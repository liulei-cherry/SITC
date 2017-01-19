using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.Interfaces;

namespace CommonOperation.BaseClass
{
    internal class SuperUser : ILoginUser
    {

        #region ILoginUser 成员

        public bool ISHIGHLEVELSHIPMAN
        {
            get { return false; }
        }

        public bool ISLANDPERSON
        {
            get { return false; }
        }

        public bool ISSHIPHEADER
        {
            get { return false; }
        }

        public bool ISSHIPBOSS
        {
            get { return false; }
        }

        public bool ISDECKMAN
        {
            get { return false; }
        }

        public bool ISMACHINEMAN
        {
            get { return false; }
        }

        public string ShipHeadShipName
        {
            get { return "软件系统管理员"; }
        }

        public string DepartmentId
        {
            get { return ""; }
        }

        public string DepartmentName
        {
            get { return ""; }
        }

        public string PostId
        {
            get { return ""; }
        }

        /// <summary>
        /// 岗位类型名称.
        /// </summary>
        public string POSTTYPENAME
        {
            get { return ""; }
        }

        #endregion
    }
}
