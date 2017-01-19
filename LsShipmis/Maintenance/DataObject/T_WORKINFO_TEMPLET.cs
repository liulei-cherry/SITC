/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：T_WORKINFO_TEMPLET.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-5-12
 * 标    题：实体类
 * 功能描述：T_WORKINFO_TEMPLET数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using Maintenance.Services;

namespace Maintenance.DataObject
{
	/// <summary>
	///T_WORKINFO_TEMPLET数据实体.
	/// </summary>
	///[Serializable]
	public partial class T_WORKINFO_TEMPLET : CommonClass
	{
		#region 变量定义
		///<summary>
		///主键.
		///</summary>
		private string _wORKINFO_TEMPLET_ID;
		///<summary>
		///相关设备.
		///</summary>
		private string _cOMPONENTREFERENCE = String.Empty;
		///<summary>
		///保养项目.
		///</summary>
		private string _iTEMNAME = String.Empty;
		///<summary>
		///保养内容.
		///</summary>
		private string _iTEMCONTENT = String.Empty;
		///<summary>
		///预检周期.
		///</summary>
		private decimal _pERIOD;
		///<summary>
		///周期的单位，数据取T_PERIODICAL
		///</summary>
		private string _pERIODICAL = String.Empty;

        ///<summary>
        ///预检周期(定时)
        ///</summary>
        private decimal _tIMINGPERIOD;
		///<summary>
		///备注.
		///</summary>
		private string _rEMARK = String.Empty;
		///<summary>
		///工作信息模板的分类ID
		///</summary>
		private string _cLASS_ID = String.Empty;
		#endregion
		
		#region 构造函数
		///<summary>
		///工作信息模板类（重新设计的）.
		///</summary>
		public T_WORKINFO_TEMPLET()
		{
		}
		///<summary>
		///工作信息模板类（重新设计的）.
		///</summary>
		public T_WORKINFO_TEMPLET
		(
			string wORKINFO_TEMPLET_ID,
			string cOMPONENTREFERENCE,
			string iTEMNAME,
			string iTEMCONTENT,
			decimal pERIOD,
			string pERIODICAL,
			string rEMARK,
			string cLASS_ID
		)
		{
			_wORKINFO_TEMPLET_ID = wORKINFO_TEMPLET_ID;
			_cOMPONENTREFERENCE  = cOMPONENTREFERENCE;
			_iTEMNAME            = iTEMNAME;
			_iTEMCONTENT         = iTEMCONTENT;
			_pERIOD              = pERIOD;
			_pERIODICAL          = pERIODICAL;
			_rEMARK              = rEMARK;
			_cLASS_ID            = cLASS_ID;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///主键.
		///</summary>
		public string WORKINFO_TEMPLET_ID
		{
			get {return _wORKINFO_TEMPLET_ID;}
			set {_wORKINFO_TEMPLET_ID = value;}
		}

		///<summary>
		///相关设备.
		///</summary>
		public string COMPONENTREFERENCE
		{
			get {return _cOMPONENTREFERENCE;}
			set {_cOMPONENTREFERENCE = value;}
		}

		///<summary>
		///保养项目.
		///</summary>
		public string ITEMNAME
		{
			get {return _iTEMNAME;}
			set {_iTEMNAME = value;}
		}

		///<summary>
		///保养内容.
		///</summary>
		public string ITEMCONTENT
		{
			get {return _iTEMCONTENT;}
			set {_iTEMCONTENT = value;}
		}

		///<summary>
		///预检周期.
		///</summary>
		public decimal PERIOD
		{
			get {return _pERIOD;}
			set {_pERIOD = value;}
		}

		///<summary>
		///周期的单位，数据取T_PERIODICAL
		///</summary>
		public string PERIODICAL
		{
			get {return _pERIODICAL;}
			set {_pERIODICAL = value;}
		}

        ///<summary>
        ///预检周期(定时)
        ///</summary>
        public decimal TIMINGPERIOD
        {
            get { return _tIMINGPERIOD; }
            set { _tIMINGPERIOD = value; }
        }

		///<summary>
		///备注.
		///</summary>
		public string REMARK
		{
			get {return _rEMARK;}
			set {_rEMARK = value;}
		}

		///<summary>
		///工作信息模板的分类ID
		///</summary>
		public string CLASS_ID
		{
			get {return _cLASS_ID;}
			set {_cLASS_ID = value;}
		}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		 public override CommonClass Clone()
		{
			T_WORKINFO_TEMPLET Unit = new T_WORKINFO_TEMPLET();
			Unit.WORKINFO_TEMPLET_ID=this.WORKINFO_TEMPLET_ID;
			Unit.COMPONENTREFERENCE=this.COMPONENTREFERENCE;
			Unit.ITEMNAME=this.ITEMNAME;
			Unit.ITEMCONTENT=this.ITEMCONTENT;
			Unit.PERIOD=this.PERIOD;
			Unit.PERIODICAL=this.PERIODICAL;
			Unit.REMARK=this.REMARK;
			Unit.CLASS_ID=this.CLASS_ID;
          return Unit;
		}
		#endregion
		 public override string GetId()
        {
            return this._wORKINFO_TEMPLET_ID;
        }

        public override string GetTypeName()
        {
            return "T_WORKINFO_TEMPLET";
        }

        public override bool Update(out string err)
        {
            return T_WORKINFO_TEMPLETService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return T_WORKINFO_TEMPLETService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
