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
using CommonOperation.Enum;

namespace StorageManage.Viewer
{
    public partial class FrmMaterialPurchaseApplyEdit : CommonViewer.BaseForm.FormBase
    {
        #region 窗体变量
        private String errMessage = String.Empty;
        /// <summary>
        /// 物料申请ID
        /// </summary>
        private string PURCHASE_APPLYID = "";
        private bool isPassive = false;
        /// <summary>
        /// 物料申请主表信息
        /// </summary>
        private DataTable dtMaterialApplyTable = new DataTable();
        private MaterialPurchaseApply spa = null;
        private DataRow drItem = null;
        private DataTable dtDetail = new DataTable();
        private Dictionary<DataRow, BindingSource> dicDetail = new Dictionary<DataRow, BindingSource>();
        private Dictionary<string, MaterialPurchaseApply> dicSPA = new Dictionary<string, MaterialPurchaseApply>();
        string STATE = "";
        string DEPART_ID = "";
        string PURCHASE_APPLY_PERSON = "";
        string ISCOMPLETE = "";
        bool ISLANDPOST = false;
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();

        /// <summary>
        /// 合单使用的Ids列表
        /// </summary>
        List<String> IdList = new List<String>();

        /// <summary>
        /// 0正常逻辑1合单逻辑
        /// </summary>
        Int32 Action = 0;

        int deleteRow = -1;

        int deleteTime = 0;

        List<int> lstIndex = new List<int>();

        #endregion

        #region  构造函数



        public FrmMaterialPurchaseApplyEdit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 修改的构造.
        /// </summary>
        /// <param name="applyID">申请单ID</param>
        public FrmMaterialPurchaseApplyEdit(string applyID)
            : this()
        {
            List<String> applyIDList = new List<String>();
            applyIDList.Add(applyID);
            if (!MaterialPurchaseApplyService.Instance.GetInfo(applyIDList, null, null, null, null,
                CommonOperation.ConstParameter.MinDateTime, CommonOperation.ConstParameter.MaxDateTime, out dtMaterialApplyTable, out errMessage))
            {
                MessageBoxEx.Show(errMessage);
                return;
            }
        }
        /// <summary>
        /// 为合单准备的构造.
        /// </summary>     
        public FrmMaterialPurchaseApplyEdit(List<String> applyIDList, Int32 action)
            : this()
        {
            IdList = applyIDList;
            Action = action;
            if (!MaterialPurchaseApplyService.Instance.GetInfo(applyIDList, null, null, null, null,
                CommonOperation.ConstParameter.MinDateTime, CommonOperation.ConstParameter.MaxDateTime, out dtMaterialApplyTable, out errMessage))
            {
                MessageBoxEx.Show(errMessage);
                return;
            }


        }
        #endregion

