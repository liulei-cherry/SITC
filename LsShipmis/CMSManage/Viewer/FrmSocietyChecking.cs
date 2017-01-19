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
using CommonViewer;
using OfficeOperation;

namespace CMSManage.Viewer
{
    /// <summary>
    /// 工单历史信息查看窗体.
    /// </summary>
    public partial class FrmSocietyChecking : CommonViewer.BaseForm.FormBase
    {
        private string shipid = "";
        private CMSCheckLog nowLog;
        private ProxyRight proxyRight = ProxyRight.Instance;//权限代理业务类.
        private IDBOperation commonOpt = CommonOperation.Functions.InterfaceInstantiation.NewADBOperation();//定义一个公共类CommonOpt对象.
        private bool noUseNow = false;

        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmSocietyChecking instance;

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmSocietyChecking Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmSocietyChecking.instance = new FrmSocietyChecking();
                }

                return FrmSocietyChecking.instance;
            }
        }

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmSocietyChecking()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSocietyChecking_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;//窗体最大化.
            //如果有船，则自动给检验日期按照上次日期加5年.
            if (!CommonOperation.ConstParameter.IsLandVersion)
            {
                shipid = CommonOperation.ConstParameter.ShipId;
                ucShipSelect1.SelectedId(CommonOperation.ConstParameter.ShipId, false);
                addTheOtherShipData(shipid);
            }
            else
            {
                setDate(CMSCheckService.Instance.GetAllItemOfOneLog(""));
            }
        }

        private void setDate(DataTable dt)
        {
            if (dt != null)
            {
                bdsCMSCheck.DataSource = dt;
                dgvCMSWorkOrder.DataSource = bdsCMSCheck;
                setFillter();
                setDataGridView();
            }
            else
            {
                bdsCMSCheck.DataSource = null;
                dgvCMSWorkOrder.Rows.Clear();
            }
        }
        private void cbx_AllSociety_CheckedChanged(object sender, EventArgs e)
        {
            setFillter();
        }

        private void cbx_OnlyNotFinished_CheckedChanged(object sender, EventArgs e)
        {
            setFillter();
        }

        private void setFillter()
        {
            if (bdsCMSCheck != null && bdsCMSCheck.DataSource != null)
            {
                string filter = "";
                if (cbx_AllSociety.Checked)//仅显示船级社.
                {
                    filter = "CHECK_DEPART=2";
                }
                if (cbx_OnlyNotFinished.Checked)
                {
                    if (filter.Length > 0) filter = filter + " and CHECK_STATE = 1";
                    else filter = "CHECK_STATE = 1";
                }
                bdsCMSCheck.Filter = filter;
            }
        }

        /// <summary>
        /// 设置物料信息网格控件dgvMatApply的隐藏列与显示标题.
        /// </summary>
        private void setDataGridView()
        {
            dgvCMSWorkOrder.LoadGridView("FrmSocietyChecking.dgvCMSWorkOrder"); 

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

            dgvCMSWorkOrder.SetDgvGridColumns(disp, "sel");
            dgvCMSWorkOrder.setDgvColumnsReadOnly(new string[] { "CHECK_PERSON", "CHECK_DATE", "CHECK_TITLE", "CHECKENGLISHNAME", "sortno",
                "CMS_CODE", "CHECK_DETAIL", "PLAN_DATE", "CHECK_DEPART_NAME", "RECTIFY_STATE", "CHECK_STATE_VIEW" });
        }

        /// <summary>
        /// 窗体关闭时释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSocietyChecking_FormClosing(object sender, FormClosingEventArgs e)
        {
            //保存网格相关信息.
            dgvCMSWorkOrder.SaveGridView("FrmSocietyChecking.dgvCMSWorkOrder");
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

        private void btnNotOk_Click(object sender, EventArgs e)
        {
            if (txtChecker.Text.Length == 0)
            {
                OurMessageBox messagebox = new OurMessageBox("请先填写验船师姓名");
                messagebox.ShowDialog();
                if (messagebox.Answer && messagebox.AnswerTxt.Length > 0)
                {
                    txtChecker.Text = messagebox.AnswerTxt;
                    save(false);
                }
                else
                    return;
            }
            int count = 0;
            List<string> allIds = new List<string>();
            foreach (DataGridViewRow dgvr in dgvCMSWorkOrder.Rows)
            {
                if (dgvr.Cells["sel"].Value != null && (bool)dgvr.Cells["sel"].Value)
                {
                    count++;
                    allIds.Add(dgvr.Cells["CMS_CHECK_ID"].Value.ToString());
                }
            }

            //一条没有选择,则不能填写.
            if (count == 0)
            {
                MessageBoxEx.Show("未选中任何检验项目,不能对其添加统一不符合说明!");
                return;
            }
            //是否为选择的项填写统一的不符合内容.
            else
            {
                FrmCMSCheckAddFlaw frm = new FrmCMSCheckAddFlaw(nowLog, allIds);
                frm.ShowDialog();
                setDate(CMSCheckService.Instance.GetAllItemOfOneLog(nowLog.GetId()));
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (txtChecker.Text.Length == 0)
            {
                OurMessageBox messagebox = new OurMessageBox("请先填写验船师姓名");
                messagebox.ShowDialog();
                if (messagebox.Answer && messagebox.AnswerTxt.Length > 0)
                {
                    txtChecker.Text = messagebox.AnswerTxt;
                    save(false);
                }
                else
                    return;
            }
            //为所有未打标志的计划状态的数据填写完成状态,如果所有的条目均不含有缺陷,则直接为完成状态,否则为缺陷状态.
            if (MessageBoxEx.Show("是否将所有未标志为缺陷的项目全部标志为合格项目?",
                "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                string err;
                if (CMSCheckService.Instance.FinishWholeCMSCheckingProject(nowLog, out err))
                {
                    MessageBoxEx.Show("处理完毕!如有缺陷项目请尽快处理");
                    Close();
                }
                else
                {
                    MessageBoxEx.Show("处理失败!更多错误信息请参考:\r" + err);
                }
            }

        }

        private bool save(bool withMessage)
        {
            string err;

            nowLog.CHECK_NAME = txtCheckName.Text;
            nowLog.CHECK_PERSON = txtChecker.Text;
            nowLog.CHECK_PLACE = txtCheckPlace.Text;
            nowLog.CHECK_DETAIL = txtDetail.Text;
            nowLog.CHECK_DATE = dtCheckDate.Value;
            if (!nowLog.Update(out err))
            {
                MessageBoxEx.Show("保存失败，错误信息为:" + err);
                return false;
            }
            if (withMessage)
            {
                MessageBoxEx.Show("保存成功");
            }
            return true;
        }    

        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            //如果切换船舶,则所有检验明细必须删除.
            if (theSelectedObject != shipid && !string.IsNullOrEmpty(shipid.Trim()))
            {
                if (MessageBoxEx.Show("切换船舶时，所有已经形成但未保存的记录将清空，是否继续操作？\r继续操作请按【是】，取消操作请按【否】！",
                    "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    addTheOtherShipData(shipid);
                }
                else
                {
                    ucShipSelect1.SelectedId(shipid, false);
                }
            }
        }

        private void addTheOtherShipData(string shipId)
        {
            bdsCMSCheck.DataSource = null;
            txtCheckName.Tag = null;
            nowLog = CMSCheckLogService.Instance.GetLastCheckLog(shipId, 1, DateTime.Today.AddMonths(6));

            if (nowLog != null && !nowLog.IsWrong)
            {
                if (nowLog.CHECK_STATE == 1)
                {
                    txtCheckName.Tag = nowLog.GetId();
                    txtCheckName.Text = nowLog.CHECK_NAME;
                    if (nowLog.CHECK_DATE == null)
                        dtCheckDate.Value = DateTime.Today;
                    else
                        dtCheckDate.Value = nowLog.CHECK_DATE;
                    txtDetail.Text = nowLog.CHECK_DETAIL;
                    txtCheckPlace.Text = nowLog.CHECK_PLACE;
                    txtChecker.Text = nowLog.CHECK_PERSON;
                    btn_save.Enabled = true;
                    btn_NotOk.Enabled = true;
                    btn_OK.Enabled = true;
                    noUseNow = false;
                    setDate(CMSCheckService.Instance.GetAllItemOfOneLog(nowLog.GetId()));
                    return;
                }                 
            }
            MessageBoxEx.Show("未发现当前船舶近期(6个月内)有未检验完成的检验项目,无法进行下一步操作!");
            btn_NotOk.Enabled = false;
            btn_OK.Enabled = false;
            btn_save.Enabled = false;
            noUseNow = true;
        }

        private void dateTimerPickerEx1__ValueChanged(object sender, EventArgs e)
        {
            //如果时间超出当前5年，或者少于上次检验日期，则报错。.
            if (txtCheckName.Tag == null && nowLog != null && !nowLog.IsWrong && dtCheckDate.Value < nowLog.CHECK_DATE.AddDays(30)
                || dtCheckDate.Value > DateTime.Today)
            {
                MessageBoxEx.Show("不允许将检验时间填写成接近上次检验日期或超过当前日期CMS检验！");
                dtCheckDate.Value = DateTime.Today;
                return;
            }

            foreach (DataGridViewRow dgr in dgvCMSWorkOrder.Rows)
            {
                //如果是船级社检验的项目，则必须把时间更改成当前值；.
                if (dgr.Cells["CHECK_DEPART"].Value.ToString() == "2")
                {
                    dgr.Cells["PLAN_DATE"].Value = dtCheckDate.Value;
                }
            }
        }

        private void dtCheckDate_Enter(object sender, EventArgs e)
        {
            if (dgvCMSWorkOrder.Rows.Count > 0)
                dgvCMSWorkOrder.CurrentCell = dgvCMSWorkOrder.FirstDisplayedCell;
        }         

        private void dgvCMSWorkOrder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (txtChecker.Text.Length == 0)
            {
                OurMessageBox messagebox = new OurMessageBox("请先填写验船师姓名");
                messagebox.ShowDialog();
                if (messagebox.Answer && messagebox.AnswerTxt.Length > 0)
                {
                    txtChecker.Text = messagebox.AnswerTxt;
                    save(false);
                }
                else
                    return;
            }
            if (e.RowIndex >= 0)
            {
                string err;
                CMSCheck cmsCheck = CMSCheckService.Instance.getObject(dgvCMSWorkOrder.Rows[e.RowIndex].Cells["CMS_CHECK_ID"].Value.ToString(), out err);
                if (cmsCheck == null || cmsCheck.IsWrong) MessageBoxEx.Show("当前选择行对象无效!");
                else
                {
                    cmsCheck.CHECK_DATE = DateTime.Today;
                    cmsCheck.CHECK_PERSON = txtChecker.Text;
                    FrmEditOneCMSCheck frm = new FrmEditOneCMSCheck(cmsCheck, true);
                    frm.ShowDialog();
                }
            }
        }

        private void dgvCMSWorkOrder_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
         
        }

        private void buttonEx2_Click(object sender, EventArgs e)
        {
            if (nowLog == null || nowLog.IsWrong || noUseNow) return;
            bool withSelfCheckProject;
            withSelfCheckProject = !(MessageBoxEx.Show("是否仅打印船级社检验项目,过滤自检项目?", "系统提示",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes);

            OperationExcel operationExcel;
            string err;
            if (!CMSCheckLogService.Instance.GetOperationExcelOfOneLog(nowLog, withSelfCheckProject, out operationExcel, out err))
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

        private void btn_save_Click(object sender, EventArgs e)
        {
            save(true);
        }

        private void btn_selAll_Click(object sender, EventArgs e)
        {
            if (bdsCMSCheck != null && bdsCMSCheck.DataSource != null)
            { 
                foreach (DataGridViewRow dgvr in dgvCMSWorkOrder.Rows)
                {
                    dgvr.Cells["sel"].Value = true;
                }
            }
        }

        private void btn_sel_null_Click(object sender, EventArgs e)
        {
            if (bdsCMSCheck != null && bdsCMSCheck.DataSource != null)
            {
                foreach (DataGridViewRow dgvr in dgvCMSWorkOrder.Rows)
                {
                    dgvr.Cells["sel"].Value = false;
                }
            }
        }
    }
}