using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using FileOperationBase.FileServices;
namespace FileOperationBase.Services
{
    public class OutPortFolderFiles
    {
        static string err = "";
        public static void GetFolders(ourFolder folder, string path)
        {
            //判断当前path下是否有folder.name文件夹,如果有,获取文件夹对象,没有,创建.
            string theFolder = ReplaceStr(folder.NodeName);
            //根据当前folder,取它下面的文件.
            string vpath = path + "\\" + theFolder;
            DirectoryInfo dicinfo = new DirectoryInfo(vpath);
            if (!dicinfo.Exists)
            {
                dicinfo.Create();
            }

            DataTable dt = FolderFileDbService.Instance.GetFileByFolder(folder.NodeId);
            foreach (DataRow row in dt.Rows)
            {
                string fileid = row["file_id"].ToString();
                string filename = row["FILE_NAME"].ToString();
                if (filename.Trim().Length > 0)
                {
                    try
                    {
                        string filepath;
                        FileDbService.Instance.GetABolbByFileId(fileid, out filepath);
                        string despath = vpath + "\\" + filename;
                        FileInfo fileinfo = new FileInfo(filepath);
                        FileInfo finfo = new FileInfo(despath);
                        if (!finfo.Exists)
                        {
                            fileinfo.CopyTo(despath, true);
                        }
                    }
                    catch { }
                }
            }

            List<ourFolder> list;
            if (FolderDbService.Instance.GetSubFolders(folder, out list, out err))
            {
                foreach (ourFolder of in list)
                {
                    GetFolders(of, vpath);
                }
            }
        }
        private static string ReplaceStr(string source)
        { 
            source=source.Replace("\\","");
            source = source.Replace("/", "");
            source = source.Replace(":", "");
            source = source.Replace("*", "");
            source = source.Replace("?", "");
            source = source.Replace("\"", "");
            source = source.Replace("<", "");
            source = source.Replace(">", "");
            source = source.Replace("|", "");
            return source;
        }
    }
}
