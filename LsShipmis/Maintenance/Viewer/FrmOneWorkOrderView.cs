using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonViewer.BaseForm;
using Maintenance.DataObject;

namespace Maintenance.Viewer
{
    public partial class FrmOneWorkOrderView : FormBase
    {
        public FrmOneWorkOrderView()
        {
            InitializeComponent();
        }
        public FrmOneWorkOrderView(WorkOrder toViewWorkOrder)
        {
            ucWorkOrder1.ThisWorkOrder = toViewWorkOrder;
        }
        public FrmOneWorkOrderView(string toViewWorkOrderId)
        {
            ucWorkOrder1.TaskId = toViewWorkOrderId;
        }
    }
}
