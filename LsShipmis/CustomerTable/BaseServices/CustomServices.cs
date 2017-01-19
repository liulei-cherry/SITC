using System;
using System.Collections.Generic;
using System.Text;
using BaseInfo.Objects;
using StorageManage.Services;
using StorageManage.DataObject;
using BaseInfo.DataAccess;
using System.IO;
using FileOperationBase.FileServices;
using FileOperationBase.Services;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using CommonOperation.Enum;

namespace CustomerTable.BaseServices
{
    public class CustomServices
    {
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();

        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static CustomServices instance = new CustomServices();
        public static CustomServices Instance
        {
            get
            {
                if (null == instance)
                {
                    CustomServices.instance = new CustomServices();
                }
                return CustomServices.instance;
            }
        }
        #endregion

    }
}
