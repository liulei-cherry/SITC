/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：ReportDeckMaintainService.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/12/6
 * 标    题：数据操作类
 * 功能描述：T_REPORT_DECK_MAINTAIN数据操作类
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
using CustomerTable.Haifeng.DataObject;

namespace  CustomerTable.Haifeng.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_REPORT_DECK_MAINTAINService.cs
    /// </summary>
    public partial class ReportDeckMaintainService
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static ReportDeckMaintainService instance=new ReportDeckMaintainService();
        public static ReportDeckMaintainService Instance
        { 
            get
            {
                if(null==instance)
                {
                    ReportDeckMaintainService.instance = new ReportDeckMaintainService();
                }
                return ReportDeckMaintainService.instance;
            }
        }
		private ReportDeckMaintainService(){}
		#endregion
		
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();        
        string sql = ""; 
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">ReportDeckMaintain对象</param>
		/// <returns>插入的对象更新</returns>	
		internal bool saveUnit(ReportDeckMaintain unit,out string err)
        {
			if (unit.REPORT_ID!=null && unit.REPORT_ID.Length > 0) //edit
			{
				sql = "UPDATE [T_REPORT_DECK_MAINTAIN] SET "
					+ " [REPORT_ID] = " + (string.IsNullOrEmpty(unit.REPORT_ID)?"null":"'" + unit.REPORT_ID.Replace ("'","''") + "'")
					+ " , [FILE_ID] = " + (string.IsNullOrEmpty(unit.FILE_ID)?"null":"'" + unit.FILE_ID.Replace ("'","''") + "'")
                    + " , [FILE_DATE] = " + dbOperation.DbToDate(unit.FILE_DATE)
					+ " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ " , [VOYAGE] = " + (unit.VOYAGE==null?"''":"'" + unit.VOYAGE.Replace ("'","''") + "'")
                    + " , [REPORT_DATE] = " + dbOperation.DbToDate(unit.REPORT_DATE)
                    + " , [BEGIN_DATE] = " + dbOperation.DbToDate(unit.BEGIN_DATE)
                    + " , [END_DATE] = " + dbOperation.DbToDate(unit.END_DATE)
					+ " , [AIR_LINE] = " + (unit.AIR_LINE==null?"''":"'" + unit.AIR_LINE.Replace ("'","''") + "'")
					+ " , [CHUAN_ZHANG] = " + (unit.CHUAN_ZHANG==null?"''":"'" + unit.CHUAN_ZHANG.Replace ("'","''") + "'")
					+ " , [DA_FU] = " + (unit.DA_FU==null?"''":"'" + unit.DA_FU.Replace ("'","''") + "'")
					+ " , [ER_FU] = " + (unit.ER_FU==null?"''":"'" + unit.ER_FU.Replace ("'","''") + "'")
					+ " , [SAN_FU] = " + (unit.SAN_FU==null?"''":"'" + unit.SAN_FU.Replace ("'","''") + "'")
					+ " , [SHUI_SHOU] = " + (unit.SHUI_SHOU==null?"''":"'" + unit.SHUI_SHOU.Replace ("'","''") + "'")
					+ " , [MU_JIANG] = " + (unit.MU_JIANG==null?"''":"'" + unit.MU_JIANG.Replace ("'","''") + "'")
					+ " , [CTJG] = " + (unit.CTJG==null?"''":"'" + unit.CTJG.Replace ("'","''") + "'")
					+ " , [CKB] = " + (unit.CKB==null?"''":"'" + unit.CKB.Replace ("'","''") + "'")
					+ " , [XZ_SHQ] = " + (unit.XZ_SHQ==null?"''":"'" + unit.XZ_SHQ.Replace ("'","''") + "'")
					+ " , [JB] = " + (unit.JB==null?"''":"'" + unit.JB.Replace ("'","''") + "'")
					+ " , [JBSB] = " + (unit.JBSB==null?"''":"'" + unit.JBSB.Replace ("'","''") + "'")
					+ " , [CG] = " + (unit.CG==null?"''":"'" + unit.CG.Replace ("'","''") + "'")
					+ " , [YST] = " + (unit.YST==null?"''":"'" + unit.YST.Replace ("'","''") + "'")
					+ " , [DBSC] = " + (unit.DBSC==null?"''":"'" + unit.DBSC.Replace ("'","''") + "'")
					+ " , [YZSC] = " + (unit.YZSC==null?"''":"'" + unit.YZSC.Replace ("'","''") + "'")
					+ " , [JBGX] = " + (unit.JBGX==null?"''":"'" + unit.JBGX.Replace ("'","''") + "'")
					+ " , [XF] = " + (unit.XF==null?"''":"'" + unit.XF.Replace ("'","''") + "'")
					+ " , [JS] = " + (unit.JS==null?"''":"'" + unit.JS.Replace ("'","''") + "'")
					+ " , [SMM_C] = " + (unit.SMM_C==null?"''":"'" + unit.SMM_C.Replace ("'","''") + "'")
					+ " , [TQG] = " + (unit.TQG==null?"''":"'" + unit.TQG.Replace ("'","''") + "'")
					+ " , [TFSB] = " + (unit.TFSB==null?"''":"'" + unit.TFSB.Replace ("'","''") + "'")
					+ " , [QT] = " + (unit.QT==null?"''":"'" + unit.QT.Replace ("'","''") + "'")
					+ " , [UNDONE_PROJECT] = " + (unit.UNDONE_PROJECT==null?"''":"'" + unit.UNDONE_PROJECT.Replace ("'","''") + "'")
					+ " , [PROBLEM] = " + (unit.PROBLEM==null?"''":"'" + unit.PROBLEM.Replace ("'","''") + "'")
					+ " , [TEMPORARY_PROJECT] = " + (unit.TEMPORARY_PROJECT==null?"''":"'" + unit.TEMPORARY_PROJECT.Replace ("'","''") + "'")
					+ " , [VERIFY_SUGGESTION] = " + (unit.VERIFY_SUGGESTION==null?"''":"'" + unit.VERIFY_SUGGESTION.Replace ("'","''") + "'")
					+ " where upper(REPORT_ID) = '" + unit.REPORT_ID.ToUpper() + "'"; 
			}
			else
			{
				unit.REPORT_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_REPORT_DECK_MAINTAIN] ("
					+ "[REPORT_ID],"
					+ "[FILE_ID],"
					+ "[FILE_DATE],"
					+ "[SHIP_ID],"
					+ "[VOYAGE],"
					+ "[REPORT_DATE],"
					+ "[BEGIN_DATE],"
					+ "[END_DATE],"
					+ "[AIR_LINE],"
					+ "[CHUAN_ZHANG],"
					+ "[DA_FU],"
					+ "[ER_FU],"
					+ "[SAN_FU],"
					+ "[SHUI_SHOU],"
					+ "[MU_JIANG],"
					+ "[CTJG],"
					+ "[CKB],"
					+ "[XZ_SHQ],"
					+ "[JB],"
					+ "[JBSB],"
					+ "[CG],"
					+ "[YST],"
					+ "[DBSC],"
					+ "[YZSC],"
					+ "[JBGX],"
					+ "[XF],"
					+ "[JS],"
					+ "[SMM_C],"
					+ "[TQG],"
					+ "[TFSB],"
					+ "[QT],"
					+ "[UNDONE_PROJECT],"
					+ "[PROBLEM],"
					+ "[TEMPORARY_PROJECT],"
					+ "[VERIFY_SUGGESTION]"
					+ ") VALUES( "
					+ " " + (string.IsNullOrEmpty(unit.REPORT_ID)?"null":"'" + unit.REPORT_ID.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.FILE_ID)?"null":"'" + unit.FILE_ID.Replace ("'","''") + "'")
					+ " ," + dbOperation.DbToDate(unit.FILE_DATE)
					+ " , " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ " , " + (unit.VOYAGE==null?"''":"'" + unit.VOYAGE.Replace ("'","''") + "'")
					+ " ," + dbOperation.DbToDate(unit.REPORT_DATE)
					+ " ," + dbOperation.DbToDate(unit.BEGIN_DATE)
					+ " ," + dbOperation.DbToDate(unit.END_DATE)
					+ " , " + (unit.AIR_LINE==null?"''":"'" + unit.AIR_LINE.Replace ("'","''") + "'")
					+ " , " + (unit.CHUAN_ZHANG==null?"''":"'" + unit.CHUAN_ZHANG.Replace ("'","''") + "'")
					+ " , " + (unit.DA_FU==null?"''":"'" + unit.DA_FU.Replace ("'","''") + "'")
					+ " , " + (unit.ER_FU==null?"''":"'" + unit.ER_FU.Replace ("'","''") + "'")
					+ " , " + (unit.SAN_FU==null?"''":"'" + unit.SAN_FU.Replace ("'","''") + "'")
					+ " , " + (unit.SHUI_SHOU==null?"''":"'" + unit.SHUI_SHOU.Replace ("'","''") + "'")
					+ " , " + (unit.MU_JIANG==null?"''":"'" + unit.MU_JIANG.Replace ("'","''") + "'")
					+ " , " + (unit.CTJG==null?"''":"'" + unit.CTJG.Replace ("'","''") + "'")
					+ " , " + (unit.CKB==null?"''":"'" + unit.CKB.Replace ("'","''") + "'")
					+ " , " + (unit.XZ_SHQ==null?"''":"'" + unit.XZ_SHQ.Replace ("'","''") + "'")
					+ " , " + (unit.JB==null?"''":"'" + unit.JB.Replace ("'","''") + "'")
					+ " , " + (unit.JBSB==null?"''":"'" + unit.JBSB.Replace ("'","''") + "'")
					+ " , " + (unit.CG==null?"''":"'" + unit.CG.Replace ("'","''") + "'")
					+ " , " + (unit.YST==null?"''":"'" + unit.YST.Replace ("'","''") + "'")
					+ " , " + (unit.DBSC==null?"''":"'" + unit.DBSC.Replace ("'","''") + "'")
					+ " , " + (unit.YZSC==null?"''":"'" + unit.YZSC.Replace ("'","''") + "'")
					+ " , " + (unit.JBGX==null?"''":"'" + unit.JBGX.Replace ("'","''") + "'")
					+ " , " + (unit.XF==null?"''":"'" + unit.XF.Replace ("'","''") + "'")
					+ " , " + (unit.JS==null?"''":"'" + unit.JS.Replace ("'","''") + "'")
					+ " , " + (unit.SMM_C==null?"''":"'" + unit.SMM_C.Replace ("'","''") + "'")
					+ " , " + (unit.TQG==null?"''":"'" + unit.TQG.Replace ("'","''") + "'")
					+ " , " + (unit.TFSB==null?"''":"'" + unit.TFSB.Replace ("'","''") + "'")
					+ " , " + (unit.QT==null?"''":"'" + unit.QT.Replace ("'","''") + "'")
					+ " , " + (unit.UNDONE_PROJECT==null?"''":"'" + unit.UNDONE_PROJECT.Replace ("'","''") + "'")
					+ " , " + (unit.PROBLEM==null?"''":"'" + unit.PROBLEM.Replace ("'","''") + "'")
					+ " , " + (unit.TEMPORARY_PROJECT==null?"''":"'" + unit.TEMPORARY_PROJECT.Replace ("'","''") + "'")
					+ " , " + (unit.VERIFY_SUGGESTION==null?"''":"'" + unit.VERIFY_SUGGESTION.Replace ("'","''") + "'")
					+ ")";
			}

			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_REPORT_DECK_MAINTAIN中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_REPORT_DECK_MAINTAIN对象</param>
		internal bool deleteUnit(ReportDeckMaintain unit,out string err)
		{
			return deleteUnit(unit.REPORT_ID,out err);
		}
		
		/// <summary>
		/// 删除数据表T_REPORT_DECK_MAINTAIN中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_REPORT_DECK_MAINTAIN.rEPORT_ID主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_REPORT_DECK_MAINTAIN where "
				+ " upper(T_REPORT_DECK_MAINTAIN.REPORT_ID)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_REPORT_DECK_MAINTAIN 所有数据信息.
		/// </summary>
		/// <returns>T_REPORT_DECK_MAINTAIN DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql = "select	"
				+ "REPORT_ID"
				+ ",FILE_ID"
				+ ",FILE_DATE"
				+ ",SHIP_ID"
				+ ",VOYAGE"
				+ ",REPORT_DATE"
				+ ",BEGIN_DATE"
				+ ",END_DATE"
				+ ",AIR_LINE"
				+ ",CHUAN_ZHANG"
				+ ",DA_FU"
				+ ",ER_FU"
				+ ",SAN_FU"
				+ ",SHUI_SHOU"
				+ ",MU_JIANG"
				+ ",CTJG"
				+ ",CKB"
				+ ",XZ_SHQ"
				+ ",JB"
				+ ",JBSB"
				+ ",CG"
				+ ",YST"
				+ ",DBSC"
				+ ",YZSC"
				+ ",JBGX"
				+ ",XF"
				+ ",JS"
				+ ",SMM_C"
				+ ",TQG"
				+ ",TFSB"
				+ ",QT"
				+ ",UNDONE_PROJECT"
				+ ",PROBLEM"
				+ ",TEMPORARY_PROJECT"
				+ ",VERIFY_SUGGESTION"
				+ "  from T_REPORT_DECK_MAINTAIN ";
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
		/// 根据一个主键ID,得到 T_REPORT_DECK_MAINTAIN 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>ReportDeckMaintain DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql = "select "
				+ "REPORT_ID"
				+ ",FILE_ID"
				+ ",FILE_DATE"
				+ ",SHIP_ID"
				+ ",VOYAGE"
				+ ",REPORT_DATE"
				+ ",BEGIN_DATE"
				+ ",END_DATE"
				+ ",AIR_LINE"
				+ ",CHUAN_ZHANG"
				+ ",DA_FU"
				+ ",ER_FU"
				+ ",SAN_FU"
				+ ",SHUI_SHOU"
				+ ",MU_JIANG"
				+ ",CTJG"
				+ ",CKB"
				+ ",XZ_SHQ"
				+ ",JB"
				+ ",JBSB"
				+ ",CG"
				+ ",YST"
				+ ",DBSC"
				+ ",YZSC"
				+ ",JBGX"
				+ ",XF"
				+ ",JS"
				+ ",SMM_C"
				+ ",TQG"
				+ ",TFSB"
				+ ",QT"
				+ ",UNDONE_PROJECT"
				+ ",PROBLEM"
				+ ",TEMPORARY_PROJECT"
				+ ",VERIFY_SUGGESTION"
				+ " from T_REPORT_DECK_MAINTAIN "
				+ " where upper(REPORT_ID)='" + Id.ToUpper()+"'";
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
		/// 根据reportdeckmaintain 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>reportdeckmaintain 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
		public ReportDeckMaintain getObject(DataRow dr)
		{
			ReportDeckMaintain unit=new ReportDeckMaintain();
			if (null==dr)
			{
				unit.IsWrong = true;
				unit.WhyWrong = "从数据库获取信息时出错,未成功构造ReportDeckMaintain类对象!";
				return unit;
			}
			if (DBNull.Value != dr["REPORT_ID"])	
			    unit.REPORT_ID=dr["REPORT_ID"].ToString();
			if (DBNull.Value != dr["FILE_ID"])	
			    unit.FILE_ID=dr["FILE_ID"].ToString();
			if (DBNull.Value != dr["FILE_DATE"])	
                unit.FILE_DATE=(DateTime)dr["FILE_DATE"];
			if (DBNull.Value != dr["SHIP_ID"])	
			    unit.SHIP_ID=dr["SHIP_ID"].ToString();
			if (DBNull.Value != dr["VOYAGE"])	
			    unit.VOYAGE=dr["VOYAGE"].ToString();
			if (DBNull.Value != dr["REPORT_DATE"])	
                unit.REPORT_DATE=(DateTime)dr["REPORT_DATE"];
			if (DBNull.Value != dr["BEGIN_DATE"])	
                unit.BEGIN_DATE=(DateTime)dr["BEGIN_DATE"];
			if (DBNull.Value != dr["END_DATE"])	
                unit.END_DATE=(DateTime)dr["END_DATE"];
			if (DBNull.Value != dr["AIR_LINE"])	
			    unit.AIR_LINE=dr["AIR_LINE"].ToString();
			if (DBNull.Value != dr["CHUAN_ZHANG"])	
			    unit.CHUAN_ZHANG=dr["CHUAN_ZHANG"].ToString();
			if (DBNull.Value != dr["DA_FU"])	
			    unit.DA_FU=dr["DA_FU"].ToString();
			if (DBNull.Value != dr["ER_FU"])	
			    unit.ER_FU=dr["ER_FU"].ToString();
			if (DBNull.Value != dr["SAN_FU"])	
			    unit.SAN_FU=dr["SAN_FU"].ToString();
			if (DBNull.Value != dr["SHUI_SHOU"])	
			    unit.SHUI_SHOU=dr["SHUI_SHOU"].ToString();
			if (DBNull.Value != dr["MU_JIANG"])	
			    unit.MU_JIANG=dr["MU_JIANG"].ToString();
			if (DBNull.Value != dr["CTJG"])	
			    unit.CTJG=dr["CTJG"].ToString();
			if (DBNull.Value != dr["CKB"])	
			    unit.CKB=dr["CKB"].ToString();
			if (DBNull.Value != dr["XZ_SHQ"])	
			    unit.XZ_SHQ=dr["XZ_SHQ"].ToString();
			if (DBNull.Value != dr["JB"])	
			    unit.JB=dr["JB"].ToString();
			if (DBNull.Value != dr["JBSB"])	
			    unit.JBSB=dr["JBSB"].ToString();
			if (DBNull.Value != dr["CG"])	
			    unit.CG=dr["CG"].ToString();
			if (DBNull.Value != dr["YST"])	
			    unit.YST=dr["YST"].ToString();
			if (DBNull.Value != dr["DBSC"])	
			    unit.DBSC=dr["DBSC"].ToString();
			if (DBNull.Value != dr["YZSC"])	
			    unit.YZSC=dr["YZSC"].ToString();
			if (DBNull.Value != dr["JBGX"])	
			    unit.JBGX=dr["JBGX"].ToString();
			if (DBNull.Value != dr["XF"])	
			    unit.XF=dr["XF"].ToString();
			if (DBNull.Value != dr["JS"])	
			    unit.JS=dr["JS"].ToString();
			if (DBNull.Value != dr["SMM_C"])	
			    unit.SMM_C=dr["SMM_C"].ToString();
			if (DBNull.Value != dr["TQG"])	
			    unit.TQG=dr["TQG"].ToString();
			if (DBNull.Value != dr["TFSB"])	
			    unit.TFSB=dr["TFSB"].ToString();
			if (DBNull.Value != dr["QT"])	
			    unit.QT=dr["QT"].ToString();
			if (DBNull.Value != dr["UNDONE_PROJECT"])	
			    unit.UNDONE_PROJECT=dr["UNDONE_PROJECT"].ToString();
			if (DBNull.Value != dr["PROBLEM"])	
			    unit.PROBLEM=dr["PROBLEM"].ToString();
			if (DBNull.Value != dr["TEMPORARY_PROJECT"])	
			    unit.TEMPORARY_PROJECT=dr["TEMPORARY_PROJECT"].ToString();
			if (DBNull.Value != dr["VERIFY_SUGGESTION"])	
			    unit.VERIFY_SUGGESTION=dr["VERIFY_SUGGESTION"].ToString();
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个ReportDeckMaintain对象.
		/// </summary>
		/// <param name="rEPORT_ID">rEPORT_ID</param>
		/// <returns>ReportDeckMaintain对象</returns>
		public  ReportDeckMaintain getObject(string Id,out string err)
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
