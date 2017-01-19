/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 创 建 人：夏喜龙
 * 创建时间：2011-5-12
 * 功能描述：
 * 修 改 人： 
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
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
using System.Drawing;
using ShipMisZHJ_WorkFlow.BusinessClasses;
using ShipMisZHJ_WorkFlow.Forms;
using CommonOperation.Enum;

namespace Cost.Viewer
{
    /// <summary>
    /// 船舶分类信息管理窗体.
    /// </summary>
    /// 
    public partial class FrmVoucher : CommonViewer.BaseForm.BaseMdiChildForm
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmVoucher instance = new FrmVoucher();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmVoucher Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmVoucher.instance = new FrmVoucher();
                }
                return FrmVoucher.instance;
            }
        }
        #endregion

        #region 窗体对象

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();

        private VOUCHER currentObject;
        public VOUCHER CurrentObject
        {
            get { return currentObject; }
            set { currentObject = value; }
        }

        private DateTime yearMonthDay;

        bool isFirstLoadMain = true;
        bool isFirstLoadDetail = true;
        string lastBusinessCode = null;
        Dictionary<string, string> dictColumns = new Dictionary<string, string>();
        DataTable dt;
        bool COST_VIEW_RIGHT = false;
        private CommonOperation.Functions.ProxyRight proxyRight = CommonOperation.Functions.ProxyRight.Instance;//权限代理业务类.
        private FormControlOption other = FormControlOption.Instance;

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmVoucher()
        {
            InitializeComponent();
        }

        #region 主窗体加载
        /// <summary>
        /// 主窗体加载.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmVoucher_Load(object sender, EventArgs e)
        {
            SetComboBox();
            SetComboBoxDate();
            loadMainData();
            string sChkMessage;
            COST_VIEW_RIGHT = proxyRight.CheckRight(CommonOperation.ConstParameter.COST_VIEW, out sChkMessage)
               && !proxyRight.CheckRight(CommonOperation.ConstParameter.COST_OPERATION, out sChkMessage);
            //liulei-2016-03-18只有机务财务可以生成单日凭证
            
            COST_VIEW_RIGHT = CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME != "机务财务岗位";
            if (COST_VIEW_RIGHT)
            {
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                btnManage.Enabled = false;
                btnReturn.Enabled = false;
                btnNullify.Enabled = false;
                btnCommit.Enabled = false;//提交按钮 liulei-2016-03-18
            }
            

        }
        #endregion

        #region 设置凭证的月日下拉列表
        public void SetComboBoxDate()
        {
            string err = "";

            //凭证的月日部分.
            DataTable dtb1 = VOUCHERService.Instance.getMonthDayByYear(dateYear.Value, null, out err);
            other.SetComboBoxValue(cboDay, dtb1);
        }
        #endregion

        #region 主窗体关闭
        /// <summary>
        /// 主窗体关闭.
        /// </summary>
        private void FrmVoucher_FormClosed(object sender, FormClosedEventArgs e)
        {
            FileOperation.FileBoundingOperation.Instance.FileBoundCheck("", "", 0, null);
            instance = null;
        }
        #endregion

        #region 关闭窗体
        /// <summary>
        /// 关闭窗体.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 设置下拉列表
        private void SetComboBox()
        {
            DataTable dtb = new DataTable();
            dtb.Columns.Add("ID", typeof(string));
            dtb.Columns.Add("NAME", typeof(string));
            dtb.Rows.Add("", "全部");
            dtb.Rows.Add("1", "未提交");
            dtb.Rows.Add("2", "审核中");
            dtb.Rows.Add("3", "被打回(审批)");
            dtb.Rows.Add("7", "被打回(凭证)");
            dtb.Rows.Add("8", "被打回(机务已修改)");
            dtb.Rows.Add("4", "审批完成");
            dtb.Rows.Add("5", "已同步SAP");
            dtb.Rows.Add("9", "作废");
            cbxState.DisplayMember = "NAME";
            cbxState.ValueMember = "ID";
            cbxState.DataSource = dtb;
            cbxState.SelectedValue = "1";

            DataTable dtb3 = dtb.Copy();
            cbxState2.DisplayMember = "NAME";
            cbxState2.ValueMember = "ID";
            cbxState2.DataSource = dtb3;
            cbxState2.SelectedValue = "";

            //月份加全部
            DataTable dtb2 = new DataTable();
            dtb2.Columns.Add("ID", typeof(string));
            dtb2.Columns.Add("NAME", typeof(string));
            dtb2.Rows.Add("", "全部");
            dtb2.Rows.Add("1", "1");
            dtb2.Rows.Add("2", "2");
            dtb2.Rows.Add("3", "3");
            dtb2.Rows.Add("4", "4");
            dtb2.Rows.Add("5", "5");
            dtb2.Rows.Add("6", "6");
            dtb2.Rows.Add("7", "7");
            dtb2.Rows.Add("8", "8");
            dtb2.Rows.Add("9", "9");
            dtb2.Rows.Add("10", "10");
            dtb2.Rows.Add("11", "11");
            dtb2.Rows.Add("12", "12");
            cboMonth.DisplayMember = "NAME";
            cboMonth.ValueMember = "ID";
            cboMonth.DataSource = dtb2;


        }
        #endregion

        #region 加载主列表数据
        /// <summary>
        /// 加载主列表数据.
        /// </summary>
        public void loadMainData()
        {
            string err = "";
            lastBusinessCode = null;
            currentObject = null;
            bool selected = tabControl1.SelectedIndex == 0 ? true : false;

            if (selected)
            {
                if (cboDay.SelectedValue == null || cboDay.SelectedValue.ToString() == "System.Data.DataRowView")
                {
                    yearMonthDay = DateTime.Now;
                    if (dgvMain.DataSource != null) dgvMain.DataSource = ((DataTable)dgvMain.DataSource).Clone();
                    return;
                }

                yearMonthDay = DateTime.Parse(dateYear.Value.Year.ToString() + "-" + cboDay.SelectedValue.ToString());
                dt = VOUCHERService.Instance.getInfoByPaymentDate(3, yearMonthDay, cbxState.SelectedValue.ToString(), CommonOperation.ConstParameter.UserId, "", out err);//获取单日凭证(单日).

            }
            else
            {
                bool isYear = "".Equals(cboMonth.SelectedValue.ToString()) ? true : false;
                DateTime yearMonth = DateTime.Parse(dateYear2.Value.Year.ToString() + "-" + (isYear ? "1" : cboMonth.Text.ToString()));
                dt = VOUCHERService.Instance.getInfoByPaymentDate(isYear ? 1 : 2, yearMonth, cbxState2.SelectedValue.ToString(), CommonOperation.ConstParameter.UserId, "", out err);//获取单日凭证.（年月）
            }


            dgvMain.DataSource = dt;
            if (dt.Rows.Count == 0)
            {
                if (dgvDetail.DataSource != null)
                {
                    DataTable dtdetail = (DataTable)dgvDetail.DataSource;
                    dtdetail.Rows.Clear();
                    dgvDetail.DataSource = dtdetail;
                }
                btnManage.Enabled = false;
                btnBdFiles.Enabled = false;
                btnDelete.Enabled = false;
                btnReturn.Enabled = false;
                btnNullify.Enabled = false;

            }
            //加载主列项.

            if (isFirstLoadMain)
            {
                loadDataCol();
            }

            //string last = "";
            //Color groupColor = Color.FromArgb(220, 240, 255);
            //Color c = Color.White;
            //foreach (DataGridViewRow item in dgvMain.Rows)
            //{
            //    if (item.Cells["voucher_num"].Value.ToString() != last)
            //    {
            //        last = item.Cells["voucher_num"].Value.ToString();
            //        if (c == groupColor)
            //            c = Color.White;
            //        else
            //            c = groupColor;
            //    }

            //    //被打回状态(在凭证中，3表示打回；在费用中，7'打回' 8'打回后提交')的颜色显示
            //    if ("3".Equals(item.Cells["CURRENT_STATE"].Value.ToString()) && !"7,8".Contains(item.Cells["SENDED"].Value.ToString()))
            //        c = Color.Red;
            //    if ("3".Equals(item.Cells["CURRENT_STATE"].Value.ToString()) && "7".Equals(item.Cells["SENDED"].Value.ToString()))
            //        c = Color.Yellow;
            //    if ("3".Equals(item.Cells["CURRENT_STATE"].Value.ToString()) && "8".Equals(item.Cells["SENDED"].Value.ToString()))
            //        c = Color.Green;

            //    item.DefaultCellStyle.BackColor = c;
            //}
        }
        #endregion

        #region 设置表头
        /// <summary>
        /// 设置主列项.
        /// </summary>
        private void loadDataCol()
        {
            dictColumns.Clear();

            //设置列标题.
            dictColumns.Add("VOUCHER_NUM", "凭证号");
            dictColumns.Add("VOUCHER_DATE", "凭证日期");
            dictColumns.Add("SHIP_OWNER", "应收船东");
            dictColumns.Add("APPLICANT", "提交人");
            dictColumns.Add("NODE_NAME", "科目");
            dictColumns.Add("Code", "费用科目编码");
            dictColumns.Add("DESCRIPTION", "项目说明");
            dictColumns.Add("PAYEE", "收款人");
            dictColumns.Add("AMOUNT", "项目金额");
            dictColumns.Add("CURRENCYNAME", "币种");
            dictColumns.Add("CURRENT_STATE_NAME", "状态");
            dictColumns.Add("remark", "费用说明");
            dictColumns.Add("INVOICE_NUM", "附发票份数");
            dictColumns.Add("APPLY_COMPANY", "申请单位");
            dgvMain.SetDgvGridColumns(dictColumns);
            //     dgvMain.LoadGridView("FrmVoucher.dgvMain");
            DataGridViewCheckBoxColumn dgvCol = new DataGridViewCheckBoxColumn();
            dgvCol.Name = "selectColumn";
            dgvCol.Width = 25;
            dgvCol.ReadOnly = true;
            dgvCol.HeaderText = "";
            dgvMain.Columns.Insert(0, dgvCol);
            isFirstLoadMain = false;
            dgvMain.SetDataGridViewNoSort();
        }
        #endregion

        #region 设置详细列表列项
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
            dictColumns.Add("ORDER_AMOUNT", "订单金额");
            dictColumns.Add("CURRENCY", "币种");
            dictColumns.Add("REBATE", "折扣");
            dictColumns.Add("AMOUNT", "折算金额");
            dictColumns.Add("ACCOUNT_CODE", "费用科目编码");
            dictColumns.Add("ACCOUNT_NAME", "费用科目类型");
            dgvDetail.SetDgvGridColumns(dictColumns);
            //    dgvDetail.LoadGridView("FrmVoucher.dgvDetail");
            isFirstLoadDetail = false;
        }
        #endregion

        private void dateYear_ValueChanged(object sender, EventArgs e)
        {
            //string err = "";

            //凭证的月日部分.
            //DataTable dtb1 = VOUCHERService.Instance.getMonthDayByYear(dateYear.Value, null, out err);
            //other.SetComboBoxValue(cboDay, dtb1);
            SetComboBoxDate();
            loadMainData();
        }

        private void dateYear2_ValueChanged(object sender, EventArgs e)
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
                string COSTS_ID = dr.Cells["COSTS_ID"].Value.ToString();

                //FileOperation.FileBoundingOperation.Instance.FileBoundCheck(COSTS_ID, COSTS_ID,
                //    CommonOperation.Enum.FileBoundingTypes.VOUCHERFILES, shipid);
                //权限设置.
                if (!COST_VIEW_RIGHT)
                {

                    if (currentObject.CURRENT_STATE == 1 || (currentObject.CURRENT_STATE == 3))
                    {
                        btnCommit.Enabled = true;
                        btnReturn.Enabled = true;
                        btnNullify.Enabled = true;
                    }
                    else
                    {
                        btnCommit.Enabled = false;
                        btnReturn.Enabled = false;
                        btnNullify.Enabled = false;
                    }
                    btnManage.Enabled = (currentObject.CURRENT_STATE == 1 || currentObject.CURRENT_STATE == 3);
                    btnBdFiles.Enabled = true;
                    btnDelete.Enabled = (currentObject.CURRENT_STATE == 1 || currentObject.CURRENT_STATE == 6);
                }

                //绑定附件，设置附件编辑的权限-liulei/2016/01/11
                FileOperationBase.Services.right right = FileOperationBase.Services.right.C;
                if (!btnBdFiles.Enabled)
                {
                    right = FileOperationBase.Services.right.R;//只读权限

                }
                FileOperation.FileBoundingOperation.Instance.FileBoundCheck(COSTS_ID, COSTS_ID,
                    CommonOperation.Enum.FileBoundingTypes.VOUCHERFILES, shipid, right);

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

        #region 导出报表
        /// <summary>
        /// 打开导出报表窗口.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportReport_Click(object sender, EventArgs e)
        {
            string err = "";

            //确定哪些凭证需要打印
            List<string> voucherIDs = new List<string>();
            foreach (DataGridViewRow item in dgvMain.Rows)
            {
                if (Convert.ToBoolean(item.Cells["selectColumn"].Value))
                {
                    if (item.Cells["CURRENT_STATE"].Value.ToString() == "1")
                    {
                        MessageBoxEx.Show("选择的凭证中存在不需要提交的数据");
                        return;
                    }
                    voucherIDs.Add(item.Cells["VOUCHER_ID"].Value.ToString());
                }
            }
            if (voucherIDs.Count == 0)
            {
                MessageBoxEx.Show("至少选择一组凭证!", "警告", new MessageBoxButtons(), MessageBoxIcon.Warning);
                return;
            }


            OperationExcel operationExcel = null;
            try
            {
                if (!ACTUAL_COSTSService.Instance.GetOperationExcelOfVoucher(voucherIDs, out operationExcel, out err))
                {
                    MessageBoxEx.Show("未正常获取信息,不能输出,错误原因是:" + err, "错误", new MessageBoxButtons(), MessageBoxIcon.Error);

                }
                else
                {
                    FrmOurReport frm = new FrmOurReport("单日凭证导出", operationExcel);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                err = ex.Message;
                MessageBoxEx.Show(err);
            }
            finally
            {
                if (operationExcel != null)
                    operationExcel.Dispose();
            }

        }
        #endregion

        #region IFunctionChildWindow 成员

        public new List<CommonOperation.BaseClass.Authority> GetAllAuthorityCanOpenThisWindow()
        {
            List<CommonOperation.BaseClass.Authority> re = new List<CommonOperation.BaseClass.Authority>();
            re.Add(CommonOperation.BaseClass.Authority.GetALoginUserAuthority());//最低权限即可.

            return re;
        }

        //本窗体不受限制.
        public new bool JudgeTheAuthorityCanOpenThisWindow(CommonOperation.BaseClass.Authority theAuthority)
        {
            return true;
        }

        private IFunctionMainWindow theMainForm;
        public new IFunctionMainWindow TheMainForm
        {
            get { return theMainForm; }
            set { theMainForm = value; }
        }

        #endregion

        #region 增加凭证
        /// <summary>
        /// 增加凭证.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            VOUCHER temp = new VOUCHER();
            temp.VOUCHER_ID = null;
            temp.VOUCHER_DATE = DateTime.Now;
            temp.APPLY_COMPANY = "海丰发展";
            temp.CURRENT_STATE = 1;
            temp.APPLICANT = CommonOperation.ConstParameter.UserName;

            FrmEditOneVoucher frm = new FrmEditOneVoucher(temp);
            frm.ShowDialog();

            //加载主数据.
            SetComboBoxDate();
            loadMainData();
        }
        #endregion

        #region 编辑凭证
        /// <summary>
        /// 管理凭证.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnManage_Click(object sender, EventArgs e)
        {
            if (currentObject == null)
            {
                MessageBoxEx.Show("请先选择一凭证,再做修改!", "警告", new MessageBoxButtons(), MessageBoxIcon.Warning);
                return;
            }
            FrmEditOneVoucher frm = new FrmEditOneVoucher(currentObject);
            frm.ShowDialog();

            //加载主数据.
            SetComboBoxDate();

            loadMainData();
        }
        #endregion

        #region 绑定附件
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

        private void ckbDisplayInvalid_CheckedChanged(object sender, EventArgs e)
        {
            loadMainData();
        }

        #region 打回机务
        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (currentObject == null)
            {
                MessageBoxEx.Show("请先选择一凭证!", "警告", new MessageBoxButtons(), MessageBoxIcon.Warning);
                return;
            }

            string err = "";
            List<string> sqlList = null;
            if (currentObject.CURRENT_STATE == 1 || currentObject.CURRENT_STATE == 3)
            {
                if (DialogResult.No == MessageBoxEx.Show("相同凭证号的信息会一同打回,确认吗?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    return;
                sqlList = new List<string>();
                foreach (DataGridViewRow item in dgvMain.Rows)
                {
                    if (item.Cells["VOUCHER_NUM"].Value.ToString() == currentObject.VOUCHER_NUM)
                    {
                        VOUCHER obj = VOUCHERService.Instance.getObject(item.Cells["VOUCHER_ID"].Value.ToString(), out err);
                        obj.CURRENT_STATE = 3;
                        sqlList.Add(obj.Update());

                        ACTUAL_COSTS costObj = ACTUAL_COSTSService.Instance.getObject(item.Cells["COSTS_ID"].Value.ToString(), out err);
                        costObj.SENDED = 7;
                        sqlList.Add(costObj.Update());
                        if (!string.IsNullOrEmpty(currentObject.VOUCHER_NUM))
                        {
                            T_WorkFlowService.Instance.RejectBusiness(costObj.SHIP_ID, currentObject.VOUCHER_NUM, "凭证审核流程", false, out err, "打回费用到机务（" + costObj.DESCRIPTION + ")");
                        }
                    }
                }

            }

            if (!VOUCHERService.Instance.ExecSql(sqlList, out err))
            {
                MessageBoxEx.Show("操作失败,错误原因是:" + err, "错误", new MessageBoxButtons(), MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBoxEx.Show("操作成功!", "提示", new MessageBoxButtons(), MessageBoxIcon.Information);
            }

            //加载主数据.
            loadMainData();
        }
        #endregion

        #region 作废
        private void btnNullify_Click(object sender, EventArgs e)
        {
            if (currentObject == null)
            {
                MessageBoxEx.Show("请先选择一凭证!", "警告", new MessageBoxButtons(), MessageBoxIcon.Warning);
                return;
            }

            string err = "";
            List<string> sqlList = null;
            if (currentObject.CURRENT_STATE == 1 || currentObject.CURRENT_STATE == 3)
            {
                if (DialogResult.No == MessageBoxEx.Show("相同凭证号的信息会一同作废,确认吗?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    return;
                sqlList = new List<string>();
                foreach (DataGridViewRow item in dgvMain.Rows)
                {
                    if (item.Cells["VOUCHER_NUM"].Value.ToString() == currentObject.VOUCHER_NUM)
                    {
                        VOUCHER obj = VOUCHERService.Instance.getObject(item.Cells["VOUCHER_ID"].Value.ToString(), out err);
                        obj.CURRENT_STATE = 9;
                        sqlList.Add(obj.Update());

                        ACTUAL_COSTS costObj = ACTUAL_COSTSService.Instance.getObject(item.Cells["COSTS_ID"].Value.ToString(), out err);
                        costObj.SENDED = 9;
                        sqlList.Add(costObj.Update());

                        //string checkedID = ACTUAL_COSTSService.Instance.GetCheckIDByCOSTS_ID(costObj.COSTS_ID);
                        //string checkedSQL = "";
                        //if (!string.IsNullOrEmpty(checkedID))
                        //{
                        //    checkedSQL = ShipMisZHJ_WorkFlow.Services.T_WorkFlowService.Instance.AddCheckDetail
                        //        (checkedID, CommonOperation.ConstParameter.UserName, CommonOperation.ConstParameter.LoginUserInfo.PostId,
                        //        "打回费用到机务（" + costObj.DESCRIPTION + ")", costObj.SHIP_ID);

                        //}
                        //sqlList.Add(checkedSQL);
                    }
                }

            }

            if (!VOUCHERService.Instance.ExecSql(sqlList, out err))
            {
                MessageBoxEx.Show("操作失败,错误原因是:" + err, "错误", new MessageBoxButtons(), MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBoxEx.Show("操作成功!", "提示", new MessageBoxButtons(), MessageBoxIcon.Information);
            }

            //加载主数据.
            loadMainData();
        }
        #endregion

        private void cbxState_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadMainData();
        }

        private void cbxState2_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadMainData();
        }

        private void cboDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadMainData();
        }

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadMainData();
        }

        #region 提交凭证
        private void btnCommit_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> voucherRows = new List<DataGridViewRow>();

            foreach (DataGridViewRow item in dgvMain.Rows)
            {
                if (Convert.ToBoolean(item.Cells["selectColumn"].Value))
                {
                    if (item.Cells["CURRENT_STATE"].Value.ToString() != "1"
                        && item.Cells["CURRENT_STATE"].Value.ToString() != "3")
                    {
                        MessageBoxEx.Show("选择的凭证中存在不需要提交的数据");
                        return;
                    }
                    voucherRows.Add(item);
                }
            }
            string err;
            if (voucherRows.Count == 0)
            {
                MessageBoxEx.Show("至少选择一组凭证!", "警告", new MessageBoxButtons(), MessageBoxIcon.Warning);
                return;
            }
            if (DialogResult.No == MessageBoxEx.Show("确认提交该条凭证吗?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                return;

            List<string> sqlList = new List<string>();
            List<string> voucherNums = new List<string>();
            foreach (DataGridViewRow item in voucherRows)
            {
                if (!voucherNums.Contains(item.Cells["voucher_num"].Value.ToString()))
                    voucherNums.Add(item.Cells["voucher_num"].Value.ToString());
                else
                    continue;
                string voucherNum = item.Cells["voucher_num"].Value.ToString();
                string shipID = item.Cells["ship_id"].Value.ToString();
                sqlList.Add(VOUCHERService.Instance.UpdateState(voucherNum, 2));
                sqlList.Add(ACTUAL_COSTSService.Instance.UpdateState(voucherNum, 3));
                T_WorkFlowService.Instance.AgreeBusiness(shipID, voucherNum, "凭证审核流程", false, out err);

                if (!InterfaceInstantiation.NewADbAccess().ExecSql(sqlList, out err))
                {
                    MessageBox.Show(err, "提交失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            MessageBox.Show("提交成功！", "提交成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadMainData();
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

        private void FrmVoucher_Shown(object sender, EventArgs e)
        {
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

        #region 删除凭证
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (currentObject == null)
            {
                MessageBoxEx.Show("请先选择一凭证!", "警告", new MessageBoxButtons(), MessageBoxIcon.Warning);
                return;
            }

            string err = "";
            if (DialogResult.No == MessageBoxEx.Show("删除该条信息将会把相同凭证号的信息一同删除,确认吗?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                return;
            if (VOUCHERService.Instance.DeleteVoucherActualCost(currentObject.VOUCHER_NUM, out err))
            {
                MessageBoxEx.Show("操作成功!", "提示", new MessageBoxButtons(), MessageBoxIcon.Information);
            }
            else
            {
                MessageBoxEx.Show("错误信息:" + err, "错误", new MessageBoxButtons(), MessageBoxIcon.Error);
            }


            loadMainData();
        }
        #endregion


        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            bool enabled = tabControl1.SelectedIndex == 0 ? true : false;

            btnExportReport.Enabled = enabled;
            cbxState2.SelectedValue = "";
            cboMonth.SelectedValue = "";

            loadMainData();

        }

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





    }
}