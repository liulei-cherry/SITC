/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：T_WORKINFO_HISTORY_OUTService.cs
 * 创 建 人：黄家龙
 * 创建时间：2011/11/7
 * 标    题：数据操作类
 * 功能描述：T_WORKINFO_HISTORY_OUT数据操作类
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
using Maintenance.DataObject;

namespace  Maintenance.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_WORKINFO_HISTORY_OUTService.cs
    /// </summary>
    public partial class T_WORKINFO_HISTORY_OUTService
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static T_WORKINFO_HISTORY_OUTService instance=new T_WORKINFO_HISTORY_OUTService();
        public static T_WORKINFO_HISTORY_OUTService Instance
        { 
            get
            {
                if(null==instance)
                {
                    T_WORKINFO_HISTORY_OUTService.instance = new T_WORKINFO_HISTORY_OUTService();
                }
                return T_WORKINFO_HISTORY_OUTService.instance;
            }
        }
		private T_WORKINFO_HISTORY_OUTService(){}
		#endregion
		
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();        
        string sql = ""; 
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">T_WORKINFO_HISTORY_OUT对象</param>
		/// <returns>插入的对象更新</returns>	
		internal bool saveUnit(T_WORKINFO_HISTORY_OUT unit,out string err)
        {
			if (unit.WHID!=null && unit.WHID.Length > 0) //edit
			{
				sql = "UPDATE [T_WORKINFO_HISTORY_OUT] SET "
					+ " [WHID] = " + (string.IsNullOrEmpty(unit.WHID)?"null":"'" + unit.WHID.Replace ("'","''") + "'")
					+ " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
                    + " , [ANNUAL] = " + dbOperation.DbToDate(unit.ANNUAL)
					+ " , [REPROT_TYPE] = " + unit.REPROT_TYPE.ToString()
					+ " , [WORKID] = " + (string.IsNullOrEmpty(unit.WORKID)?"null":"'" + unit.WORKID.Replace ("'","''") + "'")
					+ " , [ORDERNUM_SHOW] = " + (unit.ORDERNUM_SHOW==null?"''":"'" + unit.ORDERNUM_SHOW.Replace ("'","''") + "'")
					+ " , [CLASS1] = " + (unit.CLASS1==null?"''":"'" + unit.CLASS1.Replace ("'","''") + "'")
					+ " , [CLASS2] = " + (unit.CLASS2==null?"''":"'" + unit.CLASS2.Replace ("'","''") + "'")
					+ " , [MONTHS_CHECK] = " + (unit.MONTHS_CHECK==null?"''":"'" + unit.MONTHS_CHECK.Replace ("'","''") + "'")
					+ " , [EX1] = " + (unit.EX1==null?"''":"'" + unit.EX1.Replace ("'","''") + "'")
					+ " , [EX2] = " + (unit.EX2==null?"''":"'" + unit.EX2.Replace ("'","''") + "'")
					+ " , [EX3] = " + (unit.EX3==null?"''":"'" + unit.EX3.Replace ("'","''") + "'")
					+ " , [EX4] = " + (unit.EX4==null?"''":"'" + unit.EX4.Replace ("'","''") + "'")
					+ " , [EX5] = " + (unit.EX5==null?"''":"'" + unit.EX5.Replace ("'","''") + "'")
					+ " , [ITEMTYPE] = " + (unit.ITEMTYPE==null?"''":"'" + unit.ITEMTYPE.Replace ("'","''") + "'")
					+ " , [EXCEL_ORDERNUM] = " + unit.EXCEL_ORDERNUM.ToString()
					+ " where upper(WHID) = '" + unit.WHID.ToUpper() + "'"; 
			}
			else
			{
				unit.WHID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_WORKINFO_HISTORY_OUT] ("
					+ "[WHID],"
					+ "[SHIP_ID],"
					+ "[ANNUAL],"
					+ "[REPROT_TYPE],"
					+ "[WORKID],"
					+ "[ORDERNUM_SHOW],"
					+ "[CLASS1],"
					+ "[CLASS2],"
					+ "[MONTHS_CHECK],"
					+ "[EX1],"
					+ "[EX2],"
					+ "[EX3],"
					+ "[EX4],"
					+ "[EX5],"
					+ "[ITEMTYPE],"
					+ "[EXCEL_ORDERNUM]"
					+ ") VALUES( "
					+ " " + (string.IsNullOrEmpty(unit.WHID)?"null":"'" + unit.WHID.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ " ," + dbOperation.DbToDate(unit.ANNUAL)
					+ " ,"+ unit.REPROT_TYPE.ToString()
					+ " , " + (string.IsNullOrEmpty(unit.WORKID)?"null":"'" + unit.WORKID.Replace ("'","''") + "'")
					+ " , " + (unit.ORDERNUM_SHOW==null?"''":"'" + unit.ORDERNUM_SHOW.Replace ("'","''") + "'")
					+ " , " + (unit.CLASS1==null?"''":"'" + unit.CLASS1.Replace ("'","''") + "'")
					+ " , " + (unit.CLASS2==null?"''":"'" + unit.CLASS2.Replace ("'","''") + "'")
					+ " , " + (unit.MONTHS_CHECK==null?"''":"'" + unit.MONTHS_CHECK.Replace ("'","''") + "'")
					+ " , " + (unit.EX1==null?"''":"'" + unit.EX1.Replace ("'","''") + "'")
					+ " , " + (unit.EX2==null?"''":"'" + unit.EX2.Replace ("'","''") + "'")
					+ " , " + (unit.EX3==null?"''":"'" + unit.EX3.Replace ("'","''") + "'")
					+ " , " + (unit.EX4==null?"''":"'" + unit.EX4.Replace ("'","''") + "'")
					+ " , " + (unit.EX5==null?"''":"'" + unit.EX5.Replace ("'","''") + "'")
					+ " , " + (unit.ITEMTYPE==null?"''":"'" + unit.ITEMTYPE.Replace ("'","''") + "'")
					+ " ,"+ unit.EXCEL_ORDERNUM.ToString()
					+ ")";
			}
	
			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_WORKINFO_HISTORY_OUT中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_WORKINFO_HISTORY_OUT对象</param>
		internal bool deleteUnit(T_WORKINFO_HISTORY_OUT unit,out string err)
		{
			return deleteUnit(unit.WHID,out err);
		}
		
		/// <summary>
		/// 删除数据表T_WORKINFO_HISTORY_OUT中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_WORKINFO_HISTORY_OUT.wHID主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_WORKINFO_HISTORY_OUT where "
				+ " upper(T_WORKINFO_HISTORY_OUT.WHID)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_WORKINFO_HISTORY_OUT 所有数据信息.
		/// </summary>
		/// <returns>T_WORKINFO_HISTORY_OUT DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql = "select	"
				+ "WHID"
				+ ",SHIP_ID"
				+ ",ANNUAL"
				+ ",REPROT_TYPE"
				+ ",WORKID"
				+ ",ORDERNUM_SHOW"
				+ ",CLASS1"
				+ ",CLASS2"
				+ ",MONTHS_CHECK"
				+ ",EX1"
				+ ",EX2"
				+ ",EX3"
				+ ",EX4"
				+ ",EX5"
				+ ",ITEMTYPE"
				+ ",EXCEL_ORDERNUM"
				+ "  from T_WORKINFO_HISTORY_OUT ";
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
		/// 根据一个主键ID,得到 T_WORKINFO_HISTORY_OUT 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>T_WORKINFO_HISTORY_OUT DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql = "select "
				+ "WHID"
				+ ",SHIP_ID"
				+ ",ANNUAL"
				+ ",REPROT_TYPE"
				+ ",WORKID"
				+ ",ORDERNUM_SHOW"
				+ ",CLASS1"
				+ ",CLASS2"
				+ ",MONTHS_CHECK"
				+ ",EX1"
				+ ",EX2"
				+ ",EX3"
				+ ",EX4"
				+ ",EX5"
				+ ",ITEMTYPE"
				+ ",EXCEL_ORDERNUM"
				+ " from T_WORKINFO_HISTORY_OUT "
				+ " where upper(WHID)='" + Id.ToUpper()+"'";
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
		/// 根据t_workinfo_history_out 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>t_workinfo_history_out 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
		public T_WORKINFO_HISTORY_OUT getObject(DataRow dr)
		{
			T_WORKINFO_HISTORY_OUT unit=new T_WORKINFO_HISTORY_OUT();
			if (null==dr)
			{
				unit.IsWrong = true;
				unit.WhyWrong = "从数据库获取信息时出错,未成功构造T_WORKINFO_HISTORY_OUT类对象!";
				return unit;
			}
			if (DBNull.Value != dr["WHID"])	
			    unit.WHID=dr["WHID"].ToString();
			if (DBNull.Value != dr["SHIP_ID"])	
			    unit.SHIP_ID=dr["SHIP_ID"].ToString();
			if (DBNull.Value != dr["ANNUAL"])	
                unit.ANNUAL=(DateTime)dr["ANNUAL"];
			if (DBNull.Value != dr["REPROT_TYPE"])	
			    unit.REPROT_TYPE=Convert.ToInt32(dr["REPROT_TYPE"]);
			if (DBNull.Value != dr["WORKID"])	
			    unit.WORKID=dr["WORKID"].ToString();
			if (DBNull.Value != dr["ORDERNUM_SHOW"])	
			    unit.ORDERNUM_SHOW=dr["ORDERNUM_SHOW"].ToString();
			if (DBNull.Value != dr["CLASS1"])	
			    unit.CLASS1=dr["CLASS1"].ToString();
			if (DBNull.Value != dr["CLASS2"])	
			    unit.CLASS2=dr["CLASS2"].ToString();
			if (DBNull.Value != dr["MONTHS_CHECK"])	
			    unit.MONTHS_CHECK=dr["MONTHS_CHECK"].ToString();
			if (DBNull.Value != dr["EX1"])	
			    unit.EX1=dr["EX1"].ToString();
			if (DBNull.Value != dr["EX2"])	
			    unit.EX2=dr["EX2"].ToString();
			if (DBNull.Value != dr["EX3"])	
			    unit.EX3=dr["EX3"].ToString();
			if (DBNull.Value != dr["EX4"])	
			    unit.EX4=dr["EX4"].ToString();
			if (DBNull.Value != dr["EX5"])	
			    unit.EX5=dr["EX5"].ToString();
			if (DBNull.Value != dr["ITEMTYPE"])	
			    unit.ITEMTYPE=dr["ITEMTYPE"].ToString();
			if (DBNull.Value != dr["EXCEL_ORDERNUM"])	
			    unit.EXCEL_ORDERNUM=Convert.ToInt32(dr["EXCEL_ORDERNUM"]);
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个T_WORKINFO_HISTORY_OUT对象.
		/// </summary>
		/// <param name="wHID">wHID</param>
		/// <returns>T_WORKINFO_HISTORY_OUT对象</returns>
		public  T_WORKINFO_HISTORY_OUT getObject(string Id,out string err)
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
