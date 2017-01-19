/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：ShipHoldService.cs
 * 创 建 人：shengwen
 * 创建时间：2009-11-11
 * 标    题：数据操作类
 * 功能描述：T_SHIP_HOLD数据操作类
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
    /// 数据层实例化接口类 dbo.T_SHIP_HOLDService.cs
    /// </summary>
    public partial class ShipHoldService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static ShipHoldService instance = new ShipHoldService();
        public static ShipHoldService Instance
        {
            get
            {
                if (null == instance)
                {
                    ShipHoldService.instance = new ShipHoldService();
                }
                return ShipHoldService.instance;
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
        /// <param name="unit">ShipHold对象</param>
        /// <returns>插入的对象更新</returns>	
        public bool saveUnit(ShipHold unit, out string err)
        {
            if (unit.HOLD_ID != null && unit.HOLD_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_SHIP_HOLD] SET "
                    + " [HOLD_ID] = '" + (unit.HOLD_ID == null ? "" : unit.HOLD_ID.Replace("'", "''")) + "'"
                    + " , [SHIP_ID] = '" + (unit.SHIP_ID == null ? "" : unit.SHIP_ID.Replace("'", "''")) + "'"
                    + " , [HCBH] = '" + (unit.HCBH == null ? "" : unit.HCBH.Replace("'", "''")) + "'"
                    + " , [CKCD] = " + unit.CKCD
                    + " , [CKKD] = " + unit.CKKD
                    + " , [CNCD] = " + unit.CNCD
                    + " , [CNKD] = " + unit.CNKD
                    + " , [CNGD] = " + unit.CNGD
                    + " , [SZRJ] = " + unit.SZRJ
                    + " , [BZRJ] = " + unit.BZRJ
                    + " , [QHSB] = " + unit.QHSB
                    + " , [REMARK] = '" + (unit.REMARK == null ? "" : unit.REMARK.Replace("'", "''")) + "'"
                    + " where upper(HOLD_ID) = '" + unit.HOLD_ID.ToUpper() + "'";
            }
            else
            {
                unit.HOLD_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_SHIP_HOLD] ("
                    + "[HOLD_ID],"
                    + "[SHIP_ID],"
                    + "[HCBH],"
                    + "[CKCD],"
                    + "[CKKD],"
                    + "[CNCD],"
                    + "[CNKD],"
                    + "[CNGD],"
                    + "[SZRJ],"
                    + "[BZRJ],"
                    + "[QHSB],"
                    + "[REMARK]"
                    + ") VALUES( "
                    + " '" + (unit.HOLD_ID == null ? "" : unit.HOLD_ID.Replace("'", "''")) + "'"
                    + " , '" + (unit.SHIP_ID == null ? "" : unit.SHIP_ID.Replace("'", "''")) + "'"
                    + " , '" + (unit.HCBH == null ? "" : unit.HCBH.Replace("'", "''")) + "'"
                    + " ," + unit.CKCD
                    + " ," + unit.CKKD
                    + " ," + unit.CNCD
                    + " ," + unit.CNKD
                    + " ," + unit.CNGD
                    + " ," + unit.SZRJ
                    + " ," + unit.BZRJ
                    + " ," + unit.QHSB
                    + " , '" + (unit.REMARK == null ? "" : unit.REMARK.Replace("'", "''")) + "'"
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_SHIP_HOLD中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_SHIP_HOLD对象</param>
        public bool deleteUnit(ShipHold unit, out string err)
        {
            return deleteUnit(unit.HOLD_ID, out err);
        }

        /// <summary>
        /// 删除数据表T_SHIP_HOLD中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_SHIP_HOLD.hOLD_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_SHIP_HOLD where "
                + " upper(T_SHIP_HOLD.HOLD_ID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_SHIP_HOLD 所有数据信息.
        /// </summary>
        /// <returns>T_SHIP_HOLD DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "HOLD_ID, "
                + "SHIP_ID, "
                + "HCBH, "
                + "CKCD, "
                + "CKKD, "
                + "CNCD, "
                + "CNKD, "
                + "CNGD, "
                + "SZRJ, "
                + "BZRJ, "
                + "QHSB, "
                + "REMARK "
                + "  from T_SHIP_HOLD ";
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
        /// 根据一个主键ID,得到 T_SHIP_HOLD 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>ShipHold DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "HOLD_ID, "
                + "SHIP_ID, "
                + "HCBH, "
                + "CKCD, "
                + "CKKD, "
                + "CNCD, "
                + "CNKD, "
                + "CNGD, "
                + "SZRJ, "
                + "BZRJ, "
                + "QHSB, "
                + "REMARK, "
                + "CREATOR "
                + " from T_SHIP_HOLD "
                + " where upper(HOLD_ID)='" + Id.ToUpper() + "'";
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
        /// 根据shiphold 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>shiphold 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBoxEx.Show(o);
        public ShipHold getObject(DataRow dr)
        {
            ShipHold unit = new ShipHold();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造ShipHold类对象!";
                return unit;
            }
            if (DBNull.Value != dr["HOLD_ID"])
                unit.HOLD_ID = dr["HOLD_ID"].ToString();
            if (DBNull.Value != dr["SHIP_ID"])
                unit.SHIP_ID = dr["SHIP_ID"].ToString();
            if (DBNull.Value != dr["HCBH"])
                unit.HCBH = dr["HCBH"].ToString();
            if (DBNull.Value != dr["CKCD"])
                unit.CKCD = Convert.ToDecimal(dr["CKCD"]);
            if (DBNull.Value != dr["CKKD"])
                unit.CKKD = Convert.ToDecimal(dr["CKKD"]);
            if (DBNull.Value != dr["CNCD"])
                unit.CNCD = Convert.ToDecimal(dr["CNCD"]);
            if (DBNull.Value != dr["CNKD"])
                unit.CNKD = Convert.ToDecimal(dr["CNKD"]);
            if (DBNull.Value != dr["CNGD"])
                unit.CNGD = Convert.ToDecimal(dr["CNGD"]);
            if (DBNull.Value != dr["SZRJ"])
                unit.SZRJ = Convert.ToDecimal(dr["SZRJ"]);
            if (DBNull.Value != dr["BZRJ"])
                unit.BZRJ = Convert.ToDecimal(dr["BZRJ"]);
            if (DBNull.Value != dr["QHSB"])
                unit.QHSB = Convert.ToDecimal(dr["QHSB"]);
            if (DBNull.Value != dr["REMARK"])
                unit.REMARK = dr["REMARK"].ToString();
            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个ShipHold对象.
        /// </summary>
        /// <param name="hOLD_ID">hOLD_ID</param>
        /// <returns>ShipHold对象</returns>
        public ShipHold getObject(string Id, out string err)
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
