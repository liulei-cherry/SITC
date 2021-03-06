﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cost.Services;
using Cost.DataObject;
using BaseInfo.Objects;
using BaseInfo.DataAccess;
using CommonViewer.BaseControl;

using CommonViewer.BaseControlService;

namespace Cost.Viewer
{
    public partial class FrmSimpleclassEdit : CommonViewer.BaseForm.FormBase
    {

        CostSimpleclass currentObject = new CostSimpleclass();
        public CostSimpleclass CurrentObject
        {
            get { return currentObject; }
            set
            {
                if (null == value)
                {
                    return;
                }
                currentObject = value;
                showObject();
            }

        }

        #region 其它公共业务类

        private FormControlOption other = FormControlOption.Instance;

        #endregion

        public FrmSimpleclassEdit()
        {
            InitializeComponent();
        }

        public FrmSimpleclassEdit(CostSimpleclass tempObject)
        {           
            InitializeComponent();

            setComboBox();                 //设置窗体所需的下拉列表框的数据源.

            CurrentObject = tempObject;
        }

        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {
            string err = "";
            //简单费用类型.
            DataTable dtb1 = CostSimpleclassService.Instance.getCostSimpleType(out err);
            other.SetComboBoxValue(cboType, dtb1);
        }

        /// <summary>
        /// 将私有对象信息显示到窗体上.
        /// </summary>
        private void showObject()
        {
        }

        public void FormToObject(out string err)
        {
            err = "";
            if (currentObject != null)
            {
                currentObject.NAME = txtName.Text;
                currentObject.TYPE = cboType.SelectedValue.ToString();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string err="";

            if (!check(out err))
            {
                return;
            }

            this.FormToObject(out err);      //从界面获取数据到对象中.

            bool returnValue = currentObject.Update(out err);
            if (returnValue)
            {
                MessageBoxEx.Show("保存成功!", "", new MessageBoxButtons(), MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBoxEx.Show("当前对象保存失败,错误原因是:" + err, "错误", new MessageBoxButtons(), MessageBoxIcon.Error);
                return;
            }

        }

        private bool check(out string err)
        {
            err = "";

            if ("".Equals(txtName.Text))
            {
                MessageBoxEx.Show("名称不能为空!", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            return true;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}