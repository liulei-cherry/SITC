using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonViewer.BaseForm;
using CMSManage.DataObject;
using CommonViewer.BaseControl;
using CMSManage.Services;

namespace CMSManage.Viewer
{
    public partial class FrmCMSCheckAddFlaw : FormBase
    {
        CMSCheckLog cmsCheckLog;
        List<string> checkIds;
        private FrmCMSCheckAddFlaw()
        {
            InitializeComponent();
        }
        public FrmCMSCheckAddFlaw(CMSCheckLog cmsCheckLog,List<string> checkIds)
        {
            InitializeComponent();
            this.cmsCheckLog = cmsCheckLog;
            this.checkIds = checkIds;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            //是否都填写了内容,都是必填的;
            DateTime dt = dateTimePickerEx1.Value;
            if (dt < DateTime.Today)
            {
                MessageBoxEx.Show("日期填入无效,预计整改时间不能填写今天以前的时间!");
                dateTimePickerEx1.Value = DateTime.Today.AddDays(1);
                dateTimePickerEx1.Select();
                return;
            }
            string opinion = txtOpinion.Text.Trim();
            if (opinion.Length == 0)
            {
                MessageBoxEx.Show("整改意见必须填写!");
                txtOpinion.Focus();
                return;
            }
            string err;
            if (CMSRectifyService.Instance.SetFlawToCMSChecks(cmsCheckLog, checkIds, dt, opinion, out err))
            {
                MessageBoxEx.Show("处理完毕");
                this.Close();
            }
            else
            {
                MessageBoxEx.Show("处理失败,错误原因为:\r" + err);
            }
        }
    }
}
