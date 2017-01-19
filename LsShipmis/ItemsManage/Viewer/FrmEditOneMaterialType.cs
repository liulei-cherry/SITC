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
    public partial class FrmEditOneMaterialType : CommonViewer.BaseForm.FormBase
    {
        public bool NeedRetrieve = false;
        public MaterialType MaterialTypeEdited;
        public FrmEditOneMaterialType()
        {
            InitializeComponent();
        }
        public FrmEditOneMaterialType(MaterialType MaterialType)
        {           
            InitializeComponent();
            ucMaterialType1.ChangeData(MaterialType);
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ucMaterialType1.UpdateObject())
            {
                NeedRetrieve = true;
                MaterialTypeEdited = ucMaterialType1.TheObject;
                this.Close();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}