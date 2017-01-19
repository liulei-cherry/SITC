using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using Cost.Viewer;

namespace Cost.Alert
{
    /// <summary>
    /// 凭证报警
    /// </summary>
    public class VoucherAlert : CommonOperation.Interfaces.IRemind
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
            FrmVoucherApproval frm = FrmVoucherApproval.Instance;
            if (CommonViewer.CommonViewConfig.MainForm != null)
                frm.MdiParent = CommonViewer.CommonViewConfig.MainForm;
            frm.BringToFront();          
            frm.Show();
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
        /// <summary>
        /// 等到报警对象.
        /// </summary>
        /// <param name="functionCode">1=审核中; 2=被打回;</param>
        /// <returns></returns>
        public static IRemind GetAlarmObject(int functionCode)
        {
            //变量定义部分.
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select cb.VOUCHER_ID ");
            sb.AppendLine(" ,case cb.CURRENT_STATE ");
            sb.AppendLine("  when 1 then '未提交'");
            sb.AppendLine("  when 2 then '审核中'");
            sb.AppendLine("  when 3 then '被打回'");
            sb.AppendLine("  else '未知状态'");
            sb.AppendLine("  end as STATE");
            sb.AppendLine(" from T_COST_VOUCHER cb");
            sb.AppendLine(" inner join T_CHECKED c on c.BUSINESS_OBJECT_ID=cb.voucher_num ");
            sb.AppendLine(" inner join T_COST_ACTUAL_COSTS t on t.VOUCHER_ID = cb.VOUCHER_ID ");
            sb.AppendLine(" inner join T_USER_SHIP u on t.ship_id=u.ship_id ");
            sb.AppendLine(" where t.ship_id = u.ship_id and u.userid  ='" + CommonOperation.ConstParameter.UserId + "' ");        
              
            if ( "机务经理岗位" == CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)
                sb.AppendLine(" and c.current_postid = '机务经理岗位'");
            else if ("总经理岗位" == CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)
                sb.AppendLine(" and c.current_postid = '总经理岗位'"); 
            else if ("机务主管岗位" == CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)
                sb.AppendLine(" and c.current_postid = '机务主管岗位'");
            else if ("财务经理岗位" == CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)
                sb.AppendLine(" and c.current_postid = '财务经理岗位'");
            else
                return null;
            if (functionCode == 1)
            {
                sb.AppendLine(" and cb.CURRENT_STATE = 2");
                message = "存在等待审核的凭证项目";
            }
            //else if (functionCode == 2)
            //{
            //    sb.AppendLine(" and cb.CURRENT_STATE = 3");
            //    message = "存在被打回的凭证项目";
            //}

            if (dbAccess.GetDataTable(sb.ToString(), out dtb, out err))
            {
                if (dtb != null && dtb.Rows.Count > 0)
                    return (IRemind)new VoucherAlert();
            }
            return null;
        }
    }
}