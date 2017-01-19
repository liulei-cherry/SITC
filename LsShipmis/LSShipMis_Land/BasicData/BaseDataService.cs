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
using LSShipMis_Land.Common;
using LSShipMis_Land.Common.Classes;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
namespace LSShipMis_Land.BasicData
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
        /// 二、取得系统用户基础数据.
        /// </summary>
        /// <param name="sWhere">查询信息的Where条件</param>
        /// <returns>返回一个DataTable对象</returns>
        public static DataTable GetSysUser(string sWhere)
        {
            DataTable dtb;//定义一个DataTable对象.
            string err = "";     //错误信息返回参数.
            string sSql = "";               //查询树型数据所需的SQL语句.

            sSql += "select ";
            sSql += "a.userid,";
            sSql += "b.username ";
            sSql += "from t_sys_user a ";
            sSql += "inner join t_ship_user b on a.shipuserid=b.shipuserid ";
            sSql += "where b.username <> '超级用户' ";
            //设置查询的Where条件.
            if (sWhere.Trim().Length > 0)
            {
                sSql += sWhere;
            }
            sSql += "order by a.createtime ";

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
                sSql += sWhere;
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
            sSql += " order by SHIP_NAME";

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
        /// 十七、取得供应商名称的基础数据.
        /// </summary>
        /// <returns>返回一个DataTable对象</returns>
        public static DataTable GetManufacture()
        {
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询树型数据所需的SQL语句.

            sSql += "select ";
            sSql += "manufacturer_id,"; //主键.
            sSql += "manufacturer_name,";//供应商名称.

            sSql += "linker,";          //联系人.

            sSql += "telephone,";       //联系电话.
            sSql += "fax,";             //传真.
            sSql += "addr ";            //联系地址.
            sSql += "from t_manufacturer";//供应商信息表.

            dtb = dbAccess.GetDataTable(sSql, out err);
            return dtb;
        }

        /// <summary>
        /// 十八、取得供应商名称的基础数据（提供条件）.
        /// </summary>
        /// <param name="sWhere">查询信息的Where条件</param>
        /// <returns>返回一个DataTable对象</returns>
        public static DataTable GetManufacture(string sWhere)
        {
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询树型数据所需的SQL语句.

            sSql += "select ";
            sSql += "manufacturer_id,"; //主键.
            sSql += "manufacturer_name,";//供应商名称.

            sSql += "linker,";          //联系人.

            sSql += "telephone,";       //联系电话.
            sSql += "fax,";             //传真.
            sSql += "addr ";            //联系地址.
            sSql += "from t_manufacturer ";//供应商信息表.
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
        /// <summary>
        /// 十九、取得币种基础数据.
        /// </summary>
        /// <param name="sWhere">查询信息的Where条件</param>
        /// <returns>返回一个DataTable对象</returns>
        public static DataTable GetCurrency(string sWhere)
        {
            DataTable dtb;//定义一个DataTable对象.
            string err = "";     //错误信息返回参数.
            string sSql = "";               //查询树型数据所需的SQL语句.

            sSql += "select coin_id,";  //主键.
            sSql += "coin_name ";
            sSql += "from t_cointype "; //币种表.

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
        /// 取得当前本位币Id
        /// </summary>
        /// <returns>返回当前本位币Id</returns>
        public static string GetCurCoinId()
        {
            string sCurCoinId = "";     //当前本位币Id

            string err = ""; //错误信息返回参数.
            string sSql = "";           //查询树型数据所需的SQL语句.

            sSql += "select ";
            sSql += "b.coin_id ";
            sSql += "from t_coin_convert a "; //本位币表.
            sSql += "inner join t_cointype b on a.coin_convertcur_id=b.coin_id ";

            sCurCoinId = dbAccess.GetString(sSql, out err);
            return sCurCoinId;
        }

        /// <summary>
        /// 取得当前本位币编码.
        /// </summary>
        /// <returns>返回当前本位币编码</returns>
        public static string GetCurCoin()
        {
            string sCurCoin = "";       //当前本位币编码.

            string err = ""; //错误信息返回参数.
            string sSql = "";           //查询树型数据所需的SQL语句.

            sSql += "select ";
            sSql += "b.coin_code ";
            sSql += "from t_coin_convert a "; //本位币表.
            sSql += "inner join t_cointype b on a.coin_convertcur_id=b.coin_id ";

            sCurCoin = dbAccess.GetString(sSql, out err);
            return sCurCoin;
        }

        /// <summary>
        /// 取得当前本位币名称.
        /// </summary>
        /// <returns>返回当前本位币名称</returns>
        public static string GetCurCoinName()
        {
            string sCurCoinName = "";       //当前本位币名称.

            string err = ""; //错误信息返回参数.
            string sSql = "";           //查询树型数据所需的SQL语句.

            sSql += "select ";
            sSql += "b.coin_name ";
            sSql += "from t_coin_convert a "; //本位币表.
            sSql += "inner join t_cointype b on a.coin_convertcur_id=b.coin_id ";

            sCurCoinName = dbAccess.GetString(sSql, out err);
            return sCurCoinName;
        }

        /// <summary>
        /// 取得指定币种Id的币种名称.
        /// </summary>
        /// <param name="coinId">币种Id</param>
        /// <returns>返回币名称</returns>
        public static string GetCoinName(string coinId)
        {
            string sCoinName = "";      //币种名称.
            string err = ""; //错误信息返回参数.
            string sSql = "";           //查询树型数据所需的SQL语句.

            sSql += "select ";
            sSql += "coin_name ";
            sSql += "from t_cointype  "; //本位币表.
            sSql += "where coin_id = '" + coinId + "'";

            sCoinName = dbAccess.GetString(sSql, out err);
            return sCoinName;
        }

        /// <summary>
        /// 取得工作报告类型.
        /// </summary>
        /// <param name="sWhere">查询信息的Where条件</param>
        /// <returns>返回一个DataTable对象</returns>
        public static DataTable GetMearsureType(string sWhere)
        {
            DataTable dtb;//定义一个DataTable对象.
            string err = "";     //错误信息返回参数.
            string sSql = "";               //查询树型数据所需的SQL语句.

            sSql += "select measure_report_type_id,ship_id,";  //主键.
            sSql += "measure_report_type_name ";
            sSql += "from t_measure_report_type "; //工作报告类型.
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
        /// 取得当前币种转换成当前本位币后的汇率.
        /// </summary>
        /// <param name="coinTypeId">当前币种Id</param>
        /// <returns>返回当前币种转换成当前本位币后的汇率</returns>
        public static float GetCurRate(string coinTypeId)
        {
            string err = ""; //错误信息返回参数.
            string sCurCoinId = "";     //当前本位币Id
            string scurRate = "";       //当前汇率（字符型）.

            float fcurRate = 0.0f;      //当前汇率（数值型）.

            string sSqlBwb = "";        //查询当前本位币Id的SQL语句.
            string sSqlRate = "";       //查询当前汇率的SQL语句.

            //查询当前本位币Id
            sSqlBwb += "select ";
            sSqlBwb += "coin_convertcur_id ";
            sSqlBwb += "from t_coin_convert"; //本位币表.
            sCurCoinId = dbAccess.GetString(sSqlBwb, out err);

            //查询当前汇率.
            sSqlRate += "select ";
            sSqlRate += "rate ";
            sSqlRate += "from t_coin_rate "; //汇率表.

            sSqlRate += "where originalcoin_id = '" + coinTypeId + "' ";
            sSqlRate += "and convertcoin_id = '" + sCurCoinId + "' ";

            scurRate = dbAccess.GetString(sSqlRate, out err);
            if (scurRate.Length > 0)
            {
                fcurRate = float.Parse(scurRate);
            }

            return fcurRate;
        }

        /// <summary>
        /// 取得当前币种按照汇率转换成本位币后的金额.
        /// </summary>
        /// <param name="coinTypeId">当前币种Id</param>
        /// <param name="curSum">当前金额</param>
        /// <returns>返回当前币种按照汇率转换成本位币后的金额</returns>
        public static float GetRateSum(string coinTypeId, float curSum)
        {
            string err = ""; //错误信息返回参数.
            string sCurCoinId = "";     //当前本位币Id
            string scurRate = "";         //当前汇率（字符型）.

            float fcurRate = 0.0f;      //当前汇率（数值型）.

            string sSqlBwb = "";        //查询当前本位币Id的SQL语句.
            string sSqlRate = "";       //查询当前汇率的SQL语句.
            float convertSum = 0.0f;    //转换成本位币后的金额.

            //查询当前本位币Id
            sSqlBwb += "select ";
            sSqlBwb += "coin_convertcur_id ";
            sSqlBwb += "from t_coin_convert"; //本位币表.
            sCurCoinId = dbAccess.GetString(sSqlBwb, out err);

            //查询当前汇率.
            sSqlRate += "select ";
            sSqlRate += "rate ";
            sSqlRate += "from t_coin_rate "; //汇率表.

            sSqlRate += "where originalcoin_id = '" + coinTypeId + "' ";
            sSqlRate += "and convertcoin_id = '" + sCurCoinId + "' ";

            scurRate = dbAccess.GetString(sSqlRate, out err);
            if (scurRate.Length > 0)
            {
                fcurRate = float.Parse(scurRate);
            }

            convertSum = curSum * fcurRate;
            return convertSum;
        }
    }
}