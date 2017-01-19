/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：HOil.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-8-1
 * 标    题：实体类
 * 功能描述：T_HOIL数据实体类
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
	///T_HOIL数据实体.
	/// </summary>
	///[Serializable]
	public partial class HOil : CommonClass
	{		
		#region 构造函数
		///<summary> 
		///油品表.
		///</summary>
		public HOil()
		{
		}
		///<summary>
		///油品表.
		///</summary>
		public HOil
		(
			string oIL_ID,
			string tRADEMARK,
			string oIL_NAME,
			string oIL_CODE,
			string oIL_TYPE,
			string lOIL_TYPE,
			int oRDERNUM
		)
		{
			this.OIL_ID    = oIL_ID;
			this.TRADEMARK = tRADEMARK;
			this.OIL_NAME  = oIL_NAME;
			this.OIL_CODE  = oIL_CODE;
			this.OIL_TYPE  = oIL_TYPE;
			this.LOIL_TYPE = lOIL_TYPE;
			this.ORDERNUM  = oRDERNUM;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///ID
		///</summary>
		public string OIL_ID{get ;set;}

		///<summary>
		///牌号.
		///</summary>
		public string TRADEMARK{get ;set;}

		///<summary>
		///厂家.
		///</summary>
		public string OIL_NAME{get ;set;}

		///<summary>
		///油品编码，代码使用，不可修改，不可重复.
		///</summary>
		public string OIL_CODE{get ;set;}

		///<summary>
		///油品种类，0重油、1轻油、2滑油.
		///</summary>
		public string OIL_TYPE{get ;set;}

		///<summary>
		///润滑油种类，0主机气缸油、1主机系统油、2副机系统油、3其他.
		///</summary>
		public string LOIL_TYPE{get ;set;}

		///<summary>
		///排序号.
		///</summary>
		public int ORDERNUM{get ;set;}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public override CommonClass Clone()
		{
			HOil Unit = new HOil();
			Unit.OIL_ID=this.OIL_ID;
			Unit.TRADEMARK=this.TRADEMARK;
			Unit.OIL_NAME=this.OIL_NAME;
			Unit.OIL_CODE=this.OIL_CODE;
			Unit.OIL_TYPE=this.OIL_TYPE;
			Unit.LOIL_TYPE=this.LOIL_TYPE;
			Unit.ORDERNUM=this.ORDERNUM;
            return Unit;
		}
		#endregion
		
		public override string GetId()
        {
            return this.OIL_ID;
        }

        public override string GetTypeName()
        {
            return "HOil";
        }

        public override bool Update(out string err)
        {
            return HOilService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return HOilService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
