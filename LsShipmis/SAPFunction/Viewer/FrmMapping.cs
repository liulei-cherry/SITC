/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmMapping.cs
 * 创 建 人：王鹏程
 * 创建时间：2011/6/16
 * 标    题：FrmMapping窗体
 * 功能描述：sap映射信息
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Data;
using System.Windows.Forms;
using CommonViewer.BaseControl;
using SAPFunction.Services;
using SAPFunction.DataObject;
using CommonViewer;
using System.Drawing;
using ItemsManage.Services;
using ItemsManage.DataObject;

namespace SAPFunction.Viewer
{
    public partial class FrmMapping : CommonViewer.BaseForm.FormBase
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmMapping instance = new FrmMapping();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmMapping Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmMapping.instance = new FrmMapping();
                }
                return FrmMapping.instance;
            }
        }
        #endregion

        public FrmMapping()
        {
            InitializeComponent();
        }
        private void FrmMapping_Load(object sender, EventArgs e)
        {
            string err = "";
            if (!ReloadData(0, out err))
                return;
        }
        /// <summary>
        /// 绑定gridview数据.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool ReloadData(int type, out string err)
        {
            err = "";
            ucDataGridView1.SaveGridView("FrmMapping.ucDataGridView1");
            ucDataGridView2.SaveGridView("FrmMapping.ucDataGridView2");
            ucDataGridView3.SaveGridView("FrmMapping.ucDataGridView3");

            if (type == 0)
            {
                DataTable dtbMaterial = MaterialMappingService.Instance.GetAllInfo(out err);
                ucDataGridView1.DataSource = dtbMaterial;
                SetMaterialDataGridView();
            }
            else if (type == 1)
            {
                DataTable dtbInternalOrder = InternalOrderMappingService.Instance.GetAllInfo(out err);
                ucDataGridView2.DataSource = dtbInternalOrder;
                SetInternalOrderDataGridView();
            }
            else if (type == 2)
            {
                DataTable dtbSupplier = SupplierMappingService.Instance.GetAllInfo(out err);
                ucDataGridView3.DataSource = dtbSupplier;
                SetSupplierDataGridView();
            }
            return true;
        }
        /// <summary>
        /// 保存物资.
        /// </summary>
        /// <param name="err"></param>
        /// <returns></returns>
        private bool SaveMaterial(out string err)
        {
            err = "";
            DataTable dtb = (DataTable)ucDataGridView1.DataSource;
            if (dtb.Rows.Count == 0) return true;
            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                DataRow item = dtb.Rows[i];
                if (item.RowState == DataRowState.Modified)
                {
                    if (item.RowState == DataRowState.Modified)
                    {
                        MaterialMapping mapping = MaterialMappingService.Instance.getObject(item);
                        mapping.MATERIAL_FINANCE = mapping.MATERIAL_FINANCE != null ? mapping.MATERIAL_FINANCE.Trim() : mapping.MATERIAL_FINANCE;
                        mapping.COST_FINANCE = mapping.COST_FINANCE != null ? mapping.COST_FINANCE.Trim() : mapping.COST_FINANCE;

                        if (string.IsNullOrEmpty(mapping.MATERIAL_FINANCE) && string.IsNullOrEmpty(mapping.COST_FINANCE))
                        {
                            MessageBoxEx.Show("管理系统物资代码为 " + mapping.MANAGEMENT + " 的财务系统物资代码与财务系统费用科目必须填写一个");
                            return false;
                        }
                        if (!string.IsNullOrEmpty(mapping.MATERIAL_FINANCE) && !string.IsNullOrEmpty(mapping.COST_FINANCE))
                        {
                            MessageBoxEx.Show("管理系统物资代码为 " + mapping.MANAGEMENT + " 财务系统物资代码与财务系统费用科目只能填写一个");
                            return false;
                        }
                        if (!string.IsNullOrEmpty(mapping.MATERIAL_FINANCE))
                        {
                            if (dtb.Select("MATERIAL_FINANCE='" + mapping.MATERIAL_FINANCE.Replace("'", "''") + "'").Length > 1)
                            {
                                MessageBoxEx.Show("财务系统物资代码为 " + mapping.MATERIAL_FINANCE + " 的映射出现重复项");
                                return false;
                            }
                        }
                        if (!MaterialMappingService.Instance.saveUnit(mapping, out err))
                        {
                            MessageBoxEx.Show(err, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                    }
                }
            }
            MessageBoxEx.Show("保存成功");
            return true;
        }
        /// <summary>
        /// 保存内部订单.
        /// </summary>
        /// <param name="err"></param>
        /// <returns></returns>
        private bool SaveInternalOrder(out string err)
        {
            err = "";
            DataTable dtb = (DataTable)ucDataGridView2.DataSource;
            if (dtb.Rows.Count == 0) return false;
            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                DataRow item = dtb.Rows[i];
                if (item.RowState == DataRowState.Modified)
                {
                    InternalOrderMapping mapping = InternalOrderMappingService.Instance.getObject(item);
                    mapping.INTERNAL_ORDER_FINANCE = mapping.INTERNAL_ORDER_FINANCE != null ? mapping.INTERNAL_ORDER_FINANCE.Trim() : mapping.INTERNAL_ORDER_FINANCE;
                    if (string.IsNullOrEmpty(mapping.INTERNAL_ORDER_FINANCE))
                    {
                        MessageBoxEx.Show("管理系统船舶代号为 " + mapping.SHIP_CODE + " ," + " 管理系统项目类别代码为 " + mapping.ITEM_CODE + " 的财务系统内部订单号不能为空");
                        return false;
                    }
                    //if (!string.IsNullOrEmpty(mapping.INTERNAL_ORDER_FINANCE))
                    //{
                    //    if (dtb.Select("INTERNAL_ORDER_FINANCE='" + mapping.INTERNAL_ORDER_FINANCE.Replace("'", "''") + "'").Length > 1)
                    //    {
                    //        MessageBoxEx.Show("财务系统内部订单代码为 " + mapping.INTERNAL_ORDER_FINANCE + " 的映射出现重复项");
                    //        return false;
                    //    }
                    //}
                    if (!InternalOrderMappingService.Instance.saveUnit(mapping, out err))
                    {
                        MessageBoxEx.Show(err, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
            }
            MessageBoxEx.Show("保存成功");
            return true;
        }
        /// <summary>
        /// 保存供应商.
        /// </summary>
        /// <param name="err"></param>
        /// <returns></returns>
        private bool SaveSupplier(out string err)
        {
            err = "";
            DataTable dtb = (DataTable)ucDataGridView3.DataSource;
            if (dtb.Rows.Count == 0) return false;
            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                DataRow item = dtb.Rows[i];
                SupplierMapping mapping = SupplierMappingService.Instance.getObject(item);
                mapping.FINANCE = mapping.FINANCE != null ? mapping.FINANCE.Trim() : mapping.FINANCE;
                if (string.IsNullOrEmpty(mapping.FINANCE))
                {
                    MessageBoxEx.Show("管理系统供应商代码为 " + mapping.MANAGEMENT + " 的财务系统供应商代码不能为空");
                    return false;
                }
                if (!SupplierMappingService.Instance.saveUnit(mapping, out err))
                {
                    MessageBoxEx.Show(err, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            MessageBoxEx.Show("保存成功");
            return true;
        }
        /// <summary>
        /// 保存按钮事件,保存当前选项卡里的数据.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string err;
            if (tabControl1.SelectedIndex == 0)
            {
                if (!SaveMaterial(out err))
                    return;
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                if (!SaveInternalOrder(out err))
                    return;
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                if (!SaveSupplier(out err))
                    return;
            }
            if (!ReloadData(tabControl1.SelectedIndex, out err))
                return;
        }
        /// <summary>
        /// 切换选项卡事件,刷新数据.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            string err = "";
            if (!ReloadData(tabControl1.SelectedIndex, out err))
                return;
        }
        /// <summary>
        /// 添加按钮事件,当前选项卡是哪个类型 就打开哪个类型的新增窗口.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                FrmMaterialMappingAdd frm = new FrmMaterialMappingAdd();
                frm.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                FrmInternalOrderMappingAdd frm = new FrmInternalOrderMappingAdd();
                frm.ShowDialog();
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                FrmSupplierMappingAdd frm = new FrmSupplierMappingAdd();
                frm.ShowDialog();
            }
            string err;
            if (!ReloadData(tabControl1.SelectedIndex, out err))
                return;
        }
        /// <summary>
        /// 删除按钮事件,删除当前选项卡里 当前选择的数据行.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string err;
            if (DialogResult.No == MessageBoxEx.Show("确认删除该条信息吗?", "系统信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                return;
            if (tabControl1.SelectedIndex == 0)
            {
                if (ucDataGridView1.CurrentRow == null)
                {
                    MessageBoxEx.Show("未选中任何行!");
                    return;
                }
                string selection = ucDataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (!MaterialMappingService.Instance.DeleteUnitStorage(selection, out err))
                    return;
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                if (ucDataGridView2.CurrentRow == null)
                {
                    MessageBoxEx.Show("未选中任何行!");
                    return;
                }
                string selection = ucDataGridView2.CurrentRow.Cells[0].Value.ToString();
                if (!InternalOrderMappingService.Instance.deleteUnit(selection, out err))
                    return;
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                if (ucDataGridView3.CurrentRow == null)
                {
                    MessageBoxEx.Show("未选中任何行!");
                    return;
                }
                string selection = ucDataGridView3.CurrentRow.Cells[0].Value.ToString();
                if (!SupplierMappingService.Instance.deleteUnit(selection, out err))
                    return;
            }
            if (!ReloadData(tabControl1.SelectedIndex, out err))
                return;
        }
        /// <summary>
        /// 快速导入.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEx1_Click(object sender, EventArgs e)
        {
            FrmExpImpSAPData frm = new FrmExpImpSAPData();
            frm.ShowDialog();
            string err;
            if (!ReloadData(tabControl1.SelectedIndex, out err))
                MessageBoxEx.Show(err);
        }
        #region 设置gridview的列样式
        public void SetMaterialDataGridView()
        {
            if (((DataTable)ucDataGridView1.DataSource) == null)
                return;
            foreach (DataGridViewColumn item in ucDataGridView1.Columns)
                item.ReadOnly = true;
            ucDataGridView1.Columns["MATERIAL_MAPPING_ID"].Visible = false;
            ucDataGridView1.Columns["MATERIAL_NAME"].HeaderText = "管理系统物资或类型名称";
            ucDataGridView1.Columns["MATERIAL_SPEC"].HeaderText = "管理系统物资型号";
            ucDataGridView1.Columns["UNIT_NAME"].HeaderText = "管理系统物资单位";
            ucDataGridView1.Columns["MANAGEMENT"].HeaderText = "管理系统物资或类型代码";
            ucDataGridView1.Columns["MATERIAL_FINANCE"].HeaderText = "SAP代码";
            ucDataGridView1.Columns["COST_FINANCE"].HeaderText = "SAP费用科目";
            ucDataGridView1.Columns["MATERIAL_FINANCE"].ReadOnly = false;
            ucDataGridView1.Columns["COST_FINANCE"].ReadOnly = false;
            ucDataGridView1.Columns["MATERIAL_TYPE"].Visible = false;
            ucDataGridView1.Columns["MATERIAL_TYPE_NAME"].HeaderText = "类型";
            ucDataGridView1.Columns["STATUS"].Visible = false;
            ucDataGridView1.Columns["STATUS_NAME"].HeaderText = "状态";
            ucDataGridView1.LoadGridView("FrmMapping.ucDataGridView1");
            foreach (DataGridViewColumn item in ucDataGridView1.Columns)
            {
                if (item.ReadOnly)
                    item.DefaultCellStyle.BackColor = Color.Linen;
            }
        }
        public void SetSupplierDataGridView()
        {
            if (((DataTable)ucDataGridView3.DataSource) == null)
                return;
            foreach (DataGridViewColumn item in ucDataGridView3.Columns)
                item.ReadOnly = true;
            ucDataGridView3.Columns["SUPPLIER_MAPPING_ID"].Visible = false;
            ucDataGridView3.Columns["MANUFACTURER_NAME"].HeaderText = "供应商名称";
            ucDataGridView3.Columns["MANAGEMENT"].HeaderText = "管理系统供应商代码";
            ucDataGridView3.Columns["FINANCE"].HeaderText = "SAP供应商代码";
            ucDataGridView3.Columns["FINANCE"].ReadOnly = false;
            ucDataGridView3.Columns["STATUS"].Visible = false;
            ucDataGridView3.Columns["STATUS_NAME"].HeaderText = "状态";
            ucDataGridView3.LoadGridView("FrmMapping.ucDataGridView3");
            foreach (DataGridViewColumn item in ucDataGridView3.Columns)
            {
                if (item.ReadOnly)
                    item.DefaultCellStyle.BackColor = Color.Linen;
            }
        }
        public void SetInternalOrderDataGridView()
        {
            if (((DataTable)ucDataGridView2.DataSource) == null)
                return;
            foreach (DataGridViewColumn item in ucDataGridView2.Columns)
                item.ReadOnly = true;
            ucDataGridView2.Columns["INTERNAL_ORDER_MAPPING_ID"].Visible = false;
            ucDataGridView2.Columns["SHIP_NAME"].HeaderText = "管理系统船舶名称";
            ucDataGridView2.Columns["SHIP_CODE"].HeaderText = "管理系统船舶代号";
            ucDataGridView2.Columns["NODE_NAME"].HeaderText = "管理系统项目类别名称";
            ucDataGridView2.Columns["ITEM_CODE"].HeaderText = "管理系统项目类别代号";
            ucDataGridView2.Columns["INTERNAL_ORDER_FINANCE"].HeaderText = "SAP内部订单号";
            ucDataGridView2.Columns["INTERNAL_ORDER_FINANCE"].ReadOnly = false;
            ucDataGridView2.Columns["STATUS"].Visible = false;
            ucDataGridView2.Columns["STATUS_NAME"].HeaderText = "状态";
            ucDataGridView2.LoadGridView("FrmMapping.ucDataGridView2");
            foreach (DataGridViewColumn item in ucDataGridView2.Columns)
            {
                if (item.ReadOnly)
                    item.DefaultCellStyle.BackColor = Color.Linen;
            }
        }
        #endregion
        /// <summary>
        /// 窗体正在关闭事件,保存gridview列样式.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMapping_FormClosing(object sender, FormClosingEventArgs e)
        {
            ucDataGridView1.SaveGridView("FrmMapping.ucDataGridView1");
            ucDataGridView2.SaveGridView("FrmMapping.ucDataGridView2");
            ucDataGridView3.SaveGridView("FrmMapping.ucDataGridView3");
            instance = null;
        }
        /// <summary>
        /// 关闭窗体.
        /// </summary>
        private void bdNgClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            string err;
            if (MaterialMappingService.Instance.UpdateSapFlag(out err))
            {
                MessageBoxEx.Show("同步sap标示完成");
            }
            else
            {
                MessageBoxEx.Show(err);
            }
        }

        private void btnSyncStorage_Click(object sender, EventArgs e)
        {
            string err;
            if (MaterialMappingService.Instance.UpdateSapStorage(out err))
            {
                MessageBoxEx.Show("同步sap库存完成");
            }
            else
            {
                MessageBoxEx.Show(err);
            }
        }

        private void buttonEx2_Click(object sender, EventArgs e)
        {
            string err;
            DataTable dt;
            if (tabControl1.SelectedIndex == 0)
            {
                MaterialMappingService.Instance.GetMapping(null, null, "'1','2','3','5'", out dt, out err);
                foreach (DataRow item in dt.Rows)
                {
                    string tempStatus = "";
                    MaterialMapping mapping = MaterialMappingService.Instance.getObject(item);
                    bool isValid;
                    if (!RFCOperation.Instance.CheckIsValidVB(mapping.MATERIAL_FINANCE, 1, out isValid))
                    {
                        tempStatus = "5";
                    }
                    else
                    {
                        if (!isValid)
                            tempStatus = "2";
                        else
                            tempStatus = "4";
                    }
                    if (tempStatus != mapping.STATUS)
                    {
                        mapping.STATUS = tempStatus;
                        MaterialMappingService.Instance.saveUnit(mapping, out err);
                    }
                }
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                InternalOrderMappingService.Instance.GetMapping(null, null, null, "'1','2','3','5'", out dt, out err);
                foreach (DataRow item in dt.Rows)
                {
                    string tempStatus = "";
                    InternalOrderMapping mapping = InternalOrderMappingService.Instance.getObject(item);
                    bool isValid;
                    if (!RFCOperation.Instance.CheckIsValidVB(mapping.INTERNAL_ORDER_FINANCE, 2, out isValid))
                    {
                        tempStatus = "5";
                    }
                    else
                    {
                        if (!isValid)
                            tempStatus = "2";
                        else
                            tempStatus = "4";
                    }
                    if (tempStatus != mapping.STATUS)
                    {
                        mapping.STATUS = tempStatus;
                        InternalOrderMappingService.Instance.saveUnit(mapping, out err);
                    }
                }
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                SupplierMappingService.Instance.GetMapping(null, null, "'1','2','3','5'", out dt, out err);
                foreach (DataRow item in dt.Rows)
                {
                    string tempStatus = "";
                    SupplierMapping mapping = SupplierMappingService.Instance.getObject(item);
                    bool isValid;
                    if (!RFCOperation.Instance.CheckIsValidVB(mapping.FINANCE, 3, out isValid))
                    {
                        tempStatus = "5";
                    }
                    else
                    {
                        if (!isValid)
                            tempStatus = "2";
                        else
                            tempStatus = "4";
                    }
                    if (tempStatus != mapping.STATUS)
                    {
                        mapping.STATUS = tempStatus;
                        SupplierMappingService.Instance.saveUnit(mapping, out err);
                    }
                }
            }
            if (!ReloadData(tabControl1.SelectedIndex, out err))
                return;
        }
    }
}
