/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：ArgumentSetService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-7-27
 * 标    题：数据操作类
 * 功能描述：T_ARGUMENT_SET数据操作类
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
using BaseInfo.DataObject;

namespace BaseInfo.DataAccess
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_ARGUMENT_SETService.cs
    /// </summary>
    public partial class ArgumentSetService
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static ArgumentSetService instance=new ArgumentSetService();
        public static ArgumentSetService Instance
        { 
            get
            {
                if(null==instance)
                {
                    ArgumentSetService.instance = new ArgumentSetService();
                }
                return ArgumentSetService.instance;
            }
        }
		private ArgumentSetService(){}
		#endregion
		
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();        
        string sql = ""; 
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">ArgumentSet对象</param>
		/// <returns>插入的对象更新</returns>	
		internal bool saveUnit(ArgumentSet unit,out string err)
        {
			if (unit.SYS_ID!=null && unit.SYS_ID.Length > 0) //edit
			{
				sql = "UPDATE [T_ARGUMENT_SET] SET "
					+ " [SYS_ID] = " + (string.IsNullOrEmpty(unit.SYS_ID)?"null":"'" + unit.SYS_ID.Replace ("'","''") + "'")
					+ " , [CODE] = " + (unit.CODE==null?"''":"'" + unit.CODE.Replace ("'","''") + "'")
					+ " , [CODE_VALUE] = " + (unit.CODE_VALUE==null?"''":"'" + unit.CODE_VALUE.Replace ("'","''") + "'")
					+ " , [INTRO] = " + (unit.INTRO==null?"''":"'" + unit.INTRO.Replace ("'","''") + "'")
					+ " where upper(SYS_ID) = '" + unit.SYS_ID.ToUpper() + "'"; 
			}
			else
			{
				unit.SYS_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_ARGUMENT_SET] ("
					+ "[SYS_ID],"
					+ "[CODE],"
					+ "[CODE_VALUE],"
					+ "[INTRO]"
					+ ") VALUES( "
					+ " " + (string.IsNullOrEmpty(unit.SYS_ID)?"null":"'" + unit.SYS_ID.Replace ("'","''") + "'")
					+ " , " + (unit.CODE==null?"''":"'" + unit.CODE.Replace ("'","''") + "'")
					+ " , " + (unit.CODE_VALUE==null?"''":"'" + unit.CODE_VALUE.Replace ("'","''") + "'")
					+ " , " + (unit.INTRO==null?"''":"'" + unit.INTRO.Replace ("'","''") + "'")
					+ ")";
			}

			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_ARGUMENT_SET中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_ARGUMENT_SET对象</param>
		internal bool deleteUnit(ArgumentSet unit,out string err)
		{
			return deleteUnit(unit.SYS_ID,out err);
		}
		
		/// <summary>
		/// 删除数据表T_ARGUMENT_SET中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_ARGUMENT_SET.sYS_ID主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_ARGUMENT_SET where "
				+ " upper(T_ARGUMENT_SET.SYS_ID)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_ARGUMENT_SET 所有数据信息.
		/// </summary>
		/// <returns>T_ARGUMENT_SET DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql = "select	"
				+ "SYS_ID"
				+ ",CODE"
				+ ",CODE_VALUE"
				+ ",INTRO"
				+ "  from T_ARGUMENT_SET";
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
		/// 根据一个主键ID,得到 T_ARGUMENT_SET 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>ArgumentSet DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql = "select "
				+ "SYS_ID"
				+ ",CODE"
				+ ",CODE_VALUE"
				+ ",INTRO"
				+ " from T_ARGUMENT_SET "
				+ " where upper(SYS_ID)='" + Id.ToUpper()+"'";
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
		/// 根据argumentset 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>argumentset 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
		public ArgumentSet getObject(DataRow dr)
		{
			ArgumentSet unit=new ArgumentSet();
			if (null==dr)
			{
				unit.IsWrong = true;
				unit.WhyWrong = "从数据库获取信息时出错,未成功构造ArgumentSet类对象!";
				return unit;
			}
			if (DBNull.Value != dr["SYS_ID"])	
			    unit.SYS_ID=dr["SYS_ID"].ToString();
			if (DBNull.Value != dr["CODE"])	
			    unit.CODE=dr["CODE"].ToString();
			if (DBNull.Value != dr["CODE_VALUE"])	
			    unit.CODE_VALUE=dr["CODE_VALUE"].ToString();
			if (DBNull.Value != dr["INTRO"])	
			    unit.INTRO=dr["INTRO"].ToString();
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个ArgumentSet对象.
		/// </summary>
		/// <param name="sYS_ID">sYS_ID</param>
		/// <returns>ArgumentSet对象</returns>
		public  ArgumentSet getObject(string Id,out string err)
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
