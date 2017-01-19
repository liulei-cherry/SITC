using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FileOperationBase.FileServices;
using FileOperationBase.Services;
using BaseInfo.DataAccess;
using CommonOperation.Enum;
using CommonViewer.BaseControl;

namespace FileOperation.Forms
{
    public partial class UcFilesDistribute : UserControl
    {
        public UcFilesDistribute()
        {
            InitializeComponent();
        } 
        string err="";
        string ShipParentNode = "";
        int selectedone=0;
        int foldertype;
        public List<ourFolder> Folders;
        private string sourceFolderId;

        /// <summary>
        /// 加载ISM视图的船舶文件夹.
        /// </summary>
        /// <param name="folderType">源文件夹类型</param>
        public void LoadIsmFolders(string folderId, int folderType)
        {
            foldertype = folderType;
            sourceFolderId = folderId;
            DataTable ismDataTable = FolderDbService.Instance.GetIsmShipView(out err);
            ourFolder rootFolder = FolderDbService.Instance.getFolderByFolderType(FileBoundingTypes.ISMFILESROOT);
            ShipParentNode = rootFolder.NodeId;
            if (ismDataTable != null)
            {
                treeView.Nodes.Clear();
                AddTree(ismDataTable, treeView.Nodes, rootFolder.ParentNodeId);
            }
            treeView.ExpandAll();
        }

        /// <summary>
        /// 加载普通文档视图的船舶文件夹.
        /// </summary>
        /// <param name="folderType">源文件夹类型</param>
        public void LoadCommonFolders(string folderId, int folderType)
        {
            foldertype = folderType;
            sourceFolderId = folderId;
            DataTable commonDataTable = FolderDbService.Instance.GetCommonShipView(out err);
            ourFolder commonRoot = FolderDbService.Instance.getFolderByFolderType(FileBoundingTypes.COMMONFILESROOT);

            ShipParentNode = (commonRoot == null ? null : commonRoot.NodeId);
            if (commonDataTable != null && ShipParentNode!= null)
            {
                treeView.Nodes.Clear();
                AddTree(commonDataTable, treeView.Nodes, commonRoot.ParentNodeId);
            }
            
        }

        //   递归添加树的节点.
        private void AddTree(DataTable table, TreeNodeCollection Nds, string PARENT_NODE_ID)
        {

            //过滤ParentID,得到当前的所有子节点.
            //将tag值修改为保存ourFolder对象.
            TreeNode tmpNd;
            ourFolder folder;

            DataRow[] dataRow = table.Select(" PARENT_NODE_ID " + (string.IsNullOrEmpty( PARENT_NODE_ID )? "is null": " = '" + PARENT_NODE_ID+ "' "));
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
                if (folder.ParentNodeId.Equals(ShipParentNode))
                {
                    selectedone = 0;
                }
                if (folder.ParentNodeId.Equals(ShipParentNode) && !String.IsNullOrEmpty(folder.ShipId))
                {
                    tmpNd.ImageIndex = 1;
                    tmpNd.SelectedImageIndex = 1;
                    selectedone=1;
                }
                if (selectedone == 1)
                {
                    if (folder.Node_Type == foldertype)
                    {
                        tmpNd.Checked = true;
                        selectedone = 3;
                    }
                }
                
                Nds.Add(tmpNd);

                AddTree(table,tmpNd.Nodes,folder.NodeId);

            }
            this.Cursor = Cursors.Arrow;

        }

        public bool getDistributeFolders()
        {
            List<ourFolder> folders = new List<ourFolder>();
            if (treeView.Nodes.Count == 0) return false;
            FindNode(treeView.Nodes[0], folders);
            //检验是否有重复的选择.
            int total = folders.Count;
            for (int i = 0; i < total; i++)
            {
                for (int j = i + 1; j < total; j++)
                {
                    if (string.IsNullOrEmpty(folders[i].ShipId.Trim())) 
                    {
                        continue;
                    }
                    if (folders[i].ShipId.Equals(folders[j].ShipId))
                    {
                        string shipName = ShipInfoService.Instance.getObject(folders[i].ShipId, out err).ToString();
                        DialogResult result = MessageBoxEx.Show("船舶" + shipName + "的接收文件夹选择重复，是否确认下发重复的信息？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result.Equals(DialogResult.No))
                        {
                            return false;
                        }
                    }
                }
            }
            Folders = folders;
            return true;
        }

        private void FindNode(TreeNode tnParent,List<ourFolder> folders)
        {

            if (tnParent == null) return;
            foreach (TreeNode tn in tnParent.Nodes)
            {
                if (tn.Checked && ((ourFolder)tn.Tag).NodeId!=sourceFolderId)
                {
                    folders.Add((ourFolder)tn.Tag);
                }
                FindNode(tn, folders);
            }
        }

    }
}
