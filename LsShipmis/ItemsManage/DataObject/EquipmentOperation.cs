/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：EquipmentOperation.cs
 * 创 建 人：xuzhengben
 * 创建时间：2011/4/22
 * 标    题：实体类
 * 功能描述：T_EQUIPMENT_OPERATION数据实体类
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
	///T_EQUIPMENT_OPERATION数据实体.
	/// </summary>
	///[Serializable]
	public partial class EquipmentOperation : CommonClass
	{
		#region 变量定义
		///<summary>
		///id
		///</summary>
		private string _eQUOPERATIONID;
		///<summary>
		///排序号,同设备,排序使用,同设备排序,所有同名的在一起显示,排序号必须保证这一点 如:有两个操作,开启和关闭,均有3步,则排序号推荐为.
        /// 开启1:10;开启2:20;开启3:30;关闭1:40;关闭2:50;关闭3:60;
        /// 这样方便以后插入,当然为了方便起见,可以把开启和关闭各写一条即可.
		///</summary>
		private int _sORTNO;
		///<summary>
		///设备id
		///</summary>
		private string _eQUIPMENTID = String.Empty;
		///<summary>
		///操作名称.
		///</summary>
		private string _oPERATIONNAME = String.Empty;
		///<summary>
		///操作步骤.
		///</summary>
		private string _oPERATIONDETAIL = String.Empty;
		#endregion
		
		#region 构造函数
		///<summary>
		///设备日常操作步骤说明,一种操作由一条记录构成, 每一条记录可以配一到多个操作文件,如图片,视频等,可以在软件中相应位置打开,进行进一步的查询.
   		///</summary>
		public EquipmentOperation()
		{
		}
		///<summary>
		///设备日常操作步骤说明,一种操作由一条记录构成, 每一条记录可以配一到多个操作文件,如图片,视频等,可以在软件中相应位置打开,进行进一步的查询.
   		///</summary>
		public EquipmentOperation
		(
			string eQUOPERATIONID,
			int sORTNO,
			string eQUIPMENTID,
			string oPERATIONNAME,
			string oPERATIONDETAIL
		)
		{
			_eQUOPERATIONID  = eQUOPERATIONID;
			_sORTNO          = sORTNO;
			_eQUIPMENTID     = eQUIPMENTID;
			_oPERATIONNAME   = oPERATIONNAME;
			_oPERATIONDETAIL = oPERATIONDETAIL;
			
		}
		#endregion
		
		#region 公共属性
		
		///<summary>
		///id
		///</summary>
		public string EQUOPERATIONID
		{
			get {return _eQUOPERATIONID;}
			set {_eQUOPERATIONID = value;}
		}

		///<summary>
		///排序号,同设备,排序使用,同设备排序,所有同名的在一起显示,排序号必须保证这一点.
		///如:有两个操作,开启和关闭,均有3步,则排序号推荐为.
		///开启1:10;开启2:20;开启3:30;关闭1:40;关闭2:50;关闭3:60;
		///这样方便以后插入,
        ///当然为了方便起见,可以把开启和关闭各写一条即可.
		///</summary>
		public int SORTNO
		{
			get {return _sORTNO;}
			set {_sORTNO = value;}
		}

		///<summary>
		///设备id
		///</summary>
		public string EQUIPMENTID
		{
			get {return _eQUIPMENTID;}
			set {_eQUIPMENTID = value;}
		}

		///<summary>
		///操作名称.
		///</summary>
		public string OPERATIONNAME
		{
			get {return _oPERATIONNAME;}
			set {_oPERATIONNAME = value;}
		}

		///<summary>
		///操作步骤.
		///</summary>
		public string OPERATIONDETAIL
		{
			get {return _oPERATIONDETAIL;}
			set {_oPERATIONDETAIL = value;}
		}
		
		///<summary>
		///克隆一个对象.
		///</summary>
		/// <returns>克隆的新对象</returns>	
		 public override CommonClass Clone()
		{
			EquipmentOperation Unit = new EquipmentOperation();
			Unit.EQUOPERATIONID=this.EQUOPERATIONID;
			Unit.SORTNO=this.SORTNO;
			Unit.EQUIPMENTID=this.EQUIPMENTID;
			Unit.OPERATIONNAME=this.OPERATIONNAME;
			Unit.OPERATIONDETAIL=this.OPERATIONDETAIL;
          return Unit;
		}
		#endregion
		 public override string GetId()
        {
            return this._eQUOPERATIONID;
        }

        public override string GetTypeName()
        {
            return "EquipmentOperation";
        }

        public override bool Update(out string err)
        {
            return EquipmentOperationService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return EquipmentOperationService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            
        }
	}
}
