using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FileOperationBase.FileServices;
using CommonViewer;
using FileOperationBase.Services;

namespace FileOperation.Forms
{
    public partial class FileSearch : CommonViewer.BaseForm.FormBase
    {
        public ourFolder Folder;
        public string searchPath; 
        public FileSearch()
        {
            InitializeComponent();
        }

        public FileSearch(string filename)
        {
            InitializeComponent();
            txtKey.Text = filename;
        }

        //关闭窗体.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        //搜索.
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataTable dv;
            string[] txt ={ };
            txtKey.Text.Replace('，', ',');  //替换错误的中文全角字符.
            txtKey.Text = txtKey.Text.Trim().Replace("'", "''");

            if (txtKey.Text.Trim() != "")
            {
                txt = txtKey.Text.Split(',');
            }
            List<string> list = new List<string>(txt);
            dv = FileDbService.Instance.GetFilesBySelect(this.txtCreator.Text, this.dateStart.Value, this.dateEnd.Value, list, Folder == null ? "" : Folder.NodeId, null);
            ucFile.LoadFile(dv);
            txtKey.Text = txtKey.Text.Trim().Replace("''", "'");
            Cursor.Current = Cursors.Default;
        }
       
        private void uc_fileSelected(string path)
        {
            fPath.Text = path;
        }

        private void FileSearch_Load(object sender, EventArgs e)
        {
            this.dateEnd.Value = DateTime.Now;
            ucFile.filePath += new UCFile.SelectedFilePath(uc_fileSelected);
            this.Text = "当前搜索路径为：" + searchPath + " 及其子目录下所有文件";
            ucFile.FileList.Columns[0].Width = 180;
            ucFile.FileList.Columns[2].Width = 100;
            ucFile.contextMenuStrip.Items[2].Visible = false;
            ucFile.contextMenuStrip.Items[3].Visible = false;
            if (txtKey.Text.Length > 0) btnSearch_Click(null, null);
        }
    }
}