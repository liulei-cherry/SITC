using CommonOperation;
using CommonViewer.BaseControl;
using CommonViewer.BaseForm;
using ItemsManage;
using StorageManage.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace StorageManage.Viewer
{
    public partial class FrmMaterialApplySelect : FormBase
    {
        #region  窗体变量
        /// <summary>
        /// 船舶ID
        /// </summary>
        public String ShipId = String.Empty;
        /// <summary>
        /// 错误消息
        /// </summary>
        private String errMessage = String.Empty;
        /// <summary>
        /// 物料申请信息
        /// </summary>
        private DataTable dtsource = null;
        /// <summary>
        /// 物料申请ID列表
        /// </summary>
        public List<String> ApplyIdList = new List<String>();//选择的ID

        private string ApplyId = string.Empty;
        /// <summary>
        /// 物料字表部分信息包含ID
        /// </summary>
        public List<StorageParameter> StorageParameterList = new List<StorageParameter>();
        #endregion

        #region 构造函数
        public FrmMaterialApplySelect()
        {
            InitializeComponent();
        }
        public FrmMaterialApplySelect(String shipId)
        {
            InitializeComponent();
            this.ShipId = shipId;
        }
        #endregion

        #region 窗体事件
        private void FrmMaterialApplySelect_Load(object sender, EventArgs e)
        {
            InitializePageData();
            InitializePageUI();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            ApplyIdList.Add(this.ApplyId);

            DataTable dtDetail;
            if (!MaterialPurchaseApplyDetailService.Instance.GetInfo(this.ApplyId, out dtDetail, out errMessage))
            {
                MessageBoxEx.Show(errMessage);
                return;
            }
            foreach (DataRow objitem in dtDetail.Rows)
            {
                StorageParameter sp = new StorageParameter();
                sp.ItemId = objitem["MATERIAL_ID"].ToString();
                sp.orderCode = "";//objitem["MATERIAL_NAME"].ToString();
                sp.Count = Convert.ToDecimal(objitem["APPLYCOUNT"]);
                StorageParameterList.Add(sp);
            }
            this.Close();

        }

        private void ckbShowReference_CheckedChanged(object sender, EventArgs e)
        {
            InitializePageData();
        }
        #endregion

        #region 窗体方法
        private void InitializePageData()
        {
            if (!String.IsNullOrEmpty(ShipId))
            {
                
                ConstParameter.SystemParameter smParam = new ConstParameter.SystemParameter();
                DateTime output;
                if (!DateTime.TryParse(smParam["ApplyFromInStorageApplyDate"],out output))
                {
                    output = new DateTime(2013, 7, 15);    
                }
                if (!MaterialPurchaseApplyService.Instance.SelectPurchaseApplyTable(ShipId, output, ckbShowReference.Checked, out dtsource, out errMessage))
                {
                    MessageBoxEx.Show(errMessage);
                    return;
                }
                dgvApplyList.DataSource = dtsource;
            }
            else { MessageBoxEx.Show("船舶ID必须传入否则无法显示该页面！"); return; }
        }

        private void InitializePageUI()
        {
            Dictionary<String, String> dgvColumnStyle = new Dictionary<String, String>();
            dgvColumnStyle.Add("PURCHASE_APPLY_CODE", "申请单号");
            dgvColumnStyle.Add("SHIP_NAME", "船舶");
            dgvColumnStyle.Add("PURCHASE_APPLY_PERSON", "申请人");
            dgvColumnStyle.Add("PURCHASE_APPLY_DATE", "申请日期");
            dgvColumnStyle.Add("STATE_NAME", "状态");
            dgvColumnStyle.Add("REMARK", "备注");
            dgvApplyList.SetDgvGridColumns(dgvColumnStyle);
            dgvApplyList.LoadGridView("FrmMaterialApplySelect.dgvApplyList");
        }
        #endregion

        private void dgvApplyList_SelectedChanged(int rowNumber)
        {
            if (dgvApplyList.Rows[rowNumber].Cells["PURCHASE_APPLYID"].Value != null)
            {
                this.ApplyId = dgvApplyList.Rows[rowNumber].Cells["PURCHASE_APPLYID"].Value.ToString();
                DataTable dt = (DataTable)dgvApplyList.DataSource;
                DataRow drItem = dt.Select("PURCHASE_APPLYID='" + this.ApplyId + "'")[0];
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
                if (!MaterialPurchaseApplyDetailService.Instance.GetInfo(this.ApplyId, out dtDetail, out errMessage))
                {
                    MessageBoxEx.Show(errMessage);
                    return;
                }
                dgvDetail.DataSource = dtDetail;
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("MATERIAL_NAME", "物资");
                dic.Add("MATERIAL_CODE", "物资编号");
                dic.Add("MATERIAL_SPEC", "采购号或规格");
                dic.Add("UNIT_NAME", "单位");
                dic.Add("APPLYCOUNT", "申请数量");
                dic.Add("REMARK", "备注");
                dgvDetail.SetDgvGridColumns(dic);
                foreach (DataGridViewColumn item in dgvDetail.Columns)
                    item.ReadOnly = true;
            }
        }


    }
}
