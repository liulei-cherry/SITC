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
    public partial class FrmOilReportEdit : CommonViewer.BaseForm.FormBase
    {

        HOilReport currentObject = new HOilReport();
        public HOilReport CurrentObject
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

        public FrmOilReportEdit()
        {
            InitializeComponent();
        }

        public 
            FrmOilReportEdit(HOilReport tempObject)
        {           
            InitializeComponent();
            CurrentObject = tempObject;

        }

        /// <summary>
        /// 将私有对象信息显示到窗体上.
        /// </summary>
        private void showObject()
        {
            //加日期输入限制.
            date1.MinDate = new DateTime(1753, 1, 1);
            date1.MaxDate = new DateTime(9998, 12, 31);
            date1.MinDate = new DateTime(currentObject.REPORT_DATE.Year, 1, 1);
            date1.MaxDate = new DateTime(currentObject.REPORT_DATE.Year, 12, 31);
        }

        public void FormToObject(out string err)
        {
            err = "";
            if (currentObject != null)
            {
                currentObject.REPORT_DATE = date1.Value;
                currentObject.START_DATE = dateStart.Value;
                currentObject.END_DATE = dateEnd.Value;
                currentObject.SAIL_DAY = decimal.ToInt32(numDay.Value);
                currentObject.SAIL_HOUR = decimal.ToInt32(numHour.Value);
                currentObject.W_SPECIFICATION = txtSpec1.Text;
                currentObject.L_SPECIFICATION = txtSpec2.Text;
                currentObject.WLEFT_AMOUNT = numLeft1.Value;
                currentObject.LLEFT_AMOUNT = numLeft2.Value;
                currentObject.W_SULPHUR = numSu1.Value;
                currentObject.L_SULPHUR = numSu2.Value;
                currentObject.W_DENSITY = numDen1.Value;
                currentObject.L_DENSITY = numDen2.Value;
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
                MessageBoxEx.Show("保存成功!", "提示", new MessageBoxButtons(), MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBoxEx.Show("当前对象保存失败,错误原因是:" + err,"错误", new MessageBoxButtons(), MessageBoxIcon.Error);
                return;
            }

        }

        private bool check(out string err)
        {
            err = "";

            //if ("".Equals(cob3.Text))
            //{
            //    MessageBoxEx.Show("润滑油不能为空!", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}

            //月份不能重复.
            if (HOilReportService.Instance.ifHaveByYearMonth(currentObject.SHIP_ID, date1.Value, out err))
            {
                MessageBoxEx.Show("月份不能重复!", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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