/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：ShipRepairProjectService.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/7/25
 * 标    题：数据操作类
 * 功能描述：T_SHIP_REPAIR_PROJECT数据操作类
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
using Repair.DataObject;

namespace Repair.Services
{
    public partial class ShipRepairProjectService
    {
        /// <summary>
        /// 根据条件 得到  T_SHIP_REPAIR_PROJECT数据信息.
        /// </summary>
        /// <returns>T_SHIP_REPAIR_PROJECT DataTable</returns>
        public DataTable GetInfo(string applyId, string shipId, string type, string department, string chkState, string onlyPostID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" select");
            sb.AppendLine(" s.SHIP_NAME");
            sb.AppendLine(" ,srp.PROJECTID");
            sb.AppendLine(" ,srp.PROJECTNAME");
            sb.AppendLine(" ,srp.PROJECTDETAIL");
            sb.AppendLine(" ,srp.EQUIPMENTID");
            sb.AppendLine(" ,cu.COMP_CHINESE_NAME");
            sb.AppendLine(" ,[dbo].[F_Get_Comp_Full_name](cu.COMPONENT_UNIT_ID,1) COMP_FULL_NAME");
            sb.AppendLine(" ,convert(varchar(10), srp.APPLYDATE,111) APPLYDATE ");
            sb.AppendLine(" ,srp.APPLICANT");
            sb.AppendLine(" ,srp.APPLYPOST");
            sb.AppendLine(" ,bh.HEADSHIP_NAME");
            sb.AppendLine(" ,srp.RUNNINGORDOCK");
            sb.AppendLine(" ,case srp.RUNNINGORDOCK ");
            sb.AppendLine("  when '1' then '航修'");
            sb.AppendLine("  when '2' then '坞修'");
            sb.AppendLine("  end as RUNNINGORDOCK_NAME");
            sb.AppendLine(" ,srp.REPAIRSUBJECT");
            sb.AppendLine(" ,ca.NODE_NAME");
            sb.AppendLine(" ,convert(varchar(10), srp.APPLYCOMPLETEDATE,111) APPLYCOMPLETEDATE");
            sb.AppendLine(" ,srp.PROJECTSTATE");
            sb.AppendLine(" ,case srp.PROJECTSTATE ");
            sb.AppendLine("  when '1' then '未审核'");
            sb.AppendLine("  when '2' then '等待部门长审批'");
            sb.AppendLine("  when '3' then '等待船长审批'");
            sb.AppendLine("  when '4' then '等待岸端机务主管审批'");
            sb.AppendLine("  when '5' then '等待岸端机务经理审批'");
            sb.AppendLine("  when '6' then '等待船管总经理审批'");
            sb.AppendLine("  when '7' then '申请通过等待委托'");
            sb.AppendLine("  when '8' then '已经委托'");
            sb.AppendLine("  when '9' then '已经完成'");
            sb.AppendLine("  when '10' then '已经取消'");
            sb.AppendLine("  end as PROJECTSTATE_NAME");
            sb.AppendLine(" ,srp.REMARK");

            sb.AppendLine(" ,sre.REPAIRID");
            sb.AppendLine(" ,sre.REPAIRCODE");
            sb.AppendLine(" ,sre.REPAIRPORT");
            sb.AppendLine(" ,sre.ARRANGED");
            sb.AppendLine(" ,case sre.ARRANGED ");
            sb.AppendLine("  when 0 then '未完成'");
            sb.AppendLine("  when 1 then '已完成'");
            sb.AppendLine("  end as ARRANGED_NAME");
            sb.AppendLine(" ,sre.ARRANGEDPERSON");
            sb.AppendLine(" ,sre.SHIPAFFIRMANT");
            sb.AppendLine(" ,sre.COMPAFFIRMANT");
            sb.AppendLine(" ,sre.REPAIRDATE");
            sb.AppendLine(" ,sre.COMPLETEDATE");
            sb.AppendLine(" ,sre.REMARK as REPAIR_REMARK");

