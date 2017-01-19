/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmRepairApply.cs
 * 创 建 人：王鹏程
 * 创建时间：2011-7-22
 * 标    题：修理申请业务窗体
 * 功能描述：实现修理申请业务窗体上的相关功能
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BaseInfo.Objects;
using BaseInfo.DataAccess;
using FileOperationBase.FileServices;
using System.IO;
using System.Text;
using FileOperationBase.Services;
using StorageManage;
using CommonViewer.BaseControl;
using Repair.Services;
using Repair.DataObject;
using Maintenance.Viewer;
using Maintenance.DataObject;
using CommonViewer;

namespace Repair.Viewer
{
    public partial class FrmRepairApply : CommonViewer.BaseForm.FormBase, CommonOperation.Interfaces.IRemindViewState
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmRepairApply instance = new FrmRepairApply();
        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmRepairApply Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmRepairApply.instance = new FrmRepairApply();
                }

                return FrmRepairApply.instance;
            }
        }
        public FrmRepairApply()
        {
            InitializeComponent();
        }
        #endregion
        private string lastApplyId = "";
        string shipId; //取当前船舶Id
        private int currentRowIndex = 0;
        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmRepairApply_Load(object sender, EventArgs e)
        {
            CheckRightVisible();      //功能权限校验.
            this.setComboBox();     //设置窗体所需的下拉列表框的数据源.
            this.WindowState = FormWindowState.Maximized;//窗体最大化.
            this.setBindingSource();//设置数据源.
            this.setDataGridView(); //设置网格控件dgvApply的隐藏列与标头的设置.
            CheckRightEnabled();
            ucShipSelect1.ChangeSelectedState(true, true);
            ShipRepairProjectService.Instance.CheckLandOpinionColumnsExists();
        }
        /// <summary>
        /// 绑定修理项目信息.
        /// </summary>
        private void setBindingSource()
        {
            if (CommonOperation.ConstParameter.IsLandVersion)
                shipId = ucShipSelect1.GetId();//船舶.
            else
                shipId = CommonOperation.ConstParameter.ShipId;
            string onlyPostID = cbPost.Checked ? CommonOperation.ConstParameter.LoginUserInfo.PostId : null;  //仅本岗位.
            string type = ckbType.SelectedValue == null ? null : ckbType.SelectedValue.ToString();      //类型.
            //string chkState = cboChkState.SelectedValue == null || cboChkState.SelectedValue.ToString() == "100" ? null : cboChkState.SelectedValue.ToString();     //审核状态.

            string chkState = "";
            if (cboChkState.SelectedValue == null || cboChkState.SelectedValue.ToString() == "0" || cboChkState.SelectedValue.ToString() == "1")
                chkState = "";
            else
                chkState = ShipRepairProjectService.Instance.GetBusinessStateByViewerState(cboChkState.SelectedValue.ToString());
            DataTable dtbApply = ShipRepairProjectService.Instance.GetInfo(null, shipId, type, null, chkState, onlyPostID);//取得修理项目信息的DataTable对象.
            string department = ckbDepartment.SelectedValue.ToString();     //部门.
            if (department != "0")
            {
                for (int i = 0; i < dtbApply.Rows.Count; i++)
                {
                    DataRow item = dtbApply.Rows[i];
                    bool isChild;
                    DepartmentService.Instance.ADepartmentIsChildOfAnotherOne(department, item["DEPARTMENTID"].ToString(), out isChild);
                    if ((!isChild && department != item["DEPARTMENTID"].ToString()) || string.IsNullOrEmpty(item["DEPARTMENTID"].ToString()) || string.IsNullOrEmpty(department))
                    {
                        dtbApply.Rows.Remove(item);
                        i--;
                    }
                }
            }
            bindingSourceMain.Filter = "";

            StringBuilder sb = new StringBuilder();
            sb.Append("1<>1");
            bindingSourceMain.DataSource = dtbApply;//修理项目信息的数据源设置.
            dgvApply.DataSource = bindingSourceMain;
            if (cboChkState.SelectedValue != null)
            {
                if (cboChkState.SelectedValue.ToString() == "1")
                {
                    if (CommonOperation.ConstParameter.IsLandVersion)
                    {
                        if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
                            sb.AppendLine(" or PROJECTSTATE =4");
                        else if ("机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
                            sb.AppendLine(" or PROJECTSTATE =5");
                        else if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
                            sb.AppendLine(" or PROJECTSTATE =6");
                    }
                    else
                    {
                        if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS)
                            sb.AppendLine(" or PROJECTSTATE =3");
                        else if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER)
                            sb.AppendLine(" or PROJECTSTATE =2 and DEPARTMENTID='" + CommonOperation.ConstParameter.LoginUserInfo.DepartmentId + "'");
                    }
                    sb.Append("or ( PROJECTSTATE='1' and APPLICANT='" + CommonOperation.ConstParameter.UserName + "')");
                    bindingSourceMain.Filter = sb.ToString();

                }
                else if (cboChkState.SelectedValue.ToString() == "")
                {
                    sb.Append(" or PROJECTSTATE<>1 or ( PROJECTSTATE='1' and APPLICANT='" + CommonOperation.ConstParameter.UserName + "')");
                    bindingSourceMain.Filter = sb.ToString();
                }
            }
        }
        /// <summary>
        ///  设置修理项目信息网格控件dgvApply的隐藏列与显示标题.
        /// </summary>
        private void setDataGridView()
        {
            UcDataGridView dgv = dgvApply;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("PROJECTNAME", "修理项目名称");
            dic.Add("PROJECTDETAIL", "修理项目详细");
            dic.Add("APPLYDATE", "申请日期");
            dic.Add("APPLICANT", "申请人");
            dic.Add("APPLYCOMPLETEDATE", "期望完成日期");
            dic.Add("REALCOMPLETEDATE", "完成日期");
            dic.Add("PROJECTSTATE_NAME", "审核状态");
            dic.Add("AFFIRMANT", "申请最终确认人");
            dic.Add("COMPLETEAFFIRMANT", "完成确认人");
            dic.Add("RUNNINGORDOCK_NAME", "航修或坞修");
            dic.Add("REMARK", "申请备注");
            dic.Add("SHIP_NAME", "船舶");
            dic.Add("COMP_FULL_NAME", "修理设备");
            dic.Add("SENDTOWARRANT_NAME", "是否提交费用凭证");
            dic.Add("HEADSHIP_NAME", "申请人岗位");
            dic.Add("NODE_NAME", "修理科目");
            dic.Add("MANUFACTURER_NAME", "供应商名称");
            dic.Add("REPAIRCODE", "修理编号");
            dic.Add("REPAIRPORT", "修理港口");
            dic.Add("ARRANGED_NAME", "委托状态");
            dic.Add("ARRANGEDPERSON", "安排人");
            dic.Add("SHIPAFFIRMANT", "完工船端确认人");
            dic.Add("COMPAFFIRMANT", "完工岸端确认人");
            dic.Add("REPAIRDATE", "修理开始日期");
            dic.Add("COMPLETEDATE", "修理完成日期");
            dic.Add("REPAIR_REMARK", "修理备注");
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                dic.Add("CURRENCYCODE", "货币");
                dic.Add("COSTCOUNT", "消费金额");
            }
            dgv.SetDgvGridColumns(dic);
            dgv.LoadGridView("FrmRepairApply.dgvApply");
        }
        /// <summary>
        /// 界面功能控件可见权限设置.
        /// </summary>
        private void CheckRightVisible()
        {
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                btnDelegate.Visible = true;
                if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)
                || "机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)
                || "总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是船管总经理.
                {
                    btnLandCheck.Visible = true;
                    btnAllSelect.Visible = true;
                }
            }
            else
            {
                if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS)
                {
                    btnShipCheck.Visible = true;
                    btnAllSelect.Visible = true;
                }
                else if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER)
                {
                    btndepartmentCheck.Visible = true;
                    btnAllSelect.Visible = true;
                }
            }
            if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
            {
                btnFromHistory.Visible = false;
                btnFromMaintain.Visible = false;
                bdNgAddNewItem.Visible = false;
                bdNgEditItem.Visible = false;
                bdNgDeleteItem.Visible = false;
                btnAllSelect.Visible = false;
                btndepartmentCheck.Visible = false;
                btnShipCheck.Visible = false;
                btnDelegate.Visible = false;
                btnPrint.Visible = false;
            }
        }
        /// <summary>
        /// 界面功能控件可用权限设置.
        /// </summary>
        private void CheckRightEnabled()
        {
            if (dgvApply.DataSource == null || dgvApply.Rows.Count == 0) return;

            string projectStatus = dgvApply.Rows[currentRowIndex].Cells["PROJECTSTATE"].Value.ToString();
            string departmentID = dgvApply.Rows[currentRowIndex].Cells["DEPARTMENTID"].Value.ToString();
            string applicant = dgvApply.Rows[currentRowIndex].Cells["APPLICANT"].Value.ToString();
            if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS) //假如是船长.
            {
                bdNgDeleteItem.Enabled = projectStatus == "3";//删除.
                btnShipCheck.Enabled = projectStatus == "3" && applicant != CommonOperation.ConstParameter.UserName;//船长审核.
                bdNgEditItem.Enabled = projectStatus == "3"; //编辑.
            }
            else if (projectStatus == "2" && CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER && IsSelfDepartmentHead(departmentID)) //假如是部门长 并且是申请人部门的部门长.
            {
                bool isSelfDepartmentHead = IsSelfDepartmentHead(departmentID);
                bdNgDeleteItem.Enabled = isSelfDepartmentHead;//删除.
                btndepartmentCheck.Enabled = isSelfDepartmentHead && applicant != CommonOperation.ConstParameter.UserName; //部门长审核.
                bdNgEditItem.Enabled = isSelfDepartmentHead;  //编辑.
            }
            else if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务主管.
            {
                bdNgDeleteItem.Enabled = projectStatus == "4";//删除.
                bdNgEditItem.Enabled = projectStatus == "4";//编辑.
                btnLandCheck.Enabled = projectStatus == "4" && applicant != CommonOperation.ConstParameter.UserName;//机务审核.
                btnDelegate.Enabled = projectStatus == "7";
            }
            else if ("机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务经理.
            {
                bdNgDeleteItem.Enabled = projectStatus == "5" ;//删除.
                bdNgEditItem.Enabled = projectStatus == "5";//编辑.
                btnLandCheck.Enabled = (projectStatus == "5") && applicant != CommonOperation.ConstParameter.UserName;//机务审核.
                btnDelegate.Enabled = projectStatus == "7";
            }
            else if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是船管总经理.
            {
                bdNgDeleteItem.Enabled = projectStatus == "6";//删除.
                bdNgEditItem.Enabled = projectStatus == "6";//编辑.
                btnLandCheck.Enabled = projectStatus == "6" && applicant != CommonOperation.ConstParameter.UserName;//机务审核.
                btnDelegate.Enabled = projectStatus == "7";
            }
            else
            {
                bdNgDeleteItem.Enabled = false;
                bdNgEditItem.Enabled = false;
                btnShipCheck.Enabled = false;
                btndepartmentCheck.Enabled = false;
                btnLandCheck.Enabled = false;
            }

            if (projectStatus == "1" && dgvApply.Rows[currentRowIndex].Cells["APPLICANT"].Value.ToString() == CommonOperation.ConstParameter.UserName) //假如是普通员工,并且也是申请人.
            {
                bdNgDeleteItem.Enabled = true;//删除.
                bdNgEditItem.Enabled = true;//编辑.
            }
        }
        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {
            #region 部门数据绑定
            ckbDepartment.DisplayMember = "Name";
            ckbDepartment.ValueMember = "Id";
            DataTable dtbDepartment = new DataTable();
            dtbDepartment.Columns.Add("Id", typeof(string));
            dtbDepartment.Columns.Add("Name", typeof(string));
            DataRow row23 = dtbDepartment.NewRow();
            row23["Id"] = "0";
            row23["Name"] = "全部";
            dtbDepartment.Rows.Add(row23);
            DataRow row20 = dtbDepartment.NewRow();
            string err;
            row20["Id"] = DepartmentService.Instance.GetInfoByDepartmentType("甲板部门", out err).DEPARTMENTID;
            row20["Name"] = "甲板部";
            dtbDepartment.Rows.Add(row20);
            DataRow row21 = dtbDepartment.NewRow();
            row21["Id"] = DepartmentService.Instance.GetInfoByDepartmentType("轮机部门", out err).DEPARTMENTID;
            row21["Name"] = "轮机部";
            dtbDepartment.Rows.Add(row21);
            ckbDepartment.DataSource = dtbDepartment;
            ckbDepartment.SelectedIndex = 0;
            #endregion

            #region 审核状态数据绑定

            cboChkState.DisplayMember = "State";
            cboChkState.ValueMember = "Id";
            DataTable dtbChkState = new DataTable();
            dtbChkState.Columns.Add("Id", typeof(string));
            dtbChkState.Columns.Add("State", typeof(string));
            //DataRow row0 = dtbChkState.NewRow();
            //row0["Id"] = "";
            //row0["State"] = "全部";
            //dtbChkState.Rows.Add(row0);
            //DataRow row100 = dtbChkState.NewRow();
            //row100["Id"] = "100";
            //row100["State"] = "未审核或等待审核";
            //dtbChkState.Rows.Add(row100);
            //DataRow row1 = dtbChkState.NewRow();
            //row1["Id"] = "1";
            //row1["State"] = "未审核";
            //dtbChkState.Rows.Add(row1);
            //DataRow row2 = dtbChkState.NewRow();
            //row2["Id"] = "2";
            //row2["State"] = "等待部门长审批";
            //dtbChkState.Rows.Add(row2);
            //DataRow row3 = dtbChkState.NewRow();
            //row3["Id"] = "3";
            //row3["State"] = "等待船长审批";
            //dtbChkState.Rows.Add(row3);
            //DataRow row4 = dtbChkState.NewRow();
            //row4["Id"] = "4";
            //row4["State"] = "等待岸端机务主管审批";
            //dtbChkState.Rows.Add(row4);
            //DataRow row5 = dtbChkState.NewRow();
            //row5["Id"] = "5";
            //row5["State"] = "等待岸端机务经理审批";
            //dtbChkState.Rows.Add(row5);
            //DataRow row6 = dtbChkState.NewRow();
            //row6["Id"] = "6";
            //row6["State"] = "等待船管总经理审批";
            //dtbChkState.Rows.Add(row6);
            //DataRow row7 = dtbChkState.NewRow();
            //row7["Id"] = "7";
            //row7["State"] = "申请通过等待委托";
            //dtbChkState.Rows.Add(row7);
            //DataRow row8 = dtbChkState.NewRow();
            //row8["Id"] = "8";
            //row8["State"] = "已经委托";
            //dtbChkState.Rows.Add(row8);
            //DataRow row9 = dtbChkState.NewRow();
            //row9["Id"] = "9";
            //row9["State"] = "已经完成";
            //dtbChkState.Rows.Add(row9);
            //DataRow row10 = dtbChkState.NewRow();
            //row10["Id"] = "10";
            //row10["State"] = "已经取消";
            //dtbChkState.Rows.Add(row10);



            dtbChkState.Rows.Add("0", "全部");
            dtbChkState.Rows.Add("1", "待我处理"); //未填写完毕或等待审核或被打回
            dtbChkState.Rows.Add("2", "审批中");   // 2 3 4 5 6
            dtbChkState.Rows.Add("3", "申请通过等待委托");   //7
            dtbChkState.Rows.Add("4", "已经委托");     //8
            dtbChkState.Rows.Add("5", "已经完成");     //9

            cboChkState.DataSource = dtbChkState;
            cboChkState.SelectedIndex = 0;

            #endregion

            #region 类型数据绑定
            ckbType.DisplayMember = "State";
            ckbType.ValueMember = "Id";
            DataTable dtbType = new DataTable();
            dtbType.Columns.Add("Id", typeof(string));
            dtbType.Columns.Add("State", typeof(string));
            DataRow row30 = dtbType.NewRow();
            row30["Id"] = "0";
            row30["State"] = "全部";
            dtbType.Rows.Add(row30);
            DataRow row31 = dtbType.NewRow();
            row31["Id"] = "1";
            row31["State"] = "航修";
            dtbType.Rows.Add(row31);
            DataRow row32 = dtbType.NewRow();
            row32["Id"] = "2";
            row32["State"] = "坞修";
            dtbType.Rows.Add(row32);
            ckbType.DataSource = dtbType;

            ckbType.SelectedIndex = 0;
            #endregion
        }
        #region 筛选条件控件事件

        private void cbPost_CheckedChanged(object sender, EventArgs e)
        {
            this.setBindingSource();
        }
        private void ckbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.setBindingSource();
        }
        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            this.setBindingSource();
        }
        private void ckbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.setBindingSource();
        }
        private void cboChkState_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.setBindingSource();
        }
        #endregion
        #region 审核部分
        /// <summary>
        /// 审核函数.
        /// </summary>
        /// <param name="functionCode"></param>
        private void AuditingFunction(int functionCode)
        {
            if (dgvApply.CurrentRow == null)
            {
                MessageBoxEx.Show("未选中任何行!");
                return;
            }
            FrmRepairApplyEdit frmRepairApplyEdit = new FrmRepairApplyEdit(shipId, lastApplyId, functionCode);
            frmRepairApplyEdit.ShowDialog();
            this.setBindingSource();
        }
        /// <summary>
        /// 部门长审核事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btndepartmentCheck_Click(object sender, EventArgs e)
        {
            AuditingFunction(3);
        }
        /// <summary>
        /// 船长审核事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShipCheck_Click(object sender, EventArgs e)
        {
            AuditingFunction(3);
        }
        /// <summary>
        /// 机务审核事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLandCheck_Click(object sender, EventArgs e)
        {
            AuditingFunction(3);
        }
        #endregion
        /// <summary>
        /// 是否为本部门的部门长.
        /// </summary>
        /// <returns></returns>
        private bool IsSelfDepartmentHead(string departmentID)
        {
            string err;
            Post leaderpost;
            if (!PostService.Instance.GetDepartLeaderPost(departmentID, out leaderpost, out err))
            {
                MessageBoxEx.Show(err);
                return false;
            }
            return leaderpost.PostId == CommonOperation.ConstParameter.LoginUserInfo.PostId;
        }

        /// <summary>
        /// 全选(仅审批范围)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAllSelect_Click(object sender, EventArgs e)
        {
            List<string> idList = new List<string>();
            foreach (DataGridViewRow item in dgvApply.Rows)
            {
                string projectStatus = item.Cells["PROJECTSTATE"].Value.ToString();
                string departmentID = item.Cells["DEPARTMENTID"].Value.ToString();
                if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS && projectStatus == "3")
                    idList.Add(item.Cells["PROJECTID"].Value.ToString());
                else if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER && IsSelfDepartmentHead(departmentID) && projectStatus == "2")
                {
                    idList.Add(item.Cells["PROJECTID"].Value.ToString());
                }
                else if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME) && projectStatus == "4") //假如是机务主管.
                {
                    idList.Add(item.Cells["PROJECTID"].Value.ToString());
                }
                else if ("机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME) && projectStatus == "5") //假如是机务经理.
                {
                    idList.Add(item.Cells["PROJECTID"].Value.ToString());
                }
                else if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME) && projectStatus == "6") //假如是船管总经理.
                {
                    idList.Add(item.Cells["PROJECTID"].Value.ToString());
                }
            }
            if (idList.Count > 0)
            {
                FrmRepairDuoAudit frmRepairDuoAudit = new FrmRepairDuoAudit(idList);
                frmRepairDuoAudit.ShowDialog();
            }
            else
            {
                MessageBoxEx.Show("没有需要审核的申请信息");
            }
            this.setBindingSource();
        }
        /// <summary>
        /// 删除操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.
            if (dgvApply.CurrentRow == null)
            {
                MessageBoxEx.Show("未选中任何行!");
                return;
            }
            if (DialogResult.No == MessageBoxEx.Show("确认删除该条信息吗?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                return;
            DataTable dt = ShipRepairProjectService.Instance.getInfo(lastApplyId, out err);
            ShipRepairProject obj = ShipRepairProjectService.Instance.getObject(dt.Rows[0]);
            if (obj.PROJECTSTATE == 1 && obj.APPLICANT == CommonOperation.ConstParameter.UserName)
            {
                if (!ShipRepairProjectService.Instance.deleteUnit(obj.PROJECTID, out err))
                {
                    MessageBoxEx.Show(err, "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                if (DialogResult.No == MessageBoxEx.Show("删除操作会把该信息状态变为作废,确定吗?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                    return;
                obj.PROJECTSTATE = 10;
                if (!ShipRepairProjectService.Instance.saveUnit(obj, out err))
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
            if (dgvApply.CurrentRow == null)
            {
                MessageBoxEx.Show("未选中任何行!");
                return;
            }
            FrmRepairApplyEdit FrmRepairApplyEdit = new FrmRepairApplyEdit(shipId, lastApplyId, 2);
            FrmRepairApplyEdit.ShowDialog();
            this.setBindingSource();
        }
        /// <summary>
        /// 添加按钮事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            FrmRepairApplyEdit frmSpareApplyEdit = new FrmRepairApplyEdit("", null, 1);
            frmSpareApplyEdit.ShowDialog();
            this.setBindingSource();
        }
        /// <summary>
        /// 委托按钮.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelegate_Click(object sender, EventArgs e)
        {
            if (dgvApply.CurrentRow == null)
            {
                MessageBoxEx.Show("未选中任何行!");
                return;
            }
            FrmFollowDelegateEdit frm = new FrmFollowDelegateEdit(lastApplyId);
            frm.ShowDialog();
            setBindingSource();
        }
        /// <summary>
        /// 双击事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvApply_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvApply.CurrentRow == null)
            {
                MessageBoxEx.Show("未选中任何行!");
                return;
            }
            if (dgvApply.DataSource == null || dgvApply.Rows.Count == 0) return;
            string departmentID = dgvApply.Rows[currentRowIndex].Cells["DEPARTMENTID"].Value.ToString();
            string projectStatus = dgvApply.Rows[currentRowIndex].Cells["PROJECTSTATE"].Value.ToString();
            string applicant = dgvApply.Rows[currentRowIndex].Cells["APPLICANT"].Value.ToString();
            //假如是船长.
            if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS && projectStatus == "3")
            {
                FrmRepairApplyEdit FrmRepairApplyEdit = new FrmRepairApplyEdit(shipId, lastApplyId, 3);
                FrmRepairApplyEdit.ShowDialog();
            }
            //假如是部门长 并且是申请人部门的部门长.
            else if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER && IsSelfDepartmentHead(departmentID) && projectStatus == "2")
            {
                FrmRepairApplyEdit FrmRepairApplyEdit = new FrmRepairApplyEdit(shipId, lastApplyId, 3);
                FrmRepairApplyEdit.ShowDialog();
            }
            else if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)
                && projectStatus == "4" && applicant != CommonOperation.ConstParameter.UserName) //假如是机务主管.
            {
                FrmRepairApplyEdit FrmRepairApplyEdit = new FrmRepairApplyEdit(shipId, lastApplyId, 3);
                FrmRepairApplyEdit.ShowDialog();
            }
            else if ("机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)
               && (projectStatus == "5") && applicant != CommonOperation.ConstParameter.UserName) //假如是机务经理.
            {
                FrmRepairApplyEdit FrmRepairApplyEdit = new FrmRepairApplyEdit(shipId, lastApplyId, 3);
                FrmRepairApplyEdit.ShowDialog();
            }
            else if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)
                && projectStatus == "6" && applicant != CommonOperation.ConstParameter.UserName) //假如是船管总经理.
            {
                FrmRepairApplyEdit FrmRepairApplyEdit = new FrmRepairApplyEdit(shipId, lastApplyId, 3);
                FrmRepairApplyEdit.ShowDialog();
            }
            //假如是普通员工,并且也是申请人.
            else if (projectStatus == "1" && applicant == CommonOperation.ConstParameter.UserName)
            {
                FrmRepairApplyEdit FrmRepairApplyEdit = new FrmRepairApplyEdit(shipId, lastApplyId, 2);
                FrmRepairApplyEdit.ShowDialog();
            }
            else
            {
                FrmRepairApplyEdit FrmRepairApplyEdit = new FrmRepairApplyEdit(shipId, lastApplyId, 6);
                FrmRepairApplyEdit.ShowDialog();
            }
            this.setBindingSource();
        }
        /// <summary>
        /// 从维护保养导入.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFromMaintain_Click(object sender, EventArgs e)
        {
            FrmSelectNotFinishedWorkOrder frm = new FrmSelectNotFinishedWorkOrder(ucShipSelect1.GetId());
            frm.ShowDialog();
            if (frm.Selected && frm.WorkOrders != null && frm.WorkOrders.Count > 0)
            {
                string err;
                bool haveDuplicate = false;
                foreach (WorkOrder wo in frm.WorkOrders)
                {
                    wo.FillThisObject();
                    if (ShipRepairProjectService.Instance.HaveAlreadyAppliedTheWorkOrder("", wo.GetId()))
                    {
                        haveDuplicate = true;
                        continue;
                    }
                    ShipRepairProject oneProject = new ShipRepairProject("", wo.WORKORDERNAME,
                       (wo.TheWorkInfo != null ? wo.TheWorkInfo.WORKINFODETAIL : "") +
                       (string.IsNullOrEmpty(wo.WORKDESCRIPTION) ? "" : "\r\n" + wo.WORKDESCRIPTION),
                       DateTime.Today, CommonOperation.ConstParameter.UserName, wo.GetId(), DateTime.Now,
                       DateTime.MinValue, 1, "", "", ckbDepartment.SelectedValue.ToString() == "1" ? 1 : 2, null,
                       null, (string.IsNullOrEmpty(wo.WORKCOMPLETEDINFO) ? "" : "\r\n" + wo.WORKCOMPLETEDINFO),
                       wo.SHIP_ID, null, 0, (wo.TheWorkInfo != null ? wo.TheWorkInfo.REFOBJID : null), 0,
                       CommonOperation.ConstParameter.LoginUserInfo.PostId, "","");
                    if (!oneProject.Update(out err))
                    {
                        MessageBoxEx.Show("根据用户选择的工单保存修理项目时失败,失败原因请参考\r" + err);
                        return;
                    }
                }
                setBindingSource();
                if (haveDuplicate)
                {
                    MessageBoxEx.Show("您选择的某些工单已经生成过修理申请,且没有完成或被打回,不能重复申请!");
                    return;
                }
            }
            else if (frm.Selected)
            {
                MessageBoxEx.Show("未选择任何数据!");
            }
        }
        /// <summary>
        /// 从历史导入.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFromHistory_Click(object sender, EventArgs e)
        {
            FrmRepairHistory frm = new FrmRepairHistory(1);
            frm.ShowDialog();
            if (frm.dtsrp != null && frm.dtsrp.Rows.Count > 0)
            {
                string err;
                foreach (DataRow item in frm.dtsrp.Rows)
                {
                    ShipRepairProject repairProject = new ShipRepairProject();
                    repairProject.PROJECTNAME = item["PROJECTNAME"].ToString();
                    repairProject.PROJECTDETAIL = item["PROJECTDETAIL"].ToString();
                    repairProject.APPLICANT = CommonOperation.ConstParameter.UserName;
                    repairProject.APPLYDATE = DateTime.Now;
                    repairProject.WORKORDERID = item["WORKORDERID"].ToString();
                    repairProject.APPLYCOMPLETEDATE = DateTime.Now;
                    repairProject.PROJECTSTATE = 1;
                    repairProject.RUNNINGORDOCK = Convert.ToDecimal(item["RUNNINGORDOCK"]);
                    repairProject.REMARK = item["REMARK"].ToString();
                    repairProject.SHIP_ID = item["SHIP_ID"].ToString();
                    repairProject.REPAIRSUBJECT = item["REPAIRSUBJECT"].ToString();
                    repairProject.EQUIPMENTID = item["EQUIPMENTID"].ToString();
                    repairProject.SENDTOWARRANT = 0;
                    repairProject.APPLYPOST = CommonOperation.ConstParameter.LoginUserInfo.PostId;
                    if (!repairProject.Update(out err))
                    {
                        MessageBoxEx.Show("根据用户选择的修理历史保存修理项目时失败,失败原因请参考\r" + err);
                        return;
                    }
                }
                setBindingSource();
            }
        }
        /// <summary>
        /// 修理项目申请打印.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgPrintItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ckbDepartment.SelectedValue.ToString()) || ckbDepartment.SelectedValue.ToString() == "0")
            {
                MessageBoxEx.Show("未选择甲板或轮机部,将打印所有修理项目");
            }
            if (dgvApply.Rows.Count == 0)
            {
                MessageBoxEx.Show("没有申请单可以打印");
                return;
            }
            List<string> applyList = new List<string>();
            foreach (DataGridViewRow item in dgvApply.Rows)
            {
                applyList.Add(item.Cells["PROJECTID"].Value.ToString());
            }
            if (RepairConfig.customRepairApplyPrint != null)
            {
                string err;
                if (!RepairConfig.customRepairApplyPrint(applyList, out err))
                {
                    MessageBoxEx.Show("打印失败,错误参考\r" + err);
                }
            }

            ////能看到数据的均可以打印.
            //string err = "";                                 //错误信息参数.
            //string shipId = "";// ucShipSelect1.GetId();                     //取当前船舶Id
            //string shipName = ShipInfoService.Instance.getObject(shipId, out err).SHIP_NAME;
            ////string applyDate = txtApplyDate.Text;  //取申请日期.
            //List<string> lstCols = new List<string>();                  //包含要在Excel申请单上显示信息的列的名称.

            //string spareApplyId = "";                                   //修理项目申请单Id

            //if (dgvApply.Rows.Count == 0)
            //{
            //    MessageBoxEx.Show("无可打印的信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}
            //else
            //{
            //    //spareApplyId = ucDepartmentSelect1.Tag.ToString();
            //}

            ////如果找到了相应的申请单,则提示用户是否打开旧的.
            //string fileName = "";//= CommonPrintTableName.CTNOfSpareApply + (string.IsNullOrEmpty(txtApplyCode.Text) ? txtApplyDate.Text : txtApplyCode.Text);
            //string fileid;
            //if (FolderFileDbService.Instance.IfFolderHasTheFile(spareApplyId, fileName + ".xls", out fileid))
            //{
            //    if (MessageBoxEx.Show("找到了之前形成的申请单文件" + fileName + ",是否要直接打开此文件?" +
            //        "\r选择否,系统推荐您删除旧文件,以免形成多个申请单的导出文件给其他人造成误导.", "系统提示", MessageBoxButtons.YesNo,
            //        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            //    {
            //        ourFile ofile;

            //        if (!FileDbService.Instance.GetAFileById(fileid, out ofile))
            //        {
            //            MessageBoxEx.Show("非常抱歉,没有成功获取此文档,下面将重新形成新文件!", "系统提示");
            //        }
            //        else
            //        {
            //            openFile opf = new openFile();
            //            opf.FileOpen(ofile, right.U);
            //            return;
            //        }
            //    }
            //}

            //if (StorageConfig.customSpareApplyPrint != null)
            //{
            //    DialogResult dr = FolderBrowserDialogEx.ShowDialog(folderBD);
            //    if (dr == DialogResult.OK)
            //    {
            //        string path;
            //        path = folderBD.SelectedPath.ToString();
            //        if (File.Exists(path + "\\" + fileName + ".xls"))
            //        {
            //            if (MessageBoxEx.Show("您选择的文件夹已经包含了指定文件,是否覆盖此文件?" +
            //                "\r选择是,系统将覆盖当前文件.\r选择否,系统推荐为您新生成的文件添加一个随机后缀,让其不发生冲突.",
            //                "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            //            {
            //                path = path + "\\" + fileName + ".xls";
            //                FileInfo fTemp = new FileInfo(path);
            //                fTemp.Delete();
            //            }
            //            else
            //            {
            //                path = path + "\\" + fileName + Guid.NewGuid().ToString().Substring(0, 5) + ".xls";
            //            }
            //        }
            //        else path = path + "\\" + fileName + ".xls";

            //        if (!StorageConfig.customSpareApplyPrint(spareApplyId, path, out err))
            //        {
            //            MessageBoxEx.Show(err, "信息提示");
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBoxEx.Show("没有找到相关的定制报表打印功能！请确认是否就当前表格提供给软件开发商？");
            //}
        }
        /// <summary>
        /// 释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmRepairApply_FormClosing(object sender, FormClosingEventArgs e)
        {
            //清除大文档绑定功能.
            // FileOperation.FileBoundingOperation.Instance.FileBoundCheck("", "", 0, "");
            dgvApply.SaveGridView("FrmRepairApply.dgvApply");
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


        #region IRemindViewState 成员

        public void SetRemindViewApprovalState()
        {
            ucShipSelect1.SelectedText("所有船");
            ckbDepartment.Text = "全部";
            ckbType.Text = "全部";
            cbPost.Checked = false;
            cboChkState.Text = "未审核或等待审核";
            this.setBindingSource();
        }

        public void SetRemindViewInformState()
        {
            ucShipSelect1.SelectedText("所有船");
            ckbDepartment.Text = "全部";
            ckbType.Text = "全部";
            cbPost.Checked = false;
            cboChkState.Text = "全部";
            this.setBindingSource();
        }

        #endregion

        private void dgvApply_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (bindingSourceMain.Current == null || e.RowIndex < 0)
                FileOperation.FileBoundingOperation.Instance.FileBoundCheck("", "", 0, null);
            else
            {
                if (dgvApply.Rows[e.RowIndex].Cells["PROJECTID"].Value != null)
                {
                    lastApplyId = dgvApply.Rows[e.RowIndex].Cells["PROJECTID"].Value.ToString();
                    shipId = dgvApply.Rows[e.RowIndex].Cells["ship_id"].Value.ToString();
                    string REPAIRCODE = dgvApply.Rows[e.RowIndex].Cells["REPAIRCODE"].Value.ToString();
                    string PROJECTNAME = dgvApply.Rows[e.RowIndex].Cells["PROJECTNAME"].Value.ToString();

                    currentRowIndex = e.RowIndex;
                    CheckRightEnabled();

                    //绑定大文档.
                    FileOperation.FileBoundingOperation.Instance.FileBoundCheck(lastApplyId, PROJECTNAME + "(" + REPAIRCODE + ")",
                        CommonOperation.Enum.FileBoundingTypes.PROJECTMANAGE, shipId);
                }
                else
                {
                    FileOperation.FileBoundingOperation.Instance.FileBoundCheck(lastApplyId, "",
                        CommonOperation.Enum.FileBoundingTypes.PROJECTMANAGE, shipId);
                }
            }
        }



    }
}
