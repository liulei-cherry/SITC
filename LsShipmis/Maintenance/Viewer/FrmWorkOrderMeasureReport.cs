/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmWorkOrderMeasureReport.cs
 * 创 建 人：李景育
 * 创建时间：2009-06-20
 * 标    题：工单完工时填写工作报告窗体
 * 功能描述：实现工单完工时填写工作报告的功能
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
using FileOperationBase.Services;
using Maintenance.Services;
using CommonOperation.Enum;
using FileOperationBase.FileServices;
using CommonViewer.BaseControl; 

namespace Maintenance.Viewer
{
    /// <summary>
    /// 工单完工时填写工作报告窗体.
    /// </summary>
    public partial class FrmWorkOrderMeasureReport : CommonViewer.BaseForm.FormBase
    {  

        /// <summary>
        /// 存放列与列标题的集合.
        /// </summary>
        private Dictionary<string, string> dictColumns = new Dictionary<string, string>();

        /// <summary>
        /// 工作信息Id
        /// </summary>
        private string workInfoId = "";

        /// <summary>
        /// 工单Id
        /// </summary>
        private string workOrderId = "";

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="workOrderId">工单Id</param>
        /// <param name="workInfoId">工作信息Id</param>
        public FrmWorkOrderMeasureReport(string workInfoId, string workOrderId)
        {
            InitializeComponent();
            this.workInfoId = workInfoId;
            this.workOrderId = workOrderId;
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWorkOrderMeasureReport_Load(object sender, EventArgs e)
        {
            this.loadData_WorkInfoMea(true);    //加载工作信息的工作报告（true表示包括结构）.
            this.loadData_WorkOrderMea(true);   //加载工单的工作报告（true表示包括结构）.
        }

        /// <summary>
        /// 加载工作信息的工作报告模板信息.
        /// </summary>
        /// <param name="loadSchema">
        /// 是否同时加载网格的结构信息（是表示同时加载结构与数据，否表示仅加载数据），.
        /// 网格的结构信息一般在第1次启动时仅需要加载一次，其它情况下不需要反复加载.
        /// </param>
        private void loadData_WorkInfoMea(bool loadSchema)
        {
            //取得工作信息的工作报告的DataTable对象.
            DataTable dtbWorkInfoMea = WorkInfoService.Instance.GetWorkInfoMeasureReport(workInfoId);
            bdsWorkInfoMea.DataSource = dtbWorkInfoMea;
            dgvWorkInfoMeasure.DataSource = bdsWorkInfoMea;

            if (loadSchema)
            {
                //设置列标题.
                dictColumns.Clear();
                dictColumns.Add("measure_report_type_name", "工作报告");
                dictColumns.Add("workinfoname", "工作信息名称");
                dictColumns.Add("workinfodetail", "工作信息内容");
                dgvWorkInfoMeasure.SetDgvGridColumns(dictColumns);
                dgvWorkInfoMeasure.SetDataGridViewNoSort();

                dgvWorkInfoMeasure.Columns["measure_report_type_name"].Width = 100;
                dgvWorkInfoMeasure.Columns["workinfoname"].Width = 120;
                dgvWorkInfoMeasure.Columns["workinfodetail"].Width = 300;
                dgvWorkInfoMeasure.Columns["measure_report_type_name"].DefaultCellStyle.Font = new Font("宋体", 9, FontStyle.Underline);
                dgvWorkInfoMeasure.Columns["measure_report_type_name"].DefaultCellStyle.ForeColor = Color.Blue;
            }
        }

        /// <summary>
        /// 加载工单的工作报告信息.
        /// </summary>
        /// <param name="loadSchema">
        /// 是否同时加载网格的结构信息（是表示同时加载结构与数据，否表示仅加载数据），.
        /// 网格的结构信息一般在第1次启动时仅需要加载一次，其它情况下不需要反复加载.
        /// </param>
        private void loadData_WorkOrderMea(bool loadSchema)
        {
            //取得工单的工作报告信息的DataTable对象.
            DataTable dtbWorkOrderMea = WorkOrderService.Instance.GetWorkOrderMeasureReport(workOrderId);
            bdsWorkOrderMea.DataSource = dtbWorkOrderMea;
            dgvWorkOrderMeasure.DataSource = bdsWorkOrderMea;

            if (loadSchema)
            {
                //设置列标题.
                dictColumns.Clear();
                dictColumns.Add("file_name", "工作报告");
                dictColumns.Add("creator", "创建人");
                dictColumns.Add("create_date", "创建日期");
                dgvWorkOrderMeasure.SetDgvGridColumns(dictColumns);
                dgvWorkOrderMeasure.SetDataGridViewNoSort();

                dgvWorkOrderMeasure.Columns["file_name"].Width = 300;
                dgvWorkOrderMeasure.Columns["creator"].Width = 110;
                dgvWorkOrderMeasure.Columns["create_date"].Width = 110;
                dgvWorkOrderMeasure.Columns["file_name"].DefaultCellStyle.Font = new Font("宋体", 9, FontStyle.Underline);
                dgvWorkOrderMeasure.Columns["file_name"].DefaultCellStyle.ForeColor = Color.Blue;
            }
        }

        /// <summary>
        /// 双击工作信息的工作报告模板打开模板.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvWorkInfoMeasure_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string err = ""; //错误信息参数.
            string fileId = "";         //当前工作报告模板文档对应的大文档Id（t_file_manage表主键）.
            string shipId = "";         //当前船舶Id

                fileId = dgvWorkInfoMeasure.Rows[e.RowIndex].Cells["file_id"].Value.ToString();
                shipId = CommonOperation.ConstParameter.ShipId;

                if (fileId != "")
                {
                    openFile ofile = new openFile();
                    ourFile templateFile = new ourFile();
                    templateFile.FileId = fileId;
                    ourFolder folder = FolderDbService.Instance.getFolderByFolderType(FileBoundingTypes.MEASUREREPORT);
                    ourFile newFile = ofile.FileOpenWithReturn(templateFile, right.C, folder.NodeId, shipId);

                    if (newFile == null)
                    {
                        MessageBoxEx.Show("文件不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if( WorkOrderService.Instance.SaveWorkOrderMeasureReport(workOrderId, newFile.FileId, shipId, out err)) 
                    {
                        this.loadData_WorkOrderMea(false);
                    }
                    else
                    {
                        MessageBoxEx.Show(err, "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
             
        }

        /// <summary>
        /// 双击工单的工作报告打开该报告.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvWorkOrderMeasure_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string columnName = ""; //当前列名.
            string fileId = "";     //当前工作报告模板文档对应的大文档Id（t_file_manage表主键）.

            columnName = dgvWorkOrderMeasure.Columns[e.ColumnIndex].Name;
            if (columnName == "file_name")
            {
                fileId = dgvWorkOrderMeasure.Rows[e.RowIndex].Cells["file_id"].Value.ToString();

                if (fileId != "")
                {
                    openFile ofile = new openFile();
                    ourFile file = new ourFile();
                    file.FileId = fileId;
                    ofile.FileOpen(file, right.U);
                }
            }
        }

        /// <summary>
        /// 删除工单的工作报告信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            string err = "";     //错误信息参数.
            string workOrderMeaRptId = "";  //工单工作报告信息Id

            if (bdsWorkOrderMea.Current != null)
            {
                workOrderMeaRptId = dgvWorkOrderMeasure.CurrentRow.Cells["workordermearptid"].Value.ToString();
                if(WorkOrderService.Instance.DelWorkOrderMeasureReport(workOrderMeaRptId, out err))
                {
                    this.loadData_WorkOrderMea(false);
                }
                else
                {
                    MessageBoxEx.Show(err, "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
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
    }
}