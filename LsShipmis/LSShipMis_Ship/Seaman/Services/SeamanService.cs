/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有 * 文 件 名：SeamanService.cs
 * 创 建 人：李景育 * 创建时间：2007-06-10
 * 标    题：在船人员业务信息
 * 功能描述：取与在船人员相关的业务数据。 * 修 改 人：
 * 修改时间： * 修改内容： ****************************************************************************************************/
using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using LSShipMis_Ship.Common;
using LSShipMis_Ship.Common.Classes;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
namespace LSShipMis_Ship.Seaman.Services
{
    /// <summary>
    /// 在船人员业务信息.
    /// </summary>
    public class SeamanService
    {
        //定义数据操作层对象.

        private static IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();

        /// <summary>
        ///  获得船员基本信息的列表数据.
        /// </summary>
        /// <returns>返回一个DataTable对象</returns>
        public static DataTable GetSeamanInfo()
        {
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.

            sSql += "select ";
            sSql += "a.shipuserid,";
            sSql += "a.username,";
            sSql += "a.enname,";
            sSql += "a.birthday,";
            sSql += "a.sex,";
            sSql += "a.nation,";
            sSql += "a.ismarriage,";
            sSql += "a.ship_headship_id,";
            sSql += "b.headship_name,";
            sSql += "a.unit_id,";
            sSql += "c.DEPARTNAME unit_name,";
            sSql += "a.countryid,";
            sSql += "d.countryname,";
            sSql += "a.schage,";
            sSql += "a.ident,";
            sSql += "a.seanumb,";
            sSql += "a.ssnumb,";
            sSql += "a.sernumb,";
            sSql += "a.address,";
            sSql += "a.connection,";
            sSql += "a.remark,";
            sSql += "a.creator ";
            sSql += "\rfrom t_ship_user a ";
            sSql += "\rleft join t_base_headship b on a.ship_headship_id=b.ship_headship_id ";
            sSql += "\rleft join T_DEPARTMENT c on a.unit_id=c.DEPARTMENTID ";
            sSql += "\rleft join t_country d on a.countryid=d.countryid where a.username != '超级用户'";
            sSql += "\rorder by a.username";//按创建时间排序.

            dtb = dbAccess.GetDataTable(sSql, out err);
            return dtb;
        }
 
        /// <summary>
        ///  获得船员家属信息的列表数据.
        /// </summary>
        /// <param name="shipuserid">船员Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public static DataTable GetSeamanIncome(string shipUserId)
        {
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.
            string sWhere = "";                 //查询条件.

            //Where条件加工部分.
            sWhere += " and a.shipuserid = '" + shipUserId + "' ";
            //Select语句加工部分.
            sSql += "select ";
            sSql += "a.SHIPUSERIncomeId,";
            sSql += "a.shipuserid,";
            sSql += "a.income,";
            sSql += "a.allowance,";
            sSql += "a.incomeDate,";
            sSql += "a.moreinfor ";
            sSql += "from T_SHIP_USER_INCOME a ";
            sSql += "where 1=1 ";
            //设置查询的Where条件.
            if (sWhere.Trim().Length > 0)
            {
                sSql += sWhere;
            }
            sSql += "order by a.incomeDate";//按创建时间排序.

            dtb = dbAccess.GetDataTable(sSql, out err);
            return dtb;
        }
        /// <summary>
        ///  获得在船人员信息的列表数据.
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <param name="voytimesId">航次Id</param>
        /// <param name="inshipType">在船类型</param>
        /// <param name="upTime">上船时间</param>
        /// <param name="downTime">下船时间</param>
        /// <returns>返回一个DataTable对象</returns>
        public static DataTable GetInShip(string shipId, string voytimesId, string inshipType, string upTime, string downTime)
        {
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.
            string sWhere = "";                 //查询条件.

            //Where条件加工部分.
            if (inshipType.Equals("当前在船"))
            {
                //查询当前在船人员信息数据.
                sWhere += "and a.ship_id = '" + shipId + "' and voytimesid = '" + voytimesId + "' and a.downshiptime is null ";
            }
            else
            {
                //查询非在船人员的历史数据（上船时间与下船时间在指定日期范围内的数据）.
                sWhere += "and a.ship_id = '" + shipId + "' and voytimesid = '" + voytimesId + "' and (a.upshiptime >='" + upTime + "' ";
                sWhere += "and (a.downshiptime is not null and a.downshiptime<='" + downTime + "')) ";

            }

            //Select语句加工部分.
            sSql += "select a.inshipid,";
            sSql += "a.ship_id,";
            sSql += "c.ship_name,";
            sSql += "a.voytimesid,";
            sSql += "a.inshipuserid,";
            sSql += "b.username,";
            sSql += "a.upshiptime,";
            sSql += "a.downshiptime,";
            sSql += "a.shiphead,";
            sSql += "a.shipdepart,";
            sSql += "a.shiptask,";
            sSql += "a.connectmethod,";
            sSql += "a.remark,";
            sSql += "a.creator ";
            sSql += "from t_sm_inship a ";//在船人员信息表.

            sSql += "left join t_ship_user b on a.inshipuserid = b.shipuserid ";
            sSql += "left join t_ship c on a.ship_id = c.ship_id ";
            sSql += "where 1 = 1 ";
            //设置查询的Where条件.
            if (sWhere.Trim().Length > 0)
            {
                sSql += sWhere;
            }
            sSql += "order by a.createtime";//按创建时间排序.

            dtb = dbAccess.GetDataTable(sSql, out err);
            return dtb;
        }

