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
    public partial class FrmCompleteDisannul : CommonViewer.BaseForm.FormBase
    {
        #region 窗体单实例模型
        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmCompleteDisannul instance = new FrmCompleteDisannul();
        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmCompleteDisannul Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmCompleteDisannul.instance = new FrmCompleteDisannul();
                }

                return FrmCompleteDisannul.instance;
            }
        }
        private FrmCompleteDisannul()
        {
            InitializeComponent();
        }
        #endregion
        private ShipRepairProject srp = null;
        private ShipRepairEvent sre = null;
        private ShipRunningRepairRelation srr = null;
        public FrmCompleteDisannul(string paramRepairID, string paramProjectID, string paramRunningRepairRelationID)
        {
            string err;
            InitializeComponent();
            srp = ShipRepairProjectService.Instance.getObject(paramProjectID, out err);
            sre = ShipRepairEventService.Instance.getObject(paramRepairID, out err);
            srr = ShipRunningRepairRelationService.Instance.getObject(paramRunningRepairRelationID, out err);
            txtREMARK.Text = srr.REMARK;
        }
        private void bdNgDis_Click(object sender, EventArgs e)
        {
            srp.PROJECTSTATE = 7;
            srp.SERVICEPROVIDER = "";
            srr.STATE = 2;
            srr.REMARK = txtREMARK.Text.Trim();
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

        private void FrmCompleteDisannul_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

    }
}
