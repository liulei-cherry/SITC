using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Oil
{
    public class OilConfig
    {
        public delegate bool CreateMessageSql(string shipID, DateTime occur, DateTime account, string business_code, DataTable dtb,
            string messageType, string businessType, List<string> sqlList, out string err);
        public static CreateMessageSql createMessageSql;

        public delegate bool CreateMessage(string shipID, DateTime occur, DateTime account, string business_code, DataTable dtb,
           string messageType, string businessType, out string err);
        public static CreateMessage createMessage;

        public delegate bool ReverseAccount(string businessCode, List<string> sqlList, out int stateCode, out string err);
        public static ReverseAccount reverseAccount;

        public delegate bool ReverseAccountSql(string businessCode, List<string> sqlList, out int stateCode, out string err);
        public static ReverseAccountSql reverseAccountSql;

        public delegate List<string> CreatePurchaseMessageSql(DataTable dtb);
        public static CreatePurchaseMessageSql createPurchaseMessageSql;

        public delegate bool GetOilCostMapping(string id, out string mapping, out string name, out string err);
        public static GetOilCostMapping getOilCostMapping;
    }
}
