/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：OutboundMessageService.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/6/16
 * 标    题：数据操作类
 * 功能描述：T_OUTBOUND_MESSAGE数据操作类
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
    public partial class OutboundMessageService
    {
        /// <summary>
        /// 获取保存报文头和报文内容的事务执行语句        /// </summary>
        /// <param name="mh"></param>
        /// <param name="dataList"></param>
        /// <param name="createMode">创建方式 1=创建报文   2=反冲账</param>
        /// <param name="err"></param>
        /// <returns></returns>
        internal List<string> GetSaveUnitTransactionSql(MessageHeader mh, List<OutboundMessage> dataList)
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
            foreach (OutboundMessage unit in dataList)
            {
                if (unit.OUTBOUND_MESSAGE_ID != null && unit.OUTBOUND_MESSAGE_ID.Length > 0) //edit
                {
                    sql = "UPDATE [T_OUTBOUND_MESSAGE] SET "
                        + " [OUTBOUND_MESSAGE_ID] = " + (string.IsNullOrEmpty(unit.OUTBOUND_MESSAGE_ID) ? "null" : "'" + unit.OUTBOUND_MESSAGE_ID.Replace("'", "''") + "'")
                        + " , [MESSAGE_HEADER_ID] = " + (string.IsNullOrEmpty(unit.MESSAGE_HEADER_ID) ? "null" : "'" + unit.MESSAGE_HEADER_ID.Replace("'", "''") + "'")
                        + " , [LINENUM] = " + unit.LINENUM.ToString()
                        + " , [MATERIAL] = " + (unit.MATERIAL == null ? "''" : "'" + unit.MATERIAL.Replace("'", "''") + "'")
                        + " , [MATERIAL_MAPPING] = " + (unit.MATERIAL_MAPPING == null ? "''" : "'" + unit.MATERIAL_MAPPING.Replace("'", "''") + "'")
                        + " , [QUANTITY] = " + unit.QUANTITY.ToString()
                        + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                        + " , [SHIP_MAPPING] = " + (unit.SHIP_MAPPING == null ? "''" : "'" + unit.SHIP_MAPPING.Replace("'", "''") + "'")
                        + " , [INPUT_OUTPUT] = " + (unit.INPUT_OUTPUT == null ? "''" : "'" + unit.INPUT_OUTPUT.Replace("'", "''") + "'")
                        + " , [UUID] = " + (string.IsNullOrEmpty(unit.UUID) ? "null" : "'" + unit.UUID.Replace("'", "''") + "'")
                        + " where upper(OUTBOUND_MESSAGE_ID) = '" + unit.OUTBOUND_MESSAGE_ID.ToUpper() + "'";
                    sqlList.Add(sql);
                }
                else
                {
                    unit.OUTBOUND_MESSAGE_ID = Guid.NewGuid().ToString();
                    unit.MESSAGE_HEADER_ID = mh.MESSAGE_HEADER_ID;
                    sql = "INSERT INTO [T_OUTBOUND_MESSAGE] ("
                        + "[OUTBOUND_MESSAGE_ID],"
                        + "[MESSAGE_HEADER_ID],"
                        + "[LINENUM],"
                        + "[MATERIAL],"
                        + "[MATERIAL_MAPPING],"
                        + "[QUANTITY],"
                        + "[SHIP_ID],"
                        + "[SHIP_MAPPING],"
                        + "[INPUT_OUTPUT],"
                        + "[UUID]"
                        + ") VALUES( "
                        + " " + (string.IsNullOrEmpty(unit.OUTBOUND_MESSAGE_ID) ? "null" : "'" + unit.OUTBOUND_MESSAGE_ID.Replace("'", "''") + "'")
                        + " , " + (string.IsNullOrEmpty(unit.MESSAGE_HEADER_ID) ? "null" : "'" + unit.MESSAGE_HEADER_ID.Replace("'", "''") + "'")
                        + " ," + unit.LINENUM.ToString()
                        + " , " + (unit.MATERIAL == null ? "''" : "'" + unit.MATERIAL.Replace("'", "''") + "'")
                        + " , " + (unit.MATERIAL_MAPPING == null ? "''" : "'" + unit.MATERIAL_MAPPING.Replace("'", "''") + "'")
                        + " ," + unit.QUANTITY.ToString()
                        + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                        + " , " + (unit.SHIP_MAPPING == null ? "''" : "'" + unit.SHIP_MAPPING.Replace("'", "''") + "'")
                        + " , " + (unit.INPUT_OUTPUT == null ? "''" : "'" + unit.INPUT_OUTPUT.Replace("'", "''") + "'")
                        + " , " + (string.IsNullOrEmpty(unit.UUID) ? "null" : "'" + unit.UUID.Replace("'", "''") + "'")
                        + ")";
                    sqlList.Add(sql);
                }
            }
            return sqlList;
        }
        /// <summary>
        /// 保存报文头和报文内容的事务.
        /// </summary>
        /// <param name="mh"></param>
        /// <param name="dataList"></param>
        /// <param name="createMode">创建方式 1=创建报文   2=反冲账</param>
        /// <param name="err"></param>
        /// <returns></returns>
        internal bool saveUnitTransaction(MessageHeader mh, List<OutboundMessage> dataList, out string err)
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
            foreach (OutboundMessage unit in dataList)
            {
                if (unit.OUTBOUND_MESSAGE_ID != null && unit.OUTBOUND_MESSAGE_ID.Length > 0) //edit
                {
                    sql = "UPDATE [T_OUTBOUND_MESSAGE] SET "
                        + " [OUTBOUND_MESSAGE_ID] = " + (string.IsNullOrEmpty(unit.OUTBOUND_MESSAGE_ID) ? "null" : "'" + unit.OUTBOUND_MESSAGE_ID.Replace("'", "''") + "'")
                        + " , [MESSAGE_HEADER_ID] = " + (string.IsNullOrEmpty(unit.MESSAGE_HEADER_ID) ? "null" : "'" + unit.MESSAGE_HEADER_ID.Replace("'", "''") + "'")
                        + " , [LINENUM] = " + unit.LINENUM.ToString()
                        + " , [MATERIAL] = " + (unit.MATERIAL == null ? "''" : "'" + unit.MATERIAL.Replace("'", "''") + "'")
                        + " , [MATERIAL_MAPPING] = " + (unit.MATERIAL_MAPPING == null ? "''" : "'" + unit.MATERIAL_MAPPING.Replace("'", "''") + "'")
                        + " , [QUANTITY] = " + unit.QUANTITY.ToString()
                        + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                        + " , [SHIP_MAPPING] = " + (unit.SHIP_MAPPING == null ? "''" : "'" + unit.SHIP_MAPPING.Replace("'", "''") + "'")
                        + " , [INPUT_OUTPUT] = " + (unit.INPUT_OUTPUT == null ? "''" : "'" + unit.INPUT_OUTPUT.Replace("'", "''") + "'")
                        + " , [UUID] = " + (string.IsNullOrEmpty(unit.UUID) ? "null" : "'" + unit.UUID.Replace("'", "''") + "'")
                        + " where upper(OUTBOUND_MESSAGE_ID) = '" + unit.OUTBOUND_MESSAGE_ID.ToUpper() + "'";
                    sqlList.Add(sql);
                }
                else
                {
                    unit.OUTBOUND_MESSAGE_ID = Guid.NewGuid().ToString();
                    unit.MESSAGE_HEADER_ID = mh.MESSAGE_HEADER_ID;
                    sql = "INSERT INTO [T_OUTBOUND_MESSAGE] ("
                        + "[OUTBOUND_MESSAGE_ID],"
                        + "[MESSAGE_HEADER_ID],"
                        + "[LINENUM],"
                        + "[MATERIAL],"
                        + "[MATERIAL_MAPPING],"
                        + "[QUANTITY],"
                        + "[SHIP_ID],"
                        + "[SHIP_MAPPING],"
                        + "[INPUT_OUTPUT],"
                        + "[UUID]"
                        + ") VALUES( "
                        + " " + (string.IsNullOrEmpty(unit.OUTBOUND_MESSAGE_ID) ? "null" : "'" + unit.OUTBOUND_MESSAGE_ID.Replace("'", "''") + "'")
                        + " , " + (string.IsNullOrEmpty(unit.MESSAGE_HEADER_ID) ? "null" : "'" + unit.MESSAGE_HEADER_ID.Replace("'", "''") + "'")
                        + " ," + unit.LINENUM.ToString()
                        + " , " + (unit.MATERIAL == null ? "''" : "'" + unit.MATERIAL.Replace("'", "''") + "'")
                        + " , " + (unit.MATERIAL_MAPPING == null ? "''" : "'" + unit.MATERIAL_MAPPING.Replace("'", "''") + "'")
                        + " ," + unit.QUANTITY.ToString()
                        + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                        + " , " + (unit.SHIP_MAPPING == null ? "''" : "'" + unit.SHIP_MAPPING.Replace("'", "''") + "'")
                        + " , " + (unit.INPUT_OUTPUT == null ? "''" : "'" + unit.INPUT_OUTPUT.Replace("'", "''") + "'")
                        + " , " + (string.IsNullOrEmpty(unit.UUID) ? "null" : "'" + unit.UUID.Replace("'", "''") + "'")
                        + ")";
                    sqlList.Add(sql);
                }
            }
            return dbAccess.ExecSql(sqlList, out err);
        }
        /// <summary>
        /// 根据报文头ID获得报文详细.
        /// </summary>
        /// <param name="headerID"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public DataTable GetInfoByHeaderID(string headerID, out string err)
        {
            sql = "select "
                 + "om.OUTBOUND_MESSAGE_ID"
                 + ",om.MESSAGE_HEADER_ID"
                 + ",om.LINENUM"
                 + ",om.MATERIAL"
                 + ",om.MATERIAL_MAPPING"
                 + ",m.MATERIAL_NAME"
                 + ",om.QUANTITY"
                 + ",om.SHIP_ID"
                 + ",s.ship_name"
                 + ",om.SHIP_MAPPING"
                 + ",om.INPUT_OUTPUT"
                 + ",case om.INPUT_OUTPUT when 'O' then '出库' when 'I' then '入库' end as  INPUT_OUTPUT_NAME "
                 + ",om.UUID"
                 + " from T_OUTBOUND_MESSAGE om "
                 + " left join t_material m on m.MATERIAL_ID=om.MATERIAL"
                 + " left join t_ship s on s.ship_id=om.ship_id "
                 + " where om.MESSAGE_HEADER_ID='" + headerID + "'"
                 + "  order by om.LINENUM";
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
