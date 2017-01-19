using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CustomerTable
{
    partial class CustomerTableClassService
    {
        //得到一组某个指定类型的数据源，并按照排序号排序.
        public  bool GetACustomerTableConfigerGroup(string ConfigerName,out List<CustomerTableClass> allRows,out int useColumnCount,out string err)
        {
            useColumnCount = 1;
            err = "";
            allRows = new List<CustomerTableClass>();
            string sql = "select	"
                + "T_CTB_ID, "
                + "CT_CLASS, "
                + "SEQUNCE, "
                + "CATEGERY01, "
                + "CATEGERY02, "
                + "CATEGERY03"
                + "\rfrom T_CTB "
                + " where upper(CT_CLASS) = '" + ConfigerName.Replace("'", "''").ToUpper() +"' order by SEQUNCE";
            DataTable dt;
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    allRows.Add(getObject(dt.Rows[i]));
                    if (useColumnCount < 3 && !string.IsNullOrEmpty(allRows[i].CATEGERY03))
                    {
                        useColumnCount = 3;
                    }
                    else if (useColumnCount < 2 && !string.IsNullOrEmpty(allRows[i].CATEGERY02))
                    {
                        useColumnCount = 2;
                    }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 得到  T_CTB 所有数据信息.
        /// </summary>
        /// <returns>T_CTB DataTable</returns>
        public DataTable GetInfoByConfigName(string configerName)
        {
            string err;
            sql = "select	"
                + "T_CTB_ID, "
                + "CT_CLASS, "
                + "SEQUNCE, "
                + "CATEGERY01, "
                + "CATEGERY02, "
                + "CATEGERY03"
                + "  from T_CTB where upper(CT_CLASS) = '" + configerName.Replace("'","''").ToUpper() + "' order by SEQUNCE";
            DataTable dt;
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                return dt;
            }
            else
            {
                throw new Exception(err);
            }
        }

        public bool DeleteACustomerTableConfigerGroup(string ConfigerName)
        {
            string err; 
            sql = "delete from T_CTB where "
             + " upper(CT_CLASS)='" + ConfigerName.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }

        public bool SaveACustomerTableConfigerGroup(string ConfigerName, List<CustomerTableClass> allRows,out string err)
        {
            err = "";
            if (!DeleteACustomerTableConfigerGroup(ConfigerName))
            {
                err = "保存用户配置项的第一步，删除" + ConfigerName+ "的旧配置项时出错，导致无法继续保存！";
                return false;
            }
            foreach (CustomerTableClass ctcTemp in allRows)
            {
                if (ctcTemp.CT_CLASS != ConfigerName)
                   throw new Exception("调用SaveACustomerTableConfigerGroup时，存在ConfigerName 与 具体数据项不一致的问题，应该是程序开发态错误！");

               if (!this.saveUnit(ctcTemp, out err)) return false;
            }
            return true;
        }        
    }
}
