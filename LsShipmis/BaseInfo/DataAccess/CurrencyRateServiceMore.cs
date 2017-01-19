/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：CurrencyRateService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-7-4
 * 标    题：数据操作类
 * 功能描述：T_CURRENCY_EXCHANGE_RATE数据操作类
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

namespace BaseInfo.DataAccess
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_CURRENCY_EXCHANGE_RATEService.cs
    /// </summary>
    public partial class CurrencyRateService 
    {

        /// <summary>
        /// 得到  T_CURRENCY_EXCHANGE_RATE 所有数据信息(扩展方法)
        /// </summary>
        /// <returns>T_CURRENCY_EXCHANGE_RATE DataTable</returns>
        public DataTable getInfoEx(out string err)
        {
            sql = "select	"
                + "RATEID"
                + ",b.CURRENCYNAME as B_CURRENCY "
                + ",c.CURRENCYNAME as E_CURRENCY"
                + ",EXCHANGERATE"
                + ",USEFULDATEFROM"
                + ",USEFULDATEEND"
                + ",ISUSEFULL"
                + ", case ISUSEFULL when 0 then  '否' else '是' end as ISUSE"
                + ",a.REMARK"
                + "  from T_CURRENCY_EXCHANGE_RATE a left join T_CURRENCY b on a.BASECURRENCY = b.CURRENCYID ";
            sql += " left join T_CURRENCY c on a.EXCHANGECURRENCY = c.CURRENCYID";
            sql += " order by B_CURRENCY, USEFULDATEFROM DESC";
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
        /// 得到对美元汇率集合.
        /// </summary>
        /// <param name="DefaultCurrency">本位币种代码如'USD'</param>
        /// <param name="exchangeDate"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public Dictionary<string, string> getRateByUSD(string DefaultCurrency,DateTime exchangeDate, out string err)
        {
            sql = "select a.BASECURRENCY,EXCHANGERATE from T_CURRENCY_EXCHANGE_RATE a left join T_CURRENCY b on a.EXCHANGECURRENCY = b.CURRENCYID ";
            sql += " where a.ISUSEFULL = 1 and b.CURRENCYCODE = '" + DefaultCurrency.ToUpper() + "' and USEFULDATEFROM <= " + dbOperation.DbToDate(exchangeDate);//dbOperation .DbToDate (exchangeDate.AddDays(1));
            sql += " and USEFULDATEEND >= " +dbOperation .DbToDate (exchangeDate) ;

            DataTable dt;
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                Dictionary<string, string> discRate = new Dictionary<string, string>();
                foreach (DataRow row in dt.Rows) {
                    discRate.Add(row["BASECURRENCY"].ToString(), row["EXCHANGERATE"].ToString());
                }

                return discRate;
            }
            else
            {
                throw new Exception(err);
            }
        }

        #region 查询兑换汇率-liulei/2015/11/10
        /// <summary>
        /// 查询兑换汇率.
        /// </summary>
        /// <param name="BaseCurrencyId">本币</param>
        /// <param name="ExchangeCurCode">兑换货币,一般是美元</param>
        /// <param name="date">日期</param>
        /// <param name="err">错误信息</param>
        /// <returns></returns>
        public DataTable GetRateByTime(string BaseCurrencyId, string ExchangeCurCode, DateTime date, out string err)
        {
            string sql = string.Format(@"select a.BASECURRENCY, b.CURRENCYNAME ExchangeCurName, b.CURRENCYCODE,
a.EXCHANGERATE 
,a.USEFULDATEFROM
,a.USEFULDATEEND
from T_CURRENCY_EXCHANGE_RATE a left join 
T_CURRENCY b on a.EXCHANGECURRENCY = b.CURRENCYID  
where a.ISUSEFULL = 1  
and a.BASECURRENCY='{0}'
and b.CURRENCYCODE = '{1}'
and USEFULDATEFROM <=  cast('{2}' as datetime)  
and USEFULDATEEND >=  cast('{3}' as datetime) ", BaseCurrencyId, ExchangeCurCode, date.Date.AddSeconds(1), date.Date.AddSeconds(1));
            return dbAccess.GetDataTable(sql, out err);

        }
        #endregion

        #region 查询除指定id之外的兑换汇率-liulei/2015/11/10
        /// <summary>
        /// 查询兑换汇率.
        /// </summary>
        /// <param name="BaseCurrencyId">本币</param>
        /// <param name="ExchangeCurCode">兑换货币,一般是美元</param>
        /// <param name="date">日期</param>
        /// <param name="err">错误信息</param>
        /// <returns></returns>
        public DataTable GetOtherRateByTime(string BaseCurrencyId, string ExchangeCurCode, DateTime date, string id, out string err)
        {
            string sql = string.Format(@"select a.BASECURRENCY, b.CURRENCYNAME ExchangeCurName, b.CURRENCYCODE,
a.EXCHANGERATE 
from T_CURRENCY_EXCHANGE_RATE a left join 
T_CURRENCY b on a.EXCHANGECURRENCY = b.CURRENCYID  
where a.ISUSEFULL = 1  
and a.BASECURRENCY='{0}'
and b.CURRENCYCODE = '{1}'
and USEFULDATEFROM <=  cast('{2}' as datetime)  
and USEFULDATEEND >=  cast('{3}' as datetime) 
and RATEID<>'{4}'", BaseCurrencyId, ExchangeCurCode, date.Date.AddSeconds(1), date.Date.AddSeconds(1), id);
            return dbAccess.GetDataTable(sql, out err);

        }
        #endregion

        #region 查询兑换汇率-liulei/2015/11/10
        /// <summary>
        /// 查询兑换汇率.
        /// </summary>
        /// <param name="BaseCurrencyId">本币</param>
        /// <param name="ExchangeCurCode">兑换货币,一般是美元</param>
        /// <param name="date">日期</param>
        /// <param name="err">错误信息</param>
        /// <returns></returns>
        public decimal GetOneRateByTime(string BaseCurrencyId, string ExchangeCurCode, DateTime date, out string err)
        {
            DataTable dt = GetRateByTime(BaseCurrencyId, ExchangeCurCode, date.Date, out err);
            if (dt != null && dt.Rows.Count > 0)
            {
                return decimal.Parse(dt.Rows[0]["EXCHANGERATE"].ToString());
            }
            else
            {
                return 0;                
            }

        }
        #endregion


    }
}
