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
    public partial class FrmEditOneCurrency : CommonViewer.BaseForm.FormBase
    {
        public bool NeedRetrieve = false;
        public FrmEditOneCurrency()
        {
            InitializeComponent();
        }
        public FrmEditOneCurrency(Currency theCurrencyInfo)
        {
            ucCurrency1.ChangeData(theCurrencyInfo);
            InitializeComponent();
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ucCurrency1.UpdateObject())
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