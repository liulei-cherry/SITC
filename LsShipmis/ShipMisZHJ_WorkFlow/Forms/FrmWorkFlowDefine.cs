using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Design;
using ShipMisZHJ_WorkFlow.UserControls;
using ShipMisZHJ_WorkFlow.Services;
using ShipMisZHJ_WorkFlow.BusinessClasses;

namespace ShipMisZHJ_WorkFlow.Forms
{
    public partial class FrmWorkFlowDefine : CommonViewer.BaseForm.FormBase
    {
        public FrmWorkFlowDefine()
        {
            InitializeComponent();
        }

        #region form siglton mode
        private static FrmWorkFlowDefine instance;

        public static FrmWorkFlowDefine Instance
        {
            get 
            {
                if (instance == null) instance = new FrmWorkFlowDefine();
                return FrmWorkFlowDefine.instance; 
            }
        }
        #endregion

        T_WorkFlow workFlow;
        bool drawline = false;

        #region workflowentrance
        public T_WorkFlow WorkFlow
        {
            get { return workFlow; }
            set 
            { 
                workFlow = value;
                IniWorkFlow(workFlow);
            }
        }

        private Dictionary<string, string> dictColumns = new Dictionary<string, string>();

        private void FrmWorkFlowDefine_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        private void FrmWorkFlowDefine_Load(object sender, EventArgs e)
        {
            dragControl.DesignMode(true);
            dragControl.MouseRightDown += new EventHandler(dragControl_MouseRightDown);
            dragControl.DragFinished += new EventHandler(dragControl_DragFinished);
            dragControl.MouseLeftDown += new EventHandler(dragControl_MouseLeftDown);
            setGridShortCutBtn();
            loadData();
            loadWorkDataCol();
        }

        void dragControl_DragFinished(object sender, EventArgs e)
        {
            panel.Refresh();
        }

        private void loadData()
        {
            string err = "";
            DataTable dt = T_WorkFlow_EntranceService.Instance.getInfoOrder(out err);
            ucDataGridView.DataSource = dt;
        }

        /// <summary>
        /// 设置界面上的网格的一些常用的快捷菜单的事件处理，.
        /// </summary>
        private void setGridShortCutBtn()
        {
            ucDataGridView.adding = adding;
            ucDataGridView.editing = editing;
            ucDataGridView.deleting = deleting;
        }
        private void adding()
        {
            btnAdd_Click(null,null);
        }
        private void editing()
        {
            btnEdit_Click(null, null);
        }
        private void deleting()
        {
            btnDelete_Click(null, null);
        }
        /// <summary>
        /// 信息列项.
        /// </summary>
        private void loadWorkDataCol()
        {
            //设置列标题.
            dictColumns.Clear();
            dictColumns.Add("WorkFlow_Name", "流程名");
            ucDataGridView.SetDgvGridColumns(dictColumns);
            ucDataGridView.Columns["WorkFlow_Name"].Width = 300;
        }

        void dragControl_MouseRightDown(object sender, EventArgs e)
        {
            UCNode node = (UCNode)sender;
            FrmPosiSelect frm = new FrmPosiSelect();
            frm.Node = node;
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            AddNewDept();
        }

        private void AddNewDept()
        {
           
            UCNode unode = new UCNode();
            unode.Parent = panel;
            unode.Top = 100;
            dragControl.DesignMode(false);
            unode.Left = 100;
            dragControl.DesignMode(true);
            nodes.Add(unode);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string err = "";
            FrmFlowAddEdit frm = new FrmFlowAddEdit();
            frm.ShowDialog();
            if(frm.Entrance!=null)
                WorkFlow = T_WorkFlowService.Instance.getObject(frm.Entrance.WorkFlow_Id, out err);
            loadData();
            //ucDataGridView.CurrentCell = ucDataGridView.Rows[ucDataGridView.Rows.Count-1].Cells["WorkFlow_Name"];
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void Edit()
        {
            DataGridViewRow dr = ucDataGridView.CurrentRow;
            
            string err = "";
            if (dr != null)
            {
                int rowIndex = dr.Index;
                int colIndex = ucDataGridView.CurrentCell.ColumnIndex;
                T_WorkFlow_Entrance we = T_WorkFlow_EntranceService.Instance.getObject(dr);
                FrmFlowAddEdit frm = new FrmFlowAddEdit(we);
                frm.ShowDialog();
                
                if (workFlow == null || workFlow.WorkFlow_Id != dr.Cells["WorkFlow_Id"].Value.ToString())
                {
                    WorkFlow = T_WorkFlowService.Instance.getObject(frm.Entrance.WorkFlow_Id, out err);
                }
                loadData();
                ucDataGridView.CurrentCell = ucDataGridView.Rows[rowIndex].Cells[colIndex]; 
            }
        }

        private void ucDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Edit();
        }

