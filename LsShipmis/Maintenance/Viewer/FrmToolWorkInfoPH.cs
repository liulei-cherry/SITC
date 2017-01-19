/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmToolWorkInfoPH.cs
 * 创 建 人：黄家龙
 * 创建时间：2011-10-18
 * 标    题：PMS初始化打印工具
 * 功能描述：
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
using Maintenance.Services;
using Maintenance.DataObject;
using OfficeOperation;
using CommonViewer.BaseControl;
using CommonViewer.BaseForm;
using CommonOperation.Functions;
using System.Text.RegularExpressions;

namespace Maintenance.Viewer
{
    /// <summary>
    /// 船舶信息管理业务窗体.
    /// </summary>
    public partial class FrmToolWorkInfoPH : CommonViewer.BaseForm.BaseMdiChildForm
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmToolWorkInfoPH instance = new FrmToolWorkInfoPH();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        /// 
        public static FrmToolWorkInfoPH Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmToolWorkInfoPH.instance = new FrmToolWorkInfoPH();
                }
                return FrmToolWorkInfoPH.instance;
            }
        }
        #endregion

        #region 窗体引用对象
        Dictionary<string, string> dictColumns = new Dictionary<string, string>();
        string ship_id = "";

        public string Ship_id
        {
            get { return ship_id; }
            set { ship_id = value; }
        }
        #endregion

        #region dgvThree上下文菜单

        private ToolStripMenuItem tspMnuToolAddLine = new ToolStripMenuItem("添加行");
        private ToolStripMenuItem tspMnuToolDelLine = new ToolStripMenuItem("删除行");
        #endregion
        
        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmToolWorkInfoPH()
        {
            InitializeComponent();
            tspMnuToolAddLine.Click += new EventHandler(tspMnuToolAddLine_Click);
            tspMnuToolDelLine.Click += new EventHandler(tspMnuToolDelLine_Click);
        }

        void tspMnuToolDelLine_Click(object sender, EventArgs e)
        {
            string err = "";
            string unitid = dgvThree.Rows[dgvThree.CurrentCell.RowIndex].Cells["MAPID"].Value.ToString();
            T_TOOL_WORKINFO_COLUMN_MAPService.Instance.deleteUnit(unitid, out err);
            if (err.Length > 0)
            {
                MessageBoxEx.Show("删除失败" + err);
            }
            else
            {
                dgvThree.Rows.RemoveAt(dgvThree.CurrentCell.RowIndex);
            }
        }

        void tspMnuToolAddLine_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgvThree.DataSource;
            dt.Rows.Add(dt.NewRow());
        }

        private void FrmPortInfo_Load(object sender, EventArgs e)
        {
            cobreportType.SelectedIndex = 0;
            reloadData();
            loadDataColName();
            setColumnsVisble();
            setSomeRowsInvisible(); //dgvThree隐藏某些行.

            string[] sCols = new string[] { "字段名", "字段说明" };
            dgvOne.setDgvColumnsReadOnly(sCols);
            dgvTwo.setDgvColumnsReadOnly(sCols);
            dgvThree.setDgvColumnsReadOnly(sCols);
        }

        private void FrmPortInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        #region IFunctionChildWindow 成员
        
        public new List<CommonOperation.BaseClass.Authority> GetAllAuthorityCanOpenThisWindow()
        {
            List<CommonOperation.BaseClass.Authority> re = new List<CommonOperation.BaseClass.Authority>();
            re.Add(CommonOperation.BaseClass.Authority.GetALoginUserAuthority());//最低权限即可.

            return re;
        }

        //本窗体不受限制.

        public new bool JudgeTheAuthorityCanOpenThisWindow(CommonOperation.BaseClass.Authority theAuthority)
        {
            return true;
        }

        private IFunctionMainWindow theMainForm;
        public new IFunctionMainWindow TheMainForm
        {
            get { return theMainForm; }
            set { theMainForm = value; }
        }

        #endregion

        #region 控件事件区

        /// <summary>
        /// 关闭窗体.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string err = "";
            foreach (DataGridViewRow c in dgvTwo.Rows)
            {
                T_TOOL_WORKINFO_COLUMN_MAP unit = new T_TOOL_WORKINFO_COLUMN_MAP();
                unit.MAPID = c.Cells["MAPID"].Value.ToString();
                unit.TOOL_COLUMN_NAME = c.Cells["TOOL_COLUMN_NAME"].Value.ToString();
                unit.WORK_COLUMN_NAME = c.Cells["字段名"].Value.ToString();
                unit.MAPTYPE = 0;
                unit.ORDER_NUM = string.IsNullOrEmpty(c.Cells["ORDER_NUM"].Value.ToString()) ? 0 : Int32.Parse(c.Cells["ORDER_NUM"].Value.ToString());
                T_TOOL_WORKINFO_COLUMN_MAPService.Instance.saveUnit(unit, out err);
            }

            foreach (DataGridViewRow c in dgvThree.Rows)
            {
                T_TOOL_WORKINFO_COLUMN_MAP unit = new T_TOOL_WORKINFO_COLUMN_MAP();
                unit.MAPID = c.Cells["MAPID"].Value.ToString();
                unit.TOOL_COLUMN_NAME = c.Cells["TOOL_COLUMN_NAME"].Value.ToString();
                unit.WORK_COLUMN_NAME = c.Cells["字段名"].Value.ToString();
                unit.MAPTYPE = 1;
                unit.ORDER_NUM = string.IsNullOrEmpty(c.Cells["ORDER_NUM"].Value.ToString()) ? 0 : Int32.Parse(c.Cells["ORDER_NUM"].Value.ToString());
                T_TOOL_WORKINFO_COLUMN_MAPService.Instance.saveUnit(unit, out err);
            }

            Cursor.Current = Cursors.Default;
            if (err.Length > 0)
            {
                MessageBoxEx.Show("保存失败" + err);
            }
        }

        #endregion

        #region 数据初始化区
        private void reloadData()
        {
            string err;

            DataTable dt = T_TOOL_WORKINFOService.Instance.getColumnsInfo("T_TOOL_WORKINFO", out err);
            dgvOne.DataSource = dt;

            DataTable dt1 = T_TOOL_WORKINFOService.Instance.getColumnsInfoTwo("T_WORKINFO",0, out err);
            dgvTwo.DataSource = dt1;

            DataTable dt2 = T_TOOL_WORKINFOService.Instance.getColumnsInfoTwo("T_WORKINFO_HISTORY_OUT",1, out err);
            dgvThree.DataSource = dt2;
        }

        #endregion

        #region 拖拽操作
        private void dgvOne_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                DataGridView.HitTestInfo info = this.dgvOne.HitTest(e.X,e.Y);

                if(info.RowIndex >= 0)
                {
                    if(info.RowIndex >= 0 && info.ColumnIndex >= 0)
                    {
                        string text = (String)this.dgvOne.Rows[info.RowIndex].Cells[info.ColumnIndex].Value;

                        if(text != null)
                        {
                            this.dgvOne.DoDragDrop(text,DragDropEffects.Copy);
                        }
                    }
                }
            }
        }

        private void dgvThree_DragDrop(object sender, DragEventArgs e)
        {
            Point p = this.dgvThree.PointToClient(new Point(e.X, e.Y));
            DataGridView.HitTestInfo hit = this.dgvThree.HitTest(p.X,p.Y);
            if(hit.Type == DataGridViewHitTestType.Cell)
            {
                DataGridViewCell clickedCell = this.dgvThree.Rows[hit.RowIndex].Cells[hit.ColumnIndex];
                clickedCell.Value = (System.String)e.Data.GetData(typeof(System.String));
            }
        }

        private void dgvThree_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        /// <summary>
        /// 设置界面上的网格的一些常用的快捷菜单的事件处理.
        /// </summary>
        private void setGridShortCutBtn()
        {
            this.dgvThree.CtxMenu.Items.Add(new ToolStripSeparator());
            this.dgvThree.CtxMenu.Items.Add(tspMnuToolAddLine);
            this.dgvThree.CtxMenu.Items.Add(tspMnuToolDelLine);
        }
        #endregion

        /// <summary>
        /// 设置主列项.
        /// </summary>
        private void loadDataColName()
        {
            dictColumns.Clear();

            //设置列标题.

            dictColumns.Add("MAPID", "ID");//0
            dictColumns.Add("TOOL_COLUMN_NAME", "工具表列名");
            dictColumns.Add("字段名", "字段名");
            dictColumns.Add("字段说明", "字段说明");
            dictColumns.Add("ORDER_NUM", "排序号");

            dgvTwo.SetDgvGridColumns(dictColumns);
            dgvThree.SetDgvGridColumns(dictColumns);
        }

        /// <summary>
        /// 设置列隐藏.
        /// </summary>
        private void setColumnsVisble()
        {
            foreach (DataGridViewColumn curColumn in dgvOne.Columns)
            {
                curColumn.Tag = 0;
                curColumn.Visible = true;
            }

            dgvTwo.Columns[0].Visible = false;
            dgvThree.Columns[0].Visible = false;
        }

        /// <summary>
        /// 自动匹配.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void autoLinkButton_Click(object sender, EventArgs e)
        {
            StringBuilder parentString = new StringBuilder();
            string value = "";
            string temp = "";

            foreach (DataGridViewRow row in dgvOne.Rows)
            {
                parentString.Append(row.Cells["字段名"].Value.ToString()).Append(",");
            }

            temp = parentString.ToString();
            //工作信息匹配.

            foreach (DataGridViewRow row in dgvTwo.Rows)
            {
                value = row.Cells["字段名"].Value.ToString() + ",";
                if (temp.Contains(value))
                {
                    row.Cells["TOOL_COLUMN_NAME"].Value = (object)value.Substring(0, value.Length - 1);
                }
            }

            //历史匹配.
            foreach (DataGridViewRow row in dgvThree.Rows)
            {
                value = row.Cells["字段名"].Value.ToString() + ",";
                if (temp.Contains(value))
                {
                    row.Cells["TOOL_COLUMN_NAME"].Value = (object)value.Substring(0, value.Length - 1);
                }
            }
        }

        private void dgvTwo_DragDrop(object sender, DragEventArgs e)
        {
            Point p = this.dgvTwo.PointToClient(new Point(e.X, e.Y));
            DataGridView.HitTestInfo hit = this.dgvTwo.HitTest(p.X, p.Y);
            if (hit.Type == DataGridViewHitTestType.Cell)
            {
                DataGridViewCell clickedCell = this.dgvTwo.Rows[hit.RowIndex].Cells[hit.ColumnIndex];
                clickedCell.Value = (System.String)e.Data.GetData(typeof(System.String));
            }
        }

        private void dgvTwo_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string err = "";
            //工作信息表和历史表信息导入.

            Dictionary<string, string> dicOne = new Dictionary<string, string>();
            Dictionary<string, string> dicTwo = new Dictionary<string, string>();

            foreach (DataGridViewRow c in dgvTwo.Rows)
            {
                string keyTemp = c.Cells["字段名"].Value.ToString();
                if (!keyTemp.Equals("WORKINFOSTATE"))
                {
                    if (!dicOne.ContainsKey(keyTemp))
                    {
                        dicOne.Add(keyTemp, c.Cells["TOOL_COLUMN_NAME"].Value.ToString());
                    }
                }
            }

            foreach (DataGridViewRow c in dgvThree.Rows)
            {
                string keyTemp = c.Cells["字段名"].Value.ToString();
                if (!string.IsNullOrEmpty(c.Cells["TOOL_COLUMN_NAME"].Value.ToString()))
                {
                    if (!dicTwo.ContainsKey(keyTemp))
                    {
                        dicTwo.Add(c.Cells["字段名"].Value.ToString(), c.Cells["TOOL_COLUMN_NAME"].Value.ToString());
                    }
                }
            }
            dicTwo.Add("WHID", "NEWID()");
            dicTwo.Add("REPROT_TYPE", cobreportType.Text.Equals("甲板类型") ? "1" : "2");
            dicTwo.Add("ANNUAL", "cast('" + dtpYear.Value.ToString() + "' as datetime)");

            T_TOOL_WORKINFOService.Instance.importToTables(dicOne, dicTwo, cobreportType.Text.Equals("甲板类型") ? 1:2, ship_id,dtpYear.Value.ToString(), out err);

            if (err.Length == 0)
            {
                MessageBoxEx.Show("导入成功！");
            }
            else
            {
                MessageBoxEx.Show("失败：" + err);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// 设置dgvThree某些列隐藏.
        /// </summary>
        private void setSomeRowsInvisible()
        {
            string value = "";
            foreach(DataGridViewRow row in dgvThree.Rows)
            {
                value = row.Cells["字段名"].Value.ToString();
                if (value.Equals("WHID") || value.Equals("REPROT_TYPE") || value.Equals("ANNUAL"))
                {
                    row.Visible = false;
                }
            }

            foreach (DataGridViewRow row in dgvTwo.Rows)
            {
                value = row.Cells["字段名"].Value.ToString();
                if (value.Equals("WORKINFOSTATE"))
                {
                    row.Visible = false;
                }
            }
        }
    }
}