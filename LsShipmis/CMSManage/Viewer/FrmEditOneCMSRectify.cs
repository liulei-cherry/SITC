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
    public partial class FrmEditOneCMSRectify : CommonViewer.BaseForm.FormBase
    {
        public bool NeedRetrieve = false;
        public FrmEditOneCMSRectify()
        {
            InitializeComponent();
        }
        public FrmEditOneCMSRectify(CMSRectify theCMSRectify, bool canEdit)
        {
            InitializeComponent();
            if (theCMSRectify.RECTIFY_STATE == 2) SaveButton.Visible = false;
            ucCMSRectify1.ChangeData(theCMSRectify);
            ucCMSRectify1.SetCanEdit(canEdit);
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ucCMSRectify1.UpdateObject())
            {
                NeedRetrieve = true;
                this.Close();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEx2_Click(object sender, EventArgs e)
        {
            if (ucCMSRectify1.RectifyObject())
            {
                NeedRetrieve = true;
                this.Close();
            }
        }
    }
}