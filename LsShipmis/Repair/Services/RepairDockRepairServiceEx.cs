using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Repair.Services
{
    public partial class RepairDockRepairService
    {
        /// <summary>
        /// 根据条件得到厂修记录数据
        /// </summary>
        /// <returns>T_REPAIR_DOCKREPAIR DataTable</returns>
        public DataTable GetInfo(string SHIP_ID, string REPAIR_ANNUAL)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select	");
            sb.AppendLine("rd.REPAIR_DOCKREPAIR_ID");
            sb.AppendLine(",rd.SHIP_ID");
            sb.AppendLine(",s.ship_name");
            sb.AppendLine(",rd.REPAIR_ANNUAL");
            sb.AppendLine(",rd.REMARK");
            sb.AppendLine("  from T_REPAIR_DOCKREPAIR rd");
            sb.AppendLine(" inner join t_ship s on s.ship_id=rd.ship_id ");
            sb.AppendLine(" where 1=1");
            if (!string.IsNullOrEmpty(SHIP_ID))
                sb.AppendLine(" and rd.ship_id='" + SHIP_ID + "'");
            if (!string.IsNullOrEmpty(REPAIR_ANNUAL))
                sb.AppendLine(" and rd.REPAIR_ANNUAL='" + REPAIR_ANNUAL + "'");
            sb.AppendLine(" order by REPAIR_ANNUAL desc");

            DataTable dt;
            string err;
            if (dbAccess.GetDataTable(sb.ToString(), out dt, out err))
            {
                return dt;
            }
            else
            {
                throw new Exception(err);
            }
        }

        /// <summary>
        /// 得到厂修记录所有年度
        /// </summary>
        public DataTable GetAnnual(string SHIP_ID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select	");
            sb.AppendLine("REPAIR_ANNUAL");
            sb.AppendLine("  from T_REPAIR_DOCKREPAIR");
            sb.AppendLine(" where 1=1");
            if (!string.IsNullOrEmpty(SHIP_ID))
                sb.AppendLine(" and SHIP_ID='" + SHIP_ID + "'");
            sb.AppendLine("group by REPAIR_ANNUAL");
            sb.AppendLine("order by REPAIR_ANNUAL desc");
            DataTable dt;
            string err;
            if (dbAccess.GetDataTable(sb.ToString(), out dt, out err))
            {
                return dt;
            }
            else
            {
                throw new Exception(err);
            }
        }
    }
}
