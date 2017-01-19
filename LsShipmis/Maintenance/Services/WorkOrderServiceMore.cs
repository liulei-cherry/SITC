using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using CommonOperation.Interfaces;
using Maintenance.DataObject;
using BaseInfo.Objects;
using BaseInfo.DataAccess;
using System.Data;
using FileOperationBase.Services;
using System.IO;
using Maintenance.Viewer;

namespace Maintenance.Services
{
    public partial class WorkOrderService : IObjectsService
    {
        #region IObjectsService 成员

        public CommonOperation.BaseClass.CommonClass GetOneObjectById(string id)
        {
            string err;
            return getObject(id, out err);
        }

        public Dictionary<string, string> GetObjectDisplaySetting()
        {
            Dictionary<string, string> reValue = new Dictionary<string, string>();
            reValue.Add("WORKORDERNAME", "工单名称");
            reValue.Add("WORKORDERSTATE", "工单状态");
            reValue.Add("PLANEXEDATE", "计划完成日期");
            reValue.Add("COMPLETEDDATE", "实际完成日期");
            reValue.Add("WORKEXECUTOR", "执行者");
            reValue.Add("WORKCONFIRMOR", "确认者");
            reValue.Add("WORKDESCRIPTION", "工单内容");
            reValue.Add("WORKCOMPLETEDINFO", "工单完成情况");
            reValue.Add("PRINCIPALPOST", "责任人岗位");
            reValue.Add("WORKORDERSTATE", "工单状态");
            return reValue;
        }

        #endregion

        /// <summary>
        /// 取得指定船舶指定的工作信息在某个时间范围内的工单信息（这个信息包含已存在的工单，.
        /// 还要包含根据一个基准工单和该工单的周期推算出来的数据库中不存在的工单）.
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <param name="workInfoId">工作信息Id</param>
        /// <param name="startTime">起始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>返回工单列表信息</returns>
        public List<WorkOrder> GetWorkOrder(string shipId, string workInfoId, DateTime startTime, DateTime endTime)
        {
            List<WorkOrder> lstWorkOrders = new List<WorkOrder>();//包含生成的工单集合.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.
            DataTable dtb1 = new DataTable();   //定义一个DataTable对象1
            DataTable dtb2 = new DataTable();   //定义一个DataTable对象2
            DataTable dtb3 = new DataTable();   //定义一个DataTable对象3
            string calWorkOrderId = "";         //用于推算的基准工单Id

            //先在指定的日期范围内找指定工作信息Id的所有工单（除免做状态的所有工单，可能有多条）.
            sSql = "select * from v_workorder where ship_id = '" + shipId + "' and workinfoid = '" + workInfoId + "' ";
            sSql += "and case when circleortiming = 2 then last_couter_time else planexedate end between ";
            sSql += "'" + startTime + "' and '" + endTime + "' and workorderstate != 3 and workorderstate != 6 order by workordername";

            dbAccess.GetDataTable(sSql, out dtb1, out err);

            //如果在指定的日期范围内没有找到任何工单，则查找该工作信息中小于startTime日期的最近一个工单（max(planexedate)
            //或者max(last_couter_time)，除免做状态的工单外，只能取出一条），这个工单虽不在指定日期范围内，但它将做为推算下一个工单的基准工单.
            if (dtb1.Rows.Count == 0)
            {
                sSql = "select workorderid from v_workorder where case when circleortiming = 2 then last_couter_time else planexedate end = ";
                sSql += "(select max(case when circleortiming = 2 then last_couter_time else planexedate end) ";
                sSql += "from v_workorder where ship_id = '" + shipId + "' and workinfoid = '" + workInfoId + "' ";
                sSql += "and workorderstate != 3 and workorderstate != 6 and case when circleortiming = 2 ";
                sSql += "then last_couter_time else planexedate end <  '" + startTime + "')";
                sSql += "and ship_id = '" + shipId + "' and workinfoid = '" + workInfoId + "'";
                dbAccess.GetDataTable(sSql, out  dtb2, out err);
            }

            //取出dtb1中的每一个工单Id生成工单对象后把它添加到集合中去.
            foreach (DataRow dataRow in dtb1.Rows)
            {
                //组建当前工单业务对象.
                string workOrderId = dataRow["workorderid"].ToString();
                WorkOrder workOrder = this.getObject(workOrderId, out err);

                //把工单workOrder添加到集合中.
                lstWorkOrders.Add(workOrder);
            }

            //取用于推算工单的基准工单Id（如果dtb1中存在记录则在dtb1中取，否则在dtb2中取，只能取一条）.
            if (dtb1.Rows.Count > 0)
            {
                //如果工单类型为定期，那么取最大的planexedate的工单，否则如果为定时，取最大的last_couter_time工单.
                sSql = "select workorderid from v_workorder where case when circleortiming = 2 then last_couter_time else planexedate end = ";
                sSql += "(select max(case when circleortiming = 2 then last_couter_time else planexedate end) from ";
                sSql += "v_workorder where ship_id = '" + shipId + "' and workinfoid = '" + workInfoId + "' ";
                sSql += "and case when circleortiming = 2 then last_couter_time else planexedate end between ";
                sSql += "'" + startTime + "' and '" + endTime + "' and workorderstate != 3 and workorderstate != 6) ";
                sSql += "and ship_id = '" + shipId + "' and workinfoid = '" + workInfoId + "'";
                dbAccess.GetDataTable(sSql, out dtb3, out err);
                calWorkOrderId = dtb3.Rows[0]["workorderid"].ToString();
            }
            else if (dtb2.Rows.Count > 0) //dtb1有数据时dtb2肯定没有.
            {
                calWorkOrderId = dtb2.Rows[0]["workorderid"].ToString();
            }

            //如果基准工单Id存在，则以它为依据向后推算下一个工单，直到超出endTime时间为止.
            if (calWorkOrderId != "")
            {
                WorkOrder workOrder = this.getObject(calWorkOrderId, out err);
                workOrder.FillThisObject();
                if (workOrder.TheWorkInfo.WORKINFOSTATE == 1)   //如果工作信息是停止状态（为0）将不进行推算.
                {
                    if ((int)workOrder.TheWorkInfo.CIRCLEORTIMING != 2)
                    {
                        //定期或者定期与定时处理.
                        lstWorkOrders.AddRange(this.getCircleWorkOrder(workOrder, startTime, endTime));
                    }
                    else
                    {
                        //定时处理.
                        lstWorkOrders.AddRange(this.getTimingWorkOrder(workOrder, startTime, endTime));
                    }
                }
            }

            //返回生成的工单集合.
            return lstWorkOrders;
        }
        /// <summary>
        /// 得到一段时间内的完成工单.
        /// </summary>
        /// <param name="fromDate">从哪天开始</param>
        /// <param name="endDate">到哪天结束</param>
        /// <param name="principalids">责任人岗位列表(如果是单人就一个,如果是多人,则是列表,比如甲板人员等</param>
        /// <param name="shipid">那艘船的工作,此值必填</param>
        /// <param name="finishOrder">是否仅输出完成的功能,否则打印出计划的工单(可能没有完成)</param>
        /// <param name="lstWorkOrders">返回值,工单列表</param>
        /// <param name="err">不成功描述的返回字符串</param>
        /// <returns>是否成功获取,不成功的描述见err</returns>
        public bool GetWorkOrderOfDate(DateTime fromDate, DateTime endDate, List<string> principalids, string shipid, bool finishOrder, out List<WorkOrder> lstWorkOrders, out string err)
        {
            lstWorkOrders = new List<WorkOrder>();
            //责任人的id字符串( id1,id2....)
            string principals = "";
            #region 参数检验部分


            foreach (string principalid in principalids)
            {
                if (principalid == null || principalid.Length != 36) continue;

                principals += (principals.Length == 0 ? "" : ",") + "'" + principalid.ToUpper().Replace("'", "''") + "'";
            }
            if (principals.Length == 0)
            {
                err = "没有发现有效的责任人列表!";
                return false;
            }
            CommonClass ship = ShipInfoService.Instance.GetOneObjectById(shipid);
            if (ship == null || ship.IsWrong)
            {
                err = "所查询的船舶无效";
                return false;
            }
            if (fromDate < CommonOperation.ConstParameter.MinDateTime) fromDate = CommonOperation.ConstParameter.MinDateTime;
            if (fromDate > CommonOperation.ConstParameter.MaxDateTime) fromDate = CommonOperation.ConstParameter.MaxDateTime;
            if (fromDate > endDate)
            {
                err = "所查询的起始日期大于结束日期,无法查出任何结果!";
                return false;
            }
            #endregion

            sql = "select WORKORDERID from V_WorkOrder  "
                + "\rwhere (COMPLETEDDATE between" + dbOperation.DbToDate(fromDate) + " and  " + dbOperation.DbToDate(endDate)
                + (finishOrder ? ")" : " or  planexedate between" + dbOperation.DbToDate(fromDate) + " and  " + dbOperation.DbToDate(endDate) + ")")
                + "\rand upper(principalpost) in (" + principals + ")" + " and ship_id = '" + shipid + "'"                
                + "\rorder by COMPLETEDDATE,workordername";
            DataTable dt;
            if (!dbAccess.GetDataTable(sql, out dt, out err))
            {
                err = "获取符合条件的工单时出错,错误信息为:" + err;
                return false;
            }

            foreach (DataRow dr in dt.Rows)
            {
                WorkOrder wordOrder = (WorkOrder)WorkOrderService.Instance.GetOneObjectById(dr[0].ToString());
                if (wordOrder == null || wordOrder.IsWrong)
                {
                    if (null != wordOrder)
                    {
                        err = "形成具体工单信息时发生了错误,错误信息为:" + wordOrder.WhyWrong;
                    }
                    return false;
                }
                lstWorkOrders.Add(wordOrder);
            }
            return true;
        }

        /// <summary>
        /// 工单的打回.
        /// </summary>
        /// <param name="lstWorkOrderIds">待确认的工单Id</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public bool WorkOrderReback(List<string> lstWorkOrderIds, string reason, out string err)
        {
            List<string> lstSqlOpt = new List<string>();    //包含操作语句的List泛型集合.
            string sSql = "";                               //操作的SQL语句.
            string sWorkOrderIds = "(";

            foreach (string workOrderId in lstWorkOrderIds)
            {
                sWorkOrderIds += "'" + workOrderId + "',";
            }

            sWorkOrderIds = sWorkOrderIds.Substring(0, sWorkOrderIds.Length - 1) + ")";

            //2.更新新添加的工单状态为已确认.
            sSql = "update t_workorder set workorderstate = 1,COMPLETEDDATE = null,WORKDESCRIPTION = isnull(WORKDESCRIPTION,'') + " + (string.IsNullOrEmpty(reason) ? "" : "'" + reason + "'")
                + "\rwhere workorderid in " + sWorkOrderIds;
            lstSqlOpt.Add(sSql);

            //调用dbAccess的execSql执行lstSqlOpt中的所有的操作语句.
            return dbAccess.ExecSql(lstSqlOpt, out err);
        }

