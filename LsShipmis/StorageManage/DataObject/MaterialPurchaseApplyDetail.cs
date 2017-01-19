/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：MaterialPurchaseApplyDetail.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/9/18
 * 标    题：实体类
 * 功能描述：T_MATERIAL_PURCHASE_APPLY_DETAIL数据实体类
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
	///T_MATERIAL_PURCHASE_APPLY_DETAIL数据实体.
	/// </summary>
	///[Serializable]
	public partial class MaterialPurchaseApplyDetail : CommonClass
	{		
		#region 构造函数
		///<summary> 
		///
		///</summary>
		public MaterialPurchaseApplyDetail()
		{
		}
		///<summary>
		///
		///</summary>
		public MaterialPurchaseApplyDetail
		(
			string pURCHASE_APPLY_DETAIL_ID,
			string pURCHASE_APPLYID,
			string mATERIAL_ID,
			string mATERIAL_NAME,
			string mATERIAL_CODE,
			string mATERIAL_SPEC,
			decimal aPPLYCOUNT,
			decimal cONFIRMEDCOUNT,
			string rEMARK,
            int oRDERNUM
		)
		{
			this.PURCHASE_APPLY_DETAIL_ID = pURCHASE_APPLY_DETAIL_ID;
			this.PURCHASE_APPLYID         = pURCHASE_APPLYID;
			this.MATERIAL_ID              = mATERIAL_ID;
			this.MATERIAL_NAME            = mATERIAL_NAME;
			this.MATERIAL_CODE            = mATERIAL_CODE;
			this.MATERIAL_SPEC            = mATERIAL_SPEC;
			this.APPLYCOUNT               = aPPLYCOUNT;
			this.CONFIRMEDCOUNT           = cONFIRMEDCOUNT;
			this.REMARK                   = rEMARK;
            this.ORDERNUM = oRDERNUM;
			
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
		public string MATERIAL_ID{get ;set;}

		///<summary>
		///备件名称.
		///</summary>
		public string MATERIAL_NAME{get ;set;}

		///<summary>
		///采购号或规格.
		///</summary>
		public string MATERIAL_CODE{get ;set;}

		///<summary>
		///备件名称.
		///</summary>
		public string MATERIAL_SPEC{get ;set;}

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
        ///序号
        ///</summary>
        public int ORDERNUM { get; set; }
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public override CommonClass Clone()
		{
			MaterialPurchaseApplyDetail Unit = new MaterialPurchaseApplyDetail();
			Unit.PURCHASE_APPLY_DETAIL_ID=this.PURCHASE_APPLY_DETAIL_ID;
			Unit.PURCHASE_APPLYID=this.PURCHASE_APPLYID;
			Unit.MATERIAL_ID=this.MATERIAL_ID;
			Unit.MATERIAL_NAME=this.MATERIAL_NAME;
			Unit.MATERIAL_CODE=this.MATERIAL_CODE;
			Unit.MATERIAL_SPEC=this.MATERIAL_SPEC;
			Unit.APPLYCOUNT=this.APPLYCOUNT;
			Unit.CONFIRMEDCOUNT=this.CONFIRMEDCOUNT;
			Unit.REMARK=this.REMARK;
            Unit.ORDERNUM = this.ORDERNUM;
            return Unit;
		}
		#endregion
		
		public override string GetId()
        {
            return this.PURCHASE_APPLY_DETAIL_ID;
        }

        public override string GetTypeName()
        {
            return "MaterialPurchaseApplyDetail";
        }

        public override bool Update(out string err)
        {
            return MaterialPurchaseApplyDetailService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return MaterialPurchaseApplyDetailService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
