/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmSpareInEdit.cs
 * 创 建 人：徐正本
 * 创建时间：2010-5-4
 * 标    题：备件入库业务窗体
 * 功能描述：实现备件入库业务窗体上的相关功能
 *          本页面有三个情况下使用，一是直接入库单填写时编辑，二是通过其他界面点击入库，传入入库备件id集合入库，三新增入库单
 * 修 改 人：徐正本
 * 修改时间：2011-8-3
 * 修改内容：将业务增加审核流程,根据配置项
 * StorageConfig.StorageChangeNeedShipCheck 及 StorageChangeNeedLandCheck 是否需要审核,再配合
 * 当前是船端还是岸端,将审核流程实现到具体界面中,同时也修改了后台的存储表,使用最新的出入库用同一套表的方案.
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonViewer.BaseForm;
using StorageManage.DataObject;
using StorageManage.Services;
using CommonOperation.Interfaces;
using ItemsManage.DataObject;
using ItemsManage.Services;
using BaseInfo.DataAccess;
using BaseInfo.Objects;
using ItemsManage.Viewer;
using CommonViewer.BaseControl;
using ItemsManage;
using CommonOperation;

namespace StorageManage.Viewer
{
    /// <summary>
    /// 备件入库业务窗体.
    /// </summary>
    public partial class FrmSpareInEdit : CommonViewer.BaseForm.FormBase
    {
        private IDBOperation commonOpt = CommonOperation.Functions.InterfaceInstantiation.NewADBOperation();
        private CommonOperation.Functions.ProxyRight proxyRight = CommonOperation.Functions.ProxyRight.Instance;//权限代理业务类.
        private List<StorageParameter> lstSpares = null;    //接收调用方传过来的要入库的备件的List集合（由设备维护保养系统调用）.
        private string remark = "";                 //接收调用方传过来的要入库的备注信息（由设备维护保养系统调用）.
        private SpareDepotOperation theSpareIn = new SpareDepotOperation();
        private int mainFunction = 1;
        private bool isComplete = false;
        private bool setStyleflag = false;
        private List<string> orderCodeList = new List<string>();
        private SparePurchaseOrder spo = null;
        public string shipId = CommonOperation.ConstParameter.ShipId;
        private int INSTORAGETYPE = 0;
        private bool IsEdit = false;
        private bool IsButtonClose = true;
        private bool IsAdd = false;
        //            1 新入库.
        //*           2 别处选择备件，调用添加申请单、.
        //*           3 修改申请单.
        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmSpareInEdit()
        {

            InitializeComponent();
            this.IsAdd = true;
        }

        /// <summary>
        /// 构造函数，接收设备维护保养系统传过来的信息并显示.
        /// </summary>
        /// <param name="lstSpareIds">要入库的备件的List集合</param>
        /// <param name="remark">备注信息</param>
        public FrmSpareInEdit(List<StorageParameter> lstSpares, string remark)
        {
            InitializeComponent();
            mainFunction = 2;
            //接收调用方传过来的信息（由设备维护保养系统调用）.
            this.lstSpares = lstSpares;//备件Id组成的List集合.
            this.remark = remark;          //备注信息.
            this.IsAdd = false;
        }

