/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：ShipHold.cs
 * 创 建 人：shengwen
 * 创建时间：2009-11-11
 * 标    题：实体类
 * 功能描述：T_SHIP_HOLD数据实体类
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
    ///T_SHIP_HOLD数据实体.
    /// </summary>
    ///[Serializable]
    public partial class ShipHold : CommonClass
    {
        #region 变量定义
        ///<summary>
        ///主键.
        ///</summary>
        private string _hOLD_ID;
        ///<summary>
        ///船舶Id
        ///</summary>
        private string _sHIP_ID = String.Empty;
        ///<summary>
        ///货仓编号.
        ///</summary>
        private string _hCBH = String.Empty;
        ///<summary>
        ///舱口长度.
        ///</summary>
        private decimal _cKCD;
        ///<summary>
        ///舱口宽度.
        ///</summary>
        private decimal _cKKD;
        ///<summary>
        ///舱内长度.
        ///</summary>
        private decimal _cNCD;
        ///<summary>
        ///舱内宽度.
        ///</summary>
        private decimal _cNKD;
        ///<summary>
        ///舱内高度.
        ///</summary>
        private decimal _cNGD;
        ///<summary>
        ///散装容积.
        ///</summary>
        private decimal _sZRJ;
        ///<summary>
        ///包装容积.
        ///</summary>
        private decimal _bZRJ;
        ///<summary>
        ///起货设备.
        ///</summary>
        private decimal _qHSB;
        ///<summary>
        ///备注.
        ///</summary>
        private string _rEMARK = String.Empty;
        #endregion

        #region 构造函数
        ///<summary>
        ///
        ///</summary>
        public ShipHold()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public ShipHold
        (
            string hOLD_ID,
            string sHIP_ID,
            string hCBH,
            decimal cKCD,
            decimal cKKD,
            decimal cNCD,
            decimal cNKD,
            decimal cNGD,
            decimal sZRJ,
            decimal bZRJ,
            decimal qHSB,
            string rEMARK
        )
        {
            _hOLD_ID = hOLD_ID;
            _sHIP_ID = sHIP_ID;
            _hCBH = hCBH;
            _cKCD = cKCD;
            _cKKD = cKKD;
            _cNCD = cNCD;
            _cNKD = cNKD;
            _cNGD = cNGD;
            _sZRJ = sZRJ;
            _bZRJ = bZRJ;
            _qHSB = qHSB;
            _rEMARK = rEMARK;
        }
        #endregion

        #region 公共属性

        ///<summary>
        ///主键.
        ///</summary>
        public string HOLD_ID
        {
            get { return _hOLD_ID; }
            set { _hOLD_ID = value; }
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
        ///货仓编号.
        ///</summary>
        public string HCBH
        {
            get { return _hCBH; }
            set { _hCBH = value; }
        }

        ///<summary>
        ///舱口长度.
        ///</summary>
        public decimal CKCD
        {
            get { return _cKCD; }
            set { _cKCD = value; }
        }

        ///<summary>
        ///舱口宽度.
        ///</summary>
        public decimal CKKD
        {
            get { return _cKKD; }
            set { _cKKD = value; }
        }

        ///<summary>
        ///舱内长度.
        ///</summary>
        public decimal CNCD
        {
            get { return _cNCD; }
            set { _cNCD = value; }
        }

        ///<summary>
        ///舱内宽度.
        ///</summary>
        public decimal CNKD
        {
            get { return _cNKD; }
            set { _cNKD = value; }
        }

        ///<summary>
        ///舱内高度.
        ///</summary>
        public decimal CNGD
        {
            get { return _cNGD; }
            set { _cNGD = value; }
        }

        ///<summary>
        ///散装容积.
        ///</summary>
        public decimal SZRJ
        {
            get { return _sZRJ; }
            set { _sZRJ = value; }
        }

        ///<summary>
        ///包装容积.
        ///</summary>
        public decimal BZRJ
        {
            get { return _bZRJ; }
            set { _bZRJ = value; }
        }

        ///<summary>
        ///起货设备.
        ///</summary>
        public decimal QHSB
        {
            get { return _qHSB; }
            set { _qHSB = value; }
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
            ShipHold Unit = new ShipHold();
            Unit.HOLD_ID = this.HOLD_ID;
            Unit.SHIP_ID = this.SHIP_ID;
            Unit.HCBH = this.HCBH;
            Unit.CKCD = this.CKCD;
            Unit.CKKD = this.CKKD;
            Unit.CNCD = this.CNCD;
            Unit.CNKD = this.CNKD;
            Unit.CNGD = this.CNGD;
            Unit.SZRJ = this.SZRJ;
            Unit.BZRJ = this.BZRJ;
            Unit.QHSB = this.QHSB;
            Unit.REMARK = this.REMARK;
            return Unit;
        }
        #endregion

    }
}
