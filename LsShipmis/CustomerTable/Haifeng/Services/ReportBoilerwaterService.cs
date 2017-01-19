/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：ReportBoilerwaterService.cs
 * 创 建 人：黄家龙
 * 创建时间：2011/8/19
 * 标    题：数据操作类
 * 功能描述：T_REPORT_BOILERWATER数据操作类
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
    /// 数据层实例化接口类 dbo.T_REPORT_BOILERWATERService.cs
    /// </summary>
    public partial class ReportBoilerwaterService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static ReportBoilerwaterService instance = new ReportBoilerwaterService();
        public static ReportBoilerwaterService Instance
        {
            get
            {
                if (null == instance)
                {
                    ReportBoilerwaterService.instance = new ReportBoilerwaterService();
                }
                return ReportBoilerwaterService.instance;
            }
        }
        private ReportBoilerwaterService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">ReportBoilerwater对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(ReportBoilerwater unit, out string err)
        {
            if (unit.Report_BoilerWater_Id != null && unit.Report_BoilerWater_Id.Length > 0) //edit
            {
                sql = "UPDATE [T_REPORT_BOILERWATER] SET "
                    + " [Report_BoilerWater_Id] = " + (unit.Report_BoilerWater_Id == null ? "''" : "'" + unit.Report_BoilerWater_Id.Replace("'", "''") + "'")
                    + " , [File_ID] = " + (string.IsNullOrEmpty(unit.File_ID) ? "null" : "'" + unit.File_ID.Replace("'", "''") + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , [BoilerCategory] = " + (unit.BoilerCategory == null ? "''" : "'" + unit.BoilerCategory.Replace("'", "''") + "'")
                    + " , [BoilerAirPressure] = " + (unit.BoilerAirPressure == null ? "''" : "'" + unit.BoilerAirPressure.Replace("'", "''") + "'")
                    + " , [BoilerWaterQuantity] = " + (unit.BoilerWaterQuantity == null ? "''" : "'" + unit.BoilerWaterQuantity.Replace("'", "''") + "'")
                    + " , [FileDate] = " + dbOperation.DbToDate(unit.FileDate)
                    + " , [PhenolphthaleinAlkalinity] = " + (unit.PhenolphthaleinAlkalinity == null ? "''" : "'" + unit.PhenolphthaleinAlkalinity.Replace("'", "''") + "'")
                    + " , [SaltAmount] = " + (unit.SaltAmount == null ? "''" : "'" + unit.SaltAmount.Replace("'", "''") + "'")
                    + " , [Hardness] = " + (unit.Hardness == null ? "''" : "'" + unit.Hardness.Replace("'", "''") + "'")
                    + " , [PHValue] = " + (unit.PHValue == null ? "''" : "'" + unit.PHValue.Replace("'", "''") + "'")
                    + " , [SewageOnAmount] = " + (unit.SewageOnAmount == null ? "''" : "'" + unit.SewageOnAmount.Replace("'", "''") + "'")
                    + " , [SewageNextAmount] = " + (unit.SewageNextAmount == null ? "''" : "'" + unit.SewageNextAmount.Replace("'", "''") + "'")
                    + " , [Medicine1] = " + (unit.Medicine1 == null ? "''" : "'" + unit.Medicine1.Replace("'", "''") + "'")
                    + " , [Medicine2] = " + (unit.Medicine2 == null ? "''" : "'" + unit.Medicine2.Replace("'", "''") + "'")
                    + " , [Medicine3] = " + (unit.Medicine3 == null ? "''" : "'" + unit.Medicine3.Replace("'", "''") + "'")
                    + " , [Medicine1Value] = " + (unit.Medicine1Value == null ? "''" : "'" + unit.Medicine1Value.Replace("'", "''") + "'")
                    + " , [Medicine2Value] = " + (unit.Medicine2Value == null ? "''" : "'" + unit.Medicine2Value.Replace("'", "''") + "'")
                    + " , [Medicine3Value] = " + (unit.Medicine3Value == null ? "''" : "'" + unit.Medicine3Value.Replace("'", "''") + "'")
                    + " , [CondensateLevel] = " + (unit.CondensateLevel == null ? "''" : "'" + unit.CondensateLevel.Replace("'", "''") + "'")
                    + " , [CondensateSilverNitrateDrops] = " + (unit.CondensateSilverNitrateDrops == null ? "''" : "'" + unit.CondensateSilverNitrateDrops.Replace("'", "''") + "'")
                    + " , [TankWaterLeverl] = " + (unit.TankWaterLeverl == null ? "''" : "'" + unit.TankWaterLeverl.Replace("'", "''") + "'")
                    + " , [TankWateSilverNitrateDrops] = " + (unit.TankWateSilverNitrateDrops == null ? "''" : "'" + unit.TankWateSilverNitrateDrops.Replace("'", "''") + "'")
                    + " , [Remarks] = " + (unit.Remarks == null ? "''" : "'" + unit.Remarks.Replace("'", "''") + "'")
                    + " , [ExperimentOrHandlePersonName] = " + (unit.ExperimentOrHandlePersonName == null ? "''" : "'" + unit.ExperimentOrHandlePersonName.Replace("'", "''") + "'")
                    + " , [ChiefEngineerName] = " + (unit.ChiefEngineerName == null ? "''" : "'" + unit.ChiefEngineerName.Replace("'", "''") + "'")
                    + " where upper(Report_BoilerWater_Id) = '" + unit.Report_BoilerWater_Id.ToUpper() + "'";
            }
            else
            {
                unit.Report_BoilerWater_Id = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_REPORT_BOILERWATER] ("
                    + "[Report_BoilerWater_Id],"
                    + "[File_ID],"
                    + "[SHIP_ID],"
                    + "[BoilerCategory],"
                    + "[BoilerAirPressure],"
                    + "[BoilerWaterQuantity],"
                    + "[FileDate],"
                    + "[PhenolphthaleinAlkalinity],"
                    + "[SaltAmount],"
                    + "[Hardness],"
                    + "[PHValue],"
                    + "[SewageOnAmount],"
                    + "[SewageNextAmount],"
                    + "[Medicine1],"
                    + "[Medicine2],"
                    + "[Medicine3],"
                    + "[Medicine1Value],"
                    + "[Medicine2Value],"
                    + "[Medicine3Value],"
                    + "[CondensateLevel],"
                    + "[CondensateSilverNitrateDrops],"
                    + "[TankWaterLeverl],"
                    + "[TankWateSilverNitrateDrops],"
                    + "[Remarks],"
                    + "[ExperimentOrHandlePersonName],"
                    + "[ChiefEngineerName]"
                    + ") VALUES( "
                    + " " + (unit.Report_BoilerWater_Id == null ? "''" : "'" + unit.Report_BoilerWater_Id.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.File_ID) ? "null" : "'" + unit.File_ID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , " + (unit.BoilerCategory == null ? "''" : "'" + unit.BoilerCategory.Replace("'", "''") + "'")
                    + " , " + (unit.BoilerAirPressure == null ? "''" : "'" + unit.BoilerAirPressure.Replace("'", "''") + "'")
                    + " , " + (unit.BoilerWaterQuantity == null ? "''" : "'" + unit.BoilerWaterQuantity.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.FileDate)
                    + " , " + (unit.PhenolphthaleinAlkalinity == null ? "''" : "'" + unit.PhenolphthaleinAlkalinity.Replace("'", "''") + "'")
                    + " , " + (unit.SaltAmount == null ? "''" : "'" + unit.SaltAmount.Replace("'", "''") + "'")
                    + " , " + (unit.Hardness == null ? "''" : "'" + unit.Hardness.Replace("'", "''") + "'")
                    + " , " + (unit.PHValue == null ? "''" : "'" + unit.PHValue.Replace("'", "''") + "'")
                    + " , " + (unit.SewageOnAmount == null ? "''" : "'" + unit.SewageOnAmount.Replace("'", "''") + "'")
                    + " , " + (unit.SewageNextAmount == null ? "''" : "'" + unit.SewageNextAmount.Replace("'", "''") + "'")
                    + " , " + (unit.Medicine1 == null ? "''" : "'" + unit.Medicine1.Replace("'", "''") + "'")
                    + " , " + (unit.Medicine2 == null ? "''" : "'" + unit.Medicine2.Replace("'", "''") + "'")
                    + " , " + (unit.Medicine3 == null ? "''" : "'" + unit.Medicine3.Replace("'", "''") + "'")
                    + " , " + (unit.Medicine1Value == null ? "''" : "'" + unit.Medicine1Value.Replace("'", "''") + "'")
                    + " , " + (unit.Medicine2Value == null ? "''" : "'" + unit.Medicine2Value.Replace("'", "''") + "'")
                    + " , " + (unit.Medicine3Value == null ? "''" : "'" + unit.Medicine3Value.Replace("'", "''") + "'")
                    + " , " + (unit.CondensateLevel == null ? "''" : "'" + unit.CondensateLevel.Replace("'", "''") + "'")
                    + " , " + (unit.CondensateSilverNitrateDrops == null ? "''" : "'" + unit.CondensateSilverNitrateDrops.Replace("'", "''") + "'")
                    + " , " + (unit.TankWaterLeverl == null ? "''" : "'" + unit.TankWaterLeverl.Replace("'", "''") + "'")
                    + " , " + (unit.TankWateSilverNitrateDrops == null ? "''" : "'" + unit.TankWateSilverNitrateDrops.Replace("'", "''") + "'")
                    + " , " + (unit.Remarks == null ? "''" : "'" + unit.Remarks.Replace("'", "''") + "'")
                    + " , " + (unit.ExperimentOrHandlePersonName == null ? "''" : "'" + unit.ExperimentOrHandlePersonName.Replace("'", "''") + "'")
                    + " , " + (unit.ChiefEngineerName == null ? "''" : "'" + unit.ChiefEngineerName.Replace("'", "''") + "'")
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_REPORT_BOILERWATER中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_REPORT_BOILERWATER对象</param>
        internal bool deleteUnit(ReportBoilerwater unit, out string err)
        {
            return deleteUnit(unit.Report_BoilerWater_Id, out err);
        }

        /// <summary>
        /// 删除数据表T_REPORT_BOILERWATER中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_REPORT_BOILERWATER.report_BoilerWater_Id主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_REPORT_BOILERWATER where "
                + " upper(T_REPORT_BOILERWATER.Report_BoilerWater_Id)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_REPORT_BOILERWATER 所有数据信息.
        /// </summary>
        /// <returns>T_REPORT_BOILERWATER DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "Report_BoilerWater_Id"
                + ",File_ID"
                + ",SHIP_ID"
                + ",BoilerCategory"
                + ",BoilerAirPressure"
                + ",BoilerWaterQuantity"
                + ",FileDate"
                + ",PhenolphthaleinAlkalinity"
                + ",SaltAmount"
                + ",Hardness"
                + ",PHValue"
                + ",SewageOnAmount"
                + ",SewageNextAmount"
                + ",Medicine1"
                + ",Medicine2"
                + ",Medicine3"
                + ",Medicine1Value"
                + ",Medicine2Value"
                + ",Medicine3Value"
                + ",CondensateLevel"
                + ",CondensateSilverNitrateDrops"
                + ",TankWaterLeverl"
                + ",TankWateSilverNitrateDrops"
                + ",Remarks"
                + ",ExperimentOrHandlePersonName"
                + ",ChiefEngineerName"
                + "  from T_REPORT_BOILERWATER ";
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
        /// 根据一个主键ID,得到 T_REPORT_BOILERWATER 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>ReportBoilerwater DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "Report_BoilerWater_Id"
                + ",File_ID"
                + ",SHIP_ID"
                + ",BoilerCategory"
                + ",BoilerAirPressure"
                + ",BoilerWaterQuantity"
                + ",FileDate"
                + ",PhenolphthaleinAlkalinity"
                + ",SaltAmount"
                + ",Hardness"
                + ",PHValue"
                + ",SewageOnAmount"
                + ",SewageNextAmount"
                + ",Medicine1"
                + ",Medicine2"
                + ",Medicine3"
                + ",Medicine1Value"
                + ",Medicine2Value"
                + ",Medicine3Value"
                + ",CondensateLevel"
                + ",CondensateSilverNitrateDrops"
                + ",TankWaterLeverl"
                + ",TankWateSilverNitrateDrops"
                + ",Remarks"
                + ",ExperimentOrHandlePersonName"
                + ",ChiefEngineerName"
                + " from T_REPORT_BOILERWATER "
                + " where upper(Report_BoilerWater_Id)='" + Id.ToUpper() + "'";
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
        /// 根据reportboilerwater 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>reportboilerwater 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
        public ReportBoilerwater getObject(DataRow dr)
        {
            ReportBoilerwater unit = new ReportBoilerwater();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造ReportBoilerwater类对象!";
                return unit;
            }
            if (DBNull.Value != dr["Report_BoilerWater_Id"])
                unit.Report_BoilerWater_Id = dr["Report_BoilerWater_Id"].ToString();
            if (DBNull.Value != dr["File_ID"])
                unit.File_ID = dr["File_ID"].ToString();
            if (DBNull.Value != dr["SHIP_ID"])
                unit.SHIP_ID = dr["SHIP_ID"].ToString();
            if (DBNull.Value != dr["BoilerCategory"])
                unit.BoilerCategory = dr["BoilerCategory"].ToString();
            if (DBNull.Value != dr["BoilerAirPressure"])
                unit.BoilerAirPressure = dr["BoilerAirPressure"].ToString();
            if (DBNull.Value != dr["BoilerWaterQuantity"])
                unit.BoilerWaterQuantity = dr["BoilerWaterQuantity"].ToString();
            if (DBNull.Value != dr["FileDate"])
                unit.FileDate = (DateTime)dr["FileDate"];
            if (DBNull.Value != dr["PhenolphthaleinAlkalinity"])
                unit.PhenolphthaleinAlkalinity = dr["PhenolphthaleinAlkalinity"].ToString();
            if (DBNull.Value != dr["SaltAmount"])
                unit.SaltAmount = dr["SaltAmount"].ToString();
            if (DBNull.Value != dr["Hardness"])
                unit.Hardness = dr["Hardness"].ToString();
            if (DBNull.Value != dr["PHValue"])
                unit.PHValue = dr["PHValue"].ToString();
            if (DBNull.Value != dr["SewageOnAmount"])
                unit.SewageOnAmount = dr["SewageOnAmount"].ToString();
            if (DBNull.Value != dr["SewageNextAmount"])
                unit.SewageNextAmount = dr["SewageNextAmount"].ToString();
            if (DBNull.Value != dr["Medicine1"])
                unit.Medicine1 = dr["Medicine1"].ToString();
            if (DBNull.Value != dr["Medicine2"])
                unit.Medicine2 = dr["Medicine2"].ToString();
            if (DBNull.Value != dr["Medicine3"])
                unit.Medicine3 = dr["Medicine3"].ToString();
            if (DBNull.Value != dr["Medicine1Value"])
                unit.Medicine1Value = dr["Medicine1Value"].ToString();
            if (DBNull.Value != dr["Medicine2Value"])
                unit.Medicine2Value = dr["Medicine2Value"].ToString();
            if (DBNull.Value != dr["Medicine3Value"])
                unit.Medicine3Value = dr["Medicine3Value"].ToString();
            if (DBNull.Value != dr["CondensateLevel"])
                unit.CondensateLevel = dr["CondensateLevel"].ToString();
            if (DBNull.Value != dr["CondensateSilverNitrateDrops"])
                unit.CondensateSilverNitrateDrops = dr["CondensateSilverNitrateDrops"].ToString();
            if (DBNull.Value != dr["TankWaterLeverl"])
                unit.TankWaterLeverl = dr["TankWaterLeverl"].ToString();
            if (DBNull.Value != dr["TankWateSilverNitrateDrops"])
                unit.TankWateSilverNitrateDrops = dr["TankWateSilverNitrateDrops"].ToString();
            if (DBNull.Value != dr["Remarks"])
                unit.Remarks = dr["Remarks"].ToString();
            if (DBNull.Value != dr["ExperimentOrHandlePersonName"])
                unit.ExperimentOrHandlePersonName = dr["ExperimentOrHandlePersonName"].ToString();
            if (DBNull.Value != dr["ChiefEngineerName"])
                unit.ChiefEngineerName = dr["ChiefEngineerName"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个ReportBoilerwater对象.
        /// </summary>
        /// <param name="report_BoilerWater_Id">report_BoilerWater_Id</param>
        /// <returns>ReportBoilerwater对象</returns>
        public ReportBoilerwater getObject(string Id, out string err)
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
