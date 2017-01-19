/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：WorkOrderConfirmAlert.cs
 * 创 建 人：李景育
 * 创建时间：2009-06-15
 * 标    题：工单确认报警接口模块
 * 功能描述：实现工单确认报警接口模块的业务类
 * 修 改 人： 
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonOperation.Interfaces;
using Maintenance.Viewer;
using CommonOperation.Functions;

namespace ItemsManage.Alert
{
    /// <summary>
    /// 工单确认报警业务类.
    /// </summary>
    public class WorkOrderSpareNotEnoughAlert : CommonOperation.Interfaces.IRemind
    {
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
            tag = "工单需要备件库存不够";
            return remindColor.Orange;
        }

        /// <summary>
        /// 点击报警图标后需要打开的窗体或处理的事件.
        /// </summary>
        public void viewInfo()
        {
            FrmWorkOrderTrace frm = FrmWorkOrderTrace.Instance;
            if (CommonViewer.CommonViewConfig.MainForm != null) frm.MdiParent = CommonViewer.CommonViewConfig.MainForm;
            frm.BringToFront();
            frm.Show();
        }

        public static IRemind getWorkOrderSpareNotEnoughInfo(string userId)
        {
            //变量定义部分.
            DataTable dtb = new DataTable();    //定义一个DataTable对象.
            string sMidErrMessage = "";         //错误信息返回参数.
            string sSql;                       //查询数据所需的SQL语句.
            string shipHeadShipId = "";         //当前登录者的岗位Id

            shipHeadShipId = CommonOperation.ConstParameter.LoginUserInfo.PostId;

            //需要报警的最早的最高级别.
            sSql = "select top 1 t1.workorderid from t_workorder t1 inner join T_WORKINFO_USESPARE t2 on t1.WORKINFOID = t2.WORKINFOID "
                 + "\rleft join (select spare_id,ship_id, sum(STOCKSAll) stocks from V_SPARE_STOCKS group by spare_id,ship_id) t3 on t2.spareid = t3.spare_id and t1.ship_id = t3.ship_id ";

            if (CommonOperation.ConstParameter.IsLandVersion)
                sSql += " inner join T_USER_SHIP us on us.ship_id=t_workorder.ship_id  and us.userid = '" + CommonOperation.ConstParameter.UserId + "'";

            sSql += "\rwhere t1.workorderstate in (4,5,6) and (t1.confirmpost = '" + shipHeadShipId + "' or t1.principalpost = '" + shipHeadShipId + "' "
                   + "\ror " + (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER || CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS ? "'1'" : "'0'")
                   + "='1')and t2.defaultusecount - isnull(t3.stocks,0) > 0";
            dbAccess.GetDataTable(sSql, out dtb, out sMidErrMessage);

            if (dtb != null && dtb.Rows.Count > 0)
            {
                return (IRemind)new WorkOrderSpareNotEnoughAlert();
            }
            else
            {
                return null;
            }
        }
    }
}