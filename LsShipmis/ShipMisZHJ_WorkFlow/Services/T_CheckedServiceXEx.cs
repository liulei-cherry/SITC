/****************************************************************************************************
 * Copyright (C) 2009 大连陆海科技有限公司 版权所有
 * 文 件 名：T_CheckedService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2009-11-3
 * 标    题：数据操作类
 * 功能描述：T_Checked数据操作类
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
using ShipMisZHJ_WorkFlow.BusinessClasses;
using System.Windows.Forms;

namespace ShipMisZHJ_WorkFlow.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_CheckedService.cs
    /// </summary>
    public partial class T_CheckedService
    {

        /// <summary>
        /// 获得审核对象.
        /// </summary>
        internal T_Checked GetObjectByBusinessCheckObj(CheckObj businessCheckObj, out string err)
        {
            T_Checked reObj;
            if (string.IsNullOrEmpty(businessCheckObj.ObjBusinessId))
            {
                err = "传入id无效";
                return null;
            }
            sql = " select  t1.Checked_Id";
            sql += " from T_Checked t1  ";
            sql += " where upper(t1.Business_Object_Id)='" + businessCheckObj.ObjBusinessId.ToUpper() + "' ";

            DataTable dt;
            dbAccess.GetDataTable(sql, out dt, out err);
            if (dt != null && dt.Rows.Count > 0)
            {
                string id = dt.Rows[0][0].ToString();
                reObj = GetObject(id, out err);
                reObj.FillBusinessInfo(businessCheckObj.ObjBusinessName, businessCheckObj.ObjBusinessDetail + 
                    "\r\n------------------------------------------\r\n 审批过程如下:\r\n"+
                    GetCheckDetail(id));
                return reObj;
            }
            return null;
        }

        /// <summary>
        /// 获得审核历史记录.
        /// </summary>
        /// <param name="check_id"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public string GetCheckDetail(string check_id )
        {
            string err;
            sql = " select  CheckDate,Checkor,Remark ";
            sql += " from T_Checked_Detail t1  ";
            sql += " where upper(t1.Checked_Id)='" + check_id.ToUpper() + "' order by  CheckDate desc";

            DataTable dt;
            dbAccess.GetDataTable(sql, out dt, out err);
            string re = "";
            foreach (DataRow dr in dt.Rows)
            {
                re += dr["CheckDate"].ToString() + "  " + dr["Checkor"].ToString() + "  " + dr["Remark"].ToString() + "\r\n\r\n";
            }
            return re;
        }

    }
}
