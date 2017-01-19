/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmTimingCompFirstVal.cs
 * 创 建 人：李景育
 * 创建时间：2009-05-15
 * 标    题：定时设备运转小时初始化业务窗体
 * 功能描述：为定时设备录入初始的运转小时数，如果当前是组，则把该组下的所有成员也更新为同样的值
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
using System.Windows.Forms;
using CommonViewer.BaseControl;

namespace Maintenance.Viewer
{
    /// <summary>
    /// 定时设备运转小时初始化业务窗体.
    /// </summary>
    public partial class FrmTimingCompFirstVal : CommonViewer.BaseForm.FormBase
    {
        /// <summary>
        /// 原来的运转小时.
        /// </summary>
        private string oldTotalWorkHours = "";

        /// <summary>
        /// 当前设备的中文名称.
        /// </summary>
        private string compChineseName = "";

        /// <summary>
        /// 新的运转小时（初次值）.
        /// </summary>
        private string totalWorkHours = "";

        /// <summary>
        /// 新的抄表时间（初次值）.
        /// </summary>
        private string gaugeTime = "";

        /// <summary>
        /// 新的运转小时属性（初次值）.
        /// </summary>
        public string TotalWorkHours
        {
            get { return totalWorkHours; }
            set { totalWorkHours = value; }
        }

        /// <summary>
        /// 新的抄表时间属性（初次值）.
        /// </summary>
        public string GaugeTime
        {
            get { return gaugeTime; }
            set { gaugeTime = value; }
        }

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="compChineseName">当前设备的中文名称</param>
        /// <param name="oldTotalWorkHours">原来的运转小时</param>
        public FrmTimingCompFirstVal(string compChineseName, string oldTotalWorkHours)
        {
            InitializeComponent();
            this.oldTotalWorkHours = oldTotalWorkHours;
            this.compChineseName = compChineseName.Trim();
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmTimingCompFirstVal_Load(object sender, EventArgs e)
        {
            //把设备名称赋值给控件lblCompChsName
            this.lblCompChsName.Text = this.compChineseName;

            //把原来的运转小时数赋值给控件numTotalWorkHours
            if (oldTotalWorkHours != "")
            {
                numTotalWorkHours.Value = decimal.Parse(oldTotalWorkHours);
            }

            //赋当前时间.
            this.dtpGaugeTime.Value = DateTime.Now;
        }

        /// <summary>
        /// 取新的运转小时数.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (numTotalWorkHours.Value == 0)
            {
                if (MessageBoxEx.Show("当前运转小时为0，要继续吗？", "确认对话框", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    this.DialogResult = DialogResult.Cancel;
                    return;
                }
            }

            if (MessageBoxEx.Show("注意：此操作会覆盖掉原来的值及组成员的值，要继续吗？", "确认对话框", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                this.DialogResult = DialogResult.Cancel;
                return;
            }

            this.TotalWorkHours = numTotalWorkHours.Value.ToString();
            this.GaugeTime = dtpGaugeTime.Value.ToString("yyyy-MM-dd");
            this.DialogResult = DialogResult.OK;
            this.Close();            
        }

        /// <summary>
        /// 关闭窗体.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}