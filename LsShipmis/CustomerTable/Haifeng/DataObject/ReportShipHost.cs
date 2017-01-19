/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：ReportShipHost.cs
 * 创 建 人：黄家龙
 * 创建时间：2011/8/25
 * 标    题：实体类
 * 功能描述：T_REPORT_SHIPHOST数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using CustomerTable.Haifeng.Services;

namespace CustomerTable.Haifeng.DataObject
{
	/// <summary>
	///T_REPORT_SHIPHOST数据实体.
	/// </summary>
	///[Serializable]
	public partial class ReportShipHost : CommonClass
	{		
		#region 构造函数
		///<summary> 
		///船舶主机工况报表.
		///</summary>
		public ReportShipHost()
		{
		}
		///<summary>
		///船舶主机工况报表.
		///</summary>
		public ReportShipHost
		(
			string report_ShipHost_Id,
			string sHIP_ID,
			string file_ID,
			string voyage,
			DateTime tableWritedDate,
			DateTime host_ParaAbstractedDate,
			DateTime host_RecordDate,
			string host_Speed,
			string host_LoadInstruction,
			string host_SmokeHign_Tem,
			string host_SmokeHign_CylinderNO,
			string host_SmokeLow_Tem,
			string host_SmokeLow_CylinderNO,
			string host_LinerCoolWaterIn_Tem,
			string host_LinerCoolWaterOut_Tem,
			string host_PistonCoolantIn_Tem,
			string host_PistonCoolanOut_Tem,
			string host_CoolerBeforeNO1_Tem,
			string host_CoolerBeforeNO2_Tem,
			string host_CoolerBeforeNO3_Tem,
			string host_CoolerAfterNO1_Tem,
			string host_CoolerAfterNO2_Tem,
			string host_CoolerAfterNO3_Tem,
			string host_SternTube_Tem,
			string host_Cabin_Tem,
			string host_SeaWater_Tem,
			string host_CoolWaterHigh_MPa,
			string host_CoolWaterLow_MPa,
			string host_OilMain_Mpa,
			string host_OilCrosshead_Mpa,
			string host_PressurizedAir_Mpa,
			string host_FuelInto_Mpa,
			string host_ActualSpeed,
			string host_LossRate,
			string host_TurbochargerSpeedNO1,
			string host_TurbochargerSpeedNO2,
			string hH_HighPumpNO1,
			string hH_HighPumpNO2,
			string hH_HighPumpNO3,
			string hH_HighPumpNO4,
			string hH_HighPumpNO5,
			string hH_HighPumpNO6,
			string hH_HighPumpNO7,
			string hH_HighPumpNO8,
			string hH_HighPumpAverage,
			string hH_VITNO1,
			string hH_VITNO2,
			string hH_VITNO3,
			string hH_VITNO4,
			string hH_VITNO5,
			string hH_VITNO6,
			string hH_VITNO7,
			string hH_VITNO8,
			string hH_VITAverage,
			string hH_SmokeTemNO1,
			string hH_SmokeTemNO2,
			string hH_SmokeTemNO3,
			string hH_SmokeTemNO4,
			string hH_SmokeTemNO5,
			string hH_SmokeTemNO6,
			string hH_SmokeTemNO7,
			string hH_SmokeTemNO8,
			string hH_SmokeTemAverage,
			string hH_CompressionPressNO1,
			string hH_CompressionPressNO2,
			string hH_CompressionPressNO3,
			string hH_CompressionPressNO4,
			string hH_CompressionPressNO5,
			string hH_CompressionPressNO6,
			string hH_CompressionPressNO7,
			string hH_CompressionPressNO8,
			string hH_CompressionPressAverage,
			string hH_BoomPressNO1,
			string hH_BoomPressNO2,
			string hH_BoomPressNO3,
			string hH_BoomPressNO4,
			string hH_BoomPressNO5,
			string hH_BoomPressNO6,
			string hH_BoomPressNO7,
			string hH_BoomPressNO8,
			string hH_BoomPressAverage,
			DateTime hH_MeasureDate,
			string hH_Model,
			string hH_Load,
			string hH_SeaArea,
			string hH_Wind,
			string hH_Wave,
			string hH_BowDraft,
			string hH_PoopDraft,
			string hH_FireSequence,
			string hH_FuelSpecification,
			string hH_DailyConsumption,
			string hH_CylinderConstant,
			string hH_TotalKW,
			string hH_TotalRatedPower,
			string hH_TotalPower,
			string hH_Speed,
			string hH_SlipRate,
			string hH_MaxExhaustTempDifference,
			string hH_MaxCompressionPressDifference,
			string hH_DetonationPressDifference,
			string hH_FuelInTem,
			string hH_FuelInViscosity,
			string hH_Remarks,
			string hH_ChiefSign,
			DateTime hH_ChiefSignDate,
			string hH_DirectorSign,
			DateTime hH_DirectorSignDate
		)
		{
			this.Report_ShipHost_Id               = report_ShipHost_Id;
			this.SHIP_ID                          = sHIP_ID;
			this.File_ID                          = file_ID;
			this.Voyage                           = voyage;
			this.TableWritedDate                  = tableWritedDate;
			this.Host_ParaAbstractedDate          = host_ParaAbstractedDate;
			this.Host_RecordDate                  = host_RecordDate;
			this.Host_Speed                       = host_Speed;
			this.Host_LoadInstruction             = host_LoadInstruction;
			this.Host_SmokeHign_Tem               = host_SmokeHign_Tem;
			this.Host_SmokeHign_CylinderNO        = host_SmokeHign_CylinderNO;
			this.Host_SmokeLow_Tem                = host_SmokeLow_Tem;
			this.Host_SmokeLow_CylinderNO         = host_SmokeLow_CylinderNO;
			this.Host_LinerCoolWaterIn_Tem        = host_LinerCoolWaterIn_Tem;
			this.Host_LinerCoolWaterOut_Tem       = host_LinerCoolWaterOut_Tem;
			this.Host_PistonCoolantIn_Tem         = host_PistonCoolantIn_Tem;
			this.Host_PistonCoolanOut_Tem         = host_PistonCoolanOut_Tem;
			this.Host_CoolerBeforeNO1_Tem         = host_CoolerBeforeNO1_Tem;
			this.Host_CoolerBeforeNO2_Tem         = host_CoolerBeforeNO2_Tem;
			this.Host_CoolerBeforeNO3_Tem         = host_CoolerBeforeNO3_Tem;
			this.Host_CoolerAfterNO1_Tem          = host_CoolerAfterNO1_Tem;
			this.Host_CoolerAfterNO2_Tem          = host_CoolerAfterNO2_Tem;
			this.Host_CoolerAfterNO3_Tem          = host_CoolerAfterNO3_Tem;
			this.Host_SternTube_Tem               = host_SternTube_Tem;
			this.Host_Cabin_Tem                   = host_Cabin_Tem;
			this.Host_SeaWater_Tem                = host_SeaWater_Tem;
			this.Host_CoolWaterHigh_MPa           = host_CoolWaterHigh_MPa;
			this.Host_CoolWaterLow_MPa            = host_CoolWaterLow_MPa;
			this.Host_OilMain_Mpa                 = host_OilMain_Mpa;
			this.Host_OilCrosshead_Mpa            = host_OilCrosshead_Mpa;
			this.Host_PressurizedAir_Mpa          = host_PressurizedAir_Mpa;
			this.Host_FuelInto_Mpa                = host_FuelInto_Mpa;
			this.Host_ActualSpeed                 = host_ActualSpeed;
			this.Host_LossRate                    = host_LossRate;
			this.Host_TurbochargerSpeedNO1        = host_TurbochargerSpeedNO1;
			this.Host_TurbochargerSpeedNO2        = host_TurbochargerSpeedNO2;
			this.HH_HighPumpNO1                   = hH_HighPumpNO1;
			this.HH_HighPumpNO2                   = hH_HighPumpNO2;
			this.HH_HighPumpNO3                   = hH_HighPumpNO3;
			this.HH_HighPumpNO4                   = hH_HighPumpNO4;
			this.HH_HighPumpNO5                   = hH_HighPumpNO5;
			this.HH_HighPumpNO6                   = hH_HighPumpNO6;
			this.HH_HighPumpNO7                   = hH_HighPumpNO7;
			this.HH_HighPumpNO8                   = hH_HighPumpNO8;
			this.HH_HighPumpAverage               = hH_HighPumpAverage;
			this.HH_VITNO1                        = hH_VITNO1;
			this.HH_VITNO2                        = hH_VITNO2;
			this.HH_VITNO3                        = hH_VITNO3;
			this.HH_VITNO4                        = hH_VITNO4;
			this.HH_VITNO5                        = hH_VITNO5;
			this.HH_VITNO6                        = hH_VITNO6;
			this.HH_VITNO7                        = hH_VITNO7;
			this.HH_VITNO8                        = hH_VITNO8;
			this.HH_VITAverage                    = hH_VITAverage;
			this.HH_SmokeTemNO1                   = hH_SmokeTemNO1;
			this.HH_SmokeTemNO2                   = hH_SmokeTemNO2;
			this.HH_SmokeTemNO3                   = hH_SmokeTemNO3;
			this.HH_SmokeTemNO4                   = hH_SmokeTemNO4;
			this.HH_SmokeTemNO5                   = hH_SmokeTemNO5;
			this.HH_SmokeTemNO6                   = hH_SmokeTemNO6;
			this.HH_SmokeTemNO7                   = hH_SmokeTemNO7;
			this.HH_SmokeTemNO8                   = hH_SmokeTemNO8;
			this.HH_SmokeTemAverage               = hH_SmokeTemAverage;
			this.HH_CompressionPressNO1           = hH_CompressionPressNO1;
			this.HH_CompressionPressNO2           = hH_CompressionPressNO2;
			this.HH_CompressionPressNO3           = hH_CompressionPressNO3;
			this.HH_CompressionPressNO4           = hH_CompressionPressNO4;
			this.HH_CompressionPressNO5           = hH_CompressionPressNO5;
			this.HH_CompressionPressNO6           = hH_CompressionPressNO6;
			this.HH_CompressionPressNO7           = hH_CompressionPressNO7;
			this.HH_CompressionPressNO8           = hH_CompressionPressNO8;
			this.HH_CompressionPressAverage       = hH_CompressionPressAverage;
			this.HH_BoomPressNO1                  = hH_BoomPressNO1;
			this.HH_BoomPressNO2                  = hH_BoomPressNO2;
			this.HH_BoomPressNO3                  = hH_BoomPressNO3;
			this.HH_BoomPressNO4                  = hH_BoomPressNO4;
			this.HH_BoomPressNO5                  = hH_BoomPressNO5;
			this.HH_BoomPressNO6                  = hH_BoomPressNO6;
			this.HH_BoomPressNO7                  = hH_BoomPressNO7;
			this.HH_BoomPressNO8                  = hH_BoomPressNO8;
			this.HH_BoomPressAverage              = hH_BoomPressAverage;
			this.HH_MeasureDate                   = hH_MeasureDate;
			this.HH_Model                         = hH_Model;
			this.HH_Load                          = hH_Load;
			this.HH_SeaArea                       = hH_SeaArea;
			this.HH_Wind                          = hH_Wind;
			this.HH_Wave                          = hH_Wave;
			this.HH_BowDraft                      = hH_BowDraft;
			this.HH_PoopDraft                     = hH_PoopDraft;
			this.HH_FireSequence                  = hH_FireSequence;
			this.HH_FuelSpecification             = hH_FuelSpecification;
			this.HH_DailyConsumption              = hH_DailyConsumption;
			this.HH_CylinderConstant              = hH_CylinderConstant;
			this.HH_TotalKW                       = hH_TotalKW;
			this.HH_TotalRatedPower               = hH_TotalRatedPower;
			this.HH_TotalPower                    = hH_TotalPower;
			this.HH_Speed                         = hH_Speed;
			this.HH_SlipRate                      = hH_SlipRate;
			this.HH_MaxExhaustTempDifference      = hH_MaxExhaustTempDifference;
			this.HH_MaxCompressionPressDifference = hH_MaxCompressionPressDifference;
			this.HH_DetonationPressDifference     = hH_DetonationPressDifference;
			this.HH_FuelInTem                     = hH_FuelInTem;
			this.HH_FuelInViscosity               = hH_FuelInViscosity;
			this.HH_Remarks                       = hH_Remarks;
			this.HH_ChiefSign                     = hH_ChiefSign;
			this.HH_ChiefSignDate                 = hH_ChiefSignDate;
			this.HH_DirectorSign                  = hH_DirectorSign;
			this.HH_DirectorSignDate              = hH_DirectorSignDate;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///主键.
		///</summary>
		public string Report_ShipHost_Id{get ;set;}

		///<summary>
		///船舶ID
		///</summary>
		public string SHIP_ID{get ;set;}

		///<summary>
		///文件ID
		///</summary>
		public string File_ID{get ;set;}

		///<summary>
		///航次.
		///</summary>
		public string Voyage{get ;set;}

		///<summary>
		///填表日期.
		///</summary>
		public DateTime TableWritedDate{get ;set;}

		///<summary>
		///主机参数摘录日期.
		///</summary>
		public DateTime Host_ParaAbstractedDate{get ;set;}

		///<summary>
		///主机记录日期.
		///</summary>
		public DateTime Host_RecordDate{get ;set;}

		///<summary>
		///主机转速.
		///</summary>
		public string Host_Speed{get ;set;}

		///<summary>
		///负荷指示.
		///</summary>
		public string Host_LoadInstruction{get ;set;}

		///<summary>
		///排烟温度最高温度.
		///</summary>
		public string Host_SmokeHign_Tem{get ;set;}

		///<summary>
		///排烟温度最高温度缸号.
		///</summary>
		public string Host_SmokeHign_CylinderNO{get ;set;}

		///<summary>
		///排烟温度最低温度.
		///</summary>
		public string Host_SmokeLow_Tem{get ;set;}

		///<summary>
		///排烟温度最低温度缸号.
		///</summary>
		public string Host_SmokeLow_CylinderNO{get ;set;}

		///<summary>
		///缸套冷却水进机温度.
		///</summary>
		public string Host_LinerCoolWaterIn_Tem{get ;set;}

		///<summary>
		///缸套冷却水出机温度.
		///</summary>
		public string Host_LinerCoolWaterOut_Tem{get ;set;}

		///<summary>
		///活塞冷却液进机温度.
		///</summary>
		public string Host_PistonCoolantIn_Tem{get ;set;}

		///<summary>
		///活塞冷却液出机温度.
		///</summary>
		public string Host_PistonCoolanOut_Tem{get ;set;}

		///<summary>
		///空气冷却器增压空气冷却前NO1
		///</summary>
		public string Host_CoolerBeforeNO1_Tem{get ;set;}

		///<summary>
		///空气冷却器增压空气冷却前NO2
		///</summary>
		public string Host_CoolerBeforeNO2_Tem{get ;set;}

		///<summary>
		///空气冷却器增压空气冷却前NO3
		///</summary>
		public string Host_CoolerBeforeNO3_Tem{get ;set;}

		///<summary>
		///空气冷却器增压空气冷却后NO1
		///</summary>
		public string Host_CoolerAfterNO1_Tem{get ;set;}

		///<summary>
		///空气冷却器增压空气冷却后NO2
		///</summary>
		public string Host_CoolerAfterNO2_Tem{get ;set;}

		///<summary>
		///空气冷却器增压空气冷却后NO3
		///</summary>
		public string Host_CoolerAfterNO3_Tem{get ;set;}

		///<summary>
		///艉轴温度.
		///</summary>
		public string Host_SternTube_Tem{get ;set;}

		///<summary>
		///机舱.
		///</summary>
		public string Host_Cabin_Tem{get ;set;}

		///<summary>
		///海水.
		///</summary>
		public string Host_SeaWater_Tem{get ;set;}

		///<summary>
		///冷 却淡 水高温.
		///</summary>
		public string Host_CoolWaterHigh_MPa{get ;set;}

		///<summary>
		///冷 却.
		///淡 水.
		///低温.
		///</summary>
		public string Host_CoolWaterLow_MPa{get ;set;}

		///<summary>
		///滑 油主轴承.
		///</summary>
		public string Host_OilMain_Mpa{get ;set;}

		///<summary>
		///滑 油十字头.
		///</summary>
		public string Host_OilCrosshead_Mpa{get ;set;}

		///<summary>
		///增压空气.
		///</summary>
		public string Host_PressurizedAir_Mpa{get ;set;}

		///<summary>
		///燃油进机.
		///</summary>
		public string Host_FuelInto_Mpa{get ;set;}

		///<summary>
		///实际航速Kn
		///</summary>
		public string Host_ActualSpeed{get ;set;}

		///<summary>
		///滑失率%
		///</summary>
		public string Host_LossRate{get ;set;}

		///<summary>
		///增压器转速(r/min)No.1
		///</summary>
		public string Host_TurbochargerSpeedNO1{get ;set;}

		///<summary>
		///增压器转速(r/min)No.2
		///</summary>
		public string Host_TurbochargerSpeedNO2{get ;set;}

		///<summary>
		///高压油泵油门刻度NO1
		///</summary>
		public string HH_HighPumpNO1{get ;set;}

		///<summary>
		///高压油泵油门刻度NO2
		///</summary>
		public string HH_HighPumpNO2{get ;set;}

		///<summary>
		///高压油泵油门刻度NO3
		///</summary>
		public string HH_HighPumpNO3{get ;set;}

		///<summary>
		///高压油泵油门刻度NO4
		///</summary>
		public string HH_HighPumpNO4{get ;set;}

		///<summary>
		///高压油泵油门刻度NO5
		///</summary>
		public string HH_HighPumpNO5{get ;set;}

		///<summary>
		///高压油泵油门刻度NO6
		///</summary>
		public string HH_HighPumpNO6{get ;set;}

		///<summary>
		///高压油泵油门刻度NO7
		///</summary>
		public string HH_HighPumpNO7{get ;set;}

		///<summary>
		///高压油泵油门刻度NO8
		///</summary>
		public string HH_HighPumpNO8{get ;set;}

		///<summary>
		///高压油泵油门刻度平均值.
		///</summary>
		public string HH_HighPumpAverage{get ;set;}

		///<summary>
		///VIT指示刻度NO1
		///</summary>
		public string HH_VITNO1{get ;set;}

		///<summary>
		///VIT指示刻度NO2
		///</summary>
		public string HH_VITNO2{get ;set;}

		///<summary>
		///VIT指示刻度NO3
		///</summary>
		public string HH_VITNO3{get ;set;}

		///<summary>
		///VIT指示刻度NO4
		///</summary>
		public string HH_VITNO4{get ;set;}

		///<summary>
		///VIT指示刻度NO5
		///</summary>
		public string HH_VITNO5{get ;set;}

		///<summary>
		///VIT指示刻度NO6
		///</summary>
		public string HH_VITNO6{get ;set;}

		///<summary>
		///VIT指示刻度NO7
		///</summary>
		public string HH_VITNO7{get ;set;}

		///<summary>
		///VIT指示刻度NO8
		///</summary>
		public string HH_VITNO8{get ;set;}

		///<summary>
		///VIT指示刻度平均值.
		///</summary>
		public string HH_VITAverage{get ;set;}

		///<summary>
		///排烟温度NO1
		///</summary>
		public string HH_SmokeTemNO1{get ;set;}

		///<summary>
		///排烟温度NO2
		///</summary>
		public string HH_SmokeTemNO2{get ;set;}

		///<summary>
		///排烟温度NO3
		///</summary>
		public string HH_SmokeTemNO3{get ;set;}

		///<summary>
		///排烟温度NO4
		///</summary>
		public string HH_SmokeTemNO4{get ;set;}

		///<summary>
		///排烟温度NO5
		///</summary>
		public string HH_SmokeTemNO5{get ;set;}

		///<summary>
		///排烟温度NO6
		///</summary>
		public string HH_SmokeTemNO6{get ;set;}

		///<summary>
		///排烟温度NO7
		///</summary>
		public string HH_SmokeTemNO7{get ;set;}

		///<summary>
		///排烟温度NO8
		///</summary>
		public string HH_SmokeTemNO8{get ;set;}

		///<summary>
		///排烟温度平均值.
		///</summary>
		public string HH_SmokeTemAverage{get ;set;}

		///<summary>
		///压缩压力NO1
		///</summary>
		public string HH_CompressionPressNO1{get ;set;}

		///<summary>
		///压缩压力NO2
		///</summary>
		public string HH_CompressionPressNO2{get ;set;}

		///<summary>
		///压缩压力NO3
		///</summary>
		public string HH_CompressionPressNO3{get ;set;}

		///<summary>
		///压缩压力NO4
		///</summary>
		public string HH_CompressionPressNO4{get ;set;}

		///<summary>
		///压缩压力NO5
		///</summary>
		public string HH_CompressionPressNO5{get ;set;}

		///<summary>
		///压缩压力NO6
		///</summary>
		public string HH_CompressionPressNO6{get ;set;}

		///<summary>
		///压缩压力NO7
		///</summary>
		public string HH_CompressionPressNO7{get ;set;}

		///<summary>
		///压缩压力NO8
		///</summary>
		public string HH_CompressionPressNO8{get ;set;}

		///<summary>
		///压缩压力平均值.
		///</summary>
		public string HH_CompressionPressAverage{get ;set;}

		///<summary>
		///爆炸压力NO1
		///</summary>
		public string HH_BoomPressNO1{get ;set;}

		///<summary>
		///爆炸压力NO2
		///</summary>
		public string HH_BoomPressNO2{get ;set;}

		///<summary>
		///爆炸压力NO3
		///</summary>
		public string HH_BoomPressNO3{get ;set;}

		///<summary>
		///爆炸压力NO4
		///</summary>
		public string HH_BoomPressNO4{get ;set;}

		///<summary>
		///爆炸压力NO5
		///</summary>
		public string HH_BoomPressNO5{get ;set;}

		///<summary>
		///爆炸压力NO6
		///</summary>
		public string HH_BoomPressNO6{get ;set;}

		///<summary>
		///爆炸压力NO7
		///</summary>
		public string HH_BoomPressNO7{get ;set;}

		///<summary>
		///爆炸压力NO8
		///</summary>
		public string HH_BoomPressNO8{get ;set;}

		///<summary>
		///爆炸压力平均值.
		///</summary>
		public string HH_BoomPressAverage{get ;set;}

		///<summary>
		///测  量  日  期.
		///</summary>
		public DateTime HH_MeasureDate{get ;set;}

		///<summary>
		///主机型号.
		///</summary>
		public string HH_Model{get ;set;}

		///<summary>
		///装载情况(吨)
		///</summary>
		public string HH_Load{get ;set;}

		///<summary>
		///海 区.
		///</summary>
		public string HH_SeaArea{get ;set;}

		///<summary>
		///风.
		///</summary>
		public string HH_Wind{get ;set;}

		///<summary>
		///浪.
		///</summary>
		public string HH_Wave{get ;set;}

		///<summary>
		///船艏吃水(m)
		///</summary>
		public string HH_BowDraft{get ;set;}

		///<summary>
		///船艉吃水(m)
		///</summary>
		public string HH_PoopDraft{get ;set;}

		///<summary>
		///发火顺序.
		///</summary>
		public string HH_FireSequence{get ;set;}

		///<summary>
		///燃油规格.
		///</summary>
		public string HH_FuelSpecification{get ;set;}

		///<summary>
		///日消耗量(吨)
		///</summary>
		public string HH_DailyConsumption{get ;set;}

		///<summary>
		///气缸常数.
		///</summary>
		public string HH_CylinderConstant{get ;set;}

		///<summary>
		///总功率(kW)
		///</summary>
		public string HH_TotalKW{get ;set;}

		///<summary>
		///占额定功率(%)
		///</summary>
		public string HH_TotalRatedPower{get ;set;}

		///<summary>
		///额定功率(kW)
		///</summary>
		public string HH_TotalPower{get ;set;}

		///<summary>
		///转速（RPM）.
		///</summary>
		public string HH_Speed{get ;set;}

		///<summary>
		///滑失率(%)
		///</summary>
		public string HH_SlipRate{get ;set;}

		///<summary>
		///排温最大差值.
		///</summary>
		public string HH_MaxExhaustTempDifference{get ;set;}

		///<summary>
		///压缩压力最大差值(MPa)
		///</summary>
		public string HH_MaxCompressionPressDifference{get ;set;}

		///<summary>
		///爆压最大差值(MPa)
		///</summary>
		public string HH_DetonationPressDifference{get ;set;}

		///<summary>
		///燃油进机温度.
		///</summary>
		public string HH_FuelInTem{get ;set;}

		///<summary>
		///燃油进机粘度.
		///</summary>
		public string HH_FuelInViscosity{get ;set;}

		///<summary>
		///备注：.
		///</summary>
		public string HH_Remarks{get ;set;}

		///<summary>
		///轮机长签名.
		///</summary>
		public string HH_ChiefSign{get ;set;}

		///<summary>
		///轮机长签名日期.
		///</summary>
		public DateTime HH_ChiefSignDate{get ;set;}

		///<summary>
		///机务主管签名.
		///</summary>
		public string HH_DirectorSign{get ;set;}

		///<summary>
		///机务主管签名日期.
		///</summary>
		public DateTime HH_DirectorSignDate{get ;set;}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public override CommonClass Clone()
		{
			ReportShipHost Unit = new ReportShipHost();
			Unit.Report_ShipHost_Id=this.Report_ShipHost_Id;
			Unit.SHIP_ID=this.SHIP_ID;
			Unit.File_ID=this.File_ID;
			Unit.Voyage=this.Voyage;
			Unit.TableWritedDate=this.TableWritedDate;
			Unit.Host_ParaAbstractedDate=this.Host_ParaAbstractedDate;
			Unit.Host_RecordDate=this.Host_RecordDate;
			Unit.Host_Speed=this.Host_Speed;
			Unit.Host_LoadInstruction=this.Host_LoadInstruction;
			Unit.Host_SmokeHign_Tem=this.Host_SmokeHign_Tem;
			Unit.Host_SmokeHign_CylinderNO=this.Host_SmokeHign_CylinderNO;
			Unit.Host_SmokeLow_Tem=this.Host_SmokeLow_Tem;
			Unit.Host_SmokeLow_CylinderNO=this.Host_SmokeLow_CylinderNO;
			Unit.Host_LinerCoolWaterIn_Tem=this.Host_LinerCoolWaterIn_Tem;
			Unit.Host_LinerCoolWaterOut_Tem=this.Host_LinerCoolWaterOut_Tem;
			Unit.Host_PistonCoolantIn_Tem=this.Host_PistonCoolantIn_Tem;
			Unit.Host_PistonCoolanOut_Tem=this.Host_PistonCoolanOut_Tem;
			Unit.Host_CoolerBeforeNO1_Tem=this.Host_CoolerBeforeNO1_Tem;
			Unit.Host_CoolerBeforeNO2_Tem=this.Host_CoolerBeforeNO2_Tem;
			Unit.Host_CoolerBeforeNO3_Tem=this.Host_CoolerBeforeNO3_Tem;
			Unit.Host_CoolerAfterNO1_Tem=this.Host_CoolerAfterNO1_Tem;
			Unit.Host_CoolerAfterNO2_Tem=this.Host_CoolerAfterNO2_Tem;
			Unit.Host_CoolerAfterNO3_Tem=this.Host_CoolerAfterNO3_Tem;
			Unit.Host_SternTube_Tem=this.Host_SternTube_Tem;
			Unit.Host_Cabin_Tem=this.Host_Cabin_Tem;
			Unit.Host_SeaWater_Tem=this.Host_SeaWater_Tem;
			Unit.Host_CoolWaterHigh_MPa=this.Host_CoolWaterHigh_MPa;
			Unit.Host_CoolWaterLow_MPa=this.Host_CoolWaterLow_MPa;
			Unit.Host_OilMain_Mpa=this.Host_OilMain_Mpa;
			Unit.Host_OilCrosshead_Mpa=this.Host_OilCrosshead_Mpa;
			Unit.Host_PressurizedAir_Mpa=this.Host_PressurizedAir_Mpa;
			Unit.Host_FuelInto_Mpa=this.Host_FuelInto_Mpa;
			Unit.Host_ActualSpeed=this.Host_ActualSpeed;
			Unit.Host_LossRate=this.Host_LossRate;
			Unit.Host_TurbochargerSpeedNO1=this.Host_TurbochargerSpeedNO1;
			Unit.Host_TurbochargerSpeedNO2=this.Host_TurbochargerSpeedNO2;
			Unit.HH_HighPumpNO1=this.HH_HighPumpNO1;
			Unit.HH_HighPumpNO2=this.HH_HighPumpNO2;
			Unit.HH_HighPumpNO3=this.HH_HighPumpNO3;
			Unit.HH_HighPumpNO4=this.HH_HighPumpNO4;
			Unit.HH_HighPumpNO5=this.HH_HighPumpNO5;
			Unit.HH_HighPumpNO6=this.HH_HighPumpNO6;
			Unit.HH_HighPumpNO7=this.HH_HighPumpNO7;
			Unit.HH_HighPumpNO8=this.HH_HighPumpNO8;
			Unit.HH_HighPumpAverage=this.HH_HighPumpAverage;
			Unit.HH_VITNO1=this.HH_VITNO1;
			Unit.HH_VITNO2=this.HH_VITNO2;
			Unit.HH_VITNO3=this.HH_VITNO3;
			Unit.HH_VITNO4=this.HH_VITNO4;
			Unit.HH_VITNO5=this.HH_VITNO5;
			Unit.HH_VITNO6=this.HH_VITNO6;
			Unit.HH_VITNO7=this.HH_VITNO7;
			Unit.HH_VITNO8=this.HH_VITNO8;
			Unit.HH_VITAverage=this.HH_VITAverage;
			Unit.HH_SmokeTemNO1=this.HH_SmokeTemNO1;
			Unit.HH_SmokeTemNO2=this.HH_SmokeTemNO2;
			Unit.HH_SmokeTemNO3=this.HH_SmokeTemNO3;
			Unit.HH_SmokeTemNO4=this.HH_SmokeTemNO4;
			Unit.HH_SmokeTemNO5=this.HH_SmokeTemNO5;
			Unit.HH_SmokeTemNO6=this.HH_SmokeTemNO6;
			Unit.HH_SmokeTemNO7=this.HH_SmokeTemNO7;
			Unit.HH_SmokeTemNO8=this.HH_SmokeTemNO8;
			Unit.HH_SmokeTemAverage=this.HH_SmokeTemAverage;
			Unit.HH_CompressionPressNO1=this.HH_CompressionPressNO1;
			Unit.HH_CompressionPressNO2=this.HH_CompressionPressNO2;
			Unit.HH_CompressionPressNO3=this.HH_CompressionPressNO3;
			Unit.HH_CompressionPressNO4=this.HH_CompressionPressNO4;
			Unit.HH_CompressionPressNO5=this.HH_CompressionPressNO5;
			Unit.HH_CompressionPressNO6=this.HH_CompressionPressNO6;
			Unit.HH_CompressionPressNO7=this.HH_CompressionPressNO7;
			Unit.HH_CompressionPressNO8=this.HH_CompressionPressNO8;
			Unit.HH_CompressionPressAverage=this.HH_CompressionPressAverage;
			Unit.HH_BoomPressNO1=this.HH_BoomPressNO1;
			Unit.HH_BoomPressNO2=this.HH_BoomPressNO2;
			Unit.HH_BoomPressNO3=this.HH_BoomPressNO3;
			Unit.HH_BoomPressNO4=this.HH_BoomPressNO4;
			Unit.HH_BoomPressNO5=this.HH_BoomPressNO5;
			Unit.HH_BoomPressNO6=this.HH_BoomPressNO6;
			Unit.HH_BoomPressNO7=this.HH_BoomPressNO7;
			Unit.HH_BoomPressNO8=this.HH_BoomPressNO8;
			Unit.HH_BoomPressAverage=this.HH_BoomPressAverage;
			Unit.HH_MeasureDate=this.HH_MeasureDate;
			Unit.HH_Model=this.HH_Model;
			Unit.HH_Load=this.HH_Load;
			Unit.HH_SeaArea=this.HH_SeaArea;
			Unit.HH_Wind=this.HH_Wind;
			Unit.HH_Wave=this.HH_Wave;
			Unit.HH_BowDraft=this.HH_BowDraft;
			Unit.HH_PoopDraft=this.HH_PoopDraft;
			Unit.HH_FireSequence=this.HH_FireSequence;
			Unit.HH_FuelSpecification=this.HH_FuelSpecification;
			Unit.HH_DailyConsumption=this.HH_DailyConsumption;
			Unit.HH_CylinderConstant=this.HH_CylinderConstant;
			Unit.HH_TotalKW=this.HH_TotalKW;
			Unit.HH_TotalRatedPower=this.HH_TotalRatedPower;
			Unit.HH_TotalPower=this.HH_TotalPower;
			Unit.HH_Speed=this.HH_Speed;
			Unit.HH_SlipRate=this.HH_SlipRate;
			Unit.HH_MaxExhaustTempDifference=this.HH_MaxExhaustTempDifference;
			Unit.HH_MaxCompressionPressDifference=this.HH_MaxCompressionPressDifference;
			Unit.HH_DetonationPressDifference=this.HH_DetonationPressDifference;
			Unit.HH_FuelInTem=this.HH_FuelInTem;
			Unit.HH_FuelInViscosity=this.HH_FuelInViscosity;
			Unit.HH_Remarks=this.HH_Remarks;
			Unit.HH_ChiefSign=this.HH_ChiefSign;
			Unit.HH_ChiefSignDate=this.HH_ChiefSignDate;
			Unit.HH_DirectorSign=this.HH_DirectorSign;
			Unit.HH_DirectorSignDate=this.HH_DirectorSignDate;
            return Unit;
		}
		#endregion
		
		public override string GetId()
        {
            return this.Report_ShipHost_Id;
        }

        public override string GetTypeName()
        {
            return "ReportShipHost";
        }

        public override bool Update(out string err)
        {
            return ReportShipHostService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return ReportShipHostService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
