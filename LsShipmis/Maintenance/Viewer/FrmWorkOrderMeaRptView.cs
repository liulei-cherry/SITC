/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmWorkOrderMeaRptView.cs
 * 创 建 人：李景育
 * 创建时间：2009-06-20
 * 标    题：工单完工时报告信息查看窗体
 * 功能描述：实现完工时报告信息查看的功能
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
namespace Maintenance.Viewer
{
    /// <summary>
    /// 工单完工时报告信息查看窗体.
    /// </summary>
    public partial class FrmWorkOrderMeaRptView : CommonViewer.BaseForm.FormBase
    {
        /// <summary>
        /// 存放列与列标题的集合.
        /// </summary>
        private Dictionary<string, string> dictColumns = new Dictionary<string, string>();

        /// <summary>
        /// 工单Id
        /// </summary>
        private string workOrderId = "";

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="workOrderId">工单Id</param>
        public FrmWorkOrderMeaRptView(string workOrderId)
        {
            InitializeComponent();
            this.workOrderId = workOrderId;
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWorkOrderMeaRptView_Load(object sender, EventArgs e)
        {
           this.loadData_WorkOrderMea(true);   //加载工单的工作报告（true表示包括结构）.
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
        /// 打开工作报告.
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
                    ofile.FileOpen(file, right.R);
                }
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}