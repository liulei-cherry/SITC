/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmTimingCompGrpSel.cs
 * 创 建 人：李景育
 * 创建时间：2009-05-15
 * 标    题：定时设备组名称选择
 * 功能描述：实现把组成员设置成组时用于选择的组名，组名不能包括当前成员所在的组名
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
using Maintenance.Services;
using CommonViewer.BaseControl; 
namespace Maintenance.Viewer
{
    /// <summary>
    /// 定时设备组名称选择.
    /// </summary>
    public partial class FrmTimingCompGrpSel : CommonViewer.BaseForm.FormBase
    { 

        /// <summary>
        /// 当前成员所在的组的设备Id
        /// </summary>
        private string memGrpParentId = "";

        /// <summary>
        /// 选择的组Id
        /// </summary>
        private string gaugeId = "";

        /// <summary>
        /// 选择的组Id属性.
        /// </summary>
        public string GaugeId
        {
            get { return gaugeId; }
            set { gaugeId = value; }
        }

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="memGrpParentId">当前成员所在的组的设备Id</param>
        public FrmTimingCompGrpSel(string memGrpParentId)
        {
            InitializeComponent();
            this.memGrpParentId = memGrpParentId;
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmTimingCompGrpSel_Load(object sender, EventArgs e)
        {
            this.setListBox();
        }

        /// <summary>
        /// 设置列表框数据源.
        /// </summary>
        private void setListBox()
        {
            //设置部门下拉列表框的数据源.
            DataTable dtbCompGrp = WorkOrderService.Instance.GetCompGrp(memGrpParentId);
            lstCompGrp.DataSource = dtbCompGrp;
            lstCompGrp.DisplayMember = "comp_chinese_name";
            lstCompGrp.ValueMember = "gauge_id";
        }

        /// <summary>
        /// 选择信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lstCompGrp.SelectedValue != null)
            {
                this.GaugeId = lstCompGrp.SelectedValue.ToString();
            }
            else
            {
                MessageBoxEx.Show("没有可选择的项！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.Close();
        }

        /// <summary>
        /// 双击时选择信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstCompGrp_DoubleClick(object sender, EventArgs e)
        {
            this.btnSelect.PerformClick();
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