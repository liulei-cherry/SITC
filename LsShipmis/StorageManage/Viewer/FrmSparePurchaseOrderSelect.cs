using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseInfo.DataAccess;
using StorageManage.Services;
using CommonViewer.BaseControl;
using BaseInfo.Objects;
using CommonViewer;
using System.IO;
using StorageManage.DataObject;
using ItemsManage;

namespace StorageManage.Viewer
{
    public partial class FrmSparePurchaseOrderSelect : CommonViewer.BaseForm.FormBase
    {
        private string shipId = "";//船舶.
        private string manufacturer = "";//供应商.
        public List<string> orderIDList = new List<string>();//选择的ID
        public List<string> orderIDWhereList = new List<string>();//当条件排除用.
        /// <summary>
        /// 1=入库用; 2=凭证用;
        /// </summary>
        private int functionCode = 1;
        public List<StorageParameter> spareids = new List<StorageParameter>();
        #region 窗体单实例模型
        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmSparePurchaseOrderSelect instance = new FrmSparePurchaseOrderSelect();
        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmSparePurchaseOrderSelect Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmSparePurchaseOrderSelect.instance = new FrmSparePurchaseOrderSelect();
                }

                return FrmSparePurchaseOrderSelect.instance;
            }
        }
        private FrmSparePurchaseOrderSelect()
        {
            InitializeComponent();
        }
        public FrmSparePurchaseOrderSelect(string paramShipID)
        {
            InitializeComponent();
            shipId = paramShipID;
        }
        public FrmSparePurchaseOrderSelect(string paramShipID, string paramManufacturer, List<string> paramOrderIDList)
        {
            InitializeComponent();
            functionCode = 2;
            orderIDWhereList = paramOrderIDList;
            shipId = paramShipID;
            manufacturer = paramManufacturer;
        }
        #endregion
        #region 当前行关键值
        public string PURCHASE_ORDERID = "";
        private string STATE = "";
        private string PURCHASE_ORDER_PERSON = "";
        #endregion

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSparePurchaseOrderSelect_Load(object sender, EventArgs e)
        {
            ucShipSelect1.ChangeSelectedState(true, true);
            dgvOrder.DataSource = bindingSource1;
            this.setComboBox();     //设置窗体所需的下拉列表框的数据源.
            if (functionCode == 1)
            {
                ucShipSelect1.SelectedId(shipId);
                ucShipSelect1.Enabled = false;
                cboChkState.SelectedValue = 5;
                cboChkState.Enabled = false;
            }
            else if (functionCode == 2)
            {
                cboChkState.Visible = false;
                labState.Visible = false;
                this.ckbShowReference.Visible = false;
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
            }
            setBindingSource();//设置数据源.
            setDataGridView(); //设置网格控件dgvOrder的隐藏列与标头的设置.
        }
        /// <summary>
        /// 绑定信息.
        /// </summary>
        private void setBindingSource()
        {
            if (functionCode == 1)
                setBindingSourceIn();
            else if (functionCode == 2)
                SetBindingSourceCertificate();
        }
        /// <summary>
        /// 绑定信息入库.
        /// </summary>
        private void setBindingSourceIn()
        {
            string state = "";
            if (cboChkState.SelectedValue == null || cboChkState.SelectedValue.ToString() == "00" || cboChkState.SelectedValue.ToString() == "10")
                state = "";
            else
                state = cboChkState.SelectedValue.ToString();
            DataTable dtbOrder;
            string err;
            SparePurchaseOrderQueryParameter spqp = new SparePurchaseOrderQueryParameter();
            spqp.SHIP_ID = shipId;
            spqp.STATE = state;
            spqp.IsRemoveReference = !ckbShowReference.Checked;
            if (!SparePurchaseOrderService.Instance.GetInfo(spqp, out dtbOrder, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");

            if (cboChkState.SelectedValue != null && cboChkState.SelectedValue.ToString() == "10")
            {
                sb.Append(" and ( 1<>1  ");
                if (CommonOperation.ConstParameter.IsLandVersion)
                {
                    if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
                        sb.AppendLine(" or STATE =1");
                    else if ("机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
                        sb.AppendLine(" or STATE =2 or STATE =1");
                    else if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
                        sb.AppendLine(" or STATE =3");
                }
                sb.AppendLine(" or ( (STATE=0 or STATE=4) and PURCHASE_ORDER_PERSON='" + CommonOperation.ConstParameter.UserName + "'))");
            }
            if (string.IsNullOrEmpty(ucShipSelect1.GetId()))
            {
                DataTable dtOwnerShip = ShipInfoService.Instance.GetOwnerShip(out err);
                if (dtOwnerShip.Rows.Count > 0)
                {
                    sb.Append(" and ship_id in ('1'");
                    foreach (DataRow item in dtOwnerShip.Rows)
                        sb.Append(",'" + item["ship_id"].ToString() + "'");
                    sb.Append(")");
                }
                else
                {
                    sb.Append(" and 1<>1");
                }
            }
            bindingSource1.DataSource = dtbOrder;
            bindingSource1.Filter = sb.ToString();
            if (bindingSource1.Current == null)
                ClearForm();
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
            if (!SparePurchaseOrderService.Instance.GetInfo(null, ucShipSelect1.GetId(), "8", out dtbOrder, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");
            if (string.IsNullOrEmpty(ucShipSelect1.GetId()))
            {
                DataTable dtOwnerShip = ShipInfoService.Instance.GetOwnerShip(out err);
                if (dtOwnerShip.Rows.Count > 0)
                {
                    sb.Append(" and ship_id in ('1'");
                    foreach (DataRow item in dtOwnerShip.Rows)
                        sb.Append(",'" + item["ship_id"].ToString() + "'");
                    sb.Append(")");
                }
                else
                {
                    sb.Append(" and 1<>1");
                }
            }
            if (!string.IsNullOrEmpty(SUPPLIER_ID))
                sb.Append(" and SUPPLIER_ID='" + SUPPLIER_ID + "'");
            foreach (string item in orderIDWhereList)
                sb.Append(" and PURCHASE_ORDERID<>'" + item + "'");
            bindingSource1.Filter = sb.ToString();
            bindingSource1.DataSource = dtbOrder;
            if (bindingSource1.Current == null)
                ClearForm();
        }

        /// <summary>
        /// 清空数据.
        /// </summary>
        private void ClearForm()
        {
            dgvDetail.DataSource = null;
            txtSHIP_NAME.Text = "";
            txtPURCHASE_ORDER_CODE.Text = "";
            txtPURCHASE_ORDER_PERSON.Text = "";
            txtPURCHASE_ORDER_DATE.Text = "";
            txtMANUFACTURER_NAME.Text = "";
            txtSENDDATE.Text = "";
            txtLANDCHECKER.Text = "";
            txtCHECKDATE.Text = "";
            txtREMARK.Text = "";
        }
        /// <summary>
        ///  设置信息网格控件的隐藏列与显示标题.
        /// </summary>
        private void setDataGridView()
        {
            Dictionary<string, string> dgvColumnStyle = new Dictionary<string, string>();
            dgvColumnStyle.Add("PURCHASE_ORDER_CODE", "处理单号");
            dgvColumnStyle.Add("SHIP_NAME", "船舶");
            dgvColumnStyle.Add("COMP_FULL_NAME", "设备");
            dgvColumnStyle.Add("PURCHASE_ORDER_PERSON", "申请人");
            dgvColumnStyle.Add("PURCHASE_ORDER_DATE", "发起日期");
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                dgvColumnStyle.Add("CURRENCYCODE", "货币");
                dgvColumnStyle.Add("TOTALPRICE", "总价");
                dgvColumnStyle.Add("SENDDATE", "到货日期");
                dgvColumnStyle.Add("EXTRAPRICE", "附加费用");
            }
            dgvColumnStyle.Add("MANUFACTURER_NAME", "供应商");
            dgvColumnStyle.Add("SENDPORT", "送货港口");
            dgvColumnStyle.Add("LANDCHECKER", "岸端确认者");
            dgvColumnStyle.Add("CHECKDATE", "岸端确认日期");
            dgvColumnStyle.Add("STATE_NAME", "状态");
            dgvColumnStyle.Add("REMARK", "备注");
            dgvOrder.SetDgvGridColumns(dgvColumnStyle);

            if (dgvOrder.Columns["selColumn"] != null)//如果按钮列已经存在，则不能重复添加.
                dgvOrder.Columns.Remove("selColumn");
            DataGridViewCheckBoxColumn dgvCol = new DataGridViewCheckBoxColumn();
            dgvCol.Name = "selColumn";
            dgvCol.Width = 25;
            dgvCol.HeaderText = "";
            dgvOrder.Columns.Insert(0, dgvCol);
            if (CommonOperation.ConstParameter.IsLandVersion)
                dgvOrder.LoadGridView("FrmSparePurchaseOrderSelect.dgvOrderLand");
            else
                dgvOrder.LoadGridView("FrmSparePurchaseOrderSelect.dgvOrderShip");
            if (functionCode == 1)
                dgvOrder.Columns["selColumn"].Visible = false;
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
            row0["Id"] = "00";
            row0["State"] = "全部";
            dtbChkState.Rows.Add(row0);
            DataRow row11 = dtbChkState.NewRow();
            row11["Id"] = "10";
            row11["State"] = "未填写完毕或等待审核或被打回";
            dtbChkState.Rows.Add(row11);
            DataRow row4 = dtbChkState.NewRow();
            row4["Id"] = "1";
            row4["State"] = "等待岸端机务主管审批";
            dtbChkState.Rows.Add(row4);
            DataRow row5 = dtbChkState.NewRow();
            row5["Id"] = "2";
            row5["State"] = "等待岸端机务经理审批";
            dtbChkState.Rows.Add(row5);
            DataRow row6 = dtbChkState.NewRow();
            row6["Id"] = "3";
            row6["State"] = "等待船管总经理审批";
            dtbChkState.Rows.Add(row6);
            DataRow row9 = dtbChkState.NewRow();
            row9["Id"] = "4";
            row9["State"] = "订单打回";
            dtbChkState.Rows.Add(row9);
            DataRow row1 = dtbChkState.NewRow();
            row1["Id"] = "5";
            row1["State"] = "订购";
            dtbChkState.Rows.Add(row1);
            DataRow row10 = dtbChkState.NewRow();
            row10["Id"] = "6";
            row10["State"] = "此订单作废";
            dtbChkState.Rows.Add(row10);
            DataRow row13 = dtbChkState.NewRow();
            row13["Id"] = "7";
            row13["State"] = "部分到货";
            dtbChkState.Rows.Add(row13);
            DataRow row12 = dtbChkState.NewRow();
            row12["Id"] = "8";
            row12["State"] = "结束";
            dtbChkState.Rows.Add(row12);
            DataRow row18 = dtbChkState.NewRow();
            row18["Id"] = "9";
            row18["State"] = "已生成凭证";
            dtbChkState.Rows.Add(row18);
            cboChkState.DataSource = dtbChkState;
            #endregion

            #region 供应商数据绑定
            ckbMANUFACTURER.DisplayMember = "NAME";
            ckbMANUFACTURER.ValueMember = "ID";
            string err;
            DataTable dt;
            if (!SparePurchaseOrderService.Instance.GetEndManufacturer("8", out dt, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            ckbMANUFACTURER.DataSource = dt;
            #endregion
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
        private void ckbShowReference_CheckedChanged(object sender, EventArgs e)
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
            //选备件.
            if (dgvOrder.Columns[e.ColumnIndex].Name == "selColumn")
            {
                dgvOrder.Rows[e.RowIndex].Cells["selColumn"].Value = !Convert.ToBoolean(dgvOrder.Rows[e.RowIndex].Cells["selColumn"].Value);
            }
        }
        /// <summary>
        /// 当申请单信息网格行改变时，显示当前行的申请单明细信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvOrder_SelectedChanged(int rowNumber)
        {
            if (dgvOrder.DataSource == null || dgvOrder.Rows.Count == 0) return;
            if (dgvOrder.Rows[rowNumber].Cells["PURCHASE_ORDERID"].Value == null) return;
            PURCHASE_ORDERID = dgvOrder.Rows[rowNumber].Cells["PURCHASE_ORDERID"].Value.ToString();
            STATE = dgvOrder.Rows[rowNumber].Cells["STATE"].Value.ToString();
            PURCHASE_ORDER_PERSON = dgvOrder.Rows[rowNumber].Cells["PURCHASE_ORDER_PERSON"].Value.ToString();
            ShowDataToForm();
        }
        /// <summary>
        /// 显示数据到控件上.
        /// </summary>
        private void ShowDataToForm()
        {
            DataTable dt = (DataTable)bindingSource1.DataSource;
            DataRow drItem = dt.Select("PURCHASE_ORDERID='" + PURCHASE_ORDERID + "'")[0];
            txtSHIP_NAME.Text = drItem["SHIP_NAME"].ToString();
            txtPURCHASE_ORDER_CODE.Text = drItem["PURCHASE_ORDER_CODE"].ToString();
            txtPURCHASE_ORDER_PERSON.Text = drItem["PURCHASE_ORDER_PERSON"].ToString();
            txtPURCHASE_ORDER_DATE.Text = drItem["PURCHASE_ORDER_DATE"].ToString();
            txtMANUFACTURER_NAME.Text = drItem["MANUFACTURER_NAME"].ToString();
            txtSENDDATE.Text = drItem["SENDDATE"].ToString();
            txtLANDCHECKER.Text = drItem["LANDCHECKER"].ToString();
            txtCHECKDATE.Text = drItem["CHECKDATE"].ToString();
            txtREMARK.Text = drItem["REMARK"].ToString();
            txtSENDPORT.Text = drItem["SENDPORT"].ToString();
            DataTable dtDetail;
            string err;
            if (!SparePurchaseOrderDetailService.Instance.GetInfo(PURCHASE_ORDERID, out dtDetail, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            dgvDetail.DataSource = dtDetail;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("SPARE_NAME", "备件");
            dic.Add("PARTNUMBER", "采购号或规格");
            dic.Add("PURCHASECOUNT", "采购数量");
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                dic.Add("RECEIVEREMARK", "到货评价");
                dic.Add("RECEIVECOUNT", "到货数量");
            }
            dic.Add("REMARK", "备注");
            dgvDetail.SetDgvGridColumns(dic);
            foreach (DataGridViewColumn item in dgvDetail.Columns)
                item.ReadOnly = true;
        }
        /// <summary>
        /// 选择并关闭.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            string err;
            if (functionCode == 1 && bindingSource1.Current != null)
            {
                orderIDList.Add(((DataRowView)bindingSource1.Current)["PURCHASE_ORDERID"].ToString());

                DataTable dtDetail;
                if (!SparePurchaseOrderDetailService.Instance.GetInfo(((DataRowView)bindingSource1.Current)["PURCHASE_ORDERID"].ToString(), out dtDetail, out err))
                {
                    MessageBoxEx.Show(err);
                    return;
                }
                foreach (DataRow spareitem in dtDetail.Rows)
                {
                    //if (Convert.ToDecimal(spareitem["PURCHASECOUNT"]) == Convert.ToDecimal(spareitem["RECEIVECOUNT"]))
                    //    continue;
                    StorageParameter sp = new StorageParameter();
                    sp.ItemId = spareitem["SPARE_ID"].ToString();
                    sp.orderCode = ((DataRowView)bindingSource1.Current)["PURCHASE_ORDER_CODE"].ToString();
                    if (functionCode == 1)
                        sp.Count = Convert.ToDecimal(spareitem["PURCHASECOUNT"]);
                    else if (functionCode == 2)
                        sp.Count = Convert.ToDecimal(spareitem["RECEIVECOUNT"]);
                    spareids.Add(sp);
                }
            }
            else if (functionCode == 2)
            {
                foreach (DataGridViewRow item in dgvOrder.Rows)
                {
                    if (Convert.ToBoolean(item.Cells["selColumn"].Value) == true)
                    {
                        orderIDList.Add(item.Cells["PURCHASE_ORDERID"].Value.ToString());
                        DataTable dtDetail;
                        if (!SparePurchaseOrderDetailService.Instance.GetInfo(item.Cells["PURCHASE_ORDERID"].Value.ToString(), out dtDetail, out err))
                        {
                            MessageBoxEx.Show(err);
                            return;
                        }
                        foreach (DataRow spareitem in dtDetail.Rows)
                        {
                            //if (Convert.ToDecimal(spareitem["PURCHASECOUNT"]) == Convert.ToDecimal(spareitem["RECEIVECOUNT"]))
                            //    continue;
                            StorageParameter sp = new StorageParameter();
                            sp.ItemId = spareitem["SPARE_ID"].ToString();
                            sp.orderCode = item.Cells["PURCHASE_ORDER_CODE"].Value.ToString();
                            if (functionCode == 1)
                                sp.Count = Convert.ToDecimal(spareitem["PURCHASECOUNT"]);
                            else if (functionCode == 2)
                                sp.Count = Convert.ToDecimal(spareitem["RECEIVECOUNT"]);
                            spareids.Add(sp);
                        }
                    }
                }
                if (orderIDList.Count == 0 && bindingSource1.Current != null)
                {
                    orderIDList.Add(((DataRowView)bindingSource1.Current)["PURCHASE_ORDERID"].ToString());

                    DataTable dtDetail;
                    if (!SparePurchaseOrderDetailService.Instance.GetInfo(((DataRowView)bindingSource1.Current)["PURCHASE_ORDERID"].ToString(), out dtDetail, out err))
                    {
                        MessageBoxEx.Show(err);
                        return;
                    }
                    foreach (DataRow spareitem in dtDetail.Rows)
                    {
                        //if (Convert.ToDecimal(spareitem["PURCHASECOUNT"]) == Convert.ToDecimal(spareitem["RECEIVECOUNT"]))
                        //    continue;
                        StorageParameter sp = new StorageParameter();
                        sp.ItemId = spareitem["SPARE_ID"].ToString();
                        sp.orderCode = ((DataRowView)bindingSource1.Current)["PURCHASE_ORDER_CODE"].ToString();
                        if (functionCode == 1)
                            sp.Count = Convert.ToDecimal(spareitem["PURCHASECOUNT"]);
                        else if (functionCode == 2)
                            sp.Count = Convert.ToDecimal(spareitem["RECEIVECOUNT"]);
                        spareids.Add(sp);
                    }
                }
            }
            this.Close();
        }
        /// <summary>
        /// 释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSparePurchaseOrderSelect_FormClosing(object sender, FormClosingEventArgs e)
        {
            //清除大文档绑定功能.
            if (CommonOperation.ConstParameter.IsLandVersion)
                dgvOrder.SaveGridView("FrmSparePurchaseOrderSelect.dgvOrderLand");
            else
                dgvOrder.SaveGridView("FrmSparePurchaseOrderSelect.dgvOrderShip");
            instance = null;    //释放窗体实例变量.
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
