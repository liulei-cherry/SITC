using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms; 
using FileOperationBase.Services; 
using BaseInfo.Objects;
using BaseInfo.DataAccess;
using Maintenance.Services;
using OfficeOperation;
using CommonViewer;
using CommonViewer.BaseControl;

namespace Maintenance.Report
{
    public partial class FrmPlanMonth : CommonViewer.BaseForm.FormBase
    {
        public FrmPlanMonth()
        {
            InitializeComponent();
        }
        public FrmPlanMonth( string formTitle, string department)
        {
            InitializeComponent();   
            this.Text = formTitle;
            buttonEx5.Text = formTitle;
            dept = department;
        }
        void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            BindData();
        } 
        private static FrmPlanMonth instanceJ;
        private static FrmPlanMonth instanceL;
        public static FrmPlanMonth GetInstance( string title, string department)
        {
            if (department == "甲板部")
            {
                if (instanceJ == null)
                {
                    instanceJ = new FrmPlanMonth(title, department);
                }
                return instanceJ;
            }
            else
            {
                if (instanceL == null)
                {
                    instanceL = new FrmPlanMonth(title, department);
                }
                return instanceL;
            }
        }
        private bool loaded = false;
        string dept;
        int year = DateTime.Today.Year;
        int month = DateTime.Today.Month;
        DataTable dtsource = new DataTable();

        private void FrmPlanMonth_Load(object sender, EventArgs e)
        {
            ucShipSelect1.ChangeSelectedState(false, true);
            if (CommonOperation.ConstParameter.IsLandVersion)
            {                
                ucShipSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(ucShipSelect1_TheSelectedChanged);
            }
            dtsource = getSourTbl();
            for (int i = 0; i < 10; i++)
            {
                cbbxyear.Items.Add(year + 5 - i);
            }
            cbbxyear.SelectedItem = year;
            cbbmonth.SelectedItem = month.ToString();
            //加载网格控件默认的列宽信息.
            dgv.LoadGridView("FrmPlanMonth.dgv");
            loaded = true;
            BindData();
        }

        private void BindData()
        {
            if (loaded && !string.IsNullOrEmpty (ucShipSelect1.GetId()))
            {
                Cursor.Current = Cursors.WaitCursor;
                dtsource.Rows.Clear();
                
                DateTime startTime = new DateTime(year, month, 1);
                DateTime endTime;
                if (month < 12)
                    endTime = new DateTime(year, month + 1, 1);
                else
                    endTime = new DateTime(year, month, 31, 23, 59, 59);             
                WorkInfoPlan workinfoPlan = new WorkInfoPlan();
                DataTable dtsourcetemp = workinfoPlan.GetPlanListOfTheWork(ucShipSelect1.GetId(), startTime, endTime, (dept == "甲板部"));
                if (dtsourcetemp != null && dtsourcetemp.Rows.Count >0)
                {
                    for (int i = 0; i < dtsourcetemp.Rows.Count; i++)
                    {
                        DataRow dr = dtsource.NewRow();
                        dr[0] = (i + 1).ToString();
                        dr[1] = dtsourcetemp.Rows[i][0].ToString();
                        dr[2] = dtsourcetemp.Rows[i][2].ToString();
                        dtsource.Rows.Add(dr);
                    }
                    if (dtsource.Rows.Count > 0)
                    {
                        dgv.DataSource = dtsource;
                        dgv.LoadGridView("FrmPlanMonth.dgv");
                    }
                    else
                    {
                        dgv.DataSource = null;
                    }
                }
                else
                {
                  //  MessageBoxEx.Show("未获取到任何月度计划数据!");
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void FrmPlanMonth_FormClosing(object sender, FormClosingEventArgs e)
        { 
            instanceJ = null;
            instanceL = null;
            //保存网格控件各列的列宽信息.
            dgv.SaveGridView("FrmPlanMonth.dgv");
        }

        private void cbbxyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                year = Int32.Parse(this.cbbxyear.SelectedItem.ToString());
            }
            catch
            {
                return;
            }
            if (month > 0)
                BindData();
        }

        private void cbbmonth_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                month = Int32.Parse(this.cbbmonth.SelectedItem.ToString());
            }
            catch
            {
                return;
            }
            BindData();
        }

        private void tsbtnExcel_Click(object sender, EventArgs e)
        {
            easyReport();
        }
        private void easyReport()
        {
            if (dgv.Rows.Count  == 0) return;
            OperationExcel operationExcel = new OperationExcel();
            try
            {
                string err;
                if (!operationExcel.AddTitle(ucShipSelect1.GetText() + dept + "(" + year.ToString() + "年" + month.ToString() + "月)月度保养计划", 1, out err)
                  
                    || !operationExcel.InsertABodyUnit(new OneUnit("序 号", false,2, 2, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit("工作内容", false,2, 3, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                    || !operationExcel.InsertABodyUnit(new OneUnit("次 数", false, 2, 4, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err))
                {
                    MessageBoxEx.Show(err);
                    return;
                }
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (!operationExcel.InsertABodyUnit(new OneUnit(dgv.Rows[i].Cells [0].Value.ToString(), false, 3 + i, 2, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dgv.Rows[i].Cells[1].Value.ToString(), false, 3 + i, 3, 1, 1, true, false, XlHorizontalAlignment.xlLeft), out err)
                        || !operationExcel.InsertABodyUnit(new OneUnit(dgv.Rows[i].Cells[2].Value.ToString(), false, 3 + i, 4, 1, 1, true, false, XlHorizontalAlignment.xlCenter), out err))
                    {
                        MessageBoxEx.Show(err);
                        return;
                    }
                }

                operationExcel.AddAllColumnSize(1, 20);
                operationExcel.AddAllColumnSize(2, 100);
                operationExcel.AddAllColumnSize(3, 500);
                operationExcel.AddAllColumnSize(4, 100); 
                operationExcel.AddAllLineSize(1, 60); 
                FrmOurReport frmOurReport = new FrmOurReport(dept + "部月度保养计划", operationExcel);
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
        private void tsbtnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        //构造一个表结构.
        private DataTable getSourTbl()
        {
            DataTable sourTbl = new DataTable();
            DataColumn col = new DataColumn("序 号", typeof(Int32));
            DataColumn col1 = new DataColumn("工作内容", typeof(String));
            DataColumn col2 = new DataColumn("次 数", typeof(Int32));
            sourTbl.Columns.Add(col);
            sourTbl.Columns.Add(col1);
            sourTbl.Columns.Add(col2);
            return sourTbl;
        }
    }
}