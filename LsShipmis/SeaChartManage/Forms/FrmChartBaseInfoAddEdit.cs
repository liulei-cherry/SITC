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
    public partial class FrmChartBaseInfoAddEdit : CommonViewer.BaseForm.FormBase
    {
        public FrmChartBaseInfoAddEdit()
        {
            InitializeComponent();
        }

        public FrmChartBaseInfoAddEdit(string title, t_chart ochart)
        {
            InitializeComponent();
            this.Text = title;
            chart = ochart;
            if (string.IsNullOrEmpty(chart.chartid))
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
            try
            {
                this.txtchartnum.Text = chart.chartnum;
                this.txtchartname.Text = chart.chartname;
                this.txtchartenglishname.Text = chart.chartenglishname;
                this.txtchartrule.Text = chart.chartrule;
                this.txtpaperchart.Text = chart.paperchart;
                this.txtchangedate.Text = chart.changedate;
                this.txtchartformat.Text = chart.chartformat;
                this.txtsailtellnum.Text = chart.sailtellnum;
                this.txtremark.Text = chart.remark;
                this.txtpublishdept.Text = chart.publishdept;
            }
            catch { }
        }

        private t_chart chart;

        private void setObject()
        {
            chart.chartnum = replace(this.txtchartnum.Text.Trim());
            chart.chartname = replace(this.txtchartname.Text.Trim());
            chart.chartenglishname = replace(this.txtchartenglishname.Text.Trim());
            chart.chartrule = replace(this.txtchartrule.Text.Trim());
            chart.paperchart = replace(this.txtpaperchart.Text.Trim());
            chart.changedate = replace(this.txtchangedate.Text.Trim());
            chart.chartformat = replace(this.txtchartformat.Text.Trim());
            chart.sailtellnum = replace(this.txtsailtellnum.Text.Trim());
            chart.remark = replace(this.txtremark.Text.Trim());
            chart.publishdept = replace(this.txtpublishdept.Text.Trim());
        }
        private string replace(string source)
        {
            return source.Replace("'", "''");    
        }

        private bool check()
        {
            if (string.IsNullOrEmpty(this.txtchartnum.Text.Trim()))
            {
                MessageBoxEx.Show("必须输入图号！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtchartnum.Focus();
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
                if (t_chartService.Instance.saveUnit(chart, out err))
                {
                    MessageBoxEx.Show("海图信息保存成功", "提示信息", MessageBoxButtons.OK);
                    if (chkContinue.Visible && chkContinue.Checked)
                    {
                        chart = new t_chart();
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
            this.txtchartnum.Text = "";
            this.txtchartname.Text = "";
            this.txtchartenglishname.Text = "";
            this.txtchartrule.Text = "";
            this.txtpaperchart.Text = "";
            this.txtchangedate.Text = "";
            this.txtchartformat.Text = "";
            this.txtsailtellnum.Text = "";
            this.txtremark.Text = "";
            this.txtpublishdept.Text = "";
        }
    }
}