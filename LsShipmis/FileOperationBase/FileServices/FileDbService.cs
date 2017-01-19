using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using FileOperationBase.Services;

namespace FileOperationBase.FileServices
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

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBAccess lobdbAccess = InterfaceInstantiation.NewADbAccess(true);
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
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
            bool rtn = updateABlob(sObjectId, fileAddress);

            if (rtn)
            {
                updateFileSizeAndDate(sObjectId, fileAddress);
            }
            return rtn;
        }
        private bool updateABlob(string sObjectId, string fileAddress)
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
        public bool GetABlobById(string sFileId, string fileName, out string path)
        {
            string err = "";

            //获取object_id
            string sSql = "SELECT OBJECT_ID, FILE_NAME FROM T_FILE_MANAGE where upper(FILE_ID) = '" + sFileId.ToUpper() + "'";
            DataTable dtb;
            if (!dbAccess.GetDataTable(sSql, out dtb, out err) || dtb.Rows.Count == 0)
            {
                path = "";
                return false;
            }
            string obj_id;
            obj_id = dtb.Rows[0][0].ToString();

            //获取实际的物理文件.
            sSql = "select OBJECT_CON_BLOB FROM T_FILEINFO WHERE OBJECT_ID ='";
            sSql += obj_id + "'";

            //用目录文件名建立一级子目录.
            string tmp = Guid.NewGuid().ToString();
            path = (@"d:\ShipMisFiles\FileOperation\" + tmp + @"\" + obj_id + @"\");
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                try { Directory.CreateDirectory(Path.GetDirectoryName(path)); }
                catch
                {
                    path = (@"c:\ShipMisFiles\FileOperation\" + tmp + @"\" + obj_id + @"\");
                    if (!Directory.Exists(Path.GetDirectoryName(path)))
                    {
                        try { Directory.CreateDirectory(Path.GetDirectoryName(path)); }
                        catch
                        {
                            throw new Exception("This program cannot create file or directory in BOTH Disk C: and D:.");
                        }
                    }
                }
            }
            //判断指定目录下是否存在同名?这个是否存在问题.
            path = path + fileName;
            return lobdbAccess.ReadBlobFromDb(sSql, path, out err);
        }

        #endregion

        #region 操作t_file_manage表

        public bool InsertAFile(ourFile file, string sFileAddress, out string fileId, out string err)
        {
            err = "";
            string sSql = "";
            string objectId = "";
            fileId = "";
            if (!InsertABlob(sFileAddress, out objectId))
            {
                err = "插入大字段失败！";
            }
            fileId = Guid.NewGuid().ToString();
            file.FileId = fileId;
            FileInfo fi = null;
            try
            {
                fi = new FileInfo(sFileAddress);
            }
            catch
            { }
            sSql = "insert into t_file_manage(FILE_ID,OBJECT_ID,FILE_NAME,FSIZE,OBJECT_LABEL,CREATE_DATE,CREATOR,DOCTYPE_ID,REF_EQUIPMENT,PRESERVE1,PRESERVE2,VERSION,REF_FILEID,FILE_TYPE";
            if (file.ShipId != null && file.ShipId.Length > 0)
            {
                sSql += ",SHIP_ID";
            }
            sSql += ")";
            sSql += "values('";
            sSql += fileId;
            sSql += "','";
            sSql += objectId;
            sSql += "',N'";
            if (file.FileName != null)
            {
                sSql += file.FileName.Replace("'", "''");
            }
            sSql += "',";
            sSql += (fi != null ? fi.Length : 0);
            sSql += ",'";
            if (file.ObjectLabel != null)
            {
                sSql += file.ObjectLabel.Replace("'", "''");
            }
            sSql += "',";
            sSql += dbOperation.DbToDate(DateTime.Now);

            sSql += ",'";
            sSql += dbOperation.ReplaceSqlKeyStr(file.Creator);
            sSql += "','','";
            sSql += dbOperation.ReplaceSqlKeyStr(file.RefEquipment);
            sSql += "','";
            sSql += dbOperation.ReplaceSqlKeyStr(file.Preserve1);
            sSql += "','";
            sSql += dbOperation.ReplaceSqlKeyStr(file.Preserve2);
            sSql += "','";
            sSql += dbOperation.ReplaceSqlKeyStr(file.Version);
            sSql += "','";
            sSql += file.Ref_Fileid;
            sSql += "','";
            sSql += file.File_Type;
            if (file.ShipId != null && file.ShipId.Length > 0)
            {
                sSql += "','";
                sSql += file.ShipId;
            }
            sSql += "') ";

            if (!dbAccess.ExecSql(sSql, out err))
            {
                return false;
            }

            return true;
        }

        public bool UpdateAFile(ourFile file, string sFileAddress, out string err)
        { 
            err = "";
            string sSql = "";
            List<string> sqls = new List<string>();
            if (!sFileAddress.Equals(""))
            {
                if (string.IsNullOrEmpty(file.Object_id)) file.Object_id = Guid.NewGuid().ToString();
                if (!UpdateABlob(file.Object_id, sFileAddress))
                {
                    return false;
                }
            }
            if (string.IsNullOrEmpty(file.FileId))
            {
                file.FileId = Guid.NewGuid().ToString();
                sSql = @"insert into T_FILE_MANAGE(FILE_ID, OBJECT_ID, FILE_NAME, FSIZE, OBJECT_LABEL,
                CREATOR, VERSION,  REF_FILEID,FILE_TYPE, PRESERVE1, PRESERVE2, SHIP_ID)
                values ('" + file.FileId + "','" + file.Object_id + "',N'" + dbOperation.ReplaceSqlKeyStr(file.FileName) + "',"
                + file.Size.ToString() + ",'" + dbOperation.ReplaceSqlKeyStr(file.ObjectLabel) + "','" + dbOperation.ReplaceSqlKeyStr(file.Creator) + "','"
                 + dbOperation.ReplaceSqlKeyStr(file.Version) + "','"
                 + dbOperation.ReplaceSqlKeyStr(file.Ref_Fileid) + "','" + dbOperation.ReplaceSqlKeyStr(file.File_Type)
                 + "','" + dbOperation.ReplaceSqlKeyStr(file.Preserve1) + "','" + dbOperation.ReplaceSqlKeyStr(file.Preserve2)
                 + "','" + dbOperation.ReplaceSqlKeyStr(file.ShipId) + "')";
                sqls.Add(sSql);
            }
            else
            {
                sSql += "update T_FILE_MANAGE ";
                sSql += "set OBJECT_ID='";
                sSql += file.Object_id;
                sSql += "',FILE_NAME=N'";
                if (!string.IsNullOrEmpty(file.FileName))
                {
                    sSql += file.FileName.Replace("'", "''");
                }
                sSql += "',FSIZE=";
                sSql += file.Size.ToString();
                sSql += ",OBJECT_LABEL='";
                if (file.ObjectLabel != null)
                {
                    sSql += file.ObjectLabel.Replace("'", "''");
                }
                sSql += "',CREATOR='";
                if (!string.IsNullOrEmpty(file.Creator)) sSql += file.Creator.Replace("'", "''");
                sSql += "',DOCTYPE_ID=''";
                sSql += ",REF_EQUIPMENT='";
                if (!string.IsNullOrEmpty(file.RefEquipment)) sSql += file.RefEquipment.Replace("'", "''");
                sSql += "',PRESERVE1='";
                if (!string.IsNullOrEmpty(file.Preserve1)) sSql += file.Preserve1.Replace("'", "''");
                sSql += "',PRESERVE2='";
                if (!string.IsNullOrEmpty(file.Preserve2)) sSql += file.Preserve2.Replace("'", "''");
                sSql += "',VERSION='";
                if (!string.IsNullOrEmpty(file.Version)) sSql += file.Version.Replace("'", "''");
                sSql += "',FILE_TYPE='";
                if (!string.IsNullOrEmpty(file.File_Type)) sSql += file.File_Type.Replace("'", "''");
                sSql += "',REF_FILEID='";
                if (!string.IsNullOrEmpty(file.Ref_Fileid)) sSql += file.Ref_Fileid;
                if (file.ShipId != null && file.ShipId.Length > 0)
                {
                    sSql += "',SHIP_ID='";
                    sSql += file.ShipId;
                }
                sSql += "' ";
                sSql += "where upper(file_id)='";
                sSql += file.FileId;
                sSql += "' ";
                sqls.Add(sSql);
                sSql = "update t_file_ref set file_id='" + file.FileId + "' where  file_id ='" + file.FileId + "'";
                sqls.Add(sSql);
            }
            return dbAccess.ExecSql(sqls, out err);
        }

        public bool renameFile(string fileId, string newName, out string err)
        {
            err = "";
            string sSql = "";
            List<string> sqls = new List<string>();
            sSql = "update T_FILE_MANAGE set file_name=N'" + newName.Replace("'", "''") + "' where file_id='" + fileId + "'";
            sqls.Add(sSql);
            sSql = "update t_file_ref set file_id='" + fileId.ToLower() + "' where upper(file_id)='" + fileId.ToUpper() + "'";
            sqls.Add(sSql);
            return dbAccess.ExecSql(sqls, out err);
        }
        public string DeleteAFile(string fileId)
        {

            string sSql = "";
            sSql += "delete from T_FILE_MANAGE ";
            sSql += "where upper(file_id)='";
            sSql += fileId.ToUpper();
            sSql += "' ";

            return sSql;
        }
        public bool DeleteABlobFileById(string fileId, out string err)
        {
            return lobdbAccess.ExecSql(DeleteAFile(fileId), out err);
        }
        public bool formListFiles(DataTable dtb, out List<ourFile> files, out string err)
        {
            files = new List<ourFile>();
            err = "";
            decimal dSize = 0.0M;
            DateTime createDate;
            DateTime updateDate;
            try
            {
                foreach (DataRow row in dtb.Rows)
                {
                    ourFile file = new ourFile();
                    file.FileId = row["FILE_ID"].ToString();
                    file.FileName = row["file_NAME"].ToString();
                    file.Object_id = row["OBJECT_ID"].ToString();
                    file.ObjectLabel = row["OBJECT_LABEL"].ToString();
                    if (DateTime.TryParse(row["CREATE_DATE"].ToString(), out createDate))
                    {
                        file.CreateDate = createDate;
                    }
                    if (DateTime.TryParse(row["UPDATE_DATE"].ToString(), out updateDate))
                    {
                        file.UpdateDate = updateDate;
                    }
                    file.Creator = row["CREATOR"].ToString();
                    file.RefEquipment = row["REF_EQUIPMENT"].ToString();
                    file.ShipId = row["SHIP_ID"].ToString();
                    if (decimal.TryParse(row["FSIZE"].ToString(), out dSize))
                    {
                        file.Size = dSize;
                    }
                    file.Preserve1 = row["PRESERVE1"].ToString();
                    file.Preserve2 = row["PRESERVE2"].ToString();
                    file.Version = row["VERSION"].ToString();
                    file.Ref_Fileid = row["REF_FILEID"].ToString();
                    file.File_Type = row["FILE_TYPE"].ToString();
                    files.Add(file);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 判断文件是否可以直接删除(直接删除条件：体系文件或模板文件并且没生成体系文件)
        /// </summary>
        /// <param name="fileId"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool IfHaveSubFiles(string fileId, out string err)
        {
            ourFile file;
            if (!GetAFileById(fileId, out file))
            {
                err = "此文件不存在！";
                return false;
            }
            //是体系文件.
            if (file.Preserve2.ToUpper().Trim().Equals("DOC"))
            {
                err = "";
                return true;
            }
            //是模板文件.
            string sSql = "";
            sSql += "select fileId from t_file_manage upper(VERSION)='";
            sSql += fileId.ToUpper();
            sSql += "' ";
            DataTable dtb;
            if (dbAccess.GetDataTable(sSql, out dtb, out err) || dtb == null)
            {
                err = "数据库连接出错！";
                return false;
            }
            if (dtb.Rows.Count > 0)
            {
                err = "模板已经生成体系文件，不能删除！";
                return false;
            }
            return true;
        }
        public bool GetAFileById(string sFileId, out ourFile file)
        {
            file = null;
            if (string.IsNullOrEmpty(sFileId)) return false;
            string sSql = "";
            string err = "";
            file = null;
            sSql += "select a.file_id,a.OBJECT_ID,a.file_NAME,a.FSIZE,a.OBJECT_LABEL,a.CREATE_DATE," +
            "a.UPDATE_DATE,a.CREATOR,a.DOCTYPE_ID,'' TYPE_NAME,a.REF_EQUIPMENT,a.PRESERVE1,a.PRESERVE2," +
            "a.SHIP_ID,a.VERSION,a.FILE_TYPE,a.REF_FILEID from T_FILE_MANAGE a where upper(a.FILE_ID)='" + sFileId.ToUpper() + "' ";

            DataTable dtb;
            dbAccess.GetDataTable(sSql, out dtb, out err);
            List<ourFile> files;
            if (!formListFiles(dtb, out files, out err))
            {
                return false;
            }
            if (files.Count >= 1)
            {
                file = files[0];
                return true;
            }

            return false;
        }
        public bool GetAFileByIdNotHaveDocType(string sFileId, out ourFile file)
        {
            string sSql = "";
            string err = "";
            file = null;
            sSql += "select a.file_id,a.OBJECT_ID,a.file_NAME,a.FSIZE,a.OBJECT_LABEL,a.CREATE_DATE,a.UPDATE_DATE,a.CREATOR,a.DOCTYPE_ID,'' as TYPE_NAME,a.REF_EQUIPMENT,a.PRESERVE1,a.PRESERVE2,a.VERSION,a.REF_FILEID,a.FILE_TYPE,a.SHIP_ID from T_FILE_MANAGE a where upper(a.FILE_ID)='";
            sSql += sFileId.ToUpper();
            sSql += "' ";
            DataTable dtb;
            dbAccess.GetDataTable(sSql, out dtb, out err);
            List<ourFile> files;
            if (!formListFiles(dtb, out files, out err))
            {
                return false;
            }
            if (files.Count >= 1)
            {
                file = files[0];
                return true;
            }

            return false;
        }
        public bool GetABolbByFileId(string sFileId, out string path)
        {
            path = "";
            ourFile file;
            if (!GetAFileById(sFileId, out file))
            {
                return false;
            }
            if (GetABlobById(sFileId, String.Join("", file.FileName.Split(Path.GetInvalidFileNameChars())), out path))
            {
                return true;
            }

            return false;
        }
        public bool GetABolbByISMFileId(string sFileId, out string path)
        {
            path = "";
            ourFile file;

            if (!GetAFileByIdNotHaveDocType(sFileId, out file))
            {
                return false;
            }
            if (GetABlobById(sFileId, file.FileName, out path))
            {
                return true;
            }

            return false;
        }
        public DataTable GetFilesBySelect(string creator, DateTime startTime, DateTime endTime, List<string> keyWords, string nodeId, string shipId)
        {

            DataTable dtb;
            string err;
            string sSql = "";
            List<ourFolder> folders = new List<ourFolder>();
            List<ourFile> files = new List<ourFile>();

            if (nodeId.Length > 0)
            {
                ourFolder ourfolder = FolderDbService.Instance.GetAnOurFoldById(nodeId, out err);
                if (ourfolder == null)
                {
                    dtb = null;
                    return dtb;
                }

                FolderDbService.Instance.GetSubFoldersAndFiles(ourfolder, out folders, out files);
            }

            sSql = "select distinct(a.file_id),a.OBJECT_ID,a.FILE_NAME,a.FSIZE,a.OBJECT_LABEL,a.CREATE_DATE, " +
            " a.UPDATE_DATE,a.CREATOR,a.DOCTYPE_ID,'' TYPE_NAME,a.REF_EQUIPMENT,a.PRESERVE1,a.PRESERVE2,a.VERSION, " +
            " a.FILE_TYPE,a.REF_FILEID,a.SHIP_ID from T_FILE_MANAGE a " +
            " inner join T_FILE_REF c on c.FILE_ID=a.FILE_ID ";
            sSql += " where a.UPDATE_DATE>=";
            sSql += dbOperation.DbToDate(startTime);
            sSql += " and a.UPDATE_DATE<=";
            sSql += dbOperation.DbToDate(endTime);
            if (shipId != null && shipId.Length > 0)
            {
                sSql += "and upper(a.SHIP_ID)='";
                sSql += shipId.ToUpper();
                sSql += "' ";
            }
            if (!creator.Equals(""))
            {
                sSql += " and upper(a.CREATOR)='";
                sSql += creator.ToUpper();
                sSql += "' ";
            }
            if (!nodeId.Equals(""))
            {
                sSql += " and upper(c.NODE_ID) in('";
                sSql += nodeId.ToUpper();
                sSql += "'";
                foreach (ourFolder folder in folders)
                {
                    sSql += ",'";
                    sSql += folder.NodeId.ToUpper();
                    sSql += "'";
                }
                sSql += ") ";
            }
            if (keyWords.Count != 0)
            {
                sSql += "and (";
                foreach (string keyWord in keyWords)
                {
                    sSql += " OBJECT_LABEL like '%";
                    sSql += dbOperation.ReplaceSqlKeyStr(keyWord);
                    sSql += "%' or file_name like N'%" + dbOperation.ReplaceSqlKeyStr(keyWord) + "%'";
                    sSql += "  or ";
                }
                sSql = sSql.Substring(0, sSql.Length - 4);
                sSql += ") ";
            }

            DataTable dt;
            if (dbAccess.GetDataTable(sSql, out dt, out err))
            {
                return dt;
            }
            return null;
        }
        public DataTable GetDocFilesBySelect(string version, string creator, DateTime startTime, DateTime endTime, List<string> keyWords, string nodeId, string shipId)
        {
            DataTable dtb;
            string err;
            string sSql = "";
            List<ourFolder> folders = new List<ourFolder>();
            List<ourFile> files = new List<ourFile>();

            ourFolder ourfolder = FolderDbService.Instance.GetAnOurFoldById(nodeId, out err);
            if (ourfolder == null)
            {
                dtb = null;
                return dtb;
            }

            FolderDbService.Instance.GetSubFoldersAndFiles(ourfolder, out folders, out files);

            sSql = "select a.file_id,a.OBJECT_ID,a.FILE_NAME,a.FSIZE,a.OBJECT_LABEL,a.CREATE_DATE," +
            " a.UPDATE_DATE,a.CREATOR,a.DOCTYPE_ID,b.TYPE_NAME,a.REF_EQUIPMENT,a.PRESERVE1,a.PRESERVE2,a.VERSION," +
            " a.REF_FILEID,a.FILE_TYPE,a.SHIP_ID from T_FILE_MANAGE a " +
            " inner join FILE_REF c on c.FILE_ID=a.FILE_ID ";
            sSql += " where a.UPDATE_DATE>=";
            sSql += dbOperation.DbToDate(startTime);
            sSql += " and a.UPDATE_DATE<=";
            sSql += dbOperation.DbToDate(endTime);

            if (shipId != null && shipId.Length > 0)
            {
                sSql += "and upper(a.SHIP_ID)='";
                sSql += shipId.ToUpper();
                sSql += "' ";
            }
            if (!creator.Equals(""))
            {
                sSql += " and upper(a.CREATOR)='";
                sSql += creator.ToUpper();
                sSql += "' ";
            }
            if (!nodeId.Equals(""))
            {
                sSql += " and upper(c.NODE_ID) in('";
                sSql += nodeId.ToUpper();
                sSql += "'";
                foreach (ourFolder folder in folders)
                {
                    sSql += ",'";
                    sSql += folder.NodeId.ToUpper();
                    sSql += "'";
                }
                sSql += ") ";
            }
            if (keyWords.Count != 0)
            {
                sSql += "and (";
                foreach (string keyWord in keyWords)
                {
                    sSql += " OBJECT_LABEL like '%";
                    sSql += dbOperation.ReplaceSqlKeyStr(keyWord);
                    sSql += "%'";
                    sSql += "  or ";
                }
                sSql = sSql.Substring(0, sSql.Length - 4);
                sSql += ") ";
            }
            if (!version.Equals(""))
            {
                sSql += "and upper(PRESERVE1)='";
                sSql += version.ToUpper();
                sSql += "' ";
            }
            DataTable dt;
            if (dbAccess.GetDataTable(sSql, out dt, out err))
            {
                return dt;
            }
            return null;
        }
        public DataTable LoadDocFiles(ourFile file, string shipId)
        {
            string err;
            string sSql = "";

            sSql = "SELECT T_FILE_MANAGE.FILE_ID, T_FILE_MANAGE.OBJECT_ID, T_FILE_MANAGE.FILE_NAME, T_FILE_MANAGE.FSIZE, T_FILE_MANAGE.OBJECT_LABEL,";
            sSql += " T_FILE_MANAGE.CREATE_DATE, T_FILE_MANAGE.UPDATE_DATE, T_FILE_MANAGE.CREATOR, T_FILE_MANAGE.DOCTYPE_ID,";
            sSql += " T_FILE_MANAGE.VERSION, T_FILE_MANAGE.REF_EQUIPMENT, T_FILE_MANAGE.FILE_TYPE, T_FILE_MANAGE.REF_FILEID,";
            sSql += " T_FILE_MANAGE.PRESERVE1, T_FILE_MANAGE.PRESERVE2, T_FILE_MANAGE.SHIP_ID, '' TYPE_NAME";
            sSql += " FROM T_FILE_MANAGE ";
            sSql += " WHERE (T_FILE_MANAGE.REF_FILEID = '";
            sSql += file.FileId + "')";
            if (shipId != null && shipId.Trim().Length > 0)
                sSql += " AND (T_FILE_MANAGE.SHIP_ID = '" + shipId + "')";

            DataTable dt;
            if (dbAccess.GetDataTable(sSql, out dt, out err))
            {
                return dt;
            }
            return null;
        }
        public void updateFileSizeAndDate(string blobid, string file)
        {
            FileInfo ofile = new FileInfo(file);
            List<string> sqls = new List<string>();
            long size = ofile.Length;
            string sql = "update T_FILE_MANAGE set FSIZE=" + size.ToString() + ",UPDATE_DATE=getdate() where lower(OBJECT_ID)='" + blobid.ToLower() + "'";
            string err;
            sqls.Add(sql);
            sql = "UPDATE T_FILE_REF set FILE_ID= t2.file_id from t_file_ref t1 inner join t_file_manage t2 on t1.file_id = t2.file_id where lower(t2.object_id) = '" + blobid.ToLower() + "'";
            sqls.Add(sql);
            dbAccess.ExecSql(sqls, out err);
        }
        #endregion

        #region 删除无用的大文档对象
        public void deleteUnusedObject(string db, string lobdb)
        {
            //string sql;
            //string err;
            //sql = "delete from " + lobdb + ".dbo.T_FILEINFO where " + lobdb + ".dbo.T_FILEINFO.OBJECT_ID not in ";
            //sql+=" (select "+db+".dbo.T_FILE_MANAGE.OBJECT_ID from "+db+".dbo.T_FILE_MANAGE)";
            //dbAccess.ExecSql(sql,out err);
        }
        #endregion
    }
}
