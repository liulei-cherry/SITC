/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：T_TOOL_WORKINFOService.cs
 * 创 建 人：黄家龙
 * 创建时间：2011/11/23
 * 标    题：数据操作类
 * 功能描述：T_TOOL_WORKINFO数据操作类
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
using Maintenance.DataObject;

namespace  Maintenance.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_TOOL_WORKINFOService.cs
    /// </summary>
    public partial class T_TOOL_WORKINFOService
    {
		#region 构造函数
		/// <summary>
		/// 静态实例对象.
		/// </summary>
		private static T_TOOL_WORKINFOService instance=new T_TOOL_WORKINFOService();
        public static T_TOOL_WORKINFOService Instance
        { 
            get
            {
                if(null==instance)
                {
                    T_TOOL_WORKINFOService.instance = new T_TOOL_WORKINFOService();
                }
                return T_TOOL_WORKINFOService.instance;
            }
        }
		private T_TOOL_WORKINFOService(){}
		#endregion
		
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();        
        string sql = ""; 
		
		#region 添加更新删除
		
		/// <summary>
		/// 向数据库中保存一条新记录。.
		/// </summary>
		/// <param name="unit">T_TOOL_WORKINFO对象</param>
		/// <returns>插入的对象更新</returns>	
		internal bool saveUnit(T_TOOL_WORKINFO unit,out string err)
        {
			if (unit.WORKINFOID!=null && unit.WORKINFOID.Length > 0) //edit
			{
				sql = "UPDATE [T_TOOL_WORKINFO] SET "
					+ " [WORKINFOID] = " + (string.IsNullOrEmpty(unit.WORKINFOID)?"null":"'" + unit.WORKINFOID.Replace ("'","''") + "'")
					+ " , [REFOBJID] = " + (string.IsNullOrEmpty(unit.REFOBJID)?"null":"'" + unit.REFOBJID.Replace ("'","''") + "'")
					+ " , [WORKINFOTYPE] = " + unit.WORKINFOTYPE.ToString()
					+ " , [ORDERNUM_SHOW] = " + (unit.ORDERNUM_SHOW==null?"''":"'" + unit.ORDERNUM_SHOW.Replace ("'","''") + "'")
					+ " , [CLASS1] = " + (unit.CLASS1==null?"''":"'" + unit.CLASS1.Replace ("'","''") + "'")
					+ " , [CLASS2] = " + (unit.CLASS2==null?"''":"'" + unit.CLASS2.Replace ("'","''") + "'")
					+ " , [WORKINFONAME] = " + (unit.WORKINFONAME==null?"''":"'" + unit.WORKINFONAME.Replace ("'","''") + "'")
					+ " , [WORKINFODETAIL] = " + (unit.WORKINFODETAIL==null?"''":"'" + unit.WORKINFODETAIL.Replace ("'","''") + "'")
					+ " , [CIRCLEORTIMING] = " + unit.CIRCLEORTIMING.ToString()
					+ " , [CIRCLEORTIMING_INI] = " + (unit.CIRCLEORTIMING_INI==null?"''":"'" + unit.CIRCLEORTIMING_INI.Replace ("'","''") + "'")
					+ " , [CIRCLEPERIOD] = " + unit.CIRCLEPERIOD.ToString()
					+ " , [CIRCLEPERIOD_INI] = " + (unit.CIRCLEPERIOD_INI==null?"''":"'" + unit.CIRCLEPERIOD_INI.Replace ("'","''") + "'")
					+ " , [CIRCLEUNIT] = " + (unit.CIRCLEUNIT==null?"''":"'" + unit.CIRCLEUNIT.Replace ("'","''") + "'")
					+ " , [CIRCLEFRONTLIMIT] = " + unit.CIRCLEFRONTLIMIT.ToString()
					+ " , [CIRCLEBACKLIMIT] = " + unit.CIRCLEBACKLIMIT.ToString()
					+ " , [CIRCLELIMITUNIT] = " + (unit.CIRCLELIMITUNIT==null?"''":"'" + unit.CIRCLELIMITUNIT.Replace ("'","''") + "'")
					+ " , [TIMINGPERIOD] = " + unit.TIMINGPERIOD.ToString()
					+ " , [TIMINGFRONTLIMIT] = " + unit.TIMINGFRONTLIMIT.ToString()
					+ " , [TIMINGBACKLIMIT] = " + unit.TIMINGBACKLIMIT.ToString()
					+ " , [PRINCIPALPOST] = " + (unit.PRINCIPALPOST==null?"''":"'" + unit.PRINCIPALPOST.Replace ("'","''") + "'")
					+ " , [PRINCIPALPOST_INI] = " + (unit.PRINCIPALPOST_INI==null?"''":"'" + unit.PRINCIPALPOST_INI.Replace ("'","''") + "'")
					+ " , [CONFIRMPOST] = " + (unit.CONFIRMPOST==null?"''":"'" + unit.CONFIRMPOST.Replace ("'","''") + "'")
					+ " , [CONFIRMPOST_INI] = " + (unit.CONFIRMPOST_INI==null?"''":"'" + unit.CONFIRMPOST_INI.Replace ("'","''") + "'")
					+ " , [ISCHECKPROJECT] = " + unit.ISCHECKPROJECT.ToString()
					+ " , [ISCHECKPROJECT_INI] = " + (unit.ISCHECKPROJECT_INI==null?"''":"'" + unit.ISCHECKPROJECT_INI.Replace ("'","''") + "'")
					+ " , [ISREPAIRPROJECT] = " + unit.ISREPAIRPROJECT.ToString()
					+ " , [ISREPAIRPROJECT_INI] = " + (unit.ISREPAIRPROJECT_INI==null?"''":"'" + unit.ISREPAIRPROJECT_INI.Replace ("'","''") + "'")
					+ " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ " , [MONTHS_CHECK] = " + (unit.MONTHS_CHECK==null?"''":"'" + unit.MONTHS_CHECK.Replace ("'","''") + "'")
					+ " , [ISBAK] = " + unit.ISBAK.ToString()
					+ " , [EX1] = " + (unit.EX1==null?"''":"'" + unit.EX1.Replace ("'","''") + "'")
					+ " , [EX2] = " + (unit.EX2==null?"''":"'" + unit.EX2.Replace ("'","''") + "'")
					+ " , [EX3] = " + (unit.EX3==null?"''":"'" + unit.EX3.Replace ("'","''") + "'")
					+ " , [EX4] = " + (unit.EX4==null?"''":"'" + unit.EX4.Replace ("'","''") + "'")
					+ " , [EX5] = " + (unit.EX5==null?"''":"'" + unit.EX5.Replace ("'","''") + "'")
					+ " , [EXCEL_ORDERNUM] = " + unit.EXCEL_ORDERNUM.ToString()
					+ " , [ITEMTYPE] = " + (unit.ITEMTYPE==null?"''":"'" + unit.ITEMTYPE.Replace ("'","''") + "'")
					+ " , [DEPARTMENT_TYPE] = " + unit.DEPARTMENT_TYPE.ToString()
					+ " where upper(WORKINFOID) = '" + unit.WORKINFOID.ToUpper() + "'"; 
			}
			else
			{
				unit.WORKINFOID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_TOOL_WORKINFO] ("
					+ "[WORKINFOID],"
					+ "[REFOBJID],"
					+ "[WORKINFOTYPE],"
					+ "[ORDERNUM_SHOW],"
					+ "[CLASS1],"
					+ "[CLASS2],"
					+ "[WORKINFONAME],"
					+ "[WORKINFODETAIL],"
					+ "[CIRCLEORTIMING],"
					+ "[CIRCLEORTIMING_INI],"
					+ "[CIRCLEPERIOD],"
					+ "[CIRCLEPERIOD_INI],"
					+ "[CIRCLEUNIT],"
					+ "[CIRCLEFRONTLIMIT],"
					+ "[CIRCLEBACKLIMIT],"
					+ "[CIRCLELIMITUNIT],"
					+ "[TIMINGPERIOD],"
					+ "[TIMINGFRONTLIMIT],"
					+ "[TIMINGBACKLIMIT],"
					+ "[PRINCIPALPOST],"
					+ "[PRINCIPALPOST_INI],"
					+ "[CONFIRMPOST],"
					+ "[CONFIRMPOST_INI],"
					+ "[ISCHECKPROJECT],"
					+ "[ISCHECKPROJECT_INI],"
					+ "[ISREPAIRPROJECT],"
					+ "[ISREPAIRPROJECT_INI],"
					+ "[SHIP_ID],"
					+ "[MONTHS_CHECK],"
					+ "[ISBAK],"
					+ "[EX1],"
					+ "[EX2],"
					+ "[EX3],"
					+ "[EX4],"
					+ "[EX5],"
					+ "[EXCEL_ORDERNUM],"
					+ "[ITEMTYPE],"
					+ "[DEPARTMENT_TYPE]"
					+ ") VALUES( "
					+ " " + (string.IsNullOrEmpty(unit.WORKINFOID)?"null":"'" + unit.WORKINFOID.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.REFOBJID)?"null":"'" + unit.REFOBJID.Replace ("'","''") + "'")
					+ " ,"+ unit.WORKINFOTYPE.ToString()
					+ " , " + (unit.ORDERNUM_SHOW==null?"''":"'" + unit.ORDERNUM_SHOW.Replace ("'","''") + "'")
					+ " , " + (unit.CLASS1==null?"''":"'" + unit.CLASS1.Replace ("'","''") + "'")
					+ " , " + (unit.CLASS2==null?"''":"'" + unit.CLASS2.Replace ("'","''") + "'")
					+ " , " + (unit.WORKINFONAME==null?"''":"'" + unit.WORKINFONAME.Replace ("'","''") + "'")
					+ " , " + (unit.WORKINFODETAIL==null?"''":"'" + unit.WORKINFODETAIL.Replace ("'","''") + "'")
					+ " ,"+ unit.CIRCLEORTIMING.ToString()
					+ " , " + (unit.CIRCLEORTIMING_INI==null?"''":"'" + unit.CIRCLEORTIMING_INI.Replace ("'","''") + "'")
					+ " ,"+ unit.CIRCLEPERIOD.ToString()
					+ " , " + (unit.CIRCLEPERIOD_INI==null?"''":"'" + unit.CIRCLEPERIOD_INI.Replace ("'","''") + "'")
					+ " , " + (unit.CIRCLEUNIT==null?"''":"'" + unit.CIRCLEUNIT.Replace ("'","''") + "'")
					+ " ,"+ unit.CIRCLEFRONTLIMIT.ToString()
					+ " ,"+ unit.CIRCLEBACKLIMIT.ToString()
					+ " , " + (unit.CIRCLELIMITUNIT==null?"''":"'" + unit.CIRCLELIMITUNIT.Replace ("'","''") + "'")
					+ " ,"+ unit.TIMINGPERIOD.ToString()
					+ " ,"+ unit.TIMINGFRONTLIMIT.ToString()
					+ " ,"+ unit.TIMINGBACKLIMIT.ToString()
					+ " , " + (unit.PRINCIPALPOST==null?"''":"'" + unit.PRINCIPALPOST.Replace ("'","''") + "'")
					+ " , " + (unit.PRINCIPALPOST_INI==null?"''":"'" + unit.PRINCIPALPOST_INI.Replace ("'","''") + "'")
					+ " , " + (unit.CONFIRMPOST==null?"''":"'" + unit.CONFIRMPOST.Replace ("'","''") + "'")
					+ " , " + (unit.CONFIRMPOST_INI==null?"''":"'" + unit.CONFIRMPOST_INI.Replace ("'","''") + "'")
					+ " ,"+ unit.ISCHECKPROJECT.ToString()
					+ " , " + (unit.ISCHECKPROJECT_INI==null?"''":"'" + unit.ISCHECKPROJECT_INI.Replace ("'","''") + "'")
					+ " ,"+ unit.ISREPAIRPROJECT.ToString()
					+ " , " + (unit.ISREPAIRPROJECT_INI==null?"''":"'" + unit.ISREPAIRPROJECT_INI.Replace ("'","''") + "'")
					+ " , " + (string.IsNullOrEmpty(unit.SHIP_ID)?"null":"'" + unit.SHIP_ID.Replace ("'","''") + "'")
					+ " , " + (unit.MONTHS_CHECK==null?"''":"'" + unit.MONTHS_CHECK.Replace ("'","''") + "'")
					+ " ,"+ unit.ISBAK.ToString()
					+ " , " + (unit.EX1==null?"''":"'" + unit.EX1.Replace ("'","''") + "'")
					+ " , " + (unit.EX2==null?"''":"'" + unit.EX2.Replace ("'","''") + "'")
					+ " , " + (unit.EX3==null?"''":"'" + unit.EX3.Replace ("'","''") + "'")
					+ " , " + (unit.EX4==null?"''":"'" + unit.EX4.Replace ("'","''") + "'")
					+ " , " + (unit.EX5==null?"''":"'" + unit.EX5.Replace ("'","''") + "'")
					+ " ,"+ unit.EXCEL_ORDERNUM.ToString()
					+ " , " + (unit.ITEMTYPE==null?"''":"'" + unit.ITEMTYPE.Replace ("'","''") + "'")
					+ " ,"+ unit.DEPARTMENT_TYPE.ToString()
					+ ")";
			}
	
			return dbAccess.ExecSql(sql, out err);
		}
		/// <summary>
		/// 删除数据表T_TOOL_WORKINFO中的对象.
		/// </summary>
	   /// <param name="unit">要删除的T_TOOL_WORKINFO对象</param>
		internal bool deleteUnit(T_TOOL_WORKINFO unit,out string err)
		{
			return deleteUnit(unit.WORKINFOID,out err);
		}
		
		/// <summary>
		/// 删除数据表T_TOOL_WORKINFO中的一条记录.
		/// </summary>
	   /// <param name="unit">要删除的T_TOOL_WORKINFO.wORKINFOID主键</param>
		public bool deleteUnit(string unitid,out string err)
		{
			sql = "delete from T_TOOL_WORKINFO where "
				+ " upper(T_TOOL_WORKINFO.WORKINFOID)='" + unitid.ToUpper()+ "'";
			return dbAccess.ExecSql(sql, out err);
		}		
		#endregion
		
		#region 数据实体
		/// <summary>
		/// 得到  T_TOOL_WORKINFO 所有数据信息.
		/// </summary>
		/// <returns>T_TOOL_WORKINFO DataTable</returns>
		public DataTable getInfo(out string err)
		{
			sql = "select	"
				+ "WORKINFOID"
				+ ",REFOBJID"
				+ ",WORKINFOTYPE"
				+ ",ORDERNUM_SHOW"
				+ ",CLASS1"
				+ ",CLASS2"
				+ ",WORKINFONAME"
				+ ",WORKINFODETAIL"
				+ ",CIRCLEORTIMING"
				+ ",CIRCLEORTIMING_INI"
				+ ",CIRCLEPERIOD"
				+ ",CIRCLEPERIOD_INI"
				+ ",CIRCLEUNIT"
				+ ",CIRCLEFRONTLIMIT"
				+ ",CIRCLEBACKLIMIT"
				+ ",CIRCLELIMITUNIT"
				+ ",TIMINGPERIOD"
				+ ",TIMINGFRONTLIMIT"
				+ ",TIMINGBACKLIMIT"
				+ ",PRINCIPALPOST"
				+ ",PRINCIPALPOST_INI"
				+ ",CONFIRMPOST"
				+ ",CONFIRMPOST_INI"
				+ ",ISCHECKPROJECT"
				+ ",ISCHECKPROJECT_INI"
				+ ",ISREPAIRPROJECT"
				+ ",ISREPAIRPROJECT_INI"
				+ ",SHIP_ID"
				+ ",MONTHS_CHECK"
				+ ",ISBAK"
				+ ",EX1"
				+ ",EX2"
				+ ",EX3"
				+ ",EX4"
				+ ",EX5"
				+ ",EXCEL_ORDERNUM"
				+ ",ITEMTYPE"
				+ ",DEPARTMENT_TYPE"
				+ "  from T_TOOL_WORKINFO ";
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
		/// 根据一个主键ID,得到 T_TOOL_WORKINFO 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>T_TOOL_WORKINFO DataTable</returns>
		public DataTable getInfo(string Id,out string err)
		{
			sql = "select "
				+ "WORKINFOID"
				+ ",REFOBJID"
				+ ",WORKINFOTYPE"
				+ ",ORDERNUM_SHOW"
				+ ",CLASS1"
				+ ",CLASS2"
				+ ",WORKINFONAME"
				+ ",WORKINFODETAIL"
				+ ",CIRCLEORTIMING"
				+ ",CIRCLEORTIMING_INI"
				+ ",CIRCLEPERIOD"
				+ ",CIRCLEPERIOD_INI"
				+ ",CIRCLEUNIT"
				+ ",CIRCLEFRONTLIMIT"
				+ ",CIRCLEBACKLIMIT"
				+ ",CIRCLELIMITUNIT"
				+ ",TIMINGPERIOD"
				+ ",TIMINGFRONTLIMIT"
				+ ",TIMINGBACKLIMIT"
				+ ",PRINCIPALPOST"
				+ ",PRINCIPALPOST_INI"
				+ ",CONFIRMPOST"
				+ ",CONFIRMPOST_INI"
				+ ",ISCHECKPROJECT"
				+ ",ISCHECKPROJECT_INI"
				+ ",ISREPAIRPROJECT"
				+ ",ISREPAIRPROJECT_INI"
				+ ",SHIP_ID"
				+ ",MONTHS_CHECK"
				+ ",ISBAK"
				+ ",EX1"
				+ ",EX2"
				+ ",EX3"
				+ ",EX4"
				+ ",EX5"
				+ ",EXCEL_ORDERNUM"
				+ ",ITEMTYPE"
				+ ",DEPARTMENT_TYPE"
				+ " from T_TOOL_WORKINFO "
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
		/// 根据t_tool_workinfo 的DataRow封装对象.
		/// </summary>
		/// <param name="dr">一个选定的DataRow对象</param>
		/// <returns>t_tool_workinfo 数据实体</returns>
		///从DataGridView的数据源获取当前选定DataRow的方法.
		///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
		public T_TOOL_WORKINFO getObject(DataRow dr)
		{
			T_TOOL_WORKINFO unit=new T_TOOL_WORKINFO();
			if (null==dr)
			{
				unit.IsWrong = true;
				unit.WhyWrong = "从数据库获取信息时出错,未成功构造T_TOOL_WORKINFO类对象!";
				return unit;
			}
			if (DBNull.Value != dr["WORKINFOID"])	
			    unit.WORKINFOID=dr["WORKINFOID"].ToString();
			if (DBNull.Value != dr["REFOBJID"])	
			    unit.REFOBJID=dr["REFOBJID"].ToString();
			if (DBNull.Value != dr["WORKINFOTYPE"])	
			    unit.WORKINFOTYPE=Convert.ToDecimal(dr["WORKINFOTYPE"]);
			if (DBNull.Value != dr["ORDERNUM_SHOW"])	
			    unit.ORDERNUM_SHOW=dr["ORDERNUM_SHOW"].ToString();
			if (DBNull.Value != dr["CLASS1"])	
			    unit.CLASS1=dr["CLASS1"].ToString();
			if (DBNull.Value != dr["CLASS2"])	
			    unit.CLASS2=dr["CLASS2"].ToString();
			if (DBNull.Value != dr["WORKINFONAME"])	
			    unit.WORKINFONAME=dr["WORKINFONAME"].ToString();
			if (DBNull.Value != dr["WORKINFODETAIL"])	
			    unit.WORKINFODETAIL=dr["WORKINFODETAIL"].ToString();
			if (DBNull.Value != dr["CIRCLEORTIMING"])	
			    unit.CIRCLEORTIMING=Convert.ToDecimal(dr["CIRCLEORTIMING"]);
			if (DBNull.Value != dr["CIRCLEORTIMING_INI"])	
			    unit.CIRCLEORTIMING_INI=dr["CIRCLEORTIMING_INI"].ToString();
			if (DBNull.Value != dr["CIRCLEPERIOD"])	
			    unit.CIRCLEPERIOD=Convert.ToDecimal(dr["CIRCLEPERIOD"]);
			if (DBNull.Value != dr["CIRCLEPERIOD_INI"])	
			    unit.CIRCLEPERIOD_INI=dr["CIRCLEPERIOD_INI"].ToString();
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
			if (DBNull.Value != dr["PRINCIPALPOST_INI"])	
			    unit.PRINCIPALPOST_INI=dr["PRINCIPALPOST_INI"].ToString();
			if (DBNull.Value != dr["CONFIRMPOST"])	
			    unit.CONFIRMPOST=dr["CONFIRMPOST"].ToString();
			if (DBNull.Value != dr["CONFIRMPOST_INI"])	
			    unit.CONFIRMPOST_INI=dr["CONFIRMPOST_INI"].ToString();
			if (DBNull.Value != dr["ISCHECKPROJECT"])	
			    unit.ISCHECKPROJECT=Convert.ToDecimal(dr["ISCHECKPROJECT"]);
			if (DBNull.Value != dr["ISCHECKPROJECT_INI"])	
			    unit.ISCHECKPROJECT_INI=dr["ISCHECKPROJECT_INI"].ToString();
			if (DBNull.Value != dr["ISREPAIRPROJECT"])	
			    unit.ISREPAIRPROJECT=Convert.ToDecimal(dr["ISREPAIRPROJECT"]);
			if (DBNull.Value != dr["ISREPAIRPROJECT_INI"])	
			    unit.ISREPAIRPROJECT_INI=dr["ISREPAIRPROJECT_INI"].ToString();
			if (DBNull.Value != dr["SHIP_ID"])	
			    unit.SHIP_ID=dr["SHIP_ID"].ToString();
			if (DBNull.Value != dr["MONTHS_CHECK"])	
			    unit.MONTHS_CHECK=dr["MONTHS_CHECK"].ToString();
			if (DBNull.Value != dr["ISBAK"])	
			    unit.ISBAK=Convert.ToDecimal(dr["ISBAK"]);
			if (DBNull.Value != dr["EX1"])	
			    unit.EX1=dr["EX1"].ToString();
			if (DBNull.Value != dr["EX2"])	
			    unit.EX2=dr["EX2"].ToString();
			if (DBNull.Value != dr["EX3"])	
			    unit.EX3=dr["EX3"].ToString();
			if (DBNull.Value != dr["EX4"])	
			    unit.EX4=dr["EX4"].ToString();
			if (DBNull.Value != dr["EX5"])	
			    unit.EX5=dr["EX5"].ToString();
			if (DBNull.Value != dr["EXCEL_ORDERNUM"])	
			    unit.EXCEL_ORDERNUM=Convert.ToInt32(dr["EXCEL_ORDERNUM"]);
			if (DBNull.Value != dr["ITEMTYPE"])	
			    unit.ITEMTYPE=dr["ITEMTYPE"].ToString();
			if (DBNull.Value != dr["DEPARTMENT_TYPE"])	
			    unit.DEPARTMENT_TYPE=Convert.ToInt32(dr["DEPARTMENT_TYPE"]);
			
			return unit;
		}
		
		/// <summary>
		/// 根据ID,返回一个T_TOOL_WORKINFO对象.
		/// </summary>
		/// <param name="wORKINFOID">wORKINFOID</param>
		/// <returns>T_TOOL_WORKINFO对象</returns>
		public  T_TOOL_WORKINFO getObject(string Id,out string err)
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
