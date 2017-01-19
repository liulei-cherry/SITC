/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：CMSCheckLogService.cs
 * 创 建 人：徐正本
 * 创建时间：2011/6/26
 * 标    题：数据操作类
 * 功能描述：T_CMS_CHECKING_LOG数据操作类
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
using CMSManage.DataObject;
using OfficeOperation;

namespace CMSManage.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_CMS_CHECKING_LOGService.cs
    /// </summary>
    public partial class CMSCheckLogService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static CMSCheckLogService instance = new CMSCheckLogService();
        public static CMSCheckLogService Instance
        {
            get
            {
                if (null == instance)
                {
                    CMSCheckLogService.instance = new CMSCheckLogService();
                }
                return CMSCheckLogService.instance;
            }
        }
        private CMSCheckLogService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">CMSCheckLog对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(CMSCheckLog unit, out string err)
        {
            if (unit.CHECK_LOG_ID != null && unit.CHECK_LOG_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_CMS_CHECKING_LOG] SET "
                    + " [CHECK_LOG_ID] = " + (string.IsNullOrEmpty(unit.CHECK_LOG_ID) ? "null" : "'" + unit.CHECK_LOG_ID.Replace("'", "''") + "'")
                    + " , [CHECK_NAME] = " + (unit.CHECK_NAME == null ? "''" : "'" + unit.CHECK_NAME.Replace("'", "''") + "'")
                    + " , [CHECK_DATE] = " + dbOperation.DbToDate(unit.CHECK_DATE)
                    + " , [CHECK_PERSON] = " + (unit.CHECK_PERSON == null ? "''" : "'" + unit.CHECK_PERSON.Replace("'", "''") + "'")
                    + " , [CHECK_PLACE] = " + (unit.CHECK_PLACE == null ? "''" : "'" + unit.CHECK_PLACE.Replace("'", "''") + "'")
                    + " , [CHECK_DETAIL] = " + (unit.CHECK_DETAIL == null ? "''" : "'" + unit.CHECK_DETAIL.Replace("'", "''") + "'")
                    + " , [CHECK_SPAN_BEGIN] = " + dbOperation.DbToDate(unit.CHECK_SPAN_BEGIN)
                    + " , [CHECK_SPAN_END] = " + dbOperation.DbToDate(unit.CHECK_SPAN_END)
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , [CHECK_STATE] = " + unit.CHECK_STATE.ToString()
                    + " where upper(CHECK_LOG_ID) = '" + unit.CHECK_LOG_ID.ToUpper() + "'";
            }
            else
            {
                unit.CHECK_LOG_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_CMS_CHECKING_LOG] ("
                    + "[CHECK_LOG_ID],"
                    + "[CHECK_NAME],"
                    + "[CHECK_DATE],"
                    + "[CHECK_PERSON],"
                    + "[CHECK_PLACE],"
                    + "[CHECK_DETAIL],"
                    + "[CHECK_SPAN_BEGIN],"
                    + "[CHECK_SPAN_END],"
                    + "[SHIP_ID],"
                    + "[CHECK_STATE]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.CHECK_LOG_ID) ? "null" : "'" + unit.CHECK_LOG_ID.Replace("'", "''") + "'")
                    + " , " + (unit.CHECK_NAME == null ? "''" : "'" + unit.CHECK_NAME.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.CHECK_DATE)
                    + " , " + (unit.CHECK_PERSON == null ? "''" : "'" + unit.CHECK_PERSON.Replace("'", "''") + "'")
                    + " , " + (unit.CHECK_PLACE == null ? "''" : "'" + unit.CHECK_PLACE.Replace("'", "''") + "'")
                    + " , " + (unit.CHECK_DETAIL == null ? "''" : "'" + unit.CHECK_DETAIL.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.CHECK_SPAN_BEGIN)
                    + " ," + dbOperation.DbToDate(unit.CHECK_SPAN_END)
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " ," + unit.CHECK_STATE.ToString()
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_CMS_CHECKING_LOG中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_CMS_CHECKING_LOG对象</param>
        internal bool deleteUnit(CMSCheckLog unit, out string err)
        {
            return deleteUnit(unit.CHECK_LOG_ID, out err);
        }

        /// <summary>
        /// 删除数据表T_CMS_CHECKING_LOG中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_CMS_CHECKING_LOG.cHECK_LOG_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_CMS_CHECKING_LOG where "
                + " upper(T_CMS_CHECKING_LOG.CHECK_LOG_ID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_CMS_CHECKING_LOG 所有数据信息.
        /// </summary>
        /// <returns>T_CMS_CHECKING_LOG DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "CHECK_LOG_ID"
                + ",CHECK_NAME"
                + ",CHECK_DATE"
                + ",CHECK_PERSON"
                + ",CHECK_PLACE"
                + ",CHECK_DETAIL"
                + ",CHECK_SPAN_BEGIN"
                + ",CHECK_SPAN_END"
                + ",SHIP_ID"
                + ",CHECK_STATE,(select ship_name from t_ship where t_ship.ship_id = T_CMS_CHECKING_LOG.ship_id) SHIP_NAME"
                + ",Case CHECK_STATE when 1 then 'plan' when 2 then 'complete' when 3 then 'flaw' else 'err state' end Check_State_View"
                + "\rfrom T_CMS_CHECKING_LOG order by CHECK_DATE desc";
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
        /// 根据一个主键ID,得到 T_CMS_CHECKING_LOG 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>CMSCheckLog DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "CHECK_LOG_ID"
                + ",CHECK_NAME"
                + ",CHECK_DATE"
                + ",CHECK_PERSON"
                + ",CHECK_PLACE"
                + ",CHECK_DETAIL"
                + ",CHECK_SPAN_BEGIN"
                + ",CHECK_SPAN_END"
                + ",SHIP_ID"
                + ",CHECK_STATE,(select ship_name from t_ship where t_ship.ship_id = T_CMS_CHECKING_LOG.ship_id) SHIP_NAME"
                + ",Case CHECK_STATE when 1 then 'plan' when 2 then 'complete' when 3 then 'flaw' else 'err state' end Check_State_View"
                + "\rfrom T_CMS_CHECKING_LOG "
                + "\rwhere upper(CHECK_LOG_ID)='" + Id.ToUpper() + "'";
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
        /// 根据cmschecklog 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>cmschecklog 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
        public CMSCheckLog getObject(DataRow dr)
        {
            CMSCheckLog unit = new CMSCheckLog();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造CMSCheckLog类对象!";
                return unit;
            }
            if (DBNull.Value != dr["CHECK_LOG_ID"])
                unit.CHECK_LOG_ID = dr["CHECK_LOG_ID"].ToString();
            if (DBNull.Value != dr["CHECK_NAME"])
                unit.CHECK_NAME = dr["CHECK_NAME"].ToString();
            if (DBNull.Value != dr["CHECK_DATE"])
                unit.CHECK_DATE = (DateTime)dr["CHECK_DATE"];
            if (DBNull.Value != dr["CHECK_PERSON"])
                unit.CHECK_PERSON = dr["CHECK_PERSON"].ToString();
            if (DBNull.Value != dr["CHECK_PLACE"])
                unit.CHECK_PLACE = dr["CHECK_PLACE"].ToString();
            if (DBNull.Value != dr["CHECK_DETAIL"])
                unit.CHECK_DETAIL = dr["CHECK_DETAIL"].ToString();
            if (DBNull.Value != dr["CHECK_SPAN_BEGIN"])
                unit.CHECK_SPAN_BEGIN = (DateTime)dr["CHECK_SPAN_BEGIN"];
            if (DBNull.Value != dr["CHECK_SPAN_END"])
                unit.CHECK_SPAN_END = (DateTime)dr["CHECK_SPAN_END"];
            if (DBNull.Value != dr["SHIP_ID"])
                unit.SHIP_ID = dr["SHIP_ID"].ToString();
            if (DBNull.Value != dr["CHECK_STATE"])
                unit.CHECK_STATE = Convert.ToDecimal(dr["CHECK_STATE"]);

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个CMSCheckLog对象.
        /// </summary>
        /// <param name="cHECK_LOG_ID">cHECK_LOG_ID</param>
        /// <returns>CMSCheckLog对象</returns>
        public CMSCheckLog getObject(string Id, out string err)
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

        public CMSCheckLog GetLastCheckLog(string shipId)
        {
            return GetLastCheckLog(shipId, 0, CommonOperation.ConstParameter.MaxDateTime.AddYears(-1));
        }
        public CMSCheckLog GetLastCheckLog(string shipId, int state)
        {
            return GetLastCheckLog(shipId, state, CommonOperation.ConstParameter.MaxDateTime.AddYears(-1));
        }
        /// <summary>
        /// 获取某种状态的某船的最后一次检验.
        /// </summary>
        /// <param name="shipId">船舶id,为空,则所有船</param>
        /// <param name="state">状态值,0所有,1未检验,2检验通过,3检验有缺陷</param>
        /// <returns></returns>
        public CMSCheckLog GetLastCheckLog(string shipId, int state, DateTime beforeDate)
        {
            string err;
            sql = "select top 1 "
                + "CHECK_LOG_ID"
                + ",CHECK_NAME"
                + ",CHECK_DATE"
                + ",CHECK_PLACE"
                + ",CHECK_PERSON"
                + ",CHECK_DETAIL"
                + ",CHECK_SPAN_BEGIN"
                + ",CHECK_SPAN_END"
                + ",SHIP_ID,CHECK_STATE"
                + "\rfrom T_CMS_CHECKING_LOG"
                + "\rwhere ship_id = '" + shipId.Replace("'", "''") + "' " + (state == 0 ? "" : " and CHECK_STATE = " + state.ToString())
                + " and CHECK_DATE <= " + dbOperation.DbToDate(beforeDate)
                + "\rorder by CHECK_DATE desc";
            DataTable dt;
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                if (dt.Rows.Count > 0) return getObject(dt.Rows[0]);
            }
            return null;
        }

        public bool GetOperationExcelOfOneLog(CMSCheckLog oneLog, bool withSelfCheckProject, out  OperationExcel operationExcel, out string err)
        {
            operationExcel = new OperationExcel();
            err = "";

            if (oneLog == null)
            {
                err = "检验信息有误,无法进行打印!";
                return false;
            }
            oneLog.FillThisObject();
            if (oneLog.TheShip == null)
            {
                err = "未得到被检验船舶的信息,无法进行打印";
                return false;
            }

            if (!operationExcel.AddTitle("LIST OF THE EXAMINED ITEMS", 1, out err)
                || !operationExcel.InsertABodyPair(new OnePair("No.", oneLog.CHECK_NAME, PairType.NOBORDERTWOFRAME, 2, 4, 1, 2), out err)
                || !operationExcel.InsertABodyPair(new OnePair("Name of Ship", oneLog.TheShip.SHIP_NAME, PairType.ALLBORDER, 3, 2, 1, 1), out err)
                || !operationExcel.InsertABodyPair(new OnePair("Class No.", oneLog.TheShip.CBDJH, PairType.ALLBORDER, 3, 4, 1, 2), out err)
                || !operationExcel.InsertABodyPair(new OnePair("Number and Rated Output of M.E.(KW)", oneLog.TheShip.ZJTS.ToString() + " " + oneLog.TheShip.ZJGL.ToString(), PairType.ALLBORDER, 4, 2, 1, 1), out err)
                || !operationExcel.InsertABodyPair(new OnePair("Number and Rated Output of Generator(KW)", oneLog.TheShip.FDJTS.ToString() + " " + oneLog.TheShip.FDJGL.ToString(), PairType.ALLBORDER, 4, 4, 1, 2), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("Code No.", false, 5, 2, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("Items examined", false, 5, 3, 1, 3, true, false, XlHorizontalAlignment.xlCenter), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("Status", false, 5, 6, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err))
            {
                return false;
            }
            DataTable dt = CMSCheckService.Instance.GetAllItemOfOneLog(oneLog.GetId(), withSelfCheckProject, 0);

            if (dt == null)
            {
                err = "无法获取当前检验的具体项目信息";
                return false;
            }

            string[,] body1 = new string[dt.Rows.Count, 1];
            string[,] body2 = new string[dt.Rows.Count, 1];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string stateValue = dt.Rows[i]["CHECK_STATE"].ToString();
                string checkState = (stateValue == "1" ? "plan" : (stateValue == "2" ? "Complete" : "Have Flaw"));
                body1[i, 0] = dt.Rows[i]["CMS_CODE"].ToString();
                if (!operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["CHECKENGLISHNAME"].ToString(), false, 6 + i, 3, 1, 3, true, false, XlHorizontalAlignment.xlLeft), out err))
                    return false;
                body2[i, 0] = checkState;
            }
            if (!operationExcel.InsertATable(new OneTable(body1, false, 6, 2, dt.Rows.Count, 1, false, XlHorizontalAlignment.xlLeft, new System.Drawing.Font("宋体", 9), false), out err))
                return false;
            if (!operationExcel.InsertATable(new OneTable(body2, false, 6, 6, dt.Rows.Count, 1, false, XlHorizontalAlignment.xlCenter, new System.Drawing.Font("宋体", 9), false), out err))
                return false;
            operationExcel.InsertAGrid(new OneGrid(6, 2, dt.Rows.Count, 5, new int[] { 3, 6 }, true, false));

            if (!operationExcel.InsertABodyPair(new OnePair("Place", oneLog.CHECK_PLACE, PairType.NOBORDERTWOFRAME, 7 + dt.Rows.Count, 2), out err)
               || !operationExcel.InsertABodyPair(new OnePair("Surveyor", oneLog.CHECK_PERSON, PairType.NOBORDERTWOFRAME, 7 + dt.Rows.Count, 5, 2), out err))
            {
                return false;
            }
            operationExcel.SetHorizontal(false);
            operationExcel.SetFreezePanes(1, 6);
            operationExcel.AddAllColumnSize(1, 6);
            operationExcel.AddAllColumnSize(2, 165);
            operationExcel.AddAllColumnSize(3, 223);
            operationExcel.AddAllColumnSize(4, 165);
            operationExcel.AddAllColumnSize(5, 100);
            operationExcel.AddAllColumnSize(6, 120);
            operationExcel.AddAllColumnSize(7, 6);
            operationExcel.AddAllLineSize(1, 60);
            return true;
        }

        public bool CMSCodeIsDuplicated(string code, string shipid, string exceptId)
        {
            return dbOperation.ThisShipHaveThisData(code, shipid, "T_CMS_CHECKING_LOG", "CHECK_LOG_ID", "CHECK_NAME", exceptId);
        }
    }
}
