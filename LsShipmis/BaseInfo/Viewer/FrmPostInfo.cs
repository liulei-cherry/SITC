/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmShipInfo.cs
 * 创 建 人：徐正本
 * 创建时间：2010-5-28
 * 标    题：船舶标准证书信息
 * 功能描述：实现船舶信息管理业务窗体上的相关功能
 * 修 改 人： 
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms; 
using CommonViewer.BaseControlService;
using CommonOperation.Interfaces;
using BaseInfo.DataAccess;
using BaseInfo.Objects; 

namespace BaseInfo.Viewer
{
    /// <summary>
    /// 船舶信息管理业务窗体.
    /// </summary>
    public partial class FrmPostInfo : CommonViewer.BaseForm.BaseMdiChildForm
    {
        #region 窗体单实例模型
        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmPostInfo instance = new FrmPostInfo();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmPostInfo Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmPostInfo.instance = new FrmPostInfo();
                }
                return FrmPostInfo.instance;
            }
        }
        #endregion
              
        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmPostInfo()
        {            
            InitializeComponent();
        }
        Department nowDepart;
        TreeNode nowNode;
       
        public void reloadData()
        {
            Department top1;//部门信息.
            DepartmentService.Instance.reloadTree(treeView1, out top1);//加载树形的部门信息.

            nowDepart = top1;
            nowNode = treeView1.Nodes[0];
            nowNode.ExpandAll();
        }
        /// <summary>
        /// 添加操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            Post nowPost = new Post("", nowDepart.GetId(), 0, "", "", 0, nowDepart.ISLANDDEPART,1, "");
            FrmEditOnePost formNew = new FrmEditOnePost(nowPost);
            formNew.ShowDialog();
            //当新添加数据时，刷新ucObjectsGridView1的值.
            if (formNew.NeedRetrieve)
            {
                retrieveOneNode(nowNode);
            }
        }
       
        /// <summary>
        /// 删除操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            ucPost1.DeleteObject();
            if (ucPost1.needRetrieve == true)
            {               
                retrieveOneNode(nowNode);
            }
        }

        /// <summary>
        /// 关闭窗体.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            ucPost1.UpdateObject(); 
        }

        #region IFunctionChildWindow 成员
      
        public new List<CommonOperation.BaseClass.Authority> GetAllAuthorityCanOpenThisWindow()
        {
            List<CommonOperation.BaseClass.Authority> re = new List<CommonOperation.BaseClass.Authority>();
            re.Add(CommonOperation.BaseClass.Authority.GetALoginUserAuthority());//最低权限即可.
            return re;
        }

        //本窗体不受限制.
        public new bool JudgeTheAuthorityCanOpenThisWindow(CommonOperation.BaseClass.Authority theAuthority)
        {
            return true;
        }

        private IFunctionMainWindow theMainForm;
        public new IFunctionMainWindow TheMainForm
        {
            get { return theMainForm; }
            set { theMainForm = value; }
        }

        #endregion

        private void FrmPortInfo_Load(object sender, EventArgs e)
        { 
            reloadData();
            
            this.setBindingSource();//设置数据源.
        }
        /// <summary>
        /// 设置备件基础信息的bindingSource数据源。.
        /// </summary>
        private void setBindingSource()
        {
            DataTable dt;
            string err;
            dt = PostService.Instance.getDepartPosts(string.IsNullOrEmpty (nowDepart.UPDEPARTID)?"":nowDepart.GetId(), out err);
            ucPostInfoList.DataSource = dt;
            ucPostInfoList.LoadGridView("FrmPostInfo.ucPostInfoList");
            ucPostInfoList.SetDgvGridColumns(PostService.Instance.GetObjectDisplaySetting());

        } 
        private void FrmPortInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            retrieveOneNode(e.Node);
        }
        private void retrieveOneNode(TreeNode nowNodeIn)
        {
            //判断当前是否需要展开下一级.
            List<string> cwbt = new List<string>();
            List<Department> lstDepartment = DepartmentService.Instance.GetDepartmentByParentId(((Department)nowNodeIn.Tag).GetId());
            if (nowNodeIn.Nodes.Count != lstDepartment.Count)
            {
                nowNodeIn.Nodes.Clear();
                int i = 0;
                foreach (Department department in lstDepartment)
                {
                    nowNodeIn.Nodes.Add(formATreeNode(department, false));
                    i++;
                }
            }
            
            //把当前节点的信息传给右边.
            try
            {                
                nowNode = nowNodeIn;
                nowDepart = (Department)nowNode.Tag;
                //先给右边制空,等后面刷数据处理.
                ucPost1.DirectlyChangeData(null);
                setBindingSource();                
            }
            catch { }
        }
        /// <summary>
        /// 生成一个树结点.
        /// </summary>
        /// <param name="component"></param>
        /// <param name="ifRoot"></param>
        /// <returns></returns>
        private TreeNode formATreeNode(Department department, bool ifRoot)
        {
            TreeNode newNode = new TreeNode();
            newNode.Name = department.GetId();
            newNode.Text = department.ToString();
            if (department.ISLANDDEPART == 1)
            {
                newNode.ImageKey = "company";

            }
            else
            {
                newNode.ImageKey = "ship";
            }
            newNode.SelectedImageKey = "open";
            newNode.Tag = department;
            return newNode;

        }
        
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button != MouseButtons.Left && e.Clicks != 1) return;
            TreeViewHitTestInfo info = treeView1.HitTest(e.X, e.Y);
            treeView1_AfterSelect(sender, new TreeViewEventArgs(e.Node));
            if (info.Location != TreeViewHitTestLocations.PlusMinus)
            {
                if (!e.Node.IsExpanded) e.Node.Expand(); 
            }
        }

        private void FrmPostInfo_FormClosing(object sender, FormClosingEventArgs e)
        { 
            ucPostInfoList.SaveGridView("FrmPostInfo.ucPostInfoList");
        }

        private void ucPostInfoList_SelectedChanged(int rowNumber)
        {
            if (rowNumber < ucPostInfoList.Rows.Count && rowNumber >= 0)
            {
                Post post = (Post)PostService.Instance.GetOneObjectById(ucPostInfoList.Rows[rowNumber].Cells["SHIP_HEADSHIP_ID"].Value.ToString());
                if (post != null && !post.IsWrong)
                {
                    ucPost1.ChangeData(post);
                    return;
                }
            }            
            ucPost1.ClearData();            
        }

        private void buttonEx1_Click(object sender, EventArgs e)
        {
            treeView1.SelectedNode = treeView1.Nodes[0].Nodes[0];
            treeView1.SelectedNode = treeView1.Nodes[0];
        }
    }
}