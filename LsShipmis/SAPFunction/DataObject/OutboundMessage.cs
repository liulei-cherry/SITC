/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：OutboundMessage.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/7/6
 * 标    题：实体类
 * 功能描述：T_OUTBOUND_MESSAGE数据实体类
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
    ///T_OUTBOUND_MESSAGE数据实体.
    /// </summary>
    ///[Serializable]
    public partial class OutboundMessage : CommonClass
    {
        #region 构造函数
        ///<summary> 
        ///
        ///</summary>
        public OutboundMessage()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public OutboundMessage
        (
            string oUTBOUND_MESSAGE_ID,
            string mESSAGE_HEADER_ID,
            int lINENUM,
            string mATERIAL,
            string mATERIAL_MAPPING,
            decimal qUANTITY,
            string sHIP_ID,
            string sHIP_MAPPING,
            string iNPUT_OUTPUT,
            string uUID
        )
        {
            this.OUTBOUND_MESSAGE_ID = oUTBOUND_MESSAGE_ID;
            this.MESSAGE_HEADER_ID = mESSAGE_HEADER_ID;
            this.LINENUM = lINENUM;
            this.MATERIAL = mATERIAL;
            this.MATERIAL_MAPPING = mATERIAL_MAPPING;
            this.QUANTITY = qUANTITY;
            this.SHIP_ID = sHIP_ID;
            this.SHIP_MAPPING = sHIP_MAPPING;
            this.INPUT_OUTPUT = iNPUT_OUTPUT;
            this.UUID = uUID;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///
        ///</summary>
        public string OUTBOUND_MESSAGE_ID { get; set; }

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
        public string UUID { get; set; }

        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            OutboundMessage Unit = new OutboundMessage();
            Unit.OUTBOUND_MESSAGE_ID = this.OUTBOUND_MESSAGE_ID;
            Unit.MESSAGE_HEADER_ID = this.MESSAGE_HEADER_ID;
            Unit.LINENUM = this.LINENUM;
            Unit.MATERIAL = this.MATERIAL;
            Unit.MATERIAL_MAPPING = this.MATERIAL_MAPPING;
            Unit.QUANTITY = this.QUANTITY;
            Unit.SHIP_ID = this.SHIP_ID;
            Unit.SHIP_MAPPING = this.SHIP_MAPPING;
            Unit.INPUT_OUTPUT = this.INPUT_OUTPUT;
            Unit.UUID = this.UUID;
            return Unit;
        }
        #endregion

        public override string GetId()
        {
            return this.OUTBOUND_MESSAGE_ID;
        }

        public override string GetTypeName()
        {
            return "OutboundMessage";
        }

        public override bool Update(out string err)
        {
            return OutboundMessageService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return OutboundMessageService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {

        }
    }
}
