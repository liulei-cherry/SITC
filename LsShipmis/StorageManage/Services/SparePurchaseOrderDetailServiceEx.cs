using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using StorageManage.DataObject;

namespace StorageManage.Services
{
    public partial class SparePurchaseOrderDetailService
    {
        /// <summary>
        /// 得到  T_SPARE_PURCHASE_ORDER_DETAIL 所有数据信息.
        /// </summary>
        /// <returns>T_SPARE_PURCHASE_ORDER_DETAIL DataTable</returns>
        public bool GetInfo(string PURCHASE_ORDERID, out  DataTable dt, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select	");
            sb.AppendLine("spod.PURCHASE_ORDER_DETAIL_ID");
            sb.AppendLine(",spod.PURCHASE_ORDERID");
            sb.AppendLine(",spod.SPARE_ID");
            sb.AppendLine(",spod.SPARE_NAME");
            sb.AppendLine(",'' as selSpare");
            sb.AppendLine(",spod.PARTNUMBER");
            sb.AppendLine(",spare.UNIT_NAME");
            sb.AppendLine(",spod.PURCHASECOUNT");
            sb.AppendLine(",spod.CURRENCYID");
            sb.AppendLine(",c.CURRENCYCODE");
            sb.AppendLine(",spod.RECEIVECOUNT");
            if (CommonOperation.ConstParameter.IsLandVersion)
                sb.AppendLine(",spod.PRICE");
            sb.AppendLine(",spod.RECEIVEREMARK");
            sb.AppendLine(",spod.COMPONENT_UNIT_ID");
            if (CommonOperation.ConstParameter.IsLandVersion)
                sb.AppendLine(",spod.REMARK");
            sb.AppendLine(",spod.PURCHASE_APPLYID");
            sb.AppendLine(" from T_SPARE_PURCHASE_ORDER_DETAIL spod");
            sb.AppendLine(" inner join T_SPARE spare on spod.SPARE_ID = spare.SPARE_ID");
            sb.AppendLine(" left join T_CURRENCY c on c.CURRENCYID=spod.CURRENCYID ");
            sb.AppendLine(" where 1=1");
            sb.AppendLine("  and spod.PURCHASE_ORDERID='" + PURCHASE_ORDERID + "'");
            //sb.AppendLine("  order by spod.PURCHASE_APPLYID,spod.PARTNUMBER");

            return dbAccess.GetDataTable(sb.ToString(), out dt, out err);
        }
        /// <summary>
        /// 根据条件得到  T_SPARE_PURCHASE_ORDER_DETAIL 数据信息,入库用.
        /// </summary>
        /// <returns>T_SPARE_PURCHASE_ORDER_DETAIL DataTable</returns>
        public bool GetMainDetailInfo(string PURCHASE_ORDERID, out  DataTable dt, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select	");
            sb.AppendLine("spo.PURCHASE_ORDER_CODE");
            sb.AppendLine(",spo.COMPONENT_UNIT_ID");
            sb.AppendLine(",cu.COMP_CHINESE_NAME");
            sb.AppendLine(",spo.CURRENCYID");
            sb.AppendLine(",c.CURRENCYCODE");
            sb.AppendLine(",spo.SUPPLIER_ID");
            sb.AppendLine(",m.MANUFACTURER_NAME");
            sb.AppendLine(",spod.PURCHASE_ORDER_DETAIL_ID");
            sb.AppendLine(",spod.PURCHASE_ORDERID");
            sb.AppendLine(",spod.SPARE_ID");
            sb.AppendLine(",spod.SPARE_NAME");
            sb.AppendLine(",'' as selSpare");
            sb.AppendLine(",spod.PARTNUMBER");
            sb.AppendLine(",spod.PURCHASECOUNT");
            sb.AppendLine(",spod.CURRENCYID");
            sb.AppendLine(",c.CURRENCYCODE");
            sb.AppendLine(",spod.RECEIVECOUNT");
            sb.AppendLine(",spod.PRICE");
            sb.AppendLine(",spod.RECEIVEREMARK");
            sb.AppendLine(",spod.COMPONENT_UNIT_ID");
            sb.AppendLine(",spod.REMARK");
            sb.AppendLine(",spod.PURCHASE_APPLYID");
            sb.AppendLine(" from T_SPARE_PURCHASE_ORDER_DETAIL spod");
            sb.AppendLine(" left join T_CURRENCY c on c.CURRENCYID=spod.CURRENCYID ");
            sb.AppendLine(" left join T_SPARE_PURCHASE_ORDER spo on spo.PURCHASE_ORDERID=spod.PURCHASE_ORDERID ");
            sb.AppendLine(" inner join T_MANUFACTURER m on m.MANUFACTURER_ID=spo.SUPPLIER_ID ");
            sb.AppendLine(" left join T_COMPONENT_UNIT cu on cu.COMPONENT_UNIT_ID=spo.COMPONENT_UNIT_ID ");
            sb.AppendLine(" where 1=1");
            sb.AppendLine("  and spod.PURCHASE_ORDERID='" + PURCHASE_ORDERID + "'");
            sb.AppendLine("  order by spod.SPARE_NAME");
            return dbAccess.GetDataTable(sb.ToString(), out dt, out err);
        }
        /// <summary>
        /// 删除绑定数据.
        /// </summary>
        public bool DeleteByPurchaseOrderID(string PURCHASE_ORDERID, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("delete from T_SPARE_PURCHASE_ORDER_DETAIL ");
            sb.AppendLine(" where 1=1");
            sb.AppendLine("  and PURCHASE_ORDERID='" + PURCHASE_ORDERID + "'");
            return dbAccess.ExecSql(sb.ToString(), out err);
        }

