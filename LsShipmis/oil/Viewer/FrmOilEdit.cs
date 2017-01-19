using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oil.Services;
using Oil.DataObject;
using BaseInfo.Objects;
using BaseInfo.DataAccess;
using CommonViewer.BaseControl;

using CommonViewer.BaseControlService; 

namespace Oil.Viewer
{
    public partial class FrmOilEdit : CommonViewer.BaseForm.FormBase
    {

        HOil currentObject = new HOil();
        public HOil CurrentObject
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

        public FrmOilEdit()
        {
            InitializeComponent();
        }

        public FrmOilEdit(HOil tempObject)
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
            //油品类型.
            DataTable dtb1 = HOilService.Instance.getOilType(out err);
            other.SetComboBoxValue(cboType, dtb1);

            //润油类型.
            DataTable dtb2 = HOilService.Instance.getLOilType(out err);
            other.SetComboBoxValue(cboLType, dtb2);
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
                currentObject.TRADEMARK = txtMark.Text;
                currentObject.OIL_NAME = txtName.Text;
                currentObject.OIL_CODE = txtCode.Text;
                currentObject.OIL_TYPE = cboType.SelectedValue.ToString();
                if (cboLType.Visible)
                {
                    currentObject.LOIL_TYPE = cboLType.SelectedValue.ToString();
                }else{
                    currentObject.LOIL_TYPE = "3";
                }
                
                currentObject.ORDERNUM = int.Parse(numOrder.Value.ToString());
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

            bool returnValue = HOilService.Instance.saveUnit(currentObject, out err);
            if (returnValue)
            {
                MessageBoxEx.Show("保存成功!", "提示", new MessageBoxButtons(), MessageBoxIcon.Information);
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

            if ("".Equals(txtMark.Text))
            {
                MessageBoxEx.Show("牌号不能为空!", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMark.Focus();
                return false;
            }
            if ("".Equals(txtName.Text))
            {
                MessageBoxEx.Show("厂家不能为空!", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            return true;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboType.SelectedValue != null)
            {
                bool rValue = "2".Equals(cboType.SelectedValue.ToString());

                label2.Visible = rValue;
                cboLType.Visible = rValue;
            }
        }
    }
}