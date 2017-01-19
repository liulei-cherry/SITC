/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：T_WORKINFO_TEMPLATE_CLASSService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-5-11
 * 标    题：数据操作类
 * 功能描述：T_WORKINFO_TEMPLATE_CLASS数据操作类
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
using Maintenance.DataObject;

namespace  Maintenance.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_WORKINFO_TEMPLATE_CLASSService.cs
    /// </summary>
    public partial class T_WORKINFO_TEMPLATE_CLASSService
    {
        /// <summary>
        /// 通过父节点ID获取tree的子节点集合.
        /// </summary>
        internal List<T_WORKINFO_TEMPLATE_CLASS> GetObjectsByParentId(string parentId)
        {
            List<T_WORKINFO_TEMPLATE_CLASS> lists = new List<T_WORKINFO_TEMPLATE_CLASS>();
            sql = "select * from T_WORKINFO_TEMPLATE_CLASS where PARENT_NODE_ID = '" + parentId.Replace("'", "''") + "' order by sortno";
            sql = sql.Replace("= ''", "is null");
            DataTable dt;
            string err = "";
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lists.Add(getObject(dr));
                }
                return lists;
            }

            throw new Exception(err);

        }
    }
}
