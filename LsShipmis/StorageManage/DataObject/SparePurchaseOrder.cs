/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：SparePurchaseOrder.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/9/10
 * 标    题：实体类
 * 功能描述：T_SPARE_PURCHASE_ORDER数据实体类
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
    ///T_SPARE_PURCHASE_ORDER数据实体.
    /// </summary>
    ///[Serializable]
    public partial class SparePurchaseOrder : CommonClass
    {
        #region 构造函数
        ///<summary> 
        ///
        ///</summary>
        public SparePurchaseOrder()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public SparePurchaseOrder
        (
            string pURCHASE_ORDERID,
            string cURRENCYID,
            string sHIP_ID,
            string cOMPONENT_UNIT_ID,
            string sUPPLIER_ID,
            string pURCHASE_ORDER_CODE,
            string pURCHASE_ORDER_PERSON,
            DateTime pURCHASE_ORDER_DATE,
            string lANDCHECKER,
            DateTime cHECKDATE,
            string rEMARK,
            decimal sTATE,
            decimal tOTALPRICE,
            decimal eXTRAPRICE,
            DateTime sENDDATE,
            decimal iSCOMPLETE,
            string sENDPORT
        )
        {
            this.PURCHASE_ORDERID = pURCHASE_ORDERID;
            this.CURRENCYID = cURRENCYID;
            this.SHIP_ID = sHIP_ID;
            this.COMPONENT_UNIT_ID = cOMPONENT_UNIT_ID;
            this.SUPPLIER_ID = sUPPLIER_ID;
            this.PURCHASE_ORDER_CODE = pURCHASE_ORDER_CODE;
            this.PURCHASE_ORDER_PERSON = pURCHASE_ORDER_PERSON;
            this.PURCHASE_ORDER_DATE = pURCHASE_ORDER_DATE;
            this.LANDCHECKER = lANDCHECKER;
            this.CHECKDATE = cHECKDATE;
            this.REMARK = rEMARK;
            this.STATE = sTATE;
            this.TOTALPRICE = tOTALPRICE;
            this.EXTRAPRICE = eXTRAPRICE;
            this.SENDDATE = sENDDATE;
            this.ISCOMPLETE = iSCOMPLETE;
            this.SENDPORT = sENDPORT;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///
        ///</summary>
        public string PURCHASE_ORDERID { get; set; }

        ///<summary>
        ///货币id
        ///</summary>
        public string CURRENCYID { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string SHIP_ID { get; set; }

        ///<summary>
        ///如果是全单单个设备的,需要填写此id
        ///</summary>
        public string COMPONENT_UNIT_ID { get; set; }

        ///<summary>
        ///供应商.
        ///</summary>
        public string SUPPLIER_ID { get; set; }

        ///<summary>
        ///处理单号.
        ///</summary>
        public string PURCHASE_ORDER_CODE { get; set; }

        ///<summary>
        ///操作者.
        ///</summary>
        public string PURCHASE_ORDER_PERSON { get; set; }

        ///<summary>
        ///操作发起日期.
        ///</summary>
        public DateTime PURCHASE_ORDER_DATE { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string LANDCHECKER { get; set; }

        ///<summary>
        ///岸端确认日期.
        ///</summary>
        public DateTime CHECKDATE { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string REMARK { get; set; }

        ///<summary>
        ///状态(0.未填写完毕,1等待机务主管审批,2等待机务经理审批,3等待船管总经理审批,4订单打回,5订购,6.此订单作废,7.部分到货,8.结束,9.已生成凭证)
        ///</summary>
        public decimal STATE { get; set; }

        ///<summary>
        ///总价.
        ///</summary>
        public decimal TOTALPRICE { get; set; }

        ///<summary>
        ///附加费用.
        ///</summary>
        public decimal EXTRAPRICE { get; set; }

        ///<summary>
        ///到货日期.
        ///</summary>
        public DateTime SENDDATE { get; set; }

        ///<summary>
        ///是否完成操作(0,未完成,1完成)完成才能进行其它操作.
        ///</summary>
        public decimal ISCOMPLETE { get; set; }

        ///<summary>
        ///送货港口.
        ///</summary>
        public string SENDPORT { get; set; }

        ///<summary>
        ///克隆一个对象.
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            SparePurchaseOrder Unit = new SparePurchaseOrder();
            Unit.PURCHASE_ORDERID = this.PURCHASE_ORDERID;
            Unit.CURRENCYID = this.CURRENCYID;
            Unit.SHIP_ID = this.SHIP_ID;
            Unit.COMPONENT_UNIT_ID = this.COMPONENT_UNIT_ID;
            Unit.SUPPLIER_ID = this.SUPPLIER_ID;
            Unit.PURCHASE_ORDER_CODE = this.PURCHASE_ORDER_CODE;
            Unit.PURCHASE_ORDER_PERSON = this.PURCHASE_ORDER_PERSON;
            Unit.PURCHASE_ORDER_DATE = this.PURCHASE_ORDER_DATE;
            Unit.LANDCHECKER = this.LANDCHECKER;
            Unit.CHECKDATE = this.CHECKDATE;
            Unit.REMARK = this.REMARK;
            Unit.STATE = this.STATE;
            Unit.TOTALPRICE = this.TOTALPRICE;
            Unit.EXTRAPRICE = this.EXTRAPRICE;
            Unit.SENDDATE = this.SENDDATE;
            Unit.ISCOMPLETE = this.ISCOMPLETE;
            Unit.SENDPORT = this.SENDPORT;
            return Unit;
        }
        #endregion

        public override string GetId()
        {
            return this.PURCHASE_ORDERID;
        }

        public override string GetTypeName()
        {
            return "SparePurchaseOrder";
        }

        public override bool Update(out string err)
        {
            return SparePurchaseOrderService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return SparePurchaseOrderService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {

        }
    }
}
