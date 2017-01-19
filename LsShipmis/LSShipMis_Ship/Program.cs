using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using LSShipMis_Ship.Common;
using System.Deployment.Application;
using System.Reflection;
using CommonOperation;
using LSShipMis_Ship.SysLs.Services;
using LSShipMis_Ship.BasicData;
using System.Diagnostics;
using Maintenance;
using StorageManage;
using CommonOperation.Functions;
using BaseInfo.DataAccess;
using BaseInfo.Objects;
using CommonViewer.BaseForm;
using CommonOperation.Interfaces;
using CommonViewer.BaseControl;

namespace LSShipMis_Ship
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //Application.SetCompatibleTextRenderingDefault(false);
            //if (PrevInstance()) return;
            Application.EnableVisualStyles();
            Application.DoEvents();
            CommonOperation.ConstParameter.IsLandVersion = false;

            InitParameter();
            FrmLogin frmLogin = new FrmLogin("ShipMis0", "LSShipMis_Ship.Properties.Settings.ShipMisSqlConnt",
                "LSShipMis_Ship.Properties.Settings.ShipMisSqlLobConnt");
            frmLogin.GetLoginUserInfo += new FrmLogin.getLoginUserInfo(GetLoginUserInfo);
            string strUpdateExeVersion = "ShipLogin.exe";

            /*无参数模式启动检查程序版本模式*/
#if DEBUG
            args = new String[1];
            args[0] = "Success";
#endif

            if (args.Length == 0)
            {
                try
                {
                    string conn = ConstParameter.GetRegedit("ShipMisSqlConnt");//开发版数据库连接信息.
                    if (InterfaceInstantiation.NewADbAccess(conn).GetCanNotUse)
                    {
                        ConstParameter.SetRegedit("ShipMisSqlConnt", ConstParameter.ShipMisSqlConnt);
                        ConstParameter.SetRegedit("ShipMisSqlLobConnt", ConstParameter.ShipMisSqlLobConnt);
                    }

                    Process.Start(Application.StartupPath + "\\" + strUpdateExeVersion, ConstParameter.VER + " " + (ConstParameter.IsLandVersion ? "Land" : "Ship") + " " + AssemblyTitle);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "可能原因：升级程序被移除！解决办法：重新安装程序或修复程序！");
                }
                finally
                {
                    frmLogin.Close();
                }
            }
            else
            {
                /*目前有参模式为检测版本通过*/
                DialogResult dialogResult = frmLogin.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    //预先执行的内容必须连上数据库了才能执行.
                    advanceExecute();
                    Application.Run(new FrmMdiMain());
                }
            }
        }
        private static ILoginUser GetLoginUserInfo(string userId)
        {
            return (Post)PostService.Instance.GetOneObjectById(userId);
        }

        /// <summary>
        /// 预先执行的内容,在打开程序之前需要执行的部分.
        /// </summary>
        private static void advanceExecute()
        {
            ConstParameter.ArgumentSetCollectionInit();//参数设置功能的参数初始化.
            if ((new ConstParameter.SystemParameter())["IsApplyFromInStorage"] == "2")
            {
                StorageConfig.StorageChangeNeedShipCheck = true;
                StorageConfig.StorageChangeNeedLandCheck = false;
                StorageConfig.StorageStorageCheckNeedLandView = false;
            }
        }
        private static void InitParameter()
        {
#if DEBUG
            CommonOperation.ConstParameter.MultilanguageVersion = false;
#endif
            CommonOperation.ConstParameter.MAINVERSION = String.Format("版本 {0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            CommonOperation.ConstParameter.MAINUSER = "海丰船舶端";
            CommonOperation.ConstParameter.VER = "S20110513HF_SHIP";
            ConstParameter.AllRightInit();
            MaintenanceConfig.MaintenanceInitConfig();
            StorageConfig.StorageInitConfig();
        }


        public static string AssemblyTitle
        {
            get
            {
                // 获取此程序集上的所有 Title 属性.
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                // 如果至少有一个 Title 属性.
                if (attributes.Length > 0)
                {
                    // 请选择第一个属性.
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    // 如果该属性为非空字符串，则将其返回.
                    if (titleAttribute.Title != "")
                        return titleAttribute.Title;
                }
                // 如果没有 Title 属性，或者 Title 属性为一个空字符串，则返回 .exe 的名称.

                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }
    }
}