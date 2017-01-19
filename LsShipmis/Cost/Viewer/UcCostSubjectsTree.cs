/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：
 * 创 建 人：徐正本
 * 创建时间：2011-5-18
 * 标    题：
 * 功能描述：船舶物资类型树 
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CommonViewer.BaseControl;
using CommonOperation.BaseClass;
using Cost.DataObject;
using Cost.Services;

namespace Cost.Viewer
{
    public partial class UcCostSubjectsTree : CommonViewer.DragTreeViewEx
    {
        #region 委托部分
        /// <summary>
        /// 当前点击到什么对象.
        /// </summary>
        /// <param name="materialType">对象</param> 
        public delegate void itemChanged(Account materialType);
        public event itemChanged ItemChanged;
        #endregion

        public UcCostSubjectsTree()
        {
            InitializeComponent();
            expanding += new NodeOperation(expandingFunction);
            reloading += new NodeOperation(RefreshOneNode);
            canDropDown += new CanDropDown(canDropDownJudging);
            insertIntoTreeView += new InsertIntoTreeView(reallyInsertItemToTreeNode);
            InsertAnotherPermittedDropType(typeof(Account));
            CustomItemDrag += new NodeOperation(customItemDrag);
            draggingFinish += new DraggingFinish(UcCostSubjectsTree_draggingFinish);
        }
        private Account dragItem = null;
        void UcCostSubjectsTree_draggingFinish(bool ifSuccess)
        {
            if (dragItem != null)
                SelectOneAccount(dragItem);
            dragItem = null;
        }

        #region 加载数据部分

        public void ReloadingAllData()
        {
            #region 增加根结点
            this.Nodes.Clear();

            //查找船舶对应的设备.
            TreeNode rootNode = new TreeNode("费用科目根结点");
            rootNode.ImageKey = "root";
            rootNode.SelectedImageKey = "select";
            this.Nodes.Add(rootNode);
            #region 增加第一级节点
            loadingSubClass(rootNode);
            foreach (TreeNode tn in this.Nodes)
            {
                tn.Expand();
            }
            #endregion

            #endregion

        }
        /// <summary>
        /// 定位类型用.
        /// </summary>
        /// <param name="positionType"></param>
        public void ReloadingAllDataByPosition(string positionType)
        {
            #region 增加根结点
            this.Nodes.Clear();

            //查找船舶对应的设备.
            TreeNode rootNode = new TreeNode("费用科目根结点");
            rootNode.ImageKey = "root";
            rootNode.SelectedImageKey = "select";
            this.Nodes.Add(rootNode);
            #region 增加第一级节点
            loadingSubClass(rootNode);
            foreach (TreeNode tn in this.Nodes)
            {
                tn.Expand();
            }
            #endregion

            #endregion

        }

        /// <summary>
        /// 得到下级分类的所有信息,并添加到treenode上.
        /// 间接被调用.
        /// </summary>
        /// <param name="nowRoot"></param>
        private void loadingSubClass(TreeNode nowRoot)
        {
            string classId;
            try
            {
                classId = ((Account)nowRoot.Tag).GetId();
            }
            catch
            {
                classId = "";
            }
            try
            {
                //先增加分类,按照顺序加.
                List<Account> lstSubAccounts = AccountService.Instance.GetObjectsByParentId(classId);
                for (int i = 0; i < lstSubAccounts.Count; i++)
                {
                    TreeNode rootNode = new TreeNode(lstSubAccounts[i].NODE_NAME);
                    rootNode.ImageKey = "haveitem";
                    rootNode.SelectedImageKey = "select";
                    rootNode.Tag = lstSubAccounts[i];
                    nowRoot.Nodes.Add(rootNode);
                }
            }
            catch (Exception e)
            {
                MessageBoxEx.Show("加载物资分类信息时出错,出错信息为:" + e.Message);
                return;
            }
        }

        public void SelectOneAccount(Account account)
        {
            if (account == null) return;
            //从数据库中找到此条数据,然后找到其相应的分类,倒序找到物资.
            List<string> routes = new List<string>();
            string err;
            if (!AccountService.Instance.GetEquipmentRoute(account, out routes, out err))
            {
                MessageBoxEx.Show("未能找到所查询的物资,错误信息为\r" + err);

                return;
            }
            if (this.Nodes.Count == 0) return;
            TreeNode rootNode = this.Nodes[0];

            //先展开根结点.
            foreach (TreeNode tn in rootNode.Nodes)
            {
                if (tn.Tag != null && tn.Tag.GetType() == typeof(Account))
                {
                    if (((Account)tn.Tag).GetId() == routes[0])
                    {
                        if (!tn.IsExpanded) RefreshOneNode(tn);
                        rootNode = tn;
                        break;
                    }
                }
            }
            if (rootNode == null)
            {
                MessageBoxEx.Show("未能定位到指定物资分类");
                return;
            }
            for (int i = 1; i < routes.Count; i++)
            {
                foreach (TreeNode tn in rootNode.Nodes)
                {
                    if (tn.Tag != null && tn.Tag.GetType().IsSubclassOf(typeof(CommonClass)))
                    {
                        if (((CommonClass)tn.Tag).GetId() == routes[i])
                        {
                            if (!tn.IsExpanded) RefreshOneNode(tn);
                            rootNode = tn;
                            break;
                        }
                    }
                }
                if (rootNode == null)
                {
                    MessageBoxEx.Show("未能找到物资所在物资分类信息项");
                    return;
                }
            }
            this.SelectedNode = rootNode;
        }
        #endregion

