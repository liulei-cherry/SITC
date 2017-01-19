using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using StorageManage.Viewer;
using System.Data;
using StorageManage.Services;
using Repair.Viewer;
using Repair.Services;

namespace StorageManage.Alert
{
    public class RepairNotVoucherAlert : CommonOperation.Interfaces.IRemind
    {
        private static string message = "存在未填写凭证的修理完工单";
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
            FrmCreateCertification frm = FrmCreateCertification.Instance;
            if (CommonViewer.CommonViewConfig.MainForm != null) frm.MdiParent = CommonViewer.CommonViewConfig.MainForm;
            frm.BringToFront();
            frm.Show();
        }
        /// <summary>
        /// 得到报警对象.
        /// </summary>
        /// <returns></returns>
        public static IRemind GetAlarmObject()
        {
            DataTable dtb = ShipRepairProjectService.Instance.GetInfo(null, null, null, null, "9", null);

            if (dtb != null && dtb.Select(" SENDTOWARRANT=0").Length > 0)
                return (IRemind)new RepairNotVoucherAlert();
            return null;
        }
    }
}
