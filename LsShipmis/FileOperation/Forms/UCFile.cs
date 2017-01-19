/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：UCFile.cs
 * 创 建 人：牛振军
 * 创建时间：2008-05-12
 * 标    题：文件管理
 * 功能描述：文件用户对象。调用时，只需要实现 AddTree(TreeView.Nodes, "0");  第一个参数不要动，第二个参数为根文件夹的标识
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
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using FileOperationBase.FileServices;
using FileOperationBase.Services;
using System.Runtime.InteropServices;
using CommonOperation.BaseClass;
using CommonViewer;
using BaseInfo.DataAccess;
using CommonViewer.BaseControl;

namespace FileOperation.Forms
{
    public partial class UCFile : UserControl
    {

        private ListViewColumnSorter lvwColumnSorter;
        public string shipId;
        public string nodeName;
        public string nodeId;
        public string TheSelectedFileId;
        public right oright {
            get { return _oright; }
            set {
                _oright = value;
                if (value == right.R)
                {
                    //contextMenuStrip.Enabled = false;
                    //contextMenuStrip.Items[0].Enabled = false;
                    //contextMenuStrip.Items[1].Enabled = true;
                    //contextMenuStrip.Items[2].Enabled = false;
                    //contextMenuStrip.Items[3].Enabled = false;
                    //contextMenuStrip.Items[4].Enabled = false;
                    ToolStripMenuAdd.Enabled = false;
                    导出文件ToolStripMenuItem.Enabled = true;
                    文件下发ToolStripMenuItem.Enabled = false;
                    ToolStripMenuEdit.Enabled = false;
                    ToolStripMenuDelete.Enabled = false;
                    重命名ToolStripMenuItem.Enabled = false;                    
                }
                else
                {
                    contextMenuStrip.Enabled = true;
                    ToolStripMenuAdd.Enabled = true;
                    导出文件ToolStripMenuItem.Enabled = true;
                    文件下发ToolStripMenuItem.Enabled = true;
                    ToolStripMenuEdit.Enabled = true;
                    ToolStripMenuDelete.Enabled = true;
                    重命名ToolStripMenuItem.Enabled = true;  
                }
            }
        }

        private right _oright;
        private List<openFile> oFile;

        public UCFile()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            this.FileList.ListViewItemSorter = lvwColumnSorter;
            oFile = new List<openFile>();    
            
        }
        //正式方法.
        public void LoadFile(string NodeId,string name)
        {
            nodeId = NodeId;
            //ToolStripMenuAdd.Enabled = !string.IsNullOrEmpty(nodeId);//liulei-2016/01/12修改,增加权限判断
            ToolStripMenuAdd.Enabled =( oright != right.R && !string.IsNullOrEmpty(nodeId));
            clearFileInfo();
            DataTable table;
            this.Cursor = Cursors.WaitCursor;
            table = FolderFileDbService.Instance.GetFileByFolder(NodeId);
            loadFile(table);
            checkMenu();
            if (!string.IsNullOrEmpty(name))
            {
                groupBox1.Text = "[" + name + "]目录中的文件情况";
            }
            this.Cursor = Cursors.Arrow;
        }

        private void clearFileInfo()
        {
            txtKeyWords.Text = "";
            Operator.Text = "";
            optDate.Text = "";
            txtSize.Text = "";            
            txtshipInfo.Text = "";
            TheSelectedFileId = "";
        }

        //重构加载文件方法.
        public void LoadFile(DataTable table)
        {
            ToolStripMenuAdd.Enabled = false;
            loadFile(table);
        }

