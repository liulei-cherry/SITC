/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：IRemind.cs
 * 创 建 人：牛振军
 * 创建时间：2008-06-16
 * 标    题：公共报警接口
 * 功能描述：
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonOperation.Interfaces
{
    public enum remindColor { Green = 0, Yellow = 1, Orange = 2, Red = 3 }; //报警的返回级别.

    /// <summary>
    /// 需要报警的对象需要实现本接口.
    /// </summary>
    public interface IRemind
    {
        /// <summary>
        /// 当前对象的报警颜色，以及鼠标tag信息.
        /// </summary>
        /// <param name="tag">图标上显示的鼠标tag</param>
        /// <returns>报警颜色值</returns>
        remindColor getStatus(out string tag);
        /// <summary>
        /// 点击报警图标后需要打开的窗体或处理的事件.
        /// </summary>
        void viewInfo();
    }

}
