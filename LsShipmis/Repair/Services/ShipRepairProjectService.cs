/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：ShipRepairProjectService.cs
 * 创 建 人：徐正本
 * 创建时间：2013-9-18
 * 标    题：数据操作类
 * 功能描述：T_SHIP_REPAIR_PROJECT数据操作类
 * Codesmith DataAccessLayer.cst 1.02版本生成
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
    /// 数据层实例化接口类 dbo.T_SHIP_REPAIR_PROJECTService.cs
    /// </summary>
    public partial class ShipRepairProjectService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象
        /// </summary>
        private static ShipRepairProjectService instance = new ShipRepairProjectService();
        public static ShipRepairProjectService Instance
        {
            get
            {
                if (null == instance)
                {
                    ShipRepairProjectService.instance = new ShipRepairProjectService();
                }
                return ShipRepairProjectService.instance;
            }
        }
        private ShipRepairProjectService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。
        /// </summary>
        /// <param name="unit">ShipRepairProject对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(ShipRepairProject unit, out string err)
        {
            bool ifDBHaveThisObj = dbOperation.DbHaveThisData(unit.PROJECTID, "T_SHIP_REPAIR_PROJECT", "PROJECTID", "PROJECTID", "");

            if (ifDBHaveThisObj)
            {
                sql = "UPDATE [T_SHIP_REPAIR_PROJECT] SET "
                    + " [PROJECTID] = " + (string.IsNullOrEmpty(unit.PROJECTID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.PROJECTID) + "'")
                    + " , [PROJECTNAME] = " + (unit.PROJECTNAME == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.PROJECTNAME) + "'")
                    + " , [PROJECTDETAIL] = " + (unit.PROJECTDETAIL == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.PROJECTDETAIL) + "'")
                    + " , [APPLYDATE] = " + dbOperation.DbToDate(unit.APPLYDATE)
                    + " , [APPLICANT] = " + (unit.APPLICANT == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.APPLICANT) + "'")
                    + " , [WORKORDERID] = " + (string.IsNullOrEmpty(unit.WORKORDERID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.WORKORDERID) + "'")
                    + " , [APPLYCOMPLETEDATE] = " + dbOperation.DbToDate(unit.APPLYCOMPLETEDATE)
                    + " , [REALCOMPLETEDATE] = " + dbOperation.DbToDate(unit.REALCOMPLETEDATE)
                    + " , [PROJECTSTATE] = " + unit.PROJECTSTATE.ToString()
                    + " , [AFFIRMANT] = " + (unit.AFFIRMANT == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.AFFIRMANT) + "'")
                    + " , [COMPLETEAFFIRMANT] = " + (unit.COMPLETEAFFIRMANT == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.COMPLETEAFFIRMANT) + "'")
                    + " , [RUNNINGORDOCK] = " + unit.RUNNINGORDOCK.ToString()
                    + " , [REPAIRSUBJECT] = " + (string.IsNullOrEmpty(unit.REPAIRSUBJECT) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.REPAIRSUBJECT) + "'")
                    + " , [SERVICEPROVIDER] = " + (string.IsNullOrEmpty(unit.SERVICEPROVIDER) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SERVICEPROVIDER) + "'")
                    + " , [REMARK] = " + (unit.REMARK == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.REMARK) + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIP_ID) + "'")
                    + " , [CURRENCYID] = " + (string.IsNullOrEmpty(unit.CURRENCYID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.CURRENCYID) + "'")
                    + " , [COSTCOUNT] = " + unit.COSTCOUNT.ToString()
                    + " , [EQUIPMENTID] = " + (string.IsNullOrEmpty(unit.EQUIPMENTID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.EQUIPMENTID) + "'")
                    + " , [SENDTOWARRANT] = " + unit.SENDTOWARRANT.ToString()
                    + " , [APPLYPOST] = " + (string.IsNullOrEmpty(unit.APPLYPOST) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.APPLYPOST) + "'")
                    + " , [VOUCHER_ID] = " + (string.IsNullOrEmpty(unit.VOUCHER_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.VOUCHER_ID) + "'")
                    + " , [LandOpinion] = " + (unit.LandOpinion == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.LandOpinion) + "'")
                    + "\rwhere PROJECTID = '" + dbOperation.ReplaceSqlKeyStr(unit.PROJECTID) + "'";
            }
            else
            {
                if (string.IsNullOrEmpty(unit.PROJECTID))
                    unit.PROJECTID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_SHIP_REPAIR_PROJECT] ("
                    + "[PROJECTID],"
                    + "[PROJECTNAME],"
                    + "[PROJECTDETAIL],"
                    + "[APPLYDATE],"
                    + "[APPLICANT],"
                    + "[WORKORDERID],"
                    + "[APPLYCOMPLETEDATE],"
                    + "[REALCOMPLETEDATE],"
                    + "[PROJECTSTATE],"
                    + "[AFFIRMANT],"
                    + "[COMPLETEAFFIRMANT],"
                    + "[RUNNINGORDOCK],"
                    + "[REPAIRSUBJECT],"
                    + "[SERVICEPROVIDER],"
                    + "[REMARK],"
                    + "[SHIP_ID],"
                    + "[CURRENCYID],"
                    + "[COSTCOUNT],"
                    + "[EQUIPMENTID],"
                    + "[SENDTOWARRANT],"
                    + "[APPLYPOST],"
                    + "[VOUCHER_ID],"
                    + "[LandOpinion]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.PROJECTID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.PROJECTID) + "'")
                    + " , " + (unit.PROJECTNAME == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.PROJECTNAME) + "'")
                    + " , " + (unit.PROJECTDETAIL == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.PROJECTDETAIL) + "'")
                    + " ," + dbOperation.DbToDate(unit.APPLYDATE)
                    + " , " + (unit.APPLICANT == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.APPLICANT) + "'")
                    + " , " + (string.IsNullOrEmpty(unit.WORKORDERID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.WORKORDERID) + "'")
                    + " ," + dbOperation.DbToDate(unit.APPLYCOMPLETEDATE)
                    + " ," + dbOperation.DbToDate(unit.REALCOMPLETEDATE)
                    + " ," + unit.PROJECTSTATE.ToString()
                    + " , " + (unit.AFFIRMANT == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.AFFIRMANT) + "'")
                    + " , " + (unit.COMPLETEAFFIRMANT == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.COMPLETEAFFIRMANT) + "'")
                    + " ," + unit.RUNNINGORDOCK.ToString()
                    + " , " + (string.IsNullOrEmpty(unit.REPAIRSUBJECT) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.REPAIRSUBJECT) + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SERVICEPROVIDER) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SERVICEPROVIDER) + "'")
                    + " , " + (unit.REMARK == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.REMARK) + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIP_ID) + "'")
                    + " , " + (string.IsNullOrEmpty(unit.CURRENCYID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.CURRENCYID) + "'")
                    + " ," + unit.COSTCOUNT.ToString()
                    + " , " + (string.IsNullOrEmpty(unit.EQUIPMENTID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.EQUIPMENTID) + "'")
                    + " ," + unit.SENDTOWARRANT.ToString()
                    + " , " + (string.IsNullOrEmpty(unit.APPLYPOST) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.APPLYPOST) + "'")
                    + " , " + (string.IsNullOrEmpty(unit.VOUCHER_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.VOUCHER_ID) + "'")
                    + " , " + (unit.LandOpinion == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.LandOpinion) + "'")
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_SHIP_REPAIR_PROJECT中的对象
        /// </summary>
        /// <param name="unit">要删除的T_SHIP_REPAIR_PROJECT对象</param>
        internal bool deleteUnit(ShipRepairProject unit, out string err)
        {
            return deleteUnit(unit.PROJECTID, out err);
        }

        /// <summary>
        /// 删除数据表T_SHIP_REPAIR_PROJECT中的一条记录
        /// </summary>
        /// <param name="unit">要删除的T_SHIP_REPAIR_PROJECT.pROJECTID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_SHIP_REPAIR_PROJECT where PROJECTID='" + dbOperation.ReplaceSqlKeyStr(unitid) + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_SHIP_REPAIR_PROJECT 所有数据信息
        /// </summary>
        /// <returns>T_SHIP_REPAIR_PROJECT DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "PROJECTID"
                + ",PROJECTNAME"
                + ",PROJECTDETAIL"
                + ",APPLYDATE"
                + ",APPLICANT"
                + ",WORKORDERID"
                + ",APPLYCOMPLETEDATE"
                + ",REALCOMPLETEDATE"
                + ",PROJECTSTATE"
                + ",AFFIRMANT"
                + ",COMPLETEAFFIRMANT"
                + ",RUNNINGORDOCK"
                + ",REPAIRSUBJECT"
                + ",SERVICEPROVIDER"
                + ",REMARK"
                + ",SHIP_ID"
                + ",CURRENCYID"
                + ",COSTCOUNT"
                + ",EQUIPMENTID"
                + ",SENDTOWARRANT"
                + ",APPLYPOST"
                + ",VOUCHER_ID"
                + ",LandOpinion"
                + "\rfrom T_SHIP_REPAIR_PROJECT ";
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
        /// 根据一个主键ID,得到 T_SHIP_REPAIR_PROJECT 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>ShipRepairProject DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "PROJECTID"
                + ",PROJECTNAME"
                + ",PROJECTDETAIL"
                + ",APPLYDATE"
                + ",APPLICANT"
                + ",WORKORDERID"
                + ",APPLYCOMPLETEDATE"
                + ",REALCOMPLETEDATE"
                + ",PROJECTSTATE"
                + ",AFFIRMANT"
                + ",COMPLETEAFFIRMANT"
                + ",RUNNINGORDOCK"
                + ",REPAIRSUBJECT"
                + ",SERVICEPROVIDER"
                + ",REMARK"
                + ",SHIP_ID"
                + ",CURRENCYID"
                + ",COSTCOUNT"
                + ",EQUIPMENTID"
                + ",SENDTOWARRANT"
                + ",APPLYPOST"
                + ",VOUCHER_ID"
                + ",LandOpinion"
                + "\rfrom T_SHIP_REPAIR_PROJECT "
                + "\rwhere PROJECTID='" + dbOperation.ReplaceSqlKeyStr(Id) + "'";
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
        /// 根据shiprepairproject 的DataRow封装对象
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>shiprepairproject 数据实体</returns>
        public ShipRepairProject getObject(DataRow dr)
        {
            ShipRepairProject unit = new ShipRepairProject();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造ShipRepairProject类对象!";
                return unit;
            }
            if (DBNull.Value != dr["PROJECTID"])
                unit.PROJECTID = dr["PROJECTID"].ToString();
            if (DBNull.Value != dr["PROJECTNAME"])
                unit.PROJECTNAME = dr["PROJECTNAME"].ToString();
            if (DBNull.Value != dr["PROJECTDETAIL"])
                unit.PROJECTDETAIL = dr["PROJECTDETAIL"].ToString();
            if (DBNull.Value != dr["APPLYDATE"])
                unit.APPLYDATE = (DateTime)dr["APPLYDATE"];
            if (DBNull.Value != dr["APPLICANT"])
                unit.APPLICANT = dr["APPLICANT"].ToString();
            if (DBNull.Value != dr["WORKORDERID"])
                unit.WORKORDERID = dr["WORKORDERID"].ToString();
            if (DBNull.Value != dr["APPLYCOMPLETEDATE"])
                unit.APPLYCOMPLETEDATE = (DateTime)dr["APPLYCOMPLETEDATE"];
            if (DBNull.Value != dr["REALCOMPLETEDATE"])
                unit.REALCOMPLETEDATE = (DateTime)dr["REALCOMPLETEDATE"];
            if (DBNull.Value != dr["PROJECTSTATE"])
                unit.PROJECTSTATE = Convert.ToDecimal(dr["PROJECTSTATE"]);
            if (DBNull.Value != dr["AFFIRMANT"])
                unit.AFFIRMANT = dr["AFFIRMANT"].ToString();
            if (DBNull.Value != dr["COMPLETEAFFIRMANT"])
                unit.COMPLETEAFFIRMANT = dr["COMPLETEAFFIRMANT"].ToString();
            if (DBNull.Value != dr["RUNNINGORDOCK"])
                unit.RUNNINGORDOCK = Convert.ToDecimal(dr["RUNNINGORDOCK"]);
            if (DBNull.Value != dr["REPAIRSUBJECT"])
                unit.REPAIRSUBJECT = dr["REPAIRSUBJECT"].ToString();
            if (DBNull.Value != dr["SERVICEPROVIDER"])
                unit.SERVICEPROVIDER = dr["SERVICEPROVIDER"].ToString();
            if (DBNull.Value != dr["REMARK"])
                unit.REMARK = dr["REMARK"].ToString();
            if (DBNull.Value != dr["SHIP_ID"])
                unit.SHIP_ID = dr["SHIP_ID"].ToString();
            if (DBNull.Value != dr["CURRENCYID"])
                unit.CURRENCYID = dr["CURRENCYID"].ToString();
            if (DBNull.Value != dr["COSTCOUNT"])
                unit.COSTCOUNT = Convert.ToDecimal(dr["COSTCOUNT"]);
            if (DBNull.Value != dr["EQUIPMENTID"])
                unit.EQUIPMENTID = dr["EQUIPMENTID"].ToString();
            if (DBNull.Value != dr["SENDTOWARRANT"])
                unit.SENDTOWARRANT = Convert.ToDecimal(dr["SENDTOWARRANT"]);
            if (DBNull.Value != dr["APPLYPOST"])
                unit.APPLYPOST = dr["APPLYPOST"].ToString();
            if (DBNull.Value != dr["VOUCHER_ID"])
                unit.VOUCHER_ID = dr["VOUCHER_ID"].ToString();
            if (DBNull.Value != dr["LandOpinion"])
                unit.LandOpinion = dr["LandOpinion"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个ShipRepairProject对象
        /// </summary>
        /// <param name="pROJECTID">pROJECTID</param>
        /// <returns>ShipRepairProject对象</returns>
        public ShipRepairProject getObject(string Id, out string err)
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
