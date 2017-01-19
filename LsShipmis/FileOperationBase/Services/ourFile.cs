/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：WorkInfoService.cs
 * 创 建 人：牛振军
 * 创建时间：2008-05-12
 * 标    题：工作信息业务信息
 * 功能描述：文件管理。
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace FileOperationBase.Services
{
    /// 文件其它信息表.
    public class ourFile
    {
        ///T_FILEINFO表，对象的id
        private string _object_id;
        ///T_FILEINFO表，二进制对象.
        private string _object_con_blob;
        ///以下为T_FILE_MANAGE表.
        ///主键字段.
        private string _fileId;
        /// 文件名.
        private string _fileName;
        /// 文档大小单位字节.
        private decimal _size;
        /// 文件说明标签或索引.
        private string _objectLabel;
        /// 创建日期，默认系统时间.
        private DateTime _createDate;
        /// 更新日期.
        private DateTime _updateDate;
        /// 维护者.
        private string _creator;
        /// 相关设备.
        private string _refEquipment; 
        /// 版本号.
        private string _version;
        /// 文档类型，DOT OR DOC
        private string _file_type;
        /// 模板的文件id号.
        private string _ref_fileid;
        /// 保留字段.
        private string _preserve1;
        /// 保留字段.
        private string _preserve2;
        private string _shipid;

        #region 属性
        public string Object_id
        {
            get { return _object_id; }
            set { _object_id = value; }
        }
        public string Object_con_blob
        {
            get { return _object_con_blob; }
            set { _object_con_blob = value; }
        }
        public string FileId
        {
            get{ return _fileId; }
            set { _fileId = value; }
        }
        public string Creator
        {
            get { return _creator; }
            set { _creator = value; }
        }
        public string FileName
        {
            get { return _fileName; }
            set 
            {
                _fileName = value;//.Replace("'","''"); 
            }
        }
        public string ObjectLabel
        {
            get { return _objectLabel; }
            set { _objectLabel = value; }
        }
        public decimal Size
        {
            get { return _size; }
            set { _size = value; }
        }
        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }
        public DateTime UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }
        public string RefEquipment
        {
            get { return _refEquipment; }
            set { _refEquipment = value; }
        }        
        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }
        public string File_Type
        {
            get { return _file_type; }
            set { _file_type = value; }
        }
        public string Ref_Fileid
        {
            get { return _ref_fileid; }
            set { _ref_fileid = value; }
        }
        public string Preserve1
        {
            get { return _preserve1; }
            set { _preserve1 = value; }
        }
        public string Preserve2
        {
            get { return _preserve2; }
            set { _preserve2 = value; }
        } 
        public string ShipId
        {
            get { return _shipid; }
            set { _shipid = value; }
        }
        #endregion

    }
}
