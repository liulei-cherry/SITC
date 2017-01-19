/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有 * 文 件 名：RoleRight.cs
 * 创 建 人：李景育 * 创建时间：2008-06-04
 * 标    题：用户角色权限业务类 * 功能描述：实现用户角色权限操作的业务类 * 修 改 人： 
 * 修改时间： * 修改内容： ****************************************************************************************************/
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using LSShipMis_Ship.BasicData;
using LSShipMis_Ship.Common;
using LSShipMis_Ship.Common.Classes;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
namespace LSShipMis_Ship.SysLs.Services
{
    public class RoleRight
    {
        /// <summary>
        /// 定义数据操作层对象.
        /// </summary>
        private static IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();

        /// <summary>
        /// 取得用户信息.
        /// </summary>
        /// <returns>返回一个DataTable对象</returns>
        public static DataTable GetSysUser()
        {
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.

            sSql += "select ";
            sSql += "a.userid,";
            sSql += "a.shipuserid,";
            sSql += "b.username,";
            sSql += "a.userloginname,";
           // sSql += "a.userloginpass,";
            sSql += "a.creator ";
            sSql += "from t_sys_user a ";
            sSql += "inner join t_ship_user b on a.shipuserid=b.shipuserid ";
            sSql += "where b.username <> '超级用户' ";
            sSql += "order by a.createtime";

            dtb = dbAccess.GetDataTable(sSql, out err);
            return dtb;
        }

        /// <summary>
        ///  取得登录用户信息.
        /// </summary>
        /// <returns>返回一个DataTable对象</returns>
        public static DataTable GetShipUser()
        {
            //变量定义部分.
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.

            //Select语句加工部分.
            sSql += "select ";
            sSql += "a.shipuserid,";
            sSql += "a.username,";
            sSql += "a.enname,";
            sSql += "a.sex,";
            sSql += "e.headship_name as job,";
            sSql += "b.countryname,";
            sSql += "a.ident ";
            sSql += "from t_ship_user a ";
            sSql += "inner join t_country b on a.countryid = b.countryid ";
            sSql += "inner join t_sys_user c on a.shipuserid = c.shipuserid ";
            sSql += "left join T_SHIP_USER_HEAD d on a.shipuserid = d.shipuserid ";
            sSql += "left join t_base_headship e on d.ship_headship_id = e.ship_headship_id ";

            dtb = dbAccess.GetDataTable(sSql, out err);
            return dtb;
        }

        /// <summary>
        /// 判断当前用户原口令是否正确.
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="oldPwd">用户原口令</param>
        /// <returns>如果正确，返回true，否则返回false</returns>
        public static bool IsRightOldPwd(string userId, string oldPwd)
        {
            //变量定义部分.
            bool blResult = false;              //返回结果变量.
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.

            //Select语句加工部分.
            sSql += "select ";
            sSql += "userid ";
            sSql += "from t_sys_user ";
            sSql += "where userid = '" + userId + "' and userloginpass = '" + oldPwd + "'";

            dtb = dbAccess.GetDataTable(sSql, out err);

            if (dtb.Rows.Count > 0)
            {
                blResult = true;
            }

            return blResult;
        }

        /// <summary>
        /// 用户口令修改.
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="newPwd">用户新口令</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public static void EditNewPwd(string userId, string newPwd, out string err)
        {
            string sUpdateSql = ""; //修改口令的SQL语句.

            sUpdateSql += "update t_sys_user set userloginpass = '" + newPwd + "'";
            sUpdateSql += "where userid = '" + userId + "'";

            //调用dbAccess的execSql执行sSql中的所有的操作语句.
            dbAccess.ExecSql(sUpdateSql, out err);
        }

        /// <summary>
        /// 取得船舶职务（角色）信息.
        /// </summary>
        /// <returns>返回一个DataTable对象</returns>
        public static DataTable GetShipHead()
        {
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.

            sSql += "select ";
            sSql += "a.ship_headship_id,";
            sSql += "a.headship_name,";
            sSql += "a.POSTLEVEL,";
            sSql += "a.DETAIL,";
            sSql += "a.creator ";
            sSql += "from t_base_headship a ";
            sSql += "order by a.POSTLEVEL";

            dtb = dbAccess.GetDataTable(sSql, out err);
            return dtb;
        }

