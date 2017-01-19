/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：PurchaseMessage.cs
 * 创 建 人：王鹏程
 * 创建时间：2012/3/16
 * 标    题：实体类
 * 功能描述：T_PURCHASE_MESSAGE数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using SAPFunction.Services;

namespace SAPFunction.DataObject
{
    /// <summary>
    ///T_PURCHASE_MESSAGE数据实体.
    /// </summary>
    ///[Serializable]
    public partial class PurchaseMessage : CommonClass
    {
        #region 构造函数
        ///<summary> 
        ///
        ///</summary>
        public PurchaseMessage()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public PurchaseMessage
        (
            string pURCHASE_MESSAGE_ID,
            string mESSAGE_HEADER_ID,
            int lINENUM,
            string mATERIAL,
            string mATERIAL_MAPPING,
            decimal qUANTITY,
            string cURRENCY,
            decimal aMOUNT,
            string sUBJECT_MAPPING,
            string sHIP_ID,
            string sHIP_MAPPING,
            string iNPUT_OUTPUT,
            string sUPPLIER,
            string sUPPLIER_MAPPING,
            string iNPUT_ORDER,
            decimal iNPUT_OREER_ITEM,
            string uUID,
            decimal rEBATE,
            decimal oRDER_AMOUNT,
            string aCCOUNT_CODE,
            string aCCOUNT_NAME,
            string bUSINESS_CODE
        )
        {
            this.PURCHASE_MESSAGE_ID = pURCHASE_MESSAGE_ID;
            this.MESSAGE_HEADER_ID = mESSAGE_HEADER_ID;
            this.LINENUM = lINENUM;
            this.MATERIAL = mATERIAL;
            this.MATERIAL_MAPPING = mATERIAL_MAPPING;
            this.QUANTITY = qUANTITY;
            this.CURRENCY = cURRENCY;
            this.AMOUNT = aMOUNT;
            this.SUBJECT_MAPPING = sUBJECT_MAPPING;
            this.SHIP_ID = sHIP_ID;
            this.SHIP_MAPPING = sHIP_MAPPING;
            this.INPUT_OUTPUT = iNPUT_OUTPUT;
            this.SUPPLIER = sUPPLIER;
            this.SUPPLIER_MAPPING = sUPPLIER_MAPPING;
            this.INPUT_ORDER = iNPUT_ORDER;
            this.INPUT_OREER_ITEM = iNPUT_OREER_ITEM;
            this.UUID = uUID;
            this.REBATE = rEBATE;
            this.ORDER_AMOUNT = oRDER_AMOUNT;
            this.ACCOUNT_CODE = aCCOUNT_CODE;
            this.ACCOUNT_NAME = aCCOUNT_NAME;
            this.BUSINESS_CODE = bUSINESS_CODE;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///
        ///</summary>
        public string PURCHASE_MESSAGE_ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string MESSAGE_HEADER_ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int LINENUM { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string MATERIAL { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string MATERIAL_MAPPING { get; set; }

        ///<summary>
        ///
        ///</summary>
        public decimal QUANTITY { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string CURRENCY { get; set; }

        ///<summary>
        ///
        ///</summary>
        public decimal AMOUNT { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string SUBJECT_MAPPING { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string SHIP_ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string SHIP_MAPPING { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string INPUT_OUTPUT { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string SUPPLIER { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string SUPPLIER_MAPPING { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string INPUT_ORDER { get; set; }

        ///<summary>
        ///
        ///</summary>
        public decimal INPUT_OREER_ITEM { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string UUID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public decimal REBATE { get; set; }

        ///<summary>
        ///
        ///</summary>
        public decimal ORDER_AMOUNT { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string ACCOUNT_CODE { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string ACCOUNT_NAME { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string BUSINESS_CODE { get; set; }

        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            PurchaseMessage Unit = new PurchaseMessage();
            Unit.PURCHASE_MESSAGE_ID = this.PURCHASE_MESSAGE_ID;
            Unit.MESSAGE_HEADER_ID = this.MESSAGE_HEADER_ID;
            Unit.LINENUM = this.LINENUM;
            Unit.MATERIAL = this.MATERIAL;
            Unit.MATERIAL_MAPPING = this.MATERIAL_MAPPING;
            Unit.QUANTITY = this.QUANTITY;
            Unit.CURRENCY = this.CURRENCY;
            Unit.AMOUNT = this.AMOUNT;
            Unit.SUBJECT_MAPPING = this.SUBJECT_MAPPING;
            Unit.SHIP_ID = this.SHIP_ID;
            Unit.SHIP_MAPPING = this.SHIP_MAPPING;
            Unit.INPUT_OUTPUT = this.INPUT_OUTPUT;
            Unit.SUPPLIER = this.SUPPLIER;
            Unit.SUPPLIER_MAPPING = this.SUPPLIER_MAPPING;
            Unit.INPUT_ORDER = this.INPUT_ORDER;
            Unit.INPUT_OREER_ITEM = this.INPUT_OREER_ITEM;
            Unit.UUID = this.UUID;
            Unit.REBATE = this.REBATE;
            Unit.ORDER_AMOUNT = this.ORDER_AMOUNT;
            Unit.ACCOUNT_CODE = this.ACCOUNT_CODE;
            Unit.ACCOUNT_NAME = this.ACCOUNT_NAME;
            Unit.BUSINESS_CODE = this.BUSINESS_CODE;
            return Unit;
        }
        #endregion

        public override string GetId()
        {
            return this.PURCHASE_MESSAGE_ID;
        }

        public override string GetTypeName()
        {
            return "PurchaseMessage";
        }

        public override bool Update(out string err)
        {
            return PurchaseMessageService.Instance.saveUnit(this, out err);
        }

        public string Update()
        {
            return PurchaseMessageService.Instance.saveUnit(this);
        }

        public override bool Delete(out string err)
        {
            return PurchaseMessageService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {

        }
    }
}
