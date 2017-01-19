/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：SparePurchaseApplyDetailService.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/9/2
 * 标    题：数据操作类
 * 功能描述：T_SPARE_PURCHASE_APPLY_DETAIL数据操作类
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
using StorageManage.DataObject;

namespace  StorageManage.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_SPARE_PURCHASE_APPLY_DETAILService.cs
    /// </summary>
    public partial class SparePurchaseApplyDetailService
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static SparePurchaseApplyDetailService instance=new SparePurchaseApplyDetailService();
        public static SparePurchaseApplyDetailService Instance
        { 
            get
            {
                if(null==instance)
                {
                    SparePurchaseApplyDetailService.instance = new SparePurchaseApplyDetailService();
                }
                return SparePurchaseApplyDetailService.instance;
            }
        }
		private SparePurchaseApplyDetailService(){}
		#endregion
		
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();        
        string sql = ""; 
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">SparePurchaseApplyDetail对象</param>
		/// <returns>插入的对象更新</returns>	
		internal bool saveUnit(SparePurchaseApplyDetail unit,out string err)
        {
			if (unit.PURCHASE_APPLY_DETAIL_ID!=null && unit.PURCHASE_APPLY_DETAIL_ID.Length > 0) //edit
			{
				sql = "UPDATE [T_SPARE_PURCHASE_APPLY_DETAIL] SET "
					+ " [PURCHASE_APPLY_DETAIL_ID] = " + (string.IsNullOrEmpty(unit.PURCHASE_APPLY_DETAIL_ID)?"null":"'" + unit.PURCHASE_APPLY_DETAIL_ID.Replace ("'","''") + "'")
					+ " , [PURCHASE_APPLYID] = " + (string.IsNullOrEmpty(unit.PURCHASE_APPLYID)?"null":"'" + unit.PURCHASE_APPLYID.Replace ("'","''") + "'")
					+ " , [SPARE_ID] = " + (string.IsNullOrEmpty(unit.SPARE_ID)?"null":"'" + unit.SPARE_ID.Replace ("'","''") + "'")
					+ " , [SPARE_NAME] = N" + (unit.SPARE_NAME==null?"''":"'" + unit.SPARE_NAME.Replace ("'","''") + "'")
					+ " , [PARTNUMBER] = N" + (unit.PARTNUMBER==null?"''":"'" + unit.PARTNUMBER.Replace ("'","''") + "'")
					+ " , [APPLYCOUNT] = " + unit.APPLYCOUNT.ToString()
					+ " , [CONFIRMEDCOUNT] = " + unit.CONFIRMEDCOUNT.ToString()
					+ " , [REMARK] = N" + (unit.REMARK==null?"''":"'" + unit.REMARK.Replace ("'","''") + "'")
					+ " , [COMPONENT_UNIT_ID] = " + (string.IsNullOrEmpty(unit.COMPONENT_UNIT_ID)?"null":"'" + unit.COMPONENT_UNIT_ID.Replace ("'","''") + "'")
					+ " where upper(PURCHASE_APPLY_DETAIL_ID) = '" + unit.PURCHASE_APPLY_DETAIL_ID.ToUpper() + "'"; 
			}
			else
			{
				unit.PURCHASE_APPLY_DETAIL_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_SPARE_PURCHASE_APPLY_DETAIL] ("
					+ "[PURCHASE_APPLY_DETAIL_ID],"
					+ "[PURCHASE_APPLYID],"
					+ "[SPARE_ID],"
					+ "[SPARE_NAME],"
					+ "[PARTNUMBER],"
					+ "[APPLYCOUNT],"
					+ "[CONFIRMEDCOUNT],"
					+ "[REMARK],"
					+ "[COMPONENT_UNIT_ID]"
					+ ") VALUES( "
					+ " " + (string.IsNullOrEmpty(unit.PURCHASE_APPLY_DETAIL_ID)?"null":"'" + unit.PURCHASE_APPLY_DETAIL_ID.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.PURCHASE_APPLYID)?"null":"'" + unit.PURCHASE_APPLYID.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.SPARE_ID)?"null":"'" + unit.SPARE_ID.Replace ("'","''") + "'")
					+ " , N" + (unit.SPARE_NAME==null?"''":"'" + unit.SPARE_NAME.Replace ("'","''") + "'")
					+ " , N" + (unit.PARTNUMBER==null?"''":"'" + unit.PARTNUMBER.Replace ("'","''") + "'")
					+ " ,"+ unit.APPLYCOUNT.ToString()
					+ " ,"+ unit.CONFIRMEDCOUNT.ToString()
					+ " , N" + (unit.REMARK==null?"''":"'" + unit.REMARK.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.COMPONENT_UNIT_ID)?"null":"'" + unit.COMPONENT_UNIT_ID.Replace ("'","''") + "'")
					+ ")";
			}

			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_SPARE_PURCHASE_APPLY_DETAIL中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_SPARE_PURCHASE_APPLY_DETAIL对象</param>
		internal bool deleteUnit(SparePurchaseApplyDetail unit,out string err)
		{
			return deleteUnit(unit.PURCHASE_APPLY_DETAIL_ID,out err);
		}
		
		/// <summary>
		/// 删除数据表T_SPARE_PURCHASE_APPLY_DETAIL中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_SPARE_PURCHASE_APPLY_DETAIL.pURCHASE_APPLY_DETAIL_ID主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_SPARE_PURCHASE_APPLY_DETAIL where "
				+ " upper(T_SPARE_PURCHASE_APPLY_DETAIL.PURCHASE_APPLY_DETAIL_ID)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_SPARE_PURCHASE_APPLY_DETAIL 所有数据信息.
		/// </summary>
		/// <returns>T_SPARE_PURCHASE_APPLY_DETAIL DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql = "select	"
				+ "PURCHASE_APPLY_DETAIL_ID"
				+ ",PURCHASE_APPLYID"
				+ ",SPARE_ID"
				+ ",SPARE_NAME"
				+ ",PARTNUMBER"
				+ ",APPLYCOUNT"
				+ ",CONFIRMEDCOUNT"
				+ ",REMARK"
				+ ",COMPONENT_UNIT_ID"
				+ "  from T_SPARE_PURCHASE_APPLY_DETAIL ";
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
		/// 根据一个主键ID,得到 T_SPARE_PURCHASE_APPLY_DETAIL 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>SparePurchaseApplyDetail DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql = "select "
				+ "PURCHASE_APPLY_DETAIL_ID"
				+ ",PURCHASE_APPLYID"
				+ ",SPARE_ID"
				+ ",SPARE_NAME"
				+ ",PARTNUMBER"
				+ ",APPLYCOUNT"
				+ ",CONFIRMEDCOUNT"
				+ ",REMARK"
				+ ",COMPONENT_UNIT_ID"
				+ " from T_SPARE_PURCHASE_APPLY_DETAIL "
				+ " where upper(PURCHASE_APPLY_DETAIL_ID)='" + Id.ToUpper()+"'";
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
		/// 根据sparepurchaseapplydetail 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>sparepurchaseapplydetail 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
		public SparePurchaseApplyDetail getObject(DataRow dr)
		{
			SparePurchaseApplyDetail unit=new SparePurchaseApplyDetail();
			if (null==dr)
			{
				unit.IsWrong = true;
				unit.WhyWrong = "从数据库获取信息时出错,未成功构造SparePurchaseApplyDetail类对象!";
				return unit;
			}
			if (DBNull.Value != dr["PURCHASE_APPLY_DETAIL_ID"])	
			    unit.PURCHASE_APPLY_DETAIL_ID=dr["PURCHASE_APPLY_DETAIL_ID"].ToString();
			if (DBNull.Value != dr["PURCHASE_APPLYID"])	
			    unit.PURCHASE_APPLYID=dr["PURCHASE_APPLYID"].ToString();
			if (DBNull.Value != dr["SPARE_ID"])	
			    unit.SPARE_ID=dr["SPARE_ID"].ToString();
			if (DBNull.Value != dr["SPARE_NAME"])	
			    unit.SPARE_NAME=dr["SPARE_NAME"].ToString();
			if (DBNull.Value != dr["PARTNUMBER"])	
			    unit.PARTNUMBER=dr["PARTNUMBER"].ToString();
			if (DBNull.Value != dr["APPLYCOUNT"])	
			    unit.APPLYCOUNT=Convert.ToDecimal(dr["APPLYCOUNT"]);
			if (DBNull.Value != dr["CONFIRMEDCOUNT"])	
			    unit.CONFIRMEDCOUNT=Convert.ToDecimal(dr["CONFIRMEDCOUNT"]);
			if (DBNull.Value != dr["REMARK"])	
			    unit.REMARK=dr["REMARK"].ToString();
			if (DBNull.Value != dr["COMPONENT_UNIT_ID"])	
			    unit.COMPONENT_UNIT_ID=dr["COMPONENT_UNIT_ID"].ToString();
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个SparePurchaseApplyDetail对象.
		/// </summary>
		/// <param name="pURCHASE_APPLY_DETAIL_ID">pURCHASE_APPLY_DETAIL_ID</param>
		/// <returns>SparePurchaseApplyDetail对象</returns>
		public  SparePurchaseApplyDetail getObject(string Id,out string err)
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
