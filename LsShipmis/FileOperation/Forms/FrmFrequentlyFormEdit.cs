/*
 * 徐正本 2014年1月9日 增加界面，提供机务常用表格维护功能
 */
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
    public partial class FrmFrequentlyFormEdit : CommonViewer.BaseForm.FormBase
    {
        private FrmFrequentlyFormEdit()
        {
            InitializeComponent();
        }
        #region 构造函数


        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static FrmFrequentlyFormEdit instance = new FrmFrequentlyFormEdit();
        public static FrmFrequentlyFormEdit Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmFrequentlyFormEdit.instance = new FrmFrequentlyFormEdit();
                }
                return FrmFrequentlyFormEdit.instance;
            }
        }
        #endregion

        private void FrmFrequentlyFormEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmFrequentlyFormEdit_Load(object sender, EventArgs e)
        {
            ourFolder theFolder = FolderFileDbService.Instance.GetEngineerFrequentlyUsingForm();
            if (theFolder != null)
                ucFile.LoadFile(theFolder.NodeId, theFolder.NodeName);
            else
                ucFile.FileList.Clear();
        }
    }
}