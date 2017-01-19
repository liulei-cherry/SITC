using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using Oil.Viewer;

namespace Oil.Services
{
    /// <summary>
    /// 报警业务类.
    /// </summary>
    public class HOilApplyAlert : CommonOperation.Interfaces.IRemind
    {
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
            tag = "存在需要审核的油料申请";
            return rc;
        }

        /// <summary>
        /// 点击报警图标后需要打开的窗体或处理的事件.
        /// </summary>
        public void viewInfo()
        {
            FrmOilApply frm = FrmOilApply.Instance;
            if (CommonViewer.CommonViewConfig.MainForm != null) frm.MdiParent = CommonViewer.CommonViewConfig.MainForm;
            frm.BringToFront();
            frm.Show();
            frm.SetRemindViewApprovalState();
        }
        /// <summary>
        /// 得到报警对象.
        /// </summary>
        /// <returns></returns>
        public static IRemind GetAlarmObject()
        {
            //变量定义部分.
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select top 1 ");
            sb.AppendLine(" ha.APPLY_ID");
            sb.AppendLine(" from T_HOIL_APPLY ha");
            sb.AppendLine(" inner join T_CHECKED c on c.BUSINESS_OBJECT_ID=ha.APPLY_ID ");
            if (CommonOperation.ConstParameter.IsLandVersion)
                sb.AppendLine(" inner join T_USER_SHIP us on us.ship_id=ha.ship_id and us.userid = '" + CommonOperation.ConstParameter.UserId + "'");
            sb.AppendLine(" where 1=1 ");
            sb.AppendLine(" and ha.CHECKED = '1'");
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                if ("机务经理岗位" == CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)
                    sb.AppendLine(" and (c.current_postid = '机务经理岗位' )");
                else if ("机务主管岗位" == CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)
                    sb.AppendLine(" and (c.current_postid = '机务主管岗位')");
                else
                    return null;
            }
            else
                sb.AppendLine(" and c.current_postid = '" + CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME + "'");

            if (dbAccess.GetDataTable(sb.ToString(), out dtb, out err))
            {
                if (dtb != null && dtb.Rows.Count > 0)
                    return (IRemind)new HOilApplyAlert();
            }
            return null;
        }
    }
}