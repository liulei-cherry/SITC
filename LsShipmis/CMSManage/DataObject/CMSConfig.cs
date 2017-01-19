/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：CMSConfig.cs
 * 创 建 人：徐正本
 * 创建时间：2012-3-3
 * 标    题：实体类
 * 功能描述：T_CMS_CONFIG数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using CMSManage.Services;
using Maintenance.Services;
using Maintenance.DataObject;

namespace CMSManage.DataObject
{
	/// <summary>
	///T_CMS_CONFIG数据实体.
	/// </summary>
	///[Serializable]
	public partial class CMSConfig : CommonClass
	{		
		#region 构造函数
		///<summary> 
		///CMS设置表,设置CMS检验项目,代码,是否与工作信息关联等.
		///</summary>
		public CMSConfig()
		{
		}
		///<summary>
		///CMS设置表,设置CMS检验项目,代码,是否与工作信息关联等.
		///</summary>
		public CMSConfig
		(
			string cMS_CONFIG_ID,
			string cHECKTITLE,
			string cMSCODE,
			string wORKINFOID,
			string cHECKDETAIL,
			string sHIP_ID,
			string cHECKENGLISHNAME,
			decimal sortNo
		)
		{
			this.CMS_CONFIG_ID    = cMS_CONFIG_ID;
			this.CHECKTITLE       = cHECKTITLE;
			this.CMSCODE          = cMSCODE;
			this.WORKINFOID       = wORKINFOID;
			this.CHECKDETAIL      = cHECKDETAIL;
			this.SHIP_ID          = sHIP_ID;
			this.CHECKENGLISHNAME = cHECKENGLISHNAME;
			this.SortNo           = sortNo;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///ID
		///</summary>
		public string CMS_CONFIG_ID{get ;set;}

		///<summary>
		///检验项目.
		///</summary>
		public string CHECKTITLE{get ;set;}

		///<summary>
		///检验代码.
		///</summary>
		public string CMSCODE{get ;set;}

		///<summary>
		///工作信息id
		///</summary>
		public string WORKINFOID{get ;set;}

		///<summary>
		///检验内容.
		///</summary>
		public string CHECKDETAIL{get ;set;}

		///<summary>
		///船舶id
		///</summary>
		public string SHIP_ID{get ;set;}

		///<summary>
		///
		///</summary>
		public string CHECKENGLISHNAME{get ;set;}

		///<summary>
		///
		///</summary>
		public decimal SortNo{get ;set;}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public override CommonClass Clone()
		{
			CMSConfig Unit = new CMSConfig();
			Unit.CMS_CONFIG_ID=this.CMS_CONFIG_ID;
			Unit.CHECKTITLE=this.CHECKTITLE;
			Unit.CMSCODE=this.CMSCODE;
			Unit.WORKINFOID=this.WORKINFOID;
			Unit.CHECKDETAIL=this.CHECKDETAIL;
			Unit.SHIP_ID=this.SHIP_ID;
			Unit.CHECKENGLISHNAME=this.CHECKENGLISHNAME;
			Unit.SortNo=this.SortNo;
            return Unit;
		}
		#endregion
		
		public override string GetId()
        {
            return this.CMS_CONFIG_ID;
        }

        public override string GetTypeName()
        {
            return "CMSConfig";
        }
         
        public override bool Update(out string err)
        {
            if (canUpdate(out err))
                return CMSConfigService.Instance.saveUnit(this, out err);
            else
            { 
                return false;
            }

        }

        public override bool Delete(out string err)
        {
            return CMSConfigService.Instance.deleteUnit(this, out err);
        }
        public WorkInfo TheWorkInfo { get; set; }
        public override void FillThisObject()
        {
            if (TheWorkInfo == null && !string.IsNullOrEmpty(WORKINFOID))
            {
                string err;
                TheWorkInfo = WorkInfoService.Instance.getObject(WORKINFOID, out err);
            }
        }
        public bool canUpdate(out string err)
        {
            err = "当前检验名称已经存在,不允许保存当前数据,请更改重复记录后再尝试保存";
            //当前表的检验编号不允许重复;
            return !CMSConfigService.Instance.CMSCodeIsDuplicated(CHECKTITLE, CMSCODE, SHIP_ID, GetId());
        }
    }
}
