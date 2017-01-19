using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace StorageManage.Services
{
    public partial class SparePurchaseApplyDetailService
    {
        /// <summary>
        /// 得到  T_SPARE_PURCHASE_APPLY_DETAIL 所有数据信息.
        /// </summary>
        /// <returns>T_SPARE_PURCHASE_APPLY_DETAIL DataTable</returns>
        public bool GetInfo(string PURCHASE_APPLYID, out DataTable dt, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select	");
            sb.AppendLine("spad.PURCHASE_APPLY_DETAIL_ID");
            sb.AppendLine(",spad.PURCHASE_APPLYID");
            sb.AppendLine(",spad.SPARE_ID");
            sb.AppendLine(",spad.SPARE_NAME");
            sb.AppendLine(",spare.PICNUMBER");
            sb.AppendLine(",spad.PARTNUMBER");
            sb.AppendLine(",spare.UNIT_NAME");
            sb.AppendLine(",isnull(v.STOCKSAll,0) COUNTINSHIP");
            sb.AppendLine(",spad.APPLYCOUNT");
            sb.AppendLine(",spad.CONFIRMEDCOUNT");
            sb.AppendLine(",spad.COMPONENT_UNIT_ID");
            sb.AppendLine(",spad.REMARK");
            sb.AppendLine(" from T_SPARE_PURCHASE_APPLY_DETAIL spad");
            sb.AppendLine(" inner join T_SPARE spare on spad.SPARE_ID = spare.SPARE_ID");
            sb.AppendLine(" inner join T_SPARE_PURCHASE_APPLY t1 on  t1.PURCHASE_APPLYID = '" + dbOperation.ReplaceSqlKeyStr(PURCHASE_APPLYID) + "'");
            sb.AppendLine(" left join (select spare_id,sum(STOCKSAll) STOCKSAll,ship_id");
            sb.AppendLine("          from V_SPARE_STOCKS group by SHIP_ID , SPARE_ID ) v");
            sb.AppendLine("          on spad.SPARE_ID = v.spare_id and t1.ship_id = v.ship_id");
            sb.AppendLine(" where spad.PURCHASE_APPLYID='" + dbOperation.ReplaceSqlKeyStr(PURCHASE_APPLYID) + "'");
            sb.AppendLine("  order by spad.PURCHASE_APPLYID,spad.PARTNUMBER");
            return dbAccess.GetDataTable(sb.ToString(), out dt, out err);
        }
        /// <summary>
        /// 删除绑定数据.
        /// </summary>
        public bool DeleteByPurchaseApplyID(string PURCHASE_APPLYID, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("delete from T_SPARE_PURCHASE_APPLY_DETAIL ");
            sb.AppendLine(" where 1=1");
            sb.AppendLine("  and PURCHASE_APPLYID='" + PURCHASE_APPLYID + "'");
            return dbAccess.ExecSql(sb.ToString(), out err);
        }
    }
}
