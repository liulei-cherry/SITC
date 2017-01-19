/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有 * 文 件 名：ShipCertAlert.cs
 * 创 建 人：李景育 * 创建时间：2008-04-20
 * 标    题：船舶证书报警接口模块
 * 功能描述：实现船舶证书报警接口模块的业务类 * 修 改 人： 
 * 修改时间： * 修改内容： ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using ShipCertification.Services;
using ShipCertification.Viewer;

namespace ShipCertification.Services
{
    /// <summary>
    /// 证书报警业务类.
    /// </summary>
    public class ShipCertAlert : CommonOperation.Interfaces.IRemind
    {
        /// <summary>
        /// 定义数据操作层对象.
        /// </summary>
        private static IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();

        /// <summary>
        /// 当前证书的报警状态.
        /// </summary>
        private int shipCertStatus;

        #region 属性过程

        public int ShipCertStatus
        {
            get { return shipCertStatus; }
            set { shipCertStatus = value; }
        }

        #endregion

        /// <summary>
        /// 当前对象的报警颜色，以及鼠标tag信息.
        /// </summary>
        /// <param name="tag">图标上显示的鼠标tag</param>
        /// <returns>报警颜色值</returns>
        public remindColor getStatus(out string tag)
        {
            tag = "船舶证书报警";

            switch (this.ShipCertStatus)
            {
                case 2:
                    return remindColor.Yellow;
                case 3:
                    return remindColor.Red;
                default:
                    return remindColor.Yellow;
            }
        }

        /// <summary>
        /// 点击报警图标后需要打开的窗体或处理的事件.
        /// </summary>
        public void viewInfo()
        {
            FrmShipCertificationManage frm = FrmShipCertificationManage.Instance;
            if (CommonViewer.CommonViewConfig.MainForm != null) frm.MdiParent = CommonViewer.CommonViewConfig.MainForm;
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.BringToFront();
            frm.Show();
        }

        public static IRemind getHighestAlarmObject(string userId)
        {
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.

            //需要报警的最早的最高级别.

            sSql += "select max(case when MATUREDATE < getdate() then 3 "
            + " when datediff(dd,Getdate(),MATUREDATE)< ALERTDAYS then 2 else 1 end)"
            + " \rfrom T_Ship_Cert_Register ";

             if (CommonOperation.ConstParameter.IsLandVersion)
                 sSql += " inner join T_USER_SHIP us on us.ship_id=T_Ship_Cert_Register.ship_id  and us.userid = '" + CommonOperation.ConstParameter.UserId + "'";

             sSql += "\rwhere  SHIPCERTTYPE in (2,3)";

            string statusNo;
            dbAccess.GetString(sSql, out statusNo, out err);

            if (!string.IsNullOrEmpty(statusNo) && (statusNo == "2" || statusNo == "3"))
            {
                ShipCertAlert shipCertAlert = new ShipCertAlert();
                shipCertAlert.ShipCertStatus = int.Parse(statusNo);
                return (IRemind)shipCertAlert;
            }
            else
            {
                return null;
            }
        }
    }
}