        /// <summary>
        ///  获得在船人员信息的列表数据（船员评估界面使用）.
        /// </summary>
        /// <param name="inshipType">在船类型</param>
        /// <param name="upTime">上船时间</param>
        /// <param name="downTime">下船时间</param>
        /// <returns>返回一个DataTable对象</returns>
        public static DataTable GetInShip(string inshipType, string upTime, string downTime)
        {
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.
            string sWhere = "";                 //查询条件.

            //Where条件加工部分.
            if (inshipType.Equals("当前在船"))
            {
                //查询当前在船人员信息数据.
                sWhere += "and downshiptime is null ";
            }
            else
            {

                //查询非在船人员的历史数据（上船时间与下船时间在指定日期范围内的数据）.
                sWhere += "and (upshiptime>='" + upTime + "' ";
                sWhere += "and (downshiptime is not null and downshiptime<='" + downTime + "')) ";

            }

            //Select语句加工部分.
            sSql += "select a.inshipid,";
            sSql += "a.ship_id,";
            sSql += "c.ship_name,";
            sSql += "a.voytimesid,";
            sSql += "a.inshipuserid,";
            sSql += "b.username,";
            sSql += "a.upshiptime,";
            sSql += "a.downshiptime,";
            sSql += "a.shiphead,";
            sSql += "a.shipdepart,";
            sSql += "a.shiptask,";
            sSql += "a.connectmethod,";
            sSql += "a.remark,";
            sSql += "a.creator ";
            sSql += "from t_sm_inship a ";//在船人员信息表.

            sSql += "left join t_ship_user b on a.inshipuserid=b.shipuserid ";
            sSql += "left join t_ship c on a.ship_id = c.ship_id ";
            sSql += "where 1=1 ";
            //设置查询的Where条件.
            if (sWhere.Trim().Length > 0)
            {
                sSql += sWhere;
            }
            sSql += "order by a.createtime";//按创建时间排序.

            dtb = dbAccess.GetDataTable(sSql, out err);
            return dtb;
        }

        /// <summary>
        ///  获得科考人员在船信息的列表数据.
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <param name="voytimesId">航次Id</param>
        /// <param name="inshipType">在船类型</param>
        /// <param name="upTime">上船时间</param>
        /// <param name="downTime">下船时间</param>
        /// <returns>返回一个DataTable对象</returns>
        public static DataTable GetInShip_Science(string shipId, string voytimesId, string inshipType, string upTime, string downTime)
        {
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.
            string sWhere = "";                 //查询条件.

            //Where条件加工部分.
            if (inshipType.Equals("当前在船"))
            {
                //查询当前在船人员信息数据.
                sWhere += "and a.ship_id = '" + shipId + "' and voytimesid = '" + voytimesId + "' and a.downshiptime is null ";
            }
            else
            {

                //查询非在船人员的历史数据（上船时间与下船时间在指定日期范围内的数据）.
                sWhere += "and a.ship_id = '" + shipId + "' and voytimesid = '" + voytimesId + "' and (a.upshiptime>='" + upTime + "' ";
                sWhere += "and (a.downshiptime is not null and a.downshiptime<='" + downTime + "')) ";

            }

            //Select语句加工部分.
            sSql += "select a.inshipid,";
            sSql += "a.ship_id,";
            sSql += "b.ship_name,";
            sSql += "a.voytimesid,";
            sSql += "a.shipnomem,";
            sSql += "a.upshiptime,";
            sSql += "a.downshiptime,";
            sSql += "a.shiphead,";
            sSql += "a.shipdepart,";
            sSql += "a.shiptask,";
            sSql += "a.connectmethod,";
            sSql += "a.remark,";
            sSql += "a.creator ";
            sSql += "from t_sm_inship_science a ";//在船人员信息表.
            sSql += "left join t_ship b on a.ship_id = b.ship_id ";
            sSql += "where 1=1 ";
            //设置查询的Where条件.
            if (sWhere.Trim().Length > 0)
            {
                sSql += sWhere;
            }
            sSql += "order by a.createtime";//按创建时间排序.

            dtb = dbAccess.GetDataTable(sSql, out err);
            return dtb;
        }