        #region 窗体载入
        /// <summary>
        /// 窗体启动时执行的一些操作. 2014.2.21 刘子建修改
        /// </summary>     
        private void FrmMaterialPurchaseApplyEdit_Load(object sender, EventArgs e)
        {
            bool[] stateCheck = { true, true };
            if (Action == 0)
            {
                #region 原有物料申请逻辑

                string err;

                isPassive = true;
                dgvApply.SelectedChanged -= new CommonViewer.UcDataGridView.DeleSelectedChanged(dgvApply_SelectedChanged);
                ucShipSelect1.ChangeSelectedState(false, true);

                if (dtMaterialApplyTable != null && dtMaterialApplyTable.Rows.Count > 0)
                {
                    PURCHASE_APPLYID = dtMaterialApplyTable.Rows[0]["PURCHASE_APPLYID"].ToString();
                    drItem = dtMaterialApplyTable.Rows[0];
                    foreach (DataRow dr in dtMaterialApplyTable.Rows)
                    {
                        BindingSource bsTMP = new BindingSource();
                        DataTable dtTMP = new DataTable();
                        if (!MaterialPurchaseApplyDetailService.Instance.GetInfo(dr["PURCHASE_APPLYID"].ToString(), out dtTMP, out err))
                        {
                            MessageBoxEx.Show(err);
                            return;
                        }
                        bsTMP.DataSource = dtTMP;
                        dicDetail.Add(dr, bsTMP);
                        dicSPA.Add(dr["PURCHASE_APPLYID"].ToString(), MaterialPurchaseApplyService.Instance.getObject(dr));
                    }
                }
                else
                {
                    ///此逻辑应该为添加逻辑 修改的时候不应该进入到此业务 zhangy-2014-06-19
                    dicSPA.Add("", new MaterialPurchaseApply());

                    BindingSource bsTMP = new BindingSource();

                    DataTable dtApplyDetail = new DataTable();//物料申请明细

                    if (!MaterialPurchaseApplyDetailService.Instance.GetInfo("", out dtApplyDetail, out err))
                    {
                        MessageBoxEx.Show(err);
                        return;
                    }

                    bsTMP.DataSource = dtApplyDetail.Clone();

                    DataTable dtApply;//物料申请主表
                    if (!MaterialPurchaseApplyService.Instance.GetInfo
                        (null, null, null, null, null, CommonOperation.ConstParameter.MinDateTime, CommonOperation.ConstParameter.MaxDateTime, out dtApply, out err))
                    {
                        MessageBoxEx.Show(err);
                        return;
                    }

                    dtMaterialApplyTable = dtApply.Copy().Clone();

                    drItem = dtMaterialApplyTable.NewRow();

                    dtMaterialApplyTable.Rows.Add(drItem);

                    dicDetail.Add(drItem, bsTMP);

                    drItem["PURCHASE_APPLY_CODE"] = "";
                    drItem["SHIP_ID"] = ucShipSelect1.GetId();
                    drItem["SHIP_NAME"] = ucShipSelect1.GetText();
                    drItem["PURCHASE_APPLY_PERSON"] = CommonOperation.ConstParameter.UserName;
                    drItem["PURCHASE_APPLY_DATE"] = DateTime.Now;
                    drItem["HEADSHIP_NAME"] = CommonOperation.ConstParameter.LoginUserInfo.ShipHeadShipName;
                    drItem["DEPARTNAME"] = CommonOperation.ConstParameter.LoginUserInfo.DepartmentName;
                }

                dgvApply.DataSource = dtMaterialApplyTable;

                setDataGridView();

                ShowDataToForm();

                foreach (DataRow dr in dtMaterialApplyTable.Rows)
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

                btnPass.Visible = CommonOperation.ConstParameter.IsLandVersion ? (stateCheck[0] || stateCheck[1]) : false;

                btnDisagree.Visible = stateCheck[1];
                btnAgree.Visible = stateCheck[1];
                btnSubmit.Visible = stateCheck[0];
                btnSave.Visible = stateCheck[0] || stateCheck[1];
                btnDeleteDetail.Visible = stateCheck[0] || stateCheck[1];
                btnAddDetail.Visible = stateCheck[0] || stateCheck[1];
                dgvDetail.Enabled = stateCheck[0] || stateCheck[1];
                dgvDetail.Columns["APPLYCOUNT"].ReadOnly = !(stateCheck[0] || stateCheck[1]);
                dgvDetail.Columns["MATERIAL_CODE"].ReadOnly = !(stateCheck[0] || stateCheck[1]);
                dgvDetail.Columns["MATERIAL_SPEC"].ReadOnly = !(stateCheck[0] || stateCheck[1]);
                dgvDetail.Columns["REMARK"].ReadOnly = !(stateCheck[0] || stateCheck[1]);
                dgvDetail.Columns["ORDERNUM"].ReadOnly = false;
                dtpPURCHASE_APPLY_DATE.Enabled = stateCheck[0] || stateCheck[1];
                ucShipSelect1.Enabled = stateCheck[0];
                txtREMARK.Enabled = stateCheck[0] || stateCheck[1];

                foreach (DataGridViewColumn item in dgvDetail.Columns)
                {
                    if (item.ReadOnly)
                        item.DefaultCellStyle.BackColor = Color.Linen;
                }
                dgvApply.SelectedChanged += new CommonViewer.UcDataGridView.DeleSelectedChanged(dgvApply_SelectedChanged);
                isPassive = false;
                #endregion
            }
            else
            {
                #region  合单业务逻辑
                dicSPA.Add("", new MaterialPurchaseApply());
                spa = new MaterialPurchaseApply();
                txtPURCHASE_APPLY_CODE.Text = "";
                txtPURCHASE_APPLY_PERSON.Text = CommonOperation.ConstParameter.UserName;
                dtpPURCHASE_APPLY_DATE.Value = DateTime.Now;
                txtHEADSHIP_NAME.Text = CommonOperation.ConstParameter.LoginUserInfo.ShipHeadShipName;
                txtDEPARTNAME.Text = CommonOperation.ConstParameter.LoginUserInfo.DepartmentName;

                DataTable dtTemp = new DataTable();
                foreach (String applyId in IdList)
                {
                    String errMessage = String.Empty; ;
                    DataTable dtSource = null;
                    if (!MaterialPurchaseApplyDetailService.Instance.GetInfo(applyId, out dtSource, out errMessage))
                    {
                        MessageBoxEx.Show(errMessage);
                        return;
                    }
                    dtTemp.Merge(dtSource);

                }
                dtDetail = dtTemp.Clone();// 必须克隆表的结构否则dr.ItemArray会执行出错
                int rowCount = dtDetail.Rows.Count;

                foreach (DataRow dr in dtTemp.Rows)
                {

                    DataRow[] drs = dtDetail.Select("MATERIAL_ID='" + dr["MATERIAL_ID"] + "'");
                    if (drs.Length > 0)
                    {
                        Decimal applyCount = Decimal.Parse(dr["APPLYCOUNT"].ToString());//相同物料的数量
                        DataRow drTemp = drs[0];//仅此一行否则出错
                        drTemp["APPLYCOUNT"] = Decimal.Parse(drTemp["APPLYCOUNT"].ToString()) + applyCount;

                    }
                    else
                    {
                        DataRow drTemp = dtDetail.NewRow();
                        rowCount++;
                        dr["PURCHASE_APPLY_DETAIL_ID"] = "";
                        dr["PURCHASE_APPLYID"] = "";
                        dr["ORDERNUM"] = rowCount;
                        drTemp.ItemArray = dr.ItemArray;//复制数据部复制结构，指针指向发生改变
                        dtDetail.Rows.Add(drTemp);//加入新行就不会出现被属于其他表
                    }

                }

                bindingSourceDetail.DataSource = dtDetail;
                dgvDetail.DataSource = bindingSourceDetail;
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("ORDERNUM", "序号");
                dic.Add("MATERIAL_NAME", "物资");
                dic.Add("MATERIAL_CODE", "物资编号");
                dic.Add("MATERIAL_SPEC", "采购号或规格");
                dic.Add("UNIT_NAME", "单位");
                dic.Add("COUNTINSHIP", "船存数量");
                dic.Add("APPLYCOUNT", "申请数量");
                if (CommonOperation.ConstParameter.IsLandVersion || (!CommonOperation.ConstParameter.IsLandVersion && STATE == "6"))
                    dic.Add("CONFIRMEDCOUNT", "批准数量");
                dic.Add("REMARK", "备注");

                dgvDetail.SetDgvGridColumns(dic);

                //给dgvDetail加一个列按钮列用于打开弹出对话框选择物资信息.
                if (dgvDetail.Columns["selMaterial"] != null)//如果按钮列已经存在，则不能重复添加.

                    dgvDetail.Columns.Remove("selmaterial");
                DataGridViewButtonColumn dgvBtnCol = new DataGridViewButtonColumn();
                dgvBtnCol.Name = "selMaterial";
                dgvBtnCol.HeaderText = "";
                dgvBtnCol.UseColumnTextForButtonValue = true;
                dgvBtnCol.Text = "…";
                dgvBtnCol.Width = 25;
                dgvDetail.Columns.Insert(4, dgvBtnCol);
                foreach (DataGridViewColumn item in dgvDetail.Columns)
                    item.ReadOnly = true;

                String err = String.Empty;
                BindingSource bsTMP = new BindingSource();
                DataTable dtApplyDetail = new DataTable();//物料申请明细
                if (!MaterialPurchaseApplyDetailService.Instance.GetInfo("", out dtApplyDetail, out err))
                {
                    MessageBoxEx.Show(err);
                    return;
                }

                dgvApply.SelectedChanged -= new CommonViewer.UcDataGridView.DeleSelectedChanged(dgvApply_SelectedChanged);
                DataTable dtApply;//物料申请主表

                if (!MaterialPurchaseApplyService.Instance.GetInfo(null, null, null, null, null, CommonOperation.ConstParameter.MinDateTime, CommonOperation.ConstParameter.MaxDateTime, out dtApply, out err))
                {
                    MessageBoxEx.Show(err);
                    return;
                }
                bsTMP.DataSource = dtDetail;
                dtMaterialApplyTable = dtApply.Copy().Clone();
                drItem = dtMaterialApplyTable.NewRow();
                dtMaterialApplyTable.Rows.Add(drItem);
                dicDetail.Add(drItem, bsTMP);
                txtPURCHASE_APPLY_CODE.Text = MaterialPurchaseApplyService.Instance.GetPurchaseApplyCode(ucShipSelect1.GetId());
                txtPURCHASE_APPLY_PERSON.Text = CommonOperation.ConstParameter.UserName;
                dtpPURCHASE_APPLY_DATE.Value = DateTime.Now;
                txtHEADSHIP_NAME.Text = CommonOperation.ConstParameter.LoginUserInfo.ShipHeadShipName;
                txtDEPARTNAME.Text = CommonOperation.ConstParameter.LoginUserInfo.DepartmentName;

                drItem["PURCHASE_APPLY_CODE"] = txtPURCHASE_APPLY_CODE.Text;
                drItem["SHIP_ID"] = ucShipSelect1.GetId();
                drItem["SHIP_NAME"] = ucShipSelect1.GetText();
                drItem["PURCHASE_APPLY_PERSON"] = CommonOperation.ConstParameter.UserName;
                drItem["PURCHASE_APPLY_DATE"] = DateTime.Now;
                drItem["HEADSHIP_NAME"] = CommonOperation.ConstParameter.LoginUserInfo.ShipHeadShipName;
                drItem["DEPARTNAME"] = CommonOperation.ConstParameter.LoginUserInfo.DepartmentName;
                dgvApply.DataSource = dtMaterialApplyTable;
                setDataGridView();
                foreach (DataRow dr in dtMaterialApplyTable.Rows)
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
                btnPass.Visible = CommonOperation.ConstParameter.IsLandVersion ? (stateCheck[0] || stateCheck[1]) : false;
                btnDisagree.Visible = stateCheck[1];
                btnAgree.Visible = stateCheck[1];
                btnSubmit.Visible = stateCheck[0];
                btnSave.Visible = stateCheck[0] || stateCheck[1];
                btnDeleteDetail.Visible = stateCheck[0] || stateCheck[1];
                btnAddDetail.Visible = stateCheck[0] || stateCheck[1];
                dgvDetail.Enabled = stateCheck[0] || stateCheck[1];
                dgvDetail.Columns["APPLYCOUNT"].ReadOnly = !(stateCheck[0] || stateCheck[1]);
                dgvDetail.Columns["MATERIAL_CODE"].ReadOnly = !(stateCheck[0] || stateCheck[1]);
                dgvDetail.Columns["MATERIAL_SPEC"].ReadOnly = !(stateCheck[0] || stateCheck[1]);
                dgvDetail.Columns["REMARK"].ReadOnly = !(stateCheck[0] || stateCheck[1]);
                dgvDetail.Columns["ORDERNUM"].ReadOnly = false;
                dtpPURCHASE_APPLY_DATE.Enabled = stateCheck[0] || stateCheck[1];
                ucShipSelect1.Enabled = stateCheck[0];
                txtREMARK.Enabled = stateCheck[0] || stateCheck[1];
                foreach (DataGridViewColumn item in dgvDetail.Columns)
                {
                    if (item.ReadOnly)
                        item.DefaultCellStyle.BackColor = Color.Linen;
                }
                dgvApply.DataSource = dtMaterialApplyTable;
                #endregion
            }

        }
        #endregion

