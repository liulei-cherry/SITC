using System;
using System.Collections.Generic;
using System.Text; 
using ItemsManage.DataObject;

namespace ItemsManage
{
    public class ItemsManageConfig
    {
        //修理历史.
        public delegate void RepairHistory(string componentUnitID);
        public static RepairHistory repairHistory;

        public delegate void SpareInOrOutForm(List<StorageParameter> ids, string remark);
        public delegate void SpareApplyForm(ComponentUnit componentUnit, List<StorageParameter> ids, string remark);

        public static SpareInOrOutForm openSpareInForm;
        public static SpareInOrOutForm openSpareOutForm;
        public static SpareApplyForm openSpareApplyForm;

        public delegate void ComponentWorkListForm(ComponentUnit componentUnit);
        public delegate void EquipmentWorkInfoForm(ComponentUnit componentUnit);
              
        public static ComponentWorkListForm openComponentWorkListForm;
        public static EquipmentWorkInfoForm openEquipmentWorkInfoForm;

        public delegate bool CopyWorkInfosFromOneEquipmentToOther(ComponentUnit from, ComponentUnit to, out string err);
        public static CopyWorkInfosFromOneEquipmentToOther copyWorkInfosFromOneEquipmentToOther;

        public delegate void SpareInshipInfo(string shipId, string spareId);
        public static SpareInshipInfo openSpareInshipInfo;

        public delegate void QuicklyInsertEquipmentByEquipmentType(ComponentType equipmentType);
        public delegate void QuicklyInsertEquipmentByParent(string parentEquipmentUnitId);
        public delegate void QuicklyInsertEquipmentByEquipmentClassAndShipId(EquipmentClass equipmentClass,string shipid);
        public static QuicklyInsertEquipmentByEquipmentType quicklyInsertEquipmentByEquipmentType;
        public static QuicklyInsertEquipmentByParent quicklyInsertEquipmentByParent;
        public static QuicklyInsertEquipmentByEquipmentClassAndShipId quicklyInsertEquipmentByEquipmentClassAndShipId;
    }

    public struct StorageParameter
    {
        public string ItemId;
        public string WarehouseId;
        public decimal Count;
        public string orderCode;
        public string unit_name;
        public decimal stocksall;
    }
}