        /// <summary>
        /// 工单的确认.
        /// </summary>
        /// <param name="lstWorkOrderIds">待确认的工单Id</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public bool WorkOrderConfirm(List<string> lstWorkOrderIds, out string err)
        {
            List<string> lstSqlOpt = new List<string>();    //包含操作语句的List泛型集合.
            string sSql = "";                               //操作的SQL语句.
            string sWorkOrderIds = "(";

            foreach (string workOrderId in lstWorkOrderIds)
            {
                sWorkOrderIds += "'" + workOrderId + "',";
            }

            sWorkOrderIds = sWorkOrderIds.Substring(0, sWorkOrderIds.Length - 1) + ")";

            //2.更新新添加的工单状态为已确认并写确认人.
            sSql = "update t_workorder set workorderstate = case when workorderstate = 3 then 6 ";
            sSql += "when workorderstate = 4 then 7 when workorderstate = 5 then 8 end,"
                    + "completeddate = case when completeddate is null then planexedate else completeddate end, ";
            sSql += "workconfirmor = '" + CommonOperation.ConstParameter.UserName + "' where workorderid in " + sWorkOrderIds;
            lstSqlOpt.Add(sSql);

            //调用dbAccess的execSql执行lstSqlOpt中的所有的操作语句.
            return dbAccess.ExecSql(lstSqlOpt, out err);
        }
        /// <summary>
        /// 取得在指定日期之前的指定工单及根据其周期推算出来的所有工单（本函数处理定期和定期与定时两种工单类型.
        /// ，对于定期与定时的工单，仅按照定期为条件进行推算而忽略定时部分）.
        /// </summary>
        /// <param name="workOrder">指定的工单业务对象</param>
        /// <param name="startTime">起始日期</param>
        /// <param name="endTime">截止日期</param>
        /// <returns>返回符合条件的所有工单的List集合</returns>
        private List<WorkOrder> getCircleWorkOrder(WorkOrder workOrder, DateTime startTime, DateTime endTime)
        {
            workOrder.FillThisObject();
            //建立一个WorkOrder类型的List泛型集合.
            List<WorkOrder> lstWorkOrders = new List<WorkOrder>();

            //定期部分内容计算.
            DateTime nextPlanexedate = workOrder.PLANEXEDATE;   //当前工单的预计执行日期.
            DateTime circlefrontlimitdate;     //当前工单的前允差日期.
            DateTime circlebacklimitdate;      //当前工单的后允差日期.
            int circleperiod = (int)workOrder.TheWorkInfo.CIRCLEPERIOD;          //定期周期.
            string circleunitname = workOrder.TheWorkInfo.CIRCLEUNIT;   //定期周期单位.
            int circlefrontlimit = (int)workOrder.TheWorkInfo.CIRCLEFRONTLIMIT;  //定期前允差.
            int circlebacklimit = (int)workOrder.TheWorkInfo.CIRCLEBACKLIMIT;    //定期后允差.
            string circlelimitunitname = workOrder.TheWorkInfo.CIRCLELIMITUNIT;//定期允差单位.

            //定时部分内容计算（如果当前工单类型为3，那么包括定时部分）.
            int nextvalue = (int)workOrder.NEXTVALUE;                //预计执行表值.
            int timingfrontlimithours;                      //前允差小时数.
            int timingbacklimithours;                       //后允差小时数.
            int timingperiod = (int)workOrder.TheWorkInfo.TIMINGPERIOD;          //定时周期.
            int timingfrontlimit = (int)workOrder.TheWorkInfo.TIMINGFRONTLIMIT;  //定时前允差.
            int timingbacklimit = (int)workOrder.TheWorkInfo.TIMINGBACKLIMIT;    //定时后允差.

            //根据当前工单workOrder的周期不断地往后推而生成下一个工单，直到下一个工单的预计执行日期大于截止日期为止.
            while (true)
            {
                //下一个工单的预计执行日期、前允差日期与后允差日期.
                nextPlanexedate = this.GetNextPlanexedate(nextPlanexedate, circleunitname, circleperiod);
                circlefrontlimitdate = this.GetNextLimitDate(1, nextPlanexedate, circlelimitunitname, circlefrontlimit);
                circlebacklimitdate = this.GetNextLimitDate(2, nextPlanexedate, circlelimitunitname, circlebacklimit);

                nextvalue += timingperiod;
                timingfrontlimithours = nextvalue - timingfrontlimit;
                timingbacklimithours = nextvalue + timingbacklimit;
                //根据周期不断地推出下一个工单，直到预计执行日期大于结束日期为止才退出.
                if (nextPlanexedate > endTime)
                {
                    break;
                }
                else
                {
                    //如果下一个工单的预计执行日期在指定的日期范围内，则生成下一个工单对象并放到集合lstWorkOrders中去.
                    if (nextPlanexedate >= startTime && nextPlanexedate <= endTime)
                    {
                        WorkOrder curWorkOrder = (WorkOrder)workOrder.Clone();
                        curWorkOrder.WORKORDERID = Guid.NewGuid().ToString();
                        curWorkOrder.PLANEXEDATE = nextPlanexedate;
                        curWorkOrder.CIRCLEFRONTLIMITDATE = circlefrontlimitdate;
                        curWorkOrder.CIRCLEBACKLIMITDATE = circlebacklimitdate;
                        curWorkOrder.NEXTVALUE = nextvalue;
                        curWorkOrder.TIMINGFRONTLIMITHOURS = timingfrontlimithours;
                        curWorkOrder.TIMINGBACKLIMITHOURS = timingbacklimithours;
                        lstWorkOrders.Add(curWorkOrder);
                    }
                }
            }

            //返回集合对象.
            return lstWorkOrders;
        }
        /// <summary>
        /// 取当前工单要生成的下一个工单的预计执行日期（=本次完工日期+周期）.
        /// 周期要根据年、月、日三种单位的不同分别计算.
        /// </summary>
        /// <param name="theDate">计算下一个工单预计执行日期的基准日期（一般是本次完工日期或者本次工单的预计执行日期）</param>
        /// <param name="circleUnitName">周期单位</param>
        /// <param name="circleperiod">周期值</param>
        /// <returns>返回当前工单要生成的下一个工单的预计执行日期</returns>
        public DateTime GetNextPlanexedate(DateTime theDate, string circleUnitName, int circleperiod)
        {
            DateTime nextWkPlanexedate = new DateTime();  //生成的下一个工单的预计执行日期.
            nextWkPlanexedate = theDate;
            if (circleUnitName.Trim() == "年")
            {
                nextWkPlanexedate = theDate.AddYears(circleperiod);
            }
            else if (circleUnitName.Trim() == "月")
            {
                nextWkPlanexedate = theDate.AddMonths(circleperiod);
            }
            else if (circleUnitName.Trim() == "日")
            {
                nextWkPlanexedate = theDate.AddDays(circleperiod);
            }

            return nextWkPlanexedate;
        }
        /// <summary>
        /// 取当前工单要生成的下一个工单的前允差或者后允差日期.
        /// 要根据年、月、日三种允差单位的不同分别计算.
        /// </summary>
        /// <param name="mark">标记，1表示取前允差日期，2表示取后允差日期</param>
        /// <param name="nextWkPlanexedate">下一个工单的预计执行日期</param>
        /// <param name="circleLimitUnitName">允差单位</param>
        /// <param name="circleLimit">允差值，mark=1时为前允差值，mark=2时为后允差值,当允差为0时，取本月值</param>
        /// <returns>返回当前工单要生成的下一个工单的前允差或者后允差日期</returns>
        public DateTime GetNextLimitDate(int mark, DateTime nextWkPlanexedate,
                                string circleLimitUnitName, int circleLimit)
        {
            if (circleLimit == 0)
            {
                if (mark == 1)
                {
                    return new DateTime(nextWkPlanexedate.Year, nextWkPlanexedate.Month, 1);
                }
                else
                {
                    return new DateTime(nextWkPlanexedate.Year, nextWkPlanexedate.Month, 1).AddMonths(1).AddDays(-1);
                }
            }
            else
            {
                if (circleLimitUnitName.Trim() == "年")
                {
                    return nextWkPlanexedate.AddYears((mark == 1 ? -1 : 1) * circleLimit);
                }
                else if (circleLimitUnitName.Trim() == "月")
                {
                    return nextWkPlanexedate.AddMonths((mark == 1 ? -1 : 1) * circleLimit);
                }
                else if (circleLimitUnitName.Trim() == "日")
                {
                    return nextWkPlanexedate.AddDays((mark == 1 ? -1 : 1) * circleLimit);
                }
                else
                {
                    return nextWkPlanexedate.AddMonths((mark == 1 ? -1 : 1) * circleLimit);
                }
            }
        }
        /// <summary>
        /// 取得在指定日期之前的指定工单及根据其周期推算出来的所有工单（本函数处理定时一种工单类型）.
        /// </summary>
        /// <param name="workOrder">指定的工单业务对象</param>
        /// <param name="startTime">起始日期</param>        
        /// <param name="endTime">截止日期</param>
        /// <returns>返回符合条件的所有工单的List集合</returns>
        private List<WorkOrder> getTimingWorkOrder(WorkOrder workOrder, DateTime startTime, DateTime endTime)
        {
            workOrder.FillThisObject();
            //建立一个WorkOrder类型的List泛型集合.
            List<WorkOrder> lstWorkOrders = new List<WorkOrder>();
            DataTable dtb;//定义一个DataTable对象.
            string err = "";     //错误信息返回参数.
            string sSql = "";               //查询数据所需的SQL语句.

            float useRate = 0.0f;                               //设备的运转率.
            DateTime couteTime = new DateTime();                //抄表时间.
            int totalWorkhours = getWorkOrderTotalHours(workOrder);

            int timingfrontlimithours = 0;                      //前允差小时数.
            int timingbacklimithours = 0;                       //后允差小时数.
            int timingperiod = (int)workOrder.TheWorkInfo.TIMINGPERIOD;          //定时周期.
            int timingfrontlimit = (int)workOrder.TheWorkInfo.TIMINGFRONTLIMIT;  //定时前允差.
            int timingbacklimit = (int)workOrder.TheWorkInfo.TIMINGBACKLIMIT;    //定时后允差.

            //取得当前设备对应的运转率和上次抄表时间.
            sSql = "select use_rate,last_couter_time from t_component_unit where ";
            sSql += "component_unit_id = '" + workOrder.TheWorkInfo.REFOBJID + "'";
            dbAccess.GetDataTable(sSql, out dtb, out err);
            if (dtb.Rows.Count > 0)
            {
                DataRow dataRow = dtb.Rows[0];
                if (dataRow["use_rate"].ToString() != "") useRate = float.Parse(dataRow["use_rate"].ToString());
                if (dataRow["last_couter_time"].ToString() != "") couteTime = DateTime.Parse(dataRow["last_couter_time"].ToString());
            }

            //当前工单的定时周期依据运转率换算成天.
            int days = 0;
            if (useRate > 0)
            {
                days = (int)(timingperiod / useRate / 24);
            }

            //根据当前工单workOrder的定时周期不断地往后推而生成下一个工单，直到下一个工单的预计执行表值推算出的日期大于截止日期为止.
            while (true)
            {
                couteTime = couteTime.AddDays(days);                        //下一个工单的预计抄表时间.
                totalWorkhours = totalWorkhours + timingperiod;             //下一个工单的预计抄表值.
                timingfrontlimithours = totalWorkhours - timingfrontlimit;  //下一个工单的预计前允差小时数.
                timingbacklimithours = totalWorkhours + timingbacklimit;    //下一个工单的预计后允差小时数.

                //根据定时周期不断地推出下一个工单，直到预计抄表日期大于结束日期为止才退出.
                if (couteTime > endTime)
                {
                    break;
                }
                else
                {
                    //如果下一个工单的预计抄表日期在指定的日期范围内，则生成下一个工单对象并放到集合lstWorkOrders中去.
                    if (couteTime >= startTime && couteTime <= endTime)
                    {
                        //生成下一个工单对象并放到集合lstWorkOrders中去.
                        WorkOrder curWorkOrder = (WorkOrder)workOrder.Clone();
                        curWorkOrder.WORKORDERID = Guid.NewGuid().ToString();
                        curWorkOrder.NEXTVALUE = totalWorkhours;
                        curWorkOrder.TIMINGFRONTLIMITHOURS = timingfrontlimithours;
                        curWorkOrder.TIMINGBACKLIMITHOURS = timingbacklimithours;
                        curWorkOrder.PLANEXEDATE = couteTime;
                        lstWorkOrders.Add(curWorkOrder);
                    }
                }
            }

            //返回集合对象.
            return lstWorkOrders;
        }

