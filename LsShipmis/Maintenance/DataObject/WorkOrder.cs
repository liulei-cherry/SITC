/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：WorkOrder.cs
 * 创 建 人：徐正本
 * 创建时间：2010-6-21
 * 标    题：实体类
 * 功能描述：WorkOrder数据实体类
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
    ///WorkOrder数据实体.
    /// </summary>
    ///[Serializable]
    public partial class WorkOrder : CommonClass
    {
        #region 变量定义
        ///<summary>
        ///工单Id
        ///</summary>
        private string _wORKORDERID;
        ///<summary>
        ///工作信息Id
        ///</summary>
        private string _wORKINFOID = String.Empty;
        ///<summary>
        ///工单名称（默认取工作信息名称，对于合并的工单由用户起名）.
        ///</summary>
        private string _wORKORDERNAME = String.Empty;
        ///<summary>
        ///工单状态（1计划；2超期；3免做；4待确认；5超期待确认）.
        ///</summary>
        private decimal _wORKORDERSTATE;
        ///<summary>
        ///预计执行日期（定时定期都有）.
        ///</summary>
        private DateTime _pLANEXEDATE;
        ///<summary>
        ///完工日期（也就是实际执行日期，定时定期都有）.
        ///</summary>
        private DateTime _cOMPLETEDDATE;
        ///<summary>
        ///前允差日期（仅定期）.
        ///</summary>
        private DateTime _cIRCLEFRONTLIMITDATE;
        ///<summary>
        ///后允差日期（仅定期）.
        ///</summary>
        private DateTime _cIRCLEBACKLIMITDATE;
        ///<summary>
        ///预计执行表值（仅定时）.
        ///</summary>
        private decimal _nEXTVALUE;
        ///<summary>
        ///实际执行表值（仅定时）.
        ///</summary>
        private decimal _eXCUTEVALUE;
        ///<summary>
        ///定时前允差小时数（仅定时）.
        ///</summary>
        private decimal _tIMINGFRONTLIMITHOURS;
        ///<summary>
        ///定时后允差小时数（仅定时）.
        ///</summary>
        private decimal _tIMINGBACKLIMITHOURS;
        ///<summary>
        ///是否为合并的工单.
        ///</summary>
        private decimal _iSCOMBINEDORDER;
        ///<summary>
        ///是否是临时工单（0表示否，1表示是）.
        ///</summary>
        private decimal _iSTEMPWORKORDER;
        ///<summary>
        ///被某工作所代替（这个Id是指那个替代的Id）.
        ///</summary>
        private string _iNSTEADEDWKID = String.Empty;
        ///<summary>
        ///工作执行者.
        ///</summary>
        private string _wORKEXECUTOR = String.Empty;
        ///<summary>
        ///工作确认者.
        ///</summary>
        private string _wORKCONFIRMOR = String.Empty;
        ///<summary>
        ///工作完成情况.
        ///</summary>
        private string _wORKCOMPLETEDINFO = String.Empty;
        ///<summary>
        ///工作说明.
        ///</summary>
        private string _wORKDESCRIPTION = String.Empty;
        ///<summary>
        ///责任人岗位.
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
        ///船舶Id
        ///</summary>
        private string _sHIP_ID = String.Empty;
        ///<summary>
        ///生成时间.
        ///</summary>
        private DateTime _cREATEDATE;
        #endregion
        private string circleortimingname;

        public string Circleortimingname
        {
            get { return circleortimingname; }
            set { circleortimingname = value; }
        }
        private string workorderstatename;

        public string Workorderstatename
        {
            get { return workorderstatename; }
            set { workorderstatename = value; }
        }
        private string principalpostname;

        public string Principalpostname
        {
            get { return principalpostname; }
            set { principalpostname = value; }
        }

        private string confirmpostname;

        public string Confirmpostname
        {
            get { return confirmpostname; }
            set { confirmpostname = value; }
        }

        private int estimatevalue;

        public int Estimatevalue
        {
            get { return estimatevalue; }
            set { estimatevalue = value; }
        }

        private string insteadedwkname;

        public string Insteadedwkname
        {
            get { return insteadedwkname; }
            set { insteadedwkname = value; }
        }

        private WorkInfo theWorkInfo;

        public WorkInfo TheWorkInfo
        {
            get {
                FillThisObject();
                return theWorkInfo; }
            set { theWorkInfo = value; }
        }

        #region 构造函数
        ///<summary>
        ///
        ///</summary>
        public WorkOrder()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public WorkOrder
        (
            string wORKORDERID,
            string wORKINFOID,
            string wORKORDERNAME,
            decimal wORKORDERSTATE,
            DateTime pLANEXEDATE,
            DateTime cOMPLETEDDATE,
            DateTime cIRCLEFRONTLIMITDATE,
            DateTime cIRCLEBACKLIMITDATE,
            decimal nEXTVALUE,
            decimal eXCUTEVALUE,
            decimal tIMINGFRONTLIMITHOURS,
            decimal tIMINGBACKLIMITHOURS,
            decimal iSCOMBINEDORDER,
            decimal iSTEMPWORKORDER,
            string iNSTEADEDWKID,
            string wORKEXECUTOR,
            string wORKCONFIRMOR,
            string wORKCOMPLETEDINFO,
            string wORKDESCRIPTION,
            string pRINCIPALPOST,
            string cONFIRMPOST,
            decimal iSCHECKPROJECT,
            decimal iSREPAIRPROJECT,
            string sHIP_ID,
            DateTime cREATEDATE
        )
        {
            _wORKORDERID = wORKORDERID;
            _wORKINFOID = wORKINFOID;
            _wORKORDERNAME = wORKORDERNAME;
            _wORKORDERSTATE = wORKORDERSTATE;
            _pLANEXEDATE = pLANEXEDATE;
            _cOMPLETEDDATE = cOMPLETEDDATE;
            _cIRCLEFRONTLIMITDATE = cIRCLEFRONTLIMITDATE;
            _cIRCLEBACKLIMITDATE = cIRCLEBACKLIMITDATE;
            _nEXTVALUE = nEXTVALUE;
            _eXCUTEVALUE = eXCUTEVALUE;
            _tIMINGFRONTLIMITHOURS = tIMINGFRONTLIMITHOURS;
            _tIMINGBACKLIMITHOURS = tIMINGBACKLIMITHOURS;
            _iSCOMBINEDORDER = iSCOMBINEDORDER;
            _iSTEMPWORKORDER = iSTEMPWORKORDER;
            _iNSTEADEDWKID = iNSTEADEDWKID;
            _wORKEXECUTOR = wORKEXECUTOR;
            _wORKCONFIRMOR = wORKCONFIRMOR;
            _wORKCOMPLETEDINFO = wORKCOMPLETEDINFO;
            _wORKDESCRIPTION = wORKDESCRIPTION;
            _pRINCIPALPOST = pRINCIPALPOST;
            _cONFIRMPOST = cONFIRMPOST;
            _iSCHECKPROJECT = iSCHECKPROJECT;
            _iSREPAIRPROJECT = iSREPAIRPROJECT;
            _sHIP_ID = sHIP_ID;
            _cREATEDATE = cREATEDATE;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///工单Id
        ///</summary>
        public string WORKORDERID
        {
            get { return _wORKORDERID; }
            set { _wORKORDERID = value; }
        }

        ///<summary>
        ///工作信息Id
        ///</summary>
        public string WORKINFOID
        {
            get { return _wORKINFOID; }
            set { _wORKINFOID = value; }
        }

        ///<summary>
        ///工单名称（默认取工作信息名称，对于合并的工单由用户起名）.
        ///</summary>
        public string WORKORDERNAME
        {
            get { return _wORKORDERNAME; }
            set { _wORKORDERNAME = value; }
        }

        ///<summary>
        ///工单状态（1计划；2超期；3免做；4待确认；5超期待确认）.
        ///</summary>
        public decimal WORKORDERSTATE
        {
            get { return _wORKORDERSTATE; }
            set { _wORKORDERSTATE = value; }
        }

        ///<summary>
        ///预计执行日期（定时定期都有）.
        ///</summary>
        public DateTime PLANEXEDATE
        {
            get { return _pLANEXEDATE; }
            set { _pLANEXEDATE = value; }
        }

        ///<summary>
        ///完工日期（也就是实际执行日期，定时定期都有）.
        ///</summary>
        public DateTime COMPLETEDDATE
        {
            get { return _cOMPLETEDDATE; }
            set { _cOMPLETEDDATE = value; }
        }

        ///<summary>
        ///前允差日期（仅定期）.
        ///</summary>
        public DateTime CIRCLEFRONTLIMITDATE
        {
            get { return _cIRCLEFRONTLIMITDATE; }
            set { _cIRCLEFRONTLIMITDATE = value; }
        }

        ///<summary>
        ///后允差日期（仅定期）.
        ///</summary>
        public DateTime CIRCLEBACKLIMITDATE
        {
            get { return _cIRCLEBACKLIMITDATE; }
            set { _cIRCLEBACKLIMITDATE = value; }
        }

        ///<summary>
        ///预计执行表值（仅定时）.
        ///</summary>
        public decimal NEXTVALUE
        {
            get { return _nEXTVALUE; }
            set { _nEXTVALUE = value; }
        }

        ///<summary>
        ///实际执行表值（仅定时）.
        ///</summary>
        public decimal EXCUTEVALUE
        {
            get { return _eXCUTEVALUE; }
            set { _eXCUTEVALUE = value; }
        }

        ///<summary>
        ///定时前允差小时数（仅定时）.
        ///</summary>
        public decimal TIMINGFRONTLIMITHOURS
        {
            get { return _tIMINGFRONTLIMITHOURS; }
            set { _tIMINGFRONTLIMITHOURS = value; }
        }

        ///<summary>
        ///定时后允差小时数（仅定时）.
        ///</summary>
        public decimal TIMINGBACKLIMITHOURS
        {
            get { return _tIMINGBACKLIMITHOURS; }
            set { _tIMINGBACKLIMITHOURS = value; }
        }

        ///<summary>
        ///是否为合并的工单.
        ///</summary>
        public decimal ISCOMBINEDORDER
        {
            get { return _iSCOMBINEDORDER; }
            set { _iSCOMBINEDORDER = value; }
        }

        ///<summary>
        ///是否是临时工单（0表示否，1表示是）.
        ///</summary>
        public decimal ISTEMPWORKORDER
        {
            get { return _iSTEMPWORKORDER; }
            set { _iSTEMPWORKORDER = value; }
        }

        ///<summary>
        ///被某工作所代替（这个Id是指那个替代的Id）.
        ///</summary>
        public string INSTEADEDWKID
        {
            get { return _iNSTEADEDWKID; }
            set { _iNSTEADEDWKID = value; }
        }

        ///<summary>
        ///工作执行者.
        ///</summary>
        public string WORKEXECUTOR
        {
            get { return _wORKEXECUTOR; }
            set { _wORKEXECUTOR = value; }
        }

        ///<summary>
        ///工作确认者.
        ///</summary>
        public string WORKCONFIRMOR
        {
            get { return _wORKCONFIRMOR; }
            set { _wORKCONFIRMOR = value; }
        }

        ///<summary>
        ///工作完成情况.
        ///</summary>
        public string WORKCOMPLETEDINFO
        {
            get { return _wORKCOMPLETEDINFO; }
            set { _wORKCOMPLETEDINFO = value; }
        }

        ///<summary>
        ///工作说明.
        ///</summary>
        public string WORKDESCRIPTION
        {
            get { return _wORKDESCRIPTION; }
            set { _wORKDESCRIPTION = value; }
        }

        ///<summary>
        ///责任人岗位.
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
        ///船舶Id
        ///</summary>
        public string SHIP_ID
        {
            get { return _sHIP_ID; }
            set { _sHIP_ID = value; }
        }

        ///<summary>
        ///生成时间.
        ///</summary>
        public DateTime CREATEDATE
        {
            get { return _cREATEDATE; }
            set { _cREATEDATE = value; }
        }

        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            WorkOrder Unit = new WorkOrder();
            Unit.WORKORDERID = this.WORKORDERID;
            Unit.WORKINFOID = this.WORKINFOID;
            Unit.WORKORDERNAME = this.WORKORDERNAME;
            Unit.WORKORDERSTATE = this.WORKORDERSTATE;
            Unit.PLANEXEDATE = this.PLANEXEDATE;
            Unit.COMPLETEDDATE = this.COMPLETEDDATE;
            Unit.CIRCLEFRONTLIMITDATE = this.CIRCLEFRONTLIMITDATE;
            Unit.CIRCLEBACKLIMITDATE = this.CIRCLEBACKLIMITDATE;
            Unit.NEXTVALUE = this.NEXTVALUE;
            Unit.EXCUTEVALUE = this.EXCUTEVALUE;
            Unit.TIMINGFRONTLIMITHOURS = this.TIMINGFRONTLIMITHOURS;
            Unit.TIMINGBACKLIMITHOURS = this.TIMINGBACKLIMITHOURS;
            Unit.ISCOMBINEDORDER = this.ISCOMBINEDORDER;
            Unit.ISTEMPWORKORDER = this.ISTEMPWORKORDER;
            Unit.INSTEADEDWKID = this.INSTEADEDWKID;
            Unit.WORKEXECUTOR = this.WORKEXECUTOR;
            Unit.WORKCONFIRMOR = this.WORKCONFIRMOR;
            Unit.WORKCOMPLETEDINFO = this.WORKCOMPLETEDINFO;
            Unit.WORKDESCRIPTION = this.WORKDESCRIPTION;
            Unit.PRINCIPALPOST = this.PRINCIPALPOST;
            Unit.CONFIRMPOST = this.CONFIRMPOST;
            Unit.ISCHECKPROJECT = this.ISCHECKPROJECT;
            Unit.ISREPAIRPROJECT = this.ISREPAIRPROJECT;
            Unit.SHIP_ID = this.SHIP_ID;
            Unit.CREATEDATE = this.CREATEDATE;
            return Unit;
        }
        #endregion
        public override string GetId()
        {
            return this._wORKORDERID;
        }

        public override string GetTypeName()
        {
            return "WorkOrder";
        }

        public override bool Update(out string err)
        {
            return WorkOrderService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return WorkOrderService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            string err;
            if (theWorkInfo==null && !string.IsNullOrEmpty(WORKINFOID))
            {
                theWorkInfo = WorkInfoService.Instance.getObject(_wORKINFOID,out err);
            }
            WorkOrderService.Instance.fillAllWorkOrderInfo(this, out err);
        }
        public string LevelOfTheWork
        {
            get
            {
                FillThisObject();
                if (theWorkInfo == null || theWorkInfo.IsWrong)
                {
                    return "";
                }
                return theWorkInfo.LevelOfTheWork;
            }
        }
        public string CyclePhrase
        {
            get
            {
                FillThisObject();
                if (theWorkInfo == null || theWorkInfo.IsWrong)
                {
                    return "";
                }
                return theWorkInfo.CyclePhrase;
            }
        }
    }
}
