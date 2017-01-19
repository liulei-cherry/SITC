using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CommonOperation.Interfaces
{
    public interface IDBOperation
    {
        string DbToDate(DateTime datetime);
        string DbToDate(string sdatetime);
        string ReplaceSqlKeyStr(string ReplacedStr);
        bool SaveFormData(DataTable dtb, string sTableName, int mark, out string err);
        /// <summary>
        /// 取得SQL语句. 2014.2.18 刘子建添加.
        /// </summary>
        /// <param name="dtb"></param>
        /// <param name="sTableName"></param>
        /// <param name="mark"></param>
        /// <returns></returns>
        List<string> SaveFormData(DataTable dtb, string sTableName, int mark);
        string DbGetDate();
        string DbIsNull { get;}
        bool DbHaveThisData(string toFindData, string tableName, string IdName, string findColumnName, string exceptId);
        bool ThisShipHaveThisData(string toFindData, string shipid, string tableName, string IdName, string findColumnName, string exceptId);
    }
}
