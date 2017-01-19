/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：ReportShipSlave.cs
 * 创 建 人：黄家龙
 * 创建时间：2011/8/30
 * 标    题：实体类
 * 功能描述：T_REPROT_SHIPSLAVE数据实体类
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
	///T_REPROT_SHIPSLAVE数据实体.
	/// </summary>
	///[Serializable]
	public partial class ReportShipSlave : CommonClass
	{		
		#region 构造函数
		///<summary> 
		///船舶副机工况报表.
		///</summary>
		public ReportShipSlave()
		{
		}
		///<summary>
		///船舶副机工况报表.
		///</summary>
		public ReportShipSlave
		(
			string report_ShipSlave_Id,
			string sHIP_ID,
			string file_ID,
			string voyage,
			DateTime tableWritedDate,
			DateTime slave_ParaAbstractedDate,
			DateTime slave_RecordDate,
			string slave_EditID,
			string slave_SmokeHignNO,
			string slave_SmokeHignTem,
			string slave_SmokeLowNO,
			string slave_SmokeLowTem,
			string slave_CoolSystemInTem,
			string slave_CoolSystemOutTem,
			string slave_OilinTem,
			string slave_OilOutTem,
			string slave_FuelInTem,
			string slave_PressureAirTem,
			string slave_CoolWaterHignMPa,
			string slave_CoolWaterLowMPa,
			string slave_OilInMpa,
			string slave_FuelInMpa,
			string slave_PressureAirMPa,
			string slave_GeneratorVoltage,
			string slave_GeneratorCurrent,
			string slavae_GeneratorKW,
			string sS_DieselNoOne,
			string sS_DieselNoTwo,
			string sS_DieselNoOnePressureNO1,
			string sS_DieselNoOnePressureNO2,
			string sS_DieselNoOnePressureNO3,
			string sS_DieselNoOnePressureNO4,
			string sS_DieselNoOnePressureNO5,
			string sS_DieselNoOnePressureNO6,
			string sS_DieselNoOnePressureNO7,
			string sS_DieselNoOnePressureNO8,
			string sS_DieselNoOneTemNO1,
			string sS_DieselNoOneTemNO2,
			string sS_DieselNoOneTemNO3,
			string sS_DieselNoOneTemNO4,
			string sS_DieselNoOneTemNO5,
			string sS_DieselNoOneTemNO6,
			string sS_DieselNoOneTemNO7,
			string sS_DieselNoOneTemNO8,
			string sS_DieselNoTwoPressureNO1,
			string sS_DieselNoTwoPressureNO2,
			string sS_DieselNoTwoPressureNO3,
			string sS_DieselNoTwoPressureNO4,
			string sS_DieselNoTwoPressureNO5,
			string sS_DieselNoTwoPressureNO6,
			string sS_DieselNoTwoPressureNO7,
			string sS_DieselNoTwoPressureNO8,
			string sS_DieselNoTwoTemNO1,
			string sS_DieselNoTwoTemNO2,
			string sS_DieselNoTwoTemNO3,
			string sS_DieselNoTwoTemNO4,
			string sS_DieselNoTwoTemNO5,
			string sS_DieselNoTwoTemNO6,
			string sS_DieselNoTwoTemNO7,
			string sS_DieselNoTwoTemNO8,
			string sS_DieselFuelSpecifation,
			string sS_SDieselFuelConsumption1,
			string sS_SDieselFuelConsumption2,
			string sS_SDieselFuelConsumption3,
			string sS_SDieselFuelConsumption4,
			string slave_SecondChiefSign,
			DateTime slave_SecondChiefSignDate,
			string slave_ChiefSign,
			DateTime slave_ChiefSignDate,
			string slave_DirectorSign,
			DateTime slave_DirectorSignDate
		)
		{
			this.Report_ShipSlave_Id        = report_ShipSlave_Id;
			this.SHIP_ID                    = sHIP_ID;
			this.File_ID                    = file_ID;
			this.Voyage                     = voyage;
			this.TableWritedDate            = tableWritedDate;
			this.Slave_ParaAbstractedDate   = slave_ParaAbstractedDate;
			this.Slave_RecordDate           = slave_RecordDate;
			this.Slave_EditID               = slave_EditID;
			this.Slave_SmokeHignNO          = slave_SmokeHignNO;
			this.Slave_SmokeHignTem         = slave_SmokeHignTem;
			this.Slave_SmokeLowNO           = slave_SmokeLowNO;
			this.Slave_SmokeLowTem          = slave_SmokeLowTem;
			this.Slave_CoolSystemInTem      = slave_CoolSystemInTem;
			this.Slave_CoolSystemOutTem     = slave_CoolSystemOutTem;
			this.Slave_OilinTem             = slave_OilinTem;
			this.Slave_OilOutTem            = slave_OilOutTem;
			this.Slave_FuelInTem            = slave_FuelInTem;
			this.Slave_PressureAirTem       = slave_PressureAirTem;
			this.Slave_CoolWaterHignMPa     = slave_CoolWaterHignMPa;
			this.Slave_CoolWaterLowMPa      = slave_CoolWaterLowMPa;
			this.Slave_OilInMpa             = slave_OilInMpa;
			this.Slave_FuelInMpa            = slave_FuelInMpa;
			this.Slave_PressureAirMPa       = slave_PressureAirMPa;
			this.Slave_GeneratorVoltage     = slave_GeneratorVoltage;
			this.Slave_GeneratorCurrent     = slave_GeneratorCurrent;
			this.Slavae_GeneratorKW         = slavae_GeneratorKW;
			this.SS_DieselNoOne             = sS_DieselNoOne;
			this.SS_DieselNoTwo             = sS_DieselNoTwo;
			this.SS_DieselNoOnePressureNO1  = sS_DieselNoOnePressureNO1;
			this.SS_DieselNoOnePressureNO2  = sS_DieselNoOnePressureNO2;
			this.SS_DieselNoOnePressureNO3  = sS_DieselNoOnePressureNO3;
			this.SS_DieselNoOnePressureNO4  = sS_DieselNoOnePressureNO4;
			this.SS_DieselNoOnePressureNO5  = sS_DieselNoOnePressureNO5;
			this.SS_DieselNoOnePressureNO6  = sS_DieselNoOnePressureNO6;
			this.SS_DieselNoOnePressureNO7  = sS_DieselNoOnePressureNO7;
			this.SS_DieselNoOnePressureNO8  = sS_DieselNoOnePressureNO8;
			this.SS_DieselNoOneTemNO1       = sS_DieselNoOneTemNO1;
			this.SS_DieselNoOneTemNO2       = sS_DieselNoOneTemNO2;
			this.SS_DieselNoOneTemNO3       = sS_DieselNoOneTemNO3;
			this.SS_DieselNoOneTemNO4       = sS_DieselNoOneTemNO4;
			this.SS_DieselNoOneTemNO5       = sS_DieselNoOneTemNO5;
			this.SS_DieselNoOneTemNO6       = sS_DieselNoOneTemNO6;
			this.SS_DieselNoOneTemNO7       = sS_DieselNoOneTemNO7;
			this.SS_DieselNoOneTemNO8       = sS_DieselNoOneTemNO8;
			this.SS_DieselNoTwoPressureNO1  = sS_DieselNoTwoPressureNO1;
			this.SS_DieselNoTwoPressureNO2  = sS_DieselNoTwoPressureNO2;
			this.SS_DieselNoTwoPressureNO3  = sS_DieselNoTwoPressureNO3;
			this.SS_DieselNoTwoPressureNO4  = sS_DieselNoTwoPressureNO4;
			this.SS_DieselNoTwoPressureNO5  = sS_DieselNoTwoPressureNO5;
			this.SS_DieselNoTwoPressureNO6  = sS_DieselNoTwoPressureNO6;
			this.SS_DieselNoTwoPressureNO7  = sS_DieselNoTwoPressureNO7;
			this.SS_DieselNoTwoPressureNO8  = sS_DieselNoTwoPressureNO8;
			this.SS_DieselNoTwoTemNO1       = sS_DieselNoTwoTemNO1;
			this.SS_DieselNoTwoTemNO2       = sS_DieselNoTwoTemNO2;
			this.SS_DieselNoTwoTemNO3       = sS_DieselNoTwoTemNO3;
			this.SS_DieselNoTwoTemNO4       = sS_DieselNoTwoTemNO4;
			this.SS_DieselNoTwoTemNO5       = sS_DieselNoTwoTemNO5;
			this.SS_DieselNoTwoTemNO6       = sS_DieselNoTwoTemNO6;
			this.SS_DieselNoTwoTemNO7       = sS_DieselNoTwoTemNO7;
			this.SS_DieselNoTwoTemNO8       = sS_DieselNoTwoTemNO8;
			this.SS_DieselFuelSpecifation   = sS_DieselFuelSpecifation;
			this.SS_SDieselFuelConsumption1 = sS_SDieselFuelConsumption1;
			this.SS_SDieselFuelConsumption2 = sS_SDieselFuelConsumption2;
			this.SS_SDieselFuelConsumption3 = sS_SDieselFuelConsumption3;
			this.SS_SDieselFuelConsumption4 = sS_SDieselFuelConsumption4;
			this.Slave_SecondChiefSign      = slave_SecondChiefSign;
			this.Slave_SecondChiefSignDate  = slave_SecondChiefSignDate;
			this.Slave_ChiefSign            = slave_ChiefSign;
			this.Slave_ChiefSignDate        = slave_ChiefSignDate;
			this.Slave_DirectorSign         = slave_DirectorSign;
			this.Slave_DirectorSignDate     = slave_DirectorSignDate;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///主键.
		///</summary>
		public string Report_ShipSlave_Id{get ;set;}

		///<summary>
		///船ID
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
		///填表日期.
		///</summary>
		public DateTime TableWritedDate{get ;set;}

		///<summary>
		///主机参数摘录日期.
		///</summary>
		public DateTime Slave_ParaAbstractedDate{get ;set;}

		///<summary>
		///日期.
		///</summary>
		public DateTime Slave_RecordDate{get ;set;}

		///<summary>
		///副机编号.
		///</summary>
		public string Slave_EditID{get ;set;}

		///<summary>
		///排烟温度最高缸号.
		///</summary>
		public string Slave_SmokeHignNO{get ;set;}

		///<summary>
		///排烟温度最高温度.
		///</summary>
		public string Slave_SmokeHignTem{get ;set;}

		///<summary>
		///排烟最低缸号.
		///</summary>
		public string Slave_SmokeLowNO{get ;set;}

		///<summary>
		///排烟温度最低温度.
		///</summary>
		public string Slave_SmokeLowTem{get ;set;}

		///<summary>
		///机器冷却系统水温进机温度.
		///</summary>
		public string Slave_CoolSystemInTem{get ;set;}

		///<summary>
		///机器冷却系统出机温度.
		///</summary>
		public string Slave_CoolSystemOutTem{get ;set;}

		///<summary>
		///滑油进机.
		///</summary>
		public string Slave_OilinTem{get ;set;}

		///<summary>
		///滑油出机.
		///</summary>
		public string Slave_OilOutTem{get ;set;}

		///<summary>
		///燃油进机温度.
		///</summary>
		public string Slave_FuelInTem{get ;set;}

		///<summary>
		///增压空气温度.
		///</summary>
		public string Slave_PressureAirTem{get ;set;}

		///<summary>
		///冷却淡水高温压力.
		///</summary>
		public string Slave_CoolWaterHignMPa{get ;set;}

		///<summary>
		///冷却淡水低温压力.
		///</summary>
		public string Slave_CoolWaterLowMPa{get ;set;}

		///<summary>
		///滑油进机压力.
		///</summary>
		public string Slave_OilInMpa{get ;set;}

		///<summary>
		///燃油进机压力.
		///</summary>
		public string Slave_FuelInMpa{get ;set;}

		///<summary>
		///增压空气压力.
		///</summary>
		public string Slave_PressureAirMPa{get ;set;}

		///<summary>
		///发电机电压V
		///</summary>
		public string Slave_GeneratorVoltage{get ;set;}

		///<summary>
		///发电机电流A
		///</summary>
		public string Slave_GeneratorCurrent{get ;set;}

		///<summary>
		///发电机功率KW
		///</summary>
		public string Slavae_GeneratorKW{get ;set;}

		///<summary>
		///柴油机热工机号1
		///</summary>
		public string SS_DieselNoOne{get ;set;}

		///<summary>
		///柴油机热工机号2
		///</summary>
		public string SS_DieselNoTwo{get ;set;}

		///<summary>
		///柴油机热工机号1   爆压   缸号1
		///</summary>
		public string SS_DieselNoOnePressureNO1{get ;set;}

		///<summary>
		///柴油机热工机号1   爆压   缸号2
		///</summary>
		public string SS_DieselNoOnePressureNO2{get ;set;}

		///<summary>
		///柴油机热工机号1   爆压   缸号3
		///</summary>
		public string SS_DieselNoOnePressureNO3{get ;set;}

		///<summary>
		///柴油机热工机号1   爆压   缸号4
		///</summary>
		public string SS_DieselNoOnePressureNO4{get ;set;}

		///<summary>
		///柴油机热工机号1   爆压   缸号5
		///</summary>
		public string SS_DieselNoOnePressureNO5{get ;set;}

		///<summary>
		///柴油机热工机号1   爆压   缸号6
		///</summary>
		public string SS_DieselNoOnePressureNO6{get ;set;}

		///<summary>
		///柴油机热工机号1   爆压   缸号7
		///</summary>
		public string SS_DieselNoOnePressureNO7{get ;set;}

		///<summary>
		///柴油机热工机号1   爆压   缸号8
		///</summary>
		public string SS_DieselNoOnePressureNO8{get ;set;}

		///<summary>
		///柴油机热工机号1   排温  缸号1
		///</summary>
		public string SS_DieselNoOneTemNO1{get ;set;}

		///<summary>
		///柴油机热工机号1   排温  缸号2
		///</summary>
		public string SS_DieselNoOneTemNO2{get ;set;}

		///<summary>
		///柴油机热工机号1   排温  缸号3
		///</summary>
		public string SS_DieselNoOneTemNO3{get ;set;}

		///<summary>
		///柴油机热工机号1   排温  缸号4
		///</summary>
		public string SS_DieselNoOneTemNO4{get ;set;}

		///<summary>
		///柴油机热工机号1   排温  缸号5
		///</summary>
		public string SS_DieselNoOneTemNO5{get ;set;}

		///<summary>
		///柴油机热工机号1   排温  缸号6
		///</summary>
		public string SS_DieselNoOneTemNO6{get ;set;}

		///<summary>
		///柴油机热工机号1   排温  缸号7
		///</summary>
		public string SS_DieselNoOneTemNO7{get ;set;}

		///<summary>
		///柴油机热工机号1   排温  缸号8
		///</summary>
		public string SS_DieselNoOneTemNO8{get ;set;}

		///<summary>
		///柴油机热工机号2  爆压 缸号1
		///</summary>
		public string SS_DieselNoTwoPressureNO1{get ;set;}

		///<summary>
		///柴油机热工机号2  爆压 缸号2
		///</summary>
		public string SS_DieselNoTwoPressureNO2{get ;set;}

		///<summary>
		///柴油机热工机号2  爆压 缸号3
		///</summary>
		public string SS_DieselNoTwoPressureNO3{get ;set;}

		///<summary>
		///柴油机热工机号2  爆压 缸号4
		///</summary>
		public string SS_DieselNoTwoPressureNO4{get ;set;}

		///<summary>
		///柴油机热工机号2  爆压 缸号5
		///</summary>
		public string SS_DieselNoTwoPressureNO5{get ;set;}

		///<summary>
		///柴油机热工机号2  爆压 缸号6
		///</summary>
		public string SS_DieselNoTwoPressureNO6{get ;set;}

		///<summary>
		///柴油机热工机号2  爆压 缸号7
		///</summary>
		public string SS_DieselNoTwoPressureNO7{get ;set;}

		///<summary>
		///柴油机热工机号2  爆压 缸号8
		///</summary>
		public string SS_DieselNoTwoPressureNO8{get ;set;}

		///<summary>
		///柴油机热工机号2  排温  缸号1
		///</summary>
		public string SS_DieselNoTwoTemNO1{get ;set;}

		///<summary>
		///柴油机热工机号2  排温  缸号2
		///</summary>
		public string SS_DieselNoTwoTemNO2{get ;set;}

		///<summary>
		///柴油机热工机号2  排温  缸号3
		///</summary>
		public string SS_DieselNoTwoTemNO3{get ;set;}

		///<summary>
		///柴油机热工机号2  排温  缸号4
		///</summary>
		public string SS_DieselNoTwoTemNO4{get ;set;}

		///<summary>
		///柴油机热工机号2  排温  缸号5
		///</summary>
		public string SS_DieselNoTwoTemNO5{get ;set;}

		///<summary>
		///柴油机热工机号2  排温  缸号6
		///</summary>
		public string SS_DieselNoTwoTemNO6{get ;set;}

		///<summary>
		///柴油机热工机号2  排温  缸号7
		///</summary>
		public string SS_DieselNoTwoTemNO7{get ;set;}

		///<summary>
		///柴油机热工机号2  排温  缸号8
		///</summary>
		public string SS_DieselNoTwoTemNO8{get ;set;}

		///<summary>
		///油规格.
		///</summary>
		public string SS_DieselFuelSpecifation{get ;set;}

		///<summary>
		///副机编号1    日消耗量.
		///</summary>
		public string SS_SDieselFuelConsumption1{get ;set;}

		///<summary>
		///副机编号2    日消耗量.
		///</summary>
		public string SS_SDieselFuelConsumption2{get ;set;}

		///<summary>
		///副机编号3    日消耗量.
		///</summary>
		public string SS_SDieselFuelConsumption3{get ;set;}

		///<summary>
		///副机编号4    日消耗量.
		///</summary>
		public string SS_SDieselFuelConsumption4{get ;set;}

		///<summary>
		///二管轮签字.
		///</summary>
		public string Slave_SecondChiefSign{get ;set;}

		///<summary>
		///二管轮签字日期.
		///</summary>
		public DateTime Slave_SecondChiefSignDate{get ;set;}

		///<summary>
		///轮机长签字.
		///</summary>
		public string Slave_ChiefSign{get ;set;}

		///<summary>
		///轮机长签字日期.
		///</summary>
		public DateTime Slave_ChiefSignDate{get ;set;}

		///<summary>
		///机务主管签名.
		///</summary>
		public string Slave_DirectorSign{get ;set;}

		///<summary>
		///机务主管签名日期.
		///</summary>
		public DateTime Slave_DirectorSignDate{get ;set;}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public override CommonClass Clone()
		{
			ReportShipSlave Unit = new ReportShipSlave();
			Unit.Report_ShipSlave_Id=this.Report_ShipSlave_Id;
			Unit.SHIP_ID=this.SHIP_ID;
			Unit.File_ID=this.File_ID;
			Unit.Voyage=this.Voyage;
			Unit.TableWritedDate=this.TableWritedDate;
			Unit.Slave_ParaAbstractedDate=this.Slave_ParaAbstractedDate;
			Unit.Slave_RecordDate=this.Slave_RecordDate;
			Unit.Slave_EditID=this.Slave_EditID;
			Unit.Slave_SmokeHignNO=this.Slave_SmokeHignNO;
			Unit.Slave_SmokeHignTem=this.Slave_SmokeHignTem;
			Unit.Slave_SmokeLowNO=this.Slave_SmokeLowNO;
			Unit.Slave_SmokeLowTem=this.Slave_SmokeLowTem;
			Unit.Slave_CoolSystemInTem=this.Slave_CoolSystemInTem;
			Unit.Slave_CoolSystemOutTem=this.Slave_CoolSystemOutTem;
			Unit.Slave_OilinTem=this.Slave_OilinTem;
			Unit.Slave_OilOutTem=this.Slave_OilOutTem;
			Unit.Slave_FuelInTem=this.Slave_FuelInTem;
			Unit.Slave_PressureAirTem=this.Slave_PressureAirTem;
			Unit.Slave_CoolWaterHignMPa=this.Slave_CoolWaterHignMPa;
			Unit.Slave_CoolWaterLowMPa=this.Slave_CoolWaterLowMPa;
			Unit.Slave_OilInMpa=this.Slave_OilInMpa;
			Unit.Slave_FuelInMpa=this.Slave_FuelInMpa;
			Unit.Slave_PressureAirMPa=this.Slave_PressureAirMPa;
			Unit.Slave_GeneratorVoltage=this.Slave_GeneratorVoltage;
			Unit.Slave_GeneratorCurrent=this.Slave_GeneratorCurrent;
			Unit.Slavae_GeneratorKW=this.Slavae_GeneratorKW;
			Unit.SS_DieselNoOne=this.SS_DieselNoOne;
			Unit.SS_DieselNoTwo=this.SS_DieselNoTwo;
			Unit.SS_DieselNoOnePressureNO1=this.SS_DieselNoOnePressureNO1;
			Unit.SS_DieselNoOnePressureNO2=this.SS_DieselNoOnePressureNO2;
			Unit.SS_DieselNoOnePressureNO3=this.SS_DieselNoOnePressureNO3;
			Unit.SS_DieselNoOnePressureNO4=this.SS_DieselNoOnePressureNO4;
			Unit.SS_DieselNoOnePressureNO5=this.SS_DieselNoOnePressureNO5;
			Unit.SS_DieselNoOnePressureNO6=this.SS_DieselNoOnePressureNO6;
			Unit.SS_DieselNoOnePressureNO7=this.SS_DieselNoOnePressureNO7;
			Unit.SS_DieselNoOnePressureNO8=this.SS_DieselNoOnePressureNO8;
			Unit.SS_DieselNoOneTemNO1=this.SS_DieselNoOneTemNO1;
			Unit.SS_DieselNoOneTemNO2=this.SS_DieselNoOneTemNO2;
			Unit.SS_DieselNoOneTemNO3=this.SS_DieselNoOneTemNO3;
			Unit.SS_DieselNoOneTemNO4=this.SS_DieselNoOneTemNO4;
			Unit.SS_DieselNoOneTemNO5=this.SS_DieselNoOneTemNO5;
			Unit.SS_DieselNoOneTemNO6=this.SS_DieselNoOneTemNO6;
			Unit.SS_DieselNoOneTemNO7=this.SS_DieselNoOneTemNO7;
			Unit.SS_DieselNoOneTemNO8=this.SS_DieselNoOneTemNO8;
			Unit.SS_DieselNoTwoPressureNO1=this.SS_DieselNoTwoPressureNO1;
			Unit.SS_DieselNoTwoPressureNO2=this.SS_DieselNoTwoPressureNO2;
			Unit.SS_DieselNoTwoPressureNO3=this.SS_DieselNoTwoPressureNO3;
			Unit.SS_DieselNoTwoPressureNO4=this.SS_DieselNoTwoPressureNO4;
			Unit.SS_DieselNoTwoPressureNO5=this.SS_DieselNoTwoPressureNO5;
			Unit.SS_DieselNoTwoPressureNO6=this.SS_DieselNoTwoPressureNO6;
			Unit.SS_DieselNoTwoPressureNO7=this.SS_DieselNoTwoPressureNO7;
			Unit.SS_DieselNoTwoPressureNO8=this.SS_DieselNoTwoPressureNO8;
			Unit.SS_DieselNoTwoTemNO1=this.SS_DieselNoTwoTemNO1;
			Unit.SS_DieselNoTwoTemNO2=this.SS_DieselNoTwoTemNO2;
			Unit.SS_DieselNoTwoTemNO3=this.SS_DieselNoTwoTemNO3;
			Unit.SS_DieselNoTwoTemNO4=this.SS_DieselNoTwoTemNO4;
			Unit.SS_DieselNoTwoTemNO5=this.SS_DieselNoTwoTemNO5;
			Unit.SS_DieselNoTwoTemNO6=this.SS_DieselNoTwoTemNO6;
			Unit.SS_DieselNoTwoTemNO7=this.SS_DieselNoTwoTemNO7;
			Unit.SS_DieselNoTwoTemNO8=this.SS_DieselNoTwoTemNO8;
			Unit.SS_DieselFuelSpecifation=this.SS_DieselFuelSpecifation;
			Unit.SS_SDieselFuelConsumption1=this.SS_SDieselFuelConsumption1;
			Unit.SS_SDieselFuelConsumption2=this.SS_SDieselFuelConsumption2;
			Unit.SS_SDieselFuelConsumption3=this.SS_SDieselFuelConsumption3;
			Unit.SS_SDieselFuelConsumption4=this.SS_SDieselFuelConsumption4;
			Unit.Slave_SecondChiefSign=this.Slave_SecondChiefSign;
			Unit.Slave_SecondChiefSignDate=this.Slave_SecondChiefSignDate;
			Unit.Slave_ChiefSign=this.Slave_ChiefSign;
			Unit.Slave_ChiefSignDate=this.Slave_ChiefSignDate;
			Unit.Slave_DirectorSign=this.Slave_DirectorSign;
			Unit.Slave_DirectorSignDate=this.Slave_DirectorSignDate;
            return Unit;
		}
		#endregion
		
		public override string GetId()
        {
            return this.Report_ShipSlave_Id;
        }

        public override string GetTypeName()
        {
            return "ReportShipSlave";
        }

        public override bool Update(out string err)
        {
            return ReportShipSlaveService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return ReportShipSlaveService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
