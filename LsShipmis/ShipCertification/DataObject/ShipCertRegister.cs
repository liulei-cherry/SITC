/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：ShipCertRegister.cs
 * 创 建 人：徐正本
 * 创建时间：2011/8/31
 * 标    题：实体类
 * 功能描述：T_SHIP_CERT_REGISTER数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using ShipCertification.Services;

namespace ShipCertification.DataObject
{
    /// <summary>
    ///T_SHIP_CERT_REGISTER数据实体.
    /// </summary>
    ///[Serializable]
    public partial class ShipCertRegister : CommonClass
    {
        #region 构造函数
        ///<summary> 
        ///
        ///</summary>
        public ShipCertRegister()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public ShipCertRegister
        (
            string sHIP_CERT_REGISTERID,
            string sHIP_CERT_ID,
            string sHIP_CERT_NAME,
            string sHIP_ID,
            string sHIP_CERT_DEPARTID,
            decimal sHIPCERTTYPE,
            string sHIPCERTNUMB,
            decimal eFFECTDATE,
            DateTime sIGNEDDATE,
            DateTime mATUREDATE,
            decimal aLERTDAYS,
            decimal rECERTIFICATION,
            string rEMARK,
            int sORTNO,
            string pLACE,
            DateTime eXPIREDATE
        )
        {
            this.SHIP_CERT_REGISTERID = sHIP_CERT_REGISTERID;
            this.SHIP_CERT_ID = sHIP_CERT_ID;
            this.SHIP_CERT_NAME = sHIP_CERT_NAME;
            this.SHIP_ID = sHIP_ID;
            this.SHIP_CERT_DEPARTID = sHIP_CERT_DEPARTID;
            this.SHIPCERTTYPE = sHIPCERTTYPE;
            this.SHIPCERTNUMB = sHIPCERTNUMB;
            this.EFFECTDATE = eFFECTDATE;
            this.SIGNEDDATE = sIGNEDDATE;
            this.MATUREDATE = mATUREDATE;
            this.ALERTDAYS = aLERTDAYS;
            this.RECERTIFICATION = rECERTIFICATION;
            this.REMARK = rEMARK;
            this.SORTNO = sORTNO;
            this.PLACE = pLACE;
            this.EXPIREDATE = eXPIREDATE;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///证书登记Id
        ///</summary>
        public string SHIP_CERT_REGISTERID { get; set; }

        ///<summary>
        ///证书基础信息Id
        ///</summary>
        public string SHIP_CERT_ID { get; set; }

        ///<summary>
        ///证书名称.
        ///</summary>
        public string SHIP_CERT_NAME { get; set; }

        ///<summary>
        ///船舶Id
        ///</summary>
        public string SHIP_ID { get; set; }

        ///<summary>
        ///发证机构Id
        ///</summary>
        public string SHIP_CERT_DEPARTID { get; set; }

        ///<summary>
        ///证书类型(1长期、2定期、3临时、4存档)
        ///</summary>
        public decimal SHIPCERTTYPE { get; set; }

        ///<summary>
        ///证书号码.
        ///</summary>
        public string SHIPCERTNUMB { get; set; }

        ///<summary>
        ///有效期(以年为单位可以录入0.5)
        ///</summary>
        public decimal EFFECTDATE { get; set; }

        ///<summary>
        ///签发日期.
        ///</summary>
        public DateTime SIGNEDDATE { get; set; }

        ///<summary>
        ///到期日期.
        ///</summary>
        public DateTime MATUREDATE { get; set; }

        ///<summary>
        ///报警天数(长期证书不用报警)
        ///</summary>
        public decimal ALERTDAYS { get; set; }

        ///<summary>
        ///证书换发(0表示未换发,1表示换发)
        ///</summary>
        public decimal RECERTIFICATION { get; set; }

        ///<summary>
        ///备注.
        ///</summary>
        public string REMARK { get; set; }

        ///<summary>
        ///
        ///</summary>
        public int SORTNO { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string PLACE { get; set; }

        ///<summary>
        ///有效日期.
        ///</summary>
        public DateTime EXPIREDATE { get; set; }

        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            ShipCertRegister Unit = new ShipCertRegister();
            Unit.SHIP_CERT_REGISTERID = this.SHIP_CERT_REGISTERID;
            Unit.SHIP_CERT_ID = this.SHIP_CERT_ID;
            Unit.SHIP_CERT_NAME = this.SHIP_CERT_NAME;
            Unit.SHIP_ID = this.SHIP_ID;
            Unit.SHIP_CERT_DEPARTID = this.SHIP_CERT_DEPARTID;
            Unit.SHIPCERTTYPE = this.SHIPCERTTYPE;
            Unit.SHIPCERTNUMB = this.SHIPCERTNUMB;
            Unit.EFFECTDATE = this.EFFECTDATE;
            Unit.SIGNEDDATE = this.SIGNEDDATE;
            Unit.MATUREDATE = this.MATUREDATE;
            Unit.ALERTDAYS = this.ALERTDAYS;
            Unit.RECERTIFICATION = this.RECERTIFICATION;
            Unit.REMARK = this.REMARK;
            Unit.SORTNO = this.SORTNO;
            Unit.PLACE = this.PLACE;
            Unit.EXPIREDATE = this.EXPIREDATE;
            return Unit;
        }
        #endregion

        public override string GetId()
        {
            return this.SHIP_CERT_REGISTERID;
        }

        public override string GetTypeName()
        {
            return "ShipCertRegister";
        }

        public override bool Update(out string err)
        {
            return ShipCertRegisterService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return ShipCertRegisterService.Instance.deleteUnit(this, out err);
        }
         
        public override void FillThisObject()
        {
            if ((thisCert == null || thisCert.IsWrong) && !string.IsNullOrEmpty(SHIP_CERT_ID))
            {
                thisCert = (ShipCert)ShipCertService.Instance.GetOneObjectById(SHIP_CERT_ID);
            }
            if ((thisDepart == null || thisDepart.IsWrong) && !string.IsNullOrEmpty(SHIP_CERT_DEPARTID))
            {
                thisDepart = (ShipCertDepart)ShipCertDepartService.Instance.GetOneObjectById(SHIP_CERT_DEPARTID);
            }
            
        }

        private ShipCertDepart thisDepart;

        public ShipCertDepart ThisDepart
        {
            get { return thisDepart; }
            set { thisDepart = value; }
        }
        private ShipCert thisCert;

        public ShipCert ThisCert
        {
            get { return thisCert; }
            set { thisCert = value; }
        }
        public override string ToString()
        {
             return SHIP_CERT_NAME;           
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
