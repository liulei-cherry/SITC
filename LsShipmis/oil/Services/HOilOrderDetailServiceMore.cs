/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：HOilOrderDetailService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-8-12
 * 标    题：数据操作类
 * 功能描述：T_HOIL_ORDER_DETAIL数据操作类
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

namespace  Oil.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_HOIL_ORDER_DETAILService.cs
    /// </summary>
    public partial class HOilOrderDetailService
    {
        /// <summary>
        /// 获取明细信息.
        /// </summary>
        /// <param name="apply_id"></param>
        /// <returns></returns>
        public DataTable GetOrderDatas(string order_id)
        {
            string err;
            DataTable dtreturn;

            sql = "SELECT ORDER_DETAIL_ID,ORDER_ID,b.OIL_ID ,b.TRADEMARK,b.OIL_NAME,NUM,a.CURRENCY_ID,c.CURRENCYNAME,a.AMOUNT";
            sql += " FROM T_HOIL_ORDER_DETAIL a";
            sql += " inner join T_HOil b on a.Oil_Id = b.Oil_Id ";
            sql += " left join T_CURRENCY c on a.CURRENCY_ID = c.CURRENCYID ";
            sql += " WHERE ORDER_ID= '" + order_id + "'";
            sql += " order by b.OIL_NAME";

            if (!dbAccess.GetDataTable(sql, out dtreturn, out err))
            {
                throw new Exception("GetOrderDatas occur err:" + err);
            }
            return dtreturn;
        }

        /// <summary>
        /// 获取要直接保存的明细信息.
        /// </summary>
        /// <param name="apply_id"></param>
        /// <returns></returns>
        public DataTable GetOrderDataForSave(string order_id)
        {
            string err;
            DataTable dtreturn;

            sql = "SELECT hod.ORDER_DETAIL_ID,hod.ORDER_ID,hod.OIL_ID ,hod.NUM,hod.cURRENCY_ID,c.CURRENCYNAME, hod.AMOUNT as AMOUNT";
            sql += " FROM T_HOIL_ORDER_DETAIL hod ";
            sql += " left join T_CURRENCY c on c.CURRENCYID=hod.cURRENCY_ID ";
            sql += " WHERE ORDER_ID= '" + order_id + "'";

            if (!dbAccess.GetDataTable(sql, out dtreturn, out err))
            {
                throw new Exception("GetOrderDataForSave occur err:" + err);
            }
            return dtreturn;
        }

        /// <summary>
        /// 把申请明细保存到订单明细下.
        /// </summary>
        public bool applyToOrder(string orderID, List<string> lstsID, out string err)
        {
            List<string> lstSql = new List<string>();

            DataTable dt = HOilApplyDetailService.Instance.GetApplyDataByIDS(lstsID);
            foreach(DataRow row in dt.Rows){

                sql = "INSERT INTO [T_HOIL_ORDER_DETAIL] ("
					+ "[ORDER_DETAIL_ID],"
					+ "[ORDER_ID],"
					+ "[OIL_ID],"
					+ "[NUM],"
					+ "[CURRENCY_ID],"
					+ "[AMOUNT]"
					+ ") VALUES( "
					+ " '" + Guid.NewGuid().ToString()
					+ " ', '" + orderID
                    + "' , '" + row["OIL_ID"].ToString()
                    + "' ," + row["NUM"].ToString()
                    + " , " + ((DBNull.Value == row["CURRENCY_ID"]) ? "null" : "'" + row["CURRENCY_ID"].ToString() + "'")
                    + " ," + ((DBNull.Value == row["AMOUNT"]) ? "0" : "'" + row["AMOUNT"].ToString() + "'")
					+ ")";

                lstSql.Add(sql);
                
            }

            return dbAccess.ExecSql(lstSql, out err);

        }

        internal bool GetInfo(string item, out DataTable dtDetail, out string err)
        {
            sql = "SELECT ORDER_DETAIL_ID,ORDER_ID,b.OIL_ID ,b.TRADEMARK,b.OIL_NAME,NUM,a.CURRENCY_ID,c.CURRENCYCODE,c.CURRENCYNAME,a.AMOUNT";
            sql += " FROM T_HOIL_ORDER_DETAIL a";
            sql += " inner join T_HOil b on a.Oil_Id = b.Oil_Id ";
            sql += " left join T_CURRENCY c on a.CURRENCY_ID = c.CURRENCYID ";
            sql += " inner join T_MATERIAL_MAPPING d on a.OIL_ID = d.MANAGEMENT ";
            sql += " WHERE ORDER_ID= '" + item + "'";
            sql += " order by b.OIL_NAME";

            return dbAccess.GetDataTable(sql, out dtDetail, out err);
        }

    }
}
