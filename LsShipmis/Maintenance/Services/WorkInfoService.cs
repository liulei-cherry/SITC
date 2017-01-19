/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：WorkInfoService.cs
 * 创 建 人：xuzhengben
 * 创建时间：2011/4/25
 * 标    题：数据操作类
 * 功能描述：T_WORKINFO数据操作类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
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
using Maintenance.DataObject;

namespace  Maintenance.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_WORKINFOService.cs
    /// </summary>
    public partial class WorkInfoService
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static WorkInfoService instance=new WorkInfoService();
        public static WorkInfoService Instance
        { 
            get
            {
                if(null==instance)
                {
                    WorkInfoService.instance = new WorkInfoService();
                }
                return WorkInfoService.instance;
            }
        }
		private WorkInfoService(){}
		#endregion
		
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();        
        string sql = ""; 
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">WorkInfo对象</param>
		/// <returns>插入的对象更新</returns>	
		internal bool saveUnit(WorkInfo unit,out string err)
        {
			if (unit.WORKINFOID!=null && unit.WORKINFOID.Length > 0) //edit
			{
				sql = "UPDATE [T_WORKINFO] SET "
					+ " [WORKINFOID] = " + (string.IsNullOrEmpty(unit.WORKINFOID)?"null":"'" + unit.WORKINFOID.Replace ("'","''") + "'")
					+ " , [REFOBJID] = " + (string.IsNullOrEmpty(unit.REFOBJID)?"null":"'" + unit.REFOBJID.Replace ("'","''") + "'")
					+ " , [WORKINFOTYPE] = " + unit.WORKINFOTYPE.ToString()
					+ " , [WORKINFONAME] = N" + (unit.WORKINFONAME==null?"''":"'" + unit.WORKINFONAME.Replace ("'","''") + "'")
					+ " , [WORKINFODETAIL] = N" + (unit.WORKINFODETAIL==null?"''":"'" + unit.WORKINFODETAIL.Replace ("'","''") + "'")
					+ " , [WORKINFOSTATE] = " + unit.WORKINFOSTATE.ToString()
					+ " , [CIRCLEORTIMING] = " + unit.CIRCLEORTIMING.ToString()
					+ " , [CIRCLEPERIOD] = " + unit.CIRCLEPERIOD.ToString()
					+ " , [CIRCLEUNIT] = " + (unit.CIRCLEUNIT==null?"''":"'" + unit.CIRCLEUNIT.Replace ("'","''") + "'")
					+ " , [CIRCLEFRONTLIMIT] = " + unit.CIRCLEFRONTLIMIT.ToString()
					+ " , [CIRCLEBACKLIMIT] = " + unit.CIRCLEBACKLIMIT.ToString()
					+ " , [CIRCLELIMITUNIT] = " + (unit.CIRCLELIMITUNIT==null?"''":"'" + unit.CIRCLELIMITUNIT.Replace ("'","''") + "'")
					+ " , [TIMINGPERIOD] = " + unit.TIMINGPERIOD.ToString()
					+ " , [TIMINGFRONTLIMIT] = " + unit.TIMINGFRONTLIMIT.ToString()
					+ " , [TIMINGBACKLIMIT] = " + unit.TIMINGBACKLIMIT.ToString()
					+ " , [PRINCIPALPOST] = " + (unit.PRINCIPALPOST==null?"''":"'" + unit.PRINCIPALPOST.Replace ("'","''") + "'")
					+ " , [CONFIRMPOST] = " + (unit.CONFIRMPOST==null?"''":"'" + unit.CONFIRMPOST.Replace ("'","''") + "'")
					+ " , [ISCHECKPROJECT] = " + unit.ISCHECKPROJECT.ToString()
					+ " , [ISREPAIRPROJECT] = " + unit.ISREPAIRPROJECT.ToString()
					+ " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ " , [WORKINFOCODE] = " + (unit.WORKINFOCODE==null?"''":"'" + unit.WORKINFOCODE.Replace ("'","''") + "'")
					+ " where upper(WORKINFOID) = '" + unit.WORKINFOID.ToUpper() + "'"; 
			}
			else
			{
				unit.WORKINFOID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_WORKINFO] ("
					+ "[WORKINFOID],"
					+ "[REFOBJID],"
					+ "[WORKINFOTYPE],"
					+ "[WORKINFONAME],"
					+ "[WORKINFODETAIL],"
					+ "[WORKINFOSTATE],"
					+ "[CIRCLEORTIMING],"
					+ "[CIRCLEPERIOD],"
					+ "[CIRCLEUNIT],"
					+ "[CIRCLEFRONTLIMIT],"
					+ "[CIRCLEBACKLIMIT],"
					+ "[CIRCLELIMITUNIT],"
					+ "[TIMINGPERIOD],"
					+ "[TIMINGFRONTLIMIT],"
					+ "[TIMINGBACKLIMIT],"
					+ "[PRINCIPALPOST],"
					+ "[CONFIRMPOST],"
					+ "[ISCHECKPROJECT],"
					+ "[ISREPAIRPROJECT],"
					+ "[SHIP_ID],"
					+ "[WORKINFOCODE]"
					+ ") VALUES( "
					+ " " + (string.IsNullOrEmpty(unit.WORKINFOID)?"null":"'" + unit.WORKINFOID.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.REFOBJID)?"null":"'" + unit.REFOBJID.Replace ("'","''") + "'")
					+ " ,"+ unit.WORKINFOTYPE.ToString()
					+ " , N" + (unit.WORKINFONAME==null?"''":"'" + unit.WORKINFONAME.Replace ("'","''") + "'")
					+ " , N" + (unit.WORKINFODETAIL==null?"''":"'" + unit.WORKINFODETAIL.Replace ("'","''") + "'")
					+ " ,"+ unit.WORKINFOSTATE.ToString()
					+ " ,"+ unit.CIRCLEORTIMING.ToString()
					+ " ,"+ unit.CIRCLEPERIOD.ToString()
					+ " , " + (unit.CIRCLEUNIT==null?"''":"'" + unit.CIRCLEUNIT.Replace ("'","''") + "'")
					+ " ,"+ unit.CIRCLEFRONTLIMIT.ToString()
					+ " ,"+ unit.CIRCLEBACKLIMIT.ToString()
					+ " , " + (unit.CIRCLELIMITUNIT==null?"''":"'" + unit.CIRCLELIMITUNIT.Replace ("'","''") + "'")
					+ " ,"+ unit.TIMINGPERIOD.ToString()
					+ " ,"+ unit.TIMINGFRONTLIMIT.ToString()
					+ " ,"+ unit.TIMINGBACKLIMIT.ToString()
					+ " , " + (unit.PRINCIPALPOST==null?"''":"'" + unit.PRINCIPALPOST.Replace ("'","''") + "'")
					+ " , " + (unit.CONFIRMPOST==null?"''":"'" + unit.CONFIRMPOST.Replace ("'","''") + "'")
					+ " ,"+ unit.ISCHECKPROJECT.ToString()
					+ " ,"+ unit.ISREPAIRPROJECT.ToString()
					+ " , " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ " , " + (unit.WORKINFOCODE==null?"''":"'" + unit.WORKINFOCODE.Replace ("'","''") + "'")
					+ ")";
			}

			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_WORKINFO中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_WORKINFO对象</param>
		internal bool deleteUnit(WorkInfo unit,out string err)
		{
			return deleteUnit(unit.WORKINFOID,out err);
		}
		
		/// <summary>
		/// 删除数据表T_WORKINFO中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_WORKINFO.wORKINFOID主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_WORKINFO where "
				+ " upper(T_WORKINFO.WORKINFOID)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_WORKINFO 所有数据信息.
		/// </summary>
		/// <returns>T_WORKINFO DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql = "select	"
				+ "WORKINFOID"
				+ ",REFOBJID"
				+ ",WORKINFOTYPE"
				+ ",WORKINFONAME"
				+ ",WORKINFODETAIL"
				+ ",WORKINFOSTATE"
				+ ",CIRCLEORTIMING"
				+ ",CIRCLEPERIOD"
				+ ",CIRCLEUNIT"
				+ ",CIRCLEFRONTLIMIT"
				+ ",CIRCLEBACKLIMIT"
				+ ",CIRCLELIMITUNIT"
				+ ",TIMINGPERIOD"
				+ ",TIMINGFRONTLIMIT"
				+ ",TIMINGBACKLIMIT"
				+ ",PRINCIPALPOST"
				+ ",CONFIRMPOST"
				+ ",ISCHECKPROJECT"
				+ ",ISREPAIRPROJECT"
				+ ",SHIP_ID"
				+ ",WORKINFOCODE"
				+ "  from T_WORKINFO ";
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
		/// 根据一个主键ID,得到 T_WORKINFO 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>WorkInfo DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql = "select "
				+ "WORKINFOID"
				+ ",REFOBJID"
				+ ",WORKINFOTYPE"
				+ ",WORKINFONAME"
				+ ",WORKINFODETAIL"
				+ ",WORKINFOSTATE"
				+ ",CIRCLEORTIMING"
				+ ",CIRCLEPERIOD"
				+ ",CIRCLEUNIT"
				+ ",CIRCLEFRONTLIMIT"
				+ ",CIRCLEBACKLIMIT"
				+ ",CIRCLELIMITUNIT"
				+ ",TIMINGPERIOD"
				+ ",TIMINGFRONTLIMIT"
				+ ",TIMINGBACKLIMIT"
				+ ",PRINCIPALPOST"
				+ ",CONFIRMPOST"
				+ ",ISCHECKPROJECT"
				+ ",ISREPAIRPROJECT"
				+ ",SHIP_ID"
				+ ",WORKINFOCODE"
				+ " from T_WORKINFO "
				+ " where upper(WORKINFOID)='" + Id.ToUpper()+"'";
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
		/// 根据workinfo 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>workinfo 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBoxEx.Show(o);
		public WorkInfo getObject(DataRow dr)
		{
			WorkInfo unit=new WorkInfo();
			if (null==dr)
			{
				unit.IsWrong = true;
				unit.WhyWrong = "从数据库获取信息时出错,未成功构造WorkInfo类对象!";
				return unit;
			}
			if (DBNull.Value != dr["WORKINFOID"])	
			    unit.WORKINFOID=dr["WORKINFOID"].ToString();
			if (DBNull.Value != dr["REFOBJID"])	
			    unit.REFOBJID=dr["REFOBJID"].ToString();
			if (DBNull.Value != dr["WORKINFOTYPE"])	
			    unit.WORKINFOTYPE=Convert.ToDecimal(dr["WORKINFOTYPE"]);
			if (DBNull.Value != dr["WORKINFONAME"])	
			    unit.WORKINFONAME=dr["WORKINFONAME"].ToString();
			if (DBNull.Value != dr["WORKINFODETAIL"])	
			    unit.WORKINFODETAIL=dr["WORKINFODETAIL"].ToString();
			if (DBNull.Value != dr["WORKINFOSTATE"])	
			    unit.WORKINFOSTATE=Convert.ToDecimal(dr["WORKINFOSTATE"]);
			if (DBNull.Value != dr["CIRCLEORTIMING"])	
			    unit.CIRCLEORTIMING=Convert.ToDecimal(dr["CIRCLEORTIMING"]);
			if (DBNull.Value != dr["CIRCLEPERIOD"])	
			    unit.CIRCLEPERIOD=Convert.ToDecimal(dr["CIRCLEPERIOD"]);
			if (DBNull.Value != dr["CIRCLEUNIT"])	
			    unit.CIRCLEUNIT=dr["CIRCLEUNIT"].ToString();
			if (DBNull.Value != dr["CIRCLEFRONTLIMIT"])	
			    unit.CIRCLEFRONTLIMIT=Convert.ToDecimal(dr["CIRCLEFRONTLIMIT"]);
			if (DBNull.Value != dr["CIRCLEBACKLIMIT"])	
			    unit.CIRCLEBACKLIMIT=Convert.ToDecimal(dr["CIRCLEBACKLIMIT"]);
			if (DBNull.Value != dr["CIRCLELIMITUNIT"])	
			    unit.CIRCLELIMITUNIT=dr["CIRCLELIMITUNIT"].ToString();
			if (DBNull.Value != dr["TIMINGPERIOD"])	
			    unit.TIMINGPERIOD=Convert.ToDecimal(dr["TIMINGPERIOD"]);
			if (DBNull.Value != dr["TIMINGFRONTLIMIT"])	
			    unit.TIMINGFRONTLIMIT=Convert.ToDecimal(dr["TIMINGFRONTLIMIT"]);
			if (DBNull.Value != dr["TIMINGBACKLIMIT"])	
			    unit.TIMINGBACKLIMIT=Convert.ToDecimal(dr["TIMINGBACKLIMIT"]);
			if (DBNull.Value != dr["PRINCIPALPOST"])	
			    unit.PRINCIPALPOST=dr["PRINCIPALPOST"].ToString();
			if (DBNull.Value != dr["CONFIRMPOST"])	
			    unit.CONFIRMPOST=dr["CONFIRMPOST"].ToString();
			if (DBNull.Value != dr["ISCHECKPROJECT"])	
			    unit.ISCHECKPROJECT=Convert.ToDecimal(dr["ISCHECKPROJECT"]);
			if (DBNull.Value != dr["ISREPAIRPROJECT"])	
			    unit.ISREPAIRPROJECT=Convert.ToDecimal(dr["ISREPAIRPROJECT"]);
			if (DBNull.Value != dr["SHIP_ID"])	
			    unit.SHIP_ID=dr["SHIP_ID"].ToString();
			if (DBNull.Value != dr["WORKINFOCODE"])	
			    unit.WORKINFOCODE=dr["WORKINFOCODE"].ToString();
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个WorkInfo对象.
		/// </summary>
		/// <param name="wORKINFOID">wORKINFOID</param>
		/// <returns>WorkInfo对象</returns>
		public  WorkInfo getObject(string Id,out string err)
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
 
        public List<WorkInfo> GetAllWorkInfoOfAObject(string objectId)
        {
             List<WorkInfo> lstRe = new List<WorkInfo> ();
            sql = "select "
               + "WORKINFOID, "
               + "REFOBJID, "
               + "WORKINFOTYPE, "
               + "WORKINFONAME, "
               + "WORKINFODETAIL, "
               + "WORKINFOSTATE, "
               + "CIRCLEORTIMING, "
               + "CIRCLEPERIOD, "
               + "CIRCLEUNIT, "
               + "CIRCLEFRONTLIMIT, "
               + "CIRCLEBACKLIMIT, "
               + "CIRCLELIMITUNIT, "
               + "TIMINGPERIOD, "
               + "TIMINGFRONTLIMIT, "
               + "TIMINGBACKLIMIT, "
               + "PRINCIPALPOST, "
               + "CONFIRMPOST, "
               + "ISCHECKPROJECT, "
               + "ISREPAIRPROJECT, "
               + "SHIP_ID, "
               + "WORKINFOCODE "
               + " from T_WORKINFO "
               + " where REFOBJID='" + objectId + "'";
            DataTable dt;
            string err;
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                foreach(DataRow dr in dt.Rows)
                {
                    lstRe.Add (getObject(dr));
                }
                return lstRe;
            }
            else
            {
                throw new Exception(err);
            }
        }

        public int getCircleMonth(int value, string unit)
        { 
            unit = unit.Trim();
            if (unit == "月")
                return value;

            if (unit == "年")
            {
                return value * 12;
            }
            if (unit == "日")
            {
                return value / 30;
            }
            return 0;
        }
    }
}
