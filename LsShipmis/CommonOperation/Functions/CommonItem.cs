/**********************************************************************************************************
* Copyright (C) 2007 大连陆海科技有限公司 版权所有
* 文 件 名：CommonItem.cs  业务版,与简化版不完全一致,(Business1.00)
* 创 建 人：徐正本
* 创建时间：2007-8-22 9:58:24
* 标    题： 
* 功能描述：所有实体对象基类,提供id和加载控制功能
* 修 改 人：
* 修改时间：
* 修改内容：
*********************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CommonOperation.Functions
{
    public class CommonItem
    {
        private string itemGuid;
        private bool isWrong = false;  //错误的数据.
        private string whyWrong = "";  //错误的原因.

        public string ItemGuid
        {
            get
            {
                return itemGuid;
            }
            set
            {
                itemGuid = value;
            }
        }

        public bool IsWrong
        {
            get
            {
                return isWrong;
            }
            set
            {
                isWrong = value;
            }
        }

        public string WhyWrong
        {
            get
            {
                return whyWrong;
            }
            set
            {
                whyWrong = value;
            }
        }
    }
}