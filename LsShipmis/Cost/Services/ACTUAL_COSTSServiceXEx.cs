/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：T_COST_ACTUAL_COSTSService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-6-28
 * 标    题：数据操作类
 * 功能描述：T_COST_ACTUAL_COSTS数据操作类
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
using System.Drawing;
using BaseInfo.Objects;
using CommonOperation;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using Cost.DataObject;
using OfficeOperation;
using System.Globalization;
using ShipMisZHJ_WorkFlow.BusinessClasses;

namespace Cost.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_COST_ACTUAL_COSTSService.cs
    /// </summary>
    public partial class ACTUAL_COSTSService
    {
        /// <summary>
        /// 获得 "年度实际发生费用" 数据.
        /// </summary>
        public DataTable getInfoByYear(string ship_id, DateTime year, out string err)
        {

            sql = "select a.COSTS_ID,convert(varchar(10),a.OCCURENCY_DATE,120) as OCCURENCY_DATE"
            + ",convert(varchar(10),a.PAYMENT_DATE,120) as PAYMENT_DATE"
            + ",a.CUSTOMER,a.DESCRIPTION,c.CURRENCYNAME,a.AMOUNT as AMOUNT,a.CONVERT_MONEY as CONVERT_MONEY,b.NODE_NAME"
            + ",convert(varchar(10),a.COMPLETE_DATE,120) as COMPLETE_DATE,a.COMPLETE_PALCE,a.SHIP_ID"
            + "\rfrom T_COST_ACTUAL_COSTS a, T_COST_ACCOUNT b,T_Currency c  ";

            sql += "\rwhere  a.NODE_ID = b.NODE_ID and a.CURRENCY_ID = c.CURRENCYID and upper(a.SHIP_ID)='" + ship_id.ToUpper() + "' and convert(varchar(4),a.PAYMENT_DATE,120)='" + year.ToString("yyyy") + "'";
            sql += "\rorder by a.OCCURENCY_DATE";

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
        /// 根据凭证ID，去除费用的凭证关联.
        /// </summary>
        public bool noVoucherByVoucherID(string voucherID, out string err)
        {
            sql = "update T_COST_ACTUAL_COSTS set VOUCHER_ID = null where  upper(VOUCHER_ID)='" + voucherID.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }

        /// <summary>
        /// 获得 "预算月日" 数据.
        /// </summary>
        public DataTable getMonthDayByYear(DateTime year, out string err)
        {
            sql = "select PAYMENT_DATE as ID,PAYMENT_DATE from (select convert(varchar(5),PAYMENT_DATE,110) as PAYMENT_DATE"
            + " from T_COST_ACTUAL_COSTS a  ";
            sql += " where  convert(varchar(4),a.PAYMENT_DATE,120)='" + year.ToString("yyyy") + "') a group by PAYMENT_DATE";
            sql += " order by PAYMENT_DATE";

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
        /// 根据付款日期，获得 "实际发生费用" 数据.
        /// </summary>
        public DataTable getInfoByBUDGET_ID(string BUDGET_ID, bool rmbFlag, out string err)
        {
            sql = "select a.COSTS_ID,a.CUSTOMER,c.CURRENCYNAME,a.AMOUNT as AMOUNT,a.CONTRACT_NUM,(b.SHIP_NAME + a.DESCRIPTION) as DESCRIPTION"
            + ",a.APPLICANT,a.APPROVER,a.APPROVER2,convert(varchar(10),a.PAYMENT_DATE,120) as PAYMENT_DATE,a.REMARK"
            + " from T_COST_ACTUAL_COSTS a INNER JOIN T_Currency c ON a.CURRENCY_ID = c.CURRENCYID INNER JOIN T_SHIP b ON a.SHIP_ID = b.SHIP_ID INNER JOIN  T_COST_VOUCHER D ON a.VOUCHER_ID = D.VOUCHER_ID LEFT JOIN T_COST_BUDGET E ON D.BUDGET_ID = E.BUDGET_ID";

            sql += " WHERE D.BUDGET_ID =  '" + BUDGET_ID + "'";
            //sql += " and convert(varchar(10),a.PAYMENT_DATE,120)='" + paymentDate.ToString("yyyy-MM-dd") + "'";

            if (rmbFlag)
            {
                sql += " and upper(c.CURRENCYCODE) ='CNY'";
            }
            else
            {
                sql += " and upper(c.CURRENCYCODE) <>'CNY'";
            }
            sql += " order by c.CURRENCYCODE, a.CUSTOMER";

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
        /// 根据日期、币种统计"实际发生费用"
        /// </summary>
        public decimal getSumByCurrency(string BUDGET_ID, string currencyCode, out string err)
        {
            sql = @"select sum(a.AMOUNT) as AMOUNT 
                from T_COST_ACTUAL_COSTS a
                left join T_Currency c on a.CURRENCY_ID = c.CURRENCYID 
                inner join T_COST_VOUCHER cv on cv.VOUCHER_ID=a.VOUCHER_ID
                right join T_COST_BUDGET cb on cb.BUDGET_ID=cv.BUDGET_ID";
            sql += " where cb.BUDGET_ID='" + BUDGET_ID + "'";
            sql += " and upper(c.CURRENCYCODE) ='" + currencyCode + "'";

            DataTable dt;
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                string amount = dt.Rows[0][0].ToString();
                if ("".Equals(amount)) return 0M;

                decimal temp = decimal.Parse(amount);
                temp = decimal.Round(temp, 2);
                return temp;
            }
            else
            {
                throw new Exception(err);
            }

        }

        /// <summary>
        /// #用于导出为Excel。根据日期、币种统计"周预算费用"
        /// </summary>
        public bool GetOperationExcelOfWeekBudget(string BUGDET_ID, Dictionary<string, string> mainInfo, out  List<OperationExcel> operationExcel, out string err)
        {
            err = "";
            operationExcel = new List<OperationExcel>();
            OperationExcel operationExcel1 = new OperationExcel(1, "人民币");
            OperationExcel operationExcel2 = new OperationExcel(2, "其他币种");
            operationExcel.Add(operationExcel1);
            operationExcel.Add(operationExcel2);
            operationExcel1.DefaultFont = new Font("宋体", (float)9);
            operationExcel2.DefaultFont = new Font("宋体", (float)9);
            return GetRMBOrOther(BUGDET_ID, true, mainInfo, operationExcel1, out err) && GetRMBOrOther(BUGDET_ID, false, mainInfo, operationExcel2, out err);
        }

        private bool GetRMBOrOther(string BUGDET_ID, bool isRMB, Dictionary<string, string> mainInfo, OperationExcel operationExcel, out string err)
        {
            err = "";
            //表格首信息.

            if (!operationExcel.AddTitle("海丰集运及航运集团资金周预算", 1, out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("公司名称:" + mainInfo["1"], false, 2, 1, 1, 4, true, false, XlHorizontalAlignment.xlLeft, new Font("宋体", (float)11)), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("付款日:" + mainInfo["2"], false, 2, 5, 1, 2, true, false, XlHorizontalAlignment.xlLeft, new Font("宋体", (float)11)), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("审批号:" + mainInfo["3"], false, 2, 7, 1, 2, true, false, XlHorizontalAlignment.xlLeft, new Font("宋体", (float)11)), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("备注:" + mainInfo["4"], false, 2, 9, 1, 3, true, false, XlHorizontalAlignment.xlLeft, new Font("宋体", (float)11)), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("序号", false, 3, 1, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("项目", false, 3, 2, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("币别", false, 3, 3, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("上周末余额", false, 3, 4, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("其中:已预算未付金额", false, 3, 5, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)10)), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("下周预算金额", false, 3, 6, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("", false, 3, 7, 1, 5, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                )
            {
                return false;
            }

            //调整货币行数，人民币是0，其它是2
            int rmbRowNum = 0;
            if (!isRMB) rmbRowNum = 2;

            //表格主信息.

            if (isRMB)
            {
                if (!operationExcel.InsertABodyUnit(new OneUnit("", false, 4, 1, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit("合计", false, 4, 2, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit("CNY", false, 4, 3, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit(mainInfo["c1"], false, 4, 4, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit(mainInfo["c2"], false, 4, 5, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit(mainInfo["c3"], false, 4, 6, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit("", false, 4, 7, 1, 5, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                    )
                {
                    return false;
                }
            }
            else
            {
                if (!operationExcel.InsertABodyUnit(new OneUnit("", false, 4, 1, 3, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit("合计", false, 4, 2, 3, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit("USD", false, 4, 3, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit(mainInfo["u1"], false, 4, 4, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit(mainInfo["u2"], false, 4, 5, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit(mainInfo["u3"], false, 4, 6, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit("", false, 4, 7, 1, 5, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit("EUR", false, 5, 3, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit(mainInfo["e1"], false, 5, 4, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit(mainInfo["e2"], false, 5, 5, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit(mainInfo["e3"], false, 5, 6, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit("", false, 5, 7, 1, 5, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit("JPY", false, 6, 3, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit(mainInfo["j1"], false, 6, 4, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit(mainInfo["j2"], false, 6, 5, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit(mainInfo["j3"], false, 6, 6, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit("", false, 6, 7, 1, 5, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                    )
                {
                    return false;
                }

            }

            //插一行标题.

            if (!operationExcel.InsertABodyUnit(new OneUnit("下周资金预算明细", false, 5 + rmbRowNum, 1, 1, 11, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err))
            {
                return false;
            }

            //表格列标题头信息.
            if (!operationExcel.InsertABodyUnit(new OneUnit("", false, 6 + rmbRowNum, 1, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("客户名称", false, 6 + rmbRowNum, 2, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("币别", false, 6 + rmbRowNum, 3, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("金额", false, 6 + rmbRowNum, 4, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("合同评审号", false, 6 + rmbRowNum, 5, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("付款说明", false, 6 + rmbRowNum, 6, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("申请人", false, 6 + rmbRowNum, 7, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("审核人", false, 6 + rmbRowNum, 8, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("批准人", false, 6 + rmbRowNum, 9, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("付款日", false, 6 + rmbRowNum, 10, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("备注", false, 6 + rmbRowNum, 11, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)11)), out err)
                )
            {
                return false;
            }

            DataTable dt = getInfoByBUDGET_ID(BUGDET_ID, isRMB, out err);//获取实际费用.
            if (dt == null)
            {
                err = "无法获取实际发生费用信息!";
                return false;
            }

            int i = 0;
            int ordernum = 1;
            decimal amount = 0M;
            string currency = "";//币种名称.
            for (; i < dt.Rows.Count; i++)
            {
                //币种改变时，加合计.

                if (!currency.Equals(dt.Rows[i]["CURRENCYNAME"].ToString()) && i > 0)
                {

                    //合计信息.
                    if (!operationExcel.InsertABodyUnit(new OneUnit((ordernum++).ToString(), false, 7 + i + rmbRowNum, 1, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(currency + "合计", false, 7 + i + rmbRowNum, 2, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)9, FontStyle.Bold)), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("", false, 7 + i + rmbRowNum, 3, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(amount.ToString(), false, 7 + i + rmbRowNum, 4, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("", false, 7 + i + rmbRowNum, 5, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("", false, 7 + i + rmbRowNum, 6, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("", false, 7 + i + rmbRowNum, 7, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("", false, 7 + i + rmbRowNum, 8, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("", false, 7 + i + rmbRowNum, 9, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("", false, 7 + i + rmbRowNum, 10, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("", false, 7 + i + rmbRowNum, 11, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        )
                    {
                        return false;
                    }

                    amount = 0M;                    //合计清零.
                    ordernum = 1;
                    rmbRowNum += 1;
                    currency = dt.Rows[i]["CURRENCYNAME"].ToString();//改变币种.
                }
                else
                {
                    currency = dt.Rows[i]["CURRENCYNAME"].ToString();
                }

                if (!operationExcel.InsertABodyUnit(new OneUnit((ordernum++).ToString(), false, 7 + i + rmbRowNum, 1, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["CUSTOMER"].ToString(), false, 7 + i + rmbRowNum, 2, 1, 1, true, false, XlHorizontalAlignment.xlLeft), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["CURRENCYNAME"].ToString(), false, 7 + i + rmbRowNum, 3, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["AMOUNT"].ToString(), false, 7 + i + rmbRowNum, 4, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["CONTRACT_NUM"].ToString(), false, 7 + i + rmbRowNum, 5, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["DESCRIPTION"].ToString(), false, 7 + i + rmbRowNum, 6, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["APPLICANT"].ToString(), false, 7 + i + rmbRowNum, 7, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["APPROVER"].ToString(), false, 7 + i + rmbRowNum, 8, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["APPROVER2"].ToString(), false, 7 + i + rmbRowNum, 9, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["PAYMENT_DATE"].ToString(), false, 7 + i + rmbRowNum, 10, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["REMARK"].ToString(), false, 7 + i + rmbRowNum, 11, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                    )
                {
                    return false;
                }

                amount += decimal.Parse(dt.Rows[i]["AMOUNT"].ToString());
            }

            //合计信息.
            if (!operationExcel.InsertABodyUnit(new OneUnit((ordernum++).ToString(), false, 7 + i + rmbRowNum, 1, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit(currency + "合计", false, 7 + i + rmbRowNum, 2, 1, 1, true, false, XlHorizontalAlignment.xlCenter, new Font("宋体", (float)9, FontStyle.Bold)), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("", false, 7 + i + rmbRowNum, 3, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit(amount.ToString(), false, 7 + i + rmbRowNum, 4, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("", false, 7 + i + rmbRowNum, 5, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("", false, 7 + i + rmbRowNum, 6, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("", false, 7 + i + rmbRowNum, 7, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("", false, 7 + i + rmbRowNum, 8, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("", false, 7 + i + rmbRowNum, 9, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("", false, 7 + i + rmbRowNum, 10, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("", false, 7 + i + rmbRowNum, 11, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                )
            {
                return false;
            }

            //表格尾信息.

            if (!operationExcel.InsertABodyUnit(new OneUnit("批准人:", false, 8 + rmbRowNum + i, 1, 1, 3, false, false, XlHorizontalAlignment.xlLeft, new Font("宋体", (float)11)), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("核准人:", false, 8 + rmbRowNum + i, 4, 1, 2, false, false, XlHorizontalAlignment.xlLeft, new Font("宋体", (float)11)), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("申请人:", false, 8 + rmbRowNum + i, 6, 1, 3, false, false, XlHorizontalAlignment.xlLeft, new Font("宋体", (float)11)), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("财务签收:", false, 8 + rmbRowNum + i, 9, 1, 3, false, false, XlHorizontalAlignment.xlLeft, new Font("宋体", (float)11)), out err)
                )
            {
                return false;
            }

            //列宽设置.
            operationExcel.SetHorizontal(true);
            operationExcel.AddAllColumnSize(1, 40);
            operationExcel.AddAllColumnSize(2, 200);
            operationExcel.AddAllColumnSize(3, 70);
            operationExcel.AddAllColumnSize(4, 110);
            operationExcel.AddAllColumnSize(5, 120);
            operationExcel.AddAllColumnSize(6, 200);
            operationExcel.AddAllColumnSize(7, 70);
            operationExcel.AddAllColumnSize(8, 70);
            operationExcel.AddAllColumnSize(9, 70);
            operationExcel.AddAllColumnSize(10, 100);
            operationExcel.AddAllColumnSize(11, 100);
            operationExcel.AddAllLineSize(1, 40);
            operationExcel.AddAllLineSize(5 + rmbRowNum, 30);
            return true;
        }

        #region 根据发生日期和船舶，获得"单船费用核算"数据
        /// <summary>
        /// 根据付款日期和船舶，获得"单船费用核算"数据.
        /// </summary>
        public DataTable getShipCaculate(DateTime paymentYear, string ship_ID, out string err)
        {
//            sql = string.Format(@"select a.COSTS_ID,convert(varchar(10),a.PAYMENT_DATE,120) as PAYMENT_DATE,a.CUSTOMER,a.DESCRIPTION,
//                                    a.AMOUNT,b.CURRENCYNAME, a.CONVERT_MONEY ,a.SENDED,c.CURRENT_STATE
//                                    from T_COST_ACTUAL_COSTS a left join T_Currency b on a.CURRENCY_ID = b.CURRENCYID 
//                                    left join T_COST_VOUCHER c on a.VOUCHER_ID = c.VOUCHER_ID
//                                    where    convert(varchar(4),a.PAYMENT_DATE,120)='{0}' 
//                                    and a.SHIP_ID ='{1}' and a.SENDED <> 7 and a.SENDED <> 9 and ((c.current_state <> 3 and c.current_state <> 9) or c.current_state Is Null)
//                                    order by a.PAYMENT_DATE, a.CUSTOMER",
//                                    paymentYear.ToString("yyyy"), ship_ID);

            //liulei-2016/01/08-客户需求变更,修改为按发生日期统计
            sql = string.Format(@"select a.COSTS_ID
,convert(varchar(10),a.OCCURENCY_DATE,120) as OCCURENCY_DATE
,convert(varchar(10),a.PAYMENT_DATE,120) as PAYMENT_DATE
,a.CUSTOMER,a.DESCRIPTION
,a.AMOUNT
,b.CURRENCYNAME
, a.CONVERT_MONEY 
,a.SENDED
,c.CURRENT_STATE
from T_COST_ACTUAL_COSTS a left join T_Currency b on a.CURRENCY_ID = b.CURRENCYID 
left join T_COST_VOUCHER c on a.VOUCHER_ID = c.VOUCHER_ID
where    convert(varchar(4),a.OCCURENCY_DATE,120)='{0}' 
and a.SHIP_ID ='{1}' 
and a.SENDED <> 7 
and a.SENDED <> 9 
and ((c.current_state <> 3 and c.current_state <> 9) or c.current_state Is Null)
order by a.OCCURENCY_DATE, a.CUSTOMER",
            paymentYear.ToString("yyyy"), ship_ID);
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
        #endregion

        /// <summary>
        ///  #用于导出为Excel。形成单船费用核算 。.
        /// </summary>
        public bool GetOperationExcelOfShipCaculate(DateTime paymentYear, string ship_ID, string title, out  OperationExcel operationExcel, out string err)
        {
            operationExcel = new OperationExcel();
            operationExcel.DefaultFont = new Font("宋体", (float)9);
            err = "";

            //表格首信息.

            if (!operationExcel.AddTitle(title, 1, out err))
            {
                return false;
            }

            Font rowTitle = new Font("宋体", (float)11, FontStyle.Bold);

            //表格列标题头信息.
            if (!operationExcel.InsertABodyUnit(new OneUnit("序号", false, 2, 1, 1, 1, true, false, XlHorizontalAlignment.xlCenter, rowTitle), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("日期", false, 2, 2, 1, 1, true, false, XlHorizontalAlignment.xlCenter, rowTitle), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("付费对象", false, 2, 3, 1, 1, true, false, XlHorizontalAlignment.xlCenter, rowTitle), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("付费说明", false, 2, 4, 1, 1, true, false, XlHorizontalAlignment.xlCenter, rowTitle), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("币种", false, 2, 5, 1, 1, true, false, XlHorizontalAlignment.xlCenter, rowTitle), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("金额", false, 2, 6, 1, 1, true, false, XlHorizontalAlignment.xlCenter, rowTitle), out err)
                || !operationExcel.InsertABodyUnit(new OneUnit("折算美金(USD)", false, 2, 7, 1, 1, true, false, XlHorizontalAlignment.xlCenter, rowTitle), out err)
                )
            {
                return false;
            }

            DataTable dt = getShipCaculate(paymentYear, ship_ID, out err);//获取列表数据.
            if (dt == null)
            {
                err = "无法获取实际发生费用信息!";
                return false;
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //liulei-2016/01/08-日期取发生日期
                if (!operationExcel.InsertABodyUnit(new OneUnit((1 + i).ToString(), false, 3 + i, 1, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["OCCURENCY_DATE"].ToString(), false, 3 + i, 2, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["CUSTOMER"].ToString(), false, 3 + i, 3, 1, 1, true, false, XlHorizontalAlignment.xlLeft), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["DESCRIPTION"].ToString(), false, 3 + i, 4, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["CURRENCYNAME"].ToString(), false, 3 + i, 5, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["AMOUNT"].ToString(), false, 3 + i, 6, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["CONVERT_MONEY"].ToString(), false, 3 + i, 7, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)

                    )
                {
                    return false;
                }
            }

            //列宽设置.
            operationExcel.SetHorizontal(false);
            operationExcel.AddAllColumnSize(1, 70);
            operationExcel.AddAllColumnSize(2, 100);
            operationExcel.AddAllColumnSize(3, 200);
            operationExcel.AddAllColumnSize(4, 200);
            operationExcel.AddAllColumnSize(5, 70);
            operationExcel.AddAllColumnSize(6, 100);
            operationExcel.AddAllColumnSize(7, 100);
            operationExcel.AddAllLineSize(1, 40);

            return true;
        }

        #region  根据费用发生日期，获得"费用统计清单"数据-liulei/2016/01/08
        /// <summary>
        /// 根据付款日期和船舶，获得"费用统计清单"数据.
        /// </summary>
        public DataTable getShipBill(DateTime year, string ship_ID, out string err)
        {
            //获取年度各个科目的年度预算额.
            Dictionary<string, string> dictBudget = new Dictionary<string, string>();
            DataTable dtBudget = ANNUAL_BUDGETService.Instance.getInfoByYear(ship_ID, year, out err);
            foreach (DataRow row in dtBudget.Rows)
            {
                dictBudget.Add(row["NODE_NAME"].ToString(), row["AMOUNT"].ToString());
            }

            //获取年度各个科目的年度汇总.

            Dictionary<string, string> dictSum = new Dictionary<string, string>();
            DataTable dtSum = getSumByShip(year, ship_ID, out err);
            foreach (DataRow row in dtSum.Rows)
            {
                dictSum.Add(row["NODE_NAME"].ToString(), row["CONVERT_MONEY"].ToString());
            }
            //,convert(varchar(10),a.OCCURENCY_DATE,120) as OCCURENCY_DATE  2014-10-29  wanhw--添加发生日期
//            sql = string.Format(@"select a.COSTS_ID,d2.NODE_NAME,convert(varchar(10),a.OCCURENCY_DATE,120) as OCCURENCY_DATE,convert(varchar(10),a.COMPLETE_DATE,120) as COMPLETE_DATE,
//                                    a.COMPLETE_PALCE,a.REMARK,a.CUSTOMER,convert(varchar(10),a.INVOICE_DATE,120) as INVOICE_DATE,convert(varchar(10),a.PAYMENT_DATE,120) as PAYMENT_DATE,
//                                    a.INVOICE_NUM,c.CURRENCYNAME, a.AMOUNT as AMOUNT,a.CONVERT_MONEY as CONVERT_MONEY,'' as bamount
//                                    from T_COST_ACTUAL_COSTS a left join T_Currency c on a.CURRENCY_ID = c.CURRENCYID
//                                    left join T_COST_VOUCHER b on a.VOUCHER_ID = b.VOUCHER_ID
//                                    left join (select a.NODE_ID,b.path as node_name ,b.ORDER_Char from T_COST_ACCOUNT a, f_getC('') b where a.NODE_ID = b.id) 
//                                    d2 on a.NODE_ID = d2.NODE_ID    
//                                    where   convert(varchar(4),a.PAYMENT_DATE,120)='{0}' 
//                                    and a.SHIP_ID ='{1}' and a.SENDED <> 7 and a.SENDED <> 9 and ((b.current_state <> 3 and b.current_state <> 9) or b.current_state Is Null)
//                                    order by d2.ORDER_Char, d2.NODE_NAME,a.OCCURENCY_DATE,a.COMPLETE_DATE", 
//                                      year.ToString("yyyy"), ship_ID);

            //修改为按费用发生日期查询-liulei/2016/01/08
            sql = string.Format(@"select a.COSTS_ID
,d2.NODE_NAME
,convert(varchar(10),a.OCCURENCY_DATE,120) as OCCURENCY_DATE
,convert(varchar(10),a.COMPLETE_DATE,120) as COMPLETE_DATE
,a.COMPLETE_PALCE
,a.REMARK
,a.CUSTOMER
,convert(varchar(10),a.INVOICE_DATE,120) as INVOICE_DATE
,convert(varchar(10),a.PAYMENT_DATE,120) as PAYMENT_DATE
, a.INVOICE_NUM
,c.CURRENCYNAME
, a.AMOUNT as AMOUNT
,a.CONVERT_MONEY as CONVERT_MONEY
,'' as bamount
from T_COST_ACTUAL_COSTS a left join T_Currency c on a.CURRENCY_ID = c.CURRENCYID
left join T_COST_VOUCHER b on a.VOUCHER_ID = b.VOUCHER_ID
left join (select a.NODE_ID,b.path as node_name ,b.ORDER_Char from T_COST_ACCOUNT a, f_getC('') b where a.NODE_ID = b.id) 
d2 on a.NODE_ID = d2.NODE_ID    
where   convert(varchar(4),a.OCCURENCY_DATE,120)='{0}' 
and a.SHIP_ID ='{1}' and a.SENDED <> 7 and a.SENDED <> 9 and ((b.current_state <> 3 and b.current_state <> 9) or b.current_state Is Null)
order by d2.ORDER_Char, d2.NODE_NAME,a.OCCURENCY_DATE,a.COMPLETE_DATE",
                                      year.ToString("yyyy"), ship_ID);

            DataTable dt;
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                //加汇总和年度预算行.

                string preNode = "";
                string currentNode = "";

                //int sunNodeStartLine = 1;           //子科目的起始行
                int sunNodeStartLine = 0;           //子科目的起始行-liulei/2016/01/11修改
                decimal sunNodeSum = 0M;            //子科目小计值

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    currentNode = dt.Rows[i]["NODE_NAME"].ToString();

                    if ((currentNode.Equals(preNode)) && (i > 0))
                    {
                        sunNodeSum = sunNodeSum + decimal.Parse(dt.Rows[i]["CONVERT_MONEY"].ToString());
                    }
                    else
                    {
                        if (sunNodeStartLine > 0)//子科目的起始行-liulei/2016/01/11修改
                        {
                            dt.Rows[sunNodeStartLine]["CONVERT_MONEY"] = sunNodeSum;
                        
                            sunNodeSum = 0M;
                        }
                    }

                    if (!currentNode.Equals(preNode))
                    {
                        //前一个根科目
                        string preRootNode = getRootNode(preNode);
                        //后一个根科目
                        string curRootNode = getRootNode(currentNode);

                        //加合计值行
                        if (!curRootNode.Equals(preRootNode))
                        {
                            DataRow row2 = dt.NewRow();
                            row2["NODE_NAME"] = curRootNode + " 合计";
                            row2["CONVERT_MONEY"] = dictSum.ContainsKey(curRootNode) ? decimal.Parse(dictSum[curRootNode]) : 0.00M;
                            row2["bamount"] = dictBudget.ContainsKey(curRootNode) ? dictBudget[curRootNode] : "";
                            dt.Rows.InsertAt(row2, i);
                            i++;
                        }
                        sunNodeStartLine = i;

                        //加小计行
                        DataRow row = dt.NewRow();
                        row["NODE_NAME"] = currentNode + " 小计";
                        dt.Rows.InsertAt(row, i);

                    }

                    preNode = currentNode;
                }

                //给最后一行小计行增加合计数量
                if (dt.Rows.Count>0 && dt.Rows[sunNodeStartLine] != null)//liulei-2016/01/07-增加判断
                {
                    dt.Rows[sunNodeStartLine]["CONVERT_MONEY"] = sunNodeSum;
                }

                return dt;
            }
            else
            {
                throw new Exception(err);
            }

        }
        #endregion


        /// <summary>
        /// 获得根节点字符串
        /// </summary>
        private string getRootNode(string nodes)
        {
            if (nodes.Contains("—"))
            {
                string[] nodesString = nodes.Split('—');
                return nodesString[0];
            }

            return nodes;
        }

        #region 根据发生日期和船舶ID，获得单个船舶的“费用汇总”数据
        /// <summary>
        /// 根据发生日期和船舶ID，获得单个船舶的“费用汇总”数据.
        /// </summary>
        public DataTable getSumByShip(DateTime year, string ship_id, out string err)
        {
            sql = "select c.NODE_NAME ,sum(a.CONVERT_MONEY) as CONVERT_MONEY"
            + " from T_COST_ACTUAL_COSTS a, T_COST_ACCOUNT b,T_COST_ACCOUNT c  ";

            sql += " where  a.NODE_ID = b.NODE_ID and b.TOP_NODE_ID = c.NODE_ID  and a.sended <>7 and a.sended<>9 ";
            sql += "\rand upper(a.SHIP_ID)='" + ship_id.ToUpper() + "' and convert(varchar(4),a.OCCURENCY_DATE,120)='" + year.ToString("yyyy") + "'";
            sql += " group by c.NODE_NAME";

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
        #endregion

        /// <summary>
        ///  #用于导出为Excel。形成"费用统计清单" 。.
        /// </summary>
        public bool GetOperationExcelOfShipBill(DateTime paymentYear, string ship_ID, string title, out  OperationExcel operationExcel, out string err)
        {
            operationExcel = new OperationExcel();
            operationExcel.DefaultFont = new Font("宋体", (float)9);
            Font rowTitle = new Font("宋体", (float)10, FontStyle.Bold);
            err = "";

            //表格首信息.

            if (!operationExcel.AddTitle(title, 1, out err))
            {
                return false;
            }

            DataTable dt = getShipBill(paymentYear, ship_ID, out err);//获取列表数据.
            if (dt == null)
            {
                err = "无法获取费用清单!";
                return false;
            }

            string preNodeName = "";
            string nodeName = "";
            string sumTitle = "";
            int b = 0;              //分类的递增间距.
            int s = 1;              //序号.
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!"小计".Equals(dt.Rows[i]["NODE_NAME"].ToString()))
                {
                    nodeName = dt.Rows[i]["NODE_NAME"].ToString();
                }

                if (!nodeName.EndsWith(preNodeName) || i == 0)
                {
                    s = 1;

                    //表格列标题头信息.
                    if (!operationExcel.InsertABodyUnit(new OneUnit(nodeName + "费用", false, 2 + i + b, 1, 1, 11, true, false, XlHorizontalAlignment.xlCenter, rowTitle), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("序号", false, 3 + i + b, 1, 1, 1, true, false, XlHorizontalAlignment.xlCenter, rowTitle), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("完成地点", false, 3 + i + b, 2, 1, 1, true, false, XlHorizontalAlignment.xlCenter, rowTitle), out err)
                        //|| !operationExcel.InsertABodyUnit(new OneUnit("发生日期", false, 3 + i + b, 3, 1, 1, true, false, XlHorizontalAlignment.xlCenter, rowTitle), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("上船/完成日期", false, 3 + i + b, 3, 1, 1, true, false, XlHorizontalAlignment.xlCenter, rowTitle), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("项目内容", false, 3 + i + b, 4, 1, 1, true, false, XlHorizontalAlignment.xlCenter, rowTitle), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("收款/施工单位", false, 3 + i + b, 5, 1, 1, true, false, XlHorizontalAlignment.xlCenter, rowTitle), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("发票日期", false, 3 + i + b, 6, 1, 1, true, false, XlHorizontalAlignment.xlCenter, rowTitle), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("发票号码", false, 3 + i + b, 7, 1, 1, true, false, XlHorizontalAlignment.xlCenter, rowTitle), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("币种", false, 3 + i + b, 8, 1, 1, true, false, XlHorizontalAlignment.xlCenter, rowTitle), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("金额", false, 3 + i + b, 9, 1, 1, true, false, XlHorizontalAlignment.xlCenter, rowTitle), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("折算美金", false, 3 + i + b, 10, 1, 1, true, false, XlHorizontalAlignment.xlCenter, rowTitle), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("预算金额", false, 3 + i + b, 11, 1, 1, true, false, XlHorizontalAlignment.xlCenter, rowTitle), out err)
                        )
                    { return false; }

                    if (!operationExcel.InsertABodyUnit(new OneUnit(s.ToString(), false, 4 + i + b, 1, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["COMPLETE_PALCE"].ToString(), false, 4 + i + b, 2, 1, 1, true, false, XlHorizontalAlignment.xlLeft), out err)
                        //|| !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["OCCURENCY_DATE"].ToString(), false, 4 + i + b, 3, 1, 1, true, false, XlHorizontalAlignment.xlLeft), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["COMPLETE_DATE"].ToString(), false, 4 + i + b, 3, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["REMARK"].ToString(), false, 4 + i + b, 4, 1, 1, true, false, XlHorizontalAlignment.xlLeft), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["CUSTOMER"].ToString(), false, 4 + i + b, 5, 1, 1, true, false, XlHorizontalAlignment.xlLeft), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["INVOICE_DATE"].ToString(), false, 4 + i + b, 6, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["INVOICE_NUM"].ToString(), false, 4 + i + b, 7, 1, 1, true, false, XlHorizontalAlignment.xlLeft), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["CURRENCYNAME"].ToString(), false, 4 + i + b, 8, 1, 1, true, false, XlHorizontalAlignment.xlLeft), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["AMOUNT"].ToString(), false, 4 + i + b, 9, 1, 1, true, false, XlHorizontalAlignment.xlRight), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["CONVERT_MONEY"].ToString(), false, 4 + i + b, 10, 1, 1, true, false, XlHorizontalAlignment.xlRight), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["bamount"].ToString(), false, 4 + i + b, 11, 1, 1, true, false, XlHorizontalAlignment.xlRight), out err)
                        )
                    { return false; }

                    b = b + 2;

                }
                else
                {

                    sumTitle = "小计";
                    if (!"小计".Equals(dt.Rows[i]["NODE_NAME"].ToString()))
                    {
                        sumTitle = s.ToString();
                    }

                    if (!operationExcel.InsertABodyUnit(new OneUnit(sumTitle, false, 2 + i + b, 1, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["COMPLETE_PALCE"].ToString(), false, 2 + i + b, 2, 1, 1, true, false, XlHorizontalAlignment.xlLeft), out err)
                        //|| !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["OCCURENCY_DATE"].ToString(), false, 2 + i + b, 3, 1, 1, true, false, XlHorizontalAlignment.xlLeft), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["COMPLETE_DATE"].ToString(), false, 2 + i + b, 3, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["REMARK"].ToString(), false, 2 + i + b, 4, 1, 1, true, false, XlHorizontalAlignment.xlLeft), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["CUSTOMER"].ToString(), false, 2 + i + b, 5, 1, 1, true, false, XlHorizontalAlignment.xlLeft), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["INVOICE_DATE"].ToString(), false, 2 + i + b, 6, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["INVOICE_NUM"].ToString(), false, 2 + i + b, 7, 1, 1, true, false, XlHorizontalAlignment.xlLeft), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["CURRENCYNAME"].ToString(), false, 2 + i + b, 8, 1, 1, true, false, XlHorizontalAlignment.xlLeft), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["AMOUNT"].ToString(), false, 2 + i + b, 9, 1, 1, true, false, XlHorizontalAlignment.xlRight), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["CONVERT_MONEY"].ToString(), false, 2 + i + b, 10, 1, 1, true, false, XlHorizontalAlignment.xlRight), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["bamount"].ToString(), false, 2 + i + b, 11, 1, 1, true, false, XlHorizontalAlignment.xlRight), out err)
                        )
                    { return false; }
                }

                preNodeName = nodeName;
                s++;
            }

            //列宽设置.
            operationExcel.SetHorizontal(false);
            operationExcel.AddAllColumnSize(1, 50);
            operationExcel.AddAllColumnSize(2, 130);
            //operationExcel.AddAllColumnSize(3, 200);
            operationExcel.AddAllColumnSize(3, 200);
            operationExcel.AddAllColumnSize(4, 250);
            operationExcel.AddAllColumnSize(5, 250);
            operationExcel.AddAllColumnSize(6, 80);
            operationExcel.AddAllColumnSize(7, 80);
            operationExcel.AddAllColumnSize(8, 80);
            operationExcel.AddAllColumnSize(9, 80);
            operationExcel.AddAllColumnSize(10, 80);
            operationExcel.AddAllColumnSize(11, 80);
            operationExcel.AddAllLineSize(1, 30);

            return true;
        }

        /// <summary>
        /// 获得 "未生成凭证的实际发生费用" 数据.
        /// </summary>
        public DataTable getInfoNoVoucher(string shipId, out string err)
        {
            sql = "select a.COSTS_ID,(t.SHIP_NAME +'|'+ convert(varchar(10),a.OCCURENCY_DATE,120) +'|'+ a.CUSTOMER"
            + " +'|'+ a.DESCRIPTION  +'|'+CAST(a.AMOUNT as varchar(100)) +'|'+ c.CURRENCYNAME) ,a.ship_id"
            + " from T_COST_ACTUAL_COSTS a, T_COST_ACCOUNT b,T_Currency c,T_SHIP t  ";
            sql += " where  a.NODE_ID = b.NODE_ID and a.CURRENCY_ID = c.CURRENCYID"
                + " and a.ship_id = t.ship_id and a.VOUCHER_ID is null and SENDED=1 ";
            if (!string.IsNullOrEmpty(shipId))
            {
                sql += " and a.ship_id = '" + dbOperation.ReplaceSqlKeyStr(shipId) + "'";
            }
            else
            {
                //只能加载自己管辖的船-liulei-2016/01/27
                sql += string.Format(@" and a.ship_id in (
select a.SHIP_ID  
from T_SHIP a,T_USER_SHIP u 
where a.ship_id = u.ship_id 
and  u.userid  ='{0}'
)", CommonOperation.ConstParameter.UserId);
            }
            sql += "\rorder by a.OCCURENCY_DATE";

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
        /// 获得 "已生成凭证的实际发生费用" 数据.
        /// </summary>
        public DataTable getInfoYesVoucher(string VoucherID, out string err)
        {
            sql = "select a.COSTS_ID,a.DESCRIPTION,c.CURRENCYID,c.CURRENCYCODE,c.CURRENCYNAME ";
            sql += " , a.AMOUNT as AMOUNT,a.REMARK,a.ship_id,a.CUSTOMER,s.SHIP_NAME,a.NODE_ID,a.APPLICANT ";
            sql += " from T_COST_ACTUAL_COSTS a, T_Currency c,T_SHIP s ";
            sql += " where   a.CURRENCY_ID = c.CURRENCYID  and a.ship_id = s.ship_id ";
            sql += "  and a.VOUCHER_ID ='" + VoucherID + "' ";
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
        /// 根据费用ID获取 "实际发生费用" 数据.
        /// </summary>
        public DataTable getInfoByID(string costID, out string err)
        {
            sql = "select a.COSTS_ID,a.DESCRIPTION,c.CURRENCYID,c.CURRENCYCODE,c.CURRENCYNAME ";
            sql += " , a.AMOUNT as AMOUNT,a.REMARK,a.ship_id,a.CUSTOMER,s.SHIP_NAME,a.NODE_ID,a.APPLICANT ";
            sql += " from T_COST_ACTUAL_COSTS a, T_Currency c,T_SHIP s ";
            sql += " where   a.CURRENCY_ID = c.CURRENCYID  and a.ship_id = s.ship_id ";
            sql += "  and a.COSTS_ID ='" + costID + "' ";

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
        /// 根据凭证号得到费用合计值.
        /// </summary>
        public string getCostsSum(string VoucherNum, out string err)
        {
            sql = "select convert(decimal(18,2),sum(A.AMOUNT)) as AMOUNT  ";
            sql += " from T_COST_ACTUAL_COSTS A INNER  JOIN T_COST_VOUCHER B ON A.VOUCHER_ID = B.VOUCHER_ID  ";
            sql += " where  B.VOUCHER_NUM ='" + VoucherNum + "' ";
            string sum = "";
            if (dbAccess.GetString(sql, out sum, out err))
            {
                return sum;
            }
            else
            {
                throw new Exception(err);
            }

        }

        /// <summary>
        /// 把费用项目和凭证建立关联关系.
        /// </summary>
        public bool CostsInVoucher(string voucher_ID, List<string> lstIDs, out string err)
        {
            List<string> lstSql = new List<string>();
            foreach (string COSTS_ID in lstIDs)
            {
                sql = "update T_COST_ACTUAL_COSTS set voucher_id ='" + voucher_ID + "',PAYMENT_DATE = '" + DateTime.Today.ToShortDateString()
                    + "',COMPLETE_DATE = '" + DateTime.Today.ToShortDateString()
                    + "' where  COSTS_ID ='" + COSTS_ID + "'";
                lstSql.Add(sql);
            }

            return dbAccess.ExecSql(lstSql, out err);
        }

        /// <summary>
        /// 取消费用项目和凭证关联关系.
        /// </summary>
        public bool CostsOutVoucher(List<string> lstIDs, out string err)
        {
            List<string> lstSql = new List<string>();
            foreach (string COSTS_ID in lstIDs)
            {
                sql = "update T_COST_ACTUAL_COSTS set voucher_id = null where  COSTS_ID ='" + COSTS_ID + "'";
                lstSql.Add(sql);
            }

            return dbAccess.ExecSql(lstSql, out err);
        }

        /// <summary>
        ///  #用于导出为Excel。形成单日凭证。.
        /// </summary>
        public bool GetOperationExcelOfVoucher(List<string> voucherIDs, out  OperationExcel operationExcel, out string err)
        {
            operationExcel = new OperationExcel();
            operationExcel.DefaultFont = new Font("宋体", (float)10);
            err = "";

            DataTable dt = VOUCHERService.Instance.getInfoByVoucherID(voucherIDs, out err);//获取单日凭证.
            if (dt == null)
            {
                err = "无法获取凭证信息!";
                return false;
            }

            int j = 1; //同一个凭证的明细序号
            string pre_num = "";            //上一个凭证号.
            string current_num = "";        //当前凭证号.
            // int added = 0;
            int b = 0;                    //凭证间距.
            bool firstTime = true;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //xuzb 2014-3-19，一页打两遍
                //如果付费项目为空\币种为空\金额为空跳过
                if (dt.Rows[i]["DESCRIPTION"].ToString().Trim().Length == 0 || dt.Rows[i]["CURRENCYNAME"].ToString().Trim().Length == 0 || dt.Rows[i]["AMOUNT"].ToString().Trim().Length == 0)
                {
                    continue;
                }

                current_num = dt.Rows[i]["VOUCHER_NUM"].ToString();

                #region 当前凭证号<>前一个凭证号
                if (!pre_num.Equals(current_num))
                {                    
                    //把之前的重复拷贝一次，然后换页
                    if (!firstTime)
                    {
                        //把前一个凭证的空白行填充完-liulei/2016/12/14修改. 
                        if (j > 1 && j < 6)
                        {                            
                            //第(5+j)行 空格
                            operationExcel.InsertAGrid(new OneGrid(5 + j + b, 1, 6 - j, 5));//插入(6 - j)行，5列的空格
                            //第22+j行 空格
                            operationExcel.InsertAGrid(new OneGrid(5 + j + b + 17, 1, 6 - j, 5));
                            //设置行高
                            for (int x = 1; x <= 6 - j; x++)
                            {
                                operationExcel.AddAllLineSize(4 + j + b + x, 14);
                                operationExcel.AddAllLineSize(4 + j + b + 17 + x, 14);
                            }
                        }
                        b = b + 34;
                        operationExcel.AddPageBreakerHorizontal(b);  
                    }
                    else firstTime = false;
                    //重新赋值
                    j = 1;
                    //added++;

                    //表格首信息.
                    //第1行
                    if (!operationExcel.InsertABodyUnit(new OneUnit("海丰国际", false, 1 + b, 1, 1, 5, false, false, XlHorizontalAlignment.xlCenter, new Font("黑体", 14)), out err))
                    { return false;}
                    //第2行
                    if(!operationExcel.InsertABodyUnit(new OneUnit("付款审批单/船东费用结算单", false, 2 + b, 1, 1, 5, false, false, XlHorizontalAlignment.xlCenter, new Font("黑体", 14)), out err))
                    { return false;}
                    //第3行
                    if (!operationExcel.InsertABodyUnit(new OneUnit("凭证号：" + dt.Rows[i]["VOUCHER_NUM"].ToString(), false, 3 + b, 5, 1, 1, false, false, XlHorizontalAlignment.xlRight), out err))
                    { return false; }
                    //第4行
                    if (!operationExcel.InsertABodyUnit(new OneUnit("申请单位：" + dt.Rows[i]["APPLY_COMPANY"].ToString(), false, 4 + b, 1, 1, 2, false, false, XlHorizontalAlignment.xlLeft), out err)
                       || !operationExcel.InsertABodyUnit(new OneUnit("日期：" + dt.Rows[i]["VOUCHER_DATE"].ToString(), false, 4 + b, 3, 1, 2, false, false, XlHorizontalAlignment.xlLeft), out err)
                       || !operationExcel.InsertABodyUnit(new OneUnit("应收船东：" + dt.Rows[i]["SHIP_OWNER"].ToString(), false, 4 + b, 5, 1, 1, false, false, XlHorizontalAlignment.xlRight), out err))
                    { return false; }
                    //第5行
                     if (!operationExcel.InsertABodyUnit(new OneUnit("序号", false, 5 + b, 1, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("付费项目", false, 5 + b, 2, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("币别", false, 5 + b, 3, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("金额", false, 5 + b, 4, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("备注", false, 5 + b, 5, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err))
                     { return false; }
                    //第11行
                    string AmountNUM = "(" + dt.Rows[i]["CURRENCYCODE"].ToString() + ")" + ACTUAL_COSTSService.Instance.getCostsSum(dt.Rows[i]["VOUCHER_NUM"].ToString(), out err);
                    string AmountChinese = "(" + dt.Rows[i]["CURRENCYNAME"].ToString() + ")" + Tools.numberToChinese(decimal.Parse(ACTUAL_COSTSService.Instance.getCostsSum(dt.Rows[i]["VOUCHER_NUM"].ToString(), out err)));

                    string APPLICANT = dt.Rows[i]["APPLICANT"].ToString();
                    string APPROVER = dt.Rows[i]["APPROVER"].ToString();
                    string APPROVER2 = dt.Rows[i]["APPROVER2"].ToString();

                     if (!operationExcel.InsertABodyUnit(new OneUnit("合计：", false, 11 + b, 1, 1, 1, true, false, XlHorizontalAlignment.xlLeft), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("大写：" + AmountChinese, false, 11 + b, 2, 1, 2, true, false, XlHorizontalAlignment.xlLeft), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("小写：" + AmountNUM, false, 11 + b, 4, 1, 2, true, false, XlHorizontalAlignment.xlLeft), out err))
                     { return false;}

                    //第12行
                    if (!operationExcel.InsertABodyUnit(new OneUnit("收款人：", false, 12 + b, 1, 1, 1, true, false, XlHorizontalAlignment.xlLeft), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["PAYEE"].ToString(), false, 12 + b, 2, 1, 2, true, false, XlHorizontalAlignment.xlLeft), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("附发票(收据)：" + dt.Rows[i]["INVOICE_NUM"].ToString() + "份", false, 12 + b, 4, 1, 2, true, false, XlHorizontalAlignment.xlLeft), out err))
                    { return false;}
                    //第13行--空行
                    operationExcel.AddAllLineSize(13 + b, 15);//13行空行的行高

                    //第14行
                    if (!operationExcel.InsertABodyUnit(new OneUnit("批准人：", false, 14 + b, 1, 1, 1, false, false, XlHorizontalAlignment.xlRight, new Font("黑体", 12)), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(APPROVER2, false, 14 + b, 2, 1, 1, false, false, XlHorizontalAlignment.xlLeft, new Font("黑体", 12)), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("审核人：", false, 14 + b, 3, 1, 1, false, false, XlHorizontalAlignment.xlRight, new Font("黑体", 12)), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(APPROVER, false, 14 + b, 4, 1, 1, false, false, XlHorizontalAlignment.xlLeft, new Font("黑体", 12)), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("申请人：" + APPLICANT, false, 14 + b, 5, 1, 1, false, false, XlHorizontalAlignment.xlLeft, new Font("黑体", 12)), out err))
                    { return false;}
                    //第15-17行--空行
                    operationExcel.AddAllLineSize(15 + b, 25);//15行空行的行高
                    operationExcel.AddAllLineSize(16 + b, 25);//16行空行的行高
                    operationExcel.AddAllLineSize(17 + b, 25);//17行空行的行高

                    //从18行开始拷贝一遍
                    //第18行
                    if(!operationExcel.InsertABodyUnit(new OneUnit("海丰国际", false, 1 + b + 17, 1, 1, 5, false, false, XlHorizontalAlignment.xlCenter, new Font("黑体", 14)), out err))
                    { return false;}
                    //第19行
                    if(!operationExcel.InsertABodyUnit(new OneUnit("付款审批单/船东费用结算单", false, 2 + b + 17, 1, 1, 5, false, false, XlHorizontalAlignment.xlCenter, new Font("黑体", 14)), out err))
                    { return false;}
                    //第20行
                    if (!operationExcel.InsertABodyUnit(new OneUnit("凭证号：" + dt.Rows[i]["VOUCHER_NUM"].ToString(), false, 3 + b + 17, 5, 1, 1, false, false, XlHorizontalAlignment.xlRight), out err))
                    { return false;}
                    //第21行
                    if (!operationExcel.InsertABodyUnit(new OneUnit("申请单位：" + dt.Rows[i]["APPLY_COMPANY"].ToString(), false, 4 + b + 17, 1, 1, 2, false, false, XlHorizontalAlignment.xlLeft), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("日期：" + dt.Rows[i]["VOUCHER_DATE"].ToString(), false, 4 + b + 17, 3, 1, 2, false, false, XlHorizontalAlignment.xlLeft), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("应收船东：" + dt.Rows[i]["SHIP_OWNER"].ToString(), false, 4 + b + 17, 5, 1, 1, false, false, XlHorizontalAlignment.xlRight), out err))
                    { return false;}
                    //第22行
                    if (!operationExcel.InsertABodyUnit(new OneUnit("序号", false, 5 + b + 17, 1, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("付费项目", false, 5 + b + 17, 2, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("币别", false, 5 + b + 17, 3, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("金额", false, 5 + b + 17, 4, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("备注", false, 5 + b + 17, 5, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err))
                    { return false;}

                    //第28行
                    if (!operationExcel.InsertABodyUnit(new OneUnit("合计：", false, 11 + b + 17, 1, 1, 1, true, false, XlHorizontalAlignment.xlLeft), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("大写：" + AmountChinese, false, 11 + b + 17, 2, 1, 2, true, false, XlHorizontalAlignment.xlLeft), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("小写：" + AmountNUM, false, 11 + b + 17, 4, 1, 2, true, false, XlHorizontalAlignment.xlLeft), out err))
                    { return false;}
                    //第29行.
                    if (!operationExcel.InsertABodyUnit(new OneUnit("收款人：", false, 12 + b + 17, 1, 1, 1, true, false, XlHorizontalAlignment.xlLeft), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["PAYEE"].ToString(), false, 12 + b + 17, 2, 1, 2, true, false, XlHorizontalAlignment.xlLeft), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("附发票(收据)：" + dt.Rows[i]["INVOICE_NUM"].ToString() + "份", false, 12 + b + 17, 4, 1, 2, true, false, XlHorizontalAlignment.xlLeft), out err))
                    { return false;}
                    //第30行--空行
                    operationExcel.AddAllLineSize(13 + b + 17, 15);//30行空行的行高
                    //第31行
                    if (!operationExcel.InsertABodyUnit(new OneUnit("批准人：", false, 14 + b + 17, 1, 1, 1, false, false, XlHorizontalAlignment.xlRight, new Font("黑体", 12)), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(APPROVER2, false, 14 + b + 17, 2, 1, 1, false, false, XlHorizontalAlignment.xlLeft, new Font("黑体", 12)), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("审核人：", false, 14 + b + 17, 3, 1, 1, false, false, XlHorizontalAlignment.xlRight, new Font("黑体", 12)), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(APPROVER, false, 14 + b + 17, 4, 1, 1, false, false, XlHorizontalAlignment.xlLeft, new Font("黑体", 12)), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit("申请人：" + APPLICANT, false, 14 + b + 17, 5, 1, 1, false, false, XlHorizontalAlignment.xlLeft, new Font("黑体", 12)), out err)
                        )
                    {
                        return false;
                    }
                    //第32-34行--空行
                    operationExcel.AddAllLineSize(32 + b, 10);
                    operationExcel.AddAllLineSize(33 + b, 10);
                    operationExcel.AddAllLineSize(34 + b, 10);
                    
                    

                    //表格数据行信息.
                    //第6行
                    if (!operationExcel.InsertABodyUnit(new OneUnit(j.ToString(), false, 6 + b, 1, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["DESCRIPTION"].ToString(), false, 6 + b, 2, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["CURRENCYNAME"].ToString(), false, 6 + b, 3, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["AMOUNT"].ToString(), false, 6 + b, 4, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["REMARK"].ToString(), false, 6 + b, 5, 1, 1, true, true, XlHorizontalAlignment.xlCenter), out err))
                    { return false;}

                    //第23行
                    if(!operationExcel.InsertABodyUnit(new OneUnit(j.ToString(), false, 6 + b + 17, 1, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["DESCRIPTION"].ToString(), false, 6 + b + 17, 2, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["CURRENCYNAME"].ToString(), false, 6 + b + 17, 3, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["AMOUNT"].ToString(), false, 6 + b + 17, 4, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["REMARK"].ToString(), false, 6 + b + 17, 5, 1, 1, true, true, XlHorizontalAlignment.xlCenter), out err)
                        )
                    {
                        return false;
                    }

                    pre_num = current_num;
                    j++;

                }
                #endregion
                #region 当前凭证号=前一个凭证号
                else
                {

                    //表格数据行信息.
                    //j为明细序号 5-前5行是表头
                    //第5+j行
                    if (!operationExcel.InsertABodyUnit(new OneUnit(j.ToString(), false, 5 + j + b, 1, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["DESCRIPTION"].ToString(), false, 5 + j + b, 2, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["CURRENCYNAME"].ToString(), false, 5 + j + b, 3, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["AMOUNT"].ToString(), false, 5 + j + b, 4, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["REMARK"].ToString(), false, 5 + j + b, 5, 1, 1, true, true, XlHorizontalAlignment.xlCenter), out err))
                    {
                        return false;
                    }
                    //第22+j行
                    if (!operationExcel.InsertABodyUnit(new OneUnit(j.ToString(), false, 5 + j + b + 17, 1, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["DESCRIPTION"].ToString(), false, 5 + j + b + 17, 2, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["CURRENCYNAME"].ToString(), false, 5 + j + b + 17, 3, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["AMOUNT"].ToString(), false, 5 + j + b + 17, 4, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[i]["REMARK"].ToString(), false, 5 + j + b + 17, 5, 1, 1, true, true, XlHorizontalAlignment.xlCenter), out err)
                        )
                    {
                        return false;
                    }

                    j++;
                }
                #endregion
                
                
            }//end-for

            //把最后一个凭证的空白行填充完-liulei/2016/12/14修改.
            if (j > 1 && j < 6)
            {
                //第(5+j)行 空格
                operationExcel.InsertAGrid(new OneGrid(5 + j + b, 1, 6 - j, 5));//插入(6 - j)行，5列的空格
                //第22+j行 空格
                operationExcel.InsertAGrid(new OneGrid(5 + j + b + 17, 1, 6 - j, 5));
                for (int x = 1; x <= 6 - j; x++)
                {
                    operationExcel.AddAllLineSize(4 + j + b + x, 14);
                    operationExcel.AddAllLineSize(4 + j + b + 17 + x, 14);
                }
            }
            //列宽设置.
            operationExcel.SetHorizontal(false);
            operationExcel.AddAllColumnSize(1, 70);
            operationExcel.AddAllColumnSize(2, 200);
            operationExcel.AddAllColumnSize(3, 100);
            operationExcel.AddAllColumnSize(4, 120);
            operationExcel.AddAllColumnSize(5, 280);
            operationExcel.AddAllColumnSize(6, 2);//保留右侧边距,否则打印会超页
            operationExcel.SetMargin(40, 0, 0, 0);
            return true;
        }

        #region 修改为根据费用发生日期，获得所有船舶的“费用汇总”数据
        /// <summary>
        /// 根据付款日期，获得所有船舶的“费用汇总”数据.
        /// </summary>
        public DataTable getSum(DateTime paymentYear, out string err)
        {
            //获取各个船舶年度费用汇总（包括年预算）列表.



//            sql = string.Format(@"declare @sql varchar(8000), @year varchar(100) 
//                    set @year = {0}
//                    select @sql = isnull(@sql + ',' , '') + ('[' + node_name + ']') from T_COST_ACCOUNT where parent_node_id is null order by order_num 
//                    exec ('select  t_ship.ship_name as 船舶,m.*, n.合计,''预算费'' as 预算费,m2.*,n2.合计
//                    from t_ship left join ((select * from (select a.ship_id,a.sum_money,b.node_name
//                    from V_COST_SUM a,T_COST_ACCOUNT b
//                    where a.top_node_id=b.node_id and payment_date = '+@year+') c
//                    pivot (sum(c.sum_money) for c.node_name in (' + @sql + ')) d) m inner join 
//                    (select ship_id , sum(sum_money) 合计 from V_COST_SUM 
//                    where payment_date =  '+@year+' group by ship_id) n on m.ship_id = n.ship_id ) on t_ship.ship_id = m.ship_id left join
//                    ((select * from (select a2.ship_id,a2.amount as amount,b2.node_name from T_COST_ANNUAL_BUDGET a2,T_COST_ACCOUNT b2  
//                     where a2.node_id=b2.node_id and convert(varchar(4),year_date,120) = '+@year+') c2
//                     pivot (sum(c2.amount) for c2.node_name in (' + @sql + ')) d2) m2 inner join 
//                    (select ship_id , sum(amount) as 合计  from T_COST_ANNUAL_BUDGET where convert(varchar(4),year_date,120) = '+@year+' 
//                    group by ship_id) n2 on  m2.ship_id = n2.ship_id) on n.SHIP_ID = n2.SHIP_ID  order by ship_en_name')",
//                    paymentYear.Year.ToString());

            //liulei-2016/01/08-修改为按费用发生日期查询
            sql = string.Format(@"declare @sql varchar(8000), @year varchar(100) 
                    set @year = {0}
                    select @sql = isnull(@sql + ',' , '') + ('[' + node_name + ']') from T_COST_ACCOUNT where parent_node_id is null order by order_num 
                    exec ('select  t_ship.ship_name as 船舶,m.*, n.合计,''预算费'' as 预算费,m2.*,n2.合计
                    from t_ship left join ((select * from (select a.ship_id,a.sum_money,b.node_name
                    from V_COST_SUM a,T_COST_ACCOUNT b
                    where a.top_node_id=b.node_id and OCCURENCY_DATE = '+@year+') c
                    pivot (sum(c.sum_money) for c.node_name in (' + @sql + ')) d) m inner join 
                    (select ship_id , sum(sum_money) 合计 from V_COST_SUM 
                    where OCCURENCY_DATE =  '+@year+' group by ship_id) n on m.ship_id = n.ship_id ) on t_ship.ship_id = m.ship_id left join
                    ((select * from (select a2.ship_id,a2.amount as amount,b2.node_name from T_COST_ANNUAL_BUDGET a2,T_COST_ACCOUNT b2  
                     where a2.node_id=b2.node_id and convert(varchar(4),year_date,120) = '+@year+') c2
                     pivot (sum(c2.amount) for c2.node_name in (' + @sql + ')) d2) m2 inner join 
                    (select ship_id , sum(amount) as 合计  from T_COST_ANNUAL_BUDGET where convert(varchar(4),year_date,120) = '+@year+' 
                    group by ship_id) n2 on  m2.ship_id = n2.ship_id) on n.SHIP_ID = n2.SHIP_ID  order by ship_en_name')",
                    paymentYear.Year.ToString());

            DataTable dt;
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                //把一行分成两行.

                DataTable dtAccount = dt.Clone();
                int columns = dt.Columns.Count;
                foreach (DataRow row in dt.Rows)
                {
                    object[] obj = new object[columns];
                    row.ItemArray.CopyTo(obj, 0);
                    object[] obj1 = new object[columns];
                    System.Array.Copy(obj, columns / 2, obj1, 0, columns / 2);

                    dtAccount.Rows.Add(obj);
                    dtAccount.Rows.Add(obj1);
                }

                return dtAccount;
            }
            else
            {
                throw new Exception(err);
            }

        }
        #endregion

        /// <summary>
        ///  #用于导出为Excel。形成“费用汇总”数据。.
        /// </summary>
        public bool GetOperationExcelOfSum(DateTime paymentYear, out  OperationExcel operationExcel, out string err)
        {
            operationExcel = new OperationExcel();
            operationExcel.DefaultFont = new Font("宋体", (float)9);
            err = "";

            //表格首信息.

            if (!operationExcel.AddTitle(paymentYear.Year.ToString() + "年全年各船费用统计（单位：美元）", 1, out err))
            {
                return false;
            }

            Font rowTitle = new Font("宋体", (float)11, FontStyle.Bold);
            DataTable dtRowsTitle = AccountService.Instance.GetMainSubjects();
            //表格(竖)列标题头信息.

            if (!operationExcel.InsertABodyUnit(new OneUnit("项目", false, 2, 1, 1, 1, true, false, XlHorizontalAlignment.xlCenter, rowTitle), out err))
            {
                return false;
            }
            int i = 0;
            for (; i < dtRowsTitle.Rows.Count; i++)
            {
                if (!operationExcel.InsertABodyUnit(new OneUnit(dtRowsTitle.Rows[i]["NODE_NAME"].ToString(), false, i + 3, 1, 1, 1, true, false, XlHorizontalAlignment.xlCenter, rowTitle), out err))
                {
                    return false;
                }
            }
            if (!operationExcel.InsertABodyUnit(new OneUnit("合计", false, i + 3, 1, 1, 1, true, false, XlHorizontalAlignment.xlCenter, rowTitle), out err))
            {
                return false;
            }

            DataTable dt = getSum(paymentYear, out err);//获取列表数据.
            if (dt == null)
            {
                err = "无法获取费用汇总信息!";
                return false;
            }

            int columns = dt.Columns.Count;         //显示的原始列数.

            int n2 = columns / 2;
            for (int m = 0; m < dt.Rows.Count; m++)
            {
                n2 = 0;
                for (int n = 0; n < columns / 2; n++)
                {
                    if (n == 1)
                    {
                        n++;
                    }

                    if (!operationExcel.InsertABodyUnit(new OneUnit(dt.Rows[m][n].ToString(), false, n2 + 2, m + 2, 1, 1, true, false, XlHorizontalAlignment.xlRight), out err))
                    {
                        return false;
                    }

                    n2++;
                }
            }

            //冻结某个区域.
            operationExcel.SetFreezePanes(2, 2);
            //operationExcel.AddAllColumnSize(columns + 1, 50);
            //列宽设置.
            operationExcel.SetHorizontal(false);

            return true;
        }

        #region 其它费用部分

        /// <summary>
        /// 获得 "费用项目" 数据.（对应科目和其下的子科目的费用列表）
        /// </summary>
        public DataTable getShipOwnerInfoByYear(string userId, string ship_id, DateTime year, string State,
            string account, string manufacturer, out string err)
        {
            //获得科目和其子科目的主键ID
            DataTable accountDT = Cost.Services.AccountService.Instance.GetTreeSubjects(account);
            //科目主键ID的集合
            string accountString = "";
            if (account.Length > 0)
                accountString += "'" + account + "',";

            foreach (DataRow dr in accountDT.Rows)
            {
                accountString += "'" + dr["NODE_ID"].ToString() + "',";
            }
            if (accountString.Length > 0)
                accountString = accountString.Substring(0, accountString.Length - 1);


            sql = "select a.COSTS_ID,case a.SENDED when 1 then '未做凭证' when 2 then '已做凭证' when 3 then '机务经理审批'"
            + " when 4 then '总裁审批' when 5 then '财务经理审批' when 6 then '已付款' when 7 then '打回' when 8 then '打回后提交' when 9 then '作废' end  SENDED"
            + ",s.ship_name,convert(varchar(10),a.OCCURENCY_DATE,120) as OCCURENCY_DATE"
            + ",convert(varchar(10),a.PAYMENT_DATE,120) as PAYMENT_DATE"
            + ",a.CUSTOMER,a.DESCRIPTION,c.CURRENCYNAME,a.AMOUNT as AMOUNT,a.CONVERT_MONEY as CONVERT_MONEY,a.INVOICE_NUM"
            + ",b.NODE_NAME"
            + ",convert(varchar(10),a.COMPLETE_DATE,120) as COMPLETE_DATE,a.COMPLETE_PALCE,a.SHIP_ID "
            + " from T_COST_ACTUAL_COSTS a, T_COST_ACCOUNT b,T_Currency c,t_ship s ";

            sql += " where a.SENDED < 99 and a.NODE_ID = b.NODE_ID and a.CURRENCY_ID = c.CURRENCYID and a.SHIP_ID=s.ship_id";
            if (!string.IsNullOrEmpty(ship_id))
                sql += " and upper(a.SHIP_ID)='" + ship_id.ToUpper() + "' ";
            else
                sql += " and upper(a.SHIP_ID) in (SELECT [Ship_Id]  FROM [T_USER_SHIP]  where UserId='" + userId + "') ";
            if (!string.IsNullOrEmpty(State))
                sql += " and a.SENDED=" + State + " ";
            if (!string.IsNullOrEmpty(account))
                sql += " and a.NODE_ID in (" + accountString + ") ";
            if (!string.IsNullOrEmpty(manufacturer))
                sql += " and a.CUSTOMER='" + manufacturer + "' ";
            sql += "  and convert(varchar(4),a.OCCURENCY_DATE,120)='" + year.ToString("yyyy") + "'";
            sql += " order by a.OCCURENCY_DATE";

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
        /// 获得 "流程外项目" 数据.（对应科目和其下的子科目的费用列表）
        /// </summary>
        public DataTable getOuterSAPCostByYear(string userId, string ship_id, DateTime year,
            string account, string manufacturer, out string err)
        {
            //获得科目和其子科目的主键ID
            DataTable accountDT = Cost.Services.AccountService.Instance.GetTreeSubjects(account);
            //科目主键ID的集合
            string accountString = "";
            if (account.Length > 0)
                accountString += "'" + account + "',";

            foreach (DataRow dr in accountDT.Rows)
            {
                accountString += "'" + dr["NODE_ID"].ToString() + "',";
            }
            if (accountString.Length > 0)
                accountString = accountString.Substring(0, accountString.Length - 1);


            sql = "select a.COSTS_ID,s.ship_name,convert(varchar(10),a.OCCURENCY_DATE,120) as OCCURENCY_DATE"

            + ",convert(varchar(10),a.PAYMENT_DATE,120) as PAYMENT_DATE"
            + ",a.CUSTOMER,a.DESCRIPTION,c.CURRENCYNAME,a.AMOUNT as AMOUNT,a.CONVERT_MONEY as CONVERT_MONEY,a.INVOICE_NUM"
            + ",b.NODE_NAME"
            + ",convert(varchar(10),a.COMPLETE_DATE,120) as COMPLETE_DATE,a.COMPLETE_PALCE,a.SHIP_ID "
            + " from T_COST_ACTUAL_COSTS a, T_COST_ACCOUNT b,T_Currency c,t_ship s ";

            sql += " where a.SENDED = 99 and a.NODE_ID = b.NODE_ID and a.CURRENCY_ID = c.CURRENCYID and a.SHIP_ID=s.ship_id";
            if (!string.IsNullOrEmpty(ship_id))
                sql += " and upper(a.SHIP_ID)='" + ship_id.ToUpper() + "' ";
            else
                sql += " and upper(a.SHIP_ID) in (SELECT [Ship_Id]  FROM [T_USER_SHIP]  where UserId='" + userId + "') ";
            if (!string.IsNullOrEmpty(account))
                sql += " and a.NODE_ID in (" + accountString + ") ";
            if (!string.IsNullOrEmpty(manufacturer))
                sql += " and a.CUSTOMER='" + manufacturer + "' ";
            sql += "  and convert(varchar(4),a.OCCURENCY_DATE,120)='" + year.ToString("yyyy") + "'";
            sql += " order by a.OCCURENCY_DATE";

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

        public string UpdateState(string VOUCHER_NUM, int STATE)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("update T_COST_ACTUAL_COSTS set SENDED=" + STATE);
            sb.AppendLine("where 1=1");
            sb.AppendLine("and voucher_id in (select voucher_id from T_COST_VOUCHER where VOUCHER_NUM='" + VOUCHER_NUM + "')");
            return sb.ToString();
        }
        /// <summary>
        /// 根据budget_id更新申请人,审核人,批准人.
        /// </summary>
        public List<string> UpdateApprover(string voucherNum, string APPLICANT, string APPROVER, string APPROVER2)
        {
            List<string> sqlList = new List<string>();
            StringBuilder sb = new StringBuilder();
            string sqlwhere = "where voucher_id in (select voucher_id from T_COST_VOUCHER where VOUCHER_NUM='" + voucherNum + "')";
            if (APPLICANT != null)
            {
                sb.AppendLine("update T_COST_ACTUAL_COSTS set APPLICANT='" + APPLICANT + "'");
                sb.AppendLine(sqlwhere);
                sqlList.Add(sb.ToString());
                sb = new StringBuilder();
                sb.AppendLine("update T_COST_VOUCHER set APPLICANT='" + APPLICANT + "'");
                sb.AppendLine(sqlwhere);
                sqlList.Add(sb.ToString());
            }
            if (APPROVER != null)
            {
                sb.AppendLine("update T_COST_ACTUAL_COSTS set APPROVER='" + APPROVER + "'");
                sb.AppendLine(sqlwhere);
                sqlList.Add(sb.ToString());
                sb = new StringBuilder();
                sb.AppendLine("update T_COST_VOUCHER set APPROVER='" + APPROVER + "'");
                sb.AppendLine(sqlwhere);
                sqlList.Add(sb.ToString());
            }
            if (APPROVER2 != null)
            {
                sb.AppendLine("update T_COST_ACTUAL_COSTS set APPROVER2='" + APPROVER2 + "'");
                sb.AppendLine(sqlwhere);
                sqlList.Add(sb.ToString());
                sb = new StringBuilder();
                sb.AppendLine("update T_COST_VOUCHER set APPROVER2='" + APPROVER2 + "'");
                sb.AppendLine(sqlwhere);
                sqlList.Add(sb.ToString());
            }
            return sqlList;
        }

        #endregion
        /// <summary>
        /// 查询坞修费用类型的实际发生费用,坞修用.
        /// </summary>
        public bool GetActualCostInfoByCondition(string SHIP_ID, DateTime beginDate, DateTime endDate, out DataTable dt, out string err)
        {
            dt = new DataTable();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select 	");
            sb.AppendLine("cas.COSTS_ID");
            sb.AppendLine(",cas.CUSTOMER");
            sb.AppendLine(",cas.DESCRIPTION");
            sb.AppendLine(",cas.ESTIMATE_AMOUNT");
            sb.AppendLine(",cas.AMOUNT");
            sb.AppendLine(",cas.CURRENCY_ID");
            sb.AppendLine(",cy.CURRENCYCODE");
            sb.AppendLine(",cas.CONVERT_MONEY");
            sb.AppendLine(",cas.CONTRACT_NUM");
            sb.AppendLine(",cas.VOUCHER_ID");
            sb.AppendLine(",cas.OCCURENCY_DATE");
            sb.AppendLine(",cas.COMPLETE_DATE");
            sb.AppendLine(",cas.COMPLETE_PALCE");
            sb.AppendLine(",cas.REMARK");
            sb.AppendLine(",cas.APPLICANT");
            sb.AppendLine(",cas.APPROVER");
            sb.AppendLine(",cas.APPROVER2");
            sb.AppendLine(",cas.PAYMENT_DATE");
            sb.AppendLine(",cas.INVOICE_DATE");
            sb.AppendLine(",cas.INVOICE_NUM");
            sb.AppendLine(",cas.SENDED");
            sb.AppendLine(",cas.SHIP_ID");
            sb.AppendLine(",s.SHIP_NAME");
            sb.AppendLine(",cas.NODE_ID");
            sb.AppendLine(",ca.NODE_NAME");
            sb.AppendLine("from T_COST_ACTUAL_COSTS cas");
            sb.AppendLine("inner join T_SHIP s on s.ship_id=cas.ship_id");
            sb.AppendLine("inner join T_cost_account ca on ca.node_ID=cas.node_ID");
            sb.AppendLine("inner join T_CURRENCY cy on cy.CURRENCYID=cas.CURRENCY_ID");
            sb.AppendLine("where 1=1");
            sb.AppendLine("and cas.SHIP_ID='" + SHIP_ID + "'");
            sb.AppendLine("and cas.OCCURENCY_DATE>='" + beginDate.ToShortDateString() + "' and cas.OCCURENCY_DATE<='" + endDate.AddDays(1).ToShortDateString() + "'");
            DataTable dtCostAccount;
            if (!CostAccountPositionService.Instance.GetInfoByCondition(
                new CostAccountPositionCondition(null, null, "4"), out dtCostAccount, out err))
            {
                return false;
            }
            if (dtCostAccount.Rows.Count == 0)
            {
                err = "请先配置坞修科目定位信息";
                return false;
            }
            sb.AppendLine("and cas.node_id in ('0'");
            foreach (DataRow item in dtCostAccount.Rows)
            {
                sb.AppendLine(",'" + item["NODE_ID"].ToString() + "'");
            }
            sb.AppendLine(")");
            sb.AppendLine("order by cas.OCCURENCY_DATE");
            return dbAccess.GetDataTable(sb.ToString(), out dt, out err);
        }

        /// <summary>
        /// 得到坞修费用类型的实际发生项目,并汇总成坞修总结,坞修用.
        /// </summary>
        public bool GetDockRepairInfo(string SHIP_ID, DateTime beginDate, DateTime endDate, out DataTable dt, out string err)
        {
            dt = new DataTable();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select	");
            sb.AppendLine("cas.SHIP_ID");
            sb.AppendLine(",s.SHIP_NAME");
            sb.AppendLine(",cas.NODE_ID");
            sb.AppendLine(",ca.NODE_NAME");
            sb.AppendLine(",cas.CUSTOMER");
            sb.AppendLine(",m.MANUFACTURER_ID");
            sb.AppendLine(",c.CURRENCYCODE+'('+CURRENCYNAME+')' as CURRENCYNAME");
            sb.AppendLine(",SUM(cas.ESTIMATE_AMOUNT) AS ESTIMATE_AMOUNT");
            sb.AppendLine(",SUM(cas.CONVERT_MONEY) AS TOTAL_AMOUNT");
            sb.AppendLine(",cas.CURRENCY_ID");
            sb.AppendLine("from T_COST_ACTUAL_COSTS cas");
            sb.AppendLine("inner join T_SHIP s on s.ship_id=cas.ship_id");
            sb.AppendLine("inner join T_cost_account ca on ca.node_ID=cas.node_ID");
            sb.AppendLine("inner join T_MANUFACTURER m on m.MANUFACTURER_NAME=cas.CUSTOMER");
            sb.AppendLine("inner join T_CURRENCY c on c.CURRENCYID=cas.CURRENCY_ID");
            sb.AppendLine("where 1=1");
            sb.AppendLine("and cas.SHIP_ID='" + SHIP_ID + "'");
            sb.AppendLine("and cas.OCCURENCY_DATE>='" + beginDate.ToShortDateString() + "' and cas.OCCURENCY_DATE<='" + endDate.AddDays(1).ToShortDateString() + "'");
            DataTable dtCostAccount;
            if (!CostAccountPositionService.Instance.GetInfoByCondition(
                new CostAccountPositionCondition(null, null, "4"), out dtCostAccount, out err))
            {
                return false;
            }
            if (dtCostAccount.Rows.Count == 0)
            {
                err = "请先配置坞修科目定位信息";
                return false;
            }
            sb.AppendLine("and cas.node_id in ('0'");
            foreach (DataRow item in dtCostAccount.Rows)
            {
                sb.AppendLine(",'" + item["NODE_ID"].ToString() + "'");
            }
            sb.AppendLine(")");
            sb.AppendLine("group by cas.SHIP_ID,s.SHIP_NAME,cas.NODE_ID,ca.NODE_NAME,cas.CUSTOMER,m.MANUFACTURER_ID,cas.CURRENCY_ID,c.CURRENCYNAME,c.CURRENCYCODE");
            return dbAccess.GetDataTable(sb.ToString(), out dt, out err);
        }

        /// <summary>
        /// 根据费用id得到所属凭证号
        /// </summary>
        public string GetVoucherNumByCOSTS_ID(string COSTS_ID)
        {
            DataTable dt;
            string err;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select	");
            sb.AppendLine("cv.voucher_num");
            sb.AppendLine("from T_COST_ACTUAL_COSTS cas");
            sb.AppendLine("inner join T_COST_VOUCHER cv on cv.VOUCHER_ID=cas.VOUCHER_ID");
            sb.AppendLine("where 1=1");
            sb.AppendLine("and cas.COSTS_ID='" + COSTS_ID + "'");
            dbAccess.GetDataTable(sb.ToString(), out dt, out err);
            if (dt.Rows.Count == 0)
                return "";
            else
                return dt.Rows[0][0].ToString();
        }

        #region CheckObj 相关业务 2015-02-26 徐正本

        /// <summary>
        /// 根据凭证号,获取费用评审审批工作流的流程对象
        /// </summary>
        /// <param name="voucherNum">凭证号</param>
        /// <returns>审批业务对象(Type : CheckObj)</returns>
        public CheckObj GetActualCostCheckObjByVoucherNum(string voucherNum)
        {
            string err;
            DataTable dt;
            sql = string.Format(@"select  t1.VOUCHER_NUM as businessid ,
  isnull(t1.SHIP_OWNER,'') + '(' + t1.VOUCHER_NUM + ') ' as businessName,
  isnull(t1.SHIP_OWNER,'') + '(' + t1.VOUCHER_NUM + ') ' + CONVERT(varchar(100), t1.VOUCHER_DATE, 111) + CHAR(13)+CHAR(10)
  + isnull(t1.PAYEE,'') + CHAR(13)+CHAR(10)
  + isnull(t2.DESCRIPTION,'') + cast(CAST( t2.CONVERT_MONEY as numeric(18,0)) as varchar(100))+ '$'+ CHAR(13)+CHAR(10) +
  isnull(t2.REMARK,'') as businessDetail
  FROM [shipmis_hf].[dbo].[T_COST_VOUCHER] t1 inner join dbo.T_COST_ACTUAL_COSTS t2 on t1.VOUCHER_ID = t2.VOUCHER_ID
  where t1.VOUCHER_NUM = '{0}'", dbOperation.ReplaceSqlKeyStr(voucherNum));
            dbAccess.GetDataTable(sql.ToString(), out dt, out err);
            if (dt.Rows.Count >= 1) return new CheckObj(dt.Rows[0]["businessid"].ToString(), dt.Rows[0]["businessName"].ToString(), dt.Rows[0]["businessDetail"].ToString());

#if DEBUG
            throw new Exception("未从数据库获取到指定凭证的相关信息,凭证号为:" + voucherNum);
#else
            return new CheckObj(voucherNum, voucherNum, "未获取到信息");
#endif
        }
        #endregion
    }
}
