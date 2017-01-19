/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：SpareInfoService.cs
 * 创 建 人：徐正本
 * 创建时间：2011/5/24
 * 标    题：数据操作类
 * 功能描述：T_SPARE数据操作类
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
    /// 数据层实例化接口类 dbo.T_SPAREService.cs
    /// </summary>
    public partial class SpareInfoService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static SpareInfoService instance = new SpareInfoService();
        public static SpareInfoService Instance
        {
            get
            {
                if (null == instance)
                {
                    SpareInfoService.instance = new SpareInfoService();
                }
                return SpareInfoService.instance;
            }
        }
        private SpareInfoService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">SpareInfo对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(SpareInfo unit, out string err)
        {
            if (unit.SPARE_ID != null && unit.SPARE_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_SPARE] SET "
                    + " [SPARE_ID] = " + (string.IsNullOrEmpty(unit.SPARE_ID) ? "null" : "'" + unit.SPARE_ID.Replace("'", "''") + "'")
                    + " , [SPARE_NAME] = N" + (unit.SPARE_NAME == null ? "" : "'" + unit.SPARE_NAME.Replace("'", "''")) + "'"
                    + " , [SPARE_ENAME] = N" + (unit.SPARE_ENAME == null ? "" : "'" + unit.SPARE_ENAME.Replace("'", "''")) + "'"
                    + " , [PARTNUMBER] = N" + (unit.PARTNUMBER == null ? "" : "'" + unit.PARTNUMBER.Replace("'", "''")) + "'"
                    + " , [PICNUMBER] = N" + (unit.PICNUMBER == null ? "" : "'" + unit.PICNUMBER.Replace("'", "''")) + "'"
                    + " , [PICCODE] = " + (unit.PICCODE == null ? "" : "'" + unit.PICCODE.Replace("'", "''")) + "'"
                    + " , [SPARESTUFF] = " + (unit.SPARESTUFF == null ? "" : "'" + unit.SPARESTUFF.Replace("'", "''")) + "'"
                    + " , [ATTACHCOMP] = " + (unit.ATTACHCOMP == null ? "" : "'" + unit.ATTACHCOMP.Replace("'", "''")) + "'"
                    + " , [ATTACHTYPE] = " + (unit.ATTACHTYPE == null ? "" : "'" + unit.ATTACHTYPE.Replace("'", "''")) + "'"
                    + " , [REMARK] = N" + (unit.REMARK == null ? "" : "'" + unit.REMARK.Replace("'", "''")) + "'"
                    + " , [ISSPECIALSP] = " + unit.ISSPECIALSP.ToString()
                    + " , [ALERTSTOCK] = " + unit.ALERTSTOCK.ToString()
                    + " , [PARTNUMBER_HIS1] = N" + (unit.PARTNUMBER_HIS1 == null ? "" : "'" + unit.PARTNUMBER_HIS1.Replace("'", "''")) + "'"
                    + " , [PARTNUMBER_HIS2] = N" + (unit.PARTNUMBER_HIS2 == null ? "" : "'" + unit.PARTNUMBER_HIS2.Replace("'", "''")) + "'"
                    + " , [UNIT_NAME] = " + (unit.UNIT_NAME == null ? "" : "'" + unit.UNIT_NAME.Replace("'", "''")) + "'"
                    + " where upper(SPARE_ID) = '" + unit.SPARE_ID.ToUpper() + "'";
            }
            else
            {
                unit.SPARE_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_SPARE] ("
                    + "[SPARE_ID],"
                    + "[SPARE_NAME],"
                    + "[SPARE_ENAME],"
                    + "[PARTNUMBER],"
                    + "[PICNUMBER],"
                    + "[PICCODE],"
                    + "[SPARESTUFF],"
                    + "[ATTACHCOMP],"
                    + "[ATTACHTYPE],"
                    + "[REMARK],"
                    + "[ISSPECIALSP],"
                    + "[ALERTSTOCK],"
                    + "[PARTNUMBER_HIS1],"
                    + "[PARTNUMBER_HIS2],"
                    + "[UNIT_NAME]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.SPARE_ID) ? "null" : "'" + unit.SPARE_ID.Replace("'", "''") + "'")
                    + " , N" + (unit.SPARE_NAME == null ? "''" : "'" + unit.SPARE_NAME.Replace("'", "''")) + "'"
                    + " , N" + (unit.SPARE_ENAME == null ? "''" : "'" + unit.SPARE_ENAME.Replace("'", "''")) + "'"
                    + " , N" + (unit.PARTNUMBER == null ? "''" : "'" + unit.PARTNUMBER.Replace("'", "''")) + "'"
                    + " , N" + (unit.PICNUMBER == null ? "''" : "'" + unit.PICNUMBER.Replace("'", "''")) + "'"
                    + " , " + (unit.PICCODE == null ? "''" : "'" + unit.PICCODE.Replace("'", "''")) + "'"
                    + " , " + (unit.SPARESTUFF == null ? "''" : "'" + unit.SPARESTUFF.Replace("'", "''")) + "'"
                    + " , " + (unit.ATTACHCOMP == null ? "''" : "'" + unit.ATTACHCOMP.Replace("'", "''")) + "'"
                    + " , " + (unit.ATTACHTYPE == null ? "''" : "'" + unit.ATTACHTYPE.Replace("'", "''")) + "'"
                    + " , N" + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''")) + "'"
                    + " , " + unit.ISSPECIALSP.ToString()
                    + " ," + unit.ALERTSTOCK.ToString()
                    + " , N" + (unit.PARTNUMBER_HIS1 == null ? "''" : "'" + unit.PARTNUMBER_HIS1.Replace("'", "''")) + "'"
                    + " , N" + (unit.PARTNUMBER_HIS2 == null ? "''" : "'" + unit.PARTNUMBER_HIS2.Replace("'", "''")) + "'"
                    + " , " + (unit.UNIT_NAME == null ? "''" : "'" + unit.UNIT_NAME.Replace("'", "''")) + "'"
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_SPARE中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_SPARE对象</param>
        internal bool deleteUnit(SpareInfo unit, out string err)
        {
            return deleteUnit(unit.SPARE_ID, out err);
        }

        /// <summary>
        /// 删除数据表T_SPARE中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_SPARE.sPARE_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_SPARE where "
                + " upper(T_SPARE.SPARE_ID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }

        /// <summary>
        /// 提交SQL执行. 2014.2.18 刘子建增加.
        /// </summary>
        /// <param name="lstSQL"></param>
        /// <param name="err"></param>
        public bool SubmitSql(List<string> lstSQL, out string err)
        {
            return dbAccess.ExecSql(lstSQL, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_SPARE 所有数据信息.
        /// </summary>
        /// <returns>T_SPARE DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "SPARE_ID"
                + ",SPARE_NAME"
                + ",SPARE_ENAME"
                + ",PARTNUMBER"
                + ",PICNUMBER"
                + ",PICCODE"
                + ",SPARESTUFF"
                + ",ATTACHCOMP"
                + ",ATTACHTYPE"
                + ",REMARK"
                + ",ISSPECIALSP"
                + ",ALERTSTOCK"
                + ",PARTNUMBER_HIS1"
                + ",PARTNUMBER_HIS2"
                + ",UNIT_NAME"
                + "  from T_SPARE ";
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
        /// 根据一个主键ID,得到 T_SPARE 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>SpareInfo DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "SPARE_ID"
                + ",SPARE_NAME"
                + ",SPARE_ENAME"
                + ",PARTNUMBER"
                + ",PICNUMBER"
                + ",PICCODE"
                + ",SPARESTUFF"
                + ",ATTACHCOMP"
                + ",ATTACHTYPE"
                + ",REMARK"
                + ",ISSPECIALSP"
                + ",ALERTSTOCK"
                + ",PARTNUMBER_HIS1"
                + ",PARTNUMBER_HIS2"
                + ",UNIT_NAME"
                + " from T_SPARE "
                + " where upper(SPARE_ID)='" + Id.ToUpper() + "'";
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
        /// 根据spareinfo 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>spareinfo 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
        public SpareInfo getObject(DataRow dr)
        {
            SpareInfo unit = new SpareInfo();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造SpareInfo类对象!";
                return unit;
            }
            if (DBNull.Value != dr["SPARE_ID"])
                unit.SPARE_ID = dr["SPARE_ID"].ToString();
            if (DBNull.Value != dr["SPARE_NAME"])
                unit.SPARE_NAME = dr["SPARE_NAME"].ToString();
            if (DBNull.Value != dr["SPARE_ENAME"])
                unit.SPARE_ENAME = dr["SPARE_ENAME"].ToString();
            if (DBNull.Value != dr["PARTNUMBER"])
                unit.PARTNUMBER = dr["PARTNUMBER"].ToString();
            if (DBNull.Value != dr["PICNUMBER"])
                unit.PICNUMBER = dr["PICNUMBER"].ToString();
            if (DBNull.Value != dr["PICCODE"])
                unit.PICCODE = dr["PICCODE"].ToString();
            if (DBNull.Value != dr["SPARESTUFF"])
                unit.SPARESTUFF = dr["SPARESTUFF"].ToString();
            if (DBNull.Value != dr["ATTACHCOMP"])
                unit.ATTACHCOMP = dr["ATTACHCOMP"].ToString();
            if (DBNull.Value != dr["ATTACHTYPE"])
                unit.ATTACHTYPE = dr["ATTACHTYPE"].ToString();
            if (DBNull.Value != dr["REMARK"])
                unit.REMARK = dr["REMARK"].ToString();
            if (DBNull.Value != dr["ISSPECIALSP"])
                unit.ISSPECIALSP = Convert.ToByte(dr["ISSPECIALSP"]);
            if (DBNull.Value != dr["ALERTSTOCK"])
                unit.ALERTSTOCK = Convert.ToDecimal(dr["ALERTSTOCK"]);
            if (DBNull.Value != dr["PARTNUMBER_HIS1"])
                unit.PARTNUMBER_HIS1 = dr["PARTNUMBER_HIS1"].ToString();
            if (DBNull.Value != dr["PARTNUMBER_HIS2"])
                unit.PARTNUMBER_HIS2 = dr["PARTNUMBER_HIS2"].ToString();
            if (DBNull.Value != dr["UNIT_NAME"])
                unit.UNIT_NAME = dr["UNIT_NAME"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个SpareInfo对象.
        /// </summary>
        /// <param name="sPARE_ID">sPARE_ID</param>
        /// <returns>SpareInfo对象</returns>
        public SpareInfo getObject(string Id, out string err)
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
    }
}
