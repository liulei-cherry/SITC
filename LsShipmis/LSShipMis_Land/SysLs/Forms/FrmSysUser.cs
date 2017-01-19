/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有 * 文 件 名：FrmSysUser.cs
 * 创 建 人：李景育 * 创建时间：2008-06-04
 * 标    题：用户信息添加业务窗体
 * 功能描述：实现用户信息添加业务窗体上的相关功能 * 修 改 人：
 * 修改时间： * 修改内容： ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LSShipMis_Land.Common;
using LSShipMis_Land.Common.Classes;
using LSShipMis_Land.BasicData;
using LSShipMis_Land.SysLs.Services;
using CommonOperation.Functions;
using CommonViewer.BaseControl;

namespace LSShipMis_Land.SysLs.Forms
{
    /// <summary>
    /// 用户信息添加业务窗体.
    /// </summary>
    public partial class FrmSysUser : CommonViewer.BaseForm.FormBase
    {
        private CommonOpt commonOpt = new CommonOpt();  //定义一个公共类CommonOpt对象.

        private int popFlag = 0;                        //定义此窗口为弹出窗口。0代表不是；1代表是。.
        private string personName = "";

        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmSysUser instance = new FrmSysUser();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmSysUser Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmSysUser.instance = new FrmSysUser();
                }

                return FrmSysUser.instance;
            }
        }

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmSysUser()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数(重载)
        /// </summary>
        public FrmSysUser(int Flag,string name)
        {
            InitializeComponent();
            popFlag = Flag;
            personName = name;
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSysUser_Load(object sender, EventArgs e)
        {

            this.setBindingSource();//设置数据源.
            this.setDataGridView(); //设置网格控件一些的隐藏与列标头的设置.

            if (popFlag == 0)
            {
                this.WindowState = FormWindowState.Maximized;//窗体最大化.
            }else {
                this.search(personName);            
            }

        }

        /// <summary>
        /// 设置船员信息的bindingSource数据源。.
        /// </summary>
        private void setBindingSource()
        {
            DataTable dtbSysUser = RoleRight.GetSysUser();
            bindingSourceMain.DataSource = dtbSysUser;
            bdNgMain.BindingSource = bindingSourceMain;
            dgvUser.DataSource = bindingSourceMain;

        }

        /// <summary>
        /// 设置船员信息网格控件dgvUser的隐藏列与显示标题.
        /// </summary>
        private void setDataGridView()
        {
            dgvUser.Columns["userid"].Visible = false;
            dgvUser.Columns["shipuserid"].Visible = false;
            //dgvUser.Columns["userloginpass"].Visible = false;
            dgvUser.Columns["creator"].Visible = false;
            dgvUser.Columns["username"].HeaderText = "用户名称";
            dgvUser.Columns["userloginname"].HeaderText = "登录名称";
            //dgvUser.Columns["userloginpass"].HeaderText = "登录口令";
        }

        /// <summary>
        /// 添加记录.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            FrmAddSysUser frm;
            if (!string.IsNullOrEmpty(personName))
                frm = new FrmAddSysUser(personName);
            else frm = new FrmAddSysUser();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();

            this.setBindingSource();//设置数据源.
            this.setDataGridView(); //设置网格控件一些的隐藏与列标头的设置.
            this.search(frm.SelectName);

        }

        /// <summary>
        /// 删除操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.

            if (bindingSourceMain.Current != null)
            {
                if (MessageBoxEx.Show("确定要删除吗？", "删除提示", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }

                bindingSourceMain.RemoveCurrent();
                bindingSourceMain.EndEdit();
                DataTable dtb = (DataTable)bindingSourceMain.DataSource;//从BindingSource组件中取得信息集放到DataTable中去.
                commonOpt.SaveFormData(dtb, "T_Sys_User", 0, out err);//保存数据.

                //更新结果报告.
                if (err.Equals(""))
                {
                    MessageBoxEx.Show("删除成功！", "删除成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (commonOpt.IsAgainstReference(err))
                    {
                        this.setBindingSource();//刷新网格.
                        MessageBoxEx.Show("当前用户已经被引用，无法删除！", "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBoxEx.Show(err, "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

            }
        }

        /// <summary>
        /// 取消操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgCancelItem_Click(object sender, EventArgs e)
        {
            bindingSourceMain.CancelEdit();
            this.setBindingSource();
        }

        /// <summary>
        /// 关闭窗体.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSysUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.
            string userid;

            if (bindingSourceMain.Current != null)
            {
                AdminReLogin adminReLogin = new AdminReLogin();
                adminReLogin.StartPosition = FormStartPosition.CenterParent;
                adminReLogin.ShowDialog();
                string password = adminReLogin.Password;
                
                UserLogin userLogin = new UserLogin("admin", password);

                if (userLogin.CheckPwd())
                {
                    userid = dgvUser.CurrentRow.Cells["userid"].Value.ToString();
                    //userid = cboShipUser.Tag.ToString();

                    if (userid.Length == 36 && MessageBoxEx.Show("此操作将恢复当前用户初始密码为123456,确认此操作？", "删除提示", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        return;
                    }
                    //请重新录入管理员密码.

                    userLogin.restallAUserPassword(userid, out err);

                    //更新结果报告.
                    if (err.Equals(""))
                    {
                        MessageBoxEx.Show("恢复成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBoxEx.Show("恢复失败！\n" + err, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBoxEx.Show("输入密码错误,不能进行恢复密码操作!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
       
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string personName = "";
            if (dgvUser.CurrentRow != null)
            {
                personName = dgvUser.CurrentRow.Cells["username"].Value.ToString();
            }

            SysLs.Forms.FrmShipUserHead frm = new SysLs.Forms.FrmShipUserHead(1,personName);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();

        }

        private void search(string searchValue)
        { 
            if (string.IsNullOrEmpty(searchValue))
            {
                return;
            }

            for (int i = 0; i < this.dgvUser.Rows.Count; i++)
            {
                string str = this.dgvUser["username", i].Value.ToString();
                if (str.Equals(searchValue))
                {
                    this.dgvUser.CurrentCell = this.dgvUser["username", i];
                    return;
                }
            }
        }

        private void addNew_Click(object sender, EventArgs e)
        {
            FrmAddSysUser frm;
            if (!string.IsNullOrEmpty(personName))
                frm = new FrmAddSysUser(personName);
            else frm = new FrmAddSysUser();

            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();

            this.setBindingSource();//设置数据源.
            this.setDataGridView(); //设置网格控件一些的隐藏与列标头的设置.
            this.search(personName);
        }

    }
}