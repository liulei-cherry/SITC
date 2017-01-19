/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：WorkInfoService.cs
 * 创 建 人：牛振军
 * 创建时间：2008-05-12
 * 标    题：工作信息业务信息
 * 功能描述：文件夹管理。
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.Enum;

namespace FileOperationBase.Services
{
    public class ourFolder
    {
        private string _NodeId;         //当前节点ID    
        private string _NodeName;       //当前节点名称.
        private string _ParentNodeId;   //父节点ID，为空则为根节点.
        private decimal _Fsort;             //排列顺序号.
        private string _FullPath;       //当前节点到根节点的路径.
        private decimal _Node_Type;         //当前节点类型.
        private string _shipid;

        #region 属性
        public string NodeId
        {
            get { return _NodeId; }
            set { _NodeId = value; }
        }

        public string NodeName
        {
            get { return _NodeName; }
            set { _NodeName = value; }
        }

        public string ParentNodeId
        {
            get { return _ParentNodeId; }
            set { _ParentNodeId = value; }
        }

        public decimal Fsort
        {
            get { return _Fsort; }
            set { _Fsort = value; }
        }

        public string FullPath
        {
            get { return _FullPath; }
            set { _FullPath = value; }
        }

        /// <summary>
        /// 文件夹类型(分类 FileBoundingTypes)
        /// </summary>
        public decimal Node_Type
        {
            get { return _Node_Type; }
            set { _Node_Type = value; }
        }
        public string Node_Desc
        {
            get 
            {
                return EnumConfig.Instance.GetFolderDetail((int)_Node_Type);                
            }
        }
        public string ShipId
        {
            get { return _shipid; }
            set { _shipid = value; }
        }
        #endregion

    }
}
