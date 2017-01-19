using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO.Compression;

namespace CommonOperation.Functions
{ 
    /// <summary>
    /// 同步文件压缩与解压缩.
    /// </summary>
    public class FileCompress
    {
        static private string winRarExe;

        public FileCompress()
        {
            if (string.IsNullOrEmpty(winRarExe))
            {
                setWinRarExe();
            }
        }

        public void CompressFile(string sourceFile, string destinationFile)
        {
            if (!File.Exists(sourceFile)) throw new FileNotFoundException();
            FileInfo f = new FileInfo(sourceFile);
            string err;
            winRarPress(f, destinationFile, 100000000, "", false, out err);
        }

        public bool winRarPress(FileInfo curFile, int maxSendBytes, string password, bool deleteYfile, out string sErrMessage)
        {
            string compressFile = curFile.FullName.Remove(curFile.FullName.Length - curFile.Extension.Length) + ".rar";
            return winRarPress(curFile, compressFile, maxSendBytes, password, deleteYfile, out sErrMessage);
        }

        /// <summary>
        /// 使用WinRar软件压缩指定的文件（要求操作系统必须安装WinRar），.
        /// 注意压缩后的文件名后缀中包含LandSeaSynch标记，它的作用是标识当前的rar文件是系统形成的，而非用户本来的rar文件，.
        /// 这样在接收端收到文件后可根据这个标记来判断是解压缩还是不解压缩（用户本来的rar文件就不用解压缩）.
        /// </summary>
        /// <param name="winRarExe">WinRar程序名（包含所在路径）</param>
        /// <param name="curFile">要压缩的文件</param>
        /// <param name="maxSendBytes">分卷压缩值</param>
        /// <param name="sErrMessage">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public bool winRarPress(FileInfo curFile, string compressFile, int maxSendBytes, string password, bool deleteYfile, out string sErrMessage)
        {
            //声明进程对象.
            ProcessStartInfo procWinRarInfo = new ProcessStartInfo();
            Process procWinRar = new Process();
            string sCommandInfo = "";   //压缩命令信息.
            string passPart;
            if (password.Length == 0)
            {
                passPart = "";
            }
            else
            {
                passPart = "-hp" + password;
            }

            try
            {
                //设置命令参数.
                if (File.Exists(compressFile))
                {
                    try
                    {
                        (new FileInfo(compressFile)).Delete();
                    }
                    catch { }
                }
                sCommandInfo = " a " + passPart + " -v" + maxSendBytes.ToString() + " -ep -df \"" + compressFile + "\" \"" + curFile.FullName + "\" -y";
                procWinRarInfo.FileName = winRarExe;
                procWinRarInfo.Arguments = sCommandInfo;
                procWinRarInfo.WindowStyle = ProcessWindowStyle.Hidden; //隐藏显示WinRar界面.

                //执行压缩.
                procWinRar.StartInfo = procWinRarInfo;
                procWinRar.Start();
                procWinRar.WaitForExit();//等待完成后退出.

                procWinRar.Close();

                //删除临时目录.
                if (deleteYfile && File.Exists(compressFile))
                {
                    curFile.Delete();
                }

                sErrMessage = "";
                return true;
            }
            catch (Exception e)
            {
                sErrMessage = e.Message;
            }
            return false;
        }
        
