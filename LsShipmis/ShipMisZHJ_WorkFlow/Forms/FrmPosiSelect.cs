using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ShipMisZHJ_WorkFlow.UserControls;
using ShipMisZHJ_WorkFlow.Services;
using BaseInfo.DataAccess;

namespace ShipMisZHJ_WorkFlow.Forms
{
    public partial class FrmPosiSelect : CommonViewer.BaseForm.FormBase
    {
        public FrmPosiSelect()
        {
            InitializeComponent();
        }

        private UCNode node;

        public UCNode Node
        {
            get { return node; }
            set { node = value; }
        }

        private void FrmPosiSelect_Load(object sender, EventArgs e)
        {
            ucDepart.nodeSelect += new EventHandler(ucDepart_nodeSelect);
            ucDepart.Depart_Load();
            if (node != null && node.PostType!=null)
            {
                ucDepart.locate(node.PostType);
            }
        }

        void ucDepart_nodeSelect(object sender, EventArgs e)
        {
            string err = "";
            TreeViewEventArgs le = (TreeViewEventArgs)e;
            string deptId= le.Node.Tag.ToString();

            this.dgvPost.DataSource = PostService.Instance.getPostTypes(deptId, out err);

            dgvPost.Columns["PostType"].Visible = false;
            dgvPost.Columns["PostName"].Width = 150;
            dgvPost.Columns["PostHeader"].Width =300;
            dgvPost.Columns["PostName"].HeaderText = "岗位";
            dgvPost.Columns["PostHeader"].HeaderText = "是否为部门负责人";
            if (node != null && node.PostType != null)
            {
                foreach (DataGridViewRow row in dgvPost.Rows)
                {
                    if (node.PostType.EndsWith(row.Cells["PostType"].Value.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        dgvPost.CurrentCell = row.Cells["PostName"];
                        break;
                    }
                }
            }
        }

        private void bdNgClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            selectPosi();
        }

        private void selectPosi()
        {
            if (dgvPost.CurrentRow != null)
            {
                string post = dgvPost.CurrentRow.Cells["PostType"].Value.ToString();
                node.PostType = post;
                Close();
            }
        }

        private void dgvPost_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectPosi();
        }

    }
}
