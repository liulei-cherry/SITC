/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：CTB_TDSBTJBService.cs
 * 创 建 人：徐正本
 * 创建时间：2012-4-6
 * 标    题：数据操作类
 * 功能描述：T_CTB_TDSBTJB数据操作类
 * Codesmith DataAccessLayer.cst 1.02版本生成
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
using CustomTable.Haifeng.DataObject;
using CommonOperation.BaseClass;

namespace CustomTable.Haifeng.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_CTB_TDSBTJBService.cs
    /// </summary>
    public partial class CTB_TDSBTJBService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象
        /// </summary>
        private static CTB_TDSBTJBService instance = new CTB_TDSBTJBService();
        public static CTB_TDSBTJBService Instance
        {
            get
            {
                if (null == instance)
                {
                    CTB_TDSBTJBService.instance = new CTB_TDSBTJBService();
                }
                return CTB_TDSBTJBService.instance;
            }
        }
        private CTB_TDSBTJBService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。
        /// </summary>
        /// <param name="unit">CTB_TDSBTJB对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(CTB_TDSBTJB unit, out string err)
        {
            if (unit.ID != null && unit.ID.Length > 0) //edit
            {
                sql = "UPDATE [T_CTB_TDSBTJB] SET "
                    + " [ID] = " + (string.IsNullOrEmpty(unit.ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.ID) + "'")
                    + " , [EquipmentName] = " + (unit.EquipmentName == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.EquipmentName) + "'")
                    + " , [SortNo] = " + (unit.SortNo == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SortNo) + "'")
                    + " , [SEQUNCE] = " + (unit.SEQUNCE == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SEQUNCE) + "'")
                    + " , [DueDate] = " + dbOperation.DbToDate(unit.DueDate)
                    + " , [EquipmentFactory] = " + (unit.EquipmentFactory == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.EquipmentFactory) + "'")
                    + " , [EquipmentType] = " + (unit.EquipmentType == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.EquipmentType) + "'")
                    + " , [EquipSerialNo] = " + (unit.EquipSerialNo == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.EquipSerialNo) + "'")
                    + " , [Detail] = " + (unit.Detail == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.Detail) + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIP_ID) + "'")
                    + "\rwhere ID = '" + dbOperation.ReplaceSqlKeyStr(unit.ID) + "'";
            }
            else
            {
                unit.ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_CTB_TDSBTJB] ("
                    + "[ID],"
                    + "[EquipmentName],"
                    + "[SortNo],"
                    + "[SEQUNCE],"
                    + "[DueDate],"
                    + "[EquipmentFactory],"
                    + "[EquipmentType],"
                    + "[EquipSerialNo],"
                    + "[Detail],"
                    + "[SHIP_ID]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.ID) + "'")
                    + " , " + (unit.EquipmentName == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.EquipmentName) + "'")
                    + " , " + (unit.SortNo == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SortNo) + "'")
                    + " , " + (unit.SEQUNCE == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SEQUNCE) + "'")
                    + " ," + dbOperation.DbToDate(unit.DueDate)
                    + " , " + (unit.EquipmentFactory == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.EquipmentFactory) + "'")
                    + " , " + (unit.EquipmentType == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.EquipmentType) + "'")
                    + " , " + (unit.EquipSerialNo == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.EquipSerialNo) + "'")
                    + " , " + (unit.Detail == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.Detail) + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIP_ID) + "'")
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_CTB_TDSBTJB中的对象
        /// </summary>
        /// <param name="unit">要删除的T_CTB_TDSBTJB对象</param>
        internal bool deleteUnit(CTB_TDSBTJB unit, out string err)
        {
            return deleteUnit(unit.ID, out err);
        }

        /// <summary>
        /// 删除数据表T_CTB_TDSBTJB中的一条记录
        /// </summary>
        /// <param name="unit">要删除的T_CTB_TDSBTJB.iD主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_CTB_TDSBTJB where ID='" + dbOperation.ReplaceSqlKeyStr(unitid) + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_CTB_TDSBTJB 所有数据信息
        /// </summary>
        /// <returns>T_CTB_TDSBTJB DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "ID"
                + ",SortNo"
                + ",SEQUNCE" + ",EquipmentName"
                + ",DueDate"
                + ",EquipmentFactory"
                + ",EquipmentType"
                + ",EquipSerialNo"
                + ",Detail"
                + ",SHIP_ID"
                + "\rfrom T_CTB_TDSBTJB ";
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
        /// 根据一个主键ID,得到 T_CTB_TDSBTJB 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>CTB_TDSBTJB DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "ID"
                + ",SortNo"
                + ",SEQUNCE" + ",EquipmentName"
                + ",DueDate"
                + ",EquipmentFactory"
                + ",EquipmentType"
                + ",EquipSerialNo"
                + ",Detail"
                + ",SHIP_ID"
                + "\rfrom T_CTB_TDSBTJB "
                + "\rwhere ID='" + dbOperation.ReplaceSqlKeyStr(Id) + "'";
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
        /// 根据ctb_tdsbtjb 的DataRow封装对象
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>ctb_tdsbtjb 数据实体</returns>
        public CTB_TDSBTJB getObject(DataRow dr)
        {
            CTB_TDSBTJB unit = new CTB_TDSBTJB();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造CTB_TDSBTJB类对象!";
                return unit;
            }
            if (DBNull.Value != dr["ID"])
                unit.ID = dr["ID"].ToString();
            if (DBNull.Value != dr["EquipmentName"])
                unit.EquipmentName = dr["EquipmentName"].ToString();
            if (DBNull.Value != dr["SortNo"])
                unit.SortNo = dr["SortNo"].ToString();
            if (DBNull.Value != dr["SEQUNCE"])
                unit.SEQUNCE = dr["SEQUNCE"].ToString();
            if (DBNull.Value != dr["DueDate"])
                unit.DueDate = (DateTime)dr["DueDate"];
            if (DBNull.Value != dr["EquipmentFactory"])
                unit.EquipmentFactory = dr["EquipmentFactory"].ToString();
            if (DBNull.Value != dr["EquipmentType"])
                unit.EquipmentType = dr["EquipmentType"].ToString();
            if (DBNull.Value != dr["EquipSerialNo"])
                unit.EquipSerialNo = dr["EquipSerialNo"].ToString();
            if (DBNull.Value != dr["Detail"])
                unit.Detail = dr["Detail"].ToString();
            if (DBNull.Value != dr["SHIP_ID"])
                unit.SHIP_ID = dr["SHIP_ID"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个CTB_TDSBTJB对象
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>CTB_TDSBTJB对象</returns>
        public CTB_TDSBTJB getObject(string Id, out string err)
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
        /// 得到  T_CTB_TDSBTJB 所有数据信息
        /// </summary>
        /// <returns>T_CTB_TDSBTJB DataTable</returns>
        public DataTable getInfoOfOneShip(string shipId, out string err)
        {
            if (string.IsNullOrEmpty(shipId))
            {
                err = "传入参数shipId无效！";
                return null;
            }
            sql = string.Format(@"with keepTheLastOne(ctb_id,CATEGERY02,ship_id,tdsbid)
  as
  (  select t1.T_CTB_ID,t1.CATEGERY02,t2.ship_id,t3.tdsbid
  from T_CTB t1 inner join T_SHIP t2 on t1.CT_CLASS = '通信导航设备有效期统计表' and t2.ship_id = '{0}' 
    left join  (select SortNo,EquipmentName,SHIP_ID ,max(id) tdsbid
                from T_CTB_TDSBTJB 
                where DueDate is not null or EquipmentFactory is not null 
                or  EquipmentType is not null or EquipSerialNo is not null or  Detail is not null 
                group by SortNo,EquipmentName,SHIP_ID ) t3
        on t1.CATEGERY02 = t3.EquipmentName  and t2.SHIP_ID = t3.SHIP_ID 
   )
 insert into dbo.T_CTB_TDSBTJB(ID, EquipmentName, SortNo, SEQUNCE, DueDate, EquipmentFactory, EquipmentType, EquipSerialNo, Detail, SHIP_ID)
  select newid()  ID, tt1.CATEGERY02 EquipmentName, isnull(sortno,cast(tt2.SEQUNCE as varchar(50))) sortno,
  tt2.CATEGERY01 SEQUNCE,  DueDate, EquipmentFactory, EquipmentType, EquipSerialNo, Detail, tt1.ship_id
  from ( select t1.*
        from keepTheLastOne t1 
        where t1.tdsbid is not null 
        union all
        select t2.ctb_id,t2.CATEGERY02,t2.ship_id ,t3.tdsbid
        from keepTheLastOne t2 
            left join  (select EquipmentName,SHIP_ID ,max(id) tdsbid
                        from T_CTB_TDSBTJB group by EquipmentName,SHIP_ID ) t3 
            on t2.CATEGERY02 = t3.EquipmentName and t2.ship_id = t3.SHIP_ID 
            where t2.tdsbid is null ) tt1 
        inner join T_CTB tt2 on tt1.ctb_id = tt2.T_CTB_ID
        left join T_CTB_TDSBTJB tt3 on tt1.tdsbid  = tt3.ID 
    where  tt3.ID is null ", shipId);
            if (!dbAccess.ExecSql(sql, out err)) return null;

            sql = string.Format(@" select ID, EquipmentName, SortNo, SEQUNCE, DueDate, EquipmentFactory, EquipmentType, EquipSerialNo, Detail, SHIP_ID
from dbo.T_CTB_TDSBTJB 
where ship_id = '{0}'
order by convert(integer,sortno)", shipId);
            DataTable dt;
            dbAccess.GetDataTable(sql, out dt, out err);
            sql = string.Format(@"select t1.CATEGERY02  from t_ctb t1 inner join T_CTB_TDSBTJB t2 
on   t1.CATEGERY02 = t2.EquipmentName and t2.ship_id = '{0}'
group by t1.CATEGERY02 ,t1.SEQUNCE  
having COUNT (1) > 1", shipId);
            string errName = dbAccess.GetString(sql);
            if (!string.IsNullOrEmpty(errName))
            {
                DeleteMoreData();
            }
            return dt;

        }

        private void DeleteMoreData()
        {
            sql = @"with keepTheLastOne(ctb_id,CATEGERY02,ship_id,tdsbid)
  as
  (  select t1.T_CTB_ID,t1.CATEGERY02,t2.ship_id,t3.tdsbid
  from T_CTB t1 inner join T_SHIP t2 on t1.CT_CLASS = '通信导航设备有效期统计表' 
    left join  (select EquipmentName,SHIP_ID ,max(id) tdsbid
                from T_CTB_TDSBTJB 
                where DueDate is not null or EquipmentFactory is not null 
                or EquipmentType is not null or EquipSerialNo is not null or  Detail is not null 
                group by EquipmentName,SHIP_ID ) t3
        on t1.CATEGERY02 = t3.EquipmentName  and t2.SHIP_ID = t3.SHIP_ID 
   )
  delete  T_CTB_TDSBTJB
  where ID not in (
  select id from 
    ( select t1.*
        from keepTheLastOne t1 
        where t1.tdsbid is not null 
        union all
        select t2.ctb_id,t2.CATEGERY02,t2.ship_id ,t3.tdsbid
        from keepTheLastOne t2 
            left join  (select EquipmentName,SHIP_ID ,max(id) tdsbid
                            from T_CTB_TDSBTJB group by EquipmentName,SHIP_ID ) t3 on t2.CATEGERY02 = t3.EquipmentName and t2.ship_id = t3.SHIP_ID 
                            where t2.tdsbid is null and t3.tdsbid is not null) tt1 
            inner join T_CTB tt2 on tt1.ctb_id = tt2.T_CTB_ID
        inner join T_CTB_TDSBTJB tt3 on tt1.tdsbid  = tt3.ID ) ";
            string err;
            dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 得到当前用户可以看到的船的消防救生用品到期报警情况信息
        /// </summary>
        /// <returns></returns>
        public int GetAlertTDSB(out string shipid)
        {
            sql = string.Format(
               @"select count(1) c,max(t1.ship_id) shipid
from T_CTB_TDSBTJB t1 inner join T_ModelTypeRight t2 on t2.ModelTypeName = '通信导航设备有效期统计表'{0} 
where t1.DueDate <= dateadd(day,90,getdate())
and t2.onlyRead= 1 and t2.HeadShipId = '{1}'",
                 CommonOperation.ConstParameter.IsLandVersion ?
                    string.Format(@"
inner join T_USER_SHIP tt on t1.ship_id = tt.ship_id and tt.userid = {0}",
                    dbOperation.ReplaceSqlKeyStr(CommonOperation.ConstParameter.UserId)) : "",
                    CommonOperation.ConstParameter.LoginUserInfo.PostId);
            DataTable dt;
            string err;
            if (dbAccess.GetDataTable(sql, out dt, out err) && dt.Rows.Count >= 1)
            {
                int ire;
                if (int.TryParse(dt.Rows[0][0].ToString(), out ire) && ire > 0)
                {
                    shipid = dt.Rows[0][1].ToString();
                    return ire;
                }
            }
            shipid = "";
            return 0;

        }
    }
}
