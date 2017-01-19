/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmWorkOrderCancel.cs
 * 创 建 人：李景育
 * 创建时间：2009-06-01
 * 标    题：工单信息免做
 * 功能描述：实现工单信息免做的功能
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Maintenance.Services;
using Maintenance.DataObject;
using CommonViewer.BaseControl;

namespace Maintenance.Viewer
{
    /// <summary>
    /// 工单信息免做.
    /// </summary>
    public partial class FrmWorkOrderCancel : CommonViewer.BaseForm.FormBase
    {
        /// <summary>
        /// 工单Id
        /// </summary>
        private string workOrderId = "";

        /// <summary>
        /// 工单名称.
        /// </summary>
        private string workOrderName = "";

        /// <summary>
        /// 工单状态.
        /// </summary>
        private string workOrderStateName = "";
        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="workOrderId">工单Id</param>
        /// <param name="workOrderName">工单名称</param>
        /// <param name="workOrderState">工单状态</param>
        public FrmWorkOrderCancel(string workOrderId, string workOrderName, string workOrderStateName)
        {
            InitializeComponent();
            this.workOrderId = workOrderId;
            this.workOrderName = workOrderName;
            this.workOrderStateName = workOrderStateName;
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWorkOrderCancel_Load(object sender, EventArgs e)
        {
            lblWorkOrderName.Text = workOrderName;
            lblWorkOrderState.Text = workOrderStateName;
        }

        /// <summary>
        /// 执行免做功能.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.

            if (txtWorkCompletedInfo.Text.Trim() == "")
            {
                MessageBoxEx.Show("请填写工单免做原因！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtWorkCompletedInfo.Focus();
                return;
            }

            if (MessageBoxEx.Show("确定要申请当前工单免做吗？", "确认框", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }

            //更新结果报告.
            if (WorkOrderService.Instance.CancelWorkOrder(workOrderId, txtWorkCompletedInfo.Text, out err))
            {
                WorkOrder newWorkOrder = (WorkOrder)WorkOrderService.Instance.GetOneObjectById(workOrderId);
                if (newWorkOrder != null && !newWorkOrder.IsWrong && newWorkOrder.ISTEMPWORKORDER != 1 && !string.IsNullOrEmpty(newWorkOrder.WORKINFOID)
                && !checkBox1.Checked && MessageBoxEx.Show("点击'是'将为当前工单安排下一次计划,\r如果暂时无法确定此工单的计划时间,可以点'否',\r但以后需要对此工单重新首排!"
                    , "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    List<string> lstNewWorkOrderIds = new List<string>();
                    newWorkOrder.WORKORDERID = "";
                    newWorkOrder.WORKORDERSTATE = 1;
                    newWorkOrder.WORKDESCRIPTION = "";
                    newWorkOrder.PLANEXEDATE = DateTime.Now.AddMonths(6);
                    if (newWorkOrder.Update(out err))
                    {
                        lstNewWorkOrderIds.Add(newWorkOrder.GetId());
                        FrmWorkOrderNewEdit frmNewEdit = new FrmWorkOrderNewEdit(lstNewWorkOrderIds);
                        frmNewEdit.ShowDialog();
                    }

                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBoxEx.Show(err, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// 关闭窗体.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}