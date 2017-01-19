/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmSpareStock.cs
 * 创 建 人：李景育
 * 创建时间：2007-06-20
 * 标    题：备件库存业务窗体
 * 功能描述：实现备件库存业务窗体上的相关功能
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
using System.Windows.Forms;
using CommonViewer.BaseForm;
using CommonOperation.Interfaces;
using StorageManage.Services;
using ItemsManage.DataObject;
using ItemsManage.Services;
using BaseInfo.DataAccess;
using BaseInfo.Objects;
using ItemsManage.Viewer;
using CommonViewer.BaseControl;
using ItemsManage;

namespace StorageManage.Viewer
{
    /// <summary>
    /// 备件库存管理业务窗体.
    /// </summary>
    public partial class FrmSpareStockInit : CommonViewer.BaseForm.FormBase
    {
        private IDBOperation commonOpt = CommonOperation.Functions.InterfaceInstantiation.NewADBOperation();//定义一个公共类CommonOpt对象.
        private string sChkMessage = "";//权限检查提示信息（没有配置或者没有权限的提示）.
        private CommonOperation.Functions.ProxyRight proxyRight = CommonOperation.Functions.ProxyRight.Instance;//权限代理业务类.
        private bool deleteZero = true;
        private bool firstLoad = true;
        DataGridViewCellStyle warningCell = new DataGridViewCellStyle();
        #region 窗体单实例模型


        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmSpareStockInit instance = new FrmSpareStockInit();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmSpareStockInit Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmSpareStockInit.instance = new FrmSpareStockInit();
                }

