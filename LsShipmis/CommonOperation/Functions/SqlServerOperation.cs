using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using CommonOperation.BaseClass;
using System.Data;

namespace CommonOperation.Functions
{
    internal class SqlServerOperation : IDBOperation
    {
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        public string DbToDate(DateTime dtToBeChangedDate)
        {
            if (dtToBeChangedDate < ConstParameter.MinDateTime || dtToBeChangedDate > ConstParameter.MaxDateTime)
            {
                return " null ";
            }
            return " cast('" + dtToBeChangedDate.ToString("yyyy-MM-dd HH:mm:ss") + "' as datetime) ";
        }
        public string DbToDate(string dtToBeChangedDate)
        {

            if (dtToBeChangedDate.Trim().Length == 0)
            {
                //在SQL Server中会把空字符串的日期值显示成1900-1-1，所以必须把空字符串转化为Null值.
                return "null";
            }
            else
            {
                return " cast('" + dtToBeChangedDate + "' as datetime) ";
            }
        }

        public bool DbHaveThisData(string toFindData, string tableName, string IdName, string findColumnName, string exceptId)
        {            
            if ( string.IsNullOrEmpty(tableName) ||
                string.IsNullOrEmpty(IdName) || string.IsNullOrEmpty(findColumnName)) throw new Exception("执行DbHaveThisData时,传入参数无效");
            if (string.IsNullOrEmpty(toFindData)) return false;
            string sql = "select count(1) from " + tableName
                + "\rwhere " + (string.IsNullOrEmpty(exceptId) ? "" : IdName + " <> '" + exceptId + "' and ")
                +  findColumnName + " ='" + toFindData + "'";
            if (dbAccess.GetString(sql) != "0")
                return true;
            else
                return false;

        }
        public bool ThisShipHaveThisData(string toFindData, string shipid, string tableName, string IdName, string findColumnName, string exceptId)
        {
            if (string.IsNullOrEmpty(toFindData) || string.IsNullOrEmpty(tableName) ||
               string.IsNullOrEmpty(IdName) || string.IsNullOrEmpty(findColumnName)) return false; //throw new Exception("执行DbHaveThisData时,传入参数无效");
            string sql = "select count(1) from " + tableName
                + "\rwhere " + (string.IsNullOrEmpty(exceptId) ? "" : IdName + " <> '" + exceptId + "'  and ")
                + findColumnName + " ='" + toFindData + "' and ship_id = '" + shipid + "'";
            if (dbAccess.GetString(sql) != "0")
                return true;
            else
                return false;
        }
        /// </summary>
        /// <param name="dtb">包含数据的DataTable对象</param>
        /// <param name="sTableName">要保存到数据的表名</param>
        /// <param name="mark">标记：0表示是添加BindingSource中的数据；1表示是要修改DataTable中的数据</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public bool SaveFormData(DataTable dtb, string sTableName, int mark, out string err)
        {
            if (dtb == null)
            {
                err = "未发现要保存的数据";
                return false;
            }
            //得到dtb数据的一份克隆（注意不能是dtb，因为它是引用类型，数据一改变影响其它组件的显示）.
            DataTable dtbForSave = dtb.Copy();

            //把dtbForSave中所有新添加、删除及修改过的数据组装成相应的Insert、Delete和Update语句放到一个泛型集合中去.
            List<string> lstSqlOpt = new List<string>();
            if (mark == 0)
            {
                lstSqlOpt = getOptSqlFromTable(dtbForSave, sTableName);
            }
            else
            {
                lstSqlOpt = getInsSqlFromTable(dtbForSave, sTableName);
            }

            //执行数据更新.
            if (dbAccess.ExecSql(lstSqlOpt, out err))
            {
                dtb.AcceptChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// 取得SQL语句. 2014.2.18 刘子建添加
        /// </summary>
        /// <param name="dtb">包含数据的DataTable对象</param>
        /// <param name="sTableName">要保存到数据的表名</param>
        /// <param name="mark">标记：0表示是添加BindingSource中的数据；1表示是要修改DataTable中的数据</param>
        /// <returns></returns>
        public List<string> SaveFormData(DataTable dtb, string sTableName, int mark)
        {
            if (dtb == null)
            {
                return null;
            }

            //得到dtb数据的一份克隆（注意不能是dtb，因为它是引用类型，数据一改变影响其它组件的显示）.
            DataTable dtbForSave = dtb.Copy();

            //把dtbForSave中所有新添加、删除及修改过的数据组装成相应的Insert、Delete和Update语句放到一个泛型集合中去.
            List<string> lstSqlOpt = new List<string>();
            if (mark == 0)
            {
                lstSqlOpt = getOptSqlFromTable(dtbForSave, sTableName);
            }
            else
            {
                lstSqlOpt = getInsSqlFromTable(dtbForSave, sTableName);
            }
            return lstSqlOpt;
        }

        /// <summary>
        /// 把DataTable中所有新增加的、删除的和更新的数据取出来分别组成相应的Insert、Delete和Update的.
        /// 操作语句放到一个泛型集合中去。由于DataTable中包含的数据可能是包含关联表的连接数据，因此无法使用.
        /// Adapter的Update语句进行成批更新。这里只能把所有新变化的数据取出来组成相关的操作语句来执行。.
        /// 需要注意的是：dtb的源Select语句必须写上主键列并且要把主键写在第1列。.
        /// 这个函数与getOptInsFromTable函数的不同点是，它是更新BindingSource数据源中的数据，.
        /// 而前者是更新DataTable中的数据。.
        /// 需要注意一点：如果是在程序中直接调用本函数而得到对dtb表的编辑语句，那么在调用时不能用原DataTable，.
        /// 必须使用如DataTable dtbForSave = dtb.Copy()的语句生成一个原DataTable的复本，因为本函数中要对传入.
        /// 的DataTable进行加工（删除列），从而使显示时出现问题。.
        /// </summary>
        /// <param name="dtb">包含数据的DataTable</param>
        /// <param name="tableName">要更新数据的表名</param>
        /// <returns>返回一个包含增、删、改的操作语句的泛型集合</returns>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        private List<string> getOptSqlFromTable(DataTable dtb, string tableName)
        {
            string err;
            List<string> lstSqlOpt = new List<string>();//定义一个用于包含增、删、改的操作语句的泛型集合.

            //得到一个泛型的哈希表集合，里边存放着表tableName中每个字段的属性信息（如长度，是否为空等），哈希表的Key值用字段名表示.
            //这个主要用于下边判断列是不是布尔型时使用（注意，有时抛出异常KeyNotFoundException并说给定的关键字不在字典中，这种.
            //错误情况是因为字段的大小写不一致引起的，另外，对于Oracle数据库中的表如果存在BLOB字段，也会抛出此异常）.
            Dictionary<string, FldProperty> dictDtb = dbAccess.GetTbColumnSize(tableName, out err);

            //在数据库中取实际表tableName的所有列名放到泛型集合lstColName中.
            List<string> lstColName = dbAccess.GetTablesColNames(tableName, out err);

            //取出dtb中所有不存在于集合lstColName（也即是实际表tableName）中的列名放到泛型集合lstColNameNo中.
            List<string> lstColNameNo = new List<string>();
            foreach (DataColumn dataColumn in dtb.Columns)
            {
                if (dataColumn.DataType.Name.Equals("Byte[]"))
                {
                    lstColNameNo.Add(dataColumn.ColumnName);
                    continue;
                }

                if (lstColName.Contains(dataColumn.ColumnName.ToUpper()) == false)
                {
                    lstColNameNo.Add(dataColumn.ColumnName);
                }
            }

            //在dtb中删除所有不属于实际表tableName中的列名以便为数据插入准备好条件，.
            //因为必须保证dtb与实际表tableName的结构完毕一致才能使数据插入的成功。.
            foreach (string sColNameNo in lstColNameNo)
            {
                dtb.Columns.Remove(dtb.Columns[sColNameNo]);
            }

            DataView dv = new DataView(dtb);//取得当前表dtb的视图对象dv

            //***（1）加工插入语句***************************************************************************/
            //取出所有新添加的数据.
            dv.RowStateFilter = DataViewRowState.Added;
            DataTable dtbAdded = dv.ToTable();

            //建立Insert Into语句.
            string sInsertSql = "";
            string sInsertFld = "insert into " + tableName + " (";
            string sInsertVal = " values (";
            foreach (DataColumn dataColumn in dtbAdded.Columns)
            {
                sInsertFld += dataColumn.ColumnName + ",";
            }
            sInsertFld = sInsertFld.Substring(0, sInsertFld.Length - 1) + ")";//去掉最后的逗号.

            //把dtbAdded中所有的数据取出来组成Insert Into语句.
            foreach (DataRow dataRow in dtbAdded.Rows)
            {
                foreach (DataColumn dataColumn in dtbAdded.Columns)
                {
                    //字符型数据.
                    if (dataColumn.DataType.Name.Equals("String"))
                    {
                        if (dataRow[dataColumn].ToString().Trim().Length == 0)
                        {
                            sInsertVal += "null,";//如果字符串为空字符，那么在数据库中插入Null值（处理SQL Server外键插入空字符串时出错问题）.
                        }
                        else
                        {
                            sInsertVal += "'" + ReplaceSqlKeyStr(dataRow[dataColumn].ToString()) + "',";
                        }
                    }
                    //数值型数据.
                    else if (dataColumn.DataType.Name.Equals("Decimal"))
                    {
                        if (dataRow[dataColumn].ToString().Trim().Length == 0)
                        {
                            //得到包含当前字段dataColumn的属性信息的容器类fldProperty
                            FldProperty fldProperty = dictDtb[dataColumn.ColumnName.ToUpper()];
                            //如果当前字段的精度为1,小数位数为0,则应该是布尔类型数据,这时设置值为默认的0
                            if (fldProperty.NumericPrecision == 1 && fldProperty.NumericScale == 0)
                            {
                                sInsertVal += "0,";
                            }
                            else
                            {
                                sInsertVal += "null,";//如果没有任何值，则赋值为null
                            }
                        }
                        else
                        {
                            sInsertVal += dataRow[dataColumn].ToString() + ",";
                        }
                    }
                    //日期型数据.
                    else if (dataColumn.DataType.Name.Equals("DateTime"))
                    {
                        if (dataRow[dataColumn].ToString().Trim().Length == 0 || dataRow[dataColumn].ToString().Trim() == "0001-1-1 0:00:00")
                        {
                            sInsertVal += "null,";//如果没有任何值，则赋值为null
                        }
                        else
                        {
                            sInsertVal += DbToDate(dataRow[dataColumn].ToString()) + ",";
                        }
                    }
                    //其它类型数据.
                    else
                    {
                        sInsertVal += "'" + ReplaceSqlKeyStr(dataRow[dataColumn].ToString()) + "',";
                    }
                }
                sInsertVal = sInsertVal.Substring(0, sInsertVal.Length - 1) + ")";//去掉最后的逗号.
                sInsertSql = sInsertFld + sInsertVal;

                lstSqlOpt.Add(sInsertSql);//把组装好的Insert操作语句放到泛型集合中去.
                sInsertVal = " values ("; //初始化sInsertVal
            }
            /***插入语句加工结束***************************************************************************/
            //***（2）加工删除语句***************************************************************************/
            //取出所有删除的数据.
            dv.RowStateFilter = DataViewRowState.Deleted;
            DataTable dtbDeleted = dv.ToTable();

            //建立Delete语句.
            string sDeleteSql = "";

            foreach (DataRow dataRow in dtbDeleted.Rows)
            {
                sDeleteSql = "delete from " + tableName + " where " + dtbDeleted.Columns[0].ColumnName + " = ";
                sDeleteSql += "'" + dataRow[0].ToString() + "'";

                lstSqlOpt.Add(sDeleteSql);//把组装好的Delete操作语句放到泛型集合中去.
            }

            /***删除语句加工结束***************************************************************************/
            //***（3）加工修改语句***************************************************************************/
            //取出所有修改过的数据.
            dv.RowStateFilter = DataViewRowState.ModifiedCurrent;
            DataTable dtbUpdated = dv.ToTable();
            List<string> lstUpdatedSql = getLstUpdateSql(dtbUpdated, tableName, lstColName);

            //取出所有修改过的数据的修改前的值.
            dv.RowStateFilter = DataViewRowState.ModifiedOriginal;
            DataTable dtbOriginal = dv.ToTable();
            List<string> lstOriginalSql = getLstUpdateSql(dtbOriginal, tableName, lstColName);

            //以修改前的值为参照，判断lstUpdatedSql中包含的update语句是否真修改过数据，如果确未修改过，则删除该语句。.
            //（bindingSource存在一个缺陷，也就是说当焦点放在某一个记录上时，并未修改该记录任何值，但却仍然被打上了.
            //修改标记，这样在生成修改语句时仍能生成update语句，本代码块是为了解决这个问题）.
            foreach (string sSql in lstOriginalSql)
            {
                if (lstUpdatedSql.Contains(sSql))
                {
                    lstUpdatedSql.Remove(sSql);
                }
            }

            //把可能包含的修改语句添加到集合lstSqlOpt中去.
            lstSqlOpt.AddRange(lstUpdatedSql);

            /***修改语句加工结束***************************************************************************/
            return lstSqlOpt;
        }

        /// <summary>
        /// 十二、把DataTable中所有的数据取出来组成相应的Insert的操作语句放到一个泛型集合中去。.
        /// 需要注意的是：dtb的源Select语句必须写上主键列并且要把主键写在第1列。这个函数与getOptSqlFromTable函数.
        /// 的不同点是，它是更新DataTable中的数据，而前者是更新BindingSource数据源中的数据。.
        /// </summary>
        /// <param name="dtb">包含数据的DataTable</param>
        /// <param name="tableName">要更新数据的表名</param>
        /// <returns>返回一个包含添加的操作语句的泛型集合</returns>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        private List<string> getInsSqlFromTable(DataTable dtb, string tableName)
        {
            string err;
            List<string> lstSqlOpt = new List<string>();//定义一个用于包含增、删、改的操作语句的泛型集合.

            //得到一个泛型的哈希表集合，里边存放着表tableName中每个字段的属性信息（如长度，是否为空等），哈希表的Key值用字段名表示.
            //这个主要用于下边判断列是不是布尔型时使用.
            Dictionary<string, FldProperty> dictDtb = dbAccess.GetTbColumnSize(tableName, out err);

            //在数据库中取实际表tableName的所有列名放到泛型集合lstColName中.
            List<string> lstColName = dbAccess.GetTablesColNames(tableName, out err);

            //取出dtb中所有不存在于集合lstColName（也即是实际表tableName）中的列名放到泛型集合lstColNameNo中.
            List<string> lstColNameNo = new List<string>();
            foreach (DataColumn dataColumn in dtb.Columns)
            {
                if (lstColName.Contains(dataColumn.ColumnName.ToUpper()) == false)
                {
                    lstColNameNo.Add(dataColumn.ColumnName);
                }
            }

            //在dtb中删除所有不属于实际表tableName中的列名以便为数据插入准备好条件，.
            //因为必须保证dtb与实际表tableName的结构完毕一致才能使数据插入的成功。.
            foreach (string sColNameNo in lstColNameNo)
            {
                dtb.Columns.Remove(dtb.Columns[sColNameNo]);
            }

            //***（1）加工插入语句***************************************************************************/
            //取出所有新添加的数据.
            DataTable dtbAdded = dtb;

            //建立Insert Into语句.
            string sInsertSql = "";
            string sInsertFld = "insert into " + tableName + " (";
            string sInsertVal = " values (";
            foreach (DataColumn dataColumn in dtbAdded.Columns)
            {
                sInsertFld += dataColumn.ColumnName + ",";
            }
            sInsertFld = sInsertFld.Substring(0, sInsertFld.Length - 1) + ")";//去掉最后的逗号.

            //把dtbAdded中所有的数据取出来组成Insert Into语句.
            foreach (DataRow dataRow in dtbAdded.Rows)
            {
                foreach (DataColumn dataColumn in dtbAdded.Columns)
                {
                    //字符型数据.
                    if (dataColumn.DataType.Name.Equals("String"))
                    {
                        if (dataRow[dataColumn].ToString().Trim().Length == 0)
                        {
                            sInsertVal += "null,";//如果字符串为空字符，那么在数据库中插入Null值（处理SQL Server外键插入空字符串时出错问题）.
                        }
                        else
                        {
                            sInsertVal += "'" + ReplaceSqlKeyStr(dataRow[dataColumn].ToString()) + "',";
                        }
                    }
                    //数值型数据.
                    else if (dataColumn.DataType.Name.Equals("Decimal"))
                    {
                        if (dataRow[dataColumn].ToString().Trim().Length == 0)
                        {
                            //得到包含当前字段dataColumn的属性信息的容器类fldProperty
                            FldProperty fldProperty = dictDtb[dataColumn.ColumnName.ToUpper()];
                            //如果当前字段的精度为1,小数位数为0,则应该是布尔类型数据,这时设置值为默认的0
                            if (fldProperty.NumericPrecision == 1 && fldProperty.NumericScale == 0)
                            {
                                sInsertVal += "0,";
                            }
                            else
                            {
                                sInsertVal += "null,";//如果没有任何值，则赋值为null
                            }
                        }
                        else
                        {
                            sInsertVal += dataRow[dataColumn].ToString() + ",";
                        }
                    }
                    //日期型数据.
                    else if (dataColumn.DataType.Name.Equals("DateTime"))
                    {
                        if (dataRow[dataColumn].ToString().Trim().Length == 0 || dataRow[dataColumn].ToString().Trim() == "0001-1-1 0:00:00")
                        {
                            sInsertVal += "null,";//如果没有任何值，则赋值为null
                        }
                        else
                        {
                            sInsertVal += DbToDate(dataRow[dataColumn].ToString()) + ",";
                        }
                    }
                    //其它类型数据.
                    else
                    {
                        sInsertVal += "'" + ReplaceSqlKeyStr(dataRow[dataColumn].ToString()) + "',";
                    }
                }
                sInsertVal = sInsertVal.Substring(0, sInsertVal.Length - 1) + ")";//去掉最后的逗号.
                sInsertSql = sInsertFld + sInsertVal;

                lstSqlOpt.Add(sInsertSql);//把组装好的Insert操作语句放到泛型集合中去.
                sInsertVal = " values ("; //初始化sInsertVal
            }
            /***插入语句加工结束***************************************************************************/
            return lstSqlOpt;
        }

        /// <summary>
        /// 将dtb中的每条记录生成对应的update语句.
        /// </summary>
        /// <param name="dtb">包含数据的DataTable对象</param>
        /// <param name="tableName">要操作的表名</param>
        /// <param name="lstColName">表中的各个列名</param>
        /// <returns>返回一个包含update语句的List泛型集合</returns>
        private List<string> getLstUpdateSql(DataTable dtb, string tableName, List<string> lstColName)
        {
            List<string> lstUpdateSql = new List<string>();

            //建立Update语句.
            string sUpdateSql = "update " + tableName + " set ";

            //把dtbUpdated中所有的数据取出来组成Update语句.
            foreach (DataRow dataRow in dtb.Rows)
            {
                for (int iCount = 1; iCount < dtb.Columns.Count; iCount++)
                {
                    DataColumn dataColumn = dtb.Columns[iCount];//取得当前列.
                    //字符型数据.
                    if (dataColumn.DataType.Name.Equals("String"))
                    {
                        if (dataRow[dataColumn].ToString().Trim().Length == 0)
                        {
                            sUpdateSql += dataColumn.ColumnName + " = null,";//如果字符串为空字符，那么在数据库中插入Null值（处理SQL Server外键插入空字符串时出错问题）.
                        }
                        else
                        {
                            sUpdateSql += dataColumn.ColumnName + " = '" + ReplaceSqlKeyStr(dataRow[dataColumn].ToString()) + "',";
                        }
                    }
                    //数值型数据.
                    else if (dataColumn.DataType.Name.Equals("Decimal"))
                    {
                        if (dataRow[dataColumn].ToString().Trim().Length == 0)
                        {
                            sUpdateSql += dataColumn.ColumnName + " = null,";//如果没有赋值，则为null
                        }
                        else
                        {
                            sUpdateSql += dataColumn.ColumnName + " = " + dataRow[dataColumn].ToString() + ",";
                        }
                    }
                    //日期型数据.
                    else if (dataColumn.DataType.Name.Equals("DateTime"))
                    {
                        if (dataRow[dataColumn].ToString().Trim().Length == 0 || dataRow[dataColumn].ToString().Trim() == "0001-1-1 0:00:00")
                        {
                            sUpdateSql += dataColumn.ColumnName + " = null,";//如果没有赋值，则为null
                        }
                        else
                        {
                            sUpdateSql += dataColumn.ColumnName + " = " + DbToDate(dataRow[dataColumn].ToString()) + ",";
                        }
                    }
                    //其它型数据.
                    else
                    {
                        sUpdateSql += dataColumn.ColumnName + " = '" + ReplaceSqlKeyStr(dataRow[dataColumn].ToString()) + "',";
                    }
                }

                //在修改时如果当前业务表存在UPDATETIME字段，则用系统日期来更新该字段（2007-08-21添加此功能）.
                if (lstColName.Contains("UPDATETIME"))
                {
                    sUpdateSql += "updatetime = " + dbAccess.GetSysDate() + " ";
                }
                //组装好更新当前行的Update语句.
                sUpdateSql = sUpdateSql.Substring(0, sUpdateSql.Length - 1) + " where " + dtb.Columns[0] + "='" + dataRow[0].ToString() + "'";

                lstUpdateSql.Add(sUpdateSql);//把组装好的Update操作语句放到泛型集合中去.
                sUpdateSql = "update " + tableName + " set ";
            }

            return lstUpdateSql;
        }

        #region IDBOperation 成员

        public string DbGetDate()
        {
            return " getdate() ";
        }

        public string ReplaceSqlKeyStr(string ReplacedStr)
        {
            if (string.IsNullOrEmpty(ReplacedStr)) return "";
            //sqlserver 关键字是' 应该提换成''
            ReplacedStr = ReplacedStr.Replace("'", "''");
            return ReplacedStr;
        }

        public string DbIsNull
        {
            get { return "IsNull"; }
        }

        #endregion
    }
}
