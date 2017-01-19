using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Maintenance.DataObject;
using Maintenance.Services;

namespace Maintenance.Viewer
{
    public partial class FrmFinishedWorkOrderView : CommonViewer.BaseForm.FormBase
    {
        public FrmFinishedWorkOrderView(Maintenance.DataObject.WorkInfo order)
        {
            InitializeComponent();
            dt= WorkOrderService.Instance.getFinishedWorkerInfo(order);
            filldata();
        }

        private Dictionary<string, string> dictColumns = new Dictionary<string, string>();
        DataTable dt;
        private void filldata()
        {
            ucView.DataSource = dt;
            //设置列标题.
            dictColumns.Clear();
            dictColumns.Add("workordername", "工单名称");
            dictColumns.Add("state", "完成情况");
            dictColumns.Add("planexedate", "预计执行日期");
            dictColumns.Add("completeddate", "完工日期");
            dictColumns.Add("circlefrontlimitdate", "前允差日期");
            dictColumns.Add("circlebacklimitdate", "后允差日期");
            dictColumns.Add("nextvalue", "预计执行表值");
            dictColumns.Add("excutevalue", "实际执行表值");
            dictColumns.Add("timingfrontlimithours", "前允差小时数");
            dictColumns.Add("timingbacklimithours", "后允差小时数");
            dictColumns.Add("workexecutor", "执行人");
            dictColumns.Add("workconfirmor", "确认人");
            dictColumns.Add("workcompletedinfo", "完工情况说明");
            dictColumns.Add("CREATEDATE", "填写时间");
            ucView.SetDgvGridColumns(dictColumns);
        }
    }
}