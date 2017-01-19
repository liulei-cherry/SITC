/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：ComponentType.cs
 * 创 建 人：xurongxia
 * 创建时间：2009-11-16
 * 标    题：实体类
 * 功能描述：T_COMPONENT_TYPE数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using BaseInfo.Objects;

namespace ItemsManage.DataObject
{
    /// <summary>
    ///T_COMPONENT_TYPE数据实体.
    /// </summary>
    ///[Serializable]
    public partial class ComponentType : CommonClass
    {
        #region 变量定义
        ///<summary>
        ///
        ///</summary>
        private string _cOMPONENT_TYPE_ID;
        ///<summary>
        ///
        ///</summary>
        private string _sUPERIOR_COMPONENT = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _cODE_SYSTEM_INDEX = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _cOMPONENT_LEVEL = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _cOMPTYPE_CHINESE_NAME = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _cOMPTYPE_ENGLISH_NAME = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _sHIP_PROVE_CODE = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _lETTER_NUMBER = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _mANUFACTURER = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _uSE_POSITION = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _cOMPONENT_STYLE = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _sERVICE_PROVIDER = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private decimal _dEFAULT_USE_RATE;
        ///<summary>
        ///
        ///</summary>
        private string _cREATOR = String.Empty; 
        ///<summary>
        ///
        ///</summary>
        private decimal _tIMING_TYPE;
        ///<summary>
        ///
        ///</summary>
        private string _hEADSHIP = String.Empty; 
        ///<summary>
        ///
        ///</summary>
        private decimal _sAFEEQUIPMENT;
        ///<summary>
        ///
        ///</summary>
        private decimal _sort_no;
        ///<summary>
        ///
        ///</summary>
        private string _detail = String.Empty;

        private Post thePrincipalPost;

        public Post ThePrincipalPost
        {
            get { return thePrincipalPost; }
            set { thePrincipalPost = value; }
        }
        #endregion

        #region 构造函数
        ///<summary>
        ///
        ///</summary>
        public ComponentType()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public ComponentType
        (
            string cOMPONENT_TYPE_ID,
            string sUPERIOR_COMPONENT,
            string cODE_SYSTEM_INDEX,
            string cOMPONENT_LEVEL,
            string cOMPTYPE_CHINESE_NAME,
            string cOMPTYPE_ENGLISH_NAME,
            string sHIP_PROVE_CODE,
            string lETTER_NUMBER,
            string mANUFACTURER,
            string uSE_POSITION,
            string cOMPONENT_STYLE,
            string sERVICE_PROVIDER,
            decimal dEFAULT_USE_RATE,
            string cREATOR, 
            decimal tIMING_TYPE,
            string hEADSHIP, 
            decimal sAFEEQUIPMENT,
            decimal sort_no,
            string detail
        )
        {
            _cOMPONENT_TYPE_ID = cOMPONENT_TYPE_ID;
            _sUPERIOR_COMPONENT = sUPERIOR_COMPONENT;
            _cODE_SYSTEM_INDEX = cODE_SYSTEM_INDEX;
            _cOMPONENT_LEVEL = cOMPONENT_LEVEL;
            _cOMPTYPE_CHINESE_NAME = cOMPTYPE_CHINESE_NAME;
            _cOMPTYPE_ENGLISH_NAME = cOMPTYPE_ENGLISH_NAME;
            _sHIP_PROVE_CODE = sHIP_PROVE_CODE;
            _lETTER_NUMBER = lETTER_NUMBER;
            _mANUFACTURER = mANUFACTURER;
            _uSE_POSITION = uSE_POSITION;
            _cOMPONENT_STYLE = cOMPONENT_STYLE;
            _sERVICE_PROVIDER = sERVICE_PROVIDER;
            _dEFAULT_USE_RATE = dEFAULT_USE_RATE;
            _cREATOR = cREATOR; 
            _tIMING_TYPE = tIMING_TYPE;
            _hEADSHIP = hEADSHIP; 
            _sAFEEQUIPMENT = sAFEEQUIPMENT;
            _sort_no = sort_no;
            _detail = detail;
        }
        #endregion

        #region 公共属性

