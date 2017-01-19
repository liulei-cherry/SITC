/****************************************************************************************************
* Copyright (C) 2007 大连陆海科技有限公司 版权所有
* 文 件 名：FrmSpareOut.cs
* 创 建 人：徐正本
* 创建时间：2010-5-4
* 标    题：备件出库业务窗体
* 功能描述：实现备件出库业务窗体上的相关功能
*          本页面有三个情况下使用，一是直接出库单填写时编辑，二是通过其他界面点击出库，传入出库备件id集合出库，三新增出库单
* 修 改 人：徐正本
* 修改时间：2011-8-3
* 修改内容：将业务增加审核流程,根据配置项
* StorageConfig.StorageChangeNeedShipCheck 及 StorageChangeNeedLandCheck 是否需要审核,再配合
* 当前是船端还是岸端,将审核流程实现到具体界面中,同时也修改了后台的存储表,使用最新的出出库用同一套表的方案.
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
    /// 备件出库业务窗体.
    /// </summary>
    public partial class FrmSpareOut : CommonViewer.BaseForm.FormBase, CommonOperation.Interfaces.IRemindViewState
    {
        private CommonOperation.Functions.ProxyRight proxyRight = CommonOperation.Functions.ProxyRight.Instance;//权限代理业务类.
        private bool loaded = false;

        #region 窗体单实例模型


        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmSpareOut instance = new FrmSpareOut();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmSpareOut Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmSpareOut.instance = new FrmSpareOut();
                }

                return FrmSpareOut.instance;
            }
        }

        #endregion

        #region 窗体建立部分

        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmSpareOut()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSpareOut_Load(object sender, EventArgs e)
        {
            ucShipSelect1.ChangeSelectedState(true, true);
            //查询条件默认为3个月的数据.
            if (dtpStartDate.Value > DateTime.Now.AddMonths(-12))
                dtpStartDate.Value = DateTime.Now.AddMonths(-12);
            dtpEndDate.Value = DateTime.Now.AddMonths(1);
            if (!this.checkRight()) return;      //功能权限校验.
            this.WindowState = FormWindowState.Maximized;//窗体最大化.
            loaded = true;
            this.setBindingSource();//设置数据源.
            this.setDataGridView(); //设置网格控件dgvSpOut的隐藏列与标头的设置.
            this.bindingCtrols();   //绑定窗体控件.
        }

        /// <summary>
        /// 设置备件出库单信息的bindingSource数据源，每次查询的都是指定船名的备件出库信息。.
        /// </summary>
        private void setBindingSource()
        {
            if (!loaded) return;
            string shipId = ucShipSelect1.GetId();       //船舶Id
            string startDate = dtpStartDate.Value.ToShortDateString();  //起始日期.
            string endDate = dtpEndDate.Value.ToShortDateString();      //结束日期.
            DataTable dtbSpareOut = SpareDepotOperationService.Instance.GetSpareOperation(false, shipId, startDate, endDate,
                !cbOthersData.Checked, cbOnlyUnfinished.Checked);//取得备件出库单信息的DataTable对象.
            bindingSourceMain.DataSource = dtbSpareOut;//备件出库信息的数据源设置.
            dgvSpOut.DataSource = bindingSourceMain;
            resetStrikeBalanceColor();
        }
        private void resetStrikeBalanceColor()
        {
            //刷新冲账记录.
            for (int i = 0; i < dgvSpOut.Rows.Count; i++)
            {
                if (dgvSpOut.Rows[i].Cells["StrikeToBalance"].Value.ToString() == "1")
                {
                    dgvSpOut.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
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
                    MessageBoxEx.Show("必须具备【岸端物资管理权限】或【备件岸端审核】权限才能看到数据！");
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
        /// 设置备件出库信息网格控件dgvSpOut的隐藏列与显示标题.
        /// </summary>
        private void setDataGridView()
        {
            dgvSpOut.LoadGridView("FrmSpareOut.dgvSpOut");
            dgvSpOut.Columns["DEPOTOPERID"].Visible = false;
            dgvSpOut.Columns["ship_id"].Visible = false;
            dgvSpOut.Columns["ship_name"].Visible = true;
            dgvSpOut.Columns["OPERATION_PERSON_POSTID"].Visible = false;
            dgvSpOut.Columns["iscomplete"].Visible = false;
            dgvSpOut.Columns["remark"].Visible = false;
            dgvSpOut.Columns["CHECKDATE"].Visible = false;
            dgvSpOut.Columns["hasBeenBalanced"].Visible = false;
            dgvSpOut.Columns["SHIPCHECKER"].Visible = false;
            dgvSpOut.Columns["BALANCEDEPOTOPERID"].Visible = false;
            dgvSpOut.Columns["StrikeToBalance"].Visible = false;
            dgvSpOut.Columns["OPERATION_CODE"].Visible = false;
            dgvSpOut.Columns["state"].Visible = false;
            dgvSpOut.Columns["ship_name"].HeaderText = "船舶";
            dgvSpOut.Columns["LANDCHECKER"].HeaderText = "岸端审核人";
            dgvSpOut.Columns["statename"].HeaderText = "当前状态";
            dgvSpOut.Columns["DEPARTNAME"].HeaderText = "出库部门";
            dgvSpOut.Columns["OPERATION_PERSON"].HeaderText = "出库人";
            dgvSpOut.Columns["OPERATION_DATE"].HeaderText = "出库日期";

            if (dgvSpOut.Columns["f"] == null)
            {
                DataGridViewCheckBoxColumn tempFinishedC = new DataGridViewCheckBoxColumn();
                tempFinishedC.Name = "f";
                tempFinishedC.Width = 50;
                dgvSpOut.Columns.Insert(0, tempFinishedC);
                tempFinishedC.DataPropertyName = "iscomplete";
                tempFinishedC.HeaderText = "已提交";
            }

        }

        /// <summary>
        /// 绑定窗体控件（出库单信息控件的绑定）.
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
        /// 设置备件出库单明细信息的bindingSource数据源，每次查询的都是指定出库单的明细信息数据.
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <param name="SpareOutId">出库单信息Id</param>
        private void setBindingSourceDetail(string SpareOutId)
        {
            DataTable dtbSpareOutDetail = SpareDepotOperationService.Instance.GetSpareOutDetail(SpareOutId);//取得备件出库单明细信息的DataTable对象.
            bindingSourceDetail.DataSource = dtbSpareOutDetail;//备件出库明细信息的数据源设置.
            dgvSpOutDetail.DataSource = bindingSourceDetail;
            dgvSpOutDetail.LoadGridView("FrmSpareOut.dgvSpOutDetail");
            dgvSpOutDetail.Columns["SPAREOPERDETAIL_ID"].Visible = false;
            dgvSpOutDetail.Columns["DEPOTOPERID"].Visible = false;
            dgvSpOutDetail.Columns["spare_Id"].Visible = false;
            dgvSpOutDetail.Columns["warehouse_id"].Visible = false;
            dgvSpOutDetail.Columns["ship_id"].Visible = false;
            dgvSpOutDetail.Columns["stocksum"].Visible = false;

            dgvSpOutDetail.Columns["ISSAP"].HeaderText = "备件类型";
            dgvSpOutDetail.Columns["spare_name"].HeaderText = "备件名称";
            dgvSpOutDetail.Columns["partnumber"].HeaderText = "配件号|规格";
            dgvSpOutDetail.Columns["warehouse_name"].HeaderText = "仓库名称";
            dgvSpOutDetail.Columns["COUNT"].HeaderText = "出库数量";
            dgvSpOutDetail.Columns["COUNT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSpOutDetail.Columns["unit_name"].HeaderText = "单位";
            dgvSpOutDetail.Columns["unit_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSpOutDetail.Columns["type_code"].HeaderText = "出库方式";
            dgvSpOutDetail.Columns["remark"].HeaderText = "备注";
            dgvSpOutDetail.SetDataGridViewNoSort();

        }

        private void dgvSpOut_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string SpareOutId = "";                  //当前网格dgvMatIn中的出库单信息主键.
            string SpareOutDepartment = "";                //物料出库部门.
            string SpareOutDate = "";                //物料出库日期.
            DateTime dSpareOutDate;
            string SpareOutPerson = "";                //物料出库人.
            string shipId; //取当前船舶Id

            if (dgvSpOut.Rows[e.RowIndex].Cells["DEPOTOPERID"].Value != null)
            {
                SpareOutId = dgvSpOut.Rows[e.RowIndex].Cells["DEPOTOPERID"].Value.ToString();
                SpareOutDepartment = dgvSpOut.Rows[e.RowIndex].Cells["DEPARTNAME"].Value.ToString();
                SpareOutDate = dgvSpOut.Rows[e.RowIndex].Cells["OPERATION_DATE"].Value.ToString();
                if (DateTime.TryParse(SpareOutDate, out dSpareOutDate))
                {
                    SpareOutDate = dSpareOutDate.ToShortDateString();
                }
                else
                {
                    SpareOutDate = "";
                }
                SpareOutPerson = dgvSpOut.Rows[e.RowIndex].Cells["OPERATION_PERSON"].Value.ToString();
                shipId = dgvSpOut.Rows[e.RowIndex].Cells["ship_id"].Value.ToString();
                this.setBindingSourceDetail(SpareOutId);

                btnCheck.Enabled = (btnCheck.Visible && ((CommonOperation.ConstParameter.IsLandVersion && int.Parse(dgvSpOut.Rows[e.RowIndex].Cells["state"].Value.ToString()) == 2)
                    || (!CommonOperation.ConstParameter.IsLandVersion && int.Parse(dgvSpOut.Rows[e.RowIndex].Cells["state"].Value.ToString()) == 1)));

                //btnBalance.Enabled = (btnCheck.Visible && CommonOperation.ConstParameter.IsLandVersion && int.Parse(dgvSpOut.Rows[e.RowIndex].Cells["state"].Value.ToString()) >= 4
                //    && dgvSpOut.Rows[e.RowIndex].Cells["StrikeToBalance"].Value.ToString() != "1" && dgvSpOut.Rows[e.RowIndex].Cells["hasBeenBalanced"].Value.ToString() == "0");

                btnClone.Enabled = dgvSpOut.Rows[e.RowIndex].Cells["StrikeToBalance"].Value.ToString() != "0" || dgvSpOut.Rows[e.RowIndex].Cells["hasBeenBalanced"].Value.ToString() != "0";

                //绑定大文档.
                FileOperation.FileBoundingOperation.Instance.FileBoundCheck(SpareOutId, (string.IsNullOrEmpty(SpareOutDepartment) ? "" : SpareOutDepartment)
                    + (string.IsNullOrEmpty(SpareOutDate) ? "" : SpareOutDate) + (string.IsNullOrEmpty(SpareOutPerson) ? "" : SpareOutPerson),
                    CommonOperation.Enum.FileBoundingTypes.SPEARIN, shipId);
            }
        }

        #endregion

        #region 过滤区域
        /// <summary>
        /// 出库单记录筛选.
        /// </summary>
        private void Search()
        {
            this.setBindingSource();
            //如果出库单没有记录，则出库单明细也不应该有数据.
            if (loaded && dgvSpOut.Rows.Count == 0)
            {
                this.setBindingSourceDetail("");
            }
        }

        /// <summary>
        /// 出库单记录筛选（在起始日期事件中执行）.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpStartDate_CloseUp(object sender, EventArgs e)
        {
            this.Search();
        }

        /// <summary>
        /// 出库单记录筛选（在结束日期事件中执行）.
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
            if (dgvSpOut.CurrentRow != null)
            {
                if (dgvSpOut.CurrentRow.Cells["hasBeenBalanced"].Value.ToString() != "0" || (dgvSpOut.CurrentRow.Cells["BALANCEDEPOTOPERID"].Value != null
                    && dgvSpOut.CurrentRow.Cells["BALANCEDEPOTOPERID"].Value.ToString().Length > 0))
                {
                    MessageBoxEx.Show("冲账单据或被冲账原始单据均不允许被编辑!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
                //只有操作者自己（或同岗位）可以编辑没有完成的单据.
                else if (dgvSpOut.CurrentRow.Cells["iscomplete"].Value.ToString() == "1" && int.Parse(dgvSpOut.CurrentRow.Cells["state"].Value.ToString()) > 3)
                {
                    MessageBoxEx.Show("已经‘审核完毕,真正出库’的出库单不允许再次被编辑。" +
                        "\r如果当前出库单有数据错误问题，请形成对应的出库单进行冲账！",
                        "警告", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
                if (dgvSpOut.CurrentRow.Cells["OPERATION_PERSON"].Value.ToString() != CommonOperation.ConstParameter.UserName
                    || (dgvSpOut.CurrentRow.Cells["OPERATION_PERSON_POSTID"].Value.ToString() != CommonOperation.ConstParameter.LoginUserInfo.PostId))
                {
                    MessageBoxEx.Show("仅发起者可以对出库单进行编辑", "错误操作提醒");
                    return;
                }

                FrmSpareOutEdit frmSpareOutEdit = new FrmSpareOutEdit(ucDepartmentSelect1.Tag.ToString());
                frmSpareOutEdit.ShowDialog();
                this.Search();
            }
        }

        /// <summary>
        /// 备件出库单信息添加操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            if (!loaded) return;
            FrmSpareOutEdit frmSpareOutEdit = new FrmSpareOutEdit();
            frmSpareOutEdit.ShowDialog();
            this.Search();
        }
        /// <summary>
        /// 克隆操作,只能对冲账或者被冲账的数据进行clone操作.
        /// </summary>
        private void btnClone_Click(object sender, EventArgs e)
        {
            if (dgvSpOut.CurrentRow != null && (dgvSpOut.CurrentRow.Cells["StrikeToBalance"].Value.ToString() != "1" || dgvSpOut.CurrentRow.Cells["hasBeenBalanced"].Value.ToString() != "0"))
            {
                MessageBoxEx.Show("仅允许克隆'冲账'或'被冲账'的单据,形成另一条待修改的新单据!");
                return;
            }
            string err;
            string id;
            if (dgvSpOut.CurrentRow.Cells["BALANCEDEPOTOPERID"].Value != null && dgvSpOut.CurrentRow.Cells["BALANCEDEPOTOPERID"].Value.ToString().Length > 0)
            {
                id = dgvSpOut.CurrentRow.Cells["BALANCEDEPOTOPERID"].Value.ToString();
            }
            else
            {
                id = dgvSpOut.CurrentRow.Cells["DEPOTOPERID"].Value.ToString();
            }
            if (!SpareDepotOperationService.Instance.CloneABalancedBill(id, dgvSpOut.CurrentRow.Cells["ship_id"].Value.ToString(), out err))
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

            if (dgvSpOut.CurrentRow != null && dgvSpOut.CurrentRow.Cells["DEPOTOPERID"].Value != null)
            {
                //如果当前的内容是可以删除的，状态、本人可以删除、领导可以删除；.
                if (dgvSpOut.CurrentRow.Cells["iscomplete"].Value.ToString() == "1")
                {
                    MessageBoxEx.Show("仅有‘未完成’状态可以被删除，" +
                        "\r如果当前出库单有数据错误问题，请形成对应的出库单进行冲账！",
                        "警告", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
                if (dgvSpOutDetail.Rows.Count > 0)
                {
                    if (MessageBoxEx.Show("当前备件出库存在明细数据，删除此信息时会同时删掉其明细数据，请确认您要删除此信息？！",
                        "警告", MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        return;
                }
                //更新结果报告.
                if (SpareDepotOperationService.Instance.deleteUnit(dgvSpOut.CurrentRow.Cells["DEPOTOPERID"].Value.ToString(), out err))
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

        private void dgvSpOut_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (CommonOperation.ConstParameter.IsLandVersion) return;
            //bdNgEditItem_Click(null, null);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //备件消耗月报表.
            FrmSpareMonthOutReport frm = new FrmSpareMonthOutReport();
            frm.ShowDialog();
        }

        private void btnBalance_Click(object sender, EventArgs e)
        {
            if (dgvSpOut.CurrentRow != null && dgvSpOut.CurrentRow.Cells["DEPOTOPERID"].Value != null)
            {
                //提示,并写冲账原因;
                OurMessageBox messagebox = new OurMessageBox("确定要对已经出库的单据进行冲账操作吗？\r如果确认,请描述冲账原因并点击[确定]按钮,否则点击[取消]按钮.",
                      "确认框", DateTime.Now.ToShortDateString() + "被 " + CommonOperation.ConstParameter.UserName + "冲账");
                messagebox.ShowDialog();
                if (!messagebox.Answer) return;

                string err;
                int stateCode = 0;
                //将原数据完全拷贝过来,包含子表,同时把岸端确认人和时间修改成当前人员.
                if (SpareDepotOperationService.Instance.StrikeABalance(dgvSpOut.CurrentRow.Cells["DEPOTOPERID"].Value.ToString(), messagebox.AnswerTxt, out err))
                {
                    if (StorageConfig.reverseAccount != null)
                    {
                        if (!StorageConfig.reverseAccount(dgvSpOut.CurrentRow.Cells["DEPOTOPERID"].Value.ToString(), out stateCode, out err))
                        {
                            MessageBoxEx.Show("将冲账数据传递给SAP时出现错误,错误提示参考:\r" + err);
                            SpareDepotOperationService.Instance.RemoveABalance(dgvSpOut.CurrentRow.Cells["DEPOTOPERID"].Value.ToString(), out err);
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
            //当当前等待出船端审核,当前未船端,才能操作;
            if (dgvSpOut.CurrentRow != null && cbxIsComplete.Checked)
            {
                if ((CommonOperation.ConstParameter.IsLandVersion && int.Parse(dgvSpOut.CurrentRow.Cells["state"].Value.ToString()) == 2)
                    || (!CommonOperation.ConstParameter.IsLandVersion && int.Parse(dgvSpOut.CurrentRow.Cells["state"].Value.ToString()) == 1))
                {
                    FrmSpareOutEdit frmSpareOutEdit = new FrmSpareOutEdit(ucDepartmentSelect1.Tag.ToString());
                    frmSpareOutEdit.ShowDialog();
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
        /// 窗体关闭时对网格dgvSpOutDetail的一些必填值进行校验并释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSpareOut_FormClosing(object sender, FormClosingEventArgs e)
        {
            //清除大文档绑定功能.
            FileOperation.FileBoundingOperation.Instance.FileBoundCheck("", "", 0, "");
            instance = null;    //释放窗体实例变量.
            dgvSpOutDetail.SaveGridView("FrmSpareOut.dgvSpOutDetail");
            dgvSpOut.SaveGridView("FrmSpareOut.dgvSpOut");
        }
        private void dgvSpOut_Sorted(object sender, EventArgs e)
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