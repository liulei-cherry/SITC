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

namespace Cost.Viewer
{
    /// <summary>
    /// 船舶分类信息管理窗体.
    /// </summary>
    public partial class FrmOuterSAPCost : CommonViewer.BaseForm.BaseMdiChildForm
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmOuterSAPCost instance = new FrmOuterSAPCost();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmOuterSAPCost Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmOuterSAPCost.instance = new FrmOuterSAPCost();
                }
                return FrmOuterSAPCost.instance;
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

        private DateTime yearMonth;
        bool isFirstLoadMain = true;
        Dictionary<string, string> dictColumns = new Dictionary<string, string>();
        decimal rate = 0;
        #endregion

        #region 其它公共业务类
        private CommonOperation.Functions.ProxyRight proxyRight = CommonOperation.Functions.ProxyRight.Instance;//权限代理业务类.
        private FormControlOption other = FormControlOption.Instance;
        Dictionary<string, string> discRate = new Dictionary<string, string>();

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmOuterSAPCost()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 主窗体加载.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPortInfo_Load(object sender, EventArgs e)
        {
            ucManufacturerSelect1.ChangeMode(true, true, false);
            ucShipSelect1.ChangeSelectedState(true, true);

            //获取汇率集合
            string err = "";
            //DateTime tempDate = date1.Value;
            //discRate = CurrencyRateService.Instance.getRateByUSD("USD", tempDate, out err);

            setComboBox();                 //设置窗体所需的下拉列表框的数据源.

            this.ucShipSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(this.ucShipSelect1_TheSelectedChanged);
            this.dateYear.ValueChanged += new System.EventHandler(this.dateYear_ValueChanged);

            loadMainData();

        }

        /// <summary>
        /// 设置岸端界面功能按钮.
        /// </summary>
        private void setRight(ACTUAL_COSTS cuObject)
        {
            //暂不用

        }



        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {
            
            string err = "";
            string shipOwnerFeeName = CommonOperation.ConstParameter.ArgumentSetCollection["ShipOwnerFeeName"];
            Account shipOwnerFee = AccountService.Instance.GetObjectByName(shipOwnerFeeName);
            string shipOwnerFeeID = "";
            if (shipOwnerFee != null && !shipOwnerFee.IsWrong)
                shipOwnerFeeID = shipOwnerFee.GetId();
            //科目.
            DataTable dtb2 = AccountService.Instance.GetTreeSubjects(shipOwnerFeeID);
            other.SetComboBoxValue(cob1, dtb2);

            DataTable dtb3 = dtb2.Copy();
            DataRow dr = dtb3.NewRow();
            dr[0] = "";
            dr[1] = "全部";
            dtb3.Rows.InsertAt(dr, 0);
            other.SetComboBoxValue(cboAccount, dtb3);

            //币种.
            cob2.SelectedIndexChanged -= numeAmount_ValueChanged;
            date3.ValueChanged -= numeAmount_ValueChanged;
            DataTable dtb4 = CurrencyService.Instance.getInfo(out err);
            other.SetComboBoxValue(cob2, dtb4);
            //cob2.SelectedIndexChanged += numeAmount_ValueChanged;


            DataTable dtb6 = BaseInfo.DataAccess.ManufacturerService.Instance.getInfo(true,out err);
            DataRow dr2 = dtb6.NewRow();
            dr2["MANUFACTURER_ID"] = "";
            dr2["MANUFACTURER_NAME"] = "全部";
            dtb6.Rows.InsertAt(dr2, 0);
            cboManufacturer.DisplayMember = "MANUFACTURER_NAME";
            cboManufacturer.ValueMember = "MANUFACTURER_ID";
            cboManufacturer.DataSource = dtb6;

            this.cob2.SelectedIndexChanged += new System.EventHandler(this.cob2_SelectedIndexChanged);
            this.cboManufacturer.SelectedIndexChanged += new System.EventHandler(this.cboManufacturer_SelectedIndexChanged);
            this.cboAccount.SelectedIndexChanged += new System.EventHandler(this.cboAccount_SelectedIndexChanged);


        }

        /// <summary>
        /// 加载主数据.
        /// </summary>
        public void loadMainData()
        {
            string err = "";
            string manufacturer = "";
            string account = "";
            if (cboAccount.SelectedValue != null)
                account = cboAccount.SelectedValue.ToString();
            if (cboManufacturer.SelectedValue != null)
                manufacturer = cboManufacturer.Text == "全部" ? "" : cboManufacturer.Text;
            yearMonth = new DateTime(dateYear.Value.Year, 1, 1);

            String userId = CommonOperation.ConstParameter.UserId;
            DataTable dtb = ACTUAL_COSTSService.Instance.getOuterSAPCostByYear(userId, ucShipSelect1.GetId(),
                yearMonth, account, manufacturer, out err);
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

        /// <summary>
        /// 设置主列项.
        /// </summary>
        private void loadDataCol()
        {
            dictColumns.Clear();

            //设置列标题.
            dictColumns.Add("ship_name", "船舶");
            dictColumns.Add("OCCURENCY_DATE", "费用发生日期");
            dictColumns.Add("PAYMENT_DATE", "付款日期");
            dictColumns.Add("CUSTOMER", "供应商");
            dictColumns.Add("CURRENCYNAME", "币种");
            dictColumns.Add("AMOUNT", "金额");
            dictColumns.Add("CONVERT_MONEY", "折算美金");
            dictColumns.Add("NODE_NAME", "科目名称");
            dictColumns.Add("COMPLETE_DATE", "费用完成日期");
            dictColumns.Add("COMPLETE_PALCE", "完成地点");
            dictColumns.Add("INVOICE_NUM", "发票号");

            dgvMain.SetDgvGridColumns(dictColumns);
            isFirstLoadMain = false;
        }

        private void dateYear_ValueChanged(object sender, EventArgs e)
        {
            loadMainData();
        }

        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            loadMainData();
        }

        private void dgvMain_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            numeAmount.ValueChanged -= numeAmount_ValueChanged;
            if (e.RowIndex >= 0)
            {
                string err = "";
                DataGridViewRow dr = dgvMain.Rows[e.RowIndex];

                string objectID = "";
                if (DBNull.Value != dr.Cells["COSTS_ID"].Value && null != dr.Cells["COSTS_ID"].Value)
                    objectID = dr.Cells["COSTS_ID"].Value.ToString();
                CurrentObject = ACTUAL_COSTSService.Instance.getObject(objectID, out err);

                //绑定附件，设置附件编辑的权限-liulei/2016/01/11
                FileOperationBase.Services.right right = FileOperationBase.Services.right.C;
                if (!SaveButton.Enabled)
                {
                    right = FileOperationBase.Services.right.R;//只读权限

                }
                FileOperation.FileBoundingOperation.Instance.FileBoundCheck(objectID, objectID,
                    CommonOperation.Enum.FileBoundingTypes.VOUCHERFILES, CurrentObject.SHIP_ID
                    ,right);
            }
            numeAmount.ValueChanged += numeAmount_ValueChanged;
        }

        private void showObject(ACTUAL_COSTS tempObject)
        {
            cob2.SelectedIndexChanged -= numeAmount_ValueChanged;
            date3.ValueChanged -= numeAmount_ValueChanged;
            numeAmount.ValueChanged -= numeAmount_ValueChanged;
            if (tempObject != null)
            {

                txtComm.Text = tempObject.REMARK;
                date2.Value = tempObject.COMPLETE_DATE;
                txtPlace.Text = tempObject.COMPLETE_PALCE;
                txtContract.Text = tempObject.CONTRACT_NUM;
                ucManufacturerSelect1.SelectedText(tempObject.CUSTOMER);
                cob1.Text = tempObject.DESCRIPTION;
                numPre.Value = tempObject.ESTIMATE_AMOUNT;
                date4.Value = tempObject.INVOICE_DATE;
                txtInvoice.Text = tempObject.INVOICE_NUM;
                txtCommiter.Text = tempObject.APPLICANT;
                date1.Value = tempObject.OCCURENCY_DATE;
                date3.Value = tempObject.PAYMENT_DATE;
                cob1.SelectedValue = tempObject.NODE_ID;
                cob2.SelectedValue = tempObject.CURRENCY_ID;

                //变更当前汇率
                //ChangeRate();

                numMoney.Value = tempObject.CONVERT_MONEY;
                ucShipSelect2.SelectedId(tempObject.SHIP_ID);
                numeAmount.Value = tempObject.AMOUNT;
                setCanEdit(true);
            }
            else
            {
                numeAmount.Value = 0;
                txtComm.Text = "";
                date2.Value = DateTime.Now;
                txtPlace.Text = "";
                txtContract.Text = "";
                numMoney.Value = 0;
                numPre.Value = 0;
                date4.Value = DateTime.Now;
                txtInvoice.Text = "";
                txtCommiter.Text = "";
                date1.Value = DateTime.Now;
                date3.Value = DateTime.Now;
                ucShipSelect2.SelectedId("");
                setCanEdit(false);
            }

            cob2.SelectedIndexChanged += numeAmount_ValueChanged;
            date3.ValueChanged += numeAmount_ValueChanged;
            numeAmount.ValueChanged += numeAmount_ValueChanged;
        }

        #region 设置控件是否可用
        private void setCanEdit(bool canEdit)
        {
            numeAmount.Enabled = canEdit;

            txtComm.ReadOnly = !canEdit;
            date2.Enabled = canEdit;
            txtPlace.ReadOnly = !canEdit;
            txtContract.ReadOnly = !canEdit;
            numMoney.Enabled = canEdit;
            ucManufacturerSelect1.Enabled = canEdit;
            cob1.Enabled = canEdit;
            numPre.Enabled = canEdit;
            date4.Enabled = canEdit;
            txtInvoice.ReadOnly = !canEdit;
            date1.Enabled = canEdit;
            date3.Enabled = canEdit;
            cob1.Enabled = canEdit;
            cob2.Enabled = canEdit;
            ucShipSelect2.Enabled = canEdit;
        }
        #endregion


        /// <summary>
        /// 添加操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            DateTime date = new DateTime();
            ACTUAL_COSTS tempObject = new ACTUAL_COSTS(null, "", "", 0, 0, "", 0, "", "", "", date, date, "", ucShipSelect1.GetId(), "", "", "", "", date, date, "", 99);

            FrmEditOneShipOwner formNew = new FrmEditOneShipOwner(tempObject, ucShipSelect1.GetId());
            formNew.ShowDialog();

            //刷新列表.
            loadMainData();
        }

        /// <summary>
        /// 删除操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            if (currentObject != null)
            {
                string err;
                DialogResult response = MessageBoxEx.Show("您确定要删除该条数据吗？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (response == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                if (currentObject.Delete(out err) && CurrentObject.Delete(out err))
                {
                    MessageBoxEx.Show("删除成功!", "", new MessageBoxButtons(), MessageBoxIcon.Information);
                    loadMainData();
                }
                else
                {
                    MessageBoxEx.Show("当前对象删除失败,错误原因是:\n\n" + err, "", new MessageBoxButtons(), MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBoxEx.Show("请先选择一条记录!", "", new MessageBoxButtons(), MessageBoxIcon.Warning);
            }

        }


        private bool check(out string err)
        {
            err = "";

            if ("".Equals(cob2.Text))
            {
                MessageBoxEx.Show("币种不能为空!", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if ("".Equals(cob1.Text))
            {
                MessageBoxEx.Show("科目不能为空!", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (0 == numeAmount.Value)
            {
                MessageBoxEx.Show("实际金额不能为空!", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numeAmount.Focus();
                return false;
            }
            if (0 == numMoney.Value)
            {
                MessageBoxEx.Show("折算美金不能为空!", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numMoney.Focus();
                return false;
            }
            return true;
        }

        public void FormToObject(out string err)
        {
            err = "";
            if (currentObject != null)
            {
                //对象赋值.
                currentObject.AMOUNT = numeAmount.Value;
                currentObject.REMARK = txtComm.Text;
                currentObject.COMPLETE_DATE = date2.Value;
                currentObject.COMPLETE_PALCE = txtPlace.Text;
                currentObject.CONTRACT_NUM = txtContract.Text;
                currentObject.CONVERT_MONEY = numMoney.Value;
                currentObject.CUSTOMER = ucManufacturerSelect1.GetText();
                if (cob1.Text.Contains("—"))
                {
                    currentObject.DESCRIPTION = cob1.Text;
                }
                else
                {
                    currentObject.DESCRIPTION = cob1.Text + "—" + cob1.Text; ;
                }
                currentObject.ESTIMATE_AMOUNT = numPre.Value;
                currentObject.INVOICE_DATE = date4.Value;
                currentObject.INVOICE_NUM = txtInvoice.Text;
                currentObject.OCCURENCY_DATE = date1.Value;
                currentObject.PAYMENT_DATE = date3.Value;
                currentObject.NODE_ID = cob1.SelectedValue.ToString();
                currentObject.CURRENCY_ID = cob2.SelectedValue.ToString();
                currentObject.SHIP_ID = ucShipSelect2.GetId();
                currentObject.APPLICANT = CommonOperation.ConstParameter.UserName;
                currentObject.SENDED = 99;
           
            }
        }

        private bool saveObject()
        {
            string err;

            if (currentObject != null)
            {
                if (!check(out err))
                {
                    return false;
                }

                this.FormToObject(out err);      //从界面获取数据到对象中.

                //保存对象.
                return ACTUAL_COSTSService.Instance.saveUnit(currentObject, out err);

            }
            return false;
        }

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

        #region 币种、实际金额发生改变时事件
        private void numeAmount_ValueChanged(object sender, EventArgs e)
        {
            if (cob2.SelectedValue == null || cob2.SelectedValue.ToString() == "System.Data.DataRowView") return;
            if (cob2.SelectedItem != null && ((DataRowView)cob2.SelectedItem)[1].ToString() == "美元")
            {
                numMoney.Value = numeAmount.Value;

            }
            else
            {
                //liulei-2016/01/07-修改为仅可编辑时获取汇率，计算美元值
                if (numMoney.Enabled)
                {
                    ChangeRate();
                    decimal baseAmount = numeAmount.Value;
                    decimal toUSDAmount = 0.00M;
                    toUSDAmount = rate * baseAmount;
                    numMoney.Value = toUSDAmount;
                }
                else
                {
                    numMoney.Value = null == CurrentObject? 0.00m : CurrentObject.CONVERT_MONEY;
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

        /// <summary>
        /// 改变当前费用的汇率
        /// </summary>
        private void ChangeRate()
        {
            if (cob2.SelectedValue == null || cob2.SelectedValue.ToString() == "System.Data.DataRowView") return;
            if (cob2.SelectedItem != null && ((DataRowView)cob2.SelectedItem)[1].ToString() == "美元")
            {
                rate = 1;
                return;
            }

            string currencyID = cob2.SelectedValue == null ? "" : cob2.SelectedValue.ToString();

            //if (discRate.ContainsKey(currencyID))
            //{
            //    rate = decimal.Parse(discRate[currencyID]);
            //}
            //else
            //{
            //    rate = 0;
            //    MessageBoxEx.Show("此币种 -> 美元有效汇率不存在,无法自动计算,请先进行设置(基础数据-货币汇率)!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

            //liulei-修改-2016/01/07
            string err = string.Empty;

            DataTable dt = CurrencyRateService.Instance.GetRateByTime(currencyID, "USD", date1.Value.Date, out err);
            if (dt != null && dt.Rows.Count > 0)
            {
                rate = decimal.Parse(dt.Rows[0]["EXCHANGERATE"].ToString());
            }
            else
            {
                rate = 0;
                MessageBoxEx.Show("此币种 -> 美元在" +date1.Value.ToShortDateString()+"的有效汇率不存在,无法自动计算,请先进行设置(基础数据-货币汇率)!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnBdFiles_Click(object sender, EventArgs e)
        {
            if (currentObject == null)
            {
                MessageBoxEx.Show("请先选择一条记录!", "警告", new MessageBoxButtons(), MessageBoxIcon.Warning);
                return;
            }
            FileOperation.FileBoundingOperation.Instance.FileBoundOperation();
        }

        /// <summary>
        /// 主窗体关闭.
        /// </summary>
        private void FrmWorkinfoTempletClass_FormClosed(object sender, FormClosedEventArgs e)
        {
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

        private void FrmOuterSAPCost_Shown(object sender, EventArgs e)
        {

        }

    }
}