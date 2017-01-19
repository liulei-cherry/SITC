/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：CostDisorderService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-8-24
 * 标    题：数据操作类
 * 功能描述：T_COST_DISORDER数据操作类
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
    /// 数据层实例化接口类 dbo.T_COST_DISORDERService.cs
    /// </summary>
    public partial class CostDisorderService
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static CostDisorderService instance=new CostDisorderService();
        public static CostDisorderService Instance
        { 
            get
            {
                if(null==instance)
                {
                    CostDisorderService.instance = new CostDisorderService();
                }
                return CostDisorderService.instance;
            }
        }
		private CostDisorderService(){}
		#endregion
		
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();        
        string sql = ""; 
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">CostDisorder对象</param>
		/// <returns>插入的对象更新</returns>	
		internal bool saveUnit(CostDisorder unit,out string err)
        {
			if (unit.COSTS_ID!=null && unit.COSTS_ID.Length > 0) //edit
			{
				sql = "UPDATE [T_COST_DISORDER] SET "
					+ " [COSTS_ID] = " + (string.IsNullOrEmpty(unit.COSTS_ID)?"null":"'" + unit.COSTS_ID.Replace ("'","''") + "'")
					+ " , [CLASS_ID] = " + (string.IsNullOrEmpty(unit.CLASS_ID)?"null":"'" + unit.CLASS_ID.Replace ("'","''") + "'")
					+ " , [DESCRIPTION] = " + (unit.DESCRIPTION==null?"''":"'" + unit.DESCRIPTION.Replace ("'","''") + "'")
                    + " , [OCCURENCY_DATE] = " + dbOperation.DbToDate(unit.OCCURENCY_DATE)
					+ " , [ESTIMATE_AMOUNT] = " + unit.ESTIMATE_AMOUNT.ToString()
					+ " , [PLACE] = " + (unit.PLACE==null?"''":"'" + unit.PLACE.Replace ("'","''") + "'")
					+ " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ " where upper(COSTS_ID) = '" + unit.COSTS_ID.ToUpper() + "'"; 
			}
			else
			{
				unit.COSTS_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_COST_DISORDER] ("
					+ "[COSTS_ID],"
					+ "[CLASS_ID],"
					+ "[DESCRIPTION],"
					+ "[OCCURENCY_DATE],"
					+ "[ESTIMATE_AMOUNT],"
					+ "[PLACE],"
					+ "[SHIP_ID]"
					+ ") VALUES( "
					+ " " + (string.IsNullOrEmpty(unit.COSTS_ID)?"null":"'" + unit.COSTS_ID.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.CLASS_ID)?"null":"'" + unit.CLASS_ID.Replace ("'","''") + "'")
					+ " , " + (unit.DESCRIPTION==null?"''":"'" + unit.DESCRIPTION.Replace ("'","''") + "'")
					+ " ," + dbOperation.DbToDate(unit.OCCURENCY_DATE)
					+ " ,"+ unit.ESTIMATE_AMOUNT.ToString()
					+ " , " + (unit.PLACE==null?"''":"'" + unit.PLACE.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ ")";
			}

			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_COST_DISORDER中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_COST_DISORDER对象</param>
		internal bool deleteUnit(CostDisorder unit,out string err)
		{
			return deleteUnit(unit.COSTS_ID,out err);
		}
		
		/// <summary>
		/// 删除数据表T_COST_DISORDER中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_COST_DISORDER.cOSTS_ID主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_COST_DISORDER where "
				+ " upper(T_COST_DISORDER.COSTS_ID)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_COST_DISORDER 所有数据信息.
		/// </summary>
		/// <returns>T_COST_DISORDER DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql = "select	"
				+ "COSTS_ID"
				+ ",CLASS_ID"
				+ ",DESCRIPTION"
				+ ",OCCURENCY_DATE"
				+ ",ESTIMATE_AMOUNT"
				+ ",PLACE"
				+ ",SHIP_ID"
				+ "  from T_COST_DISORDER ";
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
		/// 根据一个主键ID,得到 T_COST_DISORDER 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>CostDisorder DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql = "select "
				+ "COSTS_ID"
				+ ",CLASS_ID"
				+ ",DESCRIPTION"
				+ ",OCCURENCY_DATE"
				+ ",ESTIMATE_AMOUNT"
				+ ",PLACE"
				+ ",SHIP_ID"
				+ " from T_COST_DISORDER "
				+ " where upper(COSTS_ID)='" + Id.ToUpper()+"'";
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
		/// 根据costdisorder 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>costdisorder 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
		public CostDisorder getObject(DataRow dr)
		{
			CostDisorder unit=new CostDisorder();
			if (null==dr)
			{
				unit.IsWrong = true;
				unit.WhyWrong = "从数据库获取信息时出错,未成功构造CostDisorder类对象!";
				return unit;
			}
			if (DBNull.Value != dr["COSTS_ID"])	
			    unit.COSTS_ID=dr["COSTS_ID"].ToString();
			if (DBNull.Value != dr["CLASS_ID"])	
			    unit.CLASS_ID=dr["CLASS_ID"].ToString();
			if (DBNull.Value != dr["DESCRIPTION"])	
			    unit.DESCRIPTION=dr["DESCRIPTION"].ToString();
			if (DBNull.Value != dr["OCCURENCY_DATE"])	
                unit.OCCURENCY_DATE=(DateTime)dr["OCCURENCY_DATE"];
			if (DBNull.Value != dr["ESTIMATE_AMOUNT"])	
			    unit.ESTIMATE_AMOUNT=Convert.ToDecimal(dr["ESTIMATE_AMOUNT"]);
			if (DBNull.Value != dr["PLACE"])	
			    unit.PLACE=dr["PLACE"].ToString();
			if (DBNull.Value != dr["SHIP_ID"])	
			    unit.SHIP_ID=dr["SHIP_ID"].ToString();
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个CostDisorder对象.
		/// </summary>
		/// <param name="cOSTS_ID">cOSTS_ID</param>
		/// <returns>CostDisorder对象</returns>
		public  CostDisorder getObject(string Id,out string err)
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
