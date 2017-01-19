/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmWorkOrderTraceEdit.cs
 * 创 建 人：李景育
 * 创建时间：2009-06-01
 * 标    题：工单信息修改
 * 功能描述：实现工单信息修改的功能
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
using Maintenance.DataObject;
using Maintenance.Services;
using CommonViewer.BaseControlService;
using BaseInfo.Objects;
using BaseInfo.DataAccess;
using CommonViewer.BaseControl;

namespace Maintenance.Viewer
{
    /// <summary>
    /// 工单信息修改.
    /// </summary>
    public partial class FrmWorkOrderTraceEdit : CommonViewer.BaseForm.FormBase
    {
        string err;
        /// <summary>
        /// 工单业务实体对象.
        /// </summary>
        private WorkOrder workOrder = null;

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="workOrder">工单业务实体对象</param>
        public FrmWorkOrderTraceEdit(WorkOrder workOrder)
        {
            InitializeComponent();
            this.workOrder = workOrder;
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWorkOrderTraceEdit_Load(object sender, EventArgs e)
        {
            this.setComboBox();     //设置窗体所需的下拉列表框的数据源.
            this.setFormFields();   //设置窗体上的表单信息.
        }

        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {
            //1.设置责任人岗位下拉列表框的选项.
            DataTable dtbPrincipalPost = BaseInfo.DataAccess.PostService.Instance.GetLandOrShipPostList(false, false);
            FormControlOption.Instance.SetComboBoxValue(cboPrincipalPost, dtbPrincipalPost, 0, 3);

            //2.设置确认人岗位下拉列表框的选项.
            DataTable dtbConfirmPost = BaseInfo.DataAccess.PostService.Instance.GetLandOrShipPostList(false, true);
            FormControlOption.Instance.SetComboBoxValue(cboConfirmPost, dtbConfirmPost, 0, 3);
        }

        /// <summary>
        /// 根据责任人岗位设置其确认人岗位.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboPrincipalPost_DropDownClosed(object sender, EventArgs e)
        {
            string sPrincipalPostName = cboPrincipalPost.Text;
            Post thePost = (Post)PostService.Instance.GetOneObjectByName(sPrincipalPostName);
            Post theLeaderPost;
            if (thePost != null && PostService.Instance.GetDepartLeaderPost(thePost.DEPARTMENTID, out theLeaderPost, out err) && theLeaderPost != null)
            {
                cboConfirmPost.Text = theLeaderPost.POSTNAME;
            }
            else
            {
                cboConfirmPost.Text = "";
            }
        }

        /// <summary>
        /// 设置窗体上的表单信息.
        /// </summary>
        private void setFormFields()
        {
            workOrder.FillThisObject();
            WorkOrderService.Instance.fillAllWorkOrderInfo(workOrder, out err);
            //根据定期、定时性质来设置界面上的一些元素可用与不可用.
            if (workOrder.TheWorkInfo != null)
            {
                if ((int)workOrder.TheWorkInfo.CIRCLEORTIMING == 4)
                {
                    txtPlanExeDate.Enabled = false;
                }
            }

            //设置表单上的控件的值.
            this.txtCircleOrTiming.Text = workOrder.Circleortimingname;
            this.txtWorkOrderState.Text = workOrder.Workorderstatename;
            this.chkIsTempWorkOrder.Checked = workOrder.ISTEMPWORKORDER == 1 ? true : false;
            this.txtWorkOrderName.Text = workOrder.WORKORDERNAME;
            this.txtInsteadWkName.Text = workOrder.Insteadedwkname;
            if (workOrder.PLANEXEDATE.ToString("yyyy-MM-dd") != "0001-01-01")
            {
                this.txtPlanExeDate.TextBox.Text = workOrder.PLANEXEDATE.ToString("yyyy-MM-dd");
            }
            if (workOrder.COMPLETEDDATE.ToString("yyyy-MM-dd") != "0001-01-01")
            {
                this.txtCompletedDate.Text = workOrder.COMPLETEDDATE.ToString("yyyy-MM-dd");
            }

            if (workOrder.PRINCIPALPOST == null)
            {
                this.cboPrincipalPost.SelectedIndex = -1;
            }
            else
            {
                this.cboPrincipalPost.SelectedValue = workOrder.PRINCIPALPOST;
            }

            if (workOrder.CONFIRMPOST == null)
            {
                this.cboConfirmPost.SelectedIndex = -1;
            }
            else
            {
                this.cboConfirmPost.SelectedValue = workOrder.CONFIRMPOST;
            }

            this.txtWorkExecutor.Text = workOrder.WORKEXECUTOR;
            this.txtWorkConfirmor.Text = workOrder.WORKCONFIRMOR;
            this.chkIsCombinedOrder.Checked = workOrder.ISCOMBINEDORDER == 1 ? true : false;
            this.chkInsteadWk.Checked = string.IsNullOrEmpty(workOrder.INSTEADEDWKID) ? false : true;
            this.chkIsCheckProject.Checked = workOrder.ISCHECKPROJECT == 1 ? true : false;
            this.chkIsRepairProject.Checked = workOrder.ISREPAIRPROJECT == 1 ? true : false;

            if (workOrder.TheWorkInfo != null)
                txtWorkinfoDetail.Text = workOrder.TheWorkInfo.WORKINFODETAIL;

            this.txtWorkCompletedInfo.Text = workOrder.WORKCOMPLETEDINFO;
            this.txtWorkDescription.Text = workOrder.WORKDESCRIPTION;
        }

        /// <summary>
        /// 保存修改过的信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.

            if (this.frmValidate() == false)
            {
                return;
            }

            workOrder.WORKORDERNAME = txtWorkOrderName.Text;
            if (txtPlanExeDate.TextBox.Text != "")
            {
                workOrder.PLANEXEDATE = DateTime.Parse(txtPlanExeDate.TextBox.Text);
                workOrder.CIRCLEFRONTLIMITDATE = new DateTime(workOrder.PLANEXEDATE.Year, workOrder.PLANEXEDATE.Month, 1);
                workOrder.CIRCLEBACKLIMITDATE = new DateTime(workOrder.PLANEXEDATE.Year, workOrder.PLANEXEDATE.Month, 1).AddMonths(1).AddDays(-1);
            }
            workOrder.TIMINGFRONTLIMITHOURS = workOrder.NEXTVALUE - 200;
            workOrder.TIMINGBACKLIMITHOURS = workOrder.NEXTVALUE + 200;
            workOrder.PRINCIPALPOST = cboPrincipalPost.SelectedValue.ToString();
            workOrder.CONFIRMPOST = cboConfirmPost.SelectedValue.ToString();
            workOrder.ISCHECKPROJECT = chkIsCheckProject.Checked ? 1 : 0;
            workOrder.ISREPAIRPROJECT = chkIsRepairProject.Checked ? 1 : 0;
            workOrder.WORKCOMPLETEDINFO = txtWorkCompletedInfo.Text;
            workOrder.WORKDESCRIPTION = txtWorkDescription.Text;

            //更新结果报告.
            if (workOrder.Update(out err))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBoxEx.Show(err, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// 窗体表单上的信息校验.
        /// </summary>
        /// <returns>校验通过返回true，否则返回false</returns>
        private bool frmValidate()
        {
            if (txtWorkOrderName.Text.Trim() == "")
            {
                MessageBoxEx.Show("工单名称是必填项！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtWorkOrderName.Focus();
                return false;
            }

            if ((txtCircleOrTiming.Text == "定期" || txtCircleOrTiming.Text == "定期和定时") && txtPlanExeDate.TextBox.Text.Trim() == "")
            {
                MessageBoxEx.Show("当前工单的执行日期是必填项！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPlanExeDate.Focus();
                return false;
            }
            if (cboPrincipalPost.Text == "")
            {
                MessageBoxEx.Show("责任人岗位是必选项！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboPrincipalPost.Focus();
                return false;
            }

            if (cboConfirmPost.Text == "")
            {
                MessageBoxEx.Show("确认人岗位是必选项！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboConfirmPost.Focus();
                return false;
            }

            return true;
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