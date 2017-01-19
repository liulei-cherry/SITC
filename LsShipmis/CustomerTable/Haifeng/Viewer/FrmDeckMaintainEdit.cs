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
    public partial class FrmDeckMaintainEdit : CommonViewer.BaseForm.FormBase
    {
        private ReportDeckMaintain currentObject;
        public FrmDeckMaintainEdit(ReportDeckMaintain currentObject)
        {
            if (currentObject == null)
                this.currentObject = new ReportDeckMaintain();
            else
                this.currentObject = currentObject;
            InitializeComponent();
        }
        private void FrmDeckMaintainEdit_Load(object sender, EventArgs e)
        {
            ShowObject();
            DeckMaintainBanding();
        }
        private void DeckMaintainBanding()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("船体结构（舱壁、底版等）", currentObject.CTJG);
            dic.Add("船壳板", currentObject.CKB);
            dic.Add("舾装、生活区", currentObject.XZ_SHQ);
            dic.Add("甲板", currentObject.JB);
            dic.Add("甲板设施", currentObject.JBSB);
            dic.Add("舱盖", currentObject.CG);
            dic.Add("引水梯", currentObject.YST);
            dic.Add("顶边水舱", currentObject.DBSC);
            dic.Add("压载水舱", currentObject.YZSC);
            dic.Add("甲板管系", currentObject.JBGX);
            dic.Add("消防", currentObject.XF);
            dic.Add("救生", currentObject.JS);
            dic.Add("水密门、窗", currentObject.SMM_C);
            dic.Add("透气管", currentObject.TQG);
            dic.Add("通风设备", currentObject.TFSB);
            dic.Add("其他", currentObject.QT);

            DataTable dt = new DataTable();
            dt.Columns.Add("NAME", typeof(string));
            dt.Columns.Add("VALUE", typeof(string));
            foreach (string item in dic.Keys)
            {
                DataRow dr = dt.NewRow();
                dr["NAME"] = item;
                dr["VALUE"] = dic[item];
                dt.Rows.Add(dr);
            }
            dgvDetail.DataSource = dt;
            dgvDetail.Columns["NAME"].HeaderText = "项目";
            dgvDetail.Columns["NAME"].ReadOnly = true;
            dgvDetail.Columns["VALUE"].HeaderText = "内容";
            dgvDetail.LoadGridView("FrmDeckMaintainEdit.dgvDetail");
        }

        private void ShowObject()
        {
            txtVOYAGE.Text = currentObject.VOYAGE;
            dtpBEGIN_DATE.Value = currentObject.BEGIN_DATE;
            dtpEND_DATE.Value = currentObject.END_DATE;
            dtpREPORT_DATE.Value = currentObject.REPORT_DATE;
            txtCHUAN_ZHANG.Text = currentObject.CHUAN_ZHANG;
            txtSHUI_SHOU.Text = currentObject.SHUI_SHOU;
            txtDA_FU.Text = currentObject.DA_FU;
            txtER_FU.Text = currentObject.ER_FU;
            txtSAN_FU.Text = currentObject.SAN_FU;
            txtMU_JIANG.Text = currentObject.MU_JIANG;
            txtAIR_LINE.Text = currentObject.AIR_LINE;
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
            if (string.IsNullOrEmpty(txtAIR_LINE.Text.Trim()))
            {
                MessageBoxEx.Show("航线不能为空");
                return false;
            }
            if (dtpBEGIN_DATE.Value==DateTime.MinValue)
            {
                MessageBoxEx.Show("开始时间不能为空");
                return false;
            }
            if (dtpEND_DATE.Value==DateTime.MinValue)
            {
                MessageBoxEx.Show("结束时间不能为空");
                return false;
            }
            if (dtpREPORT_DATE.Value==DateTime.MinValue)
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
            currentObject.FILE_DATE = dtpREPORT_DATE.Value;
            currentObject.VOYAGE = txtVOYAGE.Text;
            currentObject.BEGIN_DATE = dtpBEGIN_DATE.Value;
            currentObject.END_DATE = dtpEND_DATE.Value;
            currentObject.REPORT_DATE = dtpREPORT_DATE.Value;
            currentObject.CHUAN_ZHANG = txtCHUAN_ZHANG.Text;
            currentObject.SHUI_SHOU = txtSHUI_SHOU.Text;
            currentObject.DA_FU = txtDA_FU.Text;
            currentObject.ER_FU = txtER_FU.Text;
            currentObject.SAN_FU = txtSAN_FU.Text;
            currentObject.MU_JIANG = txtMU_JIANG.Text;
            currentObject.AIR_LINE = txtAIR_LINE.Text;
            currentObject.UNDONE_PROJECT = txtUNDONE_PROJECT.Text;
            currentObject.PROBLEM = txtPROBLEM.Text;
            currentObject.TEMPORARY_PROJECT = txtTEMPORARY_PROJECT.Text;
            currentObject.VERIFY_SUGGESTION = txtVERIFY_SUGGESTION.Text;

            DataTable dt = (DataTable)dgvDetail.DataSource;
            currentObject.CTJG = dt.Rows[0]["VALUE"].ToString();
            currentObject.CKB = dt.Rows[1]["VALUE"].ToString();
            currentObject.XZ_SHQ = dt.Rows[2]["VALUE"].ToString();
            currentObject.JB = dt.Rows[3]["VALUE"].ToString();
            currentObject.JBSB = dt.Rows[4]["VALUE"].ToString();
            currentObject.CG = dt.Rows[5]["VALUE"].ToString();
            currentObject.YST = dt.Rows[6]["VALUE"].ToString();
            currentObject.DBSC = dt.Rows[7]["VALUE"].ToString();
            currentObject.YZSC = dt.Rows[8]["VALUE"].ToString();
            currentObject.JBGX = dt.Rows[9]["VALUE"].ToString();
            currentObject.XF = dt.Rows[10]["VALUE"].ToString();
            currentObject.JS = dt.Rows[11]["VALUE"].ToString();
            currentObject.SMM_C = dt.Rows[12]["VALUE"].ToString();
            currentObject.TQG = dt.Rows[13]["VALUE"].ToString();
            currentObject.TFSB = dt.Rows[14]["VALUE"].ToString();
            currentObject.QT = dt.Rows[15]["VALUE"].ToString();

            string err;
            if (!currentObject.Update(out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            this.Close();
        }
        private void FrmDeckMaintainEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvDetail.SaveGridView("FrmDeckMaintainEdit.dgvDetail");
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
