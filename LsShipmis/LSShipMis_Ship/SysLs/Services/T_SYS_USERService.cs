/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：T_SYS_USERService.cs
 * 创 建 人：xxl
 * 创建时间：2009-1-15
 * 标    题：数据操作类
 * 功能描述：T_SYS_USER数据操作类
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
using LSShipMis_Ship.Common;
using LSShipMis_Ship.SysLs.BusinessClasses;
using LSShipMis_Ship.Common.Classes;
using System.Windows.Forms;
using CommonOperation.Interfaces;
using CommonOperation.Functions;

namespace LSShipMis_Ship.SysLs.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_SYS_USERService.cs
    /// </summary>
    public class T_SYS_USERService 
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static T_SYS_USERService instance=new T_SYS_USERService();
        public static T_SYS_USERService Instance
        { 
            get
            {
                if(null==instance)
                {
                    T_SYS_USERService.instance = new T_SYS_USERService();
                }
                return T_SYS_USERService.instance;
            }
        }
		#endregion
        private static IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private static IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";
        //string err = "";
		
        #region -----------实例化接口函数-----------
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">T_SYS_USER对象</param>
		/// <returns>插入的对象更新</returns>	
		public void saveUnit(T_SYS_USER unit,out string err)
        {
			if (unit.USERID!=null && unit.USERID.Length > 0) //edit
			{
				sql = "UPDATE [T_SYS_USER] SET "
					 + "[USERID] = '" + unit.USERID + "'"
					+ ","
					 + "[SHIPUSERID] = '" + unit.SHIPUSERID + "'"
					+ ","
					 + "[USERLOGINNAME] = '" + unit.USERLOGINNAME + "'"
					+ ","
					 + "[USERLOGINPASS] = '" + unit.USERLOGINPASS + "'"
					+ ","
					+ "[SUPPERUSSER] = " + unit.SUPPERUSSER
					+ ","
					 + "[creator] = '" + unit.creator + "'"
					+ ","
                       + "[createtime] = " + dbOperation.DbToDate(unit.createtime)
					+ ","
                       + "[updatetime] = " + dbOperation.DbToDate(unit.updatetime)
				+ " where upper(USERID) = '" + unit.USERID.ToUpper() + "'"; 
			}
			else
			{
                unit.USERID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_SYS_USER] ("
									  + "[USERID]"
				 + ","
					  + "[SHIPUSERID]"
				 + ","
					  + "[USERLOGINNAME]"
				 + ","
					  + "[USERLOGINPASS]"
				 + ","
					  + "[SUPPERUSSER]"
				 + ","
					  + "[creator]"
				 + ","
					  + "[createtime]"
				 + ","
					  + "[updatetime]"
				+ ") VALUES( "
									  + " '" + unit.USERID + "'"
				 + ","
					  + " '" + unit.SHIPUSERID + "'"
				 + ","
					  + " '" + unit.USERLOGINNAME + "'"
				 + ","
					  + " '" + unit.USERLOGINPASS + "'"
				 + ","
					+ unit.SUPPERUSSER
				 + ","
					  + " '" + unit.creator + "'"
				 + ","
                      + dbOperation.DbToDate(unit.createtime)
				 + ","
                      + dbOperation.DbToDate(unit.updatetime)
				+ ")";
			}

			dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_SYS_USER中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_SYS_USER对象</param>
		public void deleteUnit(T_SYS_USER unit,out string err)
		{
			deleteUnit(unit.USERID,out err);
		}
		
		/// <summary>
		/// 删除数据表T_SYS_USER中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_SYS_USER.uSERID主键</param>
		public void deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_SYS_USER where "
				+ " upper(T_SYS_USER.USERID)='" + unitid.ToUpper()+ "'";
			dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_SYS_USER 所有数据信息.
		/// </summary>
		/// <returns>T_SYS_USER DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql="select "
								+ "USERID"
				 + "," 
				+ "SHIPUSERID"
				 + "," 
				+ "USERLOGINNAME"
				 + "," 
				+ "USERLOGINPASS"
				 + "," 
				+ "SUPPERUSSER"
				 + "," 
				+ "creator"
				 + "," 
				+ "createtime"
				 + "," 
				+ "updatetime"
				 + "  from T_SYS_USER ";
			return dbAccess.GetDataTable(sql, out err);
		}
		/// <summary>
		/// 根据一个主键ID,得到 T_SYS_USER 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>T_SYS_USER DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql="select "
								+ "USERID"
				 + "," 
				+ "SHIPUSERID"
				 + "," 
				+ "USERLOGINNAME"
				 + "," 
				+ "USERLOGINPASS"
				 + "," 
				+ "SUPPERUSSER"
				 + "," 
				+ "creator"
				 + "," 
				+ "createtime"
				 + "," 
				+ "updatetime"
				+ " from T_SYS_USER "
				+ " where upper(USERID)='" + Id.ToUpper()+"'";
			return dbAccess.GetDataTable(sql, out err);
		}
        /// <summary>
		/// 根据t_sys_user 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>t_sys_user 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBoxEx.Show(o);
		public T_SYS_USER getObject(DataRow dr)
		{
			T_SYS_USER unit=new T_SYS_USER();
			if (null==dr) return null;
			if (DBNull.Value != dr["USERID"])	
			    unit.USERID=dr["USERID"].ToString();
			if (DBNull.Value != dr["SHIPUSERID"])	
			    unit.SHIPUSERID=dr["SHIPUSERID"].ToString();
			if (DBNull.Value != dr["USERLOGINNAME"])	
			    unit.USERLOGINNAME=dr["USERLOGINNAME"].ToString();
			if (DBNull.Value != dr["USERLOGINPASS"])	
			    unit.USERLOGINPASS=dr["USERLOGINPASS"].ToString();
			if (DBNull.Value != dr["SUPPERUSSER"])	
			    unit.SUPPERUSSER=Convert.ToDecimal(dr["SUPPERUSSER"]);
			if (DBNull.Value != dr["creator"])	
			    unit.creator=dr["creator"].ToString();
			if (DBNull.Value != dr["createtime"])	
                unit.createtime=(DateTime)dr["createtime"];
			if (DBNull.Value != dr["updatetime"])	
                unit.updatetime=(DateTime)dr["updatetime"];
			
			return unit;
		}
		/// <summary>
		/// 根据t_sys_user 的DataGridView的DataGridViewRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataGridViewRow对象</param>
		/// <returns>t_sys_user 数据实体</returns>
		///从DataGridView获取当前选定DataGridViewRow的方法.
		///DataGridViewRow dr=dataGridView.Rows[e.RowIndex];
        ///string o = dr.Cells["taskbegintime"].Value.ToString();
        ///MessageBoxEx.Show(o);
		public T_SYS_USER getObject(DataGridViewRow dr)
		{
			T_SYS_USER unit=new T_SYS_USER();
			if (null==dr) return null;
			if (DBNull.Value != dr.Cells["USERID"].Value)	
			    unit.USERID=dr.Cells["USERID"].Value.ToString();
			if (DBNull.Value != dr.Cells["SHIPUSERID"].Value)	
			    unit.SHIPUSERID=dr.Cells["SHIPUSERID"].Value.ToString();
			if (DBNull.Value != dr.Cells["USERLOGINNAME"].Value)	
			    unit.USERLOGINNAME=dr.Cells["USERLOGINNAME"].Value.ToString();
			if (DBNull.Value != dr.Cells["USERLOGINPASS"].Value)	
			    unit.USERLOGINPASS=dr.Cells["USERLOGINPASS"].Value.ToString();
			if (DBNull.Value != dr.Cells["SUPPERUSSER"].Value)	
			    unit.SUPPERUSSER=Convert.ToDecimal(dr.Cells["SUPPERUSSER"].Value);
			if (DBNull.Value != dr.Cells["creator"].Value)	
			    unit.creator=dr.Cells["creator"].Value.ToString();
			if (DBNull.Value != dr.Cells["createtime"].Value)	
                unit.createtime=Convert.ToDateTime(dr.Cells["createtime"].Value);
			if (DBNull.Value != dr.Cells["updatetime"].Value)	
                unit.updatetime=Convert.ToDateTime(dr.Cells["updatetime"].Value);
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个T_SYS_USER对象.
		/// </summary>
		/// <param name="uSERID">uSERID</param>
		/// <returns>T_SYS_USER对象</returns>
		public  T_SYS_USER getObject(string Id,out string err)
		{
			DataTable dt=getInfo(Id,out err);
			if(dt!=null && dt.Rows.Count>0) return getObject(dt.Rows[0]);
			return null;
		}

        public DataTable GetSysUser(string name)
        {
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.

            sSql += "select ";
            sSql += "a.userid,";
            sSql += "a.shipuserid,";
            sSql += "b.username,";
            sSql += "a.userloginname,";
            sSql += "a.creator ";
            sSql += "from t_sys_user a ";
            sSql += "inner join t_ship_user b on a.shipuserid=b.shipuserid ";
            sSql += "where b.username <> '超级用户'  and b.username ='" + name + "'";

            dtb = dbAccess.GetDataTable(sSql, out err);
            return dtb;
        }

		#endregion
		#endregion
    }
}
