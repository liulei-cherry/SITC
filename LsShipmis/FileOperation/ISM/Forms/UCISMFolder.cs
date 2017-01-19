/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：UCISMFolder.cs
 * 创 建 人：牛振军
 * 创建时间：2008-05-12
 * 标    题：ISM模板类别树
 * 功能描述：文件夹用户对象。调用时，只需要实现 generateTree(string parentSign);参数标识为ISM模板根节点的父ID值，文档规定为COMPONYCOMMONFILES. 
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
using FileOperationBase.FileServices;
using FileOperation.Forms;
using FileOperationBase.Services;
using CommonOperation.Enum;
using CommonViewer.BaseControl;
namespace FileOperation.ISM.Forms
{
    public partial class UCISMFolder : UserControl
    {
        public UCISMFolder()
        {
            InitializeComponent();
            
        }
        public DataTable table;
        private DataView dvTree;
        public void generateTree()
        {
            TreeView.Nodes.Clear();
            table = FolderFileDbService.Instance.GetFolderTree("",true);
            if (table != null)
            {
                dvTree = new DataView(table);
                AddTree(TreeView.Nodes);
            }

            foreach (TreeNode tn in TreeView.Nodes)
            {
                string theNode = ((ourFolder)tn.Tag).NodeId;
                table = FolderFileDbService.Instance.GetFolderTree(theNode,true);

                if (table != null && table.Rows.Count > 0)
                {
                    AddTree(tn.Nodes);
                    tn.Expand();
                    foreach (TreeNode tn2 in tn.Nodes)
                    {
                        string theNode2 = ((ourFolder)tn2.Tag).NodeId;
                        table = FolderFileDbService.Instance.GetFolderTree(theNode2,true);
                        if (table != null && table.Rows.Count > 0)
                        {
                            AddTree(tn2.Nodes);
                            tn2.Expand();
                        }
                    }
                }
            }       
        }

        //   递归添加树的节点.
        private void AddTree(TreeNodeCollection Nds)
        {   
            //过滤ParentID,得到当前的所有子节点.
            //将tag值修改为保存ourFolder对象.
            TreeNode   tmpNd;
            ourFolder folder;

            DataRow[] dataRow = table.Select();
            this.Cursor = Cursors.WaitCursor;
            foreach (DataRow curRow in dataRow)
            {
                tmpNd = new TreeNode();
                folder = new ourFolder();
                tmpNd.Text = curRow["node"].ToString();
                folder.NodeName = curRow["node"].ToString();
                folder.NodeId = curRow["NODE_ID"].ToString();
                folder.ParentNodeId = curRow["PARENT_NODE_ID"].ToString();
                folder.ShipId = curRow["ship_Id"].ToString();
                folder.Node_Type = (decimal)curRow["Node_type"];
                tmpNd.Tag = folder;

                Nds.Add(tmpNd);
                if (!string.IsNullOrEmpty(folder.ShipId.Trim()) && tmpNd.Parent != null && !parentIsShip(tmpNd)) //.Parent.ImageIndex != 2)
                {
                    tmpNd.ImageIndex = 2;
                    tmpNd.SelectedImageIndex = 2;
                }
            }
            this.Cursor = Cursors.Default;

        }
        private bool parentIsShip(TreeNode node)
        {
            if (node.Parent != null)
            {
                if (node.Parent.ImageIndex == 2)
                {
                    return true;
                }
                else
                {
                    return parentIsShip(node.Parent);
                }

            }
            else
            {
                return false;
            }
        }