        ///<summary>
        ///
        ///</summary>
        public string COMPONENT_TYPE_ID
        {
            get { return _cOMPONENT_TYPE_ID; }
            set { _cOMPONENT_TYPE_ID = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string SUPERIOR_COMPONENT
        {
            get { return _sUPERIOR_COMPONENT; }
            set { _sUPERIOR_COMPONENT = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string CODE_SYSTEM_INDEX
        {
            get { return _cODE_SYSTEM_INDEX; }
            set { _cODE_SYSTEM_INDEX = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string COMPONENT_LEVEL
        {
            get { return _cOMPONENT_LEVEL; }
            set { _cOMPONENT_LEVEL = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string COMPTYPE_CHINESE_NAME
        {
            get { return _cOMPTYPE_CHINESE_NAME; }
            set { _cOMPTYPE_CHINESE_NAME = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string COMPTYPE_ENGLISH_NAME
        {
            get { return _cOMPTYPE_ENGLISH_NAME; }
            set { _cOMPTYPE_ENGLISH_NAME = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string SHIP_PROVE_CODE
        {
            get { return _sHIP_PROVE_CODE; }
            set { _sHIP_PROVE_CODE = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string LETTER_NUMBER
        {
            get { return _lETTER_NUMBER; }
            set { _lETTER_NUMBER = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string MANUFACTURER
        {
            get { return _mANUFACTURER; }
            set { _mANUFACTURER = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string USE_POSITION
        {
            get { return _uSE_POSITION; }
            set { _uSE_POSITION = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string COMPONENT_STYLE
        {
            get { return _cOMPONENT_STYLE; }
            set { _cOMPONENT_STYLE = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string SERVICE_PROVIDER
        {
            get { return _sERVICE_PROVIDER; }
            set { _sERVICE_PROVIDER = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal DEFAULT_USE_RATE
        {
            get { return _dEFAULT_USE_RATE; }
            set { _dEFAULT_USE_RATE = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string CREATOR
        {
            get { return _cREATOR; }
            set { _cREATOR = value; }
        } 
        ///<summary>
        ///
        ///</summary>
        public decimal TIMING_TYPE
        {
            get { return _tIMING_TYPE; }
            set { _tIMING_TYPE = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string HEADSHIP
        {
            get { return _hEADSHIP; }
            set { _hEADSHIP = value; }
        } 

        ///<summary>
        ///
        ///</summary>
        public decimal SAFEEQUIPMENT
        {
            get { return _sAFEEQUIPMENT; }
            set { _sAFEEQUIPMENT = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal SORT_NO
        {
            get { return _sort_no; }
            set { _sort_no = value; }
        }
        public string DETAIL
        {
            get { return _detail; }
            set { _detail = value; }
        }
        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            ComponentType Unit = new ComponentType();
            Unit.COMPONENT_TYPE_ID = this.COMPONENT_TYPE_ID;
            Unit.SUPERIOR_COMPONENT = this.SUPERIOR_COMPONENT;
            Unit.CODE_SYSTEM_INDEX = this.CODE_SYSTEM_INDEX;
            Unit.COMPONENT_LEVEL = this.COMPONENT_LEVEL;
            Unit.COMPTYPE_CHINESE_NAME = this.COMPTYPE_CHINESE_NAME;
            Unit.COMPTYPE_ENGLISH_NAME = this.COMPTYPE_ENGLISH_NAME;
            Unit.SHIP_PROVE_CODE = this.SHIP_PROVE_CODE;
            Unit.LETTER_NUMBER = this.LETTER_NUMBER;
            Unit.MANUFACTURER = this.MANUFACTURER;
            Unit.USE_POSITION = this.USE_POSITION;
            Unit.COMPONENT_STYLE = this.COMPONENT_STYLE;
            Unit.SERVICE_PROVIDER = this.SERVICE_PROVIDER;
            Unit.DEFAULT_USE_RATE = this.DEFAULT_USE_RATE;
            Unit.CREATOR = this.CREATOR; 
            Unit.TIMING_TYPE = this.TIMING_TYPE;
            Unit.HEADSHIP = this.HEADSHIP; 
            Unit.SAFEEQUIPMENT = this.SAFEEQUIPMENT;
            Unit.SORT_NO = this.SORT_NO;
            Unit.DETAIL = this.DETAIL;
            return Unit;
        }
        #endregion

        public override string ToString()
        {
            string style = string.IsNullOrEmpty(_cOMPONENT_STYLE)?"":_cOMPONENT_STYLE.Trim();
            string menufactory = string.IsNullOrEmpty(_mANUFACTURER)?"":_mANUFACTURER.Trim();

            string re = menufactory +  style;
            if (re.ToUpper() == _cOMPTYPE_CHINESE_NAME.Trim().ToUpper()) 
            return _cOMPTYPE_CHINESE_NAME.Trim();
            else  
            return _cOMPTYPE_CHINESE_NAME + "(" + re + ")"  ;
        }

    }
}
