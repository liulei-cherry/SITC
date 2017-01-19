/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：SparePurchaseApplyService.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/9/12
 * 标    题：数据操作类
 * 功能描述：T_SPARE_PURCHASE_APPLY数据操作类
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
    /// 数据层实例化接口类 dbo.T_SPARE_PURCHASE_APPLYService.cs
    /// </summary>
    public partial class SparePurchaseApplyService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static SparePurchaseApplyService instance = new SparePurchaseApplyService();
        public static SparePurchaseApplyService Instance
        {
            get
            {
                if (null == instance)
                {
                    SparePurchaseApplyService.instance = new SparePurchaseApplyService();
                }
                return SparePurchaseApplyService.instance;
            }
        }
        private SparePurchaseApplyService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">SparePurchaseApply对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(SparePurchaseApply unit, out string err)
        {
            if (unit.PURCHASE_APPLYID != null && unit.PURCHASE_APPLYID.Length > 0) //edit
            {
                sql = "UPDATE [T_SPARE_PURCHASE_APPLY] SET "
                    + " [PURCHASE_APPLYID] = " + (string.IsNullOrEmpty(unit.PURCHASE_APPLYID) ? "null" : "'" + unit.PURCHASE_APPLYID.Replace("'", "''") + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , [COMPONENT_UNIT_ID] = " + (string.IsNullOrEmpty(unit.COMPONENT_UNIT_ID) ? "null" : "'" + unit.COMPONENT_UNIT_ID.Replace("'", "''") + "'")
                    + " , [PURCHASE_APPLY_CODE] = " + (unit.PURCHASE_APPLY_CODE == null ? "''" : "'" + unit.PURCHASE_APPLY_CODE.Replace("'", "''") + "'")
                    + " , [PURCHASE_APPLY_PERSON] = " + (unit.PURCHASE_APPLY_PERSON == null ? "''" : "'" + unit.PURCHASE_APPLY_PERSON.Replace("'", "''") + "'")
                    + " , [PURCHASE_APPLY_PERSON_POSTID] = " + (string.IsNullOrEmpty(unit.PURCHASE_APPLY_PERSON_POSTID) ? "null" : "'" + unit.PURCHASE_APPLY_PERSON_POSTID.Replace("'", "''") + "'")
                    + " , [PURCHASE_APPLY_DATE] = " + dbOperation.DbToDate(unit.PURCHASE_APPLY_DATE)
                    + " , [DEPART_ID] = " + (string.IsNullOrEmpty(unit.DEPART_ID) ? "null" : "'" + unit.DEPART_ID.Replace("'", "''") + "'")
                    + " , [SHIP_LEADER_CHECKER] = " + (unit.SHIP_LEADER_CHECKER == null ? "''" : "'" + unit.SHIP_LEADER_CHECKER.Replace("'", "''") + "'")
                    + " , [SHIP_LEADER_CHECKDATE] = " + dbOperation.DbToDate(unit.SHIP_LEADER_CHECKDATE)
                    + " , [SHIP_BOSS_CHECKER] = " + (unit.SHIP_BOSS_CHECKER == null ? "''" : "'" + unit.SHIP_BOSS_CHECKER.Replace("'", "''") + "'")
                    + " , [SHIP_BOSS_CHECKDATE] = " + dbOperation.DbToDate(unit.SHIP_BOSS_CHECKDATE)
                    + " , [LANDCHECKER] = " + (unit.LANDCHECKER == null ? "''" : "'" + unit.LANDCHECKER.Replace("'", "''") + "'")
                    + " , [CHECKDATE] = " + dbOperation.DbToDate(unit.CHECKDATE)
                    + " , [ISCOMPLETE] = " + unit.ISCOMPLETE.ToString()
                    + " , [REMARK] = N" + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
                    + " , [STATE] = " + unit.STATE.ToString()
                    + " where upper(PURCHASE_APPLYID) = '" + unit.PURCHASE_APPLYID.ToUpper() + "'";
            }
            else
            {
                unit.PURCHASE_APPLYID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_SPARE_PURCHASE_APPLY] ("
                    + "[PURCHASE_APPLYID],"
                    + "[SHIP_ID],"
                    + "[COMPONENT_UNIT_ID],"
                    + "[PURCHASE_APPLY_CODE],"
                    + "[PURCHASE_APPLY_PERSON],"
                    + "[PURCHASE_APPLY_PERSON_POSTID],"
                    + "[PURCHASE_APPLY_DATE],"
                    + "[DEPART_ID],"
                    + "[SHIP_LEADER_CHECKER],"
                    + "[SHIP_LEADER_CHECKDATE],"
                    + "[SHIP_BOSS_CHECKER],"
                    + "[SHIP_BOSS_CHECKDATE],"
                    + "[LANDCHECKER],"
                    + "[CHECKDATE],"
                    + "[ISCOMPLETE],"
                    + "[REMARK],"
                    + "[STATE]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.PURCHASE_APPLYID) ? "null" : "'" + unit.PURCHASE_APPLYID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.COMPONENT_UNIT_ID) ? "null" : "'" + unit.COMPONENT_UNIT_ID.Replace("'", "''") + "'")
                    + " , " + (unit.PURCHASE_APPLY_CODE == null ? "''" : "'" + unit.PURCHASE_APPLY_CODE.Replace("'", "''") + "'")
                    + " , " + (unit.PURCHASE_APPLY_PERSON == null ? "''" : "'" + unit.PURCHASE_APPLY_PERSON.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.PURCHASE_APPLY_PERSON_POSTID) ? "null" : "'" + unit.PURCHASE_APPLY_PERSON_POSTID.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.PURCHASE_APPLY_DATE)
                    + " , " + (string.IsNullOrEmpty(unit.DEPART_ID) ? "null" : "'" + unit.DEPART_ID.Replace("'", "''") + "'")
                    + " , " + (unit.SHIP_LEADER_CHECKER == null ? "''" : "'" + unit.SHIP_LEADER_CHECKER.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.SHIP_LEADER_CHECKDATE)
                    + " , " + (unit.SHIP_BOSS_CHECKER == null ? "''" : "'" + unit.SHIP_BOSS_CHECKER.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.SHIP_BOSS_CHECKDATE)
                    + " , " + (unit.LANDCHECKER == null ? "''" : "'" + unit.LANDCHECKER.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.CHECKDATE)
                    + " ," + unit.ISCOMPLETE.ToString()
                    + " , N" + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
                    + " ," + unit.STATE.ToString()
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 向数据库中保存一条新记录。. 2014.2.18 刘子建增加
        /// </summary>
        /// <param name="unit">SparePurchaseApply对象</param>
        /// <returns>插入的对象更新</returns>	
        internal string saveUnit(SparePurchaseApply unit)
        {
            if (unit.PURCHASE_APPLYID != null && unit.PURCHASE_APPLYID.Length > 0) //edit
            {
                sql = "UPDATE [T_SPARE_PURCHASE_APPLY] SET "
                    + " [PURCHASE_APPLYID] = " + (string.IsNullOrEmpty(unit.PURCHASE_APPLYID) ? "null" : "'" + unit.PURCHASE_APPLYID.Replace("'", "''") + "'")
                    + " , [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , [COMPONENT_UNIT_ID] = " + (string.IsNullOrEmpty(unit.COMPONENT_UNIT_ID) ? "null" : "'" + unit.COMPONENT_UNIT_ID.Replace("'", "''") + "'")
                    + " , [PURCHASE_APPLY_CODE] = " + (unit.PURCHASE_APPLY_CODE == null ? "''" : "'" + unit.PURCHASE_APPLY_CODE.Replace("'", "''") + "'")
                    + " , [PURCHASE_APPLY_PERSON] = " + (unit.PURCHASE_APPLY_PERSON == null ? "''" : "'" + unit.PURCHASE_APPLY_PERSON.Replace("'", "''") + "'")
                    + " , [PURCHASE_APPLY_PERSON_POSTID] = " + (string.IsNullOrEmpty(unit.PURCHASE_APPLY_PERSON_POSTID) ? "null" : "'" + unit.PURCHASE_APPLY_PERSON_POSTID.Replace("'", "''") + "'")
                    + " , [PURCHASE_APPLY_DATE] = " + dbOperation.DbToDate(unit.PURCHASE_APPLY_DATE)
                    + " , [DEPART_ID] = " + (string.IsNullOrEmpty(unit.DEPART_ID) ? "null" : "'" + unit.DEPART_ID.Replace("'", "''") + "'")
                    + " , [SHIP_LEADER_CHECKER] = " + (unit.SHIP_LEADER_CHECKER == null ? "''" : "'" + unit.SHIP_LEADER_CHECKER.Replace("'", "''") + "'")
                    + " , [SHIP_LEADER_CHECKDATE] = " + dbOperation.DbToDate(unit.SHIP_LEADER_CHECKDATE)
                    + " , [SHIP_BOSS_CHECKER] = " + (unit.SHIP_BOSS_CHECKER == null ? "''" : "'" + unit.SHIP_BOSS_CHECKER.Replace("'", "''") + "'")
                    + " , [SHIP_BOSS_CHECKDATE] = " + dbOperation.DbToDate(unit.SHIP_BOSS_CHECKDATE)
                    + " , [LANDCHECKER] = " + (unit.LANDCHECKER == null ? "''" : "'" + unit.LANDCHECKER.Replace("'", "''") + "'")
                    + " , [CHECKDATE] = " + dbOperation.DbToDate(unit.CHECKDATE)
                    + " , [ISCOMPLETE] = " + unit.ISCOMPLETE.ToString()
                    + " , [REMARK] = N" + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
                    + " , [STATE] = " + unit.STATE.ToString()
                    + " where upper(PURCHASE_APPLYID) = '" + unit.PURCHASE_APPLYID.ToUpper() + "'";
            }
            else
            {
                unit.PURCHASE_APPLYID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_SPARE_PURCHASE_APPLY] ("
                    + "[PURCHASE_APPLYID],"
                    + "[SHIP_ID],"
                    + "[COMPONENT_UNIT_ID],"
                    + "[PURCHASE_APPLY_CODE],"
                    + "[PURCHASE_APPLY_PERSON],"
                    + "[PURCHASE_APPLY_PERSON_POSTID],"
                    + "[PURCHASE_APPLY_DATE],"
                    + "[DEPART_ID],"
                    + "[SHIP_LEADER_CHECKER],"
                    + "[SHIP_LEADER_CHECKDATE],"
                    + "[SHIP_BOSS_CHECKER],"
                    + "[SHIP_BOSS_CHECKDATE],"
                    + "[LANDCHECKER],"
                    + "[CHECKDATE],"
                    + "[ISCOMPLETE],"
                    + "[REMARK],"
                    + "[STATE]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.PURCHASE_APPLYID) ? "null" : "'" + unit.PURCHASE_APPLYID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.COMPONENT_UNIT_ID) ? "null" : "'" + unit.COMPONENT_UNIT_ID.Replace("'", "''") + "'")
                    + " , " + (unit.PURCHASE_APPLY_CODE == null ? "''" : "'" + unit.PURCHASE_APPLY_CODE.Replace("'", "''") + "'")
                    + " , " + (unit.PURCHASE_APPLY_PERSON == null ? "''" : "'" + unit.PURCHASE_APPLY_PERSON.Replace("'", "''") + "'")
                    + " , " + (string.IsNullOrEmpty(unit.PURCHASE_APPLY_PERSON_POSTID) ? "null" : "'" + unit.PURCHASE_APPLY_PERSON_POSTID.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.PURCHASE_APPLY_DATE)
                    + " , " + (string.IsNullOrEmpty(unit.DEPART_ID) ? "null" : "'" + unit.DEPART_ID.Replace("'", "''") + "'")
                    + " , " + (unit.SHIP_LEADER_CHECKER == null ? "''" : "'" + unit.SHIP_LEADER_CHECKER.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.SHIP_LEADER_CHECKDATE)
                    + " , " + (unit.SHIP_BOSS_CHECKER == null ? "''" : "'" + unit.SHIP_BOSS_CHECKER.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.SHIP_BOSS_CHECKDATE)
                    + " , " + (unit.LANDCHECKER == null ? "''" : "'" + unit.LANDCHECKER.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.CHECKDATE)
                    + " ," + unit.ISCOMPLETE.ToString()
                    + " , N" + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
                    + " ," + unit.STATE.ToString()
                    + ")";
            }

            return sql;
        }
        /// <summary>
        /// 删除数据表T_SPARE_PURCHASE_APPLY中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_SPARE_PURCHASE_APPLY对象</param>
        internal bool deleteUnit(SparePurchaseApply unit, out string err)
        {
            return deleteUnit(unit.PURCHASE_APPLYID, out err);
        }

        /// <summary>
        /// 删除数据表T_SPARE_PURCHASE_APPLY中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_SPARE_PURCHASE_APPLY.pURCHASE_APPLYID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_SPARE_PURCHASE_APPLY where "
                + " upper(T_SPARE_PURCHASE_APPLY.PURCHASE_APPLYID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_SPARE_PURCHASE_APPLY 所有数据信息.
        /// </summary>
        /// <returns>T_SPARE_PURCHASE_APPLY DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "PURCHASE_APPLYID"
                + ",SHIP_ID"
                + ",COMPONENT_UNIT_ID"
                + ",PURCHASE_APPLY_CODE"
                + ",PURCHASE_APPLY_PERSON"
                + ",PURCHASE_APPLY_PERSON_POSTID"
                + ",PURCHASE_APPLY_DATE"
                + ",DEPART_ID"
                + ",SHIP_LEADER_CHECKER"
                + ",SHIP_LEADER_CHECKDATE"
                + ",SHIP_BOSS_CHECKER"
                + ",SHIP_BOSS_CHECKDATE"
                + ",LANDCHECKER"
                + ",CHECKDATE"
                + ",ISCOMPLETE"
                + ",REMARK"
                + ",STATE"
                + "  from T_SPARE_PURCHASE_APPLY ";
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
        /// 根据一个主键ID,得到 T_SPARE_PURCHASE_APPLY 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>SparePurchaseApply DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "PURCHASE_APPLYID"
                + ",SHIP_ID"
                + ",COMPONENT_UNIT_ID"
                + ",PURCHASE_APPLY_CODE"
                + ",PURCHASE_APPLY_PERSON"
                + ",PURCHASE_APPLY_PERSON_POSTID"
                + ",PURCHASE_APPLY_DATE"
                + ",DEPART_ID"
                + ",SHIP_LEADER_CHECKER"
                + ",SHIP_LEADER_CHECKDATE"
                + ",SHIP_BOSS_CHECKER"
                + ",SHIP_BOSS_CHECKDATE"
                + ",LANDCHECKER"
                + ",CHECKDATE"
                + ",ISCOMPLETE"
                + ",REMARK"
                + ",STATE"
                + " from T_SPARE_PURCHASE_APPLY "
                + " where upper(PURCHASE_APPLYID)='" + Id.ToUpper() + "'";
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
        /// 根据sparepurchaseapply 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>sparepurchaseapply 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
        public SparePurchaseApply getObject(DataRow dr)
        {
            SparePurchaseApply unit = new SparePurchaseApply();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造SparePurchaseApply类对象!";
                return unit;
            }
            if (DBNull.Value != dr["PURCHASE_APPLYID"])
                unit.PURCHASE_APPLYID = dr["PURCHASE_APPLYID"].ToString();
            if (DBNull.Value != dr["SHIP_ID"])
                unit.SHIP_ID = dr["SHIP_ID"].ToString();
            if (DBNull.Value != dr["COMPONENT_UNIT_ID"])
                unit.COMPONENT_UNIT_ID = dr["COMPONENT_UNIT_ID"].ToString();
            if (DBNull.Value != dr["PURCHASE_APPLY_CODE"])
                unit.PURCHASE_APPLY_CODE = dr["PURCHASE_APPLY_CODE"].ToString();
            if (DBNull.Value != dr["PURCHASE_APPLY_PERSON"])
                unit.PURCHASE_APPLY_PERSON = dr["PURCHASE_APPLY_PERSON"].ToString();
            if (DBNull.Value != dr["PURCHASE_APPLY_PERSON_POSTID"])
                unit.PURCHASE_APPLY_PERSON_POSTID = dr["PURCHASE_APPLY_PERSON_POSTID"].ToString();
            if (DBNull.Value != dr["PURCHASE_APPLY_DATE"])
                unit.PURCHASE_APPLY_DATE = (DateTime)dr["PURCHASE_APPLY_DATE"];
            if (DBNull.Value != dr["DEPART_ID"])
                unit.DEPART_ID = dr["DEPART_ID"].ToString();
            if (DBNull.Value != dr["SHIP_LEADER_CHECKER"])
                unit.SHIP_LEADER_CHECKER = dr["SHIP_LEADER_CHECKER"].ToString();
            if (DBNull.Value != dr["SHIP_LEADER_CHECKDATE"])
                unit.SHIP_LEADER_CHECKDATE = (DateTime)dr["SHIP_LEADER_CHECKDATE"];
            if (DBNull.Value != dr["SHIP_BOSS_CHECKER"])
                unit.SHIP_BOSS_CHECKER = dr["SHIP_BOSS_CHECKER"].ToString();
            if (DBNull.Value != dr["SHIP_BOSS_CHECKDATE"])
                unit.SHIP_BOSS_CHECKDATE = (DateTime)dr["SHIP_BOSS_CHECKDATE"];
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

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个SparePurchaseApply对象.
        /// </summary>
        /// <param name="pURCHASE_APPLYID">pURCHASE_APPLYID</param>
        /// <returns>SparePurchaseApply对象</returns>
        public SparePurchaseApply getObject(string Id, out string err)
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

        #region 根据过滤条件查询
        public bool SelectDataTable(String sWhere, out DataTable dt, out string errMessage)
        {

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("select	");
                sb.AppendLine("spa.PURCHASE_APPLYID");
                sb.AppendLine(",spa.PURCHASE_APPLY_CODE");
                sb.AppendLine(",spa.SHIP_ID");
                sb.AppendLine(",s.SHIP_NAME");

                sb.AppendLine(",spa.STATE");
                sb.AppendLine(" ,case spa.STATE ");
                sb.AppendLine("  when '0' then '未填写完毕'");
                sb.AppendLine("  when '1' then '等待部门长审核'");
                sb.AppendLine("  when '2' then '等待船长确认'");
                sb.AppendLine("  when '3' then '等待岸端机务主管审批'");
                sb.AppendLine("  when '4' then '等待岸端机务经理审批'");
                sb.AppendLine("  when '5' then '等待船管总经理审批'");
                sb.AppendLine("  when '6' then '审核通过'");
                sb.AppendLine("  when '7' then '不再处理'");
                sb.AppendLine("  when '8' then '被打回'");
                sb.AppendLine("  when '9' then '已订购'");
                sb.AppendLine("  when '-1' then '船端合单'");
                sb.AppendLine("  when '-2' then '部分订购'");
                sb.AppendLine("  when '-3' then '部分入库'");
                sb.AppendLine("  when '-4' then '全部入库'");
                sb.AppendLine("  end as STATE_NAME");
                sb.AppendLine(",spa.PURCHASE_APPLY_DATE");
                sb.AppendLine(",spa.COMPONENT_UNIT_ID");
                sb.AppendLine(",cu.COMP_CHINESE_NAME");
                sb.AppendLine(",dbo.F_Get_Comp_Full_name(spa.COMPONENT_UNIT_ID,1) COMP_FULL_NAME");
                sb.AppendLine(",cu.COMPONENT_TYPE_ID");
                sb.AppendLine(",spa.PURCHASE_APPLY_PERSON");
                sb.AppendLine(",spa.PURCHASE_APPLY_PERSON_POSTID");
                sb.AppendLine(",bh.HEADSHIP_NAME");
                sb.AppendLine(",bh.ISLANDPOST");
                sb.AppendLine(",spa.DEPART_ID");
                sb.AppendLine(",d.DEPARTNAME");
                sb.AppendLine(",spa.ISCOMPLETE");
                sb.AppendLine(" ,case spa.ISCOMPLETE ");
                sb.AppendLine("  when '0' then '未填写完毕'");
                sb.AppendLine("  when '1' then '填写完毕'");
                sb.AppendLine("  end as ISCOMPLETE_NAME");
                sb.AppendLine(",spa.SHIP_LEADER_CHECKER");
                sb.AppendLine(",spa.SHIP_LEADER_CHECKDATE");
                sb.AppendLine(",spa.SHIP_BOSS_CHECKER");
                sb.AppendLine(",spa.SHIP_BOSS_CHECKDATE");
                sb.AppendLine(",spa.LANDCHECKER");
                sb.AppendLine(",spa.CHECKDATE");
                sb.AppendLine(",spa.REMARK");
                sb.AppendLine(",cu.COMP_SERIAL_NO"); //设备序列号(李景育加2016-06-30)
                sb.AppendLine(",ty.COMPTYPE_CHINESE_NAME"); //设备类型(李景育加2016-06-30)
                sb.AppendLine(" from T_SPARE_PURCHASE_APPLY spa");
                sb.AppendLine(" inner join T_SHIP s on s.SHIP_ID=spa.SHIP_ID ");
                if (CommonOperation.ConstParameter.IsLandVersion)
                    sb.AppendLine("  inner join T_USER_SHIP us on us.ship_id=spa.SHIP_ID and us.userid = '" + CommonOperation.ConstParameter.UserId + "'");
                sb.AppendLine(" inner join T_BASE_HEADSHIP bh on bh.SHIP_HEADSHIP_ID=spa.PURCHASE_APPLY_PERSON_POSTID ");
                sb.AppendLine(" inner join T_DEPARTMENT d on d.DEPARTMENTID=spa.DEPART_ID ");
                sb.AppendLine(" left join T_COMPONENT_UNIT cu on cu.COMPONENT_UNIT_ID=spa.COMPONENT_UNIT_ID ");
                sb.AppendLine(" left join T_COMPONENT_TYPE ty on cu.COMPONENT_TYPE_ID=ty.COMPONENT_TYPE_ID ");//(李景育加2016-06-30)
                sb.AppendLine(" where 1=1 ");
                if (!string.IsNullOrEmpty(sWhere))
                    sb.AppendLine(sWhere);
                sb.AppendLine(" order by spa.PURCHASE_APPLY_DATE desc");
                dt = new DataTable();
                return dbAccess.GetDataTable(sb.ToString(), out dt, out errMessage);
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                dt = null;
                return false;
            }
        }
        #endregion
    }
}
