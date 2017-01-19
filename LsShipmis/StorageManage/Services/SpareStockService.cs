/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：SpareStockService.cs
 * 创 建 人：xuzhengben
 * 创建时间：2010/9/15
 * 标    题：备件库存业务类
 * 功能描述：
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
using StorageManage.DataObject;
using BaseInfo.DataObject;

namespace StorageManage.Services
{
    /// <summary>
    /// 数据层实例化接口类.
    /// </summary>
    public partial class SpareStockService
    {
        #region 构造函数

        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static SpareStockService instance = new SpareStockService();
        public static SpareStockService Instance
        {
            get
            {
                if (null == instance)
                {
                    SpareStockService.instance = new SpareStockService();
                }
                return SpareStockService.instance;
            }
        }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 库存是否可以操作的检验方法

        /// <summary>
        /// 备件业务是否允许重新初始化.
        /// 当所有的出入库操作状态均为4或5(完成或已经盘点)
        /// 盘点也都进行完成.
        /// 则可以进行库存初始化,或者盘点操作.
        /// </summary>
        /// <param name="shipId">那条船的</param>
        /// <param name="warehouseId">哪个仓库id</param>
        /// <returns>是否可以</returns>
        public bool SpareCanReinitOrCheck(string shipId, string warehouseId, string exceptId, out string err)
        {
            sql = "select count(1) c from T_SPARE_DEPOT_OPERATION t1 inner join T_SPARE_DEPOT_OPERATION_DETAIL t2"
                + "\r on t1.DEPOTOPERID = t2.DEPOTOPERID "
                + "\rwhere t1.SHIP_ID = t2.SHIP_ID and t2.SHIP_ID = '" + dbOperation.ReplaceSqlKeyStr(shipId)
                + "' and t2.WAREHOUSE_ID = '" + dbOperation.ReplaceSqlKeyStr(warehouseId) + "' and iscomplete = 1 and t1.STATE<4 and in_or_out = 1";
            DataTable dt;
            if (!dbAccess.GetDataTable(sql, out dt, out err))
            {
                return false;
            }
            if (dt.Rows.Count != 1 || dt.Rows[0]["c"].ToString() != "0")
            {
                err = "当前仓库存在条未完成的入库单";
                return false;
            }
            sql = "select count(1) c from T_SPARE_DEPOT_OPERATION t1 inner join T_SPARE_DEPOT_OPERATION_DETAIL t2"
    + "\r on t1.DEPOTOPERID = t2.DEPOTOPERID "
    + "\rwhere t1.SHIP_ID = t2.SHIP_ID and t2.SHIP_ID = '" + dbOperation.ReplaceSqlKeyStr(shipId)
    + "' and t2.WAREHOUSE_ID = '" + dbOperation.ReplaceSqlKeyStr(warehouseId) + "' and iscomplete = 1 and t1.STATE<4 and in_or_out = 2";

            if (!dbAccess.GetDataTable(sql, out dt, out err))
            {
                return false;
            }
            if (dt.Rows.Count != 1 || dt.Rows[0]["c"].ToString() != "0")
            {
                err = "当前仓库存在条未完成的出库单";
                return false;
            }

            sql = "select count(1) c from T_SPARE_DEPOT_CHECK t1 inner join T_SPARE_DEPOT_CHECK_DETAIL t2"
                + "\r on t1.DEPOTCHECKID = t2.DEPOTCHECKID "
                + "\rwhere t1.SHIP_ID = t2.SHIP_ID and t2.SHIP_ID = '" + dbOperation.ReplaceSqlKeyStr(shipId)
                + "' and t2.WAREHOUSE_ID = '" + dbOperation.ReplaceSqlKeyStr(warehouseId) + "' and t1.STATE<5"
                + (string.IsNullOrEmpty(exceptId) ? "" : " and t1.DEPOTCHECKID!='" + dbOperation.ReplaceSqlKeyStr(exceptId) + "'");
            if (!dbAccess.GetDataTable(sql, out dt, out err))
            {
                return false;
            }
            if (dt.Rows.Count != 1 || dt.Rows[0]["c"].ToString() != "0")
            {
                err = "当前仓库存在条未完成的盘点单";
                return false;
            }
            return true;
        }
        #endregion

