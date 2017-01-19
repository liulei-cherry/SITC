/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：HOilLuboilReportService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-8-19
 * 标    题：数据操作类
 * 功能描述：T_HOIL_LUBOIL_REPORT数据操作类
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
    /// 数据层实例化接口类 dbo.T_HOIL_LUBOIL_REPORTService.cs
    /// </summary>
    public partial class HOilLuboilReportService
    {

        /// <summary>
        /// 获得 "年度润滑油月份消耗存量报告" 数据.
        /// </summary>
        public DataTable getInfoByYear(string ship_id, DateTime year, out string err)
        {
            sql = "select a.REPORT_ID,convert(varchar(7),a.REPORT_DATE,120) as REPORT_DATE, ";
            sql += " a.REMARK,a.APPROVER,a.APPROVER2, ";
            sql += " case when a.CHECKED = '0' then '船舶端未审核' "
                + "   when a.CHECKED = '1' then '船端已审核' "
                + "   when a.CHECKED = '2' then '已经同步SAP' "
                + "   end  CHECKED ";
            sql += " from T_HOIL_LUBOIL_REPORT a  ";
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
        /// 是否本月数据已审核通过（船舶端审核是否通过、岸端是否进入SAP）
        /// </summary>
        public bool IfTheMonthChecked(string ship_id, DateTime yearMonth,bool landOrShip, out string err)
        {
            if (landOrShip)
            {
                sql = "select a.REPORT_ID ";
                sql += "\rfrom T_HOIL_LUBOIL_REPORT a  ";
                sql += "\rwhere ";
                sql += "\rupper(a.SHIP_ID)='" + ship_id.ToUpper() + "' and convert(varchar(7),a.REPORT_DATE,120)='"
                + yearMonth.ToString("yyyy-MM") + "' and CHECKED>1";
            }else{
                sql = "select a.REPORT_ID ";
                sql += "\rfrom T_HOIL_LUBOIL_REPORT a  ";
                sql += "\rwhere ";
                sql += "\rupper(a.SHIP_ID)='" + ship_id.ToUpper() + "' and convert(varchar(7),a.REPORT_DATE,120)='"
                + yearMonth.ToString("yyyy-MM") + "' and CHECKED>0";
            }


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

        /// <summary>
        /// 是否已有本月数据.
        /// </summary>
        public bool IfHaveByYearMonth(string ship_id, DateTime yearMonth, out string err)
        {
            sql = "select a.REPORT_ID ";
            sql += " from T_HOIL_LUBOIL_REPORT a  ";
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

        /// <summary>
        /// 获取用于创建同步（与SAP的同步）的数据.
        /// </summary>
        public bool GetLubOilExpenseToSAP(string id, out DataTable dtb, out string err)
        {
            //变量定义部分.
            string sSql = "";                   //查询数据所需的SQL语句.
            //Select语句加工部分.
            //领用接口格式:MATERIAL,QUANTITY,SHIP_ID,UUID

            sSql = @"select 
                    b.OIL_ID as MATERIAL
                    ,b.THISMONTH_CONSUME as QUANTITY
                    ,a.ship_id as SHIP_ID
                    ,b.REPORT_ID as UUID 
                    ,mm.MATERIAL_MAPPING_ID
                    ,mm.MANAGEMENT
                    ,mm.MATERIAL_FINANCE
                    ,mm.COST_FINANCE
                    ,mm.STATUS
                    ,ss.STORAGE_QUANTITY
                     from T_HOIL_LUBOIL_REPORT a
                    inner join T_HOIL_LUBOIL_CONSUME b on  a.SHIP_ID = b.SHIP_ID 
                    inner join T_HOil h on h.Oil_Id = b.Oil_Id 
                    Left join T_MATERIAL_MAPPING mm on  mm.MANAGEMENT=b.OIL_ID
                    left join t_sap_storage ss on ss.material_mapping_id=mm.material_mapping_id and ss.ship_id=a.ship_Id
                     where convert(varchar(7),a.REPORT_DATE,120) = convert(varchar(7),b.RECORD_DATE,120)
                    and h.LOIL_TYPE <> 3 
                    and a.REPORT_ID = '" + id + "'";
            return dbAccess.GetDataTable(sSql, out dtb, out err);
        }
    }
}
