/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：T_COST_ACCOUNTService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-6-28
 * 标    题：数据操作类
 * 功能描述：T_COST_ACCOUNT数据操作类
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
using Cost.DataObject;

namespace Cost.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_COST_ACCOUNTService.cs
    /// </summary>
    public partial class AccountService
    {

        public List<Account> GetListByParentId(string parentId)
        {
            List<Account> lsts = new List<Account>();
            sql = "select	*"
              + " from T_COST_ACCOUNT "
              + " where PARENT_NODE_ID = '" + parentId.Replace("'", "''") + "' order by ORDER_NUM";
            sql = sql.Replace("= ''", "is null");

            DataTable dt;
            string err;
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lsts.Add(getObject(dr));
                }
                return lsts;
            }
            else
            {
                throw new Exception(err);
            }

        }

        /// <summary>
        /// 取得科目大类.
        /// </summary>
        internal DataTable GetMainSubjects()
        {

            string sMidErrMessage = "";     //错误信息返回参数.
            sql = "select NODE_ID,NODE_NAME,PARENT_NODE_ID,ORDER_NUM"
              + " from T_COST_ACCOUNT "
              + " where PARENT_NODE_ID is null order by ORDER_NUM";

            DataTable dtb;//定义一个DataTable对象.
            if (dbAccess.GetDataTable(sql, out dtb, out sMidErrMessage))
            {
                return dtb;
            }
            else
            {
                throw new Exception(sMidErrMessage);
            }
        }

        /// <summary>
        /// 取得科目大类(重载)
        /// </summary>
        internal DataTable GetMainSubjects(string ship_id, DateTime year)
        {

            string sMidErrMessage = "";     //错误信息返回参数.
            sql = "select NODE_ID,NODE_NAME,PARENT_NODE_ID,ORDER_NUM"
              + " from T_COST_ACCOUNT "
              + " where PARENT_NODE_ID is null ";
            sql += " and NODE_ID not in (select a.NODE_ID from T_COST_ANNUAL_BUDGET a ";
            sql += " where  upper(a.SHIP_ID)='" + ship_id.ToUpper() + "' and convert(varchar(4),a.YEAR_DATE,120)='" + year.ToString("yyyy") + "')";
            sql += " order by ORDER_NUM";

            DataTable dtb;//定义一个DataTable对象.
            if (dbAccess.GetDataTable(sql, out dtb, out sMidErrMessage))
            {
                return dtb;
            }
            else
            {
                throw new Exception(sMidErrMessage);
            }
        }

        /// <summary>
        /// 取得树形结构的科目列表.
        /// </summary>
        public DataTable GetTreeSubjects()
        {
            return GetTreeSubjects("");
        }

        /// <summary>
        /// 取得树形结构的科目列表.
        /// </summary>
        public DataTable GetTreeSubjects(string parent_id)
        {

            string sMidErrMessage = "";     //错误信息返回参数.
            sql = string.Format(@"select a.NODE_ID,b.path  from T_COST_ACCOUNT a, f_getC('{0}') b where a.NODE_ID = b.id
order by b.order_char", (string.IsNullOrEmpty(parent_id) ? "" : parent_id).Replace("'", "''"));

            DataTable dtb;//定义一个DataTable对象.
            if (dbAccess.GetDataTable(sql, out dtb, out sMidErrMessage))
            {
                return dtb;
            }
            else
            {
                throw new Exception(sMidErrMessage);
            }
        }
        /// <summary>
        /// 取得树形结构的科目列表,科目定位用.
        /// </summary>
        public DataTable GetTreeSubjectsByPosition(string parent_id)
        {

            string sMidErrMessage = "";     //错误信息返回参数.
            sql = "select a.NODE_ID,b.path,a.code from T_COST_ACCOUNT a, f_getC('" + parent_id + "') b"
             + " where a.NODE_ID = b.id and a.node_id not in (select node_id from t_cost_account_position) order by b.order_char";

            DataTable dtb;//定义一个DataTable对象.
            if (dbAccess.GetDataTable(sql, out dtb, out sMidErrMessage))
            {
                return dtb;
            }
            else
            {
                throw new Exception(sMidErrMessage);
            }
        }
        /// <summary>
        /// 取得父级.
        /// </summary>
        public bool GetParentNode(string nodeid, out DataTable dtb, out string err)
        {
            sql = "WITH CTE (NODE_ID,PARENT_NODE_ID, NODE_NAME)"
                + " AS"
                + " ("
                + " SELECT NODE_ID,PARENT_NODE_ID, NODE_NAME"
                + " FROM T_COST_ACCOUNT"
                + " WHERE NODE_ID='" + nodeid + "'"
                + " UNION ALL"
                + " SELECT  E.NODE_ID,E.PARENT_NODE_ID, E.NODE_NAME"
                + " FROM T_COST_ACCOUNT E"
                + " JOIN CTE ON E.NODE_ID = CTE.PARENT_NODE_ID "
                + " )"
                + " SELECT NODE_ID,PARENT_NODE_ID, NODE_NAME"
                + " FROM CTE ";
            return dbAccess.GetDataTable(sql, out dtb, out err);
        }
        /// <summary>
        /// 编码是否唯一.
        /// </summary>
        internal bool onlyOne(string code)
        {

            string sMidErrMessage = "";     //错误信息返回参数.
            sql = "select NODE_ID,NODE_NAME,PARENT_NODE_ID,ORDER_NUM"
              + " from T_COST_ACCOUNT "
              + " where CODE = '" + code.Replace("'", "''") + "'";

            DataTable dtb;//定义一个DataTable对象.
            dbAccess.GetDataTable(sql, out dtb, out sMidErrMessage);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 根据名称得到主科目对象.
        /// </summary>
        internal Account GetObjectByName(string name)
        {
            sql = "select "
            + "NODE_ID"
            + ",NODE_NAME"
            + ",PARENT_NODE_ID"
            + ",TOP_NODE_ID"
            + ",CODE"
            + ",ORDER_NUM"
            + " from T_COST_ACCOUNT "
            + " where NODE_NAME='" + dbOperation.ReplaceSqlKeyStr(name) + "' and PARENT_NODE_ID is null";
            DataTable dt;
            string err;
            if (dbAccess.GetDataTable(sql, out dt, out err) && dt.Rows.Count > 0)
            {
                return getObject(dt.Rows[0]);
            }
            else return null;
        }

        /// <summary>
        ///根据code获取科目信息.
        /// </summary>
        public DataTable getInfoByCode(string code)
        {
            string sMidErrMessage = "";     //错误信息返回参数.
            sql = "select NODE_ID,NODE_NAME,PARENT_NODE_ID,ORDER_NUM"
              + " from T_COST_ACCOUNT "
              + " where CODE = '" + code.Replace("'", "''") + "'";

            DataTable dtb;//定义一个DataTable对象.
            dbAccess.GetDataTable(sql, out dtb, out sMidErrMessage);
            return dtb;
        }
    }
}
