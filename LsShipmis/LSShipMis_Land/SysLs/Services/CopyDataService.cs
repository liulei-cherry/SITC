using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.Functions;
using CommonOperation.Interfaces;
using ItemsManage.DataObject;
using ItemsManage.Services;
using System.Data;

namespace LSShipMis_Land.SysLs.Services
{
    public class CopyDataService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static CopyDataService instance = new CopyDataService();
        public static CopyDataService Instance
        {
            get
            {
                if (null == instance)
                {
                    CopyDataService.instance = new CopyDataService();
                }
                return CopyDataService.instance;
            }
        }
        private CopyDataService() { }
        #endregion

        private static IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();

        public bool CopyEquipment(string shipSource, DateTime originDate, string shipTarget,Boolean isCopyWorkInfo, out string err)
        {
            List<string> createSqlList = new List<string>();
            //清空指向表.
            createSqlList.Add("delete from T_TOOL_POINTTO");
            //导入设备.
            string icComponentUnit = "where ship_id='" + shipSource + "' and PARENT_UNIT_ID is not null";//临时解决方案.
            List<string> osComponentUnit = new List<string>();
            osComponentUnit.Add(this.UpdateShipByPointto(shipTarget));
            osComponentUnit.Add(this.UpdateSomeByPointto("PARENT_UNIT_ID"));

            //临时解决方案.
            #region 指定父ID为设备顶级(船舶)和 错误父ID指定为顶级,临时解决方案
            ComponentUnit cu = ComponentUnitService.Instance.GetObjectByRootAndShipId(shipTarget, out err);
            if (cu == null)
            {
                err = "目标船顶级设备找不到";
                return false;
            }
            osComponentUnit.Add("update CopyDateTempTable set PARENT_UNIT_ID ='" + cu.COMPONENT_UNIT_ID + "' where PARENT_UNIT_ID is null");
            #endregion

            createSqlList.AddRange(this.CopyDataPointto("T_COMPONENT_UNIT", "COMPONENT_UNIT_ID", icComponentUnit, osComponentUnit));
            //导入设备类型关系.
            string icEquipmentClassRef = "where COMPONENT_UNIT_ID in (select oldid from T_TOOL_POINTTO)";
            List<string> osEquipmentClassRef = new List<string>();
            osEquipmentClassRef.Add(this.UpdateSomeByPointto("COMPONENT_UNIT_ID"));
            createSqlList.AddRange(this.CopyDataNotPointto("T_EQUIPMENT_CLASS_REF", "REFID", icEquipmentClassRef, osEquipmentClassRef));
            if (isCopyWorkInfo)
            {
                //导入工作信息.
                string icWorkInfo = "where ship_id='" + shipSource + "'";
                List<string> osWorkInfo = new List<string>();
                osWorkInfo.Add(this.UpdateShipByPointto(shipTarget));
                osWorkInfo.Add(this.UpdateSomeByPointto("REFOBJID"));
                createSqlList.AddRange(this.CopyDataPointto("T_WORKINFO", "WORKINFOID", icWorkInfo, osWorkInfo));

                //导入工作信息历史.
                string icWorkInfoOut = "where ship_id='" + shipSource + "' and datediff(year,ANNUAL,'" + originDate.ToString("yyyy-MM-dd") + "')=0";
                List<string> osWorkInfoOut = new List<string>();
                osWorkInfoOut.Add(this.UpdateShipByPointto(shipTarget));
                osWorkInfoOut.Add(this.UpdateSomeByPointto("WORKID"));
                createSqlList.AddRange(this.CopyDataNotPointto("T_WORKINFO_HISTORY_OUT", "WHID", icWorkInfoOut, osWorkInfoOut));
                //清空指向表.
                createSqlList.Add("delete from T_TOOL_POINTTO");
            }
            return dbAccess.ExecSql(createSqlList, out err);

        }
        /// <summary>
        /// 更新船舶ID,船舶ID为ship_id
        /// </summary>
        /// <param name="shipTarget">目标船舶ID</param>
        /// <returns>sql语句</returns>
        public string UpdateShipByPointto(string shipTarget)
        {
            return ("update CopyDateTempTable set ship_id='" + shipTarget + "'");
        }
        /// <summary>
        /// 通过指向表来更新某列数据.
        /// </summary>
        /// <param name="columnName">列名</param>
        /// <returns>sql语句</returns>
        public string UpdateSomeByPointto(string columnName)
        {
            return ("update CopyDateTempTable set " + columnName + "=(select tp.newid from T_TOOL_POINTTO tp where tp.oldid=CopyDateTempTable." + columnName + ")");
        }
        /// <summary>
        /// 复制,并生成指向表数据.
        /// </summary>
        /// <param name="tableName">要复制的表名</param>
        /// <param name="primaryKey">要复制的表的主键</param>
        /// <param name="importCondition">复制条件</param>
        /// <param name="otherSql">其他语句(在生成临时表之后需要做的其他操作)</param>
        /// <returns>sql语句集合</returns>
        public List<string> CopyDataPointto(string tableName, string primaryKey, string importCondition, List<string> otherSql)
        {
            List<string> sqlList = new List<string>();
            //假如存在临时表就删除.
            sqlList.Add("if exists (select * from sysobjects where [name] = 'CopyDateTempTable' and xtype='U') begin drop table CopyDateTempTable end");
            //把源表的结构与符合条件的数据复制到临时表.
            sqlList.Add("select * into CopyDateTempTable from [" + tableName + "] " + importCondition);
            //生成指向表数据.
            sqlList.Add("insert into T_TOOL_POINTTO select NEWID()," + primaryKey + ",NEWID() from CopyDateTempTable ");
            //更新临时表主键为指向表 NEWID
            sqlList.Add("update CopyDateTempTable set " + primaryKey + "=(select tp.newid from T_TOOL_POINTTO tp where tp.oldid=CopyDateTempTable." + primaryKey + ")");
            //更新其他数据.
            if (otherSql != null && otherSql.Count > 0)
                sqlList.AddRange(otherSql);
            //从临时表导回到源数据表.
            sqlList.Add("insert into [" + tableName + "] SELECT * FROM CopyDateTempTable");
            //删除临时表.
            sqlList.Add("drop table CopyDateTempTable");
            return sqlList;
        }

