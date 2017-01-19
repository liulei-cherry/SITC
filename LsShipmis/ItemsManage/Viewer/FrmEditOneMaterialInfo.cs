using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseInfo.Objects;
using ItemsManage.DataObject;
using ItemsManage.Services;

namespace ItemsManage.Viewer
{
    public partial class FrmEditOneMaterialInfo : CommonViewer.BaseForm.FormBase
    {
        public bool NeedRetrieve = false;
        public MaterialInfo MaterialInfoEdited;
        public FrmEditOneMaterialInfo()
        {
            InitializeComponent();
        }
        public FrmEditOneMaterialInfo(MaterialInfo MaterialInfo)
        {           
            InitializeComponent();
            ucMaterialInfo1.ChangeData(MaterialInfo);
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ucMaterialInfo1.UpdateObject())
            {
                NeedRetrieve = true;
                MaterialInfoEdited = ucMaterialInfo1.TheObject;
                this.Close();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}