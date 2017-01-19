/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：HOilConsumeService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-7-25
 * 标    题：数据操作类
 * 功能描述：T_HOIL_CONSUME数据操作类
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
    /// 数据层实例化接口类 dbo.T_HOIL_CONSUMEService.cs
    /// </summary>
    public partial class HOilConsumeService
    {

        /// <summary>
        /// 获得 "年度燃油月消耗" 数据.
        /// </summary>
        public DataTable getInfoByYear(string ship_id, DateTime year, out string err)
        {

            sql = "select a.FUEL_ID, convert(varchar(7),a.CONSUME_MONTH,120) as CONSUME_MONTH,";
            sql += " case OIL_TYPE when 'A' then '重油' when 'B' then '轻油' end  OIL_TYPE,";
            sql += " case CONSUME_TYPE when 'A' then '主机' when 'B' then '副机' when 'C' then '锅炉' end  CONSUME_TYPE, ";
            sql += " a.SPECIFICATION,a.AMOUNT,a.SULPHUR,a.DENSITY,a.REMARK";
            sql += " from T_HOIL_CONSUME a  ";
            sql += " where ";
            sql += " upper(a.SHIP_ID)='" + ship_id.ToUpper() + "' and convert(varchar(4),a.CONSUME_MONTH,120)='" + year.ToString("yyyy") + "'";
            sql += " order by a.CONSUME_MONTH";

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
        /// 获得 "月度燃油月消耗" 数据.
        /// </summary>
        public DataTable getInfoByMonth(string ship_id, DateTime month, out string err)
        {

            sql = "select a.FUEL_ID,a.CONSUME_MONTH, ";
            sql += " case OIL_TYPE when 'A' then '重油' when 'B' then '轻油' end  OIL_TYPE,";
            sql += " case CONSUME_TYPE when 'A' then '主机' when 'B' then '副机' when 'C' then '锅炉' end  CONSUME_TYPE, ";
            sql += " a.SPECIFICATION,a.AMOUNT,a.SULPHUR,a.DENSITY,a.REMARK";
            sql += " from T_HOIL_CONSUME a  ";
            sql += " where ";
            sql += " upper(a.SHIP_ID)='" + ship_id.ToUpper() + "' and convert(varchar(7),a.CONSUME_MONTH,120)='" + month.ToString("yyyy-MM") + "'";
            sql += " order by a.CONSUME_MONTH";

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
        /// 获得 "月度燃油月消耗" 对象.
        /// </summary>
        public HOilConsume getObjectByMonth(string ship_id, DateTime month, string type,string consumeType, out string err)
        {
            sql = "select * ";
            sql += " from T_HOIL_CONSUME a  ";
            sql += " where ";
            sql += " upper(a.SHIP_ID)='" + ship_id.ToUpper() + "' and convert(varchar(7),a.CONSUME_MONTH,120)='" + month.ToString("yyyy-MM") + "'";
            sql += " and OIL_TYPE ='" + type + "' and CONSUME_TYPE ='" + consumeType + "'";

            DataTable dt;
            dbAccess.GetDataTable(sql, out dt, out err);
            if (dt.Rows.Count > 0)
            {
                return getObject(dt.Rows[0]);
            }
            else {
                return null;
            }
        }
    }
}
