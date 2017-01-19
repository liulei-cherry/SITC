/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：HOilApply.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-7-29
 * 标    题：实体类
 * 功能描述：T_HOIL_APPLY数据实体类
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
	///T_HOIL_APPLY数据实体.
	/// </summary>
	///[Serializable]
	public partial class HOilApply : CommonClass
	{		
		#region 构造函数
		///<summary> 
		///滑油申请管理.
		///</summary>
		public HOilApply()
		{
		}
		///<summary>
		///滑油申请管理.
		///</summary>
		public HOilApply
		(
			string aPPLY_ID,
			string sHIP_ID,
			string pORT_ID,
			DateTime aPPLY_DATE,
			DateTime sUPPLY_DATE,
			string vOYAGE,
			string rEMARK,
			string aPPROVER,
			string aPPROVER2,
			decimal cHECKED
		)
		{
			this.APPLY_ID    = aPPLY_ID;
			this.SHIP_ID     = sHIP_ID;
			this.PORT_ID     = pORT_ID;
			this.APPLY_DATE  = aPPLY_DATE;
			this.SUPPLY_DATE = sUPPLY_DATE;
			this.VOYAGE      = vOYAGE;
			this.REMARK      = rEMARK;
			this.APPROVER    = aPPROVER;
			this.APPROVER2   = aPPROVER2;
			this.CHECKED     = cHECKED;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///ID
		///</summary>
		public string APPLY_ID{get ;set;}

		///<summary>
		///船舶ID
		///</summary>
		public string SHIP_ID{get ;set;}

		///<summary>
		///港口ID
		///</summary>
		public string PORT_ID{get ;set;}

		///<summary>
		///申请日期.
		///</summary>
		public DateTime APPLY_DATE{get ;set;}

		///<summary>
		///送船日期.
		///</summary>
		public DateTime SUPPLY_DATE{get ;set;}

		///<summary>
		///航次信息.
		///</summary>
		public string VOYAGE{get ;set;}

		///<summary>
		///备注.
		///</summary>
		public string REMARK{get ;set;}

		///<summary>
		///第一个批准人.
		///
		///
		///</summary>
		public string APPROVER{get ;set;}

		///<summary>
		///第二个批准人.
		///
		///
		///</summary>
		public string APPROVER2{get ;set;}

		///<summary>
        ///审核状态（0：未提交；1：审核中；2：已批准；9：已订购）.
		///</summary>
		public decimal CHECKED{get ;set;}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public override CommonClass Clone()
		{
			HOilApply Unit = new HOilApply();
			Unit.APPLY_ID=this.APPLY_ID;
			Unit.SHIP_ID=this.SHIP_ID;
			Unit.PORT_ID=this.PORT_ID;
			Unit.APPLY_DATE=this.APPLY_DATE;
			Unit.SUPPLY_DATE=this.SUPPLY_DATE;
			Unit.VOYAGE=this.VOYAGE;
			Unit.REMARK=this.REMARK;
			Unit.APPROVER=this.APPROVER;
			Unit.APPROVER2=this.APPROVER2;
			Unit.CHECKED=this.CHECKED;
            return Unit;
		}
		#endregion
		
		public override string GetId()
        {
            return this.APPLY_ID;
        }

        public override string GetTypeName()
        {
            return "HOilApply";
        }

        public override bool Update(out string err)
        {
            return HOilApplyService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return HOilApplyService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
