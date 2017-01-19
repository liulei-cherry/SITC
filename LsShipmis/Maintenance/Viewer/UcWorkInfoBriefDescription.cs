using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms; 
using Maintenance.DataObject;
using Maintenance.Services;

namespace Maintenance.Viewer
{
    public partial class UcWorkInfoBriefDescription : UserControl
    {
        public UcWorkInfoBriefDescription()
        {
            InitializeComponent();
        }
        private Maintenance.DataObject.WorkInfo workInfo;

        public Maintenance.DataObject.WorkInfo WorkInfo
        {
            get
            {
                return workInfo;
            }
            set
            {
                workInfo = value;
                if (workInfo != null)
                {
                    showWorkInfo();
                }
            }
        }
        private void showWorkInfo()
        {
            DataTable dtb = WorkInfoService.Instance.GetABrifWorkInfoById(workInfo.WORKINFOID);
            if (dtb == null || dtb.Rows.Count != 1)
            {
                return;
            }
            DataRow row = dtb.Rows[0];
            txtWkName.Text = workInfo.WORKINFONAME;
            txtRemark.Text = workInfo.WORKINFODETAIL;
            txtPHeadship.Text = row["principalPost"].ToString();
            txtHeadship.Text = row["SupervisorPost"].ToString();
            txtWkInfo.Text = row["WorkInfoState"].ToString();
        }

        public string GroupBoxText
        {
            set
            {
                this.groupBox1.Text = value;
            }
        }

    }
}
