/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmRepairHistory.cs
 * 创 建 人：王鹏程
 * 创建时间：2011-08-25
 * 标    题：修理历史
 * 功能描述：从修理历史导入
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
using ItemsManage.Viewer.Forms;
using CommonOperation.Interfaces;
using BaseInfo.DataAccess;
using CommonViewer.BaseControl;
using ItemsManage;
using Maintenance.DataObject;
using ItemsManage.Viewer;
using ItemsManage.DataObject;
using ItemsManage.Services;
using Maintenance.Services;
using Repair.Services;
using Repair.DataObject;
using CommonViewer;

namespace Repair.Viewer
{
    public partial class FrmRepairHistory : CommonViewer.BaseForm.FormBase
    {
        private string SERVICEPROVIDER = "";
        private string CURRENCYID = "";
        private ComponentUnit componentUnit = null;
        private string SHIP_ID = "";
        private List<string> idlist = new List<string>();
        /// <summary>
        /// 功能码:1=导入历史的; 2=选择未生成凭证的; 3=选择未生成凭证的(没确定船舶,币种,服务商)
        /// </summary>
        private int functionCode = 1;
        public DataTable dtsrp = null;

        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmRepairHistory(int paramFunctionCode)
        {
            InitializeComponent();
            this.functionCode = paramFunctionCode;
        }

        /// <summary>
        /// 构造函数,查看设备修理历史用.
        /// </summary>
        public FrmRepairHistory(string COMPONENT_UNIT_ID)
        {
            InitializeComponent();
            this.functionCode = 4;
            string err;
            this.componentUnit = ComponentUnitService.Instance.getObject(COMPONENT_UNIT_ID, out err);
        }
        public FrmRepairHistory(string serviceprovider, string currencyid, string ship_id, List<string> idlist)
        {
            InitializeComponent();
            this.SERVICEPROVIDER = serviceprovider;
            this.CURRENCYID = currencyid;
            this.SHIP_ID = ship_id;
            this.idlist = idlist;
            this.functionCode = 2;
        }

