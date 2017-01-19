/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：CompTypeSpareService.cs
 * 创 建 人：XuRongxia
 * 创建时间：2009-12-9
 * 标    题：数据操作类
 * 功能描述：T_COMPONENTTYPE_SPARE数据操作类
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
using BaseInfo.Objects;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using ItemsManage.DataObject;

namespace ItemsManage.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_COMPONENTTYPE_SPAREService.cs
    /// </summary>
    public partial class CompTypeSpareService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static CompTypeSpareService instance = new CompTypeSpareService();
        public static CompTypeSpareService Instance
        {
            get
            {
                if (null == instance)
                {
                    CompTypeSpareService.instance = new CompTypeSpareService();
                }
                return CompTypeSpareService.instance;
            }
        }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";
     
        internal bool DeleteUnit(string componentTypeId, string spareId, out string err)
        {
            //string comptypespareId = Guid.NewGuid().ToString();
            //string creator = CommonOperation.ConstParameter.UserName;
            //sSqlOpt += "insert into t_componenttype_spare(comptypespareid,component_type_id,spare_id,creator)";
            //sSqlOpt += "values('" + comptypespareId + "','" + componentTypeId + "','" + spareId + "','" + creator + "')";
            //lstSqlOpt.Add(sSqlOpt);

            sql = "delete from t_componenttype_spare where component_type_id = '" + componentTypeId.Replace ("'","''") + "' ";
            sql += "and spare_id = '" + spareId.Replace("'","''") + "'"; 

            //调用dbAccess的execSql执行sSql中的所有的操作语句.
            return dbAccess.ExecSql(sql, out err);
        }
        internal bool AddUnit(string componentTypeId, string spareId, out string err)
        {
            return AddUnit(componentTypeId, spareId, 0, out err);
        }
        internal bool AddUnit(string componentTypeId, string spareId,int makeupNumber, out string err)
        {
            string comptypespareId = Guid.NewGuid().ToString();
            string creator = CommonOperation.ConstParameter.UserName;
            err = "";
            sql = "select count(1) from t_componenttype_spare where component_type_id='" + componentTypeId + "' and spare_id ='" + spareId + "'";
            if (dbAccess.GetString(sql) == "0")
            {
                sql = "insert into t_componenttype_spare(comptypespareid,component_type_id,spare_id, MAKEUPNUMBER,creator)";
                sql += "values('" + comptypespareId + "','" + componentTypeId + "','" + spareId + "'," + makeupNumber.ToString() + ", '" + creator + "')";

                //调用dbAccess的execSql执行sSql中的所有的操作语句.
                return dbAccess.ExecSql(sql, out err);
            }
            else
            {
                sql = "update t_componenttype_spare set MAKEUPNUMBER =" + makeupNumber 
                    + "\rwhere component_type_id='" + componentTypeId + "' and spare_id ='" + spareId + "'";
                return dbAccess.ExecSql(sql, out err);
            } 
        }
    }
}
