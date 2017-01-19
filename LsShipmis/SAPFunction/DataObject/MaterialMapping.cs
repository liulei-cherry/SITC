/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：MaterialMapping.cs
 * 创 建 人：王鹏程
 * 创建时间：2012/3/22
 * 标    题：实体类
 * 功能描述：T_MATERIAL_MAPPING数据实体类
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
    ///T_MATERIAL_MAPPING数据实体.
    /// </summary>
    ///[Serializable]
    public partial class MaterialMapping : CommonClass
    {
        #region 构造函数
        ///<summary> 
        ///
        ///</summary>
        public MaterialMapping()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public MaterialMapping
        (
            string mATERIAL_MAPPING_ID,
            string mANAGEMENT,
            string mATERIAL_FINANCE,
            string cOST_FINANCE,
            string sTATUS
        )
        {
            this.MATERIAL_MAPPING_ID = mATERIAL_MAPPING_ID;
            this.MANAGEMENT = mANAGEMENT;
            this.MATERIAL_FINANCE = mATERIAL_FINANCE;
            this.COST_FINANCE = cOST_FINANCE;
            this.STATUS = sTATUS;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///
        ///</summary>
        public string MATERIAL_MAPPING_ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string MANAGEMENT { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string MATERIAL_FINANCE { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string COST_FINANCE { get; set; }

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
            MaterialMapping Unit = new MaterialMapping();
            Unit.MATERIAL_MAPPING_ID = this.MATERIAL_MAPPING_ID;
            Unit.MANAGEMENT = this.MANAGEMENT;
            Unit.MATERIAL_FINANCE = this.MATERIAL_FINANCE;
            Unit.COST_FINANCE = this.COST_FINANCE;
            Unit.STATUS = this.STATUS;
            return Unit;
        }
        #endregion

        public override string GetId()
        {
            return this.MATERIAL_MAPPING_ID;
        }

        public override string GetTypeName()
        {
            return "MaterialMapping";
        }

        public override bool Update(out string err)
        {
            return MaterialMappingService.Instance.saveUnit(this, out err);
        }

        public string Update()
        {
            return MaterialMappingService.Instance.saveUnit(this);
        }

        public override bool Delete(out string err)
        {
            return MaterialMappingService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {

        }
    }
}
