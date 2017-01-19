/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：ReportBoilerwater.cs
 * 创 建 人：黄家龙
 * 创建时间：2011/8/19
 * 标    题：实体类
 * 功能描述：T_REPORT_BOILERWATER数据实体类
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
	///T_REPORT_BOILERWATER数据实体.
	/// </summary>
	///[Serializable]
	public partial class ReportBoilerwater : CommonClass
	{		
		#region 构造函数
		///<summary> 
		///锅炉水质处理.
		///</summary>
		public ReportBoilerwater()
		{
		}
		///<summary>
		///锅炉水质处理.
		///</summary>
		public ReportBoilerwater
		(
			string report_BoilerWater_Id,
			string file_ID,
			string sHIP_ID,
			string boilerCategory,
			string boilerAirPressure,
			string boilerWaterQuantity,
			DateTime fileDate,
			string phenolphthaleinAlkalinity,
			string saltAmount,
			string hardness,
			string pHValue,
			string sewageOnAmount,
			string sewageNextAmount,
			string medicine1,
			string medicine2,
			string medicine3,
			string medicine1Value,
			string medicine2Value,
			string medicine3Value,
			string condensateLevel,
			string condensateSilverNitrateDrops,
			string tankWaterLeverl,
			string tankWateSilverNitrateDrops,
			string remarks,
			string experimentOrHandlePersonName,
			string chiefEngineerName
		)
		{
			this.Report_BoilerWater_Id        = report_BoilerWater_Id;
			this.File_ID                      = file_ID;
			this.SHIP_ID                      = sHIP_ID;
			this.BoilerCategory               = boilerCategory;
			this.BoilerAirPressure            = boilerAirPressure;
			this.BoilerWaterQuantity          = boilerWaterQuantity;
			this.FileDate                     = fileDate;
			this.PhenolphthaleinAlkalinity    = phenolphthaleinAlkalinity;
			this.SaltAmount                   = saltAmount;
			this.Hardness                     = hardness;
			this.PHValue                      = pHValue;
			this.SewageOnAmount               = sewageOnAmount;
			this.SewageNextAmount             = sewageNextAmount;
			this.Medicine1                    = medicine1;
			this.Medicine2                    = medicine2;
			this.Medicine3                    = medicine3;
			this.Medicine1Value               = medicine1Value;
			this.Medicine2Value               = medicine2Value;
			this.Medicine3Value               = medicine3Value;
			this.CondensateLevel              = condensateLevel;
			this.CondensateSilverNitrateDrops = condensateSilverNitrateDrops;
			this.TankWaterLeverl              = tankWaterLeverl;
			this.TankWateSilverNitrateDrops   = tankWateSilverNitrateDrops;
			this.Remarks                      = remarks;
			this.ExperimentOrHandlePersonName = experimentOrHandlePersonName;
			this.ChiefEngineerName            = chiefEngineerName;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///记录编号.
		///</summary>
		public string Report_BoilerWater_Id{get ;set;}

		///<summary>
		///文件ID
		///</summary>
		public string File_ID{get ;set;}

		///<summary>
		///
		///</summary>
		public string SHIP_ID{get ;set;}

		///<summary>
		///锅炉分类.
		///</summary>
		public string BoilerCategory{get ;set;}

		///<summary>
		///锅炉气压.
		///</summary>
		public string BoilerAirPressure{get ;set;}

		///<summary>
		///炉水吨数.
		///</summary>
		public string BoilerWaterQuantity{get ;set;}

		///<summary>
		///年月日.
		///</summary>
		public DateTime FileDate{get ;set;}

		///<summary>
		///酚酞碱度C.C
		///</summary>
		public string PhenolphthaleinAlkalinity{get ;set;}

		///<summary>
		///含盐量C.C
		///</summary>
		public string SaltAmount{get ;set;}

		///<summary>
		///硬度.
		///</summary>
		public string Hardness{get ;set;}

		///<summary>
		///PH值.
		///</summary>
		public string PHValue{get ;set;}

		///<summary>
		///排污（上）水量（吨）.
		///</summary>
		public string SewageOnAmount{get ;set;}

		///<summary>
		///排污（下）水量吨.
		///</summary>
		public string SewageNextAmount{get ;set;}

		///<summary>
		///处理药剂名称1
		///</summary>
		public string Medicine1{get ;set;}

		///<summary>
		///处理药剂名称2
		///</summary>
		public string Medicine2{get ;set;}

		///<summary>
		///处理药剂名称3
		///</summary>
		public string Medicine3{get ;set;}

		///<summary>
		///处理药剂1投药量（千克/吨）.
		///</summary>
		public string Medicine1Value{get ;set;}

		///<summary>
		///处理药剂2投药量（千克/吨）.
		///</summary>
		public string Medicine2Value{get ;set;}

		///<summary>
		///处理药剂3投药量（千克/吨）.
		///</summary>
		public string Medicine3Value{get ;set;}

		///<summary>
		///凝结水.
		///</summary>
		public string CondensateLevel{get ;set;}

		///<summary>
		///凝结水硝酸银滴数C.C
		///</summary>
		public string CondensateSilverNitrateDrops{get ;set;}

		///<summary>
		///装水时水柜水.
		///</summary>
		public string TankWaterLeverl{get ;set;}

		///<summary>
		///装水时水柜水 硝酸银滴数C.C
		///</summary>
		public string TankWateSilverNitrateDrops{get ;set;}

		///<summary>
		///备注.
		///</summary>
		public string Remarks{get ;set;}

		///<summary>
		///试验及处理人姓名.
		///</summary>
		public string ExperimentOrHandlePersonName{get ;set;}

		///<summary>
		///轮机长.
		///</summary>
		public string ChiefEngineerName{get ;set;}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public override CommonClass Clone()
		{
			ReportBoilerwater Unit = new ReportBoilerwater();
			Unit.Report_BoilerWater_Id=this.Report_BoilerWater_Id;
			Unit.File_ID=this.File_ID;
			Unit.SHIP_ID=this.SHIP_ID;
			Unit.BoilerCategory=this.BoilerCategory;
			Unit.BoilerAirPressure=this.BoilerAirPressure;
			Unit.BoilerWaterQuantity=this.BoilerWaterQuantity;
			Unit.FileDate=this.FileDate;
			Unit.PhenolphthaleinAlkalinity=this.PhenolphthaleinAlkalinity;
			Unit.SaltAmount=this.SaltAmount;
			Unit.Hardness=this.Hardness;
			Unit.PHValue=this.PHValue;
			Unit.SewageOnAmount=this.SewageOnAmount;
			Unit.SewageNextAmount=this.SewageNextAmount;
			Unit.Medicine1=this.Medicine1;
			Unit.Medicine2=this.Medicine2;
			Unit.Medicine3=this.Medicine3;
			Unit.Medicine1Value=this.Medicine1Value;
			Unit.Medicine2Value=this.Medicine2Value;
			Unit.Medicine3Value=this.Medicine3Value;
			Unit.CondensateLevel=this.CondensateLevel;
			Unit.CondensateSilverNitrateDrops=this.CondensateSilverNitrateDrops;
			Unit.TankWaterLeverl=this.TankWaterLeverl;
			Unit.TankWateSilverNitrateDrops=this.TankWateSilverNitrateDrops;
			Unit.Remarks=this.Remarks;
			Unit.ExperimentOrHandlePersonName=this.ExperimentOrHandlePersonName;
			Unit.ChiefEngineerName=this.ChiefEngineerName;
            return Unit;
		}
		#endregion
		
		public override string GetId()
        {
            return this.Report_BoilerWater_Id;
        }

        public override string GetTypeName()
        {
            return "ReportBoilerwater";
        }

        public override bool Update(out string err)
        {
            return ReportBoilerwaterService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return ReportBoilerwaterService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
