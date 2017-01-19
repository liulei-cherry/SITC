/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：ShipRunningRepairRelation.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/8/2
 * 标    题：实体类
 * 功能描述：T_SHIPRUNNINGREPAIR_RELATION数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using Repair.Services;

namespace Repair.DataObject
{
	/// <summary>
	///T_SHIPRUNNINGREPAIR_RELATION数据实体.
	/// </summary>
	///[Serializable]
	public partial class ShipRunningRepairRelation : CommonClass
	{		
		#region 构造函数
		///<summary> 
		///
		///</summary>
		public ShipRunningRepairRelation()
		{
		}
		///<summary>
		///
		///</summary>
		public ShipRunningRepairRelation
		(
			string rELATIONID,
			string pROJECTID,
			string rEPAIRID,
			decimal sTATE,
			string rEMARK,
			decimal sORTNO
		)
		{
			this.RELATIONID = rELATIONID;
			this.PROJECTID  = pROJECTID;
			this.REPAIRID   = rEPAIRID;
			this.STATE      = sTATE;
			this.REMARK     = rEMARK;
			this.SORTNO     = sORTNO;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///
		///</summary>
		public string RELATIONID{get ;set;}

		///<summary>
		///
		///</summary>
		public string PROJECTID{get ;set;}

		///<summary>
		///
		///</summary>
		public string REPAIRID{get ;set;}

		///<summary>
		///是否在这个项目中完成,1,完成,2,未完成(通常在remark中描述原因)
		///</summary>
		public decimal STATE{get ;set;}

		///<summary>
		///备注,有可能被航修选中,但并没有在航修中修理,可以填写处理原因.
		///</summary>
		public string REMARK{get ;set;}

		///<summary>
		///
		///</summary>
		public decimal SORTNO{get ;set;}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public override CommonClass Clone()
		{
			ShipRunningRepairRelation Unit = new ShipRunningRepairRelation();
			Unit.RELATIONID=this.RELATIONID;
			Unit.PROJECTID=this.PROJECTID;
			Unit.REPAIRID=this.REPAIRID;
			Unit.STATE=this.STATE;
			Unit.REMARK=this.REMARK;
			Unit.SORTNO=this.SORTNO;
            return Unit;
		}
		#endregion
		
		public override string GetId()
        {
            return this.RELATIONID;
        }

        public override string GetTypeName()
        {
            return "ShipRunningRepairRelation";
        }

        public override bool Update(out string err)
        {
            return ShipRunningRepairRelationService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return ShipRunningRepairRelationService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
