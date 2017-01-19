/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：ShipCert.cs
 * 创 建 人：徐正本
 * 创建时间：2011/8/31
 * 标    题：实体类
 * 功能描述：T_SHIP_CERT数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using ShipCertification.Services;

namespace ShipCertification.DataObject
{
	/// <summary>
	///T_SHIP_CERT数据实体.
	/// </summary>
	///[Serializable]
	public partial class ShipCert : CommonClass
	{		
		#region 构造函数
		///<summary> 
		///
		///</summary>
		public ShipCert()
		{
		}
		///<summary>
		///
		///</summary>
		public ShipCert
		(
			string sHIP_CERT_ID,
			string sHIPCERTCODE,
			string sHIPCERTCHNAME,
			string sHIPCERTENNAME,
			decimal aLERTDAYS,
			decimal eFFECTDATE,
			decimal nEEDOUTPUT,
			string aIMTOCONFIG,
			string aIMTOCONFIGSHORT,
			string rEMARK,
			int sORTNO
		)
		{
			this.SHIP_CERT_ID     = sHIP_CERT_ID;
			this.SHIPCERTCODE     = sHIPCERTCODE;
			this.SHIPCERTCHNAME   = sHIPCERTCHNAME;
			this.SHIPCERTENNAME   = sHIPCERTENNAME;
			this.ALERTDAYS        = aLERTDAYS;
			this.EFFECTDATE       = eFFECTDATE;
			this.NEEDOUTPUT       = nEEDOUTPUT;
            this._aIMTOCONFIG = aIMTOCONFIG;
			this._aIMTOCONFIGSHORT = aIMTOCONFIGSHORT;
			this.REMARK           = rEMARK;
			this.SORTNO           = sORTNO;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///证书基础信息Id
		///</summary>
		public string SHIP_CERT_ID{get ;set;}

		///<summary>
		///证书编号.
		///</summary>
		public string SHIPCERTCODE{get ;set;}

		///<summary>
		///证书中文名称.
		///</summary>
		public string SHIPCERTCHNAME{get ;set;}

		///<summary>
		///证书英文名称.
		///</summary>
		public string SHIPCERTENNAME{get ;set;}

		///<summary>
		///报警天数(天)
		///</summary>
		public decimal ALERTDAYS{get ;set;}

		///<summary>
		///默认有效期.
		///</summary>
		public decimal EFFECTDATE{get ;set;}

		///<summary>
		///是否需要输出1输出0不输出.
		///</summary>
		public decimal NEEDOUTPUT{get ;set;}
 
		///<summary>
		///备注.
		///</summary>
		public string REMARK{get ;set;}

		///<summary>
		///
		///</summary>
		public int SORTNO{get ;set;}

        private string _aIMTOCONFIG;
        private string _aIMTOCONFIGSHORT;
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public override CommonClass Clone()
		{
			ShipCert Unit = new ShipCert();
			Unit.SHIP_CERT_ID=this.SHIP_CERT_ID;
			Unit.SHIPCERTCODE=this.SHIPCERTCODE;
			Unit.SHIPCERTCHNAME=this.SHIPCERTCHNAME;
			Unit.SHIPCERTENNAME=this.SHIPCERTENNAME;
			Unit.ALERTDAYS=this.ALERTDAYS;
			Unit.EFFECTDATE=this.EFFECTDATE;
			Unit.NEEDOUTPUT=this.NEEDOUTPUT;
			Unit.AIMTOCONFIG=this.AIMTOCONFIG;
			Unit.AIMTOCONFIGSHORT=this.AIMTOCONFIGSHORT;
			Unit.REMARK=this.REMARK;
			Unit.SORTNO=this.SORTNO;
            return Unit;
		}
		#endregion
		
		public override string GetId()
        {
            return this.SHIP_CERT_ID;
        }

        public override string GetTypeName()
        {
            return "ShipCert";
        }

        public override bool Update(out string err)
        {
            return ShipCertService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return ShipCertService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        } 

        ///<summary>
        ///
        ///</summary>
        public bool NEEDOUTPUTSHOW
        {
            get { return (NEEDOUTPUT == 1); }
            set { NEEDOUTPUT = (value ? 1 : 0); }
        }
        ///<summary>
        ///
        ///</summary>
        public string AIMTOCONFIG
        {
            get
            {
                //当对应的为空,即找不到对应,则默认为当前证书名称.
                if (string.IsNullOrEmpty(_aIMTOCONFIG)) _aIMTOCONFIG = SHIPCERTCHNAME ;
                return _aIMTOCONFIG;
            }
            set { _aIMTOCONFIG = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string AIMTOCONFIGSHORT
        {
            get
            {
                //当对应的为空,即找不到对应,则默认为当前证书名称.
                if (string.IsNullOrEmpty(_aIMTOCONFIGSHORT)) _aIMTOCONFIGSHORT = SHIPCERTCHNAME;
                return _aIMTOCONFIGSHORT;
            }
            set { _aIMTOCONFIGSHORT = value; }
        }
       
        public override string ToString()
        {
            if (SHIPCERTCHNAME == SHIPCERTENNAME || string.IsNullOrEmpty(SHIPCERTENNAME))
            {
                return this.SHIPCERTCHNAME;
            }
            return SHIPCERTCHNAME + "(" + SHIPCERTENNAME + ")";
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
