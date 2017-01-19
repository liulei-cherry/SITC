/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：MaterialPurchaseApplyDetailService.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/9/18
 * 标    题：数据操作类
 * 功能描述：T_MATERIAL_PURCHASE_APPLY_DETAIL数据操作类
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
    /// 数据层实例化接口类 dbo.T_MATERIAL_PURCHASE_APPLY_DETAILService.cs
    /// </summary>
    public partial class MaterialPurchaseApplyDetailService
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static MaterialPurchaseApplyDetailService instance=new MaterialPurchaseApplyDetailService();
        public static MaterialPurchaseApplyDetailService Instance
        { 
            get
            {
                if(null==instance)
                {
                    MaterialPurchaseApplyDetailService.instance = new MaterialPurchaseApplyDetailService();
                }
                return MaterialPurchaseApplyDetailService.instance;
            }
        }
		private MaterialPurchaseApplyDetailService(){}
		#endregion
		
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();        
        string sql = ""; 
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">MaterialPurchaseApplyDetail对象</param>
		/// <returns>插入的对象更新</returns>	
		internal bool saveUnit(MaterialPurchaseApplyDetail unit,out string err)
        {
			if (unit.PURCHASE_APPLY_DETAIL_ID!=null && unit.PURCHASE_APPLY_DETAIL_ID.Length > 0) //edit
			{
				sql = "UPDATE [T_MATERIAL_PURCHASE_APPLY_DETAIL] SET "
					+ " [PURCHASE_APPLY_DETAIL_ID] = " + (string.IsNullOrEmpty(unit.PURCHASE_APPLY_DETAIL_ID)?"null":"'" + unit.PURCHASE_APPLY_DETAIL_ID.Replace ("'","''") + "'")
					+ " , [PURCHASE_APPLYID] = " + (string.IsNullOrEmpty(unit.PURCHASE_APPLYID)?"null":"'" + unit.PURCHASE_APPLYID.Replace ("'","''") + "'")
					+ " , [MATERIAL_ID] = " + (string.IsNullOrEmpty(unit.MATERIAL_ID)?"null":"'" + unit.MATERIAL_ID.Replace ("'","''") + "'")
					+ " , [MATERIAL_NAME] = N" + (unit.MATERIAL_NAME==null?"''":"'" + unit.MATERIAL_NAME.Replace ("'","''") + "'")
					+ " , [MATERIAL_CODE] = " + (unit.MATERIAL_CODE==null?"''":"'" + unit.MATERIAL_CODE.Replace ("'","''") + "'")
					+ " , [MATERIAL_SPEC] = N" + (unit.MATERIAL_SPEC==null?"''":"'" + unit.MATERIAL_SPEC.Replace ("'","''") + "'")
					+ " , [APPLYCOUNT] = " + unit.APPLYCOUNT.ToString()
					+ " , [CONFIRMEDCOUNT] = " + unit.CONFIRMEDCOUNT.ToString()
					+ " , [REMARK] = N" + (unit.REMARK==null?"''":"'" + unit.REMARK.Replace ("'","''") + "'")
                    + " , [ORDERNUM] = " + unit.ORDERNUM.ToString()
					+ " where upper(PURCHASE_APPLY_DETAIL_ID) = '" + unit.PURCHASE_APPLY_DETAIL_ID.ToUpper() + "'"; 
			}
			else
			{
				unit.PURCHASE_APPLY_DETAIL_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_MATERIAL_PURCHASE_APPLY_DETAIL] ("
					+ "[PURCHASE_APPLY_DETAIL_ID],"
					+ "[PURCHASE_APPLYID],"
					+ "[MATERIAL_ID],"
					+ "[MATERIAL_NAME],"
					+ "[MATERIAL_CODE],"
					+ "[MATERIAL_SPEC],"
					+ "[APPLYCOUNT],"
					+ "[CONFIRMEDCOUNT],"
					+ "[REMARK],"
                    + "[ORDERNUM]"
					+ ") VALUES( "
					+ " " + (string.IsNullOrEmpty(unit.PURCHASE_APPLY_DETAIL_ID)?"null":"'" + unit.PURCHASE_APPLY_DETAIL_ID.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.PURCHASE_APPLYID)?"null":"'" + unit.PURCHASE_APPLYID.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.MATERIAL_ID)?"null":"'" + unit.MATERIAL_ID.Replace ("'","''") + "'")
					+ " , N" + (unit.MATERIAL_NAME==null?"''":"'" + unit.MATERIAL_NAME.Replace ("'","''") + "'")
					+ " , " + (unit.MATERIAL_CODE==null?"''":"'" + unit.MATERIAL_CODE.Replace ("'","''") + "'")
					+ " , N" + (unit.MATERIAL_SPEC==null?"''":"'" + unit.MATERIAL_SPEC.Replace ("'","''") + "'")
					+ " ,"+ unit.APPLYCOUNT.ToString()
					+ " ,"+ unit.CONFIRMEDCOUNT.ToString()
					+ " , N" + (unit.REMARK==null?"''":"'" + unit.REMARK.Replace ("'","''") + "'")
                    + " ," + unit.ORDERNUM.ToString()
					+ ")";
			}

			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_MATERIAL_PURCHASE_APPLY_DETAIL中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_MATERIAL_PURCHASE_APPLY_DETAIL对象</param>
		internal bool deleteUnit(MaterialPurchaseApplyDetail unit,out string err)
		{
			return deleteUnit(unit.PURCHASE_APPLY_DETAIL_ID,out err);
		}
		
		/// <summary>
		/// 删除数据表T_MATERIAL_PURCHASE_APPLY_DETAIL中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_MATERIAL_PURCHASE_APPLY_DETAIL.pURCHASE_APPLY_DETAIL_ID主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_MATERIAL_PURCHASE_APPLY_DETAIL where "
				+ " upper(T_MATERIAL_PURCHASE_APPLY_DETAIL.PURCHASE_APPLY_DETAIL_ID)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_MATERIAL_PURCHASE_APPLY_DETAIL 所有数据信息.
		/// </summary>
		/// <returns>T_MATERIAL_PURCHASE_APPLY_DETAIL DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql = "select	"
				+ "PURCHASE_APPLY_DETAIL_ID"
				+ ",PURCHASE_APPLYID"
				+ ",MATERIAL_ID"
				+ ",MATERIAL_NAME"
				+ ",MATERIAL_CODE"
				+ ",MATERIAL_SPEC"
				+ ",APPLYCOUNT"
				+ ",CONFIRMEDCOUNT"
				+ ",REMARK"
                + ",ORDERNUM"
				+ "  from T_MATERIAL_PURCHASE_APPLY_DETAIL ";
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
		/// 根据一个主键ID,得到 T_MATERIAL_PURCHASE_APPLY_DETAIL 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>MaterialPurchaseApplyDetail DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql = "select "
				+ "PURCHASE_APPLY_DETAIL_ID"
				+ ",PURCHASE_APPLYID"
				+ ",MATERIAL_ID"
				+ ",MATERIAL_NAME"
				+ ",MATERIAL_CODE"
				+ ",MATERIAL_SPEC"
				+ ",APPLYCOUNT"
				+ ",CONFIRMEDCOUNT"
				+ ",REMARK"
                + ",ORDERNUM"
				+ " from T_MATERIAL_PURCHASE_APPLY_DETAIL "
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
		/// 根据materialpurchaseapplydetail 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>materialpurchaseapplydetail 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
		public MaterialPurchaseApplyDetail getObject(DataRow dr)
		{
			MaterialPurchaseApplyDetail unit=new MaterialPurchaseApplyDetail();
			if (null==dr)
			{
				unit.IsWrong = true;
				unit.WhyWrong = "从数据库获取信息时出错,未成功构造MaterialPurchaseApplyDetail类对象!";
				return unit;
			}
			if (DBNull.Value != dr["PURCHASE_APPLY_DETAIL_ID"])	
			    unit.PURCHASE_APPLY_DETAIL_ID=dr["PURCHASE_APPLY_DETAIL_ID"].ToString();
			if (DBNull.Value != dr["PURCHASE_APPLYID"])	
			    unit.PURCHASE_APPLYID=dr["PURCHASE_APPLYID"].ToString();
			if (DBNull.Value != dr["MATERIAL_ID"])	
			    unit.MATERIAL_ID=dr["MATERIAL_ID"].ToString();
			if (DBNull.Value != dr["MATERIAL_NAME"])	
			    unit.MATERIAL_NAME=dr["MATERIAL_NAME"].ToString();
			if (DBNull.Value != dr["MATERIAL_CODE"])	
			    unit.MATERIAL_CODE=dr["MATERIAL_CODE"].ToString();
			if (DBNull.Value != dr["MATERIAL_SPEC"])	
			    unit.MATERIAL_SPEC=dr["MATERIAL_SPEC"].ToString();
			if (DBNull.Value != dr["APPLYCOUNT"])	
			    unit.APPLYCOUNT=Convert.ToDecimal(dr["APPLYCOUNT"]);
			if (DBNull.Value != dr["CONFIRMEDCOUNT"])	
			    unit.CONFIRMEDCOUNT=Convert.ToDecimal(dr["CONFIRMEDCOUNT"]);
			if (DBNull.Value != dr["REMARK"])	
			    unit.REMARK=dr["REMARK"].ToString();
            if (DBNull.Value != dr["ORDERNUM"])
                unit.ORDERNUM = Convert.ToInt32(dr["ORDERNUM"]);
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个MaterialPurchaseApplyDetail对象.
		/// </summary>
		/// <param name="pURCHASE_APPLY_DETAIL_ID">pURCHASE_APPLY_DETAIL_ID</param>
		/// <returns>MaterialPurchaseApplyDetail对象</returns>
		public  MaterialPurchaseApplyDetail getObject(string Id,out string err)
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
