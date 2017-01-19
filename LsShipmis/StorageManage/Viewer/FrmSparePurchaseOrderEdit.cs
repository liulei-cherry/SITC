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
    public partial class FrmSparePurchaseOrderEdit : CommonViewer.BaseForm.FormBase
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmSparePurchaseOrderEdit instance = new FrmSparePurchaseOrderEdit();
        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmSparePurchaseOrderEdit Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmSparePurchaseOrderEdit.instance = new FrmSparePurchaseOrderEdit();
                }

                return FrmSparePurchaseOrderEdit.instance;
            }
        }
        private FrmSparePurchaseOrderEdit()
        {
            InitializeComponent();
        }
        #endregion
        private string orderID = "";
        private string PURCHASE_ORDERID = "";
        private SparePurchaseOrder spo = null;
        private DataRow drItem = null;
        private DataTable dtDetail = new DataTable();
        List<string> applyidList = new List<string>();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();

        string STATE = "";
        /// <summary>
        /// 1=订单维护或审批，2=快速生成订单; 3=继续订单;注意，备件没有合单
        /// </summary>
        int functionCode = 1;
        string PURCHASE_ORDER_PERSON = "";
        /// <summary>
        /// 构造.
        /// </summary>
        public FrmSparePurchaseOrderEdit(string orderID)
        {
            InitializeComponent();
            functionCode = 1;
            PURCHASE_ORDERID = orderID;
        }
        /// <summary>
        /// 构造.
        /// </summary>
        public FrmSparePurchaseOrderEdit(string paramID, int paramFunctionCode)
        {
            InitializeComponent();
            functionCode = paramFunctionCode;

            if (functionCode == 2)
                applyidList.Add(paramID);
            else if (functionCode == 3)
                orderID = paramID;//xuzb 2014-8-25 原来是applyidList.Add(paramID);有问题 

        }
        /// <summary>
        /// 构造.
        /// </summary>
        public FrmSparePurchaseOrderEdit(List<string> paramidList, int paramFunctionCode)
        {
            InitializeComponent();
            functionCode = paramFunctionCode;

            if (functionCode == 2)
                applyidList = paramidList;
        }
        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSparePurchaseOrderEdit_Load(object sender, EventArgs e)
        {
            string err;
            if (!string.IsNullOrEmpty(PURCHASE_ORDERID))
            {
                DataTable dtItem;
                if (!SparePurchaseOrderService.Instance.GetInfo(PURCHASE_ORDERID, null, null, out dtItem, out err))
                {
                    MessageBoxEx.Show(err);
                    return;
                }
                drItem = dtItem.Rows[0];
                STATE = drItem["STATE"].ToString();
                PURCHASE_ORDER_PERSON = drItem["PURCHASE_ORDER_PERSON"].ToString();
                spo = SparePurchaseOrderService.Instance.getObject(PURCHASE_ORDERID, out err);
            }
            else
            {
                spo = new SparePurchaseOrder();
            }
            ucShipSelect1.ChangeSelectedState(false);
            ShowDataToForm();
            SetButtonsAndControls();
            if (functionCode == 2)
                SetCreateOrder();
            else if (functionCode == 3)
                SetContinueOrder();
        }
        /// <summary>
        /// 快速生成订单.
        /// </summary>
        private void SetCreateOrder()
        {
            DataTable dtbApply = SparePurchaseApplyService.Instance.GetInfo(applyidList, null, null, null, null);//取得信息的DataTable对象.
            ucShipSelect1.SelectedId(dtbApply.Rows[0]["SHIP_ID"].ToString());
            dtpPURCHASE_ORDER_DATE.Value = DateTime.Now;

            #region  20150107-wanhw-备注
            for (int i = 0; i < dtbApply.Rows.Count; i++)
            {
                if ((dtbApply.Rows[i]["REMARK"].ToString() + txtREMARK.Text).Length < txtREMARK.MaxLength)
                {
                    txtREMARK.Text += dtbApply.Rows[i]["REMARK"].ToString();
                }
            }
            #endregion

            ucComponentSelect1.SelectedId(dtbApply.Rows[0]["COMPONENT_UNIT_ID"].ToString());
            DataTable dt = (DataTable)bindingSourceDetail.DataSource;
            foreach (string item in applyidList)
            {
                DataTable dtDetail;
                string err;
                if (!SparePurchaseApplyDetailService.Instance.GetInfo(item, out dtDetail, out err))
                {
                    MessageBoxEx.Show(err);
                    return;
                }
                foreach (DataRow drs in dtDetail.Rows)
                {
                    DataRow dr = dt.NewRow();
                    dr["COMPONENT_UNIT_ID"] = drs["COMPONENT_UNIT_ID"];
                    dr["SPARE_ID"] = drs["SPARE_ID"];
                    dr["SPARE_NAME"] = drs["SPARE_NAME"];
                    dr["PARTNUMBER"] = drs["PARTNUMBER"];
                    dr["UNIT_NAME"] = drs["UNIT_NAME"];
                    dr["REMARK"] = drs["REMARK"];
                    if (dtbApply.Rows[0]["STATE"].ToString() == "6")
                        dr["PURCHASECOUNT"] = drs["CONFIRMEDCOUNT"];
                    else
                        dr["PURCHASECOUNT"] = drs["APPLYCOUNT"];
                    dr["PURCHASE_APPLYID"] = item; 
                    dt.Rows.Add(dr);
                }
            }
            bindingSourceDetail.DataSource = dt;
        }
        /// <summary>
        /// 继续未完成订单.
        /// </summary>
        private void SetContinueOrder()
        {
            string err;
            DataTable dtOrder;
            if (!SparePurchaseOrderService.Instance.GetInfo(orderID, null, null, out dtOrder, out err))//取得信息的DataTable对象.
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
            ucComponentSelect1.SelectedId(dtOrder.Rows[0]["COMPONENT_UNIT_ID"].ToString());
            DataTable dtDetail;
            if (!SparePurchaseOrderDetailService.Instance.GetInfo(orderID, out dtDetail, out err))
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
                dr["COMPONENT_UNIT_ID"] = drs["COMPONENT_UNIT_ID"];
                dr["SPARE_ID"] = drs["SPARE_ID"];
                dr["SPARE_NAME"] = drs["SPARE_NAME"];
                dr["UNIT_NAME"] = drs["UNIT_NAME"];
                dr["REMARK"] = drs["REMARK"];
                dr["PARTNUMBER"] = drs["PARTNUMBER"];
                dr["PURCHASECOUNT"] = Convert.ToDecimal(drs["PURCHASECOUNT"]) - Convert.ToDecimal(drs["RECEIVECOUNT"]);

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
                btnPass.Visible = isAddOrEdit || isExamine;
                btn_Agree.Visible = isExamine;
                btn_disgree.Visible = isExamine;
            }

            btnSubmit.Visible = isAddOrEdit;
            btnSave.Visible = isAddOrEdit || isExamine || STATE == "5" || STATE == "6" || STATE == "7" || STATE == "8";
            dgvDetail.Columns["RECEIVEREMARK"].ReadOnly = !(STATE == "5" || STATE == "6" || STATE == "7" || STATE == "8");
            btnDeleteDetail.Visible = isAddOrEdit || isExamine;
            btnAddDetail.Visible = isAddOrEdit || isExamine;
            dgvDetail.Enabled = isAddOrEdit || isExamine || STATE == "5" || STATE == "6" || STATE == "7" || STATE == "8";
            if (!(isAddOrEdit || isExamine))
                dgvDetail.Columns.Remove("selspare");

            dgvDetail.Columns["PARTNUMBER"].ReadOnly = !(isAddOrEdit || isExamine);
            dgvDetail.Columns["PURCHASECOUNT"].ReadOnly = !(isAddOrEdit || isExamine);
            dgvDetail.Columns["PRICE"].ReadOnly = !(isAddOrEdit || isExamine);
            dgvDetail.Columns["REMARK"].ReadOnly = !(isAddOrEdit || isExamine);

            dtpPURCHASE_ORDER_DATE.Enabled = isAddOrEdit || isExamine;
            ucShipSelect1.Enabled = isAddOrEdit;
            txtREMARK.Enabled = isAddOrEdit || isExamine;
            nudTOTALPRICE.Enabled = isAddOrEdit || isExamine;
            ucPortSelect1.Enabled = isAddOrEdit || isExamine;
            ucManufacturerSelect1.Enabled = isAddOrEdit || isExamine;
            ucComponentSelect1.Enabled = isAddOrEdit || isExamine;
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
                ucComponentSelect1.SelectedId(drItem["COMPONENT_UNIT_ID"].ToString());
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
            if (!SparePurchaseOrderDetailService.Instance.GetInfo(PURCHASE_ORDERID, out dtDetail, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            bindingSourceDetail.DataSource = dtDetail;
            dgvDetail.DataSource = bindingSourceDetail;
            //bindingSourceDetail.Sort = "PURCHASE_APPLYID,PARTNUMBER";
            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("SPARE_NAME", "备件");
            dic.Add("selSpare", "");
            dic.Add("PARTNUMBER", "采购号或规格");
            dic.Add("UNIT_NAME", "单位");
            dic.Add("PURCHASECOUNT", "采购数量");
            dic.Add("RECEIVECOUNT", "到货数量");
            dic.Add("RECEIVEREMARK", "评价");
            //dic.Add("PRICE", "采购金额");
            dic.Add("REMARK", "备注");
            dgvDetail.SetDgvGridColumns(dic);

            //给dgvDetail加一个列按钮列用于打开弹出对话框选择备件信息.
            if (dgvDetail.Columns["selSpare"] != null)//如果按钮列已经存在，则不能重复添加.
                dgvDetail.Columns.Remove("selspare");
            DataGridViewButtonColumn dgvBtnCol = new DataGridViewButtonColumn();
            dgvBtnCol.Name = "selSpare";
            dgvBtnCol.HeaderText = "";
            dgvBtnCol.UseColumnTextForButtonValue = true;
            dgvBtnCol.Text = "…";
            dgvBtnCol.Width = 25;
            dgvDetail.Columns.Insert(4, dgvBtnCol);
            foreach (DataGridViewColumn item in dgvDetail.Columns)
                item.ReadOnly = true;
        }
        /// <summary>
        /// 从指定的位置往下连续加入几行备件申请信息.
        /// </summary>
        /// <param name="ComponentUnit"></param>
        /// <param name="sporeids"></param>
        /// <param name="index">从第几行开始加入，如果从第一行加入，录入0，如果从最后一行加入，录入当前的总行数</param>
        /// <param name="replaceRow">是否要覆盖当前指定行，如果true，则index行会被覆盖掉</param>
        private void InsertSparesToGridView(ComponentUnit componentUnit, List<StorageParameter> sporeids, int index, bool isFuGai)
        {
            if (componentUnit == null || string.IsNullOrEmpty(componentUnit.COMPONENT_UNIT_ID))
            {
                MessageBoxEx.Show("添加备件申请条目信息时，传入的参数设备无效！", "错误提示");
                return;
            }
            if (sporeids.Count == 0)
            {
                MessageBoxEx.Show("添加备件申请条目信息时，传入的备件条目为0！", "错误提示");
                return;
            }
            List<SpareInfo> sporeInfoList = new List<SpareInfo>();
            string err;
            DataTable dt = (DataTable)bindingSourceDetail.DataSource;
            int tempIndex = dt.Select(" SPARE_ID is not null").Length + 1;
            foreach (StorageParameter sporeTemp in sporeids)
            {
                DataRow[] drs = dt.Select("SPARE_ID='" + sporeTemp.ItemId + "'");
                SpareInfo spore = SpareInfoService.Instance.getObject(sporeTemp.ItemId, out err);
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

                dgvDetail.CurrentRow.Cells["COMPONENT_UNIT_ID"].Value = componentUnit.COMPONENT_UNIT_ID;
                dgvDetail.CurrentRow.Cells["SPARE_ID"].Value = spore.SPARE_ID;
                dgvDetail.CurrentRow.Cells["SPARE_NAME"].Value = spore.SPARE_NAME;
                dgvDetail.CurrentRow.Cells["PARTNUMBER"].Value = spore.PARTNUMBER;
                dgvDetail.CurrentRow.Cells["UNIT_NAME"].Value = spore.UNIT_NAME;
                dgvDetail.CurrentRow.Cells["PURCHASECOUNT"].Value = 1;
            }

            if (sporeInfoList.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("以下选择的备件在该申请单里已存在");
                sb.AppendLine("备件名称 // 规格");
                foreach (SpareInfo item in sporeInfoList)
                    sb.AppendLine(item.SPARE_NAME + " // " + item.PARTNUMBER);
                MessageBoxEx.Show(sb.ToString());
            }
        }
        /// <summary>
        /// 单击选择按钮打开备件弹出框窗体选择备件的Id和名称.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //选备件.
            if (dgvDetail.Columns[e.ColumnIndex].Name == "selSpare")
            {
                if (string.IsNullOrEmpty(ucComponentSelect1.GetId()))
                {
                    MessageBoxEx.Show("请先选择设备", "提示");
                    return;
                }
                string err;
                ComponentUnit cu = ComponentUnitService.Instance.getObject(ucComponentSelect1.GetId(), out err);
                FrmSelectSpare frm = new FrmSelectSpare(cu);
                frm.ShowDialog();
                if (frm.Selected && frm.Spares.Count > 0)
                {
                    InsertSparesToGridView(cu, frm.Spares, dgvDetail.CurrentRow.Index, true);
                }
            }

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
            if (string.IsNullOrEmpty(ucComponentSelect1.GetId()))
            {
                MessageBoxEx.Show("设备不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ucComponentSelect1.Focus();
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
                if (string.IsNullOrEmpty(item.Cells["SPARE_ID"].Value.ToString()))
                {
                    MessageBoxEx.Show("第" + (i + 1) + "行的备件不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (string.IsNullOrEmpty(item.Cells["PURCHASECOUNT"].Value.ToString()))
                {
                    MessageBoxEx.Show("第" + (i + 1) + "行的采购数量不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (Convert.ToDecimal(item.Cells["PURCHASECOUNT"].Value) <= 0)
                {
                    MessageBoxEx.Show("第" + (i + 1) + "行的采购数量不能小于或等于零", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
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
            spo.COMPONENT_UNIT_ID = ucComponentSelect1.GetId();
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
                    spo.PURCHASE_ORDER_CODE = SparePurchaseOrderService.Instance.GetPurchaseOrderCode(ucShipSelect1.GetId());
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
                    }
                    item.EndEdit();
                }
                dbOperation.SaveFormData(((DataTable)bindingSourceDetail.DataSource), "T_SPARE_PURCHASE_ORDER_DETAIL", 0, out err);

                foreach (string item in applyidList)
                {
                    SparePurchaseApply obj = SparePurchaseApplyService.Instance.getObject(item, out err);
                    obj.STATE = 9;
                    obj.Update(out err);
                }

                tc.CommitTransaction();
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
                    if (!SparePurchaseOrderDetailService.Instance.DeleteByPurchaseOrderID(PURCHASE_ORDERID, out err))
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
            if (!string.IsNullOrEmpty(ucComponentSelect1.GetId()))
            {
                ucComponentSelect1.SelectedId("");
            }
            ucComponentSelect1.ChangeShip("", theSelectedObject);
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
            if (txtREMARK.Text.Trim().Contains("不同意"))
            {
                MessageBoxEx.Show("备注内容不能包含'不同意'", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtREMARK.Focus();
                return;
            }
            string err;
            if (!CheckForm()) return;
            if (MessageBoxEx.Show("是否完成填写？", "提示信息", MessageBoxButtons.YesNo,
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
            if (string.IsNullOrEmpty(ucComponentSelect1.GetId()))
            {
                MessageBoxEx.Show("请先选择设备", "提示");
                return;
            }
            if (string.IsNullOrEmpty(ucShipSelect1.GetId()))
            {
                MessageBoxEx.Show("请先选择船舶", "提示");
                return;
            }
            if (!dgvDetail.HasEmptyVal("SPARE_NAME"))
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
            if (dgvDetail.CurrentRow == null)
            {
                MessageBoxEx.Show("未选中任何行!");
                return;
            }
            bindingSourceDetail.RemoveCurrent();
        }
        /// <summary>
        /// 关闭时.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSparePurchaseOrderEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
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
  
        /// <summary>
        /// 关联相关文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                 CommonOperation.Enum.FileBoundingTypes.SPEARORDER, spo.SHIP_ID);
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
                int state = T_WorkFlowService.Instance.RejectBusiness(spo.SHIP_ID, spo.GetId(), "订单审核流程", false, out err, "不同意," + txtREMARK.Text);

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
