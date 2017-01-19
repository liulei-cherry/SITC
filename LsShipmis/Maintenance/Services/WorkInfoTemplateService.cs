/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：WorkInfoTemplateService.cs
 * 创 建 人：徐正本
 * 创建时间：2010-7-1
 * 标    题：数据操作类
 * 功能描述：T_WORKINFO_TEMPLATE数据操作类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using BaseInfo.Objects;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using Maintenance.DataObject;

namespace Maintenance.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_WORKINFO_TEMPLATEService.cs
    /// </summary>
    public partial class WorkInfoTemplateService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static WorkInfoTemplateService instance = new WorkInfoTemplateService();
        public static WorkInfoTemplateService Instance
        {
            get
            {
                if (null == instance)
                {
                    WorkInfoTemplateService.instance = new WorkInfoTemplateService();
                }
                return WorkInfoTemplateService.instance;
            }
        }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region -----------实例化接口函数-----------

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">WorkInfoTemplate对象</param>
        /// <returns>插入的对象更新</returns>	
        public bool saveUnit(WorkInfoTemplate unit, out string err)
        {
            if (unit.WORKINFO_TEMPLATE_ID != null && unit.WORKINFO_TEMPLATE_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_WORKINFO_TEMPLATE] SET "
                    + " [WORKINFO_TEMPLATE_ID] = " + (string.IsNullOrEmpty(unit.WORKINFO_TEMPLATE_ID) ? "null" : "'" + unit.WORKINFO_TEMPLATE_ID.Replace("'", "''") + "'")
                    + " , [COMPONENTREFERENCE] = '" + (unit.COMPONENTREFERENCE == null ? "" : "'" + unit.COMPONENTREFERENCE.Replace("'", "''")) + "'"
                    + " , [ITEMNAME] = '" + (unit.ITEMNAME == null ? "" : "'" + unit.ITEMNAME.Replace("'", "''")) + "'"
                    + " , [ITEMCONTENT] = '" + (unit.ITEMCONTENT == null ? "" : "'" + unit.ITEMCONTENT.Replace("'", "''")) + "'"
                    + " , [PERIOD] = " + unit.PERIOD.ToString()
                    + " , [PERIODICAL] = '" + (unit.PERIODICAL == null ? "" : "'" + unit.PERIODICAL.Replace("'", "''")) + "'"
                    + " , [REMARK] = '" + (unit.REMARK == null ? "" : "'" + unit.REMARK.Replace("'", "''")) + "'"
                    + " , [CLASS] = '" + (unit.CLASS == null ? "" : "'" + unit.CLASS.Replace("'", "''")) + "'"
                    + " where upper(WORKINFO_TEMPLATE_ID) = '" + unit.WORKINFO_TEMPLATE_ID.ToUpper() + "'";
            }
            else
            {
                unit.WORKINFO_TEMPLATE_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_WORKINFO_TEMPLATE] ("
                    + "[WORKINFO_TEMPLATE_ID],"
                    + "[COMPONENTREFERENCE],"
                    + "[ITEMNAME],"
                    + "[ITEMCONTENT],"
                    + "[PERIOD],"
                    + "[PERIODICAL],"
                    + "[REMARK],"
                    + "[CLASS]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.WORKINFO_TEMPLATE_ID) ? "null" : "'" + unit.WORKINFO_TEMPLATE_ID.Replace("'", "''") + "'")
                    + " , " + (unit.COMPONENTREFERENCE == null ? "''" : "'" + unit.COMPONENTREFERENCE.Replace("'", "''")) + "'"
                    + " , " + (unit.ITEMNAME == null ? "''" : "'" + unit.ITEMNAME.Replace("'", "''")) + "'"
                    + " , " + (unit.ITEMCONTENT == null ? "''" : "'" + unit.ITEMCONTENT.Replace("'", "''")) + "'"
                    + " ," + unit.PERIOD.ToString()
                    + " , " + (unit.PERIODICAL == null ? "''" : "'" + unit.PERIODICAL.Replace("'", "''")) + "'"
                    + " , " + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''")) + "'"
                    + " , " + (unit.CLASS == null ? "''" : "'" + unit.CLASS.Replace("'", "''")) + "'"
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_WORKINFO_TEMPLATE中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_WORKINFO_TEMPLATE对象</param>
        public bool deleteUnit(WorkInfoTemplate unit, out string err)
        {
            return deleteUnit(unit.WORKINFO_TEMPLATE_ID, out err);
        }

        /// <summary>
        /// 删除数据表T_WORKINFO_TEMPLATE中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_WORKINFO_TEMPLATE.wORKINFO_TEMPLATE_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_WORKINFO_TEMPLATE where "
                + " upper(T_WORKINFO_TEMPLATE.WORKINFO_TEMPLATE_ID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_WORKINFO_TEMPLATE 所有数据信息.
        /// </summary>
        /// <returns>T_WORKINFO_TEMPLATE DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "WORKINFO_TEMPLATE_ID"
                + ",COMPONENTREFERENCE"
                + ",ITEMNAME"
                + ",ITEMCONTENT"
                + ",PERIOD"
                + ",PERIODICAL"
                + ",PERIODICAL as PERIODICALDISPLAY"
                + ",CLASS"
                + ",REMARK"
                + "  from T_WORKINFO_TEMPLATE "
            + "  order by COMPONENTREFERENCE,class ";
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
        /// <summary>
        /// 根据一个主键ID,得到 T_WORKINFO_TEMPLATE 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>WorkInfoTemplate DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "WORKINFO_TEMPLATE_ID"
                + ",COMPONENTREFERENCE"
                + ",ITEMNAME"
                + ",ITEMCONTENT"
                + ",PERIOD"
                + ",PERIODICAL"
                + ",REMARK"
                + " from T_WORKINFO_TEMPLATE "
                + " where upper(WORKINFO_TEMPLATE_ID)='" + Id.ToUpper() + "'";
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
        /// <summary>
        /// 根据workinfotemplate 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>workinfotemplate 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBoxEx.Show(o);
        public WorkInfoTemplate getObject(DataRow dr)
        {
            WorkInfoTemplate unit = new WorkInfoTemplate();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造WorkInfoTemplate类对象!";
                return unit;
            }
            if (DBNull.Value != dr["WORKINFO_TEMPLATE_ID"])
                unit.WORKINFO_TEMPLATE_ID = dr["WORKINFO_TEMPLATE_ID"].ToString();
            if (DBNull.Value != dr["COMPONENTREFERENCE"])
                unit.COMPONENTREFERENCE = dr["COMPONENTREFERENCE"].ToString();
            if (DBNull.Value != dr["ITEMNAME"])
                unit.ITEMNAME = dr["ITEMNAME"].ToString();
            if (DBNull.Value != dr["ITEMCONTENT"])
                unit.ITEMCONTENT = dr["ITEMCONTENT"].ToString();
            if (DBNull.Value != dr["PERIOD"])
                unit.PERIOD = Convert.ToDecimal(dr["PERIOD"]);
            if (DBNull.Value != dr["PERIODICAL"])
                unit.PERIODICAL = dr["PERIODICAL"].ToString();
            if (DBNull.Value != dr["REMARK"])
                unit.REMARK = dr["REMARK"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个WorkInfoTemplate对象.
        /// </summary>
        /// <param name="wORKINFO_TEMPLATE_ID">wORKINFO_TEMPLATE_ID</param>
        /// <returns>WorkInfoTemplate对象</returns>
        public WorkInfoTemplate getObject(string Id, out string err)
        {
            err = "";
            try
            {
                DataTable dt = getInfo(Id, out err);
                return getObject(dt.Rows[0]);
            }
            catch
            {
                return getObject(null);
            }
        }
        #endregion
        #endregion
        public DataTable getInfoAllContain(string component, out string err)
        {
            sql = "select DISTINCT"
                + " COMPONENTREFERENCE"
                + ",CLASS"        
                + " from T_WORKINFO_TEMPLATE "
                + " where COMPONENTREFERENCE like '%" + component + "%' or CLASS like '%" + component + "%' ORDER BY CLASS,COMPONENTREFERENCE";
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
        public DataTable getInfoTwoCharContain(string component, out string err)
        {
            string sql1="";
            err = "";
            sql = "select DISTINCT"
                + " COMPONENTREFERENCE"
                + ",CLASS"
                + " from T_WORKINFO_TEMPLATE ";

            DataTable dt=new DataTable();
            DataTable dt1=null;
            if (component.Length < 2)
            {
                sql1 = sql + " where COMPONENTREFERENCE like '%" + component + "%' ORDER BY CLASS,COMPONENTREFERENCE";
                if (dbAccess.GetDataTable(sql1, out dt1, out err))
                {
                    dt.Merge(dt1);
                } 
            }
            while (component.Length > 1)
            {
                sql1 = sql + " where COMPONENTREFERENCE like '%" + component.Substring(0, 2) + "%'  ORDER BY CLASS,COMPONENTREFERENCE";
                component = component.Substring(1, component.Length - 1);
                if (dbAccess.GetDataTable(sql1, out dt1, out err))
                {
                    dt.Merge(dt1);
                } 
            }
            return dt;
            //dt.Rows.CopyTo(dt2.Rows, dt2.Rows.count);            
        }

        public DataTable getDetail(string component,  List<string> lstExist ,out string err)
        {
            err = "";

            string sql = "select "
                + " WORKINFO_TEMPLATE_ID"
                + ",COMPONENTREFERENCE"
                + ",ITEMNAME"
                + ",ITEMCONTENT"
                + ",PERIOD"
                + ",PERIODICAL"
                + ",REMARK"
                + ",CLASS"
                + " from T_WORKINFO_TEMPLATE "
                + " where COMPONENTREFERENCE = '" + component + "' ";

            if (lstExist.Count > 0)
            {
                string notIn = "";
                foreach (string stemp in lstExist)
                {
                    notIn += "'" + stemp.Replace("'", "''") + "',";
                }
                notIn = notIn.Substring(0, notIn.Length - 1);
                sql += " and ITEMNAME not in (" + notIn + ")";
            }
            sql += "\rorder by COMPONENTREFERENCE,CLASS,ITEMNAME,ITEMCONTENT";
            DataTable dt = new DataTable();
           
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                return dt;
            }
            else
            {
                throw new Exception(err);
            }
            
            //dt.Rows.CopyTo(dt2.Rows, dt2.Rows.count);            
        }
    }
}
