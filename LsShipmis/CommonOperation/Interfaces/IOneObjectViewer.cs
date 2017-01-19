using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;

namespace CommonOperation.Interfaces
{
    public interface IOneObjectViewer
    {
        /// <summary>
        /// 更改一个要展示的对象,当数据没有变化是,不做任何处理.
        /// </summary>
        /// <param name="toChangeData"></param>
        void ChangeData(CommonClass toChangeData);
        
        /// <summary>
        /// 直接更改数据,
        /// </summary>
        /// <param name="toChangeData"></param>
        void DirectlyChangeData(CommonClass toChangeData);
        /// <summary>
        /// 清空当前所有内容.
        /// </summary>
        void ClearData();
        /// <summary>
        /// 设置对象,表格中的内容形成一个对象.
        /// </summary>
        /// <param name="err"></param>
        /// <returns></returns>
        bool SetObject(out string err);
        /// <summary>
        /// 设置成可以改或者只读状态.
        /// </summary>
        /// <param name="canEdit"></param>
        void SetCanEdit(bool canEdit); 

        //应该把update，beforeupdate都加上。暂时不处理.
    }
}
