/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有 * 文 件 名：FrmRightSet.cs
 * 创 建 人：李景育 * 创建时间：2008-06-04
 * 标    题：权限设置业务窗体
 * 功能描述：实现权限设置业务窗体上的相关功能 * 修 改 人：
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
using LSShipMis_Land.SysLs.Services;
using CommonViewer.BaseControl;

namespace LSShipMis_Land.SysLs.Forms
{
    /// <summary>
    /// 权限设置业务窗体.
    /// </summary>
    public partial class FrmRightSet : CommonViewer.BaseForm.FormBase
    {
        private CommonOpt commonOpt = new CommonOpt();  //定义一个公共类CommonOpt对象.

        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmRightSet instance = new FrmRightSet();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmRightSet Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmRightSet.instance = new FrmRightSet();
                }

                return FrmRightSet.instance;
            }
        }

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmRightSet()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        private void FrmRoleRight_Load(object sender, EventArgs e)
        {
            this.tabMain_SelectedIndexChanged(sender, e);//窗体启动时调用tabMain的第1个标签要执行的操作.
            this.WindowState = FormWindowState.Maximized;//窗体最大化.
        }

        /// <summary>
        /// 设置船舶职务信息的bindingSource数据源。.
        /// </summary>
        private void setBdsShipHead()
        {
            DataTable dtbShipHead = RoleRight.GetShipHead();
            bindingSourceShipHead.DataSource = dtbShipHead;
            dgvShipHead.DataSource = bindingSourceShipHead;
        }

        /// <summary>
        /// 设置船舶职务信息网格控件dgvShipHead的隐藏列与显示标题.
        /// </summary>
        private void setDgvShipHead()
        {
            dgvShipHead.Columns["ship_headship_id"].Visible = false;
            dgvShipHead.Columns["creator"].Visible = false;
            dgvShipHead.Columns["headship_name"].HeaderText = "职务名称";
            dgvShipHead.Columns["POSTLEVEL"].HeaderText = "职务级别";
            dgvShipHead.Columns["DETAIL"].HeaderText = "职务说明";
            dgvShipHead.Columns["headship_name"].ReadOnly = true;
            dgvShipHead.Columns["POSTLEVEL"].ReadOnly = true;
            dgvShipHead.Columns["DETAIL"].ReadOnly = true;
            dgvShipHead.Columns["headship_name"].Width = 150;
            dgvShipHead.Columns["DETAIL"].Width = 170;
            commonOpt.SetDataGridViewNoSort(dgvShipHead);
        }

        /// <summary>
        /// 设置船员信息的bindingSource数据源。.
        /// </summary>
        private void setBdsShipUser()
        {
            DataTable dtbShipUser = RoleRight.GetShipUser();
            bindingSourceUser.DataSource = dtbShipUser;
            dgvUser.DataSource = bindingSourceUser;
        }

        /// <summary>
        /// 设置船员信息网格控件dgvUser的隐藏列与显示标题.
        /// </summary>
        private void setDgvShipUser()
        {
            dgvUser.Columns["shipuserid"].Visible = false;
            dgvUser.Columns["username"].HeaderText = "船员中文名";
            dgvUser.Columns["enname"].HeaderText = "船员英文名";
            dgvUser.Columns["sex"].HeaderText = "性别";
            dgvUser.Columns["job"].HeaderText = "职务";
            dgvUser.Columns["countryname"].HeaderText = "国籍";
            dgvUser.Columns["ident"].HeaderText = "身份证号码";
            dgvUser.Columns["sex"].Width = 60;
            dgvUser.Columns["countryname"].Width = 60;
        }

        /// <summary>
        /// 当Tab标签切换时执行相同的功能.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMain.SelectedIndex == 0)
            {
                this.setBdsShipHead();
                this.setDgvShipHead();
                bdNgMain.BindingSource = bindingSourceShipHead;
                dgvShipHead.Select();            
            }
            else if (tabMain.SelectedIndex == 1)
            {
                this.setBdsShipUser();
                this.setDgvShipUser();
                bdNgMain.BindingSource = bindingSourceUser;
                dgvUser.Select();
            }
        }

        /// <summary>
        /// 当职务网格dgvShipHead行改变时显示指定职务的权限信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvShipHead_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string shipHeadId = "";//当前网格dgvShipHead中的职务主键.

            if (dgvShipHead.Rows[e.RowIndex].Cells["ship_headship_id"].Value != null)
            {
                shipHeadId = dgvShipHead.Rows[e.RowIndex].Cells["ship_headship_id"].Value.ToString();
                this.setBdsRight(shipHeadId);
            }
        }

        /// <summary>
        /// 当船员网格dgvUser行改变时显示指定船员的权限信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvUser_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string shipUserId = "";//当前网格dgvUser中的船员主键.

            if (dgvUser.Rows[e.RowIndex].Cells["shipuserid"].Value != null)
            {
                shipUserId = dgvUser.Rows[e.RowIndex].Cells["shipuserid"].Value.ToString();
                this.setBdsRight(shipUserId);
            }
        }

        /// <summary>
        /// 设置指定业务Id的权限信息的bindingSource数据源。.
        /// </summary>
        /// <param name="shipUserId">船员职务信息</param>
        private void setBdsRight(string bussinessId)
        {
            DataTable dtbRight = null;

            if (tabMain.SelectedIndex == 0)
            {
                dtbRight = RoleRight.GetShipHeadRight(bussinessId);
            }
            else if (tabMain.SelectedIndex == 1)
            {
                dtbRight = RoleRight.GetShipUserRight(bussinessId);
            }

            bindingSourceRight.DataSource = dtbRight;
            dgvRight.DataSource = bindingSourceRight;
            this.setDgvRight();
        }

        /// <summary>
        /// 设置权限信息网格控件dgvRight的隐藏列与显示标题.
        /// </summary>
        private void setDgvRight()
        {
            dgvRight.ReadOnly = false;
            dgvRight.Columns["select"].DataPropertyName = "sel";
            dgvRight.Columns["select"].ReadOnly = false;
            dgvRight.Columns["sel"].Visible = false;
            dgvRight.Columns["right_id"].Visible = false;
            dgvRight.Columns["right_name"].HeaderText = "权限名称";
            dgvRight.Columns["right_name"].ReadOnly = true;
            dgvRight.Columns["right_name"].DefaultCellStyle.BackColor = Color.Linen;
            dgvRight.Columns["module"].HeaderText = "所属模块";
            dgvRight.Columns["module"].ReadOnly = true;
            dgvRight.Columns["module"].DefaultCellStyle.BackColor = Color.Linen;
            dgvRight.Columns["remark"].HeaderText = "备注";
            dgvRight.Columns["right_name"].Width = 150;
            dgvRight.Columns["module"].Width = 150;
            dgvRight.Columns["remark"].Width = 300;
            commonOpt.SetDataGridViewNoSort(dgvRight);
        }

        /// <summary>
        /// 保存操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgSaveItem_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.
            string shipHeadId = "";     //职务主键.
            string shipUserId = "";     //船员主键.

            dgvRight.EndEdit();         //结束权限网格编辑.

            //保存权限表的备注信息.
            Dictionary<string, string> dictRemark = this.getRightRemark();
            if (dictRemark.Count > 0)
            {
                RoleRight.SaveRightRemark(dictRemark, out err);
            }

            if (tabMain.SelectedIndex == 0)
            {
                if (dgvShipHead.Rows.Count == 0)
                {
                    MessageBoxEx.Show("当前没有职务信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                //当前职务Id
                shipHeadId = dgvShipHead.CurrentRow.Cells["ship_headship_id"].Value.ToString();

                //取所选职务对应的权限信息的DataTable对象.
                bindingSourceRight.EndEdit();
                DataTable dtb = (DataTable)bindingSourceRight.DataSource;
                DataRow[] rows = dtb.Select("sel = 1");//筛选出选择的记录.

                //保存为指定职务选择的权限数据.
                RoleRight.SaveSelShipHeadRights(shipHeadId, rows, out err);

                //更新结果报告.
                if (err.Equals(""))
                {
                    this.setBdsShipHead();//刷新网格.
                    MessageBoxEx.Show("数据保存成功！", "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBoxEx.Show(err, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (tabMain.SelectedIndex == 1)
            {
                if (dgvUser.Rows.Count == 0)
                {
                    MessageBoxEx.Show("当前没有船员信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //当前船员Id
                shipUserId = dgvUser.CurrentRow.Cells["shipuserid"].Value.ToString();

                //取所选船员对应的权限信息的DataTable对象.
                bindingSourceRight.EndEdit();
                DataTable dtb = (DataTable)bindingSourceRight.DataSource;
                DataRow[] rows = dtb.Select("sel = 1");//筛选出选择的记录.

                //保存为指定船员选择的权限数据.
                RoleRight.SaveSelUserRights(shipUserId, rows, out err);

                //更新结果报告.
                if (err.Equals(""))
                {
                    this.setBdsShipUser();//刷新网格.
                    MessageBoxEx.Show("数据保存成功！", "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBoxEx.Show(err, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            if (tabMain.SelectedIndex == 0)
            {
                bindingSourceShipHead.EndEdit();
                this.setDgvShipHead();
            }
            else if (tabMain.SelectedIndex == 1)
            {
                bindingSourceUser.EndEdit();
                this.setDgvShipUser();
            }
        }

        /// <summary>
        /// 关闭操作.
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
        private void FrmRightSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

        /// <summary>
        /// 返回包含权限Id与备注信息的Dictionary字典集合.
        /// </summary>
        /// <returns>包含权限Id与备注信息的Dictionary字典集合</returns>
        private Dictionary<string, string> getRightRemark()
        {
            Dictionary<string, string> dictRemark = new Dictionary<string, string>();

            foreach (DataGridViewRow curRow in dgvRight.Rows)
            {
                string rightId = curRow.Cells["right_id"].Value.ToString();
                string remark = curRow.Cells["remark"].Value.ToString();
                dictRemark.Add(rightId, remark);
            }

            return dictRemark;
        }

        /// <summary>
        /// 全选.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvRight.Rows)
            {
                row.Cells["sel"].Value = true;
            }
        }

        /// <summary>
        /// 全清.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBlank_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvRight.Rows)
            {
                row.Cells["sel"].Value = false;
            }
        }
    }
}