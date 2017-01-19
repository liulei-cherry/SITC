using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Cost.DataObject;
using Cost.Services;
using CommonViewer.BaseControl;

namespace Cost.Viewer
{
    /// <summary>
    /// 船舶分类信息管理窗体.
    /// </summary>
    /// 
    public partial class FrmBudgetEdit : CommonViewer.BaseForm.BaseMdiChildForm
    {
        string budget_id = null;
        CostBudget currentObject = null;

        public FrmBudgetEdit()
        {
            InitializeComponent();
            currentObject = new CostBudget();
            currentObject.STATE = 1;
        }

        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmBudgetEdit(string id)
            : this()
        {
            budget_id = id;
            string err;
            this.currentObject = CostBudgetService.Instance.getObject(id, out err);
        }

        /// <summary>
        /// 主窗体加载.
        /// </summary>
        private void FrmBudgetEdit_Load(object sender, EventArgs e)
        {
            if (currentObject != null)
                LoadMainData();
        }
        /// <summary>
        /// 关闭窗体.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 加载凭证列表数据.
        /// </summary>
        public void LoadMainData()
        {
            if (currentObject != null)
            {
                //textBoxEx1.Text = dgvList.Rows[rowNumber].Cells[""].Value.ToString();
                textBoxEx3.Text = currentObject.APPROVE_NUM;
                textBoxEx4.Text = currentObject.REMARK;
                num1.Value = currentObject.S_CNY_AMOUNT;
                num2.Value = currentObject.Y_CNY_AMOUNT;
                num3.Value = currentObject.X_CNY_AMOUNT;
                num4.Value = currentObject.S_USD_AMOUNT;
                num5.Value = currentObject.Y_USD_AMOUNT;
                num6.Value = currentObject.X_USD_AMOUNT;
                num7.Value = currentObject.S_EUR_AMOUNT;
                num8.Value = currentObject.Y_EUR_AMOUNT;
                num9.Value = currentObject.X_EUR_AMOUNT;
                num10.Value = currentObject.S_JPY_AMOUNT;
                num11.Value = currentObject.Y_JPY_AMOUNT;
                num12.Value = currentObject.X_JPY_AMOUNT;

            }
        }

        private void FormToObject()
        {
            currentObject.CREATE_DATE = DateTime.Now;
            currentObject.APPROVE_NUM = textBoxEx3.Text.Trim();
            currentObject.REMARK = textBoxEx4.Text.Trim();
            currentObject.S_CNY_AMOUNT = num1.Value;
            currentObject.Y_CNY_AMOUNT = num2.Value;
            currentObject.X_CNY_AMOUNT = num3.Value;
            currentObject.S_USD_AMOUNT = num4.Value;
            currentObject.Y_USD_AMOUNT = num5.Value;
            currentObject.X_USD_AMOUNT = num6.Value;
            currentObject.S_EUR_AMOUNT = num7.Value;
            currentObject.Y_EUR_AMOUNT = num8.Value;
            currentObject.X_EUR_AMOUNT = num9.Value;
            currentObject.S_JPY_AMOUNT = num10.Value;
            currentObject.Y_JPY_AMOUNT = num11.Value;
            currentObject.X_JPY_AMOUNT = num12.Value;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            FormToObject();
            string err;
            if (!currentObject.Update(out err))
                MessageBoxEx.Show(err);
            else
            {
                MessageBoxEx.Show("操作成功");
                this.Close();
            }
        }

    }
}