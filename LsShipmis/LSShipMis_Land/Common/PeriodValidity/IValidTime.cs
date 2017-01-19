// File:    IValidTime.cs
// Author:  xuzb
// Created: 2008年6月27日 18:12:14
// Purpose: Definition of Interface IValidTime

using System;
using System.Collections.Generic;
using System.Text;
using LSShipMis_Land.Common.Remind;

namespace LSShipMis_Land.Common.PeriodValidity
{
    public enum ValidTimeType
    {
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
        /// SAP映射报警.
        /// </summary>
        SAPMapping = 18,
        /// <summary>
        /// SAP报文报警.
        /// </summary>
        SAPMessage = 19,

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
        /// 物料申请等待审核的报警.
        /// </summary>
        MaterialPurchaseApplyCheck = 34,
        /// <summary>
        /// 物料申请未填写完毕报警.
        /// </summary>
        MaterialPurchaseApplyNotComplete = 35,
        /// <summary>
        /// 物料申请被打回的报警.
        /// </summary>
        MaterialPurchaseApplyReject = 36,
        /// <summary>
        /// 物料订单等待审核的报警.
        /// </summary>
        MaterialPurchaseOrderCheck = 37,
        /// <summary>
        /// 物料订单未填写完毕报警.
        /// </summary>
        MaterialPurchaseOrderNotComplete = 38,
        /// <summary>
        /// 物料订单被打回的报警.
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
        /// 存在等待审核的预算项目.
        /// </summary>
        VoucherAlertCheck = 42,
        /// <summary>
        /// 油料申请等待审核报警.
        /// </summary>
        HOilApplyAlertCheck = 43,

        /// <summary>
        /// 修理申请审核的一次性报警.
        /// </summary>
        RepairApplyAlertCheckOnce = 44,
        /// <summary>
        /// 油料申请审核的一次性报警.
        /// </summary>
        HOilApplyAlertCheckOnce = 45,
        /// <summary>
        /// 物料申请审核的一次性报警.
        /// </summary>
        MaterialPurchaseApplyCheckOnce = 46,
        /// <summary>
        /// 物料订单审核的一次性报警.
        /// </summary>
        MaterialPurchaseOrderCheckOnce = 47,
        /// <summary>
        /// 备件申请审核的一次性报警.
        /// </summary>
        SparePurchaseApplyCheckOnce = 48,
        /// <summary>
        /// 备件订单审核的一次性报警.
        /// </summary>
        SparePurchaseOrderCheckOnce = 49,

        /// <summary>
        /// 存在被打回的预算项目.
        /// </summary>
        VoucherAlertCheckReject = 50,

        /// <summary>
        /// 凭证通过的一次性报警.
        /// </summary>
        VoucherAlertPassCheckOnce = 51,
        /// <summary>
        /// 存在未产生单日凭证的费用项目.
        /// </summary>
        CostNotVoucher = 52,
        /// <summary>
        /// 存在未填写的备件入库凭证.
        /// </summary>
        SpareNotVoucher = 53,
        /// <summary>
        /// 存在未填写的物料入库凭证.
        /// </summary>
        MaterialNotVoucher = 54,
        /// <summary>
        /// 存在未填写的油料入库凭证.
        /// </summary>
        OilNotVoucher = 55,
        /// <summary>
        /// 存在未填写凭证的修理完工单.
        /// </summary>
        RepairNotVoucher = 56,
        /// <summary>
        /// 凭证被打回的一次性报警.
        /// </summary>
        VoucherAlertNotPassCheckOnce = 57,
        /// <summary>
        /// 备件手工入库的一次性报警.
        /// </summary>
        SpareInBySpareApply = 58,
        /// <summary>
        /// 物料手工入库的一次性报警.
        /// </summary>
        MaterialInByMaterialApply = 59,
    }
}
