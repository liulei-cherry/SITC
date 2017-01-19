using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;

namespace CommonOperation.Interfaces
{
    public interface IFunctionChildWindow
    {
        IFunctionMainWindow TheMainForm { get; set; }
        string FunctionName { get;set;}
        //获取所有可以打开本窗体的权限.
        List<Authority> GetAllAuthorityCanOpenThisWindow();
        bool JudgeTheAuthorityCanOpenThisWindow(Authority theAuthority);
    }
}
