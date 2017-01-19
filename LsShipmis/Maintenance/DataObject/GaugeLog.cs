/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：GaugeLog.cs
 * 创 建 人：xuzhengben
 * 创建时间：2010/9/29
 * 标    题：实体类
 * 功能描述：T_GAUGE_LOG数据实体类
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
    ///T_GAUGE_LOG数据实体.
    /// </summary>
    ///[Serializable]
    public partial class GaugeLog : CommonClass
    {
        #region 变量定义
        ///<summary>
        ///主键id
        ///</summary>
        private string _t_GAUGE_LOG_ID;
        ///<summary>
        ///设备id 
        ///</summary>
        private string _cOMPONENT_UNIT_ID = String.Empty;
        ///<summary>
        ///总运转值.
        ///</summary>
        private decimal _tOTAL_WORKHOURS;
        ///<summary>
        ///增长值.
        ///</summary>
        private decimal _iNCREASE_HOURS;
        ///<summary>
        ///抄表时间.
        ///</summary>
        private DateTime _gAUGE_TIME;
        ///<summary>
        ///录入时间(取系统的时间)
        ///</summary>
        private DateTime _iNPUT_TIME;
        ///<summary>
        ///录入方式（1,总值,2递增）.
        ///</summary>
        private decimal _rECORD_TYPE;
        ///<summary>
        ///抄表人.
        ///</summary>
        private string _iNPUTOR = String.Empty;
        #endregion

        #region 构造函数
        ///<summary>
        ///
        ///</summary>
        public GaugeLog()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public GaugeLog
        (
            string t_GAUGE_LOG_ID,
            string cOMPONENT_UNIT_ID,
            decimal tOTAL_WORKHOURS,
            decimal iNCREASE_HOURS,
            DateTime gAUGE_TIME,
            DateTime iNPUT_TIME,
            decimal rECORD_TYPE,
            string iNPUTOR
        )
        {
            _t_GAUGE_LOG_ID = t_GAUGE_LOG_ID;
            _cOMPONENT_UNIT_ID = cOMPONENT_UNIT_ID;
            _tOTAL_WORKHOURS = tOTAL_WORKHOURS;
            _iNCREASE_HOURS = iNCREASE_HOURS;
            _gAUGE_TIME = gAUGE_TIME;
            _iNPUT_TIME = iNPUT_TIME;
            _rECORD_TYPE = rECORD_TYPE;
            _iNPUTOR = iNPUTOR;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///主键id
        ///</summary>
        public string T_GAUGE_LOG_ID
        {
            get { return _t_GAUGE_LOG_ID; }
            set { _t_GAUGE_LOG_ID = value; }
        }

        ///<summary>
        ///设备id 
        ///</summary>
        public string COMPONENT_UNIT_ID
        {
            get { return _cOMPONENT_UNIT_ID; }
            set { _cOMPONENT_UNIT_ID = value; }
        }

        ///<summary>
        ///总运转值.
        ///</summary>
        public decimal TOTAL_WORKHOURS
        {
            get { return _tOTAL_WORKHOURS; }
            set { _tOTAL_WORKHOURS = value; }
        }

        ///<summary>
        ///增长值.
        ///</summary>
        public decimal INCREASE_HOURS
        {
            get { return _iNCREASE_HOURS; }
            set { _iNCREASE_HOURS = value; }
        }

        ///<summary>
        ///抄表时间.
        ///</summary>
        public DateTime GAUGE_TIME
        {
            get { return _gAUGE_TIME; }
            set { _gAUGE_TIME = value; }
        }

        ///<summary>
        ///录入时间(取系统的时间)
        ///</summary>
        public DateTime INPUT_TIME
        {
            get { return _iNPUT_TIME; }
            set { _iNPUT_TIME = value; }
        }

        ///<summary>
        ///录入方式（1,总值,2递增）.
        ///</summary>
        public decimal RECORD_TYPE
        {
            get { return _rECORD_TYPE; }
            set { _rECORD_TYPE = value; }
        }

        ///<summary>
        ///抄表人.
        ///</summary>
        public string INPUTOR
        {
            get { return _iNPUTOR; }
            set { _iNPUTOR = value; }
        }

        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            GaugeLog Unit = new GaugeLog();
            Unit.T_GAUGE_LOG_ID = this.T_GAUGE_LOG_ID;
            Unit.COMPONENT_UNIT_ID = this.COMPONENT_UNIT_ID;
            Unit.TOTAL_WORKHOURS = this.TOTAL_WORKHOURS;
            Unit.INCREASE_HOURS = this.INCREASE_HOURS;
            Unit.GAUGE_TIME = this.GAUGE_TIME;
            Unit.INPUT_TIME = this.INPUT_TIME;
            Unit.RECORD_TYPE = this.RECORD_TYPE;
            Unit.INPUTOR = this.INPUTOR;
            return Unit;
        }
        #endregion
        public override string GetId()
        {
            return this._t_GAUGE_LOG_ID;
        }

        public override string GetTypeName()
        {
            return "GaugeLog";
        }

        public override bool Update(out string err)
        {
            return GaugeLogService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return GaugeLogService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {

        }
    }
}
