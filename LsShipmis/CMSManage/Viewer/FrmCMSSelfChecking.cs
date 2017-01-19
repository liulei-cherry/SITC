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
using Maintenance.Viewer;

namespace CMSManage.Viewer
{
    /// <summary>
    /// 工单历史信息查看窗体.
    /// </summary>
    public partial class FrmCMSSelfChecking : CommonViewer.BaseForm.FormBase
    {
        private ProxyRight proxyRight = ProxyRight.Instance;//权限代理业务类.

        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmCMSSelfChecking instance;

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmCMSSelfChecking Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmCMSSelfChecking.instance = new FrmCMSSelfChecking();
                }

                return FrmCMSSelfChecking.instance;
            }
        }

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmCMSSelfChecking()
        {
            InitializeComponent();
            ucShipSelect1.ChangeSelectedState(CommonOperation.ConstParameter.IsLandVersion, true);
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWorkOrderHistory_Load(object sender, EventArgs e)
        {
            retrieveData();
        }

        private void retrieveData()
        {
            //根据船舶id选择，选择时显示所有没有完工的检验项目，不根据某次检验过滤，但按照检验和检验编号排序。.
            DataTable dt = CMSCheckService.Instance.GetAllNotFinishedSelfCheckItemOfOneShip(ucShipSelect1.GetId());
            bdsCMSCheck.DataSource = dt;
            dgvCMSWorkOrder.DataSource = bdsCMSCheck;
            setDataGridView();
        }

        private void setDataGridView()
        {
            dgvCMSWorkOrder.LoadGridView("FrmCMSSelfChecking.dgvCMSWorkOrder");
            Dictionary<string, string> dgvcolumns = new Dictionary<string, string>();
            dgvcolumns.Add("CHECK_TITLE", "检验中文名称");
            dgvcolumns.Add("CMS_CODE", "检验项目代码");
            dgvcolumns.Add("CHECK_DETAIL", "检验项目内容");
            dgvcolumns.Add("PLAN_DATE", "预计检验日期");
            dgvcolumns.Add("CHECK_NAME", "CMS检验名称");
            dgvcolumns.Add("CHECKENGLISHNAME", "检验英文名称");
            dgvcolumns.Add("BANDWORKORDER", "已经关联工单");
            dgvCMSWorkOrder.SetDgvGridColumns(dgvcolumns);
            dgvCMSWorkOrder.setDgvColumnsReadOnly(new string[] { "CHECK_TITLE", "CMS_CODE", "CHECK_DETAIL", "PLAN_DATE", "CHECK_NAME", "CHECKENGLISHNAME", "BANDWORKORDER" });
        }

        /// <summary>
        /// 窗体关闭时释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWorkOrderHistory_FormClosing(object sender, FormClosingEventArgs e)
        {
            //保存网格相关信息.
            dgvCMSWorkOrder.SaveGridView("FrmCMSSelfChecking.dgvCMSWorkOrder");
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
            retrieveData();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (dgvCMSWorkOrder.CurrentRow != null &&
                MessageBoxEx.Show("是否要对选定的记录进行完工操作？", "系统提示", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                //当不绑定工单时，用正常的cms完工；.
                //当绑定工单时，用工单完工。.
                string checkId = dgvCMSWorkOrder.CurrentRow.Cells["CMS_CHECK_ID"].Value.ToString();
                string workOrderid = dgvCMSWorkOrder.CurrentRow.Cells["WORKORDER_ID"].Value.ToString();
                string err;
                WorkOrder workOrder = WorkOrderService.Instance.getObject(workOrderid, out err);
                if (workOrder != null && !workOrder.IsWrong)
                {
                    List<string> workOrderIds = new List<string>();
                    workOrderIds.Add(workOrderid);
                    FrmWorkOrderFinish frm = new FrmWorkOrderFinish(workOrderIds);
                    frm.ShowDialog();
                    workOrder = WorkOrderService.Instance.getObject(workOrderid, out err);
                    if (workOrder.WORKORDERSTATE < 4) return;
                }
                if (CMSCheckService.Instance.FinishACMSSelfCheckingProject(checkId, out err))
                {
                    MessageBoxEx.Show("成功操作！\r完工后本条数据将不再显示，需要在完工查询中查询相应记录！");
                    retrieveData();
                }
                else
                    MessageBoxEx.Show("操作失败，错误原因请参考：" + err);

            }

        }
    }
}