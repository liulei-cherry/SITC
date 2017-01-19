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
using CommonOperation;
using BaseInfo.DataAccess;
using BaseInfo.Objects;
using System.Runtime.InteropServices;
using Cost.DataObject;
using Cost.Services;
using Cost.Viewer;
using CommonViewer.BaseControl;
using CommonOperation.Functions;

namespace Cost.Viewer
{

    public partial class FrmEditOneVoucher : CommonViewer.BaseForm.FormBase
    {
        #region 窗体对象
        private IDBOperation commonOpt = CommonOperation.Functions.InterfaceInstantiation.NewADBOperation();

        private VOUCHER currentObject;
        public VOUCHER CurrentObject
        {
            get { return currentObject; }
            set
            {
                currentObject = value;
                showObject(currentObject);
                setComboBox(currentObject);
            }
        }

        private ACTUAL_COSTS currentCost;
        public ACTUAL_COSTS CurrentCost
        {
            get { return currentCost; }
            set
            {
                currentCost = value;
                showObjectCost();
            }
        }

        #endregion

        #region 其它公共业务类

        private FormControlOption other = FormControlOption.Instance;
        Dictionary<string, string> discRate = new Dictionary<string, string>();
        decimal rate = 0;

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmEditOneVoucher()
        {
            InitializeComponent();
            ucShipSelect1.Visible = true;
            ucShipSelect1.ChangeSelectedState(true, true);      
            this.ucShipSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(this.ucShipSelect1_TheSelectedChanged);
            this.cob2.SelectedIndexChanged += new System.EventHandler(this.cob2_SelectedIndexChanged);
        }
        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmEditOneVoucher(VOUCHER currentObjectIn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(currentObjectIn.GetId()))
            {
                lbShip.Visible = true;
                ucShipSelect1.Visible = true;
                ucShipSelect1.ChangeSelectedState(true, true);
                this.ucShipSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(this.ucShipSelect1_TheSelectedChanged);
            }
            else
            {
                lbShip.Visible = false;
                ucShipSelect1.Visible = false;
            }
            //科目.
            DataTable dtb2 = AccountService.Instance.GetTreeSubjects();
            other.SetComboBoxValue(cob1, dtb2);
            string err;
            //币种.
            DataTable dtb3 = CurrencyService.Instance.getInfo(out err);
            other.SetComboBoxValue(cob2, dtb3);

            CurrentObject = currentObjectIn;
            
            //添加币种改变事件
            this.cob2.SelectedIndexChanged += new System.EventHandler(this.cob2_SelectedIndexChanged);
        }

        /// <summary>
        /// 主窗体加载.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmEditOneVoucher_Load(object sender, EventArgs e)
        {
            string err;
            //DateTime tempDate = date1.Value;
            //discRate = CurrencyRateService.Instance.getRateByUSD("USD", tempDate, out err);

            #region 绑定业务详细列表
            if (!string.IsNullOrEmpty(currentObject.BUSINESS_CODE))
            {
                txtVNum.ReadOnly = true;
                DataTable dtDetail;
                if (!Cost.CostConfig.getPurchaseMessageByBusinessCode(currentObject.BUSINESS_CODE, out dtDetail, out err))
                {
                    MessageBoxEx.Show(err);
                    return;
                }
                if (dtDetail.Rows.Count > 0)
                {
                    dgvDetail.DataSource = dtDetail;
                    SetDetailDataCol();
                }
            }
            #endregion
        }
        /// <summary>
        /// 设置详细列表列项.
        /// </summary>
        private void SetDetailDataCol()
        {
            Dictionary<string, string> dictColumns = new Dictionary<string, string>();
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
            dgvDetail.LoadGridView("FrmEditOneVoucher.dgvDetail");
            foreach (DataGridViewColumn item in dgvDetail.Columns)
            {
                item.ReadOnly = true;
                item.DefaultCellStyle.BackColor = Color.Linen;
            }
            dgvDetail.Columns["REBATE"].ReadOnly = false;
            dgvDetail.Columns["REBATE"].DefaultCellStyle.BackColor = Color.White;
            dgvDetail.Columns["AMOUNT"].ReadOnly = false;
            dgvDetail.Columns["AMOUNT"].DefaultCellStyle.BackColor = Color.White;
        }

