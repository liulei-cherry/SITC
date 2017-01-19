/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：MaterialPurchaseOrderService.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/9/18
 * 标    题：数据操作类
 * 功能描述：T_MATERIAL_PURCHASE_ORDER数据操作类
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
    /// 数据层实例化接口类 dbo.T_MATERIAL_PURCHASE_ORDERService.cs
    /// </summary>
    public partial class MaterialPurchaseOrderService
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static MaterialPurchaseOrderService instance=new MaterialPurchaseOrderService();
        public static MaterialPurchaseOrderService Instance
        { 
            get
            {
                if(null==instance)
                {
                    MaterialPurchaseOrderService.instance = new MaterialPurchaseOrderService();
                }
                return MaterialPurchaseOrderService.instance;
            }
        }
		private MaterialPurchaseOrderService(){}
		#endregion
		
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();        
        string sql = ""; 
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">MaterialPurchaseOrder对象</param>
		/// <returns>插入的对象更新</returns>	
		internal bool saveUnit(MaterialPurchaseOrder unit,out string err)
        {
			if (unit.PURCHASE_ORDERID!=null && unit.PURCHASE_ORDERID.Length > 0) //edit
			{
				sql = "UPDATE [T_MATERIAL_PURCHASE_ORDER] SET "
					+ " [PURCHASE_ORDERID] = " + (string.IsNullOrEmpty(unit.PURCHASE_ORDERID)?"null":"'" + unit.PURCHASE_ORDERID.Replace ("'","''") + "'")
					+ " , [CURRENCYID] = " + (string.IsNullOrEmpty(unit.CURRENCYID)?"null":"'" + unit.CURRENCYID.Replace ("'","''") + "'")
					+ " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ " , [SUPPLIER_ID] = " + (string.IsNullOrEmpty(unit.SUPPLIER_ID)?"null":"'" + unit.SUPPLIER_ID.Replace ("'","''") + "'")
					+ " , [PURCHASE_ORDER_CODE] = " + (unit.PURCHASE_ORDER_CODE==null?"''":"'" + unit.PURCHASE_ORDER_CODE.Replace ("'","''") + "'")
					+ " , [PURCHASE_ORDER_PERSON] = " + (unit.PURCHASE_ORDER_PERSON==null?"''":"'" + unit.PURCHASE_ORDER_PERSON.Replace ("'","''") + "'")
                    + " , [PURCHASE_ORDER_DATE] = " + dbOperation.DbToDate(unit.PURCHASE_ORDER_DATE)
					+ " , [LANDCHECKER] = " + (unit.LANDCHECKER==null?"''":"'" + unit.LANDCHECKER.Replace ("'","''") + "'")
                    + " , [CHECKDATE] = " + dbOperation.DbToDate(unit.CHECKDATE)
					+ " , [REMARK] = N" + (unit.REMARK==null?"''":"'" + unit.REMARK.Replace ("'","''") + "'")
					+ " , [STATE] = " + unit.STATE.ToString()
					+ " , [TOTALPRICE] = " + unit.TOTALPRICE.ToString()
					+ " , [EXTRAPRICE] = " + unit.EXTRAPRICE.ToString()
                    + " , [SENDDATE] = " + dbOperation.DbToDate(unit.SENDDATE)
					+ " , [ISCOMPLETE] = " + unit.ISCOMPLETE.ToString()
					+ " , [SENDPORT] = " + (unit.SENDPORT==null?"''":"'" + unit.SENDPORT.Replace ("'","''") + "'")
					+ " where upper(PURCHASE_ORDERID) = '" + unit.PURCHASE_ORDERID.ToUpper() + "'"; 
			}
			else
			{
				unit.PURCHASE_ORDERID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_MATERIAL_PURCHASE_ORDER] ("
					+ "[PURCHASE_ORDERID],"
					+ "[CURRENCYID],"
					+ "[SHIP_ID],"
					+ "[SUPPLIER_ID],"
					+ "[PURCHASE_ORDER_CODE],"
					+ "[PURCHASE_ORDER_PERSON],"
					+ "[PURCHASE_ORDER_DATE],"
					+ "[LANDCHECKER],"
					+ "[CHECKDATE],"
					+ "[REMARK],"
					+ "[STATE],"
					+ "[TOTALPRICE],"
					+ "[EXTRAPRICE],"
					+ "[SENDDATE],"
					+ "[ISCOMPLETE],"
					+ "[SENDPORT]"
					+ ") VALUES( "
					+ " " + (string.IsNullOrEmpty(unit.PURCHASE_ORDERID)?"null":"'" + unit.PURCHASE_ORDERID.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.CURRENCYID)?"null":"'" + unit.CURRENCYID.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.SUPPLIER_ID)?"null":"'" + unit.SUPPLIER_ID.Replace ("'","''") + "'")
					+ " , " + (unit.PURCHASE_ORDER_CODE==null?"''":"'" + unit.PURCHASE_ORDER_CODE.Replace ("'","''") + "'")
					+ " , " + (unit.PURCHASE_ORDER_PERSON==null?"''":"'" + unit.PURCHASE_ORDER_PERSON.Replace ("'","''") + "'")
					+ " ," + dbOperation.DbToDate(unit.PURCHASE_ORDER_DATE)
					+ " , " + (unit.LANDCHECKER==null?"''":"'" + unit.LANDCHECKER.Replace ("'","''") + "'")
					+ " ," + dbOperation.DbToDate(unit.CHECKDATE)
					+ " , N" + (unit.REMARK==null?"''":"'" + unit.REMARK.Replace ("'","''") + "'")
					+ " ,"+ unit.STATE.ToString()
					+ " ,"+ unit.TOTALPRICE.ToString()
					+ " ,"+ unit.EXTRAPRICE.ToString()
					+ " ," + dbOperation.DbToDate(unit.SENDDATE)
					+ " ,"+ unit.ISCOMPLETE.ToString()
					+ " , " + (unit.SENDPORT==null?"''":"'" + unit.SENDPORT.Replace ("'","''") + "'")
					+ ")";
			}

			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_MATERIAL_PURCHASE_ORDER中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_MATERIAL_PURCHASE_ORDER对象</param>
		internal bool deleteUnit(MaterialPurchaseOrder unit,out string err)
		{
			return deleteUnit(unit.PURCHASE_ORDERID,out err);
		}
		
		/// <summary>
		/// 删除数据表T_MATERIAL_PURCHASE_ORDER中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_MATERIAL_PURCHASE_ORDER.pURCHASE_ORDERID主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_MATERIAL_PURCHASE_ORDER where "
				+ " upper(T_MATERIAL_PURCHASE_ORDER.PURCHASE_ORDERID)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_MATERIAL_PURCHASE_ORDER 所有数据信息.
		/// </summary>
		/// <returns>T_MATERIAL_PURCHASE_ORDER DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql = "select	"
				+ "PURCHASE_ORDERID"
				+ ",CURRENCYID"
				+ ",SHIP_ID"
				+ ",SUPPLIER_ID"
				+ ",PURCHASE_ORDER_CODE"
				+ ",PURCHASE_ORDER_PERSON"
				+ ",PURCHASE_ORDER_DATE"
				+ ",LANDCHECKER"
				+ ",CHECKDATE"
				+ ",REMARK"
				+ ",STATE"
				+ ",TOTALPRICE"
				+ ",EXTRAPRICE"
				+ ",SENDDATE"
				+ ",ISCOMPLETE"
				+ ",SENDPORT"
				+ "  from T_MATERIAL_PURCHASE_ORDER ";
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
		/// 根据一个主键ID,得到 T_MATERIAL_PURCHASE_ORDER 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>MaterialPurchaseOrder DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql = "select "
				+ "PURCHASE_ORDERID"
				+ ",CURRENCYID"
				+ ",SHIP_ID"
				+ ",SUPPLIER_ID"
				+ ",PURCHASE_ORDER_CODE"
				+ ",PURCHASE_ORDER_PERSON"
				+ ",PURCHASE_ORDER_DATE"
				+ ",LANDCHECKER"
				+ ",CHECKDATE"
				+ ",REMARK"
				+ ",STATE"
				+ ",TOTALPRICE"
				+ ",EXTRAPRICE"
				+ ",SENDDATE"
				+ ",ISCOMPLETE"
				+ ",SENDPORT"
				+ " from T_MATERIAL_PURCHASE_ORDER "
				+ " where upper(PURCHASE_ORDERID)='" + Id.ToUpper()+"'";
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
		/// 根据materialpurchaseorder 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>materialpurchaseorder 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
		public MaterialPurchaseOrder getObject(DataRow dr)
		{
			MaterialPurchaseOrder unit=new MaterialPurchaseOrder();
			if (null==dr)
			{
				unit.IsWrong = true;
				unit.WhyWrong = "从数据库获取信息时出错,未成功构造MaterialPurchaseOrder类对象!";
				return unit;
			}
			if (DBNull.Value != dr["PURCHASE_ORDERID"])	
			    unit.PURCHASE_ORDERID=dr["PURCHASE_ORDERID"].ToString();
			if (DBNull.Value != dr["CURRENCYID"])	
			    unit.CURRENCYID=dr["CURRENCYID"].ToString();
			if (DBNull.Value != dr["SHIP_ID"])	
			    unit.SHIP_ID=dr["SHIP_ID"].ToString();
			if (DBNull.Value != dr["SUPPLIER_ID"])	
			    unit.SUPPLIER_ID=dr["SUPPLIER_ID"].ToString();
			if (DBNull.Value != dr["PURCHASE_ORDER_CODE"])	
			    unit.PURCHASE_ORDER_CODE=dr["PURCHASE_ORDER_CODE"].ToString();
			if (DBNull.Value != dr["PURCHASE_ORDER_PERSON"])	
			    unit.PURCHASE_ORDER_PERSON=dr["PURCHASE_ORDER_PERSON"].ToString();
			if (DBNull.Value != dr["PURCHASE_ORDER_DATE"])	
                unit.PURCHASE_ORDER_DATE=(DateTime)dr["PURCHASE_ORDER_DATE"];
			if (DBNull.Value != dr["LANDCHECKER"])	
			    unit.LANDCHECKER=dr["LANDCHECKER"].ToString();
			if (DBNull.Value != dr["CHECKDATE"])	
                unit.CHECKDATE=(DateTime)dr["CHECKDATE"];
			if (DBNull.Value != dr["REMARK"])	
			    unit.REMARK=dr["REMARK"].ToString();
			if (DBNull.Value != dr["STATE"])	
			    unit.STATE=Convert.ToDecimal(dr["STATE"]);
			if (DBNull.Value != dr["TOTALPRICE"])	
			    unit.TOTALPRICE=Convert.ToDecimal(dr["TOTALPRICE"]);
			if (DBNull.Value != dr["EXTRAPRICE"])	
			    unit.EXTRAPRICE=Convert.ToDecimal(dr["EXTRAPRICE"]);
			if (DBNull.Value != dr["SENDDATE"])	
                unit.SENDDATE=(DateTime)dr["SENDDATE"];
			if (DBNull.Value != dr["ISCOMPLETE"])	
			    unit.ISCOMPLETE=Convert.ToDecimal(dr["ISCOMPLETE"]);
			if (DBNull.Value != dr["SENDPORT"])	
			    unit.SENDPORT=dr["SENDPORT"].ToString();
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个MaterialPurchaseOrder对象.
		/// </summary>
		/// <param name="pURCHASE_ORDERID">pURCHASE_ORDERID</param>
		/// <returns>MaterialPurchaseOrder对象</returns>
		public  MaterialPurchaseOrder getObject(string Id,out string err)
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

        #region 根据ID查找信息 cheny-2013-08-08
        /// <summary>
        /// 根据一个主键ID,得到 T_MATERIAL_PURCHASE_ORDER 的DataTable
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public DataTable getInfoBy(string Id, out string err)
        {
            sql = "select * from T_MATERIAL_PURCHASE_ORDER a inner join T_MATERIAL_PURCHASE_ORDER_DETAIL b on a.PURCHASE_ORDERID = b.PURCHASE_ORDERID where a.PURCHASE_ORDERID='" + Id.ToUpper() + "'";
            DataTable dt;
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                return dt;
            }
            else
            {
                throw new Exception(err);
            }
        } 
        #endregion
    }
}
