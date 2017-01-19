// File:    IValidTime.cs
// Author:  xuzb
// Created: 2008年6月27日 18:12:14
// Purpose: Definition of Interface IValidTime

using System;
using System.Collections.Generic;
using System.Text;
using LSShipMis_Ship.Common.Remind;

namespace LSShipMis_Ship.Common.PeriodValidity
{
    public enum ValidTimeType
    {
        //ComponentValidTime = 2,     //设备有效期.
        //SpareValidTime = 4,         //备件有效期.
        //ActionValidTime = 5,        //事件有效期.
        //SystemAlert = 6,            //系统内部警告消息.
        /// <summary>
        /// 备件入库审核报警.
        /// </summary>
        SpareIn = 8,
        /// <summary>
        /// 备件出库审核报警.
        /// </summary>
        SpareOut = 9,
        /// <summary>
        /// 备件盘点审核报警.
        /// </summary>
        SpareStockck = 10,
        /// <summary>
        /// 备件低于警戒库存的报警.
        /// </summary>
        SpareStockLower = 31,
        /// <summary>
        /// 物资入库审核报警.
        /// </summary>
        MaterialIn = 12,
        /// <summary>
        /// 物资出库审核报警.
        /// </summary>
        MaterialOut = 13,
        /// <summary>
        /// 物资盘点审核报警.
        /// </summary>
        MaterialStockck = 14,
        /// <summary>
        /// 证书报警.
        /// </summary>
        ShipCert = 15,
        /// <summary>
        /// 工单报警.
        /// </summary>
        WorkOrder = 16,
        /// <summary>
        /// 工单确认报警.
        /// </summary>
        WorkOrderConfirm = 17,
        /// <summary>
        /// 备件不足工单使用报警.
        /// </summary>
        WorkOrderSpareNotEnough = 26,

        /// <summary>
        /// 备件申请等待审核的报警.
        /// </summary>
        SparePurchaseApplyCheck = 28,
        /// <summary>
        /// 备件申请未填写完毕报警.
        /// </summary>
        SparePurchaseApplyNotComplete = 29,
        /// <summary>
        /// 备件申请被打回的报警.
        /// </summary>
        SparePurchaseApplyReject = 30,
        /// <summary>
        /// 备件订单等待审核的报警.
        /// </summary>
        SparePurchaseOrderCheck = 31,
        /// <summary>
        /// 备件订单未填写完毕报警.
        /// </summary>
        SparePurchaseOrderNotComplete = 32,
        /// <summary>
        /// 备件订单被打回的报警.
        /// </summary>
        SparePurchaseOrderReject = 33,

        /// <summary>
        /// 物资申请等待审核的报警.
        /// </summary>
        MaterialPurchaseApplyCheck = 34,
        /// <summary>
        /// 物资申请未填写完毕报警.
        /// </summary>
        MaterialPurchaseApplyNotComplete = 35,
        /// <summary>
        /// 物资申请被打回的报警.
        /// </summary>
        MaterialPurchaseApplyReject = 36,
        /// <summary>
        /// 物资订单等待审核的报警.
        /// </summary>
        MaterialPurchaseOrderCheck = 37,
        /// <summary>
        /// 物资订单未填写完毕报警.
        /// </summary>
        MaterialPurchaseOrderNotComplete = 38,
        /// <summary>
        /// 物资订单被打回的报警.
        /// </summary>
        MaterialPurchaseOrderReject = 39,
        /// <summary>
        /// 修理申请未填写完毕.
        /// </summary>
        RepairApplyAlertNotComplete = 40,
        /// <summary>
        /// 修理申请等待审核.
        /// </summary>
        RepairApplyAlertCheck = 41,
        /// <summary>
        /// 油料申请等待审核报警.
        /// </summary>
        HOilApplyAlertCheck = 42,
        /// <summary>
        /// 消防救生设备有效期审核报警
        /// </summary>
        XFJSAlertCheck = 43,
        /// <summary>
        /// 通导设备有效期审核报警
        /// </summary>
        TDSBAlertCheck = 44

    }
}