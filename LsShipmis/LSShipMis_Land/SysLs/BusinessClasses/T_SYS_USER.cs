/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：T_SYS_USER.cs
 * 创 建 人：xxl
 * 创建时间：2009-1-15
 * 标    题：实体类
 * 功能描述：T_SYS_USER数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
namespace LSShipMis_Land.SysLs.BusinessClasses
{
	/// <summary>
	///T_SYS_USER数据实体.
	/// </summary>
	///[Serializable]
	public class T_SYS_USER
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private string _uSERID;
		///<summary>
		///
		///</summary>
		private string _sHIPUSERID = String.Empty;
		///<summary>
		///
		///</summary>
		private string _uSERLOGINNAME = String.Empty;
		///<summary>
		///
		///</summary>
		private string _uSERLOGINPASS = String.Empty;
		///<summary>
		///
		///</summary>
		private decimal _sUPPERUSSER;
		///<summary>
		///
		///</summary>
		private string _creator = String.Empty;
		///<summary>
		///
		///</summary>
		private DateTime _createtime;
		///<summary>
		///
		///</summary>
		private DateTime _updatetime;
		#endregion
		
		#region 构造函数
		///<summary>
		///
		///</summary>
		public T_SYS_USER()
		{
		}
		///<summary>
		///
		///</summary>
		public T_SYS_USER
		(
			string uSERID,
			string sHIPUSERID,
			string uSERLOGINNAME,
			string uSERLOGINPASS,
			decimal sUPPERUSSER,
			string creator,
			DateTime createtime,
			DateTime updatetime
		)
		{
			_uSERID        = uSERID;
			_sHIPUSERID    = sHIPUSERID;
			_uSERLOGINNAME = uSERLOGINNAME;
			_uSERLOGINPASS = uSERLOGINPASS;
			_sUPPERUSSER   = sUPPERUSSER;
			_creator       = creator;
			_createtime    = createtime;
			_updatetime    = updatetime;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///
		///</summary>
		public string USERID
		{
			get {return _uSERID;}
			set {_uSERID = value;}
		}

		///<summary>
		///
		///</summary>
		public string SHIPUSERID
		{
			get {return _sHIPUSERID;}
			set {_sHIPUSERID = value;}
		}

		///<summary>
		///
		///</summary>
		public string USERLOGINNAME
		{
			get {return _uSERLOGINNAME;}
			set {_uSERLOGINNAME = value;}
		}

		///<summary>
		///
		///</summary>
		public string USERLOGINPASS
		{
			get {return _uSERLOGINPASS;}
			set {_uSERLOGINPASS = value;}
		}

		///<summary>
		///
		///</summary>
		public decimal SUPPERUSSER
		{
			get {return _sUPPERUSSER;}
			set {_sUPPERUSSER = value;}
		}

		///<summary>
		///
		///</summary>
		public string creator
		{
			get {return _creator;}
			set {_creator = value;}
		}

		///<summary>
		///
		///</summary>
		public DateTime createtime
		{
			get {return _createtime;}
			set {_createtime = value;}
		}

		///<summary>
		///
		///</summary>
		public DateTime updatetime
		{
			get {return _updatetime;}
			set {_updatetime = value;}
		}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public T_SYS_USER Clone()
		{
			T_SYS_USER Unit = new T_SYS_USER();
			Unit.USERID=this.USERID;
			Unit.SHIPUSERID=this.SHIPUSERID;
			Unit.USERLOGINNAME=this.USERLOGINNAME;
			Unit.USERLOGINPASS=this.USERLOGINPASS;
			Unit.SUPPERUSSER=this.SUPPERUSSER;
			Unit.creator=this.creator;
			Unit.createtime=this.createtime;
			Unit.updatetime=this.updatetime;
          return Unit;
		}
		#endregion
		
	}
}
