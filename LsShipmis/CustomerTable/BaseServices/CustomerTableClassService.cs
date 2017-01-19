/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：CustomerTableClassService.cs
 * 创 建 人：徐正本
 * 创建时间：2010-5-25
 * 标    题：数据操作类
 * 功能描述：T_CTB数据操作类
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
using CommonViewer.BaseControl;

namespace CustomerTable
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_CTBService.cs
    /// </summary>
    public partial class CustomerTableClassService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static CustomerTableClassService instance = new CustomerTableClassService();
        public static CustomerTableClassService Instance
        {
            get
            {
                if (null == instance)
                {
                    CustomerTableClassService.instance = new CustomerTableClassService();
                }
                return CustomerTableClassService.instance;
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
        /// <param name="unit">CustomerTableClass对象</param>
        /// <returns>插入的对象更新</returns>	
        public bool saveUnit(CustomerTableClass unit, out string err)
        {
            if (unit.T_CTB_ID != null && unit.T_CTB_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_CTB] SET "
                    + " [T_CTB_ID] = '" + (unit.T_CTB_ID == null ? "" : unit.T_CTB_ID.Replace("'", "''")) + "'"
                    + " , [CT_CLASS] = '" + (unit.CT_CLASS == null ? "" : unit.CT_CLASS.Replace("'", "''")) + "'"
                    + " , [SEQUNCE] = " + unit.SEQUNCE.ToString() 
                    + " , [CATEGERY01] = '" + (unit.CATEGERY01 == null ? "" : unit.CATEGERY01.Replace("'", "''")) + "'"
                    + " , [CATEGERY02] = '" + (unit.CATEGERY02 == null ? "" : unit.CATEGERY02.Replace("'", "''")) + "'"
                    + " , [CATEGERY03] = '" + (unit.CATEGERY03 == null ? "" : unit.CATEGERY03.Replace("'", "''")) + "'"
                    + " where upper(T_CTB_ID) = '" + unit.T_CTB_ID.ToUpper() + "'";
            }
            else
            {
                unit.T_CTB_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_CTB] ("
                    + "[T_CTB_ID],"
                    + "[CT_CLASS],"
                    + "[SEQUNCE],"
                    + "[CATEGERY01],"
                    + "[CATEGERY02],"
                    + "[CATEGERY03]"
                    + ") VALUES( "
                    + " '" + (unit.T_CTB_ID == null ? "" : unit.T_CTB_ID.Replace("'", "''")) + "'"
                    + " , '" + (unit.CT_CLASS == null ? "" : unit.CT_CLASS.Replace("'", "''")) + "'"
                    + " ," + unit.SEQUNCE.ToString() 
                    + " , '" + (unit.CATEGERY01 == null ? "" : unit.CATEGERY01.Replace("'", "''")) + "'"
                    + " , '" + (unit.CATEGERY02 == null ? "" : unit.CATEGERY02.Replace("'", "''")) + "'"
                    + " , '" + (unit.CATEGERY03 == null ? "" : unit.CATEGERY03.Replace("'", "''")) + "'"
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_CTB中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_CTB对象</param>
        public bool deleteUnit(CustomerTableClass unit, out string err)
        {
            return deleteUnit(unit.T_CTB_ID, out err);
        }

        /// <summary>
        /// 删除数据表T_CTB中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_CTB.t_CTB_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_CTB where "
                + " upper(T_CTB.T_CTB_ID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_CTB 所有数据信息.
        /// </summary>
        /// <returns>T_CTB DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "T_CTB_ID, "
                + "CT_CLASS, "
                + "SEQUNCE, "
                + "CATEGERY01, "
                + "CATEGERY02, "
                + "CATEGERY03"
                + "  from T_CTB order by CT_CLASS,SEQUNCE";
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
        /// 根据一个主键ID,得到 T_CTB 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>CustomerTableClass DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "T_CTB_ID, "
                + "CT_CLASS, "
                + "SEQUNCE, "
                + "CATEGERY01, "
                + "CATEGERY02, "
                + "CATEGERY03"
                + " from T_CTB "
                + " where upper(T_CTB_ID)='" + Id.ToUpper() + "'";
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
        /// 根据customertableclass 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>customertableclass 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBoxEx.Show(o);
        public CustomerTableClass getObject(DataRow dr)
        {
            CustomerTableClass unit = new CustomerTableClass();
            if (null == dr)
            {               
                return unit;
            }
            if (DBNull.Value != dr["T_CTB_ID"])
                unit.T_CTB_ID = dr["T_CTB_ID"].ToString();
            if (DBNull.Value != dr["CT_CLASS"])
                unit.CT_CLASS = dr["CT_CLASS"].ToString();
            if (DBNull.Value != dr["SEQUNCE"])
                unit.SEQUNCE = Convert.ToInt32(dr["SEQUNCE"]);
            if (DBNull.Value != dr["CATEGERY01"])
                unit.CATEGERY01 = dr["CATEGERY01"].ToString();
            if (DBNull.Value != dr["CATEGERY02"])
                unit.CATEGERY02 = dr["CATEGERY02"].ToString();
            if (DBNull.Value != dr["CATEGERY03"])
                unit.CATEGERY03 = dr["CATEGERY03"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个CustomerTableClass对象.
        /// </summary>
        /// <param name="t_CTB_ID">t_CTB_ID</param>
        /// <returns>CustomerTableClass对象</returns>
        public CustomerTableClass getObject(string Id, out string err)
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
