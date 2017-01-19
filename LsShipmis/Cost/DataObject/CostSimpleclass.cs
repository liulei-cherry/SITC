/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：CostSimpleclass.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-8-24
 * 标    题：实体类
 * 功能描述：T_COST_SIMPLECLASS数据实体类
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
	///T_COST_SIMPLECLASS数据实体.
	/// </summary>
	///[Serializable]
	public partial class CostSimpleclass : CommonClass
	{		
		#region 构造函数
		///<summary> 
		///简单费用分类管理.
		///</summary>
		public CostSimpleclass()
		{
		}
		///<summary>
		///简单费用分类管理.
		///</summary>
		public CostSimpleclass
		(
			string cLASS_ID,
			string tYPE,
			string nAME
		)
		{
			this.CLASS_ID = cLASS_ID;
			this.TYPE     = tYPE;
			this.NAME     = nAME;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///ID
		///</summary>
		public string CLASS_ID{get ;set;}

		///<summary>
		///分类A：废旧物资；B：船舶费用.
		///</summary>
		public string TYPE{get ;set;}

		///<summary>
		///名称.
		///</summary>
		public string NAME{get ;set;}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public override CommonClass Clone()
		{
			CostSimpleclass Unit = new CostSimpleclass();
			Unit.CLASS_ID=this.CLASS_ID;
			Unit.TYPE=this.TYPE;
			Unit.NAME=this.NAME;
            return Unit;
		}
		#endregion
		
		public override string GetId()
        {
            return this.CLASS_ID;
        }

        public override string GetTypeName()
        {
            return "CostSimpleclass";
        }

        public override bool Update(out string err)
        {
            return CostSimpleclassService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return CostSimpleclassService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
