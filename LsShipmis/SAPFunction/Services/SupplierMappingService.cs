/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：SupplierMappingService.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/6/20
 * 标    题：数据操作类
 * 功能描述：T_SUPPLIER_MAPPING数据操作类
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
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using SAPFunction.DataObject;

namespace SAPFunction.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_SUPPLIER_MAPPINGService.cs
    /// </summary>
    public partial class SupplierMappingService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static SupplierMappingService instance = new SupplierMappingService();
        public static SupplierMappingService Instance
        {
            get
            {
                if (null == instance)
                {
                    SupplierMappingService.instance = new SupplierMappingService();
                }
                return SupplierMappingService.instance;
            }
        }
        private SupplierMappingService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">SupplierMapping对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(SupplierMapping unit, out string err)
        {
            if (unit.SUPPLIER_MAPPING_ID != null && unit.SUPPLIER_MAPPING_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_SUPPLIER_MAPPING] SET "
                    + " [SUPPLIER_MAPPING_ID] = " + (string.IsNullOrEmpty(unit.SUPPLIER_MAPPING_ID) ? "null" : "'" + unit.SUPPLIER_MAPPING_ID.Replace("'", "''") + "'")
                    + " , [MANAGEMENT] = " + (unit.MANAGEMENT == null ? "''" : "'" + unit.MANAGEMENT.Replace("'", "''") + "'")
                    + " , [FINANCE] = " + (unit.FINANCE == null ? "''" : "'" + unit.FINANCE.Replace("'", "''") + "'")
                    + " , [STATUS] = " + (unit.STATUS == null ? "''" : "'" + unit.STATUS.Replace("'", "''") + "'")
                    + " where upper(SUPPLIER_MAPPING_ID) = '" + unit.SUPPLIER_MAPPING_ID.ToUpper() + "'";
            }
            else
            {
                unit.SUPPLIER_MAPPING_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_SUPPLIER_MAPPING] ("
                    + "[SUPPLIER_MAPPING_ID],"
                    + "[MANAGEMENT],"
                    + "[FINANCE],"
                    + "[STATUS]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.SUPPLIER_MAPPING_ID) ? "null" : "'" + unit.SUPPLIER_MAPPING_ID.Replace("'", "''") + "'")
                    + " , " + (unit.MANAGEMENT == null ? "''" : "'" + unit.MANAGEMENT.Replace("'", "''") + "'")
                    + " , " + (unit.FINANCE == null ? "''" : "'" + unit.FINANCE.Replace("'", "''") + "'")
                    + " , " + (unit.STATUS == null ? "''" : "'" + unit.STATUS.Replace("'", "''") + "'")
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_SUPPLIER_MAPPING中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_SUPPLIER_MAPPING对象</param>
        internal bool deleteUnit(SupplierMapping unit, out string err)
        {
            return deleteUnit(unit.SUPPLIER_MAPPING_ID, out err);
        }

        /// <summary>
        /// 删除数据表T_SUPPLIER_MAPPING中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_SUPPLIER_MAPPING.sUPPLIER_MAPPING_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_SUPPLIER_MAPPING where "
                + " upper(T_SUPPLIER_MAPPING.SUPPLIER_MAPPING_ID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_SUPPLIER_MAPPING 所有数据信息.
        /// </summary>
        /// <returns>T_SUPPLIER_MAPPING DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select "
                 + "SUPPLIER_MAPPING_ID"
                 + ",MANAGEMENT"
                 + ",FINANCE"
                 + ",STATUS"
                 + " from T_SUPPLIER_MAPPING ";
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
        /// 根据一个主键ID,得到 T_SUPPLIER_MAPPING 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>SupplierMapping DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "SUPPLIER_MAPPING_ID"
                + ",MANAGEMENT"
                + ",FINANCE"
                + ",STATUS"
                + " from T_SUPPLIER_MAPPING "
                + " where upper(SUPPLIER_MAPPING_ID)='" + Id.ToUpper() + "'";
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
        /// 根据suppliermapping 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>suppliermapping 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
        public SupplierMapping getObject(DataRow dr)
        {
            SupplierMapping unit = new SupplierMapping();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造SupplierMapping类对象!";
                return unit;
            }
            if (DBNull.Value != dr["SUPPLIER_MAPPING_ID"])
                unit.SUPPLIER_MAPPING_ID = dr["SUPPLIER_MAPPING_ID"].ToString();
            if (DBNull.Value != dr["MANAGEMENT"])
                unit.MANAGEMENT = dr["MANAGEMENT"].ToString();
            if (DBNull.Value != dr["FINANCE"])
                unit.FINANCE = dr["FINANCE"].ToString();
            if (DBNull.Value != dr["STATUS"])
                unit.STATUS = dr["STATUS"].ToString();
            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个SupplierMapping对象.
        /// </summary>
        /// <param name="sUPPLIER_MAPPING_ID">sUPPLIER_MAPPING_ID</param>
        /// <returns>SupplierMapping对象</returns>
        public SupplierMapping getObject(string Id, out string err)
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
