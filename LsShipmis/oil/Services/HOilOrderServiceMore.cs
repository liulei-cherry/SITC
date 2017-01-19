/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：HOilOrderService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-8-12
 * 标    题：数据操作类
 * 功能描述：T_HOIL_ORDER数据操作类
 * Codesmith DataAccessLayer.cst 1.01版本生成
 ****************************************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using BaseInfo.Objects;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using Oil.DataObject;
using ShipMisZHJ_WorkFlow.BusinessClasses;

namespace Oil.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_HOIL_ORDERService.cs
    /// </summary>
    public partial class HOilOrderService
    {
        /// <summary>
        /// 获得订购信息数据.
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <param name="startDate">起始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="chkState">审核状态</param>      
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetOrder(string shipId, string startDate, string endDate)
        {

            //变量定义部分.
            DataTable dtb;      //定义一个DataTable对象.
            string err;         //错误信息返回参数.
            string sSql = "";   //查询数据所需的SQL语句.

            //Select语句加工部分.
            sSql += "select a.ORDER_ID,ship.ship_name,a.ORDER_DATE,a.SUPPLY_DATE,b.CNAME,c.MANUFACTURER_NAME,";
            sSql += "case when a.CHECKED = '0' then '未提交' ";
            sSql += "   when a.CHECKED = '1' then '审核中' ";
            sSql += "   when a.CHECKED = '2' then '被打回' ";
            sSql += "   when a.CHECKED = '5' then '审核通过' ";
            sSql += "   when a.CHECKED = '6' then '金额预估' ";
            sSql += "   when a.CHECKED = '7' then '已做凭证' ";
            sSql += "   end  CHECKED,";
            sSql += "   CURRENT_POSTID,";
            sSql += " a.remark ";
            sSql += " from T_HOIL_ORDER a left join  T_BASE_PORT b on a.PORT_ID = b.PORTID ";
            sSql += " inner join T_SHIP ship on ship.ship_id = a.ship_id  ";
            sSql += " left join T_MANUFACTURER c on a.SUPPLIER_ID = c.MANUFACTURER_ID  ";
            sSql += " left join T_CHECKED ck on ck.BUSINESS_OBJECT_ID=a.ORDER_ID";
            if (CommonOperation.ConstParameter.IsLandVersion)
                sSql += " inner join T_USER_SHIP us on us.ship_id=a.SHIP_ID and us.userid = '" + CommonOperation.ConstParameter.UserId + "'";
            sSql += " where 1=1 ";
            if (!string.IsNullOrEmpty(shipId))
                sSql += " and a.SHIP_ID='" + shipId + "'";
            sSql += " and a.ORDER_DATE  between '" + startDate + "' and '" + endDate + "' ";
            sSql += "order by a.ORDER_DATE desc";

            dbAccess.GetDataTable(sSql, out dtb, out err);
            return dtb;
        }

        public bool GetOrder(string shipId, string checkState, string manufactorId, out DataTable dtb, out string err)
        {
            err = "";
            string sSql = "";
            sSql += "select a.ORDER_ID,a.ORDER_DATE,a.SUPPLY_DATE,b.CNAME,c.MANUFACTURER_NAME,a.SHIP_ID,a.SUPPLIER_ID, ";
            sSql += "case when a.CHECKED = '0' then '未提交' ";
            sSql += "   when a.CHECKED = '1' then '审核中' ";
            sSql += "   when a.CHECKED = '2' then '被打回' ";
            sSql += "   when a.CHECKED = '5' then '审核通过' ";
            sSql += "   when a.CHECKED = '6' then '金额预估' ";
            sSql += "   when a.CHECKED = '7' then '已做凭证' ";
            sSql += "   end  CHECKED,";
            sSql += " a.remark ";
            sSql += " from T_HOIL_ORDER a left join  T_BASE_PORT b on a.PORT_ID = b.PORTID ";
            sSql += " left join T_MANUFACTURER c on a.SUPPLIER_ID = c.MANUFACTURER_ID  ";
            if (CommonOperation.ConstParameter.IsLandVersion)
                sSql += "  inner join T_USER_SHIP us on us.ship_id=a.SHIP_ID and us.userid = '" + CommonOperation.ConstParameter.UserId + "'";
            sSql += " where  ";
            if (!string.IsNullOrEmpty(shipId))
            {
                sSql += " a.SHIP_ID='" + shipId + "'  and";
            }
            sSql += " a.CHECKED in ( " + checkState + ") ";
            if (!string.IsNullOrEmpty(manufactorId))
            {
                sSql += "  and a.SUPPLIER_ID  = '" + manufactorId + "'";
            }

            sSql += " order by a.ORDER_DATE desc";

            return dbAccess.GetDataTable(sSql, out dtb, out err);
        }

        /// <summary>
        /// 删除数据表T_MATERIEL_APPLY中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_MATERIEL_APPLY.mATERIEL_APPLY_ID主键</param>
        public bool deleteParentAndSub(string unitid, out string err)
        {
            List<string> sqls = new List<string>();

            sqls.Add("delete T_HOIL_ORDER_DETAIL where ORDER_ID = '" + unitid + "'");
            sqls.Add("delete T_HOIL_ORDER where ORDER_ID = '" + unitid + "'");
            return dbAccess.ExecSql(sqls, out err);
        }

        /// <summary>
        /// 获取用于创建同步（与SAP的同步）的数据.
        /// </summary>
        public bool GetOrderExpenseToSAP(string id, out DataTable dtb, out string err)
        {
            //变量定义部分.
            string sSql = "";                   //查询数据所需的SQL语句.
            //Select语句加工部分.
            //采购接口格式:MATERIAL,QUANTITY,CURRENCY,AMOUNT,SHIP_ID,SUPPLIER,INPUT_ORDER,INPUT_OREER_ITEM,UUID,SUBJECT_MAPPING(油料的可以不用)

            sSql += "select ";
            sSql += "b.OIL_ID as MATERIAL,";
            sSql += "b.NUM as QUANTITY,";
            sSql += "c.CURRENCYCODE as CURRENCY,";
            sSql += "b.AMOUNT as AMOUNT,";
            sSql += "a.ship_id as ship_id,";
            sSql += "s.MANUFACTURER_ID as SUPPLIER,";
            sSql += "a.CODE as INPUT_ORDER,";
            sSql += "b.ORDER_DETAIL_ID as INPUT_OREER_ITEM,";
            sSql += "b.ORDER_DETAIL_ID as UUID ";
            sSql += " from T_HOIL_ORDER a, T_HOIL_ORDER_DETAIL b,T_Currency c,T_MANUFACTURER s  ";
            sSql += " where a.ORDER_ID = b.ORDER_ID and b.CURRENCY_ID = c.CURRENCYID and a.SUPPLIER_ID = s.MANUFACTURER_ID and a.ORDER_ID = '" + id + "'";
            return dbAccess.GetDataTable(sSql, out dtb, out err);
        }

        /// <summary>
        /// 得到部分到货或全部到货(结束)的供应商列表.
        /// </summary>
        public bool GetEndManufacturer(string state, out DataTable dt, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select	");
            sb.AppendLine("OilO.SUPPLIER_ID as ID");
            sb.AppendLine(",m.MANUFACTURER_NAME as NAME");
            sb.AppendLine(" from T_HOIL_ORDER OilO");
            sb.AppendLine(" inner join T_MANUFACTURER m on m.MANUFACTURER_ID=OilO.SUPPLIER_ID ");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine(" and OilO.CHECKED in (" + state + ")");
            sb.AppendLine("  and (m.MANUFACTURER_NULLIFY IS NULL OR m.MANUFACTURER_NULLIFY <> '1')");
            sb.AppendLine(" group by OilO.SUPPLIER_ID,m.MANUFACTURER_NAME");
            return (dbAccess.GetDataTable(sb.ToString(), out dt, out err));
        }

        /// <summary>
        /// 得到滑油订单明细.
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="dtb"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool GetOrderDetail(string orderID, out DataTable dtb, out string err)
        {
            err = "";

            sql = "SELECT ORDER_DETAIL_ID,ORDER_ID,b.OIL_ID ,b.TRADEMARK,b.OIL_NAME,NUM,a.CURRENCY_ID,c.CURRENCYNAME,a.AMOUNT";
            sql += " FROM T_HOIL_ORDER_DETAIL a";
            sql += " inner join T_HOil b on a.Oil_Id = b.Oil_Id ";
            sql += " left join T_CURRENCY c on a.CURRENCY_ID = c.CURRENCYID ";
            sql += " WHERE ORDER_ID= '" + orderID + "'";
            sql += " order by b.OIL_NAME";

            return dbAccess.GetDataTable(sql, out dtb, out err);
        }

        #region CheckObj 相关业务 2015-02-26 徐正本

        /// <summary>
        /// 根据凭证号,获取费用评审审批工作流的流程对象
        /// </summary>
        /// <param name="voucherNum">凭证号</param>
        /// <returns>审批业务对象(Type : CheckObj)</returns>
        public CheckObj GetOilOrderCheckObjByOilOrderId(string oilOrderId)
        {
            string err;
            DataTable dt;
            sql = string.Format(@"select t1.Order_ID as businessid ,
t3.SHIP_NAME + CONVERT(varchar(100) , t1.Order_DATE, 111) + '滑油采购' as businessName,
t2.CNAME + '港加油' + isnull( char(13)+ CHAR(10) + t1.REMARK,'' ) as businessMainInfo,t4.NUM,t5.TRADEMARK + t5.OIL_NAME as oilName,t6.ForWhichType
from T_HOIL_Order t1 inner join T_BASE_PORT t2 on t1.PORT_ID = t2.PORTID  
inner join T_SHIP t3 on t1.SHIP_ID = t3.SHIP_ID
inner join dbo.T_HOIL_Order_DETAIL t4 on t1.Order_ID = t4.Order_ID
inner join T_HOIL t5 on t4.OIL_ID = t5.OIL_ID
left join T_HOIL_SHIP t6 on t6.SHIP_ID = t3.SHIP_ID and t6.OIL_ID = t5.OIL_ID
where t1.Order_ID = '{0}'
order by t6.ORDERNUM", dbOperation.ReplaceSqlKeyStr(oilOrderId)); 
            dbAccess.GetDataTable(sql.ToString(), out dt, out err);
            if (dt.Rows.Count >= 1)
            {
                string businessDetail = dt.Rows[0]["businessMainInfo"].ToString();
                foreach (DataRow dr in dt.Rows)
                {
                    businessDetail += "\r\n" + dr["ForWhichType"].ToString() + dr["oilName"].ToString() + " " + dr["Num"].ToString() + "L";
                }
                return new CheckObj(dt.Rows[0]["businessid"].ToString(), dt.Rows[0]["businessName"].ToString(), businessDetail);
            }
#if DEBUG
            throw new Exception("未从数据库获取到指定滑油采购单的相关信息,采购单id为:" + oilOrderId);
#else
            return new CheckObj(oilOrderId, oilOrderId, "未获取到信息");
#endif
        }
        #endregion 
    }
}
