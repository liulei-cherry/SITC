/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmMaterialInEdit.cs
 * 创 建 人：徐正本
 * 创建时间：2010-5-4
 * 标    题：物资入库业务窗体
 * 功能描述：实现物资入库业务窗体上的相关功能
 *          本页面有三个情况下使用，一是直接入库单填写时编辑，二是通过其他界面点击入库，传入入库物资id集合入库，三新增入库单
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
    /// 物资入库业务窗体.
    /// </summary>
    public partial class FrmMaterialInEdit : FormBase
    {
        #region 窗体变量
        private IDBOperation commonOpt = CommonOperation.Functions.InterfaceInstantiation.NewADBOperation();
        private CommonOperation.Functions.ProxyRight proxyRight = CommonOperation.Functions.ProxyRight.Instance;//权限代理业务类.
        private List<StorageParameter> lstMaterials = null;    //接收调用方传过来的要入库的物资的List集合（由设备维护保养系统调用）.
        private string remark = "";                 //接收调用方传过来的要入库的备注信息（由设备维护保养系统调用）.
        private MaterialDepotOperation theMaterialIn = new MaterialDepotOperation();
        private int mainFunction = 1;
        private bool isComplete = false;
        private List<string> orderCodeList = new List<string>();
        private List<string> applyCodeList = new List<string>();
        private MaterialPurchaseOrder spo = null;
        private bool setStyleflag = false;
        string shipId = "";
        private bool IsAdd = false;
        /// <summary>
        /// 入库方式1.订单入库2.申请单入入库3.手工入库
        /// 默认是手工入库
        /// </summary>
        public Decimal inStorageType = 3;
        private bool IsEdit = false;

        private bool IsButtonClose = true;
        #endregion

        #region  构造函数
        //            1 新入库.
        //*           2 别处选择物资，调用添加申请单、.
        //*           3 修改申请单.
        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmMaterialInEdit()
        {
            InitializeComponent();
            shipId = CommonOperation.ConstParameter.ShipId;
            this.IsAdd = true;
        }

        public FrmMaterialInEdit(string materialInId)
        {
            mainFunction = 3;
            InitializeComponent();
            string err;
            theMaterialIn = MaterialDepotOperationService.Instance.getObject(materialInId, out err);
            shipId = theMaterialIn.SHIP_ID;
            this.inStorageType = theMaterialIn.INSTORAGETYPE;
            this.IsEdit = true;
        }
        #endregion

        #region 窗体方法
        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMaterialInEdit_Load(object sender, EventArgs e)
        {
            btnFromOrder.Visible = !CommonOperation.ConstParameter.IsLandVersion;
            ucDepartmentSelect1.ChangeMode(2, true);
            bindingData();
            this.setComboBox();     //设置窗体所需的下拉列表框的数据源.
            if (mainFunction == 2)
            {
                setBindingSourceDetail("");
                InsertMaterialsToGridView(lstMaterials, 0, false);
            }
            else
            {
                //加载子记录.
                setBindingSourceDetail(theMaterialIn.GetId());
            }
            //审核和提交审核的显示状态. 
            //仅需要审核,而且当前内容是未审核状态,而且当前人员不是部门长时,才能看到提交审核按钮.
            if (theMaterialIn != null && (theMaterialIn.STATE == 1 || theMaterialIn.STATE == 3)
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
                btnReject.Visible = (theMaterialIn != null && theMaterialIn.STATE > 1);
                bdCommit.Visible = false;
            }
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterParent;

            if (theMaterialIn.INSTORAGETYPE == 1 || theMaterialIn.INSTORAGETYPE == 0)//订单入库才走这里zhangy-2013-6-27
            {
                foreach (DataGridViewRow item in dgvSpInDetail.Rows)
                {
                    if (!string.IsNullOrEmpty(item.Cells["order_code"].Value.ToString()) && !orderCodeList.Contains(item.Cells["order_code"].Value.ToString()))
                        orderCodeList.Add(item.Cells["order_code"].Value.ToString());
                }
                if (orderCodeList.Count > 0)
                {
                    SetBindingSourceOrderDetail(orderCodeList[0]);
                }
            }

            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                foreach (DataGridViewRow item in dgvSpInDetail.Rows)
                {
                    string Material_id = item.Cells["Material_Id"].Value.ToString();
                    decimal count = Convert.ToDecimal(item.Cells["COUNT"].Value);
                    foreach (DataGridViewRow itemtemp in dgvOrderDetail.Rows)
                    {
                        if (itemtemp.Cells["Material_ID"].Value.ToString() == Material_id)
                        {
                            itemtemp.Cells["RECEIVECOUNT"].Value = count;
                        }
                    }
                }
            }
            #region 入库模式
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
                    bdNgDeleteItem.Visible = true;
                    btnFromOrder.Visible = true;
                    groupBox1.Visible = true;
                    splitContainer1.Panel2Collapsed = false;
                    break;
                default:
                    bdNgAddNewItem.Visible = true;
                    btnFromApply.Visible = true;
                    bdNgDeleteItem.Visible = true;
                    btnFromOrder.Visible = false;
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
            MaterialPurchaseOrderQueryParameter mpqp = new MaterialPurchaseOrderQueryParameter();
            mpqp.PURCHASE_ORDER_CODE = orderCode;
            string err;
            DataTable dt;
            if (!MaterialPurchaseOrderService.Instance.GetInfo(mpqp, out dt, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            spo = MaterialPurchaseOrderService.Instance.getObject(dt.Rows[0]["PURCHASE_ORDERID"].ToString(), out err);
            DataTable dtDetail;
            if (!MaterialPurchaseOrderDetailService.Instance.GetMainDetailInfo(spo.PURCHASE_ORDERID, out dtDetail, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            if (dtDetail.Rows.Count == 0)
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
                dic.Add("MANUFACTURER_NAME", "服务商");
                dic.Add("MATERIAL_NAME", "物料");
                dic.Add("MATERIAL_SPEC", "采购号或规格");
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
                dgvOrderDetail.setDgvColumnsReadOnly(new string[] { "MANUFACTURER_NAME", "CURRENCYCODE", 
                    "PURCHASE_ORDER_CODE", "MATERIAL_NAME",  "PURCHASECOUNT", "RECEIVEREMARK",
                    "RECEIVECOUNT", "REMARK","MATERIAL_SPEC" });
                if (CommonOperation.ConstParameter.IsLandVersion)
                    dgvOrderDetail.LoadGridView("FrmMaterialInEdit.dgvOrderDetailLand");
                else
                    dgvOrderDetail.LoadGridView("FrmMaterialInEdit.dgvOrderDetailShip");
            }
        }
        /// <summary>
        /// 从指定的位置往下连续加入几行物资申请信息.
        /// </summary> 
        /// <param name="materialids"></param>
        /// <param name="index">从第几行开始加入，如果从第一行加入，录入0，如果从最后一行加入，录入当前的总行数</param>
        /// <param name="replaceRow">是否要覆盖当前指定行，如果true，则index行会被覆盖掉</param>
        private void InsertMaterialsToGridView(List<StorageParameter> materialids, int index, bool replaceRow)
        {
            //dgvSpInDetail.DataSource = null;
            
            #region 参数判断部分
            if (materialids.Count == 0)
            {
                MessageBoxEx.Show("添加物资入库条目信息时，传入的物资条目为0！", "错误提示");
                return;
            }
            if (index < 0) index = 0;
            if (index > dgvSpInDetail.Rows.Count) index = dgvSpInDetail.Rows.Count;
            if (replaceRow && dgvSpInDetail.Rows.Count - 1 < index)
            {
                throw new Exception("添加物资入库条目信息时，替代已有行时,index参数并不实际存在！");
            }
            #endregion
            string err;
            //从指定行开始加.
            bool theFirstRow = replaceRow;
            bool hasReplitRow = false;
            foreach (StorageParameter materialTemp in materialids)
            {
                decimal dCount = (materialTemp.Count > 0 ? materialTemp.Count : 1);
                string materialId = materialTemp.ItemId;

                if (dgvSpInDetail.HasValue("material_Id", materialId))
                {
                    hasReplitRow = true;
                    continue;
                }
                MaterialInfo material = MaterialInfoService.Instance.getObject(materialId, out err);
                if (theFirstRow)
                {
                    theFirstRow = false;
                }
                else
                {
                    bindingSourceDetail.AddNew();//执行添加记录功能.
                    //为som_in_detail_id列添加一个新的全球码号.
                    dgvSpInDetail.CurrentRow.Cells["MATERIALOPERDETAIL_ID"].Value = Guid.NewGuid().ToString();
                    dgvSpInDetail.CurrentRow.Cells["DEPOTOPERID"].Value = txtInMan.Tag;//给som_in_id赋值入库单信息主键值.
                    dgvSpInDetail.CurrentRow.Cells["ship_id"].Value = shipId;//当前船舶Id
                }
                //如果当前物资有指定库存，则用指定库，如果没有则拷贝上一行的.
                dgvSpInDetail.CurrentRow.Cells["material_id"].Value = materialId;//物资Id
                dgvSpInDetail.CurrentRow.Cells["material_name"].Value = material.MATERIAL_NAME;//物资名称.
                dgvSpInDetail.CurrentRow.Cells["MATERIAL_SPEC"].Value = material.MATERIAL_SPEC;//规格型号.
                dgvSpInDetail.CurrentRow.Cells["MATERIAL_CODE"].Value = material.MATERIAL_CODE;//物资编码.
                dgvSpInDetail.CurrentRow.Cells["ORDER_CODE"].Value = materialTemp.orderCode;//对应订单号.
                dgvSpInDetail.CurrentRow.Cells["COUNT"].Value = dCount;
                string warehouseId, wareHouseName;
                dgvSpInDetail.CurrentRow.Cells["unit_name"].Value = material.UNIT_NAME;//计量单位名称.
                MaterialStockService.Instance.GetMaterialWarehouseInfo(materialId, shipId, out warehouseId, out wareHouseName, out err);

                dgvSpInDetail.CurrentRow.Cells["warehouse_id"].Value = warehouseId;    //取得当前物资的默认仓库Id（有库存的仓库）.
                dgvSpInDetail.CurrentRow.Cells["type_code"].Value = "到货";
                dgvSpInDetail.CurrentRow.Cells["remark"].Value = material.REMARK;
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
                    dgvSpInDetail.CurrentRow.Cells["warehouse_name"].Value = wareHouseName;//取得当前物资的默认仓库名称（有库存的仓库）.
                    dgvSpInDetail.CurrentRow.Cells["stocksum"].Value = MaterialStockService.Instance.GetMaterialStock(shipId, materialId);
                    dgvSpInDetail.CurrentRow.Cells["remark"].Value = material.REMARK;
                }
            }

            if (hasReplitRow)
            {
                MessageBoxEx.Show("同一物资入库记录不能重复，只能填一条数据,刚刚选择了已经存在的记录，被自动过滤！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            saveDetails(out err);
        }

        private void updateObjectFromForm()
        {
            if (theMaterialIn == null)
            {
                throw new Exception("错误，不应该出现无法识别申请单信息的情况!");
            }
            theMaterialIn.OPERATION_DATE = dtpInDate.Value;
            theMaterialIn.DEPART_ID = ucDepartmentSelect1.GetId();
            theMaterialIn.ISCOMPLETE = isComplete ? 1 : 0;
            if (theMaterialIn.STATE == 4) theMaterialIn.CHECKDATE = DateTime.Today;
            theMaterialIn.LANDCHECKER = txtLandChecker.Text;
            theMaterialIn.SHIPCHECKER = txtShipChecker.Text;
            theMaterialIn.OPERATION_PERSON = txtInMan.Text;
            theMaterialIn.REMARK = txtRemark.Text;
            theMaterialIn.INSTORAGETYPE = inStorageType;
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
                theMaterialIn.SHIP_ID = shipId;
                theMaterialIn.OPERATION_DATE = DateTime.Today;
                theMaterialIn.OPERATION_PERSON = CommonOperation.ConstParameter.UserName;
                theMaterialIn.OPERATION_PERSON_POSTID = CommonOperation.ConstParameter.LoginUserInfo.PostId;//这里用登录者的岗位，必须使用它，在过滤的时候用到了！.
                theMaterialIn.DEPART_ID = CommonOperation.ConstParameter.LoginUserInfo.DepartmentId;
                theMaterialIn.ISCOMPLETE = 0;
                theMaterialIn.STATE = 1;
                theMaterialIn.IN_OR_OUT = 1;
                theMaterialIn.REMARK = remark;
                theMaterialIn.Update(out err);
                txtInMan.Tag = theMaterialIn.GetId();
            }
            showDataToForm();
        }

        private void showDataToForm()
        {
            if (theMaterialIn == null)
            {
                throw new Exception("错误，不应该出现无法识别申请单信息的情况!");
            }
            dtpInDate.Value = theMaterialIn.OPERATION_DATE;
            ucDepartmentSelect1.SelectedId(theMaterialIn.DEPART_ID);
            txtInMan.Text = theMaterialIn.OPERATION_PERSON;
            txtInMan.Tag = theMaterialIn.GetId();
            txtShipChecker.Text = theMaterialIn.SHIPCHECKER;
            txtLandChecker.Text = theMaterialIn.LANDCHECKER;
            txtRemark.Text = theMaterialIn.REMARK;
            isComplete = theMaterialIn.ISCOMPLETE == 1 ? true : false;

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
            dgvBindDrop1.bindDropToDgv(dgvSpInDetail, cboWareHouse, 8, false, 1);

            //把入库方式下拉列表绑定到网格控件dgvSpInDetail上.
            DgvBindDrop dgvBindDrop3 = new DgvBindDrop();
            dgvBindDrop3.bindDropToDgv(dgvSpInDetail, cboInTypeCode, 12, false, 2);

            //把仓库名称下拉列表绑定到网格控件dgvSpInDetail上.
            DataTable dtbCurrency = CurrencyService.Instance.getInfo(out err);
            cboCurrency.DataSource = dtbCurrency;
            cboCurrency.DisplayMember = "SHOWINGNAME";
            cboCurrency.ValueMember = "CURRENCYID";

            DgvBindDrop dgvBindDrop4 = new DgvBindDrop();
            dgvBindDrop4.bindDropToDgv(dgvSpInDetail, cboCurrency, 17, false, 1);

            //把仓库名称下拉列表绑定到网格控件dgvSpInDetail上.
            DataTable dtbManufactory = ManufacturerService.Instance.getInfo(true, out err);
            cboManufactory.DataSource = dtbManufactory;
            cboManufactory.DisplayMember = "MANUFACTURER_NAME";
            cboManufactory.ValueMember = "MANUFACTURER_ID";

            DgvBindDrop dgvBindDrop5 = new DgvBindDrop();
            dgvBindDrop5.bindDropToDgv(dgvSpInDetail, cboManufactory, 20, false, 1);
            //cboManufactory
        }

        /// <summary>
        /// 设置物资入库单明细信息的bindingSource数据源，每次查询的都是指定入库单的明细信息数据.
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <param name="materialInId">入库单信息Id</param>
        private void setBindingSourceDetail(string materialInId)
        {
            DataTable dtbMaterialInDetail = MaterialDepotOperationService.Instance.GetMaterialInDetail(materialInId);//取得物资入库单明细信息的DataTable对象.
            bindingSourceDetail.DataSource = dtbMaterialInDetail;//物资入库明细信息的数据源设置.
            dgvSpInDetail.DataSource = bindingSourceDetail;
            dgvSpInDetail.LoadGridView("FrmMaterialInEdit.dgvSpInDetail");
            dgvSpInDetail.Columns["MATERIALOPERDETAIL_ID"].Visible = false;

            dgvSpInDetail.Columns["DEPOTOPERID"].Visible = false;
            dgvSpInDetail.Columns["material_Id"].Visible = false;
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
            //    dgvSpInDetail.Columns["CURRENCYCODE"].DefaultCellStyle.BackColor = Color.Linen;
            //    dgvSpInDetail.Columns["MANUFACTURER_NAME"].DefaultCellStyle.BackColor = Color.Linen;
            //    dgvSpInDetail.Columns["CURRENCYCODE"].Visible = false;
            //    dgvSpInDetail.Columns["AMOUNT"].Visible = false;
            //    dgvSpInDetail.Columns["MANUFACTURER_NAME"].Visible = false;
            //}
            dgvSpInDetail.Columns["MATERIAL_CODE"].HeaderText = "物资编码";
            dgvSpInDetail.Columns["material_name"].HeaderText = "物资名称";
            dgvSpInDetail.Columns["MATERIAL_SPEC"].HeaderText = "规格型号";
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
            dgvSpInDetail.Columns["material_name"].ReadOnly = true;
            dgvSpInDetail.Columns["material_name"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpInDetail.Columns["MATERIAL_CODE"].ReadOnly = true;
            dgvSpInDetail.Columns["MATERIAL_CODE"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpInDetail.Columns["MATERIAL_SPEC"].ReadOnly = true;
            dgvSpInDetail.Columns["MATERIAL_SPEC"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpInDetail.Columns["warehouse_name"].ReadOnly = true;
            //dgvSpInDetail.Columns["warehouse_name"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpInDetail.Columns["stocksum"].ReadOnly = true;
            dgvSpInDetail.Columns["stocksum"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpInDetail.Columns["unit_name"].ReadOnly = true;
            dgvSpInDetail.Columns["unit_name"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpInDetail.Columns["type_code"].ReadOnly = true;
            //dgvSpInDetail.Columns["type_code"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpInDetail.Columns["order_code"].ReadOnly = true;
            dgvSpInDetail.Columns["order_code"].DefaultCellStyle.BackColor = Color.Linen;
            //dgvSpInDetail.Columns["CURRENCYCODE"].ReadOnly = true;
            //dgvSpInDetail.Columns["MANUFACTURER_NAME"].ReadOnly = true;
            dgvSpInDetail.SetDataGridViewNoSort();

            //给dgvSpApplyDetail加一个列按钮列用于打开弹出对话框选择物资信息.
            if (dgvSpInDetail.Columns["selMaterial"] == null)//如果按钮列已经存在，则不能重复添加.
            {
                DataGridViewButtonColumn dgvBtnCol = new DataGridViewButtonColumn();
                dgvBtnCol.Name = "selMaterial";
                dgvBtnCol.HeaderText = "";
                dgvBtnCol.UseColumnTextForButtonValue = true;
                dgvBtnCol.Text = "…";
                dgvBtnCol.Width = 25;
                dgvSpInDetail.Columns.Insert(4, dgvBtnCol);
            }
            else dgvSpInDetail.Columns["selMaterial"].DisplayIndex = 4;
            

            //dgvSpInDetail.Columns["selMaterial"].Visible = false;
            
            //调用函数设置物资名称与规格型号是否可编辑，引用的物资不可编辑，手工添加的物资可编辑。.
            string[] sCols = new string[] { "material_name", "MATERIAL_SPEC", "MATERIAL_Code" };
            dgvSpInDetail.setDgvCellReadOnly("material_id", sCols);
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
                    string Material_id = dgvSpInDetail.Rows[e.RowIndex].Cells["Material_Id"].Value.ToString();
                    decimal count = Convert.ToDecimal(dgvSpInDetail.Rows[e.RowIndex].Cells["COUNT"].Value);
                    foreach (DataGridViewRow item in dgvOrderDetail.Rows)
                    {
                        if (item.Cells["Material_ID"].Value.ToString() == Material_id)
                        {
                            item.Cells["RECEIVECOUNT"].Value = count;
                        }
                    }
                }
            }
        }
        #region 明细数据添加维护的操作


        /// <summary>
        /// 单击选择按钮打开物资弹出框窗体选择物资的Id和名称.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSpInDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSpInDetail.Columns[e.ColumnIndex].Name == "selMaterial")
            {
                FrmSelectMaterial frm = new FrmSelectMaterial();
                frm.ShowDialog();

                if (frm.Selected && frm.Materials.Count > 0)
                {
                    InsertMaterialsToGridView(frm.Materials, e.RowIndex, true);
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
            string materialId = "";    //当前物资Id

            if (dgvSpInDetail.CurrentRow != null)
            {
                wareHouseId = cboWareHouse.SelectedValue.ToString();
                wareHousename = cboWareHouse.Text;
                materialId = dgvSpInDetail.CurrentRow.Cells["material_id"].Value.ToString();
                dgvSpInDetail.CurrentRow.Cells["stocksum"].Value = MaterialStockService.Instance.GetMaterialStock(shipId, materialId);

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
            string CURRENCYID = "";//当前仓库Id
            string CURRENCYCODE = "";//当前仓库Id 
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
        private void cboManufactory_SelectedValueChanged(object sender, EventArgs e)
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

        #region 物资入库单明细网格校验部分


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
                    MessageBoxEx.Show("订单编号不正确");
                    return false;
                }
                MaterialPurchaseOrderQueryParameter mpqp = new MaterialPurchaseOrderQueryParameter();
                mpqp.PURCHASE_ORDER_CODE = item;
                DataTable dt;
                if (!MaterialPurchaseOrderService.Instance.GetInfo(mpqp, out dt, out err))
                {
                    MessageBoxEx.Show(err);
                    return false;
                }
                if (dt.Rows.Count > 0)
                {
                    MaterialPurchaseOrder spo = MaterialPurchaseOrderService.Instance.getObject(dt.Rows[0]["PURCHASE_ORDERID"].ToString(), out err);
                    if (spo.STATE != 5)
                    {
                        MessageBoxEx.Show("该订单已经执行过入库操作,不可以再次使用此订单入库");
                        return false;
                    }
                }
                else
                {
                    MessageBoxEx.Show("订单信息不正确");
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

            if (dgvSpInDetail.HasEmptyVal("material_name") == true)
            {
                MessageBoxEx.Show("物资名称是必填内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        /// 物资入库明细信息添加.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string shipId = theMaterialIn.SHIP_ID;

           
            if (!dgvSpInDetail.HasEmptyVal("material_name"))
            {
                bindingSourceDetail.AddNew();//执行添加记录功能.
                //为som_in_detail_id列添加一个新的全球码号.
                dgvSpInDetail.CurrentRow.Cells["MATERIALOPERDETAIL_ID"].Value = Guid.NewGuid().ToString();
                dgvSpInDetail.CurrentRow.Cells["DEPOTOPERID"].Value = txtInMan.Tag;//给som_in_id赋值入库单信息主键值.
                dgvSpInDetail.CurrentRow.Cells["ship_id"].Value = shipId;//当前船舶Id
                dgvSpInDetail.CurrentRow.Cells["type_code"].Value = "到货";
            }
        }

        /// <summary>
        /// 物资入库明细信息消耗信息删除.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.
            string materialOrderCode = ""; //订单号.
            if (bindingSourceDetail.Current != null)
            {

                if (MessageBoxEx.Show("确定要删除吗？", "删除提示", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }

                //取要删除行的订单号（如果不是从订单引入的数据，那么为空）.
                materialOrderCode = dgvSpInDetail.CurrentRow.Cells["order_code"].Value.ToString();

                bindingSourceDetail.RemoveCurrent();
                bindingSourceDetail.EndEdit();
                DataTable dtb = (DataTable)bindingSourceDetail.DataSource;//从BindingSource组件中取得信息集放到DataTable中去.
                if (commonOpt.SaveFormData(dtb, "T_MATERIAL_DEPOT_OPERATION_DETAIL", 0, out err))
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
        /// 物资入库信息保存操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgSaveItem_Click(object sender, EventArgs e)
        {
            //isComplete = false;
            if (string.IsNullOrEmpty(ucDepartmentSelect1.GetId()))
            {
                MessageBoxEx.Show("请选择入库部门");
                return;
            }
            //***************数据校验*****************************************************************************
            if (this.validateDet() == false)
            {
                return;
            }
            if (saveInfor())
            {
                MessageBoxEx.Show("操作成功！", "提示");
                setBindingSourceDetail(theMaterialIn.GetId());
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
            //岸端,则状态为4,船端则状态为2;
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                txtLandChecker.Text = CommonOperation.ConstParameter.UserName;
                theMaterialIn.STATE = 4;
            }
            else
            {
                if (theMaterialIn.INSTORAGETYPE == 1)
                {
                    txtLandChecker.Text = "";
                    txtShipChecker.Text = CommonOperation.ConstParameter.UserName;
                    if (!StorageConfig.StorageChangeNeedLandCheck)
                        theMaterialIn.STATE = 4;
                    else
                        theMaterialIn.STATE = 2;
                }
                else {
                    txtLandChecker.Text = "";
                    txtShipChecker.Text = CommonOperation.ConstParameter.UserName;
                    if (!StorageConfig.StorageChangeNeedLandCheck)
                        theMaterialIn.STATE = 4;
                    else
                        theMaterialIn.STATE = 4;
                }
            }
            //***************数据校验*****************************************************************************
            if (string.IsNullOrEmpty(ucDepartmentSelect1.GetId()))
            {
                MessageBoxEx.Show("请选择入库部门");
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
            if (MessageBoxEx.Show("是否确认当前入库单信息？如果确认请点击【是】否则点击【否】！\r注意，如果确认则不允许再次编辑！", "确认框", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //***************数据操作*****************************************************************************
                //更新结果报告.
                if (saveInfor())
                {
                    MessageBoxEx.Show("操作成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (CommonOperation.ConstParameter.IsLandVersion)
                    {
                        decimal total = 0;
                        foreach (DataRow item in ((DataTable)dgvOrderDetail.DataSource).Rows)
                        {
                            MaterialPurchaseOrderDetail spod = MaterialPurchaseOrderDetailService.Instance.getObject(item);
                            if (!spod.Update(out err))
                            {
                                MessageBoxEx.Show("更新订单到货信息时发生错误,错误信息请参考:\r" + err);
                                return;
                            }
                            total += spod.PRICE;
                        }
                        spo.SENDDATE = DateTime.Now;
                        spo.TOTALPRICE = total;
                        spo.STATE = 8;
                        if (!spo.Update(out err))
                        {
                            MessageBoxEx.Show("更新订单状态时发生错误,错误信息请参考:\r" + err);
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
                //    if (theMaterialIn.STATE == 4 && StorageConfig.createMessage != null)
                //    {
                //        DataTable dtb;
                //        if (!SAPServiceOfMaterialAndMaterial.Instance.GetMaterialDepotInOperationToSAP(theMaterialIn.GetId(), out dtb, out err)
                //            || !StorageConfig.createMessage(theMaterialIn.SHIP_ID, theMaterialIn.OPERATION_DATE, theMaterialIn.CHECKDATE, theMaterialIn.GetId(), dtb, "1", "1", out err))
                //        {
                //            MessageBoxEx.Show("将变化数据发送给SAP时发生错误,需要重新审核,错误信息请参考:\r" + err);
                //            theMaterialIn.STATE = 2;
                //            theMaterialIn.Update(out err);
                //            return;
                //        }
                //        else
                //        {
                //            DataTable dtbInDetail = MaterialDepotOperationService.Instance.GetMaterialInDetail(theMaterialIn.GetId());//取得入库单明细信息的DataTable对象.
                //            foreach (DataRow item in dtbInDetail.Rows)
                //            {
                //                if (!MaterialPurchaseOrderDetailService.Instance.GoodsArrivalOperation(item["Material_Id"].ToString(), Convert.ToDecimal(item["COUNT"]), out err))
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
            if (dgvSpInDetail.Rows.Count > 0)
            {
                theMaterialIn.STATE = 1;
            }
            else
            {
                MessageBoxEx.Show("当前入库单不包含任何有效数据,无法提交审核.");
                return;
            }
            //***************数据校验*****************************************************************************
            if (string.IsNullOrEmpty(ucDepartmentSelect1.GetId()))
            {
                MessageBoxEx.Show("请选择入库部门");
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
            theMaterialIn.STATE = 3;
            if (CommonOperation.ConstParameter.IsLandVersion)
                txtLandChecker.Text = CommonOperation.ConstParameter.UserName;
            else
                txtShipChecker.Text = CommonOperation.ConstParameter.UserName;
            //***************数据校验*****************************************************************************
            if (string.IsNullOrEmpty(ucDepartmentSelect1.GetId()))
            {
                MessageBoxEx.Show("请选择入库部门");
                return;
            }
            if (this.validateDet() == false)
            {
                return;
            }
            OurMessageBox messagebox = new OurMessageBox("确定要打回入库操作吗？\r如果确认,请描述打回原因并点击[确定]按钮,否则点击[取消]按钮.",
                  "确认框", theMaterialIn.REMARK + "\r\n" + DateTime.Now.ToShortDateString() + "被 " + CommonOperation.ConstParameter.UserName + " 打回");
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

            if (string.IsNullOrEmpty(theMaterialIn.OPERATION_CODE)) theMaterialIn.OPERATION_CODE = StorageCommonService.Instance.GetSpareAndMaterialInOrOutCode(theMaterialIn.SHIP_ID);
            if (theMaterialIn.Update(out err))
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

            return commonOpt.SaveFormData(dtb, "T_MATERIAL_DEPOT_OPERATION_DETAIL", 0, out err);//保存数据.
        }

        /// <summary>
        /// 窗体关闭时对网格dgvSpInDetail的一些必填值进行校验并释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMaterialInEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            string err;
            if (this.IsButtonClose)
            {
                if (theMaterialIn.ISCOMPLETE == 0 && dgvSpInDetail.Rows.Count == 0)
                {
                    if (MessageBoxEx.Show("没有添加任何入库条目，请确认是否保存当前信息，\r保存请按【是】不保存请按【否】", "提示", MessageBoxButtons.YesNo,
                         MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        theMaterialIn.Delete(out err);
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
                            theMaterialIn.Delete(out err);
                        }
                    }
                } 
            }
            
            //dgvSpInDetail.SaveGridView("FrmMaterialInEdit.dgvSpInDetail");
            //if (CommonOperation.ConstParameter.IsLandVersion)
            //    dgvOrderDetail.SaveGridView("FrmMaterialInEdit.dgvOrderDetailLand");
            //else
            //    dgvOrderDetail.SaveGridView("FrmMaterialInEdit.dgvOrderDetailShip");
        }

        #endregion
        #endregion

        #region  窗体事件
        /// <summary>
        /// 依据订单入库
        /// </summary>      
        private void btnFromOrder_Click(object sender, EventArgs e)
        {
            if (orderCodeList.Count > 0)
            {
                MessageBoxEx.Show("只能导入一个订单");
                return;
            }
            if (applyCodeList.Count > 0)
            {
                MessageBoxEx.Show("已经导入了一个申请单，不能再导入订单！");
                return;
            }
            FrmMaterialPurchaseOrderSelect frm = new FrmMaterialPurchaseOrderSelect(shipId);
            frm.ShowDialog();
            if (frm.storageParameterList.Count != 0)
            {
                InsertMaterialsToGridView(frm.storageParameterList, dgvSpInDetail.Rows.Count, false);
                if (!this.IsEdit)
                {
                    inStorageType = 1;
                }
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
        /// 依据申请单入库
        /// </summary>       
        private void btnFromApply_Click(object sender, EventArgs e)
        {
            if (applyCodeList.Count > 0)
            {
                MessageBoxEx.Show("每个入库单只能导入一个申请单！");
                return;
            }
            if (orderCodeList.Count > 0)
            {
                MessageBoxEx.Show("已经导入了一个订单，不能再导入申请单！");
                return;
            }
            String errMessage = String.Empty;
            FrmMaterialApplySelect frm = new FrmMaterialApplySelect(shipId);
            frm.ShowDialog();
            frm.StartPosition = FormStartPosition.CenterScreen;
            if (frm.ApplyIdList.Count > 0)
            {
                applyCodeList.Add(frm.ApplyIdList[0]);
                InsertMaterialsToGridView(frm.StorageParameterList, dgvSpInDetail.Rows.Count, false);
                if (!this.IsEdit)
                {
                    inStorageType = 2;    
                }
            }           
            groupBox1.Visible = false;
            splitContainer1.Panel2Collapsed = true;
        }
        #endregion
    }
}