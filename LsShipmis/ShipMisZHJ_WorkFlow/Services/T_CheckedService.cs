/****************************************************************************************************
 * Copyright (C) 2009 大连陆海科技有限公司 版权所有
 * 文 件 名：T_CheckedService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2009-11-3
 * 标    题：数据操作类
 * 功能描述：T_Checked数据操作类
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
    /// 数据层实例化接口类 dbo.T_CheckedService.cs
    /// </summary>
    public partial class T_CheckedService
    {
        #region 构造函数

        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static T_CheckedService instance;
        public static T_CheckedService Instance
        {
            get
            {
                if (null == instance)
                {
                    T_CheckedService.instance = new T_CheckedService();
                }
                return T_CheckedService.instance;
            }
        }
        #endregion
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        string sql = "";

        #region -----------实例化接口函数-----------

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">T_Checked对象</param>
        /// <returns>插入的对象更新</returns>	
        public void saveUnit(T_Checked unit, out string err)
        {
            if (!string.IsNullOrEmpty(unit.Checked_Id)) //edit
            {
                sql = "UPDATE [T_Checked] SET "
                                        + "[Checked_Id] = '" + unit.Checked_Id.Replace("'", "''") + "'"
                     + ","
                    + "[WorkFlow_Id] = '" + unit.WorkFlow_Id.Replace("'", "''") + "'"
                     + ","
                    + "[Current_WorkFlow_Id] = '" + unit.Current_WorkFlow_Id.Replace("'", "''") + "'"
                     + ","
                    + "[Current_PostId] = '" + unit.CurrentPostName.Replace("'", "''") + "'"
                    + ","
                    + "[Current_State] = " + unit.Current_State
                     + ","
                    + "[Business_Object_Id] = '" + unit.Business_Object_Id.Replace("'", "''") + "'"
                    + ","
                    + "[Ship_Id] = '" + unit.Ship_Id.Replace("'", "''") + "'"
                + " where upper(Checked_Id) = '" + unit.Checked_Id.ToUpper() + "'";
            }
            else
            {
                unit.Checked_Id = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_Checked] ("
                    + "[Checked_Id]"

                    + "," + "[WorkFlow_Id]"

                    + "," + "[Current_WorkFlow_Id]"

                    + "," + "[Current_PostId]"

                    + "," + "[Current_State]"

                    + "," + "[Business_Object_Id]"

                    + "," + "[Business_Object_Type]"

                    + "," + "[Ship_Id]"

                + ") VALUES( "
                                        + " '" + unit.Checked_Id.Replace("'", "''") + "'"
                     + ","
                    + " '" + unit.WorkFlow_Id.Replace("'", "''") + "'"
                     + ","
                    + " '" + unit.Current_WorkFlow_Id.Replace("'", "''") + "'"
                     + ","
                    + " '" + unit.CurrentPostName.Replace("'", "''") + "'"
                    + ","
                    + unit.Current_State
                     + ","
                    + " '" + unit.Business_Object_Id.Replace("'", "''") + "'"
                     + ",'" + unit.Ship_Id.Replace("'", "''") + "'"
                + ")";
            }

            dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_Checked中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_Checked对象</param>
        public void deleteUnit(T_Checked unit, out string err)
        {
            deleteUnit(unit.Checked_Id, out err);
        }

        /// <summary>
        /// 删除数据表T_Checked中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_Checked.checked_Id主键</param>
        public void deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_Checked where "
                + " upper(T_Checked.Checked_Id)='" + unitid.ToUpper() + "'";
            dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_Checked 所有数据信息.
        /// </summary>
        /// <returns>T_Checked DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select "
                                + "Checked_Id"
                 + ","
                + "WorkFlow_Id"
                 + ","
                + "Current_WorkFlow_Id"
                 + ","
                + "Current_PostId"
                 + ","
                + "Current_State"
                 + ","
                + "Business_Object_Id"
                 + ","
                + "Business_Object_Type"
                 + ","
                + "Ship_Id"
                 + "  from T_Checked ";
            DataTable dt;
            dbAccess.GetDataTable(sql, out dt, out err);
            return dt;
        }
        /// <summary>
        /// 根据一个主键ID,得到 T_Checked 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>T_Checked DataTable</returns>
        public DataTable GetInfo(string Id, out string err)
        {
            sql = "select "
                                + "Checked_Id"
                 + ","
                + "WorkFlow_Id"
                 + ","
                + "Current_WorkFlow_Id"
                 + ","
                + "Current_PostId"
                 + ","
                + "Current_State"
                 + ","
                + "Business_Object_Id"
                 + ","
                + "Business_Object_Type"
                 + ","
                + "Ship_Id"
                + " from T_Checked "
                + " where upper(Checked_Id)='" + Id.ToUpper() + "'";
            DataTable dt;
            dbAccess.GetDataTable(sql, out dt, out err);
            return dt;
        }
        /// <summary>
        /// 根据t_checked 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>t_checked 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
        public T_Checked getObject(DataRow dr)
        {
            T_Checked unit = new T_Checked();
            if (null == dr) return null;
            if (DBNull.Value != dr["Checked_Id"])
                unit.Checked_Id = dr["Checked_Id"].ToString();
            if (DBNull.Value != dr["WorkFlow_Id"])
                unit.WorkFlow_Id = dr["WorkFlow_Id"].ToString();
            if (DBNull.Value != dr["Current_WorkFlow_Id"])
                unit.Current_WorkFlow_Id = dr["Current_WorkFlow_Id"].ToString();
            if (DBNull.Value != dr["Current_PostId"])
                unit.CurrentPostName = dr["Current_PostId"].ToString();
            if (DBNull.Value != dr["Current_State"])
                unit.Current_State = Convert.ToDecimal(dr["Current_State"]);
            if (DBNull.Value != dr["Business_Object_Id"])
                unit.Business_Object_Id = dr["Business_Object_Id"].ToString();
            if (DBNull.Value != dr["Ship_Id"])
                unit.Ship_Id = dr["Ship_Id"].ToString();

            return unit;
        }
        /// <summary>
        /// 根据t_checked 的DataGridView的DataGridViewRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataGridViewRow对象</param>
        /// <returns>t_checked 数据实体</returns>
        ///从DataGridView获取当前选定DataGridViewRow的方法.
        ///DataGridViewRow dr=dataGridView.Rows[e.RowIndex];
        ///string o = dr.Cells["taskbegintime"].Value.ToString();
        ///MessageBox.Show(o);
        public T_Checked getObject(DataGridViewRow dr)
        {
            T_Checked unit = new T_Checked();
            if (null == dr) return null;
            if (DBNull.Value != dr.Cells["Checked_Id"].Value)
                unit.Checked_Id = dr.Cells["Checked_Id"].Value.ToString();
            if (DBNull.Value != dr.Cells["WorkFlow_Id"].Value)
                unit.WorkFlow_Id = dr.Cells["WorkFlow_Id"].Value.ToString();
            if (DBNull.Value != dr.Cells["Current_WorkFlow_Id"].Value)
                unit.Current_WorkFlow_Id = dr.Cells["Current_WorkFlow_Id"].Value.ToString();
            if (DBNull.Value != dr.Cells["Current_PostId"].Value)
                unit.CurrentPostName = dr.Cells["Current_PostId"].Value.ToString();
            if (DBNull.Value != dr.Cells["Current_State"].Value)
                unit.Current_State = Convert.ToDecimal(dr.Cells["Current_State"].Value);
            if (DBNull.Value != dr.Cells["Business_Object_Id"].Value)
                unit.Business_Object_Id = dr.Cells["Business_Object_Id"].Value.ToString();
            if (DBNull.Value != dr.Cells["Ship_Id"].Value)
                unit.Ship_Id = dr.Cells["Ship_Id"].Value.ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个T_Checked对象.
        /// </summary>
        /// <param name="checked_Id">checked_Id</param>
        /// <returns>T_Checked对象</returns>
        internal T_Checked GetObject(string Id, out string err)
        {
            DataTable dt = GetInfo(Id, out err);
            if (dt != null && dt.Rows.Count > 0) return getObject(dt.Rows[0]);
            return null;
        }
        #endregion
        #endregion
    }
}
