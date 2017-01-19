using System; 
using System.Collections; 
using System.Data;
using System.Net;
using System.IO;
using System.Threading; 

namespace CommonOperation.Functions
{
    //实现文件的上下传等功能的web操作类.
    public class WebOperation
    {
        private WebClient client = new WebClient(); 
        /// <summary>
        /// 下载一个文件.
        /// </summary>
        /// <param name="url">文件地址</param>
        /// <param name="filename">保存的文件名</param>
        /// <param name="filedir">保存到本地的地址</param>
        /// <param name="err">错误信息</param>
        /// <returns>是否成功</returns>
        public bool DownloadFile(string url,string filename,out string filedir,out string err)
        {
            err = "";     
            filedir = "d:\\ShipMisFiles\\FileOperation\\" + Guid.NewGuid().ToString();
            try
            {
                Directory.CreateDirectory(filedir);
            }
            catch (System.UnauthorizedAccessException unauthorizedAccessException)
            {
                
                err = "用户无权限随机形成目录,必须指定可操作目录进行文件保存.\r\n" + unauthorizedAccessException.Message;
                return false;
            }
            catch (Exception e)
            {
                err = e.Message;
                return false;
            }
            filedir = filedir + "\\" + filename;
            return downloadFile(url, filedir, out err);
        }
        /// <summary>
        /// 下载一个文件,并保存到指定的位置,
        /// 如果没有会自动建立,如果有了会覆盖掉,如果建立不成功会返回失败.
        /// </summary>
        /// <param name="url">文件地址</param>
        /// <param name="saveFiledir">主动给一个保存本地</param>
        /// <param name="err">错误信息</param>
        /// <returns>是否成功</returns>
        public bool DownloadFile(string url, string saveFiledir, out string err)
        {
            FileInfo f = new FileInfo(saveFiledir);
            if (!Directory.Exists(f.DirectoryName))
            {
                try
                {
                    Directory.CreateDirectory(f.DirectoryName);
                }
                catch (System.UnauthorizedAccessException unauthorizedAccessException)
                {
                    err = "用户无权限随机形成目录,必须指定可操作目录进行文件保存.\r\n" + unauthorizedAccessException.Message;
                    return false;
                }
                catch (Exception e)
                {
                    err = e.Message;
                    return false;
                }
            }
            return downloadFile(url, saveFiledir, out err);
        }
 
        /// <summary>
        /// 下载一个文件,并保存到指定的位置,
        /// 如果没有会自动建立,如果有了会覆盖掉,如果建立不成功会返回失败.
        /// private方法,调用前已经保证filedir有效.
        /// </summary>
        /// <param name="url">文件地址</param>
        /// <param name="saveFiledir">主动给一个保存本地</param>
        /// <param name="err">错误信息</param>
        /// <returns>是否成功</returns>
        private bool downloadFile(string URLAddress, string saveFiledir, out string err)
        {
            err = "";
            FileInfo f = new FileInfo ( saveFiledir);
            
            string fileName = f.Name;           
            try
            {
                WebRequest myre = WebRequest.Create(URLAddress);
            }
            catch (WebException exp)
            {
                err = exp.Message;
                return false;
            }

            try
            { 
                client.DownloadFile(URLAddress, fileName);
                Stream str = client.OpenRead(URLAddress);
                StreamReader reader = new StreamReader(str);
                byte[] mbyte = new byte[50000000];
                int allmybyte = (int)mbyte.Length;
                int startmbyte = 0; 
                while (allmybyte > 0)
                {
                    int m = str.Read(mbyte, startmbyte, allmybyte);
                    if (m == 0)
                        break;

                    startmbyte += m;
                    allmybyte -= m;
                }

                FileStream fstr = new FileStream(saveFiledir, FileMode.OpenOrCreate, FileAccess.Write);
                fstr.Write(mbyte, 0, startmbyte);
                str.Close();
                fstr.Close();
            }
            catch (WebException exp)
            {
                err = exp.Message;
                return false;
            }
            return true;
        }
    }
}