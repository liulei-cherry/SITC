/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：Currency.cs
 * 创 建 人：徐正本
 * 创建时间：2011/7/1
 * 标    题：实体类
 * 功能描述：T_CURRENCY数据实体类
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
    ///T_CURRENCY数据实体.
    /// </summary>
    ///[Serializable]
    public partial class Currency : CommonClass
    {
        #region 构造函数
        ///<summary> 
        ///货币基本表.
        ///</summary>
        public Currency()
        {
        }
        ///<summary>
        ///货币基本表.
        ///</summary>
        public Currency
        (
            string cURRENCYID,
            string cURRENCYNAME,
            string cURRENCYCODE,
            string fULLNAME,
            string kEYNAME,
            decimal iNUSE,
            string rEMARK
        )
        {
            this.CURRENCYID = cURRENCYID;
            this.CURRENCYNAME = cURRENCYNAME;
            this.CURRENCYCODE = cURRENCYCODE;
            this.FULLNAME = fULLNAME;
            this.KEYNAME = kEYNAME;
            this.INUSE = iNUSE;
            this.REMARK = rEMARK;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///货币id
        ///</summary>
        public string CURRENCYID { get; set; }

        ///<summary>
        ///货币中文名称.
        ///</summary>
        public string CURRENCYNAME { get; set; }

        ///<summary>
        ///标准货币编码*
        ///</summary>
        public string CURRENCYCODE { get; set; }

        ///<summary>
        ///标准货币全名.
        ///</summary>
        public string FULLNAME { get; set; }

        ///<summary>
        ///标准货币简写.
        ///</summary>
        public string KEYNAME { get; set; }

        ///<summary>
        ///是否常用货币(0,不常用,1常用)
        ///</summary>
        public decimal INUSE { get; set; }

        ///<summary>
        ///备注.
        ///</summary>
        public string REMARK { get; set; }

        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            Currency Unit = new Currency();
            Unit.CURRENCYID = this.CURRENCYID;
            Unit.CURRENCYNAME = this.CURRENCYNAME;
            Unit.CURRENCYCODE = this.CURRENCYCODE;
            Unit.FULLNAME = this.FULLNAME;
            Unit.KEYNAME = this.KEYNAME;
            Unit.INUSE = this.INUSE;
            Unit.REMARK = this.REMARK;
            return Unit;
        }
        #endregion

        public override string GetId()
        {
            return this.CURRENCYID;
        }

        public override string GetTypeName()
        {
            return "Currency";
        }

        public override bool Update(out string err)
        {
            return CurrencyService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return CurrencyService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {

        }

        private bool canSave(out string err)
        {
            //如果重复了则不能保存.
            if (!CurrencyService.Instance.HaveTheCurrency(CURRENCYCODE, GetId(), out err)) return false;
            return true;
        }
    }
}
