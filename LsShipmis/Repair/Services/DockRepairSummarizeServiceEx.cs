using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Repair.Services
{
    public partial class DockRepairSummarizeService
    {
        /// <summary>
        /// 根据主数据信息.
        /// </summary>
        public bool GetmMainInfoByGroup(string SHIP_ID, out DataTable dt, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select	");
            sb.AppendLine("ds.SHIP_ID");
            sb.AppendLine(",s.SHIP_NAME");
            sb.AppendLine(",ds.BEGINDATE"); 
            sb.AppendLine(",ds.ENDDATE");
            sb.AppendLine("  from T_DOCKREPAIR_SUMMARIZE ds");
            sb.AppendLine("  inner join T_SHIP s on s.SHIP_ID=ds.SHIP_ID");
            sb.AppendLine("where 1=1");
            if (!string.IsNullOrEmpty(SHIP_ID))
                sb.AppendLine(" and ds.SHIP_ID='" + SHIP_ID + "'");
            sb.AppendLine(" group by ds.SHIP_ID,s.SHIP_NAME,ds.BEGINDATE,ds.ENDDATE");
            sb.AppendLine(" order by ds.BEGINDATE desc");
            return dbAccess.GetDataTable(sb.ToString(), out dt, out err);
        }
        /// <summary>
        /// 根据条件 得到  T_DOCKREPAIR_SUMMARIZE 所有数据信息.
        /// </summary>
        public bool GetInfoByCondition(string SHIP_ID, DateTime BEGINDATE, DateTime ENDDATE, out DataTable dt, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select	");
            sb.AppendLine("ds.DOCKREPAIR_SUMMARIZE_ID");
            sb.AppendLine(",ds.SHIP_ID");
            sb.AppendLine(",s.SHIP_NAME");
            sb.AppendLine(",ds.BEGINDATE");
            sb.AppendLine(",ds.ENDDATE");
            sb.AppendLine(",ds.NODE_ID");
            sb.AppendLine(",ca.NODE_NAME");
            sb.AppendLine(",ds.MANUFACTURER_ID");
            sb.AppendLine(",m.MANUFACTURER_NAME");
            sb.AppendLine(",c.CURRENCYCODE+'('+CURRENCYNAME+')' as CURRENCYNAME");
            sb.AppendLine(",ds.ESTIMATE_AMOUNT");
            sb.AppendLine(",ds.TOTAL_AMOUNT");
            sb.AppendLine(",ds.CURRENCY_ID");
            sb.AppendLine("  from T_DOCKREPAIR_SUMMARIZE ds");
            sb.AppendLine("  inner join T_SHIP s on s.SHIP_ID=ds.SHIP_ID");
            sb.AppendLine("  inner join T_COST_ACCOUNT ca on ca.NODE_ID=ds.NODE_ID");
            sb.AppendLine("  inner join T_MANUFACTURER m on m.MANUFACTURER_ID=ds.MANUFACTURER_ID");
            sb.AppendLine("  inner join T_CURRENCY c on c.CURRENCYID=ds.CURRENCY_ID");
            sb.AppendLine(" where 1=1");
            sb.AppendLine(" and ds.SHIP_ID='" + SHIP_ID + "'");
            sb.AppendLine(" and DATEDIFF(day,ds.BEGINDATE,'" + BEGINDATE + "')=0");
            sb.AppendLine(" and DATEDIFF(day,ds.ENDDATE,'" + ENDDATE + "')=0");
            sb.AppendLine(" order by NODE_NAME");
            return dbAccess.GetDataTable(sb.ToString(), out dt, out err);
        }

        /// <summary>
        /// 根据条件 删除信息.
        /// </summary>
        public bool DeleteInfoByCondition(string SHIP_ID, DateTime BEGINDATE, DateTime ENDDATE, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("delete from T_DOCKREPAIR_SUMMARIZE ");
            sb.AppendLine(" where 1=1");
            sb.AppendLine(" and SHIP_ID='" + SHIP_ID + "'");
            sb.AppendLine(" and DATEDIFF(day,BEGINDATE,'" + BEGINDATE + "')=0");
            sb.AppendLine(" and DATEDIFF(day,ENDDATE,'" + ENDDATE + "')=0");
            return dbAccess.ExecSql(sb.ToString(), out err);
        }

        /// <summary>
        /// 根据条件 删除信息.
        /// </summary>
        public string DeleteInfoByCondition(string SHIP_ID, DateTime BEGINDATE, DateTime ENDDATE)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("delete from T_DOCKREPAIR_SUMMARIZE ");
            sb.AppendLine(" where 1=1");
            sb.AppendLine(" and SHIP_ID='" + SHIP_ID + "'");
            sb.AppendLine(" and DATEDIFF(day,BEGINDATE,'" + BEGINDATE + "')=0");
            sb.AppendLine(" and DATEDIFF(day,ENDDATE,'" + ENDDATE + "')=0");
            return sb.ToString();
        }
    }
}