        /// <summary>
        /// 窗体启动时的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmRepairHistory_Load(object sender, EventArgs e)
        {
            ucShipSelect1.ChangeSelectedState(true, true);
            this.StartPosition = FormStartPosition.CenterParent;
            setComboBox();
            setBindingSource();
            setDataGridView();
            if (functionCode == 2)
            {
                ucShipSelect1.SelectedId(SHIP_ID);
                ucShipSelect1.Enabled = false;
                cboChkState.SelectedValue = "9";
                cboChkState.Enabled = false;
            }
            else if (functionCode == 3)
            {
                cboChkState.SelectedValue = "9";
                cboChkState.Enabled = false;
            }
            ucShipSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(this.ucShipSelect1_TheSelectedChanged);
        }
        /// <summary>
        /// 绑定修理项目信息.
        /// </summary>
        private void setBindingSource()
        {
            string onlyPostID = cbPost.Checked ? CommonOperation.ConstParameter.LoginUserInfo.PostId : null;  //仅本岗位.
            string type = ckbType.SelectedValue == null ? null : ckbType.SelectedValue.ToString();      //类型.
            string chkState = cboChkState.SelectedValue == null ? null : cboChkState.SelectedValue.ToString();     //审核状态.
            DataTable dtbRepairHistory = ShipRepairProjectService.Instance.GetInfo(null, ucShipSelect1.GetId(), type, null, chkState, onlyPostID);//取得修理项目信息的DataTable对象.

            string department = ckbDepartment.SelectedValue.ToString();     //部门.
            if (department != "0")
            {
                for (int i = 0; i < dtbRepairHistory.Rows.Count; i++)
                {
                    DataRow item = dtbRepairHistory.Rows[i];
                    bool isChild;
                    DepartmentService.Instance.ADepartmentIsChildOfAnotherOne(department, item["DEPARTMENTID"].ToString(), out isChild);
                    if ((!isChild && department != item["DEPARTMENTID"].ToString()) || string.IsNullOrEmpty(item["DEPARTMENTID"].ToString()) || string.IsNullOrEmpty(department))
                    {
                        dtbRepairHistory.Rows.Remove(item);
                        i--;
                    }
                }
            }
            bdsRepairHistory.DataSource = dtbRepairHistory;
            bdsRepairHistory.Filter = "";
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");
            if (functionCode == 2)
            {
                sb.Append(" and SENDTOWARRANT=0");
                sb.Append(" and CURRENCYID='" + this.CURRENCYID + "'");
                sb.Append(" and SERVICEPROVIDER='" + this.SERVICEPROVIDER + "'");
                foreach (string item in this.idlist)
                {
                    sb.Append(" and PROJECTID<>'" + item + "'");
                }
            }
            else if (functionCode == 3)
                sb.Append(" and SENDTOWARRANT=0");
            if (string.IsNullOrEmpty(ucShipSelect1.GetId()))
            {
                string err;
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
            bdsRepairHistory.Filter = sb.ToString();
            dgvRepairHistory.DataSource = bdsRepairHistory;
        }
        /// <summary>
        ///  设置修理项目信息网格控件dgvRepairHistory的隐藏列与显示标题.
        /// </summary>
        private void setDataGridView()
        {
            foreach (DataGridViewColumn item in dgvRepairHistory.Columns)
            {
                item.ReadOnly = true;
            }
            UcDataGridView dgv = dgvRepairHistory;
            dgv.Columns["PROJECTID"].Visible = false;
            dgv.Columns["PROJECTNAME"].HeaderText = "修理项目名称";
            dgv.Columns["PROJECTDETAIL"].HeaderText = "修理项目详细";
            dgv.Columns["APPLYDATE"].HeaderText = "申请日期";
            dgv.Columns["APPLICANT"].HeaderText = "申请人";
            dgv.Columns["WORKORDERID"].Visible = false;
            dgv.Columns["APPLYCOMPLETEDATE"].HeaderText = "期望完成日期";
            dgv.Columns["REALCOMPLETEDATE"].HeaderText = "完成日期";
            dgv.Columns["PROJECTSTATE"].Visible = false;
            dgv.Columns["PROJECTSTATE_NAME"].HeaderText = "审核状态";
            dgv.Columns["AFFIRMANT"].HeaderText = "申请最终确认人";
            dgv.Columns["COMPLETEAFFIRMANT"].HeaderText = "完成确认人";
            dgv.Columns["RUNNINGORDOCK"].Visible = false;
            dgv.Columns["RUNNINGORDOCK_NAME"].HeaderText = "航修或坞修";
            dgv.Columns["REPAIRSUBJECT"].Visible = false;
            dgv.Columns["SERVICEPROVIDER"].Visible = false;
            dgv.Columns["REMARK"].HeaderText = "申请备注";
            dgv.Columns["REMARK"].Visible = false;
            dgv.Columns["SHIP_ID"].Visible = false;
            dgv.Columns["SHIP_NAME"].HeaderText = "船舶";
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                dgv.Columns["CURRENCYID"].Visible = false;
                dgv.Columns["CURRENCYCODE"].HeaderText = "货币";
                dgv.Columns["COSTCOUNT"].HeaderText = "消费金额";
            }
            dgv.Columns["EQUIPMENTID"].Visible = false;
            dgv.Columns["COMP_FULL_NAME"].HeaderText = "修理设备";
            dgv.Columns["COMP_CHINESE_NAME"].Visible = false;
            dgv.Columns["SENDTOWARRANT"].Visible = false;
            dgv.Columns["SENDTOWARRANT_NAME"].HeaderText = "是否提交费用凭证";
            dgv.Columns["APPLYPOST"].Visible = false;
            dgv.Columns["HEADSHIP_NAME"].HeaderText = "申请人岗位";
            dgv.Columns["HEADSHIP_NAME"].Visible = false;
            dgv.Columns["SHIP_HEADSHIP_ID"].Visible = false;
            dgv.Columns["DEPARTMENTID"].Visible = false;
            dgv.Columns["NODE_NAME"].HeaderText = "修理科目";
            dgv.Columns["RELATIONID"].Visible = false;
            dgv.Columns["MANUFACTURER_NAME"].HeaderText = "供应商名称";

            dgv.Columns["REPAIRID"].Visible = false;
            dgv.Columns["REPAIRCODE"].HeaderText = "修理编号";
            dgv.Columns["REPAIRCODE"].Visible = false;
            dgv.Columns["REPAIRPORT"].HeaderText = "修理港口";
            dgv.Columns["ARRANGED"].Visible = false;
            dgv.Columns["ARRANGED_NAME"].HeaderText = "委托状态";
            dgv.Columns["ARRANGED_NAME"].Visible = false;
            dgv.Columns["ARRANGEDPERSON"].HeaderText = "安排人";
            dgv.Columns["SHIPAFFIRMANT"].HeaderText = "完工船端确认人";
            dgv.Columns["COMPAFFIRMANT"].HeaderText = "完工岸端确认人";
            dgv.Columns["REPAIRDATE"].HeaderText = "修理开始日期";
            dgv.Columns["COMPLETEDATE"].HeaderText = "修理完成日期";
            dgv.Columns["COMPLETEDATE"].Visible = false;
            dgv.Columns["REPAIR_REMARK"].HeaderText = "修理备注";
            dgv.Columns["REPAIR_REMARK"].Visible = false;
            dgv.Columns["VOUCHER_ID"].Visible = false;
            dgvRepairHistory.LoadGridView("FrmRepairHistory.dgvRepairHistory");

            if (dgvRepairHistory.Columns["select"] == null)//如果选择列已经存在，则不能重复添加.
            {
                DataGridViewCheckBoxColumn dgvChkCol = new DataGridViewCheckBoxColumn();
                dgvChkCol.Name = "select";
                dgvChkCol.HeaderText = "选择";
                dgvChkCol.DefaultCellStyle.BackColor = Color.Linen;
                dgvChkCol.DataPropertyName = "select";
                dgvChkCol.Width = 40;
                dgvRepairHistory.Columns.Insert(0, dgvChkCol);
            }
            else dgvRepairHistory.Columns["select"].DisplayIndex = 0;
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
            DataRow row0 = dtbChkState.NewRow();
            row0["Id"] = "0";
            row0["State"] = "全部";
            dtbChkState.Rows.Add(row0);
            DataRow row1 = dtbChkState.NewRow();
            row1["Id"] = "1";
            row1["State"] = "未审核";
            dtbChkState.Rows.Add(row1);
            DataRow row2 = dtbChkState.NewRow();
            row2["Id"] = "2";
            row2["State"] = "等待部门长审批";
            dtbChkState.Rows.Add(row2);
            DataRow row3 = dtbChkState.NewRow();
            row3["Id"] = "3";
            row3["State"] = "等待船长审批";
            dtbChkState.Rows.Add(row3);
            DataRow row4 = dtbChkState.NewRow();
            row4["Id"] = "4";
            row4["State"] = "等待岸端机务主管审批";
            dtbChkState.Rows.Add(row4);
            DataRow row5 = dtbChkState.NewRow();
            row5["Id"] = "5";
            row5["State"] = "等待岸端机务经理审批";
            dtbChkState.Rows.Add(row5);
            DataRow row6 = dtbChkState.NewRow();
            row6["Id"] = "6";
            row6["State"] = "等待船管总经理审批";
            dtbChkState.Rows.Add(row6);
            DataRow row7 = dtbChkState.NewRow();
            row7["Id"] = "7";
            row7["State"] = "申请通过等待委托";
            dtbChkState.Rows.Add(row7);
            DataRow row8 = dtbChkState.NewRow();
            row8["Id"] = "8";
            row8["State"] = "已经委托";
            dtbChkState.Rows.Add(row8);
            DataRow row9 = dtbChkState.NewRow();
            row9["Id"] = "9";
            row9["State"] = "已经完成";
            dtbChkState.Rows.Add(row9);
            DataRow row10 = dtbChkState.NewRow();
            row10["Id"] = "10";
            row10["State"] = "已经取消";
            dtbChkState.Rows.Add(row10);
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
        private void ckbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.setBindingSource();
        }
        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            this.setBindingSource();
        }
        private void cboChkState_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.setBindingSource();
        }

        #endregion
        /// <summary>
        /// datagridview点击复选框事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvRepairHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvRepairHistory.Columns[e.ColumnIndex].Name == "select")
            {
                bool select = false;
                if (dgvRepairHistory.CurrentRow.Cells[e.ColumnIndex].Value == null)
                    select = false;
                else select = (bool)dgvRepairHistory.CurrentRow.Cells[e.ColumnIndex].Value;
                dgvRepairHistory.CurrentRow.Cells[e.ColumnIndex].Value = !select;
            }
        }
        private bool CheckSelected()
        {
            if (functionCode == 2 || functionCode == 3)
            {
                SERVICEPROVIDER = "";
                CURRENCYID = "";
                SHIP_ID = "";
                foreach (DataGridViewRow dr in dgvRepairHistory.Rows)
                {
                    if (dr.Cells["select"].Value != null && ((bool)dr.Cells["select"].Value))
                    {
                        if (!string.IsNullOrEmpty(SERVICEPROVIDER) && dr.Cells["SERVICEPROVIDER"].Value.ToString() != SERVICEPROVIDER)
                        {
                            MessageBoxEx.Show("选择的项目存在不同的供应商");
                            return false;
                        }
                        SERVICEPROVIDER = dr.Cells["SERVICEPROVIDER"].Value.ToString();
                        if (!string.IsNullOrEmpty(CURRENCYID) && dr.Cells["CURRENCYID"].Value.ToString() != CURRENCYID)
                        {
                            MessageBoxEx.Show("选择的项目存在不同的币种");
                            return false;
                        }
                        CURRENCYID = dr.Cells["CURRENCYID"].Value.ToString();
                        if (!string.IsNullOrEmpty(SHIP_ID) && dr.Cells["SHIP_ID"].Value.ToString() != SHIP_ID)
                        {
                            MessageBoxEx.Show("选择的项目存在不同的船舶");
                            return false;
                        }
                        SHIP_ID = dr.Cells["SHIP_ID"].Value.ToString();
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// 选择按钮事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgSelect_Click(object sender, EventArgs e)
        {
            if (!CheckSelected()) return;
            DataTable dt = (DataTable)bdsRepairHistory.DataSource;
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1 and PROJECTID in ('0'");
            foreach (DataGridViewRow dr in dgvRepairHistory.Rows)
                if (dr.Cells["select"].Value != null && ((bool)dr.Cells["select"].Value))
                    sb.Append(",'" + dr.Cells["PROJECTID"].Value.ToString() + "'");
            sb.Append(")");
            dtsrp = dt.Clone();
            DataRow[] drs = dt.Select(sb.ToString());
            foreach (DataRow item in drs)
                dtsrp.Rows.Add(item.ItemArray);
            if (dtsrp.Rows.Count > 0)
                this.Close();
        }
        /// <summary>
        /// 释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
