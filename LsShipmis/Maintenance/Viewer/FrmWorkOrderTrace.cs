/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmWorkOrderTrace.cs
 * 创 建 人：李景育
 * 创建时间：2009-05-31
 * 标    题：工单的跟踪与监控业务窗体
 * 功能描述：实现工单的跟踪与监控业务功能
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
using ItemsManage.DataObject;
using ItemsManage.Services;
using ItemsManage.Viewer;
using Maintenance.DataObject;
using Maintenance.Services;
using CommonViewer.BaseControlService;
using OfficeOperation;
using CommonViewer;
using CommonViewer.BaseControl;
using CommonViewer.MultiLanguage;

namespace Maintenance.Viewer
{
    /// <summary>
    /// 工单的跟踪与监控业务窗体.
    /// </summary>
    public partial class FrmWorkOrderTrace : CommonViewer.BaseForm.FormBase, CommonOperation.Interfaces.IRemindViewState
    {

        /// <summary>
        /// 存放列与列标题的集合.
        /// </summary>
        private Dictionary<string, string> dictColumns = new Dictionary<string, string>();

        /// <summary>
        /// 权限代理业务类.
        /// </summary>
        private CommonOperation.Functions.ProxyRight proxyRight = CommonOperation.Functions.ProxyRight.Instance;

        /// <summary>
        /// 一组设备Id用逗号连接而组成的字符串.
        /// </summary>
        private string componentUnitIds = "";
        private string err;
        #region 上下文菜单


        /// <summary>
        /// 非周期工单的上下文菜单.
        /// </summary>
        private ToolStripMenuItem tspMnuNoPerWk = new ToolStripMenuItem("非周期工单(&M)…");

        /// <summary>
        /// 免做申请工单的上下文菜单.
        /// </summary>
        private ToolStripMenuItem tspMnuWkCancel = new ToolStripMenuItem("工单免做申请(&C)…");

        /// <summary>
        /// 安排他人工单的上下文菜单.
        /// </summary>
        private ToolStripMenuItem tspMnuWkToOther = new ToolStripMenuItem("安排他人(&T)…");

        /// <summary>
        /// 工单完工的上下文菜单.
        /// </summary>
        private ToolStripMenuItem tspMnuWkFinish = new ToolStripMenuItem("工单完工(&F)…");

        /// <summary>
        /// 工作报告查看上下文菜单.
        /// </summary>
        private ToolStripMenuItem tspMnuWkMeaRpt = new ToolStripMenuItem("工作报告(仅浏览)…");

        /// <summary>
        /// 备件消耗查看上下文菜单.
        /// </summary>
        private ToolStripMenuItem tspMnuSpareConsume = new ToolStripMenuItem("备件消耗(&L)…");

        /// <summary>
        /// 工单打回的上下文菜单.
        /// </summary>
        private ToolStripMenuItem tspMnuWkReback = new ToolStripMenuItem("工单打回(&R)");

        /// <summary>
        /// 工单确认的上下文菜单.
        /// </summary>
        private ToolStripMenuItem tspMnuWkConfirm = new ToolStripMenuItem("工单确认(&O)");

        /// <summary>
        /// 工单打印的上下文菜单.
        /// </summary>
        private ToolStripMenuItem tspMnuPrint = new ToolStripMenuItem("工单打印(&P)");

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
        private static FrmWorkOrderTrace instance = new FrmWorkOrderTrace();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmWorkOrderTrace Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmWorkOrderTrace.instance = new FrmWorkOrderTrace();
                }