        public FrmSpareInEdit(string spareInId,string theshipid)
        {
            //modify by lip 2013-08-27：修改岸端审核时，UcComponentSelect控件数据无法加载数据的问题
            this.shipId = theshipid;
            mainFunction = 3;
            InitializeComponent();
            string err;
            theSpareIn = SpareDepotOperationService.Instance.getObject(spareInId, out err);
            shipId = theSpareIn.SHIP_ID;
            this.INSTORAGETYPE = (int)theSpareIn.INSTORAGETYPE;
            this.IsEdit = true;
            this.IsAdd = false;
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSpareInEdit_Load(object sender, EventArgs e)
        {
            btnFromOrder.Visible = !CommonOperation.ConstParameter.IsLandVersion;
            ucDepartmentSelect1.ChangeMode(2, true);
            bindingData();
            this.setComboBox();     //设置窗体所需的下拉列表框的数据源.
            if (mainFunction == 2)
            {
                setBindingSourceDetail("");
                InsertSparesToGridView(lstSpares, 0, false);
            }
            else
            {
                //加载子记录.
                setBindingSourceDetail(theSpareIn.GetId());
            }
            //审核和提交审核的显示状态. && !CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER
            //仅需要审核,而且当前内容是未审核状态,而且当前人员不是部门长时,才能看到提交审核按钮.
            if (theSpareIn != null && (theSpareIn.STATE == 1 || theSpareIn.STATE == 3)
                && (StorageConfig.StorageChangeNeedLandCheck || StorageConfig.StorageChangeNeedShipCheck)
                  && !CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER && !CommonOperation.ConstParameter.IsLandVersion)
            {
                bdNgComplete.Visible = false;
                bdCommit.Visible = true;
                btnReject.Visible = false;
            }
            else
            {
                bdNgComplete.Visible = true;
                btnReject.Visible = (theSpareIn != null && theSpareIn.STATE > 1);
                bdCommit.Visible = false;
            }
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterParent;
            foreach (DataGridViewRow item in dgvSpInDetail.Rows)
            {
                if (!string.IsNullOrEmpty(item.Cells["order_code"].Value.ToString()) && !orderCodeList.Contains(item.Cells["order_code"].Value.ToString()))
                    orderCodeList.Add(item.Cells["order_code"].Value.ToString());
            }
            if (orderCodeList.Count > 0)
            {
                SetBindingSourceOrderDetail(orderCodeList[0]);
            }
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                foreach (DataGridViewRow item in dgvSpInDetail.Rows)
                {
                    string Spare_Id = item.Cells["Spare_Id"].Value.ToString();
                    decimal count = Convert.ToDecimal(item.Cells["COUNT"].Value);
                    foreach (DataGridViewRow itemtemp in dgvOrderDetail.Rows)
                    {
                        if (itemtemp.Cells["Spare_Id"].Value.ToString() == Spare_Id)
                        {
                            itemtemp.Cells["RECEIVECOUNT"].Value = count;
                        }
                    }
                }
            }
            #region 为海丰屏蔽 删除用0来表示
            ConstParameter.SystemParameter smParam = new ConstParameter.SystemParameter();

            switch (smParam["IsApplyFromInStorage"])
            {
                case "1":
                    bdNgAddNewItem.Visible = false;
                    btnFromApply.Visible = false;
                    bdNgDeleteItem.Visible = false;
                    btnFromOrder.Visible = true;
                    groupBox1.Visible = true;
                    splitContainer1.Panel2Collapsed = false;
                    break;
                case "2":
                    bdNgAddNewItem.Visible = true;
                    btnFromApply.Visible = true;
                    bdNgDeleteItem.Visible = true;
                    btnFromOrder.Visible = false;
                    groupBox1.Visible = false;
                    splitContainer1.Panel2Collapsed = true;
                    break;
                case "3":
                    bdNgAddNewItem.Visible = true;
                    btnFromApply.Visible = true;
                    btnFromOrder.Visible = true;
                    bdNgDeleteItem.Visible = true;
                    groupBox1.Visible = true;
                    splitContainer1.Panel2Collapsed = false;
                    break;
                default:
                    bdNgAddNewItem.Visible = true;
                    btnFromApply.Visible = true;
                    btnFromOrder.Visible = false;
                    bdNgDeleteItem.Visible = true;
                    groupBox1.Visible = false;
                    splitContainer1.Panel2Collapsed = true;
                    break;
            }
            #endregion
        }
        /// <summary>
        /// 绑定订单信息.
        /// </summary>
        /// <param name="orderCode"></param>
        private void SetBindingSourceOrderDetail(string orderCode)
        {
            SparePurchaseOrderQueryParameter mpqp = new SparePurchaseOrderQueryParameter();
            mpqp.PURCHASE_ORDER_CODE = orderCode;
            string err;
            DataTable dt;
            if (!SparePurchaseOrderService.Instance.GetInfo(mpqp, out dt, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            spo = SparePurchaseOrderService.Instance.getObject(dt.Rows[0]["PURCHASE_ORDERID"].ToString(), out err);
            DataTable dtDetail;
            if (!SparePurchaseOrderDetailService.Instance.GetMainDetailInfo(spo.PURCHASE_ORDERID, out dtDetail, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            if (dtDetail.Rows.Count == 0 && this.INSTORAGETYPE != 2)
            {
                MessageBoxEx.Show("订单明细信息不存在");
                return;
            }
            dgvOrderDetail.DataSource = dtDetail;
            if (!setStyleflag)
            {
                setStyleflag = true;
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("PURCHASE_ORDER_CODE", "订单编号");
                dic.Add("COMP_CHINESE_NAME", "设备");
                dic.Add("MANUFACTURER_NAME", "服务商");
                dic.Add("SPARE_NAME", "备件");
                dic.Add("PARTNUMBER", "采购号或规格");
                dic.Add("PURCHASECOUNT", "采购数量");
                if (CommonOperation.ConstParameter.IsLandVersion)
                {
                    dic.Add("CURRENCYCODE", "币种");
                    dic.Add("PRICE", "采购金额");
                    dic.Add("RECEIVEREMARK", "到货评价");
                    dic.Add("RECEIVECOUNT", "到货数量");
                }
                dic.Add("REMARK", "备注");
                dgvOrderDetail.SetDgvGridColumns(dic);
                dgvOrderDetail.setDgvColumnsReadOnly(new string[] { "MANUFACTURER_NAME", "CURRENCYCODE", "PURCHASE_ORDER_CODE", "COMP_CHINESE_NAME", "SPARE_NAME", "PARTNUMBER", "PURCHASECOUNT", "RECEIVEREMARK", "RECEIVECOUNT", "REMARK" });
                if (CommonOperation.ConstParameter.IsLandVersion)
                    dgvOrderDetail.LoadGridView("FrmSpareInEdit.dgvOrderDetailLand");
                else
                    dgvOrderDetail.LoadGridView("FrmSpareInEdit.dgvOrderDetailShip");

            }
        }
        /// <summary>
        /// 从指定的位置往下连续加入几行备件申请信息.
        /// </summary> 
        /// <param name="spareids"></param>
        /// <param name="index">从第几行开始加入，如果从第一行加入，录入0，如果从最后一行加入，录入当前的总行数</param>
        /// <param name="replaceRow">是否要覆盖当前指定行，如果true，则index行会被覆盖掉</param>
        private void InsertSparesToGridView(List<StorageParameter> spareids, int index, bool replaceRow)
        {
            #region 参数判断部分
            if (spareids.Count == 0)
            {
                MessageBoxEx.Show("添加备件入库条目信息时，传入的备件条目为0！", "错误提示");
                return;
            }
            if (index < 0) index = 0;
            if (index > dgvSpInDetail.Rows.Count) index = dgvSpInDetail.Rows.Count;
            if (replaceRow && dgvSpInDetail.Rows.Count - 1 < index)
            {
                throw new Exception("添加备件入库条目信息时，替代已有行时,index参数并不实际存在！");
            }
            #endregion
            string err;
            //从指定行开始加.
            bool theFirstRow = replaceRow;
            bool hasReplitRow = false;
            foreach (StorageParameter spareTemp in spareids)
            {
                decimal dCount = (spareTemp.Count > 0 ? spareTemp.Count : 1);
                string spareId = spareTemp.ItemId;

                if (dgvSpInDetail.HasValue("spare_Id", spareId))
                {
                    hasReplitRow = true;
                    continue;
                }
                SpareInfo spare = SpareInfoService.Instance.getObject(spareId, out err);
                if (theFirstRow)
                {
                    theFirstRow = false;
                }
                else
                {
                    bindingSourceDetail.AddNew();//执行添加记录功能.
                    //为som_in_detail_id列添加一个新的全球码号.
                    dgvSpInDetail.CurrentRow.Cells["SPAREOPERDETAIL_ID"].Value = Guid.NewGuid().ToString();
                    dgvSpInDetail.CurrentRow.Cells["DEPOTOPERID"].Value = txtInMan.Tag;//给som_in_id赋值入库单信息主键值.
                    dgvSpInDetail.CurrentRow.Cells["ship_id"].Value = shipId;//当前船舶Id
                }
                //如果当前备件有指定库存，则用指定库，如果没有则拷贝上一行的.
                dgvSpInDetail.CurrentRow.Cells["spare_id"].Value = spareId;//备件Id
                dgvSpInDetail.CurrentRow.Cells["spare_name"].Value = spare.SPARE_NAME;//备件名称.
                dgvSpInDetail.CurrentRow.Cells["partnumber"].Value = spare.PARTNUMBER;//配件号.
                dgvSpInDetail.CurrentRow.Cells["order_code"].Value = spareTemp.orderCode;//订单号.
                dgvSpInDetail.CurrentRow.Cells["COUNT"].Value = dCount;
                string warehouseId, wareHouseName;
                dgvSpInDetail.CurrentRow.Cells["unit_name"].Value = spare.UNIT_NAME;//计量单位名称.
                SpareStockService.Instance.GetSpareWarehouseInfo(spareId, shipId, out warehouseId, out wareHouseName, out err);

                dgvSpInDetail.CurrentRow.Cells["warehouse_id"].Value = warehouseId;    //取得当前备件的默认仓库Id（有库存的仓库）.
                dgvSpInDetail.CurrentRow.Cells["type_code"].Value = "到货";
                dgvSpInDetail.CurrentRow.Cells["remark"].Value = spare.REMARK;
                if (string.IsNullOrEmpty(dgvSpInDetail.CurrentRow.Cells["warehouse_id"].Value.ToString()))
                {
                    if (dgvSpInDetail.CurrentRow.Index > 0)
                    {
                        dgvSpInDetail.CurrentRow.Cells["warehouse_id"].Value = dgvSpInDetail.Rows[dgvSpInDetail.CurrentRow.Index - 1].Cells["warehouse_id"].Value;
                        dgvSpInDetail.CurrentRow.Cells["warehouse_name"].Value = dgvSpInDetail.Rows[dgvSpInDetail.CurrentRow.Index - 1].Cells["warehouse_name"].Value;
                    }
                }
                else
                {
                    dgvSpInDetail.CurrentRow.Cells["warehouse_name"].Value = wareHouseName;//取得当前备件的默认仓库名称（有库存的仓库）.
                    dgvSpInDetail.CurrentRow.Cells["stocksum"].Value = SpareStockService.Instance.GetSpareStock(shipId, spareId);
                    dgvSpInDetail.CurrentRow.Cells["remark"].Value = spare.REMARK;
                }
            }

            if (hasReplitRow)
            {
                MessageBoxEx.Show("同一备件入库记录不能重复，只能填一条数据,刚刚选择了已经存在的记录，被自动过滤！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            saveDetails(out err);
        }

        private void updateObjectFromForm()
        {
            if (theSpareIn == null)
            {
                throw new Exception("错误，不应该出现无法识别申请单信息的情况!");
            }
            theSpareIn.OPERATION_DATE = dtpInDate.Value;
            theSpareIn.DEPART_ID = ucDepartmentSelect1.GetId();
            theSpareIn.ISCOMPLETE = isComplete ? 1 : 0;
            if (theSpareIn.STATE == 4) theSpareIn.CHECKDATE = DateTime.Today;
            theSpareIn.LANDCHECKER = txtLandChecker.Text;
            theSpareIn.SHIPCHECKER = txtShipChecker.Text;
            theSpareIn.OPERATION_PERSON = txtInMan.Text;
            theSpareIn.REMARK = txtRemark.Text;
            theSpareIn.INSTORAGETYPE = this.INSTORAGETYPE;
            theSpareIn.COMPONENT_UNIT_ID = ucComponentSelect1.GetId();

        }

        /// <summary>
        /// 绑定窗体控件（申请单信息控件的绑定）.
        /// </summary>
        private void bindingData()
        {
            string err;
            //如果是包含子记录的,说明是需要形成记录的，其他都是已经有记录的.
            if (mainFunction != 3)
            {
                theSpareIn.SHIP_ID = shipId;
                theSpareIn.OPERATION_DATE = DateTime.Today;
                theSpareIn.OPERATION_PERSON = CommonOperation.ConstParameter.UserName;
                theSpareIn.OPERATION_PERSON_POSTID = CommonOperation.ConstParameter.LoginUserInfo.PostId;//这里用登录者的岗位，必须使用它，在过滤的时候用到了！.
                theSpareIn.DEPART_ID = CommonOperation.ConstParameter.LoginUserInfo.DepartmentId;
                theSpareIn.ISCOMPLETE = 0;
                theSpareIn.STATE = 1;
                theSpareIn.IN_OR_OUT = 1;
                theSpareIn.REMARK = remark;
                theSpareIn.Update(out err);
                txtInMan.Tag = theSpareIn.GetId();
            }
            showDataToForm();
        }

        private void showDataToForm()
        {
            if (theSpareIn == null)
            {
                throw new Exception("错误，不应该出现无法识别申请单信息的情况!");
            }
            dtpInDate.Value = theSpareIn.OPERATION_DATE;
            ucDepartmentSelect1.SelectedId(theSpareIn.DEPART_ID);
            ucComponentSelect1.SelectedId(theSpareIn.COMPONENT_UNIT_ID);
            txtInMan.Text = theSpareIn.OPERATION_PERSON;
            txtInMan.Tag = theSpareIn.GetId();
            txtShipChecker.Text = theSpareIn.SHIPCHECKER;
            txtLandChecker.Text = theSpareIn.LANDCHECKER;
            txtRemark.Text = theSpareIn.REMARK;
            isComplete = theSpareIn.ISCOMPLETE == 1 ? true : false;

        }

        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {
            string err;
            //把仓库名称下拉列表绑定到网格控件dgvSpInDetail上.
            DataTable dtbWareHouse = ShipWareHouseService.Instance.getInfoByShipId(shipId, out err);
            cboWareHouse.DataSource = dtbWareHouse;
            cboWareHouse.DisplayMember = "warehouse_name";
            cboWareHouse.ValueMember = "warehouse_id";

            DgvBindDrop dgvBindDrop1 = new DgvBindDrop();
            dgvBindDrop1.bindDropToDgv(dgvSpInDetail, cboWareHouse, 7, false, 1);

            //把入库方式下拉列表绑定到网格控件dgvSpInDetail上.
            DgvBindDrop dgvBindDrop3 = new DgvBindDrop();
            dgvBindDrop3.bindDropToDgv(dgvSpInDetail, cboInTypeCode, 11, false, 2);

            //把仓库名称下拉列表绑定到网格控件dgvSpInDetail上.
            DataTable dtbCurrency = CurrencyService.Instance.getInfo(out err);
            cboCurrency.DataSource = dtbCurrency;
            cboCurrency.DisplayMember = "SHOWINGNAME";
            cboCurrency.ValueMember = "CURRENCYID";

            DgvBindDrop dgvBindDrop4 = new DgvBindDrop();
            dgvBindDrop4.bindDropToDgv(dgvSpInDetail, cboCurrency, 16, false, 1);

            //把仓库名称下拉列表绑定到网格控件dgvSpInDetail上.
            DataTable dtbManufactory = ManufacturerService.Instance.getInfo(true, out err);
            cboManufactory.DataSource = dtbManufactory;
            cboManufactory.DisplayMember = "MANUFACTURER_NAME";
            cboManufactory.ValueMember = "MANUFACTURER_ID";

            DgvBindDrop dgvBindDrop5 = new DgvBindDrop();
            dgvBindDrop5.bindDropToDgv(dgvSpInDetail, cboManufactory, 19, false, 1);
            //cboManufactory
        }

        /// <summary>
        /// 设置备件入库单明细信息的bindingSource数据源，每次查询的都是指定入库单的明细信息数据.
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <param name="spareInId">入库单信息Id</param>
        private void setBindingSourceDetail(string spareInId)
        {
            DataTable dtbSpareInDetail = SpareDepotOperationService.Instance.GetSpareInDetail(spareInId);//取得备件入库单明细信息的DataTable对象.
            bindingSourceDetail.DataSource = dtbSpareInDetail;//备件入库明细信息的数据源设置.
            dgvSpInDetail.DataSource = bindingSourceDetail;
            dgvSpInDetail.LoadGridView("FrmSpareInEdit.dgvSpInDetail");
            dgvSpInDetail.Columns["SPAREOPERDETAIL_ID"].Visible = false;
            dgvSpInDetail.Columns["DEPOTOPERID"].Visible = false;
            dgvSpInDetail.Columns["spare_Id"].Visible = false;
            dgvSpInDetail.Columns["warehouse_id"].Visible = false;
            dgvSpInDetail.Columns["ship_id"].Visible = false;
            //dgvSpInDetail.Columns["CURRENCYID"].Visible = false;
            //dgvSpInDetail.Columns["SERVICEPROVIDERID"].Visible = false;
            //if (CommonOperation.ConstParameter.IsLandVersion)
            //{
            //    dgvSpInDetail.Columns["CURRENCYCODE"].Visible = true;
            //    dgvSpInDetail.Columns["AMOUNT"].Visible = true;
            //    dgvSpInDetail.Columns["MANUFACTURER_NAME"].Visible = true;
            //    dgvSpInDetail.Columns["CURRENCYCODE"].HeaderText = "货币种类";
            //    dgvSpInDetail.Columns["AMOUNT"].HeaderText = "总金额";
            //    dgvSpInDetail.Columns["MANUFACTURER_NAME"].HeaderText = "服务商";
            //    dgvSpInDetail.Columns["CURRENCYCODE"].DisplayIndex = 9;
            //    dgvSpInDetail.Columns["AMOUNT"].DisplayIndex = 10;
            //    dgvSpInDetail.Columns["MANUFACTURER_NAME"].DisplayIndex = 11;
            //}
            //else
            //{
            //    dgvSpInDetail.Columns["CURRENCYCODE"].Visible = false;
            //    dgvSpInDetail.Columns["AMOUNT"].Visible = false;
            //    dgvSpInDetail.Columns["MANUFACTURER_NAME"].Visible = false;
            //}
            dgvSpInDetail.Columns["spare_name"].HeaderText = "备件名称";
            dgvSpInDetail.Columns["partnumber"].HeaderText = "配件号|规格";
            dgvSpInDetail.Columns["warehouse_name"].HeaderText = "仓库名称";
            dgvSpInDetail.Columns["stocksum"].HeaderText = "库存数量";
            dgvSpInDetail.Columns["stocksum"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSpInDetail.Columns["COUNT"].HeaderText = "入库数量";
            dgvSpInDetail.Columns["COUNT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSpInDetail.Columns["unit_name"].HeaderText = "单位";
            dgvSpInDetail.Columns["unit_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSpInDetail.Columns["type_code"].HeaderText = "入库方式";
            dgvSpInDetail.Columns["order_code"].HeaderText = "对应订单号";
            dgvSpInDetail.Columns["remark"].HeaderText = "备注";
            dgvSpInDetail.Columns["spare_name"].ReadOnly = true;
            dgvSpInDetail.Columns["spare_name"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpInDetail.Columns["partnumber"].ReadOnly = true;
            dgvSpInDetail.Columns["partnumber"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpInDetail.Columns["warehouse_name"].ReadOnly = true;
            //dgvSpInDetail.Columns["warehouse_name"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpInDetail.Columns["stocksum"].ReadOnly = true;
            dgvSpInDetail.Columns["stocksum"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpInDetail.Columns["unit_name"].ReadOnly = true;
            dgvSpInDetail.Columns["unit_name"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpInDetail.Columns["type_code"].ReadOnly = true;
            dgvSpInDetail.Columns["type_code"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpInDetail.Columns["order_code"].ReadOnly = true;
            dgvSpInDetail.Columns["order_code"].DefaultCellStyle.BackColor = Color.Linen;
            //dgvSpInDetail.Columns["CURRENCYCODE"].ReadOnly = true;
            //dgvSpInDetail.Columns["CURRENCYCODE"].DefaultCellStyle.BackColor = Color.Linen;
            //dgvSpInDetail.Columns["MANUFACTURER_NAME"].ReadOnly = true;
            //dgvSpInDetail.Columns["MANUFACTURER_NAME"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpInDetail.SetDataGridViewNoSort();

            //给dgvSpApplyDetail加一个列按钮列用于打开弹出对话框选择备件信息.
            if (dgvSpInDetail.Columns["selSpare"] == null)//如果按钮列已经存在，则不能重复添加.
            {
                DataGridViewButtonColumn dgvBtnCol = new DataGridViewButtonColumn();
                dgvBtnCol.Name = "selSpare";
                dgvBtnCol.HeaderText = "";
                dgvBtnCol.UseColumnTextForButtonValue = true;
                dgvBtnCol.Text = "…";
                dgvBtnCol.Width = 25;
                dgvSpInDetail.Columns.Insert(4, dgvBtnCol);
            }
            else
            {
                dgvSpInDetail.Columns["selSpare"].DisplayIndex = 4;
            }

            //调用函数设置备件名称与配件号是否可编辑，引用的备件不可编辑，手工添加的备件可编辑。.
            string[] sCols = new string[] { "spare_name", "partnumber" };
            dgvSpInDetail.setDgvCellReadOnly("spare_id", sCols);
        }
        /// <summary>
        /// 当入库数量改变时,联动订单到货数量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSpInDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!CommonOperation.ConstParameter.IsLandVersion) return;
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (dgvSpInDetail.Columns[e.ColumnIndex].Name == "COUNT")
                {
                    string spare_id = dgvSpInDetail.Rows[e.RowIndex].Cells["spare_Id"].Value.ToString();
                    decimal count = Convert.ToDecimal(dgvSpInDetail.Rows[e.RowIndex].Cells["COUNT"].Value);
                    foreach (DataGridViewRow item in dgvOrderDetail.Rows)
                    {
                        if (item.Cells["SPARE_ID"].Value.ToString() == spare_id)
                        {
                            item.Cells["RECEIVECOUNT"].Value = count;
                        }
                    }
                }
            }
        }
        #region 明细数据添加维护的操作


        /// <summary>
        /// 单击选择按钮打开备件弹出框窗体选择备件的Id和名称.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSpInDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSpInDetail.Columns[e.ColumnIndex].Name == "selSpare")
            {
                if (theSpareIn == null || theSpareIn.IsWrong)
                {
                    throw new Exception("无法为未保存的单据添加记录");
                }
                if (string.IsNullOrEmpty(ucComponentSelect1.GetId()))
                {
                    MessageBoxEx.Show("请先选择设备", "提示");
                    ucComponentSelect1.Focus();
                    return;
                }
                string err;
                ComponentUnit cu = ComponentUnitService.Instance.getObject(ucComponentSelect1.GetId(), out err);
                FrmSelectSpare frm = new FrmSelectSpare(cu);
                frm.ShowDialog();

                if (frm.Selected && frm.Spares.Count > 0)
                {
                    InsertSparesToGridView(frm.Spares, e.RowIndex, true);
                }
            }
        }

        /// <summary>
        /// 当仓库变换内容时显示指定仓库的库存数量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboWareHouse_SelectedValueChanged(object sender, EventArgs e)
        {
            string wareHouseId = "";//当前仓库Id
            string wareHousename = "";//当前仓库Id
            string spareId = "";    //当前备件Id

            if (dgvSpInDetail.CurrentRow != null)
            {
                wareHouseId = cboWareHouse.SelectedValue.ToString();
                wareHousename = cboWareHouse.Text;
                spareId = dgvSpInDetail.CurrentRow.Cells["spare_id"].Value.ToString();
                dgvSpInDetail.CurrentRow.Cells["stocksum"].Value = SpareStockService.Instance.GetSpareStock(shipId, spareId);

                //如果当前存在未填写的仓库，则输入内容后，其他未填写的均变成此仓库.

                for (int i = 0; i < dgvSpInDetail.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(dgvSpInDetail.Rows[i].Cells["warehouse_id"].Value.ToString()))
                    {
                        dgvSpInDetail.Rows[i].Cells["warehouse_id"].Value = wareHouseId;
                        dgvSpInDetail.Rows[i].Cells["warehouse_name"].Value = wareHousename;
                    }
                }
            }
        }

        private void cboCurrency_SelectedValueChanged(object sender, EventArgs e)
        {
            string CURRENCYID = "";//当前货币id
            string CURRENCYCODE = "";//当前货币代码.
            if (dgvSpInDetail.CurrentRow != null)
            {
                CURRENCYID = cboCurrency.SelectedValue.ToString();
                CURRENCYCODE = cboCurrency.Text;

                for (int i = 0; i < dgvSpInDetail.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(dgvSpInDetail.Rows[i].Cells["CURRENCYID"].Value.ToString()))
                    {
                        dgvSpInDetail.Rows[i].Cells["CURRENCYID"].Value = CURRENCYID;
                        dgvSpInDetail.Rows[i].Cells["CURRENCYCODE"].Value = CURRENCYCODE;
                    }
                }
            }
        }

        private void cboManufactory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SERVICEPROVIDERID = "";//当前货币id
            string MANUFACTURER_NAME = "";//当前货币代码.
            if (dgvSpInDetail.CurrentRow != null)
            {
                SERVICEPROVIDERID = cboManufactory.SelectedValue.ToString();
                MANUFACTURER_NAME = cboManufactory.Text;

                for (int i = 0; i < dgvSpInDetail.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(dgvSpInDetail.Rows[i].Cells["SERVICEPROVIDERID"].Value.ToString()))
                    {
                        dgvSpInDetail.Rows[i].Cells["SERVICEPROVIDERID"].Value = SERVICEPROVIDERID;
                        dgvSpInDetail.Rows[i].Cells["MANUFACTURER_NAME"].Value = MANUFACTURER_NAME;
                    }
                }
            }
        }

        private void cboInTypeCode_SelectedValueChanged(object sender, EventArgs e)
        {
            string inTypeCode = cboInTypeCode.Text;
            if (dgvSpInDetail.CurrentRow != null)
            {
                for (int i = 0; i < dgvSpInDetail.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(dgvSpInDetail.Rows[i].Cells["type_code"].Value.ToString()))
                    {
                        dgvSpInDetail.Rows[i].Cells["type_code"].Value = inTypeCode;
                    }
                }
            }
        }
        #endregion

        #region 备件入库单明细网格校验部分


        private void dgvSpInDetail_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            float flt = 0.0f;
            //取DataGridView控件的当前列名赋给变量sColName
            string sColName = dgvSpInDetail.Columns[e.ColumnIndex].Name.ToLower();
            //取当前值赋给变量scurValue
            string sCurValue = e.FormattedValue.ToString().Trim();

            if (sColName.Equals("COUNT") && float.TryParse(sCurValue, out flt) == false)
            {
                MessageBoxEx.Show("入库数量必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            if (sColName.Equals("COUNT") && float.Parse(sCurValue) <= 0)
            {
                MessageBoxEx.Show("入库数量不能为0或负数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
        }
        private bool OrderCheck()
        {
            string err;
            foreach (string item in orderCodeList)
            {
                if (string.IsNullOrEmpty(item))
                {
                    if (this.INSTORAGETYPE == 2)
                    {
                        MessageBoxEx.Show("申请单编号不正确");
                    }
                    else
                    {
                        MessageBoxEx.Show("订单编号不正确");
                    }
                    return false;
                }

                SparePurchaseOrderQueryParameter mpqp = new SparePurchaseOrderQueryParameter();
                mpqp.PURCHASE_ORDER_CODE = item;
                DataTable dt;
                if (!SparePurchaseOrderService.Instance.GetInfo(mpqp, out dt, out err))
                {
                    MessageBoxEx.Show(err);
                    return false;
                }
                if (dt.Rows.Count > 0)
                {
                    SparePurchaseOrder spo = SparePurchaseOrderService.Instance.getObject(dt.Rows[0]["PURCHASE_ORDERID"].ToString(), out err);
                    if (spo.STATE != 5)
                    {
                        if (this.INSTORAGETYPE == 2)
                        {
                            MessageBoxEx.Show("该申请单已经执行过入库操作,不可以再次使用此订单入库");
                        }
                        else
                        {
                            MessageBoxEx.Show("该订单已经执行过入库操作,不可以再次使用此订单入库");
                        }

                        return false;
                    }
                }
                else
                {
                    if (this.INSTORAGETYPE == 2)
                    {
                        MessageBoxEx.Show("申请单单信息不正确");
                    }
                    else
                    {
                        MessageBoxEx.Show("订单信息不正确");
                    }

                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 明细数据保存时的校验函数.
        /// </summary>
        /// <returns>如果校验通过，返回true；否则返回false</returns>
        private bool validateDet()
        {
            if (string.IsNullOrEmpty(ucDepartmentSelect1.GetId()))
            {
                MessageBoxEx.Show("入库部门是必填内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(ucComponentSelect1.GetId()))
            {
                MessageBoxEx.Show("设备不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ucComponentSelect1.Focus();
                return false;
            }
            if (dgvSpInDetail.HasEmptyVal("spare_name") == true)
            {
                MessageBoxEx.Show("备件名称是必填内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dgvSpInDetail.HasEmptyVal("warehouse_id") == true)
            {
                MessageBoxEx.Show("仓库名称是必填内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dgvSpInDetail.HasEmptyVal("COUNT") == true)
            {
                MessageBoxEx.Show("入库数量是必填内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dgvSpInDetail.IsNumeric("COUNT") == false)
            {
                MessageBoxEx.Show("入库数量必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (dgvSpInDetail.HasEmptyVal("type_code") == true)
            {
                MessageBoxEx.Show("入库方式是必填内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        #endregion

        #region 按钮的操作

        /// <summary>
        /// 备件入库明细信息添加.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string shipId = theSpareIn.SHIP_ID;

            if (string.IsNullOrEmpty(ucComponentSelect1.GetId()))
            {
                MessageBoxEx.Show("设备为空，不可以添加明细！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ucComponentSelect1.Focus();
                return;
            }

            if (!dgvSpInDetail.HasEmptyVal("spare_name"))
            {
                bindingSourceDetail.AddNew();
                //为som_in_detail_id列添加一个新的全球码号.
                dgvSpInDetail.CurrentRow.Cells["SPAREOPERDETAIL_ID"].Value = Guid.NewGuid().ToString();
                dgvSpInDetail.CurrentRow.Cells["DEPOTOPERID"].Value = txtInMan.Tag;//给som_in_id赋值入库单信息主键值.
                dgvSpInDetail.CurrentRow.Cells["ship_id"].Value = shipId;//当前船舶Id
                dgvSpInDetail.CurrentRow.Cells["type_code"].Value = "到货";
            }
        }

        /// <summary>
        /// 备件入库明细信息消耗信息删除.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.
            string spareOrderCode = ""; //订单号.
            if (bindingSourceDetail.Current != null)
            {

                if (MessageBoxEx.Show("确定要删除吗？", "删除提示", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }

                //取要删除行的订单号（如果不是从订单引入的数据，那么为空）.
                spareOrderCode = dgvSpInDetail.CurrentRow.Cells["order_code"].Value.ToString();

                bindingSourceDetail.RemoveCurrent();
                bindingSourceDetail.EndEdit();
                DataTable dtb = (DataTable)bindingSourceDetail.DataSource;//从BindingSource组件中取得信息集放到DataTable中去.
                if (commonOpt.SaveFormData(dtb, "T_SPARE_DEPOT_OPERATION_DETAIL", 0, out err))
                {
                    MessageBoxEx.Show("删除成功！", "删除成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBoxEx.Show(err, "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        /// <summary>
        /// 备件入库信息保存操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgSaveItem_Click(object sender, EventArgs e)
        {
            //isComplete = false;
            if (this.validateDet() == false)
            {
                return;
            }
            if (saveInfor())
            {
                MessageBoxEx.Show("操作成功！", "提示");
                setBindingSourceDetail(theSpareIn.GetId());
                this.IsButtonClose = false;
                this.Close();
            }
        }

        /// <summary>
        /// 入库单完成操作（只有完成的入库单才允许审核）.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgComplete_Click(object sender, EventArgs e)
        {

            string err = ""; //错误信息参数.
            string somInId = "";        //入库单Id
            isComplete = true;
            bindingSourceDetail.EndEdit();
            dgvSpInDetail.EndEdit();
            if (dgvSpInDetail.Rows.Count == 0)
            {
                MessageBoxEx.Show("无可操作的信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            somInId = txtInMan.Tag.ToString();
            txtLandChecker.Text = CommonOperation.ConstParameter.UserName;
            switch (this.INSTORAGETYPE)
            {
                case 1:
                    //岸端,则状态为4,船端则状态为2;
                    if (CommonOperation.ConstParameter.IsLandVersion)
                    {
                        theSpareIn.STATE = 4;
                    }
                    else
                    {
                        txtLandChecker.Text = "";
                        if (!StorageConfig.StorageChangeNeedLandCheck)
                            theSpareIn.STATE = 4;
                        else
                            theSpareIn.STATE = 2;
                    }
                    break;
                default:
                    //申请单的审核
                    theSpareIn.STATE = 4;
                    if (!CommonOperation.ConstParameter.IsLandVersion)
                    {
                        txtLandChecker.Text = "";
                    }
                    break;
            }



            if (spo == null && this.INSTORAGETYPE == 1)
            {
                MessageBoxEx.Show("订单主信息不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.validateDet() == false)
            {
                return;
            }
            if (this.OrderCheck() == false)
            {
                return;
            }
            //***************数据操作*****************************************************************************
            //更新结果报告.
            if (MessageBoxEx.Show("是否确认当前入库单信息？如果确认请点击【是】否则点击【否】！\r注意，如果确认则不允许再次编辑！", "确认框", MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (saveInfor())
                {
                    MessageBoxEx.Show("操作成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (CommonOperation.ConstParameter.IsLandVersion)
                    {
                        decimal total = 0;
                        foreach (DataRow item in ((DataTable)dgvOrderDetail.DataSource).Rows)
                        {
                            SparePurchaseOrderDetail spod = SparePurchaseOrderDetailService.Instance.getObject(item);
                            if (!spod.Update(out err))
                            {
                                if (this.INSTORAGETYPE == 2)
                                {
                                    MessageBoxEx.Show("更新申请单到货信息时发生错误,错误信息请参考:\r" + err);
                                }
                                else
                                {
                                    MessageBoxEx.Show("更新订单到货信息时发生错误,错误信息请参考:\r" + err);
                                }
                                return;
                            }
                            total += spod.PRICE;
                        }
                        spo.SENDDATE = DateTime.Now;
                        spo.TOTALPRICE = total;
                        spo.STATE = 8;
                        if (!spo.Update(out err))
                        {
                            if (this.INSTORAGETYPE == 2)
                            {
                                MessageBoxEx.Show("更新申请单单状态时发生错误,错误信息请参考:\r" + err);
                            }
                            else
                            {
                                MessageBoxEx.Show("更新订单状态时发生错误,错误信息请参考:\r" + err);
                            }

                            return;
                        }
                    }
                    this.IsButtonClose = false;
                    this.Close();
                }
                //if (saveInfor())
                //{
                //    MessageBoxEx.Show("操作成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    //如果需要跟外部接口,则直接调用接口函数处理.
                //    if (theSpareIn.STATE == 4 && StorageConfig.createMessage != null)
                //    {
                //        DataTable dtb;
                //        if (!SAPServiceOfSpareAndMaterial.Instance.GetSpareDepotInOperationToSAP(theSpareIn.GetId(), out dtb, out err)
                //            || !StorageConfig.createMessage(theSpareIn.SHIP_ID, theSpareIn.OPERATION_DATE, theSpareIn.CHECKDATE, theSpareIn.GetId(), dtb, "1", "2", out err))
                //        {
                //            MessageBoxEx.Show("将变化数据发送给SAP时发生错误,需要重新审核,错误信息请参考:\r" + err);
                //            theSpareIn.STATE = 2;
                //            theSpareIn.Update(out err);
                //            return;
                //        }
                //        else
                //        {
                //            DataTable dtbSpareInDetail = SpareDepotOperationService.Instance.GetSpareInDetail(theSpareIn.GetId());//取得备件入库单明细信息的DataTable对象.
                //            foreach (DataRow item in dtbSpareInDetail.Rows)
                //            {
                //                if (!SparePurchaseOrderDetailService.Instance.GoodsArrivalOperation(item["spare_Id"].ToString(), Convert.ToDecimal(item["COUNT"]), out err))
                //                {
                //                    MessageBoxEx.Show("更新订单到货信息时发生错误,错误信息请参考:\r" + err);
                //                    return;
                //                }
                //            }
                //        }
                //    }
                //    this.Close();
                //}
            }

        }

        private void bdCommit_Click(object sender, EventArgs e)
        {
            //如果是船端,状态是1的才能进行此按钮的操作,否则,到了部门长或者船长级别,或者岸端审核人员都不应该出现此按钮.
            isComplete = true;
            txtLandChecker.Text = "";
            SpareDepotOperation theSpareTemp = (SpareDepotOperation)theSpareIn.Clone();
            if (dgvSpInDetail.Rows.Count > 0)
            {
                theSpareIn.STATE = 1;
            }
            else
            {
                MessageBoxEx.Show("当前入库单不包含任何有效数据,无法提交审核.");
                return;
            }
            if (this.validateDet() == false)
            {
                return;
            }
            if (this.OrderCheck() == false)
            {
                return;
            }
            if (saveInfor())
            {
                MessageBoxEx.Show("操作成功！", "提示");
                this.IsButtonClose = false;
                this.Close();
            }
            else
            {
                MessageBoxEx.Show("操作失败！", "提示");
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {

            //如果是船端,状态是1的才能进行此按钮的操作,否则,到了部门长或者船长级别,或者岸端审核人员都不应该出现此按钮.
            isComplete = true;
            theSpareIn.STATE = 3;
            if (CommonOperation.ConstParameter.IsLandVersion)
                txtLandChecker.Text = CommonOperation.ConstParameter.UserName;
            else
                txtShipChecker.Text = CommonOperation.ConstParameter.UserName;
            if (this.validateDet() == false)
            {
                return;
            }
            OurMessageBox messagebox = new OurMessageBox("确定要打回入库操作吗？\r如果确认,请描述打回原因并点击[确定]按钮,否则点击[取消]按钮.",
               "确认框", theSpareIn.REMARK + "\r\n" + DateTime.Now.ToShortDateString() + "被 " + CommonOperation.ConstParameter.UserName + " 打回");
            messagebox.ShowDialog();
            if (!messagebox.Answer) return;
            txtRemark.Text = messagebox.AnswerTxt;

            if (saveInfor())
            {
                MessageBoxEx.Show("操作成功！", "提示");
                this.IsButtonClose = false;
                this.Close();
            }
            else
            {
                MessageBoxEx.Show("操作失败！", "提示");
            }
        }

        /// <summary>
        /// 关闭窗体.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgClose_Click(object sender, EventArgs e)
        {
            this.IsButtonClose = true;
            this.Close();
        }

        private bool saveInfor()
        {
            string err;
            updateObjectFromForm();
            //***************数据校验*****************************************************************************
            if (string.IsNullOrEmpty(theSpareIn.OPERATION_CODE))
                theSpareIn.OPERATION_CODE = StorageCommonService.Instance.GetSpareAndMaterialInOrOutCode(theSpareIn.SHIP_ID);
            if (theSpareIn.Update(out err))
            {
                return saveDetails(out err);
            }
            else
            {
                MessageBoxEx.Show(err, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return false;
        }

        private bool saveDetails(out string err)
        {
            bindingSourceDetail.EndEdit();
            dgvSpInDetail.EndEdit();
            err = "";
            if (dgvSpInDetail.Rows.Count == 0) return true;
            //***************数据保存*****************************************************************************
            DataTable dtb = (DataTable)bindingSourceDetail.DataSource;//从BindingSource组件中取得信息集放到DataTable中去.

            return commonOpt.SaveFormData(dtb, "T_SPARE_DEPOT_OPERATION_DETAIL", 0, out err);//保存数据.
        }

        /// <summary>
        /// 窗体关闭时对网格dgvSpInDetail的一些必填值进行校验并释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSpareInEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            string err;
            if (this.IsButtonClose)
            {

                if (theSpareIn.ISCOMPLETE == 0 && dgvSpInDetail.Rows.Count == 0)
                {
                    if (MessageBoxEx.Show("没有添加任何入库条目，请确认是否保存当前信息，\r保存请按【是】不保存请按【否】", "提示", MessageBoxButtons.YesNo,
                         MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        theSpareIn.Delete(out err);
                    }
                    else
                    {
                        this.saveInfor();
                    }
                }
                else
                {
                    if (MessageBoxEx.Show("是否要保存当前信息，\r保存请按【是】不保存请按【否】", "提示", MessageBoxButtons.YesNo,
                         MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        this.saveInfor();
                    }
                    else
                    {
                        if (IsAdd)
                        {
                            theSpareIn.Delete(out err); 
                        }
                    }
                } 
            }
            
            
            //dgvSpInDetail.SaveGridView("FrmSpareInEdit.dgvSpInDetail");
            //if (CommonOperation.ConstParameter.IsLandVersion)
            //    dgvOrderDetail.SaveGridView("FrmSpareInEdit.dgvOrderDetailLand");
            //else
            //    dgvOrderDetail.SaveGridView("FrmSpareInEdit.dgvOrderDetailShip");
        }

        /// <summary>
        /// 导入订单明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFromOrder_Click(object sender, EventArgs e)
        {
            if (orderCodeList.Count > 0)
            {
                MessageBoxEx.Show("只能导入一个订单");
                return;
            }
            //订单入库

            if (!this.IsEdit)
            {
                this.INSTORAGETYPE = 1; 
            }
            FrmSparePurchaseOrderSelect frm = new FrmSparePurchaseOrderSelect(shipId);
            frm.ShowDialog();
            if (frm.spareids.Count != 0)
            {
                InsertSparesToGridView(frm.spareids, dgvSpInDetail.Rows.Count, false);
            }
            foreach (DataGridViewRow item in dgvSpInDetail.Rows)
            {
                if (!string.IsNullOrEmpty(item.Cells["order_code"].Value.ToString()) && !orderCodeList.Contains(item.Cells["order_code"].Value.ToString()))
                    orderCodeList.Add(item.Cells["order_code"].Value.ToString());
            }
            if (orderCodeList.Count > 0)
            {
                SetBindingSourceOrderDetail(orderCodeList[0]);
            }
            groupBox1.Visible = true;
            splitContainer1.Panel2Collapsed = false;
        }

        /// <summary>
        /// 导入申请单明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFromApply_Click(object sender, EventArgs e)
        {
            if (orderCodeList.Count > 0)
            {
                MessageBoxEx.Show("只能导入一个申请单");
                return;
            }
            //申请单入库
            if (!this.IsEdit) 
            {
                this.INSTORAGETYPE = 2;
            }
            FrmSpareApplySelect frm = new FrmSpareApplySelect(shipId);
            frm.ShowDialog();
            ucComponentSelect1.SelectedId(frm.COMPONENT_UNIT_ID);
            ucComponentSelect1.Enabled = false;
            if (frm.spareids.Count != 0)
            {
                InsertSparesToGridView(frm.spareids, dgvSpInDetail.Rows.Count, false);
            }
            if (orderCodeList.Count > 0)
            {
                SetBindingSourceOrderDetail(orderCodeList[0]);
            }
            groupBox1.Visible = false;
            splitContainer1.Panel2Collapsed = true;
        }
        #endregion
    }
}