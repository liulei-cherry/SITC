/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：T_WORKINFO_TEMPLETService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-5-12
 * 标    题：数据操作类
 * 功能描述：T_WORKINFO_TEMPLET数据操作类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
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
    /// 数据层实例化接口类 dbo.T_WORKINFO_TEMPLETService.cs
    /// </summary>
    public partial class T_WORKINFO_TEMPLETService
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static T_WORKINFO_TEMPLETService instance=new T_WORKINFO_TEMPLETService();
        public static T_WORKINFO_TEMPLETService Instance
        { 
            get
            {
                if(null==instance)
                {
                    T_WORKINFO_TEMPLETService.instance = new T_WORKINFO_TEMPLETService();
                }
                return T_WORKINFO_TEMPLETService.instance;
            }
        }
		private T_WORKINFO_TEMPLETService(){}
		#endregion
		
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();        
        string sql = ""; 
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">T_WORKINFO_TEMPLET对象</param>
		/// <returns>插入的对象更新</returns>	
		internal bool saveUnit(T_WORKINFO_TEMPLET unit,out string err)
        {
			if (unit.WORKINFO_TEMPLET_ID!=null && unit.WORKINFO_TEMPLET_ID.Length > 0) //edit
			{
				sql = "UPDATE [T_WORKINFO_TEMPLET] SET "
					+ " [WORKINFO_TEMPLET_ID] = " + (string.IsNullOrEmpty(unit.WORKINFO_TEMPLET_ID)?"null":"'" + unit.WORKINFO_TEMPLET_ID.Replace ("'","''") + "'")
					+ " , [COMPONENTREFERENCE] = " + (unit.COMPONENTREFERENCE==null?"''":"'" + unit.COMPONENTREFERENCE.Replace ("'","''") + "'")
					+ " , [ITEMNAME] = " + (unit.ITEMNAME==null?"''":"'" + unit.ITEMNAME.Replace ("'","''") + "'")
					+ " , [ITEMCONTENT] = " + (unit.ITEMCONTENT==null?"''":"'" + unit.ITEMCONTENT.Replace ("'","''") + "'")
					+ " , [PERIOD] = " + unit.PERIOD.ToString()
					+ " , [PERIODICAL] = " + (unit.PERIODICAL==null?"''":"'" + unit.PERIODICAL.Replace ("'","''") + "'")
                    + " , [TIMINGPERIOD] = " + unit.TIMINGPERIOD.ToString()
					+ " , [REMARK] = " + (unit.REMARK==null?"''":"'" + unit.REMARK.Replace ("'","''") + "'")
					+ " , [CLASS_ID] = " + (string.IsNullOrEmpty(unit.CLASS_ID)?"null":"'" + unit.CLASS_ID.Replace ("'","''") + "'")
					+ " where upper(WORKINFO_TEMPLET_ID) = '" + unit.WORKINFO_TEMPLET_ID.ToUpper() + "'"; 
			}
			else
			{
				unit.WORKINFO_TEMPLET_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_WORKINFO_TEMPLET] ("
					+ "[WORKINFO_TEMPLET_ID],"
					+ "[COMPONENTREFERENCE],"
					+ "[ITEMNAME],"
					+ "[ITEMCONTENT],"
					+ "[PERIOD],"
					+ "[PERIODICAL],"
                    + "[TIMINGPERIOD],"
					+ "[REMARK],"
					+ "[CLASS_ID]"
					+ ") VALUES( "
					+ " " + (string.IsNullOrEmpty(unit.WORKINFO_TEMPLET_ID)?"null":"'" + unit.WORKINFO_TEMPLET_ID.Replace ("'","''") + "'")
					+ " , " + (unit.COMPONENTREFERENCE==null?"''":"'" + unit.COMPONENTREFERENCE.Replace ("'","''") + "'")
					+ " , " + (unit.ITEMNAME==null?"''":"'" + unit.ITEMNAME.Replace ("'","''") + "'")
					+ " , " + (unit.ITEMCONTENT==null?"''":"'" + unit.ITEMCONTENT.Replace ("'","''") + "'")
					+ " ,"+ unit.PERIOD.ToString()
					+ " , " + (unit.PERIODICAL==null?"''":"'" + unit.PERIODICAL.Replace ("'","''") + "'")
                    + " ," + unit.TIMINGPERIOD.ToString()
					+ " , " + (unit.REMARK==null?"''":"'" + unit.REMARK.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.CLASS_ID)?"null":"'" + unit.CLASS_ID.Replace ("'","''") + "'")
					+ ")";
			}

			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_WORKINFO_TEMPLET中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_WORKINFO_TEMPLET对象</param>
		internal bool deleteUnit(T_WORKINFO_TEMPLET unit,out string err)
		{
			return deleteUnit(unit.WORKINFO_TEMPLET_ID,out err);
		}
		
		/// <summary>
		/// 删除数据表T_WORKINFO_TEMPLET中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_WORKINFO_TEMPLET.wORKINFO_TEMPLET_ID主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_WORKINFO_TEMPLET where "
				+ " upper(T_WORKINFO_TEMPLET.WORKINFO_TEMPLET_ID)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_WORKINFO_TEMPLET 所有数据信息.
		/// </summary>
		/// <returns>T_WORKINFO_TEMPLET DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql = "select	"
				+ "WORKINFO_TEMPLET_ID"
				+ ",COMPONENTREFERENCE"
				+ ",ITEMNAME"
				+ ",ITEMCONTENT"
				+ ",PERIOD"
				+ ",PERIODICAL"
                + ",TIMINGPERIOD"
				+ ",REMARK"
				+ ",CLASS_ID"
				+ "  from T_WORKINFO_TEMPLET ";
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
		/// 根据一个主键ID,得到 T_WORKINFO_TEMPLET 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>T_WORKINFO_TEMPLET DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql = "select "
				+ "WORKINFO_TEMPLET_ID"
				+ ",COMPONENTREFERENCE"
				+ ",ITEMNAME"
				+ ",ITEMCONTENT"
				+ ",PERIOD"
				+ ",PERIODICAL"
                + ",TIMINGPERIOD"
				+ ",REMARK"
				+ ",CLASS_ID"
				+ " from T_WORKINFO_TEMPLET "
				+ " where upper(WORKINFO_TEMPLET_ID)='" + Id.ToUpper()+"'";
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
		/// 根据t_workinfo_templet 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>t_workinfo_templet 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
		public T_WORKINFO_TEMPLET getObject(DataRow dr)
		{
			T_WORKINFO_TEMPLET unit=new T_WORKINFO_TEMPLET();
			if (null==dr)
			{
				unit.IsWrong = true;
				unit.WhyWrong = "从数据库获取信息时出错,未成功构造T_WORKINFO_TEMPLET类对象!";
				return unit;
			}
			if (DBNull.Value != dr["WORKINFO_TEMPLET_ID"])	
			    unit.WORKINFO_TEMPLET_ID=dr["WORKINFO_TEMPLET_ID"].ToString();
			if (DBNull.Value != dr["COMPONENTREFERENCE"])	
			    unit.COMPONENTREFERENCE=dr["COMPONENTREFERENCE"].ToString();
			if (DBNull.Value != dr["ITEMNAME"])	
			    unit.ITEMNAME=dr["ITEMNAME"].ToString();
			if (DBNull.Value != dr["ITEMCONTENT"])	
			    unit.ITEMCONTENT=dr["ITEMCONTENT"].ToString();
			if (DBNull.Value != dr["PERIOD"])	
			    unit.PERIOD=Convert.ToDecimal(dr["PERIOD"]);
			if (DBNull.Value != dr["PERIODICAL"])	
			    unit.PERIODICAL=dr["PERIODICAL"].ToString();
            if (DBNull.Value != dr["TIMINGPERIOD"])
                unit.PERIOD = Convert.ToDecimal(dr["TIMINGPERIOD"]);
			if (DBNull.Value != dr["REMARK"])	
			    unit.REMARK=dr["REMARK"].ToString();
			if (DBNull.Value != dr["CLASS_ID"])	
			    unit.CLASS_ID=dr["CLASS_ID"].ToString();
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个T_WORKINFO_TEMPLET对象.
		/// </summary>
		/// <param name="wORKINFO_TEMPLET_ID">wORKINFO_TEMPLET_ID</param>
		/// <returns>T_WORKINFO_TEMPLET对象</returns>
		public  T_WORKINFO_TEMPLET getObject(string Id,out string err)
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
