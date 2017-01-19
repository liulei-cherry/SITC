/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：HOilApplyDetailService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-7-29
 * 标    题：数据操作类
 * 功能描述：T_HOIL_APPLY_DETAIL数据操作类
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
    /// 数据层实例化接口类 dbo.T_HOIL_APPLY_DETAILService.cs
    /// </summary>
    public partial class HOilApplyDetailService
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static HOilApplyDetailService instance=new HOilApplyDetailService();
        public static HOilApplyDetailService Instance
        { 
            get
            {
                if(null==instance)
                {
                    HOilApplyDetailService.instance = new HOilApplyDetailService();
                }
                return HOilApplyDetailService.instance;
            }
        }
		private HOilApplyDetailService(){}
		#endregion
		
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();        
        string sql = ""; 
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">HOilApplyDetail对象</param>
		/// <returns>插入的对象更新</returns>	
		internal bool saveUnit(HOilApplyDetail unit,out string err)
        {
			if (unit.APPLY_DETAIL_ID!=null && unit.APPLY_DETAIL_ID.Length > 0) //edit
			{
				sql = "UPDATE [T_HOIL_APPLY_DETAIL] SET "
					+ " [APPLY_DETAIL_ID] = " + (string.IsNullOrEmpty(unit.APPLY_DETAIL_ID)?"null":"'" + unit.APPLY_DETAIL_ID.Replace ("'","''") + "'")
					+ " , [APPLY_ID] = " + (string.IsNullOrEmpty(unit.APPLY_ID)?"null":"'" + unit.APPLY_ID.Replace ("'","''") + "'")
					+ " , [OIL_ID] = " + (string.IsNullOrEmpty(unit.OIL_ID)?"null":"'" + unit.OIL_ID.Replace ("'","''") + "'")
					+ " , [NUM] = " + unit.NUM.ToString()
					+ " , [REMARK] = " + (unit.REMARK==null?"''":"'" + unit.REMARK.Replace ("'","''") + "'")
					+ " , [CURRENCY_ID] = " + (string.IsNullOrEmpty(unit.CURRENCY_ID)?"null":"'" + unit.CURRENCY_ID.Replace ("'","''") + "'")
					+ " , [AMOUNT] = " + unit.AMOUNT.ToString()
					+ " where upper(APPLY_DETAIL_ID) = '" + unit.APPLY_DETAIL_ID.ToUpper() + "'"; 
			}
			else
			{
				unit.APPLY_DETAIL_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_HOIL_APPLY_DETAIL] ("
					+ "[APPLY_DETAIL_ID],"
					+ "[APPLY_ID],"
					+ "[OIL_ID],"
					+ "[NUM],"
					+ "[REMARK],"
					+ "[CURRENCY_ID],"
					+ "[AMOUNT]"
					+ ") VALUES( "
					+ " " + (string.IsNullOrEmpty(unit.APPLY_DETAIL_ID)?"null":"'" + unit.APPLY_DETAIL_ID.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.APPLY_ID)?"null":"'" + unit.APPLY_ID.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.OIL_ID)?"null":"'" + unit.OIL_ID.Replace ("'","''") + "'")
					+ " ,"+ unit.NUM.ToString()
					+ " , " + (unit.REMARK==null?"''":"'" + unit.REMARK.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.CURRENCY_ID)?"null":"'" + unit.CURRENCY_ID.Replace ("'","''") + "'")
					+ " ,"+ unit.AMOUNT.ToString()
					+ ")";
			}

			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_HOIL_APPLY_DETAIL中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_HOIL_APPLY_DETAIL对象</param>
		internal bool deleteUnit(HOilApplyDetail unit,out string err)
		{
			return deleteUnit(unit.APPLY_DETAIL_ID,out err);
		}
		
		/// <summary>
		/// 删除数据表T_HOIL_APPLY_DETAIL中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_HOIL_APPLY_DETAIL.aPPLY_DETAIL_ID主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_HOIL_APPLY_DETAIL where "
				+ " upper(T_HOIL_APPLY_DETAIL.APPLY_DETAIL_ID)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_HOIL_APPLY_DETAIL 所有数据信息.
		/// </summary>
		/// <returns>T_HOIL_APPLY_DETAIL DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql = "select	"
				+ "APPLY_DETAIL_ID"
				+ ",APPLY_ID"
				+ ",OIL_ID"
				+ ",NUM"
				+ ",REMARK"
				+ ",CURRENCY_ID"
				+ ",AMOUNT"
				+ "  from T_HOIL_APPLY_DETAIL ";
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
		/// 根据一个主键ID,得到 T_HOIL_APPLY_DETAIL 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>HOilApplyDetail DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql = "select "
				+ "APPLY_DETAIL_ID"
				+ ",APPLY_ID"
				+ ",OIL_ID"
				+ ",NUM"
				+ ",REMARK"
				+ ",CURRENCY_ID"
				+ ",AMOUNT"
				+ " from T_HOIL_APPLY_DETAIL "
				+ " where upper(APPLY_DETAIL_ID)='" + Id.ToUpper()+"'";
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
		/// 根据hoilapplydetail 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>hoilapplydetail 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
		public HOilApplyDetail getObject(DataRow dr)
		{
			HOilApplyDetail unit=new HOilApplyDetail();
			if (null==dr)
			{
				unit.IsWrong = true;
				unit.WhyWrong = "从数据库获取信息时出错,未成功构造HOilApplyDetail类对象!";
				return unit;
			}
			if (DBNull.Value != dr["APPLY_DETAIL_ID"])	
			    unit.APPLY_DETAIL_ID=dr["APPLY_DETAIL_ID"].ToString();
			if (DBNull.Value != dr["APPLY_ID"])	
			    unit.APPLY_ID=dr["APPLY_ID"].ToString();
			if (DBNull.Value != dr["OIL_ID"])	
			    unit.OIL_ID=dr["OIL_ID"].ToString();
			if (DBNull.Value != dr["NUM"])	
			    unit.NUM=Convert.ToDecimal(dr["NUM"]);
			if (DBNull.Value != dr["REMARK"])	
			    unit.REMARK=dr["REMARK"].ToString();
			if (DBNull.Value != dr["CURRENCY_ID"])	
			    unit.CURRENCY_ID=dr["CURRENCY_ID"].ToString();
			if (DBNull.Value != dr["AMOUNT"])	
			    unit.AMOUNT=Convert.ToDecimal(dr["AMOUNT"]);
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个HOilApplyDetail对象.
		/// </summary>
		/// <param name="aPPLY_DETAIL_ID">aPPLY_DETAIL_ID</param>
		/// <returns>HOilApplyDetail对象</returns>
		public  HOilApplyDetail getObject(string Id,out string err)
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
