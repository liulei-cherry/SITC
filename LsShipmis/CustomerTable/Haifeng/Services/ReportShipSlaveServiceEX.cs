/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：ReportShipSlaveService.cs
 * 创 建 人：黄家龙
 * 创建时间：2011/8/30
 * 标    题：数据操作类
 * 功能描述：T_REPROT_SHIPSLAVE数据操作类
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

namespace  CustomerTable.Haifeng.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_REPROT_SHIPSLAVEService.cs
    /// </summary>
    public partial class ReportShipSlaveService
    {
		/// 获得 "年月度船舶副机工况参数" 数据.
        /// </summary>
        public DataTable getInfoByYear(string ship_id, DateTime year, out string err)
        {
            sql = " SELECT [Report_ShipSlave_Id]"
                 + " ,[SHIP_ID]"
                 + " ,[File_ID]"
                 + " ,[Voyage]"
                 + " ,[TableWritedDate]"
                 + " ,[Slave_ParaAbstractedDate]"
                 + " ,[Slave_RecordDate]"
                 + " ,[Slave_EditID]"
                 + " ,[Slave_SmokeHignNO]"
                 + " ,[Slave_SmokeHignTem]"
                 + " ,[Slave_SmokeLowNO]"
                 + " ,[Slave_SmokeLowTem]"
                 + " ,[Slave_CoolSystemInTem]"
                 + " ,[Slave_CoolSystemOutTem]"
                 + " ,[Slave_OilinTem]"
                 + " ,[Slave_OilOutTem]"
                 + " ,[Slave_FuelInTem]"
                 + " ,[Slave_PressureAirTem]"
                 + " ,[Slave_CoolWaterHignMPa]"
                 + " ,[Slave_CoolWaterLowMPa]"
                 + " ,[Slave_OilInMpa]"
                 + " ,[Slave_FuelInMpa]"
                 + " ,[Slave_PressureAirMPa]"
                 + " ,[Slave_GeneratorVoltage]"
                 + " ,[Slave_GeneratorCurrent]"
                 + " ,[Slavae_GeneratorKW]";

            sql += " FROM [T_REPROT_SHIPSLAVE]";
            sql += " WHERE UPPER(SHIP_Id)= '" + ship_id.ToUpper() + "'"
                + " and CONVERT(varchar(7),[Slave_RecordDate],102)='" + year.ToString("yyyy.MM") + "'";
            sql += " ORDER BY [Slave_RecordDate] ";

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

            sql = "SELECT [Report_ShipSlave_Id]"
                  + ",[SHIP_ID]"
                  + ",[File_ID]"
                  + ",CONVERT(varchar(10), Slave_RecordDate, 102) as Slave_RecordDate"
                  + " ,[Slave_ParaAbstractedDate]"
                  + " ,[Slave_EditID]"
                  + " ,[Slave_SmokeHignNO]"
                  + " ,[Slave_SmokeHignTem]"
                  + " ,[Slave_SmokeLowNO]"
                  + " ,[Slave_SmokeLowTem]"
                  + " ,[Slave_CoolSystemInTem]"
                  + " ,[Slave_CoolSystemOutTem]"
                  + " ,[Slave_OilinTem]"
                  + " ,[Slave_OilOutTem]"
                  + " ,[Slave_FuelInTem]"
                  + " ,[Slave_PressureAirTem]"
                  + " ,[Slave_CoolWaterHignMPa]"
                  + " ,[Slave_CoolWaterLowMPa]"
                  + " ,[Slave_OilInMpa]"
                  + " ,[Slave_FuelInMpa]"
                  + " ,[Slave_PressureAirMPa]"
                  + " ,[Slave_GeneratorVoltage]"
                  + " ,[Slave_GeneratorCurrent]"
                  + " ,[Slavae_GeneratorKW]";

            sql += " FROM [T_REPROT_SHIPSLAVE]";
            sql += " WHERE  convert(varchar(7),Slave_RecordDate,102)= '" + apply_id + "'";
            sql += " AND upper(SHIP_Id)= '" + shipID.ToUpper() + "' ";
            sql += " order by Slave_RecordDate";

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
        public ReportShipSlave GetMainDetail(string apply_id, string ship_id, out string err)
        {
            DataTable dtreturn;

            sql = "select * "
                + "  from T_REPROT_SHIPSLAVE T";
            sql += " where convert(varchar(10),T.Slave_RecordDate,102)= '" + apply_id + "'";
            sql += "  and  upper(SHIP_Id)= '" + ship_id.ToUpper() + "'";
            sql += " order by T.Slave_RecordDate desc";

            if (!dbAccess.GetDataTable(sql, out dtreturn, out err))
            {
                getObject(null);
                throw new Exception("GetMainDetail occur err:" + err);
            }

            return getObject(dtreturn.Rows[0]);
        }

        /// <summary>
        /// 检查某参数摘录日信息是否已经存在.
        /// </summary>
        /// <param name="apply_id"></param>
        /// <returns></returns>
        public bool CheckSubDetail(string apply_id, string ship_id)
        {
            sql = "select count(1) "
                + "  from T_REPROT_SHIPSLAVE T";
            sql += " where convert(varchar(10),T.Slave_RecordDate,102)= '" + apply_id + "'";
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

        public bool UpdateSomeRecord(string apply_id, string shipID, ReportShipSlave unit)
        {
            string sql2 = "";
            string err = "";    
            List<string> lstSql = new List<string>();

            sql = "UPDATE T_REPROT_SHIPSLAVE"
                    + " SET "
                    + "  [Voyage] = " + (unit.Voyage == null ? "''" : "'" + unit.Voyage.Replace("'", "''") + "'")
                    + " , [TableWritedDate] = " + dbOperation.DbToDate(unit.TableWritedDate)
                    + " , [Slave_ParaAbstractedDate] = " + dbOperation.DbToDate(unit.Slave_ParaAbstractedDate)
                    + " , [SS_DieselNoOne] = " + (unit.SS_DieselNoOne == null ? "''" : "'" + unit.SS_DieselNoOne.Replace("'", "''") + "'")
                    + " , [SS_DieselNoTwo] = " + (unit.SS_DieselNoTwo == null ? "''" : "'" + unit.SS_DieselNoTwo.Replace("'", "''") + "'")
                    + " , [SS_DieselNoOnePressureNO1] = " + (unit.SS_DieselNoOnePressureNO1 == null ? "''" : "'" + unit.SS_DieselNoOnePressureNO1.Replace("'", "''") + "'")
                    + " , [SS_DieselNoOnePressureNO2] = " + (unit.SS_DieselNoOnePressureNO2 == null ? "''" : "'" + unit.SS_DieselNoOnePressureNO2.Replace("'", "''") + "'")
                    + " , [SS_DieselNoOnePressureNO3] = " + (unit.SS_DieselNoOnePressureNO3 == null ? "''" : "'" + unit.SS_DieselNoOnePressureNO3.Replace("'", "''") + "'")
                    + " , [SS_DieselNoOnePressureNO4] = " + (unit.SS_DieselNoOnePressureNO4 == null ? "''" : "'" + unit.SS_DieselNoOnePressureNO4.Replace("'", "''") + "'")
                    + " , [SS_DieselNoOnePressureNO5] = " + (unit.SS_DieselNoOnePressureNO5 == null ? "''" : "'" + unit.SS_DieselNoOnePressureNO5.Replace("'", "''") + "'")
                    + " , [SS_DieselNoOnePressureNO6] = " + (unit.SS_DieselNoOnePressureNO6 == null ? "''" : "'" + unit.SS_DieselNoOnePressureNO6.Replace("'", "''") + "'")
                    + " , [SS_DieselNoOnePressureNO7] = " + (unit.SS_DieselNoOnePressureNO7 == null ? "''" : "'" + unit.SS_DieselNoOnePressureNO7.Replace("'", "''") + "'")
                    + " , [SS_DieselNoOnePressureNO8] = " + (unit.SS_DieselNoOnePressureNO8 == null ? "''" : "'" + unit.SS_DieselNoOnePressureNO8.Replace("'", "''") + "'")
                    + " , [SS_DieselNoOneTemNO1] = " + (unit.SS_DieselNoOneTemNO1 == null ? "''" : "'" + unit.SS_DieselNoOneTemNO1.Replace("'", "''") + "'")
                    + " , [SS_DieselNoOneTemNO2] = " + (unit.SS_DieselNoOneTemNO2 == null ? "''" : "'" + unit.SS_DieselNoOneTemNO2.Replace("'", "''") + "'")
                    + " , [SS_DieselNoOneTemNO3] = " + (unit.SS_DieselNoOneTemNO3 == null ? "''" : "'" + unit.SS_DieselNoOneTemNO3.Replace("'", "''") + "'")
                    + " , [SS_DieselNoOneTemNO4] = " + (unit.SS_DieselNoOneTemNO4 == null ? "''" : "'" + unit.SS_DieselNoOneTemNO4.Replace("'", "''") + "'")
                    + " , [SS_DieselNoOneTemNO5] = " + (unit.SS_DieselNoOneTemNO5 == null ? "''" : "'" + unit.SS_DieselNoOneTemNO5.Replace("'", "''") + "'")
                    + " , [SS_DieselNoOneTemNO6] = " + (unit.SS_DieselNoOneTemNO6 == null ? "''" : "'" + unit.SS_DieselNoOneTemNO6.Replace("'", "''") + "'")
                    + " , [SS_DieselNoOneTemNO7] = " + (unit.SS_DieselNoOneTemNO7 == null ? "''" : "'" + unit.SS_DieselNoOneTemNO7.Replace("'", "''") + "'")
                    + " , [SS_DieselNoOneTemNO8] = " + (unit.SS_DieselNoOneTemNO8 == null ? "''" : "'" + unit.SS_DieselNoOneTemNO8.Replace("'", "''") + "'")
                    + " , [SS_DieselNoTwoPressureNO1] = " + (unit.SS_DieselNoTwoPressureNO1 == null ? "''" : "'" + unit.SS_DieselNoTwoPressureNO1.Replace("'", "''") + "'")
                    + " , [SS_DieselNoTwoPressureNO2] = " + (unit.SS_DieselNoTwoPressureNO2 == null ? "''" : "'" + unit.SS_DieselNoTwoPressureNO2.Replace("'", "''") + "'")
                    + " , [SS_DieselNoTwoPressureNO3] = " + (unit.SS_DieselNoTwoPressureNO3 == null ? "''" : "'" + unit.SS_DieselNoTwoPressureNO3.Replace("'", "''") + "'")
                    + " , [SS_DieselNoTwoPressureNO4] = " + (unit.SS_DieselNoTwoPressureNO4 == null ? "''" : "'" + unit.SS_DieselNoTwoPressureNO4.Replace("'", "''") + "'")
                    + " , [SS_DieselNoTwoPressureNO5] = " + (unit.SS_DieselNoTwoPressureNO5 == null ? "''" : "'" + unit.SS_DieselNoTwoPressureNO5.Replace("'", "''") + "'")
                    + " , [SS_DieselNoTwoPressureNO6] = " + (unit.SS_DieselNoTwoPressureNO6 == null ? "''" : "'" + unit.SS_DieselNoTwoPressureNO6.Replace("'", "''") + "'")
                    + " , [SS_DieselNoTwoPressureNO7] = " + (unit.SS_DieselNoTwoPressureNO7 == null ? "''" : "'" + unit.SS_DieselNoTwoPressureNO7.Replace("'", "''") + "'")
                    + " , [SS_DieselNoTwoPressureNO8] = " + (unit.SS_DieselNoTwoPressureNO8 == null ? "''" : "'" + unit.SS_DieselNoTwoPressureNO8.Replace("'", "''") + "'")
                    + " , [SS_DieselNoTwoTemNO1] = " + (unit.SS_DieselNoTwoTemNO1 == null ? "''" : "'" + unit.SS_DieselNoTwoTemNO1.Replace("'", "''") + "'")
                    + " , [SS_DieselNoTwoTemNO2] = " + (unit.SS_DieselNoTwoTemNO2 == null ? "''" : "'" + unit.SS_DieselNoTwoTemNO2.Replace("'", "''") + "'")
                    + " , [SS_DieselNoTwoTemNO3] = " + (unit.SS_DieselNoTwoTemNO3 == null ? "''" : "'" + unit.SS_DieselNoTwoTemNO3.Replace("'", "''") + "'")
                    + " , [SS_DieselNoTwoTemNO4] = " + (unit.SS_DieselNoTwoTemNO4 == null ? "''" : "'" + unit.SS_DieselNoTwoTemNO4.Replace("'", "''") + "'")
                    + " , [SS_DieselNoTwoTemNO5] = " + (unit.SS_DieselNoTwoTemNO5 == null ? "''" : "'" + unit.SS_DieselNoTwoTemNO5.Replace("'", "''") + "'")
                    + " , [SS_DieselNoTwoTemNO6] = " + (unit.SS_DieselNoTwoTemNO6 == null ? "''" : "'" + unit.SS_DieselNoTwoTemNO6.Replace("'", "''") + "'")
                    + " , [SS_DieselNoTwoTemNO7] = " + (unit.SS_DieselNoTwoTemNO7 == null ? "''" : "'" + unit.SS_DieselNoTwoTemNO7.Replace("'", "''") + "'")
                    + " , [SS_DieselNoTwoTemNO8] = " + (unit.SS_DieselNoTwoTemNO8 == null ? "''" : "'" + unit.SS_DieselNoTwoTemNO8.Replace("'", "''") + "'")
                    + " , [SS_DieselFuelSpecifation] = " + (unit.SS_DieselFuelSpecifation == null ? "''" : "'" + unit.SS_DieselFuelSpecifation.Replace("'", "''") + "'")
                    + " , [SS_SDieselFuelConsumption1] = " + (unit.SS_SDieselFuelConsumption1 == null ? "''" : "'" + unit.SS_SDieselFuelConsumption1.Replace("'", "''") + "'")
                    + " , [SS_SDieselFuelConsumption2] = " + (unit.SS_SDieselFuelConsumption2 == null ? "''" : "'" + unit.SS_SDieselFuelConsumption2.Replace("'", "''") + "'")
                    + " , [SS_SDieselFuelConsumption3] = " + (unit.SS_SDieselFuelConsumption3 == null ? "''" : "'" + unit.SS_SDieselFuelConsumption3.Replace("'", "''") + "'")
                    + " , [SS_SDieselFuelConsumption4] = " + (unit.SS_SDieselFuelConsumption4 == null ? "''" : "'" + unit.SS_SDieselFuelConsumption4.Replace("'", "''") + "'")
                    + " , [Slave_SecondChiefSign] = " + (unit.Slave_SecondChiefSign == null ? "''" : "'" + unit.Slave_SecondChiefSign.Replace("'", "''") + "'")
                    + " , [Slave_SecondChiefSignDate] = " + dbOperation.DbToDate(unit.Slave_SecondChiefSignDate)
                    + " , [Slave_ChiefSign] = " + (unit.Slave_ChiefSign == null ? "''" : "'" + unit.Slave_ChiefSign.Replace("'", "''") + "'")
                    + " , [Slave_ChiefSignDate] = " + dbOperation.DbToDate(unit.Slave_ChiefSignDate)
                    + " , [Slave_DirectorSign] = " + (unit.Slave_DirectorSign == null ? "''" : "'" + unit.Slave_DirectorSign.Replace("'", "''") + "'")
                    + " , [Slave_DirectorSignDate] = " + dbOperation.DbToDate(unit.Slave_DirectorSignDate);

            if (unit.Report_ShipSlave_Id != null && unit.Report_ShipSlave_Id.Length > 0) //edit
            {
                sql2 = "UPDATE [T_REPROT_SHIPSLAVE] SET "
                    + " [Report_ShipSlave_Id] = " + (unit.Report_ShipSlave_Id == null ? "''" : "'" + unit.Report_ShipSlave_Id.Replace("'", "''") + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , [File_ID] = " + (string.IsNullOrEmpty(unit.File_ID) ? "null" : "'" + unit.File_ID.Replace("'", "''") + "'")
                    + " , [Voyage] = " + (unit.Voyage == null ? "''" : "'" + unit.Voyage.Replace("'", "''") + "'")
                    + " , [TableWritedDate] = " + dbOperation.DbToDate(unit.TableWritedDate)
                    + " , [Slave_ParaAbstractedDate] = " + dbOperation.DbToDate(unit.Slave_ParaAbstractedDate)
                    + " , [Slave_RecordDate] = " + dbOperation.DbToDate(unit.Slave_RecordDate)
                    + " , [Slave_EditID] = " + (string.IsNullOrEmpty(unit.Slave_EditID) ? "null" : "'" + unit.Slave_EditID.Replace("'", "''") + "'")
                    + " , [Slave_SmokeHignNO] = " + (unit.Slave_SmokeHignNO == null ? "''" : "'" + unit.Slave_SmokeHignNO.Replace("'", "''") + "'")
                    + " , [Slave_SmokeHignTem] = " + (unit.Slave_SmokeHignTem == null ? "''" : "'" + unit.Slave_SmokeHignTem.Replace("'", "''") + "'")
                    + " , [Slave_SmokeLowNO] = " + (unit.Slave_SmokeLowNO == null ? "''" : "'" + unit.Slave_SmokeLowNO.Replace("'", "''") + "'")
                    + " , [Slave_SmokeLowTem] = " + (unit.Slave_SmokeLowTem == null ? "''" : "'" + unit.Slave_SmokeLowTem.Replace("'", "''") + "'")
                    + " , [Slave_CoolSystemInTem] = " + (unit.Slave_CoolSystemInTem == null ? "''" : "'" + unit.Slave_CoolSystemInTem.Replace("'", "''") + "'")
                    + " , [Slave_CoolSystemOutTem] = " + (unit.Slave_CoolSystemOutTem == null ? "''" : "'" + unit.Slave_CoolSystemOutTem.Replace("'", "''") + "'")
                    + " , [Slave_OilinTem] = " + (unit.Slave_OilinTem == null ? "''" : "'" + unit.Slave_OilinTem.Replace("'", "''") + "'")
                    + " , [Slave_OilOutTem] = " + (unit.Slave_OilOutTem == null ? "''" : "'" + unit.Slave_OilOutTem.Replace("'", "''") + "'")
                    + " , [Slave_FuelInTem] = " + (unit.Slave_FuelInTem == null ? "''" : "'" + unit.Slave_FuelInTem.Replace("'", "''") + "'")
                    + " , [Slave_PressureAirTem] = " + (unit.Slave_PressureAirTem == null ? "''" : "'" + unit.Slave_PressureAirTem.Replace("'", "''") + "'")
                    + " , [Slave_CoolWaterHignMPa] = " + (unit.Slave_CoolWaterHignMPa == null ? "''" : "'" + unit.Slave_CoolWaterHignMPa.Replace("'", "''") + "'")
                    + " , [Slave_CoolWaterLowMPa] = " + (unit.Slave_CoolWaterLowMPa == null ? "''" : "'" + unit.Slave_CoolWaterLowMPa.Replace("'", "''") + "'")
                    + " , [Slave_OilInMpa] = " + (unit.Slave_OilInMpa == null ? "''" : "'" + unit.Slave_OilInMpa.Replace("'", "''") + "'")
                    + " , [Slave_FuelInMpa] = " + (unit.Slave_FuelInMpa == null ? "''" : "'" + unit.Slave_FuelInMpa.Replace("'", "''") + "'")
                    + " , [Slave_PressureAirMPa] = " + (unit.Slave_PressureAirMPa == null ? "''" : "'" + unit.Slave_PressureAirMPa.Replace("'", "''") + "'")
                    + " , [Slave_GeneratorVoltage] = " + (unit.Slave_GeneratorVoltage == null ? "''" : "'" + unit.Slave_GeneratorVoltage.Replace("'", "''") + "'")
                    + " , [Slave_GeneratorCurrent] = " + (unit.Slave_GeneratorCurrent == null ? "''" : "'" + unit.Slave_GeneratorCurrent.Replace("'", "''") + "'")
                    + " , [Slavae_GeneratorKW] = " + (unit.Slavae_GeneratorKW == null ? "''" : "'" + unit.Slavae_GeneratorKW.Replace("'", "''") + "'")
                    + " , [SS_DieselNoOne] = " + (unit.SS_DieselNoOne == null ? "''" : "'" + unit.SS_DieselNoOne.Replace("'", "''") + "'")
                    + " , [SS_DieselNoTwo] = " + (unit.SS_DieselNoTwo == null ? "''" : "'" + unit.SS_DieselNoTwo.Replace("'", "''") + "'")
                    + " , [SS_DieselNoOnePressureNO1] = " + (unit.SS_DieselNoOnePressureNO1 == null ? "''" : "'" + unit.SS_DieselNoOnePressureNO1.Replace("'", "''") + "'")
                    + " , [SS_DieselNoOnePressureNO2] = " + (unit.SS_DieselNoOnePressureNO2 == null ? "''" : "'" + unit.SS_DieselNoOnePressureNO2.Replace("'", "''") + "'")
                    + " , [SS_DieselNoOnePressureNO3] = " + (unit.SS_DieselNoOnePressureNO3 == null ? "''" : "'" + unit.SS_DieselNoOnePressureNO3.Replace("'", "''") + "'")
                    + " , [SS_DieselNoOnePressureNO4] = " + (unit.SS_DieselNoOnePressureNO4 == null ? "''" : "'" + unit.SS_DieselNoOnePressureNO4.Replace("'", "''") + "'")
                    + " , [SS_DieselNoOnePressureNO5] = " + (unit.SS_DieselNoOnePressureNO5 == null ? "''" : "'" + unit.SS_DieselNoOnePressureNO5.Replace("'", "''") + "'")
                    + " , [SS_DieselNoOnePressureNO6] = " + (unit.SS_DieselNoOnePressureNO6 == null ? "''" : "'" + unit.SS_DieselNoOnePressureNO6.Replace("'", "''") + "'")
                    + " , [SS_DieselNoOnePressureNO7] = " + (unit.SS_DieselNoOnePressureNO7 == null ? "''" : "'" + unit.SS_DieselNoOnePressureNO7.Replace("'", "''") + "'")
                    + " , [SS_DieselNoOnePressureNO8] = " + (unit.SS_DieselNoOnePressureNO8 == null ? "''" : "'" + unit.SS_DieselNoOnePressureNO8.Replace("'", "''") + "'")
                    + " , [SS_DieselNoOneTemNO1] = " + (unit.SS_DieselNoOneTemNO1 == null ? "''" : "'" + unit.SS_DieselNoOneTemNO1.Replace("'", "''") + "'")
                    + " , [SS_DieselNoOneTemNO2] = " + (unit.SS_DieselNoOneTemNO2 == null ? "''" : "'" + unit.SS_DieselNoOneTemNO2.Replace("'", "''") + "'")
                    + " , [SS_DieselNoOneTemNO3] = " + (unit.SS_DieselNoOneTemNO3 == null ? "''" : "'" + unit.SS_DieselNoOneTemNO3.Replace("'", "''") + "'")
                    + " , [SS_DieselNoOneTemNO4] = " + (unit.SS_DieselNoOneTemNO4 == null ? "''" : "'" + unit.SS_DieselNoOneTemNO4.Replace("'", "''") + "'")
                    + " , [SS_DieselNoOneTemNO5] = " + (unit.SS_DieselNoOneTemNO5 == null ? "''" : "'" + unit.SS_DieselNoOneTemNO5.Replace("'", "''") + "'")
                    + " , [SS_DieselNoOneTemNO6] = " + (unit.SS_DieselNoOneTemNO6 == null ? "''" : "'" + unit.SS_DieselNoOneTemNO6.Replace("'", "''") + "'")
                    + " , [SS_DieselNoOneTemNO7] = " + (unit.SS_DieselNoOneTemNO7 == null ? "''" : "'" + unit.SS_DieselNoOneTemNO7.Replace("'", "''") + "'")
                    + " , [SS_DieselNoOneTemNO8] = " + (unit.SS_DieselNoOneTemNO8 == null ? "''" : "'" + unit.SS_DieselNoOneTemNO8.Replace("'", "''") + "'")
                    + " , [SS_DieselNoTwoPressureNO1] = " + (unit.SS_DieselNoTwoPressureNO1 == null ? "''" : "'" + unit.SS_DieselNoTwoPressureNO1.Replace("'", "''") + "'")
                    + " , [SS_DieselNoTwoPressureNO2] = " + (unit.SS_DieselNoTwoPressureNO2 == null ? "''" : "'" + unit.SS_DieselNoTwoPressureNO2.Replace("'", "''") + "'")
                    + " , [SS_DieselNoTwoPressureNO3] = " + (unit.SS_DieselNoTwoPressureNO3 == null ? "''" : "'" + unit.SS_DieselNoTwoPressureNO3.Replace("'", "''") + "'")
                    + " , [SS_DieselNoTwoPressureNO4] = " + (unit.SS_DieselNoTwoPressureNO4 == null ? "''" : "'" + unit.SS_DieselNoTwoPressureNO4.Replace("'", "''") + "'")
                    + " , [SS_DieselNoTwoPressureNO5] = " + (unit.SS_DieselNoTwoPressureNO5 == null ? "''" : "'" + unit.SS_DieselNoTwoPressureNO5.Replace("'", "''") + "'")
                    + " , [SS_DieselNoTwoPressureNO6] = " + (unit.SS_DieselNoTwoPressureNO6 == null ? "''" : "'" + unit.SS_DieselNoTwoPressureNO6.Replace("'", "''") + "'")
                    + " , [SS_DieselNoTwoPressureNO7] = " + (unit.SS_DieselNoTwoPressureNO7 == null ? "''" : "'" + unit.SS_DieselNoTwoPressureNO7.Replace("'", "''") + "'")
                    + " , [SS_DieselNoTwoPressureNO8] = " + (unit.SS_DieselNoTwoPressureNO8 == null ? "''" : "'" + unit.SS_DieselNoTwoPressureNO8.Replace("'", "''") + "'")
                    + " , [SS_DieselNoTwoTemNO1] = " + (unit.SS_DieselNoTwoTemNO1 == null ? "''" : "'" + unit.SS_DieselNoTwoTemNO1.Replace("'", "''") + "'")
                    + " , [SS_DieselNoTwoTemNO2] = " + (unit.SS_DieselNoTwoTemNO2 == null ? "''" : "'" + unit.SS_DieselNoTwoTemNO2.Replace("'", "''") + "'")
                    + " , [SS_DieselNoTwoTemNO3] = " + (unit.SS_DieselNoTwoTemNO3 == null ? "''" : "'" + unit.SS_DieselNoTwoTemNO3.Replace("'", "''") + "'")
                    + " , [SS_DieselNoTwoTemNO4] = " + (unit.SS_DieselNoTwoTemNO4 == null ? "''" : "'" + unit.SS_DieselNoTwoTemNO4.Replace("'", "''") + "'")
                    + " , [SS_DieselNoTwoTemNO5] = " + (unit.SS_DieselNoTwoTemNO5 == null ? "''" : "'" + unit.SS_DieselNoTwoTemNO5.Replace("'", "''") + "'")
                    + " , [SS_DieselNoTwoTemNO6] = " + (unit.SS_DieselNoTwoTemNO6 == null ? "''" : "'" + unit.SS_DieselNoTwoTemNO6.Replace("'", "''") + "'")
                    + " , [SS_DieselNoTwoTemNO7] = " + (unit.SS_DieselNoTwoTemNO7 == null ? "''" : "'" + unit.SS_DieselNoTwoTemNO7.Replace("'", "''") + "'")
                    + " , [SS_DieselNoTwoTemNO8] = " + (unit.SS_DieselNoTwoTemNO8 == null ? "''" : "'" + unit.SS_DieselNoTwoTemNO8.Replace("'", "''") + "'")
                    + " , [SS_DieselFuelSpecifation] = " + (unit.SS_DieselFuelSpecifation == null ? "''" : "'" + unit.SS_DieselFuelSpecifation.Replace("'", "''") + "'")
                    + " , [SS_SDieselFuelConsumption1] = " + (unit.SS_SDieselFuelConsumption1 == null ? "''" : "'" + unit.SS_SDieselFuelConsumption1.Replace("'", "''") + "'")
                    + " , [SS_SDieselFuelConsumption2] = " + (unit.SS_SDieselFuelConsumption2 == null ? "''" : "'" + unit.SS_SDieselFuelConsumption2.Replace("'", "''") + "'")
                    + " , [SS_SDieselFuelConsumption3] = " + (unit.SS_SDieselFuelConsumption3 == null ? "''" : "'" + unit.SS_SDieselFuelConsumption3.Replace("'", "''") + "'")
                    + " , [SS_SDieselFuelConsumption4] = " + (unit.SS_SDieselFuelConsumption4 == null ? "''" : "'" + unit.SS_SDieselFuelConsumption4.Replace("'", "''") + "'")
                    + " , [Slave_SecondChiefSign] = " + (unit.Slave_SecondChiefSign == null ? "''" : "'" + unit.Slave_SecondChiefSign.Replace("'", "''") + "'")
                    + " , [Slave_SecondChiefSignDate] = " + dbOperation.DbToDate(unit.Slave_SecondChiefSignDate)
                    + " , [Slave_ChiefSign] = " + (unit.Slave_ChiefSign == null ? "''" : "'" + unit.Slave_ChiefSign.Replace("'", "''") + "'")
                    + " , [Slave_ChiefSignDate] = " + dbOperation.DbToDate(unit.Slave_ChiefSignDate)
                    + " , [Slave_DirectorSign] = " + (unit.Slave_DirectorSign == null ? "''" : "'" + unit.Slave_DirectorSign.Replace("'", "''") + "'")
                    + " , [Slave_DirectorSignDate] = " + dbOperation.DbToDate(unit.Slave_DirectorSignDate)
                    + " where upper(Report_ShipSlave_Id) = '" + unit.Report_ShipSlave_Id.ToUpper() + "'";
            }
            else
            {
                unit.Report_ShipSlave_Id = Guid.NewGuid().ToString();
                sql2 = "INSERT INTO [T_REPROT_SHIPSLAVE] ("
                    + "[Report_ShipSlave_Id],"
                    + "[SHIP_ID],"
                    + "[File_ID],"
                    + "[Voyage],"
                    + "[TableWritedDate],"
                    + "[Slave_ParaAbstractedDate],"
                    + "[Slave_RecordDate],"
                    + "[Slave_EditID],"
                    + "[Slave_SmokeHignNO],"
                    + "[Slave_SmokeHignTem],"
                    + "[Slave_SmokeLowNO],"
                    + "[Slave_SmokeLowTem],"
                    + "[Slave_CoolSystemInTem],"
                    + "[Slave_CoolSystemOutTem],"
                    + "[Slave_OilinTem],"
                    + "[Slave_OilOutTem],"
                    + "[Slave_FuelInTem],"
                    + "[Slave_PressureAirTem],"
                    + "[Slave_CoolWaterHignMPa],"
                    + "[Slave_CoolWaterLowMPa],"
                    + "[Slave_OilInMpa],"
                    + "[Slave_FuelInMpa],"
                    + "[Slave_PressureAirMPa],"
                    + "[Slave_GeneratorVoltage],"
                    + "[Slave_GeneratorCurrent],"
                    + "[Slavae_GeneratorKW],"
                    + "[SS_DieselNoOne],"
                    + "[SS_DieselNoTwo],"
                    + "[SS_DieselNoOnePressureNO1],"
                    + "[SS_DieselNoOnePressureNO2],"
                    + "[SS_DieselNoOnePressureNO3],"
                    + "[SS_DieselNoOnePressureNO4],"
                    + "[SS_DieselNoOnePressureNO5],"
                    + "[SS_DieselNoOnePressureNO6],"
                    + "[SS_DieselNoOnePressureNO7],"
                    + "[SS_DieselNoOnePressureNO8],"
                    + "[SS_DieselNoOneTemNO1],"
                    + "[SS_DieselNoOneTemNO2],"
                    + "[SS_DieselNoOneTemNO3],"
                    + "[SS_DieselNoOneTemNO4],"
                    + "[SS_DieselNoOneTemNO5],"
                    + "[SS_DieselNoOneTemNO6],"
                    + "[SS_DieselNoOneTemNO7],"
                    + "[SS_DieselNoOneTemNO8],"
                    + "[SS_DieselNoTwoPressureNO1],"
                    + "[SS_DieselNoTwoPressureNO2],"
                    + "[SS_DieselNoTwoPressureNO3],"
                    + "[SS_DieselNoTwoPressureNO4],"
                    + "[SS_DieselNoTwoPressureNO5],"
                    + "[SS_DieselNoTwoPressureNO6],"
                    + "[SS_DieselNoTwoPressureNO7],"
                    + "[SS_DieselNoTwoPressureNO8],"
                    + "[SS_DieselNoTwoTemNO1],"
                    + "[SS_DieselNoTwoTemNO2],"
                    + "[SS_DieselNoTwoTemNO3],"
                    + "[SS_DieselNoTwoTemNO4],"
                    + "[SS_DieselNoTwoTemNO5],"
                    + "[SS_DieselNoTwoTemNO6],"
                    + "[SS_DieselNoTwoTemNO7],"
                    + "[SS_DieselNoTwoTemNO8],"
                    + "[SS_DieselFuelSpecifation],"
                    + "[SS_SDieselFuelConsumption1],"
                    + "[SS_SDieselFuelConsumption2],"
                    + "[SS_SDieselFuelConsumption3],"
                    + "[SS_SDieselFuelConsumption4],"
                    + "[Slave_SecondChiefSign],"
                    + "[Slave_SecondChiefSignDate],"
                    + "[Slave_ChiefSign],"
                    + "[Slave_ChiefSignDate],"
                    + "[Slave_DirectorSign],"
                    + "[Slave_DirectorSignDate]"
                    + ") VALUES( "
                    + " " + (unit.Report_ShipSlave_Id == null ? "''" : "'" + unit.Report_ShipSlave_Id.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.File_ID) ? "null" : "'" + unit.File_ID.Replace("'", "''") + "'")
                    + " , " + (unit.Voyage == null ? "''" : "'" + unit.Voyage.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.TableWritedDate)
                    + " ," + dbOperation.DbToDate(unit.Slave_ParaAbstractedDate)
                    + " ," + dbOperation.DbToDate(unit.Slave_RecordDate)
                    + " , " + (string.IsNullOrEmpty(unit.Slave_EditID) ? "null" : "'" + unit.Slave_EditID.Replace("'", "''") + "'")
                    + " , " + (unit.Slave_SmokeHignNO == null ? "''" : "'" + unit.Slave_SmokeHignNO.Replace("'", "''") + "'")
                    + " , " + (unit.Slave_SmokeHignTem == null ? "''" : "'" + unit.Slave_SmokeHignTem.Replace("'", "''") + "'")
                    + " , " + (unit.Slave_SmokeLowNO == null ? "''" : "'" + unit.Slave_SmokeLowNO.Replace("'", "''") + "'")
                    + " , " + (unit.Slave_SmokeLowTem == null ? "''" : "'" + unit.Slave_SmokeLowTem.Replace("'", "''") + "'")
                    + " , " + (unit.Slave_CoolSystemInTem == null ? "''" : "'" + unit.Slave_CoolSystemInTem.Replace("'", "''") + "'")
                    + " , " + (unit.Slave_CoolSystemOutTem == null ? "''" : "'" + unit.Slave_CoolSystemOutTem.Replace("'", "''") + "'")
                    + " , " + (unit.Slave_OilinTem == null ? "''" : "'" + unit.Slave_OilinTem.Replace("'", "''") + "'")
                    + " , " + (unit.Slave_OilOutTem == null ? "''" : "'" + unit.Slave_OilOutTem.Replace("'", "''") + "'")
                    + " , " + (unit.Slave_FuelInTem == null ? "''" : "'" + unit.Slave_FuelInTem.Replace("'", "''") + "'")
                    + " , " + (unit.Slave_PressureAirTem == null ? "''" : "'" + unit.Slave_PressureAirTem.Replace("'", "''") + "'")
                    + " , " + (unit.Slave_CoolWaterHignMPa == null ? "''" : "'" + unit.Slave_CoolWaterHignMPa.Replace("'", "''") + "'")
                    + " , " + (unit.Slave_CoolWaterLowMPa == null ? "''" : "'" + unit.Slave_CoolWaterLowMPa.Replace("'", "''") + "'")
                    + " , " + (unit.Slave_OilInMpa == null ? "''" : "'" + unit.Slave_OilInMpa.Replace("'", "''") + "'")
                    + " , " + (unit.Slave_FuelInMpa == null ? "''" : "'" + unit.Slave_FuelInMpa.Replace("'", "''") + "'")
                    + " , " + (unit.Slave_PressureAirMPa == null ? "''" : "'" + unit.Slave_PressureAirMPa.Replace("'", "''") + "'")
                    + " , " + (unit.Slave_GeneratorVoltage == null ? "''" : "'" + unit.Slave_GeneratorVoltage.Replace("'", "''") + "'")
                    + " , " + (unit.Slave_GeneratorCurrent == null ? "''" : "'" + unit.Slave_GeneratorCurrent.Replace("'", "''") + "'")
                    + " , " + (unit.Slavae_GeneratorKW == null ? "''" : "'" + unit.Slavae_GeneratorKW.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselNoOne == null ? "''" : "'" + unit.SS_DieselNoOne.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselNoTwo == null ? "''" : "'" + unit.SS_DieselNoTwo.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselNoOnePressureNO1 == null ? "''" : "'" + unit.SS_DieselNoOnePressureNO1.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselNoOnePressureNO2 == null ? "''" : "'" + unit.SS_DieselNoOnePressureNO2.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselNoOnePressureNO3 == null ? "''" : "'" + unit.SS_DieselNoOnePressureNO3.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselNoOnePressureNO4 == null ? "''" : "'" + unit.SS_DieselNoOnePressureNO4.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselNoOnePressureNO5 == null ? "''" : "'" + unit.SS_DieselNoOnePressureNO5.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselNoOnePressureNO6 == null ? "''" : "'" + unit.SS_DieselNoOnePressureNO6.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselNoOnePressureNO7 == null ? "''" : "'" + unit.SS_DieselNoOnePressureNO7.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselNoOnePressureNO8 == null ? "''" : "'" + unit.SS_DieselNoOnePressureNO8.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselNoOneTemNO1 == null ? "''" : "'" + unit.SS_DieselNoOneTemNO1.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselNoOneTemNO2 == null ? "''" : "'" + unit.SS_DieselNoOneTemNO2.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselNoOneTemNO3 == null ? "''" : "'" + unit.SS_DieselNoOneTemNO3.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselNoOneTemNO4 == null ? "''" : "'" + unit.SS_DieselNoOneTemNO4.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselNoOneTemNO5 == null ? "''" : "'" + unit.SS_DieselNoOneTemNO5.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselNoOneTemNO6 == null ? "''" : "'" + unit.SS_DieselNoOneTemNO6.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselNoOneTemNO7 == null ? "''" : "'" + unit.SS_DieselNoOneTemNO7.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselNoOneTemNO8 == null ? "''" : "'" + unit.SS_DieselNoOneTemNO8.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselNoTwoPressureNO1 == null ? "''" : "'" + unit.SS_DieselNoTwoPressureNO1.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselNoTwoPressureNO2 == null ? "''" : "'" + unit.SS_DieselNoTwoPressureNO2.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselNoTwoPressureNO3 == null ? "''" : "'" + unit.SS_DieselNoTwoPressureNO3.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselNoTwoPressureNO4 == null ? "''" : "'" + unit.SS_DieselNoTwoPressureNO4.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselNoTwoPressureNO5 == null ? "''" : "'" + unit.SS_DieselNoTwoPressureNO5.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselNoTwoPressureNO6 == null ? "''" : "'" + unit.SS_DieselNoTwoPressureNO6.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselNoTwoPressureNO7 == null ? "''" : "'" + unit.SS_DieselNoTwoPressureNO7.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselNoTwoPressureNO8 == null ? "''" : "'" + unit.SS_DieselNoTwoPressureNO8.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselNoTwoTemNO1 == null ? "''" : "'" + unit.SS_DieselNoTwoTemNO1.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselNoTwoTemNO2 == null ? "''" : "'" + unit.SS_DieselNoTwoTemNO2.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselNoTwoTemNO3 == null ? "''" : "'" + unit.SS_DieselNoTwoTemNO3.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselNoTwoTemNO4 == null ? "''" : "'" + unit.SS_DieselNoTwoTemNO4.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselNoTwoTemNO5 == null ? "''" : "'" + unit.SS_DieselNoTwoTemNO5.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselNoTwoTemNO6 == null ? "''" : "'" + unit.SS_DieselNoTwoTemNO6.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselNoTwoTemNO7 == null ? "''" : "'" + unit.SS_DieselNoTwoTemNO7.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselNoTwoTemNO8 == null ? "''" : "'" + unit.SS_DieselNoTwoTemNO8.Replace("'", "''") + "'")
                    + " , " + (unit.SS_DieselFuelSpecifation == null ? "''" : "'" + unit.SS_DieselFuelSpecifation.Replace("'", "''") + "'")
                    + " , " + (unit.SS_SDieselFuelConsumption1 == null ? "''" : "'" + unit.SS_SDieselFuelConsumption1.Replace("'", "''") + "'")
                    + " , " + (unit.SS_SDieselFuelConsumption2 == null ? "''" : "'" + unit.SS_SDieselFuelConsumption2.Replace("'", "''") + "'")
                    + " , " + (unit.SS_SDieselFuelConsumption3 == null ? "''" : "'" + unit.SS_SDieselFuelConsumption3.Replace("'", "''") + "'")
                    + " , " + (unit.SS_SDieselFuelConsumption4 == null ? "''" : "'" + unit.SS_SDieselFuelConsumption4.Replace("'", "''") + "'")
                    + " , " + (unit.Slave_SecondChiefSign == null ? "''" : "'" + unit.Slave_SecondChiefSign.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.Slave_SecondChiefSignDate)
                    + " , " + (unit.Slave_ChiefSign == null ? "''" : "'" + unit.Slave_ChiefSign.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.Slave_ChiefSignDate)
                    + " , " + (unit.Slave_DirectorSign == null ? "''" : "'" + unit.Slave_DirectorSign.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.Slave_DirectorSignDate)
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