        /// <summary>
        ///  获得船员交接班信息的列表数据.
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <param name="startdate">起始日期</param>
        /// <param name="enddate">结束日期</param>
        /// <returns>返回一个DataTable对象</returns>
        public static DataTable GetWkShip(string shipId, string startdate, string enddate)
        {
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.
            string sWhere = "";                 //查询条件.

            sWhere += "and ship_Id = '" + shipId + "' and (senddate between '";
            sWhere += startdate + "' and  '" + enddate + "')";

            //Select语句加工部分.
            sSql += "select ";
            sSql += "a.worksendid,";
            sSql += "a.senddate,";
            sSql += "a.sendpeople,";
            sSql += "b.username as sendpeoplen,";
            sSql += "a.sendheadship,";
            sSql += "a.sendident,";
            sSql += "a.sendseanumb,";
            sSql += "a.sendssnumb,";
            sSql += "a.sendsernumb,";
            sSql += "a.sendaddress,";
            sSql += "a.sendconct,";
            sSql += "a.recepeople,";
            sSql += "c.username as recepeoplen,";
            sSql += "a.receheadship,";
            sSql += "a.receident,";
            sSql += "a.receseanumb,";
            sSql += "a.recessnumb,";
            sSql += "a.recesernumb,";
            sSql += "a.receaddress,";
            sSql += "a.receconct,";
            sSql += "a.sendrecerec ";
            sSql += "from t_sm_worksend a ";
            sSql += "inner join t_ship_user b on a.sendpeople=b.shipuserid ";
            sSql += "inner join t_ship_user c on a.recepeople=c.shipuserid ";
            sSql += "where 1=1 ";
            //设置查询的Where条件.
            if (sWhere.Trim().Length > 0)
            {
                sSql += sWhere;
            }
            sSql += "order by a.createtime";//按创建时间排序.

            dtb = dbAccess.GetDataTable(sSql, out err);
            return dtb;
        }

        /// <summary>
        ///  获得船员评估信息的列表数据.
        /// </summary>
        /// <param name="inshipId">在船人员Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public static DataTable GetShipMemEval(string inshipId)
        {
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.
            string sWhere = "";                 //查询条件.

            //Where条件加工部分.
            sWhere += " and a.inshipId='" + inshipId + "' ";

            //Select语句加工部分.
            sSql += "select ";
            sSql += "a.evalid,";
            sSql += "a.inshipid,";
            sSql += "a.evaluation,";
            sSql += "a.createtime,";
            sSql += "b.userloginname,";
            sSql += "a.creator,";
            sSql += "a.ship_id ";
            sSql += "from t_sm_inship_eval a ";
            sSql += "left join t_sys_user b on a.creator=b.userloginname ";
            sSql += "where 1=1 ";
            //设置查询的Where条件.
            if (sWhere.Trim().Length > 0)
            {
                sSql += sWhere;
            }
            sSql += " order by a.createtime";//按创建时间排序.

            dtb = dbAccess.GetDataTable(sSql, out err);
            return dtb;
        }

