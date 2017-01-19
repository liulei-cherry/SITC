using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BaseInfo.DataAccess;
using SAPFunction.Services;

namespace SAPFunction.Viewer
{
    public partial class UcSupplierSelect : CommonViewer.BaseControl.ComboxEx
    {
        public UcSupplierSelect()
        {
            InitializeComponent();
            Change("");
        }

        public UcSupplierSelect(string componentId)
        {
            InitializeComponent();
            Change(componentId);
        }
        public void Change(string componentId)
        {
            string err;
            DataTable dt;
            if (!SupplierMappingService.Instance.GetSupplierSelect(out dt, out err))
                return;
            Init(dt, "MANUFACTURER_ID", "MANUFACTURER_NAME", true, false, "", null, false);
        }
        protected override void OnLeave(EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Text.Trim()))
                this.Focus();
        }
    }
}
