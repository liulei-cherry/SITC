/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：BaseDataService.cs
 * 创 建 人：李景育
 * 创建时间：2007-05-12
 * 标    题：基础数据业务信息
 * 功能描述：定义一些基础信息的业务数据，主要为各个窗体的下拉列表设置各种数据来源，本类中包含
 *           的信息都是基础信息。
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using LSShipMis_Ship.Common;
using LSShipMis_Ship.Common.Classes;
using BaseInfo.DataAccess;
using BaseInfo.Objects;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
namespace LSShipMis_Ship.BasicData
{
    /// <summary>
    /// 基础数据业务信息.
    /// </summary>
    public class BaseDataService
    {
        //定义数据操作层对象.

        private static IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        
        /// <summary>
        /// 一、取得船舶用户基础数据.
        /// </summary>
        /// <param name="sWhere">查询信息的Where条件</param>
        /// <returns>返回一个DataTable对象</returns>
        public static DataTable GetShipUser(string sWhere)
        {
            DataTable dtb;//定义一个DataTable对象.
            string err = "";     //错误信息返回参数.
            string sSql = "";               //查询树型数据所需的SQL语句.

            sSql += "select shipuserid,";//主键.
            sSql += "username,";
            sSql += "ship_headship_id,";
            sSql += "ident,";
            sSql += "seanumb,";
            sSql += "ssnumb,";
            sSql += "sernumb,";
            sSql += "address,";
            sSql += "connection ";
            sSql += "from t_ship_user "; //船员信息表.

            sSql += "where username <> '超级用户' ";
            //设置查询的Where条件.
            if (sWhere.Trim().Length > 0)
            {
                sSql += sWhere;
            }
            sSql += "\rorder by username";
            dtb = dbAccess.GetDataTable(sSql, out err);
            return dtb;
        }

        /// <summary>
        /// 取得科考人员基础数据.
        /// </summary>
        /// <param name="sWhere">查询信息的Where条件</param>
        /// <returns>返回一个DataTable对象</returns>
        public static DataTable GetShipUserSc(string sWhere)
        {
            DataTable dtb;//定义一个DataTable对象.
            string err = "";     //错误信息返回参数.
            string sSql = "";               //查询树型数据所需的SQL语句.

            sSql += "select scientistid,";  //主键.
            sSql += "scientistname ";
            sSql += "from t_ship_user_science ";//船员信息表.

            sSql += "where 1=1 ";
            //设置查询的Where条件.
            if (sWhere.Trim().Length > 0)
            {
                sSql += sWhere;
            }

            dtb = dbAccess.GetDataTable(sSql, out err);
            return dtb;
        }

        /// <summary>
        /// 三、取得主管名称基础数据.
        /// </summary>
        /// <param name="sWhere">查询信息的Where条件</param>
        /// <returns>返回一个DataTable对象</returns>
        public static DataTable GetHeadShipName(string sWhere)
        {
            DataTable dtb;//定义一个DataTable对象.
            string err = "";        //错误信息返回参数.
            string sSql = "";               //查询树型数据所需的SQL语句.

            sSql += "select ship_headship_id,";//主键.
            sSql += "headship_name ";          //主管名称.
            sSql += "from t_base_headship ";    //船舶职务表.
            sSql += "where 1=1 ";
            //设置查询的Where条件.
            if (sWhere.Trim().Length > 0)
            {
                sSql += " and " +sWhere;
            }

            dtb = dbAccess.GetDataTable(sSql, out err);
            return dtb;
        }
 
        /// <summary>
        /// 十、取得船舶基础数据.
        /// </summary>
        /// <param name="sWhere">查询信息的Where条件</param>
        /// <returns>返回一个DataTable对象</returns>
        public static DataTable GetShip(string sWhere)
        {
            DataTable dtb;//定义一个DataTable对象.
            string err = "";     //错误信息返回参数.
            string sSql = "";               //查询树型数据所需的SQL语句.

            sSql += "select ship_id,";  //主键.
            sSql += "ship_name ";       //船舶名称.
            sSql += "from t_ship ";     //船舶信息表.

            sSql += "where 1=1 ";
            //设置查询的Where条件.
            if (sWhere.Trim().Length > 0)
            {
                sSql += sWhere;
            }
            sSql += " order by ship_name";

            dtb = dbAccess.GetDataTable(sSql, out err);
            return dtb;
        }
 
        /// <summary>
        /// 十一、取得航次基础数据.
        /// </summary>
        /// <param name="sWhere">查询信息的Where条件</param>
        /// <returns>返回一个DataTable对象</returns>
        public static DataTable GetVoyTimes(string sWhere)
        {
            DataTable dtb;//定义一个DataTable对象.
            string err = "";     //错误信息返回参数.
            string sSql = "";               //查询树型数据所需的SQL语句.

            sSql += "select voytimesid,";  //主键.
            sSql += "voytimesname ";       //航次名称.
            sSql += "from t_voy_voytimes "; //航次信息表.

            sSql += "where 1=1 ";
            //设置查询的Where条件.
            if (sWhere.Trim().Length > 0)
            {
                sSql += sWhere;
            }

            dtb = dbAccess.GetDataTable(sSql, out err);
            return dtb;
        }

        /// <summary>
        /// 十八、取得国籍基础数据.
        /// </summary>
        /// <param name="sWhere">查询信息的Where条件</param>
        /// <returns>返回一个DataTable对象</returns>
        public static DataTable GetCountry(string sWhere)
        {
            DataTable dtb;//定义一个DataTable对象.
            string err = "";     //错误信息返回参数.
            string sSql = "";               //查询树型数据所需的SQL语句.

            sSql += "select countryId,";//主键.
            sSql += "countryname ";
            sSql += "from t_country "; //船员信息表.

            sSql += "where 1=1 ";
            //设置查询的Where条件.
            if (sWhere.Trim().Length > 0)
            {
                sSql += sWhere;
            }

            dtb = dbAccess.GetDataTable(sSql, out err);
            return dtb;
        }  
 
    }
}