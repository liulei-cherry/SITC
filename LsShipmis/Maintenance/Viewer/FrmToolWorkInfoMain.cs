/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmToolWorkInfoMain.cs
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
using CommonViewer;

namespace Maintenance.Viewer
{
    /// <summary>
    /// 船舶信息管理业务窗体.
    /// </summary>
    public partial class FrmToolWorkInfoMain : CommonViewer.BaseForm.BaseMdiChildForm
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmToolWorkInfoMain instance = new FrmToolWorkInfoMain();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmToolWorkInfoMain Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmToolWorkInfoMain.instance = new FrmToolWorkInfoMain();
                }
                return FrmToolWorkInfoMain.instance;
            }
        }
        #endregion

        #region 上下文菜单

        /// <summary>
        /// 删除选中项上下文菜单.
        /// </summary>
        private ToolStripMenuItem tspMnuToolDel = new ToolStripMenuItem("删除选中行(&V)…");

        private ToolStripMenuItem tspMnuToolEditColumns = new ToolStripMenuItem("某列多行值复制");

        private ToolStripMenuItem tspMnuToolWFTrue = new ToolStripMenuItem("工作信息确定");

        private ToolStripMenuItem tspMnuToolWFFalse = new ToolStripMenuItem("工作信息取消");

        #endregion

        #region 窗体引用对象
        Dictionary<string, string> dictColumns = new Dictionary<string, string>();
        private FormControlOption other = FormControlOption.Instance;
        string shipid;
        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmToolWorkInfoMain()
        {
            InitializeComponent();
            tspMnuToolDel.Click += new EventHandler(tspMnuToolDel_Click);
            tspMnuToolEditColumns.Click += new EventHandler(tspMnuToolEditColumns_Click);
            tspMnuToolWFFalse.Click += new EventHandler(tspMnuToolWFFalse_Click);
            tspMnuToolWFTrue.Click += new EventHandler(tspMnuToolWFTrue_Click);
        }

        void tspMnuToolWFTrue_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection collection = dgvOne.SelectedRows;
            foreach (DataGridViewRow row in collection)
            {
                row.Cells["ITEMTYPE"].Value = "1";
            }
            reloadData();
            //setRowsColor();
        }

        void tspMnuToolWFFalse_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection collection = dgvOne.SelectedRows;
            foreach (DataGridViewRow row in collection)
            {
                row.Cells["ITEMTYPE"].Value = "0";
            }
            reloadData();
            //setRowsColor();
        }

        void tspMnuToolEditColumns_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataGridViewSelectedCellCollection collection = dgvOne.SelectedCells;

            if (collection.Count <= 1)
            {
                return;
            }
            int columnStartIndex = collection[collection.Count -1].RowIndex;
            int columnEndIndex = collection[0].RowIndex;
            string columnName = collection[0].DataGridView.CurrentCell.OwningColumn.Name;

            for (int i = columnStartIndex; i <= columnEndIndex; i++)
            {
                dgvOne.Rows[i].Cells[columnName].Value = dgvOne.Rows[columnStartIndex].Cells[columnName].Value;
            }
            Cursor.Current = Cursors.Default;
        }

        private void FrmPortInfo_Load(object sender, EventArgs e)
        {
            setComboBox();
            reloadData();
            loadDataColName();
            setColumnsWidth();
            setColumnsVisble();
            setColumnsReadOnly();
            setGridShortCutBtn();
            //setRowsColor();
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

        private void ParamButton_Click(object sender, EventArgs e)
        {
            FrmToolWorkInfo frm = FrmToolWorkInfo.Instance;
            frm.ShowDialog();
            reloadData();
            //setRowsColor();
        }

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

        private void CompentUnitLinkButton_Click(object sender, EventArgs e)
        {
            FrmToolWorkInfoUnit frm = FrmToolWorkInfoUnit.Instance;
            frm.ShowDialog();
            //刷新列表.
            reloadData();
            //setRowsColor();
        }

        /// <summary>
        /// 清空所有数据.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            string err = "";
            DialogResult result = MessageBoxEx.Show("确定清空所有数据？", "提示", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                T_TOOL_WORKINFOService.Instance.deleteAllData(shipid,cobReportType.Text.Equals("甲板部")? 1:2,out err);
                Cursor.Current = Cursors.Default;
            }
            //刷新列表.
            reloadData();
        }

        /// <summary>
        /// 根据周期初始化项初始化周期.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void circleAutoButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string[] Unit = new string[] { "年", "月", "日", "季度", "半年", "周" };
            string[] Value = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "一", "二", "两", "三", "四", "五", "六", "七", "八", "九", "每" };

            string UnitV = "";
            string VV = "";
            string IniValue = "";
            foreach (DataGridViewRow r in dgvOne.Rows)
            {
                IniValue = r.Cells["CIRCLEPERIOD_INI"].Value.ToString();
                if(string.IsNullOrEmpty(IniValue))
                {
                    continue;
                }

                for (int i = 0; i < Unit.Length; i++)
                {
                    if (IniValue.Contains(Unit[i]))
                    {
                        UnitV = Unit[i];
                        break;
                    }
                }

                for (int j = 0; j < Value.Length; j++)
                {
                    if (IniValue.Contains(Value[j]))
                    {
                        VV = Value[j];
                        break;
                    }
                }

                switch (VV)
                {
                    case ("一"):
                        VV = "1";
                        break;
                    case ("二"):
                        VV = "2";
                        break;
                    case ("两"):
                        VV = "2";
                        break;
                    case ("三"):
                        VV = "3";
                        break;
                    case ("四"):
                        VV = "4";
                        break;
                    case ("五"):
                        VV = "5";
                        break;
                    case ("六"):
                        VV = "6";
                        break;
                    case ("七"):
                        VV = "7";
                        break;
                    case ("八"):
                        VV = "8";
                        break;
                    case ("每"):
                        VV = "1";
                        break;
                    case ("九"):
                        VV = "9";
                        break;
                    default:
                        break;
                }

                switch (UnitV)
                {
                    case ("季度"):
                        UnitV = "月";
                        VV = Convert.ToString(Int32.Parse(VV) * 3);
                        break;
                    case ("半年"):
                        VV = "6";
                        UnitV = "月";
                        break;
                    case ("周"):
                        VV = Convert.ToString(Int32.Parse(VV) * 7);
                        UnitV = "日";
                        break;
                    default:
                        break;
                }
                r.Cells["CIRCLEPERIOD"].Value = VV;
                if (!string.IsNullOrEmpty(UnitV))
                {
                    r.Cells["CIRCLEUNIT"].Value = UnitV;
                }

                UnitV = "";
                VV = "";
                IniValue = "";
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// 时间小时初始化项.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timingAutoButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            foreach (DataGridViewRow r in dgvOne.Rows)
            {
                if (string.IsNullOrEmpty(r.Cells["TIMINGPERIOD"].Value.ToString()))
                {
                    if (r.Cells["CIRCLEUNIT"].Value.ToString().Equals("月"))
                    {
                        r.Cells["TIMINGPERIOD"].Value = Convert.ToString(Int32.Parse(r.Cells["CIRCLEPERIOD"].Value.ToString()) * 30 * 24);
                    }
                    else if (r.Cells["CIRCLEUNIT"].Value.ToString().Equals("年"))
                    {
                        r.Cells["TIMINGPERIOD"].Value = Convert.ToString(Int32.Parse(r.Cells["CIRCLEPERIOD"].Value.ToString()) * 365 * 24);
                    }
                    else
                    {
                        r.Cells["TIMINGPERIOD"].Value = Convert.ToString(Int32.Parse(r.Cells["CIRCLEPERIOD"].Value.ToString()) * 24);
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void wfPersistHistoryButton_Click(object sender, EventArgs e)
        {
            FrmToolWorkInfoPH frm = FrmToolWorkInfoPH.Instance;
            frm.Ship_id = shipid;
            frm.ShowDialog();
        }
        #endregion

        #region 数据初始化区
        private void reloadData()
        {
            DataTable dt;
            string err;
            dt = T_TOOL_WORKINFOService.Instance.getInitialData(shipid,cobReportType.Text.Equals("甲板部")? 1:2, out err);
            bindingSource1.DataSource = dt;
            dgvOne.DataSource = bindingSource1;

            setRowsColor();
        }

        private void setRowsColor()
        {
            foreach (DataGridViewRow row in dgvOne.Rows)
            {
                if (row.Cells["ITEMTYPE"].Value.ToString().Equals("1"))
                {
                    row.DefaultCellStyle.BackColor = Color.Pink;
                }
                if (!string.IsNullOrEmpty(row.Cells["PRINCIPALPOST"].Value.ToString()))
                {
                    row.Cells["PRINCIPALPOST_INI"].Style.ForeColor = Color.Chocolate;
                }
                if (!string.IsNullOrEmpty(row.Cells["CONFIRMPOST"].Value.ToString()))
                {
                    row.Cells["CONFIRMPOST_INI"].Style.ForeColor = Color.Chocolate;
                }
            }
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

            dgvOne.Columns[0].Visible = false;
            dgvOne.Columns[25].Visible = false;
            dgvOne.Columns[31].Visible = false;
            dgvOne.Columns[32].Visible = false;
            dgvOne.Columns[33].Visible = false;
            dgvOne.Columns[34].Visible = false;
            dgvOne.Columns[35].Visible = false;
            dgvOne.Columns[36].Visible = false;
            dgvOne.Columns[37].Visible = false;
        }

        /// <summary>
        /// 设置列宽.
        /// </summary>
        private void setColumnsWidth()
        {
            int defaultWidth = 60;
            int minWidth = 20;
            foreach (DataGridViewColumn c in dgvOne.Columns)
            {
                if (c.Index == 26 || c.Index == 27 || c.Index == 28 || c.Index == 29 || c.Index == 30)
                {
                    c.Width = minWidth;
                    continue;
                }
                if (c.Index == 5 || c.Index == 6)
                {
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    continue;
                }
                c.Width = defaultWidth;
            }
            dgvOne.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }

        /// <summary>
        /// 设置列只读.
        /// </summary>
        private void setColumnsReadOnly()
        {
            string[] sCols = new string[] { "COMP_CHINESE_NAME" };
            dgvOne.setDgvColumnsReadOnly(sCols);
        }

        /// <summary>
        /// 设置界面上的网格的一些常用的快捷菜单的事件处理.
        /// </summary>
        private void setGridShortCutBtn()
        {
            dgvOne.CtxMenu.Items.Add(new ToolStripSeparator());
            dgvOne.CtxMenu.Items.Add(tspMnuToolDel);
            dgvOne.CtxMenu.Items.Add(tspMnuToolEditColumns);
            dgvOne.CtxMenu.Items.Add(tspMnuToolWFTrue);
            dgvOne.CtxMenu.Items.Add(tspMnuToolWFFalse);

        }

        private void tspMnuToolDel_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DialogResult result = MessageBoxEx.Show("确定删除数据项？");

            string id = "", err = "";
            if (result == DialogResult.OK)
            {
                DataGridViewSelectedRowCollection collection = dgvOne.SelectedRows;
                foreach (DataGridViewRow row in collection)
                {
                    if (row.Index >= 0)
                    {
                        if (DBNull.Value != row.Cells["WORKINFOID"].Value && null != row.Cells["WORKINFOID"].Value)
                            id = row.Cells["WORKINFOID"].Value.ToString();
                        T_TOOL_WORKINFOService.Instance.deleteUnit(id, out err);
                    }
                }
            }

            if (err.Length > 0 && string.IsNullOrEmpty(err))
            {
                MessageBoxEx.Show("删除失败" + err);
            }
            Cursor.Current = Cursors.Default;
            //刷新列表.
            reloadData();
        }
        #endregion

        /// <summary>
        /// datagridview单元格的值发生改变.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvOne_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            string id = "", err = "";
            string columnName = dgvOne.Rows[i].Cells[e.ColumnIndex].OwningColumn.Name;
            string cellValue = dgvOne.Rows[i].Cells[columnName].Value.ToString();
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                dgvOne.Rows[i].Cells[columnName].Value = dgvOne.Rows[i].Cells[columnName].Value;
                if (DBNull.Value != dgvOne.Rows[i].Cells["WORKINFOID"].Value && null != dgvOne.Rows[i].Cells["WORKINFOID"].Value)
                    id = dgvOne.Rows[i].Cells["WORKINFOID"].Value.ToString();

                T_TOOL_WORKINFO unit = T_TOOL_WORKINFOService.Instance.getObject(id, out err);
                switch (columnName)
                {
                    case "EXCEL_ORDERNUM":
                        if (!string.IsNullOrEmpty(cellValue))
                        {
                            unit.EXCEL_ORDERNUM = Int32.Parse(cellValue);
                        }
                        break;
                    case "CLASS1":
                        unit.CLASS1 = cellValue;
                        break;
                    case "CLASS2":
                        unit.CLASS2 = cellValue;
                        break;
                    case "WORKINFONAME":
                        unit.WORKINFONAME = cellValue;
                        break;
                    case "WORKINFODETAIL":
                        unit.WORKINFODETAIL = cellValue;
                        break;
                    case "CIRCLEORTIMING":
                        if (cellValue.Trim().Equals("定期"))
                        {
                            unit.CIRCLEORTIMING = 1;
                        }
                        else if (cellValue.Trim().Equals("定时"))
                        {
                            unit.CIRCLEORTIMING = 2;
                        }
                        else if (cellValue.Trim().Equals("定期定时"))
                        {
                            unit.CIRCLEORTIMING = 3;
                        }
                        else if (cellValue.Trim().Equals("非周期"))
                        {
                            unit.CIRCLEORTIMING = 4;
                        }
                        else
                        {
                            unit.CIRCLEORTIMING = 0;
                        }
                        break;
                    case "CIRCLEORTIMING_INI":
                        unit.CIRCLEORTIMING_INI = cellValue;
                        break;
                    case "CIRCLEPERIOD":
                        if (!string.IsNullOrEmpty(cellValue))
                        {
                            unit.CIRCLEPERIOD = Int32.Parse(cellValue);
                        }
                        break;
                    case "CIRCLEPERIOD_INI":
                        unit.CIRCLEPERIOD_INI = cellValue;
                        break;
                    case "CIRCLEUNIT":
                        unit.CIRCLEUNIT = cellValue;
                        break;
                    case "CIRCLEFRONTLIMIT":
                        if (!string.IsNullOrEmpty(cellValue))
                        {
                            unit.CIRCLEFRONTLIMIT = Int32.Parse(cellValue);
                        }
                        break;
                    case "CIRCLEBACKLIMIT":
                        if (!string.IsNullOrEmpty(cellValue))
                        {
                            unit.CIRCLEBACKLIMIT = Int32.Parse(cellValue);
                        }
                        break;
                    case "CIRCLELIMITUNIT":
                        unit.CIRCLELIMITUNIT = cellValue;
                        break;
                    case "TIMINGPERIOD":
                        if (!string.IsNullOrEmpty(cellValue))
                        {
                            unit.TIMINGPERIOD = Int32.Parse(cellValue);
                        }
                        break;
                    case "TIMINGFRONTLIMIT":
                        if (!string.IsNullOrEmpty(cellValue))
                        {
                            unit.TIMINGFRONTLIMIT = Int32.Parse(cellValue);
                        }
                        break;
                    case "PRINCIPALPOST_INI":
                        unit.PRINCIPALPOST_INI = cellValue;
                        break;
                    case "CONFIRMPOST_INI":
                        unit.CONFIRMPOST_INI = cellValue;
                        break;
                    case "ISCHECKPROJECT":
                        if (!string.IsNullOrEmpty(cellValue))
                        {
                            unit.ISCHECKPROJECT = Int32.Parse(cellValue);
                        }
                        break;
                    case "ISCHECKPROJECT_INI":
                        unit.ISCHECKPROJECT_INI = cellValue;
                        break;
                    case "ISREPAIRPROJECT":
                        if (!string.IsNullOrEmpty(cellValue))
                        {
                            unit.ISREPAIRPROJECT = Int32.Parse(cellValue);
                        }
                        break;
                    case "ISREPAIRPROJECT_INI":
                        unit.ISREPAIRPROJECT_INI = cellValue;
                        break;
                    case "MONTHS_CHECK":
                        unit.MONTHS_CHECK = cellValue;
                        break;
                    case "ISBAK":
                        if (!string.IsNullOrEmpty(cellValue))
                        {
                            unit.ISBAK = Int32.Parse(cellValue);
                        }
                        break;
                    case "EX1":
                        unit.EX1 = cellValue;
                        break;
                    case "EX2":
                        unit.EX2 = cellValue;
                        break;
                    case "EX3":
                        unit.EX3 = cellValue;
                        break;
                    case "EX4":
                        unit.EX4 = cellValue;
                        break;
                    case "EX5":
                        unit.EX5 = cellValue;
                        break;
                    case "REFOBJID":
                        unit.REFOBJID = cellValue;
                        break;
                    case "ORDERNUM_SHOW":
                        unit.ORDERNUM_SHOW = cellValue;
                        break;
                    case "PRINCIPALPOST":
                        unit.PRINCIPALPOST = cellValue;
                        break;
                    case "CONFIRMPOST":
                        unit.CONFIRMPOST = cellValue;
                        break;
                    case "WORKINFOTYPE":
                        if (!string.IsNullOrEmpty(cellValue))
                        {
                            unit.WORKINFOTYPE = Int32.Parse(cellValue);
                        }
                        break;
                    case "ITEMTYPE":
                        unit.ITEMTYPE = cellValue;
                        break;
                    case "TIMINGBACKLIMIT":
                        if (!string.IsNullOrEmpty(cellValue))
                        {
                            unit.TIMINGBACKLIMIT = Int32.Parse(cellValue);
                        }
                        break;
                    default:
                        //unit.WORKINFOID = cellValue;
                        break;
                }
                T_TOOL_WORKINFOService.Instance.saveUnit(unit, out err);
            }
        }

        /// <summary>
        /// 设置主列项.
        /// </summary>
        private void loadDataColName()
        {
            dictColumns.Clear();

            //设置列标题.

            dictColumns.Add("EXCEL_ORDERNUM", "XLS序号");//0
            dictColumns.Add("ORDERNUM_SHOW", "显示排序号");
            dictColumns.Add("CLASS1", " 一级分类");
            dictColumns.Add("CLASS2", "二级分类");
            dictColumns.Add("COMP_CHINESE_NAME", "设备名称");
            dictColumns.Add("WORKINFONAME", "工作信息名称");
            dictColumns.Add("WORKINFODETAIL", "工作信息内容");
            dictColumns.Add("CIRCLEORTIMING", "定期定时");
            dictColumns.Add("CIRCLEORTIMING_INI", "定期定时初始化项");
            dictColumns.Add("CIRCLEPERIOD", "定期周期");
            dictColumns.Add("CIRCLEPERIOD_INI", "定期周期初始化项");
            dictColumns.Add("CIRCLEUNIT", "定期单位");//10
            dictColumns.Add("CIRCLEFRONTLIMIT", "定期前允差");
            dictColumns.Add("CIRCLEBACKLIMIT", "定期后允差");
            dictColumns.Add("CIRCLELIMITUNIT", "定期允差单位");
            dictColumns.Add("TIMINGPERIOD", "定时周期");
            dictColumns.Add("TIMINGFRONTLIMIT", "定时前允差");
            dictColumns.Add("TIMINGBACKLIMIT", "定时后允差");
            dictColumns.Add("PRINCIPALPOST_INI", "负责人岗位初始化项");
            dictColumns.Add("CONFIRMPOST_INI", "确认人岗位初始化项");
            dictColumns.Add("ISCHECKPROJECT", "校验项目值");
            dictColumns.Add("ISCHECKPROJECT_INI", "校验项目初始化项");//20
            dictColumns.Add("ISREPAIRPROJECT", "修理项目值");
            dictColumns.Add("ISREPAIRPROJECT_INI", "修理项目初始化项");
            //dictColumns.Add("SHIP_NAME", "船舶名称");
            dictColumns.Add("MONTHS_CHECK", "月保养");
            dictColumns.Add("ISBAK", "是否备份");
            dictColumns.Add("EX1", "扩展项1");
            dictColumns.Add("EX2", "扩展项2");
            dictColumns.Add("EX3", "扩展项3");
            dictColumns.Add("EX4", "扩展项4");
            dictColumns.Add("EX5", "扩展项5");//30
            dictColumns.Add("WORKINFOID", "主键PK");
            dictColumns.Add("REFOBJID", "关联对象ID");
            dictColumns.Add("PRINCIPALPOST", "负责人岗位ID");
            dictColumns.Add("CONFIRMPOST", "确认人岗位ID");
            dictColumns.Add("WORKINFOTYPE", "信息类别");
            dictColumns.Add("ITEMTYPE", "记录类型");
            dgvOne.SetDgvGridColumns(dictColumns);
        }

        private void cobShip_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cobShip.SelectedValue != null)
            {
                shipid = cobShip.SelectedValue.ToString();
                reloadData();
            }
        }

        private void cobReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            reloadData();
        }

        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {
            string err;
            DataTable dtbShip = T_TOOL_WORKINFOService.Instance.GetOwnerShip(out err);
            other.SetComboBoxValue(cobShip, dtbShip);
            cobShip.SelectedValueChanged += new EventHandler(cobShip_SelectedValueChanged);
            cobReportType.SelectedIndex = 0; //默认初始化部门类型.

        }

        /// <summary>
        /// 岗位生成.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void postButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            Dictionary<string, string> dicOne = new Dictionary<string, string>();
            string err = "";
            StringBuilder str = new StringBuilder();
            List<string> ls = new List<string>();
            string temp = "";
            foreach (DataGridViewRow row in dgvOne.Rows)
            {
                temp = row.Cells["PRINCIPALPOST_INI"].Value.ToString();
                if (!str.ToString().Contains(temp))
                {
                    str.Append(temp);
                    ls.Add(temp);
                }
                temp = row.Cells["CONFIRMPOST_INI"].Value.ToString();
                if (!str.ToString().Contains(temp))
                {
                    str.Append(temp);
                    ls.Add(temp);
                }
            }

            DataTable dt = T_TOOL_WORKINFOService.Instance.getPost(ls, out err);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dicOne.Add(dt.Rows[i]["HEADSHIP_NAME"].ToString(), dt.Rows[i]["SHIP_HEADSHIP_ID"].ToString());
            }

            foreach (DataGridViewRow row in dgvOne.Rows)
            {
                temp = row.Cells["PRINCIPALPOST_INI"].Value.ToString();
                if (dicOne.ContainsKey(temp))
                {
                    row.Cells["PRINCIPALPOST"].Value = dicOne[temp];
                }

                temp = row.Cells["CONFIRMPOST_INI"].Value.ToString();

                if (dicOne.ContainsKey(temp))
                {
                    row.Cells["CONFIRMPOST"].Value = dicOne[temp];
                }
            }

            Cursor.Current = Cursors.Default;

            if (string.IsNullOrEmpty(err))
            {
                MessageBoxEx.Show("岗位生成成功！", "提示");
                reloadData();//刷新列表.
            }
            else
            {
                MessageBoxEx.Show("岗位生成失败" + err, "提示");
            }
        }

        string str1 = "";
        Type type = null;
        private void dgvOne_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.RowIndex > 0 && e.ColumnIndex > 0)
                {
                    type = dgvOne.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType;
                    if (Cursor.Current == Cursors.Cross)
                    {
                        if (str1 != "")
                        {
                            dgvOne.DoDragDrop(str1, DragDropEffects.Copy);
                        }
                    }
                }
            }
        }

        private void dgvOne_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > 0 && e.ColumnIndex > 0)
            {
                str1 = dgvOne.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
        }

        private void dgvOne_DragDrop(object sender, DragEventArgs e)
        {
            Point p = this.dgvOne.PointToClient(new Point(e.X, e.Y));
            DataGridView.HitTestInfo hit = this.dgvOne.HitTest(p.X, p.Y);
            if (hit.Type == DataGridViewHitTestType.Cell)
            {
                DataGridViewCell clickedCell = this.dgvOne.Rows[hit.RowIndex].Cells[hit.ColumnIndex];
                if (this.dgvOne.Rows[hit.RowIndex].Cells[hit.ColumnIndex].ValueType.Equals(type))
                {
                    clickedCell.Value = (System.String)e.Data.GetData(typeof(System.String));
                }
            }
        }

        private void dgvOne_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        int x;
        int y;
        int height;
        int width;
        bool flag = false;

        private void dgvOne_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                int dgvX = dgvOne.Location.X;
                int dgvY = dgvOne.Location.Y;

                int cellX = dgvOne.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).X;
                int cellY = dgvOne.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Y;

                x = dgvX + cellX;
                y = dgvY + cellY;

                height = dgvOne.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Height;
                width = dgvOne.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Width;

                flag = true;
            }
        }

        private void dgvOne_MouseMove(object sender, MouseEventArgs e)
        {
            if (flag)
            {
                if (e.X > x + 3 * width / 4 && e.X < x + width && e.Y > y - 3 * height / 4 && e.Y < y)
                {
                    Cursor.Current = Cursors.Cross;
                }
                else
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void dgvOne_Sorted(object sender, EventArgs e)
        {
            setRowsColor();
        }

        private void monthButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBoxEx.Show("确定要通过月勾选初始化周期，是，可能导致已经手动调整的周期被覆盖？", "提示", MessageBoxButtons.OKCancel);
            if(result == DialogResult.Cancel)
            {
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            string IniValue;
            string[] values;
            foreach (DataGridViewRow r in dgvOne.Rows)
            {
                IniValue = r.Cells["MONTHS_CHECK"].Value.ToString();
                values = IniValue.Split(new char[] { ',' });
                if(values.Length == 0 )
                {
                    continue;
                    //不做任何处理.
                }
                else if(values.Length == 1)
                {
                    r.Cells["CIRCLEPERIOD"].Value = 1;
                    r.Cells["CIRCLEUNIT"].Value = "年";
                }
                else if (values.Length == 2)
                {
                    r.Cells["CIRCLEPERIOD"].Value = 6;
                    r.Cells["CIRCLEUNIT"].Value = "月";
                }
                else
                {
                    r.Cells["CIRCLEPERIOD"].Value = 12/values.Length;
                    r.Cells["CIRCLEUNIT"].Value = "月";
                }
            }
            Cursor.Current = Cursors.Default;
        }

        #region 按钮提示内容功能实现
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monthButton_MouseMove(object sender, MouseEventArgs e)
        {
            //ToolTip tip = new ToolTip();
            //tip.AutoPopDelay = 5000;
            //tip.InitialDelay = 0;
            //tip.ReshowDelay = 500;
            //tip.ShowAlways = true;
            //tip.SetToolTip((Control)sender, "根据月勾选内容，自动计算出周期");
        }
        #endregion
        
    }
}