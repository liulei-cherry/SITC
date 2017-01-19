using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StorageManage.DataObject;
using CommonViewer.BaseControl;
using StorageManage.Services;
using BaseInfo.Objects;
using BaseInfo.DataAccess;
using CommonOperation.Functions;
using ItemsManage.Viewer;
using ItemsManage.Services;
using ItemsManage.DataObject;
using ItemsManage;
using CommonOperation.Interfaces;
using ShipMisZHJ_WorkFlow.Services;

namespace StorageManage.Viewer
{
    public partial class FrmMaterialPurchaseOrderEdit : CommonViewer.BaseForm.FormBase
    {

        #region 窗体变量
        private string orderID = "";
        private string PURCHASE_ORDERID = "";
        private MaterialPurchaseOrder spo = null;
        private DataRow drItem = null;
        private DataTable dtDetail = new DataTable();
        List<string> applyidList = new List<string>();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string STATE = "";
        /// <summary>
        /// 1=订单维护或审批， 2=单条或所有，快速生成订单，包含全部记录; 3=单条记录，某订单未全部到货，继续形成订单;4，合单，去掉已经订购的数量
        /// </summary>
        int functionCode = 1;
        string PURCHASE_ORDER_PERSON = "";
        #endregion

        #region 构造函数
        private FrmMaterialPurchaseOrderEdit()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 构造，功能1,维护或审批一个订单，传入订单id
        /// </summary>
        /// <param name="PURCHASE_ORDERID"></param>
        /// <param name="functionCode"></param>
        public FrmMaterialPurchaseOrderEdit(string orderID)
        {
            InitializeComponent();
            functionCode = 1;
            PURCHASE_ORDERID = orderID;
        }

        /// <summary>
        /// 构造.某一个申请单形成订单，功能
        /// </summary>
        /// <param name="PURCHASE_ORDERID"></param>
        /// <param name="functionCode"></param>
        public FrmMaterialPurchaseOrderEdit(string paramID, int paramFunctionCode)
        {
            InitializeComponent();
            functionCode = paramFunctionCode;
            orderID = paramID;
        }

        /// <summary>
        /// 构造.
        /// </summary>
        /// <param name="paramidList">物料申请单ID</param>
        /// <param name="functionCode">生成订单类型</param>
        public FrmMaterialPurchaseOrderEdit(List<string> paramidList, int paramFunctionCode)
        {
            InitializeComponent();
            functionCode = paramFunctionCode;
            applyidList = paramidList;
        }
        #endregion


        /// <summary>
        /// Laod事件
        /// </summary>     
        private void FrmMaterialPurchaseOrderEdit_Load(object sender, EventArgs e)
        {
            string err;
            if (!string.IsNullOrEmpty(PURCHASE_ORDERID))
            {
                DataTable dtItem;
                if (!MaterialPurchaseOrderService.Instance.GetInfo(PURCHASE_ORDERID, null, null, out dtItem, out err))
                {
                    MessageBoxEx.Show(err);
                    return;
                }
                drItem = dtItem.Rows[0];
                STATE = drItem["STATE"].ToString();
                PURCHASE_ORDER_PERSON = drItem["PURCHASE_ORDER_PERSON"].ToString();
                spo = MaterialPurchaseOrderService.Instance.getObject(PURCHASE_ORDERID, out err);
            }
            else
            {
                spo = new MaterialPurchaseOrder();
            }
            ucShipSelect1.ChangeSelectedState(false);
            ShowDataToForm();
            dgvDetail.SetDataGridViewNoSort();
            SetButtonsAndControls();
            if (functionCode == 2 || functionCode == 4)
                SetCreateOrder();
            else if (functionCode == 3)
                SetContinueOrder();
        }

