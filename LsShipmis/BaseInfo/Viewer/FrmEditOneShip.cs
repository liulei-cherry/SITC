using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseInfo.Objects;
using BaseInfo.DataAccess;

namespace BaseInfo.Viewer
{
    public partial class FrmEditOneShip : CommonViewer.BaseForm.FormBase
    {
        private bool isNewShip = false;
        public bool NeedRetrieve = false;
        public FrmEditOneShip()
        {
            InitializeComponent();
            isNewShip = true;
            ucShipInfo1.ChangeData(new ShipInfo ());
            ucShipInfo1.SetCanEdit(true);
            ucShipInfo1.DisablePictrueAdding();
        }

        public FrmEditOneShip(ShipInfo theSchedule)
        {
            InitializeComponent();
            ucShipInfo1.ChangeData(theSchedule);
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            string err;
            if (!ucShipInfo1.UpdateObject()) return;
            NeedRetrieve = true;
            if(isNewShip)
            {
                ShipInfoService.Instance.InitAShipWithAllRelationInfo(ucShipInfo1.TheObject.GetId(), out err);
            }
            this.Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}