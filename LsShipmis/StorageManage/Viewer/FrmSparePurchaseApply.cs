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
using CommonOperation.Enum;

namespace StorageManage.Viewer
{
    public partial class FrmSparePurchaseApply : CommonViewer.BaseForm.FormBase, CommonOperation.Interfaces.IRemindViewState
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmSparePurchaseApply instance = new FrmSparePurchaseApply();
        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmSparePurchaseApply Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmSparePurchaseApply.instance = new FrmSparePurchaseApply();
                }

                return FrmSparePurchaseApply.instance;
            }
        }
        private FrmSparePurchaseApply()
        {
            InitializeComponent();
        }
        #endregion
        #region 当前行关键值
        private int currSelNum = 0;
        private bool isFirstLoad = true;
        private string PURCHASE_APPLYID = "";
        private string STATE = "";
        private string DEPART_ID = "";
        private string PURCHASE_APPLY_PERSON = "";
        private string ISCOMPLETE = "";
        #endregion
        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSparePurchaseApply_Load(object sender, EventArgs e)
        {
            //查询条件默认为3个月的数据.

            dtpStartDate.Value = DateTime.Now.AddMonths(-3);
            dtpEndDate.Value = DateTime.Now;

            ucDepartmentSelect1.ChangeMode(3);
            CheckRightVisible();      //功能权限校验.
            this.setComboBox();     //设置窗体所需的下拉列表框的数据源.
            this.WindowState = FormWindowState.Maximized;//窗体最大化.
            this.setBindingSource();//设置数据源.
            this.setDataGridView(); //设置网格控件dgvApply的隐藏列与标头的设置.
            CheckRightEnabled(0);
            ucShipSelect1.ChangeSelectedState(true, true);

            isFirstLoad = false;
        }
        /// <summary>
        /// 绑定信息.
        /// </summary>
        private void setBindingSource()
        {
            string shipId = ucShipSelect1.GetId();//船舶.
            string onlyPostID = cbPost.Checked ? CommonOperation.ConstParameter.LoginUserInfo.PostId : null;  //仅本岗位.
            string state = "";
            if (cboChkState.SelectedValue == null || cboChkState.SelectedValue.ToString() == "0" || cboChkState.SelectedValue.ToString() == "1")
                state = "";
            else
                state = SparePurchaseApplyService.Instance.GetBusinessStateByViewerState(cboChkState.SelectedValue.ToString());
            string department = ucDepartmentSelect1.GetId() == "0" ? null : ucDepartmentSelect1.GetId();//部门.
            #region 准备过滤条件
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" AND spa.PURCHASE_APPLY_DATE between '" + dtpStartDate.Value + "' and '" + dtpEndDate.Value + "' ");
            if (!string.IsNullOrEmpty(shipId))
                sb.AppendLine(" and spa.SHIP_ID='" + shipId + "'");
            if (!string.IsNullOrEmpty(department))
                sb.AppendLine(" and spa.DEPART_ID='" + department + "'");
            if (!string.IsNullOrEmpty(onlyPostID))
                sb.AppendLine(" and spa.PURCHASE_APPLY_PERSON_POSTID='" + onlyPostID + "'");
            if (!string.IsNullOrEmpty(state))
                sb.AppendLine(" and spa.STATE in (" + state + ")");
            sb.AppendLine(" and (ISCOMPLETE=1 or ( ISCOMPLETE=0 and PURCHASE_APPLY_PERSON='" + CommonOperation.ConstParameter.UserName + "'))");
            if (cboChkState.SelectedValue != null && cboChkState.SelectedValue.ToString() == "1")//待我处理
            {
                sb.Append(" and ( 1<>1  ");
                if (CommonOperation.ConstParameter.IsLandVersion)
                {
                    if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
                        sb.AppendLine(" or STATE =3");
                    else if ("机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))

                        sb.AppendLine(" or STATE =4");//sb.AppendLine(" or STATE =4 or STATE =3");

                    else if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
                        sb.AppendLine(" or STATE =5");
                }
                else
                {
                    if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS)
                        sb.AppendLine(" or STATE =2");
                    else if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER)
                        sb.AppendLine(" or STATE =1 and DEPART_ID='" + CommonOperation.ConstParameter.LoginUserInfo.DepartmentId + "'");
                }
                sb.AppendLine(" or ( (STATE=0 or STATE=8) and PURCHASE_APPLY_PERSON='" + CommonOperation.ConstParameter.UserName + "'))");
            }
            #endregion
            String errMessage = String.Empty;
            DataTable dtbApply = new DataTable();
            if (!SparePurchaseApplyService.Instance.SelectDataTable(sb.ToString(), out dtbApply, out errMessage))
            { 
                
            };//取得信息的DataTable对象.

            dgvApply.DataSource = dtbApply;

            //DataTable dtbApply = SparePurchaseApplyService.Instance.GetInfo(null, shipId, department, onlyPostID, state);//取得信息的DataTable对象.
            //StringBuilder sb = new StringBuilder();
            //sb.Append("1=1");
            //sb.AppendLine(" and (ISCOMPLETE=1 or ( ISCOMPLETE=0 and PURCHASE_APPLY_PERSON='" + CommonOperation.ConstParameter.UserName + "'))");
            //if (cboChkState.SelectedValue != null && cboChkState.SelectedValue.ToString() == "1")
            //{
            //    sb.Append(" and ( 1<>1  ");
            //    if (CommonOperation.ConstParameter.IsLandVersion)
            //    {
            //        if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
            //            sb.AppendLine(" or STATE =3");
            //        else if ("机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
            //            #region  wanhw-2014-12-30-机务经理无权查看机务主管的申请单 
            //            sb.AppendLine(" or STATE =4");//sb.AppendLine(" or STATE =4 or STATE =3");
            //            #endregion
            //        else if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
            //            sb.AppendLine(" or STATE =5");
            //    }
            //    else
            //    {
            //        if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS)
            //            sb.AppendLine(" or STATE =2");
            //        else if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER)
            //            sb.AppendLine(" or STATE =1 and DEPART_ID='" + CommonOperation.ConstParameter.LoginUserInfo.DepartmentId + "'");
            //    }
            //    sb.AppendLine(" or ( (STATE=0 or STATE=8) and PURCHASE_APPLY_PERSON='" + CommonOperation.ConstParameter.UserName + "'))");
            //}
            //DataTable newdt = new DataTable();
            //newdt = dtbApply.Clone();
            //foreach (DataRow item in dtbApply.Select(sb.ToString()))
            //    newdt.Rows.Add(item.ItemArray);
            dgvDetail.DataSource = null;
            txtShip.Text = "";
            txtComponent.Text = "";
            txtPURCHASE_APPLY_CODE.Text = "";
            txtPURCHASE_APPLY_PERSON.Text = "";
            txtHEADSHIP_NAME.Text = "";
            txtPURCHASE_APPLY_DATE.Text = "";
            txtDEPARTNAME.Text = "";
            txtSHIP_LEADER_CHECKER.Text = "";
            txtSHIP_BOSS_CHECKER.Text = "";
            txtSHIP_LEADER_CHECKDATE.Text = "";
            txtSHIP_BOSS_CHECKDATE.Text = "";
            txtLANDCHECKER.Text = "";
            txtCHECKDATE.Text = "";
            txtREMARK.Text = "";
            //dgvApply.DataSource = newdt;
            if (dtbApply.Rows.Count == 0)
                FileOperation.FileBoundingOperation.Instance.FileBoundCheck("", "", 0, "");

        }
        /// <summary>
        ///  设置信息网格控件的隐藏列与显示标题.
        /// </summary>
        private void setDataGridView()
        {
            Dictionary<string, string> dgvColumnStyle = new Dictionary<string, string>();
            dgvColumnStyle.Add("PURCHASE_APPLY_CODE", "处理单号");
            dgvColumnStyle.Add("SHIP_NAME", "船舶");
            dgvColumnStyle.Add("COMP_CHINESE_NAME", "设备");
            dgvColumnStyle.Add("PURCHASE_APPLY_PERSON", "申请人");
            dgvColumnStyle.Add("HEADSHIP_NAME", "申请人岗位");
            dgvColumnStyle.Add("DEPARTNAME", "申请人部门");
            dgvColumnStyle.Add("PURCHASE_APPLY_DATE", "申请日期");
            dgvColumnStyle.Add("SHIP_LEADER_CHECKER", "船上部门长确认者");
            dgvColumnStyle.Add("SHIP_BOSS_CHECKER", "船上船长确认者");
            dgvColumnStyle.Add("SHIP_LEADER_CHECKDATE", "船上部门长确认日期");
            dgvColumnStyle.Add("SHIP_BOSS_CHECKDATE", "船上船长确认日期");
            dgvColumnStyle.Add("LANDCHECKER", "岸端确认者");
            dgvColumnStyle.Add("CHECKDATE", "岸端确认日期");
            dgvColumnStyle.Add("STATE_NAME", "状态");
            dgvColumnStyle.Add("REMARK", "备注");
            dgvApply.SetDgvGridColumns(dgvColumnStyle, "mulselect");
            dgvApply.LoadGridView("FrmSparePurchaseApply.dgvApply");
        }
        /// <summary>
        /// 界面功能控件可见权限设置.
        /// </summary>
        private void CheckRightVisible()
        {
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)
                || "机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)
                || "总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是船管总经理.
                {
                    btnLandCheck.Visible = true;
                    btnCreateOrder.Visible = true;
                }
                btnEnquiry.Visible = true;
            }
            else
            {
                if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS)
                {
                    btnShipCheck.Visible = true;
                }
                else if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER)
                {
                    btndepartmentCheck.Visible = true;
                }
            }
            if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
            {
                btnCreateOrder.Visible = false;
                btnEnquiry.Visible = false;
                bdNgAddNewItem.Visible = false;
                bdNgEditItem.Visible = false;
                bdNgDeleteItem.Visible = false;
                btndepartmentCheck.Visible = false;
                btnShipCheck.Visible = false;
                btnPrint.Visible = false;
            }
        }
        /// <summary>
        /// 界面功能控件可用权限设置. 2014.2.17 刘子建修改
        /// </summary>
        private bool CheckRightEnabled(string pURCHASE_APPLYID, string pURCHASE_APPLY_PERSON, string sTATE)
        {
            //bool isParam = (param != null && param.Length > 0) ? true : false;

            //string pURCHASE_APPLYID = isParam ? param[0].ToString() : PURCHASE_APPLYID;
            //string pURCHASE_APPLY_PERSON = isParam ? param[1].ToString() : PURCHASE_APPLY_PERSON;
            //string sTATE = isParam ? param[2].ToString() : STATE;

            if (dgvApply.DataSource == null || dgvApply.Rows.Count == 0)
            {
                bdNgDeleteItem.Enabled = false;//删除.
                bdNgEditItem.Enabled = false;//编辑.

                btndepartmentCheck.Enabled = false; //部门长审核.
                btnShipCheck.Enabled = false;//船长审核.
                btnLandCheck.Enabled = false;//机务审核.

                return false;
            }

            if (currSelNum > 0)
            {
                return CheckRightEnabled(dgvApply.CurrentRow == null ? 0 : dgvApply.CurrentRow.Index);
            }

            bool isAddOrEdit = (pURCHASE_APPLY_PERSON == CommonOperation.ConstParameter.UserName && (sTATE == "0" || sTATE == "8")) || string.IsNullOrEmpty(pURCHASE_APPLYID);
            bool isExamine = false;

            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务主管.
                {
                    isAddOrEdit = isAddOrEdit || (pURCHASE_APPLY_PERSON == CommonOperation.ConstParameter.UserName && sTATE == "3");
                    isExamine = sTATE == "3" && pURCHASE_APPLY_PERSON != CommonOperation.ConstParameter.UserName;
                    //btnLandCheck.Enabled = isParam ? btnLandCheck.Enabled : isExamine;
                }
                else if ("机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务经理.
                {
                    isAddOrEdit = isAddOrEdit || (pURCHASE_APPLY_PERSON == CommonOperation.ConstParameter.UserName && (sTATE == "4"));
                    isExamine = (sTATE == "4") && pURCHASE_APPLY_PERSON != CommonOperation.ConstParameter.UserName;
                    //btnLandCheck.Enabled = isParam ? btnLandCheck.Enabled : isExamine;//机务审核.
                }
                else if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是船管总经理.
                {
                    isAddOrEdit = isAddOrEdit || (pURCHASE_APPLY_PERSON == CommonOperation.ConstParameter.UserName && sTATE == "5");
                    isExamine = sTATE == "5" && pURCHASE_APPLY_PERSON != CommonOperation.ConstParameter.UserName;
                    //btnLandCheck.Enabled = isParam ? btnLandCheck.Enabled : isExamine;//机务审核.
                }
            }
            else
            {
                if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS) //假如是船长.
                {
                    isAddOrEdit = isAddOrEdit || (pURCHASE_APPLY_PERSON == CommonOperation.ConstParameter.UserName && sTATE == "2");
                    isExamine = sTATE == "2" && pURCHASE_APPLY_PERSON != CommonOperation.ConstParameter.UserName;
                    //btnShipCheck.Enabled = isParam ? btnShipCheck.Enabled : isExamine;//船长审核.
                }
                else if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER) //假如是部门长 并且是申请人部门的部门长.
                {
                    isAddOrEdit = isAddOrEdit || (pURCHASE_APPLY_PERSON == CommonOperation.ConstParameter.UserName && sTATE == "1");
                    isExamine = sTATE == "1" && IsSelfDepartmentHead(DEPART_ID) && pURCHASE_APPLY_PERSON != CommonOperation.ConstParameter.UserName;
                    //btndepartmentCheck.Enabled = isParam ? btndepartmentCheck.Enabled : isExamine; //部门长审核.
                }
            }

            bdNgDeleteItem.Enabled = isAddOrEdit || isExamine;//删除.
            bdNgEditItem.Enabled = isAddOrEdit || isExamine;//编辑.

            btndepartmentCheck.Enabled = isExamine; //部门长审核.
            btnShipCheck.Enabled = isExamine;//船长审核.
            btnLandCheck.Enabled = isExamine;//机务审核.

            return isExamine;
        }
        /// <summary>
        /// 界面功能控件可用权限设置. 2014.2.21 刘子建增加.
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private bool CheckRightEnabled(int intRowNum)
        {
            if (dgvApply.DataSource == null || dgvApply.Rows.Count == 0) 
            {
                bdNgDeleteItem.Enabled = false;//删除.
                bdNgEditItem.Enabled = false;//编辑.

                btndepartmentCheck.Enabled = false; //部门长审核.
                btnShipCheck.Enabled = false;//船长审核.
                btnLandCheck.Enabled = false;//机务审核.

                return false; 
            }

            currSelNum = 0;
            string pURCHASE_APPLYID = "";
            string pURCHASE_APPLY_PERSON = "";
            string sTATE = "";

            bool isAddOrEditResult = true;
            bool isExamineResult = true;

            foreach (DataGridViewRow dr in dgvApply.Rows)
            {
                //校验是否选中.
                if (dr.Cells["mulSelect"] == null || !Convert.ToBoolean(dr.Cells["mulSelect"].Value))
                {
                    continue;
                }

                currSelNum++;
                pURCHASE_APPLYID = dr.Cells["PURCHASE_APPLYID"].Value.ToString();
                pURCHASE_APPLY_PERSON = dr.Cells["PURCHASE_APPLY_PERSON"].Value.ToString();
                sTATE = dr.Cells["STATE"].Value.ToString();

                bool isAddOrEdit = (pURCHASE_APPLY_PERSON == CommonOperation.ConstParameter.UserName && (sTATE == "0" || sTATE == "8")) || string.IsNullOrEmpty(pURCHASE_APPLYID);
                bool isExamine = false;

                if (CommonOperation.ConstParameter.IsLandVersion)
                {
                    if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务主管.
                    {
                        isAddOrEdit = isAddOrEdit || (pURCHASE_APPLY_PERSON == CommonOperation.ConstParameter.UserName && sTATE == "3");
                        isExamine = sTATE == "3" && pURCHASE_APPLY_PERSON != CommonOperation.ConstParameter.UserName;
                        //btnLandCheck.Enabled = isParam ? btnLandCheck.Enabled : isExamine;
                    }
                    else if ("机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务经理.
                    {
                        isAddOrEdit = isAddOrEdit || (pURCHASE_APPLY_PERSON == CommonOperation.ConstParameter.UserName && (sTATE == "4"));
                        isExamine = (sTATE == "4") && pURCHASE_APPLY_PERSON != CommonOperation.ConstParameter.UserName;
                        //btnLandCheck.Enabled = isParam ? btnLandCheck.Enabled : isExamine;//机务审核.
                    }
                    else if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是船管总经理.
                    {
                        isAddOrEdit = isAddOrEdit || (pURCHASE_APPLY_PERSON == CommonOperation.ConstParameter.UserName && sTATE == "5");
                        isExamine = sTATE == "5" && pURCHASE_APPLY_PERSON != CommonOperation.ConstParameter.UserName;
                        //btnLandCheck.Enabled = isParam ? btnLandCheck.Enabled : isExamine;//机务审核.
                    }
                }
                else
                {
                    if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS) //假如是船长.
                    {
                        isAddOrEdit = isAddOrEdit || (pURCHASE_APPLY_PERSON == CommonOperation.ConstParameter.UserName && sTATE == "2");
                        isExamine = sTATE == "2" && pURCHASE_APPLY_PERSON != CommonOperation.ConstParameter.UserName;
                        //btnShipCheck.Enabled = isParam ? btnShipCheck.Enabled : isExamine;//船长审核.
                    }
                    else if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER) //假如是部门长 并且是申请人部门的部门长.
                    {
                        isAddOrEdit = isAddOrEdit || (pURCHASE_APPLY_PERSON == CommonOperation.ConstParameter.UserName && sTATE == "1");
                        isExamine = sTATE == "1" && IsSelfDepartmentHead(DEPART_ID) && pURCHASE_APPLY_PERSON != CommonOperation.ConstParameter.UserName;
                        //btndepartmentCheck.Enabled = isParam ? btndepartmentCheck.Enabled : isExamine; //部门长审核.
                    }
                }

                if (isAddOrEditResult || isExamineResult)
                {
                    isAddOrEditResult = isAddOrEditResult ? isAddOrEdit : isAddOrEditResult;
                    isExamineResult = isExamineResult ? isExamine : isExamineResult;
                }
                else
                {
                    break;
                }
            }

            bdNgDeleteItem.Enabled = isAddOrEditResult || isExamineResult;//删除.
            bdNgEditItem.Enabled = isAddOrEditResult || isExamineResult;//编辑.

            btndepartmentCheck.Enabled = isExamineResult; //部门长审核.
            btnShipCheck.Enabled = isExamineResult;//船长审核.
            btnLandCheck.Enabled = isExamineResult;//机务审核.

            if (currSelNum == 0)
            {
                pURCHASE_APPLYID = dgvApply.Rows[intRowNum].Cells["PURCHASE_APPLYID"].Value.ToString();
                pURCHASE_APPLY_PERSON = dgvApply.Rows[intRowNum].Cells["PURCHASE_APPLY_PERSON"].Value.ToString();
                sTATE = dgvApply.Rows[intRowNum].Cells["STATE"].Value.ToString();

                CheckRightEnabled(pURCHASE_APPLYID, pURCHASE_APPLY_PERSON, sTATE);
            }

            return isExamineResult;
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

            #region wanhw-2014-12-03-修改--简化流程
            //dtbChkState.Rows.Add("00", "全部");
            //dtbChkState.Rows.Add("100", "未填写完毕或等待审核或被打回");
            //dtbChkState.Rows.Add("1", "等待部门长审批");
            //dtbChkState.Rows.Add("2", "等待船长审批");
            //dtbChkState.Rows.Add("3", "等待岸端机务主管审批");
            //dtbChkState.Rows.Add("4", "等待岸端机务经理审批");
            //dtbChkState.Rows.Add("5", "等待船管总经理审批");
            //dtbChkState.Rows.Add("6", "审核通过");
            //dtbChkState.Rows.Add("8", "被打回");
            //dtbChkState.Rows.Add("7", "取消");
            //dtbChkState.Rows.Add("9", "已订购");

            dtbChkState.Rows.Add("0", "全部");
            dtbChkState.Rows.Add("1", "待我处理"); //未填写完毕或等待审核或被打回
            dtbChkState.Rows.Add("2", "审批中");   //1 2 3 4 5
            dtbChkState.Rows.Add("3", "订购中");   //6
            dtbChkState.Rows.Add("4", "结束");     //7 9
            cboChkState.DataSource = dtbChkState;
            cboChkState.SelectedIndex = 1;
            #endregion

            #endregion
        }
        #region 筛选条件控件事件

        private void cbPost_CheckedChanged(object sender, EventArgs e)
        {
            this.setBindingSource();
        }
        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            this.setBindingSource();
        }
        private void ucDepartmentSelect1_TheSelectedChanged(string theSelectedObject)
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
        /// 审核函数. 2014.2.18 刘子建修改
        /// </summary>
        /// <param name="functionCode"></param>
        private void AuditingFunction(string functionCode)
        {
            //if (dgvApply.CurrentRow == null)
            //{
            //    MessageBoxEx.Show("未选中任何行!");
            //    return;
            //}

            FrmSparePurchaseApplyEdit frm;

            //判断是否为多选审核 2014.2.17 刘子建增加
            DataTable dtPURCHASE = GetMulSelectID(true, true);
            if (dgvApply.CurrentRow == null && dtPURCHASE == null)
            {
                //frm = new FrmSparePurchaseApplyEdit(PURCHASE_APPLYID);
                //frm.ShowDialog();
                //this.setBindingSource();

                MessageBoxEx.Show("未选择任何申请项目!", "提示");
                return;
            }
            else if (dtPURCHASE.Rows.Count != 0)
            {
                frm = new FrmSparePurchaseApplyEdit(dtPURCHASE);
                frm.ShowDialog();
                this.setBindingSource();
            }
        }
        /// <summary>
        /// 部门长审核事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btndepartmentCheck_Click(object sender, EventArgs e)
        {
            AuditingFunction("3");
        }
        /// <summary>
        /// 船长审核事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShipCheck_Click(object sender, EventArgs e)
        {
            AuditingFunction("3");
        }
        /// <summary>
        /// 机务审核事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLandCheck_Click(object sender, EventArgs e)
        {
            AuditingFunction("3");
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
        /// 当申请单信息网格行改变时，显示当前行的申请单明细信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvApply_SelectedChanged(int rowNumber)
        {
            if (dgvApply.DataSource == null || dgvApply.Rows.Count == 0 || isFirstLoad) return;
            if (dgvApply.Rows[rowNumber].Cells["PURCHASE_APPLYID"].Value == null) return;
            PURCHASE_APPLYID = dgvApply.Rows[rowNumber].Cells["PURCHASE_APPLYID"].Value.ToString();
            STATE = dgvApply.Rows[rowNumber].Cells["STATE"].Value.ToString();
            DEPART_ID = dgvApply.Rows[rowNumber].Cells["DEPART_ID"].Value.ToString();
            PURCHASE_APPLY_PERSON = dgvApply.Rows[rowNumber].Cells["PURCHASE_APPLY_PERSON"].Value.ToString();
            ISCOMPLETE = dgvApply.Rows[rowNumber].Cells["ISCOMPLETE"].Value.ToString();
            string PURCHASE_APPLY_CODE = dgvApply.Rows[rowNumber].Cells["PURCHASE_APPLY_CODE"].Value.ToString();
            string SHIP_ID = dgvApply.Rows[rowNumber].Cells["SHIP_ID"].Value.ToString();

            CheckRightEnabled(rowNumber);

            //CheckRightEnabled(PURCHASE_APPLYID, PURCHASE_APPLY_PERSON, STATE);

            ShowDataToForm();
            FileOperation.FileBoundingOperation.Instance.FileBoundCheck(PURCHASE_APPLYID,
                PURCHASE_APPLY_CODE, FileBoundingTypes.SPEARAPPLY, SHIP_ID);

        }
        private void dgvApply_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowNumber = dgvApply.CurrentRow.Index;

            CheckRightEnabled(rowNumber);
        }
        /// <summary>
        /// 显示数据到控件上.
        /// </summary>
        private void ShowDataToForm()
        {
            DataTable dt = (DataTable)dgvApply.DataSource;
            DataRow drItem = dt.Select("PURCHASE_APPLYID='" + PURCHASE_APPLYID + "'")[0];
            txtShip.Text = drItem["SHIP_NAME"].ToString();
            txtComponent.Text = drItem["COMP_FULL_NAME"].ToString();
            txtPURCHASE_APPLY_CODE.Text = drItem["PURCHASE_APPLY_CODE"].ToString();
            txtPURCHASE_APPLY_PERSON.Text = drItem["PURCHASE_APPLY_PERSON"].ToString();
            txtHEADSHIP_NAME.Text = drItem["HEADSHIP_NAME"].ToString();
            txtPURCHASE_APPLY_DATE.Text = drItem["PURCHASE_APPLY_DATE"].ToString();
            txtDEPARTNAME.Text = drItem["DEPARTNAME"].ToString();
            txtSHIP_LEADER_CHECKER.Text = drItem["SHIP_LEADER_CHECKER"].ToString();
            txtSHIP_LEADER_CHECKDATE.Text = drItem["SHIP_LEADER_CHECKDATE"].ToString();
            txtSHIP_BOSS_CHECKER.Text = drItem["SHIP_BOSS_CHECKER"].ToString();
            txtSHIP_BOSS_CHECKDATE.Text = drItem["SHIP_BOSS_CHECKDATE"].ToString();
            txtLANDCHECKER.Text = drItem["LANDCHECKER"].ToString();
            txtCHECKDATE.Text = drItem["CHECKDATE"].ToString();
            txtREMARK.Text = drItem["REMARK"].ToString();

            DataTable dtDetail;
            string err;
            if (!SparePurchaseApplyDetailService.Instance.GetInfo(PURCHASE_APPLYID, out dtDetail, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            dgvDetail.DataSource = dtDetail;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("SPARE_NAME", "备件");
            dic.Add("PARTNUMBER", "采购号或规格");
            dic.Add("UNIT_NAME", "单位");
            dic.Add("APPLYCOUNT", "申请数量");
            if (CommonOperation.ConstParameter.IsLandVersion || (!CommonOperation.ConstParameter.IsLandVersion && STATE == "6"))
                dic.Add("CONFIRMEDCOUNT", "批准数量");
            dic.Add("PICNUMBER", "图纸号");
            dic.Add("REMARK", "备注");
            dgvDetail.SetDgvGridColumns(dic);

            foreach (DataGridViewColumn item in dgvDetail.Columns)
                item.ReadOnly = true;
        }
        /// <summary>
        /// 全选(仅审批范围)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAllSelect_Click(object sender, EventArgs e)
        {
            //List<string> idList = new List<string>();
            //foreach (DataGridViewRow item in dgvApply.Rows)
            //{
            //    string projectStatus = item.Cells["PROJECTSTATE"].Value.ToString();
            //    string departmentID = item.Cells["DEPARTMENTID"].Value.ToString();
            //    if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS && projectStatus == "3")
            //        idList.Add(item.Cells["PROJECTID"].Value.ToString());
            //    else if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER && IsSelfDepartmentHead(departmentID) && projectStatus == "2")
            //    {
            //        idList.Add(item.Cells["PROJECTID"].Value.ToString());
            //    }
            //    else if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME) && projectStatus == "4") //假如是机务主管.
            //    {
            //        idList.Add(item.Cells["PROJECTID"].Value.ToString());
            //    }
            //    else if ("机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME) && projectStatus == "5") //假如是机务经理.
            //    {
            //        idList.Add(item.Cells["PROJECTID"].Value.ToString());
            //    }
            //    else if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME) && projectStatus == "6") //假如是船管总经理.
            //    {
            //        idList.Add(item.Cells["PROJECTID"].Value.ToString());
            //    }
            //}
            //if (idList.Count > 0)
            //{
            //    FrmRepairDuoAudit frmRepairDuoAudit = new FrmRepairDuoAudit(idList);
            //    frmRepairDuoAudit.ShowDialog();
            //}
            //else
            //{
            //    MessageBoxEx.Show("没有需要审核的申请信息");
            //}
            //this.setBindingSource();
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

            if ((STATE == "0" || STATE == "8") && PURCHASE_APPLY_PERSON == CommonOperation.ConstParameter.UserName)
            {
                if (!SparePurchaseApplyDetailService.Instance.DeleteByPurchaseApplyID(PURCHASE_APPLYID, out err))
                {
                    MessageBoxEx.Show(err, "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (!SparePurchaseApplyService.Instance.deleteUnit(PURCHASE_APPLYID, out err))
                {
                    MessageBoxEx.Show(err, "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                if (DialogResult.No == MessageBoxEx.Show("删除操作会把该信息状态变为作废,确定吗?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                    return;
                SparePurchaseApply spa = SparePurchaseApplyService.Instance.getObject(PURCHASE_APPLYID, out err);
                spa.STATE = 7;
                if (!SparePurchaseApplyService.Instance.saveUnit(spa, out err))
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

            FrmSparePurchaseApplyEdit frm;

            DataTable dtPURCHASE = GetMulSelectID(false, true);

            if (dtPURCHASE != null && dtPURCHASE.Rows.Count > 0)
            {
                frm = new FrmSparePurchaseApplyEdit(dtPURCHASE);
            }
            else
            {
                frm = new FrmSparePurchaseApplyEdit(PURCHASE_APPLYID);
            }

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
            FrmSparePurchaseApplyEdit frm = new FrmSparePurchaseApplyEdit("");
            frm.ShowDialog();
            this.setBindingSource();
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

            FrmSparePurchaseApplyEdit frm;

            DataTable dtPURCHASE = GetMulSelectID(false, true);

            if (dtPURCHASE != null && dtPURCHASE.Rows.Count > 0)
            {
                frm = new FrmSparePurchaseApplyEdit(dtPURCHASE);
            }
            else
            {
                frm = new FrmSparePurchaseApplyEdit(PURCHASE_APPLYID);
            }

            frm.ShowDialog();
            this.setBindingSource();
        } 

        /// <summary>
        /// 快速生成订单.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            List<string> idList;
            if (!GetMulSelectID(out idList))
                return;
            if (idList.Count == 0)
            {
                MessageBoxEx.Show("未勾选任何项!");
                return;
            }
            FrmSparePurchaseOrderEdit frm = new FrmSparePurchaseOrderEdit(idList, 2);
            frm.ShowDialog();
            this.setBindingSource();
        }
        /// <summary>
        /// 取得并校验多选数据是否合法. 2014.2.17 刘子建增加
        /// </summary>
        /// <returns></returns>
        private DataTable GetMulSelectID(bool isCheck, bool isEnabelNonSel)
        {
            DataTable dtPURCHASE = new DataTable();
            DataTable dtTEMP = ((DataTable)dgvApply.DataSource).Copy();

            dtPURCHASE = dtTEMP.Clone();

            foreach (DataRow dr in dtTEMP.Rows)
            {
                int drNum = dtTEMP.Rows.IndexOf(dr);

                //校验是否选中.
                if (dgvApply.Rows[drNum].Cells["mulSelect"] == null || !Convert.ToBoolean(dgvApply.Rows[drNum].Cells["mulSelect"].Value))
                {
                    continue;
                }

                //校验是否为合法审核数据.
                if (isCheck && !CheckRightEnabled(
                    dr["PURCHASE_APPLYID"].ToString(), 
                    dr["PURCHASE_APPLY_PERSON"].ToString(),
                    dr["STATE"].ToString()))
                {
                    MessageBox.Show("存在无法操作的申请项目,请重新选择", "提示");
                    return new DataTable();
                }

                //增加ID到集合中.
                dtPURCHASE.Rows.Add(dr.ItemArray);
            }

            if (isEnabelNonSel && dtPURCHASE.Rows.Count == 0)
            {
                int drNum = dgvApply.CurrentRow.Index;

                //校验是否为合法审核数据.
                if (isCheck && !CheckRightEnabled(
                    dtTEMP.Rows[drNum]["PURCHASE_APPLYID"].ToString(), 
                    dtTEMP.Rows[drNum]["PURCHASE_APPLY_PERSON"].ToString(),
                    dtTEMP.Rows[drNum]["STATE"].ToString()))
                {
                    MessageBox.Show("无法操作所选择的申请项目,请重新选择", "提示");
                    return new DataTable();
                }

                //增加ID到集合中.
                dtPURCHASE.Rows.Add(dtTEMP.Rows[drNum].ItemArray);
            }

            return dtPURCHASE.Rows.Count == 0 ? null : dtPURCHASE;
        }
        private bool GetMulSelectID(out List<string> idList)
        {
            List<DataGridViewRow> dataGridViewRowList = new List<DataGridViewRow>();
            idList = new List<string>();
            foreach (DataGridViewRow item in dgvApply.Rows)
            {
                if (item.Cells["mulSelect"].Value != null && Convert.ToBoolean(item.Cells["mulSelect"].Value))
                {
                    idList.Add(item.Cells["PURCHASE_APPLYID"].Value.ToString());
                    dataGridViewRowList.Add(item);
                }
            }

            foreach (DataGridViewRow item in dataGridViewRowList)
            {
                if (item.Cells["SHIP_ID"].Value.ToString() != dataGridViewRowList[0].Cells["SHIP_ID"].Value.ToString())
                {
                    MessageBoxEx.Show("只能选择相同船舶的申请项目");
                    return false;
                }
                if (item.Cells["STATE"].Value.ToString() != "6")
                {
                    MessageBoxEx.Show("只能选择审核通过的申请项目");
                    return false;
                }
            }

            if (idList.Count == 0 && dgvApply.CurrentRow != null)
            {
                if (dgvApply.CurrentRow.Cells["STATE"].Value.ToString() == "6")
                {
                    idList.Add(dgvApply.CurrentRow.Cells["PURCHASE_APPLYID"].Value.ToString());
                }
                else
                {
                    MessageBoxEx.Show("只能选择审核通过的申请项目");
                    return false;
                }
            }

            return true;
        }
        /// <summary>
        /// 申请打印.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgPrintItem_Click(object sender, EventArgs e)
        {
            if (dgvApply.CurrentRow == null)
            {
                MessageBoxEx.Show("未选中任何申请单,不能打印");
                return;
            }
            if (StorageConfig.customSparePurchaseApplyPrint != null)
            {
                string err;
                if (!StorageConfig.customSparePurchaseApplyPrint(PURCHASE_APPLYID, out err))
                {
                    MessageBoxEx.Show("打印失败,错误参考\r" + err);
                }
            }
        }
        /// <summary>
        /// 释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSparePurchaseApply_FormClosing(object sender, FormClosingEventArgs e)
        {
            //清除大文档绑定功能.
            FileOperation.FileBoundingOperation.Instance.FileBoundCheck("", "", 0, "");
            dgvApply.SaveGridView("FrmSparePurchaseApply.dgvApply");
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
        /// <summary>
        /// 生成询价单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnquiry_Click(object sender, EventArgs e)
        {
            if (dgvApply.CurrentRow == null)
            {
                MessageBoxEx.Show("未选中任何申请单,不能打印");
                return;
            }
            if (StorageConfig.customSparePurchaseAskPricePrint != null)
            {
                string err;
                if (!StorageConfig.customSparePurchaseAskPricePrint(PURCHASE_APPLYID, out err))
                {
                    MessageBoxEx.Show("打印失败,错误参考\r" + err);
                }
            }
        }
        public void SetRemindViewApprovalState()
        {
            ucShipSelect1.SelectedText("所有船");
            cboChkState.Text = "未填写完毕或等待审核或被打回";
            ucDepartmentSelect1.SelectedText("全部");
            cbPost.Checked = false;
        }

        public void SetRemindViewInformState()
        {
            ucShipSelect1.SelectedText("所有船");
            cboChkState.Text = "审核通过";
            ucDepartmentSelect1.SelectedText("全部");
            cbPost.Checked = false;
        }

        
    }
}
