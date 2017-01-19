/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：ArgumentSetService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-7-27
 * 标    题：数据操作类
 * 功能描述：T_ARGUMENT_SET数据操作类
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
using BaseInfo.DataObject;

namespace BaseInfo.DataAccess
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_ARGUMENT_SETService.cs
    /// </summary>
    public partial class ArgumentSetService
    {
        /// <summary>
        /// 设置默认记账本位币.
        /// </summary>
        /// <param name="defaultCurrency"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool chk_UpdateDefaultCurrency(string defaultCurrencyValue, string defaultCurrencyCode, out string err)
        {
            err = "";
            sql = "UPDATE T_ARGUMENT_SET"
                + " SET CODE_VALUE = '" + defaultCurrencyValue + "'"
                + " WHERE CODE = '" + defaultCurrencyCode + "'";
            return dbAccess.ExecSql(sql, out err);
        }

        /// <summary>
        /// 获取默认本位币.
        /// </summary>
        /// <param name="defaultCurrency"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public string chk_GetDefaultCurrency(string defaultCurrencyCode)
        {
            string value;
            string err = "";
            sql = " SELECT CODE_VALUE "
                + " FROM T_ARGUMENT_SET"
                + " WHERE CODE = '" + defaultCurrencyCode + "'";
            if (!dbAccess.GetString(sql, out value, out err))
                throw new Exception(err);
            return value;
        }

        /// <summary>
        /// 检测参数设置中是否有设置.
        /// </summary>
        /// <param name="defaultCurrencyCode"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool chk_HaveDefaultCurrency(string defaultCurrencyCode, out string err)
        {
            string value;
            err = "";
            sql = " SELECT COUNT(*) "
                + " FROM T_ARGUMENT_SET"
                + " WHERE CODE = '" + defaultCurrencyCode + "'";

            if (dbAccess.GetString(sql, out value, out err))
            {
                if (value == "0")
                {
                    return false;
                }
            }
            return true;
        }

        public bool chk_InsertDefaultCurrency(string defaultCurrencyValue, out string err)
        {
            err = "";
            sql = "INSERT INTO T_ARGUMENT_SET (SYS_ID,CODE,CODE_VALUE,INTRO) "
                + "VALUES ('" + Guid.NewGuid().ToString() + "','SetDefaultCurrency','" + defaultCurrencyValue + "','默认记账本位币' )";
            return dbAccess.ExecSql(sql, out err);
        }
    }
}
