using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Maintenance.Services;
using Maintenance.DataObject;
using CommonOperation.Interfaces;

namespace Maintenance.Services
{ 
    /// <summary>
    ///  
    /// </summary>
    public class WorkInfoPlan
    {
        string err;
        IDBAccess dbAccess = CommonOperation.Functions.InterfaceInstantiation.NewADbAccess();
        IDBOperation dbOperation = CommonOperation.Functions.InterfaceInstantiation.NewADBOperation();
        
        /// <summary>
        /// 得到工作计划列表.
        /// </summary>
        /// <param name="shipid"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="jbOrlj">1甲板,2轮机</param>
        /// <returns></returns>
        public DataTable GetPlanListOfTheWork(string shipid, DateTime startTime, DateTime endTime, bool isDeck)
        {
            string gwList;
            gwList = getbmList(isDeck);            
            string sql = "select  (ta.WORKINFONAME + case when ta.WORKINFONAME like '%'+ta.WORKINFODETAIL then '' else ta.WORKINFODETAIL end )as WORKINFONAME  ," + "\n" +
                       "  tt.PRINCIPALPOST,times from " + "\n" +
                       "(select workinfoid,WORKORDERNAME,PRINCIPALPOST, floor(datediff(day,PLANEXEDATE, " + dbOperation.DbToDate(endTime)
                           + " )/CIRCLEPERIOD)  yt,times + floor(datediff(day,PLANEXEDATE, " + dbOperation.DbToDate(endTime) + " )/CIRCLEPERIOD) " + "\n" +
                       "- case when PLANEXEDATE < " + dbOperation.DbToDate(startTime) + " then floor(datediff(day,PLANEXEDATE,"
                           + dbOperation.DbToDate(startTime) + " )/CIRCLEPERIOD) else 0 end times" + "\n" +
                       "from (select t2.workinfoid,t2.WORKORDERNAME,t2.PRINCIPALPOST,isnull(times,0) times,PLANEXEDATE,CIRCLEPERIOD from " + "\n" +
                       "( select workinfoid,count(1) times from V_WORKORDER_INFO" + "\n" +
                       "where PLANEXEDATE < " + dbOperation.DbToDate(endTime) + " and PLANEXEDATE > " + dbOperation.DbToDate(startTime) + "\n" +
                       " and PRINCIPALPOST in (" + gwList + ")group by workinfoid) t1 right join  " + "\n" +
                       "(select workinfoid,max(WORKORDERNAME)WORKORDERNAME,max(PRINCIPALPOST)PRINCIPALPOST, max(PLANEXEDATE) PLANEXEDATE,"
                           + "min( case when CIRCLEPERIOD <= 0 then 100000 else CIRCLEPERIOD end)  CIRCLEPERIOD" + "\n" +
                       "from V_WORKORDER_INFO where PLANEXEDATE < " + dbOperation.DbToDate(endTime) + "\n" +
                       " and PRINCIPALPOST in (" + gwList + ")group by workinfoid) t2 on t1.workinfoid = t2.workinfoid)t)tt" + "\n" +
                       " inner join dbo.T_WORKINFO ta on tt.workInfoId = ta.workInfoId " + "\n" +
                       " inner join dbo.T_BASE_HEADSHIP th on tt.PRINCIPALPOST = th.SHIP_HEADSHIP_ID" + "\n" +
                       " where  tt.times >0 and ta.ship_id = '" + shipid + "'\n" +
                       "order by th.HEADSHIP_NAME,WORKINFONAME";
            DataTable dtb;
            dbAccess.GetDataTable(sql, out dtb, out err);
            return dtb;
        }
        private string getbmList(bool isDeck)
        {
            string sql = "select t1.SHIP_HEADSHIP_ID from T_BASE_HEADSHIP t1 inner join t_department t2 on t1.departmentid = t2.departmentid"
                + "\rwhere DEPARTNAME = '" + (isDeck ? "甲板部" : "轮机部") + "'";
            string returnString = "";
            DataTable dt;
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    returnString += (i == 0 ? "" : ",") + "'" + dt.Rows[i][0] + "'";
                }
            }
            return returnString;
        }

    }
}