        #region 点击树操作部分

        /// <summary>
        /// 实现委托中的展开事件,同时也是此类本身的展开节点事件.
        /// </summary>
        /// <param name="tn">要展开的节点</param>
        private void expandingFunction(TreeNode tn)
        {
            if (tn.Nodes.Count == 0) RefreshOneNode(tn);
        }

        /// <summary>
        /// 此功能比鼠标左键点击更有效,因为上下移动光标也对此方法起作用.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcCostSubjectsTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //加入第一个条件是避免后面的展开函数再次展开,让push发生两次.
            if (e.Node.Nodes.Count > 0 && ItemChanged != null)
            {
                pushItemChangedEvent(e.Node);
            }
            expandingFunction(e.Node);
        }

        private void pushItemChangedEvent(TreeNode tn)
        {
            if (ItemChanged == null) return;
            if (tn == null || tn.Tag == null)
                ItemChanged(null);
            else if (tn.Tag.GetType() == typeof(Account))
            {
                ItemChanged((Account)tn.Tag);
            }
        }

        /// <summary>
        /// 刷新某个节点.
        /// </summary>
        /// <param name="theNodeToRefresh"></param>
        public void RefreshOneNode(TreeNode theNodeToRefresh)
        {
            if (theNodeToRefresh == null || theNodeToRefresh.Tag == null)
            {
                ReloadingAllData();
            }
            else
            {
                //先看看自己是否被改变.
                //再加载下级.
                theNodeToRefresh.Nodes.Clear();
                loadingSubClass(theNodeToRefresh);
            }
            pushItemChangedEvent(theNodeToRefresh);
        }

        /// <summary>
        /// 鼠标操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcCostSubjectsTree_MouseDown(object sender, MouseEventArgs e)
        {
            TreeViewHitTestInfo info = HitTest(e.X, e.Y);

            if (e.Button == MouseButtons.Left)
            {
                if (info.Location == TreeViewHitTestLocations.None) return;
                //左键单击,目的为了展开文件,如果是在checkbox中可以自动勾选.
                if (info.Location != TreeViewHitTestLocations.PlusMinus)
                {
                    if (info.Node.Nodes.Count == 0) RefreshOneNode(info.Node);
                    if (!info.Node.IsExpanded) info.Node.Expand();
                }
            }
        }

        #endregion

        #region 拖拽功能部分
        /// <summary>
        /// 是否可以拖拽释放的判断.
        /// </summary>
        /// <param name="dropNode">拖拽的内容</param>
        /// <param name="dropAim">拖拽的目标(希望放到哪个对象的下级)</param>
        /// <returns>是否可以拖拽</returns>
        private bool canDropDownJudging(object dropNode, TreeNode dropAim)
        {
            if (dropNode == null) return false;
            if (dropAim == null || dropAim.Tag == null)
            {
                if (dropNode.GetType() == typeof(Account))
                {
                    return true;
                }
                return false;
            }
            if (dropAim.Tag.GetType() == typeof(Account))
            {
                if (dropNode.GetType() == typeof(Account))
                {
                    string err;
                    if (!AccountService.Instance.AccountCanBeOthersSubClassification((Account)dropNode, (Account)dropAim.Tag, out err))
                    {
                        MessageBoxEx.Show("当前拖拽无效,错误原因是:\r" + err);
                        return false;
                    }
                    return true;
                }
                else return false;
            }
            return false;
        }

        /// <summary>
        /// 真正调整数据库,将拖动提交给数据库.
        /// </summary>
        private bool reallyInsertItemToTreeNode(object toInsertItem, TreeNode aimItem, int position)
        {
            string err;
            if ((aimItem == null || aimItem.Tag == null) && toInsertItem.GetType() == typeof(Account))
            {
                Account item = (Account)toInsertItem;
                item.PARENT_NODE_ID = "";
                item.ORDER_NUM = position + 1;
                if (!item.Update(out err))
                {
                    MessageBoxEx.Show("将分类调整提交给服务器时发生异常,错误信息为:\r" + err);
                    return false;
                }
                return true;
            }
            else if (aimItem.Tag.GetType() == typeof(Account) && toInsertItem.GetType() == typeof(Account))
            {
                Account item = (Account)toInsertItem;

                item.PARENT_NODE_ID = ((Account)aimItem.Tag).GetId();

                if (!item.Update(out err))
                {
                    MessageBoxEx.Show("将分类调整提交给服务器时发生异常,错误信息为:\r" + err);
                    return false;
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// 重载的用户拖拽发起函数.
        /// </summary>
        /// <param name="dragNode"></param>
        private void customItemDrag(TreeNode dragNode)
        {
            if (AllowUserDrag && dragNode != null && dragNode.Tag != null && dragNode.Tag.GetType() == typeof(Account))
            {
                dragItem = (Account)dragNode.Tag;
                DoDragDrop(dragItem, DragDropEffects.Move);
            }
        }
        #endregion

    }
}
