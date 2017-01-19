/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：BaseInfo.cs
 * 创 建 人：徐正本
 * 创建时间：2010-6-25
 * 标    题：实体类
 * 功能描述：T_BASE_HEADSHIP数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using BaseInfo.DataAccess;
using CommonOperation.Interfaces;

namespace BaseInfo.Objects
{
    /// <summary>
    ///T_BASE_HEADSHIP数据实体.
    /// </summary>
    ///[Serializable]
    public partial class Post : CommonClass, ILoginUser
    {
        #region 变量定义
        ///<summary>
        ///
        ///</summary>
        private string _pOSTID;
        ///<summary>
        ///所属部门id
        ///</summary>
        private string _dEPARTMENTID = String.Empty;
        ///<summary>
        ///是否是部门领导.
        ///</summary>
        private decimal _iSHEADER;
        ///<summary>
        ///岗位名称.
        ///</summary>
        private string _pOSTNAME = String.Empty;
        ///<summary>
        ///岗位编码.
        ///</summary>
        private string _pOSTCODE = String.Empty;
        ///<summary>
        ///岗位等级(同时用于排序)
        ///</summary>
        private decimal _pOSTLEVEL;
        ///<summary>
        ///是否是岸端岗位.
        ///</summary>
        private decimal _iSLANDPOST;
        ///<summary>
        ///岗位说明.
        ///</summary>
        private string _dETAIL = String.Empty;
        ///<summary>
        ///是否是岸端岗位.
        ///</summary>
        private decimal _iSHIGHLEVELSHIPMAN;
        ///<summary>
        ///标示是否为机务主管,机务经理等之类的问题.
        ///</summary>
        private string _pOSTTYPE;
        #endregion

        #region 构造函数
        ///<summary>
        ///
        ///</summary>
        public Post()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public Post
        (
            string pOSTID,
            string dEPARTMENTID,
            decimal iSHEADER,
            string pOSTNAME,
            string pOSTCODE,
            decimal pOSTLEVEL,
            decimal iSLANDPOST,
            decimal iSHIGHLEVELSHIPMAN,
            string dETAIL
        )
        {
            _pOSTID = pOSTID;
            _dEPARTMENTID = dEPARTMENTID;
            _iSHEADER = iSHEADER;
            _pOSTNAME = pOSTNAME;
            _pOSTCODE = pOSTCODE;
            _pOSTLEVEL = pOSTLEVEL;
            _iSLANDPOST = iSLANDPOST;
            _iSHIGHLEVELSHIPMAN = iSHIGHLEVELSHIPMAN;
            _dETAIL = dETAIL;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///
        ///</summary>
        public string POSTID
        {
            get { return _pOSTID; }
            set { _pOSTID = value; }
        }

        ///<summary>
        ///所属部门id
        ///</summary>
        public string DEPARTMENTID
        {
            get { return _dEPARTMENTID; }
            set { _dEPARTMENTID = value; }
        }

        ///<summary>
        ///是否是部门领导.
        ///</summary>
        public decimal ISHEADER
        {
            get { return _iSHEADER; }
            set { _iSHEADER = value; }
        }

        ///<summary>
        ///岗位名称.
        ///</summary>
        public string POSTNAME
        {
            get { return _pOSTNAME; }
            set { _pOSTNAME = value; }
        }

        ///<summary>
        ///岗位编码.
        ///</summary>
        public string POSTCODE
        {
            get { return _pOSTCODE; }
            set { _pOSTCODE = value; }
        }

        ///<summary>
        ///岗位等级(同时用于排序)
        ///</summary>
        public decimal POSTLEVEL
        {
            get { return _pOSTLEVEL; }
            set { _pOSTLEVEL = value; }
        }

        ///<summary>
        ///是否是岸端岗位.
        ///</summary>
        public decimal ISLANDPOST
        {
            get { return _iSLANDPOST; }
            set { _iSLANDPOST = value; }
        }
        ///<summary>
        ///是否是岸端岗位.
        ///</summary>
        public decimal IsHighLevelShipMan
        {
            get { return _iSHIGHLEVELSHIPMAN; }
            set { _iSHIGHLEVELSHIPMAN = value; }
        }
        ///<summary>
        ///岗位说明.
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
        ///岗位类型.
        ///</summary>
        public string POSTTYPE
        {
            get { return _pOSTTYPE; }
            set { _pOSTTYPE = value; }
        }
        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            Post Unit = new Post();
            Unit.POSTID = this.POSTID;
            Unit.DEPARTMENTID = this.DEPARTMENTID;
            Unit.ISHEADER = this.ISHEADER;
            Unit.POSTNAME = this.POSTNAME;
            Unit.POSTCODE = this.POSTCODE;
            Unit.POSTLEVEL = this.POSTLEVEL;
            Unit.ISLANDPOST = this.ISLANDPOST;
            Unit.IsHighLevelShipMan = this.IsHighLevelShipMan;
            Unit.DETAIL = this.DETAIL;
            Unit.POSTTYPE = this.POSTTYPE;
            return Unit;
        }
        #endregion
        public override string GetId()
        {
            return this._pOSTID;
        }

