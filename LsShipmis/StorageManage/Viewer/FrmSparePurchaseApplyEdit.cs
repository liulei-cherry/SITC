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

namespace StorageManage.Viewer
{
    public partial class FrmSparePurchaseApplyEdit : CommonViewer.BaseForm.FormBase
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmSparePurchaseApplyEdit instance = new FrmSparePurchaseApplyEdit();
        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmSparePurchaseApplyEdit Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmSparePurchaseApplyEdit.instance = new FrmSparePurchaseApplyEdit();
                }

                return FrmSparePurchaseApplyEdit.instance;
            }
        }
        private FrmSparePurchaseApplyEdit()
        {
            InitializeComponent();
        }
        #endregion
        private string PURCHASE_APPLYID = "";
        private DataTable PURCHASE_APPLYIDS = new DataTable();
        //private SparePurchaseApply spa = null;
        private DataRow drItem = null;
        private DataTable dtDetail = new DataTable();
        private Dictionary<DataRow, BindingSource> dicDetail = new Dictionary<DataRow, BindingSource>();
        private Dictionary<string, SparePurchaseApply> dicSPA = new Dictionary<string, SparePurchaseApply>();
        string STATE = "";
        string DEPART_ID = "";
        string PURCHASE_APPLY_PERSON = "";
        string ISCOMPLETE = "";
        bool ISLANDPOST = false;
        ComponentUnit componentUnit = null;
        List<StorageParameter> ids = null;
        string remark = "";
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();

        List<int> lstIndex = new List<int>();
        /// <summary>
        /// 构造.
        /// </summary>
        /// <param name="PURCHASE_APPLYID"></param>
        /// <param name="functionCode"></param>
        public FrmSparePurchaseApplyEdit(string applyID)
        {
            InitializeComponent();
            PURCHASE_APPLYID = applyID;
        }
        /// <summary>
        /// 多选构造. 2014.2.17 刘子建增加
        /// </summary>
        /// <param name="applyID"></param>
        public FrmSparePurchaseApplyEdit(DataTable dtPURCHASE)
        {
            InitializeComponent();
            PURCHASE_APPLYIDS = dtPURCHASE.Copy();
        }
        public FrmSparePurchaseApplyEdit(ComponentUnit paramComponentUnit, List<StorageParameter> paramids, string paramRemark)
        {
            InitializeComponent();
            componentUnit = paramComponentUnit;
            ids = paramids;
            remark = paramRemark;
        }
        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSparePurchaseApplyEdit_Load(object sender, EventArgs e)
        {
            string err;

            bool[] stateCheck = { true, true };
            dgvApply.SelectedChanged -= new CommonViewer.UcDataGridView.DeleSelectedChanged(dgvApply_SelectedChanged);

            ucShipSelect1.ChangeSelectedState(false, true);

            if (PURCHASE_APPLYIDS != null && PURCHASE_APPLYIDS.Rows.Count > 0)
            {
                PURCHASE_APPLYID = PURCHASE_APPLYIDS.Rows[0]["PURCHASE_APPLYID"].ToString();
                drItem = PURCHASE_APPLYIDS.Rows[0];

                foreach (DataRow dr in PURCHASE_APPLYIDS.Rows)
                {
                    BindingSource bsTMP = new BindingSource();
                    DataTable dtTMP = new DataTable();

                    if (!SparePurchaseApplyDetailService.Instance.GetInfo(dr["PURCHASE_APPLYID"].ToString(), out dtTMP, out err))
                    {
                        MessageBoxEx.Show(err);
                        return;
                    }

                    bsTMP.DataSource = dtTMP;
                    dicDetail.Add(dr, bsTMP);
                    dicSPA.Add(dr["PURCHASE_APPLYID"].ToString(), SparePurchaseApplyService.Instance.getObject(dr));
                }

            }
            else
            {
                //spa = new SparePurchaseApply();
                dicSPA.Add("", new SparePurchaseApply());

                BindingSource bsTMP = new BindingSource();
                DataTable dtTMP = new DataTable();

                if (!SparePurchaseApplyDetailService.Instance.GetInfo("", out dtTMP, out err))
                {
                    MessageBoxEx.Show(err);
                    return;
                }

                bsTMP.DataSource = dtTMP.Clone();
                PURCHASE_APPLYIDS = SparePurchaseApplyService.Instance.GetInfo(null, null, null, null, null).Copy().Clone();
                drItem = PURCHASE_APPLYIDS.NewRow();
                PURCHASE_APPLYIDS.Rows.Add(drItem);

                dicDetail.Add(drItem, bsTMP);

                drItem["PURCHASE_APPLY_CODE"] = "";
                drItem["SHIP_ID"] = ucShipSelect1.GetId();
                drItem["SHIP_NAME"] = ucShipSelect1.GetText();
                drItem["PURCHASE_APPLY_PERSON"] = CommonOperation.ConstParameter.UserName;
                drItem["PURCHASE_APPLY_DATE"] = DateTime.Now;
                drItem["HEADSHIP_NAME"] = CommonOperation.ConstParameter.LoginUserInfo.ShipHeadShipName;
                drItem["DEPARTNAME"] = CommonOperation.ConstParameter.LoginUserInfo.DepartmentName;
            }

            dgvApply.DataSource = PURCHASE_APPLYIDS;
            setDataGridView();
            ShowDataToForm();
            foreach (DataRow dr in PURCHASE_APPLYIDS.Rows)
            {
                STATE = dr["STATE"].ToString();
                DEPART_ID = dr["DEPART_ID"].ToString();
                PURCHASE_APPLY_PERSON = dr["PURCHASE_APPLY_PERSON"].ToString();
                ISCOMPLETE = dr["ISCOMPLETE"].ToString();
                ISLANDPOST = dr["ISLANDPOST"].ToString() == "1";

                if (stateCheck[0] || stateCheck[1])
                {
                    stateCheck = SetButtonsAndControls();
                }
                else
                {
                    break;
                }
            }

            //add
            btnPass.Visible = CommonOperation.ConstParameter.IsLandVersion ? (stateCheck[0] || stateCheck[1]) : false;

            btnDisagree.Visible = stateCheck[1];
            btnAgree.Visible = stateCheck[1];
            btnSubmit.Visible = stateCheck[0];
            btnSave.Visible = stateCheck[0] || stateCheck[1];
            btnDeleteDetail.Visible = stateCheck[0] || stateCheck[1];
            btnAddDetail.Visible = stateCheck[0] || stateCheck[1];
            dgvDetail.Enabled = stateCheck[0] || stateCheck[1];
            dgvDetail.Columns["APPLYCOUNT"].ReadOnly = !(stateCheck[0] || stateCheck[1]);
            dgvDetail.Columns["PARTNUMBER"].ReadOnly = !(stateCheck[0] || stateCheck[1]);
            dgvDetail.Columns["REMARK"].ReadOnly = !(stateCheck[0] || stateCheck[1]);
            dtpPURCHASE_APPLY_DATE.Enabled = stateCheck[0] || stateCheck[1];
            ucShipSelect1.Enabled = stateCheck[0];
            ucComponentSelect1.Enabled = stateCheck[0] || stateCheck[1];
            txtREMARK.Enabled = stateCheck[0] || stateCheck[1];

            foreach (DataGridViewColumn item in dgvDetail.Columns)
            {
                if (item.ReadOnly)
                    item.DefaultCellStyle.BackColor = Color.Linen;
            }


            if (componentUnit != null)
            {
                ucShipSelect1.SelectedId(componentUnit.SHIP_ID, false);
                ucComponentSelect1.SelectedId(componentUnit.COMPONENT_UNIT_ID);
                txtREMARK.Text = remark;
                InsertSparesToGridView(componentUnit, ids, 0, false);
            }
            ucShipSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(this.ucShipSelect1_TheSelectedChanged);
            dgvApply.SelectedChanged += new CommonViewer.UcDataGridView.DeleSelectedChanged(dgvApply_SelectedChanged);

        }
        /// <summary>
        ///  设置信息网格控件的隐藏列与显示标题.
        /// </summary>
        private void setDataGridView()
        {
            Dictionary<string, string> dgvColumnStyle = new Dictionary<string, string>();
            dgvColumnStyle.Add("SHIP_NAME", "船舶");
            dgvColumnStyle.Add("PURCHASE_APPLY_CODE", "处理单号");
            dgvColumnStyle.Add("COMP_FULL_NAME", "设备");
            dgvApply.SetDgvGridColumns(dgvColumnStyle);

            dgvApply.Columns["PURCHASE_APPLY_CODE"].Width = 85;
        }
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
        /// 设置空间可见权限.
        /// </summary>
        private bool[] SetButtonsAndControls()
        {
            bool[] Check = { true, true };

            bool isAddOrEdit = (PURCHASE_APPLY_PERSON == CommonOperation.ConstParameter.UserName && (STATE == "0" || STATE == "8")) || string.IsNullOrEmpty(PURCHASE_APPLYID);
            bool isExamine = false;

            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务主管.
                {
                    isAddOrEdit = isAddOrEdit || (PURCHASE_APPLY_PERSON == CommonOperation.ConstParameter.UserName && STATE == "3");
                    isExamine = STATE == "3" && PURCHASE_APPLY_PERSON != CommonOperation.ConstParameter.UserName;
                    //btnPass.Visible = isAddOrEdit || isExamine;
                    if (isExamine)
                    {
                        foreach (DataGridViewRow item in dgvDetail.Rows)
                        {
                            if (string.IsNullOrEmpty(item.Cells["CONFIRMEDCOUNT"].Value.ToString()))
                                item.Cells["CONFIRMEDCOUNT"].Value = item.Cells["APPLYCOUNT"].Value;
                        }
                    }
                    dgvDetail.Columns["CONFIRMEDCOUNT"].ReadOnly = !(isAddOrEdit || isExamine);
                }
                else if ("机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务经理.
                {
                    isAddOrEdit = isAddOrEdit || (PURCHASE_APPLY_PERSON == CommonOperation.ConstParameter.UserName && (STATE == "4" || STATE == "3"));
                    isExamine = (STATE == "4" || STATE == "3") && PURCHASE_APPLY_PERSON != CommonOperation.ConstParameter.UserName;
                    //btnPass.Visible = isAddOrEdit || isExamine;
                    dgvDetail.Columns["CONFIRMEDCOUNT"].ReadOnly = !(isAddOrEdit || isExamine);
                }
                else if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是船管总经理.
                {
                    isAddOrEdit = isAddOrEdit || (PURCHASE_APPLY_PERSON == CommonOperation.ConstParameter.UserName && STATE == "5");
                    isExamine = STATE == "5" && PURCHASE_APPLY_PERSON != CommonOperation.ConstParameter.UserName;
                    //btnPass.Visible = isAddOrEdit || isExamine;
                    dgvDetail.Columns["CONFIRMEDCOUNT"].ReadOnly = !(isAddOrEdit || isExamine);
                }
            }
            else
            {
                if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS) //假如是船长.
                {
                    isAddOrEdit = isAddOrEdit || (PURCHASE_APPLY_PERSON == CommonOperation.ConstParameter.UserName && STATE == "2");
                    isExamine = STATE == "2" && PURCHASE_APPLY_PERSON != CommonOperation.ConstParameter.UserName;
                }
                else if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER) //假如是部门长 并且是申请人部门的部门长.
                {
                    isAddOrEdit = isAddOrEdit || (PURCHASE_APPLY_PERSON == CommonOperation.ConstParameter.UserName && STATE == "1");
                    isExamine = STATE == "1" && IsSelfDepartmentHead(DEPART_ID) && PURCHASE_APPLY_PERSON != CommonOperation.ConstParameter.UserName;
                }
            }

            Check[0] = Check[0] ? isAddOrEdit : Check[0];
            Check[1] = Check[1] ? isExamine : Check[1];

            return Check;
        }
        /// <summary>
        /// 显示数据到控件上.
        /// </summary>
        private void ShowDataToForm()
        {
            dgvApply.SelectedChanged -= new CommonViewer.UcDataGridView.DeleSelectedChanged(dgvApply_SelectedChanged);

            if (string.IsNullOrEmpty(PURCHASE_APPLYID))
            {
                txtPURCHASE_APPLY_CODE.Text = SparePurchaseApplyService.Instance.GetPurchaseApplyCode(ucShipSelect1.GetId());
                drItem["PURCHASE_APPLY_CODE"] = txtPURCHASE_APPLY_CODE.Text;
                txtPURCHASE_APPLY_PERSON.Text = CommonOperation.ConstParameter.UserName;
                dtpPURCHASE_APPLY_DATE.Value = DateTime.Now;
                txtHEADSHIP_NAME.Text = CommonOperation.ConstParameter.LoginUserInfo.ShipHeadShipName;
                txtDEPARTNAME.Text = CommonOperation.ConstParameter.LoginUserInfo.DepartmentName;
                ucComponentSelect1.SelectedId("");
                ucComponentSelect1.ShipId = ucShipSelect1.GetId();
            }
            else
            {
                ucShipSelect1.SelectedId(drItem["SHIP_ID"].ToString(), false);
                ucComponentSelect1.SelectedId(drItem["COMPONENT_UNIT_ID"].ToString());
                txtPURCHASE_APPLY_CODE.Text = drItem["PURCHASE_APPLY_CODE"].ToString();
                txtPURCHASE_APPLY_PERSON.Text = drItem["PURCHASE_APPLY_PERSON"].ToString();
                txtHEADSHIP_NAME.Text = drItem["HEADSHIP_NAME"].ToString();
                dtpPURCHASE_APPLY_DATE.Value = Convert.ToDateTime(drItem["PURCHASE_APPLY_DATE"]);
                txtDEPARTNAME.Text = drItem["DEPARTNAME"].ToString();
                txtSHIP_LEADER_CHECKER.Text = drItem["SHIP_LEADER_CHECKER"].ToString();
                txtSHIP_BOSS_CHECKER.Text = drItem["SHIP_BOSS_CHECKER"].ToString();
                txtSHIP_LEADER_CHECKDATE.Text = drItem["SHIP_LEADER_CHECKDATE"].ToString();
                txtSHIP_BOSS_CHECKDATE.Text = drItem["SHIP_BOSS_CHECKDATE"].ToString();
                txtLANDCHECKER.Text = drItem["LANDCHECKER"].ToString();
                if (!string.IsNullOrEmpty(drItem["CHECKDATE"].ToString()))
                    dtpCHECKDATE.Value = Convert.ToDateTime(drItem["CHECKDATE"]);
                txtREMARK.Text = drItem["REMARK"].ToString();
            }

            //string err;

            dgvDetail.DataSource = dicDetail[drItem];

            //dicDetail[drItem].DataSource = dtDetail;
            //bindingSourceDetail.DataSource = dtDetail;

            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("SPARE_NAME", "备件");
            dic.Add("PARTNUMBER", "采购号或规格");
            dic.Add("UNIT_NAME", "单位");
            dic.Add("COUNTINSHIP", "船存数量");
            dic.Add("APPLYCOUNT", "申请数量");
            if (CommonOperation.ConstParameter.IsLandVersion || (!CommonOperation.ConstParameter.IsLandVersion && drItem["STATE"].ToString() == "6"))
                dic.Add("CONFIRMEDCOUNT", "批准数量");
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

            dgvApply.SelectedChanged += new CommonViewer.UcDataGridView.DeleSelectedChanged(dgvApply_SelectedChanged);
        }
        /// <summary>
        /// 从指定的位置往下连续加入几行备件申请信息.
        /// </summary>
        /// <param name="ComponentUnit"></param>
        /// <param name="spareids"></param>
        /// <param name="index">从第几行开始加入，如果从第一行加入，录入0，如果从最后一行加入，录入当前的总行数</param>
        /// <param name="replaceRow">是否要覆盖当前指定行，如果true，则index行会被覆盖掉</param>
        private void InsertSparesToGridView(ComponentUnit componentUnit, List<StorageParameter> spareids, int index, bool isFuGai)
        {
            if (componentUnit == null || string.IsNullOrEmpty(componentUnit.COMPONENT_UNIT_ID))
            {
                MessageBoxEx.Show("添加备件申请条目信息时，传入的参数设备无效！", "错误提示");
                return;
            }
            if (spareids.Count == 0)
            {
                MessageBoxEx.Show("添加备件申请条目信息时，传入的备件条目为0！", "错误提示");
                return;
            }
            List<SpareInfo> spareInfoList = new List<SpareInfo>();
            string err;
            int tempIndex = index;
            //DataTable dt = (DataTable)bindingSourceDetail.DataSource;
            DataTable dt = (DataTable)dicDetail[drItem].DataSource;
            foreach (StorageParameter spareTemp in spareids)
            {
                DataRow[] drs = dt.Select("SPARE_ID='" + spareTemp.ItemId + "'");
                SpareInfo spare = SpareInfoService.Instance.getObject(spareTemp.ItemId, out err);
                if (drs.Length > 0)
                {
                    spareInfoList.Add(spare);
                    continue;
                }
                if (isFuGai)
                {
                    dgvDetail.Rows[index].Cells["COMPONENT_UNIT_ID"].Value = componentUnit.COMPONENT_UNIT_ID;
                    dgvDetail.Rows[index].Cells["SPARE_ID"].Value = spare.SPARE_ID;
                    dgvDetail.Rows[index].Cells["SPARE_NAME"].Value = spare.SPARE_NAME;
                    dgvDetail.Rows[index].Cells["PARTNUMBER"].Value = spare.PARTNUMBER;
                    dgvDetail.Rows[index].Cells["UNIT_NAME"].Value = spare.UNIT_NAME;
                    dgvDetail.Rows[index].Cells["COUNTINSHIP"].Value = spareTemp.stocksall;
                    dgvDetail.Rows[index].Cells["APPLYCOUNT"].Value = 1;
                    isFuGai = false;
                    continue;
                }
                DataRow dr = dt.NewRow();
                dr["COMPONENT_UNIT_ID"] = componentUnit.COMPONENT_UNIT_ID;
                dr["SPARE_ID"] = spare.SPARE_ID;
                dr["SPARE_NAME"] = spare.SPARE_NAME;
                dr["PARTNUMBER"] = spare.PARTNUMBER;
                dr["UNIT_NAME"] = spare.UNIT_NAME;
                dr["COUNTINSHIP"] = spareTemp.stocksall;
                dr["APPLYCOUNT"] = 1;
                dt.Rows.InsertAt(dr, ++index);
            }
            dicDetail[drItem].DataSource = dt;
            if (spareInfoList.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("以下选择的备件在该申请单里已存在");
                sb.AppendLine("备件名称 // 规格");
                foreach (SpareInfo item in spareInfoList)
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
                if (string.IsNullOrEmpty(drItem["COMPONENT_UNIT_ID"].ToString()))
                {
                    MessageBoxEx.Show("请先选择设备", "提示");
                    return;
                }
                string err;
                ComponentUnit cu = ComponentUnitService.Instance.getObject(drItem["COMPONENT_UNIT_ID"].ToString(), out err);
                FrmSelectSpare frm = new FrmSelectSpare(cu);
                frm.ShowDialog();
                if (frm.Selected && frm.Spares.Count > 0)
                {
                    InsertSparesToGridView(cu, frm.Spares, dgvDetail.CurrentRow.Index, true);
                }
            }
        }
        /// <summary>
        /// form验证. 2014.2.18 刘子建修改
        /// </summary>
        /// <returns></returns>
        private bool CheckForm()
        {
            //提交编辑数据.
            foreach (BindingSource bsTMP in dicDetail.Values)
            {
                bsTMP.EndEdit();
            }

            foreach (DataRow dr in ((DataTable)dgvApply.DataSource).Rows)
            {
                int drNum = ((DataTable)dgvApply.DataSource).Rows.IndexOf(dr);

                if (string.IsNullOrEmpty(dr["DEPARTNAME"].ToString()))
                {
                    MessageBoxEx.Show("申请单[" + dr["PURCHASE_APPLY_CODE"] + "] :" + Environment.NewLine +
                        "申请人部门不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvApply.Rows[drNum].Selected = true;
                    dgvApply.CurrentCell = dgvApply.Rows[drNum].Cells["PURCHASE_APPLY_CODE"];
                    txtDEPARTNAME.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(dr["HEADSHIP_NAME"].ToString()))
                {
                    MessageBoxEx.Show("申请单[" + dr["PURCHASE_APPLY_CODE"] + "] :" + Environment.NewLine +
                        "申请人岗位不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvApply.Rows[drNum].Selected = true;
                    dgvApply.CurrentCell = dgvApply.Rows[drNum].Cells["PURCHASE_APPLY_CODE"];
                    txtHEADSHIP_NAME.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(dr["PURCHASE_APPLY_PERSON"].ToString()))
                {
                    MessageBoxEx.Show("申请单[" + dr["PURCHASE_APPLY_CODE"] + "] :" + Environment.NewLine +
                        "申请人不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvApply.Rows[drNum].Selected = true;
                    dgvApply.CurrentCell = dgvApply.Rows[drNum].Cells["PURCHASE_APPLY_CODE"];
                    txtPURCHASE_APPLY_PERSON.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(dr["PURCHASE_APPLY_DATE"].ToString()))
                {
                    MessageBoxEx.Show("申请单[" + dr["PURCHASE_APPLY_CODE"] + "] :" + Environment.NewLine +
                        "申请日期不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvApply.Rows[drNum].Selected = true;
                    dgvApply.CurrentCell = dgvApply.Rows[drNum].Cells["PURCHASE_APPLY_CODE"];
                    dtpPURCHASE_APPLY_DATE.Focus();
                    return false;
                }
                if (CommonOperation.ConstParameter.IsLandVersion && string.IsNullOrEmpty(dr["SHIP_ID"].ToString()))
                {
                    MessageBoxEx.Show("申请单[" + dr["PURCHASE_APPLY_CODE"] + "] :" + Environment.NewLine +
                        "船舶不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvApply.Rows[drNum].Selected = true;
                    dgvApply.CurrentCell = dgvApply.Rows[drNum].Cells["PURCHASE_APPLY_CODE"];
                    ucShipSelect1.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(dr["COMPONENT_UNIT_ID"].ToString()))
                {
                    MessageBoxEx.Show("申请单[" + dr["PURCHASE_APPLY_CODE"] + "] :" + Environment.NewLine +
                        "设备不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvApply.Rows[drNum].Selected = true;
                    dgvApply.CurrentCell = dgvApply.Rows[drNum].Cells["PURCHASE_APPLY_CODE"];
                    ucComponentSelect1.Focus();
                    return false;
                }
                if (((DataTable)dicDetail[dr].DataSource).Rows.Count == 0)
                {
                    MessageBoxEx.Show("申请单[" + dr["PURCHASE_APPLY_CODE"] + "] :" + Environment.NewLine +
                        "申请明细不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvApply.Rows[drNum].Selected = true;
                    dgvApply.CurrentCell = dgvApply.Rows[drNum].Cells["PURCHASE_APPLY_CODE"];
                    return false;
                }
                if (((DataTable)dicDetail[dr].DataSource).Select("SPARE_ID is null").Length > 0)
                {
                    MessageBoxEx.Show("申请单[" + dr["PURCHASE_APPLY_CODE"] + "] :" + Environment.NewLine +
                        "备件不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvApply.Rows[drNum].Selected = true;
                    dgvApply.CurrentCell = dgvApply.Rows[drNum].Cells["PURCHASE_APPLY_CODE"];
                    return false;
                }
                if (((DataTable)dicDetail[dr].DataSource).Select("APPLYCOUNT is null").Length > 0)
                {
                    MessageBoxEx.Show("申请单[" + dr["PURCHASE_APPLY_CODE"] + "] :" + Environment.NewLine +
                        "申请数量不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvApply.Rows[drNum].Selected = true;
                    dgvApply.CurrentCell = dgvApply.Rows[drNum].Cells["PURCHASE_APPLY_CODE"];
                    return false;
                }
                DataTable dt = (DataTable)dicDetail[dr].DataSource;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i].RowState == DataRowState.Deleted)
                        continue;
                    decimal decTMP;
                    if (!decimal.TryParse(dt.Rows[i]["APPLYCOUNT"].ToString(), out decTMP))
                    {
                        MessageBoxEx.Show("申请单[" + dr["PURCHASE_APPLY_CODE"] + "] :" + Environment.NewLine +
                        "申请数量不能为非数字信息", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgvApply.Rows[drNum].Selected = true;
                        dgvApply.CurrentCell = dgvApply.Rows[drNum].Cells["PURCHASE_APPLY_CODE"];
                        return false;
                    }
                }
                //if (!dgvDetail.IsNumeric("APPLYCOUNT"))
                //{
                //    MessageBoxEx.Show("申请单[" + dr["PURCHASE_APPLY_CODE"] + "] :" + Environment.NewLine +
                //        "申请数量不能为非数字信息", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    dgvApply.Rows[drNum].Selected = true;
                //    dgvApply.CurrentCell = dgvApply.Rows[drNum].Cells["PURCHASE_APPLY_CODE"];
                //    return false;
                //}
                if (CommonOperation.ConstParameter.IsLandVersion
                    &&
                    ((DataTable)dicDetail[dr].DataSource).Select("CONFIRMEDCOUNT is null").Length > 0)
                {
                    if (MessageBoxEx.Show("申请单[" + dr["PURCHASE_APPLY_CODE"] + "] :" + Environment.NewLine +
                        "审批数量不能为空,是否自动用申请条目自动补齐?", "警告",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        dgvApply.Rows[drNum].Selected = true;
                        dgvApply.CurrentCell = dgvApply.Rows[drNum].Cells["PURCHASE_APPLY_CODE"];
                        return false;
                    }
                    DataTable dt2 = (DataTable)dicDetail[dr].DataSource;
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        if (dt2.Rows[i].RowState == DataRowState.Deleted)
                            continue;
                        if (string.IsNullOrEmpty(dt2.Rows[i]["CONFIRMEDCOUNT"].ToString()))
                            dt2.Rows[i]["CONFIRMEDCOUNT"] = dt2.Rows[i]["APPLYCOUNT"];
                    }
                }
                foreach (DataRow drTMP in ((DataTable)dicDetail[dr].DataSource).Rows)
                {
                    if (drTMP.RowState == DataRowState.Deleted)
                    {
                        continue;
                    }
                    int drNumTMP = ((DataTable)dicDetail[dr].DataSource).Rows.IndexOf(drTMP);

                    if (Convert.ToDecimal(drTMP["APPLYCOUNT"]) <= 0)
                    {
                        MessageBoxEx.Show("申请单[" + dr["PURCHASE_APPLY_CODE"] + "] :" + Environment.NewLine +
                            "第" + (drNumTMP + 1) + "行的申请数量不能小于或等于零", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgvApply.Rows[drNum].Selected = true;
                        dgvApply.CurrentCell = dgvApply.Rows[drNum].Cells["PURCHASE_APPLY_CODE"];
                        return false;
                    }
                    if (CommonOperation.ConstParameter.IsLandVersion)
                    {
                        if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)
                            || "机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)
                            || "总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
                        {
                            if (Convert.ToDecimal(drTMP["CONFIRMEDCOUNT"]) < 0)
                            {
                                MessageBoxEx.Show("申请单[" + dr["PURCHASE_APPLY_CODE"] + "] :" + Environment.NewLine +
                                    "第" + (drNumTMP + 1) + "行的批准数量不能小于0", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                dgvApply.Rows[drNum].Selected = true;
                                dgvApply.CurrentCell = dgvApply.Rows[drNum].Cells["PURCHASE_APPLY_CODE"];
                                return false;
                            }
                        }
                    }
                }
                //for (int i = 0; i < ((DataTable)dicDetail[dr].DataSource).Rows.Count; i++)
                //{
                //    DataGridViewRow item = dgvDetail.Rows[i];

                //    if (Convert.ToDecimal(item.Cells["APPLYCOUNT"].Value) <= 0)
                //    {
                //        MessageBoxEx.Show("申请单[" + dr["PURCHASE_APPLY_CODE"] + "] :" + Environment.NewLine +
                //            "第" + (i + 1) + "行的申请数量不能小于或等于零", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        dgvApply.Rows[drNum].Selected = true;
                //        dgvApply.CurrentCell = dgvApply.Rows[drNum].Cells["PURCHASE_APPLY_CODE"];
                //        return false;
                //    }
                //    if (CommonOperation.ConstParameter.IsLandVersion)
                //    {
                //        if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)
                //            || "机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)
                //            || "总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
                //        {
                //            if (Convert.ToDecimal(item.Cells["CONFIRMEDCOUNT"].Value) < 0)
                //            {
                //                MessageBoxEx.Show("申请单[" + dr["PURCHASE_APPLY_CODE"] + "] :" + Environment.NewLine +
                //                    "第" + (i + 1) + "行的批准数量不能小于0", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //                dgvApply.Rows[drNum].Selected = true;
                //                dgvApply.CurrentCell = dgvApply.Rows[drNum].Cells["PURCHASE_APPLY_CODE"];
                //                return false;
                //            }
                //        }
                //    }
                //}
            }
            lstIndex = new List<int>();
            return true;
        }
        /// <summary>
        /// 从表单取得数据,并校验.
        /// </summary>
        /// <returns></returns>
        private bool UpdateObjectFrom()
        {
            if (!CheckForm()) return false;
            foreach (DataRow dr in ((DataTable)dgvApply.DataSource).Rows)
            {
                dicSPA[dr["PURCHASE_APPLYID"].ToString()].SHIP_ID = dr["SHIP_ID"].ToString();
                dicSPA[dr["PURCHASE_APPLYID"].ToString()].COMPONENT_UNIT_ID = dr["COMPONENT_UNIT_ID"].ToString();
                dicSPA[dr["PURCHASE_APPLYID"].ToString()].PURCHASE_APPLY_CODE = dr["PURCHASE_APPLY_CODE"].ToString();
                dicSPA[dr["PURCHASE_APPLYID"].ToString()].PURCHASE_APPLY_PERSON = dr["PURCHASE_APPLY_PERSON"].ToString();

                DateTime dateTMP = new DateTime();
                DateTime.TryParse(dr["PURCHASE_APPLY_DATE"].ToString(), out dateTMP);
                dicSPA[dr["PURCHASE_APPLYID"].ToString()].PURCHASE_APPLY_DATE = dateTMP;

                if (string.IsNullOrEmpty(dr["PURCHASE_APPLYID"].ToString()))
                    dicSPA[dr["PURCHASE_APPLYID"].ToString()].DEPART_ID = CommonOperation.ConstParameter.LoginUserInfo.DepartmentId;
                if (string.IsNullOrEmpty(dr["PURCHASE_APPLYID"].ToString()))
                    dicSPA[dr["PURCHASE_APPLYID"].ToString()].PURCHASE_APPLY_PERSON_POSTID = CommonOperation.ConstParameter.LoginUserInfo.PostId;

                dicSPA[dr["PURCHASE_APPLYID"].ToString()].REMARK = dr["REMARK"].ToString();
            }
            return true;
        }
        /// <summary>
        /// 保存函数. 2014.2.18 刘子建修改.
        /// </summary>
        /// <returns></returns>
        private bool SaveFunction()
        {
            string err;

            List<string> listSQL = new List<string>();

            foreach (string strID in dicSPA.Keys)
            {
                if (string.IsNullOrEmpty(dicSPA[strID].PURCHASE_APPLY_CODE))
                    dicSPA[strID].PURCHASE_APPLY_CODE = SparePurchaseApplyService.Instance.GetPurchaseApplyCode(ucShipSelect1.GetId());

                //取得SPA的执行语句.
                listSQL.Add(dicSPA[strID].GetUpdateSQL());

                DataRow dr;

                if (string.IsNullOrEmpty(strID))
                {
                    dr = PURCHASE_APPLYIDS.Rows[0];
                }
                else
                {
                    dr = PURCHASE_APPLYIDS.Select("PURCHASE_APPLYID = '" + strID + "'")[0];
                }

                dicDetail[dr].EndEdit();

                foreach (DataRow item in ((DataTable)dicDetail[dr].DataSource).Rows)
                {
                    if (item.RowState == DataRowState.Added)
                    {
                        if (string.IsNullOrEmpty(item["PURCHASE_APPLYID"].ToString()))
                            item["PURCHASE_APPLYID"] = dicSPA[strID].PURCHASE_APPLYID;
                        if (string.IsNullOrEmpty(item["PURCHASE_APPLY_DETAIL_ID"].ToString()))
                            item["PURCHASE_APPLY_DETAIL_ID"] = Guid.NewGuid().ToString();
                        item.EndEdit();
                    }
                }

                //取得Detail的执行语句.
                listSQL.AddRange(dbOperation.SaveFormData(((DataTable)dicDetail[dr].DataSource), "T_SPARE_PURCHASE_APPLY_DETAIL", 0));
            }

            if (!SpareInfoService.Instance.SubmitSql(listSQL, out err))
            {
                MessageBoxEx.Show("错误信息:" + Environment.NewLine + err, "提示");
                return false;
            }
            else
            {
                MessageBoxEx.Show("保存成功", "提示");
            }

            foreach (string strID in dicSPA.Keys)
            {
                if (dicSPA[strID].STATE == 6)
                    RemindService.Instance.CreateRemindOnce(2, dicSPA[strID].SHIP_ID, dicSPA[strID].PURCHASE_APPLYID);
            }
            return true;
        }

        /// <summary>
        /// 日期控件事件. 2014.2.19 刘子建添加.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpPURCHASE_APPLY_DATE__ValueChanged(object sender, EventArgs e)
        {
            drItem["PURCHASE_APPLY_DATE"] = dtpPURCHASE_APPLY_DATE.Value;
        }
        /// <summary>
        /// 船舶控件事件. 2014.2.18 刘子建修改.
        /// </summary>
        /// <param name="theSelectedObject"></param>
        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            if (dgvDetail.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(PURCHASE_APPLYID))
                {
                    string err;
                    if (!SparePurchaseApplyDetailService.Instance.DeleteByPurchaseApplyID(PURCHASE_APPLYID, out err))
                    {
                        MessageBoxEx.Show(err);
                        return;
                    }
                }

                ((DataTable)dicDetail[drItem].DataSource).Rows.Clear();
            }
            if (!string.IsNullOrEmpty(drItem["COMPONENT_UNIT_ID"].ToString()))
            {
                ucComponentSelect1.SelectedId("");
            }
            ucComponentSelect1.ChangeShip("", theSelectedObject);

            drItem["SHIP_ID"] = ucShipSelect1.GetId();
            drItem["SHIP_NAME"] = ucShipSelect1.GetText();
            drItem["PURCHASE_APPLY_CODE"] = SparePurchaseApplyService.Instance.GetPurchaseApplyCode(ucShipSelect1.GetId());
        }


        private void ucComponentSelect1_TheSelectedChanged(string theSelectedObject)
        {
            drItem["COMPONENT_UNIT_ID"] = theSelectedObject;
        }

        /// <summary>
        /// 备注修改事件 2014.2.19 刘子建增加.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtREMARK_TextChanged(object sender, EventArgs e)
        {
            drItem["REMARK"] = txtREMARK.Text;
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
                this.Close();
        }
        /// <summary>
        /// 完成. 2014.2.18 刘子建修改.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            foreach (DataRow dr in ((DataTable)dgvApply.DataSource).Rows)
            {
                int drNum = ((DataTable)dgvApply.DataSource).Rows.IndexOf(dr);

                if (dr["REMARK"].ToString().Contains("不同意"))
                {
                    MessageBoxEx.Show("备注内容不能包含'不同意'", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvApply.Rows[drNum].Selected = true;
                    dgvApply.CurrentCell = dgvApply.Rows[drNum].Cells["PURCHASE_APPLY_CODE"];
                    txtREMARK.Focus();
                    return;
                }
            }
            if (!UpdateObjectFrom())
                return;

            if (MessageBoxEx.Show("是否提交上级审批？", "提示信息", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.No) return;

            foreach (string strID in dicSPA.Keys)
            {
                dicSPA[strID].SHIP_LEADER_CHECKER = "";
                dicSPA[strID].SHIP_LEADER_CHECKDATE = DateTime.MinValue;
                dicSPA[strID].SHIP_BOSS_CHECKER = "";
                dicSPA[strID].SHIP_BOSS_CHECKDATE = DateTime.MinValue;
                dicSPA[strID].LANDCHECKER = "";
                dicSPA[strID].CHECKDATE = DateTime.MinValue;
                if (CommonOperation.ConstParameter.IsLandVersion)//是岸端.
                {
                    if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务主管.
                    {
                        dicSPA[strID].STATE = 4;
                        dicSPA[strID].LANDCHECKER = CommonOperation.ConstParameter.UserName;
                        dicSPA[strID].CHECKDATE = DateTime.Now;
                    }
                    else if ("机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务经理.
                    {
                        dicSPA[strID].STATE = 5;
                        dicSPA[strID].LANDCHECKER = CommonOperation.ConstParameter.UserName;
                        dicSPA[strID].CHECKDATE = DateTime.Now;
                    }
                    else if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是船管总经理.
                    {
                        dicSPA[strID].STATE = 6;
                        dicSPA[strID].LANDCHECKER = CommonOperation.ConstParameter.UserName;
                        dicSPA[strID].CHECKDATE = DateTime.Now;
                    }
                    else
                    {
                        dicSPA[strID].STATE = 3;
                    }
                }
                else//是船端.
                {
                    if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS)//是船长.
                    {
                        dicSPA[strID].STATE = 3;
                        dicSPA[strID].SHIP_BOSS_CHECKER = CommonOperation.ConstParameter.UserName;
                        dicSPA[strID].SHIP_BOSS_CHECKDATE = DateTime.Now;
                    }
                    else if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER)//是部门长.
                    {
                        dicSPA[strID].STATE = 2;
                        dicSPA[strID].SHIP_LEADER_CHECKER = CommonOperation.ConstParameter.UserName;
                        dicSPA[strID].SHIP_LEADER_CHECKDATE = DateTime.Now;
                    }
                    else
                    {
                        dicSPA[strID].STATE = 1;
                    }
                }
                dicSPA[strID].ISCOMPLETE = 1;
            }

            if (SaveFunction())
                this.Close();
        }
        /// <summary>
        /// 不提交上级直接通过. 2014.2.18 刘子建修改.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPass_Click(object sender, EventArgs e)
        {
            foreach (DataRow dr in ((DataTable)dgvApply.DataSource).Rows)
            {
                int drNum = ((DataTable)dgvApply.DataSource).Rows.IndexOf(dr);

                if (dr["REMARK"].ToString().Contains("不同意"))
                {
                    MessageBoxEx.Show("备注内容不能包含'不同意'", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvApply.Rows[drNum].Selected = true;
                    dgvApply.CurrentCell = dgvApply.Rows[drNum].Cells["PURCHASE_APPLY_CODE"];
                    txtREMARK.Focus();
                    return;
                }
            }
            if (!UpdateObjectFrom())
                return;

            if (MessageBoxEx.Show("是否直接订购？", "提示信息", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.No) return;

            foreach (string strID in dicSPA.Keys)
            {
                dicSPA[strID].STATE = 6;
                dicSPA[strID].LANDCHECKER = CommonOperation.ConstParameter.UserName;
                dicSPA[strID].CHECKDATE = DateTime.Now;
                dicSPA[strID].ISCOMPLETE = 1;
            }

            if (SaveFunction())
                this.Close();
        }
        /// <summary>
        /// 同意按钮事件. 2014.2.18 刘子建修改.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgree_Click(object sender, EventArgs e)
        {
            foreach (DataRow dr in ((DataTable)dgvApply.DataSource).Rows)
            {
                int drNum = ((DataTable)dgvApply.DataSource).Rows.IndexOf(dr);

                if (dr["REMARK"].ToString().Contains("不同意"))
                {
                    MessageBoxEx.Show("备注内容不能包含'不同意'", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvApply.Rows[drNum].Selected = true;
                    dgvApply.CurrentCell = dgvApply.Rows[drNum].Cells["PURCHASE_APPLY_CODE"];
                    txtREMARK.Focus();
                    return;
                }
            }
            if (!UpdateObjectFrom())
                return;

            if (MessageBoxEx.Show("是否同意本次申请？", "提示信息", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.No) return;

            foreach (string strID in dicSPA.Keys)
            {
                if (CommonOperation.ConstParameter.IsLandVersion)//是岸端.
                {
                    if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务主管.
                        dicSPA[strID].STATE = 4;
                    else if ("机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务经理.
                        dicSPA[strID].STATE = 5;
                    else if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是船管总经理.
                        dicSPA[strID].STATE = 6;
                    dicSPA[strID].LANDCHECKER = CommonOperation.ConstParameter.UserName;
                    dicSPA[strID].CHECKDATE = DateTime.Now;
                }
                else//是船端.
                {
                    if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS)//是船长.
                    {
                        dicSPA[strID].STATE = 3;
                        dicSPA[strID].SHIP_BOSS_CHECKER = CommonOperation.ConstParameter.UserName;
                        dicSPA[strID].SHIP_BOSS_CHECKDATE = DateTime.Now;
                    }
                    else if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER)//是部门长.
                    {
                        dicSPA[strID].STATE = 2;
                        dicSPA[strID].SHIP_LEADER_CHECKER = CommonOperation.ConstParameter.UserName;
                        dicSPA[strID].SHIP_LEADER_CHECKDATE = DateTime.Now;

                        dicSPA[strID].SHIP_BOSS_CHECKER = "";
                        dicSPA[strID].SHIP_BOSS_CHECKDATE = DateTime.MinValue;
                    }
                    dicSPA[strID].LANDCHECKER = "";
                    dicSPA[strID].CHECKDATE = DateTime.MinValue;
                }
                dicSPA[strID].ISCOMPLETE = 1;
            }
            if (SaveFunction())
                this.Close();
        }
        /// <summary>
        /// 不同意按钮事件. 2014.2.18 刘子建修改.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisagree_Click(object sender, EventArgs e)
        {
            if (!UpdateObjectFrom())
                return;
            if (MessageBoxEx.Show("是否不同意本次申请？", "提示信息", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.No) return;
            foreach (string strID in dicSPA.Keys)
            {
                string err;
                if (CommonOperation.ConstParameter.IsLandVersion)//是岸端.
                {
                    if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务主管.
                    {
                        DataTable dt = BaseInfo.DataAccess.PostService.Instance.getInfoByType("船长岗位", out err);
                        if (dicSPA[strID].PURCHASE_APPLY_PERSON_POSTID == dt.Rows[0][0].ToString())
                            dicSPA[strID].STATE = 8;
                        else
                            dicSPA[strID].STATE = 2;
                        dicSPA[strID].REMARK += "\r\n机务主管不同意";
                    }
                    else if ("机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务经理.
                    {
                        DataTable dt = BaseInfo.DataAccess.PostService.Instance.getInfoByType("机务主管岗位", out err);
                        if (dicSPA[strID].PURCHASE_APPLY_PERSON_POSTID == dt.Rows[0][0].ToString())
                            dicSPA[strID].STATE = 8;
                        else
                            dicSPA[strID].STATE = 3;
                        dicSPA[strID].REMARK += "\r\n机务经理不同意";
                    }
                    else if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是船管总经理.
                    {
                        DataTable dt = BaseInfo.DataAccess.PostService.Instance.getInfoByType("机务经理岗位", out err);
                        if (dicSPA[strID].PURCHASE_APPLY_PERSON_POSTID == dt.Rows[0][0].ToString())
                            dicSPA[strID].STATE = 8;
                        else
                            dicSPA[strID].STATE = 4;
                        dicSPA[strID].REMARK += "\r\n船管总经理不同意";
                    }
                    dicSPA[strID].LANDCHECKER = CommonOperation.ConstParameter.UserName;
                    dicSPA[strID].CHECKDATE = DateTime.Now;
                }
                else//是船端.
                {
                    if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS)//是船长.
                    {
                        if (BaseInfo.DataAccess.PostService.Instance.getObject(dicSPA[strID].PURCHASE_APPLY_PERSON_POSTID, out err).ISHEADER == 1)
                            dicSPA[strID].STATE = 8;
                        else
                            dicSPA[strID].STATE = 1;
                        dicSPA[strID].REMARK += "\r\n船长不同意";
                        dicSPA[strID].SHIP_BOSS_CHECKER = CommonOperation.ConstParameter.UserName;
                        dicSPA[strID].SHIP_BOSS_CHECKDATE = DateTime.Now;
                    }
                    else if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER)//是部门长.
                    {
                        dicSPA[strID].STATE = 0;
                        dicSPA[strID].REMARK += "\r\n部门长不同意";
                        dicSPA[strID].SHIP_LEADER_CHECKER = CommonOperation.ConstParameter.UserName;
                        dicSPA[strID].SHIP_LEADER_CHECKDATE = DateTime.Now;
                    }
                }
            }
            //spa.STATE = 8;
            //spa.SHIP_BOSS_CHECKER = "";
            //spa.SHIP_BOSS_CHECKDATE = DateTime.MinValue;
            //spa.SHIP_LEADER_CHECKER = "";
            //spa.SHIP_LEADER_CHECKDATE = DateTime.MinValue;
            //spa.LANDCHECKER = "";
            if (SaveFunction())
                this.Close();
        }
        /// <summary>
        /// 添加明细.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(drItem["SHIP_ID"].ToString()))
            {
                MessageBoxEx.Show("请先选择船舶", "提示");
                return;
            }
            if (string.IsNullOrEmpty(drItem["COMPONENT_UNIT_ID"].ToString()))
            {
                MessageBoxEx.Show("请先选择设备", "提示");
                return;
            }
            if (!dgvDetail.HasEmptyVal("SPARE_NAME"))
            {
                dicDetail[drItem].AddNew();
            }
        }


        #region wanhw-2014-10-25-获取数据源中真正被删除的索引.
        /// <summary>
        /// 获取数据源中真正被删除的索引.
        /// </summary>
        /// <param name="allIndexLength">数据源的长度.</param>
        /// <param name="gridViewIndex">gridView中下一个被删除的索引.</param>
        /// <param name="listIndex">已经被删除的索引集合.</param>
        /// <returns>获取数据源中真正被删除的索引.</returns>
        private int GetDeleteIndex(int allIndexLength, int gridViewIndex, List<int> listIndex)
        {
            int quantity = -1;
            for (int i = 0; i < allIndexLength; i++)
            {
                if (!listIndex.Contains(i))
                {
                    quantity++;
                }
                if (quantity == gridViewIndex)
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion



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
            DataTable dt = (DataTable)dicDetail[drItem].DataSource;
            int position = dicDetail[drItem].Position;
            int deletePosition = GetDeleteIndex(dt.Rows.Count, position, lstIndex);
            if (-1 != deletePosition)
            {
                dt.Rows[deletePosition].Delete();
                lstIndex.Add(deletePosition);
            }
            //(dicDetail[drItem].DataSource as DataTable).Rows[dicDetail[drItem].Position].Delete(); 
            //wanhw-2014-10-24-删除修复bug--->此时若提交的话，会破坏表结构。
            //(dicDetail[drItem].DataSource as DataTable).AcceptChanges();
            //bindingSourceDetail.RemoveCurrent();
        }
        /// <summary>
        /// 关闭时.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSparePurchaseApplyEdit_FormClosing(object sender, FormClosingEventArgs e)
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

        private void dgvApply_SelectedChanged(int rowNumber)
        {
            PURCHASE_APPLYID = dgvApply.Rows[rowNumber].Cells["PURCHASE_APPLYID"].Value.ToString();


            drItem = PURCHASE_APPLYIDS.Select("PURCHASE_APPLYID = '" + PURCHASE_APPLYID + "'").Length > 0 ?
                PURCHASE_APPLYIDS.Select("PURCHASE_APPLYID = '" + PURCHASE_APPLYID + "'")[0] : drItem;

            ShowDataToForm();

            STATE = drItem["STATE"].ToString();
            DEPART_ID = drItem["DEPART_ID"].ToString();
            PURCHASE_APPLY_PERSON = drItem["PURCHASE_APPLY_PERSON"].ToString();
            ISCOMPLETE = drItem["ISCOMPLETE"].ToString();
            ISLANDPOST = drItem["ISLANDPOST"].ToString() == "1";
            bool[] stateCheck = SetButtonsAndControls();

            btnPass.Visible = CommonOperation.ConstParameter.IsLandVersion ? (stateCheck[0] || stateCheck[1]) : false;

            btnDisagree.Visible = stateCheck[1];
            btnAgree.Visible = stateCheck[1];
            btnSubmit.Visible = stateCheck[0];
            btnSave.Visible = stateCheck[0] || stateCheck[1];
            btnDeleteDetail.Visible = stateCheck[0] || stateCheck[1];
            btnAddDetail.Visible = stateCheck[0] || stateCheck[1];
            dgvDetail.Enabled = stateCheck[0] || stateCheck[1];
            dgvDetail.Columns["APPLYCOUNT"].ReadOnly = !(stateCheck[0] || stateCheck[1]);
            dgvDetail.Columns["PARTNUMBER"].ReadOnly = !(stateCheck[0] || stateCheck[1]);
            dgvDetail.Columns["REMARK"].ReadOnly = !(stateCheck[0] || stateCheck[1]);
            dtpPURCHASE_APPLY_DATE.Enabled = stateCheck[0] || stateCheck[1];
            ucShipSelect1.Enabled = stateCheck[0];
            ucComponentSelect1.Enabled = stateCheck[0] || stateCheck[1];

            txtREMARK.Enabled = stateCheck[0] || stateCheck[1];

            foreach (DataGridViewColumn item in dgvDetail.Columns)
            {
                if (item.ReadOnly)
                    item.DefaultCellStyle.BackColor = Color.Linen;
            }
        }
    }
}
