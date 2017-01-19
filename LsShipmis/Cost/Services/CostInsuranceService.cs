/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：CostInsuranceService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-8-24
 * 标    题：数据操作类
 * 功能描述：T_COST_INSURANCE数据操作类
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
    /// 数据层实例化接口类 dbo.T_COST_INSURANCEService.cs
    /// </summary>
    public partial class CostInsuranceService
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static CostInsuranceService instance=new CostInsuranceService();
        public static CostInsuranceService Instance
        { 
            get
            {
                if(null==instance)
                {
                    CostInsuranceService.instance = new CostInsuranceService();
                }
                return CostInsuranceService.instance;
            }
        }
		private CostInsuranceService(){}
		#endregion
		
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();        
        string sql = ""; 
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">CostInsurance对象</param>
		/// <returns>插入的对象更新</returns>	
		internal bool saveUnit(CostInsurance unit,out string err)
        {
			if (unit.WASTE_ID!=null && unit.WASTE_ID.Length > 0) //edit
			{
				sql = "UPDATE [T_COST_INSURANCE] SET "
					+ " [WASTE_ID] = " + (string.IsNullOrEmpty(unit.WASTE_ID)?"null":"'" + unit.WASTE_ID.Replace ("'","''") + "'")
					+ " , [DESCRIPTE] = " + (unit.DESCRIPTE==null?"''":"'" + unit.DESCRIPTE.Replace ("'","''") + "'")
                    + " , [POLICY_DATE] = " + dbOperation.DbToDate(unit.POLICY_DATE)
					+ " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ " , [CURRENCY_ID] = " + (string.IsNullOrEmpty(unit.CURRENCY_ID)?"null":"'" + unit.CURRENCY_ID.Replace ("'","''") + "'")
					+ " , [PUBLIC_AMOUNT] = " + unit.PUBLIC_AMOUNT.ToString()
                    + " , [PAY_DATE] = " + dbOperation.DbToDate(unit.PAY_DATE)
					+ " , [PAY_AMOUNT] = " + unit.PAY_AMOUNT.ToString()
					+ " , [STATIC] = " + unit.STATIC.ToString()
					+ " , [INSURANCE_COMPANY] = " + (unit.INSURANCE_COMPANY==null?"''":"'" + unit.INSURANCE_COMPANY.Replace ("'","''") + "'")
					+ " , [REMARK] = " + (unit.REMARK==null?"''":"'" + unit.REMARK.Replace ("'","''") + "'")
					+ " where upper(WASTE_ID) = '" + unit.WASTE_ID.ToUpper() + "'"; 
			}
			else
			{
				unit.WASTE_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_COST_INSURANCE] ("
					+ "[WASTE_ID],"
					+ "[DESCRIPTE],"
					+ "[POLICY_DATE],"
					+ "[SHIP_ID],"
					+ "[CURRENCY_ID],"
					+ "[PUBLIC_AMOUNT],"
					+ "[PAY_DATE],"
					+ "[PAY_AMOUNT],"
					+ "[STATIC],"
					+ "[INSURANCE_COMPANY],"
					+ "[REMARK]"
					+ ") VALUES( "
					+ " " + (string.IsNullOrEmpty(unit.WASTE_ID)?"null":"'" + unit.WASTE_ID.Replace ("'","''") + "'")
					+ " , " + (unit.DESCRIPTE==null?"''":"'" + unit.DESCRIPTE.Replace ("'","''") + "'")
					+ " ," + dbOperation.DbToDate(unit.POLICY_DATE)
					+ " , " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.CURRENCY_ID)?"null":"'" + unit.CURRENCY_ID.Replace ("'","''") + "'")
					+ " ,"+ unit.PUBLIC_AMOUNT.ToString()
					+ " ," + dbOperation.DbToDate(unit.PAY_DATE)
					+ " ,"+ unit.PAY_AMOUNT.ToString()
					+ " ,"+ unit.STATIC.ToString()
					+ " , " + (unit.INSURANCE_COMPANY==null?"''":"'" + unit.INSURANCE_COMPANY.Replace ("'","''") + "'")
					+ " , " + (unit.REMARK==null?"''":"'" + unit.REMARK.Replace ("'","''") + "'")
					+ ")";
			}

			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_COST_INSURANCE中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_COST_INSURANCE对象</param>
		internal bool deleteUnit(CostInsurance unit,out string err)
		{
			return deleteUnit(unit.WASTE_ID,out err);
		}
		
		/// <summary>
		/// 删除数据表T_COST_INSURANCE中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_COST_INSURANCE.wASTE_ID主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_COST_INSURANCE where "
				+ " upper(T_COST_INSURANCE.WASTE_ID)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_COST_INSURANCE 所有数据信息.
		/// </summary>
		/// <returns>T_COST_INSURANCE DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql = "select	"
				+ "WASTE_ID"
				+ ",DESCRIPTE"
				+ ",POLICY_DATE"
				+ ",SHIP_ID"
				+ ",CURRENCY_ID"
				+ ",PUBLIC_AMOUNT"
				+ ",PAY_DATE"
				+ ",PAY_AMOUNT"
				+ ",STATIC"
				+ ",INSURANCE_COMPANY"
				+ ",REMARK"
				+ "  from T_COST_INSURANCE ";
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
		/// 根据一个主键ID,得到 T_COST_INSURANCE 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>CostInsurance DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql = "select "
				+ "WASTE_ID"
				+ ",DESCRIPTE"
				+ ",POLICY_DATE"
				+ ",SHIP_ID"
				+ ",CURRENCY_ID"
				+ ",PUBLIC_AMOUNT"
				+ ",PAY_DATE"
				+ ",PAY_AMOUNT"
				+ ",STATIC"
				+ ",INSURANCE_COMPANY"
				+ ",REMARK"
				+ " from T_COST_INSURANCE "
				+ " where upper(WASTE_ID)='" + Id.ToUpper()+"'";
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
		/// 根据costinsurance 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>costinsurance 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
		public CostInsurance getObject(DataRow dr)
		{
			CostInsurance unit=new CostInsurance();
			if (null==dr)
			{
				unit.IsWrong = true;
				unit.WhyWrong = "从数据库获取信息时出错,未成功构造CostInsurance类对象!";
				return unit;
			}
			if (DBNull.Value != dr["WASTE_ID"])	
			    unit.WASTE_ID=dr["WASTE_ID"].ToString();
			if (DBNull.Value != dr["DESCRIPTE"])	
			    unit.DESCRIPTE=dr["DESCRIPTE"].ToString();
			if (DBNull.Value != dr["POLICY_DATE"])	
                unit.POLICY_DATE=(DateTime)dr["POLICY_DATE"];
			if (DBNull.Value != dr["SHIP_ID"])	
			    unit.SHIP_ID=dr["SHIP_ID"].ToString();
			if (DBNull.Value != dr["CURRENCY_ID"])	
			    unit.CURRENCY_ID=dr["CURRENCY_ID"].ToString();
			if (DBNull.Value != dr["PUBLIC_AMOUNT"])	
			    unit.PUBLIC_AMOUNT=Convert.ToDecimal(dr["PUBLIC_AMOUNT"]);
			if (DBNull.Value != dr["PAY_DATE"])	
                unit.PAY_DATE=(DateTime)dr["PAY_DATE"];
			if (DBNull.Value != dr["PAY_AMOUNT"])	
			    unit.PAY_AMOUNT=Convert.ToDecimal(dr["PAY_AMOUNT"]);
			if (DBNull.Value != dr["STATIC"])	
			    unit.STATIC=Convert.ToInt32(dr["STATIC"]);
			if (DBNull.Value != dr["INSURANCE_COMPANY"])	
			    unit.INSURANCE_COMPANY=dr["INSURANCE_COMPANY"].ToString();
			if (DBNull.Value != dr["REMARK"])	
			    unit.REMARK=dr["REMARK"].ToString();
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个CostInsurance对象.
		/// </summary>
		/// <param name="wASTE_ID">wASTE_ID</param>
		/// <returns>CostInsurance对象</returns>
		public  CostInsurance getObject(string Id,out string err)
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
