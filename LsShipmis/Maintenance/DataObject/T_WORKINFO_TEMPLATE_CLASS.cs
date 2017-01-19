/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：T_WORKINFO_TEMPLATE_CLASS.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-5-13
 * 标    题：实体类
 * 功能描述：T_WORKINFO_TEMPLATE_CLASS数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using Maintenance.Services;

namespace Maintenance.DataObject
{
	/// <summary>
	///T_WORKINFO_TEMPLATE_CLASS数据实体.
	/// </summary>
	///[Serializable]
	public partial class T_WORKINFO_TEMPLATE_CLASS : CommonClass
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private string _nODE_ID;
		///<summary>
		///分类名称.
		///</summary>
		private string _nODE_NAME = String.Empty;
		///<summary>
		///父节点ID
		///</summary>
		private string _pARENT_NODE_ID = String.Empty;
		///<summary>
		///
		///</summary>
		private int _sORTNO;
		#endregion
		
		#region 构造函数
		///<summary>
		///工作信息模板的分类信息.
		///</summary>
		public T_WORKINFO_TEMPLATE_CLASS()
		{
		}
		///<summary>
		///工作信息模板的分类信息.
		///</summary>
		public T_WORKINFO_TEMPLATE_CLASS
		(
			string nODE_ID,
			string nODE_NAME,
			string pARENT_NODE_ID,
			int sORTNO
		)
		{
			_nODE_ID        = nODE_ID;
			_nODE_NAME      = nODE_NAME;
			_pARENT_NODE_ID = pARENT_NODE_ID;
			_sORTNO         = sORTNO;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///
		///</summary>
		public string NODE_ID
		{
			get {return _nODE_ID;}
			set {_nODE_ID = value;}
		}

		///<summary>
		///分类名称.
		///</summary>
		public string NODE_NAME
		{
			get {return _nODE_NAME;}
			set {_nODE_NAME = value;}
		}

		///<summary>
		///父节点ID
		///</summary>
		public string PARENT_NODE_ID
		{
			get {return _pARENT_NODE_ID;}
			set {_pARENT_NODE_ID = value;}
		}

		///<summary>
		///
		///</summary>
		public int SORTNO
		{
			get {return _sORTNO;}
			set {_sORTNO = value;}
		}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		 public override CommonClass Clone()
		{
			T_WORKINFO_TEMPLATE_CLASS Unit = new T_WORKINFO_TEMPLATE_CLASS();
			Unit.NODE_ID=this.NODE_ID;
			Unit.NODE_NAME=this.NODE_NAME;
			Unit.PARENT_NODE_ID=this.PARENT_NODE_ID;
			Unit.SORTNO=this.SORTNO;
          return Unit;
		}
		#endregion
		 public override string GetId()
        {
            return this._nODE_ID;
        }

        public override string GetTypeName()
        {
            return "T_WORKINFO_TEMPLATE_CLASS";
        }

        public override bool Update(out string err)
        {
            return T_WORKINFO_TEMPLATE_CLASSService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return T_WORKINFO_TEMPLATE_CLASSService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
