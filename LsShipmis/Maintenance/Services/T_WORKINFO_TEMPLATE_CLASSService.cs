/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：T_WORKINFO_TEMPLATE_CLASSService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-5-13
 * 标    题：数据操作类
 * 功能描述：T_WORKINFO_TEMPLATE_CLASS数据操作类
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
using Maintenance.DataObject;

namespace  Maintenance.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_WORKINFO_TEMPLATE_CLASSService.cs
    /// </summary>
    public partial class T_WORKINFO_TEMPLATE_CLASSService
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static T_WORKINFO_TEMPLATE_CLASSService instance=new T_WORKINFO_TEMPLATE_CLASSService();
        public static T_WORKINFO_TEMPLATE_CLASSService Instance
        { 
            get
            {
                if(null==instance)
                {
                    T_WORKINFO_TEMPLATE_CLASSService.instance = new T_WORKINFO_TEMPLATE_CLASSService();
                }
                return T_WORKINFO_TEMPLATE_CLASSService.instance;
            }
        }
		private T_WORKINFO_TEMPLATE_CLASSService(){}
		#endregion
		
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();        
        string sql = ""; 
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">T_WORKINFO_TEMPLATE_CLASS对象</param>
		/// <returns>插入的对象更新</returns>	
		internal bool saveUnit(T_WORKINFO_TEMPLATE_CLASS unit,out string err)
        {
			if (unit.NODE_ID!=null && unit.NODE_ID.Length > 0) //edit
			{
				sql = "UPDATE [T_WORKINFO_TEMPLATE_CLASS] SET "
					+ " [NODE_ID] = " + (string.IsNullOrEmpty(unit.NODE_ID)?"null":"'" + unit.NODE_ID.Replace ("'","''") + "'")
					+ " , [NODE_NAME] = " + (unit.NODE_NAME==null?"''":"'" + unit.NODE_NAME.Replace ("'","''") + "'")
					+ " , [PARENT_NODE_ID] = " + (string.IsNullOrEmpty(unit.PARENT_NODE_ID)?"null":"'" + unit.PARENT_NODE_ID.Replace ("'","''") + "'")
					+ " , [SORTNO] = " + unit.SORTNO.ToString()
					+ " where upper(NODE_ID) = '" + unit.NODE_ID.ToUpper() + "'"; 
			}
			else
			{
				unit.NODE_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_WORKINFO_TEMPLATE_CLASS] ("
					+ "[NODE_ID],"
					+ "[NODE_NAME],"
					+ "[PARENT_NODE_ID],"
					+ "[SORTNO]"
					+ ") VALUES( "
					+ " " + (string.IsNullOrEmpty(unit.NODE_ID)?"null":"'" + unit.NODE_ID.Replace ("'","''") + "'")
					+ " , " + (unit.NODE_NAME==null?"''":"'" + unit.NODE_NAME.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.PARENT_NODE_ID)?"null":"'" + unit.PARENT_NODE_ID.Replace ("'","''") + "'")
					+ " ,"+ unit.SORTNO.ToString()
					+ ")";
			}

			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_WORKINFO_TEMPLATE_CLASS中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_WORKINFO_TEMPLATE_CLASS对象</param>
		internal bool deleteUnit(T_WORKINFO_TEMPLATE_CLASS unit,out string err)
		{
			return deleteUnit(unit.NODE_ID,out err);
		}
		
		/// <summary>
		/// 删除数据表T_WORKINFO_TEMPLATE_CLASS中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_WORKINFO_TEMPLATE_CLASS.nODE_ID主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_WORKINFO_TEMPLATE_CLASS where "
				+ " upper(T_WORKINFO_TEMPLATE_CLASS.NODE_ID)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_WORKINFO_TEMPLATE_CLASS 所有数据信息.
		/// </summary>
		/// <returns>T_WORKINFO_TEMPLATE_CLASS DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql = "select	"
				+ "NODE_ID"
				+ ",NODE_NAME"
				+ ",PARENT_NODE_ID"
				+ ",SORTNO"
				+ "  from T_WORKINFO_TEMPLATE_CLASS ";
			DataTable dt;
			if(dbAccess.GetDataTable(sql,out dt, out err))
			{
				return dt;
			}
			else
			{
				throw new Exception(err);
			}
		}
		/// <summary>
		/// 根据一个主键ID,得到 T_WORKINFO_TEMPLATE_CLASS 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>T_WORKINFO_TEMPLATE_CLASS DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql = "select "
				+ "NODE_ID"
				+ ",NODE_NAME"
				+ ",PARENT_NODE_ID"
				+ ",SORTNO"
				+ " from T_WORKINFO_TEMPLATE_CLASS "
				+ " where upper(NODE_ID)='" + Id.ToUpper()+"'";
			DataTable dt;
			if(dbAccess.GetDataTable(sql,out dt, out err))
			{
				return dt;
			}
			else
			{
				throw new Exception(err);
			}
		}
        /// <summary>
		/// 根据t_workinfo_template_class 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>t_workinfo_template_class 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
		public T_WORKINFO_TEMPLATE_CLASS getObject(DataRow dr)
		{
			T_WORKINFO_TEMPLATE_CLASS unit=new T_WORKINFO_TEMPLATE_CLASS();
			if (null==dr)
			{
				unit.IsWrong = true;
				unit.WhyWrong = "从数据库获取信息时出错,未成功构造T_WORKINFO_TEMPLATE_CLASS类对象!";
				return unit;
			}
			if (DBNull.Value != dr["NODE_ID"])	
			    unit.NODE_ID=dr["NODE_ID"].ToString();
			if (DBNull.Value != dr["NODE_NAME"])	
			    unit.NODE_NAME=dr["NODE_NAME"].ToString();
			if (DBNull.Value != dr["PARENT_NODE_ID"])	
			    unit.PARENT_NODE_ID=dr["PARENT_NODE_ID"].ToString();
			if (DBNull.Value != dr["SORTNO"])	
			    unit.SORTNO=Convert.ToInt32(dr["SORTNO"]);
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个T_WORKINFO_TEMPLATE_CLASS对象.
		/// </summary>
		/// <param name="nODE_ID">nODE_ID</param>
		/// <returns>T_WORKINFO_TEMPLATE_CLASS对象</returns>
		public  T_WORKINFO_TEMPLATE_CLASS getObject(string Id,out string err)
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
