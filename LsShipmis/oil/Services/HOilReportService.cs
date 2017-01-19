/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：HOilReportService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-8-19
 * 标    题：数据操作类
 * 功能描述：T_HOIL_REPORT数据操作类
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
using Oil.DataObject;

namespace  Oil.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_HOIL_REPORTService.cs
    /// </summary>
    public partial class HOilReportService
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static HOilReportService instance=new HOilReportService();
        public static HOilReportService Instance
        { 
            get
            {
                if(null==instance)
                {
                    HOilReportService.instance = new HOilReportService();
                }
                return HOilReportService.instance;
            }
        }
		private HOilReportService(){}
		#endregion
		
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();        
        string sql = ""; 
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">HOilReport对象</param>
		/// <returns>插入的对象更新</returns>	
		internal bool saveUnit(HOilReport unit,out string err)
        {
			if (unit.REPORT_ID!=null && unit.REPORT_ID.Length > 0) //edit
			{
				sql = "UPDATE [T_HOIL_REPORT] SET "
					+ " [REPORT_ID] = " + (string.IsNullOrEmpty(unit.REPORT_ID)?"null":"'" + unit.REPORT_ID.Replace ("'","''") + "'")
					+ " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
                    + " , [START_DATE] = " + dbOperation.DbToDate(unit.START_DATE)
                    + " , [END_DATE] = " + dbOperation.DbToDate(unit.END_DATE)
                    + " , [REPORT_DATE] = " + dbOperation.DbToDate(unit.REPORT_DATE)
					+ " , [REMARK] = N" + (unit.REMARK==null?"''":"'" + unit.REMARK.Replace ("'","''") + "'")
					+ " , [W_SPECIFICATION] = " + (unit.W_SPECIFICATION==null?"''":"'" + unit.W_SPECIFICATION.Replace ("'","''") + "'")
					+ " , [WLEFT_AMOUNT] = " + unit.WLEFT_AMOUNT.ToString()
					+ " , [W_SULPHUR] = " + unit.W_SULPHUR.ToString()
					+ " , [W_DENSITY] = " + unit.W_DENSITY.ToString()
					+ " , [L_SPECIFICATION] = " + (unit.L_SPECIFICATION==null?"''":"'" + unit.L_SPECIFICATION.Replace ("'","''") + "'")
					+ " , [LLEFT_AMOUNT] = " + unit.LLEFT_AMOUNT.ToString()
					+ " , [L_SULPHUR] = " + unit.L_SULPHUR.ToString()
					+ " , [L_DENSITY] = " + unit.L_DENSITY.ToString()
					+ " , [SAIL_DAY] = " + unit.SAIL_DAY.ToString()
					+ " , [SAIL_HOUR] = " + unit.SAIL_HOUR.ToString()
					+ " where upper(REPORT_ID) = '" + unit.REPORT_ID.ToUpper() + "'"; 
			}
			else
			{
				unit.REPORT_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_HOIL_REPORT] ("
					+ "[REPORT_ID],"
					+ "[SHIP_ID],"
					+ "[START_DATE],"
					+ "[END_DATE],"
					+ "[REPORT_DATE],"
					+ "[REMARK],"
					+ "[W_SPECIFICATION],"
					+ "[WLEFT_AMOUNT],"
					+ "[W_SULPHUR],"
					+ "[W_DENSITY],"
					+ "[L_SPECIFICATION],"
					+ "[LLEFT_AMOUNT],"
					+ "[L_SULPHUR],"
					+ "[L_DENSITY],"
					+ "[SAIL_DAY],"
					+ "[SAIL_HOUR]"
					+ ") VALUES( "
					+ " " + (string.IsNullOrEmpty(unit.REPORT_ID)?"null":"'" + unit.REPORT_ID.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ " ," + dbOperation.DbToDate(unit.START_DATE)
					+ " ," + dbOperation.DbToDate(unit.END_DATE)
					+ " ," + dbOperation.DbToDate(unit.REPORT_DATE)
					+ " , N" + (unit.REMARK==null?"''":"'" + unit.REMARK.Replace ("'","''") + "'")
					+ " , " + (unit.W_SPECIFICATION==null?"''":"'" + unit.W_SPECIFICATION.Replace ("'","''") + "'")
					+ " ,"+ unit.WLEFT_AMOUNT.ToString()
					+ " ,"+ unit.W_SULPHUR.ToString()
					+ " ,"+ unit.W_DENSITY.ToString()
					+ " , " + (unit.L_SPECIFICATION==null?"''":"'" + unit.L_SPECIFICATION.Replace ("'","''") + "'")
					+ " ,"+ unit.LLEFT_AMOUNT.ToString()
					+ " ,"+ unit.L_SULPHUR.ToString()
					+ " ,"+ unit.L_DENSITY.ToString()
					+ " ,"+ unit.SAIL_DAY.ToString()
					+ " ,"+ unit.SAIL_HOUR.ToString()
					+ ")";
			}

			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_HOIL_REPORT中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_HOIL_REPORT对象</param>
		internal bool deleteUnit(HOilReport unit,out string err)
		{
			return deleteUnit(unit.REPORT_ID,out err);
		}
		
		/// <summary>
		/// 删除数据表T_HOIL_REPORT中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_HOIL_REPORT.rEPORT_ID主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_HOIL_REPORT where "
				+ " upper(T_HOIL_REPORT.REPORT_ID)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_HOIL_REPORT 所有数据信息.
		/// </summary>
		/// <returns>T_HOIL_REPORT DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql = "select	"
				+ "REPORT_ID"
				+ ",SHIP_ID"
				+ ",START_DATE"
				+ ",END_DATE"
				+ ",REPORT_DATE"
				+ ",REMARK"
				+ ",W_SPECIFICATION"
				+ ",WLEFT_AMOUNT"
				+ ",W_SULPHUR"
				+ ",W_DENSITY"
				+ ",L_SPECIFICATION"
				+ ",LLEFT_AMOUNT"
				+ ",L_SULPHUR"
				+ ",L_DENSITY"
				+ ",SAIL_DAY"
				+ ",SAIL_HOUR"
				+ "  from T_HOIL_REPORT ";
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
		/// 根据一个主键ID,得到 T_HOIL_REPORT 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>HOilReport DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql = "select "
				+ "REPORT_ID"
				+ ",SHIP_ID"
				+ ",START_DATE"
				+ ",END_DATE"
				+ ",REPORT_DATE"
				+ ",REMARK"
				+ ",W_SPECIFICATION"
				+ ",WLEFT_AMOUNT"
				+ ",W_SULPHUR"
				+ ",W_DENSITY"
				+ ",L_SPECIFICATION"
				+ ",LLEFT_AMOUNT"
				+ ",L_SULPHUR"
				+ ",L_DENSITY"
				+ ",SAIL_DAY"
				+ ",SAIL_HOUR"
				+ " from T_HOIL_REPORT "
				+ " where upper(REPORT_ID)='" + Id.ToUpper()+"'";
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
		/// 根据hoilreport 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>hoilreport 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
		public HOilReport getObject(DataRow dr)
		{
			HOilReport unit=new HOilReport();
			if (null==dr)
			{
				unit.IsWrong = true;
				unit.WhyWrong = "从数据库获取信息时出错,未成功构造HOilReport类对象!";
				return unit;
			}
			if (DBNull.Value != dr["REPORT_ID"])	
			    unit.REPORT_ID=dr["REPORT_ID"].ToString();
			if (DBNull.Value != dr["SHIP_ID"])	
			    unit.SHIP_ID=dr["SHIP_ID"].ToString();
			if (DBNull.Value != dr["START_DATE"])	
                unit.START_DATE=(DateTime)dr["START_DATE"];
			if (DBNull.Value != dr["END_DATE"])	
                unit.END_DATE=(DateTime)dr["END_DATE"];
			if (DBNull.Value != dr["REPORT_DATE"])	
                unit.REPORT_DATE=(DateTime)dr["REPORT_DATE"];
			if (DBNull.Value != dr["REMARK"])	
			    unit.REMARK=dr["REMARK"].ToString();
			if (DBNull.Value != dr["W_SPECIFICATION"])	
			    unit.W_SPECIFICATION=dr["W_SPECIFICATION"].ToString();
			if (DBNull.Value != dr["WLEFT_AMOUNT"])	
			    unit.WLEFT_AMOUNT=Convert.ToDecimal(dr["WLEFT_AMOUNT"]);
			if (DBNull.Value != dr["W_SULPHUR"])	
			    unit.W_SULPHUR=Convert.ToDecimal(dr["W_SULPHUR"]);
			if (DBNull.Value != dr["W_DENSITY"])	
			    unit.W_DENSITY=Convert.ToDecimal(dr["W_DENSITY"]);
			if (DBNull.Value != dr["L_SPECIFICATION"])	
			    unit.L_SPECIFICATION=dr["L_SPECIFICATION"].ToString();
			if (DBNull.Value != dr["LLEFT_AMOUNT"])	
			    unit.LLEFT_AMOUNT=Convert.ToDecimal(dr["LLEFT_AMOUNT"]);
			if (DBNull.Value != dr["L_SULPHUR"])	
			    unit.L_SULPHUR=Convert.ToDecimal(dr["L_SULPHUR"]);
			if (DBNull.Value != dr["L_DENSITY"])	
			    unit.L_DENSITY=Convert.ToDecimal(dr["L_DENSITY"]);
			if (DBNull.Value != dr["SAIL_DAY"])	
			    unit.SAIL_DAY=Convert.ToInt32(dr["SAIL_DAY"]);
			if (DBNull.Value != dr["SAIL_HOUR"])	
			    unit.SAIL_HOUR=Convert.ToInt32(dr["SAIL_HOUR"]);
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个HOilReport对象.
		/// </summary>
		/// <param name="rEPORT_ID">rEPORT_ID</param>
		/// <returns>HOilReport对象</returns>
		public  HOilReport getObject(string Id,out string err)
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
