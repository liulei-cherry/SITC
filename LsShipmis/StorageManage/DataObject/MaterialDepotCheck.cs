/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：MaterialDepotCheck.cs
 * 创 建 人：徐正本
 * 创建时间：2011/8/16
 * 标    题：实体类
 * 功能描述：T_MATERIAL_DEPOT_CHECK数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using StorageManage.Services;

namespace StorageManage.DataObject
{
    /// <summary>
    ///T_MATERIAL_DEPOT_CHECK数据实体.
    /// </summary>
    ///[Serializable]
    public partial class MaterialDepotCheck : CommonClass
    {
        #region 构造函数
        ///<summary> 
        ///盘点,对于某个库的物资进行盘点.
        ///</summary>
        public MaterialDepotCheck()
        {
        }
        ///<summary>
        ///盘点,对于某个库的物资进行盘点.
        ///</summary>
        public MaterialDepotCheck
        (
            string dEPOTCHECKID,
            string sHIP_ID,
            string wAREHOUSE_ID,
            string cHECK_CODE,
            string cHECK_PERSON,
            string cHECK_PERSON_POSTID,
            string dEPART_ID,
            DateTime cHECK_DATE,
            string sHIPCHECKER,
            string lANDCHECKER,
            DateTime cHECKDATE,
            decimal iSCOMPLETE,
            string rEMARK,
            decimal sTATE,
            string bALANCEDEPOTCHECKID
        )
        {
            this.DEPOTCHECKID = dEPOTCHECKID;
            this.SHIP_ID = sHIP_ID;
            this.WAREHOUSE_ID = wAREHOUSE_ID;
            this.CHECK_CODE = cHECK_CODE;
            this.CHECK_PERSON = cHECK_PERSON;
            this.CHECK_PERSON_POSTID = cHECK_PERSON_POSTID;
            this.DEPART_ID = dEPART_ID;
            this.CHECK_DATE = cHECK_DATE;
            this.SHIPCHECKER = sHIPCHECKER;
            this.LANDCHECKER = lANDCHECKER;
            this.CHECKDATE = cHECKDATE;
            this.ISCOMPLETE = iSCOMPLETE;
            this.REMARK = rEMARK;
            this.STATE = sTATE;
            this.BALANCEDEPOTCHECKID = bALANCEDEPOTCHECKID;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///
        ///</summary>
        public string DEPOTCHECKID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string SHIP_ID { get; set; }

        ///<summary>
        ///仓库id
        ///</summary>
        public string WAREHOUSE_ID { get; set; }

        ///<summary>
        ///盘点单号.
        ///</summary>
        public string CHECK_CODE { get; set; }

        ///<summary>
        ///操作者.
        ///</summary>
        public string CHECK_PERSON { get; set; }

        ///<summary>
        ///操作者岗位.
        ///</summary>
        public string CHECK_PERSON_POSTID { get; set; }

        ///<summary>
        ///盘点发起者的部门id
        ///</summary>
        public string DEPART_ID { get; set; }

        ///<summary>
        ///操作发起日期.
        ///</summary>
        public DateTime CHECK_DATE { get; set; }

        ///<summary>
        ///船上确认者.
        ///</summary>
        public string SHIPCHECKER { get; set; }

        ///<summary>
        ///岸端确认者.
        ///</summary>
        public string LANDCHECKER { get; set; }

        ///<summary>
        ///岸端确认日期.
        ///</summary>
        public DateTime CHECKDATE { get; set; }

        ///<summary>
        ///是否完成操作(0,未完成,1完成)完成才能进行其它操作.
        ///</summary>
        public decimal ISCOMPLETE { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string REMARK { get; set; }

        ///<summary>
        ///状态(状态(1.等待岸端审阅,2.等待船端调整,3.等待船端确认,4等待岸端确认,5审核被打回,6岸端确认))
        ///</summary>
        public decimal STATE { get; set; }

        ///<summary>
        ///冲账id,如果不为空,则表示冲账账单,只有岸端审核或已经盘点的单据才能被冲账.
        ///</summary>
        public string BALANCEDEPOTCHECKID { get; set; }

        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            MaterialDepotCheck Unit = new MaterialDepotCheck();
            Unit.DEPOTCHECKID = this.DEPOTCHECKID;
            Unit.SHIP_ID = this.SHIP_ID;
            Unit.WAREHOUSE_ID = this.WAREHOUSE_ID;
            Unit.CHECK_CODE = this.CHECK_CODE;
            Unit.CHECK_PERSON = this.CHECK_PERSON;
            Unit.CHECK_PERSON_POSTID = this.CHECK_PERSON_POSTID;
            Unit.DEPART_ID = this.DEPART_ID;
            Unit.CHECK_DATE = this.CHECK_DATE;
            Unit.SHIPCHECKER = this.SHIPCHECKER;
            Unit.LANDCHECKER = this.LANDCHECKER;
            Unit.CHECKDATE = this.CHECKDATE;
            Unit.ISCOMPLETE = this.ISCOMPLETE;
            Unit.REMARK = this.REMARK;
            Unit.STATE = this.STATE;
            Unit.BALANCEDEPOTCHECKID = this.BALANCEDEPOTCHECKID;
            return Unit;
        }
        #endregion

        public override string GetId()
        {
            return this.DEPOTCHECKID;
        }

        public override string GetTypeName()
        {
            return "MaterialDepotCheck";
        }

        public override bool Update(out string err)
        {
            return MaterialDepotCheckService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return MaterialDepotCheckService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {

        }
    }
}
