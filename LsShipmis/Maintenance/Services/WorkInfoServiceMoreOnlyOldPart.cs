using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Maintenance.DataObject;
using ItemsManage.DataObject;
using BaseInfo.DataAccess;

namespace Maintenance.Services
{
    public partial class WorkInfoService
    {
        /// <summary>
        /// 判断定时设备是否已定时初始化.
        /// </summary>
        /// <param name="component"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public Boolean IfHaveGauge(ComponentUnit component, out string err)
        {
            string sSql = "";                           //操作的SQL语句.
            if (component == null || component.IsWrong)   //设备是否已挂接到工作上.
            {
                err = "获取设备是否初始化了定时器时，发生传入设备无效的情况!" + (component != null ? "更多错误信息请参见：\r" + component.WhyWrong : "");
                return false;
            }

            //定时设备是否已初始化.
            sSql = "select * from t_gauge where component_unit_id = '" + component.COMPONENT_UNIT_ID + "'";
            DataTable dtb;
            if (dbAccess.GetDataTable(sSql, out dtb, out err))
            {
                if (dtb.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 某个设备的挂接工作信息列表。.
        /// </summary>
        public DataTable GetEquipWork(ComponentUnit Equip)
        {
            string sSql = "";
            string err;
            string componentID = "";

            if (Equip != null && Equip.COMPONENT_UNIT_ID != null)
            {
                componentID = Equip.COMPONENT_UNIT_ID;
            }

            sSql = "SELECT t1.WorkInfoID,t1.WorkInfoName, t2.headship_name worker, ";
            sSql += "case when t1.CircleOrTiming=1 then '定期' ";
            sSql += "     when t1.CircleOrTiming=2 then '定时' ";
            sSql += "     when t1.CircleOrTiming=3 then '定期/定时' end CircleOrTiming ";
            sSql += " FROM  T_WorkInfo t1 left join t_base_headship t2 on t1.principalpost=t2.ship_headship_id";
            sSql += " where t1.WorkInfoType=1 and t1.RefObjID='" + componentID + "' ";
            DataTable dtb;
            dbAccess.GetDataTable(sSql, out dtb, out err);
            return dtb;
        }

        /// <summary>
        /// 把工作信息从一个设备下拷贝到另一个设备下，但是并不安排工单.
        /// </summary>
        public bool CopyWorkInfosFromOneEquipmentToOther(ComponentUnit from, ComponentUnit to, out string err)
        {
            #region copy 形成时 有个问题没有处理，--> 重复的不再次形成，避免重复添加后不好处理。

            sql = "insert into T_WORKINFO ("
                  + " [WORKINFOID]"
                  + " ,[REFOBJID]"
                  + " ,[WORKINFOTYPE]"
                  + " ,[WORKINFONAME]"
                  + " ,[WORKINFODETAIL]"
                  + " ,[WORKINFOSTATE]"
                  + " ,[CIRCLEORTIMING]"
                  + " ,[CIRCLEPERIOD]"
                  + " ,[CIRCLEUNIT]"
                  + " ,[CIRCLEFRONTLIMIT]"
                  + " ,[CIRCLEBACKLIMIT]"
                  + " ,[CIRCLELIMITUNIT]"
                  + " ,[TIMINGPERIOD]"
                  + " ,[TIMINGFRONTLIMIT]"
                  + " ,[TIMINGBACKLIMIT]"
                  + " ,[PRINCIPALPOST]"
                  + " ,[CONFIRMPOST]"
                  + " ,[ISCHECKPROJECT]"
                  + " ,[ISREPAIRPROJECT]"
                  + " ,[SHIP_ID]"
                  + " ,[WORKINFOCODE]) "
                  + "\rselect newid()"
                  + " ,'" + to.GetId() + "'"
                  + " ,[WORKINFOTYPE]"
                  + " ,[WORKINFONAME]"
                  + " ,[WORKINFODETAIL]"
                  + " ,[WORKINFOSTATE]"
                  + " ,[CIRCLEORTIMING]"
                  + " ,[CIRCLEPERIOD]"
                  + " ,[CIRCLEUNIT]"
                  + " ,[CIRCLEFRONTLIMIT]"
                  + " ,[CIRCLEBACKLIMIT]"
                  + " ,[CIRCLELIMITUNIT]"
                  + " ,[TIMINGPERIOD]"
                  + " ,[TIMINGFRONTLIMIT]"
                  + " ,[TIMINGBACKLIMIT]"
                  + " ,[PRINCIPALPOST]"
                  + " ,[CONFIRMPOST]"
                  + " ,[ISCHECKPROJECT]"
                  + " ,[ISREPAIRPROJECT]"
                  + " ,[SHIP_ID]"
                  + " ,[WORKINFOCODE] "
                  + "\rfrom T_WORKINFO"
                  + "\rwhere REFOBJID='" + from.GetId() + "'";
            #endregion
            return dbAccess.ExecSql(sql, out err);
        }

        #region 工作信息本身的主业务操作

        /// <summary>
        /// 获取工作信息是否有完成或未完成的工单.
        /// </summary>
        /// <param name="workInfoId">工作信息id</param>
        /// <returns>0没有，1有未完成的，2有已经确认的,3有混合的</returns>
        internal int getSetWorks(string workInfoId)
        {
            string err;
            sql = "SELECT COUNT(*) AS res FROM T_WorkOrder WHERE workorderstate <=5 and upper(WORKINFOID) = '" + workInfoId.ToUpper() + "'";
            DataTable dt;
            dbAccess.GetDataTable(sql, out dt, out err);

            sql = "SELECT COUNT(*) AS res FROM T_WorkOrder WHERE workorderstate > 5 and upper(WORKINFOID) = '" + workInfoId.ToUpper() + "'";
            DataTable dtf;
            dbAccess.GetDataTable(sql, out dtf, out err);

            int a = Convert.ToInt32(dt.Rows[0][0]) == 0 ? 0 : 1;
            int b = Convert.ToInt32(dtf.Rows[0][0]) == 0 ? 0 : 2;
            return a + b;
        }

        /// <summary>
        /// 工作信息列表。.
        /// </summary>        /// 
        /// <param name="shipid">空所有船，非空就指定船</param>
        /// <param name="allOrNodo">0:代表全部；1代表未首排</param>
        /// <param name="workInfoSearch"></param>
        /// <returns></returns>
        public DataTable GetWorkInfo(string shipid, int allOrNodo, List<string> workInfoSearch, bool othersData)
        {
            string sSql;
            string sWhere = string.IsNullOrEmpty(shipid) ? "" : " and t1.ship_id = '" + shipid + "'";
            string err;

            if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS || CommonOperation.ConstParameter.LoginUserInfo.ISLANDPERSON)
            {
                //do nothing 因为船长和岸上人员，如果具有这个权限，则可以看所有信息，不用过滤.
            }
            else if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER || othersData)
            {
                sWhere += " and t3.DEPARTMENTID = '" + CommonOperation.ConstParameter.LoginUserInfo.DepartmentId + "' ";
            }
            else
            { //仅自己的.
                sWhere += " and t2.headship_name = '" + CommonOperation.ConstParameter.LoginUserInfo.ShipHeadShipName + "' ";
            }

            sSql = @"SELECT t2.postlevel,t1.WORKINFOCODE, case when t1.WorkInfoID is not null then 0      else 1 end as sel,WORKINFOCODE,t4.COMP_CHINESE_NAME, t1.WorkInfoID,t1.WorkInfoName, t2.headship_name worker,t1.RefObjID, 
                    case when t1.CircleOrTiming=1 then '定期'      when t1.CircleOrTiming=2 then '定时'      when t1.CircleOrTiming=3 then '定期/定时'      when t1.CircleOrTiming=4 then '非周期' end CircleOrTiming, case when t1.WORKINFOSTATE=0 then '停止'  else '正常' end WORKINFOSTATE 
                    FROM  T_WorkInfo t1 left join t_base_headship t2 on t1.principalpost=t2.ship_headship_id  left join t_base_headship t3 on t1.CONFIRMPOST=t3.ship_headship_id
                     left join
                     (
                     select component_unit_id, COMP_CHINESE_NAME, isnull(min(workinfocode),99999) sortno
                     from t_workinfo tt1 inner join t_component_unit tt2 on tt1.RefObjID = tt2.COMPONENT_UNIT_ID
                     where tt1.workinfocode is not null
                     group by COMP_CHINESE_NAME,component_unit_id
                     )t4 on t1.RefObjID = t4.component_unit_id 
                    where 1=1 ";

            if (allOrNodo == 1)
            {
                sSql += " and t1.WorkInfoID not in (select distinct workinfoid from t_workorder where  len(workinfoid)>0)";
            }

            if (workInfoSearch[0] != "-1")
            {
                sSql += " and t1.CIRCLEORTIMING =" + workInfoSearch[0];
            }

            if (workInfoSearch[1] != "")
            {
                sSql += " and t1.PRINCIPALPOST ='" + workInfoSearch[1] + "'";
            }

            if (workInfoSearch[2] != "-1")
            {
                sSql += " and t1.WORKINFOSTATE =" + workInfoSearch[2];
            }

            if (workInfoSearch[3] != "-1")
            {
                sSql += " and t1.ISCHECKPROJECT =" + workInfoSearch[3];
            }

            if (workInfoSearch[4] != "-1")
            {
                sSql += " and t1.ISREPAIRPROJECT =" + workInfoSearch[4];
            }
            if (workInfoSearch[5].Length > 0)
            {
                sSql += " and (t1.RefObjID is not null and t1.RefObjID in(" + workInfoSearch[5] + "))";
            }
            sSql += sWhere;
            sSql += "\rorder by t2.postlevel,t4.sortno,t1.WORKINFOCODE,t1.WorkInfoName";
            DataTable dtb;
            dbAccess.GetDataTable(sSql, out dtb, out err);
            return dtb;
        }

        public string GetWorkinfoByEquipmentIdAndWorkinfoName(string EquipmentId, string workinfoName)
        {
            sql = "select WORKINFOID  from T_WORKINFO where  REFOBJID = '" + EquipmentId + "' and WORKINFONAME = '" + workinfoName + "'";
            return dbAccess.GetString(sql);
        }
        /// <summary>
        /// 校验是否还有任务(工单)在列表内.
        /// </summary>
        /// <param name="workInfoId">工作信息id</param>
        /// <returns>true有,false无</returns>
        public int getLeftValidWork(string workInfoId)
        {
            if (workInfoId == null)
            {
                workInfoId = "";
            }

            sql = "select count(workOrderId) from T_WorkOrder where upper(workInfoID)='" + workInfoId.ToUpper() + "' and workOrderState=1";
            DataTable dt;
            string err;
            dbAccess.GetDataTable(sql, out dt, out err);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
        /// <summary>
        /// 免做工作信息.
        /// </summary>
        /// <param name="wokInfo">需要免做的工作信息对象</param>
        /// <param name="cancelWorkinfoHistory">是否删除已经该工作信息已列入计划的工作，1删除，0不删除</param>
        /// <param name="err">返回操作是否成功的字符串</param>
        public bool cancelWorkInfo(Maintenance.DataObject.WorkInfo wokInfo, int cancelWorkinfoHistory, out string err)
        {
            if (cancelWorkInfo(wokInfo.WORKINFOID, cancelWorkinfoHistory, out err))
            {
                wokInfo.WORKINFOSTATE = 0;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 免做工作信息.
        /// </summary>
        /// <param name="workInfoId">需要免做的工作信息Id</param>
        /// <param name="cancelWorkinfoHistory">是否删除已经该工作信息已列入计划的工作，1删除，0不删除</param>
        /// <param name="err">返回操作是否成功的字符串</param>
        private bool cancelWorkInfo(string workInfoId, int cancelWorkinfoHistory, out string err)
        {
            List<string> list = new List<string>();
            sql = "update t_workinfo set workinfostate=0 where workinfoid='" + workInfoId + "'";
            list.Add(sql);
            if (cancelWorkinfoHistory == 1)
            {
                sql = "delete from T_WorkOrder where workinfoid='" + workInfoId + "' and WORKORDERSTATE=1";
                list.Add(sql);
            }
            return dbAccess.ExecSql(list, out err);
        }

        public DataTable GetABrifWorkInfoById(string id)
        {
            string err;
            DataTable dtb;
            sql = "select a.WORKINFONAME,a.WORKINFODETAIL,";
            sql += "case when WorkInfoState=1 then '正常' else '停止' end as WorkInfoState,";
            sql += "b.HEADSHIP_NAME as principalPost,c.HEADSHIP_NAME as SupervisorPost ";
            sql += "from t_WorkInfo a ";
            sql += "inner join T_BASE_HEADSHIP b on b.SHIP_HEADSHIP_ID=a.principalPost ";
            sql += "inner join T_BASE_HEADSHIP c on c.SHIP_HEADSHIP_ID=a.CONFIRMPOST ";
            sql += "where upper(WorkInfoID)='";
            sql += id.ToUpper();
            sql += "' ";
            dbAccess.GetDataTable(sql, out dtb, out err);
            return dtb;
        }

        /// <summary>
        ///  获得非周期性工作信息.
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetNoPerWorkInfo(string shipId)
        {
            //变量定义部分.
            DataTable dtb;//定义一个DataTable对象.
            string err = "";     //错误信息返回参数.
            string sSql = "";               //查询数据所需的SQL语句.

            //Select语句加工部分.
            sSql = "select * from v_workinfo where circleortiming = 4 ";
            sSql += "and ship_id = '" + shipId + "' order by workinfoname";
            dbAccess.GetDataTable(sSql, out dtb, out err);
            return dtb;
        }
        /// <summary>
        ///  获得首排的工作信息.
        /// </summary>
        /// <param name="lstWorkInfoIds">要合并的工作信息Id组成的List集合</param>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetFirstArrangeWorkInfo(List<string> lstWorkInfoIds)
        {
            //变量定义部分.
            DataTable dtb = null;//定义一个DataTable对象.
            string err = "";     //错误信息返回参数.
            string sSql = "";               //查询数据所需的SQL语句.
            string workInfoIds = "(";       //工作信息Id用逗号组成的字符串.

            foreach (string workInfoId in lstWorkInfoIds)
            {
                workInfoIds += "'" + workInfoId + "',";
            }

            if (workInfoIds != "(")
            {
                workInfoIds = workInfoIds.Substring(0, workInfoIds.Length - 1) + ")";

                //Select语句加工部分.
                sSql += "select * from v_workinfo where workinfoid in " + workInfoIds + " order by workinfoname";
                dbAccess.GetDataTable(sSql, out dtb, out err);
            }

            return dtb;
        }

        /// <summary>
        /// 工作信息首排操作.
        /// </summary>
        /// <param name="dtb">包含要首排的行信息的DataTable对象</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public bool WorkInfoArrange(DataTable dtb, out string err)
        {
            List<string> lstSqlOpt = new List<string>();//包含操作语句的List泛型集合.
            string sSql = "";                           //操作的SQL语句.

            foreach (DataRow curRow in dtb.Rows)
            {
                string workinfoid = curRow["workinfoid"].ToString();        //工作信息Id
                string workinfoname = curRow["workinfoname"].ToString();    //工作信息名称（工单的名称默认取工作信息名称）.
                string principalpost = curRow["principalpost"].ToString();  //责任人岗位Id
                string confirmpost = curRow["confirmpost"].ToString();      //确认者岗位Id
                string circleOrTiming = curRow["circleortiming"].ToString();//定期/定时（1表示定期，2表示定时，3表示定期与定时）.
                string workdescription = curRow["workdescription"].ToString();//工单补充说明.
                string shipId = curRow["ship_id"].ToString();               //船舶Id
                string sPlanexedate = curRow["planexedate"].ToString();     //首次执行日期（字符型）.

                DateTime planExeDate = new DateTime();                      //首次执行日期（日期型）.

                string sCircleperiod = curRow["circleperiod"].ToString();   //定期周期（字符型）.

                int circlePeriod = 0;                                       //定期周期（数值型）.

                string circleUnitName = curRow["circleunitname"].ToString();//定期周期单位.
                string sCirclefrontlimit = curRow["circlefrontlimit"].ToString();//定期前允差（字符型）.
                int circleFrontLimit = 0;                                     //定期前允差（数值型）.

                string sCirclebacklimit = curRow["circlebacklimit"].ToString();//定期后允差（字符型）.
                int circleBackLimit = 0;                                     //定期后允差（数值型）.

                string circleLimitUnitName = curRow["circlelimitunitname"].ToString();//定期允差单位.
                string sNextvalue = curRow["nextvalue"].ToString();         //首次执行表值（字符型）.
                int nextvalue = 0;                                          //首次执行表值（数值型）.

                string sTimingperiod = curRow["timingperiod"].ToString();   //定时周期（字符型）.

                int timingperiod = 0;                                       //定时周期（数值型）.
                string sTimingfrontlimit = curRow["timingfrontlimit"].ToString();//定时前允差（字符型）.
                int timingfrontlimit = 0;                                        //定时前允差（数值型）.

                string sTimingbacklimit = curRow["timingbacklimit"].ToString();//定时后允差（字符型）.
                int timingbacklimit = 0;                                       //定时后允差（数值型）.

                string ischeckproject = curRow["ischeckproject"].ToString();  //检验项目（0表示否，1表示是）.
                string isrepairproject = curRow["isrepairproject"].ToString();//修理项目（0表示否，1表示是）.
                string sArrangetimes = curRow["arrangetimes"].ToString();    //安排次数（字符型）.

                int arrangetimes = 1;                                        //安排次数（数值型）.

                if (sArrangetimes != "")
                {
                    arrangetimes = int.Parse(sArrangetimes);
                }

                //将定期的首次执行日期、定期周期、定期前允差、定期后允差转换成数值型数据.
                if (sPlanexedate != "")
                {
                    planExeDate = DateTime.Parse(sPlanexedate);
                }
                if (sCircleperiod != "")
                {
                    circlePeriod = int.Parse(sCircleperiod);
                }
                if (sCirclefrontlimit != "")
                {
                    circleFrontLimit = int.Parse(sCirclefrontlimit);
                }
                if (sCirclebacklimit != "")
                {
                    circleBackLimit = int.Parse(sCirclebacklimit);
                }

                //将定时的首次执行表值、定时周期、定时前允差、定时后允差转换成数值型数据.
                if (sNextvalue != "")
                {
                    nextvalue = int.Parse(sNextvalue);
                }
                if (sTimingperiod != "")
                {
                    timingperiod = int.Parse(sTimingperiod);
                }
                if (sTimingfrontlimit != "")
                {
                    timingfrontlimit = int.Parse(sTimingfrontlimit);
                }
                if (sTimingbacklimit != "")
                {
                    timingbacklimit = int.Parse(sTimingbacklimit);
                }

                //是否检验项目与是否修理项目变量如果为空字符串，则赋值为0
                if (ischeckproject == "") ischeckproject = "0";
                if (isrepairproject == "") isrepairproject = "0";

                //根据安排次数生成首排的工单.

                for (int i = 1; i <= arrangetimes; i++)
                {

                    /***************************定时处理部分************************************************************/
                    int timingfrontlimithours = 0;//前允差小时数.
                    int timingbacklimithours = 0; //后允差小时数.

                    //如果用户手工填写了前允差小时数与后允差小时数，则第1个工单以用户填写的小时数为准，否则根据允差值来推算（仅在第1次的循环中出现，2次以上的值都是推算出来的）.

                    if (circleOrTiming == "2")
                    {
                        if (i == 1 && curRow["timingfrontlimithours"].ToString() != "") timingfrontlimithours = int.Parse(curRow["timingfrontlimithours"].ToString());
                        if (i == 1 && curRow["timingbacklimithours"].ToString() != "") timingbacklimithours = int.Parse(curRow["timingbacklimithours"].ToString());

                        if (timingfrontlimithours == 0 && timingfrontlimit > 0)
                        {
                            timingfrontlimithours = nextvalue - timingfrontlimit;
                        }
                        else if (timingfrontlimithours == 0 && timingfrontlimit == 0)
                        {
                            timingfrontlimithours = nextvalue;//如果前允差为0，则前允差小时数=预计执行表值.

                        }

                        if (timingbacklimithours == 0 && timingbacklimit > 0)
                        {
                            timingbacklimithours = nextvalue + timingbacklimit;
                        }
                        else if (timingbacklimithours == 0 && timingbacklimit == 0)
                        {
                            timingbacklimithours = nextvalue;//如果前允差为0，则后允差小时数=预计执行表值.

                        }
                    }
                    sSql = "insert into t_workorder(workorderid, workinfoid, workorderstate, workordername, principalpost, confirmpost, ";
                    sSql += "planexedate, circlefrontlimitdate, circlebacklimitdate, nextvalue, timingfrontlimithours, timingbacklimithours, ";
                    sSql += "workdescription, ischeckproject, isrepairproject, ship_id) values('" + Guid.NewGuid().ToString() + "','" + workinfoid + "',1,N'" + workinfoname + "', ";
                    sSql += "'" + principalpost + "','" + confirmpost + "', '" + planExeDate.ToString("yyyy-MM-dd") + "',";
                    if (circleOrTiming != "2")
                    {
                        if (circleFrontLimit > 0)
                        {
                            sSql += "'" + WorkOrderService.Instance.GetNextLimitDate(1, planExeDate, circleLimitUnitName, circleFrontLimit).ToString("yyyy-MM-dd") + "',";
                        }
                        else
                        {
                            sSql += "'" + new DateTime(planExeDate.Year, planExeDate.Month, 1).ToString("yyyy-MM-dd") + "',";
                        }
                        if (circleBackLimit > 0)
                        {
                            sSql += "'" + WorkOrderService.Instance.GetNextLimitDate(2, planExeDate, circleLimitUnitName, circleBackLimit).ToString("yyyy-MM-dd") + "',";
                        }
                        else
                        {
                            sSql += "'" + new DateTime(planExeDate.Year, planExeDate.Month, 1).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") + "',";
                        }
                    }
                    else
                    {
                        sSql += "null,null,";
                    }
                    if (circleOrTiming == "2")
                    {
                        sSql += nextvalue + "," + timingfrontlimithours + ", " + timingbacklimithours + ",";
                    }
                    else
                    {
                        sSql += "null,null,null,";
                    }
                    sSql += " N'" + workdescription + "'," + ischeckproject + "," + isrepairproject + ", '" + shipId + "')";
                    lstSqlOpt.Add(sSql);

                    //调用函数GetNextPlanexedate计算下一次的执行日期.
                    if (circleOrTiming != "2") planExeDate = WorkOrderService.Instance.GetNextPlanexedate(planExeDate, circleUnitName, circlePeriod);
                    //下一个执行的运转小时数.

                    nextvalue += timingperiod;
                }
            }

            //调用dbAccess的execSql执行lstSqlOpt中的所有的操作语句.
            return dbAccess.ExecSql(lstSqlOpt, out err);
        }

        #endregion

        #region 工作信息绑定备件的相关操作

        public bool SaveWorkInfoSpareByWorkInfoId(WorkInfo workInfo, DataTable dtb, out string err)
        {
            List<string> lstSql = new List<string>();
            err = "";
            string delSql = "delete from T_workinfo_useSpare where WorkInfoId='"
                + workInfo.GetId() + "'  and ship_id='" + workInfo.SHIP_ID + "'";
            lstSql.Add(delSql);
            foreach (DataRow row in dtb.Rows)
            {
                string insertSql = "insert into T_workinfo_useSpare(WorkinfoUsespareId,WorkInfoId,SpareId,DefaultUseCount,ship_id) values('";
                insertSql += Guid.NewGuid().ToString();
                insertSql += "','";
                insertSql += workInfo.WORKINFOID;
                insertSql += "','";
                insertSql += row["SPARE_ID"].ToString();
                insertSql += "',";
                insertSql += row["DefaultUseCount"].ToString();
                insertSql += ",'";
                insertSql += workInfo.SHIP_ID + "'";
                insertSql += ") ";
                lstSql.Add(insertSql);
            }
            return dbAccess.ExecSql(lstSql, out err);
        }

        public DataTable GetWorkInfoSpareByWkId(Maintenance.DataObject.WorkInfo workInfo)
        {
            string sSql;
            string err;
            DataTable dtb;
            sSql = "select b.SPARE_ID,b.SPARE_NAME,b.SPARE_ENAME,b.PICNUMBER,b.PARTNUMBER,";
            sSql += "b.SPARESTUFF,b.ATTACHCOMP,b.ATTACHTYPE,b.CREATOR ,b.UNIT_NAME,b.REMARK,";
            sSql += "b.ISSPECIALSP,b.ALERTSTOCK,a.DefaultUseCount,a.ship_id";
            sSql += " from T_workinfo_useSpare a inner join T_SPARE b on b.SPARE_ID=a.SpareId ";
            sSql += "\rwhere upper(a.WorkInfoId)='";
            sSql += workInfo.WORKINFOID.ToUpper();
            sSql += "' and upper(a.ship_id)='" + workInfo.SHIP_ID + "'";

            dbAccess.GetDataTable(sSql, out dtb, out err);
            return dtb;
        }

        public DataTable GetSpareInfoByCompTypeId(string typeId)
        {
            string sSql;
            string err;
            DataTable dtb;
            sSql = "select  b.SPARE_ID,b.SPARE_NAME,b.SPARE_ENAME,b.PICNUMBER,b.PARTNUMBER,";
            sSql += "b.SPARESTUFF,b.ATTACHCOMP,b.ATTACHTYPE,b.CREATOR ,b.UNIT_NAME,b.REMARK,";
            sSql += "b.ISSPECIALSP,b.ALERTSTOCK";
            sSql += "\rfrom T_COMPONENTTYPE_SPARE a inner join T_SPARE b on b.SPARE_ID=a.SPARE_ID ";
            sSql += "\rwhere upper(a.COMPONENT_TYPE_ID)='";
            sSql += typeId.ToUpper();
            sSql += "' ";

            dbAccess.GetDataTable(sSql, out dtb, out err);
            return dtb;
        }

        public bool InsertIntoWorkinfoSpares(WorkInfo workinfo, SpareInfo spareInfo, int usingCount, out string err)
        {
            List<string> lstSql = new List<string>();
            err = "";
            string delSql = "delete from T_workinfo_useSpare where WorkInfoId='"
                + workinfo.GetId() + "'  and ship_id ='" + workinfo.SHIP_ID + "' and SpareId = '" + spareInfo.GetId() + "'";
            lstSql.Add(delSql);

            string insertSql = "insert into T_workinfo_useSpare(WorkinfoUsespareId,WorkInfoId,SpareId,DefaultUseCount,ship_id) values('";
            insertSql += Guid.NewGuid().ToString();
            insertSql += "','";
            insertSql += workinfo.GetId();
            insertSql += "','";
            insertSql += spareInfo.GetId();
            insertSql += "',";
            insertSql += usingCount;
            insertSql += ",'";
            insertSql += workinfo.SHIP_ID + "'";
            insertSql += ") ";
            lstSql.Add(insertSql);
            return dbAccess.ExecSql(lstSql, out err);
        }

        #endregion

        #region 工作信息包含关系维护的相关操作

        /// <summary>
        /// 获取已经绑定的工作.
        /// </summary>
        internal DataTable getBindWork(Maintenance.DataObject.WorkInfo workInfo)
        {
            sql = "select t1.*,t2.needremind,t3.headship_name worker, t4.headship_name manager from t_workInfo t1 inner join ";
            sql += " (select insteadedworkinfoid,needremind from t_workinfoinsteadrelation where upper(MainWorkInfoID)='" + workInfo.GetId().ToUpper() + "') t2 ";
            sql += " on t1.workinfoid=t2.insteadedworkinfoid ";
            sql += "  inner join t_base_headship t3 on t1.principalpost=t3.ship_headship_id ";
            sql += " inner join t_base_headship t4 on t1.confirmpost=t4.ship_headship_id ";
            sql += " where t1.workInfoState=1 ";
            DataTable dtb;
            string err;
            dbAccess.GetDataTable(sql, out dtb, out err);
            return dtb;
        }
        /// <summary>
        /// 获取可以绑定的工作列表.
        /// </summary>
        internal DataTable getLeftWork(Maintenance.DataObject.WorkInfo workInfo)
        {
            sql = "select t1.*,t3.headship_name worker, t4.headship_name manager from ";
            sql += "  (select *,0 needremind from t_workInfo where upper(t_workInfo.SHIP_ID)='" + workInfo.SHIP_ID.ToUpper() + "' and workinfoid not in ";
            sql += "  (select insteadedworkinfoid from t_workinfoinsteadrelation  where upper(MainWorkInfoID)='" + workInfo.GetId().ToUpper() + "') and upper(ship_id)='" + workInfo.SHIP_ID.ToUpper() + "') t1 ";
            sql += " inner join t_base_headship t3 on t1.principalpost=t3.ship_headship_id ";
            sql += " inner join t_base_headship t4 on t1.confirmpost=t4.ship_headship_id ";
            sql += " where t1.workInfoState=1 and t1.ischeckproject =0 and upper(t1.workinfoid) !='" + workInfo.GetId().ToUpper()
                + "' and t1.principalpost = '" + (string.IsNullOrEmpty(workInfo.PRINCIPALPOST) ? "" : workInfo.PRINCIPALPOST) + "'"
                + " and t1.confirmpost = '" + (string.IsNullOrEmpty(workInfo.CONFIRMPOST) ? "" : workInfo.CONFIRMPOST) + "'";
            DataTable dtb;
            string err;
            dbAccess.GetDataTable(sql, out dtb, out err);
            return dtb;
        }

        /// <summary>
        /// 删除数据表T_WorkInfoInsteadRelation中的MainWorkInfoID的所有记录.
        /// </summary>
        /// <param name="unit">要删除的T_WorkInfoInsteadRelation.workinfoinsteadID主键</param>
        public bool deleteWorkInfoInsteadRelationByMainWorkInfoID(string MainWorkInfoID, out string err)
        {
            sql = "delete from T_WorkInfoInsteadRelation where "
                + " T_WorkInfoInsteadRelation.MainWorkInfoID='" + MainWorkInfoID + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_WorkInfoInsteadRelation中的MainWorkInfoID的所有记录.
        /// </summary>
        /// <param name="unit">要删除的T_WorkInfoInsteadRelation.workinfoinsteadID主键</param>
        public bool insertWorkInfoInsteadRelation(string MainWorkInfoID, string insteadedWorkinfoId, bool needRemind,
            string shipid, out string err)
        {
            sql = "insert [T_WorkInfoInsteadRelation] ([workinfoinsteadID],[MainWorkInfoID],[insteadedWorkinfoId]"
                 + ",[needRemind],[SHIP_ID]) VALUES( newid(),'" + MainWorkInfoID + "','" + insteadedWorkinfoId + "',"
                 + (needRemind ? "1" : "0") + ",'" + shipid + "')";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 操作绑定的工作报告部分的代码
        /// <summary>
        /// 获取剩下的未绑定的工作报告模板.
        /// </summary>
        /// <param name="workInfo">当前的workinfo</param>
        /// <returns></returns>
        public DataTable getMeasureReport(bool binded, WorkInfo workInfo)
        {
            sql = "select * from T_Measure_Report_Type where ship_id='" + workInfo.SHIP_ID + "' and measure_report_type_id " + (binded ? "in" : "not in");
            sql += " (select workReportId from t_workinfo_measurereport where workinfoid='" + workInfo.GetId() + "')";
            DataTable dtb;
            string err;
            dbAccess.GetDataTable(sql, out dtb, out err);
            return dtb;
        }

        /// <summary>
        ///  取得指定的工作信息的工作报告信息.
        /// </summary>
        /// <param name="workInfoId">当前工单所对应的工作信息Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetWorkInfoMeasureReport(string workInfoId)
        {
            //变量定义部分.
            DataTable dtb;//定义一个DataTable对象.
            string err = "";     //错误信息返回参数.
            string sSql = "";               //查询数据所需的SQL语句.

            //Select语句加工部分.
            sSql += "select ";
            sSql += "workinfoid,";
            sSql += "measure_report_type_name,";
            sSql += "workinfoname,";
            sSql += "workinfodetail,";
            sSql += "file_id ";
            sSql += "from v_workinfo ";
            sSql += "where workinfoid = '" + workInfoId + "' and isnull( measure_report_type_name,'') <> ''";
            dbAccess.GetDataTable(sSql, out dtb, out err);
            return dtb;
        }

        public bool deleteBindedMeasureReportByWorkInfo(Maintenance.DataObject.WorkInfo workInfo, out string err)
        {
            sql = "delete from t_workinfo_measurereport where workinfoid='" + workInfo.WORKINFOID + "' and upper(ship_id)='" + workInfo.SHIP_ID.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }

        public bool insertWorkInfoMeasureReport(string workInfoID, string measureReportId, string shipid, out string err)
        {
            sql = "insert [t_workinfo_measurereport] (WorkinfoMeasurereportId, WorkInfoId,WorkReportId,ship_id)"
                + " VALUES( newid(),'" + workInfoID + "','" + measureReportId + "', '" + shipid + "')";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion
    }

}
