/****************************************************************************************************
 * Copyright (C) 2008 澶ц繛闄嗘捣绉戞妧鏈夐檺鍏徃 鐗堟潈鎵€鏈?
 * 鏂?浠?鍚嶏細T_SYS_USERService.cs
 * 鍒?寤?浜猴細xxl
 * 鍒涘缓鏃堕棿锛?009-1-15
 * 鏍?   棰橈細鏁版嵁鎿嶄綔绫?
 * 鍔熻兘鎻忚堪锛歍_SYS_USER鏁版嵁鎿嶄綔绫?
 * 淇?鏀?浜猴細
 * 淇敼鏃堕棿锛?
 * 淇敼鍐呭锛?
 ****************************************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using LSShipMis_Land.Common;
using LSShipMis_Land.SysLs.BusinessClasses;
using LSShipMis_Land.Common.Classes;
using System.Windows.Forms;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
namespace LSShipMis_Land.SysLs.Services
{
    /// <summary>
    /// 鏁版嵁灞傚疄渚嬪寲鎺ュ彛绫?dbo.T_SYS_USERService.cs
    /// </summary>
    public class T_SYS_USERService 
    {
		#region 鏋勯€犲嚱鏁?
		/// <summary>
		/// 闈欐€佸疄渚嬪璞?
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
        string sql = "";
       // string err = "";
		 
        #region -----------瀹炰緥鍖栨帴鍙ｅ嚱鏁?----------
		
		#region 娣诲姞鏇存柊鍒犻櫎
		
		/// <summary>
		/// 鍚戞暟鎹簱涓繚瀛樹竴鏉℃柊璁板綍銆?
		/// </summary>
		/// <param name="unit">T_SYS_USER瀵硅薄</param>
		/// <returns>鎻掑叆鐨勫璞℃洿鏂?/returns>	
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
                       + "[createtime] = " + LSShipMis_Land.Common.EnvironmentParm.DbToDate(unit.createtime)
					+ ","
                       + "[updatetime] = " + LSShipMis_Land.Common.EnvironmentParm.DbToDate(unit.updatetime)
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
					  + LSShipMis_Land.Common.EnvironmentParm.DbToDate(unit.createtime)
				 + ","
					  + LSShipMis_Land.Common.EnvironmentParm.DbToDate(unit.updatetime)
				+ ")";
			}

			dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 鍒犻櫎鏁版嵁琛═_SYS_USER涓殑瀵硅薄.
		/// </summary>
	   /// <param name="unit">瑕佸垹闄ょ殑T_SYS_USER瀵硅薄</param>
		public void deleteUnit(T_SYS_USER unit,out string err)
		{
			deleteUnit(unit.USERID,out err);
		}
		
		/// <summary>
		/// 鍒犻櫎鏁版嵁琛═_SYS_USER涓殑涓€鏉¤褰?
		/// </summary>
	   /// <param name="unit">瑕佸垹闄ょ殑T_SYS_USER.uSERID涓婚敭</param>
		public void deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_SYS_USER where "
				+ " upper(T_SYS_USER.USERID)='" + unitid.ToUpper()+ "'";
			dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 鏁版嵁瀹炰綋
		/// <summary>
		/// 寰楀埌  T_SYS_USER 鎵€鏈夋暟鎹俊鎭?
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
		/// 鏍规嵁涓€涓富閿甀D,寰楀埌 T_SYS_USER 鐨凞ataTable
		/// </summary>
		/// <param name="Id">涓婚敭ID</param>
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
		/// 鏍规嵁t_sys_user 鐨凞ataRow灏佽瀵硅薄.
		/// </summary>
		/// <param name="dr">涓€涓€夊畾鐨凞ataRow瀵硅薄</param>
		/// <returns>t_sys_user 鏁版嵁瀹炰綋</returns>
		///浠嶥ataGridView鐨勬暟鎹簮鑾峰彇褰撳墠閫夊畾DataRow鐨勬柟娉?
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
		/// 鏍规嵁t_sys_user 鐨凞ataGridView鐨凞ataGridViewRow灏佽瀵硅薄.
		/// </summary>
		/// <param name="dr">涓€涓€夊畾鐨凞ataGridViewRow瀵硅薄</param>
		/// <returns>t_sys_user 鏁版嵁瀹炰綋</returns>
		///浠嶥ataGridView鑾峰彇褰撳墠閫夊畾DataGridViewRow鐨勬柟娉?
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
		
		#endregion
		#endregion
    }
}
