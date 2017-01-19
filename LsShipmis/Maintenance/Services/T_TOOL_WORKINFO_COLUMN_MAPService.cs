/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：T_TOOL_WORKINFO_COLUMN_MAPService.cs
 * 创 建 人：黄家龙
 * 创建时间：2011/10/19
 * 标    题：数据操作类
 * 功能描述：T_TOOL_WORKINFO_COLUMN_MAP数据操作类
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
using Maintenance.DataObject;

namespace  Maintenance.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_TOOL_WORKINFO_COLUMN_MAPService.cs
    /// </summary>
    public partial class T_TOOL_WORKINFO_COLUMN_MAPService
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static T_TOOL_WORKINFO_COLUMN_MAPService instance=new T_TOOL_WORKINFO_COLUMN_MAPService();
        public static T_TOOL_WORKINFO_COLUMN_MAPService Instance
        { 
            get
            {
                if(null==instance)
                {
                    T_TOOL_WORKINFO_COLUMN_MAPService.instance = new T_TOOL_WORKINFO_COLUMN_MAPService();
                }
                return T_TOOL_WORKINFO_COLUMN_MAPService.instance;
            }
        }
		private T_TOOL_WORKINFO_COLUMN_MAPService(){}
		#endregion
		
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();        
        string sql = ""; 
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">T_TOOL_WORKINFO_COLUMN_MAP对象</param>
		/// <returns>插入的对象更新</returns>	
		internal bool saveUnit(T_TOOL_WORKINFO_COLUMN_MAP unit,out string err)
        {
			if (unit.MAPID!=null && unit.MAPID.Length > 0) //edit
			{
				sql = "UPDATE [T_TOOL_WORKINFO_COLUMN_MAP] SET "
					+ " [MAPID] = " + (string.IsNullOrEmpty(unit.MAPID)?"null":"'" + unit.MAPID.Replace ("'","''") + "'")
					+ " , [TOOL_COLUMN_NAME] = " + (unit.TOOL_COLUMN_NAME==null?"''":"'" + unit.TOOL_COLUMN_NAME.Replace ("'","''") + "'")
					+ " , [WORK_COLUMN_NAME] = " + (unit.WORK_COLUMN_NAME==null?"''":"'" + unit.WORK_COLUMN_NAME.Replace ("'","''") + "'")
					+ " , [MAPTYPE] = " + unit.MAPTYPE.ToString()
					+ " , [ORDER_NUM] = " + unit.ORDER_NUM.ToString()
					+ " where upper(MAPID) = '" + unit.MAPID.ToUpper() + "'"; 
			}
			else
			{
				unit.MAPID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_TOOL_WORKINFO_COLUMN_MAP] ("
					+ "[MAPID],"
					+ "[TOOL_COLUMN_NAME],"
					+ "[WORK_COLUMN_NAME],"
					+ "[MAPTYPE],"
					+ "[ORDER_NUM]"
					+ ") VALUES( "
					+ " " + (string.IsNullOrEmpty(unit.MAPID)?"null":"'" + unit.MAPID.Replace ("'","''") + "'")
					+ " , " + (unit.TOOL_COLUMN_NAME==null?"''":"'" + unit.TOOL_COLUMN_NAME.Replace ("'","''") + "'")
					+ " , " + (unit.WORK_COLUMN_NAME==null?"''":"'" + unit.WORK_COLUMN_NAME.Replace ("'","''") + "'")
					+ " ,"+ unit.MAPTYPE.ToString()
					+ " ,"+ unit.ORDER_NUM.ToString()
					+ ")";
			}
	
			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_TOOL_WORKINFO_COLUMN_MAP中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_TOOL_WORKINFO_COLUMN_MAP对象</param>
		internal bool deleteUnit(T_TOOL_WORKINFO_COLUMN_MAP unit,out string err)
		{
			return deleteUnit(unit.MAPID,out err);
		}
		
		/// <summary>
		/// 删除数据表T_TOOL_WORKINFO_COLUMN_MAP中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_TOOL_WORKINFO_COLUMN_MAP.mAPID主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_TOOL_WORKINFO_COLUMN_MAP where "
				+ " upper(T_TOOL_WORKINFO_COLUMN_MAP.MAPID)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_TOOL_WORKINFO_COLUMN_MAP 所有数据信息.
		/// </summary>
		/// <returns>T_TOOL_WORKINFO_COLUMN_MAP DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql = "select	"
				+ "MAPID"
				+ ",TOOL_COLUMN_NAME"
				+ ",WORK_COLUMN_NAME"
				+ ",MAPTYPE"
				+ ",ORDER_NUM"
				+ "  from T_TOOL_WORKINFO_COLUMN_MAP ";
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
		/// 根据一个主键ID,得到 T_TOOL_WORKINFO_COLUMN_MAP 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>T_TOOL_WORKINFO_COLUMN_MAP DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql = "select "
				+ "MAPID"
				+ ",TOOL_COLUMN_NAME"
				+ ",WORK_COLUMN_NAME"
				+ ",MAPTYPE"
				+ ",ORDER_NUM"
				+ " from T_TOOL_WORKINFO_COLUMN_MAP "
				+ " where upper(MAPID)='" + Id.ToUpper()+"'";
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
		/// 根据t_tool_workinfo_column_map 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>t_tool_workinfo_column_map 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
		public T_TOOL_WORKINFO_COLUMN_MAP getObject(DataRow dr)
		{
			T_TOOL_WORKINFO_COLUMN_MAP unit=new T_TOOL_WORKINFO_COLUMN_MAP();
			if (null==dr)
			{
				unit.IsWrong = true;
				unit.WhyWrong = "从数据库获取信息时出错,未成功构造T_TOOL_WORKINFO_COLUMN_MAP类对象!";
				return unit;
			}
			if (DBNull.Value != dr["MAPID"])	
			    unit.MAPID=dr["MAPID"].ToString();
			if (DBNull.Value != dr["TOOL_COLUMN_NAME"])	
			    unit.TOOL_COLUMN_NAME=dr["TOOL_COLUMN_NAME"].ToString();
			if (DBNull.Value != dr["WORK_COLUMN_NAME"])	
			    unit.WORK_COLUMN_NAME=dr["WORK_COLUMN_NAME"].ToString();
			if (DBNull.Value != dr["MAPTYPE"])	
			    unit.MAPTYPE=Convert.ToDecimal(dr["MAPTYPE"]);
			if (DBNull.Value != dr["ORDER_NUM"])	
			    unit.ORDER_NUM=Convert.ToInt32(dr["ORDER_NUM"]);
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个T_TOOL_WORKINFO_COLUMN_MAP对象.
		/// </summary>
		/// <param name="mAPID">mAPID</param>
		/// <returns>T_TOOL_WORKINFO_COLUMN_MAP对象</returns>
		public  T_TOOL_WORKINFO_COLUMN_MAP getObject(string Id,out string err)
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
