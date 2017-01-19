/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：ShipRepairEventService.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/8/2
 * 标    题：数据操作类
 * 功能描述：T_SHIP_REPAIR_EVENT数据操作类
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
using Repair.DataObject;

namespace  Repair.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_SHIP_REPAIR_EVENTService.cs
    /// </summary>
    public partial class ShipRepairEventService
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static ShipRepairEventService instance=new ShipRepairEventService();
        public static ShipRepairEventService Instance
        { 
            get
            {
                if(null==instance)
                {
                    ShipRepairEventService.instance = new ShipRepairEventService();
                }
                return ShipRepairEventService.instance;
            }
        }
		private ShipRepairEventService(){}
		#endregion
		
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();        
        string sql = ""; 
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">ShipRepairEvent对象</param>
		/// <returns>插入的对象更新</returns>	
		internal bool saveUnit(ShipRepairEvent unit,out string err)
        {
			if (unit.REPAIRID!=null && unit.REPAIRID.Length > 0) //edit
			{
				sql = "UPDATE [T_SHIP_REPAIR_EVENT] SET "
					+ " [REPAIRID] = " + (string.IsNullOrEmpty(unit.REPAIRID)?"null":"'" + unit.REPAIRID.Replace ("'","''") + "'")
					+ " , [REPAIRCODE] = " + (unit.REPAIRCODE==null?"''":"'" + unit.REPAIRCODE.Replace ("'","''") + "'")
					+ " , [REPAIRPORT] = " + (unit.REPAIRPORT==null?"''":"'" + unit.REPAIRPORT.Replace ("'","''") + "'")
					+ " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ " , [ARRANGED] = " + unit.ARRANGED.ToString()
					+ " , [ARRANGEDPERSON] = " + (unit.ARRANGEDPERSON==null?"''":"'" + unit.ARRANGEDPERSON.Replace ("'","''") + "'")
					+ " , [SHIPAFFIRMANT] = " + (unit.SHIPAFFIRMANT==null?"''":"'" + unit.SHIPAFFIRMANT.Replace ("'","''") + "'")
					+ " , [COMPAFFIRMANT] = " + (unit.COMPAFFIRMANT==null?"''":"'" + unit.COMPAFFIRMANT.Replace ("'","''") + "'")
                    + " , [REPAIRDATE] = " + dbOperation.DbToDate(unit.REPAIRDATE)
					+ " , [SERVICEPROVIDER] = " + (unit.SERVICEPROVIDER==null?"null":"'" + unit.SERVICEPROVIDER.Replace ("'","''") + "'")
                    + " , [COMPLETEDATE] = " + dbOperation.DbToDate(unit.COMPLETEDATE)
					+ " , [REMARK] = " + (unit.REMARK==null?"''":"'" + unit.REMARK.Replace ("'","''") + "'")
					+ " where upper(REPAIRID) = '" + unit.REPAIRID.ToUpper() + "'"; 
			}
			else
			{
				unit.REPAIRID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_SHIP_REPAIR_EVENT] ("
					+ "[REPAIRID],"
					+ "[REPAIRCODE],"
					+ "[REPAIRPORT],"
					+ "[SHIP_ID],"
					+ "[ARRANGED],"
					+ "[ARRANGEDPERSON],"
					+ "[SHIPAFFIRMANT],"
					+ "[COMPAFFIRMANT],"
					+ "[REPAIRDATE],"
					+ "[SERVICEPROVIDER],"
					+ "[COMPLETEDATE],"
					+ "[REMARK]"
					+ ") VALUES( "
					+ " " + (string.IsNullOrEmpty(unit.REPAIRID)?"null":"'" + unit.REPAIRID.Replace ("'","''") + "'")
					+ " , " + (unit.REPAIRCODE==null?"''":"'" + unit.REPAIRCODE.Replace ("'","''") + "'")
					+ " , " + (unit.REPAIRPORT==null?"''":"'" + unit.REPAIRPORT.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ " ,"+ unit.ARRANGED.ToString()
					+ " , " + (unit.ARRANGEDPERSON==null?"''":"'" + unit.ARRANGEDPERSON.Replace ("'","''") + "'")
					+ " , " + (unit.SHIPAFFIRMANT==null?"''":"'" + unit.SHIPAFFIRMANT.Replace ("'","''") + "'")
					+ " , " + (unit.COMPAFFIRMANT==null?"''":"'" + unit.COMPAFFIRMANT.Replace ("'","''") + "'")
					+ " ," + dbOperation.DbToDate(unit.REPAIRDATE)
					+ " , " + (unit.SERVICEPROVIDER==null?"null":"'" + unit.SERVICEPROVIDER.Replace ("'","''") + "'")
					+ " ," + dbOperation.DbToDate(unit.COMPLETEDATE)
					+ " , " + (unit.REMARK==null?"''":"'" + unit.REMARK.Replace ("'","''") + "'")
					+ ")";
			}

			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_SHIP_REPAIR_EVENT中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_SHIP_REPAIR_EVENT对象</param>
		internal bool deleteUnit(ShipRepairEvent unit,out string err)
		{
			return deleteUnit(unit.REPAIRID,out err);
		}
		
		/// <summary>
		/// 删除数据表T_SHIP_REPAIR_EVENT中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_SHIP_REPAIR_EVENT.rEPAIRID主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_SHIP_REPAIR_EVENT where "
				+ " upper(T_SHIP_REPAIR_EVENT.REPAIRID)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_SHIP_REPAIR_EVENT 所有数据信息.
		/// </summary>
		/// <returns>T_SHIP_REPAIR_EVENT DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql = "select	"
				+ "REPAIRID"
				+ ",REPAIRCODE"
				+ ",REPAIRPORT"
				+ ",SHIP_ID"
				+ ",ARRANGED"
				+ ",ARRANGEDPERSON"
				+ ",SHIPAFFIRMANT"
				+ ",COMPAFFIRMANT"
				+ ",REPAIRDATE"
				+ ",SERVICEPROVIDER"
				+ ",COMPLETEDATE"
				+ ",REMARK"
				+ "  from T_SHIP_REPAIR_EVENT ";
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
		/// 根据一个主键ID,得到 T_SHIP_REPAIR_EVENT 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>ShipRepairEvent DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql = "select "
				+ "REPAIRID"
				+ ",REPAIRCODE"
				+ ",REPAIRPORT"
				+ ",SHIP_ID"
				+ ",ARRANGED"
				+ ",ARRANGEDPERSON"
				+ ",SHIPAFFIRMANT"
				+ ",COMPAFFIRMANT"
				+ ",REPAIRDATE"
				+ ",SERVICEPROVIDER"
				+ ",COMPLETEDATE"
				+ ",REMARK"
				+ " from T_SHIP_REPAIR_EVENT "
				+ " where upper(REPAIRID)='" + Id.ToUpper()+"'";
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
		/// 根据shiprepairevent 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>shiprepairevent 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
		public ShipRepairEvent getObject(DataRow dr)
		{
			ShipRepairEvent unit=new ShipRepairEvent();
			if (null==dr)
			{
				unit.IsWrong = true;
				unit.WhyWrong = "从数据库获取信息时出错,未成功构造ShipRepairEvent类对象!";
				return unit;
			}
			if (DBNull.Value != dr["REPAIRID"])	
			    unit.REPAIRID=dr["REPAIRID"].ToString();
			if (DBNull.Value != dr["REPAIRCODE"])	
			    unit.REPAIRCODE=dr["REPAIRCODE"].ToString();
			if (DBNull.Value != dr["REPAIRPORT"])	
			    unit.REPAIRPORT=dr["REPAIRPORT"].ToString();
			if (DBNull.Value != dr["SHIP_ID"])	
			    unit.SHIP_ID=dr["SHIP_ID"].ToString();
			if (DBNull.Value != dr["ARRANGED"])	
			    unit.ARRANGED=Convert.ToDecimal(dr["ARRANGED"]);
			if (DBNull.Value != dr["ARRANGEDPERSON"])	
			    unit.ARRANGEDPERSON=dr["ARRANGEDPERSON"].ToString();
			if (DBNull.Value != dr["SHIPAFFIRMANT"])	
			    unit.SHIPAFFIRMANT=dr["SHIPAFFIRMANT"].ToString();
			if (DBNull.Value != dr["COMPAFFIRMANT"])	
			    unit.COMPAFFIRMANT=dr["COMPAFFIRMANT"].ToString();
			if (DBNull.Value != dr["REPAIRDATE"])	
                unit.REPAIRDATE=(DateTime)dr["REPAIRDATE"];
			if (DBNull.Value != dr["SERVICEPROVIDER"])	
			    unit.SERVICEPROVIDER=dr["SERVICEPROVIDER"].ToString();
			if (DBNull.Value != dr["COMPLETEDATE"])	
                unit.COMPLETEDATE=(DateTime)dr["COMPLETEDATE"];
			if (DBNull.Value != dr["REMARK"])	
			    unit.REMARK=dr["REMARK"].ToString();
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个ShipRepairEvent对象.
		/// </summary>
		/// <param name="rEPAIRID">rEPAIRID</param>
		/// <returns>ShipRepairEvent对象</returns>
		public  ShipRepairEvent getObject(string Id,out string err)
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
