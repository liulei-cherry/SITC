/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：WorkInfo.cs
 * 创 建 人：xuzhengben
 * 创建时间：2011/4/25
 * 标    题：实体类
 * 功能描述：T_WORKINFO数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using Maintenance.Services;
using ItemsManage.Services;
using ItemsManage.DataObject;

namespace Maintenance.DataObject
{
    /// <summary>
    ///T_WORKINFO数据实体.
    /// </summary>
    ///[Serializable]
    public partial class WorkInfo : CommonClass
    {
        #region 变量定义
        ///<summary>
        ///工作信息id
        ///</summary>
        private string _wORKINFOID;
        ///<summary>
        ///关联对象Id
        ///</summary>
        private string _rEFOBJID = String.Empty;
        ///<summary>
        ///信息类别（0表无关联；1表示关联设备；2表示关联备件）.
        ///</summary>
        private decimal _wORKINFOTYPE;
        ///<summary>
        ///工作信息名称.
        ///</summary>
        private string _wORKINFONAME = String.Empty;
        ///<summary>
        ///工作信息内容.
        ///</summary>
        private string _wORKINFODETAIL = String.Empty;
        ///<summary>
        ///工作信息状态（0停止，1启动）.
        ///</summary>
        private decimal _wORKINFOSTATE;
        ///<summary>
        ///定期定时（1定期，2定时，3定期＋定时）.
        ///</summary>
        private decimal _cIRCLEORTIMING;
        ///<summary>
        ///定期周期.
        ///</summary>
        private decimal _cIRCLEPERIOD;
        ///<summary>
        ///定期单位.
        ///</summary>
        private string _cIRCLEUNIT = String.Empty;
        ///<summary>
        ///定期前允差.
        ///</summary>
        private decimal _cIRCLEFRONTLIMIT;
        ///<summary>
        ///定期后允差.
        ///</summary>
        private decimal _cIRCLEBACKLIMIT;
        ///<summary>
        ///定期允差单位.
        ///</summary>
        private string _cIRCLELIMITUNIT = String.Empty;
        ///<summary>
        ///定时周期.
        ///</summary>
        private decimal _tIMINGPERIOD;
        ///<summary>
        ///定时前允差.
        ///</summary>
        private decimal _tIMINGFRONTLIMIT;
        ///<summary>
        ///定时后允差.
        ///</summary>
        private decimal _tIMINGBACKLIMIT;
        ///<summary>
        ///负责人岗位.
        ///</summary>
        private string _pRINCIPALPOST = String.Empty;
        ///<summary>
        ///确认人岗位.
        ///</summary>
        private string _cONFIRMPOST = String.Empty;
        ///<summary>
        ///检验项目（0表示否，1表示是）.
        ///</summary>
        private decimal _iSCHECKPROJECT;
        ///<summary>
        ///修理项目（0表示否，1表示是）.
        ///</summary>
        private decimal _iSREPAIRPROJECT;
        ///<summary>
        ///船舶ID
        ///</summary>
        private string _sHIP_ID = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _wORKINFOCODE = String.Empty;
        #endregion

