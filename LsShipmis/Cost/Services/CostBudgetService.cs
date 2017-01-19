/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：CostBudgetService.cs
 * 创 建 人：王鹏程
 * 创建时间：2012/3/21
 * 标    题：数据操作类
 * 功能描述：T_COST_BUDGET数据操作类
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
    /// 数据层实例化接口类 dbo.T_COST_BUDGETService.cs
    /// </summary>
    public partial class CostBudgetService
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static CostBudgetService instance=new CostBudgetService();
        public static CostBudgetService Instance
        { 
            get
            {
                if(null==instance)
                {
                    CostBudgetService.instance = new CostBudgetService();
                }
                return CostBudgetService.instance;
            }
        }
		private CostBudgetService(){}
		#endregion
		
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();        
        string sql = ""; 
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">CostBudget对象</param>
		/// <returns>插入的对象更新</returns>	
		internal bool saveUnit(CostBudget unit,out string err)
        {
			return dbAccess.ExecSql(saveUnit(unit), out err);
		}
        /// <summary>
		/// 返回向数据库中保存一条新记录的sql语句。做事务用。.
		/// </summary>
		/// <param name="unit">CostBudget对象</param>
		/// <returns>插入的对象更新</returns>	
		internal string saveUnit(CostBudget unit)
        {
			if (unit.BUDGET_ID!=null && unit.BUDGET_ID.Length > 0) //edit
			{
				sql = "UPDATE [T_COST_BUDGET] SET "
					+ " [BUDGET_ID] = " + (string.IsNullOrEmpty(unit.BUDGET_ID)?"null":"'" + unit.BUDGET_ID.Replace ("'","''") + "'")
					+ " , [STATE] = " + unit.STATE.ToString()
                    + " , [CREATE_DATE] = " + dbOperation.DbToDate(unit.CREATE_DATE)
					+ " , [APPROVE_NUM] = " + (unit.APPROVE_NUM==null?"''":"'" + unit.APPROVE_NUM.Replace ("'","''") + "'")
					+ " , [REMARK] = " + (unit.REMARK==null?"''":"'" + unit.REMARK.Replace ("'","''") + "'")
					+ " , [S_CNY_AMOUNT] = " + unit.S_CNY_AMOUNT.ToString()
					+ " , [S_USD_AMOUNT] = " + unit.S_USD_AMOUNT.ToString()
					+ " , [S_EUR_AMOUNT] = " + unit.S_EUR_AMOUNT.ToString()
					+ " , [S_JPY_AMOUNT] = " + unit.S_JPY_AMOUNT.ToString()
					+ " , [Y_CNY_AMOUNT] = " + unit.Y_CNY_AMOUNT.ToString()
					+ " , [Y_USD_AMOUNT] = " + unit.Y_USD_AMOUNT.ToString()
					+ " , [Y_EUR_AMOUNT] = " + unit.Y_EUR_AMOUNT.ToString()
					+ " , [Y_JPY_AMOUNT] = " + unit.Y_JPY_AMOUNT.ToString()
					+ " , [X_CNY_AMOUNT] = " + unit.X_CNY_AMOUNT.ToString()
					+ " , [X_USD_AMOUNT] = " + unit.X_USD_AMOUNT.ToString()
					+ " , [X_EUR_AMOUNT] = " + unit.X_EUR_AMOUNT.ToString()
					+ " , [X_JPY_AMOUNT] = " + unit.X_JPY_AMOUNT.ToString()
					+ " where upper(BUDGET_ID) = '" + unit.BUDGET_ID.ToUpper() + "'"; 
			}
			else
			{
				unit.BUDGET_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_COST_BUDGET] ("
					+ "[BUDGET_ID],"
					+ "[STATE],"
					+ "[CREATE_DATE],"
					+ "[APPROVE_NUM],"
					+ "[REMARK],"
					+ "[S_CNY_AMOUNT],"
					+ "[S_USD_AMOUNT],"
					+ "[S_EUR_AMOUNT],"
					+ "[S_JPY_AMOUNT],"
					+ "[Y_CNY_AMOUNT],"
					+ "[Y_USD_AMOUNT],"
					+ "[Y_EUR_AMOUNT],"
					+ "[Y_JPY_AMOUNT],"
					+ "[X_CNY_AMOUNT],"
					+ "[X_USD_AMOUNT],"
					+ "[X_EUR_AMOUNT],"
					+ "[X_JPY_AMOUNT]"
					+ ") VALUES( "
					+ " " + (string.IsNullOrEmpty(unit.BUDGET_ID)?"null":"'" + unit.BUDGET_ID.Replace ("'","''") + "'")
					+ " ,"+ unit.STATE.ToString()
					+ " ," + dbOperation.DbToDate(unit.CREATE_DATE)
					+ " , " + (unit.APPROVE_NUM==null?"''":"'" + unit.APPROVE_NUM.Replace ("'","''") + "'")
					+ " , " + (unit.REMARK==null?"''":"'" + unit.REMARK.Replace ("'","''") + "'")
					+ " ,"+ unit.S_CNY_AMOUNT.ToString()
					+ " ,"+ unit.S_USD_AMOUNT.ToString()
					+ " ,"+ unit.S_EUR_AMOUNT.ToString()
					+ " ,"+ unit.S_JPY_AMOUNT.ToString()
					+ " ,"+ unit.Y_CNY_AMOUNT.ToString()
					+ " ,"+ unit.Y_USD_AMOUNT.ToString()
					+ " ,"+ unit.Y_EUR_AMOUNT.ToString()
					+ " ,"+ unit.Y_JPY_AMOUNT.ToString()
					+ " ,"+ unit.X_CNY_AMOUNT.ToString()
					+ " ,"+ unit.X_USD_AMOUNT.ToString()
					+ " ,"+ unit.X_EUR_AMOUNT.ToString()
					+ " ,"+ unit.X_JPY_AMOUNT.ToString()
					+ ")";
			}

			return sql;
		}
		/// <summary>
		/// 删除数据表T_COST_BUDGET中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_COST_BUDGET对象</param>
		internal bool deleteUnit(CostBudget unit,out string err)
		{
			return deleteUnit(unit.BUDGET_ID,out err);
		}
		
		/// <summary>
		/// 删除数据表T_COST_BUDGET中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_COST_BUDGET.bUDGET_ID主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_COST_BUDGET where "
				+ " upper(T_COST_BUDGET.BUDGET_ID)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_COST_BUDGET 所有数据信息.
		/// </summary>
		/// <returns>T_COST_BUDGET DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql = "select	"
				+ "BUDGET_ID"
				+ ",STATE"
				+ ",CREATE_DATE"
				+ ",APPROVE_NUM"
				+ ",REMARK"
				+ ",S_CNY_AMOUNT"
				+ ",S_USD_AMOUNT"
				+ ",S_EUR_AMOUNT"
				+ ",S_JPY_AMOUNT"
				+ ",Y_CNY_AMOUNT"
				+ ",Y_USD_AMOUNT"
				+ ",Y_EUR_AMOUNT"
				+ ",Y_JPY_AMOUNT"
				+ ",X_CNY_AMOUNT"
				+ ",X_USD_AMOUNT"
				+ ",X_EUR_AMOUNT"
				+ ",X_JPY_AMOUNT"
				+ "  from T_COST_BUDGET ";
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
		/// 根据一个主键ID,得到 T_COST_BUDGET 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>CostBudget DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql = "select "
				+ "BUDGET_ID"
				+ ",STATE"
				+ ",CREATE_DATE"
				+ ",APPROVE_NUM"
				+ ",REMARK"
				+ ",S_CNY_AMOUNT"
				+ ",S_USD_AMOUNT"
				+ ",S_EUR_AMOUNT"
				+ ",S_JPY_AMOUNT"
				+ ",Y_CNY_AMOUNT"
				+ ",Y_USD_AMOUNT"
				+ ",Y_EUR_AMOUNT"
				+ ",Y_JPY_AMOUNT"
				+ ",X_CNY_AMOUNT"
				+ ",X_USD_AMOUNT"
				+ ",X_EUR_AMOUNT"
				+ ",X_JPY_AMOUNT"
				+ " from T_COST_BUDGET "
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
		/// 根据costbudget 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>costbudget 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
		public CostBudget getObject(DataRow dr)
		{
			CostBudget unit=new CostBudget();
			if (null==dr)
			{
				unit.IsWrong = true;
				unit.WhyWrong = "从数据库获取信息时出错,未成功构造CostBudget类对象!";
				return unit;
			}
			if (DBNull.Value != dr["BUDGET_ID"])	
			    unit.BUDGET_ID=dr["BUDGET_ID"].ToString();
			if (DBNull.Value != dr["STATE"])	
			    unit.STATE=Convert.ToInt32(dr["STATE"]);
			if (DBNull.Value != dr["CREATE_DATE"])	
                unit.CREATE_DATE=(DateTime)dr["CREATE_DATE"];
			if (DBNull.Value != dr["APPROVE_NUM"])	
			    unit.APPROVE_NUM=dr["APPROVE_NUM"].ToString();
			if (DBNull.Value != dr["REMARK"])	
			    unit.REMARK=dr["REMARK"].ToString();
			if (DBNull.Value != dr["S_CNY_AMOUNT"])	
			    unit.S_CNY_AMOUNT=Convert.ToDecimal(dr["S_CNY_AMOUNT"]);
			if (DBNull.Value != dr["S_USD_AMOUNT"])	
			    unit.S_USD_AMOUNT=Convert.ToDecimal(dr["S_USD_AMOUNT"]);
			if (DBNull.Value != dr["S_EUR_AMOUNT"])	
			    unit.S_EUR_AMOUNT=Convert.ToDecimal(dr["S_EUR_AMOUNT"]);
			if (DBNull.Value != dr["S_JPY_AMOUNT"])	
			    unit.S_JPY_AMOUNT=Convert.ToDecimal(dr["S_JPY_AMOUNT"]);
			if (DBNull.Value != dr["Y_CNY_AMOUNT"])	
			    unit.Y_CNY_AMOUNT=Convert.ToDecimal(dr["Y_CNY_AMOUNT"]);
			if (DBNull.Value != dr["Y_USD_AMOUNT"])	
			    unit.Y_USD_AMOUNT=Convert.ToDecimal(dr["Y_USD_AMOUNT"]);
			if (DBNull.Value != dr["Y_EUR_AMOUNT"])	
			    unit.Y_EUR_AMOUNT=Convert.ToDecimal(dr["Y_EUR_AMOUNT"]);
			if (DBNull.Value != dr["Y_JPY_AMOUNT"])	
			    unit.Y_JPY_AMOUNT=Convert.ToDecimal(dr["Y_JPY_AMOUNT"]);
			if (DBNull.Value != dr["X_CNY_AMOUNT"])	
			    unit.X_CNY_AMOUNT=Convert.ToDecimal(dr["X_CNY_AMOUNT"]);
			if (DBNull.Value != dr["X_USD_AMOUNT"])	
			    unit.X_USD_AMOUNT=Convert.ToDecimal(dr["X_USD_AMOUNT"]);
			if (DBNull.Value != dr["X_EUR_AMOUNT"])	
			    unit.X_EUR_AMOUNT=Convert.ToDecimal(dr["X_EUR_AMOUNT"]);
			if (DBNull.Value != dr["X_JPY_AMOUNT"])	
			    unit.X_JPY_AMOUNT=Convert.ToDecimal(dr["X_JPY_AMOUNT"]);
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个CostBudget对象.
		/// </summary>
		/// <param name="bUDGET_ID">bUDGET_ID</param>
		/// <returns>CostBudget对象</returns>
		public  CostBudget getObject(string Id,out string err)
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
