/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：HOilWaterService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-7-25
 * 标    题：数据操作类
 * 功能描述：T_HOIL_WATER数据操作类
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
    /// 数据层实例化接口类 dbo.T_HOIL_WATERService.cs
    /// </summary>
    public partial class HOilWaterService
    {

        /// <summary>
        /// 获得 "年度加淡水" 数据.
        /// </summary>
        public DataTable getInfoByYear(string ship_id, DateTime year, out string err)
        {
            sql = "select a.FUEL_ID,a.ADD_DATE,b.CNAME,a.PRE_AMOUNT,a.ADD_AMOUNT,a.REMARK ";
            sql += " from T_HOIL_WATER a, T_BASE_PORT b  ";
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
        
    }
}
