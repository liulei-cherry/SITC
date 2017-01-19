using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonViewer.BaseForm;
using CommonOperation.Functions;
using ItemsManage.DataObject;
using ItemsManage.Services;
using ItemsManage.Viewer;
using Maintenance.Services;
using CommonViewer.BaseControlService;
using CommonViewer.BaseControl;
using CMSManage.Services;
using CMSManage.DataObject;
using CommonOperation.Interfaces;
using Maintenance.DataObject;
using OfficeOperation;
using CommonViewer;

namespace CMSManage.Viewer
{
    /// <summary>
    /// 工单历史信息查看窗体.
    /// </summary>
    public partial class FrmCMSHistory : CommonViewer.BaseForm.FormBase
    {
        private ProxyRight proxyRight = ProxyRight.Instance;//权限代理业务类.
        private IDBOperation commonOpt = CommonOperation.Functions.InterfaceInstantiation.NewADBOperation();//定义一个公共类CommonOpt对象.
        bool finishLoaded = false;
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmCMSHistory instance;

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmCMSHistory Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmCMSHistory.instance = new FrmCMSHistory();
                }

                return FrmCMSHistory.instance;
            }
        }

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmCMSHistory()
        {
            InitializeComponent();
            dtpStartFinDate.Value = DateTime.Today.AddYears(-1);
            dtpEndFinDate.Value = CommonOperation.ConstParameter.MaxDateTime;
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWorkOrderHistory_Load(object sender, EventArgs e)
        {

            //如果有船，则自动给检验日期按照上次日期加5年.
            if (!CommonOperation.ConstParameter.IsLandVersion)
            {
                ucShipSelect1.SelectedId(CommonOperation.ConstParameter.ShipId, false);
            }
            string err;
            DataTable dtCmsCheckLog = CMSCheckLogService.Instance.getInfo(out err);
            bdsCmsCheckLog.DataSource = dtCmsCheckLog;
            dgvCMSCheckList.DataSource = bdsCmsCheckLog;
            setMainDataGridView();
            cbx_CheckState.SelectedIndex = 0;
            finishLoaded = true;
            this.WindowState = FormWindowState.Maximized;//窗体最大化.
        }

        private void loadData()
        {
            if (!finishLoaded) return;
            string filter;
            string shipid = ucShipSelect1.GetId();
            DateTime dtFrom = dtpStartFinDate.Value;
            DateTime dtEnd = dtpEndFinDate.Value;
            int checkState = cbx_CheckState.SelectedIndex;

            filter = "CHECK_DATE > '" + dtFrom.ToShortDateString() + "' and  CHECK_DATE < '" + dtEnd.ToShortDateString() + "'";

            if (!string.IsNullOrEmpty(shipid)) filter += " and ship_id = '" + shipid.Trim() + "'";

            if (checkState > 0) filter += " and CHECK_STATE = " + checkState.ToString();

            bdsCmsCheckLog.Filter = filter;
            if (dgvCMSCheckList.Rows.Count == 0) clearObject();
        }

        private void setMainDataGridView()
        {
            dgvCMSCheckList.LoadGridView("FrmCMSHistory.dgvCMSCheckList");

            Dictionary<string, string> disp = new Dictionary<string, string>();
            disp.Add("CHECK_DATE", "检验时间");
            disp.Add("SHIP_NAME", "船舶名称");
            disp.Add("Check_State_View", "检验状态");
            dgvCMSCheckList.SetDgvGridColumns(disp);
            dgvCMSCheckList.setDgvColumnsReadOnly(new string[] { "CHECK_DATE", "SHIP_NAME", "Check_State_View" });
        }

        /// <summary>
        /// 设置物料信息网格控件dgvMatApply的隐藏列与显示标题.
        /// </summary>
        private void setDataGridView()
        {
            dgvCMSCheckLogDetailList.LoadGridView("FrmCMSHistory.dgvCMSCheckLogDetailList");
            Dictionary<string, string> disp = new Dictionary<string, string>();
            disp.Add("CHECK_PERSON", "检验人");
            disp.Add("CHECK_DATE", "检验时间");
            disp.Add("CHECK_TITLE", "检验项目(中文)");
            disp.Add("CHECKENGLISHNAME", "检验项目(英文)");
            disp.Add("sortno", "编号");
            disp.Add("CMS_CODE", "检验项目代码");
            disp.Add("CHECK_DETAIL", "备注");
            disp.Add("PLAN_DATE", "预计检验日期");
            disp.Add("CHECK_DEPART_NAME", "检验方");
            disp.Add("RECTIFY_STATE", "整改状态");
            disp.Add("CHECK_STATE_VIEW", "检验状态");

            dgvCMSCheckLogDetailList.SetDgvGridColumns(disp);
            dgvCMSCheckLogDetailList.setDgvColumnsReadOnly(new string[] { "CHECK_PERSON", "CHECK_DATE", "CHECK_TITLE", "CHECKENGLISHNAME", "sortno",
                "CMS_CODE", "CHECK_DETAIL", "PLAN_DATE", "CHECK_DEPART_NAME", "RECTIFY_STATE", "CHECK_STATE_VIEW" });
            resetDataAndColor();        
            dgvCMSCheckLogDetailList.SetDataGridViewNoSort();
        }

        /// <summary>
        /// 窗体关闭时释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWorkOrderHistory_FormClosing(object sender, FormClosingEventArgs e)
        {
            //保存网格相关信息.
            dgvCMSCheckList.SaveGridView("FrmCMSHistory.dgvCMSCheckList");
            dgvCMSCheckLogDetailList.SaveGridView("FrmCMSHistory.dgvCMSCheckLogDetailList");
            instance = null;//释放窗体实例变量.
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

        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            loadData();
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            //当前对象打印.
            if (dgvCMSCheckList.CurrentRow != null)
            {
                string err;
                CMSCheckLog cmsCheckLog = CMSCheckLogService.Instance.getObject(dgvCMSCheckList.CurrentRow.Cells["CHECK_LOG_ID"].Value.ToString(), out err);

                OperationExcel operationExcel;
                if (!CMSCheckLogService.Instance.GetOperationExcelOfOneLog(cmsCheckLog, true, out operationExcel, out err))
                {
                    MessageBoxEx.Show("未正常获取CMS检验信息,不能打印输出,错误信息为:\r" + err);
                }
                else
                {
                    FrmOurReport frm = new FrmOurReport("CMS检验项目打印", operationExcel);
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                    operationExcel.Dispose();
                }
            }
        }

        private void ucDataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            bdsCMSCheck.DataSource = null;
            string log_id = dgvCMSCheckList.Rows[e.RowIndex].Cells["CHECK_LOG_ID"].Value.ToString();
            string err;
            CMSCheckLog checkLog = CMSCheckLogService.Instance.getObject(log_id, out err);
            if (checkLog == null || checkLog.IsWrong)
            {
                clearObject();
                return;
            }
            else
            {
                setObject(checkLog);
                DataTable dtCmsCheckDetail = CMSCheckService.Instance.GetAllItemOfOneLog(log_id);
                bdsCMSCheck.DataSource = dtCmsCheckDetail;
                dgvCMSCheckLogDetailList.DataSource = bdsCMSCheck;
                if (checkBox1.Checked)
                    bdsCMSCheck.Filter = "CHECK_STATE>2";
                else
                    bdsCMSCheck.Filter = "";
                setDataGridView();
            }
        }
        private void setObject(CMSCheckLog checkLog)
        {
            checkLog.FillThisObject();
            txtCheckName.Text = checkLog.CHECK_NAME;
            txtCheckerName.Text = checkLog.CHECK_PERSON;
            txtCheckPlace.Text = checkLog.CHECK_PLACE;
            if (checkLog.CHECK_STATE == 1) rb_plan.Checked = true;
            else if (checkLog.CHECK_STATE == 2) rb_Complete.Checked = true;
            else if (checkLog.CHECK_STATE == 3) rb_flaw.Checked = true;
            dtCheckDate.Value = checkLog.CHECK_DATE;
            dtBegin.Value = checkLog.CHECK_SPAN_BEGIN;
            dtEnd.Value = checkLog.CHECK_SPAN_END;
            txtDetail.Text = checkLog.CHECK_DETAIL;
            if (checkLog.TheShip != null)
                txtShip.Text = checkLog.TheShip.SHIP_NAME;
            else
                txtShip.Text = "";
        }
        private void clearObject()
        {
            txtCheckName.Text = "";
            txtCheckerName.Text = "";
            txtCheckPlace.Text = "";
            rb_plan.Checked = true;
            dtCheckDate.Text = "";
            dtBegin.Text = "";
            dtEnd.Text = "";
            txtDetail.Text = "";
            txtShip.Text = "";
            bdsCMSCheck.DataSource = null;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void dgvCMSCheckLogDetailList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string err;
                CMSCheck cmsCheck = CMSCheckService.Instance.getObject(dgvCMSCheckLogDetailList.Rows[e.RowIndex].Cells["CMS_CHECK_ID"].Value.ToString(), out err);
                if (cmsCheck == null || cmsCheck.IsWrong) MessageBoxEx.Show("当前选择行对象无效!");
                else
                {
                    FrmEditOneCMSCheck frm = new FrmEditOneCMSCheck(cmsCheck, false);
                    frm.ShowDialog();
                }
            }
        }

        private void FrmCMSHistory_Shown(object sender, EventArgs e)
        {
            resetDataAndColor();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            resetDataAndColor();
        }

        private void resetDataAndColor()
        {
            if (bdsCMSCheck != null)
            {
                if (checkBox1.Checked)
                    bdsCMSCheck.Filter = "CHECK_STATE>2";
                else
                    bdsCMSCheck.Filter = "";
            }
            //从头搜索到尾,如果没有整改的,用红色文字表示.
            DataGridViewCellStyle d = new DataGridViewCellStyle();
            d.ForeColor = Color.Red;
            foreach (DataGridViewRow dgvr in dgvCMSCheckLogDetailList.Rows)
            {
                if (dgvr.Cells["RECTIFY_STATE_Value"].Value.ToString() == "1")
                {
                    dgvr.DefaultCellStyle = d;
                }
            }
        }

    }
}