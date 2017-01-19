/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：ShipCertDepartService.cs
 * 创 建 人：徐正本
 * 创建时间：2010-5-27
 * 标    题：数据操作类
 * 功能描述：T_SHIP_CERT_DEPART数据操作类
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
using BaseInfo.Objects;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using ShipCertification.DataObject;
using CommonOperation.BaseClass;

namespace ShipCertification.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_SHIP_CERT_DEPARTService.cs
    /// </summary>
    public partial class ShipCertDepartService : IObjectsService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static ShipCertDepartService instance = new ShipCertDepartService();
        public static ShipCertDepartService Instance
        {
            get
            {
                if (null == instance)
                {
                    ShipCertDepartService.instance = new ShipCertDepartService();
                }
                return ShipCertDepartService.instance;
            }
        }
        #endregion

        public ShipCertDepartService()
        {
        }
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region -----------实例化接口函数-----------

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">ShipCertDepart对象</param>
        /// <returns>插入的对象更新</returns>	
        public bool saveUnit(ShipCertDepart unit, out string err)
        {
            if (unit.SHIP_CERT_DEPARTID != null && unit.SHIP_CERT_DEPARTID.Length > 0) //edit
            {
                sql = "UPDATE [T_SHIP_CERT_DEPART] SET "
                    + " [SHIP_CERT_DEPARTID] = '" + (unit.SHIP_CERT_DEPARTID == null ? "" : unit.SHIP_CERT_DEPARTID.Replace("'", "''")) + "'"
                    + " , [SHIPCERTDEPARTNAME] = '" + (unit.SHIPCERTDEPARTNAME == null ? "" : unit.SHIPCERTDEPARTNAME.Replace("'", "''")) + "'"
                    + " , [COUNTRY] = '" + (unit.COUNTRY == null ? "" : unit.COUNTRY.Replace("'", "''")) + "'"
                    + " where upper(SHIP_CERT_DEPARTID) = '" + unit.SHIP_CERT_DEPARTID.ToUpper() + "'";
            }
            else
            {
                unit.SHIP_CERT_DEPARTID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_SHIP_CERT_DEPART] ("
                    + "[SHIP_CERT_DEPARTID],"
                    + "[SHIPCERTDEPARTNAME],"
                    + "[COUNTRY]"
                    + ") VALUES( "
                    + " '" + (unit.SHIP_CERT_DEPARTID == null ? "" : unit.SHIP_CERT_DEPARTID.Replace("'", "''")) + "'"
                    + " , '" + (unit.SHIPCERTDEPARTNAME == null ? "" : unit.SHIPCERTDEPARTNAME.Replace("'", "''")) + "'"
                    + " , '" + (unit.COUNTRY == null ? "" : unit.COUNTRY.Replace("'", "''")) + "'"
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_SHIP_CERT_DEPART中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_SHIP_CERT_DEPART对象</param>
        public bool deleteUnit(ShipCertDepart unit, out string err)
        {
            return deleteUnit(unit.SHIP_CERT_DEPARTID, out err);
        }

        /// <summary>
        /// 删除数据表T_SHIP_CERT_DEPART中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_SHIP_CERT_DEPART.sHIP_CERT_DEPARTID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_SHIP_CERT_DEPART where "
                + " upper(T_SHIP_CERT_DEPART.SHIP_CERT_DEPARTID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_SHIP_CERT_DEPART 所有数据信息.
        /// </summary>
        /// <returns>T_SHIP_CERT_DEPART DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "SHIP_CERT_DEPARTID, "
                + "SHIPCERTDEPARTNAME, "
                + "COUNTRY "
                + "  from T_SHIP_CERT_DEPART "
                + " order by SHIPCERTDEPARTNAME";
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
        /// 根据一个主键ID,得到 T_SHIP_CERT_DEPART 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>ShipCertDepart DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "SHIP_CERT_DEPARTID, "
                + "SHIPCERTDEPARTNAME, "
                + "COUNTRY "
                + " from T_SHIP_CERT_DEPART "
                + " where upper(SHIP_CERT_DEPARTID)='" + Id.ToUpper() + "'";
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
        /// 根据shipcertdepart 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>shipcertdepart 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBoxEx.Show(o);
        public ShipCertDepart getObject(DataRow dr)
        {
            ShipCertDepart unit = new ShipCertDepart();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造ShipCertDepart类对象!";
                return unit;
            }
            if (DBNull.Value != dr["SHIP_CERT_DEPARTID"])
                unit.SHIP_CERT_DEPARTID = dr["SHIP_CERT_DEPARTID"].ToString();
            if (DBNull.Value != dr["SHIPCERTDEPARTNAME"])
                unit.SHIPCERTDEPARTNAME = dr["SHIPCERTDEPARTNAME"].ToString();
            if (DBNull.Value != dr["COUNTRY"])
                unit.COUNTRY = dr["COUNTRY"].ToString();
            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个ShipCertDepart对象.
        /// </summary>
        /// <param name="sHIP_CERT_DEPARTID">sHIP_CERT_DEPARTID</param>
        /// <returns>ShipCertDepart对象</returns>
        public ShipCertDepart getObject(string Id, out string err)
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
        #endregion

        #region IObjectsService 成员

        public CommonClass GetOneObjectById(string id)
        {
            string err;
            return getObject(id, out err);
        }

        public Dictionary<string, string> GetObjectDisplaySetting()
        {
            Dictionary<string, string> reValue = new Dictionary<string, string>();

            reValue.Add("COUNTRY", "所属国家或组织");
            reValue.Add("SHIPCERTDEPARTNAME", "机构名称或代码");
            return reValue;
        }

        #endregion

        public bool HaveNotTheDepart(string id, string departName, string departCountry, out string err)
        {
            string sql = "select count(1) from T_SHIP_CERT_DEPART " +
                    "\r where SHIPCERTDEPARTNAME = '" + departName.Replace("'", "''") + "' " +
                    (string.IsNullOrEmpty(id) ? "" : " and SHIP_CERT_DEPARTID <> '" + id + "'");

            err = "";
            if (dbAccess.GetString(sql) != "0")
            {
                err = "数据库中已经存在刚刚维护过的建议机构或检验机构代码，请保证其唯一性再进行录入！";
                return false;
            }
            else return true;
        }
    }
}
