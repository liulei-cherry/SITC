using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.Functions;
using CommonOperation.Interfaces;
using StorageManage.Viewer;
using System.Data;
using BaseInfo.DataAccess;

namespace StorageManage.Alert
{
    public class SpareInAlertOnce : CommonOperation.Interfaces.IRemind
    {
        private static remindColor rc = remindColor.Yellow;

        static String AlertMessage = String.Empty;

        #region 备件手工入库报警 zhangy-2013-7-29
        public static IRemind GetSpareInAlarmObject()
        {
            DataTable dtb;
            string err = "";
            RemindService.Instance.GetInfoByCondition(9, out dtb, out err);

            if (dtb != null && dtb.Rows.Count > 0)
            {
                AlertMessage = dtb.Rows.Count + "条新手工备件入库单。";
                return (IRemind)new SpareInAlertOnce();
            }
            return null;
        }
        #endregion

        public remindColor getStatus(out string tag)
        {
            tag = AlertMessage;
            return rc;
        }

        public void viewInfo()
        {
            RemindService.Instance.DeleteByType(9);

            FrmSpareIn frm = FrmSpareIn.Instance;
            if (CommonViewer.CommonViewConfig.MainForm != null) frm.MdiParent = CommonViewer.CommonViewConfig.MainForm;
            frm.BringToFront();
            frm.Show();
            frm.SetRemindViewInformState();
        }
    }
}
