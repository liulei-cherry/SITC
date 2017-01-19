using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms; 
using CMSManage.DataObject;

namespace CMSManage.Viewer
{
    public partial class FrmEditOneCMSConfig : CommonViewer.BaseForm.FormBase
    {
        public bool NeedRetrieve = false;
        public FrmEditOneCMSConfig()
        {
            InitializeComponent();
        }
        public FrmEditOneCMSConfig(string shipId)
        {
            InitializeComponent();
            ucCMSConfig1.ShipId = shipId;
        }
        public FrmEditOneCMSConfig(CMSConfig theCMSConfig)
        {           
            InitializeComponent();
            ucCMSConfig1.ChangeData(theCMSConfig);
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ucCMSConfig1.UpdateObject())
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