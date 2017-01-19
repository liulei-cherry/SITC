/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmXFJSTJB.cs
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
    public partial class FrmXFJSTJB : CommonViewer.BaseForm.FormBase
    {
        string shipid = null;
        static string modelName = CommonPrintTableName.CTNofXFJSTJB;

        #region 窗体单实例模型


        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmXFJSTJB instance = new FrmXFJSTJB();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmXFJSTJB Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmXFJSTJB.instance = new FrmXFJSTJB();
                }

                return FrmXFJSTJB.instance;
            }
        }

        #endregion

        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmXFJSTJB()
        {
            InitializeComponent();
        }


        private void FrmXFJSTJB_Load(object sender, EventArgs e)
        {            
        }

        private void setAlertState()
        {
            //如果超期红色,如果报警橙色.
            foreach (DataGridViewRow dr in dgvMain.Rows)
            {
                DateTime alertDate;
                if (dr.Cells["WarningDate"].Value != null && DateTime.TryParse(dr.Cells["WarningDate"].Value.ToString(), out alertDate))
                {
                    if (alertDate < DateTime.Today.AddDays(1))
                    {
                        //红色.
                        dr.DefaultCellStyle.ForeColor = Color.Red;
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
            if (dbOperation.SaveFormData(dtb, "T_CTB_XFJSTJB", 0, out err))
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
            string fileName = ucShipSelect1.GetText() + "轮消防救生设备、器材统计上报表.xls";
           
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
            gridToExcel(dPath, fileName);
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

        private void gridToExcel(string path, string title)
        {
            FileInfo f = new FileInfo(path);
            string err;
            using (OfficeOperation.OperationExcel operExcel = new OperationExcel())
            {

                string[,] allData = new string[dgvMain.Rows.Count, 5];
                for (int i = 0; i < dgvMain.Rows.Count; i++)
                {
                    DataGridViewRow dr = dgvMain.Rows[i];
                    allData[i, 0] = dr.Cells["EquipmentName"].Value.ToString();
                    allData[i, 1] = dr.Cells["EquipmentCOUNT"].Value.ToString();
                    allData[i, 2] = dr.Cells["EquipmentSPEC"].Value.ToString();
                    allData[i, 3] = dr.Cells["LastCHECKEDDateDetail"].Value.ToString();
                    allData[i, 4] = dr.Cells["ValidDateDetail"].Value.ToString();
                }
                if (!operExcel.AddTitle(title, 1, out err)
                   || !operExcel.InsertABodyUnit(new OneUnit("项目", false, 2, 1, 1, 1, false, false, XlHorizontalAlignment.xlCenter), out err)
                   || !operExcel.InsertABodyUnit(new OneUnit("数量", false, 2, 2, 1, 1, false, false, XlHorizontalAlignment.xlCenter), out err)
                   || !operExcel.InsertABodyUnit(new OneUnit("规格", false, 2, 3, 1, 1, false, false, XlHorizontalAlignment.xlCenter), out err)
                   || !operExcel.InsertABodyUnit(new OneUnit("检验日期", false, 2, 4, 1, 1, false, false, XlHorizontalAlignment.xlCenter), out err)
                   || !operExcel.InsertABodyUnit(new OneUnit("有效期截至", false, 2, 5, 1, 1, false, false, XlHorizontalAlignment.xlCenter), out err)
                   || !operExcel.InsertATable(new OneTable(allData, false, 3, 1, dgvMain.Rows.Count, 5, false, XlHorizontalAlignment.xlLeft), out err))
                {
                    MessageBoxEx.Show(err);
                    return;
                }
                operExcel.InsertAGrid(new OneGrid(2, 1, dgvMain.Rows.Count + 1, 5));
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
        private void FrmXFJSTJB_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvMain.SaveGridView("FrmXFJSTJB.dgvMain");
            instance = null;    //释放窗体实例变量.
        }



        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            if (theSelectedObject != shipid)
            {
                shipid = theSelectedObject;
                string err;
                DataTable dtAllDate = CTB_XFJSTJBService.Instance.getInfoOfOneShip(shipid, out err);
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
            dgvMain.LoadGridView("FrmXFJSTJB.dgvMain");
            dgvMain.SetDataGridViewNoSort();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("EquipmentName", "项目");
            dic.Add("EquipmentCOUNT", "数量");
            dic.Add("EquipmentSPEC", "规格");
            dic.Add("LastCHECKEDDateDetail", "检验日期");
            dic.Add("ValidDateDetail", "有效期");
            dic.Add("WarningDate", "开始报警日期");
            dgvMain.SetDgvGridColumns(dic);
            if (dgvMain.Columns.Count > 0)
                dgvMain.setDgvColumnsReadOnly(new string[] { "EquipmentName" });
            DgvBindDrop dgvBindDrop = new DgvBindDrop();
            dgvBindDrop.bindDropToDgv(dgvMain, dateTimePicker1, "WarningDate");
            dgvMain.SetDgvGridDateColumnsFormatShort();
            setAlertState();
        }

        private void FrmXFJSTJB_Shown(object sender, EventArgs e)
        {
            ucShipSelect1.ChangeSelectedState(false, true);
            string shipId;
            int i = CTB_XFJSTJBService.Instance.GetAlertXFJS(out shipId);
            if (i > 0)
            {
                ucShipSelect1.SelectedId(shipId);
            }
        }
    }
}