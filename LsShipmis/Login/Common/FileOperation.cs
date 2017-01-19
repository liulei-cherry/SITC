using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Login.Services;
using System.IO;
using System.Xml;
using System.Diagnostics;

namespace Login
{
    public class FileOperation
    {
        FileDbService fileDbService = FileDbService.Instance;
        private SqlServerAccess dbAccess = new SqlServerAccess(ConstParameter.DBConnectString);
        private SqlServerAccess lobdbAccess = new SqlServerAccess(ConstParameter.LobDBConnectString);

        public delegate void OperationPercent(int percent, string whichStep);
        public OperationPercent UpdateFilesPercent;
        public OperationPercent DownLoadFilesPercent;

        #region 下载文件

        /// <summary>
        /// 下载最新版本.
        /// </summary>
        /// <param name="dtServer">服务端表内容</param>
        /// <param name="dtClient">客户端表内容</param>
        /// <returns>True成功，False失败</returns>
        public bool DownLoadLastVersion(DataTable dtServer, DataTable dtClient, out string errMessage)
        {
            #region 强制删除运行的主程序（zhangy-2013-10-12）
            string procName = "LSShipMis_" + ConstParameter.ShipOfLand;
            if ((Process.GetProcessesByName(procName)).Length > 0)
            {
                int processId = Process.GetCurrentProcess().Id;
                foreach (Process tempProcess in Process.GetProcessesByName(procName))
                {
                    if (tempProcess.Id != processId)
                        tempProcess.Kill();
                }
            }
            #endregion

            errMessage = "";

            bool returnValue = true;

            #region 按MD5对Table排序
            //对服务端Table排序.
            DataView dvServer = dtServer.DefaultView;
            dvServer.Sort = "FileMD5 ASC";
            dtServer = dvServer.ToTable();

            //对客户端Table排序.
            DataView dvClient = dtClient.DefaultView;
            dvClient.Sort = "FileMD5 ASC";
            dtClient = dvClient.ToTable();
            #endregion

            #region 创建Table
            DataTable dtTempVersionTable = new DataTable();
            dtTempVersionTable.Columns.Add("AutoUpdateFileID", Type.GetType("System.String"));
            dtTempVersionTable.Columns.Add("OBJECT_ID", Type.GetType("System.String"));
            dtTempVersionTable.Columns.Add("FileVsersionNo", Type.GetType("System.String"));
            dtTempVersionTable.Columns.Add("FileName", Type.GetType("System.String"));
            dtTempVersionTable.Columns.Add("FileMD5", Type.GetType("System.String"));
            dtTempVersionTable.Columns.Add("FilePath", Type.GetType("System.String"));
            #endregion

            #region 准备下载的数据


            int rowServerCount = dtServer.Rows.Count;
            int rowClientCount = dtClient.Rows.Count;
            if (rowServerCount > rowClientCount)
            {
                //存在新加入的文件.
                DataRow[] drs;
                for (int i = 0; i < rowServerCount; i++)
                {
                    drs = dtClient.Select("FileName='" + ReplaceSqlKeyStr(dtServer.Rows[i]["FileName"].ToString()) + "'");
                    if (drs.Length == 0)
                    {
                        //没有检索到数据，说明是新文件.
                        DataRow drServer = dtServer.Rows[i];//得到当前行.
                        dtTempVersionTable.Rows.Add(drServer.ItemArray);
                    }
                    else if (drs.Length > 0)
                    {
                        //找到文件，需要比较MD5
                        drs = dtClient.Select("FileMD5='" + dtServer.Rows[i]["FileMD5"].ToString() + "'");
                        if (drs.Length == 0)
                        {
                            DataRow drServer = dtServer.Rows[i];//得到当前行.
                            dtTempVersionTable.Rows.Add(drServer.ItemArray);
                        }

                    }
                }
            }
            else if (rowServerCount < rowClientCount)
            {
                //有文件被删除了.
                DataRow[] drs;
                for (int i = 0; i < rowClientCount; i++)
                {
                    string fileName = string.Empty;
                    try
                    {
                        fileName = dtServer.Rows[i]["FileName"].ToString();
                    }
                    catch { continue; }

                    drs = dtServer.Select("FileName='" + ReplaceSqlKeyStr(fileName) + "'");

                    if (drs == null && drs.Length == 0)
                    {
                        //文件被删除.
                        //TODO 需要删除文件.
                    }
                    else if (drs.Length > 0)
                    {
                        //找到文件，需要比较MD5
                        drs = dtServer.Select("FileMD5='" + dtServer.Rows[i]["FileMD5"].ToString() + "'");
                        if (drs.Length == 0)
                        {
                            //MD5发送变化.
                            for (int j = 0; j < rowServerCount; j++)
                            {
                                //名称一致但MD5发生变化的数据端数据.
                                DataRow[] drsN = dtServer.Select("FileName='" + ReplaceSqlKeyStr(dtClient.Rows[i]["FileName"].ToString()) + "'");
                                DataRow drServer = drsN[0];
                                dtTempVersionTable.Rows.Add(drServer.ItemArray);
                            }
                        }
                    }
                }
            }
            else
            {
                //数据数目相同.
                //排序完毕可以直接比较.
                for (int i = 0; i < rowServerCount; i++)
                {
                    if (dtServer.Rows[i]["FileMD5"].ToString() != dtClient.Rows[i]["FileMD5"].ToString())
                    {
                        DataRow drServer = dtServer.Rows[i];

                        dtTempVersionTable.Rows.Add(drServer.ItemArray);
                    }
                }
            }
            #endregion

            #region 下载DLL
            int newRowCount = dtTempVersionTable.Rows.Count;
            for (int i = 0; i < newRowCount; i++)
            {
                string strMd5 = dtTempVersionTable.Rows[i]["FileMD5"].ToString();
                //大文件ID
                string object_id = dtTempVersionTable.Rows[i]["OBJECT_ID"].ToString();
                //保存路径和文件名称.
                string strPathAndName = Application.StartupPath + "\\Update\\" + dtTempVersionTable.Rows[i]["FileName"].ToString();
                //检查文件是否存在.
                if (!File.Exists(strPathAndName))
                {
                    if (DownLoadFilesPercent != null)
                    {
                        DownLoadFilesPercent((int)((i + 1) * 98 / newRowCount), "正在下载[" + strPathAndName + "]");
                        Application.DoEvents();
                    }

                    if (!FileDbService.Instance.GetABlobByBlodId(object_id, strPathAndName))
                    {
                        errMessage = dtTempVersionTable.Rows[i]["FileName"].ToString() + "文件下载失败，请重试！";
                        return false;
                    }
                }
                else
                {
                    //虽然文件存在可能是个下载一半的坏文件.
                    //检查MD5是否正确.
                    if (MD5Function.MD5Stream(strPathAndName) != strMd5)
                    {
                        if (DownLoadFilesPercent != null)
                        {
                            DownLoadFilesPercent((int)((i + 1) * 98 / newRowCount), "正在下载[" + strPathAndName + "]");
                            Application.DoEvents();
                        }

                        //文件MD5不一致还得下载.
                        if (!FileDbService.Instance.GetABlobByBlodId(object_id, strPathAndName))
                        {
                            errMessage = dtTempVersionTable.Rows[i]["FileName"].ToString() + "文件下载失败，请重试！";
                            return false;
                        }
                    }
                }
            }
            #endregion

            #region 移动全部文件

            for (int i = 0; i < newRowCount; i++)
            {
                try
                {
                    //需要日志记录.
                    FileInfo fileInfo = new FileInfo(Application.StartupPath + "\\Update\\" + dtTempVersionTable.Rows[i]["FileName"].ToString());
                    if (dtTempVersionTable.Rows[i]["FilePath"].ToString() == "\\")
                    {
                        string filePathAndName = Application.StartupPath + "\\" + fileInfo.Name;
                        FileInfo fileD = new FileInfo(filePathAndName);
                        fileD.Delete();
                        fileInfo.CopyTo(filePathAndName, true);
                    }
                    else
                    {
                        string filePathAndName = Application.StartupPath + "\\" + dtTempVersionTable.Rows[i]["FilePath"].ToString() + "\\" + fileInfo.Name;
                        FileInfo fileD = new FileInfo(filePathAndName);
                        fileD.Delete();

                        DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "\\" + dtTempVersionTable.Rows[i]["FilePath"].ToString());
                        if (!dir.Exists) dir.Create();
                        fileInfo.CopyTo(filePathAndName, true);
                    }
                }
                catch (Exception e)
                {
                    errMessage = e.Message;
                }
            }
            FileInfo xmlFile = new FileInfo(Application.StartupPath + "\\Update\\AutoUpdate" + ConstParameter.ShipOfLand + ".xml");
            xmlFile.CopyTo(Application.StartupPath + "\\AutoUpdate" + ConstParameter.ShipOfLand + ".xml", true);
            #endregion

