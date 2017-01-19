/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：Voyage.cs
 * 创 建 人：xuzhengben
 * 创建时间：2010-12-30
 * 标    题：实体类
 * 功能描述：T_VOY_VOYTIMES数据实体类
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
    ///T_VOY_VOYTIMES数据实体.
    /// </summary>
    ///[Serializable]
    public partial class Voyage : CommonClass
    {
        #region 变量定义
        ///<summary>
        ///
        ///</summary>
        private string _vOYTIMESID;
        ///<summary>
        ///
        ///</summary>
        private string _sHIP_ID = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _vOYTIMESNAME = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private DateTime _sTARTDATE;
        ///<summary>
        ///
        ///</summary>
        private DateTime _eNDDATE;
        ///<summary>
        ///
        ///</summary>
        private string _rEMARK = String.Empty;
        #endregion

        #region 构造函数
        ///<summary>
        ///
        ///</summary>
        public Voyage()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public Voyage
        (
            string vOYTIMESID,
            string sHIP_ID,
            string vOYTIMESNAME,
            DateTime sTARTDATE,
            DateTime eNDDATE,
            string rEMARK
        )
        {
            _vOYTIMESID = vOYTIMESID;
            _sHIP_ID = sHIP_ID;
            _vOYTIMESNAME = vOYTIMESNAME;
            _sTARTDATE = sTARTDATE;
            _eNDDATE = eNDDATE;
            _rEMARK = rEMARK;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///
        ///</summary>
        public string VOYTIMESID
        {
            get { return _vOYTIMESID; }
            set { _vOYTIMESID = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string SHIP_ID
        {
            get { return _sHIP_ID; }
            set { _sHIP_ID = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string VOYTIMESNAME
        {
            get { return _vOYTIMESNAME; }
            set { _vOYTIMESNAME = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public DateTime STARTDATE
        {
            get { return _sTARTDATE; }
            set { _sTARTDATE = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public DateTime ENDDATE
        {
            get { return _eNDDATE; }
            set { _eNDDATE = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string REMARK
        {
            get { return _rEMARK; }
            set { _rEMARK = value; }
        }

        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            Voyage Unit = new Voyage();
            Unit.VOYTIMESID = this.VOYTIMESID;
            Unit.SHIP_ID = this.SHIP_ID;
            Unit.VOYTIMESNAME = this.VOYTIMESNAME;
            Unit.STARTDATE = this.STARTDATE;
            Unit.ENDDATE = this.ENDDATE;
            Unit.REMARK = this.REMARK;
            return Unit;
        }
        #endregion
        public override string GetId()
        {
            return this._vOYTIMESID;
        }

        public override string GetTypeName()
        {
            return "Voyage";
        }

        public override bool Update(out string err)
        {
            return VoyageService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return VoyageService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {

        }
    }
}
