/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：HOilOrderDetailService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-8-12
 * 标    题：数据操作类
 * 功能描述：T_HOIL_ORDER_DETAIL数据操作类
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
    /// 数据层实例化接口类 dbo.T_HOIL_ORDER_DETAILService.cs
    /// </summary>
    public partial class HOilOrderDetailService
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static HOilOrderDetailService instance=new HOilOrderDetailService();
        public static HOilOrderDetailService Instance
        { 
            get
            {
                if(null==instance)
                {
                    HOilOrderDetailService.instance = new HOilOrderDetailService();
                }
                return HOilOrderDetailService.instance;
            }
        }
		private HOilOrderDetailService(){}
		#endregion
		
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();        
        string sql = ""; 
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">HOilOrderDetail对象</param>
		/// <returns>插入的对象更新</returns>	
		internal bool saveUnit(HOilOrderDetail unit,out string err)
        {
			if (unit.ORDER_DETAIL_ID!=null && unit.ORDER_DETAIL_ID.Length > 0) //edit
			{
				sql = "UPDATE [T_HOIL_ORDER_DETAIL] SET "
					+ " [ORDER_DETAIL_ID] = " + (string.IsNullOrEmpty(unit.ORDER_DETAIL_ID)?"null":"'" + unit.ORDER_DETAIL_ID.Replace ("'","''") + "'")
					+ " , [ORDER_ID] = " + (string.IsNullOrEmpty(unit.ORDER_ID)?"null":"'" + unit.ORDER_ID.Replace ("'","''") + "'")
					+ " , [OIL_ID] = " + (string.IsNullOrEmpty(unit.OIL_ID)?"null":"'" + unit.OIL_ID.Replace ("'","''") + "'")
					+ " , [NUM] = " + unit.NUM.ToString()
					+ " , [CURRENCY_ID] = " + (string.IsNullOrEmpty(unit.CURRENCY_ID)?"null":"'" + unit.CURRENCY_ID.Replace ("'","''") + "'")
					+ " , [AMOUNT] = " + unit.AMOUNT.ToString()
					+ " where upper(ORDER_DETAIL_ID) = '" + unit.ORDER_DETAIL_ID.ToUpper() + "'"; 
			}
			else
			{
				unit.ORDER_DETAIL_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_HOIL_ORDER_DETAIL] ("
					+ "[ORDER_DETAIL_ID],"
					+ "[ORDER_ID],"
					+ "[OIL_ID],"
					+ "[NUM],"
					+ "[CURRENCY_ID],"
					+ "[AMOUNT]"
					+ ") VALUES( "
					+ " " + (string.IsNullOrEmpty(unit.ORDER_DETAIL_ID)?"null":"'" + unit.ORDER_DETAIL_ID.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.ORDER_ID)?"null":"'" + unit.ORDER_ID.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.OIL_ID)?"null":"'" + unit.OIL_ID.Replace ("'","''") + "'")
					+ " ,"+ unit.NUM.ToString()
					+ " , " + (string.IsNullOrEmpty(unit.CURRENCY_ID)?"null":"'" + unit.CURRENCY_ID.Replace ("'","''") + "'")
					+ " ,"+ unit.AMOUNT.ToString()
					+ ")";
			}

			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_HOIL_ORDER_DETAIL中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_HOIL_ORDER_DETAIL对象</param>
		internal bool deleteUnit(HOilOrderDetail unit,out string err)
		{
			return deleteUnit(unit.ORDER_DETAIL_ID,out err);
		}
		
		/// <summary>
		/// 删除数据表T_HOIL_ORDER_DETAIL中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_HOIL_ORDER_DETAIL.oRDER_DETAIL_ID主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_HOIL_ORDER_DETAIL where "
				+ " upper(T_HOIL_ORDER_DETAIL.ORDER_DETAIL_ID)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_HOIL_ORDER_DETAIL 所有数据信息.
		/// </summary>
		/// <returns>T_HOIL_ORDER_DETAIL DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql = "select	"
				+ "ORDER_DETAIL_ID"
				+ ",ORDER_ID"
				+ ",OIL_ID"
				+ ",NUM"
				+ ",CURRENCY_ID"
				+ ",AMOUNT"
				+ "  from T_HOIL_ORDER_DETAIL ";
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
		/// 根据一个主键ID,得到 T_HOIL_ORDER_DETAIL 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>HOilOrderDetail DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql = "select "
				+ "ORDER_DETAIL_ID"
				+ ",ORDER_ID"
				+ ",OIL_ID"
				+ ",NUM"
				+ ",CURRENCY_ID"
				+ ",AMOUNT"
				+ " from T_HOIL_ORDER_DETAIL "
				+ " where upper(ORDER_DETAIL_ID)='" + Id.ToUpper()+"'";
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
		/// 根据hoilorderdetail 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>hoilorderdetail 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
		public HOilOrderDetail getObject(DataRow dr)
		{
			HOilOrderDetail unit=new HOilOrderDetail();
			if (null==dr)
			{
				unit.IsWrong = true;
				unit.WhyWrong = "从数据库获取信息时出错,未成功构造HOilOrderDetail类对象!";
				return unit;
			}
			if (DBNull.Value != dr["ORDER_DETAIL_ID"])	
			    unit.ORDER_DETAIL_ID=dr["ORDER_DETAIL_ID"].ToString();
			if (DBNull.Value != dr["ORDER_ID"])	
			    unit.ORDER_ID=dr["ORDER_ID"].ToString();
			if (DBNull.Value != dr["OIL_ID"])	
			    unit.OIL_ID=dr["OIL_ID"].ToString();
			if (DBNull.Value != dr["NUM"])	
			    unit.NUM=Convert.ToDecimal(dr["NUM"]);
			if (DBNull.Value != dr["CURRENCY_ID"])	
			    unit.CURRENCY_ID=dr["CURRENCY_ID"].ToString();
			if (DBNull.Value != dr["AMOUNT"])	
			    unit.AMOUNT=Convert.ToDecimal(dr["AMOUNT"]);
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个HOilOrderDetail对象.
		/// </summary>
		/// <param name="oRDER_DETAIL_ID">oRDER_DETAIL_ID</param>
		/// <returns>HOilOrderDetail对象</returns>
		public  HOilOrderDetail getObject(string Id,out string err)
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
