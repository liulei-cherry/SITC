/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmWorkOrderSpConsume.cs
 * 创 建 人：李景育
 * 创建时间：2009-06-01
 * 标    题：工单的备件消耗业务窗体
 * 功能描述：实现工单备件消耗的功能
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
using StorageManage.Services;
using Maintenance.DataObject;
using CommonViewer.BaseControl;
using ItemsManage;

namespace Maintenance.Viewer
{
    /// <summary>
    /// 工单的备件消耗业务窗体.
    /// </summary>
    public partial class FrmWorkOrderSpConsume : CommonViewer.BaseForm.FormBase
    {
        private string shipid = "";
        /// <summary>
        /// 存放列与列标题的集合.
        /// </summary>
        private Dictionary<string, string> dictColumns = new Dictionary<string, string>();
        List<StorageParameter> lstSpareIds = new List<StorageParameter>();
        /// <summary>
        /// 调用标记（1表示工单跟踪与监控界面调用，2表示查看历史界面调用）.
        /// </summary>
        private int mark = 1;

        /// <summary>
        /// 工单Id
        /// </summary>
        private string workOrderId = "";

        /// <summary>
        /// 工作信息Id
        /// </summary>
        private string workInfoId = "";

        /// <summary>
        /// 工单名称.
        /// </summary>
        private string workOrderName = "";

