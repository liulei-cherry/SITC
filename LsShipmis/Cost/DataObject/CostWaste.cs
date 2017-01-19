/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：CostWaste.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-8-24
 * 标    题：实体类
 * 功能描述：T_COST_WASTE数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using Cost.Services;

namespace Cost.DataObject
{
	/// <summary>
	///T_COST_WASTE数据实体.
	/// </summary>
	///[Serializable]
	public partial class CostWaste : CommonClass
	{		
		#region 构造函数
		///<summary> 
		///废旧物资管理.
		///</summary>
		public CostWaste()
		{
		}
		///<summary>
		///废旧物资管理.
		///</summary>
		public CostWaste
		(
			string cOSTS_ID,
			string cLASS_ID,
			string dESCRIPTION,
			DateTime oCCURENCY_DATE,
			decimal eSTIMATE_AMOUNT,
			string sHIP_ID
		)
		{
			this.COSTS_ID        = cOSTS_ID;
			this.CLASS_ID        = cLASS_ID;
			this.DESCRIPTION     = dESCRIPTION;
			this.OCCURENCY_DATE  = oCCURENCY_DATE;
			this.ESTIMATE_AMOUNT = eSTIMATE_AMOUNT;
			this.SHIP_ID         = sHIP_ID;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///费用ID
		///</summary>
		public string COSTS_ID{get ;set;}

		///<summary>
		///ID
		///</summary>
		public string CLASS_ID{get ;set;}

		///<summary>
		///描述.
		///
		///</summary>
		public string DESCRIPTION{get ;set;}

		///<summary>
		///发生日期.
		///
		///</summary>
		public DateTime OCCURENCY_DATE{get ;set;}

		///<summary>
		///预估金额.
		///
		///</summary>
		public decimal ESTIMATE_AMOUNT{get ;set;}

		///<summary>
		///船舶.
		///</summary>
		public string SHIP_ID{get ;set;}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public override CommonClass Clone()
		{
			CostWaste Unit = new CostWaste();
			Unit.COSTS_ID=this.COSTS_ID;
			Unit.CLASS_ID=this.CLASS_ID;
			Unit.DESCRIPTION=this.DESCRIPTION;
			Unit.OCCURENCY_DATE=this.OCCURENCY_DATE;
			Unit.ESTIMATE_AMOUNT=this.ESTIMATE_AMOUNT;
			Unit.SHIP_ID=this.SHIP_ID;
            return Unit;
		}
		#endregion
		
		public override string GetId()
        {
            return this.COSTS_ID;
        }

        public override string GetTypeName()
        {
            return "CostWaste";
        }

        public override bool Update(out string err)
        {
            return CostWasteService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return CostWasteService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
