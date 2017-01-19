/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：HOilReportService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-7-25
 * 标    题：数据操作类
 * 功能描述：T_HOIL_REPORT数据操作类
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
    /// 数据层实例化接口类 dbo.T_HOIL_REPORTService.cs
    /// </summary>
    public partial class HOilReportService
    {

        /// <summary>
        /// 获得 "船舶燃、润油月度消耗报表" 数据.
        /// </summary>
        public DataTable getInfoByYear(string ship_id, DateTime year, out string err)
        {
            sql = "select a.REPORT_ID,convert(varchar(7),a.REPORT_DATE,120) as REPORT_DATE, ";
            sql += " a.WLEFT_AMOUNT,a.LLEFT_AMOUNT,(CAST(a.SAIL_DAY AS varchar(4))  + '天' + CAST(a.SAIL_HOUR AS varchar(4))  + '小时') as  SAIL_DAY ";
            sql += " from T_HOIL_REPORT a  ";
            sql += " where ";
            sql += " upper(a.SHIP_ID)='" + ship_id.ToUpper() + "' and convert(varchar(4),a.REPORT_DATE,120)='" + year.ToString("yyyy") + "'";
            sql += " order by a.REPORT_DATE";

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
        /// 是否已有本月数据.
        /// </summary>
        public bool ifHaveByYearMonth(string ship_id, DateTime yearMonth, out string err)
        {
            sql = "select a.REPORT_ID ";
            sql += " from T_HOIL_REPORT a  ";
            sql += " where ";
            sql += " upper(a.SHIP_ID)='" + ship_id.ToUpper() + "' and convert(varchar(7),a.REPORT_DATE,120)='" + yearMonth.ToString("yyyy-MM") + "'";

            DataTable dt;
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                return dt.Rows.Count > 0 ? true : false;
            }
            else
            {
                throw new Exception(err);
            }

        }

    }
}
