/****************************************************************************************************
 * Copyright (C) 2009 大连陆海科技有限公司 版权所有
 * 文 件 名：T_WorkFlowService.cs
 * 创 建 人：牛振军
 * 创建时间：2009-9-25
 * 标    题：数据操作类
 * 功能描述：T_WorkFlow数据操作类
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
using ShipMisZHJ_WorkFlow.BusinessClasses;
using System.Windows.Forms;
using CommonOperation.Interfaces;
using CommonOperation.Functions;

namespace ShipMisZHJ_WorkFlow.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_WorkFlowService.cs
    /// </summary>
    public partial class T_WorkFlowService
    {
        #region 构造函数

        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static T_WorkFlowService instance;
        public static T_WorkFlowService Instance
        {
            get
            {
                if (null == instance)
                {
                    T_WorkFlowService.instance = new T_WorkFlowService();
                }
                return T_WorkFlowService.instance;
            }
        }
        #endregion
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();

        string sql = "";

        #region -----------实例化接口函数-----------

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">T_WorkFlow对象</param>
        /// <returns>插入的对象更新</returns>	
        public void saveUnit(T_WorkFlow unit, out string err)
        {
            if (!string.IsNullOrEmpty(unit.WorkFlow_Id)) //edit
            {
                sql = "UPDATE [T_WorkFlow] SET "
                                        + "[WorkFlow_Id] = '" + unit.WorkFlow_Id.Replace("'", "''") + "'"
                     + ","
                    + "[WorkFlow] = '" + unit.WorkFlow.Replace("'", "''") + "'"
                + " where upper(WorkFlow_Id) = '" + unit.WorkFlow_Id.ToUpper() + "'";
            }
            else
            {
                unit.WorkFlow_Id = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_WorkFlow] ("
                    + "[WorkFlow_Id]"

                    + "," + "[WorkFlow]"

                + ") VALUES( "
                                        + " '" + unit.WorkFlow_Id.Replace("'", "''") + "'"
                     + ","
                    + " '" + unit.WorkFlow.Replace("'", "''") + "'"
                + ")";
            }

            dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_WorkFlow中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_WorkFlow对象</param>
        public void deleteUnit(T_WorkFlow unit, out string err)
        {
            deleteUnit(unit.WorkFlow_Id, out err);
        }

        /// <summary>
        /// 删除数据表T_WorkFlow中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_WorkFlow.workFlow_Id主键</param>
        public void deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_WorkFlow where "
                + " upper(T_WorkFlow.WorkFlow_Id)='" + unitid.ToUpper() + "'";
            dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_WorkFlow 所有数据信息.
        /// </summary>
        /// <returns>T_WorkFlow DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select "
                                + "WorkFlow_Id"
                 + ","
                + "WorkFlow"
                 + "  from T_WorkFlow ";
            DataTable dt;
            dbAccess.GetDataTable(sql, out dt, out err);
            return dt;
        }
        /// <summary>
        /// 根据一个主键ID,得到 T_WorkFlow 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>T_WorkFlow DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                                + "WorkFlow_Id"
                 + ","
                + "WorkFlow"
                + " from T_WorkFlow "
                + " where upper(WorkFlow_Id)='" + Id.ToUpper() + "'";
            DataTable dt;
            dbAccess.GetDataTable(sql, out dt, out err);
            return dt;
        }
        /// <summary>
        /// 根据t_workflow 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>t_workflow 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
        public T_WorkFlow getObject(DataRow dr)
        {
            T_WorkFlow unit = new T_WorkFlow();
            if (null == dr) return null;
            if (DBNull.Value != dr["WorkFlow_Id"])
                unit.WorkFlow_Id = dr["WorkFlow_Id"].ToString();
            if (DBNull.Value != dr["WorkFlow"])
                unit.WorkFlow = dr["WorkFlow"].ToString();

            return unit;
        }
        /// <summary>
        /// 根据t_workflow 的DataGridView的DataGridViewRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataGridViewRow对象</param>
        /// <returns>t_workflow 数据实体</returns>
        ///从DataGridView获取当前选定DataGridViewRow的方法.
        ///DataGridViewRow dr=dataGridView.Rows[e.RowIndex];
        ///string o = dr.Cells["taskbegintime"].Value.ToString();
        ///MessageBox.Show(o);
        public T_WorkFlow getObject(DataGridViewRow dr)
        {
            T_WorkFlow unit = new T_WorkFlow();
            if (null == dr) return null;
            if (DBNull.Value != dr.Cells["WorkFlow_Id"].Value)
                unit.WorkFlow_Id = dr.Cells["WorkFlow_Id"].Value.ToString();
            if (DBNull.Value != dr.Cells["WorkFlow"].Value)
                unit.WorkFlow = dr.Cells["WorkFlow"].Value.ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个T_WorkFlow对象.
        /// </summary>
        /// <param name="workFlow_Id">workFlow_Id</param>
        /// <returns>T_WorkFlow对象</returns>
        public T_WorkFlow getObject(string Id, out string err)
        {
            DataTable dt = getInfo(Id, out err);
            if (dt != null && dt.Rows.Count > 0) return getObject(dt.Rows[0]);
            return null;
        }
        #endregion
        #endregion
    }
}
