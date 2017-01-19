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
    public partial class FrmEditOneEquipment : CommonViewer.BaseForm.FormBase
    {
        public bool NeedRetrieve = false;
        public ComponentUnit EquipmentEdited;
        public FrmEditOneEquipment()
        {
            InitializeComponent();
        }
        public FrmEditOneEquipment(ComponentUnit equipment)
        {           
            InitializeComponent();
            ucEquipment1.ChangeData(equipment);
            ucEquipment1.SetCanEdit(true); 
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ucEquipment1.UpdateObject())
            {
                NeedRetrieve = true;
                EquipmentEdited = ucEquipment1.TheEquipment;
                this.Close();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}