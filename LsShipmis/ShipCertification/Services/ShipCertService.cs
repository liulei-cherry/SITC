/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：ShipCertService.cs
 * 创 建 人：徐正本
 * 创建时间：2011/8/31
 * 标    题：数据操作类
 * 功能描述：T_SHIP_CERT数据操作类
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

namespace ShipCertification.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_SHIP_CERTService.cs
    /// </summary>
    public partial class ShipCertService: IObjectsService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static ShipCertService instance = new ShipCertService();
        public static ShipCertService Instance
        {
            get
            {
                if (null == instance)
                {
                    ShipCertService.instance = new ShipCertService();
                }
                return ShipCertService.instance;
            }
        }
        private ShipCertService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">ShipCert对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(ShipCert unit, out string err)
        {
            if (unit.SHIP_CERT_ID != null && unit.SHIP_CERT_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_SHIP_CERT] SET "
                    + " [SHIP_CERT_ID] = " + (string.IsNullOrEmpty(unit.SHIP_CERT_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIP_CERT_ID) + "'")
                    + " , [SHIPCERTCODE] = " + (unit.SHIPCERTCODE == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIPCERTCODE) + "'")
                    + " , [SHIPCERTCHNAME] = " + (unit.SHIPCERTCHNAME == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIPCERTCHNAME) + "'")
                    + " , [SHIPCERTENNAME] = " + (unit.SHIPCERTENNAME == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIPCERTENNAME) + "'")
                    + " , [ALERTDAYS] = " + unit.ALERTDAYS.ToString()
                    + " , [EFFECTDATE] = " + unit.EFFECTDATE.ToString()
                    + " , [NEEDOUTPUT] = " + unit.NEEDOUTPUT.ToString()
                    + " , [AIMTOCONFIG] = " + (unit.AIMTOCONFIG == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.AIMTOCONFIG) + "'")
                    + " , [AIMTOCONFIGSHORT] = " + (unit.AIMTOCONFIGSHORT == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.AIMTOCONFIGSHORT) + "'")
                    + " , [REMARK] = N" + (unit.REMARK == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.REMARK) + "'")
                    + " , [SORTNO] = " + unit.SORTNO.ToString()
                    + "\rwhere SHIP_CERT_ID = '" + dbOperation.ReplaceSqlKeyStr(unit.SHIP_CERT_ID) + "'";
            }
            else
            {
                unit.SHIP_CERT_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_SHIP_CERT] ("
                    + "[SHIP_CERT_ID],"
                    + "[SHIPCERTCODE],"
                    + "[SHIPCERTCHNAME],"
                    + "[SHIPCERTENNAME],"
                    + "[ALERTDAYS],"
                    + "[EFFECTDATE],"
                    + "[NEEDOUTPUT],"
                    + "[AIMTOCONFIG],"
                    + "[AIMTOCONFIGSHORT],"
                    + "[REMARK],"
                    + "[SORTNO]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.SHIP_CERT_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIP_CERT_ID) + "'")
                    + " , " + (unit.SHIPCERTCODE == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIPCERTCODE) + "'")
                    + " , " + (unit.SHIPCERTCHNAME == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIPCERTCHNAME) + "'")
                    + " , " + (unit.SHIPCERTENNAME == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIPCERTENNAME) + "'")
                    + " ," + unit.ALERTDAYS.ToString()
                    + " ," + unit.EFFECTDATE.ToString()
                    + " ," + unit.NEEDOUTPUT.ToString()
                    + " , " + (unit.AIMTOCONFIG == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.AIMTOCONFIG) + "'")
                    + " , " + (unit.AIMTOCONFIGSHORT == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.AIMTOCONFIGSHORT) + "'")
                    + " , N" + (unit.REMARK == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.REMARK) + "'")
                    + " ," + unit.SORTNO.ToString()
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_SHIP_CERT中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_SHIP_CERT对象</param>
        internal bool deleteUnit(ShipCert unit, out string err)
        {
            return deleteUnit(unit.SHIP_CERT_ID, out err);
        }

        /// <summary>
        /// 删除数据表T_SHIP_CERT中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_SHIP_CERT.sHIP_CERT_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_SHIP_CERT where SHIP_CERT_ID='" + dbOperation.ReplaceSqlKeyStr(unitid) + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_SHIP_CERT 所有数据信息.
        /// </summary>
        /// <returns>T_SHIP_CERT DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "SHIP_CERT_ID"
                + ",SHIPCERTCODE"
                + ",SHIPCERTCHNAME"
                + ",SHIPCERTENNAME"
                + ",ALERTDAYS"
                + ",EFFECTDATE"
                + ",NEEDOUTPUT"
                + ",AIMTOCONFIG"
                + ",AIMTOCONFIGSHORT"
                + ",REMARK"
                + ",SORTNO"
                + "\rfrom T_SHIP_CERT order by sortno";
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
        /// 根据一个主键ID,得到 T_SHIP_CERT 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>ShipCert DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "SHIP_CERT_ID"
                + ",SHIPCERTCODE"
                + ",SHIPCERTCHNAME"
                + ",SHIPCERTENNAME"
                + ",ALERTDAYS"
                + ",EFFECTDATE"
                + ",NEEDOUTPUT"
                + ",AIMTOCONFIG"
                + ",AIMTOCONFIGSHORT"
                + ",REMARK"
                + ",SORTNO"
                + "\rfrom T_SHIP_CERT "
                + "\rwhere SHIP_CERT_ID='" + dbOperation.ReplaceSqlKeyStr(Id) + "'";
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
        /// 根据shipcert 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>shipcert 数据实体</returns>
        public ShipCert getObject(DataRow dr)
        {
            ShipCert unit = new ShipCert();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造ShipCert类对象!";
                return unit;
            }
            if (DBNull.Value != dr["SHIP_CERT_ID"])
                unit.SHIP_CERT_ID = dr["SHIP_CERT_ID"].ToString();
            if (DBNull.Value != dr["SHIPCERTCODE"])
                unit.SHIPCERTCODE = dr["SHIPCERTCODE"].ToString();
            if (DBNull.Value != dr["SHIPCERTCHNAME"])
                unit.SHIPCERTCHNAME = dr["SHIPCERTCHNAME"].ToString();
            if (DBNull.Value != dr["SHIPCERTENNAME"])
                unit.SHIPCERTENNAME = dr["SHIPCERTENNAME"].ToString();
            if (DBNull.Value != dr["ALERTDAYS"])
                unit.ALERTDAYS = Convert.ToDecimal(dr["ALERTDAYS"]);
            if (DBNull.Value != dr["EFFECTDATE"])
                unit.EFFECTDATE = Convert.ToDecimal(dr["EFFECTDATE"]);
            if (DBNull.Value != dr["NEEDOUTPUT"])
                unit.NEEDOUTPUT = Convert.ToDecimal(dr["NEEDOUTPUT"]);
            if (DBNull.Value != dr["AIMTOCONFIG"])
                unit.AIMTOCONFIG = dr["AIMTOCONFIG"].ToString();
            if (DBNull.Value != dr["AIMTOCONFIGSHORT"])
                unit.AIMTOCONFIGSHORT = dr["AIMTOCONFIGSHORT"].ToString();
            if (DBNull.Value != dr["REMARK"])
                unit.REMARK = dr["REMARK"].ToString();
            if (DBNull.Value != dr["SORTNO"])
                unit.SORTNO = Convert.ToInt32(dr["SORTNO"]);

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个ShipCert对象.
        /// </summary>
        /// <param name="sHIP_CERT_ID">sHIP_CERT_ID</param>
        /// <returns>ShipCert对象</returns>
        public ShipCert getObject(string Id, out string err)
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

        public CommonClass GetOneObjectById(string id)
        {

            string err;
            return getObject(id, out err);
        }

        public Dictionary<string, string> GetObjectDisplaySetting()
        {
            Dictionary<string, string> reValue = new Dictionary<string, string>();

            reValue.Add("SHIPCERTCODE", "船舶证书编码");
            reValue.Add("SHIPCERTCHNAME", "中文名称");
            reValue.Add("SHIPCERTENNAME", "英文名称");
            reValue.Add("EFFECTDATE", "默认周期(年)"); 
            
            return reValue;
        }

        #endregion     

        /// <summary>
        /// 得到所有证书的对象.
        /// </summary>
        /// <returns></returns>
        public List<ShipCert> GetAllReportCert()
        {
            List<ShipCert> re = new List<ShipCert>();
            string err;
            DataTable dt;
            try
            {
                dt = getInfo(out err);
            }
            catch (Exception e)
            {
                throw new Exception( "得到所有证书的对象时出错,\r错误信息为:" + e.Message);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                re.Add(getObject(dt.Rows[i]));
            }
            return re;   
        }
    }
}
