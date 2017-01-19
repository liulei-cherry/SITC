/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 创 建 人：黄家龙
 * 创建时间：2011-08-15
 * 功能描述：锅炉水质处理功能
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
using CommonViewer.BaseControl;

using CustomerTable.Haifeng.DataObject;
using CustomerTable.Haifeng.Services;

namespace CustomTable.Haifeng.Viewer
{
    /// <summary>
    /// 船舶分类信息管理窗体.
    /// </summary>
    /// 
    public partial class FrmEditOneBoilerWater : CommonViewer.BaseForm.FormBase
    {
        #region 窗体对象

        /// <summary>
        /// 存储格式为yyyy.MM
        /// </summary>
        string fileDateMonth;
        /// <summary>
        /// 存储格式为yyyy.MM.dd
        /// </summary>
        string fileDate;
        /// <summary>
        /// 明细信息是否为编辑 true编辑 false新增.
        /// </summary>
        bool editFlag = false;
        /// <summary>
        /// 月份信息是否编辑  true 编辑 false 新增.
        /// </summary>
        bool editMonthInfo = false;

        string yearValue;
        string shipID;
        ReportBoilerwater nowObject = new ReportBoilerwater();

        public ReportBoilerwater NowObject
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

        #endregion

        #region 其它公共业务类
        private FormControlOption other = FormControlOption.Instance;
        Dictionary<string, string> discRate = new Dictionary<string, string>();

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmEditOneBoilerWater()
        {
            InitializeComponent();
        }

