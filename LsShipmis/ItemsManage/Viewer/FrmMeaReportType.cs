/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有 * 文 件 名：FrmMeaReportType.cs
 * 创 建 人：李景育 * 创建时间：2008-04-20
 * 标    题：工作报告类型管理业务窗体
 * 功能描述：实现工作报告类型管理业务窗体上的相关功能 * 修 改 人： 
 * 修改时间： * 修改内容： ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FileOperationBase.Services;
using System.IO;
using ItemsManage.Services;
using CommonViewer.BaseControlService;
using CommonOperation.Functions;
using CommonOperation.Interfaces;
using FileOperation.Forms;
using CommonOperation.Enum;
using FileOperationBase.FileServices;
using CommonViewer.BaseControl;
using CommonOperation;

namespace ItemsManage.Viewer
{
    /// <summary>
    /// 工作报告类型管理业务窗体.
    /// </summary>
    public partial class FrmMeaReportType : CommonViewer.BaseForm.FormBase
    {
        ourFolder folder;
        ourFile file;
        ourFile tempFile;
        private IDBOperation commonOpt = InterfaceInstantiation.NewADBOperation();
        bool fileChanged = false;
        bool addNew = false;
        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmMeaReportType()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        private void FrmMeaReportType_Load(object sender, EventArgs e)
        {
            this.setBindingSource();//设置数据源.
            this.setDataGridView(); //设置网格控件dgvSpApply的隐藏列与标头的设置.
            this.bindingCtrols();   //绑定窗体控件.
            this.WindowState = FormWindowState.Maximized;//窗体最大化.
            ucShipSelect1.ChangeSelectedState(false, true);
        }

        /// <summary>
        /// 设置工作报告类型信息的bindingSource数据源。.
        /// </summary>
        private void setBindingSource()
        {
            DataTable dtbMeaReportType = ComponentTypeService.Instance.GetMeaReportType(ucShipSelect1.GetId());
            bindingSourceMain.DataSource = dtbMeaReportType;
            dgvMain.DataSource = bindingSourceMain;

            //如果当前没有数据，则输入框区域的控件为不可用状态；否则为可用状态。.
            if (dgvMain.Rows.Count > 0)
            {
                FormControlOption.Instance.EnableOrDisableCtrls(tableLayoutPanel2, true);
            }
            else
            {
                FormControlOption.Instance.EnableOrDisableCtrls(tableLayoutPanel2, false);
                txtFile.Text = "";
            }

        }

        /// <summary>
        /// 设置工作报告类型信息网格控件dgvMain的隐藏列与显示标题.
        /// </summary>
        private void setDataGridView()
        {
            dgvMain.Columns["measure_report_type_id"].Visible = false;
            dgvMain.Columns["ship_id"].Visible = false;
            dgvMain.Columns["ship_id"].HeaderText = "船舶";
            dgvMain.Columns["creator"].Visible = false;
            dgvMain.Columns["measure_report_type_name"].HeaderText = "工作报告类型";
            dgvMain.Columns["remark"].HeaderText = "备注";
            dgvMain.Columns["measure_report_type_name"].Width = 150;
            dgvMain.Columns["remark"].Width = 350;
            dgvMain.Columns["file_id"].Visible = false;
        }

        /// <summary>
        /// 绑定窗体控件.
        /// </summary>
        private void bindingCtrols()
        {
            //主键值measure_report_type_id的绑定使用了txtMeaReportType的Tag属性解决，无法使用隐藏的控件。.

            txtMeaReportType.DataBindings.Add("Tag", bindingSourceMain, "measure_report_type_id", true);
            txtMeaReportType.DataBindings.Add("Text", bindingSourceMain, "measure_report_type_name", true);
            txtRemark.DataBindings.Add("Tag", bindingSourceMain, "creator", true);
            txtRemark.DataBindings.Add("Text", bindingSourceMain, "remark", true);
            btnView.DataBindings.Add("Tag", bindingSourceMain, "file_ID", true);
            ucShipSelect1.DataBindings.Add("Tag", bindingSourceMain, "ship_id", true);
        }