        /// <summary>
        /// 根据指定的船舶职务Id找船舶职务名称.
        /// </summary>
        /// <param name="shipHeadId">船舶职务Id</param>
        /// <returns>返回船舶职务名称</returns>
        public static string GetShipHead(string shipHeadId)
        {
            string headship_name = ""; //船舶职务名称.
            string err = "";//错误信息返回参数.
            string sSql = "";          //查询数据所需的SQL语句.

            sSql += "select ";
            sSql += "headship_name ";
            sSql += "from t_base_headship ";
            sSql += "where ship_headship_id = '" + shipHeadId + "'";

            headship_name = dbAccess.GetString(sSql, out err);
            return headship_name;
        }

        /// <summary>
        /// 找出所有当前在船人员的名单信息.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetInShipMemName()
        {
            DataTable dtb;//定义一个DataTable对象.
            string err = "";     //错误信息返回参数.
            string sSql = "";               //查询数据所需的SQL语句.

            sSql += "select ";
            sSql += "a.inshipuserid as shipuserid,";
            sSql += "b.username ";
            sSql += "from t_sm_inship a ";
            sSql += "inner join t_ship_user b on a.inshipuserid=b.shipuserid ";
            sSql += "where a.downshiptime is null ";

            dtb = dbAccess.GetDataTable(sSql, out err);
            return dtb;
        }

        /// <summary>
        /// 找出所有非在船人员的名单信息.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetNoInShipMemName()
        {
            DataTable dtb;//定义一个DataTable对象.
            string err = "";     //错误信息返回参数.
            string sSql = "";               //查询数据所需的SQL语句.

            sSql += "select ";
            sSql += "shipuserid,";
            sSql += "username ";
            sSql += "from t_ship_user ";
            sSql += "where shipuserid not in";
            sSql += "(";
            sSql += "select inshipuserid from t_sm_inship ";
            sSql += "where downshiptime is null";
            sSql += ")";

            dtb = dbAccess.GetDataTable(sSql, out err);
            return dtb;
        }

        /// <summary>
        /// 获得指定船员记录的照片的大对象流对象.
        /// </summary>
        /// <param name="shipUserId">船员信息主键</param>
        /// <returns>返回一个包含船员记录的照片的大对象流对象</returns>
        public static Image GetPhotoStream(string shipUserId)
        {
            string err = "";     //错误信息返回参数.

            string sSql = "select photo from t_ship_user where shipuserId='" + shipUserId + "'";
            Image imgPic = dbAccess.GetImageFromDb(sSql, out err);
            return imgPic;
        }

        /// <summary>
        /// 专业培训项目信息.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetPTrainItem()
        {
            DataTable dtb;//定义一个DataTable对象.
            string err = "";     //错误信息返回参数.
            string sSql = "";               //查询数据所需的SQL语句.

            sSql += "select ";
            sSql += "itemid,";
            sSql += "itemname ";
            sSql += "from t_sm_cerprotrain_item";
            dtb = dbAccess.GetDataTable(sSql, out err);
            return dtb;
        }

        /// <summary>
        /// 特殊培训项目信息.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSTrainItem()
        {
            DataTable dtb;//定义一个DataTable对象.
            string err = "";     //错误信息返回参数.
            string sSql = "";               //查询数据所需的SQL语句.

            sSql += "select ";
            sSql += "itemid,";
            sSql += "itemname ";
            sSql += "from t_sm_cerspectrain_item";
            dtb = dbAccess.GetDataTable(sSql, out err);
            return dtb;
        }

        /// <summary>
        ///  获得海员证信息数据.
        /// </summary>
        /// <param name="shipUserId">船员Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public static DataTable GetCerSeaman(string shipUserId)
        {
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.
            string sWhere = "";                 //查询条件.

            //Where条件加工部分.
            sWhere += " and a.shipuserid = '" + shipUserId + "' ";

            //Select语句加工部分.
            sSql += "select ";
            sSql += "a.seamancerid,";
            sSql += "a.shipuserid,";
            sSql += "a.seamancernumb,";
            sSql += "a.signdate,";
            sSql += "a.enddate,";
            sSql += "a.alertdays,";
            sSql += "a.remark,";
            sSql += "a.creator ";
            sSql += "from t_sm_cerseaman a ";
            sSql += "where 1=1 ";
            //设置查询的Where条件.
            if (sWhere.Trim().Length > 0)
            {
                sSql += sWhere;
            }
            sSql += "order by a.createtime";//按创建时间排序.

            dtb = dbAccess.GetDataTable(sSql, out err);
            return dtb;
        }

