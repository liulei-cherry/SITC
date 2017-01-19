using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ShipMisZHJ_WorkFlow.BusinessClasses;
using ShipMisZHJ_WorkFlow.Services;
using BaseInfo.Objects;
using BaseInfo.DataAccess;

namespace ShipMisZHJ_WorkFlow.Forms
{
    public partial class FrmDeptSelect : Form
    {
        public FrmDeptSelect()
        {
            InitializeComponent();
            ucDepart.nodeSelect += new EventHandler(ucDepart_nodeSelect);
        }

        Department dept;

        public Department Dept
        {
            get { return dept; }
            set { dept = value; }
        }

        void ucDepart_nodeSelect(object sender, EventArgs e)
        {
            string err = "";
            TreeViewEventArgs le = (TreeViewEventArgs)e;
            string deptId = le.Node.Tag.ToString();
            if (deptId.Length == 36)
            {
                dept = DepartmentService.Instance.getObject(deptId, out err);
            }
            else
            {
                dept = null;
            }
        }

        private void FrmDeptSelect_Load(object sender, EventArgs e)
        {
            ucDepart.Depart_Load();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dept = null;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}