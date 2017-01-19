/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有 * 文 件 名：FrmEditPwd.cs
 * 创 建 人：李景育 * 创建时间：2008-06-04
 * 标    题：用户口令修改业务窗体
 * 功能描述：实现用户口令修改业务窗体上的相关功能 * 修 改 人：
 * 修改时间： * 修改内容： ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LSShipMis_Ship.Common;
using LSShipMis_Ship.Common.Classes;
using LSShipMis_Ship.SysLs.Services;
using CommonViewer.BaseControl;

namespace LSShipMis_Ship.SysLs.Forms
{
    /// <summary>
    /// 用户口令修改业务窗体.
    /// </summary>
    public partial class FrmEditPwd : CommonViewer.BaseForm.FormBase
    {
        private CommonOpt commonOpt = new CommonOpt();  //定义一个公共类CommonOpt对象.

        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmEditPwd()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        private void FrmEditPwd_Load(object sender, EventArgs e)
        {
            lblUserName.Tag = CommonOperation.ConstParameter.UserId;   //用户Id
            lblUserName.Text = CommonOperation.ConstParameter.UserName;//用户名称.
        }

        /// <summary>
        /// 执行口令修改.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            string err = "";                 //错误信息参数.
            string userId = lblUserName.Tag.ToString(); //用户Id

            if (txtOldPwd.Text.Trim().Length == 0)
            {
                MessageBoxEx.Show("请输入原口令！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOldPwd.Focus();
                return;
            }

            if (RoleRight.IsRightOldPwd(userId, txtOldPwd.Text) == false)
            {
                MessageBoxEx.Show("原口令不正确！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOldPwd.Focus();
                return;
            }

            if (txtNewPwd.Text.Trim().Length == 0)
            {
                MessageBoxEx.Show("请输入新口令！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPwd.Focus();
                return;
            }

            if (txtConfirmPwd.Text.Trim().Length == 0)
            {
                MessageBoxEx.Show("请输入确定口令！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPwd.Focus();
                return;
            }

            if (!txtNewPwd.Text.Equals(txtConfirmPwd.Text))
            {
                MessageBoxEx.Show("确认口令与新口令不一致！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPwd.Focus();
                return;
            }

            //执行口令修改.
            RoleRight.EditNewPwd(userId, txtNewPwd.Text, out err);

            //更新结果报告.
            if (err.Equals(""))
            {
                MessageBoxEx.Show("口令修改完毕！", "修改成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBoxEx.Show(err, "修改失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// 关闭窗体.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}