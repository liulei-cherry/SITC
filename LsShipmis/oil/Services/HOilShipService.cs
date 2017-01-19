/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：HOilShipService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-7-25
 * 标    题：数据操作类
 * 功能描述：T_HOIL_SHIP数据操作类
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
    /// 数据层实例化接口类 dbo.T_HOIL_SHIPService.cs
    /// </summary>
    public partial class HOilShipService
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static HOilShipService instance=new HOilShipService();
        public static HOilShipService Instance
        { 
            get
            {
                if(null==instance)
                {
                    HOilShipService.instance = new HOilShipService();
                }
                return HOilShipService.instance;
            }
        }
		private HOilShipService(){}
		#endregion
		
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();        
        string sql = ""; 
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">HOilShip对象</param>
		/// <returns>插入的对象更新</returns>	
		internal bool saveUnit(HOilShip unit,out string err)
        {
			if (unit.OIL_SHIP_ID!=null && unit.OIL_SHIP_ID.Length > 0) //edit
			{
				sql = "UPDATE [T_HOIL_SHIP] SET "
					+ " [OIL_SHIP_ID] = " + (string.IsNullOrEmpty(unit.OIL_SHIP_ID)?"null":"'" + unit.OIL_SHIP_ID.Replace ("'","''") + "'")
					+ " , [OIL_ID] = " + (string.IsNullOrEmpty(unit.OIL_ID)?"null":"'" + unit.OIL_ID.Replace ("'","''") + "'")
					+ " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ " , [ORDERNUM] = " + unit.ORDERNUM.ToString()
					+ " where upper(OIL_SHIP_ID) = '" + unit.OIL_SHIP_ID.ToUpper() + "'"; 
			}
			else
			{
				unit.OIL_SHIP_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_HOIL_SHIP] ("
					+ "[OIL_SHIP_ID],"
					+ "[OIL_ID],"
					+ "[SHIP_ID],"
					+ "[ORDERNUM]"
					+ ") VALUES( "
					+ " " + (string.IsNullOrEmpty(unit.OIL_SHIP_ID)?"null":"'" + unit.OIL_SHIP_ID.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.OIL_ID)?"null":"'" + unit.OIL_ID.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ " ,"+ unit.ORDERNUM.ToString()
					+ ")";
			}

			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_HOIL_SHIP中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_HOIL_SHIP对象</param>
		internal bool deleteUnit(HOilShip unit,out string err)
		{
			return deleteUnit(unit.OIL_SHIP_ID,out err);
		}
		
		/// <summary>
		/// 删除数据表T_HOIL_SHIP中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_HOIL_SHIP.oIL_SHIP_ID主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_HOIL_SHIP where "
				+ " upper(T_HOIL_SHIP.OIL_SHIP_ID)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_HOIL_SHIP 所有数据信息.
		/// </summary>
		/// <returns>T_HOIL_SHIP DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql = "select	"
				+ "OIL_SHIP_ID"
				+ ",OIL_ID"
				+ ",SHIP_ID"
				+ ",ORDERNUM"
				+ "  from T_HOIL_SHIP ";
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
		/// 根据一个主键ID,得到 T_HOIL_SHIP 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>HOilShip DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql = "select "
				+ "OIL_SHIP_ID"
				+ ",OIL_ID"
				+ ",SHIP_ID"
				+ ",ORDERNUM"
				+ " from T_HOIL_SHIP "
				+ " where upper(OIL_SHIP_ID)='" + Id.ToUpper()+"'";
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
		/// 根据hoilship 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>hoilship 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
		public HOilShip getObject(DataRow dr)
		{
			HOilShip unit=new HOilShip();
			if (null==dr)
			{
				unit.IsWrong = true;
				unit.WhyWrong = "从数据库获取信息时出错,未成功构造HOilShip类对象!";
				return unit;
			}
			if (DBNull.Value != dr["OIL_SHIP_ID"])	
			    unit.OIL_SHIP_ID=dr["OIL_SHIP_ID"].ToString();
			if (DBNull.Value != dr["OIL_ID"])	
			    unit.OIL_ID=dr["OIL_ID"].ToString();
			if (DBNull.Value != dr["SHIP_ID"])	
			    unit.SHIP_ID=dr["SHIP_ID"].ToString();
			if (DBNull.Value != dr["ORDERNUM"])	
			    unit.ORDERNUM=Convert.ToInt32(dr["ORDERNUM"]);
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个HOilShip对象.
		/// </summary>
		/// <param name="oIL_SHIP_ID">oIL_SHIP_ID</param>
		/// <returns>HOilShip对象</returns>
		public  HOilShip getObject(string Id,out string err)
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
