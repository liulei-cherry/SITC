/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：MaterialInfoService.cs
 * 创 建 人：徐正本
 * 创建时间：2011/8/16
 * 标    题：数据操作类
 * 功能描述：T_MATERIAL数据操作类
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
using ItemsManage.DataObject;

namespace ItemsManage.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_MATERIALService.cs
    /// </summary>
    public partial class MaterialInfoService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static MaterialInfoService instance = new MaterialInfoService();
        public static MaterialInfoService Instance
        {
            get
            {
                if (null == instance)
                {
                    MaterialInfoService.instance = new MaterialInfoService();
                }
                return MaterialInfoService.instance;
            }
        }
        private MaterialInfoService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">MaterialInfo对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(MaterialInfo unit, out string err)
        {
            if (unit.MATERIAL_ID != null && unit.MATERIAL_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_MATERIAL] SET "
                    + " [MATERIAL_ID] = " + (string.IsNullOrEmpty(unit.MATERIAL_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.MATERIAL_ID) + "'")
                    + " , [MATERIAL_TYPE_ID] = " + (string.IsNullOrEmpty(unit.MATERIAL_TYPE_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.MATERIAL_TYPE_ID) + "'")
                    + " , [MATERIAL_CODE] = " + (unit.MATERIAL_CODE == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.MATERIAL_CODE) + "'")
                    + " , [MATERIAL_NAME] = N" + (unit.MATERIAL_NAME == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.MATERIAL_NAME) + "'")
                    + " , [MATERIAL_SPEC] = N" + (unit.MATERIAL_SPEC == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.MATERIAL_SPEC) + "'")
                    + " , [UNIT_NAME] = " + (unit.UNIT_NAME == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.UNIT_NAME) + "'")
                    + " , [REMARK] = N" + (unit.REMARK == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.REMARK) + "'")
                    + "\rwhere MATERIAL_ID = '" + dbOperation.ReplaceSqlKeyStr(unit.MATERIAL_ID) + "'";
            }
            else
            {
                unit.MATERIAL_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_MATERIAL] ("
                    + "[MATERIAL_ID],"
                    + "[MATERIAL_TYPE_ID],"
                    + "[MATERIAL_CODE],"
                    + "[MATERIAL_NAME],"
                    + "[MATERIAL_SPEC],"
                    + "[UNIT_NAME],"
                    + "[REMARK]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.MATERIAL_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.MATERIAL_ID) + "'")
                    + " , " + (string.IsNullOrEmpty(unit.MATERIAL_TYPE_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.MATERIAL_TYPE_ID) + "'")
                    + " , " + (unit.MATERIAL_CODE == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.MATERIAL_CODE) + "'")
                    + " , N" + (unit.MATERIAL_NAME == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.MATERIAL_NAME) + "'")
                    + " , N" + (unit.MATERIAL_SPEC == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.MATERIAL_SPEC) + "'")
                    + " , " + (unit.UNIT_NAME == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.UNIT_NAME) + "'")
                    + " , N" + (unit.REMARK == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.REMARK) + "'")
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_MATERIAL中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_MATERIAL对象</param>
        internal bool deleteUnit(MaterialInfo unit, out string err)
        {
            return deleteUnit(unit.MATERIAL_ID, out err);
        }

        /// <summary>
        /// 删除数据表T_MATERIAL中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_MATERIAL.mATERIAL_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_MATERIAL where MATERIAL_ID='" + dbOperation.ReplaceSqlKeyStr(unitid) + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 提交SQL执行. 2014.2.21 刘子建增加.
        /// </summary>
        /// <param name="lstSQL"></param>
        /// <param name="err"></param>
        public bool SubmitSql(List<string> lstSQL, out string err)
        {
            return dbAccess.ExecSql(lstSQL, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_MATERIAL 所有数据信息.
        /// </summary>
        /// <returns>T_MATERIAL DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "MATERIAL_ID"
                + ",MATERIAL_TYPE_ID"
                + ",MATERIAL_CODE"
                + ",MATERIAL_NAME"
                + ",MATERIAL_SPEC"
                + ",UNIT_NAME"
                + ",REMARK"
                + "\rfrom T_MATERIAL where ISVALID=1";
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
        /// 根据一个主键ID,得到 T_MATERIAL 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>MaterialInfo DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "MATERIAL_ID"
                + ",MATERIAL_TYPE_ID"
                + ",MATERIAL_CODE"
                + ",MATERIAL_NAME"
                + ",MATERIAL_SPEC"
                + ",UNIT_NAME"
                + ",REMARK"
                + "\rfrom T_MATERIAL "
                + "\rwhere MATERIAL_ID='" + dbOperation.ReplaceSqlKeyStr(Id) + "'";
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
        /// 根据materialinfo 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>materialinfo 数据实体</returns>
        public MaterialInfo getObject(DataRow dr)
        {
            MaterialInfo unit = new MaterialInfo();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造MaterialInfo类对象!";
                return unit;
            }
            if (DBNull.Value != dr["MATERIAL_ID"])
                unit.MATERIAL_ID = dr["MATERIAL_ID"].ToString();
            if (DBNull.Value != dr["MATERIAL_TYPE_ID"])
                unit.MATERIAL_TYPE_ID = dr["MATERIAL_TYPE_ID"].ToString();
            if (DBNull.Value != dr["MATERIAL_CODE"])
                unit.MATERIAL_CODE = dr["MATERIAL_CODE"].ToString();
            if (DBNull.Value != dr["MATERIAL_NAME"])
                unit.MATERIAL_NAME = dr["MATERIAL_NAME"].ToString();
            if (DBNull.Value != dr["MATERIAL_SPEC"])
                unit.MATERIAL_SPEC = dr["MATERIAL_SPEC"].ToString();
            if (DBNull.Value != dr["UNIT_NAME"])
                unit.UNIT_NAME = dr["UNIT_NAME"].ToString();
            if (DBNull.Value != dr["REMARK"])
                unit.REMARK = dr["REMARK"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个MaterialInfo对象.
        /// </summary>
        /// <param name="mATERIAL_ID">mATERIAL_ID</param>
        /// <returns>MaterialInfo对象</returns>
        public MaterialInfo getObject(string Id, out string err)
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
