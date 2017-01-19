using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace StorageManage.Services
{
    public partial class MaterialPurchaseApplyService
    {
        /// <summary>
        /// 得到  T_MATERIAL_PURCHASE_APPLY 所有数据信息.
        /// </summary>
        /// <returns>T_MATERIAL_PURCHASE_APPLY DataTable</returns>
        public bool GetInfo(List<string> PURCHASE_APPLYIDs, string SHIP_ID, string DEPART_ID, string PURCHASE_APPLY_PERSON_POSTID, string STATE, DateTime beginDate, DateTime endDate, out DataTable dt, out string err)
        {
            string PURCHASE_APPLYID_string = "";
            if (PURCHASE_APPLYIDs != null)
            {
                foreach (string id in PURCHASE_APPLYIDs)
                {
                    PURCHASE_APPLYID_string += "'" + id + "',";
                }
                if (PURCHASE_APPLYID_string.Length > 0) PURCHASE_APPLYID_string = PURCHASE_APPLYID_string.Remove(PURCHASE_APPLYID_string.Length - 1);
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"select	
spa.PURCHASE_APPLYID
,spa.PURCHASE_APPLY_CODE
,spa.SHIP_ID
,s.SHIP_NAME
,case spa.STATE 
  when '0' then '未填写完毕'
  when '1' then '等待部门长审核'
  when '2' then '等待船长确认'
  when '3' then '等待岸端机务主管审批'
  when '4' then '等待岸端机务经理审批'
  when '5' then '等待船管总经理审批'
  when '6' then '审核通过'
  when '7' then '取消'
  when '8' then '被打回'
  when '9' then '全部订购'
  when '-1' then '船端合单'
  when '-2' then '部分订购'
  end as STATE_NAME
,spa.PURCHASE_APPLY_PERSON
,spa.PURCHASE_APPLY_PERSON_POSTID
,bh.HEADSHIP_NAME
,bh.ISLANDPOST
,spa.DEPART_ID
,d.DEPARTNAME
,spa.PURCHASE_APPLY_DATE
,spa.ISCOMPLETE
 ,case spa.ISCOMPLETE 
  when '0' then '未填写完毕'
  when '1' then '填写完毕'
  end as ISCOMPLETE_NAME

,spa.SHIP_LEADER_CHECKER
,spa.SHIP_LEADER_CHECKDATE
,spa.SHIP_BOSS_CHECKER
,spa.SHIP_BOSS_CHECKDATE
,spa.LANDCHECKER
,spa.CHECKDATE
,spa.STATE
,spa.REMARK
 from T_MATERIAL_PURCHASE_APPLY spa
 inner join T_SHIP s on s.SHIP_ID=spa.SHIP_ID 
 ");
            if (CommonOperation.ConstParameter.IsLandVersion)
                sb.AppendLine("  inner join T_USER_SHIP us on us.ship_id=spa.SHIP_ID and us.userid = '" + CommonOperation.ConstParameter.UserId + "'");
            sb.AppendLine(" inner join T_BASE_HEADSHIP bh on bh.SHIP_HEADSHIP_ID=spa.PURCHASE_APPLY_PERSON_POSTID ");
            sb.AppendLine(" inner join T_DEPARTMENT d on d.DEPARTMENTID=spa.DEPART_ID ");

            sb.AppendLine(" where spa.PURCHASE_APPLY_DATE between '" + beginDate.ToString("yyyy/MM/dd") + "' and '" + endDate.AddDays(1).ToString("yyyy/MM/dd") + "' ");
            if (!string.IsNullOrEmpty(PURCHASE_APPLYID_string))
                sb.AppendLine(" and spa.PURCHASE_APPLYID in (" + PURCHASE_APPLYID_string + ")");
            if (!string.IsNullOrEmpty(SHIP_ID))
                sb.AppendLine(" and spa.SHIP_ID='" + SHIP_ID + "'");
            if (!string.IsNullOrEmpty(DEPART_ID))
                sb.AppendLine(" and spa.DEPART_ID='" + DEPART_ID + "'");
            if (!string.IsNullOrEmpty(PURCHASE_APPLY_PERSON_POSTID))
                sb.AppendLine(" and spa.PURCHASE_APPLY_PERSON_POSTID='" + PURCHASE_APPLY_PERSON_POSTID + "'");
            if (!string.IsNullOrEmpty(STATE))
                sb.AppendLine(" and spa.STATE in (" + STATE + ")");
            sb.AppendLine(" order by spa.PURCHASE_APPLY_DATE desc");
            return dbAccess.GetDataTable(sb.ToString(), out dt, out err);
        }
        internal string GetBusinessStateByViewerState(string viewerState)
        {
            switch (viewerState)
            {
                case "2":
                    return "1,2,3,4,5,8";

                case "3":
                    return "6,-2";

                case "4":
                    return "-1,7,9";
#if DEBUG
                default:
                    throw new Exception("getBusinessStateByViewerState 调用异常，传入参数无效！");
            }
#else
            }
            return "";
#endif
        }

        /// <summary>
        /// 处理单号（组成规则：B船舶编号+两位年份+两位月份+序列号(三位))
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <returns>返回加工好的物资出入库单编号</returns>
        public string GetPurchaseApplyCode(string shipId)
        {
            string err = ""; //错误信息返回参数.
            string sSql = "";           //SQL查询语句.
            string sShipCode = "";      //船舶编号.
            string sMaxNumb = "";       //出入库单最大序列号（字符型）.
            int maxNumb = 0;            //出入库单最大序列号（数值型）.
            string applyCode = "";      //出入库单.

            //1.取船舶编号.
            sSql = "select ship_code from t_ship where ship_Id = '" + shipId + "'";
            dbAccess.GetString(sSql, out sShipCode, out err);
            if (sShipCode.Length == 0) sShipCode = "NoShip";

            //2.取两位年份两位月份.
            string theYear = "";
            theYear = DateTime.Now.ToString("yyMM");

            //3.取最大序列号（取t_MATERIAL_apply与t_material_apply中的最大序列号）.

            sSql = "select max(PURCHASE_APPLY_CODE) from (";
            sSql += "select cast(right(PURCHASE_APPLY_CODE,3) as int) as PURCHASE_APPLY_CODE from T_MATERIAL_PURCHASE_APPLY where ship_id = '" + shipId + "') a";
            dbAccess.GetString(sSql, out sMaxNumb, out err);
            if (sMaxNumb == "") sMaxNumb = "0";
            maxNumb = int.Parse(sMaxNumb) + 1;
            string difference = CommonOperation.ConstParameter.IsLandVersion ? "L" : "S";
            if (maxNumb < 1000)
            {
                applyCode = difference + sShipCode + "-" + theYear + string.Format("{0:000}", maxNumb);
            }
            else
            {
                applyCode = difference + sShipCode + "-" + theYear + maxNumb.ToString();
            }
            return applyCode;
        }

        #region 更新申请单的订购状态，2014年5月19日徐正本

        internal bool ResetApplicationsOrderState(List<string> applyIds, out string err)
        {
            err = "";
            foreach (string applyId in applyIds)
            {
                if (!string.IsNullOrEmpty(applyId))
                {
                    if (!ResetApplicationOrderState(applyId, out err)) return false;
                }
            }
            return true;
        }

        internal bool ResetApplicationOrderState(string applyId, out string err)
        {
            //判断方法，在订单明细项中，有申请单id，如果申请单的所有明细项，均在订单中有体现，则认为是全部采购，
            //部分有体现，则为部分采购，订单操作时有体现，但是后来订单删除了，依然认为没有采购（或放弃采购，还可以被选择）
            string sql = string.Format(
@"select SUM (applycount) applycount,SUM(ordercount) ordercount
from(
select 1 applycount, isnull(( select top 1  1 from T_MATERIAL_PURCHASE_ORDER_DETAIL t2 
where t1.PURCHASE_APPLYID = t2.PURCHASE_APPLYID and t1.MATERIAL_ID = t2.MATERIAL_ID)  ,0) ordercount
from T_MATERIAL_PURCHASE_APPLY_DETAIL t1
where t1.PURCHASE_APPLYID ='{0}') t
", applyId);
            DataTable dt;
            if (!dbAccess.GetDataTable(sql, out dt, out err))
            {
                return false;
            }
            int detailCount, orderCount;
            if (dt.Rows.Count == 0)
                return true;
            if (dt.Rows.Count == 1)
            {
                if (int.TryParse(dt.Rows[0][0].ToString(), out detailCount) && int.TryParse(dt.Rows[0][1].ToString(), out orderCount))
                {
                    if (detailCount == orderCount) return ResetApplicationState(applyId, 9, out err);
                    else if (orderCount > 0) return ResetApplicationState(applyId, -2, out err);
                    return true;
                }
            }
            err = "checkApplicationDetailState 查询到的数据异常，不能强制转换成数值";
            return false;

        }

        /// <summary>
        /// 更新申请单的订购状态，如果是部分采购，则为-2，如果是全部采购，则为9，如果均未采购，则不变
        /// 在这里，不判断其原始状态，不需要一定是 申请审核完成的单子。
        /// </summary>
        /// <param name="applyId">申请单id</param>
        /// <returns>是否成功设置</returns>
        private bool ResetApplicationState(string applyId, int newState, out string err)
        {
            if (newState > 9 || newState < -9)
            {
                err = "ResetApplicationState 传入参数newState可用范围无效，正确范围应在[-9，9]";
                return false;
            }
            string sql = string.Format(
 @"UPDATE [T_MATERIAL_PURCHASE_APPLY] 
SET [STATE] = {1}
WHERE  PURCHASE_APPLYID = '{0}'", applyId, newState);
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 读取船长审核通过的申请单 zhangy-2013-6-26
        /// <summary>
        /// 读取船长审核通过的申请单
        /// </summary>
        /// <param name="shipId">船舶ID</param>
        /// <param name="effectiveDate">数据有效日期</param>
        /// <param name="isReference">是否显示被使用过的数据</param>
        /// <param name="dtSource">返回的查询数据</param>
        /// <param name="errMessage">错误消息</param>
        /// <returns>True查询成功False查询失败</returns>
        public Boolean SelectPurchaseApplyTable(String shipId, DateTime effectiveDate,
            Boolean isReference, out DataTable dtSource, out String errMessage)
        {
            errMessage = "";
            StringBuilder sCondition = new StringBuilder();
            if (isReference)
            {
                sCondition.Append(" AND A.PURCHASE_APPLY_CODE NOT IN (SELECT ORDER_CODE FROM T_MATERIAL_DEPOT_OPERATION_DETAIL WHERE ORDER_CODE IS NOT NULL GROUP BY ORDER_CODE)");
            }
            String strSql =
                String.Format(@"SELECT A.PURCHASE_APPLYID,A.PURCHASE_APPLY_CODE,
                                S.SHIP_ID,S.SHIP_NAME,convert(varchar(10),A.PURCHASE_APPLY_DATE,111) as PURCHASE_APPLY_DATE,
                                A.ISCOMPLETE,A.ISCOMPLETE,CASE A. ISCOMPLETE
                                WHEN '0' THEN '未填写完毕'
                                WHEN '1' THEN '填写完毕'
                                END AS ISCOMPLETE_NAME,A.PURCHASE_APPLY_PERSON,
                                A.PURCHASE_APPLY_PERSON,A.PURCHASE_APPLY_PERSON_POSTID,A.STATE,
                                CASE A.STATE 
                                WHEN '0' THEN '未填写完毕'
                                WHEN '1' THEN '等待机务主管审批'
                                WHEN '2' THEN '等待机务经理审批'
                                WHEN '3' THEN '等待船管总经理审批'
                                WHEN '4' THEN '等待岸端机务经理审批'
                                WHEN '5' THEN '等待船管总经理审批'
                                WHEN '6' THEN '审核通过'
                                WHEN '7' THEN '取消'
                                WHEN '8' THEN '被打回'
                                WHEN '9' THEN '订购'
                                WHEN '-1' THEN '被合单'
                                END AS STATE_NAME,A.REMARK,A.SHIP_LEADER_CHECKER,A.SHIP_LEADER_CHECKDATE,A.SHIP_BOSS_CHECKER,A.SHIP_BOSS_CHECKDATE,A.LANDCHECKER,A.CHECKDATE,H.HEADSHIP_NAME,D.DEPARTNAME
                                FROM T_MATERIAL_PURCHASE_APPLY A
                                INNER JOIN T_SHIP S ON A.SHIP_ID=S.SHIP_ID
                                INNER JOIN T_BASE_HEADSHIP H ON H.SHIP_HEADSHIP_ID=A.PURCHASE_APPLY_PERSON_POSTID 
                                INNER JOIN T_DEPARTMENT D ON D.DEPARTMENTID=A.DEPART_ID 
                                WHERE 1=1 
                                AND A.STATE>=3
                                AND A.SHIP_ID='{0}'
                                AND A.PURCHASE_APPLY_DATE>'{1}' {2}",
                                shipId, effectiveDate, sCondition.ToString());

            return dbAccess.GetDataTable(strSql, out dtSource, out errMessage);
        }
        #endregion


        #region 读取所有申请单 zhangy-2013-8-6 2014年5月19日 徐正本关闭掉，
        //        /// <summary>
        //        /// 读取所有申请单
        //        /// </summary>
        //        /// <param name="shipId">船舶ID</param>
        //        /// <param name="isReference">是否显示被使用过的数据</param>
        //        /// <param name="dtSource">返回的查询数据</param>
        //        /// <param name="errMessage">错误消息</param>
        //        /// <returns>True查询成功False查询失败</returns>
        //        public Boolean SelectPurchaseApplyTableForEnquiry(String shipId,
        //            Boolean isReference, out DataTable dtSource, out String errMessage)
        //        {
        //            errMessage = "";
        //            StringBuilder sCondition = new StringBuilder();
        //            if (!isReference)
        //            {
        //                sCondition.Append(" AND A.CC <>0 ");
        //            }
        //            String strSql =
        //                String.Format(@"SELECT A.*,
        //
        //CASE CC
        //WHEN '0' THEN '完全导入'
        //WHEN SS THEN '未曾导入'
        //ELSE '部分导入'
        //END AS IMPORTSTATE
        // FROM  (SELECT A.PURCHASE_APPLYID,A.PURCHASE_APPLY_CODE,
        //                                S.SHIP_ID,S.SHIP_NAME,convert(varchar(10),A.PURCHASE_APPLY_DATE,111) as PURCHASE_APPLY_DATE,
        //                                A.ISCOMPLETE,CASE A. ISCOMPLETE
        //                                WHEN '0' THEN '未填写完毕' WHEN '1' THEN '填写完毕'  END AS ISCOMPLETE_NAME,
        //                                A.PURCHASE_APPLY_PERSON,A.PURCHASE_APPLY_PERSON_POSTID,A.STATE,
        //                                CASE A.STATE 
        //                                WHEN '0' THEN '未填写完毕'
        //                                WHEN '1' THEN '等待机务主管审批'
        //                                WHEN '2' THEN '等待机务经理审批'
        //                                WHEN '3' THEN '等待船管总经理审批'
        //                                WHEN '4' THEN '等待岸端机务经理审批'
        //                                WHEN '5' THEN '等待船管总经理审批'
        //                                WHEN '6' THEN '审核通过'
        //                                WHEN '7' THEN '取消'
        //                                WHEN '8' THEN '被打回'
        //                                WHEN '9' THEN '订购'
        //                                WHEN '-1' THEN '被合单'
        //                                END AS STATE_NAME,A.REMARK,A.SHIP_LEADER_CHECKER,A.SHIP_LEADER_CHECKDATE,A.SHIP_BOSS_CHECKER,A.SHIP_BOSS_CHECKDATE,A.LANDCHECKER,A.CHECKDATE,H.HEADSHIP_NAME,D.DEPARTNAME,
        //                                (
        //select COUNT(1) from dbo.T_MATERIAL_PURCHASE_APPLY_DETAIL 
        //where PURCHASE_APPLY_DETAIL_ID not in (
        //select PURCHASE_APPLY_DETAIL_ID from dbo.T_MATERIAL_PURCHASE_ENQUIRY_DETAIL )
        //and PURCHASE_APPLYID=A.PURCHASE_APPLYID
        //) AS CC,
        //(SELECT COUNT(1)  FROM dbo.T_MATERIAL_PURCHASE_APPLY_DETAIL
        //WHERE PURCHASE_APPLYID=A.PURCHASE_APPLYID ) AS SS
        //                                
        //                                FROM T_MATERIAL_PURCHASE_APPLY A
        //                                INNER JOIN T_SHIP S ON A.SHIP_ID=S.SHIP_ID
        //                                INNER JOIN T_BASE_HEADSHIP H ON H.SHIP_HEADSHIP_ID=A.PURCHASE_APPLY_PERSON_POSTID 
        //                                INNER JOIN T_DEPARTMENT D ON D.DEPARTMENTID=A.DEPART_ID 
        //                                WHERE 1=1 
        //                                AND A.STATE in (3,4,5,6)
        //                                AND A.SHIP_ID='{0}') A where 1=1  {1}",
        //                                shipId, sCondition.ToString());

        //            return dbAccess.GetDataTable(strSql, out dtSource, out errMessage);
        //        }
        #endregion

        #region 合单处理后，把所有相关申请单的状态置为-1 xzb 2013-8-22

        private string MergeString(List<String> IdList)
        {
            if (IdList.Count == 0) return "";
            StringBuilder ids = new StringBuilder();
            foreach (String id in IdList)
            {
                ids.Append("'" + dbOperation.ReplaceSqlKeyStr(id) + "',");
            }
            return ids.Remove(ids.Length - 1, 1).ToString();
        }
        private void ChangeApplyState(List<string> applyIds, int state)
        {
            string ids = MergeString(applyIds);
            if (string.IsNullOrEmpty(ids)) return;
            //2014-7-2xuzb ,修改原bug，"+ {2} + '修改为当前状态'" 这种情况下，人员名称没有包在引号中，SQL失败，这是后来修改出的bug，以后请增加备注说明
            sql = string.Format(@"UPDATE T_MATERIAL_PURCHASE_APPLY 
SET STATE ={0},
remark = remark + char(13) + char (10) + convert(varchar(20),getdate(),121) + '{2}修改为当前状态'
where PURCHASE_APPLYID in ({1})", state, ids, CommonOperation.ConstParameter.UserName);
            string err;
            dbAccess.ExecSql(sql, out err);
        }

        /// <summary>
        /// 合单处理后，把所有相关申请单的状态置为-1 xzb 2013-8-22
        /// 因为此业务并非必须执行成功，因此并没有设置返回值，和错误提示。
        /// </summary>
        /// <param name="IdList"></param>
        public void CombinedAllApplyBillAndChangeState(List<String> IdList)
        {
            ChangeApplyState(IdList, -1);
        }

        /// <summary>
        /// 部分审批完成的单子，把所有相关申请单的状态置为9 xzb 2013-8-22
        /// </summary>
        /// <param name="IdList"></param>
        public void FinishAllApplyBillAndChangeState(List<String> IdList)
        {
            ChangeApplyState(IdList, 9);
        }
        #endregion

        #region 根据过滤条件查询
        public bool SelectDataTable(String sWhere, out DataTable dt , out string errMessage)
        {
            
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(@"select	
spa.PURCHASE_APPLYID
,spa.PURCHASE_APPLY_CODE
,spa.SHIP_ID
,s.SHIP_NAME
,case spa.STATE 
  when '0' then '未填写完毕'
  when '1' then '等待部门长审核'
  when '2' then '等待船长审核'
  when '3' then '等待岸端机务主管审批'
  when '4' then '等待岸端机务经理审批'
  when '5' then '等待船管总经理审批'
  when '6' then '审核通过'
  when '7' then '不再处理'
  when '8' then '被打回'
  when '9' then '全部订购'
  when '-1' then '船端合单'
  when '-2' then '部分订购'
  when '-3' then '部分入库'
  when '-4' then '全部入库'
  end as STATE_NAME
,spa.PURCHASE_APPLY_PERSON
,spa.PURCHASE_APPLY_PERSON_POSTID
,bh.HEADSHIP_NAME
,bh.ISLANDPOST
,spa.DEPART_ID
,d.DEPARTNAME
,spa.PURCHASE_APPLY_DATE
,spa.ISCOMPLETE
 ,case spa.ISCOMPLETE 
  when '0' then '未填写完毕'
  when '1' then '填写完毕'
  end as ISCOMPLETE_NAME
,spa.SHIP_LEADER_CHECKER
,spa.SHIP_LEADER_CHECKDATE
,spa.SHIP_BOSS_CHECKER
,spa.SHIP_BOSS_CHECKDATE
,spa.LANDCHECKER
,spa.CHECKDATE
,spa.STATE
,spa.REMARK
 from T_MATERIAL_PURCHASE_APPLY spa
 inner join T_SHIP s on s.SHIP_ID=spa.SHIP_ID 
 ");
                if (CommonOperation.ConstParameter.IsLandVersion)
                {
                    sb.AppendLine("  inner join T_USER_SHIP us on us.ship_id=spa.SHIP_ID and us.userid = '" + CommonOperation.ConstParameter.UserId + "'");
                }
                sb.AppendLine(" inner join T_BASE_HEADSHIP bh on bh.SHIP_HEADSHIP_ID=spa.PURCHASE_APPLY_PERSON_POSTID ");
                sb.AppendLine(" inner join T_DEPARTMENT d on d.DEPARTMENTID=spa.DEPART_ID ");
                sb.AppendLine(" WHERE 1=1 ");
                if (!String.IsNullOrEmpty(sWhere))
                {
                    sb.AppendLine(sWhere);
                }
                sb.AppendLine(" order by spa.PURCHASE_APPLY_DATE desc");
                dt = new DataTable();
                return dbAccess.GetDataTable(sb.ToString(), out dt, out errMessage);
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                dt = null;
                return false;
            }
            
            
        }
        #endregion
    }
}
