/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：MaterialType.cs
 * 创 建 人：徐正本
 * 创建时间：2011/8/18
 * 标    题：实体类
 * 功能描述：T_MATERIAL_TYPE数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using ItemsManage.Services;

namespace ItemsManage.DataObject
{
    /// <summary>
    ///T_MATERIAL_TYPE数据实体.
    /// </summary>
    ///[Serializable]
    public partial class MaterialType : CommonClass
    {
        #region 构造函数
        ///<summary> 
        ///
        ///</summary>
        public MaterialType()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public MaterialType
        (
            string mATERIAL_TYPE_ID,
            string sUPERIOR_ID,
            string mATERIAL_TYPE_NAME,
            string rEMARK
        )
        {
            this.MATERIAL_TYPE_ID = mATERIAL_TYPE_ID;
            this.SUPERIOR_ID = sUPERIOR_ID;
            this.MATERIAL_TYPE_NAME = mATERIAL_TYPE_NAME;
            this.REMARK = rEMARK;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///
        ///</summary>
        public string MATERIAL_TYPE_ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string SUPERIOR_ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string MATERIAL_TYPE_NAME { get; set; }

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
            MaterialType Unit = new MaterialType();
            Unit.MATERIAL_TYPE_ID = this.MATERIAL_TYPE_ID;
            Unit.SUPERIOR_ID = this.SUPERIOR_ID;
            Unit.MATERIAL_TYPE_NAME = this.MATERIAL_TYPE_NAME;
            Unit.REMARK = this.REMARK;
            return Unit;
        }
        #endregion

        public MaterialType TheParentType { get; set; }
        public override string GetId()
        {
            return this.MATERIAL_TYPE_ID;
        }

        public override string GetTypeName()
        {
            return "MaterialType";
        }

        public override bool Update(out string err)
        {
            return MaterialTypeService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return MaterialTypeService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            if (TheParentType == null || TheParentType.IsWrong)
            {
                string err;
                TheParentType = MaterialTypeService.Instance.getObject(SUPERIOR_ID, out err);
            }
        }
    }
}
