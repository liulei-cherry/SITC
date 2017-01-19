/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：HOilService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-7-25
 * 标    题：数据操作类
 * 功能描述：T_HOIL数据操作类
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
using Oil.DataObject;

namespace Oil.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_HOILService.cs
    /// </summary>
    public partial class HOilService
    {
        /// <summary>
        /// 得到油品的类型.
        /// </summary>
        /// <returns>T_HOIL DataTable</returns>
        public DataTable getOilType(out string err)
        {
            sql = "select * from (select '2' as ID,'滑油' as name union	"
                + "\rselect '1' as ID,'轻油' as name union"
                + "\rselect '0' as ID,'重油' as name from T_SHIP) t order by ID";
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
        /// 得到润滑油的类型.
        /// </summary>
        /// <returns>T_HOIL DataTable</returns>
        public DataTable getLOilType(out string err)
        {
            sql = "select '0' as ID,'主机气缸油' as name union	"
                + "\rselect '1' as ID,'主机系统油' as name union"
                + "\rselect '2' as ID,'副机系统油' as name union"
                + "\rselect '3' as ID,'其它' as name ";
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
        /// 得到燃油的类型.
        /// </summary>
        public DataTable getFuelOilType(out string err)
        {
            sql = "select 'A' as ID,'重油' as name union"
                + "\rselect 'B' as ID,'轻油' as name";
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
        /// 得到燃油的消耗类型.
        /// </summary>
        public DataTable getFuelOilConsumeType(out string err)
        {
            sql = "select 'A' as ID,'主机' as name "
            + "\runion select 'B' as ID,'副机' as name"
            + "\runion select 'C' as ID,'锅炉' as name";

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

        public DataTable getOilBrand(out string err)
        {

            sql = "select distinct OIL_NAME from t_hoil order by OIL_NAME";

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
        /// 得到审核的类型.
        /// </summary>
        public DataTable getCheckType(out string err)
        {
            sql = "select '全部' as ID,'全部' as name,'0' as ordernum union"
                + "\rselect '1' as ID,'审核中' as name,'1' as ordernum union"
                + "\rselect '0' as ID,'未提交' as name,'2' as ordernum union"
                + "\rselect '2' as ID,'已批准' as name,'3' as ordernum union"
                + "\rselect '9' as ID,'已订购' as name,'4' as ordernum order by ordernum";
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
        /// 得到  T_HOIL 所有数据信息.
        /// </summary>
        /// <returns>T_HOIL DataTable</returns>
        public DataTable getOilInfo(out string err)
        {
            sql = "select OIL_ID,TRADEMARK,OIL_NAME,(OIL_NAME + ' ' + TRADEMARK) as OIL_FULL_NAME,OIL_CODE"
                + ",OIL_TYPE,case OIL_TYPE when '0' then '重油' when '1' then '轻油' when '2' then '润滑油' end  OIL_TYPE_NAME"
                + ",LOIL_TYPE,case LOIL_TYPE when '0' then '主机气缸油' when '1' then '主机系统油' when '2' then '副机系统油' when '3' then '其它' end  LOIL_TYPE_NAME"
                + ",ORDERNUM  from T_HOIL order by OIL_TYPE,LOIL_TYPE,ORDERNUM";
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
        /// 得到  T_HOIL 所有数据信息.
        /// </summary>
        /// <returns>T_HOIL DataTable</returns>
        public DataTable getOilInfoNotSelectedToOneShip(string shipId, out string err)
        {
            sql = "select a.OIL_ID,TRADEMARK,OIL_NAME,(OIL_NAME + ' ' + TRADEMARK) as OIL_FULL_NAME,OIL_CODE"
                + ",OIL_TYPE,case OIL_TYPE when '0' then '重油' when '1' then '轻油' when '2' then '润滑油' end  OIL_TYPE_NAME"
                + ",LOIL_TYPE,case LOIL_TYPE when '0' then '主机气缸油' when '1' then '主机系统油' when '2' then '副机系统油' when '3' then '其它' end  LOIL_TYPE_NAME"
                + ",a.ORDERNUM  from T_HOIL a left join T_HOil_Ship b on a.OIL_ID = b.OIL_ID and b.ship_id = '" + shipId + "'"
                + "\rwhere b.OIL_ID is null order by a.OIL_TYPE,a.LOIL_TYPE,a.ORDERNUM";
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
        /// 得到  T_HOIL 所有数据信息.
        /// </summary>
        /// <returns>T_HOIL DataTable</returns>
        public DataTable getInfoEx(out string err)
        {
            sql = "select OIL_ID,OIL_NAME,TRADEMARK,OIL_CODE"
                + ",case OIL_TYPE when '0' then '重油' when '1' then '轻油' when '2' then '润滑油' end  OIL_TYPE_NAME"
                + ",case LOIL_TYPE when '0' then '主机气缸油' when '1' then '主机系统油' when '2' then '副机系统油' when '3' then '其它' end  LOIL_TYPE_NAME"
                + ",ORDERNUM  from T_HOIL order by OIL_TYPE,LOIL_TYPE,ORDERNUM";
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
        /// 取得为指定船舶所分配的润滑油信息.
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetShipLubOil(string shipId)
        {

            string err = "";         //错误信息返回参数.
            sql = "select a.Oil_Id,(b.OIL_NAME + ' ' + b.TRADEMARK) as OIL_FULL_NAME, b.OIL_NAME,"
             + "OIL_TYPE,case OIL_TYPE when '0' then '重油' when '1' then '轻油' when '2' then '润滑油' end  OIL_TYPE_NAME,"
             + "a.Ship_Id,a.ForWhichType,a.ORDERNUM,(a.ForWhichType + '('+ b.TRADEMARK + ')') as ON_SHIP_USE  "
             + "\rfrom T_HOil_Ship a "
             + "\rinner join T_HOil b on a.Oil_Id = b.Oil_Id "
             + "\rwhere a.Ship_Id = '" + shipId + "' and b.OIL_TYPE = '2' order by a.ORDERNUM,b.ORDERNUM ";

            DataTable dtb = null;    //定义一个DataTable对象.
            if (dbAccess.GetDataTable(sql, out dtb, out err))
            {
                return dtb;
            }
            else
            {
                throw new Exception(err);
            }
        }

        /// <summary>
        /// 取得为指定船舶所分配的油品信息.
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetShipOil(string shipId)
        {

            string err = "";         //错误信息返回参数.

            sql = "select a.OIL_SHIP_ID,a.Oil_Id, (b.OIL_NAME +' '+ b.TRADEMARK) as OIL_FULL_NAME,b.OIL_NAME,"
               + "b.OIL_TYPE,case OIL_TYPE when '0' then '重油' when '1' then '轻油' when '2' then '润滑油' end  OIL_TYPE_NAME,"
               + "a.Ship_Id,a.ForWhichType,a.ORDERNUM  "
               + "\rfrom T_HOil_Ship a "
               + "\rinner join T_HOil b on a.Oil_Id = b.Oil_Id "
               + "\rwhere a.Ship_Id = '" + shipId + "' order by b.OIL_TYPE,b.LOIL_TYPE ";

            DataTable dtb = null;    //定义一个DataTable对象.
            if (dbAccess.GetDataTable(sql, out dtb, out err))
            {
                return dtb;
            }
            else
            {
                throw new Exception(err);
            }
        }

        /// <summary>
        /// 保存为指定船舶选择的油品信息.
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <param name="lstOilIds">包含选择的油品Id的List泛型集合</param>
        /// <param name="sMidErrMessage">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public void SaveShipOil(string shipId, List<string> lstOilIds, out string sMidErrMessage)
        {
            List<string> lstSqlOpt = new List<string>();//包含操作语句的List泛型集合.
            string sSqlDel = "";    //删除的SQL语句.
            string sSqlInt = "";    //添加的SQL语句.

            //在添加前先删除为指定船舶shipId分配所有油品Id信息.
            sSqlDel = "delete from T_HOil_Ship where ship_Id = '" + shipId + "'";
            lstSqlOpt.Add(sSqlDel);

            //循环泛型集合lstOilIds中的每个选择的油品Id，然后组成一个Insert语句.
            //放到操作集合中去。.
            int i = 1;
            foreach (string oilId in lstOilIds)
            {
                sSqlInt = "insert into T_HOil_Ship(Oil_Ship_Id, Oil_Id, Ship_Id,ORDERNUM) ";
                sSqlInt += "values('" + Guid.NewGuid().ToString() + "','" + oilId + "',";
                sSqlInt += "'" + shipId + "','" + i.ToString() + "')";
                i++;
                lstSqlOpt.Add(sSqlInt);
            }

            //调用dbAccess的execSql执行lstSqlOpt中的所有的操作语句.
            dbAccess.ExecSql(lstSqlOpt, out sMidErrMessage);
        }

        /// <summary>
        /// 取得油品信息所指定的船舶.
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetOilBelongShip(string Oil_Id)
        {

            string err = "";         //错误信息返回参数.

            sql = "select a.OIL_SHIP_ID,a.Oil_Id, (b.OIL_NAME +' '+ b.TRADEMARK) as OIL_FULL_NAME,b.OIL_NAME,"
               + "b.OIL_TYPE,case OIL_TYPE when '0' then '重油' when '1' then '轻油' when '2' then '润滑油' end  OIL_TYPE_NAME,"
               + "a.Ship_Id,a.ForWhichType,a.ORDERNUM  "
               + "\rfrom T_HOil_Ship a "
               + "\rinner join T_HOil b on a.Oil_Id = b.Oil_Id "
               + "\rwhere a.Oil_Id = '" + Oil_Id + "' order by b.OIL_TYPE,b.LOIL_TYPE ";

            DataTable dtb = null;    //定义一个DataTable对象.
            if (dbAccess.GetDataTable(sql, out dtb, out err))
            {
                return dtb;
            }
            else
            {
                throw new Exception(err);
            }
        }
    }
}
