/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmWorkOrderFinish.cs
 * 创 建 人：李景育
 * 创建时间：2009-06-01
 * 标    题：工单完工业务窗体
 * 功能描述：实现工单完工的功能
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
using ItemsManage.DataObject;
using CommonViewer.BaseControl; 

namespace Maintenance.Viewer
{
    /// <summary>
    /// 工单安排给他人业务窗体.
    /// </summary>
    public partial class FrmWorkOrderFinish : CommonViewer.BaseForm.FormBase
    {
        /// <summary>
        /// 存放列与列标题的集合.
        /// </summary>
        private Dictionary<string, string> dictColumns = new Dictionary<string, string>();

        /// <summary>
        /// 要完工的工单Id集合.
        /// </summary>
        private List<string> lstWorkOrderIds = null;

        /// <summary>
        /// 新生成的工单Id组成的List集合.
        /// </summary>
        private List<string> lstNewWorkOrderIds = new List<string>();

        public List<string> LstNewWorkOrderIds
        {
            get { return lstNewWorkOrderIds; }
            set { lstNewWorkOrderIds = value; }
        }

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="lstWorkOrderIds">要完工的工单Id集合</param>
        public FrmWorkOrderFinish(List<string> lstWorkOrderIds)
        {
            InitializeComponent();
            this.lstWorkOrderIds = lstWorkOrderIds;
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWorkOrderFinish_Load(object sender, EventArgs e)
        {           
            this.loadData_WorkOrderInstead("", ""); //加载可替代的工单信息的数据结构（必须在loadData_SelWorkOrder函数之前执行）.
            this.loadData_SelWorkOrder(true);   //加载要完成的工单信息（true表示包括结构）.

            //加载网格控件默认的列宽信息.
            dgvWorkOrder.LoadGridView("FrmWorkOrderFinish.dgvWorkOrder");
            dgvInsteadWkInfo.LoadGridView("FrmWorkOrderFinish.dgvInsteadWkInfo");

            //启动后把设置网格dgvWorkOrder的第1行为当前行（方式是把第1个可见的单元格设置为当前单元格）.
            if (dgvWorkOrder.FirstDisplayedCell != null) dgvWorkOrder.CurrentCell = dgvWorkOrder.FirstDisplayedCell;
        }

        /// <summary>
        /// 加载工单信息.
        /// </summary>
        /// <param name="loadSchema">
        /// 是否同时加载网格的结构信息（是表示同时加载结构与数据，否表示仅加载数据），.
        /// 网格的结构信息一般在第1次启动时仅需要加载一次，其它情况下不需要反复加载.
        /// </param>
        private void loadData_SelWorkOrder(bool loadSchema)
        {
            //取得要完工的工单信息的DataTable对象.
            DataTable dtbWorkOrder = WorkOrderService.Instance.GetWorkOrder(lstWorkOrderIds);
            bdsWorkOrder.DataSource = dtbWorkOrder;
            dgvWorkOrder.DataSource = bdsWorkOrder;

            if (loadSchema)
            {
                //设置列标题.
                dictColumns.Clear();
                dictColumns.Add("workordername", "工单名称");
                dictColumns.Add("circleortimingname", "定期/定时");
                dictColumns.Add("planexedate", "预计执行日期");
                dictColumns.Add("nextvalue", "预计执行表值");
                dictColumns.Add("total_workhours", "抄表值");
                dictColumns.Add("measurereport", "工作报告");
                dictColumns.Add("workcompletedinfo", "完工情况说明");
                dictColumns.Add("WORKDESCRIPTION", "工单补充说明");
                dgvWorkOrder.SetDgvGridColumns(dictColumns);
                dgvWorkOrder.SetDataGridViewNoSort();

                dgvWorkOrder.Columns["nextvalue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvWorkOrder.Columns["total_workhours"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvWorkOrder.Columns["measurereport"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvWorkOrder.Columns["measurereport"].Width = 60;
                dgvWorkOrder.Columns["measurereport"].Resizable = DataGridViewTriState.False;

                //将除工单完工情况以外的其它列设置为只读.
                dgvWorkOrder.ReadOnly = false;
                foreach (DataGridViewColumn dgvColumn in dgvWorkOrder.Columns)
                {
                    if (dgvColumn.Name != "workcompletedinfo" && dgvColumn.Name != "WORKDESCRIPTION")
                    {
                        dgvColumn.ReadOnly = true;
                        dgvColumn.DefaultCellStyle.BackColor = Color.Linen;
                    }
                }

                //给网格dgvWorkOrder动态添加一个按钮列.
                if (dgvWorkOrder.Columns["btnSelect"] == null)
                {
                    DataGridViewButtonColumn dgvBtnCol = new DataGridViewButtonColumn();
                    dgvBtnCol.Tag = 0;
                    dgvBtnCol.Name = "btnSelect";
                    dgvBtnCol.HeaderText = "";
                    dgvBtnCol.UseColumnTextForButtonValue = true;
                    dgvBtnCol.Text = "…";
                    dgvBtnCol.Width = 25;
                    dgvBtnCol.ReadOnly = true;
                    dgvBtnCol.Resizable = DataGridViewTriState.False;
                    dgvBtnCol.DisplayIndex = 8;
                    dgvWorkOrder.Columns.Add(dgvBtnCol);
                    dgvWorkOrder.Columns["btnSelect"].DataPropertyName = "btnSel";
                }
            }
        }

        /// <summary>
        /// 加载指定工单的所有可替代的工单信息.
        /// </summary>
        /// <param name="workOrderId">当前工单Id</param>
        /// <param name="workInfoId">当前工单所对应的工作信息Id</param>
        private void loadData_WorkOrderInstead(string workOrderId, string workInfoId)
        {
            //取得工单信息的DataTable对象.
            DataTable dtbWorkOrderInstead = WorkOrderService.Instance.GetWorkOrderInstead(workOrderId, workInfoId);
            bdsWorkOrderInstead.DataSource = dtbWorkOrderInstead;
            dgvInsteadWkInfo.DataSource = bdsWorkOrderInstead;

            //如果workOrderId为空，则说明是在启动时仅加载结构，不包含数据.
            if (workOrderId == "")
            {
                //设置列标题.
                dictColumns.Clear();
                dictColumns.Add("workordername", "工单名称");
                dictColumns.Add("circleortimingname", "定期/定时");
                dictColumns.Add("planexedate", "预计执行日期");
                dictColumns.Add("nextvalue", "预计执行表值");
                dictColumns.Add("total_workhours", "抄表值");
                dictColumns.Add("measurereport", "工作报告");
                dictColumns.Add("workcompletedinfo", "完工情况说明");
                dictColumns.Add("WORKDESCRIPTION", "工单补充说明");
                dgvInsteadWkInfo.SetDgvGridColumns(dictColumns);
                dgvInsteadWkInfo.SetDataGridViewNoSort();

                dgvInsteadWkInfo.Columns["nextvalue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvInsteadWkInfo.Columns["total_workhours"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvInsteadWkInfo.Columns["measurereport"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvInsteadWkInfo.Columns["measurereport"].Width = 60;
                dgvInsteadWkInfo.Columns["measurereport"].Resizable = DataGridViewTriState.False;

                //给网格dgvInsteadWkInfo动态添加一个复选框列.
                if (dgvInsteadWkInfo.Columns["chkSelect"] == null)
                {
                    DataGridViewCheckBoxColumn dgvChkCol = new DataGridViewCheckBoxColumn();
                    dgvChkCol.Tag = 0;
                    dgvChkCol.Name = "chkSelect";
                    dgvChkCol.HeaderText = "";
                    dgvChkCol.Width = 25;
                    dgvChkCol.Resizable = DataGridViewTriState.False;
                    dgvChkCol.DisplayIndex = 0;
                    dgvChkCol.ReadOnly = false;
                    dgvInsteadWkInfo.Columns.Add(dgvChkCol);
                    dgvInsteadWkInfo.Columns["chkSelect"].DataPropertyName = "chkSel";
                }

                //将除选择列和工单完工情况以外的其它列设置为只读.
                dgvInsteadWkInfo.ReadOnly = false;
                foreach (DataGridViewColumn dgvColumn in dgvInsteadWkInfo.Columns)
                {
                    if (dgvColumn.Name != "chkSelect" && dgvColumn.Name != "workcompletedinfo" && dgvColumn.Name != "WORKDESCRIPTION")
                    {
                        dgvColumn.ReadOnly = true;
                        dgvColumn.DefaultCellStyle.BackColor = Color.Linen;
                    }
                }

                //给网格dgvInsteadWkInfo动态添加一个按钮列.
                if (dgvInsteadWkInfo.Columns["btnSelect"] == null)
                {
                    DataGridViewButtonColumn dgvBtnCol = new DataGridViewButtonColumn();
                    dgvBtnCol.Tag = 0;
                    dgvBtnCol.Name = "btnSelect";
                    dgvBtnCol.HeaderText = "";
                    dgvBtnCol.UseColumnTextForButtonValue = true;
                    dgvBtnCol.Text = "…";
                    dgvBtnCol.Width = 25;
                    dgvBtnCol.ReadOnly = true;
                    dgvBtnCol.Resizable = DataGridViewTriState.False;
                    dgvBtnCol.DisplayIndex = 9;
                    dgvInsteadWkInfo.Columns.Add(dgvBtnCol);
                    dgvInsteadWkInfo.Columns["btnSelect"].DataPropertyName = "btnSel";
                }
            }
        }

        /// <summary>
        /// 当工单列表信息行变化时，显示指定的工单的可替代的工单信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvWorkOrder_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string workOrderId = "";//当前工单Id
            string workInfoId = ""; //当前工单对应的工作信息Id

            workOrderId = dgvWorkOrder.Rows[e.RowIndex].Cells["workorderid"].Value.ToString();
            workInfoId = dgvWorkOrder.Rows[e.RowIndex].Cells["workinfoid"].Value.ToString();

            this.loadData_WorkOrderInstead(workOrderId, workInfoId);
        }

        /// <summary>
        /// 当网格dgvInsteadWkInfo离开焦点时，如果网格有改动，则保存为当前工单选择的要替代的工单选择项.
        /// （在dgvInsteadWkInfo网格选中的复选框），同时保存完工情况说明.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvInsteadWkInfo_MouseLeave(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.
            string workOrderId = "";    //当前工单Id

            //结束编辑.
            dgvInsteadWkInfo.EndEdit();
            bdsWorkOrderInstead.EndEdit();
            DataTable dtbInsteadWkOrder = (DataTable)bdsWorkOrderInstead.DataSource;
            WorkOrderService.Instance.SaveWorkCompletedInfo(dtbInsteadWkOrder, out err);  //保存本次完工情况说明.

            //条件IsCurrentRowDirty可判断网格dgvInsteadWkInfo是否改动过.
            if (dgvWorkOrder.CurrentRow != null && dgvInsteadWkInfo.IsCurrentRowDirty == true)
            {
                workOrderId = dgvWorkOrder.CurrentRow.Cells["workorderid"].Value.ToString();
                DataRow[] dataRow = dtbInsteadWkOrder.Select("chkSel = 1");
                
                //更新结果报告.
                if (WorkOrderService.Instance.WorkOrderInsteadSel(workOrderId, dataRow, out err))
                {
                    dtbInsteadWkOrder.AcceptChanges();//提交变化.
                }
                else
                {
                    MessageBoxEx.Show(err, "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        /// <summary>
        /// 打开抄表对话框进行抄表.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvWorkOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string columnName = dgvWorkOrder.Columns[e.ColumnIndex].Name;   //当前列名.
            string workOrderId = "";                                        //当前工单Id
            string workInfoId = "";                                         //当前工单所对应的工作信息Id
            string circleortiming = "";                                     //工单类型.

            if (columnName == "btnSelect")
            {
                circleortiming = dgvWorkOrder.Rows[e.RowIndex].Cells["circleortiming"].Value.ToString();
                if (circleortiming == "1")
                {
                    MessageBoxEx.Show("当前工单是定期工单，没有抄表功能！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    workOrderId = dgvWorkOrder.Rows[e.RowIndex].Cells["workorderid"].Value.ToString();
                    workInfoId = dgvWorkOrder.Rows[e.RowIndex].Cells["workinfoid"].Value.ToString();
                    Gauge gauge = WorkOrderService.Instance.GetCompGauge(workInfoId);

                    if (gauge != null)
                    {
                        DialogResult thisDialogResult = DialogResult.Cancel;

                        if (gauge.RECORD_TYPE == 1)
                        {
                            FrmTotalGauge frm = new FrmTotalGauge();
                            frm.Gauge = gauge;
                            thisDialogResult = frm.ShowDialog();
                        }
                        else
                        {
                            FrmIncreaseGauge frm = new FrmIncreaseGauge();
                            frm.Gauge = gauge;
                            thisDialogResult = frm.ShowDialog();
                        }

                        if (thisDialogResult == DialogResult.OK)
                        {
                            this.loadData_SelWorkOrder(false);
                            this.loadData_WorkOrderInstead(workOrderId, workInfoId);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 打开抄表对话框进行抄表.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvInsteadWkInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string columnName = dgvInsteadWkInfo.Columns[e.ColumnIndex].Name; //当前列名.
            string topWorkOrderId = "";                                     //父网格dgvWorkOrder上的工单Id
            string topWorkInfoId = "";                                      //父网格dgvWorkOrder上的工作信息Id
            string workInfoId = "";                                         //当前工单所对应的工作信息Id
            string circleortiming = "";                                     //工单类型.

            if (columnName == "btnSelect")
            {
                circleortiming = dgvInsteadWkInfo.Rows[e.RowIndex].Cells["circleortiming"].Value.ToString();
                if (circleortiming == "1")
                {
                    MessageBoxEx.Show("当前工单是定期工单，没有抄表功能！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //取父网格dgvWorkOrder上的工单Id与工作信息Id，用于在FrmTotalGauge窗口关闭后重新刷新数据.
                    if (dgvWorkOrder.CurrentRow != null)
                    {
                        topWorkOrderId = dgvWorkOrder.CurrentRow.Cells["workorderid"].Value.ToString();
                        topWorkInfoId = dgvWorkOrder.CurrentRow.Cells["workinfoid"].Value.ToString();
                    }

                    workInfoId = dgvInsteadWkInfo.Rows[e.RowIndex].Cells["workinfoid"].Value.ToString();
                    Gauge gauge = WorkOrderService.Instance.GetCompGauge(workInfoId);

                    if (gauge != null)
                    {
                        DialogResult thisDialogResult = DialogResult.Cancel;

                        if (gauge.RECORD_TYPE == 1)
                        {
                            FrmTotalGauge frm = new FrmTotalGauge();
                            frm.Gauge = gauge;
                            thisDialogResult = frm.ShowDialog();
                        }
                        else
                        {
                            FrmIncreaseGauge frm = new FrmIncreaseGauge();
                            frm.Gauge = gauge;
                            thisDialogResult = frm.ShowDialog();
                        }

                        if (thisDialogResult == DialogResult.OK)
                        {
                            this.loadData_SelWorkOrder(false);
                            this.loadData_WorkOrderInstead(topWorkOrderId, topWorkInfoId);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 当双击完工报告列时打开完工报告对话框.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvWorkOrder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonEx2_Click(sender, null);
        }

        /// <summary>
        /// 当双击完工报告列时打开完工报告对话框.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvInsteadWkInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string columnName = ""; //当前列名.
            string colValue = "";   //当前单元格的值.
            string chkSel = "";     //当前行是否被选择.
            string workInfoId = ""; //当前工作信息Id
            string workOrderId = "";//当前工单Id

            columnName = dgvInsteadWkInfo.Columns[e.ColumnIndex].Name;
            colValue = dgvInsteadWkInfo.Rows[e.RowIndex].Cells["measurereport"].Value.ToString();
            chkSel = dgvInsteadWkInfo.Rows[e.RowIndex].Cells["chkSel"].Value.ToString();
            workInfoId = dgvInsteadWkInfo.Rows[e.RowIndex].Cells["workinfoid"].Value.ToString();
            workOrderId = dgvInsteadWkInfo.Rows[e.RowIndex].Cells["workorderid"].Value.ToString();

            if (columnName == "measurereport" && colValue.Trim() != "")
            {
                if (chkSel != "1")
                {
                    MessageBoxEx.Show("当前工单必须被选择才能填写工作报告！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                FrmWorkOrderMeasureReport frm = new FrmWorkOrderMeasureReport(workInfoId, workOrderId);
                frm.ShowDialog();
            }
        }

        /// <summary>
        /// 执行完工操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            string err = "";                     //错误信息参数.
            Dictionary<string, string> dictWkInstead = null;//包含被替代与替代工单Id的Dictionary集合.
            List<string> lstWorkOrderIds = null;            //所有要完工的工单Id集合.
            string completeDate = "";                       //完工日期.
            string sAllNoWatchComp = "";                    //指定工单集合lstWorkOrderIds中所有定时工单的所有未抄表的设备名称.

            dgvWorkOrder.EndEdit();
            bdsWorkOrder.EndEdit();

            //先保存dgvWorkOrder网格上的完工情况说明.
            DataTable dtbWorkOrder = (DataTable)bdsWorkOrder.DataSource;
            WorkOrderService.Instance.SaveWorkCompletedInfo(dtbWorkOrder, out err);  //保存完工情况说明.

            if (MessageBoxEx.Show("确定要执行完工操作吗？", "确认框", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }
            
            //取得所有要完工的工单Id集合（包含要完工的工单及要替代的工单）.
            lstWorkOrderIds = WorkOrderService.Instance.GetCompleteWorkOrderIds(dtbWorkOrder, out dictWkInstead);

            //判断lstWorkOrderIds内所有的定时工单在要完工的日期内是否抄过表（有该天的记录为依据），如果未抄过表则必须抄表.
            completeDate = dtpCompleteDate.Value.ToString("yyyy-MM-dd"); //完工日期.
            if (dtpCompleteDate.Value.Date > DateTime.Today)
            {
                MessageBoxEx.Show("完工日期不能超过今天","提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpCompleteDate.Focus();
                return;
            }
            sAllNoWatchComp = WorkOrderService.Instance.GetAllNoWatchComp(lstWorkOrderIds, completeDate);
            if (sAllNoWatchComp.Length > 0)
            {
                MessageBoxEx.Show("以下设备在要完工的日期" + completeDate + "内没有抄表记录：\r\r" + sAllNoWatchComp,
                                                                "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FrmGauge frmGauge = new FrmGauge();
                frmGauge.ShowDialog();
                frmGauge.StartPosition = FormStartPosition.CenterParent;
                return;
            }

            if (!WorkOrderService.Instance.AllWorkOrdersHaveMeasureReport(lstWorkOrderIds))
            {
                MessageBoxEx.Show("存在需要填写的测量报告,请先填写测量报告再进行完工处理");
                return;
            }

            List<string > tempLstNewWorkOrderIds;
            //执行完工操作.
             if (WorkOrderService.Instance.WorkOrderComplete(lstWorkOrderIds, dictWkInstead, dtpCompleteDate.Value,
                                      txtWorkCompletedInfo.Text, out tempLstNewWorkOrderIds, out err))
            {                
                LstNewWorkOrderIds = tempLstNewWorkOrderIds;
                if (LstNewWorkOrderIds.Count > 0 && MessageBoxEx.Show("操作成功，要修改新生成的工单信息吗？", "确认框", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.DialogResult = DialogResult.No;
                }
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                MessageBoxEx.Show(err, "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            this.Close();
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
        private void FrmWorkOrderFinish_FormClosing(object sender, FormClosingEventArgs e)
        {
            //保存网格相关信息.
            dgvWorkOrder.SaveGridView("FrmWorkOrderFinish.dgvWorkOrder");
            dgvInsteadWkInfo.SaveGridView("FrmWorkOrderFinish.dgvInsteadWkInfo");
        }

        private void buttonEx3_Click(object sender, EventArgs e)
        {
            //备件消耗//仅当只有一个工单的时候好用,提醒是为选择的工单进行设置; 
            string workOrderId = "";    //工单Id
            string workInfoId = "";     //工作信息Id
            string workOrderName = "";  //工单名称.
            try
            {
                if (bdsWorkOrder.Current != null && dgvWorkOrder.CurrentRow != null)
                {
                    workOrderId = dgvWorkOrder.CurrentRow.Cells["workorderid"].Value.ToString();
                    workInfoId = dgvWorkOrder.CurrentRow.Cells["workinfoid"].Value.ToString();
                    workOrderName = dgvWorkOrder.CurrentRow.Cells["workordername"].Value.ToString();

                    FrmWorkOrderSpConsume frm = new FrmWorkOrderSpConsume(1, workOrderId, workInfoId, workOrderName);
                    frm.ShowDialog();
                }
            }
            catch
            {
                MessageBoxEx.Show("必须选择具体的工单,才能进行完工报告的填写");
            }
        }

        private void buttonEx2_Click(object sender, EventArgs e)
        {
            //完工报告.
            string workInfoId = ""; //当前工作信息Id
            string workOrderId = "";//当前工单Id 
            try
            {  
                workInfoId = dgvWorkOrder.CurrentRow.Cells["workinfoid"].Value.ToString();
                workOrderId = dgvWorkOrder.CurrentRow.Cells["workorderid"].Value.ToString();
                string a = dgvWorkOrder.CurrentRow.Cells["measurereport"].Value.ToString();
                if (a.Length > 0)
                {
                    FrmWorkOrderMeasureReport frm = new FrmWorkOrderMeasureReport(workInfoId, workOrderId);
                    frm.ShowDialog();
                }
                
            }
            catch
            {
                MessageBoxEx.Show("必须选择具体的工单,才能进行完工报告的填写");
            }
        }
    }
}