/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：T_COST_ANNUAL_BUDGETService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-6-28
 * 标    题：数据操作类
 * 功能描述：T_COST_ANNUAL_BUDGET数据操作类
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
using Cost.DataObject;

namespace  Cost.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_COST_ANNUAL_BUDGETService.cs
    /// </summary>
    public partial class ANNUAL_BUDGETService
    {

        /// <summary>
        /// 获得 "年度预算" 数据.
        /// </summary>
        public DataTable getInfoByYear(string ship_id, DateTime year, out string err)
        {
            sql = "select a.BUDGET_ID,a.NODE_ID,b.NODE_NAME,convert(varchar(4),a.YEAR_DATE,120) as YEAR_DATE,a.SHIP_ID,AMOUNT ,'USD' as Currency" 
            + " from T_COST_ANNUAL_BUDGET a, T_COST_ACCOUNT b  ";
            sql += " where  a.NODE_ID = b.NODE_ID and  upper(a.SHIP_ID)='" + ship_id.ToUpper() + "' and convert(varchar(4),a.YEAR_DATE,120)='" + year.ToString("yyyy") + "'";
            sql += " order by b.ORDER_NUM";
           
            DataTable dt;
            if (dbAccess.GetDataTable(sql,out dt, out err))
            {
                return dt;
            }
            else {
                throw new Exception(err);
            }
            
        }

        /// <summary>
        /// 批量生成单船 "年度预算" 数据.
        /// </summary>
        public DataTable createByYear(string ship_id, DateTime year, out string err)
        {

            //当插入新的年度预算信息时 保证以前的信息不被删除
            string sql = string.Format (@"INSERT  INTO dbo.T_COST_ANNUAL_BUDGET  
                                            SELECT newid(),NODE_ID, '{0}','{1}',0 
                                            FROM T_COST_ACCOUNT where PARENT_NODE_ID is null and 
                                            node_id not in(select NODE_ID from T_COST_ANNUAL_BUDGET 
                                            where convert(varchar(4),YEAR_DATE,120)=Substring('{0}',1,4) and  SHIP_ID ='{1}')", year.ToString(), ship_id);

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
