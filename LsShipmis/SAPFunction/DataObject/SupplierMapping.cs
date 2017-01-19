/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：SupplierMapping.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/6/28
 * 标    题：实体类
 * 功能描述：T_SUPPLIER_MAPPING数据实体类
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
    ///T_SUPPLIER_MAPPING数据实体.
    /// </summary>
    ///[Serializable]
    public partial class SupplierMapping : CommonClass
    {
        #region 构造函数
        ///<summary> 
        ///
        ///</summary>
        public SupplierMapping()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public SupplierMapping
        (
            string sUPPLIER_MAPPING_ID,
            string mANAGEMENT,
            string fINANCE,
            string sTATUS
        )
        {
            this.SUPPLIER_MAPPING_ID = sUPPLIER_MAPPING_ID;
            this.MANAGEMENT = mANAGEMENT;
            this.FINANCE = fINANCE;
            this.STATUS = sTATUS;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///
        ///</summary>
        public string SUPPLIER_MAPPING_ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string MANAGEMENT { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string FINANCE { get; set; }

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
            SupplierMapping Unit = new SupplierMapping();
            Unit.SUPPLIER_MAPPING_ID = this.SUPPLIER_MAPPING_ID;
            Unit.MANAGEMENT = this.MANAGEMENT;
            Unit.FINANCE = this.FINANCE;
            Unit.STATUS = this.STATUS;
            return Unit;
        }
        #endregion

        public override string GetId()
        {
            return this.SUPPLIER_MAPPING_ID;
        }

        public override string GetTypeName()
        {
            return "SupplierMapping";
        }

        public override bool Update(out string err)
        {
            return SupplierMappingService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return SupplierMappingService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {

        }
    }
}
