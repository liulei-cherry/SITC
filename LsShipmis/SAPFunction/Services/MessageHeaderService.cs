/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：MessageHeaderService.cs
 * 创 建 人：王鹏程
 * 创建时间：2012/3/28
 * 标    题：数据操作类
 * 功能描述：T_MESSAGE_HEADER数据操作类
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
using SAPFunction.DataObject;

namespace SAPFunction.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_MESSAGE_HEADERService.cs
    /// </summary>
    public partial class MessageHeaderService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static MessageHeaderService instance = new MessageHeaderService();
        public static MessageHeaderService Instance
        {
            get
            {
                if (null == instance)
                {
                    MessageHeaderService.instance = new MessageHeaderService();
                }
                return MessageHeaderService.instance;
            }
        }
        private MessageHeaderService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">MessageHeader对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(MessageHeader unit, out string err)
        {
            return dbAccess.ExecSql(saveUnit(unit), out err);
        }
        /// <summary>
        /// 返回向数据库中保存一条新记录的sql语句。做事务用。.
        /// </summary>
        /// <param name="unit">MessageHeader对象</param>
        /// <returns>插入的对象更新</returns>	
        internal string saveUnit(MessageHeader unit)
        {
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
            }

            return sql;
        }
        /// <summary>
        /// 删除数据表T_MESSAGE_HEADER中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_MESSAGE_HEADER对象</param>
        internal bool deleteUnit(MessageHeader unit, out string err)
        {
            return deleteUnit(unit.MESSAGE_HEADER_ID, out err);
        }

        /// <summary>
        /// 删除数据表T_MESSAGE_HEADER中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_MESSAGE_HEADER.mESSAGE_HEADER_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_MESSAGE_HEADER where "
                + " upper(T_MESSAGE_HEADER.MESSAGE_HEADER_ID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_MESSAGE_HEADER 所有数据信息.
        /// </summary>
        /// <returns>T_MESSAGE_HEADER DataTable</returns>
        public DataTable getInfo(out string err)
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
                + "  from T_MESSAGE_HEADER ";
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
        /// 根据一个主键ID,得到 T_MESSAGE_HEADER 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>MessageHeader DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
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
                + " from T_MESSAGE_HEADER "
                + " where upper(MESSAGE_HEADER_ID)='" + Id.ToUpper() + "'";
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
        /// 根据messageheader 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>messageheader 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
        public MessageHeader getObject(DataRow dr)
        {
            MessageHeader unit = new MessageHeader();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造MessageHeader类对象!";
                return unit;
            }
            if (DBNull.Value != dr["MESSAGE_HEADER_ID"])
                unit.MESSAGE_HEADER_ID = dr["MESSAGE_HEADER_ID"].ToString();
            if (DBNull.Value != dr["SY_SOURCE"])
                unit.SY_SOURCE = dr["SY_SOURCE"].ToString();
            if (DBNull.Value != dr["INT_ID"])
                unit.INT_ID = dr["INT_ID"].ToString();
            if (DBNull.Value != dr["SHIP_ID"])
                unit.SHIP_ID = dr["SHIP_ID"].ToString();
            if (DBNull.Value != dr["COMPANY_CODE"])
                unit.COMPANY_CODE = dr["COMPANY_CODE"].ToString();
            if (DBNull.Value != dr["PRODUCE"])
                unit.PRODUCE = Convert.ToDecimal(dr["PRODUCE"]);
            if (DBNull.Value != dr["QUANTITY"])
                unit.QUANTITY = Convert.ToInt32(dr["QUANTITY"]);
            if (DBNull.Value != dr["OCCUR"])
                unit.OCCUR = Convert.ToDecimal(dr["OCCUR"]);
            if (DBNull.Value != dr["ACCOUNT"])
                unit.ACCOUNT = Convert.ToDecimal(dr["ACCOUNT"]);
            if (DBNull.Value != dr["PACKET_ID"])
                unit.PACKET_ID = dr["PACKET_ID"].ToString();
            if (DBNull.Value != dr["BUSINESS_CODE"])
                unit.BUSINESS_CODE = dr["BUSINESS_CODE"].ToString();
            if (DBNull.Value != dr["MESSAGE_TYPE"])
                unit.MESSAGE_TYPE = dr["MESSAGE_TYPE"].ToString();
            if (DBNull.Value != dr["BUSINESS_TYPE"])
                unit.BUSINESS_TYPE = dr["BUSINESS_TYPE"].ToString();
            if (DBNull.Value != dr["MESSAGE_ERROR"])
                unit.MESSAGE_ERROR = dr["MESSAGE_ERROR"].ToString();
            if (DBNull.Value != dr["STATUS"])
                unit.STATUS = dr["STATUS"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个MessageHeader对象.
        /// </summary>
        /// <param name="mESSAGE_HEADER_ID">mESSAGE_HEADER_ID</param>
        /// <returns>MessageHeader对象</returns>
        public MessageHeader getObject(string Id, out string err)
        {
            err = "";
            try
            {
                DataTable dt = getInfo(Id, out err);
                return getObject(dt.Rows[0]);
            }
            catch
            {
                return getObject(null);
            }
        }
        #endregion
    }
}
