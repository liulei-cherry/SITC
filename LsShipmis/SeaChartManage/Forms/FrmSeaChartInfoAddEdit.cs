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

namespace SeaChartManage.Forms
{
    public partial class FrmSeaChartInfoAddEdit : CommonViewer.BaseForm.FormBase
    {
        public FrmSeaChartInfoAddEdit()
        {
            InitializeComponent();
        }
        public FrmSeaChartInfoAddEdit(string title, T_CHARTINFO ochart)
        {
            InitializeComponent();
            this.Text = title;
            chart = ochart;
            if (!string.IsNullOrEmpty(chart.ChartInfoId)) //edit
            {
                loadData();
            }
        }

        private void loadData()
        {
            this.txtContent.Text = chart.CHARTCONTENT;
            this.txtTitle.Text = chart.CHARTTITLE;
            this.txtPublisher.Text = chart.PUBLISHER;
            this.datPublishDate.Value = chart.PUBLISHDATE;
        }
        T_CHARTINFO chart;

        private void setObject()
        {
            chart.CHARTCONTENT = replace(this.txtContent.Text.Trim());
            chart.CHARTTITLE = replace(this.txtTitle.Text.Trim());
            chart.PUBLISHER = replace(this.txtPublisher.Text.Trim());
            chart.PUBLISHDATE = this.datPublishDate.Value;
        }

        private string replace(string source)
        {
            return source.Replace("'", "''");
        }

        private bool check()
        {
            if (string.IsNullOrEmpty(this.txtTitle.Text.Trim()))
            {
                MessageBoxEx.Show("必须输入通告标题！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtTitle.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string err;
            setObject();
            if (check())
            {
                if (T_CHARTINFOService.Instance.saveUnit(chart, out err))
                {
                    MessageBoxEx.Show("航海通告保存成功", "提示信息", MessageBoxButtons.OK);
                    Close();
                    if (afterSave != null)
                        afterSave();
                }
                else
                {
                    MessageBoxEx.Show(err, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public delegate void AfterSave();
        public event AfterSave afterSave;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}