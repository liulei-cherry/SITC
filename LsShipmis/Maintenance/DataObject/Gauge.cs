/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：Gauge.cs
 * 创 建 人：xuzhengben
 * 创建时间：2010/9/29
 * 标    题：实体类
 * 功能描述：Gauge数据实体类
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
    ///Gauge数据实体.
    /// </summary>
    ///[Serializable]
    public partial class Gauge : CommonClass
    {
        #region 变量定义
        ///<summary>
        ///主键id
        ///</summary>
        private string _gAUGE_ID;
        ///<summary>
        ///设备id 
        ///</summary>
        private string _cOMPONENT_UNIT_ID = String.Empty;
        ///<summary>
        ///是否是顶级设备（0否,1是）.
        ///</summary>
        private decimal _tOPUNIT;
        ///<summary>
        ///父设备id（与哪个设备的运转小时同步）.
        ///</summary>
        private string _pARENT_UNIT_ID = String.Empty;
        ///<summary>
        ///抄表时间.
        ///</summary>
        private DateTime _gAUGE_TIME;
        ///<summary>
        ///录入时间(取系统的时间)
        ///</summary>
        private DateTime _iNPUT_TIME;
        ///<summary>
        ///总运转值.
        ///</summary>
        private decimal _tOTAL_WORKHOURS;
        ///<summary>
        ///增长值.
        ///</summary>
        private decimal _iNCREASE_HOURS;
        ///<summary>
        ///录入方式（1,总值,2递增）.
        ///</summary>
        private decimal _rECORD_TYPE;
        ///<summary>
        ///组序号（范围为1—10000）.
        ///</summary>
        private int _sEED;
        ///<summary>
        ///成员序号（范围为组序号*10000，数量不会超过10000个）.
        ///</summary>
        private int _sUBSEED;
        #endregion

        #region 构造函数
        ///<summary>
        ///
        ///</summary>
        public Gauge()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public Gauge
        (
            string gAUGE_ID,
            string cOMPONENT_UNIT_ID,
            decimal tOPUNIT,
            string pARENT_UNIT_ID,
            DateTime gAUGE_TIME,
            DateTime iNPUT_TIME,
            decimal tOTAL_WORKHOURS,
            decimal iNCREASE_HOURS,
            decimal rECORD_TYPE,
            int sEED,
            int sUBSEED
        )
        {
            _gAUGE_ID = gAUGE_ID;
            _cOMPONENT_UNIT_ID = cOMPONENT_UNIT_ID;
            _tOPUNIT = tOPUNIT;
            _pARENT_UNIT_ID = pARENT_UNIT_ID;
            _gAUGE_TIME = gAUGE_TIME;
            _iNPUT_TIME = iNPUT_TIME;
            _tOTAL_WORKHOURS = tOTAL_WORKHOURS;
            _iNCREASE_HOURS = iNCREASE_HOURS;
            _rECORD_TYPE = rECORD_TYPE;
            _sEED = sEED;
            _sUBSEED = sUBSEED;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///主键id
        ///</summary>
        public string GAUGE_ID
        {
            get { return _gAUGE_ID; }
            set { _gAUGE_ID = value; }
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
        ///是否是顶级设备（0否,1是）.
        ///</summary>
        public decimal TOPUNIT
        {
            get { return _tOPUNIT; }
            set { _tOPUNIT = value; }
        }

        ///<summary>
        ///父设备id（与哪个设备的运转小时同步）.
        ///</summary>
        public string PARENT_UNIT_ID
        {
            get { return _pARENT_UNIT_ID; }
            set { _pARENT_UNIT_ID = value; }
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
        ///录入方式（1,总值,2递增）.
        ///</summary>
        public decimal RECORD_TYPE
        {
            get { return _rECORD_TYPE; }
            set { _rECORD_TYPE = value; }
        }

        ///<summary>
        ///组序号（范围为1—10000）.
        ///</summary>
        public int SEED
        {
            get { return _sEED; }
            set { _sEED = value; }
        }

        ///<summary>
        ///成员序号（范围为组序号*10000，数量不会超过10000个）.
        ///</summary>
        public int SUBSEED
        {
            get { return _sUBSEED; }
            set { _sUBSEED = value; }
        }

        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            Gauge Unit = new Gauge();
            Unit.GAUGE_ID = this.GAUGE_ID;
            Unit.COMPONENT_UNIT_ID = this.COMPONENT_UNIT_ID;
            Unit.TOPUNIT = this.TOPUNIT;
            Unit.PARENT_UNIT_ID = this.PARENT_UNIT_ID;
            Unit.GAUGE_TIME = this.GAUGE_TIME;
            Unit.INPUT_TIME = this.INPUT_TIME;
            Unit.TOTAL_WORKHOURS = this.TOTAL_WORKHOURS;
            Unit.INCREASE_HOURS = this.INCREASE_HOURS;
            Unit.RECORD_TYPE = this.RECORD_TYPE;
            Unit.SEED = this.SEED;
            Unit.SUBSEED = this.SUBSEED;
            return Unit;
        }
        #endregion
        public override string GetId()
        {
            return this._gAUGE_ID;
        }

        public override string GetTypeName()
        {
            return "Gauge";
        }

        public override bool Update(out string err)
        {
            return GaugeService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return GaugeService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {

        }
    }
}