            sb.AppendLine(" ,srp.SERVICEPROVIDER");
            sb.AppendLine(" ,m.MANUFACTURER_NAME");
            sb.AppendLine(" ,srp.WORKORDERID");
            sb.AppendLine(" ,convert(varchar(10), srp.REALCOMPLETEDATE,111) REALCOMPLETEDATE");
            sb.AppendLine(" ,srp.AFFIRMANT");
            sb.AppendLine(" ,srp.COMPLETEAFFIRMANT");
            sb.AppendLine(" ,srp.SHIP_ID");
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                sb.AppendLine(" ,srp.CURRENCYID");
                sb.AppendLine(" ,g.CURRENCYCODE");
                sb.AppendLine(" ,srp.COSTCOUNT");
            }
            sb.AppendLine(" ,srp.SENDTOWARRANT");
            sb.AppendLine(" ,case srp.SENDTOWARRANT ");
            sb.AppendLine("  when '0' then '未提交'");
            sb.AppendLine("  when '1' then '已提交'");
            sb.AppendLine("  end as SENDTOWARRANT_NAME");
            sb.AppendLine(" ,bh.SHIP_HEADSHIP_ID");
            sb.AppendLine(" ,bh.DEPARTMENTID");
            sb.AppendLine(" ,sr.RELATIONID");
            sb.AppendLine(" ,srp.VOUCHER_ID");
            sb.AppendLine("   from T_SHIP_REPAIR_PROJECT srp");
            sb.AppendLine("  inner join t_ship s on s.ship_id=srp.ship_id ");
            if (CommonOperation.ConstParameter.IsLandVersion)
                sb.AppendLine("  inner join T_USER_SHIP us on us.ship_id=s.SHIP_ID and us.userid = '" + CommonOperation.ConstParameter.UserId + "'");
            sb.AppendLine("  inner join T_BASE_HEADSHIP bh on bh.SHIP_HEADSHIP_ID=srp.APPLYPOST ");
            sb.AppendLine("  left join T_COST_ACCOUNT ca on ca.NODE_ID=srp.REPAIRSUBJECT ");
            sb.AppendLine("  left join T_SHIPRUNNINGREPAIR_RELATION sr on sr.PROJECTID=srp.PROJECTID and sr.state in (1,3) ");
            sb.AppendLine("  left join T_MANUFACTURER m on m.MANUFACTURER_ID=srp.SERVICEPROVIDER  ");
            sb.AppendLine("  left join T_COMPONENT_UNIT cu on srp.EQUIPMENTID=cu.COMPONENT_UNIT_ID ");
            sb.AppendLine("  left join T_SHIP_REPAIR_EVENT sre on sre.REPAIRID=sr.REPAIRID  ");
            sb.AppendLine("  left join T_CURRENCY g on srp.CURRENCYID=g.CURRENCYID ");
            sb.AppendLine("  where 1=1 ");
            if (!string.IsNullOrEmpty(applyId))
                sb.AppendLine("  and srp.PROJECTID='" + applyId + "'");
            if (!string.IsNullOrEmpty(shipId) && shipId != "0")
                sb.AppendLine("  and srp.SHIP_ID='" + shipId + "'");
            if (!string.IsNullOrEmpty(type) && type != "0")
                sb.AppendLine("  and srp.RUNNINGORDOCK = " + type);
            if (!string.IsNullOrEmpty(chkState) && chkState != "0")
                sb.AppendLine("  and srp.PROJECTSTATE IN (" + chkState + ")");
            if (!string.IsNullOrEmpty(onlyPostID))
                sb.AppendLine("  and bh.SHIP_HEADSHIP_ID='" + onlyPostID + "'");
            if (!string.IsNullOrEmpty(department) && department != "0")
                sb.AppendLine("  and bh.DEPARTMENTID='" + department + "'");
            sb.AppendLine("  order by srp.APPLYDATE desc");
            string err;
            DataTable dt;
            if (dbAccess.GetDataTable(sb.ToString(), out dt, out err))
            {
                return dt;
            }
            else
            {
                throw new Exception(err);
            }
        }

        #region 2014-12-03-wanhw-根据下拉框选择的状态，返回对应的备件申请状态字符串用逗号隔开
        /// <summary>
        /// 根据下拉框选择的状态，返回对应的备件申请状态字符串用逗号隔开.
        /// </summary>
        /// <param name="viewerState">下拉框选择的状态.</param>
        /// <returns>对应的备件申请状态字符串用逗号隔开.</returns>
        internal string GetBusinessStateByViewerState(string viewerState)
        {
            switch (viewerState)
            {
                case "2":
                    return "2,3,4,5,6";

                case "3":
                    return "7";

                case "4":
                    return "8";

                case "5":
                    return "9";
#if DEBUG
                default:
                    throw new Exception("getBusinessStateByViewerState 调用异常，传入参数无效！");
            }
#else
            }
            return "";
