using BaseInfo.DataAccess;
using CommonViewer.BaseControlService;
using Oil.DataObject;
using Oil.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Oil.Viewer
{
    public partial class FrmOilAudit : CommonViewer.BaseForm.FormBase
    {
        #region  窗体变量
        /// <summary>
        /// 业务主键.
        /// </summary>
        private String businessId;
        /// <summary>
        /// 错误信息.
        /// </summary>
        private String errMessage;
        /// <summary>
        /// 初始化下拉框用.
        /// </summary>
        private FormControlOption other = FormControlOption.Instance;
        /// <summary>
        /// 控制是否同意；
        /// 0：默认状态；
        /// 1：同意状态；
        /// 2：不同意状态;
        /// </summary>
        private int isArgee = 0;
        public int IsArgee
        {
            get { return isArgee; }
            set { isArgee = value; }
        }
        /// <summary>
        /// 保存gridview的列名.
        /// </summary>
        Dictionary<string, string> dictColumnsSub = new Dictionary<string, string>();
        /// <summary>
        /// 是否是第一次加载datagridview.
        /// </summary>
        bool isFirstLoadSub = true;
        HOilApply oilApply;
        #endregion

        #region  构造函数
        public FrmOilAudit()
        {
            InitializeComponent();
        }
        public FrmOilAudit(String businessId)
            : this()
        {
            this.businessId = businessId;
        }
        #endregion

        #region  窗体方法

        #region  将对象展示到对应的控件中
        /// <summary>
        /// 将对象展示到对应的控件中.
        /// </summary>
        /// <param name="tempObject">滑油申请对象.</param>
        private void ShowObject(HOilApply tempObject)
        {
            if (tempObject != null && !tempObject.IsWrong)
            {
                dtpApplyDate.Value = tempObject.APPLY_DATE;
                dtpArriveDate.Value = tempObject.SUPPLY_DATE;
                cobPort.SelectedValue = tempObject.PORT_ID;
                txtVoyage.Text = tempObject.VOYAGE;

                txtCheckor.Text = tempObject.APPROVER;
                txtLeader.Text = tempObject.APPROVER2;
                txtLandChecker.Text = tempObject.CHECKED.Equals(2M) || tempObject.CHECKED.Equals(9M) ? "已审核" : "未审核";
                txtRemark.Text = tempObject.REMARK;
            }
            else
            {
                dtpApplyDate.Value = DateTime.Now;
                dtpArriveDate.Value = DateTime.Now;
                txtVoyage.Text = "";

                txtCheckor.Text = "";
                txtLeader.Text = "";
                txtLandChecker.Text = "";
                txtRemark.Text = "";
            }
        }
        #endregion

        #region 设置下拉框控件
        /// <summary>
        /// 设置下拉框控件.
        /// </summary>
        private void SetComboBox()
        {
            string err = "";
            DataTable dtb1 = PortInfoService.Instance.getInfo(out err);
            other.SetComboBoxValue(cobPort, dtb1);
        }

        #endregion

        #region  加载gridview的样式
        /// <summary>
        /// 加载gridview的样式.
        /// </summary>
        private void LoadDataColSub()
        {
            dictColumnsSub.Clear();
            dgvOilApplyDetail.LoadGridView("FrmOilAudit.dgvOilApplyDetail");

            //设置列标题.
            dictColumnsSub.Add("TRADEMARK", "牌号");
            dictColumnsSub.Add("NUM", "申请数量");
            dictColumnsSub.Add("THISMONTH_STORE", "上月库存数量");
            dictColumnsSub.Add("remark", "备注");

            dgvOilApplyDetail.SetDgvGridColumns(dictColumnsSub);
            string[] readOnlyColumns = { "TRADEMARK", "THISMONTH_STORE" };
            dgvOilApplyDetail.setDgvColumnsReadOnly(readOnlyColumns);
            isFirstLoadSub = false;
        }
        #endregion

        #region  检查按钮权限，及gridview是否可编辑
        /// <summary>
        /// 检查按钮权限，及gridview是否可编辑.
        /// </summary>
        /// <param name="checkedStatus"></param>
        private void CheckRight(decimal checkedStatus)
        {
            if (checkedStatus > 1 || checkedStatus ==0)
            {
                dgvOilApplyDetail.ReadOnly = true;
                //btn_NotOk.Visible = false;
                btn_Ok.Visible = false;

                cobPort.Enabled = false;
                txtVoyage.ReadOnly = true;
                txtRemark.ReadOnly = true;
            }
            else
            {
                dgvOilApplyDetail.ReadOnly = false;
                //btn_NotOk.Visible = true;
                btn_Ok.Visible = true;

                cobPort.Enabled = true;
                txtVoyage.ReadOnly = false;
                txtRemark.ReadOnly = false;
            }
        }

        #endregion

        #region  设置滑油申请单明细信息的bindingSource数据源
        /// <summary>
        /// 设置滑油申请单明细信息的bindingSource数据源，每次查询的都是指定申请单的明细信息数据.
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <param name="materialApplyId">申请单信息Id</param>
        private void SetBindingSourceDetail(string ApplyId, string shipID, DateTime applyDate)
        {
            DataTable dtb = HOilApplyDetailService.Instance.GetApplyDatas(ApplyId, shipID, applyDate);//取得申请单明细信息的DataTable对象.
            bindingSourceDetail.DataSource = dtb;
            dgvOilApplyDetail.DataSource = bindingSourceDetail;
            if (isFirstLoadSub)
            {
                LoadDataColSub();
            }
        }
        #endregion

        #region  获取已经修改的滑油申请明细
        /// <summary>
        /// 获取已经修改的滑油申请明细.
        /// </summary>
        /// <returns>修改的滑油申请明细.</returns>
        private List<HOilApplyDetail> GetHOilApplyDetailList()
        {
            this.bindingSourceDetail.EndEdit();
            DataTable dt = (DataTable)bindingSourceDetail.DataSource;
            List<HOilApplyDetail> listUnit = new List<HOilApplyDetail>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i].RowState == DataRowState.Modified)
                {
                    HOilApplyDetail unit = HOilApplyDetailService.Instance.getObject(dt.Rows[i]["APPLY_DETAIL_ID"].ToString(), out errMessage);
                    if (!String.IsNullOrEmpty(dt.Rows[i]["NUM"].ToString().Trim().ToString()))
                    {
                        unit.NUM = Decimal.Parse(dt.Rows[i]["NUM"].ToString());
                    }
                    unit.REMARK = dt.Rows[i]["REMARK"].ToString();
                    listUnit.Add(unit);
                }
            }
            return listUnit;
        }
        #endregion

        #region  保存滑油申请明细
        /// <summary>
        /// 保存滑油申请明细.
        /// </summary>
        private void SaveOilApplyDetail()
        {
            List<HOilApplyDetail> listUnit = GetHOilApplyDetailList();
            foreach (HOilApplyDetail item in listUnit)
            {
                HOilApplyDetailService.Instance.saveUnit(item,out errMessage);
            }
        }
        #endregion

        #region  获取滑油申请
        /// <summary>
        /// 获取滑油申请.
        /// </summary>
        /// <returns>滑油申请对象.</returns>
        private HOilApply GetOilApply()
        {
            oilApply.PORT_ID = cobPort.SelectedValue.ToString();
            oilApply.VOYAGE = txtVoyage.Text.ToString();
            oilApply.REMARK = txtRemark.Text.ToString();
            return oilApply;
        }

        #endregion

        #region  保存滑油申请
        /// <summary>
        /// 保存滑油申请.
        /// </summary>
        private void SaveOilApply()
        {
            GetOilApply();
            HOilApplyService.Instance.saveUnit(oilApply, out errMessage);
        }
        #endregion

        #endregion

        #region 窗体事件

        private void FrmOilAudit_Load(Object sender, EventArgs e)
        {
            SetComboBox();
            oilApply = HOilApplyService.Instance.getObject(businessId, out errMessage);
            ShowObject(oilApply);
            SetBindingSourceDetail(businessId, oilApply.SHIP_ID, oilApply.APPLY_DATE);
            CheckRight(oilApply.CHECKED);
        }

        private void FrmOilAudit_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvOilApplyDetail.SaveGridView("FrmOilAudit.dgvOilApplyDetail");
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            SaveOilApply();
            SaveOilApplyDetail();
            isArgee = 1;
            this.Close();
        }

        private void btn_NotOk_Click(object sender, EventArgs e)
        {
            //SaveOilApply();
            //SaveOilApplyDetail();
            //isArgee = 2;
            //this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            isArgee = 0;
            this.Close();
        }
        #endregion
    }
}
