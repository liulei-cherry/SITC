using System;
using System.Collections.Generic;
using System.Text;
using ItemsManage;
using Maintenance.Viewer;
using ItemsManage.DataObject;
using StorageManage.Viewer;
using ItemsManage.Viewer;
using ItemsManage.Services;
using Maintenance.Services;
using System.Data;

namespace Maintenance
{
    public enum CIRCLEPERIOD
    {
        YEAR = 1,
        MONTH = 2,
        DAY = 3,
    }
    public class MaintenanceConfig
    {
        #region 外部调用委托
        //月度完成情况的客户化实现.
        public delegate bool CustomMonthlyCompleteReport(string shipId, int year, int month, List<string> lstPost, int departmentType, out string err);
        public static CustomMonthlyCompleteReport customMonthlyCompleteReport;
        public delegate void SpareApplyForm(ComponentUnit componentUnit, List<StorageParameter> ids, string remark);
        public static SpareApplyForm openSpareApplyForm;
        public delegate bool ReinitializeCollect(string equipmentID, double initialHours, out string err);
        public static ReinitializeCollect reinitializeCollect;
        public delegate bool GetTotalHours(string equipmentID, out double nowTotalHours, out string err);
        public static GetTotalHours getTotalHours;
        #endregion

        #region 外部调用的窗体打开函数
        public static void fopenQuicklyInsertEquipment(ComponentType equipmentType)
        {
            FrmQuicklyInsertEquipment frm = new FrmQuicklyInsertEquipment(equipmentType);
            frm.ShowDialog();
        }

        public static void fopenQuicklyInsertEquipment(string parentEquipmentUnitId)
        {
            FrmQuicklyInsertEquipment frm = new FrmQuicklyInsertEquipment(parentEquipmentUnitId);
            frm.ShowDialog();
        }
        public static void fopenQuicklyInsertEquipment(EquipmentClass equipmentClass, string shipid)
        {
            FrmQuicklyInsertEquipment frm = new FrmQuicklyInsertEquipment(equipmentClass.CLASSID, shipid);
            frm.ShowDialog();
        }
        public static void fopenSpareApplyForm(ComponentUnit componentUnit, List<StorageParameter> ids, string remark)
        {
            FrmSparePurchaseApplyEdit frm = new FrmSparePurchaseApplyEdit(componentUnit, ids, remark);
            frm.ShowDialog();
        }

        #endregion

        #region 几个委托的实现

        public static void MaintenanceInitConfig()
        {
            ItemsManage.ItemsManageConfig.openComponentWorkListForm = new ItemsManageConfig.ComponentWorkListForm(openComponentWorkListForm);
            ItemsManage.ItemsManageConfig.openEquipmentWorkInfoForm = new ItemsManageConfig.EquipmentWorkInfoForm(openEquipmentWorkInfoForm);
            openSpareApplyForm = new SpareApplyForm(fopenSpareApplyForm);
            ItemsManage.ItemsManageConfig.quicklyInsertEquipmentByEquipmentType = new ItemsManageConfig.QuicklyInsertEquipmentByEquipmentType(fopenQuicklyInsertEquipment);
            ItemsManage.ItemsManageConfig.quicklyInsertEquipmentByParent = new ItemsManageConfig.QuicklyInsertEquipmentByParent(fopenQuicklyInsertEquipment);
            ItemsManage.ItemsManageConfig.quicklyInsertEquipmentByEquipmentClassAndShipId = new ItemsManageConfig.QuicklyInsertEquipmentByEquipmentClassAndShipId(fopenQuicklyInsertEquipment);
            ItemsManage.ItemsManageConfig.copyWorkInfosFromOneEquipmentToOther = new ItemsManageConfig.CopyWorkInfosFromOneEquipmentToOther(copyWorkInfosFromOneEquipmentToOther);
        }
        private static bool copyWorkInfosFromOneEquipmentToOther(ComponentUnit from, ComponentUnit to, out string err)
        {
            return WorkInfoService.Instance.CopyWorkInfosFromOneEquipmentToOther(from, to, out err);
        }
        public static void openComponentWorkListForm(ComponentUnit componentUnit)
        {
            FrmComponentWorkList frm = new FrmComponentWorkList(componentUnit);
            frm.ShowDialog();
        }

        public static void openEquipmentWorkInfoForm(ComponentUnit componentUnit)
        {
            FrmEquipmentWorkInfo frm = new FrmEquipmentWorkInfo(componentUnit);
            frm.ShowDialog();
        }
        #endregion

    }
}
