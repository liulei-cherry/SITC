/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：CurrencyService.cs
 * 创 建 人：徐正本
 * 创建时间：2011/7/1
 * 标    题：数据操作类
 * 功能描述：T_CURRENCY数据操作类
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

namespace BaseInfo.DataAccess
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_CURRENCYService.cs
    /// </summary>
    public partial class CurrencyService : IObjectsService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static CurrencyService instance = new CurrencyService();
        public static CurrencyService Instance
        {
            get
            {
                if (null == instance)
                {
                    CurrencyService.instance = new CurrencyService();
                }
                return CurrencyService.instance;
            }
        }
        private CurrencyService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">Currency对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(Currency unit, out string err)
        {
            if (unit.CURRENCYID != null && unit.CURRENCYID.Length > 0) //edit
            {
                sql = "UPDATE [T_CURRENCY] SET "
                    + " [CURRENCYID] = " + (string.IsNullOrEmpty(unit.CURRENCYID) ? "null" : "'" + unit.CURRENCYID.Replace("'", "''") + "'")
                    + " , [CURRENCYNAME] = " + (unit.CURRENCYNAME == null ? "''" : "'" + unit.CURRENCYNAME.Replace("'", "''") + "'")
                    + " , [CURRENCYCODE] = " + (unit.CURRENCYCODE == null ? "''" : "'" + unit.CURRENCYCODE.Replace("'", "''") + "'")
                    + " , [FULLNAME] = " + (unit.FULLNAME == null ? "''" : "'" + unit.FULLNAME.Replace("'", "''") + "'")
                    + " , [KEYNAME] = " + (unit.KEYNAME == null ? "''" : "'" + unit.KEYNAME.Replace("'", "''") + "'")
                    + " , [INUSE] = " + unit.INUSE.ToString()
                    + " , [REMARK] = " + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
                    + " where upper(CURRENCYID) = '" + unit.CURRENCYID.ToUpper() + "'";
            }
            else
            {
                unit.CURRENCYID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_CURRENCY] ("
                    + "[CURRENCYID],"
                    + "[CURRENCYNAME],"
                    + "[CURRENCYCODE],"
                    + "[FULLNAME],"
                    + "[KEYNAME],"
                    + "[INUSE],"
                    + "[REMARK]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.CURRENCYID) ? "null" : "'" + unit.CURRENCYID.Replace("'", "''") + "'")
                    + " , " + (unit.CURRENCYNAME == null ? "''" : "'" + unit.CURRENCYNAME.Replace("'", "''") + "'")
                    + " , " + (unit.CURRENCYCODE == null ? "''" : "'" + unit.CURRENCYCODE.Replace("'", "''") + "'")
                    + " , " + (unit.FULLNAME == null ? "''" : "'" + unit.FULLNAME.Replace("'", "''") + "'")
                    + " , " + (unit.KEYNAME == null ? "''" : "'" + unit.KEYNAME.Replace("'", "''") + "'")
                    + " ," + unit.INUSE.ToString()
                    + " , " + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_CURRENCY中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_CURRENCY对象</param>
        internal bool deleteUnit(Currency unit, out string err)
        {
            return deleteUnit(unit.CURRENCYID, out err);
        }

        /// <summary>
        /// 删除数据表T_CURRENCY中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_CURRENCY.cURRENCYID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_CURRENCY where "
                + " upper(T_CURRENCY.CURRENCYID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体

        /// <summary>
        /// 根据一个主键ID,得到 T_CURRENCY 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>Currency DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "CURRENCYID"
                + ",CURRENCYNAME"
                + ",CURRENCYCODE"
                + ",FULLNAME"
                + ",KEYNAME"
                + ",INUSE"
                + ",REMARK"
                + "\rfrom T_CURRENCY "
                + "\rwhere upper(CURRENCYID)='" + Id.ToUpper() + "'";

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
        /// 根据currency 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>currency 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
        public Currency getObject(DataRow dr)
        {
            Currency unit = new Currency();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造Currency类对象!";
                return unit;
            }
            if (DBNull.Value != dr["CURRENCYID"])
                unit.CURRENCYID = dr["CURRENCYID"].ToString();
            if (DBNull.Value != dr["CURRENCYNAME"])
                unit.CURRENCYNAME = dr["CURRENCYNAME"].ToString();
            if (DBNull.Value != dr["CURRENCYCODE"])
                unit.CURRENCYCODE = dr["CURRENCYCODE"].ToString();
            if (DBNull.Value != dr["FULLNAME"])
                unit.FULLNAME = dr["FULLNAME"].ToString();
            if (DBNull.Value != dr["KEYNAME"])
                unit.KEYNAME = dr["KEYNAME"].ToString();
            if (DBNull.Value != dr["INUSE"])
                unit.INUSE = Convert.ToDecimal(dr["INUSE"]);
            if (DBNull.Value != dr["REMARK"])
                unit.REMARK = dr["REMARK"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个Currency对象.
        /// </summary>
        /// <param name="cURRENCYID">cURRENCYID</param>
        /// <returns>Currency对象</returns>
        public Currency getObject(string Id, out string err)
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

        #region IObjectsService 成员

        public CommonOperation.BaseClass.CommonClass GetOneObjectById(string id)
        {
            string err;
            return getObject(id, out err);
        }

        public Dictionary<string, string> GetObjectDisplaySetting()
        {
            Dictionary<string, string> reValue = new Dictionary<string, string>();
            reValue.Add("CURRENCYNAME", "货币中文名称");
            reValue.Add("CURRENCYCODE", "标准货币编码");
            reValue.Add("FULLNAME", "标准货币全名");
            reValue.Add("KEYNAME", "标准货币简写");
            reValue.Add("REMARK", "备注");
            return reValue;
        }
        #endregion

        /// <summary>
        /// 得到  T_CURRENCY 所有数据信息.
        /// </summary>
        /// <returns>T_CURRENCY DataTable</returns>
        public DataTable getInfo(out string err)
        {
            return getInfoByInUse(true, out err);
        }
        /// <summary>
        /// 得到  T_CURRENCY 所有数据信息.
        /// </summary>
        /// <returns>T_CURRENCY DataTable</returns>
        public DataTable getInfoByInUse(bool onlyInUse, out string err)
        {
            sql = "select	"
                + "CURRENCYID"
                + ",CURRENCYNAME"
                + ",CURRENCYCODE + case when CURRENCYNAME is null or ltrim(CURRENCYNAME) = '' then '' else '(' + CURRENCYNAME+ ')' end  as SHOWINGNAME "
                + ",CURRENCYCODE"
                + ",FULLNAME"
                + ",KEYNAME"
                + ",INUSE"
                + ",REMARK"
                + "\rfrom T_CURRENCY "
                + (onlyInUse ? "\rwhere inuse = 1" : "")
                + "\rorder by inuse desc,currencycode";
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

        public bool HaveTheCurrency(string currencyCode, string exceptCurrencyId, out string err)
        {
            sql = "select count(1) from T_CURRENCY where CURRENCYCODE = '" + currencyCode + "'"
                + (string.IsNullOrEmpty(exceptCurrencyId) ? "" : " and CURRENCYID != '" + exceptCurrencyId + "'");
            string count;
            if (!dbAccess.GetString(sql, out count, out err))
            {
                return false;
            }
            if (count != "0")
            {
                err = "已经存在此货币名称!";
                return false;
            }
            return true;
        }
        /// <summary>
        /// 根据名称得到币种
        /// </summary>
        public DataTable GetByName(string CURRENCYNAME)
        {
            string err;
            sql = "select "
                 + "CURRENCYID"
                 + ",CURRENCYNAME"
                 + ",CURRENCYCODE"
                 + ",FULLNAME"
                 + ",KEYNAME"
                 + ",INUSE"
                 + ",REMARK"
                 + "\rfrom T_CURRENCY "
                 + "\rwhere CURRENCYNAME='" + CURRENCYNAME + "'";
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
    }
}