            #region 删除全部文件
            if (DownLoadFilesPercent != null)
            {
                DownLoadFilesPercent(95, "删除临时文件！");
                Application.DoEvents();
            }
            //检测记录文件方可删除.
            for (int i = 0; i < newRowCount; i++)
            {
                FileInfo fileInfo = new FileInfo(Application.StartupPath + "\\Update\\" + dtTempVersionTable.Rows[i]["FileName"].ToString());
                fileInfo.Delete();
            }
            //删除升级的XML文件.
            FileInfo xmlFileInfo = new FileInfo(Application.StartupPath + "\\Update\\AutoUpdate" + ConstParameter.ShipOfLand + ".xml");
            xmlFileInfo.Delete();

            DirectoryInfo dirInfo = new DirectoryInfo(Application.StartupPath + "\\Update");
            FileInfo[] fileInfos = dirInfo.GetFiles();
            foreach (FileInfo fileModel in fileInfos)
            {
                fileModel.Delete();
            }
            #endregion

            if (DownLoadFilesPercent != null)
            {
                DownLoadFilesPercent(99, "正在结束下载最新版本信息！");
                Application.DoEvents();
            }
            return returnValue;
        }
        #endregion

        #region 上传文件
        /// <summary>
        /// 上传文件，区分第一次使用和后继版本更新.
        /// 如果数据库不存在版本信息则为第一次使用.
        /// 如果数据库存在版本信息则为后继升级.
        /// </summary>
        /// <param name="isOneUpLoad">是否一次上传True表示一次性</param>
        /// <param name="errMessage">错误信息</param>
        /// <returns>true成功 false</returns>
        public bool UpLoadLastVersion(bool isOneUpLoad, out string errMessage)
        {
            errMessage = "";
            string strExePath = Application.StartupPath;
            string strClinetXmlPathAndName = strExePath + "\\AutoUpdate" + ConstParameter.ShipOfLand + ".xml";
            FileVersionInfo myFileVersion = FileVersionInfo.GetVersionInfo(strExePath + "\\LSShipMis_" + ConstParameter.ShipOfLand + ".exe");
            String strFileVersion = string.Format("{0}.{1}.{2}.{3}", myFileVersion.FileMajorPart, myFileVersion.FileMinorPart, myFileVersion.FileBuildPart, myFileVersion.FilePrivatePart);
            DataSet dsLocal = new DataSet();
            if (!File.Exists(strClinetXmlPathAndName))
                CreateXmlFile(strClinetXmlPathAndName, strFileVersion);
            else
            {
                //规避本地错误版本.
                //一律以程序主版本为主.
                FileInfo fileInfo = new FileInfo(strClinetXmlPathAndName);
                fileInfo.Delete();
                CreateXmlFile(strClinetXmlPathAndName, strFileVersion);
                //dsLocal.ReadXml(strClinetXmlPathAndName);
                //strFileVersion = dsLocal.Tables[0].Rows[0]["Version"].ToString();
            }

            #region 一次性上传

            if (isOneUpLoad)
            {
                WriteLog(DateTime.Now.ToString() + "一次性上传文件开始！");

                #region

                #region 删除xml多余数据
                XmlDocument xmlDeleteDoc = new XmlDocument();
                xmlDeleteDoc.Load(strClinetXmlPathAndName);
                XmlNode xmlMainNode = xmlDeleteDoc.SelectSingleNode("Main");
                XmlNodeList xmlNodeList = xmlDeleteDoc.SelectNodes("Main/AutoUpdateFile");
                foreach (XmlNode node in xmlNodeList)
                {
                    xmlMainNode.RemoveChild(node);
                }
                xmlDeleteDoc.Save(strClinetXmlPathAndName);
                #endregion

                //本地文件名称和路径.
                List<FileProperty> filePro = new List<FileProperty>();
                DirectoryInfo DirectoryModel = new DirectoryInfo(strExePath);
                filePro = GetDirAndFileName(DirectoryModel, 0, filePro);
                List<string> sqlList = new List<string>();
                string strAutoUpdateID = Guid.NewGuid().ToString();//主表主键.
                //更新XML主表信息.
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(strClinetXmlPathAndName);
                XmlNode xmlNode = xmlDoc.SelectSingleNode("Main/AutoUpdateVersion");
                xmlNode["AutoUpdateID"].InnerText = strAutoUpdateID;
                xmlNode["Version"].InnerText = strFileVersion;
                xmlDoc.Save(strClinetXmlPathAndName);
                string strVersion = string.Format(@"INSERT INTO dbo.T_AutoUpdateVersion(AutoUpdateID, VersionNo, IsValid, 
                                                  EffectiveStartTime, CreateDate, OBJECT_ID)
                                                  VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')",
                                                  strAutoUpdateID, strFileVersion, 1, DateTime.Now, DateTime.Now, "");
                sqlList.Add(strVersion);
                int fileCount = filePro.Count;
                for (int i = 0; i < fileCount; i++)
                {
                    if (UpdateFilesPercent != null)
                    {
                        UpdateFilesPercent((int)((i + 1) * 98 / fileCount), "正在上传[" + filePro[i].FullPath + "]");
                        Application.DoEvents();
                    }
                    string sAutoUpdateFileID = Guid.NewGuid().ToString();
                    string sTempBlobId;
                    if (fileDbService.InsertABlob(filePro[i].FullPath, out sTempBlobId))
                    {
                        string strFile = string.Format(@"INSERT INTO  dbo.T_AutoUpdateFile (AutoUpdateFileID, OBJECT_ID, FileVsersionNo, FileName, FileMD5, FilePath)
                                                    VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')",
                                                    sAutoUpdateFileID, sTempBlobId, "1.0.0.0", ReplaceSqlKeyStr(filePro[i].FileName), MD5Function.MD5Stream(filePro[i].FullPath), filePro[i].FolderName);
                        sqlList.Add(strFile);
                    }
                    //关系表数据.
                    string strRelation = string.Format(@"INSERT INTO dbo.T_AutoRelation (RelationID, AutoUpdateID, AutoUpdateFileID)
                                                        VALUES ('{0}','{1}','{2}')", Guid.NewGuid(), strAutoUpdateID, sAutoUpdateFileID);

                    sqlList.Add(strRelation);

                    #region xml数据更新
                    XmlDocument xmlDocFile = new XmlDocument();
                    xmlDocFile.Load(strClinetXmlPathAndName);

                    XmlNode AutoUpdateFile = xmlDocFile.CreateElement("AutoUpdateFile");

                    XmlNode AutoUpdateFileID = xmlDocFile.CreateElement("AutoUpdateFileID");
                    XmlNode OBJECT_ID = xmlDocFile.CreateElement("OBJECT_ID");
                    XmlNode FileVsersionNo = xmlDocFile.CreateElement("FileVsersionNo");
                    XmlNode FileName = xmlDocFile.CreateElement("FileName");
                    XmlNode FileMD5 = xmlDocFile.CreateElement("FileMD5");
                    XmlNode FilePath = xmlDocFile.CreateElement("FilePath");

                    AutoUpdateFileID.InnerText = sAutoUpdateFileID;
                    AutoUpdateFile.AppendChild(AutoUpdateFileID);

                    OBJECT_ID.InnerText = sTempBlobId;
                    AutoUpdateFile.AppendChild(OBJECT_ID);

                    FileVsersionNo.InnerText = "1.0.0.0";
                    AutoUpdateFile.AppendChild(FileVsersionNo);

                    FileName.InnerText = filePro[i].FileName;
                    AutoUpdateFile.AppendChild(FileName);

                    FileMD5.InnerText = MD5Function.MD5Stream(filePro[i].FullPath);
                    AutoUpdateFile.AppendChild(FileMD5);
                    if (filePro[i].FolderName == "\\")
                    {
                        FilePath.InnerText = filePro[i].FolderName;
                    }
                    else
                    { FilePath.InnerText = "\\" + filePro[i].FolderName; }
                    AutoUpdateFile.AppendChild(FilePath);
                    xmlDocFile.DocumentElement.AppendChild(AutoUpdateFile);
                    xmlDocFile.Save(strClinetXmlPathAndName);
                    #endregion
                }
                string strErr;
                if (dbAccess.ExecSql(sqlList, out strErr))
                {

                    //上传本地修正的XML文件.
                    string sTempBlobId;
                    if (fileDbService.InsertABlob(strClinetXmlPathAndName, out sTempBlobId))
                    {
                        //更新XML主表信息.
                        XmlDocument xmlDocObject = new XmlDocument();
                        xmlDocObject.Load(strClinetXmlPathAndName);
                        XmlNode xmlNodeObject = xmlDocObject.SelectSingleNode("Main/AutoUpdateVersion");
                        xmlNodeObject["OBJECT_ID"].InnerText = sTempBlobId;
                        xmlDocObject.Save(strClinetXmlPathAndName);
                        //需要更新下数据库的XML文件.
                        if (fileDbService.UpdateABlob(sTempBlobId, strClinetXmlPathAndName))
                        {
                            string strXMLFile = string.Format(@"UPDATE dbo.T_AutoUpdateVersion
                                                            SET OBJECT_ID='{0}'
                                                            WHERE AutoUpdateID='{1}' ",
                                                                sTempBlobId, strAutoUpdateID);
                            if (dbAccess.ExecSql(strXMLFile, out strErr))
                            {
                                if (UpdateFilesPercent != null)
                                {
                                    UpdateFilesPercent(99, "正在结束更新服务器最新版本信息");
                                    Application.DoEvents();
                                }
                                WriteLog(DateTime.Now.ToString() + "一次性上传文件完毕！");
                                return true;

                            }
                            else
                            {
                                errMessage = strErr;
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    errMessage = strErr;
                    return false;
                }
                #endregion

                return true;
            }
            #endregion

            #region 部分上传
            else
            {
                WriteLog(DateTime.Now.ToString() + "部分上传文件开始！");

                #region 删除xml多余数据
                XmlDocument xmlDeleteDoc = new XmlDocument();
                xmlDeleteDoc.Load(strClinetXmlPathAndName);
                XmlNode xmlMainNode = xmlDeleteDoc.SelectSingleNode("Main");
                XmlNodeList xmlNodeList = xmlDeleteDoc.SelectNodes("Main/AutoUpdateFile");
                foreach (XmlNode node in xmlNodeList)
                {
                    xmlMainNode.RemoveChild(node);
                }
                xmlDeleteDoc.Save(strClinetXmlPathAndName);
                #endregion

                #region 本地文件名

                //本地文件名称和路径.
                List<FileProperty> filePro = new List<FileProperty>();
                DirectoryInfo DirectoryModel = new DirectoryInfo(strExePath);
                filePro = GetDirAndFileName(DirectoryModel, 0, filePro);
                List<string> sqlList = new List<string>();
                #endregion

                #region 检测版本号
                string strAutoUpdateID = Guid.NewGuid().ToString();//主表主键.
                //检测版本号是否存在.
                string versionExitsSql = string.Format(@"SELECT AutoUpdateID FROM dbo.T_AutoUpdateVersion WHERE VersionNo='{0}'", strFileVersion);
                string sAutoUpdateID = dbAccess.GetString(versionExitsSql);
                //不存在则插入.
                if (string.IsNullOrEmpty(sAutoUpdateID))
                {
                    string strVersion = string.Format(@"INSERT INTO dbo.T_AutoUpdateVersion(AutoUpdateID, VersionNo, IsValid, 
                                                  EffectiveStartTime, CreateDate, OBJECT_ID) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')",
                                              strAutoUpdateID, strFileVersion, 1, DateTime.Now, DateTime.Now, "");
                    sqlList.Add(strVersion);
                }
                else
                {
                    //数据库内的ID
                    strAutoUpdateID = sAutoUpdateID;
                }
                #endregion

                #region 更新XML主表信息

                //更新XML主表信息.
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(strClinetXmlPathAndName);
                XmlNode xmlNode = xmlDoc.SelectSingleNode("Main/AutoUpdateVersion");
                xmlNode["AutoUpdateID"].InnerText = strAutoUpdateID;
                xmlNode["Version"].InnerText = strFileVersion;
                xmlDoc.Save(strClinetXmlPathAndName);
                #endregion

                int fileCount = filePro.Count;
                for (int i = 0; i < fileCount; i++)
                {
                    #region 检测文件是否上传过

                    //检测文件是否上传过.
                    //上传过关联自动加关系.
                    //未上传过需要上传并且增加关系.
                    DataTable dtMd5 = new DataTable();
                    string fileMd5 = MD5Function.MD5Stream(filePro[i].FullPath);
                    string strSqlMd5 = string.Format(@"SELECT AutoUpdateFileID,OBJECT_ID FROM dbo.T_AutoUpdateFile WHERE FileMD5='{0}'", fileMd5);
                    if (dbAccess.GetDataTable(strSqlMd5, out dtMd5, out errMessage))
                    {
                        //文件已经上传过.
                        if (dtMd5.Rows.Count > 0)
                        {
                            if (UpdateFilesPercent != null)
                            {
                                UpdateFilesPercent((int)((i + 1) * 98 / fileCount), "自动关联[" + filePro[i].FullPath + "]");
                                Application.DoEvents();
                            }
                            string strRelation = string.Format(@"INSERT INTO dbo.T_AutoRelation (RelationID, AutoUpdateID, AutoUpdateFileID)
                                                        VALUES ('{0}','{1}','{2}')", Guid.NewGuid(), strAutoUpdateID, dtMd5.Rows[0][0]);
                            sqlList.Add(strRelation);

                            #region xml数据更新
                            XmlDocument xmlDocFile = new XmlDocument();
                            xmlDocFile.Load(strClinetXmlPathAndName);

                            XmlNode AutoUpdateFile = xmlDocFile.CreateElement("AutoUpdateFile");

                            XmlNode AutoUpdateFileID = xmlDocFile.CreateElement("AutoUpdateFileID");
                            XmlNode OBJECT_ID = xmlDocFile.CreateElement("OBJECT_ID");
                            XmlNode FileVsersionNo = xmlDocFile.CreateElement("FileVsersionNo");
                            XmlNode FileName = xmlDocFile.CreateElement("FileName");
                            XmlNode FileMD5 = xmlDocFile.CreateElement("FileMD5");
                            XmlNode FilePath = xmlDocFile.CreateElement("FilePath");

                            AutoUpdateFileID.InnerText = dtMd5.Rows[0][0].ToString();
                            AutoUpdateFile.AppendChild(AutoUpdateFileID);

                            OBJECT_ID.InnerText = dtMd5.Rows[0][1].ToString();//ID
                            AutoUpdateFile.AppendChild(OBJECT_ID);

                            FileVsersionNo.InnerText = "1.0.0.0";
                            AutoUpdateFile.AppendChild(FileVsersionNo);

                            FileName.InnerText = filePro[i].FileName;
                            AutoUpdateFile.AppendChild(FileName);

                            FileMD5.InnerText = MD5Function.MD5Stream(filePro[i].FullPath);
                            AutoUpdateFile.AppendChild(FileMD5);
                            if (filePro[i].FolderName == "\\")
                            {
                                FilePath.InnerText = filePro[i].FolderName;
                            }
                            else
                            { FilePath.InnerText = "\\" + filePro[i].FolderName; }
                            AutoUpdateFile.AppendChild(FilePath);
                            xmlDocFile.DocumentElement.AppendChild(AutoUpdateFile);
                            xmlDocFile.Save(strClinetXmlPathAndName);
                            #endregion

                        }
                        else
                        {
                            if (UpdateFilesPercent != null)
                            {
                                UpdateFilesPercent((int)((i + 1) * 98 / fileCount), "正在上传[" + filePro[i].FullPath + "]");
                                Application.DoEvents();
                            }
                            //是个新文件.
                            string sAutoUpdateFileID = Guid.NewGuid().ToString();
                            string sTempBlobId;
                            if (fileDbService.InsertABlob(filePro[i].FullPath, out sTempBlobId))
                            {
                                string strFile = string.Format(@"INSERT INTO  dbo.T_AutoUpdateFile (AutoUpdateFileID, OBJECT_ID, FileVsersionNo, FileName, FileMD5, FilePath)
                                                    VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')",
                                                sAutoUpdateFileID, sTempBlobId, "1.0.0.0", ReplaceSqlKeyStr(filePro[i].FileName),
                                                MD5Function.MD5Stream(filePro[i].FullPath), filePro[i].FolderName);
                                sqlList.Add(strFile);
                            }
                            //关系表数据.
                            string strRelation = string.Format(@"INSERT INTO dbo.T_AutoRelation (RelationID, AutoUpdateID, AutoUpdateFileID)
                                                        VALUES ('{0}','{1}','{2}')", Guid.NewGuid(), strAutoUpdateID, sAutoUpdateFileID);

                            sqlList.Add(strRelation);

                            #region xml数据更新
                            XmlDocument xmlDocFile = new XmlDocument();
                            xmlDocFile.Load(strClinetXmlPathAndName);

                            XmlNode AutoUpdateFile = xmlDocFile.CreateElement("AutoUpdateFile");

                            XmlNode AutoUpdateFileID = xmlDocFile.CreateElement("AutoUpdateFileID");
                            XmlNode OBJECT_ID = xmlDocFile.CreateElement("OBJECT_ID");
                            XmlNode FileVsersionNo = xmlDocFile.CreateElement("FileVsersionNo");
                            XmlNode FileName = xmlDocFile.CreateElement("FileName");
                            XmlNode FileMD5 = xmlDocFile.CreateElement("FileMD5");
                            XmlNode FilePath = xmlDocFile.CreateElement("FilePath");

                            AutoUpdateFileID.InnerText = sAutoUpdateFileID;
                            AutoUpdateFile.AppendChild(AutoUpdateFileID);

                            OBJECT_ID.InnerText = sTempBlobId;
                            AutoUpdateFile.AppendChild(OBJECT_ID);

                            FileVsersionNo.InnerText = "1.0.0.0";
                            AutoUpdateFile.AppendChild(FileVsersionNo);

                            FileName.InnerText = filePro[i].FileName;
                            AutoUpdateFile.AppendChild(FileName);

                            FileMD5.InnerText = MD5Function.MD5Stream(filePro[i].FullPath);
                            AutoUpdateFile.AppendChild(FileMD5);
                            if (filePro[i].FolderName == "\\")
                            {
                                FilePath.InnerText = filePro[i].FolderName;
                            }
                            else
                            { FilePath.InnerText = "\\" + filePro[i].FolderName; }
                            AutoUpdateFile.AppendChild(FilePath);
                            xmlDocFile.DocumentElement.AppendChild(AutoUpdateFile);
                            xmlDocFile.Save(strClinetXmlPathAndName);
                            #endregion
                        }
                    }
                    #endregion
                }
                //事物处理.
                if (dbAccess.ExecSql(sqlList, out errMessage))
                {
                    //上传本地修正的XML文件.
                    string sTempBlobId;
                    if (fileDbService.InsertABlob(strClinetXmlPathAndName, out sTempBlobId))
                    {
                        #region 更新XML主表信息
                        //更新XML主表信息.
                        XmlDocument xmlDocObject = new XmlDocument();
                        xmlDocObject.Load(strClinetXmlPathAndName);
                        XmlNode xmlNodeObject = xmlDocObject.SelectSingleNode("Main/AutoUpdateVersion");
                        xmlNodeObject["OBJECT_ID"].InnerText = sTempBlobId;
                        xmlDocObject.Save(strClinetXmlPathAndName);
                        #endregion

                        #region 更新数据库中XML文件
                        if (fileDbService.UpdateABlob(sTempBlobId, strClinetXmlPathAndName))
                        {
                            string strXMLFile = string.Format(@"UPDATE dbo.T_AutoUpdateVersion
                                                            SET OBJECT_ID='{0}' WHERE AutoUpdateID='{1}' ",
                                                        sTempBlobId, strAutoUpdateID);
                            if (dbAccess.ExecSql(strXMLFile, out errMessage))
                            {
                                if (UpdateFilesPercent != null)
                                {
                                    UpdateFilesPercent(99, "正在结束更新服务器最新版本信息");
                                    Application.DoEvents();
                                }
                                WriteLog(DateTime.Now.ToString() + "部分上传文件结束！");
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                        #endregion
                    }
                }
                else
                {
                    return false;
                }

                return true;
            }
            #endregion
        }
        #endregion

        #region 递归获取指定路径下所有文件夹名称和文件名称和绝对路径
        /// <summary>
        /// 获取指定路径下所有文件夹名称和文件名称和绝对路径.
        /// </summary>
        /// <param name="directoryModel"></param>
        /// <param name="nLevel"></param>
        /// <param name="fileList"></param>
        /// <returns></returns>
        public List<FileProperty> GetDirAndFileName(DirectoryInfo directoryModel, int nLevel, List<FileProperty> fileList)
        {
            DirectoryInfo[] dirInfos = directoryModel.GetDirectories();//目录下所有目录.
            if (nLevel == 0)
            {
                FileInfo[] fileDirList = directoryModel.GetFiles();//根目录下所有文件.
                foreach (FileInfo fileInfo in fileDirList)
                {
                    FileProperty propertyModel = new FileProperty();
                    if (fileInfo.Name != "AutoUpdate" + ConstParameter.ShipOfLand + ".xml")
                    {
                        if (fileInfo.Name != "Login.exe")
                        {
                            propertyModel.FolderName = "\\";
                            propertyModel.FileName = fileInfo.Name;
                            propertyModel.FullPath = directoryModel.FullName + "\\" + fileInfo.Name;
                            //是文件正常.
                            System.IO.File.SetAttributes(propertyModel.FullPath, System.IO.FileAttributes.Normal);
                            fileList.Add(propertyModel);
                        }
                    }
                }
            }
            //其他目录下的文件.
            foreach (DirectoryInfo dirinfo in dirInfos)
            {
                //过滤升级文件夹.
                if (dirinfo.Name != "Update")
                {
                    FileInfo[] fileInfos = dirinfo.GetFiles(); //目录下的文件.
                    foreach (FileInfo fileInfo in fileInfos)
                    {
                        FileProperty fileProperty = new FileProperty();
                        //过滤升级程序.
                        if (fileInfo.Name != "Login.exe")
                        {
                            fileProperty.FileName = fileInfo.Name;
                            fileProperty.FolderName = dirinfo.Name;
                            fileProperty.FullPath = dirinfo.FullName + "\\" + fileInfo.Name;
                            //是文件正常.
                            System.IO.File.SetAttributes(fileProperty.FullPath, System.IO.FileAttributes.Normal);
                            fileList.Add(fileProperty);
                        }
                    }
                    fileList = GetDirAndFileName(dirinfo, nLevel + 1, fileList);
                }
            }
            return fileList;
        }

        public class FileProperty
        {
            /// <summary>
            /// 文件夹名称.
            /// </summary>
            public string FolderName
            {
                get;
                set;
            }
            /// <summary>
            /// 文件名称.
            /// </summary>
            public string FileName
            {
                get;
                set;
            }
            /// <summary>
            /// 绝对路径.
            /// </summary>
            public string FullPath
            {
                get;
                set;
            }
        }
        #endregion

        #region 日志处理
        /// <summary>
        /// 上传日志写入到TXT文件内.
        /// </summary>
        /// <param name="logPath">文件路径</param>
        /// <param name="logMessage">文件消息</param>
        public void WriteLog(string logMessage)
        {
            string logPath = Application.StartupPath + "\\Update\\Log";
            DirectoryInfo dir = new DirectoryInfo(logPath);
            if (!dir.Exists) dir.Create();
            FileStream fs;
            string file = logPath + "\\landseashipmislog.txt";
            if (File.Exists(file))
            {
                fs = new FileStream(file, FileMode.Open, FileAccess.ReadWrite);
            }
            else
            {
                fs = new FileStream(file, FileMode.Create, FileAccess.Write);
            }
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.GetEncoding("GB2312"));//通过指定字符编码方式可以实现对汉字的支持，否则在用记事本打开查看会出现乱码.
            sw.Flush();
            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.WriteLine(logMessage);
            sw.Flush();
            sw.Close();
        }
        #endregion

        #region SQL注入
        public string ReplaceSqlKeyStr(string ReplacedStr)
        {
            if (string.IsNullOrEmpty(ReplacedStr)) return "";
            //sqlserver 关键字是' 应该提换成''
            ReplacedStr = ReplacedStr.Replace("'", "''");
            return ReplacedStr;
        }
        #endregion

        #region 依据客户端提供的XML文件上传XZB

        /// <summary>
        /// 上传根目录下所有文件.
        /// 不包括更新程序和Update文件夹.
        /// 也可按照客户端的XML表结构遍历需要上传的内容.
        /// </summary>
        /// <param name="Version">客户端XML表结构</param>
        /// <param name="dt">客户端XML表结构</param>
        /// <returns>true成功，false失败</returns>
        public bool UpLoadLastVersion(OneVersion localVersion, DataTable dt, out string err)
        {
            err = "";
            string path = Application.StartupPath;
            //找到本地的xml,得到本地的对象.
            FileInfo localfile = new FileInfo(path + @"\AutoUpdate" + ConstParameter.ShipOfLand + ".xml");
            if (!localfile.Exists)
            {
                err = "没有找到本地的AutoUpdate" + ConstParameter.ShipOfLand + ".xml,请确认本地的文件已经齐全";
                return false;
            }
            //判断数据库中是否有此version,有则更新,无则插入.
            OneVersion dbVersion;
            if (!OneVersionService.Instance.getDBHaveThisVersion(localVersion.VersionNo, out dbVersion))
            {
                dbVersion = localVersion;
                if (!dbVersion.Update(out err))
                {
                    err = "当前版本文件信息保存数据库过程失败,错误信息为:\r\n" + err;
                    return false;
                }
            }
            int allCount = dt.Rows.Count;
            //用一个字典记录所有上传的文件以及其id,未将来处理数据使用.
            Dictionary<int, string> allFilesAndId = new Dictionary<int, string>();
            //需要上传的均先上传子文件,然后更新语法一起执行.
            //对比数据库的文件及版本号,判断是否要上传各子文件.
            for (int i = 0; i < allCount; i++)
            {
                string md5Temp = dt.Rows[i]["FileMD5"].ToString();
                string fileName = dt.Rows[i]["FileName"].ToString();
                string relativePath = dt.Rows[i]["FilePath"].ToString() + "\\" + fileName;
                string fileFullPath = path + relativePath;

                if (UpdateFilesPercent != null)
                {
                    UpdateFilesPercent((int)((i + 1) * 98 / allCount), "正在上传[" + relativePath + "]");
                    Application.DoEvents();
                }
                //先判断本地文件是否存在,
                FileInfo fileTemp = new FileInfo(fileFullPath);
                if (!fileTemp.Exists)
                {
                    err = "未发现本地应存在的[" + relativePath + "]文件,无法进行服务器版本升级工作!";
                    return false;
                }
                //本地文件是否是这个md5
                if (!MD5Function.MD5Stream(fileFullPath).Equals(md5Temp))
                {
                    err = "本地的[" + relativePath + "]文件发生变化,可能是破解程序或其它恶意程序破坏所致,/r/n无法进行后续升级工作!";
                    return false;
                }
                string dbFileId;
                //判断服务器上是否有这个文件.
                if (OneVersionService.Instance.getDBHaveOneBlobOfNameAndMD5(fileName, md5Temp, out dbFileId))
                {
                    //存在,则加一个外键关联即可.
                    if (!OneVersionService.Instance.RelationAFileWithOtherFileId(dbVersion.AutoUpdateID, dbFileId, out err))
                        return false;
                }
                else
                {
                    if (allFilesAndId.ContainsKey(i))
                    {
                        continue;
                    }
                    string sTempBlobId;
                    //上传到服务器,并获取一个blobid
                    if (!fileDbService.InsertABlob(fileFullPath, out sTempBlobId) || string.IsNullOrEmpty(sTempBlobId))
                    {
                        err = "上传[" + relativePath + "]文件到服务器时出错!";
                        return false;
                    }
                    allFilesAndId.Add(i, sTempBlobId);
                }
            }
            if (UpdateFilesPercent != null)
            {
                UpdateFilesPercent(99, "正在结束更新服务器最新版本信息");
                Application.DoEvents();
            }
            if (allFilesAndId.Count > 0)
            {
                //更新链接的文件不算,上传的所有文件需要建立相应的file子表信息;
                for (int i = 0; i < allCount; i++)
                {
                    if (!allFilesAndId.ContainsKey(i)) continue;
                    if (!OneVersionService.Instance.RelationAFileWithBlobID(dbVersion.AutoUpdateID, allFilesAndId[i],
                        dt.Rows[i]["FileVsersionNo"].ToString(), dt.Rows[i]["FileName"].ToString(), dt.Rows[i]["FileMD5"].ToString(),
                        dt.Rows[i]["FilePath"].ToString(), out err))
                    {
                        err = "更新服务器最新版本文件状态时出错,错误信息为:\r" + err;
                        return false;
                    }
                }
            }
            string xmlDBId;
            //上传xml文件并更新数据库的主表.
            if (!fileDbService.InsertABlob(localfile.FullName, out xmlDBId) || string.IsNullOrEmpty(xmlDBId))
            {
                err = "上传[" + localfile.FullName + "]文件到服务器时出错!";
                return false;
            }
            dbVersion.OBJECT_ID = xmlDBId;
            if (!dbVersion.Update(out err))
            {
                err = "当前版本文件信息保存数据库过程失败,错误信息为:\r\n" + err;
                return false;
            }
            return true;
        }
        #endregion

        #region 创建XML

        public void CreateXmlFile(string filePathAndName, string strVersion)
        {
            XmlTextWriter xmlWriter = new XmlTextWriter(filePathAndName, null);
            xmlWriter.Formatting = Formatting.Indented;
            xmlWriter.WriteStartElement("Main");
            //主表的创建.
            xmlWriter.WriteStartElement("AutoUpdateVersion");
            xmlWriter.WriteElementString("AutoUpdateID", "XZB");
            xmlWriter.WriteElementString("OBJECT_ID", "XZB");
            xmlWriter.WriteElementString("IsValid", "1");
            xmlWriter.WriteElementString("Version", strVersion);
            xmlWriter.WriteElementString("CreateDate", DateTime.Now.ToString());
            xmlWriter.WriteElementString("EffectiveStartTime", DateTime.Now.ToString());
            xmlWriter.WriteEndElement();
            //子表的创建.
            xmlWriter.WriteStartElement("AutoUpdateFile");
            xmlWriter.WriteElementString("AutoUpdateFileID", "XZB");
            xmlWriter.WriteElementString("OBJECT_ID", "XZB");
            xmlWriter.WriteElementString("FileVsersionNo", "XZB");
            xmlWriter.WriteElementString("FileName", "XZB");
            xmlWriter.WriteElementString("FileMD5", "XZB");
            xmlWriter.WriteElementString("FilePath", "XZB");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.Flush();
            xmlWriter.Close();
        }
        #endregion

        #region 检查升级主表是否存在
        /// <summary>
        /// 检查升级主表是否存在
        /// </summary>
        /// <param name="errMessage">错误消息</param>
        /// <returns>false失败，可能不存失败可能创建失败。True主表存在可能是创建的也可能是存在的</returns>
        public bool CheckVersionTableExits(out string errMessage)
        {
            bool returnValue = false;
            errMessage = "";
            string sContent = "";
            string strAutoUpdateVersion = string.Format("SELECT NAME FROM sysobjects WHERE NAME='T_AutoUpdateVersion'");

            if (dbAccess.GetString(strAutoUpdateVersion, out sContent, out errMessage))
            {
                if (String.IsNullOrEmpty(sContent))
                {
                    string createAutoUpdateVersion = string.Format(@"CREATE TABLE dbo.T_AutoUpdateVersion (
                                                                    AutoUpdateID CHAR(36) Primary KEY  NOT NULL,
                                                                    OBJECT_ID CHAR(36) NOT NULL,
                                                                    VersionNo VARCHAR(20) NOT NULL,
                                                                    IsValid NUMERIC(1,0) NOT NULL DEFAULT 1,
                                                                    EffectiveStartTime DATETIME DEFAULT GETDATE(),
                                                                    CreateDate DATETIME DEFAULT GETDATE())");
                    if (dbAccess.ExecSql(createAutoUpdateVersion, out errMessage))
                    {
                        return true;//创建成功表示存在
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                    returnValue = true;//表存在
            }
            return returnValue;
        }
        #endregion

        #region 检查升级文件表是否存在
        /// <summary>
        /// 检查升级文件表是否存在
        /// </summary>
        /// <param name="errMessage"></param>
        /// <returns></returns>
        public bool CheckFileTableExits(out string errMessage)
        {
            bool returnValue = false;
            errMessage = "";
            string sContent = "";

            string strAutoUpdateFile = string.Format("SELECT NAME FROM sysobjects WHERE NAME='T_AutoUpdateFile'");
            if (dbAccess.GetString(strAutoUpdateFile, out sContent, out errMessage))
            {
                if (String.IsNullOrEmpty(sContent))
                {
                    string createAutoUpdateVersion = string.Format(@"CREATE TABLE dbo.T_AutoUpdateFile (
                                                                    AutoUpdateFileID CHAR(36) Primary KEY  NOT NULL,
                                                                    OBJECT_ID  CHAR(36) NOT NULL,
                                                                    FileVsersionNo VARCHAR(30),
                                                                    FileName VARCHAR(100),
                                                                    FileMD5 VARCHAR(100),
                                                                    FilePath VARCHAR(300),
                                                                    CreateDate DATETIME DEFAULT GETDATE())");
                    if (dbAccess.ExecSql(createAutoUpdateVersion, out errMessage))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                    returnValue = true;//表存在
            }
            return returnValue;
        }
        #endregion

        #region 检查升级关系表是否存在
        /// <summary>
        /// 检查升级关系表是否存在
        /// </summary>
        /// <param name="errMessage"></param>
        /// <returns></returns>
        public bool CheckRelationTableExits(out string errMessage)
        {
            bool returnValue = false;
            errMessage = "";
            string sContent = "";

            string strAutoRelation = string.Format("SELECT NAME FROM sysobjects WHERE NAME='T_AutoRelation'");

            if (dbAccess.GetString(strAutoRelation, out sContent, out errMessage))
            {
                if (String.IsNullOrEmpty(sContent))
                {
                    string createAutoUpdateVersion = string.Format(@"CREATE TABLE dbo.T_AutoRelation (
                                                                    RelationID CHAR(36) Primary KEY  NOT NULL,
                                                                    AutoUpdateID  CHAR(36) NOT NULL,
                                                                    AutoUpdateFileID  CHAR(36) NOT NULL,
                                                                    foreign key(AutoUpdateID) references T_AutoUpdateVersion(AutoUpdateID),
                                                                    foreign key(AutoUpdateFileID) references T_AutoUpdateFile(AutoUpdateFileID))");
                    if (dbAccess.ExecSql(createAutoUpdateVersion, out errMessage))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                    returnValue = true;//表存在
            }
            return returnValue;
        }
        #endregion
    }
}
