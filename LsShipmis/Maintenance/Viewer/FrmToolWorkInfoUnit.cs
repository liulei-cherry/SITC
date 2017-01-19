/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmToolWorkInfoUnit.cs
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
using System.Text.RegularExpressions;
using BaseInfo.Objects;
using ItemsManage.DataObject;
using ItemsManage.Viewer;
using ItemsManage.Services;

namespace Maintenance.Viewer
{
    /// <summary>
    /// 船舶信息管理业务窗体.
    /// </summary>
    public partial class FrmToolWorkInfoUnit :Form
    {
        #region 窗体单实例模型
        /// <summary>
        /// 当前窗体的静态实例对象        /// </summary>
        private static FrmToolWorkInfoUnit instance = new FrmToolWorkInfoUnit();

        /// <summary>
        /// 当前窗体的静态实例属性        /// </summary>
        public static FrmToolWorkInfoUnit Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmToolWorkInfoUnit.instance = new FrmToolWorkInfoUnit();
                }
                return FrmToolWorkInfoUnit.instance;
            }
        }
        #endregion

        #region 窗体引用对象

        Dictionary<string, string> dictColumns = new Dictionary<string, string>();
        private FormControlOption other = FormControlOption.Instance;
        string shipid;
        ShipInfo shipInfo;
        string unitId;
        string unitChineseName;

        #endregion

        #region 上下文菜单

        /// <summary>
        /// 删除选中项上下文菜单.
        /// </summary>
        private ToolStripMenuItem tspMnuToolLink = new ToolStripMenuItem("关联");
        private ToolStripMenuItem tspMnuToolLinkCancel = new ToolStripMenuItem("取消关联");

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmToolWorkInfoUnit()
        {
            InitializeComponent();
            tspMnuToolLink.Click += new EventHandler(tspMnuToolLink_Click);
            tspMnuToolLinkCancel.Click += new EventHandler(tspMnuToolLinkCancel_Click);
        }

        void tspMnuToolLinkCancel_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            unitWFLinkCancel();
            Cursor.Current = Cursors.Default;
            
        }

        void tspMnuToolLink_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            unitWFLink();
            Cursor.Current = Cursors.Default;
        }

        private void FrmPortInfo_Load(object sender, EventArgs e)
        {
            setComboBox();
            reloadData();
            loadDataColName();
            setColumnsVisble();
            setColumnsWidth();
            setGridShortCutBtn();
            ucEquipmentClassTreeWithEquipment1.ReloadingShipData(shipInfo);
        }

        private void FrmPortInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
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

        #endregion

        #region 数据初始化区
        private void  reloadData()
        {
            DataTable dt;
            string err;
            dt = T_TOOL_WORKINFOService.Instance.getSomeInfo(shipid,cobReportType.Text.Equals("甲板部")? 1:2, out err);
            dgvOne.DataSource = dt;
        }
        #endregion  

        /// <summary>
        /// 设置界面上的网格的一些常用的快捷菜单的事件处理.
        /// </summary>
        private void setGridShortCutBtn()
        {
            dgvOne.CtxMenu.Items.Add(new ToolStripSeparator());
            dgvOne.CtxMenu.Items.Add(tspMnuToolLink);
            dgvOne.CtxMenu.Items.Add(tspMnuToolLinkCancel);
        }

        private void cobShip_SelectedValueChanged(object sender, EventArgs e)
        {
            string err = "";
            if(cobShip.SelectedValue != null)
            {
                shipid = cobShip.SelectedValue.ToString();
                shipInfo = ShipInfoService.Instance.getObject(shipid, out err);
                if (shipInfo != null && !shipInfo.IsWrong)
                {
                    ucEquipmentClassTreeWithEquipment1.ReloadingShipData(shipInfo);
                }
                reloadData();
            }  
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

            cobReportType.SelectedIndex = 0;
        }

        /// <summary>
        /// 设置主列项.
        /// </summary>
        private void loadDataColName()
        {
            dictColumns.Clear();
            //设置列标题.
            dictColumns.Add("WORKINFOID", "工作信息ID");//0
            dictColumns.Add("ORDERNUM_SHOW", "显示排序号");
            dictColumns.Add("COMP_CHINESE_NAME", "关联设备名称");
            dictColumns.Add("REFOBJID", "关联设备ID");
            dictColumns.Add("CLASS1", " 一级分类");
            dictColumns.Add("CLASS2", "二级分类");
            dictColumns.Add("WORKINFONAME", "工作信息名称");
            dictColumns.Add("WORKINFODETAIL", "工作信息内容");
            
            dgvOne.SetDgvGridColumns(dictColumns);
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
            dgvOne.Columns[3].Visible = false;
        }

        /// <summary>
        /// 工作信息设备关联方法.
        /// </summary>
        private void unitWFLink()
        {
            string id = "", err = "";

            Dictionary<int, DataGridViewRow> rows = new Dictionary<int, DataGridViewRow>();
            DataGridViewSelectedCellCollection cells = dgvOne.SelectedCells;
            foreach(DataGridViewCell cell in cells)
            {
                if(!rows.ContainsKey(cell.RowIndex))
                {
                    rows.Add(cell.RowIndex, dgvOne.Rows[cell.RowIndex]);
                }
            }

            DataGridViewSelectedRowCollection collection = dgvOne.SelectedRows;
            foreach (DataGridViewRow row in collection)
            {
                if (!rows.ContainsKey(row.Index))
                {
                    rows.Add(row.Index, row);
                }
            }

            foreach(DataGridViewRow row in rows.Values)
            {
                if (row.Index >= 0)
                {
                    if (DBNull.Value != row.Cells["WORKINFOID"].Value && null != row.Cells["WORKINFOID"].Value)
                        id = row.Cells["WORKINFOID"].Value.ToString();
                    T_TOOL_WORKINFO unit = T_TOOL_WORKINFOService.Instance.getObject(id,out err);
                    unit.REFOBJID = unitId;
                    unit.WORKINFOTYPE = 1;
                    T_TOOL_WORKINFOService.Instance.saveUnit(unit,out err);
                    if (err.Length == 0)
                    {
                        row.Cells["COMP_CHINESE_NAME"].Value = unitChineseName;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if(err.Length > 0)
            {
                MessageBoxEx.Show("关联失败：" + err);
            }
        }

        /// <summary>
        /// 工作信息设备取消关联方法.
        /// </summary>
        private void unitWFLinkCancel()
        {
            string id = "", err = "";

            Dictionary<int, DataGridViewRow> rows = new Dictionary<int, DataGridViewRow>();
            DataGridViewSelectedCellCollection cells = dgvOne.SelectedCells;
            foreach (DataGridViewCell cell in cells)
            {
                if (!rows.ContainsKey(cell.RowIndex))
                {
                    rows.Add(cell.RowIndex, dgvOne.Rows[cell.RowIndex]);
                }
            }

            DataGridViewSelectedRowCollection collection = dgvOne.SelectedRows;
            foreach (DataGridViewRow row in collection)
            {
                if (!rows.ContainsKey(row.Index))
                {
                    rows.Add(row.Index, row);
                }
            }

            foreach (DataGridViewRow row in rows.Values)
            {
                if (row.Index >= 0)
                {
                    if (DBNull.Value != row.Cells["WORKINFOID"].Value && null != row.Cells["WORKINFOID"].Value)
                        id = row.Cells["WORKINFOID"].Value.ToString();
                    T_TOOL_WORKINFO unit = T_TOOL_WORKINFOService.Instance.getObject(id, out err);
                    unit.REFOBJID = null;
                    unit.WORKINFOTYPE = 0;
                    T_TOOL_WORKINFOService.Instance.saveUnit(unit, out err);
                    if (err.Length == 0)
                    {
                        row.Cells["COMP_CHINESE_NAME"].Value = "";
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (err.Length > 0)
            {
                MessageBoxEx.Show("取消关联失败：" + err);
            }
        }

        /// <summary>
        /// 设备树.
        /// </summary>
        /// <param name="theObject"></param>
        /// <param name="objectType"></param>
        private void ucEquipmentClassTreeWithEquipment1_ItemChanged(object theObject, int objectType)
        {
            switch (objectType)
            {
                case 2:
                    ComponentUnit unit = (ComponentUnit)theObject;
                    if (unit == null)
                    {
                        unitId = unitChineseName = "";
                    }
                    else
                    {
                        unitId = unit.COMPONENT_UNIT_ID;
                        unitChineseName = unit.COMP_CHINESE_NAME;
                    }
                    return;
                default:
                    return;
            }
        }

        /// <summary>
        /// 设置列宽.
        /// </summary>
        private void setColumnsWidth()
        {
            foreach (DataGridViewColumn c in dgvOne.Columns)
            {
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dgvOne.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }

        public void SwitchToEquipment(string equipmentId)
        {
            string err;
            ComponentUnit equipment = ComponentUnitService.Instance.getObject(equipmentId, out err);
            if (equipment != null)
            {
                ucEquipmentClassTreeWithEquipment1.SelectOneEquipment(equipment);
            }          
        }

        /// <summary>
        /// 搜索设备.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            FrmSelectComponent frm = new FrmSelectComponent(shipid);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ucEquipmentClassTreeWithEquipment1.SelectOneEquipment(frm.Equipment);
            }
        }

        private void cobReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            reloadData();
        }
    }
}