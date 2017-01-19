using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.Functions;

namespace CommonOperation.BaseClass
{
    /// <summary>
    ///T_RIGHT数据实体.
    /// </summary>
    ///[Serializable]
    public partial class BaseRight : CommonClass
    {
        #region 变量定义
        ///<summary>
        ///权限Id
        ///</summary>
        private string _rIGHT_ID;
        ///<summary>
        ///权限名称.
        ///</summary>
        private string _rIGHT_NAME = String.Empty;
        ///<summary>
        ///模块名称.
        ///</summary>
        private string _mODULE = String.Empty;
        ///<summary>
        ///备注.
        ///</summary>
        private string _rEMARK = String.Empty;
        #endregion

        #region 构造函数
        ///<summary>
        ///
        ///</summary>
        public BaseRight()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public BaseRight
        (
            string rIGHT_ID,
            string rIGHT_NAME,
            string mODULE,
            string rEMARK
        )
        {
            _rIGHT_ID = rIGHT_ID;
            _rIGHT_NAME = rIGHT_NAME;
            _mODULE = mODULE;
            _rEMARK = rEMARK;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///权限Id
        ///</summary>
        public string RIGHT_ID
        {
            get { return _rIGHT_ID; }
            set { _rIGHT_ID = value; }
        }

        ///<summary>
        ///权限名称.
        ///</summary>
        public string RIGHT_NAME
        {
            get { return _rIGHT_NAME; }
            set { _rIGHT_NAME = value; }
        }

        ///<summary>
        ///模块名称.
        ///</summary>
        public string MODULE
        {
            get { return _mODULE; }
            set { _mODULE = value; }
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
            BaseRight Unit = new BaseRight();
            Unit.RIGHT_ID = this.RIGHT_ID;
            Unit.RIGHT_NAME = this.RIGHT_NAME;
            Unit.MODULE = this.MODULE;
            Unit.REMARK = this.REMARK;
            return Unit;
        }
        #endregion
        public override string GetId()
        {
            return this._rIGHT_ID;
        }

        public override string GetTypeName()
        {
            return "BaseRight";
        }

        public override bool Update(out string err)
        {
            return BaseRightService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return BaseRightService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {

        }
    }
}
