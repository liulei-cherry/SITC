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
    public partial class FrmMaterialPurchaseApply : CommonViewer.BaseForm.FormBase, CommonOperation.Interfaces.IRemindViewState
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmMaterialPurchaseApply instance = new FrmMaterialPurchaseApply();
        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmMaterialPurchaseApply Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmMaterialPurchaseApply.instance = new FrmMaterialPurchaseApply();
                }

                return FrmMaterialPurchaseApply.instance;
            }
        }
        private FrmMaterialPurchaseApply()
        {
            InitializeComponent();
        }
        #endregion

        #region 当前行关键值
        private bool isFirstLoad = true;

        private string PURCHASE_APPLYID = "";
        private string STATE = "";
        private string DEPART_ID = "";
        private string PURCHASE_APPLY_PERSON = "";
        private string ISCOMPLETE = "";

        private bool loadingFinish = false;
        #endregion

        #region 加载窗体相关方法
        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMaterialPurchaseApply_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;//窗体最大化.
            //查询条件默认为3个月的数据.

            dtpStartDate.Value = DateTime.Now.AddMonths(-3);
            dtpEndDate.Value = DateTime.Now;

            ucDepartmentSelect1.ChangeMode(3);
            CheckRightVisible();      //功能权限校验.
            this.setComboBox();     //设置窗体所需的下拉列表框的数据源.
            ucShipSelect1.ChangeSelectedState(true, true);
            CheckRightEnabled(0);
            loadingFinish = true;
            this.setBindingSource();//设置数据源.
            this.setDataGridView(); //设置网格控件dgvApply的隐藏列与标头的设置.    

            isFirstLoad = false;
        }

        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {
            #region 2014年5月19日 徐正本增加的新代码 修改为 船端岸端均为相同的五个状态（全部，待我处理，审批中，订购中，结束）
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
            row1["State"] = "待我处理";// "未填写完毕或等待审核或被打回";
            dtbChkState.Rows.Add(row1);
            DataRow row2 = dtbChkState.NewRow();
            row2["Id"] = "2";
            row2["State"] = "审批中";// 1,2,3,4,5五种状态
            dtbChkState.Rows.Add(row2);
            DataRow row3 = dtbChkState.NewRow();
            row3["Id"] = "3";
            row3["State"] = "订购中";//6,-2;
            dtbChkState.Rows.Add(row3);
            DataRow row4 = dtbChkState.NewRow();
            row4["Id"] = "4";
            row4["State"] = "结束";//-1,7,9
            dtbChkState.Rows.Add(row4);

            cboChkState.DataSource = dtbChkState;
            cboChkState.SelectedIndex = 1;
            #endregion
        }

        /// <summary>
        /// 绑定信息.
        /// </summary>
        private void setBindingSource()
        {
            if (!loadingFinish) return;

            #region 准备过滤条件
            string shipId = ucShipSelect1.GetId();//船舶.
            string onlyPostID = cbPost.Checked ? CommonOperation.ConstParameter.LoginUserInfo.PostId : null;  //仅本岗位.
            string state = "";
            if (cboChkState.SelectedValue == null || cboChkState.SelectedValue.ToString() == "0" || cboChkState.SelectedValue.ToString() == "1")
                state = "";
            else
            {
                state = MaterialPurchaseApplyService.Instance.GetBusinessStateByViewerState(cboChkState.SelectedValue.ToString());
            }
            string department = ucDepartmentSelect1.GetId() == "0" ? null : ucDepartmentSelect1.GetId();//部门.

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
            sb.Append(" and (ISCOMPLETE=1 or ( ISCOMPLETE=0 and PURCHASE_APPLY_PERSON='" + CommonOperation.ConstParameter.UserName + "'))");

            if (cboChkState.SelectedValue != null && cboChkState.SelectedValue.ToString() == "1")
            {
                sb.Append(" and ( 1<>1  ");
                if (CommonOperation.ConstParameter.IsLandVersion)
                {
                    if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
                        sb.AppendLine(" or STATE =3");
                    else if ("机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
                        //2014年8月18日 徐正本，修改下面代码 sb.AppendLine(" or STATE =4 or STATE =3");让机务经理只能处理机务主管审批完的信息。
                        sb.AppendLine(" or STATE =4");
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

            //string shipId = ucShipSelect1.GetId();//船舶.
            //string onlyPostID = cbPost.Checked ? CommonOperation.ConstParameter.LoginUserInfo.PostId : null;  //仅本岗位.
            //string state = "";
            //if (cboChkState.SelectedValue == null || cboChkState.SelectedValue.ToString() == "0" || cboChkState.SelectedValue.ToString() == "1")
            //    state = "";
            //else
            //{
            //    state = MaterialPurchaseApplyService.Instance.GetBusinessStateByViewerState(cboChkState.SelectedValue.ToString());
            //}
            //string department = ucDepartmentSelect1.GetId() == "0" ? null : ucDepartmentSelect1.GetId();//部门.
            DataTable dtbApply;
            string err;
            if (!MaterialPurchaseApplyService.Instance.SelectDataTable(sb.ToString(), out dtbApply, out err))//取得信息的DataTable对象.
            {
                MessageBoxEx.Show(err);
                return;
            }
            //StringBuilder sb = new StringBuilder();
            //sb.Append("1=1");
            //sb.Append(" and (ISCOMPLETE=1 or ( ISCOMPLETE=0 and PURCHASE_APPLY_PERSON='" + CommonOperation.ConstParameter.UserName + "'))");

            //if (cboChkState.SelectedValue != null && cboChkState.SelectedValue.ToString() == "1")
            //{
            //    sb.Append(" and ( 1<>1  ");
            //    if (CommonOperation.ConstParameter.IsLandVersion)
            //    {
            //        if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
            //            sb.AppendLine(" or STATE =3");
            //        else if ("机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
            //            //2014年8月18日 徐正本，修改下面代码 sb.AppendLine(" or STATE =4 or STATE =3");让机务经理只能处理机务主管审批完的信息。
            //            sb.AppendLine(" or STATE =4");
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
            dgvApply.DataSource = dtbApply;
            //dgvApply.Sort(dgvApply.Columns["PURCHASE_APPLY_DATE"], ListSortDirection.Descending);
            if (dgvApply.Rows.Count == 0)//没有数据时
            {
                FileOperation.FileBoundingOperation.Instance.FileBoundCheck("", "", 0, "");
                CheckRightEnabled(null, null, null);//liulei-2016/03/25-增加
            }
        }

        /// <summary>
        ///  设置信息网格控件的隐藏列与显示标题.
        /// </summary>
        private void setDataGridView()
        {
            Dictionary<string, string> dgvColumnStyle = new Dictionary<string, string>();
            dgvColumnStyle.Add("PURCHASE_APPLY_CODE", "处理单号");
            dgvColumnStyle.Add("SHIP_NAME", "船舶");
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
            dgvApply.SetDgvGridColumns(dgvColumnStyle, "mulSelect");
            dgvApply.LoadGridView("FrmMaterialPurchaseApply.dgvApply");
        }

        /// <summary>
        /// 显示数据到控件上.
        /// </summary>
        private void ShowDataToForm()
        {
            DataTable dt = (DataTable)dgvApply.DataSource;
            DataRow drItem = dt.Select("PURCHASE_APPLYID='" + PURCHASE_APPLYID + "'")[0];
            txtShip.Text = drItem["SHIP_NAME"].ToString();
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
            if (!MaterialPurchaseApplyDetailService.Instance.GetInfo(PURCHASE_APPLYID, out dtDetail, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            dgvDetail.DataSource = dtDetail;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("MATERIAL_NAME", "物资");
            dic.Add("MATERIAL_CODE", "物资编号");
            dic.Add("MATERIAL_SPEC", "采购号或规格");
            dic.Add("UNIT_NAME", "单位");
            dic.Add("APPLYCOUNT", "申请数量");
            if (CommonOperation.ConstParameter.IsLandVersion || (!CommonOperation.ConstParameter.IsLandVersion && STATE == "6"))
                dic.Add("CONFIRMEDCOUNT", "批准数量");
            dic.Add("REMARK", "备注");
            dgvDetail.SetDgvGridColumns(dic);

            foreach (DataGridViewColumn item in dgvDetail.Columns)
                item.ReadOnly = true;
        }

        #endregion


        #region 按钮是否可视的判断
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
                    btnCreateNewApply.Visible = true;
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
            }
        }

        /// <summary>
        /// 界面功能控件可用权限设置. 2014.2.21 刘子建修改
        /// 
        /// 2014年5月21日徐正本，这里代码这么写很乱，按钮操作和业务判断集成到一起了，
        /// 但实在没有精力去修改了。
        /// </summary>
        private bool CheckRightEnabled(string pURCHASE_APPLYID, string pURCHASE_APPLY_PERSON, string sTATE)
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
   
        private bool CheckRightEnabled(DataGridViewRow dgvr)
        {
            if (dgvr == null) return false;
            string pURCHASE_APPLYID = dgvr.Cells["PURCHASE_APPLYID"].Value.ToString();
            string pURCHASE_APPLY_PERSON = dgvr.Cells["PURCHASE_APPLY_PERSON"].Value.ToString();
            string sTATE = dgvr.Cells["STATE"].Value.ToString();
            return CheckRightEnabled(pURCHASE_APPLYID, pURCHASE_APPLY_PERSON, sTATE);
        }

        /// <summary>
        /// 界面功能控件可用权限设置. 2014年5月21日 徐正本修改刘子建原有写法，原来拷贝的代码太多，很难处理。
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private bool CheckRightEnabled(int intRowNum)
        {
            if (intRowNum >= dgvApply.Rows.Count || intRowNum < 0) return false;

            return CheckRightEnabled(dgvApply.Rows[intRowNum]);
        }

        #endregion

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
            //根据状态，修改按钮的可视程度
            tsm_finishApply.Enabled = (cboChkState.SelectedValue.ToString() == "3");

            this.setBindingSource();
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            this.setBindingSource();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            this.setBindingSource();
        }
        #endregion

        #region 审核部分

        /// <summary>
        /// 审核函数
        /// </summary>
        private void AuditingFunction()
        {
            FrmMaterialPurchaseApplyEdit frm;
            List<string> applyIds;
            if (!GetMulSelectID(CheckOperationEnable, out applyIds))
            {
                return;
            }
            if (applyIds != null && applyIds.Count > 0)
            {
                frm = new FrmMaterialPurchaseApplyEdit(applyIds, 0);
            }
            else if (string.IsNullOrEmpty(PURCHASE_APPLYID))
            {
                MessageBoxEx.Show("未选择任何申请项目!", "提示");
                return;
            }
            else
            {
                frm = new FrmMaterialPurchaseApplyEdit(PURCHASE_APPLYID);
            }

            frm.ShowDialog();
            this.setBindingSource();
        }

        /// <summary>
        /// 部门长审核事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btndepartmentCheck_Click(object sender, EventArgs e)
        {
            AuditingFunction();
        }

        /// <summary>
        /// 船长审核事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShipCheck_Click(object sender, EventArgs e)
        {
            AuditingFunction();
        }

        /// <summary>
        /// 机务审核事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLandCheck_Click(object sender, EventArgs e)
        {
            AuditingFunction();
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

        #region 按钮部分
        /// <summary>
        /// 当申请单信息网格行改变时，显示当前行的申请单明细信息. 2014.2.21 刘子建修改.
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

            CheckRightEnabled(rowNumber);

            //CheckRightEnabled(PURCHASE_APPLYID, PURCHASE_APPLY_PERSON, STATE);

            ShowDataToForm();
            string PURCHASE_APPLY_CODE = dgvApply.Rows[rowNumber].Cells["PURCHASE_APPLY_CODE"].Value.ToString();
            string SHIP_ID = dgvApply.Rows[rowNumber].Cells["SHIP_ID"].Value.ToString();

            FileOperation.FileBoundingOperation.Instance.FileBoundCheck(PURCHASE_APPLYID,
               PURCHASE_APPLY_CODE, FileBoundingTypes.ITEMSAPPLY, SHIP_ID);
        }

        /// <summary>
        /// 单击单元格内容事件. 2014.2.21 刘子建增加.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvApply_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvApply.CurrentCell != null)
            {
                int rowNumber = dgvApply.CurrentRow.Index;

                CheckRightEnabled(rowNumber);
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
            if (dgvApply.CurrentRow == null)
            {
                MessageBoxEx.Show("未选中任何行!");
                return;
            }
            if (DialogResult.No == MessageBoxEx.Show("确认删除该条信息吗?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                return;

            if ((STATE == "0" || STATE == "8") && PURCHASE_APPLY_PERSON == CommonOperation.ConstParameter.UserName)
            {
                if (!MaterialPurchaseApplyDetailService.Instance.DeleteByPurchaseApplyID(PURCHASE_APPLYID, out err))
                {
                    MessageBoxEx.Show(err, "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (!MaterialPurchaseApplyService.Instance.deleteUnit(PURCHASE_APPLYID, out err))
                {
                    MessageBoxEx.Show(err, "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                if (DialogResult.No == MessageBoxEx.Show("删除操作会把该信息状态变为作废,确定吗?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                    return;
                MaterialPurchaseApply spa = MaterialPurchaseApplyService.Instance.getObject(PURCHASE_APPLYID, out err);
                spa.STATE = 7;
                if (!MaterialPurchaseApplyService.Instance.saveUnit(spa, out err))
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

            FrmMaterialPurchaseApplyEdit frm;
            List<string> applyIds;
            if (!GetMulSelectID(null, out applyIds))
            {
                return;
            }
            if (applyIds != null && applyIds.Count > 0)
            {
                frm = new FrmMaterialPurchaseApplyEdit(applyIds, 0);
            }
            else
            {
                frm = new FrmMaterialPurchaseApplyEdit(PURCHASE_APPLYID);
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
            FrmMaterialPurchaseApplyEdit frm = new FrmMaterialPurchaseApplyEdit();
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

            FrmMaterialPurchaseApplyEdit frm = new FrmMaterialPurchaseApplyEdit(dgvApply.CurrentRow.Cells["PURCHASE_APPLYID"].Value.ToString());

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
            CreateOrder(true);
        }
        /// <summary>
        /// 快速生成订单.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateOrderOnlyNotOrder_Click(object sender, EventArgs e)
        {
            CreateOrder(false);
        }

        private void CreateOrder(bool withOrderedData, bool checkState = true)
        {
            List<string> idList;
            if (!checkState)
            {
                if (!GetMulSelectID(null, out idList)) return;
            }
            else
            {
                if (!GetMulSelectID(CheckStateOfFinishCheck, out idList)) return;
            }

            if (idList.Count == 0)
            {
                MessageBoxEx.Show("未勾选任何项!");
                return;
            }
            FrmMaterialPurchaseOrderEdit frm = new FrmMaterialPurchaseOrderEdit(idList, withOrderedData ? 2 : 4);
            frm.ShowDialog();
            this.setBindingSource();
        }

        /// <summary>
        /// 不管什么单子，都可以形成订单的处理。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsm_ForceCreateOrder_Click(object sender, EventArgs e)
        {
            CreateOrder(true, false);
        }

        private void tsm_finishApply_Click(object sender, EventArgs e)
        {
            List<string> idList;
            if (GetMulSelectID(null, out idList, false) && idList.Count > 0)
                MaterialPurchaseApplyService.Instance.FinishAllApplyBillAndChangeState(idList);
            this.setBindingSource();
        }
        #endregion

        #region 多选部分，徐正本 2014年5月21日 重新整理
        private bool GetMulSelectID(CheckState checkStateFunction, out List<string> idList, bool SameShipCheck = true)
        {
            List<DataGridViewRow> dataGridViewRowList = new List<DataGridViewRow>();

            string err;

            idList = new List<string>();
            foreach (DataGridViewRow item in dgvApply.Rows)
            {
                if (item.Cells["mulSelect"].Value != null && Convert.ToBoolean(item.Cells["mulSelect"].Value))
                {
                    idList.Add(item.Cells["PURCHASE_APPLYID"].Value.ToString());
                    dataGridViewRowList.Add(item);
                }
            }
            if (SameShipCheck)
            {
                foreach (DataGridViewRow item in dataGridViewRowList)
                {
                    if (item.Cells["SHIP_ID"].Value.ToString() != dataGridViewRowList[0].Cells["SHIP_ID"].Value.ToString())
                    {
                        MessageBoxEx.Show("只能选择相同船舶的申请项目");
                        return false;
                    }

                    if (checkStateFunction != null && !checkStateFunction(item, out err))
                    {
                        MessageBoxEx.Show(err);
                        return false;
                    }
                }
            }
            if (checkStateFunction != null && idList.Count == 0 && dgvApply.CurrentRow != null)
            {
                if (checkStateFunction(dgvApply.CurrentRow, out err))
                {
                    idList.Add(dgvApply.CurrentRow.Cells["PURCHASE_APPLYID"].Value.ToString());
                }
                else
                {
                    MessageBoxEx.Show(err);
                    return false;
                }
            }

            return true;
        }
        delegate bool CheckState(DataGridViewRow oneRow, out string err);
        private bool CheckStateOfFinishCheck(DataGridViewRow oneRow, out string err)
        {
            err = "";
            if (oneRow != null && (oneRow.Cells["STATE"].Value.ToString() == "6" || oneRow.Cells["STATE"].Value.ToString() == "-2")) return true;
            //将审核通过的（状态为6）权限放开，允许其合并
            //if (oneRow != null && (oneRow.Cells["STATE"].Value.ToString() == "-2")) return true;

            err = "只能选择通过申请审核状态的申请项目";
            return false;

        }
        private bool CheckStateOfCombinedBill(DataGridViewRow oneRow, out string err)
        {
            err = "";
            if (oneRow != null && (oneRow.Cells["STATE"].Value.ToString() == "1" ||
            (oneRow.Cells["STATE"].Value.ToString() == "0" && oneRow.Cells["HEADSHIP_NAME"].Value.ToString() == CommonOperation.ConstParameter.LoginUserInfo.ShipHeadShipName))
                ) return true;

            err = "只能选择部门长自己未填写完毕或其他本部门填写完毕的申请项目";
            return false;
        }
        private bool CheckOperationEnable(DataGridViewRow oneRow, out string err)
        {
            err = "";
            bool canOperation = CheckRightEnabled(oneRow); ;
            if (!canOperation)
            {
                err = "存在无法操作的申请项目,请重新选择";
                return false;
            }
            return true;
        }
        #endregion

        #region 打印部分
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
            if (StorageConfig.customMaterialPurchaseApplyPrint != null)
            {
                string err;
                if (!StorageConfig.customMaterialPurchaseApplyPrint(PURCHASE_APPLYID, out err))
                {
                    MessageBoxEx.Show("打印失败,错误参考\r" + err);
                }
            }
        }

        private void btnEnquiry_Click(object sender, EventArgs e)
        {
            if (dgvApply.CurrentRow == null)
            {
                MessageBoxEx.Show("未选中任何申请单,不能打印");
                return;
            }
            if (StorageConfig.customMaterialPurchaseAskPricePrint != null)
            {
                string err;
                if (!StorageConfig.customMaterialPurchaseAskPricePrint(PURCHASE_APPLYID, out err))
                {
                    MessageBoxEx.Show("打印失败,错误参考\r" + err);
                }
            }
        }
        #endregion

        #region 关闭窗体
        /// <summary>
        /// 释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMaterialPurchaseApply_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileOperation.FileBoundingOperation.Instance.FileBoundCheck("", "", 0, "");
            dgvApply.SaveGridView("FrmMaterialPurchaseApply.dgvApply");
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
        #endregion

        #region IRemindViewState 成员 报警提醒的入口。

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

        #endregion

        #region 合单功能
        private void btnCreateNewApply_Click(object sender, EventArgs e)
        {
            //zhangy2013-8-8
            List<String> applyIdList = new List<String>();
            if (!GetMulSelectID(CheckStateOfCombinedBill, out applyIdList))
                return;
            if (applyIdList.Count == 0)
            {
                MessageBoxEx.Show("请选择申请单!");
                return;
            }
            else if (applyIdList.Count == 1) { MessageBox.Show("请至少选择两个以上的申请单！"); return; }
            FrmMaterialPurchaseApplyEdit frm = new FrmMaterialPurchaseApplyEdit(applyIdList, 1);
            frm.ShowDialog();
            this.setBindingSource();
        }
        #endregion


    }
}
