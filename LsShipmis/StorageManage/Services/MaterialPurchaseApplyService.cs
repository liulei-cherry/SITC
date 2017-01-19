/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：MaterialPurchaseApplyService.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/9/18
 * 标    题：数据操作类
 * 功能描述：T_MATERIAL_PURCHASE_APPLY数据操作类
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
using StorageManage.DataObject;

namespace StorageManage.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_MATERIAL_PURCHASE_APPLYService.cs
    /// </summary>
    public partial class MaterialPurchaseApplyService
    {
        #region 构造函数

        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static MaterialPurchaseApplyService instance = new MaterialPurchaseApplyService();
        public static MaterialPurchaseApplyService Instance
        {
            get
            {
                if (null == instance)
                {
                    MaterialPurchaseApplyService.instance = new MaterialPurchaseApplyService();
                }
                return MaterialPurchaseApplyService.instance;
            }
        }
        private MaterialPurchaseApplyService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">MaterialPurchaseApply对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(MaterialPurchaseApply unit, out string err)
        {
            if (unit.PURCHASE_APPLYID != null && unit.PURCHASE_APPLYID.Length > 0) //edit
            {
                sql = "UPDATE [T_MATERIAL_PURCHASE_APPLY] SET "
                    + " [PURCHASE_APPLYID] = " + (string.IsNullOrEmpty(unit.PURCHASE_APPLYID) ? "null" : "'" + unit.PURCHASE_APPLYID.Replace("'", "''") + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , [PURCHASE_APPLY_CODE] = " + (unit.PURCHASE_APPLY_CODE == null ? "''" : "'" + unit.PURCHASE_APPLY_CODE.Replace("'", "''") + "'")
                    + " , [PURCHASE_APPLY_PERSON] = " + (unit.PURCHASE_APPLY_PERSON == null ? "''" : "'" + unit.PURCHASE_APPLY_PERSON.Replace("'", "''") + "'")
                    + " , [PURCHASE_APPLY_PERSON_POSTID] = " + (string.IsNullOrEmpty(unit.PURCHASE_APPLY_PERSON_POSTID) ? "null" : "'" + unit.PURCHASE_APPLY_PERSON_POSTID.Replace("'", "''") + "'")
                    + " , [PURCHASE_APPLY_DATE] = " + dbOperation.DbToDate(unit.PURCHASE_APPLY_DATE)
                    + " , [DEPART_ID] = " + (string.IsNullOrEmpty(unit.DEPART_ID) ? "null" : "'" + unit.DEPART_ID.Replace("'", "''") + "'")
                    + " , [SHIP_LEADER_CHECKER] = " + (unit.SHIP_LEADER_CHECKER == null ? "''" : "'" + unit.SHIP_LEADER_CHECKER.Replace("'", "''") + "'")
                    + " , [SHIP_LEADER_CHECKDATE] = " + dbOperation.DbToDate(unit.SHIP_LEADER_CHECKDATE)
                    + " , [SHIP_BOSS_CHECKER] = " + (unit.SHIP_BOSS_CHECKER == null ? "''" : "'" + unit.SHIP_BOSS_CHECKER.Replace("'", "''") + "'")
                    + " , [SHIP_BOSS_CHECKDATE] = " + dbOperation.DbToDate(unit.SHIP_BOSS_CHECKDATE)
                    + " , [LANDCHECKER] = " + (unit.LANDCHECKER == null ? "''" : "'" + unit.LANDCHECKER.Replace("'", "''") + "'")
                    + " , [CHECKDATE] = " + dbOperation.DbToDate(unit.CHECKDATE)
                    + " , [ISCOMPLETE] = " + unit.ISCOMPLETE.ToString()
                    + " , [REMARK] = N" + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
                    + " , [STATE] = " + unit.STATE.ToString()
                    + " where upper(PURCHASE_APPLYID) = '" + unit.PURCHASE_APPLYID.ToUpper() + "'";
            }
            else
            {
                unit.PURCHASE_APPLYID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_MATERIAL_PURCHASE_APPLY] ("
                    + "[PURCHASE_APPLYID],"
                    + "[SHIP_ID],"
                    + "[PURCHASE_APPLY_CODE],"
                    + "[PURCHASE_APPLY_PERSON],"
                    + "[PURCHASE_APPLY_PERSON_POSTID],"
                    + "[PURCHASE_APPLY_DATE],"
                    + "[DEPART_ID],"
                    + "[SHIP_LEADER_CHECKER],"
                    + "[SHIP_LEADER_CHECKDATE],"
                    + "[SHIP_BOSS_CHECKER],"
                    + "[SHIP_BOSS_CHECKDATE],"
                    + "[LANDCHECKER],"
                    + "[CHECKDATE],"
                    + "[ISCOMPLETE],"
                    + "[REMARK],"
                    + "[STATE]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.PURCHASE_APPLYID) ? "null" : "'" + unit.PURCHASE_APPLYID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , " + (unit.PURCHASE_APPLY_CODE == null ? "''" : "'" + unit.PURCHASE_APPLY_CODE.Replace("'", "''") + "'")
                    + " , " + (unit.PURCHASE_APPLY_PERSON == null ? "''" : "'" + unit.PURCHASE_APPLY_PERSON.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.PURCHASE_APPLY_PERSON_POSTID) ? "null" : "'" + unit.PURCHASE_APPLY_PERSON_POSTID.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.PURCHASE_APPLY_DATE)
                    + " , " + (string.IsNullOrEmpty(unit.DEPART_ID) ? "null" : "'" + unit.DEPART_ID.Replace("'", "''") + "'")
                    + " , " + (unit.SHIP_LEADER_CHECKER == null ? "''" : "'" + unit.SHIP_LEADER_CHECKER.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.SHIP_LEADER_CHECKDATE)
                    + " , " + (unit.SHIP_BOSS_CHECKER == null ? "''" : "'" + unit.SHIP_BOSS_CHECKER.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.SHIP_BOSS_CHECKDATE)
                    + " , " + (unit.LANDCHECKER == null ? "''" : "'" + unit.LANDCHECKER.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.CHECKDATE)
                    + " ," + unit.ISCOMPLETE.ToString()
                    + " , N" + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
                    + " ," + unit.STATE.ToString()
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }

        /// <summary>
        /// 返回向数据库中保存一条新记录的SQL语句。. 2014.2.21刘子建增加.
        /// </summary>
        /// <param name="unit">MaterialPurchaseApply对象</param>
        /// <returns>插入的对象更新</returns>	
        internal string saveUnit(MaterialPurchaseApply unit)
        {
            if (unit.PURCHASE_APPLYID != null && unit.PURCHASE_APPLYID.Length > 0) //edit
            {
                sql = "UPDATE [T_MATERIAL_PURCHASE_APPLY] SET "
                    + " [PURCHASE_APPLYID] = " + (string.IsNullOrEmpty(unit.PURCHASE_APPLYID) ? "null" : "'" + unit.PURCHASE_APPLYID.Replace("'", "''") + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , [PURCHASE_APPLY_CODE] = " + (unit.PURCHASE_APPLY_CODE == null ? "''" : "'" + unit.PURCHASE_APPLY_CODE.Replace("'", "''") + "'")
                    + " , [PURCHASE_APPLY_PERSON] = " + (unit.PURCHASE_APPLY_PERSON == null ? "''" : "'" + unit.PURCHASE_APPLY_PERSON.Replace("'", "''") + "'")
                    + " , [PURCHASE_APPLY_PERSON_POSTID] = " + (string.IsNullOrEmpty(unit.PURCHASE_APPLY_PERSON_POSTID) ? "null" : "'" + unit.PURCHASE_APPLY_PERSON_POSTID.Replace("'", "''") + "'")
                    + " , [PURCHASE_APPLY_DATE] = " + dbOperation.DbToDate(unit.PURCHASE_APPLY_DATE)
                    + " , [DEPART_ID] = " + (string.IsNullOrEmpty(unit.DEPART_ID) ? "null" : "'" + unit.DEPART_ID.Replace("'", "''") + "'")
                    + " , [SHIP_LEADER_CHECKER] = " + (unit.SHIP_LEADER_CHECKER == null ? "''" : "'" + unit.SHIP_LEADER_CHECKER.Replace("'", "''") + "'")
                    + " , [SHIP_LEADER_CHECKDATE] = " + dbOperation.DbToDate(unit.SHIP_LEADER_CHECKDATE)
                    + " , [SHIP_BOSS_CHECKER] = " + (unit.SHIP_BOSS_CHECKER == null ? "''" : "'" + unit.SHIP_BOSS_CHECKER.Replace("'", "''") + "'")
                    + " , [SHIP_BOSS_CHECKDATE] = " + dbOperation.DbToDate(unit.SHIP_BOSS_CHECKDATE)
                    + " , [LANDCHECKER] = " + (unit.LANDCHECKER == null ? "''" : "'" + unit.LANDCHECKER.Replace("'", "''") + "'")
                    + " , [CHECKDATE] = " + dbOperation.DbToDate(unit.CHECKDATE)
                    + " , [ISCOMPLETE] = " + unit.ISCOMPLETE.ToString()
                    + " , [REMARK] = N" + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
                    + " , [STATE] = " + unit.STATE.ToString()
                    + " where upper(PURCHASE_APPLYID) = '" + unit.PURCHASE_APPLYID.ToUpper() + "'";
            }
            else
            {
                unit.PURCHASE_APPLYID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_MATERIAL_PURCHASE_APPLY] ("
                    + "[PURCHASE_APPLYID],"
                    + "[SHIP_ID],"
                    + "[PURCHASE_APPLY_CODE],"
                    + "[PURCHASE_APPLY_PERSON],"
                    + "[PURCHASE_APPLY_PERSON_POSTID],"
                    + "[PURCHASE_APPLY_DATE],"
                    + "[DEPART_ID],"
                    + "[SHIP_LEADER_CHECKER],"
                    + "[SHIP_LEADER_CHECKDATE],"
                    + "[SHIP_BOSS_CHECKER],"
                    + "[SHIP_BOSS_CHECKDATE],"
                    + "[LANDCHECKER],"
                    + "[CHECKDATE],"
                    + "[ISCOMPLETE],"
                    + "[REMARK],"
                    + "[STATE]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.PURCHASE_APPLYID) ? "null" : "'" + unit.PURCHASE_APPLYID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , " + (unit.PURCHASE_APPLY_CODE == null ? "''" : "'" + unit.PURCHASE_APPLY_CODE.Replace("'", "''") + "'")
                    + " , " + (unit.PURCHASE_APPLY_PERSON == null ? "''" : "'" + unit.PURCHASE_APPLY_PERSON.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.PURCHASE_APPLY_PERSON_POSTID) ? "null" : "'" + unit.PURCHASE_APPLY_PERSON_POSTID.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.PURCHASE_APPLY_DATE)
                    + " , " + (string.IsNullOrEmpty(unit.DEPART_ID) ? "null" : "'" + unit.DEPART_ID.Replace("'", "''") + "'")
                    + " , " + (unit.SHIP_LEADER_CHECKER == null ? "''" : "'" + unit.SHIP_LEADER_CHECKER.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.SHIP_LEADER_CHECKDATE)
                    + " , " + (unit.SHIP_BOSS_CHECKER == null ? "''" : "'" + unit.SHIP_BOSS_CHECKER.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.SHIP_BOSS_CHECKDATE)
                    + " , " + (unit.LANDCHECKER == null ? "''" : "'" + unit.LANDCHECKER.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.CHECKDATE)
                    + " ," + unit.ISCOMPLETE.ToString()
                    + " , N" + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
                    + " ," + unit.STATE.ToString()
                    + ")";
            }

            return sql;
        }
        /// <summary>
        /// 删除数据表T_MATERIAL_PURCHASE_APPLY中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_MATERIAL_PURCHASE_APPLY对象</param>
        internal bool deleteUnit(MaterialPurchaseApply unit, out string err)
        {
            return deleteUnit(unit.PURCHASE_APPLYID, out err);
        }

        /// <summary>
        /// 删除数据表T_MATERIAL_PURCHASE_APPLY中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_MATERIAL_PURCHASE_APPLY.pURCHASE_APPLYID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_MATERIAL_PURCHASE_APPLY where "
                + " upper(T_MATERIAL_PURCHASE_APPLY.PURCHASE_APPLYID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_MATERIAL_PURCHASE_APPLY 所有数据信息.
        /// </summary>
        /// <returns>T_MATERIAL_PURCHASE_APPLY DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "PURCHASE_APPLYID"
                + ",SHIP_ID"
                + ",PURCHASE_APPLY_CODE"
                + ",PURCHASE_APPLY_PERSON"
                + ",PURCHASE_APPLY_PERSON_POSTID"
                + ",PURCHASE_APPLY_DATE"
                + ",DEPART_ID"
                + ",SHIP_LEADER_CHECKER"
                + ",SHIP_LEADER_CHECKDATE"
                + ",SHIP_BOSS_CHECKER"
                + ",SHIP_BOSS_CHECKDATE"
                + ",LANDCHECKER"
                + ",CHECKDATE"
                + ",ISCOMPLETE"
                + ",REMARK"
                + ",STATE"
                + "  from T_MATERIAL_PURCHASE_APPLY ";
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
        /// 根据一个主键ID,得到 T_MATERIAL_PURCHASE_APPLY 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>MaterialPurchaseApply DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "PURCHASE_APPLYID"
                + ",SHIP_ID"
                + ",PURCHASE_APPLY_CODE"
                + ",PURCHASE_APPLY_PERSON"
                + ",PURCHASE_APPLY_PERSON_POSTID"
                + ",PURCHASE_APPLY_DATE"
                + ",DEPART_ID"
                + ",SHIP_LEADER_CHECKER"
                + ",SHIP_LEADER_CHECKDATE"
                + ",SHIP_BOSS_CHECKER"
                + ",SHIP_BOSS_CHECKDATE"
                + ",LANDCHECKER"
                + ",CHECKDATE"
                + ",ISCOMPLETE"
                + ",REMARK"
                + ",STATE"
                + " from T_MATERIAL_PURCHASE_APPLY "
                + " where upper(PURCHASE_APPLYID)='" + Id.ToUpper() + "'";
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
        /// 根据一个主键ID,得到 T_MATERIAL_PURCHASE_APPLY 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>MaterialPurchaseApply DataTable</returns>
        public DataTable getInfo(List<string> Ids, out string err)
        {
            string allIdsChar = "";
            foreach (string id in Ids)
            {
                allIdsChar += "'" + id + "',";
            }
            if (allIdsChar.Length > 0) allIdsChar = allIdsChar.Remove(allIdsChar.Length - 1);

            sql = "select "
                + "PURCHASE_APPLYID"
                + ",SHIP_ID"
                + ",PURCHASE_APPLY_CODE"
                + ",PURCHASE_APPLY_PERSON"
                + ",PURCHASE_APPLY_PERSON_POSTID"
                + ",PURCHASE_APPLY_DATE"
                + ",DEPART_ID"
                + ",SHIP_LEADER_CHECKER"
                + ",SHIP_LEADER_CHECKDATE"
                + ",SHIP_BOSS_CHECKER"
                + ",SHIP_BOSS_CHECKDATE"
                + ",LANDCHECKER"
                + ",CHECKDATE"
                + ",ISCOMPLETE"
                + ",REMARK"
                + ",STATE"
                + " from T_MATERIAL_PURCHASE_APPLY "
                + " where PURCHASE_APPLYID in (" + allIdsChar + ")";
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
        /// 根据materialpurchaseapply 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>materialpurchaseapply 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
        public MaterialPurchaseApply getObject(DataRow dr)
        {
            MaterialPurchaseApply unit = new MaterialPurchaseApply();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造MaterialPurchaseApply类对象!";
                return unit;
            }
            if (DBNull.Value != dr["PURCHASE_APPLYID"])
                unit.PURCHASE_APPLYID = dr["PURCHASE_APPLYID"].ToString();
            if (DBNull.Value != dr["SHIP_ID"])
                unit.SHIP_ID = dr["SHIP_ID"].ToString();
            if (DBNull.Value != dr["PURCHASE_APPLY_CODE"])
                unit.PURCHASE_APPLY_CODE = dr["PURCHASE_APPLY_CODE"].ToString();
            if (DBNull.Value != dr["PURCHASE_APPLY_PERSON"])
                unit.PURCHASE_APPLY_PERSON = dr["PURCHASE_APPLY_PERSON"].ToString();
            if (DBNull.Value != dr["PURCHASE_APPLY_PERSON_POSTID"])
                unit.PURCHASE_APPLY_PERSON_POSTID = dr["PURCHASE_APPLY_PERSON_POSTID"].ToString();
            if (DBNull.Value != dr["PURCHASE_APPLY_DATE"])
                unit.PURCHASE_APPLY_DATE = (DateTime)dr["PURCHASE_APPLY_DATE"];
            if (DBNull.Value != dr["DEPART_ID"])
                unit.DEPART_ID = dr["DEPART_ID"].ToString();
            if (DBNull.Value != dr["SHIP_LEADER_CHECKER"])
                unit.SHIP_LEADER_CHECKER = dr["SHIP_LEADER_CHECKER"].ToString();
            if (DBNull.Value != dr["SHIP_LEADER_CHECKDATE"])
                unit.SHIP_LEADER_CHECKDATE = (DateTime)dr["SHIP_LEADER_CHECKDATE"];
            if (DBNull.Value != dr["SHIP_BOSS_CHECKER"])
                unit.SHIP_BOSS_CHECKER = dr["SHIP_BOSS_CHECKER"].ToString();
            if (DBNull.Value != dr["SHIP_BOSS_CHECKDATE"])
                unit.SHIP_BOSS_CHECKDATE = (DateTime)dr["SHIP_BOSS_CHECKDATE"];
            if (DBNull.Value != dr["LANDCHECKER"])
                unit.LANDCHECKER = dr["LANDCHECKER"].ToString();
            if (DBNull.Value != dr["CHECKDATE"])
                unit.CHECKDATE = (DateTime)dr["CHECKDATE"];
            if (DBNull.Value != dr["ISCOMPLETE"])
                unit.ISCOMPLETE = Convert.ToDecimal(dr["ISCOMPLETE"]);
            if (DBNull.Value != dr["REMARK"])
                unit.REMARK = dr["REMARK"].ToString();
            if (DBNull.Value != dr["STATE"])
                unit.STATE = Convert.ToDecimal(dr["STATE"]);

            return unit;
        }
        /// <summary>
        /// 根据ID,返回一个MaterialPurchaseApply对象.
        /// </summary>
        /// <param name="pURCHASE_APPLYID">pURCHASE_APPLYID</param>
        /// <returns>MaterialPurchaseApply对象</returns>
        public MaterialPurchaseApply getObject(string Id, out string err)
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
