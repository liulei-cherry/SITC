using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseInfo.DataAccess;
using CommonViewer.BaseControl;
using BaseInfo.Objects;
using CommonViewer;
using System.IO;
using Cost.Services;
using Cost.DataObject;
using CommonOperation;
using CommonOperation.Functions;
using CommonOperation.Interfaces;
using Oil.Services;
using Oil.DataObject;

namespace Oil.Viewer
{
    public partial class FrmOilVoucher : CommonViewer.BaseForm.FormBase
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmOilVoucher instance = new FrmOilVoucher();
        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmOilVoucher Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmOilVoucher.instance = new FrmOilVoucher();
                }
                return FrmOilVoucher.instance;
            }
        }

        private FrmOilVoucher()
        {
            InitializeComponent();
        }

        #endregion
        List<string> orderIDList = new List<string>();
        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmOilVoucher_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;//窗体最大化.
            txtPerson.Text = CommonOperation.ConstParameter.UserName;
            dtpDate.Value = DateTime.Now;
            ucShipSelect1.ChangeSelectedState(true, "", true);
            ucCurrencySelect1.ChangeMode(true, false, false);
            ucManufacturerSelect1.ChangeMode(true, true, false, "");
            SetAccountBindingSource();
            SetDetailBindingSource();
        }
        /// <summary>
        /// 绑定凭证科目类信息.
        /// </summary>
        private void SetAccountBindingSource()
        {
            string err;
            DataTable dt;
            if (!CostAccountPositionService.Instance.GetInfoByCondition(
                new CostAccountPositionCondition(null, null, "9"), out dt, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            bdsAccount.DataSource = dt;
            dgvAccount.DataSource = bdsAccount;

            Dictionary<string, string> dgvColumnStyle = new Dictionary<string, string>();
            dgvColumnStyle.Add("path", "科目");
            dgvColumnStyle.Add("CODE", "科目编码");
            dgvAccount.SetDgvGridColumns(dgvColumnStyle);
            foreach (DataGridViewColumn item in dgvAccount.Columns)
                item.ReadOnly = true;
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.Name = "AMOUNT";
            col.HeaderText = "金额";
            col.ValueType = typeof(decimal);
            col.ReadOnly = false;
            dgvAccount.Columns.Add(col);
            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.Name = "CONVERTDOLLARS";
            col2.HeaderText = "折算成美元";
            col2.ValueType = typeof(decimal);
            col2.ReadOnly = false;
            dgvAccount.Columns.Add(col2);
            //dgvAccount.LoadGridView("FrmOilVoucher.dgvAccount");
            for (int i = 0; i < this.dgvAccount.Columns.Count; i++)
                this.dgvAccount.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
        /// <summary>
        ///  绑定凭证详细信息.
        /// </summary>
        private void SetDetailBindingSource()
        {
            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("ORDER_DETAIL_ID", typeof(string));
            dtDetail.Columns.Add("OIL_ID", typeof(string));
            dtDetail.Columns.Add("OIL_NAME", typeof(string));
            dtDetail.Columns.Add("TRADEMARK", typeof(string));
            dtDetail.Columns.Add("NUM", typeof(decimal));
            dtDetail.Columns.Add("CURRENCYID", typeof(string));
            dtDetail.Columns.Add("CURRENCYCODE", typeof(string));
            dtDetail.Columns.Add("AMOUNT", typeof(decimal));
            dtDetail.Columns.Add("REBATE", typeof(decimal));
            dtDetail.Columns.Add("REBATEAMOUNT", typeof(decimal));
            dtDetail.Columns.Add("ACCOUNT_CODE", typeof(string));
            dtDetail.Columns.Add("ACCOUNT_NAME", typeof(string));
            dgvDetail.DataSource = bdsDetail;
            bdsDetail.DataSource = dtDetail;

            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("OIL_NAME", "滑油");
            dic.Add("TRADEMARK", "牌号");
            dic.Add("NUM", "数量");
            dic.Add("CURRENCYCODE", "币种");
            dic.Add("AMOUNT", "金额");
            dic.Add("REBATE", "折扣");
            dic.Add("REBATEAMOUNT", "折算金额");
            dic.Add("ACCOUNT_NAME", "费用科目类型");
            dgvDetail.SetDgvGridColumns(dic);
            //dgvDetail.LoadGridView("FrmOilVoucher.dgvDetail");
            foreach (DataGridViewColumn item in dgvDetail.Columns)
                item.ReadOnly = true;
            dgvDetail.Columns["REBATE"].ReadOnly = false;
            dgvDetail.Columns["REBATEAMOUNT"].ReadOnly = false;

            foreach (DataGridViewColumn item in dgvDetail.Columns)
                if (item.ReadOnly)
                    item.DefaultCellStyle.BackColor = Color.Linen;
        }
        /// <summary>
        /// 显示数据到控件上,添加明细时调用,用来赋值和锁定船舶和供应商.
        /// </summary>
        private void ShowDataToForm(string orderID)
        {
            DataTable dt = HOilOrderService.Instance.GetInfo(orderID);
            ucShipSelect1.SelectedId(dt.Rows[0]["SHIP_ID"].ToString());
            ucManufacturerSelect1.SelectedId(dt.Rows[0]["SUPPLIER_ID"].ToString());
            ucShipSelect1.Enabled = false;
            ucManufacturerSelect1.Enabled = false;
        }
        /// <summary>
        /// 得到油料所属的科目类型,如果查询不到就返回系统配置的其他油料科目.
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="ACCOUNT_CODE"></param>
        /// <param name="ACCOUNT_NAME"></param>
        private void GetAccountType(string ID, out string ACCOUNT_CODE, out string ACCOUNT_NAME)
        {
            string err = "";
            ACCOUNT_CODE = "";
            ACCOUNT_NAME = "";

            if (Oil.OilConfig.getOilCostMapping != null)
            {
                if (Oil.OilConfig.getOilCostMapping(ID, out ACCOUNT_CODE, out ACCOUNT_NAME, out err))
                {
                    if (!string.IsNullOrEmpty(ACCOUNT_CODE))
                    {
                        DataTable dt = (DataTable)bdsAccount.DataSource;
                        DataRow[] drs = dt.Select("CODE=" + ACCOUNT_CODE);
                        if (drs.Length > 0)
                            ACCOUNT_NAME = drs[0]["path"].ToString();
                        return;
                    }
                }
            }

            //其他油种.
            ACCOUNT_NAME = CommonOperation.ConstParameter.ArgumentSetCollection["OtherOilCostName"];
            ACCOUNT_CODE = CommonOperation.ConstParameter.ArgumentSetCollection["OtherOilCost"];

        }
        /// <summary>
        /// 得到币种Code
        /// </summary>
        /// <param name="currencyID"></param>
        /// <returns></returns>
        private string GetCurrencyCode(string currencyID)
        {
            string err;
            string code = "";
            Currency c = CurrencyService.Instance.getObject(currencyID, out err);
            if (c != null)
                code = c.CURRENCYCODE;
            return code;
        }
        /// <summary>
        /// 根据币种、汇率、折扣,计算详细信息的折算金额,明细币种与凭证币种不相同就乘以其他币种汇率,然后在乘以折扣.
        /// </summary>
        /// <returns></returns>
        private decimal CalculateAmount(string currencyCode, decimal rebate, decimal amount)
        {
            decimal rate = 1;
            if (ucCurrencySelect1.GetId() != currencyCode)
                rate = nudExchangeRate.Value;
            return decimal.Round(rate * rebate * amount, 2);
        }
        /// <summary>
        /// 根据币种、汇率、折扣,计算详细信息的折算金额,明细币种与凭证币种不相同就乘以其他币种汇率,然后在乘以折扣,
        /// 与"CalculateAmount"函数只是传入参数不同,并调用"CalculateAmount"函数.
        /// </summary>
        private void CalculateAmount(DataGridViewRow row)
        {
            string CURRENCYID = row.Cells["CURRENCYID"].Value.ToString();
            decimal REBATE = Convert.ToDecimal(row.Cells["REBATE"].Value);
            decimal AMOUNT = Convert.ToDecimal(row.Cells["AMOUNT"].Value);
            row.Cells["REBATEAMOUNT"].Value = CalculateAmount(CURRENCYID, REBATE, AMOUNT);
        }
        /// <summary>
        /// 添加按钮事件,打开选择明细页面,导入选择的明细,并计算折算金额,找出属于的科目类型.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            string err;
            FrmOilPurchaseOrderSelect frm = new FrmOilPurchaseOrderSelect(ucShipSelect1.GetId(),
                ucManufacturerSelect1.GetId(), orderIDList);
            frm.ShowDialog();

            if (frm.orderIDList.Count != 0)
            {
                orderIDList.AddRange(frm.orderIDList);
                ShowDataToForm(frm.orderIDList[0]);
                foreach (string item in frm.orderIDList)
                {
                    DataTable dtDetail;
                    if (!HOilOrderDetailService.Instance.GetInfo(item, out dtDetail, out err))
                    {
                        MessageBoxEx.Show(err);
                        return;
                    }
                    foreach (DataRow itemDetail in dtDetail.Rows)
                    {
                        HOil obj = HOilService.Instance.getObject(itemDetail["OIL_ID"].ToString(), out err);
                        DataTable dt = (DataTable)bdsDetail.DataSource;
                        DataRow dr = dt.NewRow();
                        dr["ORDER_DETAIL_ID"] = itemDetail["ORDER_DETAIL_ID"];
                        dr["OIL_ID"] = itemDetail["OIL_ID"];
                        dr["OIL_NAME"] = itemDetail["OIL_NAME"];
                        dr["TRADEMARK"] = itemDetail["TRADEMARK"];
                        dr["NUM"] = itemDetail["NUM"];
                        dr["CURRENCYID"] = itemDetail["CURRENCY_ID"];
                        dr["CURRENCYCODE"] = itemDetail["CURRENCYCODE"];
                        dr["AMOUNT"] = itemDetail["AMOUNT"];
                        dr["REBATE"] = 1;
                        dr["REBATEAMOUNT"] = CalculateAmount(dr["CURRENCYID"].ToString(), Convert.ToDecimal(dr["REBATE"]), Convert.ToDecimal(dr["AMOUNT"]));
                        string ACCOUNT_CODE = "";
                        string ACCOUNT_NAME = "";
                        GetAccountType(itemDetail["OIL_ID"].ToString(), out ACCOUNT_CODE, out ACCOUNT_NAME);
                        dr["ACCOUNT_CODE"] = ACCOUNT_CODE;
                        dr["ACCOUNT_NAME"] = ACCOUNT_NAME;
                        dt.Rows.Add(dr);
                    }
                }
            }
        }
        /// <summary>
        /// 计算凭证其他金额(最后一个金额),总金额-除最后一个科目的金额.
        /// </summary>
        /// <returns></returns>
        private void CalculateOtherAmount()
        {
            decimal total = 0;
            for (int i = 0; i < dgvAccount.Rows.Count - 1; i++)
            {
                DataGridViewRow itemAccount = dgvAccount.Rows[i];
                if (itemAccount.Cells["AMOUNT"].Value != null && !string.IsNullOrEmpty(itemAccount.Cells["AMOUNT"].Value.ToString()))
                    total += Convert.ToDecimal(itemAccount.Cells["AMOUNT"].Value);
            }
            dgvAccount.Rows[dgvAccount.Rows.Count - 1].Cells["AMOUNT"].Value = nudTotalAmount.Value - total;
        }
        /// <summary>
        /// 更改折扣时,重新计算明细折算金额.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (dgvDetail.Columns[e.ColumnIndex].Name == "REBATE")
                {
                    CalculateAmount(dgvDetail.Rows[e.RowIndex]);
                }
            }
        }
        /// <summary>
        /// 船舶更改时生成凭证号.
        /// </summary>
        /// <param name="theSelectedObject"></param>
        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            string err;
            string voucherNum = "";
            if (ucShipSelect1.GetId() != null && !string.IsNullOrEmpty(ucShipSelect1.GetId()))
            {
                if (!VOUCHERService.Instance.GetMaxVoucherNum(ucShipSelect1.GetId(), out voucherNum, out err))
                {
                    MessageBoxEx.Show(err);
                    return;
                }
            }
            txtVoucherNum.Text = voucherNum; //设置凭证号.

        }
        /// <summary>
        /// 更改科目金额时,计算折算成美元,计算最后一个金额,假如就一条科目,他的金额就与总金额相等,相互影响.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAccount_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (dgvAccount.Columns[e.ColumnIndex].Name == "AMOUNT")
                {
                    if (dgvAccount.Rows[e.RowIndex].Cells["AMOUNT"].Value == null || string.IsNullOrEmpty(dgvAccount.Rows[e.RowIndex].Cells["AMOUNT"].Value.ToString()))
                    {
                        dgvAccount.Rows[e.RowIndex].Cells["CONVERTDOLLARS"].Value = 0;
                        return;
                    }
                    decimal baseAmount = Convert.ToDecimal(dgvAccount.Rows[e.RowIndex].Cells["AMOUNT"].Value);
                    dgvAccount.Rows[e.RowIndex].Cells["CONVERTDOLLARS"].Value = CalculateConvertUSD(baseAmount);

                }
                if (dgvAccount.Rows.Count - 1 != e.RowIndex)
                    CalculateOtherAmount();
                //假如就一条科目,他的金额就与总金额相等,相互影响.
                if (dgvAccount.Rows.Count == 1 && dgvAccount.Rows[0].Cells["AMOUNT"].Value != null && string.IsNullOrEmpty(dgvAccount.Rows[0].Cells["AMOUNT"].Value.ToString()))
                {
                    nudTotalAmount.Value = Convert.ToDecimal(dgvAccount.Rows[0].Cells["AMOUNT"].Value);
                }
            }
        }
        /// <summary>
        /// 科目绑定完成时,因为最后一行是自动计算的,所以设置成只读.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAccount_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvAccount.Columns.Contains("AMOUNT") && dgvAccount.Columns.Contains("CONVERTDOLLARS"))
            {
                dgvAccount.Rows[dgvAccount.Rows.Count - 1].Cells["AMOUNT"].ReadOnly = true;
                dgvAccount.Rows[dgvAccount.Rows.Count - 1].Cells["CONVERTDOLLARS"].ReadOnly = true;
            }
            foreach (DataGridViewRow rowItem in dgvAccount.Rows)
                foreach (DataGridViewCell item in rowItem.Cells)
                    if (item.ReadOnly)
                        item.Style.BackColor = Color.Linen;
        }
        /// <summary>
        /// 汇率改变时,重新计算明细折算金额.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudExchangeRate_Leave(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvDetail.Rows)
                CalculateAmount(item);
        }
        /// <summary>
        /// 总金额改变时,计算最后一个金额,假如就一条科目,他的金额就与总金额相等,相互影响.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudTotalAmount_Leave(object sender, EventArgs e)
        {
            CalculateOtherAmount();
            if (dgvAccount.Rows.Count == 1)
            {
                dgvAccount.Rows[0].Cells["AMOUNT"].Value = nudTotalAmount.Value;
            }
        }
        /// <summary>
        /// 计算折算成美元.
        /// </summary>
        private decimal CalculateConvertUSD(decimal baseAmount)
        {
            string err;
            if (GetCurrencyCode(ucCurrencySelect1.GetId()).ToUpper() == "USD")
                return baseAmount;
            DateTime tempDate = dtpDate.Value;
            //Dictionary<string, string> discRate = new Dictionary<string, string>();
            //discRate = CurrencyRateService.Instance.getRateByUSD("USD", tempDate, out err);
            string currencyID = ucCurrencySelect1.GetId();
            decimal toUSDAmount = 0.00M;
            //if (discRate.ContainsKey(currencyID))
            //{
            //    toUSDAmount = decimal.Parse(discRate[currencyID]) * baseAmount;
            //}                   

            //liulei-2016/01/07-根据币种和时间查询汇率
            DataTable dt = CurrencyRateService.Instance.GetRateByTime(currencyID, "USD", tempDate, out err);
            if (dt != null && dt.Rows.Count > 0)
            {
                toUSDAmount = decimal.Parse(dt.Rows[0]["EXCHANGERATE"].ToString()) * baseAmount;
            }
            return toUSDAmount;
        }
        /// <summary>
        /// 币种改变,重新计算明细折算金额.
        /// </summary>
        private void ucCurrencySelect1_TheSelectedChanged(string theSelectedObject)
        {
            groupBox1.Text = "科目金额 (" + ucCurrencySelect1.GetText() + ")";
            foreach (DataGridViewRow item in dgvDetail.Rows)
                CalculateAmount(item);
            foreach (DataGridViewRow item in dgvAccount.Rows)
            {
                if (item.Cells["AMOUNT"].Value == null || string.IsNullOrEmpty(item.Cells["AMOUNT"].Value.ToString()))
                {
                    item.Cells["CONVERTDOLLARS"].Value = 0;
                    return;
                }
                decimal baseAmount = Convert.ToDecimal(item.Cells["AMOUNT"].Value);
                item.Cells["CONVERTDOLLARS"].Value = CalculateConvertUSD(baseAmount);
            }
        }
        /// <summary>
        /// 检查form
        /// </summary>
        /// <returns></returns>
        private bool CheckForm()
        {
            if (string.IsNullOrEmpty(txtVoucherNum.Text.Trim()))
            {
                MessageBoxEx.Show("凭证号不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtPerson.Text.Trim()))
            {
                MessageBoxEx.Show("生成人不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(ucShipSelect1.GetId()))
            {
                MessageBoxEx.Show("船舶不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(dtpDate.Value.ToString()))
            {
                MessageBoxEx.Show("日期不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(ucManufacturerSelect1.GetId()))
            {
                MessageBoxEx.Show("供应商不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(GetCurrencyCode(ucCurrencySelect1.GetId())))
            {
                MessageBoxEx.Show("币种不能为空");
                return false;
            }
            if (nudTotalAmount.Value < 0)
            {
                MessageBoxEx.Show("合计金额不能小于0");
                return false;
            }
            if (nudExchangeRate.Value < 0)
            {
                MessageBoxEx.Show("其他币种汇率不能小于0");
                return false;
            }
            foreach (DataGridViewRow item in dgvAccount.Rows)
            {
                if (item.Cells["AMOUNT"].Value == null)
                {
                    MessageBoxEx.Show("科目金额不能为空");
                    return false;
                }
                if (Convert.ToDecimal(item.Cells["AMOUNT"].Value) < 0)
                {
                    MessageBoxEx.Show("科目金额不能小于0");
                    return false;
                }
                if (item.Cells["CONVERTDOLLARS"].Value == null)
                {
                    MessageBoxEx.Show("折算成美金不能为空");
                    return false;
                }
                if (Convert.ToDecimal(item.Cells["CONVERTDOLLARS"].Value) < 0)
                {
                    MessageBoxEx.Show("折算成美金不能小于0");
                    return false;
                }
            }
            foreach (DataGridViewRow item in dgvDetail.Rows)
            {
                if (item.Cells["REBATE"].Value == null)
                {
                    MessageBoxEx.Show("折扣不能为空");
                    return false;
                }
                if (Convert.ToDecimal(item.Cells["REBATE"].Value) < 0)
                {
                    MessageBoxEx.Show("折扣不能小于0");
                    return false;
                }
                if (item.Cells["REBATEAMOUNT"].Value == null)
                {
                    MessageBoxEx.Show("折算金额不能为空");
                    return false;
                }
                if (Convert.ToDecimal(item.Cells["REBATEAMOUNT"].Value) <= 0)
                {
                    MessageBoxEx.Show("折算金额不能小于等于0");
                    return false;
                }
            }
            Dictionary<string, decimal> dic = GetAccountAmount();
            foreach (string item in dic.Keys)
            {
                decimal tempAmount = GetDetailAmountByAccount(item);
                if (dic[item] == tempAmount)
                    continue;
                if (dic[item] < tempAmount)
                {
                    MessageBoxEx.Show("科目金额小于属于该科目的凭证详细的总金额");
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 得到属于该科目的明细的汇总金额.
        /// </summary>
        /// <param name="NODE_ID"></param>
        /// <returns></returns>
        private decimal GetDetailAmountByAccount(string code)
        {
            decimal amount = 0;
            DataTable dt = (DataTable)bdsDetail.DataSource;
            foreach (DataRow item in dt.Select(" ACCOUNT_CODE ='" + code + "'"))
            {
                amount += Convert.ToDecimal(item["REBATEAMOUNT"]);
            }
            return amount;
        }
        /// <summary>
        /// 得到同类科目的项与汇总金额.
        /// </summary>
        /// <param name="NODE_ID"></param>
        /// <returns></returns>
        private Dictionary<string, decimal> GetAccountAmount()
        {
            Dictionary<string, decimal> dic = new Dictionary<string, decimal>();
            foreach (DataGridViewRow item in dgvAccount.Rows)
            {
                if (!dic.ContainsKey(item.Cells["CODE"].Value.ToString()))
                {
                    decimal amount = 0;
                    foreach (DataGridViewRow itemAccount in dgvAccount.Rows)
                    {
                        if (itemAccount.Cells["CODE"].Value.ToString() == item.Cells["CODE"].Value.ToString())
                            amount += Convert.ToDecimal(itemAccount.Cells["AMOUNT"].Value);
                    }
                    dic.Add(item.Cells["CODE"].Value.ToString(), amount);
                }
            }
            return dic;
        }
        /// <summary>
        /// 确认按钮,生成凭证,同步sap,改变订单状态为已生成凭证.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAffirm_Click(object sender, EventArgs e)
        {
            string err;
            if (!CheckForm()) return;
            List<string> sqlList = new List<string>();
            foreach (DataGridViewRow item in dgvAccount.Rows)
            {
                VOUCHER currentObject = new VOUCHER();
                currentObject.AMOUNT_LOW = nudTotalAmount.Value.ToString();
                currentObject.AMOUNT_UP = Tools.numberToChinese(nudTotalAmount.Value);
                currentObject.APPLY_COMPANY = CommonOperation.ConstParameter.ArgumentSetCollection["VoucherApplyCompany"];
                currentObject.CURRENCY_ID = ucCurrencySelect1.GetId();
                currentObject.INVOICE_NUM = Convert.ToInt32(numInvoiceNum.Value);
                currentObject.PAYEE = ucManufacturerSelect1.GetText();
                currentObject.SHIP_OWNER = ucShipSelect1.GetText();
                currentObject.VOUCHER_NUM = txtVoucherNum.Text.Trim();
                currentObject.APPLICANT = txtPerson.Text.Trim();
                currentObject.APPROVER = "";
                currentObject.APPROVER2 = "";
                currentObject.VOUCHER_DATE = dtpDate.Value;
                currentObject.CURRENT_STATE = 1;
                currentObject.BUSINESS_CODE = txtVoucherNum.Text.Trim();

                if (Convert.ToDecimal(item.Cells["AMOUNT"].Value) == 0)
                    continue;
                sqlList.Add(currentObject.Update());
                ACTUAL_COSTS nowObject = new ACTUAL_COSTS();
                nowObject.VOUCHER_ID = currentObject.VOUCHER_ID;
                nowObject.APPLICANT = txtPerson.Text.Trim();
                nowObject.APPROVER = "";
                nowObject.APPROVER2 = "";
                nowObject.REMARK = "";
                nowObject.COMPLETE_PALCE = "";
                nowObject.CONTRACT_NUM = "";
                nowObject.CUSTOMER = ucManufacturerSelect1.GetText();
                nowObject.DESCRIPTION = item.Cells["path"].Value.ToString();
                nowObject.INVOICE_NUM = "";
                nowObject.NODE_ID = item.Cells["NODE_ID"].Value.ToString();
                nowObject.CURRENCY_ID = ucCurrencySelect1.GetId();
                nowObject.VOUCHER_ID = currentObject.VOUCHER_ID;
                nowObject.SHIP_ID = ucShipSelect1.GetId();
                nowObject.AMOUNT = Convert.ToDecimal(item.Cells["AMOUNT"].Value);
                nowObject.COMPLETE_DATE = DateTime.Now;
                nowObject.CONVERT_MONEY = Convert.ToDecimal(item.Cells["CONVERTDOLLARS"].Value);
                nowObject.ESTIMATE_AMOUNT = 0;
                nowObject.INVOICE_DATE = DateTime.MinValue;
                nowObject.OCCURENCY_DATE = DateTime.Now;
                nowObject.PAYMENT_DATE = DateTime.Now;
                nowObject.SENDED = 2;
                sqlList.Add(nowObject.Update());
            }

            DataTable dtSap = new DataTable();
            dtSap.Columns.Add("UUID", typeof(string));
            dtSap.Columns.Add("MATERIAL", typeof(string));
            dtSap.Columns.Add("SUBJECT_MAPPING", typeof(string));
            dtSap.Columns.Add("QUANTITY", typeof(decimal));
            dtSap.Columns.Add("SHIP_ID", typeof(string));
            dtSap.Columns.Add("CURRENCY", typeof(string));
            dtSap.Columns.Add("AMOUNT", typeof(decimal));
            dtSap.Columns.Add("SUPPLIER", typeof(string));
            dtSap.Columns.Add("INPUT_ORDER", typeof(string));

            dtSap.Columns.Add("REBATE", typeof(decimal));
            dtSap.Columns.Add("ORDER_AMOUNT", typeof(decimal));
            dtSap.Columns.Add("ACCOUNT_CODE", typeof(string));
            dtSap.Columns.Add("ACCOUNT_NAME", typeof(string));
            dtSap.Columns.Add("BUSINESS_CODE", typeof(string));
            //Dictionary<string, decimal> dic = GetAccountAmount();
            //foreach (string item in dic.Keys)
            //{
            //    decimal tempAmount = GetDetailAmountByAccount(item);
            //    if (dic[item] == 0 || dic[item] == tempAmount)
            //        continue;
            //    if (dic[item] < tempAmount)
            //    {
            //        MessageBoxEx.Show("科目金额小于属于该科目的凭证详细的总金额");
            //        return;
            //    }
            //    //DataRow dr = dtSap.NewRow();
            //    //dr["UUID"] = currentObject.VOUCHER_ID;
            //    //dr["MATERIAL"] = "";
            //    //dr["QUANTITY"] = 1;
            //    //dr["SHIP_ID"] = ucShipSelect1.GetId();
            //    //dr["CURRENCY"] = GetCurrencyCode(ucCurrencySelect1.GetId());
            //    //dr["AMOUNT"] = dic[item] - tempAmount;
            //    //dr["SUPPLIER"] = ucManufacturerSelect1.GetId();
            //    //dr["INPUT_ORDER"] = txtVoucherNum.Text;
            //    //dr["SUBJECT_MAPPING"] = item;
            //    //dtSap.Rows.Add(dr);
            //}
            foreach (DataGridViewRow item in dgvDetail.Rows)
            {
                if (Convert.ToDecimal(item.Cells["REBATEAMOUNT"].Value) == 0)
                    continue;
                DataRow dr = dtSap.NewRow();
                dr["UUID"] = item.Cells["ORDER_DETAIL_ID"].Value;
                dr["MATERIAL"] = item.Cells["OIL_ID"].Value;
                dr["QUANTITY"] = item.Cells["NUM"].Value;
                dr["SHIP_ID"] = ucShipSelect1.GetId();
                dr["CURRENCY"] = GetCurrencyCode(ucCurrencySelect1.GetId());
                dr["AMOUNT"] = item.Cells["REBATEAMOUNT"].Value;
                dr["SUPPLIER"] = ucManufacturerSelect1.GetId();
                dr["INPUT_ORDER"] = txtVoucherNum.Text;
                dr["REBATE"] = item.Cells["REBATE"].Value;
                dr["ORDER_AMOUNT"] = item.Cells["AMOUNT"].Value;
                dr["ACCOUNT_CODE"] = item.Cells["ACCOUNT_CODE"].Value;
                dr["ACCOUNT_NAME"] = item.Cells["ACCOUNT_NAME"].Value;
                dr["BUSINESS_CODE"] = txtVoucherNum.Text;
                dtSap.Rows.Add(dr);
            }
            sqlList.AddRange(Oil.OilConfig.createPurchaseMessageSql(dtSap));
            foreach (string item in orderIDList)
            {
                HOilOrder spo = HOilOrderService.Instance.GetObject(item);
                int stateCode;
                if (spo.CHECKED == 6)
                    if (!Oil.OilConfig.reverseAccountSql(spo.GetId(), sqlList, out stateCode, out err))
                    {
                        MessageBoxEx.Show(err);
                        return;
                    }
                spo.CHECKED = 7;
                sqlList.Add(spo.UpdateSql());
            }

            IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
            if (!dbAccess.ExecSql(sqlList, out err))
            {
                MessageBoxEx.Show("生成凭证信息时发生错误,错误信息请参考:\r" + err);
                return;
            }
            MessageBoxEx.Show("操作成功");
            this.Close();
        }
        /// <summary>
        /// 释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmOilVoucher_FormClosing(object sender, FormClosingEventArgs e)
        {
            //dgvAccount.SaveGridView("FrmOilVoucher.dgvAccount");
            //dgvDetail.SaveGridView("FrmOilVoucher.dgvDetail");
            instance = null;    //释放窗体实例变量.
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

    }
}
