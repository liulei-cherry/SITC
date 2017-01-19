/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：ReportMajorEquipment.cs
 * 创 建 人：黄家龙
 * 创建时间：2011/9/1
 * 标    题：实体类
 * 功能描述：T_REPORT_MAJOREQUIPTIME数据实体类
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
	///T_REPORT_MAJOREQUIPTIME数据实体.
	/// </summary>
	///[Serializable]
	public partial class ReportMajorEquipment : CommonClass
	{		
		#region 构造函数
		///<summary> 
		///机舱主要设备运行时间统计表.
		///</summary>
		public ReportMajorEquipment()
		{
		}
		///<summary>
		///机舱主要设备运行时间统计表.
		///</summary>
		public ReportMajorEquipment
		(
			string report_MajorEquipTime_Id,
			string sHIP_ID,
			string file_ID,
			string voyage,
			string cabin_HostTotal,
			DateTime cabin_StatisticsDate,
			string host_CylinderRenewalNO1,
			string host_CylinderRenewalNO2,
			string host_CylinderRenewalNO3,
			string host_CylinderRenewalNO4,
			string host_CylinderRenewalNO5,
			string host_CylinderRenewalNO6,
			string host_CylinderRenewalNO7,
			string host_CylinderRenewalNO8,
			string host_CylinderRenewalNO9,
			string host_LiftingCylinderNO1,
			string host_LiftingCylinderNO2,
			string host_LiftingCylinderNO3,
			string host_LiftingCylinderNO4,
			string host_LiftingCylinderNO5,
			string host_LiftingCylinderNO6,
			string host_LiftingCylinderNO7,
			string host_LiftingCylinderNO8,
			string host_LiftingCylinderNO9,
			string host_ExhaustExchangeNO1,
			string host_ExhaustExchangeNO2,
			string host_ExhaustExchangeNO3,
			string host_ExhaustExchangeNO4,
			string host_ExhaustExchangeNO5,
			string host_ExhaustExchangeNO6,
			string host_ExhaustExchangeNO7,
			string host_ExhaustExchangeNO8,
			string host_ExhaustExchangeNO9,
			string host_OilHeadCheckNO1,
			string host_OilHeadCheckNO2,
			string host_OilHeadCheckNO3,
			string host_OilHeadCheckNO4,
			string host_OilHeadCheckNO5,
			string host_OilHeadCheckNO6,
			string host_OilHeadCheckNO7,
			string host_OilHeadCheckNO8,
			string host_OilHeadCheckNO9,
			string host_CrossheadBearNO1,
			string host_CrossheadBearNO2,
			string host_CrossheadBearNO3,
			string host_CrossheadBearNO4,
			string host_CrossheadBearNO5,
			string host_CrossheadBearNO6,
			string host_CrossheadBearNO7,
			string host_CrossheadBearNO8,
			string host_CrossheadBearNO9,
			string host_ConnectRodBearNO1,
			string host_ConnectRodBearNO2,
			string host_ConnectRodBearNO3,
			string host_ConnectRodBearNO4,
			string host_ConnectRodBearNO5,
			string host_ConnectRodBearNO6,
			string host_ConnectRodBearNO7,
			string host_ConnectRodBearNO8,
			string host_ConnectRodBearNO9,
			string host_MajorBearNO1,
			string host_MajorBearNO2,
			string host_MajorBearNO3,
			string host_MajorBearNO4,
			string host_MajorBearNO5,
			string host_MajorBearNO6,
			string host_MajorBearNO7,
			string host_MajorBearNO8,
			string host_MajorBearNO9,
			string host_HighPreesurePumpNO1,
			string host_HighPreesurePumpNO2,
			string host_HighPreesurePumpNO3,
			string host_HighPreesurePumpNO4,
			string host_HighPreesurePumpNO5,
			string host_HighPreesurePumpNO6,
			string host_HighPreesurePumpNO7,
			string host_HighPreesurePumpNO8,
			string host_HighPreesurePumpNO9,
			string gas_DismantNO1,
			string gas_DismantNO2,
			string gas_MarblePanelNO1,
			string gas_MarblePanelNO2,
			string gas_AirCoolerNO1,
			string gas_AirCoolerNO2,
			string gas_STotalNO1,
			string gas_STotalNO2,
			string gas_STotalNO3,
			string gas_SLiftingCylinderNO1,
			string gas_SLiftingCylinderNO2,
			string gas_SLiftingCylinderNO3,
			string gas_SExhaustExchangeNO1,
			string gas_SExhaustExchangeNO2,
			string gas_SExhaustExchangeNO3,
			string gas_SOilHeadNO1,
			string gas_SOilHeadNO2,
			string gas_SOilHeadNO3,
			string gas_SMajorBearNO1,
			string gas_SMajorBearNO2,
			string gas_SMajorBearNO3,
			string gas_STurbochargerNO1,
			string gas_STurbochargerNO2,
			string gas_STurbochargerNO3,
			string gas_ACTotalNO1,
			string gas_ACTotalNO2,
			string gas_ACTotalNO3,
			string gas_ACliftingCylinderNO1,
			string gas_ACliftingCylinderNO2,
			string gas_ACliftingCylinderNO3,
			string gas_PPTotalNO1,
			string gas_PPTotalNO2,
			string gas_PPCheckNO1,
			string gas_PPCheckNO2,
			string gas_Remarks,
			string chiefSign,
			string pump_MainSeaTotalNO1,
			string pump_MainSeaTotalNO2,
			string pump_MainSeaDisintegrationNO1,
			string pump_MainSeaDisintegrationNO2,
			string pump_SecondSeaTotal,
			string pump_SecondSeaDisintegration,
			string pump_CylinderTotalNO1,
			string pump_CylinderTotalNO2,
			string pump_CylinderDisintegrationNO1,
			string pump_CylinderDisintegrationNO2,
			string pump_LowTemTotalNO1,
			string pump_LowTemTotalNO2,
			string pump_LowTemDisintegrationNO1,
			string pump_LowTemDisintegrationNO2,
			string pump_ParkLowTemTotal,
			string pump_ParkLowTemDisintegration,
			string pump_MainOilTotalNO1,
			string pump_MainOilTotalNO2,
			string pump_MainOilDisintegrationNO1,
			string pump_MainOilDisintegrationNO2,
			string pump_CamshaftOilTotalNO1,
			string pump_CamshaftOilTotalNO2,
			string pump_CamshaftOilDisintegrationNO1,
			string pump_CamshaftOilDisintegrationNO2,
			string pump_BoilerTotal,
			string pump_BoilerDisintegration,
			string pump_GeneralToatl,
			string pump_GeneralDisintegration,
			string pump_FireTotal,
			string pump_FireDisintegration,
			string pump_FuelCircleTotalNO1,
			string pump_FuelCircleTotalNO2,
			string pump_FuelCircleDisintegratinNO1,
			string pump_FuelCircleDisintegratinNO2,
			string pump_FuelPressureTotalNO1,
			string pump_FuelPressureTotalNO2,
			string pump_FuelPressureDisintegrationNO1,
			string pump_FuelPressureDisintegrationNO2,
			string pump_HeavyOilTotalNO1,
			string pump_HeavyOilTotalNO2,
			string pump_HeavyOilDisintegrationNO1,
			string pump_HeavyOilDisintegrationNO2,
			string pump_DieselFuelTotal,
			string pump_DieselFuelDisintegration,
			string pump_OilTotalNO1,
			string pump_OilTotalNO2,
			string pump_OilDisintegrationNO1,
			string pump_OilDisintegrationNO2,
			string pump_BallastTotalNO1,
			string pump_BallastTotalNO2,
			string pump_BallastDisintegrationNO1,
			string pump_BallastDisintegrationNO2,
			string pump_EmergencyTotal,
			string pump_EmergencyDisintegration
		)
		{
			this.Report_MajorEquipTime_Id           = report_MajorEquipTime_Id;
			this.SHIP_ID                            = sHIP_ID;
			this.File_ID                            = file_ID;
			this.Voyage                             = voyage;
			this.Cabin_HostTotal                    = cabin_HostTotal;
			this.Cabin_StatisticsDate               = cabin_StatisticsDate;
			this.Host_CylinderRenewalNO1            = host_CylinderRenewalNO1;
			this.Host_CylinderRenewalNO2            = host_CylinderRenewalNO2;
			this.Host_CylinderRenewalNO3            = host_CylinderRenewalNO3;
			this.Host_CylinderRenewalNO4            = host_CylinderRenewalNO4;
			this.Host_CylinderRenewalNO5            = host_CylinderRenewalNO5;
			this.Host_CylinderRenewalNO6            = host_CylinderRenewalNO6;
			this.Host_CylinderRenewalNO7            = host_CylinderRenewalNO7;
			this.Host_CylinderRenewalNO8            = host_CylinderRenewalNO8;
			this.Host_CylinderRenewalNO9            = host_CylinderRenewalNO9;
			this.Host_LiftingCylinderNO1            = host_LiftingCylinderNO1;
			this.Host_LiftingCylinderNO2            = host_LiftingCylinderNO2;
			this.Host_LiftingCylinderNO3            = host_LiftingCylinderNO3;
			this.Host_LiftingCylinderNO4            = host_LiftingCylinderNO4;
			this.Host_LiftingCylinderNO5            = host_LiftingCylinderNO5;
			this.Host_LiftingCylinderNO6            = host_LiftingCylinderNO6;
			this.Host_LiftingCylinderNO7            = host_LiftingCylinderNO7;
			this.Host_LiftingCylinderNO8            = host_LiftingCylinderNO8;
			this.Host_LiftingCylinderNO9            = host_LiftingCylinderNO9;
			this.Host_ExhaustExchangeNO1            = host_ExhaustExchangeNO1;
			this.Host_ExhaustExchangeNO2            = host_ExhaustExchangeNO2;
			this.Host_ExhaustExchangeNO3            = host_ExhaustExchangeNO3;
			this.Host_ExhaustExchangeNO4            = host_ExhaustExchangeNO4;
			this.Host_ExhaustExchangeNO5            = host_ExhaustExchangeNO5;
			this.Host_ExhaustExchangeNO6            = host_ExhaustExchangeNO6;
			this.Host_ExhaustExchangeNO7            = host_ExhaustExchangeNO7;
			this.Host_ExhaustExchangeNO8            = host_ExhaustExchangeNO8;
			this.Host_ExhaustExchangeNO9            = host_ExhaustExchangeNO9;
			this.Host_OilHeadCheckNO1               = host_OilHeadCheckNO1;
			this.Host_OilHeadCheckNO2               = host_OilHeadCheckNO2;
			this.Host_OilHeadCheckNO3               = host_OilHeadCheckNO3;
			this.Host_OilHeadCheckNO4               = host_OilHeadCheckNO4;
			this.Host_OilHeadCheckNO5               = host_OilHeadCheckNO5;
			this.Host_OilHeadCheckNO6               = host_OilHeadCheckNO6;
			this.Host_OilHeadCheckNO7               = host_OilHeadCheckNO7;
			this.Host_OilHeadCheckNO8               = host_OilHeadCheckNO8;
			this.Host_OilHeadCheckNO9               = host_OilHeadCheckNO9;
			this.Host_CrossheadBearNO1              = host_CrossheadBearNO1;
			this.Host_CrossheadBearNO2              = host_CrossheadBearNO2;
			this.Host_CrossheadBearNO3              = host_CrossheadBearNO3;
			this.Host_CrossheadBearNO4              = host_CrossheadBearNO4;
			this.Host_CrossheadBearNO5              = host_CrossheadBearNO5;
			this.Host_CrossheadBearNO6              = host_CrossheadBearNO6;
			this.Host_CrossheadBearNO7              = host_CrossheadBearNO7;
			this.Host_CrossheadBearNO8              = host_CrossheadBearNO8;
			this.Host_CrossheadBearNO9              = host_CrossheadBearNO9;
			this.Host_ConnectRodBearNO1             = host_ConnectRodBearNO1;
			this.Host_ConnectRodBearNO2             = host_ConnectRodBearNO2;
			this.Host_ConnectRodBearNO3             = host_ConnectRodBearNO3;
			this.Host_ConnectRodBearNO4             = host_ConnectRodBearNO4;
			this.Host_ConnectRodBearNO5             = host_ConnectRodBearNO5;
			this.Host_ConnectRodBearNO6             = host_ConnectRodBearNO6;
			this.Host_ConnectRodBearNO7             = host_ConnectRodBearNO7;
			this.Host_ConnectRodBearNO8             = host_ConnectRodBearNO8;
			this.Host_ConnectRodBearNO9             = host_ConnectRodBearNO9;
			this.Host_MajorBearNO1                  = host_MajorBearNO1;
			this.Host_MajorBearNO2                  = host_MajorBearNO2;
			this.Host_MajorBearNO3                  = host_MajorBearNO3;
			this.Host_MajorBearNO4                  = host_MajorBearNO4;
			this.Host_MajorBearNO5                  = host_MajorBearNO5;
			this.Host_MajorBearNO6                  = host_MajorBearNO6;
			this.Host_MajorBearNO7                  = host_MajorBearNO7;
			this.Host_MajorBearNO8                  = host_MajorBearNO8;
			this.Host_MajorBearNO9                  = host_MajorBearNO9;
			this.Host_HighPreesurePumpNO1           = host_HighPreesurePumpNO1;
			this.Host_HighPreesurePumpNO2           = host_HighPreesurePumpNO2;
			this.Host_HighPreesurePumpNO3           = host_HighPreesurePumpNO3;
			this.Host_HighPreesurePumpNO4           = host_HighPreesurePumpNO4;
			this.Host_HighPreesurePumpNO5           = host_HighPreesurePumpNO5;
			this.Host_HighPreesurePumpNO6           = host_HighPreesurePumpNO6;
			this.Host_HighPreesurePumpNO7           = host_HighPreesurePumpNO7;
			this.Host_HighPreesurePumpNO8           = host_HighPreesurePumpNO8;
			this.Host_HighPreesurePumpNO9           = host_HighPreesurePumpNO9;
			this.Gas_DismantNO1                     = gas_DismantNO1;
			this.Gas_DismantNO2                     = gas_DismantNO2;
			this.Gas_MarblePanelNO1                 = gas_MarblePanelNO1;
			this.Gas_MarblePanelNO2                 = gas_MarblePanelNO2;
			this.Gas_AirCoolerNO1                   = gas_AirCoolerNO1;
			this.Gas_AirCoolerNO2                   = gas_AirCoolerNO2;
			this.Gas_STotalNO1                      = gas_STotalNO1;
			this.Gas_STotalNO2                      = gas_STotalNO2;
			this.Gas_STotalNO3                      = gas_STotalNO3;
			this.Gas_SLiftingCylinderNO1            = gas_SLiftingCylinderNO1;
			this.Gas_SLiftingCylinderNO2            = gas_SLiftingCylinderNO2;
			this.Gas_SLiftingCylinderNO3            = gas_SLiftingCylinderNO3;
			this.Gas_SExhaustExchangeNO1            = gas_SExhaustExchangeNO1;
			this.Gas_SExhaustExchangeNO2            = gas_SExhaustExchangeNO2;
			this.Gas_SExhaustExchangeNO3            = gas_SExhaustExchangeNO3;
			this.Gas_SOilHeadNO1                    = gas_SOilHeadNO1;
			this.Gas_SOilHeadNO2                    = gas_SOilHeadNO2;
			this.Gas_SOilHeadNO3                    = gas_SOilHeadNO3;
			this.Gas_SMajorBearNO1                  = gas_SMajorBearNO1;
			this.Gas_SMajorBearNO2                  = gas_SMajorBearNO2;
			this.Gas_SMajorBearNO3                  = gas_SMajorBearNO3;
			this.Gas_STurbochargerNO1               = gas_STurbochargerNO1;
			this.Gas_STurbochargerNO2               = gas_STurbochargerNO2;
			this.Gas_STurbochargerNO3               = gas_STurbochargerNO3;
			this.Gas_ACTotalNO1                     = gas_ACTotalNO1;
			this.Gas_ACTotalNO2                     = gas_ACTotalNO2;
			this.Gas_ACTotalNO3                     = gas_ACTotalNO3;
			this.Gas_ACliftingCylinderNO1           = gas_ACliftingCylinderNO1;
			this.Gas_ACliftingCylinderNO2           = gas_ACliftingCylinderNO2;
			this.Gas_ACliftingCylinderNO3           = gas_ACliftingCylinderNO3;
			this.Gas_PPTotalNO1                     = gas_PPTotalNO1;
			this.Gas_PPTotalNO2                     = gas_PPTotalNO2;
			this.Gas_PPCheckNO1                     = gas_PPCheckNO1;
			this.Gas_PPCheckNO2                     = gas_PPCheckNO2;
			this.Gas_Remarks                        = gas_Remarks;
			this.ChiefSign                          = chiefSign;
			this.Pump_MainSeaTotalNO1               = pump_MainSeaTotalNO1;
			this.Pump_MainSeaTotalNO2               = pump_MainSeaTotalNO2;
			this.Pump_MainSeaDisintegrationNO1      = pump_MainSeaDisintegrationNO1;
			this.Pump_MainSeaDisintegrationNO2      = pump_MainSeaDisintegrationNO2;
			this.Pump_SecondSeaTotal                = pump_SecondSeaTotal;
			this.Pump_SecondSeaDisintegration       = pump_SecondSeaDisintegration;
			this.Pump_CylinderTotalNO1              = pump_CylinderTotalNO1;
			this.Pump_CylinderTotalNO2              = pump_CylinderTotalNO2;
			this.Pump_CylinderDisintegrationNO1     = pump_CylinderDisintegrationNO1;
			this.Pump_CylinderDisintegrationNO2     = pump_CylinderDisintegrationNO2;
			this.Pump_LowTemTotalNO1                = pump_LowTemTotalNO1;
			this.Pump_LowTemTotalNO2                = pump_LowTemTotalNO2;
			this.Pump_LowTemDisintegrationNO1       = pump_LowTemDisintegrationNO1;
			this.Pump_LowTemDisintegrationNO2       = pump_LowTemDisintegrationNO2;
			this.Pump_ParkLowTemTotal               = pump_ParkLowTemTotal;
			this.Pump_ParkLowTemDisintegration      = pump_ParkLowTemDisintegration;
			this.Pump_MainOilTotalNO1               = pump_MainOilTotalNO1;
			this.Pump_MainOilTotalNO2               = pump_MainOilTotalNO2;
			this.Pump_MainOilDisintegrationNO1      = pump_MainOilDisintegrationNO1;
			this.Pump_MainOilDisintegrationNO2      = pump_MainOilDisintegrationNO2;
			this.Pump_CamshaftOilTotalNO1           = pump_CamshaftOilTotalNO1;
			this.Pump_CamshaftOilTotalNO2           = pump_CamshaftOilTotalNO2;
			this.Pump_CamshaftOilDisintegrationNO1  = pump_CamshaftOilDisintegrationNO1;
			this.Pump_CamshaftOilDisintegrationNO2  = pump_CamshaftOilDisintegrationNO2;
			this.Pump_BoilerTotal                   = pump_BoilerTotal;
			this.Pump_BoilerDisintegration          = pump_BoilerDisintegration;
			this.Pump_GeneralToatl                  = pump_GeneralToatl;
			this.Pump_GeneralDisintegration         = pump_GeneralDisintegration;
			this.Pump_FireTotal                     = pump_FireTotal;
			this.Pump_FireDisintegration            = pump_FireDisintegration;
			this.Pump_FuelCircleTotalNO1            = pump_FuelCircleTotalNO1;
			this.Pump_FuelCircleTotalNO2            = pump_FuelCircleTotalNO2;
			this.Pump_FuelCircleDisintegratinNO1    = pump_FuelCircleDisintegratinNO1;
			this.Pump_FuelCircleDisintegratinNO2    = pump_FuelCircleDisintegratinNO2;
			this.Pump_FuelPressureTotalNO1          = pump_FuelPressureTotalNO1;
			this.Pump_FuelPressureTotalNO2          = pump_FuelPressureTotalNO2;
			this.Pump_FuelPressureDisintegrationNO1 = pump_FuelPressureDisintegrationNO1;
			this.Pump_FuelPressureDisintegrationNO2 = pump_FuelPressureDisintegrationNO2;
			this.Pump_HeavyOilTotalNO1              = pump_HeavyOilTotalNO1;
			this.Pump_HeavyOilTotalNO2              = pump_HeavyOilTotalNO2;
			this.Pump_HeavyOilDisintegrationNO1     = pump_HeavyOilDisintegrationNO1;
			this.Pump_HeavyOilDisintegrationNO2     = pump_HeavyOilDisintegrationNO2;
			this.Pump_DieselFuelTotal               = pump_DieselFuelTotal;
			this.Pump_DieselFuelDisintegration      = pump_DieselFuelDisintegration;
			this.Pump_OilTotalNO1                   = pump_OilTotalNO1;
			this.Pump_OilTotalNO2                   = pump_OilTotalNO2;
			this.Pump_OilDisintegrationNO1          = pump_OilDisintegrationNO1;
			this.Pump_OilDisintegrationNO2          = pump_OilDisintegrationNO2;
			this.Pump_BallastTotalNO1               = pump_BallastTotalNO1;
			this.Pump_BallastTotalNO2               = pump_BallastTotalNO2;
			this.Pump_BallastDisintegrationNO1      = pump_BallastDisintegrationNO1;
			this.Pump_BallastDisintegrationNO2      = pump_BallastDisintegrationNO2;
			this.Pump_EmergencyTotal                = pump_EmergencyTotal;
			this.Pump_EmergencyDisintegration       = pump_EmergencyDisintegration;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///
		///</summary>
		public string Report_MajorEquipTime_Id{get ;set;}

		///<summary>
		///船舶ID
		///
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
		///总运行小时.
		///</summary>
		public string Cabin_HostTotal{get ;set;}

		///<summary>
		///统计日期.
		///
		///</summary>
		public DateTime Cabin_StatisticsDate{get ;set;}

		///<summary>
		///缸套换新后运行小时      NO1
		///</summary>
		public string Host_CylinderRenewalNO1{get ;set;}

		///<summary>
		///缸套换新后运行小时      NO12
		///</summary>
		public string Host_CylinderRenewalNO2{get ;set;}

		///<summary>
		///缸套换新后运行小时      NO3
		///</summary>
		public string Host_CylinderRenewalNO3{get ;set;}

		///<summary>
		///缸套换新后运行小时      NO4
		///</summary>
		public string Host_CylinderRenewalNO4{get ;set;}

		///<summary>
		///缸套换新后运行小时      NO5
		///</summary>
		public string Host_CylinderRenewalNO5{get ;set;}

		///<summary>
		///缸套换新后运行小时      NO6
		///</summary>
		public string Host_CylinderRenewalNO6{get ;set;}

		///<summary>
		///缸套换新后运行小时      NO7
		///</summary>
		public string Host_CylinderRenewalNO7{get ;set;}

		///<summary>
		///缸套换新后运行小时      NO8
		///</summary>
		public string Host_CylinderRenewalNO8{get ;set;}

		///<summary>
		///缸套换新后运行小时      NO9
		///</summary>
		public string Host_CylinderRenewalNO9{get ;set;}

		///<summary>
		///吊缸后运行小时  NO1
		///</summary>
		public string Host_LiftingCylinderNO1{get ;set;}

		///<summary>
		///吊缸后运行小时  NO2
		///</summary>
		public string Host_LiftingCylinderNO2{get ;set;}

		///<summary>
		///吊缸后运行小时  NO3
		///</summary>
		public string Host_LiftingCylinderNO3{get ;set;}

		///<summary>
		///吊缸后运行小时  NO4
		///</summary>
		public string Host_LiftingCylinderNO4{get ;set;}

		///<summary>
		///吊缸后运行小时  NO5
		///</summary>
		public string Host_LiftingCylinderNO5{get ;set;}

		///<summary>
		///吊缸后运行小时  NO6
		///</summary>
		public string Host_LiftingCylinderNO6{get ;set;}

		///<summary>
		///吊缸后运行小时  NO7
		///</summary>
		public string Host_LiftingCylinderNO7{get ;set;}

		///<summary>
		///吊缸后运行小时  NO8
		///</summary>
		public string Host_LiftingCylinderNO8{get ;set;}

		///<summary>
		///吊缸后运行小时  NO9
		///</summary>
		public string Host_LiftingCylinderNO9{get ;set;}

		///<summary>
		///排气阀换后运行小时  NO1
		///</summary>
		public string Host_ExhaustExchangeNO1{get ;set;}

		///<summary>
		///排气阀换后运行小时  NO2
		///</summary>
		public string Host_ExhaustExchangeNO2{get ;set;}

		///<summary>
		///排气阀换后运行小时  NO3
		///</summary>
		public string Host_ExhaustExchangeNO3{get ;set;}

		///<summary>
		///排气阀换后运行小时  NO4
		///</summary>
		public string Host_ExhaustExchangeNO4{get ;set;}

		///<summary>
		///排气阀换后运行小时  NO5
		///</summary>
		public string Host_ExhaustExchangeNO5{get ;set;}

		///<summary>
		///排气阀换后运行小时  NO6
		///</summary>
		public string Host_ExhaustExchangeNO6{get ;set;}

		///<summary>
		///排气阀换后运行小时  NO7
		///</summary>
		public string Host_ExhaustExchangeNO7{get ;set;}

		///<summary>
		///排气阀换后运行小时  NO8
		///</summary>
		public string Host_ExhaustExchangeNO8{get ;set;}

		///<summary>
		///排气阀换后运行小时  NO9
		///</summary>
		public string Host_ExhaustExchangeNO9{get ;set;}

		///<summary>
		///油头检查后运行小时  NO1
		///</summary>
		public string Host_OilHeadCheckNO1{get ;set;}

		///<summary>
		///油头检查后运行小时  NO2
		///</summary>
		public string Host_OilHeadCheckNO2{get ;set;}

		///<summary>
		///油头检查后运行小时  NO3
		///</summary>
		public string Host_OilHeadCheckNO3{get ;set;}

		///<summary>
		///油头检查后运行小时  NO4
		///</summary>
		public string Host_OilHeadCheckNO4{get ;set;}

		///<summary>
		///油头检查后运行小时  NO5
		///</summary>
		public string Host_OilHeadCheckNO5{get ;set;}

		///<summary>
		///油头检查后运行小时  NO6
		///</summary>
		public string Host_OilHeadCheckNO6{get ;set;}

		///<summary>
		///油头检查后运行小时  NO8
		///</summary>
		public string Host_OilHeadCheckNO7{get ;set;}

		///<summary>
		///油头检查后运行小时  NO8
		///</summary>
		public string Host_OilHeadCheckNO8{get ;set;}

		///<summary>
		///油头检查后运行小时  NO9
		///</summary>
		public string Host_OilHeadCheckNO9{get ;set;}

		///<summary>
		///十字头轴承拆检后运行小时 NO1
		///</summary>
		public string Host_CrossheadBearNO1{get ;set;}

		///<summary>
		///十字头轴承拆检后运行小时 NO2
		///</summary>
		public string Host_CrossheadBearNO2{get ;set;}

		///<summary>
		///十字头轴承拆检后运行小时 NO3
		///</summary>
		public string Host_CrossheadBearNO3{get ;set;}

		///<summary>
		///十字头轴承拆检后运行小时 NO4
		///</summary>
		public string Host_CrossheadBearNO4{get ;set;}

		///<summary>
		///十字头轴承拆检后运行小时 NO5
		///</summary>
		public string Host_CrossheadBearNO5{get ;set;}

		///<summary>
		///十字头轴承拆检后运行小时 NO6
		///</summary>
		public string Host_CrossheadBearNO6{get ;set;}

		///<summary>
		///十字头轴承拆检后运行小时 NO7
		///</summary>
		public string Host_CrossheadBearNO7{get ;set;}

		///<summary>
		///十字头轴承拆检后运行小时 NO8
		///</summary>
		public string Host_CrossheadBearNO8{get ;set;}

		///<summary>
		///十字头轴承拆检后运行小时 NO9
		///</summary>
		public string Host_CrossheadBearNO9{get ;set;}

		///<summary>
		///连杆轴承拆检后运行小时  NO1
		///</summary>
		public string Host_ConnectRodBearNO1{get ;set;}

		///<summary>
		///连杆轴承拆检后运行小时  NO2
		///</summary>
		public string Host_ConnectRodBearNO2{get ;set;}

		///<summary>
		///连杆轴承拆检后运行小时  NO3
		///</summary>
		public string Host_ConnectRodBearNO3{get ;set;}

		///<summary>
		///连杆轴承拆检后运行小时  NO4
		///</summary>
		public string Host_ConnectRodBearNO4{get ;set;}

		///<summary>
		///连杆轴承拆检后运行小时  NO5
		///</summary>
		public string Host_ConnectRodBearNO5{get ;set;}

		///<summary>
		///连杆轴承拆检后运行小时  NO6
		///</summary>
		public string Host_ConnectRodBearNO6{get ;set;}

		///<summary>
		///连杆轴承拆检后运行小时  NO7
		///</summary>
		public string Host_ConnectRodBearNO7{get ;set;}

		///<summary>
		///连杆轴承拆检后运行小时  NO8
		///</summary>
		public string Host_ConnectRodBearNO8{get ;set;}

		///<summary>
		///连杆轴承拆检后运行小时  NO9
		///</summary>
		public string Host_ConnectRodBearNO9{get ;set;}

		///<summary>
		///主轴承拆检后运行小时  NO1
		///</summary>
		public string Host_MajorBearNO1{get ;set;}

		///<summary>
		///主轴承拆检后运行小时  NO2
		///</summary>
		public string Host_MajorBearNO2{get ;set;}

		///<summary>
		///主轴承拆检后运行小时  NO3
		///</summary>
		public string Host_MajorBearNO3{get ;set;}

		///<summary>
		///主轴承拆检后运行小时  NO4
		///</summary>
		public string Host_MajorBearNO4{get ;set;}

		///<summary>
		///主轴承拆检后运行小时  NO5
		///</summary>
		public string Host_MajorBearNO5{get ;set;}

		///<summary>
		///主轴承拆检后运行小时  NO6
		///</summary>
		public string Host_MajorBearNO6{get ;set;}

		///<summary>
		///主轴承拆检后运行小时  NO7
		///</summary>
		public string Host_MajorBearNO7{get ;set;}

		///<summary>
		///主轴承拆检后运行小时  NO8
		///</summary>
		public string Host_MajorBearNO8{get ;set;}

		///<summary>
		///主轴承拆检后运行小时  NO9
		///</summary>
		public string Host_MajorBearNO9{get ;set;}

		///<summary>
		///高压油泵拆检后运行小时  NO1
		///</summary>
		public string Host_HighPreesurePumpNO1{get ;set;}

		///<summary>
		///高压油泵拆检后运行小时  NO2
		///</summary>
		public string Host_HighPreesurePumpNO2{get ;set;}

		///<summary>
		///高压油泵拆检后运行小时  NO3
		///</summary>
		public string Host_HighPreesurePumpNO3{get ;set;}

		///<summary>
		///高压油泵拆检后运行小时  NO4
		///</summary>
		public string Host_HighPreesurePumpNO4{get ;set;}

		///<summary>
		///高压油泵拆检后运行小时  NO5
		///</summary>
		public string Host_HighPreesurePumpNO5{get ;set;}

		///<summary>
		///高压油泵拆检后运行小时  NO6
		///</summary>
		public string Host_HighPreesurePumpNO6{get ;set;}

		///<summary>
		///高压油泵拆检后运行小时  NO7
		///</summary>
		public string Host_HighPreesurePumpNO7{get ;set;}

		///<summary>
		///高压油泵拆检后运行小时  NO8
		///</summary>
		public string Host_HighPreesurePumpNO8{get ;set;}

		///<summary>
		///高压油泵拆检后运行小时  NO9
		///</summary>
		public string Host_HighPreesurePumpNO9{get ;set;}

		///<summary>
		///废弃增压器  拆检后运行小时  NO1
		///</summary>
		public string Gas_DismantNO1{get ;set;}

		///<summary>
		///废弃增压器  拆检后运行小时  NO2
		///</summary>
		public string Gas_DismantNO2{get ;set;}

		///<summary>
		///废弃增压器  弹子盘换新后运行小时  NO1
		///</summary>
		public string Gas_MarblePanelNO1{get ;set;}

		///<summary>
		///废弃增压器  弹子盘换新后运行小时  NO2
		///</summary>
		public string Gas_MarblePanelNO2{get ;set;}

		///<summary>
		///废弃增压器  空冷器清通后运行小时  NO1
		///</summary>
		public string Gas_AirCoolerNO1{get ;set;}

		///<summary>
		///废弃增压器  空冷器清通后运行小时  NO2
		///</summary>
		public string Gas_AirCoolerNO2{get ;set;}

		///<summary>
		///废弃增压器  副机  总运行小时  NO1
		///</summary>
		public string Gas_STotalNO1{get ;set;}

		///<summary>
		///废弃增压器  副机  总运行小时  NO2
		///</summary>
		public string Gas_STotalNO2{get ;set;}

		///<summary>
		///废弃增压器  副机  总运行小时  NO3
		///</summary>
		public string Gas_STotalNO3{get ;set;}

		///<summary>
		///废弃增压器  副机  吊缸后运行小时  NO1
		///</summary>
		public string Gas_SLiftingCylinderNO1{get ;set;}

		///<summary>
		///废弃增压器  副机  吊缸后运行小时  NO2
		///</summary>
		public string Gas_SLiftingCylinderNO2{get ;set;}

		///<summary>
		///废弃增压器  副机  吊缸后运行小时  NO3
		///</summary>
		public string Gas_SLiftingCylinderNO3{get ;set;}

		///<summary>
		///废弃增压器  副机 排气阀换后运行小时  NO1
		///</summary>
		public string Gas_SExhaustExchangeNO1{get ;set;}

		///<summary>
		///废弃增压器  副机 排气阀换后运行小时  NO2
		///</summary>
		public string Gas_SExhaustExchangeNO2{get ;set;}

		///<summary>
		///废弃增压器  副机 排气阀换后运行小时  NO3
		///</summary>
		public string Gas_SExhaustExchangeNO3{get ;set;}

		///<summary>
		///废弃增压器  副机 油头检查后运行小时  NO1
		///</summary>
		public string Gas_SOilHeadNO1{get ;set;}

		///<summary>
		///废弃增压器  副机 油头检查后运行小时  NO2
		///</summary>
		public string Gas_SOilHeadNO2{get ;set;}

		///<summary>
		///废弃增压器  副机 油头检查后运行小时  NO3
		///</summary>
		public string Gas_SOilHeadNO3{get ;set;}

		///<summary>
		///废弃增压器  副机 主轴承拆检后运行小时  NO1
		///</summary>
		public string Gas_SMajorBearNO1{get ;set;}

		///<summary>
		///废弃增压器  副机 主轴承拆检后运行小时  NO2
		///</summary>
		public string Gas_SMajorBearNO2{get ;set;}

		///<summary>
		///废弃增压器  副机 主轴承拆检后运行小时  NO3
		///</summary>
		public string Gas_SMajorBearNO3{get ;set;}

		///<summary>
		///废弃增压器  副机 废气增压器  NO1
		///</summary>
		public string Gas_STurbochargerNO1{get ;set;}

		///<summary>
		///废弃增压器  副机 废气增压器  NO2
		///</summary>
		public string Gas_STurbochargerNO2{get ;set;}

		///<summary>
		///废弃增压器  副机 废气增压器  NO3
		///</summary>
		public string Gas_STurbochargerNO3{get ;set;}

		///<summary>
		///废弃增压器 主空压机   总运行小时   NO1
		///</summary>
		public string Gas_ACTotalNO1{get ;set;}

		///<summary>
		///废弃增压器 主空压机   总运行小时   NO2
		///</summary>
		public string Gas_ACTotalNO2{get ;set;}

		///<summary>
		///废弃增压器 主空压机   总运行小时   NO3
		///</summary>
		public string Gas_ACTotalNO3{get ;set;}

		///<summary>
		///废弃增压器 主空压机  吊缸后运行小时   NO1
		///</summary>
		public string Gas_ACliftingCylinderNO1{get ;set;}

		///<summary>
		///废弃增压器 主空压机  吊缸后运行小时   NO2
		///</summary>
		public string Gas_ACliftingCylinderNO2{get ;set;}

		///<summary>
		///废弃增压器 主空压机  吊缸后运行小时   NO3
		///</summary>
		public string Gas_ACliftingCylinderNO3{get ;set;}

		///<summary>
		///废弃增压器 舵机油泵   总运行小时   NO1
		///</summary>
		public string Gas_PPTotalNO1{get ;set;}

		///<summary>
		///废弃增压器 舵机油泵   总运行小时   NO2
		///</summary>
		public string Gas_PPTotalNO2{get ;set;}

		///<summary>
		///废弃增压器 舵机油泵   检查后运行小时   NO1
		///</summary>
		public string Gas_PPCheckNO1{get ;set;}

		///<summary>
		///废弃增压器 舵机油泵   检查后运行小时   NO2
		///</summary>
		public string Gas_PPCheckNO2{get ;set;}

		///<summary>
		///废弃增压器  附记.
		///</summary>
		public string Gas_Remarks{get ;set;}

		///<summary>
		///轮机长签字.
		///</summary>
		public string ChiefSign{get ;set;}

		///<summary>
		///主要泵浦  主海水泵  NO1  总运行小时.
		///</summary>
		public string Pump_MainSeaTotalNO1{get ;set;}

		///<summary>
		///主要泵浦  主海水泵  NO2  总运行小时.
		///</summary>
		public string Pump_MainSeaTotalNO2{get ;set;}

		///<summary>
		///主要泵浦  主海水泵  NO1  解体后运行小时.
		///</summary>
		public string Pump_MainSeaDisintegrationNO1{get ;set;}

		///<summary>
		///主要泵浦  主海水泵  NO2  解体后运行小时.
		///</summary>
		public string Pump_MainSeaDisintegrationNO2{get ;set;}

		///<summary>
		///主要泵浦  辅海水泵    总运行小时.
		///</summary>
		public string Pump_SecondSeaTotal{get ;set;}

		///<summary>
		///主要泵浦  辅海水泵   解体后运行小时.
		///</summary>
		public string Pump_SecondSeaDisintegration{get ;set;}

		///<summary>
		///主要泵浦  缸套水泵  NO1   总运行小时.
		///</summary>
		public string Pump_CylinderTotalNO1{get ;set;}

		///<summary>
		///主要泵浦  缸套水泵  NO2   总运行小时.
		///</summary>
		public string Pump_CylinderTotalNO2{get ;set;}

		///<summary>
		///主要泵浦  缸套水泵  NO1   解体运行小时.
		///</summary>
		public string Pump_CylinderDisintegrationNO1{get ;set;}

		///<summary>
		///主要泵浦  缸套水泵  NO2   解体运行小时.
		///</summary>
		public string Pump_CylinderDisintegrationNO2{get ;set;}

		///<summary>
		///主要泵浦  低温水泵  NO1   总运行小时.
		///</summary>
		public string Pump_LowTemTotalNO1{get ;set;}

		///<summary>
		///主要泵浦  低温水泵  NO2   总运行小时.
		///</summary>
		public string Pump_LowTemTotalNO2{get ;set;}

		///<summary>
		///主要泵浦  低温水泵  NO1   解体运行小时.
		///</summary>
		public string Pump_LowTemDisintegrationNO1{get ;set;}

		///<summary>
		///主要泵浦  低温水泵  NO2   解体运行小时.
		///</summary>
		public string Pump_LowTemDisintegrationNO2{get ;set;}

		///<summary>
		///主要泵浦  停泊低温水泵    总运行小时.
		///</summary>
		public string Pump_ParkLowTemTotal{get ;set;}

		///<summary>
		///主要泵浦  停泊低温水泵    解体运行小时.
		///</summary>
		public string Pump_ParkLowTemDisintegration{get ;set;}

		///<summary>
		///主要泵浦  主滑油泵 NO1    总运行小时.
		///</summary>
		public string Pump_MainOilTotalNO1{get ;set;}

		///<summary>
		///主要泵浦  主滑油泵 NO2   总运行小时.
		///</summary>
		public string Pump_MainOilTotalNO2{get ;set;}

		///<summary>
		///主要泵浦  主滑油泵 NO1    解体运行小时.
		///</summary>
		public string Pump_MainOilDisintegrationNO1{get ;set;}

		///<summary>
		///主要泵浦  主滑油泵 NO2    解体运行小时.
		///</summary>
		public string Pump_MainOilDisintegrationNO2{get ;set;}

		///<summary>
		///主要泵浦  凸轮轴油泵 NO1    总运行小时.
		///</summary>
		public string Pump_CamshaftOilTotalNO1{get ;set;}

		///<summary>
		///主要泵浦  凸轮轴油泵 NO2    总运行小时.
		///</summary>
		public string Pump_CamshaftOilTotalNO2{get ;set;}

		///<summary>
		///主要泵浦  凸轮轴油泵 NO1    解体运行小时.
		///</summary>
		public string Pump_CamshaftOilDisintegrationNO1{get ;set;}

		///<summary>
		///主要泵浦  凸轮轴油泵 NO2    解体运行小时.
		///</summary>
		public string Pump_CamshaftOilDisintegrationNO2{get ;set;}

		///<summary>
		///主要泵浦  锅炉给水泵   总运行小时.
		///</summary>
		public string Pump_BoilerTotal{get ;set;}

		///<summary>
		///主要泵浦  锅炉给水泵   解体运行小时.
		///</summary>
		public string Pump_BoilerDisintegration{get ;set;}

		///<summary>
		///主要泵浦  通用泵   总运行小时.
		///</summary>
		public string Pump_GeneralToatl{get ;set;}

		///<summary>
		///主要泵浦  通用泵   解体运行小时.
		///</summary>
		public string Pump_GeneralDisintegration{get ;set;}

		///<summary>
		///主要泵浦  消防泵   总运行小时.
		///</summary>
		public string Pump_FireTotal{get ;set;}

		///<summary>
		///主要泵浦  消防泵   解体运行小时.
		///</summary>
		public string Pump_FireDisintegration{get ;set;}

		///<summary>
		///主要泵浦  燃油循环泵   NO1   总运行小时.
		///</summary>
		public string Pump_FuelCircleTotalNO1{get ;set;}

		///<summary>
		///主要泵浦  燃油循环泵   NO2   总运行小时.
		///</summary>
		public string Pump_FuelCircleTotalNO2{get ;set;}

		///<summary>
		///主要泵浦  燃油循环泵   NO1   解体运行小时.
		///</summary>
		public string Pump_FuelCircleDisintegratinNO1{get ;set;}

		///<summary>
		///主要泵浦  燃油循环泵   NO2   解体运行小时.
		///</summary>
		public string Pump_FuelCircleDisintegratinNO2{get ;set;}

		///<summary>
		///主要泵浦  燃油增压泵   NO1   总运行小时.
		///</summary>
		public string Pump_FuelPressureTotalNO1{get ;set;}

		///<summary>
		///主要泵浦  燃油增压泵   NO2   总运行小时.
		///</summary>
		public string Pump_FuelPressureTotalNO2{get ;set;}

		///<summary>
		///主要泵浦  燃油增压泵   NO1   解体运行小时.
		///</summary>
		public string Pump_FuelPressureDisintegrationNO1{get ;set;}

		///<summary>
		///主要泵浦  燃油增压泵   NO2   解体运行小时.
		///</summary>
		public string Pump_FuelPressureDisintegrationNO2{get ;set;}

		///<summary>
		///主要泵浦  重油分油机   NO1   总运行小时.
		///</summary>
		public string Pump_HeavyOilTotalNO1{get ;set;}

		///<summary>
		///主要泵浦  重油分油机   NO2   总运行小时.
		///</summary>
		public string Pump_HeavyOilTotalNO2{get ;set;}

		///<summary>
		///主要泵浦  重油分油机   NO1   解体运行小时.
		///</summary>
		public string Pump_HeavyOilDisintegrationNO1{get ;set;}

		///<summary>
		///主要泵浦  重油分油机   NO2   解体运行小时.
		///</summary>
		public string Pump_HeavyOilDisintegrationNO2{get ;set;}

		///<summary>
		///主要泵浦  柴油分油机      总运行小时.
		///</summary>
		public string Pump_DieselFuelTotal{get ;set;}

		///<summary>
		///主要泵浦  柴油分油机      解体运行小时.
		///</summary>
		public string Pump_DieselFuelDisintegration{get ;set;}

		///<summary>
		///主要泵浦  滑油分油机 NO1      总运行小时.
		///</summary>
		public string Pump_OilTotalNO1{get ;set;}

		///<summary>
		///主要泵浦  滑油分油机 NO2      总运行小时.
		///</summary>
		public string Pump_OilTotalNO2{get ;set;}

		///<summary>
		///主要泵浦  滑油分油机 NO1      解体运行小时.
		///</summary>
		public string Pump_OilDisintegrationNO1{get ;set;}

		///<summary>
		///主要泵浦  滑油分油机 NO2      解体运行小时.
		///</summary>
		public string Pump_OilDisintegrationNO2{get ;set;}

		///<summary>
		///主要泵浦  压载水泵 NO1      总运行小时.
		///</summary>
		public string Pump_BallastTotalNO1{get ;set;}

		///<summary>
		///主要泵浦  压载水泵 NO2      总运行小时.
		///</summary>
		public string Pump_BallastTotalNO2{get ;set;}

		///<summary>
		///主要泵浦  压载水泵  NO1      解体运行小时.
		///</summary>
		public string Pump_BallastDisintegrationNO1{get ;set;}

		///<summary>
		///主要泵浦  压载水泵 NO2      解体运行小时.
		///</summary>
		public string Pump_BallastDisintegrationNO2{get ;set;}

		///<summary>
		///主要泵浦  应急救水泵      总运行小时.
		///</summary>
		public string Pump_EmergencyTotal{get ;set;}

		///<summary>
		///主要泵浦  应急救水泵       解体运行小时.
		///</summary>
		public string Pump_EmergencyDisintegration{get ;set;}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public override CommonClass Clone()
		{
			ReportMajorEquipment Unit = new ReportMajorEquipment();
			Unit.Report_MajorEquipTime_Id=this.Report_MajorEquipTime_Id;
			Unit.SHIP_ID=this.SHIP_ID;
			Unit.File_ID=this.File_ID;
			Unit.Voyage=this.Voyage;
			Unit.Cabin_HostTotal=this.Cabin_HostTotal;
			Unit.Cabin_StatisticsDate=this.Cabin_StatisticsDate;
			Unit.Host_CylinderRenewalNO1=this.Host_CylinderRenewalNO1;
			Unit.Host_CylinderRenewalNO2=this.Host_CylinderRenewalNO2;
			Unit.Host_CylinderRenewalNO3=this.Host_CylinderRenewalNO3;
			Unit.Host_CylinderRenewalNO4=this.Host_CylinderRenewalNO4;
			Unit.Host_CylinderRenewalNO5=this.Host_CylinderRenewalNO5;
			Unit.Host_CylinderRenewalNO6=this.Host_CylinderRenewalNO6;
			Unit.Host_CylinderRenewalNO7=this.Host_CylinderRenewalNO7;
			Unit.Host_CylinderRenewalNO8=this.Host_CylinderRenewalNO8;
			Unit.Host_CylinderRenewalNO9=this.Host_CylinderRenewalNO9;
			Unit.Host_LiftingCylinderNO1=this.Host_LiftingCylinderNO1;
			Unit.Host_LiftingCylinderNO2=this.Host_LiftingCylinderNO2;
			Unit.Host_LiftingCylinderNO3=this.Host_LiftingCylinderNO3;
			Unit.Host_LiftingCylinderNO4=this.Host_LiftingCylinderNO4;
			Unit.Host_LiftingCylinderNO5=this.Host_LiftingCylinderNO5;
			Unit.Host_LiftingCylinderNO6=this.Host_LiftingCylinderNO6;
			Unit.Host_LiftingCylinderNO7=this.Host_LiftingCylinderNO7;
			Unit.Host_LiftingCylinderNO8=this.Host_LiftingCylinderNO8;
			Unit.Host_LiftingCylinderNO9=this.Host_LiftingCylinderNO9;
			Unit.Host_ExhaustExchangeNO1=this.Host_ExhaustExchangeNO1;
			Unit.Host_ExhaustExchangeNO2=this.Host_ExhaustExchangeNO2;
			Unit.Host_ExhaustExchangeNO3=this.Host_ExhaustExchangeNO3;
			Unit.Host_ExhaustExchangeNO4=this.Host_ExhaustExchangeNO4;
			Unit.Host_ExhaustExchangeNO5=this.Host_ExhaustExchangeNO5;
			Unit.Host_ExhaustExchangeNO6=this.Host_ExhaustExchangeNO6;
			Unit.Host_ExhaustExchangeNO7=this.Host_ExhaustExchangeNO7;
			Unit.Host_ExhaustExchangeNO8=this.Host_ExhaustExchangeNO8;
			Unit.Host_ExhaustExchangeNO9=this.Host_ExhaustExchangeNO9;
			Unit.Host_OilHeadCheckNO1=this.Host_OilHeadCheckNO1;
			Unit.Host_OilHeadCheckNO2=this.Host_OilHeadCheckNO2;
			Unit.Host_OilHeadCheckNO3=this.Host_OilHeadCheckNO3;
			Unit.Host_OilHeadCheckNO4=this.Host_OilHeadCheckNO4;
			Unit.Host_OilHeadCheckNO5=this.Host_OilHeadCheckNO5;
			Unit.Host_OilHeadCheckNO6=this.Host_OilHeadCheckNO6;
			Unit.Host_OilHeadCheckNO7=this.Host_OilHeadCheckNO7;
			Unit.Host_OilHeadCheckNO8=this.Host_OilHeadCheckNO8;
			Unit.Host_OilHeadCheckNO9=this.Host_OilHeadCheckNO9;
			Unit.Host_CrossheadBearNO1=this.Host_CrossheadBearNO1;
			Unit.Host_CrossheadBearNO2=this.Host_CrossheadBearNO2;
			Unit.Host_CrossheadBearNO3=this.Host_CrossheadBearNO3;
			Unit.Host_CrossheadBearNO4=this.Host_CrossheadBearNO4;
			Unit.Host_CrossheadBearNO5=this.Host_CrossheadBearNO5;
			Unit.Host_CrossheadBearNO6=this.Host_CrossheadBearNO6;
			Unit.Host_CrossheadBearNO7=this.Host_CrossheadBearNO7;
			Unit.Host_CrossheadBearNO8=this.Host_CrossheadBearNO8;
			Unit.Host_CrossheadBearNO9=this.Host_CrossheadBearNO9;
			Unit.Host_ConnectRodBearNO1=this.Host_ConnectRodBearNO1;
			Unit.Host_ConnectRodBearNO2=this.Host_ConnectRodBearNO2;
			Unit.Host_ConnectRodBearNO3=this.Host_ConnectRodBearNO3;
			Unit.Host_ConnectRodBearNO4=this.Host_ConnectRodBearNO4;
			Unit.Host_ConnectRodBearNO5=this.Host_ConnectRodBearNO5;
			Unit.Host_ConnectRodBearNO6=this.Host_ConnectRodBearNO6;
			Unit.Host_ConnectRodBearNO7=this.Host_ConnectRodBearNO7;
			Unit.Host_ConnectRodBearNO8=this.Host_ConnectRodBearNO8;
			Unit.Host_ConnectRodBearNO9=this.Host_ConnectRodBearNO9;
			Unit.Host_MajorBearNO1=this.Host_MajorBearNO1;
			Unit.Host_MajorBearNO2=this.Host_MajorBearNO2;
			Unit.Host_MajorBearNO3=this.Host_MajorBearNO3;
			Unit.Host_MajorBearNO4=this.Host_MajorBearNO4;
			Unit.Host_MajorBearNO5=this.Host_MajorBearNO5;
			Unit.Host_MajorBearNO6=this.Host_MajorBearNO6;
			Unit.Host_MajorBearNO7=this.Host_MajorBearNO7;
			Unit.Host_MajorBearNO8=this.Host_MajorBearNO8;
			Unit.Host_MajorBearNO9=this.Host_MajorBearNO9;
			Unit.Host_HighPreesurePumpNO1=this.Host_HighPreesurePumpNO1;
			Unit.Host_HighPreesurePumpNO2=this.Host_HighPreesurePumpNO2;
			Unit.Host_HighPreesurePumpNO3=this.Host_HighPreesurePumpNO3;
			Unit.Host_HighPreesurePumpNO4=this.Host_HighPreesurePumpNO4;
			Unit.Host_HighPreesurePumpNO5=this.Host_HighPreesurePumpNO5;
			Unit.Host_HighPreesurePumpNO6=this.Host_HighPreesurePumpNO6;
			Unit.Host_HighPreesurePumpNO7=this.Host_HighPreesurePumpNO7;
			Unit.Host_HighPreesurePumpNO8=this.Host_HighPreesurePumpNO8;
			Unit.Host_HighPreesurePumpNO9=this.Host_HighPreesurePumpNO9;
			Unit.Gas_DismantNO1=this.Gas_DismantNO1;
			Unit.Gas_DismantNO2=this.Gas_DismantNO2;
			Unit.Gas_MarblePanelNO1=this.Gas_MarblePanelNO1;
			Unit.Gas_MarblePanelNO2=this.Gas_MarblePanelNO2;
			Unit.Gas_AirCoolerNO1=this.Gas_AirCoolerNO1;
			Unit.Gas_AirCoolerNO2=this.Gas_AirCoolerNO2;
			Unit.Gas_STotalNO1=this.Gas_STotalNO1;
			Unit.Gas_STotalNO2=this.Gas_STotalNO2;
			Unit.Gas_STotalNO3=this.Gas_STotalNO3;
			Unit.Gas_SLiftingCylinderNO1=this.Gas_SLiftingCylinderNO1;
			Unit.Gas_SLiftingCylinderNO2=this.Gas_SLiftingCylinderNO2;
			Unit.Gas_SLiftingCylinderNO3=this.Gas_SLiftingCylinderNO3;
			Unit.Gas_SExhaustExchangeNO1=this.Gas_SExhaustExchangeNO1;
			Unit.Gas_SExhaustExchangeNO2=this.Gas_SExhaustExchangeNO2;
			Unit.Gas_SExhaustExchangeNO3=this.Gas_SExhaustExchangeNO3;
			Unit.Gas_SOilHeadNO1=this.Gas_SOilHeadNO1;
			Unit.Gas_SOilHeadNO2=this.Gas_SOilHeadNO2;
			Unit.Gas_SOilHeadNO3=this.Gas_SOilHeadNO3;
			Unit.Gas_SMajorBearNO1=this.Gas_SMajorBearNO1;
			Unit.Gas_SMajorBearNO2=this.Gas_SMajorBearNO2;
			Unit.Gas_SMajorBearNO3=this.Gas_SMajorBearNO3;
			Unit.Gas_STurbochargerNO1=this.Gas_STurbochargerNO1;
			Unit.Gas_STurbochargerNO2=this.Gas_STurbochargerNO2;
			Unit.Gas_STurbochargerNO3=this.Gas_STurbochargerNO3;
			Unit.Gas_ACTotalNO1=this.Gas_ACTotalNO1;
			Unit.Gas_ACTotalNO2=this.Gas_ACTotalNO2;
			Unit.Gas_ACTotalNO3=this.Gas_ACTotalNO3;
			Unit.Gas_ACliftingCylinderNO1=this.Gas_ACliftingCylinderNO1;
			Unit.Gas_ACliftingCylinderNO2=this.Gas_ACliftingCylinderNO2;
			Unit.Gas_ACliftingCylinderNO3=this.Gas_ACliftingCylinderNO3;
			Unit.Gas_PPTotalNO1=this.Gas_PPTotalNO1;
			Unit.Gas_PPTotalNO2=this.Gas_PPTotalNO2;
			Unit.Gas_PPCheckNO1=this.Gas_PPCheckNO1;
			Unit.Gas_PPCheckNO2=this.Gas_PPCheckNO2;
			Unit.Gas_Remarks=this.Gas_Remarks;
			Unit.ChiefSign=this.ChiefSign;
			Unit.Pump_MainSeaTotalNO1=this.Pump_MainSeaTotalNO1;
			Unit.Pump_MainSeaTotalNO2=this.Pump_MainSeaTotalNO2;
			Unit.Pump_MainSeaDisintegrationNO1=this.Pump_MainSeaDisintegrationNO1;
			Unit.Pump_MainSeaDisintegrationNO2=this.Pump_MainSeaDisintegrationNO2;
			Unit.Pump_SecondSeaTotal=this.Pump_SecondSeaTotal;
			Unit.Pump_SecondSeaDisintegration=this.Pump_SecondSeaDisintegration;
			Unit.Pump_CylinderTotalNO1=this.Pump_CylinderTotalNO1;
			Unit.Pump_CylinderTotalNO2=this.Pump_CylinderTotalNO2;
			Unit.Pump_CylinderDisintegrationNO1=this.Pump_CylinderDisintegrationNO1;
			Unit.Pump_CylinderDisintegrationNO2=this.Pump_CylinderDisintegrationNO2;
			Unit.Pump_LowTemTotalNO1=this.Pump_LowTemTotalNO1;
			Unit.Pump_LowTemTotalNO2=this.Pump_LowTemTotalNO2;
			Unit.Pump_LowTemDisintegrationNO1=this.Pump_LowTemDisintegrationNO1;
			Unit.Pump_LowTemDisintegrationNO2=this.Pump_LowTemDisintegrationNO2;
			Unit.Pump_ParkLowTemTotal=this.Pump_ParkLowTemTotal;
			Unit.Pump_ParkLowTemDisintegration=this.Pump_ParkLowTemDisintegration;
			Unit.Pump_MainOilTotalNO1=this.Pump_MainOilTotalNO1;
			Unit.Pump_MainOilTotalNO2=this.Pump_MainOilTotalNO2;
			Unit.Pump_MainOilDisintegrationNO1=this.Pump_MainOilDisintegrationNO1;
			Unit.Pump_MainOilDisintegrationNO2=this.Pump_MainOilDisintegrationNO2;
			Unit.Pump_CamshaftOilTotalNO1=this.Pump_CamshaftOilTotalNO1;
			Unit.Pump_CamshaftOilTotalNO2=this.Pump_CamshaftOilTotalNO2;
			Unit.Pump_CamshaftOilDisintegrationNO1=this.Pump_CamshaftOilDisintegrationNO1;
			Unit.Pump_CamshaftOilDisintegrationNO2=this.Pump_CamshaftOilDisintegrationNO2;
			Unit.Pump_BoilerTotal=this.Pump_BoilerTotal;
			Unit.Pump_BoilerDisintegration=this.Pump_BoilerDisintegration;
			Unit.Pump_GeneralToatl=this.Pump_GeneralToatl;
			Unit.Pump_GeneralDisintegration=this.Pump_GeneralDisintegration;
			Unit.Pump_FireTotal=this.Pump_FireTotal;
			Unit.Pump_FireDisintegration=this.Pump_FireDisintegration;
			Unit.Pump_FuelCircleTotalNO1=this.Pump_FuelCircleTotalNO1;
			Unit.Pump_FuelCircleTotalNO2=this.Pump_FuelCircleTotalNO2;
			Unit.Pump_FuelCircleDisintegratinNO1=this.Pump_FuelCircleDisintegratinNO1;
			Unit.Pump_FuelCircleDisintegratinNO2=this.Pump_FuelCircleDisintegratinNO2;
			Unit.Pump_FuelPressureTotalNO1=this.Pump_FuelPressureTotalNO1;
			Unit.Pump_FuelPressureTotalNO2=this.Pump_FuelPressureTotalNO2;
			Unit.Pump_FuelPressureDisintegrationNO1=this.Pump_FuelPressureDisintegrationNO1;
			Unit.Pump_FuelPressureDisintegrationNO2=this.Pump_FuelPressureDisintegrationNO2;
			Unit.Pump_HeavyOilTotalNO1=this.Pump_HeavyOilTotalNO1;
			Unit.Pump_HeavyOilTotalNO2=this.Pump_HeavyOilTotalNO2;
			Unit.Pump_HeavyOilDisintegrationNO1=this.Pump_HeavyOilDisintegrationNO1;
			Unit.Pump_HeavyOilDisintegrationNO2=this.Pump_HeavyOilDisintegrationNO2;
			Unit.Pump_DieselFuelTotal=this.Pump_DieselFuelTotal;
			Unit.Pump_DieselFuelDisintegration=this.Pump_DieselFuelDisintegration;
			Unit.Pump_OilTotalNO1=this.Pump_OilTotalNO1;
			Unit.Pump_OilTotalNO2=this.Pump_OilTotalNO2;
			Unit.Pump_OilDisintegrationNO1=this.Pump_OilDisintegrationNO1;
			Unit.Pump_OilDisintegrationNO2=this.Pump_OilDisintegrationNO2;
			Unit.Pump_BallastTotalNO1=this.Pump_BallastTotalNO1;
			Unit.Pump_BallastTotalNO2=this.Pump_BallastTotalNO2;
			Unit.Pump_BallastDisintegrationNO1=this.Pump_BallastDisintegrationNO1;
			Unit.Pump_BallastDisintegrationNO2=this.Pump_BallastDisintegrationNO2;
			Unit.Pump_EmergencyTotal=this.Pump_EmergencyTotal;
			Unit.Pump_EmergencyDisintegration=this.Pump_EmergencyDisintegration;
            return Unit;
		}
		#endregion
		
		public override string GetId()
        {
            return this.Report_MajorEquipTime_Id;
        }

        public override string GetTypeName()
        {
            return "ReportMajorEquipment";
        }

        public override bool Update(out string err)
        {
            return ReportMajorEquipmentService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return ReportMajorEquipmentService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
