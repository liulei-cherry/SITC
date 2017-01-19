/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：WorkModelTypeService.cs
 * 创 建 人：徐正本
 * 创建时间：2010-6-12
 * 标    题：数据操作类
 * 功能描述：WorkModelType数据操作类
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
    /// 数据层实例化接口类 dbo.WorkModelTypeService.cs
    /// </summary>
    public partial class WorkModelTypeService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static WorkModelTypeService instance = new WorkModelTypeService();
        public static WorkModelTypeService Instance
        {
            get
            {
                if (null == instance)
                {
                    WorkModelTypeService.instance = new WorkModelTypeService();
                }
                return WorkModelTypeService.instance;
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
        /// <param name="unit">WorkModelType对象</param>
        /// <returns>插入的对象更新</returns>	
        public bool saveUnit(WorkModelType unit, out string err)
        {
            if (unit.ModelID != null && unit.ModelID.Length > 0) //edit
            {
                sql = "UPDATE [T_WorkModelType] SET "
                    + " [ModelID] = '" + (unit.ModelID == null ? "" : unit.ModelID.Replace("'", "''")) + "'"
                    + " , [ModelName] = '" + (unit.ModelName == null ? "" : unit.ModelName.Replace("'", "''")) + "'"
                    + " , [type] = " + unit.type
                    + " , [ContentExp] = '" + (unit.ContentExp == null ? "" : unit.ContentExp.Replace("'", "''")) + "'"
                    + " , [ModelFile] = '" + (unit.ModelFile == null ? "" : unit.ModelFile.Replace("'", "''")) + "'"
                    + " , [DateCol] = " + unit.DateCol
                    + " , [Daterow] = " + unit.DateRow
                    + " , [SHIP_ID] = '" + (unit.SHIP_ID == null ? "" : unit.SHIP_ID.Replace("'", "''")) + "'"
                    + " where upper(ModelID) = '" + unit.ModelID.ToUpper() + "'";
            }
            else
            {
                unit.ModelID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_WorkModelType] ("
                    + "[ModelID],"
                    + "[ModelName],"
                    + "[type],"
                    + "[ContentExp],"
                    + "[ModelFile],"
                    + "[DateCol],"
                    + "[Daterow],"
                    + "[SHIP_ID]"
                    + ") VALUES( "
                    + " '" + (unit.ModelID == null ? "" : unit.ModelID.Replace("'", "''")) + "'"
                    + " , '" + (unit.ModelName == null ? "" : unit.ModelName.Replace("'", "''")) + "'"
                    + " ," + unit.type
                    + " , '" + (unit.ContentExp == null ? "" : unit.ContentExp.Replace("'", "''")) + "'"
                    + " , '" + (unit.ModelFile == null ? "" : unit.ModelFile.Replace("'", "''")) + "'"
                    + " ," + unit.DateCol
                    + " ," + unit.DateRow
                    + " , '" + (unit.SHIP_ID == null ? "" : unit.SHIP_ID.Replace("'", "''")) + "'"
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表WorkModelType中的对象.
        /// </summary>
        /// <param name="unit">要删除的WorkModelType对象</param>
        public bool deleteUnit(WorkModelType unit, out string err)
        {
            return deleteUnit(unit.ModelID, out err);
        }

        /// <summary>
        /// 删除数据表WorkModelType中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的WorkModelType.modelID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_WorkModelType where "
                + " upper(T_WorkModelType.ModelID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  WorkModelType 所有数据信息.
        /// </summary>
        /// <returns>WorkModelType DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "t.ModelID, "
                + "t.ModelName, "
                + "t.type, "
                + "t.ContentExp, "
                + "t.ModelFile, "
                + "t.DateCol, "
                + "t.Daterow, "
                + "t.SHIP_ID,"
                + "ship_name "
                + "\rfrom T_WorkModelType t inner join t_ship on t.ship_id = t_ship.ship_id";
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
        /// 根据一个主键ID,得到 WorkModelType 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>WorkModelType DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "ModelID, "
                + "ModelName, "
                + "type, "
                + "ContentExp, "
                + "ModelFile, "
                + "DateCol, "
                + "Daterow, "
                + "SHIP_ID"
                + " from T_WorkModelType "
                + " where upper(ModelID)='" + Id.ToUpper() + "'";
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
        /// 根据workmodeltype 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>workmodeltype 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBoxEx.Show(o);
        public WorkModelType getObject(DataRow dr)
        {
            WorkModelType unit = new WorkModelType();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造WorkModelType类对象!";
                return unit;
            }
            if (DBNull.Value != dr["ModelID"])
                unit.ModelID = dr["ModelID"].ToString();
            if (DBNull.Value != dr["ModelName"])
                unit.ModelName = dr["ModelName"].ToString();
            if (DBNull.Value != dr["type"])
                unit.type = Convert.ToDecimal(dr["type"]);
            if (DBNull.Value != dr["ContentExp"])
                unit.ContentExp = dr["ContentExp"].ToString();
            if (DBNull.Value != dr["ModelFile"])
                unit.ModelFile = dr["ModelFile"].ToString();
            if (DBNull.Value != dr["DateCol"])
                unit.DateCol = Convert.ToDecimal(dr["DateCol"]);
            if (DBNull.Value != dr["Daterow"])
                unit.DateRow = Convert.ToDecimal(dr["Daterow"]);
            if (DBNull.Value != dr["SHIP_ID"])
                unit.SHIP_ID = dr["SHIP_ID"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个WorkModelType对象.
        /// </summary>
        /// <param name="modelID">modelID</param>
        /// <returns>WorkModelType对象</returns>
        public WorkModelType getObject(string Id, out string err)
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
