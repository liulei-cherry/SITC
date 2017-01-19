/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：ReportMajorEquipmentService.cs
 * 创 建 人：黄家龙
 * 创建时间：2011/9/1
 * 标    题：数据操作类
 * 功能描述：T_REPORT_MAJOREQUIPTIME数据操作类
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

namespace CustomerTable.Haifeng.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_REPORT_MAJOREQUIPTIMEService.cs
    /// </summary>
    public partial class ReportMajorEquipmentService
    {
        /// <summary>
        /// 获取记录信息.
        /// </summary>
        /// <param name="ship_id"></param>
        /// <param name="year"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public DataTable getInfoByYear(string ship_id, DateTime year, out string err)
        {
            sql = " SELECT Report_MajorEquipTime_Id "
                + ",CONVERT(varchar(10), Cabin_StatisticsDate, 102) as Cabin_StatisticsDate"
                + ",Voyage"
                + ",Cabin_HostTotal"
                + ",ChiefSign";
            sql += " FROM [T_REPORT_MAJOREQUIPTIME]";
            sql += " WHERE UPPER(SHIP_Id)= '" + ship_id.ToUpper() + "'"
                + " and CONVERT(varchar(4),[Cabin_StatisticsDate],102)='" + year.ToString("yyyy") + "'";
            sql += " ORDER BY [Cabin_StatisticsDate] ";

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

        /// <summary>
        /// 检查某月统计信息是否已经存在.
        /// </summary>
        /// <param name="apply_id"></param>
        /// <returns></returns>
        public bool CheckSubDetail(string apply_id, string ship_id)
        {
            sql = "select count(1) "
                + "  from T_REPORT_MAJOREQUIPTIME T";
            sql += " where convert(varchar(7),T.Cabin_StatisticsDate,102)= '" + apply_id + "'";
            sql += "  and  upper(SHIP_Id)= '" + ship_id.ToUpper() + "'";

            if (dbAccess.GetString(sql) == "0")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
