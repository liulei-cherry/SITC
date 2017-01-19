/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：UCFolder.cs
 * 创 建 人：牛振军
 * 创建时间：2008-05-12
 * 标    题：目录树的加载
 * 功能描述：文件夹用户对象。调用时，只需要实现 generateTree(string rootId,string shipID);  第一个参数为指定树的根父节点ID，第二个参数为船舶id
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
using System.IO;
using FileOperationBase.FileServices;
using FileOperationBase.Services;
using CommonOperation.Enum;
using CommonViewer.BaseControl;
using CommonViewer.BaseForm;
namespace FileOperation.Forms
{
    public partial class UCFolder : UserControl
    {
        bool onlyIsm = false;

        public bool OnlyIsm
        {
            get { return onlyIsm; }
            set { onlyIsm = value; }
        }
        public UCFolder()
        {
            InitializeComponent();
        }
        public UCFolder(bool onlyISM)
        {
            this.onlyIsm = onlyISM;
            InitializeComponent();
        }
        public DataTable table;
        private DataView dvTree;

        public void generateTree()
        {
            TreeView.Nodes.Clear();
            table = FolderFileDbService.Instance.GetFolderTree("", onlyIsm);
            if (table != null)
            {
                dvTree = new DataView(table);
                AddTree(TreeView.Nodes);
            }

            foreach (TreeNode tn in TreeView.Nodes)
            {
                string theNode = ((ourFolder)tn.Tag).NodeId;
                table = FolderFileDbService.Instance.GetFolderTree(theNode, onlyIsm);

                if (table != null && table.Rows.Count > 0)
                {
                    AddTree(tn.Nodes);
                    tn.Expand();
                    foreach (TreeNode tn2 in tn.Nodes)
                    {
                        string theNode2 = ((ourFolder)tn2.Tag).NodeId;
                        table = FolderFileDbService.Instance.GetFolderTree(theNode2, onlyIsm);
                        if (table != null && table.Rows.Count > 0)
                        {
                            AddTree(tn2.Nodes);
                            if (CommonOperation.ConstParameter.IsLandVersion)
                                tn2.Collapse();
                            else tn2.Expand();
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
            TreeNode tmpNd;
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
                folder.ShipId = curRow["ship_id"].ToString();
                if (curRow["FSORT"] != DBNull.Value) folder.Fsort = (decimal)curRow["FSORT"];
                folder.Node_Type = (decimal)curRow["NODE_TYPE"];

                tmpNd.Tag = folder;
                tmpNd.ToolTipText = "文件夹类型：" + folder.Node_Desc.Trim();
                Nds.Add(tmpNd);
                if (!string.IsNullOrEmpty(folder.ShipId.Trim()) && !parentIsShip(tmpNd)) //.Parent.ImageIndex != 2)
                {
                    tmpNd.ImageIndex = 2;
                    tmpNd.SelectedImageIndex = 2;
                }
                // AddTree(tmpNd.Nodes, curRow["node_id"].ToString());
            }

            TreeView.Refresh();
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

        //新增文件夹菜单.
        private void newFolder_Click(object sender, EventArgs e)
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

        //新增文件夹.
        private void insertFolder(TreeNode thisNode, TreeNode newNode)
        {
            ourFolder newFolder;
            ourFolder thisFolder;
            string err;

            thisFolder = new ourFolder();
            thisFolder = (ourFolder)thisNode.Tag;
            newFolder = new ourFolder();
            newFolder.NodeName = newNode.Text;
            newFolder.ParentNodeId = thisFolder.NodeId;
            newFolder.ShipId = thisFolder.ShipId;
            if (thisFolder.Node_Type != (int)(FileBoundingTypes.COMMONFILESROOT)
                && thisFolder.Node_Type != (int)(FileBoundingTypes.COMPONYFILES))
                newFolder.Node_Type = thisFolder.Node_Type;
            else
                newFolder.Node_Type = (int)(FileBoundingTypes.COMMONDIR);

            if (FolderDbService.Instance.InsertAFolder(thisFolder, newFolder, out err))
            {
                newNode.ToolTipText = "文件夹类型：" + newFolder.Node_Desc;
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

            if (TreeView.SelectedNode != null)
            {
                TreeView.LabelEdit = true;
                TreeView.SelectedNode.BeginEdit();
            }
        }

        //文件夹改名操作.
        private void TreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            ourFolder folder;
            string err;
            folder = (ourFolder)TreeView.SelectedNode.Tag;

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
            ourFolder folder;

            if (TreeView.SelectedNode.Parent == null)
            {
                MessageBoxEx.Show("不能删除根节点", "删除节点错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TreeView.SelectedNode != null && TreeView.SelectedNode.Tag != null)
            {
                if (MessageBoxEx.Show("是否删除选定的节点？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }
                folder = (ourFolder)TreeView.SelectedNode.Tag;
                if (folder.Node_Type != 5 && folder.Fsort <= 0)
                {
                    MessageBoxEx.Show("不允许删除初始化的节点？", "删除提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
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

        //导入文件到当前节点下.
        public void importFile_Click(object sender, EventArgs e)
        {
            TreeNode node;
            ourFolder folder;
            node = TreeView.SelectedNode;
            if (node == null)
            {
                return;
            }
            folder = (ourFolder)node.Tag;
            string[] a;
            a = null;
            ShowFrm(a, folder);
        }

        //加载文件导入窗口.
        private void ShowFrm(string[] fileName, ourFolder folder)
        {
            ImportFile frmFile;
            frmFile = new ImportFile();
            frmFile.Selfolder = folder;
            frmFile.dealFile(fileName);
            frmFile.ShowDialog();

            if (AfterImportFiles != null)
            {
                AfterImportFiles();
            }
        }

        //自定义方法.
        public delegate void MyDelegate();
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
            ser.Folder = (ourFolder)node.Tag;
            ser.searchPath = node.FullPath;
            ser.ShowDialog();
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node;
            node = TreeView.SelectedNode;

            if (node == null || node.Tag == null)
            {
                return;
            }

            #region 控制鼠标右键菜单
            if (((ourFolder)node.Tag).Node_Type >= 5000)
            {
                foreach (ToolStripItem it in contextMenuStrip.Items)
                {
                    it.Enabled = false;
                }
                search.Enabled = true;
                TreeView.AllowDrop = false;
            }
            else
            {
                foreach (ToolStripItem it in contextMenuStrip.Items)
                {
                    it.Enabled = true;
                }
                TreeView.AllowDrop = true;
            }

            #endregion

            if (TreeSelect != null)
            {
                TreeSelect();
            }

            if (node.GetNodeCount(false) != 0)
                return;
            string theNode = ((ourFolder)node.Tag).NodeId;
            table = FolderFileDbService.Instance.GetFolderTree(theNode, onlyIsm);

            if (table != null && table.Rows.Count > 0)
            {
                dvTree = new DataView(table);
                AddTree(node.Nodes);
                node.Expand();
            }

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
                    tmpNd.Text = row[1].ToString(); //代码规定第二个为显示的名称.
                }
                else
                {
                    tmpNd.Text = "无相关信息"; //代码规定第二个为显示的名称.
                }
                tr.Nodes.Add(tmpNd);
            }

        }

        //判断加载哪个类型的标签页.
        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            DataTable dat;
            switch (tabControl.SelectedIndex)
            {
                case 1: //维护者.
                    dat = FolderFileDbService.Instance.Operator();
                    dataView(operatorView, dat);
                    break;
            }
        }

        //定义事件的委托.
        public delegate void NodeSelect(string nodeId);

        //操作者事件指针.
        public event NodeSelect poperatorView;
        private void operatorView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = operatorView.SelectedNode;
            if (node != null)
            {
                if (poperatorView != null)
                {
                    poperatorView(node.Tag.ToString());
                }
            }
        }

        //动态加载文件夹的类别.
        private void LodaFolderTypeMenu()
        {
            foreach (FileBoundingTypes tempType in EnumConfig.Instance.FileBoundingTypesDetail.Keys)
            {
                if ((!onlyIsm && ((int)tempType > 0 && (int)tempType < 5000)) || (onlyIsm && (int)tempType >= 5000))
                {
                    ToolStripItem mnuItem = new ToolStripMenuItem();
                    mnuItem.Tag = (int)tempType;
                    mnuItem.Text = EnumConfig.Instance.GetFolderDetail(tempType);
                    mnuItem.Click += new EventHandler(mnuItem_Click);
                    mnuFolderType.DropDownItems.Add(mnuItem);
                }
            }
        }

        //修改文件夹的类别.
        void mnuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem mnu = (ToolStripItem)sender;
            TreeNode node = TreeView.SelectedNode;

            if (node != null)
            {
                ourFolder folder = (ourFolder)node.Tag;
                string err;
                decimal tmp = folder.Node_Type;
                string shipid;
                folder.Node_Type = (decimal)mnu.Tag;
                shipid = folder.ShipId;

                if (tmp == folder.Node_Type) return;

                if (FolderDbService.Instance.UpdateAFolder(folder, out err) == false)
                {
                    MessageBoxEx.Show(err, "文件夹修改类别失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    folder.Node_Type = tmp;
                    folder.ShipId = shipid;
                }
                else
                {
                    node.ToolTipText = "文件夹类型：" + folder.Node_Desc.Trim();
                    MessageBoxEx.Show("更新类型成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        //加载鼠标右键.
        private void UCFolder_Load(object sender, EventArgs e)
        {
            LodaFolderTypeMenu();
        }

        //文件引用的过程.
        private void ToolStripFileRef_Click(object sender, EventArgs e)
        {
            TreeNode node = TreeView.SelectedNode;
            if (node == null) return;
            ourFolder folder = (ourFolder)node.Tag;
            FileReference frf = new FileReference(folder, onlyIsm);
            frf.ShowDialog();
            TreeSelect();
        }

        private void 导出文件ToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void 文件下发ToolStripMenuItem_Click(object sender, EventArgs e)
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

            FrmFilesDistribute frm = new FrmFilesDistribute(folder.NodeId, Convert.ToInt32(folder.Node_Type), 0, fileIds);
            frm.ShowDialog();

        }

        private void 导入文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = TreeView.SelectedNode;
            pFoloder = new ourFolder();
            if (node != null)
            {
                pFoloder = (ourFolder)node.Tag;
            }
            else
            {
                return;
            }
            FolderBrowserDialogEx.ShowDialog(folderBrowserDialog1);
            path = folderBrowserDialog1.SelectedPath;
            if (path != null && path.Trim() != "")
            {
                min = 0;
                max = 100;
                frmBusyWithStep = new FrmBusyWithStep("正在导入所选目录下的所有文件，请稍后！",
                     new FrmBusyWithStep.FinishedOpeartion(importFolders));
                frmBusyWithStep.ShowDialog();
                MessageBoxEx.Show("导入成功，请重新打开文档界面");
            }

        }
        FrmBusyWithStep frmBusyWithStep;
        string path;
        ourFolder pFoloder;
        int min = 0, max = 100;
        //导入文件夹及其下的文件，递归导入.
        private void importFolders()
        {
            string thisPath = path;
            ourFolder pThisFoloder = pFoloder;
            int thisMin = min;
            int thisMax = max;
            string err;
            string[] files = Directory.GetFiles(thisPath);
            int allFileCount = files.Length;

            string[] Directorys = Directory.GetDirectories(thisPath);
            int allDirCount = Directorys.Length;
            int allItems = allFileCount + allDirCount * 4;
            if (allItems == 0) return;
            for (int i = 0; i < allFileCount; i++)
            {
                string ofile = files[i];
                ourFile file = new ourFile();
                FileInfo fl = new FileInfo(ofile);

                file.Creator = "";
                file.ObjectLabel = fl.Name;
                file.FileName = fl.Name;

                file.Size = fl.Length;
                file.CreateDate = DateTime.Today;
                //file.RefEquipment =;
                file.ShipId = pThisFoloder.ShipId;
                frmBusyWithStep.ChangeStep("正在导入" + ofile, thisMin + i * (thisMax - thisMin) / allItems);
                if (FolderFileDbService.Instance.InsertAFile(pThisFoloder.NodeId, file, ofile, out err) == false)
                {
                    this.Cursor = Cursors.Arrow;
                    MessageBoxEx.Show(err, "插入文件出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            int lastMin = thisMin + allFileCount *  (thisMax - thisMin)  / allItems;
            for (int i = 0; i < allDirCount; i++)
            {
                string dir = Directorys[i];
                //创建一个节点对象，并初始化.
                DirectoryInfo ddi = new DirectoryInfo(dir);
                pFoloder = FolderDbService.Instance.getOrCreateSubFolderByName(pThisFoloder,ddi.Name);
                path = dir;
                min = lastMin;
                max = lastMin + (i+1) * 4 * (thisMax - thisMin) / allItems;
                lastMin = max;
                importFolders();
            }
        }

    }

}
