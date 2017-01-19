/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：ANNUAL_BUDGETService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-7-4
 * 标    题：数据操作类
 * 功能描述：T_COST_ANNUAL_BUDGET数据操作类
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
using Cost.DataObject;

namespace  Cost.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_COST_ANNUAL_BUDGETService.cs
    /// </summary>
    public partial class ANNUAL_BUDGETService
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static ANNUAL_BUDGETService instance=new ANNUAL_BUDGETService();
        public static ANNUAL_BUDGETService Instance
        { 
            get
            {
                if(null==instance)
                {
                    ANNUAL_BUDGETService.instance = new ANNUAL_BUDGETService();
                }
                return ANNUAL_BUDGETService.instance;
            }
        }
		private ANNUAL_BUDGETService(){}
		#endregion
		
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();        
        string sql = ""; 
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">ANNUAL_BUDGET对象</param>
		/// <returns>插入的对象更新</returns>	
		internal bool saveUnit(ANNUAL_BUDGET unit,out string err)
        {
			if (unit.BUDGET_ID!=null && unit.BUDGET_ID.Length > 0) //edit
			{
				sql = "UPDATE [T_COST_ANNUAL_BUDGET] SET "
					+ " [BUDGET_ID] = " + (string.IsNullOrEmpty(unit.BUDGET_ID)?"null":"'" + unit.BUDGET_ID.Replace ("'","''") + "'")
					+ " , [NODE_ID] = " + (string.IsNullOrEmpty(unit.NODE_ID)?"null":"'" + unit.NODE_ID.Replace ("'","''") + "'")
                    + " , [YEAR_DATE] = " + dbOperation.DbToDate(unit.YEAR_DATE)
					+ " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ " , [AMOUNT] = " + unit.AMOUNT.ToString()
					+ " where upper(BUDGET_ID) = '" + unit.BUDGET_ID.ToUpper() + "'"; 
			}
			else
			{
				unit.BUDGET_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_COST_ANNUAL_BUDGET] ("
					+ "[BUDGET_ID],"
					+ "[NODE_ID],"
					+ "[YEAR_DATE],"
					+ "[SHIP_ID],"
					+ "[AMOUNT]"
					+ ") VALUES( "
					+ " " + (string.IsNullOrEmpty(unit.BUDGET_ID)?"null":"'" + unit.BUDGET_ID.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.NODE_ID)?"null":"'" + unit.NODE_ID.Replace ("'","''") + "'")
					+ " ," + dbOperation.DbToDate(unit.YEAR_DATE)
					+ " , " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ " ,"+ unit.AMOUNT.ToString()
					+ ")";
			}

			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_COST_ANNUAL_BUDGET中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_COST_ANNUAL_BUDGET对象</param>
		internal bool deleteUnit(ANNUAL_BUDGET unit,out string err)
		{
			return deleteUnit(unit.BUDGET_ID,out err);
		}
		
		/// <summary>
		/// 删除数据表T_COST_ANNUAL_BUDGET中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_COST_ANNUAL_BUDGET.bUDGET_ID主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_COST_ANNUAL_BUDGET where "
				+ " upper(T_COST_ANNUAL_BUDGET.BUDGET_ID)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_COST_ANNUAL_BUDGET 所有数据信息.
		/// </summary>
		/// <returns>T_COST_ANNUAL_BUDGET DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql = "select	"
				+ "BUDGET_ID"
				+ ",NODE_ID"
				+ ",YEAR_DATE"
				+ ",SHIP_ID"
				+ ",AMOUNT"
				+ "  from T_COST_ANNUAL_BUDGET ";
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
		/// 根据一个主键ID,得到 T_COST_ANNUAL_BUDGET 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>ANNUAL_BUDGET DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql = "select "
				+ "BUDGET_ID"
				+ ",NODE_ID"
				+ ",YEAR_DATE"
				+ ",SHIP_ID"
				+ ",AMOUNT"
				+ " from T_COST_ANNUAL_BUDGET "
				+ " where upper(BUDGET_ID)='" + Id.ToUpper()+"'";
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
		/// 根据annual_budget 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>annual_budget 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
		public ANNUAL_BUDGET getObject(DataRow dr)
		{
			ANNUAL_BUDGET unit=new ANNUAL_BUDGET();
			if (null==dr)
			{
				unit.IsWrong = true;
				unit.WhyWrong = "从数据库获取信息时出错,未成功构造ANNUAL_BUDGET类对象!";
				return unit;
			}
			if (DBNull.Value != dr["BUDGET_ID"])	
			    unit.BUDGET_ID=dr["BUDGET_ID"].ToString();
			if (DBNull.Value != dr["NODE_ID"])	
			    unit.NODE_ID=dr["NODE_ID"].ToString();
			if (DBNull.Value != dr["YEAR_DATE"])	
                unit.YEAR_DATE=(DateTime)dr["YEAR_DATE"];
			if (DBNull.Value != dr["SHIP_ID"])	
			    unit.SHIP_ID=dr["SHIP_ID"].ToString();
			if (DBNull.Value != dr["AMOUNT"])	
			    unit.AMOUNT=Convert.ToDecimal(dr["AMOUNT"]);
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个ANNUAL_BUDGET对象.
		/// </summary>
		/// <param name="bUDGET_ID">bUDGET_ID</param>
		/// <returns>ANNUAL_BUDGET对象</returns>
		public  ANNUAL_BUDGET getObject(string Id,out string err)
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
