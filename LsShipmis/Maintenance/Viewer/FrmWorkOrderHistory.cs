/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmWorkOrderHistory.cs
 * 创 建 人：李景育
 * 创建时间：2009-06-03
 * 标    题：工单历史信息查看窗体
 * 功能描述：实现工单历史信息查看业务功能
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
using CommonOperation.Functions;
using ItemsManage.DataObject;
using ItemsManage.Services;
using ItemsManage.Viewer;
using Maintenance.Services;
using CommonViewer.BaseControlService;

namespace Maintenance.Viewer
{
    /// <summary>
    /// 工单历史信息查看窗体.
    /// </summary>
    public partial class FrmWorkOrderHistory : CommonViewer.BaseForm.FormBase
    {

        private ProxyRight proxyRight = ProxyRight.Instance;//权限代理业务类.
        /// <summary>
        /// 存放列与列标题的集合.
        /// </summary>
        private Dictionary<string, string> dictColumns = new Dictionary<string, string>();

        string workOrderState = ""; //工单状态.
        string workOrderType = "";  //工单类型.
        string isCheckProject = ""; //检验项目.
        string isRepairProject = "";//修理项目.
        /// <summary>
        /// 一组设备Id用逗号连接而组成的字符串.
        /// </summary>
        private string componentUnitIds = "";

        #region 上下文菜单

        /// <summary>
        /// 工作报告查看上下文菜单.
        /// </summary>
        private ToolStripMenuItem tspMnuWkMeaRpt = new ToolStripMenuItem("工作报告(&V)…");

        /// <summary>
        /// 备件消耗查看上下文菜单.
        /// </summary>
        private ToolStripMenuItem tspMnuSpareConsume = new ToolStripMenuItem("备件消耗(&L)…");

        /// <summary>
        /// 工单打印的上下文菜单.
        /// </summary>
        private ToolStripMenuItem tspMnuWkInfo = new ToolStripMenuItem("工单详情(&P)");

        /// <summary>
        /// 选择设备的上下文菜单.
        /// </summary>
        private ToolStripMenuItem tspMnuSelComp = new ToolStripMenuItem("选择设备(&Q)…");

        /// <summary>
        /// 显示所有的上下文菜单.
        /// </summary>
        private ToolStripMenuItem tspMnuShowAll = new ToolStripMenuItem("显示所有(&H)");

        #endregion

        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmWorkOrderHistory instance;

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmWorkOrderHistory Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmWorkOrderHistory.instance = new FrmWorkOrderHistory();
                }