                return FrmWorkOrderTrace.instance;
            }
        }

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmWorkOrderTrace()
        {
            InitializeComponent();

            //为上下文菜单项定义单击事件.
            tspMnuNoPerWk.Click += new EventHandler(bdNgNoPerWorkOrder_Click);
            tspMnuWkCancel.Click += new EventHandler(bdNgWkCancel_Click);
            tspMnuWkToOther.Click += new EventHandler(bdNgWkToOther_Click);
            tspMnuWkReback.Click += new EventHandler(bdNgWkReback_Click);
            tspMnuWkFinish.Click += new EventHandler(bdNgWkFinish_Click);
            tspMnuWkMeaRpt.Click += new EventHandler(tspMnuWkMeaRpt_Click);
            tspMnuSpareConsume.Click += new EventHandler(bdNgSpareConsume_Click);
            tspMnuWkConfirm.Click += new EventHandler(bdNgWkConfirm_Click);
            tspMnuPrint.Click += new EventHandler(bdNgPrint_Click);
            tspMnuSelComp.Click += new EventHandler(btnSelComponent_Click);
            tspMnuShowAll.Click += new EventHandler(rdoAllWorkOrder_Click);
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWorkOrderTrace_Load(object sender, EventArgs e)
        {
            ucShipSelect1.ChangeSelectedState(false, true);
            this.setComboBox();         //设置窗体所需的下拉列表框的数据源.
            this.setGridShortCutBtn();  //设置界面上的网格的一些常用的快捷菜单的事件处理.
            this.checkRight();          //功能权限设置,放在这里是避免grid的右键button重新被设置出来！.
            this.ucShipSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(this.ucShipSelect1_TheSelectedChanged);
            loadData_WorkOrder(componentUnitIds);//加载工单信息.
            this.WindowState = FormWindowState.Maximized;//窗体最大化.

            //加载网格控件默认的列宽信息.
            dgvWorkOrder.LoadGridView("FrmWorkOrderTrace.dgvWorkOrder");

        }

        /// <summary>
        /// 界面出现过设置工单的报警状态.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWorkOrderTrace_Shown(object sender, EventArgs e)
        {
            this.setAlertState();
        }

        /// <summary>
        /// 功能权限设置.
        /// </summary>
        private void checkRight()
        {
            if (!CommonOperation.ConstParameter.LoginUserInfo.ISHIGHLEVELSHIPMAN)
            {
                dgvWorkOrder.adding = null;
                dgvWorkOrder.editing = null;
                dgvWorkOrder.deleting = null;
                this.bdNgAddNewItem.Enabled = false;
                this.bdNgEditItem.Enabled = false;
                this.bdNgDeleteItem.Enabled = false;
                this.bdNgWkCancel.Enabled = false;
                this.tspMnuWkCancel.Enabled = false;
                this.bdNgWkToOther.Enabled = false;
                this.tspMnuWkToOther.Enabled = false;
                this.bdNgWkFinish.Enabled = false;
                this.tspMnuWkFinish.Enabled = false;
                this.tspMnuWkMeaRpt.Enabled = false;
                this.tspMnuSpareConsume.Enabled = false;
                this.bdNgWkReback.Enabled = false;
                this.tspMnuWkReback.Enabled = false;
            }

            if (!CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER && !CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS)
            {
                this.bdNgWkConfirm.Enabled = false;
                this.bdNgWkReback.Enabled = false;
                this.tspMnuWkConfirm.Enabled = false;
                this.tspMnuWkReback.Enabled = false;
            }
            else
            {
                this.cboWorkOrderState.Text = "待确认";
            }
        }

        /// <summary>
        /// 当网格dgvWorkOrder重新排序时重新设置工单的报警状态.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvWorkOrder_Sorted(object sender, EventArgs e)
        {
            this.setAlertState();
        }

        /// <summary>
        /// 设置界面上的网格的一些常用的快捷菜单的事件处理.
        /// </summary>
        private void setGridShortCutBtn()
        {
            dgvWorkOrder.adding = new CommonViewer.UcDataGridView.Adding(delegateAdding);
            dgvWorkOrder.editing = new CommonViewer.UcDataGridView.Editing(delegateEditing);
            dgvWorkOrder.deleting = new CommonViewer.UcDataGridView.Deleting(delegateDeleting);

            dgvWorkOrder.CtxMenu.Items.Add(new ToolStripSeparator());
            dgvWorkOrder.CtxMenu.Items.Add(tspMnuNoPerWk);
            dgvWorkOrder.CtxMenu.Items.Add(tspMnuWkCancel);
            dgvWorkOrder.CtxMenu.Items.Add(tspMnuWkToOther);
            dgvWorkOrder.CtxMenu.Items.Add(tspMnuWkFinish);
            dgvWorkOrder.CtxMenu.Items.Add(tspMnuWkMeaRpt);
            dgvWorkOrder.CtxMenu.Items.Add(tspMnuSpareConsume);
            dgvWorkOrder.CtxMenu.Items.Add(tspMnuWkReback);
            dgvWorkOrder.CtxMenu.Items.Add(tspMnuWkConfirm);
            dgvWorkOrder.CtxMenu.Items.Add(tspMnuPrint);
            dgvWorkOrder.CtxMenu.Items.Add(new ToolStripSeparator());
            dgvWorkOrder.CtxMenu.Items.Add(tspMnuSelComp);
            dgvWorkOrder.CtxMenu.Items.Add(tspMnuShowAll);
        }

        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {
            //1.设置工单状态下拉列表框的选项（是6个固定值，分别是：全部、计划、超期、免做申请、待确认、超期待确认）.
            //  已确认状态的工单将进入历史表.
            Dictionary<string, string> dictWorkOrderState = new Dictionary<string, string>();
            dictWorkOrderState.Add("", "全部(All)");
            dictWorkOrderState.Add("(1)", "计划(Plan)");
            dictWorkOrderState.Add("(3,4,5)", "待确认(Wait Confirm)");
            FormControlOption.Instance.SetComboBoxValue(cboWorkOrderState, dictWorkOrderState);

            //2.设置工作信息下拉列表框的选项（是4个固定值，分别是：全部、定期、定时、定期与定时）.
            Dictionary<string, string> dictCircleOrTiming = new Dictionary<string, string>();
            dictCircleOrTiming.Add("", "全部(All)");
            dictCircleOrTiming.Add("1", "定期(C_Date)");
            dictCircleOrTiming.Add("2", "定时(C_Hour)");
            dictCircleOrTiming.Add("3", "定期/定时(Both)");
            dictCircleOrTiming.Add("4", "非周期工单(NonCircle)");
            dictCircleOrTiming.Add("5", "合并工单(GroupW.O.)");
            dictCircleOrTiming.Add("6", "临时工单(OccasionalW.O.)");
            FormControlOption.Instance.SetComboBoxValue(cboWorkOrderType, dictCircleOrTiming);

            //3.设置检验项目下拉列表框的选项.
            Dictionary<string, string> dictCheckProject = new Dictionary<string, string>();
            dictCheckProject.Add("", "全部(ALL)");
            dictCheckProject.Add("1", "是(Yes)");
            dictCheckProject.Add("0", "否(No)");
            FormControlOption.Instance.SetComboBoxValue(cboIsCheckProject, dictCheckProject);

            //4.设置修理项目下拉列表框的选项.
            Dictionary<string, string> dictRepairProject = new Dictionary<string, string>();
            dictRepairProject.Add("", "全部(ALL)");
            dictRepairProject.Add("1", "是(Yes)");
            dictRepairProject.Add("0", "否(No)");
            FormControlOption.Instance.SetComboBoxValue(cboIsRepairProject, dictRepairProject);

        }

        /// <summary>
        /// 加载工单信息.
        /// </summary>
        /// <param name="sCompUnitIds">包含设备Id的字符串（仅当按设备筛选时才传入该参数）</param>
        private void loadData_WorkOrder(string sCompUnitIds)
        {
            dgvWorkOrder.Visible = false;
            string workOrderState = ""; //工单状态.
            string workOrderType = "";  //工单类型.
            string isCheckProject = ""; //检验项目.
            string isRepairProject = "";//修理项目.

            workOrderState = cboWorkOrderState.SelectedValue.ToString();
            workOrderType = cboWorkOrderType.SelectedValue.ToString();
            isCheckProject = cboIsCheckProject.SelectedValue.ToString();
            isRepairProject = cboIsRepairProject.SelectedValue.ToString();

            //取得工单信息的DataTable对象.
            //取得工单信息的DataTable对象.
            DataTable dtbWorkOrder;
            string err;
            dtbWorkOrder = WorkOrderService.Instance.GetWorkOrders(ucShipSelect1.GetId(), workOrderState, workOrderType,
                           isCheckProject, isRepairProject, sCompUnitIds,
                           proxyRight.CheckRight(CommonOperation.ConstParameter.WATCH_OTHERS_INFO_OF_SAME_DEPT, out err));

            bdsWorkOrder.DataSource = dtbWorkOrder;
            dgvWorkOrder.DataSource = bdsWorkOrder;

            //设置列标题.
            dictColumns.Clear();
            dictColumns.Add("select", "");
            dictColumns.Add("workordername", "工单名称");
            dictColumns.Add("circleortimingname", "定期/定时");
            dictColumns.Add("workorderstatename", "工单状态");
            dictColumns.Add("planexedate", "预计执行日期");
            dictColumns.Add("nextvalue", "预计执行表值");
            dictColumns.Add("principalpostname", "责任人岗位");
            dictColumns.Add("confirmpostname", "确认人岗位");
            //dictColumns.Add("circlefrontlimitdate", "前允差日期");
            //dictColumns.Add("circlebacklimitdate", "后允差日期");

            //dictColumns.Add("timingfrontlimithours", "前允差小时数");
            //dictColumns.Add("timingbacklimithours", "后允差小时数");
            dgvWorkOrder.SetDgvGridColumns(dictColumns);
            dgvWorkOrder.Columns["select"].Tag = 0;
            dgvWorkOrder.Columns["nextvalue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvWorkOrder.Columns["timingfrontlimithours"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvWorkOrder.Columns["timingbacklimithours"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //将除选择列以外的其它列设置为只读.
            dgvWorkOrder.ReadOnly = false;
            foreach (DataGridViewColumn dgvColumn in dgvWorkOrder.Columns)
            {
                if (dgvColumn.Name != "select")
                {
                    dgvColumn.ReadOnly = true;
                }
            }
            dgvWorkOrder.Columns["select"].DataPropertyName = "sel";

            //如果网格没有数据，那么在Form区域的值应清空（用一个空值对象完成）.
            if (dgvWorkOrder.Rows.Count == 0) this.setFormFields(new WorkOrder());
            else dgvWorkOrder.CurrentCell = dgvWorkOrder.FirstDisplayedCell;
            this.setAlertState();

            MultiLanguageTranslate.Instance.Translate(dgvWorkOrder);
            dgvWorkOrder.Visible = true;
        }

        #region 选择设备

        /// <summary>
        /// 选择特定设备及其下子设备的工作信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelComponent_Click(object sender, EventArgs e)
        {
            rdoAllWorkOrder.Checked = false;
            componentUnitIds = "";

            FrmSelectComponent frm = new FrmSelectComponent(ucShipSelect1.GetId());
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                frm_nodeSelect(frm.Equipment);
                //按指定的设备筛选工单信息.
                this.loadData_WorkOrder(componentUnitIds);
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
        private void rdoAllWorkOrder_Click(object sender, EventArgs e)
        {
            if (rdoAllWorkOrder.Checked)
            {
                componentUnitIds = "";
                grpWorkOrderList.Text = "工单信息列表";
                toolTipBtnSelComp.SetToolTip(btnSelComponent, "选择设备");
                this.loadData_WorkOrder(componentUnitIds);
            }
        }

        #endregion

        /// <summary>
        /// 记录筛选（工单状态）.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboWorkOrderState_DropDownClosed(object sender, EventArgs e)
        {
            this.loadData_WorkOrder(componentUnitIds);
        }

        /// <summary>
        /// 记录筛选（工单类型）.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboWorkOrderType_DropDownClosed(object sender, EventArgs e)
        {
            this.loadData_WorkOrder(componentUnitIds);
        }

        /// <summary>
        /// 记录筛选（检验项目）.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboIsCheckProject_DropDownClosed(object sender, EventArgs e)
        {
            this.loadData_WorkOrder(componentUnitIds);
        }

        /// <summary>
        /// 记录筛选（修理项目）.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboIsRepairProject_DropDownClosed(object sender, EventArgs e)
        {
            this.loadData_WorkOrder(componentUnitIds);
        }

        /// <summary>
        /// 当网格行变化时显示当前行的信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvWorkOrder_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //取要修改的业务对象.
            DataRowView drvCurRow = (DataRowView)bdsWorkOrder.List[e.RowIndex];
            WorkOrder workOrder = WorkOrderService.Instance.getObject(drvCurRow["workorderid"].ToString(), out err);
            this.setFormFields(workOrder);
        }

        /// <summary>
        /// 根据网格dgvWorkOrder中的当前行的相关信息，给窗体上的定期定时信息区域赋值.
        /// </summary>
        /// <param name="workOrder">WorkOrder业务实体类</param>
        private void setFormFields(WorkOrder workOrder)
        {
            workOrder.FillThisObject();
            WorkOrderService.Instance.fillAllWorkOrderInfo(workOrder, out err);
            txtCircleOrTiming.Text = workOrder.Circleortimingname;
            txtWorkOrderState.Tag = workOrder.WORKORDERSTATE;
            txtWorkOrderState.Text = workOrder.Workorderstatename;
            txtWorkOrderName.Text = workOrder.WORKORDERNAME;
            txtInsteadWkName.Text = workOrder.Insteadedwkname;
            if (workOrder.ISTEMPWORKORDER == 1)
            {
                chkIsTempWorkOrder.Checked = true;
            }
            else
            {
                chkIsTempWorkOrder.Checked = false;
            }
            if (workOrder.PLANEXEDATE.ToString("yyyy-MM-dd") != "0001-01-01")
            {
                txtPlanExeDate.Text = workOrder.PLANEXEDATE.ToString("yyyy-MM-dd");
            }
            else
            {
                txtPlanExeDate.Text = "";
            }
            if (workOrder.CIRCLEFRONTLIMITDATE.ToString("yyyy-MM-dd") != "0001-01-01")
            {
                txtCircleFrontLimitDate.Text = workOrder.CIRCLEFRONTLIMITDATE.ToString("yyyy-MM-dd");
            }
            else
            {
                txtCircleFrontLimitDate.Text = "";
            }
            if (workOrder.CIRCLEBACKLIMITDATE.ToString("yyyy-MM-dd") != "0001-01-01")
            {
                txtCircleBackLimitDate.Text = workOrder.CIRCLEBACKLIMITDATE.ToString("yyyy-MM-dd");
            }
            else
            {
                txtCircleBackLimitDate.Text = "";
            }
            txtNextValue.Text = workOrder.NEXTVALUE.ToString();
            txtTimingFrontLimitHours.Text = workOrder.TIMINGFRONTLIMITHOURS.ToString();
            txtTimingBackLimitHours.Text = workOrder.TIMINGBACKLIMITHOURS.ToString();
            txtExcuteValue.Text = workOrder.EXCUTEVALUE.ToString();
            txtEstimateValue.Text = workOrder.Estimatevalue.ToString();
            if (workOrder.COMPLETEDDATE.ToString("yyyy-MM-dd") != "0001-01-01")
            {
                txtCompletedDate.Text = workOrder.COMPLETEDDATE.ToString("yyyy-MM-dd");
            }
            else
            {
                txtCompletedDate.Text = "";
            }
            txtPrincipalPost.Text = workOrder.Principalpostname;
            txtConfirmPost.Text = workOrder.Confirmpostname;
            txtWorkExecutor.Text = workOrder.WORKEXECUTOR;
            txtWorkConfirmor.Text = workOrder.WORKCONFIRMOR;
            if (workOrder.ISCOMBINEDORDER == 1)
            {
                chkIsCombinedOrder.Checked = true;
            }
            else
            {
                chkIsCombinedOrder.Checked = false;
            }
            if (!string.IsNullOrEmpty(workOrder.INSTEADEDWKID))
            {
                chkInsteadWk.Checked = true;
            }
            else
            {
                chkInsteadWk.Checked = false;
            }
            if (workOrder.ISCHECKPROJECT == 1)
            {
                chkIsCheckProject.Checked = true;
            }
            else
            {
                chkIsCheckProject.Checked = false;
            }
            if (workOrder.ISREPAIRPROJECT == 1)
            {
                chkIsRepairProject.Checked = true;
            }
            else
            {
                chkIsRepairProject.Checked = false;
            }

            if (workOrder.TheWorkInfo != null)
                txtWorkinfoDetail.Text = workOrder.TheWorkInfo.WORKINFODETAIL;

            txtWorkCompletedInfo.Text = workOrder.WORKCOMPLETEDINFO;
            txtWorkDescription.Text = workOrder.WORKDESCRIPTION;
        }

        /// <summary>
        /// 添加临时工单.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            delegateAdding();
        }
        private void delegateAdding()
        {
            FrmWorkOrderTempAdd frm = new FrmWorkOrderTempAdd();
            frm.ShowDialog();
            rdoAllWorkOrder.Checked = true;
            rdoAllWorkOrder_Click(null, null);
            if (frm.DialogResult == DialogResult.OK)
            {
                this.loadData_WorkOrder(componentUnitIds);
            }
        }
        /// <summary>
        /// 工单修改.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgEditItem_Click(object sender, EventArgs e)
        {
            delegateEditing();
        }
        private void delegateEditing()
        {
            if (bdsWorkOrder.Current != null)
            {
                if (txtWorkOrderState.Tag.ToString() == "3")
                {
                    MessageBoxEx.Show("免做的工单不允许修改！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtWorkOrderState.Tag.ToString() == "6")
                {
                    MessageBoxEx.Show("已确认的工单不允许修改！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //取要修改的业务对象.
                DataRowView drvCurRow = (DataRowView)bdsWorkOrder.Current;
                WorkOrder workOrder = WorkOrderService.Instance.getObject(drvCurRow["workorderid"].ToString(), out err);

                //打开弹出对话框.
                FrmWorkOrderTraceEdit frm = new FrmWorkOrderTraceEdit(workOrder);
                frm.ShowDialog();
                this.loadData_WorkOrder(componentUnitIds);
            }

        }
        /// <summary>
        /// 双击表格行时弹出修改对话框.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvWorkOrder_DoubleClick(object sender, EventArgs e)
        {
            delegateEditing();
        }

        /// <summary>
        /// 工单删除.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            delegateDeleting();
        }

        private void delegateDeleting()
        {
            string err = ""; //错误信息参数.

            if (bdsWorkOrder.Current != null)
            {
                if (txtWorkOrderState.Tag.ToString() != "1")
                {
                    MessageBoxEx.Show("只能删除计划状态的工单！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBoxEx.Show("确定要删除吗？", "确认框", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }

                DataRowView drvCurRow = (DataRowView)bdsWorkOrder.Current;
                string workorderId = drvCurRow["workorderid"].ToString();
                WorkOrder workOrder = new WorkOrder();
                workOrder.WORKORDERID = workorderId;

                //更新结果报告.
                if (workOrder.Delete(out err))
                {
                    bdsWorkOrder.RemoveCurrent();
                    MessageBoxEx.Show("删除成功！", "删除成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.loadData_WorkOrder(componentUnitIds);

                }
                else
                {
                    MessageBoxEx.Show(err, "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        /// <summary>
        /// 非周期性工单.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgNoPerWorkOrder_Click(object sender, EventArgs e)
        {
            FrmWorkOrderNoPer frm = new FrmWorkOrderNoPer();
            frm.ShowDialog();
            rdoAllWorkOrder.Checked = true;
            rdoAllWorkOrder_Click(null, null);
            if (frm.DialogResult == DialogResult.OK)
            {
                this.loadData_WorkOrder(componentUnitIds);
            }
        }

        /// <summary>
        /// 工单的免做.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgWkCancel_Click(object sender, EventArgs e)
        {
            string workOrderId = ""; //工单Id

            if (bdsWorkOrder.Current != null)
            {
                if (txtWorkOrderState.Tag.ToString() == "3")
                {
                    MessageBoxEx.Show("当前工单已经是免做申请状态！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtWorkOrderState.Tag.ToString() == "4")
                {
                    MessageBoxEx.Show("待确认的工单不允许免做申请！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtWorkOrderState.Tag.ToString() == "5")
                {
                    MessageBoxEx.Show("超期待确认的工单不允许免做申请！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dgvWorkOrder.CurrentRow != null)
                {
                    workOrderId = dgvWorkOrder.CurrentRow.Cells["workorderid"].Value.ToString();
                }

                FrmWorkOrderCancel frm = new FrmWorkOrderCancel(workOrderId, txtWorkOrderName.Text, txtWorkOrderState.Text);
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    loadData_WorkOrder(componentUnitIds);
                }
            }
        }

        /// <summary>
        /// 工单的安排给他人.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgWkToOther_Click(object sender, EventArgs e)
        {
            dgvWorkOrder.EndEdit();
            bdsWorkOrder.EndEdit();

            //取选择的工单行信息组成一个新的DataTable对象.
            DataTable dtbWkOrder = (DataTable)bdsWorkOrder.DataSource;
            DataRow[] dataRowSel = dtbWkOrder.Select("sel = 1");

            //如果用户没有选择任何工单记录，那么只操作当前记录.
            if (dataRowSel.Length == 0)
            {
                if (bdsWorkOrder.Current != null)
                {
                    //把bdsWorkOrder的当前行转换成DataRow对象添加到数组dataRowSel中去.
                    DataRowView drvCur = (DataRowView)bdsWorkOrder.Current;
                    dataRowSel = new DataRow[1];        //重新初始化数组大小.
                    dataRowSel.SetValue(drvCur.Row, 0); //添加当前行.
                }
                else
                {
                    MessageBoxEx.Show("当前没有工单记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            DataTable dtbWkOrderSel = dtbWkOrder.Copy();
            dtbWkOrderSel.Rows.Clear();
            foreach (DataRow curRow in dataRowSel)
            {
                string workOrderState = curRow["workorderstate"].ToString();
                if (workOrderState == "3")
                {
                    MessageBoxEx.Show("免做的工单不能安排给他人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (workOrderState == "4")
                {
                    MessageBoxEx.Show("待确认的工单不能安排给他人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (workOrderState == "5")
                {
                    MessageBoxEx.Show("超期待确认的工单不能安排给他人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (workOrderState == "6")
                {
                    MessageBoxEx.Show("已确认的工单不能安排给他人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dtbWkOrderSel.ImportRow(curRow);
            }

            //打开安排工单给他人的对话框.
            FrmWorkOrderToOther frm = new FrmWorkOrderToOther(dtbWkOrderSel);
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                loadData_WorkOrder(componentUnitIds);
            }
        }

        /// <summary>
        /// 备件消耗.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgSpareConsume_Click(object sender, EventArgs e)
        {
            string workOrderId = "";    //工单Id
            string workInfoId = "";     //工作信息Id
            string workOrderName = "";  //工单名称.

            if (bdsWorkOrder.Current != null && dgvWorkOrder.CurrentRow != null)
            {
                workOrderId = dgvWorkOrder.CurrentRow.Cells["workorderid"].Value.ToString();
                workInfoId = dgvWorkOrder.CurrentRow.Cells["workinfoid"].Value.ToString();
                workOrderName = dgvWorkOrder.CurrentRow.Cells["workordername"].Value.ToString();

                FrmWorkOrderSpConsume frm = new FrmWorkOrderSpConsume(1, workOrderId, workInfoId, workOrderName);
                frm.ShowDialog();
            }
        }

        /// <summary>
        /// 工单的完工.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgWkFinish_Click(object sender, EventArgs e)
        {
            List<string> lstWorkOrderIds = new List<string>();  //要完工的工单Id集合.
            string workOrderId = "";      //工单Id
            string workOrderState = "";   //工单的状态.

            dgvWorkOrder.EndEdit();
            bdsWorkOrder.EndEdit();

            //取选择的工单行信息组成一个新的DataTable对象.
            DataTable dtbWkOrder = (DataTable)bdsWorkOrder.DataSource;
            DataRow[] dataRowSel = dtbWkOrder.Select("sel = 1");

            //如果用户没有选择任何工单记录，那么只操作当前记录.
            if (dataRowSel.Length == 0)
            {
                if (bdsWorkOrder.Current != null)
                {
                    //把bdsWorkOrder的当前行转换成DataRow对象添加到数组dataRowSel中去.
                    DataRowView drvCur = (DataRowView)bdsWorkOrder.Current;
                    dataRowSel = new DataRow[1];        //重新初始化数组大小.
                    dataRowSel.SetValue(drvCur.Row, 0); //添加当前行.
                }
                else
                {
                    MessageBoxEx.Show("当前没有工单记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            foreach (DataRow curRow in dataRowSel)
            {
                workOrderId = curRow["workorderid"].ToString();
                workOrderState = curRow["workorderstate"].ToString();

                if (workOrderState == "3")
                {
                    MessageBoxEx.Show("免做的工单不需要执行完工操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (workOrderState == "4")
                {
                    MessageBoxEx.Show("待确认的工单不能再执行完工操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (workOrderState == "5")
                {
                    MessageBoxEx.Show("超期待确认的工单不能再执行完工操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (workOrderState == "6")
                {
                    MessageBoxEx.Show("已确认的工单不能再执行完工操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                lstWorkOrderIds.Add(workOrderId);
            }

            if (lstWorkOrderIds.Count > 0)
            {
                //打开完工对话框.
                FrmWorkOrderFinish frm = new FrmWorkOrderFinish(lstWorkOrderIds);
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    List<string> lstNewWorkOrderIds = frm.LstNewWorkOrderIds;
                    FrmWorkOrderNewEdit frmNewEdit = new FrmWorkOrderNewEdit(lstNewWorkOrderIds);
                    frmNewEdit.ShowDialog();
                    loadData_WorkOrder(componentUnitIds);
                }
                else if (frm.DialogResult == DialogResult.No)
                {
                    loadData_WorkOrder(componentUnitIds);
                }
            }
        }

        /// <summary>
        /// 上下文菜单中的工作报告的事件处理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tspMnuWkMeaRpt_Click(object sender, EventArgs e)
        {
            string workOrderId = "";//当前工单Id

            if (dgvWorkOrder.CurrentRow != null)
            {
                workOrderId = dgvWorkOrder.CurrentRow.Cells["workorderid"].Value.ToString();

                FrmWorkOrderMeaRptView frm = new FrmWorkOrderMeaRptView(workOrderId);
                frm.ShowDialog();
            }
        }

        /// <summary>
        /// 工单的打回.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgWkReback_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.
            List<string> lstWorkOrderIds = new List<string>();  //要打回的工单Id集合.
            string workOrderId = "";      //工单Id
            int workOrderState = 1;       //工单的状态.

            dgvWorkOrder.EndEdit();
            bdsWorkOrder.EndEdit();

            //取选择的工单行信息组成一个新的DataTable对象.
            DataTable dtbWkOrder = (DataTable)bdsWorkOrder.DataSource;
            DataRow[] dataRows = dtbWkOrder.Select("sel = 1");

            //如果用户没有选择任何工单记录，那么只操作当前记录.
            if (dataRows.Length == 0)
            {
                if (bdsWorkOrder.Current != null)
                {
                    //把bdsWorkOrder的当前行转换成DataRow对象添加到数组dataRows中去.
                    DataRowView drvCur = (DataRowView)bdsWorkOrder.Current;
                    dataRows = new DataRow[1];        //重新初始化数组大小.
                    dataRows.SetValue(drvCur.Row, 0); //添加当前行.
                }
                else
                {
                    MessageBoxEx.Show("当前没有工单记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            foreach (DataRow curRow in dataRows)
            {
                workOrderId = curRow["workorderid"].ToString();
                workOrderState = int.Parse(curRow["workorderstate"].ToString());

                if (workOrderState != 3 && workOrderState != 4 && workOrderState != 5)
                {
                    MessageBoxEx.Show("只能对[免做申请]或者[待确认]或者[超期待确认]的工单执行打回操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                lstWorkOrderIds.Add(workOrderId);
            }

            if (lstWorkOrderIds.Count > 0)
            {
                OurMessageBox messagebox = new OurMessageBox("确定要执行该操作吗？\r如果确认,请描述打回原因并点击[确定]按钮,\r如果申请免做本次工单,请点击[免做申请]按钮",
                    "确认框", DateTime.Now.ToShortDateString() + "被 " + CommonOperation.ConstParameter.UserName + " 打回");
                messagebox.ShowDialog();
                if (!messagebox.Answer) return;
                //执行工单确认.
                if (WorkOrderService.Instance.WorkOrderReback(lstWorkOrderIds, messagebox.AnswerTxt, out err))
                {
                    loadData_WorkOrder(componentUnitIds);
                    MessageBoxEx.Show("打回成功！", "打回成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBoxEx.Show(err, "打回失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        /// <summary>
        /// 工单的确认.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgWkConfirm_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.
            List<string> lstWorkOrderIds = new List<string>();  //要确认的工单Id集合.
            string workOrderId = "";      //工单Id
            int workOrderState = 1;     //工单的状态.

            dgvWorkOrder.EndEdit();
            bdsWorkOrder.EndEdit();

            //取选择的工单行信息组成一个新的DataTable对象.
            DataTable dtbWkOrder = (DataTable)bdsWorkOrder.DataSource;
            DataRow[] dataRows = dtbWkOrder.Select("sel = 1");

            //如果用户没有选择任何工单记录，那么只操作当前记录.
            if (dataRows.Length == 0)
            {
                if (bdsWorkOrder.Current != null)
                {
                    //把bdsWorkOrder的当前行转换成DataRow对象添加到数组dataRows中去.
                    DataRowView drvCur = (DataRowView)bdsWorkOrder.Current;
                    dataRows = new DataRow[1];        //重新初始化数组大小.
                    dataRows.SetValue(drvCur.Row, 0); //添加当前行.
                }
                else
                {
                    MessageBoxEx.Show("当前没有工单记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            foreach (DataRow curRow in dataRows)
            {
                workOrderId = curRow["workorderid"].ToString();
                workOrderState = int.Parse(curRow["workorderstate"].ToString());

                if (workOrderState == 1)
                {
                    MessageBoxEx.Show("计划状态的工单不能执行确认操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                lstWorkOrderIds.Add(workOrderId);
            }

            if (lstWorkOrderIds.Count > 0)
            {
                if (MessageBoxEx.Show("确定要执行该操作吗？", "确认框", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }

                //执行工单确认.
                if (WorkOrderService.Instance.WorkOrderConfirm(lstWorkOrderIds, out err))
                {
                    loadData_WorkOrder(componentUnitIds);
                    MessageBoxEx.Show("确认成功！", "确认成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBoxEx.Show(err, "确认失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        /// <summary>
        /// 工单的打印.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgPrint_Click(object sender, EventArgs e)
        {
            if (dgvWorkOrder.CurrentRow == null) return;
            OperationExcel operationExcel = new OperationExcel();
            try
            {
                string err;
                DataRowView drvCurRow = (DataRowView)bdsWorkOrder.List[dgvWorkOrder.CurrentRow.Index];
                WorkOrder workOrder = WorkOrderService.Instance.getObject(drvCurRow["workorderid"].ToString(), out err);

                if (workOrder == null || workOrder.IsWrong)
                {
                    MessageBoxEx.Show("无效工单,不能打印");
                    return;
                }
                if (!operationExcel.AddTitle("(" + txtWorkOrderName.Text + ")工单信息", 1, out err)
                    || !operationExcel.InsertABodyPair(new OnePair("责任人岗位", txtPrincipalPost.Text, PairType.ALLBORDER, 2, 2), out err)
                    || !operationExcel.InsertABodyPair(new OnePair("工单执行人", txtWorkExecutor.Text, PairType.ALLBORDER, 2, 4), out err)
                    || !operationExcel.InsertABodyPair(new OnePair("确认人岗位", txtConfirmPost.Text, PairType.ALLBORDER, 2, 6), out err)
                    || !operationExcel.InsertABodyPair(new OnePair("工单确认人", txtWorkConfirmor.Text, PairType.ALLBORDER, 2, 8), out err)
                    || !operationExcel.InsertABodyPair(new OnePair("工单状态", txtWorkOrderState.Text, PairType.ALLBORDER, 3, 2), out err)
                    || !operationExcel.InsertABodyPair(new OnePair("工单类型", txtCircleOrTiming.Text, PairType.ALLBORDER, 3, 4), out err)
                    || !operationExcel.InsertABodyPair(new OnePair("计划执行日期", txtPlanExeDate.Text, PairType.ALLBORDER, 3, 6), out err)
                    || !operationExcel.InsertABodyPair(new OnePair("计划执行表值", txtNextValue.Text, PairType.ALLBORDER, 3, 8), out err)
                    || !operationExcel.InsertABodyPair(new OnePair("前允差日期", txtCircleFrontLimitDate.Text, PairType.ALLBORDER, 4, 2), out err)
                    || !operationExcel.InsertABodyPair(new OnePair("后允差日期", txtCircleBackLimitDate.Text, PairType.ALLBORDER, 4, 4), out err)
                    || !operationExcel.InsertABodyPair(new OnePair("前允差表值", txtTimingFrontLimitHours.Text, PairType.ALLBORDER, 4, 6), out err)
                    || !operationExcel.InsertABodyPair(new OnePair("后允差表值", txtTimingBackLimitHours.Text, PairType.ALLBORDER, 4, 8), out err)
                    || !operationExcel.InsertABodyPair(new OnePair("实际完工日期", txtCompletedDate.Text, PairType.ALLBORDER, 5, 2), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit("", true, 5, 4, 1, 5, true), out err)
                    || !operationExcel.InsertABodyPair(new OnePair("工作信息描述", txtWorkinfoDetail.Text, PairType.ALLBORDER, 6, 2, 7), out err)
                    || !operationExcel.InsertABodyPair(new OnePair("工单补充说明", txtWorkDescription.Text, PairType.ALLBORDER, 7, 2, 7), out err)
                    || !operationExcel.InsertABodyPair(new OnePair("工单完工说明", txtWorkCompletedInfo.Text, PairType.ALLBORDER, 8, 2, 7), out err))
                {
                    MessageBoxEx.Show(err);
                    return;
                }
                operationExcel.AddAllColumnSize(1, 20);
                operationExcel.AddAllLineSize(1, 50);
                operationExcel.AddAllLineSize(6, 50);
                operationExcel.AddAllLineSize(7, 50);
                operationExcel.AddAllLineSize(8, 50);
                FrmOurReport frmOurReport = new FrmOurReport("工单详情打印", operationExcel);
                frmOurReport.StartPosition = FormStartPosition.CenterParent;
                frmOurReport.ShowDialog();
            }
            catch (Exception exc)
            {
                MessageBoxEx.Show(exc.Message);
            }
            finally
            {
                operationExcel.Dispose();
            }
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
        /// 窗体关闭时释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWorkOrderTrace_FormClosing(object sender, FormClosingEventArgs e)
        {
            //保存网格相关信息.
            dgvWorkOrder.SaveGridView("FrmWorkOrderTrace.dgvWorkOrder");
            instance = null;//释放窗体实例变量.
        }

        /// <summary>
        /// 设置工单的报警状态（1表示进入前允差，2表示进入后允差，3表示过期，0表示正常）.
        /// </summary>
        private void setAlertState()
        {
            string alertState = ""; //当前状态（1表示进入前允差，2表示进入后允差，3表示过期，0表示正常）.

            foreach (DataGridViewRow dgvRow in dgvWorkOrder.Rows)
            {
                alertState = dgvRow.Cells["alertstate"].Value.ToString();
                if (alertState == "1")
                {
                    dgvRow.DefaultCellStyle.BackColor = Color.Yellow;
                }
                else if (alertState == "2")
                {
                    dgvRow.DefaultCellStyle.BackColor = Color.Gold;
                }
                else if (alertState == "3")
                {
                    dgvRow.DefaultCellStyle.BackColor = Color.DarkOrange;
                }
            }
        }

        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            loadData_WorkOrder(componentUnitIds);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool isSelected = checkBox1.Checked;
            foreach (DataGridViewRow dgvr in dgvWorkOrder.Rows)
            {
                dgvr.Cells["select"].Value = (isSelected ? 1 : 0);
            }
        }

        #region IRemindViewState 成员

        public void SetRemindViewApprovalState()
        {
            ucShipSelect1.SelectedText("所有船");
            cboWorkOrderState.Text = "待确认(Wait Confirm)";
            cboWorkOrderType.Text = "全部(All)";
            cboIsCheckProject.Text = "全部(ALL)";
            cboIsRepairProject.Text = "全部(ALL)";
        }

        public void SetRemindViewInformState()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}