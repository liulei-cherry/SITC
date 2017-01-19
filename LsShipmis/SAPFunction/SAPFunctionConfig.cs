using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SAPFunction.Services;

namespace SAPFunction
{
    public class SAPFunctionConfig
    {
        public static void InitConfig()
        {
            StorageManage.StorageConfig.getMaterialCostMapping = new StorageManage.StorageConfig.GetMaterialCostMapping(GetMaterialCostMapping);
            StorageManage.StorageConfig.getSpareCostMapping = new StorageManage.StorageConfig.GetSpareCostMapping(GetSpareCostMapping);
            StorageManage.StorageConfig.createMessage = new StorageManage.StorageConfig.CreateMessage(CreateMessage);
            StorageManage.StorageConfig.reverseAccount = new StorageManage.StorageConfig.ReverseAccount(ReverseAccount);
            StorageManage.StorageConfig.createPurchaseMessageSql = new StorageManage.StorageConfig.CreatePurchaseMessageSql(CreatePurchaseMessageSql);
            Oil.OilConfig.getOilCostMapping = new Oil.OilConfig.GetOilCostMapping(GetHoilCostMapping);
            Oil.OilConfig.createPurchaseMessageSql = new Oil.OilConfig.CreatePurchaseMessageSql(CreatePurchaseMessageSql);
            Oil.OilConfig.reverseAccount = new Oil.OilConfig.ReverseAccount(ReverseAccountSql);
            Cost.CostConfig.createMessage = new Cost.CostConfig.CreateMessage(CreateMessageSql);
            Cost.CostConfig.reverseAccount = new Cost.CostConfig.ReverseAccount(ReverseAccountSql);
            Cost.CostConfig.getPurchaseMessageByBusinessCode = new Cost.CostConfig.GetPurchaseMessageByBusinessCode(GetPurchaseMessageByBusinessCode);
            Oil.OilConfig.createMessageSql = new Oil.OilConfig.CreateMessageSql(CreateMessageSql);
            Oil.OilConfig.createMessage = new Oil.OilConfig.CreateMessage(CreateMessage);
            Oil.OilConfig.reverseAccountSql = new Oil.OilConfig.ReverseAccountSql(ReverseAccountSql);
        }
        private static bool CreateMessage(string shipID, DateTime occur, DateTime account, string business_code, DataTable dtb, string messageType, string businessType, out string err)
        {
            err = "";
            return SAPFunction.Services.SAPFunctionOperation.Instance.CreateMessage(shipID, occur, account, business_code, dtb, messageType, businessType, out  err);
        }
        private static bool CreateMessageSql(string shipID, DateTime occur, DateTime account, string business_code, DataTable dtb, string messageType, string businessType, List<string> sqlList, out string err)
        {
            err = "";
            return SAPFunction.Services.SAPFunctionOperation.Instance.CreateMessageSql(shipID, occur, account, business_code, dtb, messageType, businessType, sqlList, out err);
        }
        public static bool ReverseAccountSql(string businessCode, List<string> sqlList, out int stateCode, out string err)
        {
            err = "";
            return SAPFunction.Services.SAPFunctionOperation.Instance.ReverseAccount(businessCode, sqlList, out stateCode, out  err);
        }
        public static bool ReverseAccount(string businessCode, out int stateCode, out string err)
        {
            err = "";
            return SAPFunction.Services.SAPFunctionOperation.Instance.ReverseAccount(businessCode, out stateCode, out  err);
        }
        public static bool GetMaterialCostMapping(string id, out string mapping, out string name, out string err)
        {
            err = "";
            return MappingOperation.Instance.GetMaterialCostMapping(id, out mapping, out name, out err);
        }
        public static bool GetHoilCostMapping(string id, out string mapping, out string name, out string err)
        {
            err = "";
            return MappingOperation.Instance.GetHoilCostMapping(id, out mapping, out name, out err);
        }
        public static bool GetSpareCostMapping(string shipID, string id, out string mapping, out string name, out string err)
        {
            err = "";
            return MappingOperation.Instance.GetSpareCostMapping(shipID, id, out mapping, out name, out err);
        }
        public static List<string> CreatePurchaseMessageSql(DataTable dtb)
        {
            return SAPFunctionOperation.Instance.CreatePurchaseMessageSql(dtb);
        }
        public static bool GetPurchaseMessageByBusinessCode(string BUSINESS_CODE, out DataTable dt, out string err)
        {
            return PurchaseMessageService.Instance.GetPurchaseMessageByBusinessCode(BUSINESS_CODE, out dt, out err);
        }
    }
}
