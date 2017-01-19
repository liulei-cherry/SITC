/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：HOilApplyService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-7-29
 * 标    题：数据操作类
 * 功能描述：T_HOIL_APPLY数据操作类
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
    /// 数据层实例化接口类 dbo.T_HOIL_APPLYService.cs
    /// </summary>
    public partial class HOilApplyService
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static HOilApplyService instance=new HOilApplyService();
        public static HOilApplyService Instance
        { 
            get
            {
                if(null==instance)
                {
                    HOilApplyService.instance = new HOilApplyService();
                }
                return HOilApplyService.instance;
            }
        }
		private HOilApplyService(){}
		#endregion
		
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();        
        string sql = ""; 
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">HOilApply对象</param>
		/// <returns>插入的对象更新</returns>	
		internal bool saveUnit(HOilApply unit,out string err)
        {
			if (unit.APPLY_ID!=null && unit.APPLY_ID.Length > 0) //edit
			{
				sql = "UPDATE [T_HOIL_APPLY] SET "
					+ " [APPLY_ID] = " + (string.IsNullOrEmpty(unit.APPLY_ID)?"null":"'" + unit.APPLY_ID.Replace ("'","''") + "'")
					+ " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ " , [PORT_ID] = " + (string.IsNullOrEmpty(unit.PORT_ID)?"null":"'" + unit.PORT_ID.Replace ("'","''") + "'")
                    + " , [APPLY_DATE] = " + dbOperation.DbToDate(unit.APPLY_DATE)
                    + " , [SUPPLY_DATE] = " + dbOperation.DbToDate(unit.SUPPLY_DATE)
					+ " , [VOYAGE] = " + (unit.VOYAGE==null?"''":"'" + unit.VOYAGE.Replace ("'","''") + "'")
					+ " , [REMARK] = " + (unit.REMARK==null?"''":"'" + unit.REMARK.Replace ("'","''") + "'")
					+ " , [APPROVER] = " + (unit.APPROVER==null?"''":"'" + unit.APPROVER.Replace ("'","''") + "'")
					+ " , [APPROVER2] = " + (unit.APPROVER2==null?"''":"'" + unit.APPROVER2.Replace ("'","''") + "'")
					+ " , [CHECKED] = " + unit.CHECKED.ToString()
					+ " where upper(APPLY_ID) = '" + unit.APPLY_ID.ToUpper() + "'"; 
			}
			else
			{
				unit.APPLY_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_HOIL_APPLY] ("
					+ "[APPLY_ID],"
					+ "[SHIP_ID],"
					+ "[PORT_ID],"
					+ "[APPLY_DATE],"
					+ "[SUPPLY_DATE],"
					+ "[VOYAGE],"
					+ "[REMARK],"
					+ "[APPROVER],"
					+ "[APPROVER2],"
					+ "[CHECKED]"
					+ ") VALUES( "
					+ " " + (string.IsNullOrEmpty(unit.APPLY_ID)?"null":"'" + unit.APPLY_ID.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.PORT_ID)?"null":"'" + unit.PORT_ID.Replace ("'","''") + "'")
					+ " ," + dbOperation.DbToDate(unit.APPLY_DATE)
					+ " ," + dbOperation.DbToDate(unit.SUPPLY_DATE)
					+ " , " + (unit.VOYAGE==null?"''":"'" + unit.VOYAGE.Replace ("'","''") + "'")
					+ " , " + (unit.REMARK==null?"''":"'" + unit.REMARK.Replace ("'","''") + "'")
					+ " , " + (unit.APPROVER==null?"''":"'" + unit.APPROVER.Replace ("'","''") + "'")
					+ " , " + (unit.APPROVER2==null?"''":"'" + unit.APPROVER2.Replace ("'","''") + "'")
					+ " ,"+ unit.CHECKED.ToString()
					+ ")";
			}

			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_HOIL_APPLY中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_HOIL_APPLY对象</param>
		internal bool deleteUnit(HOilApply unit,out string err)
		{
			return deleteUnit(unit.APPLY_ID,out err);
		}
		
		/// <summary>
		/// 删除数据表T_HOIL_APPLY中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_HOIL_APPLY.aPPLY_ID主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_HOIL_APPLY where "
				+ " upper(T_HOIL_APPLY.APPLY_ID)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_HOIL_APPLY 所有数据信息.
		/// </summary>
		/// <returns>T_HOIL_APPLY DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql = "select	"
				+ "APPLY_ID"
				+ ",SHIP_ID"
				+ ",PORT_ID"
				+ ",APPLY_DATE"
				+ ",SUPPLY_DATE"
				+ ",VOYAGE"
				+ ",REMARK"
				+ ",APPROVER"
				+ ",APPROVER2"
				+ ",CHECKED"
				+ "  from T_HOIL_APPLY ";
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
		/// 根据一个主键ID,得到 T_HOIL_APPLY 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>HOilApply DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql = "select "
				+ "APPLY_ID"
				+ ",SHIP_ID"
				+ ",PORT_ID"
				+ ",APPLY_DATE"
				+ ",SUPPLY_DATE"
				+ ",VOYAGE"
				+ ",REMARK"
				+ ",APPROVER"
				+ ",APPROVER2"
				+ ",CHECKED"
				+ " from T_HOIL_APPLY "
				+ " where upper(APPLY_ID)='" + Id.ToUpper()+"'";
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
		/// 根据hoilapply 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>hoilapply 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
		public HOilApply getObject(DataRow dr)
		{
			HOilApply unit=new HOilApply();
			if (null==dr)
			{
				unit.IsWrong = true;
				unit.WhyWrong = "从数据库获取信息时出错,未成功构造HOilApply类对象!";
				return unit;
			}
			if (DBNull.Value != dr["APPLY_ID"])	
			    unit.APPLY_ID=dr["APPLY_ID"].ToString();
			if (DBNull.Value != dr["SHIP_ID"])	
			    unit.SHIP_ID=dr["SHIP_ID"].ToString();
			if (DBNull.Value != dr["PORT_ID"])	
			    unit.PORT_ID=dr["PORT_ID"].ToString();
			if (DBNull.Value != dr["APPLY_DATE"])	
                unit.APPLY_DATE=(DateTime)dr["APPLY_DATE"];
			if (DBNull.Value != dr["SUPPLY_DATE"])	
                unit.SUPPLY_DATE=(DateTime)dr["SUPPLY_DATE"];
			if (DBNull.Value != dr["VOYAGE"])	
			    unit.VOYAGE=dr["VOYAGE"].ToString();
			if (DBNull.Value != dr["REMARK"])	
			    unit.REMARK=dr["REMARK"].ToString();
			if (DBNull.Value != dr["APPROVER"])	
			    unit.APPROVER=dr["APPROVER"].ToString();
			if (DBNull.Value != dr["APPROVER2"])	
			    unit.APPROVER2=dr["APPROVER2"].ToString();
			if (DBNull.Value != dr["CHECKED"])	
			    unit.CHECKED=Convert.ToDecimal(dr["CHECKED"]);
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个HOilApply对象.
		/// </summary>
		/// <param name="aPPLY_ID">aPPLY_ID</param>
		/// <returns>HOilApply对象</returns>
		public  HOilApply getObject(string Id,out string err)
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
