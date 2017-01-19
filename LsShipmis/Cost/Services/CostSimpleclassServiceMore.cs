/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：CostSimpleclassService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-8-24
 * 标    题：数据操作类
 * 功能描述：T_COST_SIMPLECLASS数据操作类
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
    /// 数据层实例化接口类 dbo.T_COST_SIMPLECLASSService.cs
    /// </summary>
    public partial class CostSimpleclassService
    {
        /// <summary>
        /// 得到费用简单分类类型.
        /// </summary>
        /// <returns>T_HOIL DataTable</returns>
        public DataTable getCostSimpleType(out string err)
        {
            sql = "select 'A' as ID,'废旧物资' as name  ";
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
        /// 得到简单分类列表信息.
        /// </summary>
        public DataTable getInfoEx(out string err)
        {
            sql = "select CLASS_ID,NAME"
                + ",case TYPE when 'A' then '废旧物资'  end  TYPE"
                + " from T_COST_SIMPLECLASS  order by type";
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
        /// 根据类型获得分列表信息.
        /// </summary>
        public DataTable getInfoByType(string type,out string err)
        {
            sql = "select CLASS_ID,NAME from T_COST_SIMPLECLASS where type ='" + type + "'";
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
