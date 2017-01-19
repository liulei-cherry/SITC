/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：CustomerTableClass.cs
 * 创 建 人：徐正本
 * 创建时间：2010-5-25
 * 标    题：实体类
 * 功能描述：T_CTB数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;

namespace CustomerTable
{
    /// <summary>
    ///T_CTB数据实体.
    /// </summary>
    ///[Serializable]
    public partial class CustomerTableClass 
    {
        #region 变量定义
        ///<summary>
        ///
        ///</summary>
        private string _t_CTB_ID;
        ///<summary>
        ///
        ///</summary>
        private string _cT_CLASS = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private int _sEQUNCE;
        ///<summary>
        ///
        ///</summary>
        private string _cATEGERY01 = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _cATEGERY02 = String.Empty;
        ///<summary>
        ///
        ///</summary>
        private string _cATEGERY03 = String.Empty;
        #endregion

        #region 构造函数
        ///<summary>
        ///
        ///</summary>
        public CustomerTableClass()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public CustomerTableClass
        (
            string t_CTB_ID,
            string cT_CLASS,
            int sEQUNCE,
            string cATEGERY01,
            string cATEGERY02,
            string cATEGERY03
        )
        {
            _t_CTB_ID = t_CTB_ID;
            _cT_CLASS = cT_CLASS;
            _sEQUNCE = sEQUNCE;
            _cATEGERY01 = cATEGERY01;
            _cATEGERY02 = cATEGERY02;
            _cATEGERY03 = cATEGERY03;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///
        ///</summary>
        public string T_CTB_ID
        {
            get { return _t_CTB_ID; }
            set { _t_CTB_ID = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string CT_CLASS
        {
            get { return _cT_CLASS; }
            set { _cT_CLASS = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public int SEQUNCE
        {
            get { return _sEQUNCE; }
            set { _sEQUNCE = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string CATEGERY01
        {
            get { return _cATEGERY01; }
            set { _cATEGERY01 = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string CATEGERY02
        {
            get { return _cATEGERY02; }
            set { _cATEGERY02 = value; }
        }

        ///<summary>
        ///
        ///</summary>
        public string CATEGERY03
        {
            get { return _cATEGERY03; }
            set { _cATEGERY03 = value; }
        }
        #endregion

    }
}
