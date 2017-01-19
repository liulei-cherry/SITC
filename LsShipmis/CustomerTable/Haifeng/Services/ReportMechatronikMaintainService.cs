/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：ReportMechatronikMaintainService.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/12/5
 * 标    题：数据操作类
 * 功能描述：T_REPORT_MECHATRONIK_MAINTAIN数据操作类
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
using CustomerTable.Haifeng.DataObject;

namespace CustomerTable.Haifeng.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_REPORT_MECHATRONIK_MAINTAINService.cs
    /// </summary>
    public partial class ReportMechatronikMaintainService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static ReportMechatronikMaintainService instance = new ReportMechatronikMaintainService();
        public static ReportMechatronikMaintainService Instance
        {
            get
            {
                if (null == instance)
                {
                    ReportMechatronikMaintainService.instance = new ReportMechatronikMaintainService();
                }
                return ReportMechatronikMaintainService.instance;
            }
        }
        private ReportMechatronikMaintainService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">ReportMechatronikMaintain对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(ReportMechatronikMaintain unit, out string err)
        {
            if (unit.REPORT_ID != null && unit.REPORT_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_REPORT_MECHATRONIK_MAINTAIN] SET "
                    + " [REPORT_ID] = " + (string.IsNullOrEmpty(unit.REPORT_ID) ? "null" : "'" + unit.REPORT_ID.Replace("'", "''") + "'")
                    + " , [FILE_ID] = " + (string.IsNullOrEmpty(unit.FILE_ID) ? "null" : "'" + unit.FILE_ID.Replace("'", "''") + "'")
                    + " , [FILE_DATE] = " + dbOperation.DbToDate(unit.FILE_DATE)
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , [VOYAGE] = " + (unit.VOYAGE == null ? "''" : "'" + unit.VOYAGE.Replace("'", "''") + "'")
                    + " , [REPORT_DATE] = " + dbOperation.DbToDate(unit.REPORT_DATE)
                    + " , [BEGIN_DATE] = " + dbOperation.DbToDate(unit.BEGIN_DATE)
                    + " , [END_DATE] = " + dbOperation.DbToDate(unit.END_DATE)
                    + " , [CHUAN_ZHANG] = " + (unit.CHUAN_ZHANG == null ? "''" : "'" + unit.CHUAN_ZHANG.Replace("'", "''") + "'")
                    + " , [LUN_JI_ZHANG] = " + (unit.LUN_JI_ZHANG == null ? "''" : "'" + unit.LUN_JI_ZHANG.Replace("'", "''") + "'")
                    + " , [DA_GUAN_LUN] = " + (unit.DA_GUAN_LUN == null ? "''" : "'" + unit.DA_GUAN_LUN.Replace("'", "''") + "'")
                    + " , [ER_GUAN_LUN] = " + (unit.ER_GUAN_LUN == null ? "''" : "'" + unit.ER_GUAN_LUN.Replace("'", "''") + "'")
                    + " , [SAN_GUAN_LUN] = " + (unit.SAN_GUAN_LUN == null ? "''" : "'" + unit.SAN_GUAN_LUN.Replace("'", "''") + "'")
                    + " , [DIAN_JI_YUAN] = " + (unit.DIAN_JI_YUAN == null ? "''" : "'" + unit.DIAN_JI_YUAN.Replace("'", "''") + "'")
                    + " , [USE_CONDITION] = " + (unit.USE_CONDITION == null ? "''" : "'" + unit.USE_CONDITION.Replace("'", "''") + "'")
                    + " , [UNDONE_PROJECT] = " + (unit.UNDONE_PROJECT == null ? "''" : "'" + unit.UNDONE_PROJECT.Replace("'", "''") + "'")
                    + " , [PROBLEM] = " + (unit.PROBLEM == null ? "''" : "'" + unit.PROBLEM.Replace("'", "''") + "'")
                    + " , [TEMPORARY_PROJECT] = " + (unit.TEMPORARY_PROJECT == null ? "''" : "'" + unit.TEMPORARY_PROJECT.Replace("'", "''") + "'")
                    + " , [VERIFY_SUGGESTION] = " + (unit.VERIFY_SUGGESTION == null ? "''" : "'" + unit.VERIFY_SUGGESTION.Replace("'", "''") + "'")
                    + " where upper(REPORT_ID) = '" + unit.REPORT_ID.ToUpper() + "'";
            }
            else
            {
                unit.REPORT_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_REPORT_MECHATRONIK_MAINTAIN] ("
                    + "[REPORT_ID],"
                    + "[FILE_ID],"
                    + "[FILE_DATE],"
                    + "[SHIP_ID],"
                    + "[VOYAGE],"
                    + "[REPORT_DATE],"
                    + "[BEGIN_DATE],"
                    + "[END_DATE],"
                    + "[CHUAN_ZHANG],"
                    + "[LUN_JI_ZHANG],"
                    + "[DA_GUAN_LUN],"
                    + "[ER_GUAN_LUN],"
                    + "[SAN_GUAN_LUN],"
                    + "[DIAN_JI_YUAN],"
                    + "[USE_CONDITION],"
                    + "[UNDONE_PROJECT],"
                    + "[PROBLEM],"
                    + "[TEMPORARY_PROJECT],"
                    + "[VERIFY_SUGGESTION]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.REPORT_ID) ? "null" : "'" + unit.REPORT_ID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.FILE_ID) ? "null" : "'" + unit.FILE_ID.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.FILE_DATE)
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , " + (unit.VOYAGE == null ? "''" : "'" + unit.VOYAGE.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.REPORT_DATE)
                    + " ," + dbOperation.DbToDate(unit.BEGIN_DATE)
                    + " ," + dbOperation.DbToDate(unit.END_DATE)
                    + " , " + (unit.CHUAN_ZHANG == null ? "''" : "'" + unit.CHUAN_ZHANG.Replace("'", "''") + "'")
                    + " , " + (unit.LUN_JI_ZHANG == null ? "''" : "'" + unit.LUN_JI_ZHANG.Replace("'", "''") + "'")
                    + " , " + (unit.DA_GUAN_LUN == null ? "''" : "'" + unit.DA_GUAN_LUN.Replace("'", "''") + "'")
                    + " , " + (unit.ER_GUAN_LUN == null ? "''" : "'" + unit.ER_GUAN_LUN.Replace("'", "''") + "'")
                    + " , " + (unit.SAN_GUAN_LUN == null ? "''" : "'" + unit.SAN_GUAN_LUN.Replace("'", "''") + "'")
                    + " , " + (unit.DIAN_JI_YUAN == null ? "''" : "'" + unit.DIAN_JI_YUAN.Replace("'", "''") + "'")
                    + " , " + (unit.USE_CONDITION == null ? "''" : "'" + unit.USE_CONDITION.Replace("'", "''") + "'")
                    + " , " + (unit.UNDONE_PROJECT == null ? "''" : "'" + unit.UNDONE_PROJECT.Replace("'", "''") + "'")
                    + " , " + (unit.PROBLEM == null ? "''" : "'" + unit.PROBLEM.Replace("'", "''") + "'")
                    + " , " + (unit.TEMPORARY_PROJECT == null ? "''" : "'" + unit.TEMPORARY_PROJECT.Replace("'", "''") + "'")
                    + " , " + (unit.VERIFY_SUGGESTION == null ? "''" : "'" + unit.VERIFY_SUGGESTION.Replace("'", "''") + "'")
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_REPORT_MECHATRONIK_MAINTAIN中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_REPORT_MECHATRONIK_MAINTAIN对象</param>
        internal bool deleteUnit(ReportMechatronikMaintain unit, out string err)
        {
            return deleteUnit(unit.REPORT_ID, out err);
        }

        /// <summary>
        /// 删除数据表T_REPORT_MECHATRONIK_MAINTAIN中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_REPORT_MECHATRONIK_MAINTAIN.rEPORT_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_REPORT_MECHATRONIK_MAINTAIN where "
                + " upper(T_REPORT_MECHATRONIK_MAINTAIN.REPORT_ID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_REPORT_MECHATRONIK_MAINTAIN 所有数据信息.
        /// </summary>
        /// <returns>T_REPORT_MECHATRONIK_MAINTAIN DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "REPORT_ID"
                + ",FILE_ID"
                + ",FILE_DATE"
                + ",SHIP_ID"
                + ",VOYAGE"
                + ",REPORT_DATE"
                + ",BEGIN_DATE"
                + ",END_DATE"
                + ",CHUAN_ZHANG"
                + ",LUN_JI_ZHANG"
                + ",DA_GUAN_LUN"
                + ",ER_GUAN_LUN"
                + ",SAN_GUAN_LUN"
                + ",DIAN_JI_YUAN"
                + ",USE_CONDITION"
                + ",UNDONE_PROJECT"
                + ",PROBLEM"
                + ",TEMPORARY_PROJECT"
                + ",VERIFY_SUGGESTION"
                + "  from T_REPORT_MECHATRONIK_MAINTAIN ";
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
        /// 根据一个主键ID,得到 T_REPORT_MECHATRONIK_MAINTAIN 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>ReportMechatronikMaintain DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "REPORT_ID"
                + ",FILE_ID"
                + ",FILE_DATE"
                + ",SHIP_ID"
                + ",VOYAGE"
                + ",REPORT_DATE"
                + ",BEGIN_DATE"
                + ",END_DATE"
                + ",CHUAN_ZHANG"
                + ",LUN_JI_ZHANG"
                + ",DA_GUAN_LUN"
                + ",ER_GUAN_LUN"
                + ",SAN_GUAN_LUN"
                + ",DIAN_JI_YUAN"
                + ",USE_CONDITION"
                + ",UNDONE_PROJECT"
                + ",PROBLEM"
                + ",TEMPORARY_PROJECT"
                + ",VERIFY_SUGGESTION"
                + " from T_REPORT_MECHATRONIK_MAINTAIN "
                + " where upper(REPORT_ID)='" + Id.ToUpper() + "'";
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
        /// 根据reportmechatronikmaintain 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>reportmechatronikmaintain 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
        public ReportMechatronikMaintain getObject(DataRow dr)
        {
            ReportMechatronikMaintain unit = new ReportMechatronikMaintain();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造ReportMechatronikMaintain类对象!";
                return unit;
            }
            if (DBNull.Value != dr["REPORT_ID"])
                unit.REPORT_ID = dr["REPORT_ID"].ToString();
            if (DBNull.Value != dr["FILE_ID"])
                unit.FILE_ID = dr["FILE_ID"].ToString();
            if (DBNull.Value != dr["FILE_DATE"])
                unit.FILE_DATE = (DateTime)dr["FILE_DATE"];
            if (DBNull.Value != dr["SHIP_ID"])
                unit.SHIP_ID = dr["SHIP_ID"].ToString();
            if (DBNull.Value != dr["VOYAGE"])
                unit.VOYAGE = dr["VOYAGE"].ToString();
            if (DBNull.Value != dr["REPORT_DATE"])
                unit.REPORT_DATE = (DateTime)dr["REPORT_DATE"];
            if (DBNull.Value != dr["BEGIN_DATE"])
                unit.BEGIN_DATE = (DateTime)dr["BEGIN_DATE"];
            if (DBNull.Value != dr["END_DATE"])
                unit.END_DATE = (DateTime)dr["END_DATE"];
            if (DBNull.Value != dr["CHUAN_ZHANG"])
                unit.CHUAN_ZHANG = dr["CHUAN_ZHANG"].ToString();
            if (DBNull.Value != dr["LUN_JI_ZHANG"])
                unit.LUN_JI_ZHANG = dr["LUN_JI_ZHANG"].ToString();
            if (DBNull.Value != dr["DA_GUAN_LUN"])
                unit.DA_GUAN_LUN = dr["DA_GUAN_LUN"].ToString();
            if (DBNull.Value != dr["ER_GUAN_LUN"])
                unit.ER_GUAN_LUN = dr["ER_GUAN_LUN"].ToString();
            if (DBNull.Value != dr["SAN_GUAN_LUN"])
                unit.SAN_GUAN_LUN = dr["SAN_GUAN_LUN"].ToString();
            if (DBNull.Value != dr["DIAN_JI_YUAN"])
                unit.DIAN_JI_YUAN = dr["DIAN_JI_YUAN"].ToString();
            if (DBNull.Value != dr["USE_CONDITION"])
                unit.USE_CONDITION = dr["USE_CONDITION"].ToString();
            if (DBNull.Value != dr["UNDONE_PROJECT"])
                unit.UNDONE_PROJECT = dr["UNDONE_PROJECT"].ToString();
            if (DBNull.Value != dr["PROBLEM"])
                unit.PROBLEM = dr["PROBLEM"].ToString();
            if (DBNull.Value != dr["TEMPORARY_PROJECT"])
                unit.TEMPORARY_PROJECT = dr["TEMPORARY_PROJECT"].ToString();
            if (DBNull.Value != dr["VERIFY_SUGGESTION"])
                unit.VERIFY_SUGGESTION = dr["VERIFY_SUGGESTION"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个ReportMechatronikMaintain对象.
        /// </summary>
        /// <param name="rEPORT_ID">rEPORT_ID</param>
        /// <returns>ReportMechatronikMaintain对象</returns>
        public ReportMechatronikMaintain getObject(string Id, out string err)
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
