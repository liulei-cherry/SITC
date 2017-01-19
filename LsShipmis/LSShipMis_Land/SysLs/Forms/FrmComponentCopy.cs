using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ItemsManage.DataObject;
using ItemsManage.Services;
using FileOperationBase.Services;
using ItemsManage.Viewer;
using BaseInfo.Objects;
using CommonViewer.BaseControl;
using LSShipMis_Land.SysLs.Services;
using ItemsManage;
using Maintenance.Services;

namespace LSShipMis_Land.SysLs.Forms
{
    public partial class FrmComponentCopy : CommonViewer.BaseForm.BaseMdiChildForm
    {
        private FrmComponentCopy()
        {
            InitializeComponent();
        }
        private CommonOperation.Functions.ProxyRight proxyRight = CommonOperation.Functions.ProxyRight.Instance;//权限代理业务类.

        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static FrmComponentCopy instance = new FrmComponentCopy();
        public static FrmComponentCopy Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmComponentCopy.instance = new FrmComponentCopy();
                }
                return FrmComponentCopy.instance;
            }
        }
        #endregion
        private string currentShipId = "";
        private ComponentUnit component;
        private void FrmComponentManage_Load(object sender, EventArgs e)
        {
            //checkRight();
            //changeButtonState(false);
            ucEquipmentClassTreeWithEquipment1.ReloadingAllData(true);
        }
        /// <summary>
        /// 加载工作信息.
        /// </summary>
        /// <returns></returns>
        private bool LoadWorkInfoData()
        {
            string err = "";
            if (string.IsNullOrEmpty(currentShipId)) return true;
            //加载列表数据.
            string REPROT_TYPE = "";
            DataTable dtbWork;
            if (!T_WORKINFO_HISTORY_OUTService.Instance.GetWorkinfoHistory(currentShipId, dtpAnnual.Value, REPROT_TYPE, out dtbWork, out err))
            {
                MessageBoxEx.Show(err);
                return false;
            }
            dgvWorkInfo.DataSource = dtbWork;

            //工作信息的初始化设置。.
            if (dgvWorkInfo.Rows.Count > 0)
            {
                dgvWorkInfo.CurrentCell = dgvWorkInfo.FirstDisplayedCell;
            }

            //设置列标题.
            Dictionary<string, string> dictColumns = new Dictionary<string, string>();
            dictColumns.Clear();

            dictColumns.Add("WORKINFOCODE", "工作编号");
            dictColumns.Add("COMP_CHINESE_NAME", "保养设备");
            dictColumns.Add("WorkInfoName", "工作名称");
            dictColumns.Add("worker", "责任人");
            dictColumns.Add("CircleOrTiming", "定期/定时");
            dictColumns.Add("WORKINFOSTATE", "工作状态");
            dictColumns.Add("ORDERNUM_SHOW", "序号");
            //dictColumns.Add("MONTHS_CHECK", "月保养");

            dgvWorkInfo.SetDgvGridColumns(dictColumns);
            dgvWorkInfo.Columns["WorkInfoName"].Tag = 0;
            foreach (DataGridViewColumn col in dgvWorkInfo.Columns)
            {
                col.ReadOnly = true;
            }
            //加载网格控件默认的列宽信息.
            dgvWorkInfo.LoadGridView("FrmComponentCopy.dgvWorkInfo");
            return true;
        }
        /// <summary>
        /// 加载工作信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvWorkInfo_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvWorkInfo.CurrentRow != null)
            {
                DataGridViewRow dr = dgvWorkInfo.CurrentRow;
                //加载选中工作的相关工单列表.
                string workInfoID = "";
                if (DBNull.Value != dr.Cells["WorkInfoID"].Value)
                    workInfoID = dr.Cells["WorkInfoID"].Value.ToString();

                LoadWorkOrder(workInfoID);
            }
        }
        /// <summary>
        /// 由单条工作信息，产生的工单列表.
        /// </summary>
        private void LoadWorkOrder(string workInfoID)
        {
            //string err;
            dgvWorkOrder.DataSource = WorkOrderService.Instance.GetWorkOrderForWkInfo(workInfoID);

            //设置列标题.
            Dictionary<string, string> dictColumnsSun = new Dictionary<string, string>();
            dictColumnsSun.Clear();
            dictColumnsSun.Add("workordername", "工单名称");
            dictColumnsSun.Add("circleortimingname", "定期/定时");
            dictColumnsSun.Add("workorderstatename", "工单状态");
            dictColumnsSun.Add("principalpostname", "责任人岗位");
            dictColumnsSun.Add("confirmpostname", "确认人岗位");
            dictColumnsSun.Add("planexedate", "预计执行日期");
            dictColumnsSun.Add("nextvalue", "预计执行表值");
            dgvWorkOrder.SetDgvGridColumns(dictColumnsSun);

            //nzj add subgird columns autosize
            if (dgvWorkOrder.DataSource != null)
            {
                dgvWorkOrder.LoadGridView("FrmComponentCopy.dgvWorkOrder");
            }
        }
        /// <summary>
        /// 年度复制.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnnualCopy_Click(object sender, EventArgs e)
        {
            FrmEquipmentWorkInfoCopy frm = new FrmEquipmentWorkInfoCopy(currentShipId);
            frm.ShowDialog();
            //ucEquipmentClassTreeWithEquipment1.ReloadingAllData(true);
        }
        /// <summary>
        /// 快速定位功能.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FrmSelectComponent frm = new FrmSelectComponent();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                SwitchToEquipment(frm.Equipment);
            }
        }

        public void SwitchToEquipment(string equipmentId)
        {
            string err;
            ComponentUnit equipment = ComponentUnitService.Instance.getObject(equipmentId, out err);
            if (equipment != null)
            {
                ucEquipmentClassTreeWithEquipment1.SelectOneEquipment(equipment);
            }

        }
        public void SwitchToEquipment(ComponentUnit equipment)
        {
            ucEquipmentClassTreeWithEquipment1.SelectOneEquipment(equipment);
        }

        private void btnCompHistory_Click(object sender, EventArgs e)
        {
            if (component == null || component.IsWrong) return;
            if (string.IsNullOrEmpty(component.COMPONENT_UNIT_ID))
            {
                MessageBoxEx.Show("请先保存设备信息", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (ItemsManageConfig.openComponentWorkListForm != null)
                    ItemsManageConfig.openComponentWorkListForm(component);
            }
        }

        private void btnSpareInfo_Click(object sender, EventArgs e)
        {
            if (component == null || component.IsWrong) return;
            if (string.IsNullOrEmpty(component.COMPONENT_UNIT_ID))
            {
                MessageBoxEx.Show("请先保存设备信息", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                FrmSparePreview frm = new FrmSparePreview(component);
                frm.ShowDialog();
            }
        }

        private void btnBdFiles_Click(object sender, EventArgs e)
        {
            if (ucEquipmentClassTreeWithEquipment1.SelectedNode != null && ucEquipmentClassTreeWithEquipment1.SelectedNode.Tag != null)
            {
                if (ucEquipmentClassTreeWithEquipment1.SelectedNode.Tag.GetType() == typeof(ComponentUnit))
                {
                    if (component == null || component.IsWrong) return;
                    if (string.IsNullOrEmpty(component.COMPONENT_TYPE_ID))
                    {
                        MessageBoxEx.Show("当前设备的类型无效,无法查看绑定文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        FileOperation.FileBoundingOperation.Instance.FileBoundOperation();
                    }
                }
                else if (ucEquipmentClassTreeWithEquipment1.SelectedNode.Tag.GetType() == typeof(EquipmentClass))
                {
                    if (string.IsNullOrEmpty(((EquipmentClass)ucEquipmentClassTreeWithEquipment1.SelectedNode.Tag).GetId()))
                    {
                        MessageBoxEx.Show("当前设备分类无效,无法查看绑定文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        FileOperation.FileBoundingOperation.Instance.FileBoundOperation();
                    }
                }
            }

        }

        private ShipInfo findNowShipId()
        {
            TreeNode tn = ucEquipmentClassTreeWithEquipment1.SelectedNode;
            while (tn != null)
            {
                tn = tn.Parent;
                if (tn.Tag != null && tn.Tag.GetType() == typeof(ShipInfo))
                {
                    return (ShipInfo)tn.Tag;
                }
            }
            return null;

        }
        private void dtpAnnual_ValueChanged(object sender, EventArgs e)
        {
            this.LoadWorkInfoData();
        }
        private void ucEquipmentClassTreeWithEquipment1_ItemChanged(object theObject, int objectType)
        {
            component = null;
            FileOperation.FileBoundingOperation.Instance.FileBoundCheck("", "", 0, null);
            switch (objectType)
            {
                case 0:
                    changeButtonState(false);
                    return;
                case 1:
                    changeButtonState(false);
                    currentShipId = ((ShipInfo)theObject).SHIP_ID;
                    this.LoadWorkOrder("");
                    this.LoadWorkInfoData();
                    return;
                case 2:
                    component = (ComponentUnit)theObject;
                    component.FillThisObject();
                    if (component.TheComponentType != null)
                        FileOperation.FileBoundingOperation.Instance.FileBoundCheck(component.TheComponentType.GetId(),
                            component.TheComponentType.ToString(), CommonOperation.Enum.FileBoundingTypes.COMPONENTFILES, null);
                    changeButtonState(true);
                    return;
                case 3:
                    FileOperation.FileBoundingOperation.Instance.FileBoundCheck(((EquipmentClass)theObject).GetId(),
                        ((EquipmentClass)theObject).ToString(), CommonOperation.Enum.FileBoundingTypes.COMPONENTSYSTEMFILES, null);
                    changeButtonState(false);
                    btnBdFiles.Enabled = true;
                    return;
            }

        }

        private void changeButtonState(bool enabled)
        {
            btnSpareInfo.Enabled = enabled;
            buttonEx3.Enabled = enabled;
            btnCompHistory.Enabled = enabled;
            btnBdFiles.Enabled = enabled; 
        }
        /// <summary>
        /// 操作说明.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEx3_Click(object sender, EventArgs e)
        {
            FrmEquipmentOperation frm = new FrmEquipmentOperation();
            frm.Component = component;
            frm.ShowDialog();
        }

        private void FrmComponentManage_FormClosed(object sender, FormClosedEventArgs e)
        {
            FileOperation.FileBoundingOperation.Instance.FileBoundCheck("", "", 0, null);
            dgvWorkInfo.SaveGridView("FrmComponentCopy.dgvWorkInfo");
            dgvWorkOrder.SaveGridView("FrmComponentCopy.dgvWorkOrder");
            instance = null;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}