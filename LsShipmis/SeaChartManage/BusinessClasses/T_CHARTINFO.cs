/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：T_CHARTINFO.cs
 * 创 建 人：牛振军
 * 创建时间：2008-12-29
 * 标    题：实体类
 * 功能描述：T_CHARTINFO数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
namespace SeaChartManage.BusinessClasses
{
	/// <summary>
	///T_CHARTINFO数据实体.
	/// </summary>
	///[Serializable]
	public class T_CHARTINFO
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private string _chartInfoId;
		///<summary>
		///
		///</summary>
		private string _cHARTTITLE = String.Empty;
		///<summary>
		///
		///</summary>
		private string _cHARTCONTENT = String.Empty;
		///<summary>
		///
		///</summary>
		private string _pUBLISHER = String.Empty;
		///<summary>
		///
		///</summary>
		private DateTime _pUBLISHDATE;
		#endregion
		
		#region 构造函数
		///<summary>
		///
		///</summary>
		public T_CHARTINFO()
		{
		}
		///<summary>
		///
		///</summary>
		public T_CHARTINFO
		(
			string chartInfoId,
			string cHARTTITLE,
			string cHARTCONTENT,
			string pUBLISHER,
			DateTime pUBLISHDATE
		)
		{
			_chartInfoId  = chartInfoId;
			_cHARTTITLE   = cHARTTITLE;
			_cHARTCONTENT = cHARTCONTENT;
			_pUBLISHER    = pUBLISHER;
			_pUBLISHDATE  = pUBLISHDATE;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///
		///</summary>
		public string ChartInfoId
		{
			get {return _chartInfoId;}
			set {_chartInfoId = value;}
		}

		///<summary>
		///
		///</summary>
		public string CHARTTITLE
		{
			get {return _cHARTTITLE;}
			set {_cHARTTITLE = value;}
		}

		///<summary>
		///
		///</summary>
		public string CHARTCONTENT
		{
			get {return _cHARTCONTENT;}
			set {_cHARTCONTENT = value;}
		}

		///<summary>
		///
		///</summary>
		public string PUBLISHER
		{
			get {return _pUBLISHER;}
			set {_pUBLISHER = value;}
		}

		///<summary>
		///
		///</summary>
		public DateTime PUBLISHDATE
		{
			get {return _pUBLISHDATE;}
			set {_pUBLISHDATE = value;}
		}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public T_CHARTINFO Clone()
		{
			T_CHARTINFO Unit = new T_CHARTINFO();
			Unit.ChartInfoId=this.ChartInfoId;
			Unit.CHARTTITLE=this.CHARTTITLE;
			Unit.CHARTCONTENT=this.CHARTCONTENT;
			Unit.PUBLISHER=this.PUBLISHER;
			Unit.PUBLISHDATE=this.PUBLISHDATE;
          return Unit;
		}
		#endregion
		
	}
}
