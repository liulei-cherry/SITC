using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FileOperationBase.FileServices;
using FileOperationBase.Services;
using CommonOperation.Enum;
using CommonViewer.MultiLanguage;

namespace FileOperation.ISM.Forms
{
    public partial class frmISMManageMent : CommonViewer.BaseForm.FormBase
    {

        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static frmISMManageMent instance = new frmISMManageMent();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static frmISMManageMent Instance
        {
            get
            {
                if (null == instance)
                {
                    frmISMManageMent.instance = new frmISMManageMent();
                }

                return frmISMManageMent.instance;
            }
        }

        #endregion

        public frmISMManageMent()
        {
            InitializeComponent();
        }

        private void frmISMManageMent_Load(object sender, EventArgs e)
        {
            #region ISM模板管理
            ucismFolder.generateTree();
            ucismFolder.TreeSelect+=new UCISMFolder.MyDelegate(ucismFolder_TreeSelect);
            ucismFolder.AfterImportFiles +=new UCISMFolder.MyDelegate(ucismFolder_AfterImportFiles);
            setColumWidth();
            #endregion
        }
        #region ISM模板管理
        void ucismFolder_AfterImportFiles(string nodeId)
        {
            ucismFile.LoadFile(nodeId);
        }

        void ucismFolder_TreeSelect(string nodeId)
        {
            ucismFile.FileList.Items.Clear();
            ucismFile.LoadFile(nodeId, ((ourFolder)ucismFolder.TreeView.SelectedNode.Tag).ShipId);
        }

        void setColumWidth()
        {
            ucismFile.dotView.Columns[0].Width = 300;
            ucismFile.dotView.Columns[1].Width = 60;
            ucismFile.dotView.Columns[2].Width = 150;
            ucismFile.dotView.Columns[3].Width = 60;
            ucismFile.dotView.Columns[4].Width = 150;

            ucismFile.FileList.Columns[0].Width = 300;
            ucismFile.FileList.Columns[1].Width = 60;
            ucismFile.FileList.Columns[2].Width = 150;
            ucismFile.FileList.Columns[3].Width = 0;
            ucismFile.FileList.Columns[4].Width = 150;
        }
        #endregion

        /// <summary>
        /// 释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmISMManageMent_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEx1_Click(object sender, EventArgs e)
        {
            ucismFile.LoadFile("");
            ucismFolder.generateTree();
        }
    }
}