using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;

namespace CommonOperation.Interfaces
{
    public interface IFunctionOfBusiness
    {
        //返回值是功能名称(同时作为菜单名称);
        string LoadThisBusinessMainDetail(out string Detail);
        //提供给主程序一个权限列表,为了让系统作为判断权限的依据.
        //提供一个菜单列表,每一个菜单对应相应的权限组.如果父菜单设置了权限组而子菜单没有设置,则认为与父菜单相同.
        void LoadAllWindowsFromTheBusiness(out List<string> menus,out List<List<Authority>> allAuthoritys);
        //根据一系列的权限列表获取当前功能集合的所有可用窗体集合.
        //List<Authority> GetAllAuthorityOfThisBusiness();
        //根据一系列的权限列表获取当前功能集合的所有可用功能集合.
        //提供一个打开所有功能的接口,不允许用户直接调用open窗口打开.
        IFunctionChildWindow LoadingAWindowByFunctionName(string functionName,out bool isDialog);
        //得到所有窗体的功能介绍.
        string GetWindowFunctionDetail(string windowFunctionName);

    }
}
