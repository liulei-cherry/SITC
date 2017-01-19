using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LSShipMis_Ship.Common;
using LSShipMis_Ship.Common.Classes;
using LSShipMis_Ship.BasicData;
using LSShipMis_Ship.SysLs.BusinessClasses;
using LSShipMis_Ship.SysLs.Services;
using CommonViewer.BaseControl;

namespace LSShipMis_Ship.SysLs.Forms
{
    public partial class FrmAddSysUser : CommonViewer.BaseForm.FormBase
    {
        private CommonOpt commonOpt = new CommonOpt();  //定义一个公共类CommonOpt对象.
        private string username;
        public string SelectName;
        public FrmAddSysUser()
        {
            InitializeComponent();
        }

        public FrmAddSysUser(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void bdNgClose_Click(object sender, EventArgs e)
        {
            this.Close();
            SelectName = "";
        }

        private void FrmAddSysUser_Load(object sender, EventArgs e)
        {
            setBindingSource();
            ucComboBoxSeaman.Text = username;
        }

        private void bdNgSaveItem_Click(object sender, EventArgs e)
        {
            string err = "";
            string shipUserId = "";     //用户Id

            //***************数据校验*****************************************************************************
            if (ucComboBoxSeaman.SelectedIndex == -1)
            {
                MessageBoxEx.Show("用户名称是必选内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ucComboBoxSeaman.Focus();
                return;
            }
            if (txtLogin.Text.Trim().Length == 0)
            {
                MessageBoxEx.Show("登录名称是必填内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLogin.Focus();
                return;
            }

            if (ucComboBoxSeaman.SelectedValue != null)
            {
                shipUserId = ucComboBoxSeaman.SelectedValue.ToString();
                SelectName = ucComboBoxSeaman.Text;
            }

            if (commonOpt.HasRepliVal(txtLogin.Text.Trim(), "T_SYS_USER", "USERLOGINNAME", null))
            {
                MessageBoxEx.Show("当前用户已经存在！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ucComboBoxSeaman.Focus();
                return;
            }

            //***************数据保存*****************************************************************************
            T_SYS_USER sysUser = new T_SYS_USER();
            sysUser.SHIPUSERID = shipUserId;
            sysUser.USERLOGINNAME = txtLogin.Text.Trim();
            sysUser.USERLOGINPASS = "123456";
            sysUser.creator = CommonOperation.ConstParameter.UserName;
            T_SYS_USERService.Instance.saveUnit(sysUser,out err);

            //更新结果报告.
            if (err.Equals(""))
            {
                //保存数据后刷新BindingSource数据源组件.
                this.setBindingSource();
                MessageBoxEx.Show("数据保存成功！", "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBoxEx.Show(err, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        /// <summary>
        /// 设置人员信息的bindingSource数据源。.
        /// </summary>
        private void setBindingSource()
        {
            DataTable dtbShipUser = BaseDataService.GetShipUser(" and SHIPUSERID not in (select SHIPUSERID from T_SYS_USER  where SHIPUSERID  is not null)");
            ucComboBoxSeaman.DataSource = dtbShipUser;
            ucComboBoxSeaman.DisplayMember = "username";
            ucComboBoxSeaman.ValueMember = "shipuserid";
        }

    }
}