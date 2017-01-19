/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：RepairDockRepairService.cs
 * 创 建 人：王鹏程
 * 创建时间：2012/4/12
 * 标    题：数据操作类
 * 功能描述：T_REPAIR_DOCKREPAIR数据操作类
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
using Repair.DataObject;

namespace Repair.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_REPAIR_DOCKREPAIRService.cs
    /// </summary>
    public partial class RepairDockRepairService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象
        /// </summary>
        private static RepairDockRepairService instance = new RepairDockRepairService();
        public static RepairDockRepairService Instance
        {
            get
            {
                if (null == instance)
                {
                    RepairDockRepairService.instance = new RepairDockRepairService();
                }
                return RepairDockRepairService.instance;
            }
        }
        private RepairDockRepairService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。
        /// </summary>
        /// <param name="unit">RepairDockRepair对象</param>
        /// <returns>插入的对象更新</returns>	
        public bool saveUnit(RepairDockRepair unit, out string err)
        {
            return dbAccess.ExecSql(saveUnitSql(unit), out err);
        }
        /// <summary>
        /// 向数据库中保存一条新记录。
        /// </summary>
        /// <param name="unit">RepairDockRepair对象</param>
        /// <returns>插入的对象更新</returns>	
        public void saveUnit(RepairDockRepair unit)
        {
            string err;
            if (!dbAccess.ExecSql(saveUnitSql(unit), out err))
                throw new Exception(err);
        }
        /// <summary>
        /// 返回向数据库中保存一条新记录的sql语句。做事务用。
        /// </summary>
        /// <param name="unit">RepairDockRepair对象</param>
        /// <returns>插入的对象更新</returns>	
        public string saveUnitSql(RepairDockRepair unit)
        {
            if (unit.REPAIR_DOCKREPAIR_ID != null && unit.REPAIR_DOCKREPAIR_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_REPAIR_DOCKREPAIR] SET "
                    + " [REPAIR_DOCKREPAIR_ID] = " + (string.IsNullOrEmpty(unit.REPAIR_DOCKREPAIR_ID) ? "null" : "'" + unit.REPAIR_DOCKREPAIR_ID.Replace("'", "''") + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , [REPAIR_ANNUAL] = " + (unit.REPAIR_ANNUAL == null ? "''" : "'" + unit.REPAIR_ANNUAL.Replace("'", "''") + "'")
                    + " , [REMARK] = " + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
                    + " where upper(REPAIR_DOCKREPAIR_ID) = '" + unit.REPAIR_DOCKREPAIR_ID.ToUpper() + "'";
            }
            else
            {
                unit.REPAIR_DOCKREPAIR_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_REPAIR_DOCKREPAIR] ("
                    + "[REPAIR_DOCKREPAIR_ID],"
                    + "[SHIP_ID],"
                    + "[REPAIR_ANNUAL],"
                    + "[REMARK]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.REPAIR_DOCKREPAIR_ID) ? "null" : "'" + unit.REPAIR_DOCKREPAIR_ID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , " + (unit.REPAIR_ANNUAL == null ? "''" : "'" + unit.REPAIR_ANNUAL.Replace("'", "''") + "'")
                    + " , " + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
                    + ")";
            }

            return sql;
        }

        /// <summary>
        /// 删除数据表T_REPAIR_DOCKREPAIR中的一条记录
        /// </summary>
        /// <param name="unit">要删除的T_REPAIR_DOCKREPAIR.rEPAIR_DOCKREPAIR_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            return dbAccess.ExecSql(deleteUnitSql(unitid), out err);
        }
        /// <summary>
        /// 删除数据表T_REPAIR_DOCKREPAIR中的一条记录
        /// </summary>
        /// <param name="unit">要删除的T_REPAIR_DOCKREPAIR.rEPAIR_DOCKREPAIR_ID主键</param>
        public void deleteUnit(string unitid)
        {
            string err;
            if (!dbAccess.ExecSql(deleteUnitSql(unitid), out err))
                throw new Exception(err);
        }

        /// <summary>
        /// 删除数据表T_REPAIR_DOCKREPAIR中的一条记录,返回sql语句
        /// </summary>
        /// <param name="unit">要删除的T_REPAIR_DOCKREPAIR.rEPAIR_DOCKREPAIR_ID主键</param>
        public string deleteUnitSql(string unitid)
        {
            sql = "delete from T_REPAIR_DOCKREPAIR where "
                + " upper(T_REPAIR_DOCKREPAIR.REPAIR_DOCKREPAIR_ID)='" + unitid.ToUpper() + "'";
            return sql;
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_REPAIR_DOCKREPAIR 所有数据信息
        /// </summary>
        /// <returns>T_REPAIR_DOCKREPAIR DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "REPAIR_DOCKREPAIR_ID"
                + ",SHIP_ID"
                + ",REPAIR_ANNUAL"
                + ",REMARK"
                + "  from T_REPAIR_DOCKREPAIR ";
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
        /// 根据一个主键ID,得到 T_REPAIR_DOCKREPAIR 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>RepairDockRepair DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "REPAIR_DOCKREPAIR_ID"
                + ",SHIP_ID"
                + ",REPAIR_ANNUAL"
                + ",REMARK"
                + " from T_REPAIR_DOCKREPAIR "
                + " where upper(REPAIR_DOCKREPAIR_ID)='" + Id.ToUpper() + "'";
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
        /// 根据repairdockrepair 的DataRow封装对象
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>repairdockrepair 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
        public RepairDockRepair getObject(DataRow dr)
        {
            RepairDockRepair unit = new RepairDockRepair();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造RepairDockRepair类对象!";
                return unit;
            }
            if (DBNull.Value != dr["REPAIR_DOCKREPAIR_ID"])
                unit.REPAIR_DOCKREPAIR_ID = dr["REPAIR_DOCKREPAIR_ID"].ToString();
            if (DBNull.Value != dr["SHIP_ID"])
                unit.SHIP_ID = dr["SHIP_ID"].ToString();
            if (DBNull.Value != dr["REPAIR_ANNUAL"])
                unit.REPAIR_ANNUAL = dr["REPAIR_ANNUAL"].ToString();
            if (DBNull.Value != dr["REMARK"])
                unit.REMARK = dr["REMARK"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个RepairDockRepair对象
        /// </summary>
        /// <param name="rEPAIR_DOCKREPAIR_ID">rEPAIR_DOCKREPAIR_ID</param>
        /// <returns>RepairDockRepair对象</returns>
        public RepairDockRepair getObject(string Id, out string err)
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
