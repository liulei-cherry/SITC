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
    public partial class FrmEditOneOilAdd : CommonViewer.BaseForm.FormBase
    {

        HOilAdd currentObject = new HOilAdd();
        public HOilAdd CurrentObject
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

        public FrmEditOneOilAdd()
        {
            InitializeComponent();
        }

        public FrmEditOneOilAdd(HOilAdd tempObject)
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
            //港口.
            DataTable dtb1 = PortInfoService.Instance.getInfo(out err);
            other.SetComboBoxValue(cobPort, dtb1);

            //燃油类型.
            DataTable dtb2 = HOilService.Instance.getFuelOilType(out err);
            other.SetComboBoxValue(cob2, dtb2);
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
                currentObject.ADD_DATE = date1.Value;
                currentObject.AMOUNT = numAmount.Value;
                currentObject.DENSITY = numDensity.Value;
                currentObject.OIL_TYPE = cob2.SelectedValue.ToString();
                currentObject.PORT_ID = cobPort.SelectedValue.ToString();
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

            bool returnValue = HOilAddService.Instance.saveUnit(currentObject, out err);
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

            if ("".Equals(cobPort.Text))
            {
                MessageBoxEx.Show("港口不能为空!", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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