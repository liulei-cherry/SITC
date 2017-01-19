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

namespace Repair.Viewer
{
    public partial class FrmCompleteEditRemark : CommonViewer.BaseForm.FormBase
    {
        #region 窗体单实例模型
        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmCompleteEditRemark instance = new FrmCompleteEditRemark();
        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmCompleteEditRemark Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmCompleteEditRemark.instance = new FrmCompleteEditRemark();
                }

                return FrmCompleteEditRemark.instance;
            }
        }
        private FrmCompleteEditRemark()
        {
            InitializeComponent();
        }
        #endregion
        private ShipRepairProject srp = null;
        private ShipRepairEvent sre = null;
        private ShipRunningRepairRelation srr = null;
        public FrmCompleteEditRemark(string paramRepairID, string paramProjectID, string paramRunningRepairRelationID)
        {
            string err;
            InitializeComponent();
            srp = ShipRepairProjectService.Instance.getObject(paramProjectID, out err);
            sre = ShipRepairEventService.Instance.getObject(paramRepairID, out err);
            srr = ShipRunningRepairRelationService.Instance.getObject(paramRunningRepairRelationID, out err);
            if (srp.PROJECTSTATE == 9)
            {
                ucCurrencySelect1.Enabled = false;
                nudAmount.ReadOnly = true;
                nudAmount.Enabled = false;
                dateTimePickerEx1.ReadOnly = true;
                checkBox1.Visible = true;
            }
            else
            {
                ucCurrencySelect1.Enabled = true;
                nudAmount.ReadOnly = false;
                nudAmount.Enabled = true;
                dateTimePickerEx1.ReadOnly = false;
                checkBox1.Visible = false;
            }
        }
        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCompleteEdit_Load(object sender, EventArgs e)
        {
            ucCurrencySelect1.ChangeMode(true, false, true);
            if (srp.REALCOMPLETEDATE != null && srp.REALCOMPLETEDATE != DateTime.MinValue)
            {
                dateTimePickerEx1.Value = srp.REALCOMPLETEDATE;
            }
            else
            {
                dateTimePickerEx1.Value = DateTime.Now;
            }
            if (!string.IsNullOrEmpty(srp.CURRENCYID))
                ucCurrencySelect1.SelectedId(srp.CURRENCYID);
            nudAmount.Value = srp.COSTCOUNT;
            txtREMARK.Text = srr.REMARK;
            if (!CommonOperation.ConstParameter.IsLandVersion)
            {
                nudAmount.Enabled = false;
                ucCurrencySelect1.Enabled = false;
                dateTimePickerEx1.Enabled = false;
            }
        }
        /// <summary>
        /// 表单验证.
        /// </summary>
        /// <returns></returns>
        private bool CheckForm()
        {
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                if (string.IsNullOrEmpty(ucCurrencySelect1.GetId()))
                {
                    MessageBoxEx.Show("币种不能为空");
                    return false;
                }
                if (string.IsNullOrEmpty(nudAmount.Value.ToString()))
                {
                    MessageBoxEx.Show("金额不能为空");
                    return false;
                }
                if (string.IsNullOrEmpty(dateTimePickerEx1.Value.ToString()))
                {
                    MessageBoxEx.Show("完成日期不能为空");
                    return false;
                }
                if (nudAmount.Value < 0)
                {
                    MessageBoxEx.Show("金额不能为负数");
                    return false;
                }
                if (nudAmount.Value < 0)
                {
                    MessageBoxEx.Show("金额不能为负数");
                    return false;
                }
                if (nudAmount.Value == 0)
                {
                    if (MessageBoxEx.Show("金额为零,是否继续操作?", "系统提示", MessageBoxButtons.YesNo) == DialogResult.No)
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
            if (!CheckForm()) return;
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                sre.COMPLETEDATE = dateTimePickerEx1.Value;
                srp.CURRENCYID = ucCurrencySelect1.GetId();
                srp.COSTCOUNT = nudAmount.Value;
                srp.REALCOMPLETEDATE = dateTimePickerEx1.Value;
            }
            srr.REMARK = txtREMARK.Text.Trim();
            string err;
            using (TransactionClass tc = new TransactionClass())
            {
                ShipRepairEventService.Instance.saveUnit(sre, out err);
                ShipRepairProjectService.Instance.saveUnit(srp, out err);
                ShipRunningRepairRelationService.Instance.saveUnit(srr, out err);
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
        /// <summary>
        /// 关闭窗体.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCompleteEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                MessageBoxEx.Show("修改已经完工项目的完工信息可能会造成软件数据上的前后不一致,请谨慎使用!");
                ucCurrencySelect1.Enabled = true;
                nudAmount.ReadOnly = false;
                nudAmount.Enabled = true;
                dateTimePickerEx1.ReadOnly = false;
                checkBox1.Enabled = false;
            }
        }

    }
}