                return FrmWorkOrderHistory.instance;
            }
        }

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmWorkOrderHistory()
        {
            InitializeComponent();

            tspMnuWkMeaRpt.Click += new EventHandler(bdNgWkMeaRpt_Click);
            tspMnuSpareConsume.Click += new EventHandler(bdNgSpareConsume_Click);
            tspMnuWkInfo.Click += new EventHandler(bdNgWkInfo_Click); 
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWorkOrderHistory_Load(object sender, EventArgs e)
        {
            ucShipSelect1.ChangeSelectedState(CommonOperation.ConstParameter.IsLandVersion, true); 
            dtpStartFinDate.Value = DateTime.Now.AddMonths(-3);
            dtpEndFinDate.Value = DateTime.Now;
            this.ucShipSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(this.ucShipSelect1_TheSelectedChanged);
            this.setGridShortCutBtn();  //设置界面上的网格的一些常用的快捷菜单的事件处理.
            this.setComboBox();         //设置窗体所需的下拉列表框的数据源.
            this.loadData_WorkOrder_His(componentUnitIds);  //加载工单历史信息.
            this.WindowState = FormWindowState.Maximized;//窗体最大化.

            //加载网格控件默认的列宽信息.
            dgvWorkOrderHis.LoadGridView("FrmWorkOrderHistory.dgvWorkOrderHis");
        }

        /// <summary>
        /// 设置界面上的网格的一些常用的快捷菜单的事件处理.
        /// </summary>
        private void setGridShortCutBtn()
        {
            dgvWorkOrderHis.CtxMenu.Items.Add(new ToolStripSeparator());
            dgvWorkOrderHis.CtxMenu.Items.Add(tspMnuWkMeaRpt);
            dgvWorkOrderHis.CtxMenu.Items.Add(tspMnuSpareConsume);
            dgvWorkOrderHis.CtxMenu.Items.Add(tspMnuWkInfo);
            dgvWorkOrderHis.CtxMenu.Items.Add(new ToolStripSeparator());
            dgvWorkOrderHis.CtxMenu.Items.Add(tspMnuSelComp);
            dgvWorkOrderHis.CtxMenu.Items.Add(tspMnuShowAll);
        }

        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {
            //3.设置责任人岗位下拉列表框的选项.
            DataTable dtbPrincipalPost = BaseInfo.DataAccess.PostService.Instance.GetLandOrShipPostList(false, false);
            DataRow rowPost = dtbPrincipalPost.NewRow();
            rowPost["ship_headship_id"] = "";
            rowPost["headship_name"] = "全部";
            dtbPrincipalPost.Rows.InsertAt(rowPost, 0);
            FormControlOption.Instance.SetComboBoxValue(cboPrincipalPost, dtbPrincipalPost, 0, 3);

            //4.设置确认人岗位下拉列表框的选项.
            DataTable dtbConfirmPost = BaseInfo.DataAccess.PostService.Instance.GetLandOrShipPostList(false, true);
            DataRow rowFirmPost = dtbConfirmPost.NewRow();
            rowFirmPost["ship_headship_id"] = "";
            rowFirmPost["headship_name"] = "全部";
            dtbConfirmPost.Rows.InsertAt(rowFirmPost, 0);
            FormControlOption.Instance.SetComboBoxValue(cboConfirmPost, dtbConfirmPost, 0, 3);
        }

        /// <summary>
        /// 加载工单历史信息.
        /// </summary>
        private void loadData_WorkOrder_His(string sCompUnitIds)
        {
            string shipId = ucShipSelect1.GetId();
            if (shipId == null) shipId = "";
            string startFinDate = "";   //查询的起始日期（完工日期）.
            string endFinDate = "";     //查询的结束日期（完工日期）.
            string principalPost = "";  //责任人岗位.
            string confirmPost = "";    //确认人岗位.
            string err;

            startFinDate = dtpStartFinDate.Value.ToString("yyyy-MM-dd");
            endFinDate = dtpEndFinDate.Value.ToString("yyyy-MM-dd");
            principalPost = cboPrincipalPost.SelectedValue.ToString();
            confirmPost = cboConfirmPost.SelectedValue.ToString();

            //取得工单历史信息的DataTable对象.
            DataTable dtbWorkOrderHis = WorkOrderService.Instance.GetWorkOrderHistory(shipId, startFinDate, endFinDate, workOrderState, workOrderType,
                  principalPost, confirmPost, isCheckProject, isRepairProject, sCompUnitIds, proxyRight.CheckRight(CommonOperation.ConstParameter.WATCH_OTHERS_INFO_OF_SAME_DEPT, out err));
            bdsWorkOrderHis.DataSource = dtbWorkOrderHis;
            dgvWorkOrderHis.DataSource = bdsWorkOrderHis;

            //设置列标题.
            dictColumns.Clear();
            dictColumns.Add("workordername", "工单名称");
            dictColumns.Add("completeddate", "完工日期");
            dictColumns.Add("circleortimingname", "定期/定时");
            dictColumns.Add("workorderstatename", "确认类型");
            dictColumns.Add("principalpostname", "责任人岗位");
            dictColumns.Add("workexecutor", "执行人");
            dictColumns.Add("confirmpostname", "确认人岗位");
            dictColumns.Add("workconfirmor", "确认人");
            dictColumns.Add("planexedate", "预计执行日期");
            dictColumns.Add("excutevalue", "实际执行表值");
            dictColumns.Add("nextvalue", "预计执行表值");
            dictColumns.Add("workcompletedinfo", "完工情况说明");

            dgvWorkOrderHis.SetDgvGridColumns(dictColumns);

            dgvWorkOrderHis.Columns["excutevalue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvWorkOrderHis.Columns["nextvalue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        #region 记录筛选（根据设备选择）

        /// <summary>
        /// 选择特定设备及其下子设备的工作信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelComponent_Click(object sender, EventArgs e)
        {
            string shipId;
            if (!CommonOperation.ConstParameter.IsLandVersion)
                shipId = CommonOperation.ConstParameter.ShipId; //船舶Id
            else shipId = "";

            rdoAllWorkOrder.Checked = false;            

            FrmSelectComponent frm = new FrmSelectComponent(shipId);
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                //按指定的设备筛选工单信息.
                frm_nodeSelect(frm.Equipment);
                this.loadData_WorkOrder_His(componentUnitIds);
            }
            else
            {
                componentUnitIds = "";
            }
        }

        /// <summary>
        /// 递归查找所有的子设备.
        /// </summary>
        /// <param name="component">指定的设备对象</param>
        private void frm_nodeSelect(ComponentUnit component)
        {
            if (component != null)
            {
                grpWorkOrderList.Text = component.COMP_CHINESE_NAME + "及其子设备的工单信息列表";
                componentUnitIds = "";
                List<ComponentUnit> components = ComponentUnitService.Instance.GetListComponentByParentId(component.COMPONENT_UNIT_ID);
                componentUnitIds = "'" + component.COMPONENT_UNIT_ID + "'";
                toolTipBtnSelComp.SetToolTip(btnSelComponent, component.COMP_CHINESE_NAME + "及其子设备的工单信息列表");
                foreach (ComponentUnit unit in components)
                {
                    this.getSubComponentIds(unit);
                }
            }
        }

        /// <summary>
        /// 指定设备及下所有子设备Id组成的字符串.
        /// </summary>
        /// <param name="unit">指定的设备对象</param>
        private void getSubComponentIds(ComponentUnit unit)
        {
            componentUnitIds += ",'" + unit.COMPONENT_UNIT_ID + "'";
            List<ComponentUnit> units = ComponentUnitService.Instance.GetListComponentByParentId(unit.COMPONENT_UNIT_ID);
            if (units.Count > 0)
            {
                foreach (ComponentUnit ounit in units)
                {
                    getSubComponentIds(ounit);
                }
            }
        }

        /// <summary>
        /// 显示所有.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoAllWorkOrder_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAllWorkOrder.Checked)
            {
                grpWorkOrderList.Text = "工单信息列表";
                toolTipBtnSelComp.SetToolTip(btnSelComponent, "选择设备");
                componentUnitIds = "";
                this.loadData_WorkOrder_His(componentUnitIds);
            }
        }
        #endregion

        /// <summary>
        /// 记录筛选（起始日期）.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpStartFinDate_CloseUp(object sender, EventArgs e)
        {
            this.loadData_WorkOrder_His(componentUnitIds);
        }

        /// <summary>
        /// 记录筛选（结束日期）.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpEndFinDate_CloseUp(object sender, EventArgs e)
        {
            this.loadData_WorkOrder_His(componentUnitIds);
        }

        /// <summary>
        /// 记录筛选（责任人岗位）.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboPrincipalPost_DropDownClosed(object sender, EventArgs e)
        {
            this.loadData_WorkOrder_His(componentUnitIds);
        }

        /// <summary>
        /// 记录筛选（确认人岗位）.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboConfirmPost_DropDownClosed(object sender, EventArgs e)
        {
            this.loadData_WorkOrder_His(componentUnitIds);
        }

        /// <summary>
        /// 记录筛选（检验项目）.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboIsCheckProject_DropDownClosed(object sender, EventArgs e)
        {
            this.loadData_WorkOrder_His(componentUnitIds);
        }

        /// <summary>
        /// 记录筛选（修理项目）.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboIsRepairProject_DropDownClosed(object sender, EventArgs e)
        {
            this.loadData_WorkOrder_His(componentUnitIds);
        }

        /// <summary>
        /// 查看工作报告.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgWkMeaRpt_Click(object sender, EventArgs e)
        {
            string workOrderId = "";//当前工单Id

            if (dgvWorkOrderHis.CurrentRow != null)
            {
                workOrderId = dgvWorkOrderHis.CurrentRow.Cells["workorderid"].Value.ToString();

                FrmWorkOrderMeaRptView frm = new FrmWorkOrderMeaRptView(workOrderId);
                frm.ShowDialog();
            }
        }

        private void bdNgWkInfo_Click(object sender, EventArgs e)
        {
            if (dgvWorkOrderHis.CurrentRow != null)
            {
                FrmTaskDetail frm = new FrmTaskDetail();
                frm.Taskid = dgvWorkOrderHis.CurrentRow.Cells["workorderid"].Value.ToString();
                frm.ShowDialog();
            }
        }

        /// <summary>
        /// 查看备件消耗.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgSpareConsume_Click(object sender, EventArgs e)
        {
            string workOrderId = "";    //工单Id
            string workInfoId = "";     //工作信息Id
            string workOrderName = "";  //工单名称.

            if (bdsWorkOrderHis.Current != null)
            {
                workOrderId = dgvWorkOrderHis.CurrentRow.Cells["workorderid"].Value.ToString();
                workInfoId = dgvWorkOrderHis.CurrentRow.Cells["workinfoid"].Value.ToString();
                workOrderName = dgvWorkOrderHis.CurrentRow.Cells["workordername"].Value.ToString();

                FrmWorkOrderSpConsume frm = new FrmWorkOrderSpConsume(2, workOrderId, workInfoId, workOrderName);
                frm.ShowDialog();
            }
        }

        /// <summary>
        /// 网格搜索.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgSearch_Click(object sender, EventArgs e)
        {
            dgvWorkOrderHis.SearchInfo();
        }

        /// <summary>
        /// 窗体关闭时释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWorkOrderHistory_FormClosing(object sender, FormClosingEventArgs e)
        {
            //保存网格相关信息.
            dgvWorkOrderHis.SaveGridView("FrmWorkOrderHistory.dgvWorkOrderHis");
            instance = null;//释放窗体实例变量.
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

        private void dgvWorkOrderHis_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                FrmTaskDetail frm = new FrmTaskDetail();
                frm.Taskid = dgvWorkOrderHis.Rows[e.RowIndex].Cells["workorderid"].Value.ToString();
                frm.ShowDialog();
            }
        }

        private void tsmWorkOrderState_Click(object sender, EventArgs e)
        {
            workOrderState = "";
            if (sender.GetType() == typeof(ToolStripMenuItem))
            {
                ToolStripMenuItem item = (ToolStripMenuItem)sender;
                if (sender == tsmNotDo)
                {
                    workOrderState = "6";
                }
                else if (sender == tsmDidIt)
                {
                    workOrderState = "7";
                }
                else if (sender == tsmOverdueIt)
                {
                    workOrderState = "8";
                }
                tsmAll.Checked = tsmAll.Name.Equals(item.Name);
                tsmNotDo.Checked = tsmNotDo.Name.Equals(item.Name);
                tsmDidIt.Checked = tsmDidIt.Name.Equals(item.Name);
                tsmOverdueIt.Checked = tsmOverdueIt.Name.Equals(item.Name);
            }
            this.loadData_WorkOrder_His(componentUnitIds);
        }

        private void tsmWorkOrderType_Click(object sender, EventArgs e)
        {
            workOrderType = "";
            if (sender.GetType() == typeof(ToolStripMenuItem))
            {
                ToolStripMenuItem item = (ToolStripMenuItem)sender;
                if (sender == tsm2Recycle)
                {
                    workOrderType = "1";
                }
                else if (sender == tsmDidIt)
                {
                    workOrderType = "2";
                }
                else if (sender == tsm2Timing)
                {
                    workOrderType = "3";
                }
                else if (sender == tsm2NotTiming)
                {
                    workOrderType = "4";
                }
                else if (sender == tsmIsComplex)
                {
                    workOrderType = "5";
                }
                else if (sender == tsm2IsTemp)
                {
                    workOrderType = "6";
                }
                tsm2All.Checked = tsm2All.Name.Equals(item.Name);
                tsm2Recycle.Checked = tsm2Recycle.Name.Equals(item.Name);
                tsmDidIt.Checked = tsmDidIt.Name.Equals(item.Name);
                tsm2Timing.Checked = tsm2Timing.Name.Equals(item.Name);
                tsm2NotTiming.Checked = tsm2NotTiming.Name.Equals(item.Name);
                tsmIsComplex.Checked = tsmIsComplex.Name.Equals(item.Name);
                tsm2IsTemp.Checked = tsm2IsTemp.Name.Equals(item.Name);
            }
            this.loadData_WorkOrder_His(componentUnitIds);
        }

        private void tsmWorkOrderCheckItem_Click(object sender, EventArgs e)
        {
            isCheckProject = "";
            if (sender.GetType() == typeof(ToolStripMenuItem))
            {
                ToolStripMenuItem item = (ToolStripMenuItem)sender;
                if (sender == tsmOnlyCheckItems)
                {
                    isCheckProject = "1";
                }
                else if (sender == tsmOnlyNotCheckItems)
                {
                    isCheckProject = "0";
                }
                tsmAllCheckItems.Checked = tsmAllCheckItems.Name.Equals(item.Name);
                tsmOnlyCheckItems.Checked = tsmOnlyCheckItems.Name.Equals(item.Name);
                tsmOnlyNotCheckItems.Checked = tsmOnlyNotCheckItems.Name.Equals(item.Name);
            }
            this.loadData_WorkOrder_His(componentUnitIds);
        }
        private void tsmWorkOrderRepairItem_Click(object sender, EventArgs e)
        {
            isRepairProject = "";
            if (sender.GetType() == typeof(ToolStripMenuItem))
            {
                ToolStripMenuItem item = (ToolStripMenuItem)sender;
                if (sender == tsmOnlyRepairItems)
                {
                    isRepairProject = "1";
                }
                else if (sender == tsmOnlyNotRepairItems)
                {
                    isRepairProject = "0";
                }
                tsm3All.Checked = tsm3All.Name.Equals(item.Name);
                tsmOnlyRepairItems.Checked = tsmOnlyRepairItems.Name.Equals(item.Name);
                tsmOnlyNotRepairItems.Checked = tsmOnlyNotRepairItems.Name.Equals(item.Name);
            }
            this.loadData_WorkOrder_His(componentUnitIds);
        }

        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            this.loadData_WorkOrder_His(componentUnitIds);
        }
    }
}