using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonViewer.BaseControl;
using CommonViewer.BaseForm;
using ShipMisZHJ_WorkFlow.BusinessClasses;
using ShipMisZHJ_WorkFlow.Services;

namespace ShipMisZHJ_WorkFlow.Forms
{
    /// <summary>
    /// 业务审核窗体.
    /// </summary>
    public partial class FrmCheck : Form
    {
        /// <summary>
        /// 状态 1.审核中,2.被打回一级,3.结束, 4提交被彻底打回 -1,状态有问题，直接关闭
        /// </summary>
        public int Current_State = 0;

        List<T_Checked> checkList = new List<T_Checked>();

        /// <summary>
        /// 0:点选; 1:多选;
        /// </summary>
        private int mode = 0;
        private FrmCheck()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 接收审核业务Id
        /// </summary>
        /// <param name="businessId">业务id</param> 
        /// <param name="mode">审批方式：1、普通方式；2、提前结束方式; 3.仅查看模式</param>
        public FrmCheck(CheckObj checkObj, int mode = 1)
            : this(new List<CheckObj> { checkObj }, mode)
        { }

        /// <summary>
        /// 接收审核业务Id
        /// </summary>
        /// <param name="paramBusinessCodeList">一组业务id</param> 
        /// <param name="mode">审批方式：1、普通方式；2、提前结束方式; 3.仅查看模式</param>
        public FrmCheck(List<CheckObj> paramCheckObjList, int mode = 1)
            : this()
        {
            string err;
            foreach (CheckObj item in paramCheckObjList)
            {
                T_Checked check = T_CheckedService.Instance.GetObjectByBusinessCheckObj(item, out err);
                if (check == null)
                {
                    Current_State = -1;
                    MessageBoxEx.Show("没有审批记录");
                    return;
                }
                this.checkList.Add(T_CheckedService.Instance.GetObjectByBusinessCheckObj(item, out err));
            }
            this.mode = mode;
            btnAgreeEnd.Visible = (mode == 2);
            EnableInput(mode != 3);
        }

        private void EnableInput(bool enable)
        {
            splitContainer1.Panel2Collapsed = !enable;
            if (!enable)
            {
                btnAgreeEnd.Visible = false;
                btnAgree.Visible = false;
                btnDisagree.Visible = false;
            }
        }

