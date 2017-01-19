/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：PortInfo.cs
 * 创 建 人：xuzhengben
 * 创建时间：2010/9/19
 * 标    题：实体类
 * 功能描述：T_BASE_PORT数据实体类
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
    ///T_BASE_PORT数据实体.
    /// </summary>
    ///[Serializable]
    public partial class PortInfo : CommonClass
    {
        #region 变量定义
        ///<summary>
        ///
        ///</summary>
        private string _pORTID;
        ///<summary>
        ///
        ///</summary>
        private string _iSOCODE = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _eNAME = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _cNAME = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _cOUNTRY = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _rEMARK = String.Empty;
        #endregion

        #region 构造函数
        ///<summary>
        ///
        ///</summary>
        public PortInfo()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public PortInfo
        (
            string pORTID,
            string iSOCODE,
            string eNAME,
            string cNAME,
            string cOUNTRY,
            string rEMARK
        )
        {
            _pORTID = pORTID;
            _iSOCODE = iSOCODE;
            _eNAME = eNAME;
            _cNAME = cNAME;
            _cOUNTRY = cOUNTRY;
            _rEMARK = rEMARK;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///
        ///</summary>
        public string PORTID
        {
            get { return _pORTID; }
            set { _pORTID = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string ISOCODE
        {
            get { return _iSOCODE; }
            set { _iSOCODE = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string ENAME
        {
            get { return _eNAME; }
            set { _eNAME = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string CNAME
        {
            get { return _cNAME; }
            set { _cNAME = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string COUNTRY
        {
            get { return _cOUNTRY; }
            set { _cOUNTRY = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string REMARK
        {
            get { return _rEMARK; }
            set { _rEMARK = value; }
        }

        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            PortInfo Unit = new PortInfo();
            Unit.PORTID = this.PORTID;
            Unit.ISOCODE = this.ISOCODE;
            Unit.ENAME = this.ENAME;
            Unit.CNAME = this.CNAME;
            Unit.COUNTRY = this.COUNTRY;
            Unit.REMARK = this.REMARK;
            return Unit;
        }
        #endregion
        public override string GetId()
        {
            return this._pORTID;
        }

        public override string GetTypeName()
        {
            return "PortInfo";
        }

        public override bool Update(out string err)
        {
            return PortInfoService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return PortInfoService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {

        }
    }
}
