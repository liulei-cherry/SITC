/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：HOilOrder.cs
 * 创 建 人：王鹏程
 * 创建时间：2012/4/26
 * 标    题：实体类
 * 功能描述：T_HOIL_ORDER数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using Oil.Services;

namespace Oil.DataObject
{
    /// <summary>
    ///T_HOIL_ORDER数据实体
    /// </summary>
    ///[Serializable]
    public partial class HOilOrder : CommonClass
    {
        #region 构造函数
        ///<summary> 
        ///滑油订单管理
        ///</summary>
        public HOilOrder()
        {
        }
        ///<summary>
        ///滑油订单管理
        ///</summary>
        public HOilOrder
        (
            string oRDER_ID,
            string aPPLY_ID,
            string sHIP_ID,
            string cODE,
            DateTime oRDER_DATE,
            DateTime sUPPLY_DATE,
            string pORT_ID,
            string sUPPLIER_ID,
            string aPPROVER,
            decimal cHECKED,
            string rEMARK
        )
        {
            this.ORDER_ID = oRDER_ID;
            this.APPLY_ID = aPPLY_ID;
            this.SHIP_ID = sHIP_ID;
            this.CODE = cODE;
            this.ORDER_DATE = oRDER_DATE;
            this.SUPPLY_DATE = sUPPLY_DATE;
            this.PORT_ID = pORT_ID;
            this.SUPPLIER_ID = sUPPLIER_ID;
            this.APPROVER = aPPROVER;
            this.CHECKED = cHECKED;
            this.REMARK = rEMARK;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///ID
        ///</summary>
        public string ORDER_ID { get; set; }

        ///<summary>
        ///申请单ID
        ///</summary>
        public string APPLY_ID { get; set; }

        ///<summary>
        ///船舶ID
        ///</summary>
        public string SHIP_ID { get; set; }

        ///<summary>
        ///编号
        ///
        ///
        ///</summary>
        public string CODE { get; set; }

        ///<summary>
        ///订购日期
        ///</summary>
        public DateTime ORDER_DATE { get; set; }

        ///<summary>
        ///供船日期
        ///</summary>
        public DateTime SUPPLY_DATE { get; set; }

        ///<summary>
        ///港口ID
        ///</summary>
        public string PORT_ID { get; set; }

        ///<summary>
        ///供货商ID
        ///</summary>
        public string SUPPLIER_ID { get; set; }

        ///<summary>
        ///第一个批准人
        ///
        ///
        ///</summary>
        public string APPROVER { get; set; }

        ///<summary>
        ///审核状态（0：未提交；1：审核中；2：被打回；5：财务经理已通过；6：金额预估；7：已做凭证）
        ///</summary>
        public decimal CHECKED { get; set; }

        ///<summary>
        ///备注
        ///</summary>
        public string REMARK { get; set; }

        ///<summary>
        ///克隆一个对象
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            HOilOrder Unit = new HOilOrder();
            Unit.ORDER_ID = this.ORDER_ID;
            Unit.APPLY_ID = this.APPLY_ID;
            Unit.SHIP_ID = this.SHIP_ID;
            Unit.CODE = this.CODE;
            Unit.ORDER_DATE = this.ORDER_DATE;
            Unit.SUPPLY_DATE = this.SUPPLY_DATE;
            Unit.PORT_ID = this.PORT_ID;
            Unit.SUPPLIER_ID = this.SUPPLIER_ID;
            Unit.APPROVER = this.APPROVER;
            Unit.CHECKED = this.CHECKED;
            Unit.REMARK = this.REMARK;
            return Unit;
        }
        #endregion

        public override string GetId()
        {
            return this.ORDER_ID;
        }

        public override string GetTypeName()
        {
            return "HOilOrder";
        }

        public override bool Update(out string err)
        {
            return HOilOrderService.Instance.SaveUnit(this, out err);
        }
        public void Update()
        {
            HOilOrderService.Instance.SaveUnit(this);
        }
        public string UpdateSql()
        {
            return HOilOrderService.Instance.SaveUnitSql(this);
        }

        public override bool Delete(out string err)
        {
            return HOilOrderService.Instance.DeleteUnit(this.GetId(), out err);
        }
        public void Delete()
        {
            HOilOrderService.Instance.DeleteUnit(this.GetId());
        }
        public string DeleteSql()
        {
            return HOilOrderService.Instance.DeleteUnitSql(this.GetId());
        }
        public override void FillThisObject()
        {

        }
    }
}
