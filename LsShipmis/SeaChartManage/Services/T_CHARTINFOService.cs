/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：T_CHARTINFOService.cs
 * 创 建 人：牛振军
 * 创建时间：2008-12-29
 * 标    题：数据操作类
 * 功能描述：T_CHARTINFO数据操作类
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
using SeaChartManage.BusinessClasses; 
using System.Windows.Forms;
using CommonOperation.Interfaces;
using CommonOperation.Functions;

namespace SeaChartManage.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_CHARTINFOService.cs
    /// </summary>
    public class T_CHARTINFOService 
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static T_CHARTINFOService instance=new T_CHARTINFOService();
        public static T_CHARTINFOService Instance
        { 
            get
            {
                if(null==instance)
                {
                    T_CHARTINFOService.instance = new T_CHARTINFOService();
                }
                return T_CHARTINFOService.instance;
            }
        }
		#endregion
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";
        // string err = "";
		
        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">T_CHARTINFO对象</param>
		/// <returns>插入的对象更新</returns>	
		public bool saveUnit(T_CHARTINFO unit,out string err)
        {
			if (unit.ChartInfoId!=null && unit.ChartInfoId.Length > 0) //edit
			{
				sql = "UPDATE [T_CHARTINFO] SET "
					 + "[ChartInfoId] = '" + unit.ChartInfoId + "'"
					+ ","
					 + "[CHARTTITLE] = '" + unit.CHARTTITLE + "'"
					+ ","
					 + "[CHARTCONTENT] = '" + unit.CHARTCONTENT + "'"
					+ ","
					 + "[PUBLISHER] = '" + unit.PUBLISHER + "'"
					+ ","
                       + "[PUBLISHDATE] = " + dbOperation.DbToDate(unit.PUBLISHDATE)
				+ " where upper(ChartInfoId) = '" + unit.ChartInfoId.ToUpper() + "'"; 
			}
			else
			{
                unit.ChartInfoId = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_CHARTINFO] ("
									  + "[ChartInfoId]"
				 + ","
					  + "[CHARTTITLE]"
				 + ","
					  + "[CHARTCONTENT]"
				 + ","
					  + "[PUBLISHER]"
				 + ","
					  + "[PUBLISHDATE]"
				+ ") VALUES( "
									  + " '" + unit.ChartInfoId + "'"
				 + ","
					  + " '" + unit.CHARTTITLE + "'"
				 + ","
					  + " '" + unit.CHARTCONTENT + "'"
				 + ","
					  + " '" + unit.PUBLISHER + "'"
				 + ","
                      + dbOperation.DbToDate(unit.PUBLISHDATE)
				+ ")";
			}
			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_CHARTINFO中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_CHARTINFO对象</param>
		public bool deleteUnit(T_CHARTINFO unit,out string err)
		{
			return deleteUnit(unit.ChartInfoId,out err);
		}
		
		/// <summary>
		/// 删除数据表T_CHARTINFO中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_CHARTINFO.chartInfoId主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_CHARTINFO where "
				+ " upper(T_CHARTINFO.ChartInfoId)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_CHARTINFO 所有数据信息.
		/// </summary>
		/// <returns>T_CHARTINFO DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql="select "
								+ "ChartInfoId"
				 + "," 
				+ "CHARTTITLE"
				 + "," 
				+ "CHARTCONTENT"
				 + "," 
				+ "PUBLISHER"
				 + "," 
				+ "PUBLISHDATE"
				 + "  from T_CHARTINFO ";
            DataTable dtb;
            dbAccess.GetDataTable(sql,out dtb, out err);
            return dtb;
		}
		/// <summary>
		/// 根据一个主键ID,得到 T_CHARTINFO 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>T_CHARTINFO DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql="select "
								+ "ChartInfoId"
				 + "," 
				+ "CHARTTITLE"
				 + "," 
				+ "CHARTCONTENT"
				 + "," 
				+ "PUBLISHER"
				 + "," 
				+ "PUBLISHDATE"
				+ " from T_CHARTINFO "
				+ " where upper(ChartInfoId)='" + Id.ToUpper()+"'";
            DataTable dtb;
            dbAccess.GetDataTable(sql,out dtb, out err);
            return dtb;
		}
        /// <summary>
		/// 根据t_chartinfo 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>t_chartinfo 数据实体</returns>
		public T_CHARTINFO getObject(DataRow dr)
		{
			T_CHARTINFO unit=new T_CHARTINFO();
			if (null==dr) return null;
			if (DBNull.Value != dr["ChartInfoId"])	
			    unit.ChartInfoId=dr["ChartInfoId"].ToString();
			if (DBNull.Value != dr["CHARTTITLE"])	
			    unit.CHARTTITLE=dr["CHARTTITLE"].ToString();
			if (DBNull.Value != dr["CHARTCONTENT"])	
			    unit.CHARTCONTENT=dr["CHARTCONTENT"].ToString();
			if (DBNull.Value != dr["PUBLISHER"])	
			    unit.PUBLISHER=dr["PUBLISHER"].ToString();
			if (DBNull.Value != dr["PUBLISHDATE"])	
                unit.PUBLISHDATE=(DateTime)dr["PUBLISHDATE"];
			
			return unit;
		}
		/// <summary>
		/// 根据t_chartinfo 的DataGridView的DataGridViewRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataGridViewRow对象</param>
		/// <returns>t_chartinfo 数据实体</returns>
		public T_CHARTINFO getObject(DataGridViewRow dr)
		{
			T_CHARTINFO unit=new T_CHARTINFO();
			if (null==dr) return null;
			if (DBNull.Value != dr.Cells["ChartInfoId"].Value)	
			    unit.ChartInfoId=dr.Cells["ChartInfoId"].Value.ToString();
			if (DBNull.Value != dr.Cells["CHARTTITLE"].Value)	
			    unit.CHARTTITLE=dr.Cells["CHARTTITLE"].Value.ToString();
			if (DBNull.Value != dr.Cells["CHARTCONTENT"].Value)	
			    unit.CHARTCONTENT=dr.Cells["CHARTCONTENT"].Value.ToString();
			if (DBNull.Value != dr.Cells["PUBLISHER"].Value)	
			    unit.PUBLISHER=dr.Cells["PUBLISHER"].Value.ToString();
			if (DBNull.Value != dr.Cells["PUBLISHDATE"].Value)	
                unit.PUBLISHDATE=Convert.ToDateTime(dr.Cells["PUBLISHDATE"].Value);
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个T_CHARTINFO对象.
		/// </summary>
		/// <param name="chartInfoId">chartInfoId</param>
		/// <returns>T_CHARTINFO对象</returns>
		public  T_CHARTINFO getObject(string Id,out string err)
		{
			DataTable dt=getInfo(Id,out err);
			if(dt!=null && dt.Rows.Count>0) return getObject(dt.Rows[0]);
			return null;
		}
		#endregion
		#endregion
    }
}