        //重构加载文件方法.
        private void loadFile(DataTable table)
        {
            groupBox1.Text = "目录中的文件情况";
            DataView dvTree;
            int i = 0;
            dvTree = new DataView(table);
            imageListSmall.Images.Clear();
            FileList.Items.Clear();
            ListViewItem[] Listitem = new ListViewItem[dvTree.Count];
            List<string> fileIco = new List<string>();
            List<string> fileExt = new List<string>();
         
            foreach (DataRowView drv in dvTree)
            {

                string desc;
                string typeinfo;
                FileInfo theFile;
                ListViewItem item;
                Cursor.Current = Cursors.WaitCursor;

                #region 获取文件图标和扩展名
                if (!string.IsNullOrEmpty(drv["FILE_NAME"].ToString()))
                {
                    #region file type
                    theFile = new FileInfo(drv["FILE_NAME"].ToString());
                    item = new ListViewItem(drv["FILE_NAME"].ToString());

                    FileSize fs = new FileSize(long.Parse(drv["FSize"].ToString()));
                    item.SubItems.Add(fs.ToString());  //文件大小.
                    int pos=fileIco.IndexOf(theFile.Extension);
                    if (pos != -1) //已经增加过该类型了.
                    {
                        desc = theFile.Extension;
                        if (fileExt[pos] != null)
                            typeinfo = fileExt[pos].ToString();
                        else
                            typeinfo = "";
                        item.ImageIndex = pos;
                    }
                    else
                    { 
                        RegistryKey softwareKey = Registry.ClassesRoot.OpenSubKey(theFile.Extension);
                        if (theFile.Extension == "")
                        {
                            desc = "";
                            typeinfo = "无类型";
                        }
                        else if (softwareKey != null)
                        {
                            desc = (string)Registry.ClassesRoot.OpenSubKey(theFile.Extension).GetValue(null);
                            if (desc == null)
                            {
                                desc = theFile.Extension;
                                typeinfo = theFile.Extension + "文件";
                            }
                            else
                            {                               
                                typeinfo = (string)Registry.ClassesRoot.OpenSubKey(desc).GetValue(null);
                                if (typeinfo == null)
                                    typeinfo = theFile.Extension + "文件";
                            }
                        }

                        else
                        {
                            desc = theFile.Extension;
                            typeinfo = theFile.Extension;
                        }

                        fileIco.Add(theFile.Extension);
                        fileExt.Add(typeinfo);
                        imageListSmall.Images.Add(FileIcon.GetFileIcon(theFile.Extension, false));
                        item.ImageIndex = fileIco.Count - 1;
                    }
                    item.SubItems.Add(typeinfo);                   //文件类型.
                    #endregion
                }
                else
                {
                    item = new ListViewItem(drv["Object_id"].ToString().Trim());
                    item.ToolTipText = drv["Object_id"].ToString().Trim();
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                }
                #endregion
                item.SubItems.Add(drv["UPDATE_DATE"].ToString());
                item.Tag = drv["FILE_ID"].ToString();
                Listitem[i] = item;
                i++;
            }
           
            FileList.Items.AddRange(Listitem);
            FileList.SmallImageList = imageListSmall;
            Cursor.Current = Cursors.Default;
        }

        private void FileList_Click(object sender, EventArgs e)
        {
            ListViewItem item;
            ourFile file;
            this.FileList.Sorting = SortOrder.None;
            if (FileList.SelectedItems.Count == 1)
            {
                item = FileList.SelectedItems[0];
                TheSelectedFileId = (string)item.Tag;
                if (FileDbService.Instance.GetAFileById(TheSelectedFileId, out file))
                {
                    loadFileInfo(file);

                    if (filePath != null)
                    {
                        filePath(ucFile_filePath(file.FileId, shipId));
                    }
                }
            }
        }

