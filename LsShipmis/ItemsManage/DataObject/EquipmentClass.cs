/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：EquipmentClass.cs
 * 创 建 人：xuzhengben
 * 创建时间：2011/4/28
 * 标    题：实体类
 * 功能描述：T_EQUIPMENT_CLASS数据实体类
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
    ///T_EQUIPMENT_CLASS数据实体.
    /// </summary>
    ///[Serializable]
    public partial class EquipmentClass : CommonClass
    {
        #region 变量定义
        ///<summary>
        ///id
        ///</summary>
        private string _cLASSID;
        ///<summary>
        ///分类代码.
        ///</summary>
        private string _cLASSCODE = String.Empty;
        ///<summary>
        ///分类名称.
        ///</summary>
        private string _cLASSNAME = String.Empty;
        ///<summary>
        ///1:部门,2系统;3设备种类,图标不一样,其它一样.
        ///</summary>
        private decimal _cLASSTYPE;
        ///<summary>
        ///分类描述.
        ///</summary>
        private string _cLASSDETAIL = String.Empty;
        ///<summary>
        ///排序号,
        ///</summary>
        private decimal _sORTNO;
        ///<summary>
        ///上级分类id
        ///</summary>
        private string _pARENTCLASSID = String.Empty;
        #endregion

        #region 构造函数
        ///<summary>
        ///船舶设备分类结构,可以使用用户要求的结构对设备进行分组.
        ///分类的时候可以按照使用部门\系统\设备种类的方式;
        ///也可以按照CWBT要求的方式进行分类.
        ///</summary>
        public EquipmentClass()
        {
        }
        ///<summary>
        ///船舶设备分类结构,可以使用用户要求的结构对设备进行分组.
        /// 分类的时候可以按照使用部门\系统\设备种类的方式;
        /// 也可以按照CWBT要求的方式进行分类.
        ///</summary>
        public EquipmentClass
        (
            string cLASSID,
            string cLASSCODE,
            string cLASSNAME,
            decimal cLASSTYPE,
            string cLASSDETAIL,
            decimal sORTNO,
            string pARENTCLASSID
        )
        {
            _cLASSID = cLASSID;
            _cLASSCODE = cLASSCODE;
            _cLASSNAME = cLASSNAME;
            _cLASSTYPE = cLASSTYPE;
            _cLASSDETAIL = cLASSDETAIL;
            _sORTNO = sORTNO;
            _pARENTCLASSID = pARENTCLASSID;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///id
        ///</summary>
        public string CLASSID
        {
            get { return _cLASSID; }
            set { _cLASSID = value; }
        }

        ///<summary>
        ///分类代码.
        ///</summary>
        public string CLASSCODE
        {
            get { return _cLASSCODE; }
            set { _cLASSCODE = value; }
        }

        ///<summary>
        ///分类名称.
        ///</summary>
        public string CLASSNAME
        {
            get { return _cLASSNAME; }
            set { _cLASSNAME = value; }
        }

        ///<summary>
        ///1:部门,2系统;3设备种类,图标不一样,其它一样.
        ///</summary>
        public decimal CLASSTYPE
        {
            get { return _cLASSTYPE; }
            set { _cLASSTYPE = value; }
        }

        ///<summary>
        ///分类描述.
        ///</summary>
        public string CLASSDETAIL
        {
            get { return _cLASSDETAIL; }
            set { _cLASSDETAIL = value; }
        }

        ///<summary>
        ///排序号,
        ///</summary>
        public decimal SORTNO
        {
            get { return _sORTNO; }
            set { _sORTNO = value; }
        }

        ///<summary>
        ///上级分类id
        ///</summary>
        public string PARENTCLASSID
        {
            get { return _pARENTCLASSID; }
            set { _pARENTCLASSID = value; }
        }

        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            EquipmentClass Unit = new EquipmentClass();
            Unit.CLASSID = this.CLASSID;
            Unit.CLASSCODE = this.CLASSCODE;
            Unit.CLASSNAME = this.CLASSNAME;
            Unit.CLASSTYPE = this.CLASSTYPE;
            Unit.CLASSDETAIL = this.CLASSDETAIL;
            Unit.SORTNO = this.SORTNO;
            Unit.PARENTCLASSID = this.PARENTCLASSID;
            return Unit;
        }
        #endregion

        public override string GetId()
        {
            return this._cLASSID;
        }

        public override string GetTypeName()
        {
            return "EquipmentClass";
        }

        public override bool Update(out string err)
        { 
            if (!EquipmentClassService.Instance.saveUnit(this, out err)) return false;
            return EquipmentClassService.Instance.resortClass(PARENTCLASSID, out err);
        }

        public override bool Delete(out string err)
        {
            List<EquipmentClass> lists = EquipmentClassService.Instance.GetObjectsByParentId(_cLASSID);
            if (lists.Count > 0)
            {
                err = "有子分类不能删除!";
                return false;
            }
            return EquipmentClassService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {

        }

        /// <summary>
        /// 另一个构造,不加入排序号,默认用99999
        /// </summary>
        /// <param name="cLASSID"></param>
        /// <param name="cLASSCODE"></param>
        /// <param name="cLASSNAME"></param>
        /// <param name="cLASSTYPE"></param>
        /// <param name="cLASSDETAIL"></param>
        /// <param name="PARENTCLASSID"></param>
        public EquipmentClass
       (
           string cLASSID,
           string cLASSCODE,
           string cLASSNAME,
           decimal cLASSTYPE,
           string cLASSDETAIL,
           string pARENTCLASSID
        )
        {
            _cLASSID = cLASSID;
            _cLASSCODE = cLASSCODE;
            _cLASSNAME = cLASSNAME;
            _cLASSTYPE = cLASSTYPE;
            _cLASSDETAIL = cLASSDETAIL;
            _pARENTCLASSID = pARENTCLASSID;
            _sORTNO = 99999;
        }

        public override string ToString()
        {
            string re = _cLASSNAME;
            if (!string.IsNullOrEmpty(_cLASSCODE) && !_cLASSNAME.Contains (_cLASSCODE))
            {
                re += "("+_cLASSCODE+")";
            }
            return re;
        }
    }
}
