/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：ShipOilWareHouseService.cs
 * 创 建 人：shengwen
 * 创建时间：2009-11-11
 * 标    题：数据操作类
 * 功能描述：T_SHIP_owWareHouse数据操作类
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

namespace BaseInfo.DataAccess
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_SHIP_owWareHouseService.cs
    /// </summary>
    public partial class ShipOilWareHouseService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static ShipOilWareHouseService instance = new ShipOilWareHouseService();
        public static ShipOilWareHouseService Instance
        {
            get
            {
                if (null == instance)
                {
                    ShipOilWareHouseService.instance = new ShipOilWareHouseService();
                }
                return ShipOilWareHouseService.instance;
            }
        }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region -----------实例化接口函数-----------

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">ShipOilWareHouse对象</param>
        /// <returns>插入的对象更新</returns>	
        public bool saveUnit(ShipOilWareHouse unit, out string err)
        {
            if (unit.owWareHouse_ID != null && unit.owWareHouse_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_SHIP_owWareHouse] SET "
                    + " [owWareHouse_ID] = '" + (unit.owWareHouse_ID == null ? "" : unit.owWareHouse_ID.Replace("'", "''")) + "'"
                    + " , [SHIP_ID] = '" + (unit.SHIP_ID == null ? "" : unit.SHIP_ID.Replace("'", "''")) + "'"
                    + " , [CGXH] = '" + (unit.CGXH == null ? "" : unit.CGXH.Replace("'", "''")) + "'"
                    + " , [XRJ] = " + unit.XRJ
                    + " , [JRJ] = " + unit.JRJ
                    + " , [WZ] = '" + (unit.WZ == null ? "" : unit.WZ.Replace("'", "''")) + "'"
                    + " , [REMARK] = '" + (unit.REMARK == null ? "" : unit.REMARK.Replace("'", "''")) + "'"
                    + " where upper(owWareHouse_ID) = '" + unit.owWareHouse_ID.ToUpper() + "'";
            }
            else
            {
                unit.owWareHouse_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_SHIP_owWareHouse] ("
                    + "[owWareHouse_ID],"
                    + "[SHIP_ID],"
                    + "[CGXH],"
                    + "[XRJ],"
                    + "[JRJ],"
                    + "[WZ],"
                    + "[REMARK]"
                    + ") VALUES( "
                    + " '" + (unit.owWareHouse_ID == null ? "" : unit.owWareHouse_ID.Replace("'", "''")) + "'"
                    + " , '" + (unit.SHIP_ID == null ? "" : unit.SHIP_ID.Replace("'", "''")) + "'"
                    + " , '" + (unit.CGXH == null ? "" : unit.CGXH.Replace("'", "''")) + "'"
                    + " ," + unit.XRJ
                    + " ," + unit.JRJ
                    + " , '" + (unit.WZ == null ? "" : unit.WZ.Replace("'", "''")) + "'"
                    + " , '" + (unit.REMARK == null ? "" : unit.REMARK.Replace("'", "''")) + "'"
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_SHIP_owWareHouse中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_SHIP_owWareHouse对象</param>
        public bool deleteUnit(ShipOilWareHouse unit, out string err)
        {
            return deleteUnit(unit.owWareHouse_ID, out err);
        }

        /// <summary>
        /// 删除数据表T_SHIP_owWareHouse中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_SHIP_owWareHouse.owWareHouse_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_SHIP_owWareHouse where "
                + " upper(T_SHIP_owWareHouse.owWareHouse_ID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_SHIP_owWareHouse 所有数据信息.
        /// </summary>
        /// <returns>T_SHIP_owWareHouse DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "owWareHouse_ID, "
                + "SHIP_ID, "
                + "CGXH, "
                + "XRJ, "
                + "JRJ, "
                + "WZ, "
                + "REMARK "
                + "  from T_SHIP_owWareHouse ";
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
        /// 根据一个主键ID,得到 T_SHIP_owWareHouse 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>ShipOilWareHouse DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "owWareHouse_ID, "
                + "SHIP_ID, "
                + "CGXH, "
                + "XRJ, "
                + "JRJ, "
                + "WZ, "
                + "REMARK "
                + " from T_SHIP_owWareHouse "
                + " where upper(owWareHouse_ID)='" + Id.ToUpper() + "'";
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
        /// 根据shipOilWareHouse 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>shipOilWareHouse 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBoxEx.Show(o);
        public ShipOilWareHouse getObject(DataRow dr)
        {
            ShipOilWareHouse unit = new ShipOilWareHouse();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造ShipOilWareHouse类对象!";
                return unit;
            }
            if (DBNull.Value != dr["owWareHouse_ID"])
                unit.owWareHouse_ID = dr["owWareHouse_ID"].ToString();
            if (DBNull.Value != dr["SHIP_ID"])
                unit.SHIP_ID = dr["SHIP_ID"].ToString();
            if (DBNull.Value != dr["CGXH"])
                unit.CGXH = dr["CGXH"].ToString();
            if (DBNull.Value != dr["XRJ"])
                unit.XRJ = Convert.ToDecimal(dr["XRJ"]);
            if (DBNull.Value != dr["JRJ"])
                unit.JRJ = Convert.ToDecimal(dr["JRJ"]);
            if (DBNull.Value != dr["WZ"])
                unit.WZ = dr["WZ"].ToString();
            if (DBNull.Value != dr["REMARK"])
                unit.REMARK = dr["REMARK"].ToString();
            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个ShipOilWareHouse对象.
        /// </summary>
        /// <param name="owWareHouse_ID">owWareHouse_ID</param>
        /// <returns>ShipOilWareHouse对象</returns>
        public ShipOilWareHouse getObject(string Id, out string err)
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
    }
}