        public override string GetTypeName()
        {
            return "Post";
        }

        public override bool Update(out string err)
        {
            return PostService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return PostService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            if ((null == _Belonging || _Belonging.IsWrong) && !string.IsNullOrEmpty(_dEPARTMENTID))
            {
                _Belonging = (Department)DepartmentService.Instance.GetOneObjectById(_dEPARTMENTID);
            }
        }

        #region ILoginUser 接口实现
        /// <summary>
        /// 是否是高级船员.
        /// </summary>
        public bool ISHIGHLEVELSHIPMAN
        {
            get { return IsHighLevelShipMan == 1; }
        }
        /// <summary>
        /// 是否是岸端人员.
        /// </summary>
        public bool ISLANDPERSON { get { return _iSLANDPOST == 1; } }
        /// <summary>
        /// 是否是部门长.
        /// </summary>
        public bool ISSHIPHEADER { get { return _iSLANDPOST != 1 && _iSHEADER == 1; } }
        /// <summary>
        /// 是否是船长.
        /// </summary>
        public bool ISSHIPBOSS { get { return POSTNAME == "船长"; } }

        private int isDeckMan = -1;
        private int isMachineMan = -1;
        /// <summary>
        /// 是否是甲板部.
        /// </summary>
        public bool ISDECKMAN
        {
            get
            {
                if (isDeckMan == -1)
                {
                    FillThisObject();
                    if (_Belonging != null && _Belonging.DEPARTNAME == "甲板部")
                    {
                        isDeckMan = 1;
                        isMachineMan = 0;
                    }
                    else
                    {
                        isDeckMan = 0;
                    }
                }
                return isDeckMan == 1;
            }
        }
        /// <summary>
        /// 是否是轮机部.
        /// </summary>
        public bool ISMACHINEMAN
        {
            get
            {
                if (isMachineMan == -1)
                {
                    FillThisObject();
                    if (_Belonging != null && _Belonging.DEPARTNAME == "轮机部")
                    {
                        isDeckMan = 0;
                        isMachineMan = 1;
                    }
                    else
                    {
                        isMachineMan = 0;
                    }
                }
                return isMachineMan == 1;
            }
        }
        /// <summary>
        /// 岗位名称.
        /// </summary>
        public string ShipHeadShipName { get { return POSTNAME; } }
        /// <summary>
        /// 部门id
        /// </summary>
        public string DepartmentId { get { return _dEPARTMENTID; } }

        /// <summary>
        /// 岗位id
        /// </summary>
        public string PostId { get { return _pOSTID; } }

        public string DepartmentName
        {
            get
            {
                FillThisObject();
                if (Belonging != null) return Belonging.DEPARTNAME;
                return "";
            }
        }

        /// <summary>
        /// 岗位类型名称.
        /// </summary>
        public string POSTTYPENAME
        {
            get { return POSTTYPE; }
        }

        #endregion
    }
}