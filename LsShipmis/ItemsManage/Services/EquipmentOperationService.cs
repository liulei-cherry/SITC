/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：EquipmentOperationService.cs
 * 创 建 人：xuzhengben
 * 创建时间：2011/4/22
 * 标    题：数据操作类
 * 功能描述：T_EQUIPMENT_OPERATION数据操作类
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
    /// 数据层实例化接口类 dbo.T_EQUIPMENT_OPERATIONService.cs
    /// </summary>
    public partial class EquipmentOperationService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static EquipmentOperationService instance = new EquipmentOperationService();
        public static EquipmentOperationService Instance
        {
            get
            {
                if (null == instance)
                {
                    EquipmentOperationService.instance = new EquipmentOperationService();
                }
                return EquipmentOperationService.instance;
            }
        }
        private EquipmentOperationService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">EquipmentOperation对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(EquipmentOperation unit, out string err)
        {
            if (unit.EQUOPERATIONID != null && unit.EQUOPERATIONID.Length > 0) //edit
            {
                sql = "UPDATE [T_EQUIPMENT_OPERATION] SET "
                    + " [EQUOPERATIONID] = " + (string.IsNullOrEmpty(unit.EQUOPERATIONID) ? "null" : "'" + unit.EQUOPERATIONID.Replace("'", "''") + "'")
                    + " , [SORTNO] = " + unit.SORTNO.ToString()
                    + " , [EQUIPMENTID] = " + (string.IsNullOrEmpty(unit.EQUIPMENTID) ? "null" : "'" + unit.EQUIPMENTID.Replace("'", "''") + "'")
                    + " , [OPERATIONNAME] = " + (unit.OPERATIONNAME == null ? "" : "'" + unit.OPERATIONNAME.Replace("'", "''")) + "'"
                    + " , [OPERATIONDETAIL] = " + (unit.OPERATIONDETAIL == null ? "" : "'" + unit.OPERATIONDETAIL.Replace("'", "''")) + "'"
                    + " where upper(EQUOPERATIONID) = '" + unit.EQUOPERATIONID.ToUpper() + "'";
            }
            else
            {
                unit.EQUOPERATIONID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_EQUIPMENT_OPERATION] ("
                    + "[EQUOPERATIONID],"
                    + "[SORTNO],"
                    + "[EQUIPMENTID],"
                    + "[OPERATIONNAME],"
                    + "[OPERATIONDETAIL]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.EQUOPERATIONID) ? "null" : "'" + unit.EQUOPERATIONID.Replace("'", "''") + "'")
                    + " ," + unit.SORTNO.ToString()
                    + " , " + (string.IsNullOrEmpty(unit.EQUIPMENTID) ? "null" : "'" + unit.EQUIPMENTID.Replace("'", "''") + "'")
                    + " , " + (unit.OPERATIONNAME == null ? "''" : "'" + unit.OPERATIONNAME.Replace("'", "''")) + "'"
                    + " , " + (unit.OPERATIONDETAIL == null ? "''" : "'" + unit.OPERATIONDETAIL.Replace("'", "''")) + "'"
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_EQUIPMENT_OPERATION中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_EQUIPMENT_OPERATION对象</param>
        internal bool deleteUnit(EquipmentOperation unit, out string err)
        {
            return deleteUnit(unit.EQUOPERATIONID, out err);
        }

        /// <summary>
        /// 删除数据表T_EQUIPMENT_OPERATION中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_EQUIPMENT_OPERATION.eQUOPERATIONID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_EQUIPMENT_OPERATION where "
                + " upper(T_EQUIPMENT_OPERATION.EQUOPERATIONID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_EQUIPMENT_OPERATION 所有数据信息.
        /// </summary>
        /// <returns>T_EQUIPMENT_OPERATION DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "EQUOPERATIONID"
                + ",SORTNO"
                + ",EQUIPMENTID"
                + ",OPERATIONNAME"
                + ",OPERATIONDETAIL"
                + "  from T_EQUIPMENT_OPERATION ";
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
        /// 根据一个主键ID,得到 T_EQUIPMENT_OPERATION 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>EquipmentOperation DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "EQUOPERATIONID"
                + ",SORTNO"
                + ",EQUIPMENTID"
                + ",OPERATIONNAME"
                + ",OPERATIONDETAIL"
                + " from T_EQUIPMENT_OPERATION "
                + " where upper(EQUOPERATIONID)='" + Id.ToUpper() + "'";
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
        /// 根据equipmentoperation 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>equipmentoperation 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBoxEx.Show(o);
        public EquipmentOperation getObject(DataRow dr)
        {
            EquipmentOperation unit = new EquipmentOperation();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造EquipmentOperation类对象!";
                return unit;
            }
            if (DBNull.Value != dr["EQUOPERATIONID"])
                unit.EQUOPERATIONID = dr["EQUOPERATIONID"].ToString();
            if (DBNull.Value != dr["SORTNO"])
                unit.SORTNO = Convert.ToInt32(dr["SORTNO"]);
            if (DBNull.Value != dr["EQUIPMENTID"])
                unit.EQUIPMENTID = dr["EQUIPMENTID"].ToString();
            if (DBNull.Value != dr["OPERATIONNAME"])
                unit.OPERATIONNAME = dr["OPERATIONNAME"].ToString();
            if (DBNull.Value != dr["OPERATIONDETAIL"])
                unit.OPERATIONDETAIL = dr["OPERATIONDETAIL"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个EquipmentOperation对象.
        /// </summary>
        /// <param name="eQUOPERATIONID">eQUOPERATIONID</param>
        /// <returns>EquipmentOperation对象</returns>
        public EquipmentOperation getObject(string Id, out string err)
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

        public EquipmentOperation GetObjectByEquipmentIdAndName(string equipmentId, string name)
        {
            string err;
            sql = "select "
                + "EQUOPERATIONID"
                + ",SORTNO"
                + ",EQUIPMENTID"
                + ",OPERATIONNAME"
                + ",OPERATIONDETAIL"
                + " from T_EQUIPMENT_OPERATION "
                + " where EQUIPMENTID = '" + equipmentId + "' and OPERATIONNAME= '" + name + "'";
            DataTable dt;
            if (dbAccess.GetDataTable(sql, out dt, out err) && dt.Rows.Count >0)
            {
                return getObject(dt.Rows[0]);
            }
            else
            {
                return null;
            }
        }
    }
}
