using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using StorageManage.DataObject;
using ShipMisZHJ_WorkFlow.BusinessClasses;

namespace StorageManage.Services
{
    public partial class MaterialPurchaseOrderService
    {
        /// <summary>
        /// 得到  T_MATERIAL_PURCHASE_ORDER 所有数据信息.
        /// </summary>
        /// <returns>T_MATERIAL_PURCHASE_ORDER DataTable</returns>
        public bool GetInfo(string PURCHASE_ORDERID, string SHIP_ID, string STATE, out DataTable dt, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select	");
            sb.AppendLine("spo.PURCHASE_ORDERID");
            sb.AppendLine(",spo.PURCHASE_ORDER_CODE");
            sb.AppendLine(",spo.SHIP_ID");
            sb.AppendLine(",s.SHIP_NAME");
            sb.AppendLine(",spo.PURCHASE_ORDER_PERSON");
            sb.AppendLine(",convert(varchar(10),spo.PURCHASE_ORDER_DATE,111) as PURCHASE_ORDER_DATE");
            sb.AppendLine(",spo.ISCOMPLETE");
            sb.AppendLine(" ,case spo.ISCOMPLETE ");
            sb.AppendLine("  when '0' then '未填写完毕'");
            sb.AppendLine("  when '1' then '填写完毕'");
            sb.AppendLine("  end as ISCOMPLETE_NAME");
            sb.AppendLine(",spo.CURRENCYID");
            sb.AppendLine(",c.CURRENCYCODE");
            sb.AppendLine(",spo.SUPPLIER_ID");
            sb.AppendLine(",m.MANUFACTURER_NAME");
            sb.AppendLine(",spo.TOTALPRICE");
            sb.AppendLine(",spo.EXTRAPRICE");
            sb.AppendLine(",convert(varchar(10),spo.SENDDATE,111) as SENDDATE");
            sb.AppendLine(",spo.SENDPORT");
            sb.AppendLine(",spo.LANDCHECKER");
            sb.AppendLine(",convert(varchar(10),spo.CHECKDATE,111) as CHECKDATE");
            sb.AppendLine(",spo.STATE");
            sb.AppendLine(" ,case spo.STATE ");
            sb.AppendLine("  when '0' then '未填写完毕'");
            sb.AppendLine("  when '1' then '等待机务主管审批'");
            sb.AppendLine("  when '2' then '等待机务经理审批'");
            sb.AppendLine("  when '3' then '等待船管总经理审批'");
            sb.AppendLine("  when '4' then '订单打回'");
            sb.AppendLine("  when '5' then '订购'");
            sb.AppendLine("  when '6' then '此订单作废'");
            sb.AppendLine("  when '7' then '部分到货'");
            sb.AppendLine("  when '8' then '结束'");
            sb.AppendLine("  when '9' then '已生成凭证'");
            sb.AppendLine("  end as STATE_NAME");
            sb.AppendLine(",spo.REMARK");
            sb.AppendLine(" from T_MATERIAL_PURCHASE_ORDER spo");
            sb.AppendLine(" inner join T_SHIP s on s.SHIP_ID=spo.SHIP_ID ");
            if (CommonOperation.ConstParameter.IsLandVersion)
                sb.AppendLine("  inner join T_USER_SHIP us on us.ship_id=spo.SHIP_ID and us.userid = '" + CommonOperation.ConstParameter.UserId + "'");
            sb.AppendLine(" inner join T_CURRENCY c on c.CURRENCYID=spo.CURRENCYID ");
            sb.AppendLine(" left join T_MANUFACTURER m on m.MANUFACTURER_ID=spo.SUPPLIER_ID ");
            sb.AppendLine(" where 1=1 ");
            if (!string.IsNullOrEmpty(PURCHASE_ORDERID))
                sb.AppendLine(" and spo.PURCHASE_ORDERID='" + PURCHASE_ORDERID + "'");
            if (!string.IsNullOrEmpty(SHIP_ID))
                sb.AppendLine(" and spo.SHIP_ID='" + SHIP_ID + "'");
            if (!string.IsNullOrEmpty(STATE))
                sb.AppendLine(" and spo.STATE in (" + STATE + ")");
            sb.AppendLine(" order by spo.PURCHASE_ORDER_DATE desc");
            return (dbAccess.GetDataTable(sb.ToString(), out dt, out err));
        }

