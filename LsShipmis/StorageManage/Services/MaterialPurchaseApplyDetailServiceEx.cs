using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace StorageManage.Services
{
    public partial class MaterialPurchaseApplyDetailService
    {
        /// <summary>
        /// 根据条件得到.
        /// </summary>
        public bool GetInfo(string PURCHASE_APPLYID, out DataTable dt, out string err)
        {
            return GetInfo(PURCHASE_APPLYID, true, out dt, out err);
        }
             /// <summary>
        /// 根据条件得到.
        /// </summary>
        public bool GetInfo(string PURCHASE_APPLYID, bool withOrderedInfo,out DataTable dt, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select	");
            sb.AppendLine("mpad.PURCHASE_APPLY_DETAIL_ID");
            sb.AppendLine(",mpad.PURCHASE_APPLYID");
            sb.AppendLine(",mpad.MATERIAL_ID");
            sb.AppendLine(",mpad.MATERIAL_NAME");
            sb.AppendLine(",mpad.MATERIAL_CODE");
            sb.AppendLine(",mpad.MATERIAL_SPEC");
            sb.AppendLine(",material.UNIT_NAME");
            sb.AppendLine(",isnull(v.STOCKSAll,0) COUNTINSHIP");
            sb.AppendLine(",mpad.APPLYCOUNT");
            sb.AppendLine(",mpad.CONFIRMEDCOUNT");
            sb.AppendLine(",mpad.REMARK");
            sb.AppendLine(",mpad.ORDERNUM");
            sb.AppendLine(" from T_MATERIAL_PURCHASE_APPLY_DETAIL mpad");
            sb.AppendLine(" inner join T_MATERIAL material on mpad.MATERIAL_ID = material.MATERIAL_ID");
            sb.AppendLine(" inner join T_MATERIAL_PURCHASE_APPLY t1 on  t1.PURCHASE_APPLYID = '" + dbOperation.ReplaceSqlKeyStr(PURCHASE_APPLYID) + "'");
            sb.AppendLine(" left join (select material_id,sum(STOCKSAll) STOCKSAll,ship_id");
            sb.AppendLine("          from V_MATERIAL_STOCKS group by SHIP_ID , MATERIAL_ID ) v");
            sb.AppendLine("          on mpad.MATERIAL_ID = v.material_id and t1.ship_id = v.ship_id");
            sb.AppendLine(" where mpad.PURCHASE_APPLYID='" + dbOperation.ReplaceSqlKeyStr(PURCHASE_APPLYID) + "'");
            if (!withOrderedInfo) sb.AppendLine(" and mpad.MATERIAL_ID not in (select MATERIAL_ID from T_MATERIAL_PURCHASE_ORDER_DETAIL where PURCHASE_APPLYID = '" + PURCHASE_APPLYID + "')");
            sb.AppendLine("  order by mpad.ORDERNUM");
            return dbAccess.GetDataTable(sb.ToString(), out dt, out err);
        }
        /// <summary>
        /// 删除绑定数据.
        /// </summary>
        public bool DeleteByPurchaseApplyID(string PURCHASE_APPLYID, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("delete from T_MATERIAL_PURCHASE_APPLY_DETAIL ");
            sb.AppendLine(" where 1=1");
            sb.AppendLine("  and PURCHASE_APPLYID='" + PURCHASE_APPLYID + "'");
            return dbAccess.ExecSql(sb.ToString(), out err);
        }

        #region 得到物料申请明细 zhangy-2013-8-6 2014年5月19日 徐正本关闭掉
        ///// <summary>
        ///// 得到物料申请明细
        ///// </summary>
        ///// <param name="businessId">主键</param>
        ///// <param name="isReference">是否被询价单引用</param>
        ///// <param name="dtSource">结果集合</param>
        ///// <param name="errMessage">错误信息</param>
        ///// <returns></returns>
        //public bool SelectMaterialApplyDetailTable(String businessId, Boolean isReference, out DataTable dtSource, out String errMessage)
        //{
        //    String sCondition = String.Empty;
        //    if (!isReference) { sCondition = " AND mpad.PURCHASE_APPLY_DETAIL_ID NOT IN (SELECT PURCHASE_APPLY_DETAIL_ID FROM dbo.T_MATERIAL_PURCHASE_ENQUIRY_DETAIL WHERE PURCHASE_APPLY_DETAIL_ID!='')"; }
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine("select	");
        //    sb.AppendLine("mpad.PURCHASE_APPLY_DETAIL_ID");
        //    sb.AppendLine(",mpad.PURCHASE_APPLYID");
        //    sb.AppendLine(",mpad.MATERIAL_ID");
        //    sb.AppendLine(",mpad.MATERIAL_NAME");
        //    sb.AppendLine(",mpad.MATERIAL_CODE");
        //    sb.AppendLine(",mpad.MATERIAL_SPEC");
        //    sb.AppendLine(",material.UNIT_NAME");
        //    sb.AppendLine(",isnull(v.STOCKSAll,0) COUNTINSHIP");
        //    sb.AppendLine(",mpad.APPLYCOUNT");
        //    sb.AppendLine(",mpad.CONFIRMEDCOUNT");
        //    sb.AppendLine(",mpad.REMARK");
        //    sb.AppendLine(",mpad.ORDERNUM");
        //    sb.AppendLine(" from T_MATERIAL_PURCHASE_APPLY_DETAIL mpad");
        //    sb.AppendLine(" inner join T_MATERIAL material on mpad.MATERIAL_ID = material.MATERIAL_ID");
        //    sb.AppendLine(" inner join T_MATERIAL_PURCHASE_APPLY t1 on  t1.PURCHASE_APPLYID = '" + dbOperation.ReplaceSqlKeyStr(businessId) + "'");
        //    sb.AppendLine(" left join (select material_id,sum(STOCKSAll) STOCKSAll,ship_id");
        //    sb.AppendLine("          from V_MATERIAL_STOCKS group by SHIP_ID , MATERIAL_ID ) v");
        //    sb.AppendLine("          on mpad.MATERIAL_ID = v.material_id and t1.ship_id = v.ship_id");
        //    sb.AppendLine(" where mpad.PURCHASE_APPLYID='" + dbOperation.ReplaceSqlKeyStr(businessId) + "' " + sCondition + "");
        //    sb.AppendLine("  order by mpad.ORDERNUM");
        //    return dbAccess.GetDataTable(sb.ToString(), out dtSource, out errMessage);
        //}
        #endregion
    }
}
