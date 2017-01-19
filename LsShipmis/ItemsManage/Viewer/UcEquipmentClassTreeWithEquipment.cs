/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：
 * 创 建 人：徐正本
 * 创建时间：2011-4-27
 * 标    题：
 * 功能描述：船舶设备分类树,包含以下功能
 * √1.展示方式
 *      a.展示时分5种级别,船舶(设备表),部门\系统\设备分类(分类表),具体设备(设备表),
 *        分别使用5种不同的图标显示.设备分为顶级设备和非顶级设备,
 *      b.直接挂在分类下的是顶级设备,挂在设备下的是非顶级设备. 
 *      c.设备包含下级的点击设备是自动展开,如果已经被其它设备引用的设备,在树上可能出现两次,这是正常的
 *        比如主机的附属设备'调速器a'初始化到主机下级,而分类中存在调速器这个项,则在主机下有'调速器a',在调速器分类下也有'调速器a'
 *      d.没有挂过任何分类的顶级设备直接出现在船舶下,排在最后的位置.
 *      e.节点不让编辑.
 *      f.支持多船模式,可以同时把几条船的信息展示出来
 * √2.设置功能:
 *      a.可以设置不展示具体设备功能(在设备分类关系界面中使用)
 *      b.可以设置是否可以编辑功能.
 *      c.可以打开或关闭拖拽功能
 *      d.可以设置是否显示没有关联设备的分类.
 *      e.支持单船或多船模式
 * √3.右键菜单:
 *      a.内容项:编辑,删除,刷新,全选下级设备,全清下级设备
 *      b.右键菜单中 刷新永远可用, 全选,全清在任何有效节点上始终可用
 *      b.对应5种类型,编辑和删除的作用:
 *          i:船舶, 不允许编辑删除
 *          ii:部门\系统\设备分类,编辑分类内容,编辑完毕后,根据新的分类状态切换显示图标,不允许删除包含子节点的内容,并且打开此功能需要权限
 *          iii:具体设备:不允许编辑;删除的作用是删除分类对应关系,并不影响实际设备,删除完毕分类后,需要对整个树进行刷新,
 *          iv:如果当前节点并非关系信息的设备信息,则删除时自动把其下级调整为其上级的下级,
 *             只有满足包含下级,且下级已经被其它分类引用的设备才可以进行此操作,操作前需要提示用户.
 *  4.树上拖拽功能, *      
 *    √a.可以拖拽分类到其它分类下,但必须保证分类的层次关系不发生异常,否则需要先切换其分类代码种类.
 *          并且注意:分类不能拖拽到设备及其前后
 *    √b.可以把顶级设备拖拽到其他分类下,也可以把非顶级设备拽到别的分类下
 *    √c.拖拽过程中,如果有下级,悬停2秒可以展开原来未展开的树枝.
 *      d.设备拖拽时,只允许往设备分类节点上拖拽,或者在同级是设备的情况下进行前后排序的拖拽. 
 *    √e.拖拽时,如果需要向上下滚动时,能够自己实现滚动功能,当鼠标在最最上部5个像素以内,以5种速度分别往前滚动,向下滚动亦然
 * √5.点击操作
 *    √a.单击展开,方向键操作也能展开(上下键不展开,右键展开左键收缩,完全像windows的方式)
 *    √b.右键弹出菜单项
 * 修 改 人： 
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
using BaseInfo.Objects;
using ItemsManage.DataObject;
using ItemsManage.Services;
using CommonViewer.BaseControl;
using CommonOperation.BaseClass;
using BaseInfo.DataAccess;
using CommonOperation.Functions;

namespace ItemsManage.Viewer
{
    public partial class UcEquipmentClassTreeWithEquipment : CommonViewer.DragTreeViewEx
    {
        #region 委托部分
        /// <summary>
        /// 当前点击到什么对象
        /// </summary>
        /// <param name="theObject">对象</param>
        /// <param name="objectType">对象类型0:null,1:ShipInfo,2:Equipment,3:EquipmentClass</param>
        public delegate void itemChanged(object theObject, int objectType);
        public event itemChanged ItemChanged;
        #endregion

        public UcEquipmentClassTreeWithEquipment()
        {
            InitializeComponent();
            expanding += new NodeOperation(expandingFunction);
            reloading += new NodeOperation(RefreshOneNode);
            canDropDown += new CanDropDown(canDropDownJudging);
            insertIntoTreeView += new InsertIntoTreeView(reallyInsertItemToTreeNode);
            InsertAnotherPermittedDropType(typeof(ComponentUnit));
            InsertAnotherPermittedDropType(typeof(EquipmentClass));
            InsertAnotherPermittedDropType(typeof(List<ComponentUnit>));
            CustomItemDrag += new NodeOperation(customItemDrag);
            draggingFinish += new DraggingFinish(UcEquipmentClassTreeWithEquipment_draggingFinish);
            mShowAllClass.CheckedChanged += new EventHandler(mShowAllClass_CheckedChanged);
        }

        void UcEquipmentClassTreeWithEquipment_draggingFinish(bool ifSuccess)
        {
            if (parentNodeOfSelect != null) this.RefreshOneNode(parentNodeOfSelect);
            parentNodeOfSelect = null;
            userSelectedEquipmentItems.Clear();
        }

        #region 2014-12-19-wanhw-获取当前节点对应的的根节点
        /// <summary>
        /// 获取当前节点对应的的根节点.
        /// </summary>
        /// <param name="tempNode">节点A.</param>
        /// <returns>节点A所在树的根节点.</returns>
        private TreeNode GetRootNode(TreeNode tempNode)
        {
            TreeNode treeNode = tempNode.Parent;
            if (null == treeNode)
            {
                return tempNode;
            }
            else
            {
                return GetRootNode(treeNode);
            }
        }

        #endregion