        #region 2014-12-03-wanhw-根据下拉框选择的状态，返回对应的备件申请状态字符串用逗号隔开
        /// <summary>
        /// 根据下拉框选择的状态，返回对应的备件申请状态字符串用逗号隔开.
        /// </summary>
        /// <param name="viewerState">下拉框选择的状态.</param>
        /// <returns>对应的备件申请状态字符串用逗号隔开.</returns>
        internal string GetBusinessStateByViewerState(string viewerState)
        {
            switch (viewerState)
            {
                case "2":
                    return "1,2,3";

                case "3":
                    return "5";

                case "4":
                    return "8";

                case "5":
                    return "9";
#if DEBUG
                default:
                    throw new Exception("getBusinessStateByViewerState 调用异常，传入参数无效！");
            }
#else
            }
            return "";
#endif
        }

        #endregion
        
        /// <summary>
        /// 得到  T_MATERIAL_PURCHASE_ORDER 所有数据信息.
        /// </summary>
        /// <returns>T_MATERIAL_PURCHASE_ORDER DataTable</returns>
        public bool GetInfo(MaterialPurchaseOrderQueryParameter qp, out DataTable dt, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select	");
            sb.AppendLine("spo.PURCHASE_ORDERID");
            sb.AppendLine(",spo.PURCHASE_ORDER_CODE");
            sb.AppendLine(",spo.SHIP_ID");
            sb.AppendLine(",s.SHIP_NAME");
            sb.AppendLine(",spo.PURCHASE_ORDER_PERSON");
            sb.AppendLine(",convert(varchar(10),spo.PURCHASE_ORDER_DATE,111) as PURCHASE_ORDER_DATE");
            sb.AppendLine(",spo.ISCOMPLETE");
            sb.AppendLine(" ,case spo.ISCOMPLETE ");
            sb.AppendLine("  when '0' then '未填写完毕'");
            sb.AppendLine("  when '1' then '填写完毕'");
            sb.AppendLine("  end as ISCOMPLETE_NAME");
            sb.AppendLine(",spo.CURRENCYID");
            sb.AppendLine(",c.CURRENCYCODE");
            sb.AppendLine(",spo.SUPPLIER_ID");
            sb.AppendLine(",m.MANUFACTURER_NAME");
            sb.AppendLine(",spo.TOTALPRICE");
            sb.AppendLine(",spo.EXTRAPRICE");
            sb.AppendLine(",convert(varchar(10),spo.SENDDATE,111) as SENDDATE");
            sb.AppendLine(",spo.SENDPORT");
            sb.AppendLine(",spo.LANDCHECKER");
            sb.AppendLine(",convert(varchar(10),spo.CHECKDATE,111) as CHECKDATE");
            sb.AppendLine(",spo.STATE");
            sb.AppendLine(" ,case spo.STATE ");
            sb.AppendLine("  when '0' then '未填写完毕'");
            sb.AppendLine("  when '1' then '等待机务主管审批'");
            sb.AppendLine("  when '2' then '等待机务经理审批'");
            sb.AppendLine("  when '3' then '等待船管总经理审批'");
            sb.AppendLine("  when '4' then '订单打回'");
            sb.AppendLine("  when '5' then '订购'");
            sb.AppendLine("  when '6' then '此订单作废'");
            sb.AppendLine("  when '7' then '部分到货'");
            sb.AppendLine("  when '8' then '结束'");
            sb.AppendLine("  when '9' then '已生成凭证'");
            sb.AppendLine("  end as STATE_NAME");
            sb.AppendLine(",spo.REMARK");
            sb.AppendLine(" from T_MATERIAL_PURCHASE_ORDER spo");
            sb.AppendLine(" inner join T_SHIP s on s.SHIP_ID=spo.SHIP_ID ");
            sb.AppendLine(" inner join T_CURRENCY c on c.CURRENCYID=spo.CURRENCYID ");
            sb.AppendLine(" inner join T_MANUFACTURER m on m.MANUFACTURER_ID=spo.SUPPLIER_ID ");
            sb.AppendLine(" where 1=1 ");
            if (!string.IsNullOrEmpty(qp.PURCHASE_ORDERID))
                sb.AppendLine(" and spo.PURCHASE_ORDERID='" + qp.PURCHASE_ORDERID + "'");
            if (!string.IsNullOrEmpty(qp.PURCHASE_ORDER_CODE))
                sb.AppendLine(" and spo.PURCHASE_ORDER_CODE='" + qp.PURCHASE_ORDER_CODE + "'");
            if (!string.IsNullOrEmpty(qp.SHIP_ID))
                sb.AppendLine(" and spo.SHIP_ID='" + qp.SHIP_ID + "'");
            if (!string.IsNullOrEmpty(qp.STATE))
                sb.AppendLine(" and spo.STATE in (" + qp.STATE + ")");
            if (qp.IsRemoveReference)
                sb.AppendLine(" and spo.PURCHASE_ORDER_CODE not in (select ORDER_CODE from T_MATERIAL_DEPOT_OPERATION_DETAIL where order_code is not null group by ORDER_CODE)");
            sb.AppendLine(" order by spo.PURCHASE_ORDER_DATE desc");
            return (dbAccess.GetDataTable(sb.ToString(), out dt, out err));
        }

