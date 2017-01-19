/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：CostSimpleclassService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-8-24
 * 标    题：数据操作类
 * 功能描述：T_COST_SIMPLECLASS数据操作类
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
    /// 数据层实例化接口类 dbo.T_COST_SIMPLECLASSService.cs
    /// </summary>
    public partial class CostSimpleclassService
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static CostSimpleclassService instance=new CostSimpleclassService();
        public static CostSimpleclassService Instance
        { 
            get
            {
                if(null==instance)
                {
                    CostSimpleclassService.instance = new CostSimpleclassService();
                }
                return CostSimpleclassService.instance;
            }
        }
		private CostSimpleclassService(){}
		#endregion
		
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();        
        string sql = ""; 
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">CostSimpleclass对象</param>
		/// <returns>插入的对象更新</returns>	
		internal bool saveUnit(CostSimpleclass unit,out string err)
        {
			if (unit.CLASS_ID!=null && unit.CLASS_ID.Length > 0) //edit
			{
				sql = "UPDATE [T_COST_SIMPLECLASS] SET "
					+ " [CLASS_ID] = " + (string.IsNullOrEmpty(unit.CLASS_ID)?"null":"'" + unit.CLASS_ID.Replace ("'","''") + "'")
					+ " , [TYPE] = " + (unit.TYPE==null?"''":"'" + unit.TYPE.Replace ("'","''") + "'")
					+ " , [NAME] = " + (unit.NAME==null?"''":"'" + unit.NAME.Replace ("'","''") + "'")
					+ " where upper(CLASS_ID) = '" + unit.CLASS_ID.ToUpper() + "'"; 
			}
			else
			{
				unit.CLASS_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_COST_SIMPLECLASS] ("
					+ "[CLASS_ID],"
					+ "[TYPE],"
					+ "[NAME]"
					+ ") VALUES( "
					+ " " + (string.IsNullOrEmpty(unit.CLASS_ID)?"null":"'" + unit.CLASS_ID.Replace ("'","''") + "'")
					+ " , " + (unit.TYPE==null?"''":"'" + unit.TYPE.Replace ("'","''") + "'")
					+ " , " + (unit.NAME==null?"''":"'" + unit.NAME.Replace ("'","''") + "'")
					+ ")";
			}

			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_COST_SIMPLECLASS中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_COST_SIMPLECLASS对象</param>
		internal bool deleteUnit(CostSimpleclass unit,out string err)
		{
			return deleteUnit(unit.CLASS_ID,out err);
		}
		
		/// <summary>
		/// 删除数据表T_COST_SIMPLECLASS中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_COST_SIMPLECLASS.cLASS_ID主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_COST_SIMPLECLASS where "
				+ " upper(T_COST_SIMPLECLASS.CLASS_ID)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_COST_SIMPLECLASS 所有数据信息.
		/// </summary>
		/// <returns>T_COST_SIMPLECLASS DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql = "select	"
				+ "CLASS_ID"
				+ ",TYPE"
				+ ",NAME"
				+ "  from T_COST_SIMPLECLASS ";
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
		/// 根据一个主键ID,得到 T_COST_SIMPLECLASS 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>CostSimpleclass DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql = "select "
				+ "CLASS_ID"
				+ ",TYPE"
				+ ",NAME"
				+ " from T_COST_SIMPLECLASS "
				+ " where upper(CLASS_ID)='" + Id.ToUpper()+"'";
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
		/// 根据costsimpleclass 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>costsimpleclass 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
		public CostSimpleclass getObject(DataRow dr)
		{
			CostSimpleclass unit=new CostSimpleclass();
			if (null==dr)
			{
				unit.IsWrong = true;
				unit.WhyWrong = "从数据库获取信息时出错,未成功构造CostSimpleclass类对象!";
				return unit;
			}
			if (DBNull.Value != dr["CLASS_ID"])	
			    unit.CLASS_ID=dr["CLASS_ID"].ToString();
			if (DBNull.Value != dr["TYPE"])	
			    unit.TYPE=dr["TYPE"].ToString();
			if (DBNull.Value != dr["NAME"])	
			    unit.NAME=dr["NAME"].ToString();
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个CostSimpleclass对象.
		/// </summary>
		/// <param name="cLASS_ID">cLASS_ID</param>
		/// <returns>CostSimpleclass对象</returns>
		public  CostSimpleclass getObject(string Id,out string err)
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
