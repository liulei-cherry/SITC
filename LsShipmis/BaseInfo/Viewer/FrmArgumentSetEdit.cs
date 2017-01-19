using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseInfo.DataAccess;
using BaseInfo.Objects;
using CommonViewer.BaseControl;
using CommonViewer.BaseControlService; 

namespace BaseInfo.Viewer
{
    public partial class FrmArgumentSetEdit : CommonViewer.BaseForm.FormBase
    {

        ArgumentSet  currentObject = new ArgumentSet();
        public ArgumentSet CurrentObject
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

        public FrmArgumentSetEdit()
        {
            InitializeComponent();
        }

        public FrmArgumentSetEdit(ArgumentSet tempObject)
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
                currentObject.CODE = txtCode.Text;
                currentObject.CODE_VALUE = txtCodeValue.Text;
                currentObject.INTRO = txtIntro.Text;
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

            bool returnValue = ArgumentSetService.Instance.saveUnit(currentObject, out err);
            if (returnValue)
            {
                MessageBoxEx.Show("保存成功!", "", new MessageBoxButtons(), MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBoxEx.Show("当前对象保存失败,错误原因是:" + err);
                return;
            }

        }

        private bool check(out string err)
        {
            err = "";

            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBoxEx.Show("编码不能为空!", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
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