        private void ucDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
        #endregion

        #region workflow
        private Color color;
        private List<UCNode> nodes = new List<UCNode>();
        private List<UcLine> lines = new List<UcLine>();

        private void IniWorkFlow(T_WorkFlow workFlow)
        {
            //先拆分字符串.
            if (nodes.Count > 0)
            {
                foreach (UCNode node in nodes)
                {
                    node.Parent = null;
                    node.Visible = false;
                }
                nodes.Clear();
                lines.Clear();
                GC.Collect();
            }

            if (workFlow == null) workFlow = new T_WorkFlow();
            string[] oNode = workFlow.WorkFlow.Split(',');
            for(int i=0;i<oNode.Length;i++)
            {
                UCNode  node= new UCNode(oNode[i]);

                #region came from and pass to
                if (i >= 1)
                {
                    node.CameFrom =oNode[i - 1];
                }
                
                if (i < oNode.Length - 1)
                {
                    node.PassTo = oNode[i + 1];
                }
                #endregion

                nodes.Add(node);
            }

            showNodes(nodes);
        }

        //显示所有的节点信息.
        private void showNodes(List<UCNode> nodes)
        {
            dragControl.DesignMode(false);
            int x = panel.Width / 2;
            int detay = 100;
            int i = 0;
            foreach (UCNode node in nodes)
            {
                node.Parent = panel;
                node.Left = x-node.Width/2;
                node.Top = panel.Top + 50 + i * detay;
                i++;
            }
            dragControl.DesignMode(true);

            panel.Refresh();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            dragControl.DesignMode(false);
            dragControl.DesignMode(false);
            drawline = true;
            color = Color.Black;
        }
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            color = Color.Red;
            dragControl.DesignMode(false);
        }
       
        private void panel_Paint(object sender, PaintEventArgs e)
        {
            color = Color.Black;
            if (nodes.Count == 0) return;
            Graphics g = e.Graphics;
            List<Point[]> Lpoints= makePassPoints();
            lines.Clear();
            if (Lpoints == null) return;
            foreach (Point[] points in Lpoints)
            {
                for (int j = 0; j < points.Length - 1; j++)
                {
                    if (j + 1 < points.Length)
                    {
                        UcLine line = new UcLine(panel, color);
                        line.X = points[j];
                        line.Y = points[j + 1];
                        line.draw();
                        lines.Add(line);
                    }

                }
            }

        }

        private List<Point[]> makePassPoints()
        {
            List<Point[]> points = new List<Point[]>();

            //先计算有多少个线段,以及长度.
            int n = 0; //每个片段的长度.
            List<int> sp = new List<int>();

            //节点重新排序.
            resort(nodes);

            for (int k = 0; k < nodes.Count ; k++)
            {
                if (!string.IsNullOrEmpty(nodes[k].PassTo))
                {
                    n++;
                }
                else
                {
                    if(n>0) sp.Add(n);
                    n = 0;
                }
            }

            //初始化数组.
            foreach (int s in sp)
            {
                points.Add(new Point[s+1]);
            }

            int length = 0;
            foreach (Point[] p in points)
            {
                length += p.Length;
            }

            Point[] tolp = new Point[length];
            int i = 0;
            foreach (UCNode node in nodes)
            { 
                if ( ((!string.IsNullOrEmpty(node.CameFrom)) || !string.IsNullOrEmpty(node.PassTo)) && i<tolp.Length)
                {
                    tolp[i] = new Point(node.Left + node.Width / 2, node.Top + node.Height / 2);
                    i++;
                }
            }
            int mmn = 0;
            for (int b = 0; b < points.Count; b++)
            {
                for (int c = 0; c < points[b].Length; c++)
                {
                    points[b][c] = tolp[mmn];
                    mmn++;
                }
            }

            return points;
        }

