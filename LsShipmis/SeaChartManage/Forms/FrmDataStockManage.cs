using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SeaChartManage.BusinessClasses;
using SeaChartManage.Services;
using CommonViewer.BaseControl;
using CommonViewer.BaseControlService;
using CommonViewer.BaseForm;

namespace SeaChartManage.Forms
{
    public partial class FrmDataStockManage : CommonViewer.BaseForm.FormBase
    {
        public FrmDataStockManage()
        {
            InitializeComponent();
        }

        #region 窗体单实例模型
        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmDataStockManage instance = new FrmDataStockManage();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmDataStockManage Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmDataStockManage.instance = new FrmDataStockManage();
                }

                return FrmDataStockManage.instance;
            }
        }

        #endregion

        private void FrmDataStockManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
            dataGridView.SaveGridView("FrmDataStockManage");

        }

        private void FrmDataStockManage_Load(object sender, EventArgs e)
        {
            laodData();

        }

        private void laodData()
        {
            string err;
            DataTable dt = T_DATA_STOCKService.Instance.getInfo(out err);
            if (dt != null )
            {
                dataGridView.DataSource = dt;
                dataGridView.LoadGridView("FrmDataStockManage");
                Dictionary<string, string> columns = new Dictionary<string, string>();
                columns.Add("CODE", "编号");
                columns.Add("DATA_NAME", "名称");
                columns.Add("DATA_REMARK", "备注");
                columns.Add("DATA_NUMBER", "总数量");
                columns.Add("DATA_LIEVE_NUMBER", "剩余数量");
                columns.Add("DATA_CLASS", "类别");
                dataGridView.SetDgvGridColumns(columns);
            }
        }

        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            FrmDataStockAddEdit frm = new FrmDataStockAddEdit("添加资料", new T_DATA_STOCK());
            frm.afterSave += new FrmDataStockAddEdit.AfterSave(laodData);
            frm.ShowDialog();
            laodData();
        }
 
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow != null && dataGridView.CurrentRow.Index >= 0)
            {
                DataGridViewRow dr = dataGridView.Rows[dataGridView.CurrentRow.Index];
                T_DATA_STOCK stock = T_DATA_STOCKService.Instance.getObject(dr);
                FrmDataStockAddEdit frm = new FrmDataStockAddEdit("修改资料信息", stock);
                frm.afterSave += new FrmDataStockAddEdit.AfterSave(laodData);
                frm.ShowDialog();
            }
        }

        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            string err;
            if (dataGridView.CurrentRow != null && dataGridView.CurrentRow.Index >= 0)
            {
                if (MessageBoxEx.Show("您是否要删除选中的资料信息？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    DataGridViewRow dr = dataGridView.Rows[dataGridView.CurrentRow.Index];
                    T_DATA_STOCK stock = T_DATA_STOCKService.Instance.getObject(dr);
                    if (T_DATA_STOCKService.Instance.deleteUnit(stock, out err))
                    {
                        laodData();
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