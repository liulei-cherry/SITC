/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：ReportCoolwater.cs
 * 创 建 人：黄家龙
 * 创建时间：2011/8/23
 * 标    题：实体类
 * 功能描述：T_REPORT_COOLWATER数据实体类
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
	///T_REPORT_COOLWATER数据实体.
	/// </summary>
	///[Serializable]
	public partial class ReportCoolwater : CommonClass
	{		
		#region 构造函数
		///<summary> 
		///冷却水化验及处理记录表.
		///</summary>
		public ReportCoolwater()
		{
		}
		///<summary>
		///冷却水化验及处理记录表.
		///</summary>
		public ReportCoolwater
		(
			string report_CoolWater_Id,
			string sHIP_ID,
			string file_ID,
			string medcine,
			string mainLinerConcentration,
			string mainLInerDosage,
			string mainPistonConcentration,
			string mainPistonDosage,
			string mainOilConcentration,
			string mainOilDosage,
			string secondConcentration,
			string secondDosage,
			DateTime experimentDealDate,
			string experimentDealSign,
			DateTime experimentDealSignDate,
			string chiefSign,
			DateTime chiefSignData
		)
		{
			this.Report_CoolWater_Id     = report_CoolWater_Id;
			this.SHIP_ID                 = sHIP_ID;
			this.File_ID                 = file_ID;
			this.Medcine                 = medcine;
			this.MainLinerConcentration  = mainLinerConcentration;
			this.MainLInerDosage         = mainLInerDosage;
			this.MainPistonConcentration = mainPistonConcentration;
			this.MainPistonDosage        = mainPistonDosage;
			this.MainOilConcentration    = mainOilConcentration;
			this.MainOilDosage           = mainOilDosage;
			this.SecondConcentration     = secondConcentration;
			this.SecondDosage            = secondDosage;
			this.ExperimentDealDate      = experimentDealDate;
			this.ExperimentDealSign      = experimentDealSign;
			this.ExperimentDealSignDate  = experimentDealSignDate;
			this.ChiefSign               = chiefSign;
			this.ChiefSignData           = chiefSignData;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///主键.
		///</summary>
		public string Report_CoolWater_Id{get ;set;}

		///<summary>
		///船舶ID
		///</summary>
		public string SHIP_ID{get ;set;}

		///<summary>
		///文件ID
		///</summary>
		public string File_ID{get ;set;}

		///<summary>
		///处理剂名称.
		///</summary>
		public string Medcine{get ;set;}

		///<summary>
		///主机缸套冷却水浓度.
		///</summary>
		public string MainLinerConcentration{get ;set;}

		///<summary>
		///主机缸套冷却水投药量.
		///</summary>
		public string MainLInerDosage{get ;set;}

		///<summary>
		///主机活塞冷却水浓度.
		///</summary>
		public string MainPistonConcentration{get ;set;}

		///<summary>
		///主机活塞冷却水投药量.
		///</summary>
		public string MainPistonDosage{get ;set;}

		///<summary>
		///主机油头冷却水浓度.
		///</summary>
		public string MainOilConcentration{get ;set;}

		///<summary>
		///主机油头冷却水投药量.
		///</summary>
		public string MainOilDosage{get ;set;}

		///<summary>
		///副机冷却水浓度.
		///</summary>
		public string SecondConcentration{get ;set;}

		///<summary>
		///副机冷却水投药量.
		///</summary>
		public string SecondDosage{get ;set;}

		///<summary>
		///化验及处理日期.
		///</summary>
		public DateTime ExperimentDealDate{get ;set;}

		///<summary>
		///化验及处理人签字.
		///</summary>
		public string ExperimentDealSign{get ;set;}

		///<summary>
		///化验及处理人签字日期.
		///</summary>
		public DateTime ExperimentDealSignDate{get ;set;}

		///<summary>
		///轮机长签名.
		///</summary>
		public string ChiefSign{get ;set;}

		///<summary>
		///轮机长签名日期.
		///</summary>
		public DateTime ChiefSignData{get ;set;}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public override CommonClass Clone()
		{
			ReportCoolwater Unit = new ReportCoolwater();
			Unit.Report_CoolWater_Id=this.Report_CoolWater_Id;
			Unit.SHIP_ID=this.SHIP_ID;
			Unit.File_ID=this.File_ID;
			Unit.Medcine=this.Medcine;
			Unit.MainLinerConcentration=this.MainLinerConcentration;
			Unit.MainLInerDosage=this.MainLInerDosage;
			Unit.MainPistonConcentration=this.MainPistonConcentration;
			Unit.MainPistonDosage=this.MainPistonDosage;
			Unit.MainOilConcentration=this.MainOilConcentration;
			Unit.MainOilDosage=this.MainOilDosage;
			Unit.SecondConcentration=this.SecondConcentration;
			Unit.SecondDosage=this.SecondDosage;
			Unit.ExperimentDealDate=this.ExperimentDealDate;
			Unit.ExperimentDealSign=this.ExperimentDealSign;
			Unit.ExperimentDealSignDate=this.ExperimentDealSignDate;
			Unit.ChiefSign=this.ChiefSign;
			Unit.ChiefSignData=this.ChiefSignData;
            return Unit;
		}
		#endregion
		
		public override string GetId()
        {
            return this.Report_CoolWater_Id;
        }

        public override string GetTypeName()
        {
            return "ReportCoolwater";
        }

        public override bool Update(out string err)
        {
            return ReportCoolwaterService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return ReportCoolwaterService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
