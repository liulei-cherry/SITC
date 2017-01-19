/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：ReportCoolwaterServiceEx.cs
 * 创 建 人：黄家龙
 * 创建时间：2011/8/23
 * 标    题：数据操作类
 * 功能描述：T_REPORT_COOLWATER数据操作类
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
using CustomerTable.Haifeng.DataObject;
namespace CustomerTable.Haifeng.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_REPORT_COOLWATERService.cs
    /// </summary>
    public partial class ReportCoolwaterService
    {
        /// <summary>
        /// 获得 "年月度处理报表情况" 数据.
        /// </summary>
        public DataTable getInfoByYear(string ship_id, DateTime year, out string err)
        {
            sql = "SELECT [Report_CoolWater_Id]"
                 + " ,[SHIP_ID]"
                 + " ,[File_ID]"
                 + " ,[Medcine]"
                 + " ,[MainLinerConcentration]"
                 + " ,[MainLInerDosage]"
                 + " ,[MainPistonConcentration]"
                 + " ,[MainPistonDosage]"
                 + " ,[MainOilConcentration]"
                 + " ,[MainOilDosage]"
                 + " ,[SecondConcentration]"
                 + " ,[SecondDosage]"
                 + " ,CONVERT(varchar(7), ExperimentDealDate, 102) as ExperimentDealDate"
                 + " ,[ExperimentDealSign]"
                 + " ,[ExperimentDealSignDate]"
                 + " ,[ChiefSign]"
                 + " ,[ChiefSignData]";
            sql += " FROM T_REPORT_COOLWATER";
            sql += " WHERE upper(SHIP_Id)= '" + ship_id.ToUpper() + "'"
                + " and convert(varchar(7),ExperimentDealDate,102)='" + year.ToString("yyyy.MM") + "'";
            sql += " order by ExperimentDealDate ";

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
        /// 检查某处理日期信息是否已经存在.
        /// </summary>
        /// <param name="apply_id"></param>
        /// <returns></returns>
        public bool CheckSubDetail(string apply_id, string ship_id)
        {
            sql = "select count(1) "
                + "  from T_REPORT_COOLWATER T";
            sql += " where convert(varchar(10),T.ExperimentDealDate,102)= '" + apply_id + "'";
            sql += "  and  upper(SHIP_Id)= '" + ship_id.ToUpper() + "'";

            if (dbAccess.GetString(sql) == "0")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 获取当月条款信息.
        /// </summary>
        /// <param name="apply_id"></param>
        /// <returns></returns>
        public DataTable GetApplyDatas(string apply_id, string shipID)
        {
            string err;
            DataTable dtreturn;

            sql = "select CONVERT(varchar(10), ExperimentDealDate, 102) as ExperimentDealDate,"
                + "T.MainLinerConcentration,T.MainLInerDosage,T.MainPistonConcentration"
                + ",T.MainPistonDosage,T.MainOilConcentration,T.MainOilDosage,T.SecondConcentration"
                + ",T.SecondDosage"
                + " from T_REPORT_COOLWATER T ";
            sql += " WHERE  convert(varchar(7),ExperimentDealDate,102)= '" + apply_id + "'";
            sql += " AND upper(SHIP_Id)= '" + shipID.ToUpper() + "' ";
            sql += " order by ExperimentDealDate";

            if (!dbAccess.GetDataTable(sql, out dtreturn, out err))
            {
                throw new Exception("GetApplyDatas occur err:" + err);
            }
            return dtreturn;
        }

        /// <summary>
        /// 获取当月条款记录详细信息.
        /// </summary>
        /// <param name="apply_id"></param>
        /// <returns></returns>
        public ReportCoolwater GetMainDetail(string apply_id, string ship_id, out string err)
        {
            DataTable dtreturn;

            sql = "select * "
                + "  from T_REPORT_COOLWATER T";
            sql += " where convert(varchar(10),T.ExperimentDealDate,102)= '" + apply_id + "'";
            sql += "  and  upper(SHIP_Id)= '" + ship_id.ToUpper() + "'";
            sql += " order by T.ExperimentDealDate desc";

            if (!dbAccess.GetDataTable(sql, out dtreturn, out err))
            {
                getObject(null);
                throw new Exception("GetMainDetail occur err:" + err);
            }

            return getObject(dtreturn.Rows[0]);
        }

        public bool UpdateSomeRecord(string apply_id, string shipID, ReportCoolwater unit)
        {
            string sql2 = "";
            string err = "";
            List<string> lstSql = new List<string>();
            sql = "UPDATE T_REPORT_COOLWATER "
                + " SET "
                + " [File_ID] = " + (string.IsNullOrEmpty(unit.File_ID) ? "null" : "'" + unit.File_ID.Replace("'", "''") + "'")
                + " , [Medcine] = " + (unit.Medcine == null ? "''" : "'" + unit.Medcine.Replace("'", "''") + "'")
                + " , [ExperimentDealSign] = " + (unit.ExperimentDealSign == null ? "''" : "'" + unit.ExperimentDealSign.Replace("'", "''") + "'")
                + " , [ExperimentDealSignDate] = " + dbOperation.DbToDate(unit.ExperimentDealSignDate)
                + " , [ChiefSign] = " + (unit.ChiefSign == null ? "''" : "'" + unit.ChiefSign.Replace("'", "''") + "'")
                + " , [ChiefSignData] = " + dbOperation.DbToDate(unit.ChiefSignData)
                + " WHERE  convert(varchar(7),ExperimentDealDate,102)= '" + apply_id + "'"
                + " AND upper(SHIP_Id)= '" + shipID.ToUpper() + "' ";

            if (unit.Report_CoolWater_Id != null && unit.Report_CoolWater_Id.Length > 0) //edit
            {
                sql2 = "UPDATE [T_REPORT_COOLWATER] SET "
                    + " [Report_CoolWater_Id] = " + (unit.Report_CoolWater_Id == null ? "''" : "'" + unit.Report_CoolWater_Id.Replace("'", "''") + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , [File_ID] = " + (string.IsNullOrEmpty(unit.File_ID) ? "null" : "'" + unit.File_ID.Replace("'", "''") + "'")
                    + " , [Medcine] = " + (unit.Medcine == null ? "''" : "'" + unit.Medcine.Replace("'", "''") + "'")
                    + " , [MainLinerConcentration] = " + (unit.MainLinerConcentration == null ? "''" : "'" + unit.MainLinerConcentration.Replace("'", "''") + "'")
                    + " , [MainLInerDosage] = " + (unit.MainLInerDosage == null ? "''" : "'" + unit.MainLInerDosage.Replace("'", "''") + "'")
                    + " , [MainPistonConcentration] = " + (unit.MainPistonConcentration == null ? "''" : "'" + unit.MainPistonConcentration.Replace("'", "''") + "'")
                    + " , [MainPistonDosage] = " + (unit.MainPistonDosage == null ? "''" : "'" + unit.MainPistonDosage.Replace("'", "''") + "'")
                    + " , [MainOilConcentration] = " + (unit.MainOilConcentration == null ? "''" : "'" + unit.MainOilConcentration.Replace("'", "''") + "'")
                    + " , [MainOilDosage] = " + (unit.MainOilDosage == null ? "''" : "'" + unit.MainOilDosage.Replace("'", "''") + "'")
                    + " , [SecondConcentration] = " + (unit.SecondConcentration == null ? "''" : "'" + unit.SecondConcentration.Replace("'", "''") + "'")
                    + " , [SecondDosage] = " + (unit.SecondDosage == null ? "''" : "'" + unit.SecondDosage.Replace("'", "''") + "'")
                    + " , [ExperimentDealDate] = " + dbOperation.DbToDate(unit.ExperimentDealDate)
                    + " , [ExperimentDealSign] = " + (unit.ExperimentDealSign == null ? "''" : "'" + unit.ExperimentDealSign.Replace("'", "''") + "'")
                    + " , [ExperimentDealSignDate] = " + dbOperation.DbToDate(unit.ExperimentDealSignDate)
                    + " , [ChiefSign] = " + (unit.ChiefSign == null ? "''" : "'" + unit.ChiefSign.Replace("'", "''") + "'")
                    + " , [ChiefSignData] = " + dbOperation.DbToDate(unit.ChiefSignData)
                    + " where upper(Report_CoolWater_Id) = '" + unit.Report_CoolWater_Id.ToUpper() + "'";
            }
            else
            {
                unit.Report_CoolWater_Id = Guid.NewGuid().ToString();
                sql2 = "INSERT INTO [T_REPORT_COOLWATER] ("
                    + "[Report_CoolWater_Id],"
                    + "[SHIP_ID],"
                    + "[File_ID],"
                    + "[Medcine],"
                    + "[MainLinerConcentration],"
                    + "[MainLInerDosage],"
                    + "[MainPistonConcentration],"
                    + "[MainPistonDosage],"
                    + "[MainOilConcentration],"
                    + "[MainOilDosage],"
                    + "[SecondConcentration],"
                    + "[SecondDosage],"
                    + "[ExperimentDealDate],"
                    + "[ExperimentDealSign],"
                    + "[ExperimentDealSignDate],"
                    + "[ChiefSign],"
                    + "[ChiefSignData]"
                    + ") VALUES( "
                    + " " + (unit.Report_CoolWater_Id == null ? "''" : "'" + unit.Report_CoolWater_Id.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.File_ID) ? "null" : "'" + unit.File_ID.Replace("'", "''") + "'")
                    + " , " + (unit.Medcine == null ? "''" : "'" + unit.Medcine.Replace("'", "''") + "'")
                    + " , " + (unit.MainLinerConcentration == null ? "''" : "'" + unit.MainLinerConcentration.Replace("'", "''") + "'")
                    + " , " + (unit.MainLInerDosage == null ? "''" : "'" + unit.MainLInerDosage.Replace("'", "''") + "'")
                    + " , " + (unit.MainPistonConcentration == null ? "''" : "'" + unit.MainPistonConcentration.Replace("'", "''") + "'")
                    + " , " + (unit.MainPistonDosage == null ? "''" : "'" + unit.MainPistonDosage.Replace("'", "''") + "'")
                    + " , " + (unit.MainOilConcentration == null ? "''" : "'" + unit.MainOilConcentration.Replace("'", "''") + "'")
                    + " , " + (unit.MainOilDosage == null ? "''" : "'" + unit.MainOilDosage.Replace("'", "''") + "'")
                    + " , " + (unit.SecondConcentration == null ? "''" : "'" + unit.SecondConcentration.Replace("'", "''") + "'")
                    + " , " + (unit.SecondDosage == null ? "''" : "'" + unit.SecondDosage.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.ExperimentDealDate)
                    + " , " + (unit.ExperimentDealSign == null ? "''" : "'" + unit.ExperimentDealSign.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.ExperimentDealSignDate)
                    + " , " + (unit.ChiefSign == null ? "''" : "'" + unit.ChiefSign.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.ChiefSignData)
                    + ")";
            }

            lstSql.Add(sql);
            lstSql.Add(sql2);

            if (!dbAccess.ExecSql(lstSql, out err))
            {
                throw new Exception("UpdateSomeRecord occur err:" + err);
            }
            else
            {
                return true;
            }
        }
    }
}
