/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：VoyageService.cs
 * 创 建 人：xuzhengben
 * 创建时间：2010-12-30
 * 标    题：数据操作类
 * 功能描述：T_VOY_VOYTIMES数据操作类
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
    /// 数据层实例化接口类 dbo.T_VOY_VOYTIMESService.cs
    /// </summary>
    public partial class VoyageService : IObjectsService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static VoyageService instance = new VoyageService();
        public static VoyageService Instance
        {
            get
            {
                if (null == instance)
                {
                    VoyageService.instance = new VoyageService();
                }
                return VoyageService.instance;
            }
        }
        private VoyageService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">Voyage对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(Voyage unit, out string err)
        {
            if (unit.VOYTIMESID != null && unit.VOYTIMESID.Length > 0) //edit
            {
                sql = "UPDATE [T_VOY_VOYTIMES] SET "
                    + " [VOYTIMESID] = " + (string.IsNullOrEmpty(unit.VOYTIMESID) ? "null" : "'" + unit.VOYTIMESID.Replace("'", "''") + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , [VOYTIMESNAME] = " + (unit.VOYTIMESNAME == null ? "" : "'" + unit.VOYTIMESNAME.Replace("'", "''")) + "'"
                    + " , [STARTDATE] = " + dbOperation.DbToDate(unit.STARTDATE)
                    + " , [ENDDATE] = " + dbOperation.DbToDate(unit.ENDDATE)
                    + " , [REMARK] = " + (unit.REMARK == null ? "" : "'" + unit.REMARK.Replace("'", "''")) + "'"
                    + " where upper(VOYTIMESID) = '" + unit.VOYTIMESID.ToUpper() + "'";
            }
            else
            {
                unit.VOYTIMESID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_VOY_VOYTIMES] ("
                    + "[VOYTIMESID],"
                    + "[SHIP_ID],"
                    + "[VOYTIMESNAME],"
                    + "[STARTDATE],"
                    + "[ENDDATE],"
                    + "[REMARK]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.VOYTIMESID) ? "null" : "'" + unit.VOYTIMESID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , " + (unit.VOYTIMESNAME == null ? "''" : "'" + unit.VOYTIMESNAME.Replace("'", "''")) + "'"
                    + " ," + dbOperation.DbToDate(unit.STARTDATE)
                    + " ," + dbOperation.DbToDate(unit.ENDDATE)
                    + " , " + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''")) + "'"
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_VOY_VOYTIMES中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_VOY_VOYTIMES对象</param>
        internal bool deleteUnit(Voyage unit, out string err)
        {
            return deleteUnit(unit.VOYTIMESID, out err);
        }

        /// <summary>
        /// 删除数据表T_VOY_VOYTIMES中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_VOY_VOYTIMES.vOYTIMESID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_VOY_VOYTIMES where "
                + " upper(T_VOY_VOYTIMES.VOYTIMESID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
    
        /// <summary>
        /// 根据voyage 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>voyage 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBoxEx.Show(o);
        public Voyage getObject(DataRow dr)
        {
            Voyage unit = new Voyage();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造Voyage类对象!";
                return unit;
            }
            if (DBNull.Value != dr["VOYTIMESID"])
                unit.VOYTIMESID = dr["VOYTIMESID"].ToString();
            if (DBNull.Value != dr["SHIP_ID"])
                unit.SHIP_ID = dr["SHIP_ID"].ToString();
            if (DBNull.Value != dr["VOYTIMESNAME"])
                unit.VOYTIMESNAME = dr["VOYTIMESNAME"].ToString();
            if (DBNull.Value != dr["STARTDATE"])
                unit.STARTDATE = (DateTime)dr["STARTDATE"];
            if (DBNull.Value != dr["ENDDATE"])
                unit.ENDDATE = (DateTime)dr["ENDDATE"];
            if (DBNull.Value != dr["REMARK"])
                unit.REMARK = dr["REMARK"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个Voyage对象.
        /// </summary>
        /// <param name="vOYTIMESID">vOYTIMESID</param>
        /// <returns>Voyage对象</returns>
        public Voyage getObject(string Id, out string err)
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

        #region IObjectsService 成员

        public CommonOperation.BaseClass.CommonClass GetOneObjectById(string id)
        {
            string err;
            return getObject(id, out err);
        }

        public Dictionary<string, string> GetObjectDisplaySetting()
        {
            Dictionary<string, string> reValue = new Dictionary<string, string>();
            reValue.Add("VOYTIMESNAME", "航次名称");
            reValue.Add("SHIP_NAME", "船舶名称");            
            reValue.Add("STARTDATE", "开始日期");
            reValue.Add("ENDDATE", "结束日期");
            reValue.Add("REMARK", "航次说明");
            return reValue;
        }

        #endregion
        /// <summary>
        /// 得到  T_VOY_VOYTIMES 所有数据信息.
        /// </summary>
        /// <returns>T_VOY_VOYTIMES DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "t1.VOYTIMESID"
                + ",t1.SHIP_ID"
                + ",t1.VOYTIMESNAME"
                + ",t1.STARTDATE"
                + ",t1.ENDDATE"
                + ",t1.REMARK,t2.SHIP_NAME"
                + "\rfrom T_VOY_VOYTIMES t1 left join t_ship t2 on t1.ship_id = t2.ship_id"
                + "\rorder by t1.startDate";
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
        /// 根据一个主键ID,得到 T_VOY_VOYTIMES 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>Voyage DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select	"
                + "t1.VOYTIMESID"
                + ",t1.SHIP_ID"
                + ",t1.VOYTIMESNAME"
                + ",t1.STARTDATE"
                + ",t1.ENDDATE"
                + ",t1.REMARK,t2.SHIP_NAME"
                + "\rfrom T_VOY_VOYTIMES t1 left join t_ship t2 on t1.ship_id = t2.ship_id"
                + "\rwhere upper(VOYTIMESID)='" + Id.ToUpper() + "'";
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
    }
}
