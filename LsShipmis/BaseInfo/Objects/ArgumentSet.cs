/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：ArgumentSet.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-7-27
 * 标    题：实体类
 * 功能描述：T_ARGUMENT_SET数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using BaseInfo.DataAccess;

namespace BaseInfo.Objects
{
	/// <summary>
	///T_ARGUMENT_SET数据实体.
	/// </summary>
	///[Serializable]
	public partial class ArgumentSet : CommonClass
	{		
		#region 构造函数
		///<summary> 
		///系统全局性参数的设置.
		///</summary>
		public ArgumentSet()
		{
		}
		///<summary>
		///系统全局性参数的设置.
		///</summary>
		public ArgumentSet
		(
			string sYS_ID,
			string cODE,
			string cODE_VALUE,
			string iNTRO
		)
		{
			this.SYS_ID     = sYS_ID;
			this.CODE       = cODE;
			this.CODE_VALUE = cODE_VALUE;
			this.INTRO      = iNTRO;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///ID
		///</summary>
		public string SYS_ID{get ;set;}

		///<summary>
		///编码.
		///</summary>
		public string CODE{get ;set;}

		///<summary>
		///编码值.
		///</summary>
		public string CODE_VALUE{get ;set;}

		///<summary>
		///介绍说明.
		///</summary>
		public string INTRO{get ;set;}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public override CommonClass Clone()
		{
			ArgumentSet Unit = new ArgumentSet();
			Unit.SYS_ID=this.SYS_ID;
			Unit.CODE=this.CODE;
			Unit.CODE_VALUE=this.CODE_VALUE;
			Unit.INTRO=this.INTRO;
            return Unit;
		}
		#endregion
		
		public override string GetId()
        {
            return this.SYS_ID;
        }

        public override string GetTypeName()
        {
            return "ArgumentSet";
        }

        public override bool Update(out string err)
        {
            return ArgumentSetService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return ArgumentSetService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
