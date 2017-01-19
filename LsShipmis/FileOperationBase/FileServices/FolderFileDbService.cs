using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using FileOperationBase.Services;
using CommonOperation.Enum;

namespace FileOperationBase.FileServices
{
    public class FolderFileDbService
    {

        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static FolderFileDbService instance = new FolderFileDbService();
        public static FolderFileDbService Instance
        {
            get
            {
                if (null == instance)
                {
                    FolderFileDbService.instance = new FolderFileDbService();
                }
                return FolderFileDbService.instance;
            }
        }
        private FolderFileDbService()
        { }
        #endregion

        private IDBAccess lobdbAccess = InterfaceInstantiation.NewADbAccess(true);
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();

        public bool IfFolderHasTheFile(string folderId, string fileName, out string fileId)
        {
            string err;
            fileId = "";
            if (string.IsNullOrEmpty(folderId) || string.IsNullOrEmpty(fileName))
                return false;

            string sSql = "select t2.[file_id],t2.[object_id] from dbo.T_FILE_REF t1 inner join dbo.T_FILE_MANAGE t2 on t1.[file_id] = t2.[file_id]"
            + "\rwhere upper(t1.node_id) = '" + folderId.ToUpper() + "' and t2.[file_name] = N'" + dbOperation.ReplaceSqlKeyStr(fileName) + "'";
            DataTable dt;
            if (dbAccess.GetDataTable(sSql, out dt, out err))
            {
                if (dt.Rows.Count > 0 && dt.Rows[0][0] != null && dt.Rows[0][1] != null)
                {
                    fileId = dt.Rows[0][0].ToString();
                    sSql = "select 1 from T_FILEINFO where upper([object_id]) = '" + dt.Rows[0][1].ToString() + "'";

                    return !string.IsNullOrEmpty(lobdbAccess.GetString(sSql));
                }
            }
            return false;
        }

        public bool IfFolderAndSubfolderHaveTheFile(string folderId, string fileName, out string findFolderId, out string fileId, out string err)
        {
            fileId = "";
            findFolderId = "";
            string sql = "with allSubFolderAndFileID as (select t.node_id from dbo.t_folder t where t.node_id = '" + folderId + "'"
                        + "\runion all select  t_folder.node_id from t_folder,allSubFolderAndFileID where PARENT_NODE_ID = allSubFolderAndFileID.node_id)"
                        + "\rselect t1.node_id,t3.file_id from allSubFolderAndFileID t1 inner join t_file_ref t2 on t1.node_id = t2.node_id "
                        + "\rinner join t_file_manage t3 on t2.file_id = t3.file_id where file_name = N'" + dbOperation.ReplaceSqlKeyStr(fileName) + " '";
            DataTable dt;
            if (!dbAccess.GetDataTable(sql, out dt, out err) || dt == null || dt.Rows.Count == 0)
                return false;            
            fileId = dt.Rows[0][1].ToString();
            findFolderId = dt.Rows[0][0].ToString();
            return true;
        }

