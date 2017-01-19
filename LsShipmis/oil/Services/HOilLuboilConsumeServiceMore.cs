/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：HOilLuboilConsumeService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-7-25
 * 标    题：数据操作类
 * 功能描述：T_HOIL_LUBOIL_CONSUME数据操作类
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

namespace Oil.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_HOIL_LUBOIL_CONSUMEService.cs
    /// </summary>
    public partial class HOilLuboilConsumeService
    {

        /// <summary>
        /// 获得 "年度润滑油各个月份消耗存量" 数据.
        /// </summary>
        public DataTable GetInfoByMonthOil(string ship_id, DateTime? date, string oil_id, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select a.REPORT_ID,convert(varchar(7),a.RECORD_DATE,120) as RECORD_DATE,b.TRADEMARK,b.OIL_NAME, ");
            sb.AppendLine(" a.LASTMONTH_LEFT,a.THISMONTH_ADD,a.THISMONTH_CONSUME,a.THISMONTH_STORE,a.REMARK");
            sb.AppendLine(" from T_HOIL_LUBOIL_CONSUME a  ");
            sb.AppendLine(" inner join T_HOil b on a.Oil_Id = b.Oil_Id ");
            sb.AppendLine(" where ");
            sb.AppendLine(" upper(a.SHIP_ID)='" + ship_id.ToUpper() + "'");
            if (date != null)
                sb.AppendLine(" and DATEDIFF(mm,RECORD_DATE,'" + date + "')=0 ");
            sb.AppendLine(" and a.Oil_Id='" + oil_id + "'");
            sb.AppendLine(" order by a.RECORD_DATE");
            DataTable dt;
            if (dbAccess.GetDataTable(sb.ToString(), out dt, out err))
            {
                return dt;
            }
            else
            {
                throw new Exception(err);
            }

        }

        /// <summary>
        /// 获得 "润滑油月份消耗存量" 数据.
        /// </summary>
        public DataTable getInfoByMonth(string ship_id, DateTime month, out string err)
        {
            //suigy-修改-2015-12-8-版本4.8.4.78-润滑油月消耗存量列表显示调整-start
            /*
            sql = "select a.REPORT_ID,convert(varchar(7),a.RECORD_DATE,120) as RECORD_DATE,c.ForWhichType,b.TRADEMARK,b.OIL_NAME, ";
            sql += " a.LASTMONTH_LEFT,a.THISMONTH_ADD,a.THISMONTH_CONSUME,a.THISMONTH_STORE,a.REMARK";
            sql += "\rfrom T_HOIL_LUBOIL_CONSUME a  ";
            sql += "\rinner join T_HOil b on a.Oil_Id = b.Oil_Id ";
            sql += "\rinner join T_HOil_Ship c on b.Oil_ID = c.Oil_id ";
            sql += "\rwhere upper(a.SHIP_ID)='" + ship_id.ToUpper() + "' and convert(varchar(4),a.RECORD_DATE,120)='" + month.ToString("yyyy") + "'";
            sql += "\r and upper(c.SHIP_ID)='" + ship_id.ToUpper() + "' ";

            sql += "\rorder by a.RECORD_DATE,c.ORDERNUM";
            */
            sql = "select a.REPORT_ID,convert(varchar(7),a.RECORD_DATE,120) as RECORD_DATE,b.TRADEMARK,b.OIL_NAME,  a.LASTMONTH_LEFT,a.THISMONTH_ADD,a.THISMONTH_CONSUME,a.THISMONTH_STORE,a.REMARK ";
            sql += "\r from T_HOIL_LUBOIL_CONSUME a "; 
            sql += "\r inner join T_HOil b on a.Oil_Id = b.Oil_Id ";
            sql += "\r where upper(a.SHIP_ID)='" + ship_id.ToUpper() + "' and convert(varchar(4),a.RECORD_DATE,120)='" + month.ToString("yyyy") + "'";
            sql += "\r order by a.RECORD_DATE ";
            //suigy-修改-2015-12-8-版本4.8.4.78-润滑油月消耗存量列表显示调整-end

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
        /// 获得 "润滑油消耗统计" 数据。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public DataTable getYearSum(DateTime start,DateTime end, out string err)
        {
            string strSql = string.Format(@"select f.ship_id,f.SHIP_NAME,
                            max(case f.LOIL_TYPE when '0' then f.THISMONTH_CONSUME end) TYPE1SUME,
                            max(case f.LOIL_TYPE when '1' then f.THISMONTH_CONSUME end) TYPE2SUME,
                            max(case f.LOIL_TYPE when '2' then f.THISMONTH_CONSUME end) TYPE3SUME from
                            (SELECT b.ship_id,b.ship_name,b.ship_en_name,c.LOIL_TYPE,sum(a.THISMONTH_ADD) THISMONTH_ADD,sum(a.THISMONTH_CONSUME) THISMONTH_CONSUME
                            FROM T_HOIL_LUBOIL_CONSUME a inner join T_Ship b on a.ship_id = b.ship_id
                            inner join T_HOil c on a.Oil_Id = c.Oil_Id
                            where a.RECORD_DATE between '{0}' and  '{1}' and c.LOIL_TYPE in ('0','1','2')
                            group by b.ship_id,b.ship_name,b.ship_en_name,c.LOIL_TYPE) f
                            group by f.ship_id,f.ship_name,f.ship_en_name order by f.ship_en_name"
                            , start.ToString("yyyy-MM-dd"), end.ToString("yyyy-MM-dd"));

            DataTable dt;
            if (dbAccess.GetDataTable(strSql, out dt, out err))
            {
                return dt;
            }
            else
            {
                throw new Exception(err);
            }

        }


        /// <summary>
        /// 获得单船月 "润滑油消耗统计" 数据。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public DataTable getMonthSum(String ship_id,DateTime start, DateTime end, out string err)
        {
            string strSql = string.Format(@"select f.SHIP_NAME,f.record_date,
                            max(case f.LOIL_TYPE when '0' then f.THISMONTH_CONSUME end) TYPE1SUME,
                            max(case f.LOIL_TYPE when '1' then f.THISMONTH_CONSUME end) TYPE2SUME,
                            max(case f.LOIL_TYPE when '2' then f.THISMONTH_CONSUME end) TYPE3SUME from
                            (SELECT convert(varchar(7),a.RECORD_DATE,120) record_date,b.ship_name,c.LOIL_TYPE,sum(a.THISMONTH_CONSUME) THISMONTH_CONSUME
                            FROM T_HOIL_LUBOIL_CONSUME a inner join T_Ship b on a.ship_id = b.ship_id
                            inner join T_HOil c on a.Oil_Id = c.Oil_Id
                            where a.ship_id ='{0}' and a.RECORD_DATE between '{1}' and  '{2}' and c.LOIL_TYPE in ('0','1','2')
                            group by a.record_date,b.ship_name,c.LOIL_TYPE) f
                            group by f.record_date,f.ship_name order by f.record_date"
                            , ship_id, start.ToString("yyyy-MM-dd"), end.ToString("yyyy-MM-dd"));

            DataTable dt;
            if (dbAccess.GetDataTable(strSql, out dt, out err))
            {
                return dt;
            }
            else
            {
                throw new Exception(err);
            }

        }

        /// <summary>
        /// 获得 "月度润滑油（主机气缸油、主机系统油、副机系统油）各个月份消耗存量" 数据.
        /// </summary>
        public DataTable getMainInfoByMonth(string ship_id, DateTime month, bool onlyMain,out string err)
        {
            sql = "select a.REPORT_ID,convert(varchar(7),a.RECORD_DATE,120) as RECORD_DATE,b.TRADEMARK,b.OIL_NAME, ";
            sql += " c.ForWhichType LOIL_TYPE,";
            sql += " a.LASTMONTH_LEFT,a.THISMONTH_ADD,a.THISMONTH_CONSUME,a.THISMONTH_STORE,a.REMARK";
            sql += "\rfrom T_HOIL_LUBOIL_CONSUME a  ";
            sql += "\rinner join T_HOil b on a.Oil_Id = b.Oil_Id ";
            sql += "\rinner join T_HOil_SHIP c on b.Oil_Id = c.Oil_Id ";
            sql += "\rwhere " + (onlyMain ? "b.LOIL_TYPE <> 3 and " : "");
            sql += " upper(a.SHIP_ID)='" + ship_id.ToUpper() + "' and convert(varchar(7),a.RECORD_DATE,120)='" + month.ToString("yyyy-MM") + "'";
            sql += "\rand upper(c.SHIP_ID)='" + ship_id.ToUpper() + "' ";
            sql += "\rorder by c.ORDERNUM,b.ORDERNUM";

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
        /// 获得"年度润滑油单个月份消耗存量"数据.
        /// </summary>
        public DataTable getMainInfoByYearMonth(string ship_id, DateTime yearMonth, out string err)
        {
            sql = "select a.REPORT_ID,convert(varchar(7),a.RECORD_DATE,120) as RECORD_DATE,c.ForWhichType, b.TRADEMARK,b.OIL_NAME, ";
            sql += " a.LASTMONTH_LEFT,a.THISMONTH_ADD,a.THISMONTH_CONSUME,a.THISMONTH_STORE,a.REMARK";
            sql += " from T_HOIL_LUBOIL_CONSUME a  ";
            sql += " inner join T_HOil b on a.Oil_Id = b.Oil_Id inner join T_hoil_ship c on b.Oil_Id = c.Oil_Id and c.ship_id = '" + ship_id + "'";
            sql += " where ";
            sql += " upper(a.SHIP_ID)='" + ship_id.ToUpper() + "' and convert(varchar(7),a.RECORD_DATE,120)='" + yearMonth.ToString("yyyy-MM") + "'";
            sql += " order by c.ORDERNUM, a.RECORD_DATE";

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

    }
}