#endif
        }

        #endregion

        /// <summary>
        /// 完工单用.
        /// </summary>
        /// <returns>T_SHIP_REPAIR_PROJECT DataTable</returns>
        public DataTable GetCompleteInfo(string repairid)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" select");
            sb.AppendLine(" case sr.STATE  when 1 then '完成' when 2 then '本次取消' when 3 then '未完成' when 4 then '关闭项目' end as STATE_NAME");
            sb.AppendLine(" ,srp.SHIP_ID");
            sb.AppendLine(" ,s.SHIP_NAME");
            sb.AppendLine(" ,srp.PROJECTID");
            sb.AppendLine(" ,srp.PROJECTNAME");
            sb.AppendLine(" ,srp.PROJECTDETAIL");
            sb.AppendLine(" ,convert(varchar(10), srp.REALCOMPLETEDATE,111) REALCOMPLETEDATE");
            sb.AppendLine(" ,srp.CURRENCYID");
            sb.AppendLine(" ,g.CURRENCYCODE");
            sb.AppendLine(" ,srp.COSTCOUNT");
            sb.AppendLine(" ,srp.COMPLETEAFFIRMANT");
            sb.AppendLine(" ,srp.EQUIPMENTID");
            sb.AppendLine(" ,cu.COMP_CHINESE_NAME");
            sb.AppendLine(" ,convert(varchar(10), srp.APPLYDATE,111) APPLYDATE");
            sb.AppendLine(" ,srp.APPLICANT");
            sb.AppendLine(" ,srp.APPLYPOST");
            sb.AppendLine(" ,bh.HEADSHIP_NAME");
            sb.AppendLine(" ,srp.RUNNINGORDOCK");
            sb.AppendLine(" ,case srp.RUNNINGORDOCK ");
            sb.AppendLine("  when '1' then '航修'");
            sb.AppendLine("  when '2' then '坞修'");
            sb.AppendLine("  end as RUNNINGORDOCK_NAME");
            sb.AppendLine(" ,srp.REPAIRSUBJECT");
            sb.AppendLine(" ,ca.NODE_NAME");
            sb.AppendLine(" ,convert(varchar(10), srp.APPLYCOMPLETEDATE,111) APPLYCOMPLETEDATE");
            sb.AppendLine(" ,srp.PROJECTSTATE");
            sb.AppendLine(" ,srp.SERVICEPROVIDER");
            sb.AppendLine(" ,m.MANUFACTURER_NAME");
            sb.AppendLine(" ,srp.WORKORDERID");
            sb.AppendLine(" ,srp.AFFIRMANT");
            sb.AppendLine(" ,srp.REMARK");
            sb.AppendLine(" ,srp.SENDTOWARRANT");
            sb.AppendLine(" ,case srp.SENDTOWARRANT ");
            sb.AppendLine("  when '0' then '未提交'");
            sb.AppendLine("  when '1' then '已提交'");
            sb.AppendLine("  end as SENDTOWARRANT_NAME");
            sb.AppendLine(" ,bh.SHIP_HEADSHIP_ID");
            sb.AppendLine(" ,bh.DEPARTMENTID");
            sb.AppendLine(" ,sr.RELATIONID");
            sb.AppendLine(" ,sr.STATE");
            sb.AppendLine(" ,sr.REMARK as SRREMARK");
            sb.AppendLine("   from T_SHIP_REPAIR_PROJECT srp");
            sb.AppendLine("  inner join t_ship s on s.ship_id=srp.ship_id ");
            sb.AppendLine("  inner join T_BASE_HEADSHIP bh on bh.SHIP_HEADSHIP_ID=srp.APPLYPOST ");
            sb.AppendLine("  inner join T_COST_ACCOUNT ca on ca.NODE_ID=srp.REPAIRSUBJECT ");
            sb.AppendLine("  left join T_SHIPRUNNINGREPAIR_RELATION sr on sr.PROJECTID=srp.PROJECTID ");
            sb.AppendLine("  left join T_MANUFACTURER m on m.MANUFACTURER_ID=srp.SERVICEPROVIDER  ");
            sb.AppendLine("  left join T_COMPONENT_UNIT cu on srp.EQUIPMENTID=cu.COMPONENT_UNIT_ID ");
            sb.AppendLine("  left join T_CURRENCY g on srp.CURRENCYID=g.CURRENCYID ");
            sb.AppendLine("  where 1=1 ");
            sb.AppendLine("  and sr.REPAIRID ='" + repairid + "'");
            sb.AppendLine("  order by sr.STATE desc");
            string err;
            DataTable dt;
            if (dbAccess.GetDataTable(sb.ToString(), out dt, out err))
            {
                return dt;
            }
            else
            {
                throw new Exception(err);
            }
        }
        /// <summary>
        /// 根据条件 得到详细信息 委托查询时用.
        /// </summary>
        /// <returns></returns>
        public DataTable GetDelegateDetailInfo(string repairid, string shipId, string state)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" select	 ");
            sb.AppendLine(" case sr.STATE  when 1 then '完成' when 2 then '本次取消' when 3 then '未完成' when 4 then '关闭项目' end as STATE_NAME");
            sb.AppendLine(" ,s.SHIP_NAME");
            sb.AppendLine(" ,srp.PROJECTID");
            sb.AppendLine(" ,srp.PROJECTNAME");
            sb.AppendLine(" ,srp.PROJECTDETAIL");
            sb.AppendLine(" ,srp.EQUIPMENTID");
            sb.AppendLine(" ,cu.COMP_CHINESE_NAME");
            sb.AppendLine(" ,convert(varchar(10), srp.APPLYDATE,111) APPLYDATE");
            sb.AppendLine(" ,convert(varchar(10), srp.APPLYCOMPLETEDATE,111) APPLYCOMPLETEDATE");
            sb.AppendLine(" ,srp.APPLICANT");
            sb.AppendLine(" ,bh.HEADSHIP_NAME");
            sb.AppendLine(" ,srp.APPLYPOST");
            sb.AppendLine(" ,case srp.RUNNINGORDOCK ");
            sb.AppendLine("  when '1' then '航修'");
            sb.AppendLine("  when '2' then '坞修'");
            sb.AppendLine("  end as RUNNINGORDOCK_NAME");
            sb.AppendLine(" ,ca.NODE_NAME");
            sb.AppendLine(" ,srp.WORKORDERID");
            //sb.AppendLine(" ,convert(varchar(10), srp.REALCOMPLETEDATE,111) REALCOMPLETEDATE");
            //sb.AppendLine(" ,srp.PROJECTSTATE");
            sb.AppendLine(" ,srp.AFFIRMANT");
            //sb.AppendLine(" ,srp.COMPLETEAFFIRMANT");
            sb.AppendLine(" ,srp.RUNNINGORDOCK");
            sb.AppendLine(" ,srp.REPAIRSUBJECT");
            sb.AppendLine(" ,srp.SHIP_ID");
            sb.AppendLine(" ,bh.SHIP_HEADSHIP_ID");
            sb.AppendLine(" ,bh.DEPARTMENTID");
            //sb.AppendLine(" ,case srp.PROJECTSTATE ");
            //sb.AppendLine("  when '1' then '未审核'");
            //sb.AppendLine("  when '2' then '等待部门长审批'");
            //sb.AppendLine("  when '3' then '等待船长审批'");
            //sb.AppendLine("  when '4' then '等待岸端机务主管审批'");
            //sb.AppendLine("  when '5' then '等待岸端机务经理审批'");
            //sb.AppendLine("  when '6' then '等待船管总经理审批'");
            //sb.AppendLine("  when '7' then '申请通过等待委托'");
            //sb.AppendLine("  when '8' then '已经委托'");
            //sb.AppendLine("  when '9' then '已经完成'");
            //sb.AppendLine("  when '10' then '已经取消'");
            //sb.AppendLine("  end as PROJECTSTATE_NAME");
            sb.AppendLine(" ,srp.REMARK");
            sb.AppendLine(" ,sr.RELATIONID");
            sb.AppendLine("   from T_SHIP_REPAIR_PROJECT srp");
            sb.AppendLine("  inner join t_ship s on s.ship_id=srp.ship_id ");
            sb.AppendLine("  inner join T_BASE_HEADSHIP bh on bh.SHIP_HEADSHIP_ID=srp.APPLYPOST ");
            sb.AppendLine("  inner join T_COST_ACCOUNT ca on ca.NODE_ID=srp.REPAIRSUBJECT ");
            sb.AppendLine("  left join T_SHIPRUNNINGREPAIR_RELATION sr on sr.PROJECTID=srp.PROJECTID ");
            sb.AppendLine("  left join T_MANUFACTURER m on m.MANUFACTURER_ID=srp.SERVICEPROVIDER  ");
            sb.AppendLine("  left join T_COMPONENT_UNIT cu on srp.EQUIPMENTID=cu.COMPONENT_UNIT_ID ");
            sb.AppendLine("   where 1=1 ");
            if (!string.IsNullOrEmpty(repairid))
                sb.AppendLine(" and srp.PROJECTID in (select PROJECTID from T_SHIPRUNNINGREPAIR_RELATION where REPAIRID='" + repairid + "')");
            if (!string.IsNullOrEmpty(shipId) && shipId != "0")
                sb.AppendLine("  and srp.SHIP_ID='" + shipId + "'");
            if (!string.IsNullOrEmpty(state) && state != "0")
                sb.AppendLine("  and srp.PROJECTSTATE in (" + state + ")");
            sb.AppendLine("  order by srp.APPLYDATE desc");
            string err;
            DataTable dt;
            if (dbAccess.GetDataTable(sb.ToString(), out dt, out err))
            {
                return dt;
            }
            else
            {
                throw new Exception(err);
            }
        }

        /// <summary>
        /// 根据条件 得到详细信息 委托操作时用.
        /// </summary>
        /// <returns></returns>
        public DataTable GetDelegateOperation(string repairid, string shipId, string state)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" select	 ");
            sb.AppendLine(" s.SHIP_NAME");
            sb.AppendLine(" ,srp.PROJECTID");
            sb.AppendLine(" ,srp.PROJECTNAME");
            sb.AppendLine(" ,srp.PROJECTDETAIL");
            sb.AppendLine(" ,srp.EQUIPMENTID");
            sb.AppendLine(" ,cu.COMP_CHINESE_NAME");
            sb.AppendLine(" ,convert(varchar(10), srp.APPLYDATE,111) APPLYDATE");
            sb.AppendLine(" ,convert(varchar(10), srp.APPLYCOMPLETEDATE,111) APPLYCOMPLETEDATE");
            sb.AppendLine(" ,srp.APPLICANT");
            sb.AppendLine(" ,bh.HEADSHIP_NAME");
            sb.AppendLine(" ,srp.APPLYPOST");
            sb.AppendLine(" ,case srp.RUNNINGORDOCK ");
            sb.AppendLine("  when '1' then '航修'");
            sb.AppendLine("  when '2' then '坞修'");
            sb.AppendLine("  end as RUNNINGORDOCK_NAME");
            sb.AppendLine(" ,ca.NODE_NAME");
            sb.AppendLine(" ,srp.WORKORDERID");
            sb.AppendLine(" ,srp.AFFIRMANT");
            sb.AppendLine(" ,srp.RUNNINGORDOCK");
            sb.AppendLine(" ,srp.REPAIRSUBJECT");
            sb.AppendLine(" ,srp.SHIP_ID");
            sb.AppendLine(" ,bh.SHIP_HEADSHIP_ID");
            sb.AppendLine(" ,bh.DEPARTMENTID");
            sb.AppendLine(" ,srp.REMARK");
            sb.AppendLine(" ,srp.PROJECTSTATE");
            sb.AppendLine("   from T_SHIP_REPAIR_PROJECT srp");
            sb.AppendLine("  inner join t_ship s on s.ship_id=srp.ship_id ");
            sb.AppendLine("  inner join T_BASE_HEADSHIP bh on bh.SHIP_HEADSHIP_ID=srp.APPLYPOST ");
            sb.AppendLine("  inner join T_COST_ACCOUNT ca on ca.NODE_ID=srp.REPAIRSUBJECT ");
            if (!string.IsNullOrEmpty(repairid))
            {
                sb.AppendLine("  left join T_SHIPRUNNINGREPAIR_RELATION sr on sr.PROJECTID=srp.PROJECTID ");
            }
            sb.AppendLine("  left join T_MANUFACTURER m on m.MANUFACTURER_ID=srp.SERVICEPROVIDER  ");
            sb.AppendLine("  left join T_COMPONENT_UNIT cu on srp.EQUIPMENTID=cu.COMPONENT_UNIT_ID ");
            sb.AppendLine("   where 1=1 ");
            if (!string.IsNullOrEmpty(repairid))
            {
                sb.AppendLine(" and srp.PROJECTID in (select PROJECTID from T_SHIPRUNNINGREPAIR_RELATION where REPAIRID='" + repairid + "')");
                sb.AppendLine(" and sr.state in (1,3) ");
            }
            if (!string.IsNullOrEmpty(shipId) && shipId != "0")
                sb.AppendLine("  and srp.SHIP_ID='" + shipId + "'");
            if (!string.IsNullOrEmpty(state) && state != "0")
                sb.AppendLine("  and srp.PROJECTSTATE in (" + state + ")");
            sb.AppendLine("  order by srp.APPLYDATE desc");
            string err;
            DataTable dt;
            if (dbAccess.GetDataTable(sb.ToString(), out dt, out err))
            {
                return dt;
            }
            else
            {
                throw new Exception(err);
            }
        }

        public bool HaveAlreadyAppliedTheWorkOrder(string repaireId, string workOrderId)
        {
            sql = "select count(1) from T_SHIP_REPAIR_PROJECT "
                + "\rwhere workOrderId = '" + dbOperation.ReplaceSqlKeyStr(workOrderId) + "'"
                + "\r and PROJECTSTATE < 9 and PROJECTID !=  '" + dbOperation.ReplaceSqlKeyStr(repaireId) + "'";

            return (dbAccess.GetString(sql) != "0");
        }

        public bool GetRepairToSAP(string id, out DataTable dtb, out string err)
        {
            //变量定义部分.
            string sSql = "";                   //查询数据所需的SQL语句.
            //Select语句加工部分.
            sSql += "select ";
            sSql += "a.CUSTOMER as SUPPLIER,";
            sSql += "c.CURRENCYCODE as CURRENCY,";
            sSql += "a.AMOUNT as AMOUNT,";
            sSql += "b.NODE_ID as SUBJECT,";
            sSql += "'D' as COST_TYPE,";
            sSql += "a.ship_id as ship_id,";
            sSql += "s.OWNER_ID as UUID ";
            sSql += " from T_COST_ACTUAL_COSTS a, T_COST_ACCOUNT b,T_Currency c,T_COST_SHIPOWNER_AMOUNT s  ";
            sSql += " where a.NODE_ID = b.NODE_ID and a.CURRENCY_ID = c.CURRENCYID and a.COSTS_ID = s.COST_ID and s.OWNER_ID = '" + id + "'";
            return dbAccess.GetDataTable(sSql, out dtb, out err);
        }
        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">ShipRepairProject对象</param>
        /// <param name="operationType">操作类型,1:插入,2:更新</param>
        public string saveUnit(ShipRepairProject unit, int operationType)
        {
            if (operationType == 2)
            {
                sql = "UPDATE [T_SHIP_REPAIR_PROJECT] SET "
                    + " [PROJECTID] = " + (string.IsNullOrEmpty(unit.PROJECTID) ? "null" : "'" + unit.PROJECTID.Replace("'", "''") + "'")
                    + " , [PROJECTNAME] = " + (unit.PROJECTNAME == null ? "''" : "'" + unit.PROJECTNAME.Replace("'", "''") + "'")
                    + " , [PROJECTDETAIL] = N" + (unit.PROJECTDETAIL == null ? "''" : "'" + unit.PROJECTDETAIL.Replace("'", "''") + "'")
                    + " , [APPLYDATE] = " + dbOperation.DbToDate(unit.APPLYDATE)
                    + " , [APPLICANT] = " + (unit.APPLICANT == null ? "''" : "'" + unit.APPLICANT.Replace("'", "''") + "'")
                    + " , [WORKORDERID] = " + (string.IsNullOrEmpty(unit.WORKORDERID) ? "null" : "'" + unit.WORKORDERID.Replace("'", "''") + "'")
                    + " , [APPLYCOMPLETEDATE] = " + dbOperation.DbToDate(unit.APPLYCOMPLETEDATE)
                    + " , [REALCOMPLETEDATE] = " + dbOperation.DbToDate(unit.REALCOMPLETEDATE)
                    + " , [PROJECTSTATE] = " + unit.PROJECTSTATE.ToString()
                    + " , [AFFIRMANT] = " + (unit.AFFIRMANT == null ? "''" : "'" + unit.AFFIRMANT.Replace("'", "''") + "'")
                    + " , [COMPLETEAFFIRMANT] = " + (unit.COMPLETEAFFIRMANT == null ? "''" : "'" + unit.COMPLETEAFFIRMANT.Replace("'", "''") + "'")
                    + " , [RUNNINGORDOCK] = " + unit.RUNNINGORDOCK.ToString()
                    + " , [REPAIRSUBJECT] = " + (string.IsNullOrEmpty(unit.REPAIRSUBJECT) ? "null" : "'" + unit.REPAIRSUBJECT.Replace("'", "''") + "'")
                    + " , [SERVICEPROVIDER] = " + (string.IsNullOrEmpty(unit.SERVICEPROVIDER) ? "null" : "'" + unit.SERVICEPROVIDER.Replace("'", "''") + "'")
                    + " , [REMARK] = N" + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , [CURRENCYID] = " + (string.IsNullOrEmpty(unit.CURRENCYID) ? "null" : "'" + unit.CURRENCYID.Replace("'", "''") + "'")
                    + " , [COSTCOUNT] = " + unit.COSTCOUNT.ToString()
                    + " , [EQUIPMENTID] = " + (string.IsNullOrEmpty(unit.EQUIPMENTID) ? "null" : "'" + unit.EQUIPMENTID.Replace("'", "''") + "'")
                    + " , [SENDTOWARRANT] = " + unit.SENDTOWARRANT.ToString()
                    + " , [APPLYPOST] = " + (string.IsNullOrEmpty(unit.APPLYPOST) ? "null" : "'" + unit.APPLYPOST.Replace("'", "''") + "'")
                    + " , [VOUCHER_ID] = " + (string.IsNullOrEmpty(unit.VOUCHER_ID) ? "null" : "'" + unit.VOUCHER_ID.Replace("'", "''") + "'")
                    + " where upper(PROJECTID) = '" + unit.PROJECTID.ToUpper() + "'";
            }
            else if (operationType == 1)
            {
                sql = "INSERT INTO [T_SHIP_REPAIR_PROJECT] ("
                    + "[PROJECTID],"
                    + "[PROJECTNAME],"
                    + "[PROJECTDETAIL],"
                    + "[APPLYDATE],"
                    + "[APPLICANT],"
                    + "[WORKORDERID],"
                    + "[APPLYCOMPLETEDATE],"
                    + "[REALCOMPLETEDATE],"
                    + "[PROJECTSTATE],"
                    + "[AFFIRMANT],"
                    + "[COMPLETEAFFIRMANT],"
                    + "[RUNNINGORDOCK],"
                    + "[REPAIRSUBJECT],"
                    + "[SERVICEPROVIDER],"
                    + "[REMARK],"
                    + "[SHIP_ID],"
                    + "[CURRENCYID],"
                    + "[COSTCOUNT],"
                    + "[EQUIPMENTID],"
                    + "[SENDTOWARRANT],"
                    + "[APPLYPOST],"
                    + "[VOUCHER_ID]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.PROJECTID) ? "null" : "'" + unit.PROJECTID.Replace("'", "''") + "'")
                    + " , " + (unit.PROJECTNAME == null ? "''" : "'" + unit.PROJECTNAME.Replace("'", "''") + "'")
                    + " , N" + (unit.PROJECTDETAIL == null ? "''" : "'" + unit.PROJECTDETAIL.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.APPLYDATE)
                    + " , " + (unit.APPLICANT == null ? "''" : "'" + unit.APPLICANT.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.WORKORDERID) ? "null" : "'" + unit.WORKORDERID.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.APPLYCOMPLETEDATE)
                    + " ," + dbOperation.DbToDate(unit.REALCOMPLETEDATE)
                    + " ," + unit.PROJECTSTATE.ToString()
                    + " , " + (unit.AFFIRMANT == null ? "''" : "'" + unit.AFFIRMANT.Replace("'", "''") + "'")
                    + " , " + (unit.COMPLETEAFFIRMANT == null ? "''" : "'" + unit.COMPLETEAFFIRMANT.Replace("'", "''") + "'")
                    + " ," + unit.RUNNINGORDOCK.ToString()
                    + " , " + (string.IsNullOrEmpty(unit.REPAIRSUBJECT) ? "null" : "'" + unit.REPAIRSUBJECT.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SERVICEPROVIDER) ? "null" : "'" + unit.SERVICEPROVIDER.Replace("'", "''") + "'")
                    + " , N" + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.CURRENCYID) ? "null" : "'" + unit.CURRENCYID.Replace("'", "''") + "'")
                    + " ," + unit.COSTCOUNT.ToString()
                    + " , " + (string.IsNullOrEmpty(unit.EQUIPMENTID) ? "null" : "'" + unit.EQUIPMENTID.Replace("'", "''") + "'")
                    + " ," + unit.SENDTOWARRANT.ToString()
                    + " , " + (string.IsNullOrEmpty(unit.APPLYPOST) ? "null" : "'" + unit.APPLYPOST.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.VOUCHER_ID) ? "null" : "'" + unit.VOUCHER_ID.Replace("'", "''") + "'")
                    + ")";
            }

            return sql;
        }

        public void CheckLandOpinionColumnsExists()
        {
            sql = @"if not exists(select * from syscolumns where id=object_id('T_SHIP_REPAIR_PROJECT') and name='LandOpinion') 
begin
	ALTER TABLE T_SHIP_REPAIR_PROJECT ADD LandOpinion varchar(2000) NULL
	ALTER TABLE B_SHIP_REPAIR_PROJECT ADD LandOpinion varchar(2000) NULL
	insert into T_TABLE_FIELD (field_id, field_name, table_id, field_type, fk_table_id, sortNum, value_type)
	values (NEWID(),'LandOpinion','003e1b76-0d14-4d4d-9ac1-58e00d3cc997',0,null,23,0)
	Exec  dbo.P_Create_Sync_Trigger_All   
	exec  dbo.P_Create_All_view 
end";
            string err;
            dbAccess.ExecSql(sql,out err);
        }
    }
}