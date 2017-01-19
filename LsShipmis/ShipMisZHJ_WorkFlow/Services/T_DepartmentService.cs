/****************************************************************************************************
 * Copyright (C) 2009 大连陆海科技有限公司 版权所有
 * 文 件 名：T_DepartmentService.cs
 * 创 建 人：牛振军
 * 创建时间：2009-9-27
 * 标    题：数据操作类
 * 功能描述：T_Department数据操作类
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
    /// 数据层实例化接口类 dbo.T_DepartmentService.cs
    /// </summary>
    public partial class T_DepartmentService 
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static T_DepartmentService instance;
        public static T_DepartmentService Instance
        { 
            get
            {
                if(null==instance)
                {
                    T_DepartmentService.instance = new T_DepartmentService();
                }
                return T_DepartmentService.instance;
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
		/// <param name="unit">T_Department对象</param>
		/// <returns>插入的对象更新</returns>	
		public void saveUnit(T_Department unit,out string err)
        {
			if (!string.IsNullOrEmpty(unit.DepartmentId)) //edit
			{
				sql = "UPDATE [T_Department] SET "
										+ "[DepartmentId] = '" + unit.DepartmentId.Replace("'","''") + "'"
					 + "," 
					+ "[ParentId] = '" + unit.ParentId.Replace("'","''") + "'"
					 + "," 
					+ "[DepartmentName] = '" + unit.DepartmentName.Replace("'","''") + "'"
					+ ","
					+ "[DepartType] = " + unit.DepartType
					+ " "
				+ " where upper(DepartmentId) = '" + unit.DepartmentId.ToUpper() + "'"; 
			}
			else
			{
				unit.DepartmentId = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_Department] ("
					+ "[DepartmentId]"

					+ "," + "[ParentId]"

					+ "," + "[DepartmentName]"

					+ "," + "[DepartType]"

				+ ") VALUES( "
										+ " '" + unit.DepartmentId.Replace("'","''") + "'"
					 + "," 
					+ " '" + unit.ParentId.Replace("'","''") + "'"
					 + "," 
					+ " '" + unit.DepartmentName.Replace("'","''") + "'"
					+ ","
					+ unit.DepartType
					+ " "
				+ ")";
			}

			dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_Department中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_Department对象</param>
		public void deleteUnit(T_Department unit,out string err)
		{
			deleteUnit(unit.DepartmentId,out err);
		}
		
		/// <summary>
		/// 删除数据表T_Department中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_Department.departmentId主键</param>
		public void deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_Department where "
				+ " upper(T_Department.DepartmentId)='" + unitid.ToUpper()+ "'";
			dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_Department 所有数据信息.
		/// </summary>
		/// <returns>T_Department DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql="select "
								+ "DepartmentId"
				 + "," 
				+ "ParentId"
				 + "," 
				+ "DepartmentName"
				 + "," 
				+ "DepartType"
				 + "," 
				+ "TheOrder"
				 + "  from T_Department ";
            DataTable dt;
            dbAccess.GetDataTable(sql, out dt, out err);
            return dt;
		}
		/// <summary>
		/// 根据一个主键ID,得到 T_Department 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>T_Department DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql="select "
								+ "DepartmentId"
				 + "," 
				+ "ParentId"
				 + "," 
				+ "DepartmentName"
				 + "," 
				+ "DepartType"
				 + "," 
				+ "TheOrder"
				+ " from T_Department "
				+ " where upper(DepartmentId)='" + Id.ToUpper()+"'";
            DataTable dt;
            dbAccess.GetDataTable(sql, out dt, out err);
            return dt;
		}
        /// <summary>
		/// 根据t_department 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>t_department 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
		public T_Department getObject(DataRow dr)
		{
			T_Department unit=new T_Department();
			if (null==dr) return null;
			if (DBNull.Value != dr["DepartmentId"])	
			    unit.DepartmentId=dr["DepartmentId"].ToString();
			if (DBNull.Value != dr["ParentId"])	
			    unit.ParentId=dr["ParentId"].ToString();
			if (DBNull.Value != dr["DepartmentName"])	
			    unit.DepartmentName=dr["DepartmentName"].ToString();
			if (DBNull.Value != dr["DepartType"])	
			    unit.DepartType=Convert.ToDecimal(dr["DepartType"]);
			if (DBNull.Value != dr["TheOrder"])	
			    unit.TheOrder=Convert.ToInt32(dr["TheOrder"]);
			
			return unit;
		}
		/// <summary>
		/// 根据t_department 的DataGridView的DataGridViewRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataGridViewRow对象</param>
		/// <returns>t_department 数据实体</returns>
		///从DataGridView获取当前选定DataGridViewRow的方法.
		///DataGridViewRow dr=dataGridView.Rows[e.RowIndex];
        ///string o = dr.Cells["taskbegintime"].Value.ToString();
        ///MessageBox.Show(o);
		public T_Department getObject(DataGridViewRow dr)
		{
			T_Department unit=new T_Department();
			if (null==dr) return null;
			if (DBNull.Value != dr.Cells["DepartmentId"].Value)	
			    unit.DepartmentId=dr.Cells["DepartmentId"].Value.ToString();
			if (DBNull.Value != dr.Cells["ParentId"].Value)	
			    unit.ParentId=dr.Cells["ParentId"].Value.ToString();
			if (DBNull.Value != dr.Cells["DepartmentName"].Value)	
			    unit.DepartmentName=dr.Cells["DepartmentName"].Value.ToString();
			if (DBNull.Value != dr.Cells["DepartType"].Value)	
			    unit.DepartType=Convert.ToDecimal(dr.Cells["DepartType"].Value);
			if (DBNull.Value != dr.Cells["TheOrder"].Value)	
			    unit.TheOrder=Convert.ToInt32(dr.Cells["TheOrder"].Value);
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个T_Department对象.
		/// </summary>
		/// <param name="departmentId">departmentId</param>
		/// <returns>T_Department对象</returns>
		public  T_Department getObject(string Id,out string err)
		{
			DataTable dt=getInfo(Id,out err);
			if(dt!=null && dt.Rows.Count>0) return getObject(dt.Rows[0]);
			return null;
		}
		#endregion
		#endregion
    }
}