        /// <summary>
        /// 更新到货数量.
        /// </summary>
        public bool GoodsArrivalOperation(string order_code, string spareID, decimal quantity, out string err)
        {
            err = "";
            if (string.IsNullOrEmpty(order_code))
                return true;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select	");
            sb.AppendLine("spod.PURCHASE_ORDER_DETAIL_ID");
            sb.AppendLine(",spod.PURCHASE_ORDERID");
            sb.AppendLine(",spod.SPARE_ID");
            sb.AppendLine(",spod.SPARE_NAME");
            sb.AppendLine(",'' as selSpare");
            sb.AppendLine(",spod.PARTNUMBER");
            sb.AppendLine(",spod.PURCHASECOUNT");
            sb.AppendLine(",spod.CURRENCYID");
            sb.AppendLine(",spod.PRICE");
            sb.AppendLine(",spod.RECEIVECOUNT");
            sb.AppendLine(",spod.RECEIVEREMARK");
            sb.AppendLine(",spod.COMPONENT_UNIT_ID");
            sb.AppendLine(",spod.REMARK");
            sb.AppendLine(" from T_SPARE_PURCHASE_ORDER_DETAIL spod");
            sb.AppendLine(" inner join T_SPARE_PURCHASE_ORDER spo on spo.PURCHASE_ORDERID=spod.PURCHASE_ORDERID");
            sb.AppendLine(" where 1=1");
            sb.AppendLine("  and spod.PURCHASECOUNT > RECEIVECOUNT");
            sb.AppendLine("  and spod.SPARE_ID = '" + spareID + "'");
            sb.AppendLine("  and spo.PURCHASE_ORDER_CODE = '" + order_code + "'");
            DataTable dt;
            if (!dbAccess.GetDataTable(sb.ToString(), out dt, out err))
                return false;
            if (dt.Rows.Count == 0)//不存在就返回.
            {
                err = "更新到货数量时没有查询到订单信息";
                return false;
            }
            //存在就更新到货数量.
            SparePurchaseOrderDetail spod = this.getObject(dt.Rows[0]);
            spod.RECEIVECOUNT = quantity;
            if (!spod.Update(out err))
                return false;
            return true;
        }

