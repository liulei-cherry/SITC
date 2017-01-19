/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：HOilService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-8-1
 * 标    题：数据操作类
 * 功能描述：T_HOIL数据操作类
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
    /// 数据层实例化接口类 dbo.T_HOILService.cs
    /// </summary>
    public partial class HOilService
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static HOilService instance=new HOilService();
        public static HOilService Instance
        { 
            get
            {
                if(null==instance)
                {
                    HOilService.instance = new HOilService();
                }
                return HOilService.instance;
            }
        }
		private HOilService(){}
		#endregion
		
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();        
        string sql = ""; 
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">HOil对象</param>
		/// <returns>插入的对象更新</returns>	
		internal bool saveUnit(HOil unit,out string err)
        {
			if (unit.OIL_ID!=null && unit.OIL_ID.Length > 0) //edit
			{
				sql = "UPDATE [T_HOIL] SET "
					+ " [OIL_ID] = " + (string.IsNullOrEmpty(unit.OIL_ID)?"null":"'" + unit.OIL_ID.Replace ("'","''") + "'")
					+ " , [TRADEMARK] = " + (unit.TRADEMARK==null?"''":"'" + unit.TRADEMARK.Replace ("'","''") + "'")
					+ " , [OIL_NAME] = " + (unit.OIL_NAME==null?"''":"'" + unit.OIL_NAME.Replace ("'","''") + "'")
					+ " , [OIL_CODE] = " + (unit.OIL_CODE==null?"''":"'" + unit.OIL_CODE.Replace ("'","''") + "'")
					+ " , [OIL_TYPE] = " + (unit.OIL_TYPE==null?"''":"'" + unit.OIL_TYPE.Replace ("'","''") + "'")
					+ " , [LOIL_TYPE] = " + (unit.LOIL_TYPE==null?"''":"'" + unit.LOIL_TYPE.Replace ("'","''") + "'")
					+ " , [ORDERNUM] = " + unit.ORDERNUM.ToString()
					+ " where upper(OIL_ID) = '" + unit.OIL_ID.ToUpper() + "'"; 
			}
			else
			{
				unit.OIL_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_HOIL] ("
					+ "[OIL_ID],"
					+ "[TRADEMARK],"
					+ "[OIL_NAME],"
					+ "[OIL_CODE],"
					+ "[OIL_TYPE],"
					+ "[LOIL_TYPE],"
					+ "[ORDERNUM]"
					+ ") VALUES( "
					+ " " + (string.IsNullOrEmpty(unit.OIL_ID)?"null":"'" + unit.OIL_ID.Replace ("'","''") + "'")
					+ " , " + (unit.TRADEMARK==null?"''":"'" + unit.TRADEMARK.Replace ("'","''") + "'")
					+ " , " + (unit.OIL_NAME==null?"''":"'" + unit.OIL_NAME.Replace ("'","''") + "'")
					+ " , " + (unit.OIL_CODE==null?"''":"'" + unit.OIL_CODE.Replace ("'","''") + "'")
					+ " , " + (unit.OIL_TYPE==null?"''":"'" + unit.OIL_TYPE.Replace ("'","''") + "'")
					+ " , " + (unit.LOIL_TYPE==null?"''":"'" + unit.LOIL_TYPE.Replace ("'","''") + "'")
					+ " ,"+ unit.ORDERNUM.ToString()
					+ ")";
			}

			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_HOIL中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_HOIL对象</param>
		internal bool deleteUnit(HOil unit,out string err)
		{
			return deleteUnit(unit.OIL_ID,out err);
		}
		
		/// <summary>
		/// 删除数据表T_HOIL中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_HOIL.oIL_ID主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_HOIL where "
				+ " upper(T_HOIL.OIL_ID)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_HOIL 所有数据信息.
		/// </summary>
		/// <returns>T_HOIL DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql = "select	"
				+ "OIL_ID"
				+ ",TRADEMARK"
				+ ",OIL_NAME"
				+ ",OIL_CODE"
				+ ",OIL_TYPE"
				+ ",LOIL_TYPE"
				+ ",ORDERNUM"
				+ "  from T_HOIL ";
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
		/// 根据一个主键ID,得到 T_HOIL 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>HOil DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql = "select "
				+ "OIL_ID"
				+ ",TRADEMARK"
				+ ",OIL_NAME"
				+ ",OIL_CODE"
				+ ",OIL_TYPE"
				+ ",LOIL_TYPE"
				+ ",ORDERNUM"
				+ " from T_HOIL "
				+ " where upper(OIL_ID)='" + Id.ToUpper()+"'";
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
		/// 根据hoil 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>hoil 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
		public HOil getObject(DataRow dr)
		{
			HOil unit=new HOil();
			if (null==dr)
			{
				unit.IsWrong = true;
				unit.WhyWrong = "从数据库获取信息时出错,未成功构造HOil类对象!";
				return unit;
			}
			if (DBNull.Value != dr["OIL_ID"])	
			    unit.OIL_ID=dr["OIL_ID"].ToString();
			if (DBNull.Value != dr["TRADEMARK"])	
			    unit.TRADEMARK=dr["TRADEMARK"].ToString();
			if (DBNull.Value != dr["OIL_NAME"])	
			    unit.OIL_NAME=dr["OIL_NAME"].ToString();
			if (DBNull.Value != dr["OIL_CODE"])	
			    unit.OIL_CODE=dr["OIL_CODE"].ToString();
			if (DBNull.Value != dr["OIL_TYPE"])	
			    unit.OIL_TYPE=dr["OIL_TYPE"].ToString();
			if (DBNull.Value != dr["LOIL_TYPE"])	
			    unit.LOIL_TYPE=dr["LOIL_TYPE"].ToString();
			if (DBNull.Value != dr["ORDERNUM"])	
			    unit.ORDERNUM=Convert.ToInt32(dr["ORDERNUM"]);
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个HOil对象.
		/// </summary>
		/// <param name="oIL_ID">oIL_ID</param>
		/// <returns>HOil对象</returns>
		public  HOil getObject(string Id,out string err)
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
