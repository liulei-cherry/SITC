/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：PortInfoService.cs
 * 创 建 人：xuzhengben
 * 创建时间：2010/9/19
 * 标    题：数据操作类
 * 功能描述：T_BASE_PORT数据操作类
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

namespace BaseInfo.DataAccess
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_BASE_PORTService.cs
    /// </summary>
    public partial class PortInfoService:IObjectsService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static PortInfoService instance = new PortInfoService();
        public static PortInfoService Instance
        {
            get
            {
                if (null == instance)
                {
                    PortInfoService.instance = new PortInfoService();
                }
                return PortInfoService.instance;
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
        /// <param name="unit">PortInfo对象</param>
        /// <returns>插入的对象更新</returns>	
        public bool saveUnit(PortInfo unit, out string err)
        {
            if (unit.PORTID != null && unit.PORTID.Length > 0) //edit
            {
                sql = "UPDATE [T_BASE_PORT] SET "
                    + " [PORTID] = " + (string.IsNullOrEmpty(unit.PORTID) ? "null" : "'" + unit.PORTID.Replace("'", "''") + "'")
                    + " , [ISOCODE] = " + (unit.ISOCODE == null ? "" : "'" + unit.ISOCODE.Replace("'", "''")) + "'"
                    + " , [ENAME] = " + (unit.ENAME == null ? "" : "'" + unit.ENAME.Replace("'", "''")) + "'"
                    + " , [CNAME] = " + (unit.CNAME == null ? "" : "'" + unit.CNAME.Replace("'", "''")) + "'"
                    + " , [COUNTRY] = " + (unit.COUNTRY == null ? "" : "'" + unit.COUNTRY.Replace("'", "''")) + "'"
                    + " , [REMARK] = " + (unit.REMARK == null ? "" : "'" + unit.REMARK.Replace("'", "''")) + "'"
                    + " where upper(PORTID) = '" + unit.PORTID.ToUpper() + "'";
            }
            else
            {
                unit.PORTID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_BASE_PORT] ("
                    + "[PORTID],"
                    + "[ISOCODE],"
                    + "[ENAME],"
                    + "[CNAME],"
                    + "[COUNTRY],"
                    + "[REMARK]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.PORTID) ? "null" : "'" + unit.PORTID.Replace("'", "''") + "'")
                    + " , " + (unit.ISOCODE == null ? "''" : "'" + unit.ISOCODE.Replace("'", "''")) + "'"
                    + " , " + (unit.ENAME == null ? "''" : "'" + unit.ENAME.Replace("'", "''")) + "'"
                    + " , " + (unit.CNAME == null ? "''" : "'" + unit.CNAME.Replace("'", "''")) + "'"
                    + " , " + (unit.COUNTRY == null ? "''" : "'" + unit.COUNTRY.Replace("'", "''")) + "'"
                    + " , " + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''")) + "'"
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_BASE_PORT中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_BASE_PORT对象</param>
        public bool deleteUnit(PortInfo unit, out string err)
        {
            return deleteUnit(unit.PORTID, out err);
        }

        /// <summary>
        /// 删除数据表T_BASE_PORT中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_BASE_PORT.pORTID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_BASE_PORT where "
                + " upper(T_BASE_PORT.PORTID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_BASE_PORT 所有数据信息.
        /// </summary>
        /// <returns>T_BASE_PORT DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "PORTID"
                + ",CNAME"
                + ",ENAME"
                + ",ISOCODE"
                + ",COUNTRY"
                + ",REMARK"
                + "  from T_BASE_PORT order by COUNTRY,CNAME";
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
        /// 根据一个主键ID,得到 T_BASE_PORT 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>PortInfo DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "PORTID"
                 + ",CNAME"
                + ",ENAME"
                + ",ISOCODE"
                + ",COUNTRY"
                + ",REMARK"
                + " from T_BASE_PORT "
                + " where upper(PORTID)='" + Id.ToUpper() + "'";
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
        /// 根据portinfo 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>portinfo 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBoxEx.Show(o);
        public PortInfo getObject(DataRow dr)
        {
            PortInfo unit = new PortInfo();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造PortInfo类对象!";
                return unit;
            }
            if (DBNull.Value != dr["PORTID"])
                unit.PORTID = dr["PORTID"].ToString();
            if (DBNull.Value != dr["ISOCODE"])
                unit.ISOCODE = dr["ISOCODE"].ToString();
            if (DBNull.Value != dr["ENAME"])
                unit.ENAME = dr["ENAME"].ToString();
            if (DBNull.Value != dr["CNAME"])
                unit.CNAME = dr["CNAME"].ToString();
            if (DBNull.Value != dr["COUNTRY"])
                unit.COUNTRY = dr["COUNTRY"].ToString();
            if (DBNull.Value != dr["REMARK"])
                unit.REMARK = dr["REMARK"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个PortInfo对象.
        /// </summary>
        /// <param name="pORTID">pORTID</param>
        /// <returns>PortInfo对象</returns>
        public PortInfo getObject(string Id, out string err)
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

        #region IObjectsService 成员

        public CommonOperation.BaseClass.CommonClass GetOneObjectById(string id)
        {
            string err;
            return getObject(id, out err);           
        }

        public Dictionary<string, string> GetObjectDisplaySetting()
        {
            Dictionary<string, string> reValue = new Dictionary<string, string>();
            reValue.Add("CNAME", "港口中文名称");
            reValue.Add("ENAME", "港口英文名称");
            reValue.Add("ISOCODE", "港口代码");
            reValue.Add("COUNTRY", "所属国家");
            reValue.Add("REMARK", "备注");
               
            return reValue;        
        } 
        #endregion
    }
}