        /// <summary>
        /// 在dgvMain_RowEnter事件中绑定文档管理器.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMain_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string measureRptId = "";   //工作报告类型Id
            txtFile.Text = "";
            tempFile = null;
            fileChanged = false;
            //当网格dgvMain行变化时显示当前行的工作报告文档信息.
            if (dgvMain.Rows[e.RowIndex].Cells["file_ID"].Value != DBNull.Value && (dgvMain.Rows[e.RowIndex].Cells["file_ID"].Value.ToString().Length > 0))
            {
                measureRptId = dgvMain.Rows[e.RowIndex].Cells["file_ID"].Value.ToString();
                btnView.Enabled = true;
                buttonEx1.Enabled = true;
                btnBdFiles.Enabled = true;
                addNew = false;
                showFileName(measureRptId);
            }
            else
            {
                btnView.Enabled = false;
                buttonEx1.Enabled = addNew;
                btnBdFiles.Enabled = addNew;
            }

        }

        private void showFileName(string fileId)
        {
            FileDbService.Instance.GetAFileById(fileId, out file);
            if (file == null) return;
            txtFile.Text = file.FileName;
        }

        /// <summary>
        /// 工作报告类型信息添加操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            addNew = true;
            fileChanged = false;
            bindingSourceMain.AddNew();
            txtMeaReportType.Tag = Guid.NewGuid().ToString();  //产生申请单主键值.
            txtRemark.Tag = CommonOperation.ConstParameter.UserName;          //当前登录用户Id
            AddButton.Enabled = false; //把AddButton.Enabled设置为false是为了防止连续添加.
            FormControlOption.Instance.EnableOrDisableCtrls(tableLayoutPanel2, true);
            buttonEx1.Enabled = true;
            btnBdFiles.Enabled = true;
            ucShipSelect1.Tag = ucShipSelect1.GetId();
        }

        /// <summary>
        /// 工作报告类型信息删除操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.
            txtFile.Text = "";
            if (bindingSourceMain.Current != null)
            {
                if (MessageBoxEx.Show("确定要删除吗？", "删除提示", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }

                bindingSourceMain.RemoveCurrent();
                bindingSourceMain.EndEdit();
                DataTable dtb = (DataTable)bindingSourceMain.DataSource;//从BindingSource组件中取得信息集放到DataTable中去.

                //更新结果报告.
                if (commonOpt.SaveFormData(dtb, "T_Measure_Report_Type", 0, out err))
                {
                    MessageBoxEx.Show("删除成功！", "删除成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBoxEx.Show(err, "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                //如果当前没有数据，则输入框区域的控件为不可用状态；否则为可用状态。.

                if (dgvMain.Rows.Count > 0)
                {
                    FormControlOption.Instance.EnableOrDisableCtrls(tableLayoutPanel2, true);
                }
                else
                {
                    FormControlOption.Instance.EnableOrDisableCtrls(tableLayoutPanel2, false);
                    buttonEx1.Enabled = false;
                    btnBdFiles.Enabled = false;
                }

                AddButton.Enabled = true;
            }
        }

        /// <summary>
        /// 备件信息保存操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgSaveItem_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.

            //***************数据校验*****************************************************************************
            //校验只能在当前网格有数据时进行，否则当网格中的数据全部删除时将由于校验功能而无法执行.

            ucShipSelect1.Tag = ucShipSelect1.GetId();

            if (dgvMain.Rows.Count > 0)
            {
                if (txtMeaReportType.Text.Trim().Length == 0)
                {
                    MessageBoxEx.Show("工作报告类型是必选内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMeaReportType.Focus();
                    return;
                }
            }
            if (txtFile.Text == null || txtFile.Text.Length < 4)
            {
                MessageBoxEx.Show("工作报告模板是必选内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((addNew && fileChanged) || file == null)  //insert a file
            {
                if (!insertAFile())
                {
                    MessageBoxEx.Show("插入文件失败，请检查原因", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (fileChanged) //edit a file
            {
                if (!updateAFile())
                {
                    MessageBoxEx.Show("修改文件失败，请检查原因", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            addNew = false;
            fileChanged = false;

            //***************数据保存*****************************************************************************
            bindingSourceMain.EndEdit();
            DataTable dtb = (DataTable)bindingSourceMain.DataSource;//从BindingSource组件中取得信息集放到DataTable中去.
            bindingSourceMain.EndEdit();
            //更新结果报告.
            if (commonOpt.SaveFormData(dtb, "T_Measure_Report_Type", 0, out err))
            {
                //保存数据后刷新BindingSource数据源组件.

                this.setBindingSource();
                MessageBoxEx.Show("数据保存成功！", "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBoxEx.Show(err, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            AddButton.Enabled = true;
            addNew = false;
        }

        /// <summary>
        /// 关闭窗体.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 在窗体关闭时清空文档管理器信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMeaReportType_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileOperation.FileBoundingOperation.Instance.FileBoundCheck("", "", 0, "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "模板文件选择";
            if (OpenFileDialogEx.ShowDialog(openFileDialog) == DialogResult.OK)
            {
                file = null;
                btnView.Enabled = false;
                dealFile(openFileDialog.FileNames[0]);
            }
        }

        public void dealFile(string fileName)
        {
            if (fileName == null) return;
            fileChanged = true;
            btnView.Enabled = true;
            if (txtMeaReportType.Text.Length == 0)
            {
                FileInfo f = new FileInfo(fileName);
                txtMeaReportType.Text = f.Name.Substring(0, f.Name.Length - f.Extension.Length);
            }
            txtFile.Text = fileName;
            txtFile.Tag = "";
        }

        /// <summary>
        /// 插入文件.
        /// </summary>
        /// <returns>bool是否成功</returns>
        private bool insertAFile()
        {
            string err;
            #region 构造文件过程

            try
            {
                file = new ourFile();
                if (tempFile != null)
                {
                    if (tempFile.File_Type == "DOT") return true;
                    file.Size = tempFile.Size;
                    file.FileName = tempFile.FileName;
                }
                else
                {
                    FileInfo myFileInfo = new FileInfo((string)txtFile.Text);
                    file.Size = (long)(myFileInfo.Length);
                    file.FileName = myFileInfo.Name;
                }
                file.Creator = CommonOperation.ConstParameter.UserName;
                file.File_Type = "DOT";
            #endregion
                if (FolderFileDbService.Instance.InsertAFile(folder.NodeId, file, (string)txtFile.Text, out err))
                {
                    this.btnView.Tag = file.FileId;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 修改一个文件.
        /// </summary>
        /// <returns></returns>
        private bool updateAFile()
        {
            string err;

            #region 构造文件过程

            try
            {
                file = new ourFile();
                if (tempFile != null)
                {
                    if (tempFile.File_Type == "DOT") return true;
                    file.Size = tempFile.Size;
                    file.FileName = tempFile.FileName;
                }
                else
                {
                    FileInfo myFileInfo = new FileInfo((string)txtFile.Text);
                    file.Size = (long)(myFileInfo.Length);
                    file.FileName = myFileInfo.Name;
                }
                file.ShipId = ucShipSelect1.GetId();
                file.Creator = CommonOperation.ConstParameter.UserName;
                file.File_Type = "DOT";
                file.UpdateDate = DateTime.Today;
            #endregion

                if (FileDbService.Instance.UpdateAFile(file, (string)txtFile.Text, out err))
                {
                    btnView.Tag = file.FileId;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;

            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            openFile of = new openFile();
            string Id = (string)btnView.Tag;
            if (string.IsNullOrEmpty(Id))
            {
                Tools.FileOpen(txtFile.Text);
            }
            else
            {
                ourFile file = new ourFile();
                file.FileId = Id;
                of.FileOpen(file, right.R);
            }
        }

        private void btnBdFiles_Click(object sender, EventArgs e)
        {
            //非修改有效数据或正在添加新数据时，直接退出.

            if (txtMeaReportType.Tag == null && !addNew) return;
            FileReference frf = new FileReference(true);
            frf.ShowDialog();
            if (string.IsNullOrEmpty(frf.TheSelectedFileId)) return;
            FileDbService.Instance.GetAFileById(frf.TheSelectedFileId, out tempFile);
            this.btnView.Tag = frf.TheSelectedFileId;
            fileChanged = true;
            txtFile.Text = tempFile.FileName;
        }

        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            this.setBindingSource();//设置数据源.

            folder = FolderDbService.Instance.getFolderByFolderType(FileBoundingTypes.MEASUREREPORTMODEL, ucShipSelect1.GetId());
            if (folder == null)
            {
                MessageBoxEx.Show("缺少本船的工作报告存放目录,请重新初始化本船文件目录(在船舶基本信息维护界面中),再进行本操作!");
            }
        }
    }

}