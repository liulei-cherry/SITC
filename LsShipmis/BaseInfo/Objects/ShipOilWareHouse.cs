/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：ShipOilWareHouse.cs
 * 创 建 人：shengwen
 * 创建时间：2009-11-11
 * 标    题：实体类
 * 功能描述：T_SHIP_owWareHouse数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;

namespace BaseInfo.Objects
{
    /// <summary>
    ///T_SHIP_owWareHouse数据实体.
    /// </summary>
    ///[Serializable]
    public partial class ShipOilWareHouse : CommonClass
    {
        #region 变量定义
        ///<summary>
        ///主键.
        ///</summary>
        private string _owWareHouse_ID;
        ///<summary>
        ///船舶Id
        ///</summary>
        private string _sHIP_ID = String.Empty;
        ///<summary>
        ///仓柜序号.
        ///</summary>
        private string _cGXH = String.Empty;
        ///<summary>
        ///型容积.
        ///</summary>
        private decimal _xRJ;
        ///<summary>
        ///净容积.
        ///</summary>
        private decimal _jRJ;
        ///<summary>
        ///位置.
        ///</summary>
        private string _wZ = String.Empty;
        ///<summary>
        ///备注.
        ///</summary>
        private string _rEMARK = String.Empty;
        #endregion

        #region 构造函数
        ///<summary>
        ///
        ///</summary>
        public ShipOilWareHouse()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public ShipOilWareHouse
        (
            string owWareHouse_ID,
            string sHIP_ID,
            string cGXH,
            decimal xRJ,
            decimal jRJ,
            string wZ,
            string rEMARK
        )
        {
            _owWareHouse_ID = owWareHouse_ID;
            _sHIP_ID = sHIP_ID;
            _cGXH = cGXH;
            _xRJ = xRJ;
            _jRJ = jRJ;
            _wZ = wZ;
            _rEMARK = rEMARK;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///主键.
        ///</summary>
        public string owWareHouse_ID
        {
            get { return _owWareHouse_ID; }
            set { _owWareHouse_ID = value; }
        }

        ///<summary>
        ///船舶Id
        ///</summary>
        public string SHIP_ID
        {
            get { return _sHIP_ID; }
            set { _sHIP_ID = value; }
        }

        ///<summary>
        ///仓柜序号.
        ///</summary>
        public string CGXH
        {
            get { return _cGXH; }
            set { _cGXH = value; }
        }

        ///<summary>
        ///型容积.
        ///</summary>
        public decimal XRJ
        {
            get { return _xRJ; }
            set { _xRJ = value; }
        }

        ///<summary>
        ///净容积.
        ///</summary>
        public decimal JRJ
        {
            get { return _jRJ; }
            set { _jRJ = value; }
        }

        ///<summary>
        ///位置.
        ///</summary>
        public string WZ
        {
            get { return _wZ; }
            set { _wZ = value; }
        }

        ///<summary>
        ///备注.
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
            ShipOilWareHouse Unit = new ShipOilWareHouse();
            Unit.owWareHouse_ID = this.owWareHouse_ID;
            Unit.SHIP_ID = this.SHIP_ID;
            Unit.CGXH = this.CGXH;
            Unit.XRJ = this.XRJ;
            Unit.JRJ = this.JRJ;
            Unit.WZ = this.WZ;
            Unit.REMARK = this.REMARK;
            return Unit;
        }
        #endregion

    }
}
