using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Cost
{
    public class CostConfig
    {
        //messageType  1=采购接口 2=费用接口  3=物资领用接口  4=物资盘点接口.
        public delegate bool CreateMessage(string shipID, DateTime occur, DateTime account, string business_code, DataTable dtb, string messageType, string businessType, List<string> sqlList, out string err);
        public static CreateMessage createMessage;

        public delegate bool ReverseAccount(string businessCode, List<string> sqlList, out int stateCode, out string err);
        public static ReverseAccount reverseAccount;
        public delegate bool GetPurchaseMessageByBusinessCode(string BUSINESS_CODE, out DataTable dt, out string err);
        public static GetPurchaseMessageByBusinessCode getPurchaseMessageByBusinessCode;
    }
}
