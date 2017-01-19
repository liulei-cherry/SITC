/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：HOilLuboilReportService.cs
 * 创 建 人：王鹏程
 * 创建时间：2012/3/23
 * 标    题：数据操作类
 * 功能描述：T_HOIL_LUBOIL_REPORT数据操作类
 * Codesmith DataAccessLayer.cst 1.01版本生成
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
using Oil.DataObject;

namespace Oil.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_HOIL_LUBOIL_REPORTService.cs
    /// </summary>
    public partial class HOilLuboilReportService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static HOilLuboilReportService instance = new HOilLuboilReportService();
        public static HOilLuboilReportService Instance
        {
            get
            {
                if (null == instance)
                {
                    HOilLuboilReportService.instance = new HOilLuboilReportService();
                }
                return HOilLuboilReportService.instance;
            }
        }
        private HOilLuboilReportService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">HOilLuboilReport对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(HOilLuboilReport unit, out string err)
        {
            return dbAccess.ExecSql(saveUnit(unit), out err);
        }
        /// <summary>
        /// 返回向数据库中保存一条新记录的sql语句。做事务用。.
        /// </summary>
        /// <param name="unit">HOilLuboilReport对象</param>
        /// <returns>插入的对象更新</returns>	
        internal string saveUnit(HOilLuboilReport unit)
        {
            if (unit.REPORT_ID != null && unit.REPORT_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_HOIL_LUBOIL_REPORT] SET "
                    + " [REPORT_ID] = " + (string.IsNullOrEmpty(unit.REPORT_ID) ? "null" : "'" + unit.REPORT_ID.Replace("'", "''") + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , [REPORT_DATE] = " + dbOperation.DbToDate(unit.REPORT_DATE)
                    + " , [REMARK] = " + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
                    + " , [APPROVER] = " + (unit.APPROVER == null ? "''" : "'" + unit.APPROVER.Replace("'", "''") + "'")
                    + " , [APPROVER2] = " + (unit.APPROVER2 == null ? "''" : "'" + unit.APPROVER2.Replace("'", "''") + "'")
                    + " , [CHECKED] = " + unit.CHECKED.ToString()
                    + " where upper(REPORT_ID) = '" + unit.REPORT_ID.ToUpper() + "'";
            }
            else
            {
                unit.REPORT_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_HOIL_LUBOIL_REPORT] ("
                    + "[REPORT_ID],"
                    + "[SHIP_ID],"
                    + "[REPORT_DATE],"
                    + "[REMARK],"
                    + "[APPROVER],"
                    + "[APPROVER2],"
                    + "[CHECKED]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.REPORT_ID) ? "null" : "'" + unit.REPORT_ID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.REPORT_DATE)
                    + " , " + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
                    + " , " + (unit.APPROVER == null ? "''" : "'" + unit.APPROVER.Replace("'", "''") + "'")
                    + " , " + (unit.APPROVER2 == null ? "''" : "'" + unit.APPROVER2.Replace("'", "''") + "'")
                    + " ," + unit.CHECKED.ToString()
                    + ")";
            }

            return sql;
        }
        /// <summary>
        /// 删除数据表T_HOIL_LUBOIL_REPORT中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_HOIL_LUBOIL_REPORT对象</param>
        internal bool deleteUnit(HOilLuboilReport unit, out string err)
        {
            return deleteUnit(unit.REPORT_ID, out err);
        }

        /// <summary>
        /// 删除数据表T_HOIL_LUBOIL_REPORT中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_HOIL_LUBOIL_REPORT.rEPORT_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_HOIL_LUBOIL_REPORT where "
                + " upper(T_HOIL_LUBOIL_REPORT.REPORT_ID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_HOIL_LUBOIL_REPORT 所有数据信息.
        /// </summary>
        /// <returns>T_HOIL_LUBOIL_REPORT DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "REPORT_ID"
                + ",SHIP_ID"
                + ",REPORT_DATE"
                + ",REMARK"
                + ",APPROVER"
                + ",APPROVER2"
                + ",CHECKED"
                + "  from T_HOIL_LUBOIL_REPORT ";
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
        /// 根据一个主键ID,得到 T_HOIL_LUBOIL_REPORT 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>HOilLuboilReport DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "REPORT_ID"
                + ",SHIP_ID"
                + ",REPORT_DATE"
                + ",REMARK"
                + ",APPROVER"
                + ",APPROVER2"
                + ",CHECKED"
                + " from T_HOIL_LUBOIL_REPORT "
                + " where upper(REPORT_ID)='" + Id.ToUpper() + "'";
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
        /// 根据hoilluboilreport 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>hoilluboilreport 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
        public HOilLuboilReport getObject(DataRow dr)
        {
            HOilLuboilReport unit = new HOilLuboilReport();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造HOilLuboilReport类对象!";
                return unit;
            }
            if (DBNull.Value != dr["REPORT_ID"])
                unit.REPORT_ID = dr["REPORT_ID"].ToString();
            if (DBNull.Value != dr["SHIP_ID"])
                unit.SHIP_ID = dr["SHIP_ID"].ToString();
            if (DBNull.Value != dr["REPORT_DATE"])
                unit.REPORT_DATE = (DateTime)dr["REPORT_DATE"];
            if (DBNull.Value != dr["REMARK"])
                unit.REMARK = dr["REMARK"].ToString();
            if (DBNull.Value != dr["APPROVER"])
                unit.APPROVER = dr["APPROVER"].ToString();
            if (DBNull.Value != dr["APPROVER2"])
                unit.APPROVER2 = dr["APPROVER2"].ToString();
            if (DBNull.Value != dr["CHECKED"])
                unit.CHECKED = Convert.ToDecimal(dr["CHECKED"]);

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个HOilLuboilReport对象.
        /// </summary>
        /// <param name="rEPORT_ID">rEPORT_ID</param>
        /// <returns>HOilLuboilReport对象</returns>
        public HOilLuboilReport getObject(string Id, out string err)
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
    }
}
