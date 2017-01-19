/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：InternalOrderMappingService.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/6/17
 * 标    题：数据操作类
 * 功能描述：T_INTERNAL_ORDER_MAPPING数据操作类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using SAPFunction.DataObject;

namespace SAPFunction.Services
{
    public partial class InternalOrderMappingService
    {
        /// <summary>
        /// 得到  T_INTERNAL_ORDER_MAPPING 所有数据信息.
        /// </summary>
        /// <returns>T_INTERNAL_ORDER_MAPPING DataTable</returns>
        public DataTable GetAllInfo(out string err)
        {
            sql = "SELECT	"
                + "IOM.INTERNAL_ORDER_MAPPING_ID"
                + ",IOM.SHIP_CODE"
                + ",S.SHIP_NAME"
                + ",IOM.ITEM_CODE"
                + ",CA.NODE_NAME"
                + ",IOM.INTERNAL_ORDER_FINANCE"
                + ",IOM.STATUS"
                + ",case IOM.status "
                + "when '1' then '不存在'"
                + "when '2' then '错误'"
                + "when '3' then '未校验' "
                + "when '4' then '有效' "
                + "when '5' then 'SAP方法调用失败' "
                + "end as STATUS_NAME "
                + "  FROM T_INTERNAL_ORDER_MAPPING IOM"
                + " INNER JOIN T_SHIP S "
                + " ON IOM.SHIP_CODE=S.SHIP_ID "
                + " INNER JOIN T_COST_ACCOUNT CA "
                + " ON IOM.ITEM_CODE=CA.NODE_ID "
                + " ORDER BY IOM.STATUS";
            DataTable dt;
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                return dt;
            }
            else
            {
                throw new Exception(err);
            }
        }
        /// <summary>
        /// 根据条件,获得映射信息.
        /// </summary>
        /// <param name="shipCode"></param>
        /// <param name="itemCode"></param>
        /// <param name="internalOrderFinance"></param>
        /// <param name="status"></param>
        /// <param name="dt"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool GetMapping(string shipCode, string itemCode,string internalOrderFinance, string status, out DataTable dt, out string err)
        {
            sql = " SELECT	"
                + "IOM.INTERNAL_ORDER_MAPPING_ID"
                + ",IOM.SHIP_CODE"
                + ",S.SHIP_NAME"
                + ",IOM.ITEM_CODE"
                + ",CA.NODE_NAME"
                + ",IOM.INTERNAL_ORDER_FINANCE"
                + ",IOM.STATUS"
                + ",case IOM.status "
                + "when '1' then '不存在'"
                + "when '2' then '错误'"
                + "when '3' then '未校验' "
                + "when '4' then '有效' "
                + "when '5' then 'SAP方法调用失败' "
                + "end as STATUS_NAME "
                + "  FROM T_INTERNAL_ORDER_MAPPING IOM"
                + " INNER JOIN T_SHIP S "
                + " ON IOM.SHIP_CODE=S.SHIP_ID "
                + " INNER JOIN T_COST_ACCOUNT CA "
                + " ON IOM.ITEM_CODE=CA.NODE_ID "
                + " WHERE 1=1 ";
            if (!string.IsNullOrEmpty(shipCode))
                sql += " AND IOM.SHIP_CODE='" + shipCode + "'";
            if (!string.IsNullOrEmpty(itemCode))
                sql += " AND IOM.ITEM_CODE='" + itemCode + "'";
            if(!string.IsNullOrEmpty(internalOrderFinance))
                sql += " AND IOM.INTERNAL_ORDER_FINANCE='" + internalOrderFinance + "'";
            if (!string.IsNullOrEmpty(status))
                sql += " AND IOM.STATUS in (" + status + ")";
            sql += " ORDER BY IOM.STATUS";
            return dbAccess.GetDataTable(sql, out dt, out err);
        }
    }
}
