/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：WorkOrderAlert.cs
 * 创 建 人：李景育
 * 创建时间：2009-06-15
 * 标    题：工单报警接口模块
 * 功能描述：实现工单报警接口模块的业务类
 * 修 改 人： 
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using Maintenance.Viewer;

namespace ItemsManage.Alert
{
    /// <summary>
    /// 工单报警业务类.
    /// </summary>
    public class WorkOrderAlert : CommonOperation.Interfaces.IRemind
    {
        private static string remindShipid = "";
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
            tag = "工单报警";
            return remindColor.Red;
        }

        /// <summary>
        /// 点击报警图标后需要打开的窗体或处理的事件.
        /// </summary>
        public void viewInfo()
        {
            FrmWorkOrderTrace frm = FrmWorkOrderTrace.Instance;
            if (CommonViewer.CommonViewConfig.MainForm != null) frm.MdiParent = CommonViewer.CommonViewConfig.MainForm;
            frm.cboWorkOrderState.Text = "全部";
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                frm.ucShipSelect1.SelectedId(remindShipid);
            }
            frm.BringToFront();
            frm.Show();
        }

        public static IRemind getHighestAlarmObject(string userId)
        {
            //变量定义部分.
            DataTable dtb = new DataTable();    //定义一个DataTable对象.
            string sMidErrMessage = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.
            string shipHeadShipId = "";         //当前登录者的岗位Id

            shipHeadShipId = CommonOperation.ConstParameter.LoginUserInfo.PostId;

            //需要报警的最早的最高级别.
            sSql += "select top 1 workorderid,w.ship_id from v_workorder as w ";

            if (CommonOperation.ConstParameter.IsLandVersion)
                sSql += " inner join T_USER_SHIP us on us.ship_id=w.ship_id  and us.userid = '" + CommonOperation.ConstParameter.UserId + "'";

            sSql += "where principalpost = '" + shipHeadShipId + "' and ";
            sSql += "case when circleortiming = 3 and circlealertstate > timingalertstate then circlealertstate ";
            sSql += "     when circleortiming = 3 and circlealertstate <= timingalertstate then timingalertstate ";
            sSql += "     else ctalertstate end > 0 and (WORKORDERSTATE=1 or WORKORDERSTATE=2)";

            dbAccess.GetDataTable(sSql, out dtb, out sMidErrMessage);

            if (dtb != null && dtb.Rows.Count > 0)
            {
                remindShipid = dtb.Rows[0]["ship_id"].ToString();
                return (IRemind)new WorkOrderAlert();
            }
            else
            {
                return null;
            }
        }
    }
}