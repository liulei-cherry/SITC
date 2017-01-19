/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：SparePurchaseOrderDetail.cs
 * 创 建 人：王鹏程
 * 创建时间：2012/4/23
 * 标    题：实体类
 * 功能描述：T_SPARE_PURCHASE_ORDER_DETAIL数据实体类
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
    ///T_SPARE_PURCHASE_ORDER_DETAIL数据实体
    /// </summary>
    ///[Serializable]
    public partial class SparePurchaseOrderDetail : CommonClass
    {
        #region 构造函数
        ///<summary> 
        ///
        ///</summary>
        public SparePurchaseOrderDetail()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public SparePurchaseOrderDetail
        (
            string pURCHASE_ORDER_DETAIL_ID,
            string pURCHASE_ORDERID,
            string cOMPONENT_UNIT_ID,
            string sPARE_ID,
            string sPARE_NAME,
            string pARTNUMBER,
            decimal pURCHASECOUNT,
            string cURRENCYID,
            string rEMARK,
            decimal pRICE,
            decimal rECEIVECOUNT,
            string rECEIVEREMARK,
            string pURCHASE_APPLYID
        )
        {
            this.PURCHASE_ORDER_DETAIL_ID = pURCHASE_ORDER_DETAIL_ID;
            this.PURCHASE_ORDERID = pURCHASE_ORDERID;
            this.COMPONENT_UNIT_ID = cOMPONENT_UNIT_ID;
            this.SPARE_ID = sPARE_ID;
            this.SPARE_NAME = sPARE_NAME;
            this.PARTNUMBER = pARTNUMBER;
            this.PURCHASECOUNT = pURCHASECOUNT;
            this.CURRENCYID = cURRENCYID;
            this.REMARK = rEMARK;
            this.PRICE = pRICE;
            this.RECEIVECOUNT = rECEIVECOUNT;
            this.RECEIVEREMARK = rECEIVEREMARK;
            this.PURCHASE_APPLYID = pURCHASE_APPLYID;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///
        ///</summary>
        public string PURCHASE_ORDER_DETAIL_ID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string PURCHASE_ORDERID { get; set; }

        ///<summary>
        ///设备id,当是子表可以存不同设备时此字段才有用
        ///</summary>
        public string COMPONENT_UNIT_ID { get; set; }

        ///<summary>
        ///备件id
        ///</summary>
        public string SPARE_ID { get; set; }

        ///<summary>
        ///备件名称
        ///</summary>
        public string SPARE_NAME { get; set; }

        ///<summary>
        ///采购号或规格
        ///</summary>
        public string PARTNUMBER { get; set; }

        ///<summary>
        ///采购数量
        ///</summary>
        public decimal PURCHASECOUNT { get; set; }

        ///<summary>
        ///货币id
        ///</summary>
        public string CURRENCYID { get; set; }

        ///<summary>
        ///备注
        ///</summary>
        public string REMARK { get; set; }

        ///<summary>
        ///采购金额
        ///</summary>
        public decimal PRICE { get; set; }

        ///<summary>
        ///到货数量
        ///</summary>
        public decimal RECEIVECOUNT { get; set; }

        ///<summary>
        ///到货评价
        ///</summary>
        public string RECEIVEREMARK { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string PURCHASE_APPLYID { get; set; }

        ///<summary>
        ///克隆一个对象
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            SparePurchaseOrderDetail Unit = new SparePurchaseOrderDetail();
            Unit.PURCHASE_ORDER_DETAIL_ID = this.PURCHASE_ORDER_DETAIL_ID;
            Unit.PURCHASE_ORDERID = this.PURCHASE_ORDERID;
            Unit.COMPONENT_UNIT_ID = this.COMPONENT_UNIT_ID;
            Unit.SPARE_ID = this.SPARE_ID;
            Unit.SPARE_NAME = this.SPARE_NAME;
            Unit.PARTNUMBER = this.PARTNUMBER;
            Unit.PURCHASECOUNT = this.PURCHASECOUNT;
            Unit.CURRENCYID = this.CURRENCYID;
            Unit.REMARK = this.REMARK;
            Unit.PRICE = this.PRICE;
            Unit.RECEIVECOUNT = this.RECEIVECOUNT;
            Unit.RECEIVEREMARK = this.RECEIVEREMARK;
            Unit.PURCHASE_APPLYID = this.PURCHASE_APPLYID;
            return Unit;
        }
        #endregion

        public override string GetId()
        {
            return this.PURCHASE_ORDER_DETAIL_ID;
        }

        public override string GetTypeName()
        {
            return "SparePurchaseOrderDetail";
        }

        public override bool Update(out string err)
        {
            return SparePurchaseOrderDetailService.Instance.saveUnit(this, out err);
        }
        public void Update()
        {
            SparePurchaseOrderDetailService.Instance.saveUnit(this);
        }
        public string UpdateSql()
        {
            return SparePurchaseOrderDetailService.Instance.saveUnitSql(this);
        }

        public override bool Delete(out string err)
        {
            return SparePurchaseOrderDetailService.Instance.deleteUnit(this.GetId(), out err);
        }
        public void Delete()
        {
            SparePurchaseOrderDetailService.Instance.deleteUnit(this.GetId());
        }
        public string DeleteSql()
        {
            return SparePurchaseOrderDetailService.Instance.deleteUnitSql(this.GetId());
        }
        public override void FillThisObject()
        {

        }
    }
}
