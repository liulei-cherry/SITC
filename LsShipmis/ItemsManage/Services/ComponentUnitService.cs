/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：ComponentUnitService.cs
 * 创 建 人：徐正本
 * 创建时间：2011/6/28
 * 标    题：数据操作类
 * 功能描述：T_COMPONENT_UNIT数据操作类
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
using ItemsManage.DataObject;

namespace ItemsManage.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_COMPONENT_UNITService.cs
    /// </summary>
    public partial class ComponentUnitService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static ComponentUnitService instance = new ComponentUnitService();
        public static ComponentUnitService Instance
        {
            get
            {
                if (null == instance)
                {
                    ComponentUnitService.instance = new ComponentUnitService();
                }
                return ComponentUnitService.instance;
            }
        }
        private ComponentUnitService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">ComponentUnit对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(ComponentUnit unit, out string err)
        {
            if (unit.COMPONENT_UNIT_ID != null && unit.COMPONENT_UNIT_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_COMPONENT_UNIT] SET "
                    + " [COMPONENT_UNIT_ID] = " + (string.IsNullOrEmpty(unit.COMPONENT_UNIT_ID) ? "null" : "'" + unit.COMPONENT_UNIT_ID.Replace("'", "''") + "'")
                    + " , [COMPONENT_TYPE_ID] = " + (string.IsNullOrEmpty(unit.COMPONENT_TYPE_ID) ? "null" : "'" + unit.COMPONENT_TYPE_ID.Replace("'", "''") + "'")
                    + " , [PARENT_UNIT_ID] = " + (string.IsNullOrEmpty(unit.PARENT_UNIT_ID) ? "null" : "'" + unit.PARENT_UNIT_ID.Replace("'", "''") + "'")
                    + " , [COMP_NUMBER] = " + (unit.COMP_NUMBER == null ? "''" : "'" + unit.COMP_NUMBER.Replace("'", "''") + "'")
                    + " , [PRODUCE_TIME] = " + dbOperation.DbToDate(unit.PRODUCE_TIME)
                    + " , [USE_TIME] = " + dbOperation.DbToDate(unit.USE_TIME)
                    + " , [USE_RATE] = " + unit.USE_RATE.ToString()
                    + " , [COMP_CHINESE_NAME] = N" + (unit.COMP_CHINESE_NAME == null ? "''" : "'" + unit.COMP_CHINESE_NAME.Replace("'", "''") + "'")
                    + " , [COMP_ENGLISH_NAME] = N" + (unit.COMP_ENGLISH_NAME == null ? "''" : "'" + unit.COMP_ENGLISH_NAME.Replace("'", "''") + "'")
                    + " , [COMP_STATUS] = " + unit.COMP_STATUS.ToString()
                    + " , [EXAMINATION_CODE] = " + (unit.EXAMINATION_CODE == null ? "''" : "'" + unit.EXAMINATION_CODE.Replace("'", "''") + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , [CWBT_CODE] = " + (unit.CWBT_CODE == null ? "''" : "'" + unit.CWBT_CODE.Replace("'", "''") + "'")
                    + " , [wareHouse] = " + (unit.wareHouse == null ? "''" : "'" + unit.wareHouse.Replace("'", "''") + "'")
                    + " , [total_workhours] = " + unit.total_workhours.ToString()
                    + " , [last_couter_time] = " + dbOperation.DbToDate(unit.last_couter_time)
                    + " , [after_repair_hours] = " + unit.after_repair_hours.ToString()
                    + " , [repair_date] = " + dbOperation.DbToDate(unit.repair_date)
                    + " , [comp_serial_no] = " + (unit.comp_serial_no == null ? "''" : "'" + unit.comp_serial_no.Replace("'", "''") + "'")
                    + " , [certification] = " + (unit.certification == null ? "''" : "'" + unit.certification.Replace("'", "''") + "'")
                    + " , [Detail] = N" + (unit.Detail == null ? "''" : "'" + unit.Detail.Replace("'", "''") + "'")
                    + " , [SortNo] = " + unit.SortNo.ToString()
                    + " where upper(COMPONENT_UNIT_ID) = '" + unit.COMPONENT_UNIT_ID.ToUpper() + "'";
            }
            else
            {
                unit.COMPONENT_UNIT_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_COMPONENT_UNIT] ("
                    + "[COMPONENT_UNIT_ID],"
                    + "[COMPONENT_TYPE_ID],"
                    + "[PARENT_UNIT_ID],"
                    + "[COMP_NUMBER],"
                    + "[PRODUCE_TIME],"
                    + "[USE_TIME],"
                    + "[USE_RATE],"
                    + "[COMP_CHINESE_NAME],"
                    + "[COMP_ENGLISH_NAME],"
                    + "[COMP_STATUS],"
                    + "[EXAMINATION_CODE],"
                    + "[SHIP_ID],"
                    + "[CWBT_CODE],"
                    + "[wareHouse],"
                    + "[total_workhours],"
                    + "[last_couter_time],"
                    + "[after_repair_hours],"
                    + "[repair_date],"
                    + "[comp_serial_no],"
                    + "[certification],"
                    + "[Detail],"
                    + "[SortNo]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.COMPONENT_UNIT_ID) ? "null" : "'" + unit.COMPONENT_UNIT_ID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.COMPONENT_TYPE_ID) ? "null" : "'" + unit.COMPONENT_TYPE_ID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.PARENT_UNIT_ID) ? "null" : "'" + unit.PARENT_UNIT_ID.Replace("'", "''") + "'")
                    + " , " + (unit.COMP_NUMBER == null ? "''" : "'" + unit.COMP_NUMBER.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.PRODUCE_TIME)
                    + " ," + dbOperation.DbToDate(unit.USE_TIME)
                    + " ," + unit.USE_RATE.ToString()
                    + " , N" + (unit.COMP_CHINESE_NAME == null ? "''" : "'" + unit.COMP_CHINESE_NAME.Replace("'", "''") + "'")
                    + " , N" + (unit.COMP_ENGLISH_NAME == null ? "''" : "'" + unit.COMP_ENGLISH_NAME.Replace("'", "''") + "'")
                    + " ," + unit.COMP_STATUS.ToString()
                    + " , " + (unit.EXAMINATION_CODE == null ? "''" : "'" + unit.EXAMINATION_CODE.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , " + (unit.CWBT_CODE == null ? "''" : "'" + unit.CWBT_CODE.Replace("'", "''") + "'")
                    + " , " + (unit.wareHouse == null ? "''" : "'" + unit.wareHouse.Replace("'", "''") + "'")
                    + " ," + unit.total_workhours.ToString()
                    + " ," + dbOperation.DbToDate(unit.last_couter_time)
                    + " ," + unit.after_repair_hours.ToString()
                    + " ," + dbOperation.DbToDate(unit.repair_date)
                    + " , " + (unit.comp_serial_no == null ? "''" : "'" + unit.comp_serial_no.Replace("'", "''") + "'")
                    + " , " + (unit.certification == null ? "''" : "'" + unit.certification.Replace("'", "''") + "'")
                    + " , N" + (unit.Detail == null ? "''" : "'" + unit.Detail.Replace("'", "''") + "'")
                    + " ," + unit.SortNo.ToString()
                    + ")";
            }
            return dbAccess.ExecSql(sql, out err);
        }

        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_COMPONENT_UNIT 所有数据信息.
        /// </summary>
        /// <returns>T_COMPONENT_UNIT DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "COMPONENT_UNIT_ID"
                + ",COMPONENT_TYPE_ID"
                + ",PARENT_UNIT_ID"
                + ",COMP_NUMBER"
                + ",PRODUCE_TIME"
                + ",USE_TIME"
                + ",USE_RATE"
                + ",COMP_CHINESE_NAME"
                + ",COMP_ENGLISH_NAME"
                + ",COMP_STATUS"
                + ",EXAMINATION_CODE"
                + ",SHIP_ID"
                + ",CWBT_CODE"
                + ",wareHouse"
                + ",total_workhours"
                + ",last_couter_time"
                + ",after_repair_hours"
                + ",repair_date"
                + ",comp_serial_no"
                + ",certification"
                + ",Detail"
                + ",SortNo,[dbo].[F_Get_Comp_Full_name](COMPONENT_UNIT_ID,1) FULL_NAME"
                + "  from T_COMPONENT_UNIT where PARENT_UNIT_ID is not null order by sortNO,createtime";
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
        /// 根据一个主键ID,得到 T_COMPONENT_UNIT 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>ComponentUnit DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "COMPONENT_UNIT_ID"
                + ",COMPONENT_TYPE_ID"
                + ",PARENT_UNIT_ID"
                + ",COMP_NUMBER"
                + ",PRODUCE_TIME"
                + ",USE_TIME"
                + ",USE_RATE"
                + ",COMP_CHINESE_NAME"
                + ",COMP_ENGLISH_NAME"
                + ",COMP_STATUS"
                + ",EXAMINATION_CODE"
                + ",SHIP_ID"
                + ",CWBT_CODE"
                + ",wareHouse"
                + ",total_workhours"
                + ",last_couter_time"
                + ",after_repair_hours"
                + ",repair_date"
                + ",comp_serial_no"
                + ",certification"
                + ",Detail"
                + ",SortNo,[dbo].[F_Get_Comp_Full_name](COMPONENT_UNIT_ID,1) FULL_NAME"
                + " from T_COMPONENT_UNIT "
                + " where upper(COMPONENT_UNIT_ID)='" + Id.ToUpper() + "' order by sortno";
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
        /// 根据componentunit 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>componentunit 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
        public ComponentUnit getObject(DataRow dr)
        {
            ComponentUnit unit = new ComponentUnit();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造ComponentUnit类对象!";
                return unit;
            }
            if (DBNull.Value != dr["COMPONENT_UNIT_ID"])
                unit.COMPONENT_UNIT_ID = dr["COMPONENT_UNIT_ID"].ToString();
            if (DBNull.Value != dr["COMPONENT_TYPE_ID"])
                unit.COMPONENT_TYPE_ID = dr["COMPONENT_TYPE_ID"].ToString();
            if (DBNull.Value != dr["PARENT_UNIT_ID"])
                unit.PARENT_UNIT_ID = dr["PARENT_UNIT_ID"].ToString();
            if (DBNull.Value != dr["COMP_NUMBER"])
                unit.COMP_NUMBER = dr["COMP_NUMBER"].ToString();
            if (DBNull.Value != dr["PRODUCE_TIME"])
                unit.PRODUCE_TIME = (DateTime)dr["PRODUCE_TIME"];
            if (DBNull.Value != dr["USE_TIME"])
                unit.USE_TIME = (DateTime)dr["USE_TIME"];
            if (DBNull.Value != dr["USE_RATE"])
                unit.USE_RATE = Convert.ToDecimal(dr["USE_RATE"]);
            if (DBNull.Value != dr["COMP_CHINESE_NAME"])
                unit.COMP_CHINESE_NAME = dr["COMP_CHINESE_NAME"].ToString();
            if (DBNull.Value != dr["COMP_ENGLISH_NAME"])
                unit.COMP_ENGLISH_NAME = dr["COMP_ENGLISH_NAME"].ToString();
            if (DBNull.Value != dr["COMP_STATUS"])
                unit.COMP_STATUS = Convert.ToDecimal(dr["COMP_STATUS"]);
            if (DBNull.Value != dr["EXAMINATION_CODE"])
                unit.EXAMINATION_CODE = dr["EXAMINATION_CODE"].ToString();
            if (DBNull.Value != dr["SHIP_ID"])
                unit.SHIP_ID = dr["SHIP_ID"].ToString();
            if (DBNull.Value != dr["CWBT_CODE"])
                unit.CWBT_CODE = dr["CWBT_CODE"].ToString();
            if (DBNull.Value != dr["wareHouse"])
                unit.wareHouse = dr["wareHouse"].ToString();
            if (DBNull.Value != dr["total_workhours"])
                unit.total_workhours = Convert.ToDecimal(dr["total_workhours"]);
            if (DBNull.Value != dr["last_couter_time"])
                unit.last_couter_time = (DateTime)dr["last_couter_time"];
            if (DBNull.Value != dr["after_repair_hours"])
                unit.after_repair_hours = Convert.ToDecimal(dr["after_repair_hours"]);
            if (DBNull.Value != dr["repair_date"])
                unit.repair_date = (DateTime)dr["repair_date"];
            if (DBNull.Value != dr["comp_serial_no"])
                unit.comp_serial_no = dr["comp_serial_no"].ToString();
            if (DBNull.Value != dr["certification"])
                unit.certification = dr["certification"].ToString();
            if (DBNull.Value != dr["Detail"])
                unit.Detail = dr["Detail"].ToString();
            if (DBNull.Value != dr["SortNo"])
                unit.SortNo = Convert.ToDecimal(dr["SortNo"]);

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个ComponentUnit对象.
        /// </summary>
        /// <param name="cOMPONENT_UNIT_ID">cOMPONENT_UNIT_ID</param>
        /// <returns>ComponentUnit对象</returns>
        public ComponentUnit getObject(string Id, out string err)
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

        /// <summary>
        /// 根据ID,返回一个ComponentUnit对象.
        /// </summary>
        /// <param name="cOMPONENT_UNIT_ID">cOMPONENT_UNIT_ID</param>
        /// <returns>ComponentUnit对象</returns>
        public ComponentUnit GetObjectByNameAndParentId(string Id, string name, out string err)
        {
            err = "";
            try
            {
                sql = "select "
                    + "COMPONENT_UNIT_ID, "
                    + "COMPONENT_TYPE_ID, "
                    + "PARENT_UNIT_ID, "
                    + "COMP_NUMBER, "
                    + "PRODUCE_TIME, "
                    + "USE_TIME, "
                    + "USE_RATE, "
                    + "COMP_CHINESE_NAME, "
                    + "COMP_ENGLISH_NAME, "
                    + "COMP_STATUS, "
                    + "EXAMINATION_CODE, "
                    + "CREATOR, "
                    + "CREATETIME, "
                    + "UPDATETIME, "
                    + "SHIP_ID, "
                    + "CWBT_CODE, "
                    + "wareHouse, "
                    + "total_workhours, "
                    + "last_couter_time, "
                    + "after_repair_hours, "
                    + "repair_date, "
                    + "comp_serial_no, "
                    + "certification,detail,sortno"
                    + "\rfrom T_Component_Unit "
                    + "\rwhere PARENT_UNIT_ID='" + dbOperation.ReplaceSqlKeyStr(Id) + "' and COMP_CHINESE_NAME = N'" + dbOperation.ReplaceSqlKeyStr(name) + "'";
                DataTable dt;
                if (dbAccess.GetDataTable(sql, out dt, out err))
                {
                    return getObject(dt.Rows[0]);
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        /// <summary>
        /// 根据ID,返回一个ComponentUnit对象.
        /// </summary>
        /// <param name="cOMPONENT_UNIT_ID">cOMPONENT_UNIT_ID</param>
        /// <returns>ComponentUnit对象</returns>
        public ComponentUnit GetObjectByNameAndParentIdAndTypeAndClass(string Id, string name, string typeid, string classid, out string err)
        {
            err = "";
            try
            {
                sql = "select top 1 "
                    + "t1.COMPONENT_UNIT_ID, "
                    + "COMPONENT_TYPE_ID, "
                    + "PARENT_UNIT_ID, "
                    + "COMP_NUMBER, "
                    + "PRODUCE_TIME, "
                    + "USE_TIME, "
                    + "USE_RATE, "
                    + "COMP_CHINESE_NAME, "
                    + "COMP_ENGLISH_NAME, "
                    + "COMP_STATUS, "
                    + "EXAMINATION_CODE, "
                    + "CREATOR, "
                    + "CREATETIME, "
                    + "UPDATETIME, "
                    + "SHIP_ID, "
                    + "CWBT_CODE, "
                    + "wareHouse, "
                    + "total_workhours, "
                    + "last_couter_time, "
                    + "after_repair_hours, "
                    + "repair_date, "
                    + "comp_serial_no, "
                    + "certification,detail,t1.sortno"
                    + "\rfrom T_Component_Unit t1 "
                    + (string.IsNullOrEmpty(classid) ? "" : "inner join T_EQUIPMENT_CLASS_REF t2 on t1.COMPONENT_UNIT_ID = t2.COMPONENT_UNIT_ID")
                    + "\rwhere PARENT_UNIT_ID='" + dbOperation.ReplaceSqlKeyStr(Id) + "' and COMP_CHINESE_NAME = N'" + dbOperation.ReplaceSqlKeyStr(name) + "'"
                    + (string.IsNullOrEmpty(classid) ? "" : "and t2.CLASSID = '" + dbOperation.ReplaceSqlKeyStr(classid) + "'")
                    + "\rorder by case when COMPONENT_TYPE_ID = '" + dbOperation.ReplaceSqlKeyStr(typeid) + "' then 0 else 1 end";
                DataTable dt;
                if (dbAccess.GetDataTable(sql, out dt, out err))
                {
                    return getObject(dt.Rows[0]);
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        /// <summary>
        /// 根据船舶ID,返回一个根节点的ComponentUnit对象.
        /// 以前的做法是船舶id和顶级设备id相同,现在可以使用此方法让其不同.
        /// </summary>
        /// <param name="cOMPONENT_UNIT_ID">cOMPONENT_UNIT_ID</param>
        /// <returns>ComponentUnit对象</returns>
        public ComponentUnit GetObjectByRootAndShipId(string shipId, out string err)
        {
            err = "";
            try
            {
                sql = "select "
                    + "COMPONENT_UNIT_ID, "
                    + "COMPONENT_TYPE_ID, "
                    + "PARENT_UNIT_ID, "
                    + "COMP_NUMBER, "
                    + "PRODUCE_TIME, "
                    + "USE_TIME, "
                    + "USE_RATE, "
                    + "COMP_CHINESE_NAME, "
                    + "COMP_ENGLISH_NAME, "
                    + "COMP_STATUS, "
                    + "EXAMINATION_CODE, "
                    + "CREATOR, "
                    + "CREATETIME, "
                    + "UPDATETIME, "
                    + "SHIP_ID, "
                    + "CWBT_CODE, "
                    + "wareHouse, "
                    + "total_workhours, "
                    + "last_couter_time, "
                    + "after_repair_hours, "
                    + "repair_date, "
                    + "comp_serial_no, "
                    + "certification,detail,sortno"
                    + "\rfrom T_Component_Unit "
                    + "\rwhere SHIP_ID='" + shipId + "' and PARENT_UNIT_ID is null"
                    + "\rorder by sortNO";
                DataTable dt;
                if (dbAccess.GetDataTable(sql, out dt, out err))
                {
                    return getObject(dt.Rows[0]);
                }
            }
            catch
            {
                return null;
            }
            return null;
        }


       
        public bool oneEquipmentCanBeDeleted(ComponentUnit theObject, out string err)
        {
            err = "";
            //如果包含下级设备,不允许删除.
            sql = "select count(1) from T_Component_Unit where PARENT_UNIT_ID = '" + theObject.GetId() + "'";
            if (dbAccess.GetString(sql) != "0")
            {
                err = "当前设备存在下级设备!\rThis equipment has sub equipment.";
                return false;
            }
            //包含设备历史.
            sql = "select count(1) from T_COMPONENT_HISTORY where COMPONENT_UNIT_ID = '" + theObject.GetId() + "'";
            if (dbAccess.GetString(sql) != "0")
            {
                err = "当前设备存在设备历史记录!\rThis equipment has some history info.";
                return false;
            }
            //包含工单信息不允许删除.
            sql = "select count(1) from T_WORKINFO where REFOBJID = '" + theObject.GetId() + "'";
            if (dbAccess.GetString(sql) != "0")
            {
                err = "当前设备存在工作信息记录!\rThis equipment has workinfo.";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 彻底删除一个设备,包含其所有下级信息.
        /// </summary>
        /// <param name="componentUnit"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool CompletelyDeleteOneEquipment(ComponentUnit theObject, out string err)
        {
            List<string> sqls = new List<string>();
            //删除其相关下级设备,这里依然有问题,下级设备有工单或者历史的 依然不能删除.
            sql = "delete T_Component_Unit where dbo.F_Comp_AIsBChild(COMPONENT_UNIT_ID,'" + theObject.GetId() + "') = 1";
            sqls.Add(sql);
            ////删除其设备历史 不能删除包含历史的设备.
            //sql = "delete T_COMPONENT_HISTORY where COMPONENT_UNIT_ID = '" + theObject.GetId() + "'";
            // sqls.Add(sql);
            //删除其工单.
            sql = "delete T_WORKINFO where REFOBJID = '" + theObject.GetId() + "'";
            sqls.Add(sql);
            //删除当前设备.
            sql = "delete T_EQUIPMENT_CLASS_REF  where COMPONENT_UNIT_ID ='" + theObject.GetId() + "'";
            sqls.Add(sql);
            sql = "delete T_Component_Unit where COMPONENT_UNIT_ID='" + theObject.GetId() + "'";
            sqls.Add(sql);
            return dbAccess.ExecSql(sqls, out err);
        }

        /// <summary>
        /// 删除数据表T_COMPONENT_UNIT中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_COMPONENT_UNIT对象</param>
        internal bool deleteUnit(ComponentUnit unit, out string err)
        {
            List<string> sqls = new List<string>();
            //得到当前设备所在设备分类的classid,并对之排序;
            string classId = EquipmentClassService.Instance.GetEquipmentBelongClass(unit.GetId());
            if (!string.IsNullOrEmpty(classId))
            {
                //如果找不到也就不用删了.
                sql = "delete T_EQUIPMENT_CLASS_REF  where COMPONENT_UNIT_ID ='" + unit.GetId() + "'";
                sqls.Add(sql);
                sql = "exec dbo.P_Resort_Class_ref '" + classId + "'";
                sqls.Add(sql);
            }
            sql = "delete from T_Component_Unit where T_Component_Unit.COMPONENT_UNIT_ID='" + unit.GetId() + "'";
            sqls.Add(sql);
            sql = "exec dbo.P_Resort_Unit '" + unit.PARENT_UNIT_ID + "'";
            sqls.Add(sql);

            return dbAccess.ExecSql(sqls, out err);
        }
        internal bool resortSubUnit(string parentUnitId, out string err)
        {
            sql = "exec dbo.P_Resort_Unit '" + parentUnitId + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        internal bool resortUnit(ComponentUnit unit, out string err)
        {
            List<string> sqls = new List<string>();
            //得到当前设备所在设备分类的classid,并对之排序;
            string classId = EquipmentClassService.Instance.GetEquipmentBelongClass(unit.GetId());
            if (!string.IsNullOrEmpty(classId))
            {
                sql = "exec dbo.P_Resort_Class_ref '" + classId + "'";
                sqls.Add(sql);
            }
            sql = "exec dbo.P_Resort_Unit '" + unit.PARENT_UNIT_ID + "'";
            sqls.Add(sql);
            return dbAccess.ExecSql(sqls, out err);
        }
    }
}
