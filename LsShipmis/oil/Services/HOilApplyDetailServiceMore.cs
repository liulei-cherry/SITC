/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：HOilApplyDetailService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-7-29
 * 标    题：数据操作类
 * 功能描述：T_HOIL_APPLY_DETAIL数据操作类
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
using Oil.DataObject;

namespace Oil.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_HOIL_APPLY_DETAILService.cs
    /// </summary>
    public partial class HOilApplyDetailService
    {
        /// <summary>
        /// 获取明细信息.
        /// </summary>
        /// <param name="apply_id"></param>
        /// <returns></returns>
        public DataTable GetApplyDatas(string apply_id, string ship_id, DateTime applyDateTime)
        {
            string err;
            DataTable dtreturn;
            if (string.IsNullOrEmpty(ship_id)) ship_id = "";
            if (applyDateTime.Year < 1753)
            {
                applyDateTime = DateTime.Now;
            }
            else
            {
                applyDateTime = applyDateTime.AddMonths(-1);//把日期调到上个月
            }

            sql = "SELECT APPLY_DETAIL_ID,APPLY_ID,b.OIL_ID ,b.TRADEMARK,b.OIL_NAME,NUM,c.THISMONTH_STORE,a.REMARK";
            sql += " FROM T_HOIL_APPLY_DETAIL a";
            sql += " inner join T_HOil b on a.Oil_Id = b.Oil_Id ";
            sql += " left join ( select * from T_HOIL_LUBOIL_CONSUME where ";
            sql += " upper(SHIP_ID)='" + ship_id.ToUpper() + "' and convert(varchar(7),RECORD_DATE,120)='" + applyDateTime.ToString("yyyy-MM") + "'";

            sql += " ) c on a.Oil_Id = c.Oil_Id ";
            sql += " WHERE APPLY_ID= '" + apply_id + "'";
            sql += " order by b.OIL_NAME";

            if (!dbAccess.GetDataTable(sql, out dtreturn, out err))
            {
                throw new Exception("GetApplyDatas occur err:" + err);
            }
            return dtreturn;
        }

        /// <summary>
        /// 获取要直接保存的明细信息.
        /// </summary>
        /// <param name="apply_id"></param>
        /// <returns></returns>
        public DataTable GetApplyDataForSave(string apply_id, string ship_id, DateTime applyDateTime)
        {
            string err;
            DataTable dtreturn;

            sql = @"SELECT a.APPLY_DETAIL_ID,a.APPLY_ID,a.OIL_ID ,(b.OIL_NAME + ' ' + b.TRADEMARK) as OIL_FULL_NAME,
                    THISMONTH_STORE,NUM,a.REMARK,cURRENCY_ID,aMOUNT
                   FROM T_HOIL_APPLY_DETAIL a inner join T_HOil b on a.Oil_Id = b.Oil_Id 
                    left join T_HOIL_LUBOIL_CONSUME hlc on hlc.Oil_Id = a.Oil_Id
                and hlc.SHIP_ID='" + ship_id + "' and datediff(MM,RECORD_DATE,'" + applyDateTime.ToString("yyyy-MM-dd") +
                    "')=0 WHERE a.APPLY_ID= '" + apply_id + "'";

            if (!dbAccess.GetDataTable(sql, out dtreturn, out err))
            {
                throw new Exception("GetApplyDataForSave occur err:" + err);
            }
            return dtreturn;
        }

        /// <summary>
        /// 根据明细ID集获取申请明细列表.
        /// </summary>
        public DataTable GetApplyDataByIDS(List<string> lstsID)
        {
            string err;
            DataTable dtreturn;
            string[] aDetailIDs = lstsID.ToArray();
            string IDs = String.Join("\',\'", aDetailIDs);

            sql = "SELECT APPLY_DETAIL_ID,APPLY_ID,OIL_ID,NUM,cURRENCY_ID,aMOUNT";
            sql += " FROM T_HOIL_APPLY_DETAIL ";
            sql += " WHERE APPLY_DETAIL_ID in ('" + IDs + "')";

            if (!dbAccess.GetDataTable(sql, out dtreturn, out err))
            {
                throw new Exception("GetApplyDataByIDS occur err:" + err);
            }
            return dtreturn;
        }
    }
}