        private int getWorkOrderTotalHours(WorkOrder workOrder)
        {
            string err;
            if (workOrder.TheWorkInfo != null)
            {
                ItemsManage.DataObject.ComponentUnit componentUnit = ItemsManage.Services.ComponentUnitService.Instance.getObject(workOrder.TheWorkInfo.REFOBJID, out err);
                int totalWorkhours = 0;
                if (componentUnit != null && !componentUnit.IsWrong)
                {

                    string sSql = @" select TOTAL_WORKHOURS from T_GAUGE_LOG where component_unit_id ='" + componentUnit.GetId() + "'"
                   + " and datediff(day,convert(varchar(10), gauge_time, 120)," + dbOperation.DbToDate(workOrder.COMPLETEDDATE) + ") =0";
                    string re = dbAccess.GetString(sSql);
                    if (string.IsNullOrEmpty(re)) return totalWorkhours;

                    if (int.TryParse(re, out totalWorkhours))
                    {
                        return totalWorkhours;
                    }
                    else
                        totalWorkhours = (int)componentUnit.total_workhours;     //抄表值
                }
                return totalWorkhours;
            }
            else return 0;
        }

        private int getWorkOrderAlertState(WorkOrder workOrder)
        {
            string sSql;
            //Select语句加工部分.
            sSql = "select ";
            //设置报警状态（如果当前工单是定期与定时性质，那么取其最严重的报警状态；如果是定期或者定时工单，直接取ctalertstate字段值.
            sSql += "case when circleortiming = 3 and circlealertstate > timingalertstate then circlealertstate ";
            sSql += "     when circleortiming = 3 and circlealertstate <= timingalertstate then timingalertstate ";
            sSql += "     else ctalertstate end as alertstate ";
            sSql += "from V_WorkOrder ";
            sSql += "where workorderid = '" + workOrder.GetId() + "'";

            string answer = dbAccess.GetString(sSql);
            if (string.IsNullOrEmpty(answer))
            {
                return 0;
            }
            return int.Parse(answer);
        }

        /// <summary>
        /// 判断当前工单所在的工作信息是否还存在着除本工单外的计划状态的工单，如果存在，则不生成下一个工单.
        /// </summary>
        /// <param name="workOrderId">当前工单Id</param>
        /// <param name="workInfoId">当前工单所对应的工作信息Id</param>
        /// <returns>存在返回true，否则返回false</returns>
        private bool IsExistNextWorkOrder(string workOrderId, string workInfoId)
        {
            DataTable dtb;//定义一个DataTable对象.
            string err = "";     //错误信息返回参数.
            string sSql = "";
            bool blResult = false;

            sSql = "select * from v_workorder where workorderid != '" + workOrderId + "' ";
            sSql += "and workinfoid = '" + workInfoId + "' and workorderstate = 1";
            dbAccess.GetDataTable(sSql, out dtb, out err);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                blResult = true;
            }

