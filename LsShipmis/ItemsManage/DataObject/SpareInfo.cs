/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：SpareInfo.cs
 * 创 建 人：徐正本
 * 创建时间：2011/5/24
 * 标    题：实体类
 * 功能描述：T_SPARE数据实体类
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
    ///T_SPARE数据实体.
    /// </summary>
    ///[Serializable]
    public partial class SpareInfo : CommonClass
    {
        #region 变量定义
        ///<summary>
        ///主键.
        ///</summary>
        private string _sPARE_ID;
        ///<summary>
        ///备件中文名称.
        ///</summary>
        private string _sPARE_NAME = String.Empty;
        ///<summary>
        ///备件英文名称.
        ///</summary>
        private string _sPARE_ENAME = String.Empty;
        ///<summary>
        ///配件号.
        ///</summary>
        private string _pARTNUMBER = String.Empty;
        ///<summary>
        ///图号.
        ///</summary>
        private string _pICNUMBER = String.Empty;
        ///<summary>
        ///在图编号.
        ///</summary>
        private string _pICCODE = String.Empty;
        ///<summary>
        ///构成材料.
        ///</summary>
        private string _sPARESTUFF = String.Empty;
        ///<summary>
        ///所属设备.
        ///</summary>
        private string _aTTACHCOMP = String.Empty;
        ///<summary>
        ///所属类型.
        ///</summary>
        private string _aTTACHTYPE = String.Empty;
        ///<summary>
        ///备注.
        ///</summary>
        private string _rEMARK = String.Empty;
        ///<summary>
        ///是否是特殊公用备件(0表示否,1表示是),这些备件都是比较普遍的如保险丝,开关等,它们无需与设备类型挂勾,这些备件由专门界面维护,但与其它备件共同保存在一个表里。.
        ///</summary>
        private byte _iSSPECIALSP;
        ///<summary>
        ///警戒库存.
        ///</summary>
        private decimal _aLERTSTOCK;
        ///<summary>
        ///
        ///</summary>
        private string _pARTNUMBER_HIS1 = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _pARTNUMBER_HIS2 = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _uNIT_NAME = String.Empty;
        #endregion

        #region 构造函数
        ///<summary>
        ///
        ///</summary>
        public SpareInfo()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public SpareInfo
        (
            string sPARE_ID,
            string sPARE_NAME,
            string sPARE_ENAME,
            string pARTNUMBER,
            string pICNUMBER,
            string pICCODE,
            string sPARESTUFF,
            string aTTACHCOMP,
            string aTTACHTYPE,
            string rEMARK,
            byte iSSPECIALSP,
            decimal aLERTSTOCK,
            string pARTNUMBER_HIS1,
            string pARTNUMBER_HIS2,
            string uNIT_NAME
        )
        {
            _sPARE_ID = sPARE_ID;
            _sPARE_NAME = sPARE_NAME;
            _sPARE_ENAME = sPARE_ENAME;
            _pARTNUMBER = pARTNUMBER;
            _pICNUMBER = pICNUMBER;
            _pICCODE = pICCODE;
            _sPARESTUFF = sPARESTUFF;
            _aTTACHCOMP = aTTACHCOMP;
            _aTTACHTYPE = aTTACHTYPE;
            _rEMARK = rEMARK;
            _iSSPECIALSP = iSSPECIALSP;
            _aLERTSTOCK = aLERTSTOCK;
            _pARTNUMBER_HIS1 = pARTNUMBER_HIS1;
            _pARTNUMBER_HIS2 = pARTNUMBER_HIS2;
            _uNIT_NAME = uNIT_NAME;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///主键.
        ///</summary>
        public string SPARE_ID
        {
            get { return _sPARE_ID; }
            set { _sPARE_ID = value; }
        }

        ///<summary>
        ///备件中文名称.
        ///</summary>
        public string SPARE_NAME
        {
            get { return _sPARE_NAME; }
            set { _sPARE_NAME = value; }
        }

        ///<summary>
        ///备件英文名称.
        ///</summary>
        public string SPARE_ENAME
        {
            get { return _sPARE_ENAME; }
            set { _sPARE_ENAME = value; }
        }

        ///<summary>
        ///配件号.
        ///</summary>
        public string PARTNUMBER
        {
            get { return _pARTNUMBER; }
            set { _pARTNUMBER = value; }
        }

        ///<summary>
        ///图号.
        ///</summary>
        public string PICNUMBER
        {
            get { return _pICNUMBER; }
            set { _pICNUMBER = value; }
        }

        ///<summary>
        ///在图编号.
        ///</summary>
        public string PICCODE
        {
            get { return _pICCODE; }
            set { _pICCODE = value; }
        }

        ///<summary>
        ///构成材料.
        ///</summary>
        public string SPARESTUFF
        {
            get { return _sPARESTUFF; }
            set { _sPARESTUFF = value; }
        }

        ///<summary>
        ///所属设备.
        ///</summary>
        public string ATTACHCOMP
        {
            get { return _aTTACHCOMP; }
            set { _aTTACHCOMP = value; }
        }

        ///<summary>
        ///所属类型.
        ///</summary>
        public string ATTACHTYPE
        {
            get { return _aTTACHTYPE; }
            set { _aTTACHTYPE = value; }
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
        ///是否是特殊公用备件(0表示否,1表示是),这些备件都是比较普遍的如保险丝,开关等,它们无需与设备类型挂勾,这些备件由专门界面维护,但与其它备件共同保存在一个表里。.
        ///</summary>
        public byte ISSPECIALSP
        {
            get { return _iSSPECIALSP; }
            set { _iSSPECIALSP = value; }
        }

        ///<summary>
        ///警戒库存.
        ///</summary>
        public decimal ALERTSTOCK
        {
            get { return _aLERTSTOCK; }
            set { _aLERTSTOCK = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string PARTNUMBER_HIS1
        {
            get { return _pARTNUMBER_HIS1; }
            set { _pARTNUMBER_HIS1 = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string PARTNUMBER_HIS2
        {
            get { return _pARTNUMBER_HIS2; }
            set { _pARTNUMBER_HIS2 = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string UNIT_NAME
        {
            get { return _uNIT_NAME; }
            set { _uNIT_NAME = value; }
        }

        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            SpareInfo Unit = new SpareInfo();
            Unit.SPARE_ID = this.SPARE_ID;
            Unit.SPARE_NAME = this.SPARE_NAME;
            Unit.SPARE_ENAME = this.SPARE_ENAME;
            Unit.PARTNUMBER = this.PARTNUMBER;
            Unit.PICNUMBER = this.PICNUMBER;
            Unit.PICCODE = this.PICCODE;
            Unit.SPARESTUFF = this.SPARESTUFF;
            Unit.ATTACHCOMP = this.ATTACHCOMP;
            Unit.ATTACHTYPE = this.ATTACHTYPE;
            Unit.REMARK = this.REMARK;
            Unit.ISSPECIALSP = this.ISSPECIALSP;
            Unit.ALERTSTOCK = this.ALERTSTOCK;
            Unit.PARTNUMBER_HIS1 = this.PARTNUMBER_HIS1;
            Unit.PARTNUMBER_HIS2 = this.PARTNUMBER_HIS2;
            Unit.UNIT_NAME = this.UNIT_NAME;
            return Unit;
        }
        #endregion
        public override string GetId()
        {
            return this._sPARE_ID;
        }

        public override string GetTypeName()
        {
            return "SpareInfo";
        }

        public override bool Update(out string err)
        {
            return SpareInfoService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return SpareInfoService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {

        }
        public override string ToString()
        {
            return _sPARE_NAME + (string.IsNullOrEmpty(_pARTNUMBER) ? "" : "(" + _pARTNUMBER + ")");
        }
    }
}
