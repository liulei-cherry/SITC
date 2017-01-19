using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ItemsManage.Services;
using ItemsManage.DataObject;
using CommonViewer;
using CommonViewer.BaseControlService;
using CommonViewer.BaseControl;
using CommonViewer.BaseForm;
using BaseInfo.Objects;
using BaseInfo.DataAccess;
namespace ItemsManage.Viewer
{
    public partial class FrmSelectComponent : FormBase
    {
        public FrmSelectComponent()
        {
            InitializeComponent();
            ucEquipmentClassTreeWithEquipment1.OneShipMode = (ship != null);
            BeforeLoad();
        }
        public FrmSelectComponent(string shipid)
        {
            InitializeComponent();
            ucEquipmentClassTreeWithEquipment1.OneShipMode = (ship != null);
            string err;
            ship = ShipInfoService.Instance.getObject(shipid, out err);
            BeforeLoad();
        }
        private void BeforeLoad()
        {
            if (ship != null && !ship.IsWrong)
            {
                ucShipSelect1.ChangeSelectedState(true, false);
                ucShipSelect1.SelectedId(ship.GetId());
                ucShipSelect1.Enabled = false;
                ucEquipmentClassTreeWithEquipment1.ReloadingShipData(ship);
            }
            else
            {
                ucShipSelect1.ChangeSelectedState(true, true);
                ucShipSelect1.Enabled = true;
                ucEquipmentClassTreeWithEquipment1.ReloadingAllData();
            }
        }
        private ShipInfo ship = null;

        private ComponentUnit componentUnit;
        public ComponentUnit Equipment
        {
            get { return componentUnit; }
        }

        private void FrmSelectComponent_Load(object sender, EventArgs e)
        {

            txtSelect.Focus();
        }

        void ucObjectsGridView1_UserDoubleClick(int rowIndex)
        {
            btnOk_Click(this, null);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (txtSelect.Text.Trim().Equals(""))
            {
                MessageBoxEx.Show("请输入要查询设备中文或英文名！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string shipId = ucShipSelect1.GetId();

            DataTable dtb = ComponentUnitService.Instance.GetComponentByName(txtSelect.Text, true, string.IsNullOrEmpty(shipId) ? "" : shipId);
            if (dtb.Rows.Count > 0)
            {
                dgvSelect.Init(dtb, ComponentUnitService.Instance, "FrmSelectComponent");
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ucEquipmentClassTreeWithEquipment1.SelectedNode != null && ucEquipmentClassTreeWithEquipment1.SelectedNode.Tag != null
                && ucEquipmentClassTreeWithEquipment1.SelectedNode.Tag.GetType() == typeof(ComponentUnit))
            {
                componentUnit = (ComponentUnit)ucEquipmentClassTreeWithEquipment1.SelectedNode.Tag;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            //btnSelect_Click(null, null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            componentUnit = null;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        void ucObjectsGridView1_TheObjectChanged(CommonOperation.BaseClass.CommonClass theNewObject)
        {
            if (theNewObject != null && !theNewObject.IsWrong)
            {
                componentUnit = (ComponentUnit)theNewObject;
                ucEquipmentClassTreeWithEquipment1.SelectOneEquipment(componentUnit);
            }
            else
            {
                componentUnit = null;
            }
        }

        private void FrmSelectComponent_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvSelect.SaveDataGridView();
        }

        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            if (txtSelect.Text != "请输入要查询的设备中文名或英文名！" && txtSelect.Text.Length > 0)
            {
                btnSelect_Click(null, null);
            }
        }

        private void txtSelect_Enter(object sender, EventArgs e)
        {
            if (txtSelect.Text == "请输入要查询的设备中文名或英文名！") txtSelect.Text = "";
        }

        private void txtSelect_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) btnSelect_Click(sender, null);
        }
        #region 拖动语法
        bool mouseselect = false;
        int lastx;
        int lasty;

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            if (mouseselect == false && e.Button == MouseButtons.Left)
            {
                mouseselect = true;
                lastx = e.X;
                lasty = e.Y;
            }
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            mouseselect = false;
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            if (mouseselect)
            {
                Point p = this.Location;
                p.Offset(e.X - lastx, e.Y - lasty);
                this.Location = p;
                lastx = e.X;
                lasty = e.Y;
            }
            mouseselect = false;
        }
        #endregion

        public void SelectEquipmentByInfo(string whichInfo)
        {
            txtSelect.Text = whichInfo;
            btnSelect_Click(null, null);
        }
    }
}