        /// <summary>
        /// 复制,但不生成指向表数据.
        /// </summary>
        /// <param name="tableName">要复制的表名</param>
        /// <param name="primaryKey">要复制的表的主键</param>
        /// <param name="importCondition">复制条件</param>
        /// <param name="otherSql">其他语句(在生成临时表之后需要做的其他操作)</param>
        /// <returns>sql语句集合</returns>
        public List<string> CopyDataNotPointto(string tableName, string primaryKey, string importCondition, List<string> otherSql)
        {
            List<string> sqlList = new List<string>();
            //假如存在临时表就删除.
            sqlList.Add("if exists (select * from sysobjects where [name] = 'CopyDateTempTable' and xtype='U') begin drop table CopyDateTempTable end");
            //把源表的结构与符合条件的数据复制到临时表.
            sqlList.Add("select * into CopyDateTempTable from [" + tableName + "] " + importCondition);
            //更新临时表主键.
            sqlList.Add("update CopyDateTempTable set " + primaryKey + "=NEWID()");
            //更新其他数据.
            if (otherSql != null && otherSql.Count > 0)
                sqlList.AddRange(otherSql);
            //从临时表导回到源数据表.
            sqlList.Add("insert into [" + tableName + "] SELECT * FROM CopyDateTempTable");
            //删除临时表.
            sqlList.Add("drop table CopyDateTempTable");
            return sqlList;
        }
        /// <summary>
        /// 按年度 得到船舶是否有原始工作信息,是否有年度工作信息,是否有年度工单.
        /// </summary>
        /// <param name="year"></param>
        /// <param name="dt"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool GetShipWorkInfoStateByYear(DateTime year, out DataTable dt, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select ");
            sb.AppendLine("ship_id");
            sb.AppendLine(",ship_name");

            sb.AppendLine(",case when (SELECT  ");
            sb.AppendLine(" COUNT(*)");
            sb.AppendLine(" FROM T_WorkInfo ");
            sb.AppendLine("where 1=1 ");
            sb.AppendLine("and ship_id=s.ship_id)>0 then '有'");
            sb.AppendLine("else '无' end as ishasworkinfo");

            sb.AppendLine(",case when (SELECT  ");
            sb.AppendLine("COUNT(*)");
            sb.AppendLine(" FROM T_WORKINFO_HISTORY_OUT who ");
            sb.AppendLine(" inner join T_WorkInfo t1 on t1.WorkInfoID = who.WORKID");
            sb.AppendLine("where 1=1 ");
            sb.AppendLine("and who.ship_id=s.ship_id");
            sb.AppendLine("and datediff(year,who.ANNUAL,'" + year.ToString("yyyy-MM-dd") + "')=0)>0 then '有'");
            sb.AppendLine("else '无' end as ishasyearworkinfo");

            sb.AppendLine(",case when (SELECT  ");
            sb.AppendLine("COUNT(*)");
            sb.AppendLine("FROM T_WORKINFO_HISTORY_OUT who ");
            sb.AppendLine(" inner join T_WorkInfo t1 on t1.WorkInfoID = who.WORKID");
            sb.AppendLine(" inner join T_WORKORDER wo on wo.WORKINFOID=t1.WORKINFOID");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine("and who.ship_id=s.ship_id");
            sb.AppendLine("and datediff(year,who.ANNUAL,'" + year.ToString("yyyy-MM-dd") + "')=0)>0 then '有'");
            sb.AppendLine(" else '无' end as ishasyearworkorder");

            sb.AppendLine("from T_SHIP s");
            return dbAccess.GetDataTable(sb.ToString(), out dt, out err);
        }
    }
}