        private void ShowCheckHistory()
        {
            if (tabList.TabCount > 0) return;

            foreach (T_Checked oneCheck in checkList)
            {
                InsertOneCheck(oneCheck);
            }
        }
        private void InsertOneCheck(T_Checked oneCheck)
        {  

            TabPage tabPageTemp = new System.Windows.Forms.TabPage();
            this.tabList.Controls.Add(tabPageTemp);
            tabPageTemp.Location = new System.Drawing.Point(4, 22);
            tabPageTemp.Name = "tabPage1";
            tabPageTemp.Padding = new System.Windows.Forms.Padding(3);
            tabPageTemp.Size = new System.Drawing.Size(815, 382);
            tabPageTemp.TabIndex = 0;
            tabPageTemp.Text = oneCheck.BusinessMainInfo;
            tabPageTemp.UseVisualStyleBackColor = true;


            TextBox txtTmp = new System.Windows.Forms.TextBox();
            tabPageTemp.Controls.Add(txtTmp);
            // 
            // textBox1
            // 
            txtTmp.Dock = System.Windows.Forms.DockStyle.Fill;
            txtTmp.Location = new System.Drawing.Point(3, 3);
            txtTmp.Multiline = true;
            txtTmp.Name = "txtTmp" + oneCheck.BusinessMainInfo;
            txtTmp.Size = new System.Drawing.Size(809, 376);
            txtTmp.TabIndex = 0;
            txtTmp.Text = oneCheck.BusinessDetailInfo;
            txtTmp.Font = new Font ("宋体",12);
        }
        private void FrmCheck_Shown(object sender, EventArgs e)
        {
            if (Current_State == -1)
            {
                this.Close();
                return;
            }
            if (checkList.Count > 0) ShowCheckHistory();
            if (mode == 1 || mode == 2)
            {
                if (checkList.Count == 0 || checkList.Contains(null))
                {
                    MessageBox.Show("不存在审批数据");
                    this.Close();
                    return;
                }

                if (checkList[0].CurrentPostName.Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
                {
                    btnAgree.Visible = true;
                    btnDisagree.Visible = true;
                }
                else
                {
                    this.Text += "   您不是该组数据的当前审批人,不能进行审批!";
                    EnableInput(false);
                    return;
                }
                foreach (T_Checked item in checkList)
                {
                    if (item.CurrentPostName != checkList[0].CurrentPostName)
                    {
                        MessageBox.Show("该组数据的状态或当前审批人存在差异,不能一起审批.");
                        this.Close();
                        return;
                    }
                }
            }
            else
            {
                EnableInput(false);
            }
        }

        /// <summary>
        /// 审核同意操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgree_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要审核吗？", "确认框", MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }

            FrmBusy frm = new FrmBusy("正在处理流程状态", agree);
            frm.ShowDialog();
            MessageBox.Show("审核完毕！", "审核完毕", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void agree()
        {
            string sFrmErrMessage = ""; //错误信息参数.
            string remark = string.IsNullOrEmpty(txtRemark.Text) ? "同意" : txtRemark.Text;
            int state = 0;
            foreach (T_Checked item in checkList)
            {
                state = T_WorkFlowService.Instance.AgreeBusinessByWorkflowId(item.Ship_Id, item.Business_Object_Id, item.WorkFlow_Id, false, out sFrmErrMessage, remark);
                if (sFrmErrMessage.Length > 0)
                {
                    MessageBox.Show(sFrmErrMessage, "审核失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    return;
                }
                Application.DoEvents();
            }
            this.Current_State = state;
            this.DialogResult = DialogResult.Yes;
        }

        /// <summary>
        /// 审核同意并结束审批操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgreeEnd_Click(object sender, EventArgs e)
        {
            string sFrmErrMessage = ""; //错误信息参数.
            string checkor = "";        //审核人.
            string postType = "";         //当前审核人的岗位类型.

            checkor = CommonOperation.ConstParameter.UserName;
            postType = CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME;

            if (MessageBox.Show("确定要审核并最终通过审批吗？", "确认框", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }
            string remark = string.IsNullOrEmpty(txtRemark.Text) ? "最终审批通过" : txtRemark.Text;
            foreach (T_Checked item in checkList)
            {
                T_WorkFlowService.Instance.AgreeBusinessByWorkflowId(item.Ship_Id, item.Business_Object_Id, item.WorkFlow_Id, true, out sFrmErrMessage, remark);
                if (sFrmErrMessage.Length > 0)
                {
                    MessageBox.Show(sFrmErrMessage, "审核失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    return;
                }
            }
            this.Current_State = 3;
            this.DialogResult = DialogResult.Yes;
            MessageBox.Show("审核完毕！", "审核完毕", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        /// <summary>
        /// 审核不同意操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisagree_Click(object sender, EventArgs e)
        {
            string sFrmErrMessage = ""; //错误信息参数. 

            if (MessageBox.Show("确定要执行此操作吗？", "确认框", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }
            string remark = string.IsNullOrEmpty(txtRemark.Text) ? "不同意" : txtRemark.Text;

            foreach (T_Checked item in checkList)
            {
                T_WorkFlowService.Instance.RejectBusinessByWorkflowId(item.Ship_Id, item.Business_Object_Id, item.WorkFlow_Id, false, out sFrmErrMessage, remark);
                if (sFrmErrMessage.Length > 0)
                {
                    MessageBox.Show(sFrmErrMessage, "审核失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    return;
                }
            }
            this.Current_State = 2;
            this.DialogResult = DialogResult.No;
            MessageBox.Show("操作完毕！", "操作完毕", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
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

        private void FrmCheck_Load(object sender, EventArgs e)
        {

        }
    }
}