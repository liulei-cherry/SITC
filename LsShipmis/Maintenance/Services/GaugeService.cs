/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：GaugeService.cs
 * 创 建 人：xuzhengben
 * 创建时间：2010/9/29
 * 标    题：数据操作类
 * 功能描述：Gauge数据操作类
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
    /// 数据层实例化接口类 dbo.GaugeService.cs
    /// </summary>
    public partial class GaugeService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static GaugeService instance = new GaugeService();
        public static GaugeService Instance
        {
            get
            {
                if (null == instance)
                {
                    GaugeService.instance = new GaugeService();
                }
                return GaugeService.instance;
            }
        }
        private GaugeService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region -----------实例化接口函数-----------

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">Gauge对象</param>
        /// <returns>插入的对象更新</returns>	
        public bool saveUnit(Gauge unit, out string err)
        {
            if (unit.GAUGE_ID != null && unit.GAUGE_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_GAUGE] SET "
                    + " [GAUGE_ID] = " + (string.IsNullOrEmpty(unit.GAUGE_ID) ? "null" : "'" + unit.GAUGE_ID.Replace("'", "''") + "'")
                    + " , [COMPONENT_UNIT_ID] = " + (string.IsNullOrEmpty(unit.COMPONENT_UNIT_ID) ? "null" : "'" + unit.COMPONENT_UNIT_ID.Replace("'", "''") + "'")
                    + " , [TOPUNIT] = " + unit.TOPUNIT.ToString()
                    + " , [PARENT_UNIT_ID] = " + (string.IsNullOrEmpty(unit.PARENT_UNIT_ID) ? "null" : "'" + unit.PARENT_UNIT_ID.Replace("'", "''") + "'")
                    + " , [GAUGE_TIME] = " + dbOperation.DbToDate(unit.GAUGE_TIME)
                    + " , [INPUT_TIME] = " + dbOperation.DbToDate(unit.INPUT_TIME)
                    + " , [TOTAL_WORKHOURS] = " + unit.TOTAL_WORKHOURS.ToString()
                    + " , [INCREASE_HOURS] = " + unit.INCREASE_HOURS.ToString()
                    + " , [RECORD_TYPE] = " + unit.RECORD_TYPE.ToString()
                    + " , [SEED] = " + unit.SEED.ToString()
                    + " , [SUBSEED] = " + unit.SUBSEED.ToString()
                    + " where upper(GAUGE_ID) = '" + unit.GAUGE_ID.ToUpper() + "'";
            }
            else
            {
                unit.GAUGE_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_GAUGE] ("
                    + "[GAUGE_ID],"
                    + "[COMPONENT_UNIT_ID],"
                    + "[TOPUNIT],"
                    + "[PARENT_UNIT_ID],"
                    + "[GAUGE_TIME],"
                    + "[INPUT_TIME],"
                    + "[TOTAL_WORKHOURS],"
                    + "[INCREASE_HOURS],"
                    + "[RECORD_TYPE],"
                    + "[SEED],"
                    + "[SUBSEED]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.GAUGE_ID) ? "null" : "'" + unit.GAUGE_ID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.COMPONENT_UNIT_ID) ? "null" : "'" + unit.COMPONENT_UNIT_ID.Replace("'", "''") + "'")
                    + " ," + unit.TOPUNIT.ToString()
                    + " , " + (string.IsNullOrEmpty(unit.PARENT_UNIT_ID) ? "null" : "'" + unit.PARENT_UNIT_ID.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.GAUGE_TIME)
                    + " ," + dbOperation.DbToDate(unit.INPUT_TIME)
                    + " ," + unit.TOTAL_WORKHOURS.ToString()
                    + " ," + unit.INCREASE_HOURS.ToString()
                    + " ," + unit.RECORD_TYPE.ToString()
                    + " ," + unit.SEED.ToString()
                    + " ," + unit.SUBSEED.ToString()
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_GAUGE中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_GAUGE对象</param>
        public bool deleteUnit(Gauge unit, out string err)
        {
            return deleteUnit(unit.GAUGE_ID, out err);
        }

        /// <summary>
        /// 删除数据表T_GAUGE中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_GAUGE.gAUGE_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_GAUGE where "
                + " upper(T_GAUGE.GAUGE_ID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_GAUGE 所有数据信息.
        /// </summary>
        /// <returns>T_GAUGE DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "GAUGE_ID"
                + ",COMPONENT_UNIT_ID"
                + ",TOPUNIT"
                + ",PARENT_UNIT_ID"
                + ",GAUGE_TIME"
                + ",INPUT_TIME"
                + ",TOTAL_WORKHOURS"
                + ",INCREASE_HOURS"
                + ",RECORD_TYPE"
                + ",SEED"
                + ",SUBSEED"
                + "  from T_GAUGE ";
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
        /// 根据一个主键ID,得到 T_GAUGE 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>Gauge DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "GAUGE_ID"
                + ",COMPONENT_UNIT_ID"
                + ",TOPUNIT"
                + ",PARENT_UNIT_ID"
                + ",GAUGE_TIME"
                + ",INPUT_TIME"
                + ",TOTAL_WORKHOURS"
                + ",INCREASE_HOURS"
                + ",RECORD_TYPE"
                + ",SEED"
                + ",SUBSEED"
                + " from T_GAUGE "
                + " where upper(GAUGE_ID)='" + Id.ToUpper() + "'";
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
        /// 根据gauge 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>gauge 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBoxEx.Show(o);
        public Gauge getObject(DataRow dr)
        {
            Gauge unit = new Gauge();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造Gauge类对象!";
                return unit;
            }
            if (DBNull.Value != dr["GAUGE_ID"])
                unit.GAUGE_ID = dr["GAUGE_ID"].ToString();
            if (DBNull.Value != dr["COMPONENT_UNIT_ID"])
                unit.COMPONENT_UNIT_ID = dr["COMPONENT_UNIT_ID"].ToString();
            if (DBNull.Value != dr["TOPUNIT"])
                unit.TOPUNIT = Convert.ToDecimal(dr["TOPUNIT"]);
            if (DBNull.Value != dr["PARENT_UNIT_ID"])
                unit.PARENT_UNIT_ID = dr["PARENT_UNIT_ID"].ToString();
            if (DBNull.Value != dr["GAUGE_TIME"])
                unit.GAUGE_TIME = (DateTime)dr["GAUGE_TIME"];
            if (DBNull.Value != dr["INPUT_TIME"])
                unit.INPUT_TIME = (DateTime)dr["INPUT_TIME"];
            if (DBNull.Value != dr["TOTAL_WORKHOURS"])
                unit.TOTAL_WORKHOURS = Convert.ToDecimal(dr["TOTAL_WORKHOURS"]);
            if (DBNull.Value != dr["INCREASE_HOURS"])
                unit.INCREASE_HOURS = Convert.ToDecimal(dr["INCREASE_HOURS"]);
            if (DBNull.Value != dr["RECORD_TYPE"])
                unit.RECORD_TYPE = Convert.ToDecimal(dr["RECORD_TYPE"]);
            if (DBNull.Value != dr["SEED"])
                unit.SEED = Convert.ToInt32(dr["SEED"]);
            if (DBNull.Value != dr["SUBSEED"])
                unit.SUBSEED = Convert.ToInt32(dr["SUBSEED"]);

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个Gauge对象.
        /// </summary>
        /// <param name="gAUGE_ID">gAUGE_ID</param>
        /// <returns>Gauge对象</returns>
        public Gauge getObject(string Id, out string err)
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
        ///  获得已初始化的设备计时组信息数据.
        /// </summary>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetTimingMainComp()
        {
            //变量定义部分.
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.

            //Select语句加工部分.
            sSql += " select ";
            sSql += " a.gauge_id,";
            sSql += " a.component_unit_id,";
            sSql += " b.comp_chinese_name,";
            sSql += " a.total_workhours,";
            sSql += " a.gauge_time,";
            sSql += " a.input_time,";
            sSql += " a.increase_hours,";
            sSql += " a.record_type,";
            sSql += "\rcase when a.record_type = 1 then '总值抄表'";
            sSql += "     when a.record_type = 2 then '递增抄表'";
            sSql += "     end as typename";
            sSql += "\rfrom t_gauge a left join t_component_unit b on a.component_unit_id = b.component_unit_id "
                 +  "\rleft join dbo.T_EQUIPMENT_CLASS_REF c on b.COMPONENT_UNIT_ID = c.COMPONENT_UNIT_ID ";
            sSql += "\rwhere  TopUnit=1";
            sSql += "\rorder by isnull(c.SORTNO,10000)*1000 + b.SortNo";
            dbAccess.GetDataTable(sSql,out dtb, out err);
            return dtb;
        }
        
        /// <summary>
        ///  获得设备的子设备.
        /// </summary>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetSunComponent(string Id)
        {
            //变量定义部分.
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.

            //Select语句加工部分.
            sSql += " select ";
            sSql += " b.comp_chinese_name,";
            sSql += " a.total_workhours,";
            sSql += " b.component_unit_id";
            sSql += " from t_gauge a ";
            sSql += " left join t_component_unit b on a.component_unit_id = b.component_unit_id ";
            sSql += " where  TopUnit=0 and a.Parent_unit_id ='" + Id.ToUpper() + "'";
            dbAccess.GetDataTable(sSql, out dtb,out err);
            return dtb;
        }

        /// <summary>
        /// 保存抄表、修改设备运转时和log记录.
        /// </summary>
        /// <param name="unit">T_GAUGE对象</param>
        /// <returns>插入的对象更新</returns>	
        public bool saveUnitAndLog(Gauge unit, out string err)
        {
            List<string> lstSqlOpt = new List<string>();//包含操作语句的List泛型集合.

            string sqlGauges = "";
            string sqlComponent = "";
            string sqlComponents = "";
            string sqlLog = "";

            if (!unit.Update(out err)) return false; //xuzhengben 2011.11.1修改 打破了原事务,但是对于新添加的guage可以保存,要再保留事务,就把update代码拷贝过来.

            if (!string.IsNullOrEmpty(unit.GAUGE_ID)) //edit
            {
                sqlGauges = "UPDATE [T_GAUGE] SET "
                       + "[GAUGE_TIME] = " + dbOperation.DbToDate(unit.GAUGE_TIME)
                + ","
                       + "[INPUT_TIME] = getDate()"
                    + ","
                    + "[TOTAL_WORKHOURS] = [TOTAL_WORKHOURS] + " + unit.INCREASE_HOURS
                    + ","
                    + "[INCREASE_HOURS] = " + unit.INCREASE_HOURS

                + " where upper(Parent_unit_id) = '" + unit.COMPONENT_UNIT_ID.ToUpper() + "'";
            }

            if (!string.IsNullOrEmpty(unit.COMPONENT_UNIT_ID)) //edit
            {
                sqlComponent = "UPDATE [T_COMPONENT_UNIT] SET "
                    + "[total_workhours] = " + unit.TOTAL_WORKHOURS
                + ","
                       + "[last_couter_time] = " + dbOperation.DbToDate(unit.GAUGE_TIME)
                + " where upper(COMPONENT_UNIT_ID) = '" + unit.COMPONENT_UNIT_ID.ToUpper() + "'";
            }

            if (!string.IsNullOrEmpty(unit.COMPONENT_UNIT_ID)) //edit
            {
                sqlComponents = "UPDATE [T_COMPONENT_UNIT] SET "
                    + "[total_workhours] = [total_workhours] + " + unit.INCREASE_HOURS
                + ","
                       + "[last_couter_time] = " + dbOperation.DbToDate(unit.GAUGE_TIME)
                + " where upper(COMPONENT_UNIT_ID)  in (  select COMPONENT_UNIT_ID from T_Gauge where Parent_unit_id = '" + unit.COMPONENT_UNIT_ID.ToUpper() + "')";
            }

            if (!string.IsNullOrEmpty(unit.GAUGE_ID)) //edit
            {
                string T_GAUGE_LOG_ID = Guid.NewGuid().ToString();
                sqlLog = "INSERT INTO [T_GAUGE_LOG] ("
                    + "[T_GAUGE_LOG_ID]"
                    + "," + "[COMPONENT_UNIT_ID]"
                    + "," + "[TOTAL_WORKHOURS]"
                    + "," + "[INCREASE_HOURS]"
                    + "," + "[GAUGE_TIME]"
                    + "," + "[RECORD_TYPE]"
                    + "," + "[INPUTOR]"
                + ") VALUES( '" + T_GAUGE_LOG_ID.Replace("'", "''") + "', '" + unit.COMPONENT_UNIT_ID.Replace("'", "''") + "'"
                    + ","  + unit.TOTAL_WORKHOURS+ ","+ unit.INCREASE_HOURS + ","+ dbOperation.DbToDate(unit.GAUGE_TIME)+ ","
                    + unit.RECORD_TYPE + "," + " '" + CommonOperation.ConstParameter.UserName + "')";
            }

            lstSqlOpt.Add(sqlGauges);
            lstSqlOpt.Add(sqlComponent);
            lstSqlOpt.Add(sqlComponents);
            lstSqlOpt.Add(sqlLog);

            //获得子设备DataTable
            DataTable components = getInfoByParentID(unit.COMPONENT_UNIT_ID);
            foreach (DataRow row in components.Rows)
            {
                string sqlGaugeLogs = "";
                string componentID = row["COMPONENT_UNIT_ID"].ToString();
                decimal totalWorkhours = decimal.Parse(row["TOTAL_WORKHOURS"].ToString()) + unit.INCREASE_HOURS;

                if (!string.IsNullOrEmpty(unit.GAUGE_ID)) //edit
                {
                    string T_GAUGE_LOG_ID =  Guid.NewGuid().ToString();
                    sqlGaugeLogs = "INSERT INTO [T_GAUGE_LOG] ("
                        + "[T_GAUGE_LOG_ID]"
                        + "," + "[COMPONENT_UNIT_ID]"
                        + "," + "[TOTAL_WORKHOURS]"
                        + "," + "[INCREASE_HOURS]"
                        + "," + "[GAUGE_TIME]"
                        + "," + "[RECORD_TYPE]"
                        + "," + "[INPUTOR]"
                    + ") VALUES( '" + T_GAUGE_LOG_ID.Replace("'", "''") + "'"
                         + ", '" + componentID.Replace("'", "''") + "',"
                        + totalWorkhours
                        + ","
                        + unit.INCREASE_HOURS
                        + ","
                          + dbOperation.DbToDate(unit.GAUGE_TIME)
                        + ","
                        + unit.RECORD_TYPE
                         + ", '" + CommonOperation.ConstParameter.UserName + "')";
                }
                lstSqlOpt.Add(sqlGaugeLogs);
            }
            //调用dbAccess的execSql执行lstSqlOpt中的所有的操作语句.
            return dbAccess.ExecSql(lstSqlOpt, out err);
        }

        /// <summary>
        /// 根据一个父设备ID,得到 T_GAUGE 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>T_GAUGE DataTable</returns>
        public DataTable getInfoByParentID(string Id)
        {
            DataTable dtb;
            string err;
            sql = string.Format(@"select  GAUGE_ID , COMPONENT_UNIT_ID , TOPUNIT , PARENT_UNIT_ID ,
                GAUGE_TIME , INPUT_TIME , TOTAL_WORKHOURS , INCREASE_HOURS ,
                RECORD_TYPE , SEED , SUBSEED
                from T_GAUGE 
                where upper(PARENT_UNIT_ID)='{0}'",Id.ToUpper());
            dbAccess.GetDataTable(sql, out dtb, out err);
            return dtb;
        }

        public Gauge getInfoByComponentUnitId(string Id)
        {
            string err;
            sql = "select "
               + "GAUGE_ID"
               + ",COMPONENT_UNIT_ID"
               + ",TOPUNIT"
               + ",PARENT_UNIT_ID"
               + ",GAUGE_TIME"
               + ",INPUT_TIME"
               + ",TOTAL_WORKHOURS"
               + ",INCREASE_HOURS"
               + ",RECORD_TYPE"
               + ",SEED"
               + ",SUBSEED"
               + " from T_GAUGE "
               + " where COMPONENT_UNIT_ID='" + Id.Replace("'","''") + "'";
            DataTable dt;
            if (dbAccess.GetDataTable(sql, out dt, out err) && dt.Rows.Count  >0)
            {
                return getObject(dt.Rows[0]);
            }
            else
            {
                throw new Exception(err);
            } 
        }
    }
}
