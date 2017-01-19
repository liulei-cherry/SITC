using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Win32;
using CommonOperation.Interfaces;
using CommonOperation.Functions;

namespace CommonOperation
{
    public partial class ConstParameter
    { 
        #region 全局变量

        //本版本号是'海丰版'。版本号(不同项目的版本号要求不同，否则开发版数据库配置信息将是其他版本的配置)。.
        public static string VER = "S20110513HF";
        public static string MAINVERSION = "非预定义版本";
        public static string MAINUSER = "非预定义用户";
        /// <summary>
        /// 用来控制     OurTableServices.GetInstance.RetrieveTable(); 是否调用
        /// </summary>
        public static bool isFristLoaded = true;
        public static DateTime MinDateTime = new DateTime(1900, 1, 1);
        public static DateTime MaxDateTime = new DateTime(2050, 12, 31);
        public static string DBSelect = "SqlServer";
        public static string DBConnectString
        {
            get
            {
                if (reDefineDbConnectString != null)
                {
                    return reDefineDbConnectString();
                }
                string shipMisSqlConnt = ShipMisSqlConnt;
                if (string.IsNullOrEmpty(shipMisSqlConnt))
                    return @"Data Source=192.168.102.70\MSSQLSVR2008R2;Initial Catalog=shipmis_hf;Persist Security Info=True;User ID=sa;Password=sa123$";
                else return shipMisSqlConnt;
                //return @"Data Source=192.168.102.216;Initial Catalog=shipmis_UT788_land;Persist Security Info=True;User ID=sa;Password=sa123$";
            }
        }

        public static bool DateTimeIsUsefull(DateTime dt)
        {
            return (dt > MinDateTime && dt < MaxDateTime);
        }
        public static string LobDBConnectString
        {
            get
            {
                if (reDefineDbConnectLobString != null)
                {
                    return reDefineDbConnectLobString();
                }
                string shipMisSqlLobConnt = ShipMisSqlLobConnt;
                if (string.IsNullOrEmpty(shipMisSqlLobConnt))
                    return @"Data Source=192.168.102.70\MSSQLSVR2008R2;Initial Catalog=shipmis_hf_lob;Persist Security Info=True;User ID=sa;Password=sa123$";
                else return shipMisSqlLobConnt;
                // return @"Data Source=192.168.102.216;Initial Catalog=shipmis_UT788_land_lob;Persist Security Info=True;User ID=sa;Password=sa123$";
            }
        }

        public static string ShipMisSqlConnt
        {
            get
            {
                string reStr = "";

                reStr = GetRegedit("ShipMisSqlConnt");//开发版数据库连接信息.
                if (string.IsNullOrEmpty(reStr)) return "";

                return reStr;
            }
            set
            {
                SetRegedit("ShipMisSqlConnt", value);
            }
        }

        public static string ShipMisSqlLobConnt
        {
            get
            {
                string reStr = "";
                reStr = GetRegedit("ShipMisSqlLobConnt");//开发版数据库连接信息.
                if (string.IsNullOrEmpty(reStr)) return "";
                return reStr;
            }
            set
            {
                SetRegedit("ShipMisSqlLobConnt", value);
            }
        }

        public delegate string ReDefineDbConnectString();
        public static ReDefineDbConnectString reDefineDbConnectString;
        public static ReDefineDbConnectString reDefineDbConnectLobString;
        public static bool IsLandVersion = true;
        public static string ShipId = "2e09fa8d-955c-44d7-8acd-fc151db84e89";
        //注意，此处的shipid值无所谓，只为了开发的时候可以预先看到实际值而赋值，可以任意修改.
        public static string UserId = "";    //当前用户Id
        public static string ShipUserId = "";//船员Id（当前用户对应的船员的id）.
        public static string UserLogInName = ""; //当前用户登录Id(登录时的用户名）.
        public static ILoginUser LoginUserInfo = null;
        public static string UserName = "非正常登录者";  //当前用户真实姓名。如：王明
        public static bool SupperUser = false;//false:普通用户，true：超级用户.
        //下面两个是常量,用const更好,只不过const在写代码的时候汇报一个warning,比较不爽.暂时写成static
        public static bool MultilanguageVersion = true;//是否是多语言版本.
        public static bool UseEquipmentCounter = false;//是否使用真实设备定时器.
        #endregion

        public static void SetRegedit(string name, string value)
        {
            RegistryKey HKLM = Registry.LocalMachine;
            RegistryKey Run = HKLM.CreateSubKey(@"SOFTWARE\Landsea\ShipMis\" + ConstParameter.VER);

            try
            {
                Run.SetValue(name, value);
                HKLM.Close();
            }
            catch (Exception) { }
        }

        public static string GetRegedit(string name)
        {
            RegistryKey HKLM = Registry.LocalMachine;
            RegistryKey Run = HKLM.CreateSubKey(@"SOFTWARE\Landsea\ShipMis\" + ConstParameter.VER);
            string value = "";
            try
            {
                object tempObject = Run.GetValue(name);
                //徐正本 edit 2013年4月17日 如果指定位置找不到，则从旧程序规定的注册表目录进行查找，如果可以找到，返回此值。
                if (tempObject != null)
                {
                    value = tempObject.ToString();
                }
                HKLM.Close();
            }
            catch { }
            return value;
        }
    }
}
