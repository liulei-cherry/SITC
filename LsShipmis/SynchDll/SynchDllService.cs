using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CommonOperation.Functions;
using CommonOperation.Interfaces;

namespace SynchDll
{
    public class SynchDllService
    {
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        private static SynchDllService instance;

        /// <summary>
        /// 实例化.
        /// </summary>
        public static SynchDllService GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SynchDllService();
                }
                return instance;
            }
        }

        public bool IsAUsefullTableId(string tableid)
        {
            string sql = "select count(1) from t_table_name where upper(table_id) = '" + tableid.ToUpper() + "'";
            return (dbAccess.GetString(sql) == "1");
        }

        /// <summary>
        /// 删除所有注册了的,却注册错误的列.
        /// </summary>
        /// <param name="tableid"></param>
        /// <returns></returns>
        public bool DeleteAllRegeditWrongColumns(string tableid, out string err)
        {
            string sql = "delete dbo.T_TABLE_FIELD where field_id in ( select field_id from ( " +
            "\nselect table_name,columnname,sort,value_type , t2.type_show_name from" +
            "\n(select id table_id ,name table_name from sysobjects where name like 'T_%' and name not like 'TEMP%' and xtype = 'U') t1" +
            "\ninner join (select t1.id table_id, t1.name columnName,t1.colid sort , " +
            "\ncase when t2.name in ('varchar','nvarchar','char','nchar','text','ntext') then 0" +
            "\nwhen t2.name in ('numeric','tinyint','smallint','int','real','money','float','decimal','smallmoney','bigint','uniqueidentifier','bit') then 1" +
            "\nwhen t2.name in ('datetime','smalldatetime','timestamp') then 2" +
            "\nwhen t2.name in ('image') then 3" +
            "\nelse 9 end value_type,t2.name type_show_name from syscolumns t1 INNER JOIN systypes t2 on t1.xtype = t2.xtype where t2.name <> 'sysname' and t2.name <> 'bool') t2" +
            "\non t1.table_id = t2.table_id and upper(columnname) not in ('CREATETIME','UPDATETIME','CREATE_DATE','UPDATE_DATE')" +
            "\nand upper(table_name) not in ('T_SYNCH_LOG','T_SYNCH_LOG_DETAIL','T_SYNCH_FILE_TABLE','T_PARAMETER') " +
            "\n) tsys right join" +
            "\n(select t2.field_id ,t1.table_name,field_name,t2.sortnum,value_type from t_table_name t1 inner join t_table_field t2 on t1.table_id = t2.table_id" +
            "\nand upper(substring(table_name,1,2)) = ('T_')) tuser" +
            "\non upper(tsys.table_name) = upper(tuser.table_name) and upper(tsys.columnname) = upper(tuser.field_name)" +
            "\nwhere tsys.value_type <> tuser.value_type or tsys.table_name is null" +
            "\nor tuser.field_name in ('CREATETIME','UPDATETIME','CREATE_DATE','UPDATE_DATE','THEORDER')" +
            "\nand upper(table_id) = '" + tableid.ToUpper() + "')";
            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除所有注册了的,却注册错误的列.
        /// </summary>
        /// <param name="tableid"></param>
        /// <returns></returns>
        public bool DeleteAllRegeditWrongColumns(out string err)
        {
            string sql = "delete dbo.T_TABLE_FIELD where field_id in ( select field_id from ( " +
            "\nselect table_name,columnname,sort,value_type , t2.type_show_name from" +
            "\n(select id table_id ,name table_name from sysobjects where name like 'T_%' and name not like 'TEMP%' and xtype = 'U') t1" +
            "\ninner join (select t1.id table_id, t1.name columnName,t1.colid sort , " +
            "\ncase when t2.name in ('varchar','nvarchar','char','nchar','text','ntext') then 0" +
            "\nwhen t2.name in ('numeric','tinyint','smallint','int','real','money','float','decimal','smallmoney','bigint','uniqueidentifier','bit') then 1" +
            "\nwhen t2.name in ('datetime','smalldatetime','timestamp') then 2" +
            "\nwhen t2.name in ('image') then 3" +
            "\nelse 9 end value_type,t2.name type_show_name from syscolumns t1 INNER JOIN systypes t2 on t1.xtype = t2.xtype where t2.name <> 'sysname' and t2.name <> 'bool') t2" +
            "\non t1.table_id = t2.table_id and upper(columnname) not in ('CREATOR','CREATETIME','UPDATETIME','CREATE_DATE','UPDATE_DATE')" +
            "\nand upper(table_name) not in ('T_SYNCH_LOG','T_SYNCH_LOG_DETAIL','T_SYNCH_FILE_TABLE','T_PARAMETER' ) " +
            "\n) tsys right join" +
            "\n(select t2.field_id ,t1.table_name,field_name,t2.sortnum,value_type from t_table_name t1 inner join t_table_field t2 on t1.table_id = t2.table_id" +
            "\nand upper(substring(table_name,1,2)) = ('T_')) tuser" +
            "\non upper(tsys.table_name) = upper(tuser.table_name) and upper(tsys.columnname) = upper(tuser.field_name)" +
            "\nwhere tsys.value_type <> tuser.value_type or tsys.table_name is null" +
            "\nor tuser.field_name in ('CREATOR','CREATETIME','UPDATETIME','CREATE_DATE','UPDATE_DATE','THEORDER'))";
            return dbAccess.ExecSql(sql, out err);
        }

        public bool InsertNotRegeditColumns(out string err)
        {
            string sql = "insert dbo.T_TABLE_FIELD(field_id,field_name,table_id,field_type,sortNum,value_type)" +
            "\nselect newid(),t.columnname,t.table_id,t.file_type,t.sort,t.value_type" +
            "\nfrom (select tsys.columnname,tsys.table_id," +
            "\ncase when (Select top 1 upper(col_name(t.id,colid))  '主键字段'" +
            "\n From  sysobjects t" +
            "\ninner join sysobjects   o on o.parent_obj = t.id and o.xtype = 'PK' " +
            "\nInner Join sysindexes   i on i.name=o.name " +
            "\nInner Join sysindexkeys k on k.indid=i.indid and k.id = t.id" +
            "\nwhere t.xtype = 'U' and upper(t.name ) = upper(tsys.table_name)) = upper(tsys.columnname) then 1 else 0 end file_type," +
            "\ntsys.sort,tsys.value_type  from" +
            "\n(select t1.table_name,columnname,sort,value_type , t2.type_show_name,tu.table_id from" +
            "\n(select id Sys_table_id ,name table_name from sysobjects where name like 'T_%' and name not like 'TEMP%' and xtype = 'U') t1" +
            "\ninner join (select t1.id Sys_table_id, t1.name columnName,t1.colid sort , " +
            "\ncase when t2.name in ('varchar','nvarchar','char','nchar','text','ntext') then 0" +
            "\nwhen t2.name in ('numeric','tinyint','smallint','int','real','money','float','decimal','smallmoney','bigint','uniqueidentifier','bit') then 1" +
            "\nwhen t2.name in ('datetime','smalldatetime','timestamp') then 2" +
            "\nwhen t2.name in ('image') then 3" +
            "\nelse 9 end value_type,t2.name type_show_name from syscolumns t1 INNER JOIN systypes t2 on t1.xtype = t2.xtype where t2.name <> 'sysname' and t2.name <> 'bool') t2" +
            "\non t1.Sys_table_id = t2.Sys_table_id and upper(columnname) not in ('CREATOR','CREATETIME','UPDATETIME','CREATE_DATE','UPDATE_DATE','THEORDER','UPDATE_TIME')" +
            "\nand upper(table_name) not in ('T_SYNCH_LOG','T_SYNCH_LOG_DETAIL','T_SYNCH_FILE_TABLE','T_PARAMETER','T_RIGHT','T_SHIP_HEAD_RIGHT','T_SHIP_USER_HEAD','T_SHIP_USER_RIGHT') " +
            "\ninner join t_table_name tu on upper(t1.table_name) = upper(tu.table_name)" +
            "\n) tsys ) t left join t_table_field tt" +
            "\non t.columnname = tt.field_name and t.table_id = tt.table_id" +
            "\nwhere tt.field_id is null";
            return dbAccess.ExecSql(sql, out err);
        }

        public bool InsertNotRegeditColumns(string tableName, out string err)
        {
            string sql = "insert dbo.T_TABLE_FIELD(field_id,field_name,table_id,field_type,sortNum,value_type)" +
            "\nselect newid(),t.columnname,t.table_id,t.file_type,t.sort,t.value_type" +
            "\nfrom (select tsys.columnname,tsys.table_id," +
            "\ncase when (Select top 1 upper(col_name(t.id,colid))  '主键字段'" +
            "\n From  sysobjects t" +
            "\ninner join sysobjects   o on o.parent_obj = t.id and o.xtype = 'PK' " +
            "\nInner Join sysindexes   i on i.name=o.name " +
            "\nInner Join sysindexkeys k on k.indid=i.indid and k.id = t.id" +
            "\nwhere t.xtype = 'U' and upper(t.name ) = upper(tsys.table_name)) = upper(tsys.columnname) then 1 else 0 end file_type," +
            "\ntsys.sort,tsys.value_type  from" +
            "\n(select t1.table_name,columnname,sort,value_type , t2.type_show_name,tu.table_id from" +
            "\n(select id Sys_table_id ,name table_name from sysobjects where upper(name) = '" + tableName.ToUpper() + "') t1" +
            "\ninner join (select t1.id Sys_table_id, t1.name columnName,t1.colid sort , " +
            "\ncase when t2.name in ('varchar','nvarchar','char','nchar','text','ntext') then 0" +
            "\nwhen t2.name in ('numeric','tinyint','smallint','int','real','money','float','decimal','smallmoney','bigint','uniqueidentifier','bit') then 1" +
            "\nwhen t2.name in ('datetime','smalldatetime','timestamp') then 2" +
            "\nwhen t2.name in ('image') then 3" +
            "\nelse 9 end value_type,t2.name type_show_name from syscolumns t1 INNER JOIN systypes t2 on t1.xtype = t2.xtype where t2.name <> 'sysname' and t2.name <> 'bool') t2" +
            "\non t1.Sys_table_id = t2.Sys_table_id and upper(columnname) not in ('CREATETIME','UPDATETIME','CREATE_DATE','UPDATE_DATE','THEORDER','UPDATE_TIME')" +
            "\nand upper(table_name) not in ('T_SYNCH_LOG','T_SYNCH_LOG_DETAIL','T_SYNCH_FILE_TABLE','T_PARAMETER','T_RIGHT','T_SHIP_HEAD_RIGHT','T_SHIP_USER_HEAD','T_SHIP_USER_RIGHT') " +
            "\ninner join t_table_name tu on upper(t1.table_name) = upper(tu.table_name)" +
            "\n) tsys ) t left join t_table_field tt" +
            "\non t.columnname = tt.field_name and t.table_id = tt.table_id" +
            "\nwhere tt.field_id is null";

            return dbAccess.ExecSql(sql, out err);
        }

        internal bool DeleteAllRegeditWrongTables(out string err)
        {
            List<string> sqls = new List<string>();
            sqls.Add("update T_TABLE_FIELD \rset fk_table_id = '',field_type = 0\r where fk_table_id in (select table_id from T_TABLE_NAME\rwhere table_name not in (select name from sysobjects where xtype = 'U') )");
            sqls.Add("delete T_TABLE_FIELD \rfrom T_TABLE_FIELD t1 inner join T_TABLE_NAME t2 on t1.table_id = t2.table_id\rwhere upper(table_name) not in (select name from sysobjects where xtype = 'U') ");
            sqls.Add("delete from T_TABLE_NAME\rwhere upper(table_name) not in (select name from sysobjects where xtype = 'U')");
            sqls.Add("update T_TABLE_FIELD\rset fk_table_id = '',field_type = 0\rwhere fk_table_id not in (select table_id from T_TABLE_NAME) and field_type = 2");
            return dbAccess.ExecSql(sqls, out err);
        }

        public bool RecreateTableTrigger(string tablename, out string err)
        {
            err = "";
            Dictionary<string, string> parms = new Dictionary<string, string>();
            string sql = "select  t2.field_name from dbo.T_TABLE_NAME t1 inner join dbo.T_TABLE_FIELD t2 "
            + "on t1.table_id = t2.table_id and field_type = 1 where upper(table_name) = '" + tablename.ToUpper() + "' ";
            string primarykeyid;
            if (!dbAccess.GetString(sql, out primarykeyid, out err))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(primarykeyid))
            {
                err = "无法获取表" + tablename + "配置的主键,请为其配置主键再重新操作!";
                return false;
            }
            parms.Add("@tableName", tablename);
            parms.Add("@primaryKeyFld", primarykeyid);
            return dbAccess.ExecProce("dbo.P_Create_Sync_Trigger", parms, out err);
        }
        #region 读取日志内容
        /// <summary>
        /// 读取日志内容.
        /// </summary>
        /// <param name="isLandVersion">是否为岸端true是岸端</param>
        /// <param name="dtSynch">同步日志列表</param>
        /// <param name="errMessage">错误消息</param>
        /// <returns>true成功反之亦然</returns>
        public bool GetSynchMainList(string synchDirect, string synchStatus, string startDate, string endDate, bool isLandVersion, out DataTable dtSynch, out string errMessage)
        {
            StringBuilder sb = new StringBuilder();
            if (synchDirect != "2")
                sb.AppendFormat(@" AND IS_SENDING_DATA='{0}'", synchDirect);
            if (synchStatus != "2")
                sb.AppendFormat(@" AND OPEARTION_SUCCESSFUL='{0}'", synchStatus);
            string strSql = string.Empty;
            if (isLandVersion)
            {
                strSql = string.Format(@"SELECT distinct LOG_ID,SENDING_TIME,SYNCH_FILE_NAME,
                                        CASE OPEARTION_SUCCESSFUL WHEN '1' THEN '成功' ELSE '失败' END AS OPEARTION_SUCCESSFUL,
                                        CASE IS_SENDING_DATA WHEN '1' THEN '由我发起' ELSE '发送给我' END AS IS_SENDING_DATA
                                        FROM dbo.T_SYNCH_LOG WHERE SENDING_TIME BETWEEN '{0}' AND '{1}' {2}", startDate, endDate, sb);
                return dbAccess.GetDataTable(strSql, out dtSynch, out errMessage);
            }
            else
            {
                strSql = string.Format(@"SELECT distinct LOG_ID,SENDING_TIME,SYNCH_FILE_NAME,
                                        CASE OPEARTION_SUCCESSFUL WHEN '1' THEN '成功' ELSE '失败' END AS OPEARTION_SUCCESSFUL,
                                        CASE IS_SENDING_DATA WHEN '1' THEN '发送给我' ELSE '由我发起' END AS IS_SENDING_DATA
                                        FROM dbo.T_SYNCH_LOG WHERE SENDING_TIME BETWEEN '{0}' AND '{1}' {2}", startDate, endDate, sb);
                return dbAccess.GetDataTable(strSql, out dtSynch, out errMessage);
            }
        }
        #endregion
        #region 读取日志明细
        /// <summary>
        /// 读取日志明细.
        /// </summary>
        /// <param name="synchFileName">日志名称</param>
        /// <param name="dtSynchDetail">明细列表</param>
        /// <param name="errMessage">错误消息</param>
        /// <returns>true成功反之亦然</returns>
        public bool GetSynchDetailList(string synchFileName, out DataTable dtSynchDetail, out string errMessage)
        {
            string strSql = string.Format(@"SELECT LOG_ID, SENDING_TIME, DEPARTMENT_ID,
                                            CASE LOG_TYPE WHEN '0' THEN '生成文件' WHEN '1' THEN '接收到文件' ELSE '自动或手动' END AS LOG_TYPE,
                                            CASE SYNCH_DATA_TYPE WHEN '0' THEN '一个表的一行或多行数据' WHEN '1' THEN '一个表的所有变化数据'
                                            WHEN '2' THEN '所有表的变化数据' WHEN '3' THEN '一个表的所有数据' WHEN '4' THEN '数据库的所有数据'
                                            WHEN '10' THEN '成功接收到数据' WHEN '11' THEN '失败接收到数据' WHEN '20' THEN '成功处理完毕的'
                                            WHEN '21' THEN '处理失败的' WHEN '51' THEN '收到的新文件' WHEN '52' THEN '收到备份文件'
                                            WHEN '53' THEN '收到处理过的文件' WHEN '54' THEN '收到错误的文件' WHEN '55' THEN '收到报修改的文件'
                                            ELSE 'KFC出错了' END AS SYNCH_DATA_TYPE, DATA_INFO, SYNCH_FILE_NAME, ROW_COUNT, FILE_SIZE, OPEARTION_SUCCESSFUL, MORE_DETAILS, SELF_FILE
                                            FROM dbo.T_SYNCH_LOG
                                            WHERE SYNCH_FILE_NAME='{0}'", synchFileName);
            return dbAccess.GetDataTable(strSql, out dtSynchDetail, out errMessage);
        }
        #endregion

        #region 读取闪呢
        /// <summary>
        ///
        /// </summary>
        /// <param name="logId">同步日志Id</param>
        /// <param name="dtSynchTable">影响数据列表</param>
        /// <param name="errMessage">错误消息</param>
        /// <returns>true成功反之亦然</returns>
        public bool GetSynchTableList(string logId, out DataTable dtSynchTable, out string errMessage)
        {
            string strSql = string.Format(@"SELECT DETAIL_ID, LOG_ID, TABLE_NAME, ROWS_COUNT
                                            FROM dbo.T_SYNCH_LOG_DETAIL
                                            WHERE LOG_ID='{0}'", logId);
            return dbAccess.GetDataTable(strSql, out dtSynchTable, out errMessage);
        }
        #endregion
        #region 读取杀呢

        /// <summary>
        /// 读取同步日志传输内容.
        /// </summary>
        /// <param name="logId">日志Id</param>
        /// <param name="recordContax">同步内容</param>
        /// <param name="errMessage">错误消息</param>
        /// <returns>true成功反之亦然</returns>
        public bool GetSynchRecordContax(string logId, out string recordContax, out string errMessage)
        {
            string strSql = string.Format(@"SELECT SYNCH_RECORD_CONTAX FROM dbo.T_SYNCH_LOG WHERE LOG_ID='{0}'", logId);

            return dbAccess.GetString(strSql, out recordContax, out errMessage);
        }
        #endregion

        /// <summary>
        /// 得到某个表中的所有数据.
        /// </summary>
        /// <param name="sTableName">表名</param>
        /// <returns>列表</returns>
        public DataTable GetAllFields(string sTableName)
        {
            if (string.IsNullOrEmpty(sTableName)) return null;
            string sSql = "";
            string sErrMessage = "";
            DataTable dtb;
            sSql += "select * ";
            sSql += "from " + sTableName.Replace("'", "''") + " ";

            dbAccess.GetDataTable(sSql, out dtb, out sErrMessage);
            return dtb;
        }
        public DataTable GetAllFieldByTableId(string sTableId)
        {
            string sSql = "";
            string sErrMessage = "";
            DataTable dtb;
            sSql += " select ";
            sSql += " a.field_id, ";
            sSql += " a.table_id, ";
            sSql += " a.field_name,";
            sSql += " a.field_type,";
            sSql += " case when a.field_type=0 then '普通列' when a.field_type=1 then '主键列' when a.field_type=2 then '外键列' end as field_typeName,";
            sSql += " a.fk_table_id,";
            sSql += " b.table_name,";
            sSql += " a.sortNum,";
            sSql += " a.value_Type,";
            sSql += " case when a.value_Type=0 then 'string' when a.value_Type=1 then 'number' when a.value_Type=2 then 'datetime' when a.value_Type=3 then 'blob' end as value_TypeName";
            sSql += " from t_table_field a ";
            sSql += " left join t_table_name b on a.fk_table_id=b.table_id ";
            sSql += " where a.table_id='" + sTableId + "' ";
            sSql += " order by a.sortNum ";
            dbAccess.GetDataTable(sSql, out dtb, out sErrMessage);
            return dtb;
        }
        public DataTable GetSynchronousTableIdAndCName()
        {
            string sSql = "";
            string sErrMessage = "";
            DataTable dtb;
            sSql += "select table_id,table_name,table_chinesename,table_status,case table_status when 0 then '不同步表' else '同步表' end as table_status_name,";
            sSql += "table_belong,case when table_belong=0 then '仅船舶端维护' when table_belong = 1 then '仅公司端维护' else '双方均可以维护' end as table_belongName,";
            sSql += "link_myself,show_column_name ,synchFilterOfLand,synchFilterOfShip ,synchShip";
            sSql += "\rfrom T_TABLE_NAME";
            sSql += "\rorder by table_name ";

            dbAccess.GetDataTable(sSql, out dtb, out sErrMessage);
            return dtb;
        }
        /// <summary>
        /// 得到数据库中所有实际表的表名.
        /// </summary>
        /// <returns>数据库中所有表名（T开头）</returns>
        public DataTable GetAllRealTableName()
        {
            string sSql = "";
            string sErrMessage = "";
            DataTable dtb;
            sSql += "SELECT t1.name From sysobjects t1 left join T_TABLE_NAME t2 on t1.name = t2.table_name " +
            "\rWHERE xtype = 'u' and left(name,2)='T_' order by case when t2.table_id is null then 0 else 1 end,t1.name ";

            dbAccess.GetDataTable(sSql, out dtb, out sErrMessage);
            return dtb;
        }
    }
}
