/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：CostBudgetService.cs
 * 创 建 人：王鹏程
 * 创建时间：2012/3/21
 * 标    题：数据操作类
 * 功能描述：T_COST_BUDGET数据操作类
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

namespace Cost.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_COST_BUDGETService.cs
    /// </summary>
    public partial class CostBudgetService
    {
        /// <summary>
        /// 根据条件得到  T_COST_BUDGET 所有数据信息.
        /// </summary>
        /// <returns>T_COST_BUDGET DataTable</returns>
        public bool GetInfoByYear(string year, string STATE, out DataTable dt, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select	");
            sb.AppendLine("cb.BUDGET_ID");
            sb.AppendLine(",cb.STATE");
            //sb.AppendLine(",case cb.STATE when 1 then '未提交' when 2 then '审核中' when 3 then '被打回' when 4 then '审核完毕' when 5 then '已同步SAP' end as STATE_NAME");
            sb.AppendLine(",cb.CREATE_DATE");
            sb.AppendLine(",cb.APPROVE_NUM");
            sb.AppendLine(",cb.REMARK");
            sb.AppendLine(",cb.S_CNY_AMOUNT");
            sb.AppendLine(",cb.S_USD_AMOUNT");
            sb.AppendLine(",cb.S_EUR_AMOUNT");
            sb.AppendLine(",cb.S_JPY_AMOUNT");
            sb.AppendLine(",cb.Y_CNY_AMOUNT");
            sb.AppendLine(",cb.Y_USD_AMOUNT");
            sb.AppendLine(",cb.Y_EUR_AMOUNT");
            sb.AppendLine(",cb.Y_JPY_AMOUNT");
            sb.AppendLine(",cb.X_CNY_AMOUNT");
            sb.AppendLine(",cb.X_USD_AMOUNT");
            sb.AppendLine(",cb.X_EUR_AMOUNT");
            sb.AppendLine(",cb.X_JPY_AMOUNT");
            sb.AppendLine(",vc.post");
            sb.AppendLine("  from T_COST_BUDGET cb");
            sb.AppendLine(" left join V_CHECK vc on cb.BUDGET_ID = vc.business_id ");
            sb.AppendLine("where 1=1");
            if (!string.IsNullOrEmpty(year))
                sb.AppendLine(" and YEAR(cb.CREATE_DATE)=" + year);
            if (!string.IsNullOrEmpty(STATE))
                sb.AppendLine(" and cb.STATE=" + STATE);
            sb.AppendLine(" order by cb.create_date desc");
            return dbAccess.GetDataTable(sb.ToString(), out dt, out err);
        }
        /// <summary>
        /// 预算年
        /// </summary>
        public DataTable GetGroupYear()
        {
            string err;
            string sql = @"SELECT convert(varchar,year(create_date)) annual from T_COST_BUDGET
group by year(create_date) order by year(create_date)";
            DataTable dt;
            if (!dbAccess.GetDataTable(sql, out dt, out err))
                throw new Exception(err);
            return dt;
        }
        /// <summary>
        /// 删除数据表T_COST_BUDGET中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_COST_BUDGET.bUDGET_ID主键</param>
        public string deleteUnit(string unitid)
        {
            sql = "delete from T_COST_BUDGET where "
                + " upper(T_COST_BUDGET.BUDGET_ID)='" + unitid.ToUpper() + "'";
            return sql;
        }
        /// <summary>
        /// 执行执行.
        /// </summary>
        public bool ExecSql(List<string> sqlList, out string err)
        {
            return dbAccess.ExecSql(sqlList, out err);
        }
    }
}
