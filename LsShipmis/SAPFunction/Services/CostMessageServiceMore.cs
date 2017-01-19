/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：CostMessageService.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/6/16
 * 标    题：数据操作类
 * 功能描述：T_COST_MESSAGE数据操作类
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
    public partial class CostMessageService
    {
        /// <summary>
        /// 保存报文头和报文内容的事务.
        /// </summary>
        /// <param name="mh"></param>
        /// <param name="dataList"></param>
        /// <param name="createMode">创建方式 1=创建报文   2=反冲账</param>
        /// <param name="err"></param>
        /// <returns></returns>
        internal bool saveUnitTransaction(MessageHeader mh, List<CostMessage> dataList, out string err)
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
            foreach (CostMessage unit in dataList)
            {
                if (unit.COST_MESSAGE_ID != null && unit.COST_MESSAGE_ID.Length > 0) //edit
                {
                    sql = "UPDATE [T_COST_MESSAGE] SET "
                        + " [COST_MESSAGE_ID] = " + (string.IsNullOrEmpty(unit.COST_MESSAGE_ID) ? "null" : "'" + unit.COST_MESSAGE_ID.Replace("'", "''") + "'")
                        + " , [MESSAGE_HEADER_ID] = " + (string.IsNullOrEmpty(unit.MESSAGE_HEADER_ID) ? "null" : "'" + unit.MESSAGE_HEADER_ID.Replace("'", "''") + "'")
                        + " , [LINENUM] = " + unit.LINENUM.ToString()
                        + " , [SUPPLIER] = " + (unit.SUPPLIER == null ? "''" : "'" + unit.SUPPLIER.Replace("'", "''") + "'")
                        + " , [SUPPLIER_MAPPING] = " + (unit.SUPPLIER_MAPPING == null ? "''" : "'" + unit.SUPPLIER_MAPPING.Replace("'", "''") + "'")
                        + " , [CURRENCY] = " + (unit.CURRENCY == null ? "''" : "'" + unit.CURRENCY.Replace("'", "''") + "'")
                        + " , [AMOUNT] = " + unit.AMOUNT.ToString()
                        + " , [SUBJECT] = " + (unit.SUBJECT == null ? "''" : "'" + unit.SUBJECT.Replace("'", "''") + "'")
                        + " , [SUBJECT_MAPPING] = " + (unit.SUBJECT_MAPPING == null ? "''" : "'" + unit.SUBJECT_MAPPING.Replace("'", "''") + "'")
                        + " , [COST_TYPE] = " + (unit.COST_TYPE == null ? "''" : "'" + unit.COST_TYPE.Replace("'", "''") + "'")
                        + " , [INNER_ORDER] = " + (unit.INNER_ORDER == null ? "''" : "'" + unit.INNER_ORDER.Replace("'", "''") + "'")
                        + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                        + " , [SHIP_MAPPING] = " + (unit.SHIP_MAPPING == null ? "''" : "'" + unit.SHIP_MAPPING.Replace("'", "''") + "'")
                        + " , [UUID] = " + (string.IsNullOrEmpty(unit.UUID) ? "null" : "'" + unit.UUID.Replace("'", "''") + "'")
                        + " , [REMARK] = " + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
                        + " where upper(COST_MESSAGE_ID) = '" + unit.COST_MESSAGE_ID.ToUpper() + "'";
                    sqlList.Add(sql);
                }
                else
                {
                    unit.COST_MESSAGE_ID = Guid.NewGuid().ToString();
                    unit.MESSAGE_HEADER_ID = mh.MESSAGE_HEADER_ID;
                    sql = "INSERT INTO [T_COST_MESSAGE] ("
                        + "[COST_MESSAGE_ID],"
                        + "[MESSAGE_HEADER_ID],"
                        + "[LINENUM],"
                        + "[SUPPLIER],"
                        + "[SUPPLIER_MAPPING],"
                        + "[CURRENCY],"
                        + "[AMOUNT],"
                        + "[SUBJECT],"
                        + "[SUBJECT_MAPPING],"
                        + "[COST_TYPE],"
                        + "[INNER_ORDER],"
                        + "[SHIP_ID],"
                        + "[SHIP_MAPPING],"
                        + "[UUID],"
                        + "[REMARK]"
                        + ") VALUES( "
                        + " " + (string.IsNullOrEmpty(unit.COST_MESSAGE_ID) ? "null" : "'" + unit.COST_MESSAGE_ID.Replace("'", "''") + "'")
                        + " , " + (string.IsNullOrEmpty(unit.MESSAGE_HEADER_ID) ? "null" : "'" + unit.MESSAGE_HEADER_ID.Replace("'", "''") + "'")
                        + " ," + unit.LINENUM.ToString()
                        + " , " + (unit.SUPPLIER == null ? "''" : "'" + unit.SUPPLIER.Replace("'", "''") + "'")
                        + " , " + (unit.SUPPLIER_MAPPING == null ? "''" : "'" + unit.SUPPLIER_MAPPING.Replace("'", "''") + "'")
                        + " , " + (unit.CURRENCY == null ? "''" : "'" + unit.CURRENCY.Replace("'", "''") + "'")
                        + " ," + unit.AMOUNT.ToString()
                        + " , " + (unit.SUBJECT == null ? "''" : "'" + unit.SUBJECT.Replace("'", "''") + "'")
                        + " , " + (unit.SUBJECT_MAPPING == null ? "''" : "'" + unit.SUBJECT_MAPPING.Replace("'", "''") + "'")
                        + " , " + (unit.COST_TYPE == null ? "''" : "'" + unit.COST_TYPE.Replace("'", "''") + "'")
                        + " , " + (unit.INNER_ORDER == null ? "''" : "'" + unit.INNER_ORDER.Replace("'", "''") + "'")
                        + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                        + " , " + (unit.SHIP_MAPPING == null ? "''" : "'" + unit.SHIP_MAPPING.Replace("'", "''") + "'")
                        + " , " + (string.IsNullOrEmpty(unit.UUID) ? "null" : "'" + unit.UUID.Replace("'", "''") + "'")
                        + " , " + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
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
        internal void saveUnitSql(MessageHeader mh, List<CostMessage> dataList, List<string> sqlList)
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
            foreach (CostMessage unit in dataList)
            {
                if (unit.COST_MESSAGE_ID != null && unit.COST_MESSAGE_ID.Length > 0) //edit
                {
                    sql = "UPDATE [T_COST_MESSAGE] SET "
                        + " [COST_MESSAGE_ID] = " + (string.IsNullOrEmpty(unit.COST_MESSAGE_ID) ? "null" : "'" + unit.COST_MESSAGE_ID.Replace("'", "''") + "'")
                        + " , [MESSAGE_HEADER_ID] = " + (string.IsNullOrEmpty(unit.MESSAGE_HEADER_ID) ? "null" : "'" + unit.MESSAGE_HEADER_ID.Replace("'", "''") + "'")
                        + " , [LINENUM] = " + unit.LINENUM.ToString()
                        + " , [SUPPLIER] = " + (unit.SUPPLIER == null ? "''" : "'" + unit.SUPPLIER.Replace("'", "''") + "'")
                        + " , [SUPPLIER_MAPPING] = " + (unit.SUPPLIER_MAPPING == null ? "''" : "'" + unit.SUPPLIER_MAPPING.Replace("'", "''") + "'")
                        + " , [CURRENCY] = " + (unit.CURRENCY == null ? "''" : "'" + unit.CURRENCY.Replace("'", "''") + "'")
                        + " , [AMOUNT] = " + unit.AMOUNT.ToString()
                        + " , [SUBJECT] = " + (unit.SUBJECT == null ? "''" : "'" + unit.SUBJECT.Replace("'", "''") + "'")
                        + " , [SUBJECT_MAPPING] = " + (unit.SUBJECT_MAPPING == null ? "''" : "'" + unit.SUBJECT_MAPPING.Replace("'", "''") + "'")
                        + " , [COST_TYPE] = " + (unit.COST_TYPE == null ? "''" : "'" + unit.COST_TYPE.Replace("'", "''") + "'")
                        + " , [INNER_ORDER] = " + (unit.INNER_ORDER == null ? "''" : "'" + unit.INNER_ORDER.Replace("'", "''") + "'")
                        + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                        + " , [SHIP_MAPPING] = " + (unit.SHIP_MAPPING == null ? "''" : "'" + unit.SHIP_MAPPING.Replace("'", "''") + "'")
                        + " , [UUID] = " + (string.IsNullOrEmpty(unit.UUID) ? "null" : "'" + unit.UUID.Replace("'", "''") + "'")
                        + " , [REMARK] = " + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
                        + " where upper(COST_MESSAGE_ID) = '" + unit.COST_MESSAGE_ID.ToUpper() + "'";
                    sqlList.Add(sql);
                }
                else
                {
                    unit.COST_MESSAGE_ID = Guid.NewGuid().ToString();
                    unit.MESSAGE_HEADER_ID = mh.MESSAGE_HEADER_ID;
                    sql = "INSERT INTO [T_COST_MESSAGE] ("
                        + "[COST_MESSAGE_ID],"
                        + "[MESSAGE_HEADER_ID],"
                        + "[LINENUM],"
                        + "[SUPPLIER],"
                        + "[SUPPLIER_MAPPING],"
                        + "[CURRENCY],"
                        + "[AMOUNT],"
                        + "[SUBJECT],"
                        + "[SUBJECT_MAPPING],"
                        + "[COST_TYPE],"
                        + "[INNER_ORDER],"
                        + "[SHIP_ID],"
                        + "[SHIP_MAPPING],"
                        + "[UUID],"
                        + "[REMARK]"
                        + ") VALUES( "
                        + " " + (string.IsNullOrEmpty(unit.COST_MESSAGE_ID) ? "null" : "'" + unit.COST_MESSAGE_ID.Replace("'", "''") + "'")
                        + " , " + (string.IsNullOrEmpty(unit.MESSAGE_HEADER_ID) ? "null" : "'" + unit.MESSAGE_HEADER_ID.Replace("'", "''") + "'")
                        + " ," + unit.LINENUM.ToString()
                        + " , " + (unit.SUPPLIER == null ? "''" : "'" + unit.SUPPLIER.Replace("'", "''") + "'")
                        + " , " + (unit.SUPPLIER_MAPPING == null ? "''" : "'" + unit.SUPPLIER_MAPPING.Replace("'", "''") + "'")
                        + " , " + (unit.CURRENCY == null ? "''" : "'" + unit.CURRENCY.Replace("'", "''") + "'")
                        + " ," + unit.AMOUNT.ToString()
                        + " , " + (unit.SUBJECT == null ? "''" : "'" + unit.SUBJECT.Replace("'", "''") + "'")
                        + " , " + (unit.SUBJECT_MAPPING == null ? "''" : "'" + unit.SUBJECT_MAPPING.Replace("'", "''") + "'")
                        + " , " + (unit.COST_TYPE == null ? "''" : "'" + unit.COST_TYPE.Replace("'", "''") + "'")
                        + " , " + (unit.INNER_ORDER == null ? "''" : "'" + unit.INNER_ORDER.Replace("'", "''") + "'")
                        + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                        + " , " + (unit.SHIP_MAPPING == null ? "''" : "'" + unit.SHIP_MAPPING.Replace("'", "''") + "'")
                        + " , " + (string.IsNullOrEmpty(unit.UUID) ? "null" : "'" + unit.UUID.Replace("'", "''") + "'")
                        + " , " + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
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
            sql = string.Format(@"select cm.COST_MESSAGE_ID,cm.MESSAGE_HEADER_ID,cm.LINENUM,ma.MANUFACTURER_ID SUPPLIER,
case when ltrim(isnull(cm.SUPPLIER_MAPPING,''))= '' then ma.MANUFACTURER_CODE else cm.SUPPLIER_MAPPING end SUPPLIER_MAPPING,ma.MANUFACTURER_NAME,
cm.CURRENCY,cm.AMOUNT,cm.SUBJECT,cm.SUBJECT_MAPPING,cd.NODE_NAME,cm.COST_TYPE,
case cm.Cost_type when 'A' then '厂修' when 'B' then '常规维修' when 'C' then '船员奖励' when 'D' then '船东费用' end as Cost_type_NAME ,
cm.INNER_ORDER,s.SHIP_ID,
case when ltrim(isnull(cm.SHIP_MAPPING,''))= '' then s.SHIP_CODE else cm.SHIP_MAPPING end SHIP_MAPPING
,s.ship_name,cm.UUID,cm.REMARK
 from T_COST_MESSAGE cm left join 
 (select code,MAX(NODE_NAME) node_name from T_COST_ACCOUNT group by code ) cd on cm.SUBJECT_MAPPING = cd.CODE 
 inner join t_ship s on s.ship_id=cm.ship_id 
 inner join T_COST_ACTUAL_COSTS t1 on t1.COSTS_ID = cm.uuid  
 left join T_MANUFACTURER ma on ma.manufacturer_name=t1.CUSTOMER
where cm.MESSAGE_HEADER_ID='{0}'
order by cm.LINENUM", headerID);

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
    }
}
