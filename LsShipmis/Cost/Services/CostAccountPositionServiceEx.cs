using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Cost.Services
{
    public partial class CostAccountPositionService
    {
        /// <summary>
        /// 根据条件得到信息.
        /// 类别（1：备件；2：物料；3：航修；4：坞修；5：捆扎件；6：缆绳；7：油漆;8:化学品）.
        /// </summary>
        public bool GetInfoByCondition(CostAccountPositionCondition condition, out DataTable dt, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("cap.POSITION_ID");
            sb.AppendLine(",cap.NODE_ID");
            sb.AppendLine(",b.path");
            sb.AppendLine(",ca.NODE_NAME");
            sb.AppendLine(",ca.CODE");
            sb.AppendLine(",cap.CLASS");
            sb.AppendLine(",cap.ORDER_NUM");
            sb.AppendLine("  from T_COST_ACCOUNT_POSITION cap ");
            sb.AppendLine("  left join T_COST_ACCOUNT ca on ca.NODE_ID=cap.NODE_ID ");
            sb.AppendLine("  left join f_getC('') b on b.id=cap.NODE_ID ");
            sb.AppendLine(" where 1=1");
            if (!string.IsNullOrEmpty(condition.NODE_ID))
                sb.AppendLine("  and cap.NODE_ID='" + condition.NODE_ID + "'");
            if (!string.IsNullOrEmpty(condition.CLASS))
                sb.AppendLine("  and cap.CLASS in ('" + condition.CLASS + "')");
            sb.AppendLine(" order by cap.ORDER_NUM");
            return dbAccess.GetDataTable(sb.ToString(), out dt, out err);
        }

        /// <summary>
        /// 得到最大排序号.
        /// </summary>
        public bool GetMaxOrderNum(int classID, out int maxOrderNum, out string err)
        {
            maxOrderNum = 0;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select max(order_num)");
            sb.AppendLine("  from T_COST_ACCOUNT_POSITION ");
            sb.AppendLine("  where CLASS=" + classID);
            DataTable dt;
            if (!dbAccess.GetDataTable(sb.ToString(), out dt, out err))
                return false;
            if (dt.Rows.Count > 0 && dt.Rows[0][0] != null && !string.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                maxOrderNum = Convert.ToInt32(dt.Rows[0][0]);
            return true;
        }

        /// <summary>
        /// 根据条件删除数据.
        /// </summary>
        /// <param name="unit">要删除的T_COST_ACCOUNT_POSITION.pOSITION_ID主键</param>
        public bool DeleteUnitCondition(CostAccountPositionCondition condition, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("delete from T_COST_ACCOUNT_POSITION where 1=1");
            if (!string.IsNullOrEmpty(condition.POSITION_ID))
                sb.AppendLine(" and upper(T_COST_ACCOUNT_POSITION.POSITION_ID)='" + condition.POSITION_ID.ToUpper() + "'");
            if (!string.IsNullOrEmpty(condition.NODE_ID))
                sb.AppendLine(" and NODE_ID='" + condition.NODE_ID + "'");
            if (!string.IsNullOrEmpty(condition.CLASS))
                sb.AppendLine(" and CLASS='" + condition.CLASS + "'");
            return dbAccess.ExecSql(sb.ToString(), out err);
        }
    }

    public class CostAccountPositionCondition
    {
        public string POSITION_ID = "";
        public string NODE_ID = "";
        public string CLASS = "";
        public CostAccountPositionCondition(string paramPOSITION_ID, string paramNODE_ID, string paramCLASS)
        {
            POSITION_ID = paramPOSITION_ID;
            NODE_ID = paramNODE_ID;
            CLASS = paramCLASS;
        }

    }
}
