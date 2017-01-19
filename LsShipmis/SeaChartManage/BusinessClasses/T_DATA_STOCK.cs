/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：T_DATA_STOCK.cs
 * 创 建 人：牛振军
 * 创建时间：2008-12-29
 * 标    题：实体类
 * 功能描述：T_DATA_STOCK数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
namespace SeaChartManage.BusinessClasses
{
	/// <summary>
	///T_DATA_STOCK数据实体.
	/// </summary>
	///[Serializable]
	public class T_DATA_STOCK
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private string _dATA_STOCK_ID;
		///<summary>
		///
		///</summary>
		private string _cODE = String.Empty;
		///<summary>
		///
		///</summary>
		private string _dATA_NAME = String.Empty;
		///<summary>
		///
		///</summary>
		private string _dATA_REMARK = String.Empty;
		///<summary>
		///
		///</summary>
		private int _dATA_NUMBER;
		///<summary>
		///
		///</summary>
		private int _dATA_LIEVE_NUMBER;
		///<summary>
		///
		///</summary>
		private string _dATA_CLASS = String.Empty;
		#endregion
		
		#region 构造函数
		///<summary>
		///
		///</summary>
		public T_DATA_STOCK()
		{
		}
		///<summary>
		///
		///</summary>
		public T_DATA_STOCK
		(
			string dATA_STOCK_ID,
			string cODE,
			string dATA_NAME,
			string dATA_REMARK,
			int dATA_NUMBER,
			int dATA_LIEVE_NUMBER,
			string dATA_CLASS
		)
		{
			_dATA_STOCK_ID     = dATA_STOCK_ID;
			_cODE              = cODE;
			_dATA_NAME         = dATA_NAME;
			_dATA_REMARK       = dATA_REMARK;
			_dATA_NUMBER       = dATA_NUMBER;
			_dATA_LIEVE_NUMBER = dATA_LIEVE_NUMBER;
			_dATA_CLASS        = dATA_CLASS;
			
		}
		#endregion
		
		#region 公共属性
		
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
		public string CODE
		{
			get {return _cODE;}
			set {_cODE = value;}
		}

		///<summary>
		///
		///</summary>
		public string DATA_NAME
		{
			get {return _dATA_NAME;}
			set {_dATA_NAME = value;}
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
		public int DATA_NUMBER
		{
			get {return _dATA_NUMBER;}
			set {_dATA_NUMBER = value;}
		}

		///<summary>
		///
		///</summary>
		public int DATA_LIEVE_NUMBER
		{
			get {return _dATA_LIEVE_NUMBER;}
			set {_dATA_LIEVE_NUMBER = value;}
		}

		///<summary>
		///
		///</summary>
		public string DATA_CLASS
		{
			get {return _dATA_CLASS;}
			set {_dATA_CLASS = value;}
		}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public T_DATA_STOCK Clone()
		{
			T_DATA_STOCK Unit = new T_DATA_STOCK();
			Unit.DATA_STOCK_ID=this.DATA_STOCK_ID;
			Unit.CODE=this.CODE;
			Unit.DATA_NAME=this.DATA_NAME;
			Unit.DATA_REMARK=this.DATA_REMARK;
			Unit.DATA_NUMBER=this.DATA_NUMBER;
			Unit.DATA_LIEVE_NUMBER=this.DATA_LIEVE_NUMBER;
			Unit.DATA_CLASS=this.DATA_CLASS;
          return Unit;
		}
		#endregion
		
	}
}
