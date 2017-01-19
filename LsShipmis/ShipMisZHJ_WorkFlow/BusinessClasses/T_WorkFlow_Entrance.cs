/****************************************************************************************************
 * Copyright (C) 2009 大连陆海科技有限公司 版权所有
 * 文 件 名：T_WorkFlow_Entrance.cs
 * 创 建 人：牛振军
 * 创建时间：2009-9-28
 * 标    题：实体类
 * 功能描述：T_WorkFlow_Entrance数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
namespace ShipMisZHJ_WorkFlow.BusinessClasses
{
	/// <summary>
	///T_WorkFlow_Entrance数据实体.
	/// </summary>
	///[Serializable]
	public class T_WorkFlow_Entrance
	{
		#region 变量定义
		///<summary>
		///流程入口Id
		///</summary>
		private string _workFlow_Entrance_Id;
		///<summary>
		///流程对象名称.
		///</summary>
		private string _workFlow_Object_Id = String.Empty;
		///<summary>
		///部门Id
		///</summary>
		private string _departmentId = String.Empty;
		///<summary>
		///流程Id
		///</summary>
		private string _workFlow_Id = String.Empty;
		///<summary>
		///流程名称.
		///</summary>
		private string _workFlow_Name = String.Empty;
		#endregion
		
		#region 构造函数
		///<summary>
		///
		///</summary>
		public T_WorkFlow_Entrance()
		{
		}
		///<summary>
		///
		///</summary>
		public T_WorkFlow_Entrance
		(
			string workFlow_Entrance_Id,
			string workFlow_Object_Id,
			string departmentId,
			string workFlow_Id,
			string workFlow_Name
		)
		{
			_workFlow_Entrance_Id = workFlow_Entrance_Id;
			_workFlow_Object_Id   = workFlow_Object_Id;
			_departmentId         = departmentId;
			_workFlow_Id          = workFlow_Id;
			_workFlow_Name        = workFlow_Name;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///流程入口Id
		///</summary>
		public string WorkFlow_Entrance_Id
		{
			get {return _workFlow_Entrance_Id;}
			set {_workFlow_Entrance_Id = value;}
		}

		///<summary>
		///流程对象名称.
		///</summary>
		public string WorkFlow_Object_Id
		{
			get {return _workFlow_Object_Id;}
			set {_workFlow_Object_Id = value;}
		}

		///<summary>
		///部门Id
		///</summary>
		public string DepartmentId
		{
			get {return _departmentId;}
			set {_departmentId = value;}
		}

		///<summary>
		///流程Id
		///</summary>
		public string WorkFlow_Id
		{
			get {return _workFlow_Id;}
			set {_workFlow_Id = value;}
		}

		///<summary>
		///流程名称.
		///</summary>
		public string WorkFlow_Name
		{
			get {return _workFlow_Name;}
			set {_workFlow_Name = value;}
		}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public T_WorkFlow_Entrance Clone()
		{
			T_WorkFlow_Entrance Unit = new T_WorkFlow_Entrance();
			Unit.WorkFlow_Entrance_Id=this.WorkFlow_Entrance_Id;
			Unit.WorkFlow_Object_Id=this.WorkFlow_Object_Id;
			Unit.DepartmentId=this.DepartmentId;
			Unit.WorkFlow_Id=this.WorkFlow_Id;
			Unit.WorkFlow_Name=this.WorkFlow_Name;
          return Unit;
		}
		#endregion
		
	}
}