        #region 库存查看统计函数

        /// <summary>
        ///  获得指定船舶指定仓库的指定备件库存信息数据.
        /// </summary>
        private DataTable getSpareStock(string shipId, string warehouseId, string spareId)
        {
            //变量定义部分.
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = @" select d.ATTACHTYPE,d.ATTACHCOMP, a.ship_id,b.ship_name,a.warehouse_id,c.warehouse_name,a.spare_id,
                    case when d.isspecialsp = 1 then d.spare_name  
                         when d.isspecialsp = 0 and d.spare_name is not null then d.spare_name + '(' + isnull(d.partnumber,'') + ')'   
                         when d.isspecialsp = 0 and d.spare_name is null and d.spare_ename is not null then d.spare_ename + '(' + isnull(d.partnumber,'') + ')' 
                         else '' end as spare_name,
                         d.partnumber,a.STOCKSAll stocks,d.ALERTSTOCK,d.unit_name,e.shipallstock,0 as isoutstock,0.0 as outnumb
                    from V_SPARE_STOCKS a inner join t_ship b on a.ship_id=b.ship_id 
                     inner join t_som_warehouse c on a.warehouse_id=c.warehouse_id
                     inner join t_spare d on a.spare_id=d.spare_id 
                     inner join (select spare_id,ship_id,sum(STOCKSAll) shipallstock from V_SPARE_STOCKS "
                        + (string.IsNullOrEmpty(shipId) ? "" : "where ship_id = '" + dbOperation.ReplaceSqlKeyStr(shipId) + "'")
                            + @"group by spare_id,ship_id) e
                                on e.spare_id = a.spare_id and e.ship_id = a.ship_id
                    where 1=1 ";
            if (!string.IsNullOrEmpty(shipId) && shipId.Length == 36) sSql += " and a.ship_Id = '" + dbOperation.ReplaceSqlKeyStr(shipId) + "' ";
            if (!string.IsNullOrEmpty(warehouseId) && warehouseId.Length == 36) sSql += " and a.warehouse_id = '" + dbOperation.ReplaceSqlKeyStr(warehouseId) + "' ";
            if (!string.IsNullOrEmpty(spareId) && spareId.Length == 36) sSql += " and a.spare_id = '" + dbOperation.ReplaceSqlKeyStr(spareId) + "' ";
            sSql += "\rorder by c.warehouse_name,d.spare_name,d.partnumber";//按创建时间排序.

            dbAccess.GetDataTable(sSql, out dtb, out err);
            return dtb;
        }

        /// <summary>
        ///  获得指定船舶所有仓库的备件库存信息数据.
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetSpareAllStock(string shipId)
        {
            return getSpareStock(shipId, null, null);
        }
        /// <summary>
        ///  获得指定船舶指定仓库的备件库存信息数据.
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <param name="warehouseId">仓库Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetSpareWareStock(string shipId, string warehouseId)
        {
            return getSpareStock(shipId, warehouseId, null);
        }
        /// <summary>
        ///  获得指定船舶指定仓库的备件库存信息数据.
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <param name="warehouseId">仓库Id</param>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetSpareStockOfShip(string shipId, string spareId)
        {
            return getSpareStock(shipId, null, spareId);
        }

        public bool GetSpareWarehouseInfo(string spareId, string shipId, out string warehouseId, out string warehouseName, out string err)
        {
            warehouseId = "";
            warehouseName = "";
            string sSql = "select top 1 a.warehouse_id,b.WAREHOUSE_NAME from V_SPARE_STOCKS a "
                + "\rinner join t_som_warehouse b on a.warehouse_id = b.warehouse_id and a.ship_id = b.ship_id where spare_id = '"
                + spareId + "' and a.ship_Id = '" + shipId + "' and STOCKSAll > 0 order by STOCKSAll desc";
            DataTable dt;
            if (!dbAccess.GetDataTable(sSql, out dt, out err) || dt.Rows.Count != 1) return false;
            warehouseId = dt.Rows[0]["warehouse_id"].ToString();
            warehouseName = dt.Rows[0]["WAREHOUSE_NAME"].ToString();
            return true;
        }

        /// <summary>
        /// 取得指定船舶某备件的所有库存信息,不特定某个库.
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <param name="spareId">备件Id</param>
        /// <returns>返回备件的库存信息</returns>
        public decimal GetSpareStock(string shipId, string spareId)
        {
            if (string.IsNullOrEmpty(shipId) || string.IsNullOrEmpty(spareId)) return 0;
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.
            string sStock = "";                 //库存信息.

            sSql = "select sum(STOCKSAll) "
                 + "\rfrom V_SPARE_STOCKS "
                 + "\rwhere ship_Id = '" + dbOperation.ReplaceSqlKeyStr(shipId) + "'"
                 + "\rand spare_Id = '" + dbOperation.ReplaceSqlKeyStr(spareId) + "'";

            if (dbAccess.GetString(sSql, out sStock, out err))
            {
                if (sStock.Length == 0)
                {
                    return 0;
                }
                return decimal.Parse(sStock);
            }
            else return 0;
        }
        /// <summary>
        /// 取得指定船舶某备件的所有库存信息.
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <param name="spareId">备件Id</param>
        /// <returns>返回备件的库存信息</returns>
        public decimal GetSpareStockOfWarehouse(string shipId, string spareId, string warehouseId)
        {
            if (string.IsNullOrEmpty(shipId) || string.IsNullOrEmpty(spareId) || string.IsNullOrEmpty(warehouseId)) return 0;
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.
            string sStock = "";                 //库存信息.

            sSql = "select sum(STOCKSAll) "
                 + "\rfrom V_SPARE_STOCKS "
                 + "\rwhere ship_Id = '" + dbOperation.ReplaceSqlKeyStr(shipId) + "'"
                 + "\rand spare_Id = '" + dbOperation.ReplaceSqlKeyStr(spareId) + "'"
                 + "\rand warehouse_id = '" + dbOperation.ReplaceSqlKeyStr(warehouseId) + "'";

            if (dbAccess.GetString(sSql, out sStock, out err))
            {
                if (sStock.Length == 0)
                {
                    return 0;
                }
                return decimal.Parse(sStock);
            }
            else return 0;
        }
        #endregion

        #region 库存更新业务相关函数

        /// <summary>
        /// 保存新的库存内容.
        /// </summary>
        /// <param name="dtOfNewStock">最新的库存内容数据表,必须包含以下列名的列( SHIP_ID , SPARE_ID ,WAREHOUSE_ID,STOCKS )</param>
        /// <param name="shipId">哪条船的处理</param>        
        /// <param name="err">错误信息</param>
        /// <returns>是否成功保存</returns>
        public bool SaveTheNewStockCount(DataTable dtOfNewStock, string shipId, out string err)
        {
            err = "";
            if (dtOfNewStock == null)
            {
                err = "传入的数据集合不存在,无法进行继续操作";
                return false;
            }
#if DEBUG
            //判断是否具备这些字段;
            if (!dtOfNewStock.Columns.Contains("SHIP_ID") || !dtOfNewStock.Columns.Contains("SPARE_ID") ||
                !dtOfNewStock.Columns.Contains("WAREHOUSE_ID") || !dtOfNewStock.Columns.Contains("STOCKS"))
            {
                err = "传入的数据集合不存在指定数据列,无法进行继续操作";
                return false;
            }
#endif
            #region 每100条数据构成一个sql语句,判断当前库存跟这个datatable中的是否一致,如果不一致,则进行差异化处理,差异化处理的备注中标明.
            //不一次性把所有的都提交是考虑到sql语法长度不能长于8000的限制.
            StringBuilder sqlData = new StringBuilder();
            List<DataTable> dtAll = new List<DataTable>();
            for (int i = 0, r = 1; i < dtOfNewStock.Rows.Count; i++)
            {
                if (r == 100 || i >= dtOfNewStock.Rows.Count - 1)
                {
                    r = 1;
                    sqlData.Append("select '" + dtOfNewStock.Rows[i]["SHIP_ID"].ToString() + "' SHIP_ID,'"
                       + dtOfNewStock.Rows[i]["SPARE_ID"].ToString() + "' SPARE_ID,'" + dtOfNewStock.Rows[i]["WAREHOUSE_ID"].ToString() + "' WAREHOUSE_ID,"
                       + dtOfNewStock.Rows[i]["STOCKS"].ToString() + " STOCKS\r");
                    sql = "select t1.SHIP_ID , t1.SPARE_ID ,t3.SPARE_NAME,t3.PARTNUMBER, t1.WAREHOUSE_ID, t1.STOCKSAll - isnull(t2.STOCKSAll,0) COUNT "
                       + "\rfrom (select  SHIP_ID , SPARE_ID ,WAREHOUSE_ID,sum(STOCKS) STOCKSAll "
                       + "\r from (" + sqlData + ")t\r group by  SHIP_ID , SPARE_ID ,WAREHOUSE_ID) t1 "
                       + "\rleft join V_SPARE_STOCKS t2 on t1.SHIP_ID = t2.SHIP_ID and t1.SPARE_ID = t2.SPARE_ID"
                       + "\rand t1.WAREHOUSE_ID = t2.WAREHOUSE_ID inner join T_SPARE t3 on t1.spare_id = t3.spare_id"
                       + "\rwhere (t1.STOCKSAll != t2.STOCKSAll or t2.STOCKSALL is null) and t1.SHIP_ID ='" + dbOperation.ReplaceSqlKeyStr(shipId) + "'";
                    DataTable dt;
                    if (!dbAccess.GetDataTable(sql, out dt, out err))
                    {
                        return false;
                    }
                    sqlData = new StringBuilder();
                    if (dt.Rows.Count > 0) dtAll.Add(dt);
                }
                else
                {
                    r++;
                    sqlData.Append("\rselect '" + dtOfNewStock.Rows[i]["SHIP_ID"].ToString() + "' SHIP_ID,'"
                        + dtOfNewStock.Rows[i]["SPARE_ID"].ToString() + "' SPARE_ID,'" + dtOfNewStock.Rows[i]["WAREHOUSE_ID"].ToString() + "' WAREHOUSE_ID,"
                        + dtOfNewStock.Rows[i]["STOCKS"].ToString() + " STOCKS\rUnion all\r");
                }
            }
            #endregion
            #region 如果存在任何数据,则进行事务操作,否则直接退出

            if (dtAll.Count == 0)
            {
                err = "没有修改任何数据!";
                return false;
            }
            dbAccess.BeginTransaction();
            //保存一个库存修改主表,状态是4:岸端已经完成审核,未被进入盘点.
            string newId = Guid.NewGuid().ToString();
            sql = "INSERT INTO [T_SPARE_DEPOT_OPERATION]"
            + "\r([DEPOTOPERID],[SHIP_ID],[COMPONENT_UNIT_ID],[OPERATION_CODE],[OPERATION_PERSON],[OPERATION_PERSON_POSTID],[IN_OR_OUT],[OPERATION_DATE]"
            + "\r,[DEPART_ID],[SHIPCHECKER],[LANDCHECKER],[CHECKDATE],[ISCOMPLETE],[REMARK],[STATE])"
            + "\rVALUES('" + newId + "','" + dbOperation.ReplaceSqlKeyStr(shipId) + "',null,'','" + CommonOperation.ConstParameter.UserName
            + "','" + CommonOperation.ConstParameter.LoginUserInfo.PostId + "',1,"
            + "\rgetdate(),'" + CommonOperation.ConstParameter.LoginUserInfo.DepartmentId + "','初始化自动审核','初始化自动审核',"
            + "\rgetdate(),1,'初始化库存自动形成的入库记录',4)";
            if (!dbAccess.ExecSql(sql, out err))
            {
                return false;
            }
            //顺序构成插入语句,插入到子表中.
            foreach (DataTable dt in dtAll)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sql = "INSERT INTO [T_SPARE_DEPOT_OPERATION_DETAIL]([SPAREOPERDETAIL_ID],[DEPOTOPERID],[SPARE_ID],"
                        + "\r[SPARE_NAME],[PARTNUMBER],[WAREHOUSE_ID],[COUNT],[TYPE_CODE],[REMARK],[SHIP_ID])"
                        + "\rVALUES(newid(),'" + newId + "','" + dr["SPARE_ID"].ToString() + "',N'" + dbOperation.ReplaceSqlKeyStr(dr["SPARE_NAME"].ToString()) + "',"
                        + "N'" + dbOperation.ReplaceSqlKeyStr(dr["PARTNUMBER"].ToString()) + "','" + dr["WAREHOUSE_ID"].ToString() + "'," + dr["COUNT"].ToString()
                        + ",'初始化','初始化库存形成记录','" + dbOperation.ReplaceSqlKeyStr(shipId) + "')";
                    if (!dbAccess.ExecSql(sql, out err))
                    {
                        return false;
                    }
                }
            }
            dbAccess.CommitTransaction();
            return true;
            #endregion
        }

