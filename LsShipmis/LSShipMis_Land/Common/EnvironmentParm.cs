using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using LSShipMis_Land.Common.Classes ;
using Microsoft.Win32;
using CommonOperation.Functions; 

namespace LSShipMis_Land.Common
{
    public enum Language
    {
        English = 0,
        Chinese = 1,
    }
    public enum DBMSUsed
    {
        //
        Oracle = 0,
        SqlServer = 1,
        MySql = 2,
    }
    //全局唯一的环境变量类.
    public class EnvironmentParm
    {
        public static string TempFileSavePath;//临时文件保存路径.

        public static DBMSUsed DbmsUsed = DBMSUsed.SqlServer;
        public static DateTime MaxDateTime = new DateTime(2999, 12, 31);
        public static DateTime MinDateTime = new DateTime(1900, 1, 1);

        public static string DbToDate(DateTime dtToBeChangedDate)
        {
            if (dtToBeChangedDate < MinDateTime || dtToBeChangedDate > MaxDateTime)
            {
                return "null";
            }
            switch (DbmsUsed)
            {
                case DBMSUsed.Oracle:
                    return " to_date('" + dtToBeChangedDate.ToString() + "','yyyy-MM-dd hh24:mi:ss') ";
                case DBMSUsed.SqlServer:
                    return " cast('" + dtToBeChangedDate.ToString() + "' as datetime) ";
                default:
                    return " to_date('" + dtToBeChangedDate.ToString() + "','yyyy-MM-dd hh24:mi:ss') ";
            }
        }
        public static string DbToDate(string dtToBeChangedDate)
        {
            switch (DbmsUsed)
            {
                case DBMSUsed.Oracle:
                    return " to_date('" + dtToBeChangedDate + "','yyyy-MM-dd hh24:mi:ss') ";
                case DBMSUsed.SqlServer:
                    if (dtToBeChangedDate.Trim().Length == 0)
                    {
                        //在SQL Server中会把空字符串的日期值显示成1900-1-1，所以必须把空字符串转化为Null值.
                        return "null";
                    }
                    else
                    {
                        return " cast('" + dtToBeChangedDate + "' as datetime) ";
                    }
                default:
                    return " to_date('" + dtToBeChangedDate + "','yyyy-MM-dd hh24:mi:ss') ";
            }
        }
    }
}
