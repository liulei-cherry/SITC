/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：ShipRunningRepairRelationService.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/8/2
 * 标    题：数据操作类
 * 功能描述：T_SHIPRUNNINGREPAIR_RELATION数据操作类
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
    /// 数据层实例化接口类 dbo.T_SHIPRUNNINGREPAIR_RELATIONService.cs
    /// </summary>
    public partial class ShipRunningRepairRelationService
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static ShipRunningRepairRelationService instance=new ShipRunningRepairRelationService();
        public static ShipRunningRepairRelationService Instance
        { 
            get
            {
                if(null==instance)
                {
                    ShipRunningRepairRelationService.instance = new ShipRunningRepairRelationService();
                }
                return ShipRunningRepairRelationService.instance;
            }
        }
		private ShipRunningRepairRelationService(){}
		#endregion
		
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();        
        string sql = ""; 
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">ShipRunningRepairRelation对象</param>
		/// <returns>插入的对象更新</returns>	
		internal bool saveUnit(ShipRunningRepairRelation unit,out string err)
        {
			if (unit.RELATIONID!=null && unit.RELATIONID.Length > 0) //edit
			{
				sql = "UPDATE [T_SHIPRUNNINGREPAIR_RELATION] SET "
					+ " [RELATIONID] = " + (string.IsNullOrEmpty(unit.RELATIONID)?"null":"'" + unit.RELATIONID.Replace ("'","''") + "'")
					+ " , [PROJECTID] = " + (string.IsNullOrEmpty(unit.PROJECTID)?"null":"'" + unit.PROJECTID.Replace ("'","''") + "'")
					+ " , [REPAIRID] = " + (string.IsNullOrEmpty(unit.REPAIRID)?"null":"'" + unit.REPAIRID.Replace ("'","''") + "'")
					+ " , [STATE] = " + unit.STATE.ToString()
					+ " , [REMARK] = " + (unit.REMARK==null?"''":"'" + unit.REMARK.Replace ("'","''") + "'")
					+ " , [SORTNO] = " + unit.SORTNO.ToString()
					+ " where upper(RELATIONID) = '" + unit.RELATIONID.ToUpper() + "'"; 
			}
			else
			{
				unit.RELATIONID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_SHIPRUNNINGREPAIR_RELATION] ("
					+ "[RELATIONID],"
					+ "[PROJECTID],"
					+ "[REPAIRID],"
					+ "[STATE],"
					+ "[REMARK],"
					+ "[SORTNO]"
					+ ") VALUES( "
					+ " " + (string.IsNullOrEmpty(unit.RELATIONID)?"null":"'" + unit.RELATIONID.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.PROJECTID)?"null":"'" + unit.PROJECTID.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.REPAIRID)?"null":"'" + unit.REPAIRID.Replace ("'","''") + "'")
					+ " ,"+ unit.STATE.ToString()
					+ " , " + (unit.REMARK==null?"''":"'" + unit.REMARK.Replace ("'","''") + "'")
					+ " ,"+ unit.SORTNO.ToString()
					+ ")";
			}

			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_SHIPRUNNINGREPAIR_RELATION中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_SHIPRUNNINGREPAIR_RELATION对象</param>
		internal bool deleteUnit(ShipRunningRepairRelation unit,out string err)
		{
			return deleteUnit(unit.RELATIONID,out err);
		}
		
		/// <summary>
		/// 删除数据表T_SHIPRUNNINGREPAIR_RELATION中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_SHIPRUNNINGREPAIR_RELATION.rELATIONID主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_SHIPRUNNINGREPAIR_RELATION where "
				+ " upper(T_SHIPRUNNINGREPAIR_RELATION.RELATIONID)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_SHIPRUNNINGREPAIR_RELATION 所有数据信息.
		/// </summary>
		/// <returns>T_SHIPRUNNINGREPAIR_RELATION DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql = "select	"
				+ "RELATIONID"
				+ ",PROJECTID"
				+ ",REPAIRID"
				+ ",STATE"
				+ ",REMARK"
				+ ",SORTNO"
				+ "  from T_SHIPRUNNINGREPAIR_RELATION ";
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
		/// 根据一个主键ID,得到 T_SHIPRUNNINGREPAIR_RELATION 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>ShipRunningRepairRelation DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql = "select "
				+ "RELATIONID"
				+ ",PROJECTID"
				+ ",REPAIRID"
				+ ",STATE"
				+ ",REMARK"
				+ ",SORTNO"
				+ " from T_SHIPRUNNINGREPAIR_RELATION "
				+ " where upper(RELATIONID)='" + Id.ToUpper()+"'";
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
		/// 根据shiprunningrepairrelation 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>shiprunningrepairrelation 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
		public ShipRunningRepairRelation getObject(DataRow dr)
		{
			ShipRunningRepairRelation unit=new ShipRunningRepairRelation();
			if (null==dr)
			{
				unit.IsWrong = true;
				unit.WhyWrong = "从数据库获取信息时出错,未成功构造ShipRunningRepairRelation类对象!";
				return unit;
			}
			if (DBNull.Value != dr["RELATIONID"])	
			    unit.RELATIONID=dr["RELATIONID"].ToString();
			if (DBNull.Value != dr["PROJECTID"])	
			    unit.PROJECTID=dr["PROJECTID"].ToString();
			if (DBNull.Value != dr["REPAIRID"])	
			    unit.REPAIRID=dr["REPAIRID"].ToString();
			if (DBNull.Value != dr["STATE"])	
			    unit.STATE=Convert.ToDecimal(dr["STATE"]);
			if (DBNull.Value != dr["REMARK"])	
			    unit.REMARK=dr["REMARK"].ToString();
			if (DBNull.Value != dr["SORTNO"])	
			    unit.SORTNO=Convert.ToDecimal(dr["SORTNO"]);
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个ShipRunningRepairRelation对象.
		/// </summary>
		/// <param name="rELATIONID">rELATIONID</param>
		/// <returns>ShipRunningRepairRelation对象</returns>
		public  ShipRunningRepairRelation getObject(string Id,out string err)
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
