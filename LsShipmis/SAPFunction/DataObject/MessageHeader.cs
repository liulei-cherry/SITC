/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：MessageHeader.cs
 * 创 建 人：王鹏程
 * 创建时间：2012/3/28
 * 标    题：实体类
 * 功能描述：T_MESSAGE_HEADER数据实体类
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
    ///T_MESSAGE_HEADER数据实体.
    /// </summary>
    ///[Serializable]
    public partial class MessageHeader : CommonClass
    {
        #region 构造函数
        ///<summary> 
        ///
        ///</summary>
        public MessageHeader()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public MessageHeader
        (
            string mESSAGE_HEADER_ID,
            string sY_SOURCE,
            string iNT_ID,
            string sHIP_ID,
            string cOMPANY_CODE,
            decimal pRODUCE,
            int qUANTITY,
            decimal oCCUR,
            decimal aCCOUNT,
            string pACKET_ID,
            string bUSINESS_CODE,
            string mESSAGE_TYPE,
            string bUSINESS_TYPE,
            string mESSAGE_ERROR,
            string sTATUS
        )
        {
            this.MESSAGE_HEADER_ID = mESSAGE_HEADER_ID;
            this.SY_SOURCE = sY_SOURCE;
            this.INT_ID = iNT_ID;
            this.SHIP_ID = sHIP_ID;
            this.COMPANY_CODE = cOMPANY_CODE;
            this.PRODUCE = pRODUCE;
            this.QUANTITY = qUANTITY;
            this.OCCUR = oCCUR;
            this.ACCOUNT = aCCOUNT;
            this.PACKET_ID = pACKET_ID;
            this.BUSINESS_CODE = bUSINESS_CODE;
            this.MESSAGE_TYPE = mESSAGE_TYPE;
            this.BUSINESS_TYPE = bUSINESS_TYPE;
            this.MESSAGE_ERROR = mESSAGE_ERROR;
            this.STATUS = sTATUS;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///
        ///</summary>
        public string MESSAGE_HEADER_ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string SY_SOURCE { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string INT_ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string SHIP_ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string COMPANY_CODE { get; set; }

        ///<summary>
        ///
        ///</summary>
        public decimal PRODUCE { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int QUANTITY { get; set; }

        ///<summary>
        ///
        ///</summary>
        public decimal OCCUR { get; set; }

        ///<summary>
        ///
        ///</summary>
        public decimal ACCOUNT { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string PACKET_ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string BUSINESS_CODE { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string MESSAGE_TYPE { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string BUSINESS_TYPE { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string MESSAGE_ERROR { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string STATUS { get; set; }

        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            MessageHeader Unit = new MessageHeader();
            Unit.MESSAGE_HEADER_ID = this.MESSAGE_HEADER_ID;
            Unit.SY_SOURCE = this.SY_SOURCE;
            Unit.INT_ID = this.INT_ID;
            Unit.SHIP_ID = this.SHIP_ID;
            Unit.COMPANY_CODE = this.COMPANY_CODE;
            Unit.PRODUCE = this.PRODUCE;
            Unit.QUANTITY = this.QUANTITY;
            Unit.OCCUR = this.OCCUR;
            Unit.ACCOUNT = this.ACCOUNT;
            Unit.PACKET_ID = this.PACKET_ID;
            Unit.BUSINESS_CODE = this.BUSINESS_CODE;
            Unit.MESSAGE_TYPE = this.MESSAGE_TYPE;
            Unit.BUSINESS_TYPE = this.BUSINESS_TYPE;
            Unit.MESSAGE_ERROR = this.MESSAGE_ERROR;
            Unit.STATUS = this.STATUS;
            return Unit;
        }
        #endregion

        public override string GetId()
        {
            return this.MESSAGE_HEADER_ID;
        }

        public override string GetTypeName()
        {
            return "MessageHeader";
        }

        public override bool Update(out string err)
        {
            return MessageHeaderService.Instance.saveUnit(this, out err);
        }

        public string Update()
        {
            return MessageHeaderService.Instance.saveUnit(this);
        }

        public override bool Delete(out string err)
        {
            return MessageHeaderService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {

        }
    }
}
