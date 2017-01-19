using System;
using System.Data;
using Repair.DataObject;

namespace Repair.Services
{
    public partial class ShipRepairEventService
    {
        /// <summary>
        /// 根据条件 得到  T_SHIP_REPAIR_EVENT 数据信息.
        /// </summary>
        /// <returns></returns>
        public DataTable GetInfo(string shipID, string arranged)
        {
            sql = "select	"
                + "sre.REPAIRID"
                + ",sre.REPAIRCODE"
                + ",sre.REPAIRPORT"
                + ",sre.SHIP_ID"
                + ",s.SHIP_NAME"
                + ",sre.ARRANGED"
                + ",case sre.ARRANGED "
                + " when 0 then '未完成'"
                + " when 1 then '已完成'"
                + " end as ARRANGED_NAME"
                + ",sre.ARRANGEDPERSON"
                + ",sre.SHIPAFFIRMANT"
                + ",sre.COMPAFFIRMANT"
                + ",convert(varchar(10), sre.REPAIRDATE,111) REPAIRDATE"
                + ",sre.SERVICEPROVIDER"
                + ",m.MANUFACTURER_NAME"
                + ",convert(varchar(10), sre.COMPLETEDATE,111) COMPLETEDATE "
                + ",sre.REMARK"
                + "  from T_SHIP_REPAIR_EVENT sre"
                + " inner join t_ship s on s.ship_id=sre.ship_id "
                + " inner join T_MANUFACTURER m on m.MANUFACTURER_ID=sre.SERVICEPROVIDER "
                + " where 1=1";
            if (!string.IsNullOrEmpty(shipID) && shipID != "0")
                sql += " and sre.ship_id='" + shipID + "'";
            if (!string.IsNullOrEmpty(arranged))
                sql += " and sre.ARRANGED=" + arranged;
            sql += " order by sre.REPAIRCODE desc";
            string err;
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
        /// 生成流水号.
        /// </summary>
        /// <returns></returns>
        public string CreateSerialNumber()
        {
            sql = "select	"
                + "convert(int, substring(REPAIRCODE,len(REPAIRCODE)-2,3)) serialNo"
                + " from T_SHIP_REPAIR_EVENT "
                + " order by convert(int, substring(REPAIRCODE,len(REPAIRCODE)-2,3)) desc";
            string err;
            DataTable dt;
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                if (dt.Rows.Count > 0)
                {
                    string num = "00" + (Convert.ToInt32(dt.Rows[0]["serialNo"]) + 1);
                    return num.Substring(num.Length - 3);
                }
                else
                    return "001";
            }
            else
            {
                throw new Exception(err);
            }
        }
        /// <summary>
        /// 向数据库中保存一条新记录。并返回ID
        /// </summary>
        /// <param name="unit">ShipRepairEvent对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool InsertUnit(ShipRepairEvent unit, out string id, out string err)
        {
            if (unit.REPAIRID != null && unit.REPAIRID.Length > 0) //edit
            {
                sql = "UPDATE [T_SHIP_REPAIR_EVENT] SET "
                    + " [REPAIRID] = " + (string.IsNullOrEmpty(unit.REPAIRID) ? "null" : "'" + unit.REPAIRID.Replace("'", "''") + "'")
                    + " , [REPAIRCODE] = " + (unit.REPAIRCODE == null ? "''" : "'" + unit.REPAIRCODE.Replace("'", "''") + "'")
                    + " , [REPAIRPORT] = " + (unit.REPAIRPORT == null ? "''" : "'" + unit.REPAIRPORT.Replace("'", "''") + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , [ARRANGED] = " + unit.ARRANGED.ToString()
                    + " , [ARRANGEDPERSON] = " + (unit.ARRANGEDPERSON == null ? "''" : "'" + unit.ARRANGEDPERSON.Replace("'", "''") + "'")
                    + " , [SHIPAFFIRMANT] = " + (unit.SHIPAFFIRMANT == null ? "''" : "'" + unit.SHIPAFFIRMANT.Replace("'", "''") + "'")
                    + " , [COMPAFFIRMANT] = " + (unit.COMPAFFIRMANT == null ? "''" : "'" + unit.COMPAFFIRMANT.Replace("'", "''") + "'")
                    + " , [REPAIRDATE] = " + dbOperation.DbToDate(unit.REPAIRDATE)
                    + " , [SERVICEPROVIDER] = " + (unit.SERVICEPROVIDER == null ? "null" : "'" + unit.SERVICEPROVIDER.Replace("'", "''") + "'")
                    + " , [COMPLETEDATE] = " + dbOperation.DbToDate(unit.COMPLETEDATE)
                    + " , [REMARK] = N" + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
                    + " where upper(REPAIRID) = '" + unit.REPAIRID.ToUpper() + "'";
            }
            else
            {
                unit.REPAIRID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_SHIP_REPAIR_EVENT] ("
                    + "[REPAIRID],"
                    + "[REPAIRCODE],"
                    + "[REPAIRPORT],"
                    + "[SHIP_ID],"
                    + "[ARRANGED],"
                    + "[ARRANGEDPERSON],"
                    + "[SHIPAFFIRMANT],"
                    + "[COMPAFFIRMANT],"
                    + "[REPAIRDATE],"
                    + "[SERVICEPROVIDER],"
                    + "[COMPLETEDATE],"
                    + "[REMARK]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.REPAIRID) ? "null" : "'" + unit.REPAIRID.Replace("'", "''") + "'")
                    + " , " + (unit.REPAIRCODE == null ? "''" : "'" + unit.REPAIRCODE.Replace("'", "''") + "'")
                    + " , " + (unit.REPAIRPORT == null ? "''" : "'" + unit.REPAIRPORT.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " ," + unit.ARRANGED.ToString()
                    + " , " + (unit.ARRANGEDPERSON == null ? "''" : "'" + unit.ARRANGEDPERSON.Replace("'", "''") + "'")
                    + " , " + (unit.SHIPAFFIRMANT == null ? "''" : "'" + unit.SHIPAFFIRMANT.Replace("'", "''") + "'")
                    + " , " + (unit.COMPAFFIRMANT == null ? "''" : "'" + unit.COMPAFFIRMANT.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.REPAIRDATE)
                    + " , " + (unit.SERVICEPROVIDER == null ? "null" : "'" + unit.SERVICEPROVIDER.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.COMPLETEDATE)
                    + " , N" + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
                    + ")";
            }
            id = unit.REPAIRID;
            return dbAccess.ExecSql(sql, out err);
        }
    }
}