        //新增文件夹.
        private void insertFolder(TreeNode thisNode, TreeNode newNode)
        {
            ourFolder newFolder;
            ourFolder thisFolder;
            string err;

            thisFolder = new ourFolder();
            thisFolder =(ourFolder) thisNode.Tag;
            newFolder = new ourFolder();
            newFolder.NodeName = newNode.Text;
            newFolder.ParentNodeId = thisFolder.NodeId;
            newFolder.ShipId = thisFolder.ShipId;
            newFolder.Node_Type = (int)FileBoundingTypes.OTHERREPORTMODEL;

            if (FolderDbService.Instance.InsertAFolder(thisFolder, newFolder, out err))
            {
                newNode.Tag = newFolder;  //将节点值记入tag内.
            }
            else  //发生错误，显示错误信息.
            {
                MessageBoxEx.Show(err, "创建文件夹错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        //新增文件夹.
        private void insertFolder(TreeNode thisNode, TreeNode newNode,string shipId,int nodeTye)
        {
            ourFolder newFolder;
            ourFolder thisFolder;
            string err;

            thisFolder = new ourFolder();
            thisFolder = (ourFolder)thisNode.Tag;
            newFolder = new ourFolder();
            newFolder.NodeName = newNode.Text;
            newFolder.ParentNodeId = thisFolder.NodeId;
            newFolder.ShipId = shipId;
            newFolder.Node_Type = nodeTye;

            if (FolderDbService.Instance.InsertAFolder(thisFolder, newFolder, out err))
            {
                newNode.Tag = newFolder;  //将节点值记入tag内.
            }
            else  //发生错误，显示错误信息.
            {
                MessageBoxEx.Show(err, "创建文件夹错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //改名.
        private void rename_Click(object sender, EventArgs e)
        {

            if (TreeView.SelectedNode!=null)
            {
                TreeView.LabelEdit = true;               
                TreeView.SelectedNode.BeginEdit();    
            }
        }

        //文件夹改名操作.
        private void TreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            ourFolder folder = (ourFolder)TreeView.SelectedNode.Tag;
            string err;
            TreeView.SelectedNode.EndEdit(true);

            if (e.Label == null)
                return;
            if (e.Label.Length > 256)
            {
                MessageBoxEx.Show("文件夹名字不得超过256个字符", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (e.Label.Length == 0)
            {
                TreeView.SelectedNode.EndEdit(false);
                e.CancelEdit = true;
                return;
            }
            folder.NodeName = e.Label.Replace("'", "''");

            if (FolderDbService.Instance.UpdateAFolder(folder, out err) == false)
            {
                MessageBoxEx.Show(err, "文件夹改名失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TreeView.SelectedNode.EndEdit(false);                
            }
        }

        //展开与折叠操作.
        private void expand_Click(object sender, EventArgs e)
        {
            if (TreeView.SelectedNode != null)
            {
                TreeView.SelectedNode.Expand();
            }
        }

        private void collipse_Click(object sender, EventArgs e)
        {
            if (TreeView.SelectedNode != null)
            {
                TreeView.SelectedNode.Collapse();
            }
        }

        //删除文件夹.
        private void delete_Click(object sender, EventArgs e)
        {
            string err;
            ourFolder folder = new ourFolder();

            if (TreeView.SelectedNode.Parent == null)
            {
                MessageBoxEx.Show("不能删除根节点", "删除节点错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TreeView.SelectedNode != null)
            {
                if (MessageBoxEx.Show("是否删除选定的节点？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }
                folder = (ourFolder)TreeView.SelectedNode.Tag;
                if (FolderDbService.Instance.DeleteAFolder(folder, out err) == false)
                {
                    MessageBoxEx.Show(err, "删除文件夹失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TreeView.SelectedNode.Remove();
                }
            }
        }
        public delegate void loadFile(string node);

        //展开节点.
        private void expand_Click_1(object sender, EventArgs e)
        {
            TreeView.SelectedNode.Expand();
        }

        //折叠节点.
        private void collapse_Click(object sender, EventArgs e)
        {
            TreeView.SelectedNode.Collapse();
        }

        //导入文件到当前节点下.
        public void importFile_Click(object sender, EventArgs e)
        {
            TreeNode node;
            ourFolder folder;
            ourFile file;

            node = TreeView.SelectedNode;
            if (node == null)
            {
                return;
            }

            folder = new ourFolder();
            file = new ourFile();

            folder = (ourFolder)node.Tag;

            string[] a = null;
            ShowFrm(a, folder);

        }
        
        //加载文件导入窗口，此处只能导入模板文件.
        private void ShowFrm(string[] fileName, ourFolder folder)
        { 
            frmImportFile frmFile;
            frmFile = new frmImportFile();
            frmFile.Selfolder = folder;
            frmFile.dealFile(fileName);
            frmFile.templateType = "DOT";
            frmFile.orefFileId = "";
            frmFile.ShowDialog();
            
            if (AfterImportFiles != null)
            {
                AfterImportFiles(folder.NodeId);
            }        
        }

        //自定义方法.
        public delegate void MyDelegate(string nodeId);
        public event MyDelegate AfterImportFiles;
        public event MyDelegate TreeSelect;
        private void search_Click(object sender, EventArgs e)
        {
            TreeNode node;
            node = TreeView.SelectedNode;
            if (node == null)
            {
                return;
            }
            FileSearch ser = new FileSearch();
            ser.Folder  = (ourFolder)node.Tag;
            ser.ShowDialog();
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node;
            node = TreeView.SelectedNode;

            if (node == null)
            {
                return;
            }

            if (((ourFolder)node.Tag).Node_Type == (int)FileBoundingTypes.ISMFILESROOT)
            {
                addNewFolder.Visible = false;
                importFile.Visible = false;
            }
            else
            {
                addNewFolder.Visible = true;
                importFile.Visible = true;
            }
            if (TreeSelect != null)
            {
                TreeSelect(((ourFolder)TreeView.SelectedNode.Tag).NodeId);
            }

            if (node.GetNodeCount(false) != 0)
                return;
            #region 鼠标点击加载下级节点 
            string theNode = ((ourFolder)node.Tag).NodeId;
            table = FolderFileDbService.Instance.GetFolderTree(theNode, true);

            if (table != null)
            {
                dvTree = new DataView(table);
                AddTree(node.Nodes);
                node.Expand();
            }
            #endregion
        }

              //加载左侧树形结构.
        public void dataView(TreeView tr, DataTable dt)
        {
            tr.Nodes.Clear(); //清空原有数据.
            TreeNode tmpNd;
            foreach (DataRow row in dt.Rows)
            {
                tmpNd = new TreeNode();

                    tmpNd.Tag = row[0].ToString();  //代码规定第一个为索引的id
                    if (row[1].ToString().Length != 0)
                    {
                        tmpNd.Text =  row[1].ToString(); //代码规定第二个为显示的名称.
                    }
                    else
                    {
                        tmpNd.Text ="无相关设备"; //代码规定第二个为显示的名称.
                    }
                tr.Nodes.Add(tmpNd);
            }

        }

        //定义事件的委托.
        public delegate void NodeSelect(string nodeId);

        //文档类型事件指针.
        public event NodeSelect pdocTypeView;
        private void docTypeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = TreeView.SelectedNode;
            if (node != null)
            {
                if (pdocTypeView != null)
                {
                    pdocTypeView(node.Tag.ToString());
                }
            }
        }

        //新建船舶资料.
        void mnuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem mnu = (ToolStripItem)sender;
            TreeNode node = TreeView.SelectedNode;

            TreeNode tmp;
            tmp = new TreeNode(mnu.Text);
            //在TreeView组件中加入兄弟节点.
            TreeView.SelectedNode.Nodes.Add(tmp);
            insertFolder(TreeView.SelectedNode, tmp,mnu.Tag.ToString(),6001);
            TreeView.SelectedNode.Expand();
        }

        //新建文件夹.
        private void 新建文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //首先判断是否选定组件中节点的位置.
            if (TreeView.SelectedNode == null)
            {
                MessageBoxEx.Show("请选择一个节点", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //创建一个节点对象，并初始化.
                TreeNode tmp;
                tmp = new TreeNode("新建文件夹");
                //在TreeView组件中加入兄弟节点.
                TreeView.SelectedNode.Nodes.Add(tmp);
                insertFolder(TreeView.SelectedNode, tmp);
                TreeView.SelectedNode.Expand();
            }
        }
      
        private void mnuRefFiles_Click(object sender, EventArgs e)
        { 
            TreeNode node = TreeView.SelectedNode;
            if (node == null) return;
            ourFolder folder = (ourFolder)node.Tag;
            FileReference frf = new FileReference(folder,true);
            frf.ShowDialog();
            TreeSelect(folder.NodeId); //刷新引用结果.
        }

        private void 导出文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = TreeView.SelectedNode;
            ourFolder folder = new ourFolder();
            if (node != null)
            {
                folder = (ourFolder)node.Tag;
            }
            else
            {
                return;
            }
            FolderBrowserDialogEx.ShowDialog(folderBrowserDialog1);
            string path = folderBrowserDialog1.SelectedPath;
            if (path != null && path.Trim() != "")
            {
                FileOperationBase.Services.OutPortFolderFiles.GetFolders(folder, path);
                MessageBoxEx.Show("导出成功!");
            }
        }

        private void 下发文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = TreeView.SelectedNode;
            ourFolder folder = (ourFolder)node.Tag;
            if (folder == null) return;
            DataTable datfiles = FolderFileDbService.Instance.GetFileByFolder(folder.NodeId);
            List<string> fileIds = new List<string>();
            foreach (DataRow dr in datfiles.Rows)
            {
                fileIds.Add(dr["FILE_ID"].ToString());
            }

            FrmFilesDistribute frm = new FrmFilesDistribute(folder.NodeId, Convert.ToInt32(folder.Node_Type), 1, fileIds);
            frm.ShowDialog();
        }
    }

}
