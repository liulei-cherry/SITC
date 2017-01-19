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

namespace StorageManage.Viewer
{
    /// <summary>
    /// 备件出库信息选择.
    /// </summary>
    public partial class FrmSpareOperation : CommonViewer.BaseForm.FormBase
    {
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
        private static FrmSpareOperation instance = new FrmSpareOperation();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmSpareOperation Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmSpareOperation.instance = new FrmSpareOperation();
                }

                return FrmSpareOperation.instance;
            }
        }

        #endregion

        public void SwitchToAlertStock()
        {
            checkBox2.Checked = true;
            cboWareHouse.SelectedIndex = 0;
        }

        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmSpareOperation()
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
            ucShipSelect1.ChangeSelectedState(false,true);
            if (!CommonOperation.ConstParameter.IsLandVersion) this.setComboBox(ucShipSelect1.GetId ()); //设置窗体所需的下拉列表框的数据源.
          
            if(!this.checkRight())return;      //功能权限校验.
            isloaded = true;
            this.setBdsStocks();    //设置库存数据源.
            this.setDgvStocks();    //设置网格控件dgvSpareStock一些的隐藏与列标头的设置            this.WindowState = FormWindowState.Maximized;//窗体最大化.
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
        /// 界面功能权限的校验.
        /// </summary>
        private bool checkRight()
        {
            string err;
            //设置需要权限控制的控件的可见性.
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                if (!proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_VIEW, out err)
                   && !proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_CHECK, out err)
                   && !proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_LEADER_CHECK, out err)
                   && !proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_MANAGER_CHECK, out err))
                {
                    MessageBoxEx.Show("必须具备【岸端物资管理权限】或【备件岸端审核】权限才能看到数据！");
                    return false;
                }               
                //bdNgStockOut.Visible = false;
                //bdNgStockIn.Visible = false;
            }
            else
            {
                ucShipSelect1.Visible = false;
                //bdNgStockOut.Visible = CommonOperation.ConstParameter.LoginUserInfo.ISHIGHLEVELSHIPMAN;
                //bdNgStockIn.Visible = CommonOperation.ConstParameter.LoginUserInfo.ISHIGHLEVELSHIPMAN;
            }
            return true;
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
            dgvSpareStock.Columns["ATTACHTYPE"].HeaderText = "设备分类";
            dgvSpareStock.Columns["ATTACHTYPE"].ReadOnly = true;
            dgvSpareStock.Columns["ATTACHTYPE"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpareStock.Columns["ATTACHCOMP"].HeaderText = "设备名称";
            dgvSpareStock.Columns["ATTACHCOMP"].ReadOnly = true;
            dgvSpareStock.Columns["ATTACHCOMP"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpareStock.Columns["warehouse_name"].HeaderText = "仓库名称";
            dgvSpareStock.Columns["spare_name"].HeaderText = "备件名称";
            dgvSpareStock.Columns["partnumber"].HeaderText = "配件号|规格";
            dgvSpareStock.Columns["ALERTSTOCK"].HeaderText = "最低库存";
            dgvSpareStock.Columns["stocks"].HeaderText = "本库数量";
            dgvSpareStock.Columns["unit_name"].HeaderText = "计量单位";
            dgvSpareStock.Columns["outnumb"].HeaderText = "操作数量(添数选中备件)";            
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
            dgvSpareStock.Columns["outnumb"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSpareStock.Columns["outnumb"].SortMode = DataGridViewColumnSortMode.NotSortable;
            


            if (dgvSpareStock.Columns["chkoutstock"] == null)//如果选择列已经存在，则不能重复添加.
            {
                DataGridViewCheckBoxColumn dgvChkCol = new DataGridViewCheckBoxColumn();
                dgvChkCol.Name = "chkoutstock";
                dgvChkCol.HeaderText = "操作";
                dgvChkCol.ReadOnly = true;
                dgvChkCol.DefaultCellStyle.BackColor = Color.Linen;
                dgvChkCol.DataPropertyName = "isoutstock";
                dgvChkCol.Width = 40;
                dgvSpareStock.Columns.Insert(dgvSpareStock.Columns.Count - 1, dgvChkCol);
            }
            dgvSpareStock.LoadGridView("FrmSpareOperation.dgvSpareStock"); 
            dgvSpareStock.Columns["ship_id"].Visible = false;
            dgvSpareStock.Columns["ship_name"].Visible = false;
            dgvSpareStock.Columns["warehouse_id"].Visible = false;
            dgvSpareStock.Columns["spare_id"].Visible = false;
            dgvSpareStock.Columns["isoutstock"].Visible = false;
            #region xiaxf  2013-07-09  将【操作数量(添数选中备件)】、【操作】列隐藏
            dgvSpareStock.Columns["chkoutstock"].Visible = false;
            dgvSpareStock.Columns["outnumb"].Visible = false;
            #endregion
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
        /// 备件出库操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgStockOut_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.
            
            dgvSpareStock.EndEdit();

            if (this.IsChkNoStockNumb())
            {
                MessageBoxEx.Show("对于要出库的备件必须填写正确的出库数量！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.IsEmpty())
            {
                MessageBoxEx.Show("请选择要出库的备件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dgvSpareStock.IsNumeric("outnumb") == false)
            {
                MessageBoxEx.Show("出库数量必须是数值型数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.dgvCellValidating(out err) == false)
            {
                MessageBoxEx.Show(err, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBoxEx.Show("确认要出库吗？", "确认框", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }

            //***************数据保存*****************************************************************************
            bdsStock.EndEdit();
            DataTable dtb = (DataTable)bdsStock.DataSource;//从BindingSource组件中取得信息集放到DataTable中去.
            DataRow[] outRows = dtb.Select("isoutstock = 1");
            if (SpareDepotOperationService.Instance.SpareOut(outRows, out err))
            {
                this.setBdsStocks();
                MessageBoxEx.Show("成功生成一条出库单！", "出库成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBoxEx.Show(err, "出库失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// 在保存出库信息时，如果有选择出库标记但未填写出库数量时，则提示。.
        /// </summary>
        /// <returns>如果存在未填写出库数量的现象，返回true，否则返回false</returns>        
        private bool IsChkNoStockNumb()
        {
            bool blResult = false;

            foreach (DataGridViewRow dgvRow in dgvSpareStock.Rows)
            {
                if (dgvRow.Cells["chkoutstock"].Value.ToString().Equals("1"))
                {
                    string sOutNumb = dgvRow.Cells["outnumb"].Value.ToString();
                    if (sOutNumb.Equals(""))
                    {
                        blResult = true;
                        break;
                    }
                    float outNumb = float.Parse(sOutNumb);
                    if (outNumb <= 0)
                    {
                        blResult = true;
                        break;
                    }                    
                }
            }

            return blResult;
        }

        /// <summary>
        /// 检测网格控件中指定的列是否全部是空值。.
        /// </summary>
        /// <returns>如果全部是空值，返回true，否则返回false</returns>        
        private bool IsEmpty()
        {
            bool blResult = true;

            foreach (DataGridViewRow dgvRow in dgvSpareStock.Rows)
            {
                if (dgvRow.Cells["chkoutstock"].Value.ToString().Equals("1"))
                {
                    blResult = false;
                    break;
                }
            }

            return blResult;
        }

        /// <summary>
        /// 当备件出库时进行网格校验.
        /// </summary>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        /// <returns>如果校验通过，返回true；否则返回false</returns>
        private bool dgvCellValidating(out string err)
        {
            bool blResult = true;
            err = "";

            foreach (DataGridViewRow dgvRow in dgvSpareStock.Rows)
            { 
                if(dgvRow.Cells["chkoutstock"].Value.ToString().Equals("1"))
                {
                    float stocks = float.Parse(dgvRow.Cells["stocks"].Value.ToString());    //库存数量.
                    float outnumb = float.Parse(dgvRow.Cells["outnumb"].Value.ToString());  //出库数量.

                    if (stocks == 0)
                    {
                        blResult = false;
                        err = "当前库存数量为0！";
                        break;
                    }

                    if (outnumb < 0)
                    {
                        blResult = false;
                        err = "出库数量不能为负！";
                        break;
                    }

                    if (outnumb > stocks)
                    {
                        blResult = false;
                        err = "出库数量不能大于库存数量！";
                        break;
                    }
                }
            }

            return blResult;
        }

        /// <summary>
        /// 释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSpareOutMethod_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
            dgvSpareStock.SaveGridView("FrmSpareOperation.dgvSpareStock");
        }

        #region 网格校验部分

        private void dgvSpareStock_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            float flt = 0.0f;
            
            //取DataGridView控件的当前列名赋给变量sColName
            string sColName = dgvSpareStock.Columns[e.ColumnIndex].Name.ToLower();
            if (sColName.Equals("outnumb"))
            {
                //取当前值赋给变量scurValue
                string sCurValue = e.FormattedValue.ToString().Trim();
                //取当前库存数.
                float fltStocks = float.Parse(dgvSpareStock.CurrentRow.Cells["stocks"].Value.ToString());

                if (sColName.IndexOf("outnumb") >= 0 && sCurValue.Length > 0 && float.TryParse(sCurValue, out flt) == false)
                {
                    MessageBoxEx.Show("出入库数量必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }
                if (sColName.IndexOf("outnumb") >= 0 && sCurValue.Length > 0 && float.Parse(sCurValue) < 0)
                {
                    MessageBoxEx.Show("出入库数量不能为负数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }
                if (flt != 0)
                {
                    dgvSpareStock.CurrentRow.Cells["isoutstock"].Value = 1;
                }
                else
                {
                    dgvSpareStock.CurrentRow.Cells["isoutstock"].Value = 0;
                }
            }
        }

        #endregion
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
            if (textBox1.Text.Length > 0 && bdsStock != null)
            {
                bdsStock.Filter = "spare_name like '%" + textBox1.Text.Replace("'", "''")
                    + "%' or partnumber like '%" + textBox1.Text.Replace("'", "''")+ "%' ";
            }
            else
                bdsStock.Filter = null;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {            
            setBdsStocks();
        }

        private void buttonEx1_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.
            dgvSpareStock.EndEdit();
            if (this.IsChkNoStockNumb())
            {
                MessageBoxEx.Show("对于要入库的备件必须填写正确的入库数量！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.IsEmpty())
            {
                MessageBoxEx.Show("请选择要入库的备件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dgvSpareStock.IsNumeric("outnumb") == false)
            {
                MessageBoxEx.Show("入库数量必须是数值型数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }             

            if (MessageBoxEx.Show("确认要入库吗？", "确认框", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }

            //***************数据保存*****************************************************************************
            bdsStock.EndEdit();
            DataTable dtb = (DataTable)bdsStock.DataSource;//从BindingSource组件中取得信息集放到DataTable中去.
            DataRow[] outRows = dtb.Select("isoutstock = 1"); 
            if (SpareDepotOperationService.Instance.SpareIn(outRows, out err))
            {
                this.setBdsStocks();
                MessageBoxEx.Show("成功生成一条入库单！", "入库成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBoxEx.Show(err, "入库失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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

        private void buttonEx1_Click_1(object sender, EventArgs e)
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
                    MessageBoxEx.Show(err, "操作失败");
                }
            }
        }         
    }
}