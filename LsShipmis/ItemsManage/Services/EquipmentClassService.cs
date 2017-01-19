/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：EquipmentClassService.cs
 * 创 建 人：xuzhengben
 * 创建时间：2011/4/28
 * 标    题：数据操作类
 * 功能描述：T_EQUIPMENT_CLASS数据操作类
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
    /// 数据层实例化接口类 dbo.T_EQUIPMENT_CLASSService.cs
    /// </summary>
    public partial class EquipmentClassService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static EquipmentClassService instance = new EquipmentClassService();
        public static EquipmentClassService Instance
        {
            get
            {
                if (null == instance)
                {
                    EquipmentClassService.instance = new EquipmentClassService();
                }
                return EquipmentClassService.instance;
            }
        }
        private EquipmentClassService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">EquipmentClass对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(EquipmentClass unit, out string err)
        {
            if (unit.CLASSID != null && unit.CLASSID.Length > 0) //edit
            {
                sql = "UPDATE [T_EQUIPMENT_CLASS] SET "
                    + " [CLASSID] = " + (string.IsNullOrEmpty(unit.CLASSID) ? "null" : "'" + unit.CLASSID.Replace("'", "''") + "'")
                    + " , [CLASSCODE] = " + (unit.CLASSCODE == null ? "" : "'" + unit.CLASSCODE.Replace("'", "''")) + "'"
                    + " , [CLASSNAME] = " + (unit.CLASSNAME == null ? "" : "'" + unit.CLASSNAME.Replace("'", "''")) + "'"
                    + " , [CLASSTYPE] = " + unit.CLASSTYPE.ToString()
                    + " , [CLASSDETAIL] = " + (unit.CLASSDETAIL == null ? "" : "'" + unit.CLASSDETAIL.Replace("'", "''")) + "'"
                    + " , [SORTNO] = " + unit.SORTNO.ToString()
                    + " , [PARENTCLASSID] = " + (string.IsNullOrEmpty(unit.PARENTCLASSID) ? "null" : "'" + unit.PARENTCLASSID.Replace("'", "''") + "'")
                    + " where upper(CLASSID) = '" + unit.CLASSID.ToUpper() + "'";
            }
            else
            {
                unit.CLASSID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_EQUIPMENT_CLASS] ("
                    + "[CLASSID],"
                    + "[CLASSCODE],"
                    + "[CLASSNAME],"
                    + "[CLASSTYPE],"
                    + "[CLASSDETAIL],"
                    + "[SORTNO],"
                    + "[PARENTCLASSID]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.CLASSID) ? "null" : "'" + unit.CLASSID.Replace("'", "''") + "'")
                    + " , " + (unit.CLASSCODE == null ? "''" : "'" + unit.CLASSCODE.Replace("'", "''")) + "'"
                    + " , " + (unit.CLASSNAME == null ? "''" : "'" + unit.CLASSNAME.Replace("'", "''")) + "'"
                    + " ," + unit.CLASSTYPE.ToString()
                    + " , " + (unit.CLASSDETAIL == null ? "''" : "'" + unit.CLASSDETAIL.Replace("'", "''")) + "'"
                    + " ," + unit.SORTNO.ToString()
                    + " , " + (string.IsNullOrEmpty(unit.PARENTCLASSID) ? "null" : "'" + unit.PARENTCLASSID.Replace("'", "''") + "'")
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
    
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_EQUIPMENT_CLASS 所有数据信息.
        /// </summary>
        /// <returns>T_EQUIPMENT_CLASS DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "CLASSID"
                + ",CLASSCODE"
                + ",CLASSNAME"
                + ",CLASSTYPE"
                + ",CLASSDETAIL"
                + ",SORTNO"
                + ",PARENTCLASSID"
                + "  from T_EQUIPMENT_CLASS ";
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
        /// 根据一个主键ID,得到 T_EQUIPMENT_CLASS 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>EquipmentClass DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "CLASSID"
                + ",CLASSCODE"
                + ",CLASSNAME"
                + ",CLASSTYPE"
                + ",CLASSDETAIL"
                + ",SORTNO"
                + ",PARENTCLASSID"
                + " from T_EQUIPMENT_CLASS "
                + " where upper(CLASSID)='" + Id.ToUpper() + "'";
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
        /// 根据equipmentclass 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>equipmentclass 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBoxEx.Show(o);
        public EquipmentClass getObject(DataRow dr)
        {
            EquipmentClass unit = new EquipmentClass();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造EquipmentClass类对象!";
                return unit;
            }
            if (DBNull.Value != dr["CLASSID"])
                unit.CLASSID = dr["CLASSID"].ToString();
            if (DBNull.Value != dr["CLASSCODE"])
                unit.CLASSCODE = dr["CLASSCODE"].ToString();
            if (DBNull.Value != dr["CLASSNAME"])
                unit.CLASSNAME = dr["CLASSNAME"].ToString();
            if (DBNull.Value != dr["CLASSTYPE"])
                unit.CLASSTYPE = Convert.ToDecimal(dr["CLASSTYPE"]);
            if (DBNull.Value != dr["CLASSDETAIL"])
                unit.CLASSDETAIL = dr["CLASSDETAIL"].ToString();
            if (DBNull.Value != dr["SORTNO"])
                unit.SORTNO = Convert.ToDecimal(dr["SORTNO"]);
            if (DBNull.Value != dr["PARENTCLASSID"])
                unit.PARENTCLASSID = dr["PARENTCLASSID"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个EquipmentClass对象.
        /// </summary>
        /// <param name="cLASSID">cLASSID</param>
        /// <returns>EquipmentClass对象</returns>
        public EquipmentClass getObject(string Id, out string err)
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

        internal bool resortClass(string parentId, out string err)
        { 
            //得到当前设备所在设备分类的classid,并对之排序; 
            if (!string.IsNullOrEmpty(parentId))
            {
                sql = "exec dbo.P_Resort_Class '" + parentId + "'";
                return dbAccess.ExecSql(sql, out err);
            }
            else
            {
                sql = "exec dbo.P_Resort_Class ''";
                return dbAccess.ExecSql(sql, out err);
            }
        }

        /// <summary>
        /// 删除数据表T_EQUIPMENT_CLASS中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_EQUIPMENT_CLASS对象</param>
        internal bool deleteUnit(EquipmentClass unit, out string err)
        {
            List<string> sqls = new List<string>();
            sql = "delete from T_EQUIPMENT_CLASS where "
                + " T_EQUIPMENT_CLASS.CLASSID='" + unit.GetId() + "'";
            sqls.Add(sql);
            sql = "exec dbo.P_Resort_Class '" + unit.PARENTCLASSID + "'";
            sqls.Add(sql);
            return dbAccess.ExecSql(sqls, out err);
        } 
    }
}
