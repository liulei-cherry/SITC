/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：HOilAdd.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-7-25
 * 标    题：实体类
 * 功能描述：T_HOIL_ADD数据实体类
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
	///T_HOIL_ADD数据实体.
	/// </summary>
	///[Serializable]
	public partial class HOilAdd : CommonClass
	{		
		#region 构造函数
		///<summary> 
		///燃油加油.
		///</summary>
		public HOilAdd()
		{
		}
		///<summary>
		///燃油加油.
		///</summary>
		public HOilAdd
		(
			string fUEL_ID,
			string sHIP_ID,
			string pORT_ID,
			DateTime aDD_DATE,
			string oIL_TYPE,
			string sPECIFICATION,
			decimal aMOUNT,
			decimal sULPHUR,
			decimal dENSITY,
			string rEMARK
		)
		{
			this.FUEL_ID       = fUEL_ID;
			this.SHIP_ID       = sHIP_ID;
			this.PORT_ID       = pORT_ID;
			this.ADD_DATE      = aDD_DATE;
			this.OIL_TYPE      = oIL_TYPE;
			this.SPECIFICATION = sPECIFICATION;
			this.AMOUNT        = aMOUNT;
			this.SULPHUR       = sULPHUR;
			this.DENSITY       = dENSITY;
			this.REMARK        = rEMARK;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///ID
		///</summary>
		public string FUEL_ID{get ;set;}

		///<summary>
		///船舶ID
		///</summary>
		public string SHIP_ID{get ;set;}

		///<summary>
		///港口ID
		///</summary>
		public string PORT_ID{get ;set;}

		///<summary>
		///加油日期.
		///</summary>
		public DateTime ADD_DATE{get ;set;}

		///<summary>
		///燃油类型（A重油，B轻油）.
		///</summary>
		public string OIL_TYPE{get ;set;}

		///<summary>
		///规格.
		///</summary>
		public string SPECIFICATION{get ;set;}

		///<summary>
		///数量（单位：吨）.
		///</summary>
		public decimal AMOUNT{get ;set;}

		///<summary>
		///含硫量（%）.
		///</summary>
		public decimal SULPHUR{get ;set;}

		///<summary>
		///比重（KG/L）.
		///</summary>
		public decimal DENSITY{get ;set;}

		///<summary>
		///备注.
		///</summary>
		public string REMARK{get ;set;}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public override CommonClass Clone()
		{
			HOilAdd Unit = new HOilAdd();
			Unit.FUEL_ID=this.FUEL_ID;
			Unit.SHIP_ID=this.SHIP_ID;
			Unit.PORT_ID=this.PORT_ID;
			Unit.ADD_DATE=this.ADD_DATE;
			Unit.OIL_TYPE=this.OIL_TYPE;
			Unit.SPECIFICATION=this.SPECIFICATION;
			Unit.AMOUNT=this.AMOUNT;
			Unit.SULPHUR=this.SULPHUR;
			Unit.DENSITY=this.DENSITY;
			Unit.REMARK=this.REMARK;
            return Unit;
		}
		#endregion
		
		public override string GetId()
        {
            return this.FUEL_ID;
        }

        public override string GetTypeName()
        {
            return "HOilAdd";
        }

        public override bool Update(out string err)
        {
            return HOilAddService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return HOilAddService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
