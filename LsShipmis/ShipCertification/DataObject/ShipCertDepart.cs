/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：ShipCertDepart.cs
 * 创 建 人：徐正本
 * 创建时间：2010-5-27
 * 标    题：实体类
 * 功能描述：T_SHIP_CERT_DEPART数据实体类
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
    ///T_SHIP_CERT_DEPART数据实体.
    /// </summary>
    ///[Serializable]
    public partial class ShipCertDepart : CommonClass
    {
        #region 变量定义
        ///<summary>
        ///发证机构Id
        ///</summary>
        private string _sHIP_CERT_DEPARTID;
        ///<summary>
        ///发证机构名称.
        ///</summary>
        private string _sHIPCERTDEPARTNAME = String.Empty;
        ///<summary>
        ///代码（之前是表达所在国的意思，为了符合标准，现改成编码字段）.
        ///</summary>
        private string _cOUNTRY = String.Empty;
        #endregion

        #region 构造函数
        ///<summary>
        ///
        ///</summary>
        public ShipCertDepart()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public ShipCertDepart
        (
            string sHIP_CERT_DEPARTID,
            string sHIPCERTDEPARTNAME,
            string cOUNTRY
        )
        {
            _sHIP_CERT_DEPARTID = sHIP_CERT_DEPARTID;
            _sHIPCERTDEPARTNAME = sHIPCERTDEPARTNAME;
            _cOUNTRY = cOUNTRY;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///发证机构Id
        ///</summary>
        public string SHIP_CERT_DEPARTID
        {
            get { return _sHIP_CERT_DEPARTID; }
            set { _sHIP_CERT_DEPARTID = value; }
        }

        ///<summary>
        ///发证机构名称.
        ///</summary>
        public string SHIPCERTDEPARTNAME
        {
            get { return _sHIPCERTDEPARTNAME; }
            set { _sHIPCERTDEPARTNAME = value; }
        }

        ///<summary>
        ///所在国.
        ///</summary>
        public string COUNTRY
        {
            get { return _cOUNTRY; }
            set { _cOUNTRY = value; }
        }

        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            ShipCertDepart Unit = new ShipCertDepart();
            Unit.SHIP_CERT_DEPARTID = this.SHIP_CERT_DEPARTID;
            Unit.SHIPCERTDEPARTNAME = this.SHIPCERTDEPARTNAME;
            Unit.COUNTRY = this.COUNTRY;
            return Unit;
        }
        #endregion
        public override string GetId()
        {
            return this._sHIP_CERT_DEPARTID;
        }

        public override string GetTypeName()
        {
            return "ShipCertDepart";
        }

        public override bool Update(out string err)
        {
            return ShipCertDepartService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return ShipCertDepartService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {

        }
    }
}
