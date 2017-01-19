/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：UCISMFile.cs
 * 创 建 人：牛振军
 * 创建时间：2008-05-12
 * 标    题：ISM模板及体系文件管理
 * 功能描述：文件用户对象
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
using System.Runtime.InteropServices;
using FileOperation;
using FileOperationBase.FileServices;
using FileOperationBase.Services;
using FileOperation.Forms;

using CommonOperation.BaseClass;
using CommonViewer;
using BaseInfo.DataAccess;
using CommonOperation.Functions;
using CommonOperation.Enum;
using CommonViewer.BaseControl;

namespace FileOperation.ISM.Forms
{
    public partial class UCISMFile : UserControl
    {

        private ListViewColumnSorter lvwColumnSorter;
        public string shipId;
        public string nodeId;
        public UCISMFile()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            this.FileList.ListViewItemSorter = lvwColumnSorter;

        }
        //正式方法，加载上面的模板文件.
        public void LoadFile(string NodeId)
        {
            FileList.Items.Clear();
            clearFileInfo();
            DataTable table;
            this.Cursor = Cursors.WaitCursor;
            table =FolderFileDbService.Instance.GetISMTemplateFile(NodeId);
            LoadFile(table, dotView); 
            nodeId = NodeId;
            this.Cursor = Cursors.Arrow;
        }
        //重写方法，加载下部的体系文件.
        public void LoadFile(string NodeId, String ShipId)
        {
            shipId = ShipId;
            nodeId = NodeId;
            clearFileInfo();
            LoadFile(NodeId);
        }

        //重构加载文件方法.
        public void LoadFile(DataTable table,ListView lv)
        {
            ourFile file;

            DataView dvTree;
             
            dvTree = new DataView(table);
            ImageList img = lv.SmallImageList;
            img.Images.Clear();
            lv.Items.Clear();
            foreach (DataRowView drv in dvTree)
            {
                //构造文件类对象.
                file = new ourFile();
                file.Creator = drv["creator"].ToString();
                file.FileId = drv["FILE_ID"].ToString();
                file.FileName = drv["file_NAME"].ToString();
                file.Object_id = drv["Object_id"].ToString();
                file.ObjectLabel = drv["OBJECT_LABEL"].ToString();
                file.Size = (decimal)drv["FSize"];
                file.UpdateDate = Convert.ToDateTime(drv["UPDATE_DATE"]);           
                file.RefEquipment = drv["REF_EQUIPMENT"].ToString();
                file.ShipId = drv["SHIP_ID"].ToString();
                file.Version = drv["version"].ToString().Trim();    //版本.
                file.File_Type = drv["file_type"].ToString();  //DOT  DOC 是否为模板标识.
                file.Ref_Fileid = drv["ref_fileid"].ToString();  //模板的file_id
                file.Preserve1 = drv["PRESERVE1"].ToString();
                file.Preserve2 = drv["PRESERVE2"].ToString();
                AddAFile(file,lv);
            }
        }

         //选择某一行.
        //单击某一个文件显示全路径.
        private void FileList_Click(object sender, EventArgs e)
        {
            ListClick((ListView)sender);
        }
        private void ListClick(ListView lv)
        {
            ListViewItem item;
            ourFile file;
            //lv.Sorting = SortOrder.None;
            if (lv.SelectedItems.Count == 1)
            {
                item = lv.SelectedItems[0];
                file = (ourFile)item.Tag;
                loadFileInfo(file);

                if (filePath != null)
                {
                    filePath(ucFile_filePath(file.FileId));
                }
            }
        }

        //删除文件操作，支持多选操作.
        private void DeleteFiles(ListView lv)
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

