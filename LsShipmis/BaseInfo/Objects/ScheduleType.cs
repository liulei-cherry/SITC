/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：ScheduleType.cs
 * 创 建 人：xuzb
 * 创建时间：2009-8-19
 * 标    题：实体类
 * 功能描述：T_SCHEDULE_TYPE数据实体类
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
    ///T_SCHEDULE_TYPE数据实体.
    /// </summary>
    ///[Serializable]
    public partial class ScheduleType : CommonClass
    {
        public override string GetId()
        {
            return _sCHEDULETYPEID;
        }
        public override string GetTypeName()
        {
            return "ScheduleType";
        }
        public override bool Update(out string err)
        { 
            return ScheduleTypeService.Instance.saveUnit(this,out err);
        }
        public override bool Delete(out string err)
        {
            return ScheduleTypeService.Instance.deleteUnit(this, out err);
        }
        #region 变量定义
        ///<summary>
        ///
        ///</summary>
        private string _sCHEDULETYPEID;
        ///<summary>
        ///
        ///</summary>
        private string _tYPENAME = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _dETAIL = String.Empty;
        ///<summary>
        ///1:默认当成工作日,0:默认当成非可用日.
        ///</summary>
        private decimal _iSWORKING;
        ///<summary>
        ///
        ///</summary>
        private decimal _sORT;
        #endregion

        #region 构造函数
        ///<summary>
        ///
        ///</summary>
        public ScheduleType()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public ScheduleType
        (
            string sCHEDULETYPEID,
            string tYPENAME,
            string dETAIL,
            decimal iSWORKING,
            decimal sORT
        )
        {
            _sCHEDULETYPEID = sCHEDULETYPEID;
            _tYPENAME = tYPENAME;
            _dETAIL = dETAIL;
            _iSWORKING = iSWORKING;
            _sORT = sORT;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///
        ///</summary>
        public string SCHEDULETYPEID
        {
            get { return _sCHEDULETYPEID; }
            set { _sCHEDULETYPEID = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string TYPENAME
        {
            get { return _tYPENAME; }
            set { _tYPENAME = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string DETAIL
        {
            get { return _dETAIL; }
            set { _dETAIL = value; }
        }

        ///<summary>
        ///1:默认当成工作日,0:默认当成非可用日.
        ///</summary>
        public decimal ISWORKING
        {
            get { return _iSWORKING; }
            set { _iSWORKING = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public decimal SORT
        {
            get { return _sORT; }
            set { _sORT = value; }
        }

        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            ScheduleType Unit = new ScheduleType();
            Unit.SCHEDULETYPEID = this.SCHEDULETYPEID;
            Unit.TYPENAME = this.TYPENAME;
            Unit.DETAIL = this.DETAIL;
            Unit.ISWORKING = this.ISWORKING;
            Unit.SORT = this.SORT;
            return Unit;
        }
        #endregion
        public override void FillThisObject(){}
         
    }
}
