/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：HOilConsumeService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-7-25
 * 标    题：数据操作类
 * 功能描述：T_HOIL_CONSUME数据操作类
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
    /// 数据层实例化接口类 dbo.T_HOIL_CONSUMEService.cs
    /// </summary>
    public partial class HOilConsumeService
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static HOilConsumeService instance=new HOilConsumeService();
        public static HOilConsumeService Instance
        { 
            get
            {
                if(null==instance)
                {
                    HOilConsumeService.instance = new HOilConsumeService();
                }
                return HOilConsumeService.instance;
            }
        }
		private HOilConsumeService(){}
		#endregion
		
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();        
        string sql = ""; 
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">HOilConsume对象</param>
		/// <returns>插入的对象更新</returns>	
		internal bool saveUnit(HOilConsume unit,out string err)
        {
			if (unit.FUEL_ID!=null && unit.FUEL_ID.Length > 0) //edit
			{
				sql = "UPDATE [T_HOIL_CONSUME] SET "
					+ " [FUEL_ID] = " + (string.IsNullOrEmpty(unit.FUEL_ID)?"null":"'" + unit.FUEL_ID.Replace ("'","''") + "'")
					+ " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
                    + " , [CONSUME_MONTH] = " + dbOperation.DbToDate(unit.CONSUME_MONTH)
					+ " , [CONSUME_TYPE] = " + (unit.CONSUME_TYPE==null?"''":"'" + unit.CONSUME_TYPE.Replace ("'","''") + "'")
					+ " , [OIL_TYPE] = " + (unit.OIL_TYPE==null?"''":"'" + unit.OIL_TYPE.Replace ("'","''") + "'")
					+ " , [SPECIFICATION] = " + (unit.SPECIFICATION==null?"''":"'" + unit.SPECIFICATION.Replace ("'","''") + "'")
					+ " , [AMOUNT] = " + unit.AMOUNT.ToString()
					+ " , [SULPHUR] = " + unit.SULPHUR.ToString()
					+ " , [DENSITY] = " + unit.DENSITY.ToString()
					+ " , [REMARK] = " + (unit.REMARK==null?"''":"'" + unit.REMARK.Replace ("'","''") + "'")
					+ " where upper(FUEL_ID) = '" + unit.FUEL_ID.ToUpper() + "'"; 
			}
			else
			{
				unit.FUEL_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_HOIL_CONSUME] ("
					+ "[FUEL_ID],"
					+ "[SHIP_ID],"
					+ "[CONSUME_MONTH],"
					+ "[CONSUME_TYPE],"
					+ "[OIL_TYPE],"
					+ "[SPECIFICATION],"
					+ "[AMOUNT],"
					+ "[SULPHUR],"
					+ "[DENSITY],"
					+ "[REMARK]"
					+ ") VALUES( "
					+ " " + (string.IsNullOrEmpty(unit.FUEL_ID)?"null":"'" + unit.FUEL_ID.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ " ," + dbOperation.DbToDate(unit.CONSUME_MONTH)
					+ " , " + (unit.CONSUME_TYPE==null?"''":"'" + unit.CONSUME_TYPE.Replace ("'","''") + "'")
					+ " , " + (unit.OIL_TYPE==null?"''":"'" + unit.OIL_TYPE.Replace ("'","''") + "'")
					+ " , " + (unit.SPECIFICATION==null?"''":"'" + unit.SPECIFICATION.Replace ("'","''") + "'")
					+ " ,"+ unit.AMOUNT.ToString()
					+ " ,"+ unit.SULPHUR.ToString()
					+ " ,"+ unit.DENSITY.ToString()
					+ " , " + (unit.REMARK==null?"''":"'" + unit.REMARK.Replace ("'","''") + "'")
					+ ")";
			}

			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_HOIL_CONSUME中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_HOIL_CONSUME对象</param>
		internal bool deleteUnit(HOilConsume unit,out string err)
		{
			return deleteUnit(unit.FUEL_ID,out err);
		}
		
		/// <summary>
		/// 删除数据表T_HOIL_CONSUME中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_HOIL_CONSUME.fUEL_ID主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_HOIL_CONSUME where "
				+ " upper(T_HOIL_CONSUME.FUEL_ID)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_HOIL_CONSUME 所有数据信息.
		/// </summary>
		/// <returns>T_HOIL_CONSUME DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql = "select	"
				+ "FUEL_ID"
				+ ",SHIP_ID"
				+ ",CONSUME_MONTH"
				+ ",CONSUME_TYPE"
				+ ",OIL_TYPE"
				+ ",SPECIFICATION"
				+ ",AMOUNT"
				+ ",SULPHUR"
				+ ",DENSITY"
				+ ",REMARK"
				+ "  from T_HOIL_CONSUME ";
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
		/// 根据一个主键ID,得到 T_HOIL_CONSUME 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>HOilConsume DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql = "select "
				+ "FUEL_ID"
				+ ",SHIP_ID"
				+ ",CONSUME_MONTH"
				+ ",CONSUME_TYPE"
				+ ",OIL_TYPE"
				+ ",SPECIFICATION"
				+ ",AMOUNT"
				+ ",SULPHUR"
				+ ",DENSITY"
				+ ",REMARK"
				+ " from T_HOIL_CONSUME "
				+ " where upper(FUEL_ID)='" + Id.ToUpper()+"'";
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
		/// 根据hoilconsume 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>hoilconsume 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
		public HOilConsume getObject(DataRow dr)
		{
			HOilConsume unit=new HOilConsume();
			if (null==dr)
			{
				unit.IsWrong = true;
				unit.WhyWrong = "从数据库获取信息时出错,未成功构造HOilConsume类对象!";
				return unit;
			}
			if (DBNull.Value != dr["FUEL_ID"])	
			    unit.FUEL_ID=dr["FUEL_ID"].ToString();
			if (DBNull.Value != dr["SHIP_ID"])	
			    unit.SHIP_ID=dr["SHIP_ID"].ToString();
			if (DBNull.Value != dr["CONSUME_MONTH"])	
                unit.CONSUME_MONTH=(DateTime)dr["CONSUME_MONTH"];
			if (DBNull.Value != dr["CONSUME_TYPE"])	
			    unit.CONSUME_TYPE=dr["CONSUME_TYPE"].ToString();
			if (DBNull.Value != dr["OIL_TYPE"])	
			    unit.OIL_TYPE=dr["OIL_TYPE"].ToString();
			if (DBNull.Value != dr["SPECIFICATION"])	
			    unit.SPECIFICATION=dr["SPECIFICATION"].ToString();
			if (DBNull.Value != dr["AMOUNT"])	
			    unit.AMOUNT=Convert.ToDecimal(dr["AMOUNT"]);
			if (DBNull.Value != dr["SULPHUR"])	
			    unit.SULPHUR=Convert.ToDecimal(dr["SULPHUR"]);
			if (DBNull.Value != dr["DENSITY"])	
			    unit.DENSITY=Convert.ToDecimal(dr["DENSITY"]);
			if (DBNull.Value != dr["REMARK"])	
			    unit.REMARK=dr["REMARK"].ToString();
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个HOilConsume对象.
		/// </summary>
		/// <param name="fUEL_ID">fUEL_ID</param>
		/// <returns>HOilConsume对象</returns>
		public  HOilConsume getObject(string Id,out string err)
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
