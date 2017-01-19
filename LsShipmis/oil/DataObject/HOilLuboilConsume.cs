/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：HOilLuboilConsume.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-7-25
 * 标    题：实体类
 * 功能描述：T_HOIL_LUBOIL_CONSUME数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using Oil.Services;

namespace Oil.DataObject
{
	/// <summary>
	///T_HOIL_LUBOIL_CONSUME数据实体.
	/// </summary>
	///[Serializable]
	public partial class HOilLuboilConsume : CommonClass
	{		
		#region 构造函数
		///<summary> 
		///滑油月度增加消耗表.
		///</summary>
		public HOilLuboilConsume()
		{
		}
		///<summary>
		///滑油月度增加消耗表.
		///</summary>
		public HOilLuboilConsume
		(
			string rEPORT_ID,
			string sHIP_ID,
			string oIL_ID,
			decimal lASTMONTH_LEFT,
			decimal tHISMONTH_ADD,
			decimal tHISMONTH_CONSUME,
			decimal tHISMONTH_STORE,
			string rEMARK,
			DateTime rECORD_DATE
		)
		{
			this.REPORT_ID         = rEPORT_ID;
			this.SHIP_ID           = sHIP_ID;
			this.OIL_ID            = oIL_ID;
			this.LASTMONTH_LEFT    = lASTMONTH_LEFT;
			this.THISMONTH_ADD     = tHISMONTH_ADD;
			this.THISMONTH_CONSUME = tHISMONTH_CONSUME;
			this.THISMONTH_STORE   = tHISMONTH_STORE;
			this.REMARK            = rEMARK;
			this.RECORD_DATE       = rECORD_DATE;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///ID
		///</summary>
		public string REPORT_ID{get ;set;}

		///<summary>
		///船舶.
		///</summary>
		public string SHIP_ID{get ;set;}

		///<summary>
		///滑油ID
		///</summary>
		public string OIL_ID{get ;set;}

		///<summary>
		///上月库存.
		///</summary>
		public decimal LASTMONTH_LEFT{get ;set;}

		///<summary>
		///本月加油.
		///</summary>
		public decimal THISMONTH_ADD{get ;set;}

		///<summary>
		///本月消耗.
		///</summary>
		public decimal THISMONTH_CONSUME{get ;set;}

		///<summary>
		///本月库存.
		///</summary>
		public decimal THISMONTH_STORE{get ;set;}

		///<summary>
		///备注.
		///</summary>
		public string REMARK{get ;set;}

		///<summary>
		///记录的月份.
		///</summary>
		public DateTime RECORD_DATE{get ;set;}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public override CommonClass Clone()
		{
			HOilLuboilConsume Unit = new HOilLuboilConsume();
			Unit.REPORT_ID=this.REPORT_ID;
			Unit.SHIP_ID=this.SHIP_ID;
			Unit.OIL_ID=this.OIL_ID;
			Unit.LASTMONTH_LEFT=this.LASTMONTH_LEFT;
			Unit.THISMONTH_ADD=this.THISMONTH_ADD;
			Unit.THISMONTH_CONSUME=this.THISMONTH_CONSUME;
			Unit.THISMONTH_STORE=this.THISMONTH_STORE;
			Unit.REMARK=this.REMARK;
			Unit.RECORD_DATE=this.RECORD_DATE;
            return Unit;
		}
		#endregion
		
		public override string GetId()
        {
            return this.REPORT_ID;
        }

        public override string GetTypeName()
        {
            return "HOilLuboilConsume";
        }

        public override bool Update(out string err)
        {
            return HOilLuboilConsumeService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return HOilLuboilConsumeService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
