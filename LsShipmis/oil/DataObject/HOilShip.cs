/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：HOilShip.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-7-25
 * 标    题：实体类
 * 功能描述：T_HOIL_SHIP数据实体类
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
	///T_HOIL_SHIP数据实体.
	/// </summary>
	///[Serializable]
	public partial class HOilShip : CommonClass
	{		
		#region 构造函数
		///<summary> 
		///船舶油品表.
		///</summary>
		public HOilShip()
		{
		}
		///<summary>
		///船舶油品表.
		///</summary>
		public HOilShip
		(
			string oIL_SHIP_ID,
			string oIL_ID,
			string sHIP_ID,
			int oRDERNUM
		)
		{
			this.OIL_SHIP_ID = oIL_SHIP_ID;
			this.OIL_ID      = oIL_ID;
			this.SHIP_ID     = sHIP_ID;
			this.ORDERNUM    = oRDERNUM;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///ID
		///</summary>
		public string OIL_SHIP_ID{get ;set;}

		///<summary>
		///油品id
		///</summary>
		public string OIL_ID{get ;set;}

		///<summary>
		///船舶.
		///</summary>
		public string SHIP_ID{get ;set;}

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
			HOilShip Unit = new HOilShip();
			Unit.OIL_SHIP_ID=this.OIL_SHIP_ID;
			Unit.OIL_ID=this.OIL_ID;
			Unit.SHIP_ID=this.SHIP_ID;
			Unit.ORDERNUM=this.ORDERNUM;
            return Unit;
		}
		#endregion
		
		public override string GetId()
        {
            return this.OIL_SHIP_ID;
        }

        public override string GetTypeName()
        {
            return "HOilShip";
        }

        public override bool Update(out string err)
        {
            return HOilShipService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return HOilShipService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
