using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BaseInfo.DataAccess;
using BaseInfo.Objects;
using Cost.DataObject;
using Cost.Services;
using CommonViewer.BaseControl;
using ShipMisZHJ_WorkFlow.Forms;
using ShipMisZHJ_WorkFlow.Services;
using ShipMisZHJ_WorkFlow.BusinessClasses;
using System.Text;
using OfficeOperation;
using CommonViewer;
using CommonOperation.Functions;
using System.Drawing;

namespace Cost.Viewer
{
    /// <summary>
    /// 船舶分类信息管理窗体.
    /// </summary>
    /// 
    public partial class FrmBudget : CommonViewer.BaseForm.FormBase
    {
        #region 窗体单实例模型
        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmBudget instance = new FrmBudget();
        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmBudget Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmBudget.instance = new FrmBudget();
                }
                return FrmBudget.instance;
            }
        }
        #endregion

        bool isFirstLoadList = true;
        bool isFirstLoadVoucher = true;
        string budgetid;

        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmBudget()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 主窗体加载.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmBudget_Load(object sender, EventArgs e)
        {

            if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
            {
                btnAdd.Visible = false;
                btnAddItem.Visible = false;
                btnBdFiles.Visible = false;
                btnManage.Visible = false;
                btnDelete.Visible = false;
                btnExportReport.Visible = false;
                btnRemove.Visible = false;
            }

            btnAdd.Enabled = (CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME == "机务财务岗位");
            SetComboboxSource();
            LoadMainData();
        }
        public void SetComboboxSource()
        {
            string lastSelectItem = cboAnnual.Text;
            DataTable dt = CostBudgetService.Instance.GetGroupYear();
            DataRow dr = dt.NewRow();
            dr[0] = "全部";
            dt.Rows.InsertAt(dr, 0);
            cboAnnual.DataSource = dt;
            if (!string.IsNullOrEmpty(lastSelectItem))
                if (dt.Select("annual='" + lastSelectItem + "'").Length > 0)
                    cboAnnual.Text = lastSelectItem;
        }
        /// <summary>
        /// 主窗体关闭.
        /// </summary>
        private void FrmBudget_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvList.SaveGridView("FrmBudget.dgvList");
            dgvVoucher.SaveGridView("FrmBudget.dgvVoucher");
            instance = null;
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
        /// 加载凭证列表数据.
        /// </summary>
        public void LoadMainData()
        {
            string err = "";
            string annual = "";
            if (!string.IsNullOrEmpty(cboAnnual.Text) && cboAnnual.Text != "全部")
                annual = cboAnnual.Text;
            DataTable dt;
            if (!CostBudgetService.Instance.GetInfoByYear(annual, null, out dt, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            dgvList.DataSource = dt;
            if (isFirstLoadList)
            {
                Dictionary<string, string> dictColumns = new Dictionary<string, string>();
                dictColumns.Add("CREATE_DATE", "提交日期");
                dictColumns.Add("APPROVE_NUM", "审批号");
                dictColumns.Add("POST", "审核职务");
                dgvList.SetDgvGridColumns(dictColumns);
                dgvList.LoadGridView("FrmBudget.dgvList");
                isFirstLoadList = false;
            }
            LoadVocherData();
            if (dt.Rows.Count == 0)
            {
                budgetid = "";
                if (dgvVoucher.DataSource != null)
                {
                    DataTable dtdetail = (DataTable)dgvVoucher.DataSource;
                    dtdetail.Rows.Clear();
                    dgvVoucher.DataSource = dtdetail;
                    btnBdFiles.Enabled = false;
                }

                textBoxEx2.Text = "";
                textBoxEx3.Text = "";
                textBoxEx4.Text = "";
                num1.Value = 0;
                num2.Value = 0;
                num3.Value = 0;
                num4.Value = 0;
                num5.Value = 0;
                num6.Value = 0;
                num7.Value = 0;
                num8.Value = 0;
                num9.Value = 0;
                num10.Value = 0;
                num11.Value = 0;
                num12.Value = 0;

                btnManage.Enabled = false;
                btnDelete.Enabled = false;
                btnRemove.Enabled = false;
                btnAddItem.Enabled = false;
                btnBdFiles.Enabled = false;
            }
        }

        /// <summary>
        /// 设置主列项.
        /// </summary>
        private void LoadVocherData()
        {
            string err;
            if (dgvList.CurrentRow == null)
                return;
            DataTable dt;
            string id = dgvList.CurrentRow.Cells["BUDGET_ID"].Value.ToString();
            if (!VOUCHERService.Instance.GetByBudgetID(id, out dt, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            if (dt.Rows.Count != 0)
            {
                textBoxEx2.Text = dt.Rows[0]["PAYMENT_DATE"].ToString();
            }
            else
            {
                textBoxEx2.Text = "";
            }
            dgvVoucher.DataSource = dt;
            if (isFirstLoadVoucher)
            {
                Dictionary<string, string> dictColumns = new Dictionary<string, string>();
                dictColumns.Add("CUSTOMER", "客户");
                dictColumns.Add("SHIP_OWNER", "应收船东");
                dictColumns.Add("VOUCHER_NUM", "凭证号");
                dictColumns.Add("CURRENCYNAME", "币别");
                dictColumns.Add("AMOUNT", "金额");
                dictColumns.Add("CONTRACT_NUM", "合同评审号");
                dictColumns.Add("DESCRIPTION", "付款说明");
                dictColumns.Add("APPLICANT", "申请人");
                dictColumns.Add("APPROVER", "审核人");
                dictColumns.Add("APPROVER2", "批准人");
                dictColumns.Add("PAYMENT_DATE", "付款日期");
                dictColumns.Add("REMARK", "备注");
                dictColumns.Add("CURRENT_STATE_NAME", "状态");
                dgvVoucher.SetDgvGridColumns(dictColumns);
                dgvVoucher.LoadGridView("FrmBudget.dgvVoucher");
                isFirstLoadVoucher = false;
            }
            btnBdFiles.Enabled = (dgvVoucher.Rows.Count != 0);

            string last = "";
            Color groupColor = Color.FromArgb(220, 240, 255);
            Color c = Color.White;
            foreach (DataGridViewRow item in dgvVoucher.Rows)
            {
                if (item.Cells["voucher_num"].Value.ToString() != last)
                {
                    last = item.Cells["voucher_num"].Value.ToString();
                    if (c == groupColor)
                        c = Color.White;
                    else
                        c = groupColor;
                }
                item.DefaultCellStyle.BackColor = c;
            }
        }

        private void dateYear_ValueChanged(object sender, EventArgs e)
        {
            LoadMainData();
        }

        /// <summary>
        /// 打开导出报表窗口.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportReport_Click(object sender, EventArgs e)
        {
            if (dgvList.CurrentRow == null)
            {
                MessageBoxEx.Show("请先选择一条预算!", "警告", new MessageBoxButtons(), MessageBoxIcon.Warning);
                return;
            }

            List<OperationExcel> operationExcel = null;

            try
            {

                string err;
                if (!ACTUAL_COSTSService.Instance.GetOperationExcelOfWeekBudget(dgvList.CurrentRow.Cells["BUDGET_ID"].Value.ToString(), getMainInfo(), out operationExcel, out err))
                {
                    MessageBoxEx.Show("未正常获取信息,不能输出,错误信息为:\r" + err);
                }
                else
                {
                    FrmOurReport frm = new FrmOurReport("周预算导出", operationExcel);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {

                MessageBoxEx.Show("不能输出,错误信息为:\r" + ex);
            }
            finally
            {
                if (operationExcel != null)
                {
                    operationExcel.Clear();
                    operationExcel = null;
                }
            }
        }

        /// <summary>
        /// 获取预算主信息.
        /// </summary>
        private Dictionary<string, string> getMainInfo()
        {
            Dictionary<string, string> mainInfo = new Dictionary<string, string>();
            mainInfo.Add("1", textBoxEx1.Text);
            mainInfo.Add("2", textBoxEx2.Text);
            mainInfo.Add("3", textBoxEx3.Text);
            mainInfo.Add("4", textBoxEx4.Text);
            mainInfo.Add("c1", Decimal.Round(num1.Value, 2).ToString());
            mainInfo.Add("c2", Decimal.Round(num2.Value, 2).ToString());
            mainInfo.Add("c3", Decimal.Round(num3.Value, 2).ToString());
            mainInfo.Add("u1", Decimal.Round(num4.Value, 2).ToString());
            mainInfo.Add("u2", Decimal.Round(num5.Value, 2).ToString());
            mainInfo.Add("u3", Decimal.Round(num6.Value, 2).ToString());
            mainInfo.Add("e1", Decimal.Round(num7.Value, 2).ToString());
            mainInfo.Add("e2", Decimal.Round(num8.Value, 2).ToString());
            mainInfo.Add("e3", Decimal.Round(num9.Value, 2).ToString());
            mainInfo.Add("j1", Decimal.Round(num10.Value, 2).ToString());
            mainInfo.Add("j2", Decimal.Round(num11.Value, 2).ToString());
            mainInfo.Add("j3", Decimal.Round(num12.Value, 2).ToString());
            return mainInfo;

        }

        private void cboAnnual_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMainData();
        }
        private void cbxState_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMainData();
        }
        private void dgvList_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvList.CurrentRow == null) return;
            budgetid = dgvList.CurrentRow.Cells["BUDGET_ID"].Value.ToString();
            //textBoxEx1.Text = dgvList.Rows[e.RowIndex].Cells[""].Value.ToString();
            textBoxEx3.Text = dgvList.CurrentRow.Cells["APPROVE_NUM"].Value.ToString();
            textBoxEx4.Text = dgvList.CurrentRow.Cells["REMARK"].Value.ToString();
            num1.Value = ((decimal)dgvList.CurrentRow.Cells["S_CNY_AMOUNT"].Value);
            num2.Value = ((decimal)dgvList.CurrentRow.Cells["Y_CNY_AMOUNT"].Value);
            num4.Value = ((decimal)dgvList.CurrentRow.Cells["S_USD_AMOUNT"].Value);
            num5.Value = ((decimal)dgvList.CurrentRow.Cells["Y_USD_AMOUNT"].Value);
            num7.Value = ((decimal)dgvList.CurrentRow.Cells["S_EUR_AMOUNT"].Value);
            num8.Value = ((decimal)dgvList.CurrentRow.Cells["Y_EUR_AMOUNT"].Value);
            num10.Value = ((decimal)dgvList.CurrentRow.Cells["S_JPY_AMOUNT"].Value);
            num11.Value = ((decimal)dgvList.CurrentRow.Cells["Y_JPY_AMOUNT"].Value);
            num3.Value = ((decimal)dgvList.CurrentRow.Cells["X_CNY_AMOUNT"].Value);
            num6.Value = ((decimal)dgvList.CurrentRow.Cells["X_USD_AMOUNT"].Value);
            num9.Value = ((decimal)dgvList.CurrentRow.Cells["X_EUR_AMOUNT"].Value);
            num12.Value = ((decimal)dgvList.CurrentRow.Cells["X_JPY_AMOUNT"].Value);
            LoadVocherData();

            CheckRight();//控制审核按钮.

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmBudgetEdit frm = new FrmBudgetEdit();
            frm.ShowDialog();
            SetComboboxSource();
            LoadMainData();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            if (dgvList.CurrentRow == null)
            {
                MessageBoxEx.Show("请先选择一条预算!", "警告", new MessageBoxButtons(), MessageBoxIcon.Warning);
                return;
            }

            FrmBudgetEdit frm = new FrmBudgetEdit(dgvList.CurrentRow.Cells["BUDGET_ID"].Value.ToString());
            frm.ShowDialog();
            SetComboboxSource();
            LoadMainData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvList.CurrentRow == null)
            {
                MessageBoxEx.Show("请先选择一条预算!", "警告", new MessageBoxButtons(), MessageBoxIcon.Warning);
                return;
            }
            if (DialogResult.No == MessageBoxEx.Show("确认删除该条预算吗?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                return;
            string err;
            List<string> voucherNums = new List<string>();
            List<string> sqlList = new List<string>();
            foreach (DataGridViewRow item in dgvVoucher.Rows)
            {
                if (!voucherNums.Contains(item.Cells["voucher_num"].Value.ToString()))
                    voucherNums.Add(item.Cells["voucher_num"].Value.ToString());
                else
                    continue;
                string voucherNum = item.Cells["voucher_num"].Value.ToString();
                string shipID = item.Cells["ship_id"].Value.ToString();
                sqlList.Add(VOUCHERService.Instance.UpdateBudgetID(voucherNum, null));
                sqlList.Add(ACTUAL_COSTSService.Instance.UpdateState(voucherNum, 2));
            }
            sqlList.Add(CostBudgetService.Instance.deleteUnit(budgetid));
            if (!CostBudgetService.Instance.ExecSql(sqlList, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            else
            {
                MessageBoxEx.Show("操作成功");
            }
            SetComboboxSource();
            LoadMainData();
        }

        private void CheckRight()
        {
            if (dgvList.CurrentRow != null)
            {
                int STATE = Convert.ToInt32(dgvList.CurrentRow.Cells["STATE"].Value);
                btnManage.Enabled = (CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME == "机务财务岗位");
                btnDelete.Enabled = (CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME == "机务财务岗位");
                btnAddItem.Enabled = (CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME == "机务财务岗位");
                btnRemove.Enabled = (CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME == "机务财务岗位");
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (dgvList.CurrentRow == null)
            {
                MessageBoxEx.Show("请先选择一条预算!", "警告", new MessageBoxButtons(), MessageBoxIcon.Warning);
                return;
            }

            FrmVoucherSelect frm = new FrmVoucherSelect(budgetid);
            frm.ShowDialog();
            SetBudgetNextWeek();
            LoadVocherData();
        }
        private void SetBudgetNextWeek()
        {
            string err;
            CostBudget currentObject = CostBudgetService.Instance.getObject(budgetid, out err);
            currentObject.X_CNY_AMOUNT = ACTUAL_COSTSService.Instance.getSumByCurrency(budgetid, "CNY", out err);
            currentObject.X_EUR_AMOUNT = ACTUAL_COSTSService.Instance.getSumByCurrency(budgetid, "EUR", out err);
            currentObject.X_JPY_AMOUNT = ACTUAL_COSTSService.Instance.getSumByCurrency(budgetid, "JPY", out err);
            currentObject.X_USD_AMOUNT = ACTUAL_COSTSService.Instance.getSumByCurrency(budgetid, "USD", out err);
            if (!currentObject.Update(out err))
            {
                MessageBoxEx.Show(err);
            }
            num3.Value = currentObject.X_CNY_AMOUNT;
            num6.Value = currentObject.X_USD_AMOUNT;
            num9.Value = currentObject.X_EUR_AMOUNT;
            num12.Value = currentObject.X_JPY_AMOUNT;
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvVoucher.CurrentRow == null)
            {
                MessageBoxEx.Show("请先选择一条凭证!", "警告", new MessageBoxButtons(), MessageBoxIcon.Warning);
                return;
            }
            string err;
            string voucher_num = dgvVoucher.CurrentRow.Cells["voucher_num"].Value.ToString();
            List<string> sqlList = new List<string>();
            sqlList.Add(VOUCHERService.Instance.UpdateBudgetID(voucher_num, null));
            sqlList.Add(ACTUAL_COSTSService.Instance.UpdateState(voucher_num, 2));
            if (!VOUCHERService.Instance.ExecSql(sqlList, out err))
                MessageBoxEx.Show(err);
            SetBudgetNextWeek();
            LoadVocherData();
        }

        private void dgvVoucher_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgvVoucher.Rows[e.RowIndex];
            string objectID = "";
            if (DBNull.Value != dr.Cells["VOUCHER_ID"].Value && null != dr.Cells["VOUCHER_ID"].Value)
                objectID = dr.Cells["VOUCHER_ID"].Value.ToString();
            string shipid = "";
            if (DBNull.Value != dr.Cells["SHIP_ID"].Value && null != dr.Cells["SHIP_ID"].Value)
                shipid = dr.Cells["SHIP_ID"].Value.ToString();
            string COSTS_ID = dr.Cells["COSTS_ID"].Value.ToString();
            FileOperation.FileBoundingOperation.Instance.FileBoundCheck(COSTS_ID, COSTS_ID,
                CommonOperation.Enum.FileBoundingTypes.VOUCHERFILES, shipid);
        }

        private void btnBdFiles_Click(object sender, EventArgs e)
        {
            if (dgvVoucher.CurrentRow == null)
            {
                MessageBoxEx.Show("请先选择一条预算!", "警告", new MessageBoxButtons(), MessageBoxIcon.Warning);
                return;
            }
            FileOperation.FileBoundingOperation.Instance.FileBoundOperation();
        }

        private void FrmBudget_Shown(object sender, EventArgs e)
        {
            string last = "";
            Color groupColor = Color.FromArgb(220, 240, 255);
            Color c = Color.White;
            foreach (DataGridViewRow item in dgvVoucher.Rows)
            {
                if (item.Cells["voucher_num"].Value.ToString() != last)
                {
                    last = item.Cells["voucher_num"].Value.ToString();
                    if (c == groupColor)
                        c = Color.White;
                    else
                        c = groupColor;
                }
                item.DefaultCellStyle.BackColor = c;
            }
        }

    }
}