using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SeaChartManage.Services;
using SeaChartManage.BusinessClasses;
using CommonViewer.BaseControl;
using CommonViewer.BaseControlService;
using CommonViewer.BaseForm;

namespace SeaChartManage.Forms
{
    public partial class FrmChartBaseInfoManage : CommonViewer.BaseForm.FormBase
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmChartBaseInfoManage instance = new FrmChartBaseInfoManage();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmChartBaseInfoManage Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmChartBaseInfoManage.instance = new FrmChartBaseInfoManage();
                }

                return FrmChartBaseInfoManage.instance;
            }
        }

        #endregion

        public FrmChartBaseInfoManage()
        {
            InitializeComponent();
        }

        private void FrmChartBaseInfoManage_Load(object sender, EventArgs e)
        {
            LoadChartData(); 
        }

        private void LoadChartData()
        {
            string err;
            DataTable dt = t_chartService.Instance.getInfo(out err);
            if (dt!=null)
            {
                dataGridView.DataSource = dt;
                dataGridView.LoadGridView("FrmChartBaseInfoManage");
                Dictionary<string,string> columns = new Dictionary<string,string> ();
                columns.Add ("chartnum", "图号");
                columns.Add ("chartname", "图名(中文)");
                columns.Add ("chartenglishname", "图名(英文)");
                columns.Add ("chartrule", "比例尺1：N");
                columns.Add ("paperchart", "纸质图");
                columns.Add ("changedate", "改版日期");
                columns.Add ("chartformat", "图积");
                columns.Add ( "sailtellnum", "航告期数");
                columns.Add ("publishdept", "发布部门");
                columns.Add ("remark", "备注");
                dataGridView.SetDgvGridColumns(columns); 
            }
        }
 
        private void FrmChartBaseInfoManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataGridView.SaveGridView("FrmChartBaseInfoManage"); 
            instance = null;
        }

        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            FrmChartBaseInfoAddEdit frm = new FrmChartBaseInfoAddEdit("添加海图信息", new t_chart());
            frm.afterSave += new FrmChartBaseInfoAddEdit.AfterSave(LoadChartData);
            frm.ShowDialog();
            LoadChartData();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow != null && dataGridView.CurrentRow.Index >= 0)
            {
                DataGridViewRow dr = dataGridView.Rows[dataGridView.CurrentRow.Index];
                t_chart chart = t_chartService.Instance.getObject(dr);
                FrmChartBaseInfoAddEdit frm = new FrmChartBaseInfoAddEdit("修改海图信息", chart);
                frm.afterSave += new FrmChartBaseInfoAddEdit.AfterSave(LoadChartData);
                frm.ShowDialog();
            }
        }

        private void bdNgClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            toolStripButton1_Click(sender, e);
        }

        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            string err;
            if (dataGridView.CurrentRow != null && dataGridView.CurrentRow.Index >= 0)
            {
                if (MessageBoxEx.Show("您是否要删除选中的海图？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    DataGridViewRow dr = dataGridView.Rows[dataGridView.CurrentRow.Index];
                    t_chart chart = t_chartService.Instance.getObject(dr); 
                    if (t_chartService.Instance.deleteUnit(chart, out err))
                    {
                        LoadChartData();
                    }
                    else
                    {
                        MessageBoxEx.Show(err);
                    }
                }
            }
        } 

    }
}