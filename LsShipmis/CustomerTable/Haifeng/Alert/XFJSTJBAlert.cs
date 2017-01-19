using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using CustomTable.Haifeng.Viewer;
using BaseInfo.DataAccess;
using CustomTable.Haifeng.Services;

namespace CustomTable.Haifeng.Alert
{
    /// <summary>
    /// 消防救生设备有效期管理报警.
    /// </summary>
    public class XFJSTJBAlert : CommonOperation.Interfaces.IRemind
    {
        private static string message = "";
        private static remindColor rc = remindColor.Orange;
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
            FrmXFJSTJB frm = new FrmXFJSTJB();
            if (CommonViewer.CommonViewConfig.MainForm != null) frm.MdiParent = CommonViewer.CommonViewConfig.MainForm;
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.BringToFront();
            frm.Show();
        }
        /// <summary>
        /// 得到报警对象.
        /// </summary>
        public static IRemind GetAlarmObject()
        {
            string shipId;
            int i = CTB_XFJSTJBService.Instance.GetAlertXFJS(out shipId);
            if (i > 0)
            {
                message = "共有" + i + "条消防救生设备进入报警期!";
                return (IRemind)new XFJSTJBAlert();
            }

            return null;
        }
    }
}
