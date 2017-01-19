/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有 * 文 件 名：SeamanOpt.cs
 * 创 建 人：李景育 * 创建时间：2007-06-16
 * 标    题：船员管理操作
 * 功能描述：实现船员管理过程中各种对数据的操作
 * 修 改 人：
 * 修改时间： * 修改内容： ****************************************************************************************************/
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using LSShipMis_Ship.Common;
using LSShipMis_Ship.Common.Classes;
using CommonOperation.Interfaces;
using CommonOperation.Functions;

namespace LSShipMis_Ship.Seaman.Services
{
    /// <summary>
    /// 船员管理操作.
    /// </summary>
    public class SeamanOpt
    {
        private static IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();          //定义数据操作层对象.

        private static CommonOpt commonOpt = new CommonOpt();        //定义一个公共类CommonOpt对象.
        private static IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        /// <summary>
        /// 保存船员交接班数据.
        /// </summary>
        /// <param name="dtb">保存交接班信息的DataTable对象</param>
        /// <param name="tableName">表面</param>
        /// <param name="curInShipId">当着在船人员主键</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public static void SaveWkSendRece(DataTable dtb, string tableName, string curInShipId,
                                                        string shipId, string voytimesId, out string err)
        {
            //定义一个泛型集合用于保存所有删除或者添加的SQL语句.
            List<string> lstSqlOpt = new List<string>();

            //为在船船员下船更新下船时间Sql语句.
            string sUpdateSql = "Update T_Sm_InShip ";
            sUpdateSql += "set downshiptime= " + dbOperation.DbToDate(dtb.Rows[0]["senddate"].ToString());
            sUpdateSql += " where inshipid='" + curInShipId + "'";

            //添加接班人为新的上船船员Sql语句.
            string sInsertSql = "Insert Into T_Sm_InShip ";
            sInsertSql += "(inshipid,inshipuserId,ship_Id,voytimesId,upshiptime,shiphead,shipdepart,shiptask,connectmethod,creator)";
            sInsertSql += " values ('" + Guid.NewGuid().ToString() + "','" + dtb.Rows[0]["recepeople"].ToString() + "','" + shipId + "',";
            sInsertSql += "'" + voytimesId + "'," + dbOperation.DbToDate(dtb.Rows[0]["senddate"].ToString()) + ",";
            sInsertSql += "'" + dtb.Rows[0]["shiphead"].ToString() + "','" + dtb.Rows[0]["shipdepart"].ToString() + "',";
            sInsertSql += "'" + dtb.Rows[0]["shiptask"].ToString() + "','" + dtb.Rows[0]["receconct"].ToString() + "','" + CommonOperation.ConstParameter.UserName + "')";

            /*注意：上边的语句必须放到调用getOptSqlFromTable方法的前边，因为在getOptSqlFromTable
             * 中会去掉不属于数据库中T_Sm_WorkSend原表的列shiphead、shipdepart和shiptaskt从而造成出错*/
            lstSqlOpt = commonOpt.getOptSqlFromTable(dtb, tableName, out err);

            //把为在船船员下船更新下船时间Sql语句和添加接班人为新的上船船员Sql语句添加到泛型集合lstSqlOpt以便一起提交.

            lstSqlOpt.Add(sUpdateSql);
            lstSqlOpt.Add(sInsertSql);

            //提交数据.
            dbAccess.ExecSql(lstSqlOpt, out err);
        }

        /// <summary>
        /// 保存船员基本信息（已不使用）.
        /// </summary>
        /// <param name="dtb">bindingSource数据源的DataTable对象</param>
        /// <param name="fileName">照片路径</param>
        /// <param name="shipUserId">当前船员基本信息Id</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public static void SaveSeamanInfo(DataTable dtb, string fileName, string shipUserId, out string err)
        {
            if (dbOperation.SaveFormData(dtb, "T_Ship_User", 0, out err) && fileName.Length > 0)
            {
                string sUpdateBlob = ""; 

                sUpdateBlob = "update  t_ship_user set photo=@photo where shipuserId='" + shipUserId + "' ";
                dbAccess.WriteBlobToDbWithIns("", sUpdateBlob, fileName, "@photo", out err);

            }
        }

        /// <summary>
        /// 保存海员证信息或适任证信息或服务簿信息的数据.
        /// </summary>
        /// <param name="sSql">保存数据的SQL语句</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public static void SaveCertificate(string sSql, out string err)
        {
            //调用dbAccess的execSql执行sSql中的所有的操作语句.
            dbAccess.ExecSql(sSql, out err);
        }
    }
}