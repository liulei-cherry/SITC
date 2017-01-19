/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：HOilApplyService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-7-29
 * 标    题：数据操作类
 * 功能描述：T_HOIL_APPLY数据操作类
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
using ShipMisZHJ_WorkFlow.BusinessClasses;

namespace Oil.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_HOIL_APPLYService.cs
    /// </summary>
    public partial class HOilApplyService
    {
        /// <summary>
        /// 获得申请信息数据.
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <param name="startDate">起始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="chkState">审核状态</param>      
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetApply(string shipId, string startDate, string endDate, string chkState)
        {

            //变量定义部分.
            DataTable dtb;      //定义一个DataTable对象.
            string err;         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.

            //Select语句加工部分.
            sSql += "select a.APPLY_ID,s.SHIP_NAME,a.APPLY_DATE,a.SUPPLY_DATE,a.VOYAGE,b.CNAME,";
            sSql += "case when a.CHECKED = '0' then '未提交' "
                    + "   when a.CHECKED = '1' then '审核中' "
                    + "   when a.CHECKED = '2' then '已批准' "
                    + "   when a.CHECKED = '9' then '已订购' "
                    + "   end  CHECKED,";
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                sSql += " c.post,a.remark ";
            }
            else
            {
                sSql += "case when a.CHECKED = '1' and c.post is null then '岸端审核' "
                      + "else  c.post "
                      + "   end  post,";
                sSql += " a.remark ";
            }
            sSql += " from T_HOIL_APPLY a inner join  T_BASE_PORT b on a.PORT_ID = b.PORTID ";
            sSql += " inner join t_ship s on s.SHIP_ID = a.SHIP_ID  ";
            sSql += " left join V_CHECK c on a.APPLY_ID = c.business_id  ";
            if (CommonOperation.ConstParameter.IsLandVersion)
                sSql += " inner join T_USER_SHIP us on us.ship_id=a.SHIP_ID and us.userid = '" + CommonOperation.ConstParameter.UserId + "'";
            sSql += " where 1=1 ";
            if (!string.IsNullOrEmpty(chkState))
                sSql += " and a.CHECKED='" + chkState + "'";
            //modify by lipeng 解决插入的数据找不到的问题 start
            sSql += " and a.APPLY_DATE between '" + startDate + "' and '" + endDate + "' ";
            //modify by lipeng end
            if (!string.IsNullOrEmpty(shipId))
                sSql += " and a.SHIP_ID='" + shipId + "'";
            sSql += "order by a.APPLY_DATE desc";

            if (dbAccess.GetDataTable(sSql, out dtb, out err))
            {
                return dtb;
            }
            else
            {
                throw new Exception(err);
            }
        }

        /// <summary>
        /// 获得已批准申请信息数据.
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <param name="startDate">起始日期</param>
        /// <param name="endDate">结束日期</param>      
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetApply(string shipId)
        {

            //变量定义部分.
            DataTable dtb;      //定义一个DataTable对象.
            string err;         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.

            //Select语句加工部分.
            sSql += "select a.APPLY_ID,(replace(replace(replace(CONVERT(varchar, a.APPLY_DATE, 120 ),\'-\',\'\'),\' \',\'\'),\':\',\'\')) as code ";
            sSql += " from T_HOIL_APPLY a inner join  T_BASE_PORT b on a.PORT_ID = b.PORTID ";
            sSql += " where a.SHIP_ID='" + shipId + "' and ( a.CHECKED= 2 or a.CHECKED= 9) ";
            sSql += " order by a.APPLY_DATE desc";

            dbAccess.GetDataTable(sSql, out dtb, out err);
            return dtb;
        }

        /// <summary>
        /// 删除数据表T_MATERIEL_APPLY中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_MATERIEL_APPLY.mATERIEL_APPLY_ID主键</param>
        public bool deleteParentAndSub(string unitid, out string err)
        {
            List<string> sqls = new List<string>();

            sqls.Add("delete T_HOIL_APPLY_DETAIL where APPLY_ID = '" + unitid + "'");
            sqls.Add("delete T_HOIL_APPLY where APPLY_ID = '" + unitid + "'");
            return dbAccess.ExecSql(sqls, out err);
        }


        #region CheckObj 相关业务 2015-02-26 徐正本

        /// <summary>
        /// 根据滑油申请单号,获取滑油申请审批工作流的流程对象
        /// </summary>
        /// <param name="oilApplyId">申请单id</param>
        /// <returns>审批业务对象(Type : CheckObj)</returns>
        public CheckObj GetOilApplyCheckObjByOilApplyId(string oilApplyId)
        {
            string err;
            DataTable dt;
            sql = string.Format(@"select t1.APPLY_ID as businessid ,
t3.SHIP_NAME + CONVERT(varchar(100) , t1.APPLY_DATE, 111) + '滑油申请' as businessName,
t2.CNAME + '港' + isnull(t1.VOYAGE ,'') + isnull( char(13)+ CHAR(10) + t1.REMARK,'' ) as businessMainInfo,t4.NUM,t5.TRADEMARK + t5.OIL_NAME as oilName,t6.ForWhichType
from T_HOIL_APPLY t1 inner join T_BASE_PORT t2 on t1.PORT_ID = t2.PORTID  
inner join T_SHIP t3 on t1.SHIP_ID = t3.SHIP_ID
inner join dbo.T_HOIL_APPLY_DETAIL t4 on t1.APPLY_ID = t4.APPLY_ID
inner join T_HOIL t5 on t4.OIL_ID = t5.OIL_ID
left join T_HOIL_SHIP t6 on t6.SHIP_ID = t3.SHIP_ID and t6.OIL_ID = t5.OIL_ID
where t1.APPLY_ID = '{0}'
order by t6.ORDERNUM", dbOperation.ReplaceSqlKeyStr(oilApplyId));
            dbAccess.GetDataTable(sql.ToString(), out dt, out err);
            if (dt.Rows.Count >= 1)
            {
                string businessDetail = dt.Rows[0]["businessMainInfo"].ToString();
                foreach (DataRow dr in dt.Rows)
                { 
                    businessDetail += "\r\n" + dr["ForWhichType"].ToString() + dr["oilName"].ToString() + " " + dr["Num"].ToString() + "L";
                }
                return new CheckObj(dt.Rows[0]["businessid"].ToString(), dt.Rows[0]["businessName"].ToString(), businessDetail);
            }
#if DEBUG
            throw new Exception("未从数据库获取到指定滑油申请的相关信息,申请单id为:" + oilApplyId);
#else
            return new CheckObj(oilApplyId, oilApplyId, "未获取到信息");
#endif
        }
        #endregion
    }
}
