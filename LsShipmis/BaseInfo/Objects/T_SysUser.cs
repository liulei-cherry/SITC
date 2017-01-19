/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：T_SysUser.cs
 * 创 建 人：李景育
 * 创建时间：2009-08-24
 * 标    题：系统用户业务实体类
 * 功能描述：定义系统用户业务实体类的字段，属性和构造函数
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseInfo.Objects
{
    /// <summary>
    /// 系统用户业务实体类.
    /// </summary>
    public class T_SysUser
    {
        #region 字段定义

        private string userId;
        private string postId;
        private string userName;
        private string postName;
        private string loginName;
        private string password;
        private int supperUser;
        private string supperUserName;
        private int on_Ship;
        private string on_ShipName;
        private string remark;
        private string ship_Id;

        #endregion

        #region 公共属性

        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        public string PostId
        {
            get { return postId; }
            set { postId = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string PostName
        {
            get { return postName; }
            set { postName = value; }
        }
        public string LoginName
        {
            get { return loginName; }
            set { loginName = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public int SupperUser
        {
            get { return supperUser; }
            set { supperUser = value; }
        }
        public string SupperUserName
        {
            get { return supperUserName; }
            set { supperUserName = value; }
        }
        public int On_Ship
        {
            get { return on_Ship; }
            set { on_Ship = value; }
        }
        public string On_ShipName
        {
            get { return on_ShipName; }
            set { on_ShipName = value; }
        }
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        public string Ship_Id
        {
            get { return ship_Id; }
            set { ship_Id = value; }
        }

        #endregion

        #region 构造函数
        
        public T_SysUser() { }

        #endregion
    }
}
