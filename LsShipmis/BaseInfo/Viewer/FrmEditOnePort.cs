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
    public partial class FrmEditOnePort : CommonViewer.BaseForm.FormBase
    {
        public bool NeedRetrieve = false;
        public FrmEditOnePort()
        {
            InitializeComponent();
        }
        public FrmEditOnePort(PortInfo thePortInfo)
        {
            ucport1.ChangeData(thePortInfo);
            InitializeComponent();
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ucport1.UpdateObject())
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