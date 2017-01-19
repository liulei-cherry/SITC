/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：ACTUAL_COSTS.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-7-4
 * 标    题：实体类
 * 功能描述：T_COST_ACTUAL_COSTS数据实体类
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
    ///T_COST_ACTUAL_COSTS数据实体.
    /// </summary>
    ///[Serializable]
    public partial class ACTUAL_COSTS : CommonClass
    {
        #region 构造函数

        ///<summary> 
        ///实际发生费用Actual Costs
        ///</summary>
        public ACTUAL_COSTS()
        {
        }
        ///<summary>
        ///实际发生费用Actual Costs
        ///</summary>
        public ACTUAL_COSTS
        (
            string cOSTS_ID,
            string cUSTOMER,
            string dESCRIPTION,
            decimal eSTIMATE_AMOUNT,
            decimal aMOUNT,
            string cURRENCY_ID,
            decimal cONVERT_MONEY,
            string cONTRACT_NUM,
            string nODE_ID,
            string vOUCHER_ID,
            DateTime oCCURENCY_DATE,
            DateTime cOMPLETE_DATE,
            string cOMPLETE_PALCE,
            string sHIP_ID,
            string rEMARK,
            string aPPLICANT,
            string aPPROVER,
            string aPPROVER2,
            DateTime pAYMENT_DATE,
            DateTime iNVOICE_DATE,
            string iNVOICE_NUM,
            int sENDED
        )
        {
            this.COSTS_ID = cOSTS_ID;
            this.CUSTOMER = cUSTOMER;
            this.DESCRIPTION = dESCRIPTION;
            this.ESTIMATE_AMOUNT = eSTIMATE_AMOUNT;
            this.AMOUNT = aMOUNT;
            this.CURRENCY_ID = cURRENCY_ID;
            this.CONVERT_MONEY = cONVERT_MONEY;
            this.CONTRACT_NUM = cONTRACT_NUM;
            this.NODE_ID = nODE_ID;
            this.VOUCHER_ID = vOUCHER_ID;
            this.OCCURENCY_DATE = oCCURENCY_DATE;
            this.COMPLETE_DATE = cOMPLETE_DATE;
            this.COMPLETE_PALCE = cOMPLETE_PALCE;
            this.SHIP_ID = sHIP_ID;
            this.REMARK = rEMARK;
            this.APPLICANT = aPPLICANT;
            this.APPROVER = aPPROVER;
            this.APPROVER2 = aPPROVER2;
            this.PAYMENT_DATE = pAYMENT_DATE;
            this.INVOICE_DATE = iNVOICE_DATE;
            this.INVOICE_NUM = iNVOICE_NUM;
            this.SENDED = sENDED;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///费用ID
        ///</summary>
        public string COSTS_ID { get; set; }

        ///<summary>
        ///客户名称.
        ///</summary>
        public string CUSTOMER { get; set; }

        ///<summary>
        ///项目说明.
        ///
        ///</summary>
        public string DESCRIPTION { get; set; }

        ///<summary>
        ///预估金额.
        ///
        ///</summary>
        public decimal ESTIMATE_AMOUNT { get; set; }

        ///<summary>
        ///实际金额.
        ///
        ///</summary>
        public decimal AMOUNT { get; set; }

        ///<summary>
        ///币种.
        ///</summary>
        public string CURRENCY_ID { get; set; }

        ///<summary>
        ///折算成美金.
        ///
        ///</summary>
        public decimal CONVERT_MONEY { get; set; }

        ///<summary>
        ///合同评审号.
        ///</summary>
        public string CONTRACT_NUM { get; set; }

        ///<summary>
        ///科目分类.
        ///</summary>
        public string NODE_ID { get; set; }

        ///<summary>
        ///凭证ID
        ///</summary>
        public string VOUCHER_ID { get; set; }

        ///<summary>
        ///发生日期.
        ///
        ///</summary>
        public DateTime OCCURENCY_DATE { get; set; }

        ///<summary>
        ///完成日期.
        ///
        ///</summary>
        public DateTime COMPLETE_DATE { get; set; }

        ///<summary>
        ///完成地点.
        ///</summary>
        public string COMPLETE_PALCE { get; set; }

        ///<summary>
        ///船舶.
        ///</summary>
        public string SHIP_ID { get; set; }

        ///<summary>
        ///备注.
        ///</summary>
        public string REMARK { get; set; }

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
        ///付款日期.
        ///
        ///</summary>
        public DateTime PAYMENT_DATE { get; set; }

        ///<summary>
        ///发票日期.
        ///
        ///</summary>
        public DateTime INVOICE_DATE { get; set; }

        ///<summary>
        ///发票号.
        ///</summary>
        public string INVOICE_NUM { get; set; }
        ///<summary>
        ///状态
        ///1'未做凭证'  2'已做凭证'  3'机务经理审批'  4'总裁审批'  5'财务经理审批'  6'已付款' 7'打回' 8'打回后提交' 9'作废'
        ///99'SAP外' xxl 2014年12月补充
        ///45 财务主管审批
        ///</summary>
        public int SENDED { get; set; }

        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            ACTUAL_COSTS Unit = new ACTUAL_COSTS();
            Unit.COSTS_ID = this.COSTS_ID;
            Unit.CUSTOMER = this.CUSTOMER;
            Unit.DESCRIPTION = this.DESCRIPTION;
            Unit.ESTIMATE_AMOUNT = this.ESTIMATE_AMOUNT;
            Unit.AMOUNT = this.AMOUNT;
            Unit.CURRENCY_ID = this.CURRENCY_ID;
            Unit.CONVERT_MONEY = this.CONVERT_MONEY;
            Unit.CONTRACT_NUM = this.CONTRACT_NUM;
            Unit.NODE_ID = this.NODE_ID;
            Unit.VOUCHER_ID = this.VOUCHER_ID;
            Unit.OCCURENCY_DATE = this.OCCURENCY_DATE;
            Unit.COMPLETE_DATE = this.COMPLETE_DATE;
            Unit.COMPLETE_PALCE = this.COMPLETE_PALCE;
            Unit.SHIP_ID = this.SHIP_ID;
            Unit.REMARK = this.REMARK;
            Unit.APPLICANT = this.APPLICANT;
            Unit.APPROVER = this.APPROVER;
            Unit.APPROVER2 = this.APPROVER2;
            Unit.PAYMENT_DATE = this.PAYMENT_DATE;
            Unit.INVOICE_DATE = this.INVOICE_DATE;
            Unit.INVOICE_NUM = this.INVOICE_NUM;
            Unit.SENDED = this.SENDED;
            return Unit;
        }
        #endregion

        public override string GetId()
        {
            return this.COSTS_ID;
        }

        public override string GetTypeName()
        {
            return "ACTUAL_COSTS";
        }

        public override bool Update(out string err)
        {
            return ACTUAL_COSTSService.Instance.saveUnit(this, out err);
        }

        public string Update()
        {
            return ACTUAL_COSTSService.Instance.saveUnit(this);
        }

        public override bool Delete(out string err)
        {
            //应该用事务，这里没有使用！
            bool re = ACTUAL_COSTSService.Instance.deleteUnit(this, out err);
            if (re == false) return false;
            if (!string.IsNullOrEmpty(VOUCHER_ID) && !VOUCHERService.Instance.deleteUnit(VOUCHER_ID, out err))
            {
                return false;
            }
            return true;
        }

        public override void FillThisObject()
        {

        }
    }
}
