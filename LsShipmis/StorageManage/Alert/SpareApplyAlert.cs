using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using StorageManage.Viewer;

namespace StorageManage.Alert
{
    /// <summary>
    /// 备件申请报警业务类.
    /// </summary>
    public class SpareApplyAlert : CommonOperation.Interfaces.IRemind
    {
        private static string message = "";
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
            FrmSparePurchaseApply frm = FrmSparePurchaseApply.Instance;
            if (CommonViewer.CommonViewConfig.MainForm != null) frm.MdiParent = CommonViewer.CommonViewConfig.MainForm;
            frm.BringToFront();
            frm.Show();
            frm.SetRemindViewApprovalState();
        }
        /// <summary>
        /// 等到报警对象.
        /// </summary>
        /// <param name="functionCode">1=等待审核; 2=未填写完毕; 3=被打回</param>
        /// <returns></returns>
        public static IRemind GetAlarmObject(int functionCode)
        {
            //变量定义部分.
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            rc = remindColor.Red;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select top 1 ");
            sb.AppendLine("PURCHASE_APPLYID");
            sb.AppendLine(" ,case STATE ");
            sb.AppendLine("  when '0' then '未填写完毕'");
            sb.AppendLine("  when '1' then '等待部门长审核'");
            sb.AppendLine("  when '2' then '等待船长确认'");
            sb.AppendLine("  when '3' then '等待岸端机务主管审批'");
            sb.AppendLine("  when '4' then '等待岸端机务经理审批'");
            sb.AppendLine("  when '5' then '等待船管总经理审批'");
            sb.AppendLine("  when '6' then '审核通过'");
            sb.AppendLine("  when '7' then '取消'");
            sb.AppendLine("  when '8' then '被打回'");
            sb.AppendLine("  end as STATE_NAME");
            sb.AppendLine(" from T_SPARE_PURCHASE_APPLY");
            if (CommonOperation.ConstParameter.IsLandVersion)
                sb.AppendLine(" inner join T_USER_SHIP us on us.ship_id=T_SPARE_PURCHASE_APPLY.ship_id and us.userid = '" + CommonOperation.ConstParameter.UserId + "'");

            sb.AppendLine(" where 1=1 ");
            if (functionCode == 1)
            {
                if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务主管.
                {
                    sb.AppendLine(" and STATE = 3");
                    message = "存在未审核的备件申请";
                }
                else if ("机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务经理.
                {
                    sb.AppendLine(" and (STATE = 4)");
                    message = "存在未审核的备件申请";
                }
                else if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是总经理.
                {
                    sb.AppendLine(" and STATE = 5");
                    message = "存在未审核的备件申请";
                }
                else if ("船长岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是船长.
                {
                    sb.AppendLine(" and STATE = 2");
                    message = "存在未审核的备件申请";
                }
                else if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER) //假如是部门长 并且是申请人部门的部门长.
                {
                    sb.AppendLine(" and STATE = 1");
                    sb.AppendLine(" and '" + CommonOperation.ConstParameter.LoginUserInfo.DepartmentId + "'=DEPART_ID");
                    message = "存在未审核的备件申请";
                }
                else
                {
                    return null;
                }
            }
            else if (functionCode == 2)
            {
                sb.AppendLine(" and PURCHASE_APPLY_PERSON='" + CommonOperation.ConstParameter.UserName + "'");
                sb.AppendLine(" and STATE = 0 ");
                message = "存在未填写完毕的备件申请";
                rc = remindColor.Yellow;
            }
            else if (functionCode == 3)
            {
                sb.AppendLine(" and PURCHASE_APPLY_PERSON='" + CommonOperation.ConstParameter.UserName + "'");
                sb.AppendLine(" and STATE=8");
                message = "存在被打回的备件申请";
            }
            if (dbAccess.GetDataTable(sb.ToString(), out dtb, out err))
            {
                if (dtb != null && dtb.Rows.Count > 0)
                    return (IRemind)new SpareApplyAlert();
            }
            return null;
        }
    }
}