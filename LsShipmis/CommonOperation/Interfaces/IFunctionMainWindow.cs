using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
namespace CommonOperation.Interfaces
{
    /// <summary>
    /// 功能窗体必须继承的接口.
    /// </summary>
    public interface IFunctionMainWindow
    {
        void ChildClosed(IFunctionChildWindow functionChildWindow);
    }
}
