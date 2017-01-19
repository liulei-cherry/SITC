using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseInfo.DataAccess;
using StorageManage.Services;
using CommonViewer.BaseControl;
using BaseInfo.Objects;
using CommonViewer;
using System.IO;
using StorageManage.DataObject;
using Cost.Services;
using Cost.DataObject;
using ItemsManage;
using ItemsManage.DataObject;
using ItemsManage.Services;
using CommonOperation;
using CommonOperation.Functions;
using Cost.Viewer;
using CommonOperation.Interfaces;

namespace StorageManage.Viewer
{
    public partial class FrmMaterialVoucher : CommonViewer.BaseForm.FormBase
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmMaterialVoucher instance = new FrmMaterialVoucher();
        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmMaterialVoucher Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmMaterialVoucher.instance = new FrmMaterialVoucher();
                }
                return FrmMaterialVoucher.instance;
            }
        }
        private FrmMaterialVoucher()
        {
            InitializeComponent();
        }
        #endregion
        List<string> orderIDList = new List<string>();
        string lastAccount = "2";//默认为物资.

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMaterialVoucher_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;//窗体最大化.
            setComboBox();
            txtPerson.Text = CommonOperation.ConstParameter.UserName;
            dtpDate.Value = DateTime.Now;
            ucShipSelect1.ChangeSelectedState(true, "", true);
            ucCurrencySelect1.ChangeMode(true, false, false);
            ucManufacturerSelect1.ChangeMode(true, true, false, "");
            SetAccountBindingSource();
            SetDetailBindingSource();
            SetAccountDataView();
        }
        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {
            //类别（1：备件；2：物料；3：航修；4：坞修；5：捆扎件；6：缆绳；7：油漆;8:化学品）.
            cmbAccount.DisplayMember = "Name";
            cmbAccount.ValueMember = "Id";
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            DataRow row11 = dt.NewRow();
            row11["Id"] = "2";
            row11["Name"] = "物资费";
            dt.Rows.Add(row11);
            DataRow row2 = dt.NewRow();
            row2["Id"] = "5";
            row2["Name"] = "绑扎件";
            dt.Rows.Add(row2);
            DataRow row3 = dt.NewRow();
            row3["Id"] = "6";
            row3["Name"] = "缆绳";
            dt.Rows.Add(row3);
            DataRow row5 = dt.NewRow();
            row5["Id"] = "7";
            row5["Name"] = "油漆";
            dt.Rows.Add(row5);
            DataRow row4 = dt.NewRow();
            row4["Id"] = "8";
            row4["Name"] = "化学品";
            dt.Rows.Add(row4);
            cmbAccount.DataSource = dt;
        }
        /// <summary>
        /// 绑定凭证科目类信息.
        /// </summary>
        private void SetAccountBindingSource()
        {
            string err;
            DataTable dt;
            if (!CostAccountPositionService.Instance.GetInfoByCondition(
                new CostAccountPositionCondition(null, null, cmbAccount.SelectedValue.ToString()), out dt, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            if (dt.Rows.Count == 0)
            {
                MessageBoxEx.Show("选择的科目没有科目定位配置项");
                return;
            }
            bdsAccount.DataSource = dt;
            dgvAccount.DataSource = bdsAccount;
        }
        /// <summary>
        /// 绑定凭证科目类信息.
        /// </summary>
        private void SetAccountDataView()
        {
            Dictionary<string, string> dgvColumnStyle = new Dictionary<string, string>();
            dgvColumnStyle.Add("NODE_NAME", "科目");
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

            //dgvAccount.LoadGridView("FrmMaterialVoucher.dgvAccount");

            foreach (DataGridViewColumn item in dgvAccount.Columns)
                if (item.ReadOnly)
                    item.DefaultCellStyle.BackColor = Color.Linen;
        }
        /// <summary>
        ///  绑定凭证详细信息.
        /// </summary>
        private void SetDetailBindingSource()
        {
            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("ORDER_DETAIL_ID", typeof(string));
            dtDetail.Columns.Add("MATERIAL_ID", typeof(string));
            dtDetail.Columns.Add("MATERIAL_NAME", typeof(string));
            dtDetail.Columns.Add("MATERIAL_CODE", typeof(string));
            dtDetail.Columns.Add("MATERIAL_SPEC", typeof(string));
            dtDetail.Columns.Add("PARTNUMBER", typeof(string));
            dtDetail.Columns.Add("QUANTITY", typeof(decimal));
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
            dic.Add("MATERIAL_NAME", "物资");
            dic.Add("MATERIAL_CODE", "物资编号");
            dic.Add("MATERIAL_SPEC", "采购号或规格");
            dic.Add("QUANTITY", "数量");
            dic.Add("CURRENCYCODE", "币种");
            dic.Add("AMOUNT", "金额");
            dic.Add("REBATE", "折扣");
            dic.Add("REBATEAMOUNT", "折算金额");
            dic.Add("ACCOUNT_NAME", "费用科目类型");
            dgvDetail.SetDgvGridColumns(dic);
            //dgvDetail.LoadGridView("FrmMaterialVoucher.dgvDetail");
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
            string err;
            DataTable dt = MaterialPurchaseOrderService.Instance.getInfo(orderID, out err);
            ucShipSelect1.SelectedId(dt.Rows[0]["SHIP_ID"].ToString());
            ucManufacturerSelect1.SelectedId(dt.Rows[0]["SUPPLIER_ID"].ToString());
            ucShipSelect1.Enabled = false;
            ucManufacturerSelect1.Enabled = false;
        }
        /// <summary>
        /// 得到物资所属的科目类型,如果查询不到就返回系统配置的其他物资科目.
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="ACCOUNT_CODE"></param>
        /// <param name="ACCOUNT_NAME"></param>
        private void GetAccountType(string ID, out string ACCOUNT_CODE, out string ACCOUNT_NAME)
        {
            string err = "";
            ACCOUNT_CODE = "";
            ACCOUNT_NAME = "";
            if (StorageConfig.getMaterialCostMapping != null)
            {
                if (StorageConfig.getMaterialCostMapping(ID, out ACCOUNT_CODE, out ACCOUNT_NAME, out err))
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
            if (CommonOperation.ConstParameter.ArgumentSetCollection.ContainsKey("OtherMaterialCost")
             || CommonOperation.ConstParameter.ArgumentSetCollection.ContainsKey("OtherMaterialCostName"))
            {
                ACCOUNT_NAME = CommonOperation.ConstParameter.ArgumentSetCollection["OtherMaterialCostName"];
                ACCOUNT_CODE = CommonOperation.ConstParameter.ArgumentSetCollection["OtherMaterialCost"];
            }
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
        /// 得到科目列表中现有的科目编码.
        /// </summary>
        /// <returns></returns>
        private List<string> GetCurrentAccount()
        {
            List<string> caList = new List<string>();
            if (dgvAccount.Rows.Count > 0)
            {
                foreach (DataGridViewRow item in dgvAccount.Rows)
                {
                    caList.Add(item.Cells["CODE"].Value.ToString());
                }
            }
            return caList;
        }
        /// <summary>
        /// 添加按钮事件,打开选择明细页面,导入选择的明细,并计算折算金额,找出属于的科目类型.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            string err;
            if (bdsAccount.Current == null)
            {
                MessageBoxEx.Show("请先选择费用类型");
                return;
            }
            FrmMaterialPurchaseOrderSelect frm = new FrmMaterialPurchaseOrderSelect(ucShipSelect1.GetId(),
                ucManufacturerSelect1.GetId(), GetCurrentAccount(), orderIDList);
            frm.ShowDialog();

            if (frm.orderIDList.Count != 0 && frm.storageParameterList.Count != 0)
            {
                orderIDList.AddRange(frm.orderIDList);
                ShowDataToForm(frm.orderIDList[0]);
                foreach (string item in frm.orderIDList)
                {
                    DataTable dtDetail;
                    if (!MaterialPurchaseOrderDetailService.Instance.GetInfo(item, out dtDetail, out err))
                    {
                        MessageBoxEx.Show(err);
                        return;
                    }
                    foreach (DataRow itemDetail in dtDetail.Rows)
                    {
                        MaterialInfo obj = MaterialInfoService.Instance.getObject(itemDetail["MATERIAL_ID"].ToString(), out err);
                        if (string.IsNullOrEmpty(obj.MATERIAL_CODE) || string.IsNullOrEmpty(obj.MATERIAL_CODE.Trim()) || Convert.ToDecimal(itemDetail["RECEIVECOUNT"]) == 0)
                            continue;

                        string ACCOUNT_CODE;
                        string ACCOUNT_NAME;
                        GetAccountType(obj.MATERIAL_ID, out  ACCOUNT_CODE, out  ACCOUNT_NAME);
                        if (!GetCurrentAccount().Contains(ACCOUNT_CODE))
                            continue;

                        DataTable dt = (DataTable)bdsDetail.DataSource;
                        DataRow dr = dt.NewRow();
                        dr["ORDER_DETAIL_ID"] = itemDetail["PURCHASE_ORDER_DETAIL_ID"];
                        dr["MATERIAL_ID"] = itemDetail["MATERIAL_ID"];
                        dr["MATERIAL_NAME"] = itemDetail["MATERIAL_NAME"];
                        dr["MATERIAL_CODE"] = itemDetail["MATERIAL_CODE"];
                        dr["MATERIAL_SPEC"] = itemDetail["MATERIAL_SPEC"];
                        dr["QUANTITY"] = itemDetail["RECEIVECOUNT"];
                        dr["CURRENCYID"] = itemDetail["CURRENCYID"];
                        dr["CURRENCYCODE"] = itemDetail["CURRENCYCODE"];
                        dr["AMOUNT"] = itemDetail["PRICE"];
                        dr["REBATE"] = 1;
                        dr["REBATEAMOUNT"] = CalculateAmount(dr["CURRENCYID"].ToString(), Convert.ToDecimal(dr["REBATE"]), Convert.ToDecimal(dr["AMOUNT"]));
                        dr["ACCOUNT_CODE"] = ACCOUNT_CODE;
                        dr["ACCOUNT_NAME"] = ACCOUNT_NAME;
                        dt.Rows.Add(dr);
                    }
                }
            }
        }

        /// <summary>
        /// 计算凭证总金额.
        /// </summary>
        /// <param name="itemDetail"></param>
        /// <returns></returns>
        private void CalculateTotalAmount()
        {
            decimal total = 0;
            //foreach (DataGridViewRow itemDetail in dgvDetail.Rows)
            //    if (itemDetail.Cells["REBATEAMOUNT"].Value != null && !string.IsNullOrEmpty(itemDetail.Cells["REBATEAMOUNT"].Value.ToString()))
            //        total += Convert.ToDecimal(itemDetail.Cells["REBATEAMOUNT"].Value);
            foreach (DataGridViewRow itemAccount in dgvAccount.Rows)
                if (itemAccount.Cells["AMOUNT"].Value != null && !string.IsNullOrEmpty(itemAccount.Cells["AMOUNT"].Value.ToString()))
                    total += Convert.ToDecimal(itemAccount.Cells["AMOUNT"].Value);
            nudTotalAmount.Value = total;
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
                    CalculateAmount(dgvDetail.Rows[e.RowIndex]);
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
        /// 更改科目金额时,计算折算成美元,假如就一条科目,他的金额就与总金额相等,相互影响.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAccount_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (dgvAccount.Columns[e.ColumnIndex].Name == "AMOUNT")
                {
                    CalculateTotalAmount();
                    if (dgvAccount.Rows[e.RowIndex].Cells["AMOUNT"].Value == null || string.IsNullOrEmpty(dgvAccount.Rows[e.RowIndex].Cells["AMOUNT"].Value.ToString()))
                    {
                        dgvAccount.Rows[e.RowIndex].Cells["CONVERTDOLLARS"].Value = 0;
                        return;
                    }
                    decimal baseAmount = Convert.ToDecimal(dgvAccount.Rows[e.RowIndex].Cells["AMOUNT"].Value);
                    dgvAccount.Rows[e.RowIndex].Cells["CONVERTDOLLARS"].Value = CalculateConvertUSD(baseAmount);
                }
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
            DataTable dt = CurrencyRateService.Instance.GetRateByTime(currencyID, "USD", tempDate.Date, out err);
            if (dt != null && dt.Rows.Count > 0)
            {
                toUSDAmount = decimal.Parse(dt.Rows[0]["EXCHANGERATE"].ToString()) * baseAmount;
            }            
            return toUSDAmount;
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
        /// 总金额改变时,假如就一条科目,他的金额就与总金额相等,相互影响.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudTotalAmount_Leave(object sender, EventArgs e)
        {
            if (dgvAccount.Rows.Count == 1)
            {
                dgvAccount.Rows[0].Cells["AMOUNT"].Value = nudTotalAmount.Value;
            }
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
                if (dic[item] == 0 || dic[item] == tempAmount)
                    continue;
                if (dic[item] < tempAmount)
                {
                    MessageBoxEx.Show("科目金额小于属于该科目的凭证详细的总金额");
                    return false;

                }
            }
            decimal accountTotal = 0;
            foreach (DataGridViewRow item in dgvAccount.Rows)
            {
                accountTotal += Convert.ToDecimal(item.Cells["AMOUNT"].Value);
            }
            if (accountTotal != nudTotalAmount.Value)
            {
                MessageBoxEx.Show("科目总金额与凭证合计金额不相等");
                return false;
            }
            return true;
        }
        /// <summary>
        /// 得到属于该科目的明细的汇总金额.
        /// </summary>
        /// <param name="NODE_ID"></param>
        /// <returns></returns>
        private decimal GetDetailAmountByAccount(string NODE_ID)
        {
            decimal tempAmount = 0;
            DataTable dt = (DataTable)bdsDetail.DataSource;
            foreach (DataRow item in dt.Select(" ACCOUNT_CODE ='" + NODE_ID + "'"))
            {
                tempAmount += Convert.ToDecimal(item["REBATEAMOUNT"]);
            }
            return tempAmount;
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
                if (Convert.ToDecimal(item.Cells["AMOUNT"].Value) == 0)
                    continue;
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

                sqlList.Add(currentObject.Update());
                ACTUAL_COSTS nowObject = new ACTUAL_COSTS();
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

            foreach (DataGridViewRow item in dgvDetail.Rows)
            {
                if (Convert.ToDecimal(item.Cells["REBATEAMOUNT"].Value) == 0)
                    continue;
                DataRow dr = dtSap.NewRow();
                dr["UUID"] = item.Cells["ORDER_DETAIL_ID"].Value;
                dr["MATERIAL"] = item.Cells["MATERIAL_ID"].Value;
                dr["QUANTITY"] = item.Cells["QUANTITY"].Value;
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
            sqlList.AddRange(StorageConfig.createPurchaseMessageSql(dtSap));
            foreach (string item in orderIDList)
            {
                MaterialPurchaseOrder spo = MaterialPurchaseOrderService.Instance.getObject(item, out err);
                spo.SENDDATE = DateTime.Now;
                spo.STATE = 9;
                sqlList.Add(MaterialPurchaseOrderService.Instance.saveUnit(spo, 2));
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
        /// 科目改变时,当选择了明细就询问是否更改,是:页面数据清空.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbAccount_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (dgvDetail.Rows.Count > 0)
            {
                if (DialogResult.Yes == MessageBoxEx.Show("已选择了对应该科目的明细项,确认更改吗?",
                    "系统提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    orderIDList.Clear();
                    SetAccountBindingSource();
                    bdsDetail.DataSource = new DataTable();

                    nudTotalAmount.Value = 0;
                    ucManufacturerSelect1.Enabled = true;
                    ucShipSelect1.Enabled = true;

                    lastAccount = cmbAccount.SelectedValue.ToString();
                }
                else
                {
                    cmbAccount.SelectedValue = lastAccount;
                }
            }
            else
            {
                SetAccountBindingSource();
                nudTotalAmount.Value = 0;
                lastAccount = cmbAccount.SelectedValue.ToString();
            }
        }
        /// <summary>
        /// 释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMaterialVoucher_FormClosing(object sender, FormClosingEventArgs e)
        {
            //dgvAccount.SaveGridView("FrmMaterialVoucher.dgvAccount");
            //dgvDetail.SaveGridView("FrmMaterialVoucher.dgvDetail");
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
