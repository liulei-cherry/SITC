/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：ScheduleTypeService.cs
 * 创 建 人：xuzhengben
 * 创建时间：2009-9-30
 * 标    题：数据操作类
 * 功能描述：T_SCHEDULE_TYPE数据操作类
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
    /// 数据层实例化接口类 dbo.T_SCHEDULE_TYPEService.cs
    /// </summary>
    public partial class ScheduleTypeService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static ScheduleTypeService instance = new ScheduleTypeService();
        public static ScheduleTypeService Instance
        {
            get
            {
                if (null == instance)
                {
                    ScheduleTypeService.instance = new ScheduleTypeService();
                }
                return ScheduleTypeService.instance;
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
        /// <param name="unit">ScheduleType对象</param>
        /// <returns>插入的对象更新</returns>	
        public bool saveUnit(ScheduleType unit, out string err)
        {
            if (unit.SCHEDULETYPEID != null && unit.SCHEDULETYPEID.Length > 0) //edit
            {
                sql = "UPDATE [T_SCHEDULE_TYPE] SET "
                    + " [SCHEDULETYPEID] = '" + (unit.SCHEDULETYPEID == null ? "" : unit.SCHEDULETYPEID.Replace("'", "''")) + "'"
                    + " , [TYPENAME] = '" + (unit.TYPENAME == null ? "" : unit.TYPENAME.Replace("'", "''")) + "'"
                    + " , [DETAIL] = '" + (unit.DETAIL == null ? "" : unit.DETAIL.Replace("'", "''")) + "'"
                    + " , [ISWORKING] = " + unit.ISWORKING
                    + " , [SORT] = " + unit.SORT
                    + " where upper(SCHEDULETYPEID) = '" + unit.SCHEDULETYPEID.ToUpper() + "'";
            }
            else
            {
                unit.SCHEDULETYPEID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_SCHEDULE_TYPE] ("
                    + "[SCHEDULETYPEID],"
                    + "[TYPENAME],"
                    + "[DETAIL],"
                    + "[ISWORKING],"
                    + "[SORT]"
                    + ") VALUES( "
                    + " '" + (unit.SCHEDULETYPEID == null ? "" : unit.SCHEDULETYPEID.Replace("'", "''")) + "'"
                    + " , '" + (unit.TYPENAME == null ? "" : unit.TYPENAME.Replace("'", "''")) + "'"
                    + " , '" + (unit.DETAIL == null ? "" : unit.DETAIL.Replace("'", "''")) + "'"
                    + " ," + unit.ISWORKING
                    + " ," + unit.SORT
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_SCHEDULE_TYPE中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_SCHEDULE_TYPE对象</param>
        public bool deleteUnit(ScheduleType unit, out string err)
        {
            
            return deleteUnit(unit.SCHEDULETYPEID, out err);
        }

        /// <summary>
        /// 删除数据表T_SCHEDULE_TYPE中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_SCHEDULE_TYPE.sCHEDULETYPEID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {

            sql = "delete from T_SCHEDULE_TYPE where "
                + " upper(T_SCHEDULE_TYPE.SCHEDULETYPEID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_SCHEDULE_TYPE 所有数据信息.
        /// </summary>
        /// <returns>T_SCHEDULE_TYPE DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "SCHEDULETYPEID, "
                + "TYPENAME, "
                + "DETAIL, "
                + "ISWORKING, "
                + "SORT"
                + "  from T_SCHEDULE_TYPE order by SORT ";
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
        /// 根据一个主键ID,得到 T_SCHEDULE_TYPE 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>ScheduleType DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "SCHEDULETYPEID, "
                + "TYPENAME, "
                + "DETAIL, "
                + "ISWORKING, "
                + "SORT"
                + " from T_SCHEDULE_TYPE "
                + " where upper(SCHEDULETYPEID)='" + Id.ToUpper() + "'";
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
        /// 根据scheduletype 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>scheduletype 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBoxEx.Show(o);
        public ScheduleType getObject(DataRow dr)
        {
            ScheduleType unit = new ScheduleType();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造ScheduleType类对象!";
                return unit;
            }
            if (DBNull.Value != dr["SCHEDULETYPEID"])
                unit.SCHEDULETYPEID = dr["SCHEDULETYPEID"].ToString();
            if (DBNull.Value != dr["TYPENAME"])
                unit.TYPENAME = dr["TYPENAME"].ToString();
            if (DBNull.Value != dr["DETAIL"])
                unit.DETAIL = dr["DETAIL"].ToString();
            if (DBNull.Value != dr["ISWORKING"])
                unit.ISWORKING = Convert.ToDecimal(dr["ISWORKING"]);
            if (DBNull.Value != dr["SORT"])
                unit.SORT = Convert.ToDecimal(dr["SORT"]);

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个ScheduleType对象.
        /// </summary>
        /// <param name="sCHEDULETYPEID">sCHEDULETYPEID</param>
        /// <returns>ScheduleType对象</returns>
        public ScheduleType getObject(string Id, out string err)
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

        public string getMaxSort()
        {
            sql = "select top 1  SORT from T_SCHEDULE_TYPE order by SORT desc";
            string sort = dbAccess.GetString(sql);
            return sort;

        }
    }
}
