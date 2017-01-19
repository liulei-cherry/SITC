/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：HOilApplydetail.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-7-29
 * 标    题：实体类
 * 功能描述：T_HOIL_APPLY_DETAIL数据实体类
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
	///T_HOIL_APPLY_DETAIL数据实体.
	/// </summary>
	///[Serializable]
	public partial class HOilApplyDetail : CommonClass
	{		
		#region 构造函数
		///<summary> 
		///滑油申请明细.
		///</summary>
		public HOilApplyDetail()
		{
		}
		///<summary>
		///滑油申请明细.
		///</summary>
        public HOilApplyDetail
		(
			string aPPLY_DETAIL_ID,
			string aPPLY_ID,
			string oIL_ID,
			decimal nUM,
			string rEMARK,
			string cURRENCY_ID,
			decimal aMOUNT
		)
		{
			this.APPLY_DETAIL_ID = aPPLY_DETAIL_ID;
			this.APPLY_ID        = aPPLY_ID;
			this.OIL_ID          = oIL_ID;
			this.NUM             = nUM;
			this.REMARK          = rEMARK;
			this.CURRENCY_ID     = cURRENCY_ID;
			this.AMOUNT          = aMOUNT;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///ID
		///</summary>
		public string APPLY_DETAIL_ID{get ;set;}

		///<summary>
		///ID
		///</summary>
		public string APPLY_ID{get ;set;}

		///<summary>
		///滑油ID
		///</summary>
		public string OIL_ID{get ;set;}

		///<summary>
		///数量.
		///</summary>
		public decimal NUM{get ;set;}

		///<summary>
		///备注.
		///</summary>
		public string REMARK{get ;set;}

		///<summary>
		///币种.
		///</summary>
		public string CURRENCY_ID{get ;set;}

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
            HOilApplyDetail Unit = new HOilApplyDetail();
			Unit.APPLY_DETAIL_ID=this.APPLY_DETAIL_ID;
			Unit.APPLY_ID=this.APPLY_ID;
			Unit.OIL_ID=this.OIL_ID;
			Unit.NUM=this.NUM;
			Unit.REMARK=this.REMARK;
			Unit.CURRENCY_ID=this.CURRENCY_ID;
			Unit.AMOUNT=this.AMOUNT;
            return Unit;
		}
		#endregion
		
		public override string GetId()
        {
            return this.APPLY_DETAIL_ID;
        }

        public override string GetTypeName()
        {
            return "HOilApplydetail";
        }

        public override bool Update(out string err)
        {
            return HOilApplyDetailService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return HOilApplyDetailService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
