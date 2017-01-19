/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：ReportShipHostService.cs
 * 创 建 人：黄家龙
 * 创建时间：2011/8/25
 * 标    题：数据操作类
 * 功能描述：T_REPORT_SHIPHOST数据操作类
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
    /// 数据层实例化接口类 dbo.T_REPORT_SHIPHOSTService.cs
    /// </summary>
    public partial class ReportShipHostService
    {
        /// <summary>
        /// 获得 "年月度船舶主机工况参数" 数据.
        /// </summary>
        public DataTable getInfoByYear(string ship_id, DateTime year, out string err)
        {
            sql = "SELECT [Report_ShipHost_Id]"
              + " ,[SHIP_ID]"
              + " ,[File_ID]"
              + ",CONVERT(varchar(10), Host_RecordDate, 102) as Host_RecordDate"
              + ",[Host_Speed]"
              + ",[Host_LoadInstruction]"
              + ",[Host_SmokeHign_Tem]"
              + ",[Host_SmokeHign_CylinderNO]"
              + ",[Host_SmokeLow_Tem]"
              + ",[Host_SmokeLow_CylinderNO]"
              + ",[Host_LinerCoolWaterIn_Tem]"
              + ",[Host_LinerCoolWaterOut_Tem]"
              +" ,[Host_PistonCoolantIn_Tem]"
              + ",[Host_PistonCoolanOut_Tem]"
              + ",[Host_CoolerBeforeNO1_Tem]"
              + ",[Host_CoolerBeforeNO2_Tem]"
              + ",[Host_CoolerBeforeNO3_Tem]"
              + ",[Host_CoolerAfterNO1_Tem]"
              + ",[Host_CoolerAfterNO2_Tem]"
              + ",[Host_CoolerAfterNO3_Tem]"
              + ",[Host_SternTube_Tem]"
              + ",[Host_Cabin_Tem]"
              + ",[Host_SeaWater_Tem]"
              + ",[Host_CoolWaterHigh_MPa]"
              + ",[Host_CoolWaterLow_MPa]"
              + ",[Host_OilMain_Mpa]"
              + ",[Host_OilCrosshead_Mpa]"
              + ",[Host_PressurizedAir_Mpa]"
              + ",[Host_FuelInto_Mpa]"
              + ",[Host_ActualSpeed]"
              + ",[Host_LossRate]"
              + ",[Host_TurbochargerSpeedNO1]"
              + ",[Host_TurbochargerSpeedNO2] ";

            sql += " FROM [T_REPORT_SHIPHOST]";
            sql += " WHERE upper(SHIP_Id)= '" + ship_id.ToUpper() + "'"
                + " and convert(varchar(7),[Host_RecordDate],102)='" + year.ToString("yyyy.MM") + "'";
            sql += " order by [Host_RecordDate] ";

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
        /// 获取当月条款信息.
        /// </summary>
        /// <param name="apply_id"></param>
        /// <returns></returns>
        public DataTable GetApplyDatas(string apply_id, string shipID)
        {
            string err;
            DataTable dtreturn;

            sql = "SELECT [Report_ShipHost_Id]"
              + ",[SHIP_ID]"
              + ",[File_ID]"
              + ",CONVERT(varchar(10), Host_RecordDate, 102) as Host_RecordDate"
              + ",[Host_Speed]"
              + ",[Host_LoadInstruction]"
              + ",[Host_SmokeHign_Tem]"
              + ",[Host_SmokeHign_CylinderNO]"
              + ",[Host_SmokeLow_Tem]"
              + ",[Host_SmokeLow_CylinderNO]"
              + ",[Host_LinerCoolWaterIn_Tem]"
              + ",[Host_LinerCoolWaterOut_Tem]"
              + " ,[Host_PistonCoolantIn_Tem]"
              + ",[Host_PistonCoolanOut_Tem]"
              + ",[Host_CoolerBeforeNO1_Tem]"
              + ",[Host_CoolerBeforeNO2_Tem]"
              + ",[Host_CoolerBeforeNO3_Tem]"
              + ",[Host_CoolerAfterNO1_Tem]"
              + ",[Host_CoolerAfterNO2_Tem]"
              + ",[Host_CoolerAfterNO3_Tem]"
              + ",[Host_SternTube_Tem]"
              + ",[Host_Cabin_Tem]"
              + ",[Host_SeaWater_Tem]"
              + ",[Host_CoolWaterHigh_MPa]"
              + ",[Host_CoolWaterLow_MPa]"
              + ",[Host_OilMain_Mpa]"
              + ",[Host_OilCrosshead_Mpa]"
              + ",[Host_PressurizedAir_Mpa]"
              + ",[Host_FuelInto_Mpa]"
              + ",[Host_ActualSpeed]"
              + ",[Host_LossRate]"
              + ",[Host_TurbochargerSpeedNO1]"
              + ",[Host_TurbochargerSpeedNO2] ";

            sql += " FROM [T_REPORT_SHIPHOST]";
            sql += " WHERE  convert(varchar(7),Host_RecordDate,102)= '" + apply_id + "'";
            sql += " AND upper(SHIP_Id)= '" + shipID.ToUpper() + "' ";
            sql += " order by Host_RecordDate";

            if (!dbAccess.GetDataTable(sql, out dtreturn, out err))
            {
                throw new Exception("GetApplyDatas occur err:" + err);
            }
            return dtreturn;
        }

        /// <summary>
        /// 检查某参数摘录日信息是否已经存在.
        /// </summary>
        /// <param name="apply_id"></param>
        /// <returns></returns>
        public bool CheckSubDetail(string apply_id, string ship_id)
        {
            sql = "select count(1) "
                + "  from T_REPORT_SHIPHOST T";
            sql += " where convert(varchar(10),T.Host_RecordDate,102)= '" + apply_id + "'";
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
        /// 获取当月条款记录详细信息.
        /// </summary>
        /// <param name="apply_id"></param>
        /// <returns></returns>
        public ReportShipHost GetMainDetail(string apply_id, string ship_id, out string err)
        {
            DataTable dtreturn;

            sql = "select * "
                + "  from T_REPORT_SHIPHOST T";
            sql += " where convert(varchar(10),T.Host_RecordDate,102)= '" + apply_id + "'";
            sql += "  and  upper(SHIP_Id)= '" + ship_id.ToUpper() + "'";
            sql += " order by T.Host_RecordDate desc";

            if (!dbAccess.GetDataTable(sql, out dtreturn, out err))
            {
                getObject(null);
                throw new Exception("GetMainDetail occur err:" + err);
            }

            return getObject(dtreturn.Rows[0]);
        }

        public bool UpdateSomeRecord(string apply_id, string shipID, ReportShipHost unit)
        {
            string sql2 = "";
            string err = "";
            List<string> lstSql = new List<string>();

            sql = "UPDATE T_REPORT_SHIPHOST"
                    + " SET "
                    + "  [Voyage] = " + (unit.Voyage == null ? "''" : "'" + unit.Voyage.Replace("'", "''") + "'")
                    + " , [TableWritedDate] = " + dbOperation.DbToDate(unit.TableWritedDate)
                    + " , [Host_ParaAbstractedDate] = " + dbOperation.DbToDate(unit.Host_ParaAbstractedDate)
                    + " , [HH_HighPumpNO1] = " + (unit.HH_HighPumpNO1 == null ? "''" : "'" + unit.HH_HighPumpNO1.Replace("'", "''") + "'")
                    + " , [HH_HighPumpNO2] = " + (unit.HH_HighPumpNO2 == null ? "''" : "'" + unit.HH_HighPumpNO2.Replace("'", "''") + "'")
                    + " , [HH_HighPumpNO3] = " + (unit.HH_HighPumpNO3 == null ? "''" : "'" + unit.HH_HighPumpNO3.Replace("'", "''") + "'")
                    + " , [HH_HighPumpNO4] = " + (unit.HH_HighPumpNO4 == null ? "''" : "'" + unit.HH_HighPumpNO4.Replace("'", "''") + "'")
                    + " , [HH_HighPumpNO5] = " + (unit.HH_HighPumpNO5 == null ? "''" : "'" + unit.HH_HighPumpNO5.Replace("'", "''") + "'")
                    + " , [HH_HighPumpNO6] = " + (unit.HH_HighPumpNO6 == null ? "''" : "'" + unit.HH_HighPumpNO6.Replace("'", "''") + "'")
                    + " , [HH_HighPumpNO7] = " + (unit.HH_HighPumpNO7 == null ? "''" : "'" + unit.HH_HighPumpNO7.Replace("'", "''") + "'")
                    + " , [HH_HighPumpNO8] = " + (unit.HH_HighPumpNO8 == null ? "''" : "'" + unit.HH_HighPumpNO8.Replace("'", "''") + "'")
                    + " , [HH_HighPumpAverage] = " + (unit.HH_HighPumpAverage == null ? "''" : "'" + unit.HH_HighPumpAverage.Replace("'", "''") + "'")
                    + " , [HH_VITNO1] = " + (unit.HH_VITNO1 == null ? "''" : "'" + unit.HH_VITNO1.Replace("'", "''") + "'")
                    + " , [HH_VITNO2] = " + (unit.HH_VITNO2 == null ? "''" : "'" + unit.HH_VITNO2.Replace("'", "''") + "'")
                    + " , [HH_VITNO3] = " + (unit.HH_VITNO3 == null ? "''" : "'" + unit.HH_VITNO3.Replace("'", "''") + "'")
                    + " , [HH_VITNO4] = " + (unit.HH_VITNO4 == null ? "''" : "'" + unit.HH_VITNO4.Replace("'", "''") + "'")
                    + " , [HH_VITNO5] = " + (unit.HH_VITNO5 == null ? "''" : "'" + unit.HH_VITNO5.Replace("'", "''") + "'")
                    + " , [HH_VITNO6] = " + (unit.HH_VITNO6 == null ? "''" : "'" + unit.HH_VITNO6.Replace("'", "''") + "'")
                    + " , [HH_VITNO7] = " + (unit.HH_VITNO7 == null ? "''" : "'" + unit.HH_VITNO7.Replace("'", "''") + "'")
                    + " , [HH_VITNO8] = " + (unit.HH_VITNO8 == null ? "''" : "'" + unit.HH_VITNO8.Replace("'", "''") + "'")
                    + " , [HH_VITAverage] = " + (unit.HH_VITAverage == null ? "''" : "'" + unit.HH_VITAverage.Replace("'", "''") + "'")
                    + " , [HH_SmokeTemNO1] = " + (unit.HH_SmokeTemNO1 == null ? "''" : "'" + unit.HH_SmokeTemNO1.Replace("'", "''") + "'")
                    + " , [HH_SmokeTemNO2] = " + (unit.HH_SmokeTemNO2 == null ? "''" : "'" + unit.HH_SmokeTemNO2.Replace("'", "''") + "'")
                    + " , [HH_SmokeTemNO3] = " + (unit.HH_SmokeTemNO3 == null ? "''" : "'" + unit.HH_SmokeTemNO3.Replace("'", "''") + "'")
                    + " , [HH_SmokeTemNO4] = " + (unit.HH_SmokeTemNO4 == null ? "''" : "'" + unit.HH_SmokeTemNO4.Replace("'", "''") + "'")
                    + " , [HH_SmokeTemNO5] = " + (unit.HH_SmokeTemNO5 == null ? "''" : "'" + unit.HH_SmokeTemNO5.Replace("'", "''") + "'")
                    + " , [HH_SmokeTemNO6] = " + (unit.HH_SmokeTemNO6 == null ? "''" : "'" + unit.HH_SmokeTemNO6.Replace("'", "''") + "'")
                    + " , [HH_SmokeTemNO7] = " + (unit.HH_SmokeTemNO7 == null ? "''" : "'" + unit.HH_SmokeTemNO7.Replace("'", "''") + "'")
                    + " , [HH_SmokeTemNO8] = " + (unit.HH_SmokeTemNO8 == null ? "''" : "'" + unit.HH_SmokeTemNO8.Replace("'", "''") + "'")
                    + " , [HH_SmokeTemAverage] = " + (unit.HH_SmokeTemAverage == null ? "''" : "'" + unit.HH_SmokeTemAverage.Replace("'", "''") + "'")
                    + " , [HH_CompressionPressNO1] = " + (unit.HH_CompressionPressNO1 == null ? "''" : "'" + unit.HH_CompressionPressNO1.Replace("'", "''") + "'")
                    + " , [HH_CompressionPressNO2] = " + (unit.HH_CompressionPressNO2 == null ? "''" : "'" + unit.HH_CompressionPressNO2.Replace("'", "''") + "'")
                    + " , [HH_CompressionPressNO3] = " + (unit.HH_CompressionPressNO3 == null ? "''" : "'" + unit.HH_CompressionPressNO3.Replace("'", "''") + "'")
                    + " , [HH_CompressionPressNO4] = " + (unit.HH_CompressionPressNO4 == null ? "''" : "'" + unit.HH_CompressionPressNO4.Replace("'", "''") + "'")
                    + " , [HH_CompressionPressNO5] = " + (unit.HH_CompressionPressNO5 == null ? "''" : "'" + unit.HH_CompressionPressNO5.Replace("'", "''") + "'")
                    + " , [HH_CompressionPressNO6] = " + (unit.HH_CompressionPressNO6 == null ? "''" : "'" + unit.HH_CompressionPressNO6.Replace("'", "''") + "'")
                    + " , [HH_CompressionPressNO7] = " + (unit.HH_CompressionPressNO7 == null ? "''" : "'" + unit.HH_CompressionPressNO7.Replace("'", "''") + "'")
                    + " , [HH_CompressionPressNO8] = " + (unit.HH_CompressionPressNO8 == null ? "''" : "'" + unit.HH_CompressionPressNO8.Replace("'", "''") + "'")
                    + " , [HH_CompressionPressAverage] = " + (unit.HH_CompressionPressAverage == null ? "''" : "'" + unit.HH_CompressionPressAverage.Replace("'", "''") + "'")
                    + " , [HH_BoomPressNO1] = " + (unit.HH_BoomPressNO1 == null ? "''" : "'" + unit.HH_BoomPressNO1.Replace("'", "''") + "'")
                    + " , [HH_BoomPressNO2] = " + (unit.HH_BoomPressNO2 == null ? "''" : "'" + unit.HH_BoomPressNO2.Replace("'", "''") + "'")
                    + " , [HH_BoomPressNO3] = " + (unit.HH_BoomPressNO3 == null ? "''" : "'" + unit.HH_BoomPressNO3.Replace("'", "''") + "'")
                    + " , [HH_BoomPressNO4] = " + (unit.HH_BoomPressNO4 == null ? "''" : "'" + unit.HH_BoomPressNO4.Replace("'", "''") + "'")
                    + " , [HH_BoomPressNO5] = " + (unit.HH_BoomPressNO5 == null ? "''" : "'" + unit.HH_BoomPressNO5.Replace("'", "''") + "'")
                    + " , [HH_BoomPressNO6] = " + (unit.HH_BoomPressNO6 == null ? "''" : "'" + unit.HH_BoomPressNO6.Replace("'", "''") + "'")
                    + " , [HH_BoomPressNO7] = " + (unit.HH_BoomPressNO7 == null ? "''" : "'" + unit.HH_BoomPressNO7.Replace("'", "''") + "'")
                    + " , [HH_BoomPressNO8] = " + (unit.HH_BoomPressNO8 == null ? "''" : "'" + unit.HH_BoomPressNO8.Replace("'", "''") + "'")
                    + " , [HH_BoomPressAverage] = " + (unit.HH_BoomPressAverage == null ? "''" : "'" + unit.HH_BoomPressAverage.Replace("'", "''") + "'")
                    + " , [HH_MeasureDate] = " + dbOperation.DbToDate(unit.HH_MeasureDate)
                    + " , [HH_Model] = " + (unit.HH_Model == null ? "''" : "'" + unit.HH_Model.Replace("'", "''") + "'")
                    + " , [HH_Load] = " + (unit.HH_Load == null ? "''" : "'" + unit.HH_Load.Replace("'", "''") + "'")
                    + " , [HH_SeaArea] = " + (unit.HH_SeaArea == null ? "''" : "'" + unit.HH_SeaArea.Replace("'", "''") + "'")
                    + " , [HH_Wind] = " + (unit.HH_Wind == null ? "''" : "'" + unit.HH_Wind.Replace("'", "''") + "'")
                    + " , [HH_Wave] = " + (unit.HH_Wave == null ? "''" : "'" + unit.HH_Wave.Replace("'", "''") + "'")
                    + " , [HH_BowDraft] = " + (unit.HH_BowDraft == null ? "''" : "'" + unit.HH_BowDraft.Replace("'", "''") + "'")
                    + " , [HH_PoopDraft] = " + (unit.HH_PoopDraft == null ? "''" : "'" + unit.HH_PoopDraft.Replace("'", "''") + "'")
                    + " , [HH_FireSequence] = " + (unit.HH_FireSequence == null ? "''" : "'" + unit.HH_FireSequence.Replace("'", "''") + "'")
                    + " , [HH_FuelSpecification] = " + (unit.HH_FuelSpecification == null ? "''" : "'" + unit.HH_FuelSpecification.Replace("'", "''") + "'")
                    + " , [HH_DailyConsumption] = " + (unit.HH_DailyConsumption == null ? "''" : "'" + unit.HH_DailyConsumption.Replace("'", "''") + "'")
                    + " , [HH_CylinderConstant] = " + (unit.HH_CylinderConstant == null ? "''" : "'" + unit.HH_CylinderConstant.Replace("'", "''") + "'")
                    + " , [HH_TotalKW] = " + (unit.HH_TotalKW == null ? "''" : "'" + unit.HH_TotalKW.Replace("'", "''") + "'")
                    + " , [HH_TotalRatedPower] = " + (unit.HH_TotalRatedPower == null ? "''" : "'" + unit.HH_TotalRatedPower.Replace("'", "''") + "'")
                    + " , [HH_TotalPower] = " + (unit.HH_TotalPower == null ? "''" : "'" + unit.HH_TotalPower.Replace("'", "''") + "'")
                    + " , [HH_Speed] = " + (unit.HH_Speed == null ? "''" : "'" + unit.HH_Speed.Replace("'", "''") + "'")
                    + " , [HH_SlipRate] = " + (unit.HH_SlipRate == null ? "''" : "'" + unit.HH_SlipRate.Replace("'", "''") + "'")
                    + " , [HH_MaxExhaustTempDifference] = " + (unit.HH_MaxExhaustTempDifference == null ? "''" : "'" + unit.HH_MaxExhaustTempDifference.Replace("'", "''") + "'")
                    + " , [HH_MaxCompressionPressDifference] = " + (unit.HH_MaxCompressionPressDifference == null ? "''" : "'" + unit.HH_MaxCompressionPressDifference.Replace("'", "''") + "'")
                    + " , [HH_DetonationPressDifference] = " + (unit.HH_DetonationPressDifference == null ? "''" : "'" + unit.HH_DetonationPressDifference.Replace("'", "''") + "'")
                    + " , [HH_FuelInTem] = " + (unit.HH_FuelInTem == null ? "''" : "'" + unit.HH_FuelInTem.Replace("'", "''") + "'")
                    + " , [HH_FuelInViscosity] = " + (unit.HH_FuelInViscosity == null ? "''" : "'" + unit.HH_FuelInViscosity.Replace("'", "''") + "'")
                    + " , [HH_Remarks] = " + (unit.HH_Remarks == null ? "''" : "'" + unit.HH_Remarks.Replace("'", "''") + "'")
                    + " , [HH_ChiefSign] = " + (unit.HH_ChiefSign == null ? "''" : "'" + unit.HH_ChiefSign.Replace("'", "''") + "'")
                    + " , [HH_ChiefSignDate] = " + dbOperation.DbToDate(unit.HH_ChiefSignDate)
                    + " , [HH_DirectorSign] = " + (unit.HH_DirectorSign == null ? "''" : "'" + unit.HH_DirectorSign.Replace("'", "''") + "'")
                    + " , [HH_DirectorSignDate] = " + dbOperation.DbToDate(unit.HH_DirectorSignDate);

            if (unit.Report_ShipHost_Id != null && unit.Report_ShipHost_Id.Length > 0) //edit
            {
                sql2 = "UPDATE [T_REPORT_SHIPHOST] SET "
                    + " [Report_ShipHost_Id] = " + (unit.Report_ShipHost_Id == null ? "''" : "'" + unit.Report_ShipHost_Id.Replace("'", "''") + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , [File_ID] = " + (string.IsNullOrEmpty(unit.File_ID) ? "null" : "'" + unit.File_ID.Replace("'", "''") + "'")
                    + " , [Voyage] = " + (unit.Voyage == null ? "''" : "'" + unit.Voyage.Replace("'", "''") + "'")
                    + " , [TableWritedDate] = " + dbOperation.DbToDate(unit.TableWritedDate)
                    + " , [Host_ParaAbstractedDate] = " + dbOperation.DbToDate(unit.Host_ParaAbstractedDate)
                    + " , [Host_RecordDate] = " + dbOperation.DbToDate(unit.Host_RecordDate)
                    + " , [Host_Speed] = " + (unit.Host_Speed == null ? "''" : "'" + unit.Host_Speed.Replace("'", "''") + "'")
                    + " , [Host_LoadInstruction] = " + (unit.Host_LoadInstruction == null ? "''" : "'" + unit.Host_LoadInstruction.Replace("'", "''") + "'")
                    + " , [Host_SmokeHign_Tem] = " + (unit.Host_SmokeHign_Tem == null ? "''" : "'" + unit.Host_SmokeHign_Tem.Replace("'", "''") + "'")
                    + " , [Host_SmokeHign_CylinderNO] = " + (unit.Host_SmokeHign_CylinderNO == null ? "''" : "'" + unit.Host_SmokeHign_CylinderNO.Replace("'", "''") + "'")
                    + " , [Host_SmokeLow_Tem] = " + (unit.Host_SmokeLow_Tem == null ? "''" : "'" + unit.Host_SmokeLow_Tem.Replace("'", "''") + "'")
                    + " , [Host_SmokeLow_CylinderNO] = " + (unit.Host_SmokeLow_CylinderNO == null ? "''" : "'" + unit.Host_SmokeLow_CylinderNO.Replace("'", "''") + "'")
                    + " , [Host_LinerCoolWaterIn_Tem] = " + (unit.Host_LinerCoolWaterIn_Tem == null ? "''" : "'" + unit.Host_LinerCoolWaterIn_Tem.Replace("'", "''") + "'")
                    + " , [Host_LinerCoolWaterOut_Tem] = " + (unit.Host_LinerCoolWaterOut_Tem == null ? "''" : "'" + unit.Host_LinerCoolWaterOut_Tem.Replace("'", "''") + "'")
                    + " , [Host_PistonCoolantIn_Tem] = " + (unit.Host_PistonCoolantIn_Tem == null ? "''" : "'" + unit.Host_PistonCoolantIn_Tem.Replace("'", "''") + "'")
                    + " , [Host_PistonCoolanOut_Tem] = " + (unit.Host_PistonCoolanOut_Tem == null ? "''" : "'" + unit.Host_PistonCoolanOut_Tem.Replace("'", "''") + "'")
                    + " , [Host_CoolerBeforeNO1_Tem] = " + (unit.Host_CoolerBeforeNO1_Tem == null ? "''" : "'" + unit.Host_CoolerBeforeNO1_Tem.Replace("'", "''") + "'")
                    + " , [Host_CoolerBeforeNO2_Tem] = " + (unit.Host_CoolerBeforeNO2_Tem == null ? "''" : "'" + unit.Host_CoolerBeforeNO2_Tem.Replace("'", "''") + "'")
                    + " , [Host_CoolerBeforeNO3_Tem] = " + (unit.Host_CoolerBeforeNO3_Tem == null ? "''" : "'" + unit.Host_CoolerBeforeNO3_Tem.Replace("'", "''") + "'")
                    + " , [Host_CoolerAfterNO1_Tem] = " + (unit.Host_CoolerAfterNO1_Tem == null ? "''" : "'" + unit.Host_CoolerAfterNO1_Tem.Replace("'", "''") + "'")
                    + " , [Host_CoolerAfterNO2_Tem] = " + (unit.Host_CoolerAfterNO2_Tem == null ? "''" : "'" + unit.Host_CoolerAfterNO2_Tem.Replace("'", "''") + "'")
                    + " , [Host_CoolerAfterNO3_Tem] = " + (unit.Host_CoolerAfterNO3_Tem == null ? "''" : "'" + unit.Host_CoolerAfterNO3_Tem.Replace("'", "''") + "'")
                    + " , [Host_SternTube_Tem] = " + (unit.Host_SternTube_Tem == null ? "''" : "'" + unit.Host_SternTube_Tem.Replace("'", "''") + "'")
                    + " , [Host_Cabin_Tem] = " + (unit.Host_Cabin_Tem == null ? "''" : "'" + unit.Host_Cabin_Tem.Replace("'", "''") + "'")
                    + " , [Host_SeaWater_Tem] = " + (unit.Host_SeaWater_Tem == null ? "''" : "'" + unit.Host_SeaWater_Tem.Replace("'", "''") + "'")
                    + " , [Host_CoolWaterHigh_MPa] = " + (unit.Host_CoolWaterHigh_MPa == null ? "''" : "'" + unit.Host_CoolWaterHigh_MPa.Replace("'", "''") + "'")
                    + " , [Host_CoolWaterLow_MPa] = " + (unit.Host_CoolWaterLow_MPa == null ? "''" : "'" + unit.Host_CoolWaterLow_MPa.Replace("'", "''") + "'")
                    + " , [Host_OilMain_Mpa] = " + (unit.Host_OilMain_Mpa == null ? "''" : "'" + unit.Host_OilMain_Mpa.Replace("'", "''") + "'")
                    + " , [Host_OilCrosshead_Mpa] = " + (unit.Host_OilCrosshead_Mpa == null ? "''" : "'" + unit.Host_OilCrosshead_Mpa.Replace("'", "''") + "'")
                    + " , [Host_PressurizedAir_Mpa] = " + (unit.Host_PressurizedAir_Mpa == null ? "''" : "'" + unit.Host_PressurizedAir_Mpa.Replace("'", "''") + "'")
                    + " , [Host_FuelInto_Mpa] = " + (unit.Host_FuelInto_Mpa == null ? "''" : "'" + unit.Host_FuelInto_Mpa.Replace("'", "''") + "'")
                    + " , [Host_ActualSpeed] = " + (unit.Host_ActualSpeed == null ? "''" : "'" + unit.Host_ActualSpeed.Replace("'", "''") + "'")
                    + " , [Host_LossRate] = " + (unit.Host_LossRate == null ? "''" : "'" + unit.Host_LossRate.Replace("'", "''") + "'")
                    + " , [Host_TurbochargerSpeedNO1] = " + (unit.Host_TurbochargerSpeedNO1 == null ? "''" : "'" + unit.Host_TurbochargerSpeedNO1.Replace("'", "''") + "'")
                    + " , [Host_TurbochargerSpeedNO2] = " + (unit.Host_TurbochargerSpeedNO2 == null ? "''" : "'" + unit.Host_TurbochargerSpeedNO2.Replace("'", "''") + "'")
                    + " , [HH_HighPumpNO1] = " + (unit.HH_HighPumpNO1 == null ? "''" : "'" + unit.HH_HighPumpNO1.Replace("'", "''") + "'")
                    + " , [HH_HighPumpNO2] = " + (unit.HH_HighPumpNO2 == null ? "''" : "'" + unit.HH_HighPumpNO2.Replace("'", "''") + "'")
                    + " , [HH_HighPumpNO3] = " + (unit.HH_HighPumpNO3 == null ? "''" : "'" + unit.HH_HighPumpNO3.Replace("'", "''") + "'")
                    + " , [HH_HighPumpNO4] = " + (unit.HH_HighPumpNO4 == null ? "''" : "'" + unit.HH_HighPumpNO4.Replace("'", "''") + "'")
                    + " , [HH_HighPumpNO5] = " + (unit.HH_HighPumpNO5 == null ? "''" : "'" + unit.HH_HighPumpNO5.Replace("'", "''") + "'")
                    + " , [HH_HighPumpNO6] = " + (unit.HH_HighPumpNO6 == null ? "''" : "'" + unit.HH_HighPumpNO6.Replace("'", "''") + "'")
                    + " , [HH_HighPumpNO7] = " + (unit.HH_HighPumpNO7 == null ? "''" : "'" + unit.HH_HighPumpNO7.Replace("'", "''") + "'")
                    + " , [HH_HighPumpNO8] = " + (unit.HH_HighPumpNO8 == null ? "''" : "'" + unit.HH_HighPumpNO8.Replace("'", "''") + "'")
                    + " , [HH_HighPumpAverage] = " + (unit.HH_HighPumpAverage == null ? "''" : "'" + unit.HH_HighPumpAverage.Replace("'", "''") + "'")
                    + " , [HH_VITNO1] = " + (unit.HH_VITNO1 == null ? "''" : "'" + unit.HH_VITNO1.Replace("'", "''") + "'")
                    + " , [HH_VITNO2] = " + (unit.HH_VITNO2 == null ? "''" : "'" + unit.HH_VITNO2.Replace("'", "''") + "'")
                    + " , [HH_VITNO3] = " + (unit.HH_VITNO3 == null ? "''" : "'" + unit.HH_VITNO3.Replace("'", "''") + "'")
                    + " , [HH_VITNO4] = " + (unit.HH_VITNO4 == null ? "''" : "'" + unit.HH_VITNO4.Replace("'", "''") + "'")
                    + " , [HH_VITNO5] = " + (unit.HH_VITNO5 == null ? "''" : "'" + unit.HH_VITNO5.Replace("'", "''") + "'")
                    + " , [HH_VITNO6] = " + (unit.HH_VITNO6 == null ? "''" : "'" + unit.HH_VITNO6.Replace("'", "''") + "'")
                    + " , [HH_VITNO7] = " + (unit.HH_VITNO7 == null ? "''" : "'" + unit.HH_VITNO7.Replace("'", "''") + "'")
                    + " , [HH_VITNO8] = " + (unit.HH_VITNO8 == null ? "''" : "'" + unit.HH_VITNO8.Replace("'", "''") + "'")
                    + " , [HH_VITAverage] = " + (unit.HH_VITAverage == null ? "''" : "'" + unit.HH_VITAverage.Replace("'", "''") + "'")
                    + " , [HH_SmokeTemNO1] = " + (unit.HH_SmokeTemNO1 == null ? "''" : "'" + unit.HH_SmokeTemNO1.Replace("'", "''") + "'")
                    + " , [HH_SmokeTemNO2] = " + (unit.HH_SmokeTemNO2 == null ? "''" : "'" + unit.HH_SmokeTemNO2.Replace("'", "''") + "'")
                    + " , [HH_SmokeTemNO3] = " + (unit.HH_SmokeTemNO3 == null ? "''" : "'" + unit.HH_SmokeTemNO3.Replace("'", "''") + "'")
                    + " , [HH_SmokeTemNO4] = " + (unit.HH_SmokeTemNO4 == null ? "''" : "'" + unit.HH_SmokeTemNO4.Replace("'", "''") + "'")
                    + " , [HH_SmokeTemNO5] = " + (unit.HH_SmokeTemNO5 == null ? "''" : "'" + unit.HH_SmokeTemNO5.Replace("'", "''") + "'")
                    + " , [HH_SmokeTemNO6] = " + (unit.HH_SmokeTemNO6 == null ? "''" : "'" + unit.HH_SmokeTemNO6.Replace("'", "''") + "'")
                    + " , [HH_SmokeTemNO7] = " + (unit.HH_SmokeTemNO7 == null ? "''" : "'" + unit.HH_SmokeTemNO7.Replace("'", "''") + "'")
                    + " , [HH_SmokeTemNO8] = " + (unit.HH_SmokeTemNO8 == null ? "''" : "'" + unit.HH_SmokeTemNO8.Replace("'", "''") + "'")
                    + " , [HH_SmokeTemAverage] = " + (unit.HH_SmokeTemAverage == null ? "''" : "'" + unit.HH_SmokeTemAverage.Replace("'", "''") + "'")
                    + " , [HH_CompressionPressNO1] = " + (unit.HH_CompressionPressNO1 == null ? "''" : "'" + unit.HH_CompressionPressNO1.Replace("'", "''") + "'")
                    + " , [HH_CompressionPressNO2] = " + (unit.HH_CompressionPressNO2 == null ? "''" : "'" + unit.HH_CompressionPressNO2.Replace("'", "''") + "'")
                    + " , [HH_CompressionPressNO3] = " + (unit.HH_CompressionPressNO3 == null ? "''" : "'" + unit.HH_CompressionPressNO3.Replace("'", "''") + "'")
                    + " , [HH_CompressionPressNO4] = " + (unit.HH_CompressionPressNO4 == null ? "''" : "'" + unit.HH_CompressionPressNO4.Replace("'", "''") + "'")
                    + " , [HH_CompressionPressNO5] = " + (unit.HH_CompressionPressNO5 == null ? "''" : "'" + unit.HH_CompressionPressNO5.Replace("'", "''") + "'")
                    + " , [HH_CompressionPressNO6] = " + (unit.HH_CompressionPressNO6 == null ? "''" : "'" + unit.HH_CompressionPressNO6.Replace("'", "''") + "'")
                    + " , [HH_CompressionPressNO7] = " + (unit.HH_CompressionPressNO7 == null ? "''" : "'" + unit.HH_CompressionPressNO7.Replace("'", "''") + "'")
                    + " , [HH_CompressionPressNO8] = " + (unit.HH_CompressionPressNO8 == null ? "''" : "'" + unit.HH_CompressionPressNO8.Replace("'", "''") + "'")
                    + " , [HH_CompressionPressAverage] = " + (unit.HH_CompressionPressAverage == null ? "''" : "'" + unit.HH_CompressionPressAverage.Replace("'", "''") + "'")
                    + " , [HH_BoomPressNO1] = " + (unit.HH_BoomPressNO1 == null ? "''" : "'" + unit.HH_BoomPressNO1.Replace("'", "''") + "'")
                    + " , [HH_BoomPressNO2] = " + (unit.HH_BoomPressNO2 == null ? "''" : "'" + unit.HH_BoomPressNO2.Replace("'", "''") + "'")
                    + " , [HH_BoomPressNO3] = " + (unit.HH_BoomPressNO3 == null ? "''" : "'" + unit.HH_BoomPressNO3.Replace("'", "''") + "'")
                    + " , [HH_BoomPressNO4] = " + (unit.HH_BoomPressNO4 == null ? "''" : "'" + unit.HH_BoomPressNO4.Replace("'", "''") + "'")
                    + " , [HH_BoomPressNO5] = " + (unit.HH_BoomPressNO5 == null ? "''" : "'" + unit.HH_BoomPressNO5.Replace("'", "''") + "'")
                    + " , [HH_BoomPressNO6] = " + (unit.HH_BoomPressNO6 == null ? "''" : "'" + unit.HH_BoomPressNO6.Replace("'", "''") + "'")
                    + " , [HH_BoomPressNO7] = " + (unit.HH_BoomPressNO7 == null ? "''" : "'" + unit.HH_BoomPressNO7.Replace("'", "''") + "'")
                    + " , [HH_BoomPressNO8] = " + (unit.HH_BoomPressNO8 == null ? "''" : "'" + unit.HH_BoomPressNO8.Replace("'", "''") + "'")
                    + " , [HH_BoomPressAverage] = " + (unit.HH_BoomPressAverage == null ? "''" : "'" + unit.HH_BoomPressAverage.Replace("'", "''") + "'")
                    + " , [HH_MeasureDate] = " + dbOperation.DbToDate(unit.HH_MeasureDate)
                    + " , [HH_Model] = " + (unit.HH_Model == null ? "''" : "'" + unit.HH_Model.Replace("'", "''") + "'")
                    + " , [HH_Load] = " + (unit.HH_Load == null ? "''" : "'" + unit.HH_Load.Replace("'", "''") + "'")
                    + " , [HH_SeaArea] = " + (unit.HH_SeaArea == null ? "''" : "'" + unit.HH_SeaArea.Replace("'", "''") + "'")
                    + " , [HH_Wind] = " + (unit.HH_Wind == null ? "''" : "'" + unit.HH_Wind.Replace("'", "''") + "'")
                    + " , [HH_Wave] = " + (unit.HH_Wave == null ? "''" : "'" + unit.HH_Wave.Replace("'", "''") + "'")
                    + " , [HH_BowDraft] = " + (unit.HH_BowDraft == null ? "''" : "'" + unit.HH_BowDraft.Replace("'", "''") + "'")
                    + " , [HH_PoopDraft] = " + (unit.HH_PoopDraft == null ? "''" : "'" + unit.HH_PoopDraft.Replace("'", "''") + "'")
                    + " , [HH_FireSequence] = " + (unit.HH_FireSequence == null ? "''" : "'" + unit.HH_FireSequence.Replace("'", "''") + "'")
                    + " , [HH_FuelSpecification] = " + (unit.HH_FuelSpecification == null ? "''" : "'" + unit.HH_FuelSpecification.Replace("'", "''") + "'")
                    + " , [HH_DailyConsumption] = " + (unit.HH_DailyConsumption == null ? "''" : "'" + unit.HH_DailyConsumption.Replace("'", "''") + "'")
                    + " , [HH_CylinderConstant] = " + (unit.HH_CylinderConstant == null ? "''" : "'" + unit.HH_CylinderConstant.Replace("'", "''") + "'")
                    + " , [HH_TotalKW] = " + (unit.HH_TotalKW == null ? "''" : "'" + unit.HH_TotalKW.Replace("'", "''") + "'")
                    + " , [HH_TotalRatedPower] = " + (unit.HH_TotalRatedPower == null ? "''" : "'" + unit.HH_TotalRatedPower.Replace("'", "''") + "'")
                    + " , [HH_TotalPower] = " + (unit.HH_TotalPower == null ? "''" : "'" + unit.HH_TotalPower.Replace("'", "''") + "'")
                    + " , [HH_Speed] = " + (unit.HH_Speed == null ? "''" : "'" + unit.HH_Speed.Replace("'", "''") + "'")
                    + " , [HH_SlipRate] = " + (unit.HH_SlipRate == null ? "''" : "'" + unit.HH_SlipRate.Replace("'", "''") + "'")
                    + " , [HH_MaxExhaustTempDifference] = " + (unit.HH_MaxExhaustTempDifference == null ? "''" : "'" + unit.HH_MaxExhaustTempDifference.Replace("'", "''") + "'")
                    + " , [HH_MaxCompressionPressDifference] = " + (unit.HH_MaxCompressionPressDifference == null ? "''" : "'" + unit.HH_MaxCompressionPressDifference.Replace("'", "''") + "'")
                    + " , [HH_DetonationPressDifference] = " + (unit.HH_DetonationPressDifference == null ? "''" : "'" + unit.HH_DetonationPressDifference.Replace("'", "''") + "'")
                    + " , [HH_FuelInTem] = " + (unit.HH_FuelInTem == null ? "''" : "'" + unit.HH_FuelInTem.Replace("'", "''") + "'")
                    + " , [HH_FuelInViscosity] = " + (unit.HH_FuelInViscosity == null ? "''" : "'" + unit.HH_FuelInViscosity.Replace("'", "''") + "'")
                    + " , [HH_Remarks] = " + (unit.HH_Remarks == null ? "''" : "'" + unit.HH_Remarks.Replace("'", "''") + "'")
                    + " , [HH_ChiefSign] = " + (unit.HH_ChiefSign == null ? "''" : "'" + unit.HH_ChiefSign.Replace("'", "''") + "'")
                    + " , [HH_ChiefSignDate] = " + dbOperation.DbToDate(unit.HH_ChiefSignDate)
                    + " , [HH_DirectorSign] = " + (unit.HH_DirectorSign == null ? "''" : "'" + unit.HH_DirectorSign.Replace("'", "''") + "'")
                    + " , [HH_DirectorSignDate] = " + dbOperation.DbToDate(unit.HH_DirectorSignDate)
                    + " where upper(Report_ShipHost_Id) = '" + unit.Report_ShipHost_Id.ToUpper() + "'";
            }
            else
            {
                unit.Report_ShipHost_Id = Guid.NewGuid().ToString();
                sql2 = "INSERT INTO [T_REPORT_SHIPHOST] ("
                    + "[Report_ShipHost_Id],"
                    + "[SHIP_ID],"
                    + "[File_ID],"
                    + "[Voyage],"
                    + "[TableWritedDate],"
                    + "[Host_ParaAbstractedDate],"
                    + "[Host_RecordDate],"
                    + "[Host_Speed],"
                    + "[Host_LoadInstruction],"
                    + "[Host_SmokeHign_Tem],"
                    + "[Host_SmokeHign_CylinderNO],"
                    + "[Host_SmokeLow_Tem],"
                    + "[Host_SmokeLow_CylinderNO],"
                    + "[Host_LinerCoolWaterIn_Tem],"
                    + "[Host_LinerCoolWaterOut_Tem],"
                    + "[Host_PistonCoolantIn_Tem],"
                    + "[Host_PistonCoolanOut_Tem],"
                    + "[Host_CoolerBeforeNO1_Tem],"
                    + "[Host_CoolerBeforeNO2_Tem],"
                    + "[Host_CoolerBeforeNO3_Tem],"
                    + "[Host_CoolerAfterNO1_Tem],"
                    + "[Host_CoolerAfterNO2_Tem],"
                    + "[Host_CoolerAfterNO3_Tem],"
                    + "[Host_SternTube_Tem],"
                    + "[Host_Cabin_Tem],"
                    + "[Host_SeaWater_Tem],"
                    + "[Host_CoolWaterHigh_MPa],"
                    + "[Host_CoolWaterLow_MPa],"
                    + "[Host_OilMain_Mpa],"
                    + "[Host_OilCrosshead_Mpa],"
                    + "[Host_PressurizedAir_Mpa],"
                    + "[Host_FuelInto_Mpa],"
                    + "[Host_ActualSpeed],"
                    + "[Host_LossRate],"
                    + "[Host_TurbochargerSpeedNO1],"
                    + "[Host_TurbochargerSpeedNO2],"
                    + "[HH_HighPumpNO1],"
                    + "[HH_HighPumpNO2],"
                    + "[HH_HighPumpNO3],"
                    + "[HH_HighPumpNO4],"
                    + "[HH_HighPumpNO5],"
                    + "[HH_HighPumpNO6],"
                    + "[HH_HighPumpNO7],"
                    + "[HH_HighPumpNO8],"
                    + "[HH_HighPumpAverage],"
                    + "[HH_VITNO1],"
                    + "[HH_VITNO2],"
                    + "[HH_VITNO3],"
                    + "[HH_VITNO4],"
                    + "[HH_VITNO5],"
                    + "[HH_VITNO6],"
                    + "[HH_VITNO7],"
                    + "[HH_VITNO8],"
                    + "[HH_VITAverage],"
                    + "[HH_SmokeTemNO1],"
                    + "[HH_SmokeTemNO2],"
                    + "[HH_SmokeTemNO3],"
                    + "[HH_SmokeTemNO4],"
                    + "[HH_SmokeTemNO5],"
                    + "[HH_SmokeTemNO6],"
                    + "[HH_SmokeTemNO7],"
                    + "[HH_SmokeTemNO8],"
                    + "[HH_SmokeTemAverage],"
                    + "[HH_CompressionPressNO1],"
                    + "[HH_CompressionPressNO2],"
                    + "[HH_CompressionPressNO3],"
                    + "[HH_CompressionPressNO4],"
                    + "[HH_CompressionPressNO5],"
                    + "[HH_CompressionPressNO6],"
                    + "[HH_CompressionPressNO7],"
                    + "[HH_CompressionPressNO8],"
                    + "[HH_CompressionPressAverage],"
                    + "[HH_BoomPressNO1],"
                    + "[HH_BoomPressNO2],"
                    + "[HH_BoomPressNO3],"
                    + "[HH_BoomPressNO4],"
                    + "[HH_BoomPressNO5],"
                    + "[HH_BoomPressNO6],"
                    + "[HH_BoomPressNO7],"
                    + "[HH_BoomPressNO8],"
                    + "[HH_BoomPressAverage],"
                    + "[HH_MeasureDate],"
                    + "[HH_Model],"
                    + "[HH_Load],"
                    + "[HH_SeaArea],"
                    + "[HH_Wind],"
                    + "[HH_Wave],"
                    + "[HH_BowDraft],"
                    + "[HH_PoopDraft],"
                    + "[HH_FireSequence],"
                    + "[HH_FuelSpecification],"
                    + "[HH_DailyConsumption],"
                    + "[HH_CylinderConstant],"
                    + "[HH_TotalKW],"
                    + "[HH_TotalRatedPower],"
                    + "[HH_TotalPower],"
                    + "[HH_Speed],"
                    + "[HH_SlipRate],"
                    + "[HH_MaxExhaustTempDifference],"
                    + "[HH_MaxCompressionPressDifference],"
                    + "[HH_DetonationPressDifference],"
                    + "[HH_FuelInTem],"
                    + "[HH_FuelInViscosity],"
                    + "[HH_Remarks],"
                    + "[HH_ChiefSign],"
                    + "[HH_ChiefSignDate],"
                    + "[HH_DirectorSign],"
                    + "[HH_DirectorSignDate]"
                    + ") VALUES( "
                    + " " + (unit.Report_ShipHost_Id == null ? "''" : "'" + unit.Report_ShipHost_Id.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.File_ID) ? "null" : "'" + unit.File_ID.Replace("'", "''") + "'")
                    + " , " + (unit.Voyage == null ? "''" : "'" + unit.Voyage.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.TableWritedDate)
                    + " ," + dbOperation.DbToDate(unit.Host_ParaAbstractedDate)
                    + " ," + dbOperation.DbToDate(unit.Host_RecordDate)
                    + " , " + (unit.Host_Speed == null ? "''" : "'" + unit.Host_Speed.Replace("'", "''") + "'")
                    + " , " + (unit.Host_LoadInstruction == null ? "''" : "'" + unit.Host_LoadInstruction.Replace("'", "''") + "'")
                    + " , " + (unit.Host_SmokeHign_Tem == null ? "''" : "'" + unit.Host_SmokeHign_Tem.Replace("'", "''") + "'")
                    + " , " + (unit.Host_SmokeHign_CylinderNO == null ? "''" : "'" + unit.Host_SmokeHign_CylinderNO.Replace("'", "''") + "'")
                    + " , " + (unit.Host_SmokeLow_Tem == null ? "''" : "'" + unit.Host_SmokeLow_Tem.Replace("'", "''") + "'")
                    + " , " + (unit.Host_SmokeLow_CylinderNO == null ? "''" : "'" + unit.Host_SmokeLow_CylinderNO.Replace("'", "''") + "'")
                    + " , " + (unit.Host_LinerCoolWaterIn_Tem == null ? "''" : "'" + unit.Host_LinerCoolWaterIn_Tem.Replace("'", "''") + "'")
                    + " , " + (unit.Host_LinerCoolWaterOut_Tem == null ? "''" : "'" + unit.Host_LinerCoolWaterOut_Tem.Replace("'", "''") + "'")
                    + " , " + (unit.Host_PistonCoolantIn_Tem == null ? "''" : "'" + unit.Host_PistonCoolantIn_Tem.Replace("'", "''") + "'")
                    + " , " + (unit.Host_PistonCoolanOut_Tem == null ? "''" : "'" + unit.Host_PistonCoolanOut_Tem.Replace("'", "''") + "'")
                    + " , " + (unit.Host_CoolerBeforeNO1_Tem == null ? "''" : "'" + unit.Host_CoolerBeforeNO1_Tem.Replace("'", "''") + "'")
                    + " , " + (unit.Host_CoolerBeforeNO2_Tem == null ? "''" : "'" + unit.Host_CoolerBeforeNO2_Tem.Replace("'", "''") + "'")
                    + " , " + (unit.Host_CoolerBeforeNO3_Tem == null ? "''" : "'" + unit.Host_CoolerBeforeNO3_Tem.Replace("'", "''") + "'")
                    + " , " + (unit.Host_CoolerAfterNO1_Tem == null ? "''" : "'" + unit.Host_CoolerAfterNO1_Tem.Replace("'", "''") + "'")
                    + " , " + (unit.Host_CoolerAfterNO2_Tem == null ? "''" : "'" + unit.Host_CoolerAfterNO2_Tem.Replace("'", "''") + "'")
                    + " , " + (unit.Host_CoolerAfterNO3_Tem == null ? "''" : "'" + unit.Host_CoolerAfterNO3_Tem.Replace("'", "''") + "'")
                    + " , " + (unit.Host_SternTube_Tem == null ? "''" : "'" + unit.Host_SternTube_Tem.Replace("'", "''") + "'")
                    + " , " + (unit.Host_Cabin_Tem == null ? "''" : "'" + unit.Host_Cabin_Tem.Replace("'", "''") + "'")
                    + " , " + (unit.Host_SeaWater_Tem == null ? "''" : "'" + unit.Host_SeaWater_Tem.Replace("'", "''") + "'")
                    + " , " + (unit.Host_CoolWaterHigh_MPa == null ? "''" : "'" + unit.Host_CoolWaterHigh_MPa.Replace("'", "''") + "'")
                    + " , " + (unit.Host_CoolWaterLow_MPa == null ? "''" : "'" + unit.Host_CoolWaterLow_MPa.Replace("'", "''") + "'")
                    + " , " + (unit.Host_OilMain_Mpa == null ? "''" : "'" + unit.Host_OilMain_Mpa.Replace("'", "''") + "'")
                    + " , " + (unit.Host_OilCrosshead_Mpa == null ? "''" : "'" + unit.Host_OilCrosshead_Mpa.Replace("'", "''") + "'")
                    + " , " + (unit.Host_PressurizedAir_Mpa == null ? "''" : "'" + unit.Host_PressurizedAir_Mpa.Replace("'", "''") + "'")
                    + " , " + (unit.Host_FuelInto_Mpa == null ? "''" : "'" + unit.Host_FuelInto_Mpa.Replace("'", "''") + "'")
                    + " , " + (unit.Host_ActualSpeed == null ? "''" : "'" + unit.Host_ActualSpeed.Replace("'", "''") + "'")
                    + " , " + (unit.Host_LossRate == null ? "''" : "'" + unit.Host_LossRate.Replace("'", "''") + "'")
                    + " , " + (unit.Host_TurbochargerSpeedNO1 == null ? "''" : "'" + unit.Host_TurbochargerSpeedNO1.Replace("'", "''") + "'")
                    + " , " + (unit.Host_TurbochargerSpeedNO2 == null ? "''" : "'" + unit.Host_TurbochargerSpeedNO2.Replace("'", "''") + "'")
                    + " , " + (unit.HH_HighPumpNO1 == null ? "''" : "'" + unit.HH_HighPumpNO1.Replace("'", "''") + "'")
                    + " , " + (unit.HH_HighPumpNO2 == null ? "''" : "'" + unit.HH_HighPumpNO2.Replace("'", "''") + "'")
                    + " , " + (unit.HH_HighPumpNO3 == null ? "''" : "'" + unit.HH_HighPumpNO3.Replace("'", "''") + "'")
                    + " , " + (unit.HH_HighPumpNO4 == null ? "''" : "'" + unit.HH_HighPumpNO4.Replace("'", "''") + "'")
                    + " , " + (unit.HH_HighPumpNO5 == null ? "''" : "'" + unit.HH_HighPumpNO5.Replace("'", "''") + "'")
                    + " , " + (unit.HH_HighPumpNO6 == null ? "''" : "'" + unit.HH_HighPumpNO6.Replace("'", "''") + "'")
                    + " , " + (unit.HH_HighPumpNO7 == null ? "''" : "'" + unit.HH_HighPumpNO7.Replace("'", "''") + "'")
                    + " , " + (unit.HH_HighPumpNO8 == null ? "''" : "'" + unit.HH_HighPumpNO8.Replace("'", "''") + "'")
                    + " , " + (unit.HH_HighPumpAverage == null ? "''" : "'" + unit.HH_HighPumpAverage.Replace("'", "''") + "'")
                    + " , " + (unit.HH_VITNO1 == null ? "''" : "'" + unit.HH_VITNO1.Replace("'", "''") + "'")
                    + " , " + (unit.HH_VITNO2 == null ? "''" : "'" + unit.HH_VITNO2.Replace("'", "''") + "'")
                    + " , " + (unit.HH_VITNO3 == null ? "''" : "'" + unit.HH_VITNO3.Replace("'", "''") + "'")
                    + " , " + (unit.HH_VITNO4 == null ? "''" : "'" + unit.HH_VITNO4.Replace("'", "''") + "'")
                    + " , " + (unit.HH_VITNO5 == null ? "''" : "'" + unit.HH_VITNO5.Replace("'", "''") + "'")
                    + " , " + (unit.HH_VITNO6 == null ? "''" : "'" + unit.HH_VITNO6.Replace("'", "''") + "'")
                    + " , " + (unit.HH_VITNO7 == null ? "''" : "'" + unit.HH_VITNO7.Replace("'", "''") + "'")
                    + " , " + (unit.HH_VITNO8 == null ? "''" : "'" + unit.HH_VITNO8.Replace("'", "''") + "'")
                    + " , " + (unit.HH_VITAverage == null ? "''" : "'" + unit.HH_VITAverage.Replace("'", "''") + "'")
                    + " , " + (unit.HH_SmokeTemNO1 == null ? "''" : "'" + unit.HH_SmokeTemNO1.Replace("'", "''") + "'")
                    + " , " + (unit.HH_SmokeTemNO2 == null ? "''" : "'" + unit.HH_SmokeTemNO2.Replace("'", "''") + "'")
                    + " , " + (unit.HH_SmokeTemNO3 == null ? "''" : "'" + unit.HH_SmokeTemNO3.Replace("'", "''") + "'")
                    + " , " + (unit.HH_SmokeTemNO4 == null ? "''" : "'" + unit.HH_SmokeTemNO4.Replace("'", "''") + "'")
                    + " , " + (unit.HH_SmokeTemNO5 == null ? "''" : "'" + unit.HH_SmokeTemNO5.Replace("'", "''") + "'")
                    + " , " + (unit.HH_SmokeTemNO6 == null ? "''" : "'" + unit.HH_SmokeTemNO6.Replace("'", "''") + "'")
                    + " , " + (unit.HH_SmokeTemNO7 == null ? "''" : "'" + unit.HH_SmokeTemNO7.Replace("'", "''") + "'")
                    + " , " + (unit.HH_SmokeTemNO8 == null ? "''" : "'" + unit.HH_SmokeTemNO8.Replace("'", "''") + "'")
                    + " , " + (unit.HH_SmokeTemAverage == null ? "''" : "'" + unit.HH_SmokeTemAverage.Replace("'", "''") + "'")
                    + " , " + (unit.HH_CompressionPressNO1 == null ? "''" : "'" + unit.HH_CompressionPressNO1.Replace("'", "''") + "'")
                    + " , " + (unit.HH_CompressionPressNO2 == null ? "''" : "'" + unit.HH_CompressionPressNO2.Replace("'", "''") + "'")
                    + " , " + (unit.HH_CompressionPressNO3 == null ? "''" : "'" + unit.HH_CompressionPressNO3.Replace("'", "''") + "'")
                    + " , " + (unit.HH_CompressionPressNO4 == null ? "''" : "'" + unit.HH_CompressionPressNO4.Replace("'", "''") + "'")
                    + " , " + (unit.HH_CompressionPressNO5 == null ? "''" : "'" + unit.HH_CompressionPressNO5.Replace("'", "''") + "'")
                    + " , " + (unit.HH_CompressionPressNO6 == null ? "''" : "'" + unit.HH_CompressionPressNO6.Replace("'", "''") + "'")
                    + " , " + (unit.HH_CompressionPressNO7 == null ? "''" : "'" + unit.HH_CompressionPressNO7.Replace("'", "''") + "'")
                    + " , " + (unit.HH_CompressionPressNO8 == null ? "''" : "'" + unit.HH_CompressionPressNO8.Replace("'", "''") + "'")
                    + " , " + (unit.HH_CompressionPressAverage == null ? "''" : "'" + unit.HH_CompressionPressAverage.Replace("'", "''") + "'")
                    + " , " + (unit.HH_BoomPressNO1 == null ? "''" : "'" + unit.HH_BoomPressNO1.Replace("'", "''") + "'")
                    + " , " + (unit.HH_BoomPressNO2 == null ? "''" : "'" + unit.HH_BoomPressNO2.Replace("'", "''") + "'")
                    + " , " + (unit.HH_BoomPressNO3 == null ? "''" : "'" + unit.HH_BoomPressNO3.Replace("'", "''") + "'")
                    + " , " + (unit.HH_BoomPressNO4 == null ? "''" : "'" + unit.HH_BoomPressNO4.Replace("'", "''") + "'")
                    + " , " + (unit.HH_BoomPressNO5 == null ? "''" : "'" + unit.HH_BoomPressNO5.Replace("'", "''") + "'")
                    + " , " + (unit.HH_BoomPressNO6 == null ? "''" : "'" + unit.HH_BoomPressNO6.Replace("'", "''") + "'")
                    + " , " + (unit.HH_BoomPressNO7 == null ? "''" : "'" + unit.HH_BoomPressNO7.Replace("'", "''") + "'")
                    + " , " + (unit.HH_BoomPressNO8 == null ? "''" : "'" + unit.HH_BoomPressNO8.Replace("'", "''") + "'")
                    + " , " + (unit.HH_BoomPressAverage == null ? "''" : "'" + unit.HH_BoomPressAverage.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.HH_MeasureDate)
                    + " , " + (unit.HH_Model == null ? "''" : "'" + unit.HH_Model.Replace("'", "''") + "'")
                    + " , " + (unit.HH_Load == null ? "''" : "'" + unit.HH_Load.Replace("'", "''") + "'")
                    + " , " + (unit.HH_SeaArea == null ? "''" : "'" + unit.HH_SeaArea.Replace("'", "''") + "'")
                    + " , " + (unit.HH_Wind == null ? "''" : "'" + unit.HH_Wind.Replace("'", "''") + "'")
                    + " , " + (unit.HH_Wave == null ? "''" : "'" + unit.HH_Wave.Replace("'", "''") + "'")
                    + " , " + (unit.HH_BowDraft == null ? "''" : "'" + unit.HH_BowDraft.Replace("'", "''") + "'")
                    + " , " + (unit.HH_PoopDraft == null ? "''" : "'" + unit.HH_PoopDraft.Replace("'", "''") + "'")
                    + " , " + (unit.HH_FireSequence == null ? "''" : "'" + unit.HH_FireSequence.Replace("'", "''") + "'")
                    + " , " + (unit.HH_FuelSpecification == null ? "''" : "'" + unit.HH_FuelSpecification.Replace("'", "''") + "'")
                    + " , " + (unit.HH_DailyConsumption == null ? "''" : "'" + unit.HH_DailyConsumption.Replace("'", "''") + "'")
                    + " , " + (unit.HH_CylinderConstant == null ? "''" : "'" + unit.HH_CylinderConstant.Replace("'", "''") + "'")
                    + " , " + (unit.HH_TotalKW == null ? "''" : "'" + unit.HH_TotalKW.Replace("'", "''") + "'")
                    + " , " + (unit.HH_TotalRatedPower == null ? "''" : "'" + unit.HH_TotalRatedPower.Replace("'", "''") + "'")
                    + " , " + (unit.HH_TotalPower == null ? "''" : "'" + unit.HH_TotalPower.Replace("'", "''") + "'")
                    + " , " + (unit.HH_Speed == null ? "''" : "'" + unit.HH_Speed.Replace("'", "''") + "'")
                    + " , " + (unit.HH_SlipRate == null ? "''" : "'" + unit.HH_SlipRate.Replace("'", "''") + "'")
                    + " , " + (unit.HH_MaxExhaustTempDifference == null ? "''" : "'" + unit.HH_MaxExhaustTempDifference.Replace("'", "''") + "'")
                    + " , " + (unit.HH_MaxCompressionPressDifference == null ? "''" : "'" + unit.HH_MaxCompressionPressDifference.Replace("'", "''") + "'")
                    + " , " + (unit.HH_DetonationPressDifference == null ? "''" : "'" + unit.HH_DetonationPressDifference.Replace("'", "''") + "'")
                    + " , " + (unit.HH_FuelInTem == null ? "''" : "'" + unit.HH_FuelInTem.Replace("'", "''") + "'")
                    + " , " + (unit.HH_FuelInViscosity == null ? "''" : "'" + unit.HH_FuelInViscosity.Replace("'", "''") + "'")
                    + " , " + (unit.HH_Remarks == null ? "''" : "'" + unit.HH_Remarks.Replace("'", "''") + "'")
                    + " , " + (unit.HH_ChiefSign == null ? "''" : "'" + unit.HH_ChiefSign.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.HH_ChiefSignDate)
                    + " , " + (unit.HH_DirectorSign == null ? "''" : "'" + unit.HH_DirectorSign.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.HH_DirectorSignDate)
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