        #region 设置下拉列表-未做凭证的费用项目
        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox(VOUCHER objectIn)
        {
            string err = "";
            //未做凭证的费用项目.
            if (string.IsNullOrEmpty(objectIn.VOUCHER_ID))
            {
                DataTable dtb = ACTUAL_COSTSService.Instance.getInfoNoVoucher(ucShipSelect1.GetId(), out err);
                other.SetComboBoxValue(cboCost, dtb);
            }
            else
            {
                label4.Visible = false;
                cboCost.Visible = false;
            }
        }
        #endregion

        /// <summary>
        /// 显示对象.
        /// </summary>
        private void showObject(VOUCHER tempObject)
        {
            txtVNum.Text = tempObject.VOUCHER_NUM;
            txtApplyCompany.Text = tempObject.APPLY_COMPANY;
            date1.Value = tempObject.VOUCHER_DATE;
            txtShipOwner.Text = tempObject.SHIP_OWNER;
            ucManufacturerSelect1.Text = tempObject.PAYEE;
            numInvoiceNum.Value = tempObject.INVOICE_NUM;

            //显示明细.
            if (!string.IsNullOrEmpty(tempObject.VOUCHER_ID))
            {
                showObjectCost();
            }
        }

        /// <summary>
        /// 显示对象(费用)
        /// </summary>
        private void showObjectCost()
        {
            //显示明细.
            string err = "";
            DataTable dtb;
            if (string.IsNullOrEmpty(CurrentObject.VOUCHER_ID))
            {
                dtb = ACTUAL_COSTSService.Instance.getInfoByID(string.IsNullOrEmpty(CurrentCost.COSTS_ID) ? "" : CurrentCost.COSTS_ID, out err);
            }
            else
            {
                dtb = ACTUAL_COSTSService.Instance.getInfoYesVoucher(CurrentObject.VOUCHER_ID, out err);
            }

            if (dtb != null && dtb.Rows.Count > 0)
            {
                if (currentCost != null)
                {
                    string voucherNum = "";
                    VOUCHERService.Instance.GetMaxVoucherNum(currentCost.SHIP_ID, out voucherNum, out err);
                    txtVNum.Text = voucherNum;
                }

                //凭证信息的显示.
                currentCost = ACTUAL_COSTSService.Instance.getObject(dtb.Rows[0]["COSTS_ID"].ToString(), out err);
                txtShipOwner.Text = dtb.Rows[0]["SHIP_NAME"].ToString();
                ucManufacturerSelect1.Text = dtb.Rows[0]["CUSTOMER"].ToString();

                //费用明细的显示.

                txtDescription.Text = dtb.Rows[0]["DESCRIPTION"].ToString();
                txtCommiter.Text = dtb.Rows[0]["APPLICANT"].ToString();
                cob2.Text = dtb.Rows[0]["CURRENCYNAME"].ToString();
                cob1.SelectedValue = dtb.Rows[0]["NODE_ID"].ToString();
                nudAmount.Value = Convert.ToDecimal(dtb.Rows[0]["AMOUNT"] == null ? 0 : dtb.Rows[0]["AMOUNT"]);//实际费用
                txtRemark.Text = dtb.Rows[0]["REMARK"].ToString();
            }

        }

