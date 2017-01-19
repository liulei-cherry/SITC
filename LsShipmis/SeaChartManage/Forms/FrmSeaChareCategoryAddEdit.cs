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
    public partial class FrmSeaChareCategoryAddEdit : CommonViewer.BaseForm.FormBase
    {
        public FrmSeaChareCategoryAddEdit()
        {
            InitializeComponent();
        }
        public FrmSeaChareCategoryAddEdit(string title, T_CHARTINDEX ochart)
        {
            InitializeComponent();
            this.Text = title;
            chart = ochart;
            if (string.IsNullOrEmpty(chart.CHARTID))
            {
                chkContinue.Visible = true;
            }
            else
            {
                loadData();
                chkContinue.Visible = false;
            }
        }

        private void loadData()
        {
            if (chart != null)
            {
                this.txtChartNo.Text = chart.CHARTNO;
                this.txtTitleCn.Text = chart.TITLECN;
                this.txtTitleEn.Text = chart.TITLEEN;
                this.txtSize.Text = chart.SIZE;
                this.txtPage.Text = chart.PAGE;
            }
        }

        private T_CHARTINDEX chart;

        private void setObject()
        {
            chart.CHARTNO = replace(this.txtChartNo.Text.Trim());
            chart.TITLECN = replace(this.txtTitleCn.Text.Trim());
            chart.TITLEEN = replace(this.txtTitleEn.Text.Trim());
            chart.SIZE = replace(this.txtSize.Text.Trim());
            chart.PAGE = replace(this.txtPage.Text.Trim());
        }
        private string replace(string source)
        {
            return source.Replace("'", "''");    
        }

        private bool check()
        {
            if (string.IsNullOrEmpty(this.txtChartNo.Text.Trim()))
            {
                MessageBoxEx.Show("必须输入图号！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtChartNo.Focus();
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
            if (check())
            {
                setObject(); 
                if (T_CHARTINDEXService.Instance.saveUnit(chart, out err))
                {
                    MessageBoxEx.Show("海图索引保存成功", "提示信息", MessageBoxButtons.OK);
                    if (chkContinue.Visible && chkContinue.Checked)
                    {
                        chart = new T_CHARTINDEX();
                        raiseEvent = true;
                        clearText();
                    }
                    else
                    {
                        Close();
                        if (afterSave != null)
                            afterSave();
                    }
                }
                else
                {
                    MessageBoxEx.Show(err, "提示信息", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
            if (raiseEvent && afterSave != null)
                afterSave();

        }

        bool raiseEvent = false;
        public delegate void AfterSave();
        public event AfterSave afterSave;

        private void clearText()
        {
            this.txtChartNo.Text = "";
            this.txtPage.Text = "";
            this.txtSize.Text = "";
            this.txtTitleCn.Text = "";
            this.txtTitleEn.Text = "";
        }
    }
}