        private WorkOrder theWorkOrder;
        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="mark">调用标记（1表示工单跟踪与监控界面调用，2表示查看历史界面调用）</param>
        /// <param name="workOrderId">工单Id</param>
        /// <param name="workInfoId">工作信息Id</param>
        /// <param name="workOrderName">工单名称</param>
        public FrmWorkOrderSpConsume(int mark, string workOrderId, string workInfoId, string workOrderName)
        {
            InitializeComponent();
            string err;
            this.mark = mark;
            this.workOrderId = workOrderId;
            this.workInfoId = workInfoId;
            this.workOrderName = workOrderName;
            theWorkOrder = (WorkOrder)WorkOrderService.Instance.getObject(workOrderId, out err);
            if (theWorkOrder != null)
                shipid = theWorkOrder.SHIP_ID;
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWorkOrderSpConsume_Load(object sender, EventArgs e)
        {
            if (this.mark == 1)
            {
                dgvWorkOrderSpConsume.ReadOnly = false;
            }
            else if (this.mark == 2)
            {
                SaveButton.Visible = false;
                buttonEx3.Visible = false;
                buttonEx2.Visible = false;
            }

            this.lblWorkOrderName.Text = workOrderName; //工单名称.
            this.loadData_WorkOrderSpConsume();         //加载工单的备件消耗信息.
        }

        /// <summary>
        /// 加载工单的备件消耗信息.
        /// </summary>
        private void loadData_WorkOrderSpConsume()
        {
            //取得工单备件消耗信息的DataTable对象.
            DataTable dtbWorkOrderSpConsume = WorkOrderService.Instance.GetWorkOrderSpConsume(workOrderId, workInfoId);
            bdsWorkOrderSpConsume.DataSource = dtbWorkOrderSpConsume;
            dgvWorkOrderSpConsume.DataSource = bdsWorkOrderSpConsume;

            //设置列标题.
            dictColumns.Clear();
            dictColumns.Add("spare_name", "备件名称");
            dictColumns.Add("PARTNUMBER", "配件号|规格");
            dictColumns.Add("unit_name", "计量单位");
            dictColumns.Add("defaultusecount", "默认消耗数量");
            dictColumns.Add("usedcount", "实际消耗数量");
            dictColumns.Add("stocks", "船存数量");
            dictColumns.Add("finished", "是否已经出库");
            dgvWorkOrderSpConsume.SetDgvGridColumns(dictColumns);
            dgvWorkOrderSpConsume.SetDataGridViewNoSort();
            dgvWorkOrderSpConsume.Columns["spare_name"].Width = 70;
            dgvWorkOrderSpConsume.Columns["PARTNUMBER"].Width = 150;
            dgvWorkOrderSpConsume.Columns["unit_name"].Width = 70;
            dgvWorkOrderSpConsume.Columns["defaultusecount"].Width = 100;
            dgvWorkOrderSpConsume.Columns["usedcount"].Width = 100;
            dgvWorkOrderSpConsume.Columns["stocks"].Width = 100;
            dgvWorkOrderSpConsume.Columns["finished"].Width = 100;
            if (this.mark == 1)
            {
                dgvWorkOrderSpConsume.Columns["spare_name"].ReadOnly = true;
                dgvWorkOrderSpConsume.Columns["spare_name"].DefaultCellStyle.BackColor = Color.Linen;
                dgvWorkOrderSpConsume.Columns["PARTNUMBER"].ReadOnly = true;
                dgvWorkOrderSpConsume.Columns["PARTNUMBER"].DefaultCellStyle.BackColor = Color.Linen;
                dgvWorkOrderSpConsume.Columns["unit_name"].ReadOnly = true;
                dgvWorkOrderSpConsume.Columns["unit_name"].DefaultCellStyle.BackColor = Color.Linen;
                dgvWorkOrderSpConsume.Columns["defaultusecount"].ReadOnly = true;
                dgvWorkOrderSpConsume.Columns["defaultusecount"].DefaultCellStyle.BackColor = Color.Linen;
                dgvWorkOrderSpConsume.Columns["stocks"].ReadOnly = true;
                dgvWorkOrderSpConsume.Columns["stocks"].DefaultCellStyle.BackColor = Color.Linen;
                dgvWorkOrderSpConsume.Columns["finished"].ReadOnly = true;
                dgvWorkOrderSpConsume.Columns["finished"].DefaultCellStyle.BackColor = Color.Linen;
            }

            dgvWorkOrderSpConsume.Columns["unit_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvWorkOrderSpConsume.Columns["defaultusecount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvWorkOrderSpConsume.Columns["usedcount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            lstSpareIds = new List<StorageParameter>();
            foreach (DataGridViewRow dgvr in dgvWorkOrderSpConsume.Rows)
            {
                if (dgvr.Cells["finished"].Value.ToString() == "已出库")
                {
                    dgvr.Cells["usedcount"].ReadOnly = true;
                    dgvr.Cells["usedcount"].Style.BackColor = Color.Linen;
                }
                else if (dgvr.Cells["warning"].Value.ToString() == "1")
                {
                    StorageParameter spTemp = new StorageParameter();
                    dgvr.DefaultCellStyle.BackColor = Color.OrangeRed;
                    spTemp.ItemId = dgvr.Cells["spareid"].Value.ToString();
                    spTemp.Count = decimal.Parse(dgvr.Cells["defaultusecount"].Value.ToString()) - decimal.Parse(dgvr.Cells["stocks"].Value.ToString());
                    lstSpareIds.Add(spTemp);
                }
            }
        }

        /// <summary>
        /// 选择备件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelSpare_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.
            if (string.IsNullOrEmpty(workInfoId.Trim()))
            {
                MessageBoxEx.Show("临时工单无法绑定备件！", "错误提示！");
                return;
            }
            WorkInfo workInfo = (WorkInfo)WorkInfoService.Instance.getObject(workInfoId, out err);
            if (workInfo != null && !workInfo.IsWrong)
            {
                FrmWorkInfoSpare frm = new FrmWorkInfoSpare(workInfo);
                frm.ShowDialog();
                this.loadData_WorkOrderSpConsume();
            }
        }

        /// <summary>
        /// 保存工单的备件消耗信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            finish(false);
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
        private void buttonEx3_Click(object sender, EventArgs e)
        {
            Dictionary<string, StorageParameter> toOutSpares = new Dictionary<string, StorageParameter>();
            string err;
            if (string.IsNullOrEmpty(shipid) && !CommonOperation.ConstParameter.IsLandVersion)
            {
                shipid = CommonOperation.ConstParameter.ShipId;
            }

            foreach (DataGridViewRow dgvr in dgvWorkOrderSpConsume.Rows)
            {
                decimal count, stock;
                if (decimal.TryParse(dgvr.Cells["usedcount"].Value.ToString(), out count) && count > 0)
                {
                    if (decimal.TryParse(dgvr.Cells["stocks"].Value.ToString(), out stock) && stock >= count)
                    {
                        StorageParameter tempSp = new StorageParameter();
                        tempSp.ItemId = dgvr.Cells["spareid"].Value.ToString();

                        string warehouseId, warehouseName;
                        if (SpareStockService.Instance.GetSpareWarehouseInfo(tempSp.ItemId, shipid, out warehouseId, out warehouseName, out err))
                        {
                            tempSp.Count = count;
                            tempSp.WarehouseId = warehouseId;
                            toOutSpares.Add(tempSp.ItemId, tempSp);
                        }
                        else
                        {
                            MessageBoxEx.Show(err);
                            return;
                        }

                    }
                    else
                    {
                        MessageBoxEx.Show(dgvr.Cells["spare_name"].Value.ToString() + "数量不够,无法完成出库操作");
                        return;
                    }
                }
            }
            if (toOutSpares.Count == 0)
            {
                MessageBoxEx.Show("未选择任何备件进行出库操作");
                return;
            }
            if (MessageBoxEx.Show("已经出库的工单不允许再次修改,请一定确认好了再进行点击.是否确认真正出库操作?", "注意",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (!SpareDepotOperationService.Instance.SpareOut(toOutSpares,shipid,"维护保养时自动出库",out err))
                {
                    MessageBoxEx.Show(err, "错误提示");
                    return;
                }
                finish(true);
            }
        }

        private void buttonEx4_Click(object sender, EventArgs e)
        {
            //遍历所有行，把数据拷贝到指定的消耗数量列。.
            foreach (DataGridViewRow dgvr in dgvWorkOrderSpConsume.Rows)
            {
                dgvr.Cells["usedcount"].Value = dgvr.Cells["defaultusecount"].Value;
            }
        }

        private void finish(bool isOut)
        {
            string err = ""; //错误信息参数.

            if (dgvWorkOrderSpConsume.Rows.Count == 0)
            {
                MessageBoxEx.Show("无可保存的信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgvWorkOrderSpConsume.EndEdit();
            bdsWorkOrderSpConsume.EndEdit();

            DataTable dtb = (DataTable)bdsWorkOrderSpConsume.DataSource;

            //保存备件消耗信息.
            if (WorkOrderService.Instance.WorkOrderSpConsume(workOrderId, workInfoId, isOut, dtb, out err))
            {
                MessageBoxEx.Show("保存成功！", "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBoxEx.Show(err, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void buttonEx5_Click(object sender, EventArgs e)
        {
            string remark = "为" + theWorkOrder.WORKORDERNAME + "预留的备件数量不够!";
            theWorkOrder.FillThisObject();
            if (theWorkOrder.TheWorkInfo != null)
            {
                theWorkOrder.TheWorkInfo.FillThisObject();

                if (lstSpareIds.Count > 0 && theWorkOrder.TheWorkInfo.CompUnit != null)
                {
                    //打开备件申请界面.
                    if (MaintenanceConfig.openSpareApplyForm != null)
                    {
                        MaintenanceConfig.openSpareApplyForm(theWorkOrder.TheWorkInfo.CompUnit, lstSpareIds, remark);
                        return;
                    }
                    else
                    {
                        MessageBoxEx.Show("系统没有把备件申请界面注册到此处！");
                    }
                }
            }

            MessageBoxEx.Show("未发现此工单关联过设备或备件库存均满足要求", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}