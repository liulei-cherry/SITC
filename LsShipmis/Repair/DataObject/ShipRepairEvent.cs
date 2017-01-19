/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：ShipRepairEvent.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/8/2
 * 标    题：实体类
 * 功能描述：T_SHIP_REPAIR_EVENT数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using Repair.Services;

namespace Repair.DataObject
{
	/// <summary>
	///T_SHIP_REPAIR_EVENT数据实体.
	/// </summary>
	///[Serializable]
	public partial class ShipRepairEvent : CommonClass
	{		
		#region 构造函数
		///<summary> 
		///所有修船主表,包含航修坞修等,
		///</summary>
		public ShipRepairEvent()
		{
		}
		///<summary>
		///所有修船主表,包含航修坞修等,
		///</summary>
		public ShipRepairEvent
		(
			string rEPAIRID,
			string rEPAIRCODE,
			string rEPAIRPORT,
			string sHIP_ID,
			decimal aRRANGED,
			string aRRANGEDPERSON,
			string sHIPAFFIRMANT,
			string cOMPAFFIRMANT,
			DateTime rEPAIRDATE,
			string sERVICEPROVIDER,
			DateTime cOMPLETEDATE,
			string rEMARK
		)
		{
			this.REPAIRID        = rEPAIRID;
			this.REPAIRCODE      = rEPAIRCODE;
			this.REPAIRPORT      = rEPAIRPORT;
			this.SHIP_ID         = sHIP_ID;
			this.ARRANGED        = aRRANGED;
			this.ARRANGEDPERSON  = aRRANGEDPERSON;
			this.SHIPAFFIRMANT   = sHIPAFFIRMANT;
			this.COMPAFFIRMANT   = cOMPAFFIRMANT;
			this.REPAIRDATE      = rEPAIRDATE;
			this.SERVICEPROVIDER = sERVICEPROVIDER;
			this.COMPLETEDATE    = cOMPLETEDATE;
			this.REMARK          = rEMARK;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///
		///</summary>
		public string REPAIRID{get ;set;}

		///<summary>
		///修理编号.
		///</summary>
		public string REPAIRCODE{get ;set;}

		///<summary>
		///修理港口(地点)
		///</summary>
		public string REPAIRPORT{get ;set;}

		///<summary>
		///船舶id
		///</summary>
		public string SHIP_ID{get ;set;}

		///<summary>
		///委托完成(0,未完成,1已完成)
		///</summary>
		public decimal ARRANGED{get ;set;}

		///<summary>
		///安排人.
		///</summary>
		public string ARRANGEDPERSON{get ;set;}

		///<summary>
		///完工船端确认人.
		///</summary>
		public string SHIPAFFIRMANT{get ;set;}

		///<summary>
		///完工岸端确认人.
		///</summary>
		public string COMPAFFIRMANT{get ;set;}

		///<summary>
		///修理开始日期.
		///</summary>
		public DateTime REPAIRDATE{get ;set;}

		///<summary>
		///服务商.
		///</summary>
		public string SERVICEPROVIDER{get ;set;}

		///<summary>
		///修理完成日期(默认与修理开始日期相同.
		///</summary>
		public DateTime COMPLETEDATE{get ;set;}

		///<summary>
		///备注.
		///</summary>
		public string REMARK{get ;set;}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public override CommonClass Clone()
		{
			ShipRepairEvent Unit = new ShipRepairEvent();
			Unit.REPAIRID=this.REPAIRID;
			Unit.REPAIRCODE=this.REPAIRCODE;
			Unit.REPAIRPORT=this.REPAIRPORT;
			Unit.SHIP_ID=this.SHIP_ID;
			Unit.ARRANGED=this.ARRANGED;
			Unit.ARRANGEDPERSON=this.ARRANGEDPERSON;
			Unit.SHIPAFFIRMANT=this.SHIPAFFIRMANT;
			Unit.COMPAFFIRMANT=this.COMPAFFIRMANT;
			Unit.REPAIRDATE=this.REPAIRDATE;
			Unit.SERVICEPROVIDER=this.SERVICEPROVIDER;
			Unit.COMPLETEDATE=this.COMPLETEDATE;
			Unit.REMARK=this.REMARK;
            return Unit;
		}
		#endregion
		
		public override string GetId()
        {
            return this.REPAIRID;
        }

        public override string GetTypeName()
        {
            return "ShipRepairEvent";
        }

        public override bool Update(out string err)
        {
            return ShipRepairEventService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return ShipRepairEventService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
