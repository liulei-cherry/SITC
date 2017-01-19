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
    public partial class FrmEditOnePost : CommonViewer.BaseForm.FormBase
    {
        public bool NeedRetrieve = false;
        public FrmEditOnePost()
        {
            InitializeComponent();
        }
        public FrmEditOnePost(Post thePostInfo)
        {
            InitializeComponent();
            ucPost1.ChangeData(thePostInfo);
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ucPost1.UpdateObject())
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