/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：CurrencyRateService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-7-4
 * 标    题：数据操作类
 * 功能描述：T_CURRENCY_EXCHANGE_RATE数据操作类
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

namespace BaseInfo.DataAccess
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_CURRENCY_EXCHANGE_RATEService.cs
    /// </summary>
    public partial class CurrencyRateService 
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static CurrencyRateService instance=new CurrencyRateService();
        public static CurrencyRateService Instance
        { 
            get
            {
                if(null==instance)
                {
                    CurrencyRateService.instance = new CurrencyRateService();
                }
                return CurrencyRateService.instance;
            }
        }
		private CurrencyRateService(){}
		#endregion
		
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();        
        string sql = ""; 
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">CurrencyRate对象</param>
		/// <returns>插入的对象更新</returns>	
		internal bool saveUnit(CurrencyRate unit,out string err)
        {
			if (unit.RATEID!=null && unit.RATEID.Length > 0) //edit
			{
				sql = "UPDATE [T_CURRENCY_EXCHANGE_RATE] SET "
					+ " [RATEID] = " + (string.IsNullOrEmpty(unit.RATEID)?"null":"'" + unit.RATEID.Replace ("'","''") + "'")
					+ " , [EXCHANGECURRENCY] = " + (unit.EXCHANGECURRENCY==null?"''":"'" + unit.EXCHANGECURRENCY.Replace ("'","''") + "'")
					+ " , [BASECURRENCY] = " + (unit.BASECURRENCY==null?"''":"'" + unit.BASECURRENCY.Replace ("'","''") + "'")
					+ " , [EXCHANGERATE] = " + unit.EXCHANGERATE.ToString()
                    + " , [USEFULDATEFROM] = " + dbOperation.DbToDate(unit.USEFULDATEFROM)
                    + " , [USEFULDATEEND] = " + dbOperation.DbToDate(unit.USEFULDATEEND)
					+ " , [ISUSEFULL] = " + unit.ISUSEFULL.ToString()
					+ " , [REMARK] = " + (unit.REMARK==null?"''":"'" + unit.REMARK.Replace ("'","''") + "'")
					+ " where upper(RATEID) = '" + unit.RATEID.ToUpper() + "'"; 
			}
			else
			{
				unit.RATEID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_CURRENCY_EXCHANGE_RATE] ("
					+ "[RATEID],"
					+ "[EXCHANGECURRENCY],"
					+ "[BASECURRENCY],"
					+ "[EXCHANGERATE],"
					+ "[USEFULDATEFROM],"
					+ "[USEFULDATEEND],"
					+ "[ISUSEFULL],"
					+ "[REMARK]"
					+ ") VALUES( "
					+ " " + (string.IsNullOrEmpty(unit.RATEID)?"null":"'" + unit.RATEID.Replace ("'","''") + "'")
					+ " , " + (unit.EXCHANGECURRENCY==null?"''":"'" + unit.EXCHANGECURRENCY.Replace ("'","''") + "'")
					+ " , " + (unit.BASECURRENCY==null?"''":"'" + unit.BASECURRENCY.Replace ("'","''") + "'")
					+ " ,"+ unit.EXCHANGERATE.ToString()
					+ " ," + dbOperation.DbToDate(unit.USEFULDATEFROM)
					+ " ," + dbOperation.DbToDate(unit.USEFULDATEEND)
					+ " ,"+ unit.ISUSEFULL.ToString()
					+ " , " + (unit.REMARK==null?"''":"'" + unit.REMARK.Replace ("'","''") + "'")
					+ ")";
			}

			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_CURRENCY_EXCHANGE_RATE中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_CURRENCY_EXCHANGE_RATE对象</param>
		internal bool deleteUnit(CurrencyRate unit,out string err)
		{
			return deleteUnit(unit.RATEID,out err);
		}
		
		/// <summary>
		/// 删除数据表T_CURRENCY_EXCHANGE_RATE中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_CURRENCY_EXCHANGE_RATE.rATEID主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_CURRENCY_EXCHANGE_RATE where "
				+ " upper(T_CURRENCY_EXCHANGE_RATE.RATEID)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_CURRENCY_EXCHANGE_RATE 所有数据信息.
		/// </summary>
		/// <returns>T_CURRENCY_EXCHANGE_RATE DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql = "select	"
				+ "RATEID"
				+ ",EXCHANGECURRENCY"
				+ ",BASECURRENCY"
				+ ",EXCHANGERATE"
				+ ",USEFULDATEFROM"
				+ ",USEFULDATEEND"
				+ ",ISUSEFULL"
				+ ",REMARK"
				+ "  from T_CURRENCY_EXCHANGE_RATE ";
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
		/// 根据一个主键ID,得到 T_CURRENCY_EXCHANGE_RATE 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>CurrencyRate DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql = "select "
				+ "RATEID"
				+ ",EXCHANGECURRENCY"
				+ ",BASECURRENCY"
				+ ",EXCHANGERATE"
				+ ",USEFULDATEFROM"
				+ ",USEFULDATEEND"
				+ ",ISUSEFULL"
				+ ",REMARK"
				+ " from T_CURRENCY_EXCHANGE_RATE "
				+ " where upper(RATEID)='" + Id.ToUpper()+"'";
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
		/// 根据currencyrate 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>currencyrate 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
		public CurrencyRate getObject(DataRow dr)
		{
			CurrencyRate unit=new CurrencyRate();
			if (null==dr)
			{
				unit.IsWrong = true;
				unit.WhyWrong = "从数据库获取信息时出错,未成功构造CurrencyRate类对象!";
				return unit;
			}
			if (DBNull.Value != dr["RATEID"])	
			    unit.RATEID=dr["RATEID"].ToString();
			if (DBNull.Value != dr["EXCHANGECURRENCY"])	
			    unit.EXCHANGECURRENCY=dr["EXCHANGECURRENCY"].ToString();
			if (DBNull.Value != dr["BASECURRENCY"])	
			    unit.BASECURRENCY=dr["BASECURRENCY"].ToString();
			if (DBNull.Value != dr["EXCHANGERATE"])	
			    unit.EXCHANGERATE=Convert.ToDecimal(dr["EXCHANGERATE"]);
			if (DBNull.Value != dr["USEFULDATEFROM"])	
                unit.USEFULDATEFROM=(DateTime)dr["USEFULDATEFROM"];
			if (DBNull.Value != dr["USEFULDATEEND"])	
                unit.USEFULDATEEND=(DateTime)dr["USEFULDATEEND"];
			if (DBNull.Value != dr["ISUSEFULL"])	
			    unit.ISUSEFULL=Convert.ToDecimal(dr["ISUSEFULL"]);
			if (DBNull.Value != dr["REMARK"])	
			    unit.REMARK=dr["REMARK"].ToString();
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个CurrencyRate对象.
		/// </summary>
		/// <param name="rATEID">rATEID</param>
		/// <returns>CurrencyRate对象</returns>
		public  CurrencyRate getObject(string Id,out string err)
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
