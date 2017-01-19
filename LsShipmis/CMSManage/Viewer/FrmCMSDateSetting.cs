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

namespace CMSManage.Viewer
{
    /// <summary>
    /// 工单历史信息查看窗体.
    /// </summary>
    public partial class FrmCMSDateSetting : CommonViewer.BaseForm.FormBase
    {
        private string shipid = "";
        private CMSCheckLog lastLog;

        private ProxyRight proxyRight = ProxyRight.Instance;//权限代理业务类.
        private IDBOperation commonOpt = CommonOperation.Functions.InterfaceInstantiation.NewADBOperation();//定义一个公共类CommonOpt对象.
        DgvBindDrop dgvBindDrop = new DgvBindDrop();
        DgvBindDrop dgvBindDrop2 = new DgvBindDrop();
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmCMSDateSetting instance;

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmCMSDateSetting Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmCMSDateSetting.instance = new FrmCMSDateSetting();
                }

                return FrmCMSDateSetting.instance;
            }
        }

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmCMSDateSetting()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWorkOrderHistory_Load(object sender, EventArgs e)
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

            this.dtCheckDate._ValueChanged += new CommonViewer.DateTimePickerEx.ValueChanged(this.dateTimerPickerEx1__ValueChanged);
            setComboBanding();
        }

        private void setDate(DataTable dt)
        {
            if (dt != null)
            {
                bdsCMSCheck.DataSource = dt;
                dgvCMSWorkOrder.DataSource = bdsCMSCheck;
                setDataGridView();
            }
            else
            {
                bdsCMSCheck.DataSource = null;
                dgvCMSWorkOrder.Rows.Clear();
            }
        }

        /// <summary>
        /// 设置物料信息网格控件dgvMatApply的隐藏列与显示标题.
        /// </summary>
        private void setDataGridView()
        {
            dgvCMSWorkOrder.LoadGridView("FrmCMSDateSetting.dgvCMSWorkOrder");
            Dictionary<string, string> disp = new Dictionary<string, string>();
            disp.Add("CHECK_TITLE", "检验项目(中文)");
            disp.Add("CHECKENGLISHNAME", "检验项目(英文)");
            disp.Add("sortno", "编号");
            disp.Add("CMS_CODE", "检验项目代码");
            disp.Add("CHECK_DETAIL", "备注");
            disp.Add("PLAN_DATE", "预计检验日期");
            disp.Add("CHECK_DEPART_NAME", "检验方");
            disp.Add("BANDWORKINFO", "可关联工单");
            dgvCMSWorkOrder.SetDgvGridColumns(disp, "sel");
            dgvCMSWorkOrder.setDgvColumnsReadOnly(new string[] { "CHECK_TITLE", "CHECKENGLISHNAME", "sortno", "CMS_CODE", "BANDWORKINFO" });

        }

        private void setComboBanding()
        {
            //把入库方式下拉列表绑定到网格控件dgvMatInDetail上.
            //cboWhoCheck .SelectedIndex 
            DataTable dt = new DataTable();
            dt.Columns.Add("CHECK_DEPART");
            dt.Columns.Add("CHECK_DEPART_NAME");
            DataRow dr = dt.NewRow();
            dr[0] = 1;
            dr[1] = "轮机长";
            dt.Rows.Add(dr);
            DataRow dr1 = dt.NewRow();
            dr1[0] = 2;
            dr1[1] = "船级社";
            dt.Rows.Add(dr1);
            ComboBox cmbox = new ComboBox();
            cmbox.DataSource = dt;
            cmbox.DisplayMember = "CHECK_DEPART_NAME";
            cmbox.ValueMember = "CHECK_DEPART";
            cmbox.Visible = false;

            dgvBindDrop.bindDropToDgv(dgvCMSWorkOrder, cmbox, "CHECK_DEPART_NAME", "CHECK_DEPART", false, 1);
            dgvBindDrop2.bindDropToDgv(dgvCMSWorkOrder, dateTimePicker1, "PLAN_DATE");

        }
        /// <summary>
        /// 窗体关闭时释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWorkOrderHistory_FormClosing(object sender, FormClosingEventArgs e)
        {
            //保存网格相关信息.
            dgvCMSWorkOrder.SaveGridView("FrmCMSDateSetting.dgvCMSWorkOrder");
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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string err;
            if (!beforeSaveChecking(out err))
            {
                MessageBox.Show(err);
                return;
            }
            //检验日期,船舶,检验名称必须填写,
            if (dgvCMSWorkOrder.Rows.Count > 0)
            {
                if (MessageBoxEx.Show("形成明细项时，所有已经形成的记录将清空，是否继续操作？\r继续操作请按【是】，取消操作请按【否】！",
                    "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    bdsCMSCheck.DataSource = null;
                }
                else
                    return;
            }
            CMSCheckLog cmsCheckLog;
            if (saveMainData(out cmsCheckLog, out err))
            {
                setDate(CMSCheckService.Instance.SetNewItemOfOneLog(cmsCheckLog));
            }
            else
            {
                MessageBoxEx.Show("产生数据失败，错误信息为：" + err);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save(true);
        }
        private bool beforeSaveChecking(out string err)
        {
            err = "";
            if (string.IsNullOrEmpty(dtCheckDate.Text) || string.IsNullOrEmpty(txtCheckName.Text) || string.IsNullOrEmpty(shipid)
                 || string.IsNullOrEmpty(dtBegin.Text) || string.IsNullOrEmpty(dtEnd.Text))
            {
                err = "检验名称，检验日期，检验船舶,自检开始及结束日期,均是必填项，不允许为空！";
                return false;
            }
            return true;
        }
        private bool save(bool withMessage)
        {
            string err;
            CMSCheckLog cmsCheckLog;
            if (!beforeSaveChecking(out err))
            {
                MessageBoxEx.Show(err);
                return false;
            }
            if (saveMainData(out cmsCheckLog, out err) && saveDetails(out err))
            {
                if (withMessage)
                {
                    MessageBoxEx.Show("保存成功");
                }
                return true;
            }
            else
            {
                MessageBoxEx.Show("保存失败，错误信息为:" + err);
                return false;
            }
        }
        private bool saveMainData(out CMSCheckLog cmsCheckLog, out string err)
        {
            cmsCheckLog = new CMSCheckLog((txtCheckName.Tag == null ? "" : txtCheckName.Tag.ToString()), txtCheckName.Text, dtCheckDate.Value, "", txtCheckPlace.Text,
               "", dtBegin.Value, dtEnd.Value, shipid, 1);
            if (null != txtCheckName.Tag) cmsCheckLog.CHECK_LOG_ID = txtCheckName.Tag.ToString();
            if (!cmsCheckLog.Update(out err))
            {
                MessageBoxEx.Show("无法保存当前检测信息，不能为其生成明细记录。更多错误请参考：\r" + err);
                return false;
            }
            lastLog = cmsCheckLog;
            txtCheckName.Tag = cmsCheckLog.GetId();
            return true;
        }

        private bool saveDetails(out string err)
        {
            //从第一个开始，所有的id赋值.
            bdsCMSCheck.EndEdit();
            dgvCMSWorkOrder.EndEdit();
            err = "";
            if (dgvCMSWorkOrder.Rows.Count == 0) return true;
            //***************数据保存*****************************************************************************
            DataTable dtb = (DataTable)bdsCMSCheck.DataSource;//从BindingSource组件中取得信息集放到DataTable中去.
            return commonOpt.SaveFormData(dtb, "T_CMS_CHECK", 0, out err);//保存数据.
        }

        private void btn_BandingWorkinfo_Click(object sender, EventArgs e)
        {
            //当前行，有效，有工作信息，有安排时间；.
            if (dgvCMSWorkOrder.CurrentRow != null)
            {
                if (dgvCMSWorkOrder.CurrentRow.Cells["WORKORDER_ID"].Value.ToString().Length > 0)
                {
                    MessageBoxEx.Show("已经关联了工单，不能再次关联");
                    return;
                }
                CMSConfig oneConfig = CMSConfigService.Instance.GetConfigByShipAndCMSCode(shipid, dgvCMSWorkOrder.CurrentRow.Cells["CMS_CODE"].Value.ToString());

                if (oneConfig != null && !string.IsNullOrEmpty(oneConfig.WORKINFOID))
                {
                    string err;
                    WorkInfo workInfo = WorkInfoService.Instance.getObject(oneConfig.WORKINFOID, out err);
                    if (workInfo != null && !workInfo.IsWrong)
                    {
                        WorkOrder workOrder;
                        if (WorkOrderService.Instance.GetOrCreateWorkOrderByWorkInfoAndTime(workInfo,
                            (DateTime)dgvCMSWorkOrder.CurrentRow.Cells["PLAN_DATE"].Value, out workOrder, out err))
                        {
                            dgvCMSWorkOrder.CurrentRow.Cells["WORKORDER_ID"].Value = workOrder.GetId();
                            if (workOrder.WORKORDERSTATE > 5)
                            {
                                dgvCMSWorkOrder.CurrentRow.Cells["CHECK_STATE"].Value = 2;
                                dgvCMSWorkOrder.CurrentRow.Cells["CHECK_DATE"].Value = workOrder.COMPLETEDDATE;
                            }
                            if (save(false))
                            {
                                MessageBoxEx.Show("关联成功！");
                                dgvCMSWorkOrder.CurrentRow.Cells["BANDWORKORDER"].Value = "Yes";
                                return;
                            }
                            else
                            {
                                //MessageBoxEx.Show("关联失败！");本来会提示一个保存失败，.
                                return;
                            }
                        }
                    }
                }
                MessageBoxEx.Show("不能为未关联工作信息的CMS检验项目关联工单");
                return;
            }
            else
            {
                MessageBoxEx.Show("未选择任何行");
            }
        }

        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            //如果切换船舶,则所有检验明细必须删除.
            if (theSelectedObject != shipid && !string.IsNullOrEmpty(shipid.Trim()))
            {
                if (MessageBoxEx.Show("切换船舶时，所有已经形成但未保存的记录将清空，是否继续操作？\r继续操作请按【是】，取消操作请按【否】！",
                    "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    shipid = theSelectedObject;
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

            lastLog = CMSCheckLogService.Instance.GetLastCheckLog(shipId);
            if (lastLog != null && !lastLog.IsWrong)
            {
                if (lastLog.CHECK_STATE == 1)
                {
                    txtCheckName.Tag = lastLog.GetId();
                    txtCheckName.Text = lastLog.CHECK_NAME;
                    dtCheckDate.Value = lastLog.CHECK_DATE;
                    dtBegin.Value = lastLog.CHECK_SPAN_BEGIN;
                    dtEnd.Value = lastLog.CHECK_SPAN_END;
                    txtDetail.Text = lastLog.CHECK_DETAIL;
                    txtCheckPlace.Text = lastLog.CHECK_PLACE;

                    setDate(CMSCheckService.Instance.GetAllItemOfOneLog(lastLog.GetId()));
                }
                else
                {
                    txtCheckName.Text = "";
                    dtCheckDate.Value = lastLog.CHECK_DATE.AddYears(5);
                    dtBegin.Value = lastLog.CHECK_DATE.AddDays(1);
                    dtEnd.Value = dtCheckDate.Value;
                    txtDetail.Text = "";
                    txtCheckPlace.Text = "";
                    setDate(CMSCheckService.Instance.GetAllItemOfOneLog(""));
                }
            }
            else
            {
                txtCheckName.Text = "";
                dtCheckDate.Text = "";
                dtBegin.Text = "";
                dtEnd.Text = "";
                txtDetail.Text = "";
                txtCheckPlace.Text = "";
            }
        }
        private void dateTimerPickerEx1__ValueChanged(object sender, EventArgs e)
        {
            //如果时间超出当前5年，或者少于上次检验日期，则报错。.
            if (txtCheckName.Tag == null && lastLog != null && !lastLog.IsWrong && dtCheckDate.Value < lastLog.CHECK_DATE.AddDays(30)
                || dtCheckDate.Value > DateTime.Today.AddYears(6))
            {
                MessageBoxEx.Show("不允许添加时间接近上次检验日期或超过当前日期6年以上的CMS检验！");
                dtCheckDate.Text = "";
                return;
            }
            if (txtCheckName.Tag == null && lastLog != null && !lastLog.IsWrong)
            {
                dtBegin.Value = lastLog.CHECK_DATE.AddDays(1);
            }
            dtEnd.Value = dtCheckDate.Value;

            foreach (DataGridViewRow dgr in dgvCMSWorkOrder.Rows)
            {
                //如果是船级社检验的项目，则必须把时间更改成当前值；.
                if (dgr.Cells["CHECK_DEPART"].Value.ToString() == "2")
                {
                    dgr.Cells["PLAN_DATE"].Value = dtCheckDate.Value;
                }
            }
        }

        private void btnGunter_Click(object sender, EventArgs e)
        {
            if (!save(false)) return;
            FrmSetSelfCheckItems frm = new FrmSetSelfCheckItems(lastLog);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            setDate(CMSCheckService.Instance.GetAllItemOfOneLog(lastLog.GetId()));
        }

        private void dtCheckDate_Enter(object sender, EventArgs e)
        {
            if (dgvCMSWorkOrder.Rows.Count > 0)
                dgvCMSWorkOrder.CurrentCell = dgvCMSWorkOrder.FirstDisplayedCell;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            dt_other.Enabled = radioButton3.Checked;
        }

        private void dt_other_ValueChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked && (dt_other.Value < lastLog.CHECK_SPAN_BEGIN || dt_other.Value > lastLog.CHECK_SPAN_END))
            {
                MessageBoxEx.Show("轮机长自检日期应该在特检周期之内!");
                dt_other.Value = lastLog.CHECK_SPAN_END.AddMonths(-30);
            }
        }

        private void btn_selAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvr in dgvCMSWorkOrder.Rows)
            {
                dgvr.Cells["sel"].Value = true;
            }
        }

        private void btn_sel_null_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvr in dgvCMSWorkOrder.Rows)
            {
                dgvr.Cells["sel"].Value = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lastLog == null || lastLog.IsWrong)
            {
                return;
            }
            string who = "轮机长";
            int iwho = 1;
            DateTime when = lastLog.CHECK_SPAN_END;
            if (radioButton2.Checked)
            {
                who = "船级社";
                iwho = 2;
            }
            if (radioButton1.Checked) when = lastLog.CHECK_SPAN_END.AddMonths(-30);
            else if (radioButton3.Checked) when = dt_other.Value.Date;

            foreach (DataGridViewRow dgvr in dgvCMSWorkOrder.Rows)
            {
                if (dgvr.Cells["sel"].Value != null && (bool)dgvr.Cells["sel"].Value == true)
                {
                    dgvr.Cells["CHECK_DEPART_NAME"].Value = who;
                    dgvr.Cells["CHECK_DEPART"].Value = iwho;
                    dgvr.Cells["PLAN_DATE"].Value = when;
                }
            }
            save(false);
        }
    }
}