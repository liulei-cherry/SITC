using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.Functions;
using System.Data;
using CommonOperation.Interfaces;

namespace StorageManage.Services
{
    public class SAPServiceOfSpareAndMaterial
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static SAPServiceOfSpareAndMaterial instance = new SAPServiceOfSpareAndMaterial();
        public static SAPServiceOfSpareAndMaterial Instance
        {
            get
            {
                if (null == instance)
                {
                    SAPServiceOfSpareAndMaterial.instance = new SAPServiceOfSpareAndMaterial();
                }
                return SAPServiceOfSpareAndMaterial.instance;
            }
        }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql;
        #region 备件部分
        /// 采购接口.
        ///  /// 因为从生成凭证走,所以不用他了.
        //public bool GetSpareDepotInOperationToSAP(string id, out DataTable dtb, out string err)
        //{
        //    sql = "select "
        //        + "a.SPAREOPERDETAIL_ID as UUID,"
        //        + "a.spare_Id as MATERIAL,"
        //        + "a.COUNT as QUANTITY,"
        //        + "a.ship_id as SHIP_ID,"
        //        + "c.CURRENCYCODE as CURRENCY,"
        //        + "a.AMOUNT as AMOUNT,"
        //        + "a.SERVICEPROVIDERID as SUPPLIER,"
        //        + "b.OPERATION_CODE  as INPUT_ORDER"
        //        + "\rfrom T_SPARE_DEPOT_OPERATION_DETAIL a inner join T_SPARE_DEPOT_OPERATION b on a.DEPOTOPERID = b.DEPOTOPERID "
        //        + "\r inner join T_CURRENCY c on a.CURRENCYID= c.CURRENCYID "
        //        + "\rwhere a.DEPOTOPERID = '" + id + "' and COUNT<>0";
        //    return dbAccess.GetDataTable(sql, out dtb, out err);
        //}
        /// 出库接口格式 MATERIAL,QUANTITY,SHIP_ID,UUID,STORAGE_QUANTITY
        public bool GetSpareDepotOutOperationToSAP(string id, out DataTable dtb, out string err)
        {
            sql = string.Format(@"select 
                a.SPAREOPERDETAIL_ID as UUID
                ,a.spare_Id as MATERIAL
                ,a.COUNT as QUANTITY
                ,a.ship_id as SHIP_ID
                ,mm.MATERIAL_MAPPING_ID
                ,mm.MANAGEMENT
                ,mm.MATERIAL_FINANCE
                ,mm.COST_FINANCE
                ,mm.STATUS
                ,ss.STORAGE_QUANTITY
                from T_SPARE_DEPOT_OPERATION_DETAIL a 
                inner join T_MATERIAL_MAPPING mm on mm.MANAGEMENT=a.spare_Id
                left join t_sap_storage ss on ss.material_mapping_id=mm.material_mapping_id and ss.ship_id=a.ship_Id
                where a.DEPOTOPERID = '{0}' and a.COUNT<>0 ", id);
            return dbAccess.GetDataTable(sql, out dtb, out err);
        }
        /// 盘点接口格式 MATERIAL,QUANTITY,SHIP_ID,UUID,STORAGE_QUANTITY,materialStock
        public bool GetSpareDepotCheckOperationToSAP(string id, out DataTable dtb, out string err)
        {
            sql = string.Format(@"select 
                a.SPARECHECKDETAIL_ID as UUID
                ,a.spare_Id as MATERIAL
                ,a.COUNT as QUANTITY
                ,a.ship_id as SHIP_ID
                ,mm.MATERIAL_MAPPING_ID
                ,mm.MANAGEMENT
                ,mm.MATERIAL_FINANCE
                ,mm.COST_FINANCE
                ,mm.STATUS
                ,isnull(ss.STORAGE_QUANTITY,0) as STORAGE_QUANTITY
                ,isnull((select sum(vms.STOCKSAll) from V_SPARE_STOCKS vms where vms.ship_Id = a.ship_id and vms.spare_Id = a.spare_Id),0) as materialStock
                from T_SPARE_DEPOT_CHECK_DETAIL a 
                inner join T_MATERIAL_MAPPING mm on mm.MANAGEMENT=a.spare_Id
                left join t_sap_storage ss on ss.material_mapping_id=mm.material_mapping_id and ss.ship_id=a.ship_Id
                where a.DEPOTCHECKID = '{0}' and a.COUNT<>0 ", id);
            return dbAccess.GetDataTable(sql, out dtb, out err);
        }
        #endregion

        #region 物料部分
        /// 采购接口格式:MATERIAL,QUANTITY,CURRENCY,AMOUNT,SHIP_ID,SUPPLIER,INPUT_ORDER,INPUT_OREER_ITEM,UUID
        /// 因为从生成凭证走,所以不用他了.
        //public bool GetMaterialDepotInOperationToSAP(string id, out DataTable dtb, out string err)
        //{
        //    sql = "select "
        //        + "a.MATERIALOPERDETAIL_ID as UUID,"
        //        + "a.material_Id as MATERIAL,"
        //        + "a.COUNT as QUANTITY,"
        //        + "a.ship_id as SHIP_ID,"
        //        + "c.CURRENCYCODE as CURRENCY,"
        //        + "a.AMOUNT as AMOUNT,"
        //        + "a.SERVICEPROVIDERID as SUPPLIER,"
        //        + "b.OPERATION_CODE  as INPUT_ORDER"
        //        + "\rfrom T_MATERIAL_DEPOT_OPERATION_DETAIL a inner join T_MATERIAL_DEPOT_OPERATION b on a.DEPOTOPERID = b.DEPOTOPERID "
        //        + "\r inner join T_CURRENCY c on a.CURRENCYID= c.CURRENCYID "
        //        + "\rwhere a.DEPOTOPERID = '" + id + "' and COUNT<>0";
        //    return dbAccess.GetDataTable(sql, out dtb, out err);
        //}
        /// 出库接口格式 MATERIAL,QUANTITY,SHIP_ID,UUID,STORAGE_QUANTITY
        public bool GetMaterialDepotOutOperationToSAP(string id, out DataTable dtb, out string err)
        {
            sql = string.Format(@"select 
                a.MATERIALOPERDETAIL_ID as UUID
                ,a.material_Id as MATERIAL
                ,a.COUNT as QUANTITY
                ,a.ship_id as SHIP_ID
                ,mm.MATERIAL_MAPPING_ID
                ,mm.MANAGEMENT
                ,mm.MATERIAL_FINANCE
                ,mm.COST_FINANCE
                ,mm.STATUS
                ,ss.STORAGE_QUANTITY
                from T_MATERIAL_DEPOT_OPERATION_DETAIL a 
                inner join T_MATERIAL_MAPPING mm on mm.MANAGEMENT=a.material_Id
                left join t_sap_storage ss on ss.material_mapping_id=mm.material_mapping_id and ss.ship_id=a.ship_Id
                where a.DEPOTOPERID = '{0}' and a.COUNT<>0 ", id);
            return dbAccess.GetDataTable(sql, out dtb, out err);
        }
        /// 盘点接口格式 MATERIAL,QUANTITY,SHIP_ID,UUID,STORAGE_QUANTITY,materialStock
        public bool GetMaterialDepotCheckOperationToSAP(string id, out DataTable dtb, out string err)
        {
            sql = string.Format(@"select 
                a.MATERIALCHECKDETAIL_ID as UUID
                ,a.material_Id as MATERIAL
                ,a.COUNT as QUANTITY
                ,a.ship_id as SHIP_ID
                ,mm.MATERIAL_MAPPING_ID
                ,mm.MANAGEMENT
                ,mm.MATERIAL_FINANCE
                ,mm.COST_FINANCE
                ,mm.STATUS
                ,isnull(ss.STORAGE_QUANTITY,0) as STORAGE_QUANTITY
                ,isnull((select sum(vms.STOCKSAll) from V_MATERIAL_STOCKS vms where vms.ship_Id = a.ship_id and vms.material_Id = a.material_Id),0) as materialStock
                from T_MATERIAL_DEPOT_CHECK_DETAIL a 
                inner join T_MATERIAL_MAPPING mm on mm.MANAGEMENT=a.material_Id
                left join t_sap_storage ss on ss.material_mapping_id=mm.material_mapping_id and ss.ship_id=a.ship_Id
                where a.DEPOTCHECKID = '{0}' and a.COUNT<>0 ", id);
            return dbAccess.GetDataTable(sql, out dtb, out err);
        }
        #endregion
    }
}
