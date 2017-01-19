/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：MaterialInfo.cs
 * 创 建 人：徐正本
 * 创建时间：2011/8/16
 * 标    题：实体类
 * 功能描述：T_MATERIAL数据实体类
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
	///T_MATERIAL数据实体.
	/// </summary>
	///[Serializable]
	public partial class MaterialInfo : CommonClass
	{		
		#region 构造函数
		///<summary> 
		///
		///</summary>
		public MaterialInfo()
		{
		}
		///<summary>
		///
		///</summary>
		public MaterialInfo
		(
			string mATERIAL_ID,
			string mATERIAL_TYPE_ID,
			string mATERIAL_CODE,
			string mATERIAL_NAME,
			string mATERIAL_SPEC,
			string uNIT_NAME,
			string rEMARK
		)
		{
			this.MATERIAL_ID      = mATERIAL_ID;
			this.MATERIAL_TYPE_ID = mATERIAL_TYPE_ID;
			this.MATERIAL_CODE    = mATERIAL_CODE;
			this.MATERIAL_NAME    = mATERIAL_NAME;
			this.MATERIAL_SPEC    = mATERIAL_SPEC;
			this.UNIT_NAME        = uNIT_NAME;
			this.REMARK           = rEMARK;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///物料Id
		///</summary>
		public string MATERIAL_ID{get ;set;}

		///<summary>
		///物料类型Id
		///</summary>
		public string MATERIAL_TYPE_ID{get ;set;}

		///<summary>
		///物料编号.
		///</summary>
		public string MATERIAL_CODE{get ;set;}

		///<summary>
		///物料名称.
		///</summary>
		public string MATERIAL_NAME{get ;set;}

		///<summary>
		///物料规格型号.
		///</summary>
		public string MATERIAL_SPEC{get ;set;}

		///<summary>
		///计量单位Id
		///</summary>
		public string UNIT_NAME{get ;set;}

		///<summary>
		///备注.
		///</summary>
		public string REMARK{get ;set;}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public override CommonClass Clone()
		{
			MaterialInfo Unit = new MaterialInfo();
			Unit.MATERIAL_ID=this.MATERIAL_ID;
			Unit.MATERIAL_TYPE_ID=this.MATERIAL_TYPE_ID;
			Unit.MATERIAL_CODE=this.MATERIAL_CODE;
			Unit.MATERIAL_NAME=this.MATERIAL_NAME;
			Unit.MATERIAL_SPEC=this.MATERIAL_SPEC;
			Unit.UNIT_NAME=this.UNIT_NAME;
			Unit.REMARK=this.REMARK;
            return Unit;
		}
		#endregion
		
		public override string GetId()
        {
            return this.MATERIAL_ID;
        }

        public override string GetTypeName()
        {
            return "MaterialInfo";
        }

        public override bool Update(out string err)
        {
            return MaterialInfoService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return MaterialInfoService.Instance.deleteUnit(this, out err);
        }

        public string TypeName { get; set; }
        public MaterialType TheType { get; set; }
        public override void FillThisObject()
        {
            if (TheType == null || TheType.IsWrong)
            {
                string err;              
                TheType = MaterialTypeService.Instance.getObject(MATERIAL_TYPE_ID,out err);
                if (TheType != null && !TheType.IsWrong)
                    TypeName = TheType.MATERIAL_TYPE_NAME;
                else
                    TypeName = "";
            }
            else TypeName = "";
        }
        public override string ToString()
        {
            return MATERIAL_NAME + (string.IsNullOrEmpty(MATERIAL_SPEC) ? "" : "(" + MATERIAL_SPEC + ")");
        }
    }
}
