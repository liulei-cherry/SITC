using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using StorageManage.DataObject;

namespace StorageManage.Services
{
    public partial class MaterialPurchaseOrderDetailService
    {
        /// <summary>
        /// 得到  T_MATERIAL_PURCHASE_ORDER_DETAIL 所有数据信息.
        /// </summary>
        /// <returns>T_MATERIAL_PURCHASE_ORDER_DETAIL DataTable</returns>
        public bool GetInfo(string PURCHASE_ORDERID, out  DataTable dt, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select	");
            sb.AppendLine("mpod.PURCHASE_ORDER_DETAIL_ID");
            sb.AppendLine(",mpod.PURCHASE_ORDERID");
            sb.AppendLine(",mpod.MATERIAL_ID");
            sb.AppendLine(",type.MATERIAL_TYPE_NAME");

            sb.AppendLine(",mpod.MATERIAL_NAME");
            sb.AppendLine(",mpod.MATERIAL_CODE");
            sb.AppendLine(",mpod.MATERIAL_SPEC");
            sb.AppendLine(",material.UNIT_NAME");
            sb.AppendLine(",mpod.PURCHASECOUNT");
            sb.AppendLine(",mpod.CURRENCYID");
            sb.AppendLine(",c.CURRENCYCODE");
            sb.AppendLine(",mpod.PRICE");
            sb.AppendLine(",mpod.RECEIVECOUNT");
            sb.AppendLine(",mpod.RECEIVEREMARK");
            sb.AppendLine(",mpod.REMARK");
            sb.AppendLine(",mpod.PURCHASE_APPLYID");
            sb.AppendLine(",mpod.ORDERNUM");
            sb.AppendLine(" from T_MATERIAL_PURCHASE_ORDER_DETAIL mpod");
            sb.AppendLine(" inner join T_MATERIAL material on mpod.MATERIAL_ID = material.MATERIAL_ID");
            sb.AppendLine(" left join T_CURRENCY c on c.CURRENCYID=mpod.CURRENCYID ");
            sb.AppendLine(" left join T_MATERIAL_TYPE type on type.MATERIAL_TYPE_ID=material.MATERIAL_TYPE_ID ");
            sb.AppendLine(" where 1=1");
            sb.AppendLine("  and mpod.PURCHASE_ORDERID='" + PURCHASE_ORDERID + "'");
            //sb.AppendLine("  order by mpod.PURCHASE_APPLYID,material.MATERIAL_TYPE_ID");
            sb.AppendLine("  order by mpod.ORDERNUM");
            return dbAccess.GetDataTable(sb.ToString(), out dt, out err);
        }
        /// <summary>
        /// 根据条件得到  T_MATERIAL_PURCHASE_ORDER_DETAIL 数据信息,入库用.
        /// </summary>
        /// <returns>T_MATERIAL_PURCHASE_ORDER_DETAIL DataTable</returns>
        public bool GetMainDetailInfo(string PURCHASE_ORDERID, out  DataTable dt, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select	");
            sb.AppendLine("mpo.PURCHASE_ORDER_CODE");
            sb.AppendLine(",mpo.CURRENCYID");
            sb.AppendLine(",c.CURRENCYCODE");
            sb.AppendLine(",mpo.SUPPLIER_ID");
            sb.AppendLine(",m.MANUFACTURER_NAME");
            sb.AppendLine(",mpod.PURCHASE_ORDER_DETAIL_ID");
            sb.AppendLine(",mpod.PURCHASE_ORDERID");
            sb.AppendLine(",mpod.MATERIAL_ID");
            sb.AppendLine(",mpod.MATERIAL_NAME");
            sb.AppendLine(",mpod.MATERIAL_CODE");
            sb.AppendLine(",mpod.MATERIAL_SPEC");
            sb.AppendLine(",mpod.PURCHASECOUNT");
            sb.AppendLine(",mpod.CURRENCYID");
            sb.AppendLine(",c.CURRENCYCODE");
            sb.AppendLine(",mpod.PRICE");
            sb.AppendLine(",mpod.ORDERNUM");//zhangy-2013-6-13 增加
            sb.AppendLine(",mpod.RECEIVECOUNT");
            sb.AppendLine(",mpod.RECEIVEREMARK");
            sb.AppendLine(",mpod.REMARK");
            sb.AppendLine(",mpod.PURCHASE_APPLYID");
            sb.AppendLine(" from T_MATERIAL_PURCHASE_ORDER_DETAIL mpod");
            sb.AppendLine(" left join T_CURRENCY c on c.CURRENCYID=mpod.CURRENCYID ");
            sb.AppendLine(" left join T_MATERIAL_PURCHASE_ORDER mpo on mpo.PURCHASE_ORDERID=mpod.PURCHASE_ORDERID ");
            sb.AppendLine(" inner join T_MANUFACTURER m on m.MANUFACTURER_ID=mpo.SUPPLIER_ID ");
            sb.AppendLine(" where 1=1");
            sb.AppendLine("  and mpod.PURCHASE_ORDERID='" + PURCHASE_ORDERID + "'");
            sb.AppendLine("  order by mpod.MATERIAL_NAME");
            return dbAccess.GetDataTable(sb.ToString(), out dt, out err);
        }
        /// <summary>
        /// 删除绑定数据.
        /// </summary>
        public bool DeleteByPurchaseOrderID(string PURCHASE_ORDERID, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("delete from T_MATERIAL_PURCHASE_ORDER_DETAIL ");
            sb.AppendLine(" where 1=1");
            sb.AppendLine("  and PURCHASE_ORDERID='" + PURCHASE_ORDERID + "'");
            return dbAccess.ExecSql(sb.ToString(), out err);
        }

