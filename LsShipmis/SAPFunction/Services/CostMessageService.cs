/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：CostMessageService.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/12/30
 * 标    题：数据操作类
 * 功能描述：T_COST_MESSAGE数据操作类
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
    /// 数据层实例化接口类 dbo.T_COST_MESSAGEService.cs
    /// </summary>
    public partial class CostMessageService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static CostMessageService instance = new CostMessageService();
        public static CostMessageService Instance
        {
            get
            {
                if (null == instance)
                {
                    CostMessageService.instance = new CostMessageService();
                }
                return CostMessageService.instance;
            }
        }
        private CostMessageService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">CostMessage对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(CostMessage unit, out string err)
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
            }
            else
            {
                unit.COST_MESSAGE_ID = Guid.NewGuid().ToString();
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
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_COST_MESSAGE中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_COST_MESSAGE对象</param>
        internal bool deleteUnit(CostMessage unit, out string err)
        {
            return deleteUnit(unit.COST_MESSAGE_ID, out err);
        }

        /// <summary>
        /// 删除数据表T_COST_MESSAGE中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_COST_MESSAGE.cOST_MESSAGE_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_COST_MESSAGE where "
                + " upper(T_COST_MESSAGE.COST_MESSAGE_ID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_COST_MESSAGE 所有数据信息.
        /// </summary>
        /// <returns>T_COST_MESSAGE DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "COST_MESSAGE_ID"
                + ",MESSAGE_HEADER_ID"
                + ",LINENUM"
                + ",SUPPLIER"
                + ",SUPPLIER_MAPPING"
                + ",CURRENCY"
                + ",AMOUNT"
                + ",SUBJECT"
                + ",SUBJECT_MAPPING"
                + ",COST_TYPE"
                + ",INNER_ORDER"
                + ",SHIP_ID"
                + ",SHIP_MAPPING"
                + ",UUID"
                + ",REMARK"
                + "  from T_COST_MESSAGE ";
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
        /// 根据一个主键ID,得到 T_COST_MESSAGE 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>CostMessage DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "COST_MESSAGE_ID"
                + ",MESSAGE_HEADER_ID"
                + ",LINENUM"
                + ",SUPPLIER"
                + ",SUPPLIER_MAPPING"
                + ",CURRENCY"
                + ",AMOUNT"
                + ",SUBJECT"
                + ",SUBJECT_MAPPING"
                + ",COST_TYPE"
                + ",INNER_ORDER"
                + ",SHIP_ID"
                + ",SHIP_MAPPING"
                + ",UUID"
                + ",REMARK"
                + " from T_COST_MESSAGE "
                + " where upper(COST_MESSAGE_ID)='" + Id.ToUpper() + "'";
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
        /// 根据costmessage 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>costmessage 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
        public CostMessage getObject(DataRow dr)
        {
            CostMessage unit = new CostMessage();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造CostMessage类对象!";
                return unit;
            }
            if (DBNull.Value != dr["COST_MESSAGE_ID"])
                unit.COST_MESSAGE_ID = dr["COST_MESSAGE_ID"].ToString();
            if (DBNull.Value != dr["MESSAGE_HEADER_ID"])
                unit.MESSAGE_HEADER_ID = dr["MESSAGE_HEADER_ID"].ToString();
            if (DBNull.Value != dr["LINENUM"])
                unit.LINENUM = Convert.ToInt32(dr["LINENUM"]);
            if (DBNull.Value != dr["SUPPLIER"])
                unit.SUPPLIER = dr["SUPPLIER"].ToString();
            if (DBNull.Value != dr["SUPPLIER_MAPPING"])
                unit.SUPPLIER_MAPPING = dr["SUPPLIER_MAPPING"].ToString();
            if (DBNull.Value != dr["CURRENCY"])
                unit.CURRENCY = dr["CURRENCY"].ToString();
            if (DBNull.Value != dr["AMOUNT"])
                unit.AMOUNT = Convert.ToDecimal(dr["AMOUNT"]);
            if (DBNull.Value != dr["SUBJECT"])
                unit.SUBJECT = dr["SUBJECT"].ToString();
            if (DBNull.Value != dr["SUBJECT_MAPPING"])
                unit.SUBJECT_MAPPING = dr["SUBJECT_MAPPING"].ToString();
            if (DBNull.Value != dr["COST_TYPE"])
                unit.COST_TYPE = dr["COST_TYPE"].ToString();
            if (DBNull.Value != dr["INNER_ORDER"])
                unit.INNER_ORDER = dr["INNER_ORDER"].ToString();
            if (DBNull.Value != dr["SHIP_ID"])
                unit.SHIP_ID = dr["SHIP_ID"].ToString();
            if (DBNull.Value != dr["SHIP_MAPPING"])
                unit.SHIP_MAPPING = dr["SHIP_MAPPING"].ToString();
            if (DBNull.Value != dr["UUID"])
                unit.UUID = dr["UUID"].ToString();
            if (DBNull.Value != dr["REMARK"])
                unit.REMARK = dr["REMARK"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个CostMessage对象.
        /// </summary>
        /// <param name="cOST_MESSAGE_ID">cOST_MESSAGE_ID</param>
        /// <returns>CostMessage对象</returns>
        public CostMessage getObject(string Id, out string err)
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
