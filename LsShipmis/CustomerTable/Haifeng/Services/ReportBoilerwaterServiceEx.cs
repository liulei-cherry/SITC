/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：ReportBoilerwaterService.cs
 * 创 建 人：黄家龙
 * 创建时间：2011/8/17
 * 标    题：数据操作类
 * 功能描述：T_REPORT_BOILERWATER数据操作类
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
    /// 数据层实例化接口类 dbo.T_REPORT_BOILERWATERService.cs
    /// </summary>
    public partial class ReportBoilerwaterService
    {
        /// <summary>
        /// 获得 "年度处理报表情况" 数据.
        /// </summary>
        public DataTable getInfoByYear(string ship_id, DateTime year, out string err)
        {
            sql = "select * from (";
            sql += "select T.File_ID,T.BoilerCategory,T.BoilerAirPressure,T.BoilerWaterQuantity"
                + ",CONVERT(varchar(7), T.FileDate, 102) as FileDate"
                + ",T.ExperimentOrHandlePersonName,T.ChiefEngineerName"
                + "  from T_REPORT_BOILERWATER T";
            sql += " where upper(SHIP_Id)= '" + ship_id.ToUpper() + "'"
            + "and convert(varchar(4),T.FileDate,102)='" + year.ToString("yyyy") + "'";
            sql += " ) s group by s.BoilerCategory,s.BoilerAirPressure,s.BoilerWaterQuantity"
            + ",s.FileDate,s.ExperimentOrHandlePersonName,s.ChiefEngineerName,s.File_ID ";
            sql += " order by s.FileDate ";

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
        /// 获取明细信息.
        /// </summary>
        /// <param name="apply_id"></param>
        /// <returns></returns>
        public DataTable GetApplyDatas(string apply_id, string shipID)
        {
            string err;
            DataTable dtreturn;

            sql = "select CONVERT(varchar(10), T.FileDate, 102) as FileDate,"
                + "T.PhenolphthaleinAlkalinity,T.SaltAmount,T.Hardness"
                + ",T.PHValue,T.SewageOnAmount,T.SewageNextAmount,T.Medicine1"
                + ",T.Medicine2,T.Medicine3,T.Medicine1Value,T.Medicine2Value"
                + ",T.Medicine3Value,T.CondensateLevel,T.CondensateSilverNitrateDrops"
                + ",T.TankWaterLeverl,T.TankWateSilverNitrateDrops,T.Remarks"
                + " from T_REPORT_BOILERWATER T ";
            sql += " WHERE  convert(varchar(7),T.FileDate,102)= '" + apply_id + "'";
            sql += " AND upper(SHIP_Id)= '" + shipID.ToUpper() + "' ";

            if (!dbAccess.GetDataTable(sql, out dtreturn, out err))
            {
                throw new Exception("GetApplyDatas occur err:" + err);
            }
            return dtreturn;
        }

        /// <summary>
        /// 获取记录详细信息.
        /// </summary>
        /// <param name="apply_id"></param>
        /// <returns></returns>
        public ReportBoilerwater GetMainDetail(string apply_id, string ship_id, out string err)
        {
            DataTable dtreturn;

            sql = "select * "
                + "  from T_REPORT_BOILERWATER T";
            sql += " where convert(varchar(10),T.FileDate,102)= '" + apply_id + "'";
            sql += "  and  upper(SHIP_Id)= '" + ship_id.ToUpper() + "'";

            if (!dbAccess.GetDataTable(sql, out dtreturn, out err))
            {
                getObject(null);
                throw new Exception("GetMainDetail occur err:" + err);
            }
            return getObject(dtreturn.Rows[0]);
        }

        /// <summary>
        /// 检查某明细日信息是否已经存在.
        /// </summary>
        /// <param name="apply_id"></param>
        /// <returns></returns>
        public bool CheckSubDetail(string apply_id, string ship_id)
        {
            sql = "select count(1) "
                + "  from T_REPORT_BOILERWATER T";
            sql += " where convert(varchar(10),T.FileDate,102)= '" + apply_id + "'";
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
        /// 检查某明细日信息是否已经存在.
        /// </summary>
        /// <param name="apply_id"></param>
        /// <returns></returns>
        public bool CheckSubMonth(string apply_id, string ship_id)
        {
            sql = "select count(1) "
                + "  from T_REPORT_BOILERWATER T";
            sql += " where convert(varchar(7),T.FileDate,102)= '" + apply_id + "'";
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
        /// 批量更新主信息.
        /// </summary>
        /// <param name="BoilerCategory"></param>
        /// <param name="BoilerAirPressure"></param>
        /// <param name="BoilerWaterQuantity"></param>
        /// <param name="ExperimentOrHandlePersonName"></param>
        /// <param name="ChiefEngineerName"></param>
        /// <returns></returns>
        public bool UpdateSomeRecord(string apply_id, string shipID, ReportBoilerwater unit)
        {
            string sql2 = "";
            string err = "";
            List<string> lstSql = new List<string>();
            sql = "UPDATE T_REPORT_BOILERWATER "
            + " SET "
            + " [File_ID] = " + (string.IsNullOrEmpty(unit.File_ID) ? "null" : "'" + unit.File_ID.Replace("'", "''") + "'")
            + " ,[BoilerCategory] = " + (unit.BoilerCategory == null ? "''" : "'" + unit.BoilerCategory.Replace("'", "''") + "'")
            + " , [BoilerAirPressure] = " + (unit.BoilerAirPressure == null ? "''" : "'" + unit.BoilerAirPressure.Replace("'", "''") + "'")
            + " , [BoilerWaterQuantity] = " + (unit.BoilerWaterQuantity == null ? "''" : "'" + unit.BoilerWaterQuantity.Replace("'", "''") + "'")
            + " , [Medicine1] = " + (unit.Medicine1 == null ? "''" : "'" + unit.Medicine1.Replace("'", "''") + "'")
            + " , [Medicine2] = " + (unit.Medicine2 == null ? "''" : "'" + unit.Medicine2.Replace("'", "''") + "'")
            + " , [Medicine3] = " + (unit.Medicine3 == null ? "''" : "'" + unit.Medicine3.Replace("'", "''") + "'")
            + " , [ExperimentOrHandlePersonName] = " + (unit.ExperimentOrHandlePersonName == null ? "''" : "'" + unit.ExperimentOrHandlePersonName.Replace("'", "''") + "'")
             + " , [ChiefEngineerName] = " + (unit.ChiefEngineerName == null ? "''" : "'" + unit.ChiefEngineerName.Replace("'", "''") + "'")
            + " WHERE  convert(varchar(7),FileDate,102)= '" + apply_id + "'"
            + " AND upper(SHIP_Id)= '" + shipID.ToUpper() + "' ";

            if (unit.Report_BoilerWater_Id != null && unit.Report_BoilerWater_Id.Length > 0) //edit
            {
                sql2 = "UPDATE [T_REPORT_BOILERWATER] SET "
                    + " [Report_BoilerWater_Id] = " + (unit.Report_BoilerWater_Id == null ? "''" : "'" + unit.Report_BoilerWater_Id.Replace("'", "''") + "'")
                    + " , [File_ID] = " + (string.IsNullOrEmpty(unit.File_ID) ? "null" : "'" + unit.File_ID.Replace("'", "''") + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , [BoilerCategory] = " + (unit.BoilerCategory == null ? "''" : "'" + unit.BoilerCategory.Replace("'", "''") + "'")
                    + " , [BoilerAirPressure] = " + (unit.BoilerAirPressure == null ? "''" : "'" + unit.BoilerAirPressure.Replace("'", "''") + "'")
                    + " , [BoilerWaterQuantity] = " + (unit.BoilerWaterQuantity == null ? "''" : "'" + unit.BoilerWaterQuantity.Replace("'", "''") + "'")
                    + " , [FileDate] = " + dbOperation.DbToDate(unit.FileDate)
                    + " , [PhenolphthaleinAlkalinity] = " + (unit.PhenolphthaleinAlkalinity == null ? "''" : "'" + unit.PhenolphthaleinAlkalinity.Replace("'", "''") + "'")
                    + " , [SaltAmount] = " + (unit.SaltAmount == null ? "''" : "'" + unit.SaltAmount.Replace("'", "''") + "'")
                    + " , [Hardness] = " + (unit.Hardness == null ? "''" : "'" + unit.Hardness.Replace("'", "''") + "'")
                    + " , [PHValue] = " + (unit.PHValue == null ? "''" : "'" + unit.PHValue.Replace("'", "''") + "'")
                    + " , [SewageOnAmount] = " + (unit.SewageOnAmount == null ? "''" : "'" + unit.SewageOnAmount.Replace("'", "''") + "'")
                    + " , [SewageNextAmount] = " + (unit.SewageNextAmount == null ? "''" : "'" + unit.SewageNextAmount.Replace("'", "''") + "'")
                    + " , [Medicine1] = " + (unit.Medicine1 == null ? "''" : "'" + unit.Medicine1.Replace("'", "''") + "'")
                    + " , [Medicine2] = " + (unit.Medicine2 == null ? "''" : "'" + unit.Medicine2.Replace("'", "''") + "'")
                    + " , [Medicine3] = " + (unit.Medicine3 == null ? "''" : "'" + unit.Medicine3.Replace("'", "''") + "'")
                    + " , [Medicine1Value] = " + (unit.Medicine1Value == null ? "''" : "'" + unit.Medicine1Value.Replace("'", "''") + "'")
                    + " , [Medicine2Value] = " + (unit.Medicine2Value == null ? "''" : "'" + unit.Medicine2Value.Replace("'", "''") + "'")
                    + " , [Medicine3Value] = " + (unit.Medicine3Value == null ? "''" : "'" + unit.Medicine3Value.Replace("'", "''") + "'")
                    + " , [CondensateLevel] = " + (unit.CondensateLevel == null ? "''" : "'" + unit.CondensateLevel.Replace("'", "''") + "'")
                    + " , [CondensateSilverNitrateDrops] = " + (unit.CondensateSilverNitrateDrops == null ? "''" : "'" + unit.CondensateSilverNitrateDrops.Replace("'", "''") + "'")
                    + " , [TankWaterLeverl] = " + (unit.TankWaterLeverl == null ? "''" : "'" + unit.TankWaterLeverl.Replace("'", "''") + "'")
                    + " , [TankWateSilverNitrateDrops] = " + (unit.TankWateSilverNitrateDrops == null ? "''" : "'" + unit.TankWateSilverNitrateDrops.Replace("'", "''") + "'")
                    + " , [Remarks] = " + (unit.Remarks == null ? "''" : "'" + unit.Remarks.Replace("'", "''") + "'")
                    + " , [ExperimentOrHandlePersonName] = " + (unit.ExperimentOrHandlePersonName == null ? "''" : "'" + unit.ExperimentOrHandlePersonName.Replace("'", "''") + "'")
                    + " , [ChiefEngineerName] = " + (unit.ChiefEngineerName == null ? "''" : "'" + unit.ChiefEngineerName.Replace("'", "''") + "'")
                    + " where upper(Report_BoilerWater_Id) = '" + unit.Report_BoilerWater_Id.ToUpper() + "'";
            }
            else
            {
                unit.Report_BoilerWater_Id = Guid.NewGuid().ToString();
                sql2 = "INSERT INTO [T_REPORT_BOILERWATER] ("
                    + "[Report_BoilerWater_Id],"
                    + "[File_ID],"
                    + "[SHIP_ID],"
                    + "[BoilerCategory],"
                    + "[BoilerAirPressure],"
                    + "[BoilerWaterQuantity],"
                    + "[FileDate],"
                    + "[PhenolphthaleinAlkalinity],"
                    + "[SaltAmount],"
                    + "[Hardness],"
                    + "[PHValue],"
                    + "[SewageOnAmount],"
                    + "[SewageNextAmount],"
                    + "[Medicine1],"
                    + "[Medicine2],"
                    + "[Medicine3],"
                    + "[Medicine1Value],"
                    + "[Medicine2Value],"
                    + "[Medicine3Value],"
                    + "[CondensateLevel],"
                    + "[CondensateSilverNitrateDrops],"
                    + "[TankWaterLeverl],"
                    + "[TankWateSilverNitrateDrops],"
                    + "[Remarks],"
                    + "[ExperimentOrHandlePersonName],"
                    + "[ChiefEngineerName]"
                    + ") VALUES( "
                    + " " + (unit.Report_BoilerWater_Id == null ? "''" : "'" + unit.Report_BoilerWater_Id.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.File_ID) ? "null" : "'" + unit.File_ID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , " + (unit.BoilerCategory == null ? "''" : "'" + unit.BoilerCategory.Replace("'", "''") + "'")
                    + " , " + (unit.BoilerAirPressure == null ? "''" : "'" + unit.BoilerAirPressure.Replace("'", "''") + "'")
                    + " , " + (unit.BoilerWaterQuantity == null ? "''" : "'" + unit.BoilerWaterQuantity.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.FileDate)
                    + " , " + (unit.PhenolphthaleinAlkalinity == null ? "''" : "'" + unit.PhenolphthaleinAlkalinity.Replace("'", "''") + "'")
                    + " , " + (unit.SaltAmount == null ? "''" : "'" + unit.SaltAmount.Replace("'", "''") + "'")
                    + " , " + (unit.Hardness == null ? "''" : "'" + unit.Hardness.Replace("'", "''") + "'")
                    + " , " + (unit.PHValue == null ? "''" : "'" + unit.PHValue.Replace("'", "''") + "'")
                    + " , " + (unit.SewageOnAmount == null ? "''" : "'" + unit.SewageOnAmount.Replace("'", "''") + "'")
                    + " , " + (unit.SewageNextAmount == null ? "''" : "'" + unit.SewageNextAmount.Replace("'", "''") + "'")
                    + " , " + (unit.Medicine1 == null ? "''" : "'" + unit.Medicine1.Replace("'", "''") + "'")
                    + " , " + (unit.Medicine2 == null ? "''" : "'" + unit.Medicine2.Replace("'", "''") + "'")
                    + " , " + (unit.Medicine3 == null ? "''" : "'" + unit.Medicine3.Replace("'", "''") + "'")
                    + " , " + (unit.Medicine1Value == null ? "''" : "'" + unit.Medicine1Value.Replace("'", "''") + "'")
                    + " , " + (unit.Medicine2Value == null ? "''" : "'" + unit.Medicine2Value.Replace("'", "''") + "'")
                    + " , " + (unit.Medicine3Value == null ? "''" : "'" + unit.Medicine3Value.Replace("'", "''") + "'")
                    + " , " + (unit.CondensateLevel == null ? "''" : "'" + unit.CondensateLevel.Replace("'", "''") + "'")
                    + " , " + (unit.CondensateSilverNitrateDrops == null ? "''" : "'" + unit.CondensateSilverNitrateDrops.Replace("'", "''") + "'")
                    + " , " + (unit.TankWaterLeverl == null ? "''" : "'" + unit.TankWaterLeverl.Replace("'", "''") + "'")
                    + " , " + (unit.TankWateSilverNitrateDrops == null ? "''" : "'" + unit.TankWateSilverNitrateDrops.Replace("'", "''") + "'")
                    + " , " + (unit.Remarks == null ? "''" : "'" + unit.Remarks.Replace("'", "''") + "'")
                    + " , " + (unit.ExperimentOrHandlePersonName == null ? "''" : "'" + unit.ExperimentOrHandlePersonName.Replace("'", "''") + "'")
                    + " , " + (unit.ChiefEngineerName == null ? "''" : "'" + unit.ChiefEngineerName.Replace("'", "''") + "'")
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
