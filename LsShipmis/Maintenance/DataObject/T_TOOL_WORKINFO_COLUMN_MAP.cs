/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：T_TOOL_WORKINFO_COLUMN_MAP.cs
 * 创 建 人：黄家龙
 * 创建时间：2011/10/19
 * 标    题：实体类
 * 功能描述：T_TOOL_WORKINFO_COLUMN_MAP数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using Maintenance.Services;

namespace Maintenance.DataObject
{
	/// <summary>
	///T_TOOL_WORKINFO_COLUMN_MAP数据实体.
	/// </summary>
	///[Serializable]
	public partial class T_TOOL_WORKINFO_COLUMN_MAP : CommonClass
	{		
		#region 构造函数
		///<summary> 
		///到工作信息暂存表到工作信息列映射表.
		///</summary>
		public T_TOOL_WORKINFO_COLUMN_MAP()
		{
		}
		///<summary>
		///到工作信息暂存表到工作信息列映射表.
		///</summary>
		public T_TOOL_WORKINFO_COLUMN_MAP
		(
			string mAPID,
			string tOOL_COLUMN_NAME,
			string wORK_COLUMN_NAME,
			decimal mAPTYPE,
			int oRDER_NUM
		)
		{
			this.MAPID            = mAPID;
			this.TOOL_COLUMN_NAME = tOOL_COLUMN_NAME;
			this.WORK_COLUMN_NAME = wORK_COLUMN_NAME;
			this.MAPTYPE          = mAPTYPE;
			this.ORDER_NUM        = oRDER_NUM;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///ID
		///</summary>
		public string MAPID{get ;set;}

		///<summary>
		///工作暂存表列项名称.
		///</summary>
		public string TOOL_COLUMN_NAME{get ;set;}

		///<summary>
		///工作表列项名称.
		///</summary>
		public string WORK_COLUMN_NAME{get ;set;}

		///<summary>
		///映射类别（0工作信息；1输出表格）.
		///</summary>
		public decimal MAPTYPE{get ;set;}

		///<summary>
		///排序号.
		///</summary>
		public int ORDER_NUM{get ;set;}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public override CommonClass Clone()
		{
			T_TOOL_WORKINFO_COLUMN_MAP Unit = new T_TOOL_WORKINFO_COLUMN_MAP();
			Unit.MAPID=this.MAPID;
			Unit.TOOL_COLUMN_NAME=this.TOOL_COLUMN_NAME;
			Unit.WORK_COLUMN_NAME=this.WORK_COLUMN_NAME;
			Unit.MAPTYPE=this.MAPTYPE;
			Unit.ORDER_NUM=this.ORDER_NUM;
            return Unit;
		}
		#endregion
		
		public override string GetId()
        {
            return this.MAPID;
        }

        public override string GetTypeName()
        {
            return "T_TOOL_WORKINFO_COLUMN_MAP";
        }

        public override bool Update(out string err)
        {
            return T_TOOL_WORKINFO_COLUMN_MAPService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return T_TOOL_WORKINFO_COLUMN_MAPService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
