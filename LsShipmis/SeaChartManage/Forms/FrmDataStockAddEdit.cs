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
    public partial class FrmDataStockAddEdit : CommonViewer.BaseForm.FormBase
    {
        public FrmDataStockAddEdit()
        {
            InitializeComponent();
            numTotle.Value = 1;
            nulLeft.Value = 1;
        }
        public FrmDataStockAddEdit(string title,T_DATA_STOCK ostock)
        {
            InitializeComponent();
            cboKind.SelectedIndex = 0;
            this.Text = title;
            stock = ostock;
            if (string.IsNullOrEmpty(stock.DATA_STOCK_ID))
            {
                chkContinue.Visible = true;
            }
            else
            {
                chkContinue.Visible = false;
                loadData();
            }

        }

        private void loadData()
        {
            this.txtCode.Text = stock.CODE;
            this.cboKind.Text = stock.DATA_CLASS;
            this.txtName.Text = stock.DATA_NAME;
            this.txtContent.Text = stock.DATA_REMARK;
            this.numTotle.Value = stock.DATA_NUMBER;
            this.nulLeft.Value = stock.DATA_LIEVE_NUMBER;
        }

        private void setObject()
        {
            stock.CODE=replace(this.txtCode.Text.Trim());
            stock.DATA_CLASS = replace(this.cboKind.Text.Trim());
            stock.DATA_NAME = replace(this.txtName.Text.Trim());
            stock.DATA_REMARK = replace(this.txtContent.Text.Trim());
            stock.DATA_NUMBER =Convert.ToInt32(this.numTotle.Value);
            stock.DATA_LIEVE_NUMBER =Convert.ToInt32(this.nulLeft.Value);
        }

        private string replace(string source)
        {
            return source.Replace("'", "''");
        }
        private bool check()
        {
            if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
            {
                MessageBoxEx.Show("必须输入资料名称！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtName.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        T_DATA_STOCK stock;
        bool raiseEvent = false;
        private void button1_Click(object sender, EventArgs e)
        {
            string err;
            if (check())
            {
                setObject(); 
                if (T_DATA_STOCKService.Instance.saveUnit(stock, out err))
                {
                    MessageBoxEx.Show("资料保存成功", "提示信息", MessageBoxButtons.OK);
                    if (chkContinue.Visible && chkContinue.Checked)
                    {
                        stock = new T_DATA_STOCK();
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
                    MessageBoxEx.Show(err, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void clearText()
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtContent.Text = "";
            numTotle.Value = 1;
            nulLeft.Value = 1;
        }

        public delegate void AfterSave();
        public event AfterSave afterSave;

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            if (raiseEvent && afterSave != null)
                afterSave();
        }
    }
}