        //文件引用操作.
        public bool refFiles(string folderId, List<string> fileId, out string err)
        {
            err = "";
            string sSql = "";
            List<string> sqls = new List<string>();
            string sql;

            sql = "select SHIP_ID from T_FOLDER where upper(NODE_ID)='" + folderId.ToUpper() + "'";
            string targetShipId = dbAccess.GetString(sql);
            sql = "select NODE_TYPE from T_FOLDER where upper(NODE_ID)='" + folderId.ToUpper() + "'";
            int folderType = Convert.ToInt32(dbAccess.GetString(sql));

            foreach (string item in fileId)
            {
                sSql = "select id from T_FILE_REF where upper(node_id)='" + folderId.ToUpper() + "' and upper(file_id)='" + item.ToUpper() + "'";
                DataTable dt;
                if (dbAccess.GetDataTable(sSql, out dt, out err) && dt.Rows.Count == 0)
                {
                    sql = "select SHIP_ID from T_FILE_MANAGE where upper(FILE_ID)='" + item.ToUpper() + "'";
                    string fileShipId = dbAccess.GetString(sql);

                    sql = "select FILE_TYPE from T_FILE_MANAGE where upper(FILE_ID)='" + item.ToUpper() + "'";
                    string fileType = dbAccess.GetString(sql);
                    //这里可以实现为,拷贝过来另一个版本的文件.
                    if ((folderType >= 5000) && !fileType.Equals("DOT"))
                    {
                        err = "模板类型的文件夹不允许引用普通的文件！";
                        return false;
                    }

                    if (targetShipId.Trim() == fileShipId.Trim())
                    {
                        sSql = "insert into T_FILE_REF(ID,NODE_ID,FILE_ID) ";
                        sSql += "values('";
                        sSql += Guid.NewGuid().ToString();
                        sSql += "','";
                        sSql += folderId;
                        sSql += "','";
                        sSql += item;
                        sSql += "') ";
                        sqls.Add(sSql);
                    }
                    else
                    {
                        List<string> filess = new List<string>();
                        filess.Add(item);
                        distributeFiles(folderId, filess, out err);
                    }

                    //sSql = "update T_File_manage set UPDATE_DATE = " + EnvironmentParm.DbSysdate + " where upper(file_id)='" + item.ToUpper() + "'";
                    //sqls.Add(sSql);
                }
            }
            return dbAccess.ExecSql(sqls, out err);
        }