        public bool ClearZeroStock(string shipId, out string err)
        {
            sql = "delete T_SPARE_STOCKS where STOCKS = 0 ";
            if (!string.IsNullOrEmpty(shipId))
                sql += "\r and ship_id= '" + shipId + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 外围调用,快速初始化
        public bool UpdateSpareStorage(string spareId, string shipId, Dictionary<string, decimal> storageInfo, out string err)
        {
            List<string> sqls = new List<string>();
            err = "";
            //if (CommonOperation.ConstParameter.IsLandVersion)
            //{
            //    err = "抱歉,库存初始化功能仅船舶端可以使用!";
            //    return false;
            //}
            ////;
            foreach (string storageName in storageInfo.Keys)
            {
                string tempStorageId = getStorageInfoByNameAndShip(storageName, shipId);
                if (string.IsNullOrEmpty(tempStorageId))
                {
                    ShipWareHouse tempStorage = new ShipWareHouse();
                    tempStorage.SHIP_ID = shipId;
                    tempStorage.WAREHOUSE_NAME = storageName;
                    if (tempStorage.Update(out err))
                    {
                        tempStorageId = tempStorage.GetId();
                    }
                    else
                    {
                        err = "抱歉,创建新的仓库时出错,错误代码是:" + err;
                        return false;
                    }
                }
                sqls.Add("DELETE FROM [dbo].[T_SPARE_STOCKS] WHERE SHIP_ID = '" + shipId + "' and SPARE_ID = '" + spareId + "' and WAREHOUSE_ID = '" + tempStorageId + "'");
                sqls.Add(" INSERT INTO [dbo].[T_SPARE_STOCKS]([STOCKS_ID],[SHIP_ID] ,[SPARE_ID] ,[WAREHOUSE_ID],[STOCKS],[CHANGE_DATE])"
                   + "VALUES(newid(),'" + shipId + "', '" + spareId + "','" + tempStorageId + "',"
                   + storageInfo[storageName].ToString() + ",getdate())");
            }
            return dbAccess.ExecSql(sqls, out err);
        }

        private string getStorageInfoByNameAndShip(string name, string shipId)
        {
            sql = "select WAREHOUSE_ID  from T_SOM_WAREHOUSE where ship_id = '" + shipId.Replace("'", "''")
                + "' and WAREHOUSE_NAME = '" + dbOperation.ReplaceSqlKeyStr(name) + "'";
            return dbAccess.GetString(sql);
        }
        #endregion
    }
}
