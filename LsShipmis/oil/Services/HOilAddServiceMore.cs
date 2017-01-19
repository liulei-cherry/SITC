/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：HOilAddService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-7-25
 * 标    题：数据操作类
 * 功能描述：T_HOIL_ADD数据操作类
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
    /// 数据层实例化接口类 dbo.T_HOIL_ADDService.cs
    /// </summary>
    public partial class HOilAddService
    {

        /// <summary>
        /// 获得 "年度加燃油" 数据.
        /// </summary>
        public DataTable getInfoByYear(string ship_id, DateTime year, out string err)
        {
            sql = "select a.FUEL_ID,a.ADD_DATE,b.CNAME, ";
            sql += " case OIL_TYPE when 'A' then '重油' when 'B' then '轻油' end  OIL_TYPE,";
            sql += " a.SPECIFICATION,a.AMOUNT,a.SULPHUR,a.DENSITY,a.REMARK";
            sql += " from T_HOIL_ADD a, T_BASE_PORT b  ";
            sql += " where  a.PORT_ID = b.PORTID and ";
            sql += " upper(a.SHIP_ID)='" + ship_id.ToUpper() + "' and convert(varchar(4),a.ADD_DATE,120)='" + year.ToString("yyyy") + "'";
            sql += " order by a.ADD_DATE";

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
        /// 获得 "月度加燃油" 数据.
        /// </summary>
        public DataTable getInfoByMonth(string ship_id, DateTime month, out string err)
        {
            sql = "select a.FUEL_ID,a.ADD_DATE,b.CNAME, ";
            sql += " case OIL_TYPE when 'A' then '重油' when 'B' then '轻油' end  OIL_TYPE,";
            sql += " a.SPECIFICATION,a.AMOUNT,a.SULPHUR,a.DENSITY,a.REMARK";
            sql += " from T_HOIL_ADD a, T_BASE_PORT b  ";
            sql += " where  a.PORT_ID = b.PORTID and ";
            sql += " upper(a.SHIP_ID)='" + ship_id.ToUpper() + "' and convert(varchar(7),a.ADD_DATE,120)='" + month.ToString("yyyy-MM") + "'";
            sql += " order by a.ADD_DATE,a.OIL_TYPE";

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