            if (lv.SelectedItems.Count >= 1)
            {
                foreach (ListViewItem item in lv.SelectedItems)
                {
                    file = (ourFile)item.Tag;
                    if (FolderFileDbService.Instance.DeleteAFile(nodeId, file.FileId, out err) == false)
                    {
                        MessageBoxEx.Show(err, "删除文件出错", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                        this.Cursor = Cursors.Arrow;
                    }
                    else
                    {
                        lv.Items.Remove(item);
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
            ourFile file;
            string err;
            item = FileList.SelectedItems[0];
            file = (ourFile)item.Tag;

            file.FileName = item.Text;

            //当第二个参数的值为空时，表示只修改了文件的属性而不是将文件打开后保存的替换。.
            if (FileDbService.Instance.UpdateAFile(file, filePath, out err) == true)
            {
                item.Text = file.FileName;
                item.Tag = file;
            }
            else
            {
                MessageBoxEx.Show(err, "修改文件出错", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }

        }

        //添加文件后刷新ListView
        public void AddAFile(ourFile file, ListView lv)
        {
            string desc;
            string typeinfo;
            FileInfo theFile = new FileInfo(file.FileName);
            ImageList img = lv.SmallImageList;

            ListViewItem item = new ListViewItem(file.FileName); //文件名.

            FileSize fs = new FileSize((long)(file.Size));
            item.SubItems.Add(fs.ToString());  //文件大小.

            RegistryKey softwareKey = Registry.ClassesRoot.OpenSubKey(theFile.Extension);
            if (theFile.Extension == "")
            {
                desc = "";
                typeinfo = "无类型";
            }
            else if (softwareKey != null)
            {
                //desc = (string)Registry.ClassesRoot.OpenSubKey(theFile.Extension).GetValue(null);
                //typeinfo = (string)Registry.ClassesRoot.OpenSubKey(desc).GetValue(null);
                desc = (string)Registry.ClassesRoot.OpenSubKey(theFile.Extension).GetValue(null);
                if (desc == null)
                {
                    desc = theFile.Extension;
                    typeinfo = theFile.Extension + "文件";
                }
                else
                {
                    typeinfo = (string)Registry.ClassesRoot.OpenSubKey(desc).GetValue(null);
                }
            }

            else
            {
                desc = theFile.Extension;
                typeinfo = theFile.Extension + "文件";
            }

            item.SubItems.Add(typeinfo);                   //文件类型.
            item.SubItems.Add(file.Version.Trim());      //版本号.
            item.SubItems.Add(file.UpdateDate.ToString()); //修改日期.
            
            item.Tag = file;
            int i = img.Images.Count;
            img.Images.Add(FileIcon.GetFileIcon(file.FileName, false));
            lv.Items.Add(item);

            lv.SmallImageList = img;
            lv.Items[i].ImageIndex = i;
        }

        //删除文件.
        private void ToolStripMenuDelete_Click(object sender, EventArgs e)
        {
            DeleteFiles(dotView);
        }

        private void clearFileInfo()
        {
            txtVersion.Text = "";
            txtKeyWords.Text = "";
            Operator.Text = "";
            optDate.Text = "";
            txtSize.Text = "";
            txtShipInfo.Text = "";
        }

        //修改后刷新界面.
        private void loadFileInfo(ourFile file)
        { 
            txtVersion.Text = file.Version;
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
            catch { }
            txtShipInfo.Text = shipname;
        }
        //文件属性修改.
        private void ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            modifyFileProperty(dotView,true);           
        }

        //打开文件.
        [DllImport("kernel32.dll")]
        public static extern int WinExec(string exeName, int operType);
        private void FileList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            dbClickTreeView((ListView)sender,"DOC");
        }
        
        //双击treeview事件，该过程只判断当前打开文件是否可以修改，并进行监视。.
        private void dbClickTreeView(ListView tr,string  fileType)
        {
            openFile ofile = new openFile();

            if (tr.SelectedItems.Count == 1)
            {
                ourFile openFile = (ourFile)(tr.SelectedItems[0].Tag);
                switch (checkUserRight(openFile,fileType))
                {
                    case right.C:
                        ofile.FileOpen(openFile, right.C);
                        break;
                    case right.U:
                        ofile.FileOpen(openFile, right.U);
                        break;
                    default:     //default is readonly
                        ofile.FileOpen(openFile, right.R);
                        break;
                }       
            }        
        }

        //根据当前用户、文件及文件类型，判断用户是否有编辑文件的权限。.
        private right checkUserRight(ourFile file, string fileType)
        {
            if (canModify)
            {
                return right.U;
            }
            else
            {
                return right.R;
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
        private string ucFile_filePath(string FileId)
        {
            string folderId = FolderFileDbService.Instance.GetFolderIdByFileId(FileId);
            //根据folder得到所有目录.
            string err;
            return FolderDbService.Instance.GetPathByFolderId(folderId,out err);            
        }

        private void ToolStripMenuAdd_Click(object sender, EventArgs e)
        {
            ImportFiles();
        }
        public void ImportFiles()
        {
            if ((nodeId != null) && (shipId != ""))
            {
                frmImportFile imp = new frmImportFile();
                ourFolder folder = new ourFolder();
                folder.NodeId = nodeId;
                folder.ShipId = shipId;
                imp.Selfolder=folder;
                imp.ShowDialog();
                LoadFile(nodeId, shipId);
            }
        }

        //private void checkMenu()
        //{
        //    if ((nodeId == null) || (shipId == ""))
        //    {
        //        ToolStripMenuAdd.Visible = false;
        //    }
        //    else
        //    {
        //        ToolStripMenuAdd.Visible = true;
        //    }
        //}

        //单击显示属性信息.
        private void dotView_Click(object sender, EventArgs e)
        {
            ListClick((ListView)sender);
            
            if (dotView.SelectedItems.Count != 1) return;
            ourFile SelectedFile = (ourFile)(dotView.SelectedItems[0].Tag);
            LoadDocFiles(SelectedFile, shipId);

            string fileid = SelectedFile.FileId;

            //if ((shipId != "") && (fileid != ""))
            //{
            //    LoadFile(fileid, shipId);
            //}
        }
        //双击查看文档.
        private void dotView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            生成报告ToolStripMenuItem_Click(sender, null);            
        }

        //删除文件.
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            DeleteFiles(FileList);
        }

        private void 修改模板文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbClickTreeView(dotView, "DOT");
        }

        private void 生成报告ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //生成一个报告.
            openFile ofile = new openFile();
            if (dotView.SelectedItems.Count != 1) return;
            ourFile openFile = (ourFile)(dotView.SelectedItems[0].Tag);
            if (string.IsNullOrEmpty(shipId) && !CommonOperation.ConstParameter.IsLandVersion)
            {
                shipId = CommonOperation.ConstParameter.ShipId;
            } 
            //right.C  为创建一个新的体系文件.
            ourFolder folderUp = FolderDbService.Instance.getFolderByFolderType(FileBoundingTypes.MEASUREREPORT, shipId);
            ourFolder folder = FolderDbService.Instance.getOrCreateSubFolderByName(folderUp, DateTime.Today.ToString("yyyy年MM月"));
            try
            {
                ofile.FileOpen(openFile, right.C, folder.NodeId, shipId);

                LoadDocFiles(openFile, shipId);
            }
            catch (Exception es)
            {
                MessageBoxEx.Show(es.Message);
            }
        }

