/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmWorkOrderNewEdit.cs
 * 创 建 人：李景育
 * 创建时间：2009-06-01
 * 标    题：新工单编辑业务窗体
 * 功能描述：实现新工单编辑的功能
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
using Maintenance.DataObject;
using Maintenance.Services;
using CommonViewer.BaseControlService;
using CommonViewer.BaseControl;

namespace Maintenance.Viewer
{
    /// <summary>
    /// 新工单编辑业务窗体.
    /// </summary>
    public partial class FrmWorkOrderNewEdit : CommonViewer.BaseForm.FormBase
    {
        /// <summary> 
        /// 存放列与列标题的集合.
        /// </summary>
        private Dictionary<string, string> dictColumns = new Dictionary<string, string>();

        /// <summary>
        /// 新生成的工单Id组成的List集合.
        /// </summary>
        private List<string> lstNewWorkOrderIds = new List<string>();
        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="lstNewWorkOrderIds">新生成的工单Id组成的List集合</param>
        public FrmWorkOrderNewEdit(List<string> lstNewWorkOrderIds)
        {
            InitializeComponent();
            this.lstNewWorkOrderIds = lstNewWorkOrderIds;
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWorkOrderNewEdit_Load(object sender, EventArgs e)
        {
            this.setComboBox();       //设置窗体所需的下拉列表框的数据源.
            this.loadData_WorkOrder();//加载要完成的工单信息（true表示包括结构）.
            //加载网格控件默认的列宽信息.
            dgvWorkOrder.LoadGridView("FrmWorkOrderNewEdit.dgvWorkOrder");
        }

        /// <summary>
        ///  当窗体启动后根据工作信息类型设置网格dgvWorkOrder的一些单元格的只读或者非只读属性.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWorkOrderNewEdit_Shown(object sender, EventArgs e)
        {
            this.dgvWorkOrder.ReadOnly = false; 
        }

        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        { 
            //1.用于网格的责任人岗位下拉列表.
            DataTable dtbPrincipalPostGrid = BaseInfo.DataAccess.PostService.Instance.GetLandOrShipPostList(false, false);
            FormControlOption.Instance.SetComboBoxValue(cboPrincipalPostGrid, dtbPrincipalPostGrid, 0, 3);
            DgvBindDrop dgvBindDrop1 = new DgvBindDrop();
            dgvBindDrop1.bindDropToDgv(dgvWorkOrder, cboPrincipalPostGrid, 6, false, 1);

            //2.用于网格的确认者岗位下拉列表.

            DataTable dtbConfirmPostGrid = BaseInfo.DataAccess.PostService.Instance.GetLandOrShipPostList(false, true);
            FormControlOption.Instance.SetComboBoxValue(cboConfirmPostGrid, dtbConfirmPostGrid, 0, 3);
            DgvBindDrop dgvBindDrop2 = new DgvBindDrop();
            dgvBindDrop2.bindDropToDgv(dgvWorkOrder, cboConfirmPostGrid, 8, false, 1);

            //8.在网格dgvWorkOrder绑定计划执行时间.
            DgvBindDrop dgvBindDrop3 = new DgvBindDrop();
            dgvBindDrop3.bindDropToDgv(dgvWorkOrder, dtpPlanExeDate, 9); 
        }

        /// <summary>
        /// 加载新生成的工单信息.
        /// </summary>
        private void loadData_WorkOrder()
        {
            //取得工单信息的DataTable对象.
            DataTable dtbWorkOrder = WorkOrderService.Instance.GetWorkOrder(lstNewWorkOrderIds);            
            bdsWorkOrder.DataSource = dtbWorkOrder;
            dgvWorkOrder.DataSource = bdsWorkOrder;

            //设置列标题.
            dictColumns.Clear();
            dictColumns.Add("workordername", "工单名称");
            dictColumns.Add("circleortimingname", "定期/定时");
            dictColumns.Add("principalpostname", "责任人岗位");
            dictColumns.Add("confirmpostname", "确认人岗位");
            dictColumns.Add("planexedate", "预计执行日期");
            dictColumns.Add("nextvalue", "预计执行表值");
            dictColumns.Add("last_couter_time", "设备最后一次抄表时间");
            dictColumns.Add("total_workhours", "设备最后一次抄表值");
            dgvWorkOrder.SetDgvGridColumns(dictColumns);
            dgvWorkOrder.SetDataGridViewNoSort();

            dgvWorkOrder.Columns["nextvalue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.setDgvReadOnly();
            
        }
        WorkOrder workOrder = null;
        /// <summary>
        /// 当网格行变化时显示当前行的信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvWorkOrder_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string err;
            DataRowView drvCurRow = (DataRowView)bdsWorkOrder.List[e.RowIndex];
            workOrder = WorkOrderService.Instance.getObject(drvCurRow["workorderid"].ToString(), out err);
            workOrder.FillThisObject();
            this.setForms(workOrder);
        }

        /// <summary>
        /// 根据网格dgvWorkOrder中的当前行的相关信息，给窗体上的定期定时信息区域赋值.
        /// </summary>
        /// <param name="workOrder">WorkOrder业务实体类</param>
        private void setForms(WorkOrder workOrder)
        {
            this.txtCirclePeriod.Text = workOrder.TheWorkInfo.CIRCLEPERIOD.ToString ();
            this.txtCircleUnit.Text = workOrder.TheWorkInfo.CIRCLEUNIT;
            this.txtTimingPeriod.Text = workOrder.TheWorkInfo.TIMINGPERIOD.ToString();
        }

        /// <summary>
        /// 网格校验部分.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvWorkOrder_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string colName = "";        //当前单元格所在的列名.
            string curValue = "";       //当前单元格的值.

            decimal decValidata = 0;   //数值型数值校验.
            if (workOrder == null)
            {
                MessageBoxEx.Show("未知错误发生,无法定位行");
                return;
            }

            colName = dgvWorkOrder.Columns[e.ColumnIndex].Name;
            curValue = e.FormattedValue.ToString().Trim();

            //1.前允差日期不能大于预计执行日期.
            if (colName == "circlefrontlimitdate")
            {
                //取预计执行日期.
                string sPlanexedate = dgvWorkOrder.Rows[e.RowIndex].Cells["planexedate"].Value.ToString();

                //与前允差日期做比较.
                if (sPlanexedate != "" && curValue != "")
                {
                    DateTime dtCirclefrontlimitdate = DateTime.Parse(curValue);
                    DateTime dtPlanexedate = DateTime.Parse(sPlanexedate);
                    if (dtCirclefrontlimitdate > dtPlanexedate)
                    {
                        MessageBoxEx.Show("前允差日期不能大于预计执行日期！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                        return;
                    }
                }
            }

            //2.后允差日期不能小于预计执行日期.
            if (colName == "circlebacklimitdate")
            {
                //取预计执行日期.
                string sPlanexedate = dgvWorkOrder.Rows[e.RowIndex].Cells["planexedate"].Value.ToString();

                //与前允差日期做比较.
                if (sPlanexedate != "" && curValue != "")
                {
                    DateTime dtCirclebacklimitdate = DateTime.Parse(curValue);
                    DateTime dtPlanexedate = DateTime.Parse(sPlanexedate);
                    if (dtCirclebacklimitdate < dtPlanexedate)
                    {
                        MessageBoxEx.Show("后允差日期不能小于预计执行日期！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                        return;
                    }
                }
            }

            //3.预计执行表值必须是数值型数据.
            if (colName == "nextvalue")
            {
                if (curValue != "" && e.RowIndex >= 0 && dgvWorkOrder.Rows[e.RowIndex].Cells["circleortimingname"].Value.ToString().Contains("定时") )
                {
                    if(!resetNextValue(curValue,e.RowIndex))
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }

            //4.前允差小时数必须是数值型数据且不能大于预计执行表值.
            if (colName == "timingfrontlimithours")
            {
                if (curValue != "")
                {
                    if (decimal.TryParse(curValue, out decValidata) == false)
                    {
                        MessageBoxEx.Show("前允差小时数必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                        return;
                    }
                }

                //取预计执行表值.
                string sNextvalue = dgvWorkOrder.Rows[e.RowIndex].Cells["nextvalue"].Value.ToString();
                if (sNextvalue != "" && curValue != "")
                {
                    decimal nextValue = decimal.Parse(sNextvalue);
                    decimal timingFrontLimitHours = decimal.Parse(curValue);
                    if (timingFrontLimitHours > nextValue)
                    {
                        MessageBoxEx.Show("前允差小时数不能大于预计执行表值！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                        return;
                    }
                }
            }

            //5.后允差小时数必须是数值型数据且不能小于预计执行表值.
            if (colName == "timingbacklimithours")
            {
                if (curValue != "")
                {
                    if (decimal.TryParse(curValue, out decValidata) == false)
                    {
                        MessageBoxEx.Show("后允差小时数必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                        return;
                    }
                }

                //取预计执行表值.
                string sNextvalue = dgvWorkOrder.Rows[e.RowIndex].Cells["nextvalue"].Value.ToString();
                if (sNextvalue != "" && curValue != "")
                {
                    decimal nextValue = decimal.Parse(sNextvalue);
                    decimal timingBackLimitHours = decimal.Parse(curValue);
                    if (timingBackLimitHours < nextValue)
                    {
                        MessageBoxEx.Show("后允差小时数不能小于预计执行表值！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }

        private bool resetNextValue(string curValue,int index)
        {
            decimal decValidata = 0;
            decimal aimHours = decimal.Parse(curValue);
            string sTotalWorkhours = dgvWorkOrder.Rows[index].Cells["total_workhours"].Value.ToString();
            decimal totalWorkhours = 0;
            DateTime dt;
            if (sTotalWorkhours != "") totalWorkhours = decimal.Parse(sTotalWorkhours);
            workOrder.TheWorkInfo.FillThisObject();
            decimal rate = 1;
            if (workOrder.TheWorkInfo.CompUnit != null && !workOrder.TheWorkInfo.CompUnit.IsWrong)
            {
                rate = workOrder.TheWorkInfo.CompUnit.USE_RATE;
                if (rate == 0) rate = 1;
                string dts = dgvWorkOrder.Rows[index].Cells["last_couter_time"].Value.ToString();
                if (dts != "")
                {
                    dt = DateTime.Parse(dts);
                }
                else
                {
                    MessageBoxEx.Show("由于没有发现抄表记录,当前操作无效！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else
            {
                MessageBoxEx.Show("由于当前工作信息没有绑定设备,无法获取抄表记录,操作无效！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (decimal.TryParse(curValue, out decValidata) == false)
            {
                MessageBoxEx.Show("首次执行表值必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                if (totalWorkhours > 0 && decimal.Parse(curValue) <= totalWorkhours)
                {
                    MessageBoxEx.Show("首次执行表值必须大于设备上次抄表值！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            dgvWorkOrder.Rows[index].Cells["planexedate"].Value = dt.AddHours((int)((aimHours - totalWorkhours) / rate));
            dgvWorkOrder.Rows[index].Cells["timingfrontlimithours"].Value = aimHours - workOrder.TheWorkInfo.TIMINGFRONTLIMIT;
            dgvWorkOrder.Rows[index].Cells["timingbacklimithours"].Value = aimHours - workOrder.TheWorkInfo.TIMINGBACKLIMIT;
            return true;
        }

        /// <summary>
        /// 保存编辑后的信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            string err = "";     //错误信息参数.

            dgvWorkOrder.EndEdit();

            //取要保存的新工单的行信息.
            BindingSource bds = (BindingSource)dgvWorkOrder.DataSource;
            DataTable dtb = (DataTable)bds.DataSource;

            //数据校验.
            if (this.IsValidate(dtb) == false)
            {
                return;
            }

            //保存修改过的信息.
            if (WorkOrderService.Instance.SaveNewWorkOrder(dtb, out err))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBoxEx.Show(err, "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// 保存时的数据校验.
        /// </summary>
        /// <param name="dtb">包含数据行信息的DataTable对象</param>
        /// <returns>如果通过校验返回true，否则返回false</returns>
        private bool IsValidate(DataTable dtb)
        {
            string workordername = "";  //工单名称.
            string principalpost = "";  //责任人岗位Id
            string confirmpost = "";    //确认者岗位Id
            string circleOrTiming = ""; //定期/定时（1表示定期，2表示定时，3表示定期与定时）.
            string planexedate = "";    //首次执行日期.
            string nextvalue = "";      //首次执行表值.

            foreach (DataRow curRow in dtb.Rows)
            {
                workordername = curRow["workordername"].ToString();
                principalpost = curRow["principalpost"].ToString();
                confirmpost = curRow["confirmpost"].ToString();
                circleOrTiming = curRow["circleortiming"].ToString();
                planexedate = curRow["planexedate"].ToString();
                nextvalue = curRow["nextvalue"].ToString();

                if (workordername == "")
                {
                    MessageBoxEx.Show("工单名称是必填项！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (principalpost == "")
                {
                    MessageBoxEx.Show("责任人岗位是必选项！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (confirmpost == "")
                {
                    MessageBoxEx.Show("确认者岗位是必选项！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (circleOrTiming == "1" && planexedate == "")
                {
                    MessageBoxEx.Show("定期工单必须填预计执行日期！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (circleOrTiming == "2" && nextvalue == "")
                {
                    MessageBoxEx.Show("定时工单必须填预计执行表值！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (circleOrTiming == "3" && planexedate == "")
                {
                    MessageBoxEx.Show("定期和定时的工单必须填预计执行日期！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (circleOrTiming == "3" && nextvalue == "")
                {
                    MessageBoxEx.Show("定期和定时时必须填预计执行表值！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            return true;
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
        /// 窗体关闭时保存网格信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWorkOrderNewEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            //保存网格相关信息.
            dgvWorkOrder.SaveGridView("FrmWorkOrderNewEdit.dgvWorkOrder");
        }

        /// <summary>
        /// 根据工作信息类型设置网格dgvWorkOrder的一些单元格的只读或者非只读属性.
        /// </summary>
        private void setDgvReadOnly()
        {
            foreach (DataGridViewRow dgvRow in dgvWorkOrder.Rows)
            {
                string circleOrTiming = dgvRow.Cells["circleortiming"].Value.ToString();

                dgvRow.Cells["circleortimingname"].ReadOnly = true;
                dgvRow.Cells["circleortimingname"].Style.BackColor = Color.Linen;

                if (circleOrTiming == "1")
                {                   
                    //dgvRow.Cells["circlefrontlimitdate"].ReadOnly = false;
                    //dgvRow.Cells["circlebacklimitdate"].ReadOnly = false;
                    dgvRow.Cells["nextvalue"].ReadOnly = true;
                    dgvRow.Cells["last_couter_time"].ReadOnly = true;
                    //dgvRow.Cells["timingfrontlimithours"].ReadOnly = true;
                    //dgvRow.Cells["timingbacklimithours"].ReadOnly = true;
                    //dgvRow.Cells["circlefrontlimitdate"].Style.BackColor = Color.White;
                    //dgvRow.Cells["circlebacklimitdate"].Style.BackColor = Color.White;
                    dgvRow.Cells["nextvalue"].Style.BackColor = Color.Linen;
                    dgvRow.Cells["last_couter_time"].Style.BackColor = Color.Linen;
                    //dgvRow.Cells["timingfrontlimithours"].Style.BackColor = Color.Linen;
                    //dgvRow.Cells["timingbacklimithours"].Style.BackColor = Color.Linen;                    
                }
                else if (circleOrTiming == "2")
                {
                    dgvRow.Cells["planexedate"].ReadOnly = true;
                    dgvRow.Cells["planexedate"].Style.BackColor = Color.Linen;
                    //dgvRow.Cells["circlefrontlimitdate"].ReadOnly = true;
                    //dgvRow.Cells["circlebacklimitdate"].ReadOnly = true;
                    dgvRow.Cells["nextvalue"].ReadOnly = false;
                    //dgvRow.Cells["timingfrontlimithours"].ReadOnly = false;
                    //dgvRow.Cells["timingbacklimithours"].ReadOnly = false;
                    //dgvRow.Cells["circlefrontlimitdate"].Style.BackColor = Color.Linen;
                    //dgvRow.Cells["circlebacklimitdate"].Style.BackColor = Color.Linen;
                    dgvRow.Cells["nextvalue"].Style.BackColor = Color.White;
                    //dgvRow.Cells["timingfrontlimithours"].Style.BackColor = Color.White;
                    //dgvRow.Cells["timingbacklimithours"].Style.BackColor = Color.White; 
                    resetNextValue(dgvRow.Cells["nextvalue"].Value.ToString(), dgvRow.Index);
                }
                else if (circleOrTiming == "3")
                {
                    //dgvRow.Cells["circlefrontlimitdate"].ReadOnly = false;
                    //dgvRow.Cells["circlebacklimitdate"].ReadOnly = false;
                    dgvRow.Cells["nextvalue"].ReadOnly = false;
                    //dgvRow.Cells["timingfrontlimithours"].ReadOnly = false;
                    //dgvRow.Cells["timingbacklimithours"].ReadOnly = false;
                    //dgvRow.Cells["circlefrontlimitdate"].Style.BackColor = Color.White;
                    //dgvRow.Cells["circlebacklimitdate"].Style.BackColor = Color.White;
                    dgvRow.Cells["nextvalue"].Style.BackColor = Color.White;
                    //dgvRow.Cells["timingfrontlimithours"].Style.BackColor = Color.White;
                    //dgvRow.Cells["timingbacklimithours"].Style.BackColor = Color.White;
                }
            }
        } 
    }
}