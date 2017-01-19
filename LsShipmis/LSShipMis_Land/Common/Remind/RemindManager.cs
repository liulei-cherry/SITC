/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：IRemind.cs
 * 创 建 人：牛振军
 * 创建时间：2008-06-16
 * 标    题：公共报管理器
 * 功能描述：管理公共报警的对象
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using LSShipMis_Land.Common.PeriodValidity;
using CommonViewer;
using CommonOperation.Interfaces;
using ItemsManage.Alert;
using StorageManage.Alert;
using SAPFunction.Services;
using Repair.Services;
using Cost.Services;
using Oil.Services;
using Cost.Alert;

namespace LSShipMis_Land.Common.Remind
{
    class RemindManager
    {
        private StatusStrip statusBar;
        private List<ValidTimeType> remind;
        public List<ToolStripItem> statusLabel;
        private List<int> remindStatus;  //初始未检查状态为0，进入timer循环为1
        private string groupUserID;

        public delegate void RemindTextShow(string text);
        public RemindTextShow remindTextShow;

        /// <summary>
        /// 构造对象.
        /// </summary>
        /// <param name="ostatus">主窗口状态栏</param>
        public RemindManager(StatusStrip ostatus, RemindTextShow remindTextShowIn)
        {
            statusBar = ostatus;
            remind = new List<ValidTimeType>();
            remindStatus = new List<int>();
            statusLabel = new List<ToolStripItem>();
            remindTextShow = remindTextShowIn;
        }

        /// <summary>
        /// 注册对象.
        /// </summary>
        /// <param name="oremind">新的报警对象</param>
        /// <param name="userId">当前登录用户的id，是CommonOperation.ConstParameter.ShipUserId</param>
        public void register(ValidTimeType oremind, string userId)
        {
            groupUserID = userId;
            if (remind.Contains(oremind)) return;

            remind.Add(oremind);
            remindStatus.Add(0);

            ToolStripItem newLabel = new ToolStripLabel();
            newLabel.AccessibleName = oremind.ToString(); //记住当前报告的类型.
            newLabel.BackColor = System.Drawing.Color.Transparent;
            newLabel.MouseHover += new EventHandler(newLabel_MouseHover);
            newLabel.MouseLeave += new EventHandler(newLabel_MouseLeave);
            statusLabel.Add(newLabel);
            statusBar.Items.Insert(3, newLabel);
            //这里需要设置状态条的状态.

            setStatus(remindColor.Green, newLabel);
            newLabel.Click += new EventHandler(newLabel_Click);
        }

        void newLabel_MouseLeave(object sender, EventArgs e)
        {
            if (remindTextShow != null) remindTextShow("");
        }

        void newLabel_MouseHover(object sender, EventArgs e)
        {
            if (remindTextShow != null && ((ToolStripItem)sender).Text != null)
                remindTextShow(((ToolStripItem)sender).Text);
        }

        #region old use sys statuse bar
        /// <summary>
        /// 打开查看窗体方法绑定委托.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void newLabel_Click(object sender, EventArgs e)
        {
            if (((ToolStripItem)(sender)).Tag != null) ((IRemind)((ToolStripItem)(sender)).Tag).viewInfo();
        }

        /// <summary>
        /// 设置图标.
        /// </summary>
        /// <param name="col">颜色</param>
        /// <param name="tol">状态条对象</param>
        private void setStatus(remindColor col, ToolStripItem tol)
        {
            switch (col)
            {
                case remindColor.Green:
                    tol.Image = null;
                    tol.Visible = false;
                    tol.Width = 0;
                    break;
                case remindColor.Orange:
                    tol.Image = Properties.Resources.orange;
                    tol.Visible = true;
                    tol.Width = 16;
                    break;
                case remindColor.Yellow:
                    tol.Image = Properties.Resources.yellow;
                    tol.Visible = true;
                    tol.Width = 16;
                    break;
                default:
                    tol.Image = Properties.Resources.red;
                    tol.Visible = true;
                    tol.Width = 16;
                    break;
            }
        }

        /// <summary>
        /// 检查对象的报警状态.
        /// </summary>
        public void checkedStatus()
        {
            int total = remind.Count;
            string tag = "";

            for (int i = 0; i < total; i++)
            {
                if (remindStatus[i] == 0)  //如果对象正在循环体内进行校验，则不进行调用.
                {
                    remindStatus[i] = 1;

                   
                    IRemind bindobj = getAnObject(statusLabel[i].AccessibleName);

                    if (null == bindobj)
                    {
                        remindStatus[i] = 0;
                        statusLabel[i].Visible = false;
                        statusLabel[i].Width = 0;
                    }
                    else
                    {
                        remindColor ocolor = bindobj.getStatus(out tag);
                        statusLabel[i].DisplayStyle = ToolStripItemDisplayStyle.Image;
                        statusLabel[i].Tag = bindobj;
                        statusLabel[i].Text = tag;
                        setStatus(ocolor, statusLabel[i]);
                        remindStatus[i] = 0;
                    }
                }
            }
        }

