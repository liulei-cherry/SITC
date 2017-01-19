using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseInfo.DataAccess;
using CommonViewer.BaseControl;
using BaseInfo.Objects;
using CommonViewer;
using System.IO;
using Oil.Services;

namespace Oil.Viewer
{
    public partial class FrmOilPurchaseOrderSelect : CommonViewer.BaseForm.FormBase
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmOilPurchaseOrderSelect instance = new FrmOilPurchaseOrderSelect();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmOilPurchaseOrderSelect Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmOilPurchaseOrderSelect.instance = new FrmOilPurchaseOrderSelect();
                }

                return FrmOilPurchaseOrderSelect.instance;
            }
        }

        #endregion

        #region 构造函数

        private FrmOilPurchaseOrderSelect()
        {
            InitializeComponent();
        }
        public FrmOilPurchaseOrderSelect(string paramShipID)
            : this()
        {
            shipId = paramShipID;
        }
        public FrmOilPurchaseOrderSelect(string paramShipID, string paramManufacturer, List<string> paramOrderIDList)
            : this()
        {
            this.paramOrderIDList = paramOrderIDList;
            shipId = paramShipID;
            manufacturer = paramManufacturer;
        }

        #endregion

        #region 全局变量

        private string shipId = "";//船舶.
        private string manufacturer = "";//供应商.

        public List<string> orderIDList = new List<string>();//选择的油料订单ID
        private List<string> paramOrderIDList = new List<string>();

        #region 当前行关键值

        public string ORDERID = "";
        //private string STATE = "";
        //private string ORDER_PERSON = "";

        #endregion

        #endregion

        #region 窗体事件

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmOilPurchaseOrderSelect_Load(object sender, EventArgs e)
        {
            ucShipSelect1.ChangeSelectedState(true, true);
            dgvMatApply.DataSource = bindingSource1;
            this.setComboBox();  //设置窗体所需的下拉列表框的数据源.

            cboChkState.Visible = false;
            labState.Visible = false;
            labMANUFACTURER.Visible = true;
            ckbMANUFACTURER.Visible = true;
            if (!string.IsNullOrEmpty(shipId))
            {
                ucShipSelect1.SelectedId(shipId);
                ucShipSelect1.Enabled = false;
            }
            if (!string.IsNullOrEmpty(manufacturer))
            {
                ckbMANUFACTURER.SelectedValue = manufacturer;
                ckbMANUFACTURER.Enabled = false;
            }

            setBindingSource();//设置数据源.
            setDataGridView(); //设置网格控件dgvOrder的隐藏列与标头的设置.
        }

        #region 筛选条件控件事件

        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            this.setBindingSource();
        }
        private void cboChkState_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.setBindingSource();
        }
        private void ckbMANUFACTURER_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.setBindingSource();
        }
        #endregion

        /// <summary>
        /// 单击选择.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //选订单.
            if (dgvMatApply.Columns[e.ColumnIndex].Name == "selectColumn")
            {
                dgvMatApply.Rows[e.RowIndex].Cells["selectColumn"].Value = !Convert.ToBoolean(dgvMatApply.Rows[e.RowIndex].Cells["selectColumn"].Value);
            }
        }

        /// <summary>
        /// 当申请单信息网格行改变时，显示当前行的申请单明细信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMatApply_SelectedChanged(int rowNumber)
        {
            if (dgvMatApply.DataSource == null || dgvMatApply.Rows.Count == 0) return;
            if (dgvMatApply.Rows[rowNumber].Cells["ORDER_ID"].Value == null) return;
            ORDERID = dgvMatApply.Rows[rowNumber].Cells["ORDER_ID"].Value.ToString();
            //STATE = dgvMatApply.Rows[rowNumber].Cells["STATE"].Value.ToString();
            //ORDER_PERSON = dgvMatApply.Rows[rowNumber].Cells["PURCHASE_ORDER_PERSON"].Value.ToString();
            ShowDataToForm();
        }

        /// <summary>
        /// 选择并关闭.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        { 
            foreach (DataGridViewRow item in dgvMatApply.Rows)
            {
                if (Convert.ToBoolean(item.Cells["selectColumn"].Value) == true)
                {
                    orderIDList.Add(item.Cells["ORDER_ID"].Value.ToString());
                }
            }
            if (orderIDList.Count == 0 && dgvMatApply.CurrentRow != null)
            {
                orderIDList.Add(dgvMatApply.CurrentRow.Cells["ORDER_ID"].Value.ToString());
            }
            this.Close();
        }

        #endregion

        #region 数据操作

        /// <summary>
        /// 绑定信息.
        /// </summary>
        private void setBindingSource()
        {
            SetBindingSourceCertificate();
        }

        /// <summary>
        /// 绑定信息凭证.
        /// </summary>
        private void SetBindingSourceCertificate()
        {
            string SUPPLIER_ID = "";
            if (ckbMANUFACTURER.SelectedValue != null)
                SUPPLIER_ID = ckbMANUFACTURER.SelectedValue.ToString();
            DataTable dtbOrder;
            string err;
            if (!HOilOrderService.Instance.GetOrder(ucShipSelect1.GetId(), "5,6", null, out dtbOrder, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");
            if (!string.IsNullOrEmpty(SUPPLIER_ID))
                sb.Append(" and SUPPLIER_ID='" + SUPPLIER_ID + "'");
            foreach (string item in paramOrderIDList)
                sb.Append(" and ORDER_ID<>'" + item + "'");
            bindingSource1.DataSource = dtbOrder;
            bindingSource1.Filter = sb.ToString();
            if (bindingSource1.Current == null)
                ClearForm();
        }

        /// <summary>
        /// 显示数据到控件上.
        /// </summary>
        private void ShowDataToForm()
        {
            DataTable dt = (DataTable)bindingSource1.DataSource;
            DataRow drItem = dt.Select("ORDER_ID='" + ORDERID + "'")[0];
            txtPurchaseDate.Text = drItem["ORDER_DATE"].ToString();
            txtSendDate.Text = drItem["SUPPLY_DATE"].ToString();
            txtRemark.Text = drItem["REMARK"].ToString();
            txtManufacture.Text = drItem["MANUFACTURER_NAME"].ToString();
            txtShipBase.Text = drItem["CNAME"].ToString();
            DataTable dtDetail;
            string err;
            if (!HOilOrderService.Instance.GetOrderDetail(ORDERID, out dtDetail, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            dgvMatApplyDetail.DataSource = dtDetail;
            Dictionary<string, string> dgvMatApplyDetailColumnsStyle = new Dictionary<string, string>();
            dgvMatApplyDetailColumnsStyle.Clear();
            dgvMatApplyDetailColumnsStyle.Add("OIL_NAME", "滑油");
            dgvMatApplyDetailColumnsStyle.Add("TRADEMARK", "牌号");
            dgvMatApplyDetailColumnsStyle.Add("NUM", "订购数量");
            if (CommonOperation.ConstParameter.IsLandVersion)//仅陆地端需要显示列.
            {
                dgvMatApplyDetailColumnsStyle.Add("CURRENCYNAME", "币种");
                dgvMatApplyDetailColumnsStyle.Add("AMOUNT", "金额");
            }
            dgvMatApplyDetail.SetDgvGridColumns(dgvMatApplyDetailColumnsStyle);
            foreach (DataGridViewColumn item in dgvMatApplyDetail.Columns)
                item.ReadOnly = true;
        }

        /// <summary>
        /// 清空数据.
        /// </summary>
        private void ClearForm()
        {
            dgvMatApplyDetail.DataSource = null;
            txtPurchaseDate.Text = "";
            txtSendDate.Text = "";
            txtRemark.Text = "";
            txtManufacture.Text = "";
            txtShipBase.Text = "";
        }

        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {
            #region 审核状态数据绑定
            cboChkState.DisplayMember = "State";
            cboChkState.ValueMember = "Id";
            DataTable dtbChkState = new DataTable();
            dtbChkState.Columns.Add("Id", typeof(string));
            dtbChkState.Columns.Add("State", typeof(string));
            DataRow row0 = dtbChkState.NewRow();
            row0["Id"] = " 0";
            row0["State"] = "岸端未通过";
            dtbChkState.Rows.Add(row0);
            DataRow row1 = dtbChkState.NewRow();
            row1["Id"] = "1";
            row1["State"] = "岸端已通过";
            dtbChkState.Rows.Add(row1);
            DataRow row2 = dtbChkState.NewRow();
            row2["Id"] = "2";
            row2["State"] = "船端未通过";
            dtbChkState.Rows.Add(row2);
            DataRow row3 = dtbChkState.NewRow();
            row3["Id"] = "3";
            row3["State"] = "船端已通过";
            dtbChkState.Rows.Add(row3);
            DataRow row4 = dtbChkState.NewRow();
            row4["Id"] = "9";
            row4["State"] = "已生成凭证";
            dtbChkState.Rows.Add(row4);
            cboChkState.DataSource = dtbChkState;
            #endregion

            #region 供应商数据绑定

            ckbMANUFACTURER.DisplayMember = "NAME";
            ckbMANUFACTURER.ValueMember = "ID";
            string err;
            DataTable dt;//船端通过的定单供应商.
            if (!HOilOrderService.Instance.GetEndManufacturer("5,6", out dt, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            ckbMANUFACTURER.DataSource = dt;
            #endregion
        }

        #endregion

        #region 私有方法

        /// <summary>
        ///  设置信息网格控件的隐藏列与显示标题.
        /// </summary>
        private void setDataGridView()
        {
            Dictionary<string, string> dgvMatApplyColumnStyle = new Dictionary<string, string>();
            dgvMatApplyColumnStyle.Add("ORDER_DATE", "订购日期");
            dgvMatApplyColumnStyle.Add("SUPPLY_DATE", "送船日期");
            dgvMatApplyColumnStyle.Add("CNAME", "港口");
            dgvMatApplyColumnStyle.Add("MANUFACTURER_NAME", "供应商");
            dgvMatApplyColumnStyle.Add("CHECKED", "审核状态");
            dgvMatApplyColumnStyle.Add("remark", "备注");
            dgvMatApply.SetDgvGridColumns(dgvMatApplyColumnStyle);
            if (dgvMatApply.Columns["selectColumn"] != null)//如果按钮列已经存在，则不能重复添加.
                dgvMatApply.Columns.Remove("selectColumn");
            DataGridViewCheckBoxColumn dgvCol = new DataGridViewCheckBoxColumn();
            dgvCol.Name = "selectColumn";
            dgvCol.Width = 25;
            dgvCol.HeaderText = "";
            dgvMatApply.Columns.Insert(0, dgvCol);

            Dictionary<string, string> dgvMatApplyDetailColumnsStyle = new Dictionary<string, string>();
            dgvMatApplyDetailColumnsStyle.Clear();
            dgvMatApplyDetailColumnsStyle.Add("OIL_NAME", "滑油");
            dgvMatApplyDetailColumnsStyle.Add("TRADEMARK", "牌号");
            dgvMatApplyDetailColumnsStyle.Add("NUM", "订购数量");
            if (CommonOperation.ConstParameter.IsLandVersion)//仅陆地端需要显示列.
            {
                dgvMatApplyDetailColumnsStyle.Add("CURRENCYNAME", "币种");
                dgvMatApplyDetailColumnsStyle.Add("AMOUNT", "金额");
            }
            dgvMatApplyDetail.SetDgvGridColumns(dgvMatApplyDetailColumnsStyle);

            dgvMatApply.LoadGridView("FrmOilPurchaseOrderSelect.dgvOrderLand");
            dgvMatApplyDetail.LoadGridView("FrmOilPurchaseOrderSelect.dgvOrderLandDetail");
        }

        #endregion

        /// <summary>
        /// 释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmOilPurchaseOrderSelect_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvMatApply.SaveGridView("FrmOilPurchaseOrderSelect.dgvOrderLand");
            dgvMatApplyDetail.SaveGridView("FrmOilPurchaseOrderSelect.dgvOrderLandDetail");
            instance = null;
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
    }
}
