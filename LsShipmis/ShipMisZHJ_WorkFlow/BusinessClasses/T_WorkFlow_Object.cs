/****************************************************************************************************
 * Copyright (C) 2009 大连陆海科技有限公司 版权所有
 * 文 件 名：T_WorkFlow_Object.cs
 * 创 建 人：牛振军
 * 创建时间：2009-9-25
 * 标    题：实体类
 * 功能描述：T_WorkFlow_Object数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
namespace ShipMisZHJ_WorkFlow.BusinessClasses
{
	/// <summary>
	///T_WorkFlow_Object数据实体.
	/// </summary>
	///[Serializable]
	public class T_WorkFlow_Object
	{
		#region 变量定义
		///<summary>
		///流程对象Id
		///</summary>
		private string _workFlow_Object_Id;
		///<summary>
		///流程对象名称.
		///</summary>
		private string _workFlow_Object_Name = String.Empty;
		#endregion
		
		#region 构造函数
		///<summary>
		///
		///</summary>
		public T_WorkFlow_Object()
		{
		}
		///<summary>
		///
		///</summary>
		public T_WorkFlow_Object
		(
			string workFlow_Object_Id,
			string workFlow_Object_Name
		)
		{
			_workFlow_Object_Id   = workFlow_Object_Id;
			_workFlow_Object_Name = workFlow_Object_Name;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///流程对象Id
		///</summary>
		public string WorkFlow_Object_Id
		{
			get {return _workFlow_Object_Id;}
			set {_workFlow_Object_Id = value;}
		}

		///<summary>
		///流程对象名称.
		///</summary>
		public string WorkFlow_Object_Name
		{
			get {return _workFlow_Object_Name;}
			set {_workFlow_Object_Name = value;}
		}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public T_WorkFlow_Object Clone()
		{
			T_WorkFlow_Object Unit = new T_WorkFlow_Object();
			Unit.WorkFlow_Object_Id=this.WorkFlow_Object_Id;
			Unit.WorkFlow_Object_Name=this.WorkFlow_Object_Name;
          return Unit;
		}
		#endregion
		
	}
}
