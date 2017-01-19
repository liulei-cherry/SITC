/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：InternalOrderMapping.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/6/28
 * 标    题：实体类
 * 功能描述：T_INTERNAL_ORDER_MAPPING数据实体类
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
    ///T_INTERNAL_ORDER_MAPPING数据实体.
    /// </summary>
    ///[Serializable]
    public partial class InternalOrderMapping : CommonClass
    {
        #region 构造函数
        ///<summary> 
        ///
        ///</summary>
        public InternalOrderMapping()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public InternalOrderMapping
        (
            string iNTERNAL_ORDER_MAPPING_ID,
            string sHIP_CODE,
            string iTEM_CODE,
            string iNTERNAL_ORDER_FINANCE,
            string sTATUS
        )
        {
            this.INTERNAL_ORDER_MAPPING_ID = iNTERNAL_ORDER_MAPPING_ID;
            this.SHIP_CODE = sHIP_CODE;
            this.ITEM_CODE = iTEM_CODE;
            this.INTERNAL_ORDER_FINANCE = iNTERNAL_ORDER_FINANCE;
            this.STATUS = sTATUS;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///
        ///</summary>
        public string INTERNAL_ORDER_MAPPING_ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string SHIP_CODE { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string ITEM_CODE { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string INTERNAL_ORDER_FINANCE { get; set; }

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
            InternalOrderMapping Unit = new InternalOrderMapping();
            Unit.INTERNAL_ORDER_MAPPING_ID = this.INTERNAL_ORDER_MAPPING_ID;
            Unit.SHIP_CODE = this.SHIP_CODE;
            Unit.ITEM_CODE = this.ITEM_CODE;
            Unit.INTERNAL_ORDER_FINANCE = this.INTERNAL_ORDER_FINANCE;
            Unit.STATUS = this.STATUS;
            return Unit;
        }
        #endregion

        public override string GetId()
        {
            return this.INTERNAL_ORDER_MAPPING_ID;
        }

        public override string GetTypeName()
        {
            return "InternalOrderMapping";
        }

        public override bool Update(out string err)
        {
            return InternalOrderMappingService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return InternalOrderMappingService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {

        }
    }
}
