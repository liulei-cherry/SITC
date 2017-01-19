/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：HOilLuboilReport.cs
 * 创 建 人：王鹏程
 * 创建时间：2012/3/23
 * 标    题：实体类
 * 功能描述：T_HOIL_LUBOIL_REPORT数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using Oil.Services;

namespace Oil.DataObject
{
    /// <summary>
    ///T_HOIL_LUBOIL_REPORT数据实体.
    /// </summary>
    ///[Serializable]
    public partial class HOilLuboilReport : CommonClass
    {
        #region 构造函数
        ///<summary> 
        ///月度滑油报告.
        ///</summary>
        public HOilLuboilReport()
        {
        }
        ///<summary>
        ///月度滑油报告.
        ///</summary>
        public HOilLuboilReport
        (
            string rEPORT_ID,
            string sHIP_ID,
            DateTime rEPORT_DATE,
            string rEMARK,
            string aPPROVER,
            string aPPROVER2,
            decimal cHECKED
        )
        {
            this.REPORT_ID = rEPORT_ID;
            this.SHIP_ID = sHIP_ID;
            this.REPORT_DATE = rEPORT_DATE;
            this.REMARK = rEMARK;
            this.APPROVER = aPPROVER;
            this.APPROVER2 = aPPROVER2;
            this.CHECKED = cHECKED;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///ID
        ///</summary>
        public string REPORT_ID { get; set; }

        ///<summary>
        ///船舶ID
        ///</summary>
        public string SHIP_ID { get; set; }

        ///<summary>
        ///报告日期.
        ///</summary>
        public DateTime REPORT_DATE { get; set; }

        ///<summary>
        ///备注.
        ///</summary>
        public string REMARK { get; set; }

        ///<summary>
        ///第一个批准人.
        ///
        ///
        ///</summary>
        public string APPROVER { get; set; }

        ///<summary>
        ///第二个批准人.
        ///
        ///
        ///</summary>
        public string APPROVER2 { get; set; }

        ///<summary>
        ///审核：0未审批（船舶端），1已审批（船舶端），2岸端审核通过并传送给SAP
        ///</summary>
        public decimal CHECKED { get; set; }

        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            HOilLuboilReport Unit = new HOilLuboilReport();
            Unit.REPORT_ID = this.REPORT_ID;
            Unit.SHIP_ID = this.SHIP_ID;
            Unit.REPORT_DATE = this.REPORT_DATE;
            Unit.REMARK = this.REMARK;
            Unit.APPROVER = this.APPROVER;
            Unit.APPROVER2 = this.APPROVER2;
            Unit.CHECKED = this.CHECKED;
            return Unit;
        }
        #endregion

        public override string GetId()
        {
            return this.REPORT_ID;
        }

        public override string GetTypeName()
        {
            return "HOilLuboilReport";
        }

        public override bool Update(out string err)
        {
            return HOilLuboilReportService.Instance.saveUnit(this, out err);
        }

        public string Update()
        {
            return HOilLuboilReportService.Instance.saveUnit(this);
        }

        public override bool Delete(out string err)
        {
            return HOilLuboilReportService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {

        }
    }
}