        /// <summary>
        /// 文件下发.
        /// </summary>
        /// <param name="folderId">目标文件夹id</param>
        /// <param name="fileId">下发的文件id</param>
        /// <param name="err">输出错误</param>
        /// <returns></returns>
        public bool distributeFiles(string folderId, List<string> fileId, out string err)
        {
            string sql;
            err = "";
            sql = "select SHIP_ID from T_FOLDER where upper(NODE_ID)='" + folderId.ToUpper() + "'";
            string targetShipId = dbAccess.GetString(sql);

            sql = "select NODE_TYPE from T_FOLDER where upper(NODE_ID)='" + folderId.ToUpper() + "'";
            int folderType = Convert.ToInt32(dbAccess.GetString(sql));
            string fileType = "DOC";
            if (folderType >= 5000)
            {
                fileType = "DOT";
            }
            foreach (string file in fileId)
            {
                sql = "select OBJECT_ID from T_FILE_MANAGE where upper(FILE_ID)='" + file.ToUpper() + "'";
                string blobid = dbAccess.GetString(sql);
                string newblobId = Guid.NewGuid().ToString();
                sql = "insert into t_fileinfo select '" + newblobId + "',object_con_blob from t_fileinfo where upper(object_id)='" + blobid.ToUpper() + "'";

                if (lobdbAccess.ExecSql(sql, out err))
                {
                    List<string> strings = new List<string>();
                    //插入t_filemanage表.
                    string fileManageId = Guid.NewGuid().ToString();
                    sql = "INSERT INTO [T_FILE_MANAGE] select '" + fileManageId + "','" + newblobId + "',[FILE_NAME],[FSIZE],[OBJECT_LABEL],[CREATE_DATE],[UPDATE_DATE],[CREATOR],[DOCTYPE_ID]," +
                        " [REF_EQUIPMENT],[VERSION],'" + fileType + "',[REF_FILEID],[PRESERVE1],[PRESERVE2],'" + targetShipId + "'" + "from T_FILE_MANAGE where upper(FILE_ID)='" + file.ToUpper() + "'";
                    strings.Add(sql);
                    sql = "insert into T_FILE_REF(ID,NODE_ID,FILE_ID) values('" + Guid.NewGuid().ToString() + "','" + folderId + "','" + fileManageId + "')";
                    strings.Add(sql);
                    if (!dbAccess.ExecSql(strings, out err))
                    { return false; }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 删除文件.
        /// </summary>
        public bool DeleteAFile(string nodeId, string fileId, out string err)
        {
            err = "";
            List<string> listSql = new List<string>();
            ourFile ourFile;
            if (!FileDbService.Instance.GetAFileById(fileId, out ourFile))
            {
                err = "无此文件！";
                return false;
            }

            //判断是否要删除大文本.
            string sSelectSql = "";
            sSelectSql += "select file_id from T_FILE_MANAGE where OBJECT_ID in (select OBJECT_ID from T_FILE_MANAGE where upper(file_id)='";
            sSelectSql += fileId.ToUpper();
            sSelectSql += "') ";

            string refSql = "select file_id from T_FILE_REF where  upper(FILE_ID)='";
            refSql += fileId.ToUpper() + "'";

            DataTable dtb;

            if (!dbAccess.GetDataTable(sSelectSql, out dtb, out err) || dtb == null)
            {
                return false;
            }
            DataTable refdtb;

            if (!dbAccess.GetDataTable(refSql, out refdtb, out err) || refdtb == null)
            {
                return false;
            }
            if ((dtb.Rows.Count == 1) && (refdtb.Rows.Count <= 1))
            {
                listSql.Add(FileDbService.Instance.DeleteAFile(fileId));
                if (!lobdbAccess.ExecSql(FileDbService.Instance.DeleteABlob(ourFile.Object_id), out err))
                {
                    return false;
                }
            }
            string tmpSql = "delete from t_file_ref where upper(FILE_ID)='";
            tmpSql += fileId.ToUpper();
            tmpSql += "' and upper(node_id)='";
            tmpSql += (nodeId == null ? "" : nodeId.ToUpper()) + "'";
            listSql.Add(tmpSql);

            return dbAccess.ExecSql(listSql, out err);
        }

        /// <summary>
        /// 移动文件.
        /// </summary>
        public bool MoveFile(string sourceFolder, string targetFolder, string fileId, out string err)
        {
            err = "";
            string sSql = "";
            sSql += "update T_FILE_REF set NODE_ID='";
            sSql += targetFolder;
            sSql += "' where upper(FILE_ID)='";
            sSql += fileId.ToUpper();
            sSql += "' and upper(NODE_ID)='";
            sSql += sourceFolder.ToUpper();
            sSql += "' ";
            return dbAccess.ExecSql(sSql, out err);
        }

        /// <summary>
        /// 根据文件夹id得到文件的列表.
        /// </summary>
        public DataTable GetFileByFolder(string folderId)
        {
            //EnvironmentParm.IsLobOpt = true;//设置操作Lob库的环境变量.
            DataTable fileDataTable;
            fileDataTable = new DataTable();
            if (folderId == null) return null;
            string sSql = "";
            string err = "";
            sSql += "select distinct(a.file_id),a.OBJECT_ID,a.FILE_NAME,a.FSIZE,a.OBJECT_LABEL,a.CREATE_DATE, " +
                "a.UPDATE_DATE,a.CREATOR,a.DOCTYPE_ID,'' TYPE_NAME,a.REF_EQUIPMENT,a.VERSION,a.FILE_TYPE, " +
                "a.REF_FILEID,a.PRESERVE1,a.PRESERVE2,a.SHIP_ID from T_FILE_MANAGE a inner join T_FILE_REF c on c.FILE_ID=a.FILE_ID " +
                "where upper(c.NODE_ID)='";
            sSql += folderId.ToUpper();
            sSql += "' ";
            sSql += " order by a.FILE_NAME ";

            if (!dbAccess.GetDataTable(sSql, out fileDataTable, out err))
            {
                fileDataTable = null;
            }
            return fileDataTable;
        }

        //根据文件id得到文件所在文件夹的id
        public string GetFolderIdByFileId(string fileId)
        {
            string sSql = "";
            string err;
            sSql = "select NODE_ID from T_FILE_REF where upper(FILE_ID)='";
            sSql += fileId.ToUpper();
            sSql += "' ";

            DataTable dtb;
            if (!dbAccess.GetDataTable(sSql, out dtb, out err) || dtb.Rows.Count == 0)
            {
                return "";
            }
            return dtb.Rows[0][0].ToString();
        }

        /// <summary>
        /// rootType为节点的类型值，改写为每次点击后递归查询.
        /// </summary>
        /// <param name="rootId"></param>
        /// <returns></returns>
        public DataTable GetFolderTree(string ParentNode, bool onlyIsm)
        {

            DataTable tab;
            string sSql = "";
            string err;

            sSql = "SELECT T_FOLDER.NODE_ID, T_FOLDER.NODE, T_FOLDER.PARENT_NODE_ID, T_FOLDER.FSORT, T_FOLDER.NODE_TYPE, T_FOLDER.SHIP_ID ";
            sSql += " FROM T_FOLDER ";
            sSql += " WHERE T_FOLDER.PARENT_NODE_ID='"+ParentNode + "'" ;
            sSql += (onlyIsm ? " and NODE_TYPE>=5000" : " and NODE_TYPE<5000");
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                sSql += " and (T_FOLDER.SHIP_ID is null or ltrim(T_FOLDER.SHIP_ID) = '' or T_FOLDER.SHIP_ID in "
                   + "(select ship_id from T_USER_SHIP where userid = '" + CommonOperation.ConstParameter.UserId + "'))";
            } 
            sSql += " ORDER BY NODE_TYPE,T_FOLDER.NODE";
            sSql = sSql.Replace("=''", " is null ");
            if (!dbAccess.GetDataTable(sSql, out tab, out err))
            {
                tab = null;
            }
            return tab;
        }

        //返回系统的不同操作者.
        public DataTable Operator()
        {
            string err;
            DataTable dtb;
            string sSql = "select distinct CREATOR,CREATOR from T_FILE_MANAGE ";
            if (!dbAccess.GetDataTable(sSql, out dtb, out err))
            {
                dtb = null;
            }
            return dtb;
        }
        //不同操作者的视图.
        public DataTable operatorView(string operatorName)
        {
            operatorName = operatorName.Trim();
            DataTable dtb;
            string sSql = "select distinct(a.file_id),a.OBJECT_ID,a.file_NAME,a.FSIZE,a.OBJECT_LABEL," +
               " a.CREATE_DATE,a.UPDATE_DATE,a.CREATOR,a.DOCTYPE_ID,'' TYPE_NAME,a.REF_EQUIPMENT,a.PRESERVE1," +
               " a.PRESERVE2,a.version,a.FILE_TYPE,a.REF_FILEID,a.SHIP_ID\rfrom T_FILE_MANAGE a " +
               " inner join T_FILE_REF c on c.FILE_ID=a.FILE_ID where ";
            sSql += " upper(a.CREATOR)='";
            sSql += operatorName.ToUpper();
            sSql += "' ";
            sSql += "\rorder by a.file_NAME";
            string err;
            if (!dbAccess.GetDataTable(sSql, out dtb, out err))
            {
                dtb = null;
            }
            return dtb;
        }

        /// <summary>
        /// xuzb 2014年1月9日增加函数，提供机务常用表格的维护目录。
        /// </summary>
        /// <returns></returns>
        public ourFolder GetEngineerFrequentlyUsingForm()
        {
            //得到目录为“机务经理常用报表”且类型为普通，排序第的记录，
            ourFolder theRootFolder = FolderDbService.Instance.getFolderByFolderType(FileBoundingTypes.COMMONFILESROOT);
            return FolderDbService.Instance.getOrCreateSubFolderByName(theRootFolder, "机务常用表格维护");        
        }

        public DataTable GetISMTemplateFile(string folderId)
        {
            string sSql = "";
            string err = "";
            sSql += "select a.file_id,a.OBJECT_ID,a.file_NAME,a.FSIZE,a.OBJECT_LABEL,a.CREATE_DATE,a.UPDATE_DATE,a.CREATOR,a.DOCTYPE_ID, '' TYPE_NAME,a.REF_EQUIPMENT,a.PRESERVE1,a.PRESERVE2,a.version,a.FILE_TYPE,a.REF_FILEID,a.SHIP_ID from T_FILE_MANAGE a inner join T_FILE_REF c on c.FILE_ID=a.FILE_ID where upper(c.NODE_ID)='";
            sSql += folderId.ToUpper();
            sSql += "' ";
            sSql += "and upper(a.FILE_TYPE)='DOT'  order by a.file_NAME";

            DataTable dtb;
            if (dbAccess.GetDataTable(sSql, out dtb, out err))
            {
                return dtb;
            }
            return null;

        }

        /// <summary>
        /// 在知道要加入节点id的时候,使用此方法.
        /// </summary>
        /// <param name="folder">目录对象</param>
        /// <param name="file">文件对象,必须预先定义好,如果有modelid,必须在此对象中维护</param>
        /// <param name="fileAddress">文件地址</param>
        /// <param name="err">返回错误信息</param>
        /// <returns>是否操作成功</returns>
        public bool InsertAFile(ourFolder folder, ourFile file, string fileAddress, out string err)
        {
            //如果folder不存在,则建立.
            if (FolderDbService.Instance.UpdateAFolder(folder, out err))
            {
                return InsertAFile(folder.NodeId, file, fileAddress, out err);
            }
            else return false;
        }
  
        /// <summary>
        /// 在知道要加入节点id的时候,使用此方法.
        /// </summary>
        /// <param name="nodeId">目录id</param>
        /// <param name="file">文件对象,必须预先定义好,如果有modelid,必须在此对象中维护</param>
        /// <param name="fileAddress">文件地址</param>
        /// <param name="err">返回错误信息</param>
        /// <returns>是否操作成功</returns>
        public bool InsertAFile(string nodeId, ourFile file, string fileAddress, out string err)
        {
            err = "";
            string sSql = "";
            string fileId;

            if (!FileDbService.Instance.InsertAFile(file, fileAddress, out fileId, out err))
            {
                return false;
            }

            sSql = "insert into T_FILE_REF(ID,NODE_ID,FILE_ID) ";
            sSql += "values(newid() ,'" + nodeId + "','" + fileId + "') ";
            if (dbAccess.ExecSql(sSql, out err))
            {
                file.FileId = fileId;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 把一个文件放到指定文件夹的下面.
        /// 在不知道要加入节点的id,但是知道其相关信息时,使用此方法.
        /// </summary>       
        /// <param name="theType">文件(夹)类型</param> 
        /// <param name="usingMoreFolder">是否使用子目录,注意使用子目录时的排序号依然不能小于主目录的排序号</param>
        /// <param name="folderName">目录名称,当上一个参数为true时有效</param>
        /// <param name="file">文件对象,必须预先定义好,如果有modelid,必须在此对象中维护</param>
        /// <param name="fileAddress">文件地址</param>
        /// <param name="err">返回错误信息</param>
        /// <returns>是否操作成功</returns>
        public bool InsertAFile(FileBoundingTypes theType, bool usingMoreFolder, string folderName, string folderId, ourFile file, string fileAddress, out string err)
        {
            ourFolder theFolder = null;
            if (!string.IsNullOrEmpty(folderId))
            {
                theFolder = FolderDbService.Instance.getFolderByFolderID(folderId);
                if (theFolder != null && theFolder.NodeName != folderName)
                {
                    theFolder.NodeName = folderName;
                    //这里即使出错也不返回,因为不是多大的问题,只不过不能改名而已.
                    FolderDbService.Instance.UpdateAFolder(theFolder, out err);
                }
            }
            if (theFolder == null)
            {
                theFolder = FolderDbService.Instance.getFolderByFolderType(theType, file.ShipId);
                if (usingMoreFolder)
                {
                    ourFolder tempFolder = FolderDbService.Instance.getOrCreateSubFolderByNameAndId(theFolder, folderName, folderId);
                    if (tempFolder != null) theFolder = tempFolder;
                }
            }
            if (theFolder != null)
                return InsertAFile(theFolder.NodeId, file, fileAddress, out err);
            else
            {
                err = "无法获取准确的目录信息,未能将文件插入数据库";
                return false;
            }
        }
    }
}