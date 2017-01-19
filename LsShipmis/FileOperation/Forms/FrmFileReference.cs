using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FileOperationBase.FileServices;
using FileOperationBase.Services;
using CommonViewer.BaseControl;
namespace FileOperation.Forms
{
    public partial class FileReference : CommonViewer.BaseForm.FormBase
    {
        private ourFolder Folder;
        private ourFolder toFolder;
        public string TheSelectedFileId;
        private bool mustOne = false;
        public FileReference()
        {
            InitializeComponent();
            mustOne = true;
        }

        private bool onlyIsm = false;
        public FileReference(bool onlyIsm)
        {
            InitializeComponent();
            mustOne = true;
            this.onlyIsm = onlyIsm;
        }
        public FileReference(ourFolder toFolder, bool onlyIsm)
        {
            InitializeComponent();
            this.toFolder = toFolder;
            this.onlyIsm = onlyIsm;
        }
        //搜索.
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (Folder == null) return;

            DataTable dv;
            string[] txt = { };
            txtKey.Text.Replace('，', ',');  //替换错误的中文全角字符.
            txtKey.Text = txtKey.Text.Trim().Replace("'", "''");

            if (txtKey.Text.Trim() != "")
            {
                txt = txtKey.Text.Split(',');
            }
            List<string> list = new List<string>(txt);
            dv = FileDbService.Instance.GetFilesBySelect(this.txtCreator.Text, this.dateStart.Value, this.dateEnd.Value, list, Folder.NodeId, Folder.ShipId);
            ucFile.LoadFile(dv);
        }

        private void uc_fileSelected(string path)
        {
            fPath.Text = path;
        }

        private void FileSearch_Load(object sender, EventArgs e)
        {
            ucFolder.tabControl.TabPages.RemoveAt(1);
            this.dateEnd.Value = DateTime.Now;
            ucFile.filePath += new UCFile.SelectedFilePath(uc_fileSelected);

            ucFile.FileList.Columns[0].Width = 180;
            ucFile.FileList.Columns[2].Width = 100;
            ucFolder.OnlyIsm = onlyIsm;
            ucFolder.generateTree();
            ucFolder.TreeSelect += new UCFolder.MyDelegate(ucFolder_TreeSelect);
            ucFile.contextMenuStrip.Items[0].Visible = false;
            ucFile.contextMenuStrip.Items[2].Visible = false;
            ucFile.contextMenuStrip.Items[3].Visible = false;
        }

        void ucFolder_TreeSelect()
        {
            ucFile.FileList.Items.Clear();
            TreeNode node = ucFolder.TreeView.SelectedNode;
            this.Text = "当前搜索路径为：" + node.FullPath + " 及其子目录下所有文件";
            if (node != null)
            {
                Folder = (ourFolder)node.Tag;
                ucFile.LoadFile(Folder.NodeId, Folder.NodeName);
            }
        }

        //保存引用的文件到相应的toFolder节点下.
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (mustOne)
            {
                if (string.IsNullOrEmpty(ucFile.TheSelectedFileId))
                    MessageBoxEx.Show("没有选择任何内容！");
                else
                {
                    TheSelectedFileId = ucFile.TheSelectedFileId;
                    this.Close();
                }
                return;
            }
            if (ucFile.FileList.SelectedItems.Count <= 0) return;
            List<string> a = new List<string>();
            string err;

            foreach (ListViewItem it in ucFile.FileList.SelectedItems)
            {
                a.Add(((string)it.Tag).Trim());
            }
            if (FolderFileDbService.Instance.refFiles(toFolder.NodeId, a, out err) == false)
            {
                MessageBoxEx.Show(err, "文件引用错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}