        /// <summary>
        /// 取得船舶职务（角色）信息.
        /// </summary>
        /// <param name="shipUserId">船员职务信息</param>
        /// <returns>返回一个DataTable对象</returns>
        public static DataTable GetShipHead(string shipUserId)
        {
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.

            sSql += "select ";
            sSql += "case when b.shipuserid is null then 0 ";
            sSql += "     else 1 end as sel,";
            sSql += "a.ship_headship_id,";
            sSql += "a.headship_name,";
            sSql += "a.POSTLEVEL,";
            sSql += "a.DETAIL,";
            sSql += "a.creator ";
            sSql += "from t_base_headship a ";
            sSql += "left join (";
            sSql += "            select shipuserid,ship_headship_id from t_ship_user_head ";
            sSql += "            where shipuserid = '" + shipUserId + "'";
            sSql += "          ) b on a.ship_headship_id = b.ship_headship_id ";
            sSql += "order by a.POSTLEVEL";

            dtb = dbAccess.GetDataTable(sSql, out err);
            return dtb;
        }

        /// <summary>
        /// 取得指定职务的权限信息.
        /// </summary>
        /// <param name="shipHeadId">职务Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public static DataTable GetShipHeadRight(string shipHeadId)
        {
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.

            sSql += "select ";
            sSql += "case when b.ship_head_right_id is null then 0 ";
            sSql += "     else 1 end as sel,";
            sSql += "a.right_id,";
            sSql += "a.right_name,";
            sSql += "a.module,";
            sSql += "a.remark ";
            sSql += "from t_right a ";
            sSql += "left join (";
            sSql += "           select ship_head_right_id, right_id from t_ship_head_right";
            sSql += "           where ship_headship_id = '" + shipHeadId + "'";
            sSql += "          ) b on a.right_id = b.right_id ";
            sSql += "order by a.right_name ";

            dtb = dbAccess.GetDataTable(sSql, out err);
            return dtb;
        }

        /// <summary>
        /// 取得指定船员的权限信息.
        /// </summary>
        /// <param name="shipUserId">船员职务信息</param>
        /// <returns>返回一个DataTable对象</returns>
        public static DataTable GetShipUserRight(string shipUserId)
        {
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.

            sSql += "select ";
            sSql += "case when b.ship_user_right_id is null then 0 ";
            sSql += "     else 1 end as sel,";
            sSql += "a.right_id,";
            sSql += "a.right_name,";
            sSql += "a.module,";
            sSql += "a.remark ";
            sSql += "from t_right a ";
            sSql += "left join (";
            sSql += "           select ship_user_right_id, right_id from t_ship_user_right";
            sSql += "           where shipuserid = '" + shipUserId + "'";
            sSql += "          ) b on a.right_id = b.right_id ";
            sSql += "order by a.right_name ";

            dtb = dbAccess.GetDataTable(sSql, out err);
            return dtb;
        }

        /// <summary>
        /// 保存为指定船员选择的职务信息到对应关系表t_ship_user_head中去。.
        /// </summary>
        /// <param name="shipUserId">船员Id</param>
        /// <param name="rows">包含为指定船员选择的职务信息的DataRow数组对象</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public static void SaveSelShipHeads(string shipUserId, DataRow[] rows, out string err)
        {
            List<string> lstSqlOpt = new List<string>();//包含操作语句的List泛型集合.

            //把为指定船员选择的职务信息保存到表t_ship_user_head中去（先删除再重新插入）.
            string sDelShipHeads = "delete from t_ship_user_head where shipuserid = '" + shipUserId + "' ";
            lstSqlOpt.Add(sDelShipHeads);

            //循环rows中的每一行，把打勾选择的行信息添加到表t_ship_user_head中去.
            foreach (DataRow row in rows)
            {
                string newGuidId = Guid.NewGuid().ToString();//产生一个新的全球码的Guid
                string sel = row["sel"].ToString();//是否被选择标记.
                string shipHeadshipId = row["ship_headship_id"].ToString();//选择的船舶职务Id

                string sInsertSql = "insert into t_ship_user_head(ship_user_head_id,";
                sInsertSql += "shipuserid, ship_headship_id) values(";
                sInsertSql += "'" + newGuidId + "','" + shipUserId + "','" + shipHeadshipId + "')";
                lstSqlOpt.Add(sInsertSql);
            }

            //调用dbAccess的execSql执行sSql中的所有的操作语句.
            dbAccess.ExecSql(lstSqlOpt, out err);
        }

