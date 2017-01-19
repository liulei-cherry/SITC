using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Maintenance.Viewer
{
    public partial class FrmTaskDetail : CommonViewer.BaseForm.FormBase
    {
        public FrmTaskDetail()
        {
            InitializeComponent();
        }

        private  string taskid;
        private static FrmTaskDetail ftd;
        public string Taskid
        {
            get { return taskid; }
            set
            {
                if (value == null)
                    return;
                if (taskid == null||ftd.Taskid!=value)
                {
                    taskid = value;
                    ucWorkOrder.TaskId = value;
                }
            }
        }
        
        public static FrmTaskDetail GetFtdForm()
        {
            if (ftd == null)
            {
                ftd = new FrmTaskDetail();
            }
            return ftd;
        }

        private void FrmTaskDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            ftd = null;
        }
    }
}