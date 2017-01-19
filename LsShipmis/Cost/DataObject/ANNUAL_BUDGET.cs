/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：ANNUAL_BUDGET.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-7-4
 * 标    题：实体类
 * 功能描述：T_COST_ANNUAL_BUDGET数据实体类
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
	///T_COST_ANNUAL_BUDGET数据实体.
	/// </summary>
	///[Serializable]
	public partial class ANNUAL_BUDGET : CommonClass
	{		
		#region 构造函数
		///<summary> 
		///科目年度预算.
		///</summary>
		public ANNUAL_BUDGET()
		{
		}
		///<summary>
		///科目年度预算.
		///</summary>
		public ANNUAL_BUDGET
		(
			string bUDGET_ID,
			string nODE_ID,
			DateTime yEAR_DATE,
			string sHIP_ID,
			decimal aMOUNT
		)
		{
			this.BUDGET_ID = bUDGET_ID;
			this.NODE_ID   = nODE_ID;
			this.YEAR_DATE = yEAR_DATE;
			this.SHIP_ID   = sHIP_ID;
			this.AMOUNT    = aMOUNT;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///预算ID
		///</summary>
		public string BUDGET_ID{get ;set;}

		///<summary>
		///
		///</summary>
		public string NODE_ID{get ;set;}

		///<summary>
		///年份.
		///</summary>
		public DateTime YEAR_DATE{get ;set;}

		///<summary>
		///船舶.
		///</summary>
		public string SHIP_ID{get ;set;}

		///<summary>
		///金额.
		///
		///</summary>
		public decimal AMOUNT{get ;set;}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public override CommonClass Clone()
		{
			ANNUAL_BUDGET Unit = new ANNUAL_BUDGET();
			Unit.BUDGET_ID=this.BUDGET_ID;
			Unit.NODE_ID=this.NODE_ID;
			Unit.YEAR_DATE=this.YEAR_DATE;
			Unit.SHIP_ID=this.SHIP_ID;
			Unit.AMOUNT=this.AMOUNT;
            return Unit;
		}
		#endregion
		
		public override string GetId()
        {
            return this.BUDGET_ID;
        }

        public override string GetTypeName()
        {
            return "ANNUAL_BUDGET";
        }

        public override bool Update(out string err)
        {
            return ANNUAL_BUDGETService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return ANNUAL_BUDGETService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
