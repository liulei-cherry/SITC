/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：CostBudget.cs
 * 创 建 人：王鹏程
 * 创建时间：2012/3/21
 * 标    题：实体类
 * 功能描述：T_COST_BUDGET数据实体类
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
	///T_COST_BUDGET数据实体.
	/// </summary>
	///[Serializable]
	public partial class CostBudget : CommonClass
	{		
		#region 构造函数
		///<summary> 
		///预算管理，用于凭证审批并同步到SAP
		///</summary>
		public CostBudget()
		{
		}
		///<summary>
		///预算管理，用于凭证审批并同步到SAP
		///</summary>
		public CostBudget
		(
			string bUDGET_ID,
			int sTATE,
			DateTime cREATE_DATE,
			string aPPROVE_NUM,
			string rEMARK,
			decimal s_CNY_AMOUNT,
			decimal s_USD_AMOUNT,
			decimal s_EUR_AMOUNT,
			decimal s_JPY_AMOUNT,
			decimal y_CNY_AMOUNT,
			decimal y_USD_AMOUNT,
			decimal y_EUR_AMOUNT,
			decimal y_JPY_AMOUNT,
			decimal x_CNY_AMOUNT,
			decimal x_USD_AMOUNT,
			decimal x_EUR_AMOUNT,
			decimal x_JPY_AMOUNT
		)
		{
			this.BUDGET_ID    = bUDGET_ID;
			this.STATE        = sTATE;
			this.CREATE_DATE  = cREATE_DATE;
			this.APPROVE_NUM  = aPPROVE_NUM;
			this.REMARK       = rEMARK;
			this.S_CNY_AMOUNT = s_CNY_AMOUNT;
			this.S_USD_AMOUNT = s_USD_AMOUNT;
			this.S_EUR_AMOUNT = s_EUR_AMOUNT;
			this.S_JPY_AMOUNT = s_JPY_AMOUNT;
			this.Y_CNY_AMOUNT = y_CNY_AMOUNT;
			this.Y_USD_AMOUNT = y_USD_AMOUNT;
			this.Y_EUR_AMOUNT = y_EUR_AMOUNT;
			this.Y_JPY_AMOUNT = y_JPY_AMOUNT;
			this.X_CNY_AMOUNT = x_CNY_AMOUNT;
			this.X_USD_AMOUNT = x_USD_AMOUNT;
			this.X_EUR_AMOUNT = x_EUR_AMOUNT;
			this.X_JPY_AMOUNT = x_JPY_AMOUNT;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///ID
		///</summary>
		public string BUDGET_ID{get ;set;}

		///<summary>
        ///状态（1：未提交、2：审核中、3：被打回、4：审核完毕、5：同步SAP）.
		///</summary>
		public int STATE{get ;set;}

		///<summary>
		///提交日期.
		///</summary>
		public DateTime CREATE_DATE{get ;set;}

		///<summary>
		///审批号.
		///</summary>
		public string APPROVE_NUM{get ;set;}

		///<summary>
		///备注.
		///</summary>
		public string REMARK{get ;set;}

		///<summary>
		///上周末余额_人民币金额.
		///</summary>
		public decimal S_CNY_AMOUNT{get ;set;}

		///<summary>
		///上周末余额_美元金额.
		///
		///</summary>
		public decimal S_USD_AMOUNT{get ;set;}

		///<summary>
		///上周末余额_欧元金额.
		///
		///</summary>
		public decimal S_EUR_AMOUNT{get ;set;}

		///<summary>
		///上周末余额_日元金额.
		///
		///</summary>
		public decimal S_JPY_AMOUNT{get ;set;}

		///<summary>
		///已预算未付金额_人民币金额.
		///</summary>
		public decimal Y_CNY_AMOUNT{get ;set;}

		///<summary>
		///已预算未付金额_美元金额.
		///
		///</summary>
		public decimal Y_USD_AMOUNT{get ;set;}

		///<summary>
		///已预算未付金额_欧元金额.
		///
		///</summary>
		public decimal Y_EUR_AMOUNT{get ;set;}

		///<summary>
		///已预算未付金额_日元金额.
		///
		///</summary>
		public decimal Y_JPY_AMOUNT{get ;set;}

		///<summary>
		///下周预算金额_人民币金额.
		///</summary>
		public decimal X_CNY_AMOUNT{get ;set;}

		///<summary>
		///下周预算金额_美元金额.
		///
		///</summary>
		public decimal X_USD_AMOUNT{get ;set;}

		///<summary>
		///下周预算金额_欧元金额.
		///
		///</summary>
		public decimal X_EUR_AMOUNT{get ;set;}

		///<summary>
		///下周预算金额_日元金额.
		///
		///</summary>
		public decimal X_JPY_AMOUNT{get ;set;}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public override CommonClass Clone()
		{
			CostBudget Unit = new CostBudget();
			Unit.BUDGET_ID=this.BUDGET_ID;
			Unit.STATE=this.STATE;
			Unit.CREATE_DATE=this.CREATE_DATE;
			Unit.APPROVE_NUM=this.APPROVE_NUM;
			Unit.REMARK=this.REMARK;
			Unit.S_CNY_AMOUNT=this.S_CNY_AMOUNT;
			Unit.S_USD_AMOUNT=this.S_USD_AMOUNT;
			Unit.S_EUR_AMOUNT=this.S_EUR_AMOUNT;
			Unit.S_JPY_AMOUNT=this.S_JPY_AMOUNT;
			Unit.Y_CNY_AMOUNT=this.Y_CNY_AMOUNT;
			Unit.Y_USD_AMOUNT=this.Y_USD_AMOUNT;
			Unit.Y_EUR_AMOUNT=this.Y_EUR_AMOUNT;
			Unit.Y_JPY_AMOUNT=this.Y_JPY_AMOUNT;
			Unit.X_CNY_AMOUNT=this.X_CNY_AMOUNT;
			Unit.X_USD_AMOUNT=this.X_USD_AMOUNT;
			Unit.X_EUR_AMOUNT=this.X_EUR_AMOUNT;
			Unit.X_JPY_AMOUNT=this.X_JPY_AMOUNT;
            return Unit;
		}
		#endregion
		
		public override string GetId()
        {
            return this.BUDGET_ID;
        }

        public override string GetTypeName()
        {
            return "CostBudget";
        }

        public override bool Update(out string err)
        {
            return CostBudgetService.Instance.saveUnit(this, out err);
        }
        
        public string Update()
        {
            return CostBudgetService.Instance.saveUnit(this);
        }
        
        public override bool Delete(out string err)
        {
            return CostBudgetService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
