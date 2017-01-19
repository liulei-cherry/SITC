using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using CommonOperation.Interfaces;
using CommonOperation.Functions;

namespace CommonOperation.Functions
{
    public class OurTableServices
    {
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private static OurTableServices instance;
        private static Dictionary<string, OurTable> dicLoadedTables = new Dictionary<string, OurTable>();//根据tablename作为字典数据的索引列.
        private static Dictionary<string, string> dicTableIdAndName = new Dictionary<string, string>(); //根据tableId找到tablename;
        private static Dictionary<string, string> dicFKAnName = new Dictionary<string, string>();  //根据外键名找到主tablename
        private static Dictionary<string, string> dicFkAndForeignTableName = new Dictionary<string, string>();  //根据外健找从表tablename 
        DataTable toReOurTablefield = null;
        public OurTableServices()
        {

        }
        /// <summary>
        /// 实例化.
        /// </summary>
        public static OurTableServices GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OurTableServices();
                }
                return instance;
            }
        }
        /// <summary>
        /// 得到所有元素的list
        /// </summary>
        public List<OurTable> AllTables
        {
            get
            {
                List<OurTable> reAllTables = new List<OurTable>();
                foreach (string temps in dicLoadedTables.Keys)
                {
                    reAllTables.Add(dicLoadedTables[temps]);
                }
                return reAllTables;
            }
        }
        public OurTable LoadATableById(string id)
        {
            if (dicTableIdAndName.ContainsKey(id.ToUpper()) && dicLoadedTables.ContainsKey(dicTableIdAndName[id.ToUpper()]))
            {
                return dicLoadedTables[dicTableIdAndName[id.ToUpper()]];
            }
            string sql = "select ";
            sql += "table_id,table_name,table_chinesename,table_status,table_belong,link_myself,show_Column_Name,synchFilterOfLand,synchFilterOfShip,synchShip,synchronous_order ";
            sql += "from t_table_name where upper(table_id) = upper('" + id + "')";
            return loadATable(sql);
        }
        public OurTable LoadATableByName(string tableName)
        {
            if (string.IsNullOrEmpty(tableName)) tableName = "";

            if (dicLoadedTables.ContainsKey(tableName.ToUpper()))
            {
                return dicLoadedTables[tableName.ToUpper()];
            }
            string sql = "select ";
            sql += "table_id,table_name,table_chinesename,table_status,table_belong,link_myself,show_Column_Name,synchFilterOfLand,synchFilterOfShip,synchShip,synchronous_order ";
            sql += "from t_table_name where upper(table_name) = upper('" + tableName + "')";
            return loadATable(sql);
        }

        public string LoadTableNameByFkName(string FkColumnName)
        {
            if (string.IsNullOrEmpty(FkColumnName)) return "";
            if (dicFKAnName.ContainsKey(FkColumnName.ToUpper()))
            {
                return dicFKAnName[FkColumnName.ToUpper()];
            }
            else
            {
                return "";
            }
        }

        public string LoadForeignTableNameByFkName(string FkColumnName)
        {
            if (string.IsNullOrEmpty(FkColumnName)) return "";
            if (dicFkAndForeignTableName.ContainsKey(FkColumnName.ToUpper()))
            {
                return dicFkAndForeignTableName[FkColumnName.ToUpper()];
            }
            else
            {
                return "";
            }
        }

        private OurTable loadATable(string sql)
        {
            string sqlErr;
            OurTable toReOurTable;
            DataTable toReOurTableTable;
            if (dbAccess.GetDataTable(sql, out toReOurTableTable, out sqlErr) && toReOurTableTable.Rows.Count == 1)
            {
                toReOurTable = loadATableByDataRow(toReOurTableTable.Rows[0]);
            }
            else
            {
                toReOurTable = new OurTable(false, "无法加载T_TABLENAME的数据，其错误信息可能为：" + sqlErr);
            }
            return toReOurTable;
        }

        private OurTable loadATableByDataRow(DataRow dr)
        {
            OurTable toReOurTable;
            int synchronous_order;
            int tableStatus;
            if (!int.TryParse(dr["table_status"].ToString(), out tableStatus))
            {
                return new OurTable(false, "无法加载T_TABLENAME的数据，其错误信息可能为：table_status列[" + dr["table_status"].ToString() + "]并非int型值");
            }
            int tableBelong;
            if (!int.TryParse(dr["table_belong"].ToString(), out tableBelong))
            {
                return new OurTable(false, "无法加载T_TABLENAME的数据，其错误信息可能为：table_belong列[" + dr["table_belong"].ToString() + "]并非int型值");
            }
            if (!int.TryParse(dr["synchronous_order"].ToString(), out synchronous_order))
            {
                synchronous_order = 0;
            }
            if (dicLoadedTables.ContainsKey(dr["table_name"].ToString().ToUpper()))
                return dicLoadedTables[dr["table_name"].ToString().ToUpper()];
            if (toReOurTablefield == null)
            {
                string field_sql = @"select field_id,field_name,field_type,table_id,fk_table_id,sortnum ,value_type 
                                     from t_table_field ORDER BY sortnum";
                string sqlErr;
                dbAccess.GetDataTable(field_sql, out toReOurTablefield, out sqlErr);
            }
            toReOurTable = new OurTable(toReOurTablefield, dr["table_id"].ToString(), dr["table_name"].ToString(), dr["table_chinesename"].ToString(),
                tableStatus, tableBelong, dr["show_Column_Name"].ToString(), dr["synchFilterOfLand"].ToString(),
                dr["synchFilterOfShip"].ToString(), dr["synchShip"].ToString(), synchronous_order);
            dicLoadedTables.Add(dr["table_name"].ToString().ToUpper(), toReOurTable);
            return toReOurTable;
        }

        public void RetrieveTable()
        {
            //Console.Write(DateTime.Now);
            dicLoadedTables.Clear();
            loadTableIdAndName();
            if (!DbHaveThisObject("TEMP_SYNCHRONIZATION")) //2011 11 24 黄家龙修改 DBInsideOperation.Instance.
            {
                CreateTheTempTable();//2011 11 24 黄家龙修改  DBInsideOperation.Instance.
            }
            //Console.Write(DateTime.Now);
        }

        private void loadTableIdAndName()
        {
            dicTableIdAndName.Clear();
            dicFKAnName.Clear();
            string sqlErr;
            string sql = @"select table_id,table_name,table_chinesename,table_status,table_belong,
                    link_myself,show_Column_Name,synchFilterOfLand,synchFilterOfShip,synchShip,synchronous_order
                    from t_table_name ";
            DataTable tempDataTable;
            if (dbAccess.GetDataTable(sql, out tempDataTable, out sqlErr))
            {
                foreach (DataRow tempDataRow in tempDataTable.Rows)
                {
                    dicTableIdAndName.Add(tempDataRow[0].ToString().ToUpper(), tempDataRow[1].ToString().ToUpper());
                    if (!dicLoadedTables.ContainsKey(tempDataRow[1].ToString().ToUpper()))
                    {
                        loadATableByDataRow(tempDataRow);
                    }
                }

                ResetAllTable();
            }

            if (getTableIdByFkColumnName(out tempDataTable, out sqlErr))
            {
                foreach (DataRow tempDataRow in tempDataTable.Rows)
                {
                    dicFKAnName.Add(tempDataRow["ConstName"].ToString().ToUpper(), tempDataRow["PKTABLE_NAME"].ToString().ToUpper());
                    dicFkAndForeignTableName.Add(tempDataRow["ConstName"].ToString().ToUpper(), tempDataRow["FKTABLE_NAME"].ToString().ToUpper());
                }
            }
        }

        /// <summary>
        /// 返回形式"{ID,VALUE1,VALUE2....,MORE}",全部大写,用逗号分隔,两边是大括号.
        /// </summary>
        /// <param name="theTable">表</param>
        /// <param name="theTableRows">返回值</param>
        /// <returns>是否成功</returns>
        public bool GetTableRows(OurTable theTable, out string theTableRows, out string err)
        {
            err = "";
            theTableRows = "{";
            for (int i = 0; i < theTable.ThisFieldList.Count; i++)
            {
                theTableRows = theTableRows + theTable.ThisFieldList[i].ThisFieldName.ToUpper() + ",";
            }
            theTableRows = theTableRows.Substring(0, theTableRows.Length - 1) + "}"; 
            return true;
        }
        /// <summary>
        /// 分割表名,如果分割不成功,可以判断组成时错误.
        /// 分割成功后,可以作为导入形成语法的依据.
        /// </summary>
        /// <param name="theTableRows"></param>
        /// <param name="listRows"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool GetListStringOfTableString(string theTableRows, out List<string> listRows, out string err)
        {
            err = "";
            listRows = new List<string>();
            if (theTableRows.Length <= 2)
            {
                err = "传入的tableRows不可能是准确的,它的长度太短";
                return false;
            }
            string tempstring = theTableRows.Substring(1, theTableRows.Length - 2);
            string[] listRowsTemp = tempstring.Split(',');

            foreach (string temp in listRowsTemp)
            {
                //正则表达式判断 判断分开的字符串是否都是字母打头,只有字母数字和下划线的字符串.
                if (!Regex.IsMatch(temp, "^[a-zA-Z]\\w+$"))
                {
                    err = temp + "片段不符合表字段的名称要求,分割或合并时有误";
                    return false;
                }
                listRows.Add(temp);
            }

            return true;
        }
        #region 新加 2011 1124 黄家龙  从synchDll移动 commonItem OurField OurTable OurTableServices  四个文件
        /// <summary>
        /// 用来判断数据库是否有这个表,这个函数仅判断是否有临时表,实际其他业务表等都在T_tablename中维护了,可以用tableservices去判断.
        /// </summary>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public bool DbHaveThisObject(string tablename)
        {
            string createSql;
            createSql = "select count(1) from sysobjects where upper(name) = upper('" + tablename + "') and xtype = 'U'";
            string err;
            DataTable dtTemp;

            if (dbAccess.GetDataTable(createSql, out dtTemp, out err) && dtTemp.Rows.Count == 1)
            {
                if (dtTemp.Rows[0][0].ToString() == "1")
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 当发现本地没有某船舶的临时表时,自动生成一个临时表.
        /// 临时表的字段与T_TEMP_SYNCHRONIZATION相同.
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public bool CreateTheTempTable()
        {
            List<string> createSql = new List<string>();
            string err;
            createSql.Add("create table [dbo].[TEMP_SYNCHRONIZATION]("
                                + "\n [TEMP_ID]  [char](36) NOT NULL,"
                                + "\n [TABLE_ID] [char](36) NOT NULL,"
                                + "\n [VALUE_ID] [char](36) NOT NULL,"
                                + "\n [CHANGE_TIME] [datetime] NOT NULL CONSTRAINT [DF_TEMP_SYNCHRONIZATION_TIME]  DEFAULT (getdate()),"
                                + "\n [NOWSTATE] [numeric](1, 0) NULL CONSTRAINT [DF_TEMP_SYNCHRONIZATION_STATE]  DEFAULT ((0)),"
                                + "\n [SYNCHNUMBER] [varchar](30) NULL,"
                                + "\n [SHIPID] [char](36) NULL,"
                                + "\n CONSTRAINT [PK_TEMP_SYNCHRONIZATION] PRIMARY KEY CLUSTERED ([temp_id] ASC))");

            return dbAccess.ExecSql(createSql, out err);
        }
        #endregion

        public void ResetAllTable()
        {
            //全部排序归零,避免永远递增,超出界限.
            foreach (string temps in dicLoadedTables.Keys)
            {
                dicLoadedTables[temps].SynchronousOrder = 0;
            }
            //依次计算,调用递归方法addOrderToAllTableAboveThis
            foreach (string temps in dicLoadedTables.Keys)
            {
                addOrderToAllTableAboveThis(dicLoadedTables[temps], "");
            }
            string alltableorder = "";
            foreach (string temps in dicLoadedTables.Keys)
            {
                alltableorder += dicLoadedTables[temps].TableName + ":" + dicLoadedTables[temps].SynchronousOrder.ToString() + "\r";
            }
            List<string> sqllist = new List<string>();
            foreach (OurTable oneTable in AllTables)
            {
                sqllist.Add(@"update t_table_name set synchronous_order =" + oneTable.SynchronousOrder.ToString()
                           + " where table_id ='" + oneTable.TableId + "'");
            }
            string err;
            dbAccess.ExecSql(sqllist, out err);
        }
        /// <summary>
        /// 自动循环所有配置表,将其顺序判断清晰.
        /// </summary>
        /// <param name="ourTable"></param>
        /// <param name="idsIn">所有id连成的串,如果添加过的,不需要在加一</param>
        private void addOrderToAllTableAboveThis(OurTable ourTable, string idsIn)
        {
            //定义这个string,为了不跟传入参数混合成一个,影响递归!
            string ids = idsIn;
            if (ids.IndexOf(ourTable.TableId.ToUpper()) < 0)
                ids += ourTable.TableId.ToUpper() + "|";
            else return;
            //查找所有它用到的表,用到的优先级均加1
            foreach (OurField temps in ourTable.ThisFkFieldList)
            {
                string tempId = temps.ThisFkTableId.ToUpper();
                //避免重复添加.
                if (ids.IndexOf(tempId) >= 0) continue;
                //
                if (dicTableIdAndName.ContainsKey(tempId))
                {
                    dicLoadedTables[dicTableIdAndName[tempId]].SynchronousOrder++;
                    addOrderToAllTableAboveThis(dicLoadedTables[dicTableIdAndName[tempId]], ids);
                }
            }
        }

        /// <summary>
        /// 根据外键找找主表名称.
        /// </summary>
        /// <param name="FkColumnName">外键名称如fk_</param>
        /// <returns></returns>
        public bool getTableIdByFkColumnName(out DataTable tempDataTable, out string sqlErr)
        {
            sqlErr = "";
            string sql = " select t.ConstName, t.PKTABLE_NAME, t.FKTABLE_NAME from "
            + " \n("
            + " \n select   object_name(constid)   as   ConstName"
            + " \n ,object_name(rkeyid)   as   PKTABLE_NAME"
            + " \n ,col_name(rkeyid,rkey)     as   PKCOLUMN_NAME "
            + " \n ,object_name(fkeyid)   as   FKTABLE_NAME"
            + " \n ,COL_NAME(fkeyid,fkey)   as   FKCOLUMN_NAME "
            + " \n from   sysforeignkeys "
            + " \n ) t ";
            return dbAccess.GetDataTable(sql, out tempDataTable, out sqlErr);
        }
    }
}
