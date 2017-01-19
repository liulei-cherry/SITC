using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseInfo.Objects;
namespace BaseInfo.Viewer
{
    public partial class FrmEditOneCurrencyRate : CommonViewer.BaseForm.FormBase
    {
        public bool NeedRetrieve = false;
        public FrmEditOneCurrencyRate()
        {
            InitializeComponent();
        }
        public FrmEditOneCurrencyRate(CurrencyRate theObjectInfo)
        {
            InitializeComponent();
            ucCurrencyRate1.ChangeData(theObjectInfo);
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ucCurrencyRate1.UpdateObject())
            {
                NeedRetrieve = true;
                this.Close();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}