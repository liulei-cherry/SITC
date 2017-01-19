/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：ReportCoolwaterService.cs
 * 创 建 人：黄家龙
 * 创建时间：2011/8/23
 * 标    题：数据操作类
 * 功能描述：T_REPORT_COOLWATER数据操作类
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
    /// 数据层实例化接口类 dbo.T_REPORT_COOLWATERService.cs
    /// </summary>
    public partial class ReportCoolwaterService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static ReportCoolwaterService instance = new ReportCoolwaterService();
        public static ReportCoolwaterService Instance
        {
            get
            {
                if (null == instance)
                {
                    ReportCoolwaterService.instance = new ReportCoolwaterService();
                }
                return ReportCoolwaterService.instance;
            }
        }
        private ReportCoolwaterService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">ReportCoolwater对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(ReportCoolwater unit, out string err)
        {
            if (unit.Report_CoolWater_Id != null && unit.Report_CoolWater_Id.Length > 0) //edit
            {
                sql = "UPDATE [T_REPORT_COOLWATER] SET "
                    + " [Report_CoolWater_Id] = " + (unit.Report_CoolWater_Id == null ? "''" : "'" + unit.Report_CoolWater_Id.Replace("'", "''") + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , [File_ID] = " + (string.IsNullOrEmpty(unit.File_ID) ? "null" : "'" + unit.File_ID.Replace("'", "''") + "'")
                    + " , [Medcine] = " + (unit.Medcine == null ? "''" : "'" + unit.Medcine.Replace("'", "''") + "'")
                    + " , [MainLinerConcentration] = " + (unit.MainLinerConcentration == null ? "''" : "'" + unit.MainLinerConcentration.Replace("'", "''") + "'")
                    + " , [MainLInerDosage] = " + (unit.MainLInerDosage == null ? "''" : "'" + unit.MainLInerDosage.Replace("'", "''") + "'")
                    + " , [MainPistonConcentration] = " + (unit.MainPistonConcentration == null ? "''" : "'" + unit.MainPistonConcentration.Replace("'", "''") + "'")
                    + " , [MainPistonDosage] = " + (unit.MainPistonDosage == null ? "''" : "'" + unit.MainPistonDosage.Replace("'", "''") + "'")
                    + " , [MainOilConcentration] = " + (unit.MainOilConcentration == null ? "''" : "'" + unit.MainOilConcentration.Replace("'", "''") + "'")
                    + " , [MainOilDosage] = " + (unit.MainOilDosage == null ? "''" : "'" + unit.MainOilDosage.Replace("'", "''") + "'")
                    + " , [SecondConcentration] = " + (unit.SecondConcentration == null ? "''" : "'" + unit.SecondConcentration.Replace("'", "''") + "'")
                    + " , [SecondDosage] = " + (unit.SecondDosage == null ? "''" : "'" + unit.SecondDosage.Replace("'", "''") + "'")
                    + " , [ExperimentDealDate] = " + dbOperation.DbToDate(unit.ExperimentDealDate)
                    + " , [ExperimentDealSign] = " + (unit.ExperimentDealSign == null ? "''" : "'" + unit.ExperimentDealSign.Replace("'", "''") + "'")
                    + " , [ExperimentDealSignDate] = " + dbOperation.DbToDate(unit.ExperimentDealSignDate)
                    + " , [ChiefSign] = " + (unit.ChiefSign == null ? "''" : "'" + unit.ChiefSign.Replace("'", "''") + "'")
                    + " , [ChiefSignData] = " + dbOperation.DbToDate(unit.ChiefSignData)
                    + " where upper(Report_CoolWater_Id) = '" + unit.Report_CoolWater_Id.ToUpper() + "'";
            }
            else
            {
                unit.Report_CoolWater_Id = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_REPORT_COOLWATER] ("
                    + "[Report_CoolWater_Id],"
                    + "[SHIP_ID],"
                    + "[File_ID],"
                    + "[Medcine],"
                    + "[MainLinerConcentration],"
                    + "[MainLInerDosage],"
                    + "[MainPistonConcentration],"
                    + "[MainPistonDosage],"
                    + "[MainOilConcentration],"
                    + "[MainOilDosage],"
                    + "[SecondConcentration],"
                    + "[SecondDosage],"
                    + "[ExperimentDealDate],"
                    + "[ExperimentDealSign],"
                    + "[ExperimentDealSignDate],"
                    + "[ChiefSign],"
                    + "[ChiefSignData]"
                    + ") VALUES( "
                    + " " + (unit.Report_CoolWater_Id == null ? "''" : "'" + unit.Report_CoolWater_Id.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.File_ID) ? "null" : "'" + unit.File_ID.Replace("'", "''") + "'")
                    + " , " + (unit.Medcine == null ? "''" : "'" + unit.Medcine.Replace("'", "''") + "'")
                    + " , " + (unit.MainLinerConcentration == null ? "''" : "'" + unit.MainLinerConcentration.Replace("'", "''") + "'")
                    + " , " + (unit.MainLInerDosage == null ? "''" : "'" + unit.MainLInerDosage.Replace("'", "''") + "'")
                    + " , " + (unit.MainPistonConcentration == null ? "''" : "'" + unit.MainPistonConcentration.Replace("'", "''") + "'")
                    + " , " + (unit.MainPistonDosage == null ? "''" : "'" + unit.MainPistonDosage.Replace("'", "''") + "'")
                    + " , " + (unit.MainOilConcentration == null ? "''" : "'" + unit.MainOilConcentration.Replace("'", "''") + "'")
                    + " , " + (unit.MainOilDosage == null ? "''" : "'" + unit.MainOilDosage.Replace("'", "''") + "'")
                    + " , " + (unit.SecondConcentration == null ? "''" : "'" + unit.SecondConcentration.Replace("'", "''") + "'")
                    + " , " + (unit.SecondDosage == null ? "''" : "'" + unit.SecondDosage.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.ExperimentDealDate)
                    + " , " + (unit.ExperimentDealSign == null ? "''" : "'" + unit.ExperimentDealSign.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.ExperimentDealSignDate)
                    + " , " + (unit.ChiefSign == null ? "''" : "'" + unit.ChiefSign.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.ChiefSignData)
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_REPORT_COOLWATER中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_REPORT_COOLWATER对象</param>
        internal bool deleteUnit(ReportCoolwater unit, out string err)
        {
            return deleteUnit(unit.Report_CoolWater_Id, out err);
        }

        /// <summary>
        /// 删除数据表T_REPORT_COOLWATER中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_REPORT_COOLWATER.report_CoolWater_Id主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_REPORT_COOLWATER where "
                + " upper(T_REPORT_COOLWATER.Report_CoolWater_Id)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_REPORT_COOLWATER 所有数据信息.
        /// </summary>
        /// <returns>T_REPORT_COOLWATER DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "Report_CoolWater_Id"
                + ",SHIP_ID"
                + ",File_ID"
                + ",Medcine"
                + ",MainLinerConcentration"
                + ",MainLInerDosage"
                + ",MainPistonConcentration"
                + ",MainPistonDosage"
                + ",MainOilConcentration"
                + ",MainOilDosage"
                + ",SecondConcentration"
                + ",SecondDosage"
                + ",ExperimentDealDate"
                + ",ExperimentDealSign"
                + ",ExperimentDealSignDate"
                + ",ChiefSign"
                + ",ChiefSignData"
                + "  from T_REPORT_COOLWATER ";
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
        /// 根据一个主键ID,得到 T_REPORT_COOLWATER 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>ReportCoolwater DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "Report_CoolWater_Id"
                + ",SHIP_ID"
                + ",File_ID"
                + ",Medcine"
                + ",MainLinerConcentration"
                + ",MainLInerDosage"
                + ",MainPistonConcentration"
                + ",MainPistonDosage"
                + ",MainOilConcentration"
                + ",MainOilDosage"
                + ",SecondConcentration"
                + ",SecondDosage"
                + ",ExperimentDealDate"
                + ",ExperimentDealSign"
                + ",ExperimentDealSignDate"
                + ",ChiefSign"
                + ",ChiefSignData"
                + " from T_REPORT_COOLWATER "
                + " where upper(Report_CoolWater_Id)='" + Id.ToUpper() + "'";
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
        /// 根据reportcoolwater 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>reportcoolwater 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
        public ReportCoolwater getObject(DataRow dr)
        {
            ReportCoolwater unit = new ReportCoolwater();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造ReportCoolwater类对象!";
                return unit;
            }
            if (DBNull.Value != dr["Report_CoolWater_Id"])
                unit.Report_CoolWater_Id = dr["Report_CoolWater_Id"].ToString();
            if (DBNull.Value != dr["SHIP_ID"])
                unit.SHIP_ID = dr["SHIP_ID"].ToString();
            if (DBNull.Value != dr["File_ID"])
                unit.File_ID = dr["File_ID"].ToString();
            if (DBNull.Value != dr["Medcine"])
                unit.Medcine = dr["Medcine"].ToString();
            if (DBNull.Value != dr["MainLinerConcentration"])
                unit.MainLinerConcentration = dr["MainLinerConcentration"].ToString();
            if (DBNull.Value != dr["MainLInerDosage"])
                unit.MainLInerDosage = dr["MainLInerDosage"].ToString();
            if (DBNull.Value != dr["MainPistonConcentration"])
                unit.MainPistonConcentration = dr["MainPistonConcentration"].ToString();
            if (DBNull.Value != dr["MainPistonDosage"])
                unit.MainPistonDosage = dr["MainPistonDosage"].ToString();
            if (DBNull.Value != dr["MainOilConcentration"])
                unit.MainOilConcentration = dr["MainOilConcentration"].ToString();
            if (DBNull.Value != dr["MainOilDosage"])
                unit.MainOilDosage = dr["MainOilDosage"].ToString();
            if (DBNull.Value != dr["SecondConcentration"])
                unit.SecondConcentration = dr["SecondConcentration"].ToString();
            if (DBNull.Value != dr["SecondDosage"])
                unit.SecondDosage = dr["SecondDosage"].ToString();
            if (DBNull.Value != dr["ExperimentDealDate"])
                unit.ExperimentDealDate = (DateTime)dr["ExperimentDealDate"];
            if (DBNull.Value != dr["ExperimentDealSign"])
                unit.ExperimentDealSign = dr["ExperimentDealSign"].ToString();
            if (DBNull.Value != dr["ExperimentDealSignDate"])
                unit.ExperimentDealSignDate = (DateTime)dr["ExperimentDealSignDate"];
            if (DBNull.Value != dr["ChiefSign"])
                unit.ChiefSign = dr["ChiefSign"].ToString();
            if (DBNull.Value != dr["ChiefSignData"])
                unit.ChiefSignData = (DateTime)dr["ChiefSignData"];

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个ReportCoolwater对象.
        /// </summary>
        /// <param name="report_CoolWater_Id">report_CoolWater_Id</param>
        /// <returns>ReportCoolwater对象</returns>
        public ReportCoolwater getObject(string Id, out string err)
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
