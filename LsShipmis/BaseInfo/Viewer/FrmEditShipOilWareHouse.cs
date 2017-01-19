using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseInfo.Objects;
using BaseInfo.DataAccess;
using CommonViewer.BaseControl;

namespace BaseInfo.Viewer
{
    public partial class FrmEditShipOilWareHouse : CommonViewer.BaseForm.FormBase
    {
        public bool NeedRetrieve = false;
        /// <summary>
        /// 仅船舶端可以调用此方法,因为船舶端的shipid是固定项.
        /// </summary>        
        private FrmEditShipOilWareHouse()
        {
            InitializeComponent();
        }

        public FrmEditShipOilWareHouse(ShipInfo shipInfo)
        {
            InitializeComponent();
            ShipOilWareHouse sw = new ShipOilWareHouse();
            if (shipInfo != null && !shipInfo.IsWrong)
            {
                sw.SHIP_ID = shipInfo.GetId();
            }
            else
            {
                MessageBoxEx.Show("当前界面必须明确修改的是哪条船舶的数据,由于传入船舶信息有误,所以无法进行继续操作!");
                this.Close();
            }
            ucOilWareHouse1.ChangeData(sw);
            ucOilWareHouse1.SetCanEdit(true);
        }
        public FrmEditShipOilWareHouse(ShipOilWareHouse theSchedule)
        {
            InitializeComponent();
            ucOilWareHouse1.ChangeData(theSchedule);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ucOilWareHouse1.UpdateObject())
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