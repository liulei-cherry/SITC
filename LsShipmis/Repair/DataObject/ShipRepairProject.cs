/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：ShipRepairProject.cs
 * 创 建 人：徐正本
 * 创建时间：2013-9-18
 * 标    题：实体类
 * 功能描述：T_SHIP_REPAIR_PROJECT数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using Repair.Services;

namespace Repair.DataObject
{
    /// <summary>
    ///T_SHIP_REPAIR_PROJECT数据实体
    /// </summary>
    ///[Serializable]
    public partial class ShipRepairProject : CommonClass
    {
        #region 构造函数
        ///<summary> 
        ///
        ///</summary>
        public ShipRepairProject()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public ShipRepairProject
        (
            string pROJECTID,
            string pROJECTNAME,
            string pROJECTDETAIL,
            DateTime aPPLYDATE,
            string aPPLICANT,
            string wORKORDERID,
            DateTime aPPLYCOMPLETEDATE,
            DateTime rEALCOMPLETEDATE,
            decimal pROJECTSTATE,
            string aFFIRMANT,
            string cOMPLETEAFFIRMANT,
            decimal rUNNINGORDOCK,
            string rEPAIRSUBJECT,
            string sERVICEPROVIDER,
            string rEMARK,
            string sHIP_ID,
            string cURRENCYID,
            decimal cOSTCOUNT,
            string eQUIPMENTID,
            decimal sENDTOWARRANT,
            string aPPLYPOST,
            string vOUCHER_ID,
            string landOpinion
        )
        {
            this.PROJECTID = pROJECTID;
            this.PROJECTNAME = pROJECTNAME;
            this.PROJECTDETAIL = pROJECTDETAIL;
            this.APPLYDATE = aPPLYDATE;
            this.APPLICANT = aPPLICANT;
            this.WORKORDERID = wORKORDERID;
            this.APPLYCOMPLETEDATE = aPPLYCOMPLETEDATE;
            this.REALCOMPLETEDATE = rEALCOMPLETEDATE;
            this.PROJECTSTATE = pROJECTSTATE;
            this.AFFIRMANT = aFFIRMANT;
            this.COMPLETEAFFIRMANT = cOMPLETEAFFIRMANT;
            this.RUNNINGORDOCK = rUNNINGORDOCK;
            this.REPAIRSUBJECT = rEPAIRSUBJECT;
            this.SERVICEPROVIDER = sERVICEPROVIDER;
            this.REMARK = rEMARK;
            this.SHIP_ID = sHIP_ID;
            this.CURRENCYID = cURRENCYID;
            this.COSTCOUNT = cOSTCOUNT;
            this.EQUIPMENTID = eQUIPMENTID;
            this.SENDTOWARRANT = sENDTOWARRANT;
            this.APPLYPOST = aPPLYPOST;
            this.VOUCHER_ID = vOUCHER_ID;
            this.LandOpinion = landOpinion;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///
        ///</summary>
        public string PROJECTID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string PROJECTNAME { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string PROJECTDETAIL { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime APPLYDATE { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string APPLICANT { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string WORKORDERID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime APPLYCOMPLETEDATE { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime REALCOMPLETEDATE { get; set; }

        ///<summary>
        ///
        ///</summary>
        public decimal PROJECTSTATE { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string AFFIRMANT { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string COMPLETEAFFIRMANT { get; set; }

        ///<summary>
        ///
        ///</summary>
        public decimal RUNNINGORDOCK { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string REPAIRSUBJECT { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string SERVICEPROVIDER { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string REMARK { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string SHIP_ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string CURRENCYID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public decimal COSTCOUNT { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string EQUIPMENTID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public decimal SENDTOWARRANT { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string APPLYPOST { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string VOUCHER_ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string LandOpinion { get; set; }

        ///<summary>
        ///克隆一个对象
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            ShipRepairProject Unit = new ShipRepairProject();
            Unit.PROJECTID = this.PROJECTID;
            Unit.PROJECTNAME = this.PROJECTNAME;
            Unit.PROJECTDETAIL = this.PROJECTDETAIL;
            Unit.APPLYDATE = this.APPLYDATE;
            Unit.APPLICANT = this.APPLICANT;
            Unit.WORKORDERID = this.WORKORDERID;
            Unit.APPLYCOMPLETEDATE = this.APPLYCOMPLETEDATE;
            Unit.REALCOMPLETEDATE = this.REALCOMPLETEDATE;
            Unit.PROJECTSTATE = this.PROJECTSTATE;
            Unit.AFFIRMANT = this.AFFIRMANT;
            Unit.COMPLETEAFFIRMANT = this.COMPLETEAFFIRMANT;
            Unit.RUNNINGORDOCK = this.RUNNINGORDOCK;
            Unit.REPAIRSUBJECT = this.REPAIRSUBJECT;
            Unit.SERVICEPROVIDER = this.SERVICEPROVIDER;
            Unit.REMARK = this.REMARK;
            Unit.SHIP_ID = this.SHIP_ID;
            Unit.CURRENCYID = this.CURRENCYID;
            Unit.COSTCOUNT = this.COSTCOUNT;
            Unit.EQUIPMENTID = this.EQUIPMENTID;
            Unit.SENDTOWARRANT = this.SENDTOWARRANT;
            Unit.APPLYPOST = this.APPLYPOST;
            Unit.VOUCHER_ID = this.VOUCHER_ID;
            Unit.LandOpinion = this.LandOpinion;
            return Unit;
        }
        #endregion

        public override string GetId()
        {
            return this.PROJECTID;
        }

        public override string GetTypeName()
        {
            return "ShipRepairProject";
        }

        public override bool Update(out string err)
        {
            return ShipRepairProjectService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return ShipRepairProjectService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {

        }
    }
}
