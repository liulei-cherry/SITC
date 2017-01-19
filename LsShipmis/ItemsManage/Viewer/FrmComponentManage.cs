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

namespace ItemsManage.Viewer
{
    public partial class FrmComponentManage : CommonViewer.BaseForm.BaseMdiChildForm
    {
        private FrmComponentManage()
        {
            InitializeComponent();
        }
        private CommonOperation.Functions.ProxyRight proxyRight = CommonOperation.Functions.ProxyRight.Instance;//权限代理业务类.
        private bool CanEdit = false;
        string sChkMessage = "";
        #region 构造函数

        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static FrmComponentManage instance = new FrmComponentManage();
        public static FrmComponentManage Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmComponentManage.instance = new FrmComponentManage();
                }
                return FrmComponentManage.instance;
            }
        }
        #endregion
        private ComponentUnit component;
        private void FrmComponentManage_Load(object sender, EventArgs e)
        {
            checkRight();
            changeButtonState(false);
            ucEquipmentClassTreeWithEquipment1.ReloadingAllData();
        }
        private void 保存SToolStripButton_Click(object sender, EventArgs e)
        {
            if (CanEdit && ucEquipment1.Visible == true)
            {
                if (ucEquipment1.UpdateObject())
                {
                    ucEquipmentClassTreeWithEquipment1.RefreshOneNode(ucEquipmentClassTreeWithEquipment1.SelectedNode);
                }
            }
        }

        /// <summary>
        /// 添加操作,修改完毕.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 新建NToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                EquipmentClass thisEquipmentClass = null;
                if (CanEdit)
                {
                    ComponentUnit toAdd = new ComponentUnit();
                    if (ucEquipmentClass1.Visible)
                    {
                        thisEquipmentClass = ucEquipmentClass1.TheObject;
                        ShipInfo shipInfo = findNowShipId();
                        string err;
                        ComponentUnit shipObj = ComponentUnitService.Instance.GetObjectByRootAndShipId(shipInfo.GetId(), out err);
                        if (shipObj != null)
                        {
                            toAdd.PARENT_UNIT_ID = shipObj.GetId();
                            toAdd.SHIP_ID = shipInfo.GetId();
                        }
                        else throw new Exception("获取当前设备所在船舶失败,不能添加设备!");
                    }
                    else if (ucEquipment1.Visible && component != null && !component.IsWrong)
                    {
                        toAdd.PARENT_UNIT_ID = component.GetId();
                        toAdd.SHIP_ID = component.SHIP_ID;
                    }
                    else if (ucShipInfo1.Visible)
                    {
                        ShipInfo shipInfo = findNowShipId();
                        string err;
                        ComponentUnit shipObj = ComponentUnitService.Instance.GetObjectByRootAndShipId(shipInfo.GetId(), out err);
                        if (shipObj != null)
                        {
                            toAdd.PARENT_UNIT_ID = shipObj.GetId();
                            toAdd.SHIP_ID = shipInfo.GetId();
                        }
                        else throw new Exception("获取当前设备所在船舶失败,不能添加设备!");
                    }
                    else throw new Exception("发生未预期的错误");
                    FrmEditOneEquipment frm = new FrmEditOneEquipment(toAdd);
                    frm.ShowDialog();
                    if (frm.NeedRetrieve)
                    {
                        #region 如果存在分类代码,则把设备安排到分类下
                        string err;
                        if (thisEquipmentClass != null)
                            ItemsManage.Services.EquipmentClassService.Instance.ClassifyEquipmentToClass(thisEquipmentClass.GetId(), frm.EquipmentEdited.GetId(), frm.EquipmentEdited.SHIP_ID, out err);
                        #endregion
                        ucEquipmentClassTreeWithEquipment1.RefreshOneNode(ucEquipmentClassTreeWithEquipment1.SelectedNode);
                    }
                }
                else throw new Exception("当前用户不具备添加设备的权限!");
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message);
            }
        }

        /// <summary>
        /// 删除操作,修改完毕.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (component == null || !component.IsWrong && component.GetId() == null)
            {
                if (ucEquipmentClassTreeWithEquipment1.SelectedNode != null)
                    ucEquipmentClassTreeWithEquipment1.RefreshOneNode(ucEquipmentClassTreeWithEquipment1.SelectedNode.Parent);
                return;
            }
            if (string.IsNullOrEmpty(component.PARENT_UNIT_ID))
            {
                MessageBoxEx.Show("不允许删除最高级结点");
                return;
            }
            if (!CanEdit || MessageBoxEx.Show("是否删除当前设备", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            string err;
            if (!ComponentUnitService.Instance.oneEquipmentCanBeDeleted(component, out err))
            {
                if (MessageBoxEx.Show(err + "\r是否彻底删除设备相关的所有信息?\rComplete delete this equipment and it's sub items?"
                    , "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
            }
            if (component.CompletelyDelete(out err))
            {
                if (ucEquipmentClassTreeWithEquipment1.SelectedNode != null)
                {
                    ucEquipmentClassTreeWithEquipment1.RefreshOneNode(ucEquipmentClassTreeWithEquipment1.SelectedNode.Parent);
                }
            }
            else
            {
                MessageBoxEx.Show("删除失败,当前设备或其下级设备已被某业务使用,不能删除!\r更多信息请参考:" + err);
            }

        }

        private void FrmComponentManage_FormClosed(object sender, FormClosedEventArgs e)
        {
            FileOperation.FileBoundingOperation.Instance.FileBoundCheck("", "", 0, null);
            instance = null;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void checkRight()
        {
            CanEdit = proxyRight.CheckRight(CommonOperation.ConstParameter.EQUIPMENT_EDIT, out sChkMessage);
            buttonEx2.Enabled = CanEdit;
            AddButton.Enabled = CanEdit;
            btnClone.Enabled = CanEdit;
            deleteButton.Enabled = CanEdit;
            SaveButton.Enabled = CanEdit;
            buttonEx1.Enabled = CanEdit;
            btnWorkInfoEdit.Enabled = CanEdit;
        }

        private void btnWorkInfoEdit_Click(object sender, EventArgs e)
        {
            if (component == null || component.IsWrong) return;
            if (string.IsNullOrEmpty(component.COMPONENT_UNIT_ID))
            {
                MessageBoxEx.Show("请先保存设备信息", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (ItemsManageConfig.openEquipmentWorkInfoForm != null)
                    ItemsManageConfig.openEquipmentWorkInfoForm(component);
            }
        }

        private void buttonEx1_Click(object sender, EventArgs e)
        {
            if (component == null || component.IsWrong) return;
            if (string.IsNullOrEmpty(component.COMPONENT_TYPE_ID))
            {
                MessageBoxEx.Show("当前设备型号为空,无法维护备件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                component.FillThisObject();
                FrmSpareForEquipType frm = new FrmSpareForEquipType(component.TheComponentType);
                frm.ShowDialog();
            }
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
                if (tn.Tag != null && tn.Tag.GetType() == typeof(ShipInfo))
                {
                    return (ShipInfo)tn.Tag;
                }
                tn = tn.Parent;
            }
            return null;

        }
        /// <summary>
        /// 快速导入功能.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEx2_Click(object sender, EventArgs e)
        {
            TreeNode tn = ucEquipmentClassTreeWithEquipment1.SelectedNode;
            if (ItemsManageConfig.quicklyInsertEquipmentByEquipmentClassAndShipId != null && ucEquipmentClass1.Visible)
            {
                ShipInfo shipInfo = findNowShipId();
                if (shipInfo != null)
                    ItemsManageConfig.quicklyInsertEquipmentByEquipmentClassAndShipId
                        ((EquipmentClass)ucEquipmentClassTreeWithEquipment1.SelectedNode.Tag, shipInfo.GetId());
            }
            else if (ItemsManageConfig.quicklyInsertEquipmentByParent != null)
            {
                if (tn.Tag != null && tn.Tag.GetType() == typeof(ComponentUnit))
                {
                    component = (ComponentUnit)tn.Tag;
                    ItemsManageConfig.quicklyInsertEquipmentByParent(component.GetId());
                }
                else if (tn.Tag != null && tn.Tag.GetType() == typeof(ShipInfo))
                {
                    string err;
                    ItemsManageConfig.quicklyInsertEquipmentByParent(ComponentUnitService.Instance.GetObjectByRootAndShipId(((ShipInfo)tn.Tag).SHIP_ID, out err).GetId());
                }
                else
                {
                    MessageBoxEx.Show("必须在指定设备的下级建立,当前未选择具体设备,无法完成操作");
                    return;
                }
            }
            else
            {
                MessageBoxEx.Show("未对快速初始化功能进行设置,请速与开发商联系,\r可能是程序版本不对应");
            }
            try
            {
                ucEquipmentClassTreeWithEquipment1.RefreshOneNode(ucEquipmentClassTreeWithEquipment1.SelectedNode);
            }
            catch
            {
                //此处不捕获错误.
            }
        }

        private void ucEquipmentClassTreeWithEquipment1_ItemChanged(object theObject, int objectType)
        {
            component = null;
            FileOperation.FileBoundingOperation.Instance.FileBoundCheck("", "", 0, null);
            ucEquipment1.Visible = false;
            gbEquipmentClass.Visible = false;
            ucShipInfo1.Visible = false;
            switch (objectType)
            {
                case 0:
                    changeButtonState(false);
                    return;
                case 1:
                    ucShipInfo1.ChangeData((ShipInfo)theObject);
                    ucShipInfo1.SetCanEdit(false);
                    ucShipInfo1.Visible = true;
                    changeButtonState(false);
                    buttonEx2.Enabled = true;
                    return;
                case 2:
                    ucEquipment1.ChangeData((ComponentUnit)theObject);
                    ucEquipment1.Visible = true;
                    component = (ComponentUnit)theObject;
                    component.FillThisObject();
                    if (component.TheComponentType != null)
                        FileOperation.FileBoundingOperation.Instance.FileBoundCheck(component.TheComponentType.GetId(),
                            component.TheComponentType.ToString(), CommonOperation.Enum.FileBoundingTypes.COMPONENTFILES, null);
                    ucEquipment1.SetCanEdit(CanEdit);
                    changeButtonState(true);
                    return;
                case 3:
                    gbEquipmentClass.Visible = true;
                    ucEquipmentClass1.ChangeData((EquipmentClass)theObject);
                    FileOperation.FileBoundingOperation.Instance.FileBoundCheck(((EquipmentClass)theObject).GetId(),
                        ((EquipmentClass)theObject).ToString(), CommonOperation.Enum.FileBoundingTypes.COMPONENTSYSTEMFILES, null);
                    changeButtonState(false);
                    buttonEx2.Enabled = true;
                    btnBdFiles.Enabled = true;
                    return;
            }
        }

        private void changeButtonState(bool enabled)
        {
            buttonEx2.Enabled = enabled;
            deleteButton.Enabled = enabled;
            SaveButton.Enabled = enabled;
            buttonEx1.Enabled = enabled;
            btnSpareInfo.Enabled = enabled;
            buttonEx3.Enabled = enabled;
            btnCompHistory.Enabled = enabled;
            btnWorkInfoEdit.Enabled = enabled;
            btnBdFiles.Enabled = enabled;
            if (enabled) checkRight();
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

        private void buttonEx4_Click(object sender, EventArgs e)
        {
            //clone当前设备到一个新的位置,命新名,设备型号不变.
            if (component != null && !component.IsWrong)
            {
                FrmCloneEquipment frm = new FrmCloneEquipment(component);
                frm.ShowDialog();
                if (ucEquipmentClassTreeWithEquipment1.SelectedNode != null && ucEquipmentClassTreeWithEquipment1.SelectedNode.Parent != null)
                {
                    ucEquipmentClassTreeWithEquipment1.RefreshOneNode(ucEquipmentClassTreeWithEquipment1.SelectedNode.Parent);
                }
            }
        }
    }
}