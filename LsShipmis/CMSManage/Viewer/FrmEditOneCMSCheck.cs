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
    public partial class FrmEditOneCMSCheck : CommonViewer.BaseForm.FormBase
    {
        public bool NeedRetrieve = false;
        public FrmEditOneCMSCheck()
        {
            InitializeComponent();
        }
        public FrmEditOneCMSCheck(CMSCheck theCMSCheck,bool canEdit)
        {           
            InitializeComponent(); 
            ucCMSCheck1.ChangeData(theCMSCheck);
            ucCMSCheck1.SetCanEdit(canEdit);
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ucCMSCheck1.UpdateObject())
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