/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：T_DATA_STOCKService.cs
 * 创 建 人：牛振军
 * 创建时间：2008-12-29
 * 标    题：数据操作类
 * 功能描述：T_DATA_STOCK数据操作类
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
    /// 数据层实例化接口类 dbo.T_DATA_STOCKService.cs
    /// </summary>
    public class T_DATA_STOCKService 
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static T_DATA_STOCKService instance=new T_DATA_STOCKService();
        public static T_DATA_STOCKService Instance
        { 
            get
            {
                if(null==instance)
                {
                    T_DATA_STOCKService.instance = new T_DATA_STOCKService();
                }
                return T_DATA_STOCKService.instance;
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
		/// <param name="unit">T_DATA_STOCK对象</param>
		/// <returns>插入的对象更新</returns>	
		public bool saveUnit(T_DATA_STOCK unit,out string err)
        {
			if (unit.DATA_STOCK_ID!=null && unit.DATA_STOCK_ID.Length > 0) //edit
			{
				sql = "UPDATE [T_DATA_STOCK] SET "
					 + "[DATA_STOCK_ID] = '" + unit.DATA_STOCK_ID + "'"
					+ ","
					 + "[CODE] = '" + unit.CODE + "'"
					+ ","
					 + "[DATA_NAME] = '" + unit.DATA_NAME + "'"
					+ ","
					 + "[DATA_REMARK] = '" + unit.DATA_REMARK + "'"
					+ ","
					 + "[DATA_NUMBER] = '" + unit.DATA_NUMBER + "'"
					+ ","
					 + "[DATA_LIEVE_NUMBER] = '" + unit.DATA_LIEVE_NUMBER + "'"
					+ ","
					 + "[DATA_CLASS] = '" + unit.DATA_CLASS + "'"
				+ " where upper(DATA_STOCK_ID) = '" + unit.DATA_STOCK_ID.ToUpper() + "'"; 
			}
			else
			{
                unit.DATA_STOCK_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_DATA_STOCK] ("
									  + "[DATA_STOCK_ID]"
				 + ","
					  + "[CODE]"
				 + ","
					  + "[DATA_NAME]"
				 + ","
					  + "[DATA_REMARK]"
				 + ","
					  + "[DATA_NUMBER]"
				 + ","
					  + "[DATA_LIEVE_NUMBER]"
				 + ","
					  + "[DATA_CLASS]"
				+ ") VALUES( "
									  + " '" + unit.DATA_STOCK_ID + "'"
				 + ","
					  + " '" + unit.CODE + "'"
				 + ","
					  + " '" + unit.DATA_NAME + "'"
				 + ","
					  + " '" + unit.DATA_REMARK + "'"
				 + ","
					  + " '" + unit.DATA_NUMBER + "'"
				 + ","
					  + " '" + unit.DATA_LIEVE_NUMBER + "'"
				 + ","
					  + " '" + unit.DATA_CLASS + "'"
				+ ")";
			}

			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_DATA_STOCK中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_DATA_STOCK对象</param>
		public bool deleteUnit(T_DATA_STOCK unit,out string err)
		{
			return deleteUnit(unit.DATA_STOCK_ID,out err);
		}
		
		/// <summary>
		/// 删除数据表T_DATA_STOCK中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_DATA_STOCK.dATA_STOCK_ID主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_DATA_STOCK where "
				+ " upper(T_DATA_STOCK.DATA_STOCK_ID)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_DATA_STOCK 所有数据信息.
		/// </summary>
		/// <returns>T_DATA_STOCK DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql="select "
								+ "DATA_STOCK_ID"
				 + "," 
				+ "CODE"
				 + "," 
				+ "DATA_NAME"
				 + "," 
				+ "DATA_REMARK"
				 + "," 
				+ "DATA_NUMBER"
				 + "," 
				+ "DATA_LIEVE_NUMBER"
				 + "," 
				+ "DATA_CLASS"
				 + "  from T_DATA_STOCK ";
            DataTable dtb;
            dbAccess.GetDataTable(sql, out dtb, out err);
            return dtb;
		}
		/// <summary>
		/// 根据一个主键ID,得到 T_DATA_STOCK 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>T_DATA_STOCK DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql="select "
								+ "DATA_STOCK_ID"
				 + "," 
				+ "CODE"
				 + "," 
				+ "DATA_NAME"
				 + "," 
				+ "DATA_REMARK"
				 + "," 
				+ "DATA_NUMBER"
				 + "," 
				+ "DATA_LIEVE_NUMBER"
				 + "," 
				+ "DATA_CLASS"
				+ " from T_DATA_STOCK "
				+ " where upper(DATA_STOCK_ID)='" + Id.ToUpper()+"'";
            DataTable dtb;
            dbAccess.GetDataTable(sql, out dtb, out err);
            return dtb;
		}
        /// <summary>
		/// 根据t_data_stock 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>t_data_stock 数据实体</returns>
		public T_DATA_STOCK getObject(DataRow dr)
		{
			T_DATA_STOCK unit=new T_DATA_STOCK();
			if (null==dr) return null;
			if (DBNull.Value != dr["DATA_STOCK_ID"])	
			    unit.DATA_STOCK_ID=dr["DATA_STOCK_ID"].ToString();
			if (DBNull.Value != dr["CODE"])	
			    unit.CODE=dr["CODE"].ToString();
			if (DBNull.Value != dr["DATA_NAME"])	
			    unit.DATA_NAME=dr["DATA_NAME"].ToString();
			if (DBNull.Value != dr["DATA_REMARK"])	
			    unit.DATA_REMARK=dr["DATA_REMARK"].ToString();
			if (DBNull.Value != dr["DATA_NUMBER"])	
			    unit.DATA_NUMBER=Convert.ToInt32(dr["DATA_NUMBER"]);
			if (DBNull.Value != dr["DATA_LIEVE_NUMBER"])	
			    unit.DATA_LIEVE_NUMBER=Convert.ToInt32(dr["DATA_LIEVE_NUMBER"]);
			if (DBNull.Value != dr["DATA_CLASS"])	
			    unit.DATA_CLASS=dr["DATA_CLASS"].ToString();
			
			return unit;
		}
		/// <summary>
		/// 根据t_data_stock 的DataGridView的DataGridViewRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataGridViewRow对象</param>
		/// <returns>t_data_stock 数据实体</returns>
		public T_DATA_STOCK getObject(DataGridViewRow dr)
		{
			T_DATA_STOCK unit=new T_DATA_STOCK();
			if (null==dr) return null;
			if (DBNull.Value != dr.Cells["DATA_STOCK_ID"].Value)	
			    unit.DATA_STOCK_ID=dr.Cells["DATA_STOCK_ID"].Value.ToString();
			if (DBNull.Value != dr.Cells["CODE"].Value)	
			    unit.CODE=dr.Cells["CODE"].Value.ToString();
			if (DBNull.Value != dr.Cells["DATA_NAME"].Value)	
			    unit.DATA_NAME=dr.Cells["DATA_NAME"].Value.ToString();
			if (DBNull.Value != dr.Cells["DATA_REMARK"].Value)	
			    unit.DATA_REMARK=dr.Cells["DATA_REMARK"].Value.ToString();
			if (DBNull.Value != dr.Cells["DATA_NUMBER"].Value)	
			    unit.DATA_NUMBER=Convert.ToInt32(dr.Cells["DATA_NUMBER"].Value);
			if (DBNull.Value != dr.Cells["DATA_LIEVE_NUMBER"].Value)	
			    unit.DATA_LIEVE_NUMBER=Convert.ToInt32(dr.Cells["DATA_LIEVE_NUMBER"].Value);
			if (DBNull.Value != dr.Cells["DATA_CLASS"].Value)	
			    unit.DATA_CLASS=dr.Cells["DATA_CLASS"].Value.ToString();
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个T_DATA_STOCK对象.
		/// </summary>
		/// <param name="dATA_STOCK_ID">dATA_STOCK_ID</param>
		/// <returns>T_DATA_STOCK对象</returns>
		public  T_DATA_STOCK getObject(string Id,out string err)
		{
			DataTable dt=getInfo(Id,out err);
			if(dt!=null && dt.Rows.Count>0) return getObject(dt.Rows[0]);
			return null;
		}
		#endregion
		#endregion
    }
}
