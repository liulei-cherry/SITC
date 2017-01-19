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
    public partial class FrmEditOneEquipmentClass : CommonViewer.BaseForm.FormBase
    {
        public bool NeedRetrieve = false;
        public EquipmentClass EquipmentClassEdited;
        public FrmEditOneEquipmentClass()
        {
            InitializeComponent();
        }
        public FrmEditOneEquipmentClass(EquipmentClass equipmentClass)
        {           
            InitializeComponent();
            ucEquipmentClass1.ChangeData(equipmentClass);
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ucEquipmentClass1.UpdateObject())
            {
                NeedRetrieve = true;
                EquipmentClassEdited = ucEquipmentClass1.TheObject;
                this.Close();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}