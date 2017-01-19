/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmMaterialOutMethod.cs
 * 创 建 人：徐正本
 * 创建时间：2008-07-01
 * 标    题：物资出库信息选择
 * 功能描述：实现物资出库信息选择业务窗体上的相关功能
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
using ItemsManage.Viewer.Forms;
using CommonOperation.Interfaces;
using BaseInfo.DataAccess;
using CommonViewer.BaseControl;
using ItemsManage;
using Maintenance.DataObject;
using ItemsManage.Viewer;
using ItemsManage.DataObject;
using ItemsManage.Services;
using Maintenance.Services;

namespace Maintenance.Viewer
{
    /// <summary>
    /// 物资出库信息选择.
    /// </summary>
    public partial class FrmSelectNotFinishedWorkOrder : CommonViewer.BaseForm.FormBase
    {
        string shipId = CommonOperation.ConstParameter.ShipId;
        public bool Selected = false;
        public List<WorkOrder> WorkOrders = new List<WorkOrder>();

        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmSelectNotFinishedWorkOrder instance = new FrmSelectNotFinishedWorkOrder();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmSelectNotFinishedWorkOrder Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmSelectNotFinishedWorkOrder.instance = new FrmSelectNotFinishedWorkOrder();
                }

                return FrmSelectNotFinishedWorkOrder.instance;
            }
        }

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmSelectNotFinishedWorkOrder()
        {
            InitializeComponent();
        }
        public FrmSelectNotFinishedWorkOrder(string shipId)
        {
            InitializeComponent();
            this.shipId = shipId;
        }
        /// <summary>
        /// 窗体启动时的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMaterialOutMethod_Load(object sender, EventArgs e)
        {
            this.loadData_WorkOrder("");    //设置库存数据源.
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterParent;
            ucPostSelect1.ChangeSelectedState(false, false, true, "所有岗位");
            ucPostSelect2.ChangeSelectedState(false, true, true, "所有岗位");
        }

        /// <summary>
        /// 设置库存信息的bindingSource数据源.
        /// </summary>
        private void loadData_WorkOrder(string componentUnitIds)
        {
            DataTable dtNotFinishedWorkOrder = null;
            string err;
            if (!WorkOrderService.Instance.GetRepairWorkOrders(shipId, componentUnitIds, out dtNotFinishedWorkOrder, out err))
            {
                MessageBoxEx.Show("获取未完成的工单时失败,错误信息请参考:\r" + err);
                return;
            }
            bdsStock.DataSource = dtNotFinishedWorkOrder;
            dgvNotFinishedWorkOrder.DataSource = bdsStock;
            dgvNotFinishedWorkOrder.LoadGridView("FrmSelectNotFinishedWorkOrder.dgvNotFinishedWorkOrder");
            dgvNotFinishedWorkOrder.Columns["ship_id"].Visible = false;
            dgvNotFinishedWorkOrder.Columns["workorderid"].Visible = false;
            dgvNotFinishedWorkOrder.Columns["principalpost"].Visible = false;
            dgvNotFinishedWorkOrder.Columns["confirmpost"].Visible = false;
            dgvNotFinishedWorkOrder.Columns["component_unit_id"].Visible = false;
            dgvNotFinishedWorkOrder.Columns["workordername"].HeaderText = "工单名称";
            dgvNotFinishedWorkOrder.Columns["circleortimingname"].HeaderText = "周期类型";
            dgvNotFinishedWorkOrder.Columns["workorderstatename"].HeaderText = "工单当前状态";
            dgvNotFinishedWorkOrder.Columns["principalpostname"].HeaderText = "负责人岗位";
            dgvNotFinishedWorkOrder.Columns["confirmpostname"].HeaderText = "确认者岗位";
            dgvNotFinishedWorkOrder.Columns["planexedate"].HeaderText = "计划完成日期";
            dgvNotFinishedWorkOrder.Columns["workinfodetail"].HeaderText = "工作内容";
            dgvNotFinishedWorkOrder.Columns["workexecutor"].HeaderText = "工单执行者";
            dgvNotFinishedWorkOrder.Columns["workcompletedinfo"].HeaderText = "工单完成情况";
            dgvNotFinishedWorkOrder.Columns["workdescription"].HeaderText = "工单补充说明";

            if (dgvNotFinishedWorkOrder.Columns["select"] == null)//如果选择列已经存在，则不能重复添加.
            {
                DataGridViewCheckBoxColumn dgvChkCol = new DataGridViewCheckBoxColumn();
                dgvChkCol.Name = "select";
                dgvChkCol.HeaderText = "选择";
                dgvChkCol.DefaultCellStyle.BackColor = Color.Linen;
                dgvChkCol.DataPropertyName = "select";
                dgvChkCol.Width = 40;
                dgvNotFinishedWorkOrder.Columns.Insert(0, dgvChkCol);
            }
            else dgvNotFinishedWorkOrder.Columns["select"].DisplayIndex = 0;

            filter();
        }

        /// <summary>
        /// 释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSelectNotFinishedWorkOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
            dgvNotFinishedWorkOrder.SaveGridView("FrmSelectNotFinishedWorkOrder.dgvNotFinishedWorkOrder");
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Selected = false;
            this.Close();
        }

        private void bdNgSelect_Click(object sender, EventArgs e)
        {
            string err;
            WorkOrders.Clear();
            if (dgvNotFinishedWorkOrder.Columns.Contains("select"))
            {
                foreach (DataGridViewRow dr in dgvNotFinishedWorkOrder.Rows)
                {
                    if (dr.Cells["select"].Value != null && (bool)dr.Cells["select"].Value)
                    {
                        WorkOrder wo = WorkOrderService.Instance.getObject(dr.Cells["workorderid"].Value.ToString(), out err);
                        if (wo != null && !wo.IsWrong)
                            WorkOrders.Add(wo);
                    }
                }
                if (WorkOrders.Count > 0)
                {
                    Selected = true;
                    this.Close();
                    return;
                }
                else
                {
                    MessageBoxEx.Show("没有选择任何数据.");
                }
            }
            else
            {
                MessageBoxEx.Show("未发现选择列,无法判断选中的行.");
            }
        }

        private void rdoAllWorkOrder_Click(object sender, EventArgs e)
        {
            loadData_WorkOrder("");
        }

        private void btnSelComponent_Click(object sender, EventArgs e)
        {
            rdoAllWorkOrder.Checked = false;
            string componentUnitIds = "";

            FrmSelectComponent frm = new FrmSelectComponent(shipId);
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                //按指定的设备筛选工单信息.
                //Equipment
                if (frm.Equipment != null)
                {
                    ComponentUnit component = frm.Equipment;
                    componentUnitIds = "";
                    List<ComponentUnit> components = ComponentUnitService.Instance.GetListComponentByParentId(component.COMPONENT_UNIT_ID);
                    componentUnitIds = "'" + component.COMPONENT_UNIT_ID + "'";
                    foreach (ComponentUnit unit in components)
                    {
                        this.getSubComponentIds(unit, ref componentUnitIds);
                    }
                }
                this.loadData_WorkOrder(componentUnitIds);
            }
        }
        /// <summary>
        /// 指定设备及下所有子设备Id组成的字符串.
        /// </summary>
        /// <param name="unit">指定的设备对象</param>
        private void getSubComponentIds(ComponentUnit unit, ref string componentUnitIds)
        {
            componentUnitIds += ",'" + unit.COMPONENT_UNIT_ID + "'";
            List<ComponentUnit> units = ComponentUnitService.Instance.GetListComponentByParentId(unit.COMPONENT_UNIT_ID);
            if (units.Count > 0)
            {
                foreach (ComponentUnit ounit in units)
                {
                    getSubComponentIds(ounit, ref componentUnitIds);
                }
            }
        }

        private void dgvNotFinishedWorkOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvNotFinishedWorkOrder.Columns[e.ColumnIndex].Name == "select")
            {
                bool select = false;
                if (dgvNotFinishedWorkOrder.CurrentRow.Cells[e.ColumnIndex].Value == null)
                    select = false;
                else select = (bool)dgvNotFinishedWorkOrder.CurrentRow.Cells[e.ColumnIndex].Value;
                dgvNotFinishedWorkOrder.CurrentRow.Cells[e.ColumnIndex].Value = !select;
            }
        }

        private void ucPostSelect1_TheSelectedChanged(string theSelectedObject)
        {
            filter();
        }

        private void ucPostSelect2_TheSelectedChanged(string theSelectedObject)
        {
            filter();
        }
        private void filter()
        {
            if (bdsStock.DataSource != null)
            {
                string filter = "";
                if (!string.IsNullOrEmpty(ucPostSelect1.GetId()))
                {
                    filter = "principalpost = '" + ucPostSelect1.GetId().Replace("'", "''") + "'";
                }
                if (!string.IsNullOrEmpty(ucPostSelect2.GetId()))
                {
                    if (filter.Length > 0) filter += " and ";
                    filter += "confirmpost = '" + ucPostSelect2.GetId().Replace("'", "''") + "'";
                }
                bdsStock.Filter = filter;
            }
        }
    }
}