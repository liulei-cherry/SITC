/****************************************************************************************************
 * Copyright (C) 2009 大连陆海科技有限公司 版权所有
 * 文 件 名：
 * 创 建 人：夏喜龙
 * 创建时间：2009-05-27
 * 标    题：
 * 功能描述：工作信息管理
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
using ItemsManage.DataObject;
using ItemsManage.Services;
using ItemsManage.Viewer;
using CommonOperation.Enum;
using Maintenance.Services;
using Maintenance.Viewer;
using Maintenance.DataObject;
using CommonViewer.BaseControlService;
using CommonViewer.BaseControl;
using BaseInfo.Objects;
using BaseInfo.DataAccess;

namespace Maintenance.Viewer
{
    public partial class FrmWorkInfo : CommonViewer.BaseForm.FormBase
    {
        /// <summary>
        /// 存放列与列标题的集合.
        /// </summary>
        private Dictionary<string, string> dictColumns = new Dictionary<string, string>();
        private Dictionary<string, string> dictColumnsSun = new Dictionary<string, string>();

        /// <summary>
        /// 权限检查提示信息（没有配置或者没有权限的提示）.
        /// </summary>
        private string err = "";
        /// <summary>
        /// 权限代理业务类.
        /// </summary>
        private CommonOperation.Functions.ProxyRight proxyRight = CommonOperation.Functions.ProxyRight.Instance;
        private int ISCHECKPROJECT = -1;
        private int ISREPAIRPROJECT = -1;
        private ComponentUnit componentUnit = null;
        private Maintenance.DataObject.WorkInfo workInfo;
        public Maintenance.DataObject.WorkInfo WorkInfo
        {
            get { return workInfo; }
            set
            {
                if (null == value)
                {
                    workInfo = null;

                    ucWorkInfo.WorkInfo = value;
                    return;
                }
                workInfo = value;
                ucWorkInfo.WorkInfo = workInfo;
            }
        }

        #region 窗体单实例模型


        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmWorkInfo instance = new FrmWorkInfo();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmWorkInfo Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmWorkInfo.instance = new FrmWorkInfo();
                }

                return FrmWorkInfo.instance;
            }
        }

        #endregion

        public FrmWorkInfo()
        {
            InitializeComponent();
            this.ucWorkInfo.cancelWork += new UcWorkInfo.CancelWork(reloadLastRow);
            this.setGridShortCutBtn();           //设置界面上的网格的一些常用的快捷菜单的事件处理.
        }

        void reloadWhichRow(string workinfoId)
        {
            if (string.IsNullOrEmpty(workinfoId))
            {
                if (this.dgvWork.CurrentCell != null && this.dgvWork.CurrentCell.RowIndex >= 0)
                {
                    workinfoId = this.dgvWork.Rows[this.dgvWork.CurrentCell.RowIndex].Cells["workinfoid"].Value.ToString();
                }
            }
            this.loadWorkData();

            if (!string.IsNullOrEmpty(workinfoId))
                dgvWork.ScrollToDefinedRow("workinfoid", workinfoId);
        }

        //处理启动和停止工作.
        void reloadLastRow()
        {
            reloadWhichRow(null);
        }

        /// <summary>
        /// 功能权限设置.
        /// </summary>
        private void checkRight()
        {
            if (proxyRight.CheckRight(CommonOperation.ConstParameter.BASE_WORKINFO_EDIT, out err) == false)
            {
                this.bdNgAddNewItem.Enabled = false;
                this.dgvWork.adding = null;
                this.bdNgEditItem.Enabled = false;
                this.dgvWork.editing = null;
                this.bdNgDeleteItem.Enabled = false;
                this.dgvWork.deleting = null;
            }
            if (!CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER && !CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS)
            {
                this.dgvWorkOrder.editing = null;
                this.dgvWorkOrder.deleting = null;
                this.bdNgArrangeOrder.Enabled = false;
                this.bdNgDeleteOrder.Enabled = false;
            }
        }

        /// <summary>
        /// 设置界面上的网格的一些常用的快捷菜单的事件处理，.
        /// </summary>
        private void setGridShortCutBtn()
        {
            dgvWork.adding = new CommonViewer.UcDataGridView.Adding(deleAdding);
            dgvWork.editing = new CommonViewer.UcDataGridView.Editing(deleEditing);
            dgvWork.deleting = new CommonViewer.UcDataGridView.Deleting(deleDeleting);
            dgvWorkOrder.deleting = new CommonViewer.UcDataGridView.Deleting(deleOrderDeleting);
            dgvWorkOrder.editing = new CommonViewer.UcDataGridView.Editing(editBtn);

        }

        private void editBtn()
        {
            //取要修改的业务对象.
            DataRowView drvCurRow = (DataRowView)bdsWorkOrder.Current;
            WorkOrder workOrder = WorkOrderService.Instance.getObject(drvCurRow["WORKORDERID"].ToString(), out err);
            workOrder.FillThisObject();
            if ((int)workOrder.WORKORDERSTATE == 3)
            {
                MessageBoxEx.Show("提交免做申请的工单,在申请确认或申请打回之前不允许修改！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if ((int)workOrder.WORKORDERSTATE > 5)
            {
                MessageBoxEx.Show("已确认的工单不允许修改！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //打开弹出对话框.
            FrmWorkOrderTraceEdit frm = new FrmWorkOrderTraceEdit(workOrder);
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                this.loadWorkOrder(workOrder.GetId());
            }
        }

        private void FrmWorkInfo_Load(object sender, EventArgs e)
        {

            this.setGridShortCutBtn();          //设置界面上的网格的一些常用的快捷菜单的事件处理.
            this.checkRight();                  //功能权限设置.
            this.setComboBox();                 //设置窗体所需的下拉列表框的数据源.

            ucShipSelect1.ChangeSelectedState(false);
            ucShipSelect1.Enabled = CommonOperation.ConstParameter.IsLandVersion;
            cboWorkInfoState.Text = "运行";
            this.loadWorkData();                //加载所有工作列表信息.

            //加载网格控件默认的列宽信息.
            dgvWork.LoadGridView("FrmWorkInfo.dgvWork");
            dgvWorkOrder.LoadGridView("FrmWorkInfo.dgvWorkOrder");
        }

        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {
            //1.设置工作信息下拉列表框的选项（是4个固定值，分别是：全部、定期、定时、定期与定时）.
            Dictionary<string, string> dictCircleOrTiming = new Dictionary<string, string>();
            dictCircleOrTiming.Add("-1", "全部");
            dictCircleOrTiming.Add("1", "定期");
            dictCircleOrTiming.Add("2", "定时");
            dictCircleOrTiming.Add("3", "定期与定时");
            FormControlOption.Instance.SetComboBoxValue(cboCircleOrTiming, dictCircleOrTiming);

            //2.设置责任人岗位下拉列表框的选项.
            DataTable dtbPrincipalPost = BaseInfo.DataAccess.PostService.Instance.GetLandOrShipPostList(false, false);
            DataRow rowPost = dtbPrincipalPost.NewRow();
            rowPost["ship_headship_id"] = "";
            rowPost["headship_name"] = "全部";
            dtbPrincipalPost.Rows.InsertAt(rowPost, 0);
            FormControlOption.Instance.SetComboBoxValue(cboPrincipalPost, dtbPrincipalPost, 0, 3);

            //3.设置工作信息状态下拉列表框的选项（是3个固定值，分别是：全部、停止、运行）.
            Dictionary<string, string> dictWorkInfoState = new Dictionary<string, string>();
            dictWorkInfoState.Add("-1", "全部");
            dictWorkInfoState.Add("0", "停止");
            dictWorkInfoState.Add("1", "运行");
            FormControlOption.Instance.SetComboBoxValue(cboWorkInfoState, dictWorkInfoState);
        }

        /// <summary>
        /// 加载按条件查询出的工作信息列表.
        /// </summary>
        private void loadWorkData()
        {
            this.dgvWork.RowEnter -= new DataGridViewCellEventHandler(dgvWork_RowEnter);//取消rowEnter事件.
            //加载列表数据.
            int selectedFlag = 0;       //默认是0，代表全部工作信息.
            if (checkBox1.Checked)
            {
                selectedFlag = 1;       //1 代表是未初始化工作信息.
            }

            string CIRCLEORTIMING = cboCircleOrTiming.SelectedValue.ToString();
            string PRINCIPALPOST = cboPrincipalPost.SelectedValue.ToString();
            string WORKINFOSTATE = cboWorkInfoState.SelectedValue.ToString();
            List<string> filters = new List<string>();
            filters.Add(CIRCLEORTIMING);
            filters.Add(PRINCIPALPOST);
            filters.Add(WORKINFOSTATE);
            filters.Add(ISCHECKPROJECT.ToString());
            filters.Add(ISREPAIRPROJECT.ToString());
            if (btnSelComponent.Tag == null)
                btnSelComponent.Tag = "";
            filters.Add(btnSelComponent.Tag.ToString());

            DataTable dtbWork = WorkInfoService.Instance.GetWorkInfo(ucShipSelect1.GetId(), selectedFlag, filters, proxyRight.CheckRight(CommonOperation.ConstParameter.WATCH_OTHERS_INFO_OF_SAME_DEPT, out err));
            if (!CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS)
            {
                if (CommonOperation.ConstParameter.LoginUserInfo.ISMACHINEMAN)
                {
                    dtbWork.Select("");
                }
                else
                {
                    dtbWork.Select("");
                }
            }
            bindingSourceMain.DataSource = dtbWork;
            dgvWork.DataSource = bindingSourceMain;

            //设置列标题.
            dictColumns.Clear();
            dictColumns.Add("select", "");
            dgvWork.Columns["select"].DataPropertyName = "sel";
            dgvWork.Columns["select"].Width = 35;
            dictColumns.Add("WORKINFOCODE", "工作编号");
            dictColumns.Add("COMP_CHINESE_NAME", "保养设备");
            dictColumns.Add("WorkInfoName", "工作名称");
            dictColumns.Add("worker", "责任人");
            dictColumns.Add("CircleOrTiming", "定期/定时");
            dictColumns.Add("WORKINFOSTATE", "工作状态");
            dgvWork.SetDgvGridColumns(dictColumns);
            dgvWork.Columns["select"].Tag = 0;
            dgvWork.Columns["WorkInfoName"].Tag = 0;
            this.setDgvReadOnly();                  //设置只读属性.

            //当没有工作信息时.
            if (dtbWork.Rows.Count == 0)
            {
                workInfo = null;
                ucWorkInfo.WorkInfo = workInfo;
                ucWorkInfo.addRefrshControls();
                dgvWorkOrder.DataSource = null;
            }

            //工作信息的初始化设置。.
            ucWorkInfo.Component_unit = componentUnit;
            this.dgvWork.RowEnter += new DataGridViewCellEventHandler(dgvWork_RowEnter);//加rowEnter事件.
            if (dgvWork.Rows.Count > 0)
            {
                dgvWork.CurrentCell = dgvWork.FirstDisplayedCell;
            }
            else
            {
                ucWorkInfo.WorkInfo = null;
            }

        }

        /// <summary>
        /// 根据工作信息类型设置网格dgvWorkInfo的一些单元格的只读或者非只读属性.
        /// </summary>
        private void setDgvReadOnly()
        {
            foreach (DataGridViewColumn col in dgvWork.Columns)
            {
                col.ReadOnly = true;
            }
            dgvWork.Columns["select"].ReadOnly = false;
        }

        /// <summary>
        /// 由单条工作信息，产生的工单列表.
        /// </summary>
        private void loadWorkOrder(string workInfoID)
        {
            //string err;
            bdsWorkOrder.DataSource = WorkOrderService.Instance.GetWorkOrderForWkInfo(workInfoID);
            dgvWorkOrder.DataSource = bdsWorkOrder;

            //设置列标题.
            dictColumnsSun.Clear();
            dictColumnsSun.Add("workordername", "工单名称");
            dictColumnsSun.Add("circleortimingname", "定期/定时");
            dictColumnsSun.Add("workorderstatename", "工单状态");
            dictColumnsSun.Add("principalpostname", "责任人岗位");
            dictColumnsSun.Add("confirmpostname", "确认人岗位");
            dictColumnsSun.Add("planexedate", "预计执行日期");
            dictColumnsSun.Add("nextvalue", "预计执行表值");
            dgvWorkOrder.SetDgvGridColumns(dictColumnsSun);

            //nzj add subgird columns autosize
            if (dgvWorkOrder.DataSource != null)
            {
                dgvWorkOrder.LoadGridView("FrmWorkInfo.dgvWorkOrder");
            }
        }

        /// <summary>
        /// 加载工作信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvWork_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string err;

            if (e.RowIndex < 0)
            {
                return;
            }
            else
            {
                DataGridViewRow dr = dgvWork.Rows[e.RowIndex];

                //加载选中工作的相关工单列表.
                string workInfoID = "";
                if (DBNull.Value != dr.Cells["WorkInfoID"].Value)
                    workInfoID = dr.Cells["WorkInfoID"].Value.ToString();

                workInfo = WorkInfoService.Instance.getObject(workInfoID, out err);
                loadWorkOrder(workInfoID);

            }
            ucWorkInfo.WorkInfo = workInfo;

        }
        private void deleAdding()
        {
            Maintenance.DataObject.WorkInfo work = new Maintenance.DataObject.WorkInfo();
            work.SHIP_ID = ucShipSelect1.GetId();
            work.WORKINFOID = null;
            work.WORKINFOSTATE = 1;

            FrmEquipmentWorkInfoAddEdit frm = new FrmEquipmentWorkInfoAddEdit();
            frm.ComponentUnit = componentUnit;
            frm.WorkInfo = work;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            reloadWhichRow(work.GetId());
        }
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            deleAdding();
        }

        private void bdNgEditItem_Click(object sender, EventArgs e)
        {
            deleEditing();
        }
        private void deleEditing()
        {
            if (workInfo == null)
            {
                MessageBoxEx.Show("请选择要修改的工作信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FrmEquipmentWorkInfoAddEdit frm = new FrmEquipmentWorkInfoAddEdit();
            frm.WorkInfo = workInfo;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            reloadLastRow();
        }
        //不能如此的删除.
        //当该工作信息已经进行了工单安排后，除非删除所有工单，否则不能删除，只能停止.
        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            deleDeleting();
        }
        private void deleDeleting()
        {
            if (workInfo == null)
            {
                MessageBoxEx.Show("请选择要删除的工作信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //首先校验该工作信息是否有工单.
            int hasOrder = WorkInfoService.Instance.getSetWorks(workInfo.WORKINFOID);
            if (hasOrder >= 2)
            {
                MessageBoxEx.Show("该工作信息已经存在完成的工单，不能删除，只能暂停！");
                return;
            }
            else if (hasOrder == 1)
            {
                MessageBoxEx.Show("该工作存在未完成的工单，请先删除后再删除该工作信息！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //校验该工作信息是否有年度计划.
            DataTable dt;
            string error;
            if (!T_WORKINFO_HISTORY_OUTService.Instance.GetInfoByWorkID(workInfo.WORKINFOID, out dt, out error))
            {
                MessageBoxEx.Show(error);
                return;
            }
            if (dt.Rows.Count > 0)
            {
                MessageBoxEx.Show("该工作信息已经存在年度计划，不能删除，只能暂停！");
                return;
            }
            if (MessageBoxEx.Show("您确认删除选定的工作信息吗?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            string err = "";
            if (workInfo.Delete(out err))
            {
                MessageBoxEx.Show("工作信息删除成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.loadWorkData();    //加载单个设备的工作列表信息.
            }
            else
            {
                MessageBoxEx.Show(err, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bdNgClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmWorkInfo_Shown(object sender, EventArgs e)
        {
            this.dgvWork.ReadOnly = false;
            this.setDgvReadOnly();
        }
        private void cboCircleOrTiming_DropDownClosed(object sender, EventArgs e)
        {
            this.loadWorkData();
        }

        private void cboPrincipalPost_DropDownClosed(object sender, EventArgs e)
        {
            this.loadWorkData();
        }

        private void cboWorkInfoState_DropDownClosed(object sender, EventArgs e)
        {
            this.loadWorkData();
        }
        /// <summary>
        /// 首排工单.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgArrangeOrder_Click(object sender, EventArgs e)
        {
            //存放选择的所有行的工作信息.
            List<string> lstWorkInfoIds = new List<string>();

            dgvWork.EndEdit();
            bindingSourceMain.EndEdit();

            foreach (DataGridViewRow dgvRow in dgvWork.Rows)
            {
                if (dgvRow.Cells["select"].Value.ToString() == "1")
                {
                    string workinfoid = dgvRow.Cells["workinfoid"].Value.ToString();
                    lstWorkInfoIds.Add(workinfoid);

                    if (dgvRow.Cells["workinfostate"].Value.ToString() == "停止")
                    {
                        MessageBoxEx.Show("对于已经停止的工作信息不能安排工单！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }

            if (lstWorkInfoIds.Count == 0)
            {
                if (dgvWork.CurrentRow != null)
                {
                    if (dgvWork.CurrentRow.Cells["workinfostate"].Value.ToString() == "停止")
                    {
                        MessageBoxEx.Show("对于已经停止的工作信息不能安排工单！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    lstWorkInfoIds.Add(dgvWork.CurrentRow.Cells["workinfoid"].Value.ToString());
                }
                else
                {
                    MessageBoxEx.Show("请选择要首排的工作信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            FrmWorkInfoFirstArrange frm = new FrmWorkInfoFirstArrange(lstWorkInfoIds);
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                reloadLastRow();
            }
        }

        /// <summary>
        /// 被多选的工作信息.
        /// </summary>
        private List<Maintenance.DataObject.WorkInfo> selectedWorkInfos()
        {
            List<Maintenance.DataObject.WorkInfo> workInfos = new List<Maintenance.DataObject.WorkInfo>();

            foreach (DataGridViewRow dgvRow in dgvWork.Rows)
            {
                if (dgvRow.Cells["select"].Value.ToString().Equals("1"))
                {
                    Maintenance.DataObject.WorkInfo tempWorkInfo = new Maintenance.DataObject.WorkInfo();
                    tempWorkInfo.WORKINFOID = dgvRow.Cells["workinfoid"].Value.ToString();
                    tempWorkInfo.WORKINFONAME = dgvRow.Cells["workinfoname"].Value.ToString();
                    workInfos.Add(tempWorkInfo);
                }

            }
            return workInfos;
        }

        private void FrmWorkInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvWork.SaveGridView("FrmWorkInfo.dgvWork");
            dgvWorkOrder.SaveGridView("FrmWorkInfo.dgvWorkOrder");
            instance = null;
        }

        private void dgvWork_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bdNgEditItem_Click(sender, null);
        }

        private void dgvWorkOrder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editBtn();
        }

        private void deleOrderDeleting()
        {
            string err;

            if (dgvWorkOrder.Rows.Count == 0)
            {
                return;
            }

            DataGridViewRow dr = dgvWorkOrder.CurrentRow;
            if (dr == null)
            {
                MessageBoxEx.Show("请选择要删除的工单！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            WorkOrder order = WorkOrderService.Instance.getObject(dr.Cells["workorderid"].Value.ToString(), out err);
            if (order.WORKORDERSTATE > 2)
            {
                MessageBoxEx.Show("工单已经进入操作流程，不能删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (MessageBoxEx.Show("确认要删除选定的工单吗？", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (order.Delete(out err))
                    {
                        bdsWorkOrder.RemoveCurrent();
                        bdsWorkOrder.EndEdit();
                        bdsWorkOrder.DataSource = WorkOrderService.Instance.GetWorkOrderForWkInfo(order.WORKINFOID);
                    }
                    else
                    {
                        MessageBoxEx.Show("删除当前工单失败,可能是工单已经完成或被其它信息引用,更多信息请参考:\r" + err);
                    }
                }
            }
        }
        private void bdNgDeleteOrder_Click(object sender, EventArgs e)
        {
            deleOrderDeleting();
        }

        private void rdoAllComponent_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAllComponent.Checked) //显示所有设备.
            {
                groupBox2.Text = "工作信息列表";
                btnSelComponent.Tag = "";
                toolTip1.SetToolTip(btnSelComponent, "所有设备的工作信息");
                this.loadWorkData();
            }
            else if (string.IsNullOrEmpty(btnSelComponent.Tag.ToString()))
            {
                btnSelComponent_Click(sender, null);
            }
        }

        //选择特定设备及其下子设备的工作信息.
        private void btnSelComponent_Click(object sender, EventArgs e)
        {
            FrmSelectComponent frm = new FrmSelectComponent(ucShipSelect1.GetId());

            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                frm_nodeSelect(frm.Equipment);
            }
            this.loadWorkData();
        }

        //递归查找所有的子设备.
        void frm_nodeSelect(ComponentUnit component)
        {
            if (component == null) return;
            groupBox2.Text = component.COMP_CHINESE_NAME;
            btnSelComponent.Tag = "";
            List<ComponentUnit> components = ComponentUnitService.Instance.GetListComponentByParentId(component.COMPONENT_UNIT_ID);
            btnSelComponent.Tag = "'" + component.COMPONENT_UNIT_ID + "'";
            toolTip1.SetToolTip(btnSelComponent, component.COMP_CHINESE_NAME + "及其子设备的工作信息");
            foreach (ComponentUnit unit in components)
            {
                getSubComponentIds(unit);
            }
            rdoAllComponent.Checked = false;
        }

        private void getSubComponentIds(ComponentUnit unit)
        {
            btnSelComponent.Tag += ",'" + unit.COMPONENT_UNIT_ID + "'";
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
        /// 快速关联设备.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            List<WorkInfo> lstWorkInfos = getAllSelectWorkInfos();
            if (lstWorkInfos.Count == 0)
            {
                MessageBoxEx.Show("未选择任何内容");
                return;
            }
            FrmSelectComponent frm = new FrmSelectComponent(workInfo.SHIP_ID);
            frm.ShowDialog();
            if (frm.DialogResult != DialogResult.OK) return;
            if (frm.Equipment == null) return;
            bool haveFault = false;

            foreach (Maintenance.DataObject.WorkInfo tempWorkInfo in lstWorkInfos)
            {
                tempWorkInfo.WORKINFOTYPE = 1;
                tempWorkInfo.REFOBJID = frm.Equipment.GetId();
                if (!tempWorkInfo.Update(out err))
                {
                    haveFault = true;
                    break;
                }
            }
            if (haveFault)
            {
                MessageBoxEx.Show("操作失败,更多错误请参考:\r" + err);
            }
            else
            {
                MessageBoxEx.Show("操作完成");
                loadWorkData();
            }
        }
        private void 仅显示修理项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ISCHECKPROJECT = 1;
            仅显示修理项目ToolStripMenuItem.Checked = true;
            全部ToolStripMenuItem.Checked = false;
            仅显示非修理项目ToolStripMenuItem.Checked = false;
            this.loadWorkData();
        }

        private void 全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ISCHECKPROJECT = -1;
            仅显示修理项目ToolStripMenuItem.Checked = false;
            全部ToolStripMenuItem.Checked = true;
            仅显示非修理项目ToolStripMenuItem.Checked = false;
            this.loadWorkData();
        }

        private void 仅显示非修理项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ISCHECKPROJECT = 0;
            仅显示修理项目ToolStripMenuItem.Checked = false;
            全部ToolStripMenuItem.Checked = false;
            仅显示非修理项目ToolStripMenuItem.Checked = true;
            this.loadWorkData();
        }

        private void 全部项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ISREPAIRPROJECT = -1;
            全部项目ToolStripMenuItem.Checked = true;
            仅显示检验项目ToolStripMenuItem.Checked = false;
            仅显示非检验项目ToolStripMenuItem.Checked = false;
            this.loadWorkData();
        }

        private void 仅显示检验项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ISREPAIRPROJECT = 1;
            全部项目ToolStripMenuItem.Checked = false;
            仅显示检验项目ToolStripMenuItem.Checked = true;
            仅显示非检验项目ToolStripMenuItem.Checked = false;
            this.loadWorkData();
        }

        private void 仅显示非检验项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ISREPAIRPROJECT = 0;
            全部项目ToolStripMenuItem.Checked = false;
            仅显示检验项目ToolStripMenuItem.Checked = false;
            仅显示非检验项目ToolStripMenuItem.Checked = true;
            this.loadWorkData();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            loadWorkData();
        }

        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            loadWorkData();
        }

        private void 全部启动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<WorkInfo> lstWorkInfos = getAllSelectWorkInfos();
            if (lstWorkInfos.Count == 0)
            {
                MessageBoxEx.Show("未选择任何内容");
                return;
            }
            if (MessageBoxEx.Show("确定启动选定的工作信息吗?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                return;
            }
            bool haveFault = false;
            foreach (WorkInfo workInfo in lstWorkInfos)
            {
                if (workInfo.WORKINFOSTATE == 0)
                {
                    workInfo.WORKINFOSTATE = 1;
                    if (!workInfo.Update(out err))
                    {
                        haveFault = true;
                        MessageBoxEx.Show(err, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }

            }
            if (!haveFault)
            {
                MessageBoxEx.Show("工作信息启动成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.loadWorkData();
            }
        }

        private void 全部停止ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<WorkInfo> lstWorkInfos = getAllSelectWorkInfos();
            if (lstWorkInfos.Count == 0)
            {
                MessageBoxEx.Show("未选择任何内容");
                return;
            }
            if (MessageBoxEx.Show("确定停止选定的工作信息吗?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                return;
            }
            bool haveFault = false;
            int deleteType = -1;//-1未选择,1,删除已经生效的工单,0,不删除已经生效的工单.
            foreach (WorkInfo workInfo in lstWorkInfos)
            {
                if (workInfo.WORKINFOSTATE == 1)
                {
                    if (WorkInfoService.Instance.getLeftValidWork(workInfo.WORKINFOID) > 0)
                    {
                        if (deleteType == -1)
                        {
                            if (MessageBoxEx.Show("工作信息存在未完成的工单，是否删除已经列入计划的工单信息?"
                               , "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3) == DialogResult.Yes)
                            {
                                deleteType = 1;
                            }
                            else
                            {
                                deleteType = 0;
                            }
                        }
                        if (deleteType == 1)
                        {
                            //是否删除已经该工作信息已列入计划的工作，1删除，0不删除.
                            if (!WorkInfoService.Instance.cancelWorkInfo(workInfo, deleteType, out err))
                            {
                                haveFault = true;
                                MessageBoxEx.Show(err, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                    }

                    workInfo.WORKINFOSTATE = 0;
                    if (!workInfo.Update(out err))
                    {
                        haveFault = true;
                        MessageBoxEx.Show(err, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
            }
            if (!haveFault)
            {
                MessageBoxEx.Show("工作信息停止成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.loadWorkData();
            }
        }
        private List<WorkInfo> getAllSelectWorkInfos()
        {

            //存放选择的所有行的工作信息.
            List<WorkInfo> lstWorkInfos = new List<Maintenance.DataObject.WorkInfo>();

            dgvWork.EndEdit();
            bindingSourceMain.EndEdit();
            string err;
            foreach (DataGridViewRow dgvRow in dgvWork.Rows)
            {
                if (dgvRow.Cells["select"].Value.ToString() == "1")
                {
                    string workinfoid = dgvRow.Cells["workinfoid"].Value.ToString();

                    Maintenance.DataObject.WorkInfo tempWorkInfo = Maintenance.Services.WorkInfoService.Instance.getObject(workinfoid, out err);
                    if (tempWorkInfo != null) lstWorkInfos.Add(tempWorkInfo);
                }
            }
            return lstWorkInfos;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            bool isSelected = checkBox2.Checked;
            foreach (DataGridViewRow dgvr in dgvWork.Rows)
            {
                dgvr.Cells["select"].Value = (isSelected ? 1 : 0);
            }
        }
    }
}