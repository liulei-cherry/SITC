using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using Oil.Viewer;
using BaseInfo.DataAccess;

namespace Oil.Services
{
    /// <summary>
    /// 报警业务类.
    /// </summary>
    public class HOilApplyAlertOnce : CommonOperation.Interfaces.IRemind
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
            RemindService.Instance.DeleteByType(6);
            FrmOilApply frm = FrmOilApply.Instance;
            if (CommonViewer.CommonViewConfig.MainForm != null) frm.MdiParent = CommonViewer.CommonViewConfig.MainForm;
            frm.BringToFront();
            frm.Show();
        }
        /// <summary>
        /// 等到报警对象.
        /// </summary>
        /// <returns></returns>
        public static IRemind GetAlarmObject()
        {
            //变量定义部分.
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.

            RemindService.Instance.GetInfoByCondition(6, out dtb, out err);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                message = dtb.Rows.Count + "条新油料申请审核完成";
                return (IRemind)new HOilApplyAlertOnce();
            }
            return null;
        }
    }
}