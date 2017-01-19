/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：VOUCHER.cs
 * 创 建 人：王鹏程
 * 创建时间：2012/3/22
 * 标    题：实体类
 * 功能描述：T_COST_VOUCHER数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using Cost.Services;

namespace Cost.DataObject
{
    /// <summary>
    ///T_COST_VOUCHER数据实体.
    /// </summary>
    ///[Serializable]
    public partial class VOUCHER : CommonClass
    {
        #region 构造函数
        ///<summary> 
        ///单日凭证.
        ///</summary>
        public VOUCHER()
        {
        }
        ///<summary>
        ///单日凭证.
        ///</summary>
        public VOUCHER
        (
            string vOUCHER_ID,
            string bUDGET_ID,
            string vOUCHER_NUM,
            string aPPLY_COMPANY,
            DateTime vOUCHER_DATE,
            string sHIP_OWNER,
            string cURRENCY_ID,
            string aMOUNT_UP,
            string aMOUNT_LOW,
            string pAYEE,
            int iNVOICE_NUM,
            string aPPLICANT,
            string aPPROVER,
            string aPPROVER2,
            int cURRENT_STATE,
            string bUSINESS_CODE
        )
        {
            this.VOUCHER_ID = vOUCHER_ID;
            this.BUDGET_ID = bUDGET_ID;
            this.VOUCHER_NUM = vOUCHER_NUM;
            this.APPLY_COMPANY = aPPLY_COMPANY;
            this.VOUCHER_DATE = vOUCHER_DATE;
            this.SHIP_OWNER = sHIP_OWNER;
            this.CURRENCY_ID = cURRENCY_ID;
            this.AMOUNT_UP = aMOUNT_UP;
            this.AMOUNT_LOW = aMOUNT_LOW;
            this.PAYEE = pAYEE;
            this.INVOICE_NUM = iNVOICE_NUM;
            this.APPLICANT = aPPLICANT;
            this.APPROVER = aPPROVER;
            this.APPROVER2 = aPPROVER2;
            this.CURRENT_STATE = cURRENT_STATE;
            this.BUSINESS_CODE = bUSINESS_CODE;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///凭证ID
        ///</summary>
        public string VOUCHER_ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string BUDGET_ID { get; set; }

        ///<summary>
        ///凭证号.
        ///</summary>
        public string VOUCHER_NUM { get; set; }

        ///<summary>
        ///项目说明.
        ///
        ///</summary>
        public string APPLY_COMPANY { get; set; }

        ///<summary>
        ///付款日期.
        ///
        ///</summary>
        public DateTime VOUCHER_DATE { get; set; }

        ///<summary>
        ///船东.
        ///</summary>
        public string SHIP_OWNER { get; set; }

        ///<summary>
        ///币种.
        ///</summary>
        public string CURRENCY_ID { get; set; }

        ///<summary>
        ///金额大写.
        ///</summary>
        public string AMOUNT_UP { get; set; }

        ///<summary>
        ///金额小写.
        ///</summary>
        public string AMOUNT_LOW { get; set; }

        ///<summary>
        ///收款人.
        ///
        ///</summary>
        public string PAYEE { get; set; }

        ///<summary>
        ///发票数.
        ///</summary>
        public int INVOICE_NUM { get; set; }

        ///<summary>
        ///申请人.
        ///</summary>
        public string APPLICANT { get; set; }

        ///<summary>
        ///第一个批准人.
        ///
        ///
        ///</summary>
        public string APPROVER { get; set; }

        ///<summary>
        ///第二个批准人.
        ///</summary>
        public string APPROVER2 { get; set; }

        ///<summary>
        ///状态（1:未提交; 2:审核中; 3:被打回; 4:审批完成; 5:已同步SAP; 9:已作废）.
        ///</summary>
        public int CURRENT_STATE { get; set; }

        ///<summary>
        ///与对应业务的关联码.
        ///</summary>
        public string BUSINESS_CODE { get; set; }

        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            VOUCHER Unit = new VOUCHER();
            Unit.VOUCHER_ID = this.VOUCHER_ID;
            Unit.BUDGET_ID = this.BUDGET_ID;
            Unit.VOUCHER_NUM = this.VOUCHER_NUM;
            Unit.APPLY_COMPANY = this.APPLY_COMPANY;
            Unit.VOUCHER_DATE = this.VOUCHER_DATE;
            Unit.SHIP_OWNER = this.SHIP_OWNER;
            Unit.CURRENCY_ID = this.CURRENCY_ID;
            Unit.AMOUNT_UP = this.AMOUNT_UP;
            Unit.AMOUNT_LOW = this.AMOUNT_LOW;
            Unit.PAYEE = this.PAYEE;
            Unit.INVOICE_NUM = this.INVOICE_NUM;
            Unit.APPLICANT = this.APPLICANT;
            Unit.APPROVER = this.APPROVER;
            Unit.APPROVER2 = this.APPROVER2;
            Unit.CURRENT_STATE = this.CURRENT_STATE;
            Unit.BUSINESS_CODE = this.BUSINESS_CODE;
            return Unit;
        }
        #endregion

        public override string GetId()
        {
            return this.VOUCHER_ID;
        }

        public override string GetTypeName()
        {
            return "VOUCHER";
        }

        public override bool Update(out string err)
        {
            return VOUCHERService.Instance.saveUnit(this, out err);
        }

        public string Update()
        {
            return VOUCHERService.Instance.saveUnit(this);
        }

        public override bool Delete(out string err)
        {
            return VOUCHERService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {

        }
    }
}
