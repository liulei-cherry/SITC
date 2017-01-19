/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：CostAccountPositionService.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/10/10
 * 标    题：数据操作类
 * 功能描述：T_COST_ACCOUNT_POSITION数据操作类
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
    /// 数据层实例化接口类 dbo.T_COST_ACCOUNT_POSITIONService.cs
    /// </summary>
    public partial class CostAccountPositionService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static CostAccountPositionService instance = new CostAccountPositionService();
        public static CostAccountPositionService Instance
        {
            get
            {
                if (null == instance)
                {
                    CostAccountPositionService.instance = new CostAccountPositionService();
                }
                return CostAccountPositionService.instance;
            }
        }
        private CostAccountPositionService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">CostAccountPosition对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(CostAccountPosition unit, out string err)
        {
            if (unit.POSITION_ID != null && unit.POSITION_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_COST_ACCOUNT_POSITION] SET "
                    + " [POSITION_ID] = " + (string.IsNullOrEmpty(unit.POSITION_ID) ? "null" : "'" + unit.POSITION_ID.Replace("'", "''") + "'")
                    + " , [NODE_ID] = " + (string.IsNullOrEmpty(unit.NODE_ID) ? "null" : "'" + unit.NODE_ID.Replace("'", "''") + "'")
                    + " , [CLASS] = " + (unit.CLASS == null ? "''" : "'" + unit.CLASS.Replace("'", "''") + "'")
                    + " , [ORDER_NUM] = " + unit.ORDER_NUM.ToString()
                    + " where upper(POSITION_ID) = '" + unit.POSITION_ID.ToUpper() + "'";
            }
            else
            {
                unit.POSITION_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_COST_ACCOUNT_POSITION] ("
                    + "[POSITION_ID],"
                    + "[NODE_ID],"
                    + "[CLASS],"
                    + "[ORDER_NUM]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.POSITION_ID) ? "null" : "'" + unit.POSITION_ID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.NODE_ID) ? "null" : "'" + unit.NODE_ID.Replace("'", "''") + "'")
                    + " , " + (unit.CLASS == null ? "''" : "'" + unit.CLASS.Replace("'", "''") + "'")
                    + " ," + unit.ORDER_NUM.ToString()
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_COST_ACCOUNT_POSITION中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_COST_ACCOUNT_POSITION对象</param>
        internal bool deleteUnit(CostAccountPosition unit, out string err)
        {
            return deleteUnit(unit.POSITION_ID, out err);
        }

        /// <summary>
        /// 删除数据表T_COST_ACCOUNT_POSITION中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_COST_ACCOUNT_POSITION.pOSITION_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_COST_ACCOUNT_POSITION where "
                + " upper(T_COST_ACCOUNT_POSITION.POSITION_ID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_COST_ACCOUNT_POSITION 所有数据信息.
        /// </summary>
        /// <returns>T_COST_ACCOUNT_POSITION DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "POSITION_ID"
                + ",NODE_ID"
                + ",CLASS"
                + ",ORDER_NUM"
                + "  from T_COST_ACCOUNT_POSITION ";
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
        /// 根据一个主键ID,得到 T_COST_ACCOUNT_POSITION 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>CostAccountPosition DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "POSITION_ID"
                + ",NODE_ID"
                + ",CLASS"
                + ",ORDER_NUM"
                + " from T_COST_ACCOUNT_POSITION "
                + " where upper(POSITION_ID)='" + Id.ToUpper() + "'";
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
        /// 根据costaccountposition 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>costaccountposition 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
        public CostAccountPosition getObject(DataRow dr)
        {
            CostAccountPosition unit = new CostAccountPosition();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造CostAccountPosition类对象!";
                return unit;
            }
            if (DBNull.Value != dr["POSITION_ID"])
                unit.POSITION_ID = dr["POSITION_ID"].ToString();
            if (DBNull.Value != dr["NODE_ID"])
                unit.NODE_ID = dr["NODE_ID"].ToString();
            if (DBNull.Value != dr["CLASS"])
                unit.CLASS = dr["CLASS"].ToString();
            if (DBNull.Value != dr["ORDER_NUM"])
                unit.ORDER_NUM = Convert.ToInt32(dr["ORDER_NUM"]);

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个CostAccountPosition对象.
        /// </summary>
        /// <param name="pOSITION_ID">pOSITION_ID</param>
        /// <returns>CostAccountPosition对象</returns>
        public CostAccountPosition getObject(string Id, out string err)
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
