/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：ACTUAL_COSTSService.cs
 * 创 建 人：王鹏程
 * 创建时间：2012/3/21
 * 标    题：数据操作类
 * 功能描述：T_COST_ACTUAL_COSTS数据操作类
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
    /// 数据层实例化接口类 dbo.T_COST_ACTUAL_COSTSService.cs
    /// </summary>
    public partial class ACTUAL_COSTSService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static ACTUAL_COSTSService instance = new ACTUAL_COSTSService();
        public static ACTUAL_COSTSService Instance
        {
            get
            {
                if (null == instance)
                {
                    ACTUAL_COSTSService.instance = new ACTUAL_COSTSService();
                }
                return ACTUAL_COSTSService.instance;
            }
        }
        private ACTUAL_COSTSService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">ACTUAL_COSTS对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(ACTUAL_COSTS unit, out string err)
        {
            List<string> sqls = new List<string>();
            sqls.Add(saveUnit(unit));
            sql = string.Format(@"update t_file_manage
set SHIP_ID = '{0}'
from T_FOLDER t1 inner join T_FILE_REF t2 on t1.NODE_ID = t2.NODE_ID
inner join T_FILE_MANAGE t3 on t2.FILE_ID = t3.FILE_ID
where t3.SHIP_ID <> '{0}' and t1.NODE_TYPE = {2}  and t1.NODE_ID = '{1}'",
                                 unit.SHIP_ID, unit.COSTS_ID, ((int)CommonOperation.Enum.FileBoundingTypes.VOUCHERFILES).ToString ());
            sqls.Add(sql);

            if (!string.IsNullOrEmpty(unit.VOUCHER_ID))
            {
                sql = string.Format (@"Update T_COST_VOUCHER
   SET [SHIP_OWNER] = (select ship_name from t_ship where ship_id = '{0}')
      ,[PAYEE] = '{1}'
      ,[INVOICE_NUM] = 0
      ,[APPLICANT] = '{3}'
      ,[APPROVER] = '{4}'
      ,[APPROVER2] = '{5}' 
      ,[CURRENT_STATE] = 3
 WHERE VOUCHER_ID = '{6}'",unit.SHIP_ID ,unit.CUSTOMER,unit.INVOICE_NUM,unit.APPLICANT,unit.APPROVER,unit.APPROVER2,unit.VOUCHER_ID);
                sqls.Add(sql);
            }
            return dbAccess.ExecSql(sqls, out err);
        }
        /// <summary>
        /// 返回向数据库中保存一条新记录的sql语句。做事务用。.
        /// </summary>
        /// <param name="unit">ACTUAL_COSTS对象</param>
        /// <returns>插入的对象更新</returns>	
        internal string saveUnit(ACTUAL_COSTS unit)
        {
            if (unit.COSTS_ID != null && unit.COSTS_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_COST_ACTUAL_COSTS] SET "
                    + " [COSTS_ID] = " + (string.IsNullOrEmpty(unit.COSTS_ID) ? "null" : "'" + unit.COSTS_ID.Replace("'", "''") + "'")
                    + " , [CUSTOMER] = " + (unit.CUSTOMER == null ? "''" : "'" + unit.CUSTOMER.Replace("'", "''") + "'")
                    + " , [DESCRIPTION] = " + (unit.DESCRIPTION == null ? "''" : "'" + unit.DESCRIPTION.Replace("'", "''") + "'")
                    + " , [ESTIMATE_AMOUNT] = " + unit.ESTIMATE_AMOUNT.ToString()
                    + " , [AMOUNT] = " + unit.AMOUNT.ToString()
                    + " , [CURRENCY_ID] = " + (string.IsNullOrEmpty(unit.CURRENCY_ID) ? "null" : "'" + unit.CURRENCY_ID.Replace("'", "''") + "'")
                    + " , [CONVERT_MONEY] = " + unit.CONVERT_MONEY.ToString()
                    + " , [CONTRACT_NUM] = " + (unit.CONTRACT_NUM == null ? "''" : "'" + unit.CONTRACT_NUM.Replace("'", "''") + "'")
                    + " , [NODE_ID] = " + (string.IsNullOrEmpty(unit.NODE_ID) ? "null" : "'" + unit.NODE_ID.Replace("'", "''") + "'")
                    + " , [VOUCHER_ID] = " + (string.IsNullOrEmpty(unit.VOUCHER_ID) ? "null" : "'" + unit.VOUCHER_ID.Replace("'", "''") + "'")
                    + " , [OCCURENCY_DATE] = " + dbOperation.DbToDate(unit.OCCURENCY_DATE)
                    + " , [COMPLETE_DATE] = " + dbOperation.DbToDate(unit.COMPLETE_DATE)
                    + " , [COMPLETE_PALCE] = " + (unit.COMPLETE_PALCE == null ? "''" : "'" + unit.COMPLETE_PALCE.Replace("'", "''") + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , [REMARK] = " + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
                    + " , [APPLICANT] = " + (unit.APPLICANT == null ? "''" : "'" + unit.APPLICANT.Replace("'", "''") + "'")
                    + " , [APPROVER] = " + (unit.APPROVER == null ? "''" : "'" + unit.APPROVER.Replace("'", "''") + "'")
                    + " , [APPROVER2] = " + (unit.APPROVER2 == null ? "''" : "'" + unit.APPROVER2.Replace("'", "''") + "'")
                    + " , [PAYMENT_DATE] = " + dbOperation.DbToDate(unit.PAYMENT_DATE)
                    + " , [INVOICE_DATE] = " + dbOperation.DbToDate(unit.INVOICE_DATE)
                    + " , [INVOICE_NUM] = " + (unit.INVOICE_NUM == null ? "''" : "'" + unit.INVOICE_NUM.Replace("'", "''") + "'")
                    + " , [SENDED] = " + unit.SENDED.ToString()
                    + " where upper(COSTS_ID) = '" + unit.COSTS_ID.ToUpper() + "'";
            }
            else
            {
                unit.COSTS_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_COST_ACTUAL_COSTS] ("
                    + "[COSTS_ID],"
                    + "[CUSTOMER],"
                    + "[DESCRIPTION],"
                    + "[ESTIMATE_AMOUNT],"
                    + "[AMOUNT],"
                    + "[CURRENCY_ID],"
                    + "[CONVERT_MONEY],"
                    + "[CONTRACT_NUM],"
                    + "[NODE_ID],"
                    + "[VOUCHER_ID],"
                    + "[OCCURENCY_DATE],"
                    + "[COMPLETE_DATE],"
                    + "[COMPLETE_PALCE],"
                    + "[SHIP_ID],"
                    + "[REMARK],"
                    + "[APPLICANT],"
                    + "[APPROVER],"
                    + "[APPROVER2],"
                    + "[PAYMENT_DATE],"
                    + "[INVOICE_DATE],"
                    + "[INVOICE_NUM],"
                    + "[SENDED]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.COSTS_ID) ? "null" : "'" + unit.COSTS_ID.Replace("'", "''") + "'")
                    + " , " + (unit.CUSTOMER == null ? "''" : "'" + unit.CUSTOMER.Replace("'", "''") + "'")
                    + " , " + (unit.DESCRIPTION == null ? "''" : "'" + unit.DESCRIPTION.Replace("'", "''") + "'")
                    + " ," + unit.ESTIMATE_AMOUNT.ToString()
                    + " ," + unit.AMOUNT.ToString()
                    + " , " + (string.IsNullOrEmpty(unit.CURRENCY_ID) ? "null" : "'" + unit.CURRENCY_ID.Replace("'", "''") + "'")
                    + " ," + unit.CONVERT_MONEY.ToString()
                    + " , " + (unit.CONTRACT_NUM == null ? "''" : "'" + unit.CONTRACT_NUM.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.NODE_ID) ? "null" : "'" + unit.NODE_ID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.VOUCHER_ID) ? "null" : "'" + unit.VOUCHER_ID.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.OCCURENCY_DATE)
                    + " ," + dbOperation.DbToDate(unit.COMPLETE_DATE)
                    + " , " + (unit.COMPLETE_PALCE == null ? "''" : "'" + unit.COMPLETE_PALCE.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , " + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
                    + " , " + (unit.APPLICANT == null ? "''" : "'" + unit.APPLICANT.Replace("'", "''") + "'")
                    + " , " + (unit.APPROVER == null ? "''" : "'" + unit.APPROVER.Replace("'", "''") + "'")
                    + " , " + (unit.APPROVER2 == null ? "''" : "'" + unit.APPROVER2.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.PAYMENT_DATE)
                    + " ," + dbOperation.DbToDate(unit.INVOICE_DATE)
                    + " , " + (unit.INVOICE_NUM == null ? "''" : "'" + unit.INVOICE_NUM.Replace("'", "''") + "'")
                    + " ," + unit.SENDED.ToString()
                    + ")";
            }

            return sql;
        }
        /// <summary>
        /// 删除数据表T_COST_ACTUAL_COSTS中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_COST_ACTUAL_COSTS对象</param>
        internal bool deleteUnit(ACTUAL_COSTS unit, out string err)
        {
            return deleteUnit(unit.COSTS_ID, out err);
        }

        /// <summary>
        /// 删除数据表T_COST_ACTUAL_COSTS中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_COST_ACTUAL_COSTS.cOSTS_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_COST_ACTUAL_COSTS where "
                + " upper(T_COST_ACTUAL_COSTS.COSTS_ID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_COST_ACTUAL_COSTS 所有数据信息.
        /// </summary>
        /// <returns>T_COST_ACTUAL_COSTS DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "COSTS_ID"
                + ",CUSTOMER"
                + ",DESCRIPTION"
                + ",ESTIMATE_AMOUNT"
                + ",AMOUNT"
                + ",CURRENCY_ID"
                + ",CONVERT_MONEY"
                + ",CONTRACT_NUM"
                + ",NODE_ID"
                + ",VOUCHER_ID"
                + ",OCCURENCY_DATE"
                + ",COMPLETE_DATE"
                + ",COMPLETE_PALCE"
                + ",SHIP_ID"
                + ",REMARK"
                + ",APPLICANT"
                + ",APPROVER"
                + ",APPROVER2"
                + ",PAYMENT_DATE"
                + ",INVOICE_DATE"
                + ",INVOICE_NUM"
                + ",SENDED"
                + "  from T_COST_ACTUAL_COSTS ";
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
        /// 根据一个主键ID,得到 T_COST_ACTUAL_COSTS 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>ACTUAL_COSTS DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "COSTS_ID"
                + ",CUSTOMER"
                + ",DESCRIPTION"
                + ",ESTIMATE_AMOUNT"
                + ",AMOUNT"
                + ",CURRENCY_ID"
                + ",CONVERT_MONEY"
                + ",CONTRACT_NUM"
                + ",NODE_ID"
                + ",VOUCHER_ID"
                + ",OCCURENCY_DATE"
                + ",COMPLETE_DATE"
                + ",COMPLETE_PALCE"
                + ",SHIP_ID"
                + ",REMARK"
                + ",APPLICANT"
                + ",APPROVER"
                + ",APPROVER2"
                + ",PAYMENT_DATE"
                + ",INVOICE_DATE"
                + ",INVOICE_NUM"
                + ",SENDED"
                + " from T_COST_ACTUAL_COSTS "
                + " where upper(COSTS_ID)='" + Id.ToUpper() + "'";
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
        /// 根据actual_costs 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>actual_costs 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
        public ACTUAL_COSTS getObject(DataRow dr)
        {
            ACTUAL_COSTS unit = new ACTUAL_COSTS();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造ACTUAL_COSTS类对象!";
                return unit;
            }
            if (DBNull.Value != dr["COSTS_ID"])
                unit.COSTS_ID = dr["COSTS_ID"].ToString();
            if (DBNull.Value != dr["CUSTOMER"])
                unit.CUSTOMER = dr["CUSTOMER"].ToString();
            if (DBNull.Value != dr["DESCRIPTION"])
                unit.DESCRIPTION = dr["DESCRIPTION"].ToString();
            if (DBNull.Value != dr["ESTIMATE_AMOUNT"])
                unit.ESTIMATE_AMOUNT = Convert.ToDecimal(dr["ESTIMATE_AMOUNT"]);
            if (DBNull.Value != dr["AMOUNT"])
                unit.AMOUNT = Convert.ToDecimal(dr["AMOUNT"]);
            if (DBNull.Value != dr["CURRENCY_ID"])
                unit.CURRENCY_ID = dr["CURRENCY_ID"].ToString();
            if (DBNull.Value != dr["CONVERT_MONEY"])
                unit.CONVERT_MONEY = Convert.ToDecimal(dr["CONVERT_MONEY"]);
            if (DBNull.Value != dr["CONTRACT_NUM"])
                unit.CONTRACT_NUM = dr["CONTRACT_NUM"].ToString();
            if (DBNull.Value != dr["NODE_ID"])
                unit.NODE_ID = dr["NODE_ID"].ToString();
            if (DBNull.Value != dr["VOUCHER_ID"])
                unit.VOUCHER_ID = dr["VOUCHER_ID"].ToString();
            if (DBNull.Value != dr["OCCURENCY_DATE"])
                unit.OCCURENCY_DATE = (DateTime)dr["OCCURENCY_DATE"];
            if (DBNull.Value != dr["COMPLETE_DATE"])
                unit.COMPLETE_DATE = (DateTime)dr["COMPLETE_DATE"];
            if (DBNull.Value != dr["COMPLETE_PALCE"])
                unit.COMPLETE_PALCE = dr["COMPLETE_PALCE"].ToString();
            if (DBNull.Value != dr["SHIP_ID"])
                unit.SHIP_ID = dr["SHIP_ID"].ToString();
            if (DBNull.Value != dr["REMARK"])
                unit.REMARK = dr["REMARK"].ToString();
            if (DBNull.Value != dr["APPLICANT"])
                unit.APPLICANT = dr["APPLICANT"].ToString();
            if (DBNull.Value != dr["APPROVER"])
                unit.APPROVER = dr["APPROVER"].ToString();
            if (DBNull.Value != dr["APPROVER2"])
                unit.APPROVER2 = dr["APPROVER2"].ToString();
            if (DBNull.Value != dr["PAYMENT_DATE"])
                unit.PAYMENT_DATE = (DateTime)dr["PAYMENT_DATE"];
            if (DBNull.Value != dr["INVOICE_DATE"])
                unit.INVOICE_DATE = (DateTime)dr["INVOICE_DATE"];
            if (DBNull.Value != dr["INVOICE_NUM"])
                unit.INVOICE_NUM = dr["INVOICE_NUM"].ToString();
            if (DBNull.Value != dr["SENDED"])
                unit.SENDED = Convert.ToInt32(dr["SENDED"]);

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个ACTUAL_COSTS对象.
        /// </summary>
        /// <param name="cOSTS_ID">cOSTS_ID</param>
        /// <returns>ACTUAL_COSTS对象</returns>
        public ACTUAL_COSTS getObject(string Id, out string err)
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