        /// <summary>
        /// 使用WinRar软件解压缩指定的文件（要求操作系统必须安装WinRar）.
        /// </summary>
        /// <param name="winRarExe">WinRar程序名（包含所在路径）</param>
        /// <param name="curFile">要解压缩的文件</param>
        /// <param name="sErrMessage">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public bool winRarUnPress(FileInfo curFile, string password, out string sErrMessage)
        {
            //声明进程对象.
            ProcessStartInfo procWinRarInfo = new ProcessStartInfo();
            Process procWinRar = new Process();
            string sCommandInfo = "";   //解压缩命令信息.
            try
            {
                string passPart = "";
                if (password.Length == 0)
                {
                    passPart = "";
                }
                else
                {
                    passPart = " -hp" + password;
                }
                int tempa = curFile.Directory.GetFiles().Length;
                //设置命令参数.
                sCommandInfo = " x \"" + curFile.FullName + "\" " + curFile.DirectoryName + " -y" + passPart;
                procWinRarInfo.FileName = winRarExe;
                procWinRarInfo.Arguments = sCommandInfo;
                procWinRarInfo.WindowStyle = ProcessWindowStyle.Hidden; //隐藏显示WinRar界面.

                //执行压缩.
                procWinRar.StartInfo = procWinRarInfo;
                procWinRar.Start();
                procWinRar.WaitForExit();//等待完成后退出.

                procWinRar.Close();
                int tempb = curFile.Directory.GetFiles().Length;
                if (tempa >= tempb)
                {
                    sErrMessage = "原文件并非可解压的文件";
                    return false;
                }
                sErrMessage = "";
                return true;
            }
            catch (Exception e)
            {
                sErrMessage = e.Message;
            }
            return false;
        }

        /// <summary>
        /// 系统启动时在注册表中取WinRar程序名，如果没有安装，则将停止.
        /// </summary>
        private static void setWinRarExe()
        {
            RegistryKey registryKeyWinRar = Registry.ClassesRoot.OpenSubKey(@"WinRAR\Shell\Open\Command");
            if (registryKeyWinRar != null)
            {
                winRarExe = registryKeyWinRar.GetValue("").ToString();
                winRarExe = winRarExe.Substring(1, winRarExe.Length - 7);
                registryKeyWinRar.Close();
            }
        }

        Random a = new Random();
        /// <summary>
        /// 压缩指定目录dirSendFilePath下的所有同步文件（在压缩之前要进行备份）.
        /// </summary>
        /// <param name="winRarExe">WinRar程序名（包含所在路径）</param>
        /// <param name="dirSendFilePath">发送文件的路径</param>
        /// <param name="maxSendBytes">分卷压缩值</param>
        public void CompressFile(string winRarExetemp, DirectoryInfo dirSendFilePathtemp, int maxSendBytestemp, bool needPasstemp)
        {

            string sErrMessage = "";    //错误信息.
            string sendFileBackUp = ""; //发送文件的备份目录.

            //发送文件备份目录 = 发送文件目录 + Backup目录，如果不存在则建立，这个目录主要备份发送文件以便在发送失败并被打回后重新发送.

            sendFileBackUp = dirSendFilePathtemp.FullName + "\\Backup";
            if (Directory.Exists(sendFileBackUp) == false)
            {
                Directory.CreateDirectory(sendFileBackUp);
            }

            //取发送文件目录下的所有可发送的文件.
            FileInfo[] synchFiles = dirSendFilePathtemp.GetFiles("*.*");
            foreach (FileInfo curFile in synchFiles)
            {
                if (curFile.Name.IndexOf(".LandSeaSynch.") == -1) //对于已经是要发送的压缩文件不能再压缩（有时发送服务器连接不上从而发送不出去，这时*.LandSeaSynch.*文件还存在）.
                {
                    try
                    {
                        curFile.CopyTo(sendFileBackUp + "\\" + curFile.Name, true);//压缩前备份当前文件.
                        if (needPasstemp)
                        {
                            this.winRarPress(winRarExetemp, curFile, maxSendBytestemp, "landsea123$%^", out sErrMessage);
                        }
                        else
                        {
                            this.winRarPress(winRarExetemp, curFile, maxSendBytestemp, "", out sErrMessage);
                        }
                    }
                    catch (Exception) { }
                }
            }

            //清除发送目录下的Backup目录下的备份文件（清除10天之前的文件）.
            if (synchFiles.Length > 0)
            {
                this.clearBackup(sendFileBackUp);
            }
        }

