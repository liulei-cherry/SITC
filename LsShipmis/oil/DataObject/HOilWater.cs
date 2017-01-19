/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：HOilWater.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-7-25
 * 标    题：实体类
 * 功能描述：T_HOIL_WATER数据实体类
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
	///T_HOIL_WATER数据实体.
	/// </summary>
	///[Serializable]
	public partial class HOilWater : CommonClass
	{		
		#region 构造函数
		///<summary> 
		///淡水管理.
		///</summary>
		public HOilWater()
		{
		}
		///<summary>
		///淡水管理.
		///</summary>
		public HOilWater
		(
			string fUEL_ID,
			string sHIP_ID,
			string pORT_ID,
			DateTime aDD_DATE,
			decimal pRE_AMOUNT,
			decimal aDD_AMOUNT,
			string rEMARK
		)
		{
			this.FUEL_ID    = fUEL_ID;
			this.SHIP_ID    = sHIP_ID;
			this.PORT_ID    = pORT_ID;
			this.ADD_DATE   = aDD_DATE;
			this.PRE_AMOUNT = pRE_AMOUNT;
			this.ADD_AMOUNT = aDD_AMOUNT;
			this.REMARK     = rEMARK;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///ID
		///</summary>
		public string FUEL_ID{get ;set;}

		///<summary>
		///船舶ID
		///</summary>
		public string SHIP_ID{get ;set;}

		///<summary>
		///港口ID
		///</summary>
		public string PORT_ID{get ;set;}

		///<summary>
		///加水日期.
		///</summary>
		public DateTime ADD_DATE{get ;set;}

		///<summary>
		///加水前数量（单位：吨）.
		///</summary>
		public decimal PRE_AMOUNT{get ;set;}

		///<summary>
		///增加数量（单位：吨）.
		///</summary>
		public decimal ADD_AMOUNT{get ;set;}

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
			HOilWater Unit = new HOilWater();
			Unit.FUEL_ID=this.FUEL_ID;
			Unit.SHIP_ID=this.SHIP_ID;
			Unit.PORT_ID=this.PORT_ID;
			Unit.ADD_DATE=this.ADD_DATE;
			Unit.PRE_AMOUNT=this.PRE_AMOUNT;
			Unit.ADD_AMOUNT=this.ADD_AMOUNT;
			Unit.REMARK=this.REMARK;
            return Unit;
		}
		#endregion
		
		public override string GetId()
        {
            return this.FUEL_ID;
        }

        public override string GetTypeName()
        {
            return "HOilWater";
        }

        public override bool Update(out string err)
        {
            return HOilWaterService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return HOilWaterService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
