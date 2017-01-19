/****************************************************************************************************
 * Copyright (C) 2009 大连陆海科技有限公司 版权所有
 * 文 件 名：T_Department.cs
 * 创 建 人：牛振军
 * 创建时间：2009-9-27
 * 标    题：实体类
 * 功能描述：T_Department数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
namespace ShipMisZHJ_WorkFlow.BusinessClasses
{
	/// <summary>
	///T_Department数据实体.
	/// </summary>
	///[Serializable]
	public class T_Department
	{
		#region 变量定义
		///<summary>
		///部门Id
		///</summary>
		private string _departmentId;
		///<summary>
		///
		///</summary>
		private string _parentId = String.Empty;
		///<summary>
		///部门名称.
		///</summary>
		private string _departmentName = String.Empty;
		///<summary>
		///部门类型（1表示船舶端，2表示岸端）.
		///</summary>
		private decimal _departType;
		///<summary>
		///排序号.
		///</summary>
		private int _theOrder;
		#endregion
		
		#region 构造函数
		///<summary>
		///
		///</summary>
		public T_Department()
		{
		}
		///<summary>
		///
		///</summary>
		public T_Department
		(
			string departmentId,
			string parentId,
			string departmentName,
			decimal departType,
			int theOrder
		)
		{
			_departmentId   = departmentId;
			_parentId       = parentId;
			_departmentName = departmentName;
			_departType     = departType;
			_theOrder       = theOrder;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///部门Id
		///</summary>
		public string DepartmentId
		{
			get {return _departmentId;}
			set {_departmentId = value;}
		}

		///<summary>
		///
		///</summary>
		public string ParentId
		{
			get {return _parentId;}
			set {_parentId = value;}
		}

		///<summary>
		///部门名称.
		///</summary>
		public string DepartmentName
		{
			get {return _departmentName;}
			set {_departmentName = value;}
		}

		///<summary>
		///部门类型（1表示船舶端，2表示岸端）.
		///</summary>
		public decimal DepartType
		{
			get {return _departType;}
			set {_departType = value;}
		}

		///<summary>
		///排序号.
		///</summary>
		public int TheOrder
		{
			get {return _theOrder;}
			set {_theOrder = value;}
		}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public T_Department Clone()
		{
			T_Department Unit = new T_Department();
			Unit.DepartmentId=this.DepartmentId;
			Unit.ParentId=this.ParentId;
			Unit.DepartmentName=this.DepartmentName;
			Unit.DepartType=this.DepartType;
			Unit.TheOrder=this.TheOrder;
          return Unit;
		}
		#endregion
		
	}
}
