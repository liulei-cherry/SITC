/****************************************************************************************************
* Copyright (C) 2008 大连陆海科技有限公司 版权所有
* 文 件 名：BaseRightService.cs
* 创 建 人：xuzhengben
* 创建时间：2010/9/1
* 标    题：数据操作类
* 功能描述：T_RIGHT数据操作类
* 修 改 人：
* 修改时间：
* 修改内容：
****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonOperation.BaseClass;
using CommonOperation.Interfaces;

namespace CommonOperation.Functions
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_RIGHTService.cs
    /// </summary>
    internal class BaseRightService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static BaseRightService instance = new BaseRightService();
        public static BaseRightService Instance
        {
            get
            {
                if (null == instance)
                {
                    BaseRightService.instance = new BaseRightService();
                }
                return BaseRightService.instance;
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
        /// <param name="unit">BaseRight对象</param>
        /// <returns>插入的对象更新</returns>	
        public bool saveUnit(BaseRight unit, out string err)
        {
            if (unit.RIGHT_ID != null && unit.RIGHT_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_RIGHT] SET "
                    + " [RIGHT_ID] = " + (string.IsNullOrEmpty(unit.RIGHT_ID) ? "null" : "'" + unit.RIGHT_ID.Replace("'", "''") + "'")
                    + " , [RIGHT_NAME] = " + (unit.RIGHT_NAME == null ? "" : "'" + unit.RIGHT_NAME.Replace("'", "''")) + "'"
                    + " , [MODULE] = " + (unit.MODULE == null ? "" : "'" + unit.MODULE.Replace("'", "''")) + "'"
                    + " , [REMARK] = " + (unit.REMARK == null ? "" : "'" + unit.REMARK.Replace("'", "''")) + "'"
                    + " where upper(RIGHT_ID) = '" + unit.RIGHT_ID.ToUpper() + "'";
            }
            else
            {
                unit.RIGHT_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_RIGHT] ("
                    + "[RIGHT_ID],"
                    + "[RIGHT_NAME],"
                    + "[MODULE],"
                    + "[REMARK]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.RIGHT_ID) ? "null" : "'" + unit.RIGHT_ID.Replace("'", "''") + "'")
                    + " , " + (unit.RIGHT_NAME == null ? "''" : "'" + unit.RIGHT_NAME.Replace("'", "''")) + "'"
                    + " , " + (unit.MODULE == null ? "''" : "'" + unit.MODULE.Replace("'", "''")) + "'"
                    + " , " + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''")) + "'"
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_RIGHT中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_RIGHT对象</param>
        public bool deleteUnit(BaseRight unit, out string err)
        {
            return deleteUnit(unit.RIGHT_ID, out err);
        }

        /// <summary>
        /// 删除数据表T_RIGHT中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_RIGHT.rIGHT_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_RIGHT where "
                + " upper(T_RIGHT.RIGHT_ID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_RIGHT 所有数据信息.
        /// </summary>
        /// <returns>T_RIGHT DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "RIGHT_ID"
                + ",RIGHT_NAME"
                + ",MODULE"
                + ",REMARK"
                + "  from T_RIGHT ";
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
        /// 根据一个主键ID,得到 T_RIGHT 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>BaseRight DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "RIGHT_ID"
                + ",RIGHT_NAME"
                + ",MODULE"
                + ",REMARK"
                + " from T_RIGHT "
                + " where upper(RIGHT_ID)='" + Id.ToUpper() + "'";
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
        /// 根据baseright 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>baseright 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBoxEx.Show(o);
        public BaseRight getObject(DataRow dr)
        {
            BaseRight unit = new BaseRight();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造BaseRight类对象!";
                return unit;
            }
            if (DBNull.Value != dr["RIGHT_ID"])
                unit.RIGHT_ID = dr["RIGHT_ID"].ToString();
            if (DBNull.Value != dr["RIGHT_NAME"])
                unit.RIGHT_NAME = dr["RIGHT_NAME"].ToString();
            if (DBNull.Value != dr["MODULE"])
                unit.MODULE = dr["MODULE"].ToString();
            if (DBNull.Value != dr["REMARK"])
                unit.REMARK = dr["REMARK"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个BaseRight对象.
        /// </summary>
        /// <param name="rIGHT_ID">rIGHT_ID</param>
        /// <returns>BaseRight对象</returns>
        public BaseRight getObject(string Id, out string err)
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

        public void InitAllRight()
        {
            string err;
            DataTable dt = BaseRightService.Instance.getInfo(out err);
            string allRightNameTemp = "";
            foreach (string sRightName in ProxyRight.AllRight.Keys)
            {
                if (ProxyRight.AllRight[sRightName] == 3 && ConstParameter.IsLandVersion
                    || ProxyRight.AllRight[sRightName] == 2 && !ConstParameter.IsLandVersion) continue;
                if (dt.Select("RIGHT_NAME = '" + sRightName.Replace("'", "''") + "'").Length == 0)
                {
                    BaseRight br = new BaseRight();
                    br.RIGHT_NAME = sRightName;
                    br.REMARK = sRightName;
                    br.Update(out err);
                }
                allRightNameTemp += "'" + sRightName + "',";
            }
            //随便写的,为了打开FrmWorkInfo视图设计器不出错.
            string allRightName = "'0-0'";
            if (allRightNameTemp.Length > 1)
                allRightName = allRightNameTemp.Substring(0, allRightNameTemp.Length - 1);
            if (dt.Select("RIGHT_NAME not in (" + allRightName + ")").Length > 0)
            {
                sql = "update T_RIGHT set REMARK = '已经无效，不需要再对用户设置此权限' where RIGHT_NAME not in (" + allRightName + ")";
                dbAccess.ExecSql(sql, out err);
                List<string> sqls = new List<string>();
                sqls.Add("delete T_SHIP_USER_RIGHT where RIGHT_ID in (select RIGHT_ID from T_RIGHT where REMARK = '已经无效，不需要再对用户设置此权限' )");
                sqls.Add("delete T_SHIP_HEAD_RIGHT where RIGHT_ID in (select RIGHT_ID from T_RIGHT where REMARK = '已经无效，不需要再对用户设置此权限' )");
                sqls.Add("delete T_RIGHT where RIGHT_ID in (select RIGHT_ID from T_RIGHT where REMARK = '已经无效，不需要再对用户设置此权限' )");
                dbAccess.ExecSql(sqls, out err);
            }
        }

    }
}
