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
    public partial class FrmFilesDistribute : CommonViewer.BaseForm.FormBase
    {
        List<string> FilesId;

        /// <summary>
        /// 启动选择的文件夹类型.
        /// </summary>
        /// <param name="Foldertype">文件夹类型</param>
        /// <param name="loadType">0普通视图，1ISM视图</param>
        public FrmFilesDistribute(string sourceFolderId, int Foldertype,int loadType,List<string> filesId)
        {
            InitializeComponent();
            FilesId = filesId;
            if (loadType == 0)
            {
                ucFilesDistribute.LoadCommonFolders(sourceFolderId,Foldertype);
            }
            else
            {
                ucFilesDistribute.LoadIsmFolders(sourceFolderId,Foldertype);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string err="";

            if (ucFilesDistribute.getDistributeFolders())
            {
                List<ourFolder> folders = ucFilesDistribute.Folders;
                foreach (ourFolder folder in folders)
                {
                    if (!FolderFileDbService.Instance.distributeFiles(folder.NodeId, FilesId, out err))
                    {
                        MessageBoxEx.Show(err, "文件下发错误提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close();
                        return;
                    }
                }                
                MessageBoxEx.Show("文件下发成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();               
            }
        }

    }
}