        /// <summary>
        /// 保存为指定职务选择的权限信息到对应关系表t_ship_head_right中去。.
        /// </summary>
        /// <param name="shipHeadId">职务Id</param>
        /// <param name="rows">包含为指定职务选择的权限信息的DataRow数组对象</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public static void SaveSelShipHeadRights(string shipHeadId, DataRow[] rows, out string err)
        {
            List<string> lstSqlOpt = new List<string>();//包含操作语句的List泛型集合.

            //把为指定职务选择的权限信息保存到表t_ship_head_right中去（先删除再重新插入）.
            string sDelShipHeadRights = "delete from t_ship_head_right where ship_headship_id = '" + shipHeadId + "' ";
            lstSqlOpt.Add(sDelShipHeadRights);

            //循环rows中的每一行，把打勾选择的行信息添加到表t_ship_user_head中去.
            foreach (DataRow row in rows)
            {
                string newGuidId = Guid.NewGuid().ToString();//产生一个新的全球码的Guid
                string sel = row["sel"].ToString();         //是否被选择标记.
                string rightId = row["right_id"].ToString();//选择的权限Id

                string sInsertSql = "insert into t_ship_head_right(ship_head_right_id,";
                sInsertSql += "ship_headship_id, right_id) values(";
                sInsertSql += "'" + newGuidId + "','" + shipHeadId + "','" + rightId + "')";
                lstSqlOpt.Add(sInsertSql);
            }

            //调用dbAccess的execSql执行sSql中的所有的操作语句.
            dbAccess.ExecSql(lstSqlOpt, out err);
        }

        /// <summary>
        /// 保存为指定船员选择的权限信息到对应关系表t_ship_user_right中去。.
        /// </summary>
        /// <param name="shipUserId">船员Id</param>
        /// <param name="rows">包含为指定船员选择的权限信息的DataRow数组对象</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public static void SaveSelUserRights(string shipUserId, DataRow[] rows, out string err)
        {
            List<string> lstSqlOpt = new List<string>();//包含操作语句的List泛型集合.

            //把为指定船员选择的权限信息保存到表t_ship_user_right中去（先删除再重新插入）.
            string sDelShipHeadRights = "delete from t_ship_user_right where shipuserid = '" + shipUserId + "' ";
            lstSqlOpt.Add(sDelShipHeadRights);

            //循环rows中的每一行，把打勾选择的行信息添加到表t_ship_user_right中去.
            foreach (DataRow row in rows)
            {
                string newGuidId = Guid.NewGuid().ToString();//产生一个新的全球码的Guid
                string sel = row["sel"].ToString();         //是否被选择标记.
                string rightId = row["right_id"].ToString();//选择的权限Id

                string sInsertSql = "insert into t_ship_user_right(ship_user_right_id,";
                sInsertSql += "shipuserid, right_id) values(";
                sInsertSql += "'" + newGuidId + "','" + shipUserId + "','" + rightId + "')";
                lstSqlOpt.Add(sInsertSql);
            }

            //调用dbAccess的execSql执行sSql中的所有的操作语句.
            dbAccess.ExecSql(lstSqlOpt, out err);
        }

        /// <summary>
        /// 保存权限表的备注信息.
        /// </summary>
        /// <param name="dictRemark">包含权限Id与备注信息的Dictionary字典集合</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public static void SaveRightRemark(Dictionary<string, string> dictRemark, out string err)
        {
            List<string> lstSqlOpt = new List<string>();//包含操作语句的List泛型集合.

            foreach (string rightId in dictRemark.Keys)
            {
                string remark = dictRemark[rightId];
                string sSql = "update t_right set remark = '" + remark + "' where right_id = '" + rightId + "'";
                lstSqlOpt.Add(sSql);
            }

            //调用dbAccess的execSql执行sSql中的所有的操作语句.
            dbAccess.ExecSql(lstSqlOpt, out err);
        }
    }
}