/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：Department.cs
 * 创 建 人：xuzhengben
 * 创建时间：2010-12-30
 * 标    题：实体类
 * 功能描述：
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass; 
using BaseInfo.DataAccess;
using System.Data;

namespace BaseInfo.Objects
{
    /// <summary>
    ///
    /// </summary>
    ///[Serializable]
    public partial class Department : CommonClass
    {
        #region 变量定义
        ///<summary>
        ///
        ///</summary>
        private string _dEPARTMENTID;
        ///<summary>
        ///部门名称.
        ///</summary>
        private string _dEPARTNAME = String.Empty;
        ///<summary>
        ///部门编码.
        ///</summary>
        private string _dEPARTCODE = String.Empty;
        ///<summary>
        ///上级部门id
        ///</summary>
        private string _uPDEPARTID = String.Empty;
        ///<summary>
        ///是否是岸端部门.
        ///</summary>
        private decimal _iSLANDDEPART;
        ///<summary>
        ///部门类型.
        ///</summary>
        private string _dEPARTMENTTYPE = String.Empty;

        ///<summary>
        ///排序号.
        ///</summary>
        private decimal _sORTNO;
        ///<summary>
        ///是否是固定项(1,不能在软件中修改,0,可以修改)
        ///</summary>
        private decimal _uNMODIFY;
        ///<summary>
        ///描述.
        ///</summary>
        private string _dETAIL = String.Empty;
        #endregion

        #region 构造函数
        ///<summary>
        ///
        ///</summary>
        public Department()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public Department
        (
            string dEPARTMENTID,
            string dEPARTNAME,
            string dEPARTCODE,
            string dEPARTMENTTYPE,
            string uPDEPARTID,
            decimal iSLANDDEPART,
            decimal sORTNO,
            decimal uNMODIFY,
            string dETAIL
        )
        {
            _dEPARTMENTID = dEPARTMENTID;
            _dEPARTNAME = dEPARTNAME;
            _dEPARTCODE = dEPARTCODE;
            _dEPARTMENTTYPE = dEPARTMENTTYPE;
            _uPDEPARTID = uPDEPARTID;
            _iSLANDDEPART = iSLANDDEPART;
            _sORTNO = sORTNO;
            _uNMODIFY = uNMODIFY;
            _dETAIL = dETAIL;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///
        ///</summary>
        public string DEPARTMENTID
        {
            get { return _dEPARTMENTID; }
            set { _dEPARTMENTID = value; }
        }

        ///<summary>
        ///部门名称.
        ///</summary>
        public string DEPARTNAME
        {
            get { return _dEPARTNAME; }
            set { _dEPARTNAME = value; }
        }

        ///<summary>
        ///部门编码.
        ///</summary>
        public string DEPARTCODE
        {
            get { return _dEPARTCODE; }
            set { _dEPARTCODE = value; }
        }

        ///<summary>
        ///上级部门id
        ///</summary>
        public string UPDEPARTID
        {
            get { return _uPDEPARTID; }
            set { _uPDEPARTID = value; }
        }

        ///<summary>
        ///是否是岸端部门.
        ///</summary>
        public decimal ISLANDDEPART
        {
            get { return _iSLANDDEPART; }
            set { _iSLANDDEPART = value; }
        }

        ///<summary>
        ///部门类型.
        ///</summary>
        public string DEPARTMENTTYPE
        {
            get { return _dEPARTMENTTYPE; }
            set { _dEPARTMENTTYPE = value; }
        }

        ///<summary>
        ///排序号.
        ///</summary>
        public decimal SORTNO
        {
            get { return _sORTNO; }
            set { _sORTNO = value; }
        }

        ///<summary>
        ///是否是固定项(1,不能在软件中修改,0,可以修改)
        ///</summary>
        public decimal UNMODIFY
        {
            get { return _uNMODIFY; }
            set { _uNMODIFY = value; }
        }

        ///<summary>
        ///描述.
        ///</summary>
        public string DETAIL
        {
            get { return _dETAIL; }
            set { _dETAIL = value; }
        }
        private Department _Belonging;
        ///<summary>
        ///所属部门.
        ///</summary>
        public Department Belonging
        {
            get { return _Belonging; }
            set { _Belonging = value; }
        }
        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            Department Unit = new Department();
            Unit.DEPARTMENTID = this.DEPARTMENTID;
            Unit.DEPARTNAME = this.DEPARTNAME;
            Unit.DEPARTCODE = this.DEPARTCODE;
            Unit.UPDEPARTID = this.UPDEPARTID;
            Unit.ISLANDDEPART = this.ISLANDDEPART;
            Unit.SORTNO = this.SORTNO;
            Unit.UNMODIFY = this.UNMODIFY;
            Unit.DETAIL = this.DETAIL;
            return Unit;
        }
        #endregion
        public override string GetId()
        {
            return this._dEPARTMENTID;
        }

        public override string GetTypeName()
        {
            return "Department";
        }

        public override bool Update(out string err)
        {
            return DepartmentService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            if (beforeDelete(out err))
                return DepartmentService.Instance.deleteUnit(this, out err);
            else 
                return false;
        }

        public override void FillThisObject()
        {
            if ((null == _Belonging || _Belonging.IsWrong) && !string.IsNullOrEmpty(UPDEPARTID))
            {
                _Belonging = (Department)DepartmentService.Instance.GetOneObjectById(UPDEPARTID);
            }
        }

        public override string ToString()
        {
            return this.DEPARTNAME + (string.IsNullOrEmpty(this.DEPARTCODE) ? "" : "(" + this.DEPARTCODE + ")");
        }
        private bool beforeDelete(out string err)
        {
            err = "";
            //不允许修改的内容不能删除.
            if (_uNMODIFY == 1)
            {
                err = "标准部门不允许删除";
                return false;
            }
            //包含下级的不能删除.
            if (DepartmentService.Instance.GetDepartmentByParentId(_dEPARTMENTID).Count > 0)
            {
                err = "当前部门下存在下级部门,不能删除";
                return false;
            }
            //包含已经安排岗位的不能删除.
            DataTable dt = PostService.Instance.getDepartPosts(_dEPARTMENTID, out err);
            if (dt != null && dt.Rows.Count > 0)
            {
                err = "当前部门已经安排了具体岗位,不能删除";
                return false;
            }
            return true;
        }
    }
}
