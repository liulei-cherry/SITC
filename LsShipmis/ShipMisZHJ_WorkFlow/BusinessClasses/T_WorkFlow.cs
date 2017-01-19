/****************************************************************************************************
 * Copyright (C) 2009 大连陆海科技有限公司 版权所有
 * 文 件 名：T_WorkFlow.cs
 * 创 建 人：牛振军
 * 创建时间：2009-9-25
 * 标    题：实体类
 * 功能描述：T_WorkFlow数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
namespace ShipMisZHJ_WorkFlow.BusinessClasses
{
	/// <summary>
	///T_WorkFlow数据实体.
	/// </summary>
	///[Serializable]
	public class T_WorkFlow
	{
		#region 变量定义
		///<summary>
		///流程Id
		///</summary>
		private string _workFlow_Id;
		///<summary>
		///流程定义.
		///</summary>
		private string _workFlow = String.Empty;
		#endregion
		
		#region 构造函数
		///<summary>
		///
		///</summary>
		public T_WorkFlow()
		{
		}
		///<summary>
		///
		///</summary>
		public T_WorkFlow
		(
			string workFlow_Id,
			string workFlow
		)
		{
			_workFlow_Id = workFlow_Id;
			_workFlow    = workFlow;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///流程Id
		///</summary>
		public string WorkFlow_Id
		{
			get {return _workFlow_Id;}
			set {_workFlow_Id = value;}
		}

		///<summary>
		///流程定义.
		///</summary>
		public string WorkFlow
		{
			get {return _workFlow;}
			set {_workFlow = value;}
		}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		public T_WorkFlow Clone()
		{
			T_WorkFlow Unit = new T_WorkFlow();
			Unit.WorkFlow_Id=this.WorkFlow_Id;
			Unit.WorkFlow=this.WorkFlow;
          return Unit;
		}
		#endregion
		
	}
}
