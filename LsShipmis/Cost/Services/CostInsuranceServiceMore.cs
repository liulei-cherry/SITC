/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：CostInsuranceService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-8-24
 * 标    题：数据操作类
 * 功能描述：T_COST_INSURANCE数据操作类
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
    /// 数据层实例化接口类 dbo.T_COST_INSURANCEService.cs
    /// </summary>
    public partial class CostInsuranceService
    {

        /// <summary>
        /// 得到保险费用列表信息.
        /// </summary>
        public DataTable getInfoByYear(string ship_id, DateTime year, out string err)
        {
            sql = "select a.WASTE_ID,convert(varchar(10),a.POLICY_DATE,120) as POLICY_DATE, "
                    + "case when a.STATIC = '0' then '未提交' "
                    + "   when a.STATIC = '1' then '提交办理' "
                    + "   when a.STATIC = '2' then '已经理赔' "
                    + "   when a.STATIC = '3' then '拒绝理赔' "
                    + "   end  STATIC";
            sql += " ,a.DESCRIPTE,b.CURRENCYNAME,a.PUBLIC_AMOUNT,a.INSURANCE_COMPANY";
            sql += " from T_COST_INSURANCE a, T_CURRENCY b";
            sql += " where  a.CURRENCY_ID = b.CURRENCYID and upper(a.SHIP_ID)='" + ship_id.ToUpper() + "' and convert(varchar(4),a.POLICY_DATE,120)='" + year.ToString("yyyy") + "'";
            sql += " order by a.POLICY_DATE";

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
        /// 得到状态列表.
        /// </summary>
        public DataTable getStatic(out string err)
        {
            ///保险状态（0：未提交、1：提交办理、2：已经理赔、3：拒绝理赔）.
            sql = " select '0' as ID,'未提交' as name from T_SHIP union	"
                + " select '1' as ID,'提交办理' as name from T_SHIP union"
                + " select '2' as ID,'已经理赔' as name from T_SHIP union"
                + " select '3' as ID,'拒绝理赔' as name from T_SHIP ";
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
