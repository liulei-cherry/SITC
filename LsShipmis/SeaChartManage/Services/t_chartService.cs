/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：t_chartService.cs
 * 创 建 人：盛文
 * 创建时间：2009-8-26
 * 标    题：数据操作类
 * 功能描述：t_chart数据操作类
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
using CommonOperation.Functions;
using CommonOperation.Interfaces;

namespace SeaChartManage.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.t_chartService.cs
    /// </summary>
    public class t_chartService 
    {
		#region 构造函数

		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static t_chartService instance=new t_chartService();
        public static t_chartService Instance
        { 
            get
            {
                if(null==instance)
                {
                    t_chartService.instance = new t_chartService();
                }
                return t_chartService.instance;
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
		/// <param name="unit">t_chart对象</param>
		/// <returns>插入的对象更新</returns>	
		public bool saveUnit(t_chart unit,out string err)
        {
			if (!string.IsNullOrEmpty(unit.chartid)) //edit
			{
				sql = "UPDATE [t_chart] SET "
					 + "[chartid] = '" + unit.chartid.Replace("'","''") + "'"
					+ ","
					 + "[chartnum] = '" + unit.chartnum.Replace("'","''") + "'"
					+ ","
					 + "[chartname] = '" + unit.chartname.Replace("'","''") + "'"
					+ ","
					 + "[chartenglishname] = '" + unit.chartenglishname.Replace("'","''") + "'"
					+ ","
					 + "[chartrule] = '" + unit.chartrule.Replace("'","''") + "'"
					+ ","
					 + "[paperchart] = '" + unit.paperchart.Replace("'","''") + "'"
					+ ","
					 + "[changedate] = '" + unit.changedate.Replace("'","''") + "'"
					+ ","
					 + "[chartformat] = '" + unit.chartformat.Replace("'","''") + "'"
					+ ","
					 + "[sailtellnum] = '" + unit.sailtellnum.Replace("'","''") + "'"
					+ ","
                     + "[remark] = '" + unit.remark.Replace("'", "''") + "'"
                    + ","
                     + "[publishdept] = '" + unit.publishdept.Replace("'", "''") + "'"
				+ " where upper(chartid) = '" + unit.chartid.ToUpper() + "'"; 
			}
			else
			{
                unit.chartid = Guid.NewGuid().ToString();
                sql = "INSERT INTO [t_chart] ("
									  + "[chartid]"
				 + ","
					  + "[chartnum]"
				 + ","
					  + "[chartname]"
				 + ","
					  + "[chartenglishname]"
				 + ","
					  + "[chartrule]"
				 + ","
					  + "[paperchart]"
				 + ","
					  + "[changedate]"
				 + ","
					  + "[chartformat]"
				 + ","
					  + "[sailtellnum]"
				 + ","
                      + "[remark]"
                 + ","
                      + "[publishdept]"
				+ ") VALUES( "
									  + " '" + unit.chartid.Replace("'","''") + "'"
				 + ","
					  + " '" + unit.chartnum.Replace("'","''") + "'"
				 + ","
					  + " '" + unit.chartname.Replace("'","''") + "'"
				 + ","
					  + " '" + unit.chartenglishname.Replace("'","''") + "'"
				 + ","
					  + " '" + unit.chartrule.Replace("'","''") + "'"
				 + ","
					  + " '" + unit.paperchart.Replace("'","''") + "'"
				 + ","
					  + " '" + unit.changedate.Replace("'","''") + "'"
				 + ","
					  + " '" + unit.chartformat.Replace("'","''") + "'"
				 + ","
					  + " '" + unit.sailtellnum.Replace("'","''") + "'"
				 + ","
                      + " '" + unit.remark.Replace("'", "''") + "'"
                 + ","
                      + " '" + unit.publishdept.Replace("'", "''") + "'"
				+ ")";
			}

			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表t_chart中的对象.
		/// </summary>
	   /// <param name="unit">要删除的t_chart对象</param>
		public bool deleteUnit(t_chart unit,out string err)
		{
			return deleteUnit(unit.chartid,out err);
		}
		
		/// <summary>
		/// 删除数据表t_chart中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的t_chart.chartid主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from t_chart where "
				+ " upper(t_chart.chartid)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  t_chart 所有数据信息.
		/// </summary>
		/// <returns>t_chart DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql="select "
								+ "chartid"
				 + "," 
				+ "chartnum"
				 + "," 
				+ "chartname"
				 + "," 
				+ "chartenglishname"
				 + "," 
				+ "chartrule"
				 + "," 
				+ "paperchart"
				 + "," 
				+ "changedate"
				 + "," 
				+ "chartformat"
				 + ","
                + "sailtellnum"
                 + ","
                + "publishdept"
				 + ","
                + "remark"
                 + "  from t_chart order by chartnum ";
            DataTable dtb;
            dbAccess.GetDataTable(sql, out dtb, out err);
            return dtb;
		}
		/// <summary>
		/// 根据一个主键ID,得到 t_chart 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>t_chart DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql="select "
								+ "chartid"
				 + "," 
				+ "chartnum"
				 + "," 
				+ "chartname"
				 + "," 
				+ "chartenglishname"
				 + "," 
				+ "chartrule"
				 + "," 
				+ "paperchart"
				 + "," 
				+ "changedate"
				 + "," 
				+ "chartformat"
				 + ","
                + "sailtellnum"
                 + ","
                + "publishdept"
				 + ","
                + "remark"
				+ " from t_chart "
                + " where upper(chartid)='" + Id.ToUpper() + "' order by chartnum ";
            DataTable dtb;
            dbAccess.GetDataTable(sql, out dtb, out err);
            return dtb;
		}
        /// <summary>
		/// 根据t_chart 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>t_chart 数据实体</returns>
		public t_chart getObject(DataRow dr)
		{
			t_chart unit=new t_chart();
			if (null==dr) return null;
			if (DBNull.Value != dr["chartid"])	
			    unit.chartid=dr["chartid"].ToString();
			if (DBNull.Value != dr["chartnum"])	
			    unit.chartnum=dr["chartnum"].ToString();
			if (DBNull.Value != dr["chartname"])	
			    unit.chartname=dr["chartname"].ToString();
			if (DBNull.Value != dr["chartenglishname"])	
			    unit.chartenglishname=dr["chartenglishname"].ToString();
			if (DBNull.Value != dr["chartrule"])	
			    unit.chartrule=dr["chartrule"].ToString();
			if (DBNull.Value != dr["paperchart"])	
			    unit.paperchart=dr["paperchart"].ToString();
			if (DBNull.Value != dr["changedate"])	
			    unit.changedate=dr["changedate"].ToString();
			if (DBNull.Value != dr["chartformat"])	
			    unit.chartformat=dr["chartformat"].ToString();
			if (DBNull.Value != dr["sailtellnum"])
                unit.sailtellnum = dr["sailtellnum"].ToString();
            if (DBNull.Value != dr["publishdept"])
                unit.remark = dr["publishdept"].ToString();
			if (DBNull.Value != dr["remark"])
                unit.remark = dr["remark"].ToString();
			
			return unit;
		}
		/// <summary>
		/// 根据t_chart 的DataGridView的DataGridViewRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataGridViewRow对象</param>
		/// <returns>t_chart 数据实体</returns>
		public t_chart getObject(DataGridViewRow dr)
		{
			t_chart unit=new t_chart();
			if (null==dr) return null;
			if (DBNull.Value != dr.Cells["chartid"].Value)	
			    unit.chartid=dr.Cells["chartid"].Value.ToString();
			if (DBNull.Value != dr.Cells["chartnum"].Value)	
			    unit.chartnum=dr.Cells["chartnum"].Value.ToString();
			if (DBNull.Value != dr.Cells["chartname"].Value)	
			    unit.chartname=dr.Cells["chartname"].Value.ToString();
			if (DBNull.Value != dr.Cells["chartenglishname"].Value)	
			    unit.chartenglishname=dr.Cells["chartenglishname"].Value.ToString();
			if (DBNull.Value != dr.Cells["chartrule"].Value)	
			    unit.chartrule=dr.Cells["chartrule"].Value.ToString();
			if (DBNull.Value != dr.Cells["paperchart"].Value)	
			    unit.paperchart=dr.Cells["paperchart"].Value.ToString();
			if (DBNull.Value != dr.Cells["changedate"].Value)	
			    unit.changedate=dr.Cells["changedate"].Value.ToString();
			if (DBNull.Value != dr.Cells["chartformat"].Value)	
			    unit.chartformat=dr.Cells["chartformat"].Value.ToString();
			if (DBNull.Value != dr.Cells["sailtellnum"].Value)
                unit.sailtellnum = dr.Cells["sailtellnum"].Value.ToString();
            if (DBNull.Value != dr.Cells["publishdept"].Value)
                unit.remark = dr.Cells["publishdept"].Value.ToString();
			if (DBNull.Value != dr.Cells["remark"].Value)
                unit.remark = dr.Cells["remark"].Value.ToString();
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个t_chart对象.
		/// </summary>
		/// <param name="chartid">chartid</param>
		/// <returns>t_chart对象</returns>
		public  t_chart getObject(string Id,out string err)
		{
			DataTable dt=getInfo(Id,out err);
			if(dt!=null && dt.Rows.Count>0) return getObject(dt.Rows[0]);
			return null;
		}
		#endregion
		#endregion
    }
}
