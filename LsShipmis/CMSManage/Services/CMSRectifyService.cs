/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：CMSRectifyService.cs
 * 创 建 人：徐正本
 * 创建时间：2011/6/22
 * 标    题：数据操作类
 * 功能描述：T_CMS_RECTIFY数据操作类
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

namespace CMSManage.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_CMS_RECTIFYService.cs
    /// </summary>
    public partial class CMSRectifyService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static CMSRectifyService instance = new CMSRectifyService();
        public static CMSRectifyService Instance
        {
            get
            {
                if (null == instance)
                {
                    CMSRectifyService.instance = new CMSRectifyService();
                }
                return CMSRectifyService.instance;
            }
        }
        private CMSRectifyService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">CMSRectify对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(CMSRectify unit, out string err)
        {
            if (unit.CMS_RECTIFY_ID != null && unit.CMS_RECTIFY_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_CMS_RECTIFY] SET "
                    + " [CMS_RECTIFY_ID] = " + (string.IsNullOrEmpty(unit.CMS_RECTIFY_ID) ? "null" : "'" + unit.CMS_RECTIFY_ID.Replace("'", "''") + "'")
                    + " , [CMS_CHECK_ID] = " + (string.IsNullOrEmpty(unit.CMS_CHECK_ID) ? "null" : "'" + unit.CMS_CHECK_ID.Replace("'", "''") + "'")
                    + " , [RECTIFY_OPINION] = " + (unit.RECTIFY_OPINION == null ? "''" : "'" + unit.RECTIFY_OPINION.Replace("'", "''") + "'")
                    + " , [RECTIFY_STATE] = " + unit.RECTIFY_STATE.ToString()
                    + " , [RECTIFY_PLAN_DATE] = " + dbOperation.DbToDate(unit.RECTIFY_PLAN_DATE)
                    + " , [RECTIFY_DATE] = " + dbOperation.DbToDate(unit.RECTIFY_DATE)
                    + " , [RECTIFY_DETAIL] = " + (unit.RECTIFY_DETAIL == null ? "''" : "'" + unit.RECTIFY_DETAIL.Replace("'", "''") + "'")
                    + " , [RECTIFY_APPROVE] = " + (unit.RECTIFY_APPROVE == null ? "''" : "'" + unit.RECTIFY_APPROVE.Replace("'", "''") + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " where upper(CMS_RECTIFY_ID) = '" + unit.CMS_RECTIFY_ID.ToUpper() + "'";
            }
            else
            {
                unit.CMS_RECTIFY_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_CMS_RECTIFY] ("
                    + "[CMS_RECTIFY_ID],"
                    + "[CMS_CHECK_ID],"
                    + "[RECTIFY_OPINION],"
                    + "[RECTIFY_STATE],"
                    + "[RECTIFY_PLAN_DATE],"
                    + "[RECTIFY_DATE],"
                    + "[RECTIFY_DETAIL],"
                    + "[RECTIFY_APPROVE],"
                    + "[SHIP_ID]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.CMS_RECTIFY_ID) ? "null" : "'" + unit.CMS_RECTIFY_ID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.CMS_CHECK_ID) ? "null" : "'" + unit.CMS_CHECK_ID.Replace("'", "''") + "'")
                    + " , " + (unit.RECTIFY_OPINION == null ? "''" : "'" + unit.RECTIFY_OPINION.Replace("'", "''") + "'")
                    + " ," + unit.RECTIFY_STATE.ToString()
                    + " ," + dbOperation.DbToDate(unit.RECTIFY_PLAN_DATE)
                    + " ," + dbOperation.DbToDate(unit.RECTIFY_DATE)
                    + " , " + (unit.RECTIFY_DETAIL == null ? "''" : "'" + unit.RECTIFY_DETAIL.Replace("'", "''") + "'")
                    + " , " + (unit.RECTIFY_APPROVE == null ? "''" : "'" + unit.RECTIFY_APPROVE.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_CMS_RECTIFY中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_CMS_RECTIFY对象</param>
        internal bool deleteUnit(CMSRectify unit, out string err)
        {
            return deleteUnit(unit.CMS_RECTIFY_ID, out err);
        }

        /// <summary>
        /// 删除数据表T_CMS_RECTIFY中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_CMS_RECTIFY.cMS_RECTIFY_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_CMS_RECTIFY where "
                + " upper(T_CMS_RECTIFY.CMS_RECTIFY_ID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_CMS_RECTIFY 所有数据信息.
        /// </summary>
        /// <returns>T_CMS_RECTIFY DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "CMS_RECTIFY_ID"
                + ",CMS_CHECK_ID"
                + ",RECTIFY_OPINION"
                + ",RECTIFY_STATE"
                + ",RECTIFY_PLAN_DATE"
                + ",RECTIFY_DATE"
                + ",RECTIFY_DETAIL"
                + ",RECTIFY_APPROVE"
                + ",SHIP_ID"
                + "  from T_CMS_RECTIFY ";
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
        /// 根据一个主键ID,得到 T_CMS_RECTIFY 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>CMSRectify DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "CMS_RECTIFY_ID"
                + ",CMS_CHECK_ID"
                + ",RECTIFY_OPINION"
                + ",RECTIFY_STATE"
                + ",RECTIFY_PLAN_DATE"
                + ",RECTIFY_DATE"
                + ",RECTIFY_DETAIL"
                + ",RECTIFY_APPROVE"
                + ",SHIP_ID"
                + " from T_CMS_RECTIFY "
                + " where upper(CMS_RECTIFY_ID)='" + Id.ToUpper() + "'";
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
        /// 根据cmsrectify 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>cmsrectify 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
        public CMSRectify getObject(DataRow dr)
        {
            CMSRectify unit = new CMSRectify();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造CMSRectify类对象!";
                return unit;
            }
            if (DBNull.Value != dr["CMS_RECTIFY_ID"])
                unit.CMS_RECTIFY_ID = dr["CMS_RECTIFY_ID"].ToString();
            if (DBNull.Value != dr["CMS_CHECK_ID"])
                unit.CMS_CHECK_ID = dr["CMS_CHECK_ID"].ToString();
            if (DBNull.Value != dr["RECTIFY_OPINION"])
                unit.RECTIFY_OPINION = dr["RECTIFY_OPINION"].ToString();
            if (DBNull.Value != dr["RECTIFY_STATE"])
                unit.RECTIFY_STATE = Convert.ToDecimal(dr["RECTIFY_STATE"]);
            if (DBNull.Value != dr["RECTIFY_PLAN_DATE"])
                unit.RECTIFY_PLAN_DATE = (DateTime)dr["RECTIFY_PLAN_DATE"];
            if (DBNull.Value != dr["RECTIFY_DATE"])
                unit.RECTIFY_DATE = (DateTime)dr["RECTIFY_DATE"];
            if (DBNull.Value != dr["RECTIFY_DETAIL"])
                unit.RECTIFY_DETAIL = dr["RECTIFY_DETAIL"].ToString();
            if (DBNull.Value != dr["RECTIFY_APPROVE"])
                unit.RECTIFY_APPROVE = dr["RECTIFY_APPROVE"].ToString();
            if (DBNull.Value != dr["SHIP_ID"])
                unit.SHIP_ID = dr["SHIP_ID"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个CMSRectify对象.
        /// </summary>
        /// <param name="cMS_RECTIFY_ID">cMS_RECTIFY_ID</param>
        /// <returns>CMSRectify对象</returns>
        public CMSRectify getObject(string Id, out string err)
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

        /// <summary>
        /// 为CMS检查项目统一添加缺陷.
        /// </summary>
        /// <param name="theLog">当前是为哪个检验添加内容</param>
        /// <param name="checkIds">一组id</param>
        /// <param name="checkDate">预计整改时间</param>
        /// <param name="opinion">整改意见</param>
        /// <param name="err">错误原因返回值</param>
        /// <returns></returns>
        public bool SetFlawToCMSChecks(CMSCheckLog theLog, List<string> checkIds, DateTime checkDate, string opinion, out string err)
        {
            if (theLog == null || theLog.IsWrong)
            {
                err = "传入的CMS检验项目无效,不能为其添加缺陷整改意见";
                return false;
            }
            if (checkIds == null || checkIds.Count == 0)
            {
                err = "为传入任何检验记录,无法为其设置缺陷整改意见!";
                return false;
            }
            StringBuilder ids = new StringBuilder();
            foreach (string id in checkIds)
            {
                ids.Append("'" + id + "',");
            }

            string sIds = ids.ToString();
            sIds = sIds.Substring(0, sIds.Length - 1);
            List<string> sqls = new List<string>();
            sql = "update T_CMS_RECTIFY set RECTIFY_OPINION = '" + opinion.Replace("'", "''") + "',"
                + "RECTIFY_PLAN_DATE = " + dbOperation.DbToDate(checkDate)
                + "\rwhere CMS_CHECK_ID in (" + sIds + ") ";
            sqls.Add(sql);
            sql = "insert into T_CMS_RECTIFY(CMS_RECTIFY_ID,CMS_CHECK_ID,RECTIFY_OPINION,RECTIFY_STATE,RECTIFY_PLAN_DATE,SHIP_ID)"
                + "\rselect newid(),t1.CMS_CHECK_ID,'" + opinion.Replace("'", "''") + "',1, " + dbOperation.DbToDate(checkDate) + ",'" + theLog.SHIP_ID + "'"
                + "\rfrom T_CMS_CHECK t1 left join T_CMS_RECTIFY t2  on t1.CMS_CHECK_ID = t2.CMS_CHECK_ID where t1.CMS_CHECK_ID in  (" + sIds + ") and  t2.CMS_CHECK_ID is null";
            sqls.Add(sql);
            sql = "update T_CMS_CHECK set CHECK_STATE = 3 where CMS_CHECK_ID in (" + sIds + ") ";
            sqls.Add(sql);
            return dbAccess.ExecSql(sqls, out err);
        }

        internal CMSRectify getObjectByCMSCheckId(string CMS_CHECK_ID)
        {
            sql = "select "
               + "CMS_RECTIFY_ID"
               + ",CMS_CHECK_ID"
               + ",RECTIFY_OPINION"
               + ",RECTIFY_STATE"
               + ",RECTIFY_PLAN_DATE"
               + ",RECTIFY_DATE"
               + ",RECTIFY_DETAIL"
               + ",RECTIFY_APPROVE"
               + ",SHIP_ID"
               + " from T_CMS_RECTIFY "
               + " where CMS_CHECK_ID='" + CMS_CHECK_ID.Replace("'", "''") + "'";
            DataTable dt;
            string err;
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                if (dt.Rows.Count > 0)
                    return getObject(dt.Rows[0]);
                else
                    return null;
            }
            else
            {
                throw new Exception(err);
            }
        }
    }
}
