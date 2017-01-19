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
    public partial class FrmOilConsumeEdit : CommonViewer.BaseForm.FormBase
    {

        HOilConsume currentObject = new HOilConsume();
        public HOilConsume CurrentObject
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

        public FrmOilConsumeEdit()
        {
            InitializeComponent();
        }

        public FrmOilConsumeEdit(HOilConsume tempObject)
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

            //燃油类型.
            DataTable dtb2 = HOilService.Instance.getFuelOilType(out err);
            other.SetComboBoxValue(cob2, dtb2);

            //燃油消耗类型.
            DataTable dtb3 = HOilService.Instance.getFuelOilConsumeType(out err);
            other.SetComboBoxValue(cob3, dtb3);
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
                currentObject.CONSUME_MONTH = date1.Value;
                currentObject.AMOUNT = numAmount.Value;
                currentObject.DENSITY = numDensity.Value;
                currentObject.OIL_TYPE = cob2.SelectedValue.ToString();
                currentObject.CONSUME_TYPE = cob3.SelectedValue.ToString();
                currentObject.REMARK = txtRemark.Text;
                currentObject.SPECIFICATION = txtSpe.Text;
                currentObject.SULPHUR = numSul.Value;
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

            bool returnValue = HOilConsumeService.Instance.saveUnit(currentObject, out err);
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

            //if ("".Equals(cobPort.Text))
            //{
            //    MessageBoxEx.Show("港口不能为空!", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}

            return true;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}