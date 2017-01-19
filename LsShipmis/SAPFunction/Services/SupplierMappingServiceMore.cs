/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：SupplierMappingService.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/6/20
 * 标    题：数据操作类
 * 功能描述：T_SUPPLIER_MAPPING数据操作类
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
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using SAPFunction.DataObject;

namespace SAPFunction.Services
{
    public partial class SupplierMappingService
    {
        /// <summary>
        /// 得到  T_SUPPLIER_MAPPING 所有数据信息.
        /// </summary>
        /// <returns>T_SUPPLIER_MAPPING DataTable</returns>
        public DataTable GetAllInfo(out string err)
        {
            sql = "select	"
                 + "sm.SUPPLIER_MAPPING_ID "
                 + ",mf.manufacturer_name "
                 + ",sm.MANAGEMENT "
                 + ",sm.FINANCE "
                 + ",sm.STATUS "
                 + ",case sm.status "
                 + "when '1' then '不存在' "
                 + "when '2' then '错误' "
                 + "when '3' then '未校验' "
                 + "when '4' then '有效'  "
                 + "when '5' then 'SAP方法调用失败' "
                 + "end as STATUS_NAME  "
                 + "from T_SUPPLIER_MAPPING sm "
                 + "inner join t_manufacturer mf "
                 + "on sm.management=mf.MANUFACTURER_ID "
                 + "ORDER BY sm.STATUS ";
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
        /// 根据管理系统代码,获得财务系统映射.
        /// </summary>
        /// <param name="management"></param>
        /// <param name="status"></param>
        /// <param name="dt"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool GetMapping(string management, string finance, string status, out DataTable dt, out string err)
        {
            sql = " SELECT	"
                + "sm.SUPPLIER_MAPPING_ID "
                 + ",mf.manufacturer_name "
                 + ",sm.MANAGEMENT "
                 + ",sm.FINANCE "
                 + ",sm.STATUS "
                 + ",case sm.status "
                 + "when '1' then '不存在' "
                 + "when '2' then '错误' "
                 + "when '3' then '未校验' "
                 + "when '4' then '有效'  "
                 + "when '5' then 'SAP方法调用失败' "
                 + "end as STATUS_NAME  "
                 + "from T_SUPPLIER_MAPPING sm "
                 + "inner join t_manufacturer mf "
                 + "on sm.management=mf.MANUFACTURER_ID "
                + " WHERE 1=1 ";
            if (!string.IsNullOrEmpty(management))
                sql += " AND sm.MANAGEMENT='" + management + "'";
            if (!string.IsNullOrEmpty(finance))
                sql += " AND sm.FINANCE='" + finance + "'";
            if (!string.IsNullOrEmpty(status))
                sql += " AND sm.STATUS in (" + status + ")";
            sql += " ORDER BY sm.STATUS";
            return dbAccess.GetDataTable(sql, out dt, out err);
        }
        /// <summary>
        /// 下拉列表绑定的方法,排除已设置过的.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool GetSupplierSelect(out DataTable dt, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("  SELECT	");
            sb.AppendLine(" MF.MANUFACTURER_NAME ");
            sb.AppendLine(" ,MF.MANUFACTURER_ID ,'' sapcode ");
            sb.AppendLine(" FROM T_SUPPLIER_MAPPING SM RIGHT JOIN T_MANUFACTURER MF ");
            sb.AppendLine(" ON SM.MANAGEMENT=MF.MANUFACTURER_ID  ");
            sb.AppendLine(" WHERE 1=1 ");
            sb.AppendLine(" AND SM.MANAGEMENT IS NULL");
            return dbAccess.GetDataTable(sb.ToString(), out dt, out err);
        }
        /// <summary>
        /// 重新设置供应商.
        /// </summary>
        public bool ResetTheSupplierMapping(string managementId, string sapId, out string err)
        {
            List<string> lstSql = new List<string>();
            string sql = "delete T_SUPPLIER_MAPPING where MANAGEMENT = '" + managementId + "'";
            lstSql.Add(sql);
            sql = "INSERT INTO [T_SUPPLIER_MAPPING] ("
                    + "[SUPPLIER_MAPPING_ID],"
                    + "[MANAGEMENT],"
                    + "[FINANCE],"
                    + "[STATUS]"
                    + ") VALUES( "
                    + " newid()"
                    + " , '" + managementId + "'"
                    + " , '" + sapId + "'"
                    + " , 3"
                    + ")";
            lstSql.Add(sql);
            return dbAccess.ExecSql(lstSql, out err);
        }

    }
}