        ///// <summary>
        ///// 传入一个detailID和他的入库数量,判断这个detailID是否属于没有完全入库的,
        ///// 是:更新detailID的到货数量,
        /////    更新orderID的到货日期.
        /////    判断当前orderID是否全部到货,
        /////    是:更新状态为到货,否:更新状态为部分到货.
        ///// </summary>
        //public bool GoodsArrivalOperation(string spareID, decimal quantity, out string err)
        //{
        //    //拼接orderID用来做in查询出detailID是否属于多个orderID的其中一个.
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine("select	");
        //    sb.AppendLine("spod.PURCHASE_ORDER_DETAIL_ID");
        //    sb.AppendLine(",spod.PURCHASE_ORDERID");
        //    sb.AppendLine(",spod.SPARE_ID");
        //    sb.AppendLine(",spod.SPARE_NAME");
        //    sb.AppendLine(",'' as selSpare");
        //    sb.AppendLine(",spod.PARTNUMBER");
        //    sb.AppendLine(",spod.PURCHASECOUNT");
        //    sb.AppendLine(",spod.CURRENCYID");
        //    sb.AppendLine(",spod.PRICE");
        //    sb.AppendLine(",spod.RECEIVECOUNT");
        //    sb.AppendLine(",spod.RECEIVEREMARK");
        //    sb.AppendLine(",spod.COMPONENT_UNIT_ID");
        //    sb.AppendLine(",spod.REMARK");
        //    sb.AppendLine(" from T_SPARE_PURCHASE_ORDER_DETAIL spod");
        //    sb.AppendLine(" where 1=1");
        //    sb.AppendLine("  and spod.PURCHASECOUNT <> RECEIVECOUNT");
        //    sb.AppendLine("  and spod.SPARE_ID = '" + spareID + "'");
        //    sb.AppendLine("  order by spod.SPARE_NAME");
        //    DataTable dt;
        //    if (!dbAccess.GetDataTable(sb.ToString(), out dt, out err))
        //        return false;
        //    if (dt.Rows.Count == 0)//不存在就返回.
        //        return true;
        //    //存在就更新到货数量.
        //    SparePurchaseOrderDetail spod = this.getObject(dt.Rows[0]);
        //    if (spod.RECEIVECOUNT != spod.PURCHASECOUNT)
        //    {
        //        if (quantity + spod.RECEIVECOUNT >= spod.PURCHASECOUNT)
        //            spod.RECEIVECOUNT = spod.PURCHASECOUNT;
        //        else
        //            spod.RECEIVECOUNT = quantity;
        //        if (!spod.Update(out err))
        //            return false;
        //        //通过判断是否还有没到货的更改状态.
        //        StringBuilder sb2 = new StringBuilder();
        //        sb2.AppendLine("select	");
        //        sb2.AppendLine("PURCHASE_ORDER_DETAIL_ID");
        //        sb2.AppendLine("FROM T_SPARE_PURCHASE_ORDER_DETAIL");
        //        sb2.AppendLine("where [PURCHASE_ORDERID]='" + spod.PURCHASE_ORDERID + "'");
        //        sb2.AppendLine("and [PURCHASECOUNT]<>[RECEIVECOUNT]");
        //        DataTable dt2;
        //        if (!dbAccess.GetDataTable(sb2.ToString(), out dt2, out err))
        //            return false;
        //        SparePurchaseOrder spo = SparePurchaseOrderService.Instance.getObject(spod.PURCHASE_ORDERID, out err);
        //        spo.SENDDATE = DateTime.Now;
        //        if (dt2.Rows.Count == 0)
        //            spo.STATE = 8;
        //        else
        //            spo.STATE = 7;
        //        if (!spo.Update(out err))
        //            return false;
        //    }
        //}
    }
}
