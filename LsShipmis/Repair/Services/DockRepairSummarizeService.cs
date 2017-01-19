/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：DockRepairSummarizeService.cs
 * 创 建 人：王鹏程
 * 创建时间：2012/1/16
 * 标    题：数据操作类
 * 功能描述：T_DOCKREPAIR_SUMMARIZE数据操作类
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
using Repair.DataObject;

namespace Repair.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_DOCKREPAIR_SUMMARIZEService.cs
    /// </summary>
    public partial class DockRepairSummarizeService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static DockRepairSummarizeService instance = new DockRepairSummarizeService();
        public static DockRepairSummarizeService Instance
        {
            get
            {
                if (null == instance)
                {
                    DockRepairSummarizeService.instance = new DockRepairSummarizeService();
                }
                return DockRepairSummarizeService.instance;
            }
        }
        private DockRepairSummarizeService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">DockRepairSummarize对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(DockRepairSummarize unit, out string err)
        {
            if (unit.DOCKREPAIR_SUMMARIZE_ID != null && unit.DOCKREPAIR_SUMMARIZE_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_DOCKREPAIR_SUMMARIZE] SET "
                    + " [DOCKREPAIR_SUMMARIZE_ID] = " + (string.IsNullOrEmpty(unit.DOCKREPAIR_SUMMARIZE_ID) ? "null" : "'" + unit.DOCKREPAIR_SUMMARIZE_ID.Replace("'", "''") + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , [BEGINDATE] = " + dbOperation.DbToDate(unit.BEGINDATE)
                    + " , [ENDDATE] = " + dbOperation.DbToDate(unit.ENDDATE)
                    + " , [NODE_ID] = " + (string.IsNullOrEmpty(unit.NODE_ID) ? "null" : "'" + unit.NODE_ID.Replace("'", "''") + "'")
                    + " , [MANUFACTURER_ID] = " + (string.IsNullOrEmpty(unit.MANUFACTURER_ID) ? "null" : "'" + unit.MANUFACTURER_ID.Replace("'", "''") + "'")
                    + " , [TOTAL_AMOUNT] = " + unit.TOTAL_AMOUNT.ToString()
                    + " , [ESTIMATE_AMOUNT] = " + unit.ESTIMATE_AMOUNT.ToString()
                    + " , [CURRENCY_ID] = " + (string.IsNullOrEmpty(unit.CURRENCY_ID) ? "null" : "'" + unit.CURRENCY_ID.Replace("'", "''") + "'")
                    + " where upper(DOCKREPAIR_SUMMARIZE_ID) = '" + unit.DOCKREPAIR_SUMMARIZE_ID.ToUpper() + "'";
            }
            else
            {
                unit.DOCKREPAIR_SUMMARIZE_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_DOCKREPAIR_SUMMARIZE] ("
                    + "[DOCKREPAIR_SUMMARIZE_ID],"
                    + "[SHIP_ID],"
                    + "[BEGINDATE],"
                    + "[ENDDATE],"
                    + "[NODE_ID],"
                    + "[MANUFACTURER_ID],"
                    + "[TOTAL_AMOUNT],"
                    + "[ESTIMATE_AMOUNT],"
                    + "[CURRENCY_ID]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.DOCKREPAIR_SUMMARIZE_ID) ? "null" : "'" + unit.DOCKREPAIR_SUMMARIZE_ID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.BEGINDATE)
                    + " ," + dbOperation.DbToDate(unit.ENDDATE)
                    + " , " + (string.IsNullOrEmpty(unit.NODE_ID) ? "null" : "'" + unit.NODE_ID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.MANUFACTURER_ID) ? "null" : "'" + unit.MANUFACTURER_ID.Replace("'", "''") + "'")
                    + " ," + unit.TOTAL_AMOUNT.ToString()
                    + " ," + unit.ESTIMATE_AMOUNT.ToString()
                    + " , " + (string.IsNullOrEmpty(unit.CURRENCY_ID) ? "null" : "'" + unit.CURRENCY_ID.Replace("'", "''") + "'")
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 向数据库中保存一条新记录。返回sql
        /// </summary>
        /// <param name="unit">DockRepairSummarize对象</param>
        /// <returns>插入的对象更新</returns>	
        internal string saveUnit(DockRepairSummarize unit)
        {
            if (unit.DOCKREPAIR_SUMMARIZE_ID != null && unit.DOCKREPAIR_SUMMARIZE_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_DOCKREPAIR_SUMMARIZE] SET "
                    + " [DOCKREPAIR_SUMMARIZE_ID] = " + (string.IsNullOrEmpty(unit.DOCKREPAIR_SUMMARIZE_ID) ? "null" : "'" + unit.DOCKREPAIR_SUMMARIZE_ID.Replace("'", "''") + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , [BEGINDATE] = " + dbOperation.DbToDate(unit.BEGINDATE)
                    + " , [ENDDATE] = " + dbOperation.DbToDate(unit.ENDDATE)
                    + " , [NODE_ID] = " + (string.IsNullOrEmpty(unit.NODE_ID) ? "null" : "'" + unit.NODE_ID.Replace("'", "''") + "'")
                    + " , [MANUFACTURER_ID] = " + (string.IsNullOrEmpty(unit.MANUFACTURER_ID) ? "null" : "'" + unit.MANUFACTURER_ID.Replace("'", "''") + "'")
                    + " , [TOTAL_AMOUNT] = " + unit.TOTAL_AMOUNT.ToString()
                    + " , [ESTIMATE_AMOUNT] = " + unit.ESTIMATE_AMOUNT.ToString()
                    + " , [CURRENCY_ID] = " + (string.IsNullOrEmpty(unit.CURRENCY_ID) ? "null" : "'" + unit.CURRENCY_ID.Replace("'", "''") + "'")
                    + " where upper(DOCKREPAIR_SUMMARIZE_ID) = '" + unit.DOCKREPAIR_SUMMARIZE_ID.ToUpper() + "'";
            }
            else
            {
                unit.DOCKREPAIR_SUMMARIZE_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_DOCKREPAIR_SUMMARIZE] ("
                    + "[DOCKREPAIR_SUMMARIZE_ID],"
                    + "[SHIP_ID],"
                    + "[BEGINDATE],"
                    + "[ENDDATE],"
                    + "[NODE_ID],"
                    + "[MANUFACTURER_ID],"
                    + "[TOTAL_AMOUNT],"
                    + "[ESTIMATE_AMOUNT],"
                    + "[CURRENCY_ID]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.DOCKREPAIR_SUMMARIZE_ID) ? "null" : "'" + unit.DOCKREPAIR_SUMMARIZE_ID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.BEGINDATE)
                    + " ," + dbOperation.DbToDate(unit.ENDDATE)
                    + " , " + (string.IsNullOrEmpty(unit.NODE_ID) ? "null" : "'" + unit.NODE_ID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.MANUFACTURER_ID) ? "null" : "'" + unit.MANUFACTURER_ID.Replace("'", "''") + "'")
                    + " ," + unit.TOTAL_AMOUNT.ToString()
                    + " ," + unit.ESTIMATE_AMOUNT.ToString()
                    + " , " + (string.IsNullOrEmpty(unit.CURRENCY_ID) ? "null" : "'" + unit.CURRENCY_ID.Replace("'", "''") + "'")
                    + ")";
            }

            return sql;
        }
        /// <summary>
        /// 删除数据表T_DOCKREPAIR_SUMMARIZE中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_DOCKREPAIR_SUMMARIZE对象</param>
        internal bool deleteUnit(DockRepairSummarize unit, out string err)
        {
            return deleteUnit(unit.DOCKREPAIR_SUMMARIZE_ID, out err);
        }

        /// <summary>
        /// 删除数据表T_DOCKREPAIR_SUMMARIZE中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_DOCKREPAIR_SUMMARIZE.dOCKREPAIR_SUMMARIZE_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_DOCKREPAIR_SUMMARIZE where "
                + " upper(T_DOCKREPAIR_SUMMARIZE.DOCKREPAIR_SUMMARIZE_ID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_DOCKREPAIR_SUMMARIZE 所有数据信息.
        /// </summary>
        /// <returns>T_DOCKREPAIR_SUMMARIZE DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "DOCKREPAIR_SUMMARIZE_ID"
                + ",SHIP_ID"
                + ",BEGINDATE"
                + ",ENDDATE"
                + ",NODE_ID"
                + ",MANUFACTURER_ID"
                + ",TOTAL_AMOUNT"
                + ",ESTIMATE_AMOUNT"
                + ",CURRENCY_ID"
                + "  from T_DOCKREPAIR_SUMMARIZE ";
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
        /// 根据一个主键ID,得到 T_DOCKREPAIR_SUMMARIZE 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>DockRepairSummarize DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "DOCKREPAIR_SUMMARIZE_ID"
                + ",SHIP_ID"
                + ",BEGINDATE"
                + ",ENDDATE"
                + ",NODE_ID"
                + ",MANUFACTURER_ID"
                + ",TOTAL_AMOUNT"
                + ",ESTIMATE_AMOUNT"
                + ",CURRENCY_ID"
                + " from T_DOCKREPAIR_SUMMARIZE "
                + " where upper(DOCKREPAIR_SUMMARIZE_ID)='" + Id.ToUpper() + "'";
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
        /// 根据dockrepairsummarize 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>dockrepairsummarize 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
        public DockRepairSummarize getObject(DataRow dr)
        {
            DockRepairSummarize unit = new DockRepairSummarize();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造DockRepairSummarize类对象!";
                return unit;
            }
            if (DBNull.Value != dr["DOCKREPAIR_SUMMARIZE_ID"])
                unit.DOCKREPAIR_SUMMARIZE_ID = dr["DOCKREPAIR_SUMMARIZE_ID"].ToString();
            if (DBNull.Value != dr["SHIP_ID"])
                unit.SHIP_ID = dr["SHIP_ID"].ToString();
            if (DBNull.Value != dr["BEGINDATE"])
                unit.BEGINDATE = (DateTime)dr["BEGINDATE"];
            if (DBNull.Value != dr["ENDDATE"])
                unit.ENDDATE = (DateTime)dr["ENDDATE"];
            if (DBNull.Value != dr["NODE_ID"])
                unit.NODE_ID = dr["NODE_ID"].ToString();
            if (DBNull.Value != dr["MANUFACTURER_ID"])
                unit.MANUFACTURER_ID = dr["MANUFACTURER_ID"].ToString();
            if (DBNull.Value != dr["TOTAL_AMOUNT"])
                unit.TOTAL_AMOUNT = Convert.ToDecimal(dr["TOTAL_AMOUNT"]);
            if (DBNull.Value != dr["ESTIMATE_AMOUNT"])
                unit.ESTIMATE_AMOUNT = Convert.ToDecimal(dr["ESTIMATE_AMOUNT"]);
            if (DBNull.Value != dr["CURRENCY_ID"])
                unit.CURRENCY_ID = dr["CURRENCY_ID"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个DockRepairSummarize对象.
        /// </summary>
        /// <param name="dOCKREPAIR_SUMMARIZE_ID">dOCKREPAIR_SUMMARIZE_ID</param>
        /// <returns>DockRepairSummarize对象</returns>
        public DockRepairSummarize getObject(string Id, out string err)
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