        /// <summary>
        /// 创建新订单
        /// </summary>
        private void SetCreateOrder()
        {
            DataTable dtbApply;
            string err;
            if (!MaterialPurchaseApplyService.Instance.GetInfo(applyidList, null, null, null, null, CommonOperation.ConstParameter.MinDateTime, CommonOperation.ConstParameter.MaxDateTime, out dtbApply, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            ucShipSelect1.SelectedId(dtbApply.Rows[0]["SHIP_ID"].ToString());
            dtpPURCHASE_ORDER_DATE.Value = DateTime.Now;

            #region  20150107-wanhw-备注
            for (int i = 0; i < dtbApply.Rows.Count; i++)
            {
                if ((dtbApply.Rows[i]["REMARK"].ToString()+txtREMARK.Text).Length<txtREMARK.MaxLength)
                {
                    txtREMARK.Text += dtbApply.Rows[i]["REMARK"].ToString();
                }
            }
            #endregion

            DataTable dt = (DataTable)bindingSourceDetail.DataSource;

            foreach (string item in applyidList)
            {
                DataTable dtDetail;
                if (!MaterialPurchaseApplyDetailService.Instance.GetInfo(item, (functionCode != 4), out dtDetail, out err))
                {
                    MessageBoxEx.Show(err);
                    return;
                }
                foreach (DataRow drs in dtDetail.Rows)
                {
                    DataRow dr = dt.NewRow();
                    dr["MATERIAL_ID"] = drs["MATERIAL_ID"];
                    dr["MATERIAL_NAME"] = drs["MATERIAL_NAME"];
                    dr["MATERIAL_CODE"] = drs["MATERIAL_CODE"];
                    dr["UNIT_NAME"] = drs["UNIT_NAME"];
                    dr["MATERIAL_SPEC"] = drs["MATERIAL_SPEC"];
                    dr["REMARK"] = drs["REMARK"];
                    if (dtbApply.Rows[0]["STATE"].ToString() == "6")
                        dr["PURCHASECOUNT"] = drs["CONFIRMEDCOUNT"];
                    else
                        dr["PURCHASECOUNT"] = drs["APPLYCOUNT"];
                    dr["PURCHASE_APPLYID"] = item;
                    dr["ORDERNUM"] = dt.Rows.Count + 1;
                    dt.Rows.Add(dr);
                }
            }
            bindingSourceDetail.DataSource = dt;
            bindingSourceDetail.Sort = " ORDERNUM ASC";
        }

        /// <summary>
        /// 继续未完成订单.
        /// </summary>
        private void SetContinueOrder()
        {
            string err;
            DataTable dtOrder;
            if (!MaterialPurchaseOrderService.Instance.GetInfo(orderID, null, null, out dtOrder, out err))//取得信息的DataTable对象.
            {
                MessageBoxEx.Show(err);
                return;
            }
            ucShipSelect1.SelectedId(dtOrder.Rows[0]["SHIP_ID"].ToString());
            dtpPURCHASE_ORDER_DATE.Value = DateTime.Now;

            #region  20150107-wanhw-备注
            for (int i = 0; i < dtOrder.Rows.Count; i++)
            {
                if ((dtOrder.Rows[i]["REMARK"].ToString() + txtREMARK.Text).Length < txtREMARK.MaxLength)
                {
                    txtREMARK.Text += dtOrder.Rows[i]["REMARK"].ToString();
                }
            }
            #endregion

            ucManufacturerSelect1.SelectedId(dtOrder.Rows[0]["SUPPLIER_ID"].ToString());
            ucPortSelect1.SelectedText(dtOrder.Rows[0]["SENDPORT"].ToString());
            ucCurrencySelect1.SelectedId(dtOrder.Rows[0]["CURRENCYID"].ToString());
            DataTable dtDetail;
            if (!MaterialPurchaseOrderDetailService.Instance.GetInfo(orderID, out dtDetail, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            DataTable dt = (DataTable)bindingSourceDetail.DataSource;
            foreach (DataRow drs in dtDetail.Rows)
            {
                if (Convert.ToDecimal(drs["PURCHASECOUNT"]) <= Convert.ToDecimal(drs["RECEIVECOUNT"]))
                    continue;
                DataRow dr = dt.NewRow();
                dr["MATERIAL_ID"] = drs["MATERIAL_ID"];
                dr["MATERIAL_NAME"] = drs["MATERIAL_NAME"];
                dr["MATERIAL_CODE"] = drs["MATERIAL_CODE"];
                dr["UNIT_NAME"] = drs["UNIT_NAME"];
                dr["MATERIAL_SPEC"] = drs["MATERIAL_SPEC"];
                dr["REMARK"] = drs["REMARK"];
                dr["PURCHASECOUNT"] = Convert.ToDecimal(drs["PURCHASECOUNT"]) - Convert.ToDecimal(drs["RECEIVECOUNT"]);
                dr["ORDERNUM"] = drs["ORDERNUM"];
                dt.Rows.Add(dr);
            }
            bindingSourceDetail.DataSource = dt;
        }
        /// <summary>
        /// 设置控件可见权限.
        /// </summary>
        private void SetButtonsAndControls()
        {
            bool isAddOrEdit = (PURCHASE_ORDER_PERSON == CommonOperation.ConstParameter.UserName && (STATE == "0" || STATE == "4")) || string.IsNullOrEmpty(PURCHASE_ORDERID);
            bool isExamine = false;
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务主管.
                {
                    isAddOrEdit = isAddOrEdit || (PURCHASE_ORDER_PERSON == CommonOperation.ConstParameter.UserName && STATE == "1");
                    isExamine = STATE == "1" && PURCHASE_ORDER_PERSON != CommonOperation.ConstParameter.UserName;
                }
                else if ("机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务经理.
                {
                    isAddOrEdit = isAddOrEdit || (PURCHASE_ORDER_PERSON == CommonOperation.ConstParameter.UserName && (STATE == "2"));
                    isExamine = (STATE == "2") && PURCHASE_ORDER_PERSON != CommonOperation.ConstParameter.UserName;
                }
                else if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是船管总经理.
                {
                    isAddOrEdit = isAddOrEdit || (PURCHASE_ORDER_PERSON == CommonOperation.ConstParameter.UserName && STATE == "3");
                    isExamine = STATE == "3" && PURCHASE_ORDER_PERSON != CommonOperation.ConstParameter.UserName;
                }
                btn_Agree.Visible = isExamine;
                btn_disgree.Visible = isExamine;
                btnPass.Visible = isAddOrEdit || isExamine;
            }
            btnSubmit.Visible = isAddOrEdit && !btn_Agree.Visible;
            btnSave.Visible = isAddOrEdit || isExamine || STATE == "5" || STATE == "6" || STATE == "7" || STATE == "8";
            dgvDetail.Columns["RECEIVEREMARK"].ReadOnly = !(STATE == "5" || STATE == "6" || STATE == "7" || STATE == "8");
            btnDeleteDetail.Visible = isAddOrEdit || isExamine;
            btnAddDetail.Visible = isAddOrEdit || isExamine;
            dgvDetail.Enabled = isAddOrEdit || isExamine || STATE == "5" || STATE == "6" || STATE == "7" || STATE == "8";
            if (!(isAddOrEdit || isExamine))
                dgvDetail.Columns.Remove("selmaterial");

            dgvDetail.Columns["MATERIAL_CODE"].ReadOnly = !(isAddOrEdit || isExamine);
            dgvDetail.Columns["MATERIAL_SPEC"].ReadOnly = !(isAddOrEdit || isExamine);
            dgvDetail.Columns["PURCHASECOUNT"].ReadOnly = !(isAddOrEdit || isExamine);
            dgvDetail.Columns["PRICE"].ReadOnly = !(isAddOrEdit || isExamine);
            dgvDetail.Columns["REMARK"].ReadOnly = !(isAddOrEdit || isExamine);
            dgvDetail.Columns["ORDERNUM"].ReadOnly = false;
            dtpPURCHASE_ORDER_DATE.Enabled = isAddOrEdit || isExamine;
            ucShipSelect1.Enabled = isAddOrEdit;
            txtREMARK.Enabled = isAddOrEdit || isExamine;
            nudTOTALPRICE.Enabled = isAddOrEdit || isExamine;
            ucPortSelect1.Enabled = isAddOrEdit || isExamine;
            ucManufacturerSelect1.Enabled = isAddOrEdit || isExamine;
            ucCurrencySelect1.Enabled = isAddOrEdit || isExamine;

            foreach (DataGridViewColumn item in dgvDetail.Columns)
                if (item.ReadOnly)
                    item.DefaultCellStyle.BackColor = Color.Linen;
        }
        /// <summary>
        /// 显示数据到控件上.
        /// </summary>
        private void ShowDataToForm()
        {
            if (string.IsNullOrEmpty(PURCHASE_ORDERID))
            {
                txtPURCHASE_ORDER_CODE.Text = "";
                txtPURCHASE_ORDER_PERSON.Text = CommonOperation.ConstParameter.UserName;
                dtpPURCHASE_ORDER_DATE.Value = DateTime.Now;
            }
            else
            {
                ucShipSelect1.SelectedId(drItem["SHIP_ID"].ToString());
                ucCurrencySelect1.SelectedId(drItem["CURRENCYID"].ToString());
                txtPURCHASE_ORDER_CODE.Text = drItem["PURCHASE_ORDER_CODE"].ToString();
                txtPURCHASE_ORDER_PERSON.Text = drItem["PURCHASE_ORDER_PERSON"].ToString();
                ucManufacturerSelect1.SelectedId(drItem["SUPPLIER_ID"].ToString());
                dtpPURCHASE_ORDER_DATE.Value = Convert.ToDateTime(drItem["PURCHASE_ORDER_DATE"]);
                ucPortSelect1.SelectedText(drItem["SENDPORT"].ToString());
                nudTOTALPRICE.Value = Convert.ToDecimal(drItem["TOTALPRICE"]);
                txtSENDDATE.Text = drItem["SENDDATE"].ToString();
                txtLANDCHECKER.Text = drItem["LANDCHECKER"].ToString();
                txtCHECKDATE.Text = drItem["CHECKDATE"].ToString();
                txtREMARK.Text = drItem["REMARK"].ToString();
            }
            string err;
            if (!MaterialPurchaseOrderDetailService.Instance.GetInfo(PURCHASE_ORDERID, out dtDetail, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            bindingSourceDetail.DataSource = dtDetail;
            dgvDetail.DataSource = bindingSourceDetail;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("ORDERNUM", "序号");
            dic.Add("MATERIAL_NAME", "物资");
            dic.Add("MATERIAL_CODE", "物资编号");
            dic.Add("MATERIAL_SPEC", "采购号或规格");
            dic.Add("UNIT_NAME", "单位");
            dic.Add("PURCHASECOUNT", "采购数量");
            dic.Add("RECEIVECOUNT", "到货数量");
            dic.Add("RECEIVEREMARK", "评价");
            //dic.Add("PRICE", "采购金额");
            dic.Add("REMARK", "备注");
            dgvDetail.SetDgvGridColumns(dic, "mulSelect");

            //给dgvDetail加一个列按钮列用于打开弹出对话框选择物资信息.
            if (dgvDetail.Columns["selMaterial"] != null)//如果按钮列已经存在，则不能重复添加.
                dgvDetail.Columns.Remove("selmaterial");
            DataGridViewButtonColumn dgvBtnCol = new DataGridViewButtonColumn();
            dgvBtnCol.Name = "selMaterial";
            dgvBtnCol.HeaderText = "";
            dgvBtnCol.UseColumnTextForButtonValue = true;
            dgvBtnCol.Text = "…";
            dgvBtnCol.Width = 25;
            dgvDetail.Columns.Insert(4, dgvBtnCol);
            foreach (DataGridViewColumn item in dgvDetail.Columns)
                item.ReadOnly = true;
        }

        /// <summary>
        /// 从指定的位置往下连续加入几行物资申请信息.
        /// </summary>
        /// <param name="sporeids"></param>
        /// <param name="index">从第几行开始加入，如果从第一行加入，录入0，如果从最后一行加入，录入当前的总行数</param>
        /// <param name="replaceRow">是否要覆盖当前指定行，如果true，则index行会被覆盖掉</param>
        private void InsertMaterialsToGridView(List<StorageParameter> sporeids, int index, bool isFuGai)
        {
            if (sporeids.Count == 0)
            {
                MessageBoxEx.Show("添加物资申请条目信息时，传入的物资条目为0！", "错误提示");
                return;
            }
            List<MaterialInfo> sporeInfoList = new List<MaterialInfo>();
            string err;
            DataTable dt = (DataTable)bindingSourceDetail.DataSource;
            int tempIndex = dt.Select(" MATERIAL_ID is not null").Length + 1;
            foreach (StorageParameter sporeTemp in sporeids)
            {
                DataRow[] drs = dt.Select("MATERIAL_ID='" + sporeTemp.ItemId + "'");
                MaterialInfo spore = MaterialInfoService.Instance.getObject(sporeTemp.ItemId, out err);

                if (drs.Length > 0)
                {
                    sporeInfoList.Add(spore);
                    continue;
                }

                if (isFuGai)
                {
                    isFuGai = false;
                }
                else
                {
                    bindingSourceDetail.AddNew();//执行添加记录功能.
                }

                dgvDetail.CurrentRow.Cells["MATERIAL_ID"].Value = spore.MATERIAL_ID;
                dgvDetail.CurrentRow.Cells["MATERIAL_NAME"].Value = spore.MATERIAL_NAME;
                dgvDetail.CurrentRow.Cells["MATERIAL_CODE"].Value = spore.MATERIAL_CODE;
                dgvDetail.CurrentRow.Cells["MATERIAL_SPEC"].Value = spore.MATERIAL_SPEC;
                dgvDetail.CurrentRow.Cells["PURCHASECOUNT"].Value = 1;
                dgvDetail.CurrentRow.Cells["unit_name"].Value = spore.UNIT_NAME;
                dgvDetail.CurrentRow.Cells["ORDERNUM"].Value = tempIndex++;
            }

            if (sporeInfoList.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("以下选择的物资在该申请单里已存在");
                sb.AppendLine("物资名称 // 规格");
                foreach (MaterialInfo item in sporeInfoList)
                    sb.AppendLine(item.MATERIAL_NAME + " // " + item.MATERIAL_SPEC);
                MessageBoxEx.Show(sb.ToString());
            }
        }
        /// <summary>
        /// 单击选择按钮打开物资弹出框窗体选择物资的Id和名称.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //选物资.
            if (dgvDetail.Columns[e.ColumnIndex].Name == "selMaterial")
            {
                FrmSelectMaterial frm = new FrmSelectMaterial();
                frm.ShowDialog();
                if (frm.Selected && frm.Materials.Count > 0)
                {
                    InsertMaterialsToGridView(frm.Materials, dgvDetail.CurrentRow.Index, true);
                }
            }
            this.bindingSourceDetail.Sort = " ORDERNUM ASC";
        }
        /// <summary>
        /// form验证.
        /// </summary>
        /// <returns></returns>
        private bool CheckForm()
        {
            if (string.IsNullOrEmpty(txtPURCHASE_ORDER_PERSON.Text.Trim()))
            {
                MessageBoxEx.Show("申请人不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpPURCHASE_ORDER_DATE.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(ucCurrencySelect1.GetId()))
            {
                MessageBoxEx.Show("货币不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ucCurrencySelect1.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(nudTOTALPRICE.Value.ToString()))
            {
                MessageBoxEx.Show("总价不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudTOTALPRICE.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dtpPURCHASE_ORDER_DATE.Value.ToString()))
            {
                MessageBoxEx.Show("发起日期不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpPURCHASE_ORDER_DATE.Focus();
                return false;
            }
            if (CommonOperation.ConstParameter.IsLandVersion && string.IsNullOrEmpty(ucShipSelect1.GetId()))
            {
                MessageBoxEx.Show("船舶不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ucShipSelect1.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(ucManufacturerSelect1.GetId()))
            {
                MessageBoxEx.Show("供应商不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ucManufacturerSelect1.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(ucPortSelect1.GetId()))
            {
                MessageBoxEx.Show("送货港口不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ucPortSelect1.Focus();
                return false;
            }
            if (dgvDetail.Rows.Count == 0)
            {
                MessageBoxEx.Show("订单明细不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            for (int i = 0; i < dgvDetail.Rows.Count; i++)
            {
                DataGridViewRow item = dgvDetail.Rows[i];
                if (string.IsNullOrEmpty(item.Cells["MATERIAL_ID"].Value.ToString()))
                {
                    MessageBoxEx.Show("第" + (i + 1) + "行的物资不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (string.IsNullOrEmpty(item.Cells["PURCHASECOUNT"].Value.ToString()))
                {
                    MessageBoxEx.Show("第" + (i + 1) + "行的采购数量不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //Convert.ToDecimal(item.Cells["PURCHASECOUNT"].Value) <= 0
                #region  wanhw-2014-12-03-采购数量为"0",该为能通过，可注明理由。
                if (Convert.ToDecimal(item.Cells["PURCHASECOUNT"].Value) < 0)
                {
                    MessageBoxEx.Show("第" + (i + 1) + "行的采购数量不能小于零", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                #endregion
                //if (string.IsNullOrEmpty(item.Cells["PRICE"].Value.ToString()))
                //{
                //    MessageBoxEx.Show("第" + (i + 1) + "行的采购金额不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return false;
                //}
            }
            return true;
        }

        /// <summary>
        /// 从表单取得数据,并校验.
        /// </summary>
        /// <returns></returns>
        private bool UpdateObjectFrom()
        {
            spo.PURCHASE_ORDER_PERSON = txtPURCHASE_ORDER_PERSON.Text.Trim();
            spo.SHIP_ID = ucShipSelect1.GetId();
            spo.CURRENCYID = ucCurrencySelect1.GetId();
            spo.SUPPLIER_ID = ucManufacturerSelect1.GetId();
            spo.TOTALPRICE = nudTOTALPRICE.Value;
            spo.PURCHASE_ORDER_DATE = dtpPURCHASE_ORDER_DATE.Value;
            spo.SENDPORT = ucPortSelect1.GetText();
            spo.REMARK = txtREMARK.Text.Trim();
            return true;
        }

        /// <summary>
        /// 保存函数.
        /// </summary>
        /// <returns></returns>
        private bool SaveFunction()
        {
            string err;
            using (TransactionClass tc = new TransactionClass())
            {
                if (string.IsNullOrEmpty(spo.PURCHASE_ORDER_CODE))
                    spo.PURCHASE_ORDER_CODE = MaterialPurchaseOrderService.Instance.GetPurchaseOrderCode(ucShipSelect1.GetId());
                spo.Update(out err);
                DataTable dt = (DataTable)bindingSourceDetail.DataSource;
                bindingSourceDetail.EndEdit();
                foreach (DataRow item in dt.Rows)
                {
                    if (item.RowState == DataRowState.Added)
                    {
                        if (string.IsNullOrEmpty(item["PURCHASE_ORDERID"].ToString()))
                            item["PURCHASE_ORDERID"] = spo.PURCHASE_ORDERID;
                        if (string.IsNullOrEmpty(item["PURCHASE_ORDER_DETAIL_ID"].ToString()))
                            item["PURCHASE_ORDER_DETAIL_ID"] = Guid.NewGuid().ToString();
                        item.EndEdit();
                    }
                }
                dbOperation.SaveFormData(((DataTable)bindingSourceDetail.DataSource), "T_MATERIAL_PURCHASE_ORDER_DETAIL", 0, out err);

                #region 屏蔽它，是因为假事务对查询操作执行有问题，放到事务提交后执行 2014年5月19日 徐正本
                //if (functionCode == 4)
                //{
                //    //变更询价单状态为已生成订单
                //    if (!MaterailEnquiryService.Instance.ChangeEnquiryState(applyidList[0], out errMessage))
                //    {

                //        MessageBox.Show("询价单状态更改失败！");
                //    }
                //}
                //else
                //{
                //    //变更申请单状态为“订购”
                //    foreach (string item in applyidList)
                //    {
                //        MaterialPurchaseApply obj = MaterialPurchaseApplyService.Instance.getObject(item, out err);
                //        obj.STATE = 9;
                //        obj.Update(out err);
                //    }
                //}
                //if (spo.STATE == 5)
                //{
                //    List<string> lstPurchaseEnquiryID = new List<string>();
                //    foreach (DataRow item in ((DataTable)bindingSourceDetail.DataSource).Rows)
                //    {
                //        if (!string.IsNullOrEmpty(item["PURCHASE_APPLYID"].ToString())
                //            &&
                //            !lstPurchaseEnquiryID.Contains(item["PURCHASE_APPLYID"].ToString()))
                //        {
                //            lstPurchaseEnquiryID.Add(item["PURCHASE_APPLYID"].ToString());
                //        }
                //    }
                //    //变更通过询价的申请单状态.
                //    if (!MaterailEnquiryService.Instance.UpdateMaterialPurchaseApply(lstPurchaseEnquiryID, out errMessage))
                //    {
                //        MessageBox.Show("申请单状态更改失败！");
                //    }
                //}
                #endregion
                tc.CommitTransaction();
                if (!MaterialPurchaseApplyService.Instance.ResetApplicationsOrderState(applyidList, out err))
                {
                    MessageBox.Show(err, "申请单状态更改失败");
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 船舶控件事件.
        /// </summary>
        /// <param name="theSelectedObject"></param>
        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            if (dgvDetail.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(PURCHASE_ORDERID))
                {
                    string err;
                    if (!MaterialPurchaseOrderDetailService.Instance.DeleteByPurchaseOrderID(PURCHASE_ORDERID, out err))
                    {
                        MessageBoxEx.Show(err);
                        return;
                    }
                }
                DataTable dtbDetail = (DataTable)bindingSourceDetail.DataSource;
                dtbDetail.Rows.Clear();
                bindingSourceDetail.DataSource = dtbDetail;
                dgvDetail.DataSource = bindingSourceDetail;
            }
        }
        /// <summary>
        /// 保存按钮事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!UpdateObjectFrom())
                return;
            if (SaveFunction())
            {
                MessageBoxEx.Show("保存成功", "提示");
                this.Close();
            }
        }
        /// <summary>
        /// 完成.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string err;
            if (AgreeRemarkHasErr()) return;
            if (!CheckForm()) return;
            if (MessageBoxEx.Show("是否提交当前订单信息，进入审批流程？", "提示信息", MessageBoxButtons.YesNo,
MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
== System.Windows.Forms.DialogResult.No) return;

            if (!UpdateObjectFrom())
                return;
            spo.CHECKDATE = DateTime.MinValue;
            if (CommonOperation.ConstParameter.IsLandVersion)//是岸端.
            {
                if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务主管.
                {
                    spo.STATE = 2;
                    spo.LANDCHECKER = CommonOperation.ConstParameter.UserName;
                    spo.CHECKDATE = DateTime.Now;
                }
                else if ("机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务经理.
                {
                    spo.STATE = 3;
                    spo.LANDCHECKER = CommonOperation.ConstParameter.UserName;
                    spo.CHECKDATE = DateTime.Now;
                }
                else if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是船管总经理.
                {
                    spo.STATE = 5;
                    spo.LANDCHECKER = CommonOperation.ConstParameter.UserName;
                    spo.CHECKDATE = DateTime.Now;
                }
                else
                {
                    spo.STATE = 1;
                }
            }
            spo.ISCOMPLETE = 1;
            if (SaveFunction())
            {
                T_WorkFlowService.Instance.AgreeBusiness(spo.SHIP_ID, spo.GetId(), "订单审核流程", false, out err);
                MessageBoxEx.Show("保存成功", "提示");
                this.Close();
            }
        }

        /// <summary>
        /// 添加明细.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ucShipSelect1.GetId()))
            {
                MessageBoxEx.Show("请先选择船舶", "提示");
                return;
            }
            if (!dgvDetail.HasEmptyVal("MATERIAL_NAME"))
            {
                bindingSourceDetail.AddNew();
            }
        }
        /// <summary>
        /// 删除明细.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteDetail_Click(object sender, EventArgs e)
        {
            List<string> allIds = new List<string>();
            List<int> allDeleteRowIndex = new List<int>();
            dgvDetail.EndEdit();
            //先判断，是否多选，如果多选，则直接按照多选删除，提示删除多少行
            foreach (DataGridViewRow dgvr in dgvDetail.Rows)
            {
                if (dgvr.Cells["mulSelect"].Value != null && dgvr.Cells["mulSelect"].Value.ToString().ToLower() == "true")
                {
                    allDeleteRowIndex.Add(dgvr.Index);
                }
            }
            if (allDeleteRowIndex.Count > 0)
            {
                if (MessageBoxEx.Show("是否删除选中的" + allDeleteRowIndex.Count + "条数据？", "提示操作", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    for (int i = allDeleteRowIndex.Count - 1; i >= 0; i--)
                        bindingSourceDetail.RemoveAt(allDeleteRowIndex[i]);
                }
                return;
            }
            //否则 判断是否选择当前行
            else if (dgvDetail.CurrentRow != null)
            {
                if (MessageBoxEx.Show("是否删除当前选中的数据？", "提示操作", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    bindingSourceDetail.RemoveCurrent();
                }
            }
            else
            {
                MessageBoxEx.Show("未选中任何行!");
                return;
            }

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

        private void btnBdFiles_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(spo.GetId()))
            {
                if (!UpdateObjectFrom())
                    return;
                if (!SaveFunction())
                    return;
            }
            if (!string.IsNullOrEmpty(spo.GetId()))
            {
                FileOperation.FileBoundingOperation.Instance.FileBoundCheck(spo.GetId(), spo.PURCHASE_ORDER_CODE,
                 CommonOperation.Enum.FileBoundingTypes.ITEMSORDER, spo.SHIP_ID);
                FileOperation.FileBoundingOperation.Instance.FileBoundOperation();
            }
        }

        /// <summary>
        /// 提交上级
        /// </summary>
        private void btn_Agree_Click(object sender, EventArgs e)
        {
            if (AgreeRemarkHasErr()) return;
            Agree(false);
        }

        /// <summary>
        /// 不提交上级直接通过.
        /// </summary>
        private void btnPass_Click(object sender, EventArgs e)
        {
            if (AgreeRemarkHasErr()) return;
            Agree(true);
        }
        private bool AgreeRemarkHasErr()
        {
            if (txtREMARK.Text.Trim().Contains("不同意"))
            {
                MessageBoxEx.Show("备注内容不能包含'不同意'", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtREMARK.Focus();
                return true;
            }
            return false;
        }
        private void Agree(bool toEnd)
        {
            string err;
            if (!CheckForm()) return;
            string sOpinion = toEnd ? "同意" : "同意并审核完毕";
            if (MessageBoxEx.Show("是否" + sOpinion + "本订单？", "提示信息", MessageBoxButtons.YesNo,
MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
== System.Windows.Forms.DialogResult.No) return;

            if (!UpdateObjectFrom())
                return;

            if (SaveFunction())
            {
                MessageBoxEx.Show("保存成功", "提示");
                RemindService.Instance.CreateRemindOnce(5, spo.SHIP_ID, spo.PURCHASE_ORDERID);
                int state = T_WorkFlowService.Instance.AgreeBusiness(spo.SHIP_ID, spo.GetId(), "订单审核流程", toEnd, out err, sOpinion);

                switch (state)
                {
                    case 3:
                        spo.STATE = 5;
                        break;
                    case 1:
                        switch (CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)
                        {
                            case "机务主管岗位":
                                spo.STATE = 2;
                                break;
                            case "机务经理岗位":
                                spo.STATE = 3;
                                break;
                        }
                        break;
                    default:
                        MessageBoxEx.Show("保存失败" + err, "提示");
                        return;
                }
                spo.LANDCHECKER = CommonOperation.ConstParameter.UserName;
                spo.CHECKDATE = DateTime.Now;
                spo.ISCOMPLETE = 1;
                spo.Update(out err);
                this.Close();
            }
        }

        private void DisAgree()
        {
            string err;
            if (!CheckForm()) return;
            if (MessageBoxEx.Show("是否打回本订单？", "提示信息", MessageBoxButtons.YesNo,
MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
== System.Windows.Forms.DialogResult.No) return;

            if (!UpdateObjectFrom())
                return;

            if (SaveFunction())
            {
                MessageBoxEx.Show("保存成功", "提示");
                RemindService.Instance.CreateRemindOnce(5, spo.SHIP_ID, spo.PURCHASE_ORDERID);
                int state = T_WorkFlowService.Instance.RejectBusiness(spo.SHIP_ID, spo.GetId(), "订单审核流程", false, out err, "不同意 " + txtREMARK.Text);

                switch (state)
                {
                    case 2:
                        switch (CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)
                        {
                            case "机务经理岗位":
                                spo.STATE = 1;
                                break;
                            case "总经理岗位":
                                spo.STATE = 2;
                                break;
                        }
                        break;
                    default:
                        MessageBoxEx.Show("保存失败" + err, "提示");
                        return;
                }
                spo.LANDCHECKER = CommonOperation.ConstParameter.UserName;
                spo.CHECKDATE = DateTime.Now;
                spo.ISCOMPLETE = 1;
                spo.Update(out err);
                this.Close();
            }

        }
        private void btn_disgree_Click(object sender, EventArgs e)
        {
            DisAgree();
        }
    }
}
