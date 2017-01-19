using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseInfo.Objects;
using BaseInfo.DataObject;
namespace BaseInfo.Viewer
{
    public partial class FrmEditOneShipWareHouse : CommonViewer.BaseForm.FormBase
    {
        public bool NeedRetrieve = false;
        public FrmEditOneShipWareHouse()
        {
            InitializeComponent();
        }
        public FrmEditOneShipWareHouse(ShipWareHouse theShipWareHouse)
        {
            ucShipWareHouse1.ChangeData(theShipWareHouse);
            InitializeComponent();
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ucShipWareHouse1.UpdateObject())
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