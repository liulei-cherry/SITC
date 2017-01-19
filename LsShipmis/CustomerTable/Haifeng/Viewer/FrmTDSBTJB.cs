/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmTDSBTJB.cs
 * 创 建 人：
 * 创建时间：
 * 标    题：
 * 功能描述： * 修 改 人：
 * 修改时间： * 修改内容： ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonOperation.Interfaces;
using CommonViewer.BaseForm;
using CommonOperation.Functions;
using BaseInfo.Objects;
using BaseInfo.DataAccess;
using FileOperationBase.Services;
using System.IO;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using CustomerTable.Forms;
using FileOperationBase.FileServices;
using CommonViewer.BaseControl;
using OfficeOperation;
using CustomTable.Haifeng.Services;
using CommonOperation.BaseClass;
using CommonOperation;

namespace CustomTable.Haifeng.Viewer
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FrmTDSBTJB : CommonViewer.BaseForm.FormBase
    {
        string shipid = null;
        static string modelName = CommonPrintTableName.CTNofTDSBTJB;

        #region 窗体单实例模型


        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmTDSBTJB instance = new FrmTDSBTJB();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmTDSBTJB Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmTDSBTJB.instance = new FrmTDSBTJB();
                }

                return FrmTDSBTJB.instance;
            }
        }

        #endregion

        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmTDSBTJB()
        {
            InitializeComponent();
        }


        private void FrmTDSBTJB_Load(object sender, EventArgs e)
        {          
        }

        private void setAlertState()
        {
            //如果超期红色,如果报警橙色.
            foreach (DataGridViewRow dr in dgvMain.Rows)
            {
                DateTime alertDate;
                if (dr.Cells["DueDate"].Value != null && DateTime.TryParse(dr.Cells["DueDate"].Value.ToString(), out alertDate))
                {
                    if (alertDate < DateTime.Today.AddDays(1))
                    {
                        //红色.
                        dr.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else if (alertDate < DateTime.Today.AddDays(90))
                    {
                        //桔黄色.
                        dr.DefaultCellStyle.ForeColor = Color.Orange;
                    }
                }
            }
        }
        #region  按钮部分
        private void btnSave_Click(object sender, EventArgs e)
        {
            string err = "";//错误信息参数.
            dgvMain.EndEdit();

            //数据保存.
            bindingSourceMain.EndEdit();
            DataTable dtb = (DataTable)bindingSourceMain.DataSource;
            if (dbOperation.SaveFormData(dtb, "T_CTB_TDSBTJB", 0, out err))
            {
                MessageBoxEx.Show("数据保存成功！", "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                setAlertState();
            }
            else
            {
                MessageBoxEx.Show(err, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            string fileName = ucShipSelect1.GetText() + "轮通信导航设备有效期统计表.xls";
            if (dgvMain.Rows.Count == 0)
            {
                MessageBoxEx.Show("无数据需要打印！");
                return;
            }
            string dPath = savePath(this.folderBD);
            if (string.IsNullOrEmpty(dPath)) return;
            dPath = saveFilePath(dPath, fileName);
            if (dPath == "") return;
            Cursor.Current = Cursors.WaitCursor;
            gridToExcel(dPath);
            Cursor.Current = Cursors.Default;

        }
        #region 打印用到的函数

        //取得保存的文件夹路径.
        private string savePath(FolderBrowserDialog folderBD)
        {
            string path;
            //指定对话框的起始根文件夹.
            folderBD.RootFolder = Environment.SpecialFolder.Desktop;

            //指定初始选定的文件夹.
            folderBD.SelectedPath = @"c:\";

            //指定对话框显示的文字说明.
            folderBD.Description = "请选择存放文件的路径";

            //定义变量用于接收对话框返回的信息.
            DialogResult dr = FolderBrowserDialogEx.ShowDialog(folderBD);
            if (dr == DialogResult.OK)
                path = folderBD.SelectedPath.ToString();
            else
                path = "";
            return path;
        }

        private string saveFilePath(string path, string filename)
        {
            string filepath = System.IO.Path.Combine(path, filename);
            if (System.IO.File.Exists(filepath))
            {
                DialogResult result = MessageBoxEx.Show("是否覆盖原文件?", "请注意", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Cancel)
                {
                    filepath = "";
                }
                else if (result == DialogResult.No)
                {
                    filename = DateTime.Now.Millisecond.ToString().Trim() + "_" + filename;
                    filepath = System.IO.Path.Combine(path, filename);
                }
            }
            return filepath;
        }

        private void gridToExcel(string path)
        {
            FileInfo f = new FileInfo(path);
            string err;
            using (OfficeOperation.OperationExcel operExcel = new OperationExcel())
            {

                string[,] allData = new string[dgvMain.Rows.Count, 7];
                for (int i = 0; i < dgvMain.Rows.Count; i++)
                {  //ID, EquipmentName, SortNo, DueDate, EquipmentFactory, EquipmentType, EquipSerialNo, Detail, SHIP_ID
                    DataGridViewRow dr = dgvMain.Rows[i];
                    allData[i, 0] = dr.Cells["SEQUNCE"].Value.ToString();
                    allData[i, 1] = dr.Cells["EquipmentName"].Value.ToString();
                    allData[i, 2] = dr.Cells["DueDate"].Value.ToString();
                    allData[i, 3] = dr.Cells["EquipmentFactory"].Value.ToString();
                    allData[i, 4] = dr.Cells["EquipmentType"].Value.ToString();
                    allData[i, 5] = dr.Cells["EquipSerialNo"].Value.ToString();
                    allData[i, 6] = dr.Cells["Detail"].Value.ToString();
                }
                if (!operExcel.AddTitle("通信导航设备有效期统计表", 1, out err)
                   || !operExcel.InsertABodyUnit(new OneUnit("序号", false, 2, 1, 1, 1, false, false, XlHorizontalAlignment.xlCenter), out err)
                   || !operExcel.InsertABodyUnit(new OneUnit("设备明细", false, 2, 2, 1, 1, false, false, XlHorizontalAlignment.xlCenter), out err)
                   || !operExcel.InsertABodyUnit(new OneUnit("到期/更新/保养日期", false, 2, 3, 1, 1, false, false, XlHorizontalAlignment.xlCenter), out err)
                   || !operExcel.InsertABodyUnit(new OneUnit("设备厂家", false, 2, 4, 1, 1, false, false, XlHorizontalAlignment.xlCenter), out err)
                   || !operExcel.InsertABodyUnit(new OneUnit("设备型号", false, 2, 5, 1, 1, false, false, XlHorizontalAlignment.xlCenter), out err)
                   || !operExcel.InsertABodyUnit(new OneUnit("设备系列号", false, 2, 6, 1, 1, false, false, XlHorizontalAlignment.xlCenter), out err)
                   || !operExcel.InsertABodyUnit(new OneUnit("备注", false, 2, 7, 1, 1, false, false, XlHorizontalAlignment.xlCenter), out err)
                   || !operExcel.InsertATable(new OneTable(allData, false, 3, 1, dgvMain.Rows.Count, 7, false, XlHorizontalAlignment.xlLeft), out err))
                {
                    MessageBoxEx.Show(err);
                    return;
                }
                operExcel.InsertAGrid(new OneGrid(2, 1, dgvMain.Rows.Count + 1, 7));
                operExcel.ExportToExcel(path, true, out err);
            }
            Tools.FileOpen(path);
        } 
        #endregion
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        /// <summary>
        /// 释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmTDSBTJB_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvMain.SaveGridView("FrmTDSBTJB.dgvMain");
            instance = null;    //释放窗体实例变量.
        }



        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            if (theSelectedObject != shipid)
            {
                shipid = theSelectedObject;
                string err;
                DataTable dtAllDate = CTB_TDSBTJBService.Instance.getInfoOfOneShip(shipid, out err);
                bindingSourceMain.DataSource = dtAllDate;
                dgvMain.DataSource = bindingSourceMain;
                setDataGridView();
            }
        }
        /// <summary>
        /// 设置dgvMain的隐藏列与显示标题.
        /// </summary>
        private void setDataGridView()
        {
            dgvMain.LoadGridView("FrmTDSBTJB.dgvMain");
            dgvMain.SetDataGridViewNoSort();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            //ID, EquipmentName, SortNo, DueDate, EquipmentFactory, EquipmentType, EquipSerialNo, Detail, SHIP_ID
            dic.Add("SEQUNCE", "序号");
            dic.Add("EquipmentName", "设备明细");
            dic.Add("DueDate", "到期/更新/保养日期");
            dic.Add("EquipmentFactory", "设备厂家");
            dic.Add("EquipmentType", "设备型号");
            dic.Add("EquipSerialNo", "设备系列号");
            dic.Add("Detail", "备注");
            dgvMain.SetDgvGridColumns(dic);
            if (dgvMain.Columns.Count > 0)
                dgvMain.setDgvColumnsReadOnly(new string[] { "SEQUNCE", "EquipmentName" });
            DgvBindDrop dgvBindDrop = new DgvBindDrop();
            dgvBindDrop.bindDropToDgv(dgvMain, dateTimePicker1, "DueDate");
            dgvMain.SetDgvGridDateColumnsFormatShort();
            setAlertState();
        }

        private void FrmTDSBTJB_Shown(object sender, EventArgs e)
        {
            ucShipSelect1.ChangeSelectedState(false, true);
            string shipId;
            int i = CTB_TDSBTJBService.Instance.GetAlertTDSB(out shipId);
            if (i > 0)
            {
                ucShipSelect1.SelectedId(shipId);
            }
        }         
    }
}