using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using BLToolkit.Data;
using BLToolkit.DataAccess;
using SupplyManage.DataObject;

namespace SupplyManage.DataAccess
{
	public class SupplierOfferApprovalAccess
	{
		#region BASE_ACCESS 
		
		#region liulei-2017-1-19-构造函数 
		///<summary> 
		///静态实例对象. 
		///</summary> 
		private static SupplierOfferApprovalAccess instance = new SupplierOfferApprovalAccess();
		public static SupplierOfferApprovalAccess Instance
		{
			get
			{
				if (null == instance)
				{
					SupplierOfferApprovalAccess.instance = new SupplierOfferApprovalAccess();
				}
				return SupplierOfferApprovalAccess.instance;
			}
		}
		private SupplierOfferApprovalAccess() { }
		#endregion 
		
		#region liulei-2017-1-19-根据主键读取对象 
		///<summary> 
		///根据主键读取对象. 
		///</summary> 
		///<param name="businessId">业务主键.</param> 
		///<param name="errMessage">错误信息.</param>
		///<param name="dbAccess">数据库管理对象.</param> 
		///<returns>根据主键查询得到的对象.</returns>
		public SupplierOfferApprovalFormObject SelectObject(String businessId, out String errMessage, DbManager dbAccess = null)
		{
			errMessage = String.Empty;
			DbManager db = null;
			if (null == dbAccess) { db = new DbManager(CommonOperation.ConstParameter.DBConnectString); }
			else db = dbAccess;
			try
			{
                SqlQuery<SupplierOfferApprovalFormObject> query = new SqlQuery<SupplierOfferApprovalFormObject>();
				return query.SelectByKey(db, businessId);
			}
			catch (Exception ex)
			{
				errMessage = ex.Message;
				return null;
			}
		}
		#endregion 
		
		#region liulei-2017-1-19-插入对象 
		///<summary> 
		///插入对象. 
		///</summary> 
		///<param name="model">业务对象.</param> 
		///<param name="errMessage">错误信息.</param>
		///<param name="dbAccess">数据库管理对象.</param> 
		///<returns>True成功，FALSE 失败.</returns>
        public Boolean InsertObject(SupplierOfferApprovalFormObject model, out String errMessage, DbManager dbAccess = null)
		{
			errMessage = String.Empty;
			DbManager db = null;
            if (null == dbAccess) { db = new DbManager(CommonOperation.ConstParameter.DBConnectString); }
			else db = dbAccess;
			try
			{
                SqlQuery<SupplierOfferApprovalFormObject> query = new SqlQuery<SupplierOfferApprovalFormObject>();
				query.Insert(db, model);
				return true;
			}
			catch (Exception ex)
			{
				errMessage = ex.Message;
				return false;
			}
		}
		#endregion 
		
		#region liulei-2017-1-19-更新对象 
		///<summary> 
		///更新对象. 
		///</summary> 
		///<param name="model">业务对象.</param> 
		///<param name="errMessage">错误信息.</param>
		///<param name="dbAccess">数据库管理对象.</param> 
		///<returns>True成功，FALSE 失败.</returns>
        public Boolean UpdateObject(SupplierOfferApprovalFormObject model, out String errMessage, DbManager dbAccess = null)
		{
			errMessage = String.Empty;
			DbManager db = null;
			if (null == dbAccess) { db = new DbManager(CommonOperation.ConstParameter.DBConnectString); }
			else db = dbAccess;
			try
			{
                SqlQuery<SupplierOfferApprovalFormObject> query = new SqlQuery<SupplierOfferApprovalFormObject>();
				query.Update(db, model);
				return true;
			}
			catch (Exception ex)
			{
				errMessage = ex.Message;
				return false;
			}
		}
		#endregion 
		
		#region liulei-2017-1-19-根据主键删除对象 
		///<summary> 
		///根据主键删除对象. 
		///</summary> 
		///<param name="businessId">业务主键.</param> 
		///<param name="errMessage">错误信息.</param>
		///<param name="dbAccess">数据库管理对象.</param> 
		///<returns>True成功，FALSE 失败.</returns>
		public Boolean DeleteObjectByKey(String businessId, out String errMessage, DbManager dbAccess = null)
		{
			errMessage = String.Empty;
			DbManager db = null;
            if (null == dbAccess) { db = new DbManager(CommonOperation.ConstParameter.DBConnectString); }
			else db = dbAccess;
			try
			{
                SqlQuery<SupplierOfferApprovalFormObject> query = new SqlQuery<SupplierOfferApprovalFormObject>();
				query.DeleteByKey(db, businessId);
				return true;
			}
			catch (Exception ex)
			{
				errMessage = ex.Message;
				return false;
			}
		}
		#endregion 
		
		#region liulei-2017-1-19-数据库是否存在指定主键的对象字符串 
		///<summary> 
		///得到数据库是否存在指定主键的对象字符串. 
		///</summary> 
		///<param name="businessId">业务主键.</param> 
		///<param name="errMessage">错误信息.</param>
		///<param name="dbAccess">数据库管理对象.</param> 
		///<returns>True成功，FALSE 失败.</returns>
		public Boolean DbHaveThisData( String businessId , out String errMessage, DbManager dbAccess = null)
		{
            SupplierOfferApprovalFormObject model = SelectObject(businessId, out errMessage);
			if (null != model) { return true; }
			return false;
		}
		#endregion 
		
		#region liulei-2017-1-19-保存对象 
		///<summary> 
		///保存业务对象. 
		///</summary> 
		///<param name="model">业务对象.</param> 
		///<param name="errMessage">错误信息.</param>
		///<param name="dbAccess">数据库管理对象.</param> 
		///<returns>True成功，FALSE 失败.</returns>
        public Boolean SaveObject(SupplierOfferApprovalFormObject model, out String errMessage, DbManager dbAccess = null)
		{
			if (String.IsNullOrEmpty(model.ID)) //ID为主键字段名称，可能需要被替换。
			{
				model.ID = System.Guid.NewGuid().ToString();
				return InsertObject(model, out errMessage, dbAccess);
			}
			else
			{
				return UpdateObject(model, out errMessage, dbAccess);
			}
		}
		#endregion 
		#endregion 
	} 
} 

