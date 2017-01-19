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
    public partial class FrmEditOneDepartment : CommonViewer.BaseForm.FormBase
    {
        public bool NeedRetrieve = false;
        public FrmEditOneDepartment()
        {
            InitializeComponent();
        }
        public FrmEditOneDepartment(Department theDepartmentInfo)
        {           
            InitializeComponent();
            ucDepartment1.ChangeData(theDepartmentInfo);
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ucDepartment1.UpdateObject())
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