        #region 2014-12-19-wanhw-拖拽的节点与被拖拽到的节点是否在同一条船舶上
        /// <summary>
        /// 拖拽的节点与被拖拽到的节点是否在同一条船舶上.
        /// </summary>
        /// <param name="dropNode">拖拽的节点.</param>
        /// <param name="aimNode">被拖拽到的节点.</param>
        /// <returns>TRUE:属于同一条船舶；FALSE:属于不同的船舶.</returns>
        private Boolean IsTheSameTree(TreeNode dropNode, TreeNode aimNode)
        {
            TreeNode tempDropNode = GetRootNode(dropNode);
            TreeNode tempAimNode = GetRootNode(aimNode); 

            if (tempDropNode.Tag.GetType() == typeof(ShipInfo)&&tempAimNode.Tag.GetType() == typeof(ShipInfo))
            {
                if (((ShipInfo)tempDropNode.Tag).SHIP_ID == ((ShipInfo)tempAimNode.Tag).SHIP_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion 

        #region 设置区域

        /// <summary>
        /// 设置是否展示具体设备功能
        /// </summary>
        [Description("设置是否展示具体设备功能,如果不允许显示设备,则是纯代码树管理!"), Category("自定义属性")]
        public bool ShowEquipment { get; set; }

        /// <summary>
        /// 设置是否展示具体设备功能
        /// </summary>
        [Description("设置是否允许设备分类层次之间的拖动,此设置不影响是否允许设备往分类上的拖动!"), Category("自定义属性")]
        public bool AllowEquipmentClassDragToOtherClass { get; set; }

        /// <summary>
        /// 设置是否可以编辑,
        /// 靠此设置,全面屏蔽右键菜单的弹出.
        /// </summary>
        [Description("设置是否可以编辑,不允许编辑时,右键菜单只存在刷新功能"), Category("自定义属性")]
        public bool AllowUserEdit { get; set; }

        /// <summary>
        /// 设置是否显示所有分类,true所有,false仅显示关联设备的分类 
        /// </summary>
        [Description("设置是否显示所有分类,true所有,false仅显示关联设备的分类"), Category("自定义属性")]
        public bool ShowAllClass { get; set; }

        /// <summary>
        /// 设置是否只显示一条船的模式,true只显示一条船,false可以显示多条船 
        /// </summary>
        [Description("设置是否只显示一条船的模式,true只显示一条船,false可以显示多条船"), Category("自定义属性")]
        public bool OneShipMode { get; set; }

        /// <summary>
        /// 设置是否显示未分类的船舶设备信息
        /// </summary>
        [Description("设置是否显示未分类的船舶设备信息"), Category("自定义属性")]
        public bool ShowNotClassifedEquipment { get; set; }

        /// <summary>
        /// 设置是否仅显示未分类的船舶设备信息,用于被拖拽的树 
        /// </summary>
        [Description("设置是否仅显示未分类的船舶设备信息,用于被拖拽的树"), Category("自定义属性")]
        public bool OnlyShowNotClassifedEquipment { get; set; }

        /// <summary>
        /// 设置是否显示设备包含备件图片的功能,如果设置了,具备备件的设备图标与不具备的图标不一致 
        /// </summary>
        [Description("设置是否显示设备包含备件图片的功能,如果设置了,具备备件的设备图标与不具备的图标不一致"), Category("自定义属性")]
        public bool ShowEquipmentHaveSpare { get; set; }

        private bool allowUserMultiSelect = true;
        /// <summary>
        /// 设置是否允许多选 
        /// </summary>
        [Description("设置是否允许多选!"), Category("自定义属性")]
        public bool AllowUserMultiSelect
        {
            get
            {
                return allowUserMultiSelect;
            }
            set
            {
                allowUserMultiSelect = value;
                CheckBoxes = allowUserMultiSelect;
                mSelectAll.Visible = allowUserMultiSelect;
                mClearAll.Visible = allowUserMultiSelect;
                toolStripSeparator1.Visible = allowUserMultiSelect;
            }
        }

        #endregion

        #region 加载数据部分

        ShipInfo theShipShow = null;
        private bool loaded = false;
        public void ReloadingAllData()
        {
            loaded = false;
            if (ShowEquipment)
            {
                if (OnlyShowNotClassifedEquipment)
                {
                    mShowAllClass.Visible = false;
                    toolStripSeparator3.Visible = false;
                }
                else
                {
                    mShowAllClass.Checked = ShowAllClass;
                }
                List<ShipInfo> allShips = new List<ShipInfo>();
                if (OneShipMode)
                {
                    if (theShipShow != null) allShips.Add(theShipShow);
                }
                else
                {
                    string err;
                    DataTable dt = ShipInfoService.Instance.GetOwnerShip(out err);
                    foreach (DataRow dr in dt.Rows)
                    {
                        allShips.Add(ShipInfoService.Instance.getObject(dr));
                    }
                }
                #region 增加根结点

                this.Nodes.Clear();
                for (int i = 0; i < allShips.Count; i++)
                {
                    //查找船舶对应的设备.
                    TreeNode rootNode = new TreeNode(allShips[i].ToString());
                    rootNode.ImageKey = "ship";
                    rootNode.SelectedImageKey = "open";
                    rootNode.Tag = allShips[i];
                    this.Nodes.Add(rootNode);
                    #region 增加第一级节点
                    loadingSubItemsOfShip(rootNode);
                    #endregion
                }
                #endregion
            }
            else
            {
                //这种模式必须显示所有分类.
                ShowAllClass = true;
                mShowAllClass.Visible = false;
                toolStripSeparator3.Visible = false;
                //查找船舶对应的设备.
                this.Nodes.Clear();
                TreeNode rootNode = new TreeNode("分类代码(EquipmentClass)");
                rootNode.ImageKey = "ship";
                rootNode.SelectedImageKey = "open";
                rootNode.Tag = null;
                this.Nodes.Add(rootNode);
                #region 增加第一级节点

                loadingSubClass(rootNode, "");
                if (rootNode.Nodes.Count < 4) rootNode.Expand();
                #endregion
            }
            loaded = true;
        }
        /// <summary>
        /// 复制设备,显示全部.
        /// </summary>
        public void ReloadingAllData(bool showAll)
        {
            loaded = false;
            if (ShowEquipment)
            {
                if (OnlyShowNotClassifedEquipment)
                {
                    mShowAllClass.Visible = false;
                    toolStripSeparator3.Visible = false;
                }
                else
                {
                    mShowAllClass.Checked = ShowAllClass;
                }
                List<ShipInfo> allShips = new List<ShipInfo>();
                if (OneShipMode)
                {
                    if (theShipShow != null) allShips.Add(theShipShow);
                }
                else
                {
                    string err;
                    DataTable dt = ShipInfoService.Instance.getInfo(out err);
                    foreach (DataRow dr in dt.Rows)
                    {
                        allShips.Add(ShipInfoService.Instance.getObject(dr));
                    }
                }
                #region 增加根结点

                this.Nodes.Clear();
                for (int i = 0; i < allShips.Count; i++)
                {
                    //查找船舶对应的设备.
                    TreeNode rootNode = new TreeNode(allShips[i].ToString());
                    rootNode.ImageKey = "ship";
                    rootNode.SelectedImageKey = "open";
                    rootNode.Tag = allShips[i];
                    this.Nodes.Add(rootNode);
                    #region 增加第一级节点

                    loadingSubItemsOfShip(rootNode);
                    #endregion
                }
                #endregion
            }
            else
            {
                //这种模式必须显示所有分类.
                ShowAllClass = true;
                mShowAllClass.Visible = false;
                toolStripSeparator3.Visible = false;
                //查找船舶对应的设备.
                this.Nodes.Clear();
                TreeNode rootNode = new TreeNode("分类代码(EquipmentClass)");
                rootNode.ImageKey = "ship";
                rootNode.SelectedImageKey = "open";
                rootNode.Tag = null;
                this.Nodes.Add(rootNode);
                #region 增加第一级节点

                loadingSubClass(rootNode, "");
                if (rootNode.Nodes.Count < 4) rootNode.Expand();
                #endregion
            }
            loaded = true;
        }

        public void ReloadingShipData(ShipInfo theShip)
        {
            loaded = false;
            theShipShow = theShip;
            #region 增加根结点

            //查找船舶对应的设备.
            if (theShip == null || theShip.IsWrong) throw new Exception("传入的船舶参数无效!");
            this.Nodes.Clear();
            TreeNode rootNode = new TreeNode(theShip.ToString());
            rootNode.ImageKey = "ship";
            rootNode.SelectedImageKey = "open";
            rootNode.Tag = theShip;
            this.Nodes.Add(rootNode);
            #endregion

            #region 增加第一级节点

            loadingSubItemsOfShip(rootNode);
            #endregion
            loaded = true;
        }

        /// <summary>
        /// 加载一条船所有的节点到treenode上.
        /// 树上根结点点击时调用.
        /// </summary>
        /// <param name="nowRoot"></param>
        private void loadingSubItemsOfShip(TreeNode nowRoot)
        {
            try
            {
                ShipInfo nowClass = (ShipInfo)nowRoot.Tag;
                //先增加分类,按照顺序加.
                if (!OnlyShowNotClassifedEquipment) loadingSubClass(nowRoot, nowClass.GetId());
                //再增加没有关联过分类的设备,按照其型号的排序来,如果没有找到的,按照名称排序.
                if (ShowEquipment && (ShowNotClassifedEquipment || OnlyShowNotClassifedEquipment))
                    loadingSubItemsOfEquipment(nowRoot);
                if (!CommonOperation.ConstParameter.IsLandVersion) nowRoot.Expand();
            }
            catch (Exception e)
            {
                MessageBoxEx.Show("加载船舶分类信息时出错,出错信息为:" + e.Message);
                return;
            }

        }

        /// <summary>
        /// 得到下级分类的所有信息,并添加到treenode上
        /// 树上点击分类节点时调用
        /// </summary>
        /// <param name="nowRoot"></param>
        private void loadingSubItemsOfClass(TreeNode nowRoot, string shipid)
        {
            try
            {
                EquipmentClass nowClass = (EquipmentClass)nowRoot.Tag;
                //现增加分类,按照顺序加
                loadingSubClass(nowRoot, shipid);
                //再增加关联过当前分类的设备,按照分类关联排序号排序.
                if (ShowEquipment) loadingSubEquipment(nowRoot, shipid);
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// 获取设备的下级设备
        /// 树上点击未分类设备时调用
        /// 同时,也可以间接被调用
        /// </summary>
        /// <param name="parentEquipmentId"></param>
        private void loadingSubItemsOfEquipment(TreeNode nowRoot)
        {
            try
            {
                ComponentUnit nowEquipment;
                CommonClass nowClass = (CommonClass)nowRoot.Tag;
                string err;
                if (nowRoot.Tag.GetType() == typeof(ShipInfo))
                {
                    nowEquipment = ComponentUnitService.Instance.GetObjectByRootAndShipId(nowClass.GetId(), out err);
                }
                else
                {
                    nowEquipment = (ComponentUnit)nowClass;
                }
                //再增加没有关联过分类的设备,按照其型号的排序来,如果没有找到的,按照名称排序.
                List<ComponentUnit> lstComponents = EquipmentClassService.Instance.GetNotClassifiedEquipments(nowEquipment.GetId());
                for (int i = 0; i < lstComponents.Count; i++)
                {
                    TreeNode rootNode = new TreeNode(lstComponents[i].ToString());
                    if (ShowEquipmentHaveSpare && ComponentUnitService.Instance.GetOneComponentHasSparePic(lstComponents[i]))
                    {
                        rootNode.ImageKey = "equipwithpic";
                    }
                    else
                    {
                        rootNode.ImageKey = "equipment";
                    }
                    rootNode.SelectedImageKey = "open";
                    rootNode.Tag = lstComponents[i];
                    nowRoot.Nodes.Add(rootNode);
                }
            }
            catch (Exception e)
            {
                MessageBoxEx.Show("加载设备分类信息时出错,出错信息为:" + e.Message);
                return;
            }
        }

        /// <summary>
        /// 得到下级分类的所有信息,并添加到treenode上
        /// 间接被调用
        /// </summary>
        /// <param name="nowRoot"></param>
        private void loadingSubClass(TreeNode nowRoot, string shipid)
        {
            string classId;
            try
            {
                classId = ((EquipmentClass)nowRoot.Tag).GetId();
            }
            catch
            {
                classId = "";
            }
            try
            {
                //先增加分类,按照顺序加
                List<EquipmentClass> lstSubEquipmentClasses = EquipmentClassService.Instance.GetObjectsByParentId(classId, ShowAllClass, shipid);
                for (int i = 0; i < lstSubEquipmentClasses.Count; i++)
                {
                    TreeNode rootNode = new TreeNode(lstSubEquipmentClasses[i].ToString());
                    rootNode.ImageKey = "EquipClass";
                    rootNode.SelectedImageKey = "open";
                    rootNode.Tag = lstSubEquipmentClasses[i];
                    nowRoot.Nodes.Add(rootNode);
                }
            }
            catch (Exception e)
            {
                MessageBoxEx.Show("加载设备分类信息时出错,出错信息为:" + e.Message);
                return;
            }
        }

        /// <summary>
        /// 得到下级分类的所有信息,并添加到treenode上
        /// 间接被调用
        /// </summary>
        /// <param name="nowRoot"></param>
        private void loadingSubEquipment(TreeNode nowRoot, string shipid)
        {
            try
            {
                EquipmentClass nowClass = (EquipmentClass)nowRoot.Tag;
                //先增加分类,按照顺序加
                List<ComponentUnit> lstComponents = EquipmentClassService.Instance.GetClassifiedEquipmentByClassId(nowClass.GetId(), shipid);
                for (int i = 0; i < lstComponents.Count; i++)
                {
                    TreeNode rootNode = new TreeNode(lstComponents[i].ToString());
                    if (ShowEquipmentHaveSpare && ComponentUnitService.Instance.GetOneComponentHasSparePic(lstComponents[i]))
                    {
                        rootNode.ImageKey = "equipwithpic";
                    }
                    else
                    {
                        rootNode.ImageKey = "equipment";
                    }
                    rootNode.SelectedImageKey = "open";
                    rootNode.Tag = lstComponents[i];
                    nowRoot.Nodes.Add(rootNode);
                }
            }
            catch (Exception e)
            {
                MessageBoxEx.Show("加载设备分类信息时出错,出错信息为:" + e.Message);
                return;
            }
        }

        private void mShowAllClass_CheckedChanged(object sender, EventArgs e)
        {
            ShowAllClass = mShowAllClass.Checked;
            if (loaded) ReloadingAllData();
        }

        public void SelectOneEquipment(ComponentUnit equipment)
        {
            if (equipment == null) return;
            //从数据库中找到此条数据,然后找到其相应的分类,倒序找到设备
            List<string> routes = new List<string>();
            if (!EquipmentClassService.Instance.GetEquipmentRoute(equipment, out routes))
            {
                MessageBoxEx.Show("未能找到所查询的设备");

                return;
            }
            TreeNode rootNode = null;
            //先展开船舶
            foreach (TreeNode tn in this.Nodes)
            {
                if (tn.Tag != null && tn.Tag.GetType() == typeof(ShipInfo))
                {
                    if (((ShipInfo)tn.Tag).GetId() == equipment.SHIP_ID)
                    {
                        if (!tn.IsExpanded) RefreshOneNode(tn);
                        rootNode = tn;
                        break;
                    }
                }
            }
            if (rootNode == null)
            {
                MessageBoxEx.Show("未能找到设备所在船舶");
                return;
            }
            //在一层层展开routes

            for (int i = 1; i < routes.Count; i++)
            {
                bool find = false;
                foreach (TreeNode tn in rootNode.Nodes)
                {
                    if (tn.Tag != null && tn.Tag.GetType().IsSubclassOf(typeof(CommonClass)))
                    {
                        if (((CommonClass)tn.Tag).GetId() == routes[i])
                        {
                            if (!tn.IsExpanded) RefreshOneNode(tn);
                            rootNode = tn;
                            find = true;
                            break;
                        }
                    }
                }
                if (find == false)
                {
                    MessageBoxEx.Show("未能找到设备所在设备分类信息项");
                    return;
                }
            }
            this.SelectedNode = rootNode;
        }
        #endregion

        #region 点击树操作部分

        /// <summary>
        /// 实现委托中的展开事件,同时也是此类本身的展开节点事件
        /// </summary>
        /// <param name="tn">要展开的节点</param>
        private void expandingFunction(TreeNode tn)
        {
            if (tn.Nodes.Count == 0) RefreshOneNode(tn);
        }

        /// <summary>
        /// 此功能比鼠标左键点击更有效,因为上下移动光标也对此方法起作用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcEquipmentClassTreeWithEquipment_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //加入第一个条件是避免后面的展开函数再次展开,让push发生两次
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
                ItemChanged(null, 0);
            else if (tn.Tag.GetType() == typeof(ShipInfo))
            {
                ItemChanged(tn.Tag, 1);
            }
            else if (tn.Tag.GetType() == typeof(ComponentUnit))
            {
                ItemChanged(tn.Tag, 2);
            }
            else if (tn.Tag.GetType() == typeof(EquipmentClass))
            {
                ItemChanged(tn.Tag, 3);
            }
        }
        /// <summary>
        /// 右键功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (lastRightClickNode == null || lastRightClickNode.Tag == null)
            {
                if (e.ClickedItem.Name == "mRefresh")
                    ReloadingAllData();
                else
                    return;
            }
            string err;
            switch (e.ClickedItem.Name)
            {
                case "mEdit":
                    //部门\系统\设备分类,编辑分类内容,编辑完毕后,根据新的分类状态切换显示图标
                    if (lastRightClickNode.Tag.GetType() == typeof(EquipmentClass))
                    {
                        FrmEditOneEquipmentClass form = new FrmEditOneEquipmentClass((EquipmentClass)lastRightClickNode.Tag);
                        form.ShowDialog();
                        if (form.NeedRetrieve)
                        {
                            lastRightClickNode.Tag = form.EquipmentClassEdited;
                            lastRightClickNode.Text = form.EquipmentClassEdited.ToString();
                            lastRightClickNode.ImageKey = "EquipClass";
                        }
                    }
                    return;
                case "mDelete":
                    if (lastRightClickNode.Tag.GetType() == typeof(EquipmentClass))
                    {
                        if (MessageBoxEx.Show("是否删除当前设备分类信息", "提示信息", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            if (!((EquipmentClass)lastRightClickNode.Tag).Delete(out err))
                            {
                                MessageBoxEx.Show("删除失败,原因是:\r" + err);
                            }
                            else
                            {
                                MessageBoxEx.Show("删除成功");

                                RefreshOneNode(lastRightClickNode.Parent);
                            }
                        }
                    }
                    #region 具体设备
                    else if (lastRightClickNode.Tag.GetType() == typeof(ComponentUnit))
                    {
                        string equipmentId = ((ComponentUnit)lastRightClickNode.Tag).GetId();

                        if (lastRightClickNode.Parent != null && lastRightClickNode.Parent.Tag != null
                            && lastRightClickNode.Parent.Tag.GetType() == typeof(EquipmentClass))
                        {
                            //得到上级分类,
                            EquipmentClass classifiedClass = (EquipmentClass)lastRightClickNode.Parent.Tag;
                            if (!EquipmentClassService.Instance.DeleteClassifiedEquipmentRelation(classifiedClass.GetId(),
                                ((ComponentUnit)lastRightClickNode.Tag).GetId(), out err))
                            {
                                MessageBoxEx.Show("删除设备分类关联关系时出错,错误信息为:\r" + err);
                            }
                            else
                            {
                                #region 找到当前设备最顶级的船舶,直接刷新,并展示到上级分类处
                                List<EquipmentClass> allRoot = new List<EquipmentClass>();
                                allRoot.Add(classifiedClass);
                                TreeNode tn = lastRightClickNode.Parent;
                                while (tn.Parent != null && tn.Parent.Tag != null && tn.Parent.Tag.GetType() == typeof(EquipmentClass))
                                {
                                    tn = tn.Parent;
                                    allRoot.Insert(0, (EquipmentClass)tn.Tag);
                                }
                                if (tn.Parent != null && tn.Parent.Tag != null && tn.Parent.Tag.GetType() == typeof(ShipInfo))
                                {
                                    tn = tn.Parent;
                                    RefreshOneNode(tn);
                                    //依次展开所有分类级别
                                    for (int i = 0; i < allRoot.Count; i++)
                                    {
                                        bool find = false;
                                        tn.Expand();
                                        foreach (TreeNode tnTemp in tn.Nodes)
                                        {
                                            if (tnTemp.Tag != null && tnTemp.Tag.GetType() == typeof(EquipmentClass)
                                                && ((EquipmentClass)tnTemp.Tag).GetId() == allRoot[i].GetId())
                                            {
                                                find = true;
                                                tn = tnTemp;
                                                break;
                                            }
                                        }
                                        if (find)
                                        {
                                            RefreshOneNode(tn);

                                            this.SelectedNode = tn;
                                            tn.Expand();
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                                #endregion
                            }

                        }
                        else
                        {
                            TreeNode tempNode = lastRightClickNode.Parent;
                            while (tempNode != null && tempNode.Tag != null && tempNode.Tag.GetType() == typeof(ComponentUnit))
                            {
                                tempNode = tempNode.Parent;
                            }
                            if (tempNode == null || tempNode.Tag == null) throw new Exception("err treenode");
                            if (tempNode.Tag.GetType() == typeof(EquipmentClass))
                            {
                                MessageBoxEx.Show("不能通过此功能删除具体设备!");
                            }
                            else if (tempNode.Tag.GetType() == typeof(ShipInfo))
                            {
                                #region 删除实际设备表中的过渡设备
                                //如果当前节点并非关系信息的设备信息,则删除时自动把其下级调整为其上级的下级,
                                //只有满足包含下级,且下级已经被其它分类引用的设备才可以进行此操作,操作前需要提示用户.
                                if (EquipmentClassService.Instance.CanBeDeletedVirtualEquipment(equipmentId))
                                {
                                    if (MessageBoxEx.Show("确定要删除当前设备?", "提示信息", MessageBoxButtons.YesNo)
                                        == DialogResult.Yes)
                                    {
                                        if (ComponentUnitService.Instance.DeleteVirtualEquipment(equipmentId, out err))
                                        {
                                            //删除完毕直接移除当前节点
                                            RefreshOneNode(lastRightClickNode.Parent);
                                        }
                                        else
                                        {
                                            MessageBoxEx.Show("删除失败,错误信息为:\r" + err, "错误提示");
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBoxEx.Show("删除设备操作仅针对两种情况进行处理:\r1希望撤销其分类的设备,"
                                        + "\r2所有下级均分类完毕,不需要作为上级设备显示到设备树上的虚拟设备节点"
                                        + "\r3当前设备不属于上面任何一种类型,不能进行删除操作!"
                                        + "\rThere're only two kind of equipment can be deleted, "
                                        + "\rwhich one has been classified but the user want to remove its relation,"
                                        + "\ror which one was used to be a virtual grouping node and now is effectless."
                                        + "\rThe node you're operated is not belong to these.", "错误提示");
                                }
                                #endregion
                            }
                        }
                    #endregion
                    }
                    return;
                case "mRefresh":
                    RefreshOneNode(lastRightClickNode);
                    selectAllSubItem(lastRightClickNode, false);
                    return;
                case "mSelectAll":
                    selectAllSubItem(lastRightClickNode, true);
                    return;
                case "mClearAll":
                    selectAllSubItem(lastRightClickNode, false);
                    return;
            }
        }

        /// <summary>
        /// 刷新某个节点
        /// </summary>
        /// <param name="theNodeToRefresh"></param>
        public void RefreshOneNode(TreeNode theNodeToRefresh)
        {
            string err;
            parentNodeOfSelect = null;
            if (theNodeToRefresh == null || theNodeToRefresh.Tag == null)
            {
                ReloadingAllData();
            }
            else
            {
                //先看看自己是否被改变
                //再加载下级
                theNodeToRefresh.Nodes.Clear();
                if (theNodeToRefresh.Tag.GetType() == typeof(ShipInfo))
                {
                    loadingSubItemsOfShip(theNodeToRefresh);
                }
                else if (theNodeToRefresh.Tag.GetType() == typeof(EquipmentClass))
                {
                    EquipmentClass nowClass = EquipmentClassService.Instance.getObject(((EquipmentClass)theNodeToRefresh.Tag).GetId(), out err);
                    if (nowClass != null && !nowClass.IsWrong)
                    {
                        theNodeToRefresh.Text = nowClass.ToString();
                        theNodeToRefresh.Tag = nowClass;
                    }
                    if (ShowEquipment)
                    {
                        TreeNode tn = theNodeToRefresh.Parent;
                        while (tn != null && tn.Tag != null && tn.Tag.GetType() != typeof(ShipInfo))
                        {
                            tn = tn.Parent;
                        }
                        if (tn != null && tn.Tag == null)
                        {
                            loadingSubItemsOfClass(theNodeToRefresh, "");
                        }
                        if (tn != null && tn.Tag != null && tn.Tag.GetType() == typeof(ShipInfo))
                        {
                            loadingSubItemsOfClass(theNodeToRefresh, ((ShipInfo)tn.Tag).GetId());
                        }
                    }
                    else
                    {
                        loadingSubItemsOfClass(theNodeToRefresh, "");
                    }
                }
                else if (theNodeToRefresh.Tag.GetType() == typeof(ComponentUnit))
                {
                    ComponentUnit nowEquipment = ComponentUnitService.Instance.getObject(((ComponentUnit)theNodeToRefresh.Tag).GetId(), out err);
                    if (nowEquipment != null && !nowEquipment.IsWrong)
                    {
                        theNodeToRefresh.Text = nowEquipment.ToString();
                        theNodeToRefresh.Tag = nowEquipment;
                    }
                    loadingSubItemsOfEquipment(theNodeToRefresh);
                }
            }
            pushItemChangedEvent(theNodeToRefresh);
        }

        /// <summary>
        /// 把下级全清,或全选
        /// </summary>
        /// <param name="theNodesParent">希望处理谁的下级</param>
        /// <param name="selectState">全清,false,全选,true</param>
        private void selectAllSubItem(TreeNode theNodesParent, bool selectState)
        {
            if (theNodesParent == null) return;
            userSelect = true;
            userSelectedEquipmentItems.Clear();
            if (selectState) parentNodeOfSelect = theNodesParent;
            else parentNodeOfSelect = null;
            foreach (TreeNode tn in theNodesParent.Nodes)
            {
                if (tn.Tag != null && tn.Tag.GetType() == typeof(ComponentUnit))
                {
                    tn.Checked = selectState;
                }
            }
            userSelect = false;
        }

        private void UcEquipmentClassTreeWithEquipment_MouseUp(object sender, MouseEventArgs e)
        {
            TreeViewHitTestInfo info = HitTest(e.X, e.Y);

            string err;
            if (e.Button == MouseButtons.Left)
            {
                if (info.Location == TreeViewHitTestLocations.None) return;
                //左键单击,目的为了展开文件,如果是在checkbox中可以自动勾选
                if (info.Location != TreeViewHitTestLocations.PlusMinus)
                {
                    if (info.Node.Nodes.Count == 0)
                    {
                        RefreshOneNode(info.Node);
                    }
                    else
                    {
                        pushItemChangedEvent(info.Node);
                    }
                    if (!info.Node.IsExpanded) info.Node.Expand();
                    else if (null != info.Node.Parent) info.Node.Collapse();
                }
            }
            #region 右键设置菜单部分
            else if (e.Button == MouseButtons.Right)
            {
                lastRightClickNode = info.Node;
                if (lastRightClickNode == null)
                {
                    rightClickMenu.Items["mEdit"].Enabled = false;
                    rightClickMenu.Items["mDelete"].Enabled = false;
                    rightClickMenu.Items["mSelectAll"].Enabled = false;
                    rightClickMenu.Items["mClearAll"].Enabled = false;
                }
                else
                {
                    this.SelectedNode = lastRightClickNode;
                    //右键单击,目的为了弹出右键菜单前切换右键菜单的项目
                    if (lastRightClickNode.Tag != null)
                    {
                        rightClickMenu.Items["mSelectAll"].Enabled = true;
                        rightClickMenu.Items["mClearAll"].Enabled = true;
                        if (lastRightClickNode.Tag.GetType() == typeof(ShipInfo))
                        {
                            rightClickMenu.Items["mEdit"].Enabled = false;
                            rightClickMenu.Items["mDelete"].Enabled = false;
                        }
                        // 部门\系统\设备分类,编辑分类内容,编辑完毕后,根据新的分类状态切换显示图标,不允许删除包含子节点的内容,并且打开此功能需要权限
                        else if (lastRightClickNode.Tag.GetType() == typeof(EquipmentClass))
                        {
                            bool canEdit = AllowUserEdit && ProxyRight.Instance.CheckRight(CommonOperation.ConstParameter.EQUIPMENTCLASS_EDIT, out err);
                            rightClickMenu.Items["mEdit"].Enabled = canEdit;
                            rightClickMenu.Items["mDelete"].Enabled = canEdit;
                        }
                        //具体设备:不允许编辑;删除的作用是删除分类对应关系,并不影响实际设备,删除完毕分类后,需要对整个树进行刷新,如果当前节点并非关系信息,则不允许删除.
                        else if (lastRightClickNode.Tag.GetType() == typeof(ComponentUnit))
                        {
                            rightClickMenu.Items["mEdit"].Enabled = false;
                            if (lastRightClickNode.Parent != null && lastRightClickNode.Parent.Tag.GetType() == typeof(EquipmentClass))
                            {
                                rightClickMenu.Items["mDelete"].Enabled = true;
                            }
                            else
                            {
                                rightClickMenu.Items["mDelete"].Enabled = EquipmentClassService.Instance.CanBeDeletedVirtualEquipment
                                    (((ComponentUnit)lastRightClickNode.Tag).GetId());
                            }
                        }
                    }
                    else
                    {
                        rightClickMenu.Items["mEdit"].Enabled = false;
                        rightClickMenu.Items["mDelete"].Enabled = false;
                        rightClickMenu.Items["mSelectAll"].Enabled = false;
                        rightClickMenu.Items["mClearAll"].Enabled = false;
                    }
                }
            }
            #endregion
        }

        #endregion

        #region 拖拽功能部分
        /// <summary>
        /// 是否可以拖拽释放的判断
        /// </summary>
        /// <param name="dropNode">拖拽的内容</param>
        /// <param name="dropAim">拖拽的目标(希望放到哪个对象的下级)</param>
        /// <returns>是否可以拖拽</returns>
        private bool canDropDownJudging(object dropNode, TreeNode dropAim)
        {
            if (dropNode == null || (dropAim.Tag == null && ShowEquipment == true)) return false;

            #region  wanhw-2014-12-19-只能在同一条船舶上拖拽
            TreeNode tempDropNode=null;
            if (dropNode.GetType() == typeof(TreeNode))
            {
                tempDropNode = (TreeNode)dropNode;
            }
            else if (DragTreeNode != null)
            {
                tempDropNode = DragTreeNode;
            }
            //else return false;
            if (null != tempDropNode)
            {
                if (!IsTheSameTree(tempDropNode, dropAim))
                {
                    return false;
                }
            }
            #endregion

            if ( (dropAim.Tag == null && ShowEquipment == false) || dropAim.Tag.GetType() == typeof(EquipmentClass))
            {
                if (dropNode.GetType() == typeof(EquipmentClass))
                {
                    if (AllowEquipmentClassDragToOtherClass)
                        return selfDropDownJudging((EquipmentClass)dropNode, (TreeNode)dropAim);
                    else
                        return false;
                }
                else if (dropNode.GetType() == typeof(ComponentUnit) && dropAim.Tag != null)
                {
                    return true;
                }
                else if (dropNode.GetType() == typeof(List<ComponentUnit>) && dropAim.Tag != null)
                    return outerEquipmentDropDownJudging((List<ComponentUnit>)dropNode, (TreeNode)dropAim);
                else return false;
            }
            else
            {
                if (dropNode.GetType() == typeof(ComponentUnit))
                {
                    string err;
                    ComponentUnit parentUnit;
                    if (dropAim.Tag.GetType() == typeof(ShipInfo))
                    {
                        parentUnit = ComponentUnitService.Instance.GetObjectByRootAndShipId(((CommonClass)dropAim.Tag).GetId(), out err);
                    }
                    else
                    {
                        parentUnit = (ComponentUnit)dropAim.Tag;
                    }
                    ComponentUnit toDrop = (ComponentUnit)dropNode;
                    if (toDrop.SHIP_ID != parentUnit.SHIP_ID)
                    {
                        return false;
                    }

                    while (parentUnit != null && !parentUnit.IsWrong)
                    {
                        if (parentUnit.GetId() != toDrop.GetId())
                            parentUnit = ComponentUnitService.Instance.getObject(parentUnit.PARENT_UNIT_ID, out err);
                        else
                        {
                            return false;
                        }
                    }
                    return true;
                }
                return false;
            }
        }
        /// <summary>
        /// 这是自己控件的元素往自己身上拖的时候调用的方法
        /// 有两种拖法,分类往分类上拖动,需要判断其层次关系,不允许出现层次异常
        /// 如果是设备往分类上拖动,则不需要判断那么多,拖就是了,顺便把原来的分类更新掉
        /// </summary>
        /// <param name="dropNode"></param>
        /// <param name="dropAim"></param>
        /// <returns></returns>
        private bool selfDropDownJudging(EquipmentClass dropNode, TreeNode dropAim)
        {
            //如果分类往分类上拖拽,也需要进一步判断,分类的上下级关系,
            //部门不能作为其它部门的下级,系统不能作为其它系统的下级,设备分类可以作为其它设备分类的下级
            string err;
            if (!EquipmentClassService.Instance.EquipmentClassCanBeOthersSubClassification(dropNode, (EquipmentClass)dropAim.Tag, out err))
            {
                MessageBoxEx.Show("当前拖拽无效,错误原因是:\r" + err);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 外部的设备是否可以拖到分类下,这个应该没有什么问题,只要目标节点类型正确就可以
        /// </summary>
        /// <param name="allUnit"></param>
        /// <param name="dropAim"></param>
        /// <returns></returns>
        private bool outerEquipmentDropDownJudging(List<ComponentUnit> allUnit, TreeNode dropAim)
        {
            if (dropAim.Tag == null || dropAim.Tag.GetType() != typeof(EquipmentClass))
            {
                MessageBoxEx.Show("拖拽释放的目标位置无效,无法完成拖拽操作!");
                return false;
            }
            return true;
        }
        /// <summary>
        /// 真正调整数据库,将拖动提交给数据库 
        /// </summary>
        /// <param name="toInsertItem">插入的元素</param>
        /// <param name="aimItem">目标元素</param>
        /// <param name="position">插入元素在目标元素中的位置</param>
        /// <returns>是否成功</returns>
        private bool reallyInsertItemToTreeNode(object toInsertItem, TreeNode aimItem, int position)
        {
            position = position * 10 + 5;
            string err;
            if ((aimItem.Tag == null && ShowEquipment == false) || aimItem.Tag.GetType() == typeof(EquipmentClass))
            {
                if (toInsertItem.GetType() == typeof(EquipmentClass))
                {
                    if (!EquipmentClassService.Instance.DropClassToOtherClass(false, (EquipmentClass)toInsertItem,
                        (EquipmentClass)aimItem.Tag, position, out err))
                    {
                        MessageBoxEx.Show("将分类调整提交给服务器时发生异常,错误信息为:\r" + err);
                        return false;
                    }
                }
                else if (toInsertItem.GetType() == typeof(ComponentUnit))
                {
                    if (!EquipmentClassService.Instance.ClassifyEquipmentToClass(((EquipmentClass)aimItem.Tag).GetId(),
                        ((ComponentUnit)toInsertItem).GetId(), position, out err))
                    {
                        MessageBoxEx.Show("将设备关联到分类的调整提交给服务器时发生异常,错误信息为:\r" + err);
                        return false;
                    }
                }
                else if (toInsertItem.GetType() == typeof(List<ComponentUnit>))
                {
                    if (!EquipmentClassService.Instance.ClassifyEquipmentsToClass(((EquipmentClass)aimItem.Tag).GetId(),
                        (List<ComponentUnit>)toInsertItem, out err))
                    {
                        MessageBoxEx.Show("将设备关联到分类的调整提交给服务器时发生异常,错误信息为:\r" + err);
                        return false;
                    }
                }
                return true;
            }
            else
            {
                if (toInsertItem.GetType() == typeof(ComponentUnit))
                {
                    ComponentUnit toInsertUnit = (ComponentUnit)toInsertItem;
                    ComponentUnit parentUnit;
                    if (aimItem.Tag.GetType() == typeof(ShipInfo))
                    {
                        parentUnit = ComponentUnitService.Instance.GetObjectByRootAndShipId(((CommonClass)aimItem.Tag).GetId(), out err);
                    }
                    else
                    {
                        parentUnit = (ComponentUnit)aimItem.Tag;
                    }
                    if (toInsertUnit.SHIP_ID != parentUnit.SHIP_ID)
                    {
                        MessageBoxEx.Show("不同船舶之间,不允许拖拽设备");
                        return false;
                    }
                    string lastParentUnitId = parentUnit.GetId();
                    if (toInsertUnit.PARENT_UNIT_ID != parentUnit.GetId())
                    {
                        toInsertUnit.PARENT_UNIT_ID = parentUnit.GetId();
                    }
                    toInsertUnit.SortNo = position;
                    if (!toInsertUnit.Update(out err)) return false;
                    if (string.IsNullOrEmpty(lastParentUnitId)) return true;
                    //删除原设备跟class之间的关系
                    EquipmentClassService.Instance.DeleteClassifiedEquipmentRelation("", toInsertUnit.GetId(), out err);
                    //刷新拖拽节点的上级节点
                    if (aimItem.Parent != null) reloading(aimItem.Parent);
                    else if (aimItem != null) reloading(aimItem);
                    return ComponentUnitService.Instance.resortSubUnit(lastParentUnitId, out err);
                }
            }
            return false;
        }

        List<ComponentUnit> userSelectedEquipmentItems = new List<ComponentUnit>();
        /// <summary>
        /// 重载的用户拖拽发起函数
        /// </summary>
        /// <param name="dragNode"></param>
        private void customItemDrag(TreeNode dragNode)
        {
            if (AllowUserDrag)
            {
                if (!allowUserMultiSelect || userSelectedEquipmentItems == null || userSelectedEquipmentItems.Count == 0)
                {
                    if (AllowEquipmentClassDragToOtherClass || (dragNode != null && dragNode.Tag != null && dragNode.Tag.GetType() == typeof(ComponentUnit)))
                        DoDragDrop(dragNode.Tag, DragDropEffects.Move);
                    else return;
                }
                else
                {
                    DoDragDrop(userSelectedEquipmentItems, DragDropEffects.Move);
                }
            }
        }
        private TreeNode parentNodeOfSelect = null;
        private bool userSelect = false;
        /// <summary>
        /// 在选中多选框之前要处理的内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcEquipmentClassTreeWithEquipment_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            bool canCheck = false;
            //当选中某节点时,非同级的其它节点需要清空选中
            if (e.Node.Parent != null && (e.Node.Parent == parentNodeOfSelect || parentNodeOfSelect == null) && e.Node.Tag.GetType() == typeof(ComponentUnit))
            {
                parentNodeOfSelect = e.Node.Parent;
                canCheck = true;
            }
            else
            {
                canCheck = userSelect;
            }
            if (canCheck)
            {
                if (e.Node.Checked == false && !userSelectedEquipmentItems.Contains((ComponentUnit)e.Node.Tag))
                    userSelectedEquipmentItems.Add((ComponentUnit)e.Node.Tag);
                else if (e.Node.Checked == true && userSelectedEquipmentItems.Contains((ComponentUnit)e.Node.Tag))
                    userSelectedEquipmentItems.Remove((ComponentUnit)e.Node.Tag);

                if (userSelectedEquipmentItems.Count == 0)
                    parentNodeOfSelect = null;
                e.Cancel = false;
            }
            else
                e.Cancel = true;
        }
        #endregion
    }
}
