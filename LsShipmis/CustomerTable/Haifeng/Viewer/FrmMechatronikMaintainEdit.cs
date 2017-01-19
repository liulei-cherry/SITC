using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CustomerTable.Haifeng.DataObject;
using CommonViewer.BaseControl;

namespace CustomTable.Haifeng.Viewer
{
    public partial class FrmMechatronikMaintainEdit : CommonViewer.BaseForm.FormBase
    {
        private ReportMechatronikMaintain currentObject;
        public FrmMechatronikMaintainEdit(ReportMechatronikMaintain currentObject)
        {
            if (currentObject == null)
                this.currentObject = new ReportMechatronikMaintain();
            else
                this.currentObject = currentObject;
            InitializeComponent();
        }
        private void FrmMechatronikMaintainEdit_Load(object sender, EventArgs e)
        {
            ShowObject();
        }
        private void ShowObject()
        {
            txtVOYAGE.Text = currentObject.VOYAGE;
            dtpBEGIN_DATE.Value = currentObject.BEGIN_DATE;
            dtpEND_DATE.Value = currentObject.END_DATE;
            dtpREPORT_DATE.Value = currentObject.REPORT_DATE;
            txtCHUAN_ZHANG.Text = currentObject.CHUAN_ZHANG;
            txtLUN_JI_ZHANG.Text = currentObject.LUN_JI_ZHANG;
            txtDA_GUAN_LUN.Text = currentObject.DA_GUAN_LUN;
            txtER_GUAN_LUN.Text = currentObject.ER_GUAN_LUN;
            txtSAN_GUAN_LUN.Text = currentObject.SAN_GUAN_LUN;
            txtDIAN_JI_YUAN.Text = currentObject.DIAN_JI_YUAN;
            txtUSE_CONDITION.Text = currentObject.USE_CONDITION;
            txtUNDONE_PROJECT.Text = currentObject.UNDONE_PROJECT;
            txtPROBLEM.Text = currentObject.PROBLEM;
            txtTEMPORARY_PROJECT.Text = currentObject.TEMPORARY_PROJECT;
            txtVERIFY_SUGGESTION.Text = currentObject.VERIFY_SUGGESTION;
        }
        private bool CheckForm()
        {
            if (string.IsNullOrEmpty(txtVOYAGE.Text.Trim()))
            {
                MessageBoxEx.Show("航次不能为空");
                return false;
            }
            if (dtpBEGIN_DATE.Value == DateTime.MinValue)
            {
                MessageBoxEx.Show("开始时间不能为空");
                return false;
            }
            if (dtpEND_DATE.Value == DateTime.MinValue)
            {
                MessageBoxEx.Show("结束时间不能为空");
                return false;
            }
            if (dtpREPORT_DATE.Value == DateTime.MinValue)
            {
                MessageBoxEx.Show("日期不能为空");
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckForm())
                return;
            if (currentObject.FILE_ID == null)
                currentObject.FILE_ID = Guid.NewGuid().ToString();
            currentObject.FILE_DATE = dtpREPORT_DATE.Value; ;
            currentObject.VOYAGE = txtVOYAGE.Text;
            currentObject.BEGIN_DATE = dtpBEGIN_DATE.Value;
            currentObject.END_DATE = dtpEND_DATE.Value;
            currentObject.REPORT_DATE = dtpREPORT_DATE.Value;
            currentObject.CHUAN_ZHANG = txtCHUAN_ZHANG.Text;
            currentObject.LUN_JI_ZHANG = txtLUN_JI_ZHANG.Text;
            currentObject.DA_GUAN_LUN = txtDA_GUAN_LUN.Text;
            currentObject.ER_GUAN_LUN = txtER_GUAN_LUN.Text;
            currentObject.SAN_GUAN_LUN = txtSAN_GUAN_LUN.Text;
            currentObject.DIAN_JI_YUAN = txtDIAN_JI_YUAN.Text;
            currentObject.USE_CONDITION = txtUSE_CONDITION.Text;
            currentObject.UNDONE_PROJECT = txtUNDONE_PROJECT.Text;
            currentObject.PROBLEM = txtPROBLEM.Text;
            currentObject.TEMPORARY_PROJECT = txtTEMPORARY_PROJECT.Text;
            currentObject.VERIFY_SUGGESTION = txtVERIFY_SUGGESTION.Text;
            string err;
            if (!currentObject.Update(out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            this.Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
