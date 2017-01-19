using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ShipCertification.DataObject;

namespace ShipCertification.Services
{
    partial class ShipCertRegisterService
    {
        public DataTable GetAllShipCertificationOfShip(string shipId)
        {
            DataTable dtRe;
            string err;
            sql = "select SHIP_CERT_REGISTERID, t2.SHIP_NAME, case when t1.EFFECTDATE = 0 or t1.MATUREDATE > '2048-1-1' then null else  dateadd(day,-1 * t1.ALERTDAYS,t1.MATUREDATE) end alertdate, "
                + "case when t1.MATUREDATE > '2048-1-1' then null else t1.MATUREDATE  end MATUREDATE,t1.SHIP_CERT_NAME, SIGNEDDATE ,"
                + "case when t1.EXPIREDATE > '2048-1-1' then null else t1.EXPIREDATE  end enddate,t1.SHIPCERTNUMB,t1.EFFECTDATE,t1.PLACE,t4.SHIPCERTDEPARTNAME"
                + "\rfrom T_SHIP_CERT_REGISTER t1 inner join t_ship t2 on t1.ship_id = t2.ship_id "
                + "\r  left join T_SHIP_CERT t3 on t1.SHIP_CERT_ID = t3.SHIP_CERT_ID"
                + "\r left join T_SHIP_CERT_DEPART t4 on t1.SHIP_CERT_DEPARTID = t4.SHIP_CERT_DEPARTID"
                + "\rwhere t1.SHIPCERTTYPE <> 4 ";
            if (string.IsNullOrEmpty(shipId))
            {
                sql += "\rorder by isnull(t3.sortno,10000),t1.sortno";
            }
            else
            {
                sql += "\rand t2.SHIP_ID = '" + dbOperation.ReplaceSqlKeyStr(shipId) + "' \r order by isnull(t3.sortno,10000),t1.sortno";
            }
            if (dbAccess.GetDataTable(sql, out dtRe, out err))
            {
                return dtRe;
            }
            else
            {
                throw new Exception("获取船舶证书相关信息时出错,错误信息为:" + err);
            }
        }

        public List<ShipCertRegister> GetAllShipCertificationListOfShip(string shipId)
        {
            List<ShipCertRegister> lstRe = new List<ShipCertRegister>();
            string err = "";
            DataTable dtRe = GetAllShipCertificationOfShip(shipId);
            //如果没有获取到,肯定就抛出异常了,这里不用处理.
            foreach (DataRow dr in dtRe.Rows)
            {
                lstRe.Add(getObject(dr["SHIP_CERT_REGISTERID"].ToString(), out err));
            }
            return lstRe;
        }

        public bool FinishOrAbolishAShipCert(string certId, out string err)
        {
            if (certId == null || certId.Length != 36)
            {
                err = "调用停止或者作废一个船舶证书时，传入的证书的主键无效";
                return false;
            }
            sql = "update T_SHIP_CERT_REGISTER set SHIPCERTTYPE =4 where SHIP_CERT_REGISTERID = '" + certId +"'";
            return dbAccess.ExecSql(sql, out err);
        }

        public DataTable GetAllShipCertificationOfAbolished()
        {
            DataTable dtRe;

            string err;
            sql = "select tt1.ship_id,tt1.ship_cert_id from"
                + "\r(select ship_id,ship_cert_id from T_SHIP_CERT_REGISTER)tt1"
                + "\rleft join "
                + "\r(select t2.ship_id,t3.ship_cert_id "
                + "\rfrom T_SHIP_CERT_REGISTER t1 inner join t_ship t2 on t1.ship_id = t2.ship_id"
                + "\rleft join T_SHIP_CERT t3 on t1.SHIP_CERT_ID = t3.SHIP_CERT_ID"
                + "\rwhere t1.SHIPCERTTYPE <> 4 "
                + "\rgroup by t2.ship_id,t3.ship_cert_id) tt2"
                + "\ron tt1.ship_id= tt2.ship_id and tt1.ship_cert_id = tt2.ship_cert_id"
                + "\rwhere tt2.ship_id is null and tt1.ship_cert_id is not null and tt1.ship_cert_id <> ''";
            if (dbAccess.GetDataTable(sql, out dtRe, out err))
            {
                return dtRe;
            }
            else
            {
                throw new Exception("获取船舶证书相关信息时出错,错误信息为:" + err);
            }
        }
      
