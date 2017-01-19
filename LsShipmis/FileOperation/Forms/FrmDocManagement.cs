using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FileOperationBase.FileServices;
using FileOperationBase.Services;

namespace FileOperation.Forms
{
    public partial class FrmDocManagement : CommonViewer.BaseForm.FormBase
    {
        private FrmDocManagement()
        {
            InitializeComponent();

            FolderDbService.Instance.CheckingUsefullessFolderType();
            //选择一个文件夹导入文件后激发的事件，此例用于更新右侧ListView的文件显示.
            ucFolder.TreeSelect += new UCFolder.MyDelegate(ucFolder_TreeSelect);
            ucFolder.AfterImportFiles += new UCFolder.MyDelegate(ucFolder_AfterImportFiles);
            ucFolder.poperatorView += new UCFolder.NodeSelect(ucFolder_poperatorView);
            ucFolder.generateTree();
        }
        #region 构造函数

        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static FrmDocManagement instance = new FrmDocManagement();
        public static FrmDocManagement Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmDocManagement.instance = new FrmDocManagement();
                }
                return FrmDocManagement.instance;
            }
        }
        #endregion

        //操作者视图.
        void ucFolder_poperatorView(string nodeId)
        {
            ucFile.FileList.Items.Clear();
            DataTable dat; 
            dat = FolderFileDbService.Instance.operatorView(nodeId);
            ucFile.LoadFile(dat);
        }
     
        //点击左侧文件夹节点，加载右侧treeview的文件.
        void ucFolder_TreeSelect()
        {
            ucFile.FileList.Items.Clear();
            TreeNode node = ucFolder.TreeView.SelectedNode;
            if (node != null)
            {
                ourFolder ourf = (ourFolder)node.Tag;
                ucFile.LoadFile(ourf.NodeId,ourf.NodeName);
            }
        }

        void ucFolder_AfterImportFiles()
        {
            ucFile.FileList.Items.Clear();
            TreeNode node = ucFolder.TreeView.SelectedNode;
            if (node != null)
            {
                ourFolder ourf = (ourFolder)node.Tag;
                ucFile.LoadFile(ourf.NodeId, ourf.NodeName);
            }
        }

        private void FrmDocManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEx1_Click(object sender, EventArgs e)
        {
            ucFile.LoadFile("","");
            ucFolder.generateTree();
        }

     

    }
}