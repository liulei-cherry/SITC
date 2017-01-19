using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonOperation.Functions;
using CommonOperation.Interfaces;

namespace SAPFunction.Services
{
    public class StorageContrastService
    {
        #region 构造函数

        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static StorageContrastService instance = new StorageContrastService();
        public static StorageContrastService Instance
        {
            get
            {
                if (null == instance)
                {
                    StorageContrastService.instance = new StorageContrastService();
                }
                return StorageContrastService.instance;
            }
        }
        private StorageContrastService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();

        /// <summary>
        /// 库存信息.
        /// </summary>
        public bool GetStockInfo(string SHIP_ID, out DataTable dt, out string err)
        {
            err = "";
            dt = new DataTable();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT	");
            sb.AppendLine("mm.MANAGEMENT");
            sb.AppendLine(",smn.MATERIAL_SPEC");
            sb.AppendLine(",smn.UNIT_NAME");
            sb.AppendLine(",smn.MATERIAL_TYPE");
            sb.AppendLine(",case smn.MATERIAL_TYPE ");
            sb.AppendLine("when '1' then '物料'");
            sb.AppendLine("when '2' then '备件'");
            sb.AppendLine("when '3' then '油料' ");
            sb.AppendLine("end as MATERIAL_TYPE_NAME ");
            sb.AppendLine(",smn.MATERIAL_NAME");
            sb.AppendLine(",mm.MATERIAL_FINANCE");
            sb.AppendLine(",mm.STOCKSAll ");
            sb.AppendLine(",isnull(saps.STORAGE_QUANTITY,0) as INITIAL_STORAGE");
            sb.AppendLine("from ");

            sb.AppendLine("(");
            sb.AppendLine("SELECT	");
            sb.AppendLine("mm.MATERIAL_MAPPING_ID");
            sb.AppendLine(",mm.MANAGEMENT");
            sb.AppendLine(",mm.MATERIAL_FINANCE");
            sb.AppendLine(",isnull((select sum(STOCKSAll) from V_MATERIAL_STOCKS where MATERIAL_ID=mm.MANAGEMENT and SHIP_ID='" + SHIP_ID + "' ),0) as STOCKSAll");
            sb.AppendLine("from T_MATERIAL_MAPPING mm");
            sb.AppendLine("INNER JOIN V_SAP_Material_Name smn ON smn.MATERIAL_ID=mm.MANAGEMENT");
            sb.AppendLine("where smn.MATERIAL_TYPE='1'");

            sb.AppendLine("union all");

            sb.AppendLine("SELECT	");
            sb.AppendLine("mm.MATERIAL_MAPPING_ID");
            sb.AppendLine(",mm.MANAGEMENT");
            sb.AppendLine(",mm.MATERIAL_FINANCE");
            sb.AppendLine(",isnull((select sum(STOCKSAll) from V_SPARE_STOCKS where SPARE_ID=mm.MANAGEMENT and SHIP_ID='" + SHIP_ID + "' ),0) as STOCKSAll");
            sb.AppendLine("from T_MATERIAL_MAPPING mm");
            sb.AppendLine("INNER JOIN V_SAP_Material_Name smn ON smn.MATERIAL_ID=mm.MANAGEMENT");
            sb.AppendLine("where smn.MATERIAL_TYPE='2'");

            sb.AppendLine("union all");

            sb.AppendLine(" SELECT");
            sb.AppendLine("mm.MATERIAL_MAPPING_ID	");
            sb.AppendLine(",mm.MANAGEMENT");
            sb.AppendLine(",mm.MATERIAL_FINANCE");
            sb.AppendLine(",isnull((select top 1 THISMONTH_STORE from T_HOIL_LUBOIL_CONSUME where OIL_ID=mm.MANAGEMENT and SHIP_ID='" + SHIP_ID + "' order by RECORD_DATE desc),0) as STOCKSAll");
            sb.AppendLine("from T_MATERIAL_MAPPING mm ");
            sb.AppendLine("INNER JOIN V_SAP_Material_Name smn ON smn.MATERIAL_ID=mm.MANAGEMENT");
            sb.AppendLine("where smn.MATERIAL_TYPE='3'");

            sb.AppendLine(") mm");

            sb.AppendLine("INNER JOIN V_SAP_Material_Name smn ON smn.MATERIAL_ID=mm.MANAGEMENT");
            sb.AppendLine("left join T_SAP_STORAGE saps on saps.MATERIAL_MAPPING_ID=mm.MATERIAL_MAPPING_ID and saps.SHIP_ID='" + SHIP_ID + "' ");

            sb.AppendLine("WHERE 1=1 ");
            sb.AppendLine("ORDER BY smn.MATERIAL_TYPE");
            return dbAccess.GetDataTable(sb.ToString(), out dt, out err);
        }

        public bool GetTestSapStockInfo(out DataTable dt, out string err)
        {
            err = "";
            dt = new DataTable();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" SELECT 'SP21000005' as MATNR,0 as LABST, 'la' as MEINS");
            sb.AppendLine(" union all SELECT 'SP21000005' as MATNR,1 as LABST, 'la' as MEINS");
            sb.AppendLine(" union all SELECT 'SP21000032' as MATNR,1 as LABST, 'la' as MEINS");
            sb.AppendLine(" union all SELECT 'SP22000031' as MATNR,8 as LABST, 'la' as MEINS");
            sb.AppendLine(" union all SELECT 'SP11000003' as MATNR,14444 as LABST, 'la' as MEINS");
            sb.AppendLine(" union all SELECT 'SP41000246' as MATNR,3 as LABST, 'la' as MEINS");
            sb.AppendLine(" union all SELECT 'SP41000127' as MATNR,0 as LABST, 'la' as MEINS");
            sb.AppendLine(" union all SELECT 'SP33333333' as MATNR,0 as LABST, 'la' as MEINS");
            sb.AppendLine(" union all SELECT 'SP44444444' as MATNR,0 as LABST, 'la' as MEINS");
            sb.AppendLine(" union all SELECT 'SP45555555' as MATNR,0 as LABST, 'la' as MEINS");
            sb.AppendLine(" union all SELECT 'SP22000011' as MATNR,3 as LABST, 'la' as MEINS");
            sb.AppendLine(" union all SELECT 'SP22000012' as MATNR,0 as LABST, 'la' as MEINS");
            sb.AppendLine(" union all SELECT 'SP41000141' as MATNR,1 as LABST, 'la' as MEINS");

            return dbAccess.GetDataTable(sb.ToString(), out dt, out err);
        }
    }
}
