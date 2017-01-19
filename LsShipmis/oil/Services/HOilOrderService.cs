/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：HOilOrderService.cs
 * 创 建 人：王鹏程
 * 创建时间：2012/4/26
 * 标    题：数据操作类
 * 功能描述：T_HOIL_ORDER数据操作类
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
    /// 数据层实例化接口类 dbo.T_HOIL_ORDERService.cs
    /// </summary>
    public partial class HOilOrderService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象
        /// </summary>
        private static HOilOrderService instance = new HOilOrderService();
        public static HOilOrderService Instance
        {
            get
            {
                if (null == instance)
                {
                    HOilOrderService.instance = new HOilOrderService();
                }
                return HOilOrderService.instance;
            }
        }
        private HOilOrderService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。
        /// </summary>
        /// <param name="unit">HOilOrder对象</param>
        /// <returns>插入的对象更新</returns>	
        public bool SaveUnit(HOilOrder unit, out string err)
        {
            return dbAccess.ExecSql(SaveUnitSql(unit), out err);
        }
        /// <summary>
        /// 向数据库中保存一条新记录。
        /// </summary>
        /// <param name="unit">HOilOrder对象</param>
        /// <returns>插入的对象更新</returns>	
        public void SaveUnit(HOilOrder unit)
        {
            string err;
            if (!dbAccess.ExecSql(SaveUnitSql(unit), out err))
                throw new Exception(err);
        }
        /// <summary>
        /// 返回向数据库中保存一条新记录的sql语句。做事务用。
        /// </summary>
        /// <param name="unit">HOilOrder对象</param>
        /// <returns>插入的对象更新</returns>	
        public string SaveUnitSql(HOilOrder unit)
        {
            if (unit.ORDER_ID != null && unit.ORDER_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_HOIL_ORDER] SET "
                    + " [ORDER_ID] = " + (string.IsNullOrEmpty(unit.ORDER_ID) ? "null" : "'" + unit.ORDER_ID.Replace("'", "''") + "'")
                    + " , [APPLY_ID] = " + (string.IsNullOrEmpty(unit.APPLY_ID) ? "null" : "'" + unit.APPLY_ID.Replace("'", "''") + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , [CODE] = " + (unit.CODE == null ? "''" : "'" + unit.CODE.Replace("'", "''") + "'")
                    + " , [ORDER_DATE] = " + dbOperation.DbToDate(unit.ORDER_DATE)
                    + " , [SUPPLY_DATE] = " + dbOperation.DbToDate(unit.SUPPLY_DATE)
                    + " , [PORT_ID] = " + (string.IsNullOrEmpty(unit.PORT_ID) ? "null" : "'" + unit.PORT_ID.Replace("'", "''") + "'")
                    + " , [SUPPLIER_ID] = " + (string.IsNullOrEmpty(unit.SUPPLIER_ID) ? "null" : "'" + unit.SUPPLIER_ID.Replace("'", "''") + "'")
                    + " , [APPROVER] = " + (unit.APPROVER == null ? "''" : "'" + unit.APPROVER.Replace("'", "''") + "'")
                    + " , [CHECKED] = " + unit.CHECKED.ToString()
                    + " , [REMARK] = " + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
                    + " where upper(ORDER_ID) = '" + unit.ORDER_ID.ToUpper() + "'";
            }
            else
            {
                unit.ORDER_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_HOIL_ORDER] ("
                    + "[ORDER_ID],"
                    + "[APPLY_ID],"
                    + "[SHIP_ID],"
                    + "[CODE],"
                    + "[ORDER_DATE],"
                    + "[SUPPLY_DATE],"
                    + "[PORT_ID],"
                    + "[SUPPLIER_ID],"
                    + "[APPROVER],"
                    + "[CHECKED],"
                    + "[REMARK]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.ORDER_ID) ? "null" : "'" + unit.ORDER_ID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.APPLY_ID) ? "null" : "'" + unit.APPLY_ID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , " + (unit.CODE == null ? "''" : "'" + unit.CODE.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.ORDER_DATE)
                    + " ," + dbOperation.DbToDate(unit.SUPPLY_DATE)
                    + " , " + (string.IsNullOrEmpty(unit.PORT_ID) ? "null" : "'" + unit.PORT_ID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SUPPLIER_ID) ? "null" : "'" + unit.SUPPLIER_ID.Replace("'", "''") + "'")
                    + " , " + (unit.APPROVER == null ? "''" : "'" + unit.APPROVER.Replace("'", "''") + "'")
                    + " ," + unit.CHECKED.ToString()
                    + " , " + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
                    + ")";
            }

            return sql;
        }

        /// <summary>
        /// 删除数据表T_HOIL_ORDER中的一条记录
        /// </summary>
        /// <param name="unit">要删除的T_HOIL_ORDER.oRDER_ID主键</param>
        public bool DeleteUnit(string unitid, out string err)
        {
            return dbAccess.ExecSql(DeleteUnitSql(unitid), out err);
        }
        /// <summary>
        /// 删除数据表T_HOIL_ORDER中的一条记录
        /// </summary>
        /// <param name="unit">要删除的T_HOIL_ORDER.oRDER_ID主键</param>
        public void DeleteUnit(string unitid)
        {
            string err;
            if (!dbAccess.ExecSql(DeleteUnitSql(unitid), out err))
                throw new Exception(err);
        }

        /// <summary>
        /// 删除数据表T_HOIL_ORDER中的一条记录,返回sql语句
        /// </summary>
        /// <param name="unit">要删除的T_HOIL_ORDER.oRDER_ID主键</param>
        public string DeleteUnitSql(string unitid)
        {
            sql = "delete from T_HOIL_ORDER where "
                + " upper(T_HOIL_ORDER.ORDER_ID)='" + unitid.ToUpper() + "'";
            return sql;
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_HOIL_ORDER 所有数据信息
        /// </summary>
        /// <returns>T_HOIL_ORDER DataTable</returns>
        public DataTable GetInfo()
        {
            string err;
            sql = "select	"
                + "ORDER_ID"
                + ",APPLY_ID"
                + ",SHIP_ID"
                + ",CODE"
                + ",ORDER_DATE"
                + ",SUPPLY_DATE"
                + ",PORT_ID"
                + ",SUPPLIER_ID"
                + ",APPROVER"
                + ",CHECKED"
                + ",REMARK"
                + "  from T_HOIL_ORDER ";
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
        /// 根据一个主键ID,得到 T_HOIL_ORDER 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>HOilOrder DataTable</returns>
        public DataTable GetInfo(string Id)
        {
            string err;
            sql = "select "
                + "ORDER_ID"
                + ",APPLY_ID"
                + ",SHIP_ID"
                + ",CODE"
                + ",ORDER_DATE"
                + ",SUPPLY_DATE"
                + ",PORT_ID"
                + ",SUPPLIER_ID"
                + ",APPROVER"
                + ",CHECKED"
                + ",REMARK"
                + " from T_HOIL_ORDER "
                + " where upper(ORDER_ID)='" + Id.ToUpper() + "'";
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
        /// 根据hoilorder 的DataRow封装对象
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>hoilorder 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
        public HOilOrder GetObject(DataRow dr)
        {
            HOilOrder unit = new HOilOrder();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造HOilOrder类对象!";
                return unit;
            }
            if (DBNull.Value != dr["ORDER_ID"])
                unit.ORDER_ID = dr["ORDER_ID"].ToString();
            if (DBNull.Value != dr["APPLY_ID"])
                unit.APPLY_ID = dr["APPLY_ID"].ToString();
            if (DBNull.Value != dr["SHIP_ID"])
                unit.SHIP_ID = dr["SHIP_ID"].ToString();
            if (DBNull.Value != dr["CODE"])
                unit.CODE = dr["CODE"].ToString();
            if (DBNull.Value != dr["ORDER_DATE"])
                unit.ORDER_DATE = (DateTime)dr["ORDER_DATE"];
            if (DBNull.Value != dr["SUPPLY_DATE"])
                unit.SUPPLY_DATE = (DateTime)dr["SUPPLY_DATE"];
            if (DBNull.Value != dr["PORT_ID"])
                unit.PORT_ID = dr["PORT_ID"].ToString();
            if (DBNull.Value != dr["SUPPLIER_ID"])
                unit.SUPPLIER_ID = dr["SUPPLIER_ID"].ToString();
            if (DBNull.Value != dr["APPROVER"])
                unit.APPROVER = dr["APPROVER"].ToString();
            if (DBNull.Value != dr["CHECKED"])
                unit.CHECKED = Convert.ToDecimal(dr["CHECKED"]);
            if (DBNull.Value != dr["REMARK"])
                unit.REMARK = dr["REMARK"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个HOilOrder对象
        /// </summary>
        /// <param name="oRDER_ID">oRDER_ID</param>
        /// <returns>HOilOrder对象</returns>
        public HOilOrder GetObject(string Id)
        {
            try
            {
                DataTable dt = GetInfo(Id);
                return GetObject(dt.Rows[0]);
            }
            catch
            {
                return null;
            }
        }
        #endregion       
    }
}
