/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：HOilLuboilConsumeService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-7-25
 * 标    题：数据操作类
 * 功能描述：T_HOIL_LUBOIL_CONSUME数据操作类
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
    /// 数据层实例化接口类 dbo.T_HOIL_LUBOIL_CONSUMEService.cs
    /// </summary>
    public partial class HOilLuboilConsumeService
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static HOilLuboilConsumeService instance=new HOilLuboilConsumeService();
        public static HOilLuboilConsumeService Instance
        { 
            get
            {
                if(null==instance)
                {
                    HOilLuboilConsumeService.instance = new HOilLuboilConsumeService();
                }
                return HOilLuboilConsumeService.instance;
            }
        }
		private HOilLuboilConsumeService(){}
		#endregion
		
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();        
        string sql = ""; 
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">HOilLuboilConsume对象</param>
		/// <returns>插入的对象更新</returns>	
		internal bool saveUnit(HOilLuboilConsume unit,out string err)
        {
			if (unit.REPORT_ID!=null && unit.REPORT_ID.Length > 0) //edit
			{
				sql = "UPDATE [T_HOIL_LUBOIL_CONSUME] SET "
					+ " [REPORT_ID] = " + (string.IsNullOrEmpty(unit.REPORT_ID)?"null":"'" + unit.REPORT_ID.Replace ("'","''") + "'")
					+ " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ " , [OIL_ID] = " + (string.IsNullOrEmpty(unit.OIL_ID)?"null":"'" + unit.OIL_ID.Replace ("'","''") + "'")
					+ " , [LASTMONTH_LEFT] = " + unit.LASTMONTH_LEFT.ToString()
					+ " , [THISMONTH_ADD] = " + unit.THISMONTH_ADD.ToString()
					+ " , [THISMONTH_CONSUME] = " + unit.THISMONTH_CONSUME.ToString()
					+ " , [THISMONTH_STORE] = " + unit.THISMONTH_STORE.ToString()
					+ " , [REMARK] = " + (unit.REMARK==null?"''":"'" + unit.REMARK.Replace ("'","''") + "'")
                    + " , [RECORD_DATE] = " + dbOperation.DbToDate(unit.RECORD_DATE)
					+ " where upper(REPORT_ID) = '" + unit.REPORT_ID.ToUpper() + "'"; 
			}
			else
			{
				unit.REPORT_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_HOIL_LUBOIL_CONSUME] ("
					+ "[REPORT_ID],"
					+ "[SHIP_ID],"
					+ "[OIL_ID],"
					+ "[LASTMONTH_LEFT],"
					+ "[THISMONTH_ADD],"
					+ "[THISMONTH_CONSUME],"
					+ "[THISMONTH_STORE],"
					+ "[REMARK],"
					+ "[RECORD_DATE]"
					+ ") VALUES( "
					+ " " + (string.IsNullOrEmpty(unit.REPORT_ID)?"null":"'" + unit.REPORT_ID.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.OIL_ID)?"null":"'" + unit.OIL_ID.Replace ("'","''") + "'")
					+ " ,"+ unit.LASTMONTH_LEFT.ToString()
					+ " ,"+ unit.THISMONTH_ADD.ToString()
					+ " ,"+ unit.THISMONTH_CONSUME.ToString()
					+ " ,"+ unit.THISMONTH_STORE.ToString()
					+ " , " + (unit.REMARK==null?"''":"'" + unit.REMARK.Replace ("'","''") + "'")
					+ " ," + dbOperation.DbToDate(unit.RECORD_DATE)
					+ ")";
			}

			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_HOIL_LUBOIL_CONSUME中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_HOIL_LUBOIL_CONSUME对象</param>
		internal bool deleteUnit(HOilLuboilConsume unit,out string err)
		{
			return deleteUnit(unit.REPORT_ID,out err);
		}
		
		/// <summary>
		/// 删除数据表T_HOIL_LUBOIL_CONSUME中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_HOIL_LUBOIL_CONSUME.rEPORT_ID主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_HOIL_LUBOIL_CONSUME where "
				+ " upper(T_HOIL_LUBOIL_CONSUME.REPORT_ID)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_HOIL_LUBOIL_CONSUME 所有数据信息.
		/// </summary>
		/// <returns>T_HOIL_LUBOIL_CONSUME DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql = "select	"
				+ "REPORT_ID"
				+ ",SHIP_ID"
				+ ",OIL_ID"
				+ ",LASTMONTH_LEFT"
				+ ",THISMONTH_ADD"
				+ ",THISMONTH_CONSUME"
				+ ",THISMONTH_STORE"
				+ ",REMARK"
				+ ",RECORD_DATE"
				+ "  from T_HOIL_LUBOIL_CONSUME ";
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
		/// 根据一个主键ID,得到 T_HOIL_LUBOIL_CONSUME 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>HOilLuboilConsume DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql = "select "
				+ "REPORT_ID"
				+ ",SHIP_ID"
				+ ",OIL_ID"
				+ ",LASTMONTH_LEFT"
				+ ",THISMONTH_ADD"
				+ ",THISMONTH_CONSUME"
				+ ",THISMONTH_STORE"
				+ ",REMARK"
				+ ",RECORD_DATE"
				+ " from T_HOIL_LUBOIL_CONSUME "
				+ " where upper(REPORT_ID)='" + Id.ToUpper()+"'";
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
		/// 根据hoilluboilconsume 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>hoilluboilconsume 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
		public HOilLuboilConsume getObject(DataRow dr)
		{
			HOilLuboilConsume unit=new HOilLuboilConsume();
			if (null==dr)
			{
				unit.IsWrong = true;
				unit.WhyWrong = "从数据库获取信息时出错,未成功构造HOilLuboilConsume类对象!";
				return unit;
			}
			if (DBNull.Value != dr["REPORT_ID"])	
			    unit.REPORT_ID=dr["REPORT_ID"].ToString();
			if (DBNull.Value != dr["SHIP_ID"])	
			    unit.SHIP_ID=dr["SHIP_ID"].ToString();
			if (DBNull.Value != dr["OIL_ID"])	
			    unit.OIL_ID=dr["OIL_ID"].ToString();
			if (DBNull.Value != dr["LASTMONTH_LEFT"])	
			    unit.LASTMONTH_LEFT=Convert.ToDecimal(dr["LASTMONTH_LEFT"]);
			if (DBNull.Value != dr["THISMONTH_ADD"])	
			    unit.THISMONTH_ADD=Convert.ToDecimal(dr["THISMONTH_ADD"]);
			if (DBNull.Value != dr["THISMONTH_CONSUME"])	
			    unit.THISMONTH_CONSUME=Convert.ToDecimal(dr["THISMONTH_CONSUME"]);
			if (DBNull.Value != dr["THISMONTH_STORE"])	
			    unit.THISMONTH_STORE=Convert.ToDecimal(dr["THISMONTH_STORE"]);
			if (DBNull.Value != dr["REMARK"])	
			    unit.REMARK=dr["REMARK"].ToString();
			if (DBNull.Value != dr["RECORD_DATE"])	
                unit.RECORD_DATE=(DateTime)dr["RECORD_DATE"];
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个HOilLuboilConsume对象.
		/// </summary>
		/// <param name="rEPORT_ID">rEPORT_ID</param>
		/// <returns>HOilLuboilConsume对象</returns>
		public  HOilLuboilConsume getObject(string Id,out string err)
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
