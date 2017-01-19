/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有

 * 文 件 名：OneVersionService.cs
 * 创 建 人：徐正本

 * 创建时间：2011/12/3
 * 标    题：数据操作类

 * 功能描述：T_AutoUpdateVersion数据操作类

 * Codesmith DataAccessLayer.cst 1.01版本生成
 ****************************************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Login.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_AutoUpdateVersionService.cs
    /// </summary>
    public partial class OneVersionService
    {
        #region 构造函数

        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static OneVersionService instance = new OneVersionService();
        public static OneVersionService Instance
        {
            get
            {
                if (null == instance)
                {
                    OneVersionService.instance = new OneVersionService();
                }
                return OneVersionService.instance;
            }
        }
        private OneVersionService() { }
        #endregion
        private SqlServerAccess dbAccess = new SqlServerAccess(ConstParameter.DBConnectString);
        private SqlServerAccess lobdbAccess = new SqlServerAccess(ConstParameter.LobDBConnectString);
        string sql = "";
        public string ReplaceSqlKeyStr(string ReplacedStr)
        {
            if (string.IsNullOrEmpty(ReplacedStr)) return "";
            //sqlserver 关键字是' 应该提换成''
            ReplacedStr = ReplacedStr.Replace("'", "''");
            return ReplacedStr;
        }
        public string DbToDate(DateTime dtToBeChangedDate)
        {
            if (dtToBeChangedDate < new DateTime(1950, 1, 1) || dtToBeChangedDate > new DateTime(2050, 12, 31))
            {
                return " null ";
            }
            return " cast('" + dtToBeChangedDate.ToString() + "' as datetime) ";
        }

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">OneVersion对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(OneVersion unit, out string err)
        {
            if (unit.AutoUpdateID != null && unit.AutoUpdateID.Length > 0) //edit
            {
                sql = "UPDATE [T_AutoUpdateVersion] SET "
                    + " [AutoUpdateID] = " + (string.IsNullOrEmpty(unit.AutoUpdateID) ? "null" : "'" + ReplaceSqlKeyStr(unit.AutoUpdateID) + "'")
                    + " , [VersionNo] = " + (unit.VersionNo == null ? "''" : "'" + ReplaceSqlKeyStr(unit.VersionNo) + "'")
                    + " , [IsValid] = " + unit.IsValid.ToString()
                    + " , [EffectiveStartTime] = " + DbToDate(unit.EffectiveStartTime)
                    + " , [CreateDate] = " + DbToDate(unit.CreateDate)
                    + " , [OBJECT_ID] = " + (string.IsNullOrEmpty(unit.OBJECT_ID) ? "null" : "'" + ReplaceSqlKeyStr(unit.OBJECT_ID) + "'")
                    + "\rwhere AutoUpdateID = '" + ReplaceSqlKeyStr(unit.AutoUpdateID) + "'";
            }
            else
            {
                unit.AutoUpdateID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_AutoUpdateVersion] ("
                    + "[AutoUpdateID],"
                    + "[VersionNo],"
                    + "[IsValid],"
                    + "[EffectiveStartTime],"
                    + "[CreateDate],"
                    + "[OBJECT_ID]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.AutoUpdateID) ? "null" : "'" + ReplaceSqlKeyStr(unit.AutoUpdateID) + "'")
                    + " , " + (unit.VersionNo == null ? "''" : "'" + ReplaceSqlKeyStr(unit.VersionNo) + "'")
                    + " ," + unit.IsValid.ToString()
                    + " ," + DbToDate(unit.EffectiveStartTime)
                    + " ," + DbToDate(unit.CreateDate)
                    + " , " + (string.IsNullOrEmpty(unit.OBJECT_ID) ? "null" : "'" + ReplaceSqlKeyStr(unit.OBJECT_ID) + "'")
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_AutoUpdateVersion中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_AutoUpdateVersion对象</param>
        internal bool deleteUnit(OneVersion unit, out string err)
        {
            return deleteUnit(unit.AutoUpdateID, out err);
        }

        /// <summary>
        /// 删除数据表T_AutoUpdateVersion中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_AutoUpdateVersion.autoUpdateID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_AutoUpdateVersion where AutoUpdateID='" + ReplaceSqlKeyStr(unitid) + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_AutoUpdateVersion 所有数据信息.
        /// </summary>
        /// <returns>T_AutoUpdateVersion DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "AutoUpdateID"
                + ",VersionNo"
                + ",IsValid"
                + ",EffectiveStartTime"
                + ",CreateDate"
                + ",OBJECT_ID"
                + "\rfrom T_AutoUpdateVersion ";
            DataTable dt;
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 根据一个主键ID,得到 T_AutoUpdateVersion 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>OneVersion DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "AutoUpdateID"
                + ",VersionNo"
                + ",IsValid"
                + ",EffectiveStartTime"
                + ",CreateDate"
                + ",OBJECT_ID"
                + "\rfrom T_AutoUpdateVersion "
                + "\rwhere AutoUpdateID='" + ReplaceSqlKeyStr(Id) + "'";
            DataTable dt;
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 根据oneversion 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>oneversion 数据实体</returns>
        public OneVersion getObject(DataRow dr)
        {
            OneVersion unit = new OneVersion();
            if (null == dr)
            {
                return null;
            }
            if (DBNull.Value != dr["AutoUpdateID"])
                unit.AutoUpdateID = dr["AutoUpdateID"].ToString();
            if (DBNull.Value != dr["VersionNo"])
                unit.VersionNo = dr["VersionNo"].ToString();
            if (DBNull.Value != dr["IsValid"])
                unit.IsValid = Convert.ToDecimal(dr["IsValid"]);
            if (DBNull.Value != dr["EffectiveStartTime"])
                unit.EffectiveStartTime = (DateTime)dr["EffectiveStartTime"];
            if (DBNull.Value != dr["CreateDate"])
                unit.CreateDate = (DateTime)dr["CreateDate"];
            if (DBNull.Value != dr["OBJECT_ID"])
                unit.OBJECT_ID = dr["OBJECT_ID"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个OneVersion对象.
        /// </summary>
        /// <param name="autoUpdateID">autoUpdateID</param>
        /// <returns>OneVersion对象</returns>
        public OneVersion getObject(string Id, out string err)
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

        public bool getDBHaveThisVersion(string version, out OneVersion dbVersion)
        {
            string err;
            dbVersion = null;
            sql = "select "
               + "AutoUpdateID"
               + ",VersionNo"
               + ",IsValid"
               + ",EffectiveStartTime"
               + ",CreateDate"
               + ",OBJECT_ID"
               + "\rfrom T_AutoUpdateVersion "
               + "\rwhere VersionNo='" + ReplaceSqlKeyStr(version) + "'";
            DataTable dt;
            if (dbAccess.GetDataTable(sql, out dt, out err) && dt.Rows.Count == 1)
            {
                dbVersion = getObject(dt.Rows[0]);
                if (dbVersion != null)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        public bool getDBHaveOneBlobOfNameAndMD5(string fileName, string md5, out string fileID)
        {
            string err;
            sql = string.Format(@"select top 1 AutoUpdateFileID
                    from T_AutoUpdateFile
                    where FileName = '{0}' and FileMD5 = '{1}'
                    order by FileVsersionNo", ReplaceSqlKeyStr(fileName), ReplaceSqlKeyStr(md5));
            if (!dbAccess.GetString(sql, out fileID, out err))
                return false;
            return !string.IsNullOrEmpty(fileID);
        }

        public bool RelationAFileWithOtherFileId(string mainVersionId, string oldFileId, out string err)
        {
            sql = string.Format(@"insert into T_AutoRelation(RelationID,AutoUpdateID,AutoUpdateFileID)
                    values(newid(),'{0}','{1}')", ReplaceSqlKeyStr(mainVersionId), ReplaceSqlKeyStr(oldFileId));
            return dbAccess.ExecSql(sql, out err);
        }

        public bool RelationAFileWithBlobID(string mainVersionId, string blobFileId, string fileVersion,
            string fileName, string fileMd5, string filePath, out string err)
        {
            List<string> sqls = new List<string>();
            string newid = Guid.NewGuid().ToString();
            sql = string.Format(@"INSERT INTO [dbo].[T_AutoUpdateFile]
                   ([AutoUpdateFileID],[OBJECT_ID],[FileVsersionNo],[FileName],[FileMD5],[FilePath])
                VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", ReplaceSqlKeyStr(newid),
                ReplaceSqlKeyStr(blobFileId), ReplaceSqlKeyStr(fileVersion),
                ReplaceSqlKeyStr(fileName), ReplaceSqlKeyStr(fileMd5), ReplaceSqlKeyStr(filePath));
            sqls.Add(sql);

            sql = string.Format(@"insert into T_AutoRelation(RelationID,AutoUpdateID,AutoUpdateFileID)
                    values(newid(),'{0}','{1}')", ReplaceSqlKeyStr(mainVersionId), ReplaceSqlKeyStr(newid));
            sqls.Add(sql);
            return dbAccess.ExecSql(sqls, out err);
        }
    }
}