        /// <summary>
        /// 使用WinRar软件压缩指定的文件（要求操作系统必须安装WinRar），.
        /// 注意压缩后的文件名后缀中包含LandSeaSynch标记，它的作用是标识当前的rar文件是系统形成的，而非用户本来的rar文件，.
        /// 这样在接收端收到文件后可根据这个标记来判断是解压缩还是不解压缩（用户本来的rar文件就不用解压缩）.
        /// </summary>
        /// <param name="winRarExe">WinRar程序名（包含所在路径）</param>
        /// <param name="curFile">要压缩的文件</param>
        /// <param name="maxSendBytes">分卷压缩值</param>
        /// <param name="sErrMessage">返回参数，返回一个出错信息</param>
        private bool winRarPress(string winRarExe, FileInfo curFile, int maxSendBytes, string password, out string sErrMessage)
        {
            //声明进程对象.
            ProcessStartInfo procWinRarInfo = new ProcessStartInfo();
            Process procWinRar = new Process();
            string sCommandInfo = "";   //压缩命令信息.
            string compressFile = "";   //要压缩的文件名（路径\\原文件名.扩展名.rar）.
            string passPart;
            if (password.Length == 0)
            {
                passPart = "";
            }
            else
            {
                passPart = "-hp" + password;
            }

            //为当前要压缩的文件curFile建立一个临时目录并把该文件复制到临时目录下.
            //（压缩是在该临时目录下进行的，压缩完毕后再放到发送目录下）.

            string curFilePath = curFile.DirectoryName;
            string tempRarPath = curFilePath + "\\tempRarPath\\" + (a.Next(10000) + 10000).ToString() + "\\";
            string EndingSendPath = curFilePath + "\\Sending";
            if (Directory.Exists(tempRarPath) == false)
            {
                Directory.CreateDirectory(tempRarPath);
            }
            if (Directory.Exists(EndingSendPath) == false)
            {
                Directory.CreateDirectory(EndingSendPath);
            }
            try
            {
                //把要压缩的文件移到临时目录下.
                curFile.IsReadOnly = false;//去掉文件可能存在的只读属性.

                curFile.MoveTo(tempRarPath + "\\" + curFile.Name);

                //设置命令参数.
                compressFile = tempRarPath + "\\" + curFile.Name + ".LandSeaSynch.rar";    //要压缩成的文件名=路径\\原文件名.扩展名.rar
                sCommandInfo = " a " + passPart + " -v" + maxSendBytes.ToString() + " -ep -df \"" + compressFile + "\" \"" + tempRarPath + "\\" + curFile.Name + "\" -y";
                //sCommandInfo = " a -v" + maxSendBytes.ToString() + " -ep -df \"" + compressFile + "\" \"" + tempRarPath + "\\" + curFile.Name + "\" -y";
                procWinRarInfo.FileName = winRarExe;
                procWinRarInfo.Arguments = sCommandInfo;
                procWinRarInfo.WindowStyle = ProcessWindowStyle.Hidden; //隐藏显示WinRar界面.

                //执行压缩.
                procWinRar.StartInfo = procWinRarInfo;
                procWinRar.Start();
                procWinRar.WaitForExit();//等待完成后退出.

                procWinRar.Close();

                //文件压缩完毕后把所有rar文件移到发送目录下.
                DirectoryInfo dirTempRarPath = new DirectoryInfo(tempRarPath);
                FileInfo[] tempFiles = dirTempRarPath.GetFiles("*.*");
                foreach (FileInfo tempFile in tempFiles)
                {
                    tempFile.MoveTo(EndingSendPath + "\\" + tempFile.Name);
                }
                //删除临时目录.
                Directory.Delete(tempRarPath);
                sErrMessage = "";
                return true;
            }
            catch (Exception e)
            {
                sErrMessage = e.Message;
            }
            return false;
        }

