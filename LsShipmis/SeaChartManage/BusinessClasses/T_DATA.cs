/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：T_DATA.cs
 * 创 建 人：牛振军
 * 创建时间：2008-12-29
 * 标    题：实体类
 * 功能描述：T_DATA数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
namespace SeaChartManage.BusinessClasses
{
	/// <summary>
	///T_DATA数据实体.
	/// </summary>
	///[Serializable]
	public class T_DATA
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private string _dATA_ID;
		///<summary>
		///
		///</summary>
		private DateTime _aPPLY_DATE;
		///<summary>
		///
		///</summary>
		private DateTime _cATCH_DATE;
		///<summary>
		///
		///</summary>
		private DateTime _eND_DATE;
		///<summary>
		///
		///</summary>
		private string _dATA_STOCK_ID = String.Empty;
		///<summary>
		///
		///</summary>
		private string _dATA_REMARK = String.Empty;
		///<summary>
		///
		///</summary>
		private string _aPPLY_PERSORN = String.Empty;
		///<summary>
		///
		///</summary>
		private int _rETURN_FLAG;
		#endregion
		
		#region 构造函数
		///<summary>
		///
		///</summary>
		public T_DATA()
		{
		}
		///<summary>
		///
		///</summary>
		public T_DATA
		(
			string dATA_ID,
			DateTime aPPLY_DATE,
			DateTime cATCH_DATE,
			DateTime eND_DATE,
			string dATA_STOCK_ID,
			string dATA_REMARK,
			string aPPLY_PERSORN,
			int rETURN_FLAG
		)
		{
			_dATA_ID       = dATA_ID;
			_aPPLY_DATE    = aPPLY_DATE;
			_cATCH_DATE    = cATCH_DATE;
			_eND_DATE      = eND_DATE;
			_dATA_STOCK_ID = dATA_STOCK_ID;
			_dATA_REMARK   = dATA_REMARK;
			_aPPLY_PERSORN = aPPLY_PERSORN;
			_rETURN_FLAG   = rETURN_FLAG;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///
		///</summary>
		public string DATA_ID
		{
			get {return _dATA_ID;}
			set {_dATA_ID = value;}
		}

		///<summary>
		///
		///</summary>
		public DateTime APPLY_DATE
		{
			get {return _aPPLY_DATE;}
			set {_aPPLY_DATE = value;}
		}

		///<summary>
		///
		///</summary>
		public DateTime CATCH_DATE
		{
			get {return _cATCH_DATE;}
			set {_cATCH_DATE = value;}
		}

		///<summary>
		///
		///</summary>
		public DateTime END_DATE
		{
			get {return _eND_DATE;}
			set {_eND_DATE = value;}
		}

		///<summary>
		///
		///</summary>
		public string DATA_STOCK_ID
		{
			get {return _dATA_STOCK_ID;}
			set {_dATA_STOCK_ID = value;}
		}

		///<summary>
		///
		///</summary>
		public string DATA_REMARK
		{
			get {return _dATA_REMARK;}
			set {_dATA_REMARK = value;}
		}

		///<summary>
		///
		///</summary>
		public string APPLY_PERSORN
		{
			get {return _aPPLY_PERSORN;}
			set {_aPPLY_PERSORN = value;}
		}

		///<summary>
		///
		///</summary>
		public int RETURN_FLAG
		{
			get {return _rETURN_FLAG;}
			set {_rETURN_FLAG = value;}
		}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public T_DATA Clone()
		{
			T_DATA Unit = new T_DATA();
			Unit.DATA_ID=this.DATA_ID;
			Unit.APPLY_DATE=this.APPLY_DATE;
			Unit.CATCH_DATE=this.CATCH_DATE;
			Unit.END_DATE=this.END_DATE;
			Unit.DATA_STOCK_ID=this.DATA_STOCK_ID;
			Unit.DATA_REMARK=this.DATA_REMARK;
			Unit.APPLY_PERSORN=this.APPLY_PERSORN;
			Unit.RETURN_FLAG=this.RETURN_FLAG;
          return Unit;
		}
		#endregion
		
	}
}
