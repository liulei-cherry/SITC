/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmWorkOrderTempAdd.cs
 * 创 建 人：李景育
 * 创建时间：2009-05-31
 * 标    题：增加临时工单
 * 功能描述：实现增加临时工单的功能
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
using CommonViewer.BaseControlService;
using BaseInfo.Objects;
using BaseInfo.DataAccess;
using CommonViewer.BaseControl;

namespace Maintenance.Viewer
{
    /// <summary>
    /// 增加临时工单.
    /// </summary>
    public partial class FrmWorkOrderTempAdd : CommonViewer.BaseForm.FormBase
    {
        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmWorkOrderTempAdd()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWorkOrderTempAdd_Load(object sender, EventArgs e)
        {
            this.setComboBox();//设置窗体所需的下拉列表框的数据源.
            dtpPlanExeDate.Value = DateTime.Now;
            checkBox1.Checked = false;
            cboPrincipalPost.SelectedValue = CommonOperation.ConstParameter.LoginUserInfo.PostId;
        }

        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {
            //1.设置确认人岗位下拉列表框的选项.
            DataTable dtbConfirmPost = BaseInfo.DataAccess.PostService.Instance.GetLandOrShipPostList(false,true );
            FormControlOption.Instance.SetComboBoxValue(cboConfirmPost, dtbConfirmPost, 0, 3);   
            //1.5设置责任人岗位的下拉列表.
            DataTable dtbPrincipalPost = BaseInfo.DataAccess.PostService.Instance.GetLandOrShipPostList(false, false);
            FormControlOption.Instance.SetComboBoxValue(cboPrincipalPost, dtbPrincipalPost, 0, 3);
        }

        /// <summary>
        /// 保存临时工单.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.
            int isCheckProject = 0;     //是否是检验项目.
            int isRepairProject = 0;    //是否是修理项目.

            if (txtWorkOrderName.Text.Trim() == "")
            {
                MessageBoxEx.Show("工单名称是必填项！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtWorkOrderName.Focus();
                return;
            }
            if (txtWorkDescription.Text.Trim() == "")
            {
                MessageBoxEx.Show("工单内容是必填项！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtWorkDescription.Focus();
                return;
            }

            if (chkIsCheckProject.Checked) isCheckProject = 1;
            if (chkIsRepairProject.Checked) isRepairProject = 1;

            //更新结果报告.
            if (WorkOrderService.Instance.AddTempWorkOrder(checkBox1.Checked,CommonOperation.ConstParameter.ShipId, txtWorkOrderName.Text, cboPrincipalPost.SelectedValue.ToString(), cboConfirmPost.SelectedValue.ToString(),
                                              dtpPlanExeDate.Value, isCheckProject, isRepairProject, txtWorkDescription.Text,txtWorkCompletedInfo.Text, out err))
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
        /// 关闭窗体.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cboPrincipalPost_SelectedIndexChanged(object sender, EventArgs e)
        {
            // GetPostHeader
            Post nowPost = (Post)PostService.Instance.GetOneObjectByName(cboPrincipalPost.Text);

            if (nowPost != null && !nowPost.IsWrong)
            {
                Post leaderPost;
                string err;
                if (PostService.Instance.GetPostHeader(nowPost, out leaderPost, out err))
                {
                    cboConfirmPost.Text = leaderPost.POSTNAME;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtWorkCompletedInfo.ReadOnly = !checkBox1.Checked;
            cboPrincipalPost.Enabled = !checkBox1.Checked;
            if (checkBox1.Checked)
            {
                cboPrincipalPost.SelectedValue = CommonOperation.ConstParameter.LoginUserInfo.PostId;
                label3.Text = "完工日期";
            }
            else
            {
                label3.Text = "预计完工日期";
            }
        }
    }
}