        public DataTable GetAllShipCertificationOfShipAndCert(string shipId, string certId,bool allData)
        { 
            DataTable dtRe;
            string err;
            sql = "select t2.SHIP_ID,t2.SHIP_NAME,t3.SHIP_CERT_ID,t1.SHIP_CERT_NAME,max(t1.SIGNEDDATE) SIGNEDDATE"
                + "\rfrom T_SHIP_CERT_REGISTER t1 inner join t_ship t2 on t1.ship_id = t2.ship_id "
                + "\r  left join T_SHIP_CERT t3 on t1.SHIP_CERT_ID = t3.SHIP_CERT_ID"
                + "\rwhere 1=1 " + (allData ? "" : "and t1.SHIPCERTTYPE <> 4 ");

            if (!string.IsNullOrEmpty(shipId)) sql += "\rand t2.ship_id = '" + shipId + "'";
            if (!string.IsNullOrEmpty(certId)) sql += "\rand t3.SHIP_CERT_ID = '" + certId + "'";

            sql += "\rgroup by t2.SHIP_ID,t2.SHIP_NAME,t3.SHIP_CERT_ID,t1.SHIP_CERT_NAME,t1.sortno,t3.sortno"
                + "\rorder by t2.SHIP_NAME,isnull(t3.sortno,10000),t1.sortno";

            if (dbAccess.GetDataTable(sql, out dtRe, out err))
            {
                return dtRe;
            }
            else
            {
                throw new Exception("获取船舶证书相关信息时出错,错误信息为:" + err);
            }
        }

        public DataTable GetAllShipCertificationHisOfShipAndCert(string shipId,string certId)
        {
            DataTable dtRe;
            string err;
            sql = "select SHIP_CERT_REGISTERID, t2.SHIP_NAME,dateadd(day,-1 * t1.ALERTDAYS,t1.MATUREDATE) alertdate, "
                + "t1.MATUREDATE,t1.SHIP_CERT_NAME,t1.SIGNEDDATE,t1.EXPIREDATE enddate,"
                + "t1.EFFECTDATE,t4.SHIPCERTDEPARTNAME,case t1.recertification when 0 then '签名盖章'else '换发新证' end certType,t1.remark"
                + "\rfrom T_SHIP_CERT_REGISTER t1 inner join t_ship t2 on t1.ship_id = t2.ship_id "
                + "\r  left join T_SHIP_CERT t3 on t1.SHIP_CERT_ID = t3.SHIP_CERT_ID"
                + "\r left join T_SHIP_CERT_DEPART t4 on t1.SHIP_CERT_DEPARTID = t4.SHIP_CERT_DEPARTID"
                + "\rwhere t1.SHIPCERTTYPE = 4 ";

            if (!string.IsNullOrEmpty(shipId)) sql += "\rand t2.ship_id = '" + shipId + "'";
            if (!string.IsNullOrEmpty(certId)) sql += "\rand t3.SHIP_CERT_ID = '" + certId + "'";

            sql += "\rorder by t2.SHIP_NAME,t1.sortno,t1.SHIP_CERT_NAME,t1.MATUREDATE desc";
             
            if (dbAccess.GetDataTable(sql, out dtRe, out err))
            {
                return dtRe;
            }
            else
            {
                throw new Exception("获取船舶证书相关信息时出错,错误信息为:" + err);
            }
        }

        public DataTable GetAllShipCertRegisterCrossTableInfo()
        {
            //1、得到所有的要输出证书信息.
            List<ShipCert> lstShipCert = ShipCertService.Instance.GetAllReportCert();
            DataTable dtRe;
            string err;
            sql = "select SHIP_NAME";
            List<string> usedName = new List<string>();
            usedName.Add("SHIP_NAME");
            for (int i = 0; i < lstShipCert.Count; i++)
            {
                if (!lstShipCert[i].NEEDOUTPUTSHOW) continue;

                string toUse;
                if(string.IsNullOrEmpty(lstShipCert[i].AIMTOCONFIGSHORT) || usedName.Contains (lstShipCert[i].AIMTOCONFIGSHORT))
                {
                    toUse = lstShipCert[i].AIMTOCONFIG;
                }
                else 
                    toUse = lstShipCert[i].AIMTOCONFIGSHORT;
                
                if (usedName.Contains(toUse)) continue;                
                usedName.Add(toUse);

                sql += ",\r (select isnull(convert( varchar(10),max(MATUREDATE),102),'----')"
                    + " from T_SHIP_CERT_REGISTER where SHIPCERTTYPE<>4 and T_SHIP_CERT_REGISTER.ship_id = t_ship.ship_id and SHIP_CERT_ID = '"
                    + lstShipCert[i].GetId() + "') as [" + toUse + "]";
            }
             
            sql += "\rfrom t_ship order by SHIP_EN_NAME";
          
            if (dbAccess.GetDataTable(sql, out dtRe, out err))
            {
                return dtRe;
            }
            else
            {
                throw new Exception("获取船舶证书相关信息时出错,错误信息为:" + err);
            }
        }

        public ShipCertRegister GetTheLastRegisterOfShipCert(string shipId, string certId)
        {
            string err;
            sql = "select  top 1 SHIP_CERT_REGISTERID "
                + "\rfrom T_SHIP_CERT_REGISTER"
                + "\rwhere 1=1 ";
            if (!string.IsNullOrEmpty(shipId)) sql += "\rand ship_id = '" + shipId + "'";
            if (!string.IsNullOrEmpty(certId)) sql += "\rand SHIP_CERT_ID = '" + certId + "'";
            sql += "\rorder by MATUREDATE desc";
            string id;
            if (dbAccess.GetString(sql, out id, out err))
            {
                return (ShipCertRegister)GetOneObjectById(id);
            }
            else
            {
                return null;
            }
        }
    }
}