        /// <summary>
        /// 更新到货数量.
        /// </summary>
        public bool GoodsArrivalOperation(string order_code, string materialID, decimal quantity, out string err)
        {
            err = "";
            if (string.IsNullOrEmpty(order_code))
                return true;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select	");
            sb.AppendLine("mpod.PURCHASE_ORDER_DETAIL_ID");
            sb.AppendLine(",mpod.PURCHASE_ORDERID");
            sb.AppendLine(",mpod.MATERIAL_ID");
            sb.AppendLine(",mpod.MATERIAL_NAME");
            sb.AppendLine(",mpod.MATERIAL_CODE");
            sb.AppendLine(",mpod.MATERIAL_SPEC");
            sb.AppendLine(",mpod.PURCHASECOUNT");
            sb.AppendLine(",mpod.CURRENCYID");
            sb.AppendLine(",mpod.PRICE");
            sb.AppendLine(",mpod.RECEIVECOUNT");
            sb.AppendLine(",mpod.RECEIVEREMARK");
            sb.AppendLine(",mpod.REMARK");
            sb.AppendLine(" from T_MATERIAL_PURCHASE_ORDER_DETAIL mpod");
            sb.AppendLine(" inner join T_MATERIAL_PURCHASE_ORDER mpo on mpo.PURCHASE_ORDERID=mpod.PURCHASE_ORDERID");
            sb.AppendLine(" where 1=1");
            sb.AppendLine("  and mpod.PURCHASECOUNT <> RECEIVECOUNT");
            sb.AppendLine("  and mpod.MATERIAL_ID = '" + materialID + "'");
            sb.AppendLine("  and mpo.PURCHASE_ORDER_CODE = '" + order_code + "'");
            DataTable dt;
            if (!dbAccess.GetDataTable(sb.ToString(), out dt, out err))
                return false;
            if (dt.Rows.Count == 0)//不存在就返回.
            {
                err = "更新到货数量时没有查询到订单信息";
                return false;
            }
            //存在就更新到货数量.
            MaterialPurchaseOrderDetail obj = this.getObject(dt.Rows[0]);
            obj.RECEIVECOUNT = quantity;
            if (!obj.Update(out err))
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
        //public bool GoodsArrivalOperation(string materialID, decimal quantity, out string err)
        //{
        //    //拼接orderID用来做in查询出detailID是否属于多个orderID的其中一个.
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine("select	");
        //    sb.AppendLine("mpod.PURCHASE_ORDER_DETAIL_ID");
        //    sb.AppendLine(",mpod.PURCHASE_ORDERID");
        //    sb.AppendLine(",mpod.MATERIAL_ID");
        //    sb.AppendLine(",mpod.MATERIAL_NAME");
        //    sb.AppendLine(",mpod.MATERIAL_CODE");
        //    sb.AppendLine(",mpod.MATERIAL_SPEC");
        //    sb.AppendLine(",mpod.PURCHASECOUNT");
        //    sb.AppendLine(",mpod.CURRENCYID");
        //    sb.AppendLine(",mpod.PRICE");
        //    sb.AppendLine(",mpod.RECEIVECOUNT");
        //    sb.AppendLine(",mpod.RECEIVEREMARK");
        //    sb.AppendLine(",mpod.REMARK");
        //    sb.AppendLine(" from T_MATERIAL_PURCHASE_ORDER_DETAIL mpod");
        //    sb.AppendLine(" where 1=1");
        //    sb.AppendLine("  and mpod.PURCHASECOUNT <> RECEIVECOUNT");
        //    sb.AppendLine("  and mpod.MATERIAL_ID = '" + materialID + "'");
        //    sb.AppendLine("  order by mpod.MATERIAL_NAME");
        //    DataTable dt;
        //    if (!dbAccess.GetDataTable(sb.ToString(), out dt, out err))
        //        return false;
        //    if (dt.Rows.Count == 0)//不存在就返回.
        //        return true;
        //    //存在就更新到货数量.
        //    MaterialPurchaseOrderDetail mpod = this.getObject(dt.Rows[0]);
        //    if (mpod.RECEIVECOUNT != mpod.PURCHASECOUNT)
        //    {
        //        if (quantity + mpod.RECEIVECOUNT >= mpod.PURCHASECOUNT)
        //            mpod.RECEIVECOUNT = mpod.PURCHASECOUNT;
        //        else
        //            mpod.RECEIVECOUNT = quantity;
        //        if (!mpod.Update(out err))
        //            return false;
        //        //通过判断是否还有没到货的更改状态.
        //        StringBuilder sb2 = new StringBuilder();
        //        sb2.AppendLine("select	");
        //        sb2.AppendLine("PURCHASE_ORDER_DETAIL_ID");
        //        sb2.AppendLine("FROM T_MATERIAL_PURCHASE_ORDER_DETAIL");
        //        sb2.AppendLine("where [PURCHASE_ORDERID]='" + mpod.PURCHASE_ORDERID + "'");
        //        sb2.AppendLine("and [PURCHASECOUNT]<>[RECEIVECOUNT]");
        //        DataTable dt2;
        //        if (!dbAccess.GetDataTable(sb2.ToString(), out dt2, out err))
        //            return false;
        //        MaterialPurchaseOrder mpo = MaterialPurchaseOrderService.Instance.getObject(mpod.PURCHASE_ORDERID, out err);
        //        mpo.SENDDATE = DateTime.Now;
        //        if (dt2.Rows.Count == 0)
        //            mpo.STATE = 8;
        //        else
        //            mpo.STATE = 7;
        //        if (!mpo.Update(out err))
        //            return false;
        //    }
        //    return true;
        //}
    }
}
