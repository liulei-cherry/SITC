/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：HOilReport.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-8-19
 * 标    题：实体类
 * 功能描述：T_HOIL_REPORT数据实体类
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
	///T_HOIL_REPORT数据实体.
	/// </summary>
	///[Serializable]
	public partial class HOilReport : CommonClass
	{		
		#region 构造函数
		///<summary> 
		///燃、润油月度消耗报表.
		///</summary>
		public HOilReport()
		{
		}
		///<summary>
		///燃、润油月度消耗报表.
		///</summary>
		public HOilReport
		(
			string rEPORT_ID,
			string sHIP_ID,
			DateTime sTART_DATE,
			DateTime eND_DATE,
			DateTime rEPORT_DATE,
			string rEMARK,
			string w_SPECIFICATION,
			decimal wLEFT_AMOUNT,
			decimal w_SULPHUR,
			decimal w_DENSITY,
			string l_SPECIFICATION,
			decimal lLEFT_AMOUNT,
			decimal l_SULPHUR,
			decimal l_DENSITY,
			int sAIL_DAY,
			int sAIL_HOUR
		)
		{
			this.REPORT_ID       = rEPORT_ID;
			this.SHIP_ID         = sHIP_ID;
			this.START_DATE      = sTART_DATE;
			this.END_DATE        = eND_DATE;
			this.REPORT_DATE     = rEPORT_DATE;
			this.REMARK          = rEMARK;
			this.W_SPECIFICATION = w_SPECIFICATION;
			this.WLEFT_AMOUNT    = wLEFT_AMOUNT;
			this.W_SULPHUR       = w_SULPHUR;
			this.W_DENSITY       = w_DENSITY;
			this.L_SPECIFICATION = l_SPECIFICATION;
			this.LLEFT_AMOUNT    = lLEFT_AMOUNT;
			this.L_SULPHUR       = l_SULPHUR;
			this.L_DENSITY       = l_DENSITY;
			this.SAIL_DAY        = sAIL_DAY;
			this.SAIL_HOUR       = sAIL_HOUR;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///ID
		///</summary>
		public string REPORT_ID{get ;set;}

		///<summary>
		///船舶ID
		///</summary>
		public string SHIP_ID{get ;set;}

		///<summary>
		///起始日期.
		///</summary>
		public DateTime START_DATE{get ;set;}

		///<summary>
		///结束日期.
		///</summary>
		public DateTime END_DATE{get ;set;}

		///<summary>
		///报告日期.
		///</summary>
		public DateTime REPORT_DATE{get ;set;}

		///<summary>
		///备注.
		///</summary>
		public string REMARK{get ;set;}

		///<summary>
		///重油—规格.
		///</summary>
		public string W_SPECIFICATION{get ;set;}

		///<summary>
		///重油结存—数量（单位：吨）.
		///</summary>
		public decimal WLEFT_AMOUNT{get ;set;}

		///<summary>
		///重油—含硫量（%）.
		///</summary>
		public decimal W_SULPHUR{get ;set;}

		///<summary>
		///重油—比重（KG/L）.
		///</summary>
		public decimal W_DENSITY{get ;set;}

		///<summary>
		///轻油—规格.
		///</summary>
		public string L_SPECIFICATION{get ;set;}

		///<summary>
		///轻油结存—数量（单位：吨）.
		///</summary>
		public decimal LLEFT_AMOUNT{get ;set;}

		///<summary>
		///轻油—含硫量（%）.
		///</summary>
		public decimal L_SULPHUR{get ;set;}

		///<summary>
		///轻油—比重（KG/L）.
		///</summary>
		public decimal L_DENSITY{get ;set;}

		///<summary>
		///月航行天数.
		///</summary>
		public int SAIL_DAY{get ;set;}

		///<summary>
		///月航行小时.
		///</summary>
		public int SAIL_HOUR{get ;set;}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public override CommonClass Clone()
		{
			HOilReport Unit = new HOilReport();
			Unit.REPORT_ID=this.REPORT_ID;
			Unit.SHIP_ID=this.SHIP_ID;
			Unit.START_DATE=this.START_DATE;
			Unit.END_DATE=this.END_DATE;
			Unit.REPORT_DATE=this.REPORT_DATE;
			Unit.REMARK=this.REMARK;
			Unit.W_SPECIFICATION=this.W_SPECIFICATION;
			Unit.WLEFT_AMOUNT=this.WLEFT_AMOUNT;
			Unit.W_SULPHUR=this.W_SULPHUR;
			Unit.W_DENSITY=this.W_DENSITY;
			Unit.L_SPECIFICATION=this.L_SPECIFICATION;
			Unit.LLEFT_AMOUNT=this.LLEFT_AMOUNT;
			Unit.L_SULPHUR=this.L_SULPHUR;
			Unit.L_DENSITY=this.L_DENSITY;
			Unit.SAIL_DAY=this.SAIL_DAY;
			Unit.SAIL_HOUR=this.SAIL_HOUR;
            return Unit;
		}
		#endregion
		
		public override string GetId()
        {
            return this.REPORT_ID;
        }

        public override string GetTypeName()
        {
            return "HOilReport";
        }

        public override bool Update(out string err)
        {
            return HOilReportService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return HOilReportService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
