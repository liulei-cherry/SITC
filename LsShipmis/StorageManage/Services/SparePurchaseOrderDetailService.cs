/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：SparePurchaseOrderDetailService.cs
 * 创 建 人：王鹏程
 * 创建时间：2012/4/23
 * 标    题：数据操作类
 * 功能描述：T_SPARE_PURCHASE_ORDER_DETAIL数据操作类
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
using StorageManage.DataObject;

namespace StorageManage.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_SPARE_PURCHASE_ORDER_DETAILService.cs
    /// </summary>
    public partial class SparePurchaseOrderDetailService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象
        /// </summary>
        private static SparePurchaseOrderDetailService instance = new SparePurchaseOrderDetailService();
        public static SparePurchaseOrderDetailService Instance
        {
            get
            {
                if (null == instance)
                {
                    SparePurchaseOrderDetailService.instance = new SparePurchaseOrderDetailService();
                }
                return SparePurchaseOrderDetailService.instance;
            }
        }
        private SparePurchaseOrderDetailService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。
        /// </summary>
        /// <param name="unit">SparePurchaseOrderDetail对象</param>
        /// <returns>插入的对象更新</returns>	
        public bool saveUnit(SparePurchaseOrderDetail unit, out string err)
        {
            return dbAccess.ExecSql(saveUnitSql(unit), out err);
        }
        /// <summary>
        /// 向数据库中保存一条新记录。
        /// </summary>
        /// <param name="unit">SparePurchaseOrderDetail对象</param>
        /// <returns>插入的对象更新</returns>	
        public void saveUnit(SparePurchaseOrderDetail unit)
        {
            string err;
            if (!dbAccess.ExecSql(saveUnitSql(unit), out err))
                throw new Exception(err);
        }
        /// <summary>
        /// 返回向数据库中保存一条新记录的sql语句。做事务用。
        /// </summary>
        /// <param name="unit">SparePurchaseOrderDetail对象</param>
        /// <returns>插入的对象更新</returns>	
        public string saveUnitSql(SparePurchaseOrderDetail unit)
        {
            if (unit.PURCHASE_ORDER_DETAIL_ID != null && unit.PURCHASE_ORDER_DETAIL_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_SPARE_PURCHASE_ORDER_DETAIL] SET "
                + " [PURCHASE_ORDER_DETAIL_ID] = " + (string.IsNullOrEmpty(unit.PURCHASE_ORDER_DETAIL_ID) ? "null" : "'" + unit.PURCHASE_ORDER_DETAIL_ID.Replace("'", "''") + "'")
                + " , [PURCHASE_ORDERID] = " + (string.IsNullOrEmpty(unit.PURCHASE_ORDERID) ? "null" : "'" + unit.PURCHASE_ORDERID.Replace("'", "''") + "'")
                + " , [COMPONENT_UNIT_ID] = " + (string.IsNullOrEmpty(unit.COMPONENT_UNIT_ID) ? "null" : "'" + unit.COMPONENT_UNIT_ID.Replace("'", "''") + "'")
                + " , [SPARE_ID] = " + (string.IsNullOrEmpty(unit.SPARE_ID) ? "null" : "'" + unit.SPARE_ID.Replace("'", "''") + "'")
                + " , [SPARE_NAME] = " + (unit.SPARE_NAME == null ? "''" : "'" + unit.SPARE_NAME.Replace("'", "''") + "'")
                + " , [PARTNUMBER] = " + (unit.PARTNUMBER == null ? "''" : "'" + unit.PARTNUMBER.Replace("'", "''") + "'")
                + " , [PURCHASECOUNT] = " + unit.PURCHASECOUNT.ToString()
                + " , [CURRENCYID] = " + (string.IsNullOrEmpty(unit.CURRENCYID) ? "null" : "'" + unit.CURRENCYID.Replace("'", "''") + "'")
                + " , [REMARK] = " + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
                + " , [PRICE] = " + unit.PRICE.ToString()
                + " , [RECEIVECOUNT] = " + unit.RECEIVECOUNT.ToString()
                + " , [RECEIVEREMARK] = " + (unit.RECEIVEREMARK == null ? "''" : "'" + unit.RECEIVEREMARK.Replace("'", "''") + "'")
                + " , [PURCHASE_APPLYID] = " + (string.IsNullOrEmpty(unit.PURCHASE_APPLYID) ? "null" : "'" + unit.PURCHASE_APPLYID.Replace("'", "''") + "'")
                + " where upper(PURCHASE_ORDER_DETAIL_ID) = '" + unit.PURCHASE_ORDER_DETAIL_ID.ToUpper() + "'"; 
            }
            else
            {
                unit.PURCHASE_ORDER_DETAIL_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_SPARE_PURCHASE_ORDER_DETAIL] ("
                 + "[PURCHASE_ORDER_DETAIL_ID],"
                 + "[PURCHASE_ORDERID],"
                 + "[COMPONENT_UNIT_ID],"
                 + "[SPARE_ID],"
                 + "[SPARE_NAME],"
                 + "[PARTNUMBER],"
                 + "[PURCHASECOUNT],"
                 + "[CURRENCYID],"
                 + "[REMARK],"
                 + "[PRICE],"
                 + "[RECEIVECOUNT],"
                 + "[RECEIVEREMARK],"
                 + "[PURCHASE_APPLYID]"
                 + ") VALUES( "
                 + " " + (string.IsNullOrEmpty(unit.PURCHASE_ORDER_DETAIL_ID) ? "null" : "'" + unit.PURCHASE_ORDER_DETAIL_ID.Replace("'", "''") + "'")
                 + " , " + (string.IsNullOrEmpty(unit.PURCHASE_ORDERID) ? "null" : "'" + unit.PURCHASE_ORDERID.Replace("'", "''") + "'")
                 + " , " + (string.IsNullOrEmpty(unit.COMPONENT_UNIT_ID) ? "null" : "'" + unit.COMPONENT_UNIT_ID.Replace("'", "''") + "'")
                 + " , " + (string.IsNullOrEmpty(unit.SPARE_ID) ? "null" : "'" + unit.SPARE_ID.Replace("'", "''") + "'")
                 + " , " + (unit.SPARE_NAME == null ? "''" : "'" + unit.SPARE_NAME.Replace("'", "''") + "'")
                 + " , " + (unit.PARTNUMBER == null ? "''" : "'" + unit.PARTNUMBER.Replace("'", "''") + "'")
                 + " ," + unit.PURCHASECOUNT.ToString()
                 + " , " + (string.IsNullOrEmpty(unit.CURRENCYID) ? "null" : "'" + unit.CURRENCYID.Replace("'", "''") + "'")
                 + " , " + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
                 + " ," + unit.PRICE.ToString()
                 + " ," + unit.RECEIVECOUNT.ToString()
                 + " , " + (unit.RECEIVEREMARK == null ? "''" : "'" + unit.RECEIVEREMARK.Replace("'", "''") + "'")
                 + " , " + (string.IsNullOrEmpty(unit.PURCHASE_APPLYID) ? "null" : "'" + unit.PURCHASE_APPLYID.Replace("'", "''") + "'")
                 + ")";
            }

            return sql;
        }

        /// <summary>
        /// 删除数据表T_SPARE_PURCHASE_ORDER_DETAIL中的一条记录
        /// </summary>
        /// <param name="unit">要删除的T_SPARE_PURCHASE_ORDER_DETAIL.pURCHASE_ORDER_DETAIL_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            return dbAccess.ExecSql(deleteUnitSql(unitid), out err);
        }
        /// <summary>
        /// 删除数据表T_SPARE_PURCHASE_ORDER_DETAIL中的一条记录
        /// </summary>
        /// <param name="unit">要删除的T_SPARE_PURCHASE_ORDER_DETAIL.pURCHASE_ORDER_DETAIL_ID主键</param>
        public void deleteUnit(string unitid)
        {
            string err;
            if (!dbAccess.ExecSql(deleteUnitSql(unitid), out err))
                throw new Exception(err);
        }

        /// <summary>
        /// 删除数据表T_SPARE_PURCHASE_ORDER_DETAIL中的一条记录,返回sql语句
        /// </summary>
        /// <param name="unit">要删除的T_SPARE_PURCHASE_ORDER_DETAIL.pURCHASE_ORDER_DETAIL_ID主键</param>
        public string deleteUnitSql(string unitid)
        {
            sql = "delete from T_SPARE_PURCHASE_ORDER_DETAIL where "
                + " upper(T_SPARE_PURCHASE_ORDER_DETAIL.PURCHASE_ORDER_DETAIL_ID)='" + unitid.ToUpper() + "'";
            return sql;
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_SPARE_PURCHASE_ORDER_DETAIL 所有数据信息
        /// </summary>
        /// <returns>T_SPARE_PURCHASE_ORDER_DETAIL DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "PURCHASE_ORDER_DETAIL_ID"
                + ",PURCHASE_ORDERID"
                + ",COMPONENT_UNIT_ID"
                + ",SPARE_ID"
                + ",SPARE_NAME"
                + ",PARTNUMBER"
                + ",PURCHASECOUNT"
                + ",CURRENCYID"
                + ",REMARK"
                + ",PRICE"
                + ",RECEIVECOUNT"
                + ",RECEIVEREMARK"
                + ",PURCHASE_APPLYID"
                + "  from T_SPARE_PURCHASE_ORDER_DETAIL ";
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
        /// 根据一个主键ID,得到 T_SPARE_PURCHASE_ORDER_DETAIL 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>SparePurchaseOrderDetail DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "PURCHASE_ORDER_DETAIL_ID"
                + ",PURCHASE_ORDERID"
                + ",COMPONENT_UNIT_ID"
                + ",SPARE_ID"
                + ",SPARE_NAME"
                + ",PARTNUMBER"
                + ",PURCHASECOUNT"
                + ",CURRENCYID"
                + ",REMARK"
                + ",PRICE"
                + ",RECEIVECOUNT"
                + ",RECEIVEREMARK"
                + ",PURCHASE_APPLYID"
                + " from T_SPARE_PURCHASE_ORDER_DETAIL "
                + " where upper(PURCHASE_ORDER_DETAIL_ID)='" + Id.ToUpper() + "'";
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
        /// 根据sparepurchaseorderdetail 的DataRow封装对象
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>sparepurchaseorderdetail 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
        public SparePurchaseOrderDetail getObject(DataRow dr)
        {
            SparePurchaseOrderDetail unit = new SparePurchaseOrderDetail();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造SparePurchaseOrderDetail类对象!";
                return unit;
            }
            if (DBNull.Value != dr["PURCHASE_ORDER_DETAIL_ID"])
                unit.PURCHASE_ORDER_DETAIL_ID = dr["PURCHASE_ORDER_DETAIL_ID"].ToString();
            if (DBNull.Value != dr["PURCHASE_ORDERID"])
                unit.PURCHASE_ORDERID = dr["PURCHASE_ORDERID"].ToString();
            if (DBNull.Value != dr["COMPONENT_UNIT_ID"])
                unit.COMPONENT_UNIT_ID = dr["COMPONENT_UNIT_ID"].ToString();
            if (DBNull.Value != dr["SPARE_ID"])
                unit.SPARE_ID = dr["SPARE_ID"].ToString();
            if (DBNull.Value != dr["SPARE_NAME"])
                unit.SPARE_NAME = dr["SPARE_NAME"].ToString();
            if (DBNull.Value != dr["PARTNUMBER"])
                unit.PARTNUMBER = dr["PARTNUMBER"].ToString();
            if (DBNull.Value != dr["PURCHASECOUNT"])
                unit.PURCHASECOUNT = Convert.ToDecimal(dr["PURCHASECOUNT"]);
            if (DBNull.Value != dr["CURRENCYID"])
                unit.CURRENCYID = dr["CURRENCYID"].ToString();
            if (DBNull.Value != dr["REMARK"])
                unit.REMARK = dr["REMARK"].ToString();
            if (DBNull.Value != dr["PRICE"])
                unit.PRICE = Convert.ToDecimal(dr["PRICE"]);
            if (DBNull.Value != dr["RECEIVECOUNT"])
                unit.RECEIVECOUNT = Convert.ToDecimal(dr["RECEIVECOUNT"]);
            if (DBNull.Value != dr["RECEIVEREMARK"])
                unit.RECEIVEREMARK = dr["RECEIVEREMARK"].ToString();
            if (DBNull.Value != dr["PURCHASE_APPLYID"])
                unit.PURCHASE_APPLYID = dr["PURCHASE_APPLYID"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个SparePurchaseOrderDetail对象
        /// </summary>
        /// <param name="pURCHASE_ORDER_DETAIL_ID">pURCHASE_ORDER_DETAIL_ID</param>
        /// <returns>SparePurchaseOrderDetail对象</returns>
        public SparePurchaseOrderDetail getObject(string Id, out string err)
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
