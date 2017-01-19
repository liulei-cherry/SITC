/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：AccountService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-7-8
 * 标    题：数据操作类
 * 功能描述：T_COST_ACCOUNT数据操作类
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
using Cost.DataObject;

namespace Cost.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_COST_ACCOUNTService.cs
    /// </summary>
    public partial class AccountService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static AccountService instance = new AccountService();
        public static AccountService Instance
        {
            get
            {
                if (null == instance)
                {
                    AccountService.instance = new AccountService();
                }
                return AccountService.instance;
            }
        }
        private AccountService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">Account对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(Account unit, out string err)
        {
            if (unit.NODE_ID != null && unit.NODE_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_COST_ACCOUNT] SET "
                    + " [NODE_ID] = " + (string.IsNullOrEmpty(unit.NODE_ID) ? "null" : "'" + unit.NODE_ID.Replace("'", "''") + "'")
                    + " , [NODE_NAME] = " + (unit.NODE_NAME == null ? "''" : "'" + unit.NODE_NAME.Replace("'", "''") + "'")
                    + " , [PARENT_NODE_ID] = " + (string.IsNullOrEmpty(unit.PARENT_NODE_ID) ? "null" : "'" + unit.PARENT_NODE_ID.Replace("'", "''") + "'")
                    + " , [TOP_NODE_ID] = " + (string.IsNullOrEmpty(unit.TOP_NODE_ID) ? "null" : "'" + unit.TOP_NODE_ID.Replace("'", "''") + "'")
                    + " , [CODE] = " + (unit.CODE == null ? "''" : "'" + unit.CODE.Replace("'", "''") + "'")
                    + " , [ORDER_NUM] = " + unit.ORDER_NUM.ToString()
                    + " where upper(NODE_ID) = '" + unit.NODE_ID.ToUpper() + "'";
            }
            else
            {
                unit.NODE_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_COST_ACCOUNT] ("
                    + "[NODE_ID],"
                    + "[NODE_NAME],"
                    + "[PARENT_NODE_ID],"
                    + "[TOP_NODE_ID],"
                    + "[CODE],"
                    + "[ORDER_NUM]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.NODE_ID) ? "null" : "'" + unit.NODE_ID.Replace("'", "''") + "'")
                    + " , " + (unit.NODE_NAME == null ? "''" : "'" + unit.NODE_NAME.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.PARENT_NODE_ID) ? "null" : "'" + unit.PARENT_NODE_ID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.TOP_NODE_ID) ? "null" : "'" + unit.TOP_NODE_ID.Replace("'", "''") + "'")
                    + " , " + (unit.CODE == null ? "''" : "'" + unit.CODE.Replace("'", "''") + "'")
                    + " ," + unit.ORDER_NUM.ToString()
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err) && ResetAllTopNode(out err);
        }
        /// <summary>
        /// 删除数据表T_COST_ACCOUNT中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_COST_ACCOUNT对象</param>
        internal bool deleteUnit(Account unit, out string err)
        {
            return deleteUnit(unit.NODE_ID, out err) && ResetAllTopNode(out err);
        }

        /// <summary>
        /// 删除数据表T_COST_ACCOUNT中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_COST_ACCOUNT.nODE_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {            
            sql = "delete from T_COST_ACCOUNT where "
                + " upper(T_COST_ACCOUNT.NODE_ID)='" + unitid.ToUpper() + "'";

            return dbAccess.ExecSql(sql, out err) && ResetAllTopNode(out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_COST_ACCOUNT 所有数据信息.
        /// </summary>
        /// <returns>T_COST_ACCOUNT DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "NODE_ID"
                + ",NODE_NAME"
                + ",PARENT_NODE_ID"
                + ",TOP_NODE_ID"
                + ",CODE"
                + ",ORDER_NUM"
                + "  from T_COST_ACCOUNT ";
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
        /// 根据一个主键ID,得到 T_COST_ACCOUNT 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>Account DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "NODE_ID"
                + ",NODE_NAME"
                + ",PARENT_NODE_ID"
                + ",TOP_NODE_ID"
                + ",CODE"
                + ",ORDER_NUM"
                + " from T_COST_ACCOUNT "
                + " where upper(NODE_ID)='" + Id.ToUpper() + "'";
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
        /// 根据account 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>account 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
        public Account getObject(DataRow dr)
        {
            Account unit = new Account();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造Account类对象!";
                return unit;
            }
            if (DBNull.Value != dr["NODE_ID"])
                unit.NODE_ID = dr["NODE_ID"].ToString();
            if (DBNull.Value != dr["NODE_NAME"])
                unit.NODE_NAME = dr["NODE_NAME"].ToString();
            if (DBNull.Value != dr["PARENT_NODE_ID"])
                unit.PARENT_NODE_ID = dr["PARENT_NODE_ID"].ToString();
            if (DBNull.Value != dr["TOP_NODE_ID"])
                unit.TOP_NODE_ID = dr["TOP_NODE_ID"].ToString();
            if (DBNull.Value != dr["CODE"])
                unit.CODE = dr["CODE"].ToString();
            if (DBNull.Value != dr["ORDER_NUM"])
                unit.ORDER_NUM = Convert.ToInt32(dr["ORDER_NUM"]);

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个Account对象.
        /// </summary>
        /// <param name="nODE_ID">nODE_ID</param>
        /// <returns>Account对象</returns>
        public Account getObject(string Id, out string err)
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
 
        internal List<Account> GetObjectsByParentId(string classId)
        { 
            List<Account> reItems = new List<Account>();
            string err;
            sql = "select "
                + "NODE_ID"
                + ",NODE_NAME"
                + ",PARENT_NODE_ID"
                + ",TOP_NODE_ID,CODE,ORDER_NUM"
                + "\rfrom T_COST_ACCOUNT "
                + (string.IsNullOrEmpty(classId) ? "\rwhere PARENT_NODE_ID is null" : "\rwhere PARENT_NODE_ID  ='" + classId + "'")
                + "\rorder by ORDER_NUM";

            DataTable dt;
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Account account = getObject(dt.Rows[i]);
                    reItems.Add(account);
                }
                return reItems;
            }
            else
            {
                throw new Exception(err);
            }
        }

        internal bool GetEquipmentRoute(Account account, out List<string> LstParentIds, out string err)
        {
            err = "";
            //当结点是根结点时直接返回.
            LstParentIds = new List<string>();
            if (string.IsNullOrEmpty(account.GetId()))
            {
                err = "输入结点无效";
                return false;
            }
            string tempId = account.GetId();
            LstParentIds.Add(tempId);
            Account theObject = account;
            string parentId = theObject.PARENT_NODE_ID;
            if (string.IsNullOrEmpty(parentId))
            {
                return true;
            }

            while (!string.IsNullOrEmpty(parentId))
            {
                LstParentIds.Insert(0, parentId);
                theObject = getObject(parentId, out err);
                if (theObject == null || theObject.IsWrong)
                {
                    err = "某个上级结点不存在！";
                    return false;
                }
                parentId = theObject.PARENT_NODE_ID;
            }
            return true;
        }

        internal bool AccountCanBeOthersSubClassification(Account toJudgeOne, Account theParentOne, out string err)
        {
            if (theParentOne != null)
            {
                Account temp = theParentOne;
                while (temp != null && !temp.IsWrong)
                {
                    if (temp.GetId() != toJudgeOne.GetId())
                        temp = AccountService.Instance.getObject(temp.PARENT_NODE_ID, out err);
                    else
                    {
                        err = "出现循环设定,不能将物资分类的上级设置为自己或自己的下级";
                        return false;
                    }
                }
                err = "";
                return true;
            }
            err = "没有拖到有效节点";
            return false;
        }

        internal bool ResetAllTopNode(out string err)
        {
            sql = @"with rootCostAccout(node_id,base_name,node_name,parent_node_id,times)
                    as(
                    select node_id,node_name,node_name,parent_node_id,1
                    from T_COST_ACCOUNT
                    union all
                    select t2.node_id,t2.base_name,t1.node_name,t1.parent_node_id,times + 1
                    from T_COST_ACCOUNT t1 inner join rootCostAccout t2
                    on t1.NODE_ID = t2.parent_node_id  
                    where t1.parent_node_id is not null
                    )
                    update T_COST_ACCOUNT
                    set top_node_id = isnull(t2.parent_node_id,t1.top_node_id)
                    from T_COST_ACCOUNT t1 inner join 
                    (select t1.node_id,t1.parent_node_id from rootCostAccout t1
                    inner join (select node_id,max(times) times from rootCostAccout group by node_id)t2 
                    on t1.node_id = t2.node_id and t1.times = t2.times)t2 on t1.node_id = t2.node_id";
            return dbAccess.ExecSql(sql, out err);
        }
    }
}
