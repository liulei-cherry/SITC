/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：InternalOrderMappingService.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/6/17
 * 标    题：数据操作类
 * 功能描述：T_INTERNAL_ORDER_MAPPING数据操作类
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
    /// 数据层实例化接口类 dbo.T_INTERNAL_ORDER_MAPPINGService.cs
    /// </summary>
    public partial class InternalOrderMappingService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static InternalOrderMappingService instance = new InternalOrderMappingService();
        public static InternalOrderMappingService Instance
        {
            get
            {
                if (null == instance)
                {
                    InternalOrderMappingService.instance = new InternalOrderMappingService();
                }
                return InternalOrderMappingService.instance;
            }
        }
        private InternalOrderMappingService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">InternalOrderMapping对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(InternalOrderMapping unit, out string err)
        {
            if (unit.INTERNAL_ORDER_MAPPING_ID != null && unit.INTERNAL_ORDER_MAPPING_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_INTERNAL_ORDER_MAPPING] SET "
                    + " [INTERNAL_ORDER_MAPPING_ID] = " + (string.IsNullOrEmpty(unit.INTERNAL_ORDER_MAPPING_ID) ? "null" : "'" + unit.INTERNAL_ORDER_MAPPING_ID.Replace("'", "''") + "'")
                    + " , [SHIP_CODE] = " + (unit.SHIP_CODE == null ? "''" : "'" + unit.SHIP_CODE.Replace("'", "''") + "'")
                    + " , [ITEM_CODE] = " + (unit.ITEM_CODE == null ? "''" : "'" + unit.ITEM_CODE.Replace("'", "''") + "'")
                    + " , [INTERNAL_ORDER_FINANCE] = " + (unit.INTERNAL_ORDER_FINANCE == null ? "''" : "'" + unit.INTERNAL_ORDER_FINANCE.Replace("'", "''") + "'")
                    + " , [STATUS] = " + (unit.STATUS == null ? "''" : "'" + unit.STATUS.Replace("'", "''") + "'")
                    + " where upper(INTERNAL_ORDER_MAPPING_ID) = '" + unit.INTERNAL_ORDER_MAPPING_ID.ToUpper() + "'";
            }
            else
            {
                unit.INTERNAL_ORDER_MAPPING_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_INTERNAL_ORDER_MAPPING] ("
                    + "[INTERNAL_ORDER_MAPPING_ID],"
                    + "[SHIP_CODE],"
                    + "[ITEM_CODE],"
                    + "[INTERNAL_ORDER_FINANCE],"
                    + "[STATUS]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.INTERNAL_ORDER_MAPPING_ID) ? "null" : "'" + unit.INTERNAL_ORDER_MAPPING_ID.Replace("'", "''") + "'")
                    + " , " + (unit.SHIP_CODE == null ? "''" : "'" + unit.SHIP_CODE.Replace("'", "''") + "'")
                    + " , " + (unit.ITEM_CODE == null ? "''" : "'" + unit.ITEM_CODE.Replace("'", "''") + "'")
                    + " , " + (unit.INTERNAL_ORDER_FINANCE == null ? "''" : "'" + unit.INTERNAL_ORDER_FINANCE.Replace("'", "''") + "'")
                    + " , " + (unit.STATUS == null ? "''" : "'" + unit.STATUS.Replace("'", "''") + "'")
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_INTERNAL_ORDER_MAPPING中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_INTERNAL_ORDER_MAPPING对象</param>
        internal bool deleteUnit(InternalOrderMapping unit, out string err)
        {
            return deleteUnit(unit.INTERNAL_ORDER_MAPPING_ID, out err);
        }

        /// <summary>
        /// 删除数据表T_INTERNAL_ORDER_MAPPING中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_INTERNAL_ORDER_MAPPING.iNTERNAL_ORDER_MAPPING_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_INTERNAL_ORDER_MAPPING where "
                + " upper(T_INTERNAL_ORDER_MAPPING.INTERNAL_ORDER_MAPPING_ID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_INTERNAL_ORDER_MAPPING 所有数据信息.
        /// </summary>
        /// <returns>T_INTERNAL_ORDER_MAPPING DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select "
                 + "INTERNAL_ORDER_MAPPING_ID"
                 + ",SHIP_CODE"
                 + ",ITEM_CODE"
                 + ",INTERNAL_ORDER_FINANCE"
                 + ",STATUS"
                 + " from T_INTERNAL_ORDER_MAPPING ";
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
        /// 根据一个主键ID,得到 T_INTERNAL_ORDER_MAPPING 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>InternalOrderMapping DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "INTERNAL_ORDER_MAPPING_ID"
                + ",SHIP_CODE"
                + ",ITEM_CODE"
                + ",INTERNAL_ORDER_FINANCE"
                + ",STATUS"
                + " from T_INTERNAL_ORDER_MAPPING "
                + " where upper(INTERNAL_ORDER_MAPPING_ID)='" + Id.ToUpper() + "'";
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
        /// 根据internalordermapping 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>internalordermapping 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
        public InternalOrderMapping getObject(DataRow dr)
        {
            InternalOrderMapping unit = new InternalOrderMapping();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造InternalOrderMapping类对象!";
                return unit;
            }
            if (DBNull.Value != dr["INTERNAL_ORDER_MAPPING_ID"])
                unit.INTERNAL_ORDER_MAPPING_ID = dr["INTERNAL_ORDER_MAPPING_ID"].ToString();
            if (DBNull.Value != dr["SHIP_CODE"])
                unit.SHIP_CODE = dr["SHIP_CODE"].ToString();
            if (DBNull.Value != dr["ITEM_CODE"])
                unit.ITEM_CODE = dr["ITEM_CODE"].ToString();
            if (DBNull.Value != dr["INTERNAL_ORDER_FINANCE"])
                unit.INTERNAL_ORDER_FINANCE = dr["INTERNAL_ORDER_FINANCE"].ToString();
            if (DBNull.Value != dr["STATUS"])
                unit.STATUS = dr["STATUS"].ToString();
            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个InternalOrderMapping对象.
        /// </summary>
        /// <param name="iNTERNAL_ORDER_MAPPING_ID">iNTERNAL_ORDER_MAPPING_ID</param>
        /// <returns>InternalOrderMapping对象</returns>
        public InternalOrderMapping getObject(string Id, out string err)
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
