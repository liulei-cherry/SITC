/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 创 建 人：夏喜龙
 * 创建时间：2011-5-3
 * 功能描述：船舶设备日常操作步骤说明信息管理功能
 * 修 改 人： 
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using CommonViewer.BaseControlService;
using CommonOperation.Interfaces;
using BaseInfo.DataAccess;
using BaseInfo.Objects;
using System.Runtime.InteropServices;
using ItemsManage.DataObject;
using ItemsManage.Services;
using CommonViewer.BaseControl;
using FileOperationBase.FileServices;
using FileOperationBase.Services;

namespace ItemsManage.Viewer
{
    /// <summary>
    /// 主窗体.
    /// </summary>
    public partial class FrmEquipmentOperation : CommonViewer.BaseForm.FormBase
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmEquipmentOperation instance = new FrmEquipmentOperation();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmEquipmentOperation Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmEquipmentOperation.instance = new FrmEquipmentOperation();
                }
                return FrmEquipmentOperation.instance;
            }
        }
        #endregion

        #region 全局对象

        private ComponentUnit component;
        public ComponentUnit Component
        {
            get { return component; }
            set { 
                component = value;
                buttonEx5.Text = component.COMP_CHINESE_NAME + ":设备操作说明";
            }
        }

        private EquipmentOperation equipOperation;
        public EquipmentOperation EquipOperation
        {
            get { return equipOperation; }
            set { equipOperation = value;}
        }

        private string fileName;      //文件名称.
        #endregion
        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmEquipmentOperation()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 添加操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            EquipmentOperation newOperation = new EquipmentOperation();
            newOperation.EQUIPMENTID = component.COMPONENT_TYPE_ID;
            newOperation.SORTNO = dgvOperation.RowCount + 1;

            FrmEditEquipmentOperation formNew = new FrmEditEquipmentOperation(newOperation);
            formNew.ShowDialog();
            this.reloadData();
        }

        /// <summary>
        /// 删除操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {

            string err;
            
            if (equipOperation == null)
            {
                MessageBoxEx.Show("请选择一条要删除的设备操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBoxEx.Show("是否删除当前设备操作？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            EquipmentOperationService.Instance.deleteUnit(equipOperation, out err);
            this.reloadData();
        }

        /// <summary>
        /// 保存操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (equipOperation == null)
            {
                MessageBoxEx.Show("请选择要修改的设备操作！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            equipOperation.SORTNO = int.Parse(numOrderNum.Value.ToString());
            equipOperation.OPERATIONDETAIL = txtDetail.Text;

            string err;
            if (!EquipmentOperationService.Instance.saveUnit(equipOperation, out err))
            {
                MessageBoxEx.Show(err, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else {
                MessageBoxEx.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dgvOperation_RowEnter(dgvOperation, new DataGridViewCellEventArgs(0, dgvOperation.CurrentRow.Index));
        }

        /// <summary>
        /// 主窗体加载.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPortInfo_Load(object sender, EventArgs e)
        {
            dgvOperation.CtxMenu.Enabled = false;
            reloadData();
        }

        /// <summary>
        /// 主窗体关闭.
        /// </summary>
        private void FrmPortInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataGridViewExt.saveGridView(dgvOperation, CommonOperation.ConstParameter.UserId, "FrmEquipmentOperation.dgvOperation");
            instance = null;    //释放窗体实例变量.
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
        /// 加载初始数据.
        /// </summary>
        public void reloadData()
        {
            //取得设备操作列表信息的DataTable对象.
            DataTable dtbEquipOperation = EquipmentOperationService.Instance.GetOperationByEquipment(component);
            dgvOperation.DataSource = dtbEquipOperation;

            //设置列标题.
            DataGridViewExt.loadGridView(dgvOperation, CommonOperation.ConstParameter.UserId, "FrmEquipmentOperation.dgvOperation");

            dgvOperation.Columns["EQUOPERATIONID"].Visible = false;
            dgvOperation.Columns["SORTNO"].Visible = false;
            dgvOperation.Columns["EQUIPMENTID"].Visible = false;
            dgvOperation.Columns["OPERATIONDETAIL"].Visible = false;

            dgvOperation.Columns["OPERATIONNAME"].HeaderText = "设备操作名称";
            dgvOperation.Columns["OPERATIONNAME"].Width = 200;

        }

        /// <summary>
        /// 操作选择事件.
        /// </summary>
        private void dgvOperation_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string ID = "";
            string err ="";
            if (DBNull.Value != dgvOperation["EQUOPERATIONID",e.RowIndex].Value && null != dgvOperation["EQUOPERATIONID",e.RowIndex].Value)
                ID = dgvOperation["EQUOPERATIONID",e.RowIndex].Value.ToString();
            EquipOperation =  EquipmentOperationService.Instance.getObject(ID,out err);
            //显示对象到页面.
            objectToView(EquipOperation);

            //显示文件列表到页面.
            DataTable dt = FolderFileDbService.Instance.GetFileByFolder(equipOperation.GetId());
            lstVPic.LargeImageList = imageList2;
            lstVPic.Clear();
            foreach (DataRow row in dt.Rows)
            {
                string file_name = row["FILE_NAME"].ToString();
                ListViewItem item = new ListViewItem(file_name);
                item.Tag = row["file_id"];

                string ext = System.IO.Path.GetExtension(file_name);
                if (".gif,.jpg,.jpeg,.bmp,.wmf,.png".Contains(ext))
                {
                    item.ImageIndex = 1;
                }
                else
                {
                    item.ImageIndex = 0;
                }

                lstVPic.Items.Add(item);

            }

            //电子资料设置.
            FileOperation.FileBoundingOperation.Instance.FileBoundCheck(equipOperation.EQUOPERATIONID,
                 component.COMP_CHINESE_NAME + "/" + equipOperation.OPERATIONNAME, CommonOperation.Enum.FileBoundingTypes.COMPONENTOPERATION, null);

            //清空图片的显示.
            pictureBox.ImageLocation = "";

        }

        /// <summary>
        /// 显示对象到页面.
        /// </summary>
        public void objectToView(EquipmentOperation operation)
        {
            numOrderNum.Value = operation.SORTNO;
            txtDetail.Text = operation.OPERATIONDETAIL;
        }

        /// <summary>
        /// 文件列表项激活事件.
        /// </summary>
        private void lstVPic_ItemActivate(object sender, EventArgs e)
        {
            ListView lstV = (ListView)sender;

            if (FileDbService.Instance.GetABolbByFileId((string)lstV.SelectedItems[0].Tag, out fileName))
            {
                if (IsImage(fileName))
                {
                    setPictureScale(true);//如果是图片则显示.
                }
                else {
                    setPictureScale(false);//如果不是图片则清空.

                    //是文件就打开.
                    ourFile file;
                    FileDbService.Instance.GetAFileById((string)lstV.SelectedItems[0].Tag, out file);

                    if (!string.IsNullOrEmpty(file.Object_id) && file.Object_id.Trim().Length == 36)
                    {
                        openFile oFile = new openFile();
                        oFile.FileOpen(file, right.R);
                    }

                }
            }  
        }

        /// <summary>
        /// 判断文件是否为图片.
        /// </summary>
        /// <param name="path">文件的完整路径</param>
        /// <returns>返回结果</returns>
        public Boolean IsImage(string path)
        {
            try
            {
                System.Drawing.Image img = System.Drawing.Image.FromFile(path);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 设置图片只能水平显示.
        /// </summary>
        private void setPictureScale(bool isImage)
        {
            string imageName = "";
            if (isImage) imageName = fileName;
            pictureBox.Refresh();
            pictureBox.ImageLocation = imageName;
        }

        /// <summary>
        /// 图片放大缩小.
        /// </summary>
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (pictureBox.Width < 3000)
                {
                    pictureBox.Width = Convert.ToInt32(pictureBox.Width * 1.2);
                    pictureBox.Height = Convert.ToInt32(pictureBox.Height * 1.2);
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                if (pictureBox.Width > 600)
                {
                    pictureBox.Width = Convert.ToInt32(pictureBox.Width / 1.2);
                    pictureBox.Height = Convert.ToInt32(pictureBox.Height / 1.2);
                }
            }
        }

        /// <summary>
        /// 文件操作.
        /// </summary>
        private void btnFile_Click(object sender, EventArgs e)
        {
            if (equipOperation == null || equipOperation.IsWrong) return;
            if (string.IsNullOrEmpty(equipOperation.GetId()))
            {
                MessageBoxEx.Show("当前设备操作为空,无法查看绑定文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {

                FileOperation.FileBoundingOperation.Instance.FileBoundOperation();
                dgvOperation_RowEnter(dgvOperation,new DataGridViewCellEventArgs(0,dgvOperation.CurrentRow.Index));

            }
        }

        private void dgvOperation_DataSourceChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgvOperation.DataSource;
            if (dt.Rows.Count == 0)
            {
                numOrderNum.Value = 1;
                numOrderNum.Enabled = false;
                txtDetail.Text = "";
                txtDetail.Enabled = false;

                lstVPic.Clear();
                pictureBox.ImageLocation = "";

                EquipOperation = null;

            }else{
                numOrderNum.Enabled = true;
                txtDetail.Enabled = true;
            }

        }

    }
}