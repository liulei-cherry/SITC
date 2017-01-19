/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：T_DATAService.cs
 * 创 建 人：xxl
 * 创建时间：2008-12-29
 * 标    题：数据操作类
 * 功能描述：T_DATA数据操作类
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
    /// 数据层实例化接口类 dbo.T_DATAService.cs
    /// </summary>
    public class T_DATAService 
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static T_DATAService instance=new T_DATAService();
        public static T_DATAService Instance
        { 
            get
            {
                if(null==instance)
                {
                    T_DATAService.instance = new T_DATAService();
                }
                return T_DATAService.instance;
            }
        }
		#endregion
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";
        //string err = "";
		
        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">T_DATA对象</param>
		/// <returns>插入的对象更新</returns>	
		public bool saveUnit(T_DATA unit,out string err)
        {
			if (unit.DATA_ID!=null && unit.DATA_ID.Length > 0) //edit
			{
				sql = "UPDATE [T_DATA] SET "
					 + "[DATA_ID] = '" + unit.DATA_ID + "'"
					+ ","
                       + "[APPLY_DATE] = " + dbOperation.DbToDate(unit.APPLY_DATE)
					+ ","
                       + "[CATCH_DATE] = " + dbOperation.DbToDate(unit.CATCH_DATE)
					+ ","
                       + "[END_DATE] = " + dbOperation.DbToDate(unit.END_DATE)
					+ ","
					 + "[DATA_STOCK_ID] = '" + unit.DATA_STOCK_ID + "'"
					+ ","
					 + "[DATA_REMARK] = '" + unit.DATA_REMARK + "'"
					+ ","
					 + "[APPLY_PERSORN] = '" + unit.APPLY_PERSORN + "'"
					+ ","
					 + "[RETURN_FLAG] = '" + unit.RETURN_FLAG + "'"
				+ " where upper(DATA_ID) = '" + unit.DATA_ID.ToUpper() + "'"; 
			}
			else
			{
                unit.DATA_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_DATA] ("
									  + "[DATA_ID]"
				 + ","
					  + "[APPLY_DATE]"
				 + ","
					  + "[CATCH_DATE]"
				 + ","
					  + "[END_DATE]"
				 + ","
					  + "[DATA_STOCK_ID]"
				 + ","
					  + "[DATA_REMARK]"
				 + ","
					  + "[APPLY_PERSORN]"
				 + ","
					  + "[RETURN_FLAG]"
				+ ") VALUES( "
									  + " '" + unit.DATA_ID + "'"
				 + ","
                      + dbOperation.DbToDate(unit.APPLY_DATE)
				 + ","
                      + dbOperation.DbToDate(unit.CATCH_DATE)
				 + ","
                      + dbOperation.DbToDate(unit.END_DATE)
				 + ","
					  + " '" + unit.DATA_STOCK_ID + "'"
				 + ","
					  + " '" + unit.DATA_REMARK + "'"
				 + ","
					  + " '" + unit.APPLY_PERSORN + "'"
				 + ","
					  + " '" + unit.RETURN_FLAG + "'"
				+ ")";
			}

			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_DATA中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_DATA对象</param>
		public bool deleteUnit(T_DATA unit,out string err)
		{
			return deleteUnit(unit.DATA_ID,out err);
		}
		
		/// <summary>
		/// 删除数据表T_DATA中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_DATA.dATA_ID主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_DATA where "
				+ " upper(T_DATA.DATA_ID)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_DATA 所有数据信息.
		/// </summary>
		/// <returns>T_DATA DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql="select "
								+ "DATA_ID"
				 + "," 
				+ "APPLY_DATE"
				 + "," 
				+ "CATCH_DATE"
				 + "," 
				+ "END_DATE"
				 + "," 
				+ "DATA_STOCK_ID"
				 + "," 
				+ "DATA_REMARK"
				 + "," 
				+ "APPLY_PERSORN"
				 + "," 
				+ "RETURN_FLAG"
				 + "  from T_DATA ";
            DataTable dtb;
            dbAccess.GetDataTable(sql, out dtb, out err);
            return dtb;
		}

        public DataTable getInfoEx(out string err)
        {
            sql = "select "
                 + "b.DATA_NAME"
                 + ","
                                + "a.DATA_ID"
                 + ","
                + "a.APPLY_DATE"
                 + ","
                + "a.CATCH_DATE"
                 + ","
                + "a.END_DATE"
                 + ","
                + "a.DATA_STOCK_ID"
                 + ","
                + "a.DATA_REMARK"
                 + ","
                + "a.APPLY_PERSORN"
                 + ","
                + "a.RETURN_FLAG"

                 + "  from T_DATA a,T_DATA_STOCK  b"
                 
            +"  where a.DATA_STOCK_ID =b.DATA_STOCK_ID ";
            DataTable dtb;
            dbAccess.GetDataTable(sql, out dtb, out err);
            return dtb;
        }

		/// <summary>
		/// 根据一个主键ID,得到 T_DATA 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>T_DATA DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql="select "
								+ "DATA_ID"
				 + "," 
				+ "APPLY_DATE"
				 + "," 
				+ "CATCH_DATE"
				 + "," 
				+ "END_DATE"
				 + "," 
				+ "DATA_STOCK_ID"
				 + "," 
				+ "DATA_REMARK"
				 + "," 
				+ "APPLY_PERSORN"
				 + "," 
				+ "RETURN_FLAG"
				+ " from T_DATA "
				+ " where upper(DATA_ID)='" + Id.ToUpper()+"'";
            DataTable dtb;
            dbAccess.GetDataTable(sql, out dtb, out err);
            return dtb;
		}
        /// <summary>
		/// 根据t_data 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>t_data 数据实体</returns>
		public T_DATA getObject(DataRow dr)
		{
			T_DATA unit=new T_DATA();
			if (null==dr) return null;
			if (DBNull.Value != dr["DATA_ID"])	
			    unit.DATA_ID=dr["DATA_ID"].ToString();
			if (DBNull.Value != dr["APPLY_DATE"])	
                unit.APPLY_DATE=(DateTime)dr["APPLY_DATE"];
			if (DBNull.Value != dr["CATCH_DATE"])	
                unit.CATCH_DATE=(DateTime)dr["CATCH_DATE"];
			if (DBNull.Value != dr["END_DATE"])	
                unit.END_DATE=(DateTime)dr["END_DATE"];
			if (DBNull.Value != dr["DATA_STOCK_ID"])	
			    unit.DATA_STOCK_ID=dr["DATA_STOCK_ID"].ToString();
			if (DBNull.Value != dr["DATA_REMARK"])	
			    unit.DATA_REMARK=dr["DATA_REMARK"].ToString();
			if (DBNull.Value != dr["APPLY_PERSORN"])	
			    unit.APPLY_PERSORN=dr["APPLY_PERSORN"].ToString();
			if (DBNull.Value != dr["RETURN_FLAG"])	
			    unit.RETURN_FLAG=Convert.ToInt32(dr["RETURN_FLAG"]);
			
			return unit;
		}
		/// <summary>
		/// 根据t_data 的DataGridView的DataGridViewRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataGridViewRow对象</param>
		/// <returns>t_data 数据实体</returns>
		public T_DATA getObject(DataGridViewRow dr)
		{
			T_DATA unit=new T_DATA();
			if (null==dr) return null;
			if (DBNull.Value != dr.Cells["DATA_ID"].Value)	
			    unit.DATA_ID=dr.Cells["DATA_ID"].Value.ToString();
			if (DBNull.Value != dr.Cells["APPLY_DATE"].Value)	
                unit.APPLY_DATE=Convert.ToDateTime(dr.Cells["APPLY_DATE"].Value);
			if (DBNull.Value != dr.Cells["CATCH_DATE"].Value)	
                unit.CATCH_DATE=Convert.ToDateTime(dr.Cells["CATCH_DATE"].Value);
			if (DBNull.Value != dr.Cells["END_DATE"].Value)	
                unit.END_DATE=Convert.ToDateTime(dr.Cells["END_DATE"].Value);
			if (DBNull.Value != dr.Cells["DATA_STOCK_ID"].Value)	
			    unit.DATA_STOCK_ID=dr.Cells["DATA_STOCK_ID"].Value.ToString();
			if (DBNull.Value != dr.Cells["DATA_REMARK"].Value)	
			    unit.DATA_REMARK=dr.Cells["DATA_REMARK"].Value.ToString();
			if (DBNull.Value != dr.Cells["APPLY_PERSORN"].Value)	
			    unit.APPLY_PERSORN=dr.Cells["APPLY_PERSORN"].Value.ToString();
			if (DBNull.Value != dr.Cells["RETURN_FLAG"].Value)	
			    unit.RETURN_FLAG=Convert.ToInt32(dr.Cells["RETURN_FLAG"].Value);
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个T_DATA对象.
		/// </summary>
		/// <param name="dATA_ID">dATA_ID</param>
		/// <returns>T_DATA对象</returns>
		public  T_DATA getObject(string Id,out string err)
		{
			DataTable dt=getInfo(Id,out err);
			if(dt!=null && dt.Rows.Count>0) return getObject(dt.Rows[0]);
			return null;
		}
		#endregion
		#endregion
    }
}
