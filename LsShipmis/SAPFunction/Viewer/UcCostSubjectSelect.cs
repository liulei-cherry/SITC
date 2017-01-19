using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SAPFunction.Services;
using Cost.Services;

namespace SAPFunction.Viewer
{
    public partial class UcCostSubjectSelect : CommonViewer.BaseControl.ComboxEx
    {
        public UcCostSubjectSelect()
        {
            InitializeComponent(); 
            DataTable dt;
            dt = AccountService.Instance.GetTreeSubjects();
            Init(dt, "NODE_ID", "path", true, false, "", null, false);
        } 
    }
}
