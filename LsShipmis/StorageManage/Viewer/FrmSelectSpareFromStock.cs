/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmSpareOutMethod.cs
 * 创 建 人：李景育
 * 创建时间：2008-07-01
 * 标    题：备件出库信息选择
 * 功能描述：实现备件出库信息选择业务窗体上的相关功能
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
using ItemsManage.Viewer.Forms;
using CommonOperation.Interfaces;
using BaseInfo.DataAccess;
using StorageManage.Services;
using CommonViewer.BaseControl;
using ItemsManage;

namespace StorageManage.Viewer
{
    /// <summary>
    /// 备件出库信息选择.
    /// </summary>
    public partial class FrmSelectSpareFromStock : CommonViewer.BaseForm.FormBase
    {
        public bool Selected = false;
        public List<StorageParameter> Spares = new List<StorageParameter>();
        /// <summary>
        /// 定义一个公共类CommonOpt对象.
        /// </summary>
       private IDBOperation commonOpt = CommonOperation.Functions.InterfaceInstantiation.NewADBOperation(); 
        /// <summary>
        /// 权限代理业务类.
        /// </summary>
        private CommonOperation.Functions.ProxyRight proxyRight =CommonOperation.Functions.ProxyRight.Instance;

        bool isloaded = false;
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmSelectSpareFromStock instance = new FrmSelectSpareFromStock();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmSelectSpareFromStock Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmSelectSpareFromStock.instance = new FrmSelectSpareFromStock();
                }

