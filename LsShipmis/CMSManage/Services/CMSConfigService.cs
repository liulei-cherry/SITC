/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：CMSConfigService.cs
 * 创 建 人：徐正本
 * 创建时间：2012-3-3
 * 标    题：数据操作类
 * 功能描述：T_CMS_CONFIG数据操作类
 * Codesmith DataAccessLayer.cst 1.02版本生成
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
using CMSManage.DataObject;

namespace CMSManage.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_CMS_CONFIGService.cs
    /// </summary>
    public partial class CMSConfigService : IObjectsService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static CMSConfigService instance = new CMSConfigService();
        public static CMSConfigService Instance
        {
            get
            {
                if (null == instance)
                {
                    CMSConfigService.instance = new CMSConfigService();
                }
                return CMSConfigService.instance;
            }
        }
        private CMSConfigService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">CMSConfig对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(CMSConfig unit, out string err)
        {
            if (unit.CMS_CONFIG_ID != null && unit.CMS_CONFIG_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_CMS_CONFIG] SET "
                    + " [CMS_CONFIG_ID] = " + (string.IsNullOrEmpty(unit.CMS_CONFIG_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.CMS_CONFIG_ID) + "'")
                    + " , [CHECKTITLE] = " + (unit.CHECKTITLE == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.CHECKTITLE) + "'")
                    + " , [CMSCODE] = " + (unit.CMSCODE == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.CMSCODE) + "'")
                    + " , [WORKINFOID] = " + (string.IsNullOrEmpty(unit.WORKINFOID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.WORKINFOID) + "'")
                    + " , [CHECKDETAIL] = " + (unit.CHECKDETAIL == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.CHECKDETAIL) + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIP_ID) + "'")
                    + " , [CHECKENGLISHNAME] = " + (unit.CHECKENGLISHNAME == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.CHECKENGLISHNAME) + "'")
                    + " , [SortNo] = " + unit.SortNo.ToString()
                    + "\rwhere CMS_CONFIG_ID = '" + dbOperation.ReplaceSqlKeyStr(unit.CMS_CONFIG_ID) + "'";
            }
            else
            {
                unit.CMS_CONFIG_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_CMS_CONFIG] ("
                    + "[CMS_CONFIG_ID],"
                    + "[CHECKTITLE],"
                    + "[CMSCODE],"
                    + "[WORKINFOID],"
                    + "[CHECKDETAIL],"
                    + "[SHIP_ID],"
                    + "[CHECKENGLISHNAME],"
                    + "[SortNo]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.CMS_CONFIG_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.CMS_CONFIG_ID) + "'")
                    + " , " + (unit.CHECKTITLE == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.CHECKTITLE) + "'")
                    + " , " + (unit.CMSCODE == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.CMSCODE) + "'")
                    + " , " + (string.IsNullOrEmpty(unit.WORKINFOID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.WORKINFOID) + "'")
                    + " , " + (unit.CHECKDETAIL == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.CHECKDETAIL) + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIP_ID) + "'")
                    + " , " + (unit.CHECKENGLISHNAME == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.CHECKENGLISHNAME) + "'")
                    + " ," + unit.SortNo.ToString()
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_CMS_CONFIG中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_CMS_CONFIG对象</param>
        internal bool deleteUnit(CMSConfig unit, out string err)
        {
            return deleteUnit(unit.CMS_CONFIG_ID, out err);
        }

        /// <summary>
        /// 删除数据表T_CMS_CONFIG中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_CMS_CONFIG.cMS_CONFIG_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_CMS_CONFIG where CMS_CONFIG_ID='" + dbOperation.ReplaceSqlKeyStr(unitid) + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_CMS_CONFIG 所有数据信息.
        /// </summary>
        /// <returns>T_CMS_CONFIG DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "CMS_CONFIG_ID,SortNo"
                + ",CHECKTITLE,CHECKENGLISHNAME"
                + ",CMSCODE"
                + ",WORKINFOID"
                + ",CHECKDETAIL"
                + ",SHIP_ID"
                + ",CHECKENGLISHNAME"
                + ",SortNo"
                + "\rfrom T_CMS_CONFIG ";
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
        /// 根据一个主键ID,得到 T_CMS_CONFIG 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>CMSConfig DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "CMS_CONFIG_ID,SortNo"
                + ",CHECKTITLE,CHECKENGLISHNAME"
                + ",CMSCODE"
                + ",WORKINFOID"
                + ",CHECKDETAIL"
                + ",SHIP_ID"
                + ",CHECKENGLISHNAME"
                + ",SortNo"
                + "\rfrom T_CMS_CONFIG "
                + "\rwhere CMS_CONFIG_ID='" + dbOperation.ReplaceSqlKeyStr(Id) + "'";
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
        /// 根据cmsconfig 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>cmsconfig 数据实体</returns>
        public CMSConfig getObject(DataRow dr)
        {
            CMSConfig unit = new CMSConfig();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造CMSConfig类对象!";
                return unit;
            }
            if (DBNull.Value != dr["CMS_CONFIG_ID"])
                unit.CMS_CONFIG_ID = dr["CMS_CONFIG_ID"].ToString();
            if (DBNull.Value != dr["CHECKTITLE"])
                unit.CHECKTITLE = dr["CHECKTITLE"].ToString();
            if (DBNull.Value != dr["CMSCODE"])
                unit.CMSCODE = dr["CMSCODE"].ToString();
            if (DBNull.Value != dr["WORKINFOID"])
                unit.WORKINFOID = dr["WORKINFOID"].ToString();
            if (DBNull.Value != dr["CHECKDETAIL"])
                unit.CHECKDETAIL = dr["CHECKDETAIL"].ToString();
            if (DBNull.Value != dr["SHIP_ID"])
                unit.SHIP_ID = dr["SHIP_ID"].ToString();
            if (DBNull.Value != dr["CHECKENGLISHNAME"])
                unit.CHECKENGLISHNAME = dr["CHECKENGLISHNAME"].ToString();
            if (DBNull.Value != dr["SortNo"])
                unit.SortNo = Convert.ToDecimal(dr["SortNo"]);

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个CMSConfig对象.
        /// </summary>
        /// <param name="cMS_CONFIG_ID">cMS_CONFIG_ID</param>
        /// <returns>CMSConfig对象</returns>
        public CMSConfig getObject(string Id, out string err)
        {
            err = "";
            try
            {
                DataTable dt = getInfo(Id, out err);
                return getObject(dt.Rows[0]);
            }
            catch
            {
                return getObject(null);
            }
        }
        #endregion
        #region IObjectsService 成员

        public CommonOperation.BaseClass.CommonClass GetOneObjectById(string id)
        {
            string err;
            return getObject(id, out err);
        }

        public Dictionary<string, string> GetObjectDisplaySetting()
        {
            Dictionary<string, string> reValue = new Dictionary<string, string>();
            reValue.Add("SortNo", "项目序号");
            reValue.Add("CHECKTITLE", "检验项目(中文)");
            reValue.Add("CHECKENGLISHNAME", "检验项目(英文)");
            reValue.Add("CMSCODE", "CODE");
            reValue.Add("BANDWORKINFO", "关联工作信息");
            return reValue;
        }
        #endregion

        /// <summary>
        /// 得到  T_CMS_CONFIG 所有数据信息.
        /// </summary>
        /// <returns>T_CMS_CONFIG DataTable</returns>
        public DataTable getInfoOfShip(string shipId, out string err)
        {
            sql = "select	"
                + "CMS_CONFIG_ID,SortNo"
                + ",CHECKTITLE,CHECKENGLISHNAME"
                + ",CMSCODE"
                + ",WORKINFOID"
                + ",CHECKDETAIL"
                + ",SHIP_ID,case when len(isnull(WORKINFOID,''))>0 then 'Yes' else 'No' end BANDWORKINFO"
                + "\rfrom T_CMS_CONFIG"
                + (string.IsNullOrEmpty(shipId) ? "" : "\rwhere ship_id = '" + shipId.Replace("'", "''") + "'")
                + "\rorder by sortno,CMSCODE,CHECKTITLE";
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

        public CMSConfig GetConfigByShipAndCMSCode(string shipId, string cmsCode)
        {
            string err;
            sql = "select "
               + "CMS_CONFIG_ID,SortNo"
               + ",CHECKTITLE,CHECKENGLISHNAME"
               + ",CMSCODE"
               + ",WORKINFOID"
               + ",CHECKDETAIL"
               + ",SHIP_ID"
               + " from T_CMS_CONFIG "
               + " where SHIP_ID='" + shipId + "' and CMSCODE = '" + cmsCode + "'";
            DataTable dt;
            if (dbAccess.GetDataTable(sql, out dt, out err) && dt.Rows.Count > 0)
            {
                return getObject(dt.Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public bool CMSCodeIsDuplicated(string title, string code, string shipid, string exceptId)
        {
            return dbOperation.ThisShipHaveThisData(title + code, shipid, "T_CMS_CONFIG", "CMS_CONFIG_ID", "CHECKTITLE + CMSCODE", exceptId);
        }

        internal bool DeleteAllConfigOfOneShip(string shipId, out string err)
        {
            sql = @"delete T_CMS_CONFIG where ship_id = '" + shipId + "'";
            return dbAccess.ExecSql(sql, out err);
        }
    }
}
