/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：MessageHeaderService.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/6/20
 * 标    题：数据操作类
 * 功能描述：T_MESSAGE_HEADER数据操作类
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
    public partial class MessageHeaderService
    {
        /// <summary>
        /// 获取报文头信息
        /// </summary>
        /// <param name="ship_id"></param>
        /// <param name="type"></param>
        /// <param name="status"></param>
        /// <param name="businessType"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public DataTable GetInfo(string ship_id,string yearMonth,string type, string status, string businessType, out string err)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(@"select	
                mh.MESSAGE_HEADER_ID
                ,mh.SY_SOURCE
                ,'机务' as SY_SOURCE_NAME
                ,mh.INT_ID
                ,case mh.INT_ID
when 'JMM001' then '机务-采购接口' 
when 'JMM002' then '机务-费用接口' 
when 'JMM003' then '机务-库存领用及盘点接口' end as INT_ID_NAME 
                ,mh.SHIP_ID
                ,s.ship_name
                ,mh.COMPANY_CODE
                ,mh.PRODUCE
                ,mh.QUANTITY
                ,mh.OCCUR
                ,mh.ACCOUNT
                ,mh.PACKET_ID
                ,mh.BUSINESS_CODE
                ,mh.MESSAGE_TYPE
                ,case mh.MESSAGE_TYPE 
when '1' then '采购接口' 
when '2' then '费用接口' 
when '3' then '出入库接口' 
when '4' then '盘点接口' end as MESSAGE_TYPE_NAME 
                ,mh.BUSINESS_TYPE
                ,case mh.BUSINESS_TYPE 
when '1' then '物料业务' 
when '2' then '备件业务' 
when '3' then '油料业务' 
when '4' then '其他业务' end as BUSINESS_TYPE_NAME 
                ,mh.MESSAGE_ERROR
                ,mh.STATUS
                ,case mh.status 
                when '2' then '未通过映射'
                when '3' then '待发送'
                when '4' then '报文错误'
                when '5' then '发送成功'
                when '6' then '作废'
                when '7' then 'SAP方法调用失败'
                end as STATUS_NAME
                  from T_MESSAGE_HEADER mh
                 inner join t_ship s on s.ship_id=mh.ship_id 
                  where 1=1 ");
            if (!string.IsNullOrEmpty(ship_id))
                sql.AppendLine( " and mh.SHIP_ID='" + ship_id + "'");
            if (!string.IsNullOrEmpty(yearMonth))
                sql.AppendLine(  " and left(convert(varchar(20),mh.PRODUCE,121),6)='" + yearMonth + "'");
            if (!string.IsNullOrEmpty(type))
                sql.AppendLine(  " and mh.message_type='" + type + "'");
            if (!string.IsNullOrEmpty(status))
                sql.AppendLine(  " and mh.STATUS in ('" + status + "')");
            if (!string.IsNullOrEmpty(businessType))
                sql.AppendLine(" and mh.BUSINESS_TYPE='" + businessType + "'");

            sql.AppendLine(" order by mh.PRODUCE desc");
            DataTable dt;
            if (dbAccess.GetDataTable(sql.ToString(), out dt, out err))
            {
                return dt;
            }
            else
            {
                throw new Exception(err);
            }
        }
        /// <summary>
        /// 冲账时用.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="status"></param>
        /// <param name="businessCode"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool GetWantCreateOrReverseInfo(string status, string businessCode,bool isReverse, out DataTable dt, out string err)
        {
            sql = "select	"
                + "MESSAGE_HEADER_ID"
                + ",SY_SOURCE"
                + ",INT_ID"
                + ",SHIP_ID"
                + ",COMPANY_CODE"
                + ",PRODUCE"
                + ",QUANTITY"
                + ",OCCUR"
                + ",ACCOUNT"
                + ",PACKET_ID"
                + ",BUSINESS_CODE"
                + ",MESSAGE_TYPE"
                + ",BUSINESS_TYPE"
                + ",MESSAGE_ERROR"
                + ",STATUS"
                + ",case status "
                + "when '2' then '未通过映射'"
                + "when '3' then '待发送'"
                + "when '4' then '报文错误'"
                + "when '5' then '发送成功'"
                + "when '6' then '作废'"
                + "when '7' then 'SAP方法调用失败'"
                + "end as STATUS_NAME"
                + "  from T_MESSAGE_HEADER "
                + "  where 1=1 ";
            if(isReverse)
                sql+= "  and packet_id like '%-X'";
            else
                sql += "  and packet_id not like '%-X'";
            if (!string.IsNullOrEmpty(businessCode))
                sql += " and BUSINESS_CODE='" + businessCode + "'";
            if (!string.IsNullOrEmpty(status))
                sql += " and STATUS in ('" + status + "')";
            sql += " order by PRODUCE desc";
            return dbAccess.GetDataTable(sql, out dt, out err);
        }
        /// <summary>
        /// 作废时的事务.
        /// </summary>
        /// <param name="unit">MessageHeader对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnitTransaction(MessageHeader unit, out string err)
        {
            List<string> sqlList = new List<string>();
            if (unit.MESSAGE_HEADER_ID != null && unit.MESSAGE_HEADER_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_MESSAGE_HEADER] SET "
                    + " [MESSAGE_HEADER_ID] = " + (string.IsNullOrEmpty(unit.MESSAGE_HEADER_ID) ? "null" : "'" + unit.MESSAGE_HEADER_ID.Replace("'", "''") + "'")
                    + " , [SY_SOURCE] = " + (unit.SY_SOURCE == null ? "''" : "'" + unit.SY_SOURCE.Replace("'", "''") + "'")
                    + " , [INT_ID] = " + (string.IsNullOrEmpty(unit.INT_ID) ? "null" : "'" + unit.INT_ID.Replace("'", "''") + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , [COMPANY_CODE] = " + (unit.COMPANY_CODE == null ? "''" : "'" + unit.COMPANY_CODE.Replace("'", "''") + "'")
                    + " , [PRODUCE] = " + unit.PRODUCE.ToString()
                    + " , [QUANTITY] = " + unit.QUANTITY.ToString()
                    + " , [OCCUR] = " + unit.OCCUR.ToString()
                    + " , [ACCOUNT] = " + unit.ACCOUNT.ToString()
                    + " , [PACKET_ID] = " + (string.IsNullOrEmpty(unit.PACKET_ID) ? "null" : "'" + unit.PACKET_ID.Replace("'", "''") + "'")
                    + " , [BUSINESS_CODE] = " + (unit.BUSINESS_CODE == null ? "''" : "'" + unit.BUSINESS_CODE.Replace("'", "''") + "'")
                    + " , [MESSAGE_TYPE] = " + (unit.MESSAGE_TYPE == null ? "''" : "'" + unit.MESSAGE_TYPE.Replace("'", "''") + "'")
                    + " , [BUSINESS_TYPE] = " + (unit.BUSINESS_TYPE == null ? "''" : "'" + unit.BUSINESS_TYPE.Replace("'", "''") + "'")
                    + " , [MESSAGE_ERROR] = " + (unit.MESSAGE_ERROR == null ? "''" : "'" + unit.MESSAGE_ERROR.Replace("'", "''") + "'")
                    + " , [STATUS] = " + (unit.STATUS == null ? "''" : "'" + unit.STATUS.Replace("'", "''") + "'")
                    + " where upper(MESSAGE_HEADER_ID) = '" + unit.MESSAGE_HEADER_ID.ToUpper() + "'";
                sqlList.Add(sql);
            }
            else
            {
                unit.MESSAGE_HEADER_ID = Guid.NewGuid().ToString();
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
                    + " " + (string.IsNullOrEmpty(unit.MESSAGE_HEADER_ID) ? "null" : "'" + unit.MESSAGE_HEADER_ID.Replace("'", "''") + "'")
                    + " , " + (unit.SY_SOURCE == null ? "''" : "'" + unit.SY_SOURCE.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.INT_ID) ? "null" : "'" + unit.INT_ID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , " + (unit.COMPANY_CODE == null ? "''" : "'" + unit.COMPANY_CODE.Replace("'", "''") + "'")
                    + " ," + unit.PRODUCE.ToString()
                    + " ," + unit.QUANTITY.ToString()
                    + " ," + unit.OCCUR.ToString()
                    + " ," + unit.ACCOUNT.ToString()
                    + " , " + (string.IsNullOrEmpty(unit.PACKET_ID) ? "null" : "'" + unit.PACKET_ID.Replace("'", "''") + "'")
                    + " , " + (unit.BUSINESS_CODE == null ? "''" : "'" + unit.BUSINESS_CODE.Replace("'", "''") + "'")
                    + " , " + (unit.MESSAGE_TYPE == null ? "''" : "'" + unit.MESSAGE_TYPE.Replace("'", "''") + "'")
                    + " , " + (unit.BUSINESS_TYPE == null ? "''" : "'" + unit.BUSINESS_TYPE.Replace("'", "''") + "'")
                    + " , " + (unit.MESSAGE_ERROR == null ? "''" : "'" + unit.MESSAGE_ERROR.Replace("'", "''") + "'")
                    + " , " + (unit.STATUS == null ? "''" : "'" + unit.STATUS.Replace("'", "''") + "'")
                    + ")";
                sqlList.Add(sql);
            }
            return dbAccess.ExecSql(sqlList, out err);
        }
        /// <summary>
        /// 删除数据表T_MESSAGE_HEADER中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_MESSAGE_HEADER.mESSAGE_HEADER_ID主键</param>
        public List<string> DeleteDetailAndUnit(MessageHeader mh)
        {
            List<string> sqlList = new List<string>();
            if (mh.MESSAGE_TYPE == "1")
            {
                sqlList.Add("delete from T_PURCHASE_MESSAGE where upper(MESSAGE_HEADER_ID)='" + mh.MESSAGE_HEADER_ID.ToUpper() + "'");
            }
            else if (mh.MESSAGE_TYPE == "2")
            {
                sqlList.Add("delete from T_COST_MESSAGE where upper(MESSAGE_HEADER_ID)='" + mh.MESSAGE_HEADER_ID.ToUpper() + "'");
            }
            else if (mh.MESSAGE_TYPE == "3")
            {
                sqlList.Add("delete from T_OUTBOUND_MESSAGE where upper(MESSAGE_HEADER_ID)='" + mh.MESSAGE_HEADER_ID.ToUpper() + "'");
            }
            else if (mh.MESSAGE_TYPE == "4")
            {
                sqlList.Add("delete from T_INVEN_MESSAGE where upper(MESSAGE_HEADER_ID)='" + mh.MESSAGE_HEADER_ID.ToUpper() + "'");
            }
            sqlList.Add("delete from T_MESSAGE_HEADER where upper(MESSAGE_HEADER_ID)='" + mh.MESSAGE_HEADER_ID.ToUpper() + "'");
            return sqlList;
        }

        /// <summary>
        /// 获取客户化错误信息提示.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tableName"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string getCustomErrorInfo(string id, string tableName, out string err)
        {
            string result = "";
            err = "";
            string sql = "";
            sql += "\n declare @show_column_name  varchar(4000)";
            sql += "\n declare @field_name varchar(100)";
            sql += "\n select @show_column_name = A.show_column_name ,@field_name = B.field_name ";
            sql += "\n from dbo.T_TABLE_NAME A inner join dbo.T_TABLE_FIELD B on A.table_id = B.table_id";
            sql += "\n where  A.table_name = '" + tableName + "'";
            sql += "\n and B.field_type = 1";
            sql += "\n  exec('select ' + @show_column_name  + ' from T_MANUFACTURER where ' + @field_name + ' = ''" + id.ToUpper() + "''')";

            dbAccess.GetString(sql, out result, out err);
            if (string.IsNullOrEmpty(result))
            {
                result = id;
            }
            return result;
        }
    }
}
