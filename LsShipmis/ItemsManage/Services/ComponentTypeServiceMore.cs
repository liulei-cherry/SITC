using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.Interfaces;
using BaseInfo.Objects;
using ItemsManage.DataObject;
using System.Data;
using BaseInfo.DataObject;
namespace ItemsManage.Services
{
    partial class ComponentTypeService : IObjectsService
    {
        #region IObjectsService 成员

        public CommonOperation.BaseClass.CommonClass GetOneObjectById(string id)
        {
            string err;
            return getObject(id, out err);
            //throw new Exception("The method or operation is not implemented.");
        }

        public Dictionary<string, string> GetObjectDisplaySetting()
        {
            Dictionary<string, string> reValue = new Dictionary<string, string>();
            reValue.Add("COMPTYPE_CHINESE_NAME", "设备类型名");
            reValue.Add("COMPTYPE_ENGLISH_NAME", "设备类型别名");
            reValue.Add("COMPONENT_STYLE", "设备型号");
            //reValue.Add("comp_serial_no", "设备序列号");
            //reValue.Add("SHIP_Name", "船舶名称");
            return reValue;
        }

        #endregion

        /// <summary>
        /// 根据设备型号找出所有属于该类型下的设备.
        /// </summary>
        /// <param name="spareId"></param>
        /// <returns></returns>
        public Dictionary<string, string> GetOneCompTypeAllComponent(string componentTypeId)
        {
            Dictionary<string, string> dicRe = new Dictionary<string, string>();
            string err;
            DataTable dt;
            sql = "SELECT  t1.COMPONENT_UNIT_ID,'(' + t2.SHIP_NAME + ')' + [dbo].[F_Get_Comp_Full_name](t1.COMPONENT_UNIT_ID,1) full_name FROM";
            sql += " T_Component_Unit t1 inner join t_ship t2 on t1.ship_id = t2.ship_id where t1.COMPONENT_TYPE_ID = '" + componentTypeId + "'";
            sql += "\r order by t2.ship_name,full_name";
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                string component_id = "";
                string component_name = "";
                foreach (DataRow dr in dt.Rows)
                {
                    component_id = dr[0].ToString();
                    component_name = dr[1].ToString();
                    dicRe.Add(component_id, component_name);
                }
            }
            return dicRe;
        }

        /// <summary>
        /// 根据id得到其所有下级设备.
        /// </summary>
        /// <param name="sParentId">设备型号id</param>
        /// <param name="err"></param>
        /// <returns></returns>
        public List<ComponentType> GetSonEquipmentTypes(string sParentId, out string err)
        {
            DataTable dtb;
            string sSql = "";
            err = "";
            sSql += "select COMPONENT_TYPE_ID,SUPERIOR_COMPONENT,CODE_SYSTEM_INDEX,SAFEEQUIPMENT,";
            sSql += "SAFEEQUIPMENT,COMPTYPE_CHINESE_NAME, COMPTYPE_CHINESE_NAME,COMPTYPE_ENGLISH_NAME,";
            sSql += "SHIP_PROVE_CODE,LETTER_NUMBER,MANUFACTURER,USE_POSITION,COMPONENT_STYLE,SERVICE_PROVIDER,DEFAULT_USE_RATE,T_COMPONENT_TYPE.CREATOR,TIMING_TYPE,";
            sSql += "HEADSHIP,sort_no,DETAIL from T_COMPONENT_TYPE where upper(SUPERIOR_COMPONENT)";
            sSql += ((sParentId == null || sParentId.Length != 36) ? " is null " : "='" + sParentId.ToUpper() + "'");
            sSql += " order by  sort_no ";
            List<ComponentType> reList = new List<ComponentType>();
            if (!dbAccess.GetDataTable(sSql, out dtb, out err))
            {
                return reList;
            }
            reList.AddRange(this.GetLstEquipmentTypeByTable(dtb));
            return reList;
        }

