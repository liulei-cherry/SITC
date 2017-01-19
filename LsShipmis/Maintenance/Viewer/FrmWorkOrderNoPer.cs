/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmWorkOrderNoPer.cs
 * 创 建 人：李景育
 * 创建时间：2009-07-02
 * 标    题：非周期性工单生成
 * 功能描述：实现非周期性工单生成的功能
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
    /// 非周期性工单生成.
    /// </summary>
    public partial class FrmWorkOrderNoPer : CommonViewer.BaseForm.FormBase
    { 
        /// <summary>
        /// 存放列与列标题的集合.
        /// </summary>
        private Dictionary<string, string> dictColumns = new Dictionary<string, string>();
        private DataTable dtbWorkInfo;
        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmWorkOrderNoPer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWorkOrderNoPer_Load(object sender, EventArgs e)
        {
            this.setComboBox();         //设置窗体所需的下拉列表框的数据源.
            this.loadData_WorkInfo();   //加载非周期性工作信息.
           
            cboPost.Text = CommonOperation.ConstParameter.LoginUserInfo.ShipHeadShipName;         
        }

        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {
            //1.设置确认人岗位下拉列表框的选项.
            DataTable dtbConfirmPost = BaseInfo.DataAccess.PostService.Instance.GetLandOrShipPostList(false, true);
            FormControlOption.Instance.SetComboBoxValue(cboConfirmPost, dtbConfirmPost, 0, 3);
            //1.5设置责任人岗位的下拉列表.
            DataTable dtbPrincipalPost = BaseInfo.DataAccess.PostService.Instance.GetLandOrShipPostList(false, false);
            FormControlOption.Instance.SetComboBoxValue(cboPost, dtbPrincipalPost, 0, 3);
        }

        /// <summary>
        /// 加载非周期性工作信息.
        /// </summary>
        private void loadData_WorkInfo()
        {
            string shipId = CommonOperation.ConstParameter.ShipId; //船舶Id

            //取得非周期性工作信息的DataTable对象.
            dtbWorkInfo = WorkInfoService.Instance.GetNoPerWorkInfo(shipId);
            bdsNoPerWorkInfo.DataSource = dtbWorkInfo;
            dgvNoPerWorkInfo.DataSource = bdsNoPerWorkInfo;

            //设置列标题.
            dictColumns.Clear();
            dictColumns.Add("workinfoname", "工作信息名称");
            dictColumns.Add("circleortimingname", "定期/定时");
            dictColumns.Add("principalpostname", "责任人岗位");
            dictColumns.Add("confirmpostname", "确认者岗位");
            dgvNoPerWorkInfo.SetDgvGridColumns(dictColumns);

            dgvNoPerWorkInfo.Columns["workinfoname"].Width = 250;
        }

        /// <summary>
        /// 当工作信息行发生变化时，显示该工作信息的工作内容.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvNoPerWorkInfo_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string workInfoId = "";     //工作信息Id
            string workInfoName = "";   //工作信息名称.
            string workInfoDetail = ""; //工作信息内容.

            workInfoId = dgvNoPerWorkInfo.Rows[e.RowIndex].Cells["workinfoid"].Value.ToString();
            workInfoName = dgvNoPerWorkInfo.Rows[e.RowIndex].Cells["workinfoname"].Value.ToString();
            workInfoDetail = dgvNoPerWorkInfo.Rows[e.RowIndex].Cells["workinfodetail"].Value.ToString();

            txtWorkOrderName.Tag = workInfoId;
            txtWorkOrderName.Text = workInfoName;
            txtWorkinfoDetail.Text = workInfoDetail;
        }

        /// <summary>
        /// 保养非周期性工单.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            string err = "";             //错误信息参数.
            string shipId = CommonOperation.ConstParameter.ShipId; //船舶Id

            WorkOrder workOrder = new WorkOrder();    //声明一个工单业务实体对象.

            if (dgvNoPerWorkInfo.Rows.Count == 0)
            {
                MessageBoxEx.Show("当前没有工作信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtWorkOrderName.Text.Trim() == "")
            {
                MessageBoxEx.Show("工单名称是必填内容！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtWorkOrderName.Focus();
                return;
            }
            if (txtWorkCompletedInfo.Text.Trim() == "" && checkBox1.Checked)
            {
                MessageBoxEx.Show("选择了直接完工的情况下,工单完成情况必须填写！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtWorkCompletedInfo.Focus();
                return;
            }
            if (cboPost.SelectedValue.ToString() == "" && checkBox1.Checked)
            {
                MessageBoxEx.Show("选择了直接完工的情况下,工单责任人岗位必须填写！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboPost.Focus();
                return;
            } 
            workOrder.WORKINFOID = txtWorkOrderName.Tag.ToString();
            workOrder.WORKORDERNAME = txtWorkOrderName.Text;
            if (checkBox1.Checked)
            {
                workOrder.WORKORDERSTATE = 4;
                workOrder.PLANEXEDATE = dtpCompletedDate.Value; 
                workOrder.COMPLETEDDATE = dtpCompletedDate.Value;
                workOrder.WORKCOMPLETEDINFO = txtWorkCompletedInfo.Text;
            }
            else
            {
                workOrder.WORKORDERSTATE = 1;
                workOrder.PLANEXEDATE = dtpCompletedDate.Value; 
            }

            workOrder.WORKEXECUTOR = CommonOperation.ConstParameter.UserName;
            workOrder.WORKDESCRIPTION = txtWorkDescription.Text;
            workOrder.PRINCIPALPOST = cboPost.SelectedValue.ToString();
            workOrder.CONFIRMPOST = cboConfirmPost.SelectedValue.ToString();
            workOrder.ISCHECKPROJECT = chkIsCheckProject.Checked ? 1 : 0;
            workOrder.ISREPAIRPROJECT = chkIsRepairProject.Checked ? 1 : 0;
            workOrder.SHIP_ID  = shipId;
 
            //更新结果报告.
            if (workOrder.Update(out err))
            {
                MessageBoxEx.Show("工单安排成功", "安排成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtWorkCompletedInfo.ReadOnly = !checkBox1.Checked;
            cboPost.Enabled = !checkBox1.Checked;
            if (checkBox1.Checked)
            {
                cboPost.Text = CommonOperation.ConstParameter.LoginUserInfo.ShipHeadShipName;
                label18.Text = "完工日期";
            }
            else
            {
                label18.Text = "预计完工日期";
            }
        }

        private void cboPost_SelectedIndexChanged(object sender, EventArgs e)
        {
            // GetPostHeader
            Post nowPost = (Post)PostService.Instance.GetOneObjectByName(cboPost.Text);

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                bdsNoPerWorkInfo.Filter = "workinfoname like '%" + textBox1.Text.Trim().Replace("'","''") + "%' ";
            }
            else
            {
                bdsNoPerWorkInfo.Filter = "";
            }
        } 
 
    }
}