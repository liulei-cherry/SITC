/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：SpareDepotOperationService.cs
 * 创 建 人：徐正本
 * 创建时间：2011/8/3
 * 标    题：数据操作类
 * 功能描述：T_SPARE_DEPOT_OPERATION数据操作类
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
using ItemsManage;

namespace StorageManage.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_SPARE_DEPOT_OPERATIONService.cs
    /// </summary>
    public partial class SpareDepotOperationService
    {
        #region 构造函数

        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static SpareDepotOperationService instance = new SpareDepotOperationService();
        public static SpareDepotOperationService Instance
        {
            get
            {
                if (null == instance)
                {
                    SpareDepotOperationService.instance = new SpareDepotOperationService();
                }
                return SpareDepotOperationService.instance;
            }
        }
        private SpareDepotOperationService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">SpareDepotOperation对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(SpareDepotOperation unit, out string err)
        {
            if (unit.DEPOTOPERID != null && unit.DEPOTOPERID.Length > 0) //edit
            {
                sql = "UPDATE [T_SPARE_DEPOT_OPERATION] SET "
                    + " [DEPOTOPERID] = " + (string.IsNullOrEmpty(unit.DEPOTOPERID) ? "null" : "'" + unit.DEPOTOPERID.Replace("'", "''") + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , [COMPONENT_UNIT_ID] = " + (string.IsNullOrEmpty(unit.COMPONENT_UNIT_ID) ? "null" : "'" + unit.COMPONENT_UNIT_ID.Replace("'", "''") + "'")
                    + " , [OPERATION_CODE] = " + (unit.OPERATION_CODE == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.OPERATION_CODE) + "'")
                    + " , [OPERATION_PERSON] = " + (unit.OPERATION_PERSON == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.OPERATION_PERSON) + "'")
                    + " , [OPERATION_PERSON_POSTID] = " + (unit.OPERATION_PERSON_POSTID == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.OPERATION_PERSON_POSTID) + "'")
                    + " , [IN_OR_OUT] = " + unit.IN_OR_OUT.ToString()
                    + " , [OPERATION_DATE] = " + dbOperation.DbToDate(unit.OPERATION_DATE)
                    + " , [DEPART_ID] = " + (string.IsNullOrEmpty(unit.DEPART_ID) ? "null" : "'" + unit.DEPART_ID.Replace("'", "''") + "'")
                    + " , [SHIPCHECKER] = " + (unit.SHIPCHECKER == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIPCHECKER) + "'")
                    + " , [LANDCHECKER] = " + (unit.LANDCHECKER == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.LANDCHECKER) + "'")
                    + " , [CHECKDATE] = " + dbOperation.DbToDate(unit.CHECKDATE)
                    + " , [ISCOMPLETE] = " + unit.ISCOMPLETE.ToString()
                    + " , [REMARK] = N" + (unit.REMARK == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.REMARK) + "'")
                    + " , [STATE] = " + unit.STATE.ToString()
                    + " , [INSTORAGETYPE] = " + unit.INSTORAGETYPE.ToString()
                    + " , [BALANCEDEPOTOPERID] = " + (string.IsNullOrEmpty(unit.BALANCEDEPOTOPERID) ? "null" : "'" + unit.BALANCEDEPOTOPERID.Replace("'", "''") + "'")
                    + "\rwhere DEPOTOPERID = '" + dbOperation.ReplaceSqlKeyStr(unit.DEPOTOPERID) + "'";
            }
            else
            {
                unit.DEPOTOPERID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_SPARE_DEPOT_OPERATION] ("
                    + "[DEPOTOPERID],"
                    + "[SHIP_ID],"
                    + "[COMPONENT_UNIT_ID],"
                    + "[OPERATION_CODE],"
                    + "[OPERATION_PERSON],"
                    + "[OPERATION_PERSON_POSTID],"
                    + "[IN_OR_OUT],"
                    + "[OPERATION_DATE],"
                    + "[DEPART_ID],"
                    + "[SHIPCHECKER],"
                    + "[LANDCHECKER],"
                    + "[CHECKDATE],"
                    + "[ISCOMPLETE],"
                    + "[REMARK],"
                    + "[STATE],"
                    + "[INSTORAGETYPE],"
                    + "[BALANCEDEPOTOPERID]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.DEPOTOPERID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.DEPOTOPERID) + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIP_ID) + "'")
                    + " , " + (string.IsNullOrEmpty(unit.COMPONENT_UNIT_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.COMPONENT_UNIT_ID) + "'")
                    + " , " + (unit.OPERATION_CODE == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.OPERATION_CODE) + "'")
                    + " , " + (unit.OPERATION_PERSON == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.OPERATION_PERSON) + "'")
                    + " , " + (unit.OPERATION_PERSON_POSTID == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.OPERATION_PERSON_POSTID) + "'")
                    + " ," + unit.IN_OR_OUT.ToString()
                    + " ," + dbOperation.DbToDate(unit.OPERATION_DATE)
                    + " , " + (string.IsNullOrEmpty(unit.DEPART_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.DEPART_ID) + "'")
                    + " , " + (unit.SHIPCHECKER == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIPCHECKER) + "'")
                    + " , " + (unit.LANDCHECKER == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.LANDCHECKER) + "'")
                    + " ," + dbOperation.DbToDate(unit.CHECKDATE)
                    + " ," + unit.ISCOMPLETE.ToString()
                    + " , N" + (unit.REMARK == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.REMARK) + "'")
                    + " ," + unit.STATE.ToString() + " ," + unit.INSTORAGETYPE.ToString()
                    + " , " + (string.IsNullOrEmpty(unit.BALANCEDEPOTOPERID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.BALANCEDEPOTOPERID) + "'")
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_SPARE_DEPOT_OPERATION中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_SPARE_DEPOT_OPERATION对象</param>
        internal bool deleteUnit(SpareDepotOperation unit, out string err)
        {
            return deleteUnit(unit.DEPOTOPERID, out err);
        }

        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_SPARE_DEPOT_OPERATION 所有数据信息.
        /// </summary>
        /// <returns>T_SPARE_DEPOT_OPERATION DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "DEPOTOPERID"
                + ",SHIP_ID"
                + ",COMPONENT_UNIT_ID"
                + ",OPERATION_CODE"
                + ",OPERATION_PERSON"
                + ",OPERATION_PERSON_POSTID"
                + ",IN_OR_OUT"
                + ",OPERATION_DATE"
                + ",DEPART_ID"
                + ",SHIPCHECKER"
                + ",LANDCHECKER"
                + ",CHECKDATE"
                + ",ISCOMPLETE"
                + ",REMARK"
                + ",STATE"
                + ",BALANCEDEPOTOPERID" 
                + ",INSTORAGETYPE"
                + "\rfrom T_SPARE_DEPOT_OPERATION ";
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
        /// 根据一个主键ID,得到 T_SPARE_DEPOT_OPERATION 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>SpareDepotOperation DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "DEPOTOPERID"
                + ",SHIP_ID"
                + ",COMPONENT_UNIT_ID"
                + ",OPERATION_CODE"
                + ",OPERATION_PERSON"
                + ",OPERATION_PERSON_POSTID"
                + ",IN_OR_OUT"
                + ",OPERATION_DATE"
                + ",DEPART_ID"
                + ",SHIPCHECKER"
                + ",LANDCHECKER"
                + ",CHECKDATE"
                + ",ISCOMPLETE"
                + ",REMARK"
                + ",STATE"
                + ",BALANCEDEPOTOPERID"
                + ",INSTORAGETYPE"
                + "\rfrom T_SPARE_DEPOT_OPERATION "
                + "\rwhere DEPOTOPERID='" + dbOperation.ReplaceSqlKeyStr(Id) + "'";
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
        /// 根据sparedepotoperation 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>sparedepotoperation 数据实体</returns>
        public SpareDepotOperation getObject(DataRow dr)
        {
            SpareDepotOperation unit = new SpareDepotOperation();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造SpareDepotOperation类对象!";
                return unit;
            }
            if (DBNull.Value != dr["DEPOTOPERID"])
                unit.DEPOTOPERID = dr["DEPOTOPERID"].ToString();
            if (DBNull.Value != dr["SHIP_ID"])
                unit.SHIP_ID = dr["SHIP_ID"].ToString();
            if (DBNull.Value != dr["COMPONENT_UNIT_ID"])
                unit.COMPONENT_UNIT_ID = dr["COMPONENT_UNIT_ID"].ToString();
            if (DBNull.Value != dr["OPERATION_CODE"])
                unit.OPERATION_CODE = dr["OPERATION_CODE"].ToString();
            if (DBNull.Value != dr["OPERATION_PERSON"])
                unit.OPERATION_PERSON = dr["OPERATION_PERSON"].ToString();
            if (DBNull.Value != dr["OPERATION_PERSON_POSTID"])
                unit.OPERATION_PERSON_POSTID = dr["OPERATION_PERSON_POSTID"].ToString();
            if (DBNull.Value != dr["IN_OR_OUT"])
                unit.IN_OR_OUT = Convert.ToDecimal(dr["IN_OR_OUT"]);
            if (DBNull.Value != dr["OPERATION_DATE"])
                unit.OPERATION_DATE = (DateTime)dr["OPERATION_DATE"];
            if (DBNull.Value != dr["DEPART_ID"])
                unit.DEPART_ID = dr["DEPART_ID"].ToString();
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
            if (DBNull.Value != dr["BALANCEDEPOTOPERID"])
                unit.BALANCEDEPOTOPERID = dr["BALANCEDEPOTOPERID"].ToString();
            if (DBNull.Value != dr["INSTORAGETYPE"])
                unit.INSTORAGETYPE = Convert.ToDecimal(dr["INSTORAGETYPE"]);
            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个SpareDepotOperation对象.
        /// </summary>
        /// <param name="dEPOTOPERID">dEPOTOPERID</param>
        /// <returns>SpareDepotOperation对象</returns>
        public SpareDepotOperation getObject(string Id, out string err)
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

        #region 业务处理部分
        /// <summary>
        /// 删除数据表T_SPARE_DEPOT_OPERATION中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_SPARE_DEPOT_OPERATION.dEPOTOPERID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            List<string> sqls = new List<string>();

            sqls.Add("delete T_SPARE_DEPOT_OPERATION_DETAIL where DEPOTOPERID = '" + dbOperation.ReplaceSqlKeyStr(unitid) + "'");
            sqls.Add("delete T_SPARE_DEPOT_OPERATION where DEPOTOPERID = '" + dbOperation.ReplaceSqlKeyStr(unitid) + "'");
            return dbAccess.ExecSql(sqls, out err);
        }

        /// <summary>
        /// 根据库存入库备件.
        /// </summary>
        /// <param name="outRows">包含备件入库信息的DataRow对象</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public bool SpareIn(DataRow[] inRows, out string err)
        {
            Dictionary<string, StorageParameter> dicAllRows = new Dictionary<string, StorageParameter>();
            foreach (DataRow dr in inRows)
            {
                string spareId = dr["spare_id"].ToString();
                StorageParameter storagePara = new StorageParameter();
                if (!Decimal.TryParse(dr["outnumb"].ToString(), out storagePara.Count))
                {
                    storagePara.Count = 0;
                }
                storagePara.ItemId = spareId;
                storagePara.WarehouseId = dr["warehouse_id"].ToString();
                dicAllRows.Add(spareId, storagePara);
            }
            return SpareIn(dicAllRows, out err);
        }

        /// <summary>
        /// 根据库存入库备件.
        /// </summary>
        /// <param name="outRows">包含备件入库信息的DataRow对象</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public bool SpareIn(Dictionary<string, StorageParameter> dicAllRows, out string err)
        {
            List<string> lstSqlOpt = new List<string>();    //存放执行SQL语句的泛型集合.

            //1.入库单信息.
            string spareInId = Guid.NewGuid().ToString();  //入库单Id
            string shipId = CommonOperation.ConstParameter.ShipId;         //船舶Id
            string spareInMan = CommonOperation.ConstParameter.UserName;  //入库人.
            string spareInUnitId = CommonOperation.ConstParameter.LoginUserInfo.DepartmentName;
            string sRemark = "根据库存入库自动产生";        //备注.
            string sCreator = CommonOperation.ConstParameter.LoginUserInfo.ShipHeadShipName;     //创建人.
            //根据设置判断当前最新状态,如果需要岸端审核,则状态为2,否则状态为4,如果需要船端审核则状态为1
            int state;
            if (StorageConfig.StorageChangeNeedShipCheck) state = 1;
            else if (StorageConfig.StorageChangeNeedLandCheck) state = 2;
            else state = 4;

            //2.组合备件入库单的SQL语句并把它放到泛型集合中去.
            string sInsertInBill = "insert into T_SPARE_DEPOT_OPERATION(DEPOTOPERID,ship_id,OPERATION_PERSON,OPERATION_PERSON_POSTID,IN_OR_OUT,OPERATION_DATE,"
                  + "DEPART_ID,REMARK,ISCOMPLETE,SHIPCHECKER,STATE,CHECKDATE) values("
                  + "'" + spareInId + "','" + shipId + "','" + dbOperation.ReplaceSqlKeyStr(spareInMan) + "','"
                  + CommonOperation.ConstParameter.LoginUserInfo.PostId + "',1," + dbOperation.DbToDate(DateTime.Today) + ","
                  + "'" + CommonOperation.ConstParameter.LoginUserInfo.DepartmentId + "',N'" + dbOperation.ReplaceSqlKeyStr(sRemark) + "',1,"
                  + (state == 1 ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(spareInMan) + "'") + "," + state.ToString() + "," + dbOperation.DbToDate(DateTime.Today) + ")";
            lstSqlOpt.Add(sInsertInBill);//把该语句添加到泛型集合中去.

            //3.组合备件入库明细信息的SQL语句并把它放到泛型集合中去.
            foreach (string spareId in dicAllRows.Keys)
            {
                //入库明细信息.
                string spareInDetailId = Guid.NewGuid().ToString();        //入库单明细Id 
                string warehouseId = dicAllRows[spareId].WarehouseId;
                decimal innumb = dicAllRows[spareId].Count;
                string inTypeCode = "到货";                                //入库类型.
                string sRemarkDetail = "快速入库操作时自动产生";              //备注.
                //组合入库明细的初始语句.
                string sInsertInDetail = "insert into T_SPARE_DEPOT_OPERATION_DETAIL(SPAREOPERDETAIL_ID,DEPOTOPERID,SPARE_ID,"
                     + "SPARE_NAME,PARTNUMBER,WAREHOUSE_ID,COUNT,TYPE_CODE,REMARK,SHIP_ID) select '" + spareInDetailId + "','" + spareInId + "','"
                     + spareId + "',SPARE_NAME,PARTNUMBER,'" + warehouseId + "'," + innumb + ",'" + dbOperation.ReplaceSqlKeyStr(inTypeCode) + "',N'" + dbOperation.ReplaceSqlKeyStr(sRemarkDetail) + "','" + shipId + "'"
                     + "\rfrom t_spare where SPARE_ID = '" + spareId + "'";
                lstSqlOpt.Add(sInsertInDetail);//把该语句添加到泛型集合中去.
            }

            //4.执行操作.
            return dbAccess.ExecSql(lstSqlOpt, out err);
        }

        /// <summary>
        /// 根据库存出库备件.
        /// </summary>
        /// <param name="outRows">包含备件出库信息的DataRow对象</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public bool SpareOut(DataRow[] OutRows, out string err)
        {
            Dictionary<string, StorageParameter> dicAllRows = new Dictionary<string, StorageParameter>();
            foreach (DataRow dr in OutRows)
            {
                string spareId = dr["spare_id"].ToString();
                StorageParameter storagePara = new StorageParameter();
                if (!Decimal.TryParse(dr["outnumb"].ToString(), out storagePara.Count))
                {
                    storagePara.Count = 0;
                }
                storagePara.ItemId = spareId;
                storagePara.WarehouseId = dr["warehouse_id"].ToString();
                dicAllRows.Add(spareId, storagePara);
            }
            return SpareOut(dicAllRows, out err);
        }

        /// <summary>
        /// 根据库存出库备件.
        /// </summary>
        /// <param name="outRows">包含备件出库信息的DataRow对象</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public bool SpareOut(Dictionary<string, StorageParameter> dicAllRows, out string err)
        {
            string shipId = CommonOperation.ConstParameter.ShipId;         //船舶Id
            string remark = "根据库存出库自动产生";        //备注.
            return SpareOut(dicAllRows, shipId, remark, out err);
        }

        public bool SpareOut(Dictionary<string, StorageParameter> dicAllRows, string shipId, string remark, out string err)
        {
            List<string> lstSqlOpt = new List<string>();    //存放执行SQL语句的泛型集合.

            //1.出库单信息.
            string spareOutId = Guid.NewGuid().ToString();  //出库单Id

            string spareOutMan = CommonOperation.ConstParameter.UserName;  //出库人.
            string spareOutUnitId = CommonOperation.ConstParameter.LoginUserInfo.DepartmentName;

            string sCreator = CommonOperation.ConstParameter.LoginUserInfo.ShipHeadShipName;     //创建人.
            //根据设置判断当前最新状态,如果需要岸端审核,则状态为2,否则状态为4,如果需要船端审核则状态为1
            int state;
            if (StorageConfig.StorageChangeNeedShipCheck) state = 1;
            else if (StorageConfig.StorageChangeNeedLandCheck) state = 2;
            else state = 4;

            //2.组合备件出库单的SQL语句并把它放到泛型集合中去.
            string sInsertInBill = "insert into T_SPARE_DEPOT_OPERATION(DEPOTOPERID,ship_id,OPERATION_PERSON,OPERATION_PERSON_POSTID,IN_OR_OUT,OPERATION_DATE,"
                  + "DEPART_ID,REMARK,ISCOMPLETE,SHIPCHECKER,STATE,CHECKDATE) values("
                  + "'" + spareOutId + "','" + shipId + "','" + dbOperation.ReplaceSqlKeyStr(spareOutMan) + "','"
                  + CommonOperation.ConstParameter.LoginUserInfo.PostId + "',2," + dbOperation.DbToDate(DateTime.Today) + ","
                  + "'" + CommonOperation.ConstParameter.LoginUserInfo.DepartmentId + "',N'" + dbOperation.ReplaceSqlKeyStr(remark) + "',1,"
                  + (state == 1 ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(spareOutMan) + "'") + "," + state.ToString() + "," + dbOperation.DbToDate(DateTime.Today) + ")";
            lstSqlOpt.Add(sInsertInBill);//把该语句添加到泛型集合中去.

            //3.组合备件出库明细信息的SQL语句并把它放到泛型集合中去.
            foreach (string spareId in dicAllRows.Keys)
            {
                //出库明细信息.
                string spareOutDetailId = Guid.NewGuid().ToString();        //出库单明细Id 
                string warehouseId = dicAllRows[spareId].WarehouseId;
                decimal innumb = dicAllRows[spareId].Count;
                string inTypeCode = "消耗";                                //出库类型.
                string sRemarkDetail = "快速出库操作时自动产生";              //备注.
                //组合出库明细的初始语句.
                string sInsertInDetail = "insert into T_SPARE_DEPOT_OPERATION_DETAIL(SPAREOPERDETAIL_ID,DEPOTOPERID,SPARE_ID,"
                     + "SPARE_NAME,PARTNUMBER,WAREHOUSE_ID,COUNT,TYPE_CODE,REMARK,SHIP_ID) select '" + spareOutDetailId + "','" + spareOutId + "','"
                     + spareId + "',SPARE_NAME,PARTNUMBER,'" + warehouseId + "'," + innumb + ",'" + dbOperation.ReplaceSqlKeyStr(inTypeCode) + "',N'" + dbOperation.ReplaceSqlKeyStr(sRemarkDetail) + "','" + shipId + "'"
                     + "\rfrom t_spare where SPARE_ID = '" + spareId + "'";
                lstSqlOpt.Add(sInsertInDetail);//把该语句添加到泛型集合中去.
            }

            //4.执行操作.
            return dbAccess.ExecSql(lstSqlOpt, out err);
        }
        /// <summary>
        ///  获得备件入库月统计信息数据.
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <param name="spareinId">备件入库单Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetMonthSpareIn(string shipId, int year, int month)
        {
            //变量定义部分.
            DataTable dtb;    //定义一个DataTable对象.
            string err;         //错误信息返回参数.
            DateTime startTime = new DateTime(year, month, 1);
            DateTime endTime = startTime.AddMonths(1).AddMinutes(-1);

            sql = string.Format(@"select t2.*,f.STOCKSAll stocksum from (
				select spare_id,spare_name,partnumber,sum(COUNT) COUNT,WAREHOUSE_ID,WAREHOUSE_NAME,unit_name,ship_id from 
                (select b.spare_id,b.spare_name,b.partnumber,a.COUNT,b.unit_name,a.ship_id,c.WAREHOUSE_ID,c.WAREHOUSE_NAME,b.SPARE_CODE
                   from T_SPARE_DEPOT_OPERATION g 
                inner join T_SPARE_DEPOT_OPERATION_DETAIL a on a.DEPOTOPERID=g.DEPOTOPERID  
                left join t_spare b on a.spare_Id=b.spare_id 
                left join t_som_warehouse c on a.warehouse_id=c.warehouse_id 
                
                where g.IN_OR_OUT = 1 and g.state>=4 and g.OPERATION_DATE between   {0} and {1}  
                and g.ship_Id = '{2}' 
                ) t group by t.SPARE_ID,spare_name,partnumber,unit_name,ship_id,warehouse_id,WAREHOUSE_NAME) t2 
                
                left join V_SPARE_STOCKS f  on t2.spare_id = f.spare_id and t2.warehouse_id=f.warehouse_id where
                  f.ship_Id = '{3}' ",
                 dbOperation.DbToDate(startTime), dbOperation.DbToDate(endTime),
                dbOperation.ReplaceSqlKeyStr(shipId).ToString(), dbOperation.ReplaceSqlKeyStr(shipId).ToString());//按创建时间排序.

            dbAccess.GetDataTable(sql, out dtb, out err);
            return dtb;
        }

        /// <summary>
        ///  获得备件入库月统计信息数据.
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <param name="spareinId">备件入库单Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetMonthSpareOut(string shipId, int year, int month)
        {
            //变量定义部分.
            DataTable dtb;    //定义一个DataTable对象.
            string err;         //错误信息返回参数.
            DateTime startTime = new DateTime(year, month, 1);
            DateTime endTime = startTime.AddMonths(1).AddMinutes(-1);

            //Select语句加工部分.
            sql = "select spare_name,partnumber,sum(COUNT) COUNT,stocksum,unit_name,ship_id from (select "
                + "case when b.spare_name is not null then b.spare_name  "
                + "     when b.spare_name is null and b.spare_ename is not null then b.spare_ename  "
                + "     else '' end as spare_name,"
                + "b.partnumber,"
                + "a.COUNT,"
                + "f.stocksum,"
                + "b.unit_name,"
                + "a.ship_id "
                + "\rfrom T_SPARE_DEPOT_OPERATION g "
                + "inner join T_SPARE_DEPOT_OPERATION_DETAIL a on a.DEPOTOPERID=g.DEPOTOPERID  "
                + "left join t_spare b on a.spare_Id=b.spare_id "
                + "left join t_som_warehouse c on a.warehouse_id=c.warehouse_id "
                //与备件库存查询关联（指定船舶、指定仓库、指定计量单位的备件）.
                + "\rleft join ("
                + "    select spare_id,STOCKSAll stocksum from V_SPARE_STOCKS "
                + "    where ship_Id = '" + dbOperation.ReplaceSqlKeyStr(shipId) + "'"
                + "    ) f on a.spare_id = f.spare_id  "
                + "\rwhere g.IN_OR_OUT = 2 and g.state>=4 and g.OPERATION_DATE between " + dbOperation.DbToDate(startTime) + " and " + dbOperation.DbToDate(endTime)
                + "\rand g.ship_Id = '" + dbOperation.ReplaceSqlKeyStr(shipId) + "' "
                + ") t group by spare_name,partnumber,stocksum,unit_name,ship_id order by spare_name";//按创建时间排序.

            dbAccess.GetDataTable(sql, out dtb, out err);
            return dtb;
        }

        /// <summary>
        ///  获得备件入库单明细信息数据.
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <param name="spareInId">备件入库单Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetSpareInDetail(string spareInId)
        {
            //变量定义部分.
            DataTable dtb;    //定义一个DataTable对象.
            string err;         //错误信息返回参数.
            //Select语句加工部分.
            sql = "select "
                + "a.SPAREOPERDETAIL_ID,"
                + "a.DEPOTOPERID,"
                + "a.spare_Id,"
                + "case when b.spare_name is not null then b.spare_name  "
                + "     when b.spare_name is null and b.spare_ename is not null then b.spare_ename  "
                + "     else '' end as spare_name,"
                + "b.partnumber,"
                + "a.warehouse_id,"
                + "c.warehouse_name,"
                + "case when e.stocksum is null then 0 else e.stocksum end as stocksum,"
                + "a.COUNT COUNT,"
                + "b.unit_name,"
                + "a.type_code,"
                + "a.order_code,"
                + "a.remark,"
                + "a.ship_id "
                //+ "a.CURRENCYID,g.CURRENCYCODE,"
                //+ "a.AMOUNT,"
                //+ "a.SERVICEPROVIDERID,f.MANUFACTURER_NAME"
                + "\rfrom T_SPARE_DEPOT_OPERATION_DETAIL a "
                + "\rleft join t_spare b on a.spare_Id=b.spare_id "
                + "\rleft join t_som_warehouse c on a.warehouse_id=c.warehouse_id "
                //与备件库存查询关联（指定船舶、指定仓库、指定计量单位的备件）.
                + "\rleft join ("
                + "            select warehouse_id,spare_id,STOCKSAll as stocksum,ship_id from V_SPARE_STOCKS "
                + "          ) e on (a.warehouse_id = e.warehouse_id and a.spare_id = e.spare_id and e.ship_id = a.ship_id) "
                //+ "\rleft join T_MANUFACTURER f on a.SERVICEPROVIDERID = f.MANUFACTURER_ID"
                //+ "\rleft join T_CURRENCY g on a.CURRENCYID = g.CURRENCYID"
                + "\rwhere a.DEPOTOPERID = '" + spareInId + "'"
                + "\rorder by b.spare_name";
            dbAccess.GetDataTable(sql, out dtb, out err);
            return dtb;
        }

        /// <summary>
        ///  获得备件入库单明细信息数据.
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <param name="spareInId">备件入库单Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetSpareOutDetail(string spareOutId)
        {
            //变量定义部分.
            DataTable dtb;    //定义一个DataTable对象.
            string err;         //错误信息返回参数.
            //Select语句加工部分.
            sql = "select "
                + "a.SPAREOPERDETAIL_ID,"
                + "a.DEPOTOPERID,"
                + "a.spare_Id,"
                + "case when b.spare_name is not null then b.spare_name  "
                + "     when b.spare_name is null and b.spare_ename is not null then b.spare_ename  "
                + "     else '' end as spare_name,"
                + "b.partnumber,"
                + "a.warehouse_id,"
                + "c.warehouse_name,"
                + "case when e.stocksum is null then 0 else e.stocksum end as stocksum,"
                + "a.COUNT COUNT,"
                + "b.unit_name,"
                + "a.type_code,"
                + "a.remark,"
                + "case when b.ISSPECIALSP=1 then '进SAP' else '' end as ISSAP,"
                + "a.ship_id"
                + "\rfrom T_SPARE_DEPOT_OPERATION_DETAIL a "
                + "\rleft join t_spare b on a.spare_Id=b.spare_id "
                + "\rleft join t_som_warehouse c on a.warehouse_id=c.warehouse_id "
                //与备件库存查询关联（指定船舶、指定仓库、指定计量单位的备件）.
                + "\rleft join ("
                + "            select warehouse_id,spare_id,STOCKSAll as stocksum,ship_id from V_SPARE_STOCKS "
                + "          ) e on (a.warehouse_id = e.warehouse_id and a.spare_id = e.spare_id and e.ship_id = a.ship_id) "
                + "\rwhere a.DEPOTOPERID = '" + spareOutId + "'"
                + "\rorder by b.spare_name";//按创建时间排序.
            dbAccess.GetDataTable(sql, out dtb, out err);
            return dtb;
        }

        /// <summary>
        ///  获得备件入库单信息数据.
        /// </summary>       
        /// <param name="shipId">船舶Id</param>
        /// <param name="startDate">起始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="othersData">其他人数据</param>
        /// <param name="onlyUnfinished">仅未完成(包含没有填写完成或没有审核完成的数据)</param>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetSpareOperation(bool inOfOut, string shipId, string startDate, string endDate, bool othersData, bool onlyUnfinished)
        {
            //变量定义部分.
            DataTable dtb;    //定义一个DataTable对象.
            string err;         //错误信息返回参数.
            string sSql;                   //查询数据所需的SQL语句.
            string sWhere = "";                 //查询条件.

            //Where条件加工部分.
            if (!string.IsNullOrEmpty(shipId))
                sWhere += " and a.ship_Id='" + shipId + "' ";
            sWhere += (onlyUnfinished ? " and (iscomplete !=1 or (state < 4 and state != 3))" : "");
            //如果是部门长，则看本部门的，如果不是高级船员，则只能看自己的.
            //如果没有完成的，仅自己可以看到.
            //如果看他人信息，则仅能看完成的,而必须随时看到自己的，所以必须加上a.iscomplete = 0一句，与where中的相应部分呼应.
            //以上注释使用的是离散数学中与非关系相关的知识，很难一下理解，如果要修改，请先理解程序本意。.
            //这里不做权限判断，调用前请过滤不能看别人数据的人员。.
            if (othersData && !onlyUnfinished)
            {
                if (!CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS && !CommonOperation.ConstParameter.LoginUserInfo.ISLANDPERSON)
                {
                    sWhere += " and  (a.iscomplete = 1 and  rtrim(c.DEPARTNAME) = '"
                        + dbOperation.ReplaceSqlKeyStr(CommonOperation.ConstParameter.LoginUserInfo.DepartmentName) + "' or  a.iscomplete = 0)";
                }
            }
            else if (!othersData)
            {
                sWhere += " and a.OPERATION_PERSON_POSTID = '" + CommonOperation.ConstParameter.LoginUserInfo.PostId + "'";
            }

            sWhere += " and a.OPERATION_DATE between '" + startDate + "' and '" + endDate + "' ";

            //Select语句加工部分.
            sSql = "select "
                + "a.iscomplete, "
                + "a.DEPOTOPERID,"
                + "a.ship_id,"
                + "b.ship_name,"
                + "a.OPERATION_CODE,"
                + "rtrim(c.DEPARTNAME) DEPARTNAME,"
                + "a.OPERATION_DATE ,"
                + "a.OPERATION_PERSON_POSTID,"
                + "case a.state when 1 then '等待船端审核' when 2 then '等待岸端审核' when 3 then '审核不通过' when 4 then '岸端审核通过' when 5 then '已经盘点' end stateName,"
                + "a.OPERATION_PERSON ,"
                + "a.remark,a.state,CHECKDATE,SHIPCHECKER,LANDCHECKER,"
                + "BALANCEDEPOTOPERID,case when BALANCEDEPOTOPERID is null then 0 else 1 end StrikeToBalance,"
                + "isnull((select count(1) from T_SPARE_DEPOT_OPERATION x where x.BALANCEDEPOTOPERID = a.DEPOTOPERID),0) hasBeenBalanced "
                + ",case a.INSTORAGETYPE when 1 then '订单入库' when 2 then '申请单入库' when 3 then '手工入库' else '未知状态' end INSTORAGETYPENAME"
                + "\rfrom T_SPARE_DEPOT_OPERATION a "
                + "inner join t_ship b on a.ship_id=b.ship_id "
                + "inner join T_DEPARTMENT c on a.DEPART_ID = c.DEPARTMENTID";
            if (CommonOperation.ConstParameter.IsLandVersion)
                sSql += " inner join T_USER_SHIP us on us.ship_id=a.SHIP_ID and us.userid = '" + CommonOperation.ConstParameter.UserId + "'";
            sSql += "\rwhere IN_OR_OUT = " + (inOfOut ? "1" : "2");
            //设置查询的Where条件.
            if (sWhere.Trim().Length > 0)
            {
                sSql += sWhere;
            }
            sSql += "\rorder by a.OPERATION_DATE desc, ltrim(isnull(BALANCEDEPOTOPERID,'')) + DEPOTOPERID ";//按创建时间排序.
            dbAccess.GetDataTable(sSql, out dtb, out err);
            return dtb;
        }

        public bool StrikeABalance(string operationId, string balanceReason, out string err)
        {
            err = "";
            string newid = Guid.NewGuid().ToString();
            List<string> sqls = new List<string>();
            sql = "insert into T_SPARE_DEPOT_OPERATION([DEPOTOPERID],[SHIP_ID],[COMPONENT_UNIT_ID],[OPERATION_CODE],[OPERATION_PERSON],[OPERATION_PERSON_POSTID]"
                + ",[IN_OR_OUT],[OPERATION_DATE],[DEPART_ID],[SHIPCHECKER],[LANDCHECKER],[CHECKDATE],[ISCOMPLETE],[REMARK],[STATE],[BALANCEDEPOTOPERID])"
                + "select '" + newid + "',[SHIP_ID],[COMPONENT_UNIT_ID],[OPERATION_CODE],[OPERATION_PERSON],[OPERATION_PERSON_POSTID]"
                + ",[IN_OR_OUT],[OPERATION_DATE],[DEPART_ID],[SHIPCHECKER],'" + dbOperation.ReplaceSqlKeyStr(CommonOperation.ConstParameter.UserName)
                + "'," + dbOperation.DbToDate(DateTime.Today) + ",[ISCOMPLETE],'" + dbOperation.ReplaceSqlKeyStr(balanceReason) + "',[STATE],'"
                + dbOperation.ReplaceSqlKeyStr(operationId) + "'"
                + "\rfrom T_SPARE_DEPOT_OPERATION where DEPOTOPERID = '" + dbOperation.ReplaceSqlKeyStr(operationId) + "'";
            sqls.Add(sql);
            sql = "INSERT INTO T_SPARE_DEPOT_OPERATION_DETAIL([SPAREOPERDETAIL_ID],[DEPOTOPERID],[SPARE_ID],[SPARE_NAME],[PARTNUMBER],[WAREHOUSE_ID],[COUNT]"
                + ",[TYPE_CODE],[REMARK],[ORDER_CODE] ,[SHIP_ID],[COMPONENT_UNIT_ID])"
                + "\rselect newid(),'" + newid + "',[SPARE_ID],[SPARE_NAME],[PARTNUMBER],[WAREHOUSE_ID],[COUNT] * -1,"
                + "[TYPE_CODE],[REMARK],[ORDER_CODE] ,[SHIP_ID],[COMPONENT_UNIT_ID] "
                + "\rfrom T_SPARE_DEPOT_OPERATION_DETAIL where DEPOTOPERID = '" + dbOperation.ReplaceSqlKeyStr(operationId) + "'";
            sqls.Add(sql);

            return dbAccess.ExecSql(sqls, out err);
        }
        public bool RemoveABalance(string operationId, out string err)
        {
            err = "";
            sql = "select DEPOTOPERID from T_SPARE_DEPOT_OPERATION where BALANCEDEPOTOPERID = '" + dbOperation.ReplaceSqlKeyStr(operationId) + "'";

            string newid = dbAccess.GetString(sql);
            if (string.IsNullOrEmpty(newid)) return true;

            List<string> sqls = new List<string>();
            sql = "delete T_SPARE_DEPOT_OPERATION_DETAIL where DEPOTOPERID = '" + dbOperation.ReplaceSqlKeyStr(newid) + "'";
            sqls.Add(sql);
            sql = "delete T_SPARE_DEPOT_OPERATION where DEPOTOPERID = '" + dbOperation.ReplaceSqlKeyStr(newid) + "'";
            sqls.Add(sql);

            return dbAccess.ExecSql(sqls, out err);
        }
        public bool CloneABalancedBill(string operationId, string shipid, out string err)
        {
            err = "";
            string newid = Guid.NewGuid().ToString();

            List<string> sqls = new List<string>();
            sql = "insert into T_SPARE_DEPOT_OPERATION([DEPOTOPERID],[SHIP_ID],[COMPONENT_UNIT_ID],[OPERATION_CODE],[OPERATION_PERSON],[OPERATION_PERSON_POSTID]"
                + ",[IN_OR_OUT],[OPERATION_DATE],[DEPART_ID],[SHIPCHECKER],[LANDCHECKER],[CHECKDATE],[ISCOMPLETE],[REMARK],[STATE],[BALANCEDEPOTOPERID])"
                + "select '" + newid + "',[SHIP_ID],[COMPONENT_UNIT_ID],'" + StorageCommonService.Instance.GetSpareAndMaterialInOrOutCode(shipid) + "',"
                + "'" + dbOperation.ReplaceSqlKeyStr(CommonOperation.ConstParameter.UserName) + "','" + CommonOperation.ConstParameter.LoginUserInfo.PostId + "'"
                + ",[IN_OR_OUT],[OPERATION_DATE],[DEPART_ID],"
                + (CommonOperation.ConstParameter.IsLandVersion ? "''" : "[SHIPCHECKER]") + ",''," + dbOperation.DbToDate(DateTime.Today) + ","
                + (CommonOperation.ConstParameter.IsLandVersion ? "1" : "0") + ",'根据冲账账单' + OPERATION_CODE +'快速形成的新入库单',"
                + (CommonOperation.ConstParameter.IsLandVersion ? "2" : "1") + ",null"
                + "\rfrom T_SPARE_DEPOT_OPERATION where DEPOTOPERID = '" + dbOperation.ReplaceSqlKeyStr(operationId) + "'";
            sqls.Add(sql);
            sql = "INSERT INTO T_SPARE_DEPOT_OPERATION_DETAIL([SPAREOPERDETAIL_ID],[DEPOTOPERID],[SPARE_ID],[SPARE_NAME],[PARTNUMBER],[WAREHOUSE_ID],[COUNT]"
                + ",[TYPE_CODE],[REMARK],[ORDER_CODE] ,[SHIP_ID],[COMPONENT_UNIT_ID],CURRENCYID,AMOUNT,SERVICEPROVIDERID)"
                + "\rselect newid(),'" + newid + "',[SPARE_ID],[SPARE_NAME],[PARTNUMBER],[WAREHOUSE_ID],[COUNT],"
                + "[TYPE_CODE],[REMARK],[ORDER_CODE] ,[SHIP_ID],[COMPONENT_UNIT_ID],CURRENCYID,AMOUNT,SERVICEPROVIDERID "
                + "\rfrom T_SPARE_DEPOT_OPERATION_DETAIL where DEPOTOPERID = '" + dbOperation.ReplaceSqlKeyStr(operationId) + "'";
            sqls.Add(sql);

            return dbAccess.ExecSql(sqls, out err);
        }
        #endregion

    }
}
