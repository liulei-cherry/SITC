/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：SpareDepotOperation.cs
 * 创 建 人：徐正本
 * 创建时间：2011/8/4
 * 标    题：实体类
 * 功能描述：T_SPARE_DEPOT_OPERATION数据实体类
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
    ///T_SPARE_DEPOT_OPERATION数据实体.
    /// </summary>
    ///[Serializable]
    public partial class SpareDepotOperation : CommonClass
    {
        #region 构造函数
        ///<summary> 
        ///
        ///</summary>
        public SpareDepotOperation()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public SpareDepotOperation
        (
            string dEPOTOPERID,
            string sHIP_ID,
            string cOMPONENT_UNIT_ID,
            string oPERATION_CODE,
            string oPERATION_PERSON,
            string OPERATION_PERSON_POSTID,
            decimal iN_OR_OUT,
            DateTime oPERATION_DATE,
            string dEPART_ID,
            string sHIPCHECKER,
            string lANDCHECKER,
            DateTime cHECKDATE,
            decimal iSCOMPLETE,
            string rEMARK,
            decimal sTATE,
            string bALANCEDEPOTOPERID,
            decimal dINSTORAGETYPE
        )
        {
            this.DEPOTOPERID = dEPOTOPERID;
            this.SHIP_ID = sHIP_ID;
            this.COMPONENT_UNIT_ID = cOMPONENT_UNIT_ID;
            this.OPERATION_CODE = oPERATION_CODE;
            this.OPERATION_PERSON = oPERATION_PERSON;
            this.OPERATION_PERSON_POSTID = OPERATION_PERSON_POSTID;
            this.IN_OR_OUT = iN_OR_OUT;
            this.OPERATION_DATE = oPERATION_DATE;
            this.DEPART_ID = dEPART_ID;
            this.SHIPCHECKER = sHIPCHECKER;
            this.LANDCHECKER = lANDCHECKER;
            this.CHECKDATE = cHECKDATE;
            this.ISCOMPLETE = iSCOMPLETE;
            this.REMARK = rEMARK;
            this.STATE = sTATE;
            this.BALANCEDEPOTOPERID = bALANCEDEPOTOPERID;
            this.INSTORAGETYPE = dINSTORAGETYPE;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///
        ///</summary>
        public string DEPOTOPERID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string SHIP_ID { get; set; }

        ///<summary>
        ///如果是全单单个设备的,需要填写此id
        ///</summary>
        public string COMPONENT_UNIT_ID { get; set; }

        ///<summary>
        ///处理单号.
        ///</summary>
        public string OPERATION_CODE { get; set; }

        ///<summary>
        ///操作者.
        ///</summary>
        public string OPERATION_PERSON { get; set; }

        ///<summary>
        ///操作者岗位.
        ///</summary>
        public string OPERATION_PERSON_POSTID { get; set; }

        ///<summary>
        ///出库还是入库,1入库2出库(移库形成两个单子)
        ///</summary>
        public decimal IN_OR_OUT { get; set; }

        ///<summary>
        ///操作发起日期.
        ///</summary>
        public DateTime OPERATION_DATE { get; set; }

        ///<summary>
        ///出入库发起者的部门id
        ///</summary>
        public string DEPART_ID { get; set; }

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
        ///状态(1.等待船端确认,2等待岸端确认,3岸端打回,4岸端确认,5已经盘点)
        ///</summary>
        public decimal STATE { get; set; }

        ///<summary>
        ///冲账id,如果不为空,则表示冲账账单,只有岸端审核或已经盘点的单据才能被冲账.
        ///</summary>
        public string BALANCEDEPOTOPERID { get; set; }
        /// <summary>
        /// 入库类型（2013-6-26-zhangy）
        /// 1.订单入库2.申请单入库3.手工入库作为出库时该字段值无用默认0即可
        /// </summary>
        public decimal INSTORAGETYPE { get; set; }

        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            SpareDepotOperation Unit = new SpareDepotOperation();
            Unit.DEPOTOPERID = this.DEPOTOPERID;
            Unit.SHIP_ID = this.SHIP_ID;
            Unit.COMPONENT_UNIT_ID = this.COMPONENT_UNIT_ID;
            Unit.OPERATION_CODE = this.OPERATION_CODE;
            Unit.OPERATION_PERSON = this.OPERATION_PERSON;
            Unit.OPERATION_PERSON_POSTID = this.OPERATION_PERSON_POSTID;
            Unit.IN_OR_OUT = this.IN_OR_OUT;
            Unit.OPERATION_DATE = this.OPERATION_DATE;
            Unit.DEPART_ID = this.DEPART_ID;
            Unit.SHIPCHECKER = this.SHIPCHECKER;
            Unit.LANDCHECKER = this.LANDCHECKER;
            Unit.CHECKDATE = this.CHECKDATE;
            Unit.ISCOMPLETE = this.ISCOMPLETE;
            Unit.REMARK = this.REMARK;
            Unit.STATE = this.STATE;
            Unit.BALANCEDEPOTOPERID = this.BALANCEDEPOTOPERID;
            Unit.INSTORAGETYPE = this.INSTORAGETYPE;
            return Unit;
        }
        #endregion
        public override string GetId()
        {
            return this.DEPOTOPERID;
        }

        public override string GetTypeName()
        {
            return "SpareDepotOperation";
        }

        public override bool Update(out string err)
        {
            return SpareDepotOperationService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return SpareDepotOperationService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {

        }
    }
}
