/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：ShipWareHouseService.cs
 * 创 建 人：xuzhengben
 * 创建时间：2010/9/15
 * 标    题：数据操作类
 * 功能描述：T_SOM_WAREHOUSE数据操作类
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
using BaseInfo.DataObject;

namespace BaseInfo.DataAccess
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_SOM_WAREHOUSEService.cs
    /// </summary>
    public partial class ShipWareHouseService : IObjectsService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static ShipWareHouseService instance = new ShipWareHouseService();
        public static ShipWareHouseService Instance
        {
            get
            {
                if (null == instance)
                {
                    ShipWareHouseService.instance = new ShipWareHouseService();
                }
                return ShipWareHouseService.instance;
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
        /// <param name="unit">ShipWareHouse对象</param>
        /// <returns>插入的对象更新</returns>	
        public bool saveUnit(ShipWareHouse unit, out string err)
        {
            if (unit.WAREHOUSE_ID != null && unit.WAREHOUSE_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_SOM_WAREHOUSE] SET "
                    + " [WAREHOUSE_ID] = " + (string.IsNullOrEmpty(unit.WAREHOUSE_ID) ? "null" : "'" + unit.WAREHOUSE_ID.Replace("'", "''") + "'")
                    + " , [WAREHOUSE_NAME] = " + (unit.WAREHOUSE_NAME == null ? "" : "'" + unit.WAREHOUSE_NAME.Replace("'", "''")) + "'"
                    + " , [REMARK] = " + (unit.REMARK == null ? "" : "'" + unit.REMARK.Replace("'", "''")) + "'"
                    + " , [WAREHOUSE_CODE] = " + (unit.WAREHOUSE_CODE == null ? "" : "'" + unit.WAREHOUSE_CODE.Replace("'", "''")) + "'"
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " where upper(WAREHOUSE_ID) = '" + unit.WAREHOUSE_ID.ToUpper() + "'";
            }
            else
            {
                unit.WAREHOUSE_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_SOM_WAREHOUSE] ("
                    + "[WAREHOUSE_ID],"
                    + "[WAREHOUSE_NAME],"
                    + "[REMARK],"
                    + "[WAREHOUSE_CODE],"
                    + "[SHIP_ID]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.WAREHOUSE_ID) ? "null" : "'" + unit.WAREHOUSE_ID.Replace("'", "''") + "'")
                    + " , " + (unit.WAREHOUSE_NAME == null ? "''" : "'" + unit.WAREHOUSE_NAME.Replace("'", "''")) + "'"
                    + " , " + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''")) + "'"
                    + " , " + (unit.WAREHOUSE_CODE == null ? "''" : "'" + unit.WAREHOUSE_CODE.Replace("'", "''")) + "'"
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_SOM_WAREHOUSE中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_SOM_WAREHOUSE对象</param>
        public bool deleteUnit(ShipWareHouse unit, out string err)
        {
            return deleteUnit(unit.WAREHOUSE_ID, out err);
        }

        /// <summary>
        /// 删除数据表T_SOM_WAREHOUSE中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_SOM_WAREHOUSE.wAREHOUSE_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_SOM_WAREHOUSE where "
                + " upper(T_SOM_WAREHOUSE.WAREHOUSE_ID)='" + unitid.ToUpper() + "'";

            Console.WriteLine(sql);
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体 改过了不能随便覆盖
        /// <summary>
        /// 得到  T_SOM_WAREHOUSE 所有数据信息.
        /// </summary>
        /// <returns>T_SOM_WAREHOUSE DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "WAREHOUSE_ID"
                + ",WAREHOUSE_NAME"
                + ",t1.REMARK"
                + ",WAREHOUSE_CODE"
                + ",t1.SHIP_ID"
                + ",t2.SHIP_NAME"
                + "\rfrom T_SOM_WAREHOUSE t1"
                + "\rinner join T_SHIP t2 on t1.ship_ID = t2.SHIP_ID"
                + "\rorder by t2.ship_code,t1.WAREHOUSE_CODE";
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
        /// 得到  T_SOM_WAREHOUSE 所有数据信息.
        /// </summary>
        /// <returns>T_SOM_WAREHOUSE DataTable</returns>
        public DataTable getInfoByShipId(string shipId,out string err)
        {
            sql = "select	"
                + "WAREHOUSE_ID"
                + ",WAREHOUSE_NAME"
                + ",t1.REMARK"
                + ",WAREHOUSE_CODE"
                + ",t1.SHIP_ID"
                + ",t2.SHIP_NAME"
                + "\rfrom T_SOM_WAREHOUSE t1"
                + "\rinner join T_SHIP t2 on t1.ship_ID = t2.SHIP_ID"
                + "\rwhere t1.ship_id = '" + shipId.Replace("'", "''") + "'"
                + "\rorder by t2.ship_code,t1.WAREHOUSE_CODE";
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
        /// 根据一个主键ID,得到 T_SOM_WAREHOUSE 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>ShipWareHouse DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "WAREHOUSE_ID"
                + ",WAREHOUSE_NAME"
                + ",t1.REMARK"
                + ",WAREHOUSE_CODE"
                + ",t1.SHIP_ID"
                + ",t2.SHIP_NAME"
                + "\rfrom T_SOM_WAREHOUSE t1"
                + "\r inner join T_SHIP t2 on t1.ship_ID = t2.SHIP_ID"
                + "\rwhere upper(WAREHOUSE_ID)='" + Id.ToUpper() + "'";
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
        /// 根据shipwarehouse 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>shipwarehouse 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBoxEx.Show(o);
        public ShipWareHouse getObject(DataRow dr)
        {
            ShipWareHouse unit = new ShipWareHouse();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造ShipWareHouse类对象!";
                return unit;
            }
            if (DBNull.Value != dr["WAREHOUSE_ID"])
                unit.WAREHOUSE_ID = dr["WAREHOUSE_ID"].ToString();
            if (DBNull.Value != dr["WAREHOUSE_NAME"])
                unit.WAREHOUSE_NAME = dr["WAREHOUSE_NAME"].ToString();
            if (DBNull.Value != dr["REMARK"])
                unit.REMARK = dr["REMARK"].ToString();
            if (DBNull.Value != dr["WAREHOUSE_CODE"])
                unit.WAREHOUSE_CODE = dr["WAREHOUSE_CODE"].ToString();
            if (DBNull.Value != dr["SHIP_ID"])
                unit.SHIP_ID = dr["SHIP_ID"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个ShipWareHouse对象.
        /// </summary>
        /// <param name="wAREHOUSE_ID">wAREHOUSE_ID</param>
        /// <returns>ShipWareHouse对象</returns>
        public ShipWareHouse getObject(string Id, out string err)
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

        #region IObjectsService 成员

        public CommonOperation.BaseClass.CommonClass GetOneObjectById(string id)
        {
            string err;
            return getObject(id, out err);
        }

        public Dictionary<string, string> GetObjectDisplaySetting()
        {
            Dictionary<string, string> reValue = new Dictionary<string, string>();
            reValue.Add("SHIP_NAME", "船舶");
            reValue.Add("WAREHOUSE_NAME", "仓库名称");
            reValue.Add("WAREHOUSE_CODE", "仓库代码"); 
            return reValue;
        }

        #endregion
    }
}