                return FrmSelectSpareFromStock.instance;
            }
        }

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmSelectSpareFromStock()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体启动时的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSpareOutMethod_Load(object sender, EventArgs e)
        {
            ucShipSelect1.ChangeSelectedState(false, true);
            if (!CommonOperation.ConstParameter.IsLandVersion) this.setComboBox(ucShipSelect1.GetId ()); //设置窗体所需的下拉列表框的数据源.
           
            isloaded = true;
            this.setBdsStocks();    //设置库存数据源.
            this.setDgvStocks();    //设置网格控件dgvSpareStock一些的隐藏与列标头的设置.
            ucShipSelect1.ChangeSelectedState(false, true);
            this.WindowState = FormWindowState.Normal;//窗体最大化.
            this.StartPosition = FormStartPosition.CenterParent;
        }

        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox(string shipId)
        {             
            string err;
            //仓库名称选择的DataTable对象（是当前船舶的仓库）.
            DataTable dtbWareHouse = ShipWareHouseService.Instance.getInfoByShipId(shipId, out err);       
            DataRow row = dtbWareHouse.NewRow();
            row["warehouse_id"] = "0";
            row["warehouse_name"] = "全部";
            dtbWareHouse.Rows.InsertAt(row, 0);

            //仓库名称下拉列表.
            cboWareHouse.DataSource = dtbWareHouse;
            cboWareHouse.DisplayMember = "warehouse_name";
            cboWareHouse.ValueMember = "warehouse_id";
        }
 
        /// <summary>
        /// 设置库存信息的bindingSource数据源.
        /// </summary>
        private void setBdsStocks()
        {
            if (!isloaded) return;
            string shipId = ucShipSelect1.GetId();
            string warehouseId = "";
            DataTable dtbSpareStock = null;
            DataTable dtb2;
            if (cboWareHouse.SelectedValue != null)
            {
                warehouseId = cboWareHouse.SelectedValue.ToString();
            }

            //取备件库存信息的DataTable对象.
            if (string.IsNullOrEmpty(shipId) || warehouseId.Equals("0"))
            {
                dtbSpareStock = SpareStockService.Instance.GetSpareAllStock(shipId);
            }
            else
            {
                dtbSpareStock = SpareStockService.Instance.GetSpareWareStock(shipId, warehouseId);                
            }
            //显示警戒库存时，不管是不是选择显示0库存，都要显示相应的内容。.
            if(checkBox2.Checked)
            { 
                dtb2 = dtbSpareStock.Copy();
                dtb2.Rows.Clear();
                DataRow[] drs = dtbSpareStock.Select("ALERTSTOCK > shipallstock");
                if (drs.Length > 0)
                {
                    foreach (DataRow dr in drs)
                    {
                        dtb2.ImportRow(dr);
                    }
                }

                dtbSpareStock = dtb2.Copy();
            }
            else if (!checkBox1.Checked  )
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
            bdsStock.DataSource = dtbSpareStock;
            dgvSpareStock.DataSource = bdsStock;
        }

        /// <summary>
        /// 设置dgvSpareStock的隐藏列与显示标题.
        /// </summary>
        private void setDgvStocks()
        {
            dgvSpareStock.LoadGridView("FrmSelectSpareFromStock.dgvSpareStock");        
            dgvSpareStock.Columns["warehouse_name"].HeaderText = "仓库名称";
            dgvSpareStock.Columns["spare_name"].HeaderText = "备件名称";
            dgvSpareStock.Columns["partnumber"].HeaderText = "配件号|规格";
            dgvSpareStock.Columns["ALERTSTOCK"].HeaderText = "最低库存";
            dgvSpareStock.Columns["stocks"].HeaderText = "本库数量";
            dgvSpareStock.Columns["unit_name"].HeaderText = "计量单位";
            dgvSpareStock.Columns["outnumb"].Visible = false;
            dgvSpareStock.Columns["shipallstock"].HeaderText = "全船数量";
            dgvSpareStock.Columns["warehouse_name"].ReadOnly = true;
            dgvSpareStock.Columns["warehouse_name"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpareStock.Columns["spare_name"].ReadOnly = true;
            dgvSpareStock.Columns["spare_name"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpareStock.Columns["partnumber"].ReadOnly = true;
            dgvSpareStock.Columns["partnumber"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpareStock.Columns["partnumber"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvSpareStock.Columns["ALERTSTOCK"].ReadOnly = true;
            dgvSpareStock.Columns["ALERTSTOCK"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpareStock.Columns["ALERTSTOCK"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvSpareStock.Columns["shipallstock"].ReadOnly = true;
            dgvSpareStock.Columns["shipallstock"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpareStock.Columns["shipallstock"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvSpareStock.Columns["stocks"].ReadOnly = true;
            dgvSpareStock.Columns["stocks"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpareStock.Columns["stocks"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSpareStock.Columns["stocks"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvSpareStock.Columns["unit_name"].ReadOnly = true;
            dgvSpareStock.Columns["unit_name"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpareStock.Columns["unit_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSpareStock.Columns["unit_name"].SortMode = DataGridViewColumnSortMode.NotSortable;

            if (dgvSpareStock.Columns["chkoutstock"] == null)//如果选择列已经存在，则不能重复添加.
            {
                DataGridViewCheckBoxColumn dgvChkCol = new DataGridViewCheckBoxColumn();
                dgvChkCol.Name = "chkoutstock";
                dgvChkCol.HeaderText = "操作";
                dgvChkCol.DefaultCellStyle.BackColor = Color.Linen;
                dgvChkCol.DataPropertyName = "isoutstock";
                dgvChkCol.Width = 40;
                dgvSpareStock.Columns.Insert(0, dgvChkCol);
            }
            else dgvSpareStock.Columns["chkoutstock"].DisplayIndex = 0;
            
            dgvSpareStock.Columns["ship_id"].Visible = false;
            dgvSpareStock.Columns["ship_name"].Visible = false;
            dgvSpareStock.Columns["warehouse_id"].Visible = false;
            dgvSpareStock.Columns["spare_id"].Visible = false;
            dgvSpareStock.Columns["isoutstock"].Visible = false; 
        }

        /// <summary>
        /// 根据仓库筛选备件信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboWareHouse_DropDownClosed(object sender, EventArgs e)
        {
            this.setBdsStocks();
        }
 
        /// <summary>
        /// 释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSpareOutMethod_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
            dgvSpareStock.SaveGridView("FrmSelectSpareFromStock.dgvSpareStock");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (dgvSpareStock.RowCount > 0 && textBox1.Text.Length > 0 && bdsStock != null)
            {
                bdsStock.Filter = "spare_name like '%" + textBox1.Text.Replace("'", "''")
                    + "%' or partnumber like '%" + textBox1.Text.Replace("'", "''")+ "%' ";
            }
            else
                bdsStock.Filter = null;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Selected = false;
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {            
            setBdsStocks();
        }
 
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {   
            //加上这句，只要是警戒库存快到了，就选所有的仓库。暂时屏蔽掉。.
            //if(checkBox2.Checked)cboWareHouse.SelectedIndex = 0;
            setBdsStocks();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvSpareStock.CurrentRow != null && dgvSpareStock.CurrentRow.Cells["spare_id"].Value != null )
            {
                FrmSpareBasic frm = new FrmSpareBasic(dgvSpareStock.CurrentRow.Cells["spare_id"].Value.ToString());
                frm.StartPosition = FormStartPosition.CenterParent; 
                frm.ShowDialog();
                setBdsStocks();
            }
        }

        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            setComboBox(theSelectedObject);           
            setBdsStocks();
        }

        private void bdNgSelect_Click(object sender, EventArgs e)
        {
            Spares.Clear();
            if (dgvSpareStock.Columns.Contains("chkoutstock"))
            {
                foreach (DataGridViewRow dr in dgvSpareStock.Rows)
                {
                    if (dr.Cells["chkoutstock"].Value.ToString() == "1")
                    {
                        StorageParameter sp = new StorageParameter();
                        sp.ItemId = dr.Cells["spare_id"].Value.ToString();
                        Spares.Add(sp);
                    }
                }
                if (Spares.Count > 0)
                {
                    Selected = true;
                    this.Close();
                    return;
                }
                else
                {
                    MessageBoxEx.Show("没有选择任何数据.");
                }
            }
            else
            {
                MessageBoxEx.Show("未发现选择列,无法判断选中的行.");
            }
        }         
    }
}