        /// <summary>
        ///  获得适任证书信息数据.
        /// </summary>
        /// <param name="shipUserId">船员Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public static DataTable GetCerShiren(string shipUserId)
        {
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.
            string sWhere = "";                 //查询条件.

            //Where条件加工部分.
            sWhere += " and a.shipuserid = '" + shipUserId + "' ";

            //Select语句加工部分.
            sSql += "select ";
            sSql += "a.cershirenid,";
            sSql += "a.shipuserid,";
            sSql += "a.cershirennumb,";
            sSql += "a.signdate,";
            sSql += "a.enddate,";
            sSql += "a.alertdays,";
            sSql += "a.cersort,";
            sSql += "a.cergrade,";
            sSql += "a.ship_headship_id,";
            sSql += "a.restrict_oilship,";
            sSql += "a.restrict_chemship,";
            sSql += "a.restrict_lpgship,";
            sSql += "a.restrict_custship,";
            sSql += "a.restrict_aquaship,";
            sSql += "a.restrict_notransit,";
            sSql += "a.restrict_custgun,";
            sSql += "a.restrict_hignspeed,";
            sSql += "a.restrict_gmdss,";
            sSql += "a.restrict_gasfired,";
            sSql += "a.restrict_steamer,";
            sSql += "a.creator ";
            sSql += "from t_sm_cershiren a ";
            sSql += "where 1=1 ";
            //设置查询的Where条件.
            if (sWhere.Trim().Length > 0)
            {
                sSql += sWhere;
            }
            sSql += "order by a.createtime";//按创建时间排序.

            dtb = dbAccess.GetDataTable(sSql, out err);
            return dtb;
        }

        /// <summary>
        ///  获得服务簿信息数据.
        /// </summary>
        /// <param name="shipUserId">船员Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public static DataTable GetCerSerBook(string shipUserId)
        {
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.
            string sWhere = "";                 //查询条件.

            //Where条件加工部分.
            sWhere += " and a.shipuserid = '" + shipUserId + "' ";

            //Select语句加工部分.
            sSql += "select ";
            sSql += "a.cerservbookid,";
            sSql += "a.shipuserid,";
            sSql += "a.cerservbooknumb,";
            sSql += "a.signdate,";
            sSql += "a.alertdays,";
            sSql += "a.remark,";
            sSql += "a.creator ";
            sSql += "from t_sm_cerservbook a ";
            sSql += "where 1=1 ";
            //设置查询的Where条件.
            if (sWhere.Trim().Length > 0)
            {
                sSql += sWhere;
            }
            sSql += "order by a.createtime";//按创建时间排序.

            dtb = dbAccess.GetDataTable(sSql, out err);
            return dtb;
        }

        /// <summary>
        ///  获得专业培训合格证信息数据.
        /// </summary>
        /// <param name="shipUserId">船员Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public static DataTable GetCerProTrain(string shipUserId)
        {
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.
            string sWhere = "";                 //查询条件.

            //Where条件加工部分.
            sWhere += " and a.shipuserid = '" + shipUserId + "' ";

            //Select语句加工部分.
            sSql += "select ";
            sSql += "a.cerprotrainid,";
            sSql += "a.shipuserid,";
            sSql += "a.cerprotrainnumb,";
            sSql += "a.itemid,";
            sSql += "b.itemname,";
            sSql += "a.signdepart,";
            sSql += "a.signdate,";
            sSql += "a.remark,";
            sSql += "a.creator ";
            sSql += "from t_sm_cerprotrain a ";
            sSql += "inner join t_sm_cerprotrain_item b on a.itemid=b.itemid ";
            sSql += "where 1=1 ";
            //设置查询的Where条件.
            if (sWhere.Trim().Length > 0)
            {
                sSql += sWhere;
            }
            sSql += "order by a.createtime";//按创建时间排序.

            dtb = dbAccess.GetDataTable(sSql, out err);
            return dtb;
        }

