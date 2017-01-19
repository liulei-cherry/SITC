using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CommonOperation.Interfaces;
using BaseInfo.DataAccess;
using BaseInfo.Objects;
using CommonOperation.BaseClass;
using System.IO;
using Microsoft.Win32;
using System.Data.SqlClient;
using CommonOperation.Functions;
using FileOperationBase.FileServices;
using CommonViewer.BaseControl;
using CommonViewer.BaseControlService;

namespace BaseInfo.Viewer
{
    public partial class UcCurrencyRate : UserControl, IOneObjectViewer
    {
        public bool needRetrieve = false;
        CurrencyRate theObject = new CurrencyRate();
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();

        #region 其它公共业务类


        private FormControlOption other = FormControlOption.Instance;

        #endregion

        public CurrencyRate TheObject
        {
            get
            {
                string err;
                SetObject(out err);
                return theObject;
            }
        }

        public UcCurrencyRate()
        {
            InitializeComponent();

            setComboBox();                 //设置窗体所需的下拉列表框的数据源.
        }

        private void UcCurrencyRate_Load(object sender, EventArgs e)
        {

            txtExchange.Text = ArgumentSetService.Instance.chk_GetDefaultCurrency("SetDefaultCurrency");
            txtExchange.Tag = CurrencyService.Instance.GetByName(txtExchange.Text).Rows[0]["CURRENCYID"].ToString();
        }

        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {
            string err = "";

            //基准货币.
            DataTable dtb1 = CurrencyService.Instance.getInfo(out err);
            other.SetComboBoxValue(cob1, dtb1);
        }

        #region IOneObjectViewer 成员
        public void ChangeData(CommonClass toChangeData)
        {
            if (!toChangeData.EqualTo(theObject))
            {
                DirectlyChangeData(toChangeData);
            }
        }
        public void DirectlyChangeData(CommonClass toChangeData)
        {
            theObject = (CurrencyRate)toChangeData;
            if (theObject != null)
            {
                SetCanEdit(true);

                cob1.SelectedValue = theObject.BASECURRENCY;
                numRate.Value = theObject.EXCHANGERATE;
                date1.Value = theObject.USEFULDATEFROM;
                date2.Value = theObject.USEFULDATEEND;
                rdo1.Checked = theObject.ISUSEFULL == 1 ? true : false;
                rdo2.Checked = theObject.ISUSEFULL == 0 ? true : false;
                txtRemark.Text = theObject.REMARK;
                string err;
                Currency currency = CurrencyService.Instance.getObject(theObject.EXCHANGECURRENCY, out err);
                txtExchange.Text = currency.CURRENCYNAME;
                txtExchange.Tag = theObject.EXCHANGECURRENCY;
            }
            else
            {
                ClearData();
                SetCanEdit(false);
            }
        }

        public void ClearData()
        {
            theObject = new CurrencyRate();

            numRate.Value = 1;
            date1.Value = DateTime.Now;
            date2.Value = DateTime.Now;
            rdo1.Checked = true;
            txtRemark.Text = "";
        }

        public bool SetObject(out string err)
        {
            err = "";
            if (theObject != null)
            {
                theObject.BASECURRENCY = cob1.SelectedValue.ToString();
                theObject.EXCHANGERATE = numRate.Value;
                theObject.EXCHANGECURRENCY = txtExchange.Tag.ToString();
                theObject.USEFULDATEFROM = new DateTime(date1.Value.Year, date1.Value.Month, date1.Value.Day, 0, 0, 1);
                theObject.USEFULDATEEND = new DateTime(date2.Value.Year, date2.Value.Month, date2.Value.Day, 23, 59, 59);
                theObject.ISUSEFULL = rdo1.Checked ? 1 : 0;
                theObject.REMARK = txtRemark.Text;
                return true;
            }
            else
            {
                err = "没有对应的数据！";
            }
            return false;
        }

        public void SetCanEdit(bool canEdit)
        {
            cob1.Enabled = canEdit;
            numRate.Enabled = canEdit;
            date1.Enabled = canEdit;
            date2.Enabled = canEdit;
            rdo1.Enabled = canEdit;
            txtRemark.Enabled = canEdit;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public void DeleteObject()
        {
            if (theObject.IsWrong || string.IsNullOrEmpty(theObject.GetId()))
            {
                MessageBoxEx.Show("当前对象无效,不能删除!");
            }
            else
            {
                string err;
                DialogResult response = MessageBoxEx.Show("您确定要删除该条数据吗？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (response == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
                if (CurrencyRateService.Instance.deleteUnit(theObject.GetId(), out err))
                {
                    MessageBoxEx.Show("删除成功");
                    needRetrieve = true;
                }
                else
                {
                    MessageBoxEx.Show("当前对象删除失败,错误原因是:\n\n" + err);
                }
            }
        }
        public bool UpdateObject()
        {
            string err;
            if (!SetObject(out err)) return false;
            
            if (theObject == null)
            {
                MessageBoxEx.Show("当前对象无效,不能保存!");
                return false;
            }
            else
            {

                if (string.IsNullOrEmpty(theObject.BASECURRENCY))
                {
                    MessageBoxEx.Show("标准货币为必填项");
                    cob1.Focus();
                    return false;
                }
                //liulei-2015/11/10-更新前的验证
                if (!SaveValidation()) { return false; }
                if (!theObject.Update(out err))
                {
                    MessageBoxEx.Show("当前对象保存失败,错误原因是:" + err);
                    return false;
                }
            }
            MessageBoxEx.Show("保存成功!");
            return true;
        }

        #region 保存前的验证-liulei-2015/11/10
        /// <summary>
        /// 保存前的验证.
        /// </summary>
        /// <returns></returns>
        private bool SaveValidation()
        {
            //起始日期校验
            if (theObject.USEFULDATEFROM > theObject.USEFULDATEEND)
            {
                MessageBoxEx.Show("起始日期不能晚于结束日期，请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                date1.Focus();
                return false;
            }
            //日期是否重复
            //theObject.USEFULDATEFROM;
            string err = string.Empty;
            Currency currObj = CurrencyService.Instance.getObject(theObject.EXCHANGECURRENCY, out err);

            //起始日期查询
            DataTable dt;
            if (string.IsNullOrEmpty(theObject.RATEID))
            {
                dt = CurrencyRateService.Instance.GetRateByTime(theObject.BASECURRENCY, 
                    currObj.CURRENCYCODE, theObject.USEFULDATEFROM, out err);
            }
            else
            {
                dt = CurrencyRateService.Instance.GetOtherRateByTime(theObject.BASECURRENCY, 
                    currObj.CURRENCYCODE, theObject.USEFULDATEFROM, theObject.RATEID, out err);
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                MessageBoxEx.Show("起始日期与已有时段重复，请重新输入","提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                date1.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(theObject.RATEID))
            {
                dt = CurrencyRateService.Instance.GetRateByTime(theObject.BASECURRENCY,
                    currObj.CURRENCYCODE, theObject.USEFULDATEEND, out err);
            }
            else
            {
                dt = CurrencyRateService.Instance.GetOtherRateByTime(theObject.BASECURRENCY,
                    currObj.CURRENCYCODE, theObject.USEFULDATEEND, theObject.RATEID, out err);
            }

            if (dt != null && dt.Rows.Count > 0)
            {
                MessageBoxEx.Show("结束日期与已有时段重复，请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                date2.Focus();
                return false;
            }

            return true;
        }
        #endregion
    }
}
