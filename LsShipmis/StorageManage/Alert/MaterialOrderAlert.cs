using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.Functions;
using CommonOperation.Interfaces;
using StorageManage.Viewer;
using System.Data;

namespace StorageManage.Alert
{
    /// <summary>
    /// 物资订单报警业务类.
    /// </summary>
    public class MaterialOrderAlert : CommonOperation.Interfaces.IRemind
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
            FrmMaterialPurchaseOrder frm = FrmMaterialPurchaseOrder.Instance;
            if (CommonViewer.CommonViewConfig.MainForm != null) frm.MdiParent = CommonViewer.CommonViewConfig.MainForm;
            frm.BringToFront();
            frm.Show();
            frm.SetRemindViewApprovalState();
        }
        /// <summary>
        /// 得到报警对象.
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
            sb.AppendLine("PURCHASE_ORDERID");
            sb.AppendLine(" ,case STATE ");
            sb.AppendLine("  when '0' then '未填写完毕'");
            sb.AppendLine("  when '1' then '等待机务主管审批'");
            sb.AppendLine("  when '2' then '等待机务经理审批'");
            sb.AppendLine("  when '3' then '等待船管总经理审批'");
            sb.AppendLine("  when '4' then '订单打回'");
            sb.AppendLine("  when '5' then '订购'");
            sb.AppendLine("  when '6' then '此订单作废'");
            sb.AppendLine("  when '7' then '部分到货'");
            sb.AppendLine("  when '8' then '结束'");
            sb.AppendLine("  when '9' then '已生成凭证'");
            sb.AppendLine("  end as STATE_NAME");
            sb.AppendLine(" from T_Material_PURCHASE_ORDER");
            if (CommonOperation.ConstParameter.IsLandVersion)
                sb.AppendLine(" inner join T_USER_SHIP us on us.ship_id=T_Material_PURCHASE_ORDER.ship_id  and us.userid = '" + CommonOperation.ConstParameter.UserId + "'");
            sb.AppendLine(" where 1=1 ");
            if (functionCode == 1)
            {
                if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务主管.
                {
                    sb.AppendLine(" and STATE = 1");
                    message = "存在未审核的物资订单";
                }
                else if ("机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务经理.
                {
                    sb.AppendLine(" and (STATE = 2)");
                    message = "存在未审核的物资订单";
                }
                else if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是船管总经理.
                {
                    sb.AppendLine(" and STATE = 3");
                    message = "存在未审核的物资订单";
                }
                else
                {
                    return null;
                }
            }
            else if (functionCode == 2)
            {
                sb.AppendLine(" and PURCHASE_ORDER_PERSON='" + CommonOperation.ConstParameter.UserName + "'");
                sb.AppendLine(" and STATE = 0 ");
                message = "存在未填写完毕的物资订单";
                rc = remindColor.Yellow;
            }
            else if (functionCode == 3)
            {
                sb.AppendLine(" and PURCHASE_ORDER_PERSON='" + CommonOperation.ConstParameter.UserName + "'");
                sb.AppendLine(" and STATE=4");
                message = "存在被打回的物资订单";
            }
            if (dbAccess.GetDataTable(sb.ToString(), out dtb, out err))
            {
                if (dtb != null && dtb.Rows.Count > 0)
                    return (IRemind)new MaterialOrderAlert();
            }
            return null;
        }
    }
}
