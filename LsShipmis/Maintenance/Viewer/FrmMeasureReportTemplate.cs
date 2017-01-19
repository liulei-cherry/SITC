using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms; 
using FileOperationBase.Services;
using CommonViewer.BaseControlService;
using Maintenance.DataObject;
using Maintenance.Services;
using CommonViewer;
using CommonViewer.BaseControl;

namespace Maintenance.Viewer
{
    public partial class FrmMeasureReportTemplate : CommonViewer.BaseForm.FormBase
    {
        public FrmMeasureReportTemplate()
        {
            InitializeComponent();
        }

        private Maintenance.DataObject.WorkInfo workInfo;
        public FrmMeasureReportTemplate(Maintenance.DataObject.WorkInfo workinfo)
        {
            InitializeComponent();
            if (workinfo == null || workinfo.WORKINFOID == null) return;
            workInfo = workinfo;

            loadLeftData();
            loadBindedData();
            setGridView(datBinded);
            setGridView(datLeft);
        }

        //加载绑定的工作.
        private void loadBindedData()
        {

            DataTable dt = WorkInfoService.Instance.getMeasureReport(true,workInfo); 
            addBoolColoum(dt);
            datBinded.DataSource = dt;
            datBinded.LoadGridView("FrmMeasureReportTemplate.datBinded");
            
        }

        //加载剩余的工作.
        private void loadLeftData()
        {
            DataTable dt = WorkInfoService.Instance.getMeasureReport(false,workInfo);
            addBoolColoum(dt);
            datLeft.DataSource = dt;
            datLeft.LoadGridView("FrmMeasureReportTemplate.datLeft");
        }

        //增加第一列为布尔列.
        private void addBoolColoum(DataTable dt)
        {
            DataColumn col = new DataColumn("choose", Type.GetType("System.Boolean"));
            dt.Columns.Add(col);
            col.SetOrdinal(0);
        } 

        //设定gridview 的列信息.
        private void setGridView(UcDataGridView dgv)
        {
          
            Dictionary <string,string> dgvGridColumns = new Dictionary<string,string> ();
            dgvGridColumns.Add ( "choose", "选择");
            dgvGridColumns.Add ( "MEASURE_REPORT_TYPE_NAME", "报告名");
            dgvGridColumns.Add ("REMARK", "备注");
           
            dgv.SetDgvGridColumns(dgvGridColumns);

            dgv.Columns["MEASURE_REPORT_TYPE_NAME"].DefaultCellStyle.Font = new Font(dgv.Font.FontFamily, dgv.Font.Size, FontStyle.Underline);
            dgv.Columns["MEASURE_REPORT_TYPE_NAME"].DefaultCellStyle.ForeColor = Color.Blue;
  
        }

        private void setColumns(DataGridView dgv, string columnName, string caption)
        {
            dgv.Columns[columnName].Visible = true;
            dgv.Columns[columnName].HeaderText = caption;
            dgv.Columns[columnName].Tag = null;
        }

        private void datLeft_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex!=-1)
            {
                if (DBNull.Value == datLeft.Rows[e.RowIndex].Cells[0].Value) datLeft.Rows[e.RowIndex].Cells[0].Value = false;
                datLeft.Rows[e.RowIndex].Cells[0].Value = !(bool)(datLeft.Rows[e.RowIndex].Cells[0].Value);
            }
        }

        private void datBinded_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                if (DBNull.Value == datBinded.Rows[e.RowIndex].Cells[0].Value) datBinded.Rows[e.RowIndex].Cells[0].Value = false;
                datBinded.Rows[e.RowIndex].Cells[0].Value = !(bool)(datBinded.Rows[e.RowIndex].Cells[0].Value);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            datLeft.EndEdit();
            datBinded.EndEdit();
            DataTable sourceTable = (DataTable)datLeft.DataSource;
            DataTable targetTable = (DataTable)datBinded.DataSource;
            DataRow[] dataRows = sourceTable.Select("choose = 1");
            if (dataRows.Length + datBinded.Rows.Count > 1)
            {
                MessageBoxEx.Show("一个工作信息只能选择一个工作报告！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            moveRow(datLeft, datBinded);
        }

        private void moveRow(DataGridView source, DataGridView target)
        {
            DataTable sourceTable=(DataTable) source.DataSource;
            DataTable targetTable=(DataTable)target.DataSource;
            int count = sourceTable.Rows.Count;
            DataRow dr;
            for (int i = count - 1; i >= 0;i-- )
            {
                dr = sourceTable.Rows[i];    
                if (dr["choose"] != DBNull.Value && (bool)dr["choose"])
                {
                    targetTable.ImportRow(dr);
                    sourceTable.Rows.Remove(dr);
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            moveRow(datBinded, datLeft);
        }

        private void FrmMeasureReportTemplate_FormClosing(object sender, FormClosingEventArgs e)
        {
            datBinded.SaveGridView("FrmMeasureReportTemplate.datBinded");
            datLeft.SaveGridView("FrmMeasureReportTemplate.datLeft");
        }

        private void datLeft_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            openFile(datLeft, e);
        }

        private void datBinded_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            openFile(datBinded, e);
        }

        private void openFile (DataGridView dv,DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex!=2) return;
            string fileId=dv.Rows[e.RowIndex].Cells["file_id"].Value.ToString();
            openFile ofile = new openFile();
            ourFile file = new ourFile();
            file.FileId = fileId;
            ofile.FileOpen(file, right.R);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string err;
            //delete data
            if (!WorkInfoService.Instance.deleteBindedMeasureReportByWorkInfo(workInfo, out err))
            {
                MessageBoxEx.Show("删除以前绑定的工作报告时失败，错误信息为：" + err, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //insert data
            foreach (DataRow dr in ((DataTable)datBinded.DataSource).Rows)
            {
                if (!WorkInfoService.Instance.insertWorkInfoMeasureReport(workInfo.WORKINFOID, dr["measure_report_type_id"].ToString(), workInfo.SHIP_ID, out err))
                {
                    MessageBoxEx.Show("工作报告绑定失败，错误信息为："+err, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
            MessageBoxEx.Show("工作报告设置成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
            
        }

        private void FrmMeasureReportTemplate_Load(object sender, EventArgs e)
        {

        }
    }
}