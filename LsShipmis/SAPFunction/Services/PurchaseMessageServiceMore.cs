/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：PurchaseMessageService.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/6/16
 * 标    题：数据操作类
 * 功能描述：T_PURCHASE_MESSAGE数据操作类
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
    public partial class PurchaseMessageService
    {
        /// <summary>
        /// 保存报文头和报文内容的事务.
        /// </summary>
        /// <param name="mh"></param>
        /// <param name="dataList"></param>
        /// <param name="createMode">创建方式 1=创建报文   2=反冲账</param>
        /// <param name="err"></param>
        /// <returns></returns>
        internal bool saveUnitTransaction(MessageHeader mh, List<PurchaseMessage> dataList, out string err)
        {
            List<string> sqlList = new List<string>();

            if (mh.MESSAGE_HEADER_ID != null && mh.MESSAGE_HEADER_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_MESSAGE_HEADER] SET "
                    + " [MESSAGE_HEADER_ID] = " + (string.IsNullOrEmpty(mh.MESSAGE_HEADER_ID) ? "null" : "'" + mh.MESSAGE_HEADER_ID.Replace("'", "''") + "'")
                    + " , [SY_SOURCE] = " + (mh.SY_SOURCE == null ? "''" : "'" + mh.SY_SOURCE.Replace("'", "''") + "'")
                    + " , [INT_ID] = " + (string.IsNullOrEmpty(mh.INT_ID) ? "null" : "'" + mh.INT_ID.Replace("'", "''") + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(mh.SHIP_ID) ? "null" : "'" + mh.SHIP_ID.Replace("'", "''") + "'")
                    + " , [COMPANY_CODE] = " + (mh.COMPANY_CODE == null ? "''" : "'" + mh.COMPANY_CODE.Replace("'", "''") + "'")
                    + " , [PRODUCE] = " + mh.PRODUCE.ToString()
                    + " , [QUANTITY] = " + mh.QUANTITY.ToString()
                    + " , [OCCUR] = " + mh.OCCUR.ToString()
                    + " , [ACCOUNT] = " + mh.ACCOUNT.ToString()
                    + " , [PACKET_ID] = " + (string.IsNullOrEmpty(mh.PACKET_ID) ? "null" : "'" + mh.PACKET_ID.Replace("'", "''") + "'")
                    + " , [BUSINESS_CODE] = " + (mh.BUSINESS_CODE == null ? "''" : "'" + mh.BUSINESS_CODE.Replace("'", "''") + "'")
                    + " , [MESSAGE_TYPE] = " + (mh.MESSAGE_TYPE == null ? "''" : "'" + mh.MESSAGE_TYPE.Replace("'", "''") + "'")
                    + " , [BUSINESS_TYPE] = " + (mh.BUSINESS_TYPE == null ? "''" : "'" + mh.BUSINESS_TYPE.Replace("'", "''") + "'")
                    + " , [MESSAGE_ERROR] = " + (mh.MESSAGE_ERROR == null ? "''" : "'" + mh.MESSAGE_ERROR.Replace("'", "''") + "'")
                    + " , [STATUS] = " + (mh.STATUS == null ? "''" : "'" + mh.STATUS.Replace("'", "''") + "'")
                    + " where upper(MESSAGE_HEADER_ID) = '" + mh.MESSAGE_HEADER_ID.ToUpper() + "'";
                sqlList.Add(sql);
            }
            else
            {
                mh.MESSAGE_HEADER_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_MESSAGE_HEADER] ("
                    + "[MESSAGE_HEADER_ID],"
                    + "[SY_SOURCE],"
                    + "[INT_ID],"
                    + "[SHIP_ID],"
                    + "[COMPANY_CODE],"
                    + "[PRODUCE],"
                    + "[QUANTITY],"
                    + "[OCCUR],"
                    + "[ACCOUNT],"
                    + "[PACKET_ID],"
                    + "[BUSINESS_CODE],"
                    + "[MESSAGE_TYPE],"
                    + "[BUSINESS_TYPE],"
                    + "[MESSAGE_ERROR],"
                    + "[STATUS]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(mh.MESSAGE_HEADER_ID) ? "null" : "'" + mh.MESSAGE_HEADER_ID.Replace("'", "''") + "'")
                    + " , " + (mh.SY_SOURCE == null ? "''" : "'" + mh.SY_SOURCE.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(mh.INT_ID) ? "null" : "'" + mh.INT_ID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(mh.SHIP_ID) ? "null" : "'" + mh.SHIP_ID.Replace("'", "''") + "'")
                    + " , " + (mh.COMPANY_CODE == null ? "''" : "'" + mh.COMPANY_CODE.Replace("'", "''") + "'")
                    + " ," + mh.PRODUCE.ToString()
                    + " ," + mh.QUANTITY.ToString()
                    + " ," + mh.OCCUR.ToString()
                    + " ," + mh.ACCOUNT.ToString()
                    + " , " + (string.IsNullOrEmpty(mh.PACKET_ID) ? "null" : "'" + mh.PACKET_ID.Replace("'", "''") + "'")
                    + " , " + (mh.BUSINESS_CODE == null ? "''" : "'" + mh.BUSINESS_CODE.Replace("'", "''") + "'")
                    + " , " + (mh.MESSAGE_TYPE == null ? "''" : "'" + mh.MESSAGE_TYPE.Replace("'", "''") + "'")
                    + " , " + (mh.BUSINESS_TYPE == null ? "''" : "'" + mh.BUSINESS_TYPE.Replace("'", "''") + "'")
                    + " , " + (mh.MESSAGE_ERROR == null ? "''" : "'" + mh.MESSAGE_ERROR.Replace("'", "''") + "'")
                    + " , " + (mh.STATUS == null ? "''" : "'" + mh.STATUS.Replace("'", "''") + "'")
                    + ")";
                sqlList.Add(sql);
            }
            foreach (PurchaseMessage unit in dataList)
            {
                if (unit.PURCHASE_MESSAGE_ID != null && unit.PURCHASE_MESSAGE_ID.Length > 0) //edit
                {
                    sql = "UPDATE [T_PURCHASE_MESSAGE] SET "
                        + " [PURCHASE_MESSAGE_ID] = " + (string.IsNullOrEmpty(unit.PURCHASE_MESSAGE_ID) ? "null" : "'" + unit.PURCHASE_MESSAGE_ID.Replace("'", "''") + "'")
                    + " , [MESSAGE_HEADER_ID] = " + (string.IsNullOrEmpty(unit.MESSAGE_HEADER_ID) ? "null" : "'" + unit.MESSAGE_HEADER_ID.Replace("'", "''") + "'")
                    + " , [LINENUM] = " + unit.LINENUM.ToString()
                    + " , [MATERIAL] = " + (unit.MATERIAL == null ? "''" : "'" + unit.MATERIAL.Replace("'", "''") + "'")
                    + " , [MATERIAL_MAPPING] = " + (unit.MATERIAL_MAPPING == null ? "''" : "'" + unit.MATERIAL_MAPPING.Replace("'", "''") + "'")
                    + " , [QUANTITY] = " + unit.QUANTITY.ToString()
                    + " , [CURRENCY] = " + (unit.CURRENCY == null ? "''" : "'" + unit.CURRENCY.Replace("'", "''") + "'")
                    + " , [AMOUNT] = " + unit.AMOUNT.ToString()
                    + " , [SUBJECT_MAPPING] = " + (unit.SUBJECT_MAPPING == null ? "''" : "'" + unit.SUBJECT_MAPPING.Replace("'", "''") + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , [SHIP_MAPPING] = " + (unit.SHIP_MAPPING == null ? "''" : "'" + unit.SHIP_MAPPING.Replace("'", "''") + "'")
                    + " , [INPUT_OUTPUT] = " + (unit.INPUT_OUTPUT == null ? "''" : "'" + unit.INPUT_OUTPUT.Replace("'", "''") + "'")
                    + " , [SUPPLIER] = " + (unit.SUPPLIER == null ? "''" : "'" + unit.SUPPLIER.Replace("'", "''") + "'")
                    + " , [SUPPLIER_MAPPING] = " + (unit.SUPPLIER_MAPPING == null ? "''" : "'" + unit.SUPPLIER_MAPPING.Replace("'", "''") + "'")
                    + " , [INPUT_ORDER] = " + (unit.INPUT_ORDER == null ? "''" : "'" + unit.INPUT_ORDER.Replace("'", "''") + "'")
                    + " , [INPUT_OREER_ITEM] = " + unit.INPUT_OREER_ITEM.ToString()
                    + " , [UUID] = " + (string.IsNullOrEmpty(unit.UUID) ? "null" : "'" + unit.UUID.Replace("'", "''") + "'")
                    + " where upper(PURCHASE_MESSAGE_ID) = '" + unit.PURCHASE_MESSAGE_ID.ToUpper() + "'";
                    sqlList.Add(sql);
                }
                else
                {
                    unit.PURCHASE_MESSAGE_ID = Guid.NewGuid().ToString();
                    unit.MESSAGE_HEADER_ID = mh.MESSAGE_HEADER_ID;
                    sql = "INSERT INTO [T_PURCHASE_MESSAGE] ("
                        + "[PURCHASE_MESSAGE_ID],"
                        + "[MESSAGE_HEADER_ID],"
                        + "[LINENUM],"
                        + "[MATERIAL],"
                        + "[MATERIAL_MAPPING],"
                        + "[QUANTITY],"
                        + "[CURRENCY],"
                        + "[AMOUNT],"
                        + "[SUBJECT_MAPPING],"
                        + "[SHIP_ID],"
                        + "[SHIP_MAPPING],"
                        + "[INPUT_OUTPUT],"
                        + "[SUPPLIER],"
                        + "[SUPPLIER_MAPPING],"
                        + "[INPUT_ORDER],"
                        + "[INPUT_OREER_ITEM],"
                        + "[UUID]"
                        + ") VALUES( "
                        + " " + (string.IsNullOrEmpty(unit.PURCHASE_MESSAGE_ID) ? "null" : "'" + unit.PURCHASE_MESSAGE_ID.Replace("'", "''") + "'")
                        + " , " + (string.IsNullOrEmpty(unit.MESSAGE_HEADER_ID) ? "null" : "'" + unit.MESSAGE_HEADER_ID.Replace("'", "''") + "'")
                        + " ," + unit.LINENUM.ToString()
                        + " , " + (unit.MATERIAL == null ? "''" : "'" + unit.MATERIAL.Replace("'", "''") + "'")
                        + " , " + (unit.MATERIAL_MAPPING == null ? "''" : "'" + unit.MATERIAL_MAPPING.Replace("'", "''") + "'")
                        + " ," + unit.QUANTITY.ToString()
                        + " , " + (unit.CURRENCY == null ? "''" : "'" + unit.CURRENCY.Replace("'", "''") + "'")
                        + " ," + unit.AMOUNT.ToString()
                        + " , " + (unit.SUBJECT_MAPPING == null ? "''" : "'" + unit.SUBJECT_MAPPING.Replace("'", "''") + "'")
                        + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                        + " , " + (unit.SHIP_MAPPING == null ? "''" : "'" + unit.SHIP_MAPPING.Replace("'", "''") + "'")
                        + " , " + (unit.INPUT_OUTPUT == null ? "''" : "'" + unit.INPUT_OUTPUT.Replace("'", "''") + "'")
                        + " , " + (unit.SUPPLIER == null ? "''" : "'" + unit.SUPPLIER.Replace("'", "''") + "'")
                        + " , " + (unit.SUPPLIER_MAPPING == null ? "''" : "'" + unit.SUPPLIER_MAPPING.Replace("'", "''") + "'")
                        + " , " + (unit.INPUT_ORDER == null ? "''" : "'" + unit.INPUT_ORDER.Replace("'", "''") + "'")
                        + " ," + unit.INPUT_OREER_ITEM.ToString()
                        + " , " + (string.IsNullOrEmpty(unit.UUID) ? "null" : "'" + unit.UUID.Replace("'", "''") + "'")
                        + ")";
                    sqlList.Add(sql);
                }
            }

            return dbAccess.ExecSql(sqlList, out err);
        }
        /// <summary>
        /// 保存报文头和报文内容的脚本.
        /// </summary>
        /// <param name="mh"></param>
        /// <param name="dataList"></param>
        /// <param name="createMode">创建方式 1=创建报文   2=反冲账</param>
        /// <param name="err"></param>
        /// <returns></returns>
        internal void saveUnitSql(MessageHeader mh, List<PurchaseMessage> dataList, List<string> sqlList)
        {

            if (mh.MESSAGE_HEADER_ID != null && mh.MESSAGE_HEADER_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_MESSAGE_HEADER] SET "
                    + " [MESSAGE_HEADER_ID] = " + (string.IsNullOrEmpty(mh.MESSAGE_HEADER_ID) ? "null" : "'" + mh.MESSAGE_HEADER_ID.Replace("'", "''") + "'")
                    + " , [SY_SOURCE] = " + (mh.SY_SOURCE == null ? "''" : "'" + mh.SY_SOURCE.Replace("'", "''") + "'")
                    + " , [INT_ID] = " + (string.IsNullOrEmpty(mh.INT_ID) ? "null" : "'" + mh.INT_ID.Replace("'", "''") + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(mh.SHIP_ID) ? "null" : "'" + mh.SHIP_ID.Replace("'", "''") + "'")
                    + " , [COMPANY_CODE] = " + (mh.COMPANY_CODE == null ? "''" : "'" + mh.COMPANY_CODE.Replace("'", "''") + "'")
                    + " , [PRODUCE] = " + mh.PRODUCE.ToString()
                    + " , [QUANTITY] = " + mh.QUANTITY.ToString()
                    + " , [OCCUR] = " + mh.OCCUR.ToString()
                    + " , [ACCOUNT] = " + mh.ACCOUNT.ToString()
                    + " , [PACKET_ID] = " + (string.IsNullOrEmpty(mh.PACKET_ID) ? "null" : "'" + mh.PACKET_ID.Replace("'", "''") + "'")
                    + " , [BUSINESS_CODE] = " + (mh.BUSINESS_CODE == null ? "''" : "'" + mh.BUSINESS_CODE.Replace("'", "''") + "'")
                    + " , [MESSAGE_TYPE] = " + (mh.MESSAGE_TYPE == null ? "''" : "'" + mh.MESSAGE_TYPE.Replace("'", "''") + "'")
                    + " , [BUSINESS_TYPE] = " + (mh.BUSINESS_TYPE == null ? "''" : "'" + mh.BUSINESS_TYPE.Replace("'", "''") + "'")
                    + " , [MESSAGE_ERROR] = " + (mh.MESSAGE_ERROR == null ? "''" : "'" + mh.MESSAGE_ERROR.Replace("'", "''") + "'")
                    + " , [STATUS] = " + (mh.STATUS == null ? "''" : "'" + mh.STATUS.Replace("'", "''") + "'")
                    + " where upper(MESSAGE_HEADER_ID) = '" + mh.MESSAGE_HEADER_ID.ToUpper() + "'";
                sqlList.Add(sql);
            }
            else
            {
                mh.MESSAGE_HEADER_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_MESSAGE_HEADER] ("
                    + "[MESSAGE_HEADER_ID],"
                    + "[SY_SOURCE],"
                    + "[INT_ID],"
                    + "[SHIP_ID],"
                    + "[COMPANY_CODE],"
                    + "[PRODUCE],"
                    + "[QUANTITY],"
                    + "[OCCUR],"
                    + "[ACCOUNT],"
                    + "[PACKET_ID],"
                    + "[BUSINESS_CODE],"
                    + "[MESSAGE_TYPE],"
                    + "[BUSINESS_TYPE],"
                    + "[MESSAGE_ERROR],"
                    + "[STATUS]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(mh.MESSAGE_HEADER_ID) ? "null" : "'" + mh.MESSAGE_HEADER_ID.Replace("'", "''") + "'")
                    + " , " + (mh.SY_SOURCE == null ? "''" : "'" + mh.SY_SOURCE.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(mh.INT_ID) ? "null" : "'" + mh.INT_ID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(mh.SHIP_ID) ? "null" : "'" + mh.SHIP_ID.Replace("'", "''") + "'")
                    + " , " + (mh.COMPANY_CODE == null ? "''" : "'" + mh.COMPANY_CODE.Replace("'", "''") + "'")
                    + " ," + mh.PRODUCE.ToString()
                    + " ," + mh.QUANTITY.ToString()
                    + " ," + mh.OCCUR.ToString()
                    + " ," + mh.ACCOUNT.ToString()
                    + " , " + (string.IsNullOrEmpty(mh.PACKET_ID) ? "null" : "'" + mh.PACKET_ID.Replace("'", "''") + "'")
                    + " , " + (mh.BUSINESS_CODE == null ? "''" : "'" + mh.BUSINESS_CODE.Replace("'", "''") + "'")
                    + " , " + (mh.MESSAGE_TYPE == null ? "''" : "'" + mh.MESSAGE_TYPE.Replace("'", "''") + "'")
                    + " , " + (mh.BUSINESS_TYPE == null ? "''" : "'" + mh.BUSINESS_TYPE.Replace("'", "''") + "'")
                    + " , " + (mh.MESSAGE_ERROR == null ? "''" : "'" + mh.MESSAGE_ERROR.Replace("'", "''") + "'")
                    + " , " + (mh.STATUS == null ? "''" : "'" + mh.STATUS.Replace("'", "''") + "'")
                    + ")";
                sqlList.Add(sql);
            }
            foreach (PurchaseMessage unit in dataList)
            {
                if (unit.PURCHASE_MESSAGE_ID != null && unit.PURCHASE_MESSAGE_ID.Length > 0) //edit
                {
                    sql = "UPDATE [T_PURCHASE_MESSAGE] SET "
                        + " [PURCHASE_MESSAGE_ID] = " + (string.IsNullOrEmpty(unit.PURCHASE_MESSAGE_ID) ? "null" : "'" + unit.PURCHASE_MESSAGE_ID.Replace("'", "''") + "'")
                    + " , [MESSAGE_HEADER_ID] = " + (string.IsNullOrEmpty(unit.MESSAGE_HEADER_ID) ? "null" : "'" + unit.MESSAGE_HEADER_ID.Replace("'", "''") + "'")
                    + " , [LINENUM] = " + unit.LINENUM.ToString()
                    + " , [MATERIAL] = " + (unit.MATERIAL == null ? "''" : "'" + unit.MATERIAL.Replace("'", "''") + "'")
                    + " , [MATERIAL_MAPPING] = " + (unit.MATERIAL_MAPPING == null ? "''" : "'" + unit.MATERIAL_MAPPING.Replace("'", "''") + "'")
                    + " , [QUANTITY] = " + unit.QUANTITY.ToString()
                    + " , [CURRENCY] = " + (unit.CURRENCY == null ? "''" : "'" + unit.CURRENCY.Replace("'", "''") + "'")
                    + " , [AMOUNT] = " + unit.AMOUNT.ToString()
                    + " , [SUBJECT_MAPPING] = " + (unit.SUBJECT_MAPPING == null ? "''" : "'" + unit.SUBJECT_MAPPING.Replace("'", "''") + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , [SHIP_MAPPING] = " + (unit.SHIP_MAPPING == null ? "''" : "'" + unit.SHIP_MAPPING.Replace("'", "''") + "'")
                    + " , [INPUT_OUTPUT] = " + (unit.INPUT_OUTPUT == null ? "''" : "'" + unit.INPUT_OUTPUT.Replace("'", "''") + "'")
                    + " , [SUPPLIER] = " + (unit.SUPPLIER == null ? "''" : "'" + unit.SUPPLIER.Replace("'", "''") + "'")
                    + " , [SUPPLIER_MAPPING] = " + (unit.SUPPLIER_MAPPING == null ? "''" : "'" + unit.SUPPLIER_MAPPING.Replace("'", "''") + "'")
                    + " , [INPUT_ORDER] = " + (unit.INPUT_ORDER == null ? "''" : "'" + unit.INPUT_ORDER.Replace("'", "''") + "'")
                    + " , [INPUT_OREER_ITEM] = " + unit.INPUT_OREER_ITEM.ToString()
                    + " , [UUID] = " + (string.IsNullOrEmpty(unit.UUID) ? "null" : "'" + unit.UUID.Replace("'", "''") + "'")
                    + " where upper(PURCHASE_MESSAGE_ID) = '" + unit.PURCHASE_MESSAGE_ID.ToUpper() + "'";
                    sqlList.Add(sql);
                }
                else
                {
                    unit.PURCHASE_MESSAGE_ID = Guid.NewGuid().ToString();
                    unit.MESSAGE_HEADER_ID = mh.MESSAGE_HEADER_ID;
                    sql = "INSERT INTO [T_PURCHASE_MESSAGE] ("
                        + "[PURCHASE_MESSAGE_ID],"
                        + "[MESSAGE_HEADER_ID],"
                        + "[LINENUM],"
                        + "[MATERIAL],"
                        + "[MATERIAL_MAPPING],"
                        + "[QUANTITY],"
                        + "[CURRENCY],"
                        + "[AMOUNT],"
                        + "[SUBJECT_MAPPING],"
                        + "[SHIP_ID],"
                        + "[SHIP_MAPPING],"
                        + "[INPUT_OUTPUT],"
                        + "[SUPPLIER],"
                        + "[SUPPLIER_MAPPING],"
                        + "[INPUT_ORDER],"
                        + "[INPUT_OREER_ITEM],"
                        + "[UUID]"
                        + ") VALUES( "
                        + " " + (string.IsNullOrEmpty(unit.PURCHASE_MESSAGE_ID) ? "null" : "'" + unit.PURCHASE_MESSAGE_ID.Replace("'", "''") + "'")
                        + " , " + (string.IsNullOrEmpty(unit.MESSAGE_HEADER_ID) ? "null" : "'" + unit.MESSAGE_HEADER_ID.Replace("'", "''") + "'")
                        + " ," + unit.LINENUM.ToString()
                        + " , " + (unit.MATERIAL == null ? "''" : "'" + unit.MATERIAL.Replace("'", "''") + "'")
                        + " , " + (unit.MATERIAL_MAPPING == null ? "''" : "'" + unit.MATERIAL_MAPPING.Replace("'", "''") + "'")
                        + " ," + unit.QUANTITY.ToString()
                        + " , " + (unit.CURRENCY == null ? "''" : "'" + unit.CURRENCY.Replace("'", "''") + "'")
                        + " ," + unit.AMOUNT.ToString()
                        + " , " + (unit.SUBJECT_MAPPING == null ? "''" : "'" + unit.SUBJECT_MAPPING.Replace("'", "''") + "'")
                        + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                        + " , " + (unit.SHIP_MAPPING == null ? "''" : "'" + unit.SHIP_MAPPING.Replace("'", "''") + "'")
                        + " , " + (unit.INPUT_OUTPUT == null ? "''" : "'" + unit.INPUT_OUTPUT.Replace("'", "''") + "'")
                        + " , " + (unit.SUPPLIER == null ? "''" : "'" + unit.SUPPLIER.Replace("'", "''") + "'")
                        + " , " + (unit.SUPPLIER_MAPPING == null ? "''" : "'" + unit.SUPPLIER_MAPPING.Replace("'", "''") + "'")
                        + " , " + (unit.INPUT_ORDER == null ? "''" : "'" + unit.INPUT_ORDER.Replace("'", "''") + "'")
                        + " ," + unit.INPUT_OREER_ITEM.ToString()
                        + " , " + (string.IsNullOrEmpty(unit.UUID) ? "null" : "'" + unit.UUID.Replace("'", "''") + "'")
                        + ")";
                    sqlList.Add(sql);
                }
            }
        }
        /// <summary>
        /// 根据报文头ID获得报文详细.
        /// </summary>
        /// <param name="headerID"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public DataTable GetInfoByHeaderID(string headerID, out string err)
        {
            sql = "select	"
                + "tpm.PURCHASE_MESSAGE_ID"
                + ",tpm.MESSAGE_HEADER_ID"
                + ",tpm.LINENUM"
                + ",tpm.MATERIAL"
                + ",m.MATERIAL_NAME"
                + ",tpm.MATERIAL_MAPPING"
                + ",tpm.QUANTITY"
                + ",tpm.CURRENCY"
                + ",tpm.AMOUNT"
                + ",tpm.SUBJECT_MAPPING"
                + ",ca.NODE_NAME"
                + ",tpm.SHIP_ID"
                + ",tpm.SHIP_MAPPING"
                + ",s.ship_name"
                + ",tpm.INPUT_OUTPUT"
                + ",case tpm.INPUT_OUTPUT when 'O' then '出库' when 'I' then '入库' end as  INPUT_OUTPUT_NAME "
                + ",tpm.SUPPLIER"
                + ",tpm.SUPPLIER_MAPPING"
                + ",ma.MANUFACTURER_NAME"
                + ",tpm.INPUT_ORDER"
                + ",tpm.INPUT_OREER_ITEM"
                + ",tpm.UUID"
                + ",tpm.REBATE"
                + ",tpm.ORDER_AMOUNT"
                + ",tpm.ACCOUNT_CODE"
                + ",tpm.ACCOUNT_NAME"
                + ",tpm.BUSINESS_CODE"
                + "  from T_PURCHASE_MESSAGE tpm "
                + " left join t_material m on m.MATERIAL_ID=tpm.MATERIAL"
                + " left join t_ship s on s.ship_id=tpm.ship_id "
                + " left join T_MANUFACTURER ma on ma.MANUFACTURER_ID=tpm.SUPPLIER"
                + " left join (select code,MAX(NODE_NAME) node_name from T_COST_ACCOUNT group by code ) ca on tpm.SUBJECT_MAPPING = ca.CODE"
                + "  where tpm.MESSAGE_HEADER_ID='" + headerID + "'"
                + "  order by tpm.LINENUM";
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
        /// 根据BUSINESS_CODE查询采购信息提供给凭证.
        /// </summary>
        /// <returns>T_PURCHASE_MESSAGE DataTable</returns>
        public bool GetPurchaseMessageByBusinessCode(string BUSINESS_CODE, out DataTable dt, out string err)
        {
            sql = string.Format(@"select	
                pm.PURCHASE_MESSAGE_ID
                ,pm.MESSAGE_HEADER_ID
                ,pm.MATERIAL
                ,smn.MATERIAL_NAME
                ,smn.MATERIAL_SPEC
                ,pm.QUANTITY
                ,pm.CURRENCY
                ,pm.AMOUNT
                ,pm.SHIP_ID
                ,pm.SUPPLIER
                ,pm.REBATE
                ,pm.ORDER_AMOUNT
                ,pm.ACCOUNT_CODE
                ,pm.ACCOUNT_NAME
                ,pm.BUSINESS_CODE
                from T_PURCHASE_MESSAGE pm 
                LEFT JOIN V_SAP_Material_Name smn
                ON smn.MATERIAL_ID=pm.MATERIAL
                where pm.BUSINESS_CODE='{0}'", BUSINESS_CODE);
            return dbAccess.GetDataTable(sql, out dt, out err);
        }
    }
}
