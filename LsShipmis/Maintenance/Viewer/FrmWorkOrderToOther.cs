/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmWorkOrderToOther.cs
 * 创 建 人：李景育
 * 创建时间：2009-06-01
 * 标    题：工单安排给他人业务窗体
 * 功能描述：实现工单安排给他人的功能
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
using CommonViewer.BaseForm;
using Maintenance.Services;
using CommonViewer.BaseControlService;
using CommonViewer.BaseControl;

namespace Maintenance.Viewer
{
    /// <summary>
    /// 工单安排给他人业务窗体.
    /// </summary>
    public partial class FrmWorkOrderToOther : CommonViewer.BaseForm.FormBase
    {  
        /// <summary>
        /// 存放列与列标题的集合.
        /// </summary>
        private Dictionary<string, string> dictColumns = new Dictionary<string, string>();

        /// <summary>
        /// 选择的要安排给他人的工单信息.
        /// </summary>
        private DataTable dtbWkOrderSel = null;

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="dtbWkOrderSel">选择的要安排给他人的工单信息</param>
        public FrmWorkOrderToOther(DataTable dtbWkOrderSel)
        {
            InitializeComponent();
            this.dtbWkOrderSel = dtbWkOrderSel;
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWorkOrderToOther_Load(object sender, EventArgs e)
        {
            this.setComboBox();          //设置窗体所需的下拉列表框的数据源.
            this.loadData_SelWorkOrder();//加载要安排给他人的工单信息.

            //加载网格控件默认的列宽信息.
            dgvWorkOrder.LoadGridView("FrmWorkOrderToOther.dgvWorkOrder");
            textBox1.Text = DateTime.Now.ToShortDateString() + ":由" + CommonOperation.ConstParameter.UserName + "重新安排";
        }

        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        { 
            //1.责任人岗位下拉列表.
            DataTable dtbPrincipalPostGrid = BaseInfo.DataAccess.PostService.Instance.GetLandOrShipPostList(false, false);
            FormControlOption.Instance.SetComboBoxValue(cboPrincipalPostGrid, dtbPrincipalPostGrid, 0, 3);
            DgvBindDrop dgvBindDrop1 = new DgvBindDrop();
            dgvBindDrop1.bindDropToDgv(dgvWorkOrder, cboPrincipalPostGrid, 9, false, 1);

            //2.确认者岗位下拉列表.
            DataTable dtbConfirmPostGrid = BaseInfo.DataAccess.PostService.Instance.GetLandOrShipPostList(false, true);
            FormControlOption.Instance.SetComboBoxValue(cboConfirmPostGrid, dtbConfirmPostGrid, 0, 3);
            DgvBindDrop dgvBindDrop2 = new DgvBindDrop();
            dgvBindDrop2.bindDropToDgv(dgvWorkOrder, cboConfirmPostGrid, 11, false, 1);
        }

        /// <summary>
        /// 加载工单信息.
        /// </summary>
        private void loadData_SelWorkOrder()
        {
            bdsWorkOrder.DataSource = dtbWkOrderSel;
            dgvWorkOrder.DataSource = bdsWorkOrder;

            //设置列标题.
            dictColumns.Clear();
            dictColumns.Add("workordername", "工单名称");
            dictColumns.Add("circleortimingname", "定期/定时");
            dictColumns.Add("workorderstatename", "工单状态");
            dictColumns.Add("principalpostname", "责任人岗位");
            dictColumns.Add("confirmpostname", "确认人岗位");
            dictColumns.Add("planexedate", "预计执行日期");
            dictColumns.Add("circlefrontlimitdate", "前允差日期");
            dictColumns.Add("circlebacklimitdate", "后允差日期");
            dictColumns.Add("nextvalue", "预计执行表值");
            dictColumns.Add("timingfrontlimithours", "前允差小时数");
            dictColumns.Add("timingbacklimithours", "后允差小时数");
            dgvWorkOrder.SetDgvGridColumns(dictColumns);
            dgvWorkOrder.SetDataGridViewNoSort();

            dgvWorkOrder.Columns["nextvalue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvWorkOrder.Columns["timingfrontlimithours"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvWorkOrder.Columns["timingbacklimithours"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        /// <summary>
        /// 保存修改的信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.

            dgvWorkOrder.EndEdit();
            bdsWorkOrder.EndEdit();
 
            //更新结果报告.
            if (WorkOrderService.Instance.WorkOrderToOther(dtbWkOrderSel,textBox1.Text, out err))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBoxEx.Show(err, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// 关闭窗体.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// 窗体关闭时保存网格相关信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWorkOrderToOther_FormClosing(object sender, FormClosingEventArgs e)
        {
            //保存网格相关信息.
            dgvWorkOrder.SaveGridView("FrmWorkOrderToOther.dgvWorkOrder");
        }
    }
}