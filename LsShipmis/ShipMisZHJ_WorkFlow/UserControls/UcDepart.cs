/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：UcDepart.cs
 * 创 建 人：李景育
 * 创建时间：2009-08-25
 * 标    题：部门信息显示控件
 * 功能描述：实现部门信息显示与编辑的自定义控件
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
using ShipMisZHJ_WorkFlow.Services;
using ShipMisZHJ_WorkFlow.BusinessClasses;
using CommonViewer.BaseControlService;
using BaseInfo.DataAccess;

namespace ShipMisZHJ_WorkFlow.UserControls
{
    /// <summary>
    /// 部门信息显示控件.
    /// </summary>
    public partial class UcDepart : UserControl
    {
        //定义公共类Other对象.
        private FormControlOption other = FormControlOption.Instance;

        //声明一个上下文件菜单（用于部门树中添加或者删除时用）.
        private ContextMenuStrip ctxMenu = new ContextMenuStrip();
        private ToolStripMenuItem tspMnuAdd = new ToolStripMenuItem("添加部门");
        private ToolStripMenuItem tspMnuUpdate = new ToolStripMenuItem("编辑部门");
        private ToolStripMenuItem tspMnuDel = new ToolStripMenuItem("删除部门");

        #region 属性过程

        private int operationType = 1;

        /// <summary>
        /// 操作类型，0表示仅展示信息，1表示可操作信息.
        /// </summary>
        public int OperationType
        {
            get { return operationType; }
            set { operationType = value; }
        }
        
        /// <summary>
        /// 当前树控件.
        /// </summary>
        public TreeView TrvDepart
        {
            get { return trvDepart; }
            set { trvDepart = value; }
        }

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        public UcDepart()
        {
            InitializeComponent();

            ctxMenu.ImageList = imgLstMain;

            //为上下文菜单项定义单击事件.
            tspMnuAdd.ImageIndex = 4;
            tspMnuDel.ImageIndex = 5;
        }

        /// <summary>
        /// 加载部门树信息（这个函数为公用函数，在宿主应用程序时需要调用这个函以便在界面启动时加载树控件的数据）.
        /// </summary>
        public void Depart_Load()
        {
            trvDepart.Nodes[0].Expand();//展开船舶与陆地两个节点.
            this.loadAllTreeData(trvDepart.Nodes[0]);
            //trvDepart.SelectedNode = trvDepart.Nodes[0];  //界面刚打开时默认TopNode为根节点.
        }

        /// <summary>
        /// 加载部门树的所有节点（使用了递归算法，从最顶层开始）.
        /// </summary>
        /// <param name="curNode">树的根节点（必须传根节点，因为要从顶层节点开始）</param>
        private void loadAllTreeData(TreeNode curNode)
        {
            //调用FillTrViewDepart函数加载部门树的当前节点下的所有数据.
            this.FillTrViewDepart(curNode);

            //循环顶层节点下的所有子节点，为每个子节点加载数据.
            foreach (TreeNode theNode in curNode.Nodes)
            {
                loadAllTreeData(theNode);
            }
        }

        /// <summary>
        /// 为部门树trvDepart的当前节点加载数据.
        /// </summary>
        /// <param name="curNode">部门树trvDepart的当前节点</param>
        private void FillTrViewDepart(TreeNode curNode)
        {
            DataTable dtbDepart = null; //部门信息的DataTable对象.

            //在部门树当前节点加载数据前先删除掉以前存在的所有节点.
            curNode.Nodes.Clear();

            dtbDepart = T_DepartmentService.Instance.GetDepartment(curNode.Tag.ToString());
            if (dtbDepart.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dtbDepart.Rows)
                {
                    TreeNode newNode = new TreeNode();
                    string departmentId = dataRow["DepartmentId"].ToString();
                    string DEPARTNAME = dataRow["DEPARTNAME"].ToString();
                    string departType = dataRow["ISLANDDEPART"].ToString();

                    newNode.Tag = departmentId;
                    newNode.Name = departType;
                    newNode.Text = DEPARTNAME;

                    if (departType == "0")
                    {
                        newNode.ImageIndex = 1;
                        newNode.SelectedImageIndex = 1;
                    }
                    else if (departType == "1")
                    {
                        newNode.ImageIndex = 2;
                        newNode.SelectedImageIndex = 2;
                    }

                    curNode.Nodes.Add(newNode);
                }

                curNode.Expand();//展开当前节点.
            }
        }

        private void trvDepart_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (nodeSelect != null)
            {
                nodeSelect(sender, e);
            }
        }

        public event EventHandler nodeSelect;

        #region autoselect

        internal void locate(string p)
        {
            string deptId = PostService.Instance.getDept(p);
            SelectNodes(trvDepart, deptId);
        }

        private void SelectNodes(TreeView treeView, string detpId)
        {
            foreach (TreeNode n in treeView.Nodes)
            {
                SelectSubNodes(n, detpId);
            }
        }

        private void SelectSubNodes(TreeNode treeNode, string deptId)
        {
            if (treeNode.Tag.ToString().Equals(deptId))
            {
                trvDepart.SelectedNode = treeNode;
                return;
            }
            foreach (TreeNode tn in treeNode.Nodes)
            {
                SelectSubNodes(tn, deptId);
            }
        }

        #endregion

    }
}