        /// <summary>
        ///  设置信息网格控件的隐藏列与显示标题. 2014.2.21 刘子建添加.
        /// </summary>
        private void setDataGridView()
        {
            Dictionary<string, string> dgvColumnStyle = new Dictionary<string, string>();
            dgvColumnStyle.Add("SHIP_NAME", "船舶");
            dgvColumnStyle.Add("PURCHASE_APPLY_CODE", "处理单号");
            dgvColumnStyle.Add("STATE_NAME", "状态");
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

        #region 设置控件可见权限
        /// <summary>
        /// 设置控件可见权限. 2014.2.21 刘子建修改.
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
                    dgvDetail.Columns["CONFIRMEDCOUNT"].ReadOnly = !(isAddOrEdit || isExamine);
                }
                else if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是船管总经理.
                {
                    isAddOrEdit = isAddOrEdit || (PURCHASE_APPLY_PERSON == CommonOperation.ConstParameter.UserName && STATE == "5");
                    isExamine = STATE == "5" && PURCHASE_APPLY_PERSON != CommonOperation.ConstParameter.UserName;
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
        #endregion

        #region 显示数据到控件上
        /// <summary>
        /// 显示数据到控件上.
        /// </summary>
        private void ShowDataToForm()
        {
            isPassive = true;
            dgvApply.SelectedChanged -= new CommonViewer.UcDataGridView.DeleSelectedChanged(dgvApply_SelectedChanged);

            if (string.IsNullOrEmpty(PURCHASE_APPLYID))
            {
                txtPURCHASE_APPLY_CODE.Text = MaterialPurchaseApplyService.Instance.GetPurchaseApplyCode(ucShipSelect1.GetId());
                drItem["PURCHASE_APPLY_CODE"] = txtPURCHASE_APPLY_CODE.Text;
                txtPURCHASE_APPLY_PERSON.Text = CommonOperation.ConstParameter.UserName;
                dtpPURCHASE_APPLY_DATE.Value = DateTime.Now;
                txtHEADSHIP_NAME.Text = CommonOperation.ConstParameter.LoginUserInfo.ShipHeadShipName;
                txtDEPARTNAME.Text = CommonOperation.ConstParameter.LoginUserInfo.DepartmentName;
            }
            else
            {
                ucShipSelect1.SelectedId(drItem["SHIP_ID"].ToString());
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

            dgvDetail.DataSource = dicDetail[drItem];

            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("ORDERNUM", "序号");
            dic.Add("MATERIAL_NAME", "物资");
            dic.Add("MATERIAL_CODE", "物资编号");
            dic.Add("MATERIAL_SPEC", "采购号或规格");
            dic.Add("UNIT_NAME", "单位");
            dic.Add("COUNTINSHIP", "船存数量");
            dic.Add("APPLYCOUNT", "申请数量");
            if (CommonOperation.ConstParameter.IsLandVersion || (!CommonOperation.ConstParameter.IsLandVersion && drItem["STATE"].ToString() == "6"))
                dic.Add("CONFIRMEDCOUNT", "批准数量");
            dic.Add("REMARK", "备注");
            dgvDetail.SetDgvGridColumns(dic);

            //给dgvDetail加一个列按钮列用于打开弹出对话框选择物资信息.
            if (dgvDetail.Columns["selMaterial"] != null)//如果按钮列已经存在，则不能重复添加.

                dgvDetail.Columns.Remove("selmaterial");
            DataGridViewButtonColumn dgvBtnCol = new DataGridViewButtonColumn();
            dgvBtnCol.Name = "selMaterial";
            dgvBtnCol.HeaderText = "";
            dgvBtnCol.UseColumnTextForButtonValue = true;
            dgvBtnCol.Text = "…";
            dgvBtnCol.Width = 25;
            dgvDetail.Columns.Insert(4, dgvBtnCol);

            foreach (DataGridViewColumn item in dgvDetail.Columns)
                item.ReadOnly = true;

            dgvApply.SelectedChanged += new CommonViewer.UcDataGridView.DeleSelectedChanged(dgvApply_SelectedChanged);
            isPassive = false;
        }
        #endregion

        #region 从指定的位置往下连续加入几行物资申请信息
        /// <summary>
        /// 从指定的位置往下连续加入几行物资申请信息.
        /// </summary>
        /// <param name="ComponentUnit"></param>
        /// <param name="materialids"></param>
        /// <param name="index">从第几行开始加入，如果从第一行加入，录入0，如果从最后一行加入，录入当前的总行数</param>
        /// <param name="replaceRow">是否要覆盖当前指定行，如果true，则index行会被覆盖掉</param>
        private void InsertMaterialsToGridView(List<StorageParameter> materialids, int index, bool isFuGai)
        {
            if (materialids.Count == 0)
            {
                MessageBoxEx.Show("添加物资申请条目信息时，传入的物资条目为0！", "错误提示");
                return;
            }
            List<MaterialInfo> materialInfoList = new List<MaterialInfo>();
            string err;

            DataTable dt = (DataTable)dicDetail[drItem].DataSource;
            int tempIndex = dt.Select(" MATERIAL_ID is not null").Length + 1;
            foreach (StorageParameter materialTemp in materialids)
            {
                DataRow[] drs = dt.Select("MATERIAL_ID='" + materialTemp.ItemId + "'");
                MaterialInfo material = MaterialInfoService.Instance.getObject(materialTemp.ItemId, out err);
                DataTable dtmaterial = MaterialInfoService.Instance.GetMaterialInfoAndStock(materialTemp.ItemId, ucShipSelect1.GetId());

                if (drs.Length > 0)
                {
                    materialInfoList.Add(material);
                    continue;
                }


                if (isFuGai)
                {
                    isFuGai = false;
                }
                else
                {
                    dicDetail[drItem].AddNew();//执行添加记录功能.
                }

                dgvDetail.CurrentRow.Cells["MATERIAL_ID"].Value = material.MATERIAL_ID;
                dgvDetail.CurrentRow.Cells["MATERIAL_NAME"].Value = material.MATERIAL_NAME;
                dgvDetail.CurrentRow.Cells["MATERIAL_CODE"].Value = material.MATERIAL_CODE;
                dgvDetail.CurrentRow.Cells["MATERIAL_SPEC"].Value = material.MATERIAL_SPEC;
                dgvDetail.CurrentRow.Cells["APPLYCOUNT"].Value = 1;
                dgvDetail.CurrentRow.Cells["unit_name"].Value = material.UNIT_NAME;
                dgvDetail.CurrentRow.Cells["COUNTINSHIP"].Value = dtmaterial.Rows[0]["STOCKSAll"];
                dgvDetail.CurrentRow.Cells["ORDERNUM"].Value = tempIndex++;

                dicDetail[drItem].EndEdit();
            }
            //    bindingSourceDetail.DataSource = dt;
            if (materialInfoList.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("以下选择的物资在该申请单里已存在");
                sb.AppendLine("物资名称 // 规格");
                foreach (MaterialInfo item in materialInfoList)
                    sb.AppendLine(item.MATERIAL_NAME + " // " + item.MATERIAL_SPEC);
                MessageBoxEx.Show(sb.ToString());
            }
        }
        #endregion

        #region 【选择物料】按钮
        /// <summary>
        /// 单击选择按钮打开物资弹出框窗体选择物资的Id和名称.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //选物资.
            if (dgvDetail.Columns[e.ColumnIndex].Name == "selMaterial")
            {
                FrmSelectMaterial frm = new FrmSelectMaterial();
                frm.ShowDialog();
                if (frm.Selected && frm.Materials.Count > 0)
                {
                    InsertMaterialsToGridView(frm.Materials, dgvDetail.CurrentRow.Index, true);
                }
            }
            dicDetail[drItem].Sort = " ORDERNUM ASC";
        }
        #endregion


        #region form验证
        /// <summary>
        /// form验证. 2014.2.21 刘子建修改
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
                if (((DataTable)dicDetail[dr].DataSource).Rows.Count == 0)
                {
                    MessageBoxEx.Show("申请单[" + dr["PURCHASE_APPLY_CODE"] + "] :" + Environment.NewLine +
                        "申请明细不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvApply.Rows[drNum].Selected = true;
                    dgvApply.CurrentCell = dgvApply.Rows[drNum].Cells["PURCHASE_APPLY_CODE"];
                    return false;
                }
                if (((DataTable)dicDetail[dr].DataSource).Select("MATERIAL_ID is null").Length > 0)
                {
                    MessageBoxEx.Show("申请单[" + dr["PURCHASE_APPLY_CODE"] + "] :" + Environment.NewLine +
                        "物资不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                DataTable dt= (DataTable)dicDetail[dr].DataSource;
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
                            dt2.Rows[i]["CONFIRMEDCOUNT"] =
                                dt2.Rows[i]["APPLYCOUNT"];
                    }
                }
                foreach (DataRow drTMP in ((DataTable)dicDetail[dr].DataSource).Rows)
                {
                    if (drTMP.RowState== DataRowState.Deleted)
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
            }
            lstIndex = new List<int>();
            return true;

            //if (string.IsNullOrEmpty(txtDEPARTNAME.Text.Trim()))
            //{
            //    MessageBoxEx.Show("申请人部门不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    dtpPURCHASE_APPLY_DATE.Focus();
            //    return false;
            //}
            //if (string.IsNullOrEmpty(txtHEADSHIP_NAME.Text.Trim()))
            //{
            //    MessageBoxEx.Show("申请人岗位不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    dtpPURCHASE_APPLY_DATE.Focus();
            //    return false;
            //}
            //if (string.IsNullOrEmpty(txtPURCHASE_APPLY_PERSON.Text.Trim()))
            //{
            //    MessageBoxEx.Show("申请人不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    dtpPURCHASE_APPLY_DATE.Focus();
            //    return false;
            //}
            //if (string.IsNullOrEmpty(dtpPURCHASE_APPLY_DATE.Value.ToString()))
            //{
            //    MessageBoxEx.Show("申请日期不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    dtpPURCHASE_APPLY_DATE.Focus();
            //    return false;
            //}
            //if (CommonOperation.ConstParameter.IsLandVersion && string.IsNullOrEmpty(ucShipSelect1.GetId()))
            //{
            //    MessageBoxEx.Show("船舶不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    ucShipSelect1.Focus();
            //    return false;
            //}
            //if (dgvDetail.Rows.Count == 0)
            //{
            //    MessageBoxEx.Show("申请明细不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            //if (dgvDetail.HasEmptyVal("MATERIAL_ID"))
            //{
            //    MessageBoxEx.Show("物资不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            //if (dgvDetail.HasEmptyVal("APPLYCOUNT"))
            //{
            //    MessageBoxEx.Show("申请数量不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            //if (!dgvDetail.IsNumeric("APPLYCOUNT"))
            //{
            //    MessageBoxEx.Show("申请数量不能为非数字信息", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            //if (CommonOperation.ConstParameter.IsLandVersion && dgvDetail.HasEmptyVal("CONFIRMEDCOUNT"))
            //{
            //    if (MessageBoxEx.Show("审批数量不能为空,是否自动用申请条目自动补齐?", "警告",
            //        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            //        return false;
            //    for (int i = 0; i < dgvDetail.Rows.Count; i++)
            //    {
            //        dgvDetail.Rows[i].Cells["CONFIRMEDCOUNT"].Value = dgvDetail.Rows[i].Cells["APPLYCOUNT"].Value;
            //    }
            //}
            //for (int i = 0; i < dgvDetail.Rows.Count; i++)
            //{
            //    DataGridViewRow item = dgvDetail.Rows[i];

            //    if (Convert.ToDecimal(item.Cells["APPLYCOUNT"].Value) <= 0)
            //    {
            //        MessageBoxEx.Show("第" + (i + 1) + "行的申请数量不能小于或等于零", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            //                MessageBoxEx.Show("第" + (i + 1) + "行的批准数量不能小于0", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                return false;
            //            }
            //        }
            //    }
            //}
            //return true;
        }
        #endregion


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

            //if (!CheckForm()) return false;
            //spa.SHIP_ID = ucShipSelect1.GetId();
            //spa.PURCHASE_APPLY_CODE = txtPURCHASE_APPLY_CODE.Text;
            //spa.PURCHASE_APPLY_PERSON = txtPURCHASE_APPLY_PERSON.Text;
            //spa.PURCHASE_APPLY_DATE = dtpPURCHASE_APPLY_DATE.Value;
            //if (string.IsNullOrEmpty(PURCHASE_APPLYID))
            //    spa.DEPART_ID = CommonOperation.ConstParameter.LoginUserInfo.DepartmentId;
            //if (string.IsNullOrEmpty(PURCHASE_APPLYID))
            //    spa.PURCHASE_APPLY_PERSON_POSTID = CommonOperation.ConstParameter.LoginUserInfo.PostId;
            //spa.REMARK = txtREMARK.Text.Trim();

            //return true;
        }
        /// <summary>
        /// 保存函数. 2014.2.21 刘子建修改.
        /// </summary>
        /// <returns></returns>
        private bool SaveFunction()
        {
            string err;

            List<string> listSQL = new List<string>();

            foreach (string strID in dicSPA.Keys)
            {
                if (string.IsNullOrEmpty(dicSPA[strID].PURCHASE_APPLY_CODE))
                    dicSPA[strID].PURCHASE_APPLY_CODE = MaterialPurchaseApplyService.Instance.GetPurchaseApplyCode(ucShipSelect1.GetId());

                //取得SPA的执行语句.
                listSQL.Add(dicSPA[strID].GetUpdateSQL());

                DataRow dr;

                if (string.IsNullOrEmpty(strID))
                {
                    dr = dtMaterialApplyTable.Rows[0];
                }
                else
                {
                    dr = dtMaterialApplyTable.Select("PURCHASE_APPLYID = '" + strID + "'")[0];
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
                listSQL.AddRange(dbOperation.SaveFormData(((DataTable)dicDetail[dr].DataSource), "T_MATERIAL_PURCHASE_APPLY_DETAIL", 0));
            }

            if (!MaterialInfoService.Instance.SubmitSql(listSQL, out err))
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
                    RemindService.Instance.CreateRemindOnce(4, dicSPA[strID].SHIP_ID, dicSPA[strID].PURCHASE_APPLYID);
            }

            #region xzb 加入合单功能影响到的信息，需要把状态置为-1
            if (Action == 1)
            {
                MaterialPurchaseApplyService.Instance.CombinedAllApplyBillAndChangeState(IdList);
            }
            #endregion

            return true;
        }
        /// <summary>
        /// 日期控件事件. 2014.2.21 刘子建添加.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpPURCHASE_APPLY_DATE__ValueChanged(object sender, EventArgs e)
        {
            drItem["PURCHASE_APPLY_DATE"] = dtpPURCHASE_APPLY_DATE.Value;
        }
        /// <summary>
        /// 船舶控件事件.
        /// </summary>
        /// <param name="theSelectedObject"></param>
        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            if (isPassive) return;

