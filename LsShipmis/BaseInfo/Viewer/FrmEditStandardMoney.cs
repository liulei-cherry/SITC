using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseInfo.DataAccess;
using CommonViewer.BaseControlService;
using CommonViewer.BaseControl;

namespace BaseInfo.Viewer
{
    public partial class FrmEditStandardMoney : CommonViewer.BaseForm.FormBase
    {
        private FormControlOption other = FormControlOption.Instance;
        public FrmEditStandardMoney()
        {
            InitializeComponent();

            string err;
            //记账本位币.
            DataTable dtb3 = CurrencyService.Instance.getInfo(out err);
            other.SetComboBoxValue(cboStandardMoney, dtb3);

            cboStandardMoney.Text = ArgumentSetService.Instance.chk_GetDefaultCurrency("SetDefaultCurrency");
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string err;
            if (ArgumentSetService.Instance.chk_HaveDefaultCurrency("SetDefaultCurrency", out err))
            {
                ArgumentSetService.Instance.chk_UpdateDefaultCurrency(cboStandardMoney.Text, "SetDefaultCurrency", out err);
            }
            else
            {
                if (err.Length == 0)
                {
                    ArgumentSetService.Instance.chk_InsertDefaultCurrency(cboStandardMoney.Text, out err);
                }
            }

            if (err.Length > 0)
            {
                MessageBoxEx.Show("默认本位币修改或设置失败,错误原因:" + err);
            }
            else
                this.Close();
        }
    }
}
