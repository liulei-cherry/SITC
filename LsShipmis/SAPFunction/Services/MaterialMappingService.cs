/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：MaterialMappingService.cs
 * 创 建 人：王鹏程
 * 创建时间：2012/3/22
 * 标    题：数据操作类
 * 功能描述：T_MATERIAL_MAPPING数据操作类
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
    /// 数据层实例化接口类 dbo.T_MATERIAL_MAPPINGService.cs
    /// </summary>
    public partial class MaterialMappingService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static MaterialMappingService instance = new MaterialMappingService();
        public static MaterialMappingService Instance
        {
            get
            {
                if (null == instance)
                {
                    MaterialMappingService.instance = new MaterialMappingService();
                }
                return MaterialMappingService.instance;
            }
        }
        private MaterialMappingService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">MaterialMapping对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(MaterialMapping unit, out string err)
        {
            return dbAccess.ExecSql(saveUnit(unit), out err);
        }
        /// <summary>
        /// 返回向数据库中保存一条新记录的sql语句。做事务用。.
        /// </summary>
        /// <param name="unit">MaterialMapping对象</param>
        /// <returns>插入的对象更新</returns>	
        internal string saveUnit(MaterialMapping unit)
        {
            if (unit.MATERIAL_MAPPING_ID != null && unit.MATERIAL_MAPPING_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_MATERIAL_MAPPING] SET "
                    + " [MATERIAL_MAPPING_ID] = " + (string.IsNullOrEmpty(unit.MATERIAL_MAPPING_ID) ? "null" : "'" + unit.MATERIAL_MAPPING_ID.Replace("'", "''") + "'")
                    + " , [MANAGEMENT] = " + (unit.MANAGEMENT == null ? "''" : "'" + unit.MANAGEMENT.Replace("'", "''") + "'")
                    + " , [MATERIAL_FINANCE] = " + (unit.MATERIAL_FINANCE == null ? "''" : "'" + unit.MATERIAL_FINANCE.Replace("'", "''") + "'")
                    + " , [COST_FINANCE] = " + (unit.COST_FINANCE == null ? "''" : "'" + unit.COST_FINANCE.Replace("'", "''") + "'")
                    + " , [STATUS] = " + (unit.STATUS == null ? "''" : "'" + unit.STATUS.Replace("'", "''") + "'")
                    + " where upper(MATERIAL_MAPPING_ID) = '" + unit.MATERIAL_MAPPING_ID.ToUpper() + "'";
            }
            else
            {
                unit.MATERIAL_MAPPING_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_MATERIAL_MAPPING] ("
                    + "[MATERIAL_MAPPING_ID],"
                    + "[MANAGEMENT],"
                    + "[MATERIAL_FINANCE],"
                    + "[COST_FINANCE],"
                    + "[STATUS]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.MATERIAL_MAPPING_ID) ? "null" : "'" + unit.MATERIAL_MAPPING_ID.Replace("'", "''") + "'")
                    + " , " + (unit.MANAGEMENT == null ? "''" : "'" + unit.MANAGEMENT.Replace("'", "''") + "'")
                    + " , " + (unit.MATERIAL_FINANCE == null ? "''" : "'" + unit.MATERIAL_FINANCE.Replace("'", "''") + "'")
                    + " , " + (unit.COST_FINANCE == null ? "''" : "'" + unit.COST_FINANCE.Replace("'", "''") + "'")
                    + " , " + (unit.STATUS == null ? "''" : "'" + unit.STATUS.Replace("'", "''") + "'")
                    + ")";
            }

            return sql;
        }
        /// <summary>
        /// 删除数据表T_MATERIAL_MAPPING中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_MATERIAL_MAPPING对象</param>
        internal bool deleteUnit(MaterialMapping unit, out string err)
        {
            return deleteUnit(unit.MATERIAL_MAPPING_ID, out err);
        }

        /// <summary>
        /// 删除数据表T_MATERIAL_MAPPING中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_MATERIAL_MAPPING.mATERIAL_MAPPING_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_MATERIAL_MAPPING where "
                + " upper(T_MATERIAL_MAPPING.MATERIAL_MAPPING_ID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_MATERIAL_MAPPING 所有数据信息.
        /// </summary>
        /// <returns>T_MATERIAL_MAPPING DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "MATERIAL_MAPPING_ID"
                + ",MANAGEMENT"
                + ",MATERIAL_FINANCE"
                + ",COST_FINANCE"
                + ",STATUS"
                + "  from T_MATERIAL_MAPPING ";
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
        /// 根据一个主键ID,得到 T_MATERIAL_MAPPING 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>MaterialMapping DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "MATERIAL_MAPPING_ID"
                + ",MANAGEMENT"
                + ",MATERIAL_FINANCE"
                + ",COST_FINANCE"
                + ",STATUS"
                + " from T_MATERIAL_MAPPING "
                + " where upper(MATERIAL_MAPPING_ID)='" + Id.ToUpper() + "'";
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
        /// 根据materialmapping 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>materialmapping 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
        public MaterialMapping getObject(DataRow dr)
        {
            MaterialMapping unit = new MaterialMapping();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造MaterialMapping类对象!";
                return unit;
            }
            if (DBNull.Value != dr["MATERIAL_MAPPING_ID"])
                unit.MATERIAL_MAPPING_ID = dr["MATERIAL_MAPPING_ID"].ToString();
            if (DBNull.Value != dr["MANAGEMENT"])
                unit.MANAGEMENT = dr["MANAGEMENT"].ToString();
            if (DBNull.Value != dr["MATERIAL_FINANCE"])
                unit.MATERIAL_FINANCE = dr["MATERIAL_FINANCE"].ToString();
            if (DBNull.Value != dr["COST_FINANCE"])
                unit.COST_FINANCE = dr["COST_FINANCE"].ToString();
            if (DBNull.Value != dr["STATUS"])
                unit.STATUS = dr["STATUS"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个MaterialMapping对象.
        /// </summary>
        /// <param name="mATERIAL_MAPPING_ID">mATERIAL_MAPPING_ID</param>
        /// <returns>MaterialMapping对象</returns>
        public MaterialMapping getObject(string Id, out string err)
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
