/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：DragTreeViewEx.cs
 * 创 建 人：徐正本
 * 创建时间：2011年4月13日
 * 标    题：可拖拽通用树控件
 * 功能描述：继承于 TreeView 扩展了通用拖拽功能的树控件
 * 修 改 人：徐正本 
 * 修改时间：2011年4月28日
 * 修改内容：增加拖拽时,悬停在最顶端或最低端时,可以自动实现向上或者向下滚动
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace CommonViewer
{
    /// <summary>
    /// 拖拽的释放类型,就是把一个元素拖拽到树形上以后,
    /// 相应点是有意义区域还是无意义区域.
    /// </summary>
    internal enum DropType
    {
        NOTHING = 0,//无意义区域,通常是空白位置.
        OVER = 1,//在某个节点上,相当于拖到某节点下级时的状态.
        FRONT = 2,//在某个节点之前,相当于拖到某节点的同级前一个位置.
        AFTER = 3,//在某个节点之后,相当于拖到某节点的同级后一个位置.
    }
    /// <summary>
    /// 为了拖拽而扩展的树控件.
    /// 可以上下级拖拽,
    /// 可以同级排序,
    /// 可以可视部分有效性判断,
    /// 可以调用外部委托实现存储层或业务层的其它业务.
    /// </summary>
    public partial class DragTreeViewEx : TreeView
    {
        #region 委托区域
        /// <summary>
        /// 外部调用委托,在显示效果处理后,同样可以在数据层进行相应处理.
        /// 这个委托的参数object需要在重写后进行赋值,直接使用的话需要做一个转换NodeToObject
        /// </summary>
        /// <param name="toInsertItem">要移动的元素</param>
        /// <param name="aimItem">要移动到的父级节点</param>
        /// <param name="position">移动后排序位置</param>
        /// <returns></returns>
        public delegate bool InsertIntoTreeView(object toInsertItem, TreeNode aimItem, int position);
        public InsertIntoTreeView insertIntoTreeView;
        /// <summary>
        /// 除了系统中可视部分判断是否可以拖拽以外,
        /// 支持另外由用户端判断是否可以拖拽,这样更有利用控件的通用性.
        /// </summary>
        /// <param name="toInsertItem"></param>
        /// <param name="aimItem"></param>
        /// <returns></returns>
        public delegate bool CanDropDown(object toInsertItem, TreeNode aimItem);
        public CanDropDown canDropDown;
        public delegate void NodeOperation(TreeNode tn);
        public NodeOperation reloading;//刷新.
        public NodeOperation expanding;//展开.
        public NodeOperation CustomItemDrag;//是否重新实现了拖拽开始.
        public delegate void DraggingFinish(bool ifSuccess);
        public event DraggingFinish draggingFinish;
        #endregion

        #region 构造函数
        List<Type> allCanDropType = new List<Type>();
        public DragTreeViewEx()
        {
            InitializeComponent();
            allCanDropType.Add(typeof(TreeNode));
        }

        public DragTreeViewEx(IContainer container)
            : this()
        {
            container.Add(this);
        }
        #endregion

        #region 与外部交互部分

        /// <summary>
        /// 可以打开或关闭拖拽功能.
        /// </summary>
        [Description("设置可以打开或关闭拖拽功能"), Category("自定义属性")]
        public bool AllowUserDrag { get; set; }

        /// <summary>
        /// 可以打开或关闭拖拽功能.
        /// </summary>
        [Description("设置可以打开或关闭拖拽排序功能,关闭则只可以拖动,不可以排序!"), Category("自定义属性")]
        public bool AllowUserSort { get; set; }

        public void InsertAnotherPermittedDropType(Type onePermittedDropType)
        {
            if (!allCanDropType.Contains(onePermittedDropType))
                allCanDropType.Add(onePermittedDropType);
        }

        #endregion

        #region 控件变量区域
        protected TreeNode lastRightClickNode = null;
        private DropType dropType = DropType.NOTHING;//拖拽的释放类型,默认是无意义释放.
        protected TreeNode lastOverNode = null;        //上一个拖上去的节点,默认是空,释放后同样设置为空,为了调节显示颜色用的.
        private int DrawLineX1, DrawLineX2, DrawLineY;//插入两个树节点中间时画横线的前后点x坐标及y坐标,由于是水平的,y只需要一个值.
        #endregion

        #region 拖动代码
        public TreeNode DragTreeNode = null;
        private void DragTreeViewEx_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DragTreeNode = (TreeNode)e.Item;
            if (DragTreeNode.IsExpanded) DragTreeNode.Collapse();
            if (CustomItemDrag != null && e.Item.GetType() == typeof(TreeNode))
            {
                CustomItemDrag(DragTreeNode);
            }
            else
            {
                if (AllowUserDrag) DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        /// <summary>
        /// 接收外来插入项,如果使用,一般都需要重载.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DragTreeViewEx_DragEnter(object sender, DragEventArgs e)
        {
            if (AllowDrop)
            {
                foreach (Type thePermittedType in allCanDropType)
                {
                    if (e.Data.GetDataPresent(thePermittedType))
                    {
                        e.Effect = DragDropEffects.All;
                        return;
                    }
                }
            }
            e.Effect = DragDropEffects.None;
        }

        /// <summary>
        /// 拖拽放下.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DragTreeViewEx_DragDrop(object sender, DragEventArgs e)
        {
            timer1.Stop();
            if (!AllowDrop)
            {
                DragTreeNode = null;
                return;
            }
            Point tempPosition = new Point(0, 0);
            if (lastOverNode != null) lastOverNode.BackColor = this.BackColor;
            lastOverNode = null;
            tempPosition.X = e.X;
            tempPosition.Y = e.Y;
            tempPosition = this.PointToClient(tempPosition);
            TreeNode aimNode = this.GetNodeAt(tempPosition);
            int position = 0;
            object dropNode = null;
            foreach (Type thePermittedType in allCanDropType)
            {
                if (e.Data.GetDataPresent(thePermittedType))
                {
                    dropNode = e.Data.GetData(thePermittedType);
                    break;
                }
            }
            if (aimNode != null)
            {
                //是否是拖到下级.
                if (dropType == DropType.OVER && candrop(dropNode, aimNode))
                {
                    position = aimNode.Nodes.Count;
                }
                //是否是拖到同级前后位置.
                else if ((dropType == DropType.FRONT || dropType == DropType.AFTER)
                    && candrop(dropNode, aimNode.Parent))
                {
                    //上级存在,则肯定放在上级下面,否则说明是根结点,放到根结点前后.
                    if (aimNode.Parent != null)
                    {
                        position = aimNode.Parent.Nodes.IndexOf(aimNode) + (dropType == DropType.FRONT ? 0 : 1);
                        aimNode = aimNode.Parent;
                    }
                    else
                    {
                        position = this.Nodes.IndexOf(aimNode) + (dropType == DropType.FRONT ? 0 : 1);
                        aimNode = null;
                    }
                }
                else
                {
                    DragTreeNode = null;
                    return;
                }
            }
            // 如果目标节点不存在，即拖拽的位置不存在节点，那么就将被拖拽节点放在根节点之下.
            else
            {
                position = this.Nodes.Count;
            }
            TreeNodeDragDrop(dropNode, aimNode, position);
            return;
        }

        private bool TreeNodeDragDrop(object dropNode, TreeNode aimNode, int position)
        {
            //把目标节点显示出来,并高亮.
            if (insertIntoTreeView != null)
            {
                if (!insertIntoTreeView(dropNode, aimNode, position))
                {
                    if (reloading != null && dropNode.GetType() == typeof(TreeNode)) reloading((TreeNode)dropNode);
                    if (draggingFinish != null) draggingFinish(false);
                    return false;
                }
                else if (dropNode.GetType() == typeof(TreeNode))
                {
                    doingDrop((TreeNode)dropNode, aimNode, position);
                }
                else
                {
                    if (DragTreeNode != null && DragTreeNode.Parent != null) reloading(DragTreeNode.Parent);
                    DragTreeNode = null;
                    reloading(aimNode);
                }
            }
            if (draggingFinish != null) draggingFinish(true);
            this.SelectedNode = aimNode;
            aimNode.Expand();
            return true;
        }

        /// <summary>
        /// 真正插入操作.
        /// </summary>
        /// <param name="dropNode">拖动要插入的节点</param>
        /// <param name="aimNode">目标上级节点,如果是空,则是根结点</param>
        /// <param name="position">插入的位置</param>
        private void doingDrop(TreeNode dropNode, TreeNode aimNode, int position)
        {
            TreeNode dragNodeTemp = dropNode;
            dropNode.Remove();
            if (aimNode == null)
            {
                this.Nodes.Insert(position, dragNodeTemp);
            }
            else
            {
                //为了避免出现两遍同一个节点,加入了此判断.
                if (aimNode != this.SelectedNode)
                    aimNode.Nodes.Insert(position, dragNodeTemp);
            }

        }

        /// <summary>
        /// 是否可以释放的判断.
        /// 首先判断显示效果,然后判断用户委托.
        /// 当拖拽节点是目标节点的上级时,不能放.
        /// </summary>
        /// <param name="dragitem">拖拽节点</param>
        /// <param name="aim">目标位置</param>
        /// <returns></returns>
        private bool candrop(object dragitem, TreeNode aim)
        {
            if (dragitem.GetType() == typeof(TreeNode))
            {
                TreeNode temp = aim;
                while (temp != null)
                {
                    if (temp != dragitem)
                        temp = temp.Parent;
                    else return false;
                }
            }
            if (canDropDown != null)
            {
                return canDropDown(dragitem, aim);
            }
            return true;
        }

        /// <summary>
        /// 悬停2秒的展开事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            if (expanding != null && lastOverNode != null && !lastOverNode.IsExpanded)
            {
                expanding(lastOverNode);
                lastOverNode.Expand();
            }
        }
        /// <summary>
        /// 拖拽过程中显示效果.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DragTreeViewEx_DragOver(object sender, DragEventArgs e)
        {
            if (!AllowDrop)
                return;
            Point tempPosition = new Point(0, 0);
            tempPosition.X = e.X;
            tempPosition.Y = e.Y;
            tempPosition = this.PointToClient(tempPosition);
            TreeNode overNode = this.GetNodeAt(tempPosition);
            #region 当拖拽到最顶部或者最底部15个像素以内,则自动触发滚动事件,除非滚动不了,则跳出
            if (tempPosition.Y <= 15)
            {
                //向上滚动,得到当前node,判断其前一个node是否存在,存在则给其前一个node赋值为当前值,并显示;
                if(overNode != null && overNode.PrevVisibleNode != null)
                {
                    this.SelectedNode = overNode.PrevVisibleNode;
                    return;
                }
            }
            else if (tempPosition.Y >= this.Height - 35) //45是因为还有可能有个横向滚动条.
            {
                //向下滚动,得到当前node,判断其后一个node是否存在,存在则给其后一个node赋值为当前值,并显示;
                if (overNode.NextVisibleNode != null)
                {
                    this.SelectedNode = overNode.NextVisibleNode;
                    return;
                }
            }
            #endregion
            #region 鼠标位置判断
            if (lastOverNode != overNode && overNode != null)
            {
                timer1.Stop();
                if (lastOverNode != null) lastOverNode.BackColor = this.BackColor;
                lastOverNode = overNode;
                if (!lastOverNode.IsExpanded) timer1.Start();
                dropType = DropType.NOTHING;
            }
            else if (lastOverNode != null)
            {
                dropType = DropType.OVER;
                if (AllowUserSort && lastOverNode.Bounds.Y + 4 > tempPosition.Y)
                {
                    if (dropType != DropType.FRONT)
                    {
                        DrawLineX1 = this.Indent * (lastOverNode.Level + 1) + 10;
                        DrawLineX2 = this.Width - 40;
                        DrawLineY = lastOverNode.Bounds.Y + 1;
                        this.Refresh();
                        this.painting();
                    }
                    dropType = DropType.FRONT;
                }
                else if (AllowUserSort && lastOverNode.Bounds.Y + lastOverNode.Bounds.Height - 4 < tempPosition.Y)
                {
                    if (dropType != DropType.AFTER)
                    {
                        DrawLineX1 = this.Indent * (lastOverNode.Level + 1) + 10;
                        DrawLineX2 = this.Width - 40;
                        DrawLineY = lastOverNode.Bounds.Y + lastOverNode.Bounds.Height;
                        this.Refresh();
                        this.painting();
                    }
                    dropType = DropType.AFTER;
                }
                else
                    lastOverNode.BackColor = Color.Orange;
            }
            #endregion
        }
        #endregion

        #region 画两节点中间的横线的部分代码
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);
        protected void painting()
        {
            Graphics g = System.Drawing.Graphics.FromHdc(GetWindowDC(this.Handle));
            g.DrawLine(new Pen(new SolidBrush(Color.DarkBlue), 2), DrawLineX1, DrawLineY - 5, DrawLineX1, DrawLineY + 5);
            g.DrawLine(new Pen(new SolidBrush(Color.DarkBlue), 2), DrawLineX1, DrawLineY, DrawLineX2, DrawLineY);
        }
        #endregion
    }
}
