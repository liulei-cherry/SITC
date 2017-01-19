/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 创 建 人：夏喜龙
 * 创建时间：2011-5-12
 * 功能描述：船舶设备分类信息管理的相关功能
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
using CommonOperation.BaseClass;
using CommonViewer.BaseControlService;
using CommonOperation.Interfaces;
using BaseInfo.DataAccess;
using BaseInfo.Objects;
using System.Runtime.InteropServices;
using Maintenance.DataObject;
using Maintenance.Services;
using CommonViewer.BaseControl;

namespace Maintenance.Viewer
{
    /// <summary>
    /// 船舶分类信息管理窗体.
    /// </summary>
    /// 
    public partial class FrmWorkinfoTempletClass : CommonViewer.BaseForm.BaseMdiChildForm
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmWorkinfoTempletClass instance = new FrmWorkinfoTempletClass();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmWorkinfoTempletClass Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmWorkinfoTempletClass.instance = new FrmWorkinfoTempletClass();
                }
                return FrmWorkinfoTempletClass.instance;
            }
        }
        #endregion

        #region 窗体对象

        T_WORKINFO_TEMPLATE_CLASS templateClass;
        TreeNode nowNode;

        #endregion

        /// <summary>
        /// 主窗体加载.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPortInfo_Load(object sender, EventArgs e)
        {
            reloadData();
        }

        /// <summary>
        /// 加载tree初始数据.
        /// </summary>
        public void reloadData()
        {
            //加载根节点.
            TreeNode rootNode = new TreeNode("工作模板分类");
            rootNode.Tag = "root";
            rootNode.ImageKey = "root";
            treeView1.Nodes.Add(rootNode);

            //界面刚打开时把根节点变为当前节点.
            treeView1.SelectedNode = treeView1.Nodes[0];
            treeView1.ExpandAll();
        }

        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmWorkinfoTempletClass()
        {
            InitializeComponent();
        }

        /// <summary>
        /// tree节点选取事件.
        /// </summary>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            treenodeClick(e.Node);
        }

        /// <summary>
        /// 点击tree节点实现相关功能.
        /// </summary>
        private void treenodeClick(TreeNode tn)
        {
            //把当前节点的信息传给右边.
            showNode(tn);

            //判断当前是否需要展开下一级.
            string objectID = "root".Equals(tn.Tag) ? "" : ((CommonClass)tn.Tag).GetId();

            List<T_WORKINFO_TEMPLATE_CLASS> lists = T_WORKINFO_TEMPLATE_CLASSService.Instance.GetObjectsByParentId(objectID);

            tn.Nodes.Clear();
            foreach (T_WORKINFO_TEMPLATE_CLASS tempObject in lists)
            {
                tn.Nodes.Add(formATreeNode(tempObject, false));
            }

            treeView1.Refresh();

            //展开当前节点.
            tn.Expand();

        }

        /// <summary>
        /// 显示节点信息.
        /// </summary>
        private void showNode(TreeNode tn)
        {
            //把当前节点的信息传给右边.
            nowNode = tn;               //更新当前节点信息.
            if (!"root".Equals(tn.Tag))
            {
                templateClass = (T_WORKINFO_TEMPLATE_CLASS)nowNode.Tag;
                txtName.Text = templateClass.NODE_NAME;
                numSortNo.Value = templateClass.SORTNO;
            }
            else
            {
                templateClass = null;
                txtName.Text = "";
                numSortNo.Value = 0;
            }

        }

        /// <summary>
        /// 生成一个新的树结点.
        /// </summary>
        private TreeNode formATreeNode(T_WORKINFO_TEMPLATE_CLASS node, bool ifRoot)
        {
            TreeNode newNode = new TreeNode();
            newNode.Name = node.GetId();
            newNode.Text = node.NODE_NAME;
            newNode.Tag = node;

            newNode.ImageKey = "base";
            newNode.SelectedImageKey = "open";
            return newNode;

        }

        /// <summary>
        /// 添加操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            string supID = null;
            if (templateClass != null)
            {
                supID = templateClass.GetId();
            }

            T_WORKINFO_TEMPLATE_CLASS tempObject = new T_WORKINFO_TEMPLATE_CLASS(null, "", supID,99);
            FrmWorkinfoTempletClassEdit formNew = new FrmWorkinfoTempletClassEdit(tempObject);

            formNew.ShowDialog();
            //当新添加数据时，刷新tree
            if (nowNode != null)
            {
                treenodeClick(nowNode);
            }

        }

        /// <summary>
        /// 删除操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {

            if (templateClass != null && nowNode.Nodes.Count == 0)
            {
                string err;
                DialogResult response = MessageBoxEx.Show("您确定要删除该条数据吗？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (response == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                if (templateClass.Delete(out err))
                {
                    MessageBoxEx.Show("删除成功!", "", new MessageBoxButtons(), MessageBoxIcon.Information);
                    treeView1.SelectedNode.Remove();
                }
                else
                {
                    MessageBoxEx.Show("当前对象删除失败,错误原因是:\n\n" + err, "", new MessageBoxButtons(), MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBoxEx.Show("当前节点不能删除!", "", new MessageBoxButtons(), MessageBoxIcon.Warning);
            }

        }

        /// <summary>
        /// 保存操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {

            string err;

            if (templateClass != null && nowNode != null && nowNode.Parent != null)
            {

                //对象赋值.
                templateClass.NODE_NAME = txtName.Text;
                templateClass.SORTNO = int.Parse(numSortNo.Value.ToString());

                //对象校验.
                if (string.IsNullOrEmpty(templateClass.NODE_NAME))
                {
                    MessageBoxEx.Show("分类名称不允许为空!","",new MessageBoxButtons(),MessageBoxIcon.Warning);
                    txtName.Focus();
                    return;
                }

                //保存对象.
                if (!T_WORKINFO_TEMPLATE_CLASSService.Instance.saveUnit(templateClass, out err))
                {
                    MessageBoxEx.Show(err);
                    return;
                }
                else
                {
                    MessageBoxEx.Show("保存成功!", "", new MessageBoxButtons(), MessageBoxIcon.Information);
                    //刷新节点.
                    if (nowNode != null && nowNode.Parent != null)
                    {
                        nowNode = nowNode.Parent;

                        treenodeClick(nowNode);
                    }
                }

            }
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

        /// <summary>
        /// 主窗体关闭.
        /// </summary>
        private void FrmWorkinfoTempletClass_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
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

    }
}