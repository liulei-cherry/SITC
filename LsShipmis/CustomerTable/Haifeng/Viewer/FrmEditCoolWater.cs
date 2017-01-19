/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 创 建 人：黄家龙
 * 创建时间：2011-08-15
 * 功能描述：冷却水化验及处理
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
    public partial class FrmEditCoolWater : CommonViewer.BaseForm.FormBase
    {

        #region 窗体对象
        //存储格式为yyyy.MM
        string fileDateMonth;
        //存储格式为yyyy.MM.dd
        string fileDate;
        //是否为编辑 true编辑 false新增.
        bool editFlag = false;

        string shipID;
        ReportCoolwater nowObject = new ReportCoolwater();
        public ReportCoolwater NowObject
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
        private FrmEditCoolWater()
        {
            InitializeComponent();
        }

        public FrmEditCoolWater(string shipid, ReportCoolwater tempObject)
        {
            InitializeComponent();

            if (tempObject != null)
            {
                NowObject = tempObject;
                editFlag = true;
            }
            else
            {
                this.AddDetailButton.Visible = false;
            }

            //yearValue = year;
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
        /// 增加日详细信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDetailButton_Click(object sender, EventArgs e)
        {
            //编辑为true  新增为false
            this.editFlag = false;

            this.txtLinerConcentration.Text = "";
            this.txtPistonDosage.Text = "";
            this.txtOilConcentration.Text = "";
            this.txtOilDosage.Text = "";
            this.txtLinerDosage.Text = "";
            this.txtPistonConcentration.Text = "";
            this.dtpDealDate.Value = DateTime.Now;
            this.txtSecondConcentration.Text = "";
            this.txtSecondDosage.Text = "";
        }

        public void FormToObject(out string err)
        {
            err = "";

            if (nowObject != null)
            {
                nowObject.Medcine = this.txtMedcine.Text;
                nowObject.ExperimentDealSign = this.txtPerson.Text;
                nowObject.ChiefSign = this.txtChief.Text;
                nowObject.MainLinerConcentration = this.txtLinerConcentration.Text;
                nowObject.MainLInerDosage = this.txtLinerDosage.Text;
                nowObject.MainPistonConcentration = this.txtPistonConcentration.Text;
                nowObject.MainPistonDosage = this.txtPistonDosage.Text;
                nowObject.MainOilConcentration = this.txtOilConcentration.Text;
                nowObject.MainOilDosage = this.txtOilDosage.Text;
                nowObject.SecondConcentration = this.txtSecondConcentration.Text;
                nowObject.SecondDosage = this.txtSecondDosage.Text;
                nowObject.SHIP_ID = this.shipID;
                nowObject.ExperimentDealDate = this.dtpDealDate.Value;
              
                if (this.txtPerson.Text.Length != 0 && txtPersonTextChange)
                {
                    nowObject.ExperimentDealSignDate = DateTime.Now;
                }
                else
                {
                    nowObject.ExperimentDealSignDate = DateTime.MinValue;
                }

                if (this.txtChief.Text.Length != 0 && txtChiefTextChange)
                {
                    nowObject.ChiefSignData = DateTime.Now;
                }
                else
                {
                    nowObject.ChiefSignData = DateTime.MinValue;
                }

                if (nowObject.File_ID == null)
                {
                    nowObject.File_ID = Guid.NewGuid().ToString();
                }

                fileDateMonth = this.dtpDealDate.Value.ToString("yyyy.MM");
                fileDate = this.dtpDealDate.Value.ToString("yyyy.MM.dd");
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
                MessageBoxEx.Show("校验失败:" + err,"提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            this.FormToObject(out err);      //从界面获取数据到对象中.

            if (!editFlag) //新.
            {
                nowObject.Report_CoolWater_Id = null;

                //检查数据库是否已存在此条记录.
                if (ReportCoolwaterService.Instance.CheckSubDetail(fileDate, shipID))
                {
                    MessageBoxEx.Show("数据库已经存在此日的处理信息,请查看日期选择是否正确","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
            }

            returnValue = ReportCoolwaterService.Instance.UpdateSomeRecord(fileDateMonth, shipID, nowObject);

            if (returnValue)
            {
                MessageBoxEx.Show("保存成功", "", new MessageBoxButtons(), MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBoxEx.Show("保存失败,原因是:" + err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// 窗体控件值校验.
        /// </summary>
        /// <param name="err"></param>
        /// <returns></returns>
        private bool check(out string err)
        {
            err = "";

            if (this.txtMedcine.Text.Length == 0)
            {
                err = "处理药剂为必填信息";
                this.txtMedcine.Focus();
                return false;
            }
            return true;
        }

        private void showObject()
        {
            if (nowObject != null)
            {
                this.txtMedcine.Text = nowObject.Medcine;
                this.txtPerson.Text = nowObject.ExperimentDealSign;
                this.txtChief.Text = nowObject.ChiefSign;
                this.txtLinerConcentration.Text = nowObject.MainLinerConcentration;
                this.txtLinerDosage.Text = nowObject.MainLInerDosage;
                this.txtPistonConcentration.Text = nowObject.MainPistonConcentration;
                this.txtPistonDosage.Text = nowObject.MainPistonDosage;
                this.txtOilConcentration.Text = nowObject.MainOilConcentration;
                this.txtOilDosage.Text = nowObject.MainOilDosage;
                this.dtpDealDate.Value = nowObject.ExperimentDealDate;
                this.txtSecondConcentration.Text = nowObject.SecondConcentration;
                this.txtSecondDosage.Text = nowObject.SecondDosage;
                
            }
        }

        bool txtPersonTextChange = false;
        private void txtPerson_TextChanged(object sender, EventArgs e)
        {
            txtPersonTextChange = true;
        }

        bool txtChiefTextChange = false;
        private void txtChief_TextChanged(object sender, EventArgs e)
        {
            txtChiefTextChange = true;
        }
    }
}