            if (dgvDetail.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(PURCHASE_APPLYID))
                {
                    string err;
                    if (!MaterialPurchaseApplyDetailService.Instance.DeleteByPurchaseApplyID(PURCHASE_APPLYID, out err))
                    {
                        MessageBoxEx.Show(err);
                        return;
                    }
                }

                ((DataTable)dicDetail[drItem].DataSource).Rows.Clear();
            }
            drItem["SHIP_ID"] = ucShipSelect1.GetId();
            drItem["SHIP_NAME"] = ucShipSelect1.GetText();
            drItem["PURCHASE_APPLY_CODE"] = MaterialPurchaseApplyService.Instance.GetPurchaseApplyCode(ucShipSelect1.GetId());

            //if (dgvDetail.Rows.Count > 0)
            //{
            //    if (!string.IsNullOrEmpty(PURCHASE_APPLYID))
            //    {
            //        string err;
            //        if (!MaterialPurchaseApplyDetailService.Instance.DeleteByPurchaseApplyID(PURCHASE_APPLYID, out err))
            //        {
            //            MessageBoxEx.Show(err);
            //            return;
            //        }
            //    }
            //    DataTable dtbDetail = (DataTable)bindingSourceDetail.DataSource;
            //    dtbDetail.Rows.Clear();
            //    bindingSourceDetail.DataSource = dtbDetail;
            //    dgvDetail.DataSource = bindingSourceDetail;
            //}
        }
        /// <summary>
        /// 备注修改事件 2014.2.21 刘子建增加.
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
        /// 完成. 2014.2.21 刘子建修改.
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


            //            if (txtREMARK.Text.Trim().Contains("不同意"))
            //            {
            //                MessageBoxEx.Show("备注内容不能包含'不同意'", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                txtREMARK.Focus();
            //                return;
            //            }
            //            if (!UpdateObjectFrom())
            //                return;
            //            if (MessageBoxEx.Show("是否提交审批？", "提示信息", MessageBoxButtons.YesNo,
            //MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            //== System.Windows.Forms.DialogResult.No) return;
            //            spa.SHIP_LEADER_CHECKER = "";
            //            spa.SHIP_LEADER_CHECKDATE = DateTime.MinValue;
            //            spa.SHIP_BOSS_CHECKER = "";
            //            spa.SHIP_BOSS_CHECKDATE = DateTime.MinValue;
            //            spa.LANDCHECKER = "";
            //            spa.CHECKDATE = DateTime.MinValue;
            //            if (CommonOperation.ConstParameter.IsLandVersion)//是岸端.
            //            {
            //                if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务主管.
            //                {
            //                    spa.STATE = 4;
            //                    spa.LANDCHECKER = CommonOperation.ConstParameter.UserName;
            //                    spa.CHECKDATE = DateTime.Now;
            //                }
            //                else if ("机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务经理.
            //                {
            //                    spa.STATE = 5;
            //                    spa.LANDCHECKER = CommonOperation.ConstParameter.UserName;
            //                    spa.CHECKDATE = DateTime.Now;
            //                }
            //                else if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是船管总经理.
            //                {
            //                    spa.STATE = 6;
            //                    spa.LANDCHECKER = CommonOperation.ConstParameter.UserName;
            //                    spa.CHECKDATE = DateTime.Now;
            //                }
            //                else
            //                {
            //                    spa.STATE = 3;
            //                }
            //            }
            //            else//是船端.
            //            {
            //                if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS)//是船长.
            //                {
            //                    spa.STATE = 3;
            //                    spa.SHIP_BOSS_CHECKER = CommonOperation.ConstParameter.UserName;
            //                    spa.SHIP_BOSS_CHECKDATE = DateTime.Now;
            //                }
            //                else if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER)//是部门长.
            //                {
            //                    spa.STATE = 2;
            //                    spa.SHIP_LEADER_CHECKER = CommonOperation.ConstParameter.UserName;
            //                    spa.SHIP_LEADER_CHECKDATE = DateTime.Now;
            //                }
            //                else
            //                {
            //                    spa.STATE = 1;
            //                }
            //            }
            //            spa.ISCOMPLETE = 1;
            if (SaveFunction())
                this.Close();
        }
        /// <summary>
        /// 不提交上级直接通过. 2014.2.21 刘子建修改.
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

            if (MessageBoxEx.Show("是否审批完成，进入订购过程？", "提示信息", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.No) return;

            foreach (string strID in dicSPA.Keys)
            {
                dicSPA[strID].STATE = 6;
                dicSPA[strID].LANDCHECKER = CommonOperation.ConstParameter.UserName;
                dicSPA[strID].CHECKDATE = DateTime.Now;
                dicSPA[strID].ISCOMPLETE = 1;
            }

            //            if (txtREMARK.Text.Trim().Contains("不同意"))
            //            {
            //                MessageBoxEx.Show("备注内容不能包含'不同意'", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                txtREMARK.Focus();
            //                return;
            //            }
            //            if (!UpdateObjectFrom())
            //                return;
            //            if (MessageBoxEx.Show("是否安排订购？", "提示信息", MessageBoxButtons.YesNo,
            //MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            //== System.Windows.Forms.DialogResult.No) return;
            //            spa.STATE = 6;
            //            spa.LANDCHECKER = CommonOperation.ConstParameter.UserName;
            //            spa.CHECKDATE = DateTime.Now;
            //            spa.ISCOMPLETE = 1;

            if (SaveFunction())
                this.Close();
        }
        /// <summary>
        /// 同意按钮事件. 2014.2.21 刘子建修改.
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

            //            if (txtREMARK.Text.Trim().Contains("不同意"))
            //            {
            //                MessageBoxEx.Show("备注内容不能包含'不同意'", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                txtREMARK.Focus();
            //                return;
            //            }
            //            if (!UpdateObjectFrom())
            //                return;
            //            if (MessageBoxEx.Show("是否同意本次申请？", "提示信息", MessageBoxButtons.YesNo,
            //MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            //== System.Windows.Forms.DialogResult.No) return;


            //            if (CommonOperation.ConstParameter.IsLandVersion)//是岸端.
            //            {
            //                if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务主管.

            //                    spa.STATE = 4;
            //                else if ("机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务经理.

            //                    spa.STATE = 5;
            //                else if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是船管总经理.

            //                    spa.STATE = 6;
            //                spa.LANDCHECKER = CommonOperation.ConstParameter.UserName;
            //                spa.CHECKDATE = DateTime.Now;
            //            }
            //            else//是船端.
            //            {
            //                if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS)//是船长.
            //                {
            //                    spa.STATE = 3;
            //                    spa.SHIP_BOSS_CHECKER = CommonOperation.ConstParameter.UserName;
            //                    spa.SHIP_BOSS_CHECKDATE = DateTime.Now;
            //                }
            //                else if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER)//是部门长.
            //                {
            //                    spa.STATE = 2;
            //                    spa.SHIP_LEADER_CHECKER = CommonOperation.ConstParameter.UserName;
            //                    spa.SHIP_LEADER_CHECKDATE = DateTime.Now;

            //                    spa.SHIP_BOSS_CHECKER = "";
            //                    spa.SHIP_BOSS_CHECKDATE = DateTime.MinValue;
            //                }
            //                spa.LANDCHECKER = "";
            //                spa.CHECKDATE = DateTime.MinValue;
            //            }
            //            spa.ISCOMPLETE = 1;

            if (SaveFunction())
                this.Close();
        }
        /// <summary>
        /// 不同意按钮事件. 2014.2.21 刘子建修改.
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

            //            string err;
            //            if (MessageBoxEx.Show("是否不同意本次申请？", "提示信息", MessageBoxButtons.YesNo,
            //MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            //== System.Windows.Forms.DialogResult.No) return;

            //            if (CommonOperation.ConstParameter.IsLandVersion)//是岸端.
            //            {
            //                if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务主管.
            //                {
            //                    DataTable dt = BaseInfo.DataAccess.PostService.Instance.getInfoByType("船长岗位", out err);
            //                    if (spa.PURCHASE_APPLY_PERSON_POSTID == dt.Rows[0][0].ToString())
            //                        spa.STATE = 8;
            //                    else
            //                        spa.STATE = 2;
            //                    spa.REMARK += "\r\n机务主管不同意";
            //                }
            //                else if ("机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务经理.
            //                {
            //                    DataTable dt = BaseInfo.DataAccess.PostService.Instance.getInfoByType("机务主管岗位", out err);
            //                    if (spa.PURCHASE_APPLY_PERSON_POSTID == dt.Rows[0][0].ToString())
            //                        spa.STATE = 8;
            //                    else
            //                        spa.STATE = 3;
            //                    spa.REMARK += "\r\n机务经理不同意";
            //                }
            //                else if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是船管总经理.
            //                {
            //                    DataTable dt = BaseInfo.DataAccess.PostService.Instance.getInfoByType("机务经理岗位", out err);
            //                    if (spa.PURCHASE_APPLY_PERSON_POSTID == dt.Rows[0][0].ToString())
            //                        spa.STATE = 8;
            //                    else
            //                        spa.STATE = 4;
            //                    spa.REMARK += "\r\n船管总经理不同意";
            //                }
            //                spa.LANDCHECKER = CommonOperation.ConstParameter.UserName;
            //                spa.CHECKDATE = DateTime.Now;
            //            }
            //            else//是船端.
            //            {
            //                if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS)//是船长.
            //                {
            //                    if (BaseInfo.DataAccess.PostService.Instance.getObject(spa.PURCHASE_APPLY_PERSON_POSTID, out err).ISHEADER == 1)
            //                        spa.STATE = 8;
            //                    else
            //                        spa.STATE = 1;
            //                    spa.REMARK += "\r\n船长不同意";
            //                    spa.SHIP_BOSS_CHECKER = CommonOperation.ConstParameter.UserName;
            //                    spa.SHIP_BOSS_CHECKDATE = DateTime.Now;
            //                }
            //                else if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER)//是部门长.
            //                {
            //                    spa.STATE = 0;
            //                    spa.REMARK += "\r\n部门长不同意";
            //                    spa.SHIP_LEADER_CHECKER = CommonOperation.ConstParameter.UserName;
            //                    spa.SHIP_LEADER_CHECKDATE = DateTime.Now;
            //                }
            //            }
            //            //spa.STATE = 8;
            //            //spa.SHIP_BOSS_CHECKER = "";
            //            //spa.SHIP_BOSS_CHECKDATE = DateTime.MinValue;
            //            //spa.SHIP_LEADER_CHECKER = "";
            //            //spa.SHIP_LEADER_CHECKDATE = DateTime.MinValue;
            //            //spa.LANDCHECKER = "";

            if (SaveFunction())
                this.Close();
        }
        /// <summary>
        /// 添加明细. 2014.2.21 刘子建修改.
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
            if (!dgvDetail.HasEmptyVal("MATERIAL_NAME"))
            {
                dicDetail[drItem].AddNew();
                //bindingSourceDetail.AddNew();
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
            //wanhw-2014-10-11-删除修复bug--->删除之后提交不成功。
            //(dicDetail[drItem].DataSource as DataTable).AcceptChanges();
            //bindingSourceDetail.RemoveCurrent();
        }
        /// <summary>
        /// 关闭时.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMaterialPurchaseApplyEdit_FormClosing(object sender, FormClosingEventArgs e)
        {

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
            //if (dgvApply.CurrentRow != null)
            //{
            //    PURCHASE_APPLYID = dgvApply.CurrentRow.Cells["PURCHASE_APPLYID"].Value.ToString();
            //}
            //else
            //{
            PURCHASE_APPLYID = dgvApply.Rows[rowNumber].Cells["PURCHASE_APPLYID"].Value.ToString();
            //}

            drItem = dtMaterialApplyTable.Select("PURCHASE_APPLYID = '" + PURCHASE_APPLYID + "'").Length > 0 ?
                dtMaterialApplyTable.Select("PURCHASE_APPLYID = '" + PURCHASE_APPLYID + "'")[0] : drItem;

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
            dgvDetail.Columns["MATERIAL_CODE"].ReadOnly = !(stateCheck[0] || stateCheck[1]);
            dgvDetail.Columns["MATERIAL_SPEC"].ReadOnly = !(stateCheck[0] || stateCheck[1]);
            dgvDetail.Columns["REMARK"].ReadOnly = !(stateCheck[0] || stateCheck[1]);
            dgvDetail.Columns["ORDERNUM"].ReadOnly = false;
            dtpPURCHASE_APPLY_DATE.Enabled = stateCheck[0] || stateCheck[1];
            ucShipSelect1.Enabled = stateCheck[0];
            txtREMARK.Enabled = stateCheck[0] || stateCheck[1];

            foreach (DataGridViewColumn item in dgvDetail.Columns)
            {
                if (item.ReadOnly)
                    item.DefaultCellStyle.BackColor = Color.Linen;
            }
        }

    }
}