        //加载体系文件.
        private void LoadDocFiles(ourFile file, string shipId)
        {
            DataTable dat = FileDbService.Instance.LoadDocFiles(file, shipId);
            LoadFile(dat, FileList);
        }

        //修改文件的属性.
        private void modifyFileProperty(ListView lv,bool showVersion)
        {
            if (lv.SelectedItems.Count == 1)
            {
                frmFilePropertys pro = new frmFilePropertys();
                ourFile file = (ourFile)lv.SelectedItems[0].Tag;
                pro.file = file;
                pro.showVersion = showVersion;
                pro.ShowFileInfo();
                pro.ShowDialog();
                loadFileInfo(file);
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            modifyFileProperty(FileList,false);
        }

        private void 文件下发ToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            ourFolder folder = FolderDbService.Instance.getFolderByFolderID(nodeId);
            if (folder == null) return;
            if (FileList.SelectedItems.Count == 0)
            {
                MessageBoxEx.Show("请先选择要下发的文件");
                return;
            }
            List<string> fileIds = new List<string>();
            foreach (ListViewItem item in FileList.SelectedItems)
            {
                fileIds.Add(((ourFile)item.Tag).FileId);
            }

            FrmFilesDistribute frm = new FrmFilesDistribute(folder.NodeId, Convert.ToInt32(folder.Node_Type), 1, fileIds);
            frm.ShowDialog();
        }

        private void 文件下发ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ourFolder folder = FolderDbService.Instance.getFolderByFolderID(nodeId);
            if (folder == null) return;
            if (dotView.SelectedItems.Count == 0)
            {
                MessageBoxEx.Show("请先选择要下发的文件");
                return;
            }
            List<string> fileIds = new List<string>();
            foreach (ListViewItem item in dotView.SelectedItems)
            {
                fileIds.Add(((ourFile)item.Tag).FileId);
            }

