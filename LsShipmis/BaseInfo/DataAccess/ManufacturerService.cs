/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：ManufacturerService.cs
 * 创 建 人：黄家龙
 * 创建时间：2011/10/12
 * 标    题：数据操作类
 * 功能描述：T_MANUFACTURER数据操作类
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

namespace BaseInfo.DataAccess
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_MANUFACTURERService.cs
    /// </summary>
    public partial class ManufacturerService
    {
        #region 构造函数

        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static ManufacturerService instance = new ManufacturerService();
        public static ManufacturerService Instance
        {
            get
            {
                if (null == instance)
                {
                    ManufacturerService.instance = new ManufacturerService();
                }
                return ManufacturerService.instance;
            }
        }
        private ManufacturerService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">Manufacturer对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(Manufacturer unit, out string err)
        {
            List<string> sqls = new List<string>();
            if (unit.MANUFACTURER_ID != null && unit.MANUFACTURER_ID.Length > 0) //edit
            {
                //dbo.T_COST_VOUCHER, payee 
                sql = string.Format(@"
UPDATE T_COST_VOUCHER 
set payee = '{0}'
where payee = (select MANUFACTURER_NAME from T_MANUFACTURER where MANUFACTURER_ID = '{1}')", unit.MANUFACTURER_NAME, unit.GetId());
                sqls.Add(sql);
                
                //dbo.T_COST_ACTUAL_COSTS,CUSTOMER
                sql = string.Format(@"
UPDATE T_COST_ACTUAL_COSTS 
set CUSTOMER = '{0}'
where CUSTOMER = (select MANUFACTURER_NAME from T_MANUFACTURER where MANUFACTURER_ID = '{1}')", unit.MANUFACTURER_NAME, unit.GetId());
                sqls.Add(sql);

                sql = "UPDATE [T_MANUFACTURER] SET "
                    + " [MANUFACTURER_ID] = " + (string.IsNullOrEmpty(unit.MANUFACTURER_ID) ? "null" : "'" + unit.MANUFACTURER_ID.Replace("'", "''") + "'")
                    + " , [MANUFACTURER_CODE] = " + (unit.MANUFACTURER_CODE == null ? "''" : "'" + unit.MANUFACTURER_CODE.Replace("'", "''") + "'")
                    + " , [MANUFACTURER_TYPE] = " + (unit.MANUFACTURER_TYPE == null ? "''" : "'" + unit.MANUFACTURER_TYPE.Replace("'", "''") + "'")
                    + " , [MANUFACTURER_NAME] = " + (unit.MANUFACTURER_NAME == null ? "''" : "'" + unit.MANUFACTURER_NAME.Replace("'", "''") + "'")
                    + " , [MANUFACTURER_ENAME] = " + (unit.MANUFACTURER_ENAME == null ? "''" : "'" + unit.MANUFACTURER_ENAME.Replace("'", "''") + "'")
                    + " , [ADDR] = " + (unit.ADDR == null ? "''" : "'" + unit.ADDR.Replace("'", "''") + "'")
                    + " , [FAX] = " + (unit.FAX == null ? "''" : "'" + unit.FAX.Replace("'", "''") + "'")
                    + " , [NETADDR] = " + (unit.NETADDR == null ? "''" : "'" + unit.NETADDR.Replace("'", "''") + "'")
                    + " , [EMAIL] = " + (unit.EMAIL == null ? "''" : "'" + unit.EMAIL.Replace("'", "''") + "'")
                    + " , [LINKER] = " + (unit.LINKER == null ? "''" : "'" + unit.LINKER.Replace("'", "''") + "'")
                    + " , [POSTALCODE] = " + (unit.POSTALCODE == null ? "''" : "'" + unit.POSTALCODE.Replace("'", "''") + "'")
                    + " , [REMARK] = " + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
                    + " , [TELEPHONE] = " + (unit.TELEPHONE == null ? "''" : "'" + unit.TELEPHONE.Replace("'", "''") + "'")
                    + " , [MOBILPHONE] = " + (unit.MOBILPHONE == null ? "''" : "'" + unit.MOBILPHONE.Replace("'", "''") + "'")
                    + " , [MANUFACTURER_NULLIFY] = " + (string.IsNullOrEmpty(unit.MANUFACTURER_NULLIFY) ? "'0'" : "'" + unit.MANUFACTURER_NULLIFY.Replace("'", "''") + "'")
                    + " where upper(MANUFACTURER_ID) = '" + unit.MANUFACTURER_ID.ToUpper() + "'";
                sqls.Add(sql);
            }
            else
            {
                unit.MANUFACTURER_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_MANUFACTURER] ("
                    + "[MANUFACTURER_ID],"
                    + "[MANUFACTURER_CODE],"
                    + "[MANUFACTURER_TYPE],"
                    + "[MANUFACTURER_NAME],"
                    + "[MANUFACTURER_ENAME],"
                    + "[ADDR],"
                    + "[FAX],"
                    + "[NETADDR],"
                    + "[EMAIL],"
                    + "[LINKER],"
                    + "[POSTALCODE],"
                    + "[REMARK],"
                    + "[TELEPHONE],"
                    + "[MOBILPHONE],"
                    + "[MANUFACTURER_NULLIFY]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.MANUFACTURER_ID) ? "null" : "'" + unit.MANUFACTURER_ID.Replace("'", "''") + "'")
                    + " , " + (unit.MANUFACTURER_CODE == null ? "''" : "'" + unit.MANUFACTURER_CODE.Replace("'", "''") + "'")
                    + " , " + (unit.MANUFACTURER_TYPE == null ? "''" : "'" + unit.MANUFACTURER_TYPE.Replace("'", "''") + "'")
                    + " , " + (unit.MANUFACTURER_NAME == null ? "''" : "'" + unit.MANUFACTURER_NAME.Replace("'", "''") + "'")
                    + " , " + (unit.MANUFACTURER_ENAME == null ? "''" : "'" + unit.MANUFACTURER_ENAME.Replace("'", "''") + "'")
                    + " , " + (unit.ADDR == null ? "''" : "'" + unit.ADDR.Replace("'", "''") + "'")
                    + " , " + (unit.FAX == null ? "''" : "'" + unit.FAX.Replace("'", "''") + "'")
                    + " , " + (unit.NETADDR == null ? "''" : "'" + unit.NETADDR.Replace("'", "''") + "'")
                    + " , " + (unit.EMAIL == null ? "''" : "'" + unit.EMAIL.Replace("'", "''") + "'")
                    + " , " + (unit.LINKER == null ? "''" : "'" + unit.LINKER.Replace("'", "''") + "'")
                    + " , " + (unit.POSTALCODE == null ? "''" : "'" + unit.POSTALCODE.Replace("'", "''") + "'")
                    + " , " + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
                    + " , " + (unit.TELEPHONE == null ? "''" : "'" + unit.TELEPHONE.Replace("'", "''") + "'")
                    + " , " + (unit.MOBILPHONE == null ? "''" : "'" + unit.MOBILPHONE.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.MANUFACTURER_NULLIFY) ? "'0'" : "'" + unit.MANUFACTURER_NULLIFY.Replace("'", "''") + "'")
                    + ")";
                sqls.Add(sql);
            }

            return dbAccess.ExecSql(sqls, out err);
        }
        /// <summary>
        /// 删除数据表T_MANUFACTURER中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_MANUFACTURER对象</param>
        internal bool deleteUnit(Manufacturer unit, out string err)
        {
            return deleteUnit(unit.MANUFACTURER_ID, out err);
        }

        /// <summary>
        /// 删除数据表T_MANUFACTURER中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_MANUFACTURER.mANUFACTURER_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_MANUFACTURER where "
                + " upper(T_MANUFACTURER.MANUFACTURER_ID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体

        /// <summary>
        /// 得到  T_MANUFACTURER 所有数据信息.
        /// </summary>
        /// <param name="notNullify">不包括作废的供应商：true；包括作废的供应商（默认）：false.</param>
        /// <returns>T_MANUFACTURER DataTable</returns>
        public DataTable getInfo(Boolean notNullify, out string err)
        {
            sql = "select	"
                + "MANUFACTURER_ID"
                + ",MANUFACTURER_CODE"
                + ",MANUFACTURER_TYPE"
                + ",MANUFACTURER_NAME"
                + ",MANUFACTURER_ENAME"
                + ",ADDR"
                + ",FAX"
                + ",NETADDR"
                + ",EMAIL"
                + ",LINKER"
                + ",POSTALCODE"
                + ",REMARK"
                + ",TELEPHONE"
                + ",MOBILPHONE"
                + ",MANUFACTURER_NULLIFY"
                + ",case when isnull(MANUFACTURER_NULLIFY,'') = '1' then '作废' end as  MANUFACTURER_NoUse"
                + "  from T_MANUFACTURER WHERE 1=1 ";
            if (notNullify)
            {
                sql += "AND (MANUFACTURER_NULLIFY IS NULL OR MANUFACTURER_NULLIFY <> '1') ";
            }

            sql += "   order by MANUFACTURER_NAME ";
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
        /// 根据一个主键ID,得到 T_MANUFACTURER 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>Manufacturer DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "MANUFACTURER_ID"
                + ",MANUFACTURER_CODE"
                + ",MANUFACTURER_TYPE"
                + ",MANUFACTURER_NAME"
                + ",MANUFACTURER_ENAME"
                + ",ADDR"
                + ",FAX"
                + ",NETADDR"
                + ",EMAIL"
                + ",LINKER"
                + ",POSTALCODE"
                + ",REMARK"
                + ",TELEPHONE"
                + ",MOBILPHONE"
                + ",MANUFACTURER_NULLIFY"
                + ",case when isnull(MANUFACTURER_NULLIFY,'') = '1' then '作废' end as  MANUFACTURER_NoUse"
                + " from T_MANUFACTURER "
                + " where upper(MANUFACTURER_ID)='" + Id.ToUpper() + "'";
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
        /// 根据manufacturer 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>manufacturer 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
        public Manufacturer getObject(DataRow dr)
        {
            Manufacturer unit = new Manufacturer();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造Manufacturer类对象!";
                return unit;
            }
            if (DBNull.Value != dr["MANUFACTURER_ID"])
                unit.MANUFACTURER_ID = dr["MANUFACTURER_ID"].ToString();
            if (DBNull.Value != dr["MANUFACTURER_CODE"])
                unit.MANUFACTURER_CODE = dr["MANUFACTURER_CODE"].ToString();
            if (DBNull.Value != dr["MANUFACTURER_TYPE"])
                unit.MANUFACTURER_TYPE = dr["MANUFACTURER_TYPE"].ToString();
            if (DBNull.Value != dr["MANUFACTURER_NAME"])
                unit.MANUFACTURER_NAME = dr["MANUFACTURER_NAME"].ToString();
            if (DBNull.Value != dr["MANUFACTURER_ENAME"])
                unit.MANUFACTURER_ENAME = dr["MANUFACTURER_ENAME"].ToString();
            if (DBNull.Value != dr["ADDR"])
                unit.ADDR = dr["ADDR"].ToString();
            if (DBNull.Value != dr["FAX"])
                unit.FAX = dr["FAX"].ToString();
            if (DBNull.Value != dr["NETADDR"])
                unit.NETADDR = dr["NETADDR"].ToString();
            if (DBNull.Value != dr["EMAIL"])
                unit.EMAIL = dr["EMAIL"].ToString();
            if (DBNull.Value != dr["LINKER"])
                unit.LINKER = dr["LINKER"].ToString();
            if (DBNull.Value != dr["POSTALCODE"])
                unit.POSTALCODE = dr["POSTALCODE"].ToString();
            if (DBNull.Value != dr["REMARK"])
                unit.REMARK = dr["REMARK"].ToString();
            if (DBNull.Value != dr["TELEPHONE"])
                unit.TELEPHONE = dr["TELEPHONE"].ToString();
            if (DBNull.Value != dr["MOBILPHONE"])
                unit.MOBILPHONE = dr["MOBILPHONE"].ToString();
            if (DBNull.Value != dr["MANUFACTURER_NULLIFY"])
                unit.MANUFACTURER_NULLIFY = dr["MANUFACTURER_NULLIFY"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个Manufacturer对象.
        /// </summary>
        /// <param name="mANUFACTURER_ID">mANUFACTURER_ID</param>
        /// <returns>Manufacturer对象</returns>
        public Manufacturer getObject(string Id, out string err)
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
