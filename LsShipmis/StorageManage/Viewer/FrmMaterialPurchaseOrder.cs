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
using ShipMisZHJ_WorkFlow.Services;
using CommonOperation.Functions;
using ShipMisZHJ_WorkFlow.Forms;
using ShipMisZHJ_WorkFlow.BusinessClasses;

namespace StorageManage.Viewer
{
    public partial class FrmMaterialPurchaseOrder : CommonViewer.BaseForm.FormBase, CommonOperation.Interfaces.IRemindViewState
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmMaterialPurchaseOrder instance = new FrmMaterialPurchaseOrder();
        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmMaterialPurchaseOrder Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmMaterialPurchaseOrder.instance = new FrmMaterialPurchaseOrder();
                }

                return FrmMaterialPurchaseOrder.instance;
            }
        }
        private FrmMaterialPurchaseOrder()
        {
            InitializeComponent();
        }
        #endregion

        #region 报警相关
        public void SetRemindViewApprovalState()
        {
            ucShipSelect1.SelectedText("所有船");
            cboChkState.Text = "未填写完毕或等待审核或被打回";
        }

        public void SetRemindViewInformState()
        {
            ucShipSelect1.SelectedText("所有船");
            cboChkState.Text = "全部";
        }
        #endregion

        #region 页面加载部分
        private List<string> operationIds = new List<string>();
        private bool _load = true;

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMaterialPurchaseOrder_Load(object sender, EventArgs e)
        {
            this.setComboBox();     //设置窗体所需的下拉列表框的数据源.
            this.WindowState = FormWindowState.Maximized;//窗体最大化.
            if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
            {
                bdNgAddNewItem.Visible = false;
                bdNgDeleteItem.Visible = false;
                btnContinueOrder.Visible = false;
            }
            this.setBindingSource();//设置数据源.
            this.setDataGridView(); //设置网格控件dgvOrder的隐藏列与标头的设置. 
            ucShipSelect1.ChangeSelectedState(true, true);
            _load = false;

            this.ucShipSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(this.ucShipSelect1_TheSelectedChanged);
            this.cboChkState.SelectedIndexChanged += new System.EventHandler(this.cboChkState_SelectedIndexChanged);
        }
        /// <summary>
        /// 绑定信息.
        /// </summary>
        private void setBindingSource()
        {
            string shipId = ucShipSelect1.GetId();//船舶.
            string state = "";
            if (cboChkState.SelectedValue == null || cboChkState.SelectedValue.ToString() == "0" || cboChkState.SelectedValue.ToString() == "1")
                state = "";
            else
                state = MaterialPurchaseOrderService.Instance.GetBusinessStateByViewerState(cboChkState.SelectedValue.ToString());
            DataTable dtbOrder;
            string err;
            if (!MaterialPurchaseOrderService.Instance.GetInfo(null, shipId, state, out dtbOrder, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");
            sb.Append(" and (ISCOMPLETE=1 or ( ISCOMPLETE=0 and PURCHASE_ORDER_PERSON='" + CommonOperation.ConstParameter.UserName + "'))");
            if (cboChkState.SelectedValue != null && cboChkState.SelectedValue.ToString() == "1")
            {
                sb.Append(" and ( 1<>1  ");
                if (CommonOperation.ConstParameter.IsLandVersion)
                {
                    if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
                        sb.AppendLine(" or STATE =1");
                    else if ("机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
                        sb.AppendLine(" or STATE =2");
                    else if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
                        sb.AppendLine(" or STATE =3");
                }
                sb.AppendLine(" or ( (STATE=0 or STATE=4) and PURCHASE_ORDER_PERSON='" + CommonOperation.ConstParameter.UserName + "'))");
            }
            DataTable newdt = new DataTable();
            newdt = dtbOrder.Clone();
            DataRow[] rows = dtbOrder.Select(sb.ToString());
            foreach (DataRow item in dtbOrder.Select(sb.ToString()))
                newdt.Rows.Add(item.ItemArray);
            ClearDetail();
            dgvOrder.DataSource = newdt;
            dgvOrder.Sort(dgvOrder.Columns["PURCHASE_ORDER_DATE"], ListSortDirection.Descending);
        }
        private void ClearDetail()
        {
            dgvDetail.DataSource = null;
            txtSHIP_NAME.Text = "";
            txtTOTALPRICE.Text = "";
            txtPURCHASE_ORDER_CODE.Text = "";
            txtPURCHASE_ORDER_PERSON.Text = "";
            txtCURRENCYNAME.Text = "";
            txtPURCHASE_ORDER_DATE.Text = "";
            txtMANUFACTURER_NAME.Text = "";
            txtSENDDATE.Text = "";
            txtLANDCHECKER.Text = "";
            txtCHECKDATE.Text = "";
            txtSENDPORT.Text = "";
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
            dgvColumnStyle.Add("PURCHASE_ORDER_PERSON", "申请人");
            dgvColumnStyle.Add("PURCHASE_ORDER_DATE", "发起日期");
            dgvColumnStyle.Add("CURRENCYCODE", "货币");
            dgvColumnStyle.Add("MANUFACTURER_NAME", "供应商");
            dgvColumnStyle.Add("TOTALPRICE", "总价");
            dgvColumnStyle.Add("SENDDATE", "到货日期");
            dgvColumnStyle.Add("SENDPORT", "送货港口");
            dgvColumnStyle.Add("LANDCHECKER", "岸端确认者");
            dgvColumnStyle.Add("CHECKDATE", "岸端确认日期");
            dgvColumnStyle.Add("STATE_NAME", "状态");
            dgvColumnStyle.Add("REMARK", "备注");
            dgvOrder.LoadGridView("FrmMaterialPurchaseOrder.dgvOrder", dgvColumnStyle, "mulselect");
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
            //DataRow row0 = dtbChkState.NewRow();
            //row0["Id"] = "00";
            //row0["State"] = "全部";
            //dtbChkState.Rows.Add(row0);
            //DataRow row11 = dtbChkState.NewRow();
            //row11["Id"] = "10";
            //row11["State"] = "未填写完毕或等待审核或被打回";
            //dtbChkState.Rows.Add(row11);
            //DataRow row4 = dtbChkState.NewRow();
            //row4["Id"] = "1";
            //row4["State"] = "等待岸端机务主管审批";
            //dtbChkState.Rows.Add(row4);
            //DataRow row5 = dtbChkState.NewRow();
            //row5["Id"] = "2";
            //row5["State"] = "等待岸端机务经理审批";
            //dtbChkState.Rows.Add(row5);
            //DataRow row6 = dtbChkState.NewRow();
            //row6["Id"] = "3";
            //row6["State"] = "等待船管总经理审批";
            //dtbChkState.Rows.Add(row6);
            //DataRow row9 = dtbChkState.NewRow();
            //row9["Id"] = "4";
            //row9["State"] = "订单打回";
            //dtbChkState.Rows.Add(row9);
            //DataRow row1 = dtbChkState.NewRow();
            //row1["Id"] = "5";
            //row1["State"] = "订购";
            //dtbChkState.Rows.Add(row1);
            //DataRow row10 = dtbChkState.NewRow();
            //row10["Id"] = "7";
            //row10["State"] = "此订单作废";
            //dtbChkState.Rows.Add(row10);

            //DataRow row12 = dtbChkState.NewRow();
            //row12["Id"] = "8";
            //row12["State"] = "结束";
            //dtbChkState.Rows.Add(row12);
            //DataRow row123 = dtbChkState.NewRow();
            //row123["Id"] = "9";
            //row123["State"] = "已生成凭证";
            //dtbChkState.Rows.Add(row123);

            dtbChkState.Rows.Add("0", "全部");
            dtbChkState.Rows.Add("1", "待我处理"); //未填写完毕或等待审核或被打回
            dtbChkState.Rows.Add("2", "审批中");   //1 2 3
            dtbChkState.Rows.Add("3", "订购中");   //5
            dtbChkState.Rows.Add("4", "结束");     //8
            dtbChkState.Rows.Add("5", "已生成凭证");     //9

            cboChkState.DataSource = dtbChkState;
            cboChkState.SelectedIndex = 1;
            #endregion
        }

        #endregion

        #region 筛选条件控件事件

        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            this.setBindingSource();
        }
        private void cboChkState_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnLandCheck.Enabled = (cboChkState.SelectedValue.ToString() == "1");
            this.setBindingSource();
        }
        #endregion

        #region 数据变化 单击切换右边和按钮
        /// <summary>
        /// 当申请单信息网格行改变时，显示当前行的申请单明细信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvOrder_SelectedChanged(int rowNumber)
        {
            if (_load) return;
            if (dgvOrder.DataSource == null || dgvOrder.Rows.Count == 0) return;
            string PURCHASE_ORDERID = dgvOrder.Rows[rowNumber].Cells["PURCHASE_ORDERID"].Value.ToString();
            if (string.IsNullOrEmpty(PURCHASE_ORDERID)) return;
            string PURCHASE_ORDER_PERSON = dgvOrder.Rows[rowNumber].Cells["PURCHASE_ORDER_PERSON"].Value.ToString();
            string PURCHASE_ORDER_CODE = dgvOrder.Rows[rowNumber].Cells["PURCHASE_ORDER_CODE"].Value.ToString();
            string STATE = dgvOrder.Rows[rowNumber].Cells["STATE"].Value.ToString();
            string lastShipId = dgvOrder.Rows[rowNumber].Cells["SHIP_ID"].Value.ToString();

            //FileOperation.FileBoundingOperation.Instance.FileBoundCheck(PURCHASE_ORDERID, PURCHASE_ORDER_CODE,
            //CommonOperation.Enum.FileBoundingTypes.ITEMSORDER, lastShipId);
            ShowDataToForm(PURCHASE_ORDERID);
            CheckRightEnabled(PURCHASE_ORDERID, PURCHASE_ORDER_PERSON, STATE);
            //绑定附件，设置附件编辑的权限-liulei/2016/01/11
            FileOperationBase.Services.right right = FileOperationBase.Services.right.C;
            if (STATE == "8")//已结束
            {
                right = FileOperationBase.Services.right.R;//只读权限
                
            }
            FileOperation.FileBoundingOperation.Instance.FileBoundCheck(PURCHASE_ORDERID
                    , PURCHASE_ORDER_CODE
                    , CommonOperation.Enum.FileBoundingTypes.ITEMSORDER
                    , lastShipId
                    , right);
        }

        /// <summary>
        /// 界面功能控件可用权限设置. 2014.4.22 李鹏修改
        /// </summary>
        private void CheckRightEnabled(string pURCHASE_ORDERID, string pURCHASE_ORDER_PERSON, string sTATE)
        {
            if (dgvOrder.DataSource == null || dgvOrder.Rows.Count == 0)
            {
                bdNgDeleteItem.Enabled = false;//删除.
                bdNgEditItem.Enabled = false;//编辑. 
                btnLandCheck.Enabled = false;//机务审核.
                btn_CheckView.Enabled = false;//审核历史
                return;
            }

            bool isAddOrEdit = (pURCHASE_ORDER_PERSON == CommonOperation.ConstParameter.UserName && (sTATE == "0" || sTATE == "4"));
            bool isExamine = false;

            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务主管.
                {
                    isAddOrEdit = isAddOrEdit || (pURCHASE_ORDER_PERSON == CommonOperation.ConstParameter.UserName && sTATE == "1");
                    isExamine = sTATE == "1" && pURCHASE_ORDER_PERSON != CommonOperation.ConstParameter.UserName;
                }
                else if ("机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务经理.
                {
                    isAddOrEdit = isAddOrEdit || (pURCHASE_ORDER_PERSON == CommonOperation.ConstParameter.UserName && (sTATE == "2"));
                    isExamine = (sTATE == "2") && pURCHASE_ORDER_PERSON != CommonOperation.ConstParameter.UserName;
                }
                else if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是船管总经理.
                {
                    isAddOrEdit = isAddOrEdit || (pURCHASE_ORDER_PERSON == CommonOperation.ConstParameter.UserName && sTATE == "3");
                    isExamine = sTATE == "3" && pURCHASE_ORDER_PERSON != CommonOperation.ConstParameter.UserName;
                }
            }

            bdNgDeleteItem.Enabled = isAddOrEdit || isExamine;//删除.
            bdNgEditItem.Enabled = isAddOrEdit || isExamine;//编辑.             
            btnLandCheck.Enabled = isExamine;//机务审核.
            btn_CheckView.Enabled = true;
            bool isCanContinueOrder = false;
            foreach (DataGridViewRow item in dgvDetail.Rows)
            {
                if (item.Cells["RECEIVECOUNT"].Value != DBNull.Value && Convert.ToDecimal(item.Cells["PURCHASECOUNT"].Value) > Convert.ToDecimal(item.Cells["RECEIVECOUNT"].Value))
                {
                    isCanContinueOrder = true;
                    break;
                }
            }
            btnContinueOrder.Enabled = (isCanContinueOrder && sTATE == "8");
        }
        /// <summary>
        /// 显示数据到控件上.
        /// </summary>
        private void ShowDataToForm(string PURCHASE_ORDERID)
        {
            DataTable dt = (DataTable)dgvOrder.DataSource;
            DataRow[] drItems = dt.Select("PURCHASE_ORDERID='" + PURCHASE_ORDERID + "'");
            if (drItems.Length != 1)
            {
                ClearDetail();
                return;
            }
            DataRow drItem = drItems[0];
            PURCHASE_ORDERID = drItem["PURCHASE_ORDERID"].ToString();
            txtSHIP_NAME.Text = drItem["SHIP_NAME"].ToString();
            txtTOTALPRICE.Text = drItem["TOTALPRICE"].ToString();
            txtPURCHASE_ORDER_CODE.Text = drItem["PURCHASE_ORDER_CODE"].ToString();
            txtPURCHASE_ORDER_PERSON.Text = drItem["PURCHASE_ORDER_PERSON"].ToString();
            txtCURRENCYNAME.Text = drItem["CURRENCYCODE"].ToString();
            txtPURCHASE_ORDER_DATE.Text = drItem["PURCHASE_ORDER_DATE"].ToString();
            txtMANUFACTURER_NAME.Text = drItem["MANUFACTURER_NAME"].ToString();
            txtSENDDATE.Text = drItem["SENDDATE"].ToString();
            txtSENDPORT.Text = drItem["SENDPORT"].ToString();
            txtLANDCHECKER.Text = drItem["LANDCHECKER"].ToString();
            txtCHECKDATE.Text = drItem["CHECKDATE"].ToString();
            txtREMARK.Text = drItem["REMARK"].ToString();

            DataTable dtDetail;
            string err;
            if (!MaterialPurchaseOrderDetailService.Instance.GetInfo(PURCHASE_ORDERID, out dtDetail, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            dgvDetail.DataSource = dtDetail;
            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("MATERIAL_TYPE_NAME", "物资类型");
            dic.Add("MATERIAL_NAME", "物资");
            dic.Add("MATERIAL_CODE", "物资编号");
            dic.Add("MATERIAL_SPEC", "采购号或规格");
            dic.Add("UNIT_NAME", "单位");
            dic.Add("PURCHASECOUNT", "采购数量");
            dic.Add("RECEIVEREMARK", "到货评价");
            //dic.Add("PRICE", "采购金额");
            dic.Add("RECEIVECOUNT", "到货数量");
            dic.Add("REMARK", "备注");
            dgvDetail.SetDgvGridColumns(dic);
            foreach (DataGridViewColumn item in dgvDetail.Columns)
                item.ReadOnly = true;
        }

        #endregion

        #region 按钮操作部分

        #region 审核部分
        /// <summary>
        /// 机务审核事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLandCheck_Click(object sender, EventArgs e)
        {
            string err = "";
            GetMulSelectID();
            if (operationIds.Count == 0)
            {
                MessageBoxEx.Show("未选中任何行!");
                return;
            }
            using (TransactionClass tc = new TransactionClass())
            {
                List<CheckObj> materialOrderChecks = new List<CheckObj>();
                foreach (string operationId in operationIds)
                {
                    materialOrderChecks.Add(MaterialPurchaseOrderService.Instance.GetMaterialPurchaseOrderCheckObjByOrderId(operationId));
                }

                FrmCheck frm = new FrmCheck(materialOrderChecks, 2);
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.Cancel) return;
                foreach (string PURCHASE_ORDERID in operationIds)
                {
                    MaterialPurchaseOrder spo = MaterialPurchaseOrderService.Instance.getObject(PURCHASE_ORDERID, out err);
                    List<string> sqlList = new List<string>();
                    if (frm.Current_State == 1)
                    {
                        spo.CHECKDATE = DateTime.MinValue;
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
                        spo.Update(out err);
                    }
                    else if (frm.Current_State == 3)
                    {
                        spo.STATE = 5;
                        spo.LANDCHECKER = CommonOperation.ConstParameter.UserName;
                        spo.CHECKDATE = DateTime.Now;
                        spo.Update(out err);
                        RemindService.Instance.CreateRemindOnce(3, spo.SHIP_ID, spo.PURCHASE_ORDERID);
                    }
                    else if (frm.Current_State == 2)
                    {
                        if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务主管.
                        {
                            spo.STATE = 4;
                        }
                        else if ("机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务经理.
                        {
                            spo.STATE = 1;
                        }
                        else if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是船管总经理.
                        {
                            spo.STATE = 2;
                        }
                        spo.LANDCHECKER = "";
                        spo.CHECKDATE = DateTime.MinValue;
                        spo.Update(out err);
                    }
                    else if (frm.Current_State == 4)
                    {
                        spo.STATE = 4;
                        spo.LANDCHECKER = "";
                        spo.CHECKDATE = DateTime.MinValue;
                        spo.Update(out err);
                    }
                }
                tc.CommitTransaction();
            }
            this.setBindingSource();
        }
        #endregion

        /// <summary>
        /// 继续订购.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnContinueOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrder.CurrentRow == null)
            {
                MessageBoxEx.Show("未选中任何行!");
                return;
            }
            FrmMaterialPurchaseOrderEdit frm = new FrmMaterialPurchaseOrderEdit(dgvOrder.CurrentRow.Cells["PURCHASE_ORDERID"].Value.ToString(), 3);
            frm.ShowDialog();
        }

        /// <summary>
        /// 删除操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.
            if (dgvOrder.CurrentRow == null)
            {
                MessageBoxEx.Show("未选中任何行!");
                return;
            }
            if (DialogResult.No == MessageBoxEx.Show("确认删除该条信息吗?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                return;
            string state = dgvOrder.CurrentRow.Cells["STATE"].Value.ToString();
            string purchaseOrderPerson = dgvOrder.CurrentRow.Cells["PURCHASE_ORDER_PERSON"].Value.ToString();
            string purchaseOrderId = dgvOrder.CurrentRow.Cells["PURCHASE_ORDERID"].Value.ToString();
            if ((state == "0" || state == "4") && purchaseOrderPerson == CommonOperation.ConstParameter.UserName)
            {
                if (!MaterialPurchaseOrderDetailService.Instance.DeleteByPurchaseOrderID(purchaseOrderId, out err))
                {
                    MessageBoxEx.Show(err, "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (!MaterialPurchaseOrderService.Instance.deleteUnit(purchaseOrderId, out err))
                {
                    MessageBoxEx.Show(err, "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                if (DialogResult.No == MessageBoxEx.Show("删除操作会把该信息状态变为作废,确定吗?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                    return;
                MaterialPurchaseOrder spa = MaterialPurchaseOrderService.Instance.getObject(purchaseOrderId, out err);
                spa.STATE = 7;
                if (!MaterialPurchaseOrderService.Instance.saveUnit(spa, out err))
                {
                    MessageBoxEx.Show(err, "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            MessageBoxEx.Show("操作成功！", "操作成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.setBindingSource();
        }

        /// <summary>
        /// 编辑按钮事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgEditItem_Click(object sender, EventArgs e)
        {
            if (dgvOrder.CurrentRow == null)
            {
                MessageBoxEx.Show("未选中任何行!");
                return;
            }
            string purchaseOrderId = dgvOrder.CurrentRow.Cells["PURCHASE_ORDERID"].Value.ToString();
            FrmMaterialPurchaseOrderEdit frm = new FrmMaterialPurchaseOrderEdit(purchaseOrderId);
            frm.ShowDialog();
            this.setBindingSource();
        }

        /// <summary>
        /// 添加按钮事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            FrmMaterialPurchaseOrderEdit frm = new FrmMaterialPurchaseOrderEdit(null);
            frm.ShowDialog();
            this.setBindingSource();
        }

        /// <summary>
        /// 双击事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvOrder_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvOrder.CurrentRow == null)
            {
                MessageBoxEx.Show("未选中任何行!");
                return;
            }
            string PURCHASE_ORDERID = dgvOrder.CurrentRow.Cells["PURCHASE_ORDERID"].Value.ToString();
            FrmMaterialPurchaseOrderEdit frm = new FrmMaterialPurchaseOrderEdit(PURCHASE_ORDERID);
            frm.ShowDialog();
            this.setBindingSource();
        }

        /// <summary>
        /// 释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMaterialPurchaseOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            //清除大文档绑定功能.
            FileOperation.FileBoundingOperation.Instance.FileBoundCheck("", "", 0, "");
            dgvOrder.SaveGridView("FrmMaterialPurchaseOrder.dgvOrder");
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

        private void btnBdFiles_Click(object sender, EventArgs e)
        {
            if (dgvOrder.CurrentRow == null)
            {
                MessageBoxEx.Show("未选中任何行!");
                return;
            }
            FileOperation.FileBoundingOperation.Instance.FileBoundOperation();
        }

        private void btn_CheckView_Click(object sender, EventArgs e)
        {
            if (dgvOrder.CurrentRow == null)
            {
                MessageBoxEx.Show("未选中任何行!");
                return;
            }
            string PURCHASE_ORDERID = dgvOrder.CurrentRow.Cells["PURCHASE_ORDERID"].Value.ToString();
            FrmCheck frm = new FrmCheck(MaterialPurchaseOrderService.Instance.GetMaterialPurchaseOrderCheckObjByOrderId(PURCHASE_ORDERID), 3);
            frm.ShowDialog();
        }
        /// <summary>
        /// 取得并校验多选数据是否合法. 2014.4.22 李鹏增加
        /// </summary>
        /// <returns></returns>
        private bool GetMulSelectID()
        {
            List<DataGridViewRow> dataGridViewRowList = new List<DataGridViewRow>();
            operationIds = new List<string>();
            if (dgvOrder.CurrentRow == null)
            {
                MessageBoxEx.Show("未选中任何行!");

                return false;
            }
            foreach (DataGridViewRow item in dgvOrder.Rows)
            {
                if (item.Cells["mulSelect"].Value != null && Convert.ToBoolean(item.Cells["mulSelect"].Value))
                {
                    operationIds.Add(item.Cells["PURCHASE_ORDERID"].Value.ToString());
                    dataGridViewRowList.Add(item);
                }
            }
            if (operationIds.Count == 0)
            {
                operationIds.Add(dgvOrder.CurrentRow.Cells["PURCHASE_ORDERID"].Value.ToString());
            }

            return true;
        }

        #endregion
    }
}