        #region 构造函数
        ///<summary>
        ///基础工作信息表.
        ///</summary>
        public WorkInfo()
        {
        }
        ///<summary>
        ///基础工作信息表.
        ///</summary>
        public WorkInfo
        (
            string wORKINFOID,
            string rEFOBJID,
            decimal wORKINFOTYPE,
            string wORKINFONAME,
            string wORKINFODETAIL,
            decimal wORKINFOSTATE,
            decimal cIRCLEORTIMING,
            decimal cIRCLEPERIOD,
            string cIRCLEUNIT,
            decimal cIRCLEFRONTLIMIT,
            decimal cIRCLEBACKLIMIT,
            string cIRCLELIMITUNIT,
            decimal tIMINGPERIOD,
            decimal tIMINGFRONTLIMIT,
            decimal tIMINGBACKLIMIT,
            string pRINCIPALPOST,
            string cONFIRMPOST,
            decimal iSCHECKPROJECT,
            decimal iSREPAIRPROJECT,
            string sHIP_ID,
            string wORKINFOCODE
        )
        {
            _wORKINFOID = wORKINFOID;
            _rEFOBJID = rEFOBJID;
            _wORKINFOTYPE = wORKINFOTYPE;
            _wORKINFONAME = wORKINFONAME;
            _wORKINFODETAIL = wORKINFODETAIL;
            _wORKINFOSTATE = wORKINFOSTATE;
            _cIRCLEORTIMING = cIRCLEORTIMING;
            _cIRCLEPERIOD = cIRCLEPERIOD;
            _cIRCLEUNIT = cIRCLEUNIT;
            _cIRCLEFRONTLIMIT = cIRCLEFRONTLIMIT;
            _cIRCLEBACKLIMIT = cIRCLEBACKLIMIT;
            _cIRCLELIMITUNIT = cIRCLELIMITUNIT;
            _tIMINGPERIOD = tIMINGPERIOD;
            _tIMINGFRONTLIMIT = tIMINGFRONTLIMIT;
            _tIMINGBACKLIMIT = tIMINGBACKLIMIT;
            _pRINCIPALPOST = pRINCIPALPOST;
            _cONFIRMPOST = cONFIRMPOST;
            _iSCHECKPROJECT = iSCHECKPROJECT;
            _iSREPAIRPROJECT = iSREPAIRPROJECT;
            _sHIP_ID = sHIP_ID;
            _wORKINFOCODE = wORKINFOCODE;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///工作信息id
        ///</summary>
        public string WORKINFOID
        {
            get { return _wORKINFOID; }
            set { _wORKINFOID = value; }
        }

        ///<summary>
        ///关联对象Id
        ///</summary>
        public string REFOBJID
        {
            get { return _rEFOBJID; }
            set { _rEFOBJID = value; }
        }

        ///<summary>
        ///信息类别（0表无关联；1表示关联设备；2表示关联备件）.
        ///</summary>
        public decimal WORKINFOTYPE
        {
            get { return _wORKINFOTYPE; }
            set { _wORKINFOTYPE = value; }
        }

        ///<summary>
        ///工作信息名称.
        ///</summary>
        public string WORKINFONAME
        {
            get { return _wORKINFONAME; }
            set { _wORKINFONAME = value; }
        }

        ///<summary>
        ///工作信息内容.
        ///</summary>
        public string WORKINFODETAIL
        {
            get { return _wORKINFODETAIL; }
            set { _wORKINFODETAIL = value; }
        }

        ///<summary>
        ///工作信息状态（0停止，1启动）.
        ///</summary>
        public decimal WORKINFOSTATE
        {
            get { return _wORKINFOSTATE; }
            set { _wORKINFOSTATE = value; }
        }

        ///<summary>
        ///定期定时（1定期，2定时，3定期＋定时）.
        ///</summary>
        public decimal CIRCLEORTIMING
        {
            get { return _cIRCLEORTIMING; }
            set { _cIRCLEORTIMING = value; }
        }

        ///<summary>
        ///定期周期.
        ///</summary>
        public decimal CIRCLEPERIOD
        {
            get { return _cIRCLEPERIOD; }
            set { _cIRCLEPERIOD = value; }
        }

        ///<summary>
        ///定期单位.
        ///</summary>
        public string CIRCLEUNIT
        {
            get { return _cIRCLEUNIT; }
            set { _cIRCLEUNIT = value; }
        }

        ///<summary>
        ///定期前允差.
        ///</summary>
        public decimal CIRCLEFRONTLIMIT
        {
            get { return _cIRCLEFRONTLIMIT; }
            set { _cIRCLEFRONTLIMIT = value; }
        }

        ///<summary>
        ///定期后允差.
        ///</summary>
        public decimal CIRCLEBACKLIMIT
        {
            get { return _cIRCLEBACKLIMIT; }
            set { _cIRCLEBACKLIMIT = value; }
        }

        ///<summary>
        ///定期允差单位.
        ///</summary>
        public string CIRCLELIMITUNIT
        {
            get { return _cIRCLELIMITUNIT; }
            set { _cIRCLELIMITUNIT = value; }
        }

        ///<summary>
        ///定时周期.
        ///</summary>
        public decimal TIMINGPERIOD
        {
            get { return _tIMINGPERIOD; }
            set { _tIMINGPERIOD = value; }
        }

        ///<summary>
        ///定时前允差.
        ///</summary>
        public decimal TIMINGFRONTLIMIT
        {
            get { return _tIMINGFRONTLIMIT; }
            set { _tIMINGFRONTLIMIT = value; }
        }

        ///<summary>
        ///定时后允差.
        ///</summary>
        public decimal TIMINGBACKLIMIT
        {
            get { return _tIMINGBACKLIMIT; }
            set { _tIMINGBACKLIMIT = value; }
        }

        ///<summary>
        ///负责人岗位.
        ///</summary>
        public string PRINCIPALPOST
        {
            get { return _pRINCIPALPOST; }
            set { _pRINCIPALPOST = value; }
        }

        ///<summary>
        ///确认人岗位.
        ///</summary>
        public string CONFIRMPOST
        {
            get { return _cONFIRMPOST; }
            set { _cONFIRMPOST = value; }
        }

        ///<summary>
        ///检验项目（0表示否，1表示是）.
        ///</summary>
        public decimal ISCHECKPROJECT
        {
            get { return _iSCHECKPROJECT; }
            set { _iSCHECKPROJECT = value; }
        }

        ///<summary>
        ///修理项目（0表示否，1表示是）.
        ///</summary>
        public decimal ISREPAIRPROJECT
        {
            get { return _iSREPAIRPROJECT; }
            set { _iSREPAIRPROJECT = value; }
        }

        ///<summary>
        ///船舶ID
        ///</summary>
        public string SHIP_ID
        {
            get { return _sHIP_ID; }
            set { _sHIP_ID = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string WORKINFOCODE
        {
            get { return _wORKINFOCODE; }
            set { _wORKINFOCODE = value; }
        }
        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            WorkInfo Unit = new WorkInfo();
            Unit.WORKINFOID = this.WORKINFOID;
            Unit.REFOBJID = this.REFOBJID;
            Unit.WORKINFOTYPE = this.WORKINFOTYPE;
            Unit.WORKINFONAME = this.WORKINFONAME;
            Unit.WORKINFODETAIL = this.WORKINFODETAIL;
            Unit.WORKINFOSTATE = this.WORKINFOSTATE;
            Unit.CIRCLEORTIMING = this.CIRCLEORTIMING;
            Unit.CIRCLEPERIOD = this.CIRCLEPERIOD;
            Unit.CIRCLEUNIT = this.CIRCLEUNIT;
            Unit.CIRCLEFRONTLIMIT = this.CIRCLEFRONTLIMIT;
            Unit.CIRCLEBACKLIMIT = this.CIRCLEBACKLIMIT;
            Unit.CIRCLELIMITUNIT = this.CIRCLELIMITUNIT;
            Unit.TIMINGPERIOD = this.TIMINGPERIOD;
            Unit.TIMINGFRONTLIMIT = this.TIMINGFRONTLIMIT;
            Unit.TIMINGBACKLIMIT = this.TIMINGBACKLIMIT;
            Unit.PRINCIPALPOST = this.PRINCIPALPOST;
            Unit.CONFIRMPOST = this.CONFIRMPOST;
            Unit.ISCHECKPROJECT = this.ISCHECKPROJECT;
            Unit.ISREPAIRPROJECT = this.ISREPAIRPROJECT;
            Unit.SHIP_ID = this.SHIP_ID;
            Unit.WORKINFOCODE = this.WORKINFOCODE;
            return Unit;
        }
        #endregion
        public override string GetId()
        {
            return this._wORKINFOID;
        }

        public override string GetTypeName()
        {
            return "WorkInfo";
        }

        public override bool Update(out string err)
        {
            return WorkInfoService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return WorkInfoService.Instance.deleteUnit(this, out err);
        }
 
        private ComponentUnit compUnit;

        public ComponentUnit CompUnit
        {
            get { return compUnit; }
            set { compUnit = value; }
        }

        public override void FillThisObject()
        {
            string err;
            if (compUnit == null || (_wORKINFOTYPE == 1 && !_rEFOBJID.Equals(compUnit)))
            {
                compUnit = ComponentUnitService.Instance.getObject(_rEFOBJID, out err);
            }
        }

        public string LevelOfTheWork
        {
            get
            {
                //定期,和定期定时的,都看定期,否则看定时.
                int circleMonth = WorkInfoService.Instance.getCircleMonth((int)_cIRCLEPERIOD, _cIRCLEUNIT);
                if (_cIRCLEORTIMING == 1 || _cIRCLEORTIMING == 3)
                {
                    //定期2月以内为c级,5月以内d,9月以内e,18月以内f,36月以内g,36月以上h级.
                    if (circleMonth <= 0) return "";
                    else if (circleMonth < 2) return "c";
                    else if (circleMonth < 5) return "d";
                    else if (circleMonth < 9) return "e";
                    else if (circleMonth < 18) return "f";
                    else if (circleMonth < 36) return "g";
                    else return "h";
                }
                else
                {
                    //定期1000小时以内为c级,2000以内d,4000月以内e,8000月以内f,16000以内g,16000以上为h
                    if (_tIMINGPERIOD <= 0) return "";
                    else if (_tIMINGPERIOD < 1000) return "c";
                    else if (_tIMINGPERIOD < 2000) return "d";
                    else if (_tIMINGPERIOD < 4000) return "e";
                    else if (_tIMINGPERIOD < 8000) return "f";
                    else if (_tIMINGPERIOD < 16000) return "g";
                    else return "h";
                }
            }
        }
        public string CyclePhrase
        {
            get
            {
                string circlePhrse = "";
                if (_cIRCLEORTIMING == 1 || _cIRCLEORTIMING == 3)
                {
                    circlePhrse = _cIRCLEPERIOD.ToString() + _cIRCLEUNIT.Trim();
                }
                if (_cIRCLEORTIMING == 2 || _cIRCLEORTIMING == 3)
                {
                    circlePhrse += _tIMINGPERIOD.ToString() + "hours";
                }
                return circlePhrse;
            }
        }
    }
}
