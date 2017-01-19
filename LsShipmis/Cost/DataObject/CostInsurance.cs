/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：CostInsurance.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-8-24
 * 标    题：实体类
 * 功能描述：T_COST_INSURANCE数据实体类
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
	///T_COST_INSURANCE数据实体.
	/// </summary>
	///[Serializable]
	public partial class CostInsurance : CommonClass
	{		
		#region 构造函数
		///<summary> 
		///保险费用管理.
		///</summary>
		public CostInsurance()
		{
		}
		///<summary>
		///保险费用管理.
		///</summary>
		public CostInsurance
		(
			string wASTE_ID,
			string dESCRIPTE,
			DateTime pOLICY_DATE,
			string sHIP_ID,
			string cURRENCY_ID,
			decimal pUBLIC_AMOUNT,
			DateTime pAY_DATE,
			decimal pAY_AMOUNT,
			int sTATIC,
			string iNSURANCE_COMPANY,
			string rEMARK
		)
		{
			this.WASTE_ID          = wASTE_ID;
			this.DESCRIPTE         = dESCRIPTE;
			this.POLICY_DATE       = pOLICY_DATE;
			this.SHIP_ID           = sHIP_ID;
			this.CURRENCY_ID       = cURRENCY_ID;
			this.PUBLIC_AMOUNT     = pUBLIC_AMOUNT;
			this.PAY_DATE          = pAY_DATE;
			this.PAY_AMOUNT        = pAY_AMOUNT;
			this.STATIC            = sTATIC;
			this.INSURANCE_COMPANY = iNSURANCE_COMPANY;
			this.REMARK            = rEMARK;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///ID
		///</summary>
		public string WASTE_ID{get ;set;}

		///<summary>
		///描述.
		///</summary>
		public string DESCRIPTE{get ;set;}

		///<summary>
		///保单理赔日期.
		///</summary>
		public DateTime POLICY_DATE{get ;set;}

		///<summary>
		///船舶.
		///</summary>
		public string SHIP_ID{get ;set;}

		///<summary>
		///币种ID
		///</summary>
		public string CURRENCY_ID{get ;set;}

		///<summary>
		///上报损失金额.
		///
		///</summary>
		public decimal PUBLIC_AMOUNT{get ;set;}

		///<summary>
		///赔款日期.
		///</summary>
		public DateTime PAY_DATE{get ;set;}

		///<summary>
		///赔款金额.
		///</summary>
		public decimal PAY_AMOUNT{get ;set;}

		///<summary>
		///保险状态（0：未提交、1：提交办理、2：已经理赔、3：拒绝理赔）.
		///</summary>
		public int STATIC{get ;set;}

		///<summary>
		///保险公司.
		///</summary>
		public string INSURANCE_COMPANY{get ;set;}

		///<summary>
		///
		///</summary>
		public string REMARK{get ;set;}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public override CommonClass Clone()
		{
			CostInsurance Unit = new CostInsurance();
			Unit.WASTE_ID=this.WASTE_ID;
			Unit.DESCRIPTE=this.DESCRIPTE;
			Unit.POLICY_DATE=this.POLICY_DATE;
			Unit.SHIP_ID=this.SHIP_ID;
			Unit.CURRENCY_ID=this.CURRENCY_ID;
			Unit.PUBLIC_AMOUNT=this.PUBLIC_AMOUNT;
			Unit.PAY_DATE=this.PAY_DATE;
			Unit.PAY_AMOUNT=this.PAY_AMOUNT;
			Unit.STATIC=this.STATIC;
			Unit.INSURANCE_COMPANY=this.INSURANCE_COMPANY;
			Unit.REMARK=this.REMARK;
            return Unit;
		}
		#endregion
		
		public override string GetId()
        {
            return this.WASTE_ID;
        }

        public override string GetTypeName()
        {
            return "CostInsurance";
        }

        public override bool Update(out string err)
        {
            return CostInsuranceService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return CostInsuranceService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
