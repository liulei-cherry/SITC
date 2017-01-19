/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：T_CHARTINDEX.cs
 * 创 建 人：牛振军
 * 创建时间：2008-12-29
 * 标    题：实体类
 * 功能描述：T_CHARTINDEX数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
namespace SeaChartManage.BusinessClasses
{
	/// <summary>
	///T_CHARTINDEX数据实体.
	/// </summary>
	///[Serializable]
	public class T_CHARTINDEX
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private string _cHARTID;
		///<summary>
		///
		///</summary>
		private string _cHARTNO = String.Empty;
		///<summary>
		///
		///</summary>
		private string _tITLECN = String.Empty;
		///<summary>
		///
		///</summary>
		private string _tITLEEN = String.Empty;
		///<summary>
		///
		///</summary>
		private string _sIZE = String.Empty;
		///<summary>
		///
		///</summary>
		private string _pAGE = String.Empty;
		#endregion
		
		#region 构造函数
		///<summary>
		///
		///</summary>
		public T_CHARTINDEX()
		{
		}
		///<summary>
		///
		///</summary>
		public T_CHARTINDEX
		(
			string cHARTID,
			string cHARTNO,
			string tITLECN,
			string tITLEEN,
			string sIZE,
			string pAGE
		)
		{
			_cHARTID = cHARTID;
			_cHARTNO = cHARTNO;
			_tITLECN = tITLECN;
			_tITLEEN = tITLEEN;
			_sIZE    = sIZE;
			_pAGE    = pAGE;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///
		///</summary>
		public string CHARTID
		{
			get {return _cHARTID;}
			set {_cHARTID = value;}
		}

		///<summary>
		///
		///</summary>
		public string CHARTNO
		{
			get {return _cHARTNO;}
			set {_cHARTNO = value;}
		}

		///<summary>
		///
		///</summary>
		public string TITLECN
		{
			get {return _tITLECN;}
			set {_tITLECN = value;}
		}

		///<summary>
		///
		///</summary>
		public string TITLEEN
		{
			get {return _tITLEEN;}
			set {_tITLEEN = value;}
		}

		///<summary>
		///
		///</summary>
		public string SIZE
		{
			get {return _sIZE;}
			set {_sIZE = value;}
		}

		///<summary>
		///
		///</summary>
		public string PAGE
		{
			get {return _pAGE;}
			set {_pAGE = value;}
		}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public T_CHARTINDEX Clone()
		{
			T_CHARTINDEX Unit = new T_CHARTINDEX();
			Unit.CHARTID=this.CHARTID;
			Unit.CHARTNO=this.CHARTNO;
			Unit.TITLECN=this.TITLECN;
			Unit.TITLEEN=this.TITLEEN;
			Unit.SIZE=this.SIZE;
			Unit.PAGE=this.PAGE;
          return Unit;
		}
		#endregion
		
	}
}
