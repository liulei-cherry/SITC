using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SeaChartManage.BusinessClasses;
using SeaChartManage.Services;
using CommonViewer.BaseControlService;
using CommonViewer.BaseForm;
using CommonViewer.BaseControl;

namespace SeaChartManage.Forms
{
    public partial class FrmSeaChartInfoManage : CommonViewer.BaseForm.FormBase
    {
        #region 窗体单实例模型
        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmSeaChartInfoManage instance;
        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmSeaChartInfoManage Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmSeaChartInfoManage.instance = new FrmSeaChartInfoManage();
                }
                return FrmSeaChartInfoManage.instance;
            }
        }
        #endregion
        private FrmSeaChartInfoManage()
        {
            InitializeComponent();

        }

        private void FrmSeaChartInfoManage_Load(object sender, EventArgs e)
        {
            LoadData();
        }
      
        private void LoadData()
        {
            string err;
            DataTable dt = T_CHARTINFOService.Instance.getInfo(out err);
            this.dataGridView.DataSource = dt;
            dataGridView.LoadGridView("FrmSeaChartInfoManage");
            Dictionary<string, string> columns = new Dictionary<string, string>();
            columns.Add("CHARTTITLE", "通告标题");
            columns.Add("CHARTCONTENT", "通告内容");
            columns.Add("PUBLISHER", "发布单位");
            columns.Add("PUBLISHDATE", "发布日期");
            dataGridView.SetDgvGridColumns(columns);
        }

        private void FrmSeaChartInfoManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
            dataGridView.SaveGridView("FrmSeaChartInfoManage");
        }

        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            FrmSeaChartInfoAddEdit frm = new FrmSeaChartInfoAddEdit("添加航海通告", new T_CHARTINFO());
            frm.afterSave += new FrmSeaChartInfoAddEdit.AfterSave(frm_afterSave);
            frm.ShowDialog();
        }

        void frm_afterSave()
        {
            LoadData();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow != null && dataGridView.CurrentRow.Index >= 0)
            {
                DataGridViewRow dr = dataGridView.Rows[dataGridView.CurrentRow.Index];
                T_CHARTINFO chart = T_CHARTINFOService.Instance.getObject(dr);
                FrmSeaChartInfoAddEdit frm = new FrmSeaChartInfoAddEdit("修改航海公告", chart);
                frm.afterSave += new FrmSeaChartInfoAddEdit.AfterSave(frm_afterSave);
                frm.ShowDialog();
            }
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
                if (MessageBoxEx.Show("您是否要删除选中的航海公告？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    DataGridViewRow dr = dataGridView.Rows[dataGridView.CurrentRow.Index];
                    T_CHARTINFO chart = T_CHARTINFOService.Instance.getObject(dr);
                    if (T_CHARTINFOService.Instance.deleteUnit(chart, out err))
                    {
                        frm_afterSave();
                    }
                    else
                    {
                        MessageBoxEx.Show(err);
                    }
                }
            }
        }

        private void bdNgClose_Click(object sender, EventArgs e)
        {
            Close();
        }

    }

}