using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using Cost.Viewer;
using BaseInfo.DataAccess;

namespace Cost.Alert
{
    /// <summary>
    /// 凭证报警
    /// </summary>
    public class VoucherNotPassAlertOnce : CommonOperation.Interfaces.IRemind
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
            RemindService.Instance.DeleteByType(8);

            FrmVoucherApproval frm = FrmVoucherApproval.Instance;
            if (CommonViewer.CommonViewConfig.MainForm != null)
                frm.MdiParent = CommonViewer.CommonViewConfig.MainForm;
            frm.showStatic = 1;//1:打回状态
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

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select	");
            sb.AppendLine("r.ID");
            sb.AppendLine(",r.BUSINESSID");
            sb.AppendLine(",r.REMIND_TYPE");
            sb.AppendLine(",r.POST_TYPE");
            sb.AppendLine("  from T_REMIND r");
            sb.AppendLine(" inner join T_USER_SHIP us on us.ship_id=r.ship_id  and us.userid = '" + CommonOperation.ConstParameter.UserId + "'");
            sb.AppendLine(" where 1=1");
            sb.AppendLine(" and r.POST_TYPE='" + CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME + "'");
            sb.AppendLine(" and r.REMIND_TYPE=8");
            sb.AppendLine("  group by r.ID,r.BUSINESSID,r.REMIND_TYPE,r.POST_TYPE");
            if (!dbAccess.GetDataTable(sb.ToString(), out dtb, out err))
                return null;

            if (dtb != null && dtb.Rows.Count > 0)
            {
                message = dtb.Rows.Count + "条凭证申请审核未通过";
                return (IRemind)new VoucherNotPassAlertOnce();
            }
            return null;
        }
    }
}