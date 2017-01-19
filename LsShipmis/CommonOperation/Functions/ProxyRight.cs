/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有 * 文 件 名：ProxyRight.cs
 * 创 建 人：李景育 * 创建时间：2008-06-04
 * 标    题：权限代理业务类 * 功能描述：实现功能权限的代理业务类 * 修 改 人： 徐正本
 * 修改时间：2010－08－14
 * 修改内容：管理员功能限制，没有任何具体操作权限 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using CommonOperation.Interfaces;
using CommonOperation.BaseClass;
namespace CommonOperation.Functions
{
    /// <summary>
    /// 权限代理业务类.
    /// </summary>
    public class ProxyRight
    {
        //int = 1,岸和船均可 =2 岸端 = 3 船端.
        public static Dictionary<string, int> AllRight = new Dictionary<string, int>();

        private static ProxyRight instance;
        public static ProxyRight Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProxyRight();
                }
                return ProxyRight.instance;
            }
            set { ProxyRight.instance = value; }
        }
        private ProxyRight()
        {
            if (AllRight.Count == 0) ConstParameter.AllRightInit();
            //检查所有的权限是否都存在，如果不存在则添加.
            BaseRightService.Instance.InitAllRight();
        }
        /// <summary>
        /// 判断给定的功能权限是否存在，如果存在，当前登录用户是否有使用该功能的权限.
        /// </summary>
        /// <param name="rightName">功能权限名称</param>
        /// <param name="sChkMessage">返回参数，如果功能权限没有配置或者当前用户没有该功能权限，则返回提示信息，否则返回ok</param>
        /// <returns>返回值，如果功能权限没有配置或者当前用户没有该功能权限，返回false，否则返回true</returns>
        public bool CheckRight(string rightName, out string sChkMessage)
        {
            bool blResult = false;  //返回值.

            //1.对于超级用户不用进行权限判断，不可以操作任何功能.
            if (CommonOperation.ConstParameter.UserName != null && CommonOperation.ConstParameter.UserName.Equals("超级用户"))
            {
                blResult = false;
                sChkMessage = "管理员不可以执行任何业务操作";
                return blResult;
            }

            //取系统所有的功能权限列表（里边包含当前登录用户所具有的功能权限，值为true）.

            Dictionary<string, bool> dictAllRights = CommonOperation.ConstParameter.dictAllRights;

            //2.如果当前功能权限没有配置，那么返回提示信息.

            if (dictAllRights != null && !dictAllRights.ContainsKey(rightName))
            {
                sChkMessage = rightName + "的功能权限在系统中没有配置！";
                //在此插入权限。.
                return blResult;
            }

            //3.如果当前登录用户有当前功能权限，返回true，否则返回false，并返回相应的提示信息.

            if (dictAllRights != null && dictAllRights[rightName])
            {
                blResult = true;
                sChkMessage = "";
            }
            else
            {
                sChkMessage = "您没有此功能的权限！";
                //sChkMessage = "您没有" + rightName + "的权限！";
            }

            //返回结果信息.
            return blResult;
        }
    }
}