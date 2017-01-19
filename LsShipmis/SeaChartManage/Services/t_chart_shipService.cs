/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：t_chart_shipService.cs
 * 创 建 人：盛文
 * 创建时间：2009-8-27
 * 标    题：数据操作类
 * 功能描述：t_chart_ship数据操作类
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
    /// 数据层实例化接口类 dbo.t_chart_shipService.cs
    /// </summary>
    public class t_chart_shipService 
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static t_chart_shipService instance=new t_chart_shipService();
        public static t_chart_shipService Instance
        { 
            get
            {
                if(null==instance)
                {
                    t_chart_shipService.instance = new t_chart_shipService();
                }
                return t_chart_shipService.instance;
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
		/// <param name="unit">t_chart_ship对象</param>
		/// <returns>插入的对象更新</returns>	
		public bool saveUnit(t_chart_ship unit,out string err)
        {
			if (!string.IsNullOrEmpty(unit.chart_shipid)) //edit
			{
				sql = "UPDATE [t_chart_ship] SET "
					 + "[chart_shipid] = '" + unit.chart_shipid.Replace("'","''") + "'"
					+ ","
					 + "[chartid] = '" + unit.chartid.Replace("'","''") + "'"
					+ ","
					 + "[ship_id] = '" + unit.ship_id.Replace("'","''") + "'"
					+ ","
					 + "[portid] = '" + unit.portid.Replace("'","''") + "'"
				+ " where upper(chart_shipid) = '" + unit.chart_shipid.ToUpper() + "'"; 
			}
			else
			{
                unit.chart_shipid = Guid.NewGuid().ToString();
                sql = "INSERT INTO [t_chart_ship] ("
									  + "[chart_shipid]"
				 + ","
					  + "[chartid]"
				 + ","
					  + "[ship_id]"
				 + ","
					  + "[portid]"
				+ ") VALUES( "
									  + " '" + unit.chart_shipid.Replace("'","''") + "'"
				 + ","
					  + " '" + unit.chartid.Replace("'","''") + "'"
				 + ","
					  + " '" + unit.ship_id.Replace("'","''") + "'"
				 + ","
					  + " '" + unit.portid.Replace("'","''") + "'"
				+ ")";
			}

			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表t_chart_ship中的对象.
		/// </summary>
	   /// <param name="unit">要删除的t_chart_ship对象</param>
		public bool deleteUnit(t_chart_ship unit,out string err)
		{
			return deleteUnit(unit.chart_shipid,out err);
		}
		
		/// <summary>
		/// 删除数据表t_chart_ship中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的t_chart_ship.chart_shipid主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from t_chart_ship where "
				+ " upper(t_chart_ship.chart_shipid)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  t_chart_ship 所有数据信息.
		/// </summary>
		/// <returns>t_chart_ship DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql="select "
								+ "chart_shipid"
				 + "," 
				+ "chartid"
				 + "," 
				+ "ship_id"
				 + "," 
				+ "portid"
				 + "  from t_chart_ship ";
            DataTable dtb;
            dbAccess.GetDataTable(sql, out dtb, out err);
            return dtb;
		}
		/// <summary>
		/// 根据一个主键ID,得到 t_chart_ship 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>t_chart_ship DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
            sql = "SELECT t1.chartnum, t1.chartname, t1.chartenglishname, t1.chartrule, t1.paperchart, t1.changedate, t1.chartformat, t1.sailtellnum,t1.publishdept, t1.remark  "
                + " FROM t_chart t1,t_chart_ship t2 "
                + " where t1.chartid=t2.chartid and t2.ship_id='" + Id + "' order by t1.chartnum ";
            DataTable dtb;
            dbAccess.GetDataTable(sql, out dtb, out err);
            return dtb;
		}

        public DataTable getChartId(string Id, out string err)
        {
            sql ="select chartid from t_chart_ship where upper(ship_id)='" + Id.ToUpper() + "'";
            DataTable dtb;
            dbAccess.GetDataTable(sql, out dtb, out err);
            return dtb;
        }
        /// <summary>
		/// 根据t_chart_ship 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>t_chart_ship 数据实体</returns>
		public t_chart_ship getObject(DataRow dr)
		{
			t_chart_ship unit=new t_chart_ship();
			if (null==dr) return null;
			if (DBNull.Value != dr["chart_shipid"])	
			    unit.chart_shipid=dr["chart_shipid"].ToString();
			if (DBNull.Value != dr["chartid"])	
			    unit.chartid=dr["chartid"].ToString();
			if (DBNull.Value != dr["ship_id"])	
			    unit.ship_id=dr["ship_id"].ToString();
			if (DBNull.Value != dr["portid"])	
			    unit.portid=dr["portid"].ToString();
			
			return unit;
		}
		/// <summary>
		/// 根据t_chart_ship 的DataGridView的DataGridViewRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataGridViewRow对象</param>
		/// <returns>t_chart_ship 数据实体</returns>
		public t_chart_ship getObject(DataGridViewRow dr)
		{
			t_chart_ship unit=new t_chart_ship();
			if (null==dr) return null;
			if (DBNull.Value != dr.Cells["chart_shipid"].Value)	
			    unit.chart_shipid=dr.Cells["chart_shipid"].Value.ToString();
			if (DBNull.Value != dr.Cells["chartid"].Value)	
			    unit.chartid=dr.Cells["chartid"].Value.ToString();
			if (DBNull.Value != dr.Cells["ship_id"].Value)	
			    unit.ship_id=dr.Cells["ship_id"].Value.ToString();
			if (DBNull.Value != dr.Cells["portid"].Value)	
			    unit.portid=dr.Cells["portid"].Value.ToString();
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个t_chart_ship对象.
		/// </summary>
		/// <param name="chart_shipid">chart_shipid</param>
		/// <returns>t_chart_ship对象</returns>
		public  t_chart_ship getObject(string Id,out string err)
		{
			DataTable dt=getInfo(Id,out err);
			if(dt!=null && dt.Rows.Count>0) return getObject(dt.Rows[0]);
			return null;
		}
		#endregion
		#endregion

        internal void delete(string shipId, out string err)
        {
            sql = "delete from t_chart_ship where upper(t_chart_ship.ship_id)='" + shipId.ToUpper() + "'";
            dbAccess.ExecSql(sql, out err);
        }
    }
}