        //删除文件操作，支持多选操作.
        private void DeleteFiles()
        {
            //public bool DeleteABlob(string fileId, out string err) 
            //FolderFileDbService : FolderFileDbService
            ourFile file; 
            string err;
            if (MessageBoxEx.Show("是否删除选定的文件？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            } 
            this.Cursor = Cursors.WaitCursor;

            if (FileList.SelectedItems.Count >= 1)
            {
                foreach (ListViewItem item in FileList.SelectedItems)
                {
                    FileDbService.Instance.GetAFileById((string)item.Tag, out file);
                    if (FolderFileDbService.Instance.DeleteAFile(nodeId, file.FileId, out err) == false)
                    {
                        MessageBoxEx.Show(err, "删除文件出错", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                        this.Cursor = Cursors.Arrow;
                    }
                    else
                    {
                        FileList.Items.Remove(item);
                        this.Cursor = Cursors.Arrow;
                    }
                }

            }
            this.Cursor = Cursors.Arrow;
        }

        //修改文件属性，包括文件名，文件打开后保存，出入参数为空时表示只修改了文件的属性而不是将文件打开后保存的替换。.
        private void EditFileName(string filePath)
        {
            ListViewItem item;
            ourFile file = new ourFile ();
            string err;
            item = FileList.SelectedItems[0];
            FileDbService.Instance.GetAFileById((string)item.Tag, out file);
            file.FileName = item.Text;

            //当第二个参数的值为空时，表示只修改了文件的属性而不是将文件打开后保存的替换。.
            if (FileDbService.Instance.UpdateAFile(file, filePath, out err) == true)
            {
                item.Text = file.FileName;
                item.Tag = file.FileId;
            }
            else
            {
                MessageBoxEx.Show(err, "修改文件出错", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }

        }

        //删除文件.
        private void ToolStripMenuDelete_Click(object sender, EventArgs e)
        {
            DeleteFiles();
        }

        //修改后刷新界面.
        private void loadFileInfo(ourFile file)
        {
            
            txtKeyWords.Text = file.ObjectLabel;
            Operator.Text = file.Creator;
            optDate.Text = file.UpdateDate.ToShortDateString();
            FileSize fs = new FileSize((long)(file.Size));
            txtSize.Text = fs.ToString();
            shipId = file.ShipId;
            string err;           
            string shipname = "公司文件";
            try
            {
                shipname = ShipInfoService.Instance.getObject(shipId, out err).SHIP_NAME;
            }
            catch{}
            txtshipInfo.Text = shipname;
            FileList.SelectedItems[0].Tag = file.FileId;
            if(file.FileName=="") FileList.SelectedItems[0].Text = file.ObjectLabel.Trim();
            
        }
        //文件属性修改.
        private void ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (FileList.SelectedItems.Count == 1)
            {
                
                ourFile file; 
                FileDbService.Instance.GetAFileById((string)FileList.SelectedItems[0].Tag, out file);

                if (file.FileName != "")
                {
                    FilePropertys pro = new FilePropertys();
                    pro.file = file;
                    pro.ShowFileInfo();
                    pro.ShowDialog();
                    loadFileInfo(file);
                }
                else
                {
                    frmPropertyModify property = new frmPropertyModify();
                    property.file = file;
                    property.ShowFileInfo();
                    property.ShowDialog();
                    loadFileInfo(file);
                }
            }
        }

        //打开文件.
        private void FileList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.FileList.SelectedItems.Count == 1)
            {
                
                ourFile file;
                FileDbService.Instance.GetAFileById((string)FileList.SelectedItems[0].Tag, out file);

                if (!string.IsNullOrEmpty(file.Object_id) && file.Object_id.Trim ().Length == 36)
                {
                    oFile.Add(new openFile());
                    oFile[oFile.Count - 1].FileOpen(file, oright);
                }
                else
                {
                    frmPropertyModify property = new frmPropertyModify();
                    property.file = file;
                    property.ShowFileInfo();
                    property.ShowDialog();
                    loadFileInfo(file);
                }
            }
        }

        /// <summary>
        /// 返回选定文件所在路径的委托方法.
        /// 调用如下：ucFile.filePath += new UCFile.SelectedFilePath(uc_fileSelected);
        /// 然后实现方法 private void uc_fileSelected(string path) 传入为路径，文件搜索有一个样例.
        /// </summary>
        /// <param name="path"></param>
        public delegate void SelectedFilePath(string path);
        public SelectedFilePath filePath;

        //点击某一个文件时filePath需要赋值.
        private string ucFile_filePath(string FileId, string shipId)
        {
            string folderId = FolderFileDbService.Instance.GetFolderIdByFileId(FileId);
            string err;
            return FolderDbService.Instance.GetPathByFolderId(folderId, out err);
        }

        private void ToolStripMenuAdd_Click(object sender, EventArgs e)
        {
            ImportFiles();
        }
        public void ImportFiles()
        {
            if ((nodeId != null)) //&& (shipId != "")
            {
                ImportFile imp = new ImportFile();
                ourFolder folder = FolderDbService.Instance.getFolderByFolderID(nodeId);
                if (folder == null)
                {
                    folder.NodeId = nodeId;
                    folder.ShipId = shipId;
                    string err;
                    DataTable dat;
                    if (!FolderDbService.Instance.GetFolderTypeByFolderId(nodeId, out dat, out err))
                    {
                        MessageBoxEx.Show("请定义节点类型并创建父节点", "定位错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    folder.Node_Type = (decimal)dat.Rows[0]["NODE_TYPE"];
                    folder.NodeName = nodeName;
                }
                imp.Selfolder = folder;
                imp.ShowDialog();
                LoadFile(nodeId, folder.NodeName);
            }
        }

        private void checkMenu()
        {
            if ((nodeId == null))
            {
                ToolStripMenuAdd.Visible = false;
            }
            else
            {
                ToolStripMenuAdd.Visible = true;
            }
        }

        private void UCFile_Load(object sender, EventArgs e)
        {
            if (oright == right.R)
            {
                contextMenuStrip.Enabled = false;
            }
            else
            {
                contextMenuStrip.Enabled = true;
            }
        }

        private void 文件下发ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ourFolder folder = FolderDbService.Instance.getFolderByFolderID(nodeId);
            if (FileList.SelectedItems.Count == 0)
            {
                MessageBoxEx.Show("请先选择要下发的文件");
                return;
            }
            List<string> fileIds = new List<string>();
            foreach (ListViewItem item in FileList.SelectedItems)
            {
                fileIds.Add((string)item.Tag);
            }

            FrmFilesDistribute frm = new FrmFilesDistribute(folder.NodeId, Convert.ToInt32(folder.Node_Type), 0, fileIds);
            frm.ShowDialog();
        }

        private void FileList_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Label)) return;
            if (e.Label.Length > 256)
            {
                MessageBoxEx.Show("文件名字不得超过256个字符", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string err;
            if (FileList.SelectedItems.Count == 1)
            {
                ourFile file;// = (ourFile)FileList.SelectedItems[0].Tag;
                FileDbService.Instance.GetAFileById((string)FileList.SelectedItems[0].Tag, out file);

                FileInfo oldfile = new FileInfo(file.FileName);
                string oldExt = oldfile.Extension;

                FileInfo newfile = new FileInfo(e.Label);
                string newExt = newfile.Extension;
                if (!oldExt.Equals(newExt, StringComparison.OrdinalIgnoreCase))
                {
                    if (MessageBoxEx.Show("文件扩展名改变，是否确认？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        e.CancelEdit = true;
                        return;
                    }
                }

                if (FileDbService.Instance.renameFile(file.FileId, e.Label, out err))
                {
                    file.FileName = e.Label;
                }
                else
                {
                    MessageBoxEx.Show(err, "文件重命名失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void 重命名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FileList.SelectedItems.Count == 1)
            {
                FileList.SelectedItems[0].BeginEdit();
            }
        }

        private void 导出文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FileList.SelectedItems.Count > 0)
            {
                if(FolderBrowserDialogEx.ShowDialog(folderBrowserDialog) == DialogResult.OK)
                {
                    string path = folderBrowserDialog.SelectedPath;
 
                    foreach (ListViewItem item in this.FileList.SelectedItems)
                    {
                        ourFile file;
                        FileDbService.Instance.GetAFileById((string)item.Tag, out file);

                        if (file.FileName != "")
                        {
                            string tmpFile;
                            if (FileDbService.Instance.GetABolbByFileId(file.FileId, out tmpFile))
                            {
                                try
                                {
                                    File.Copy(tmpFile, path + "\\" + String.Join("", file.FileName.Split(Path.GetInvalidFileNameChars())), true);
                                }
                                catch { }
                            }
                        }
                    }
                }
            }
        }
    }
}
