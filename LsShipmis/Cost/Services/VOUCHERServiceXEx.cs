/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：VOUCHERService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-7-4
 * 标    题：数据操作类
 * 功能描述：T_COST_VOUCHER数据操作类
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
using Cost.DataObject;
using BaseInfo.DataAccess;

namespace Cost.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_COST_VOUCHERService.cs
    /// </summary>
    public partial class VOUCHERService
    {
        /// <summary>
        /// 获得 "凭证月日" 数据.
        /// </summary>
        public DataTable getMonthDayByYear(DateTime year, string state, out string err)
        {
            sql = "select VOUCHER_DATE as ID,VOUCHER_DATE from (select convert(varchar(5),VOUCHER_DATE,110) as VOUCHER_DATE"
            + " from T_COST_VOUCHER a  ";
            sql += " where convert(varchar(4),a.VOUCHER_DATE,120)='" + year.ToString("yyyy") + "'";
            if (!string.IsNullOrEmpty(state))
                sql += " and  current_state in (" + state + ")";
            sql += " ) a group by VOUCHER_DATE";
            sql += " order by VOUCHER_DATE desc";
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
        /// 获得 "凭证月日" 数据.
        /// </summary>
        public DataTable GetMonthDayByYear(DateTime year, out string err)
        {
            sql = "select VOUCHER_DATE as ID,VOUCHER_DATE from (select convert(varchar(5),VOUCHER_DATE,110) as VOUCHER_DATE"
            + " from T_COST_VOUCHER a  ";
            sql += " where convert(varchar(4),a.VOUCHER_DATE,120)='" + year.ToString("yyyy") + "'";
            sql += " and  current_state in (4,5) ";
            sql += " and  budget_id is null ";
            sql += " ) a group by VOUCHER_DATE";
            sql += " order by VOUCHER_DATE desc";
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
        /// 根据凭证ID，获得 "单日凭证" 数据.
        /// </summary>
        public DataTable getInfoByVoucherID(List<string> voucherIDs, out string err)
        {
            string idsSql = "";
            foreach (string voucherID in voucherIDs)
            {
                idsSql += "'" + voucherID + "',";
            }
            idsSql = idsSql.Length > 0 ? idsSql.Substring(0, idsSql.Length - 1) : "";

            sql = string.Format(@"select a.VOUCHER_ID,a.VOUCHER_NUM,convert(varchar(10),a.VOUCHER_DATE,120)  VOUCHER_DATE
            ,a.SHIP_OWNER,b.APPLICANT,a.PAYEE, a.AMOUNT_LOW,a.AMOUNT_UP
            ,c.CURRENCYCODE,CONVERT(decimal(18,2),b.amount) as amount,c.CURRENCYNAME,b.remark
            ,a.CURRENT_STATE,case a.CURRENT_STATE when 1 then '未提交' when 2 then '审核中' when 3 then '被打回'
            when 4 then '审批完成'  when 5 then '已同步SAP' when 9 then '作废'  end as CURRENT_STATE_NAME,b.SENDED
            ,b.SHIP_ID ,a.BUSINESS_CODE,b.APPROVER,b.APPROVER2,b.COSTS_ID,ca.NODE_NAME,b.DESCRIPTION,ca.Code,a.INVOICE_NUM,a.APPLY_COMPANY  
             from T_COST_VOUCHER a
            left join T_COST_ACTUAL_COSTS b on a.VOUCHER_ID = b.VOUCHER_ID 
            left join t_cost_account ca on ca.node_id=b.node_id
            left join T_Currency c on b.CURRENCY_ID = c.CURRENCYID 
            left join t_cost_budget cb on cb.budget_id=a.budget_id
             where a.VOUCHER_ID  in ({0}) order by a.VOUCHER_NUM", idsSql);

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
        /// 根据不同条件得到凭证信息
        /// </summary>
        /// <param name="yearMonthDay">根据年、月、日的那种类型，1，年，2，月，3，日</param>
        /// <param name="paymentDate"></param>
        /// <param name="CURRENT_STATE"></param>
        /// <param name="userID"></param>
        /// <param name="SHIP_ID"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public DataTable getInfoByPaymentDate(int yearMonthDay, DateTime paymentDate, string CURRENT_STATE, string userID, string SHIP_ID, out string err)
        {
            sql = @"select a.VOUCHER_ID,a.VOUCHER_NUM,convert(varchar(10),a.VOUCHER_DATE,120)  VOUCHER_DATE,
            a.SHIP_OWNER,b.APPLICANT,a.PAYEE, a.AMOUNT_LOW,a.AMOUNT_UP,
            c.CURRENCYCODE,CONVERT(decimal(18,2),b.amount) as amount,
             (select SUM(amount) from T_COST_VOUCHER y left join T_COST_ACTUAL_COSTS w on y.VOUCHER_ID = w.VOUCHER_ID  where y.VOUCHER_NUM = a.VOUCHER_NUM) sumAmount,
            c.CURRENCYNAME,b.remark,a.CURRENT_STATE,case a.CURRENT_STATE 
            when 1 then '未提交'
            when 2 then '审核中(' + ck.CURRENT_POSTID + ')'  
            when 3 then
                (case when b.SENDED = 7 then '打回费用项目填写' 
                 when b.SENDED = 8 then '（打回后）机务已修改'  else  '打回到'+ (case when ltrim(isnull(ck.CURRENT_POSTID,'')) = '' then '发起者' else ltrim(ck.CURRENT_POSTID) end )  end)
            when 4 then '审批完成' 
            when 5 then '已同步SAP'
            when 9 then '作废' 
            end as CURRENT_STATE_NAME,b.SENDED,b.SHIP_ID ,a.BUSINESS_CODE,b.APPROVER,b.APPROVER2,
            b.COSTS_ID,ca.NODE_NAME,b.DESCRIPTION,ca.Code,a.INVOICE_NUM,a.APPLY_COMPANY 
            from T_COST_VOUCHER a
            left join T_COST_ACTUAL_COSTS b on a.VOUCHER_ID = b.VOUCHER_ID 
            left join t_cost_account ca on ca.node_id=b.node_id
            left join T_Currency c on b.CURRENCY_ID = c.CURRENCYID 
            left join t_cost_budget cb on cb.budget_id=a.budget_id 
            left join T_CHECKED ck on ck.BUSINESS_OBJECT_ID=a.voucher_num
            inner join T_USER_SHIP d on b.ship_id = d.ship_id and d.userid = '" + userID + "' ";
            switch (yearMonthDay)
            {
                case 1:
                    sql += "\r\nwhere datediff(year,a.VOUCHER_DATE,'" + paymentDate.ToString("yyyy-MM-dd") + "')=0 ";
                    break;
                case 2:
                    sql += "\r\nwhere datediff(month,a.VOUCHER_DATE,'" + paymentDate.ToString("yyyy-MM-dd") + "')=0 ";
                    break;
                default:
                    sql += "\r\nwhere datediff(day,a.VOUCHER_DATE,'" + paymentDate.ToString("yyyy-MM-dd") + "')=0 ";
                    break;
            }
            if (!string.IsNullOrEmpty(CURRENT_STATE))
            {
                if ("7,8".Contains(CURRENT_STATE))
                {
                    sql += " and a.CURRENT_STATE = 3 and b.SENDED =" + CURRENT_STATE;
                }
                else if (CURRENT_STATE == "6")
                {
                    sql += " and ck.CURRENT_POSTID='" + CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME + "'";
                }
                else
                {
                    sql += " and (b.SENDED <> 7 and b.SENDED <> 8) and a.CURRENT_STATE =" + CURRENT_STATE;
                }
                if (CURRENT_STATE == "9") sql += " and a.CURRENT_STATE = 9";
                else sql += " and a.CURRENT_STATE <> 9";
            }
            if (!string.IsNullOrEmpty(SHIP_ID))
            {
                sql += " and b.SHIP_ID ='" + SHIP_ID + "'";
            }
            sql += @"
order by convert(varchar(10),a.VOUCHER_DATE,120) ,case when (select COUNT(1) from [T_SHIP_USER] t1 
inner join t_ship_user_head t2 on t1.SHIPUSERID = t2.SHIPUSERID 
inner join T_BASE_HEADSHIP t3 on t2.SHIP_HEADSHIP_ID = t3.SHIP_HEADSHIP_ID
where t1.USERNAME = b.APPLICANT and t3.HEADSHIP_NAME ='通导主管') = 1 then 1 else 0 end,
b.APPLICANT,a.SHIP_OWNER,a.VOUCHER_NUM";

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
        /// 根据时间段，获得"已完成凭证和实际付款日子"数据.
        /// </summary>
        public DataTable GetPayDateInfo(DateTime startDate, DateTime endDate, bool ifRecord, out string err)
        {
            string sqlWhere = "";
            if (!ifRecord)
            {
                sqlWhere = " and d.voucher_id is null ";
            }


            sql = string.Format(@"select a.VOUCHER_ID,d.ESTIMATE_PAY_DATE,d.PAY_DATE,a.VOUCHER_NUM,a.APPLY_COMPANY,a.SHIP_OWNER,a.PAYEE, a.AMOUNT_LOW,
	                a.AMOUNT_UP,a.INVOICE_NUM,ca.Code,b.DESCRIPTION,c.CURRENCYCODE,c.CURRENCYNAME,
	                CONVERT(decimal(18,2),b.amount) as amount,convert(varchar(10),a.VOUCHER_DATE,120)  VOUCHER_DATE,
                    b.remark,a.CURRENT_STATE,
                    case a.CURRENT_STATE when 1 then '未提交' when 2 then '审核中' when 3 then '被打回'
                    when 4 then '审批完成'  when 5 then '已同步SAP' when 9 then '作废' end as CURRENT_STATE_NAME
                    ,b.SHIP_ID ,a.BUSINESS_CODE,a.APPLICANT,a.APPROVER,a.APPROVER2,b.COSTS_ID,
                    ca.node_name  
                    from T_COST_VOUCHER a
                    left join T_COST_ACTUAL_COSTS b on a.VOUCHER_ID = b.VOUCHER_ID 
                    left join t_cost_account ca on ca.node_id=b.node_id
                    left join T_Currency c on b.CURRENCY_ID = c.CURRENCYID 
                    left join t_cost_budget cb on cb.budget_id=a.budget_id
                    left join T_COST_BILL d on a.voucher_id = d.voucher_id
                    where a.VOUCHER_DATE >= '{0}' and 
                    a.VOUCHER_DATE <= '{1}' and a.budget_id is null 
                    and a.CURRENT_STATE > 4 {2}
                    order by a.VOUCHER_DATE desc"
                    , startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"), sqlWhere);

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
        /// 根据凭证ID，判断是否有凭证明细.
        /// </summary>
        public bool exitActualCosts(string voucherID, out string err)
        {
            string vID = voucherID == null ? "" : voucherID.ToString();
            sql = "select a.VOUCHER_ID  from T_COST_ACTUAL_COSTS a where VOUCHER_ID = '" + vID + "'";
            DataTable dt;
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                return (dt.Rows.Count > 0);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取最新凭证号.
        /// a+ship+yyyyMM+3位流水号.
        /// </summary>
        public bool GetMaxVoucherNum(string shipID, out string voucherNum, out string err)
        {
            err = "";
            ShipInfo theShip = ShipInfoService.Instance.getObject(shipID, out err);
            string shipCode = "0000";
            if (!string.IsNullOrEmpty(theShip.SHIP_CODE) && theShip.SHIP_CODE.Length >= 4)
            {
                shipCode = theShip.SHIP_CODE.Substring(0, 4);
            }
            voucherNum = "";

            string yymm = DateTime.Now.ToString("yyMM");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select");
            sb.AppendLine("SUBSTRING(VOUCHER_NUM,10,3)");
            sb.AppendLine("from T_COST_VOUCHER");
            sb.AppendLine("where 1=1");
            sb.AppendLine("and len(VOUCHER_NUM)=12");
            sb.AppendLine("and SUBSTRING(VOUCHER_NUM,2,4)='" + shipCode + "'");
            sb.AppendLine("and SUBSTRING(VOUCHER_NUM,6,4)='" + yymm + "'");
            sb.AppendLine("order by VOUCHER_NUM desc");
            DataTable dt;
            if (!dbAccess.GetDataTable(sb.ToString(), out dt, out err))
                return false;
            if (dt.Rows.Count > 0)
            {
                string temp = ("000" + (Convert.ToInt32(dt.Rows[0][0]) + 1).ToString());
                voucherNum = "a" + shipCode + yymm + temp.Substring(temp.Length - 3);
            }
            else
                voucherNum = "a" + shipCode + yymm + "001";
            return true;
        }

        /// <summary>
        /// 检查修改的凭证号不应该与带有business_code的相同.
        /// </summary>
        public DataTable CheckNotSameHaveBusinessCodeByVoucherNum(string voucherNum)
        {
            string err = "";
            DataTable dt;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select");
            sb.AppendLine("VOUCHER_NUM");
            sb.AppendLine("from T_COST_VOUCHER");
            sb.AppendLine("where 1=1");
            sb.AppendLine(" and VOUCHER_NUM='" + voucherNum + "'");
            sb.AppendLine(" and business_code is not null");
            sb.AppendLine("   and len( business_code)<>0 ");
            if (!dbAccess.GetDataTable(sb.ToString(), out dt, out err))
                throw new Exception(err);
            return dt;
        }

        /// <summary>
        /// 检查修改的凭证号不应该与带有business_code的相同.
        /// </summary>
        public DataTable CheckNotSameSubmittedByVoucherNum(string voucherNum)
        {
            string err = "";
            DataTable dt;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select");
            sb.AppendLine("VOUCHER_NUM");
            sb.AppendLine(",VOUCHER_DATE");
            sb.AppendLine("from T_COST_VOUCHER");
            sb.AppendLine("where 1=1");
            sb.AppendLine(" and VOUCHER_NUM='" + voucherNum + "'");
            sb.AppendLine(" and CURRENT_STATE <>1 and CURRENT_STATE <>3");
            if (!dbAccess.GetDataTable(sb.ToString(), out dt, out err))
                throw new Exception(err);
            return dt;
        }


        public bool UpdateApproverOfList(List<string> voucherNums, int state, out string err)
        {
            err = "";
            List<string> sqlList = new List<string>();
            foreach (string voucherNum in voucherNums)
            {
                if (state == 1)
                {
                    if ("机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
                    {
                        sqlList.AddRange(ACTUAL_COSTSService.Instance.UpdateApprover(voucherNum, null, CommonOperation.ConstParameter.UserName, null));
                        sqlList.Add(ACTUAL_COSTSService.Instance.UpdateState(voucherNum, 3));
                    }
                    else if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
                    {
                        sqlList.AddRange(ACTUAL_COSTSService.Instance.UpdateApprover(voucherNum, null, null, CommonOperation.ConstParameter.UserName));
                        sqlList.Add(ACTUAL_COSTSService.Instance.UpdateState(voucherNum, 4));
                    }
                    else if ("财务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
                    { 
                        sqlList.Add(ACTUAL_COSTSService.Instance.UpdateState(voucherNum, 45));
                    }
                    sqlList.Add(VOUCHERService.Instance.UpdateState(voucherNum, 2));
                }
                else if (state == 3)
                {
                    sqlList.Add(VOUCHERService.Instance.UpdateState(voucherNum, 4));
                    sqlList.Add(ACTUAL_COSTSService.Instance.UpdateState(voucherNum, 5));
                    DataTable dtShip;
                    VOUCHERService.Instance.GetShipByVoucherNum(voucherNum, out dtShip, out err);
                    foreach (DataRow item in dtShip.Rows)
                    {
                        RemindService.Instance.CreateRemindOnce(7, item["ship_id"].ToString(), voucherNum);
                    }
                }
                else if (state == 2)
                {
                    if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
                    {
                        sqlList.AddRange(ACTUAL_COSTSService.Instance.UpdateApprover(voucherNum, null, null, ""));
                        sqlList.Add(ACTUAL_COSTSService.Instance.UpdateState(voucherNum, 3));
                    }
                    else if ("机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
                    {
                        sqlList.AddRange(ACTUAL_COSTSService.Instance.UpdateApprover(voucherNum, null, "", null));
                        sqlList.Add(ACTUAL_COSTSService.Instance.UpdateState(voucherNum, 2));
                    }
                    else if ("财务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
                    {
                        sqlList.Add(ACTUAL_COSTSService.Instance.UpdateState(voucherNum, 4));
                    }
                    else if ("财务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
                    {
                        sqlList.Add(ACTUAL_COSTSService.Instance.UpdateState(voucherNum, 45));
                    }
                    sqlList.Add(VOUCHERService.Instance.UpdateState(voucherNum, 3));

                    DataTable dtShip;
                    VOUCHERService.Instance.GetShipByVoucherNum(voucherNum, out dtShip, out err);
                    foreach (DataRow item in dtShip.Rows)
                    {
                        RemindService.Instance.CreateRemindOnce(8, item["ship_id"].ToString(), voucherNum);
                    }
                }
            }
            if (sqlList.Count != 0)
                return InterfaceInstantiation.NewASingleAccess().ExecSql(sqlList, out err);
            else
                return true;
        }
        /// <summary>
        /// 执行执行.
        /// </summary>
        public bool ExecSql(List<string> sqlList, out string err)
        {
            return dbAccess.ExecSql(sqlList, out err);
        }

        /// <summary>
        /// 根据日期，获得 "单日凭证" 数据.
        /// </summary>
        public bool GetByBudgetID(string BUDGET_ID, out DataTable dt, out string err)
        {
            sql = string.Format(@"select a.VOUCHER_ID,a.VOUCHER_NUM,a.APPLY_COMPANY,a.SHIP_OWNER,a.PAYEE, a.AMOUNT_LOW,a.AMOUNT_UP,a.INVOICE_NUM
            ,b.DESCRIPTION,c.CURRENCYCODE,c.CURRENCYNAME,CONVERT(decimal(18,2),b.amount) as amount,convert(varchar(10),a.VOUCHER_DATE,120)  VOUCHER_DATE,b.remark
            ,b.SHIP_ID ,a.BUSINESS_CODE,b.COSTS_ID,b.CUSTOMER,b.CONTRACT_NUM,b.DESCRIPTION,b.APPLICANT,b.APPROVER,b.APPROVER2,
            convert(varchar(10),b.PAYMENT_DATE,120) as PAYMENT_DATE,case a.CURRENT_STATE when 1 then '未提交' when 2 then '审核中' when 3 then '被打回'
            when 4 then '审批完成'  when 5 then '已同步SAP' when 9 then '作废' end as CURRENT_STATE_NAME
             from T_COST_VOUCHER a,T_COST_ACTUAL_COSTS b,T_Currency c 
             where  a.VOUCHER_ID = b.VOUCHER_ID and  b.CURRENCY_ID = c.CURRENCYID 
             and a.BUDGET_ID='{0}' 
             order by a.VOUCHER_NUM", BUDGET_ID);

            return dbAccess.GetDataTable(sql, out dt, out err);
        }

        /// <summary>
        /// 获得预算船舶
        /// </summary>
        public bool GetShipByVoucherNum(string VOUCHER_NUM, out DataTable dt, out string err)
        {
            sql = string.Format(@"select b.SHIP_ID
             from T_COST_VOUCHER a,T_COST_ACTUAL_COSTS b,T_USER_SHIP us
             where  a.VOUCHER_ID = b.VOUCHER_ID and a.VOUCHER_NUM='{0}' 
            and  us.ship_id=b.ship_id  and us.userid = '{1}'
             group by b.ship_id", VOUCHER_NUM, CommonOperation.ConstParameter.UserId);

            return dbAccess.GetDataTable(sql, out dt, out err);
        }

        public bool GetCostToSAP(string VOUCHER_NUM, out DataTable dtb, out string err)
        {
            //变量定义部分.
            string sSql = "";                   //查询数据所需的SQL语句.
            //Select语句加工部分.
            sSql += "select ";
            sSql += "(select top 1 MANUFACTURER_ID from T_MANUFACTURER where MANUFACTURER_NAME=a.CUSTOMER) as SUPPLIER,";
            sSql += "c.CURRENCYCODE as CURRENCY,";
            sSql += "a.AMOUNT as AMOUNT,";
            sSql += "b.NODE_ID as SUBJECT,";
            sSql += "b.CODE as SUBJECT_MAPPING, ";
            sSql += "  case when (select count(*) from t_cost_account_position where class=4 and node_id=b.node_id)>0 ";
            sSql += " then 'A'";
            sSql += " else 'D' end  as COST_TYPE,";
            sSql += "a.ship_id as ship_id,";
            sSql += "a.COSTS_ID as UUID,";
            sSql += " substring(a.REMARK,1,25) as remark ";
            sSql += " from T_COST_VOUCHER cv,T_COST_ACTUAL_COSTS a, T_COST_ACCOUNT b,T_Currency c ";
            sSql += " where a.amount is not null and a.amount<>0 and cv.VOUCHER_ID=a.VOUCHER_ID ";
            sSql += " and a.NODE_ID = b.NODE_ID and a.CURRENCY_ID = c.CURRENCYID  and cv.VOUCHER_NUM = '" + VOUCHER_NUM + "'";
            return dbAccess.GetDataTable(sSql, out dtb, out err);
        }

        public bool GetCostMaterialToSAP(string BUSINESS_CODE, out DataTable dtb, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select * from (select");
            sb.AppendLine("m.MANUFACTURER_ID as SUPPLIER, ");
            sb.AppendLine("c.CURRENCYCODE as CURRENCY, ");
            sb.AppendLine("(isnull(sum(a.AMOUNT),0) -(select isnull(SUM(AMOUNT),0) from T_PURCHASE_MESSAGE where ACCOUNT_CODE=b.CODE and BUSINESS_CODE='" + BUSINESS_CODE + "')) as AMOUNT, ");
            sb.AppendLine("b.CODE as SUBJECT_MAPPING, ");
            sb.AppendLine("a.ship_id as ship_id, ");
            sb.AppendLine("max(a.COSTS_ID) as UUID, ");
            sb.AppendLine("1 as quantity, ");
            sb.AppendLine("'' as MATERIAL, ");
            sb.AppendLine("cv.VOUCHER_NUM as INPUT_ORDER ");
            sb.AppendLine("from T_COST_VOUCHER cv,T_COST_ACTUAL_COSTS a, T_COST_ACCOUNT b,T_Currency c ,T_MANUFACTURER m ");
            sb.AppendLine("where MANUFACTURER_NAME=a.CUSTOMER and cv.VOUCHER_ID=a.VOUCHER_ID and a.NODE_ID = b.NODE_ID and a.CURRENCY_ID = c.CURRENCYID ");
            sb.AppendLine("and cv.BUSINESS_CODE = '" + BUSINESS_CODE + "' ");
            sb.AppendLine("group by m.MANUFACTURER_ID,c.CURRENCYCODE,b.CODE,a.ship_id,cv.VOUCHER_NUM) a");
            sb.AppendLine("where a.amount<>0");

            sb.AppendLine("union all ");

            sb.AppendLine("select ");
            sb.AppendLine("SUPPLIER ");
            sb.AppendLine(",CURRENCY ");
            sb.AppendLine(",AMOUNT ");
            sb.AppendLine(",SUBJECT_MAPPING ");
            sb.AppendLine(",SHIP_ID ");
            sb.AppendLine(",UUID ");
            sb.AppendLine(",QUANTITY ");
            sb.AppendLine(",MATERIAL ");
            sb.AppendLine(",INPUT_ORDER ");
            sb.AppendLine("from T_PURCHASE_MESSAGE where BUSINESS_CODE='" + BUSINESS_CODE + "' ");
            return dbAccess.GetDataTable(sb.ToString(), out dtb, out err);
        }

        /// <summary>
        /// 更改凭证状态.
        /// </summary>
        /// <param name="VOUCHER_NUM">当条件用的</param>
        /// <param name="STATE">要更新成的状态</param>
        /// <returns></returns>
        public string UpdateState(string VOUCHER_NUM, int CURRENT_STATE)
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine("update T_COST_VOUCHER set CURRENT_STATE=" + CURRENT_STATE + ",voucher_date = getdate()");
            //2014-1-9 徐正本 修改凭证改时间的脚本，让时间不变
            sb.AppendLine("update T_COST_VOUCHER set CURRENT_STATE=" + CURRENT_STATE);
            sb.AppendLine("where 1=1");
            sb.AppendLine("and VOUCHER_NUM='" + VOUCHER_NUM + "'");
            return sb.ToString();
        }

        public string UpdateBudgetID(string VOUCHER_NUM, string BUDGET_ID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("update T_COST_VOUCHER set ");
            if (string.IsNullOrEmpty(BUDGET_ID))
                sb.AppendLine(" BUDGET_ID=null");
            else
                sb.AppendLine(" BUDGET_ID='" + BUDGET_ID + "'");

            sb.AppendLine("where 1=1");
            sb.AppendLine("and VOUCHER_NUM='" + VOUCHER_NUM + "'");
            return sb.ToString();
        }

        public List<string> UpdateDate(string VOUCHER_NUM, DateTime date)
        {
            List<string> sqlList = new List<string>();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("update T_COST_VOUCHER set voucher_date='" + date.ToString() + "'");
            sb.AppendLine("where VOUCHER_NUM='" + VOUCHER_NUM.Trim() + "'");
            sqlList.Add(sb.ToString());
            StringBuilder sb1 = new StringBuilder();
            sb1.AppendLine("update T_COST_ACTUAL_COSTS set PAYMENT_DATE='" + date.ToString() + "'");
            sb1.AppendLine("where VOUCHER_ID in (select VOUCHER_ID from T_COST_VOUCHER where VOUCHER_NUM='" + VOUCHER_NUM.Trim() + "')");
            sqlList.Add(sb1.ToString());
            return sqlList;
        }

        public bool DeleteVoucherActualCost(string VOUCHER_NUM, out string err)
        {
            List<string> sqlList = new List<string>();

            StringBuilder sb1 = new StringBuilder();
            sb1.AppendLine("update T_COST_ACTUAL_COSTS set SENDED = 1,VOUCHER_ID = null ");
            sb1.AppendLine("where VOUCHER_ID in (select VOUCHER_ID from T_COST_VOUCHER where VOUCHER_NUM='" + VOUCHER_NUM.Trim() + "')");
            sqlList.Add(sb1.ToString());

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("delete from T_COST_VOUCHER ");
            sb.AppendLine("where VOUCHER_NUM='" + VOUCHER_NUM.Trim() + "'");
            sqlList.Add(sb.ToString());

            return dbAccess.ExecSql(sqlList, out err);

        }

        /// <summary>
        /// 增加或修改凭证的预计付款日期
        /// </summary>
        /// <param name="payDate"></param>
        /// <param name="IDsAdd"></param>
        /// <param name="IDsUpdate"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool AddCostBillPrePayDate(DateTime payDate, List<string> IDsAdd, List<string> IDsUpdate, out string err)
        {
            string idsAddSql = "";
            string idsUpdateSql = "";
            foreach (string id in IDsAdd)
            {
                idsAddSql += "'" + id + "',";
            }
            idsAddSql = idsAddSql.Length > 0 ? idsAddSql.Substring(0, idsAddSql.Length - 1) : "";

            foreach (string id in IDsUpdate)
            {
                idsUpdateSql += "'" + id + "',";
            }
            idsUpdateSql = idsUpdateSql.Length > 0 ? idsUpdateSql.Substring(0, idsUpdateSql.Length - 1) : "";

            string sqlInsert = string.Format(@"insert T_COST_BILL(ID,VOUCHER_ID,ESTIMATE_PAY_DATE)  select newid(),VOUCHER_ID,'{0}' 
                    from dbo.T_COST_VOUCHER where VOUCHER_ID in ({1})",
                    payDate.ToString("yyyy年MM月dd日"), idsAddSql);

            string sqlUpdate = "update T_COST_BILL set ESTIMATE_PAY_DATE ='" + payDate.ToString("yyyy年MM月dd日") + "' where VOUCHER_ID  in (" + idsUpdateSql + ")";

            List<string> sqlStrings = new List<string>();
            if (IDsAdd.Count > 0) sqlStrings.Add(sqlInsert);
            if (IDsUpdate.Count > 0) sqlStrings.Add(sqlUpdate);

            return dbAccess.ExecSql(sqlStrings, out err);
        }

        /// <summary>
        /// 增加或修改凭证的实际付款日期
        /// </summary>
        /// <param name="payDate"></param>
        /// <param name="IDsAdd"></param>
        /// <param name="IDsUpdate"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool AddCostBillPayDate(DateTime payDate, List<string> IDsAdd, List<string> IDsUpdate, out string err)
        {
            string idsAddSql = "";
            string idsUpdateSql = "";
            foreach (string id in IDsAdd)
            {
                idsAddSql += "'" + id + "',";
            }
            idsAddSql = idsAddSql.Length > 0 ? idsAddSql.Substring(0, idsAddSql.Length - 1) : "";

            foreach (string id in IDsUpdate)
            {
                idsUpdateSql += "'" + id + "',";
            }
            idsUpdateSql = idsUpdateSql.Length > 0 ? idsUpdateSql.Substring(0, idsUpdateSql.Length - 1) : "";

            string sqlInsert = string.Format(@"insert T_COST_BILL(ID,VOUCHER_ID,PAY_DATE)  select newid(),VOUCHER_ID,'{0}' 
                    from dbo.T_COST_VOUCHER where VOUCHER_ID in ({1})",
                    payDate.ToString("yyyy年MM月dd日"), idsAddSql);

            string sqlUpdate = "update T_COST_BILL set PAY_DATE ='" + payDate.ToString("yyyy年MM月dd日") + "' where VOUCHER_ID  in (" + idsUpdateSql + ")";

            List<string> sqlStrings = new List<string>();
            if (IDsAdd.Count > 0) sqlStrings.Add(sqlInsert);
            if (IDsUpdate.Count > 0) sqlStrings.Add(sqlUpdate);

            return dbAccess.ExecSql(sqlStrings, out err);
        }


    }
}