            FrmFilesDistribute frm = new FrmFilesDistribute(folder.NodeId, Convert.ToInt32(folder.Node_Type), 1, fileIds);
            frm.ShowDialog();
        }

        private void 重命名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dotView.SelectedItems.Count == 1)
            {
                dotView.SelectedItems[0].BeginEdit();
            }
        }

        private void dotView_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Label)) return;
            if (e.Label.Length > 256)
            {
                MessageBoxEx.Show("文件名字不得超过256个字符", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string err;
            if (dotView.SelectedItems.Count == 1)
            {
                ourFile file = (ourFile)dotView.SelectedItems[0].Tag;
                FileInfo oldfile = new FileInfo(file.FileName);
                string oldExt = oldfile.Extension;

                FileInfo newfile = new FileInfo(e.Label);
                string newExt = newfile.Extension;
                if (!oldExt.Equals(newExt, StringComparison.OrdinalIgnoreCase))
                {
                    if (MessageBoxEx.Show("文件扩展名改变，是否确认？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
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

        private void 重命名ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (FileList.SelectedItems.Count == 1)
            {
                FileList.SelectedItems[0].BeginEdit();
            }
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
                ourFile file = (ourFile)FileList.SelectedItems[0].Tag;
                FileInfo oldfile = new FileInfo(file.FileName);
                string oldExt = oldfile.Extension;

                FileInfo newfile = new FileInfo(e.Label);
                string newExt = newfile.Extension;
                if (!oldExt.Equals(newExt, StringComparison.OrdinalIgnoreCase))
                {
                    if (MessageBoxEx.Show("文件扩展名改变，是否确认？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
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

        private void 导入体系文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dotView.SelectedItems.Count != 1)
            {
                MessageBoxEx.Show("请选择一个体系文件对应的模板文件！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ourFile sourceFile = (ourFile)(dotView.SelectedItems[0].Tag);
            openFileDialog.Title = "文件选择";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] Files = openFileDialog.FileNames;
                if (!importFiles(sourceFile, Files))
                {
                    MessageBoxEx.Show("导入体系文件错误！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //导入体系文件.
        private bool importFiles(ourFile dotFile, string[] files)
        { 
            string err="";

            FileInfo myFileInfo;
            this.Cursor = Cursors.WaitCursor; 
            foreach (string ifile in files)
            {
                ourFile file = new ourFile();
                file.Creator = "";
                myFileInfo = new FileInfo(ifile);
                file.FileName = myFileInfo.Name;
                 file.Size = myFileInfo.Length;
                 file.CreateDate = DateTime.Today; 
                file.RefEquipment = "";
                file.Version = dotFile.Version;   //版本号.
                file.File_Type = "DOC";           //文档类型.
                file.Ref_Fileid = dotFile.FileId;           //相关文档的id
                file.ShipId = shipId;

                if (!FolderFileDbService.Instance.InsertAFile(nodeId, file, ifile, out err))
                {
                    this.Cursor = Cursors.Arrow;
                    MessageBoxEx.Show(err, "插入文件出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Cursor = Cursors.Default;
                    return false;
                }
                else
                {
                    AddAFile(file, FileList);
                }                
            }
            this.Cursor = Cursors.Default;
            return true;
        }
        bool canModify = false;
        private void UCISMFile_Load(object sender, EventArgs e)
        {
            string sChkMessage;
            ProxyRight proxyRight = ProxyRight.Instance;//权限代理业务类.
            canModify = proxyRight.CheckRight(CommonOperation.ConstParameter.ISM_MODEL_EDIT, out sChkMessage);
            修改模板文件ToolStripMenuItem.Visible = canModify;

        }

        private void dotView_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Delete)
            {
                DeleteFiles(dotView);
            }
        }

        private void FileList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteFiles(FileList);
            }
        }

        private void 导出文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFiles(dotView);
        }

        private void ExportFiles(ListView listview)
        {
            if (listview.SelectedItems.Count > 0)
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = folderBrowserDialog.SelectedPath;

                    foreach (ListViewItem item in listview.SelectedItems)
                    {
                        ourFile file = (ourFile)item.Tag;
                        if (file.FileName != "")
                        {
                            string tmpFile;
                            if (FileDbService.Instance.GetABolbByFileId(file.FileId, out tmpFile))
                            {
                                try
                                {
                                    File.Copy(tmpFile, path + "\\" + file.FileName, true);
                                }
                                catch { }
                            }
                        }
                    }
                }
            }
        }

        private void 导出文件ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ExportFiles(FileList);
        }
    }
}
