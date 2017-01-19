/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：CTB_XFJSTJBService.cs
 * 创 建 人：徐正本
 * 创建时间：2012-4-6
 * 标    题：数据操作类
 * 功能描述：T_CTB_XFJSTJB数据操作类
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
    /// 数据层实例化接口类 dbo.T_CTB_XFJSTJBService.cs
    /// </summary>
    public partial class CTB_XFJSTJBService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象
        /// </summary>
        private static CTB_XFJSTJBService instance = new CTB_XFJSTJBService();
        public static CTB_XFJSTJBService Instance
        {
            get
            {
                if (null == instance)
                {
                    CTB_XFJSTJBService.instance = new CTB_XFJSTJBService();
                }
                return CTB_XFJSTJBService.instance;
            }
        }
        private CTB_XFJSTJBService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。
        /// </summary>
        /// <param name="unit">CTB_XFJSTJB对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(CTB_XFJSTJB unit, out string err)
        {
            if (unit.ID != null && unit.ID.Length > 0) //edit
            {
                sql = "UPDATE [T_CTB_XFJSTJB] SET "
                    + " [ID] = " + (string.IsNullOrEmpty(unit.ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.ID) + "'")
                    + " , [SortNo] = " + (unit.SortNo == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SortNo) + "'")
                    + " , [EquipmentName] = " + (unit.EquipmentName == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.EquipmentName) + "'")
                    + " , [EquipmentCOUNT] = " + (unit.EquipmentCOUNT == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.EquipmentCOUNT) + "'")
                    + " , [EquipmentSPEC] = " + (unit.EquipmentSPEC == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.EquipmentSPEC) + "'")
                    + " , [WarningDate] = " + dbOperation.DbToDate(unit.WarningDate)
                    + " , [LastCHECKEDDateDetail] = " + (unit.LastCHECKEDDateDetail == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.LastCHECKEDDateDetail) + "'")
                    + " , [ValidDateDetail] = " + (unit.ValidDateDetail == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.ValidDateDetail) + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIP_ID) + "'")
                    + "\rwhere ID = '" + dbOperation.ReplaceSqlKeyStr(unit.ID) + "'";
            }
            else
            {
                unit.ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_CTB_XFJSTJB] ("
                    + "[ID],"
                    + "[SortNo],"
                    + "[EquipmentName],"
                    + "[EquipmentCOUNT],"
                    + "[EquipmentSPEC],"
                    + "[WarningDate],"
                    + "[LastCHECKEDDateDetail],"
                    + "[ValidDateDetail],"
                    + "[SHIP_ID]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.ID) + "'")
                    + " , " + (unit.SortNo == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SortNo) + "'")
                    + " , " + (unit.EquipmentName == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.EquipmentName) + "'")
                    + " , " + (unit.EquipmentCOUNT == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.EquipmentCOUNT) + "'")
                    + " , " + (unit.EquipmentSPEC == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.EquipmentSPEC) + "'")
                    + " ," + dbOperation.DbToDate(unit.WarningDate)
                    + " , " + (unit.LastCHECKEDDateDetail == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.LastCHECKEDDateDetail) + "'")
                    + " , " + (unit.ValidDateDetail == null ? "''" : "'" + dbOperation.ReplaceSqlKeyStr(unit.ValidDateDetail) + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + dbOperation.ReplaceSqlKeyStr(unit.SHIP_ID) + "'")
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_CTB_XFJSTJB中的对象
        /// </summary>
        /// <param name="unit">要删除的T_CTB_XFJSTJB对象</param>
        internal bool deleteUnit(CTB_XFJSTJB unit, out string err)
        {
            return deleteUnit(unit.ID, out err);
        }

        /// <summary>
        /// 删除数据表T_CTB_XFJSTJB中的一条记录
        /// </summary>
        /// <param name="unit">要删除的T_CTB_XFJSTJB.iD主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_CTB_XFJSTJB where ID='" + dbOperation.ReplaceSqlKeyStr(unitid) + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_CTB_XFJSTJB 所有数据信息
        /// </summary>
        /// <returns>T_CTB_XFJSTJB DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "ID"
                + ",SortNo"
                + ",EquipmentName"
                + ",EquipmentCOUNT"
                + ",EquipmentSPEC"
                + ",WarningDate"
                + ",LastCHECKEDDateDetail"
                + ",ValidDateDetail"
                + ",SHIP_ID"
                + "\rfrom T_CTB_XFJSTJB order by sortno ";
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
        /// 根据一个主键ID,得到 T_CTB_XFJSTJB 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>CTB_XFJSTJB DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "ID"
                + ",SortNo"
                + ",EquipmentName"
                + ",EquipmentCOUNT"
                + ",EquipmentSPEC"
                + ",WarningDate"
                + ",LastCHECKEDDateDetail"
                + ",ValidDateDetail"
                + ",SHIP_ID"
                + "\rfrom T_CTB_XFJSTJB "
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
        /// 根据ctb_xfjstjb 的DataRow封装对象
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>ctb_xfjstjb 数据实体</returns>
        public CTB_XFJSTJB getObject(DataRow dr)
        {
            CTB_XFJSTJB unit = new CTB_XFJSTJB();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造CTB_XFJSTJB类对象!";
                return unit;
            }
            if (DBNull.Value != dr["ID"])
                unit.ID = dr["ID"].ToString();
            if (DBNull.Value != dr["SortNo"])
                unit.SortNo = dr["SortNo"].ToString();
            if (DBNull.Value != dr["EquipmentName"])
                unit.EquipmentName = dr["EquipmentName"].ToString();
            if (DBNull.Value != dr["EquipmentCOUNT"])
                unit.EquipmentCOUNT = dr["EquipmentCOUNT"].ToString();
            if (DBNull.Value != dr["EquipmentSPEC"])
                unit.EquipmentSPEC = dr["EquipmentSPEC"].ToString();
            if (DBNull.Value != dr["WarningDate"])
                unit.WarningDate = (DateTime)dr["WarningDate"];
            if (DBNull.Value != dr["LastCHECKEDDateDetail"])
                unit.LastCHECKEDDateDetail = dr["LastCHECKEDDateDetail"].ToString();
            if (DBNull.Value != dr["ValidDateDetail"])
                unit.ValidDateDetail = dr["ValidDateDetail"].ToString();
            if (DBNull.Value != dr["SHIP_ID"])
                unit.SHIP_ID = dr["SHIP_ID"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个CTB_XFJSTJB对象
        /// </summary>
        /// <param name="iD">iD</param>
        /// <returns>CTB_XFJSTJB对象</returns>
        public CTB_XFJSTJB getObject(string Id, out string err)
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
        /// 得到  T_CTB_XFJSTJB 所有数据信息
        /// </summary>
        /// <returns>T_CTB_XFJSTJB DataTable</returns>
        public DataTable getInfoOfOneShip(string shipId, out string err)
        {
            if (string.IsNullOrEmpty(shipId))
            {
                err = "传入参数shipId无效！";
                return null;
            }
            sql = string.Format(@"with keepTheLastOne(ctb_id,CATEGERY01,ship_id,xfjsid)
  as
  (  select t1.T_CTB_ID,t1.CATEGERY01,t2.ship_id,t3.xfjsid
  from T_CTB t1 inner join T_SHIP t2 on t1.CT_CLASS = '消防救生设备、器材统计表' and t2.ship_id = '{0}' 
    left join  (select SortNo,EquipmentName,SHIP_ID ,max(id) xfjsid
                from t_ctb_xfjstjb 
                where  EquipmentSPEC is not null or EquipmentCOUNT is not null 
                or  LastCHECKEDDateDetail is not null or ValidDateDetail is not null
                group by SortNo,EquipmentName,SHIP_ID ) t3
        on t1.CATEGERY01 = t3.EquipmentName  and t2.SHIP_ID = t3.SHIP_ID 
   )
 insert into dbo.T_CTB_XFJSTJB (ID, SortNo, EquipmentName, EquipmentCOUNT, EquipmentSPEC, WarningDate, LastCHECKEDDateDetail, ValidDateDetail, SHIP_ID)
  select newid() ID, isnull(sortno,cast(tt2.SEQUNCE as varchar(50))) sortno,
   tt1.CATEGERY01 EquipmentName, EquipmentCOUNT, EquipmentSPEC, WarningDate, LastCHECKEDDateDetail, ValidDateDetail, tt1.ship_id
  from ( select t1.*
        from keepTheLastOne t1 
        where t1.xfjsid is not null 
        union all
        select t2.ctb_id,t2.CATEGERY01,t2.ship_id ,t3.xfjsid
        from keepTheLastOne t2 
            left join  (select SortNo,EquipmentName,SHIP_ID ,max(id) xfjsid
                        from t_ctb_xfjstjb group by SortNo,EquipmentName,SHIP_ID ) t3 
            on t2.CATEGERY01 = t3.EquipmentName and t2.ship_id = t3.SHIP_ID 
            where t2.xfjsid is null ) tt1 
        inner join T_CTB tt2 on tt1.ctb_id = tt2.T_CTB_ID
        left join T_CTB_XFJSTJB tt3 on tt1.xfjsid  = tt3.ID 
   where  tt3.ID is null ", shipId);
            if (!dbAccess.ExecSql(sql, out err)) return null;

            sql = string.Format(@" select ID, SortNo, EquipmentName, EquipmentCOUNT, EquipmentSPEC, WarningDate, LastCHECKEDDateDetail, ValidDateDetail, SHIP_ID
from dbo.t_ctb_xfjstjb 
where ship_id = '{0}'
order by convert(integer,sortno)", shipId);
            DataTable dt;
            dbAccess.GetDataTable(sql, out dt, out err);
            sql = string.Format(@"select t1.CATEGERY01  from t_ctb t1 inner join t_ctb_xfjstjb t2 
on   t1.CATEGERY01 = t2.EquipmentName and t2.ship_id = '{0}'
group by t1.CATEGERY01 ,t1.SEQUNCE  
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
            sql = @"with keepTheLastOne(ctb_id,CATEGERY01,ship_id,xfjsid)
  as
  (  select t1.T_CTB_ID,t1.CATEGERY01,t2.ship_id,t3.xfjsid
  from T_CTB t1 inner join T_SHIP t2 on t1.CT_CLASS = '消防救生设备、器材统计表' 
    left join  (select SortNo,EquipmentName,SHIP_ID ,max(id) xfjsid
                from t_ctb_xfjstjb 
                where  EquipmentSPEC is not null or EquipmentCOUNT is not null 
                or  LastCHECKEDDateDetail is not null or ValidDateDetail is not null
                group by SortNo,EquipmentName,SHIP_ID ) t3
        on t1.CATEGERY01 = t3.EquipmentName  and t2.SHIP_ID = t3.SHIP_ID 
   )
  delete  t_ctb_xfjstjb
  where ID not in (
  select id from 
    ( select t1.*
        from keepTheLastOne t1 
        where t1.xfjsid is not null 
        union all
        select t2.ctb_id,t2.CATEGERY01,t2.ship_id ,t3.xfjsid
        from keepTheLastOne t2 
            left join  (select SortNo,EquipmentName,SHIP_ID ,max(id) xfjsid
                            from t_ctb_xfjstjb group by SortNo,EquipmentName,SHIP_ID ) t3 on t2.CATEGERY01 = t3.EquipmentName and t2.ship_id = t3.SHIP_ID 
                            where t2.xfjsid is null and t3.xfjsid is not null) tt1 
            inner join T_CTB tt2 on tt1.ctb_id = tt2.T_CTB_ID
        inner join T_CTB_XFJSTJB tt3 on tt1.xfjsid  = tt3.ID ) ";
            string err;
            dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 得到当前用户可以看到的船的消防救生用品到期报警情况信息
        /// </summary>
        /// <returns></returns>
        public int GetAlertXFJS(out string shipid)
        {
            sql = string.Format(
                  @"select count(1) c,max(t1.ship_id) shipid
from T_CTB_XFJSTJB t1 inner join T_ModelTypeRight t2 on t2.ModelTypeName = '消防救生设备、器材统计表'{0} 
where t1.WarningDate <= getdate()
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

