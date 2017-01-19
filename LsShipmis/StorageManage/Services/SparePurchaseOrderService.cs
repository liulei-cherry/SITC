/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：SparePurchaseOrderService.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/9/10
 * 标    题：数据操作类
 * 功能描述：T_SPARE_PURCHASE_ORDER数据操作类
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
    /// 数据层实例化接口类 dbo.T_SPARE_PURCHASE_ORDERService.cs
    /// </summary>
    public partial class SparePurchaseOrderService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static SparePurchaseOrderService instance = new SparePurchaseOrderService();
        public static SparePurchaseOrderService Instance
        {
            get
            {
                if (null == instance)
                {
                    SparePurchaseOrderService.instance = new SparePurchaseOrderService();
                }
                return SparePurchaseOrderService.instance;
            }
        }
        private SparePurchaseOrderService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">SparePurchaseOrder对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(SparePurchaseOrder unit, out string err)
        {
            if (unit.PURCHASE_ORDERID != null && unit.PURCHASE_ORDERID.Length > 0) //edit
            {
                sql = "UPDATE [T_SPARE_PURCHASE_ORDER] SET "
                    + " [PURCHASE_ORDERID] = " + (string.IsNullOrEmpty(unit.PURCHASE_ORDERID) ? "null" : "'" + unit.PURCHASE_ORDERID.Replace("'", "''") + "'")
                    + " , [CURRENCYID] = " + (string.IsNullOrEmpty(unit.CURRENCYID) ? "null" : "'" + unit.CURRENCYID.Replace("'", "''") + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , [COMPONENT_UNIT_ID] = " + (string.IsNullOrEmpty(unit.COMPONENT_UNIT_ID) ? "null" : "'" + unit.COMPONENT_UNIT_ID.Replace("'", "''") + "'")
                    + " , [SUPPLIER_ID] = " + (string.IsNullOrEmpty(unit.SUPPLIER_ID) ? "null" : "'" + unit.SUPPLIER_ID.Replace("'", "''") + "'")
                    + " , [PURCHASE_ORDER_CODE] = " + (unit.PURCHASE_ORDER_CODE == null ? "''" : "'" + unit.PURCHASE_ORDER_CODE.Replace("'", "''") + "'")
                    + " , [PURCHASE_ORDER_PERSON] = " + (unit.PURCHASE_ORDER_PERSON == null ? "''" : "'" + unit.PURCHASE_ORDER_PERSON.Replace("'", "''") + "'")
                    + " , [PURCHASE_ORDER_DATE] = " + dbOperation.DbToDate(unit.PURCHASE_ORDER_DATE)
                    + " , [LANDCHECKER] = " + (unit.LANDCHECKER == null ? "''" : "'" + unit.LANDCHECKER.Replace("'", "''") + "'")
                    + " , [CHECKDATE] = " + dbOperation.DbToDate(unit.CHECKDATE)
                    + " , [REMARK] = N" + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
                    + " , [STATE] = " + unit.STATE.ToString()
                    + " , [TOTALPRICE] = " + unit.TOTALPRICE.ToString()
                    + " , [EXTRAPRICE] = " + unit.EXTRAPRICE.ToString()
                    + " , [SENDDATE] = " + dbOperation.DbToDate(unit.SENDDATE)
                    + " , [ISCOMPLETE] = " + unit.ISCOMPLETE.ToString()
                    + " , [SENDPORT] = " + (unit.SENDPORT == null ? "''" : "'" + unit.SENDPORT.Replace("'", "''") + "'")
                    + " where upper(PURCHASE_ORDERID) = '" + unit.PURCHASE_ORDERID.ToUpper() + "'";
            }
            else
            {
                unit.PURCHASE_ORDERID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_SPARE_PURCHASE_ORDER] ("
                    + "[PURCHASE_ORDERID],"
                    + "[CURRENCYID],"
                    + "[SHIP_ID],"
                    + "[COMPONENT_UNIT_ID],"
                    + "[SUPPLIER_ID],"
                    + "[PURCHASE_ORDER_CODE],"
                    + "[PURCHASE_ORDER_PERSON],"
                    + "[PURCHASE_ORDER_DATE],"
                    + "[LANDCHECKER],"
                    + "[CHECKDATE],"
                    + "[REMARK],"
                    + "[STATE],"
                    + "[TOTALPRICE],"
                    + "[EXTRAPRICE],"
                    + "[SENDDATE],"
                    + "[ISCOMPLETE],"
                    + "[SENDPORT]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.PURCHASE_ORDERID) ? "null" : "'" + unit.PURCHASE_ORDERID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.CURRENCYID) ? "null" : "'" + unit.CURRENCYID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.COMPONENT_UNIT_ID) ? "null" : "'" + unit.COMPONENT_UNIT_ID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SUPPLIER_ID) ? "null" : "'" + unit.SUPPLIER_ID.Replace("'", "''") + "'")
                    + " , " + (unit.PURCHASE_ORDER_CODE == null ? "''" : "'" + unit.PURCHASE_ORDER_CODE.Replace("'", "''") + "'")
                    + " , " + (unit.PURCHASE_ORDER_PERSON == null ? "''" : "'" + unit.PURCHASE_ORDER_PERSON.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.PURCHASE_ORDER_DATE)
                    + " , " + (unit.LANDCHECKER == null ? "''" : "'" + unit.LANDCHECKER.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.CHECKDATE)
                    + " , N" + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
                    + " ," + unit.STATE.ToString()
                    + " ," + unit.TOTALPRICE.ToString()
                    + " ," + unit.EXTRAPRICE.ToString()
                    + " ," + dbOperation.DbToDate(unit.SENDDATE)
                    + " ," + unit.ISCOMPLETE.ToString()
                    + " , " + (unit.SENDPORT == null ? "''" : "'" + unit.SENDPORT.Replace("'", "''") + "'")
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_SPARE_PURCHASE_ORDER中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_SPARE_PURCHASE_ORDER对象</param>
        internal bool deleteUnit(SparePurchaseOrder unit, out string err)
        {
            return deleteUnit(unit.PURCHASE_ORDERID, out err);
        }

        /// <summary>
        /// 删除数据表T_SPARE_PURCHASE_ORDER中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_SPARE_PURCHASE_ORDER.pURCHASE_ORDERID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_SPARE_PURCHASE_ORDER where "
                + " upper(T_SPARE_PURCHASE_ORDER.PURCHASE_ORDERID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_SPARE_PURCHASE_ORDER 所有数据信息.
        /// </summary>
        /// <returns>T_SPARE_PURCHASE_ORDER DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "PURCHASE_ORDERID"
                + ",CURRENCYID"
                + ",SHIP_ID"
                + ",COMPONENT_UNIT_ID"
                + ",SUPPLIER_ID"
                + ",PURCHASE_ORDER_CODE"
                + ",PURCHASE_ORDER_PERSON"
                + ",PURCHASE_ORDER_DATE"
                + ",LANDCHECKER"
                + ",CHECKDATE"
                + ",REMARK"
                + ",STATE"
                + ",TOTALPRICE"
                + ",EXTRAPRICE"
                + ",SENDDATE"
                + ",ISCOMPLETE"
                + ",SENDPORT"
                + "  from T_SPARE_PURCHASE_ORDER ";
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
        /// 根据一个主键ID,得到 T_SPARE_PURCHASE_ORDER 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>SparePurchaseOrder DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "PURCHASE_ORDERID"
                + ",CURRENCYID"
                + ",SHIP_ID"
                + ",COMPONENT_UNIT_ID"
                + ",SUPPLIER_ID"
                + ",PURCHASE_ORDER_CODE"
                + ",PURCHASE_ORDER_PERSON"
                + ",PURCHASE_ORDER_DATE"
                + ",LANDCHECKER"
                + ",CHECKDATE"
                + ",REMARK"
                + ",STATE"
                + ",TOTALPRICE"
                + ",EXTRAPRICE"
                + ",SENDDATE"
                + ",ISCOMPLETE"
                + ",SENDPORT"
                + " from T_SPARE_PURCHASE_ORDER "
                + " where upper(PURCHASE_ORDERID)='" + Id.ToUpper() + "'";
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
        /// 根据sparepurchaseorder 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>sparepurchaseorder 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
        public SparePurchaseOrder getObject(DataRow dr)
        {
            SparePurchaseOrder unit = new SparePurchaseOrder();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造SparePurchaseOrder类对象!";
                return unit;
            }
            if (DBNull.Value != dr["PURCHASE_ORDERID"])
                unit.PURCHASE_ORDERID = dr["PURCHASE_ORDERID"].ToString();
            if (DBNull.Value != dr["CURRENCYID"])
                unit.CURRENCYID = dr["CURRENCYID"].ToString();
            if (DBNull.Value != dr["SHIP_ID"])
                unit.SHIP_ID = dr["SHIP_ID"].ToString();
            if (DBNull.Value != dr["COMPONENT_UNIT_ID"])
                unit.COMPONENT_UNIT_ID = dr["COMPONENT_UNIT_ID"].ToString();
            if (DBNull.Value != dr["SUPPLIER_ID"])
                unit.SUPPLIER_ID = dr["SUPPLIER_ID"].ToString();
            if (DBNull.Value != dr["PURCHASE_ORDER_CODE"])
                unit.PURCHASE_ORDER_CODE = dr["PURCHASE_ORDER_CODE"].ToString();
            if (DBNull.Value != dr["PURCHASE_ORDER_PERSON"])
                unit.PURCHASE_ORDER_PERSON = dr["PURCHASE_ORDER_PERSON"].ToString();
            if (DBNull.Value != dr["PURCHASE_ORDER_DATE"])
                unit.PURCHASE_ORDER_DATE = (DateTime)dr["PURCHASE_ORDER_DATE"];
            if (DBNull.Value != dr["LANDCHECKER"])
                unit.LANDCHECKER = dr["LANDCHECKER"].ToString();
            if (DBNull.Value != dr["CHECKDATE"])
                unit.CHECKDATE = (DateTime)dr["CHECKDATE"];
            if (DBNull.Value != dr["REMARK"])
                unit.REMARK = dr["REMARK"].ToString();
            if (DBNull.Value != dr["STATE"])
                unit.STATE = Convert.ToDecimal(dr["STATE"]);
            if (DBNull.Value != dr["TOTALPRICE"])
                unit.TOTALPRICE = Convert.ToDecimal(dr["TOTALPRICE"]);
            if (DBNull.Value != dr["EXTRAPRICE"])
                unit.EXTRAPRICE = Convert.ToDecimal(dr["EXTRAPRICE"]);
            if (DBNull.Value != dr["SENDDATE"])
                unit.SENDDATE = (DateTime)dr["SENDDATE"];
            if (DBNull.Value != dr["ISCOMPLETE"])
                unit.ISCOMPLETE = Convert.ToDecimal(dr["ISCOMPLETE"]);
            if (DBNull.Value != dr["SENDPORT"])
                unit.SENDPORT = dr["SENDPORT"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个SparePurchaseOrder对象.
        /// </summary>
        /// <param name="pURCHASE_ORDERID">pURCHASE_ORDERID</param>
        /// <returns>SparePurchaseOrder对象</returns>
        public SparePurchaseOrder getObject(string Id, out string err)
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
