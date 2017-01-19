using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.IO;
using FileOperationBase.FileServices;
using CommonOperation;

namespace FileOperationBase.Services
{
    public enum right { C, R, U, D };
    public class openFile
    {
        private string fileName;
        //private right oRight;
        //private ourFile oFile;
        //public ourFolder oFolder;
        //打开文件.
        [DllImport("kernel32.dll")]
        public static extern int WinExec(string exeName, int operType);


        public void FileOpen(ourFile theFile, right Right)
        {
            if (theFile == null) return;
            string file;
            if (!FileDbService.Instance.GetABolbByFileId(theFile.FileId, out file)) return;
            FileInfo ofile = new FileInfo(file);

            //如果不是只读权限，则允许修改，监控文件的修改，子过程去判断是新增文件还是修改文件.
            //if (Right != right.R)
            //{
                DelayedFileSystemWatcher watch = new DelayedFileSystemWatcher();
                watch.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;
                watch.Path = ofile.DirectoryName;
                watch.EnableRaisingEvents = true;

                watch.Filter = ofile.Name;
                fileName = ofile.Name;

                watch.Changed += new FileSystemEventHandler(watch_Changed);
                watch.Renamed += new RenamedEventHandler(watch_Renamed);
            //}
            Tools.FileOpen(file);
        }

        public void FileOpen(ourFile theFile, right Right, string nodeId, string shipId)
        {
            //如果是根据模板文件创建体系文件，则先另存后再打开.
            if (right.C == Right)
            {
                FileOpen(CopyFile(theFile, nodeId, shipId), right.U);
            }
        }

        /// <summary>
        /// 方法重构，返回新建的文件.
        /// </summary>
        /// <param name="theFile"></param>
        /// <param name="Right"></param>
        /// <param name="nodeId"></param>
        /// <param name="shipId"></param>
        public ourFile FileOpenWithReturn(ourFile theFile, right Right, string nodeId, string shipId)
        {
            //如果是根据模板文件创建体系文件，则先另存后再打开.
            if (right.C == Right)
            {
                ourFile tmpFile;
                tmpFile = CopyFile(theFile, nodeId, shipId);
                FileOpen(tmpFile, right.U);
                return tmpFile;
            }
            else
            {
                return null;
            }
        }

        //拷贝文件并返回.
        private ourFile CopyFile(ourFile theFile, string nodeId, string shipId)
        {
            //从数据库获取文件.
            string file;
            if (!FileDbService.Instance.GetABolbByFileId(theFile.FileId, out file)) return null;
            FileInfo ofile = new FileInfo(file);    //文件.
            string ext = ofile.Extension;           //扩展名.
            string filePath = ofile.DirectoryName;  //路径.
            string err;

            //新文件名.
            string newFileName = ofile.Name.Substring(0, ofile.Name.Length - ext.Length) + "_" + string.Format("{0:yyyy_MM_dd}", DateTime.Now) + "_" + CommonOperation.ConstParameter.UserName + ext;
            //拷贝成临时文件.
            File.Copy(ofile.FullName, filePath + @"\" + newFileName);
            //构造新插入的文件。.
            ourFile tmpFile = new ourFile();
            tmpFile.Creator = CommonOperation.ConstParameter.UserName;
            tmpFile.File_Type = "DOC";

            tmpFile.FileName = newFileName;
            tmpFile.ObjectLabel = theFile.ObjectLabel;
            tmpFile.Preserve1 = theFile.Preserve1;
            tmpFile.Preserve2 = theFile.Preserve2;
            tmpFile.Ref_Fileid = theFile.FileId;
            tmpFile.RefEquipment = theFile.RefEquipment;
            tmpFile.ShipId = shipId;
            if (shipId == "")
                tmpFile.ShipId = null;
            tmpFile.Size = ofile.Length;
            if (FolderFileDbService.Instance.InsertAFile(nodeId, tmpFile, filePath + @"\" + newFileName, out err))
            {
                return tmpFile;
            }
            else
            {
                return null;
            }
        }
        //监视非独占程序的修改.
        void watch_Changed(object sender, FileSystemEventArgs e)
        {
            monitor_file(sender, e.FullPath);
        }
        //监视独占程序的修改.
        void watch_Renamed(object sender, RenamedEventArgs e)
        {
            monitor_file(sender, e.FullPath);
        }

        void monitor_file(object sender, string file)
        {
            FileInfo ofile = new FileInfo(file);
            string filePath = ofile.DirectoryName;
            string objectId = filePath.Substring(filePath.Length - 36);
            string ext = new FileInfo(fileName).Extension;

            FileInfo tmpFile = new FileInfo(filePath + @"\" + fileName);
            string tmpname = Guid.NewGuid().ToString() + ext;
            if (ext.ToLower() != ".tmp" && ofile.Name[0] != '~')
            {
                try
                {
                    System.IO.File.Copy(file, filePath + @"\" + tmpname, true);
                    FileDbService.Instance.UpdateABlob(objectId, filePath + @"\" + tmpname);
                    FileInfo delFile = new FileInfo(filePath + @"\" + tmpname);
                    delFile.Delete();
                }
                catch { }
            }
        }
    }
}
