/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：T_WORKINFO_TEMPLETService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-5-12
 * 标    题：数据操作类
 * 功能描述：T_WORKINFO_TEMPLET数据操作类
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
    /// 数据层实例化接口类 dbo.T_WORKINFO_TEMPLETService.cs
    /// </summary>
    public partial class T_WORKINFO_TEMPLETService
    {

		#region 数据实体

		/// <summary>
		/// 根据一个主键ID,得到 T_WORKINFO_TEMPLET 的DataTable
		/// </summary>
		/// <param name="Id">主键ID</param>
		/// <returns>T_WORKINFO_TEMPLET DataTable</returns>
		public DataTable getInfoByClass(string class_id,out string err)
		{
			sql = "select "
				+ "WORKINFO_TEMPLET_ID"
				+ ",COMPONENTREFERENCE"
				+ ",ITEMNAME"
				+ ",ITEMCONTENT"
				+ ",PERIOD"
				+ ",PERIODICAL"
                + ",PERIODICAL as PERIODICALDISPLAY"
                + ",TIMINGPERIOD"
				+ ",REMARK"
				+ ",CLASS_ID"
				+ " from T_WORKINFO_TEMPLET "
                + " where upper(CLASS_ID)='" + class_id.ToUpper() + "' order by ITEMNAME";
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
        /// 根据一个主键ID,和集合lstExist 得到 T_WORKINFO_TEMPLET 的DataTable
        /// </summary>
        public DataTable getDetail(string class_id, List<string> lstExist, out string err)
        {
            err = "";

            sql = "select "
                + "WORKINFO_TEMPLET_ID"
                + ",COMPONENTREFERENCE"
                + ",ITEMNAME"
                + ",ITEMCONTENT"
                + ",PERIOD"
                + ",PERIODICAL"
                + ",TIMINGPERIOD"
                + ",REMARK"
                + ",CLASS_ID"
                + " from T_WORKINFO_TEMPLET "
                + " where upper(CLASS_ID)='" + class_id.ToUpper() + "'";

            if (lstExist.Count > 0)
            {
                string notIn = "";
                foreach (string stemp in lstExist)
                {
                    notIn += "'" + stemp.Replace("'", "''") + "',";
                }
                notIn = notIn.Substring(0, notIn.Length - 1);
                sql += " and ITEMNAME not in (" + notIn + ")";
            }
            sql += "\rorder by COMPONENTREFERENCE,ITEMNAME,ITEMCONTENT";
            DataTable dt = new DataTable();

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
