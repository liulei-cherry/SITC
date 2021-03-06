﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using FileOperationBase.FileServices;
using FileOperationBase.Services;
using CommonViewer.BaseControl;

namespace FileOperation.ISM.Forms
   
{
    public partial class frmImportFile : CommonViewer.BaseForm.FormBase
    {
        public frmImportFile()
        {
            InitializeComponent();
        }
        public ourFolder Selfolder;
        public string templateType; //模板类型 DOT  OR  DOC
        public string orefFileId;          //相应模板id
        private void btnFileSelect_Click(object sender, EventArgs e)
        {

            openFileDialog.Title = "文件选择";
            if (OpenFileDialogEx.ShowDialog(openFileDialog) == DialogResult.OK)
            {
                dealFile(openFileDialog.FileNames);
            }
        }
        
        //处理文件图标及扩展名.
        public void dealFile(string[] files)
        {
            string desc;
            string typeinfo;
            if (files == null)
                return;
            foreach (string fileName in files)
            {
                #region 获取文件过程
                FileInfo myFileInfo = new FileInfo(fileName);
                ListViewItem item = new ListViewItem(myFileInfo.Name);

                item.SubItems.Add(myFileInfo.Length.ToString());

                RegistryKey softwareKey = Registry.ClassesRoot.OpenSubKey(myFileInfo.Extension);
                if (myFileInfo.Extension == "")
                {
                    desc = "";
                    typeinfo = "无类型";
                }
                else if (softwareKey != null)
                {
                    desc = (string)Registry.ClassesRoot.OpenSubKey(myFileInfo.Extension).GetValue(null);
                    if (desc == null)
                    {
                        desc = myFileInfo.Extension;
                        typeinfo = myFileInfo.Extension + "文件";
                    }
                    else
                    {
                        typeinfo = (string)Registry.ClassesRoot.OpenSubKey(desc).GetValue(null);
                    }
                }
                else
                {
                    desc = myFileInfo.Extension;
                    typeinfo = myFileInfo.Extension + "文件";
                }

                item.SubItems.Add(typeinfo);                   //文件类型.
                item.Tag = fileName;
                int i = imageListSmall.Images.Count;
                try
                {
                    imageListSmall.Images.Add(FileIcon.GetFileIcon(fileName, false));
                }
                catch { }//此处不捕获错误.
                FileList.SmallImageList = imageListSmall;
                FileList.Items.Add(item);
                FileList.Items[i].ImageIndex = i;
                #endregion
            }
        }

        //循环导入到数据库.
        private void btnImport_Click(object sender, EventArgs e)
        {
            ourFile file;
            string err;

            file = new ourFile();
            FileInfo myFileInfo;
            this.Cursor = Cursors.WaitCursor;
            foreach (ListViewItem lv in FileList.Items)
            {
                file.Creator = txtOperator.Text;              
                file.ObjectLabel = txtLabel.Text.Replace("'", "''");
                file.FileName = lv.Text;
                string a = lv.SubItems[1].ToString();
                myFileInfo = new FileInfo(lv.Tag.ToString());
                file.Size = myFileInfo.Length;
                file.CreateDate = Convert.ToDateTime(txtDate.Text);
                file.RefEquipment = "";
                file.Version = txtVersion.Text.Replace("'", "''");   //版本号.
                file.File_Type = templateType;           //文档类型.
                file.Ref_Fileid = orefFileId;           //相关文档的id
                file.ShipId = Selfolder.ShipId;
                if (FolderFileDbService.Instance.InsertAFile(Selfolder.NodeId, file, lv.Tag.ToString(), out err) == false)
                {
                    this.Cursor = Cursors.Arrow;
                    MessageBoxEx.Show(err, "插入文件出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            //只插入备注而没有文件信息.
            if (FileList.Items.Count == 0)
            {
                if (txtLabel.Text.Trim().Length > 0)
                {
                    file.Creator = txtOperator.Text;
                    file.ObjectLabel = txtLabel.Text.Replace("'", "''");
                    file.CreateDate = Convert.ToDateTime(txtDate.Text);
                    file.RefEquipment = "";
                    file.ShipId = Selfolder.ShipId;
                    if (FolderFileDbService.Instance.InsertAFile(Selfolder.NodeId, file, "", out err) == false)
                    {
                        this.Cursor = Cursors.Arrow;
                        MessageBoxEx.Show(err, "增加备注出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            this.Cursor = Cursors.Arrow;
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lv in FileList.SelectedItems)
            {
                imageListSmall.Images.RemoveAt(lv.Index);
                lv.Remove();
            }
            //resort image
            foreach (ListViewItem lv in FileList.Items )
            {
                lv.ImageIndex = lv.Index;
            }
        }

        private void frmImportFile_Load(object sender, EventArgs e)
        {
            txtOperator.Text = CommonOperation.ConstParameter.UserName;
            txtDate.Text = DateTime.Now.ToShortDateString();
        }

    }
}