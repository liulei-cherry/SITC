/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：WorkModelType.cs
 * 创 建 人：徐正本
 * 创建时间：2010-6-12
 * 标    题：实体类
 * 功能描述：WorkModelType数据实体类
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
	///WorkModelType数据实体.
	/// </summary>
	///[Serializable]
	public partial class WorkModelType : CommonClass
	{
		#region 变量定义
		///<summary>
		///模板类ID
		///</summary>
		private string _modelID;
		///<summary>
		///模板名称.
		///</summary>
		private string _modelName = String.Empty;
		///<summary>
		///1.甲板部月度预防检修计划表 2.轮机部月度预防检修计划表 3.甲板部月度保养计划执行表 4.轮机部月度保养计划执行表  5.甲板部年度预防检修计划表 6.轮机部年度预防检修计划表.
		///</summary>
		private decimal _type;
		///<summary>
		///内容说明.
		///</summary>
		private string _contentExp = String.Empty;
		///<summary>
		///模板文件.
		///</summary>
		private string _modelFile = String.Empty;
		///<summary>
		///日期开始列号.
		///</summary>
		private decimal _dateCol;
		///<summary>
		///
		///</summary>
		private decimal _dateRow;
		///<summary>
		///
		///</summary>
		private string _sHIP_ID = String.Empty;
		#endregion
		
		#region 构造函数
		///<summary>
		///
		///</summary>
		public WorkModelType()
		{
		}
		///<summary>
		///
		///</summary>
		public WorkModelType
		(
			string modelID,
			string modelName,
			decimal type,
			string contentExp,
			string modelFile,
			decimal dateCol,
			decimal dateRow,
			string sHIP_ID
		)
		{
			_modelID    = modelID;
			_modelName  = modelName;
			_type       = type;
			_contentExp = contentExp;
			_modelFile  = modelFile;
			_dateCol    = dateCol;
			_dateRow    = dateRow;
			_sHIP_ID    = sHIP_ID;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///模板类ID
		///</summary>
		public string ModelID
		{
			get {return _modelID;}
			set {_modelID = value;}
		}

		///<summary>
		///模板名称.
		///</summary>
		public string ModelName
		{
			get {return _modelName;}
			set {_modelName = value;}
		}

		///<summary>
		///1.甲板部月度预防检修计划表 2.轮机部月度预防检修计划表 3.甲板部月度保养计划执行表 4.轮机部月度保养计划执行表  5.甲板部年度预防检修计划表 6.轮机部年度预防检修计划表.
		///</summary>
		public decimal type
		{
			get {return _type;}
			set {_type = value;}
		}

		///<summary>
		///内容说明.
		///</summary>
		public string ContentExp
		{
			get {return _contentExp;}
			set {_contentExp = value;}
		}

		///<summary>
		///模板文件.
		///</summary>
		public string ModelFile
		{
			get {return _modelFile;}
			set {_modelFile = value;}
		}

		///<summary>
		///日期开始列号.
		///</summary>
		public decimal DateCol
		{
			get {return _dateCol;}
			set {_dateCol = value;}
		}

		///<summary>
		///
		///</summary>
		public decimal DateRow
		{
			get {return _dateRow;}
			set {_dateRow = value;}
		}

		///<summary>
		///
		///</summary>
		public string SHIP_ID
		{
			get {return _sHIP_ID;}
			set {_sHIP_ID = value;}
		}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		 public override CommonClass Clone()
		{
			WorkModelType Unit = new WorkModelType();
			Unit.ModelID=this.ModelID;
			Unit.ModelName=this.ModelName;
			Unit.type=this.type;
			Unit.ContentExp=this.ContentExp;
			Unit.ModelFile=this.ModelFile;
			Unit.DateCol=this.DateCol;
			Unit.DateRow=this.DateRow;
			Unit.SHIP_ID=this.SHIP_ID;
          return Unit;
		}
		#endregion
		 public override string GetId()
        {
            return this._modelID;
        }

        public override string GetTypeName()
        {
            return "WorkModelType";
        }

        public override bool Update(out string err)
        {
            return WorkModelTypeService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return WorkModelTypeService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
