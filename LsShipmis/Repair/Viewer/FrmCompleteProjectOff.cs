using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Repair.DataObject;
using Repair.Services;
using CommonOperation.Functions;
using CommonViewer.BaseControl;

namespace Repair.Viewer
{
    public partial class FrmCompleteProjectOff : CommonViewer.BaseForm.FormBase
    {
        #region 窗体单实例模型
        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmCompleteProjectOff instance = new FrmCompleteProjectOff();
        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmCompleteProjectOff Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmCompleteProjectOff.instance = new FrmCompleteProjectOff();
                }

                return FrmCompleteProjectOff.instance;
            }
        }
        private FrmCompleteProjectOff()
        {
            InitializeComponent();
        }
        #endregion
        private ShipRepairProject srp = null;
        private ShipRepairEvent sre = null;
        private ShipRunningRepairRelation srr = null;
        public FrmCompleteProjectOff(string paramRepairID, string paramProjectID, string paramRunningRepairRelationID)
        {
            string err;
            InitializeComponent();
            srp = ShipRepairProjectService.Instance.getObject(paramProjectID, out err);
            sre = ShipRepairEventService.Instance.getObject(paramRepairID, out err);
            srr = ShipRunningRepairRelationService.Instance.getObject(paramRunningRepairRelationID, out err);
            txtREMARK.Text = srp.REMARK;
        }
        private void bdNgDis_Click(object sender, EventArgs e)
        {
            srp.PROJECTSTATE = 10;
            srp.SERVICEPROVIDER = "";
            srp.REMARK = txtREMARK.Text.Trim();
            srr.STATE = 4;
            srr.REMARK += ("\r\n" + txtREMARK.Text.Trim());
            string err;
            using (TransactionClass tc = new TransactionClass())
            {
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
            this.Close();
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

        private void FrmCompleteProjectOff_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

    }
}