                return FrmSpareStockInit.instance;
            }
        }

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmSpareStockInit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体启动时的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSpareStock_Load(object sender, EventArgs e)
        {
            ucShipSelect1.ChangeSelectedState(false, true);
            this.setComboBox();     //设置窗体所需的下拉列表框的数据源.
            ButtonCanOperation(false);
            this.setBindingSource();//设置数据源.
            this.setDataGridView(); //设置网格控件dgvMain一些的隐藏与列标头的设置.
            this.checkRight();      //功能权限校验.
            this.setBdsStocks();
            this.WindowState = FormWindowState.Maximized;//窗体最大化.
            FileOperation.FileBoundingOperation.Instance.FileBoundCheck("", "", 0, "");
            warningCell.BackColor = Color.DarkOrange;
        }

        /// <summary>
        /// 设置bindingSource为数据源.
        /// </summary>
        private void setBindingSource()
        {
            if (string.IsNullOrEmpty(ucShipSelect1.GetId())) return;
            //取油备件库存信息的DataTable对象.
            DataTable dtbSpareStock = SpareStockService.Instance.GetSpareAllStock(ucShipSelect1.GetId());
            bindingSourceMain.DataSource = dtbSpareStock;
            dgvMain.DataSource = bindingSourceMain;
        }

        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {
            if (string.IsNullOrEmpty(ucShipSelect1.GetId())) return;
            string err;
            //仓库名称选择的DataTable对象（是当前船舶的仓库）.
            DataTable dtbWareHouse = BaseInfo.DataAccess.ShipWareHouseService.Instance.getInfoByShipId(ucShipSelect1.GetId(), out err);
            DataRow row = dtbWareHouse.NewRow();
            row["warehouse_id"] = "0";
            row["warehouse_name"] = "ALL";
            dtbWareHouse.Rows.InsertAt(row, 0);
            //仓库名称下拉列表.
            cboWareHouse.DataSource = dtbWareHouse;
            cboWareHouse.DisplayMember = "warehouse_name";
            cboWareHouse.ValueMember = "warehouse_id";
        }

        /// <summary>
        /// 界面功能权限的校验.
        /// </summary>
        private void checkRight()
        {
            //备件操作权限.
            bool spareInfoOperation = proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_INIT, out sChkMessage);

            this.Text += "（具备‘物资初始化’的权限才能编辑）";

            //设置需要权限控制的控件的可见性.
            ButtonCanOperation(spareInfoOperation);
        }
        private void ButtonCanOperation(bool canOper)
        {
            //设置需要权限控制的控件的可见性.
            bdNgAddNewItem.Enabled = canOper;
            bdNgDeleteItem.Enabled = canOper;
            bdNgSaveItem.Enabled = canOper;
        }

        /// <summary>
        /// 设置dgvMain的隐藏列与显示标题.
        /// </summary>
        private void setDataGridView()
        {
            dgvMain.LoadGridView("FrmSpareStock.dgvMain");
            dgvMain.Columns["ship_id"].Visible = false;
            dgvMain.Columns["ship_name"].Visible = false;
            dgvMain.Columns["warehouse_id"].Visible = false;
            dgvMain.Columns["spare_id"].Visible = false;
            dgvMain.Columns["isoutstock"].Visible = false;
            dgvMain.Columns["outnumb"].Visible = false;
            dgvMain.Columns["ATTACHTYPE"].HeaderText = "船存总数";
            dgvMain.Columns["ATTACHCOMP"].HeaderText = "仓库名称"; 
            dgvMain.Columns["shipallstock"].HeaderText = "船存总数";
            dgvMain.Columns["warehouse_name"].HeaderText = "仓库名称";
            dgvMain.Columns["spare_name"].HeaderText = "备件名称";
            dgvMain.Columns["partnumber"].HeaderText = "配件号|规格";
            dgvMain.Columns["stocks"].HeaderText = "本库存量";
            dgvMain.Columns["unit_name"].HeaderText = "计量单位";

            dgvMain.Columns["stocks"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvMain.Columns["unit_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMain.Columns["spare_name"].ReadOnly = true;
            dgvMain.Columns["warehouse_name"].ReadOnly = true;
            dgvMain.Columns["spare_name"].ReadOnly = true;
            dgvMain.Columns["unit_name"].ReadOnly = true;
            dgvMain.Columns["shipallstock"].ReadOnly = true;
            dgvMain.Columns["partnumber"].ReadOnly = true;
            dgvMain.Columns["ALERTSTOCK"].Visible = false;
            dgvMain.Columns["ATTACHCOMP"].Visible = false;
            dgvMain.Columns["ATTACHTYPE"].Visible = false;
            dgvMain.Columns["ATTACHCOMP"].DefaultCellStyle.BackColor = Color.Linen;
            dgvMain.Columns["ATTACHTYPE"].DefaultCellStyle.BackColor = Color.Linen;
            dgvMain.Columns["spare_name"].DefaultCellStyle.BackColor = Color.Linen;
            dgvMain.Columns["warehouse_name"].DefaultCellStyle.BackColor = Color.Linen;
            dgvMain.Columns["spare_name"].DefaultCellStyle.BackColor = Color.Linen;
            dgvMain.Columns["unit_name"].DefaultCellStyle.BackColor = Color.Linen;
            dgvMain.Columns["shipallstock"].DefaultCellStyle.BackColor = Color.Linen;
            dgvMain.Columns["partnumber"].DefaultCellStyle.BackColor = Color.Linen;
        }

        /// <summary>
        /// 添加记录.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            if (cboWareHouse.SelectedValue == null || cboWareHouse.SelectedIndex == 0)
            {
                MessageBoxEx.Show("请先确定要初始化到那个库中", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboWareHouse.Focus();
                return;
            }
            List<StorageParameter> lstSpares;
            string err;
            FrmSelectSpare frm = new FrmSelectSpare(ucShipSelect1.GetId());
            frm.ShowDialog();
            if (frm.Selected && frm.Spares.Count > 0)
            {
                lstSpares = frm.Spares;
                bindingSourceMain.Filter = "";
                textBox1.Text = "";
                DataTable dt = (DataTable)bindingSourceMain.DataSource;
                foreach (StorageParameter spareTemp in lstSpares)
                {
                    DataRow newRow = dt.NewRow();

                    SpareInfo spareInfo = SpareInfoService.Instance.getObject(spareTemp.ItemId, out err);
                    spareInfo.FillThisObject();

                    //如果本库库存已经存在,则不允许添加.
                    decimal countSpareOfThisWarehouse = SpareStockService.Instance.GetSpareStockOfWarehouse
                        (ucShipSelect1.GetId(), spareTemp.ItemId, cboWareHouse.SelectedValue.ToString());
                    if (countSpareOfThisWarehouse > 0) continue;
                    decimal countSpare = SpareStockService.Instance.GetSpareStock(ucShipSelect1.GetId(), spareTemp.ItemId);
                    int rowCountTemp = dt.Rows.Count;
                    dt.Rows.Add(newRow);
                    dgvMain.Rows[rowCountTemp].Cells["ship_id"].Value = ucShipSelect1.GetId();
                    dgvMain.Rows[rowCountTemp].Cells["warehouse_id"].Value = cboWareHouse.SelectedValue;
                    dgvMain.Rows[rowCountTemp].Cells["warehouse_name"].Value = cboWareHouse.Text;
                    dgvMain.Rows[rowCountTemp].Cells["spare_id"].Value = spareTemp.ItemId;
                    dgvMain.Rows[rowCountTemp].Cells["spare_name"].Value = spareInfo.SPARE_NAME;
                    dgvMain.Rows[rowCountTemp].Cells["partnumber"].Value = spareInfo.PARTNUMBER;
                    dgvMain.Rows[rowCountTemp].Cells["stocks"].Value = 0;
                    dgvMain.Rows[rowCountTemp].Cells["unit_name"].Value = spareInfo.UNIT_NAME;
                    dgvMain.Rows[rowCountTemp].Cells["shipallstock"].Value = countSpare;
                    if (countSpare > 0)
                    {
                        dgvMain.Rows[rowCountTemp].Cells["shipallstock"].Style = warningCell;
                    }
                }
            }
        }
        /// <summary>
        /// 删除操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.
            if (string.IsNullOrEmpty(ucShipSelect1.GetId())) return;

            if (bindingSourceMain.Current != null)
            {
                if (MessageBoxEx.Show("初始化的删除是让库存变为0而非真正删除,确定要删除吗？", "删除提示", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }
                dgvMain.CurrentRow.Cells["stocks"].Value = 0;

                bindingSourceMain.EndEdit();
                DataTable dtb = (DataTable)bindingSourceMain.DataSource;//从BindingSource组件中取得信息集放到DataTable中去.
                if (SpareStockService.Instance.SaveTheNewStockCount(dtb, ucShipSelect1.GetId(), out err))
                {
                    MessageBoxEx.Show("删除成功！", "删除成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBoxEx.Show(err, "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            bdNgAddNewItem.Enabled = true;
        }

        /// <summary>
        /// 保存操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgSaveItem_Click(object sender, EventArgs e)
        {
            string err = "";//错误信息参数.

            dgvMain.SaveGridView("FrmSpareStock.dgvMain");
            if (string.IsNullOrEmpty(ucShipSelect1.GetId())) return;
            //***************数据保存*****************************************************************************
            bindingSourceMain.EndEdit();
            dgvMain.EndEdit();
            DataTable dtb = (DataTable)bindingSourceMain.DataSource;//从BindingSource组件中取得信息集放到DataTable中去.

            if (SpareStockService.Instance.SaveTheNewStockCount(dtb, ucShipSelect1.GetId(), out err))
            {
                //保存数据后刷新BindingSource数据源组件.
                this.setBdsStocks();
                MessageBoxEx.Show("数据保存成功！", "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBoxEx.Show(err, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            bdNgAddNewItem.Enabled = true;
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
        /// 释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSpareStock_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;    //释放窗体实例变量.
            dgvMain.SaveGridView("FrmSpareStock.dgvMain");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && bindingSourceMain != null)
            {
                bindingSourceMain.Filter = "spare_name like '%" + textBox1.Text.Replace("'", "''")
                  + "%' or partnumber like '%" + textBox1.Text.Replace("'", "''") + "%'";
            }
            else
                bindingSourceMain.Filter = null;
        }

        private void cboWareHouse_DropDownClosed(object sender, EventArgs e)
        {
            this.setBdsStocks();
        }

        /// <summary>
        /// 设置库存信息的bindingSource数据源.
        /// </summary>
        private void setBdsStocks()
        {
            string shipId = ucShipSelect1.GetId();
            string warehouseId = "";
            DataTable dtbSpareStock = null;
            DataTable dtb2;
            ButtonCanOperation(true);
            if (cboWareHouse.SelectedValue != null)
            {
                string err;
                warehouseId = cboWareHouse.SelectedValue.ToString();
                if (!SpareStockService.Instance.SpareCanReinitOrCheck(shipId, warehouseId, null, out err))
                {
                    MessageBoxEx.Show(err + "\r必须先处理完毕，才能进行盘点操作");
                    ButtonCanOperation(false);
                }
            }
            //取备件库存信息的DataTable对象.
            if (warehouseId.Equals("0"))
            {
                ButtonCanOperation(false);
                dtbSpareStock = SpareStockService.Instance.GetSpareAllStock(shipId);
            }
            else
            {
                dtbSpareStock = SpareStockService.Instance.GetSpareWareStock(shipId, warehouseId);
            }

            if (deleteZero)
            {
                dtb2 = dtbSpareStock.Copy();
                dtb2.Rows.Clear();
                DataRow[] drs = dtbSpareStock.Select("stocks<>'0'");
                if (drs.Length > 0)
                {
                    foreach (DataRow dr in drs)
                    {
                        dtb2.ImportRow(dr);
                    }
                }

                dtbSpareStock = dtb2.Copy();
            }
            dtbSpareStock.Columns["spare_name"].SetOrdinal(0);
            bindingSourceMain.DataSource = dtbSpareStock;
            dgvMain.DataSource = bindingSourceMain;

            if (firstLoad)
            {
                setDataGridView();
                firstLoad = false;
            }

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            deleteZero = !checkBox1.Checked;
            setBdsStocks();
        }

        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            this.setComboBox();     //设置窗体所需的下拉列表框的数据源.
            this.setBindingSource();//设置数据源.
        }

        private void buttonEx1_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("本操作将清除当前船舶历史库存中数量为零的所有信息,是否继续?\r确认请按[是],取消操作请按[否]", "系统提示",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                return;
            string err;
            if (SpareStockService.Instance.ClearZeroStock(ucShipSelect1.GetId(), out err))
            {
                this.setBindingSource();//设置数据源.
                MessageBoxEx.Show("清理完毕");
            }
            else
            {
                MessageBoxEx.Show("清理失败,错误请参考:\r" + err);
            }
        }

        private void buttonEx3_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("此操作将消耗30秒钟左右的时间,当设备备件从属关系更新了以后才需要执行此操作,是否继续操作", 
                "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                string err;
                if (ItemsManage.Services.SpareInfoService.Instance.UpdateSpareComponentInfo(out err))
                {
                    MessageBoxEx.Show("操作成功");
                }
                else
                {
                    MessageBoxEx.Show(err,"操作失败");
                }
            }
        }
    }
}