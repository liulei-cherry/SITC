/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：ReportMajorEquipmentService.cs
 * 创 建 人：黄家龙
 * 创建时间：2011/9/1
 * 标    题：数据操作类
 * 功能描述：T_REPORT_MAJOREQUIPTIME数据操作类
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
    /// 数据层实例化接口类 dbo.T_REPORT_MAJOREQUIPTIMEService.cs
    /// </summary>
    public partial class ReportMajorEquipmentService
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static ReportMajorEquipmentService instance=new ReportMajorEquipmentService();
        public static ReportMajorEquipmentService Instance
        { 
            get
            {
                if(null==instance)
                {
                    ReportMajorEquipmentService.instance = new ReportMajorEquipmentService();
                }
                return ReportMajorEquipmentService.instance;
            }
        }
		private ReportMajorEquipmentService(){}
		#endregion
		
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();        
        string sql = ""; 
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">ReportMajorEquipment对象</param>
		/// <returns>插入的对象更新</returns>	
		internal bool saveUnit(ReportMajorEquipment unit,out string err)
        {
			if (unit.Report_MajorEquipTime_Id!=null && unit.Report_MajorEquipTime_Id.Length > 0) //edit
			{
				sql = "UPDATE [T_REPORT_MAJOREQUIPTIME] SET "
					+ " [Report_MajorEquipTime_Id] = " + (unit.Report_MajorEquipTime_Id==null?"''":"'" + unit.Report_MajorEquipTime_Id.Replace ("'","''") + "'")
					+ " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ " , [File_ID] = " + (string.IsNullOrEmpty(unit.File_ID)?"null":"'" + unit.File_ID.Replace ("'","''") + "'")
					+ " , [Voyage] = " + (unit.Voyage==null?"''":"'" + unit.Voyage.Replace ("'","''") + "'")
					+ " , [Cabin_HostTotal] = " + (unit.Cabin_HostTotal==null?"''":"'" + unit.Cabin_HostTotal.Replace ("'","''") + "'")
                    + " , [Cabin_StatisticsDate] = " + dbOperation.DbToDate(unit.Cabin_StatisticsDate)
					+ " , [Host_CylinderRenewalNO1] = " + (unit.Host_CylinderRenewalNO1==null?"''":"'" + unit.Host_CylinderRenewalNO1.Replace ("'","''") + "'")
					+ " , [Host_CylinderRenewalNO2] = " + (unit.Host_CylinderRenewalNO2==null?"''":"'" + unit.Host_CylinderRenewalNO2.Replace ("'","''") + "'")
					+ " , [Host_CylinderRenewalNO3] = " + (unit.Host_CylinderRenewalNO3==null?"''":"'" + unit.Host_CylinderRenewalNO3.Replace ("'","''") + "'")
					+ " , [Host_CylinderRenewalNO4] = " + (unit.Host_CylinderRenewalNO4==null?"''":"'" + unit.Host_CylinderRenewalNO4.Replace ("'","''") + "'")
					+ " , [Host_CylinderRenewalNO5] = " + (unit.Host_CylinderRenewalNO5==null?"''":"'" + unit.Host_CylinderRenewalNO5.Replace ("'","''") + "'")
					+ " , [Host_CylinderRenewalNO6] = " + (unit.Host_CylinderRenewalNO6==null?"''":"'" + unit.Host_CylinderRenewalNO6.Replace ("'","''") + "'")
					+ " , [Host_CylinderRenewalNO7] = " + (unit.Host_CylinderRenewalNO7==null?"''":"'" + unit.Host_CylinderRenewalNO7.Replace ("'","''") + "'")
					+ " , [Host_CylinderRenewalNO8] = " + (unit.Host_CylinderRenewalNO8==null?"''":"'" + unit.Host_CylinderRenewalNO8.Replace ("'","''") + "'")
					+ " , [Host_CylinderRenewalNO9] = " + (unit.Host_CylinderRenewalNO9==null?"''":"'" + unit.Host_CylinderRenewalNO9.Replace ("'","''") + "'")
					+ " , [Host_LiftingCylinderNO1] = " + (unit.Host_LiftingCylinderNO1==null?"''":"'" + unit.Host_LiftingCylinderNO1.Replace ("'","''") + "'")
					+ " , [Host_LiftingCylinderNO2] = " + (unit.Host_LiftingCylinderNO2==null?"''":"'" + unit.Host_LiftingCylinderNO2.Replace ("'","''") + "'")
					+ " , [Host_LiftingCylinderNO3] = " + (unit.Host_LiftingCylinderNO3==null?"''":"'" + unit.Host_LiftingCylinderNO3.Replace ("'","''") + "'")
					+ " , [Host_LiftingCylinderNO4] = " + (unit.Host_LiftingCylinderNO4==null?"''":"'" + unit.Host_LiftingCylinderNO4.Replace ("'","''") + "'")
					+ " , [Host_LiftingCylinderNO5] = " + (unit.Host_LiftingCylinderNO5==null?"''":"'" + unit.Host_LiftingCylinderNO5.Replace ("'","''") + "'")
					+ " , [Host_LiftingCylinderNO6] = " + (unit.Host_LiftingCylinderNO6==null?"''":"'" + unit.Host_LiftingCylinderNO6.Replace ("'","''") + "'")
					+ " , [Host_LiftingCylinderNO7] = " + (unit.Host_LiftingCylinderNO7==null?"''":"'" + unit.Host_LiftingCylinderNO7.Replace ("'","''") + "'")
					+ " , [Host_LiftingCylinderNO8] = " + (unit.Host_LiftingCylinderNO8==null?"''":"'" + unit.Host_LiftingCylinderNO8.Replace ("'","''") + "'")
					+ " , [Host_LiftingCylinderNO9] = " + (unit.Host_LiftingCylinderNO9==null?"''":"'" + unit.Host_LiftingCylinderNO9.Replace ("'","''") + "'")
					+ " , [Host_ExhaustExchangeNO1] = " + (unit.Host_ExhaustExchangeNO1==null?"''":"'" + unit.Host_ExhaustExchangeNO1.Replace ("'","''") + "'")
					+ " , [Host_ExhaustExchangeNO2] = " + (unit.Host_ExhaustExchangeNO2==null?"''":"'" + unit.Host_ExhaustExchangeNO2.Replace ("'","''") + "'")
					+ " , [Host_ExhaustExchangeNO3] = " + (unit.Host_ExhaustExchangeNO3==null?"''":"'" + unit.Host_ExhaustExchangeNO3.Replace ("'","''") + "'")
					+ " , [Host_ExhaustExchangeNO4] = " + (unit.Host_ExhaustExchangeNO4==null?"''":"'" + unit.Host_ExhaustExchangeNO4.Replace ("'","''") + "'")
					+ " , [Host_ExhaustExchangeNO5] = " + (unit.Host_ExhaustExchangeNO5==null?"''":"'" + unit.Host_ExhaustExchangeNO5.Replace ("'","''") + "'")
					+ " , [Host_ExhaustExchangeNO6] = " + (unit.Host_ExhaustExchangeNO6==null?"''":"'" + unit.Host_ExhaustExchangeNO6.Replace ("'","''") + "'")
					+ " , [Host_ExhaustExchangeNO7] = " + (unit.Host_ExhaustExchangeNO7==null?"''":"'" + unit.Host_ExhaustExchangeNO7.Replace ("'","''") + "'")
					+ " , [Host_ExhaustExchangeNO8] = " + (unit.Host_ExhaustExchangeNO8==null?"''":"'" + unit.Host_ExhaustExchangeNO8.Replace ("'","''") + "'")
					+ " , [Host_ExhaustExchangeNO9] = " + (unit.Host_ExhaustExchangeNO9==null?"''":"'" + unit.Host_ExhaustExchangeNO9.Replace ("'","''") + "'")
					+ " , [Host_OilHeadCheckNO1] = " + (unit.Host_OilHeadCheckNO1==null?"''":"'" + unit.Host_OilHeadCheckNO1.Replace ("'","''") + "'")
					+ " , [Host_OilHeadCheckNO2] = " + (unit.Host_OilHeadCheckNO2==null?"''":"'" + unit.Host_OilHeadCheckNO2.Replace ("'","''") + "'")
					+ " , [Host_OilHeadCheckNO3] = " + (unit.Host_OilHeadCheckNO3==null?"''":"'" + unit.Host_OilHeadCheckNO3.Replace ("'","''") + "'")
					+ " , [Host_OilHeadCheckNO4] = " + (unit.Host_OilHeadCheckNO4==null?"''":"'" + unit.Host_OilHeadCheckNO4.Replace ("'","''") + "'")
					+ " , [Host_OilHeadCheckNO5] = " + (unit.Host_OilHeadCheckNO5==null?"''":"'" + unit.Host_OilHeadCheckNO5.Replace ("'","''") + "'")
					+ " , [Host_OilHeadCheckNO6] = " + (unit.Host_OilHeadCheckNO6==null?"''":"'" + unit.Host_OilHeadCheckNO6.Replace ("'","''") + "'")
					+ " , [Host_OilHeadCheckNO7] = " + (unit.Host_OilHeadCheckNO7==null?"''":"'" + unit.Host_OilHeadCheckNO7.Replace ("'","''") + "'")
					+ " , [Host_OilHeadCheckNO8] = " + (unit.Host_OilHeadCheckNO8==null?"''":"'" + unit.Host_OilHeadCheckNO8.Replace ("'","''") + "'")
					+ " , [Host_OilHeadCheckNO9] = " + (unit.Host_OilHeadCheckNO9==null?"''":"'" + unit.Host_OilHeadCheckNO9.Replace ("'","''") + "'")
					+ " , [Host_CrossheadBearNO1] = " + (unit.Host_CrossheadBearNO1==null?"''":"'" + unit.Host_CrossheadBearNO1.Replace ("'","''") + "'")
					+ " , [Host_CrossheadBearNO2] = " + (unit.Host_CrossheadBearNO2==null?"''":"'" + unit.Host_CrossheadBearNO2.Replace ("'","''") + "'")
					+ " , [Host_CrossheadBearNO3] = " + (unit.Host_CrossheadBearNO3==null?"''":"'" + unit.Host_CrossheadBearNO3.Replace ("'","''") + "'")
					+ " , [Host_CrossheadBearNO4] = " + (unit.Host_CrossheadBearNO4==null?"''":"'" + unit.Host_CrossheadBearNO4.Replace ("'","''") + "'")
					+ " , [Host_CrossheadBearNO5] = " + (unit.Host_CrossheadBearNO5==null?"''":"'" + unit.Host_CrossheadBearNO5.Replace ("'","''") + "'")
					+ " , [Host_CrossheadBearNO6] = " + (unit.Host_CrossheadBearNO6==null?"''":"'" + unit.Host_CrossheadBearNO6.Replace ("'","''") + "'")
					+ " , [Host_CrossheadBearNO7] = " + (unit.Host_CrossheadBearNO7==null?"''":"'" + unit.Host_CrossheadBearNO7.Replace ("'","''") + "'")
					+ " , [Host_CrossheadBearNO8] = " + (unit.Host_CrossheadBearNO8==null?"''":"'" + unit.Host_CrossheadBearNO8.Replace ("'","''") + "'")
					+ " , [Host_CrossheadBearNO9] = " + (unit.Host_CrossheadBearNO9==null?"''":"'" + unit.Host_CrossheadBearNO9.Replace ("'","''") + "'")
					+ " , [Host_ConnectRodBearNO1] = " + (unit.Host_ConnectRodBearNO1==null?"''":"'" + unit.Host_ConnectRodBearNO1.Replace ("'","''") + "'")
					+ " , [Host_ConnectRodBearNO2] = " + (unit.Host_ConnectRodBearNO2==null?"''":"'" + unit.Host_ConnectRodBearNO2.Replace ("'","''") + "'")
					+ " , [Host_ConnectRodBearNO3] = " + (unit.Host_ConnectRodBearNO3==null?"''":"'" + unit.Host_ConnectRodBearNO3.Replace ("'","''") + "'")
					+ " , [Host_ConnectRodBearNO4] = " + (unit.Host_ConnectRodBearNO4==null?"''":"'" + unit.Host_ConnectRodBearNO4.Replace ("'","''") + "'")
					+ " , [Host_ConnectRodBearNO5] = " + (unit.Host_ConnectRodBearNO5==null?"''":"'" + unit.Host_ConnectRodBearNO5.Replace ("'","''") + "'")
					+ " , [Host_ConnectRodBearNO6] = " + (unit.Host_ConnectRodBearNO6==null?"''":"'" + unit.Host_ConnectRodBearNO6.Replace ("'","''") + "'")
					+ " , [Host_ConnectRodBearNO7] = " + (unit.Host_ConnectRodBearNO7==null?"''":"'" + unit.Host_ConnectRodBearNO7.Replace ("'","''") + "'")
					+ " , [Host_ConnectRodBearNO8] = " + (unit.Host_ConnectRodBearNO8==null?"''":"'" + unit.Host_ConnectRodBearNO8.Replace ("'","''") + "'")
					+ " , [Host_ConnectRodBearNO9] = " + (unit.Host_ConnectRodBearNO9==null?"''":"'" + unit.Host_ConnectRodBearNO9.Replace ("'","''") + "'")
					+ " , [Host_MajorBearNO1] = " + (unit.Host_MajorBearNO1==null?"''":"'" + unit.Host_MajorBearNO1.Replace ("'","''") + "'")
					+ " , [Host_MajorBearNO2] = " + (unit.Host_MajorBearNO2==null?"''":"'" + unit.Host_MajorBearNO2.Replace ("'","''") + "'")
					+ " , [Host_MajorBearNO3] = " + (unit.Host_MajorBearNO3==null?"''":"'" + unit.Host_MajorBearNO3.Replace ("'","''") + "'")
					+ " , [Host_MajorBearNO4] = " + (unit.Host_MajorBearNO4==null?"''":"'" + unit.Host_MajorBearNO4.Replace ("'","''") + "'")
					+ " , [Host_MajorBearNO5] = " + (unit.Host_MajorBearNO5==null?"''":"'" + unit.Host_MajorBearNO5.Replace ("'","''") + "'")
					+ " , [Host_MajorBearNO6] = " + (unit.Host_MajorBearNO6==null?"''":"'" + unit.Host_MajorBearNO6.Replace ("'","''") + "'")
					+ " , [Host_MajorBearNO7] = " + (unit.Host_MajorBearNO7==null?"''":"'" + unit.Host_MajorBearNO7.Replace ("'","''") + "'")
					+ " , [Host_MajorBearNO8] = " + (unit.Host_MajorBearNO8==null?"''":"'" + unit.Host_MajorBearNO8.Replace ("'","''") + "'")
					+ " , [Host_MajorBearNO9] = " + (unit.Host_MajorBearNO9==null?"''":"'" + unit.Host_MajorBearNO9.Replace ("'","''") + "'")
					+ " , [Host_HighPreesurePumpNO1] = " + (unit.Host_HighPreesurePumpNO1==null?"''":"'" + unit.Host_HighPreesurePumpNO1.Replace ("'","''") + "'")
					+ " , [Host_HighPreesurePumpNO2] = " + (unit.Host_HighPreesurePumpNO2==null?"''":"'" + unit.Host_HighPreesurePumpNO2.Replace ("'","''") + "'")
					+ " , [Host_HighPreesurePumpNO3] = " + (unit.Host_HighPreesurePumpNO3==null?"''":"'" + unit.Host_HighPreesurePumpNO3.Replace ("'","''") + "'")
					+ " , [Host_HighPreesurePumpNO4] = " + (unit.Host_HighPreesurePumpNO4==null?"''":"'" + unit.Host_HighPreesurePumpNO4.Replace ("'","''") + "'")
					+ " , [Host_HighPreesurePumpNO5] = " + (unit.Host_HighPreesurePumpNO5==null?"''":"'" + unit.Host_HighPreesurePumpNO5.Replace ("'","''") + "'")
					+ " , [Host_HighPreesurePumpNO6] = " + (unit.Host_HighPreesurePumpNO6==null?"''":"'" + unit.Host_HighPreesurePumpNO6.Replace ("'","''") + "'")
					+ " , [Host_HighPreesurePumpNO7] = " + (unit.Host_HighPreesurePumpNO7==null?"''":"'" + unit.Host_HighPreesurePumpNO7.Replace ("'","''") + "'")
					+ " , [Host_HighPreesurePumpNO8] = " + (unit.Host_HighPreesurePumpNO8==null?"''":"'" + unit.Host_HighPreesurePumpNO8.Replace ("'","''") + "'")
					+ " , [Host_HighPreesurePumpNO9] = " + (unit.Host_HighPreesurePumpNO9==null?"''":"'" + unit.Host_HighPreesurePumpNO9.Replace ("'","''") + "'")
					+ " , [Gas_DismantNO1] = " + (unit.Gas_DismantNO1==null?"''":"'" + unit.Gas_DismantNO1.Replace ("'","''") + "'")
					+ " , [Gas_DismantNO2] = " + (unit.Gas_DismantNO2==null?"''":"'" + unit.Gas_DismantNO2.Replace ("'","''") + "'")
					+ " , [Gas_MarblePanelNO1] = " + (unit.Gas_MarblePanelNO1==null?"''":"'" + unit.Gas_MarblePanelNO1.Replace ("'","''") + "'")
					+ " , [Gas_MarblePanelNO2] = " + (unit.Gas_MarblePanelNO2==null?"''":"'" + unit.Gas_MarblePanelNO2.Replace ("'","''") + "'")
					+ " , [Gas_AirCoolerNO1] = " + (unit.Gas_AirCoolerNO1==null?"''":"'" + unit.Gas_AirCoolerNO1.Replace ("'","''") + "'")
					+ " , [Gas_AirCoolerNO2] = " + (unit.Gas_AirCoolerNO2==null?"''":"'" + unit.Gas_AirCoolerNO2.Replace ("'","''") + "'")
					+ " , [Gas_STotalNO1] = " + (unit.Gas_STotalNO1==null?"''":"'" + unit.Gas_STotalNO1.Replace ("'","''") + "'")
					+ " , [Gas_STotalNO2] = " + (unit.Gas_STotalNO2==null?"''":"'" + unit.Gas_STotalNO2.Replace ("'","''") + "'")
					+ " , [Gas_STotalNO3] = " + (unit.Gas_STotalNO3==null?"''":"'" + unit.Gas_STotalNO3.Replace ("'","''") + "'")
					+ " , [Gas_SLiftingCylinderNO1] = " + (unit.Gas_SLiftingCylinderNO1==null?"''":"'" + unit.Gas_SLiftingCylinderNO1.Replace ("'","''") + "'")
					+ " , [Gas_SLiftingCylinderNO2] = " + (unit.Gas_SLiftingCylinderNO2==null?"''":"'" + unit.Gas_SLiftingCylinderNO2.Replace ("'","''") + "'")
					+ " , [Gas_SLiftingCylinderNO3] = " + (unit.Gas_SLiftingCylinderNO3==null?"''":"'" + unit.Gas_SLiftingCylinderNO3.Replace ("'","''") + "'")
					+ " , [Gas_SExhaustExchangeNO1] = " + (unit.Gas_SExhaustExchangeNO1==null?"''":"'" + unit.Gas_SExhaustExchangeNO1.Replace ("'","''") + "'")
					+ " , [Gas_SExhaustExchangeNO2] = " + (unit.Gas_SExhaustExchangeNO2==null?"''":"'" + unit.Gas_SExhaustExchangeNO2.Replace ("'","''") + "'")
					+ " , [Gas_SExhaustExchangeNO3] = " + (unit.Gas_SExhaustExchangeNO3==null?"''":"'" + unit.Gas_SExhaustExchangeNO3.Replace ("'","''") + "'")
					+ " , [Gas_SOilHeadNO1] = " + (unit.Gas_SOilHeadNO1==null?"''":"'" + unit.Gas_SOilHeadNO1.Replace ("'","''") + "'")
					+ " , [Gas_SOilHeadNO2] = " + (unit.Gas_SOilHeadNO2==null?"''":"'" + unit.Gas_SOilHeadNO2.Replace ("'","''") + "'")
					+ " , [Gas_SOilHeadNO3] = " + (unit.Gas_SOilHeadNO3==null?"''":"'" + unit.Gas_SOilHeadNO3.Replace ("'","''") + "'")
					+ " , [Gas_SMajorBearNO1] = " + (unit.Gas_SMajorBearNO1==null?"''":"'" + unit.Gas_SMajorBearNO1.Replace ("'","''") + "'")
					+ " , [Gas_SMajorBearNO2] = " + (unit.Gas_SMajorBearNO2==null?"''":"'" + unit.Gas_SMajorBearNO2.Replace ("'","''") + "'")
					+ " , [Gas_SMajorBearNO3] = " + (unit.Gas_SMajorBearNO3==null?"''":"'" + unit.Gas_SMajorBearNO3.Replace ("'","''") + "'")
					+ " , [Gas_STurbochargerNO1] = " + (unit.Gas_STurbochargerNO1==null?"''":"'" + unit.Gas_STurbochargerNO1.Replace ("'","''") + "'")
					+ " , [Gas_STurbochargerNO2] = " + (unit.Gas_STurbochargerNO2==null?"''":"'" + unit.Gas_STurbochargerNO2.Replace ("'","''") + "'")
					+ " , [Gas_STurbochargerNO3] = " + (unit.Gas_STurbochargerNO3==null?"''":"'" + unit.Gas_STurbochargerNO3.Replace ("'","''") + "'")
					+ " , [Gas_ACTotalNO1] = " + (unit.Gas_ACTotalNO1==null?"''":"'" + unit.Gas_ACTotalNO1.Replace ("'","''") + "'")
					+ " , [Gas_ACTotalNO2] = " + (unit.Gas_ACTotalNO2==null?"''":"'" + unit.Gas_ACTotalNO2.Replace ("'","''") + "'")
					+ " , [Gas_ACTotalNO3] = " + (unit.Gas_ACTotalNO3==null?"''":"'" + unit.Gas_ACTotalNO3.Replace ("'","''") + "'")
					+ " , [Gas_ACliftingCylinderNO1] = " + (unit.Gas_ACliftingCylinderNO1==null?"''":"'" + unit.Gas_ACliftingCylinderNO1.Replace ("'","''") + "'")
					+ " , [Gas_ACliftingCylinderNO2] = " + (unit.Gas_ACliftingCylinderNO2==null?"''":"'" + unit.Gas_ACliftingCylinderNO2.Replace ("'","''") + "'")
					+ " , [Gas_ACliftingCylinderNO3] = " + (unit.Gas_ACliftingCylinderNO3==null?"''":"'" + unit.Gas_ACliftingCylinderNO3.Replace ("'","''") + "'")
					+ " , [Gas_PPTotalNO1] = " + (unit.Gas_PPTotalNO1==null?"''":"'" + unit.Gas_PPTotalNO1.Replace ("'","''") + "'")
					+ " , [Gas_PPTotalNO2] = " + (unit.Gas_PPTotalNO2==null?"''":"'" + unit.Gas_PPTotalNO2.Replace ("'","''") + "'")
					+ " , [Gas_PPCheckNO1] = " + (unit.Gas_PPCheckNO1==null?"''":"'" + unit.Gas_PPCheckNO1.Replace ("'","''") + "'")
					+ " , [Gas_PPCheckNO2] = " + (unit.Gas_PPCheckNO2==null?"''":"'" + unit.Gas_PPCheckNO2.Replace ("'","''") + "'")
					+ " , [Gas_Remarks] = " + (unit.Gas_Remarks==null?"''":"'" + unit.Gas_Remarks.Replace ("'","''") + "'")
					+ " , [ChiefSign] = " + (unit.ChiefSign==null?"''":"'" + unit.ChiefSign.Replace ("'","''") + "'")
					+ " , [Pump_MainSeaTotalNO1] = " + (unit.Pump_MainSeaTotalNO1==null?"''":"'" + unit.Pump_MainSeaTotalNO1.Replace ("'","''") + "'")
					+ " , [Pump_MainSeaTotalNO2] = " + (unit.Pump_MainSeaTotalNO2==null?"''":"'" + unit.Pump_MainSeaTotalNO2.Replace ("'","''") + "'")
					+ " , [Pump_MainSeaDisintegrationNO1] = " + (unit.Pump_MainSeaDisintegrationNO1==null?"''":"'" + unit.Pump_MainSeaDisintegrationNO1.Replace ("'","''") + "'")
					+ " , [Pump_MainSeaDisintegrationNO2] = " + (unit.Pump_MainSeaDisintegrationNO2==null?"''":"'" + unit.Pump_MainSeaDisintegrationNO2.Replace ("'","''") + "'")
					+ " , [Pump_SecondSeaTotal] = " + (unit.Pump_SecondSeaTotal==null?"''":"'" + unit.Pump_SecondSeaTotal.Replace ("'","''") + "'")
					+ " , [Pump_SecondSeaDisintegration] = " + (unit.Pump_SecondSeaDisintegration==null?"''":"'" + unit.Pump_SecondSeaDisintegration.Replace ("'","''") + "'")
					+ " , [Pump_CylinderTotalNO1] = " + (unit.Pump_CylinderTotalNO1==null?"''":"'" + unit.Pump_CylinderTotalNO1.Replace ("'","''") + "'")
					+ " , [Pump_CylinderTotalNO2] = " + (unit.Pump_CylinderTotalNO2==null?"''":"'" + unit.Pump_CylinderTotalNO2.Replace ("'","''") + "'")
					+ " , [Pump_CylinderDisintegrationNO1] = " + (unit.Pump_CylinderDisintegrationNO1==null?"''":"'" + unit.Pump_CylinderDisintegrationNO1.Replace ("'","''") + "'")
					+ " , [Pump_CylinderDisintegrationNO2] = " + (unit.Pump_CylinderDisintegrationNO2==null?"''":"'" + unit.Pump_CylinderDisintegrationNO2.Replace ("'","''") + "'")
					+ " , [Pump_LowTemTotalNO1] = " + (unit.Pump_LowTemTotalNO1==null?"''":"'" + unit.Pump_LowTemTotalNO1.Replace ("'","''") + "'")
					+ " , [Pump_LowTemTotalNO2] = " + (unit.Pump_LowTemTotalNO2==null?"''":"'" + unit.Pump_LowTemTotalNO2.Replace ("'","''") + "'")
					+ " , [Pump_LowTemDisintegrationNO1] = " + (unit.Pump_LowTemDisintegrationNO1==null?"''":"'" + unit.Pump_LowTemDisintegrationNO1.Replace ("'","''") + "'")
					+ " , [Pump_LowTemDisintegrationNO2] = " + (unit.Pump_LowTemDisintegrationNO2==null?"''":"'" + unit.Pump_LowTemDisintegrationNO2.Replace ("'","''") + "'")
					+ " , [Pump_ParkLowTemTotal] = " + (unit.Pump_ParkLowTemTotal==null?"''":"'" + unit.Pump_ParkLowTemTotal.Replace ("'","''") + "'")
					+ " , [Pump_ParkLowTemDisintegration] = " + (unit.Pump_ParkLowTemDisintegration==null?"''":"'" + unit.Pump_ParkLowTemDisintegration.Replace ("'","''") + "'")
					+ " , [Pump_MainOilTotalNO1] = " + (unit.Pump_MainOilTotalNO1==null?"''":"'" + unit.Pump_MainOilTotalNO1.Replace ("'","''") + "'")
					+ " , [Pump_MainOilTotalNO2] = " + (unit.Pump_MainOilTotalNO2==null?"''":"'" + unit.Pump_MainOilTotalNO2.Replace ("'","''") + "'")
					+ " , [Pump_MainOilDisintegrationNO1] = " + (unit.Pump_MainOilDisintegrationNO1==null?"''":"'" + unit.Pump_MainOilDisintegrationNO1.Replace ("'","''") + "'")
					+ " , [Pump_MainOilDisintegrationNO2] = " + (unit.Pump_MainOilDisintegrationNO2==null?"''":"'" + unit.Pump_MainOilDisintegrationNO2.Replace ("'","''") + "'")
					+ " , [Pump_CamshaftOilTotalNO1] = " + (unit.Pump_CamshaftOilTotalNO1==null?"''":"'" + unit.Pump_CamshaftOilTotalNO1.Replace ("'","''") + "'")
					+ " , [Pump_CamshaftOilTotalNO2] = " + (unit.Pump_CamshaftOilTotalNO2==null?"''":"'" + unit.Pump_CamshaftOilTotalNO2.Replace ("'","''") + "'")
					+ " , [Pump_CamshaftOilDisintegrationNO1] = " + (unit.Pump_CamshaftOilDisintegrationNO1==null?"''":"'" + unit.Pump_CamshaftOilDisintegrationNO1.Replace ("'","''") + "'")
					+ " , [Pump_CamshaftOilDisintegrationNO2] = " + (unit.Pump_CamshaftOilDisintegrationNO2==null?"''":"'" + unit.Pump_CamshaftOilDisintegrationNO2.Replace ("'","''") + "'")
					+ " , [Pump_BoilerTotal] = " + (unit.Pump_BoilerTotal==null?"''":"'" + unit.Pump_BoilerTotal.Replace ("'","''") + "'")
					+ " , [Pump_BoilerDisintegration] = " + (unit.Pump_BoilerDisintegration==null?"''":"'" + unit.Pump_BoilerDisintegration.Replace ("'","''") + "'")
					+ " , [Pump_GeneralToatl] = " + (unit.Pump_GeneralToatl==null?"''":"'" + unit.Pump_GeneralToatl.Replace ("'","''") + "'")
					+ " , [Pump_GeneralDisintegration] = " + (unit.Pump_GeneralDisintegration==null?"''":"'" + unit.Pump_GeneralDisintegration.Replace ("'","''") + "'")
					+ " , [Pump_FireTotal] = " + (unit.Pump_FireTotal==null?"''":"'" + unit.Pump_FireTotal.Replace ("'","''") + "'")
					+ " , [Pump_FireDisintegration] = " + (unit.Pump_FireDisintegration==null?"''":"'" + unit.Pump_FireDisintegration.Replace ("'","''") + "'")
					+ " , [Pump_FuelCircleTotalNO1] = " + (unit.Pump_FuelCircleTotalNO1==null?"''":"'" + unit.Pump_FuelCircleTotalNO1.Replace ("'","''") + "'")
					+ " , [Pump_FuelCircleTotalNO2] = " + (unit.Pump_FuelCircleTotalNO2==null?"''":"'" + unit.Pump_FuelCircleTotalNO2.Replace ("'","''") + "'")
					+ " , [Pump_FuelCircleDisintegratinNO1] = " + (unit.Pump_FuelCircleDisintegratinNO1==null?"''":"'" + unit.Pump_FuelCircleDisintegratinNO1.Replace ("'","''") + "'")
					+ " , [Pump_FuelCircleDisintegratinNO2] = " + (unit.Pump_FuelCircleDisintegratinNO2==null?"''":"'" + unit.Pump_FuelCircleDisintegratinNO2.Replace ("'","''") + "'")
					+ " , [Pump_FuelPressureTotalNO1] = " + (unit.Pump_FuelPressureTotalNO1==null?"''":"'" + unit.Pump_FuelPressureTotalNO1.Replace ("'","''") + "'")
					+ " , [Pump_FuelPressureTotalNO2] = " + (unit.Pump_FuelPressureTotalNO2==null?"''":"'" + unit.Pump_FuelPressureTotalNO2.Replace ("'","''") + "'")
					+ " , [Pump_FuelPressureDisintegrationNO1] = " + (unit.Pump_FuelPressureDisintegrationNO1==null?"''":"'" + unit.Pump_FuelPressureDisintegrationNO1.Replace ("'","''") + "'")
					+ " , [Pump_FuelPressureDisintegrationNO2] = " + (unit.Pump_FuelPressureDisintegrationNO2==null?"''":"'" + unit.Pump_FuelPressureDisintegrationNO2.Replace ("'","''") + "'")
					+ " , [Pump_HeavyOilTotalNO1] = " + (unit.Pump_HeavyOilTotalNO1==null?"''":"'" + unit.Pump_HeavyOilTotalNO1.Replace ("'","''") + "'")
					+ " , [Pump_HeavyOilTotalNO2] = " + (unit.Pump_HeavyOilTotalNO2==null?"''":"'" + unit.Pump_HeavyOilTotalNO2.Replace ("'","''") + "'")
					+ " , [Pump_HeavyOilDisintegrationNO1] = " + (unit.Pump_HeavyOilDisintegrationNO1==null?"''":"'" + unit.Pump_HeavyOilDisintegrationNO1.Replace ("'","''") + "'")
					+ " , [Pump_HeavyOilDisintegrationNO2] = " + (unit.Pump_HeavyOilDisintegrationNO2==null?"''":"'" + unit.Pump_HeavyOilDisintegrationNO2.Replace ("'","''") + "'")
					+ " , [Pump_DieselFuelTotal] = " + (unit.Pump_DieselFuelTotal==null?"''":"'" + unit.Pump_DieselFuelTotal.Replace ("'","''") + "'")
					+ " , [Pump_DieselFuelDisintegration] = " + (unit.Pump_DieselFuelDisintegration==null?"''":"'" + unit.Pump_DieselFuelDisintegration.Replace ("'","''") + "'")
					+ " , [Pump_OilTotalNO1] = " + (unit.Pump_OilTotalNO1==null?"''":"'" + unit.Pump_OilTotalNO1.Replace ("'","''") + "'")
					+ " , [Pump_OilTotalNO2] = " + (unit.Pump_OilTotalNO2==null?"''":"'" + unit.Pump_OilTotalNO2.Replace ("'","''") + "'")
					+ " , [Pump_OilDisintegrationNO1] = " + (unit.Pump_OilDisintegrationNO1==null?"''":"'" + unit.Pump_OilDisintegrationNO1.Replace ("'","''") + "'")
					+ " , [Pump_OilDisintegrationNO2] = " + (unit.Pump_OilDisintegrationNO2==null?"''":"'" + unit.Pump_OilDisintegrationNO2.Replace ("'","''") + "'")
					+ " , [Pump_BallastTotalNO1] = " + (unit.Pump_BallastTotalNO1==null?"''":"'" + unit.Pump_BallastTotalNO1.Replace ("'","''") + "'")
					+ " , [Pump_BallastTotalNO2] = " + (unit.Pump_BallastTotalNO2==null?"''":"'" + unit.Pump_BallastTotalNO2.Replace ("'","''") + "'")
					+ " , [Pump_BallastDisintegrationNO1] = " + (unit.Pump_BallastDisintegrationNO1==null?"''":"'" + unit.Pump_BallastDisintegrationNO1.Replace ("'","''") + "'")
					+ " , [Pump_BallastDisintegrationNO2] = " + (unit.Pump_BallastDisintegrationNO2==null?"''":"'" + unit.Pump_BallastDisintegrationNO2.Replace ("'","''") + "'")
					+ " , [Pump_EmergencyTotal] = " + (unit.Pump_EmergencyTotal==null?"''":"'" + unit.Pump_EmergencyTotal.Replace ("'","''") + "'")
					+ " , [Pump_EmergencyDisintegration] = " + (unit.Pump_EmergencyDisintegration==null?"''":"'" + unit.Pump_EmergencyDisintegration.Replace ("'","''") + "'")
					+ " where upper(Report_MajorEquipTime_Id) = '" + unit.Report_MajorEquipTime_Id.ToUpper() + "'"; 
			}
			else
			{
				unit.Report_MajorEquipTime_Id = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_REPORT_MAJOREQUIPTIME] ("
					+ "[Report_MajorEquipTime_Id],"
					+ "[SHIP_ID],"
					+ "[File_ID],"
					+ "[Voyage],"
					+ "[Cabin_HostTotal],"
					+ "[Cabin_StatisticsDate],"
					+ "[Host_CylinderRenewalNO1],"
					+ "[Host_CylinderRenewalNO2],"
					+ "[Host_CylinderRenewalNO3],"
					+ "[Host_CylinderRenewalNO4],"
					+ "[Host_CylinderRenewalNO5],"
					+ "[Host_CylinderRenewalNO6],"
					+ "[Host_CylinderRenewalNO7],"
					+ "[Host_CylinderRenewalNO8],"
					+ "[Host_CylinderRenewalNO9],"
					+ "[Host_LiftingCylinderNO1],"
					+ "[Host_LiftingCylinderNO2],"
					+ "[Host_LiftingCylinderNO3],"
					+ "[Host_LiftingCylinderNO4],"
					+ "[Host_LiftingCylinderNO5],"
					+ "[Host_LiftingCylinderNO6],"
					+ "[Host_LiftingCylinderNO7],"
					+ "[Host_LiftingCylinderNO8],"
					+ "[Host_LiftingCylinderNO9],"
					+ "[Host_ExhaustExchangeNO1],"
					+ "[Host_ExhaustExchangeNO2],"
					+ "[Host_ExhaustExchangeNO3],"
					+ "[Host_ExhaustExchangeNO4],"
					+ "[Host_ExhaustExchangeNO5],"
					+ "[Host_ExhaustExchangeNO6],"
					+ "[Host_ExhaustExchangeNO7],"
					+ "[Host_ExhaustExchangeNO8],"
					+ "[Host_ExhaustExchangeNO9],"
					+ "[Host_OilHeadCheckNO1],"
					+ "[Host_OilHeadCheckNO2],"
					+ "[Host_OilHeadCheckNO3],"
					+ "[Host_OilHeadCheckNO4],"
					+ "[Host_OilHeadCheckNO5],"
					+ "[Host_OilHeadCheckNO6],"
					+ "[Host_OilHeadCheckNO7],"
					+ "[Host_OilHeadCheckNO8],"
					+ "[Host_OilHeadCheckNO9],"
					+ "[Host_CrossheadBearNO1],"
					+ "[Host_CrossheadBearNO2],"
					+ "[Host_CrossheadBearNO3],"
					+ "[Host_CrossheadBearNO4],"
					+ "[Host_CrossheadBearNO5],"
					+ "[Host_CrossheadBearNO6],"
					+ "[Host_CrossheadBearNO7],"
					+ "[Host_CrossheadBearNO8],"
					+ "[Host_CrossheadBearNO9],"
					+ "[Host_ConnectRodBearNO1],"
					+ "[Host_ConnectRodBearNO2],"
					+ "[Host_ConnectRodBearNO3],"
					+ "[Host_ConnectRodBearNO4],"
					+ "[Host_ConnectRodBearNO5],"
					+ "[Host_ConnectRodBearNO6],"
					+ "[Host_ConnectRodBearNO7],"
					+ "[Host_ConnectRodBearNO8],"
					+ "[Host_ConnectRodBearNO9],"
					+ "[Host_MajorBearNO1],"
					+ "[Host_MajorBearNO2],"
					+ "[Host_MajorBearNO3],"
					+ "[Host_MajorBearNO4],"
					+ "[Host_MajorBearNO5],"
					+ "[Host_MajorBearNO6],"
					+ "[Host_MajorBearNO7],"
					+ "[Host_MajorBearNO8],"
					+ "[Host_MajorBearNO9],"
					+ "[Host_HighPreesurePumpNO1],"
					+ "[Host_HighPreesurePumpNO2],"
					+ "[Host_HighPreesurePumpNO3],"
					+ "[Host_HighPreesurePumpNO4],"
					+ "[Host_HighPreesurePumpNO5],"
					+ "[Host_HighPreesurePumpNO6],"
					+ "[Host_HighPreesurePumpNO7],"
					+ "[Host_HighPreesurePumpNO8],"
					+ "[Host_HighPreesurePumpNO9],"
					+ "[Gas_DismantNO1],"
					+ "[Gas_DismantNO2],"
					+ "[Gas_MarblePanelNO1],"
					+ "[Gas_MarblePanelNO2],"
					+ "[Gas_AirCoolerNO1],"
					+ "[Gas_AirCoolerNO2],"
					+ "[Gas_STotalNO1],"
					+ "[Gas_STotalNO2],"
					+ "[Gas_STotalNO3],"
					+ "[Gas_SLiftingCylinderNO1],"
					+ "[Gas_SLiftingCylinderNO2],"
					+ "[Gas_SLiftingCylinderNO3],"
					+ "[Gas_SExhaustExchangeNO1],"
					+ "[Gas_SExhaustExchangeNO2],"
					+ "[Gas_SExhaustExchangeNO3],"
					+ "[Gas_SOilHeadNO1],"
					+ "[Gas_SOilHeadNO2],"
					+ "[Gas_SOilHeadNO3],"
					+ "[Gas_SMajorBearNO1],"
					+ "[Gas_SMajorBearNO2],"
					+ "[Gas_SMajorBearNO3],"
					+ "[Gas_STurbochargerNO1],"
					+ "[Gas_STurbochargerNO2],"
					+ "[Gas_STurbochargerNO3],"
					+ "[Gas_ACTotalNO1],"
					+ "[Gas_ACTotalNO2],"
					+ "[Gas_ACTotalNO3],"
					+ "[Gas_ACliftingCylinderNO1],"
					+ "[Gas_ACliftingCylinderNO2],"
					+ "[Gas_ACliftingCylinderNO3],"
					+ "[Gas_PPTotalNO1],"
					+ "[Gas_PPTotalNO2],"
					+ "[Gas_PPCheckNO1],"
					+ "[Gas_PPCheckNO2],"
					+ "[Gas_Remarks],"
					+ "[ChiefSign],"
					+ "[Pump_MainSeaTotalNO1],"
					+ "[Pump_MainSeaTotalNO2],"
					+ "[Pump_MainSeaDisintegrationNO1],"
					+ "[Pump_MainSeaDisintegrationNO2],"
					+ "[Pump_SecondSeaTotal],"
					+ "[Pump_SecondSeaDisintegration],"
					+ "[Pump_CylinderTotalNO1],"
					+ "[Pump_CylinderTotalNO2],"
					+ "[Pump_CylinderDisintegrationNO1],"
					+ "[Pump_CylinderDisintegrationNO2],"
					+ "[Pump_LowTemTotalNO1],"
					+ "[Pump_LowTemTotalNO2],"
					+ "[Pump_LowTemDisintegrationNO1],"
					+ "[Pump_LowTemDisintegrationNO2],"
					+ "[Pump_ParkLowTemTotal],"
					+ "[Pump_ParkLowTemDisintegration],"
					+ "[Pump_MainOilTotalNO1],"
					+ "[Pump_MainOilTotalNO2],"
					+ "[Pump_MainOilDisintegrationNO1],"
					+ "[Pump_MainOilDisintegrationNO2],"
					+ "[Pump_CamshaftOilTotalNO1],"
					+ "[Pump_CamshaftOilTotalNO2],"
					+ "[Pump_CamshaftOilDisintegrationNO1],"
					+ "[Pump_CamshaftOilDisintegrationNO2],"
					+ "[Pump_BoilerTotal],"
					+ "[Pump_BoilerDisintegration],"
					+ "[Pump_GeneralToatl],"
					+ "[Pump_GeneralDisintegration],"
					+ "[Pump_FireTotal],"
					+ "[Pump_FireDisintegration],"
					+ "[Pump_FuelCircleTotalNO1],"
					+ "[Pump_FuelCircleTotalNO2],"
					+ "[Pump_FuelCircleDisintegratinNO1],"
					+ "[Pump_FuelCircleDisintegratinNO2],"
					+ "[Pump_FuelPressureTotalNO1],"
					+ "[Pump_FuelPressureTotalNO2],"
					+ "[Pump_FuelPressureDisintegrationNO1],"
					+ "[Pump_FuelPressureDisintegrationNO2],"
					+ "[Pump_HeavyOilTotalNO1],"
					+ "[Pump_HeavyOilTotalNO2],"
					+ "[Pump_HeavyOilDisintegrationNO1],"
					+ "[Pump_HeavyOilDisintegrationNO2],"
					+ "[Pump_DieselFuelTotal],"
					+ "[Pump_DieselFuelDisintegration],"
					+ "[Pump_OilTotalNO1],"
					+ "[Pump_OilTotalNO2],"
					+ "[Pump_OilDisintegrationNO1],"
					+ "[Pump_OilDisintegrationNO2],"
					+ "[Pump_BallastTotalNO1],"
					+ "[Pump_BallastTotalNO2],"
					+ "[Pump_BallastDisintegrationNO1],"
					+ "[Pump_BallastDisintegrationNO2],"
					+ "[Pump_EmergencyTotal],"
					+ "[Pump_EmergencyDisintegration]"
					+ ") VALUES( "
					+ " " + (unit.Report_MajorEquipTime_Id==null?"''":"'" + unit.Report_MajorEquipTime_Id.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.File_ID)?"null":"'" + unit.File_ID.Replace ("'","''") + "'")
					+ " , " + (unit.Voyage==null?"''":"'" + unit.Voyage.Replace ("'","''") + "'")
					+ " , " + (unit.Cabin_HostTotal==null?"''":"'" + unit.Cabin_HostTotal.Replace ("'","''") + "'")
					+ " ," + dbOperation.DbToDate(unit.Cabin_StatisticsDate)
					+ " , " + (unit.Host_CylinderRenewalNO1==null?"''":"'" + unit.Host_CylinderRenewalNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Host_CylinderRenewalNO2==null?"''":"'" + unit.Host_CylinderRenewalNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Host_CylinderRenewalNO3==null?"''":"'" + unit.Host_CylinderRenewalNO3.Replace ("'","''") + "'")
					+ " , " + (unit.Host_CylinderRenewalNO4==null?"''":"'" + unit.Host_CylinderRenewalNO4.Replace ("'","''") + "'")
					+ " , " + (unit.Host_CylinderRenewalNO5==null?"''":"'" + unit.Host_CylinderRenewalNO5.Replace ("'","''") + "'")
					+ " , " + (unit.Host_CylinderRenewalNO6==null?"''":"'" + unit.Host_CylinderRenewalNO6.Replace ("'","''") + "'")
					+ " , " + (unit.Host_CylinderRenewalNO7==null?"''":"'" + unit.Host_CylinderRenewalNO7.Replace ("'","''") + "'")
					+ " , " + (unit.Host_CylinderRenewalNO8==null?"''":"'" + unit.Host_CylinderRenewalNO8.Replace ("'","''") + "'")
					+ " , " + (unit.Host_CylinderRenewalNO9==null?"''":"'" + unit.Host_CylinderRenewalNO9.Replace ("'","''") + "'")
					+ " , " + (unit.Host_LiftingCylinderNO1==null?"''":"'" + unit.Host_LiftingCylinderNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Host_LiftingCylinderNO2==null?"''":"'" + unit.Host_LiftingCylinderNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Host_LiftingCylinderNO3==null?"''":"'" + unit.Host_LiftingCylinderNO3.Replace ("'","''") + "'")
					+ " , " + (unit.Host_LiftingCylinderNO4==null?"''":"'" + unit.Host_LiftingCylinderNO4.Replace ("'","''") + "'")
					+ " , " + (unit.Host_LiftingCylinderNO5==null?"''":"'" + unit.Host_LiftingCylinderNO5.Replace ("'","''") + "'")
					+ " , " + (unit.Host_LiftingCylinderNO6==null?"''":"'" + unit.Host_LiftingCylinderNO6.Replace ("'","''") + "'")
					+ " , " + (unit.Host_LiftingCylinderNO7==null?"''":"'" + unit.Host_LiftingCylinderNO7.Replace ("'","''") + "'")
					+ " , " + (unit.Host_LiftingCylinderNO8==null?"''":"'" + unit.Host_LiftingCylinderNO8.Replace ("'","''") + "'")
					+ " , " + (unit.Host_LiftingCylinderNO9==null?"''":"'" + unit.Host_LiftingCylinderNO9.Replace ("'","''") + "'")
					+ " , " + (unit.Host_ExhaustExchangeNO1==null?"''":"'" + unit.Host_ExhaustExchangeNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Host_ExhaustExchangeNO2==null?"''":"'" + unit.Host_ExhaustExchangeNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Host_ExhaustExchangeNO3==null?"''":"'" + unit.Host_ExhaustExchangeNO3.Replace ("'","''") + "'")
					+ " , " + (unit.Host_ExhaustExchangeNO4==null?"''":"'" + unit.Host_ExhaustExchangeNO4.Replace ("'","''") + "'")
					+ " , " + (unit.Host_ExhaustExchangeNO5==null?"''":"'" + unit.Host_ExhaustExchangeNO5.Replace ("'","''") + "'")
					+ " , " + (unit.Host_ExhaustExchangeNO6==null?"''":"'" + unit.Host_ExhaustExchangeNO6.Replace ("'","''") + "'")
					+ " , " + (unit.Host_ExhaustExchangeNO7==null?"''":"'" + unit.Host_ExhaustExchangeNO7.Replace ("'","''") + "'")
					+ " , " + (unit.Host_ExhaustExchangeNO8==null?"''":"'" + unit.Host_ExhaustExchangeNO8.Replace ("'","''") + "'")
					+ " , " + (unit.Host_ExhaustExchangeNO9==null?"''":"'" + unit.Host_ExhaustExchangeNO9.Replace ("'","''") + "'")
					+ " , " + (unit.Host_OilHeadCheckNO1==null?"''":"'" + unit.Host_OilHeadCheckNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Host_OilHeadCheckNO2==null?"''":"'" + unit.Host_OilHeadCheckNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Host_OilHeadCheckNO3==null?"''":"'" + unit.Host_OilHeadCheckNO3.Replace ("'","''") + "'")
					+ " , " + (unit.Host_OilHeadCheckNO4==null?"''":"'" + unit.Host_OilHeadCheckNO4.Replace ("'","''") + "'")
					+ " , " + (unit.Host_OilHeadCheckNO5==null?"''":"'" + unit.Host_OilHeadCheckNO5.Replace ("'","''") + "'")
					+ " , " + (unit.Host_OilHeadCheckNO6==null?"''":"'" + unit.Host_OilHeadCheckNO6.Replace ("'","''") + "'")
					+ " , " + (unit.Host_OilHeadCheckNO7==null?"''":"'" + unit.Host_OilHeadCheckNO7.Replace ("'","''") + "'")
					+ " , " + (unit.Host_OilHeadCheckNO8==null?"''":"'" + unit.Host_OilHeadCheckNO8.Replace ("'","''") + "'")
					+ " , " + (unit.Host_OilHeadCheckNO9==null?"''":"'" + unit.Host_OilHeadCheckNO9.Replace ("'","''") + "'")
					+ " , " + (unit.Host_CrossheadBearNO1==null?"''":"'" + unit.Host_CrossheadBearNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Host_CrossheadBearNO2==null?"''":"'" + unit.Host_CrossheadBearNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Host_CrossheadBearNO3==null?"''":"'" + unit.Host_CrossheadBearNO3.Replace ("'","''") + "'")
					+ " , " + (unit.Host_CrossheadBearNO4==null?"''":"'" + unit.Host_CrossheadBearNO4.Replace ("'","''") + "'")
					+ " , " + (unit.Host_CrossheadBearNO5==null?"''":"'" + unit.Host_CrossheadBearNO5.Replace ("'","''") + "'")
					+ " , " + (unit.Host_CrossheadBearNO6==null?"''":"'" + unit.Host_CrossheadBearNO6.Replace ("'","''") + "'")
					+ " , " + (unit.Host_CrossheadBearNO7==null?"''":"'" + unit.Host_CrossheadBearNO7.Replace ("'","''") + "'")
					+ " , " + (unit.Host_CrossheadBearNO8==null?"''":"'" + unit.Host_CrossheadBearNO8.Replace ("'","''") + "'")
					+ " , " + (unit.Host_CrossheadBearNO9==null?"''":"'" + unit.Host_CrossheadBearNO9.Replace ("'","''") + "'")
					+ " , " + (unit.Host_ConnectRodBearNO1==null?"''":"'" + unit.Host_ConnectRodBearNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Host_ConnectRodBearNO2==null?"''":"'" + unit.Host_ConnectRodBearNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Host_ConnectRodBearNO3==null?"''":"'" + unit.Host_ConnectRodBearNO3.Replace ("'","''") + "'")
					+ " , " + (unit.Host_ConnectRodBearNO4==null?"''":"'" + unit.Host_ConnectRodBearNO4.Replace ("'","''") + "'")
					+ " , " + (unit.Host_ConnectRodBearNO5==null?"''":"'" + unit.Host_ConnectRodBearNO5.Replace ("'","''") + "'")
					+ " , " + (unit.Host_ConnectRodBearNO6==null?"''":"'" + unit.Host_ConnectRodBearNO6.Replace ("'","''") + "'")
					+ " , " + (unit.Host_ConnectRodBearNO7==null?"''":"'" + unit.Host_ConnectRodBearNO7.Replace ("'","''") + "'")
					+ " , " + (unit.Host_ConnectRodBearNO8==null?"''":"'" + unit.Host_ConnectRodBearNO8.Replace ("'","''") + "'")
					+ " , " + (unit.Host_ConnectRodBearNO9==null?"''":"'" + unit.Host_ConnectRodBearNO9.Replace ("'","''") + "'")
					+ " , " + (unit.Host_MajorBearNO1==null?"''":"'" + unit.Host_MajorBearNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Host_MajorBearNO2==null?"''":"'" + unit.Host_MajorBearNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Host_MajorBearNO3==null?"''":"'" + unit.Host_MajorBearNO3.Replace ("'","''") + "'")
					+ " , " + (unit.Host_MajorBearNO4==null?"''":"'" + unit.Host_MajorBearNO4.Replace ("'","''") + "'")
					+ " , " + (unit.Host_MajorBearNO5==null?"''":"'" + unit.Host_MajorBearNO5.Replace ("'","''") + "'")
					+ " , " + (unit.Host_MajorBearNO6==null?"''":"'" + unit.Host_MajorBearNO6.Replace ("'","''") + "'")
					+ " , " + (unit.Host_MajorBearNO7==null?"''":"'" + unit.Host_MajorBearNO7.Replace ("'","''") + "'")
					+ " , " + (unit.Host_MajorBearNO8==null?"''":"'" + unit.Host_MajorBearNO8.Replace ("'","''") + "'")
					+ " , " + (unit.Host_MajorBearNO9==null?"''":"'" + unit.Host_MajorBearNO9.Replace ("'","''") + "'")
					+ " , " + (unit.Host_HighPreesurePumpNO1==null?"''":"'" + unit.Host_HighPreesurePumpNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Host_HighPreesurePumpNO2==null?"''":"'" + unit.Host_HighPreesurePumpNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Host_HighPreesurePumpNO3==null?"''":"'" + unit.Host_HighPreesurePumpNO3.Replace ("'","''") + "'")
					+ " , " + (unit.Host_HighPreesurePumpNO4==null?"''":"'" + unit.Host_HighPreesurePumpNO4.Replace ("'","''") + "'")
					+ " , " + (unit.Host_HighPreesurePumpNO5==null?"''":"'" + unit.Host_HighPreesurePumpNO5.Replace ("'","''") + "'")
					+ " , " + (unit.Host_HighPreesurePumpNO6==null?"''":"'" + unit.Host_HighPreesurePumpNO6.Replace ("'","''") + "'")
					+ " , " + (unit.Host_HighPreesurePumpNO7==null?"''":"'" + unit.Host_HighPreesurePumpNO7.Replace ("'","''") + "'")
					+ " , " + (unit.Host_HighPreesurePumpNO8==null?"''":"'" + unit.Host_HighPreesurePumpNO8.Replace ("'","''") + "'")
					+ " , " + (unit.Host_HighPreesurePumpNO9==null?"''":"'" + unit.Host_HighPreesurePumpNO9.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_DismantNO1==null?"''":"'" + unit.Gas_DismantNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_DismantNO2==null?"''":"'" + unit.Gas_DismantNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_MarblePanelNO1==null?"''":"'" + unit.Gas_MarblePanelNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_MarblePanelNO2==null?"''":"'" + unit.Gas_MarblePanelNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_AirCoolerNO1==null?"''":"'" + unit.Gas_AirCoolerNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_AirCoolerNO2==null?"''":"'" + unit.Gas_AirCoolerNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_STotalNO1==null?"''":"'" + unit.Gas_STotalNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_STotalNO2==null?"''":"'" + unit.Gas_STotalNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_STotalNO3==null?"''":"'" + unit.Gas_STotalNO3.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_SLiftingCylinderNO1==null?"''":"'" + unit.Gas_SLiftingCylinderNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_SLiftingCylinderNO2==null?"''":"'" + unit.Gas_SLiftingCylinderNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_SLiftingCylinderNO3==null?"''":"'" + unit.Gas_SLiftingCylinderNO3.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_SExhaustExchangeNO1==null?"''":"'" + unit.Gas_SExhaustExchangeNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_SExhaustExchangeNO2==null?"''":"'" + unit.Gas_SExhaustExchangeNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_SExhaustExchangeNO3==null?"''":"'" + unit.Gas_SExhaustExchangeNO3.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_SOilHeadNO1==null?"''":"'" + unit.Gas_SOilHeadNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_SOilHeadNO2==null?"''":"'" + unit.Gas_SOilHeadNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_SOilHeadNO3==null?"''":"'" + unit.Gas_SOilHeadNO3.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_SMajorBearNO1==null?"''":"'" + unit.Gas_SMajorBearNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_SMajorBearNO2==null?"''":"'" + unit.Gas_SMajorBearNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_SMajorBearNO3==null?"''":"'" + unit.Gas_SMajorBearNO3.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_STurbochargerNO1==null?"''":"'" + unit.Gas_STurbochargerNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_STurbochargerNO2==null?"''":"'" + unit.Gas_STurbochargerNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_STurbochargerNO3==null?"''":"'" + unit.Gas_STurbochargerNO3.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_ACTotalNO1==null?"''":"'" + unit.Gas_ACTotalNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_ACTotalNO2==null?"''":"'" + unit.Gas_ACTotalNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_ACTotalNO3==null?"''":"'" + unit.Gas_ACTotalNO3.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_ACliftingCylinderNO1==null?"''":"'" + unit.Gas_ACliftingCylinderNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_ACliftingCylinderNO2==null?"''":"'" + unit.Gas_ACliftingCylinderNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_ACliftingCylinderNO3==null?"''":"'" + unit.Gas_ACliftingCylinderNO3.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_PPTotalNO1==null?"''":"'" + unit.Gas_PPTotalNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_PPTotalNO2==null?"''":"'" + unit.Gas_PPTotalNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_PPCheckNO1==null?"''":"'" + unit.Gas_PPCheckNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_PPCheckNO2==null?"''":"'" + unit.Gas_PPCheckNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Gas_Remarks==null?"''":"'" + unit.Gas_Remarks.Replace ("'","''") + "'")
					+ " , " + (unit.ChiefSign==null?"''":"'" + unit.ChiefSign.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_MainSeaTotalNO1==null?"''":"'" + unit.Pump_MainSeaTotalNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_MainSeaTotalNO2==null?"''":"'" + unit.Pump_MainSeaTotalNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_MainSeaDisintegrationNO1==null?"''":"'" + unit.Pump_MainSeaDisintegrationNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_MainSeaDisintegrationNO2==null?"''":"'" + unit.Pump_MainSeaDisintegrationNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_SecondSeaTotal==null?"''":"'" + unit.Pump_SecondSeaTotal.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_SecondSeaDisintegration==null?"''":"'" + unit.Pump_SecondSeaDisintegration.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_CylinderTotalNO1==null?"''":"'" + unit.Pump_CylinderTotalNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_CylinderTotalNO2==null?"''":"'" + unit.Pump_CylinderTotalNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_CylinderDisintegrationNO1==null?"''":"'" + unit.Pump_CylinderDisintegrationNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_CylinderDisintegrationNO2==null?"''":"'" + unit.Pump_CylinderDisintegrationNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_LowTemTotalNO1==null?"''":"'" + unit.Pump_LowTemTotalNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_LowTemTotalNO2==null?"''":"'" + unit.Pump_LowTemTotalNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_LowTemDisintegrationNO1==null?"''":"'" + unit.Pump_LowTemDisintegrationNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_LowTemDisintegrationNO2==null?"''":"'" + unit.Pump_LowTemDisintegrationNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_ParkLowTemTotal==null?"''":"'" + unit.Pump_ParkLowTemTotal.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_ParkLowTemDisintegration==null?"''":"'" + unit.Pump_ParkLowTemDisintegration.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_MainOilTotalNO1==null?"''":"'" + unit.Pump_MainOilTotalNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_MainOilTotalNO2==null?"''":"'" + unit.Pump_MainOilTotalNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_MainOilDisintegrationNO1==null?"''":"'" + unit.Pump_MainOilDisintegrationNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_MainOilDisintegrationNO2==null?"''":"'" + unit.Pump_MainOilDisintegrationNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_CamshaftOilTotalNO1==null?"''":"'" + unit.Pump_CamshaftOilTotalNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_CamshaftOilTotalNO2==null?"''":"'" + unit.Pump_CamshaftOilTotalNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_CamshaftOilDisintegrationNO1==null?"''":"'" + unit.Pump_CamshaftOilDisintegrationNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_CamshaftOilDisintegrationNO2==null?"''":"'" + unit.Pump_CamshaftOilDisintegrationNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_BoilerTotal==null?"''":"'" + unit.Pump_BoilerTotal.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_BoilerDisintegration==null?"''":"'" + unit.Pump_BoilerDisintegration.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_GeneralToatl==null?"''":"'" + unit.Pump_GeneralToatl.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_GeneralDisintegration==null?"''":"'" + unit.Pump_GeneralDisintegration.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_FireTotal==null?"''":"'" + unit.Pump_FireTotal.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_FireDisintegration==null?"''":"'" + unit.Pump_FireDisintegration.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_FuelCircleTotalNO1==null?"''":"'" + unit.Pump_FuelCircleTotalNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_FuelCircleTotalNO2==null?"''":"'" + unit.Pump_FuelCircleTotalNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_FuelCircleDisintegratinNO1==null?"''":"'" + unit.Pump_FuelCircleDisintegratinNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_FuelCircleDisintegratinNO2==null?"''":"'" + unit.Pump_FuelCircleDisintegratinNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_FuelPressureTotalNO1==null?"''":"'" + unit.Pump_FuelPressureTotalNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_FuelPressureTotalNO2==null?"''":"'" + unit.Pump_FuelPressureTotalNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_FuelPressureDisintegrationNO1==null?"''":"'" + unit.Pump_FuelPressureDisintegrationNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_FuelPressureDisintegrationNO2==null?"''":"'" + unit.Pump_FuelPressureDisintegrationNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_HeavyOilTotalNO1==null?"''":"'" + unit.Pump_HeavyOilTotalNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_HeavyOilTotalNO2==null?"''":"'" + unit.Pump_HeavyOilTotalNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_HeavyOilDisintegrationNO1==null?"''":"'" + unit.Pump_HeavyOilDisintegrationNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_HeavyOilDisintegrationNO2==null?"''":"'" + unit.Pump_HeavyOilDisintegrationNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_DieselFuelTotal==null?"''":"'" + unit.Pump_DieselFuelTotal.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_DieselFuelDisintegration==null?"''":"'" + unit.Pump_DieselFuelDisintegration.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_OilTotalNO1==null?"''":"'" + unit.Pump_OilTotalNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_OilTotalNO2==null?"''":"'" + unit.Pump_OilTotalNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_OilDisintegrationNO1==null?"''":"'" + unit.Pump_OilDisintegrationNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_OilDisintegrationNO2==null?"''":"'" + unit.Pump_OilDisintegrationNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_BallastTotalNO1==null?"''":"'" + unit.Pump_BallastTotalNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_BallastTotalNO2==null?"''":"'" + unit.Pump_BallastTotalNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_BallastDisintegrationNO1==null?"''":"'" + unit.Pump_BallastDisintegrationNO1.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_BallastDisintegrationNO2==null?"''":"'" + unit.Pump_BallastDisintegrationNO2.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_EmergencyTotal==null?"''":"'" + unit.Pump_EmergencyTotal.Replace ("'","''") + "'")
					+ " , " + (unit.Pump_EmergencyDisintegration==null?"''":"'" + unit.Pump_EmergencyDisintegration.Replace ("'","''") + "'")
					+ ")";
			}

			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_REPORT_MAJOREQUIPTIME中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_REPORT_MAJOREQUIPTIME对象</param>
		internal bool deleteUnit(ReportMajorEquipment unit,out string err)
		{
			return deleteUnit(unit.Report_MajorEquipTime_Id,out err);
		}
		
		/// <summary>
		/// 删除数据表T_REPORT_MAJOREQUIPTIME中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_REPORT_MAJOREQUIPTIME.report_MajorEquipTime_Id主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_REPORT_MAJOREQUIPTIME where "
				+ " upper(T_REPORT_MAJOREQUIPTIME.Report_MajorEquipTime_Id)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_REPORT_MAJOREQUIPTIME 所有数据信息.
		/// </summary>
		/// <returns>T_REPORT_MAJOREQUIPTIME DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql = "select	"
				+ "Report_MajorEquipTime_Id"
				+ ",SHIP_ID"
				+ ",File_ID"
				+ ",Voyage"
				+ ",Cabin_HostTotal"
				+ ",Cabin_StatisticsDate"
				+ ",Host_CylinderRenewalNO1"
				+ ",Host_CylinderRenewalNO2"
				+ ",Host_CylinderRenewalNO3"
				+ ",Host_CylinderRenewalNO4"
				+ ",Host_CylinderRenewalNO5"
				+ ",Host_CylinderRenewalNO6"
				+ ",Host_CylinderRenewalNO7"
				+ ",Host_CylinderRenewalNO8"
				+ ",Host_CylinderRenewalNO9"
				+ ",Host_LiftingCylinderNO1"
				+ ",Host_LiftingCylinderNO2"
				+ ",Host_LiftingCylinderNO3"
				+ ",Host_LiftingCylinderNO4"
				+ ",Host_LiftingCylinderNO5"
				+ ",Host_LiftingCylinderNO6"
				+ ",Host_LiftingCylinderNO7"
				+ ",Host_LiftingCylinderNO8"
				+ ",Host_LiftingCylinderNO9"
				+ ",Host_ExhaustExchangeNO1"
				+ ",Host_ExhaustExchangeNO2"
				+ ",Host_ExhaustExchangeNO3"
				+ ",Host_ExhaustExchangeNO4"
				+ ",Host_ExhaustExchangeNO5"
				+ ",Host_ExhaustExchangeNO6"
				+ ",Host_ExhaustExchangeNO7"
				+ ",Host_ExhaustExchangeNO8"
				+ ",Host_ExhaustExchangeNO9"
				+ ",Host_OilHeadCheckNO1"
				+ ",Host_OilHeadCheckNO2"
				+ ",Host_OilHeadCheckNO3"
				+ ",Host_OilHeadCheckNO4"
				+ ",Host_OilHeadCheckNO5"
				+ ",Host_OilHeadCheckNO6"
				+ ",Host_OilHeadCheckNO7"
				+ ",Host_OilHeadCheckNO8"
				+ ",Host_OilHeadCheckNO9"
				+ ",Host_CrossheadBearNO1"
				+ ",Host_CrossheadBearNO2"
				+ ",Host_CrossheadBearNO3"
				+ ",Host_CrossheadBearNO4"
				+ ",Host_CrossheadBearNO5"
				+ ",Host_CrossheadBearNO6"
				+ ",Host_CrossheadBearNO7"
				+ ",Host_CrossheadBearNO8"
				+ ",Host_CrossheadBearNO9"
				+ ",Host_ConnectRodBearNO1"
				+ ",Host_ConnectRodBearNO2"
				+ ",Host_ConnectRodBearNO3"
				+ ",Host_ConnectRodBearNO4"
				+ ",Host_ConnectRodBearNO5"
				+ ",Host_ConnectRodBearNO6"
				+ ",Host_ConnectRodBearNO7"
				+ ",Host_ConnectRodBearNO8"
				+ ",Host_ConnectRodBearNO9"
				+ ",Host_MajorBearNO1"
				+ ",Host_MajorBearNO2"
				+ ",Host_MajorBearNO3"
				+ ",Host_MajorBearNO4"
				+ ",Host_MajorBearNO5"
				+ ",Host_MajorBearNO6"
				+ ",Host_MajorBearNO7"
				+ ",Host_MajorBearNO8"
				+ ",Host_MajorBearNO9"
				+ ",Host_HighPreesurePumpNO1"
				+ ",Host_HighPreesurePumpNO2"
				+ ",Host_HighPreesurePumpNO3"
				+ ",Host_HighPreesurePumpNO4"
				+ ",Host_HighPreesurePumpNO5"
				+ ",Host_HighPreesurePumpNO6"
				+ ",Host_HighPreesurePumpNO7"
				+ ",Host_HighPreesurePumpNO8"
				+ ",Host_HighPreesurePumpNO9"
				+ ",Gas_DismantNO1"
				+ ",Gas_DismantNO2"
				+ ",Gas_MarblePanelNO1"
				+ ",Gas_MarblePanelNO2"
				+ ",Gas_AirCoolerNO1"
				+ ",Gas_AirCoolerNO2"
				+ ",Gas_STotalNO1"
				+ ",Gas_STotalNO2"
				+ ",Gas_STotalNO3"
				+ ",Gas_SLiftingCylinderNO1"
				+ ",Gas_SLiftingCylinderNO2"
				+ ",Gas_SLiftingCylinderNO3"
				+ ",Gas_SExhaustExchangeNO1"
				+ ",Gas_SExhaustExchangeNO2"
				+ ",Gas_SExhaustExchangeNO3"
				+ ",Gas_SOilHeadNO1"
				+ ",Gas_SOilHeadNO2"
				+ ",Gas_SOilHeadNO3"
				+ ",Gas_SMajorBearNO1"
				+ ",Gas_SMajorBearNO2"
				+ ",Gas_SMajorBearNO3"
				+ ",Gas_STurbochargerNO1"
				+ ",Gas_STurbochargerNO2"
				+ ",Gas_STurbochargerNO3"
				+ ",Gas_ACTotalNO1"
				+ ",Gas_ACTotalNO2"
				+ ",Gas_ACTotalNO3"
				+ ",Gas_ACliftingCylinderNO1"
				+ ",Gas_ACliftingCylinderNO2"
				+ ",Gas_ACliftingCylinderNO3"
				+ ",Gas_PPTotalNO1"
				+ ",Gas_PPTotalNO2"
				+ ",Gas_PPCheckNO1"
				+ ",Gas_PPCheckNO2"
				+ ",Gas_Remarks"
				+ ",ChiefSign"
				+ ",Pump_MainSeaTotalNO1"
				+ ",Pump_MainSeaTotalNO2"
				+ ",Pump_MainSeaDisintegrationNO1"
				+ ",Pump_MainSeaDisintegrationNO2"
				+ ",Pump_SecondSeaTotal"
				+ ",Pump_SecondSeaDisintegration"
				+ ",Pump_CylinderTotalNO1"
				+ ",Pump_CylinderTotalNO2"
				+ ",Pump_CylinderDisintegrationNO1"
				+ ",Pump_CylinderDisintegrationNO2"
				+ ",Pump_LowTemTotalNO1"
				+ ",Pump_LowTemTotalNO2"
				+ ",Pump_LowTemDisintegrationNO1"
				+ ",Pump_LowTemDisintegrationNO2"
				+ ",Pump_ParkLowTemTotal"
				+ ",Pump_ParkLowTemDisintegration"
				+ ",Pump_MainOilTotalNO1"
				+ ",Pump_MainOilTotalNO2"
				+ ",Pump_MainOilDisintegrationNO1"
				+ ",Pump_MainOilDisintegrationNO2"
				+ ",Pump_CamshaftOilTotalNO1"
				+ ",Pump_CamshaftOilTotalNO2"
				+ ",Pump_CamshaftOilDisintegrationNO1"
				+ ",Pump_CamshaftOilDisintegrationNO2"
				+ ",Pump_BoilerTotal"
				+ ",Pump_BoilerDisintegration"
				+ ",Pump_GeneralToatl"
				+ ",Pump_GeneralDisintegration"
				+ ",Pump_FireTotal"
				+ ",Pump_FireDisintegration"
				+ ",Pump_FuelCircleTotalNO1"
				+ ",Pump_FuelCircleTotalNO2"
				+ ",Pump_FuelCircleDisintegratinNO1"
				+ ",Pump_FuelCircleDisintegratinNO2"
				+ ",Pump_FuelPressureTotalNO1"
				+ ",Pump_FuelPressureTotalNO2"
				+ ",Pump_FuelPressureDisintegrationNO1"
				+ ",Pump_FuelPressureDisintegrationNO2"
				+ ",Pump_HeavyOilTotalNO1"
				+ ",Pump_HeavyOilTotalNO2"
				+ ",Pump_HeavyOilDisintegrationNO1"
				+ ",Pump_HeavyOilDisintegrationNO2"
				+ ",Pump_DieselFuelTotal"
				+ ",Pump_DieselFuelDisintegration"
				+ ",Pump_OilTotalNO1"
				+ ",Pump_OilTotalNO2"
				+ ",Pump_OilDisintegrationNO1"
				+ ",Pump_OilDisintegrationNO2"
				+ ",Pump_BallastTotalNO1"
				+ ",Pump_BallastTotalNO2"
				+ ",Pump_BallastDisintegrationNO1"
				+ ",Pump_BallastDisintegrationNO2"
				+ ",Pump_EmergencyTotal"
				+ ",Pump_EmergencyDisintegration"
				+ "  from T_REPORT_MAJOREQUIPTIME ";
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
		/// 根据一个主键ID,得到 T_REPORT_MAJOREQUIPTIME 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>ReportMajorEquipment DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql = "select "
				+ "Report_MajorEquipTime_Id"
				+ ",SHIP_ID"
				+ ",File_ID"
				+ ",Voyage"
				+ ",Cabin_HostTotal"
				+ ",Cabin_StatisticsDate"
				+ ",Host_CylinderRenewalNO1"
				+ ",Host_CylinderRenewalNO2"
				+ ",Host_CylinderRenewalNO3"
				+ ",Host_CylinderRenewalNO4"
				+ ",Host_CylinderRenewalNO5"
				+ ",Host_CylinderRenewalNO6"
				+ ",Host_CylinderRenewalNO7"
				+ ",Host_CylinderRenewalNO8"
				+ ",Host_CylinderRenewalNO9"
				+ ",Host_LiftingCylinderNO1"
				+ ",Host_LiftingCylinderNO2"
				+ ",Host_LiftingCylinderNO3"
				+ ",Host_LiftingCylinderNO4"
				+ ",Host_LiftingCylinderNO5"
				+ ",Host_LiftingCylinderNO6"
				+ ",Host_LiftingCylinderNO7"
				+ ",Host_LiftingCylinderNO8"
				+ ",Host_LiftingCylinderNO9"
				+ ",Host_ExhaustExchangeNO1"
				+ ",Host_ExhaustExchangeNO2"
				+ ",Host_ExhaustExchangeNO3"
				+ ",Host_ExhaustExchangeNO4"
				+ ",Host_ExhaustExchangeNO5"
				+ ",Host_ExhaustExchangeNO6"
				+ ",Host_ExhaustExchangeNO7"
				+ ",Host_ExhaustExchangeNO8"
				+ ",Host_ExhaustExchangeNO9"
				+ ",Host_OilHeadCheckNO1"
				+ ",Host_OilHeadCheckNO2"
				+ ",Host_OilHeadCheckNO3"
				+ ",Host_OilHeadCheckNO4"
				+ ",Host_OilHeadCheckNO5"
				+ ",Host_OilHeadCheckNO6"
				+ ",Host_OilHeadCheckNO7"
				+ ",Host_OilHeadCheckNO8"
				+ ",Host_OilHeadCheckNO9"
				+ ",Host_CrossheadBearNO1"
				+ ",Host_CrossheadBearNO2"
				+ ",Host_CrossheadBearNO3"
				+ ",Host_CrossheadBearNO4"
				+ ",Host_CrossheadBearNO5"
				+ ",Host_CrossheadBearNO6"
				+ ",Host_CrossheadBearNO7"
				+ ",Host_CrossheadBearNO8"
				+ ",Host_CrossheadBearNO9"
				+ ",Host_ConnectRodBearNO1"
				+ ",Host_ConnectRodBearNO2"
				+ ",Host_ConnectRodBearNO3"
				+ ",Host_ConnectRodBearNO4"
				+ ",Host_ConnectRodBearNO5"
				+ ",Host_ConnectRodBearNO6"
				+ ",Host_ConnectRodBearNO7"
				+ ",Host_ConnectRodBearNO8"
				+ ",Host_ConnectRodBearNO9"
				+ ",Host_MajorBearNO1"
				+ ",Host_MajorBearNO2"
				+ ",Host_MajorBearNO3"
				+ ",Host_MajorBearNO4"
				+ ",Host_MajorBearNO5"
				+ ",Host_MajorBearNO6"
				+ ",Host_MajorBearNO7"
				+ ",Host_MajorBearNO8"
				+ ",Host_MajorBearNO9"
				+ ",Host_HighPreesurePumpNO1"
				+ ",Host_HighPreesurePumpNO2"
				+ ",Host_HighPreesurePumpNO3"
				+ ",Host_HighPreesurePumpNO4"
				+ ",Host_HighPreesurePumpNO5"
				+ ",Host_HighPreesurePumpNO6"
				+ ",Host_HighPreesurePumpNO7"
				+ ",Host_HighPreesurePumpNO8"
				+ ",Host_HighPreesurePumpNO9"
				+ ",Gas_DismantNO1"
				+ ",Gas_DismantNO2"
				+ ",Gas_MarblePanelNO1"
				+ ",Gas_MarblePanelNO2"
				+ ",Gas_AirCoolerNO1"
				+ ",Gas_AirCoolerNO2"
				+ ",Gas_STotalNO1"
				+ ",Gas_STotalNO2"
				+ ",Gas_STotalNO3"
				+ ",Gas_SLiftingCylinderNO1"
				+ ",Gas_SLiftingCylinderNO2"
				+ ",Gas_SLiftingCylinderNO3"
				+ ",Gas_SExhaustExchangeNO1"
				+ ",Gas_SExhaustExchangeNO2"
				+ ",Gas_SExhaustExchangeNO3"
				+ ",Gas_SOilHeadNO1"
				+ ",Gas_SOilHeadNO2"
				+ ",Gas_SOilHeadNO3"
				+ ",Gas_SMajorBearNO1"
				+ ",Gas_SMajorBearNO2"
				+ ",Gas_SMajorBearNO3"
				+ ",Gas_STurbochargerNO1"
				+ ",Gas_STurbochargerNO2"
				+ ",Gas_STurbochargerNO3"
				+ ",Gas_ACTotalNO1"
				+ ",Gas_ACTotalNO2"
				+ ",Gas_ACTotalNO3"
				+ ",Gas_ACliftingCylinderNO1"
				+ ",Gas_ACliftingCylinderNO2"
				+ ",Gas_ACliftingCylinderNO3"
				+ ",Gas_PPTotalNO1"
				+ ",Gas_PPTotalNO2"
				+ ",Gas_PPCheckNO1"
				+ ",Gas_PPCheckNO2"
				+ ",Gas_Remarks"
				+ ",ChiefSign"
				+ ",Pump_MainSeaTotalNO1"
				+ ",Pump_MainSeaTotalNO2"
				+ ",Pump_MainSeaDisintegrationNO1"
				+ ",Pump_MainSeaDisintegrationNO2"
				+ ",Pump_SecondSeaTotal"
				+ ",Pump_SecondSeaDisintegration"
				+ ",Pump_CylinderTotalNO1"
				+ ",Pump_CylinderTotalNO2"
				+ ",Pump_CylinderDisintegrationNO1"
				+ ",Pump_CylinderDisintegrationNO2"
				+ ",Pump_LowTemTotalNO1"
				+ ",Pump_LowTemTotalNO2"
				+ ",Pump_LowTemDisintegrationNO1"
				+ ",Pump_LowTemDisintegrationNO2"
				+ ",Pump_ParkLowTemTotal"
				+ ",Pump_ParkLowTemDisintegration"
				+ ",Pump_MainOilTotalNO1"
				+ ",Pump_MainOilTotalNO2"
				+ ",Pump_MainOilDisintegrationNO1"
				+ ",Pump_MainOilDisintegrationNO2"
				+ ",Pump_CamshaftOilTotalNO1"
				+ ",Pump_CamshaftOilTotalNO2"
				+ ",Pump_CamshaftOilDisintegrationNO1"
				+ ",Pump_CamshaftOilDisintegrationNO2"
				+ ",Pump_BoilerTotal"
				+ ",Pump_BoilerDisintegration"
				+ ",Pump_GeneralToatl"
				+ ",Pump_GeneralDisintegration"
				+ ",Pump_FireTotal"
				+ ",Pump_FireDisintegration"
				+ ",Pump_FuelCircleTotalNO1"
				+ ",Pump_FuelCircleTotalNO2"
				+ ",Pump_FuelCircleDisintegratinNO1"
				+ ",Pump_FuelCircleDisintegratinNO2"
				+ ",Pump_FuelPressureTotalNO1"
				+ ",Pump_FuelPressureTotalNO2"
				+ ",Pump_FuelPressureDisintegrationNO1"
				+ ",Pump_FuelPressureDisintegrationNO2"
				+ ",Pump_HeavyOilTotalNO1"
				+ ",Pump_HeavyOilTotalNO2"
				+ ",Pump_HeavyOilDisintegrationNO1"
				+ ",Pump_HeavyOilDisintegrationNO2"
				+ ",Pump_DieselFuelTotal"
				+ ",Pump_DieselFuelDisintegration"
				+ ",Pump_OilTotalNO1"
				+ ",Pump_OilTotalNO2"
				+ ",Pump_OilDisintegrationNO1"
				+ ",Pump_OilDisintegrationNO2"
				+ ",Pump_BallastTotalNO1"
				+ ",Pump_BallastTotalNO2"
				+ ",Pump_BallastDisintegrationNO1"
				+ ",Pump_BallastDisintegrationNO2"
				+ ",Pump_EmergencyTotal"
				+ ",Pump_EmergencyDisintegration"
				+ " from T_REPORT_MAJOREQUIPTIME "
				+ " where upper(Report_MajorEquipTime_Id)='" + Id.ToUpper()+"'";
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
		/// 根据reportmajorequipment 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>reportmajorequipment 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
		public ReportMajorEquipment getObject(DataRow dr)
		{
			ReportMajorEquipment unit=new ReportMajorEquipment();
			if (null==dr)
			{
				unit.IsWrong = true;
				unit.WhyWrong = "从数据库获取信息时出错,未成功构造ReportMajorEquipment类对象!";
				return unit;
			}
			if (DBNull.Value != dr["Report_MajorEquipTime_Id"])	
			    unit.Report_MajorEquipTime_Id=dr["Report_MajorEquipTime_Id"].ToString();
			if (DBNull.Value != dr["SHIP_ID"])	
			    unit.SHIP_ID=dr["SHIP_ID"].ToString();
			if (DBNull.Value != dr["File_ID"])	
			    unit.File_ID=dr["File_ID"].ToString();
			if (DBNull.Value != dr["Voyage"])	
			    unit.Voyage=dr["Voyage"].ToString();
			if (DBNull.Value != dr["Cabin_HostTotal"])	
			    unit.Cabin_HostTotal=dr["Cabin_HostTotal"].ToString();
			if (DBNull.Value != dr["Cabin_StatisticsDate"])	
                unit.Cabin_StatisticsDate=(DateTime)dr["Cabin_StatisticsDate"];
			if (DBNull.Value != dr["Host_CylinderRenewalNO1"])	
			    unit.Host_CylinderRenewalNO1=dr["Host_CylinderRenewalNO1"].ToString();
			if (DBNull.Value != dr["Host_CylinderRenewalNO2"])	
			    unit.Host_CylinderRenewalNO2=dr["Host_CylinderRenewalNO2"].ToString();
			if (DBNull.Value != dr["Host_CylinderRenewalNO3"])	
			    unit.Host_CylinderRenewalNO3=dr["Host_CylinderRenewalNO3"].ToString();
			if (DBNull.Value != dr["Host_CylinderRenewalNO4"])	
			    unit.Host_CylinderRenewalNO4=dr["Host_CylinderRenewalNO4"].ToString();
			if (DBNull.Value != dr["Host_CylinderRenewalNO5"])	
			    unit.Host_CylinderRenewalNO5=dr["Host_CylinderRenewalNO5"].ToString();
			if (DBNull.Value != dr["Host_CylinderRenewalNO6"])	
			    unit.Host_CylinderRenewalNO6=dr["Host_CylinderRenewalNO6"].ToString();
			if (DBNull.Value != dr["Host_CylinderRenewalNO7"])	
			    unit.Host_CylinderRenewalNO7=dr["Host_CylinderRenewalNO7"].ToString();
			if (DBNull.Value != dr["Host_CylinderRenewalNO8"])	
			    unit.Host_CylinderRenewalNO8=dr["Host_CylinderRenewalNO8"].ToString();
			if (DBNull.Value != dr["Host_CylinderRenewalNO9"])	
			    unit.Host_CylinderRenewalNO9=dr["Host_CylinderRenewalNO9"].ToString();
			if (DBNull.Value != dr["Host_LiftingCylinderNO1"])	
			    unit.Host_LiftingCylinderNO1=dr["Host_LiftingCylinderNO1"].ToString();
			if (DBNull.Value != dr["Host_LiftingCylinderNO2"])	
			    unit.Host_LiftingCylinderNO2=dr["Host_LiftingCylinderNO2"].ToString();
			if (DBNull.Value != dr["Host_LiftingCylinderNO3"])	
			    unit.Host_LiftingCylinderNO3=dr["Host_LiftingCylinderNO3"].ToString();
			if (DBNull.Value != dr["Host_LiftingCylinderNO4"])	
			    unit.Host_LiftingCylinderNO4=dr["Host_LiftingCylinderNO4"].ToString();
			if (DBNull.Value != dr["Host_LiftingCylinderNO5"])	
			    unit.Host_LiftingCylinderNO5=dr["Host_LiftingCylinderNO5"].ToString();
			if (DBNull.Value != dr["Host_LiftingCylinderNO6"])	
			    unit.Host_LiftingCylinderNO6=dr["Host_LiftingCylinderNO6"].ToString();
			if (DBNull.Value != dr["Host_LiftingCylinderNO7"])	
			    unit.Host_LiftingCylinderNO7=dr["Host_LiftingCylinderNO7"].ToString();
			if (DBNull.Value != dr["Host_LiftingCylinderNO8"])	
			    unit.Host_LiftingCylinderNO8=dr["Host_LiftingCylinderNO8"].ToString();
			if (DBNull.Value != dr["Host_LiftingCylinderNO9"])	
			    unit.Host_LiftingCylinderNO9=dr["Host_LiftingCylinderNO9"].ToString();
			if (DBNull.Value != dr["Host_ExhaustExchangeNO1"])	
			    unit.Host_ExhaustExchangeNO1=dr["Host_ExhaustExchangeNO1"].ToString();
			if (DBNull.Value != dr["Host_ExhaustExchangeNO2"])	
			    unit.Host_ExhaustExchangeNO2=dr["Host_ExhaustExchangeNO2"].ToString();
			if (DBNull.Value != dr["Host_ExhaustExchangeNO3"])	
			    unit.Host_ExhaustExchangeNO3=dr["Host_ExhaustExchangeNO3"].ToString();
			if (DBNull.Value != dr["Host_ExhaustExchangeNO4"])	
			    unit.Host_ExhaustExchangeNO4=dr["Host_ExhaustExchangeNO4"].ToString();
			if (DBNull.Value != dr["Host_ExhaustExchangeNO5"])	
			    unit.Host_ExhaustExchangeNO5=dr["Host_ExhaustExchangeNO5"].ToString();
			if (DBNull.Value != dr["Host_ExhaustExchangeNO6"])	
			    unit.Host_ExhaustExchangeNO6=dr["Host_ExhaustExchangeNO6"].ToString();
			if (DBNull.Value != dr["Host_ExhaustExchangeNO7"])	
			    unit.Host_ExhaustExchangeNO7=dr["Host_ExhaustExchangeNO7"].ToString();
			if (DBNull.Value != dr["Host_ExhaustExchangeNO8"])	
			    unit.Host_ExhaustExchangeNO8=dr["Host_ExhaustExchangeNO8"].ToString();
			if (DBNull.Value != dr["Host_ExhaustExchangeNO9"])	
			    unit.Host_ExhaustExchangeNO9=dr["Host_ExhaustExchangeNO9"].ToString();
			if (DBNull.Value != dr["Host_OilHeadCheckNO1"])	
			    unit.Host_OilHeadCheckNO1=dr["Host_OilHeadCheckNO1"].ToString();
			if (DBNull.Value != dr["Host_OilHeadCheckNO2"])	
			    unit.Host_OilHeadCheckNO2=dr["Host_OilHeadCheckNO2"].ToString();
			if (DBNull.Value != dr["Host_OilHeadCheckNO3"])	
			    unit.Host_OilHeadCheckNO3=dr["Host_OilHeadCheckNO3"].ToString();
			if (DBNull.Value != dr["Host_OilHeadCheckNO4"])	
			    unit.Host_OilHeadCheckNO4=dr["Host_OilHeadCheckNO4"].ToString();
			if (DBNull.Value != dr["Host_OilHeadCheckNO5"])	
			    unit.Host_OilHeadCheckNO5=dr["Host_OilHeadCheckNO5"].ToString();
			if (DBNull.Value != dr["Host_OilHeadCheckNO6"])	
			    unit.Host_OilHeadCheckNO6=dr["Host_OilHeadCheckNO6"].ToString();
			if (DBNull.Value != dr["Host_OilHeadCheckNO7"])	
			    unit.Host_OilHeadCheckNO7=dr["Host_OilHeadCheckNO7"].ToString();
			if (DBNull.Value != dr["Host_OilHeadCheckNO8"])	
			    unit.Host_OilHeadCheckNO8=dr["Host_OilHeadCheckNO8"].ToString();
			if (DBNull.Value != dr["Host_OilHeadCheckNO9"])	
			    unit.Host_OilHeadCheckNO9=dr["Host_OilHeadCheckNO9"].ToString();
			if (DBNull.Value != dr["Host_CrossheadBearNO1"])	
			    unit.Host_CrossheadBearNO1=dr["Host_CrossheadBearNO1"].ToString();
			if (DBNull.Value != dr["Host_CrossheadBearNO2"])	
			    unit.Host_CrossheadBearNO2=dr["Host_CrossheadBearNO2"].ToString();
			if (DBNull.Value != dr["Host_CrossheadBearNO3"])	
			    unit.Host_CrossheadBearNO3=dr["Host_CrossheadBearNO3"].ToString();
			if (DBNull.Value != dr["Host_CrossheadBearNO4"])	
			    unit.Host_CrossheadBearNO4=dr["Host_CrossheadBearNO4"].ToString();
			if (DBNull.Value != dr["Host_CrossheadBearNO5"])	
			    unit.Host_CrossheadBearNO5=dr["Host_CrossheadBearNO5"].ToString();
			if (DBNull.Value != dr["Host_CrossheadBearNO6"])	
			    unit.Host_CrossheadBearNO6=dr["Host_CrossheadBearNO6"].ToString();
			if (DBNull.Value != dr["Host_CrossheadBearNO7"])	
			    unit.Host_CrossheadBearNO7=dr["Host_CrossheadBearNO7"].ToString();
			if (DBNull.Value != dr["Host_CrossheadBearNO8"])	
			    unit.Host_CrossheadBearNO8=dr["Host_CrossheadBearNO8"].ToString();
			if (DBNull.Value != dr["Host_CrossheadBearNO9"])	
			    unit.Host_CrossheadBearNO9=dr["Host_CrossheadBearNO9"].ToString();
			if (DBNull.Value != dr["Host_ConnectRodBearNO1"])	
			    unit.Host_ConnectRodBearNO1=dr["Host_ConnectRodBearNO1"].ToString();
			if (DBNull.Value != dr["Host_ConnectRodBearNO2"])	
			    unit.Host_ConnectRodBearNO2=dr["Host_ConnectRodBearNO2"].ToString();
			if (DBNull.Value != dr["Host_ConnectRodBearNO3"])	
			    unit.Host_ConnectRodBearNO3=dr["Host_ConnectRodBearNO3"].ToString();
			if (DBNull.Value != dr["Host_ConnectRodBearNO4"])	
			    unit.Host_ConnectRodBearNO4=dr["Host_ConnectRodBearNO4"].ToString();
			if (DBNull.Value != dr["Host_ConnectRodBearNO5"])	
			    unit.Host_ConnectRodBearNO5=dr["Host_ConnectRodBearNO5"].ToString();
			if (DBNull.Value != dr["Host_ConnectRodBearNO6"])	
			    unit.Host_ConnectRodBearNO6=dr["Host_ConnectRodBearNO6"].ToString();
			if (DBNull.Value != dr["Host_ConnectRodBearNO7"])	
			    unit.Host_ConnectRodBearNO7=dr["Host_ConnectRodBearNO7"].ToString();
			if (DBNull.Value != dr["Host_ConnectRodBearNO8"])	
			    unit.Host_ConnectRodBearNO8=dr["Host_ConnectRodBearNO8"].ToString();
			if (DBNull.Value != dr["Host_ConnectRodBearNO9"])	
			    unit.Host_ConnectRodBearNO9=dr["Host_ConnectRodBearNO9"].ToString();
			if (DBNull.Value != dr["Host_MajorBearNO1"])	
			    unit.Host_MajorBearNO1=dr["Host_MajorBearNO1"].ToString();
			if (DBNull.Value != dr["Host_MajorBearNO2"])	
			    unit.Host_MajorBearNO2=dr["Host_MajorBearNO2"].ToString();
			if (DBNull.Value != dr["Host_MajorBearNO3"])	
			    unit.Host_MajorBearNO3=dr["Host_MajorBearNO3"].ToString();
			if (DBNull.Value != dr["Host_MajorBearNO4"])	
			    unit.Host_MajorBearNO4=dr["Host_MajorBearNO4"].ToString();
			if (DBNull.Value != dr["Host_MajorBearNO5"])	
			    unit.Host_MajorBearNO5=dr["Host_MajorBearNO5"].ToString();
			if (DBNull.Value != dr["Host_MajorBearNO6"])	
			    unit.Host_MajorBearNO6=dr["Host_MajorBearNO6"].ToString();
			if (DBNull.Value != dr["Host_MajorBearNO7"])	
			    unit.Host_MajorBearNO7=dr["Host_MajorBearNO7"].ToString();
			if (DBNull.Value != dr["Host_MajorBearNO8"])	
			    unit.Host_MajorBearNO8=dr["Host_MajorBearNO8"].ToString();
			if (DBNull.Value != dr["Host_MajorBearNO9"])	
			    unit.Host_MajorBearNO9=dr["Host_MajorBearNO9"].ToString();
			if (DBNull.Value != dr["Host_HighPreesurePumpNO1"])	
			    unit.Host_HighPreesurePumpNO1=dr["Host_HighPreesurePumpNO1"].ToString();
			if (DBNull.Value != dr["Host_HighPreesurePumpNO2"])	
			    unit.Host_HighPreesurePumpNO2=dr["Host_HighPreesurePumpNO2"].ToString();
			if (DBNull.Value != dr["Host_HighPreesurePumpNO3"])	
			    unit.Host_HighPreesurePumpNO3=dr["Host_HighPreesurePumpNO3"].ToString();
			if (DBNull.Value != dr["Host_HighPreesurePumpNO4"])	
			    unit.Host_HighPreesurePumpNO4=dr["Host_HighPreesurePumpNO4"].ToString();
			if (DBNull.Value != dr["Host_HighPreesurePumpNO5"])	
			    unit.Host_HighPreesurePumpNO5=dr["Host_HighPreesurePumpNO5"].ToString();
			if (DBNull.Value != dr["Host_HighPreesurePumpNO6"])	
			    unit.Host_HighPreesurePumpNO6=dr["Host_HighPreesurePumpNO6"].ToString();
			if (DBNull.Value != dr["Host_HighPreesurePumpNO7"])	
			    unit.Host_HighPreesurePumpNO7=dr["Host_HighPreesurePumpNO7"].ToString();
			if (DBNull.Value != dr["Host_HighPreesurePumpNO8"])	
			    unit.Host_HighPreesurePumpNO8=dr["Host_HighPreesurePumpNO8"].ToString();
			if (DBNull.Value != dr["Host_HighPreesurePumpNO9"])	
			    unit.Host_HighPreesurePumpNO9=dr["Host_HighPreesurePumpNO9"].ToString();
			if (DBNull.Value != dr["Gas_DismantNO1"])	
			    unit.Gas_DismantNO1=dr["Gas_DismantNO1"].ToString();
			if (DBNull.Value != dr["Gas_DismantNO2"])	
			    unit.Gas_DismantNO2=dr["Gas_DismantNO2"].ToString();
			if (DBNull.Value != dr["Gas_MarblePanelNO1"])	
			    unit.Gas_MarblePanelNO1=dr["Gas_MarblePanelNO1"].ToString();
			if (DBNull.Value != dr["Gas_MarblePanelNO2"])	
			    unit.Gas_MarblePanelNO2=dr["Gas_MarblePanelNO2"].ToString();
			if (DBNull.Value != dr["Gas_AirCoolerNO1"])	
			    unit.Gas_AirCoolerNO1=dr["Gas_AirCoolerNO1"].ToString();
			if (DBNull.Value != dr["Gas_AirCoolerNO2"])	
			    unit.Gas_AirCoolerNO2=dr["Gas_AirCoolerNO2"].ToString();
			if (DBNull.Value != dr["Gas_STotalNO1"])	
			    unit.Gas_STotalNO1=dr["Gas_STotalNO1"].ToString();
			if (DBNull.Value != dr["Gas_STotalNO2"])	
			    unit.Gas_STotalNO2=dr["Gas_STotalNO2"].ToString();
			if (DBNull.Value != dr["Gas_STotalNO3"])	
			    unit.Gas_STotalNO3=dr["Gas_STotalNO3"].ToString();
			if (DBNull.Value != dr["Gas_SLiftingCylinderNO1"])	
			    unit.Gas_SLiftingCylinderNO1=dr["Gas_SLiftingCylinderNO1"].ToString();
			if (DBNull.Value != dr["Gas_SLiftingCylinderNO2"])	
			    unit.Gas_SLiftingCylinderNO2=dr["Gas_SLiftingCylinderNO2"].ToString();
			if (DBNull.Value != dr["Gas_SLiftingCylinderNO3"])	
			    unit.Gas_SLiftingCylinderNO3=dr["Gas_SLiftingCylinderNO3"].ToString();
			if (DBNull.Value != dr["Gas_SExhaustExchangeNO1"])	
			    unit.Gas_SExhaustExchangeNO1=dr["Gas_SExhaustExchangeNO1"].ToString();
			if (DBNull.Value != dr["Gas_SExhaustExchangeNO2"])	
			    unit.Gas_SExhaustExchangeNO2=dr["Gas_SExhaustExchangeNO2"].ToString();
			if (DBNull.Value != dr["Gas_SExhaustExchangeNO3"])	
			    unit.Gas_SExhaustExchangeNO3=dr["Gas_SExhaustExchangeNO3"].ToString();
			if (DBNull.Value != dr["Gas_SOilHeadNO1"])	
			    unit.Gas_SOilHeadNO1=dr["Gas_SOilHeadNO1"].ToString();
			if (DBNull.Value != dr["Gas_SOilHeadNO2"])	
			    unit.Gas_SOilHeadNO2=dr["Gas_SOilHeadNO2"].ToString();
			if (DBNull.Value != dr["Gas_SOilHeadNO3"])	
			    unit.Gas_SOilHeadNO3=dr["Gas_SOilHeadNO3"].ToString();
			if (DBNull.Value != dr["Gas_SMajorBearNO1"])	
			    unit.Gas_SMajorBearNO1=dr["Gas_SMajorBearNO1"].ToString();
			if (DBNull.Value != dr["Gas_SMajorBearNO2"])	
			    unit.Gas_SMajorBearNO2=dr["Gas_SMajorBearNO2"].ToString();
			if (DBNull.Value != dr["Gas_SMajorBearNO3"])	
			    unit.Gas_SMajorBearNO3=dr["Gas_SMajorBearNO3"].ToString();
			if (DBNull.Value != dr["Gas_STurbochargerNO1"])	
			    unit.Gas_STurbochargerNO1=dr["Gas_STurbochargerNO1"].ToString();
			if (DBNull.Value != dr["Gas_STurbochargerNO2"])	
			    unit.Gas_STurbochargerNO2=dr["Gas_STurbochargerNO2"].ToString();
			if (DBNull.Value != dr["Gas_STurbochargerNO3"])	
			    unit.Gas_STurbochargerNO3=dr["Gas_STurbochargerNO3"].ToString();
			if (DBNull.Value != dr["Gas_ACTotalNO1"])	
			    unit.Gas_ACTotalNO1=dr["Gas_ACTotalNO1"].ToString();
			if (DBNull.Value != dr["Gas_ACTotalNO2"])	
			    unit.Gas_ACTotalNO2=dr["Gas_ACTotalNO2"].ToString();
			if (DBNull.Value != dr["Gas_ACTotalNO3"])	
			    unit.Gas_ACTotalNO3=dr["Gas_ACTotalNO3"].ToString();
			if (DBNull.Value != dr["Gas_ACliftingCylinderNO1"])	
			    unit.Gas_ACliftingCylinderNO1=dr["Gas_ACliftingCylinderNO1"].ToString();
			if (DBNull.Value != dr["Gas_ACliftingCylinderNO2"])	
			    unit.Gas_ACliftingCylinderNO2=dr["Gas_ACliftingCylinderNO2"].ToString();
			if (DBNull.Value != dr["Gas_ACliftingCylinderNO3"])	
			    unit.Gas_ACliftingCylinderNO3=dr["Gas_ACliftingCylinderNO3"].ToString();
			if (DBNull.Value != dr["Gas_PPTotalNO1"])	
			    unit.Gas_PPTotalNO1=dr["Gas_PPTotalNO1"].ToString();
			if (DBNull.Value != dr["Gas_PPTotalNO2"])	
			    unit.Gas_PPTotalNO2=dr["Gas_PPTotalNO2"].ToString();
			if (DBNull.Value != dr["Gas_PPCheckNO1"])	
			    unit.Gas_PPCheckNO1=dr["Gas_PPCheckNO1"].ToString();
			if (DBNull.Value != dr["Gas_PPCheckNO2"])	
			    unit.Gas_PPCheckNO2=dr["Gas_PPCheckNO2"].ToString();
			if (DBNull.Value != dr["Gas_Remarks"])	
			    unit.Gas_Remarks=dr["Gas_Remarks"].ToString();
			if (DBNull.Value != dr["ChiefSign"])	
			    unit.ChiefSign=dr["ChiefSign"].ToString();
			if (DBNull.Value != dr["Pump_MainSeaTotalNO1"])	
			    unit.Pump_MainSeaTotalNO1=dr["Pump_MainSeaTotalNO1"].ToString();
			if (DBNull.Value != dr["Pump_MainSeaTotalNO2"])	
			    unit.Pump_MainSeaTotalNO2=dr["Pump_MainSeaTotalNO2"].ToString();
			if (DBNull.Value != dr["Pump_MainSeaDisintegrationNO1"])	
			    unit.Pump_MainSeaDisintegrationNO1=dr["Pump_MainSeaDisintegrationNO1"].ToString();
			if (DBNull.Value != dr["Pump_MainSeaDisintegrationNO2"])	
			    unit.Pump_MainSeaDisintegrationNO2=dr["Pump_MainSeaDisintegrationNO2"].ToString();
			if (DBNull.Value != dr["Pump_SecondSeaTotal"])	
			    unit.Pump_SecondSeaTotal=dr["Pump_SecondSeaTotal"].ToString();
			if (DBNull.Value != dr["Pump_SecondSeaDisintegration"])	
			    unit.Pump_SecondSeaDisintegration=dr["Pump_SecondSeaDisintegration"].ToString();
			if (DBNull.Value != dr["Pump_CylinderTotalNO1"])	
			    unit.Pump_CylinderTotalNO1=dr["Pump_CylinderTotalNO1"].ToString();
			if (DBNull.Value != dr["Pump_CylinderTotalNO2"])	
			    unit.Pump_CylinderTotalNO2=dr["Pump_CylinderTotalNO2"].ToString();
			if (DBNull.Value != dr["Pump_CylinderDisintegrationNO1"])	
			    unit.Pump_CylinderDisintegrationNO1=dr["Pump_CylinderDisintegrationNO1"].ToString();
			if (DBNull.Value != dr["Pump_CylinderDisintegrationNO2"])	
			    unit.Pump_CylinderDisintegrationNO2=dr["Pump_CylinderDisintegrationNO2"].ToString();
			if (DBNull.Value != dr["Pump_LowTemTotalNO1"])	
			    unit.Pump_LowTemTotalNO1=dr["Pump_LowTemTotalNO1"].ToString();
			if (DBNull.Value != dr["Pump_LowTemTotalNO2"])	
			    unit.Pump_LowTemTotalNO2=dr["Pump_LowTemTotalNO2"].ToString();
			if (DBNull.Value != dr["Pump_LowTemDisintegrationNO1"])	
			    unit.Pump_LowTemDisintegrationNO1=dr["Pump_LowTemDisintegrationNO1"].ToString();
			if (DBNull.Value != dr["Pump_LowTemDisintegrationNO2"])	
			    unit.Pump_LowTemDisintegrationNO2=dr["Pump_LowTemDisintegrationNO2"].ToString();
			if (DBNull.Value != dr["Pump_ParkLowTemTotal"])	
			    unit.Pump_ParkLowTemTotal=dr["Pump_ParkLowTemTotal"].ToString();
			if (DBNull.Value != dr["Pump_ParkLowTemDisintegration"])	
			    unit.Pump_ParkLowTemDisintegration=dr["Pump_ParkLowTemDisintegration"].ToString();
			if (DBNull.Value != dr["Pump_MainOilTotalNO1"])	
			    unit.Pump_MainOilTotalNO1=dr["Pump_MainOilTotalNO1"].ToString();
			if (DBNull.Value != dr["Pump_MainOilTotalNO2"])	
			    unit.Pump_MainOilTotalNO2=dr["Pump_MainOilTotalNO2"].ToString();
			if (DBNull.Value != dr["Pump_MainOilDisintegrationNO1"])	
			    unit.Pump_MainOilDisintegrationNO1=dr["Pump_MainOilDisintegrationNO1"].ToString();
			if (DBNull.Value != dr["Pump_MainOilDisintegrationNO2"])	
			    unit.Pump_MainOilDisintegrationNO2=dr["Pump_MainOilDisintegrationNO2"].ToString();
			if (DBNull.Value != dr["Pump_CamshaftOilTotalNO1"])	
			    unit.Pump_CamshaftOilTotalNO1=dr["Pump_CamshaftOilTotalNO1"].ToString();
			if (DBNull.Value != dr["Pump_CamshaftOilTotalNO2"])	
			    unit.Pump_CamshaftOilTotalNO2=dr["Pump_CamshaftOilTotalNO2"].ToString();
			if (DBNull.Value != dr["Pump_CamshaftOilDisintegrationNO1"])	
			    unit.Pump_CamshaftOilDisintegrationNO1=dr["Pump_CamshaftOilDisintegrationNO1"].ToString();
			if (DBNull.Value != dr["Pump_CamshaftOilDisintegrationNO2"])	
			    unit.Pump_CamshaftOilDisintegrationNO2=dr["Pump_CamshaftOilDisintegrationNO2"].ToString();
			if (DBNull.Value != dr["Pump_BoilerTotal"])	
			    unit.Pump_BoilerTotal=dr["Pump_BoilerTotal"].ToString();
			if (DBNull.Value != dr["Pump_BoilerDisintegration"])	
			    unit.Pump_BoilerDisintegration=dr["Pump_BoilerDisintegration"].ToString();
			if (DBNull.Value != dr["Pump_GeneralToatl"])	
			    unit.Pump_GeneralToatl=dr["Pump_GeneralToatl"].ToString();
			if (DBNull.Value != dr["Pump_GeneralDisintegration"])	
			    unit.Pump_GeneralDisintegration=dr["Pump_GeneralDisintegration"].ToString();
			if (DBNull.Value != dr["Pump_FireTotal"])	
			    unit.Pump_FireTotal=dr["Pump_FireTotal"].ToString();
			if (DBNull.Value != dr["Pump_FireDisintegration"])	
			    unit.Pump_FireDisintegration=dr["Pump_FireDisintegration"].ToString();
			if (DBNull.Value != dr["Pump_FuelCircleTotalNO1"])	
			    unit.Pump_FuelCircleTotalNO1=dr["Pump_FuelCircleTotalNO1"].ToString();
			if (DBNull.Value != dr["Pump_FuelCircleTotalNO2"])	
			    unit.Pump_FuelCircleTotalNO2=dr["Pump_FuelCircleTotalNO2"].ToString();
			if (DBNull.Value != dr["Pump_FuelCircleDisintegratinNO1"])	
			    unit.Pump_FuelCircleDisintegratinNO1=dr["Pump_FuelCircleDisintegratinNO1"].ToString();
			if (DBNull.Value != dr["Pump_FuelCircleDisintegratinNO2"])	
			    unit.Pump_FuelCircleDisintegratinNO2=dr["Pump_FuelCircleDisintegratinNO2"].ToString();
			if (DBNull.Value != dr["Pump_FuelPressureTotalNO1"])	
			    unit.Pump_FuelPressureTotalNO1=dr["Pump_FuelPressureTotalNO1"].ToString();
			if (DBNull.Value != dr["Pump_FuelPressureTotalNO2"])	
			    unit.Pump_FuelPressureTotalNO2=dr["Pump_FuelPressureTotalNO2"].ToString();
			if (DBNull.Value != dr["Pump_FuelPressureDisintegrationNO1"])	
			    unit.Pump_FuelPressureDisintegrationNO1=dr["Pump_FuelPressureDisintegrationNO1"].ToString();
			if (DBNull.Value != dr["Pump_FuelPressureDisintegrationNO2"])	
			    unit.Pump_FuelPressureDisintegrationNO2=dr["Pump_FuelPressureDisintegrationNO2"].ToString();
			if (DBNull.Value != dr["Pump_HeavyOilTotalNO1"])	
			    unit.Pump_HeavyOilTotalNO1=dr["Pump_HeavyOilTotalNO1"].ToString();
			if (DBNull.Value != dr["Pump_HeavyOilTotalNO2"])	
			    unit.Pump_HeavyOilTotalNO2=dr["Pump_HeavyOilTotalNO2"].ToString();
			if (DBNull.Value != dr["Pump_HeavyOilDisintegrationNO1"])	
			    unit.Pump_HeavyOilDisintegrationNO1=dr["Pump_HeavyOilDisintegrationNO1"].ToString();
			if (DBNull.Value != dr["Pump_HeavyOilDisintegrationNO2"])	
			    unit.Pump_HeavyOilDisintegrationNO2=dr["Pump_HeavyOilDisintegrationNO2"].ToString();
			if (DBNull.Value != dr["Pump_DieselFuelTotal"])	
			    unit.Pump_DieselFuelTotal=dr["Pump_DieselFuelTotal"].ToString();
			if (DBNull.Value != dr["Pump_DieselFuelDisintegration"])	
			    unit.Pump_DieselFuelDisintegration=dr["Pump_DieselFuelDisintegration"].ToString();
			if (DBNull.Value != dr["Pump_OilTotalNO1"])	
			    unit.Pump_OilTotalNO1=dr["Pump_OilTotalNO1"].ToString();
			if (DBNull.Value != dr["Pump_OilTotalNO2"])	
			    unit.Pump_OilTotalNO2=dr["Pump_OilTotalNO2"].ToString();
			if (DBNull.Value != dr["Pump_OilDisintegrationNO1"])	
			    unit.Pump_OilDisintegrationNO1=dr["Pump_OilDisintegrationNO1"].ToString();
			if (DBNull.Value != dr["Pump_OilDisintegrationNO2"])	
			    unit.Pump_OilDisintegrationNO2=dr["Pump_OilDisintegrationNO2"].ToString();
			if (DBNull.Value != dr["Pump_BallastTotalNO1"])	
			    unit.Pump_BallastTotalNO1=dr["Pump_BallastTotalNO1"].ToString();
			if (DBNull.Value != dr["Pump_BallastTotalNO2"])	
			    unit.Pump_BallastTotalNO2=dr["Pump_BallastTotalNO2"].ToString();
			if (DBNull.Value != dr["Pump_BallastDisintegrationNO1"])	
			    unit.Pump_BallastDisintegrationNO1=dr["Pump_BallastDisintegrationNO1"].ToString();
			if (DBNull.Value != dr["Pump_BallastDisintegrationNO2"])	
			    unit.Pump_BallastDisintegrationNO2=dr["Pump_BallastDisintegrationNO2"].ToString();
			if (DBNull.Value != dr["Pump_EmergencyTotal"])	
			    unit.Pump_EmergencyTotal=dr["Pump_EmergencyTotal"].ToString();
			if (DBNull.Value != dr["Pump_EmergencyDisintegration"])	
			    unit.Pump_EmergencyDisintegration=dr["Pump_EmergencyDisintegration"].ToString();
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个ReportMajorEquipment对象.
		/// </summary>
		/// <param name="report_MajorEquipTime_Id">report_MajorEquipTime_Id</param>
		/// <returns>ReportMajorEquipment对象</returns>
		public  ReportMajorEquipment getObject(string Id,out string err)
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
