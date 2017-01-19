using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cost.Services;
using Cost.DataObject;
using BaseInfo.Objects;
using BaseInfo.DataAccess;
using CommonViewer.BaseControl;
using CommonViewer.BaseControlService;

namespace Cost.Viewer
{
    public partial class FrmEditOneShipOwner : CommonViewer.BaseForm.FormBase
    {

        ACTUAL_COSTS nowObject = new ACTUAL_COSTS();
        public ACTUAL_COSTS NowObject
        {
            get { return nowObject; }
            set
            {
                if (null == value)
                {
                    return;
                }
                nowObject = value;
                showObject();
            }

        }

        #region 其它公共业务类


        private FormControlOption other = FormControlOption.Instance;
        Dictionary<string, string> discRate = new Dictionary<string, string>();

        #endregion

        public FrmEditOneShipOwner()
        {
            InitializeComponent();
        }

        public FrmEditOneShipOwner(ACTUAL_COSTS tempObject, string shipID)
        {
            InitializeComponent();

            string err = "";

            //获取汇率集合
            //DateTime tempDate = date3.Value;
            //discRate = CurrencyRateService.Instance.getRateByUSD("USD", tempDate, out err);

            setComboBox();                 //设置窗体所需的下拉列表框的数据源.

            NowObject = tempObject;
            ucShipSelect2.SelectedId(shipID);
        }


        private void FrmEditOneShipOwner_Load(object sender, EventArgs e)
        {
            ucShipSelect2.ChangeSelectedState(false,true,"", true);
            ucManufacturerSelect1.ChangeMode(true, true, false,"");
        }


        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {
            string err = "";

            //科目.
            DataTable dtb2 = AccountService.Instance.GetTreeSubjects();
            DataRow drCob1 = dtb2.NewRow(); 
            drCob1["NODE_ID"] = "";
            drCob1["path"] = "";
            dtb2.Rows.InsertAt(drCob1, 0);
            other.SetComboBoxValue(cob1, dtb2);

            //币种.
            DataTable dtb3 = CurrencyService.Instance.getInfo(out err);
            DataRow drCob = dtb3.NewRow();
            drCob["CURRENCYID"] = "";
            drCob["CURRENCYNAME"] = "";
            dtb3.Rows.InsertAt(drCob, 0);
            other.SetComboBoxValue(cob2, dtb3);
        }

        /// <summary>
        /// 将私有对象信息显示到窗体上.
        /// </summary>
        private void showObject()
        {
        }

        public void FormToObject(out string err)
        {
            err = "";
            if (nowObject != null)
            {
                nowObject.AMOUNT = numeAmount.Value;

                nowObject.REMARK = txtComm.Text;
                nowObject.COMPLETE_DATE = date2.Value;
                nowObject.COMPLETE_PALCE = txtPlace.Text;
                nowObject.INVOICE_DATE = date4.Value;
                nowObject.INVOICE_NUM = txtInvoice.Text;

                nowObject.CONVERT_MONEY = numMoney.Value;
                nowObject.CUSTOMER = ucManufacturerSelect1.Text;
                if (cob1.Text.Contains("—"))
                {
                    nowObject.DESCRIPTION = cob1.Text;
                }
                else
                {
                    nowObject.DESCRIPTION = cob1.Text + "—" + cob1.Text; ;
                }

                nowObject.ESTIMATE_AMOUNT = numPre.Value;

                nowObject.OCCURENCY_DATE = date1.Value;
                nowObject.PAYMENT_DATE = date3.Value;
                nowObject.NODE_ID = cob1.SelectedValue.ToString();
                nowObject.CURRENCY_ID = cob2.SelectedValue.ToString();
                nowObject.SHIP_ID = ucShipSelect2.GetId();
                nowObject.APPLICANT = CommonOperation.ConstParameter.UserName;
            }

        }

        #region 保存按钮
        private void SaveButton_Click(object sender, EventArgs e)
        {
            string err = "";

            if (!check(out err))
            {
                return;
            }

            this.FormToObject(out err);      //从界面获取数据到对象中.

            if (ACTUAL_COSTSService.Instance.saveUnit(nowObject, out err))
            {
                MessageBoxEx.Show("保存成功!", "", new MessageBoxButtons(), MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBoxEx.Show("当前对象保存失败,错误原因是:" + err);
                return;
            }
        }
        #endregion

        #region 数据验证
        private bool check(out string err)
        {
            err = "";//ucShipSelect2

            if (String.IsNullOrEmpty(ucShipSelect2.Text))
            {
                MessageBoxEx.Show("船东不能为空!", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (String.IsNullOrEmpty(ucManufacturerSelect1.Text))
            {
                MessageBoxEx.Show("供应商不能为空!", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if ("".Equals(cob2.Text))
            {
                MessageBoxEx.Show("币种不能为空!", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if ("".Equals(cob1.Text))
            {
                MessageBoxEx.Show("科目不能为空!", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cob1.Focus();
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
            //if (string.IsNullOrEmpty(this.txtComm.Text.Trim()))
            //{
            //    MessageBoxEx.Show("费用说明不能为空", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            return true;
        }
        #endregion

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numeAmount_ValueChanged(object sender, EventArgs e)
        {
            if (cob2.SelectedValue == null || cob2.SelectedValue.ToString() == "System.Data.DataRowView" || "" == cob2.SelectedValue.ToString()) return;
            if (cob2.SelectedItem != null && ((DataRowView)cob2.SelectedItem)[1].ToString() == "美元")
            {
                numMoney.Value = numeAmount.Value;
                return;
            }
            string currencyID = cob2.SelectedValue == null ? "" : cob2.SelectedValue.ToString();
            decimal baseAmount = numeAmount.Value;
            decimal toUSDAmount = 0.00M;
            //if (discRate.ContainsKey(currencyID))
            //{
            //    toUSDAmount = decimal.Parse(discRate[currencyID]) * baseAmount;
            //}
            //else
            //{
            //    MessageBoxEx.Show("此币种 -> 美元有效汇率不存在,无法自动计算,请先进行设置(基础数据-货币汇率)!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //liulei-修改-2016/01/07
            string err = string.Empty;
            //按发生日期查询汇率
            decimal rate = CurrencyRateService.Instance.GetOneRateByTime(currencyID, "USD", date1.Value.Date, out err);
            if (rate == 0)
            {
                MessageBoxEx.Show("此币种 -> 美元在" + date1.Value.ToShortDateString() + "的有效汇率不存在,无法自动计算,请先进行设置(基础数据-货币汇率)!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }           
                
            toUSDAmount = rate * baseAmount;
            
            numMoney.Value = toUSDAmount;
        }


        private void cob2_SelectedIndexChanged(object sender, EventArgs e)
        {
            numeAmount_ValueChanged(null, null);

        }
    }
}