/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmMaterialStockck.cs
 * 创 建 人：许榕夏
 * 创建时间：2010-5-5
 * 标    题：物资盘点业务窗体
 * 功能描述：实现物资盘点业务窗体上的相关功能
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
using StorageManage.Services;
using CommonViewer.BaseForm;
using CommonOperation.Interfaces;
using BaseInfo.DataAccess;
using CommonViewer.BaseControl;
using StorageManage.DataObject;
namespace StorageManage.Viewer
{
    public partial class FrmMaterialStockCheck : CommonViewer.BaseForm.FormBase,IRemindViewState
    {
        private IDBOperation commonOpt = CommonOperation.Functions.InterfaceInstantiation.NewADBOperation();//定义一个公共类CommonOpt对象.
        private CommonOperation.Functions.ProxyRight proxyRight = CommonOperation.Functions.ProxyRight.Instance;//权限代理业务类.
        private bool loaded = false;
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmMaterialStockCheck instance = new FrmMaterialStockCheck();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmMaterialStockCheck Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmMaterialStockCheck.instance = new FrmMaterialStockCheck();
                }

                return FrmMaterialStockCheck.instance;
            }
        }

        #endregion

        private FrmMaterialStockCheck()
        {
            InitializeComponent();
        }
        private void FrmMaterialStockck_Load(object sender, EventArgs e)
        {
            ucShipSelect1.ChangeSelectedState(true, true);
            //查询条件默认为三个月的数据.
            dtpStartDate.Value = DateTime.Now.AddMonths(-12);
            dtpEndDate.Value = DateTime.Now.AddMonths(1);
            this.setComboBox();     //设置窗体所需的下拉列表框的数据源.
            if (!this.checkRight()) return;      //功能权限校验.
            loaded = true;
            this.setBindingSource();//设置数据源.
            this.setDataGridView(); //设置网格控件dgvSpApply的隐藏列与标头的设置.
            this.bindingCtrols();   //绑定窗体控件.
            this.WindowState = FormWindowState.Maximized;//窗体最大化.

            Search();
        }

        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {
            //审核状态选择的DataTable对象.
            DataTable dtbChkState = new DataTable();

            //状态(1.等待岸端审阅,2.等待船端调整,3.等待船端确认,4等待岸端确认,5审核被打回,6岸端确认)
            //打回的单据继续由.
            dtbChkState.Columns.Add("Id", typeof(string));
            dtbChkState.Columns.Add("State", typeof(string));
            DataRow row0 = dtbChkState.NewRow();
            row0["Id"] = "0";
            row0["State"] = "全部";
            DataRow row1 = dtbChkState.NewRow();
            row1["Id"] = "1";
            row1["State"] = "等待岸端审阅";
            DataRow row2 = dtbChkState.NewRow();
            row2["Id"] = "2";
            row2["State"] = "等待船端调整";
            DataRow row3 = dtbChkState.NewRow();
            row3["Id"] = "3";
            row3["State"] = "等待船端确认";
            DataRow row4 = dtbChkState.NewRow();
            row4["Id"] = "4";
            row4["State"] = "等待岸端确认";
            DataRow row5 = dtbChkState.NewRow();
            row5["Id"] = "5";
            row5["State"] = "审核被打回";
            DataRow row6 = dtbChkState.NewRow();
            row6["Id"] = "6";
            row6["State"] = "岸端确认";

            dtbChkState.Rows.Add(row0);
            if (StorageConfig.StorageStorageCheckNeedLandView) dtbChkState.Rows.Add(row1);
            dtbChkState.Rows.Add(row2);
            dtbChkState.Rows.Add(row3);
            dtbChkState.Rows.Add(row4);
            dtbChkState.Rows.Add(row5);
            dtbChkState.Rows.Add(row6);

            cboChkState.DataSource = dtbChkState;
            cboChkState.DisplayMember = "State";
            cboChkState.ValueMember = "Id";
        }
        /// <summary>
        /// 设置物资信息的bindingSource数据源，每次查询的都是指定船名的物资信息。.
        /// </summary>
        private void setBindingSource()
        {
            if (!loaded) return;
            string shipId = ucShipSelect1.GetId();
            string sckState = "";
            if (cboChkState.SelectedValue != null)
            {
                sckState = cboChkState.SelectedValue.ToString();        //审核状态.
            }

            //取得物资盘存单信息的DataTable对象.
            DataTable dtbMaterialStockck = MaterialDepotCheckService.Instance.GetMaterialStockCheck(shipId, dtpStartDate.Value, dtpEndDate.Value, sckState, !cbOthersData.Checked);
            bindingSourceMain.DataSource = dtbMaterialStockck;//物资盘点信息的数据源设置.
            dgvSpStockck.DataSource = bindingSourceMain;
            resetStrikeBalanceColor();
        }

        /// <summary>
        /// 设置物资盘点信息网格控件dgvSpIn的隐藏列与显示标题.
        /// </summary>
        private void setDataGridView()
        {
            dgvSpStockck.LoadGridView("FrmMaterialDepotCheck.dgvSpStockck");
            dgvSpStockck.Columns["DEPOTCHECKID"].Visible = false;
            dgvSpStockck.Columns["SHIP_ID"].Visible = false;
            dgvSpStockck.Columns["ship_name"].Visible = true;
            dgvSpStockck.Columns["WAREHOUSE_ID"].Visible = false;
            dgvSpStockck.Columns["CHECKDATE"].Visible = false;
            dgvSpStockck.Columns["CHECK_PERSON_POSTID"].Visible = false;
            dgvSpStockck.Columns["STATE"].Visible = false;
            dgvSpStockck.Columns["ISCOMPLETE"].Visible = false;
            dgvSpStockck.Columns["CHECK_CODE"].Visible = false;
            dgvSpStockck.Columns["remark"].Visible = false;
            dgvSpStockck.Columns["ship_name"].HeaderText = "船舶";
            dgvSpStockck.Columns["WAREHOUSE_NAME"].HeaderText = "盘点仓库";
            dgvSpStockck.Columns["CHECK_DATE"].HeaderText = "盘点日期";
            dgvSpStockck.Columns["CHECK_PERSON"].HeaderText = "盘点人";
            dgvSpStockck.Columns["stateName"].HeaderText = "盘点状态";
            dgvSpStockck.Columns["DEPART_ID"].Visible = false;
            dgvSpStockck.Columns["SHIPCHECKER"].Visible = false;
            dgvSpStockck.Columns["LANDCHECKER"].Visible = false;
            dgvSpStockck.Columns["BALANCEDEPOTCHECKID"].Visible = false;
            dgvSpStockck.Columns["StrikeToBalance"].Visible = false;
            dgvSpStockck.Columns["hasBeenBalanced"].Visible = false;
        }
        private void resetStrikeBalanceColor()
        {
            //刷新冲账记录.
            for (int i = 0; i < dgvSpStockck.Rows.Count; i++)
            {
                if (dgvSpStockck.Rows[i].Cells["StrikeToBalance"].Value.ToString() == "1")
                {
                    dgvSpStockck.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }
        /// <summary>
        /// 绑定窗体控件（盘存单信息控件的绑定）.
        /// </summary>
        private void bindingCtrols()
        {
            //主键值DEPOTCHECKID的绑定使用了dtpSpckDate的Tag属性解决，无法使用隐藏的控件。.
            txtCode.DataBindings.Add("Text", bindingSourceMain, "CHECK_CODE", true);
            txtWareHouse.DataBindings.Add("Text", bindingSourceMain, "WAREHOUSE_NAME", true);
            dtpSpckDate.DataBindings.Add("Tag", bindingSourceMain, "DEPOTCHECKID", true);
            dtpSpckDate.DataBindings.Add("Text", bindingSourceMain, "CHECK_DATE", true);
            txtStockChecker.DataBindings.Add("Text", bindingSourceMain, "CHECK_PERSON", true);
            txtRemark.DataBindings.Add("Text", bindingSourceMain, "remark", true);
            txtShipChecker.DataBindings.Add("Text", bindingSourceMain, "SHIPCHECKER", true);
            txtCheckDate.DataBindings.Add("Text", bindingSourceMain, "CHECKDATE", true);
            txtLandChecker.DataBindings.Add("Text", bindingSourceMain, "LANDCHECKER", true);
            txtState.DataBindings.Add("Text", bindingSourceMain, "stateName", true);
        }

        /// <summary>
        /// 界面功能权限的校验.
        /// </summary>
        private bool checkRight()
        {
            btnView.Enabled = false;
            btnBanlance.Enabled = false;
            btnCheck.Enabled = false;
            string err;
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                bdNgAddNewItem.Visible = false;
                bdNgDeleteItem.Visible = false;
                bdNgEditItem.Visible = false;
                if (StorageConfig.StorageStorageCheckNeedLandView) btnView.Visible = true;
                cbOthersData.Checked = false;
                cbOthersData.Visible = false;

                if (!proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_VIEW, out err)
                   && !proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_CHECK, out err)
                   && !proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_LEADER_CHECK, out err)
                   && !proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_MANAGER_CHECK, out err))
                {
                    MessageBoxEx.Show("必须具备【岸端物资管理权限】或【物资岸端审核】权限才能看到数据！");
                    return false;
                }
                else if (proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_CHECK, out err)
                   || proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_LEADER_CHECK, out err)
                   || proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_MANAGER_CHECK, out err))
                {
                    btnCheck.Visible = true;
                }
                btnBanlance.Visible = proxyRight.CheckRight(CommonOperation.ConstParameter.STRIKE_A_BALANCE, out err);
            }
            else
            {
                btnView.Visible = false;
                btnBanlance.Visible = false;
                //权限判断部分,如果有看别人信息的权限时，checkbox设置成可操作，否则不可操作.
                if (proxyRight.CheckRight(CommonOperation.ConstParameter.WATCH_OTHERS_INFO_OF_SAME_DEPT, out err)
                    || CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER || CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS)
                {
                    cbOthersData.Checked = false;
                    cbOthersData.Enabled = true;
                }
                else
                {
                    cbOthersData.Checked = true;
                    cbOthersData.Enabled = false;//不能看别人的.
                }
                //高级船员，非领导岗位.
                if (CommonOperation.ConstParameter.LoginUserInfo.ISHIGHLEVELSHIPMAN && !CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER && !CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS)
                {
                    //设置需要权限控制的控件的可见性.
                    bdNgAddNewItem.Visible = true;
                    bdNgDeleteItem.Visible = true;
                    bdNgEditItem.Visible = true;
                }
                else if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS || CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER)
                {
                    //设置需要权限控制的控件的可见性.
                    bdNgAddNewItem.Visible = true;
                    bdNgDeleteItem.Visible = true;
                    bdNgEditItem.Visible = true;
                    btnCheck.Visible = true;
                }
                else
                {
                    MessageBoxEx.Show("除了船舶的高级船员外，其他人登录此界面也不能操作及看到任何数据！");
                    return false;
                }
            }
            return true;
            // 
        }

        /// <summary>
        /// 当盘存单信息网格行改变时，显示当前行的盘存单明细信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSpStockck_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string stockckId = "";                  //当前网格dgvSpStockck中的盘存单信息主键.
            string stockCkCode = "";                //物资盘存单编号.
            string shipId;
            string state;
            if (dgvSpStockck.CurrentRow != null && dgvSpStockck.CurrentRow.Cells["DEPOTCHECKID"].Value != null)
            {
                //状态(1.等待岸端审阅,2.等待船端调整,3.等待船端确认,4等待岸端确认,5审核被打回,6岸端确认)
                //如果当前的内容是可以删除的，状态、本人可以删除、领导可以删除；.
                if (dgvSpStockck.CurrentRow.Cells["ISCOMPLETE"].Value.ToString() == "1" &&
                    (dgvSpStockck.CurrentRow.Cells["STATE"].Value.ToString() == "2" || dgvSpStockck.CurrentRow.Cells["STATE"].Value.ToString() == "3"
                    || dgvSpStockck.CurrentRow.Cells["STATE"].Value.ToString() == "5"))
                {
                    bdNgEditItem.Enabled = true;
                }
                else if (dgvSpStockck.CurrentRow.Cells["ISCOMPLETE"].Value.ToString() == "0"
                    && dgvSpStockck.CurrentRow.Cells["DEPART_ID"].Value.ToString().Equals(CommonOperation.ConstParameter.LoginUserInfo.DepartmentId))
                {
                    if (dgvSpStockck.CurrentRow.Cells["STATE"].Value.ToString() == "1")
                        bdNgEditItem.Enabled = true;
                    else if (dgvSpStockck.CurrentRow.Cells["STATE"].Value.ToString() == "2" || dgvSpStockck.CurrentRow.Cells["STATE"].Value.ToString() == "3"
                        || dgvSpStockck.CurrentRow.Cells["STATE"].Value.ToString() == "5")
                        bdNgEditItem.Enabled = true;
                    else
                        bdNgEditItem.Enabled = false;
                }
                else
                {
                    bdNgEditItem.Enabled = false;
                }
            }
            else
            {
                bdNgEditItem.Enabled = false;
            }
            if (dgvSpStockck.Rows[e.RowIndex].Cells["DEPOTCHECKID"].Value != null)
            {
                stockckId = dgvSpStockck.Rows[e.RowIndex].Cells["DEPOTCHECKID"].Value.ToString();
                stockCkCode = dgvSpStockck.Rows[e.RowIndex].Cells["CHECK_CODE"].Value.ToString();
                shipId = dgvSpStockck.Rows[e.RowIndex].Cells["ship_id"].Value.ToString();
                state = dgvSpStockck.Rows[e.RowIndex].Cells["state"].Value.ToString();
                this.setBindingSourceDetail(stockckId, state);
                //绑定大文档.
                FileOperation.FileBoundingOperation.Instance.FileBoundCheck(stockckId, stockCkCode, CommonOperation.Enum.FileBoundingTypes.SPEARCOUNT, shipId);

                btnView.Enabled = (dgvSpStockck.Rows[e.RowIndex].Cells["STATE"].Value.ToString() == "1" && dgvSpStockck.Rows[e.RowIndex].Cells["ISCOMPLETE"].Value.ToString() == "1");
                btnCheck.Enabled = (((dgvSpStockck.Rows[e.RowIndex].Cells["STATE"].Value.ToString() == "3" && !CommonOperation.ConstParameter.IsLandVersion)
                    || (dgvSpStockck.Rows[e.RowIndex].Cells["STATE"].Value.ToString() == "4" && CommonOperation.ConstParameter.IsLandVersion))
                    && dgvSpStockck.Rows[e.RowIndex].Cells["ISCOMPLETE"].Value.ToString() == "1");
                btnBanlance.Enabled = (dgvSpStockck.Rows[e.RowIndex].Cells["STATE"].Value.ToString() == "6" && dgvSpStockck.Rows[e.RowIndex].Cells["ISCOMPLETE"].Value.ToString() == "1"
                    && dgvSpStockck.Rows[e.RowIndex].Cells["hasBeenBalanced"].Value.ToString() == "0" && dgvSpStockck.Rows[e.RowIndex].Cells["StrikeToBalance"].Value.ToString() != "1");
                btnClone.Enabled = (dgvSpStockck.Rows[e.RowIndex].Cells["STATE"].Value.ToString() == "6" && dgvSpStockck.Rows[e.RowIndex].Cells["ISCOMPLETE"].Value.ToString() == "1"
                    && dgvSpStockck.Rows[e.RowIndex].Cells["hasBeenBalanced"].Value.ToString() == "0");

            }
            else
            {
                this.setBindingSourceDetail("", "");
            }
        }

        /// <summary>
        /// 设置物资盘存单明细信息的bindingSource数据源，每次查询的都是指定盘存单的明细信息数据.
        /// </summary>
        /// <param name="stockckId">盘存单信息Id</param>
        /// <param name="stockckId">盘存单信息Id</param>
        private void setBindingSourceDetail(string stockckId, string state)
        {
            DataTable dtbMaterialStockckDetail = MaterialDepotCheckService.Instance.GetMaterialStockckDetail(stockckId);//取得物资盘存单明细信息的DataTable对象.
            bindingSourceDetail.DataSource = dtbMaterialStockckDetail;//物资盘点明细信息的数据源设置.
            dgvSpStockckDetail.DataSource = bindingSourceDetail;
            this.setDataGridViewDetail(state);
        }

        /// <summary>
        /// 设物资盘点明细信息网格控件dgvSpStockckDetail的隐藏列与显示标题.
        /// </summary>
        private void setDataGridViewDetail(string state)
        {
            dgvSpStockckDetail.LoadGridView("FrmMaterialStockCheck.dgvSpStockckDetail");
            dgvSpStockckDetail.Columns["MaterialCHECKDETAIL_ID"].Visible = false;
            dgvSpStockckDetail.Columns["DEPOTCHECKID"].Visible = false;
            dgvSpStockckDetail.Columns["WAREHOUSE_ID"].Visible = false;
            dgvSpStockckDetail.Columns["material_Id"].Visible = false;
            dgvSpStockckDetail.Columns["ship_id"].Visible = false;
            dgvSpStockckDetail.Columns["THEORETICALCOUNT"].Visible = false;
            dgvSpStockckDetail.Columns["COUNT"].Visible = false;
            dgvSpStockckDetail.Columns["ISSAP"].HeaderText = "物料类型";
            dgvSpStockckDetail.Columns["material_code"].HeaderText = "物资编码";
            dgvSpStockckDetail.Columns["material_name"].HeaderText = "物资名称";
            dgvSpStockckDetail.Columns["material_spec"].HeaderText = "规格型号";
            dgvSpStockckDetail.Columns["THEORETICALCOUNT"].HeaderText = "帐面数量";
            dgvSpStockckDetail.Columns["THEORETICALCOUNT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSpStockckDetail.Columns["ACTUALCOUNT"].HeaderText = "实存数量";
            dgvSpStockckDetail.Columns["ACTUALCOUNT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSpStockckDetail.Columns["COUNT"].HeaderText = "盈亏数量";
            dgvSpStockckDetail.Columns["COUNT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSpStockckDetail.Columns["unit_name"].HeaderText = "单位";
            dgvSpStockckDetail.Columns["unit_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSpStockckDetail.Columns["remark"].HeaderText = "盈亏原因";
            dgvSpStockckDetail.Columns["material_code"].ReadOnly = true;
            dgvSpStockckDetail.Columns["material_code"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpStockckDetail.Columns["material_name"].ReadOnly = true;
            dgvSpStockckDetail.Columns["material_name"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpStockckDetail.Columns["material_spec"].ReadOnly = true;
            dgvSpStockckDetail.Columns["material_spec"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpStockckDetail.Columns["THEORETICALCOUNT"].ReadOnly = true;
            dgvSpStockckDetail.Columns["THEORETICALCOUNT"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpStockckDetail.Columns["unit_name"].ReadOnly = true;
            dgvSpStockckDetail.Columns["unit_name"].DefaultCellStyle.BackColor = Color.Linen;
            dgvSpStockckDetail.Columns["COUNT"].ReadOnly = true;
            dgvSpStockckDetail.Columns["COUNT"].DefaultCellStyle.BackColor = Color.Linen;
            //1.等待岸端审阅,2.等待船端调整,3.等待船端确认,4等待岸端确认,5审核被打回,6岸端确认.
            int iState;
            if (int.TryParse(state, out iState))
            {
                if (iState > 1)
                {
                    dgvSpStockckDetail.Columns["THEORETICALCOUNT"].Visible = true;
                    dgvSpStockckDetail.Columns["COUNT"].Visible = true;
                }
            }
        }

        #region 查询
        /// <summary>
        /// 申请单记录筛选.
        /// </summary>
        private void Search()
        {
            this.setBindingSource();
            //如果盘点单没有记录，则盘点单明细也不应该有数据.
            if (loaded && dgvSpStockck.Rows.Count == 0)
            {
                this.setBindingSourceDetail("", "");
            }
        }

        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            this.Search();
        }

        private void dtpStartDate_CloseUp(object sender, EventArgs e)
        {
            this.Search();
        }

        private void dtpEndDate_CloseUp(object sender, EventArgs e)
        {
            this.Search();
        }

        private void cboChkState_SelectedValueChanged(object sender, EventArgs e)
        {
            this.Search();
        }
        private void cbOthersData_CheckedChanged(object sender, EventArgs e)
        {
            this.Search();
        }
        #endregion

        #region 按钮操作
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            if (!loaded) return;
            FrmMaterialStockCheckEdit frmMaterialStockckEdit = new FrmMaterialStockCheckEdit();
            frmMaterialStockckEdit.ShowDialog();
            this.Search();
        }

        private void bdNgEditItem_Click(object sender, EventArgs e)
        {
            if (dgvSpStockck.CurrentRow != null && dgvSpStockck.CurrentRow.Cells["DEPOTCHECKID"].Value != null)
            {
                //状态(1.等待岸端审阅,2.等待船端调整,3.等待船端确认,4等待岸端确认,5审核被打回,6岸端确认)
                //如果当前的内容是可以删除的，状态、本人可以删除、领导可以删除；.
                if (dgvSpStockck.CurrentRow.Cells["ISCOMPLETE"].Value.ToString() == "1" &&
                    (dgvSpStockck.CurrentRow.Cells["STATE"].Value.ToString() == "2" || dgvSpStockck.CurrentRow.Cells["STATE"].Value.ToString() == "3"
                    || dgvSpStockck.CurrentRow.Cells["STATE"].Value.ToString() == "5"))
                {
                    openform(3);
                }
                else if (dgvSpStockck.CurrentRow.Cells["ISCOMPLETE"].Value.ToString() == "0"
                    && dgvSpStockck.CurrentRow.Cells["DEPART_ID"].Value.ToString().Equals(CommonOperation.ConstParameter.LoginUserInfo.DepartmentId))
                {
                    if (dgvSpStockck.CurrentRow.Cells["STATE"].Value.ToString() == "1")
                        openform(2);
                    else if (dgvSpStockck.CurrentRow.Cells["STATE"].Value.ToString() == "2" || dgvSpStockck.CurrentRow.Cells["STATE"].Value.ToString() == "3"
                        || dgvSpStockck.CurrentRow.Cells["STATE"].Value.ToString() == "5")
                        openform(3);
                }
            }
        }

        /// <summary>
        /// 删除操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.

            if (dgvSpStockck.CurrentRow != null && dgvSpStockck.CurrentRow.Cells["DEPOTCHECKID"].Value != null)
            {
                //如果当前的内容是可以删除的，状态、本人可以删除、领导可以删除；.
                if (dgvSpStockck.CurrentRow.Cells["ISCOMPLETE"].Value.ToString() == "1" 
                    || dgvSpStockck.CurrentRow.Cells["STATE"].Value.ToString() != (StorageConfig.StorageStorageCheckNeedLandView ? "1" : "3"))
                {
                    MessageBoxEx.Show("仅可以删除未完成操作且没有提交任何人审核的单据", "警告", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
                //根据权限，只要能看到这条数据的，就可以对其进行操作不需要再次进行判断.
                if (MessageBoxEx.Show("确认删除此盘点单信息？",
                   "警告", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;

                if (MaterialDepotCheckService.Instance.deleteUnit(dgvSpStockck.CurrentRow.Cells["DEPOTCHECKID"].Value.ToString(), out err))
                {
                    MessageBoxEx.Show("删除成功！", "删除成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBoxEx.Show(err, "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                //如果当前没有数据，则输入框区域的控件为不可用状态；否则为可用状态。.
                Search();
            }
        }

        /// <summary>
        /// 物资盘点统计信息打印.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgPrintItem_Click(object sender, EventArgs e)
        {
            if (dgvSpStockck.CurrentRow == null || dgvSpStockck.CurrentRow.Cells["DEPOTCHECKID"].Value == null)
            {
                MessageBoxEx.Show("无可打印的信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            dgvSpStockckDetail.Title = dgvSpStockck.CurrentRow.Cells["ship_name"].Value.ToString() + dtpSpckDate.Text + "物资盘存单";
            dgvSpStockckDetail.Header.Clear();
            dgvSpStockckDetail.Header.Add("盘存单编号:" + dgvSpStockck.CurrentRow.Cells["CHECK_CODE"].Value.ToString() +
                "      盘点人:" + txtStockChecker.Text + "     盘点仓库:" + dgvSpStockck.CurrentRow.Cells["warehouse_name"].Value.ToString());
            dgvSpStockckDetail.Footer.Clear();
            if (txtRemark.Text.Length > 0)
                dgvSpStockckDetail.Footer.Add("备注:" + txtRemark.Text);

            dgvSpStockckDetail.OutPutExcel();
        }

        private void bdNgClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 审阅.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dgvSpStockck.CurrentRow == null || dgvSpStockck.CurrentRow.Cells["DEPOTCHECKID"].Value == null)
            {
                MessageBoxEx.Show("未选中任何信息,无法继续操作！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dgvSpStockck.CurrentRow.Cells["STATE"].Value.ToString() != "1" || dgvSpStockck.CurrentRow.Cells["ISCOMPLETE"].Value.ToString() != "1")
            {
                MessageBoxEx.Show("当前数据状态不正确,无法进行审阅！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //审阅时,不能修改数据,只能添加审阅意见,可以打印导出审阅情况,当进入审阅时,应该可以看到所有的数据.
            string sChkMessage;
            //只能是具备岸端审核功能的才能操作.
            if (!proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_CHECK, out sChkMessage)
                && !proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_LEADER_CHECK, out sChkMessage)
                && !proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_MANAGER_CHECK, out sChkMessage))
            {
                MessageBoxEx.Show("只能是岸端机务审核权限的领导才能操作此功能", "错误操作提醒");
                return;
            }
            openform(4);

        }

        /// <summary>
        /// 打开一个维护窗体.
        /// </summary>
        /// <param name="function">  1 新盘点单,注意同一个仓库上一次盘点未完成不能进行盘点,存在出入库记录未审核也不能进行盘点.
        ///    2 修改未提交的盘点单 不需要建立默认对象,其他与1一致.
        ///    3 被打回的盘点单,或岸端审阅完成的盘点单,等待修改 可以看到理论库存值.
        ///    4 岸端审阅 //只能填写备注,也可以填写明细备注.
        ///    5 船上审核 //可以修改数量,改备注.
        ///    6 岸上审核 //可以修改数量,改备注,如果有必要,将传送给SAP</param>
        private void openform(int function)
        {
            if (dgvSpStockck.CurrentRow != null)
            {
                FrmMaterialStockCheckEdit frmMaterialStockckEdit = new FrmMaterialStockCheckEdit(dtpSpckDate.Tag.ToString(), function);
                frmMaterialStockckEdit.ShowDialog();
                this.Search();
            }
        }

        private void FrmMaterialStockck_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileOperation.FileBoundingOperation.Instance.FileBoundCheck("", "", 0, "");
            instance = null;    //释放窗体实例变量.
            dgvSpStockck.SaveGridView("FrmMaterialDepotCheck.dgvSpStockck");
            dgvSpStockckDetail.SaveGridView("FrmMaterialStockCheck.dgvSpStockckDetail");
        }

        private void dgvSpStockck_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //bdNgEditItem_Click(null, null);
        }

        /// <summary>
        /// 冲账后，克隆盘点数据(用于重新同步到SAP)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClone_Click(object sender, EventArgs e)
        {
            if (dgvSpStockck.CurrentRow == null || dgvSpStockck.CurrentRow.Cells["DEPOTCHECKID"].Value == null)
            {
                MessageBoxEx.Show("未选中任何信息,无法继续操作！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //提示,并写冲账原因;
            OurMessageBox messagebox = new OurMessageBox("确定要对盘点信息进行克隆冲账操作吗？\r如果确认,请描述克隆原因并点击[确定]按钮,否则点击[取消]按钮.",
                  "确认框", DateTime.Now.ToShortDateString() + "被 " + CommonOperation.ConstParameter.UserName + "克隆");
            messagebox.ShowDialog();
            if (!messagebox.Answer) return;

            string err;
            //将原数据完全拷贝过来,包含子表,把审核状态改为（等待岸端确认）.
            if (MaterialDepotCheckService.Instance.CloneStockTake(dgvSpStockck.CurrentRow.Cells["DEPOTCHECKID"].Value.ToString(), messagebox.AnswerTxt, out err))
            {
                MessageBoxEx.Show("克隆完成", "提示");
                this.Search();
            }
            else
            {
                MessageBoxEx.Show("克隆失败,错误原因为" + err, "错误");
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (dgvSpStockck.CurrentRow == null || dgvSpStockck.CurrentRow.Cells["DEPOTCHECKID"].Value == null)
            {
                MessageBoxEx.Show("未选中任何信息,无法继续操作！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //审核应该在岸端船端分别可以点击,效果不同,船端是部门长审核或船长审核,审核完毕填写船端审核人,改状态,
            //岸端是相应审核权限的人员审核,审核后也改状态.
            //审阅时,不能修改数据,只能添加审阅意见,可以打印导出审阅情况,当进入审阅时,应该可以看到所有的数据.
            string sChkMessage;
            //只能是具备岸端审核功能的才能操作.
            if (CommonOperation.ConstParameter.IsLandVersion && (proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_CHECK, out sChkMessage)
                || proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_LEADER_CHECK, out sChkMessage)
                || proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_MANAGER_CHECK, out sChkMessage)))
            {
                openform(6);
            }
            else if (!CommonOperation.ConstParameter.IsLandVersion &&
                (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS || CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER))
            {
                openform(5);
            }
            else
            {
                MessageBoxEx.Show("当前操作者不具备审核权限,无法完成审核操作", "错误提示");
            }
        }

        private void btnBanlance_Click(object sender, EventArgs e)
        {
            if (dgvSpStockck.CurrentRow == null || dgvSpStockck.CurrentRow.Cells["DEPOTCHECKID"].Value == null)
            {
                MessageBoxEx.Show("未选中任何信息,无法继续操作！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //提示,并写冲账原因;
            OurMessageBox messagebox = new OurMessageBox("确定要对已经入库的单据进行冲账操作吗？\r如果确认,请描述冲账原因并点击[确定]按钮,否则点击[取消]按钮.",
                  "确认框", DateTime.Now.ToShortDateString() + "被 " + CommonOperation.ConstParameter.UserName + "冲账");
            messagebox.ShowDialog();
            if (!messagebox.Answer) return;

            string err;
            int stateCode = 0;

            //将原数据完全拷贝过来,包含子表,同时把岸端确认人和时间修改成当前人员.
            if (MaterialDepotCheckService.Instance.StrikeABalance(dgvSpStockck.CurrentRow.Cells["DEPOTCHECKID"].Value.ToString(), messagebox.AnswerTxt, out err))
            {
                if (StorageConfig.reverseAccount != null)
                {
                    if (!StorageConfig.reverseAccount(dgvSpStockck.CurrentRow.Cells["DEPOTCHECKID"].Value.ToString(), out stateCode, out err))
                    {
                        MessageBoxEx.Show("将冲账数据传递给SAP时出现错误,错误提示参考:\r" + err);
                        MaterialDepotCheckService.Instance.RemoveABalance(dgvSpStockck.CurrentRow.Cells["DEPOTCHECKID"].Value.ToString(), out err);
                        return;
                    }
                }
                if (stateCode == 0)
                    MessageBoxEx.Show("成功撤销上报SAP操作.");
                else
                    MessageBoxEx.Show("此预算已经导入到SAP中,无法撤销,已经做SAP冲账处理.");
                this.Search();
            }
            else
            {
                MessageBoxEx.Show("冲账失败,错误原因为" + err);
            }

        }

        private void dgvSpStockck_Sorted(object sender, EventArgs e)
        {
            resetStrikeBalanceColor();
        }
        #endregion


        #region IRemindViewState 成员

        public void SetRemindViewApprovalState()
        {
            if (CommonOperation.ConstParameter.IsLandVersion)
                ucShipSelect1.SelectedText("所有船");
            cboChkState.Text = "全部";
            Search();
        }

        public void SetRemindViewInformState()
        {
        }

        #endregion
    }
}