        /// <summary>
        ///  获得特殊培训合格证信息数据.
        /// </summary>
        /// <param name="shipUserId">船员Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public static DataTable GetCerSpecTrain(string shipUserId)
        {
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.
            string sWhere = "";                 //查询条件.

            //Where条件加工部分.
            sWhere += " and a.shipuserid = '" + shipUserId + "' ";

            //Select语句加工部分.
            sSql += "select ";
            sSql += "a.cerspectrainid,";
            sSql += "a.shipuserid,";
            sSql += "a.cerspectrainnumb,";
            sSql += "a.itemid,";
            sSql += "b.itemname,";
            sSql += "a.signdepart,";
            sSql += "a.signdate,";
            sSql += "a.remark,";
            sSql += "a.creator ";
            sSql += "from t_sm_cerspectrain a ";
            sSql += "inner join t_sm_cerspectrain_item b on a.itemid=b.itemid ";
            sSql += "where 1=1 ";
            //设置查询的Where条件.
            if (sWhere.Trim().Length > 0)
            {
                sSql += sWhere;
            }
            sSql += "order by a.createtime";//按创建时间排序.

            dtb = dbAccess.GetDataTable(sSql, out err);
            return dtb;
        }

        /// <summary>
        ///  获得其它证书信息数据.
        /// </summary>
        /// <param name="shipUserId">船员Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public static DataTable GetCerOther(string shipUserId)
        {
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.
            string sWhere = "";                 //查询条件.

            //Where条件加工部分.
            sWhere += " and a.shipuserid = '" + shipUserId + "' ";

            //Select语句加工部分.
            sSql += "select ";
            sSql += "a.cerotherid,";
            sSql += "a.shipuserid,";
            sSql += "a.cerothernumb,";
            sSql += "a.cerothername,";
            sSql += "a.signdate,";
            sSql += "a.enddate,";
            sSql += "a.alertdays,";
            sSql += "a.remark,";
            sSql += "a.creator ";
            sSql += "from t_sm_cerother a ";
            sSql += "where 1=1 ";
            //设置查询的Where条件.
            if (sWhere.Trim().Length > 0)
            {
                sSql += sWhere;
            }
            sSql += "order by a.createtime";//按创建时间排序.

            dtb = dbAccess.GetDataTable(sSql, out err);
            return dtb;
        }

        /// <summary>
        ///  获得船员培训信息数据.
        /// </summary>
        /// <param name="shipUserId">船员Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public static DataTable GetSmTraining(string shipUserId)
        {
            DataTable dtb;//定义一个DataTable对象.
            string err = "";     //错误信息返回参数.
            string sSql = "";               //查询数据所需的SQL语句.
            string sWhere = "";                 //查询条件.

            //Where条件加工部分.
            sWhere += " and a.shipuserid = '" + shipUserId + "' ";

            //Select语句加工部分.
            sSql += "select ";
            sSql += "a.smtrainingid,";
            sSql += "a.shipuserid,";
            sSql += "a.ship_id,";
            sSql += "b.ship_name,";
            sSql += "a.traindate,";
            sSql += "a.trainspot,";
            sSql += "a.traincontent,";
            sSql += "a.creator ";
            sSql += "from t_sm_training a ";
            sSql += "left join t_ship b on a.ship_id = b.ship_id ";
            sSql += "where 1=1 ";
            //设置查询的Where条件.
            if (sWhere.Trim().Length > 0)
            {
                sSql += sWhere;
            }
            sSql += "order by a.createtime";//按创建时间排序.

            dtb = dbAccess.GetDataTable(sSql, out err);
            return dtb;
        }

        /// <summary>
        ///  获得船员考勤信息数据.
        /// </summary>
        /// <param name="shipUserId">船员Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public static DataTable GetSmTimeCard(string shipUserId)
        {
            DataTable dtb;//定义一个DataTable对象.
            string err = "";     //错误信息返回参数.
            string sSql = "";               //查询数据所需的SQL语句.
            string sWhere = "";                 //查询条件.

            //Where条件加工部分.
            sWhere += " and a.shipuserid = '" + shipUserId + "' ";

            //Select语句加工部分.
            sSql += "select ";
            sSql += "a.timecardid,";
            sSql += "a.shipuserid,";
            sSql += "a.ship_id,";
            sSql += "b.ship_name,";
            sSql += "a.workstate,";
            sSql += "a.startdate,";
            sSql += "a.enddate,";
            sSql += "a.remark,";
            sSql += "a.creator ";
            sSql += "from t_sm_timecard a ";
            sSql += "left join t_ship b on a.ship_id = b.ship_id ";
            sSql += "where 1 = 1 ";
            //设置查询的Where条件.
            if (sWhere.Trim().Length > 0)
            {
                sSql += sWhere;
            }
            sSql += "order by a.createtime";//按创建时间排序.

            dtb = dbAccess.GetDataTable(sSql, out err);
            return dtb;
        }
    }
}