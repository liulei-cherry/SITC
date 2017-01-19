﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using StorageManage.Viewer;
using BaseInfo.DataAccess;

namespace StorageManage.Alert
{
    /// <summary>
    /// 报警业务类.
    /// </summary>
    public class MaterialApplyAlertOnce : CommonOperation.Interfaces.IRemind
    {
        private static string message = "";
        private static remindColor rc = remindColor.Yellow;
        /// <summary>
        /// 定义数据操作层对象.
        /// </summary>
        private static IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        /// <summary>
        /// 当前对象的报警颜色，以及鼠标tag信息.
        /// </summary>
        /// <param name="tag">图标上显示的鼠标tag</param>
        /// <returns>报警颜色值</returns>
        public remindColor getStatus(out string tag)
        {
            tag = message;
            return rc;
        }

        /// <summary>
        /// 点击报警图标后需要打开的窗体或处理的事件.
        /// </summary>
        public void viewInfo()
        {
            RemindService.Instance.DeleteByType(4);
            FrmMaterialPurchaseApply frm = FrmMaterialPurchaseApply.Instance;
            if (CommonViewer.CommonViewConfig.MainForm != null) frm.MdiParent = CommonViewer.CommonViewConfig.MainForm;
            frm.BringToFront();
            frm.Show();
            frm.SetRemindViewInformState();
        }
        /// <summary>
        /// 得到报警对象.
        /// </summary>
        public static IRemind GetAlarmObject()
        {
            //变量定义部分.
            DataTable dtb;    //定义一个DataTable对象.
            string err;
            RemindService.Instance.GetInfoByCondition(4, out dtb, out err);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                message = dtb.Rows.Count + "条新物料申请审核完成";
                return (IRemind)new MaterialApplyAlertOnce();
            }

            return null;
        }
    }
}