            return blResult;
        }
        /// <summary>
        /// 执行工作信息合并.
        /// </summary>
        /// <param name="workOrderName">工单名称</param>
        /// <param name="planExeDate">计划执行日期</param>
        /// <param name="circleFrontLimitDate">前允差日期</param>
        /// <param name="circleBackLimitDate">后允差日期</param>
        /// <param name="workDescription">补充说明</param>
        /// <param name="principalPost">责任人岗位</param>
        /// <param name="confirmPost">确认人岗位</param>
        /// <param name="lstWorkInfoIds">要合并的工作信息Id组成的List集合</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public bool CombinedWorkInfo(string shipid, string workOrderName, string planExeDate, string circleFrontLimitDate,
                                        string circleBackLimitDate, string workDescription, string principalPost,
                                        string confirmPost, List<string> lstWorkInfoIds, out string err)
        {
            List<string> lstSqlOpt = new List<string>();    //包含操作语句的List泛型集合.
            string sSql = "";                               //操作的SQL语句.
            string workorderId = Guid.NewGuid().ToString(); //生成新的工单Id

            //添加工单信息.
            sSql = "insert into t_workorder(workorderid,workordername,workorderstate,principalpost,confirmpost,";
            sSql += "planexedate,circlefrontlimitdate,circlebacklimitdate,iscombinedorder,workdescription,ship_id) ";
            sSql += "values('" + workorderId + "',N'" + workOrderName + "',1,'" + principalPost + "','" + confirmPost + "',";
            sSql += "'" + planExeDate + "','" + circleFrontLimitDate + "','" + circleBackLimitDate + "',1,N'" + workDescription + "',";
            sSql += "'" + shipid + "')";
            lstSqlOpt.Add(sSql);
            //向合并信息表中添加合并信息.
            foreach (string workInfoId in lstWorkInfoIds)
            {
                sSql = "insert into t_workorder_combined(COMBINEDORDER_ID, WORKTASKID, workinfoid) ";
                sSql += "values('" + Guid.NewGuid().ToString() + "','" + workorderId + "','" + workInfoId + "')";
                lstSqlOpt.Add(sSql);
            }

            //调用dbAccess的execSql执行lstSqlOpt中的所有的操作语句.
            return dbAccess.ExecSql(lstSqlOpt, out err);
        }

        /// <summary>
        /// 添加临时工单.
        /// </summary>
        /// <param name="workOrderName">工单名称</param>
        /// <param name="principalPost">责任人岗位</param>
        /// <param name="confirmPost">确认人岗位</param>
        /// <param name="planExeDate">执行日期</param>
        /// <param name="isCheckProject">检验项目</param>
        /// <param name="isRepairProject">修理项目</param>      
        /// <param name="workDescription">工单内容</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public bool AddTempWorkOrder(bool finished, string shipid, string workOrderName, string principalPost, string confirmPost,
                                     DateTime planExeDate, int isCheckProject, int isRepairProject, string workDescription, string workcompleteinfo, out string err)
        {
            string sSql = "";                             //操作的SQL语句.

            sSql = "insert into t_workorder(workorderid,workordername,workorderstate,planexedate," + (finished ? "" : "completeddate,");
            sSql += "circlefrontlimitdate,circlebacklimitdate,istempworkorder,workdescription,principalpost,";
            sSql += "confirmpost,ischeckproject,isrepairproject,WORKCOMPLETEDINFO,ship_id) values('" + Guid.NewGuid().ToString() + "',";
            sSql += "N'" + workOrderName.Replace("'", "''") + "'," + (finished ? "4" : "1") + ",'" + planExeDate.ToString("yyyy-MM-dd")
                 + "'," + (finished ? "" : "'" + planExeDate.ToString("yyyy-MM-dd") + "',") +
                 new DateTime(planExeDate.Year, planExeDate.Month, 1).ToString("yyyy-MM-dd") + ",";
            sSql += new DateTime(planExeDate.Year, planExeDate.Month, 1).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd")
                + ",1,N'" + workDescription.Replace("'", "''") + "','" + principalPost + "','" + confirmPost + "',";
            sSql += isCheckProject + "," + isRepairProject + ",N'" + workcompleteinfo.Replace("'", "''") + "','" + shipid + "')";

            //调用dbAccess的execSql执行lstSqlOpt中的所有的操作语句.
            return dbAccess.ExecSql(sSql, out err);
        }
        /// <summary>
        /// 获取特定工作信息的完工历史.
        /// </summary>
        /// <param name="workInfo"></param>
        /// <returns></returns>
        public DataTable getFinishedWorkerInfo(Maintenance.DataObject.WorkInfo workInfo)
        {
            DataTable dtb;
            sql = "SELECT WORKORDERNAME,CASE WHEN WORKORDERSTATE = 6 THEN '本次免做确认' WHEN WORKORDERSTATE = 7 THEN '正常确认' ELSE '超期确认' end as state,";
            sql += "PLANEXEDATE, COMPLETEDDATE, CIRCLEFRONTLIMITDATE, CIRCLEBACKLIMITDATE, NEXTVALUE, EXCUTEVALUE, TIMINGFRONTLIMITHOURS,";
            sql += "TIMINGBACKLIMITHOURS, WORKEXECUTOR, WORKCONFIRMOR, ";
            sql += "WORKCOMPLETEDINFO, WORKDESCRIPTION,  CREATEDATE ";
            sql += " FROM T_WORKORDER ";
            sql += " WHERE WORKINFOID = '" + workInfo.WORKINFOID + "' and SHIP_ID='" + workInfo.SHIP_ID + "' and WORKORDERSTATE>5 order by COMPLETEDDATE desc";
            string err;
            dbAccess.GetDataTable(sql, out dtb, out err);
            return dtb;
        }

        public bool fillAllWorkOrderInfo(WorkOrder toFillWorkOrder, out string err)
        {
            err = "";
            sql = "select circleortimingname,workorderstatename,principalpostname,confirmpostname,estimatevalue,insteadedwkname from V_WorkOrder where workorderid  = '" + toFillWorkOrder.GetId() + "'";
            DataTable dtb;
            if (!dbAccess.GetDataTable(sql, out dtb, out err) || dtb.Rows.Count != 1)
                return false;
            toFillWorkOrder.Circleortimingname = dtb.Rows[0]["circleortimingname"].ToString();
            toFillWorkOrder.Workorderstatename = dtb.Rows[0]["workorderstatename"].ToString();
            toFillWorkOrder.Principalpostname = dtb.Rows[0]["principalpostname"].ToString();
            toFillWorkOrder.Confirmpostname = dtb.Rows[0]["confirmpostname"].ToString();
            int estimatevalue;
            if (int.TryParse(dtb.Rows[0]["estimatevalue"].ToString(), out estimatevalue))
            {
                toFillWorkOrder.Estimatevalue = estimatevalue;
            }
            else
            {
                toFillWorkOrder.Estimatevalue = 0;
            }
            toFillWorkOrder.Insteadedwkname = dtb.Rows[0]["insteadedwkname"].ToString();

            return true;
        }

        /// <summary>
        /// 工单的完工操作.
        /// </summary>
        /// <param name="lstWorkOrderIds">所有要完工的工单Id集合（包含要完工的工单及要替代的工单）</param>
        /// <param name="dictWkInstead">包含被替代与替代工单Id的Dictionary集合</param>
        /// <param name="dtCompleteDate">完工日期</param>
        /// <param name="workCompletedInfo">完工情况说明</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        /// <returns>返回根据周期生成的新的工单的Id集合</returns>
        public bool WorkOrderComplete(List<string> lstWorkOrderIds, Dictionary<string, string> dictWkInstead,
            DateTime dtCompleteDate, string workCompletedInfo, out List<string> lstNewWorkOrderIds, out string err)
        {
            List<string> lstSqlOpt = new List<string>();         //包含操作语句的List泛型集合.
            lstNewWorkOrderIds = new List<string>();//根据周期生成的新的工单的Id集合.
            string sSql = "";                                    //SQL操作语句.
            int workOrderStateConfirm = 4;                       //工单的确认状态（4为待确认，5为超期待确认）.
            string excutevalue = "null";                         //执行时表值（定时）.
            foreach (string workOrderId in lstWorkOrderIds)
            {
                WorkOrder workOrder = getObject(workOrderId, out err);
                if (workOrder == null) continue;
                workOrder.COMPLETEDDATE = dtCompleteDate;   //把本次完工日期赋值给工单业务对象.
                workOrder.FillThisObject();
                //取当前工单的完工情况说明，如果没有说明，则取总说明.
                string curWorkCompletedInfo = workOrder.WORKCOMPLETEDINFO.Replace("'", "''");
                if (curWorkCompletedInfo.Trim() == "") curWorkCompletedInfo = workCompletedInfo.Replace("'", "''");
                //如果当前工单超期，则待确认状态应该为5（超期待确认），否则为4（待确认）.
                if (getWorkOrderAlertState(workOrder) == 3)
                {
                    workOrderStateConfirm = 5;
                }
                else
                {
                    workOrderStateConfirm = 4;
                }
                int workTotalHours = getWorkOrderTotalHours(workOrder);
                //工单完工时表值（实际执行时表值） = 最近的抄表值.
                if (workTotalHours > 0)
                {
                    workOrder.EXCUTEVALUE = workTotalHours;
                    excutevalue = "'" + workOrder.EXCUTEVALUE.ToString() + "'";
                }
                //执行完工操作的SQL语句.
                sSql = "update t_workorder set COMPLETEDDATE = '" + dtCompleteDate.ToString("yyyy-MM-dd") + "', excutevalue = " + excutevalue;
                sSql += ",workorderstate = " + workOrderStateConfirm + ", workexecutor = '" + CommonOperation.ConstParameter.UserName + "',";
                sSql += "workcompletedinfo = '" + curWorkCompletedInfo + "' where workorderid = '" + workOrderId + "'";
                lstSqlOpt.Add(sSql);
                //判断当前工单所在的工作信息是否还存在着除本工单外的计划状态的工单，如果存在，则不生成下一个工单.
                if (this.IsExistNextWorkOrder(workOrder.GetId(), workOrder.WORKINFOID))
                {
                    continue;
                }
                //如果当前工单是非周期性工单或者是合并工单或者是临时工单，则不会生成下一个工单.
                if (workOrder.TheWorkInfo == null || (int)workOrder.TheWorkInfo.CIRCLEORTIMING == 4 || (int)workOrder.ISCOMBINEDORDER == 1 || (int)workOrder.ISTEMPWORKORDER == 1)
                {
                    continue;
                }
                string nextWorkOrderId = Guid.NewGuid().ToString();//下一个工单的Id
                lstNewWorkOrderIds.Add(nextWorkOrderId);
                //生成下一个工单的SQL语句.
                if (workOrder.TheWorkInfo.CIRCLEORTIMING == 1)
                {
                    //下一个工单的预计执行日期、前允差日期与后允差日期.
                    DateTime nextWkPlanexedate = this.GetNextPlanexedate(workOrder.COMPLETEDDATE, workOrder.TheWorkInfo.CIRCLEUNIT, (int)workOrder.TheWorkInfo.CIRCLEPERIOD);//以本次工单完工日期为准计算（而非本次工单预计执行日期）.
                    DateTime nextFrontLimitDate = this.GetNextLimitDate(1, nextWkPlanexedate, workOrder.TheWorkInfo.CIRCLEUNIT, (int)workOrder.TheWorkInfo.CIRCLEFRONTLIMIT);
                    string sNextFrontLimitDate = "null";
                    DateTime nextBackLimitDate = this.GetNextLimitDate(2, nextWkPlanexedate, workOrder.TheWorkInfo.CIRCLEUNIT, (int)workOrder.TheWorkInfo.CIRCLEBACKLIMIT);
                    string sNextBackLimitDate = "null";
                    sNextFrontLimitDate = "'" + nextFrontLimitDate.ToString("yyyy-MM-dd") + "'";
                    sNextBackLimitDate = "'" + nextBackLimitDate.ToString("yyyy-MM-dd") + "'";
                    sSql = "insert into t_workorder(workorderid,workinfoid,workordername,workorderstate,principalpost,";
                    sSql += "confirmpost,planexedate,circlefrontlimitdate,circlebacklimitdate,ship_id) values(";
                    sSql += "'" + nextWorkOrderId + "','" + workOrder.WORKINFOID + "','" + workOrder.WORKORDERNAME + "',1,";
                    sSql += "'" + workOrder.PRINCIPALPOST + "','" + workOrder.CONFIRMPOST + "','" + nextWkPlanexedate.ToString("yyyy-MM-dd") + "',";
                    sSql += sNextFrontLimitDate + "," + sNextBackLimitDate + ",'" + workOrder.SHIP_ID + "')";
                    lstSqlOpt.Add(sSql);
                }
                else if (workOrder.TheWorkInfo.CIRCLEORTIMING == 2)
                {
                    //下一个工单的预计执行表值、前允差小时数与后允差小时数.
                    int nextWkOrderValue = (int)workOrder.EXCUTEVALUE + (int)workOrder.TheWorkInfo.TIMINGPERIOD;//注意：下次预计执行表值=本次实际执行表值（而非预计）+周期.
                    int timingFrontLimitHours = nextWkOrderValue - (int)workOrder.TheWorkInfo.TIMINGFRONTLIMIT;
                    string sTimingFrontLimitHours = "null";
                    int timingBackLimitHours = nextWkOrderValue + (int)workOrder.TheWorkInfo.TIMINGBACKLIMIT;
                    string sTimingBackLimitHours = "null";
                    if (workOrder.TheWorkInfo.TIMINGFRONTLIMIT > 0)
                    {
                        sTimingFrontLimitHours = timingFrontLimitHours.ToString();
                    }
                    else
                    {
                        sTimingFrontLimitHours = nextWkOrderValue.ToString();//如果前允差为0，则前允差小时数=预计执行表值.
                    }
                    if (workOrder.TheWorkInfo.TIMINGBACKLIMIT > 0)
                    {
                        sTimingBackLimitHours = timingBackLimitHours.ToString();
                    }
                    else
                    {
                        sTimingBackLimitHours = nextWkOrderValue.ToString();//如果前允差为0，则后允差小时数=预计执行表值.
                    }

                    decimal rate = 1;
                    workOrder.TheWorkInfo.FillThisObject();
                    if (workOrder.TheWorkInfo.CompUnit != null)
                    {
                        rate = workOrder.TheWorkInfo.CompUnit.USE_RATE;
                        if (rate == 0) rate = 1;
                    }
                    DateTime planExeDate = dtCompleteDate.AddHours((int)((nextWkOrderValue - workOrder.EXCUTEVALUE) / rate)); ;
                    sSql = "insert into t_workorder(workorderid,workinfoid,workordername,workorderstate,principalpost,";
                    sSql += "confirmpost,nextvalue,timingfrontlimithours,timingbacklimithours,planexedate,ship_id) values(";
                    sSql += "'" + nextWorkOrderId + "','" + workOrder.WORKINFOID + "','" + workOrder.WORKORDERNAME + "',1,";
                    sSql += "'" + workOrder.PRINCIPALPOST + "','" + workOrder.CONFIRMPOST + "'," + nextWkOrderValue + ",";
                    sSql += sTimingFrontLimitHours + "," + sTimingBackLimitHours + "," + dbOperation.DbToDate(planExeDate) + ",'" + workOrder.SHIP_ID + "')";
                    lstSqlOpt.Add(sSql);

                }
                else if (workOrder.TheWorkInfo.CIRCLEORTIMING == 3)
                {
                    //下一个工单的预计执行日期、前允差日期与后允差日期.
                    DateTime nextWkPlanexedate = this.GetNextPlanexedate(workOrder.COMPLETEDDATE, workOrder.TheWorkInfo.CIRCLEUNIT, (int)workOrder.TheWorkInfo.CIRCLEPERIOD);//以本次工单完工日期为准计算（而非本次工单预计执行日期）.
                    DateTime nextFrontLimitDate = this.GetNextLimitDate(1, nextWkPlanexedate, workOrder.TheWorkInfo.CIRCLEUNIT, (int)workOrder.TheWorkInfo.CIRCLEFRONTLIMIT);
                    string sNextFrontLimitDate = "null";
                    DateTime nextBackLimitDate = this.GetNextLimitDate(2, nextWkPlanexedate, workOrder.TheWorkInfo.CIRCLEUNIT, (int)workOrder.TheWorkInfo.CIRCLEBACKLIMIT);
                    string sNextBackLimitDate = "null";
                    sNextFrontLimitDate = "'" + nextFrontLimitDate.ToString("yyyy-MM-dd") + "'";
                    sNextBackLimitDate = "'" + nextBackLimitDate.ToString("yyyy-MM-dd") + "'";
                    //下一个工单的预计执行表值、前允差小时数与后允差小时数.
                    int nextWkOrderValue = (int)workOrder.EXCUTEVALUE + (int)workOrder.TheWorkInfo.TIMINGPERIOD;//注意：下次预计执行表值=本次实际执行表值（而非预计）+周期.
                    int timingFrontLimitHours = nextWkOrderValue - (int)workOrder.TheWorkInfo.TIMINGFRONTLIMIT;
                    string sTimingFrontLimitHours = "null";
                    int timingBackLimitHours = nextWkOrderValue + (int)workOrder.TheWorkInfo.TIMINGBACKLIMIT;
                    string sTimingBackLimitHours = "null";
                    if (workOrder.TheWorkInfo.TIMINGFRONTLIMIT > 0)
                    {
                        sTimingFrontLimitHours = timingFrontLimitHours.ToString();
                    }
                    else
                    {
                        sTimingFrontLimitHours = nextWkOrderValue.ToString();//如果前允差为0，则前允差小时数=预计执行表值.
                    }
                    if (workOrder.TheWorkInfo.TIMINGBACKLIMIT > 0)
                    {
                        sTimingBackLimitHours = timingBackLimitHours.ToString();
                    }
                    else
                    {
                        sTimingBackLimitHours = nextWkOrderValue.ToString();//如果前允差为0，则后允差小时数=预计执行表值.
                    }
                    sSql = "insert into t_workorder(workorderid,workinfoid,workordername,workorderstate,principalpost,confirmpost,";
                    sSql += "planexedate,circlefrontlimitdate,circlebacklimitdate,nextvalue,timingfrontlimithours,timingbacklimithours,ship_id) values(";
                    sSql += "'" + nextWorkOrderId + "','" + workOrder.WORKINFOID + "','" + workOrder.WORKORDERNAME + "',1,";
                    sSql += "'" + workOrder.PRINCIPALPOST + "','" + workOrder.CONFIRMPOST + "','" + nextWkPlanexedate.ToString("yyyy-MM-dd") + "',";
                    sSql += sNextFrontLimitDate + "," + sNextBackLimitDate + "," + nextWkOrderValue + "," + sTimingFrontLimitHours + ",";
                    sSql += sTimingBackLimitHours + ",'" + workOrder.SHIP_ID + "')";
                    lstSqlOpt.Add(sSql);
                }
            }
            //根据集合dictWkInstead中的替代与被替代工单Id信息更新t_workorder中的有替代情况的工单（insteadedwkid）.
            foreach (string key in dictWkInstead.Keys)
            {
                sSql = "update t_workorder set insteadedwkid = '" + dictWkInstead[key] + "' where workorderid = '" + key + "'";
                lstSqlOpt.Add(sSql);
            }
            //调用dbAccess的execSql执行lstSqlOpt中的所有的操作语句.
            return dbAccess.ExecSql(lstSqlOpt, out err);

        }

        #region 工单与CMS检验和船舶修理相结合的部分
        public bool GetOrCreateWorkOrderByWorkInfoAndTime(WorkInfo workInfo, DateTime referenceDate, out WorkOrder theWorkOrder, out string err)
        {
            theWorkOrder = null;
            if (workInfo == null || workInfo.IsWrong)
            {
                err = "传入的工作信息无效！";
                return false;
            }
            sql = "select workorderid,workorderstate from V_WorkOrder"
                + "\rwhere circlefrontlimitdate <" + dbOperation.DbToDate(referenceDate) + " and circlebacklimitdate > " + dbOperation.DbToDate(referenceDate)
                + "\r and workinfoid = '" + workInfo.GetId() + "'"
                + "\rorder by planexedate desc";
            DataTable dt;
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                if (dt.Rows.Count > 0)
                {
                    theWorkOrder = getObject(dt.Rows[0]["workorderid"].ToString(), out err);
                    return true;
                }
                else
                {
                    DateTime frontPermitTime = GetNextLimitDate(1, referenceDate, workInfo.CIRCLELIMITUNIT, (int)workInfo.CIRCLEFRONTLIMIT);
                    DateTime afterPermitTime = GetNextLimitDate(2, referenceDate, workInfo.CIRCLELIMITUNIT, (int)workInfo.CIRCLEBACKLIMIT);
                    //创建一条工单，并返回.
                    theWorkOrder = new WorkOrder("", workInfo.GetId(), workInfo.WORKINFONAME, 1, referenceDate, System.DateTime.MinValue,
                        frontPermitTime, afterPermitTime, 0, 0, 0, 0, 0, 0, "", "", "", "", "本工单是在为CMS检验项目关联工单时自动生成", workInfo.PRINCIPALPOST,
                        workInfo.CONFIRMPOST, 1, workInfo.ISREPAIRPROJECT, workInfo.SHIP_ID, DateTime.Today);
                    return theWorkOrder.Update(out err);
                }
            }
            else
            {
                return false;
            }
        }
        #endregion
        #region 工单备件
        /// <summary>
        /// 保存工单备件消耗信息.
        /// </summary>
        /// <param name="workOrderId">工单Id</param>
        /// <param name="workInfoId">工作信息Id</param>
        /// <param name="dtb">包含工单备件消耗信息的DataTable</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public bool WorkOrderSpConsume(string workOrderId, string workInfoId, bool isOut, DataTable dtb, out string err)
        {
            List<string> lstSqlOpt = new List<string>();    //包含操作语句的List泛型集合.
            string sSql = "";                               //操作的SQL语句.
            string useSpareId = "";                         //主键Id
            string spareId = "";                            //备件Id
            string usedCount = "";                          //实际消耗数量.
            string shipId = "";                             //船舶Id 
            foreach (DataRow curRow in dtb.Rows)
            {
                useSpareId = curRow["usespareid"].ToString();
                spareId = curRow["spareid"].ToString();
                usedCount = curRow["usedcount"].ToString();
                if (usedCount == "") usedCount = "0";
                shipId = curRow["ship_id"].ToString();
                if (useSpareId == "")
                {
                    if (usedCount != "0")
                    {
                        useSpareId = Guid.NewGuid().ToString();
                        sSql = "insert into t_workorder_usespare(usespareid, workorderid, workinfoid, spare_id, usedcount, ship_id,finished) ";
                        sSql += "values('" + useSpareId + "','" + workOrderId + "','" + workInfoId + "',";
                        sSql += "'" + spareId + "'," + usedCount + ",'" + shipId + "'," + (isOut ? "1" : "0") + ")";
                        lstSqlOpt.Add(sSql);
                    }
                }
                else
                {
                    sSql = "update t_workorder_usespare set workorderid = '" + workOrderId + "',";
                    sSql += "workinfoid = '" + workInfoId + "',spare_id = '" + spareId + "',";
                    sSql += "usedcount = " + usedCount + ",ship_id = '" + shipId + "', finished =" + (isOut ? "1" : "0");
                    sSql += "\rwhere usespareid = '" + useSpareId + "' and finished <> 1";
                    lstSqlOpt.Add(sSql);
                }
            }

            //调用dbAccess的execSql执行lstSqlOpt中的所有的操作语句.
            return dbAccess.ExecSql(lstSqlOpt, out err);
        }
        /// <summary>
        ///  取得指定工单的备件消耗信息.
        /// </summary>
        /// <param name="workOrderId">工单Id</param>
        /// <param name="workInfoId">工作信息Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetWorkOrderSpConsume(string workOrderId, string workInfoId)
        {
            //变量定义部分.
            DataTable dtb;//定义一个DataTable对象.
            string err = "";     //错误信息返回参数.
            string sSql = "";               //查询数据所需的SQL语句.

            //Select语句加工部分.
            sSql = "select ";
            sSql += "a.spareid,";
            sSql += "b.spare_name,b.PARTNUMBER,";
            sSql += "d.usespareid,";
            sSql += "b.unit_name,";
            sSql += "a.defaultusecount,";
            sSql += "d.usedcount,isnull(e.stocks,0) stocks,case when defaultusecount - isnull(e.stocks,0) > 0 then 1 else 0 end warning,";
            sSql += "a.ship_id,case d.finished when 1 then '已出库' else '未出库' end finished";
            sSql += "\rfrom t_workinfo_usespare a ";
            sSql += "inner join t_spare b on a.spareid = b.spare_id ";
            sSql += "left join (";
            sSql += "             select usespareid, workinfoid, spare_id, usedcount,finished from t_workorder_usespare";
            sSql += "             where workorderid = '" + workOrderId + "' and workinfoid = '" + workInfoId + "'";
            sSql += "          ) d on a.workinfoid = d.workinfoid and a.spareid = d.spare_id ";
            sSql += "left join (select spare_id,ship_id, sum(STOCKSAll) stocks from V_SPARE_STOCKS group by spare_id,ship_id) e on b.spare_id = e.spare_id and a.ship_id = e.ship_id ";
            sSql += "\rwhere a.workinfoid = '" + workInfoId + "' ";
            sSql += "order by b.spare_name";

            dbAccess.GetDataTable(sSql, out dtb, out err);
            return dtb;
        }
        #endregion

        #region 工单工作报告
        /// <summary>
        ///  取得指定工单的工作报告信息.
        /// </summary>
        /// <param name="workOrderId">工单Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetWorkOrderMeasureReport(string workOrderId)
        {
            //变量定义部分.
            DataTable dtb;//定义一个DataTable对象.
            string err = "";     //错误信息返回参数.
            string sSql = "";               //查询数据所需的SQL语句.

            //Select语句加工部分.
            sSql = "select ";
            sSql += "a.workordermearptid,";
            sSql += "a.file_id,";
            sSql += "b.file_name,";
            sSql += "b.object_id,";
            sSql += "b.creator,";
            sSql += "b.ship_id,";
            sSql += "b.create_date ";
            sSql += "from t_workorder_measurereport a ";
            sSql += "inner join t_file_manage b on a.file_id = b.file_id ";
            sSql += "where a.workorderid = '" + workOrderId + "'";

            dbAccess.GetDataTable(sSql, out dtb, out err);
            return dtb;
        }

        /// <summary>
        /// 保存工单的工作报告.
        /// </summary>
        /// <param name="workOrderId">工单Id</param>
        /// <param name="fileId">大文档Id</param>
        /// <param name="shipId">船舶Id</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public bool SaveWorkOrderMeasureReport(string workOrderId, string fileId, string shipId, out string err)
        {
            string sSql = "";   //操作的SQL语句.

            sSql = "insert into t_workorder_measurereport(workordermearptid, workorderid, file_id, ship_id) ";
            sSql += "values('" + Guid.NewGuid().ToString() + "','" + workOrderId + "','" + fileId + "','" + shipId + "')";

            //调用dbAccess的execSql执行sSql中的操作语句.
            return dbAccess.ExecSql(sSql, out err);
        }

        /// <summary>
        /// 删除工单的工作报告.
        /// </summary>
        /// <param name="workOrderMeaRptId">工单工作报告信息Id</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public bool DelWorkOrderMeasureReport(string workOrderMeaRptId, out string err)
        {
            string sSql = "";   //操作的SQL语句.
            sSql = "delete from t_workorder_measurereport where workordermearptid = '" + workOrderMeaRptId + "'";

            //调用dbAccess的execSql执行sSql中的操作语句.
            return dbAccess.ExecSql(sSql, out err);
        }
        #endregion

        #region 替代完成工单

        /// <summary>
        /// 得到某些工作是否均具备测量报告.
        /// 注意有些工单本身就不需要测量报告.
        /// </summary>
        /// <param name="workOrdersId"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool AllWorkOrdersHaveMeasureReport(List<string> workOrdersId)
        {
            if (workOrdersId.Count == 0) return true;
            string allWorkOrderIds = "";
            for (int i = 0; i < workOrdersId.Count; i++)
            {
                if (allWorkOrderIds.Length == 0) allWorkOrderIds = "'" + workOrdersId[i] + "'";
                else allWorkOrderIds += ",'" + workOrdersId[i] + "'";
            }
            sql = string.Format(@"select count(1) 
                    from T_WORKORDER a 
		                inner join T_WORKINFO b on a.workinfoid = b.workinfoid 
                        inner join T_WORKINFO_MEASUREREPORT c on b.workinfoid = c.workinfoid
                        left join T_WORKORDER_MEASUREREPORT d on a.WORKORDERID = d.WORKORDERID
                    where a.WORKORDERID in ({0}) and d.WORKORDERID is null
                    ", allWorkOrderIds);
            return dbAccess.GetString(sql) == "0";
        }

        public DataTable getReplacedWorkFor(string workOrderId)
        {
            string err;
            sql = "select t1.workorderid,t1.workordername,t1.workorderstate, t1.workdescription "
                + "\rfrom V_WorkOrder t1 inner join t_workOrder t2 on t1.workorderid = t2.INSTEADEDWKID "
                + "\rwhere t2.workorderid  = '" + workOrderId.Replace("'", "''") + "'";
            DataTable dtb;
            dbAccess.GetDataTable(sql, out dtb, out err);
            return dtb;
        }

        /// <summary>
        ///  取得指定工作信息下的所有工单.
        /// </summary>
        /// <param name="workInfoId">工作信息Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetWorkOrderForWkInfo(string workInfoId)
        {
            //变量定义部分.
            DataTable dtb;//定义一个DataTable对象.
            string err = "";     //错误信息返回参数.
            string sSql = "";               //查询数据所需的SQL语句.

            //Select语句加工部分.
            sSql += "select * from v_workorder where workinfoid = '" + workInfoId + "' order by planexedate desc, workordername";
            dbAccess.GetDataTable(sSql, out dtb, out err);
            return dtb;
        }

        /// <summary>
        /// 得到当前未完成的所有修理项目类型的工单.
        /// </summary>
        /// <param name="shipId">哪条船舶</param>
        /// <param name="sCompUnitIds">那个设备或</param>
        /// <param name="dtb"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool GetRepairWorkOrders(string shipId, string sCompUnitIds, out DataTable dtb, out string err)
        {
            //Select语句加工部分.
            sql = "select [workorderid],[workordername],[circleortimingname],[workorderstatename],[principalpost],[principalpostname]"
                + " ,[confirmpost],[confirmpostname],[planexedate],[workexecutor],[workinfodetail],[workcompletedinfo]"
                + " ,[workdescription],[component_unit_id],[ship_id] from v_workorder "
                + "\rwhere ship_id = '" + shipId + "'  and isrepairproject = 1";
            if (sCompUnitIds.Trim() != "")
            {
                sql += "\rand component_unit_id in (" + sCompUnitIds + ")";
            }
            sql += "\rorder by confirmpostname,workordername";
            return dbAccess.GetDataTable(sql, out dtb, out err);
        }
        /// <summary>
        ///  取得指定条件的工单信息.
        /// </summary>
        /// <param name="shipId">船舶Id</param>        
        /// <param name="workOrderState">工单状态</param>
        /// <param name="workOrderType">工单类型</param>
        /// <param name="isCheckProject">检验项目</param>
        /// <param name="isRepairProject">修理项目</param>
        /// <param name="sCompUnitIds">包含设备Id的字符串（仅当按设备筛选时才传入该参数）</param>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetWorkOrders(string shipId, string workOrderState, string workOrderType,
                                      string isCheckProject, string isRepairProject, string sCompUnitIds, bool withOthersData)
        {
            //变量定义部分.
            DataTable dtb;//定义一个DataTable对象.
            string err = "";     //错误信息返回参数.
            string sSql = "";               //查询数据所需的SQL语句.
            string sWhere = "";             //Where条件部分.
            string shipHeadShipId = "";     //当前登录用户岗位Id

            shipHeadShipId = CommonOperation.ConstParameter.LoginUserInfo.PostId;

            sWhere = " and a.ship_id = '" + shipId + "' ";

            if (workOrderState != "")
            {
                //如果要查询超期的工单则根据报警状态字段来查询.
                if (workOrderState == "(2)")
                {
                    sWhere += " and a.alertstate = 3 ";
                }
                else
                {
                    sWhere += " and a.workorderstate in " + workOrderState;
                }
            }
            if (workOrderType != "")
            {
                if (workOrderType == "5")
                {
                    sWhere += " and a.iscombinedorder = 1 ";
                }
                else if (workOrderType == "6")
                {
                    sWhere += " and a.istempworkorder = 1 ";
                }
                else
                {
                    sWhere += " and a.circleortiming = '" + workOrderType + "' ";
                }
            }
            if (isCheckProject != "")
            {
                sWhere += " and a.ischeckproject = " + isCheckProject;
            }
            if (isRepairProject != "")
            {
                sWhere += " and a.isrepairproject = " + isRepairProject;
            }
            if (sCompUnitIds.Trim() != "")
            {
                sWhere += " and (a.component_unit_id is not null and a.component_unit_id in (" + sCompUnitIds + "))";
            }
            if (!CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS && !CommonOperation.ConstParameter.IsLandVersion)
            {
                if (withOthersData || CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER)
                {
                    sWhere += " and b.DEPARTMENTID = '" + CommonOperation.ConstParameter.LoginUserInfo.DepartmentId + "'";
                }
                else
                {
                    sWhere += " and (a.principalpost = '" + shipHeadShipId + "' or a.confirmpost = '" + shipHeadShipId + "') ";
                }
            }
            //Select语句加工部分.
            sSql += "select null as sel,a.* from ";
            sSql += "(select *,";
            //设置报警状态（如果当前工单是定期与定时性质，那么取其最严重的报警状态；如果是定期或者定时工单，直接取ctalertstate字段值.
            sSql += "case when circleortiming = 3 and circlealertstate > timingalertstate then circlealertstate ";
            sSql += "     when circleortiming = 3 and circlealertstate <= timingalertstate then timingalertstate ";
            sSql += "     else ctalertstate end as alertstate ";
            sSql += "from v_workorder) a inner join T_BASE_HEADSHIP b on a.confirmpost = b.SHIP_HEADSHIP_ID";
            sSql += "\rwhere a.workorderstate <=5 ";
            sSql += sWhere;
            sSql += " order by a.planexedate, a.alertstate desc,a.confirmpostname,a.workordername";

            dbAccess.GetDataTable(sSql, out dtb, out err);
            return dtb;
        }

        /// <summary>
        ///  取得指定的工单的所有可替代的工单.
        /// </summary>
        /// <param name="workOrderId">当前工单Id</param>
        /// <param name="workInfoId">当前工单所对应的工作信息Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetWorkOrderInstead(string workOrderId, string workInfoId)
        {
            //变量定义部分.
            DataTable dtb;//定义一个DataTable对象.
            string err = "";     //错误信息返回参数.
            string sSql = "";               //查询数据所需的SQL语句.

            //Select语句加工部分.
            sSql += "select ";
            sSql += "case when b.wkinfosteadselid is null then 0 ";
            sSql += "     else 1 end as chkSel,";
            sSql += "a.workorderid,";
            sSql += "a.workordername,";
            sSql += "a.workinfoid,";
            sSql += "a.circleortiming,";
            sSql += "a.circleortimingname,";
            sSql += "a.planexedate,";
            sSql += "a.nextvalue,";
            sSql += "a.total_workhours,";
            sSql += "null as btnSel,";
            sSql += "case when c.workreportid is not null then '双击' end as measurereport,";
            sSql += "a.workcompletedinfo,";
            sSql += "a.iscombinedorder,";
            sSql += "a.istempworkorder,a.WORKDESCRIPTION  ";
            sSql += "from v_workorder a ";
            sSql += "left join(";
            sSql += "           select wkinfosteadselid, insteadworkorderid from t_workinfosteadsel where workorderid = '" + workOrderId + "'";
            sSql += "         ) b on a.workorderid = b.insteadworkorderid ";
            sSql += "left join t_workinfo_measurereport c on a.workinfoid = c.workinfoid ";
            sSql += "where a.workinfoid in (select InsteadedWorkinfoId from t_workinfoinsteadrelation where mainworkinfoid = '" + workInfoId + "')";
            sSql += "      and (a.workorderstate = 1 or a.workorderstate = 2) ";
            sSql += "order by a.workordername";

            dbAccess.GetDataTable(sSql, out dtb, out err);
            return dtb;
        }

        /// <summary>
        ///  取得指定条件的工单历史信息.
        /// </summary>
        /// <param name="shipId">船舶Id</param>        
        /// <param name="startFinDate">查询起始日期</param>
        /// <param name="endFinDate">查询终止日期</param>
        /// <param name="workOrderState">工单状态</param>
        /// <param name="workOrderType">工单类型</param>
        /// <param name="principalPost">责任人岗位</param>
        /// <param name="confirmPost">确认人岗位</param>
        /// <param name="isCheckProject">检验项目</param>
        /// <param name="isRepairProject">修理项目</param>
        /// <param name="sCompUnitIds">包含设备Id的字符串（仅当按设备筛选时才传入该参数）</param>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetWorkOrderHistory(string shipId, string startFinDate, string endFinDate, string workOrderState, string workOrderType,
           string principalPost, string confirmPost, string isCheckProject, string isRepairProject, string sCompUnitIds, bool withOthersData)
        {
            //变量定义部分.
            DataTable dtb;//定义一个DataTable对象.
            string err = "";     //错误信息返回参数.
            string sSql = "";               //查询数据所需的SQL语句.
            string sWhere = "";             //Where条件部分.
            if (CommonOperation.ConstParameter.IsLandVersion && shipId.Length > 0) sWhere = " and ship_id = '" + shipId + "'";

            sWhere += " and  completeddate between '" + startFinDate + "' and '" + endFinDate + "' ";

            if (workOrderState != "")
            {
                sWhere += " and workorderstate = '" + workOrderState + "' ";
            }
            if (workOrderType != "")
            {
                if (workOrderType == "5")
                {
                    sWhere += " and iscombinedorder = 1 ";
                }
                else if (workOrderType == "6")
                {
                    sWhere += " and istempworkorder = 1 ";
                }
                else
                {
                    sWhere += " and circleortiming = '" + workOrderType + "' ";
                }
            }
            if (principalPost != "")
            {
                sWhere += " and principalpost = '" + principalPost + "'";
            }
            if (confirmPost != "")
            {
                sWhere += " and confirmpost = '" + confirmPost + "'";
            }
            if (isCheckProject != "")
            {
                sWhere += " and ischeckproject = " + isCheckProject;
            }
            if (isRepairProject != "")
            {
                sWhere += " and isrepairproject = " + isRepairProject;
            }
            if (sCompUnitIds.Trim() != "")
            {
                sWhere += " and (component_unit_id is not null and component_unit_id in (" + sCompUnitIds + "))";
            }

            if (!CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS && !CommonOperation.ConstParameter.IsLandVersion)
            {
                if (withOthersData || CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER)
                {
                    Post leader;
                    PostService.Instance.GetDepartLeaderPost(CommonOperation.ConstParameter.LoginUserInfo.DepartmentId, out leader, out err);
                    sWhere += " and (principalpostname = '" + CommonOperation.ConstParameter.LoginUserInfo.ShipHeadShipName +
                           "' or confirmpostname = '" + CommonOperation.ConstParameter.LoginUserInfo.ShipHeadShipName +
                           (leader == null ? "')" : "' or confirmpostname = '" + leader.POSTNAME + "')");
                }
                else
                {
                    sWhere += " and (principalpostname = '" + CommonOperation.ConstParameter.LoginUserInfo.ShipHeadShipName +
                        "' or confirmpostname = '" + CommonOperation.ConstParameter.LoginUserInfo.ShipHeadShipName + "') ";
                }
            }
            //Select语句加工部分.
            sSql += "select * from v_workorder ";
            sSql += "\rwhere workorderstate > 5 ";
            sSql += sWhere;
            sSql += "\rorder by completeddate desc, workordername";
            dbAccess.GetDataTable(sSql, out dtb, out err);
            return dtb;
        }

        #endregion

        #region 合并工单
        /// <summary>
        /// 取得指定合并工单所对应的工作信息，合并工单一般对应多个工作信息.
        /// </summary>
        /// <param name="workOrderId">工单Id（合并的工单）</param>
        /// <returns>返回合并工单所对应的工作信息</returns>
        public string GetCombinedWorkInfo(string workOrderId)
        {
            string err = "";     //错误信息返回参数.
            DataTable dtb;//定义一个DataTable对象.
            string sSql = "";               //查询数据所需的SQL语句.
            string combinedWorkInfo = "";   //合并工单所对应的工作信息.
            string workinfodetail = "";     //工作信息内容.

            //Select语句加工部分.
            sSql += "select workinfodetail from t_workinfo a ";
            sSql += "inner join t_workorder_combined b on a.workinfoid = b.workinfoid ";
            sSql += "where b.WORKTASKID = '" + workOrderId + "'";
            dbAccess.GetDataTable(sSql, out dtb, out err);
            if (dtb != null)
            {
                foreach (DataRow dataRow in dtb.Rows)
                {
                    workinfodetail = dataRow["workinfodetail"].ToString();
                    combinedWorkInfo = combinedWorkInfo + workinfodetail + "\r\n";
                }
            }
            return combinedWorkInfo;
        }

        /// <summary>
        ///  取得要合并成工单的工作信息.
        /// </summary>
        /// <param name="lstWorkInfoIds">要合并的工作信息Id组成的List集合</param>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetCombinedWorkInfo(List<string> lstWorkInfoIds)
        {
            //变量定义部分.
            DataTable dtb = new DataTable();//定义一个DataTable对象.
            string err = "";     //错误信息返回参数.
            string sSql = "";               //查询数据所需的SQL语句.
            string workInfoIds = "(";       //工作信息Id用逗号组成的字符串.

            //把所有的工作信息Id组成一个用逗号连接成的字符串.
            foreach (string workInfoId in lstWorkInfoIds)
            {
                workInfoIds += "'" + workInfoId + "',";
            }

            if (workInfoIds != "(")
            {
                workInfoIds = workInfoIds.Substring(0, workInfoIds.Length - 1) + ")";

                //Select语句加工部分.
                sSql += "select ";
                sSql += "a.workinfoid,";
                sSql += "a.workinfoname,";
                sSql += "a.circleortiming,";
                sSql += "case when a.circleortiming = 1 then '定期'";
                sSql += "     when a.circleortiming = 2 then '定时'";
                sSql += "     when a.circleortiming = 3 then '定期和定时'";
                sSql += "     end as circleortimingname,";
                sSql += "a.principalpost,";
                sSql += "b.headship_name as principalpostname,";
                sSql += "a.confirmpost,";
                sSql += "c.headship_name as confirmpostname ";
                sSql += "from t_workinfo a ";
                sSql += "left join t_base_headship b on a.principalpost = b.ship_headship_id ";
                sSql += "left join t_base_headship c on a.confirmpost = c.ship_headship_id ";
                sSql += "\rwhere workinfoid in " + workInfoIds;
                sSql += "\rorder by a.workinfoname";

                dbAccess.GetDataTable(sSql, out dtb, out err);
            }

            return dtb;
        }

        #endregion

        #region 抄表相关

        /// <summary>
        /// 取指定工单集合lstWorkOrderIds中所有定时工单的所有未抄表的设备名称.
        /// </summary>
        /// <param name="lstWorkOrderIds">要完工的工单Id集合</param>
        /// <param name="completeDate">完工日期</param>
        /// <returns>返回所有定时工单的所有未抄表的设备名称</returns>
        public string GetAllNoWatchComp(List<string> lstWorkOrderIds, string completeDate)
        {
            string sAllNoWatchComp = "";    //所有定时工单的所有未抄表的设备名称.
            string err = "";     //错误信息返回参数.
            DataTable dtb;//定义一个DataTable对象.
            string workOrderName = "";      //工单名称.
            string componentUnitId = "";    //设备Id
            string compChineseName = "";    //设备名称.
            string sSql = "";               //查询数据所需的SQL语句.

            foreach (string workOrderId in lstWorkOrderIds)
            {
                //查找当前工单名称以及当前工单Id所对应的工作信息Id的设备Id与设备名称.
                sSql = "select workordername, component_unit_id, comp_chinese_name from t_workorder a ";
                sSql += "inner join t_workinfo b on a.workinfoid = b.workinfoid ";
                sSql += "inner join t_component_unit c on b.refobjid = c.component_unit_id ";
                sSql += "where b.circleortiming != 1 and b.circleortiming != 4 and a.workorderid = '" + workOrderId + "'";

                if (dbAccess.GetDataTable(sSql, out dtb, out err) && dtb.Rows.Count > 0)
                {
                    workOrderName = dtb.Rows[0]["workordername"].ToString();        //当前工单名称.
                    componentUnitId = dtb.Rows[0]["component_unit_id"].ToString();  //当前工单对应的设备Id
                    compChineseName = dtb.Rows[0]["comp_chinese_name"].ToString();  //当前工单对应的设备名称.

                    //在抄表记录表t_gauge判断在完工日期completeDate内当前项目关键过程是否有抄表记录
                    sSql = @" select t1.GAUGE_ID  from t_gauge t1 inner join T_GAUGE_LOG t2 on t1.COMPONENT_UNIT_ID = t2.COMPONENT_UNIT_ID
                    where t2.component_unit_id ='" + componentUnitId + "' and convert(varchar(10), t2.gauge_time, 120) = " + dbOperation.DbToDate(completeDate);
                    
                    dbAccess.GetDataTable(sSql, out dtb, out err);
                    if (dtb.Rows.Count == 0)
                    {
                        sAllNoWatchComp += "工单名称：" + workOrderName + "；对应设备：" + compChineseName + "；\r\n";
                    }
                }
            }

            //返回所有定时工单的所有未抄表的设备名称.
            return sAllNoWatchComp;
        }

        /// <summary>
        /// 保完工情况说明到工单表t_workorder的workcompletedinfo字段.
        /// </summary>
        /// <param name="dtb">包含完工情况说明的DataTable对象</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public bool SaveWorkCompletedInfo(DataTable dtb, out string err)
        {
            List<string> lstSqlOpt = new List<string>();    //包含操作语句的List泛型集合.
            string sSql = "";                               //操作的SQL语句.
            string workorderId = "";                        //当前工单Id
            string workcompletedinfo = "";                  //完工情况说明.

            foreach (DataRow curRow in dtb.Rows)
            {
                workorderId = curRow["workorderid"].ToString();

                //取完工情况说明.
                workcompletedinfo = curRow["workcompletedinfo"].ToString();
                sSql = "update t_workorder set workcompletedinfo = N'" + workcompletedinfo + "' where workorderid = '" + workorderId + "'";
                lstSqlOpt.Add(sSql);
            }

            //调用dbAccess的execSql执行lstSqlOpt中的所有的操作语句.
            return dbAccess.ExecSql(lstSqlOpt, out err);
        }

        /// <summary>
        /// 保存为指定工单选择的要替代的工单信息.
        /// </summary>
        /// <param name="workOrderId">工单Id</param>
        /// <param name="dataRow">包含为workOrderId工单选择的要替代的工单Id集合</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public bool WorkOrderInsteadSel(string workOrderId, DataRow[] dataRows, out string err)
        {
            List<string> lstSqlOpt = new List<string>();    //包含操作语句的List泛型集合.
            string sSql = "";                               //操作的SQL语句.

            sSql = "delete from t_workinfosteadsel where workorderid = '" + workOrderId + "'";
            lstSqlOpt.Add(sSql);

            foreach (DataRow curRow in dataRows)
            {
                string insteadWorkOrderId = curRow["workorderid"].ToString();//当前选择的要替代的工单Id
                sSql = "insert into t_workinfosteadsel(wkinfosteadselid, workorderid, insteadworkorderid) values(";
                sSql += "'" + Guid.NewGuid().ToString() + "','" + workOrderId + "','" + insteadWorkOrderId + "')";
                lstSqlOpt.Add(sSql);
            }

            //调用dbAccess的execSql执行lstSqlOpt中的所有的操作语句.
            return dbAccess.ExecSql(lstSqlOpt, out err);
        }
        /// <summary>
        /// 取当前完工界面的所有要完工的工单的Id集合。这个集合包括主工单Id，.
        /// 还要包括主工单所有要替代完工的工单Id，集合不能有重复的项。.
        /// 同时还要返回一个Dictionary集合，这个集合包含当前要完工的所有工单Id与替代工单Id
        /// （第一项是被替代的工单Id，第二项是替代的工单Id）.
        /// </summary>
        /// <param name="dtb">包含主工单Id的DataTable对象</param>
        /// <param name="dictWkInstead">包含被替代与替代工单Id的Dictionary集合</param>
        /// <returns>返回所有要完工的工单Id集合</returns>
        public List<string> GetCompleteWorkOrderIds(DataTable dtb, out Dictionary<string, string> dictWkInstead)
        {
            string err = "";                         //错误信息参数.
            List<string> lstWorkOrderIds = new List<string>();  //包含工单Id的集合对象.
            string sSql = "";                                   //SQL语句.
            string workOrderId = "";                            //当前主工单Id
            string insteadWorkOrderId = "";                     //当前被替代的工单Id

            //实例化集合对象dictWkInstead
            dictWkInstead = new Dictionary<string, string>();

            foreach (DataRow curRow in dtb.Rows)
            {
                workOrderId = curRow["workorderid"].ToString();
                if (lstWorkOrderIds.Contains(workOrderId) == false)
                {
                    lstWorkOrderIds.Add(workOrderId);
                }

                sSql = "select insteadworkorderid from t_workinfosteadsel where workorderid = '" + workOrderId + "'";
                DataTable dtbInstead;
                dbAccess.GetDataTable(sSql, out dtbInstead, out err);
                foreach (DataRow insteadRow in dtbInstead.Rows)
                {
                    insteadWorkOrderId = insteadRow["insteadworkorderid"].ToString();
                    //把当前被替代的工单Id（insteadWorkOrderId）与替代的工单Id（workOrderId）添加到集合dictWkInstead中.
                    dictWkInstead.Add(insteadWorkOrderId, workOrderId);
                    if (lstWorkOrderIds.Contains(insteadWorkOrderId) == false)
                    {
                        lstWorkOrderIds.Add(insteadWorkOrderId);
                    }
                }
            }

            return lstWorkOrderIds;
        }

        /// <summary>
        ///  获得未初始化的父子设备信息.
        /// </summary>
        /// <param name="shipId">船舶Id</param>        
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetUnInitComp(string shipId)
        {
            //变量定义部分.
            DataTable dtb;    //定义一个DataTable对象.
            string err;         //错误信息返回参数.
            string sProcName = "P_Pms_NoInitTmComp";
            Dictionary<string, string> dictParam = new Dictionary<string, string>();
            dictParam.Add("@shipId", shipId);
            dbAccess.ExecProce(sProcName, dictParam, out dtb, out err);
            return dtb;
        }
         
        //add by lipeng 检索未初始化的父子设备信息.（新）2013-12-27
        public DataTable GetUnInitComp()
        {
            //变量定义部分.
            DataTable dtb;    //定义一个DataTable对象.
            string err;         //错误信息返回参数.
            string sql = string.Format(@"with cte(COMPONENT_UNIT_ID,PARENT_UNIT_ID,COMP_CHINESE_NAME,topunit,total_workhours) as 
                                            (--下级父项 
                                            select COMPONENT_UNIT_ID,PARENT_UNIT_ID,COMP_CHINESE_NAME,'0' as topunit ,total_workhours from T_COMPONENT_UNIT 
                                            where COMPONENT_UNIT_ID
                                            in (select distinct t1.COMPONENT_UNIT_ID
	                                            from T_COMPONENT_UNIT t1 inner join T_WORKINFO t2 
	                                            on t2.workInfotype = 1 --设备工作
	                                            and refobjid = t1.COMPONENT_UNIT_ID -- 设备id对应上
	                                            and t2.circleortiming in (2,3) -- 定时工作
	                                            left join dbo.T_GAUGE t3
	                                            on t1.COMPONENT_UNIT_ID = t3.COMPONENT_UNIT_ID
	                                            where t3.gauge_id is null )
                                            union all 
                                            --递归结果集中的父项 
                                            select t.COMPONENT_UNIT_ID,t.PARENT_UNIT_ID,t.COMP_CHINESE_NAME,'1' as topunit,t.total_workhours from T_COMPONENT_UNIT as t 
                                            inner join cte as c on t.COMPONENT_UNIT_ID = c.PARENT_UNIT_ID 
                                            ) 
                                            select distinct COMPONENT_UNIT_ID,topunit,
                                             '       ' + COMP_CHINESE_NAME as comp_chinese_name,
                                            case when PARENT_UNIT_ID is null then COMPONENT_UNIT_ID else PARENT_UNIT_ID end as sort,
                                            total_workhours from cte
                                            where PARENT_UNIT_ID is not null
                                            order by topunit desc");
            dbAccess.GetDataTable(sql, out dtb, out err);
            return dtb;
        }

        /// <summary>
        ///  获得已初始化的设备计时组信息数据.
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetInitComp(string shipId)
        {
            //变量定义部分.
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.

            //modify by lipeng
            //todo 此处原始代码tt1.sort > tt2.sort,这样会丢数据，改成>=就好了。
            #region 重新排序所有的设备
            sql = @" with t_gauge_sort(GAUGE_ID,sort) as
                     (
                     select GAUGE_ID,t2.SortNo from T_GAUGE t1 inner join T_COMPONENT_UNIT t2 on t1.COMPONENT_UNIT_ID = t2.COMPONENT_UNIT_ID
                     where t1.TOPUNIT = 1
                     )
                     update T_GAUGE
                     set SEED = t4.c
                     from T_GAUGE t3 inner join (select tt1.GAUGE_ID,COUNT(1) c from  t_gauge_sort tt1 inner join t_gauge_sort tt2 on tt1.sort >= tt2.sort
                     group by tt1.GAUGE_ID) t4 on t3.GAUGE_ID = t4.GAUGE_ID";
            dbAccess.ExecSql(sql, out err);

            sql = @"update  T_GAUGE
                    set subseed = t5.SEED* 10000 + t5.c
                    from T_GAUGE t inner join 
	                    (select t3.GAUGE_ID,t4.seed,t3.c from 
		                    (select t1.GAUGE_ID,t1.PARENT_UNIT_ID, count(1) c
		                     from T_GAUGE t1 inner join T_GAUGE t2 on t1.PARENT_UNIT_ID = t2.PARENT_UNIT_ID and t1.GAUGE_ID >= t2.GAUGE_ID
		                     where t1.TOPUNIT =0 and t2.TOPUNIT = 0
		                     group by t1.GAUGE_ID,t1.PARENT_UNIT_ID) t3 
		                     inner join T_GAUGE t4 on t3.PARENT_UNIT_ID = t4.COMPONENT_UNIT_ID
	                    ) t5 on t.GAUGE_ID = t5.GAUGE_ID";
            dbAccess.ExecSql(sql, out err);
            #endregion

            #region 把重复的seed重新编排
            //上个方法运行完，可能会产生重复的SEED，把重复的SEED重新排，以免画面乱套！
            string sqli = string.Format(@" with t_gauge_sort(GAUGE_ID,seed,COMPONENT_UNIT_ID,PARENT_UNIT_ID) as
                                            (
                                            select  A.GAUGE_ID,A.SEED,A.COMPONENT_UNIT_ID,A.PARENT_UNIT_ID from T_GAUGE A
                                            inner join
                                            (select seed,COUNT(*) as cnt from T_GAUGE where TOPUNIT='1' group by seed) as B
                                            on B.SEED = A.SEED
                                            where B.cnt>1)
                                            select * from (
                                            select * from t_gauge_sort
                                            union 
                                            select A.GAUGE_ID,A.SEED,A.COMPONENT_UNIT_ID,A.PARENT_UNIT_ID  from T_GAUGE A where TOPUNIT<>'1' 
                                            and LEN(SUBSEED)>4
                                            and  left(SUBSEED,LEN(SUBSEED)-4) 
                                            in (select  SEED from t_gauge_sort)) B
                                            order by seed desc");

            DataTable dt = new DataTable();
            dbAccess.GetDataTable(sqli, out dt, out err);

            if (dt.Rows.Count > 0)
            {
                

                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    if (Convert.IsDBNull( dt.Rows[i][1]))
                    {
                        break;
                    }
                    
                    string sqli1 = string.Format(@"update T_GAUGE 
                                                        set seed = (select max(seed) +1 from T_GAUGE) 
                                                        where GAUGE_ID = '{0}'", dt.Rows[i][0]);

                    dbAccess.ExecSql(sqli1, out err);

                    DataRow[] dataRows = dt.Select("parent_unit_id = '" + dt.Rows[i][2].ToString() + "'");

                    for (int j = 0; j < dataRows.Length; j++)
                    {
                        string sqli2 = string.Format(@"update T_GAUGE 
                                                        set SUBSEED = (select SEED from T_GAUGE where GAUGE_ID = '{0}') * 10000 
                                                                 + (select count(*) from T_GAUGE where parent_unit_id = '{1}') 
                                                        where GAUGE_ID = '{2}'", dt.Rows[i][0], dt.Rows[i][2], dataRows[j][0]);

                        dbAccess.ExecSql(sqli2, out err);
                    }
 
                }
            }
            #endregion

            //Select语句加工部分.
            sSql += "select ";
            sSql += "a.gauge_id,";
            sSql += "a.parent_unit_id,";
            sSql += "a.component_unit_id,";
            sSql += "case when a.topunit = 1 then b.comp_chinese_name ";
            sSql += "     else '       ' + b.comp_chinese_name end as comp_chinese_name,";
            sSql += "a.topunit,";
            sSql += "a.gauge_time,";
            sSql += "a.input_time,";
            sSql += "a.total_workhours,";
            sSql += "a.increase_hours,";
            sSql += "a.record_type,";
            sSql += "case when topunit = 1 then seed * 10000 else subseed end as fieldorder ";
            sSql += "from t_gauge a ";
            sSql += "left join t_component_unit b on a.component_unit_id = b.component_unit_id ";
            sSql += "where b.ship_id = '" + shipId + "' ";
            sSql += "order by fieldorder";
            dbAccess.GetDataTable(sSql, out dtb, out err);
            return dtb;
        }

        /// <summary>
        ///  获得当前可用的计时设备组名（但不包含当前成员所在的组的设备Id）.
        /// </summary>
        /// <param name="memGrpParentId">当前成员所在的组的设备Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetCompGrp(string memGrpParentId)
        {
            //变量定义部分.
            DataTable dtb;//定义一个DataTable对象.
            string err = "";     //错误信息返回参数.
            string sSql = "";               //查询数据所需的SQL语句.

            //Select语句加工部分.
            sSql += "select ";
            sSql += "a.gauge_id,";
            sSql += "b.comp_chinese_name ";
            sSql += "from t_gauge a ";
            sSql += "left join t_component_unit b on a.component_unit_id = b.component_unit_id ";
            sSql += "where topunit = 1 and a.component_unit_id != '" + memGrpParentId + "' ";
            sSql += "order by b.comp_chinese_name";

            dbAccess.GetDataTable(sSql, out dtb, out err);
            return dtb;
        }

        /// <summary>
        /// 设置为组操作（在网格dgvInitComp内操作）.
        /// </summary>
        /// <param name="gaugeId">当前已初始化设备的记录Id</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public bool SetToGroup(string gaugeId, out string err)
        {
            string sProcName = "P_Pms_TmCompSetToGrp";
            Dictionary<string, string> dictParam = new Dictionary<string, string>();
            dictParam.Add("@gaugeId", gaugeId);
            return dbAccess.ExecProce(sProcName, dictParam, out err);
        }

        /// <summary>
        /// 设置为指定组的成员的操作（在网格dgvInitComp内操作）.
        /// </summary>
        /// <param name="memgaugeId">成员所在的记录Id</param>
        /// <param name="grpgaugeId">要并入的组所在的记录Id</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public bool SetToMember(string memgaugeId, string grpgaugeId, out string err)
        {
            string sProcName = "P_Pms_TmCompSetToMem";
            Dictionary<string, string> dictParam = new Dictionary<string, string>();
            dictParam.Add("@memgaugeId", memgaugeId);
            dictParam.Add("@grpgaugeId", grpgaugeId);
            return dbAccess.ExecProce(sProcName, dictParam, out err);
        }

        /// <summary>
        /// 把未初始化的设备设置为组或者组成员的操作（从网格dgvUnInitComp到网格dgvInitComp移动）.
        /// </summary>
        /// <param name="grpComponentUnitId">要并入的组的设备Id</param>
        /// <param name="topunit">组标记（1表示组，0表示成员）</param>
        /// <param name="componentUnitId">要移动的设备Id</param>
        /// <param name="totalWorkhours">要移动的设备的总运转小时数（上次抄表值）</param>
        /// <param name="dataRows">如果在网格dgvUnInitComp中当前选择的设备是个组，那么取它的所有成员</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public bool SetToGroup(string grpComponentUnitId, string topunit, string componentUnitId,
                               string totalWorkhours, DataRow[] dataRows, out string err)
        {
            List<string> lstSqlOpt = new List<string>();//包含操作语句的List泛型集合.
            string sSql = "";                           //操作的SQL语句.
            string gaugeTime = DateTime.Now.ToString("yyyy-MM-dd"); //抄表时间.

            //如果当前要移动的记录是成员.

            if (topunit == "0")
            {
                //要并入的组的设备Id存在.
                if (grpComponentUnitId != "")
                {
                    //如果topunit为0，则把当前设备移动到网格dgvInitComp的grpComponentUnitId组下.
                    sSql = "insert into t_gauge(gauge_id, component_unit_id, topunit, parent_unit_id, gauge_time, total_workhours, seed, subseed) ";
                    sSql += "values('" + Guid.NewGuid().ToString() + "','" + componentUnitId + "',0,'" + grpComponentUnitId + "','" + gaugeTime + "'," + totalWorkhours;
                    sSql += ", null, dbo.F_Get_SubSeed('" + grpComponentUnitId + "'))";
                    lstSqlOpt.Add(sSql);
                }
                else
                {
                    //如果要并入的组的设备Id不存在，则把当前设备移动到网格dgvInitComp时直接变为一个组（因为这时网格中没有任何记录）.

                    sSql = "insert into t_gauge(gauge_id, component_unit_id, topunit, parent_unit_id, gauge_time, total_workhours, seed, subseed) ";
                    sSql += "values('" + Guid.NewGuid().ToString() + "','" + componentUnitId + "',1,null,'" + gaugeTime + "'," + totalWorkhours;
                    sSql += ",dbo.F_Get_Seed(), null)";
                    lstSqlOpt.Add(sSql);
                }
            }
            //如果当前要移动的记录是组.
            else
            {
                //如果topunit为1，则把当前设备移动到网格dgvInitComp后新建一个组.
                sSql = "insert into t_gauge(gauge_id, component_unit_id, topunit, parent_unit_id, gauge_time, total_workhours, seed, subseed) ";
                sSql += "values('" + Guid.NewGuid().ToString() + "','" + componentUnitId + "',1,null,'" + gaugeTime + "'," + totalWorkhours;
                sSql += ",dbo.F_Get_Seed(), null)";
                lstSqlOpt.Add(sSql);

                //当前要移动的设备由于是组，因此所它下边所有可能的成员也移动过去.

                if (dataRows != null)
                {
                    foreach (DataRow curRow in dataRows)
                    {
                        string curTotalWorkhours = curRow["total_workhours"].ToString();
                        if (curTotalWorkhours == "") curTotalWorkhours = "0";

                        sSql = "insert into t_gauge(gauge_id, component_unit_id, topunit, parent_unit_id, gauge_time, total_workhours, seed, subseed) ";
                        sSql += "values('" + Guid.NewGuid().ToString() + "','" + curRow["component_unit_id"].ToString() + "',";
                        sSql += "0,'" + componentUnitId + "','" + gaugeTime + "'," + curTotalWorkhours + ",null,dbo.F_Get_SubSeed('" + componentUnitId + "'))";
                        lstSqlOpt.Add(sSql);
                    }
                }
            }

            //调用dbAccess的execSql执行lstSqlOpt中的所有的操作语句.
            return dbAccess.ExecSql(lstSqlOpt, out err);
        }

        /// <summary>
        /// 把已初始化的设备移除（从网格dgvInitComp到网格dgvUnInitComp移动）.
        /// </summary>
        /// <param name="componentUnitId">要移除的设备Id</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public bool RemoveFromGroup(string componentUnitId, out string err)
        {
            List<string> lstSqlOpt = new List<string>();//包含操作语句的List泛型集合.
            string sSql = "";                           //操作的SQL语句.

            //先移除该设备的所有成员（如果是组就可能有成员）.

            sSql = "delete from t_gauge where parent_unit_id = '" + componentUnitId + "'";
            lstSqlOpt.Add(sSql);

            //再移除该设备.
            sSql = "delete from t_gauge where component_unit_id = '" + componentUnitId + "'";
            lstSqlOpt.Add(sSql);

            //调用dbAccess的execSql执行lstSqlOpt中的所有的操作语句.
            return dbAccess.ExecSql(lstSqlOpt, out err);
        }

        /// <summary>
        /// 初始化指定定时设备的总运转小时数（初始化包括三种操作：第一种是更新表t_gauge中的值；第二种是在表T_Gaguge_Log
        /// 中添加一条日志记录；第三种操作是在设备表t_component_unit中记录总运转小时total_workhours和上次抄表时间last_couter_time
        /// </summary>
        /// <param name="componentUnitId">设备Id</param>
        /// <param name="oldTotalWorkHours">初次录入的总运转小时数</param>
        /// <param name="gaugeTime">初次抄表值</param>
        /// <param name="dataRows">如果在网格dgvInitComp中当前选择的设备是个组，那么取它的所有成员</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public bool InitTotalWorkhours(string componentUnitId, string totalWorkHours,
                            string gaugeTime, DataRow[] dataRows, out string err)
        {
            List<string> lstSqlOpt = new List<string>();//包含操作语句的List泛型集合.
            string sSql = "";                           //操作的SQL语句.

            //先更新该设备的总运转小时.

            sSql = "update t_gauge set total_workhours = " + totalWorkHours + ", ";
            sSql += "gauge_time = '" + gaugeTime + "' where component_unit_id = '" + componentUnitId + "'";
            lstSqlOpt.Add(sSql);

            //再更新该设备的成员的总运转小时（如果是组就可能有成员）.

            sSql = "update t_gauge set total_workhours = " + totalWorkHours + ", ";
            sSql += "gauge_time = '" + gaugeTime + "' where parent_unit_id = '" + componentUnitId + "'";
            lstSqlOpt.Add(sSql);

            //向抄表日志表T_Gaguge_Log中记录日志.

            sSql = "insert into t_gauge_log(t_gauge_log_id, component_unit_id, total_workhours, gauge_time,";
            sSql += "record_type, inputor) select lower(newid()), component_unit_id, total_workhours, gauge_time, 1,";
            sSql += "'" + CommonOperation.ConstParameter.UserName + "' from t_gauge where component_unit_id = '" + componentUnitId + "' ";
            sSql += "or parent_unit_id = '" + componentUnitId + "'";
            lstSqlOpt.Add(sSql);

            //更新设备表t_component_unit中的记录总运转小时total_workhours和上次抄表时间last_couter_time
            //1.先更新组的值.

            sSql = "update t_component_unit set total_workhours = " + totalWorkHours + ",";
            sSql += "last_couter_time = '" + gaugeTime + "' where component_unit_id = '" + componentUnitId + "'";
            lstSqlOpt.Add(sSql);

            //2.再更新组下的成员的值.

            if (dataRows != null)
            {
                foreach (DataRow curRow in dataRows)
                {
                    string curCompUnitId = curRow["component_unit_id"].ToString();
                    sSql = "update t_component_unit set total_workhours = " + totalWorkHours + ",";
                    sSql += "last_couter_time = '" + gaugeTime + "' where component_unit_id = '" + curCompUnitId + "'";
                    lstSqlOpt.Add(sSql);
                }
            }

            //调用dbAccess的execSql执行lstSqlOpt中的所有的操作语句.
            return dbAccess.ExecSql(lstSqlOpt, out err);
        }

        #endregion
    }
}
