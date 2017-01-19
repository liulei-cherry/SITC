/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：ReportMechatronikMaintain.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/12/5
 * 标    题：实体类
 * 功能描述：T_REPORT_MECHATRONIK_MAINTAIN数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using CustomerTable.Haifeng.Services;

namespace CustomerTable.Haifeng.DataObject
{
    /// <summary>
    ///T_REPORT_MECHATRONIK_MAINTAIN数据实体.
    /// </summary>
    ///[Serializable]
    public partial class ReportMechatronikMaintain : CommonClass
    {
        #region 构造函数
        ///<summary> 
        ///
        ///</summary>
        public ReportMechatronikMaintain()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public ReportMechatronikMaintain
        (
            string rEPORT_ID,
            string fILE_ID,
            DateTime fILE_DATE,
            string sHIP_ID,
            string vOYAGE,
            DateTime rEPORT_DATE,
            DateTime bEGIN_DATE,
            DateTime eND_DATE,
            string cHUAN_ZHANG,
            string lUN_JI_ZHANG,
            string dA_GUAN_LUN,
            string eR_GUAN_LUN,
            string sAN_GUAN_LUN,
            string dIAN_JI_YUAN,
            string uSE_CONDITION,
            string uNDONE_PROJECT,
            string pROBLEM,
            string tEMPORARY_PROJECT,
            string vERIFY_SUGGESTION
        )
        {
            this.REPORT_ID = rEPORT_ID;
            this.FILE_ID = fILE_ID;
            this.FILE_DATE = fILE_DATE;
            this.SHIP_ID = sHIP_ID;
            this.VOYAGE = vOYAGE;
            this.REPORT_DATE = rEPORT_DATE;
            this.BEGIN_DATE = bEGIN_DATE;
            this.END_DATE = eND_DATE;
            this.CHUAN_ZHANG = cHUAN_ZHANG;
            this.LUN_JI_ZHANG = lUN_JI_ZHANG;
            this.DA_GUAN_LUN = dA_GUAN_LUN;
            this.ER_GUAN_LUN = eR_GUAN_LUN;
            this.SAN_GUAN_LUN = sAN_GUAN_LUN;
            this.DIAN_JI_YUAN = dIAN_JI_YUAN;
            this.USE_CONDITION = uSE_CONDITION;
            this.UNDONE_PROJECT = uNDONE_PROJECT;
            this.PROBLEM = pROBLEM;
            this.TEMPORARY_PROJECT = tEMPORARY_PROJECT;
            this.VERIFY_SUGGESTION = vERIFY_SUGGESTION;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///记录编号.
        ///</summary>
        public string REPORT_ID { get; set; }

        ///<summary>
        ///文件ID
        ///</summary>
        public string FILE_ID { get; set; }

        ///<summary>
        ///年月日.
        ///</summary>
        public DateTime FILE_DATE { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string SHIP_ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string VOYAGE { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime REPORT_DATE { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime BEGIN_DATE { get; set; }

        ///<summary>
        ///
        ///</summary>
        public DateTime END_DATE { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string CHUAN_ZHANG { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string LUN_JI_ZHANG { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string DA_GUAN_LUN { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string ER_GUAN_LUN { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string SAN_GUAN_LUN { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string DIAN_JI_YUAN { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string USE_CONDITION { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string UNDONE_PROJECT { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string PROBLEM { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string TEMPORARY_PROJECT { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string VERIFY_SUGGESTION { get; set; }

        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            ReportMechatronikMaintain Unit = new ReportMechatronikMaintain();
            Unit.REPORT_ID = this.REPORT_ID;
            Unit.FILE_ID = this.FILE_ID;
            Unit.FILE_DATE = this.FILE_DATE;
            Unit.SHIP_ID = this.SHIP_ID;
            Unit.VOYAGE = this.VOYAGE;
            Unit.REPORT_DATE = this.REPORT_DATE;
            Unit.BEGIN_DATE = this.BEGIN_DATE;
            Unit.END_DATE = this.END_DATE;
            Unit.CHUAN_ZHANG = this.CHUAN_ZHANG;
            Unit.LUN_JI_ZHANG = this.LUN_JI_ZHANG;
            Unit.DA_GUAN_LUN = this.DA_GUAN_LUN;
            Unit.ER_GUAN_LUN = this.ER_GUAN_LUN;
            Unit.SAN_GUAN_LUN = this.SAN_GUAN_LUN;
            Unit.DIAN_JI_YUAN = this.DIAN_JI_YUAN;
            Unit.USE_CONDITION = this.USE_CONDITION;
            Unit.UNDONE_PROJECT = this.UNDONE_PROJECT;
            Unit.PROBLEM = this.PROBLEM;
            Unit.TEMPORARY_PROJECT = this.TEMPORARY_PROJECT;
            Unit.VERIFY_SUGGESTION = this.VERIFY_SUGGESTION;
            return Unit;
        }
        #endregion

        public override string GetId()
        {
            return this.REPORT_ID;
        }

        public override string GetTypeName()
        {
            return "ReportMechatronikMaintain";
        }

        public override bool Update(out string err)
        {
            return ReportMechatronikMaintainService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return ReportMechatronikMaintainService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {

        }
    }
}
