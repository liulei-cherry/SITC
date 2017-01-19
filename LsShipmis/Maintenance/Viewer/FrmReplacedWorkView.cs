using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Maintenance.Services;
using Maintenance.DataObject; 

namespace Maintenance.Viewer
{
    public partial class FrmReplacedWorkView : CommonViewer.BaseForm.FormBase
    {
        private  FrmReplacedWorkView()
        {
            InitializeComponent();
        }
        public FrmReplacedWorkView(WorkOrder theWorkOrder)
        {
            InitializeComponent();
            loadReplacedWrok(theWorkOrder);
        }
        /// <summary>
        /// 加载被本工作替代的工作信息.
        /// </summary>
        /// <param name="workInfoHistory"></param>
        private void loadReplacedWrok(WorkOrder theWorkOrder)
        {
            DataTable dt = WorkOrderService.Instance.getReplacedWorkFor(theWorkOrder.GetId ());
            if (dt == null) return;
            dataGridView.DataSource = dt;
            dataGridView.LoadGridView("FrmReplacedWorkView.dataGridView");
            setColumns();
        }

        private void setColumns()
        { 
            Dictionary<string,string> dicColumns = new Dictionary<string,string> ();  
            dicColumns.Add ( "workordername", "工单名称");
            dicColumns.Add ( "workorderstate", "工单状态");
            dicColumns.Add (  "workdescription", "工单描述");
            dataGridView.SetDgvGridColumns(dicColumns);
        }
      
        private void FrmReplacedWorkView_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataGridView.SaveGridView("FrmReplacedWorkView.dataGridView");
        }

        private void dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataRow dr = ((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
            string err;
            WorkOrder workOrder = WorkOrderService.Instance.getObject(dr["workorderid"].ToString(), out err);
            ucWorkOrder1.ThisWorkOrder = workOrder; 
        }

        private void FrmReplacedWorkView_Load(object sender, EventArgs e)
        {

        }
    }
}