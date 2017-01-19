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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using CommonOperation.BaseClass;
using CommonViewer.BaseControlService;
using CommonOperation.Interfaces;
using BaseInfo.DataAccess;
using BaseInfo.Objects;
using System.Runtime.InteropServices;
using Cost.DataObject;
using Cost.Services;
using Cost.Viewer;
using CommonViewer.BaseControl;
using CommonOperation.Functions;
using ShipMisZHJ_WorkFlow.Forms;
using ShipMisZHJ_WorkFlow.Services;
using ShipMisZHJ_WorkFlow.BusinessClasses;
using FileOperationBase;

namespace Cost.Viewer
{
    /// <summary>
    /// 费用项目管理窗体.
    /// </summary>
    public partial class FrmShipOwnerCost : CommonViewer.BaseForm.BaseMdiChildForm
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmShipOwnerCost instance = new FrmShipOwnerCost();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmShipOwnerCost Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmShipOwnerCost.instance = new FrmShipOwnerCost();
                }
                return FrmShipOwnerCost.instance;
            }
        }
        #endregion

        #region 窗体对象

        private ACTUAL_COSTS currentObject;
        public ACTUAL_COSTS CurrentObject
        {
            get { return currentObject; }
            set
            {
                currentObject = value;
                setRight(currentObject);
                showObject(currentObject);
                
            }
        }
        bool COST_VIEW_RIGHT = false;
        private DateTime yearMonth;
        bool isFirstLoadMain = true;
        //Dictionary<string, string> dictColumns = new Dictionary<string, string>();
        decimal rate = 0;
        /// <summary>
        /// 错误信息
        /// </summary>
        String errMessage = String.Empty;
        #endregion

        #region 其它公共业务类
        private CommonOperation.Functions.ProxyRight proxyRight = CommonOperation.Functions.ProxyRight.Instance;//权限代理业务类.
        private FormControlOption other = FormControlOption.Instance;
        Dictionary<string, string> discRate = new Dictionary<string, string>();

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmShipOwnerCost()
        {
            InitializeComponent();
        }

        #region FrmLoad事件
        /// <summary>
        /// 主窗体加载.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPortInfo_Load(object sender, EventArgs e)
        {
            ucManufacturerSelect1.ChangeMode(true, true, false);
            ucShipSelect1.ChangeSelectedState(true, true);

            setComboBox();                 //设置窗体所需的下拉列表框的数据源.

            this.ucShipSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(this.ucShipSelect1_TheSelectedChanged);
            this.dateYear.ValueChanged += new System.EventHandler(this.dateYear_ValueChanged);

            loadMainData();

            COST_VIEW_RIGHT = proxyRight.CheckRight(CommonOperation.ConstParameter.COST_VIEW, out errMessage)
              && !proxyRight.CheckRight(CommonOperation.ConstParameter.COST_OPERATION, out errMessage);
            if (COST_VIEW_RIGHT)
            {
                AddButton.Enabled = false;
                deleteButton.Enabled = false;
                SaveButton.Enabled = false;
                btnClone.Enabled = false;
                btnNullify.Enabled = false;
            }
        }
        #endregion

        #region 设置岸端界面功能按钮
        /// <summary>
        /// 设置岸端界面功能按钮.
        /// </summary>
        private void setRight(ACTUAL_COSTS cuObject)
        {
            //设置船岸端按钮权限.

            if (CommonOperation.ConstParameter.IsLandVersion && !COST_VIEW_RIGHT)
            {
                //业务权限. 未作凭证 作废 可删除 可保存 可作废
                if (cuObject != null && (cuObject.SENDED == 1 || cuObject.SENDED == 9))
                {
                    deleteButton.Visible = true; 
                    SaveButton.Enabled = true;
                    btnNullify.Enabled = true;
                }
                else if (cuObject != null && (cuObject.SENDED == 7))//打回 不可删 不可作废 可保存
                {
                    deleteButton.Visible = false; 
                    SaveButton.Enabled = true;
                    btnNullify.Enabled = false;
                }
                else
                {
                    deleteButton.Visible = false; 
                    SaveButton.Enabled = false;
                    btnNullify.Enabled = false;
                }

            }

        }
        #endregion

        #region 设置下拉列表
        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {
            string err = "";
            //船东费用根节点名称 shipOwnerFeeName=船东费用
            string shipOwnerFeeName = CommonOperation.ConstParameter.ArgumentSetCollection["ShipOwnerFeeName"];
            Account shipOwnerFee = AccountService.Instance.GetObjectByName(shipOwnerFeeName);
            string shipOwnerFeeID = "";
            if (shipOwnerFee != null && !shipOwnerFee.IsWrong)
                shipOwnerFeeID = shipOwnerFee.GetId();
            //科目.
            DataTable dtb2 = AccountService.Instance.GetTreeSubjects(shipOwnerFeeID);
            other.SetComboBoxValue(combEditAcount, dtb2);

            DataTable dtb3 = dtb2.Copy();
            DataRow dr = dtb3.NewRow();
            dr[0] = "";
            dr[1] = "全部";
            dtb3.Rows.InsertAt(dr, 0);
            other.SetComboBoxValue(cboAccount, dtb3);

            
            //币种.
            combCurrency.SelectedIndexChanged -= numeAmount_ValueChanged;
            DataTable dtb4 = CurrencyService.Instance.getInfo(out err);
            other.SetComboBoxValue(combCurrency, dtb4);
            combCurrency.SelectedIndexChanged += numeAmount_ValueChanged;

            DataTable dtb = new DataTable();
            dtb.Columns.Add("ID", typeof(string));
            dtb.Columns.Add("NAME", typeof(string));
            dtb.Rows.Add("", "全部");
            dtb.Rows.Add("1", "未做凭证");
            dtb.Rows.Add("2", "已做凭证");
            dtb.Rows.Add("3", "机务经理审批");
            dtb.Rows.Add("4", "总裁审批");
            dtb.Rows.Add("5", "财务经理审批");
            dtb.Rows.Add("6", "已付款");
            dtb.Rows.Add("7", "打回");
            dtb.Rows.Add("8", "打回后提交");
            dtb.Rows.Add("9", "作废");
            cbxState.DisplayMember = "NAME";
            cbxState.ValueMember = "ID";
            cbxState.DataSource = dtb;
            cbxState.SelectedValue = "1";

            DataTable dtb6 = BaseInfo.DataAccess.ManufacturerService.Instance.getInfo(true,out err);
            DataRow dr2 = dtb6.NewRow();
            dr2["MANUFACTURER_ID"] = "";
            dr2["MANUFACTURER_NAME"] = "全部";
            dtb6.Rows.InsertAt(dr2, 0);
            cboManufacturer.DisplayMember = "MANUFACTURER_NAME";
            cboManufacturer.ValueMember = "MANUFACTURER_ID";
            cboManufacturer.DataSource = dtb6;

            //this.cob2.SelectedIndexChanged += new System.EventHandler(this.cob2_SelectedIndexChanged);
            this.cboManufacturer.SelectedIndexChanged += new System.EventHandler(this.cboManufacturer_SelectedIndexChanged);
            this.cboAccount.SelectedIndexChanged += new System.EventHandler(this.cboAccount_SelectedIndexChanged);
            this.cbxState.SelectedIndexChanged += new System.EventHandler(this.cbxState_SelectedIndexChanged);

        }
        #endregion

        #region 加载主数据
        /// <summary>
        /// 加载主数据. 查询条件 船舶、科目、状态、供应商、年份
        /// </summary>
        public void loadMainData()
        {
            string err = "";
            string state = "";
            string manufacturer = "";
            string account = "";
            if (cboAccount.SelectedValue != null) 
                account = cboAccount.SelectedValue.ToString();
            if (cbxState.SelectedValue != null)
                state = cbxState.SelectedValue.ToString();
            if (cboManufacturer.SelectedValue != null)
                manufacturer = cboManufacturer.Text == "全部" ? "" : cboManufacturer.Text;
            yearMonth = new DateTime(dateYear.Value.Year, 1, 1);

            String userId = CommonOperation.ConstParameter.UserId;
            DataTable dtb = ACTUAL_COSTSService.Instance.getShipOwnerInfoByYear(userId, ucShipSelect1.GetId(),
                yearMonth, state, account, manufacturer, out err);
            dgvMain.DataSource = dtb;

            //加载主列项.

            if (isFirstLoadMain)
            {
                loadDataCol();
            }

            if (dtb.Rows.Count == 0)
            {
                CurrentObject = null;// 没有对象则显示置空.
            }
        }
        #endregion

        #region 设置表格头部列显示
        /// <summary>
        /// 设置主列项.
        /// </summary>
        private void loadDataCol()
        {
            Dictionary<string, string> dictColumns = new Dictionary<string, string>();
            dictColumns.Clear();

            //设置列标题.
            dictColumns.Add("SENDED", "审核状态");
            dictColumns.Add("ship_name", "船舶");
            dictColumns.Add("OCCURENCY_DATE", "费用发生日期");
            dictColumns.Add("PAYMENT_DATE", "付款日期");
            dictColumns.Add("CUSTOMER", "供应商");
            //   dictColumns.Add("DESCRIPTION", "项目说明");
            dictColumns.Add("CURRENCYNAME", "币种");
            dictColumns.Add("AMOUNT", "金额");
            dictColumns.Add("CONVERT_MONEY", "折算美金");
            dictColumns.Add("NODE_NAME", "科目名称");
            dictColumns.Add("COMPLETE_DATE", "费用完成日期");
            dictColumns.Add("COMPLETE_PALCE", "完成地点");
            dictColumns.Add("INVOICE_NUM", "发票号");

            dgvMain.SetDgvGridColumns(dictColumns);
            //    dgvMain.LoadGridView("FrmShipOwnerCost.dgvMain");

            isFirstLoadMain = false;
        }
        #endregion

        #region 筛选条件选择事件
        private void dateYear_ValueChanged(object sender, EventArgs e)
        {
            loadMainData();
        }

        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            loadMainData();
        }

        private void cbxState_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadMainData();
        }

        private void cboAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadMainData();
        }

        private void cboManufacturer_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadMainData();
        }
        #endregion

        #region 表格RowEnter事件
        private void dgvMain_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            numeAmount.ValueChanged -= numeAmount_ValueChanged;
            if (e.RowIndex >= 0)//(dgvMain.CurrentRow != null)
            {
                string err = "";
                DataGridViewRow dr = dgvMain.Rows[e.RowIndex];

                string objectID = "";
                if (DBNull.Value != dr.Cells["COSTS_ID"].Value && null != dr.Cells["COSTS_ID"].Value)
                    objectID = dr.Cells["COSTS_ID"].Value.ToString();
                CurrentObject = ACTUAL_COSTSService.Instance.getObject(objectID, out err);

                //绑定附件，设置附件编辑的权限-liulei/2016/01/11
                FileOperationBase.Services.right right = FileOperationBase.Services.right.C;
                if (CurrentObject.SENDED == 6)//已付款的附件只读
                {
                    right = FileOperationBase.Services.right.R;//只读权限

                }
                
                FileOperation.FileBoundingOperation.Instance.FileBoundCheck(objectID, objectID,
                    CommonOperation.Enum.FileBoundingTypes.VOUCHERFILES, CurrentObject.SHIP_ID, right);
            }
            numeAmount.ValueChanged += numeAmount_ValueChanged;
        }
        #endregion

        #region 显示详细信息
        private void showObject(ACTUAL_COSTS tempObject)
        {
            
            if (tempObject != null)
            {

                txtComm.Text = tempObject.REMARK;
                dtpCompleteDate.Value = tempObject.COMPLETE_DATE;
                txtPlace.Text = tempObject.COMPLETE_PALCE;
                txtContract.Text = tempObject.CONTRACT_NUM;
                ucManufacturerSelect1.SelectedText(tempObject.CUSTOMER);
                combEditAcount.Text = tempObject.DESCRIPTION;
                numPre.Value = tempObject.ESTIMATE_AMOUNT;
                dtpInvoiceDate.Value = tempObject.INVOICE_DATE;
                txtInvoiceNum.Text = tempObject.INVOICE_NUM;
                txtCommiter.Text = tempObject.APPLICANT;
                dtpOccurency.Value = tempObject.OCCURENCY_DATE;
                dtpPaymentDate.Value = tempObject.PAYMENT_DATE;
                combEditAcount.SelectedValue = tempObject.NODE_ID;
                combCurrency.SelectedValue = tempObject.CURRENCY_ID;

                //变更当前汇率
                //ChangeRate();

                numMoney.Value = tempObject.CONVERT_MONEY;
                ucShipSelect2.SelectedId(tempObject.SHIP_ID);
                setCanEdit((CurrentObject.SENDED == 1) || (CurrentObject.SENDED == 7));
                numeAmount.Value = tempObject.AMOUNT;
            }
            else
            {
                ucManufacturerSelect1.Text = "全部";
                
                numeAmount.Value = 0;
                txtComm.Text = "";
                dtpCompleteDate.Value = DateTime.Now;
                txtPlace.Text = "";
                txtContract.Text = "";
                numMoney.Value = 0;
                numPre.Value = 0;
                dtpInvoiceDate.Value = DateTime.Now;
                txtInvoiceNum.Text = "";
                txtCommiter.Text = "";
                dtpOccurency.Value = DateTime.Now;
                dtpPaymentDate.Value = DateTime.Now;
                ucShipSelect2.SelectedId("");
                combEditAcount.Text = null;
                setCanEdit(false);
            }
            
        }
        #endregion

        #region 设置详细信息是否可编辑
        private void setCanEdit(bool canEdit)
        {
            numeAmount.Enabled = canEdit;

            txtComm.Enabled = canEdit;
            dtpCompleteDate.Enabled = canEdit;
            txtPlace.ReadOnly = !canEdit;
            txtContract.ReadOnly = !canEdit;
            numMoney.Enabled = canEdit;
            ucManufacturerSelect1.Enabled = canEdit;
            combEditAcount.Enabled = canEdit;
            numPre.Enabled = canEdit;
            dtpInvoiceDate.Enabled = canEdit;
            txtInvoiceNum.ReadOnly = !canEdit;
            dtpOccurency.Enabled = canEdit;
            dtpPaymentDate.Enabled = canEdit;
            combEditAcount.Enabled = canEdit;
            combCurrency.Enabled = canEdit;
            ucShipSelect2.Enabled = canEdit;

        }
        #endregion

        #region 添加事件
        /// <summary>
        /// 添加操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            DateTime date = new DateTime();
            ACTUAL_COSTS tempObject = new ACTUAL_COSTS(null, "", "", 0, 0, "", 0, "", "", "", date, date, "", ucShipSelect1.GetId(), "", "", "", "", date, date, "", 1);

            FrmEditOneShipOwner formNew = new FrmEditOneShipOwner(tempObject, ucShipSelect1.GetId());
            formNew.ShowDialog();

            //刷新列表.
            loadMainData();
        }
        #endregion

        #region 删除事件
        /// <summary>
        /// 删除操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            if (currentObject == null)
            {
                MessageBoxEx.Show("请先选择一条记录!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            DialogResult response = MessageBoxEx.Show("您确定要删除该条数据吗？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (response == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            if (currentObject.Delete(out errMessage) )
            {
                MessageBoxEx.Show("删除成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadMainData();
            }
            else
            {
                MessageBoxEx.Show("当前对象删除失败,错误原因是:\n\n" + errMessage, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
            
        }
        #endregion

        #region 作废事件
        /// <summary>
        /// 作废操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNullify_Click(object sender, EventArgs e)
        {
            if (currentObject == null)
            {
                MessageBoxEx.Show("请先选择一条记录!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }            
            currentObject.SENDED = 9;
            ACTUAL_COSTSService.Instance.saveUnit(currentObject, out errMessage);
            loadMainData();  
        }
        #endregion

        #region 页面验证
        private bool check()
        {
            if ("".Equals(combCurrency.Text))
            {
                MessageBoxEx.Show("币种不能为空!", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                combCurrency.Focus();
                return false;
            }
            if ("".Equals(combEditAcount.Text))
            {
                MessageBoxEx.Show("科目不能为空!", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                combEditAcount.Focus();
                return false;
            }
            //if (string.IsNullOrEmpty(this.txtComm.Text.Trim()))
            //{
            //    MessageBoxEx.Show("费用说明不能为空", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}

            return true;
        }
        #endregion

        #region 对象封装
        public void FormToObject()
        {
            if (currentObject != null)
            {
                //对象赋值.

                currentObject.AMOUNT = numeAmount.Value;

                currentObject.REMARK = txtComm.Text;
                currentObject.COMPLETE_DATE = dtpCompleteDate.Value;
                currentObject.COMPLETE_PALCE = txtPlace.Text;
                currentObject.CONTRACT_NUM = txtContract.Text;
                currentObject.CONVERT_MONEY = numMoney.Value;
                currentObject.CUSTOMER = ucManufacturerSelect1.GetText();
                if (combEditAcount.Text.Contains("—"))
                {
                    currentObject.DESCRIPTION = combEditAcount.Text;
                }
                else
                {
                    currentObject.DESCRIPTION = combEditAcount.Text + "—" + combEditAcount.Text; ;
                }
                currentObject.ESTIMATE_AMOUNT = numPre.Value;
                currentObject.INVOICE_DATE = dtpInvoiceDate.Value;
                currentObject.INVOICE_NUM = txtInvoiceNum.Text;
                currentObject.OCCURENCY_DATE = dtpOccurency.Value;
                currentObject.PAYMENT_DATE = dtpPaymentDate.Value;
                currentObject.NODE_ID = combEditAcount.SelectedValue.ToString();
                currentObject.CURRENCY_ID = combCurrency.SelectedValue.ToString();
                currentObject.SHIP_ID = ucShipSelect2.GetId();
                currentObject.APPLICANT = CommonOperation.ConstParameter.UserName;
                if (currentObject.SENDED == 7) currentObject.SENDED = 8;

            }
        }
        #endregion

        #region 保存费用项目
        private bool saveObject()
        {
            if (currentObject != null)
            {
                if (!check())
                {
                    return false;
                }

                this.FormToObject();      //从界面获取数据到对象中.

                //保存对象.
                bool returnValue = false;
                using (TransactionClass tc = new TransactionClass())
                {
                    string VoucherNum = ACTUAL_COSTSService.Instance.GetVoucherNumByCOSTS_ID(currentObject.COSTS_ID);
                    if (!string.IsNullOrEmpty(VoucherNum))
                    {
                        T_WorkFlowService.Instance.AgreeBusiness(currentObject.SHIP_ID, VoucherNum, "凭证审核流程", false, out errMessage, "打回费用已修改（" + currentObject.DESCRIPTION + ")");
                    }
                    returnValue = ACTUAL_COSTSService.Instance.saveUnit(currentObject, out errMessage);

                    tc.CommitTransaction();
                }

                return returnValue;

            }
            return false;
        }
        #endregion

        #region 保存事件
        /// <summary>
        /// 保存操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (saveObject())
            {
                MessageBoxEx.Show("保存成功!", "提示", new MessageBoxButtons(), MessageBoxIcon.Information);
                //刷新列表.
                loadMainData();
            }
            else
            {
                MessageBoxEx.Show("当前对象保存失败", "错误", new MessageBoxButtons(), MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 实际费用改变事件
        private void numeAmount_ValueChanged(object sender, EventArgs e)
        {
            // numeAmount-实际金额 numMoney-折算美金
            if (combCurrency.SelectedValue == null || combCurrency.SelectedValue.ToString() == "System.Data.DataRowView") return;
            if (combCurrency.SelectedItem != null && ((DataRowView)combCurrency.SelectedItem)[1].ToString() == "美元")
            {
                numMoney.Value = numeAmount.Value;

            }
            else
            {
                if (numMoney.Enabled)
                {//仅可编辑时

                    ChangeRate();//变更当前汇率
                    decimal baseAmount = numeAmount.Value;
                    numMoney.Value = rate * baseAmount;
                }
                else
                {
                    numMoney.Value = null==CurrentObject? 0.00m: CurrentObject.CONVERT_MONEY;
                }
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

        private void cob2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeRate();
        }

        #region 查询对美元汇率
        /// <summary>
        /// 改变当前费用的汇率
        /// </summary>
        private void ChangeRate()
        {

            if (combCurrency.SelectedValue == null || combCurrency.SelectedValue.ToString() == "System.Data.DataRowView") return;
            if (combCurrency.SelectedItem != null && ((DataRowView)combCurrency.SelectedItem)[1].ToString() == "美元")
            {
                rate = 1;
                return;
            }
            //liulei-修改-2016/01/07-按费用发生日期查询该日期对应的币种对美元汇率
            
            string currencyID = combCurrency.SelectedValue == null ? "" : combCurrency.SelectedValue.ToString();
            DataTable dt = CurrencyRateService.Instance.GetRateByTime(currencyID, "USD", dtpOccurency.Value, out errMessage);
            if (dt != null && dt.Rows.Count > 0)
            {
                rate = decimal.Parse(dt.Rows[0]["EXCHANGERATE"].ToString());
            }
            else
            {
                rate = 0;
                MessageBoxEx.Show("此币种 -> 美元在" + dtpOccurency.Value.ToShortDateString() + "的有效汇率不存在,无法自动计算,请先进行设置(基础数据-货币汇率)!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
        }
        #endregion

        #region 克隆数据
        private void btnClone_Click(object sender, EventArgs e)
        {
            if (currentObject != null)
            {
                ACTUAL_COSTS tempObj = (ACTUAL_COSTS)currentObject.Clone();
                tempObj.COSTS_ID = null;
                tempObj.SENDED = 1;
                tempObj.VOUCHER_ID = null;
                tempObj.APPLICANT = null;
                tempObj.APPROVER = null;
                tempObj.APPROVER2 = null;
                tempObj.REMARK += "\r克隆数据。";
                tempObj.Update(out errMessage);
                MessageBoxEx.Show("克隆成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadMainData();

            }
            else
            {
                MessageBoxEx.Show("请先选择一条记录!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region 查看审核历史
        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (currentObject == null)
            {
                MessageBoxEx.Show("请先选择一条记录!", "", new MessageBoxButtons(), MessageBoxIcon.Warning);
                return;
            }
            string voucherNum = ACTUAL_COSTSService.Instance.GetVoucherNumByCOSTS_ID(currentObject.COSTS_ID);
            if (string.IsNullOrEmpty(voucherNum))
            {
                MessageBoxEx.Show("该费用项目还没有关联预算管理", "", new MessageBoxButtons(), MessageBoxIcon.Warning);
                return;
            }
            CheckObj checkObj = ACTUAL_COSTSService.Instance.GetActualCostCheckObjByVoucherNum(voucherNum);
            FrmCheck frm = new FrmCheck(checkObj, 3);
            frm.ShowDialog();
        }
        #endregion

        #region 绑定附件
        private void btnBdFiles_Click(object sender, EventArgs e)
        {
            if (currentObject == null)
            {
                MessageBoxEx.Show("请先选择一条记录!", "警告", new MessageBoxButtons(), MessageBoxIcon.Warning);
                return;
            }
            FileOperation.FileBoundingOperation.Instance.FileBoundOperation();
        }
        #endregion

        #region 主窗体关闭
        /// <summary>
        /// 主窗体关闭.
        /// </summary>
        private void FrmWorkinfoTempletClass_FormClosed(object sender, FormClosedEventArgs e)
        {
            //  dgvMain.SaveGridView("FrmShipOwnerCost.dgvMain");
            instance = null;
        }
        #endregion

        #region 关闭窗体事件
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


    }
}