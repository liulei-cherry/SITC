/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：WorkOrderService.cs
 * 创 建 人：徐正本
 * 创建时间：2010-6-21
 * 标    题：数据操作类
 * 功能描述：WorkOrder数据操作类
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
using Maintenance.DataObject;
using ItemsManage.DataObject;
using ItemsManage.Services;

namespace Maintenance.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.WorkOrderService.cs
    /// </summary>
    public partial class WorkOrderService
    {
        #region 构造函数

        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static WorkOrderService instance = new WorkOrderService();
        public static WorkOrderService Instance
        {
            get
            {
                if (null == instance)
                {
                    WorkOrderService.instance = new WorkOrderService();
                }
                return WorkOrderService.instance;
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
        /// <param name="unit">WorkOrder对象</param>
        /// <returns>插入的对象更新</returns>	
        public bool saveUnit(WorkOrder unit, out string err)
        {
            if (unit.WORKORDERID != null && unit.WORKORDERID.Length > 0) //edit
            {
                sql = "UPDATE [t_workorder] SET "
                    + " [WORKORDERID] = " + (string.IsNullOrEmpty(unit.WORKORDERID) ? "null" : "'" + unit.WORKORDERID.Replace("'", "''") + "'")
                    + " , [WORKINFOID] = " + (string.IsNullOrEmpty(unit.WORKINFOID) ? "null" : "'" + unit.WORKINFOID.Replace("'", "''") + "'")
                    + " , [WORKORDERNAME] = N'" + (unit.WORKORDERNAME == null ? "" : unit.WORKORDERNAME.Replace("'", "''")) + "'"
                    + " , [WORKORDERSTATE] = " + unit.WORKORDERSTATE.ToString()
                    + " , [PLANEXEDATE] = " + dbOperation.DbToDate(unit.PLANEXEDATE)
                    + " , [COMPLETEDDATE] = " + dbOperation.DbToDate(unit.COMPLETEDDATE)
                    + " , [CIRCLEFRONTLIMITDATE] = " + dbOperation.DbToDate(unit.CIRCLEFRONTLIMITDATE)
                    + " , [CIRCLEBACKLIMITDATE] = " + dbOperation.DbToDate(unit.CIRCLEBACKLIMITDATE)
                    + " , [NEXTVALUE] = " + (unit.NEXTVALUE == 0 ? "null" : unit.NEXTVALUE.ToString())
                    + " , [EXCUTEVALUE] = " + (unit.NEXTVALUE == 0 ? "null" : unit.EXCUTEVALUE.ToString())
                    + " , [TIMINGFRONTLIMITHOURS] = " + (unit.NEXTVALUE == 0 ? "null" : unit.TIMINGFRONTLIMITHOURS.ToString())
                    + " , [TIMINGBACKLIMITHOURS] = " + (unit.NEXTVALUE == 0 ? "null" : unit.TIMINGBACKLIMITHOURS.ToString())
                    + " , [ISCOMBINEDORDER] = " + unit.ISCOMBINEDORDER.ToString()
                    + " , [ISTEMPWORKORDER] = " + unit.ISTEMPWORKORDER.ToString()
                    + " , [INSTEADEDWKID] = " + (string.IsNullOrEmpty(unit.INSTEADEDWKID) ? "null" : "'" + unit.INSTEADEDWKID.Replace("'", "''") + "'")
                    + " , [WORKEXECUTOR] = '" + (unit.WORKEXECUTOR == null ? "" : unit.WORKEXECUTOR.Replace("'", "''")) + "'"
                    + " , [WORKCONFIRMOR] = '" + (unit.WORKCONFIRMOR == null ? "" : unit.WORKCONFIRMOR.Replace("'", "''")) + "'"
                    + " , [WORKCOMPLETEDINFO] = N'" + (unit.WORKCOMPLETEDINFO == null ? "" : unit.WORKCOMPLETEDINFO.Replace("'", "''")) + "'"
                    + " , [WORKDESCRIPTION] = N'" + (unit.WORKDESCRIPTION == null ? "" : unit.WORKDESCRIPTION.Replace("'", "''")) + "'"
                    + " , [PRINCIPALPOST] = '" + (unit.PRINCIPALPOST == null ? "" : unit.PRINCIPALPOST.Replace("'", "''")) + "'"
                    + " , [CONFIRMPOST] = '" + (unit.CONFIRMPOST == null ? "" : unit.CONFIRMPOST.Replace("'", "''")) + "'"
                    + " , [ISCHECKPROJECT] = " + unit.ISCHECKPROJECT.ToString()
                    + " , [ISREPAIRPROJECT] = " + unit.ISREPAIRPROJECT.ToString()
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , [CREATEDATE] = " + dbOperation.DbToDate(unit.CREATEDATE)
                    + " where upper(WORKORDERID) = '" + unit.WORKORDERID.ToUpper() + "'";
            }
            else
            {
                unit.WORKORDERID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [t_workorder] ("
                    + "[WORKORDERID],"
                    + "[WORKINFOID],"
                    + "[WORKORDERNAME],"
                    + "[WORKORDERSTATE],"
                    + "[PLANEXEDATE],"
                    + "[COMPLETEDDATE],"
                    + "[CIRCLEFRONTLIMITDATE],"
                    + "[CIRCLEBACKLIMITDATE],"
                    + "[NEXTVALUE],"
                    + "[EXCUTEVALUE],"
                    + "[TIMINGFRONTLIMITHOURS],"
                    + "[TIMINGBACKLIMITHOURS],"
                    + "[ISCOMBINEDORDER],"
                    + "[ISTEMPWORKORDER],"
                    + "[INSTEADEDWKID],"
                    + "[WORKEXECUTOR],"
                    + "[WORKCONFIRMOR],"
                    + "[WORKCOMPLETEDINFO],"
                    + "[WORKDESCRIPTION],"
                    + "[PRINCIPALPOST],"
                    + "[CONFIRMPOST],"
                    + "[ISCHECKPROJECT],"
                    + "[ISREPAIRPROJECT],"
                    + "[SHIP_ID],"
                    + "[CREATEDATE]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.WORKORDERID) ? "null" : "'" + unit.WORKORDERID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.WORKINFOID) ? "null" : "'" + unit.WORKINFOID.Replace("'", "''") + "'")
                    + " , N" + (unit.WORKORDERNAME == null ? "''" : "'" + unit.WORKORDERNAME.Replace("'", "''")) + "'"
                    + " ," + unit.WORKORDERSTATE.ToString()
                    + " ," + dbOperation.DbToDate(unit.PLANEXEDATE)
                    + " ," + dbOperation.DbToDate(unit.COMPLETEDDATE)
                    + " ," + dbOperation.DbToDate(unit.CIRCLEFRONTLIMITDATE)
                    + " ," + dbOperation.DbToDate(unit.CIRCLEBACKLIMITDATE)
                    + " ," + (unit.NEXTVALUE == 0 ? "null" : unit.NEXTVALUE.ToString())
                    + " ," + (unit.NEXTVALUE == 0 ? "null" : unit.EXCUTEVALUE.ToString())
                    + " ," + (unit.NEXTVALUE == 0 ? "null" : unit.TIMINGFRONTLIMITHOURS.ToString())
                    + " ," + (unit.NEXTVALUE == 0 ? "null" : unit.TIMINGBACKLIMITHOURS.ToString())
                    + " ," + unit.ISCOMBINEDORDER.ToString()
                    + " ," + unit.ISTEMPWORKORDER.ToString()
                    + " , " + (string.IsNullOrEmpty(unit.INSTEADEDWKID) ? "null" : "'" + unit.INSTEADEDWKID.Replace("'", "''") + "'")
                    + " , " + (unit.WORKEXECUTOR == null ? "''" : "'" + unit.WORKEXECUTOR.Replace("'", "''")) + "'"
                    + " , " + (unit.WORKCONFIRMOR == null ? "''" : "'" + unit.WORKCONFIRMOR.Replace("'", "''")) + "'"
                    + " , N" + (unit.WORKCOMPLETEDINFO == null ? "''" : "'" + unit.WORKCOMPLETEDINFO.Replace("'", "''")) + "'"
                    + " , N" + (unit.WORKDESCRIPTION == null ? "''" : "'" + unit.WORKDESCRIPTION.Replace("'", "''")) + "'"
                    + " , " + (unit.PRINCIPALPOST == null ? "''" : "'" + unit.PRINCIPALPOST.Replace("'", "''")) + "'"
                    + " , " + (unit.CONFIRMPOST == null ? "''" : "'" + unit.CONFIRMPOST.Replace("'", "''")) + "'"
                    + " ," + unit.ISCHECKPROJECT.ToString()
                    + " ," + unit.ISREPAIRPROJECT.ToString()
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.CREATEDATE)
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表t_workorder中的对象.
        /// </summary>
        /// <param name="unit">要删除的t_workorder对象</param>
        public bool deleteUnit(WorkOrder unit, out string err)
        {
            return deleteUnit(unit.WORKORDERID, out err);
        }

        /// <summary>
        /// 删除数据表WorkOrder中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的WorkOrder.wORKORDERID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            if (string.IsNullOrEmpty(unitid))
            {
                err = "删除工单失败,传入参数无效,为空值";
                return false;
            }
            if (!canDelete(unitid, out err)) return false;
            sql = "delete from t_workorder where "
                + " upper(t_workorder.WORKORDERID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  t_workorder 所有数据信息.
        /// </summary>
        /// <returns>t_workorder DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "WORKORDERID, "
                + "WORKINFOID, "
                + "WORKORDERNAME, "
                + "WORKORDERSTATE, "
                + "PLANEXEDATE, "
                + "COMPLETEDDATE, "
                + "CIRCLEFRONTLIMITDATE, "
                + "CIRCLEBACKLIMITDATE, "
                + "NEXTVALUE, "
                + "EXCUTEVALUE, "
                + "TIMINGFRONTLIMITHOURS, "
                + "TIMINGBACKLIMITHOURS, "
                + "ISCOMBINEDORDER, "
                + "ISTEMPWORKORDER, "
                + "INSTEADEDWKID, "
                + "WORKEXECUTOR, "
                + "WORKCONFIRMOR, "
                + "WORKCOMPLETEDINFO, "
                + "WORKDESCRIPTION, "
                + "PRINCIPALPOST, "
                + "CONFIRMPOST, "
                + "ISCHECKPROJECT, "
                + "ISREPAIRPROJECT, "
                + "SHIP_ID, "
                + "CREATEDATE"
                + "  from t_workorder ";
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
        /// 根据一个主键ID,得到 t_workorder 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>t_workorder DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "WORKORDERID, "
                + "WORKINFOID, "
                + "WORKORDERNAME, "
                + "WORKORDERSTATE, "
                + "PLANEXEDATE, "
                + "COMPLETEDDATE, "
                + "CIRCLEFRONTLIMITDATE, "
                + "CIRCLEBACKLIMITDATE, "
                + "NEXTVALUE, "
                + "EXCUTEVALUE, "
                + "TIMINGFRONTLIMITHOURS, "
                + "TIMINGBACKLIMITHOURS, "
                + "ISCOMBINEDORDER, "
                + "ISTEMPWORKORDER, "
                + "INSTEADEDWKID, "
                + "WORKEXECUTOR, "
                + "WORKCONFIRMOR, "
                + "WORKCOMPLETEDINFO, "
                + "WORKDESCRIPTION, "
                + "PRINCIPALPOST, "
                + "CONFIRMPOST, "
                + "ISCHECKPROJECT, "
                + "ISREPAIRPROJECT, "
                + "SHIP_ID, "
                + "CREATEDATE"
                + " from t_workorder "
                + " where upper(WORKORDERID)='" + Id.ToUpper() + "'";
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
        /// 根据t_workorder 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>t_workorder 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBoxEx.Show(o);
        public WorkOrder getObject(DataRow dr)
        {
            WorkOrder unit = new WorkOrder();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造WorkOrder类对象!";
                return unit;
            }
            if (DBNull.Value != dr["WORKORDERID"])
                unit.WORKORDERID = dr["WORKORDERID"].ToString();
            if (DBNull.Value != dr["WORKINFOID"])
                unit.WORKINFOID = dr["WORKINFOID"].ToString();
            if (DBNull.Value != dr["WORKORDERNAME"])
                unit.WORKORDERNAME = dr["WORKORDERNAME"].ToString();
            if (DBNull.Value != dr["WORKORDERSTATE"])
                unit.WORKORDERSTATE = Convert.ToDecimal(dr["WORKORDERSTATE"]);
            if (DBNull.Value != dr["PLANEXEDATE"])
                unit.PLANEXEDATE = (DateTime)dr["PLANEXEDATE"];
            if (DBNull.Value != dr["COMPLETEDDATE"])
                unit.COMPLETEDDATE = (DateTime)dr["COMPLETEDDATE"];
            if (DBNull.Value != dr["CIRCLEFRONTLIMITDATE"])
                unit.CIRCLEFRONTLIMITDATE = (DateTime)dr["CIRCLEFRONTLIMITDATE"];
            if (DBNull.Value != dr["CIRCLEBACKLIMITDATE"])
                unit.CIRCLEBACKLIMITDATE = (DateTime)dr["CIRCLEBACKLIMITDATE"];
            if (DBNull.Value != dr["NEXTVALUE"])
                unit.NEXTVALUE = Convert.ToDecimal(dr["NEXTVALUE"]);
            if (DBNull.Value != dr["EXCUTEVALUE"])
                unit.EXCUTEVALUE = Convert.ToDecimal(dr["EXCUTEVALUE"]);
            if (DBNull.Value != dr["TIMINGFRONTLIMITHOURS"])
                unit.TIMINGFRONTLIMITHOURS = Convert.ToDecimal(dr["TIMINGFRONTLIMITHOURS"]);
            if (DBNull.Value != dr["TIMINGBACKLIMITHOURS"])
                unit.TIMINGBACKLIMITHOURS = Convert.ToDecimal(dr["TIMINGBACKLIMITHOURS"]);
            if (DBNull.Value != dr["ISCOMBINEDORDER"])
                unit.ISCOMBINEDORDER = Convert.ToDecimal(dr["ISCOMBINEDORDER"]);
            if (DBNull.Value != dr["ISTEMPWORKORDER"])
                unit.ISTEMPWORKORDER = Convert.ToDecimal(dr["ISTEMPWORKORDER"]);
            if (DBNull.Value != dr["INSTEADEDWKID"])
                unit.INSTEADEDWKID = dr["INSTEADEDWKID"].ToString();
            if (DBNull.Value != dr["WORKEXECUTOR"])
                unit.WORKEXECUTOR = dr["WORKEXECUTOR"].ToString();
            if (DBNull.Value != dr["WORKCONFIRMOR"])
                unit.WORKCONFIRMOR = dr["WORKCONFIRMOR"].ToString();
            if (DBNull.Value != dr["WORKCOMPLETEDINFO"])
                unit.WORKCOMPLETEDINFO = dr["WORKCOMPLETEDINFO"].ToString();
            if (DBNull.Value != dr["WORKDESCRIPTION"])
                unit.WORKDESCRIPTION = dr["WORKDESCRIPTION"].ToString();
            if (DBNull.Value != dr["PRINCIPALPOST"])
                unit.PRINCIPALPOST = dr["PRINCIPALPOST"].ToString();
            if (DBNull.Value != dr["CONFIRMPOST"])
                unit.CONFIRMPOST = dr["CONFIRMPOST"].ToString();
            if (DBNull.Value != dr["ISCHECKPROJECT"])
                unit.ISCHECKPROJECT = Convert.ToDecimal(dr["ISCHECKPROJECT"]);
            if (DBNull.Value != dr["ISREPAIRPROJECT"])
                unit.ISREPAIRPROJECT = Convert.ToDecimal(dr["ISREPAIRPROJECT"]);
            if (DBNull.Value != dr["SHIP_ID"])
                unit.SHIP_ID = dr["SHIP_ID"].ToString();
            if (DBNull.Value != dr["CREATEDATE"])
                unit.CREATEDATE = (DateTime)dr["CREATEDATE"];

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个WorkOrder对象.
        /// </summary>
        /// <param name="wORKORDERID">wORKORDERID</param>
        /// <returns>WorkOrder对象</returns>
        public WorkOrder getObject(string Id, out string err)
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

        private bool canDelete(string workorderId, out string err)
        {
            err = "";
            //是否可以删除当前工单,有可能包含消耗备件,被其它工单引用,存在测量报告,特殊功能模块还可能包含CMS引用和修船引用,工单暂停引用.            
            sql = string.Format(@"select SUM(c)
                    from    (select COUNT (1) c
                        from T_SHIP_REPAIR_PROJECT
                        where WORKORDERID = '{0}'
                        union all
                        select COUNT(1)
                        from dbo.T_WORKORDER_MEASUREREPORT
                        where WORKORDERID = '{0}'
                        union all
                        select COUNT(1)
                        from dbo.T_WORKORDER_USESPARE
                        where WORKORDERID = '{0}')t ", workorderId);
            if (dbAccess.GetString(sql) != "0")
            {
                err = "修船项目引用过的工单,包含备件消耗的工单,填写过工作报告的工单均不能被删除.";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 保存编辑过的工单信息（这些工单是因完工操作而产生的）.
        /// </summary>
        /// <param name="dtb">包含工单信息的DataTable对象</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public bool SaveNewWorkOrder(DataTable dtb, out string err)
        {
            List<string> lstSqlOpt = new List<string>();    //包含操作语句的List泛型集合.
            string sSql = "";                               //操作的SQL语句.
            string workorderId = "";                        //工单Id
            string workordername = "";                      //工单名称.
            string principalpost = "";                      //责任人岗位.
            string confirmpost = "";                        //确认人岗位.
            string planexedate = "null";                    //预计执行日期.
            string circlefrontlimitdate = "null";           //前允差日期.
            string circlebacklimitdate = "null";            //后允差日期.
            string nextvalue = "null";                      //预计执行时表值.
            string timingfrontlimithours = "null";          //前允差小时数.
            string timingbacklimithours = "null";           //后允差小时数.

            foreach (DataRow curRow in dtb.Rows)
            {
                workorderId = curRow["workorderid"].ToString();
                workordername = curRow["workordername"].ToString();
                principalpost = curRow["principalpost"].ToString();
                confirmpost = curRow["confirmpost"].ToString();
                if (curRow["planexedate"].ToString() != "")
                {
                    DateTime dtTemp = (DateTime)curRow["planexedate"];
                    planexedate = "'" + dtTemp.ToString() + "'";
                    if (string.IsNullOrEmpty(curRow["circlefrontlimitdate"].ToString()) || curRow["circlefrontlimitdate"].ToString() == "0")
                        circlefrontlimitdate = "'" + new DateTime(dtTemp.Year, dtTemp.Month, 1).ToShortDateString() + "'";
                    else
                        circlefrontlimitdate = "'" + curRow["circlefrontlimitdate"].ToString() + "'";
                    if (string.IsNullOrEmpty(curRow["circlebacklimitdate"].ToString()) || curRow["circlebacklimitdate"].ToString() == "0")
                        circlebacklimitdate = "'" + new DateTime(dtTemp.Year, dtTemp.Month, 1).AddMonths(1).AddDays(-1).ToShortDateString() + "'";
                    else
                        circlebacklimitdate = "'" + curRow["circlebacklimitdate"].ToString() + "'";
                }
                if (curRow["nextvalue"].ToString() != "")
                {
                    long lTemp = long.Parse(curRow["nextvalue"].ToString());
                    nextvalue = lTemp.ToString();
                    if (curRow["timingfrontlimithours"].ToString() != "")
                        timingfrontlimithours = curRow["timingfrontlimithours"].ToString();
                    else
                        timingfrontlimithours = (lTemp - 200).ToString();
                    if (curRow["timingbacklimithours"].ToString() != "")
                        timingbacklimithours = curRow["timingbacklimithours"].ToString();
                    else
                        timingbacklimithours = (lTemp + 200).ToString();
                }
                sSql = "update t_workorder set workordername = N'" + workordername + "', principalpost='" + principalpost + "',";
                sSql += "confirmpost = '" + confirmpost + "',planexedate=" + planexedate + ",circlefrontlimitdate=" + circlefrontlimitdate;
                sSql += ",circlebacklimitdate=" + circlebacklimitdate + ",nextvalue=" + nextvalue;
                sSql += ",timingfrontlimithours=" + timingfrontlimithours + ",timingbacklimithours=" + timingbacklimithours;
                sSql += " where workorderid = '" + workorderId + "'";
                lstSqlOpt.Add(sSql);
            }

            //调用dbAccess的execSql执行lstSqlOpt中的所有的操作语句.
            return dbAccess.ExecSql(lstSqlOpt, out err);
        }

        /// <summary>
        /// 根据指定的工单Id集合来查询工单信息.
        /// </summary>
        /// <param name="lstWorkOrderIds">工单Id组成的List集合</param>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetWorkOrder(List<string> lstWorkOrderIds)
        {
            //变量定义部分.
            DataTable dtb = new DataTable();//定义一个DataTable对象.
            string err = "";     //错误信息返回参数.
            string sSql = "";               //查询数据所需的SQL语句.
            string workOrderIds = "(";      //工单信息Id用逗号组成的字符串.

            //把所有的工单Id组成一个用逗号连接成的字符串.
            foreach (string workOrderId in lstWorkOrderIds)
            {
                workOrderIds += "'" + workOrderId + "',";
            }

            if (workOrderIds != "(")
            {
                workOrderIds = workOrderIds.Substring(0, workOrderIds.Length - 1) + ")";

                //Select语句加工部分.
                sSql = "select ";
                sSql += "a.workorderid,";
                sSql += "a.workordername,";
                sSql += "a.workinfoid,";
                sSql += "a.circleortiming,";
                sSql += "a.circleortimingname,";
                sSql += "a.principalpost,";
                sSql += "a.principalpostname,";
                sSql += "a.confirmpost,";
                sSql += "a.confirmpostname,";
                sSql += "a.planexedate,";
                sSql += "a.circlefrontlimitdate,";
                sSql += "a.circlebacklimitdate,";
                sSql += "a.nextvalue,";
                sSql += "a.timingfrontlimithours,";
                sSql += "a.timingbacklimithours,";
                sSql += "a.total_workhours,";
                sSql += "case when b.workreportid is not null then '双击' end as measurereport,";
                sSql += "a.workcompletedinfo,";
                sSql += "a.iscombinedorder,";
                sSql += "a.istempworkorder,a.last_couter_time,a.ship_id,a.WORKDESCRIPTION ";
                sSql += "\rfrom v_workorder a left join t_workinfo_measurereport b on a.workinfoid = b.workinfoid ";
                sSql += "\rwhere a.workorderid in " + workOrderIds + " order by a.workordername";
                dbAccess.GetDataTable(sSql, out dtb, out err);
            }

            return dtb;
        }

        /// <summary>
        /// 取得当前工单的工作信息所对应的设备的抄表对象（这个工单必须是定时的或者定期与定时的），.
        /// 本函数用于在工单完工时为定时设备抄表使用.
        /// </summary>
        /// <param name="workInfoId">当前工单对应的工作信息Id</param>
        /// <returns>返回一个抄表对象T_GAUGE</returns>
        public Gauge GetCompGauge(string workInfoId)
        {
            Gauge gauge = null;           //声明一个T_GAUGE对象.
            string err = "";     //错误信息返回参数.
            string componentUnitId = "";    //当前工作信息对应的设备Id
            string grpComponentUnitId = ""; //当前设备所在的组的设备Id
            string gaugeId = "";            //抄表记录Id
            string sSql = "";               //查询数据所需的SQL语句.

            //取得当前工作信息workInfoId对应的设备IdcomponentUnitId
            sSql = "select refobjid from t_workinfo where workinfoid = '" + workInfoId + "'";
            componentUnitId = dbAccess.GetString(sSql);

            if (!string.IsNullOrEmpty(componentUnitId))
            {
                //在表t_gauge中取得当前设备componentUnitId所在的组的组设备Id。如果当前设备本身就是组(topunit=1)，那么.
                //组Id就是这个设备的Id，否则取当前设备对应的parent_unit_id
                sSql = "select ";
                sSql += "case when topunit = 1 then component_unit_id ";
                sSql += "     else parent_unit_id ";
                sSql += "end as grpcomponent_unit_id ";
                sSql += "from t_gauge where component_unit_id = '" + componentUnitId + "'";
                grpComponentUnitId = dbAccess.GetString(sSql);

                if (!string.IsNullOrEmpty(grpComponentUnitId))
                {
                    //取当前组设备grpComponentUnitId对应的抄表记录Id
                    sSql = "select gauge_id from t_gauge where component_unit_id = '" + grpComponentUnitId + "'"; gaugeId = dbAccess.GetString(sSql);

                    //根据抄表记录Id组成一个T_GAUGE对象.
                    gauge = GaugeService.Instance.getObject(gaugeId, out err);
                }
            }

            return gauge;
        }

        /// <summary>
        /// 工单的免做.
        /// </summary>
        /// <param name="workOrderId">工单Id</param>
        /// <param name="cancelReason">免做原因</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public bool CancelWorkOrder(string workOrderId, string cancelReason, out string err)
        {
            string sqlOpt = ""; //操作的SQL语句.

            sqlOpt = "update t_workorder set workorderstate = 3, workcompletedinfo = N'" + cancelReason + "' ";
            sqlOpt += "where workorderid = '" + workOrderId + "'";

            //调用dbAccess的execSql执行sSql中的所有的操作语句.
            return dbAccess.ExecSql(sqlOpt, out err);
        }
        /// <summary>
        /// 工单安排给他人.
        /// </summary>
        /// <param name="dtb">包含工单信息的DataTable对象</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public bool WorkOrderToOther(DataTable dtb, string reason, out string err)
        {
            List<string> lstSqlOpt = new List<string>();    //包含操作语句的List泛型集合.
            string sSql = "";                               //操作的SQL语句.
            string workorderId = "";                        //工单Id
            string principalpost = "";                      //责任人岗位.
            string confirmpost = "";                        //确认人岗位.

            foreach (DataRow curRow in dtb.Rows)
            {
                workorderId = curRow["workorderid"].ToString();
                principalpost = curRow["principalpost"].ToString();
                confirmpost = curRow["confirmpost"].ToString();

                sSql = "update t_workorder set principalpost = '" + principalpost + "', ";
                sSql += "confirmpost = '" + confirmpost + "'" + (string.IsNullOrEmpty(reason) ? "" : ",WORKDESCRIPTION = isnull(WORKDESCRIPTION,'') + '" + reason + "'")
                    + "\rwhere workorderid = '" + workorderId + "'";
                lstSqlOpt.Add(sSql);
            }

            //调用dbAccess的execSql执行lstSqlOpt中的所有的操作语句.
            return dbAccess.ExecSql(lstSqlOpt, out err);
        }
    }
}
