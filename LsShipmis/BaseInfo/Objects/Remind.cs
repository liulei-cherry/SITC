/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：Remind.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/11/29
 * 标    题：实体类
 * 功能描述：T_REMIND数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using BaseInfo.DataAccess;

namespace BaseInfo.Objects
{
	/// <summary>
	///T_REMIND数据实体.
	/// </summary>
	///[Serializable]
	public partial class Remind : CommonClass
	{		
		#region 构造函数
		///<summary> 
		///提醒表(只做一次提醒)
		///</summary>
		public Remind()
		{
		}
		///<summary>
		///提醒表(只做一次提醒)
		///</summary>
		public Remind
		(
			string iD,
			string bUSINESSID,
			int rEMIND_TYPE,
			string pOST_TYPE,
			string sHIP_ID
		)
		{
			this.ID          = iD;
			this.BUSINESSID  = bUSINESSID;
			this.REMIND_TYPE = rEMIND_TYPE;
			this.POST_TYPE   = pOST_TYPE;
			this.SHIP_ID     = sHIP_ID;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///ID
		///</summary>
		public string ID{get ;set;}

		///<summary>
		///业务ID(匹配各种业务ID)
		///</summary>
		public string BUSINESSID{get ;set;}

		///<summary>
        ///提醒类型(1.修理,2.备件申请,3.备件订单,4.物料申请,5.物料订单,6油料申请9.备件手工入库10物料手工入库)
		///</summary>
		public int REMIND_TYPE{get ;set;}

		///<summary>
		///岗位类型.
		///</summary>
		public string POST_TYPE{get ;set;}

		///<summary>
		///船舶ID
		///</summary>
		public string SHIP_ID{get ;set;}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public override CommonClass Clone()
		{
			Remind Unit = new Remind();
			Unit.ID=this.ID;
			Unit.BUSINESSID=this.BUSINESSID;
			Unit.REMIND_TYPE=this.REMIND_TYPE;
			Unit.POST_TYPE=this.POST_TYPE;
			Unit.SHIP_ID=this.SHIP_ID;
            return Unit;
		}
		#endregion
		
		public override string GetId()
        {
            return this.ID;
        }

        public override string GetTypeName()
        {
            return "Remind";
        }

        public override bool Update(out string err)
        {
            return RemindService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return RemindService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
