using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace Login
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {                         
#if !DEBUG
             if (args.Length < 3)
            {  
                MessageBox.Show("Login程序启动命令不能独立运行");
                return;
            }
#else
            if (args.Length == 0)
            {     
                args = new string[3];
                args[0] = "S20110513HF";
                args[1] = "Land";
                args[2] = "测试版本";
            }
#endif
            if (PrevInstance()) return;
            Login.ConstParameter.VER = args[0];
            if (args[1].ToUpper() == "LAND")
                Login.ConstParameter.ShipOfLand = "Land";
            else
                Login.ConstParameter.ShipOfLand = "Ship"; ;
            ConstParameter.Detail = args[2];
            if (args.Length > 3)
            { ConstParameter.BackCallArg = args[3]; }

#if DEBUG
            MessageBox.Show(Login.ConstParameter.VER, "配置版本号");
            MessageBox.Show(Login.ConstParameter.ShipOfLand, "船舶端或岸端");
            MessageBox.Show(Login.ConstParameter.Detail, "主程序描述");
            MessageBox.Show(Login.ConstParameter.BackCallArg, "反调主程序参数");
#endif 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmShipLogin());
        }

        private static bool PrevInstance()
        {
            string procName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            if ((System.Diagnostics.Process.GetProcessesByName(procName)).GetUpperBound(0) > 0)
            {
                #region 清理升级程序文件 (zhangy-2013-10-12)
                try
                {
                    String currentSoftPath = Application.StartupPath;
                    String fileFullName = currentSoftPath + "\\AutoUpdate" + ConstParameter.ShipOfLand + ".xml";
                    FileInfo fi = new FileInfo(fileFullName);
                    fi.Delete();
                }
                catch { }
                #endregion

                MessageBox.Show("当前程序正在运行,本程序不允许重复打开多个副本!");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
