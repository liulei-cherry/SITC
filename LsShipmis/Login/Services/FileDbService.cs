using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

namespace Login.Services
{
    public class FileDbService
    {
        #region 构造函数

        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static FileDbService instance = new FileDbService();
        public static FileDbService Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new FileDbService();
                }
                return instance;
            }
        }
        private FileDbService()
        {
        }
        #endregion

        private SqlServerAccess dbAccess = new SqlServerAccess(ConstParameter.DBConnectString);
        private SqlServerAccess lobdbAccess =  new SqlServerAccess(ConstParameter.LobDBConnectString); 
        #region 操作t_fileInfo表


        public bool InsertABlob(string fileAddress, out string sObjectId)
        {
            //先插入一条空记录再更新.
            sObjectId = "";
            if (!File.Exists(fileAddress))
            {
                return true;
            }
            string sInsertSql = "";
            string sUpdateSql = "";
            string err = "";
            sObjectId = Guid.NewGuid().ToString();
            sInsertSql = "insert into t_fileinfo(object_id) values('" + sObjectId + "')";
            sUpdateSql = "update t_fileinfo set object_con_blob = @object_con_blob where upper(object_id)='" + sObjectId.ToUpper() + "'";
            return lobdbAccess.WriteBlobToDbWithIns(sInsertSql, sUpdateSql, fileAddress, "object_con_blob", out err);
        }

        public bool UpdateABlob(string sObjectId, string fileAddress)
        {          
            string sInsertSql = "";
            string sSql = "";
            string err = "";
            FileInfo zipfile = new FileInfo(fileAddress);
            if (!File.Exists(fileAddress))
            {
                return false;
            }

            //在这里判断,如果没有这个文件id,则变成插入操作.
            sSql = "select count(1) from t_fileinfo where object_id ='" + sObjectId + "'";
            if (lobdbAccess.GetString(sSql) == "0")
            {
                sInsertSql = "insert into t_fileinfo(object_id) values('" + sObjectId + "')";
            }

            sSql = "update t_fileinfo set object_con_blob = @object_con_blob where upper(object_id)='" + sObjectId.ToUpper() + "'";
            return lobdbAccess.WriteBlobToDbWithIns(sInsertSql, sSql, fileAddress, "object_con_blob", out err);
        }

        public string DeleteABlob(string objectId)
        {
            string sSql = "delete from t_fileinfo where upper(OBJECT_ID)='" + objectId.ToUpper() + "' ";
            return sSql;
        }

        public bool GetABlobStreamById(string sFileId, out Stream fileStream)
        {
            string err = "";
            string sSql;
            //获取实际的物理文件.
            sSql = "select OBJECT_CON_BLOB FROM T_FILEINFO WHERE OBJECT_ID ='" + sFileId + "'";
            return lobdbAccess.ReadBlobFromDb(sSql, out fileStream, out err);
        }
        public bool GetABlobByBlodId(string sBlodId, string filepath)
        {
            string err = "";
            string sSql;
            //获取实际的物理文件.
            if (string.IsNullOrEmpty(sBlodId) || sBlodId.Length != 36) return false;
            sSql = "select OBJECT_CON_BLOB FROM T_FILEINFO WHERE OBJECT_ID ='" + sBlodId + "'";
            return lobdbAccess.ReadBlobFromDb(sSql, filepath, out err);
        }
        #endregion 
    }
}
