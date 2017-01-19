/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：CurrencyRate.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-7-4
 * 标    题：实体类
 * 功能描述：T_CURRENCY_EXCHANGE_RATE数据实体类
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
	///T_CURRENCY_EXCHANGE_RATE数据实体.
	/// </summary>
	///[Serializable]
	public partial class CurrencyRate : CommonClass
	{		
		#region 构造函数
		///<summary> 
		///货币汇率表.
		///</summary>
		public CurrencyRate()
		{
		}
		///<summary>
		///货币汇率表.
		///</summary>
		public CurrencyRate
		(
			string rATEID,
			string eXCHANGECURRENCY,
			string bASECURRENCY,
			decimal eXCHANGERATE,
			DateTime uSEFULDATEFROM,
			DateTime uSEFULDATEEND,
			decimal iSUSEFULL,
			string rEMARK
		)
		{
			this.RATEID           = rATEID;
			this.EXCHANGECURRENCY = eXCHANGECURRENCY;
			this.BASECURRENCY     = bASECURRENCY;
			this.EXCHANGERATE     = eXCHANGERATE;
			this.USEFULDATEFROM   = uSEFULDATEFROM;
			this.USEFULDATEEND    = uSEFULDATEEND;
			this.ISUSEFULL        = iSUSEFULL;
			this.REMARK           = rEMARK;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///兑换id
		///</summary>
		public string RATEID{get ;set;}

		///<summary>
		///兑换货币.
		///</summary>
		public string EXCHANGECURRENCY{get ;set;}

		///<summary>
		///基准货币.
		///</summary>
		public string BASECURRENCY{get ;set;}

		///<summary>
		///汇率.
		///</summary>
		public decimal EXCHANGERATE{get ;set;}

		///<summary>
		///有效起始日期.
		///</summary>
		public DateTime USEFULDATEFROM{get ;set;}

		///<summary>
		///有效结束日期.
		///</summary>
		public DateTime USEFULDATEEND{get ;set;}

		///<summary>
		///是否有效(1,有效,0无效)同样两种货币不允许有两种同时有效的兑换汇率.
		///</summary>
		public decimal ISUSEFULL{get ;set;}

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
			CurrencyRate Unit = new CurrencyRate();
			Unit.RATEID=this.RATEID;
			Unit.EXCHANGECURRENCY=this.EXCHANGECURRENCY;
			Unit.BASECURRENCY=this.BASECURRENCY;
			Unit.EXCHANGERATE=this.EXCHANGERATE;
			Unit.USEFULDATEFROM=this.USEFULDATEFROM;
			Unit.USEFULDATEEND=this.USEFULDATEEND;
			Unit.ISUSEFULL=this.ISUSEFULL;
			Unit.REMARK=this.REMARK;
            return Unit;
		}
		#endregion
		
		public override string GetId()
        {
            return this.RATEID;
        }

        public override string GetTypeName()
        {
            return "CurrencyRate";
        }

        public override bool Update(out string err)
        {
            return CurrencyRateService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return CurrencyRateService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
