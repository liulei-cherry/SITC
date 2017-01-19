using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace ShipMisZHJ_WorkFlow.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_WorkFlow_EntranceService.cs
    /// </summary>
    public partial class T_WorkFlow_EntranceService
    {
        internal int getDuplicate(string WorkFlow_Object_Id, string DepartmentId)
        {
            sql = "select count(*) from T_WorkFlow_Entrance where upper(WorkFlow_Object_Id)='" + WorkFlow_Object_Id.ToUpper() + "' and upper(DepartmentId)='" + DepartmentId.ToUpper() + "'";
            string res = dbAccess.GetString(sql);
            return int.Parse(res);
        }

        internal string getGuid(string WorkFlow_Object_Id, string DepartmentId)
        {
            sql = "select WorkFlow_Entrance_Id from T_WorkFlow_Entrance where upper(WorkFlow_Object_Id)='" + WorkFlow_Object_Id.ToUpper() + "' and upper(DepartmentId)='" + DepartmentId.ToUpper() + "'";

            return dbAccess.GetString(sql);
        }

        /// <summary>
        /// 得到  T_WorkFlow_Entrance 所有数据信息.
        /// </summary>
        /// <returns>T_WorkFlow_Entrance DataTable</returns>
        internal DataTable getInfoOrder(out string err)
        {
            sql = "select "
                                + "WorkFlow_Entrance_Id"
                 + ","
                + "WorkFlow_Object_Id"
                 + ","
                + "DepartmentId"
                 + ","
                + "WorkFlow_Id"
                 + ","
                + "WorkFlow_Name"
                 + "  from T_WorkFlow_Entrance order by WorkFlow_Name";
            DataTable dt;
            dbAccess.GetDataTable(sql, out dt, out err);
            return dt;
        }

    }
}
