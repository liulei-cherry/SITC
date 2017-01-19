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
using ItemsManage;

namespace StorageManage.Viewer
{
    public partial class FrmMaterialPurchaseApplySelect : CommonViewer.BaseForm.FormBase
    {
        private string shipId = "";//船舶.
        public List<StorageParameter> spareids = new List<StorageParameter>();
        #region 窗体单实例模型
        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmMaterialPurchaseApplySelect instance = new FrmMaterialPurchaseApplySelect();
        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmMaterialPurchaseApplySelect Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmMaterialPurchaseApplySelect.instance = new FrmMaterialPurchaseApplySelect();
                }

                return FrmMaterialPurchaseApplySelect.instance;
            }
        }
        private FrmMaterialPurchaseApplySelect()
        {
            InitializeComponent();
        }

        public FrmMaterialPurchaseApplySelect(string paramShipID)
        {
            InitializeComponent();
            shipId = paramShipID;
            ucShipSelect1.SelectedId(shipId);
            ucShipSelect1.Enabled = false;
        }
        #endregion

        #region 当前行关键值
        public string PURCHASE_APPLYID = "";
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
        private void FrmMaterialPurchaseApplySelect_Load(object sender, EventArgs e)
        {
            ucDepartmentSelect1.ChangeMode(3);
            this.setComboBox();     //设置窗体所需的下拉列表框的数据源.
            this.setBindingSource();//设置数据源.
            this.setDataGridView(); //设置网格控件dgvApply的隐藏列与标头的设置.
            ucShipSelect1.ChangeSelectedState(false, true);

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
            {
                state = MaterialPurchaseApplyService.Instance.GetBusinessStateByViewerState(cboChkState.SelectedValue.ToString());
            }
            string department = ucDepartmentSelect1.GetId() == "0" ? null : ucDepartmentSelect1.GetId();//部门.
            DataTable dtbApply;
            string err;
            if (!MaterialPurchaseApplyService.Instance.GetInfo(null, shipId, department, onlyPostID, state, CommonOperation.ConstParameter.MinDateTime, CommonOperation.ConstParameter.MaxDateTime, out dtbApply, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");
            sb.Append(" and (ISCOMPLETE=1 or ( ISCOMPLETE=0 and PURCHASE_APPLY_PERSON='" + CommonOperation.ConstParameter.UserName + "'))");
            if (cboChkState.SelectedValue != null && cboChkState.SelectedValue.ToString() == "1")
            {
                sb.Append(" and ( 1<>1  ");
                if (CommonOperation.ConstParameter.IsLandVersion)
                {
                    if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
                        sb.AppendLine(" or STATE =3");
                    else if ("机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
                        sb.AppendLine(" or STATE =4 or STATE =3");
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
            if (string.IsNullOrEmpty(ucShipSelect1.GetId()))
            {
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
            DataTable newdt = new DataTable();
            newdt = dtbApply.Clone();
            foreach (DataRow item in dtbApply.Select(sb.ToString()))
                newdt.Rows.Add(item.ItemArray);
            dgvDetail.DataSource = null;
            txtShip.Text = "";
            txtPURCHASE_APPLY_CODE.Text = "";
            txtPURCHASE_APPLY_PERSON.Text = "";
            txtHEADSHIP_NAME.Text = "";
            txtPURCHASE_APPLY_DATE.Text = "";
            txtDEPARTNAME.Text = "";
            txtSHIP_LEADER_CHECKER.Text = "";
            txtSHIP_BOSS_CHECKER.Text = "";
            txtSHIP_BOSS_CHECKDATE.Text = "";
            txtLANDCHECKER.Text = "";
            txtCHECKDATE.Text = "";
            txtREMARK.Text = "";
            dgvApply.DataSource = newdt;
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
            dgvApply.SetDgvGridColumns(dgvColumnStyle);
            dgvApply.LoadGridView("FrmMaterialPurchaseApplySelect.dgvApply");
        }
        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {
            #region 2014年5月19日 徐正本增加的新代码 修改为 船端岸端均为相同的五个状态（全部，待我处理，审批中，订购中，流程结束）
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
            row4["State"] = "流程结束";//-1,7,9
            dtbChkState.Rows.Add(row4);

            cboChkState.DataSource = dtbChkState;
            cboChkState.SelectedIndex = 1;
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
            if (dgvApply.DataSource == null || dgvApply.Rows.Count == 0) return;
            if (dgvApply.Rows[rowNumber].Cells["PURCHASE_APPLYID"].Value == null) return;
            PURCHASE_APPLYID = dgvApply.Rows[rowNumber].Cells["PURCHASE_APPLYID"].Value.ToString();
            STATE = dgvApply.Rows[rowNumber].Cells["STATE"].Value.ToString();
            DEPART_ID = dgvApply.Rows[rowNumber].Cells["DEPART_ID"].Value.ToString();
            PURCHASE_APPLY_PERSON = dgvApply.Rows[rowNumber].Cells["PURCHASE_APPLY_PERSON"].Value.ToString();
            ISCOMPLETE = dgvApply.Rows[rowNumber].Cells["ISCOMPLETE"].Value.ToString();
            ShowDataToForm();
        }
        /// <summary>
        /// 选择并关闭.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            string err;
            DataTable dtDetail;
            if (!MaterialPurchaseApplyDetailService.Instance.GetInfo(PURCHASE_APPLYID, out dtDetail, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            MaterialPurchaseApply spa = MaterialPurchaseApplyService.Instance.getObject(PURCHASE_APPLYID, out err);
            foreach (DataRow spareitem in dtDetail.Rows)
            {
                StorageParameter sp = new StorageParameter();
                sp.ItemId = spareitem["MATERIAL_ID"].ToString();
                sp.Count = spa.STATE != 6 ? Convert.ToDecimal(spareitem["APPLYCOUNT"]) : Convert.ToDecimal(spareitem["CONFIRMEDCOUNT"]);
                spareids.Add(sp);
            }
            this.Close();
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
            dic.Add("COUNTINSHIP", "船存数量");
            dic.Add("APPLYCOUNT", "申请数量");
            if (CommonOperation.ConstParameter.IsLandVersion || (!CommonOperation.ConstParameter.IsLandVersion && STATE == "6"))
                dic.Add("CONFIRMEDCOUNT", "批准数量");
            dic.Add("REMARK", "备注");
            dgvDetail.SetDgvGridColumns(dic);

            foreach (DataGridViewColumn item in dgvDetail.Columns)
                item.ReadOnly = true;
        }
        /// <summary>
        /// 释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMaterialPurchaseApplySelect_FormClosing(object sender, FormClosingEventArgs e)
        {
            //清除大文档绑定功能.
            // FileOperation.FileBoundingOperation.Instance.FileBoundCheck("", "", 0, "");
            dgvApply.SaveGridView("FrmMaterialPurchaseApplySelect.dgvApply");
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
    }
}
