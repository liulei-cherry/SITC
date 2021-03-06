﻿/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：HOilAddService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-7-25
 * 标    题：数据操作类
 * 功能描述：T_HOIL_ADD数据操作类
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
    /// 数据层实例化接口类 dbo.T_HOIL_ADDService.cs
    /// </summary>
    public partial class HOilAddService
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static HOilAddService instance=new HOilAddService();
        public static HOilAddService Instance
        { 
            get
            {
                if(null==instance)
                {
                    HOilAddService.instance = new HOilAddService();
                }
                return HOilAddService.instance;
            }
        }
		private HOilAddService(){}
		#endregion
		
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();        
        string sql = ""; 
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">HOilAdd对象</param>
		/// <returns>插入的对象更新</returns>	
		internal bool saveUnit(HOilAdd unit,out string err)
        {
			if (unit.FUEL_ID!=null && unit.FUEL_ID.Length > 0) //edit
			{
				sql = "UPDATE [T_HOIL_ADD] SET "
					+ " [FUEL_ID] = " + (string.IsNullOrEmpty(unit.FUEL_ID)?"null":"'" + unit.FUEL_ID.Replace ("'","''") + "'")
					+ " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ " , [PORT_ID] = " + (string.IsNullOrEmpty(unit.PORT_ID)?"null":"'" + unit.PORT_ID.Replace ("'","''") + "'")
                    + " , [ADD_DATE] = " + dbOperation.DbToDate(unit.ADD_DATE)
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
                sql = "INSERT INTO [T_HOIL_ADD] ("
					+ "[FUEL_ID],"
					+ "[SHIP_ID],"
					+ "[PORT_ID],"
					+ "[ADD_DATE],"
					+ "[OIL_TYPE],"
					+ "[SPECIFICATION],"
					+ "[AMOUNT],"
					+ "[SULPHUR],"
					+ "[DENSITY],"
					+ "[REMARK]"
					+ ") VALUES( "
					+ " " + (string.IsNullOrEmpty(unit.FUEL_ID)?"null":"'" + unit.FUEL_ID.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.PORT_ID)?"null":"'" + unit.PORT_ID.Replace ("'","''") + "'")
					+ " ," + dbOperation.DbToDate(unit.ADD_DATE)
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
		/// 删除数据表T_HOIL_ADD中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_HOIL_ADD对象</param>
		internal bool deleteUnit(HOilAdd unit,out string err)
		{
			return deleteUnit(unit.FUEL_ID,out err);
		}
		
		/// <summary>
		/// 删除数据表T_HOIL_ADD中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_HOIL_ADD.fUEL_ID主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_HOIL_ADD where "
				+ " upper(T_HOIL_ADD.FUEL_ID)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_HOIL_ADD 所有数据信息.
		/// </summary>
		/// <returns>T_HOIL_ADD DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql = "select	"
				+ "FUEL_ID"
				+ ",SHIP_ID"
				+ ",PORT_ID"
				+ ",ADD_DATE"
				+ ",OIL_TYPE"
				+ ",SPECIFICATION"
				+ ",AMOUNT"
				+ ",SULPHUR"
				+ ",DENSITY"
				+ ",REMARK"
				+ "  from T_HOIL_ADD ";
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
		/// 根据一个主键ID,得到 T_HOIL_ADD 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>HOilAdd DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql = "select "
				+ "FUEL_ID"
				+ ",SHIP_ID"
				+ ",PORT_ID"
				+ ",ADD_DATE"
				+ ",OIL_TYPE"
				+ ",SPECIFICATION"
				+ ",AMOUNT"
				+ ",SULPHUR"
				+ ",DENSITY"
				+ ",REMARK"
				+ " from T_HOIL_ADD "
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
		/// 根据hoiladd 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>hoiladd 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
		public HOilAdd getObject(DataRow dr)
		{
			HOilAdd unit=new HOilAdd();
			if (null==dr)
			{
				unit.IsWrong = true;
				unit.WhyWrong = "从数据库获取信息时出错,未成功构造HOilAdd类对象!";
				return unit;
			}
			if (DBNull.Value != dr["FUEL_ID"])	
			    unit.FUEL_ID=dr["FUEL_ID"].ToString();
			if (DBNull.Value != dr["SHIP_ID"])	
			    unit.SHIP_ID=dr["SHIP_ID"].ToString();
			if (DBNull.Value != dr["PORT_ID"])	
			    unit.PORT_ID=dr["PORT_ID"].ToString();
			if (DBNull.Value != dr["ADD_DATE"])	
                unit.ADD_DATE=(DateTime)dr["ADD_DATE"];
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
		/// 根据ID,返回一个HOilAdd对象.
		/// </summary>
		/// <param name="fUEL_ID">fUEL_ID</param>
		/// <returns>HOilAdd对象</returns>
		public  HOilAdd getObject(string Id,out string err)
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
