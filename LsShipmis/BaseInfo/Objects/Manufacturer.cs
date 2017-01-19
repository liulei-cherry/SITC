/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：Manufacturer.cs
 * 创 建 人：黄家龙
 * 创建时间：2011/10/12
 * 标    题：实体类
 * 功能描述：T_MANUFACTURER数据实体类
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
	///T_MANUFACTURER数据实体.
	/// </summary>
	///[Serializable]
	public partial class Manufacturer : CommonClass
	{		
		#region 构造函数
		///<summary> 
		///
		///</summary>
		public Manufacturer()
		{
		}
		///<summary>
		///
		///</summary>
		public Manufacturer
		(
			string mANUFACTURER_ID,
			string mANUFACTURER_CODE,
			string mANUFACTURER_TYPE,
			string mANUFACTURER_NAME,
			string mANUFACTURER_ENAME,
			string aDDR,
			string fAX,
			string nETADDR,
			string eMAIL,
			string lINKER,
			string pOSTALCODE,
			string rEMARK,
			string tELEPHONE,
			string mOBILPHONE,
            String mANUFACTURER_NULLIFY
		)
		{
			this.MANUFACTURER_ID    = mANUFACTURER_ID;
			this.MANUFACTURER_CODE  = mANUFACTURER_CODE;
			this.MANUFACTURER_TYPE  = mANUFACTURER_TYPE;
			this.MANUFACTURER_NAME  = mANUFACTURER_NAME;
			this.MANUFACTURER_ENAME = mANUFACTURER_ENAME;
			this.ADDR               = aDDR;
			this.FAX                = fAX;
			this.NETADDR            = nETADDR;
			this.EMAIL              = eMAIL;
			this.LINKER             = lINKER;
			this.POSTALCODE         = pOSTALCODE;
			this.REMARK             = rEMARK;
			this.TELEPHONE          = tELEPHONE;
			this.MOBILPHONE         = mOBILPHONE;
            this.MANUFACTURER_NULLIFY = mANUFACTURER_NULLIFY;
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///
		///</summary>
		public string MANUFACTURER_ID{get ;set;}

		///<summary>
		///
		///</summary>
		public string MANUFACTURER_CODE{get ;set;}

		///<summary>
        ///A:修船 B:油 C:备件 D:物资 E:其他.
		///</summary>
		public string MANUFACTURER_TYPE{get ;set;}

		///<summary>
		///
		///</summary>
		public string MANUFACTURER_NAME{get ;set;}

		///<summary>
		///
		///</summary>
		public string MANUFACTURER_ENAME{get ;set;}

		///<summary>
		///
		///</summary>
		public string ADDR{get ;set;}

		///<summary>
		///
		///</summary>
		public string FAX{get ;set;}

		///<summary>
		///
		///</summary>
		public string NETADDR{get ;set;}

		///<summary>
		///
		///</summary>
		public string EMAIL{get ;set;}

		///<summary>
		///
		///</summary>
		public string LINKER{get ;set;}

		///<summary>
		///
		///</summary>
		public string POSTALCODE{get ;set;}

		///<summary>
		///
		///</summary>
		public string REMARK{get ;set;}

		///<summary>
		///
		///</summary>
		public string TELEPHONE{get ;set;}

		///<summary>
		///
		///</summary>
		public string MOBILPHONE{get ;set;}

        /// <summary>
        /// 作废（0:重新启用供应商（或者默认）；1：作废供应商）.
        /// </summary>
        public String MANUFACTURER_NULLIFY { get; set; }
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public override CommonClass Clone()
		{
			Manufacturer Unit = new Manufacturer();
			Unit.MANUFACTURER_ID=this.MANUFACTURER_ID;
			Unit.MANUFACTURER_CODE=this.MANUFACTURER_CODE;
			Unit.MANUFACTURER_TYPE=this.MANUFACTURER_TYPE;
			Unit.MANUFACTURER_NAME=this.MANUFACTURER_NAME;
			Unit.MANUFACTURER_ENAME=this.MANUFACTURER_ENAME;
			Unit.ADDR=this.ADDR;
			Unit.FAX=this.FAX;
			Unit.NETADDR=this.NETADDR;
			Unit.EMAIL=this.EMAIL;
			Unit.LINKER=this.LINKER;
			Unit.POSTALCODE=this.POSTALCODE;
			Unit.REMARK=this.REMARK;
			Unit.TELEPHONE=this.TELEPHONE;
			Unit.MOBILPHONE=this.MOBILPHONE;
            Unit.MANUFACTURER_NULLIFY = this.MANUFACTURER_NULLIFY;
            return Unit;
		}
		#endregion
		
		public override string GetId()
        {
            return this.MANUFACTURER_ID;
        }

        public override string GetTypeName()
        {
            return "Manufacturer";
        }

        public override bool Update(out string err)
        {
            return ManufacturerService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return ManufacturerService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
