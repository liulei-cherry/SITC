/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：T_CHARTINDEXService.cs
 * 创 建 人：牛振军
 * 创建时间：2008-12-29
 * 标    题：数据操作类
 * 功能描述：T_CHARTINDEX数据操作类
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
    /// 数据层实例化接口类 dbo.T_CHARTINDEXService.cs
    /// </summary>
    public class T_CHARTINDEXService 
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static T_CHARTINDEXService instance=new T_CHARTINDEXService();
        public static T_CHARTINDEXService Instance
        { 
            get
            {
                if(null==instance)
                {
                    T_CHARTINDEXService.instance = new T_CHARTINDEXService();
                }
                return T_CHARTINDEXService.instance;
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
		/// <param name="unit">T_CHARTINDEX对象</param>
		/// <returns>插入的对象更新</returns>	
		public bool saveUnit(T_CHARTINDEX unit,out string err)
        {
			if (unit.CHARTID!=null && unit.CHARTID.Length > 0) //edit
			{
				sql = "UPDATE [T_CHARTINDEX] SET "
					 + "[CHARTID] = '" + unit.CHARTID + "'"
					+ ","
					 + "[CHARTNO] = '" + unit.CHARTNO + "'"
					+ ","
					 + "[TITLECN] = '" + unit.TITLECN + "'"
					+ ","
					 + "[TITLEEN] = '" + unit.TITLEEN + "'"
					+ ","
					 + "[SIZE] = '" + unit.SIZE + "'"
					+ ","
					 + "[PAGE] = '" + unit.PAGE + "'"
				+ " where upper(CHARTID) = '" + unit.CHARTID.ToUpper() + "'"; 
			}
			else
			{
				unit.CHARTID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_CHARTINDEX] ("
									  + "[CHARTID]"
				 + ","
					  + "[CHARTNO]"
				 + ","
					  + "[TITLECN]"
				 + ","
					  + "[TITLEEN]"
				 + ","
					  + "[SIZE]"
				 + ","
					  + "[PAGE]"
				+ ") VALUES( "
									  + " '" + unit.CHARTID + "'"
				 + ","
					  + " '" + unit.CHARTNO + "'"
				 + ","
					  + " '" + unit.TITLECN + "'"
				 + ","
					  + " '" + unit.TITLEEN + "'"
				 + ","
					  + " '" + unit.SIZE + "'"
				 + ","
					  + " '" + unit.PAGE + "'"
				+ ")";
			}

			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_CHARTINDEX中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_CHARTINDEX对象</param>
		public bool deleteUnit(T_CHARTINDEX unit,out string err)
		{
			return deleteUnit(unit.CHARTID,out err);
		}
		
		/// <summary>
		/// 删除数据表T_CHARTINDEX中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_CHARTINDEX.cHARTID主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_CHARTINDEX where "
				+ " upper(T_CHARTINDEX.CHARTID)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_CHARTINDEX 所有数据信息.
		/// </summary>
		/// <returns>T_CHARTINDEX DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql="select "
								+ "CHARTID"
				 + "," 
				+ "CHARTNO"
				 + "," 
				+ "TITLECN"
				 + "," 
				+ "TITLEEN"
				 + "," 
				+ "SIZE"
				 + "," 
				+ "PAGE"
				 + "  from T_CHARTINDEX ";
            DataTable dtb;
            dbAccess.GetDataTable(sql, out dtb, out err);
            return dtb;
		}
		/// <summary>
		/// 根据一个主键ID,得到 T_CHARTINDEX 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>T_CHARTINDEX DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql="select "
								+ "CHARTID"
				 + "," 
				+ "CHARTNO"
				 + "," 
				+ "TITLECN"
				 + "," 
				+ "TITLEEN"
				 + "," 
				+ "SIZE"
				 + "," 
				+ "PAGE"
				+ " from T_CHARTINDEX "
				+ " where upper(CHARTID)='" + Id.ToUpper()+"'";
            DataTable dtb;
            dbAccess.GetDataTable(sql, out dtb, out err);
            return dtb;
		}
        /// <summary>
		/// 根据t_chartindex 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>t_chartindex 数据实体</returns>
		public T_CHARTINDEX getObject(DataRow dr)
		{
			T_CHARTINDEX unit=new T_CHARTINDEX();
			if (null==dr) return null;
			if (DBNull.Value != dr["CHARTID"])	
			    unit.CHARTID=dr["CHARTID"].ToString();
			if (DBNull.Value != dr["CHARTNO"])	
			    unit.CHARTNO=dr["CHARTNO"].ToString();
			if (DBNull.Value != dr["TITLECN"])	
			    unit.TITLECN=dr["TITLECN"].ToString();
			if (DBNull.Value != dr["TITLEEN"])	
			    unit.TITLEEN=dr["TITLEEN"].ToString();
			if (DBNull.Value != dr["SIZE"])	
			    unit.SIZE=dr["SIZE"].ToString();
			if (DBNull.Value != dr["PAGE"])	
			    unit.PAGE=dr["PAGE"].ToString();
			
			return unit;
		}
		/// <summary>
		/// 根据t_chartindex 的DataGridView的DataGridViewRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataGridViewRow对象</param>
		/// <returns>t_chartindex 数据实体</returns>
		public T_CHARTINDEX getObject(DataGridViewRow dr)
		{
			T_CHARTINDEX unit=new T_CHARTINDEX();
			if (null==dr) return null;
			if (DBNull.Value != dr.Cells["CHARTID"].Value)	
			    unit.CHARTID=dr.Cells["CHARTID"].Value.ToString();
			if (DBNull.Value != dr.Cells["CHARTNO"].Value)	
			    unit.CHARTNO=dr.Cells["CHARTNO"].Value.ToString();
			if (DBNull.Value != dr.Cells["TITLECN"].Value)	
			    unit.TITLECN=dr.Cells["TITLECN"].Value.ToString();
			if (DBNull.Value != dr.Cells["TITLEEN"].Value)	
			    unit.TITLEEN=dr.Cells["TITLEEN"].Value.ToString();
			if (DBNull.Value != dr.Cells["SIZE"].Value)	
			    unit.SIZE=dr.Cells["SIZE"].Value.ToString();
			if (DBNull.Value != dr.Cells["PAGE"].Value)	
			    unit.PAGE=dr.Cells["PAGE"].Value.ToString();
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个T_CHARTINDEX对象.
		/// </summary>
		/// <param name="cHARTID">cHARTID</param>
		/// <returns>T_CHARTINDEX对象</returns>
		public  T_CHARTINDEX getObject(string Id,out string err)
		{
			DataTable dt=getInfo(Id,out err);
			if(dt!=null && dt.Rows.Count>0) return getObject(dt.Rows[0]);
			return null;
		}
		#endregion
		#endregion
    }
}
