using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonViewer;
using Cost.Services;
using Cost.DataObject;
using CommonViewer.BaseControl;
using Repair.DataObject;
using Repair.Services;

namespace Repair.Viewer
{
    public partial class FrmDockRepairSummarize : CommonViewer.BaseForm.FormBase
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmDockRepairSummarize instance = new FrmDockRepairSummarize();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmDockRepairSummarize Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmDockRepairSummarize.instance = new FrmDockRepairSummarize();
                }

                return FrmDockRepairSummarize.instance;
            }
        }
        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmDockRepairSummarize()
        {
            InitializeComponent();
        }
        #endregion
        bool isLoadedActualCost = false;
        bool isLoadedDetail = false;
        string lastShipID = "";
        DateTime lastBeginDate;
        DateTime lastEndDate;
        private void FrmDockRepairSummarize_Load(object sender, EventArgs e)
        {
            ucShipSelect1.ChangeSelectedState(false, true);
            SetSummarizeBindingSource();
            SetSummarizeDataGridView();
        }
        /// <summary>
        /// 绑定坞修总结列表信息.
        /// </summary>
        private void SetSummarizeBindingSource()
        {
            ClearData();
            DataTable dt;
            string err;
            if (!DockRepairSummarizeService.Instance.GetmMainInfoByGroup(ucShipSelect1.GetId(), out dt, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            bdsSummarize.DataSource = dt;
            dgvSummarize.DataSource = bdsSummarize;
        }
        /// <summary>
        /// 绑定坞修总结列表信息.
        /// </summary>
        private void SetSummarizeDataGridView()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("SHIP_NAME", "船舶");
            dic.Add("BEGINDATE", "开始日期");
            dic.Add("ENDDATE", "结束日期");
            dgvSummarize.SetDgvGridColumns(dic);
            dgvSummarize.LoadGridView("FrmDockRepairSummarize.dgvSummarize");
            dgvSummarize.SetDgvGridDateColumnsFormatShort();
        }
        /// <summary>
        /// 设置坞修明细列.
        /// </summary>
        private void SetDetailDataGridView()
        {
            if (isLoadedDetail) return;
            isLoadedDetail = true;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("SHIP_NAME", "船舶");
            dic.Add("NODE_NAME", "科目");
            dic.Add("MANUFACTURER_NAME", "供应商");
            dic.Add("ESTIMATE_AMOUNT", "预估金额");
            dic.Add("TOTAL_AMOUNT", "汇总金额(美元)");
            dic.Add("CURRENCYNAME", "币种");
            dgvDetail.SetDgvGridColumns(dic);
            dgvDetail.LoadGridView("FrmDockRepairSummarize.dgvDetail");
            dgvDetail.SetDgvGridDateColumnsFormatShort();
        }
        /// <summary>
        /// 设置实际发生费用列.
        /// </summary>
        public void SetActualCostDataGridView()
        {
            if (isLoadedActualCost) return;
            isLoadedActualCost = true;
            Dictionary<string, string> dictColumns = new Dictionary<string, string>();
            dictColumns.Add("DESCRIPTION", "付费项目");
            dictColumns.Add("CUSTOMER", "供应商");
            dictColumns.Add("REMARK", "备注");
            dictColumns.Add("OCCURENCY_DATE", "发生日期");
            dictColumns.Add("PAYMENT_DATE", "付款日期");
            dictColumns.Add("AMOUNT", "金额");
            dictColumns.Add("NODE_NAME", "科目");
            dictColumns.Add("ESTIMATE_AMOUNT", "预估金额");
            dictColumns.Add("CONVERT_MONEY", "折算成美金");
            dictColumns.Add("CONTRACT_NUM", "合同评审号");
            dictColumns.Add("COMPLETE_DATE", "完成日期");
            dictColumns.Add("COMPLETE_PALCE", "完成地点");
            dictColumns.Add("APPLICANT", "申请人");
            dictColumns.Add("APPROVER", "审核人");
            dictColumns.Add("APPROVER2", "审批人");
            dictColumns.Add("INVOICE_DATE", "发票日期");
            dictColumns.Add("INVOICE_NUM", "发票号");
            dictColumns.Add("CURRENCYCODE", "币种");
            dictColumns.Add("SHIP_NAME", "船舶");
            dgvActualCost.SetDgvGridColumns(dictColumns);
            //设置列只读.

            dgvActualCost.LoadGridView("FrmDockRepairSummarize.dgvActualCost");
            dgvActualCost.SetDgvGridDateColumnsFormatShort();
        }
        /// <summary>
        /// 清空数据.
        /// </summary>
        private void ClearData()
        {
            isLoadedActualCost = false;
            isLoadedDetail = false;
            lastShipID = "";
            lastBeginDate = new DateTime();
            lastEndDate = new DateTime();
            if (dgvActualCost.Rows.Count > 0)
                bdsActualCost.DataSource = new DataTable();
            if (dgvDetail.Rows.Count > 0)
                bdsDetail.DataSource = new DataTable();
        }
        /// <summary>
        /// 更新明细与实际发生费用.
        /// </summary>
        /// <param name="rowNumber"></param>
        private void dgvSummarize_CurrentCellChanged(object sender, EventArgs e)
        {
            if (bdsSummarize.Current == null) return;
            DataRowView drv = (DataRowView)bdsSummarize.Current;
            if (lastShipID == drv["SHIP_ID"].ToString()
                && lastBeginDate == Convert.ToDateTime(drv["BEGINDATE"])
                && lastEndDate == Convert.ToDateTime(drv["ENDDATE"])) return;
            lastShipID = drv["SHIP_ID"].ToString();
            lastBeginDate = Convert.ToDateTime(drv["BEGINDATE"]);
            lastEndDate = Convert.ToDateTime(drv["ENDDATE"]);

            DataTable dt;
            string err;
            if (!DockRepairSummarizeService.Instance.GetInfoByCondition(drv["SHIP_ID"].ToString(),
                Convert.ToDateTime(drv["BEGINDATE"]), Convert.ToDateTime(drv["ENDDATE"]), out dt, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            bdsDetail.DataSource = dt;
            dgvDetail.DataSource = bdsDetail;
            SetDetailDataGridView();

            DataTable dtActualCost;
            if (!ACTUAL_COSTSService.Instance.GetActualCostInfoByCondition(drv["SHIP_ID"].ToString(),
                Convert.ToDateTime(drv["BEGINDATE"]), Convert.ToDateTime(drv["ENDDATE"]), out dtActualCost, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            bdsActualCost.DataSource = dtActualCost;
            dgvActualCost.DataSource = bdsActualCost;
            SetActualCostDataGridView();
        }
        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            SetSummarizeBindingSource();
        }

        /// <summary>
        /// 导入项目.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            FrmDockRepairSummarizeEdit frm = new FrmDockRepairSummarizeEdit(ucShipSelect1.GetId());
            frm.ShowDialog();
            SetSummarizeBindingSource();
        }
        /// <summary>
        /// 编辑修改.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (bdsSummarize.Current == null)
            {
                MessageBoxEx.Show("未选中任何行!");
            }
            DataRowView drv = (DataRowView)bdsSummarize.Current;
            FrmDockRepairSummarizeEdit frm = new FrmDockRepairSummarizeEdit(drv["SHIP_ID"].ToString(),
                Convert.ToDateTime(drv["BEGINDATE"]), Convert.ToDateTime(drv["ENDDATE"]));
            frm.ShowDialog();
            SetSummarizeBindingSource();
        }
        /// <summary>
        /// 删除.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string err;
            if (bdsSummarize.Current != null)
            {
                if (DialogResult.No == MessageBoxEx.Show("确认要删除该坞修总结吗?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                    return;
                DataRowView drv = (DataRowView)bdsSummarize.Current;
                if (!DockRepairSummarizeService.Instance.DeleteInfoByCondition(drv["SHIP_ID"].ToString(),
                Convert.ToDateTime(drv["BEGINDATE"]), Convert.ToDateTime(drv["ENDDATE"]), out err))
                {
                    MessageBoxEx.Show(err);
                    return;
                }
                MessageBoxEx.Show("操作成功");
                SetSummarizeBindingSource();
            }
        }
        /// <summary>
        /// 导出报表.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (bdsDetail.DataSource == null || ((DataTable)bdsDetail.DataSource).Rows.Count == 0)
                return;
            if (RepairConfig.customDockRepairSummarizePrint != null)
            {
                string err;
                if (!RepairConfig.customDockRepairSummarizePrint(((DataTable)bdsDetail.DataSource), out err))
                {
                    MessageBoxEx.Show("打印失败,错误参考\r" + err);
                }
            }

        }

        /// <summary>
        /// 正在关闭窗体.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmDockRepairSummarize_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvActualCost.SaveGridView("FrmDockRepairSummarize.dgvActualCost");
            dgvDetail.SaveGridView("FrmDockRepairSummarize.dgvDetail");
            dgvSummarize.SaveGridView("FrmDockRepairSummarize.dgvSummarize");
            instance = null;
        }
        /// <summary>
        /// 关闭按钮.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