        /// <summary>
        /// 保存操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (SaveCurrentObject())
            {
                MessageBoxEx.Show("保存成功!", "", new MessageBoxButtons(), MessageBoxIcon.Information);
                this.Close();
            }
        }

        private bool SaveCurrentObject()
        {
            string err;
            if (string.IsNullOrEmpty(currentObject.VOUCHER_ID))
            {
                if (string.IsNullOrEmpty(cboCost.Text))
                {
                    MessageBoxEx.Show("没有费用项目可做凭证!", "提示", new MessageBoxButtons(), MessageBoxIcon.Information);
                    return false;
                }
            }
            if (!txtVNum.ReadOnly)
            {
                DataTable dt = VOUCHERService.Instance.CheckNotSameHaveBusinessCodeByVoucherNum(txtVNum.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    MessageBoxEx.Show("该凭证号与业务绑定,不能与其相同");
                    return false;
                }
                DataTable dt2 = VOUCHERService.Instance.CheckNotSameSubmittedByVoucherNum(txtVNum.Text.Trim());
                if (dt2.Rows.Count > 0)
                {
                    MessageBoxEx.Show("该凭证号不能与已经提交的凭证号相同");
                    return false;
                }
                foreach (DataRow item in dt2.Rows)
                {
                    if (Convert.ToDateTime(item["VOUCHER_DATE"]).ToShortDateString() != date1.Value.ToShortDateString())
                    {
                        if (DialogResult.No == MessageBoxEx.Show("与该凭证号相同的凭证将同步修改凭证日期,确定吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                            return false;
                        else
                            break;
                    }
                }
            }
            //对象赋值.
            if (currentCost == null)
            {
                MessageBoxEx.Show("未能找到当前凭证的费用相关信息,无法完成保存,请联系管理员寻求帮助.");
                return false;
            }
            if (currentCost.PAYMENT_DATE.ToShortDateString() != date1.Value.ToShortDateString())
                if (DialogResult.No == MessageBoxEx.Show("修改费用项目付款日期为凭证日期,确定吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    return false;
            currentObject.VOUCHER_NUM = txtVNum.Text;
            currentObject.APPLY_COMPANY = txtApplyCompany.Text;
            currentObject.VOUCHER_DATE = date1.Value;
            currentObject.SHIP_OWNER = txtShipOwner.Text;
            currentObject.PAYEE = ucManufacturerSelect1.Text;
            currentObject.INVOICE_NUM = int.Parse(Decimal.Round(numInvoiceNum.Value, 0).ToString());
            currentObject.APPLICANT = CommonOperation.ConstParameter.UserName;
            currentObject.CURRENCY_ID = cob2.SelectedValue.ToString();
            List<string> sqlList = new List<string>();

            sqlList.Add(currentObject.Update());

            CurrentCost.VOUCHER_ID = CurrentObject.VOUCHER_ID;
            currentCost.NODE_ID = cob1.SelectedValue.ToString();
            currentCost.CURRENCY_ID = cob2.SelectedValue.ToString();
            currentCost.PAYMENT_DATE = date1.Value;
            currentCost.AMOUNT = nudAmount.Value;//费用金额
            currentCost.REMARK = txtRemark.Text.Trim();
            currentCost.SENDED = 2;
            currentCost.DESCRIPTION = txtDescription.Text.Trim();
            currentCost.CUSTOMER = ucManufacturerSelect1.Text;
            //2014.12.22 xiaxilong 修改
            currentCost.CONVERT_MONEY = ToUSAAmount();//修改折算美元的方法。按时间段内的汇率算，汇率是变化的

            sqlList.Add(CurrentCost.Update());

            sqlList.AddRange(VOUCHERService.Instance.UpdateDate(currentObject.VOUCHER_NUM, date1.Value));
            if (!InterfaceInstantiation.NewADbAccess().ExecSql(sqlList, out err))
            {
                MessageBoxEx.Show("保存失败,错误原因是:" + err, "错误", new MessageBoxButtons(), MessageBoxIcon.Error);
                return false;
            }
            if (dgvDetail.DataSource != null)
            {
                DataTable dtb = (DataTable)dgvDetail.DataSource;
                if (!commonOpt.SaveFormData(dtb, "T_PURCHASE_MESSAGE", 0, out err))//保存数据.
                {
                    MessageBoxEx.Show("保存失败,错误原因是:" + err, "错误", new MessageBoxButtons(), MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        #region 转换成美元
        /// <summary>
        /// 转换成美元
        /// </summary>
        /// <returns></returns>
        private decimal ToUSAAmount()
        {
            decimal usaAmount = 0M;     //转换成的美元数量             
            
            //获取币种
            if (cob2.SelectedValue == null || cob2.SelectedValue.ToString() == "System.Data.DataRowView")
                return usaAmount;

            if (cob2.SelectedItem != null && ((DataRowView)cob2.SelectedItem)[1].ToString() == "美元")
            {
                usaAmount = nudAmount.Value;

            }
            else
            {
                ChangeRate();//获取汇率
                
                decimal baseAmount = nudAmount.Value;
                decimal toUSDAmount = 0.00M;
                toUSDAmount = rate * baseAmount;
                usaAmount = toUSDAmount;
            }
            return usaAmount;
        }
        #endregion

        private void cboCost_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboCost.SelectedValue != null)
            {
                string err = "";
                CurrentCost = ACTUAL_COSTSService.Instance.getObject(cboCost.SelectedValue.ToString(), out err);
            }
        }
        /// <summary>
        /// 主窗体关闭.
        /// </summary>
        private void FrmEditOneVoucher_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvDetail.SaveGridView("FrmEditOneVoucher.dgvDetail");
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

        private void btnBdFiles_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentObject.VOUCHER_ID))
            {
                if (DialogResult.Yes == MessageBoxEx.Show("关联文件之前要保存当前凭证,是否保存?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    if (SaveCurrentObject())
                    {
                        FileOperation.FileBoundingOperation.Instance.FileBoundCheck(currentObject.VOUCHER_ID, currentObject.VOUCHER_ID,
                          CommonOperation.Enum.FileBoundingTypes.VOUCHERFILES, CurrentCost.SHIP_ID);
                        FileOperation.FileBoundingOperation.Instance.FileBoundOperation();
                    }
                }
            }
            else
                FileOperation.FileBoundingOperation.Instance.FileBoundOperation();
        }

        private void cob1_SelectedValueChanged(object sender, EventArgs e)
        {
            txtDescription.Text = cob1.Text;
        }

        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            string err;
            DataTable dtb = ACTUAL_COSTSService.Instance.getInfoNoVoucher(ucShipSelect1.GetId(), out err);
            cboCost.DataSource = null;
            other.SetComboBoxValue(cboCost, dtb);
        }

        private void cob2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeRate();
        }

        #region 改变当前费用的汇率-按费用发生日期计算
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

            //liulei-修改
            string err = string.Empty;
            //DateTime tempDate = date1.Value;
            //discRate = CurrencyRateService.Instance.getRateByUSD("USD", tempDate, out err);

            //if (discRate.ContainsKey(currencyID))
            //{
            //    rate = decimal.Parse(discRate[currencyID]);
            //}
            //else
            //{
            //    rate = 0;
            //    MessageBoxEx.Show("此币种 -> 美元有效汇率不存在,无法自动计算,请先进行设置(基础数据-货币汇率)!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

            //按费用发生日期计算-liulei-2016/01/08
            DataTable dt = CurrencyRateService.Instance.GetRateByTime(cob2.SelectedValue.ToString(), "USD", currentCost.OCCURENCY_DATE.Date, out err);
            if ( dt != null && dt.Rows.Count>0)
            {
                rate = decimal.Parse(dt.Rows[0]["EXCHANGERATE"].ToString());
            }
            else
            {
                rate = 0;
                MessageBoxEx.Show("此币种 -> 美元在费用发生日期" + currentCost.OCCURENCY_DATE.ToShortDateString() + "的有效汇率不存在,无法自动计算,请先进行设置(基础数据-货币汇率)!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion


    }
}