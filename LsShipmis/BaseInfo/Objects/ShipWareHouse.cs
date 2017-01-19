/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：ShipWareHouse.cs
 * 创 建 人：xuzhengben
 * 创建时间：2010/9/15
 * 标    题：实体类
 * 功能描述：T_SOM_WAREHOUSE数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using BaseInfo.DataAccess;

namespace BaseInfo.DataObject
{
    /// <summary>
    ///T_SOM_WAREHOUSE数据实体.
    /// </summary>
    ///[Serializable]
    public partial class ShipWareHouse : CommonClass
    {
        #region 变量定义
        ///<summary>
        ///
        ///</summary>
        private string _wAREHOUSE_ID;
        ///<summary>
        ///
        ///</summary>
        private string _wAREHOUSE_NAME = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _rEMARK = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _wAREHOUSE_CODE = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _sHIP_ID = String.Empty;
        #endregion

        #region 构造函数
        ///<summary>
        ///
        ///</summary>
        public ShipWareHouse()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public ShipWareHouse
        (
            string wAREHOUSE_ID,
            string wAREHOUSE_NAME,
            string rEMARK,
            string wAREHOUSE_CODE,
            string sHIP_ID
        )
        {
            _wAREHOUSE_ID = wAREHOUSE_ID;
            _wAREHOUSE_NAME = wAREHOUSE_NAME;
            _rEMARK = rEMARK;
            _wAREHOUSE_CODE = wAREHOUSE_CODE;
            _sHIP_ID = sHIP_ID;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///
        ///</summary>
        public string WAREHOUSE_ID
        {
            get { return _wAREHOUSE_ID; }
            set { _wAREHOUSE_ID = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string WAREHOUSE_NAME
        {
            get { return _wAREHOUSE_NAME; }
            set { _wAREHOUSE_NAME = value; }
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
        ///
        ///</summary>
        public string WAREHOUSE_CODE
        {
            get { return _wAREHOUSE_CODE; }
            set { _wAREHOUSE_CODE = value; }
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
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            ShipWareHouse Unit = new ShipWareHouse();
            Unit.WAREHOUSE_ID = this.WAREHOUSE_ID;
            Unit.WAREHOUSE_NAME = this.WAREHOUSE_NAME;
            Unit.REMARK = this.REMARK;
            Unit.WAREHOUSE_CODE = this.WAREHOUSE_CODE;
            Unit.SHIP_ID = this.SHIP_ID;
            return Unit;
        }
        #endregion
        public override string GetId()
        {
            return this._wAREHOUSE_ID;
        }

        public override string GetTypeName()
        {
            return "ShipWareHouse";
        }

        public override bool Update(out string err)
        {
            return ShipWareHouseService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return ShipWareHouseService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {

        }
    }
}
