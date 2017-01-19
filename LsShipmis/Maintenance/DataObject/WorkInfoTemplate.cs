/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：WorkInfoTemplate.cs
 * 创 建 人：徐正本
 * 创建时间：2010-7-1
 * 标    题：实体类
 * 功能描述：T_WORKINFO_TEMPLATE数据实体类
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
    ///T_WORKINFO_TEMPLATE数据实体.
    /// </summary>
    ///[Serializable]
    public partial class WorkInfoTemplate : CommonClass
    {
        #region 变量定义
        ///<summary>
        ///主键.
        ///</summary>
        private string _wORKINFO_TEMPLATE_ID;
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
        ///周期的单位.
        ///</summary>
        private string _pERIODICAL = String.Empty;
        ///<summary>
        ///备注.
        ///</summary>
        private string _rEMARK = String.Empty;
        ///<summary>
        ///类别.
        ///</summary>
        private string _cLASS = String.Empty;
        #endregion

        #region 构造函数
        ///<summary>
        ///
        ///</summary>
        public WorkInfoTemplate()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public WorkInfoTemplate
        (
            string wORKINFO_TEMPLATE_ID,
            string cOMPONENTREFERENCE,
            string iTEMNAME,
            string iTEMCONTENT,
            decimal pERIOD,
            string pERIODICAL,
            string rEMARK,
            string cLASS
        )
        {
            _wORKINFO_TEMPLATE_ID = wORKINFO_TEMPLATE_ID;
            _cOMPONENTREFERENCE = cOMPONENTREFERENCE;
            _iTEMNAME = iTEMNAME;
            _iTEMCONTENT = iTEMCONTENT;
            _pERIOD = pERIOD;
            _pERIODICAL = pERIODICAL;
            _rEMARK = rEMARK;
            _cLASS = cLASS;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///主键.
        ///</summary>
        public string WORKINFO_TEMPLATE_ID
        {
            get { return _wORKINFO_TEMPLATE_ID; }
            set { _wORKINFO_TEMPLATE_ID = value; }
        }

        ///<summary>
        ///相关设备.
        ///</summary>
        public string COMPONENTREFERENCE
        {
            get { return _cOMPONENTREFERENCE; }
            set { _cOMPONENTREFERENCE = value; }
        }

        ///<summary>
        ///保养项目.
        ///</summary>
        public string ITEMNAME
        {
            get { return _iTEMNAME; }
            set { _iTEMNAME = value; }
        }

        ///<summary>
        ///保养内容.
        ///</summary>
        public string ITEMCONTENT
        {
            get { return _iTEMCONTENT; }
            set { _iTEMCONTENT = value; }
        }

        ///<summary>
        ///预检周期.
        ///</summary>
        public decimal PERIOD
        {
            get { return _pERIOD; }
            set { _pERIOD = value; }
        }

        ///<summary>
        ///周期的单位.
        ///</summary>
        public string PERIODICAL
        {
            get { return _pERIODICAL; }
            set { _pERIODICAL = value; }
        }

        ///<summary>
        ///备注.
        ///</summary>
        public string REMARK
        {
            get { return _rEMARK; }
            set { _rEMARK = value; }
        }

        ///<summary>
        ///备注.
        ///</summary>
        public string CLASS
        {
            get { return _cLASS; }
            set { _cLASS = value; }
        }

        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            WorkInfoTemplate Unit = new WorkInfoTemplate();
            Unit.WORKINFO_TEMPLATE_ID = this.WORKINFO_TEMPLATE_ID;
            Unit.COMPONENTREFERENCE = this.COMPONENTREFERENCE;
            Unit.ITEMNAME = this.ITEMNAME;
            Unit.ITEMCONTENT = this.ITEMCONTENT;
            Unit.PERIOD = this.PERIOD;
            Unit.PERIODICAL = this.PERIODICAL;
            Unit.REMARK = this.REMARK;
            Unit.CLASS = this.CLASS;
            return Unit;
        }
        #endregion
        public override string GetId()
        {
            return this._wORKINFO_TEMPLATE_ID;
        }

        public override string GetTypeName()
        {
            return "WorkInfoTemplate";
        }

        public override bool Update(out string err)
        {
            return WorkInfoTemplateService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return WorkInfoTemplateService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {

        }
    }
}
