/****************************************************************************************************
* Copyright (C) 2007 大连陆海科技有限公司 版权所有
* 文 件 名：FrmMaterialIn.cs
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
using StorageManage.Services;
using CommonViewer.BaseControl;
using CommonViewer.BaseControlService;

namespace StorageManage.Viewer
{
    /// <summary>
    /// 物资入库业务窗体.
    /// </summary>
    public partial class FrmMaterialIn : CommonViewer.BaseForm.FormBase, CommonOperation.Interfaces.IRemindViewState
    {
        private CommonOperation.Functions.ProxyRight proxyRight = CommonOperation.Functions.ProxyRight.Instance;//权限代理业务类.
        private bool loaded = false;

        #region 窗体单实例模型


        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmMaterialIn instance = new FrmMaterialIn();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmMaterialIn Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmMaterialIn.instance = new FrmMaterialIn();
                }

                return FrmMaterialIn.instance;
            }
        }

        #endregion

        #region 窗体建立部分
        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmMaterialIn()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMaterialIn_Load(object sender, EventArgs e)
        {
            ucShipSelect1.ChangeSelectedState(true, true);
            //查询条件默认为3个月的数据.
            if (dtpStartDate.Value > DateTime.Now.AddMonths(-12)) dtpStartDate.Value = DateTime.Now.AddMonths(-12);
            dtpEndDate.Value = DateTime.Now.AddMonths(1);
            if (!this.checkRight()) return;      //功能权限校验.
            this.WindowState = FormWindowState.Maximized;//窗体最大化.
            loaded = true;
            this.setBindingSource();//设置数据源.
            this.setDataGridView(); //设置网格控件dgvSpIn的隐藏列与标头的设置.
            this.bindingCtrols();   //绑定窗体控件.
        }

        /// <summary>
        /// 设置物资入库单信息的bindingSource数据源，每次查询的都是指定船名的物资入库信息。.
        /// </summary>
        private void setBindingSource()
        {
            if (!loaded) return;
            string shipId = ucShipSelect1.GetId();       //船舶Id
            string startDate = dtpStartDate.Value.ToShortDateString();  //起始日期.
            string endDate = dtpEndDate.Value.ToShortDateString();      //结束日期.
            DataTable dtbMaterialIn = MaterialDepotOperationService.Instance.GetMaterialOperation(true, shipId, startDate, endDate,
                !cbOthersData.Checked, cbOnlyUnfinished.Checked);//取得物资入库单信息的DataTable对象.
            bindingSourceMain.DataSource = dtbMaterialIn;//物资入库信息的数据源设置.
            dgvSpIn.DataSource = bindingSourceMain;
            resetStrikeBalanceColor();
        }
        private void resetStrikeBalanceColor()
        {
            //刷新冲账记录.
            for (int i = 0; i < dgvSpIn.Rows.Count; i++)
            {
                if (dgvSpIn.Rows[i].Cells["StrikeToBalance"].Value.ToString() == "1")
                {
                    dgvSpIn.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }
        /// <summary>
        /// 界面功能权限的校验.
        /// </summary>
        private bool checkRight()
        {
            btnCheck.Enabled = false;
            //btnBalance.Enabled = false;
            btnClone.Enabled = false;
            string err;
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                //
                cbOthersData.Checked = false;
                cbOthersData.Visible = false;
                bdNgAddNewItem.Visible = false;
                bdNgDeleteItem.Visible = false;
                btnCheck.Visible = false;
                bdNgEditItem.Visible = false;
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
                //btnBalance.Visible = proxyRight.CheckRight(CommonOperation.ConstParameter.STRIKE_A_BALANCE, out err);
            }
            else
            {
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
                    cbOthersData.Enabled = false;
                }
                btnCheck.Visible = (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER || CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS);

                //高级船员，非领导岗位.
                if (CommonOperation.ConstParameter.LoginUserInfo.ISHIGHLEVELSHIPMAN)
                {
                    //设置需要权限控制的控件的可见性.
                    bdNgAddNewItem.Visible = true;
                    bdNgDeleteItem.Visible = true;
                    bdNgEditItem.Visible = true;
                }
                else
                {
                    bdNgAddNewItem.Visible = false;
                    bdNgDeleteItem.Visible = false;
                    bdNgEditItem.Visible = false;
                    MessageBoxEx.Show("除了船舶的高级船员外，其他人登录此界面也不能操作及看到任何数据！");
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 设置物资入库信息网格控件dgvSpIn的隐藏列与显示标题.
        /// </summary>
        private void setDataGridView()
        {
            dgvSpIn.LoadGridView("FrmMaterialIn.dgvSpIn");
            dgvSpIn.Columns["DEPOTOPERID"].Visible = false;
            dgvSpIn.Columns["ship_id"].Visible = false;
            dgvSpIn.Columns["ship_name"].Visible = true;
            dgvSpIn.Columns["OPERATION_PERSON_POSTID"].Visible = false;
            dgvSpIn.Columns["iscomplete"].Visible = false;
            dgvSpIn.Columns["remark"].Visible = false;
            dgvSpIn.Columns["CHECKDATE"].Visible = false;
            dgvSpIn.Columns["hasBeenBalanced"].Visible = false;
            dgvSpIn.Columns["SHIPCHECKER"].Visible = false;
            dgvSpIn.Columns["BALANCEDEPOTOPERID"].Visible = false;
            dgvSpIn.Columns["StrikeToBalance"].Visible = false;
            dgvSpIn.Columns["OPERATION_CODE"].Visible = false;
            dgvSpIn.Columns["state"].Visible = false;
            dgvSpIn.Columns["ship_name"].HeaderText = "船舶";
            dgvSpIn.Columns["LANDCHECKER"].HeaderText = "岸端审核人";
            dgvSpIn.Columns["statename"].HeaderText = "当前状态";
            dgvSpIn.Columns["DEPARTNAME"].HeaderText = "入库部门";
            dgvSpIn.Columns["OPERATION_PERSON"].HeaderText = "入库人";
            dgvSpIn.Columns["OPERATION_DATE"].HeaderText = "入库日期";
            dgvSpIn.Columns["INSTORAGETYPENAME"].HeaderText = "入库方式";
            if (dgvSpIn.Columns["f"] == null)
            {
                DataGridViewCheckBoxColumn tempFinishedC = new DataGridViewCheckBoxColumn();
                tempFinishedC.Name = "f";
                tempFinishedC.Width = 50;
                dgvSpIn.Columns.Insert(0, tempFinishedC);
                tempFinishedC.DataPropertyName = "iscomplete";
                tempFinishedC.HeaderText = "已提交";
            }

        }

        /// <summary>
        /// 绑定窗体控件（入库单信息控件的绑定）.
        /// </summary>
        private void bindingCtrols()
        {
            ucDepartmentSelect1.DataBindings.Add("Text", bindingSourceMain, "DEPARTNAME", true);
            ucDepartmentSelect1.DataBindings.Add("Tag", bindingSourceMain, "DEPOTOPERID", true);
            dtpInDate.DataBindings.Add("Text", bindingSourceMain, "OPERATION_DATE", true);
            txtInMan.DataBindings.Add("Text", bindingSourceMain, "OPERATION_PERSON", true);
            txtRemark.DataBindings.Add("Text", bindingSourceMain, "remark", true);
            cbxIsComplete.DataBindings.Add("Checked", bindingSourceMain, "iscomplete", true);
            txtStateName.DataBindings.Add("Text", bindingSourceMain, "statename", true);
            txtShipCheck.DataBindings.Add("Text", bindingSourceMain, "SHIPCHECKER", true);
            txtLandCheck.DataBindings.Add("Text", bindingSourceMain, "LANDCHECKER", true);
            dtpCheckDate.DataBindings.Add("Text", bindingSourceMain, "CHECKDATE", true);
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
            dgvSpInDetail.LoadGridView("FrmMaterialIn.dgvSpInDetail");
            dgvSpInDetail.Columns["MATERIALOPERDETAIL_ID"].Visible = false;
            dgvSpInDetail.Columns["DEPOTOPERID"].Visible = false;
            dgvSpInDetail.Columns["Material_Id"].Visible = false;
            dgvSpInDetail.Columns["warehouse_id"].Visible = false;
            dgvSpInDetail.Columns["ship_id"].Visible = false;
            dgvSpInDetail.Columns["stocksum"].Visible = false;

            //dgvSpInDetail.Columns["CURRENCYID"].Visible = false;
            //dgvSpInDetail.Columns["CURRENCYCODE"].Visible = false;
            //dgvSpInDetail.Columns["AMOUNT"].Visible = false;
            //dgvSpInDetail.Columns["SERVICEPROVIDERID"].Visible = false;
            //dgvSpInDetail.Columns["MANUFACTURER_NAME"].Visible = false;
            //if (btnCheck.Visible)
            //{
            //    dgvSpInDetail.Columns["CURRENCYCODE"].HeaderText = "货币种类";
            //    dgvSpInDetail.Columns["AMOUNT"].HeaderText = "总金额";
            //    dgvSpInDetail.Columns["MANUFACTURER_NAME"].HeaderText = "服务商";
            //    dgvSpInDetail.Columns["CURRENCYCODE"].Visible = true;
            //    dgvSpInDetail.Columns["AMOUNT"].Visible = true;
            //    dgvSpInDetail.Columns["MANUFACTURER_NAME"].Visible = true;
            //}
            dgvSpInDetail.Columns["MATERIAL_name"].HeaderText = "物资名称";
            dgvSpInDetail.Columns["MATERIAL_CODE"].HeaderText = "物资编码";
            dgvSpInDetail.Columns["MATERIAL_SPEC"].HeaderText = "规格型号";
            dgvSpInDetail.Columns["warehouse_name"].HeaderText = "仓库名称";
            dgvSpInDetail.Columns["COUNT"].HeaderText = "入库数量";
            dgvSpInDetail.Columns["COUNT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSpInDetail.Columns["unit_name"].HeaderText = "单位";
            dgvSpInDetail.Columns["unit_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSpInDetail.Columns["type_code"].HeaderText = "入库方式";
            dgvSpInDetail.Columns["order_code"].HeaderText = "对应订单号";
            dgvSpInDetail.Columns["remark"].HeaderText = "备注";
            dgvSpInDetail.SetDataGridViewNoSort();

        }

        private void dgvSpIn_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string MaterialInId = "";                  //当前网格dgvMatIn中的入库单信息主键.
            string MaterialInDepartment = "";                //物资入库部门.
            string MaterialInDate = "";                //物资入库日期.
            DateTime dMaterialInDate;
            string MaterialInPerson = "";                //物资入库人.
            string shipId; //取当前船舶Id

            if (dgvSpIn.Rows[e.RowIndex].Cells["DEPOTOPERID"].Value != null)
            {
                MaterialInId = dgvSpIn.Rows[e.RowIndex].Cells["DEPOTOPERID"].Value.ToString();
                MaterialInDepartment = dgvSpIn.Rows[e.RowIndex].Cells["DEPARTNAME"].Value.ToString();
                MaterialInDate = dgvSpIn.Rows[e.RowIndex].Cells["OPERATION_DATE"].Value.ToString();
                if (DateTime.TryParse(MaterialInDate, out dMaterialInDate))
                {
                    MaterialInDate = dMaterialInDate.ToShortDateString();
                }
                else
                {
                    MaterialInDate = "";
                }
                MaterialInPerson = dgvSpIn.Rows[e.RowIndex].Cells["OPERATION_PERSON"].Value.ToString();
                shipId = dgvSpIn.Rows[e.RowIndex].Cells["ship_id"].Value.ToString();
                this.setBindingSourceDetail(MaterialInId);

                btnCheck.Enabled = (btnCheck.Visible && ((CommonOperation.ConstParameter.IsLandVersion && int.Parse(dgvSpIn.Rows[e.RowIndex].Cells["state"].Value.ToString()) == 2)
                    || (!CommonOperation.ConstParameter.IsLandVersion && int.Parse(dgvSpIn.Rows[e.RowIndex].Cells["state"].Value.ToString()) == 1)));

                //btnBalance.Enabled = (btnCheck.Visible && CommonOperation.ConstParameter.IsLandVersion && int.Parse(dgvSpIn.Rows[e.RowIndex].Cells["state"].Value.ToString()) >= 4
                //    && dgvSpIn.Rows[e.RowIndex].Cells["StrikeToBalance"].Value.ToString() != "1" && dgvSpIn.Rows[e.RowIndex].Cells["hasBeenBalanced"].Value.ToString() == "0");

                btnClone.Enabled = dgvSpIn.Rows[e.RowIndex].Cells["StrikeToBalance"].Value.ToString() != "0" || dgvSpIn.Rows[e.RowIndex].Cells["hasBeenBalanced"].Value.ToString() != "0";

                //绑定大文档.
                FileOperation.FileBoundingOperation.Instance.FileBoundCheck(MaterialInId, (string.IsNullOrEmpty(MaterialInDepartment) ? "" : MaterialInDepartment)
                    + (string.IsNullOrEmpty(MaterialInDate) ? "" : MaterialInDate) + (string.IsNullOrEmpty(MaterialInPerson) ? "" : MaterialInPerson),
                    CommonOperation.Enum.FileBoundingTypes.SPEARIN, shipId);
            }
        }

        #endregion

        #region 过滤区域
        /// <summary>
        /// 入库单记录筛选.
        /// </summary>
        private void Search()
        {
            this.setBindingSource();
            //如果入库单没有记录，则入库单明细也不应该有数据.
            if (loaded && dgvSpIn.Rows.Count == 0)
            {
                this.setBindingSourceDetail("");
            }
        }

        /// <summary>
        /// 入库单记录筛选（在起始日期事件中执行）.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpStartDate_CloseUp(object sender, EventArgs e)
        {
            this.Search();
        }

        /// <summary>
        /// 入库单记录筛选（在结束日期事件中执行）.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpEndDate_CloseUp(object sender, EventArgs e)
        {
            this.Search();
        }

        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            this.Search();
        }

        private void cbOthersData_CheckedChanged(object sender, EventArgs e)
        {
            this.Search();
        }

        private void cbOnlyUnfinished_CheckedChanged(object sender, EventArgs e)
        {
            this.Search();
        }

        #endregion

        #region 按钮操作部分
        private void bdNgEditItem_Click(object sender, EventArgs e)
        {
            if (dgvSpIn.CurrentRow != null)
            {
                if (dgvSpIn.CurrentRow.Cells["hasBeenBalanced"].Value.ToString() != "0" ||
                    (dgvSpIn.CurrentRow.Cells["BALANCEDEPOTOPERID"].Value != null && dgvSpIn.CurrentRow.Cells["BALANCEDEPOTOPERID"].Value.ToString().Length > 0))
                {
                    MessageBoxEx.Show("冲账单据或被冲账原始单据均不允许被编辑!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
                //只有操作者自己（或同岗位）可以编辑没有完成的单据.
                else if (dgvSpIn.CurrentRow.Cells["iscomplete"].Value.ToString() == "1" && int.Parse(dgvSpIn.CurrentRow.Cells["state"].Value.ToString()) >
                    (CommonOperation.ConstParameter.IsLandVersion ? 3 : 1))
                {
                    MessageBoxEx.Show("您不具备维护当前状态入库单的权限。" +
                        "\r如果当前入库单有数据错误问题，请形成对应的出库单进行冲账！",
                        "警告", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
                if (dgvSpIn.CurrentRow.Cells["OPERATION_PERSON"].Value.ToString() != CommonOperation.ConstParameter.UserName
                    || (dgvSpIn.CurrentRow.Cells["OPERATION_PERSON_POSTID"].Value.ToString() != CommonOperation.ConstParameter.LoginUserInfo.PostId))
                {
                    MessageBoxEx.Show("仅发起者可以对入库单进行编辑", "错误操作提醒");
                    return;
                }

                FrmMaterialInEdit frmMaterialInEdit = new FrmMaterialInEdit(ucDepartmentSelect1.Tag.ToString());
                frmMaterialInEdit.ShowDialog();
                this.Search();
            }
        }

        /// <summary>
        /// 物资入库单信息添加操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            if (!loaded) return;
            FrmMaterialInEdit frmMaterialInEdit = new FrmMaterialInEdit();
            frmMaterialInEdit.ShowDialog();
            this.Search();
        }
        /// <summary>
        /// 克隆操作,只能对冲账或者被冲账的数据进行clone操作.
        /// </summary>
        private void btnClone_Click(object sender, EventArgs e)
        {
            if (dgvSpIn.CurrentRow != null && (dgvSpIn.CurrentRow.Cells["StrikeToBalance"].Value.ToString() != "1" || dgvSpIn.CurrentRow.Cells["hasBeenBalanced"].Value.ToString() != "0"))
            {
                MessageBoxEx.Show("仅允许克隆'冲账'或'被冲账'的单据,形成另一条待修改的新单据!");
                return;
            }
            string err;
            string id;
            if (dgvSpIn.CurrentRow.Cells["BALANCEDEPOTOPERID"].Value != null && dgvSpIn.CurrentRow.Cells["BALANCEDEPOTOPERID"].Value.ToString().Length > 0)
            {
                id = dgvSpIn.CurrentRow.Cells["BALANCEDEPOTOPERID"].Value.ToString();
            }
            else
            {
                id = dgvSpIn.CurrentRow.Cells["DEPOTOPERID"].Value.ToString();
            }
            if (!MaterialDepotOperationService.Instance.CloneABalancedBill(id, dgvSpIn.CurrentRow.Cells["ship_id"].Value.ToString(), out err))
            {
                MessageBoxEx.Show("操作失败,失败原因是" + err, "系统提示");
            }
            Search();
        }
        /// <summary>
        /// 删除操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.

            if (dgvSpIn.CurrentRow != null && dgvSpIn.CurrentRow.Cells["DEPOTOPERID"].Value != null)
            {
                //如果当前的内容是可以删除的，状态、本人可以删除、领导可以删除；.
                if (dgvSpIn.CurrentRow.Cells["iscomplete"].Value.ToString() == "1")
                {
                    MessageBoxEx.Show("仅有‘未完成’状态可以被删除，" +
                        "\r如果当前入库单有数据错误问题，请形成对应的出库单进行冲账！",
                        "警告", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
                if (dgvSpInDetail.Rows.Count > 0)
                {
                    if (MessageBoxEx.Show("当前物资入库存在明细数据，删除此信息时会同时删掉其明细数据，请确认您要删除此信息？！",
                        "警告", MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        return;
                }
                //更新结果报告.
                if (MaterialDepotOperationService.Instance.deleteUnit(dgvSpIn.CurrentRow.Cells["DEPOTOPERID"].Value.ToString(), out err))
                {
                    MessageBoxEx.Show("删除成功！", "删除成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBoxEx.Show(err, "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                Search();
            }
        }

        private void dgvSpIn_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (CommonOperation.ConstParameter.IsLandVersion) return;
            //bdNgEditItem_Click(null, null);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //物资消耗月报表.
            FrmMaterialMonthInReport frm = new FrmMaterialMonthInReport();
            frm.ShowDialog();
        }

        private void btnBalance_Click(object sender, EventArgs e)
        {
            if (dgvSpIn.CurrentRow != null && dgvSpIn.CurrentRow.Cells["DEPOTOPERID"].Value != null)
            {
                //提示,并写冲账原因;
                OurMessageBox messagebox = new OurMessageBox("确定要对已经入库的单据进行冲账操作吗？\r如果确认,请描述冲账原因并点击[确定]按钮,否则点击[取消]按钮.",
                      "确认框", DateTime.Now.ToShortDateString() + "被 " + CommonOperation.ConstParameter.UserName + "冲账");
                messagebox.ShowDialog();
                if (!messagebox.Answer) return;

                int stateCode = 0;
                string err;
                //将原数据完全拷贝过来,包含子表,同时把岸端确认人和时间修改成当前人员.
                if (MaterialDepotOperationService.Instance.StrikeABalance(dgvSpIn.CurrentRow.Cells["DEPOTOPERID"].Value.ToString(), messagebox.AnswerTxt, out err))
                {
                    if (StorageConfig.reverseAccount != null)
                    {
                        if (!StorageConfig.reverseAccount(dgvSpIn.CurrentRow.Cells["DEPOTOPERID"].Value.ToString(), out stateCode, out err))
                        {
                            MessageBoxEx.Show("将冲账数据传递给SAP时出现错误,错误提示参考:\r" + err);
                            MaterialDepotOperationService.Instance.RemoveABalance(dgvSpIn.CurrentRow.Cells["DEPOTOPERID"].Value.ToString(), out err);
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
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            //当当前数据等待岸端审核,当前为岸端,才能操作;
            //当当前等待出船端审核,当前为船端,才能操作;
            if (dgvSpIn.CurrentRow != null && cbxIsComplete.Checked)
            {
                if ((CommonOperation.ConstParameter.IsLandVersion && int.Parse(dgvSpIn.CurrentRow.Cells["state"].Value.ToString()) == 2)
                    || (!CommonOperation.ConstParameter.IsLandVersion && int.Parse(dgvSpIn.CurrentRow.Cells["state"].Value.ToString()) == 1))
                {
                    FrmMaterialInEdit frmMaterialInEdit = new FrmMaterialInEdit(ucDepartmentSelect1.Tag.ToString());
                    frmMaterialInEdit.ShowDialog();
                    this.Search();
                }
            }
            else
            {
                MessageBoxEx.Show("仅提交审核状态的单据才可以被审核处理!");
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
        /// <summary>
        /// 窗体关闭时对网格dgvSpInDetail的一些必填值进行校验并释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMaterialIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            //清除大文档绑定功能.
            FileOperation.FileBoundingOperation.Instance.FileBoundCheck("", "", 0, "");
            instance = null;    //释放窗体实例变量.
            dgvSpInDetail.SaveGridView("FrmMaterialIn.dgvSpInDetail");
            dgvSpIn.SaveGridView("FrmMaterialIn.dgvSpIn");
        }
        private void dgvSpIn_Sorted(object sender, EventArgs e)
        {
            resetStrikeBalanceColor();
        }
        #endregion
        #region IRemindViewState 成员

        public void SetRemindViewApprovalState()
        {
            if (CommonOperation.ConstParameter.IsLandVersion)
                ucShipSelect1.SelectedText("所有船");
            cbOnlyUnfinished.Checked = true;
            dtpStartDate.Value = new DateTime(2010, 1, 1);
            Search();
        }

        public void SetRemindViewInformState()
        {
            if (CommonOperation.ConstParameter.IsLandVersion)
                ucShipSelect1.SelectedText("所有船");
            cbOnlyUnfinished.Checked = false;
            dtpStartDate.Value = new DateTime(2010, 1, 1);
            Search();
        }

        #endregion
    }
}