        public FrmEditOneBoilerWater(string year, string shipid, ReportBoilerwater tempObject)
        {
            InitializeComponent();

            setComboBox();                 //设置窗体所需的下拉列表框的数据源.

            if (tempObject != null)
            {
                NowObject = tempObject;

                editFlag = true;
                editMonthInfo = true;

                if (tempObject.FileDate.Month.ToString().Length == 1)
                {
                    this.cobMonth.Text = "0" + tempObject.FileDate.Month.ToString();
                }
                else
                {
                    this.cobMonth.Text = tempObject.FileDate.Month.ToString();
                }

                if (tempObject.FileDate.Day.ToString().Length == 1)
                {
                    this.cobDay.Text = "0" + tempObject.FileDate.Day.ToString();
                }
                else
                {
                    this.cobDay.Text = tempObject.FileDate.Day.ToString();
                }

                this.cobMonth.Enabled = false;
                this.cobDay.Enabled = false;
            }
            else
            {
                this.AddDetailButton.Visible = false;
            }

            yearValue = year;
            shipID = shipid;
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
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {
            cobDay.Items.Add("01");
            cobDay.Items.Add("02");
            cobDay.Items.Add("03");
            cobDay.Items.Add("04");
            cobDay.Items.Add("05");
            cobDay.Items.Add("06");
            cobDay.Items.Add("07");
            cobDay.Items.Add("08");
            cobDay.Items.Add("09");
            cobDay.Items.Add("10");
            cobDay.Items.Add("11");
            cobDay.Items.Add("12");
            cobDay.Items.Add("13");
            cobDay.Items.Add("14");
            cobDay.Items.Add("15");
            cobDay.Items.Add("16");
            cobDay.Items.Add("17");
            cobDay.Items.Add("18");
            cobDay.Items.Add("19");
            cobDay.Items.Add("20");
            cobDay.Items.Add("21");
            cobDay.Items.Add("22");
            cobDay.Items.Add("23");
            cobDay.Items.Add("24");
            cobDay.Items.Add("25");
            cobDay.Items.Add("26");
            cobDay.Items.Add("27");
            cobDay.Items.Add("28");
            cobDay.Items.Add("29");
            cobDay.Items.Add("30");
            cobDay.Items.Add("31");
            if (DateTime.Now.Day.ToString().Length == 1)
            {
                this.cobDay.Text = "0" + DateTime.Now.Day.ToString();
            }
            else
            {
                this.cobDay.Text = DateTime.Now.Day.ToString();
            }

            cobMonth.Items.Add("01");
            cobMonth.Items.Add("02");
            cobMonth.Items.Add("03");
            cobMonth.Items.Add("04");
            cobMonth.Items.Add("05");
            cobMonth.Items.Add("06");
            cobMonth.Items.Add("07");
            cobMonth.Items.Add("08");
            cobMonth.Items.Add("09");
            cobMonth.Items.Add("10");
            cobMonth.Items.Add("11");
            cobMonth.Items.Add("12");

            if (DateTime.Now.Month.ToString().Length == 1)
            {
                this.cobMonth.Text = "0" + DateTime.Now.Month.ToString();
            }
            else
            {
                this.cobMonth.Text = DateTime.Now.Month.ToString();
            }
        }

        /// <summary>
        /// 增加日详细信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDetailButton_Click(object sender, EventArgs e)
        {
            //编辑为true  新增为false
            this.editFlag = false;

            this.cobDay.SelectedIndex = 0;
            this.txtPhenolphthaleinAlkalinity.Text = "";
            this.txtPHValue.Text = "";
            this.txtRemarks.Text = "";
            this.txtSewageOn.Text = "";
            this.txtSewageNext.Text = "";
            this.txtSaltAmount.Text = "";
            this.txtHardness.Text = "";
            this.txtMedicine1Value.Text = "";
            this.txtMedicine2Value.Text = "";
            this.txtMedicine3Value.Text = "";
            this.txtCondensate.Text = "";
            this.txtCondensateDrops.Text = "";
            this.txtTankWate.Text = "";
            this.txtTankWateDrops.Text = "";

            //改变界面控件Enabled
            this.cobDay.Enabled = true;
        }

        public void FormToObject(out string err)
        {
            err = "";

            if (nowObject != null)
            {
                nowObject.BoilerCategory = this.txtBoilerCatagory.Text;
                nowObject.BoilerAirPressure = this.txtPressure.Text;
                nowObject.BoilerWaterQuantity = this.txtWater.Text;
                nowObject.ExperimentOrHandlePersonName = this.txtPerson.Text;
                nowObject.ChiefEngineerName = this.txtChief.Text;
                nowObject.PhenolphthaleinAlkalinity = this.txtPhenolphthaleinAlkalinity.Text;
                nowObject.SaltAmount = this.txtSaltAmount.Text;
                nowObject.Hardness = this.txtHardness.Text;
                nowObject.PHValue = this.txtPHValue.Text;
                nowObject.SewageOnAmount = this.txtSewageOn.Text;
                nowObject.SewageNextAmount = this.txtSewageNext.Text;
                nowObject.Medicine1 = this.txtMedicine1.Text;
                nowObject.Medicine2 = this.txtMedicine2.Text;
                nowObject.Medicine3 = this.txtMedicine3.Text;
                nowObject.Medicine1Value = this.txtMedicine1Value.Text;
                nowObject.Medicine2Value = this.txtMedicine2Value.Text;
                nowObject.Medicine3Value = this.txtMedicine3Value.Text;
                nowObject.CondensateLevel = this.txtCondensate.Text;
                nowObject.CondensateSilverNitrateDrops = this.txtCondensateDrops.Text;
                nowObject.TankWaterLeverl = this.txtTankWate.Text;
                nowObject.TankWateSilverNitrateDrops = this.txtTankWateDrops.Text;
                nowObject.SewageOnAmount = this.txtSewageOn.Text;
                nowObject.SewageOnAmount = this.txtSewageOn.Text;
                nowObject.Remarks = this.txtRemarks.Text;
                nowObject.SHIP_ID = this.shipID;
                if (nowObject.File_ID == null)
                {
                    nowObject.File_ID = Guid.NewGuid().ToString();
                }

                fileDate = this.yearValue + "." + this.cobMonth.Text + "." + this.cobDay.Text;
                fileDateMonth = this.yearValue + "." + this.cobMonth.Text;
                if (fileDate.Contains(".."))
                {
                    fileDate.Replace("..", ".");
                }
                if (fileDateMonth.Contains(".."))
                {
                    fileDateMonth.Replace("..", ".");
                }
                nowObject.FileDate = Convert.ToDateTime(fileDate);
            }
        }

        /// <summary>
        /// 保存操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            string err = "";
            bool returnValue;

            if (!check(out err))
            {
                MessageBoxEx.Show("校验失败:" + err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.FormToObject(out err);      //从界面获取数据到对象中.

            if(!editMonthInfo) //新.
            {
                //检查数据库是否已存在次月报表记录.
                if (ReportBoilerwaterService.Instance.CheckSubMonth(fileDateMonth, shipID))
                {
                    MessageBoxEx.Show("数据库已经存在此月的信息,请查看月份选择是否正确", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (!editFlag) //新.
            {
                nowObject.Report_BoilerWater_Id = null;

                //检查数据库是否已存在某月某日记录.
                if (ReportBoilerwaterService.Instance.CheckSubDetail(fileDate, shipID))
                {
                    MessageBoxEx.Show("数据库已经存在此日的信息,请查看日选择是否正确","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
            }

            returnValue = ReportBoilerwaterService.Instance.UpdateSomeRecord(fileDateMonth, shipID, nowObject);

            if (returnValue)
            {
                MessageBoxEx.Show("保存成功", "", new MessageBoxButtons(), MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBoxEx.Show("保存失败,原因:" + err, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private bool check(out string err)
        {
            err = "";

            if (this.txtBoilerCatagory.Text.Length == 0)
            {
                err = "锅炉种类为必填信息";
                this.txtBoilerCatagory.Focus();
                return false;
            }
            else if (this.txtPressure.Text.Length == 0)
            {
                err = "锅炉汽压为必填信息";
                this.txtPressure.Focus();
                return false;
            }
            else if (this.txtWater.Text.Length == 0)
            {
                err = "炉水吨数为空必填信息";
                this.txtWater.Focus();
                return false;
            }
            return true;
        }

        private void showObject()
        {
            if (nowObject != null)
            {
                this.txtBoilerCatagory.Text = nowObject.BoilerCategory;
                this.txtPressure.Text = nowObject.BoilerAirPressure;
                this.txtWater.Text = nowObject.BoilerWaterQuantity;
                this.txtPerson.Text = nowObject.ExperimentOrHandlePersonName;
                this.txtChief.Text = nowObject.ChiefEngineerName;
                this.txtPhenolphthaleinAlkalinity.Text = nowObject.PhenolphthaleinAlkalinity;
                this.txtSaltAmount.Text = nowObject.SaltAmount;
                this.txtHardness.Text = nowObject.Hardness;
                this.txtPHValue.Text = nowObject.PHValue;
                this.txtSewageOn.Text = nowObject.SewageOnAmount;
                this.txtSewageNext.Text = nowObject.SewageNextAmount;
                this.txtMedicine1.Text = nowObject.Medicine1;
                this.txtMedicine2.Text = nowObject.Medicine2;
                this.txtMedicine3.Text = nowObject.Medicine3;
                this.txtMedicine1Value.Text = nowObject.Medicine1Value;
                this.txtMedicine2Value.Text = nowObject.Medicine2Value;
                this.txtMedicine3Value.Text = nowObject.Medicine3Value;
                this.txtCondensate.Text = nowObject.CondensateLevel;
                this.txtCondensateDrops.Text = nowObject.CondensateSilverNitrateDrops;
                this.txtTankWate.Text = nowObject.TankWaterLeverl;
                this.txtTankWateDrops.Text = nowObject.TankWateSilverNitrateDrops;
                this.txtSewageOn.Text = nowObject.SewageOnAmount;
                this.txtSewageOn.Text = nowObject.SewageOnAmount;
                this.cobMonth.Text = nowObject.FileDate.Month.ToString();
                this.cobDay.Text = nowObject.FileDate.Day.ToString();
                this.txtRemarks.Text = nowObject.Remarks;
            }
        }
    }
}