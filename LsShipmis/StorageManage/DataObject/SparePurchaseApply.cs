/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：SparePurchaseApply.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/9/12
 * 标    题：实体类
 * 功能描述：T_SPARE_PURCHASE_APPLY数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using StorageManage.Services;
using ItemsManage.DataObject; 

namespace StorageManage.DataObject
{
    /// <summary>
    ///T_SPARE_PURCHASE_APPLY数据实体.
    /// </summary>
    ///[Serializable]
    public partial class SparePurchaseApply : CommonClass
    {
        #region 构造函数
        ///<summary> 
        ///
        ///</summary>
        public SparePurchaseApply()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public SparePurchaseApply
        (
            string pURCHASE_APPLYID,
            string sHIP_ID,
            string cOMPONENT_UNIT_ID,
            string pURCHASE_APPLY_CODE,
            string pURCHASE_APPLY_PERSON,
            string pURCHASE_APPLY_PERSON_POSTID,
            DateTime pURCHASE_APPLY_DATE,
            string dEPART_ID,
            string sHIP_LEADER_CHECKER,
            DateTime sHIP_LEADER_CHECKDATE,
            string sHIP_BOSS_CHECKER,
            DateTime sHIP_BOSS_CHECKDATE,
            string lANDCHECKER,
            DateTime cHECKDATE,
            decimal iSCOMPLETE,
            string rEMARK,
            decimal sTATE
        )
        {
            this.PURCHASE_APPLYID = pURCHASE_APPLYID;
            this.SHIP_ID = sHIP_ID;
            this.COMPONENT_UNIT_ID = cOMPONENT_UNIT_ID;
            this.PURCHASE_APPLY_CODE = pURCHASE_APPLY_CODE;
            this.PURCHASE_APPLY_PERSON = pURCHASE_APPLY_PERSON;
            this.PURCHASE_APPLY_PERSON_POSTID = pURCHASE_APPLY_PERSON_POSTID;
            this.PURCHASE_APPLY_DATE = pURCHASE_APPLY_DATE;
            this.DEPART_ID = dEPART_ID;
            this.SHIP_LEADER_CHECKER = sHIP_LEADER_CHECKER;
            this.SHIP_LEADER_CHECKDATE = sHIP_LEADER_CHECKDATE;
            this.SHIP_BOSS_CHECKER = sHIP_BOSS_CHECKER;
            this.SHIP_BOSS_CHECKDATE = sHIP_BOSS_CHECKDATE;
            this.LANDCHECKER = lANDCHECKER;
            this.CHECKDATE = cHECKDATE;
            this.ISCOMPLETE = iSCOMPLETE;
            this.REMARK = rEMARK;
            this.STATE = sTATE;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///
        ///</summary>
        public string PURCHASE_APPLYID { get; set; }

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
        public string PURCHASE_APPLY_CODE { get; set; }

        ///<summary>
        ///操作者.
        ///</summary>
        public string PURCHASE_APPLY_PERSON { get; set; }

        ///<summary>
        ///操作者岗位.
        ///</summary>
        public string PURCHASE_APPLY_PERSON_POSTID { get; set; }

        ///<summary>
        ///操作发起日期.
        ///</summary>
        public DateTime PURCHASE_APPLY_DATE { get; set; }

        ///<summary>
        ///出入库发起者的部门id
        ///</summary>
        public string DEPART_ID { get; set; }

        ///<summary>
        ///船上部门长确认者.
        ///</summary>
        public string SHIP_LEADER_CHECKER { get; set; }

        ///<summary>
        ///船上部门长确认日期.
        ///</summary>
        public DateTime SHIP_LEADER_CHECKDATE { get; set; }

        ///<summary>
        ///船上船长确认者.
        ///</summary>
        public string SHIP_BOSS_CHECKER { get; set; }

        ///<summary>
        ///船上船长确认日期.
        ///</summary>
        public DateTime SHIP_BOSS_CHECKDATE { get; set; }

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
        ///状态(0.未填写完毕,1.等待部门长审核,2等待船长确认,3等待岸端机务主管审批,4等待岸端机务经理审批,5等待船管总经理审批,6.审核通过,7.取消,8.被打回,9已订购)
        ///</summary>
        public decimal STATE { get; set; }

        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            SparePurchaseApply Unit = new SparePurchaseApply();
            Unit.PURCHASE_APPLYID = this.PURCHASE_APPLYID;
            Unit.SHIP_ID = this.SHIP_ID;
            Unit.COMPONENT_UNIT_ID = this.COMPONENT_UNIT_ID;
            Unit.PURCHASE_APPLY_CODE = this.PURCHASE_APPLY_CODE;
            Unit.PURCHASE_APPLY_PERSON = this.PURCHASE_APPLY_PERSON;
            Unit.PURCHASE_APPLY_PERSON_POSTID = this.PURCHASE_APPLY_PERSON_POSTID;
            Unit.PURCHASE_APPLY_DATE = this.PURCHASE_APPLY_DATE;
            Unit.DEPART_ID = this.DEPART_ID;
            Unit.SHIP_LEADER_CHECKER = this.SHIP_LEADER_CHECKER;
            Unit.SHIP_LEADER_CHECKDATE = this.SHIP_LEADER_CHECKDATE;
            Unit.SHIP_BOSS_CHECKER = this.SHIP_BOSS_CHECKER;
            Unit.SHIP_BOSS_CHECKDATE = this.SHIP_BOSS_CHECKDATE;
            Unit.LANDCHECKER = this.LANDCHECKER;
            Unit.CHECKDATE = this.CHECKDATE;
            Unit.ISCOMPLETE = this.ISCOMPLETE;
            Unit.REMARK = this.REMARK;
            Unit.STATE = this.STATE;
            return Unit;
        }
        #endregion

        public override string GetId()
        {
            return this.PURCHASE_APPLYID;
        }

        public override string GetTypeName()
        {
            return "SparePurchaseApply";
        }

        public override bool Update(out string err)
        {
            return SparePurchaseApplyService.Instance.saveUnit(this, out err);
        }
        /// <summary>
        /// 取得保存SQL语句 . 2014.2.18 刘子建添加.
        /// </summary>
        /// <returns></returns>
        public string GetUpdateSQL()
        {
            return SparePurchaseApplyService.Instance.saveUnit(this);
        }

        public override bool Delete(out string err)
        {
            return SparePurchaseApplyService.Instance.deleteUnit(this, out err);
        }
        private ComponentUnit theApplyEquipment;

        public ComponentUnit TheApplyEquipment
        {
            get { return theApplyEquipment; } 
        }
        private BaseInfo.Objects.ShipInfo theShipInfo;

        public BaseInfo.Objects.ShipInfo TheShipInfo
        {
            get { return theShipInfo; } 
        }

        public override void FillThisObject()
        {
            string err;
            if (theShipInfo == null)
            {
                theShipInfo = BaseInfo.DataAccess.ShipInfoService.Instance.getObject(SHIP_ID, out err);
            }
            if (theApplyEquipment == null)
            {
                theApplyEquipment = ItemsManage.Services.ComponentUnitService.Instance.getObject(COMPONENT_UNIT_ID, out err);
            }
        }
    }
}