        /// <summary>
        /// 解压缩指定目录dirFilePath下的所有rar文件（除了用户本来的rar文件，根据文件后缀中是否包含LandSeaSynch标记来判断）.
        /// </summary>
        /// <param name="winRarExe">WinRar程序名（包含所在路径）</param>
        /// <param name="dirFilePath">接收文件目录</param>
        public void UnCompressFile(string winRarExetemp, DirectoryInfo dirReceFilePathtemp)
        {
            string sErrMessage = "";                        //错误信息.
            List<string> lstPartRar = new List<string>();   //存放所有被分卷压缩的文件名的集合.

            string sCurFileNoExt = "";                      //当前被分卷压缩的文件名（去掉.LandSeaSynch.part序号.rar部分）.

            FileInfo curFileNoExt = null;                   //当前被分卷压缩的文件（去掉.LandSeaSynch.part序号.rar部分）.

            //取接收目录下的tempRarPath目录，接收的文件都是临时放在该目录下，解压缩后才移到接收目录下。.

            //如果接收目录不存在，则说明没有接收到文件，直接退出.

            string tempRarPath = dirReceFilePathtemp.FullName + "\\tempRarPath";
            DirectoryInfo dirTempRarPath = new DirectoryInfo(tempRarPath);
            if (!Directory.Exists(dirTempRarPath.FullName))
            {
                dirTempRarPath.Create();
            }
            if (!Directory.Exists(dirTempRarPath.FullName))
            {
                return;
            }

            //取出dirTempRarPath目录下的所有rar文件（排除用户本来的rar文件）.

            FileInfo[] synchFiles = dirTempRarPath.GetFiles("*.LandSeaSynch.*");
            foreach (FileInfo curFile in synchFiles)
            {
                //1.对于被分卷压缩的文件的解压缩处理（避免对所有卷的重复解压）.
                if (this.isPartRarFile(curFile))
                {
                    //取去掉.LandSeaSynch.part序号.rar部分的文件名部分（不包括路径）.

                    sCurFileNoExt = curFile.Name;
                    sCurFileNoExt = sCurFileNoExt.Substring(0, sCurFileNoExt.LastIndexOf(".LandSeaSynch."));

                    //以下代码用于避免对所有卷的重复解压.

                    if (lstPartRar.Contains(sCurFileNoExt) == false)
                    {
                        lstPartRar.Add(sCurFileNoExt);
                        this.winRarUnPress(winRarExetemp, curFile, out sErrMessage);
                    }
                }
                //2.对于未被分卷压缩的文件的解压缩处理（直接解压）.

                else
                {
                    this.winRarUnPress(winRarExetemp, curFile, out sErrMessage);
                }
            }

            //删除所有已经解压缩过的rar文件.
            foreach (FileInfo curFile in synchFiles)
            {
                //取去掉.LandSeaSynch.part序号.rar部分的文件名部分（但包括路径）.

                sCurFileNoExt = curFile.FullName;
                sCurFileNoExt = sCurFileNoExt.Substring(0, sCurFileNoExt.LastIndexOf(".LandSeaSynch."));
                curFileNoExt = new FileInfo(sCurFileNoExt);

                //1.对于被分卷压缩的文件的删除处理（如果所有卷没有都到达，则不能删除当前卷）.

                if (this.isPartRarFile(curFile))
                {
                    //如果该文件名（去掉.LandSeaSynch.part序号.rar部分）不存在，则说明分卷解压没有成功，这时不能删除当前卷.
                    if (curFileNoExt.Exists)
                    {
                        try
                        {
                            curFile.Delete();//删除掉rar文件.
                        }
                        catch { }
                    }
                }
                //2.对于未被分卷压缩的文件的删除处理（直接删除）.
                else
                {
                    if (File.Exists(curFile.FullName))
                    {
                        try
                        {
                            curFile.Delete();//删除掉rar文件.
                        }
                        catch { }
                    }
                }
            }

            //清除集合中的内容.
            lstPartRar.Clear();

            //把dirTempRarPath目录下的所有解压过的文件移到接收目录下.
            FileInfo[] unPressedFiles = dirTempRarPath.GetFiles("*.*");
            try
            {
                foreach (FileInfo curFile in unPressedFiles)
                {
                    if (curFile.Name.IndexOf(".LandSeaSynch.") == -1)//不能包含未解压的同步文件.
                    {
                        if (File.Exists(dirReceFilePathtemp + "\\" + curFile.Name))
                        {
                            File.Delete(dirReceFilePathtemp + "\\" + curFile.Name);
                        }
                        curFile.MoveTo(dirReceFilePathtemp + "\\" + curFile.Name);
                    }
                }

                //如果dirTempRarPath目录下没有任何文件则删除它.

                if (dirTempRarPath.GetFiles().Length == 0)
                {
                    dirTempRarPath.Delete();
                }
            }
            catch { }
        }

