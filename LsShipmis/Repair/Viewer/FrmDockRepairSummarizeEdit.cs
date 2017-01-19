using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonViewer;
using Cost.Services;
using Cost.DataObject;
using CommonViewer.BaseControl;
using CommonOperation.Interfaces;
using Repair.DataObject;
using Repair.Services;
using CommonOperation.Functions;

namespace Repair.Viewer
{
    public partial class FrmDockRepairSummarizeEdit : CommonViewer.BaseForm.FormBase
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmDockRepairSummarizeEdit instance = new FrmDockRepairSummarizeEdit();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmDockRepairSummarizeEdit Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmDockRepairSummarizeEdit.instance = new FrmDockRepairSummarizeEdit();
                }

                return FrmDockRepairSummarizeEdit.instance;
            }
        }
        #endregion
        /// <summary>
        /// 1=正常; 2=修改;
        /// </summary>
        private int functionCode = 1;
        private string SHIP_ID_Global = "";
        private DateTime BEGINDATE_Global;
        private DateTime ENDDATE_Global;
        bool isLoadedActualCost = false;
        bool isLoadedDetail = false;

        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmDockRepairSummarizeEdit()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmDockRepairSummarizeEdit(string SHIP_ID)
        {
            InitializeComponent();
            functionCode = 1;
            SHIP_ID_Global = SHIP_ID;
        }
        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmDockRepairSummarizeEdit(string SHIP_ID, DateTime BEGINDATE, DateTime ENDDATE)
        {
            InitializeComponent();
            functionCode = 2;
            SHIP_ID_Global = SHIP_ID;
            BEGINDATE_Global = BEGINDATE;
            ENDDATE_Global = ENDDATE;
        }
        private void FrmDockRepairSummarize_Load(object sender, EventArgs e)
        {
            ucShipSelect1.ChangeSelectedState(false, true);
            if (functionCode == 1)
            {
                ucShipSelect1.SelectedId(SHIP_ID_Global);
                dtpEnd.Value = DateTime.Now;
                dtpBegin.Value = DateTime.Now.AddYears(-1);
            }
            else if (functionCode == 2)
            {
                ucShipSelect1.SelectedId(SHIP_ID_Global);
                dtpBegin.Value = BEGINDATE_Global;
                dtpEnd.Value = ENDDATE_Global;
                //ImportFunction();
            }
        }
        /// <summary>
        /// 绑定坞修明细信息.
        /// </summary>
        private void SetDetailBindingSource()
        {
            if (isLoadedDetail) return;
            isLoadedDetail = true;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("SHIP_NAME", "船舶");
            dic.Add("NODE_NAME", "科目");
            dic.Add("CUSTOMER", "供应商");
            dic.Add("ESTIMATE_AMOUNT", "预估金额");
            dic.Add("TOTAL_AMOUNT", "汇总金额(美元)");
            dic.Add("CURRENCYNAME", "币种");
            dgvDetail.SetDgvGridColumns(dic);
            dgvDetail.LoadGridView("FrmDockRepairSummarizeEdit.dgvDetail");
        }
        /// <summary>
        /// 绑定实际发生费用.
        /// </summary>
        public void SetActualCostDataGridView()
        {
            if (isLoadedActualCost) return;
            isLoadedActualCost = true;
            Dictionary<string, string> dictColumns = new Dictionary<string, string>();
            dictColumns.Add("DESCRIPTION", "付费项目");
            dictColumns.Add("CUSTOMER", "供应商");
            dictColumns.Add("REMARK", "备注");
            dictColumns.Add("OCCURENCY_DATE", "发生日期");
            dictColumns.Add("PAYMENT_DATE", "付款日期");
            dictColumns.Add("CURRENCY_NAME", "币种");
            dictColumns.Add("AMOUNT", "金额");
            dictColumns.Add("NODE_NAME", "科目名称");
            dictColumns.Add("ESTIMATE_AMOUNT", "预估金额");
            dictColumns.Add("CONVERT_MONEY", "折算成美金");
            dictColumns.Add("CONTRACT_NUM", "合同评审号");
            dictColumns.Add("COMPLETE_DATE", "完成日期");
            dictColumns.Add("COMPLETE_PALCE", "完成地点");
            dictColumns.Add("APPLICANT", "申请人");
            dictColumns.Add("APPROVER", "审核人");
            dictColumns.Add("APPROVER2", "审批人");
            dictColumns.Add("INVOICE_DATE", "发票日期");
            dictColumns.Add("INVOICE_NUM", "发票号");
            dgvActualCost.SetDgvGridColumns(dictColumns);
            //设置列只读.

            dgvActualCost.LoadGridView("FrmDockRepairSummarizeEdit.dgvActualCost");
        }
        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            string err;
            if (!ImportFunction(out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
        }
        private void dtpBegin_ValueChanged(object sender, EventArgs e)
        {
            string err;
            if (!ImportFunction(out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
        }
        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            string err;
            if (!ImportFunction(out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
        }

        /// <summary>
        /// 导入项目.
        /// </summary>
        private bool ImportFunction(out string err)
        {
            DataTable dt;
            if (!ACTUAL_COSTSService.Instance.GetDockRepairInfo(ucShipSelect1.GetId(), dtpBegin.Value, dtpEnd.Value, out dt, out err))
            {
                MessageBoxEx.Show(err);
                return false;
            }
            bdsDetail.DataSource = dt;
            dgvDetail.DataSource = dt;
            SetDetailBindingSource();

            DataTable dtActualCost;
            if (!ACTUAL_COSTSService.Instance.GetActualCostInfoByCondition(ucShipSelect1.GetId(), dtpBegin.Value, dtpEnd.Value, out dtActualCost, out err))
            {
                MessageBoxEx.Show(err);
                return false;
            }
            bdsActualCost.DataSource = dtActualCost;
            dgvActualCost.DataSource = dtActualCost;
            SetActualCostDataGridView();
            return true;
        }
        /// <summary>
        /// 保存操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string err = "";
            List<string> sqlList = new List<string>();
            if (functionCode == 2)
            {
                sqlList.Add(DockRepairSummarizeService.Instance.DeleteInfoByCondition(SHIP_ID_Global, BEGINDATE_Global, ENDDATE_Global));
            }
            foreach (DataGridViewRow item in dgvDetail.Rows)
            {
                DockRepairSummarize drs = new DockRepairSummarize();
                drs.BEGINDATE = dtpBegin.Value;
                drs.ENDDATE = dtpEnd.Value;
                drs.MANUFACTURER_ID = item.Cells["MANUFACTURER_ID"].Value.ToString();
                drs.NODE_ID = item.Cells["NODE_ID"].Value.ToString();
                drs.SHIP_ID = item.Cells["SHIP_ID"].Value.ToString();
                drs.ESTIMATE_AMOUNT = DBNull.Value == item.Cells["ESTIMATE_AMOUNT"].Value ? 0:  Convert.ToDecimal(item.Cells["ESTIMATE_AMOUNT"].Value);

                drs.TOTAL_AMOUNT = Convert.ToDecimal(item.Cells["TOTAL_AMOUNT"].Value);
                drs.CURRENCY_ID = item.Cells["CURRENCY_ID"].Value.ToString();
                sqlList.Add(drs.Update());
            }
            IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
            if (!dbAccess.ExecSql(sqlList, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            MessageBoxEx.Show("操作成功");
            this.Close();
        }
        /// <summary>
        /// 正在关闭窗体.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmDockRepairSummarize_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvDetail.SaveGridView("FrmDockRepairSummarizeEdit.dgvDetail");
            dgvActualCost.SaveGridView("FrmDockRepairSummarizeEdit.dgvActualCost");
            instance = null;
        }
        /// <summary>
        /// 关闭按钮.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
