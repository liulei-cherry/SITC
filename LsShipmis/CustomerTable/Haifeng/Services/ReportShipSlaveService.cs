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
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static ReportShipSlaveService instance=new ReportShipSlaveService();
        public static ReportShipSlaveService Instance
        { 
            get
            {
                if(null==instance)
                {
                    ReportShipSlaveService.instance = new ReportShipSlaveService();
                }
                return ReportShipSlaveService.instance;
            }
        }
		private ReportShipSlaveService(){}
		#endregion
		
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();        
        string sql = ""; 
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">ReportShipSlave对象</param>
		/// <returns>插入的对象更新</returns>	
		internal bool saveUnit(ReportShipSlave unit,out string err)
        {
			if (unit.Report_ShipSlave_Id!=null && unit.Report_ShipSlave_Id.Length > 0) //edit
			{
				sql = "UPDATE [T_REPROT_SHIPSLAVE] SET "
					+ " [Report_ShipSlave_Id] = " + (unit.Report_ShipSlave_Id==null?"''":"'" + unit.Report_ShipSlave_Id.Replace ("'","''") + "'")
					+ " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ " , [File_ID] = " + (string.IsNullOrEmpty(unit.File_ID)?"null":"'" + unit.File_ID.Replace ("'","''") + "'")
					+ " , [Voyage] = " + (unit.Voyage==null?"''":"'" + unit.Voyage.Replace ("'","''") + "'")
                    + " , [TableWritedDate] = " + dbOperation.DbToDate(unit.TableWritedDate)
                    + " , [Slave_ParaAbstractedDate] = " + dbOperation.DbToDate(unit.Slave_ParaAbstractedDate)
                    + " , [Slave_RecordDate] = " + dbOperation.DbToDate(unit.Slave_RecordDate)
					+ " , [Slave_EditID] = " + (string.IsNullOrEmpty(unit.Slave_EditID)?"null":"'" + unit.Slave_EditID.Replace ("'","''") + "'")
					+ " , [Slave_SmokeHignNO] = " + (unit.Slave_SmokeHignNO==null?"''":"'" + unit.Slave_SmokeHignNO.Replace ("'","''") + "'")
					+ " , [Slave_SmokeHignTem] = " + (unit.Slave_SmokeHignTem==null?"''":"'" + unit.Slave_SmokeHignTem.Replace ("'","''") + "'")
					+ " , [Slave_SmokeLowNO] = " + (unit.Slave_SmokeLowNO==null?"''":"'" + unit.Slave_SmokeLowNO.Replace ("'","''") + "'")
					+ " , [Slave_SmokeLowTem] = " + (unit.Slave_SmokeLowTem==null?"''":"'" + unit.Slave_SmokeLowTem.Replace ("'","''") + "'")
					+ " , [Slave_CoolSystemInTem] = " + (unit.Slave_CoolSystemInTem==null?"''":"'" + unit.Slave_CoolSystemInTem.Replace ("'","''") + "'")
					+ " , [Slave_CoolSystemOutTem] = " + (unit.Slave_CoolSystemOutTem==null?"''":"'" + unit.Slave_CoolSystemOutTem.Replace ("'","''") + "'")
					+ " , [Slave_OilinTem] = " + (unit.Slave_OilinTem==null?"''":"'" + unit.Slave_OilinTem.Replace ("'","''") + "'")
					+ " , [Slave_OilOutTem] = " + (unit.Slave_OilOutTem==null?"''":"'" + unit.Slave_OilOutTem.Replace ("'","''") + "'")
					+ " , [Slave_FuelInTem] = " + (unit.Slave_FuelInTem==null?"''":"'" + unit.Slave_FuelInTem.Replace ("'","''") + "'")
					+ " , [Slave_PressureAirTem] = " + (unit.Slave_PressureAirTem==null?"''":"'" + unit.Slave_PressureAirTem.Replace ("'","''") + "'")
					+ " , [Slave_CoolWaterHignMPa] = " + (unit.Slave_CoolWaterHignMPa==null?"''":"'" + unit.Slave_CoolWaterHignMPa.Replace ("'","''") + "'")
					+ " , [Slave_CoolWaterLowMPa] = " + (unit.Slave_CoolWaterLowMPa==null?"''":"'" + unit.Slave_CoolWaterLowMPa.Replace ("'","''") + "'")
					+ " , [Slave_OilInMpa] = " + (unit.Slave_OilInMpa==null?"''":"'" + unit.Slave_OilInMpa.Replace ("'","''") + "'")
					+ " , [Slave_FuelInMpa] = " + (unit.Slave_FuelInMpa==null?"''":"'" + unit.Slave_FuelInMpa.Replace ("'","''") + "'")
					+ " , [Slave_PressureAirMPa] = " + (unit.Slave_PressureAirMPa==null?"''":"'" + unit.Slave_PressureAirMPa.Replace ("'","''") + "'")
					+ " , [Slave_GeneratorVoltage] = " + (unit.Slave_GeneratorVoltage==null?"''":"'" + unit.Slave_GeneratorVoltage.Replace ("'","''") + "'")
					+ " , [Slave_GeneratorCurrent] = " + (unit.Slave_GeneratorCurrent==null?"''":"'" + unit.Slave_GeneratorCurrent.Replace ("'","''") + "'")
					+ " , [Slavae_GeneratorKW] = " + (unit.Slavae_GeneratorKW==null?"''":"'" + unit.Slavae_GeneratorKW.Replace ("'","''") + "'")
					+ " , [SS_DieselNoOne] = " + (unit.SS_DieselNoOne==null?"''":"'" + unit.SS_DieselNoOne.Replace ("'","''") + "'")
					+ " , [SS_DieselNoTwo] = " + (unit.SS_DieselNoTwo==null?"''":"'" + unit.SS_DieselNoTwo.Replace ("'","''") + "'")
					+ " , [SS_DieselNoOnePressureNO1] = " + (unit.SS_DieselNoOnePressureNO1==null?"''":"'" + unit.SS_DieselNoOnePressureNO1.Replace ("'","''") + "'")
					+ " , [SS_DieselNoOnePressureNO2] = " + (unit.SS_DieselNoOnePressureNO2==null?"''":"'" + unit.SS_DieselNoOnePressureNO2.Replace ("'","''") + "'")
					+ " , [SS_DieselNoOnePressureNO3] = " + (unit.SS_DieselNoOnePressureNO3==null?"''":"'" + unit.SS_DieselNoOnePressureNO3.Replace ("'","''") + "'")
					+ " , [SS_DieselNoOnePressureNO4] = " + (unit.SS_DieselNoOnePressureNO4==null?"''":"'" + unit.SS_DieselNoOnePressureNO4.Replace ("'","''") + "'")
					+ " , [SS_DieselNoOnePressureNO5] = " + (unit.SS_DieselNoOnePressureNO5==null?"''":"'" + unit.SS_DieselNoOnePressureNO5.Replace ("'","''") + "'")
					+ " , [SS_DieselNoOnePressureNO6] = " + (unit.SS_DieselNoOnePressureNO6==null?"''":"'" + unit.SS_DieselNoOnePressureNO6.Replace ("'","''") + "'")
					+ " , [SS_DieselNoOnePressureNO7] = " + (unit.SS_DieselNoOnePressureNO7==null?"''":"'" + unit.SS_DieselNoOnePressureNO7.Replace ("'","''") + "'")
					+ " , [SS_DieselNoOnePressureNO8] = " + (unit.SS_DieselNoOnePressureNO8==null?"''":"'" + unit.SS_DieselNoOnePressureNO8.Replace ("'","''") + "'")
					+ " , [SS_DieselNoOneTemNO1] = " + (unit.SS_DieselNoOneTemNO1==null?"''":"'" + unit.SS_DieselNoOneTemNO1.Replace ("'","''") + "'")
					+ " , [SS_DieselNoOneTemNO2] = " + (unit.SS_DieselNoOneTemNO2==null?"''":"'" + unit.SS_DieselNoOneTemNO2.Replace ("'","''") + "'")
					+ " , [SS_DieselNoOneTemNO3] = " + (unit.SS_DieselNoOneTemNO3==null?"''":"'" + unit.SS_DieselNoOneTemNO3.Replace ("'","''") + "'")
					+ " , [SS_DieselNoOneTemNO4] = " + (unit.SS_DieselNoOneTemNO4==null?"''":"'" + unit.SS_DieselNoOneTemNO4.Replace ("'","''") + "'")
					+ " , [SS_DieselNoOneTemNO5] = " + (unit.SS_DieselNoOneTemNO5==null?"''":"'" + unit.SS_DieselNoOneTemNO5.Replace ("'","''") + "'")
					+ " , [SS_DieselNoOneTemNO6] = " + (unit.SS_DieselNoOneTemNO6==null?"''":"'" + unit.SS_DieselNoOneTemNO6.Replace ("'","''") + "'")
					+ " , [SS_DieselNoOneTemNO7] = " + (unit.SS_DieselNoOneTemNO7==null?"''":"'" + unit.SS_DieselNoOneTemNO7.Replace ("'","''") + "'")
					+ " , [SS_DieselNoOneTemNO8] = " + (unit.SS_DieselNoOneTemNO8==null?"''":"'" + unit.SS_DieselNoOneTemNO8.Replace ("'","''") + "'")
					+ " , [SS_DieselNoTwoPressureNO1] = " + (unit.SS_DieselNoTwoPressureNO1==null?"''":"'" + unit.SS_DieselNoTwoPressureNO1.Replace ("'","''") + "'")
					+ " , [SS_DieselNoTwoPressureNO2] = " + (unit.SS_DieselNoTwoPressureNO2==null?"''":"'" + unit.SS_DieselNoTwoPressureNO2.Replace ("'","''") + "'")
					+ " , [SS_DieselNoTwoPressureNO3] = " + (unit.SS_DieselNoTwoPressureNO3==null?"''":"'" + unit.SS_DieselNoTwoPressureNO3.Replace ("'","''") + "'")
					+ " , [SS_DieselNoTwoPressureNO4] = " + (unit.SS_DieselNoTwoPressureNO4==null?"''":"'" + unit.SS_DieselNoTwoPressureNO4.Replace ("'","''") + "'")
					+ " , [SS_DieselNoTwoPressureNO5] = " + (unit.SS_DieselNoTwoPressureNO5==null?"''":"'" + unit.SS_DieselNoTwoPressureNO5.Replace ("'","''") + "'")
					+ " , [SS_DieselNoTwoPressureNO6] = " + (unit.SS_DieselNoTwoPressureNO6==null?"''":"'" + unit.SS_DieselNoTwoPressureNO6.Replace ("'","''") + "'")
					+ " , [SS_DieselNoTwoPressureNO7] = " + (unit.SS_DieselNoTwoPressureNO7==null?"''":"'" + unit.SS_DieselNoTwoPressureNO7.Replace ("'","''") + "'")
					+ " , [SS_DieselNoTwoPressureNO8] = " + (unit.SS_DieselNoTwoPressureNO8==null?"''":"'" + unit.SS_DieselNoTwoPressureNO8.Replace ("'","''") + "'")
					+ " , [SS_DieselNoTwoTemNO1] = " + (unit.SS_DieselNoTwoTemNO1==null?"''":"'" + unit.SS_DieselNoTwoTemNO1.Replace ("'","''") + "'")
					+ " , [SS_DieselNoTwoTemNO2] = " + (unit.SS_DieselNoTwoTemNO2==null?"''":"'" + unit.SS_DieselNoTwoTemNO2.Replace ("'","''") + "'")
					+ " , [SS_DieselNoTwoTemNO3] = " + (unit.SS_DieselNoTwoTemNO3==null?"''":"'" + unit.SS_DieselNoTwoTemNO3.Replace ("'","''") + "'")
					+ " , [SS_DieselNoTwoTemNO4] = " + (unit.SS_DieselNoTwoTemNO4==null?"''":"'" + unit.SS_DieselNoTwoTemNO4.Replace ("'","''") + "'")
					+ " , [SS_DieselNoTwoTemNO5] = " + (unit.SS_DieselNoTwoTemNO5==null?"''":"'" + unit.SS_DieselNoTwoTemNO5.Replace ("'","''") + "'")
					+ " , [SS_DieselNoTwoTemNO6] = " + (unit.SS_DieselNoTwoTemNO6==null?"''":"'" + unit.SS_DieselNoTwoTemNO6.Replace ("'","''") + "'")
					+ " , [SS_DieselNoTwoTemNO7] = " + (unit.SS_DieselNoTwoTemNO7==null?"''":"'" + unit.SS_DieselNoTwoTemNO7.Replace ("'","''") + "'")
					+ " , [SS_DieselNoTwoTemNO8] = " + (unit.SS_DieselNoTwoTemNO8==null?"''":"'" + unit.SS_DieselNoTwoTemNO8.Replace ("'","''") + "'")
					+ " , [SS_DieselFuelSpecifation] = " + (unit.SS_DieselFuelSpecifation==null?"''":"'" + unit.SS_DieselFuelSpecifation.Replace ("'","''") + "'")
					+ " , [SS_SDieselFuelConsumption1] = " + (unit.SS_SDieselFuelConsumption1==null?"''":"'" + unit.SS_SDieselFuelConsumption1.Replace ("'","''") + "'")
					+ " , [SS_SDieselFuelConsumption2] = " + (unit.SS_SDieselFuelConsumption2==null?"''":"'" + unit.SS_SDieselFuelConsumption2.Replace ("'","''") + "'")
					+ " , [SS_SDieselFuelConsumption3] = " + (unit.SS_SDieselFuelConsumption3==null?"''":"'" + unit.SS_SDieselFuelConsumption3.Replace ("'","''") + "'")
					+ " , [SS_SDieselFuelConsumption4] = " + (unit.SS_SDieselFuelConsumption4==null?"''":"'" + unit.SS_SDieselFuelConsumption4.Replace ("'","''") + "'")
					+ " , [Slave_SecondChiefSign] = " + (unit.Slave_SecondChiefSign==null?"''":"'" + unit.Slave_SecondChiefSign.Replace ("'","''") + "'")
                    + " , [Slave_SecondChiefSignDate] = " + dbOperation.DbToDate(unit.Slave_SecondChiefSignDate)
					+ " , [Slave_ChiefSign] = " + (unit.Slave_ChiefSign==null?"''":"'" + unit.Slave_ChiefSign.Replace ("'","''") + "'")
                    + " , [Slave_ChiefSignDate] = " + dbOperation.DbToDate(unit.Slave_ChiefSignDate)
					+ " , [Slave_DirectorSign] = " + (unit.Slave_DirectorSign==null?"''":"'" + unit.Slave_DirectorSign.Replace ("'","''") + "'")
                    + " , [Slave_DirectorSignDate] = " + dbOperation.DbToDate(unit.Slave_DirectorSignDate)
					+ " where upper(Report_ShipSlave_Id) = '" + unit.Report_ShipSlave_Id.ToUpper() + "'"; 
			}
			else
			{
				unit.Report_ShipSlave_Id = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_REPROT_SHIPSLAVE] ("
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
					+ " " + (unit.Report_ShipSlave_Id==null?"''":"'" + unit.Report_ShipSlave_Id.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.File_ID)?"null":"'" + unit.File_ID.Replace ("'","''") + "'")
					+ " , " + (unit.Voyage==null?"''":"'" + unit.Voyage.Replace ("'","''") + "'")
					+ " ," + dbOperation.DbToDate(unit.TableWritedDate)
					+ " ," + dbOperation.DbToDate(unit.Slave_ParaAbstractedDate)
					+ " ," + dbOperation.DbToDate(unit.Slave_RecordDate)
					+ " , " + (string.IsNullOrEmpty(unit.Slave_EditID)?"null":"'" + unit.Slave_EditID.Replace ("'","''") + "'")
					+ " , " + (unit.Slave_SmokeHignNO==null?"''":"'" + unit.Slave_SmokeHignNO.Replace ("'","''") + "'")
					+ " , " + (unit.Slave_SmokeHignTem==null?"''":"'" + unit.Slave_SmokeHignTem.Replace ("'","''") + "'")
					+ " , " + (unit.Slave_SmokeLowNO==null?"''":"'" + unit.Slave_SmokeLowNO.Replace ("'","''") + "'")
					+ " , " + (unit.Slave_SmokeLowTem==null?"''":"'" + unit.Slave_SmokeLowTem.Replace ("'","''") + "'")
					+ " , " + (unit.Slave_CoolSystemInTem==null?"''":"'" + unit.Slave_CoolSystemInTem.Replace ("'","''") + "'")
					+ " , " + (unit.Slave_CoolSystemOutTem==null?"''":"'" + unit.Slave_CoolSystemOutTem.Replace ("'","''") + "'")
					+ " , " + (unit.Slave_OilinTem==null?"''":"'" + unit.Slave_OilinTem.Replace ("'","''") + "'")
					+ " , " + (unit.Slave_OilOutTem==null?"''":"'" + unit.Slave_OilOutTem.Replace ("'","''") + "'")
					+ " , " + (unit.Slave_FuelInTem==null?"''":"'" + unit.Slave_FuelInTem.Replace ("'","''") + "'")
					+ " , " + (unit.Slave_PressureAirTem==null?"''":"'" + unit.Slave_PressureAirTem.Replace ("'","''") + "'")
					+ " , " + (unit.Slave_CoolWaterHignMPa==null?"''":"'" + unit.Slave_CoolWaterHignMPa.Replace ("'","''") + "'")
					+ " , " + (unit.Slave_CoolWaterLowMPa==null?"''":"'" + unit.Slave_CoolWaterLowMPa.Replace ("'","''") + "'")
					+ " , " + (unit.Slave_OilInMpa==null?"''":"'" + unit.Slave_OilInMpa.Replace ("'","''") + "'")
					+ " , " + (unit.Slave_FuelInMpa==null?"''":"'" + unit.Slave_FuelInMpa.Replace ("'","''") + "'")
					+ " , " + (unit.Slave_PressureAirMPa==null?"''":"'" + unit.Slave_PressureAirMPa.Replace ("'","''") + "'")
					+ " , " + (unit.Slave_GeneratorVoltage==null?"''":"'" + unit.Slave_GeneratorVoltage.Replace ("'","''") + "'")
					+ " , " + (unit.Slave_GeneratorCurrent==null?"''":"'" + unit.Slave_GeneratorCurrent.Replace ("'","''") + "'")
					+ " , " + (unit.Slavae_GeneratorKW==null?"''":"'" + unit.Slavae_GeneratorKW.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselNoOne==null?"''":"'" + unit.SS_DieselNoOne.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselNoTwo==null?"''":"'" + unit.SS_DieselNoTwo.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselNoOnePressureNO1==null?"''":"'" + unit.SS_DieselNoOnePressureNO1.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselNoOnePressureNO2==null?"''":"'" + unit.SS_DieselNoOnePressureNO2.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselNoOnePressureNO3==null?"''":"'" + unit.SS_DieselNoOnePressureNO3.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselNoOnePressureNO4==null?"''":"'" + unit.SS_DieselNoOnePressureNO4.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselNoOnePressureNO5==null?"''":"'" + unit.SS_DieselNoOnePressureNO5.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselNoOnePressureNO6==null?"''":"'" + unit.SS_DieselNoOnePressureNO6.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselNoOnePressureNO7==null?"''":"'" + unit.SS_DieselNoOnePressureNO7.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselNoOnePressureNO8==null?"''":"'" + unit.SS_DieselNoOnePressureNO8.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselNoOneTemNO1==null?"''":"'" + unit.SS_DieselNoOneTemNO1.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselNoOneTemNO2==null?"''":"'" + unit.SS_DieselNoOneTemNO2.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselNoOneTemNO3==null?"''":"'" + unit.SS_DieselNoOneTemNO3.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselNoOneTemNO4==null?"''":"'" + unit.SS_DieselNoOneTemNO4.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselNoOneTemNO5==null?"''":"'" + unit.SS_DieselNoOneTemNO5.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselNoOneTemNO6==null?"''":"'" + unit.SS_DieselNoOneTemNO6.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselNoOneTemNO7==null?"''":"'" + unit.SS_DieselNoOneTemNO7.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselNoOneTemNO8==null?"''":"'" + unit.SS_DieselNoOneTemNO8.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselNoTwoPressureNO1==null?"''":"'" + unit.SS_DieselNoTwoPressureNO1.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselNoTwoPressureNO2==null?"''":"'" + unit.SS_DieselNoTwoPressureNO2.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselNoTwoPressureNO3==null?"''":"'" + unit.SS_DieselNoTwoPressureNO3.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselNoTwoPressureNO4==null?"''":"'" + unit.SS_DieselNoTwoPressureNO4.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselNoTwoPressureNO5==null?"''":"'" + unit.SS_DieselNoTwoPressureNO5.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselNoTwoPressureNO6==null?"''":"'" + unit.SS_DieselNoTwoPressureNO6.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselNoTwoPressureNO7==null?"''":"'" + unit.SS_DieselNoTwoPressureNO7.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselNoTwoPressureNO8==null?"''":"'" + unit.SS_DieselNoTwoPressureNO8.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselNoTwoTemNO1==null?"''":"'" + unit.SS_DieselNoTwoTemNO1.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselNoTwoTemNO2==null?"''":"'" + unit.SS_DieselNoTwoTemNO2.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselNoTwoTemNO3==null?"''":"'" + unit.SS_DieselNoTwoTemNO3.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselNoTwoTemNO4==null?"''":"'" + unit.SS_DieselNoTwoTemNO4.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselNoTwoTemNO5==null?"''":"'" + unit.SS_DieselNoTwoTemNO5.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselNoTwoTemNO6==null?"''":"'" + unit.SS_DieselNoTwoTemNO6.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselNoTwoTemNO7==null?"''":"'" + unit.SS_DieselNoTwoTemNO7.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselNoTwoTemNO8==null?"''":"'" + unit.SS_DieselNoTwoTemNO8.Replace ("'","''") + "'")
					+ " , " + (unit.SS_DieselFuelSpecifation==null?"''":"'" + unit.SS_DieselFuelSpecifation.Replace ("'","''") + "'")
					+ " , " + (unit.SS_SDieselFuelConsumption1==null?"''":"'" + unit.SS_SDieselFuelConsumption1.Replace ("'","''") + "'")
					+ " , " + (unit.SS_SDieselFuelConsumption2==null?"''":"'" + unit.SS_SDieselFuelConsumption2.Replace ("'","''") + "'")
					+ " , " + (unit.SS_SDieselFuelConsumption3==null?"''":"'" + unit.SS_SDieselFuelConsumption3.Replace ("'","''") + "'")
					+ " , " + (unit.SS_SDieselFuelConsumption4==null?"''":"'" + unit.SS_SDieselFuelConsumption4.Replace ("'","''") + "'")
					+ " , " + (unit.Slave_SecondChiefSign==null?"''":"'" + unit.Slave_SecondChiefSign.Replace ("'","''") + "'")
					+ " ," + dbOperation.DbToDate(unit.Slave_SecondChiefSignDate)
					+ " , " + (unit.Slave_ChiefSign==null?"''":"'" + unit.Slave_ChiefSign.Replace ("'","''") + "'")
					+ " ," + dbOperation.DbToDate(unit.Slave_ChiefSignDate)
					+ " , " + (unit.Slave_DirectorSign==null?"''":"'" + unit.Slave_DirectorSign.Replace ("'","''") + "'")
					+ " ," + dbOperation.DbToDate(unit.Slave_DirectorSignDate)
					+ ")";
			}

			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_REPROT_SHIPSLAVE中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_REPROT_SHIPSLAVE对象</param>
		internal bool deleteUnit(ReportShipSlave unit,out string err)
		{
			return deleteUnit(unit.Report_ShipSlave_Id,out err);
		}
		
		/// <summary>
		/// 删除数据表T_REPROT_SHIPSLAVE中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_REPROT_SHIPSLAVE.report_ShipSlave_Id主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_REPROT_SHIPSLAVE where "
				+ " upper(T_REPROT_SHIPSLAVE.Report_ShipSlave_Id)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_REPROT_SHIPSLAVE 所有数据信息.
		/// </summary>
		/// <returns>T_REPROT_SHIPSLAVE DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql = "select	"
				+ "Report_ShipSlave_Id"
				+ ",SHIP_ID"
				+ ",File_ID"
				+ ",Voyage"
				+ ",TableWritedDate"
				+ ",Slave_ParaAbstractedDate"
				+ ",Slave_RecordDate"
				+ ",Slave_EditID"
				+ ",Slave_SmokeHignNO"
				+ ",Slave_SmokeHignTem"
				+ ",Slave_SmokeLowNO"
				+ ",Slave_SmokeLowTem"
				+ ",Slave_CoolSystemInTem"
				+ ",Slave_CoolSystemOutTem"
				+ ",Slave_OilinTem"
				+ ",Slave_OilOutTem"
				+ ",Slave_FuelInTem"
				+ ",Slave_PressureAirTem"
				+ ",Slave_CoolWaterHignMPa"
				+ ",Slave_CoolWaterLowMPa"
				+ ",Slave_OilInMpa"
				+ ",Slave_FuelInMpa"
				+ ",Slave_PressureAirMPa"
				+ ",Slave_GeneratorVoltage"
				+ ",Slave_GeneratorCurrent"
				+ ",Slavae_GeneratorKW"
				+ ",SS_DieselNoOne"
				+ ",SS_DieselNoTwo"
				+ ",SS_DieselNoOnePressureNO1"
				+ ",SS_DieselNoOnePressureNO2"
				+ ",SS_DieselNoOnePressureNO3"
				+ ",SS_DieselNoOnePressureNO4"
				+ ",SS_DieselNoOnePressureNO5"
				+ ",SS_DieselNoOnePressureNO6"
				+ ",SS_DieselNoOnePressureNO7"
				+ ",SS_DieselNoOnePressureNO8"
				+ ",SS_DieselNoOneTemNO1"
				+ ",SS_DieselNoOneTemNO2"
				+ ",SS_DieselNoOneTemNO3"
				+ ",SS_DieselNoOneTemNO4"
				+ ",SS_DieselNoOneTemNO5"
				+ ",SS_DieselNoOneTemNO6"
				+ ",SS_DieselNoOneTemNO7"
				+ ",SS_DieselNoOneTemNO8"
				+ ",SS_DieselNoTwoPressureNO1"
				+ ",SS_DieselNoTwoPressureNO2"
				+ ",SS_DieselNoTwoPressureNO3"
				+ ",SS_DieselNoTwoPressureNO4"
				+ ",SS_DieselNoTwoPressureNO5"
				+ ",SS_DieselNoTwoPressureNO6"
				+ ",SS_DieselNoTwoPressureNO7"
				+ ",SS_DieselNoTwoPressureNO8"
				+ ",SS_DieselNoTwoTemNO1"
				+ ",SS_DieselNoTwoTemNO2"
				+ ",SS_DieselNoTwoTemNO3"
				+ ",SS_DieselNoTwoTemNO4"
				+ ",SS_DieselNoTwoTemNO5"
				+ ",SS_DieselNoTwoTemNO6"
				+ ",SS_DieselNoTwoTemNO7"
				+ ",SS_DieselNoTwoTemNO8"
				+ ",SS_DieselFuelSpecifation"
				+ ",SS_SDieselFuelConsumption1"
				+ ",SS_SDieselFuelConsumption2"
				+ ",SS_SDieselFuelConsumption3"
				+ ",SS_SDieselFuelConsumption4"
				+ ",Slave_SecondChiefSign"
				+ ",Slave_SecondChiefSignDate"
				+ ",Slave_ChiefSign"
				+ ",Slave_ChiefSignDate"
				+ ",Slave_DirectorSign"
				+ ",Slave_DirectorSignDate"
				+ "  from T_REPROT_SHIPSLAVE ";
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
		/// 根据一个主键ID,得到 T_REPROT_SHIPSLAVE 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>ReportShipSlave DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql = "select "
				+ "Report_ShipSlave_Id"
				+ ",SHIP_ID"
				+ ",File_ID"
				+ ",Voyage"
				+ ",TableWritedDate"
				+ ",Slave_ParaAbstractedDate"
				+ ",Slave_RecordDate"
				+ ",Slave_EditID"
				+ ",Slave_SmokeHignNO"
				+ ",Slave_SmokeHignTem"
				+ ",Slave_SmokeLowNO"
				+ ",Slave_SmokeLowTem"
				+ ",Slave_CoolSystemInTem"
				+ ",Slave_CoolSystemOutTem"
				+ ",Slave_OilinTem"
				+ ",Slave_OilOutTem"
				+ ",Slave_FuelInTem"
				+ ",Slave_PressureAirTem"
				+ ",Slave_CoolWaterHignMPa"
				+ ",Slave_CoolWaterLowMPa"
				+ ",Slave_OilInMpa"
				+ ",Slave_FuelInMpa"
				+ ",Slave_PressureAirMPa"
				+ ",Slave_GeneratorVoltage"
				+ ",Slave_GeneratorCurrent"
				+ ",Slavae_GeneratorKW"
				+ ",SS_DieselNoOne"
				+ ",SS_DieselNoTwo"
				+ ",SS_DieselNoOnePressureNO1"
				+ ",SS_DieselNoOnePressureNO2"
				+ ",SS_DieselNoOnePressureNO3"
				+ ",SS_DieselNoOnePressureNO4"
				+ ",SS_DieselNoOnePressureNO5"
				+ ",SS_DieselNoOnePressureNO6"
				+ ",SS_DieselNoOnePressureNO7"
				+ ",SS_DieselNoOnePressureNO8"
				+ ",SS_DieselNoOneTemNO1"
				+ ",SS_DieselNoOneTemNO2"
				+ ",SS_DieselNoOneTemNO3"
				+ ",SS_DieselNoOneTemNO4"
				+ ",SS_DieselNoOneTemNO5"
				+ ",SS_DieselNoOneTemNO6"
				+ ",SS_DieselNoOneTemNO7"
				+ ",SS_DieselNoOneTemNO8"
				+ ",SS_DieselNoTwoPressureNO1"
				+ ",SS_DieselNoTwoPressureNO2"
				+ ",SS_DieselNoTwoPressureNO3"
				+ ",SS_DieselNoTwoPressureNO4"
				+ ",SS_DieselNoTwoPressureNO5"
				+ ",SS_DieselNoTwoPressureNO6"
				+ ",SS_DieselNoTwoPressureNO7"
				+ ",SS_DieselNoTwoPressureNO8"
				+ ",SS_DieselNoTwoTemNO1"
				+ ",SS_DieselNoTwoTemNO2"
				+ ",SS_DieselNoTwoTemNO3"
				+ ",SS_DieselNoTwoTemNO4"
				+ ",SS_DieselNoTwoTemNO5"
				+ ",SS_DieselNoTwoTemNO6"
				+ ",SS_DieselNoTwoTemNO7"
				+ ",SS_DieselNoTwoTemNO8"
				+ ",SS_DieselFuelSpecifation"
				+ ",SS_SDieselFuelConsumption1"
				+ ",SS_SDieselFuelConsumption2"
				+ ",SS_SDieselFuelConsumption3"
				+ ",SS_SDieselFuelConsumption4"
				+ ",Slave_SecondChiefSign"
				+ ",Slave_SecondChiefSignDate"
				+ ",Slave_ChiefSign"
				+ ",Slave_ChiefSignDate"
				+ ",Slave_DirectorSign"
				+ ",Slave_DirectorSignDate"
				+ " from T_REPROT_SHIPSLAVE "
				+ " where upper(Report_ShipSlave_Id)='" + Id.ToUpper()+"'";
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
		/// 根据reportshipslave 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>reportshipslave 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
		public ReportShipSlave getObject(DataRow dr)
		{
			ReportShipSlave unit=new ReportShipSlave();
			if (null==dr)
			{
				unit.IsWrong = true;
				unit.WhyWrong = "从数据库获取信息时出错,未成功构造ReportShipSlave类对象!";
				return unit;
			}
			if (DBNull.Value != dr["Report_ShipSlave_Id"])	
			    unit.Report_ShipSlave_Id=dr["Report_ShipSlave_Id"].ToString();
			if (DBNull.Value != dr["SHIP_ID"])	
			    unit.SHIP_ID=dr["SHIP_ID"].ToString();
			if (DBNull.Value != dr["File_ID"])	
			    unit.File_ID=dr["File_ID"].ToString();
			if (DBNull.Value != dr["Voyage"])	
			    unit.Voyage=dr["Voyage"].ToString();
			if (DBNull.Value != dr["TableWritedDate"])	
                unit.TableWritedDate=(DateTime)dr["TableWritedDate"];
			if (DBNull.Value != dr["Slave_ParaAbstractedDate"])	
                unit.Slave_ParaAbstractedDate=(DateTime)dr["Slave_ParaAbstractedDate"];
			if (DBNull.Value != dr["Slave_RecordDate"])	
                unit.Slave_RecordDate=(DateTime)dr["Slave_RecordDate"];
			if (DBNull.Value != dr["Slave_EditID"])	
			    unit.Slave_EditID=dr["Slave_EditID"].ToString();
			if (DBNull.Value != dr["Slave_SmokeHignNO"])	
			    unit.Slave_SmokeHignNO=dr["Slave_SmokeHignNO"].ToString();
			if (DBNull.Value != dr["Slave_SmokeHignTem"])	
			    unit.Slave_SmokeHignTem=dr["Slave_SmokeHignTem"].ToString();
			if (DBNull.Value != dr["Slave_SmokeLowNO"])	
			    unit.Slave_SmokeLowNO=dr["Slave_SmokeLowNO"].ToString();
			if (DBNull.Value != dr["Slave_SmokeLowTem"])	
			    unit.Slave_SmokeLowTem=dr["Slave_SmokeLowTem"].ToString();
			if (DBNull.Value != dr["Slave_CoolSystemInTem"])	
			    unit.Slave_CoolSystemInTem=dr["Slave_CoolSystemInTem"].ToString();
			if (DBNull.Value != dr["Slave_CoolSystemOutTem"])	
			    unit.Slave_CoolSystemOutTem=dr["Slave_CoolSystemOutTem"].ToString();
			if (DBNull.Value != dr["Slave_OilinTem"])	
			    unit.Slave_OilinTem=dr["Slave_OilinTem"].ToString();
			if (DBNull.Value != dr["Slave_OilOutTem"])	
			    unit.Slave_OilOutTem=dr["Slave_OilOutTem"].ToString();
			if (DBNull.Value != dr["Slave_FuelInTem"])	
			    unit.Slave_FuelInTem=dr["Slave_FuelInTem"].ToString();
			if (DBNull.Value != dr["Slave_PressureAirTem"])	
			    unit.Slave_PressureAirTem=dr["Slave_PressureAirTem"].ToString();
			if (DBNull.Value != dr["Slave_CoolWaterHignMPa"])	
			    unit.Slave_CoolWaterHignMPa=dr["Slave_CoolWaterHignMPa"].ToString();
			if (DBNull.Value != dr["Slave_CoolWaterLowMPa"])	
			    unit.Slave_CoolWaterLowMPa=dr["Slave_CoolWaterLowMPa"].ToString();
			if (DBNull.Value != dr["Slave_OilInMpa"])	
			    unit.Slave_OilInMpa=dr["Slave_OilInMpa"].ToString();
			if (DBNull.Value != dr["Slave_FuelInMpa"])	
			    unit.Slave_FuelInMpa=dr["Slave_FuelInMpa"].ToString();
			if (DBNull.Value != dr["Slave_PressureAirMPa"])	
			    unit.Slave_PressureAirMPa=dr["Slave_PressureAirMPa"].ToString();
			if (DBNull.Value != dr["Slave_GeneratorVoltage"])	
			    unit.Slave_GeneratorVoltage=dr["Slave_GeneratorVoltage"].ToString();
			if (DBNull.Value != dr["Slave_GeneratorCurrent"])	
			    unit.Slave_GeneratorCurrent=dr["Slave_GeneratorCurrent"].ToString();
			if (DBNull.Value != dr["Slavae_GeneratorKW"])	
			    unit.Slavae_GeneratorKW=dr["Slavae_GeneratorKW"].ToString();
			if (DBNull.Value != dr["SS_DieselNoOne"])	
			    unit.SS_DieselNoOne=dr["SS_DieselNoOne"].ToString();
			if (DBNull.Value != dr["SS_DieselNoTwo"])	
			    unit.SS_DieselNoTwo=dr["SS_DieselNoTwo"].ToString();
			if (DBNull.Value != dr["SS_DieselNoOnePressureNO1"])	
			    unit.SS_DieselNoOnePressureNO1=dr["SS_DieselNoOnePressureNO1"].ToString();
			if (DBNull.Value != dr["SS_DieselNoOnePressureNO2"])	
			    unit.SS_DieselNoOnePressureNO2=dr["SS_DieselNoOnePressureNO2"].ToString();
			if (DBNull.Value != dr["SS_DieselNoOnePressureNO3"])	
			    unit.SS_DieselNoOnePressureNO3=dr["SS_DieselNoOnePressureNO3"].ToString();
			if (DBNull.Value != dr["SS_DieselNoOnePressureNO4"])	
			    unit.SS_DieselNoOnePressureNO4=dr["SS_DieselNoOnePressureNO4"].ToString();
			if (DBNull.Value != dr["SS_DieselNoOnePressureNO5"])	
			    unit.SS_DieselNoOnePressureNO5=dr["SS_DieselNoOnePressureNO5"].ToString();
			if (DBNull.Value != dr["SS_DieselNoOnePressureNO6"])	
			    unit.SS_DieselNoOnePressureNO6=dr["SS_DieselNoOnePressureNO6"].ToString();
			if (DBNull.Value != dr["SS_DieselNoOnePressureNO7"])	
			    unit.SS_DieselNoOnePressureNO7=dr["SS_DieselNoOnePressureNO7"].ToString();
			if (DBNull.Value != dr["SS_DieselNoOnePressureNO8"])	
			    unit.SS_DieselNoOnePressureNO8=dr["SS_DieselNoOnePressureNO8"].ToString();
			if (DBNull.Value != dr["SS_DieselNoOneTemNO1"])	
			    unit.SS_DieselNoOneTemNO1=dr["SS_DieselNoOneTemNO1"].ToString();
			if (DBNull.Value != dr["SS_DieselNoOneTemNO2"])	
			    unit.SS_DieselNoOneTemNO2=dr["SS_DieselNoOneTemNO2"].ToString();
			if (DBNull.Value != dr["SS_DieselNoOneTemNO3"])	
			    unit.SS_DieselNoOneTemNO3=dr["SS_DieselNoOneTemNO3"].ToString();
			if (DBNull.Value != dr["SS_DieselNoOneTemNO4"])	
			    unit.SS_DieselNoOneTemNO4=dr["SS_DieselNoOneTemNO4"].ToString();
			if (DBNull.Value != dr["SS_DieselNoOneTemNO5"])	
			    unit.SS_DieselNoOneTemNO5=dr["SS_DieselNoOneTemNO5"].ToString();
			if (DBNull.Value != dr["SS_DieselNoOneTemNO6"])	
			    unit.SS_DieselNoOneTemNO6=dr["SS_DieselNoOneTemNO6"].ToString();
			if (DBNull.Value != dr["SS_DieselNoOneTemNO7"])	
			    unit.SS_DieselNoOneTemNO7=dr["SS_DieselNoOneTemNO7"].ToString();
			if (DBNull.Value != dr["SS_DieselNoOneTemNO8"])	
			    unit.SS_DieselNoOneTemNO8=dr["SS_DieselNoOneTemNO8"].ToString();
			if (DBNull.Value != dr["SS_DieselNoTwoPressureNO1"])	
			    unit.SS_DieselNoTwoPressureNO1=dr["SS_DieselNoTwoPressureNO1"].ToString();
			if (DBNull.Value != dr["SS_DieselNoTwoPressureNO2"])	
			    unit.SS_DieselNoTwoPressureNO2=dr["SS_DieselNoTwoPressureNO2"].ToString();
			if (DBNull.Value != dr["SS_DieselNoTwoPressureNO3"])	
			    unit.SS_DieselNoTwoPressureNO3=dr["SS_DieselNoTwoPressureNO3"].ToString();
			if (DBNull.Value != dr["SS_DieselNoTwoPressureNO4"])	
			    unit.SS_DieselNoTwoPressureNO4=dr["SS_DieselNoTwoPressureNO4"].ToString();
			if (DBNull.Value != dr["SS_DieselNoTwoPressureNO5"])	
			    unit.SS_DieselNoTwoPressureNO5=dr["SS_DieselNoTwoPressureNO5"].ToString();
			if (DBNull.Value != dr["SS_DieselNoTwoPressureNO6"])	
			    unit.SS_DieselNoTwoPressureNO6=dr["SS_DieselNoTwoPressureNO6"].ToString();
			if (DBNull.Value != dr["SS_DieselNoTwoPressureNO7"])	
			    unit.SS_DieselNoTwoPressureNO7=dr["SS_DieselNoTwoPressureNO7"].ToString();
			if (DBNull.Value != dr["SS_DieselNoTwoPressureNO8"])	
			    unit.SS_DieselNoTwoPressureNO8=dr["SS_DieselNoTwoPressureNO8"].ToString();
			if (DBNull.Value != dr["SS_DieselNoTwoTemNO1"])	
			    unit.SS_DieselNoTwoTemNO1=dr["SS_DieselNoTwoTemNO1"].ToString();
			if (DBNull.Value != dr["SS_DieselNoTwoTemNO2"])	
			    unit.SS_DieselNoTwoTemNO2=dr["SS_DieselNoTwoTemNO2"].ToString();
			if (DBNull.Value != dr["SS_DieselNoTwoTemNO3"])	
			    unit.SS_DieselNoTwoTemNO3=dr["SS_DieselNoTwoTemNO3"].ToString();
			if (DBNull.Value != dr["SS_DieselNoTwoTemNO4"])	
			    unit.SS_DieselNoTwoTemNO4=dr["SS_DieselNoTwoTemNO4"].ToString();
			if (DBNull.Value != dr["SS_DieselNoTwoTemNO5"])	
			    unit.SS_DieselNoTwoTemNO5=dr["SS_DieselNoTwoTemNO5"].ToString();
			if (DBNull.Value != dr["SS_DieselNoTwoTemNO6"])	
			    unit.SS_DieselNoTwoTemNO6=dr["SS_DieselNoTwoTemNO6"].ToString();
			if (DBNull.Value != dr["SS_DieselNoTwoTemNO7"])	
			    unit.SS_DieselNoTwoTemNO7=dr["SS_DieselNoTwoTemNO7"].ToString();
			if (DBNull.Value != dr["SS_DieselNoTwoTemNO8"])	
			    unit.SS_DieselNoTwoTemNO8=dr["SS_DieselNoTwoTemNO8"].ToString();
			if (DBNull.Value != dr["SS_DieselFuelSpecifation"])	
			    unit.SS_DieselFuelSpecifation=dr["SS_DieselFuelSpecifation"].ToString();
			if (DBNull.Value != dr["SS_SDieselFuelConsumption1"])	
			    unit.SS_SDieselFuelConsumption1=dr["SS_SDieselFuelConsumption1"].ToString();
			if (DBNull.Value != dr["SS_SDieselFuelConsumption2"])	
			    unit.SS_SDieselFuelConsumption2=dr["SS_SDieselFuelConsumption2"].ToString();
			if (DBNull.Value != dr["SS_SDieselFuelConsumption3"])	
			    unit.SS_SDieselFuelConsumption3=dr["SS_SDieselFuelConsumption3"].ToString();
			if (DBNull.Value != dr["SS_SDieselFuelConsumption4"])	
			    unit.SS_SDieselFuelConsumption4=dr["SS_SDieselFuelConsumption4"].ToString();
			if (DBNull.Value != dr["Slave_SecondChiefSign"])	
			    unit.Slave_SecondChiefSign=dr["Slave_SecondChiefSign"].ToString();
			if (DBNull.Value != dr["Slave_SecondChiefSignDate"])	
                unit.Slave_SecondChiefSignDate=(DateTime)dr["Slave_SecondChiefSignDate"];
			if (DBNull.Value != dr["Slave_ChiefSign"])	
			    unit.Slave_ChiefSign=dr["Slave_ChiefSign"].ToString();
			if (DBNull.Value != dr["Slave_ChiefSignDate"])	
                unit.Slave_ChiefSignDate=(DateTime)dr["Slave_ChiefSignDate"];
			if (DBNull.Value != dr["Slave_DirectorSign"])	
			    unit.Slave_DirectorSign=dr["Slave_DirectorSign"].ToString();
			if (DBNull.Value != dr["Slave_DirectorSignDate"])	
                unit.Slave_DirectorSignDate=(DateTime)dr["Slave_DirectorSignDate"];
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个ReportShipSlave对象.
		/// </summary>
		/// <param name="report_ShipSlave_Id">report_ShipSlave_Id</param>
		/// <returns>ReportShipSlave对象</returns>
		public  ReportShipSlave getObject(string Id,out string err)
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
