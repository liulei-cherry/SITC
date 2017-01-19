/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：Account.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-7-8
 * 标    题：实体类
 * 功能描述：T_COST_ACCOUNT数据实体类
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
	///T_COST_ACCOUNT数据实体.
	/// </summary>
	///[Serializable]
	public partial class Account : CommonClass
	{		
		#region 构造函数
		///<summary> 
		///费用科目的分类信息.
		///</summary>
		public Account()
		{
		}
		///<summary>
		///费用科目的分类信息.
		///</summary>
		public Account
		(
			string nODE_ID,
			string nODE_NAME,
			string pARENT_NODE_ID,
			string tOP_NODE_ID,
			string cODE,
			int oRDER_NUM
		)
		{
			this.NODE_ID        = nODE_ID;
			this.NODE_NAME      = nODE_NAME;
			this.PARENT_NODE_ID = pARENT_NODE_ID;
			this.TOP_NODE_ID    = tOP_NODE_ID;
			this.CODE           = cODE;
			this.ORDER_NUM      = oRDER_NUM;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///
		///</summary>
		public string NODE_ID{get ;set;}

		///<summary>
		///分类名称.
		///</summary>
		public string NODE_NAME{get ;set;}

		///<summary>
		///父节点ID
		///</summary>
		public string PARENT_NODE_ID{get ;set;}

		///<summary>
		///父节点ID
		///</summary>
		public string TOP_NODE_ID{get ;set;}

		///<summary>
		///编码.
		///</summary>
		public string CODE{get ;set;}

		///<summary>
		///
		///</summary>
		public int ORDER_NUM{get ;set;}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public override CommonClass Clone()
		{
			Account Unit = new Account();
			Unit.NODE_ID=this.NODE_ID;
			Unit.NODE_NAME=this.NODE_NAME;
			Unit.PARENT_NODE_ID=this.PARENT_NODE_ID;
			Unit.TOP_NODE_ID=this.TOP_NODE_ID;
			Unit.CODE=this.CODE;
			Unit.ORDER_NUM=this.ORDER_NUM;
            return Unit;
		}
		#endregion
		
		public override string GetId()
        {
            return this.NODE_ID;
        }

        public override string GetTypeName()
        {
            return "Account";
        }

        public override bool Update(out string err)
        {
            return AccountService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return AccountService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
