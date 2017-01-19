using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cost.Services;
using Cost.DataObject;
using BaseInfo.Objects;
using CommonViewer.BaseControl;

namespace Cost.Viewer
{
    public partial class FrmEditOneCostSubjects : CommonViewer.BaseForm.FormBase
    {

        Account nowObject = new Account();
        public Account NowObject
        {
            get { return nowObject; }
            set
            {
                if (null == value)
                {
                    return;
                }
                nowObject = value;
                showObject();
            }

        }

        public FrmEditOneCostSubjects()
        {
            InitializeComponent();
        }

        public FrmEditOneCostSubjects(Account tempObject, string parentName)
        {           
            InitializeComponent();

            lbParent.Text = parentName;
            NowObject = tempObject;

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
            if (nowObject != null)
            {
                nowObject.CODE = txtCode.Text;
                nowObject.NODE_NAME = txtName.Text;
                nowObject.ORDER_NUM = int.Parse(Decimal.Round(numOrder.Value, 0).ToString());
            }

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string err="";

            this.FormToObject(out err);      //从界面获取数据到对象中.

            if (!check(out err))
            {
                return;
            }

            bool returnValue = AccountService.Instance.saveUnit(nowObject, out err);
            if (returnValue)
            {
                if(nowObject.TOP_NODE_ID == null){
                    nowObject.TOP_NODE_ID = nowObject.NODE_ID;
                    nowObject.Update(out err);
                }   
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
            //对象校验.
            if (string.IsNullOrEmpty(NowObject.NODE_NAME))
            {
                MessageBoxEx.Show("科目名称不允许为空!", "", new MessageBoxButtons(), MessageBoxIcon.Warning);
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