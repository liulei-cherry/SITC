/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 创 建 人：夏喜龙
 * 创建时间：2011-5-12
 * 功能描述：滑油月度消耗
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
using System.IO;
using System.Windows.Forms;
using CommonOperation.BaseClass;
using CommonViewer.BaseControlService;
using CommonOperation.Interfaces;
using BaseInfo.DataAccess;
using BaseInfo.Objects;
using System.Runtime.InteropServices;
using Oil.DataObject;
using Oil.Services;
using Oil.Viewer;
using CommonViewer.BaseControl;

namespace Oil.Viewer
{
    /// <summary>
    /// 船舶分类信息管理窗体.
    /// </summary>
    /// 
    public partial class FrmOilLuboilConsume : CommonViewer.BaseForm.BaseMdiChildForm
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmOilLuboilConsume instance = new FrmOilLuboilConsume();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmOilLuboilConsume Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmOilLuboilConsume.instance = new FrmOilLuboilConsume();
                }
                return FrmOilLuboilConsume.instance;
            }
        }
        #endregion

        #region 窗体对象

        private HOilLuboilConsume currentObject;
        public HOilLuboilConsume CurrentObject
        {
            get { return currentObject; }
            set
            {
                currentObject = value;
                showObject(currentObject);
            }
        }

        private string shipID;
        public string ShipID
        {
            get { return shipID; }
            set
            {
                shipID = value;
            }
        }

        private DateTime yearMonth;
        public DateTime YearMonth
        {
            get { return yearMonth; }
            set { yearMonth = value; }
        }

        bool isFirstLoadMain = true;
        Dictionary<string, string> dictColumns = new Dictionary<string, string>();

        #endregion

        #region 其它公共业务类

        private FormControlOption other = FormControlOption.Instance;
        Dictionary<string, string> discRate = new Dictionary<string, string>();

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmOilLuboilConsume()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 主窗体加载.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmOilLuboilConsume_Load(object sender, EventArgs e)
        {
            this.num1.TextChanged += new EventHandler(num_ValueChanged);
            this.num2.TextChanged += new EventHandler(num_ValueChanged);
            this.num4.TextChanged += new EventHandler(num_ValueChanged);
            ucShipSelect1.ChangeSelectedState(false, true);
            dateYear.Value = DateTime.Today;


            loadMainData();
        }

        /// <summary>
        /// 关闭窗体.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 加载主数据.
        /// </summary>
        public void loadMainData()
        {
            shipID = ucShipSelect1.GetId();
            if (string.IsNullOrEmpty(shipID)) return;

            string err = "";
            YearMonth = new DateTime(dateYear.Value.Year, 1, 1);

            DataTable dtb = HOilLuboilConsumeService.Instance.getInfoByMonth(shipID, yearMonth, out err);
            dgvMain.DataSource = dtb;

            //加载主列项.
            if (isFirstLoadMain)
            {
                loadDataCol();
            }

            if (dtb.Rows.Count == 0) CurrentObject = null;// 没有对象则显示置空.

            //按日期进行分组，显示不同的颜色
            SetDataGridViewColor();
        }

        /// <summary>
        /// 分组显示列表
        /// </summary>
        private void SetDataGridViewColor()
        {
            //按日期进行分组，显示不同的颜色
            string last = "";
            Color groupColor = Color.FromArgb(220, 240, 255);
            Color c = Color.White;
            foreach (DataGridViewRow item in dgvMain.Rows)
            {
                if (item.Cells["RECORD_DATE"].Value.ToString() != last)
                {
                    last = item.Cells["RECORD_DATE"].Value.ToString();
                    if (c == groupColor)
                        c = Color.White;
                    else
                        c = groupColor;
                }
                item.DefaultCellStyle.BackColor = c;
            }
        }


        /// <summary>
        /// 设置主列项.
        /// </summary>
        private void loadDataCol()
        {
            dictColumns.Clear();
            dgvMain.LoadGridView("FrmOilLuboilConsume.dgvMain");
            //设置列标题.
            dictColumns.Add("RECORD_DATE", "日期");
            //suigy-修改-2015-12-08-版本4.8.4.78
            //dictColumns.Add("ForWhichType", "润滑油");
            dictColumns.Add("TRADEMARK", "润滑油");
            dictColumns.Add("OIL_NAME", "厂家");
            dictColumns.Add("LASTMONTH_LEFT", "上月结存");
            dictColumns.Add("THISMONTH_ADD", "本月增加");
            dictColumns.Add("THISMONTH_CONSUME", "本月消耗");
            dictColumns.Add("THISMONTH_STORE", "本月末库存");
            dictColumns.Add("REMARK", "备注");

            dgvMain.SetDgvGridColumns(dictColumns);
            dgvMain.SetDataGridViewNoSort();

            isFirstLoadMain = false;
        }

        private void dateYear_ValueChanged(object sender, EventArgs e)
        {
            loadMainData();
        }

        private void dgvMain_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string err = "";
                DataGridViewRow dr = dgvMain.Rows[e.RowIndex];

                string objectID = "";
                if (DBNull.Value != dr.Cells["REPORT_ID"].Value && null != dr.Cells["REPORT_ID"].Value)
                    objectID = dr.Cells["REPORT_ID"].Value.ToString();

                CurrentObject = HOilLuboilConsumeService.Instance.getObject(objectID, out err);
            }
        }

        private void showObject(HOilLuboilConsume tempObject)
        {
            if (tempObject != null)
            {
                date1.Value = tempObject.RECORD_DATE;
                cob3.SelectedValue = tempObject.OIL_ID;
                num1.Value = tempObject.LASTMONTH_LEFT;
                num2.Value = tempObject.THISMONTH_ADD;
                num3.Value = tempObject.THISMONTH_CONSUME;
                num4.Value = tempObject.THISMONTH_STORE;
                txtRemark.Text = tempObject.REMARK;
            }
            else
            {
                num1.Value = 0;
                num2.Value = 0;
                num3.Value = 0;
                num4.Value = 0;
                txtRemark.Text = "";
            }
        }

        /// <summary>
        /// 添加操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(shipID)) return;
            DateTime date = new DateTime(dateYear.Value.Year, DateTime.Today.Month, DateTime.Today.Day);
            HOilLuboilConsume tempObject = new HOilLuboilConsume(null, shipID, null, 0M, 0M, 0M, 0M, "", date);
            FrmOilLuboilConsumeEdit formNew = new FrmOilLuboilConsumeEdit(tempObject);
            formNew.ShowDialog();

            //刷新列表.
            loadMainData();
        }

        /// <summary>
        /// 删除操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {

            if (currentObject != null)
            {
                string err;
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
                    return;
                }

                DialogResult response = MessageBoxEx.Show("您确定要删除该条数据吗？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (response == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                if (currentObject.Delete(out err))
                {
                    MessageBoxEx.Show("删除成功!", "提示", new MessageBoxButtons(), MessageBoxIcon.Information);
                    loadMainData();
                }
                else
                {
                    MessageBoxEx.Show("当前对象删除失败,错误原因是:\n\n" + err, "", new MessageBoxButtons(), MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBoxEx.Show("请先选择一条记录!", "警告", new MessageBoxButtons(), MessageBoxIcon.Warning);
            }

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="err"></param>
        /// <returns></returns>
        private bool check(out string err)
        {
            err = "";
            if (HOilLuboilReportService.Instance.IfTheMonthChecked(CurrentObject.SHIP_ID, date1.Value, CommonOperation.ConstParameter.IsLandVersion, out err))
            {
                string message = "";
                if (CommonOperation.ConstParameter.IsLandVersion)
                {
                    message = "当前月份的滑油报告已经进入SAP,不能再进行任何处理!";
                }else{
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
            if (currentObject.RECORD_DATE.ToString("yyyyMM") != date1.Value.ToString("yyyyMM") || currentObject.OIL_ID != cob3.SelectedValue.ToString())
            {
                DataTable dtb = HOilLuboilConsumeService.Instance.GetInfoByMonthOil(CurrentObject.SHIP_ID, date1.Value, cob3.SelectedValue.ToString(), out err);
                if (dtb.Rows.Count > 0)
                {
                    MessageBoxEx.Show("该润滑油" + date1.Value.ToString("yyyy/MM") + "月消耗存量已经存在!", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            //当下一个月同一油种的存量已经存在时,不允许修改本月存量.
            //当已经形成月度报告时,不允许修改油的存量.
            return true;
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

        /// <summary>
        /// 保存操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {

            string err;

            if (currentObject != null)
            {
                if (!check(out err))
                {
                    return;
                }

                this.FormToObject(out err);      //从界面获取数据到对象中.

                //保存对象.
                if (!HOilLuboilConsumeService.Instance.saveUnit(currentObject, out err))
                {
                    MessageBoxEx.Show("当前对象保存失败,错误原因是:" + err, "错误", new MessageBoxButtons(), MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBoxEx.Show("保存成功!", "提示", new MessageBoxButtons(), MessageBoxIcon.Information);
                    //刷新列表.
                    loadMainData();
                }
            }
        }

        #region IFunctionChildWindow 成员

        public new List<CommonOperation.BaseClass.Authority> GetAllAuthorityCanOpenThisWindow()
        {
            List<CommonOperation.BaseClass.Authority> re = new List<CommonOperation.BaseClass.Authority>();
            re.Add(CommonOperation.BaseClass.Authority.GetALoginUserAuthority());//最低权限即可.
            return re;
        }

        //本窗体不受限制.
        public new bool JudgeTheAuthorityCanOpenThisWindow(CommonOperation.BaseClass.Authority theAuthority)
        {
            return true;
        }

        private IFunctionMainWindow theMainForm;
        public new IFunctionMainWindow TheMainForm
        {
            get { return theMainForm; }
            set { theMainForm = value; }
        }

        #endregion

        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            //分配到特定船舶的润滑油列表.
            DataTable dtb2 = HOilService.Instance.GetShipLubOil(theSelectedObject);
            other.SetComboBoxValue(cob3, dtb2, "oil_id", "ON_SHIP_USE");
            loadMainData();
        }

        private void FrmOilLuboilConsume_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
            dgvMain.SaveGridView("FrmOilLuboilConsume.dgvMain");
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            Oil.Viewer.FrmOilLuboilConsumeZed frm = Oil.Viewer.FrmOilLuboilConsumeZed.Instance;
            frm.BringToFront();
            frm.Show();
        }

        private void FrmOilLuboilConsume_Shown(object sender, EventArgs e)
        {
            //按日期进行分组，显示不同的颜色
            SetDataGridViewColor();
        }

    }
}