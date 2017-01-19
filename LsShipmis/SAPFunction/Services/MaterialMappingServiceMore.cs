/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：MaterialMappingService.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/6/17
 * 标    题：数据操作类
 * 功能描述：T_MATERIAL_MAPPING数据操作类
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
using ItemsManage.Services;
using Oil.Services;

namespace SAPFunction.Services
{
    public partial class MaterialMappingService
    {
        /// <summary>
        /// 得到  T_MATERIAL_MAPPING 所有数据信息.
        /// </summary>
        /// <returns>T_MATERIAL_MAPPING DataTable</returns>
        public DataTable GetAllInfo(out string err)
        {
            sql = "select	"
                + "mm.MATERIAL_MAPPING_ID"
                + ",smn.MATERIAL_NAME"
                + ",smn.MATERIAL_SPEC"
                + ",smn.unit_name"
                + ",mm.MANAGEMENT"
                + ",mm.MATERIAL_FINANCE"
                + ",mm.COST_FINANCE"
                + ",smn.MATERIAL_TYPE"
                + ",case smn.MATERIAL_TYPE "
                + "when '1' then '物料'"
                + "when '2' then '备件'"
                + "when '3' then '油料' "
                + "when '4' then '设备类型'"
                + "when '5' then '物料类型' "
                + "end as MATERIAL_TYPE_NAME "
                + ",mm.STATUS"
                + ",case mm.status "
                + "when '1' then '不存在'"
                + "when '2' then '错误'"
                + "when '3' then '未校验' "
                + "when '4' then '有效' "
                + "when '5' then 'SAP方法调用失败' "
                + "end as STATUS_NAME "
                + " from T_MATERIAL_MAPPING mm"
                + " left JOIN V_SAP_Material_Name smn"
                + " ON smn.MATERIAL_ID=mm.MANAGEMENT"
                + " ORDER BY mm.STATUS";
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
        /// 根据管理系统的物资代码,取得财务系统物资代码.
        /// </summary>
        /// <param name="management"></param>
        /// <param name="status"></param>
        /// <param name="dt"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool GetMapping(string management, string materialFinance, string status, out DataTable dt, out string err)
        {
            sql = " SELECT	"
                + "mm.MATERIAL_MAPPING_ID"
                + ",smn.MATERIAL_NAME"
                + ",mm.MANAGEMENT"
                + ",mm.MATERIAL_FINANCE"
                + ",mm.COST_FINANCE"
                + ",smn.MATERIAL_TYPE"
                + ",case smn.MATERIAL_TYPE "
                + "when '1' then '物料'"
                + "when '2' then '备件'"
                + "when '3' then '油料' "
                + "when '4' then '设备类型'"
                + "when '5' then '物料类型' "
                + "end as MATERIAL_TYPE_NAME "
                + ",mm.STATUS"
                + ",case mm.status "
                + "when '1' then '不存在'"
                + "when '2' then '错误'"
                + "when '3' then '未校验' "
                + "when '4' then '有效' "
                + "when '5' then 'SAP方法调用失败' "
                + "end as STATUS_NAME "
                + " from T_MATERIAL_MAPPING mm"
                + " left JOIN V_SAP_Material_Name smn"
                + " ON smn.MATERIAL_ID=mm.MANAGEMENT"
                + " WHERE 1=1 ";
            if (!string.IsNullOrEmpty(management))
                sql += " AND mm.MANAGEMENT='" + management + "'";
            if (!string.IsNullOrEmpty(materialFinance))
                sql += " AND mm.MATERIAL_FINANCE='" + materialFinance + "'";
            if (!string.IsNullOrEmpty(status))
                sql += " AND mm.STATUS in (" + status + ")";
            sql += " ORDER BY mm.STATUS";
            return dbAccess.GetDataTable(sql, out dt, out err);
        }
        /// <summary>
        /// 根据管理系统的物资代码,取得财务系统物资代码.
        /// </summary>
        /// <param name="management"></param>
        /// <param name="status"></param>
        /// <param name="dt"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool GetMaterialName(string MATERIAL_ID, out DataTable dt, out string err)
        {
            sql = " SELECT	"
                + " MATERIAL_ID"
                + ",MATERIAL_NAME"
                + ",MATERIAL_SPEC"
                + ",MATERIAL_TYPE"
                + " from V_SAP_Material_Name"
                + " WHERE 1=1 "
                + " AND MATERIAL_ID='" + MATERIAL_ID + "'";
            return dbAccess.GetDataTable(sql, out dt, out err);
        }
        /// <summary>
        /// 取得已有的财务费用代码.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool GetCostFinance(out DataTable dt, out string err)
        {
            sql = " SELECT DISTINCT	"
                + " COST_FINANCE "
                + " FROM T_MATERIAL_MAPPING "
                + " WHERE COST_FINANCE IS NOT NULL AND COST_FINANCE <>''";
            return dbAccess.GetDataTable(sql, out dt, out err);
        }
        /// <summary>
        /// 重新设置物资.
        /// </summary>
        /// <para映射m name="materialId">物资id</param>
        /// <param name="sapId"></param>
        /// <param name="err"></param>
        /// <returns>是否成功</returns>
        public bool ResetTheMaterialMapping(string materialId, string sapId, out string err)
        {
            List<string> lstSql = new List<string>();
            //lstSql.Add("delete from t_sap_storage where ship_id='" + ship_id + "' and material_mapping_id=(select material_mapping_id from T_MATERIAL_MAPPING where MANAGEMENT = '" + materialId + "' or MATERIAL_FINANCE = '" + sapId + "')");
            lstSql.Add("delete T_MATERIAL_MAPPING where MANAGEMENT = '" + materialId + "' or MATERIAL_FINANCE = '" + sapId + "'");
            string MATERIAL_MAPPING_ID = Guid.NewGuid().ToString();
            sql = "insert into T_MATERIAL_MAPPING(MATERIAL_MAPPING_ID"
                + ",MANAGEMENT"
                + ",MATERIAL_FINANCE"
                + ",COST_FINANCE"
                + ",STATUS)"
                + "values('" + MATERIAL_MAPPING_ID + "','" + materialId + "','" + sapId + "','',3)";
            lstSql.Add(sql);
            //lstSql.Add("insert into T_SAP_STORAGE values(newid(),'" + ship_id + "','" + MATERIAL_MAPPING_ID + "','" + storageQuantity + ")");
            return dbAccess.ExecSql(lstSql, out err);
        }
        /// <summary>
        /// 更改sap库存数量.
        /// </summary>
        public bool GetUpdateStorageQuantity(string ship_id, string materialId, decimal storageQuantity, out string err)
        {
            err = "";
            string sql = GetUpdateStorageQuantitySql(ship_id, materialId, storageQuantity);
            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 更改sap库存数量.
        /// </summary>
        /// <param name="ship_id"></param>
        /// <param name="materialId"></param>
        /// <param name="storageQuantity"></param>
        /// <returns></returns>
        public string GetUpdateStorageQuantitySql(string ship_id, string materialId, decimal storageQuantity)
        {
            DataTable dt;
            string err;
            sql = "select MATERIAL_MAPPING_ID from [T_SAP_STORAGE] "
                       + " where ship_id='" + ship_id + "' and upper(MATERIAL_MAPPING_ID) = '" + materialId.ToUpper() + "'";
            dbAccess.GetDataTable(sql, out dt, out err);
            if (dt.Rows.Count > 0)
            {
                return sql = "UPDATE [T_SAP_STORAGE] SET "
                           + " [STORAGE_QUANTITY] = " + storageQuantity
                           + " where ship_id='" + ship_id + "' and upper(MATERIAL_MAPPING_ID) = '" + materialId.ToUpper() + "'";
            }
            else
            {
                return sql = "insert into [T_SAP_STORAGE] values(newid(),'" + ship_id + "','" + materialId + "'," + storageQuantity + ") ";
            }
        }
        /// <summary>
        /// 更新sap标示.
        /// </summary>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool UpdateSapFlag(out string err)
        {
            List<string> sqlList = new List<string>();
            sqlList.Add("ALTER   TABLE   T_SPARE   DISABLE   TRIGGER   ALL ");
            sqlList.Add("update T_SPARE set ISSPECIALSP = 0");
            sqlList.Add("update T_SPARE set ISSPECIALSP = 1 where SPARE_ID in (select MANAGEMENT from T_MATERIAL_MAPPING)");
            sqlList.Add("ALTER   TABLE   T_SPARE   ENABLE   TRIGGER   ALL");
            sqlList.Add("ALTER   TABLE   T_MATERIAL   DISABLE   TRIGGER   ALL");
            sqlList.Add("update T_MATERIAL  set MATERIAL_CODE =  MATERIAL_FINANCE  from T_MATERIAL ,T_MATERIAL_MAPPING  where MANAGEMENT=MATERIAL_ID");
            sqlList.Add("ALTER   TABLE   T_MATERIAL   ENABLE   TRIGGER   ALL");

            return dbAccess.ExecSql(sqlList, out err);

        }
        /// <summary>
        /// 更新sap库存.
        /// </summary>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool UpdateSapStorage(out string err)
        {
            List<string> sqlList = new List<string>();
            //sqlList.Add("delete from t_sap_storage");
            sqlList.Add(@"insert into T_SAP_STORAGE 
                select newid(),ss.ship_id,mm.MATERIAL_MAPPING_ID,ss.STOCKSAll 
                from V_SPARE_STOCKS ss 
                inner join T_MATERIAL_MAPPING mm on mm.MANAGEMENT=ss.SPARE_ID
                left join T_SAP_STORAGE saps on saps.MATERIAL_MAPPING_ID=mm.MATERIAL_MAPPING_ID and saps.SHIP_ID=ss.SHIP_ID
                where saps.MATERIAL_MAPPING_ID is null");
            sqlList.Add(@"insert into T_SAP_STORAGE 
                select newid(),ms.ship_id,mm.MATERIAL_MAPPING_ID,ms.STOCKSAll 
                from V_MATERIAL_STOCKS ms 
                inner join T_MATERIAL_MAPPING mm on mm.MANAGEMENT=ms.MATERIAL_ID
                left join T_SAP_STORAGE saps on saps.MATERIAL_MAPPING_ID=mm.MATERIAL_MAPPING_ID and saps.SHIP_ID=ms.ship_id
                where saps.MATERIAL_MAPPING_ID is null");
            return dbAccess.ExecSql(sqlList, out err);
        }
        /// <summary>
        /// 删除数据表T_MATERIAL_MAPPING中的一条记录,包括库存.
        /// </summary>
        /// <param name="unit">要删除的T_MATERIAL_MAPPING.mATERIAL_MAPPING_ID主键</param>
        public bool DeleteUnitStorage(string unitid, out string err)
        {
            List<string> sqlList = new List<string>();
            sqlList.Add("delete from t_sap_storage where material_mapping_id='" + unitid + "'");
            sqlList.Add("delete from T_MATERIAL_MAPPING where  upper(T_MATERIAL_MAPPING.MATERIAL_MAPPING_ID)='" + unitid.ToUpper() + "'");
            return dbAccess.ExecSql(sqlList, out err);
        }

        public bool GetHoilMapping(string management, string materialFinance, string status, out DataTable dt, out string err)
        {
            sql = " SELECT	"
                + "mm.MATERIAL_MAPPING_ID"
                + ",mm.MANAGEMENT"
                + ",mm.MATERIAL_FINANCE"
                + ",mm.COST_FINANCE"
                + ",mm.STATUS"
                + ",case mm.status "
                + "when '1' then '不存在'"
                + "when '2' then '错误'"
                + "when '3' then '未校验' "
                + "when '4' then '有效' "
                + "when '5' then 'SAP方法调用失败' "
                + "end as STATUS_NAME "
                + " from T_MATERIAL_MAPPING mm"
                + " WHERE 1=1 ";
            if (!string.IsNullOrEmpty(management))
                sql += " AND mm.MANAGEMENT='" + management + "'";
            if (!string.IsNullOrEmpty(materialFinance))
                sql += " AND mm.MATERIAL_FINANCE='" + materialFinance + "'";
            if (!string.IsNullOrEmpty(status))
                sql += " AND mm.STATUS in ('" + status + "')";
            sql += " ORDER BY mm.STATUS";
            return dbAccess.GetDataTable(sql, out dt, out err);
        }


        /// <summary>
        /// 获取对应映射的库存
        /// </summary>
        public bool GetSAPStorageQuantity(string id, string ship_id, out DataTable dtb)
        {
            string sSql = "";
            string err;
            sSql = @"select 
                     mm.MATERIAL_MAPPING_ID
                    ,mm.MANAGEMENT
                    ,mm.MATERIAL_FINANCE
                    ,mm.COST_FINANCE
                    ,mm.STATUS
                    ,isnull(ss.STORAGE_QUANTITY,0) STORAGE_QUANTITY
                     from T_MATERIAL_MAPPING mm 
                     left join t_sap_storage ss on ss.material_mapping_id=mm.material_mapping_id and ss.ship_id='" + ship_id + "'"
                     + " where  mm.MANAGEMENT='" + id + "'";
            return dbAccess.GetDataTable(sSql, out dtb, out err);
        }
    }
}
