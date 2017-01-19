using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms; 
using ItemsManage.DataObject;
using ItemsManage.Services;
using CommonViewer.BaseControlService;
using Maintenance.DataObject;
using Maintenance.Services;

namespace Maintenance.Viewer
{
    public partial class FrmComponentWorkList : CommonViewer.BaseForm.FormBase
    {
        public FrmComponentWorkList(ComponentUnit component)
        {
            InitializeComponent();
            unit = component;
        }
        ComponentUnit unit;

        private void FrmComponentWorkList_Load(object sender, EventArgs e)
        {
            datHistory.DataSource = ComponentUnitService.Instance.getComponentWorkHistory(unit);
            foreach (DataGridViewColumn col in datHistory.Columns)
            {
                col.Visible = false;
                col.Tag = 0;
            }
            datHistory.Columns["workordername"].Visible = true;
            datHistory.Columns["workordername"].HeaderText = "工作名称";
            datHistory.Columns["workorderstatename"].Visible = true;
            datHistory.Columns["workorderstatename"].HeaderText = "状态";
            datHistory.Columns["principalpostname"].Visible = true;
            datHistory.Columns["principalpostname"].HeaderText = "责任岗位";           
            datHistory.Columns["workexecutor"].Visible = true;
            datHistory.Columns["workexecutor"].HeaderText = "完成人";
            datHistory.Columns["completeddate"].Visible = true;
            datHistory.Columns["completeddate"].HeaderText = "完成时间";
            DataGridViewExt.loadGridView(datHistory, CommonOperation.ConstParameter.UserId, "FrmComponentWorkList");
        }

        private void setCol(string colName, string caption)
        {
            datHistory.Columns[colName].HeaderText = caption;
            datHistory.Columns[colName].Visible = true;
            datHistory.Columns[colName].Tag = null;
        }

        private void FrmComponentWorkList_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataGridViewExt.saveGridView(datHistory, CommonOperation.ConstParameter.UserId, "FrmComponentWorkList");

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void datHistory_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(datHistory.DataSource==null || e.RowIndex<0) return;
            string workHistoryId = datHistory.Rows[e.RowIndex].Cells["workorderid"].Value.ToString();
            string err;
            WorkOrder ex = WorkOrderService.Instance.getObject(workHistoryId,out err);
            ucWorkInfoHistoryView.ThisWorkOrder=ex;
        }

    }
}