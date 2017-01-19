﻿/****************************************************************************************************
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
    /// <summary>
    /// 数据层实例化接口类 dbo.T_OUTBOUND_MESSAGEService.cs
    /// </summary>
    public partial class OutboundMessageService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static OutboundMessageService instance = new OutboundMessageService();
        public static OutboundMessageService Instance
        {
            get
            {
                if (null == instance)
                {
                    OutboundMessageService.instance = new OutboundMessageService();
                }
                return OutboundMessageService.instance;
            }
        }
        private OutboundMessageService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">OutboundMessage对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(OutboundMessage unit, out string err)
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
            }
            else
            {
                unit.OUTBOUND_MESSAGE_ID = Guid.NewGuid().ToString();
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
            }

            return dbAccess.ExecSql(sql, out err);
        }
       
        /// <summary>
        /// 删除数据表T_OUTBOUND_MESSAGE中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_OUTBOUND_MESSAGE对象</param>
        internal bool deleteUnit(OutboundMessage unit, out string err)
        {
            return deleteUnit(unit.OUTBOUND_MESSAGE_ID, out err);
        }

        /// <summary>
        /// 删除数据表T_OUTBOUND_MESSAGE中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_OUTBOUND_MESSAGE.oUTBOUND_MESSAGE_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_OUTBOUND_MESSAGE where "
                + " upper(T_OUTBOUND_MESSAGE.OUTBOUND_MESSAGE_ID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_OUTBOUND_MESSAGE 所有数据信息.
        /// </summary>
        /// <returns>T_OUTBOUND_MESSAGE DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "OUTBOUND_MESSAGE_ID"
                + ",MESSAGE_HEADER_ID"
                + ",LINENUM"
                + ",MATERIAL"
                + ",MATERIAL_MAPPING"
                + ",QUANTITY"
                + ",SHIP_ID"
                + ",SHIP_MAPPING"
                + ",INPUT_OUTPUT"
                + ",UUID"
                + "  from T_OUTBOUND_MESSAGE ";
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
        /// 根据一个主键ID,得到 T_OUTBOUND_MESSAGE 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>OutboundMessage DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "OUTBOUND_MESSAGE_ID"
                + ",MESSAGE_HEADER_ID"
                + ",LINENUM"
                + ",MATERIAL"
                + ",MATERIAL_MAPPING"
                + ",QUANTITY"
                + ",SHIP_ID"
                + ",SHIP_MAPPING"
                + ",INPUT_OUTPUT"
                + ",UUID"
                + " from T_OUTBOUND_MESSAGE "
                + " where upper(OUTBOUND_MESSAGE_ID)='" + Id.ToUpper() + "'";
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
        /// 根据outboundmessage 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>outboundmessage 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
        public OutboundMessage getObject(DataRow dr)
        {
            OutboundMessage unit = new OutboundMessage();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造OutBoundMessage类对象!";
                return unit;
            }
            if (DBNull.Value != dr["OUTBOUND_MESSAGE_ID"])
                unit.OUTBOUND_MESSAGE_ID = dr["OUTBOUND_MESSAGE_ID"].ToString();
            if (DBNull.Value != dr["MESSAGE_HEADER_ID"])
                unit.MESSAGE_HEADER_ID = dr["MESSAGE_HEADER_ID"].ToString();
            if (DBNull.Value != dr["LINENUM"])
                unit.LINENUM = Convert.ToInt32(dr["LINENUM"]);
            if (DBNull.Value != dr["MATERIAL"])
                unit.MATERIAL = dr["MATERIAL"].ToString();
            if (DBNull.Value != dr["MATERIAL_MAPPING"])
                unit.MATERIAL_MAPPING = dr["MATERIAL_MAPPING"].ToString();
            if (DBNull.Value != dr["QUANTITY"])
                unit.QUANTITY = Convert.ToDecimal(dr["QUANTITY"]);
            if (DBNull.Value != dr["SHIP_ID"])
                unit.SHIP_ID = dr["SHIP_ID"].ToString();
            if (DBNull.Value != dr["SHIP_MAPPING"])
                unit.SHIP_MAPPING = dr["SHIP_MAPPING"].ToString();
            if (DBNull.Value != dr["INPUT_OUTPUT"])
                unit.INPUT_OUTPUT = dr["INPUT_OUTPUT"].ToString();
            if (DBNull.Value != dr["UUID"])
                unit.UUID = dr["UUID"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个OutboundMessage对象.
        /// </summary>
        /// <param name="oUTBOUND_MESSAGE_ID">oUTBOUND_MESSAGE_ID</param>
        /// <returns>OutboundMessage对象</returns>
        public OutboundMessage getObject(string Id, out string err)
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
