/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：ComponentTypeService.cs
 * 创 建 人：xurongxia
 * 创建时间：2009-11-16
 * 标    题：数据操作类
 * 功能描述：T_COMPONENT_TYPE数据操作类
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
    /// 数据层实例化接口类 dbo.T_COMPONENT_TYPEService.cs
    /// </summary>
    public partial class ComponentTypeService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static ComponentTypeService instance = new ComponentTypeService();
        public static ComponentTypeService Instance
        {
            get
            {
                if (null == instance)
                {
                    ComponentTypeService.instance = new ComponentTypeService();
                }
                return ComponentTypeService.instance;
            }
        }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region -----------实例化接口函数-----------

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">ComponentType对象</param>
        /// <returns>插入的对象更新</returns>	
        public bool saveUnit(ComponentType unit, out string err)
        {
            if (unit.COMPONENT_TYPE_ID != null && unit.COMPONENT_TYPE_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_COMPONENT_TYPE] SET "
                    + " [COMPONENT_TYPE_ID] = '" + (unit.COMPONENT_TYPE_ID == null ? "" : unit.COMPONENT_TYPE_ID.Replace("'", "''")) + "'"
                    + " , [SUPERIOR_COMPONENT] = '" + (unit.SUPERIOR_COMPONENT == null ? "" : unit.SUPERIOR_COMPONENT.Replace("'", "''")) + "'"
                    + " , [CODE_SYSTEM_INDEX] = '" + (unit.CODE_SYSTEM_INDEX == null ? "" : unit.CODE_SYSTEM_INDEX.Replace("'", "''")) + "'"
                    + " , [COMPONENT_LEVEL] = '" + (unit.COMPONENT_LEVEL == null ? "" : unit.COMPONENT_LEVEL.Replace("'", "''")) + "'"
                    + " , [COMPTYPE_CHINESE_NAME] = '" + (unit.COMPTYPE_CHINESE_NAME == null ? "" : unit.COMPTYPE_CHINESE_NAME.Replace("'", "''")) + "'"
                    + " , [COMPTYPE_ENGLISH_NAME] = '" + (unit.COMPTYPE_ENGLISH_NAME == null ? "" : unit.COMPTYPE_ENGLISH_NAME.Replace("'", "''")) + "'"
                    + " , [SHIP_PROVE_CODE] = '" + (unit.SHIP_PROVE_CODE == null ? "" : unit.SHIP_PROVE_CODE.Replace("'", "''")) + "'"
                    + " , [LETTER_NUMBER] = '" + (unit.LETTER_NUMBER == null ? "" : unit.LETTER_NUMBER.Replace("'", "''")) + "'"
                    + " , [MANUFACTURER] = '" + (unit.MANUFACTURER == null ? "" : unit.MANUFACTURER.Replace("'", "''")) + "'"
                    + " , [USE_POSITION] = '" + (unit.USE_POSITION == null ? "" : unit.USE_POSITION.Replace("'", "''")) + "'"
                    + " , [COMPONENT_STYLE] = N'" + (unit.COMPONENT_STYLE == null ? "" : unit.COMPONENT_STYLE.Replace("'", "''")) + "'"
                    + " , [SERVICE_PROVIDER] = '" + (unit.SERVICE_PROVIDER == null ? "" : unit.SERVICE_PROVIDER.Replace("'", "''")) + "'"
                    + " , [DEFAULT_USE_RATE] = " + unit.DEFAULT_USE_RATE
                    + " , [CREATOR] = '" + (unit.CREATOR == null ? "" : unit.CREATOR.Replace("'", "''")) + "'"
                    + " , [TIMING_TYPE] = " + unit.TIMING_TYPE
                    + " , [HEADSHIP] =  " + (string.IsNullOrEmpty(unit.HEADSHIP) ? "null" :"'" + unit.HEADSHIP.Replace("'", "''") + "'")
                    + " , [UPDATETIME] = getdate()"
                    + " , [SAFEEQUIPMENT] = " + unit.SAFEEQUIPMENT
                    + " , [sort_no] = " + unit.SORT_NO
                    + " , [detail] = N'" + (unit.DETAIL == null ? "" : unit.DETAIL.Replace("'", "''")) + "'"                  
                    + " where upper(COMPONENT_TYPE_ID) = '" + unit.COMPONENT_TYPE_ID.ToUpper() + "'";
            }
            else
            {
                unit.COMPONENT_TYPE_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_COMPONENT_TYPE] ("
                    + "[COMPONENT_TYPE_ID],"
                    + "[SUPERIOR_COMPONENT],"
                    + "[CODE_SYSTEM_INDEX],"
                    + "[COMPONENT_LEVEL],"
                    + "[COMPTYPE_CHINESE_NAME],"
                    + "[COMPTYPE_ENGLISH_NAME],"
                    + "[SHIP_PROVE_CODE],"
                    + "[LETTER_NUMBER],"
                    + "[MANUFACTURER],"
                    + "[USE_POSITION],"
                    + "[COMPONENT_STYLE],"
                    + "[SERVICE_PROVIDER],"
                    + "[DEFAULT_USE_RATE],"
                    + "[CREATOR],"
                    + "[CREATETIME],"
                    + "[TIMING_TYPE],"
                    + "[HEADSHIP]," 
                    + "[SAFEEQUIPMENT],"
                    + "[sort_no],[detail]"
                    + ") VALUES( "
                    + " '" + (unit.COMPONENT_TYPE_ID == null ? "" : unit.COMPONENT_TYPE_ID.Replace("'", "''")) + "'"
                    + " , '" + (unit.SUPERIOR_COMPONENT == null ? "" : unit.SUPERIOR_COMPONENT.Replace("'", "''")) + "'"
                    + " , '" + (unit.CODE_SYSTEM_INDEX == null ? "" : unit.CODE_SYSTEM_INDEX.Replace("'", "''")) + "'"
                    + " , '" + (unit.COMPONENT_LEVEL == null ? "" : unit.COMPONENT_LEVEL.Replace("'", "''")) + "'"
                    + " , '" + (unit.COMPTYPE_CHINESE_NAME == null ? "" : unit.COMPTYPE_CHINESE_NAME.Replace("'", "''")) + "'"
                    + " , '" + (unit.COMPTYPE_ENGLISH_NAME == null ? "" : unit.COMPTYPE_ENGLISH_NAME.Replace("'", "''")) + "'"
                    + " , '" + (unit.SHIP_PROVE_CODE == null ? "" : unit.SHIP_PROVE_CODE.Replace("'", "''")) + "'"
                    + " , '" + (unit.LETTER_NUMBER == null ? "" : unit.LETTER_NUMBER.Replace("'", "''")) + "'"
                    + " , '" + (unit.MANUFACTURER == null ? "" : unit.MANUFACTURER.Replace("'", "''")) + "'"
                    + " , '" + (unit.USE_POSITION == null ? "" : unit.USE_POSITION.Replace("'", "''")) + "'"
                    + " , N'" + (unit.COMPONENT_STYLE == null ? "" : unit.COMPONENT_STYLE.Replace("'", "''")) + "'"
                    + " , '" + (unit.SERVICE_PROVIDER == null ? "" : unit.SERVICE_PROVIDER.Replace("'", "''")) + "'"
                    + " ," + unit.DEFAULT_USE_RATE
                    + " , '" + (unit.CREATOR == null ? "" : unit.CREATOR.Replace("'", "''")) + "'"
                    + " ,getdate()" 
                    + " ," + unit.TIMING_TYPE
                    + " , " + (string.IsNullOrEmpty(unit.HEADSHIP) ? "null" : "'" + unit.HEADSHIP.Replace("'", "''") + "'")
                    + " ," + unit.SAFEEQUIPMENT
                    + " ," + unit.SORT_NO
                    + " ,N'" + (unit.DETAIL == null ? "" : unit.DETAIL.Replace("'", "''")) + "'"    
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_COMPONENT_TYPE中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_COMPONENT_TYPE对象</param>
        public bool deleteUnit(ComponentType unit, out string err)
        {
            return deleteUnit(unit.COMPONENT_TYPE_ID, out err);
        }

        /// <summary>
        /// 删除数据表T_COMPONENT_TYPE中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_COMPONENT_TYPE.cOMPONENT_TYPE_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_COMPONENT_TYPE where "
                + " upper(T_COMPONENT_TYPE.COMPONENT_TYPE_ID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_COMPONENT_TYPE 所有数据信息.
        /// </summary>
        /// <returns>T_COMPONENT_TYPE DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
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
                + "  from T_COMPONENT_TYPE ";
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
        /// 根据一个主键ID,得到 T_COMPONENT_TYPE 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>ComponentType DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
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
                + " from T_COMPONENT_TYPE "
                + " where upper(COMPONENT_TYPE_ID)='" + Id.ToUpper() + "'";
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
        /// 根据componenttype 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>componenttype 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBoxEx.Show(o);
        public ComponentType getObject(DataRow dr)
        {
            ComponentType unit = new ComponentType();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造ComponentType类对象!";
                return unit;
            }
            if (DBNull.Value != dr["COMPONENT_TYPE_ID"])
                unit.COMPONENT_TYPE_ID = dr["COMPONENT_TYPE_ID"].ToString();
            if (DBNull.Value != dr["SUPERIOR_COMPONENT"])
                unit.SUPERIOR_COMPONENT = dr["SUPERIOR_COMPONENT"].ToString();
            if (DBNull.Value != dr["CODE_SYSTEM_INDEX"])
                unit.CODE_SYSTEM_INDEX = dr["CODE_SYSTEM_INDEX"].ToString();
            if (DBNull.Value != dr["COMPONENT_LEVEL"])
                unit.COMPONENT_LEVEL = dr["COMPONENT_LEVEL"].ToString();
            if (DBNull.Value != dr["COMPTYPE_CHINESE_NAME"])
                unit.COMPTYPE_CHINESE_NAME = dr["COMPTYPE_CHINESE_NAME"].ToString();
            if (DBNull.Value != dr["COMPTYPE_ENGLISH_NAME"])
                unit.COMPTYPE_ENGLISH_NAME = dr["COMPTYPE_ENGLISH_NAME"].ToString();
            if (DBNull.Value != dr["SHIP_PROVE_CODE"])
                unit.SHIP_PROVE_CODE = dr["SHIP_PROVE_CODE"].ToString();
            if (DBNull.Value != dr["LETTER_NUMBER"])
                unit.LETTER_NUMBER = dr["LETTER_NUMBER"].ToString();
            if (DBNull.Value != dr["MANUFACTURER"])
                unit.MANUFACTURER = dr["MANUFACTURER"].ToString();
            if (DBNull.Value != dr["USE_POSITION"])
                unit.USE_POSITION = dr["USE_POSITION"].ToString();
            if (DBNull.Value != dr["COMPONENT_STYLE"])
                unit.COMPONENT_STYLE = dr["COMPONENT_STYLE"].ToString();
            if (DBNull.Value != dr["SERVICE_PROVIDER"])
                unit.SERVICE_PROVIDER = dr["SERVICE_PROVIDER"].ToString();
            if (DBNull.Value != dr["DEFAULT_USE_RATE"])
                unit.DEFAULT_USE_RATE = Convert.ToDecimal(dr["DEFAULT_USE_RATE"]);
            if (DBNull.Value != dr["CREATOR"])
                unit.CREATOR = dr["CREATOR"].ToString(); 
            if (DBNull.Value != dr["TIMING_TYPE"])
                unit.TIMING_TYPE = Convert.ToDecimal(dr["TIMING_TYPE"]);
            if (DBNull.Value != dr["HEADSHIP"])
                unit.HEADSHIP = dr["HEADSHIP"].ToString(); 
            if (DBNull.Value != dr["SAFEEQUIPMENT"])
                unit.SAFEEQUIPMENT = Convert.ToDecimal(dr["SAFEEQUIPMENT"]);
            if (DBNull.Value != dr["sort_no"])
                unit.SORT_NO = Convert.ToDecimal(dr["sort_no"]);
            if (DBNull.Value != dr["detail"])
                unit.DETAIL = dr["detail"].ToString();
            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个ComponentType对象.
        /// </summary>
        /// <param name="cOMPONENT_TYPE_ID">cOMPONENT_TYPE_ID</param>
        /// <returns>ComponentType对象</returns>
        public ComponentType getObject(string Id, out string err)
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
        #endregion
    }
}