        /// <summary>
        /// 根据一个DataTable得到一组设备的实例.
        /// </summary>
        /// <param name="dtb"></param>
        /// <returns></returns>
        public List<ComponentType> GetLstEquipmentTypeByTable(DataTable dtb)
        {
            List<ComponentType> reList = new List<ComponentType>();
            try
            {
                foreach (DataRow row in dtb.Rows)
                {
                    ComponentType newEquip = new ComponentType();
                    //(row["COMPONENT_TYPE_ID"].ToString(), row["SUPERIOR_COMPONENT"].ToString(), row["CODE_SYSTEM_INDEX"].ToString(), decimal.Parse(row["SAFEEQUIPMENT"].ToString()),
                    //row["COMPTYPE_CHINESE_NAME"].ToString(), row["COMPTYPE_ENGLISH_NAME"].ToString(), row["SHIP_PROVE_CODE"].ToString(), row["MANUFACTURER"].ToString(), row["COMPONENT_STYLE"].ToString(),
                    //row["SERVICE_PROVIDER"].ToString(), decimal.Parse(row["DEFAULT_USE_RATE"].ToString()), row["CREATOR"].ToString(), decimal.Parse(row["TIMING_TYPE"].ToString()),
                    //row["HEADSHIP"].ToString(), Decimal.Parse(row["sort_no"].ToString()));
                    if (DBNull.Value != row["COMPONENT_TYPE_ID"])
                        newEquip.COMPONENT_TYPE_ID = row["COMPONENT_TYPE_ID"].ToString();
                    if (DBNull.Value != row["SUPERIOR_COMPONENT"])
                        newEquip.SUPERIOR_COMPONENT = row["SUPERIOR_COMPONENT"].ToString();
                    if (DBNull.Value != row["CODE_SYSTEM_INDEX"])
                        newEquip.CODE_SYSTEM_INDEX = row["CODE_SYSTEM_INDEX"].ToString();
                    if (DBNull.Value != row["SAFEEQUIPMENT"])
                        newEquip.SAFEEQUIPMENT = decimal.Parse(row["SAFEEQUIPMENT"].ToString());
                    if (DBNull.Value != row["COMPTYPE_CHINESE_NAME"])
                        newEquip.COMPTYPE_CHINESE_NAME = row["COMPTYPE_CHINESE_NAME"].ToString();
                    if (DBNull.Value != row["COMPTYPE_ENGLISH_NAME"])
                        newEquip.COMPTYPE_ENGLISH_NAME = row["COMPTYPE_ENGLISH_NAME"].ToString();
                    if (DBNull.Value != row["SHIP_PROVE_CODE"])
                        newEquip.SHIP_PROVE_CODE = row["SHIP_PROVE_CODE"].ToString();
                    if (DBNull.Value != row["MANUFACTURER"])
                        newEquip.MANUFACTURER = row["MANUFACTURER"].ToString();
                    if (DBNull.Value != row["COMPONENT_STYLE"])
                        newEquip.COMPONENT_STYLE = row["COMPONENT_STYLE"].ToString();
                    if (DBNull.Value != row["SERVICE_PROVIDER"])
                        newEquip.SERVICE_PROVIDER = row["SERVICE_PROVIDER"].ToString();
                    if (DBNull.Value != row["DEFAULT_USE_RATE"])
                        newEquip.DEFAULT_USE_RATE = decimal.Parse(row["DEFAULT_USE_RATE"].ToString());
                    if (DBNull.Value != row["CREATOR"])
                        newEquip.CREATOR = row["CREATOR"].ToString();
                    if (DBNull.Value != row["TIMING_TYPE"])
                        newEquip.TIMING_TYPE = decimal.Parse(row["TIMING_TYPE"].ToString());
                    if (DBNull.Value != row["HEADSHIP"])
                        newEquip.HEADSHIP = row["HEADSHIP"].ToString();
                    if (DBNull.Value != row["sort_no"])
                        newEquip.SORT_NO = decimal.Parse(row["sort_no"].ToString());
                    if (DBNull.Value != row["detail"])
                        newEquip.DETAIL = row["detail"].ToString();
                    reList.Add(newEquip);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return reList;
        }

        /// <summary>
        /// 根据设备型号名称返回设备型号的信息.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="shipId"></param>
        /// <returns></returns>
        public ComponentType GetComponentTypeByNameAndStyleNumber(string name, string style)
        {
            string err;
            sql = "select top 1"
                + "COMPONENT_TYPE_ID, "
                + "SUPERIOR_COMPONENT, "
                + "CODE_SYSTEM_INDEX, "
                + "COMPONENT_LEVEL, "
                + "COMPTYPE_CHINESE_NAME, "
                + "COMPTYPE_ENGLISH_NAME, "
                + "SHIP_PROVE_CODE, "
                + "LETTER_NUMBER, "
                + "MANUFACTURER, "
                + "USE_POSITION, "
                + "COMPONENT_STYLE, "
                + "SERVICE_PROVIDER, "
                + "DEFAULT_USE_RATE, "
                + "CREATOR, "
                + "CREATETIME, "
                + "TIMING_TYPE, "
                + "HEADSHIP, "
                + "UPDATETIME, "
                + "SAFEEQUIPMENT, "
                + "sort_no,detail"
                + "\rfrom T_COMPONENT_TYPE "
                + "\rwhere " + (string.IsNullOrEmpty(style) ? " COMPTYPE_CHINESE_NAME ='" + name.Replace("'", "''") + "'" : "COMPONENT_STYLE='" + style.Replace("'", "''") + "'")
                + "\rorder by " + (string.IsNullOrEmpty(name) ? "COMPTYPE_CHINESE_NAME" : "case when COMPTYPE_CHINESE_NAME ='" + name.Replace("'", "''") + "' then 1 else 2 end ,sort_no,COMPTYPE_CHINESE_NAME ");
            DataTable dtb;
            if (!dbAccess.GetDataTable(sql, out dtb, out err) || dtb.Rows.Count == 0)
            {
                return null;
            }
            return getObject(dtb.Rows[0]);
        }

        public ComponentType GetComponentTypeByNameAndStyleNumber(string name, string style, string factory)
        {
            string err;
            sql = "select top 1"
                + "COMPONENT_TYPE_ID, "
                + "SUPERIOR_COMPONENT, "
                + "CODE_SYSTEM_INDEX, "
                + "COMPONENT_LEVEL, "
                + "COMPTYPE_CHINESE_NAME, "
                + "COMPTYPE_ENGLISH_NAME, "
                + "SHIP_PROVE_CODE, "
                + "LETTER_NUMBER, "
                + "MANUFACTURER, "
                + "USE_POSITION, "
                + "COMPONENT_STYLE, "
                + "SERVICE_PROVIDER, "
                + "DEFAULT_USE_RATE, "
                + "CREATOR, "
                + "CREATETIME, "
                + "TIMING_TYPE, "
                + "HEADSHIP, "
                + "UPDATETIME, "
                + "SAFEEQUIPMENT, "
                + "sort_no,detail"
                + "\rfrom T_COMPONENT_TYPE "
                + "\rwhere COMPTYPE_CHINESE_NAME ='" + name.Replace("'", "''") + "' and COMPONENT_STYLE='"
                + style.Replace("'", "''") + "' and MANUFACTURER ='" + factory.Replace("'", "''") + "'";
            DataTable dtb;
            if (!dbAccess.GetDataTable(sql, out dtb, out err) || dtb.Rows.Count == 0)
            {
                return null;
            }
            return getObject(dtb.Rows[0]);
        }

        /// <summary>
        /// 为设备型号绑定备件.
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="spareId"></param>
        /// <param name="makingNumber">构成数量</param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool BandingToSpare(string typeId, string spareId, int makingNumber, out string err)
        {
            string comptypespareId = Guid.NewGuid().ToString();
            string creator = CommonOperation.ConstParameter.UserName;
            List<string> sqls = new List<string>();
            sqls.Add("delete t_componenttype_spare where component_type_id='" + typeId.Replace("'", "''") + "' and spare_id = '" + spareId.Replace("'", "''") + "'");
            sqls.Add("insert into t_componenttype_spare(comptypespareid,component_type_id,spare_id,MAKEUPNUMBER,creator)"
            + "values('" + comptypespareId + "','" + typeId.Replace("'", "''") + "','" + spareId.Replace("'", "''") + "'," + makingNumber.ToString() + ",'" + creator.Replace("'", "''") + "')");
            return dbAccess.ExecSql(sqls, out err);
        }

        /// <summary>
        /// 为设备型号绑定备件.
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="spareId"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool BandingToSpare(string typeId, string spareId, out string err)
        {
            return BandingToSpare(typeId, spareId, 0, out err);
        }

        /// <summary>
        /// 为设备型号绑定备件.
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="spareId"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool DeleteBandingToSpare(string bandingId, out string err)
        {
            string comptypespareId = Guid.NewGuid().ToString();
            string creator = CommonOperation.ConstParameter.UserName;
            string sql = "delete t_componenttype_spare where comptypespareid ='" + bandingId + "'";
            return dbAccess.ExecSql(sql, out err);
        }

        /// <summary>
        /// 注意:这里并非是其应该在的位置,应该给它建立一个具体类,只是没有时间这么做了.
        /// 取工作报告类型信息.
        /// </summary>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetMeaReportType(string SHIP_ID)
        {
            //变量定义部分.
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.

            //Select语句加工部分.
            sSql += "select ";
            sSql += "ship_id,";
            sSql += "measure_report_type_id,";
            sSql += "measure_report_type_name,";
            sSql += "remark,file_id,";
            sSql += "creator ";
            sSql += "from T_Measure_Report_Type ";
            if (!string.IsNullOrEmpty(SHIP_ID))
                sSql += "where SHIP_ID= '" + SHIP_ID + "'";
            sSql += "order by measure_report_type_name"; //名称排序.

            dbAccess.GetDataTable(sSql, out dtb, out err);
            return dtb;
        }

    }
}
