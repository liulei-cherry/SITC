/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：MaterialPurchaseOrderDetail.cs
 * 创 建 人：王鹏程
 * 创建时间：2012/4/23
 * 标    题：实体类
 * 功能描述：T_MATERIAL_PURCHASE_ORDER_DETAIL数据实体类
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
    ///T_MATERIAL_PURCHASE_ORDER_DETAIL数据实体
    /// </summary>
    ///[Serializable]
    public partial class MaterialPurchaseOrderDetail : CommonClass
    {
        #region 构造函数
        ///<summary> 
        ///
        ///</summary>
        public MaterialPurchaseOrderDetail()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public MaterialPurchaseOrderDetail
        (
                string pURCHASE_ORDER_DETAIL_ID,
            string pURCHASE_ORDERID,
            string mATERIAL_ID,
            string mATERIAL_NAME,
            string mATERIAL_CODE,
            string mATERIAL_SPEC,
            decimal pURCHASECOUNT,
            string cURRENCYID,
            string rEMARK,
            decimal pRICE,
            decimal rECEIVECOUNT,
            string rECEIVEREMARK,
            string pURCHASE_APPLYID,
            int oRDERNUM
        )
        {
            this.PURCHASE_ORDER_DETAIL_ID = pURCHASE_ORDER_DETAIL_ID;
            this.PURCHASE_ORDERID = pURCHASE_ORDERID;
            this.MATERIAL_ID = mATERIAL_ID;
            this.MATERIAL_NAME = mATERIAL_NAME;
            this.MATERIAL_CODE = mATERIAL_CODE;
            this.MATERIAL_SPEC = mATERIAL_SPEC;
            this.PURCHASECOUNT = pURCHASECOUNT;
            this.CURRENCYID = cURRENCYID;
            this.REMARK = rEMARK;
            this.PRICE = pRICE;
            this.RECEIVECOUNT = rECEIVECOUNT;
            this.RECEIVEREMARK = rECEIVEREMARK;
            this.PURCHASE_APPLYID = pURCHASE_APPLYID;
            this.ORDERNUM = oRDERNUM;

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
        ///备件id
        ///</summary>
        public string MATERIAL_ID { get; set; }

        ///<summary>
        ///备件名称
        ///</summary>
        public string MATERIAL_NAME { get; set; }

        ///<summary>
        ///采购号或规格
        ///</summary>
        public string MATERIAL_CODE { get; set; }

        ///<summary>
        ///备件名称
        ///</summary>
        public string MATERIAL_SPEC { get; set; }

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
        ///序号
        ///</summary>
        public int ORDERNUM { get; set; }
		
        ///<summary>
        ///克隆一个对象
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            MaterialPurchaseOrderDetail Unit = new MaterialPurchaseOrderDetail();
            Unit.PURCHASE_ORDER_DETAIL_ID = this.PURCHASE_ORDER_DETAIL_ID;
            Unit.PURCHASE_ORDERID = this.PURCHASE_ORDERID;
            Unit.MATERIAL_ID = this.MATERIAL_ID;
            Unit.MATERIAL_NAME = this.MATERIAL_NAME;
            Unit.MATERIAL_CODE = this.MATERIAL_CODE;
            Unit.MATERIAL_SPEC = this.MATERIAL_SPEC;
            Unit.PURCHASECOUNT = this.PURCHASECOUNT;
            Unit.CURRENCYID = this.CURRENCYID;
            Unit.REMARK = this.REMARK;
            Unit.PRICE = this.PRICE;
            Unit.RECEIVECOUNT = this.RECEIVECOUNT;
            Unit.RECEIVEREMARK = this.RECEIVEREMARK;
            Unit.PURCHASE_APPLYID = this.PURCHASE_APPLYID;
            Unit.ORDERNUM = this.ORDERNUM;
            return Unit;
        }
        #endregion

        public override string GetId()
        {
            return this.PURCHASE_ORDER_DETAIL_ID;
        }

        public override string GetTypeName()
        {
            return "MaterialPurchaseOrderDetail";
        }

        public override bool Update(out string err)
        {
            return MaterialPurchaseOrderDetailService.Instance.saveUnit(this, out err);
        }
        public void Update()
        {
            MaterialPurchaseOrderDetailService.Instance.saveUnit(this);
        }
        public string UpdateSql()
        {
            return MaterialPurchaseOrderDetailService.Instance.saveUnitSql(this);
        }

        public override bool Delete(out string err)
        {
            return MaterialPurchaseOrderDetailService.Instance.deleteUnit(this.GetId(), out err);
        }
        public void Delete()
        {
            MaterialPurchaseOrderDetailService.Instance.deleteUnit(this.GetId());
        }
        public string DeleteSql()
        {
            return MaterialPurchaseOrderDetailService.Instance.deleteUnitSql(this.GetId());
        }
        public override void FillThisObject()
        {

        }
    }
}
