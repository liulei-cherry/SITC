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
    public partial class FrmOilLuboilConsumeEdit : CommonViewer.BaseForm.FormBase
    {

        HOilLuboilConsume currentObject = new HOilLuboilConsume();
        public HOilLuboilConsume CurrentObject
        {
            get { return currentObject; }
            set
            {
                if (null == value)
                {
                    return;
                }
                currentObject = value;
            }

        }

        #region 其它公共业务类
        private FormControlOption other = FormControlOption.Instance;
        #endregion

        public FrmOilLuboilConsumeEdit()
        {
            InitializeComponent();
        }

        public FrmOilLuboilConsumeEdit(HOilLuboilConsume tempObject)
        {
            InitializeComponent();
            this.num1.TextChanged += new EventHandler(num_ValueChanged);
            this.num2.TextChanged += new EventHandler(num_ValueChanged);
            this.num4.TextChanged += new EventHandler(num_ValueChanged);
            CurrentObject = tempObject;
            setComboBox(tempObject.SHIP_ID);                 //设置窗体所需的下拉列表框的数据源.
        }
        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox(string ship_id)
        {
            //分配到特定船舶的润滑油列表.
            DataTable dtb1 = HOilService.Instance.GetShipLubOil(ship_id);
            other.SetComboBoxValue(cob3, dtb1, "oil_id", "ON_SHIP_USE");
        }

        private void num_ValueChanged(object sender, EventArgs e)
        {
            decimal val = num1.Value + num2.Value - num4.Value;
            if (val >= 0)
            {
                if (val > 99999999)
                    val = 99999999;
                else
                    num3.Value = val;
            }
            else
                num3.Value = 0;
        }

        private void date1_ValueChanged(object sender, EventArgs e)
        {
            string err = "";
            
            DataTable dtb = HOilLuboilConsumeService.Instance.GetInfoByMonthOil(CurrentObject.SHIP_ID, date1.Value.AddMonths(-1), cob3.SelectedValue.ToString(), out err);
            if (dtb.Rows.Count > 0)
                num1.Value = Convert.ToDecimal(dtb.Rows[0]["THISMONTH_STORE"]);
            else
                num1.Value = 0;
        }

        public void FormToObject(out string err)
        {
            err = "";
            if (currentObject != null)
            {
                currentObject.RECORD_DATE = date1.Value;
                currentObject.OIL_ID = cob3.SelectedValue.ToString();
                currentObject.LASTMONTH_LEFT = num1.Value;
                currentObject.THISMONTH_ADD = num2.Value;
                currentObject.THISMONTH_CONSUME = num3.Value;
                currentObject.THISMONTH_STORE = num4.Value;
                currentObject.REMARK = txtRemark.Text;
            }
        }

        private bool check(out string err)
        {
            err = "";
            if (HOilLuboilReportService.Instance.IfTheMonthChecked(CurrentObject.SHIP_ID, date1.Value, CommonOperation.ConstParameter.IsLandVersion, out err))
            {
                string message = "";
                if (CommonOperation.ConstParameter.IsLandVersion)
                {
                    message = "当前月份的滑油报告已经进入SAP,不能再进行任何处理!";
                }
                else
                {
                    message = "当前月份的滑油报告已经经过船舶端审核,不能再进行任何处理!";
                }

                MessageBox.Show(message);
                return false;
            }

            if ("".Equals(cob3.Text))
            {
                MessageBoxEx.Show("润滑油不能为空!", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            DataTable dtb = HOilLuboilConsumeService.Instance.GetInfoByMonthOil(CurrentObject.SHIP_ID, date1.Value, cob3.SelectedValue.ToString(), out err);
            if (dtb.Rows.Count > 0)
            {
                MessageBoxEx.Show("该润滑油" + date1.Value.ToString("yyyy/MM") + "月消耗存量已经存在!", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string err = "";

            if (!check(out err))
                return;
            this.FormToObject(out err);      //从界面获取数据到对象中.
            bool returnValue = HOilLuboilConsumeService.Instance.saveUnit(currentObject, out err);
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

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}