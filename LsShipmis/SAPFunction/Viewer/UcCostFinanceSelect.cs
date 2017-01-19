using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SAPFunction.Services;

namespace SAPFunction.Viewer
{
    public partial class UcCostFinanceSelect : CommonViewer.BaseControl.ComboxEx
    {
        public UcCostFinanceSelect()
        {
            InitializeComponent();
            ChangeShip("");
        }
        public UcCostFinanceSelect(string componentId)
        {
            InitializeComponent();
            ChangeShip(componentId);
        }
        public void ChangeShip(string componentId)
        {
            DataTable dt;
            string err;
            if (!MaterialMappingService.Instance.GetCostFinance(out dt, out err))
                return;
            Init(dt, "COST_FINANCE", "COST_FINANCE", true, false, "", null, true);
        }
    }
}
