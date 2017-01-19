/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：VOUCHERService.cs
 * 创 建 人：王鹏程
 * 创建时间：2012/3/22
 * 标    题：数据操作类
 * 功能描述：T_COST_VOUCHER数据操作类
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
using Cost.DataObject;

namespace Cost.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_COST_VOUCHERService.cs
    /// </summary>
    public partial class VOUCHERService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static VOUCHERService instance = new VOUCHERService();
        public static VOUCHERService Instance
        {
            get
            {
                if (null == instance)
                {
                    VOUCHERService.instance = new VOUCHERService();
                }
                return VOUCHERService.instance;
            }
        }
        private VOUCHERService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">VOUCHER对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(VOUCHER unit, out string err)
        {
            return dbAccess.ExecSql(saveUnit(unit), out err);
        }
        /// <summary>
        /// 返回向数据库中保存一条新记录的sql语句。做事务用。.
        /// </summary>
        /// <param name="unit">VOUCHER对象</param>
        /// <returns>插入的对象更新</returns>	
        internal string saveUnit(VOUCHER unit)
        {
            if (unit.VOUCHER_ID != null && unit.VOUCHER_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_COST_VOUCHER] SET "
                    + " [VOUCHER_ID] = " + (string.IsNullOrEmpty(unit.VOUCHER_ID) ? "null" : "'" + unit.VOUCHER_ID.Replace("'", "''") + "'")
                    + " , [BUDGET_ID] = " + (string.IsNullOrEmpty(unit.BUDGET_ID) ? "null" : "'" + unit.BUDGET_ID.Replace("'", "''") + "'")
                    + " , [VOUCHER_NUM] = " + (unit.VOUCHER_NUM == null ? "''" : "'" + unit.VOUCHER_NUM.Replace("'", "''") + "'")
                    + " , [APPLY_COMPANY] = " + (unit.APPLY_COMPANY == null ? "''" : "'" + unit.APPLY_COMPANY.Replace("'", "''") + "'")
                    + " , [VOUCHER_DATE] = " + dbOperation.DbToDate(unit.VOUCHER_DATE)
                    + " , [SHIP_OWNER] = " + (unit.SHIP_OWNER == null ? "''" : "'" + unit.SHIP_OWNER.Replace("'", "''") + "'")
                    + " , [CURRENCY_ID] = " + (string.IsNullOrEmpty(unit.CURRENCY_ID) ? "null" : "'" + unit.CURRENCY_ID.Replace("'", "''") + "'")
                    + " , [AMOUNT_UP] = " + (unit.AMOUNT_UP == null ? "''" : "'" + unit.AMOUNT_UP.Replace("'", "''") + "'")
                    + " , [AMOUNT_LOW] = " + (unit.AMOUNT_LOW == null ? "''" : "'" + unit.AMOUNT_LOW.Replace("'", "''") + "'")
                    + " , [PAYEE] = " + (unit.PAYEE == null ? "''" : "'" + unit.PAYEE.Replace("'", "''") + "'")
                    + " , [INVOICE_NUM] = " + unit.INVOICE_NUM.ToString()
                    + " , [APPLICANT] = " + (unit.APPLICANT == null ? "''" : "'" + unit.APPLICANT.Replace("'", "''") + "'")
                    + " , [APPROVER] = " + (unit.APPROVER == null ? "''" : "'" + unit.APPROVER.Replace("'", "''") + "'")
                    + " , [APPROVER2] = " + (unit.APPROVER2 == null ? "''" : "'" + unit.APPROVER2.Replace("'", "''") + "'")
                    + " , [CURRENT_STATE] = " + unit.CURRENT_STATE.ToString()
                    + " , [BUSINESS_CODE] = " + (unit.BUSINESS_CODE == null ? "''" : "'" + unit.BUSINESS_CODE.Replace("'", "''") + "'")
                    + " where upper(VOUCHER_ID) = '" + unit.VOUCHER_ID.ToUpper() + "'";
            }
            else
            {
                unit.VOUCHER_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_COST_VOUCHER] ("
                    + "[VOUCHER_ID],"
                    + "[BUDGET_ID],"
                    + "[VOUCHER_NUM],"
                    + "[APPLY_COMPANY],"
                    + "[VOUCHER_DATE],"
                    + "[SHIP_OWNER],"
                    + "[CURRENCY_ID],"
                    + "[AMOUNT_UP],"
                    + "[AMOUNT_LOW],"
                    + "[PAYEE],"
                    + "[INVOICE_NUM],"
                    + "[APPLICANT],"
                    + "[APPROVER],"
                    + "[APPROVER2],"
                    + "[CURRENT_STATE],"
                    + "[BUSINESS_CODE]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.VOUCHER_ID) ? "null" : "'" + unit.VOUCHER_ID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.BUDGET_ID) ? "null" : "'" + unit.BUDGET_ID.Replace("'", "''") + "'")
                    + " , " + (unit.VOUCHER_NUM == null ? "''" : "'" + unit.VOUCHER_NUM.Replace("'", "''") + "'")
                    + " , " + (unit.APPLY_COMPANY == null ? "''" : "'" + unit.APPLY_COMPANY.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.VOUCHER_DATE)
                    + " , " + (unit.SHIP_OWNER == null ? "''" : "'" + unit.SHIP_OWNER.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.CURRENCY_ID) ? "null" : "'" + unit.CURRENCY_ID.Replace("'", "''") + "'")
                    + " , " + (unit.AMOUNT_UP == null ? "''" : "'" + unit.AMOUNT_UP.Replace("'", "''") + "'")
                    + " , " + (unit.AMOUNT_LOW == null ? "''" : "'" + unit.AMOUNT_LOW.Replace("'", "''") + "'")
                    + " , " + (unit.PAYEE == null ? "''" : "'" + unit.PAYEE.Replace("'", "''") + "'")
                    + " ," + unit.INVOICE_NUM.ToString()
                    + " , " + (unit.APPLICANT == null ? "''" : "'" + unit.APPLICANT.Replace("'", "''") + "'")
                    + " , " + (unit.APPROVER == null ? "''" : "'" + unit.APPROVER.Replace("'", "''") + "'")
                    + " , " + (unit.APPROVER2 == null ? "''" : "'" + unit.APPROVER2.Replace("'", "''") + "'")
                    + " ," + unit.CURRENT_STATE.ToString()
                    + " , " + (unit.BUSINESS_CODE == null ? "''" : "'" + unit.BUSINESS_CODE.Replace("'", "''") + "'")
                    + ")";
            }

            return sql;
        }
        /// <summary>
        /// 删除数据表T_COST_VOUCHER中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_COST_VOUCHER对象</param>
        internal bool deleteUnit(VOUCHER unit, out string err)
        {
            return deleteUnit(unit.VOUCHER_ID, out err);
        }

        /// <summary>
        /// 删除数据表T_COST_VOUCHER中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_COST_VOUCHER.vOUCHER_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_COST_VOUCHER where "
                + " upper(T_COST_VOUCHER.VOUCHER_ID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_COST_VOUCHER 所有数据信息.
        /// </summary>
        /// <returns>T_COST_VOUCHER DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "VOUCHER_ID"
                + ",BUDGET_ID"
                + ",VOUCHER_NUM"
                + ",APPLY_COMPANY"
                + ",VOUCHER_DATE"
                + ",SHIP_OWNER"
                + ",CURRENCY_ID"
                + ",AMOUNT_UP"
                + ",AMOUNT_LOW"
                + ",PAYEE"
                + ",INVOICE_NUM"
                + ",APPLICANT"
                + ",APPROVER"
                + ",APPROVER2"
                + ",CURRENT_STATE"
                + ",BUSINESS_CODE"
                + "  from T_COST_VOUCHER ";
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
        /// 根据一个主键ID,得到 T_COST_VOUCHER 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>VOUCHER DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "VOUCHER_ID"
                + ",BUDGET_ID"
                + ",VOUCHER_NUM"
                + ",APPLY_COMPANY"
                + ",VOUCHER_DATE"
                + ",SHIP_OWNER"
                + ",CURRENCY_ID"
                + ",AMOUNT_UP"
                + ",AMOUNT_LOW"
                + ",PAYEE"
                + ",INVOICE_NUM"
                + ",APPLICANT"
                + ",APPROVER"
                + ",APPROVER2"
                + ",CURRENT_STATE"
                + ",BUSINESS_CODE"
                + " from T_COST_VOUCHER "
                + " where upper(VOUCHER_ID)='" + Id.ToUpper() + "'";
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
        /// 根据voucher 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>voucher 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
        public VOUCHER getObject(DataRow dr)
        {
            VOUCHER unit = new VOUCHER();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造VOUCHER类对象!";
                return unit;
            }
            if (DBNull.Value != dr["VOUCHER_ID"])
                unit.VOUCHER_ID = dr["VOUCHER_ID"].ToString();
            if (DBNull.Value != dr["BUDGET_ID"])
                unit.BUDGET_ID = dr["BUDGET_ID"].ToString();
            if (DBNull.Value != dr["VOUCHER_NUM"])
                unit.VOUCHER_NUM = dr["VOUCHER_NUM"].ToString();
            if (DBNull.Value != dr["APPLY_COMPANY"])
                unit.APPLY_COMPANY = dr["APPLY_COMPANY"].ToString();
            if (DBNull.Value != dr["VOUCHER_DATE"])
                unit.VOUCHER_DATE = (DateTime)dr["VOUCHER_DATE"];
            if (DBNull.Value != dr["SHIP_OWNER"])
                unit.SHIP_OWNER = dr["SHIP_OWNER"].ToString();
            if (DBNull.Value != dr["CURRENCY_ID"])
                unit.CURRENCY_ID = dr["CURRENCY_ID"].ToString();
            if (DBNull.Value != dr["AMOUNT_UP"])
                unit.AMOUNT_UP = dr["AMOUNT_UP"].ToString();
            if (DBNull.Value != dr["AMOUNT_LOW"])
                unit.AMOUNT_LOW = dr["AMOUNT_LOW"].ToString();
            if (DBNull.Value != dr["PAYEE"])
                unit.PAYEE = dr["PAYEE"].ToString();
            if (DBNull.Value != dr["INVOICE_NUM"])
                unit.INVOICE_NUM = Convert.ToInt32(dr["INVOICE_NUM"]);
            if (DBNull.Value != dr["APPLICANT"])
                unit.APPLICANT = dr["APPLICANT"].ToString();
            if (DBNull.Value != dr["APPROVER"])
                unit.APPROVER = dr["APPROVER"].ToString();
            if (DBNull.Value != dr["APPROVER2"])
                unit.APPROVER2 = dr["APPROVER2"].ToString();
            if (DBNull.Value != dr["CURRENT_STATE"])
                unit.CURRENT_STATE = Convert.ToInt32(dr["CURRENT_STATE"]);
            if (DBNull.Value != dr["BUSINESS_CODE"])
                unit.BUSINESS_CODE = dr["BUSINESS_CODE"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个VOUCHER对象.
        /// </summary>
        /// <param name="vOUCHER_ID">vOUCHER_ID</param>
        /// <returns>VOUCHER对象</returns>
        public VOUCHER getObject(string Id, out string err)
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
