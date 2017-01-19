using System;
using System.Data;
using System.Text;

namespace Repair.Services
{
    public partial class ShipRunningRepairRelationService
    {
        /// <summary>
        /// 根据条件 得到  T_SHIPRUNNINGREPAIR_RELATION 数据信息.
        /// </summary>
        /// <returns>T_SHIPRUNNINGREPAIR_RELATION DataTable</returns>
        public DataTable GetInfo(string projectID, string repairID, string state, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select	");
            sb.Append("RELATIONID");
            sb.Append(",PROJECTID");
            sb.Append(",REPAIRID");
            sb.Append(",STATE");
            sb.Append(",REMARK");
            sb.Append(",SORTNO");
            sb.Append("  from T_SHIPRUNNINGREPAIR_RELATION ");
            sb.Append(" where 1=1 ");
            if (!string.IsNullOrEmpty(projectID))
                sb.Append(" and PROJECTID='" + projectID + "'");
            if (!string.IsNullOrEmpty(repairID))
                sb.Append(" and REPAIRID='" + repairID + "'");
            if (!string.IsNullOrEmpty(state))
                sb.Append(" and STATE in ('" + state + "')");
            sb.Append(" order by SORTNO");
            DataTable dt;
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
        /// 根据条件删除.
        /// </summary>
        public void DeleteUnit(string projectid, string repairid, string state)
        {
            sql = "delete from T_SHIPRUNNINGREPAIR_RELATION where 1=1";
            if (!string.IsNullOrEmpty(projectid))
                sql += " and PROJECTID='" + projectid + "'";
            if (!string.IsNullOrEmpty(state))
                sql += " and STATE=" + state;
            sql += " and REPAIRID='" + repairid + "'";
            string err;
            if (!dbAccess.ExecSql(sql, out err))
            {
                throw new Exception(err);
            }

        }

    }
}
