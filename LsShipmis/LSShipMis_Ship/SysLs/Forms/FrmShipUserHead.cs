/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有 * 文 件 名：FrmShipUserHead.cs
 * 创 建 人：李景育 * 创建时间：2008-06-04
 * 标    题：船员职务设置业务窗体
 * 功能描述：实现船员职务业务窗体上的相关功能 * 修 改 人：
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
    /// 船员职务设置业务窗体.
    /// </summary>
    public partial class FrmShipUserHead : CommonViewer.BaseForm.FormBase
    {
        private CommonOpt commonOpt = new CommonOpt();  //定义一个公共类CommonOpt对象.

        private int popFlag = 0;                        //定义此窗口是被其他窗口调用的窗口。0代表不是；1代表是。.
        
        private string personName = "";                        

        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmShipUserHead instance = new FrmShipUserHead();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmShipUserHead Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmShipUserHead.instance = new FrmShipUserHead();
                }

                return FrmShipUserHead.instance;
            }
        }

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmShipUserHead()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数(重载)
        /// </summary>
        public FrmShipUserHead(int Flag,string name)
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
        private void FrmShipUserHead_Load(object sender, EventArgs e)
        {
            this.setBdsShipUser();
            this.setDgvShipUser();
            if (popFlag == 0)
            {
                this.WindowState = FormWindowState.Maximized;//窗体最大化.
            }
            else
            {
                this.search(personName);
            }
        }

        /// <summary>
        /// 设置船员信息的bindingSource数据源。.
        /// </summary>
        private void setBdsShipUser()
        {
            DataTable dtbShipUser = RoleRight.GetShipUser();
            bindingSourceUser.DataSource = dtbShipUser;
            bdNgMain.BindingSource = bindingSourceUser;
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
        /// 当船员信息改变时，显示当前船员的职务信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvUser_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string shipUserId = "";//当前网格dgvUser中的船员主键.

            if (dgvUser.Rows[e.RowIndex].Cells["shipuserid"].Value != null)
            {
                shipUserId = dgvUser.Rows[e.RowIndex].Cells["shipuserid"].Value.ToString();
                this.setBdsShipHead(shipUserId);
            }
        }

        /// <summary>
        /// 设置船舶职务信息的bindingSource数据源。.
        /// </summary>
        /// <param name="shipUserId">船员职务信息</param>
        private void setBdsShipHead(string shipUserId)
        {
            DataTable dtbShipHead = RoleRight.GetShipHead(shipUserId);
            bindingSourceShipHead.DataSource = dtbShipHead;
            dgvShipHead.DataSource = bindingSourceShipHead;
            this.setDgvShipHead();
        }

        /// <summary>
        /// 设置船舶职务信息网格控件dgvShipHead的隐藏列与显示标题.
        /// </summary>
        private void setDgvShipHead()
        {
            dgvShipHead.Columns["select"].DataPropertyName="sel";
            dgvShipHead.Columns["sel"].Visible = false;
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
        /// 保存为指定船员所选择的角色.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgSaveItem_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.
            string shipUserId = "";     //当前船员Id
            dgvShipHead.EndEdit();      //结束网格编辑.

            if (dgvUser.Rows.Count == 0)
            {           
                MessageBoxEx.Show("当前没有船员信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //if (commonOpt.HasRepliVal(dgvShipHead, "sel","1"))
            //{
            //    MessageBoxEx.Show("一个船员只能选择一个职务！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            shipUserId = dgvUser.CurrentRow.Cells["shipuserid"].Value.ToString();
            
            //取所选船舶职务信息的DataTable对象.
            bindingSourceShipHead.EndEdit();
            DataTable dtb = (DataTable)bindingSourceShipHead.DataSource;
            DataRow[] rows = dtb.Select("sel = 1");//筛选出选择的记录.

            if (rows.Length > 1)
            {
                MessageBoxEx.Show("为了简化权限设置，通过选择岗位即可用户对应权限，这里规定只允许选择一个岗位，如有代理其他岗位的情况，请选择最大岗位。","无法完成保存");
                return;
            }
            //保存选择的职务数据.
            RoleRight.SaveSelShipHeads(shipUserId, rows, out err);

            //更新结果报告.
            if (err.Equals(""))
            {
                this.setBdsShipHead(shipUserId);//刷新网格.
                MessageBoxEx.Show("数据保存成功！", "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (popFlag == 1)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBoxEx.Show(err, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// 取消操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgCancelItem_Click(object sender, EventArgs e)
        {
            bindingSourceUser.EndEdit();
            this.setBdsShipUser();
        }

        /// <summary>
        /// 权限设置.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgRightSet_Click(object sender, EventArgs e)
        {
            FrmRightSet frm = new FrmRightSet();
            frm.ShowDialog();
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
        private void FrmShipUserHead_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
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
                }
            }
        }

    }
}