/****************************************************************************************************
 * Copyright (C) 2009 大连陆海科技有限公司 版权所有
 * 文 件 名：T_WorkFlow_ObjectService.cs
 * 创 建 人：牛振军
 * 创建时间：2009-9-25
 * 标    题：数据操作类
 * 功能描述：T_WorkFlow_Object数据操作类
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
    /// 数据层实例化接口类 dbo.T_WorkFlow_ObjectService.cs
    /// </summary>
    public partial class T_WorkFlow_ObjectService 
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static T_WorkFlow_ObjectService instance;
        public static T_WorkFlow_ObjectService Instance
        { 
            get
            {
                if(null==instance)
                {
                    T_WorkFlow_ObjectService.instance = new T_WorkFlow_ObjectService();
                }
                return T_WorkFlow_ObjectService.instance;
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
		/// <param name="unit">T_WorkFlow_Object对象</param>
		/// <returns>插入的对象更新</returns>	
		public void saveUnit(T_WorkFlow_Object unit,out string err)
        {
			if (!string.IsNullOrEmpty(unit.WorkFlow_Object_Id)) //edit
			{
				sql = "UPDATE [T_WorkFlow_Object] SET "
										+ "[WorkFlow_Object_Id] = '" + unit.WorkFlow_Object_Id.Replace("'","''") + "'"
					 + "," 
					+ "[WorkFlow_Object_Name] = '" + unit.WorkFlow_Object_Name.Replace("'","''") + "'"
				+ " where upper(WorkFlow_Object_Id) = '" + unit.WorkFlow_Object_Id.ToUpper() + "'"; 
			}
			else
			{
				unit.WorkFlow_Object_Id = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_WorkFlow_Object] ("
					+ "[WorkFlow_Object_Id]"

					+ "," + "[WorkFlow_Object_Name]"

				+ ") VALUES( "
										+ " '" + unit.WorkFlow_Object_Id.Replace("'","''") + "'"
					 + "," 
					+ " '" + unit.WorkFlow_Object_Name.Replace("'","''") + "'"
				+ ")";
			}

			dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_WorkFlow_Object中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_WorkFlow_Object对象</param>
		public void deleteUnit(T_WorkFlow_Object unit,out string err)
		{
			deleteUnit(unit.WorkFlow_Object_Id,out err);
		}
		
		/// <summary>
		/// 删除数据表T_WorkFlow_Object中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_WorkFlow_Object.workFlow_Object_Id主键</param>
		public void deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_WorkFlow_Object where "
				+ " upper(T_WorkFlow_Object.WorkFlow_Object_Id)='" + unitid.ToUpper()+ "'";
			dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_WorkFlow_Object 所有数据信息.
		/// </summary>
		/// <returns>T_WorkFlow_Object DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql="select "
								+ "WorkFlow_Object_Id"
				 + "," 
				+ "WorkFlow_Object_Name"
				 + "  from T_WorkFlow_Object ";
            DataTable dt;
            dbAccess.GetDataTable(sql, out dt, out err);
            return dt;
		}
		/// <summary>
		/// 根据一个主键ID,得到 T_WorkFlow_Object 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>T_WorkFlow_Object DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql="select "
								+ "WorkFlow_Object_Id"
				 + "," 
				+ "WorkFlow_Object_Name"
				+ " from T_WorkFlow_Object "
				+ " where upper(WorkFlow_Object_Id)='" + Id.ToUpper()+"'";
            DataTable dt;
            dbAccess.GetDataTable(sql, out dt, out err);
            return dt;
		}
        /// <summary>
		/// 根据t_workflow_object 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>t_workflow_object 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
		public T_WorkFlow_Object getObject(DataRow dr)
		{
			T_WorkFlow_Object unit=new T_WorkFlow_Object();
			if (null==dr) return null;
			if (DBNull.Value != dr["WorkFlow_Object_Id"])	
			    unit.WorkFlow_Object_Id=dr["WorkFlow_Object_Id"].ToString();
			if (DBNull.Value != dr["WorkFlow_Object_Name"])	
			    unit.WorkFlow_Object_Name=dr["WorkFlow_Object_Name"].ToString();
			
			return unit;
		}
		/// <summary>
		/// 根据t_workflow_object 的DataGridView的DataGridViewRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataGridViewRow对象</param>
		/// <returns>t_workflow_object 数据实体</returns>
		///从DataGridView获取当前选定DataGridViewRow的方法.
		///DataGridViewRow dr=dataGridView.Rows[e.RowIndex];
        ///string o = dr.Cells["taskbegintime"].Value.ToString();
        ///MessageBox.Show(o);
		public T_WorkFlow_Object getObject(DataGridViewRow dr)
		{
			T_WorkFlow_Object unit=new T_WorkFlow_Object();
			if (null==dr) return null;
			if (DBNull.Value != dr.Cells["WorkFlow_Object_Id"].Value)	
			    unit.WorkFlow_Object_Id=dr.Cells["WorkFlow_Object_Id"].Value.ToString();
			if (DBNull.Value != dr.Cells["WorkFlow_Object_Name"].Value)	
			    unit.WorkFlow_Object_Name=dr.Cells["WorkFlow_Object_Name"].Value.ToString();
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个T_WorkFlow_Object对象.
		/// </summary>
		/// <param name="workFlow_Object_Id">workFlow_Object_Id</param>
		/// <returns>T_WorkFlow_Object对象</returns>
		public  T_WorkFlow_Object getObject(string Id,out string err)
		{
			DataTable dt=getInfo(Id,out err);
			if(dt!=null && dt.Rows.Count>0) return getObject(dt.Rows[0]);
			return null;
		}
		#endregion
		#endregion

    }
}
