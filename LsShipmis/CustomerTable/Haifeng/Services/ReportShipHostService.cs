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

namespace  CustomerTable.Haifeng.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_REPORT_SHIPHOSTService.cs
    /// </summary>
    public partial class ReportShipHostService
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static ReportShipHostService instance=new ReportShipHostService();
        public static ReportShipHostService Instance
        { 
            get
            {
                if(null==instance)
                {
                    ReportShipHostService.instance = new ReportShipHostService();
                }
                return ReportShipHostService.instance;
            }
        }
		private ReportShipHostService(){}
		#endregion
		
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();        
        string sql = ""; 
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">ReportShipHost对象</param>
		/// <returns>插入的对象更新</returns>	
		internal bool saveUnit(ReportShipHost unit,out string err)
        {
			if (unit.Report_ShipHost_Id!=null && unit.Report_ShipHost_Id.Length > 0) //edit
			{
				sql = "UPDATE [T_REPORT_SHIPHOST] SET "
					+ " [Report_ShipHost_Id] = " + (unit.Report_ShipHost_Id==null?"''":"'" + unit.Report_ShipHost_Id.Replace ("'","''") + "'")
					+ " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ " , [File_ID] = " + (string.IsNullOrEmpty(unit.File_ID)?"null":"'" + unit.File_ID.Replace ("'","''") + "'")
					+ " , [Voyage] = " + (unit.Voyage==null?"''":"'" + unit.Voyage.Replace ("'","''") + "'")
                    + " , [TableWritedDate] = " + dbOperation.DbToDate(unit.TableWritedDate)
                    + " , [Host_ParaAbstractedDate] = " + dbOperation.DbToDate(unit.Host_ParaAbstractedDate)
                    + " , [Host_RecordDate] = " + dbOperation.DbToDate(unit.Host_RecordDate)
					+ " , [Host_Speed] = " + (unit.Host_Speed==null?"''":"'" + unit.Host_Speed.Replace ("'","''") + "'")
					+ " , [Host_LoadInstruction] = " + (unit.Host_LoadInstruction==null?"''":"'" + unit.Host_LoadInstruction.Replace ("'","''") + "'")
					+ " , [Host_SmokeHign_Tem] = " + (unit.Host_SmokeHign_Tem==null?"''":"'" + unit.Host_SmokeHign_Tem.Replace ("'","''") + "'")
					+ " , [Host_SmokeHign_CylinderNO] = " + (unit.Host_SmokeHign_CylinderNO==null?"''":"'" + unit.Host_SmokeHign_CylinderNO.Replace ("'","''") + "'")
					+ " , [Host_SmokeLow_Tem] = " + (unit.Host_SmokeLow_Tem==null?"''":"'" + unit.Host_SmokeLow_Tem.Replace ("'","''") + "'")
					+ " , [Host_SmokeLow_CylinderNO] = " + (unit.Host_SmokeLow_CylinderNO==null?"''":"'" + unit.Host_SmokeLow_CylinderNO.Replace ("'","''") + "'")
					+ " , [Host_LinerCoolWaterIn_Tem] = " + (unit.Host_LinerCoolWaterIn_Tem==null?"''":"'" + unit.Host_LinerCoolWaterIn_Tem.Replace ("'","''") + "'")
					+ " , [Host_LinerCoolWaterOut_Tem] = " + (unit.Host_LinerCoolWaterOut_Tem==null?"''":"'" + unit.Host_LinerCoolWaterOut_Tem.Replace ("'","''") + "'")
					+ " , [Host_PistonCoolantIn_Tem] = " + (unit.Host_PistonCoolantIn_Tem==null?"''":"'" + unit.Host_PistonCoolantIn_Tem.Replace ("'","''") + "'")
					+ " , [Host_PistonCoolanOut_Tem] = " + (unit.Host_PistonCoolanOut_Tem==null?"''":"'" + unit.Host_PistonCoolanOut_Tem.Replace ("'","''") + "'")
					+ " , [Host_CoolerBeforeNO1_Tem] = " + (unit.Host_CoolerBeforeNO1_Tem==null?"''":"'" + unit.Host_CoolerBeforeNO1_Tem.Replace ("'","''") + "'")
					+ " , [Host_CoolerBeforeNO2_Tem] = " + (unit.Host_CoolerBeforeNO2_Tem==null?"''":"'" + unit.Host_CoolerBeforeNO2_Tem.Replace ("'","''") + "'")
					+ " , [Host_CoolerBeforeNO3_Tem] = " + (unit.Host_CoolerBeforeNO3_Tem==null?"''":"'" + unit.Host_CoolerBeforeNO3_Tem.Replace ("'","''") + "'")
					+ " , [Host_CoolerAfterNO1_Tem] = " + (unit.Host_CoolerAfterNO1_Tem==null?"''":"'" + unit.Host_CoolerAfterNO1_Tem.Replace ("'","''") + "'")
					+ " , [Host_CoolerAfterNO2_Tem] = " + (unit.Host_CoolerAfterNO2_Tem==null?"''":"'" + unit.Host_CoolerAfterNO2_Tem.Replace ("'","''") + "'")
					+ " , [Host_CoolerAfterNO3_Tem] = " + (unit.Host_CoolerAfterNO3_Tem==null?"''":"'" + unit.Host_CoolerAfterNO3_Tem.Replace ("'","''") + "'")
					+ " , [Host_SternTube_Tem] = " + (unit.Host_SternTube_Tem==null?"''":"'" + unit.Host_SternTube_Tem.Replace ("'","''") + "'")
					+ " , [Host_Cabin_Tem] = " + (unit.Host_Cabin_Tem==null?"''":"'" + unit.Host_Cabin_Tem.Replace ("'","''") + "'")
					+ " , [Host_SeaWater_Tem] = " + (unit.Host_SeaWater_Tem==null?"''":"'" + unit.Host_SeaWater_Tem.Replace ("'","''") + "'")
					+ " , [Host_CoolWaterHigh_MPa] = " + (unit.Host_CoolWaterHigh_MPa==null?"''":"'" + unit.Host_CoolWaterHigh_MPa.Replace ("'","''") + "'")
					+ " , [Host_CoolWaterLow_MPa] = " + (unit.Host_CoolWaterLow_MPa==null?"''":"'" + unit.Host_CoolWaterLow_MPa.Replace ("'","''") + "'")
					+ " , [Host_OilMain_Mpa] = " + (unit.Host_OilMain_Mpa==null?"''":"'" + unit.Host_OilMain_Mpa.Replace ("'","''") + "'")
					+ " , [Host_OilCrosshead_Mpa] = " + (unit.Host_OilCrosshead_Mpa==null?"''":"'" + unit.Host_OilCrosshead_Mpa.Replace ("'","''") + "'")
					+ " , [Host_PressurizedAir_Mpa] = " + (unit.Host_PressurizedAir_Mpa==null?"''":"'" + unit.Host_PressurizedAir_Mpa.Replace ("'","''") + "'")
					+ " , [Host_FuelInto_Mpa] = " + (unit.Host_FuelInto_Mpa==null?"''":"'" + unit.Host_FuelInto_Mpa.Replace ("'","''") + "'")
					+ " , [Host_ActualSpeed] = " + (unit.Host_ActualSpeed==null?"''":"'" + unit.Host_ActualSpeed.Replace ("'","''") + "'")
					+ " , [Host_LossRate] = " + (unit.Host_LossRate==null?"''":"'" + unit.Host_LossRate.Replace ("'","''") + "'")
					+ " , [Host_TurbochargerSpeedNO1] = " + (unit.Host_TurbochargerSpeedNO1==null?"''":"'" + unit.Host_TurbochargerSpeedNO1.Replace ("'","''") + "'")
					+ " , [Host_TurbochargerSpeedNO2] = " + (unit.Host_TurbochargerSpeedNO2==null?"''":"'" + unit.Host_TurbochargerSpeedNO2.Replace ("'","''") + "'")
					+ " , [HH_HighPumpNO1] = " + (unit.HH_HighPumpNO1==null?"''":"'" + unit.HH_HighPumpNO1.Replace ("'","''") + "'")
					+ " , [HH_HighPumpNO2] = " + (unit.HH_HighPumpNO2==null?"''":"'" + unit.HH_HighPumpNO2.Replace ("'","''") + "'")
					+ " , [HH_HighPumpNO3] = " + (unit.HH_HighPumpNO3==null?"''":"'" + unit.HH_HighPumpNO3.Replace ("'","''") + "'")
					+ " , [HH_HighPumpNO4] = " + (unit.HH_HighPumpNO4==null?"''":"'" + unit.HH_HighPumpNO4.Replace ("'","''") + "'")
					+ " , [HH_HighPumpNO5] = " + (unit.HH_HighPumpNO5==null?"''":"'" + unit.HH_HighPumpNO5.Replace ("'","''") + "'")
					+ " , [HH_HighPumpNO6] = " + (unit.HH_HighPumpNO6==null?"''":"'" + unit.HH_HighPumpNO6.Replace ("'","''") + "'")
					+ " , [HH_HighPumpNO7] = " + (unit.HH_HighPumpNO7==null?"''":"'" + unit.HH_HighPumpNO7.Replace ("'","''") + "'")
					+ " , [HH_HighPumpNO8] = " + (unit.HH_HighPumpNO8==null?"''":"'" + unit.HH_HighPumpNO8.Replace ("'","''") + "'")
					+ " , [HH_HighPumpAverage] = " + (unit.HH_HighPumpAverage==null?"''":"'" + unit.HH_HighPumpAverage.Replace ("'","''") + "'")
					+ " , [HH_VITNO1] = " + (unit.HH_VITNO1==null?"''":"'" + unit.HH_VITNO1.Replace ("'","''") + "'")
					+ " , [HH_VITNO2] = " + (unit.HH_VITNO2==null?"''":"'" + unit.HH_VITNO2.Replace ("'","''") + "'")
					+ " , [HH_VITNO3] = " + (unit.HH_VITNO3==null?"''":"'" + unit.HH_VITNO3.Replace ("'","''") + "'")
					+ " , [HH_VITNO4] = " + (unit.HH_VITNO4==null?"''":"'" + unit.HH_VITNO4.Replace ("'","''") + "'")
					+ " , [HH_VITNO5] = " + (unit.HH_VITNO5==null?"''":"'" + unit.HH_VITNO5.Replace ("'","''") + "'")
					+ " , [HH_VITNO6] = " + (unit.HH_VITNO6==null?"''":"'" + unit.HH_VITNO6.Replace ("'","''") + "'")
					+ " , [HH_VITNO7] = " + (unit.HH_VITNO7==null?"''":"'" + unit.HH_VITNO7.Replace ("'","''") + "'")
					+ " , [HH_VITNO8] = " + (unit.HH_VITNO8==null?"''":"'" + unit.HH_VITNO8.Replace ("'","''") + "'")
					+ " , [HH_VITAverage] = " + (unit.HH_VITAverage==null?"''":"'" + unit.HH_VITAverage.Replace ("'","''") + "'")
					+ " , [HH_SmokeTemNO1] = " + (unit.HH_SmokeTemNO1==null?"''":"'" + unit.HH_SmokeTemNO1.Replace ("'","''") + "'")
					+ " , [HH_SmokeTemNO2] = " + (unit.HH_SmokeTemNO2==null?"''":"'" + unit.HH_SmokeTemNO2.Replace ("'","''") + "'")
					+ " , [HH_SmokeTemNO3] = " + (unit.HH_SmokeTemNO3==null?"''":"'" + unit.HH_SmokeTemNO3.Replace ("'","''") + "'")
					+ " , [HH_SmokeTemNO4] = " + (unit.HH_SmokeTemNO4==null?"''":"'" + unit.HH_SmokeTemNO4.Replace ("'","''") + "'")
					+ " , [HH_SmokeTemNO5] = " + (unit.HH_SmokeTemNO5==null?"''":"'" + unit.HH_SmokeTemNO5.Replace ("'","''") + "'")
					+ " , [HH_SmokeTemNO6] = " + (unit.HH_SmokeTemNO6==null?"''":"'" + unit.HH_SmokeTemNO6.Replace ("'","''") + "'")
					+ " , [HH_SmokeTemNO7] = " + (unit.HH_SmokeTemNO7==null?"''":"'" + unit.HH_SmokeTemNO7.Replace ("'","''") + "'")
					+ " , [HH_SmokeTemNO8] = " + (unit.HH_SmokeTemNO8==null?"''":"'" + unit.HH_SmokeTemNO8.Replace ("'","''") + "'")
					+ " , [HH_SmokeTemAverage] = " + (unit.HH_SmokeTemAverage==null?"''":"'" + unit.HH_SmokeTemAverage.Replace ("'","''") + "'")
					+ " , [HH_CompressionPressNO1] = " + (unit.HH_CompressionPressNO1==null?"''":"'" + unit.HH_CompressionPressNO1.Replace ("'","''") + "'")
					+ " , [HH_CompressionPressNO2] = " + (unit.HH_CompressionPressNO2==null?"''":"'" + unit.HH_CompressionPressNO2.Replace ("'","''") + "'")
					+ " , [HH_CompressionPressNO3] = " + (unit.HH_CompressionPressNO3==null?"''":"'" + unit.HH_CompressionPressNO3.Replace ("'","''") + "'")
					+ " , [HH_CompressionPressNO4] = " + (unit.HH_CompressionPressNO4==null?"''":"'" + unit.HH_CompressionPressNO4.Replace ("'","''") + "'")
					+ " , [HH_CompressionPressNO5] = " + (unit.HH_CompressionPressNO5==null?"''":"'" + unit.HH_CompressionPressNO5.Replace ("'","''") + "'")
					+ " , [HH_CompressionPressNO6] = " + (unit.HH_CompressionPressNO6==null?"''":"'" + unit.HH_CompressionPressNO6.Replace ("'","''") + "'")
					+ " , [HH_CompressionPressNO7] = " + (unit.HH_CompressionPressNO7==null?"''":"'" + unit.HH_CompressionPressNO7.Replace ("'","''") + "'")
					+ " , [HH_CompressionPressNO8] = " + (unit.HH_CompressionPressNO8==null?"''":"'" + unit.HH_CompressionPressNO8.Replace ("'","''") + "'")
					+ " , [HH_CompressionPressAverage] = " + (unit.HH_CompressionPressAverage==null?"''":"'" + unit.HH_CompressionPressAverage.Replace ("'","''") + "'")
					+ " , [HH_BoomPressNO1] = " + (unit.HH_BoomPressNO1==null?"''":"'" + unit.HH_BoomPressNO1.Replace ("'","''") + "'")
					+ " , [HH_BoomPressNO2] = " + (unit.HH_BoomPressNO2==null?"''":"'" + unit.HH_BoomPressNO2.Replace ("'","''") + "'")
					+ " , [HH_BoomPressNO3] = " + (unit.HH_BoomPressNO3==null?"''":"'" + unit.HH_BoomPressNO3.Replace ("'","''") + "'")
					+ " , [HH_BoomPressNO4] = " + (unit.HH_BoomPressNO4==null?"''":"'" + unit.HH_BoomPressNO4.Replace ("'","''") + "'")
					+ " , [HH_BoomPressNO5] = " + (unit.HH_BoomPressNO5==null?"''":"'" + unit.HH_BoomPressNO5.Replace ("'","''") + "'")
					+ " , [HH_BoomPressNO6] = " + (unit.HH_BoomPressNO6==null?"''":"'" + unit.HH_BoomPressNO6.Replace ("'","''") + "'")
					+ " , [HH_BoomPressNO7] = " + (unit.HH_BoomPressNO7==null?"''":"'" + unit.HH_BoomPressNO7.Replace ("'","''") + "'")
					+ " , [HH_BoomPressNO8] = " + (unit.HH_BoomPressNO8==null?"''":"'" + unit.HH_BoomPressNO8.Replace ("'","''") + "'")
					+ " , [HH_BoomPressAverage] = " + (unit.HH_BoomPressAverage==null?"''":"'" + unit.HH_BoomPressAverage.Replace ("'","''") + "'")
                    + " , [HH_MeasureDate] = " + dbOperation.DbToDate(unit.HH_MeasureDate)
					+ " , [HH_Model] = " + (unit.HH_Model==null?"''":"'" + unit.HH_Model.Replace ("'","''") + "'")
					+ " , [HH_Load] = " + (unit.HH_Load==null?"''":"'" + unit.HH_Load.Replace ("'","''") + "'")
					+ " , [HH_SeaArea] = " + (unit.HH_SeaArea==null?"''":"'" + unit.HH_SeaArea.Replace ("'","''") + "'")
					+ " , [HH_Wind] = " + (unit.HH_Wind==null?"''":"'" + unit.HH_Wind.Replace ("'","''") + "'")
					+ " , [HH_Wave] = " + (unit.HH_Wave==null?"''":"'" + unit.HH_Wave.Replace ("'","''") + "'")
					+ " , [HH_BowDraft] = " + (unit.HH_BowDraft==null?"''":"'" + unit.HH_BowDraft.Replace ("'","''") + "'")
					+ " , [HH_PoopDraft] = " + (unit.HH_PoopDraft==null?"''":"'" + unit.HH_PoopDraft.Replace ("'","''") + "'")
					+ " , [HH_FireSequence] = " + (unit.HH_FireSequence==null?"''":"'" + unit.HH_FireSequence.Replace ("'","''") + "'")
					+ " , [HH_FuelSpecification] = " + (unit.HH_FuelSpecification==null?"''":"'" + unit.HH_FuelSpecification.Replace ("'","''") + "'")
					+ " , [HH_DailyConsumption] = " + (unit.HH_DailyConsumption==null?"''":"'" + unit.HH_DailyConsumption.Replace ("'","''") + "'")
					+ " , [HH_CylinderConstant] = " + (unit.HH_CylinderConstant==null?"''":"'" + unit.HH_CylinderConstant.Replace ("'","''") + "'")
					+ " , [HH_TotalKW] = " + (unit.HH_TotalKW==null?"''":"'" + unit.HH_TotalKW.Replace ("'","''") + "'")
					+ " , [HH_TotalRatedPower] = " + (unit.HH_TotalRatedPower==null?"''":"'" + unit.HH_TotalRatedPower.Replace ("'","''") + "'")
					+ " , [HH_TotalPower] = " + (unit.HH_TotalPower==null?"''":"'" + unit.HH_TotalPower.Replace ("'","''") + "'")
					+ " , [HH_Speed] = " + (unit.HH_Speed==null?"''":"'" + unit.HH_Speed.Replace ("'","''") + "'")
					+ " , [HH_SlipRate] = " + (unit.HH_SlipRate==null?"''":"'" + unit.HH_SlipRate.Replace ("'","''") + "'")
					+ " , [HH_MaxExhaustTempDifference] = " + (unit.HH_MaxExhaustTempDifference==null?"''":"'" + unit.HH_MaxExhaustTempDifference.Replace ("'","''") + "'")
					+ " , [HH_MaxCompressionPressDifference] = " + (unit.HH_MaxCompressionPressDifference==null?"''":"'" + unit.HH_MaxCompressionPressDifference.Replace ("'","''") + "'")
					+ " , [HH_DetonationPressDifference] = " + (unit.HH_DetonationPressDifference==null?"''":"'" + unit.HH_DetonationPressDifference.Replace ("'","''") + "'")
					+ " , [HH_FuelInTem] = " + (unit.HH_FuelInTem==null?"''":"'" + unit.HH_FuelInTem.Replace ("'","''") + "'")
					+ " , [HH_FuelInViscosity] = " + (unit.HH_FuelInViscosity==null?"''":"'" + unit.HH_FuelInViscosity.Replace ("'","''") + "'")
					+ " , [HH_Remarks] = " + (unit.HH_Remarks==null?"''":"'" + unit.HH_Remarks.Replace ("'","''") + "'")
					+ " , [HH_ChiefSign] = " + (unit.HH_ChiefSign==null?"''":"'" + unit.HH_ChiefSign.Replace ("'","''") + "'")
                    + " , [HH_ChiefSignDate] = " + dbOperation.DbToDate(unit.HH_ChiefSignDate)
					+ " , [HH_DirectorSign] = " + (unit.HH_DirectorSign==null?"''":"'" + unit.HH_DirectorSign.Replace ("'","''") + "'")
                    + " , [HH_DirectorSignDate] = " + dbOperation.DbToDate(unit.HH_DirectorSignDate)
					+ " where upper(Report_ShipHost_Id) = '" + unit.Report_ShipHost_Id.ToUpper() + "'"; 
			}
			else
			{
				unit.Report_ShipHost_Id = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_REPORT_SHIPHOST] ("
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
					+ " " + (unit.Report_ShipHost_Id==null?"''":"'" + unit.Report_ShipHost_Id.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.File_ID)?"null":"'" + unit.File_ID.Replace ("'","''") + "'")
					+ " , " + (unit.Voyage==null?"''":"'" + unit.Voyage.Replace ("'","''") + "'")
					+ " ," + dbOperation.DbToDate(unit.TableWritedDate)
					+ " ," + dbOperation.DbToDate(unit.Host_ParaAbstractedDate)
					+ " ," + dbOperation.DbToDate(unit.Host_RecordDate)
					+ " , " + (unit.Host_Speed==null?"''":"'" + unit.Host_Speed.Replace ("'","''") + "'")
					+ " , " + (unit.Host_LoadInstruction==null?"''":"'" + unit.Host_LoadInstruction.Replace ("'","''") + "'")
					+ " , " + (unit.Host_SmokeHign_Tem==null?"''":"'" + unit.Host_SmokeHign_Tem.Replace ("'","''") + "'")
					+ " , " + (unit.Host_SmokeHign_CylinderNO==null?"''":"'" + unit.Host_SmokeHign_CylinderNO.Replace ("'","''") + "'")
					+ " , " + (unit.Host_SmokeLow_Tem==null?"''":"'" + unit.Host_SmokeLow_Tem.Replace ("'","''") + "'")
					+ " , " + (unit.Host_SmokeLow_CylinderNO==null?"''":"'" + unit.Host_SmokeLow_CylinderNO.Replace ("'","''") + "'")
					+ " , " + (unit.Host_LinerCoolWaterIn_Tem==null?"''":"'" + unit.Host_LinerCoolWaterIn_Tem.Replace ("'","''") + "'")
					+ " , " + (unit.Host_LinerCoolWaterOut_Tem==null?"''":"'" + unit.Host_LinerCoolWaterOut_Tem.Replace ("'","''") + "'")
					+ " , " + (unit.Host_PistonCoolantIn_Tem==null?"''":"'" + unit.Host_PistonCoolantIn_Tem.Replace ("'","''") + "'")
					+ " , " + (unit.Host_PistonCoolanOut_Tem==null?"''":"'" + unit.Host_PistonCoolanOut_Tem.Replace ("'","''") + "'")
					+ " , " + (unit.Host_CoolerBeforeNO1_Tem==null?"''":"'" + unit.Host_CoolerBeforeNO1_Tem.Replace ("'","''") + "'")
					+ " , " + (unit.Host_CoolerBeforeNO2_Tem==null?"''":"'" + unit.Host_CoolerBeforeNO2_Tem.Replace ("'","''") + "'")
					+ " , " + (unit.Host_CoolerBeforeNO3_Tem==null?"''":"'" + unit.Host_CoolerBeforeNO3_Tem.Replace ("'","''") + "'")
					+ " , " + (unit.Host_CoolerAfterNO1_Tem==null?"''":"'" + unit.Host_CoolerAfterNO1_Tem.Replace ("'","''") + "'")
					+ " , " + (unit.Host_CoolerAfterNO2_Tem==null?"''":"'" + unit.Host_CoolerAfterNO2_Tem.Replace ("'","''") + "'")
					+ " , " + (unit.Host_CoolerAfterNO3_Tem==null?"''":"'" + unit.Host_CoolerAfterNO3_Tem.Replace ("'","''") + "'")
					+ " , " + (unit.Host_SternTube_Tem==null?"''":"'" + unit.Host_SternTube_Tem.Replace ("'","''") + "'")
					+ " , " + (unit.Host_Cabin_Tem==null?"''":"'" + unit.Host_Cabin_Tem.Replace ("'","''") + "'")
					+ " , " + (unit.Host_SeaWater_Tem==null?"''":"'" + unit.Host_SeaWater_Tem.Replace ("'","''") + "'")
					+ " , " + (unit.Host_CoolWaterHigh_MPa==null?"''":"'" + unit.Host_CoolWaterHigh_MPa.Replace ("'","''") + "'")
					+ " , " + (unit.Host_CoolWaterLow_MPa==null?"''":"'" + unit.Host_CoolWaterLow_MPa.Replace ("'","''") + "'")
					+ " , " + (unit.Host_OilMain_Mpa==null?"''":"'" + unit.Host_OilMain_Mpa.Replace ("'","''") + "'")
					+ " , " + (unit.Host_OilCrosshead_Mpa==null?"''":"'" + unit.Host_OilCrosshead_Mpa.Replace ("'","''") + "'")
					+ " , " + (unit.Host_PressurizedAir_Mpa==null?"''":"'" + unit.Host_PressurizedAir_Mpa.Replace ("'","''") + "'")
					+ " , " + (unit.Host_FuelInto_Mpa==null?"''":"'" + unit.Host_FuelInto_Mpa.Replace ("'","''") + "'")
					+ " , " + (unit.Host_ActualSpeed==null?"''":"'" + unit.Host_ActualSpeed.Replace ("'","''") + "'")
					+ " , " + (unit.Host_LossRate==null?"''":"'" + unit.Host_LossRate.Replace ("'","''") + "'")
					+ " , " + (unit.Host_TurbochargerSpeedNO1==null?"''":"'" + unit.Host_TurbochargerSpeedNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Host_TurbochargerSpeedNO2==null?"''":"'" + unit.Host_TurbochargerSpeedNO2.Replace ("'","''") + "'")
					+ " , " + (unit.HH_HighPumpNO1==null?"''":"'" + unit.HH_HighPumpNO1.Replace ("'","''") + "'")
					+ " , " + (unit.HH_HighPumpNO2==null?"''":"'" + unit.HH_HighPumpNO2.Replace ("'","''") + "'")
					+ " , " + (unit.HH_HighPumpNO3==null?"''":"'" + unit.HH_HighPumpNO3.Replace ("'","''") + "'")
					+ " , " + (unit.HH_HighPumpNO4==null?"''":"'" + unit.HH_HighPumpNO4.Replace ("'","''") + "'")
					+ " , " + (unit.HH_HighPumpNO5==null?"''":"'" + unit.HH_HighPumpNO5.Replace ("'","''") + "'")
					+ " , " + (unit.HH_HighPumpNO6==null?"''":"'" + unit.HH_HighPumpNO6.Replace ("'","''") + "'")
					+ " , " + (unit.HH_HighPumpNO7==null?"''":"'" + unit.HH_HighPumpNO7.Replace ("'","''") + "'")
					+ " , " + (unit.HH_HighPumpNO8==null?"''":"'" + unit.HH_HighPumpNO8.Replace ("'","''") + "'")
					+ " , " + (unit.HH_HighPumpAverage==null?"''":"'" + unit.HH_HighPumpAverage.Replace ("'","''") + "'")
					+ " , " + (unit.HH_VITNO1==null?"''":"'" + unit.HH_VITNO1.Replace ("'","''") + "'")
					+ " , " + (unit.HH_VITNO2==null?"''":"'" + unit.HH_VITNO2.Replace ("'","''") + "'")
					+ " , " + (unit.HH_VITNO3==null?"''":"'" + unit.HH_VITNO3.Replace ("'","''") + "'")
					+ " , " + (unit.HH_VITNO4==null?"''":"'" + unit.HH_VITNO4.Replace ("'","''") + "'")
					+ " , " + (unit.HH_VITNO5==null?"''":"'" + unit.HH_VITNO5.Replace ("'","''") + "'")
					+ " , " + (unit.HH_VITNO6==null?"''":"'" + unit.HH_VITNO6.Replace ("'","''") + "'")
					+ " , " + (unit.HH_VITNO7==null?"''":"'" + unit.HH_VITNO7.Replace ("'","''") + "'")
					+ " , " + (unit.HH_VITNO8==null?"''":"'" + unit.HH_VITNO8.Replace ("'","''") + "'")
					+ " , " + (unit.HH_VITAverage==null?"''":"'" + unit.HH_VITAverage.Replace ("'","''") + "'")
					+ " , " + (unit.HH_SmokeTemNO1==null?"''":"'" + unit.HH_SmokeTemNO1.Replace ("'","''") + "'")
					+ " , " + (unit.HH_SmokeTemNO2==null?"''":"'" + unit.HH_SmokeTemNO2.Replace ("'","''") + "'")
					+ " , " + (unit.HH_SmokeTemNO3==null?"''":"'" + unit.HH_SmokeTemNO3.Replace ("'","''") + "'")
					+ " , " + (unit.HH_SmokeTemNO4==null?"''":"'" + unit.HH_SmokeTemNO4.Replace ("'","''") + "'")
					+ " , " + (unit.HH_SmokeTemNO5==null?"''":"'" + unit.HH_SmokeTemNO5.Replace ("'","''") + "'")
					+ " , " + (unit.HH_SmokeTemNO6==null?"''":"'" + unit.HH_SmokeTemNO6.Replace ("'","''") + "'")
					+ " , " + (unit.HH_SmokeTemNO7==null?"''":"'" + unit.HH_SmokeTemNO7.Replace ("'","''") + "'")
					+ " , " + (unit.HH_SmokeTemNO8==null?"''":"'" + unit.HH_SmokeTemNO8.Replace ("'","''") + "'")
					+ " , " + (unit.HH_SmokeTemAverage==null?"''":"'" + unit.HH_SmokeTemAverage.Replace ("'","''") + "'")
					+ " , " + (unit.HH_CompressionPressNO1==null?"''":"'" + unit.HH_CompressionPressNO1.Replace ("'","''") + "'")
					+ " , " + (unit.HH_CompressionPressNO2==null?"''":"'" + unit.HH_CompressionPressNO2.Replace ("'","''") + "'")
					+ " , " + (unit.HH_CompressionPressNO3==null?"''":"'" + unit.HH_CompressionPressNO3.Replace ("'","''") + "'")
					+ " , " + (unit.HH_CompressionPressNO4==null?"''":"'" + unit.HH_CompressionPressNO4.Replace ("'","''") + "'")
					+ " , " + (unit.HH_CompressionPressNO5==null?"''":"'" + unit.HH_CompressionPressNO5.Replace ("'","''") + "'")
					+ " , " + (unit.HH_CompressionPressNO6==null?"''":"'" + unit.HH_CompressionPressNO6.Replace ("'","''") + "'")
					+ " , " + (unit.HH_CompressionPressNO7==null?"''":"'" + unit.HH_CompressionPressNO7.Replace ("'","''") + "'")
					+ " , " + (unit.HH_CompressionPressNO8==null?"''":"'" + unit.HH_CompressionPressNO8.Replace ("'","''") + "'")
					+ " , " + (unit.HH_CompressionPressAverage==null?"''":"'" + unit.HH_CompressionPressAverage.Replace ("'","''") + "'")
					+ " , " + (unit.HH_BoomPressNO1==null?"''":"'" + unit.HH_BoomPressNO1.Replace ("'","''") + "'")
					+ " , " + (unit.HH_BoomPressNO2==null?"''":"'" + unit.HH_BoomPressNO2.Replace ("'","''") + "'")
					+ " , " + (unit.HH_BoomPressNO3==null?"''":"'" + unit.HH_BoomPressNO3.Replace ("'","''") + "'")
					+ " , " + (unit.HH_BoomPressNO4==null?"''":"'" + unit.HH_BoomPressNO4.Replace ("'","''") + "'")
					+ " , " + (unit.HH_BoomPressNO5==null?"''":"'" + unit.HH_BoomPressNO5.Replace ("'","''") + "'")
					+ " , " + (unit.HH_BoomPressNO6==null?"''":"'" + unit.HH_BoomPressNO6.Replace ("'","''") + "'")
					+ " , " + (unit.HH_BoomPressNO7==null?"''":"'" + unit.HH_BoomPressNO7.Replace ("'","''") + "'")
					+ " , " + (unit.HH_BoomPressNO8==null?"''":"'" + unit.HH_BoomPressNO8.Replace ("'","''") + "'")
					+ " , " + (unit.HH_BoomPressAverage==null?"''":"'" + unit.HH_BoomPressAverage.Replace ("'","''") + "'")
					+ " ," + dbOperation.DbToDate(unit.HH_MeasureDate)
					+ " , " + (unit.HH_Model==null?"''":"'" + unit.HH_Model.Replace ("'","''") + "'")
					+ " , " + (unit.HH_Load==null?"''":"'" + unit.HH_Load.Replace ("'","''") + "'")
					+ " , " + (unit.HH_SeaArea==null?"''":"'" + unit.HH_SeaArea.Replace ("'","''") + "'")
					+ " , " + (unit.HH_Wind==null?"''":"'" + unit.HH_Wind.Replace ("'","''") + "'")
					+ " , " + (unit.HH_Wave==null?"''":"'" + unit.HH_Wave.Replace ("'","''") + "'")
					+ " , " + (unit.HH_BowDraft==null?"''":"'" + unit.HH_BowDraft.Replace ("'","''") + "'")
					+ " , " + (unit.HH_PoopDraft==null?"''":"'" + unit.HH_PoopDraft.Replace ("'","''") + "'")
					+ " , " + (unit.HH_FireSequence==null?"''":"'" + unit.HH_FireSequence.Replace ("'","''") + "'")
					+ " , " + (unit.HH_FuelSpecification==null?"''":"'" + unit.HH_FuelSpecification.Replace ("'","''") + "'")
					+ " , " + (unit.HH_DailyConsumption==null?"''":"'" + unit.HH_DailyConsumption.Replace ("'","''") + "'")
					+ " , " + (unit.HH_CylinderConstant==null?"''":"'" + unit.HH_CylinderConstant.Replace ("'","''") + "'")
					+ " , " + (unit.HH_TotalKW==null?"''":"'" + unit.HH_TotalKW.Replace ("'","''") + "'")
					+ " , " + (unit.HH_TotalRatedPower==null?"''":"'" + unit.HH_TotalRatedPower.Replace ("'","''") + "'")
					+ " , " + (unit.HH_TotalPower==null?"''":"'" + unit.HH_TotalPower.Replace ("'","''") + "'")
					+ " , " + (unit.HH_Speed==null?"''":"'" + unit.HH_Speed.Replace ("'","''") + "'")
					+ " , " + (unit.HH_SlipRate==null?"''":"'" + unit.HH_SlipRate.Replace ("'","''") + "'")
					+ " , " + (unit.HH_MaxExhaustTempDifference==null?"''":"'" + unit.HH_MaxExhaustTempDifference.Replace ("'","''") + "'")
					+ " , " + (unit.HH_MaxCompressionPressDifference==null?"''":"'" + unit.HH_MaxCompressionPressDifference.Replace ("'","''") + "'")
					+ " , " + (unit.HH_DetonationPressDifference==null?"''":"'" + unit.HH_DetonationPressDifference.Replace ("'","''") + "'")
					+ " , " + (unit.HH_FuelInTem==null?"''":"'" + unit.HH_FuelInTem.Replace ("'","''") + "'")
					+ " , " + (unit.HH_FuelInViscosity==null?"''":"'" + unit.HH_FuelInViscosity.Replace ("'","''") + "'")
					+ " , " + (unit.HH_Remarks==null?"''":"'" + unit.HH_Remarks.Replace ("'","''") + "'")
					+ " , " + (unit.HH_ChiefSign==null?"''":"'" + unit.HH_ChiefSign.Replace ("'","''") + "'")
					+ " ," + dbOperation.DbToDate(unit.HH_ChiefSignDate)
					+ " , " + (unit.HH_DirectorSign==null?"''":"'" + unit.HH_DirectorSign.Replace ("'","''") + "'")
					+ " ," + dbOperation.DbToDate(unit.HH_DirectorSignDate)
					+ ")";
			}

			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_REPORT_SHIPHOST中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_REPORT_SHIPHOST对象</param>
		internal bool deleteUnit(ReportShipHost unit,out string err)
		{
			return deleteUnit(unit.Report_ShipHost_Id,out err);
		}
		
		/// <summary>
		/// 删除数据表T_REPORT_SHIPHOST中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_REPORT_SHIPHOST.report_ShipHost_Id主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_REPORT_SHIPHOST where "
				+ " upper(T_REPORT_SHIPHOST.Report_ShipHost_Id)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_REPORT_SHIPHOST 所有数据信息.
		/// </summary>
		/// <returns>T_REPORT_SHIPHOST DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql = "select	"
				+ "Report_ShipHost_Id"
				+ ",SHIP_ID"
				+ ",File_ID"
				+ ",Voyage"
				+ ",TableWritedDate"
				+ ",Host_ParaAbstractedDate"
				+ ",Host_RecordDate"
				+ ",Host_Speed"
				+ ",Host_LoadInstruction"
				+ ",Host_SmokeHign_Tem"
				+ ",Host_SmokeHign_CylinderNO"
				+ ",Host_SmokeLow_Tem"
				+ ",Host_SmokeLow_CylinderNO"
				+ ",Host_LinerCoolWaterIn_Tem"
				+ ",Host_LinerCoolWaterOut_Tem"
				+ ",Host_PistonCoolantIn_Tem"
				+ ",Host_PistonCoolanOut_Tem"
				+ ",Host_CoolerBeforeNO1_Tem"
				+ ",Host_CoolerBeforeNO2_Tem"
				+ ",Host_CoolerBeforeNO3_Tem"
				+ ",Host_CoolerAfterNO1_Tem"
				+ ",Host_CoolerAfterNO2_Tem"
				+ ",Host_CoolerAfterNO3_Tem"
				+ ",Host_SternTube_Tem"
				+ ",Host_Cabin_Tem"
				+ ",Host_SeaWater_Tem"
				+ ",Host_CoolWaterHigh_MPa"
				+ ",Host_CoolWaterLow_MPa"
				+ ",Host_OilMain_Mpa"
				+ ",Host_OilCrosshead_Mpa"
				+ ",Host_PressurizedAir_Mpa"
				+ ",Host_FuelInto_Mpa"
				+ ",Host_ActualSpeed"
				+ ",Host_LossRate"
				+ ",Host_TurbochargerSpeedNO1"
				+ ",Host_TurbochargerSpeedNO2"
				+ ",HH_HighPumpNO1"
				+ ",HH_HighPumpNO2"
				+ ",HH_HighPumpNO3"
				+ ",HH_HighPumpNO4"
				+ ",HH_HighPumpNO5"
				+ ",HH_HighPumpNO6"
				+ ",HH_HighPumpNO7"
				+ ",HH_HighPumpNO8"
				+ ",HH_HighPumpAverage"
				+ ",HH_VITNO1"
				+ ",HH_VITNO2"
				+ ",HH_VITNO3"
				+ ",HH_VITNO4"
				+ ",HH_VITNO5"
				+ ",HH_VITNO6"
				+ ",HH_VITNO7"
				+ ",HH_VITNO8"
				+ ",HH_VITAverage"
				+ ",HH_SmokeTemNO1"
				+ ",HH_SmokeTemNO2"
				+ ",HH_SmokeTemNO3"
				+ ",HH_SmokeTemNO4"
				+ ",HH_SmokeTemNO5"
				+ ",HH_SmokeTemNO6"
				+ ",HH_SmokeTemNO7"
				+ ",HH_SmokeTemNO8"
				+ ",HH_SmokeTemAverage"
				+ ",HH_CompressionPressNO1"
				+ ",HH_CompressionPressNO2"
				+ ",HH_CompressionPressNO3"
				+ ",HH_CompressionPressNO4"
				+ ",HH_CompressionPressNO5"
				+ ",HH_CompressionPressNO6"
				+ ",HH_CompressionPressNO7"
				+ ",HH_CompressionPressNO8"
				+ ",HH_CompressionPressAverage"
				+ ",HH_BoomPressNO1"
				+ ",HH_BoomPressNO2"
				+ ",HH_BoomPressNO3"
				+ ",HH_BoomPressNO4"
				+ ",HH_BoomPressNO5"
				+ ",HH_BoomPressNO6"
				+ ",HH_BoomPressNO7"
				+ ",HH_BoomPressNO8"
				+ ",HH_BoomPressAverage"
				+ ",HH_MeasureDate"
				+ ",HH_Model"
				+ ",HH_Load"
				+ ",HH_SeaArea"
				+ ",HH_Wind"
				+ ",HH_Wave"
				+ ",HH_BowDraft"
				+ ",HH_PoopDraft"
				+ ",HH_FireSequence"
				+ ",HH_FuelSpecification"
				+ ",HH_DailyConsumption"
				+ ",HH_CylinderConstant"
				+ ",HH_TotalKW"
				+ ",HH_TotalRatedPower"
				+ ",HH_TotalPower"
				+ ",HH_Speed"
				+ ",HH_SlipRate"
				+ ",HH_MaxExhaustTempDifference"
				+ ",HH_MaxCompressionPressDifference"
				+ ",HH_DetonationPressDifference"
				+ ",HH_FuelInTem"
				+ ",HH_FuelInViscosity"
				+ ",HH_Remarks"
				+ ",HH_ChiefSign"
				+ ",HH_ChiefSignDate"
				+ ",HH_DirectorSign"
				+ ",HH_DirectorSignDate"
				+ "  from T_REPORT_SHIPHOST ";
			DataTable dt;
			if(dbAccess.GetDataTable(sql,out dt, out err))
			{
				return dt;
			}
			else
			{
				throw new Exception(err);
			}
		}
		/// <summary>
		/// 根据一个主键ID,得到 T_REPORT_SHIPHOST 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>ReportShipHost DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql = "select "
				+ "Report_ShipHost_Id"
				+ ",SHIP_ID"
				+ ",File_ID"
				+ ",Voyage"
				+ ",TableWritedDate"
				+ ",Host_ParaAbstractedDate"
				+ ",Host_RecordDate"
				+ ",Host_Speed"
				+ ",Host_LoadInstruction"
				+ ",Host_SmokeHign_Tem"
				+ ",Host_SmokeHign_CylinderNO"
				+ ",Host_SmokeLow_Tem"
				+ ",Host_SmokeLow_CylinderNO"
				+ ",Host_LinerCoolWaterIn_Tem"
				+ ",Host_LinerCoolWaterOut_Tem"
				+ ",Host_PistonCoolantIn_Tem"
				+ ",Host_PistonCoolanOut_Tem"
				+ ",Host_CoolerBeforeNO1_Tem"
				+ ",Host_CoolerBeforeNO2_Tem"
				+ ",Host_CoolerBeforeNO3_Tem"
				+ ",Host_CoolerAfterNO1_Tem"
				+ ",Host_CoolerAfterNO2_Tem"
				+ ",Host_CoolerAfterNO3_Tem"
				+ ",Host_SternTube_Tem"
				+ ",Host_Cabin_Tem"
				+ ",Host_SeaWater_Tem"
				+ ",Host_CoolWaterHigh_MPa"
				+ ",Host_CoolWaterLow_MPa"
				+ ",Host_OilMain_Mpa"
				+ ",Host_OilCrosshead_Mpa"
				+ ",Host_PressurizedAir_Mpa"
				+ ",Host_FuelInto_Mpa"
				+ ",Host_ActualSpeed"
				+ ",Host_LossRate"
				+ ",Host_TurbochargerSpeedNO1"
				+ ",Host_TurbochargerSpeedNO2"
				+ ",HH_HighPumpNO1"
				+ ",HH_HighPumpNO2"
				+ ",HH_HighPumpNO3"
				+ ",HH_HighPumpNO4"
				+ ",HH_HighPumpNO5"
				+ ",HH_HighPumpNO6"
				+ ",HH_HighPumpNO7"
				+ ",HH_HighPumpNO8"
				+ ",HH_HighPumpAverage"
				+ ",HH_VITNO1"
				+ ",HH_VITNO2"
				+ ",HH_VITNO3"
				+ ",HH_VITNO4"
				+ ",HH_VITNO5"
				+ ",HH_VITNO6"
				+ ",HH_VITNO7"
				+ ",HH_VITNO8"
				+ ",HH_VITAverage"
				+ ",HH_SmokeTemNO1"
				+ ",HH_SmokeTemNO2"
				+ ",HH_SmokeTemNO3"
				+ ",HH_SmokeTemNO4"
				+ ",HH_SmokeTemNO5"
				+ ",HH_SmokeTemNO6"
				+ ",HH_SmokeTemNO7"
				+ ",HH_SmokeTemNO8"
				+ ",HH_SmokeTemAverage"
				+ ",HH_CompressionPressNO1"
				+ ",HH_CompressionPressNO2"
				+ ",HH_CompressionPressNO3"
				+ ",HH_CompressionPressNO4"
				+ ",HH_CompressionPressNO5"
				+ ",HH_CompressionPressNO6"
				+ ",HH_CompressionPressNO7"
				+ ",HH_CompressionPressNO8"
				+ ",HH_CompressionPressAverage"
				+ ",HH_BoomPressNO1"
				+ ",HH_BoomPressNO2"
				+ ",HH_BoomPressNO3"
				+ ",HH_BoomPressNO4"
				+ ",HH_BoomPressNO5"
				+ ",HH_BoomPressNO6"
				+ ",HH_BoomPressNO7"
				+ ",HH_BoomPressNO8"
				+ ",HH_BoomPressAverage"
				+ ",HH_MeasureDate"
				+ ",HH_Model"
				+ ",HH_Load"
				+ ",HH_SeaArea"
				+ ",HH_Wind"
				+ ",HH_Wave"
				+ ",HH_BowDraft"
				+ ",HH_PoopDraft"
				+ ",HH_FireSequence"
				+ ",HH_FuelSpecification"
				+ ",HH_DailyConsumption"
				+ ",HH_CylinderConstant"
				+ ",HH_TotalKW"
				+ ",HH_TotalRatedPower"
				+ ",HH_TotalPower"
				+ ",HH_Speed"
				+ ",HH_SlipRate"
				+ ",HH_MaxExhaustTempDifference"
				+ ",HH_MaxCompressionPressDifference"
				+ ",HH_DetonationPressDifference"
				+ ",HH_FuelInTem"
				+ ",HH_FuelInViscosity"
				+ ",HH_Remarks"
				+ ",HH_ChiefSign"
				+ ",HH_ChiefSignDate"
				+ ",HH_DirectorSign"
				+ ",HH_DirectorSignDate"
				+ " from T_REPORT_SHIPHOST "
				+ " where upper(Report_ShipHost_Id)='" + Id.ToUpper()+"'";
			DataTable dt;
			if(dbAccess.GetDataTable(sql,out dt, out err))
			{
				return dt;
			}
			else
			{
				throw new Exception(err);
			}
		}
        /// <summary>
		/// 根据reportshiphost 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>reportshiphost 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
		public ReportShipHost getObject(DataRow dr)
		{
			ReportShipHost unit=new ReportShipHost();
			if (null==dr)
			{
				unit.IsWrong = true;
				unit.WhyWrong = "从数据库获取信息时出错,未成功构造ReportShipHost类对象!";
				return unit;
			}
			if (DBNull.Value != dr["Report_ShipHost_Id"])	
			    unit.Report_ShipHost_Id=dr["Report_ShipHost_Id"].ToString();
			if (DBNull.Value != dr["SHIP_ID"])	
			    unit.SHIP_ID=dr["SHIP_ID"].ToString();
			if (DBNull.Value != dr["File_ID"])	
			    unit.File_ID=dr["File_ID"].ToString();
			if (DBNull.Value != dr["Voyage"])	
			    unit.Voyage=dr["Voyage"].ToString();
			if (DBNull.Value != dr["TableWritedDate"])	
                unit.TableWritedDate=(DateTime)dr["TableWritedDate"];
			if (DBNull.Value != dr["Host_ParaAbstractedDate"])	
                unit.Host_ParaAbstractedDate=(DateTime)dr["Host_ParaAbstractedDate"];
			if (DBNull.Value != dr["Host_RecordDate"])	
                unit.Host_RecordDate=(DateTime)dr["Host_RecordDate"];
			if (DBNull.Value != dr["Host_Speed"])	
			    unit.Host_Speed=dr["Host_Speed"].ToString();
			if (DBNull.Value != dr["Host_LoadInstruction"])	
			    unit.Host_LoadInstruction=dr["Host_LoadInstruction"].ToString();
			if (DBNull.Value != dr["Host_SmokeHign_Tem"])	
			    unit.Host_SmokeHign_Tem=dr["Host_SmokeHign_Tem"].ToString();
			if (DBNull.Value != dr["Host_SmokeHign_CylinderNO"])	
			    unit.Host_SmokeHign_CylinderNO=dr["Host_SmokeHign_CylinderNO"].ToString();
			if (DBNull.Value != dr["Host_SmokeLow_Tem"])	
			    unit.Host_SmokeLow_Tem=dr["Host_SmokeLow_Tem"].ToString();
			if (DBNull.Value != dr["Host_SmokeLow_CylinderNO"])	
			    unit.Host_SmokeLow_CylinderNO=dr["Host_SmokeLow_CylinderNO"].ToString();
			if (DBNull.Value != dr["Host_LinerCoolWaterIn_Tem"])	
			    unit.Host_LinerCoolWaterIn_Tem=dr["Host_LinerCoolWaterIn_Tem"].ToString();
			if (DBNull.Value != dr["Host_LinerCoolWaterOut_Tem"])	
			    unit.Host_LinerCoolWaterOut_Tem=dr["Host_LinerCoolWaterOut_Tem"].ToString();
			if (DBNull.Value != dr["Host_PistonCoolantIn_Tem"])	
			    unit.Host_PistonCoolantIn_Tem=dr["Host_PistonCoolantIn_Tem"].ToString();
			if (DBNull.Value != dr["Host_PistonCoolanOut_Tem"])	
			    unit.Host_PistonCoolanOut_Tem=dr["Host_PistonCoolanOut_Tem"].ToString();
			if (DBNull.Value != dr["Host_CoolerBeforeNO1_Tem"])	
			    unit.Host_CoolerBeforeNO1_Tem=dr["Host_CoolerBeforeNO1_Tem"].ToString();
			if (DBNull.Value != dr["Host_CoolerBeforeNO2_Tem"])	
			    unit.Host_CoolerBeforeNO2_Tem=dr["Host_CoolerBeforeNO2_Tem"].ToString();
			if (DBNull.Value != dr["Host_CoolerBeforeNO3_Tem"])	
			    unit.Host_CoolerBeforeNO3_Tem=dr["Host_CoolerBeforeNO3_Tem"].ToString();
			if (DBNull.Value != dr["Host_CoolerAfterNO1_Tem"])	
			    unit.Host_CoolerAfterNO1_Tem=dr["Host_CoolerAfterNO1_Tem"].ToString();
			if (DBNull.Value != dr["Host_CoolerAfterNO2_Tem"])	
			    unit.Host_CoolerAfterNO2_Tem=dr["Host_CoolerAfterNO2_Tem"].ToString();
			if (DBNull.Value != dr["Host_CoolerAfterNO3_Tem"])	
			    unit.Host_CoolerAfterNO3_Tem=dr["Host_CoolerAfterNO3_Tem"].ToString();
			if (DBNull.Value != dr["Host_SternTube_Tem"])	
			    unit.Host_SternTube_Tem=dr["Host_SternTube_Tem"].ToString();
			if (DBNull.Value != dr["Host_Cabin_Tem"])	
			    unit.Host_Cabin_Tem=dr["Host_Cabin_Tem"].ToString();
			if (DBNull.Value != dr["Host_SeaWater_Tem"])	
			    unit.Host_SeaWater_Tem=dr["Host_SeaWater_Tem"].ToString();
			if (DBNull.Value != dr["Host_CoolWaterHigh_MPa"])	
			    unit.Host_CoolWaterHigh_MPa=dr["Host_CoolWaterHigh_MPa"].ToString();
			if (DBNull.Value != dr["Host_CoolWaterLow_MPa"])	
			    unit.Host_CoolWaterLow_MPa=dr["Host_CoolWaterLow_MPa"].ToString();
			if (DBNull.Value != dr["Host_OilMain_Mpa"])	
			    unit.Host_OilMain_Mpa=dr["Host_OilMain_Mpa"].ToString();
			if (DBNull.Value != dr["Host_OilCrosshead_Mpa"])	
			    unit.Host_OilCrosshead_Mpa=dr["Host_OilCrosshead_Mpa"].ToString();
			if (DBNull.Value != dr["Host_PressurizedAir_Mpa"])	
			    unit.Host_PressurizedAir_Mpa=dr["Host_PressurizedAir_Mpa"].ToString();
			if (DBNull.Value != dr["Host_FuelInto_Mpa"])	
			    unit.Host_FuelInto_Mpa=dr["Host_FuelInto_Mpa"].ToString();
			if (DBNull.Value != dr["Host_ActualSpeed"])	
			    unit.Host_ActualSpeed=dr["Host_ActualSpeed"].ToString();
			if (DBNull.Value != dr["Host_LossRate"])	
			    unit.Host_LossRate=dr["Host_LossRate"].ToString();
			if (DBNull.Value != dr["Host_TurbochargerSpeedNO1"])	
			    unit.Host_TurbochargerSpeedNO1=dr["Host_TurbochargerSpeedNO1"].ToString();
			if (DBNull.Value != dr["Host_TurbochargerSpeedNO2"])	
			    unit.Host_TurbochargerSpeedNO2=dr["Host_TurbochargerSpeedNO2"].ToString();
			if (DBNull.Value != dr["HH_HighPumpNO1"])	
			    unit.HH_HighPumpNO1=dr["HH_HighPumpNO1"].ToString();
			if (DBNull.Value != dr["HH_HighPumpNO2"])	
			    unit.HH_HighPumpNO2=dr["HH_HighPumpNO2"].ToString();
			if (DBNull.Value != dr["HH_HighPumpNO3"])	
			    unit.HH_HighPumpNO3=dr["HH_HighPumpNO3"].ToString();
			if (DBNull.Value != dr["HH_HighPumpNO4"])	
			    unit.HH_HighPumpNO4=dr["HH_HighPumpNO4"].ToString();
			if (DBNull.Value != dr["HH_HighPumpNO5"])	
			    unit.HH_HighPumpNO5=dr["HH_HighPumpNO5"].ToString();
			if (DBNull.Value != dr["HH_HighPumpNO6"])	
			    unit.HH_HighPumpNO6=dr["HH_HighPumpNO6"].ToString();
			if (DBNull.Value != dr["HH_HighPumpNO7"])	
			    unit.HH_HighPumpNO7=dr["HH_HighPumpNO7"].ToString();
			if (DBNull.Value != dr["HH_HighPumpNO8"])	
			    unit.HH_HighPumpNO8=dr["HH_HighPumpNO8"].ToString();
			if (DBNull.Value != dr["HH_HighPumpAverage"])	
			    unit.HH_HighPumpAverage=dr["HH_HighPumpAverage"].ToString();
			if (DBNull.Value != dr["HH_VITNO1"])	
			    unit.HH_VITNO1=dr["HH_VITNO1"].ToString();
			if (DBNull.Value != dr["HH_VITNO2"])	
			    unit.HH_VITNO2=dr["HH_VITNO2"].ToString();
			if (DBNull.Value != dr["HH_VITNO3"])	
			    unit.HH_VITNO3=dr["HH_VITNO3"].ToString();
			if (DBNull.Value != dr["HH_VITNO4"])	
			    unit.HH_VITNO4=dr["HH_VITNO4"].ToString();
			if (DBNull.Value != dr["HH_VITNO5"])	
			    unit.HH_VITNO5=dr["HH_VITNO5"].ToString();
			if (DBNull.Value != dr["HH_VITNO6"])	
			    unit.HH_VITNO6=dr["HH_VITNO6"].ToString();
			if (DBNull.Value != dr["HH_VITNO7"])	
			    unit.HH_VITNO7=dr["HH_VITNO7"].ToString();
			if (DBNull.Value != dr["HH_VITNO8"])	
			    unit.HH_VITNO8=dr["HH_VITNO8"].ToString();
			if (DBNull.Value != dr["HH_VITAverage"])	
			    unit.HH_VITAverage=dr["HH_VITAverage"].ToString();
			if (DBNull.Value != dr["HH_SmokeTemNO1"])	
			    unit.HH_SmokeTemNO1=dr["HH_SmokeTemNO1"].ToString();
			if (DBNull.Value != dr["HH_SmokeTemNO2"])	
			    unit.HH_SmokeTemNO2=dr["HH_SmokeTemNO2"].ToString();
			if (DBNull.Value != dr["HH_SmokeTemNO3"])	
			    unit.HH_SmokeTemNO3=dr["HH_SmokeTemNO3"].ToString();
			if (DBNull.Value != dr["HH_SmokeTemNO4"])	
			    unit.HH_SmokeTemNO4=dr["HH_SmokeTemNO4"].ToString();
			if (DBNull.Value != dr["HH_SmokeTemNO5"])	
			    unit.HH_SmokeTemNO5=dr["HH_SmokeTemNO5"].ToString();
			if (DBNull.Value != dr["HH_SmokeTemNO6"])	
			    unit.HH_SmokeTemNO6=dr["HH_SmokeTemNO6"].ToString();
			if (DBNull.Value != dr["HH_SmokeTemNO7"])	
			    unit.HH_SmokeTemNO7=dr["HH_SmokeTemNO7"].ToString();
			if (DBNull.Value != dr["HH_SmokeTemNO8"])	
			    unit.HH_SmokeTemNO8=dr["HH_SmokeTemNO8"].ToString();
			if (DBNull.Value != dr["HH_SmokeTemAverage"])	
			    unit.HH_SmokeTemAverage=dr["HH_SmokeTemAverage"].ToString();
			if (DBNull.Value != dr["HH_CompressionPressNO1"])	
			    unit.HH_CompressionPressNO1=dr["HH_CompressionPressNO1"].ToString();
			if (DBNull.Value != dr["HH_CompressionPressNO2"])	
			    unit.HH_CompressionPressNO2=dr["HH_CompressionPressNO2"].ToString();
			if (DBNull.Value != dr["HH_CompressionPressNO3"])	
			    unit.HH_CompressionPressNO3=dr["HH_CompressionPressNO3"].ToString();
			if (DBNull.Value != dr["HH_CompressionPressNO4"])	
			    unit.HH_CompressionPressNO4=dr["HH_CompressionPressNO4"].ToString();
			if (DBNull.Value != dr["HH_CompressionPressNO5"])	
			    unit.HH_CompressionPressNO5=dr["HH_CompressionPressNO5"].ToString();
			if (DBNull.Value != dr["HH_CompressionPressNO6"])	
			    unit.HH_CompressionPressNO6=dr["HH_CompressionPressNO6"].ToString();
			if (DBNull.Value != dr["HH_CompressionPressNO7"])	
			    unit.HH_CompressionPressNO7=dr["HH_CompressionPressNO7"].ToString();
			if (DBNull.Value != dr["HH_CompressionPressNO8"])	
			    unit.HH_CompressionPressNO8=dr["HH_CompressionPressNO8"].ToString();
			if (DBNull.Value != dr["HH_CompressionPressAverage"])	
			    unit.HH_CompressionPressAverage=dr["HH_CompressionPressAverage"].ToString();
			if (DBNull.Value != dr["HH_BoomPressNO1"])	
			    unit.HH_BoomPressNO1=dr["HH_BoomPressNO1"].ToString();
			if (DBNull.Value != dr["HH_BoomPressNO2"])	
			    unit.HH_BoomPressNO2=dr["HH_BoomPressNO2"].ToString();
			if (DBNull.Value != dr["HH_BoomPressNO3"])	
			    unit.HH_BoomPressNO3=dr["HH_BoomPressNO3"].ToString();
			if (DBNull.Value != dr["HH_BoomPressNO4"])	
			    unit.HH_BoomPressNO4=dr["HH_BoomPressNO4"].ToString();
			if (DBNull.Value != dr["HH_BoomPressNO5"])	
			    unit.HH_BoomPressNO5=dr["HH_BoomPressNO5"].ToString();
			if (DBNull.Value != dr["HH_BoomPressNO6"])	
			    unit.HH_BoomPressNO6=dr["HH_BoomPressNO6"].ToString();
			if (DBNull.Value != dr["HH_BoomPressNO7"])	
			    unit.HH_BoomPressNO7=dr["HH_BoomPressNO7"].ToString();
			if (DBNull.Value != dr["HH_BoomPressNO8"])	
			    unit.HH_BoomPressNO8=dr["HH_BoomPressNO8"].ToString();
			if (DBNull.Value != dr["HH_BoomPressAverage"])	
			    unit.HH_BoomPressAverage=dr["HH_BoomPressAverage"].ToString();
			if (DBNull.Value != dr["HH_MeasureDate"])	
                unit.HH_MeasureDate=(DateTime)dr["HH_MeasureDate"];
			if (DBNull.Value != dr["HH_Model"])	
			    unit.HH_Model=dr["HH_Model"].ToString();
			if (DBNull.Value != dr["HH_Load"])	
			    unit.HH_Load=dr["HH_Load"].ToString();
			if (DBNull.Value != dr["HH_SeaArea"])	
			    unit.HH_SeaArea=dr["HH_SeaArea"].ToString();
			if (DBNull.Value != dr["HH_Wind"])	
			    unit.HH_Wind=dr["HH_Wind"].ToString();
			if (DBNull.Value != dr["HH_Wave"])	
			    unit.HH_Wave=dr["HH_Wave"].ToString();
			if (DBNull.Value != dr["HH_BowDraft"])	
			    unit.HH_BowDraft=dr["HH_BowDraft"].ToString();
			if (DBNull.Value != dr["HH_PoopDraft"])	
			    unit.HH_PoopDraft=dr["HH_PoopDraft"].ToString();
			if (DBNull.Value != dr["HH_FireSequence"])	
			    unit.HH_FireSequence=dr["HH_FireSequence"].ToString();
			if (DBNull.Value != dr["HH_FuelSpecification"])	
			    unit.HH_FuelSpecification=dr["HH_FuelSpecification"].ToString();
			if (DBNull.Value != dr["HH_DailyConsumption"])	
			    unit.HH_DailyConsumption=dr["HH_DailyConsumption"].ToString();
			if (DBNull.Value != dr["HH_CylinderConstant"])	
			    unit.HH_CylinderConstant=dr["HH_CylinderConstant"].ToString();
			if (DBNull.Value != dr["HH_TotalKW"])	
			    unit.HH_TotalKW=dr["HH_TotalKW"].ToString();
			if (DBNull.Value != dr["HH_TotalRatedPower"])	
			    unit.HH_TotalRatedPower=dr["HH_TotalRatedPower"].ToString();
			if (DBNull.Value != dr["HH_TotalPower"])	
			    unit.HH_TotalPower=dr["HH_TotalPower"].ToString();
			if (DBNull.Value != dr["HH_Speed"])	
			    unit.HH_Speed=dr["HH_Speed"].ToString();
			if (DBNull.Value != dr["HH_SlipRate"])	
			    unit.HH_SlipRate=dr["HH_SlipRate"].ToString();
			if (DBNull.Value != dr["HH_MaxExhaustTempDifference"])	
			    unit.HH_MaxExhaustTempDifference=dr["HH_MaxExhaustTempDifference"].ToString();
			if (DBNull.Value != dr["HH_MaxCompressionPressDifference"])	
			    unit.HH_MaxCompressionPressDifference=dr["HH_MaxCompressionPressDifference"].ToString();
			if (DBNull.Value != dr["HH_DetonationPressDifference"])	
			    unit.HH_DetonationPressDifference=dr["HH_DetonationPressDifference"].ToString();
			if (DBNull.Value != dr["HH_FuelInTem"])	
			    unit.HH_FuelInTem=dr["HH_FuelInTem"].ToString();
			if (DBNull.Value != dr["HH_FuelInViscosity"])	
			    unit.HH_FuelInViscosity=dr["HH_FuelInViscosity"].ToString();
			if (DBNull.Value != dr["HH_Remarks"])	
			    unit.HH_Remarks=dr["HH_Remarks"].ToString();
			if (DBNull.Value != dr["HH_ChiefSign"])	
			    unit.HH_ChiefSign=dr["HH_ChiefSign"].ToString();
			if (DBNull.Value != dr["HH_ChiefSignDate"])	
                unit.HH_ChiefSignDate=(DateTime)dr["HH_ChiefSignDate"];
			if (DBNull.Value != dr["HH_DirectorSign"])	
			    unit.HH_DirectorSign=dr["HH_DirectorSign"].ToString();
			if (DBNull.Value != dr["HH_DirectorSignDate"])	
                unit.HH_DirectorSignDate=(DateTime)dr["HH_DirectorSignDate"];
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个ReportShipHost对象.
		/// </summary>
		/// <param name="report_ShipHost_Id">report_ShipHost_Id</param>
		/// <returns>ReportShipHost对象</returns>
		public  ReportShipHost getObject(string Id,out string err)
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
    }
}
