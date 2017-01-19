/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：CMSCheckService.cs
 * 创 建 人：徐正本
 * 创建时间：2011/6/22
 * 标    题：数据操作类
 * 功能描述：T_CMS_CHECK数据操作类
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
using CMSManage.DataObject;

namespace CMSManage.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_CMS_CHECKService.cs
    /// </summary>
    public partial class CMSCheckService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static CMSCheckService instance = new CMSCheckService();
        public static CMSCheckService Instance
        {
            get
            {
                if (null == instance)
                {
                    CMSCheckService.instance = new CMSCheckService();
                }
                return CMSCheckService.instance;
            }
        }
        private CMSCheckService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">CMSCheck对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(CMSCheck unit, out string err)
        {
            if (unit.CMS_CHECK_ID != null && unit.CMS_CHECK_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_CMS_CHECK] SET "
                    + " [CMS_CHECK_ID] = " + (string.IsNullOrEmpty(unit.CMS_CHECK_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.CMS_CHECK_ID) + "'")
                    + " , [CHECK_TITLE] = " + (unit.CHECK_TITLE == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.CHECK_TITLE) + "'")
                    + " , [CMS_CODE] = " + (unit.CMS_CODE == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.CMS_CODE) + "'")
                    + " , [WORKORDER_ID] = " + (string.IsNullOrEmpty(unit.WORKORDER_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.WORKORDER_ID) + "'")
                    + " , [CHECK_DETAIL] = " + (unit.CHECK_DETAIL == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.CHECK_DETAIL) + "'")
                    + " , [PLAN_DATE] = " + dbOperation.DbToDate(unit.PLAN_DATE)
                    + " , [CHECK_STATE] = " + unit.CHECK_STATE.ToString()
                    + " , [CHECK_DEPART] = " + unit.CHECK_DEPART.ToString()
                    + " , [CHECK_PERSON] = " + (unit.CHECK_PERSON == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.CHECK_PERSON) + "'")
                    + " , [CHECK_DATE] = " + dbOperation.DbToDate(unit.CHECK_DATE)
                    + " , [CHECK_LOG_ID] = " + (string.IsNullOrEmpty(unit.CHECK_LOG_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.CHECK_LOG_ID) + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIP_ID) + "'")
                    + " , [CHECKENGLISHNAME] = " + (unit.CHECKENGLISHNAME == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.CHECKENGLISHNAME) + "'")
                    + " , [SortNo] = " + unit.SortNo.ToString()
                    + "\rwhere CMS_CHECK_ID = '" + dbOperation.ReplaceSqlKeyStr(unit.CMS_CHECK_ID) + "'";
            }
            else
            {
                unit.CMS_CHECK_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_CMS_CHECK] ("
                    + "[CMS_CHECK_ID],"
                    + "[CHECK_TITLE],"
                    + "[CMS_CODE],"
                    + "[WORKORDER_ID],"
                    + "[CHECK_DETAIL],"
                    + "[PLAN_DATE],"
                    + "[CHECK_STATE],"
                    + "[CHECK_DEPART],"
                    + "[CHECK_PERSON],"
                    + "[CHECK_DATE],"
                    + "[CHECK_LOG_ID],"
                    + "[SHIP_ID],"
                    + "[CHECKENGLISHNAME],"
                    + "[SortNo]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.CMS_CHECK_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.CMS_CHECK_ID) + "'")
                    + " , " + (unit.CHECK_TITLE == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.CHECK_TITLE) + "'")
                    + " , " + (unit.CMS_CODE == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.CMS_CODE) + "'")
                    + " , " + (string.IsNullOrEmpty(unit.WORKORDER_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.WORKORDER_ID) + "'")
                    + " , " + (unit.CHECK_DETAIL == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.CHECK_DETAIL) + "'")
                    + " ," + dbOperation.DbToDate(unit.PLAN_DATE)
                    + " ," + unit.CHECK_STATE.ToString()
                    + " ," + unit.CHECK_DEPART.ToString()
                    + " , " + (unit.CHECK_PERSON == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.CHECK_PERSON) + "'")
                    + " ," + dbOperation.DbToDate(unit.CHECK_DATE)
                    + " , " + (string.IsNullOrEmpty(unit.CHECK_LOG_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.CHECK_LOG_ID) + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIP_ID) + "'")
                    + " , " + (unit.CHECKENGLISHNAME == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.CHECKENGLISHNAME) + "'")
                    + " ," + unit.SortNo.ToString()
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_CMS_CHECK中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_CMS_CHECK对象</param>
        internal bool deleteUnit(CMSCheck unit, out string err)
        {
            return deleteUnit(unit.CMS_CHECK_ID, out err);
        }

        /// <summary>
        /// 删除数据表T_CMS_CHECK中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_CMS_CHECK.cMS_CHECK_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_CMS_CHECK where CMS_CHECK_ID='" + dbOperation.ReplaceSqlKeyStr(unitid) + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_CMS_CHECK 所有数据信息.
        /// </summary>
        /// <returns>T_CMS_CHECK DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "CMS_CHECK_ID"
                + ",CHECK_TITLE"
                + ",CMS_CODE"
                + ",WORKORDER_ID"
                + ",CHECK_DETAIL"
                + ",PLAN_DATE"
                + ",CHECK_STATE"
                + ",CHECK_DEPART"
                + ",CHECK_PERSON"
                + ",CHECK_DATE"
                + ",CHECK_LOG_ID"
                + ",SHIP_ID"
                + ",CHECKENGLISHNAME"
                + ",SortNo"
                + "\rfrom T_CMS_CHECK ";
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
        /// 根据一个主键ID,得到 T_CMS_CHECK 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>CMSCheck DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "CMS_CHECK_ID"
                + ",CHECK_TITLE"
                + ",CMS_CODE"
                + ",WORKORDER_ID"
                + ",CHECK_DETAIL"
                + ",PLAN_DATE"
                + ",CHECK_STATE"
                + ",CHECK_DEPART"
                + ",CHECK_PERSON"
                + ",CHECK_DATE"
                + ",CHECK_LOG_ID"
                + ",SHIP_ID"
                + ",CHECKENGLISHNAME"
                + ",SortNo"
                + "\rfrom T_CMS_CHECK "
                + "\rwhere CMS_CHECK_ID='" + dbOperation.ReplaceSqlKeyStr(Id) + "'";
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
        /// 根据cmscheck 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>cmscheck 数据实体</returns>
        public CMSCheck getObject(DataRow dr)
        {
            CMSCheck unit = new CMSCheck();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造CMSCheck类对象!";
                return unit;
            }
            if (DBNull.Value != dr["CMS_CHECK_ID"])
                unit.CMS_CHECK_ID = dr["CMS_CHECK_ID"].ToString();
            if (DBNull.Value != dr["CHECK_TITLE"])
                unit.CHECK_TITLE = dr["CHECK_TITLE"].ToString();
            if (DBNull.Value != dr["CMS_CODE"])
                unit.CMS_CODE = dr["CMS_CODE"].ToString();
            if (DBNull.Value != dr["WORKORDER_ID"])
                unit.WORKORDER_ID = dr["WORKORDER_ID"].ToString();
            if (DBNull.Value != dr["CHECK_DETAIL"])
                unit.CHECK_DETAIL = dr["CHECK_DETAIL"].ToString();
            if (DBNull.Value != dr["PLAN_DATE"])
                unit.PLAN_DATE = (DateTime)dr["PLAN_DATE"];
            if (DBNull.Value != dr["CHECK_STATE"])
                unit.CHECK_STATE = Convert.ToDecimal(dr["CHECK_STATE"]);
            if (DBNull.Value != dr["CHECK_DEPART"])
                unit.CHECK_DEPART = Convert.ToDecimal(dr["CHECK_DEPART"]);
            if (DBNull.Value != dr["CHECK_PERSON"])
                unit.CHECK_PERSON = dr["CHECK_PERSON"].ToString();
            if (DBNull.Value != dr["CHECK_DATE"])
                unit.CHECK_DATE = (DateTime)dr["CHECK_DATE"];
            if (DBNull.Value != dr["CHECK_LOG_ID"])
                unit.CHECK_LOG_ID = dr["CHECK_LOG_ID"].ToString();
            if (DBNull.Value != dr["SHIP_ID"])
                unit.SHIP_ID = dr["SHIP_ID"].ToString();
            if (DBNull.Value != dr["CHECKENGLISHNAME"])
                unit.CHECKENGLISHNAME = dr["CHECKENGLISHNAME"].ToString();
            if (DBNull.Value != dr["SortNo"])
                unit.SortNo = Convert.ToDecimal(dr["SortNo"]);

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个CMSCheck对象.
        /// </summary>
        /// <param name="cMS_CHECK_ID">cMS_CHECK_ID</param>
        /// <returns>CMSCheck对象</returns>
        public CMSCheck getObject(string Id, out string err)
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

        public DataTable SetNewItemOfOneLog(CMSCheckLog cmsCheckLog)
        {
            string err;
            List<string> sqls = new List<string>();
            //先删除已有的.
            sqls.Add("delete T_CMS_CHECK where CHECK_LOG_ID = '" + cmsCheckLog.GetId() + "'");
            //插入语法，根据模板插入所有条目.
            sql = "insert into T_CMS_CHECK(CMS_CHECK_ID"
                + ",CHECK_TITLE"
                + ",CMS_CODE"
                + ",CHECK_DETAIL"
                + ",PLAN_DATE"
                + ",CHECK_STATE"
                + ",CHECK_DEPART"
                + ",CHECK_LOG_ID"
                + ",SHIP_ID,CHECKENGLISHNAME,sortno)"
                + "\rselect newId(),t1.CHECKTITLE,t1.CMSCODE,t1.CHECKDETAIL," + dbOperation.DbToDate(cmsCheckLog.CHECK_DATE) + ","
                + "1,3 - isnull(t2.CHECK_DEPART,1) ,'" + cmsCheckLog.GetId() + "',t1.SHIP_ID,t1.CHECKENGLISHNAME,t1.sortno"
                + "\rfrom T_CMS_CONFIG t1 left join T_CMS_CHECK t2 on t1.CMSCODE = t2.CMS_CODE and t1.CHECKTITLE = t2.CHECK_TITLE"
                + "\rand t2.PLAN_DATE = (select max(plan_date) from T_CMS_CHECK t3 where t3.CMS_CODE = t2.CMS_CODE and t3.CHECK_TITLE = t2.CHECK_TITLE)";
            sqls.Add(sql);
            if (!dbAccess.ExecSql(sqls, out err)) return null;

            return GetAllItemOfOneLog(cmsCheckLog.GetId());
        }

        public DataTable GetAllItemOfOneLog(string logId)
        {
            return GetAllItemOfOneLog(logId, true, 0);
        }

        public DataTable GetAllItemOfOneLog(string logId, int state)
        {
            return GetAllItemOfOneLog(logId, true, state);
        }

        public DataTable GetAllItemOfOneLog(string logId, bool withSelfCheckProject, int state)
        {
            string err;
            sql = "update T_CMS_CHECK set WORKORDER_ID = null "
               +"\rwhere WORKORDER_ID not in (select WORKORDER_ID from V_WorkOrder )"
               +"\r and CHECK_LOG_ID='" + logId.Replace("'", "''") + "'";
            if (!dbAccess.ExecSql(sql, out err)) return null;
            sql = "select "
              + "t1.CMS_CHECK_ID,t1.sortno"
              + ",t1.CHECK_TITLE,t1.CHECKENGLISHNAME"
              + ",t1.CMS_CODE"
              + ",t1.WORKORDER_ID"
              + ",t1.PLAN_DATE"
              + ",t1.CHECK_STATE"
              + ",case t1.CHECK_STATE when 1 then 'plan' when 2 then 'complete' when 3 then 'flaw' else 'err' end CHECK_STATE_VIEW"
              + ",t1.CHECK_DEPART"
              + ",CASE t1.CHECK_DEPART WHEN 1 THEN '轮机长' ELSE '船级社' END CHECK_DEPART_NAME"
              + ",t1.CHECK_PERSON"
              + ",t1.CHECK_DATE"
              + ",t1.CHECK_LOG_ID"
              + ",t1.SHIP_ID,(select case count(1) when 0 then 'No' else 'Yes' end from t_cms_config t "
              + "\r    where t.SHIP_ID = t1.SHIP_ID and t.CMSCODE= t1.CMS_CODE and len(isnull(t.WORKINFOID,''))>0) BANDWORKINFO"
              + ",case when len(isnull(WORKORDER_ID,'')) > 0 then 'Yes' else 'No' end BANDWORKORDER"
              + ",isnull(RECTIFY_STATE,0) RECTIFY_STATE_Value"
              + ",case isnull(RECTIFY_STATE,0) when 1 then 'unrectified' when 2 then 'rectified' else '' end RECTIFY_STATE"
              + ",t1.CHECK_DETAIL"
              + "\rfrom T_CMS_CHECK t1 left join T_CMS_RECTIFY t2 on t1.CMS_CHECK_ID = t2.CMS_CHECK_ID"
              + "\rwhere upper(CHECK_LOG_ID)='" + logId.Replace("'", "''").ToUpper() + "'"
              + (!withSelfCheckProject ? "\r and CHECK_DEPART = 2" : "")
              + (state == 0 ? "" : " and CHECK_STATE = " + state.ToString())
              + "\rorder by sortno, CMS_CODE"; 
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

        public DataTable GetAllSelfCheckItemOfOneLog(string logId)
        {
            sql = "select "
              + "CMS_CHECK_ID"
              + ",CHECK_TITLE"
              + ",DATEADD (day , -1, PLAN_DATE) PLAN_DATE_ALERT "
              + ",PLAN_DATE"
              + ",CMS_CODE"
              + ",'轮机长'"
              + "\rfrom T_CMS_CHECK "
              + "\rwhere upper(CHECK_LOG_ID)='" + logId.Replace("'", "''").ToUpper() + "' and CHECK_DEPART = 1"
              + "\rorder by CMS_CODE";
            string err;
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

        public DataTable GetAllNotFinishedSelfCheckItemOfOneShip(string shipId)
        {
            DataTable dt;
            sql = "select	"
                + "t1.CMS_CHECK_ID,t1.sortno"
                + ",t2.CHECK_NAME"
                + ",t1.CHECK_TITLE,t1.CHECKENGLISHNAME"
                + ",t1.CMS_CODE"
                + ",t1.WORKORDER_ID"
                + ",case when len(isnull(t1.WORKORDER_ID,'')) > 0 then 'Yes' else 'No' end BANDWORKORDER"
                + ",t1.CHECK_DETAIL"
                + ",t1.PLAN_DATE"
                + ",t1.CHECK_PERSON"
                + ",t1.CHECK_DATE"
                + ",t1.CHECK_LOG_ID"
                + ",t1.SHIP_ID"
                + "\rfrom T_CMS_CHECK t1 inner join T_CMS_CHECKING_LOG t2 on t1.CHECK_LOG_ID = t2.CHECK_LOG_ID "
                + "\rwhere t1.ship_id = '" + shipId.Replace("'", "''") + "' and t1.CHECK_DEPART = 1 and t1.CHECK_STATE = 1"
                + "\rorder by t1.sortno, t2.CHECK_DATE ,t1.CMS_CODE";
            string err;
            if (dbAccess.GetDataTable(sql, out dt, out err))
                return dt;
            return null;
        }

        public bool FinishACMSSelfCheckingProject(string checkId, out string err)
        {
            sql = "update T_CMS_CHECK set CHECK_STATE =2,CHECK_PERSON = '" + CommonOperation.ConstParameter.UserName + "',"
                + "CHECK_DATE = getdate() where CMS_CHECK_ID = '" + checkId.Replace("'", "''") + "'";
            return dbAccess.ExecSql(sql, out err);
        }

        public bool FinishWholeCMSCheckingProject(CMSCheckLog checkLog, out string err)
        {
            List<string> sqls = new List<string>();
            sql = "update T_CMS_CHECK set CHECK_STATE =2,CHECK_PERSON = '" + checkLog.CHECK_PERSON + "',CHECK_DATE = " + dbOperation.DbToDate(checkLog.CHECK_DATE)
                + ",CHECK_DEPART = 2 \rwhere CHECK_LOG_ID = '" + checkLog.GetId() + "' and CHECK_STATE = 1";
            sqls.Add(sql);
            sql = "update T_CMS_CHECKING_LOG set CHECK_STATE = case isnull((select count(1) from T_CMS_CHECK where CHECK_LOG_ID = '"
                + checkLog.GetId() + "' and CHECK_STATE = 3),0) when 0 then 2 else 3 end "
                + "\rwhere CHECK_LOG_ID = '" + checkLog.GetId() + "'";
            sqls.Add(sql);
            return dbAccess.ExecSql(sqls, out err);
        }

        public bool CMSCheckTitleIsDuplicated(string checkTitle, string logId, string exceptId)
        {
            sql = "select count(1) from T_CMS_CHECK where CHECK_TITLE = '" + dbOperation.ReplaceSqlKeyStr(checkTitle) + "'"
            + "\rand CHECK_LOG_ID = '" + dbOperation.ReplaceSqlKeyStr(logId) + "'"
            + "\rand CMS_CHECK_ID <> '" + dbOperation.ReplaceSqlKeyStr(exceptId) + "'";
            return dbAccess.GetString(sql) != "0";
        }
        public bool CMSCheckCodeIsDuplicated(string checkCode, string logId, string exceptId)
        {
            sql = "select count(1) from T_CMS_CHECK where CMS_CODE = '" + dbOperation.ReplaceSqlKeyStr(checkCode) + "'"
             + "\rand CHECK_LOG_ID = '" + dbOperation.ReplaceSqlKeyStr(logId) + "'"
             + "\rand CMS_CHECK_ID <> '" + dbOperation.ReplaceSqlKeyStr(exceptId) + "'";
            return dbAccess.GetString(sql) != "0";
        }
    }
}
