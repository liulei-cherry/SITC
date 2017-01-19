using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CommonViewer.BaseControlService;
using CommonOperation.Interfaces;
using Cost.DataObject;
using Cost.Services;
using CommonViewer.BaseControl;
using CommonViewer;
using OfficeOperation;
using CommonOperation.Functions;

namespace Cost.Viewer
{
    /// <summary>
    /// 船舶分类信息管理窗体.
    /// </summary>
    /// 
    public partial class FrmVoucherSelect : CommonViewer.BaseForm.FormBase
    {

        #region 窗体对象
        private VOUCHER currentObject;
        public VOUCHER CurrentObject
        {
            get { return currentObject; }
            set { currentObject = value; }
        }

        private DateTime yearMonthDay;
        string BUDGET_ID = "";
        bool isFirstLoadMain = true;
        bool isFirstLoadDetail = true;
        string lastBusinessCode = null;
        Dictionary<string, string> dictColumns = new Dictionary<string, string>();
        DataTable dt;
        #endregion
        private FormControlOption other = FormControlOption.Instance;

        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmVoucherSelect(string BUDGET_ID)
        {
            InitializeComponent();
            this.BUDGET_ID = BUDGET_ID;
        }

        /// <summary>
        /// 主窗体加载.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmVoucherSelect_Load(object sender, EventArgs e)
        {
            SetComboBoxDate();
            loadMainData();
        }
        public void SetComboBoxDate()
        {
            string err = "";
            //凭证的月日部分.

            DataTable dtb1 = VOUCHERService.Instance.GetMonthDayByYear(dateYear.Value, out err);
            other.SetComboBoxValue(cboDay, dtb1);
        }
        /// <summary>
        /// 主窗体关闭.
        /// </summary>
        private void FrmVoucherSelect_FormClosed(object sender, FormClosedEventArgs e)
        {
            dgvMain.SaveGridView("FrmVoucherSelect.dgvMain");
            dgvDetail.SaveGridView("FrmVoucherSelect.dgvDetail");
        }
        /// <summary>
        /// 关闭窗体.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 加载主列表数据.
        /// </summary>
        public void loadMainData()
        {
            string err = "";
            lastBusinessCode = null;
            currentObject = null;
            if (cboDay.SelectedValue == null || cboDay.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                yearMonthDay = DateTime.Now;
                return;
            }

            yearMonthDay = DateTime.Parse(dateYear.Value.Year.ToString() + "-" + cboDay.SelectedValue.ToString());
            dt = VOUCHERService.Instance.getInfoByPaymentDate(3, yearMonthDay, "", CommonOperation.ConstParameter.UserId, "", out err);//获取单日凭证.
            dgvMain.DataSource = dt;
            if (dt.Rows.Count == 0)
            {
                if (dgvDetail.DataSource != null)
                {
                    DataTable dtdetail = (DataTable)dgvDetail.DataSource;
                    dtdetail.Rows.Clear();
                    dgvDetail.DataSource = dtdetail;
                }
            }
            //加载主列项.
            if (isFirstLoadMain)
                loadDataCol();
        }
        /// <summary>
        /// 设置主列项.
        /// </summary>
        private void loadDataCol()
        {
            dictColumns.Clear();

            //设置列标题.
            dictColumns.Add("VOUCHER_NUM", "凭证号");
            dictColumns.Add("APPLY_COMPANY", "申请单位");
            dictColumns.Add("SHIP_OWNER", "应收船东");
            dictColumns.Add("PAYEE", "收款人");

            dictColumns.Add("INVOICE_NUM", "附发票份数");
            dictColumns.Add("NODE_NAME", "科目");
            dictColumns.Add("DESCRIPTION", "项目说明");
            dictColumns.Add("CURRENCYNAME", "币种");
            dictColumns.Add("AMOUNT", "项目金额");
            dictColumns.Add("CURRENT_STATE_NAME", "状态");
            dgvMain.SetDgvGridColumns(dictColumns, "selectColumn");
            dgvMain.LoadGridView("FrmVoucherSelect.dgvMain");
            foreach (DataGridViewColumn item in dgvMain.Columns)
                item.ReadOnly = true;
            dgvMain.Columns["selectColumn"].ReadOnly = false;
            isFirstLoadMain = false;
        }
        /// <summary>
        /// 设置详细列表列项.
        /// </summary>
        private void SetDetailDataCol()
        {
            if (!isFirstLoadDetail)
                return;
            dictColumns.Clear();
            dictColumns.Add("MATERIAL_NAME", "物资");
            dictColumns.Add("MATERIAL_SPEC", "采购号或规格");
            dictColumns.Add("QUANTITY", "数量");
            dictColumns.Add("CURRENCY", "币种");
            dictColumns.Add("ORDER_AMOUNT", "订单金额");
            dictColumns.Add("REBATE", "折扣");
            dictColumns.Add("AMOUNT", "折算金额");
            dictColumns.Add("ACCOUNT_CODE", "费用科目编码");
            dictColumns.Add("ACCOUNT_NAME", "费用科目类型");
            dgvDetail.SetDgvGridColumns(dictColumns);
            dgvDetail.LoadGridView("FrmVoucherSelect.dgvDetail");
            isFirstLoadDetail = false;
        }
        private void dateYear_ValueChanged(object sender, EventArgs e)
        {
            loadMainData();
        }
        private void dgvMain_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvMain.CurrentRow != null)
            {
                string err = "";
                DataGridViewRow dr = dgvMain.CurrentRow;

                string objectID = "";
                if (DBNull.Value != dr.Cells["VOUCHER_ID"].Value && null != dr.Cells["VOUCHER_ID"].Value)
                    objectID = dr.Cells["VOUCHER_ID"].Value.ToString();
                string shipid = "";
                if (DBNull.Value != dr.Cells["SHIP_ID"].Value && null != dr.Cells["SHIP_ID"].Value)
                    shipid = dr.Cells["SHIP_ID"].Value.ToString();
                currentObject = VOUCHERService.Instance.getObject(objectID, out err);
                #region 绑定业务详细列表
                if (!(!string.IsNullOrEmpty(currentObject.BUSINESS_CODE) && lastBusinessCode == currentObject.BUSINESS_CODE))
                {
                    DataTable dtDetail;
                    if (!Cost.CostConfig.getPurchaseMessageByBusinessCode(currentObject.BUSINESS_CODE, out dtDetail, out err))
                    {
                        MessageBoxEx.Show(err);
                        return;
                    }
                    dgvDetail.DataSource = dtDetail;
                    SetDetailDataCol();
                }
                lastBusinessCode = currentObject.BUSINESS_CODE;
                #endregion
            }
        }

        private void bdCommit_Click(object sender, EventArgs e)
        {
            string err;
            List<string> sqlList = new List<string>();
            List<string> voucher_nums = new List<string>();

            foreach (DataGridViewRow item in dgvMain.Rows)
            {
                if (Convert.ToBoolean(item.Cells["selectColumn"].Value))
                {
                    VOUCHER tempObject = VOUCHERService.Instance.getObject(item.Cells["VOUCHER_ID"].Value.ToString(), out err);
                    tempObject.BUDGET_ID = this.BUDGET_ID;
                    sqlList.Add(tempObject.Update());
                    string voucher_num = item.Cells["voucher_num"].Value.ToString();
                    if (!voucher_nums.Contains(voucher_num))
                    {
                        voucher_nums.Add(voucher_num);
                    }
                }
            }

            if (!VOUCHERService.Instance.ExecSql(sqlList, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            else
            {
                this.Close();
            }
        }

        private void FrmVoucherSelect_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvMain.SaveGridView("FrmVoucherSelect.dgvMain");
            dgvDetail.SaveGridView("FrmVoucherSelect.dgvDetail");
        }

        private void dgvMain_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvMain.Columns["selectColumn"].Index == e.ColumnIndex)
            {
                bool selectChecked = Convert.ToBoolean(dgvMain.Rows[e.RowIndex].Cells["selectColumn"].Value);
                foreach (DataGridViewRow item in dgvMain.Rows)
                {
                    if (item.Cells["voucher_num"].Value.ToString() == dgvMain.Rows[e.RowIndex].Cells["voucher_num"].Value.ToString())
                        item.Cells["selectColumn"].Value = selectChecked;
                }
            }
        }
        private void cboDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadMainData();

        }

    }
}