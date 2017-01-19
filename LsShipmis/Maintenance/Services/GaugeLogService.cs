/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：GaugeLogService.cs
 * 创 建 人：xuzhengben
 * 创建时间：2010/9/29
 * 标    题：数据操作类
 * 功能描述：T_GAUGE_LOG数据操作类
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
using ItemsManage.DataObject;

namespace ItemsManage.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.GaugeLogService.cs
    /// </summary>
    public partial class GaugeLogService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static GaugeLogService instance = new GaugeLogService();
        public static GaugeLogService Instance
        {
            get
            {
                if (null == instance)
                {
                    GaugeLogService.instance = new GaugeLogService();
                }
                return GaugeLogService.instance;
            }
        }
        private GaugeLogService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region -----------实例化接口函数-----------

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">GaugeLog对象</param>
        /// <returns>插入的对象更新</returns>	
        public bool saveUnit(GaugeLog unit, out string err)
        {
            if (unit.T_GAUGE_LOG_ID != null && unit.T_GAUGE_LOG_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_GAUGE_LOG] SET "
                    + " [T_GAUGE_LOG_ID] = " + (string.IsNullOrEmpty(unit.T_GAUGE_LOG_ID) ? "null" : "'" + unit.T_GAUGE_LOG_ID.Replace("'", "''") + "'")
                    + " , [COMPONENT_UNIT_ID] = " + (string.IsNullOrEmpty(unit.COMPONENT_UNIT_ID) ? "null" : "'" + unit.COMPONENT_UNIT_ID.Replace("'", "''") + "'")
                    + " , [TOTAL_WORKHOURS] = " + unit.TOTAL_WORKHOURS.ToString()
                    + " , [INCREASE_HOURS] = " + unit.INCREASE_HOURS.ToString()
                    + " , [GAUGE_TIME] = " + dbOperation.DbToDate(unit.GAUGE_TIME)
                    + " , [INPUT_TIME] = " + dbOperation.DbToDate(unit.INPUT_TIME)
                    + " , [RECORD_TYPE] = " + unit.RECORD_TYPE.ToString()
                    + " , [INPUTOR] = " + (unit.INPUTOR == null ? "" : "'" + unit.INPUTOR.Replace("'", "''")) + "'"
                    + " where upper(T_GAUGE_LOG_ID) = '" + unit.T_GAUGE_LOG_ID.ToUpper() + "'";
            }
            else
            {
                unit.T_GAUGE_LOG_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_GAUGE_LOG] ("
                    + "[T_GAUGE_LOG_ID],"
                    + "[COMPONENT_UNIT_ID],"
                    + "[TOTAL_WORKHOURS],"
                    + "[INCREASE_HOURS],"
                    + "[GAUGE_TIME],"
                    + "[INPUT_TIME],"
                    + "[RECORD_TYPE],"
                    + "[INPUTOR],"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.T_GAUGE_LOG_ID) ? "null" : "'" + unit.T_GAUGE_LOG_ID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.COMPONENT_UNIT_ID) ? "null" : "'" + unit.COMPONENT_UNIT_ID.Replace("'", "''") + "'")
                    + " ," + unit.TOTAL_WORKHOURS.ToString()
                    + " ," + unit.INCREASE_HOURS.ToString()
                    + " ," + dbOperation.DbToDate(unit.GAUGE_TIME)
                    + " ," + dbOperation.DbToDate(unit.INPUT_TIME)
                    + " ," + unit.RECORD_TYPE.ToString()
                    + " , " + (unit.INPUTOR == null ? "''" : "'" + unit.INPUTOR.Replace("'", "''")) + "'"
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_GAUGE_LOG中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_GAUGE_LOG对象</param>
        public bool deleteUnit(GaugeLog unit, out string err)
        {
            return deleteUnit(unit.T_GAUGE_LOG_ID, out err);
        }

        /// <summary>
        /// 删除数据表T_GAUGE_LOG中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_GAUGE_LOG.t_GAUGE_LOG_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_GAUGE_LOG where "
                + " upper(T_GAUGE_LOG.T_GAUGE_LOG_ID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_GAUGE_LOG 所有数据信息.
        /// </summary>
        /// <returns>T_GAUGE_LOG DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "T_GAUGE_LOG_ID"
                + ",COMPONENT_UNIT_ID"
                + ",TOTAL_WORKHOURS"
                + ",INCREASE_HOURS"
                + ",GAUGE_TIME"
                + ",INPUT_TIME"
                + ",RECORD_TYPE"
                + ",INPUTOR"
                + "  from T_GAUGE_LOG ";
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
        /// 根据一个主键ID,得到 T_GAUGE_LOG 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>GaugeLog DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "T_GAUGE_LOG_ID"
                + ",COMPONENT_UNIT_ID"
                + ",TOTAL_WORKHOURS"
                + ",INCREASE_HOURS"
                + ",GAUGE_TIME"
                + ",INPUT_TIME"
                + ",RECORD_TYPE"
                + ",INPUTOR"
                + " from T_GAUGE_LOG "
                + " where upper(T_GAUGE_LOG_ID)='" + Id.ToUpper() + "'";
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
        /// 根据gaugelog 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>gaugelog 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBoxEx.Show(o);
        public GaugeLog getObject(DataRow dr)
        {
            GaugeLog unit = new GaugeLog();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造GaugeLog类对象!";
                return unit;
            }
            if (DBNull.Value != dr["T_GAUGE_LOG_ID"])
                unit.T_GAUGE_LOG_ID = dr["T_GAUGE_LOG_ID"].ToString();
            if (DBNull.Value != dr["COMPONENT_UNIT_ID"])
                unit.COMPONENT_UNIT_ID = dr["COMPONENT_UNIT_ID"].ToString();
            if (DBNull.Value != dr["TOTAL_WORKHOURS"])
                unit.TOTAL_WORKHOURS = Convert.ToDecimal(dr["TOTAL_WORKHOURS"]);
            if (DBNull.Value != dr["INCREASE_HOURS"])
                unit.INCREASE_HOURS = Convert.ToDecimal(dr["INCREASE_HOURS"]);
            if (DBNull.Value != dr["GAUGE_TIME"])
                unit.GAUGE_TIME = (DateTime)dr["GAUGE_TIME"];
            if (DBNull.Value != dr["INPUT_TIME"])
                unit.INPUT_TIME = (DateTime)dr["INPUT_TIME"];
            if (DBNull.Value != dr["RECORD_TYPE"])
                unit.RECORD_TYPE = Convert.ToDecimal(dr["RECORD_TYPE"]);
            if (DBNull.Value != dr["INPUTOR"])
                unit.INPUTOR = dr["INPUTOR"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个GaugeLog对象.
        /// </summary>
        /// <param name="t_GAUGE_LOG_ID">t_GAUGE_LOG_ID</param>
        /// <returns>GaugeLog对象</returns>
        public GaugeLog getObject(string Id, out string err)
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

        /// <summary>
        /// 根据一个主键ID,得到 T_GAUGE_LOG 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>T_GAUGE_LOG DataTable</returns>
        public DataTable getInfoTopFive(string Id, out string err)
        {
            DataTable dtb; 
            sql = "select  top 5  T_GAUGE_LOG_ID"
                 + ","
                + "COMPONENT_UNIT_ID"
                 + ","
                + "TOTAL_WORKHOURS"
                 + ","
                + "INCREASE_HOURS"
                 + ","
                + "GAUGE_TIME"
                 + ","
                + "INPUT_TIME"
                 + ","
                + "RECORD_TYPE"
                 + ","
                + "INPUTOR"
                + "\rfrom T_GAUGE_LOG "
                + "\rwhere upper(COMPONENT_UNIT_ID)='" + Id.ToUpper() + "'"
                + "\rorder by  Gauge_TIME desc";
            dbAccess.GetDataTable(sql,out dtb, out err);
            return dtb;
        }

    }
}