        #endregion

        private IRemind getAnObject(string vType)
        {
            IRemind rem = null;
            if (vType == ValidTimeType.SparePurchaseApplyCheck.ToString())
            {
                rem = SpareApplyAlert.GetAlarmObject(1);//备件申请等待审核的报警.
            }
            else if (vType == ValidTimeType.SparePurchaseApplyNotComplete.ToString())
            {
                rem = SpareApplyAlert.GetAlarmObject(2);//备件申请未填写完毕报警.
            }
            else if (vType == ValidTimeType.SparePurchaseApplyReject.ToString())
            {
                rem = SpareApplyAlert.GetAlarmObject(3);//备件申请被打回的报警.
            }
            else if (vType == ValidTimeType.SparePurchaseOrderCheck.ToString())
            {
                rem = SpareOrderAlert.GetAlarmObject(1);//备件订单等待审核的报警.
            }
            else if (vType == ValidTimeType.SparePurchaseOrderNotComplete.ToString())
            {
                rem = SpareOrderAlert.GetAlarmObject(2);//备件订单未填写完毕报警.
            }
            else if (vType == ValidTimeType.SparePurchaseOrderReject.ToString())
            {
                rem = SpareOrderAlert.GetAlarmObject(3);//备件订单被打回的报警.
            }
            else if (vType == ValidTimeType.SpareIn.ToString())
            {
                rem = SpareInAlert.GetAlarmObject(groupUserID);//存在等待审核的备件入库单.
            }
            else if (vType == ValidTimeType.SpareOut.ToString())
            {
                rem = SpareOutAlert.GetAlarmObject(groupUserID);//备件出库.
            }
            else if (vType == ValidTimeType.SpareStockck.ToString())
            {
                rem = SpareStockckAlert.GetAlarmObject(groupUserID);//备件盘点.
            }
            else if (vType == ValidTimeType.MaterialPurchaseApplyCheck.ToString())
            {
                rem = MaterialApplyAlert.GetAlarmObject(1);//物料申请等待审核的报警.
            }
            else if (vType == ValidTimeType.MaterialPurchaseApplyNotComplete.ToString())
            {
                rem = MaterialApplyAlert.GetAlarmObject(2);//物料申请未填写完毕报警.
            }
            else if (vType == ValidTimeType.MaterialPurchaseApplyReject.ToString())
            {
                rem = MaterialApplyAlert.GetAlarmObject(3);//物料申请被打回的报警.
            }
            else if (vType == ValidTimeType.MaterialPurchaseOrderCheck.ToString())
            {
                rem = MaterialOrderAlert.GetAlarmObject(1);//物料订单等待审核的报警.
            }
            else if (vType == ValidTimeType.MaterialPurchaseOrderNotComplete.ToString())
            {
                rem = MaterialOrderAlert.GetAlarmObject(2);//物料订单未填写完毕报警.
            }
            else if (vType == ValidTimeType.MaterialPurchaseOrderReject.ToString())
            {
                rem = MaterialOrderAlert.GetAlarmObject(3);//物料订单被打回的报警.
            }
            else if (vType == ValidTimeType.MaterialIn.ToString())
            {
                rem = MaterialInAlert.GetAlarmObject(groupUserID);//存在等待审核的物料入库单.
            }
            else if (vType == ValidTimeType.MaterialOut.ToString())
            {
                rem = MaterialOutAlert.GetAlarmObject(groupUserID);//物料出库.
            }
            else if (vType == ValidTimeType.MaterialStockck.ToString())
            {
                rem = MaterialStockckAlert.GetAlarmObject(groupUserID);//物料盘点.
            }
            else if (vType == ValidTimeType.RepairApplyAlertNotComplete.ToString())
            {
                rem = RepairApplyAlert.GetAlarmObject(1);//修理申请未填写完毕.
            }
            else if (vType == ValidTimeType.RepairApplyAlertCheck.ToString())
            {
                rem = RepairApplyAlert.GetAlarmObject(2);//修理申请等待审核.
            }
            else if (vType == ValidTimeType.HOilApplyAlertCheck.ToString())
            {
                rem = HOilApplyAlert.GetAlarmObject();//油料申请等待审核.
            }
            else if (vType == ValidTimeType.VoucherAlertCheck.ToString())
            {
                rem = VoucherAlert.GetAlarmObject(1);//存在等待审核的凭证项目.
            }
            //else if (vType == ValidTimeType.VoucherAlertCheckReject.ToString())
            //{
            //    rem = VoucherAlert.GetAlarmObject(2);//存在被打回的凭证项目.
            //}
            else if (vType == ValidTimeType.VoucherAlertPassCheckOnce.ToString())
            {
                rem = VoucherAlertOnce.GetAlarmObject();//凭证项目通过一次性报警
            }
            else if (vType == ValidTimeType.VoucherAlertNotPassCheckOnce.ToString())
            {
                rem = VoucherNotPassAlertOnce.GetAlarmObject();//凭证项目被打回一次性报警
            }
            else if (vType == ValidTimeType.ShipCert.ToString())
            {
                rem = ShipCertification.Services.ShipCertAlert.getHighestAlarmObject(groupUserID);//船舶证书.
            }
            else if (vType == ValidTimeType.WorkOrder.ToString())
            {
                rem = WorkOrderAlert.getHighestAlarmObject(groupUserID);//工单报警.
            }
            else if (vType == ValidTimeType.WorkOrderConfirm.ToString())
            {
                rem = WorkOrderConfirmAlert.getHighestAlarmObject(groupUserID);//工单确认报警.
            }
            else if (vType == ValidTimeType.SAPMapping.ToString())
            {
                rem = MappingAlert.GetAlarmObject(groupUserID);//sap映射报警.
            }
            else if (vType == ValidTimeType.SAPMessage.ToString())
            {
                rem = MessageAlert.GetAlarmObject();//sap报文报警.
            }
            else if (vType == ValidTimeType.RepairApplyAlertCheckOnce.ToString())
            {
                rem = RepairApplyAlertOnce.GetAlarmObject();//修理申请审核的一次性报警.
            }
            else if (vType == ValidTimeType.HOilApplyAlertCheckOnce.ToString())
            {
                rem = HOilApplyAlertOnce.GetAlarmObject();//油料申请审核的一次性报警.
            }
            else if (vType == ValidTimeType.MaterialPurchaseApplyCheckOnce.ToString())
            {
                rem = MaterialApplyAlertOnce.GetAlarmObject();//物料申请审核的一次性报警.
            }
            else if (vType == ValidTimeType.MaterialPurchaseOrderCheckOnce.ToString())
            {
                rem = MaterialOrderAlertOnce.GetAlarmObject();//物料订单审核的一次性报警.
            }
            else if (vType == ValidTimeType.SparePurchaseApplyCheckOnce.ToString())
            {
                rem = SpareApplyAlertOnce.GetAlarmObject();//备件申请审核的一次性报警.
            }
            else if (vType == ValidTimeType.SparePurchaseOrderCheckOnce.ToString())
            {
                rem = SpareOrderAlertOnce.GetAlarmObject();//备件订单审核的一次性报警.
            }
            else if (vType == ValidTimeType.CostNotVoucher.ToString())
            {
                rem = CostNotVoucherAlert.GetAlarmObject();//存在未产生单日凭证的费用项目.
            }
            else if (vType == ValidTimeType.SpareNotVoucher.ToString())
            {
                //rem = SpareNotVoucherAlert.GetAlarmObject(); //zhangy注释与2013-7-29
            }
            else if (vType == ValidTimeType.MaterialNotVoucher.ToString())
            {
                //rem = MaterialNotVoucherAlert.GetAlarmObject();//zhangy注释与2013-7-29
            }
            else if (vType == ValidTimeType.OilNotVoucher.ToString())
            {
                //rem = OilNotVoucherAlert.GetAlarmObject();//zhangy注释与2013-7-29
            }
            else if (vType == ValidTimeType.RepairNotVoucher.ToString())
            {
                //rem = RepairNotVoucherAlert.GetAlarmObject();//zhangy注释与2013-7-29
            }
            else if (vType == ValidTimeType.SpareInBySpareApply.ToString())
            {
                rem = SpareInAlertOnce.GetSpareInAlarmObject();//zhangy-2013-7-29
            }
            else if (vType == ValidTimeType.MaterialInByMaterialApply.ToString())
            {
                rem = MaterialInAlertOnce.GetMaterialInAlarmObject();//zhangy-2013-7-29
            }
            return rem;
        }

    }
}
