using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CommonViewer.BaseForm
{
    public partial class frmColumnSet : CommonViewer.BaseForm.FormBase
    {
        public frmColumnSet()
        {
            InitializeComponent();
        }
        public DataGridView dgv;
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewColumn column;
            if (dgv != null)
            {
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    dgv.Columns[i].Visible = false;
                }
            }
            for (int i = 0; i < tv.Nodes.Count; i++)
            {
                column = (DataGridViewColumn)tv.Nodes[i].Tag;
                column.Visible = tv.Nodes[i].Checked;
            }
            Close();
        }

        private void frmColumnSet_Load(object sender, EventArgs e)
        {
            if (dgv == null) return;
            TreeNode node;
            DataGridViewColumn column;
            DataGridViewColumn tmpcol;

            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    tmpcol = dgv.Columns[j];
                    if (tmpcol.DisplayIndex == i)
                    {
                        column = dgv.Columns[j];
                        if (column.Tag == null || (int)(column.Tag) != 0) //不显示的隐藏列初始化为tag＝0
                        {
                            node = new TreeNode(column.HeaderText);
                            node.Tag = column;
                            node.Checked = column.Visible;
                            tv.Nodes.Add(node);
                        }
                    }
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tv.Nodes.Count; i++)
            {
                tv.Nodes[i].Checked = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tv.Nodes.Count; i++)
            {
                tv.Nodes[i].Checked = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tv.Nodes.Count; i++)
            {
                tv.Nodes[i].Checked = !tv.Nodes[i].Checked;
            }
        }
    }
}