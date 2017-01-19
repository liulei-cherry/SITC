/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 创 建 人：夏喜龙
 * 创建时间：2011-5-12
 * 功能描述：维护保养中工作分类信息的基础维护
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
using BaseInfo.Objects;
using Maintenance.DataObject;
using Maintenance.Services;
using CommonViewer.BaseControl;

namespace Maintenance.Viewer
{
    public partial class FrmWorkinfoTempletClassEdit : CommonViewer.BaseForm.FormBase
    {

        public T_WORKINFO_TEMPLATE_CLASS templetClass;
        public FrmWorkinfoTempletClassEdit()
        {
            InitializeComponent();
        }

        public FrmWorkinfoTempletClassEdit(T_WORKINFO_TEMPLATE_CLASS workTempletClass)
        {           
            InitializeComponent();

            templetClass = workTempletClass;
            this.ChangeData(templetClass);
        }

        public void ChangeData(T_WORKINFO_TEMPLATE_CLASS workTempletClass)
        {
            txtName.Text = workTempletClass.NODE_NAME;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            UpdateObject();
        }

        /// <summary>
        /// 保存对象功能.
        /// </summary>
        public void UpdateObject()
        {
            string err;
            if (!SetObject(out err))
            {
                return;
            }
            if (beforSaveCheck())
            {
                MessageBoxEx.Show("保存成功!", "", new MessageBoxButtons(), MessageBoxIcon.Information);
                this.Close();
            }
        }

        /// <summary>
        /// 把显示值设置到对象上.
        /// </summary>
        public bool SetObject(out string err)
        {
            err = "";
            if (templetClass != null)
            {
                templetClass.NODE_NAME = txtName.Text;
                templetClass.SORTNO = int.Parse(numSortNo.Value.ToString());
                return true;
            }
            else
            {
                err = "当前对象无效!";
                MessageBoxEx.Show(err, "", new MessageBoxButtons(), MessageBoxIcon.Error);

            }
            return false;
        }

        /// <summary>
        /// 对象保存前检查.
        /// </summary>
        private bool beforSaveCheck()
        {
            if (string.IsNullOrEmpty(templetClass.NODE_NAME))
            {
                MessageBoxEx.Show("名称不允许为空!", "", new MessageBoxButtons(), MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            string err;
            if (!T_WORKINFO_TEMPLATE_CLASSService.Instance.saveUnit(templetClass, out err))
            {
                MessageBoxEx.Show(err);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 关闭窗口.
        /// </summary>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}