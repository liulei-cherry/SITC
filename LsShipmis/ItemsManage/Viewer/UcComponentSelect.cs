using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ItemsManage.DataObject;
using ItemsManage.Services;

namespace ItemsManage.Viewer
{
    public partial class UcComponentSelect : UserControl
    {
        private bool canEdit = true;
        [Browsable(true), Category("用户自定义区域"), Description("是否可以编辑,控制选择按钮的可操作性.")]
        public bool CanEdit
        {
            get { return canEdit; }
            set
            {
                canEdit = value;
                btnSelect.Enabled = value;
                btnSelect.Visible = value;
            }
        }
        string valueId = "";
        string shipId = CommonOperation.ConstParameter.ShipId;

        public string ShipId
        {
            get { return shipId; }
            set { shipId = value; }
        }
        public UcComponentSelect()
        {
            InitializeComponent();
            ChangeShip("", shipId);
        }

        public UcComponentSelect(string componentId, string shipId)
        {
            InitializeComponent();
            ChangeShip(componentId, shipId, true);
        }

        public void ChangeShip(string componentId, string shipId, bool canEdit = true)
        {            
            SelectedId(componentId);
            this.shipId = shipId;
            CanEdit = canEdit;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            FrmSelectComponent frm = new FrmSelectComponent(shipId);
            frm.SelectEquipmentByInfo(txtEquipmentName.Text);
            frm.ShowDialog();
         
            if (frm.Equipment != null) SelectedId(frm.Equipment);
        }

        public string GetId()
        {
            return valueId;
        }

        public void SelectedId(string componentId)
        {
            SelectedId((ComponentUnit)ComponentUnitService.Instance.GetOneObjectById(componentId));
        }

        public string GetText()
        {
            return string.IsNullOrEmpty(valueId) ? "" : txtEquipmentName.Text;
        }

        private void SelectedId(ComponentUnit whichEquipment)
        {
            if (whichEquipment == null || whichEquipment.IsWrong)
            {
                valueId = "";
                shipId = "";
                txtEquipmentName.Text = "未选择设备";
            }
            else
            {
                valueId = whichEquipment.GetId();
                shipId = whichEquipment.SHIP_ID;
                txtEquipmentName.Text = whichEquipment.COMP_CHINESE_NAME;
            }
            if (!string.IsNullOrEmpty(valueId))
            {
                if (TheSelectedChanged != null)
                {
                    TheSelectedChanged(valueId);
                }
            }
        }

        #region 向外抛事件，说明数据变化
        /// <summary>
        /// 所选的内容变化后调用的委托,传出的值是当前选择的id
        /// </summary>
        /// <param name="theSelectedObject"></param>
        public delegate void ObjectChanged(string theSelectedObject);

        public event ObjectChanged TheSelectedChanged;
        #endregion
    }
}
