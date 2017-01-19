/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：PurchaseMessageService.cs
 * 创 建 人：王鹏程
 * 创建时间：2012/3/16
 * 标    题：数据操作类
 * 功能描述：T_PURCHASE_MESSAGE数据操作类
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
    /// 数据层实例化接口类 dbo.T_PURCHASE_MESSAGEService.cs
    /// </summary>
    public partial class PurchaseMessageService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static PurchaseMessageService instance = new PurchaseMessageService();
        public static PurchaseMessageService Instance
        {
            get
            {
                if (null == instance)
                {
                    PurchaseMessageService.instance = new PurchaseMessageService();
                }
                return PurchaseMessageService.instance;
            }
        }
        private PurchaseMessageService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">PurchaseMessage对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(PurchaseMessage unit, out string err)
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
                    + " , [REBATE] = " + unit.REBATE.ToString()
                    + " , [ORDER_AMOUNT] = " + unit.ORDER_AMOUNT.ToString()
                    + " , [ACCOUNT_CODE] = " + (unit.ACCOUNT_CODE == null ? "''" : "'" + unit.ACCOUNT_CODE.Replace("'", "''") + "'")
                    + " , [ACCOUNT_NAME] = " + (unit.ACCOUNT_NAME == null ? "''" : "'" + unit.ACCOUNT_NAME.Replace("'", "''") + "'")
                    + " , [BUSINESS_CODE] = " + (unit.BUSINESS_CODE == null ? "''" : "'" + unit.BUSINESS_CODE.Replace("'", "''") + "'")
                    + " where upper(PURCHASE_MESSAGE_ID) = '" + unit.PURCHASE_MESSAGE_ID.ToUpper() + "'";
            }
            else
            {
                unit.PURCHASE_MESSAGE_ID = Guid.NewGuid().ToString();
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
                    + "[UUID],"
                    + "[REBATE],"
                    + "[ORDER_AMOUNT],"
                    + "[ACCOUNT_CODE],"
                    + "[ACCOUNT_NAME],"
                    + "[BUSINESS_CODE]"
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
                    + " ," + unit.REBATE.ToString()
                    + " ," + unit.ORDER_AMOUNT.ToString()
                    + " , " + (unit.ACCOUNT_CODE == null ? "''" : "'" + unit.ACCOUNT_CODE.Replace("'", "''") + "'")
                    + " , " + (unit.ACCOUNT_NAME == null ? "''" : "'" + unit.ACCOUNT_NAME.Replace("'", "''") + "'")
                    + " , " + (unit.BUSINESS_CODE == null ? "''" : "'" + unit.BUSINESS_CODE.Replace("'", "''") + "'")
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 向数据库中保存一条新记录。返回sql
        /// </summary>
        /// <param name="unit">PurchaseMessage对象</param>
        /// <returns>插入的对象更新</returns>	
        internal string saveUnit(PurchaseMessage unit)
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
                    + " , [REBATE] = " + unit.REBATE.ToString()
                    + " , [ORDER_AMOUNT] = " + unit.ORDER_AMOUNT.ToString()
                    + " , [ACCOUNT_CODE] = " + (unit.ACCOUNT_CODE == null ? "''" : "'" + unit.ACCOUNT_CODE.Replace("'", "''") + "'")
                    + " , [ACCOUNT_NAME] = " + (unit.ACCOUNT_NAME == null ? "''" : "'" + unit.ACCOUNT_NAME.Replace("'", "''") + "'")
                    + " , [BUSINESS_CODE] = " + (unit.BUSINESS_CODE == null ? "''" : "'" + unit.BUSINESS_CODE.Replace("'", "''") + "'")
                    + " where upper(PURCHASE_MESSAGE_ID) = '" + unit.PURCHASE_MESSAGE_ID.ToUpper() + "'";
            }
            else
            {
                unit.PURCHASE_MESSAGE_ID = Guid.NewGuid().ToString();
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
                    + "[UUID],"
                    + "[REBATE],"
                    + "[ORDER_AMOUNT],"
                    + "[ACCOUNT_CODE],"
                    + "[ACCOUNT_NAME],"
                    + "[BUSINESS_CODE]"
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
                    + " ," + unit.REBATE.ToString()
                    + " ," + unit.ORDER_AMOUNT.ToString()
                    + " , " + (unit.ACCOUNT_CODE == null ? "''" : "'" + unit.ACCOUNT_CODE.Replace("'", "''") + "'")
                    + " , " + (unit.ACCOUNT_NAME == null ? "''" : "'" + unit.ACCOUNT_NAME.Replace("'", "''") + "'")
                    + " , " + (unit.BUSINESS_CODE == null ? "''" : "'" + unit.BUSINESS_CODE.Replace("'", "''") + "'")
                    + ")";
            }

            return sql;
        }
        /// <summary>
        /// 删除数据表T_PURCHASE_MESSAGE中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_PURCHASE_MESSAGE对象</param>
        internal bool deleteUnit(PurchaseMessage unit, out string err)
        {
            return deleteUnit(unit.PURCHASE_MESSAGE_ID, out err);
        }

        /// <summary>
        /// 删除数据表T_PURCHASE_MESSAGE中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_PURCHASE_MESSAGE.pURCHASE_MESSAGE_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_PURCHASE_MESSAGE where "
                + " upper(T_PURCHASE_MESSAGE.PURCHASE_MESSAGE_ID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_PURCHASE_MESSAGE 所有数据信息.
        /// </summary>
        /// <returns>T_PURCHASE_MESSAGE DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "PURCHASE_MESSAGE_ID"
                + ",MESSAGE_HEADER_ID"
                + ",LINENUM"
                + ",MATERIAL"
                + ",MATERIAL_MAPPING"
                + ",QUANTITY"
                + ",CURRENCY"
                + ",AMOUNT"
                + ",SUBJECT_MAPPING"
                + ",SHIP_ID"
                + ",SHIP_MAPPING"
                + ",INPUT_OUTPUT"
                + ",SUPPLIER"
                + ",SUPPLIER_MAPPING"
                + ",INPUT_ORDER"
                + ",INPUT_OREER_ITEM"
                + ",UUID"
                + ",REBATE"
                + ",ORDER_AMOUNT"
                + ",ACCOUNT_CODE"
                + ",ACCOUNT_NAME"
                + ",BUSINESS_CODE"
                + "  from T_PURCHASE_MESSAGE ";
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
        /// 根据一个主键ID,得到 T_PURCHASE_MESSAGE 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>PurchaseMessage DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "PURCHASE_MESSAGE_ID"
                + ",MESSAGE_HEADER_ID"
                + ",LINENUM"
                + ",MATERIAL"
                + ",MATERIAL_MAPPING"
                + ",QUANTITY"
                + ",CURRENCY"
                + ",AMOUNT"
                + ",SUBJECT_MAPPING"
                + ",SHIP_ID"
                + ",SHIP_MAPPING"
                + ",INPUT_OUTPUT"
                + ",SUPPLIER"
                + ",SUPPLIER_MAPPING"
                + ",INPUT_ORDER"
                + ",INPUT_OREER_ITEM"
                + ",UUID"
                + ",REBATE"
                + ",ORDER_AMOUNT"
                + ",ACCOUNT_CODE"
                + ",ACCOUNT_NAME"
                + ",BUSINESS_CODE"
                + " from T_PURCHASE_MESSAGE "
                + " where upper(PURCHASE_MESSAGE_ID)='" + Id.ToUpper() + "'";
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
        /// 根据purchasemessage 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>purchasemessage 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
        public PurchaseMessage getObject(DataRow dr)
        {
            PurchaseMessage unit = new PurchaseMessage();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造PurchaseMessage类对象!";
                return unit;
            }
            if (DBNull.Value != dr["PURCHASE_MESSAGE_ID"])
                unit.PURCHASE_MESSAGE_ID = dr["PURCHASE_MESSAGE_ID"].ToString();
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
            if (DBNull.Value != dr["CURRENCY"])
                unit.CURRENCY = dr["CURRENCY"].ToString();
            if (DBNull.Value != dr["AMOUNT"])
                unit.AMOUNT = Convert.ToDecimal(dr["AMOUNT"]);
            if (DBNull.Value != dr["SUBJECT_MAPPING"])
                unit.SUBJECT_MAPPING = dr["SUBJECT_MAPPING"].ToString();
            if (DBNull.Value != dr["SHIP_ID"])
                unit.SHIP_ID = dr["SHIP_ID"].ToString();
            if (DBNull.Value != dr["SHIP_MAPPING"])
                unit.SHIP_MAPPING = dr["SHIP_MAPPING"].ToString();
            if (DBNull.Value != dr["INPUT_OUTPUT"])
                unit.INPUT_OUTPUT = dr["INPUT_OUTPUT"].ToString();
            if (DBNull.Value != dr["SUPPLIER"])
                unit.SUPPLIER = dr["SUPPLIER"].ToString();
            if (DBNull.Value != dr["SUPPLIER_MAPPING"])
                unit.SUPPLIER_MAPPING = dr["SUPPLIER_MAPPING"].ToString();
            if (DBNull.Value != dr["INPUT_ORDER"])
                unit.INPUT_ORDER = dr["INPUT_ORDER"].ToString();
            if (DBNull.Value != dr["INPUT_OREER_ITEM"])
                unit.INPUT_OREER_ITEM = Convert.ToDecimal(dr["INPUT_OREER_ITEM"]);
            if (DBNull.Value != dr["UUID"])
                unit.UUID = dr["UUID"].ToString();
            if (DBNull.Value != dr["REBATE"])
                unit.REBATE = Convert.ToDecimal(dr["REBATE"]);
            if (DBNull.Value != dr["ORDER_AMOUNT"])
                unit.ORDER_AMOUNT = Convert.ToDecimal(dr["ORDER_AMOUNT"]);
            if (DBNull.Value != dr["ACCOUNT_CODE"])
                unit.ACCOUNT_CODE = dr["ACCOUNT_CODE"].ToString();
            if (DBNull.Value != dr["ACCOUNT_NAME"])
                unit.ACCOUNT_NAME = dr["ACCOUNT_NAME"].ToString();
            if (DBNull.Value != dr["BUSINESS_CODE"])
                unit.BUSINESS_CODE = dr["BUSINESS_CODE"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个PurchaseMessage对象.
        /// </summary>
        /// <param name="pURCHASE_MESSAGE_ID">pURCHASE_MESSAGE_ID</param>
        /// <returns>PurchaseMessage对象</returns>
        public PurchaseMessage getObject(string Id, out string err)
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
