/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：CostDisorderService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-8-24
 * 标    题：数据操作类
 * 功能描述：T_COST_DISORDER数据操作类
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
using Cost.DataObject;

namespace  Cost.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_COST_DISORDERService.cs
    /// </summary>
    public partial class CostDisorderService
    {
        /// <summary>
        /// 得到船舶费用列表信息.
        /// </summary>
        public DataTable getInfoByYear(string ship_id, DateTime year, out string err)
        {
            sql = "select a.COSTS_ID,convert(varchar(10),a.OCCURENCY_DATE,120) as OCCURENCY_DATE,b.NAME"
                    + ",a.DESCRIPTION, ESTIMATE_AMOUNT,PLACE"
                    + " from T_COST_DISORDER a, T_COST_SIMPLECLASS b";
            sql += " where  a.CLASS_ID = b.CLASS_ID and upper(a.SHIP_ID)='" + ship_id.ToUpper() + "' and convert(varchar(4),a.OCCURENCY_DATE,120)='" + year.ToString("yyyy") + "'";
            sql += " order by a.OCCURENCY_DATE";
            
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
