using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Repair.DataObject;
using CommonViewer.BaseControl;
using Cost.DataObject;
using CommonOperation;
using CommonViewer;
using Repair.Services;
using Cost.Services;
using CommonViewer.BaseForm;
using CommonOperation.Functions;
using BaseInfo.DataAccess;
using BaseInfo.Objects;
using CommonOperation.Interfaces;

namespace Repair.Viewer
{
    public partial class FrmCreateCertification : CommonViewer.BaseForm.FormBase
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmCreateCertification instance = new FrmCreateCertification();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmCreateCertification Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmCreateCertification.instance = new FrmCreateCertification();
                }

                return FrmCreateCertification.instance;
            }
        }
        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmCreateCertification()
        {
            InitializeComponent();
        }
        #endregion
        private string currency_id = "";
        private string ship_id = "";
        private string serviceprovider = "";
        private string customer = "";
        /// <summary>
        /// 船体加载事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCreateCertification_Load(object sender, EventArgs e)
        {
            DgvBindDrop dgvBindDrop1 = new DgvBindDrop();
            dgvBindDrop1.bindDropToDgv(dgvActualCosts, dateTimePicker1, 1);
            DgvBindDrop dgvBindDrop2 = new DgvBindDrop();
            dgvBindDrop2.bindDropToDgv(dgvActualCosts, dateTimePicker2, 8);
            DgvBindDrop dgvBindDrop3 = new DgvBindDrop();
            dgvBindDrop3.bindDropToDgv(dgvActualCosts, dateTimePicker3, 11);
            DgvBindDrop dgvBindDrop4 = new DgvBindDrop();
            dgvBindDrop4.bindDropToDgv(dgvActualCosts, dateTimePicker4, 17);
            DgvBindDrop dgvBindDrop5 = new DgvBindDrop();

            string err;
            DataTable dtRepair;
            if (!CostAccountPositionService.Instance.GetInfoByCondition(new CostAccountPositionCondition(null, null, "3"), out dtRepair, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            DataTable dtSlipwayRepair;
            if (!CostAccountPositionService.Instance.GetInfoByCondition(new CostAccountPositionCondition(null, null, "4"), out dtSlipwayRepair, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            for (int i = 0; i < dtSlipwayRepair.Rows.Count; i++)
            {
                dtRepair.Rows.Add(dtSlipwayRepair.Rows[i].ItemArray);
            }
            cbxCostType.DataSource = dtRepair;
            cbxCostType.DisplayMember = "path";
            cbxCostType.ValueMember = "NODE_ID";
            dgvBindDrop5.bindDropToDgv(dgvActualCosts, cbxCostType, 10, false, 1);
            setBindingSource();
            setActualCostsBindingSource();
            txtApplyCompany.Text = CommonOperation.ConstParameter.ArgumentSetCollection["VoucherApplyCompany"];
            txtMan1.Text = CommonOperation.ConstParameter.UserName;
        }
        /// <summary>
        /// 绑定修理项目信息.
        /// </summary>
        private void setBindingSource()
        {
            bdsProject.DataSource = ShipRepairProjectService.Instance.GetInfo("---", null, null, null, null, null);
            dgvDetail.DataSource = bdsProject;
            UcDataGridView dgv = dgvDetail;
            dgv.Columns["PROJECTID"].Visible = false;
            dgv.Columns["PROJECTNAME"].HeaderText = "修理项目名称";
            dgv.Columns["PROJECTDETAIL"].HeaderText = "修理项目详细";
            dgv.Columns["APPLYDATE"].HeaderText = "申请日期";
            dgv.Columns["APPLICANT"].HeaderText = "申请人";
            dgv.Columns["WORKORDERID"].Visible = false;
            dgv.Columns["APPLYCOMPLETEDATE"].HeaderText = "期望完成日期";
            dgv.Columns["REALCOMPLETEDATE"].HeaderText = "完成日期";
            dgv.Columns["PROJECTSTATE"].Visible = false;
            dgv.Columns["PROJECTSTATE_NAME"].HeaderText = "审核状态";
            dgv.Columns["AFFIRMANT"].HeaderText = "申请最终确认人";
            dgv.Columns["COMPLETEAFFIRMANT"].HeaderText = "完成确认人";
            dgv.Columns["RUNNINGORDOCK"].Visible = false;
            dgv.Columns["RUNNINGORDOCK_NAME"].HeaderText = "航修或坞修";
            dgv.Columns["REPAIRSUBJECT"].Visible = false;
            dgv.Columns["SERVICEPROVIDER"].Visible = false;
            dgv.Columns["REMARK"].HeaderText = "申请备注";
            dgv.Columns["REMARK"].Visible = false;
            dgv.Columns["SHIP_ID"].Visible = false;
            dgv.Columns["SHIP_NAME"].HeaderText = "船舶";
            dgv.Columns["CURRENCYID"].Visible = false;
            dgv.Columns["CURRENCYCODE"].HeaderText = "货币";
            dgv.Columns["COSTCOUNT"].HeaderText = "消费金额";
            dgv.Columns["EQUIPMENTID"].Visible = false;
            dgv.Columns["COMP_CHINESE_NAME"].Visible = false;
            dgv.Columns["COMP_FULL_NAME"].HeaderText = "修理设备";
            dgv.Columns["SENDTOWARRANT"].Visible = false;
            dgv.Columns["SENDTOWARRANT_NAME"].HeaderText = "是否提交费用凭证";
            dgv.Columns["APPLYPOST"].Visible = false;
            dgv.Columns["HEADSHIP_NAME"].HeaderText = "申请人岗位";
            dgv.Columns["HEADSHIP_NAME"].Visible = false;
            dgv.Columns["SHIP_HEADSHIP_ID"].Visible = false;
            dgv.Columns["DEPARTMENTID"].Visible = false;
            dgv.Columns["NODE_NAME"].HeaderText = "修理科目";
            dgv.Columns["RELATIONID"].Visible = false;
            dgv.Columns["MANUFACTURER_NAME"].HeaderText = "供应商名称";
            dgv.Columns["REPAIRID"].Visible = false;
            dgv.Columns["REPAIRCODE"].HeaderText = "修理编号";
            dgv.Columns["REPAIRCODE"].Visible = false;
            dgv.Columns["REPAIRPORT"].HeaderText = "修理港口";
            dgv.Columns["ARRANGED"].Visible = false;
            dgv.Columns["ARRANGED_NAME"].HeaderText = "委托状态";
            dgv.Columns["ARRANGED_NAME"].Visible = false;
            dgv.Columns["ARRANGEDPERSON"].HeaderText = "安排人";
            dgv.Columns["SHIPAFFIRMANT"].HeaderText = "完工船端确认人";
            dgv.Columns["COMPAFFIRMANT"].HeaderText = "完工岸端确认人";
            dgv.Columns["REPAIRDATE"].HeaderText = "修理开始日期";
            dgv.Columns["COMPLETEDATE"].HeaderText = "修理完成日期";
            dgv.Columns["COMPLETEDATE"].Visible = false;
            dgv.Columns["REPAIR_REMARK"].HeaderText = "修理备注";
            dgv.Columns["REPAIR_REMARK"].Visible = false;
            dgv.Columns["VOUCHER_ID"].Visible = false;
            dgv.LoadGridView("FrmCreateCertification.dgvDetail");
        }
        /// <summary>
        /// 加载子列表数据.
        /// </summary>
        public void setActualCostsBindingSource()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("COSTS_ID", typeof(string));
            dt.Columns.Add("OCCURENCY_DATE", typeof(DateTime));
            dt.Columns.Add("CUSTOMER", typeof(string));
            dt.Columns.Add("CURRENCY_ID", typeof(string));
            dt.Columns.Add("CURRENCY_NAME", typeof(string));
            dt.Columns.Add("ESTIMATE_AMOUNT", typeof(decimal));
            dt.Columns.Add("AMOUNT", typeof(decimal));
            dt.Columns.Add("CONVERT_MONEY", typeof(decimal));
            dt.Columns.Add("PAYMENT_DATE", typeof(DateTime));
            dt.Columns.Add("NODE_ID", typeof(string));
            dt.Columns.Add("NODE_NAME", typeof(string));
            dt.Columns.Add("COMPLETE_DATE", typeof(DateTime));
            dt.Columns.Add("COMPLETE_PALCE", typeof(string));
            dt.Columns.Add("DESCRIPTION", typeof(string));
            dt.Columns.Add("APPLICANT", typeof(string));
            dt.Columns.Add("APPROVER", typeof(string));
            dt.Columns.Add("APPROVER2", typeof(string));
            dt.Columns.Add("INVOICE_DATE", typeof(DateTime));
            dt.Columns.Add("INVOICE_NUM", typeof(string));
            dt.Columns.Add("CONTRACT_NUM", typeof(string));
            dt.Columns.Add("VOUCHER_ID", typeof(string));
            dt.Columns.Add("SHIP_ID", typeof(string));
            dt.Columns.Add("SHIP_NAME", typeof(string));
            dt.Columns.Add("REMARK", typeof(string));
            bdsCost.DataSource = dt;
            dgvActualCosts.DataSource = bdsCost;
            //设置列标题.

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
            dgvActualCosts.SetDgvGridColumns(dictColumns);
            //设置列只读.

            dgvActualCosts.Columns["CUSTOMER"].ReadOnly = true;
            dgvActualCosts.Columns["CURRENCY_ID"].ReadOnly = true;
            dgvActualCosts.Columns["CURRENCY_NAME"].ReadOnly = true;
            dgvActualCosts.Columns["NODE_ID"].ReadOnly = true;
            dgvActualCosts.Columns["NODE_NAME"].ReadOnly = true;
            dgvActualCosts.Columns["SHIP_ID"].ReadOnly = true;
            dgvActualCosts.Columns["SHIP_NAME"].ReadOnly = true;
            dgvActualCosts.LoadGridView("FrmCreateCertification.dgvActualCosts");
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
        /// 计算折算成美元.
        /// </summary>
        private decimal CalculateConvertUSD(string currencyID, decimal baseAmount)
        {
            string err;
            if (GetCurrencyCode(currencyID).ToUpper() == "USD")
                return baseAmount;
            DateTime tempDate = DateTime.Now;
            //Dictionary<string, string> discRate = new Dictionary<string, string>();
            //discRate = CurrencyRateService.Instance.getRateByUSD("USD", tempDate, out err);
            decimal toUSDAmount = 0.00M;
            //if (discRate.ContainsKey(currencyID))
            //{
            //    toUSDAmount = decimal.Parse(discRate[currencyID]) * baseAmount;
            //}            

            //liulei-2016/01/07-根据币种和时间查询汇率
            DataTable dt = CurrencyRateService.Instance.GetRateByTime(currencyID, "USD", date1.Value.Date, out err);
            if (dt != null && dt.Rows.Count > 0)
            {
                toUSDAmount = decimal.Parse(dt.Rows[0]["EXCHANGERATE"].ToString()) * baseAmount;
            }
            return toUSDAmount;
        }
        /// <summary>
        /// 导入修理项目.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            FrmRepairHistory frm = null;
            if (string.IsNullOrEmpty(this.customer) && string.IsNullOrEmpty(this.currency_id) && string.IsNullOrEmpty(this.ship_id))
            {
                frm = new FrmRepairHistory(3);
            }
            else
            {
                List<string> idlist = new List<string>();
                foreach (DataGridViewRow item in dgvDetail.Rows)
                {
                    idlist.Add(item.Cells["PROJECTID"].Value.ToString());
                }
                frm = new FrmRepairHistory(this.serviceprovider, this.currency_id, this.ship_id, idlist);
            }
            frm.ShowDialog();
            if (frm.dtsrp != null && frm.dtsrp.Rows.Count > 0)
            {
                DataTable dtProject = (DataTable)bdsProject.DataSource;
                decimal sumAmount = 0;
                DataTable dtActualCosts = ((DataTable)bdsCost.DataSource);
                foreach (DataRow item in frm.dtsrp.Rows)
                {
                    dtProject.Rows.Add(item.ItemArray);

                    DataRow dr = dtActualCosts.NewRow();
                    dr["DESCRIPTION"] = item["PROJECTNAME"];
                    dr["OCCURENCY_DATE"] = DateTime.Now;
                    dr["PAYMENT_DATE"] = DateTime.Now;
                    dr["CUSTOMER"] = item["MANUFACTURER_NAME"];
                    dr["CURRENCY_ID"] = item["CURRENCYID"];
                    dr["CURRENCY_NAME"] = item["CURRENCYCODE"];
                    dr["AMOUNT"] = item["COSTCOUNT"];
                    dr["SHIP_ID"] = item["SHIP_ID"];
                    dr["SHIP_NAME"] = item["SHIP_NAME"];
                    dr["NODE_ID"] = item["REPAIRSUBJECT"];
                    dr["NODE_NAME"] = item["NODE_NAME"];
                    dr["CONVERT_MONEY"] = CalculateConvertUSD(item["CURRENCYID"].ToString(), Convert.ToDecimal(item["COSTCOUNT"]));
                    dtActualCosts.Rows.Add(dr);

                    sumAmount += Convert.ToDecimal(item["COSTCOUNT"]);
                    txtCurrency.Text = item["CURRENCYCODE"].ToString();
                    txtCustomer.Text = item["MANUFACTURER_NAME"].ToString();
                    txtShip.Text = item["SHIP_NAME"].ToString();

                    txtShip.Text = item["SHIP_NAME"].ToString();
                    string err;
                    string voucherNum = "";
                    if (item["SHIP_ID"].ToString() != null && !string.IsNullOrEmpty(item["SHIP_ID"].ToString()))
                    {
                        if (!VOUCHERService.Instance.GetMaxVoucherNum(item["SHIP_ID"].ToString(), out voucherNum, out err))
                        {
                            MessageBoxEx.Show(err);
                            return;
                        }
                    }
                    txtVNum.Text = voucherNum; //设置凭证号.

                    this.currency_id = item["CURRENCYID"].ToString();
                    this.ship_id = item["SHIP_ID"].ToString();
                    this.customer = item["MANUFACTURER_NAME"].ToString();
                    this.serviceprovider = item["SERVICEPROVIDER"].ToString();
                }
                bdsCost.DataSource = dtActualCosts;
                bdsProject.DataSource = dtProject;
                txtSmall.Text = sumAmount.ToString();
                txtBig.Text = Tools.numberToChinese(sumAmount);
            }
        }

        private void dgvActualCosts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (dgvActualCosts.Columns[e.ColumnIndex].Name == "AMOUNT")
                {
                    if (dgvActualCosts.Rows[e.RowIndex].Cells["AMOUNT"].Value == null
                        || string.IsNullOrEmpty(dgvActualCosts.Rows[e.RowIndex].Cells["AMOUNT"].Value.ToString()))
                    {
                        dgvActualCosts.Rows[e.RowIndex].Cells["CONVERT_MONEY"].Value = 0;
                        return;
                    }
                    decimal baseAmount = Convert.ToDecimal(dgvActualCosts.Rows[e.RowIndex].Cells["AMOUNT"].Value);
                    string CURRENCY = dgvActualCosts.Rows[e.RowIndex].Cells["CURRENCY_ID"].Value.ToString();
                    dgvActualCosts.Rows[e.RowIndex].Cells["CONVERT_MONEY"].Value = CalculateConvertUSD(CURRENCY, baseAmount);
                }
            }
        }
        /// <summary>
        /// check凭证form
        /// </summary>
        /// <returns></returns>
        private bool CheckVoucherForm()
        {
            if (string.IsNullOrEmpty(txtVNum.Text.Trim()))
            {
                MessageBoxEx.Show("凭证号不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtApplyCompany.Text.Trim()))
            {
                MessageBoxEx.Show("申请单位不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(this.customer))
            {
                MessageBoxEx.Show("收款人不能为空");
                return false;
            }

            if (string.IsNullOrEmpty(txtShip.Text.Trim()))
            {
                MessageBoxEx.Show("应收船东不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtSmall.Text.Trim()))
            {
                MessageBoxEx.Show("合计小写不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtBig.Text.Trim()))
            {
                MessageBoxEx.Show("合计大写不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(this.currency_id))
            {
                MessageBoxEx.Show("币种不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(this.txtREMARK.Text.Trim()))
            {
                MessageBoxEx.Show("费用说明不能为空");
                return false;
            }
            return true;
        }
        /// <summary>
        /// check实际发生费用form
        /// </summary>
        /// <returns></returns>
        private bool CheckCostActualCostsForm()
        {
            foreach (DataGridViewRow item in dgvActualCosts.Rows)
            {
                if (string.IsNullOrEmpty(item.Cells["OCCURENCY_DATE"].Value.ToString()))
                {
                    MessageBoxEx.Show("发生日期不能为空");
                    return false;
                }
                if (string.IsNullOrEmpty(item.Cells["CUSTOMER"].Value.ToString()))
                {
                    MessageBoxEx.Show("供应商不能为空");
                    return false;
                }
                if (string.IsNullOrEmpty(item.Cells["CURRENCY_ID"].Value.ToString()))
                {
                    MessageBoxEx.Show("币种不能为空");
                    return false;
                }
                if (string.IsNullOrEmpty(item.Cells["CONVERT_MONEY"].Value.ToString()))
                {
                    MessageBoxEx.Show("折算成美金不能为空");
                    return false;
                }
                if (string.IsNullOrEmpty(item.Cells["PAYMENT_DATE"].Value.ToString()))
                {
                    MessageBoxEx.Show("付款日期不能为空");
                    return false;
                }
                if (string.IsNullOrEmpty(item.Cells["NODE_ID"].Value.ToString()))
                {
                    MessageBoxEx.Show("科目名称不能为空");
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 保存操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string err;
            if (dgvActualCosts.Rows.Count == 0)
            {
                MessageBoxEx.Show("没有费用项目,请先增加凭证项目!", "提示");
                return;
            }
            if (dgvDetail.Rows.Count == 0)
            {
                MessageBoxEx.Show("没有修理项目,请先增加修理项目!", "提示");
                return;
            }
            if (!CheckVoucherForm()) return;
            if (!CheckCostActualCostsForm()) return;
            List<string> sqlList = new List<string>();
            //对象赋值.

            foreach (DataGridViewRow item in dgvActualCosts.Rows)
            {
                VOUCHER currentObject = new VOUCHER();
                currentObject.AMOUNT_LOW = txtSmall.Text;
                currentObject.AMOUNT_UP = txtBig.Text;
                currentObject.APPLY_COMPANY = txtApplyCompany.Text;
                currentObject.CURRENCY_ID = this.currency_id;
                currentObject.INVOICE_NUM = int.Parse(Decimal.Round(numInvoiceNum.Value, 0).ToString());
                currentObject.PAYEE = this.customer;
                currentObject.SHIP_OWNER = txtShip.Text.Trim();
                currentObject.VOUCHER_NUM = txtVNum.Text.Trim();
                currentObject.APPLICANT = txtMan1.Text.Trim();
                currentObject.VOUCHER_DATE = date1.Value;
                currentObject.CURRENT_STATE = 1;
                sqlList.Add(currentObject.Update());
                ACTUAL_COSTS nowObject = new ACTUAL_COSTS();
                nowObject.VOUCHER_ID = currentObject.VOUCHER_ID;
                nowObject.APPLICANT = txtMan1.Text.Trim();
                //nowObject.APPROVER = item.Cells["APPROVER"].Value.ToString();
                //nowObject.APPROVER2 = item.Cells["APPROVER2"].Value.ToString();
                nowObject.REMARK = txtREMARK.Text.Trim();
                nowObject.COMPLETE_PALCE = item.Cells["COMPLETE_PALCE"].Value.ToString();
                nowObject.CONTRACT_NUM = item.Cells["CONTRACT_NUM"].Value.ToString();
                nowObject.CUSTOMER = item.Cells["CUSTOMER"].Value.ToString();
                nowObject.DESCRIPTION = item.Cells["NODE_NAME"].Value.ToString();
                nowObject.INVOICE_NUM = item.Cells["INVOICE_NUM"].Value.ToString();
                nowObject.NODE_ID = item.Cells["NODE_ID"].Value.ToString();
                nowObject.CURRENCY_ID = item.Cells["CURRENCY_ID"].Value.ToString();
                nowObject.VOUCHER_ID = currentObject.VOUCHER_ID;
                nowObject.SHIP_ID = item.Cells["SHIP_ID"].Value.ToString();
                nowObject.SENDED = 2;
                if (!string.IsNullOrEmpty(item.Cells["AMOUNT"].Value.ToString()))
                    nowObject.AMOUNT = Convert.ToDecimal(item.Cells["AMOUNT"].Value);
                if (!string.IsNullOrEmpty(item.Cells["COMPLETE_DATE"].Value.ToString()))
                    nowObject.COMPLETE_DATE = Convert.ToDateTime(item.Cells["COMPLETE_DATE"].Value);
                if (!string.IsNullOrEmpty(item.Cells["CONVERT_MONEY"].Value.ToString()))
                    nowObject.CONVERT_MONEY = Convert.ToDecimal(item.Cells["CONVERT_MONEY"].Value);
                if (!string.IsNullOrEmpty(item.Cells["ESTIMATE_AMOUNT"].Value.ToString()))
                    nowObject.ESTIMATE_AMOUNT = Convert.ToDecimal(item.Cells["ESTIMATE_AMOUNT"].Value);
                if (!string.IsNullOrEmpty(item.Cells["INVOICE_DATE"].Value.ToString()))
                    nowObject.INVOICE_DATE = Convert.ToDateTime(item.Cells["INVOICE_DATE"].Value);
                if (!string.IsNullOrEmpty(item.Cells["OCCURENCY_DATE"].Value.ToString()))
                    nowObject.OCCURENCY_DATE = Convert.ToDateTime(item.Cells["OCCURENCY_DATE"].Value);
                if (!string.IsNullOrEmpty(item.Cells["PAYMENT_DATE"].Value.ToString()))
                    nowObject.PAYMENT_DATE = Convert.ToDateTime(item.Cells["PAYMENT_DATE"].Value);
                sqlList.Add(nowObject.Update());
            }
            foreach (DataGridViewRow item in dgvDetail.Rows)
            {
                ShipRepairProject srp = ShipRepairProjectService.Instance.getObject(item.Cells["PROJECTID"].Value.ToString(), out err);
                srp.VOUCHER_ID = txtVNum.Text.Trim();
                srp.SENDTOWARRANT = 1;
                sqlList.Add(ShipRepairProjectService.Instance.saveUnit(srp, 2));
            }
            IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
            if (!dbAccess.ExecSql(sqlList, out err))
            {
                MessageBoxEx.Show(err, "操作失败");
                return;
            }
            else
            {
                MessageBoxEx.Show("操作成功!", "", new MessageBoxButtons(), MessageBoxIcon.Information);
                txtVNum.Text = ""; //设置凭证号.

                setBindingSource();
                setActualCostsBindingSource();
                txtApplyCompany.Text = CommonOperation.ConstParameter.ArgumentSetCollection["VoucherApplyCompany"];
                txtSmall.Text = "";
                txtBig.Text = "";
                txtCurrency.Text = "";
                txtCustomer.Text = "";
                txtShip.Text = "";
                this.customer = "";
                this.currency_id = "";
                this.ship_id = "";
                numInvoiceNum.Value = 0;
                txtMan1.Text = "";
                txtREMARK.Text = "";
            }
        }
        /// <summary>
        /// 复制实际发生费用.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (bdsCost.Current != null)
            {
                DataTable dtActualCosts = ((DataTable)bdsCost.DataSource);
                dtActualCosts.Rows.Add(((System.Data.DataRowView)(bdsCost.Current)).Row.ItemArray);
                bdsCost.DataSource = dtActualCosts;
            }
            resetTotalValue();
        }
        /// <summary>
        /// 移除实际发生费用.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (bdsCost.Current != null)
                bdsCost.RemoveCurrent();
            resetTotalValue();
        }
        /// <summary>
        /// 移除修理项目.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteRepair_Click(object sender, EventArgs e)
        {
            if (bdsProject.Current != null)
                bdsProject.RemoveCurrent();
        }

        private void dgvActualCosts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvActualCosts.Columns[e.ColumnIndex].Name == "AMOUNT")
            {
                resetTotalValue();
            }
        }

        private void resetTotalValue()
        {
            decimal sumAmount = 0;
            foreach (DataGridViewRow item in dgvActualCosts.Rows)
            {
                sumAmount += Convert.ToDecimal(item.Cells["AMOUNT"].Value);
            }
            txtSmall.Text = sumAmount.ToString();
            txtBig.Text = Tools.numberToChinese(sumAmount);
        }

        /// <summary>
        /// 正在关闭窗体.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCreateCertification_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvDetail.SaveGridView("FrmCreateCertification.dgvDetail");
            dgvActualCosts.SaveGridView("FrmCreateCertification.dgvActualCosts");
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