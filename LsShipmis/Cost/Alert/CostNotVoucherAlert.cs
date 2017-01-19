using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using Cost.Viewer;
using System.Data;
using Cost.Services;

namespace Cost.Alert
{
    public class CostNotVoucherAlert : CommonOperation.Interfaces.IRemind
    {
        private static string message = "存在未产生单日凭证的费用项目";
        private static remindColor rc = remindColor.Red;
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
            FrmVoucher frm = FrmVoucher.Instance;
            if (CommonViewer.CommonViewConfig.MainForm != null)
                frm.MdiParent = CommonViewer.CommonViewConfig.MainForm;
            frm.BringToFront();
            frm.Show();
        }
        /// <summary>
        /// 得到报警对象.
        /// </summary>
        public static IRemind GetAlarmObject()
        {
            string err = "";

            DataTable dtb = ACTUAL_COSTSService.Instance.getInfoNoVoucher("", out err);

            if (dtb != null && dtb.Rows.Count > 0)
                return (IRemind)new CostNotVoucherAlert();
            return null;
        }
    }
}
