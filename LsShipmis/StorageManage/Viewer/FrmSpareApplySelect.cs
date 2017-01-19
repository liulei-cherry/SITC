using BaseInfo.DataAccess;
using CommonOperation;
using CommonOperation.Interfaces;
using CommonViewer.BaseControl;
using CommonViewer.BaseForm;
using ItemsManage;
using StorageManage.DataObject;
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
    public partial class FrmSpareApplySelect : FormBase
    {
        private string shipId = "";//船舶.
        public List<StorageParameter> spareids = new List<StorageParameter>();
        public string COMPONENT_UNIT_ID = string.Empty;

        #region 当前行关键值
        public string PURCHASE_APPLYID = "";
        private string STATE = "";
        private string DEPART_ID = "";
        private string PURCHASE_APPLY_PERSON = "";
        private string ISCOMPLETE = "";
        #endregion

        public FrmSpareApplySelect()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmSpareApplySelect instance = new FrmSpareApplySelect();
        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmSpareApplySelect Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmSpareApplySelect.instance = new FrmSpareApplySelect();
                }

                return FrmSpareApplySelect.instance;
            }
        }

        /// <summary>
        /// 构造方法的重载
        /// </summary>
        /// <param name="paramShipID">船舶id</param>
        public FrmSpareApplySelect(string paramShipID)
        {
            InitializeComponent();
            shipId = paramShipID;
            ucShipSelect1.SelectedId(shipId);
            ucShipSelect1.Enabled = false;
        }

        /// <summary>
        /// 画面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSpareApplySelect_Load(object sender, EventArgs e)
        {
            this.setBindingSource();//设置数据源.
            this.setDataGridView(); //设置网格控件dgvApply的隐藏列与标头的设置.
            ucShipSelect1.ChangeSelectedState(false, true);
        }

        /// <summary>
        /// 选择并关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            string err;
            DataTable dtDetail;
            if (!SparePurchaseApplyDetailService.Instance.GetInfo(PURCHASE_APPLYID, out dtDetail, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            SparePurchaseApply spa = SparePurchaseApplyService.Instance.getObject(PURCHASE_APPLYID, out err);
            this.COMPONENT_UNIT_ID = spa.COMPONENT_UNIT_ID;
            foreach (DataRow spareitem in dtDetail.Rows)
            {
                StorageParameter sp = new StorageParameter();
                sp.ItemId = spareitem["SPARE_ID"].ToString();
                sp.Count = spa.STATE != 6 ? Convert.ToDecimal(spareitem["APPLYCOUNT"]) : Convert.ToDecimal(spareitem["CONFIRMEDCOUNT"]);
                spareids.Add(sp);
            }
            this.Close();
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 绑定信息.
        /// </summary>
        private void setBindingSource()
        {
            string shipId = ucShipSelect1.GetId();//船舶.
            string onlyPostID = cbPost.Checked ? CommonOperation.ConstParameter.LoginUserInfo.PostId : null;  //仅本岗位.
                        
            string person = CommonOperation.ConstParameter.UserName;
            ConstParameter.SystemParameter smParam = new ConstParameter.SystemParameter();
            DateTime output;
            DataTable dtbApply = new DataTable();
            if (DateTime.TryParse(smParam["ApplyFromInStorageApplyDate"], out output))
            {
                dtbApply = SparePurchaseApplyService.Instance.GetApplyInfo(shipId, smParam["ApplyFromInStorageApplyDate"]);//取得信息的DataTable对象.
            }
            else
            {
                dtbApply = SparePurchaseApplyService.Instance.GetApplyInfo(shipId, "2013/07/15");//取得信息的DataTable对象.
            }
            
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");
            sb.AppendLine(" and (ISCOMPLETE=1 or ( ISCOMPLETE=0 and PURCHASE_APPLY_PERSON='" + person + "'))");

            
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
            DataTable newdt = new DataTable();
            newdt = dtbApply.Clone();
            foreach (DataRow item in dtbApply.Select(sb.ToString()))
                newdt.Rows.Add(item.ItemArray);
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
            txtSHIP_BOSS_CHECKDATE.Text = "";
            txtLANDCHECKER.Text = "";
            txtCHECKDATE.Text = "";
            txtREMARK.Text = "";

            dgvApply.DataSource = newdt;
            if (newdt.Rows.Count == 0)
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
            dgvApply.SetDgvGridColumns(dgvColumnStyle);
            dgvApply.LoadGridView("FrmSpareApplySelect.dgvApply");
        }
        
        /// <summary>
        /// 申请信息列表的选择处理方法
        /// </summary>
        /// <param name="rowNumber">选择行号</param>
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
        /// 显示数据到控件上.
        /// </summary>
        private void ShowDataToForm()
        {
            DataTable dt = (DataTable)dgvApply.DataSource;
            DataRow drItem = dt.Select("PURCHASE_APPLYID='" + PURCHASE_APPLYID + "'")[0];
            txtShip.Text = drItem["SHIP_NAME"].ToString();
            txtComponent.Text = drItem["COMP_CHINESE_NAME"].ToString();
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
        /// 显示被入库单引用选中事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbPost_CheckedChanged(object sender, EventArgs e)
        {
            this.setBindingSource();
        }
    }
}