        /// <summary>
        /// 节点重新排序.
        /// </summary>
        /// <param name="nodes"></param>
        private void resort(List<UCNode> nodes)
        {
            if (nodes.Count == 0) return;
            List<UCNode> tmpNodes = new List<UCNode>();
            List<UCNode> startNodes = new List<UCNode>();

            //先获取所有的起始节点.
            foreach (UCNode node in nodes)
            {
                if (string.IsNullOrEmpty(node.CameFrom)) startNodes.Add(node);
            }

            foreach (UCNode node in startNodes)
            {
                tmpNodes.Add(node);
                AddSubNode(tmpNodes, node);
            }
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i] = tmpNodes[i];
            }
        }

        private void AddSubNode(List<UCNode> tmpNodes, UCNode node)
        {
            foreach (UCNode onode in nodes)
            {
                if (node.PostType != null && onode.CameFrom == node.PostType)
                {
                    tmpNodes.Add(onode);
                    AddSubNode(tmpNodes, onode);
                }
            }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            dragControl.DesignMode(true);
            drawline = false;
        }

        #endregion

        private UcLine getObj(Point pt)
        {
            UcLine line = GetLineAtPoint(pt);
            return line;
        }

        private UcLine GetLineAtPoint(Point pt)
        {
            foreach (UcLine line in lines)
            {
                if (PointOnline(line.X, line.Y, pt))
                {
                    return line;
                }
            }
            return null;
        }

        private bool PointOnline(Point point1,Point point2,Point point)
        {
            if (System.Math.Abs(distance(point1, point2) - distance(point1, point) - distance(point2, point)) <= 0.05)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private double distance(Point p1, Point p2)
        {
            int x = System.Math.Abs(p1.X - p2.X);
            int y = System.Math.Abs(p1.Y - p2.Y);
            return Math.Sqrt(x * x + y * y);
        }

        #region mouse event

        Point tmpStart;
        UCNode fromNode;
        UCNode toNode;
        void dragControl_MouseLeftDown(object sender, EventArgs e)
        {
            if (sender != null && sender.GetType() == typeof(UCNode))
            {
                UCNode node=(UCNode)sender;
                toolDelete.Tag = node;
                if (drawline && checkNode(node) && string.IsNullOrEmpty(node.PassTo))
                {
                    tmpStart = new Point(node.Left + node.Width / 2, node.Top + node.Height / 2);
                    fromNode = node;
                }
            }
        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && tmpStart != null && drawline) //划临时线.
            {
                Point nowPoint = new Point(e.X, e.Y);
                Graphics g = panel.CreateGraphics();
                panel.Refresh();
                g.DrawLine(new Pen(color, 1), tmpStart, nowPoint);
            }

            Point p = new Point(e.X, e.Y);
            UcLine line = getObj(p);
            if (line != null)
            {
                Cursor.Current = Cursors.Cross;
            }
        }

        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            Point p=new Point(e.X,e.Y);
            Control col=panel.GetChildAtPoint(p);
            if (col != null && col.GetType() == typeof(UCNode))
            {
                UCNode node = (UCNode)col;
                if (drawline && checkNode(node) && string.IsNullOrEmpty(node.CameFrom))
                {
                    toNode = node;
                    toNode.CameFrom = fromNode.PostType;
                    fromNode.PassTo = toNode.PostType;
                    fromNode = null;
                    toNode = null;
                }
            }
        }

        private void panel_MouseClick(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            UcLine line = getObj(p);
            if (line != null)
            {
                foreach (UcLine l in lines)
                {
                    l.releaseFocus();
                }
                toolDelete.Tag = line;
                panel.Refresh();
                line.SetFocus();
            }
        }

        #endregion

        private bool checkNode(UCNode node)
        {
            if (string.IsNullOrEmpty(node.PostType) || node.PostType.Length < 0)
            {
                MessageBox.Show("请先选择要审核的部门");
                return false;
            }
            return true;

        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            if (toolDelete.Tag == null) return;
            deleteObj(toolDelete.Tag);
            toolDelete.Tag = null;

        }

        private void deleteObj(object obj)
        {
            if (obj.GetType() == typeof(UcLine))
            {
                if (MessageBox.Show("是否删除选定的连线?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) deleteLine((UcLine)toolDelete.Tag);
            }
            else if(obj.GetType()==typeof(UCNode))
            {
                if (MessageBox.Show("是否删除选定的审核节点?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) deleteNode((UCNode)toolDelete.Tag);
            }
        }

        /// <summary>
        /// 删除节点.
        /// </summary>
        /// <param name="uCNode"></param>
        private void deleteNode(UCNode node)
        {
            UcLine line1;
            UcLine line2;
            findLineByNode(node,out line1, out line2);
            if (line2 != null)  deleteNextNodeFrom(line2); //需要删除下一个节点的来源.
            if (line1 != null) deleteForNodeTo(line1); //删除前一个节点的节点去向.
            nodes.Remove(node);
            node.Parent = null;
            node = null;
            panel.Refresh();
            GC.Collect();
        }

        /// <summary>
        /// 删除连线.
        /// </summary>
        /// <param name="ucLine"></param>
        private void deleteLine(UcLine line)
        {
            UCNode node1;
            UCNode node2;

            fineNodesByLine(line, out node1, out node2);
            node1.PassTo = null;
            node2.CameFrom = null;
            lines.Remove(line);
            line = null;
            panel.Refresh();
            GC.Collect();
        }

        private void deleteForNodeTo(UcLine line1)
        {
            UCNode from;
            UCNode to;
            fineNodesByLine(line1, out from, out to);
            from.PassTo = null;
        }

        private void deleteNextNodeFrom(UcLine line2)
        {
            UCNode from;
            UCNode to;
            fineNodesByLine(line2, out from, out to);
            to.CameFrom = null;
        }

        private void findLineByNode(UCNode node, out UcLine line1, out UcLine line2)
        {
            Point p = new Point(node.Left + node.Width / 2, node.Top + node.Height / 2);
            line1 = null;
            line2 = null;
            foreach (UcLine line in lines)
            {
                if (distance(line.X ,p)<=3) line2 = line;
                if (distance(line.Y ,p)<=3) line1 = line;
            }
        }

        private void fineNodesByLine(UcLine line,out UCNode node1, out UCNode node2)
        {
            node1 = null;
            node2 = null;
            foreach (UCNode node in nodes)
            {
                Point p = new Point(node.Left + node.Width / 2, node.Top + node.Height / 2);
                if (p == line.X) node1 = node;
                if (p == line.Y) node2 = node;
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (check())
            {
                save();
            }
        }

        private void save()
        {
            string flowStr = "";
            foreach (UCNode node in nodes)
            {
                if (flowStr.Length > 0) flowStr += ",";
                flowStr += node.PostType;
            }
            string err = "";
            workFlow.WorkFlow = flowStr;
            T_WorkFlowService.Instance.saveUnit(workFlow,out err);
            if (err.Equals(""))
            {
                MessageBox.Show("保存成功");
            }
            else
            {
                MessageBox.Show(err);
            }
        }

        private bool check()
        {
            if (nodes.Count != lines.Count + 1)
            {
                MessageBox.Show("请定义好流程后再保存");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ucDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string err = "";
            
            if (e.RowIndex>=0)
            {
                DataGridViewRow dr = this.ucDataGridView.Rows[e.RowIndex];
                if (workFlow == null || workFlow.WorkFlow_Id != dr.Cells["WorkFlow_Id"].Value.ToString())
                {

                    WorkFlow = T_WorkFlowService.Instance.getObject(dr.Cells["WorkFlow_Id"].Value.ToString(), out err);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = ucDataGridView.CurrentRow;
            if (dr != null && dr.Index >= 0)
            {
                if (MessageBox.Show("是否确认要删除选中的流程?", "confirm information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string err = "";
                    T_WorkFlow_Entrance ent=T_WorkFlow_EntranceService.Instance.getObject(dr);
                    T_WorkFlowService.Instance.deleteUnit(ent.WorkFlow_Id, out err);
                    T_WorkFlow_EntranceService.Instance.deleteUnit(ent, out err);
                    loadData();
                }
            }
        }

    }
}