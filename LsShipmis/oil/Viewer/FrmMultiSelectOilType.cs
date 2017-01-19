/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmMultiSelectOilType.cs
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
using CommonOperation.Interfaces;
using BaseInfo.DataAccess; 
using CommonViewer.BaseControl;
using Oil.Services; 

namespace Oil.Viewer
{
    /// <summary>
    /// 备件出库信息选择.
    /// </summary>
    public partial class FrmMultiSelectOilType : CommonViewer.BaseForm.FormBase
    {
        public bool Selected = false;
        public List<string> OilTypes = new List<string>();
        /// <summary>
        /// 定义一个公共类CommonOpt对象.
        /// </summary>
        private IDBOperation commonOpt = CommonOperation.Functions.InterfaceInstantiation.NewADBOperation(); 
 
        private string shipId;
        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmMultiSelectOilType()
        {
            InitializeComponent();
        }
        public FrmMultiSelectOilType(string shipid)
        {
            InitializeComponent();
            shipId= shipid;
        }
        /// <summary>
        /// 窗体启动时的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMultiSelectOilType_Load(object sender, EventArgs e)
        {
            setComboBox();
            string err;
            DataTable dtbSpareStock = HOilService.Instance.getOilInfoNotSelectedToOneShip(shipId,out err);
            bdsStock.DataSource = dtbSpareStock;
            dgvOilType.DataSource = bdsStock;
            this.setBdsStocks();    //设置库存数据源.
           
            this.setDgvStocks();    //设置网格控件dgvSpareStock一些的隐藏与列标头的设置.
        
            this.WindowState = FormWindowState.Normal;//窗体最大化.
            this.StartPosition = FormStartPosition.CenterParent;
        }

        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {             
            string err;
            //仓库名称选择的DataTable对象（是当前船舶的仓库）.
            DataTable dtbOilType = HOilService.Instance.getOilType(out err);
            DataRow row = dtbOilType.NewRow();
            row["ID"] = "-1";
            row["name"] = "ALL";
            dtbOilType.Rows.InsertAt(row, 0);
            cboOilType.DisplayMember = "name";
            cboOilType.ValueMember = "ID";
            cboOilType.DataSource = dtbOilType;
         
            DataTable dtbOilBrand = HOilService.Instance.getOilBrand(out err);
            DataRow row2 = dtbOilBrand.NewRow();
            row2["OIL_NAME"] = "ALL";
            dtbOilBrand.Rows.InsertAt(row2, 0);
            cboOilBrand.DisplayMember = "OIL_NAME";
            cboOilBrand.ValueMember = "OIL_NAME";
            //仓库名称下拉列表.
            cboOilBrand.DataSource = dtbOilBrand;
           
        }
 
        /// <summary>
        /// 设置库存信息的bindingSource数据源.
        /// </summary>
        private void setBdsStocks()
        {
            string filter = "1=1 ";
            if (cboOilType.SelectedValue != null && int.Parse(cboOilType.SelectedValue.ToString()) >= 0)
            {
                filter += " and OIL_TYPE = '" + cboOilType.SelectedValue.ToString () + "'";
            }
            if (cboOilBrand.SelectedValue != null && cboOilBrand.SelectedValue.ToString() != "ALL")
            {
                filter += " and OIL_NAME = '" + cboOilBrand.SelectedValue.ToString() + "'";
            }
            bdsStock.Filter = filter;
        }

        /// <summary>
        /// 设置dgvSpareStock的隐藏列与显示标题.
        /// </summary>
        private void setDgvStocks()
        {
            dgvOilType.LoadGridView("FrmMultiSelectOilType.dgvOilType");       
            Dictionary<string, string> dicDetail = new Dictionary<string, string>();
            dicDetail.Add("OIL_TYPE_NAME", "油品种类");
            dicDetail.Add("TRADEMARK", "油品型号");
            dicDetail.Add("OIL_NAME", "油品品牌");           
            dgvOilType.SetDgvGridColumns(dicDetail);
            
            if (dgvOilType.Columns["chkoutstock"] == null)//如果选择列已经存在，则不能重复添加.
            {
                DataGridViewCheckBoxColumn dgvChkCol = new DataGridViewCheckBoxColumn();
                dgvChkCol.Name = "chkoutstock";
                dgvChkCol.HeaderText = "选择"; 
                dgvChkCol.DataPropertyName = "chkoutstock";
                dgvChkCol.Width = 40;
                dgvOilType.Columns.Insert(0, dgvChkCol);
            }
            else dgvOilType.Columns["chkoutstock"].DisplayIndex = 0;
             
        }
 
        /// <summary>
        /// 释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMultiSelectOilType_FormClosing(object sender, FormClosingEventArgs e)
        { 
            dgvOilType.SaveGridView("FrmMultiSelectOilType.dgvOilType");     
        }
         
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Selected = false;
            this.Close();
        }

        private void bdNgSelect_Click(object sender, EventArgs e)
        {
            OilTypes.Clear();
            if (dgvOilType.Columns.Contains("chkoutstock"))
            {
                foreach (DataGridViewRow dr in dgvOilType.Rows)
                {
                    if (dr.Cells["chkoutstock"].Value != null && (bool)dr.Cells["chkoutstock"].Value)
                    {
                        OilTypes.Add(dr.Cells["OIL_ID"].Value.ToString());
                    }
                }
                if (OilTypes.Count > 0)
                {
                    Selected = true;
                    this.Close();
                    return;
                }
                else
                {
                    MessageBoxEx.Show("没有选择任何数据!", "提示", new MessageBoxButtons(), MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBoxEx.Show("未发现选择列,无法判断选中的行.", "提示", new MessageBoxButtons(), MessageBoxIcon.Warning);
            }
        }

        private void cboOilBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            setBdsStocks();
        }
        private void cboOilType_SelectedIndexChanged(object sender, EventArgs e)
        {
            setBdsStocks();
        }

        private void dgvOilType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvOilType.Columns[e.ColumnIndex].Name == "chkoutstock")
            {
                bool last = false;
                if (dgvOilType.Rows[e.RowIndex].Cells["chkoutstock"].Value != null
                    && (bool)dgvOilType.Rows[e.RowIndex].Cells["chkoutstock"].Value)
                {
                    last = true;
                }
                dgvOilType.Rows[e.RowIndex].Cells["chkoutstock"].Value = !last;
            }
        }

    }
}