        /// <summary>
        /// 处理单号（组成规则：B船舶编号+两位年份+两位月份+序列号(三位))
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <returns>返回加工好的物资出入库单编号</returns>
        public string GetPurchaseOrderCode(string shipId)
        {
            string err = ""; //错误信息返回参数.
            string sSql = "";           //SQL查询语句.
            string sShipCode = "";      //船舶编号.
            string sMaxNumb = "";       //出入库单最大序列号（字符型）.
            int maxNumb = 0;            //出入库单最大序列号（数值型）.
            string applyCode = "";      //出入库单.

            //1.取船舶编号.
            sSql = "select ship_code from t_ship where ship_Id = '" + shipId + "'";
            dbAccess.GetString(sSql, out sShipCode, out err);
            if (sShipCode.Length == 0) sShipCode = "NoShip";

            //2.取两位年份两位月份.
            string theYear = "";
            theYear = DateTime.Now.ToString("yyMM");

            //3.取最大序列号（取t_material_apply与t_material_apply中的最大序列号）.

            sSql = "select max(PURCHASE_ORDER_CODE) from (";
            sSql += "select cast(right(PURCHASE_ORDER_CODE,3) as int) as PURCHASE_ORDER_CODE from T_MATERIAL_PURCHASE_ORDER where ship_id = '" + shipId + "') a";
            dbAccess.GetString(sSql, out sMaxNumb, out err);
            if (sMaxNumb == "") sMaxNumb = "0";
            maxNumb = int.Parse(sMaxNumb) + 1;

            if (maxNumb < 1000)
            {
                applyCode = "B" + sShipCode + "-" + theYear + string.Format("{0:000}", maxNumb);
            }
            else
            {
                applyCode = "B" + sShipCode + "-" + theYear + maxNumb.ToString();
            }
            return applyCode;
        }
        /// <summary>
        /// 得到部分到货或全部到货(结束)的供应商列表.
        /// </summary>
        public bool GetEndManufacturer(string state, out DataTable dt, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select	");
            sb.AppendLine("spo.SUPPLIER_ID as ID");
            sb.AppendLine(",m.MANUFACTURER_NAME as NAME");
            sb.AppendLine(" from T_MATERIAL_PURCHASE_ORDER spo");
            sb.AppendLine(" inner join T_MANUFACTURER m on m.MANUFACTURER_ID=spo.SUPPLIER_ID ");
            if (CommonOperation.ConstParameter.IsLandVersion)
                sb.AppendLine("  inner join T_USER_SHIP us on us.ship_id=spo.SHIP_ID and us.userid = '" + CommonOperation.ConstParameter.UserId + "'");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine(" and spo.STATE in (" + state + ")");
            sb.AppendLine(" and (m.MANUFACTURER_NULLIFY IS NULL OR m.MANUFACTURER_NULLIFY <> '1')");
            sb.AppendLine(" group by spo.SUPPLIER_ID,m.MANUFACTURER_NAME");
            return (dbAccess.GetDataTable(sb.ToString(), out dt, out err));
        }
        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">MaterialPurchaseOrder对象</param>
        /// <param name="operationType">操作类型,1:插入,2:更新</param>
        public string saveUnit(MaterialPurchaseOrder unit, int operationType)
        {
            if (operationType == 2)
            {
                sql = "UPDATE [T_MATERIAL_PURCHASE_ORDER] SET "
                    + " [PURCHASE_ORDERID] = " + (string.IsNullOrEmpty(unit.PURCHASE_ORDERID) ? "null" : "'" + unit.PURCHASE_ORDERID.Replace("'", "''") + "'")
                    + " , [CURRENCYID] = " + (string.IsNullOrEmpty(unit.CURRENCYID) ? "null" : "'" + unit.CURRENCYID.Replace("'", "''") + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , [SUPPLIER_ID] = " + (string.IsNullOrEmpty(unit.SUPPLIER_ID) ? "null" : "'" + unit.SUPPLIER_ID.Replace("'", "''") + "'")
                    + " , [PURCHASE_ORDER_CODE] = " + (unit.PURCHASE_ORDER_CODE == null ? "''" : "'" + unit.PURCHASE_ORDER_CODE.Replace("'", "''") + "'")
                    + " , [PURCHASE_ORDER_PERSON] = " + (unit.PURCHASE_ORDER_PERSON == null ? "''" : "'" + unit.PURCHASE_ORDER_PERSON.Replace("'", "''") + "'")
                    + " , [PURCHASE_ORDER_DATE] = " + dbOperation.DbToDate(unit.PURCHASE_ORDER_DATE)
                    + " , [LANDCHECKER] = " + (unit.LANDCHECKER == null ? "''" : "'" + unit.LANDCHECKER.Replace("'", "''") + "'")
                    + " , [CHECKDATE] = " + dbOperation.DbToDate(unit.CHECKDATE)
                    + " , [REMARK] = N" + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
                    + " , [STATE] = " + unit.STATE.ToString()
                    + " , [TOTALPRICE] = " + unit.TOTALPRICE.ToString()
                    + " , [EXTRAPRICE] = " + unit.EXTRAPRICE.ToString()
                    + " , [SENDDATE] = " + dbOperation.DbToDate(unit.SENDDATE)
                    + " , [ISCOMPLETE] = " + unit.ISCOMPLETE.ToString()
                    + " , [SENDPORT] = " + (unit.SENDPORT == null ? "''" : "'" + unit.SENDPORT.Replace("'", "''") + "'")
                    + " where upper(PURCHASE_ORDERID) = '" + unit.PURCHASE_ORDERID.ToUpper() + "'";
            }
            else if (operationType == 1)
            {
                sql = "INSERT INTO [T_MATERIAL_PURCHASE_ORDER] ("
                    + "[PURCHASE_ORDERID],"
                    + "[CURRENCYID],"
                    + "[SHIP_ID],"
                    + "[SUPPLIER_ID],"
                    + "[PURCHASE_ORDER_CODE],"
                    + "[PURCHASE_ORDER_PERSON],"
                    + "[PURCHASE_ORDER_DATE],"
                    + "[LANDCHECKER],"
                    + "[CHECKDATE],"
                    + "[REMARK],"
                    + "[STATE],"
                    + "[TOTALPRICE],"
                    + "[EXTRAPRICE],"
                    + "[SENDDATE],"
                    + "[ISCOMPLETE],"
                    + "[SENDPORT]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.PURCHASE_ORDERID) ? "null" : "'" + unit.PURCHASE_ORDERID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.CURRENCYID) ? "null" : "'" + unit.CURRENCYID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SUPPLIER_ID) ? "null" : "'" + unit.SUPPLIER_ID.Replace("'", "''") + "'")
                    + " , " + (unit.PURCHASE_ORDER_CODE == null ? "''" : "'" + unit.PURCHASE_ORDER_CODE.Replace("'", "''") + "'")
                    + " , " + (unit.PURCHASE_ORDER_PERSON == null ? "''" : "'" + unit.PURCHASE_ORDER_PERSON.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.PURCHASE_ORDER_DATE)
                    + " , " + (unit.LANDCHECKER == null ? "''" : "'" + unit.LANDCHECKER.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.CHECKDATE)
                    + " , N" + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
                    + " ," + unit.STATE.ToString()
                    + " ," + unit.TOTALPRICE.ToString()
                    + " ," + unit.EXTRAPRICE.ToString()
                    + " ," + dbOperation.DbToDate(unit.SENDDATE)
                    + " ," + unit.ISCOMPLETE.ToString()
                    + " , " + (unit.SENDPORT == null ? "''" : "'" + unit.SENDPORT.Replace("'", "''") + "'")
                    + ")";
            }

            return sql;
        }

        #region CheckObj 相关业务 2015-02-26 徐正本

        /// <summary>
        /// 根据物料采购订单id,获取物料采购审批工作流的流程对象
        /// </summary>
        /// <param name="purchaseOrderId">订单id</param>
        /// <returns>审批业务对象(Type : CheckObj)</returns>
        public CheckObj GetMaterialPurchaseOrderCheckObjByOrderId(string purchaseOrderId)
        {
            string err;
            DataTable dt;
            sql = string.Format(@"select top 5 t1.PURCHASE_ORDERID as businessid ,
 t3.SHIP_NAME  +   '(' + t1.PURCHASE_ORDER_CODE+ ') 物料采购' as businessName,
'供应商:'+ t4.MANUFACTURER_NAME + '  定单日期:'+  CONVERT(varchar(100), t1.PURCHASE_ORDER_DATE, 111) + CHAR(13)+CHAR(10)+
isnull('备注:'+ t1.REMARK + CHAR(13)+CHAR(10),'') as businessMainInfo,
t2.MATERIAL_NAME + isnull('('+t2.MATERIAL_SPEC+') ',' ') + cast(CAST( t2.PURCHASECOUNT as numeric(18,0)) as varchar(100)) + isnull( +t5.UNIT_NAME ,'') + isnull( t2.REMARK ,'') as businessItemInfo
from T_MATERIAL_PURCHASE_ORDER t1 inner join T_MATERIAL_PURCHASE_ORDER_DETAIL t2 on t1.PURCHASE_ORDERID = t2.PURCHASE_ORDERID
inner join T_SHIP t3 on t1.SHIP_ID = t3.SHIP_ID
inner join T_MANUFACTURER t4 on t1.SUPPLIER_ID = t4.MANUFACTURER_ID
left join T_MATERIAL t5 on t2.MATERIAL_ID = t5.MATERIAL_ID
where t1.PURCHASE_ORDERID = '{0}'
order by t2.ORDERNUM", dbOperation.ReplaceSqlKeyStr(purchaseOrderId));
            dbAccess.GetDataTable(sql.ToString(), out dt, out err);
            if (dt.Rows.Count >= 1)
            {
                string businessDetail = dt.Rows[0]["businessMainInfo"].ToString();
                foreach (DataRow dr in dt.Rows)
                {
                    businessDetail += "\r\n" + dr["businessItemInfo"].ToString();
                }
                if (dt.Rows.Count == 5) businessDetail += " 等......";
                return new CheckObj(dt.Rows[0]["businessid"].ToString(), dt.Rows[0]["businessName"].ToString(), businessDetail);
            }
#if DEBUG
            throw new Exception("未从数据库获取到指定滑油申请的相关信息,申请单id为:" + purchaseOrderId);
#else
            return new CheckObj(purchaseOrderId, purchaseOrderId, "未获取到信息");
#endif
        }
        #endregion
    }
    public struct MaterialPurchaseOrderQueryParameter
    {
        public string PURCHASE_ORDERID;
        public string SHIP_ID;
        public string STATE;
        public string PURCHASE_ORDER_CODE;
        public bool IsRemoveReference;
    }
}
