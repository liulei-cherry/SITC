/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：DataService.cs
 * 创 建 人：李景育
 * 创建时间：2009-02-16
 * 标    题：资料领取登记业务信息
 * 功能描述：取与资料领取登记相关的业务数据。
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using CommonOperation.Functions;
using CommonOperation.Interfaces; 

namespace SeaChartManage.Services
{
    /// <summary>
    /// 资料领取登记业务信息.
    /// </summary>
    public class DataService
    {
        /// <summary>
        /// 定义数据操作层对象.
        /// </summary>
        private static IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private static IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation(); 
        /// <summary>
        /// 取得资料借阅信息.
        /// </summary>
        /// <returns>返回一个DataTable对象</returns>
        public static DataTable GetData()
        {
            //变量定义部分.
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.

            //Select语句加工部分.
            sSql += "select ";
            sSql += "a.data_id,";
            sSql += "a.data_stock_id,";
            sSql += "b.data_name,";
            sSql += "a.apply_date,";
            sSql += "a.catch_date,";
            sSql += "a.end_date,";
            sSql += "a.apply_persorn,";
            sSql += "a.data_remark,";
            sSql += "a.return_flag,";
            sSql += "case when a.return_flag=1 then '是'";
            sSql += "                          else '否' end as return_name ";
            sSql += "from t_data a ";
            sSql += "inner join t_data_stock b on a.data_stock_id = b.data_stock_id";
            
            dbAccess.GetDataTable(sSql, out dtb, out err);

            return dtb;
        }

        /// <summary>
        /// 取得资料名称的基础数据.
        /// </summary>
        /// <returns>返回一个DataTable对象</returns>
        public static DataTable GetDataName()
        {
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.

            sSql += "select data_stock_id,";
            sSql += "data_name ";
            sSql += "from t_data_stock";
            dbAccess.GetDataTable(sSql, out dtb, out err);
            return dtb;
        }

        /// <summary>
        /// 取得指定资料的当前库存数.
        /// </summary>
        /// <param name="dataStockId">资料库存Id</param>
        /// <returns></returns>
        public static int GetDataStockNumb(string dataStockId)
        {
            int dataStockNumb = 0;
            string sDataStockNumb = "";
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.

            sSql += "select data_lieve_number ";
            sSql += "from t_data_stock where data_stock_id = '" + dataStockId + "'";

            dbAccess.GetString(sSql, out sDataStockNumb, out err);

            if (sDataStockNumb != "")
            {
                dataStockNumb = int.Parse(sDataStockNumb);
            }

            return dataStockNumb;
        }

        /// <summary>
        /// 资料的保存.
        /// </summary>
        /// <param name="dtb">包含数据的DataTable对象</param>
        /// <param name="dataStockId">资料库存Id</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public static bool SaveData(DataTable dtb, string dataStockId, out string err)
        {
            List<string> lstSqlOpt = new List<string>();//包含操作语句的List泛型集合.
            string sSql = "";   //更新库存的SQL语句.
            
            //得到dtb数据的一份克隆（注意不能是dtb，因为它是引用类型，数据一改变影响其它组件的显示）.
            DataTable dtbForSave = dtb.Copy();

            //取出对表T_Data的所有编辑的SQL语句.
            if(dbOperation.SaveFormData(dtbForSave, "t_data",0, out err))
            {
                sSql = "update t_data_stock set data_lieve_number = data_lieve_number - 1 where data_stock_id = '" + dataStockId + "'";
                lstSqlOpt.Add(sSql);
                //调用dbAccess的execSql执行sSql中的所有的操作语句.
                return dbAccess.ExecSql(lstSqlOpt, out err);
            }
            return false;
        }

        /// <summary>
        /// 资料的返还.
        /// </summary>
        /// <param name="dataId">借阅信息Id</param>
        /// <param name="dataStockId">资料库存Id</param>
        /// <param name="endDate">返还日期</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public static bool DataReturn(string dataId, string endDate, string dataStockId, out string err)
        {
            List<string> lstSqlOpt = new List<string>();//包含操作语句的List泛型集合.

            string sSqlUpdate1 = "update t_data set return_flag = 1, end_date = '" + endDate + "' where data_id = '" + dataId + "'";
            string sSqlUpdate2 = "update t_data_stock set data_lieve_number = data_lieve_number + 1 where data_stock_id = '" + dataStockId + "'";

            lstSqlOpt.Add(sSqlUpdate1);
            lstSqlOpt.Add(sSqlUpdate2);

            //调用dbAccess的execSql执行lstSqlOpt中的所有的操作语句.
            return dbAccess.ExecSql(lstSqlOpt, out err);
        }
    }
}
