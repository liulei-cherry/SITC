using System;
using System.Collections.Generic;
using System.Text;
using ItemsManage;
using ItemsManage.DataObject;

using StorageManage.Viewer;
using StorageManage.Services;
using System.Data;

namespace StorageManage
{
    public class StorageConfig
    {
        public static bool StorageChangeNeedShipCheck = true;
        public static bool StorageChangeNeedLandCheck = true; 

        public static bool StorageStorageCheckNeedLandView = false;

        //备件物料申请的客户化实现.
        public delegate bool CustomSpareApplyPrint(string applyId, string path, out string err);
        public static CustomSpareApplyPrint customSpareApplyPrint;
        public delegate bool CustomMaterialApplyPrint(string applyId, string path, out string err);
        public static CustomMaterialApplyPrint customMaterialApplyPrint;

        //备件物料采购申请的客户化实现.
        public delegate bool CustomItemPurchaseApplyPrint(string applyId, out string err);
        public static CustomItemPurchaseApplyPrint customSparePurchaseApplyPrint;
        public static CustomItemPurchaseApplyPrint customMaterialPurchaseApplyPrint;

        //// add by lip:解决物质采购询价中的DB读取问题
        //public delegate bool CustomItemEnquiryPrint(string businessId, out string err);
        //public static CustomItemEnquiryPrint customMaterialEnquiryPrint;

        public delegate bool CustomItemPurchaseAskPricePrint(string applyId, out string err);
        public static CustomItemPurchaseAskPricePrint customSparePurchaseAskPricePrint;
        public static CustomItemPurchaseAskPricePrint customMaterialPurchaseAskPricePrint;

        public delegate bool GetMaterialCostMapping(string id, out string mapping, out string name, out string err);
        public static GetMaterialCostMapping getMaterialCostMapping;
        public delegate bool GetSpareCostMapping(string shipID, string id, out string mapping, out string name, out string err);
        public static GetSpareCostMapping getSpareCostMapping;

        public delegate bool CreateMessage(string shipID, DateTime occur, DateTime account, string business_code, DataTable dtb, string messageType, string businessType, out string err);
        public static CreateMessage createMessage;

        public delegate List<string> CreatePurchaseMessageSql(DataTable dtb);
        public static CreatePurchaseMessageSql createPurchaseMessageSql;

        public delegate bool ReverseAccount(string businessCode, out int stateCode, out string err);
        public static ReverseAccount reverseAccount;

        public static void StorageInitConfig()
        {
            ItemsManage.ItemsManageConfig.openSpareApplyForm = new ItemsManageConfig.SpareApplyForm(openSpareApplyForm);
            ItemsManage.ItemsManageConfig.openSpareInForm = new ItemsManageConfig.SpareInOrOutForm(openSpareInForm);
            ItemsManage.ItemsManageConfig.openSpareOutForm = new ItemsManageConfig.SpareInOrOutForm(openSpareOutForm);
            ItemsManage.ItemsManageConfig.openSpareInshipInfo = new ItemsManageConfig.SpareInshipInfo(openSpareInshipInfo);
        }
        public static void openSpareApplyForm(ComponentUnit componentUnit, List<StorageParameter> items, string remark)
        {
            FrmSparePurchaseApplyEdit frm = new FrmSparePurchaseApplyEdit(componentUnit, items, remark);
            frm.ShowDialog();
        }

        public static void openSpareInForm(List<StorageParameter> items, string remark)
        {
            FrmSpareInEdit frm = new FrmSpareInEdit(items, remark);
            frm.ShowDialog();
        }
        public static void openSpareOutForm(List<StorageParameter> items, string remark)
        {
            FrmSpareOutEdit frm = new FrmSpareOutEdit(items, remark);
            frm.ShowDialog();
        }
        public static void openSpareInshipInfo(string shipId, string spareId)
        {
            FrmSpareInShipInfo frm = new FrmSpareInShipInfo(shipId, spareId);
            frm.ShowDialog();
        }

    }
}
