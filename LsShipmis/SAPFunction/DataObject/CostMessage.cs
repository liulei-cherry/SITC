/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：CostMessage.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/12/30
 * 标    题：实体类
 * 功能描述：T_COST_MESSAGE数据实体类
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
    ///T_COST_MESSAGE数据实体.
    /// </summary>
    ///[Serializable]
    public partial class CostMessage : CommonClass
    {
        #region 构造函数
        ///<summary> 
        ///
        ///</summary>
        public CostMessage()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public CostMessage
        (
            string cOST_MESSAGE_ID,
            string mESSAGE_HEADER_ID,
            int lINENUM,
            string sUPPLIER,
            string sUPPLIER_MAPPING,
            string cURRENCY,
            decimal aMOUNT,
            string sUBJECT,
            string sUBJECT_MAPPING,
            string cOST_TYPE,
            string iNNER_ORDER,
            string sHIP_ID,
            string sHIP_MAPPING,
            string uUID,
            string rEMARK
        )
        {
            this.COST_MESSAGE_ID = cOST_MESSAGE_ID;
            this.MESSAGE_HEADER_ID = mESSAGE_HEADER_ID;
            this.LINENUM = lINENUM;
            this.SUPPLIER = sUPPLIER;
            this.SUPPLIER_MAPPING = sUPPLIER_MAPPING;
            this.CURRENCY = cURRENCY;
            this.AMOUNT = aMOUNT;
            this.SUBJECT = sUBJECT;
            this.SUBJECT_MAPPING = sUBJECT_MAPPING;
            this.COST_TYPE = cOST_TYPE;
            this.INNER_ORDER = iNNER_ORDER;
            this.SHIP_ID = sHIP_ID;
            this.SHIP_MAPPING = sHIP_MAPPING;
            this.UUID = uUID;
            this.REMARK = rEMARK;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///
        ///</summary>
        public string COST_MESSAGE_ID { get; set; }

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
        public string SUPPLIER { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string SUPPLIER_MAPPING { get; set; }

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
        public string SUBJECT { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string SUBJECT_MAPPING { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string COST_TYPE { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string INNER_ORDER { get; set; }

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
        public string UUID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string REMARK { get; set; }

        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            CostMessage Unit = new CostMessage();
            Unit.COST_MESSAGE_ID = this.COST_MESSAGE_ID;
            Unit.MESSAGE_HEADER_ID = this.MESSAGE_HEADER_ID;
            Unit.LINENUM = this.LINENUM;
            Unit.SUPPLIER = this.SUPPLIER;
            Unit.SUPPLIER_MAPPING = this.SUPPLIER_MAPPING;
            Unit.CURRENCY = this.CURRENCY;
            Unit.AMOUNT = this.AMOUNT;
            Unit.SUBJECT = this.SUBJECT;
            Unit.SUBJECT_MAPPING = this.SUBJECT_MAPPING;
            Unit.COST_TYPE = this.COST_TYPE;
            Unit.INNER_ORDER = this.INNER_ORDER;
            Unit.SHIP_ID = this.SHIP_ID;
            Unit.SHIP_MAPPING = this.SHIP_MAPPING;
            Unit.UUID = this.UUID;
            Unit.REMARK = this.REMARK;
            return Unit;
        }
        #endregion

        public override string GetId()
        {
            return this.COST_MESSAGE_ID;
        }

        public override string GetTypeName()
        {
            return "CostMessage";
        }

        public override bool Update(out string err)
        {
            return CostMessageService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return CostMessageService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {

        }
    }
}
