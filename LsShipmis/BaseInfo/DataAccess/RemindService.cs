/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：RemindService.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/11/29
 * 标    题：数据操作类
 * 功能描述：T_REMIND数据操作类
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
    /// 数据层实例化接口类 dbo.T_REMINDService.cs
    /// </summary>
    public partial class RemindService
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static RemindService instance=new RemindService();
        public static RemindService Instance
        { 
            get
            {
                if(null==instance)
                {
                    RemindService.instance = new RemindService();
                }
                return RemindService.instance;
            }
        }
		private RemindService(){}
		#endregion
		
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();        
        string sql = ""; 
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">Remind对象</param>
		/// <returns>插入的对象更新</returns>	
		internal bool saveUnit(Remind unit,out string err)
        {
			if (unit.ID!=null && unit.ID.Length > 0) //edit
			{
				sql = "UPDATE [T_REMIND] SET "
					+ " [ID] = " + (string.IsNullOrEmpty(unit.ID)?"null":"'" + unit.ID.Replace ("'","''") + "'")
					+ " , [BUSINESSID] = " + (string.IsNullOrEmpty(unit.BUSINESSID)?"null":"'" + unit.BUSINESSID.Replace ("'","''") + "'")
					+ " , [REMIND_TYPE] = " + unit.REMIND_TYPE.ToString()
					+ " , [POST_TYPE] = " + (unit.POST_TYPE==null?"''":"'" + unit.POST_TYPE.Replace ("'","''") + "'")
					+ " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ " where upper(ID) = '" + unit.ID.ToUpper() + "'"; 
			}
			else
			{
				unit.ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_REMIND] ("
					+ "[ID],"
					+ "[BUSINESSID],"
					+ "[REMIND_TYPE],"
					+ "[POST_TYPE],"
					+ "[SHIP_ID]"
					+ ") VALUES( "
					+ " " + (string.IsNullOrEmpty(unit.ID)?"null":"'" + unit.ID.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.BUSINESSID)?"null":"'" + unit.BUSINESSID.Replace ("'","''") + "'")
					+ " ,"+ unit.REMIND_TYPE.ToString()
					+ " , " + (unit.POST_TYPE==null?"''":"'" + unit.POST_TYPE.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ ")";
			}

			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_REMIND中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_REMIND对象</param>
		internal bool deleteUnit(Remind unit,out string err)
		{
			return deleteUnit(unit.ID,out err);
		}
		
		/// <summary>
		/// 删除数据表T_REMIND中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_REMIND.iD主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_REMIND where "
				+ " upper(T_REMIND.ID)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_REMIND 所有数据信息.
		/// </summary>
		/// <returns>T_REMIND DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql = "select	"
				+ "ID"
				+ ",BUSINESSID"
				+ ",REMIND_TYPE"
				+ ",POST_TYPE"
				+ ",SHIP_ID"
				+ "  from T_REMIND ";
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
		/// 根据一个主键ID,得到 T_REMIND 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>Remind DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql = "select "
				+ "ID"
				+ ",BUSINESSID"
				+ ",REMIND_TYPE"
				+ ",POST_TYPE"
				+ ",SHIP_ID"
				+ " from T_REMIND "
				+ " where upper(ID)='" + Id.ToUpper()+"'";
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
		/// 根据remind 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>remind 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
		public Remind getObject(DataRow dr)
		{
			Remind unit=new Remind();
			if (null==dr)
			{
				unit.IsWrong = true;
				unit.WhyWrong = "从数据库获取信息时出错,未成功构造Remind类对象!";
				return unit;
			}
			if (DBNull.Value != dr["ID"])	
			    unit.ID=dr["ID"].ToString();
			if (DBNull.Value != dr["BUSINESSID"])	
			    unit.BUSINESSID=dr["BUSINESSID"].ToString();
			if (DBNull.Value != dr["REMIND_TYPE"])	
			    unit.REMIND_TYPE=Convert.ToInt32(dr["REMIND_TYPE"]);
			if (DBNull.Value != dr["POST_TYPE"])	
			    unit.POST_TYPE=dr["POST_TYPE"].ToString();
			if (DBNull.Value != dr["SHIP_ID"])	
			    unit.SHIP_ID=dr["SHIP_ID"].ToString();
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个Remind对象.
		/// </summary>
		/// <param name="iD">iD</param>
		/// <returns>Remind对象</returns>
		public  Remind getObject(string Id,out string err)
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
