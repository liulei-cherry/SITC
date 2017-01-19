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
    public partial class FrmSeaChartCategoryManage : CommonViewer.BaseForm.FormBase
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmSeaChartCategoryManage instance = new FrmSeaChartCategoryManage();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmSeaChartCategoryManage Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmSeaChartCategoryManage.instance = new FrmSeaChartCategoryManage();
                }

                return FrmSeaChartCategoryManage.instance;
            }
        }

        #endregion

        public FrmSeaChartCategoryManage()
        {
            InitializeComponent();
        }

        private void FrmSeaChartCategoryManage_Load(object sender, EventArgs e)
        {
            loadChartData();          
        }

        private void loadChartData()
        {
            string err;
            DataTable dt = T_CHARTINDEXService.Instance.getInfo(out err);
            if (!string.IsNullOrEmpty(err))
            {
                dataGridView.DataSource = dt;
                dataGridView.LoadGridView("FrmSeaChartCategoryManage");
                Dictionary<string, string> columns = new Dictionary<string, string>();
                columns.Add("CHARTNO", "图号");
                columns.Add("TITLECN", "图名(中文)");
                columns.Add("TITLEEN", "图名(英文)");
                columns.Add("SIZE", "面积");
                columns.Add("PAGE", "页");
                dataGridView.SetDgvGridColumns(columns);

            }
        }

        private void FrmSeaChartCategoryManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataGridView.SaveGridView("FrmSeaChartCategoryManage"); 
            instance = null;
        }

        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            FrmSeaChareCategoryAddEdit frm = new FrmSeaChareCategoryAddEdit("添加海图索引", new T_CHARTINDEX());
            frm.afterSave += new FrmSeaChareCategoryAddEdit.AfterSave(loadChartData);
            frm.ShowDialog();
        } 

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow != null && dataGridView.CurrentRow.Index >= 0)
            {
                DataGridViewRow dr = dataGridView.Rows[dataGridView.CurrentRow.Index];
                T_CHARTINDEX chart = T_CHARTINDEXService.Instance.getObject(dr);
                FrmSeaChareCategoryAddEdit frm = new FrmSeaChareCategoryAddEdit("修改海图索引", chart);
                frm.afterSave += new FrmSeaChareCategoryAddEdit.AfterSave(loadChartData);
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
                    T_CHARTINDEX chart = T_CHARTINDEXService.Instance.getObject(dr);
                    if (T_CHARTINDEXService.Instance.deleteUnit(chart, out err))
                    {
                        loadChartData();
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