using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Repair.DataObject;
using Repair.Services;
using CommonViewer;
using CommonViewer.BaseControl;
using BaseInfo.DataAccess;
using CommonOperation.Functions;
using Cost.Services;
using CommonViewer.BaseForm;

namespace Repair.Viewer
{
    public partial class FrmCompleteAll : CommonViewer.BaseForm.FormBase
    {
        private ShipRepairEvent sre = null;
        public FrmCompleteAll(string paramRepairID)
        {
            string err;
            InitializeComponent();
            sre = ShipRepairEventService.Instance.getObject(paramRepairID, out err);
        }
        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCompleteAll_Load(object sender, EventArgs e)
        {
            string err;

            if (sre.COMPLETEDATE != null && sre.COMPLETEDATE != DateTime.MinValue)
            {
                dtpCOMPLETEDATE.Value = sre.COMPLETEDATE;
            }
            else
            {
                dtpCOMPLETEDATE.Value = DateTime.Now;
            }
            txtREMARK.Text = sre.REMARK;
            setDetailBindingSource();
            setDetailDataGridView();
            if (!CommonOperation.ConstParameter.IsLandVersion)
            {
                dtpCOMPLETEDATE.Enabled = false;
            }
            else
            {
                DataTable dtbCurrency = CurrencyService.Instance.getInfo(out err);
                cboCurrency.DataSource = dtbCurrency;
                cboCurrency.DisplayMember = "SHOWINGNAME";
                cboCurrency.ValueMember = "CURRENCYID";
                DgvBindDrop dgvBindDrop4 = new DgvBindDrop();
                dgvBindDrop4.bindDropToDgv(dgvDetail, cboCurrency, 8, false, 1);

                DgvBindDrop dgvBindDrop5 = new DgvBindDrop();
                dgvBindDrop5.bindDropToDgv(dgvDetail, dateTimePicker1, 6);

            }
        }
        /// <summary>
        /// 绑定详细grid
        /// </summary>
        private void setDetailBindingSource()
        {
            DataTable dtbDetail = ShipRepairProjectService.Instance.GetCompleteInfo(sre.REPAIRID);
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");
            sb.Append(" and PROJECTSTATE=8 ");
            DataTable newdt = new DataTable();
            newdt = dtbDetail.Clone();
            foreach (DataRow item in dtbDetail.Select(sb.ToString()))
                newdt.Rows.Add(item.ItemArray);
            dgvDetail.DataSource = newdt;
        }
        /// <summary>
        ///  设置详细grid的隐藏列与显示标题.
        /// </summary>
        private void setDetailDataGridView()
        {
            UcDataGridView dgv = dgvDetail;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("PROJECTNAME", "修理项目名称");
            dic.Add("PROJECTDETAIL", "修理项目详细");
            dic.Add("APPLYDATE", "申请日期");
            dic.Add("APPLICANT", "申请人");
            dic.Add("APPLYCOMPLETEDATE", "期望完成日期");
            dic.Add("REALCOMPLETEDATE", "完成日期");
            dic.Add("AFFIRMANT", "申请最终确认人");
            dic.Add("COMPLETEAFFIRMANT", "完成确认人");
            dic.Add("RUNNINGORDOCK_NAME", "航修或坞修");
            dic.Add("REMARK", "备注");
            dic.Add("CURRENCYCODE", "货币");
            dic.Add("COSTCOUNT", "消费金额");
            dic.Add("COMP_CHINESE_NAME", "修理设备");
            dic.Add("SENDTOWARRANT_NAME", "是否提交费用凭证");
            dic.Add("HEADSHIP_NAME", "申请人岗位");
            dic.Add("NODE_NAME", "修理科目");
            dgv.SetDgvGridColumns(dic);
            foreach (DataGridViewColumn item in dgvDetail.Columns)
                item.ReadOnly = true;
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                dgv.Columns["REALCOMPLETEDATE"].ReadOnly = false;
                dgv.Columns["CURRENCYCODE"].ReadOnly = false;
                dgv.Columns["COSTCOUNT"].ReadOnly = false;
            }
            dgv.Columns["REMARK"].ReadOnly = false;
            foreach (DataGridViewColumn item in dgvDetail.Columns)
                if (item.ReadOnly)
                    item.DefaultCellStyle.BackColor = Color.Linen;
            dgv.LoadGridView("FrmCompleteAll.dgvDetail");
        }
        /// <summary>
        /// 表单验证.
        /// </summary>
        /// <returns></returns>
        private bool CheckForm(DataGridViewRow item)
        {
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                if (string.IsNullOrEmpty(item.Cells["CURRENCYID"].Value.ToString()))
                {
                    MessageBoxEx.Show("币种不能为空");
                    return false;
                }
                if (string.IsNullOrEmpty(item.Cells["COSTCOUNT"].Value.ToString()))
                {
                    MessageBoxEx.Show("金额不能为空");
                    return false;
                }
                if (string.IsNullOrEmpty(item.Cells["REALCOMPLETEDATE"].Value.ToString()))
                {
                    MessageBoxEx.Show("完成时间不能为空");
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 完工.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComplete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvDetail.Rows)
            {
                if (!CheckForm(item)) return;
            }
            sre.REMARK = txtREMARK.Text.Trim();
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                sre.COMPAFFIRMANT = CommonOperation.ConstParameter.UserName;
                sre.COMPLETEDATE = dtpCOMPLETEDATE.Value;
            }
            else
                sre.SHIPAFFIRMANT = CommonOperation.ConstParameter.UserName;
            string err;
            using (TransactionClass tc = new TransactionClass())
            {
                ShipRepairEventService.Instance.saveUnit(sre, out err);
                foreach (DataGridViewRow item in dgvDetail.Rows)
                {
                    ShipRepairProject srp = ShipRepairProjectService.Instance.getObject(item.Cells["PROJECTID"].Value.ToString(), out err);
                    if (CommonOperation.ConstParameter.IsLandVersion)
                    {
                        srp.CURRENCYID = item.Cells["CURRENCYID"].Value.ToString();
                        srp.COSTCOUNT = Convert.ToInt32(item.Cells["COSTCOUNT"].Value);
                        srp.REALCOMPLETEDATE = Convert.ToDateTime(item.Cells["REALCOMPLETEDATE"].Value);
                        srp.COMPLETEAFFIRMANT = CommonOperation.ConstParameter.UserName;
                        srp.PROJECTSTATE = 9;

                        DataTable dtSrrr = ShipRunningRepairRelationService.Instance.GetInfo(srp.PROJECTID, sre.REPAIRID, "3", out err);
                        ShipRunningRepairRelation srrr = ShipRunningRepairRelationService.Instance.getObject(dtSrrr.Rows[0]);
                        srrr.STATE = 1;
                        ShipRunningRepairRelationService.Instance.saveUnit(srrr, out err);
                    }
                    srp.REMARK = item.Cells["REMARK"].Value.ToString();
                    ShipRepairProjectService.Instance.saveUnit(srp, out err);
                }
                tc.CommitTransaction();
            }
            if (string.IsNullOrEmpty(err))
            {
                MessageBoxEx.Show("操作成功！", "提示");
                this.Close();
            }
            else
            {
                MessageBoxEx.Show(err, "操作失败");
            }
        }

        private void cboCurrency_SelectedValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvDetail.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dgvDetail.Rows[i].Cells["CURRENCYID"].Value.ToString()))
                {
                    dgvDetail.Rows[i].Cells["CURRENCYCODE"].Value = ((System.Data.DataRowView)(cboCurrency.SelectedItem)).Row.ItemArray[2].ToString();
                    dgvDetail.Rows[i].Cells["CURRENCYID"].Value = ((System.Data.DataRowView)(cboCurrency.SelectedItem)).Row.ItemArray[0].ToString();
                }

            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvDetail.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dgvDetail.Rows[i].Cells["REALCOMPLETEDATE"].Value.ToString()))
                {
                    dgvDetail.Rows[i].Cells["REALCOMPLETEDATE"].Value = dateTimePicker1.Value;
                }
            }
        }
        private void FrmCompleteAll_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvDetail.SaveGridView("FrmCompleteAll.dgvDetail");
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
    }
}