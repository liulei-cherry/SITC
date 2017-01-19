/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有 * 文 件 名：FrmInputBox.cs
 * 创 建 人：李景育 * 创建时间：2007-12-20
 * 标    题：快速搜索对话框窗体
 * 功能描述：实现快速搜索对话框窗体上的相关功能
 * 修 改 人： 
 * 修改时间： * 修改内容： ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonViewer.BaseControl;

namespace CommonViewer
{
    /// <summary>
    /// 快速搜索对话框窗体.
    /// </summary>
    public partial class FrmInputBoxGrid : CommonViewer.BaseForm.FormBase
    {
        /// <summary>
        /// 搜索内容.
        /// </summary>
        private string searchValue = "";

        /// <summary>
        /// 搜索内容.
        /// </summary>
        public string SearchValue
        {
            get { return searchValue; }
            set { searchValue = value; }
        }

        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmInputBoxGrid()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 设置搜索内容.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtInputBox.Text.Trim().Length == 0)
            {
                MessageBoxEx.Show("请输入要查找的内容！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtInputBox.Focus();

                //设置对话框继续运行.
                this.DialogResult=DialogResult.None;
            }
            else
            {
                this.SearchValue = txtInputBox.Text;
                this.Close();
            }
        }

        /// <summary>
        /// 关闭窗体.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 当在快速搜索文本框中按回车时执行btnOk功能.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnOk_Click(sender, e);
            }
        }
    }
}