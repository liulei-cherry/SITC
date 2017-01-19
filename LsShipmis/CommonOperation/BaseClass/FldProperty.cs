/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FldProperty.cs
 * 创 建 人：李景育
 * 创建时间：2007-05-06
 * 标    题：业务信息实体中的字段属性信息类
 * 功能描述：容器类，用于装载业务信息实体中的字段属性信息
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonOperation.BaseClass
{
    /// <summary>
    /// 业务信息实体中的字段属性信息类.
    /// </summary>
    public class FldProperty
    {
        private int     columnSize;         //字段的大小信息.
        private int     numericPrecision;   //字段的最大精度.
        private int     numericScale;       //字段的小数位数.
        private bool    allowDBNull;        //字段是否可以为空.
        private string  dataType;           //字段的数据类型信息.
        /// <summary>
        /// 字段的大小信息属性.
        /// </summary>
        public int ColumnSize
        {
            get
            {
                return columnSize;
            }
            set
            {
                columnSize = value;
            }
        }

        /// <summary>
        /// 字段的最大精度.
        /// </summary>
        public int NumericPrecision
        {
            get
            {
                return numericPrecision;
            }
            set
            {
                numericPrecision = value;
            }
        }

        /// <summary>
        /// 字段的小数位数部分.
        /// </summary>
        public int NumericScale
        {
            get
            {
                return numericScale;
            }
            set
            {
                numericScale = value;
            }
        }

        /// <summary>
        /// 字段是否可以为空信息属性.
        /// </summary>
        public bool AllowDBNull
        {
            get
            {
                return allowDBNull;
            }
            set
            {
                allowDBNull = value;
            }
        }

        /// <summary>
        /// 字段的数据类型信息属性.
        /// </summary>
        public string DataType
        {
            get
            {
                return dataType;
            }
            set
            {
                dataType = value;
            }
        }
    }
}