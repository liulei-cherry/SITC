using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ShipMisZHJ_WorkFlow.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_WorkFlow_ObjectService.cs
    /// </summary>
    public partial class T_WorkFlow_ObjectService
    {
        internal int findObj(string p)
        {
            sql = "select count(*) from T_WorkFlow_Object where WorkFlow_Object_Name='" + p + "'";
            string rt=dbAccess.GetString(sql);
            if (!string.IsNullOrEmpty(rt))
            {
                return int.Parse(rt);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 得到  T_WorkFlow_Object 所有数据信息,并排序.
        /// </summary>
        /// <returns>T_WorkFlow_Object DataTable</returns>
        internal DataTable getInfoOrder(out string err)
        {
            sql = "select "
                                + "WorkFlow_Object_Id"
                 + ","
                + "WorkFlow_Object_Name"
                 + "  from T_WorkFlow_Object order by WorkFlow_Object_Name";
            DataTable dt;
            dbAccess.GetDataTable(sql, out dt, out err);
            return dt;
        }

    }
}
