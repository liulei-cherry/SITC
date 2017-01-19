using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Win32;

namespace Login
{
    public class ConstParameter
    {
        /// <summary>
        /// 版本号(不同项目的版本号要求不同，否则开发版数据库配置信息将是其他版本的配置)。
        /// 此版本号用于从注册表获取或保存相应配置
        /// </summary>
        public static string VER = "NOT DEFINE";
        /// <summary>
        /// 版本描述，在升级程序中显示的版本名称
        /// </summary>
        public static string Detail = "未知版本";
        /// <summary>
        /// 船舶端或者陆地端，影响注册表获取的位置
        /// </summary>
        public static string ShipOfLand = "NOT DEFINE";
        /// <summary>
        /// 反馈调用主程序的参数。如没有，则空
        /// </summary>
        public static string BackCallArg = ""; 
        public static string DBConnectString
        {
            get
            {
                if (reDefineDbConnectString != null)
                {
                    return reDefineDbConnectString();
                }
                string shipMisSqlConnt = ShipMisSqlConnt;
                //if (string.IsNullOrEmpty(shipMisSqlConnt))
                //    return @"Data Source=SHIPMISSERVER\SHIPMIS2008;Initial Catalog=shipmis_hf;Persist Security Info=True;User ID=sa;Password=sa123$";
                //else 
                return shipMisSqlConnt;
            }
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
                //if (string.IsNullOrEmpty(shipMisSqlLobConnt))
                //    return @"Data Source=SHIPMISSERVER\SHIPMIS2008;Initial Catalog=shipmis_hf_lob;Persist Security Info=True;User ID=sa;Password=sa123$";
                //else 
                return shipMisSqlLobConnt;
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

        //注意，此处的shipid值无所谓，只为了开发的时候可以预先看到实际值而赋值，可以任意修改.
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
            catch (Exception) { }
            return value;
        }

      
    }
}
