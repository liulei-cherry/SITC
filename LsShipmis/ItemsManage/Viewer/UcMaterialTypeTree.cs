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
using ItemsManage.DataObject;
using ItemsManage.Services;
using CommonViewer.BaseControl;
using CommonOperation.BaseClass;  

namespace ItemsManage.Viewer
{
    public partial class UcMaterialTypeTree : CommonViewer.DragTreeViewEx
    {
        #region 委托部分
        /// <summary>
        /// 当前点击到什么对象.
        /// </summary>
        /// <param name="materialType">对象</param> 
        public delegate void itemChanged(MaterialType materialType);
        public event itemChanged ItemChanged;
        #endregion

        public UcMaterialTypeTree()
        {
            InitializeComponent();
            expanding += new NodeOperation(expandingFunction);
            reloading += new NodeOperation(RefreshOneNode);
            canDropDown += new CanDropDown(canDropDownJudging);
            insertIntoTreeView += new InsertIntoTreeView(reallyInsertItemToTreeNode);
            InsertAnotherPermittedDropType(typeof(MaterialType));
            CustomItemDrag += new NodeOperation(customItemDrag);
            draggingFinish += new DraggingFinish(UcMaterialTypeTree_draggingFinish);
        }
        private MaterialType dragItem = null;
        void UcMaterialTypeTree_draggingFinish(bool ifSuccess)
        {
            if (dragItem != null)
                SelectOneMaterialType(dragItem);
            dragItem = null;
        }

        #region 加载数据部分 

        public void ReloadingAllData()
        {
            #region 增加根结点
            this.Nodes.Clear();
            List<MaterialType> root = MaterialTypeService.Instance.getRootItems();
            foreach (MaterialType oneRoot in root)
            {
                //查找船舶对应的设备.
                TreeNode rootNode = new TreeNode(oneRoot.MATERIAL_TYPE_NAME);
                rootNode.ImageKey = "root";
                rootNode.SelectedImageKey = "select";
                rootNode.Tag = oneRoot;
                this.Nodes.Add(rootNode);
                #region 增加第一级节点
                loadingSubClass(rootNode);
                foreach (TreeNode tn in this.Nodes)
                {
                    tn.Expand();
                }
                #endregion
            }
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
                classId = ((MaterialType)nowRoot.Tag).GetId();
            }
            catch
            {
                classId = "";
            }
            try
            {
                //先增加分类,按照顺序加.
                List<MaterialType> lstSubMaterialTypees = MaterialTypeService.Instance.GetObjectsByParentId(classId);
                for (int i = 0; i < lstSubMaterialTypees.Count; i++)
                {
                    TreeNode rootNode = new TreeNode(lstSubMaterialTypees[i].MATERIAL_TYPE_NAME);
                    rootNode.ImageKey = "haveitem";
                    rootNode.SelectedImageKey = "select";
                    rootNode.Tag = lstSubMaterialTypees[i];
                    nowRoot.Nodes.Add(rootNode);
                }
            }
            catch (Exception e)
            {
                MessageBoxEx.Show("加载物资分类信息时出错,出错信息为:" + e.Message);
                return;
            }
        }

        public void SelectOneMaterialType(MaterialType materialType)
        {
            if (materialType == null) return;
            //从数据库中找到此条数据,然后找到其相应的分类,倒序找到物资.
            List<string> routes = new List<string>();
            string err;
            if (!MaterialTypeService.Instance.GetEquipmentRoute(materialType, out routes, out err))
            {
                MessageBoxEx.Show("未能找到所查询的物资,错误信息为\r" + err);

                return;
            }
            TreeNode rootNode = null;
            //先展开根结点.
            foreach (TreeNode tn in this.Nodes)
            {
                if (tn.Tag != null && tn.Tag.GetType() == typeof(MaterialType))
                {
                    if (((MaterialType)tn.Tag).GetId() == routes[0])
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
        private void UcMaterialTypeTree_AfterSelect(object sender, TreeViewEventArgs e)
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
            else if (tn.Tag.GetType() == typeof(MaterialType))
            {
                ItemChanged((MaterialType)tn.Tag);
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
        private void UcMaterialTypeTree_MouseDown(object sender, MouseEventArgs e)
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
            if (dropNode == null || dropAim.Tag == null) return false;
            if (dropAim.Tag.GetType() == typeof(MaterialType))
            {
                if (dropNode.GetType() == typeof(MaterialType))
                {
                    string err;
                    if (!MaterialTypeService.Instance.MaterialTypeCanBeOthersSubClassification((MaterialType)dropNode, (MaterialType)dropAim.Tag, out err))
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
            if (aimItem.Tag.GetType() == typeof(MaterialType) && toInsertItem.GetType() == typeof(MaterialType))
            {
                MaterialType item = (MaterialType)toInsertItem;

                item.SUPERIOR_ID = ((MaterialType)aimItem.Tag).GetId();

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
            if (AllowUserDrag && dragNode!=null && dragNode.Tag!=null && dragNode.Tag.GetType() == typeof(MaterialType))
            {
                dragItem = (MaterialType)dragNode.Tag;
                DoDragDrop(dragItem, DragDropEffects.Move);                 
            }
        }
        #endregion

    }
}
