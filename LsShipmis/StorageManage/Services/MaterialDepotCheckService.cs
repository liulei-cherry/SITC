/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：MaterialDepotCheckService.cs
 * 创 建 人：徐正本
 * 创建时间：2011/8/16
 * 标    题：数据操作类
 * 功能描述：T_MATERIAL_DEPOT_CHECK数据操作类
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
using StorageManage.DataObject;

namespace StorageManage.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_MATERIAL_DEPOT_CHECKService.cs
    /// </summary>
    public partial class MaterialDepotCheckService
    {
        #region 构造函数

        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static MaterialDepotCheckService instance = new MaterialDepotCheckService();
        public static MaterialDepotCheckService Instance
        {
            get
            {
                if (null == instance)
                {
                    MaterialDepotCheckService.instance = new MaterialDepotCheckService();
                }
                return MaterialDepotCheckService.instance;
            }
        }
        private MaterialDepotCheckService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">MaterialDepotCheck对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(MaterialDepotCheck unit, out string err)
        {
            if (unit.DEPOTCHECKID != null && unit.DEPOTCHECKID.Length > 0) //edit
            {
                sql = "UPDATE [T_MATERIAL_DEPOT_CHECK] SET "
                    + " [DEPOTCHECKID] = " + (string.IsNullOrEmpty(unit.DEPOTCHECKID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.DEPOTCHECKID) + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIP_ID) + "'")
                    + " , [WAREHOUSE_ID] = " + (string.IsNullOrEmpty(unit.WAREHOUSE_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.WAREHOUSE_ID) + "'")
                    + " , [CHECK_CODE] = " + (unit.CHECK_CODE == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.CHECK_CODE) + "'")
                    + " , [CHECK_PERSON] = " + (unit.CHECK_PERSON == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.CHECK_PERSON) + "'")
                    + " , [CHECK_PERSON_POSTID] = " + (string.IsNullOrEmpty(unit.CHECK_PERSON_POSTID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.CHECK_PERSON_POSTID) + "'")
                    + " , [DEPART_ID] = " + (string.IsNullOrEmpty(unit.DEPART_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.DEPART_ID) + "'")
                    + " , [CHECK_DATE] = " + dbOperation.DbToDate(unit.CHECK_DATE)
                    + " , [SHIPCHECKER] = " + (unit.SHIPCHECKER == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIPCHECKER) + "'")
                    + " , [LANDCHECKER] = " + (unit.LANDCHECKER == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.LANDCHECKER) + "'")
                    + " , [CHECKDATE] = " + dbOperation.DbToDate(unit.CHECKDATE)
                    + " , [ISCOMPLETE] = " + unit.ISCOMPLETE.ToString()
                    + " , [REMARK] = " + (unit.REMARK == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.REMARK) + "'")
                    + " , [STATE] = " + unit.STATE.ToString()
                    + " , [BALANCEDEPOTCHECKID] = " + (string.IsNullOrEmpty(unit.BALANCEDEPOTCHECKID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.BALANCEDEPOTCHECKID) + "'")
                    + "\rwhere DEPOTCHECKID = '" + dbOperation.ReplaceSqlKeyStr(unit.DEPOTCHECKID) + "'";
            }
            else
            {
                unit.DEPOTCHECKID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_MATERIAL_DEPOT_CHECK] ("
                    + "[DEPOTCHECKID],"
                    + "[SHIP_ID],"
                    + "[WAREHOUSE_ID],"
                    + "[CHECK_CODE],"
                    + "[CHECK_PERSON],"
                    + "[CHECK_PERSON_POSTID],"
                    + "[DEPART_ID],"
                    + "[CHECK_DATE],"
                    + "[SHIPCHECKER],"
                    + "[LANDCHECKER],"
                    + "[CHECKDATE],"
                    + "[ISCOMPLETE],"
                    + "[REMARK],"
                    + "[STATE],"
                    + "[BALANCEDEPOTCHECKID]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.DEPOTCHECKID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.DEPOTCHECKID) + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIP_ID) + "'")
                    + " , " + (string.IsNullOrEmpty(unit.WAREHOUSE_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.WAREHOUSE_ID) + "'")
                    + " , " + (unit.CHECK_CODE == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.CHECK_CODE) + "'")
                    + " , " + (unit.CHECK_PERSON == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.CHECK_PERSON) + "'")
                    + " , " + (string.IsNullOrEmpty(unit.CHECK_PERSON_POSTID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.CHECK_PERSON_POSTID) + "'")
                    + " , " + (string.IsNullOrEmpty(unit.DEPART_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.DEPART_ID) + "'")
                    + " ," + dbOperation.DbToDate(unit.CHECK_DATE)
                    + " , " + (unit.SHIPCHECKER == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIPCHECKER) + "'")
                    + " , " + (unit.LANDCHECKER == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.LANDCHECKER) + "'")
                    + " ," + dbOperation.DbToDate(unit.CHECKDATE)
                    + " ," + unit.ISCOMPLETE.ToString()
                    + " , " + (unit.REMARK == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.REMARK) + "'")
                    + " ," + unit.STATE.ToString()
                    + " , " + (string.IsNullOrEmpty(unit.BALANCEDEPOTCHECKID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.BALANCEDEPOTCHECKID) + "'")
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_MATERIAL_DEPOT_CHECK中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_MATERIAL_DEPOT_CHECK对象</param>
        internal bool deleteUnit(MaterialDepotCheck unit, out string err)
        {
            return deleteUnit(unit.DEPOTCHECKID, out err);
        }

        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_MATERIAL_DEPOT_CHECK 所有数据信息.
        /// </summary>
        /// <returns>T_MATERIAL_DEPOT_CHECK DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "DEPOTCHECKID"
                + ",SHIP_ID"
                + ",WAREHOUSE_ID"
                + ",CHECK_CODE"
                + ",CHECK_PERSON"
                + ",CHECK_PERSON_POSTID"
                + ",DEPART_ID"
                + ",CHECK_DATE"
                + ",SHIPCHECKER"
                + ",LANDCHECKER"
                + ",CHECKDATE"
                + ",ISCOMPLETE"
                + ",REMARK"
                + ",STATE"
                + ",BALANCEDEPOTCHECKID"
                + "\rfrom T_MATERIAL_DEPOT_CHECK ";
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
        /// 根据一个主键ID,得到 T_MATERIAL_DEPOT_CHECK 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>MaterialDepotCheck DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "DEPOTCHECKID"
                + ",SHIP_ID"
                + ",WAREHOUSE_ID"
                + ",CHECK_CODE"
                + ",CHECK_PERSON"
                + ",CHECK_PERSON_POSTID"
                + ",DEPART_ID"
                + ",CHECK_DATE"
                + ",SHIPCHECKER"
                + ",LANDCHECKER"
                + ",CHECKDATE"
                + ",ISCOMPLETE"
                + ",REMARK"
                + ",STATE"
                + ",BALANCEDEPOTCHECKID"
                + "\rfrom T_MATERIAL_DEPOT_CHECK "
                + "\rwhere DEPOTCHECKID='" + dbOperation.ReplaceSqlKeyStr(Id) + "'";
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
        /// 根据materialdepotcheck 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>materialdepotcheck 数据实体</returns>
        public MaterialDepotCheck getObject(DataRow dr)
        {
            MaterialDepotCheck unit = new MaterialDepotCheck();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造MaterialDepotCheck类对象!";
                return unit;
            }
            if (DBNull.Value != dr["DEPOTCHECKID"])
                unit.DEPOTCHECKID = dr["DEPOTCHECKID"].ToString();
            if (DBNull.Value != dr["SHIP_ID"])
                unit.SHIP_ID = dr["SHIP_ID"].ToString();
            if (DBNull.Value != dr["WAREHOUSE_ID"])
                unit.WAREHOUSE_ID = dr["WAREHOUSE_ID"].ToString();
            if (DBNull.Value != dr["CHECK_CODE"])
                unit.CHECK_CODE = dr["CHECK_CODE"].ToString();
            if (DBNull.Value != dr["CHECK_PERSON"])
                unit.CHECK_PERSON = dr["CHECK_PERSON"].ToString();
            if (DBNull.Value != dr["CHECK_PERSON_POSTID"])
                unit.CHECK_PERSON_POSTID = dr["CHECK_PERSON_POSTID"].ToString();
            if (DBNull.Value != dr["DEPART_ID"])
                unit.DEPART_ID = dr["DEPART_ID"].ToString();
            if (DBNull.Value != dr["CHECK_DATE"])
                unit.CHECK_DATE = (DateTime)dr["CHECK_DATE"];
            if (DBNull.Value != dr["SHIPCHECKER"])
                unit.SHIPCHECKER = dr["SHIPCHECKER"].ToString();
            if (DBNull.Value != dr["LANDCHECKER"])
                unit.LANDCHECKER = dr["LANDCHECKER"].ToString();
            if (DBNull.Value != dr["CHECKDATE"])
                unit.CHECKDATE = (DateTime)dr["CHECKDATE"];
            if (DBNull.Value != dr["ISCOMPLETE"])
                unit.ISCOMPLETE = Convert.ToDecimal(dr["ISCOMPLETE"]);
            if (DBNull.Value != dr["REMARK"])
                unit.REMARK = dr["REMARK"].ToString();
            if (DBNull.Value != dr["STATE"])
                unit.STATE = Convert.ToDecimal(dr["STATE"]);
            if (DBNull.Value != dr["BALANCEDEPOTCHECKID"])
                unit.BALANCEDEPOTCHECKID = dr["BALANCEDEPOTCHECKID"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个MaterialDepotCheck对象.
        /// </summary>
        /// <param name="dEPOTCHECKID">dEPOTCHECKID</param>
        /// <returns>MaterialDepotCheck对象</returns>
        public MaterialDepotCheck getObject(string Id, out string err)
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
        /// 删除数据表T_MATERIAL_DEPOT_CHECK中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_MATERIAL_DEPOT_CHECK.dEPOTCHECKID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            List<string> sqls = new List<string>();

            sqls.Add("delete T_MATERIAL_DEPOT_CHECK_DETAIL where DEPOTCHECKID = '" + dbOperation.ReplaceSqlKeyStr(unitid) + "'");
            sqls.Add("delete T_MATERIAL_DEPOT_CHECK where DEPOTCHECKID = '" + dbOperation.ReplaceSqlKeyStr(unitid) + "'");
            return dbAccess.ExecSql(sqls, out err);
        }

        /// <summary>
        /// 物资盘点信息.
        /// </summary>
        /// <param name="shipId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="chkState"></param>
        /// <param name="othersData"></param>
        /// <returns></returns>
        public DataTable GetMaterialStockCheck(string shipId, DateTime startDate, DateTime endDate, string chkState, bool othersData)
        {
            //变量定义部分.
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sWhere = "";                 //查询条件.

            //Where条件加工部分.
            //在Oracle中查询不包括时间的日期时，必须把时间字段设置成yyyy-MM-dd格式后再转换成日期字段.
            //Where条件加工部分.
            if (!string.IsNullOrEmpty(shipId))
                sWhere += " and a.ship_Id='" + shipId + "' ";
            //如果是部门长，看本部门的，如果不是部门长，则只能看自己的.
            if (!othersData || (!CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER && !CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS
                && !CommonOperation.ConstParameter.IsLandVersion))//只能看自己岗位的.
            {
                sWhere += " and  a.CHECK_PERSON_POSTID = '" + dbOperation.ReplaceSqlKeyStr(CommonOperation.ConstParameter.LoginUserInfo.PostId) + "' ";
            }
            if (chkState != "0")
            {
                sWhere += " and a.STATE='" + chkState + "' ";
            }
            sWhere += " and a.CHECK_DATE between " + dbOperation.DbToDate(startDate) + " and " + dbOperation.DbToDate(endDate);

            //Select语句加工部分.
            sql = "select "
                + "a.DEPOTCHECKID,"
                + "a.SHIP_ID,"
                + "b.ship_name,"
                + "a.CHECK_CODE,"
                + "a.WAREHOUSE_ID,"
                + "c.WAREHOUSE_NAME,"
                + "a.CHECK_PERSON,"
                + "a.CHECK_PERSON_POSTID,"
                + "a.DEPART_ID,"
                + "a.CHECK_DATE,"
                + "a.SHIPCHECKER,"
                + "a.LANDCHECKER,"
                + "a.remark,"
                + "a.STATE,"
                + "case when a.ISCOMPLETE = 0 then '未填写完毕' else (case a.state when 1 then '等待岸端审阅' when 2 then '等待船端调整' when 3 then '等待船端确认' "
                + "\rwhen 4 then '等待岸端确认' when 5 then '审核被打回' when 6 then '岸端确认' end) end stateName,"
                + "a.CHECKDATE,"
                + "a.BALANCEDEPOTCHECKID,case when BALANCEDEPOTCHECKID is null then 0 else 1 end StrikeToBalance,"//StrikeToBalance可以被冲账.
                + "isnull((select count(1) from T_MATERIAL_DEPOT_CHECK x where x.BALANCEDEPOTCHECKID = a.DEPOTCHECKID),0) hasBeenBalanced,"
                + "a.ISCOMPLETE "
                + "\rfrom T_MATERIAL_DEPOT_CHECK a "
                + "inner join t_ship b on a.ship_id=b.ship_id "
                + "inner join t_som_warehouse c on a.WAREHOUSE_ID = c.WAREHOUSE_ID ";
            if (CommonOperation.ConstParameter.IsLandVersion)
                sql += " inner join T_USER_SHIP us on us.ship_id=a.SHIP_ID and us.userid = '" + CommonOperation.ConstParameter.UserId + "'";
            sql += "\rwhere 1=1 ";
            //设置查询的Where条件.
            if (sWhere.Trim().Length > 0)
            {
                sql += sWhere;
            }
            sql += "\rorder by a.CHECK_DATE desc, ltrim(isnull(BALANCEDEPOTCHECKID,'')) + DEPOTCHECKID ";//按创建时间排序.
            dbAccess.GetDataTable(sql, out dtb, out err);
            return dtb;
        }

        /// <summary>
        ///  获得物资盘存单明细信息数据.
        /// </summary>
        /// <param name="stockckId">物资盘存单Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetMaterialStockckDetail(string stockckId)
        {
            //变量定义部分.
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.

            //Select语句加工部分.
            sql = "select "
                 + "a.MATERIALCHECKDETAIL_ID,"
                 + "a.DEPOTCHECKID,"
                 + "a.MATERIAL_Id,b.MATERIAL_CODE,"
                 + "case when len(b.MATERIAL_CODE)>0 then '进SAP' else '' end as ISSAP,"
                 + "b.MATERIAL_name,"
                 + "b.MATERIAL_SPEC,"
                 + "a.WAREHOUSE_ID,"
                 + "a.THEORETICALCOUNT,"
                 + "a.ACTUALCOUNT,"
                 + "a.COUNT,"
                 + "b.unit_name,"
                 + "a.remark,"
                 + "a.ship_id "
                 + "\rfrom T_MATERIAL_DEPOT_CHECK_DETAIL a "
                 + "\rleft join t_MATERIAL b on a.MATERIAL_Id = b.MATERIAL_id "
                 + "\rwhere  a.DEPOTCHECKID = '" + dbOperation.ReplaceSqlKeyStr(stockckId) + "' "
                 + "\rorder by b.MATERIAL_name";

            dbAccess.GetDataTable(sql, out dtb, out err);
            return dtb;
        }

        /// <summary>
        /// 根据指定的船舶Id、仓库Id生成一个指定船舶的指定仓库的盘存清单.
        /// 把以前有过库存的全部计算了,这里也可以只关注非零库存的内容,但暂时先不这样处理.
        /// </summary>        
        /// <param name="shipId">船舶Id</param>
        /// <param name="wareHouseId">仓库Id</param>
        /// <param name="stockckId">盘存单Id</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public bool ProduceStockNewLst(string shipId, string wareHouseId, string stockckId, out string err)
        {
            if (string.IsNullOrEmpty(shipId) || string.IsNullOrEmpty(wareHouseId) || string.IsNullOrEmpty(stockckId))
            {
                err = "传入的参数无效,不能继续行程盘存单明细";
                return false;
            }
            //当当前库有未完成的盘点时,不允许生成此单据.
            List<string> lstSqlOpt = new List<string>();//包含操作语句的List泛型集合.

            //在生成盘存单明细之前先删除掉以前的旧数据.
            string sDelSql = "delete from T_MATERIAL_DEPOT_CHECK_DETAIL where DEPOTCHECKID = '" + dbOperation.ReplaceSqlKeyStr(stockckId) + "'";
            lstSqlOpt.Add(sDelSql);

            //生成盘存单明细的SQL语句.
            string sInsertSql = "insert into T_MATERIAL_DEPOT_CHECK_DETAIL(MATERIALCHECKDETAIL_ID,"
                + "DEPOTCHECKID,MATERIAL_id,THEORETICALCOUNT,COUNT,warehouse_id,ship_id) "
                + "select newid(),'" + dbOperation.ReplaceSqlKeyStr(stockckId) + "',"
                + "MATERIAL_id,STOCKSAll, 0,'" + dbOperation.ReplaceSqlKeyStr(wareHouseId) + "','" + dbOperation.ReplaceSqlKeyStr(shipId) + "' "
                + "from V_MATERIAL_STOCKS where ship_id='" + dbOperation.ReplaceSqlKeyStr(shipId)
                + "' and warehouse_id='" + dbOperation.ReplaceSqlKeyStr(wareHouseId) + "'";
            lstSqlOpt.Add(sInsertSql);

            //调用dbAccess的execSql执行sSql中的所有的操作语句.
            return dbAccess.ExecSql(lstSqlOpt, out err);
        }

        public bool StrikeABalance(string checkId, string balanceReason, out string err)
        {
            err = "";
            string newid = Guid.NewGuid().ToString();
            List<string> sqls = new List<string>();
            sql = "insert into T_MATERIAL_DEPOT_CHECK([DEPOTCHECKID],[SHIP_ID],[WAREHOUSE_ID],[CHECK_CODE],[CHECK_PERSON],[CHECK_PERSON_POSTID]"
                + ",[CHECK_DATE],[DEPART_ID],[SHIPCHECKER],[LANDCHECKER],[CHECKDATE],[ISCOMPLETE],[REMARK],[STATE],[BALANCEDEPOTCHECKID])"
                + "select '" + newid + "',[SHIP_ID],[WAREHOUSE_ID],[CHECK_CODE],[CHECK_PERSON],[CHECK_PERSON_POSTID]"
                + ",[CHECK_DATE],[DEPART_ID],[SHIPCHECKER],'" + dbOperation.ReplaceSqlKeyStr(CommonOperation.ConstParameter.UserName)
                + "'," + dbOperation.DbToDate(DateTime.Today) + ",[ISCOMPLETE],'" + dbOperation.ReplaceSqlKeyStr(balanceReason) + "',[STATE],'"
                + dbOperation.ReplaceSqlKeyStr(checkId) + "'"
                + "\rfrom T_MATERIAL_DEPOT_CHECK where DEPOTCHECKID = '" + dbOperation.ReplaceSqlKeyStr(checkId) + "'";
            sqls.Add(sql);
            sql = "INSERT INTO T_MATERIAL_DEPOT_CHECK_DETAIL([MATERIALCHECKDETAIL_ID],[DEPOTCHECKID],[MATERIAL_ID],[WAREHOUSE_ID],"
                + "[THEORETICALCOUNT],[ACTUALCOUNT],[COUNT],[REMARK],[SHIP_ID])"
                + "\rselect newid(),'" + newid + "',[MATERIAL_ID],[WAREHOUSE_ID],[ACTUALCOUNT],[THEORETICALCOUNT],[COUNT] * -1,[REMARK],[SHIP_ID]"
                + "\rfrom T_MATERIAL_DEPOT_CHECK_DETAIL where DEPOTCHECKID = '" + dbOperation.ReplaceSqlKeyStr(checkId) + "'";
            sqls.Add(sql);

            return dbAccess.ExecSql(sqls, out err);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="checkId"></param>
        /// <param name="balanceReason"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool CloneStockTake(string checkId, string balanceReason, out string err)
        {
            err = "";
            string newid = Guid.NewGuid().ToString();
            List<string> sqls = new List<string>();
            sql = "insert into T_MATERIAL_DEPOT_CHECK([DEPOTCHECKID],[SHIP_ID],[WAREHOUSE_ID],[CHECK_CODE],[CHECK_PERSON],[CHECK_PERSON_POSTID]"
                + ",[CHECK_DATE],[DEPART_ID],[SHIPCHECKER],[LANDCHECKER],[CHECKDATE],[ISCOMPLETE],[REMARK],[STATE],[BALANCEDEPOTCHECKID])"
                + "select '" + newid + "',[SHIP_ID],[WAREHOUSE_ID],[CHECK_CODE],[CHECK_PERSON],[CHECK_PERSON_POSTID]"
                + ",[CHECK_DATE],[DEPART_ID],[SHIPCHECKER],'" + dbOperation.ReplaceSqlKeyStr(CommonOperation.ConstParameter.UserName)
                + "'," + dbOperation.DbToDate(DateTime.Today) + ",[ISCOMPLETE],'" + dbOperation.ReplaceSqlKeyStr(balanceReason) + "',4,null"
                + "\rfrom T_MATERIAL_DEPOT_CHECK where DEPOTCHECKID = '" + dbOperation.ReplaceSqlKeyStr(checkId) + "'";
            sqls.Add(sql);
            sql = "INSERT INTO T_MATERIAL_DEPOT_CHECK_DETAIL([MATERIALCHECKDETAIL_ID],[DEPOTCHECKID],[MATERIAL_ID],[WAREHOUSE_ID],"
                + "[THEORETICALCOUNT],[ACTUALCOUNT],[COUNT],[REMARK],[SHIP_ID])"
                + "\rselect newid(),'" + newid + "',[MATERIAL_ID],[WAREHOUSE_ID],[ACTUALCOUNT],[THEORETICALCOUNT],[COUNT],[REMARK],[SHIP_ID]"
                + "\rfrom T_MATERIAL_DEPOT_CHECK_DETAIL where DEPOTCHECKID = '" + dbOperation.ReplaceSqlKeyStr(checkId) + "'";
            sqls.Add(sql);

            return dbAccess.ExecSql(sqls, out err);
        }
        public bool RemoveABalance(string checkId, out string err)
        {
            err = "";
            sql = "select DEPOTCHECKID from T_MATERIAL_DEPOT_CHECK where BALANCEDEPOTCHECKID = '" + dbOperation.ReplaceSqlKeyStr(checkId) + "'";

            string newid = dbAccess.GetString(sql);
            if (string.IsNullOrEmpty(newid)) return true;

            List<string> sqls = new List<string>();
            sql = "delete T_MATERIAL_DEPOT_CHECK_DETAIL where DEPOTCHECKID = '" + dbOperation.ReplaceSqlKeyStr(newid) + "'";
            sqls.Add(sql);
            sql = "delete T_MATERIAL_DEPOT_CHECK where DEPOTCHECKID = '" + dbOperation.ReplaceSqlKeyStr(newid) + "'";
            sqls.Add(sql);

            return dbAccess.ExecSql(sqls, out err);
        }
        /// <summary>
        /// 把一次盘点的操作真正影响懂啊数据库层.
        /// 所有的出入库单据的状态(原来是4的全部改成5)
        /// </summary>
        /// <param name="stockckId"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool MaterialStockCheckFinish(string stockckId, out string err)
        {
            List<string> sqls = new List<string>();

            sql = string.Format(@"update dbo.T_MATERIAL_STOCKS
set STOCKS = t3.ACTUALCOUNT,CHANGE_DATE = getdate()
from T_MATERIAL_STOCKS t1 inner join T_MATERIAL_DEPOT_CHECK t2 on t1.SHIP_ID = t2.SHIP_ID 
and t1.WAREHOUSE_ID = t2.WAREHOUSE_ID inner join T_MATERIAL_DEPOT_CHECK_detail t3
on t2.DEPOTCHECKID = t3.DEPOTCHECKID and t1.MATERIAL_id = t3.MATERIAL_id
where t2.DEPOTCHECKID = '{0}'", stockckId);
            sqls.Add(sql);

            sql = string.Format(@"insert into dbo.T_MATERIAL_STOCKS(STOCKS_ID, SHIP_ID, MATERIAL_ID, WAREHOUSE_ID, STOCKS, CHANGE_DATE )
select NEWID(),t2.ship_id,t2.MATERIAL_ID,t2.WAREHOUSE_ID,t2.ACTUALCOUNT,GETDATE()
from T_MATERIAL_DEPOT_CHECK t1  inner join T_MATERIAL_DEPOT_CHECK_detail t2
on t1.DEPOTCHECKID = t2.DEPOTCHECKID
left join T_MATERIAL_STOCKS t3 on t2.MATERIAL_ID = t3.MATERIAL_ID
 and t2.WAREHOUSE_ID = t3.WAREHOUSE_ID and t3.SHIP_ID = t2.SHIP_ID 
where t3.MATERIAL_ID is null and t1.DEPOTCHECKID = '{0}'", stockckId);
            sqls.Add(sql);

            //将明细表的状态变化;
            sql = "update T_MATERIAL_DEPOT_OPERATION_DETAIL "
                + "\rset CHECKSTATE = 1 "
                + "\rfrom T_MATERIAL_DEPOT_OPERATION_DETAIL t1 inner join T_MATERIAL_DEPOT_CHECK_DETAIL t2 "
                + "\ron t1.SHIP_ID = t2.SHIP_ID and t1.WAREHOUSE_ID = t2.WAREHOUSE_ID and t1.MATERIAL_ID = t2.MATERIAL_ID"
                + "\rinner join T_MATERIAL_DEPOT_OPERATION t3 on t1.DEPOTOPERID = t3.DEPOTOPERID"
                + "\rinner join T_MATERIAL_DEPOT_CHECK t4 on t2.DEPOTCHECKID = t4.DEPOTCHECKID"
                + "\rwhere t3.STATE = 4 and isnull(t1.CHECKSTATE,0) = 0 and t4.DEPOTCHECKID = '" + stockckId + "'";
            sqls.Add(sql);

            //将主表的状态变化.
            sql = "update T_MATERIAL_DEPOT_OPERATION "
               + "\rset STATE = 5"
               + "\rwhere DEPOTOPERID in (select distinct t1.DEPOTOPERID"
               + "\rfrom T_MATERIAL_DEPOT_OPERATION_DETAIL t1 inner join T_MATERIAL_DEPOT_CHECK_DETAIL t2 "
               + "\ron t1.SHIP_ID = t2.SHIP_ID and t1.WAREHOUSE_ID = t2.WAREHOUSE_ID and t1.MATERIAL_ID = t2.MATERIAL_ID"
               + "\rinner join T_MATERIAL_DEPOT_OPERATION t3 on t1.DEPOTOPERID = t3.DEPOTOPERID"
               + "\rinner join T_MATERIAL_DEPOT_CHECK t4 on t2.DEPOTCHECKID = t4.DEPOTCHECKID"
               + "\rwhere t3.STATE = 4 and (select count(1) from T_MATERIAL_DEPOT_OPERATION_DETAIL t1 where"
               + "\rt1.DEPOTOPERID = t3.DEPOTOPERID and isnull(t1.CHECKSTATE,0)= 0 )= 0 and t4.DEPOTCHECKID = '" + stockckId + "')";
            sqls.Add(sql);
            return dbAccess.ExecSql(sqls, out err);
        }
    }
}
