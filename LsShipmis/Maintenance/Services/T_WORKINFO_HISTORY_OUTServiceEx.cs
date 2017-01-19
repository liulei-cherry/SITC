using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Maintenance.Services
{
    public partial class T_WORKINFO_HISTORY_OUTService
    {
        /// <summary>
        /// 根据船舶和年度,得到  T_WORKINFO_HISTORY_OUT 数据信息.
        /// </summary>
        public bool GetWorkinfoHistory(string SHIP_ID, DateTime ANNUAL, string REPROT_TYPE, out DataTable dt, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT  ");
            sb.AppendLine("who.WHID");
            sb.AppendLine(",who.SHIP_ID");
            sb.AppendLine(",who.ANNUAL");
            sb.AppendLine(",who.WORKID");
            sb.AppendLine(",who.REPROT_TYPE");
            sb.AppendLine(",who.ORDERNUM_SHOW");
            sb.AppendLine(",who.CLASS1");
            sb.AppendLine(",who.CLASS2");
            sb.AppendLine(",who.MONTHS_CHECK");
            sb.AppendLine(",who.EX1");
            sb.AppendLine(",who.EX2");
            sb.AppendLine(",who.EX3");
            sb.AppendLine(",who.EX4");
            sb.AppendLine(",who.EX5");
            sb.AppendLine(",who.ITEMTYPE");
            sb.AppendLine(",who.EXCEL_ORDERNUM");
            sb.AppendLine(",case when t1.WorkInfoID is not null then 0 else 1 end as sel");
            sb.AppendLine(",t1.WorkInfoID");
            sb.AppendLine(",t1.WorkInfoName");
            sb.AppendLine(",t2.headship_name worker");
            sb.AppendLine(",t1.RefObjID");
            sb.AppendLine(",t1.ship_id");
            sb.AppendLine(",case when t1.CircleOrTiming=1 then '定期' ");
            sb.AppendLine("     when t1.CircleOrTiming=2 then '定时' ");
            sb.AppendLine("     when t1.CircleOrTiming=3 then '定期/定时' ");
            sb.AppendLine("     when t1.CircleOrTiming=4 then '非周期' end CircleOrTiming");
            sb.AppendLine(",case when t1.WORKINFOSTATE=0 then '停止' ");
            sb.AppendLine(" when t1.WORKINFOSTATE=1 then '正常' end WORKINFOSTATE ");
            sb.AppendLine(",t4.COMP_CHINESE_NAME");
            sb.AppendLine(",WORKINFOCODE");
            sb.AppendLine("FROM T_WORKINFO_HISTORY_OUT who ");
            sb.AppendLine(" left join T_WorkInfo t1 on t1.WorkInfoID = who.WORKID");
            sb.AppendLine(" left join t_base_headship t2 on t1.principalpost=t2.ship_headship_id");
            sb.AppendLine(" left join t_base_headship t3 on t1.CONFIRMPOST=t3.ship_headship_id");
            sb.AppendLine(" left join t_component_unit t4 on t1.RefObjID = t4.COMPONENT_UNIT_ID");
            sb.AppendLine("where 1=1 ");
            sb.AppendLine("and who.ship_id='" + SHIP_ID + "'");
            sb.AppendLine("and datediff(year,who.ANNUAL,'" + ANNUAL.ToString("yyyy-MM-dd") + "')=0");
            sb.AppendLine("and who.ITEMTYPE='1'");
            if (!string.IsNullOrEmpty(REPROT_TYPE))
                sb.AppendLine("and who.REPROT_TYPE='" + REPROT_TYPE + "'");
            sb.AppendLine("order by who.EXCEL_ORDERNUM");
            return dbAccess.GetDataTable(sb.ToString(), out dt, out err);

        }

        /// <summary>
        /// 得到需要生成工单的  T_WORKINFO_HISTORY_OUT和T_WORKINFO 数据信息.
        /// </summary>
        public bool GetNeedCreateWorkorder(string SHIP_ID, DateTime ANNUAL, out DataTable dt, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT  ");
            sb.AppendLine("who.WHID");
            sb.AppendLine(",who.SHIP_ID");
            sb.AppendLine(",who.ANNUAL");
            sb.AppendLine(",who.WORKID");
            sb.AppendLine(",who.REPROT_TYPE");
            sb.AppendLine(",who.ORDERNUM_SHOW");
            sb.AppendLine(",who.CLASS1");
            sb.AppendLine(",who.CLASS2");
            sb.AppendLine(",who.MONTHS_CHECK");
            sb.AppendLine(",who.EX1");
            sb.AppendLine(",who.EX2");
            sb.AppendLine(",who.EX3");
            sb.AppendLine(",who.EX4");
            sb.AppendLine(",who.EX5");
            sb.AppendLine(",who.ITEMTYPE");
            sb.AppendLine(",who.EXCEL_ORDERNUM");
            sb.AppendLine(",case when t1.WorkInfoID is not null then 0 else 1 end as sel");
            sb.AppendLine(",t1.WorkInfoID");
            sb.AppendLine(",t1.WorkInfoName");
            sb.AppendLine(",t2.headship_name worker");
            sb.AppendLine(",t1.RefObjID");
            sb.AppendLine(",t1.ship_id");
            sb.AppendLine(",case when t1.CircleOrTiming=1 then '定期' ");
            sb.AppendLine("     when t1.CircleOrTiming=2 then '定时' ");
            sb.AppendLine("     when t1.CircleOrTiming=3 then '定期/定时' ");
            sb.AppendLine("     when t1.CircleOrTiming=4 then '非周期' end CircleOrTiming");
            sb.AppendLine(",case when t1.WORKINFOSTATE=0 then '停止' ");
            sb.AppendLine(" when t1.WORKINFOSTATE=1 then '正常' end WORKINFOSTATE ");
            sb.AppendLine(",t4.COMP_CHINESE_NAME");
            sb.AppendLine(",WORKINFOCODE");
            sb.AppendLine("FROM T_WORKINFO_HISTORY_OUT who ");
            sb.AppendLine(" inner join T_WorkInfo t1 on t1.WorkInfoID = who.WORKID");
            sb.AppendLine(" left join t_base_headship t2 on t1.principalpost=t2.ship_headship_id");
            sb.AppendLine(" left join t_base_headship t3 on t1.CONFIRMPOST=t3.ship_headship_id");
            sb.AppendLine(" left join t_component_unit t4 on t1.RefObjID = t4.COMPONENT_UNIT_ID");
            sb.AppendLine("where 1=1 ");
            sb.AppendLine("and who.ship_id='" + SHIP_ID + "'");
            sb.AppendLine("and datediff(year,who.ANNUAL,'" + ANNUAL.ToString("yyyy-MM-dd") + "')=0");
            sb.AppendLine("and who.ITEMTYPE='1'");
            sb.AppendLine("and t1.CircleOrTiming=1");
            sb.AppendLine("and MONTHS_CHECK is not null");
            sb.AppendLine("and len(MONTHS_CHECK)>0");
            sb.AppendLine("order by who.EXCEL_ORDERNUM");
            return dbAccess.GetDataTable(sb.ToString(), out dt, out err);
        }
        /// <summary>
        /// 得到现有的年度.
        /// </summary>
        public bool GetAnnualInfo(out DataTable dt, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select distinct");
            sb.AppendLine(" CONVERT ( varchar(4) ,ANNUAL, 121 ) as annual");
            sb.AppendLine("  from T_WORKINFO_HISTORY_OUT ");
            sb.AppendLine("  order by annual ");
            return dbAccess.GetDataTable(sb.ToString(), out dt, out err);
        }
        /// <summary>
        /// 得到内部排序号最大值.
        /// </summary>
        public bool GetMaxExcelOrdernum(string SHIP_ID, DateTime ANNUAL, out int maxExcelOrderNum, out string err)
        {
            maxExcelOrderNum = 0;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select max(EXCEL_ORDERNUM) maxEXCEL_ORDERNUM");
            sb.AppendLine("  from T_WORKINFO_HISTORY_OUT ");
            sb.AppendLine("where ship_id='" + SHIP_ID + "'");
            sb.AppendLine("and datediff(year,ANNUAL,'" + ANNUAL.ToString("yyyy-MM-dd") + "')=0");
            string sContent = "";
            if (!dbAccess.GetString(sb.ToString(), out sContent, out err))
                return false;
            if (!string.IsNullOrEmpty(sContent))
                maxExcelOrderNum = Convert.ToInt32(sContent);
            return true;
        }
        /// <summary>
        /// 得到序号-内部排序号列表.
        /// </summary>
        public bool GetOrderExcelNum(string SHIP_ID, DateTime ANNUAL, out DataTable dt, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select (ORDERNUM_SHOW+' --- '+convert(varchar(50),EXCEL_ORDERNUM)) as ORDER_EXCEL_NUM");
            sb.AppendLine(",EXCEL_ORDERNUM");
            sb.AppendLine("  from T_WORKINFO_HISTORY_OUT ");
            sb.AppendLine("where ship_id='" + SHIP_ID + "'");
            sb.AppendLine("and datediff(year,ANNUAL,'" + ANNUAL.ToString("yyyy-MM-dd") + "')=0");
            sb.AppendLine("order by EXCEL_ORDERNUM");
            return dbAccess.GetDataTable(sb.ToString(), out dt, out err);
        }
        /// <summary>
        /// 得到某个序号是否存在.
        /// </summary>
        public bool GetExcelOrderNumIsExist(string SHIP_ID, DateTime ANNUAL, int EXCEL_ORDERNUM, out bool isExist, out string err)
        {
            DataTable dt;
            isExist = false;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("EXCEL_ORDERNUM");
            sb.AppendLine("  from T_WORKINFO_HISTORY_OUT ");
            sb.AppendLine("where ship_id='" + SHIP_ID + "'");
            sb.AppendLine("and datediff(year,ANNUAL,'" + ANNUAL.ToString("yyyy-MM-dd") + "')=0");
            sb.AppendLine("and EXCEL_ORDERNUM=" + EXCEL_ORDERNUM);
            sb.AppendLine("order by EXCEL_ORDERNUM");
            if (!dbAccess.GetDataTable(sb.ToString(), out dt, out err))
                return false;
            isExist = (dt.Rows.Count > 0);
            return true;
        }
        /// <summary>
        /// 年度复制.
        /// </summary>
        public bool CopyAnnualInfo(string originSHIP_ID, DateTime originANNUAL, string targetSHIP_ID, DateTime targetANNUAL, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("insert into T_WORKINFO_HISTORY_OUT");
            sb.AppendLine("(");
            sb.AppendLine("who.WHID");
            sb.AppendLine(",who.SHIP_ID");
            sb.AppendLine(",who.ANNUAL");
            sb.AppendLine(",who.REPROT_TYPE");
            sb.AppendLine(",who.WORKID");
            sb.AppendLine(",who.ORDERNUM_SHOW");
            sb.AppendLine(",who.CLASS1");
            sb.AppendLine(",who.CLASS2");
            sb.AppendLine(",who.MONTHS_CHECK");
            sb.AppendLine(",who.EX1");
            sb.AppendLine(",who.EX2");
            sb.AppendLine(",who.EX3");
            sb.AppendLine(",who.EX4");
            sb.AppendLine(",who.EX5");
            sb.AppendLine(",who.ITEMTYPE");
            sb.AppendLine(",who.EXCEL_ORDERNUM");
            sb.AppendLine(")");
            sb.AppendLine(" select ");
            sb.AppendLine("newid()");
            sb.AppendLine(",'" + targetSHIP_ID + "'");
            sb.AppendLine(",'" + targetANNUAL.ToString("yyyy-MM-dd") + "'");
            sb.AppendLine(",who.REPROT_TYPE");
            sb.AppendLine(",who.WORKID");
            sb.AppendLine(",who.ORDERNUM_SHOW");
            sb.AppendLine(",who.CLASS1");
            sb.AppendLine(",who.CLASS2");
            sb.AppendLine(",who.MONTHS_CHECK");
            sb.AppendLine(",who.EX1");
            sb.AppendLine(",who.EX2");
            sb.AppendLine(",who.EX3");
            sb.AppendLine(",who.EX4");
            sb.AppendLine(",who.EX5");
            sb.AppendLine(",who.ITEMTYPE");
            sb.AppendLine(",who.EXCEL_ORDERNUM");
            sb.AppendLine("from T_WORKINFO_HISTORY_OUT who");
            sb.AppendLine("where 1=1 ");
            sb.AppendLine("and who.ship_id='" + originSHIP_ID + "'");
            sb.AppendLine("and datediff(year,who.ANNUAL,'" + originANNUAL.ToString("yyyy-MM-dd") + "')=0");
            return dbAccess.ExecSql(sb.ToString(), out err);
        }
        /// <summary>
        /// 重排内部排序号.
        /// </summary>
        public bool ResetExcelOrdernum(string SHIP_ID, DateTime ANNUAL, string WHID, int? oldnum, int newnum, out string err)
        {
            err = "";
            if (oldnum == newnum) return true;
            bool isExist = false;
            if (!this.GetExcelOrderNumIsExist(SHIP_ID, ANNUAL, newnum, out isExist, out err))
                return false;
            if (!isExist) return true;
            StringBuilder sb = new StringBuilder();
            if (oldnum == null)
            {
                sb.AppendLine("update T_WORKINFO_HISTORY_OUT set EXCEL_ORDERNUM=(EXCEL_ORDERNUM+1)");
                sb.AppendLine("where EXCEL_ORDERNUM>=" + newnum);
            }
            else if (oldnum > newnum)
            {
                sb.AppendLine("update T_WORKINFO_HISTORY_OUT set EXCEL_ORDERNUM=(EXCEL_ORDERNUM+1)");
                sb.AppendLine("where EXCEL_ORDERNUM>=" + newnum + " and EXCEL_ORDERNUM<" + oldnum);
            }
            else if (oldnum < newnum)
            {
                sb.AppendLine("update T_WORKINFO_HISTORY_OUT set EXCEL_ORDERNUM=(EXCEL_ORDERNUM-1)");
                sb.AppendLine("where EXCEL_ORDERNUM>" + oldnum + " and EXCEL_ORDERNUM<=" + newnum);
            }
            sb.AppendLine("and WHID<>'" + WHID + "'");
            sb.AppendLine("and ship_id='" + SHIP_ID + "'");
            sb.AppendLine("and datediff(year,ANNUAL,'" + ANNUAL.ToString("yyyy-MM-dd") + "')=0");
            return dbAccess.ExecSql(sb.ToString(), out err);
        }
        /// <summary>
        /// 得到 某船  T_WORKINFO_HISTORY_OUT 所有数据信息.
        /// </summary>
        /// <returns>T_WORKINFO_HISTORY_OUT DataTable</returns>
        public DataTable getInfoByship(string ship_id, int report_type, DateTime DT, out string err)
        {
            sql = "select	"
                + "WHID"
                + ",SHIP_ID"
                + ",ANNUAL"
                + ",WORKID"
                + ",ORDERNUM_SHOW"
                + ",CLASS1"
                + ",CLASS2"
                + ",MONTHS_CHECK"
                + ",EX1"
                + ",EX2"
                + ",EX3"
                + ",EX4"
                + ",EX5"
                + ",ITEMTYPE"
                + ",EXCEL_ORDERNUM"
                + "  from T_WORKINFO_HISTORY_OUT "
                + " where SHIP_ID = '" + ship_id.ToUpper() + "'"
                + " AND REPROT_TYPE = " + report_type
                + " AND convert(varchar(7),ANNUAL,102)='" + DT.ToString("yyyy.MM") + "'"
                + " ORDER BY EXCEL_ORDERNUM";
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
        /// 获取负责人岗位描述.
        /// </summary>
        /// <param name="workinfoid"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool getHEADSHIP_NAME(string workinfoid, out string value, out string err)
        {
            value = "";
            err = "";
            sql = @"select HEADSHIP_NAME 
                     from dbo.T_BASE_HEADSHIP a 
                     inner join T_WORKINFO  b 
                     on a.SHIP_HEADSHIP_ID = b.PRINCIPALPOST
                     where b.WORKINFOID = '" + workinfoid + "'";

            return dbAccess.GetString(sql, out value, out err);
        }
        /// <summary>
        /// 得到某个工作信息的输出历史信息.
        /// </summary>
        public bool GetInfoByWorkID(string workid, out DataTable dt, out string err)
        {
            sql = "select	"
                + "WHID"
                + ",SHIP_ID"
                + ",ANNUAL"
                + ",REPROT_TYPE"
                + ",WORKID"
                + ",ORDERNUM_SHOW"
                + ",CLASS1"
                + ",CLASS2"
                + ",MONTHS_CHECK"
                + ",EX1"
                + ",EX2"
                + ",EX3"
                + ",EX4"
                + ",EX5"
                + ",ITEMTYPE"
                + ",EXCEL_ORDERNUM"
                + "  from T_WORKINFO_HISTORY_OUT "
                + "where workid='" + workid + "'";
            return dbAccess.GetDataTable(sql, out dt, out err);
        }
    }
}
