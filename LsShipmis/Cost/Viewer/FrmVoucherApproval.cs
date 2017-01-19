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
using ShipMisZHJ_WorkFlow.Services;
using BaseInfo.DataAccess;
using ShipMisZHJ_WorkFlow.BusinessClasses;
using BaseInfo.Objects;
using ShipMisZHJ_WorkFlow.Forms;
using System.Drawing;
using CommonViewer.BaseForm;

namespace Cost.Viewer
{
    public partial class FrmVoucherApproval : CommonViewer.BaseForm.FormBase
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmVoucherApproval instance = new FrmVoucherApproval();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmVoucherApproval Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmVoucherApproval.instance = new FrmVoucherApproval();
                }
                return FrmVoucherApproval.instance;
            }
        }
        #endregion

        #region 窗体对象
        IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();

        VOUCHER currentObject;

        bool isFirstLoadMain = true;
        bool COST_VIEW_RIGHT = false;
        CommonOperation.Functions.ProxyRight proxyRight = CommonOperation.Functions.ProxyRight.Instance;//权限代理业务类.
        public int showStatic = 0;//0:默认状态；1：打回状态

        #endregion

        private FrmVoucherApproval()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 主窗体加载.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmVoucherApproval_Load(object sender, EventArgs e)
        {
            ucShipSelect1.ChangeSelectedState(true, true);

            SetComboBox();
            loadMainData();
            string sChkMessage;
            COST_VIEW_RIGHT = proxyRight.CheckRight(CommonOperation.ConstParameter.COST_VIEW, out sChkMessage)
               && !proxyRight.CheckRight(CommonOperation.ConstParameter.COST_OPERATION, out sChkMessage);

            btnSame.Enabled = (CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME == "财务经理岗位");
            btnReverse.Enabled = (CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME == "财务经理岗位");
            String postName = CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME;
            if (!String.IsNullOrEmpty(postName))
            {
                btnCheck.Enabled = ("机务经理岗位,总经理岗位,财务主管岗位,财务经理岗位".Contains(postName));
            }
            else { btnCheck.Enabled = false; }
        }

        /// <summary>
        /// 主窗体关闭.
        /// </summary>
        private void FrmVoucherApproval_FormClosed(object sender, FormClosedEventArgs e)
        {
            dgvMain.SaveGridView("FrmVoucherApproval.dgvMain");
            FileOperation.FileBoundingOperation.Instance.FileBoundCheck("", "", 0, null);
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

        private void SetComboBox()
        {
            DataTable dtb = new DataTable();
            dtb.Columns.Add("ID", typeof(string));
            dtb.Columns.Add("NAME", typeof(string));
            dtb.Rows.Add("", "全部");
            //dtb.Rows.Add("1", "未提交");
            dtb.Rows.Add("2", "审核中");
            dtb.Rows.Add("6", "仅等待我审核");
            dtb.Rows.Add("3", "被打回");
            dtb.Rows.Add("4", "审批完成");
            dtb.Rows.Add("5", "已同步SAP");


            cbxState.DisplayMember = "NAME";
            cbxState.ValueMember = "ID";
            cbxState.DataSource = dtb;
            if (showStatic == 1)
                cbxState.Text = "被打回";
            else
                cbxState.Text = "仅等待我审核";
        }

        /// <summary>
        /// 加载主列表数据.
        /// </summary>
        public void loadMainData()
        {
            currentObject = null;
            string err;
            DataTable dt = VOUCHERService.Instance.getInfoByPaymentDate(1, dateYear.Value, cbxState.SelectedValue.ToString(), CommonOperation.ConstParameter.UserId, ucShipSelect1.GetId(), out err);
            dgvMain.DataSource = dt;
            if (isFirstLoadMain)
                loadDataCol();

            string last = "";
            Color groupColor = Color.FromArgb(220, 240, 255);
            Color c = Color.White;
            foreach (DataGridViewRow item in dgvMain.Rows)
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

        /// <summary>
        /// 设置主列项.
        /// </summary>
        private void loadDataCol()
        {
            Dictionary<string, string> dictColumns = new Dictionary<string, string>();
            //设置列标题.
            dictColumns.Add("VOUCHER_NUM", "凭证号");
            dictColumns.Add("VOUCHER_DATE", "凭证日期");
            dictColumns.Add("APPLY_COMPANY", "申请单位");
            dictColumns.Add("SHIP_OWNER", "应收船东");
            dictColumns.Add("PAYEE", "收款人");
            dictColumns.Add("INVOICE_NUM", "附发票份数");
            dictColumns.Add("NODE_NAME", "科目");
            dictColumns.Add("DESCRIPTION", "项目说明");
            dictColumns.Add("Code", "费用科目编码");
            dictColumns.Add("CURRENCYNAME", "币种");
            dictColumns.Add("AMOUNT", "项目金额");
            dictColumns.Add("SUMAMOUNT", "凭证总金额");
            dictColumns.Add("CURRENT_STATE_NAME", "状态");
            dictColumns.Add("CURRENT_POSTID", "当前审批岗位");
            dictColumns.Add("remark", "费用说明");
            dictColumns.Add("APPLICANT", "提交人");
            dgvMain.SetDgvGridColumns(dictColumns);
            //      dgvMain.LoadGridView("FrmVoucherApproval.dgvMain");

            DataGridViewCheckBoxColumn dgvCol = new DataGridViewCheckBoxColumn();
            dgvCol.Name = "selectColumn";
            dgvCol.Width = 25;
            dgvCol.ReadOnly = true;
            dgvCol.HeaderText = "";
            dgvMain.Columns.Insert(0, dgvCol);
            isFirstLoadMain = false;

            dgvMain.SetDataGridViewNoSort();
        }

        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            loadMainData();
            FrmVoucherApproval_Shown(null, null);
        }

        private void dateYear_ValueChanged(object sender, EventArgs e)
        {
            loadMainData();
            FrmVoucherApproval_Shown(null, null);
        }

        private void dgvMain_CurrentCellChanged(object sender, EventArgs e)
        {
            txtContent.Text = "";
            if (dgvMain.CurrentRow != null)
            {
                string err = "";
                DataGridViewRow dr = dgvMain.CurrentRow;
                string objectID = dr.Cells["VOUCHER_ID"].Value.ToString();
                string shipid = dr.Cells["SHIP_ID"].Value.ToString();
                currentObject = VOUCHERService.Instance.getObject(objectID, out err);
                string COSTS_ID = dr.Cells["COSTS_ID"].Value.ToString();
                txtContent.Text = "申请人:" + dr.Cells["APPLICANT"].Value.ToString() + " 费用说明:" + dr.Cells["remark"].Value.ToString();

                FileOperation.FileBoundingOperation.Instance.FileBoundCheck(COSTS_ID, COSTS_ID,
                    CommonOperation.Enum.FileBoundingTypes.VOUCHERFILES, shipid);
                btnBdFiles.Enabled = true;
            }
        }

        #region 附件
        /// <summary>
        /// 打开电子资料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBdFiles_Click(object sender, EventArgs e)
        {
            if (currentObject == null)
            {
                MessageBoxEx.Show("请先选择一凭证!", "警告", new MessageBoxButtons(), MessageBoxIcon.Warning);
                return;
            }
            FileOperation.FileBoundingOperation.Instance.FileBoundOperation();
        }
        #endregion

        #region 审批按钮
        /// <summary>
        /// 审批
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            List<string> voucherNums = new List<string>();
            foreach (DataGridViewRow item in dgvMain.Rows)
            {
                if (Convert.ToBoolean(item.Cells["selectColumn"].Value))
                {
                    if (item.Cells["CURRENT_STATE"].Value.ToString() != "2" && item.Cells["CURRENT_STATE"].Value.ToString() != "3")
                    {
                        MessageBoxEx.Show("选择的凭证中存在不需要审批的数据");
                        return;
                    }
                    if (!voucherNums.Contains(item.Cells["voucher_num"].Value.ToString()))
                        voucherNums.Add(item.Cells["voucher_num"].Value.ToString());
                    else
                        continue;
                }
            }
            if (voucherNums.Count == 0)
            {
                MessageBoxEx.Show("至少选择一组凭证!", "警告", new MessageBoxButtons(), MessageBoxIcon.Warning);
                return;
            }
            List<CheckObj> voucherCheckObjs = new List<CheckObj> ();
            foreach (string voucherNum in voucherNums)
            {
                voucherCheckObjs.Add(ACTUAL_COSTSService.Instance.GetActualCostCheckObjByVoucherNum(voucherNum));
            }
            FrmCheck frm = new FrmCheck(voucherCheckObjs);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.Cancel) return;
            currentStateForWorking = frm.Current_State;
            voucherNumsForWorking = voucherNums;
            FrmBusy frm2 = new FrmBusy("正在更新业务数据的审批人信息，不能关闭程序，否则将影响打印输出", Working);
            frm2.ShowDialog();
        }
        int currentStateForWorking;
        List<string> voucherNumsForWorking = new List<string>();

        private void Working()
        {
            string err;
            if (!VOUCHERService.Instance.UpdateApproverOfList(voucherNumsForWorking, currentStateForWorking, out err))
            {
                MessageBoxEx.Show("将审核人更新到凭证记录时出错，出错信息为：" + err);
            }
            loadMainData();
        }
        #endregion

        #region 同步sap
        /// <summary>
        /// 同步sap
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSame_Click(object sender, EventArgs e)
        {
            repoartSAP();
            loadMainData();
        }
        #endregion

        #region 上报sap
        /// <summary>
        /// 上报SAP
        /// </summary>
        private void repoartSAP()
        {
            string err = "";
            List<DataGridViewRow> voucherRows = new List<DataGridViewRow>();
            foreach (DataGridViewRow item in dgvMain.Rows)
            {
                if (Convert.ToBoolean(item.Cells["selectColumn"].Value))
                {
                    if (item.Cells["CURRENT_STATE"].Value.ToString() != "4")
                    {
                        MessageBoxEx.Show("选择的凭证中存在不需要同步到SAP的数据");
                        return;
                    }
                    voucherRows.Add(item);
                }
            }
            if (voucherRows.Count == 0)
            {
                MessageBoxEx.Show("至少选择一组凭证!", "警告", new MessageBoxButtons(), MessageBoxIcon.Warning);
                return;
            }

            List<string> voucher_nums = new List<string>();
            foreach (DataGridViewRow item in voucherRows)
            {
                List<string> sqlList = new List<string>();
                string voucher_num = item.Cells["voucher_num"].Value.ToString();
                string business_code = item.Cells["BUSINESS_CODE"].Value.ToString();
                if (!voucher_nums.Contains(voucher_num))
                {
                    voucher_nums.Add(voucher_num);

                    DataTable dtb;
                    if (string.IsNullOrEmpty(business_code)) //纯费用类型.
                    {
                        if (!VOUCHERService.Instance.GetCostToSAP(voucher_num, out dtb, out err))
                        {
                            MessageBoxEx.Show(err, "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (!Cost.CostConfig.createMessage(item.Cells["ship_id"].Value.ToString(), DateTime.Now, DateTime.Now, voucher_num, dtb, "2", "4", sqlList, out err))
                        {
                            MessageBoxEx.Show("将变化数据发送给SAP时发生错误,错误信息请参考:\r" + err);
                            return;
                        }
                    }
                    else
                    {
                        if (!VOUCHERService.Instance.GetCostMaterialToSAP(business_code, out dtb, out err))
                        {
                            MessageBoxEx.Show(err, "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (!Cost.CostConfig.createMessage(item.Cells["ship_id"].Value.ToString(), DateTime.Now, DateTime.Now, voucher_num, dtb, "1", "4", sqlList, out err))
                        {
                            MessageBoxEx.Show("将变化数据发送给SAP时发生错误,错误信息请参考:\r" + err);
                            return;
                        }
                    }
                }
                sqlList.Add(VOUCHERService.Instance.UpdateState(voucher_num, 5));
                sqlList.Add(ACTUAL_COSTSService.Instance.UpdateState(voucher_num, 6));

                if (!CostBudgetService.Instance.ExecSql(sqlList, out err))
                {
                    MessageBoxEx.Show("将变化数据发送给SAP时发生错误,错误信息请参考:\r" + err);
                    return;
                }
            }
            MessageBoxEx.Show("同步SAP成功");
        }
        #endregion

        #region 撤销sap
        /// <summary>
        /// 撤销sap
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReverse_Click(object sender, EventArgs e)
        {
            string err = "";
            Dictionary<string, string> voucherNums = new Dictionary<string, string>();
            foreach (DataGridViewRow item in dgvMain.Rows)
            {
                if (Convert.ToBoolean(item.Cells["selectColumn"].Value))
                {
                    if (item.Cells["CURRENT_STATE"].Value.ToString() != "5")
                    {
                        MessageBoxEx.Show("选择的凭证中存在不能撤销的数据");
                        return;
                    }
                    if (!voucherNums.ContainsKey(item.Cells["voucher_num"].Value.ToString()))
                        voucherNums.Add(item.Cells["voucher_num"].Value.ToString(), item.Cells["ship_id"].Value.ToString());
                }
            }
            if (voucherNums.Count == 0)
            {
                MessageBoxEx.Show("至少选择一组凭证!", "警告", new MessageBoxButtons(), MessageBoxIcon.Warning);
                return;
            }

            int stateCode;
            foreach (string item in voucherNums.Keys)
            {
                List<string> sqlList = new List<string>();
                if (!Cost.CostConfig.reverseAccount(item, sqlList, out stateCode, out err))
                {
                    MessageBoxEx.Show("将变化数据发送给SAP时发生错误,错误信息请参考:\r" + err);
                    return;
                }

                sqlList.Add(VOUCHERService.Instance.UpdateState(item, 2));
                sqlList.Add(ACTUAL_COSTSService.Instance.UpdateState(item, 4));

                T_WorkFlowService.Instance.RejectBusiness(voucherNums[item], item, "凭证审核流程", false, out err, "SAP打回");

                if (!CostBudgetService.Instance.ExecSql(sqlList, out err))
                {
                    MessageBoxEx.Show("将变化数据发送给SAP时发生错误,错误信息请参考:\r" + err);
                    return;
                }
            }
            MessageBoxEx.Show("成功撤销上报SAP操作.");
            loadMainData();
        }
        #endregion


        private void ckbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvMain.Rows)
                item.Cells["selectColumn"].Value = ckbSelectAll.Checked;
        }

        private void lnkClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ckbSelectAll.Checked = false;
            foreach (DataGridViewRow item in dgvMain.Rows)
            {
                item.Cells["selectColumn"].Value = false;
            }
        }

        private void lnkReverse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            foreach (DataGridViewRow item in dgvMain.Rows)
            {
                item.Cells["selectColumn"].Value = !Convert.ToBoolean(item.Cells["selectColumn"].Value);
            }
            ckbSelectAll.Checked = false;
        }

        #region 查看审批记录
        private void btnCheckRecode_Click(object sender, EventArgs e)
        {
            if (currentObject == null)
            {
                MessageBoxEx.Show("请先选择一条记录!", "", new MessageBoxButtons(), MessageBoxIcon.Warning);
                return;
            }
            CheckObj checkObj = ACTUAL_COSTSService.Instance.GetActualCostCheckObjByVoucherNum(currentObject.VOUCHER_NUM);
            FrmCheck frm = new FrmCheck(checkObj, 3);
            frm.ShowDialog();
        }
        #endregion

        private void dgvMain_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (!isFirstLoadMain && dgvMain.Rows.Count > 0 && dgvMain.CurrentRow != null)
                {
                    bool selected = (bool)(dgvMain.CurrentRow.Cells["selectColumn"].Value == null
                         ? false : dgvMain.CurrentRow.Cells["selectColumn"].Value);
                    foreach (DataGridViewRow item in dgvMain.Rows)
                    {
                        if (item.Cells["voucher_num"].Value.ToString() == dgvMain.CurrentRow.Cells["voucher_num"].Value.ToString())
                            item.Cells["selectColumn"].Value = !selected;
                    }
                }
            }
        }

        private void FrmVoucherApproval_Shown(object sender, EventArgs e)
        {

            dgvMain.Columns["AMOUNT"].DefaultCellStyle.Format = "N2";
            string last = "";
            Color groupColor = Color.FromArgb(220, 240, 255);
            Color c = Color.White;
            foreach (DataGridViewRow item in dgvMain.Rows)
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
        bool isSorted = false;

        #region 费用排序
        private void btnByFeeSort_Click(object sender, EventArgs e)
        {
            if (dgvMain.DataSource != null)
            {
                if (isSorted)
                    dgvMain.Sort(dgvMain.Columns["sumAmount"], System.ComponentModel.ListSortDirection.Ascending);
                else
                    dgvMain.Sort(dgvMain.Columns["voucher_num"], System.ComponentModel.ListSortDirection.Descending);
                isSorted = !isSorted;
            }
        }
        #endregion

    }
}