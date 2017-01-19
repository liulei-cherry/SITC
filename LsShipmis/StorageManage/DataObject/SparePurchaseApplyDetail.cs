/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：SparePurchaseApplyDetail.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/9/2
 * 标    题：实体类
 * 功能描述：T_SPARE_PURCHASE_APPLY_DETAIL数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using StorageManage.Services;

namespace StorageManage.DataObject
{
	/// <summary>
	///T_SPARE_PURCHASE_APPLY_DETAIL数据实体.
	/// </summary>
	///[Serializable]
	public partial class SparePurchaseApplyDetail : CommonClass
	{		
		#region 构造函数
		///<summary> 
		///
		///</summary>
		public SparePurchaseApplyDetail()
		{
		}
		///<summary>
		///
		///</summary>
		public SparePurchaseApplyDetail
		(
			string pURCHASE_APPLY_DETAIL_ID,
			string pURCHASE_APPLYID,
			string sPARE_ID,
			string sPARE_NAME,
			string pARTNUMBER,
			decimal aPPLYCOUNT,
			decimal cONFIRMEDCOUNT,
			string rEMARK,
			string cOMPONENT_UNIT_ID
		)
		{
			this.PURCHASE_APPLY_DETAIL_ID = pURCHASE_APPLY_DETAIL_ID;
			this.PURCHASE_APPLYID         = pURCHASE_APPLYID;
			this.SPARE_ID                 = sPARE_ID;
			this.SPARE_NAME               = sPARE_NAME;
			this.PARTNUMBER               = pARTNUMBER;
			this.APPLYCOUNT               = aPPLYCOUNT;
			this.CONFIRMEDCOUNT           = cONFIRMEDCOUNT;
			this.REMARK                   = rEMARK;
			this.COMPONENT_UNIT_ID        = cOMPONENT_UNIT_ID;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///
		///</summary>
		public string PURCHASE_APPLY_DETAIL_ID{get ;set;}

		///<summary>
		///主表id
		///</summary>
		public string PURCHASE_APPLYID{get ;set;}

		///<summary>
		///备件id
		///</summary>
		public string SPARE_ID{get ;set;}

		///<summary>
		///备件名称.
		///</summary>
		public string SPARE_NAME{get ;set;}

		///<summary>
		///采购号或规格.
		///</summary>
		public string PARTNUMBER{get ;set;}

		///<summary>
		///申请数量.
		///</summary>
		public decimal APPLYCOUNT{get ;set;}

		///<summary>
		///批准数量.
		///</summary>
		public decimal CONFIRMEDCOUNT{get ;set;}

		///<summary>
		///备注.
		///</summary>
		public string REMARK{get ;set;}

		///<summary>
		///设备id,当是子表可以存不同设备时此字段才有用.
		///</summary>
		public string COMPONENT_UNIT_ID{get ;set;}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public override CommonClass Clone()
		{
			SparePurchaseApplyDetail Unit = new SparePurchaseApplyDetail();
			Unit.PURCHASE_APPLY_DETAIL_ID=this.PURCHASE_APPLY_DETAIL_ID;
			Unit.PURCHASE_APPLYID=this.PURCHASE_APPLYID;
			Unit.SPARE_ID=this.SPARE_ID;
			Unit.SPARE_NAME=this.SPARE_NAME;
			Unit.PARTNUMBER=this.PARTNUMBER;
			Unit.APPLYCOUNT=this.APPLYCOUNT;
			Unit.CONFIRMEDCOUNT=this.CONFIRMEDCOUNT;
			Unit.REMARK=this.REMARK;
			Unit.COMPONENT_UNIT_ID=this.COMPONENT_UNIT_ID;
            return Unit;
		}
		#endregion
		
		public override string GetId()
        {
            return this.PURCHASE_APPLY_DETAIL_ID;
        }

        public override string GetTypeName()
        {
            return "SparePurchaseApplyDetail";
        }

        public override bool Update(out string err)
        {
            return SparePurchaseApplyDetailService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return SparePurchaseApplyDetailService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
