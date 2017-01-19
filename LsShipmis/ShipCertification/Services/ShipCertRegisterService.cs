/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：ShipCertRegisterService.cs
 * 创 建 人：徐正本
 * 创建时间：2011/8/31
 * 标    题：数据操作类
 * 功能描述：T_SHIP_CERT_REGISTER数据操作类
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
using ShipCertification.DataObject;
using CommonOperation.BaseClass;

namespace  ShipCertification.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_SHIP_CERT_REGISTERService.cs
    /// </summary>
    public partial class ShipCertRegisterService:IObjectsService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static ShipCertRegisterService instance = new ShipCertRegisterService();
        public static ShipCertRegisterService Instance
        {
            get
            {
                if (null == instance)
                {
                    ShipCertRegisterService.instance = new ShipCertRegisterService();
                }
                return ShipCertRegisterService.instance;
            }
        }
        private ShipCertRegisterService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">ShipCertRegister对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(ShipCertRegister unit, out string err)
        {
            if (unit.SHIP_CERT_REGISTERID != null && unit.SHIP_CERT_REGISTERID.Length > 0) //edit
            {
                sql = "UPDATE [T_SHIP_CERT_REGISTER] SET "
                    + " [SHIP_CERT_REGISTERID] = " + (string.IsNullOrEmpty(unit.SHIP_CERT_REGISTERID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIP_CERT_REGISTERID) + "'")
                    + " , [SHIP_CERT_ID] = " + (string.IsNullOrEmpty(unit.SHIP_CERT_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIP_CERT_ID) + "'")
                    + " , [SHIP_CERT_NAME] = " + (unit.SHIP_CERT_NAME == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIP_CERT_NAME) + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIP_ID) + "'")
                    + " , [SHIP_CERT_DEPARTID] = " + (string.IsNullOrEmpty(unit.SHIP_CERT_DEPARTID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIP_CERT_DEPARTID) + "'")
                    + " , [SHIPCERTTYPE] = " + unit.SHIPCERTTYPE.ToString()
                    + " , [SHIPCERTNUMB] = " + (unit.SHIPCERTNUMB == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIPCERTNUMB) + "'")
                    + " , [EFFECTDATE] = " + unit.EFFECTDATE.ToString()
                    + " , [SIGNEDDATE] = " + dbOperation.DbToDate(unit.SIGNEDDATE)
                    + " , [MATUREDATE] = " + dbOperation.DbToDate(unit.MATUREDATE)
                    + " , [ALERTDAYS] = " + unit.ALERTDAYS.ToString()
                    + " , [RECERTIFICATION] = " + unit.RECERTIFICATION.ToString()
                    + " , [REMARK] = " + (unit.REMARK == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.REMARK) + "'")
                    + " , [SORTNO] = " + unit.SORTNO.ToString()
                    + " , [PLACE] = " + (unit.PLACE == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.PLACE) + "'")
                    + " , [EXPIREDATE] = " + dbOperation.DbToDate(unit.EXPIREDATE)
                    + "\rwhere SHIP_CERT_REGISTERID = '" + dbOperation.ReplaceSqlKeyStr(unit.SHIP_CERT_REGISTERID) + "'";
            }
            else
            {
                unit.SHIP_CERT_REGISTERID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_SHIP_CERT_REGISTER] ("
                    + "[SHIP_CERT_REGISTERID],"
                    + "[SHIP_CERT_ID],"
                    + "[SHIP_CERT_NAME],"
                    + "[SHIP_ID],"
                    + "[SHIP_CERT_DEPARTID],"
                    + "[SHIPCERTTYPE],"
                    + "[SHIPCERTNUMB],"
                    + "[EFFECTDATE],"
                    + "[SIGNEDDATE],"
                    + "[MATUREDATE],"
                    + "[ALERTDAYS],"
                    + "[RECERTIFICATION],"
                    + "[REMARK],"
                    + "[SORTNO],"
                    + "[PLACE],"
                    + "[EXPIREDATE]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.SHIP_CERT_REGISTERID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIP_CERT_REGISTERID) + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_CERT_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIP_CERT_ID) + "'")
                    + " , " + (unit.SHIP_CERT_NAME == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIP_CERT_NAME) + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIP_ID) + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_CERT_DEPARTID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIP_CERT_DEPARTID) + "'")
                    + " ," + unit.SHIPCERTTYPE.ToString()
                    + " , " + (unit.SHIPCERTNUMB == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIPCERTNUMB) + "'")
                    + " ," + unit.EFFECTDATE.ToString()
                    + " ," + dbOperation.DbToDate(unit.SIGNEDDATE)
                    + " ," + dbOperation.DbToDate(unit.MATUREDATE)
                    + " ," + unit.ALERTDAYS.ToString()
                    + " ," + unit.RECERTIFICATION.ToString()
                    + " , " + (unit.REMARK == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.REMARK) + "'")
                    + " ," + unit.SORTNO.ToString()
                    + " , " + (unit.PLACE == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.PLACE) + "'")
                    + " ," + dbOperation.DbToDate(unit.EXPIREDATE)
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_SHIP_CERT_REGISTER中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_SHIP_CERT_REGISTER对象</param>
        internal bool deleteUnit(ShipCertRegister unit, out string err)
        {
            return deleteUnit(unit.SHIP_CERT_REGISTERID, out err);
        }

        /// <summary>
        /// 删除数据表T_SHIP_CERT_REGISTER中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_SHIP_CERT_REGISTER.sHIP_CERT_REGISTERID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_SHIP_CERT_REGISTER where SHIP_CERT_REGISTERID='" + dbOperation.ReplaceSqlKeyStr(unitid) + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_SHIP_CERT_REGISTER 所有数据信息.
        /// </summary>
        /// <returns>T_SHIP_CERT_REGISTER DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "SHIP_CERT_REGISTERID"
                + ",SHIP_CERT_ID"
                + ",SHIP_CERT_NAME"
                + ",SHIP_ID"
                + ",SHIP_CERT_DEPARTID"
                + ",SHIPCERTTYPE"
                + ",SHIPCERTNUMB"
                + ",EFFECTDATE"
                + ",SIGNEDDATE"
                + ",MATUREDATE"
                + ",ALERTDAYS"
                + ",RECERTIFICATION"
                + ",REMARK"
                + ",SORTNO"
                + ",PLACE"
                + ",EXPIREDATE"
                + "\rfrom T_SHIP_CERT_REGISTER order by sortno ";
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
        /// 根据一个主键ID,得到 T_SHIP_CERT_REGISTER 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>ShipCertRegister DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "SHIP_CERT_REGISTERID"
                + ",SHIP_CERT_ID"
                + ",SHIP_CERT_NAME"
                + ",SHIP_ID"
                + ",SHIP_CERT_DEPARTID"
                + ",SHIPCERTTYPE"
                + ",SHIPCERTNUMB"
                + ",EFFECTDATE"
                + ",SIGNEDDATE"
                + ",MATUREDATE"
                + ",ALERTDAYS"
                + ",RECERTIFICATION"
                + ",REMARK"
                + ",SORTNO"
                + ",PLACE"
                + ",EXPIREDATE"
                + "\rfrom T_SHIP_CERT_REGISTER "
                + "\rwhere SHIP_CERT_REGISTERID='" + dbOperation.ReplaceSqlKeyStr(Id) + "'";
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
        /// 根据shipcertregister 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>shipcertregister 数据实体</returns>
        public ShipCertRegister getObject(DataRow dr)
        {
            ShipCertRegister unit = new ShipCertRegister();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造ShipCertRegister类对象!";
                return unit;
            }
            if (DBNull.Value != dr["SHIP_CERT_REGISTERID"])
                unit.SHIP_CERT_REGISTERID = dr["SHIP_CERT_REGISTERID"].ToString();
            if (DBNull.Value != dr["SHIP_CERT_ID"])
                unit.SHIP_CERT_ID = dr["SHIP_CERT_ID"].ToString();
            if (DBNull.Value != dr["SHIP_CERT_NAME"])
                unit.SHIP_CERT_NAME = dr["SHIP_CERT_NAME"].ToString();
            if (DBNull.Value != dr["SHIP_ID"])
                unit.SHIP_ID = dr["SHIP_ID"].ToString();
            if (DBNull.Value != dr["SHIP_CERT_DEPARTID"])
                unit.SHIP_CERT_DEPARTID = dr["SHIP_CERT_DEPARTID"].ToString();
            if (DBNull.Value != dr["SHIPCERTTYPE"])
                unit.SHIPCERTTYPE = Convert.ToDecimal(dr["SHIPCERTTYPE"]);
            if (DBNull.Value != dr["SHIPCERTNUMB"])
                unit.SHIPCERTNUMB = dr["SHIPCERTNUMB"].ToString();
            if (DBNull.Value != dr["EFFECTDATE"])
                unit.EFFECTDATE = Convert.ToDecimal(dr["EFFECTDATE"]);
            if (DBNull.Value != dr["SIGNEDDATE"])
                unit.SIGNEDDATE = (DateTime)dr["SIGNEDDATE"];
            if (DBNull.Value != dr["MATUREDATE"])
                unit.MATUREDATE = (DateTime)dr["MATUREDATE"];
            if (DBNull.Value != dr["ALERTDAYS"])
                unit.ALERTDAYS = Convert.ToDecimal(dr["ALERTDAYS"]);
            if (DBNull.Value != dr["RECERTIFICATION"])
                unit.RECERTIFICATION = Convert.ToDecimal(dr["RECERTIFICATION"]);
            if (DBNull.Value != dr["REMARK"])
                unit.REMARK = dr["REMARK"].ToString();
            if (DBNull.Value != dr["SORTNO"])
                unit.SORTNO = Convert.ToInt32(dr["SORTNO"]);
            if (DBNull.Value != dr["PLACE"])
                unit.PLACE = dr["PLACE"].ToString();
            if (DBNull.Value != dr["EXPIREDATE"])
                unit.EXPIREDATE = (DateTime)dr["EXPIREDATE"];

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个ShipCertRegister对象.
        /// </summary>
        /// <param name="sHIP_CERT_REGISTERID">sHIP_CERT_REGISTERID</param>
        /// <returns>ShipCertRegister对象</returns>
        public ShipCertRegister getObject(string Id, out string err)
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

        public bool HaveNotTheCert(string shipId, string CertId,string shipCertRegester)
        {
            if (shipId.Length != 36 || CertId.Length != 36) return true;

            string sql = "select count(1) from T_SHIP_CERT_REGISTER " +
                     "\r where SHIP_ID = '" + shipId.Replace("'", "''") + "' " +
                    " and SHIP_CERT_ID = '" + CertId.Replace("'", "''") + "' " +
                    (string.IsNullOrEmpty (shipCertRegester)?"": " and SHIP_CERT_REGISTERID <> '" + shipCertRegester.Replace("'", "''") + "' " )+
                    " and SHIPCERTTYPE != 4";
            return (dbAccess.GetString(sql) == "0");
        }

        #region IObjectsService 成员

        public CommonClass GetOneObjectById(string id)
        {

            string err;
            return getObject(id, out err);
        }

        public Dictionary<string, string> GetObjectDisplaySetting()
        {
            Dictionary<string, string> reValue = new Dictionary<string, string>();

            reValue.Add("SHIP_CERT_NAME", "证书名称");        
            reValue.Add("SHIPCERTNUMB", "证书号码");
            reValue.Add("SIGNEDDATE", "签发日期");
            reValue.Add("MATUREDATE", "到期日期");
            return reValue;
        }

        #endregion

    }
}
