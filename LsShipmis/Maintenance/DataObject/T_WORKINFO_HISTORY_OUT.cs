/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：T_WORKINFO_HISTORY_OUT.cs
 * 创 建 人：黄家龙
 * 创建时间：2011/11/7
 * 标    题：实体类
 * 功能描述：T_WORKINFO_HISTORY_OUT数据实体类
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
	///T_WORKINFO_HISTORY_OUT数据实体.
	/// </summary>
	///[Serializable]
	public partial class T_WORKINFO_HISTORY_OUT : CommonClass
	{		
		#region 构造函数
		///<summary> 
		///维护保养工作信息历史和表格输出表.
		///</summary>
		public T_WORKINFO_HISTORY_OUT()
		{
		}
		///<summary>
		///维护保养工作信息历史和表格输出表.
		///</summary>
		public T_WORKINFO_HISTORY_OUT
		(
			string wHID,
			string sHIP_ID,
			DateTime aNNUAL,
			int rEPROT_TYPE,
			string wORKID,
			string oRDERNUM_SHOW,
			string cLASS1,
			string cLASS2,
			string mONTHS_CHECK,
			string eX1,
			string eX2,
			string eX3,
			string eX4,
			string eX5,
			string iTEMTYPE,
			int eXCEL_ORDERNUM
		)
		{
			this.WHID           = wHID;
			this.SHIP_ID        = sHIP_ID;
			this.ANNUAL         = aNNUAL;
			this.REPROT_TYPE    = rEPROT_TYPE;
			this.WORKID         = wORKID;
			this.ORDERNUM_SHOW  = oRDERNUM_SHOW;
			this.CLASS1         = cLASS1;
			this.CLASS2         = cLASS2;
			this.MONTHS_CHECK   = mONTHS_CHECK;
			this.EX1            = eX1;
			this.EX2            = eX2;
			this.EX3            = eX3;
			this.EX4            = eX4;
			this.EX5            = eX5;
			this.ITEMTYPE       = iTEMTYPE;
			this.EXCEL_ORDERNUM = eXCEL_ORDERNUM;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///
		///</summary>
		public string WHID{get ;set;}

		///<summary>
		///船舶ID
		///</summary>
		public string SHIP_ID{get ;set;}

		///<summary>
		///年度.
		///</summary>
		public DateTime ANNUAL{get ;set;}

		///<summary>
		///报表类型（1：甲板类型；2：轮机类型）.
		///</summary>
		public int REPROT_TYPE{get ;set;}

		///<summary>
		///工作信息ID
		///</summary>
		public string WORKID{get ;set;}

		///<summary>
		///显示排序号.
		///</summary>
		public string ORDERNUM_SHOW{get ;set;}

		///<summary>
		///一级分类.
		///</summary>
		public string CLASS1{get ;set;}

		///<summary>
		///二级分类.
		///</summary>
		public string CLASS2{get ;set;}

		///<summary>
		///月保养勾选.
		///</summary>
		public string MONTHS_CHECK{get ;set;}

		///<summary>
		///扩展项1
		///</summary>
		public string EX1{get ;set;}

		///<summary>
		///扩展项2
		///</summary>
		public string EX2{get ;set;}

		///<summary>
		///扩展项3
		///</summary>
		public string EX3{get ;set;}

		///<summary>
		///扩展项4
		///</summary>
		public string EX4{get ;set;}

		///<summary>
		///扩展项5
		///</summary>
		public string EX5{get ;set;}

		///<summary>
		///
		///</summary>
		public string ITEMTYPE{get ;set;}

		///<summary>
		///
		///</summary>
		public int EXCEL_ORDERNUM{get ;set;}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public override CommonClass Clone()
		{
			T_WORKINFO_HISTORY_OUT Unit = new T_WORKINFO_HISTORY_OUT();
			Unit.WHID=this.WHID;
			Unit.SHIP_ID=this.SHIP_ID;
			Unit.ANNUAL=this.ANNUAL;
			Unit.REPROT_TYPE=this.REPROT_TYPE;
			Unit.WORKID=this.WORKID;
			Unit.ORDERNUM_SHOW=this.ORDERNUM_SHOW;
			Unit.CLASS1=this.CLASS1;
			Unit.CLASS2=this.CLASS2;
			Unit.MONTHS_CHECK=this.MONTHS_CHECK;
			Unit.EX1=this.EX1;
			Unit.EX2=this.EX2;
			Unit.EX3=this.EX3;
			Unit.EX4=this.EX4;
			Unit.EX5=this.EX5;
			Unit.ITEMTYPE=this.ITEMTYPE;
			Unit.EXCEL_ORDERNUM=this.EXCEL_ORDERNUM;
            return Unit;
		}
		#endregion
		
		public override string GetId()
        {
            return this.WHID;
        }

        public override string GetTypeName()
        {
            return "T_WORKINFO_HISTORY_OUT";
        }

        public override bool Update(out string err)
        {
            return T_WORKINFO_HISTORY_OUTService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return T_WORKINFO_HISTORY_OUTService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
