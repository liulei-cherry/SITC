using System;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using System.Drawing;

namespace CommonOperation.Interfaces
{
    public interface IDBAccess
    {
        string GetConectString();
        bool ExecSql(string sql, out string err);
        bool ExecSql(List<string> lstSql, out string err);

        void BeginTransaction();
        void CommitTransaction();
        void EndTransaction();
        DataTable GetDataTable(string sSql, out string sErrMessage);
        bool GetDataTable(string sSql, out DataTable dt, out string sErrMessage);

        string GetString(string sSql, out string err);
        bool GetString(string sSql,out string sContent, out string sErrMessage);
        string GetString(string sSql);
        bool ReadBlobFromDb(string sSelectSql, string sPath, out string sErrMessage);
        bool ReadBlobFromDb(string sSelectSql, out Stream sPath, out string sErrMessage);
        bool WriteBlobToDbWithIns(string sInsertSql, string sUpdateSql, string fileName, string param, out string sErrMessage);
        /// <summary>
        /// 根据指定的表名在数据库中查找该表的所有字段名称后将其放到一个泛型集合中返回.
        /// </summary>
        /// <param name="sTableName">表名</param>
        /// <returns>返回一个包含表的所有字段名的泛型集合</returns>
        List<string> GetTablesColNames(string sTableName, out string sErrMessage);
        /// <summary>
        /// 执行一个存储过程，获得返回值.
        /// </summary>
        /// <param name="sProcName">存储过程名</param>
        /// <param name="dictInPara">参数字典</param>
        /// <param name="dtb">返回的datatable</param>
        /// <param name="sErrMessage">返回的错误信息</param>
        /// <returns>成功失败</returns>
        bool ExecProce(string sProcName, Dictionary<string, string> dictInPara, out DataTable dtb, out string sErrMessage);
        /// <summary>
        /// 执行一个存储过程，获得返回值.
        /// </summary>
        /// <param name="sProcName">存储过程名</param>
        /// <param name="dictInPara">参数字典</param>
        /// <param name="sErrMessage">返回的错误信息</param>
        /// <returns>成功失败</returns>
        bool ExecProce(string sProcName, Dictionary<string, string> dictInPara, out string sErrMessage);
       
        /// <summary>
        /// 返回存放指定表的每个字段的属性信息的泛型集合。.
        /// 这些属性信息有：字段的名称（用于设置集合的Key值）、字段的长度、是否允许为空和数据类型。.
        /// 取这些属性信息的目的是为了在界面上执行保存功能时可以对相应的控件进行校验（如长度校验、为空校验等）.
        /// </summary>
        /// <param name="tableName">指定的表名</param>
        /// <param name="sErrMessage">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        /// <returns>泛型集合</returns>
        Dictionary<string, FldProperty> GetTbColumnSize(string tableName, out string sErrMessage);
        string GetSysDate();
        Image GetImageFromDb(string sSelectSql, out string sErrMessage);

        bool GetCanNotUse{get;}
    }
}