        /// <summary>
        /// 使用WinRar软件解压缩指定的文件（要求操作系统必须安装WinRar）.
        /// </summary>
        /// <param name="winRarExe">WinRar程序名（包含所在路径）</param>
        /// <param name="curFile">要解压缩的文件</param>
        /// <param name="sErrMessage">返回参数，返回一个出错信息</param>
        private bool winRarUnPress(string winRarExe, FileInfo curFile, out string sErrMessage)
        {
            //声明进程对象.
            ProcessStartInfo procWinRarInfo = new ProcessStartInfo();
            Process procWinRar = new Process();
            string sCommandInfo = "";   //解压缩命令信息.

            try
            {
                //设置命令参数.
                sCommandInfo = " x \"" + curFile.FullName + "\" " + curFile.DirectoryName + " -y -hplandsea123$%^ ";
                procWinRarInfo.FileName = winRarExe;
                procWinRarInfo.Arguments = sCommandInfo;
                procWinRarInfo.WindowStyle = ProcessWindowStyle.Hidden; //隐藏显示WinRar界面.

                //执行压缩.
                procWinRar.StartInfo = procWinRarInfo;
                procWinRar.Start();
                procWinRar.WaitForExit();//等待完成后退出.

                procWinRar.Close();
                sErrMessage = "";
                return true;
            }
            catch (Exception e)
            {
                sErrMessage = e.Message;
            }
            return false;
        }

        /// <summary>
        /// 清除发送目录下的Backup目录下的备份文件（清除10天之前的文件）.
        /// </summary>
        /// <param name="sendFileBackUp">指定的备份目录</param>
        public void clearBackup(string sendFileBackUp)
        {
            DirectoryInfo dirSendFileBackUp = new DirectoryInfo(sendFileBackUp);

            if (dirSendFileBackUp.Exists)
            {
                //取备份目录下的所有文件.

                FileInfo[] files = dirSendFileBackUp.GetFiles("*.*");
                foreach (FileInfo curFile in files)
                {
                    if (curFile.CreationTime < (DateTime.Now.AddDays(-10)))
                    {
                        try { curFile.Delete(); }
                        catch { }
                    }
                }
            }
        }

        /// <summary>
        /// 判断指定的文件是否是被分卷压缩的文件（分卷压缩的文件类似：*.part1.rar、*.part01.rar）.
        /// </summary>
        /// <param name="curFile">指定的文件</param>
        /// <returns>如果是返回True，否则返回False</returns>
        private bool isPartRarFile(FileInfo curFile)
        {
            bool blnResult = false;     //返回的结果值.

            string pattern1 = @"[\S\s][.]LandSeaSynch[.]part[0-9]{1}[.]rar$";//匹配*.LandSeaSynch.part1.rar格式（点号匹配应该写成[.]）.
            string pattern2 = @"[\S\s][.]LandSeaSynch[.]part[0-9]{2}[.]rar$";//匹配*.LandSeaSynch.part01.rar格式（点号匹配应该写成[.]）.
            string pattern3 = @"[\S\s][.]LandSeaSynch[.]part[0-9]{3}[.]rar$";//匹配*.LandSeaSynch.part001.rar格式（点号匹配应该写成[.]）.
            string curFileName = curFile.Name;  //当前文件名.

            //如果符合三个条件之一，则返回true
            if (Regex.IsMatch(curFileName, pattern1) || Regex.IsMatch(curFileName, pattern2)
                                                    || Regex.IsMatch(curFileName, pattern3))
            {
                blnResult = true;
            }

            return blnResult;
        }
    }
}