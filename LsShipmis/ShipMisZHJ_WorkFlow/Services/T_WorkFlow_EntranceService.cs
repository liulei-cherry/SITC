/****************************************************************************************************
 * Copyright (C) 2009 大连陆海科技有限公司 版权所有
 * 文 件 名：T_WorkFlow_EntranceService.cs
 * 创 建 人：牛振军
 * 创建时间：2009-9-28
 * 标    题：数据操作类
 * 功能描述：T_WorkFlow_Entrance数据操作类
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
    /// 数据层实例化接口类 dbo.T_WorkFlow_EntranceService.cs
    /// </summary>
    public partial class T_WorkFlow_EntranceService 
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static T_WorkFlow_EntranceService instance;
        public static T_WorkFlow_EntranceService Instance
        { 
            get
            {
                if(null==instance)
                {
                    T_WorkFlow_EntranceService.instance = new T_WorkFlow_EntranceService();
                }
                return T_WorkFlow_EntranceService.instance;
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
		/// <param name="unit">T_WorkFlow_Entrance对象</param>
		/// <returns>插入的对象更新</returns>	
		public void saveUnit(T_WorkFlow_Entrance unit,out string err)
        {
			if (!string.IsNullOrEmpty(unit.WorkFlow_Entrance_Id)) //edit
			{
				sql = "UPDATE [T_WorkFlow_Entrance] SET "
										+ "[WorkFlow_Entrance_Id] = '" + unit.WorkFlow_Entrance_Id.Replace("'","''") + "'"
					 + "," 
					+ "[WorkFlow_Object_Id] = '" + unit.WorkFlow_Object_Id.Replace("'","''") + "'"
					 + "," 
					+ "[DepartmentId] = '" + unit.DepartmentId.Replace("'","''") + "'"
					 + "," 
					+ "[WorkFlow_Id] = '" + unit.WorkFlow_Id.Replace("'","''") + "'"
					 + "," 
					+ "[WorkFlow_Name] = '" + unit.WorkFlow_Name.Replace("'","''") + "'"
				+ " where upper(WorkFlow_Entrance_Id) = '" + unit.WorkFlow_Entrance_Id.ToUpper() + "'"; 
			}
			else
			{
				unit.WorkFlow_Entrance_Id = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_WorkFlow_Entrance] ("
					+ "[WorkFlow_Entrance_Id]"

					+ "," + "[WorkFlow_Object_Id]"

					+ "," + "[DepartmentId]"

					+ "," + "[WorkFlow_Id]"

					+ "," + "[WorkFlow_Name]"

				+ ") VALUES( "
										+ " '" + unit.WorkFlow_Entrance_Id.Replace("'","''") + "'"
					 + "," 
					+ " '" + unit.WorkFlow_Object_Id.Replace("'","''") + "'"
					 + "," 
					+ " '" + unit.DepartmentId.Replace("'","''") + "'"
					 + "," 
					+ " '" + unit.WorkFlow_Id.Replace("'","''") + "'"
					 + "," 
					+ " '" + unit.WorkFlow_Name.Replace("'","''") + "'"
				+ ")";
			}

			dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_WorkFlow_Entrance中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_WorkFlow_Entrance对象</param>
		public void deleteUnit(T_WorkFlow_Entrance unit,out string err)
		{
			deleteUnit(unit.WorkFlow_Entrance_Id,out err);
		}
		
		/// <summary>
		/// 删除数据表T_WorkFlow_Entrance中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_WorkFlow_Entrance.workFlow_Entrance_Id主键</param>
		public void deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_WorkFlow_Entrance where "
				+ " upper(T_WorkFlow_Entrance.WorkFlow_Entrance_Id)='" + unitid.ToUpper()+ "'";
			dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_WorkFlow_Entrance 所有数据信息.
		/// </summary>
		/// <returns>T_WorkFlow_Entrance DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql="select "
								+ "WorkFlow_Entrance_Id"
				 + "," 
				+ "WorkFlow_Object_Id"
				 + "," 
				+ "DepartmentId"
				 + "," 
				+ "WorkFlow_Id"
				 + "," 
				+ "WorkFlow_Name"
				 + "  from T_WorkFlow_Entrance ";
            DataTable dt;
            dbAccess.GetDataTable(sql, out dt, out err);
            return dt;
		}
		/// <summary>
		/// 根据一个主键ID,得到 T_WorkFlow_Entrance 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>T_WorkFlow_Entrance DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql="select "
								+ "WorkFlow_Entrance_Id"
				 + "," 
				+ "WorkFlow_Object_Id"
				 + "," 
				+ "DepartmentId"
				 + "," 
				+ "WorkFlow_Id"
				 + "," 
				+ "WorkFlow_Name"
				+ " from T_WorkFlow_Entrance "
				+ " where upper(WorkFlow_Entrance_Id)='" + Id.ToUpper()+"'";
            DataTable dt;
            dbAccess.GetDataTable(sql, out dt, out err);
            return dt;
		}
        /// <summary>
		/// 根据t_workflow_entrance 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>t_workflow_entrance 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
		public T_WorkFlow_Entrance getObject(DataRow dr)
		{
			T_WorkFlow_Entrance unit=new T_WorkFlow_Entrance();
			if (null==dr) return null;
			if (DBNull.Value != dr["WorkFlow_Entrance_Id"])	
			    unit.WorkFlow_Entrance_Id=dr["WorkFlow_Entrance_Id"].ToString();
			if (DBNull.Value != dr["WorkFlow_Object_Id"])	
			    unit.WorkFlow_Object_Id=dr["WorkFlow_Object_Id"].ToString();
			if (DBNull.Value != dr["DepartmentId"])	
			    unit.DepartmentId=dr["DepartmentId"].ToString();
			if (DBNull.Value != dr["WorkFlow_Id"])	
			    unit.WorkFlow_Id=dr["WorkFlow_Id"].ToString();
			if (DBNull.Value != dr["WorkFlow_Name"])	
			    unit.WorkFlow_Name=dr["WorkFlow_Name"].ToString();
			
			return unit;
		}
		/// <summary>
		/// 根据t_workflow_entrance 的DataGridView的DataGridViewRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataGridViewRow对象</param>
		/// <returns>t_workflow_entrance 数据实体</returns>
		///从DataGridView获取当前选定DataGridViewRow的方法.
		///DataGridViewRow dr=dataGridView.Rows[e.RowIndex];
        ///string o = dr.Cells["taskbegintime"].Value.ToString();
        ///MessageBox.Show(o);
		public T_WorkFlow_Entrance getObject(DataGridViewRow dr)
		{
			T_WorkFlow_Entrance unit=new T_WorkFlow_Entrance();
			if (null==dr) return null;
			if (DBNull.Value != dr.Cells["WorkFlow_Entrance_Id"].Value)	
			    unit.WorkFlow_Entrance_Id=dr.Cells["WorkFlow_Entrance_Id"].Value.ToString();
			if (DBNull.Value != dr.Cells["WorkFlow_Object_Id"].Value)	
			    unit.WorkFlow_Object_Id=dr.Cells["WorkFlow_Object_Id"].Value.ToString();
			if (DBNull.Value != dr.Cells["DepartmentId"].Value)	
			    unit.DepartmentId=dr.Cells["DepartmentId"].Value.ToString();
			if (DBNull.Value != dr.Cells["WorkFlow_Id"].Value)	
			    unit.WorkFlow_Id=dr.Cells["WorkFlow_Id"].Value.ToString();
			if (DBNull.Value != dr.Cells["WorkFlow_Name"].Value)	
			    unit.WorkFlow_Name=dr.Cells["WorkFlow_Name"].Value.ToString();
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个T_WorkFlow_Entrance对象.
		/// </summary>
		/// <param name="workFlow_Entrance_Id">workFlow_Entrance_Id</param>
		/// <returns>T_WorkFlow_Entrance对象</returns>
		public  T_WorkFlow_Entrance getObject(string Id,out string err)
		{
			DataTable dt=getInfo(Id,out err);
			if(dt!=null && dt.Rows.Count>0) return getObject(dt.Rows[0]);
			return null;
		}
		#endregion
		#endregion

    }
}
