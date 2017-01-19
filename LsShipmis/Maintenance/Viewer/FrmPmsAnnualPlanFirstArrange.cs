/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmPmsAnnualPlanFirstArrange.cs
 * 创 建 人：王鹏程
 * 创建时间：2011-11-15
 * 标    题：工作信息调整
 * 功能描述：
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using FileOperationBase.Services;
using Maintenance.Services;
using CommonViewer.BaseControlService;
using Maintenance.DataObject;
using CommonViewer.BaseControl;

namespace Maintenance.Viewer
{
    /// <summary>
    /// 工作信息首排业务窗体.
    /// </summary>
    public partial class FrmPmsAnnualPlanFirstArrange : CommonViewer.BaseForm.FormBase
    {
        private DateTime annual;
        private WorkInfo workinfo;
        private T_WORKINFO_HISTORY_OUT workinfoHistoryOut = null;
        private string CirclePeriod = "";
        private string TimingPeriod = "";
        private DataTable dtbFirstArrangeWorkInfo = new DataTable();

        /// <summary>
        /// 构造函数.
        /// </summar>
        public FrmPmsAnnualPlanFirstArrange(WorkInfo workInfo, T_WORKINFO_HISTORY_OUT workinfoHistoryOut, DateTime annual)
        {
            InitializeComponent();
            this.workinfo = workInfo;
            this.annual = annual;
            this.workinfoHistoryOut = workinfoHistoryOut;
        }
        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPmsAnnualPlanFirstArrange_Load(object sender, EventArgs e)
        {
            this.setComboBox();                  //设置窗体所需的下拉列表框的数据源.
            this.loadData_FirstArrangeWorkInfo();//加载要首排的工作信息.
        }
        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {
            //1.用于网格的责任人岗位下拉列表.
            DataTable dtbPrincipalPostGrid = BaseInfo.DataAccess.PostService.Instance.GetLandOrShipPostList(false, false);
            FormControlOption.Instance.SetComboBoxValue(cboPrincipalPostGrid, dtbPrincipalPostGrid, 0, 3);

            //2.用于网格的确认者岗位下拉列表.
            DataTable dtbConfirmPostGrid = BaseInfo.DataAccess.PostService.Instance.GetLandOrShipPostList(false, true);
            FormControlOption.Instance.SetComboBoxValue(cboConfirmPostGrid, dtbConfirmPostGrid, 0, 3);

        }
        /// <summary>
        /// 加载要首排的工作信息.
        /// </summary>
        private void loadData_FirstArrangeWorkInfo()
        {
            //取得要首排的工作信息的DataTable对象.
            List<string> workids = new List<string>();
            workids.Add(workinfo.WORKINFOID);
            dtbFirstArrangeWorkInfo = WorkInfoService.Instance.GetFirstArrangeWorkInfo(workids);
            if (dtbFirstArrangeWorkInfo.Rows.Count == 0) return;
            DataRow curDgvRow = dtbFirstArrangeWorkInfo.Rows[0];
            //取出当前工作信息所对应的设备的最近抄表值.
            string workInfoId = dtbFirstArrangeWorkInfo.Rows[0]["workinfoid"].ToString();
            string err;
            if (workinfo == null || !workinfo.GetId().Equals(workInfoId))
            {
                workinfo = WorkInfoService.Instance.getObject(workInfoId, out err);
                if (workinfo == null || workinfo.IsWrong)
                {
                    MessageBoxEx.Show("得到当前行的工作信息对象有错,无法执行以后操作");
                    return;
                }
                workinfo.FillThisObject();
            }
            CirclePeriod = curDgvRow["circleperiod"].ToString();
            TimingPeriod = curDgvRow["timingperiod"].ToString();
            if (curDgvRow["ischeckproject"].ToString() == "1")
            {
                chkIsCheckProject.Checked = true;
            }
            else
            {
                chkIsCheckProject.Checked = false;
            }
            if (curDgvRow["isrepairproject"].ToString() == "1")
            {
                chkIsRepairProject.Checked = true;
            }
            else
            {
                chkIsRepairProject.Checked = false;
            }

            txtworkinfoname.Text = curDgvRow["workinfoname"].ToString();
            txtcircleortimingname.Text = curDgvRow["circleortimingname"].ToString();
            cboPrincipalPostGrid.SelectedText = curDgvRow["principalpostname"].ToString();
            cboConfirmPostGrid.SelectedText = curDgvRow["confirmpostname"].ToString();
            if (!string.IsNullOrEmpty(curDgvRow["planexedate"].ToString()))
                dtpPlanExeDate.Value = Convert.ToDateTime(curDgvRow["planexedate"]);
            txtnextvalue.Text = curDgvRow["nextvalue"].ToString();
            if (!string.IsNullOrEmpty(curDgvRow["GAUGE_TIME"].ToString()))
                dtpGAUGE_TIME.Value = Convert.ToDateTime(curDgvRow["GAUGE_TIME"]);
            txttotal_workhours.Text = curDgvRow["total_workhours"].ToString();
            if (string.IsNullOrEmpty(dtbFirstArrangeWorkInfo.Rows[0]["measure_report_type_name"].ToString()))
                lklWorkReport.Text = "没有报告";
            else
                lklWorkReport.Text = dtbFirstArrangeWorkInfo.Rows[0]["measure_report_type_name"].ToString();
            DataTable dt;
            if (!T_WORKINFO_HISTORY_OUTService.Instance.GetOrderExcelNum(curDgvRow["ship_id"].ToString(), annual, out dt, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            cbxOrderExcelNum.ValueMember = "EXCEL_ORDERNUM";
            cbxOrderExcelNum.DisplayMember = "ORDER_EXCEL_NUM";
            DataRow dr = dt.NewRow();
            dr[0] = "更改内部排序号";
            dr[1] = -1;
            dt.Rows.InsertAt(dr, 0);
            cbxOrderExcelNum.DataSource = dt;
            //if (string.IsNullOrEmpty(workinfoHistoryOut.WHID))
            //{
            //    int maxeon;
            //    if (!T_WORKINFO_HISTORY_OUTService.Instance.GetMaxExcelOrdernum(curDgvRow["ship_id"].ToString(), annual, out maxeon, out err))
            //    {
            //        MessageBoxEx.Show(err);
            //        return;
            //    }
            //    nudEXCEL_ORDERNUM.Value = maxeon + 1;
            //}
            //else
            //{
            //    nudEXCEL_ORDERNUM.Value = workinfoHistoryOut.EXCEL_ORDERNUM;
            //}
            if (workinfoHistoryOut.EXCEL_ORDERNUM >= 1)
                txtEXCEL_ORDERNUM.Text = workinfoHistoryOut.EXCEL_ORDERNUM.ToString();
            //cbxOrderExcelNum.SelectedValue = workinfoHistoryOut.EXCEL_ORDERNUM;
            txtORDERNUM_SHOW.Text = workinfoHistoryOut.ORDERNUM_SHOW;
            string months_check = workinfoHistoryOut.MONTHS_CHECK == null ? "" : workinfoHistoryOut.MONTHS_CHECK;
            for (int i = 1; i <= 12; i++)
            {
                CheckBox cb = (CheckBox)flowLayoutPanel2.Controls.Find("checkbox" + i, false)[0];
                cb.Checked = (months_check.Contains("{" + i + "}"));
            }
            txtEx1.Text = workinfoHistoryOut.EX1;
            this.setReadOnly();
            //设置列标题.
            //dictColumns.Clear();
            //dictColumns.Add("workinfoname", "工作信息名称");
            //dictColumns.Add("circleortimingname", "定期/定时");
            //dictColumns.Add("principalpostname", "责任人岗位");
            //dictColumns.Add("confirmpostname", "确认者岗位");
            //dictColumns.Add("planexedate", "首次执行日期");
            //dictColumns.Add("nextvalue", "首次执行表值");
            //dictColumns.Add("GAUGE_TIME", "设备最后一次抄表时间");
            //dictColumns.Add("total_workhours", "设备最后一次抄表值");
            //dictColumns.Add("measure_report_type_name", "工作报告");
            //dictColumns.Add("arrangetimes", "安排次数");
        }
        /// <summary>
        /// 根据工作信息类型设置网格dgvWorkInfo的一些单元格的只读或者非只读属性.
        /// </summary>
        private void setReadOnly()
        {
            string circleOrTiming = dtbFirstArrangeWorkInfo.Rows[0]["circleortiming"].ToString();
            if (circleOrTiming == "1")
            {
                txtnextvalue.ReadOnly = true;
            }
            else if (circleOrTiming == "2")
            {
                dtpPlanExeDate.Enabled = false;
                btnManualArrange.Enabled = false;
            }
            else if (circleOrTiming == "4")
            {
                txtnextvalue.ReadOnly = true;
                nudarrangetimes.ReadOnly = true;
            }
        }
        /// <summary>
        /// 数据校验部分.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool DataValidating(DataTable dtb)
        {
            decimal decValidata = 0;   //数值型数值校验.
            //取首次执行日期.
            string sPlanexedate = dtb.Rows[0]["planexedate"].ToString();
            //取首次执行表值.
            string sNextvalue = dtb.Rows[0]["nextvalue"].ToString();

            #region 1.前允差日期不能大于首次执行日期
            string circlefrontlimitdate = dtb.Rows[0]["circlefrontlimitdate"].ToString();
            //与前允差日期做比较.
            if (sPlanexedate != "" && circlefrontlimitdate != "")
            {
                DateTime dtCirclefrontlimitdate = DateTime.Parse(circlefrontlimitdate);
                DateTime dtPlanexedate = DateTime.Parse(sPlanexedate);
                if (dtCirclefrontlimitdate > dtPlanexedate)
                {
                    MessageBoxEx.Show("前允差日期不能大于首次执行日期！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            #endregion

            #region 2.后允差日期不能小于首次执行日期
            string circlebacklimitdate = dtb.Rows[0]["circlebacklimitdate"].ToString();
            //与前允差日期做比较.
            if (sPlanexedate != "" && circlebacklimitdate != "")
            {
                DateTime dtCirclebacklimitdate = DateTime.Parse(circlebacklimitdate);
                DateTime dtPlanexedate = DateTime.Parse(sPlanexedate);
                if (dtCirclebacklimitdate < dtPlanexedate)
                {
                    MessageBoxEx.Show("后允差日期不能小于首次执行日期！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            #endregion

            #region 3.首次执行表值必须是数值型数据
            string nextvalue = dtb.Rows[0]["nextvalue"].ToString();
            if (dtb.Rows[0]["nextvalue"] != null && !string.IsNullOrEmpty(dtb.Rows[0]["nextvalue"].ToString()))
            {
                decimal aimHours = decimal.Parse(nextvalue);
                string sTotalWorkhours = dtb.Rows[0]["total_workhours"].ToString();
                decimal totalWorkhours = 0;
                DateTime dt;
                if (sTotalWorkhours != "") totalWorkhours = decimal.Parse(sTotalWorkhours);

                decimal rate = 1;
                if (workinfo.CompUnit != null && !workinfo.CompUnit.IsWrong)
                {
                    rate = workinfo.CompUnit.USE_RATE;
                    if (rate == 0) rate = 1;
                    string dts = dtb.Rows[0]["GAUGE_TIME"].ToString();
                    if (dts != "")
                    {
                        dt = DateTime.Parse(dts);
                    }
                    else
                    {
                        MessageBoxEx.Show("由于没有发现抄表记录,当前操作无效！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                else
                {
                    MessageBoxEx.Show("由于当前工作信息没有绑定设备,无法获取抄表记录,操作无效！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (decimal.TryParse(nextvalue, out decValidata) == false)
                {
                    MessageBoxEx.Show("首次执行表值必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    if (totalWorkhours > 0 && decimal.Parse(nextvalue) <= totalWorkhours)
                    {
                        MessageBoxEx.Show("首次执行表值必须大于设备上次抄表值！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                dtb.Rows[0]["planexedate"] = dt.AddHours((int)((aimHours - totalWorkhours) / rate));
                dtb.Rows[0]["timingfrontlimithours"] = aimHours - workinfo.TIMINGFRONTLIMIT;
                dtb.Rows[0]["timingbacklimithours"] = aimHours - workinfo.TIMINGBACKLIMIT;
                dtb.Rows[0]["nextvalue"] = aimHours;
            }
            #endregion

            #region 4.前允差小时数必须是数值型数据且不能大于首次执行表值
            string timingfrontlimithours = dtb.Rows[0]["timingfrontlimithours"].ToString();
            if (timingfrontlimithours != "")
            {
                if (decimal.TryParse(timingfrontlimithours, out decValidata) == false)
                {
                    MessageBoxEx.Show("前允差小时数必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            if (sNextvalue != "" && timingfrontlimithours != "")
            {
                decimal nextValue = decimal.Parse(sNextvalue);
                decimal timingFrontLimitHours = decimal.Parse(timingfrontlimithours);
                if (timingFrontLimitHours > nextValue)
                {
                    MessageBoxEx.Show("前允差小时数不能大于首次执行表值！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            #endregion

            #region 5.后允差小时数必须是数值型数据且不能小于首次执行表值
            string timingbacklimithours = dtb.Rows[0]["timingbacklimithours"].ToString();
            if (timingbacklimithours != "")
            {
                if (decimal.TryParse(timingbacklimithours, out decValidata) == false)
                {
                    MessageBoxEx.Show("后允差小时数必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            //取首次执行表值.
            if (sNextvalue != "" && timingbacklimithours != "")
            {
                decimal nextValue = decimal.Parse(sNextvalue);
                decimal timingBackLimitHours = decimal.Parse(timingbacklimithours);
                if (timingBackLimitHours < nextValue)
                {
                    MessageBoxEx.Show("后允差小时数不能小于首次执行表值！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            #endregion
            return true;
        }
        /// <summary>
        /// 首排保存时的数据校验.
        /// </summary>
        /// <param name="dtb">包含要首排的行信息的DataTable对象</param>
        /// <returns>如果通过校验返回true，否则返回false</returns>
        private bool IsArrangeValidate(DataTable dtb)
        {
            string principalpost = "";  //责任人岗位Id
            string confirmpost = "";    //确认者岗位Id
            string circleOrTiming = ""; //定期/定时（1表示定期，2表示定时，3表示定期与定时）.
            DateTime planexedate;    //首次执行日期.
            string nextvalue = "";      //首次执行表值.
            string sArrangetimes = "";  //安排次数（字符型）.
            int arrangetimes = 0;       //安排次数（数值型）.
            DataRow curRow = dtb.Rows[0];
            principalpost = cboPrincipalPostGrid.SelectedValue.ToString();
            confirmpost = cboConfirmPostGrid.SelectedValue.ToString();
            planexedate = dtpPlanExeDate.Value;
            nextvalue = txtnextvalue.Text;
            sArrangetimes = nudarrangetimes.Value.ToString();
            arrangetimes = Convert.ToInt32(nudarrangetimes.Value);
            circleOrTiming = curRow["circleortiming"].ToString();
            if (sArrangetimes != "")
            {
                arrangetimes = int.Parse(sArrangetimes);
            }

            if (principalpost == "")
            {
                MessageBoxEx.Show("首排的工作信息必须填责任人岗位！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (confirmpost == "")
            {
                MessageBoxEx.Show("首排的工作信息必须填确认者岗位！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (circleOrTiming == "1" && planexedate == DateTime.MinValue)
            {
                MessageBoxEx.Show("当首排的工作信息是定期时必须填首次执行日期！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (circleOrTiming == "2" && nextvalue == "")
            {
                MessageBoxEx.Show("当首排的工作信息是定时时必须填首次执行表值！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (circleOrTiming == "3" && planexedate == DateTime.MinValue)
            {
                MessageBoxEx.Show("当首排的工作信息是定期和定时时必须填首次执行日期！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (circleOrTiming == "3" && nextvalue == "")
            {
                MessageBoxEx.Show("当首排的工作信息是定期和定时时必须填首次执行表值！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (circleOrTiming == "1" && arrangetimes > 1 && CirclePeriod.Trim() == "")
            {
                MessageBoxEx.Show("定期的工作信息当安排次数在2次以上时必须要有定期周期！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (circleOrTiming == "2" && arrangetimes > 1 && TimingPeriod.Trim() == "")
            {
                MessageBoxEx.Show("定时的工作信息当安排次数在2次以上时必须要有定时周期！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (circleOrTiming == "3" && arrangetimes > 1 && CirclePeriod.Trim() == "")
            {
                MessageBoxEx.Show("[定期和定时]的工作信息当安排次数在2次以上时必须要有定期周期！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (circleOrTiming == "3" && arrangetimes > 1 && TimingPeriod.Trim() == "")
            {
                MessageBoxEx.Show("[定期和定时]的工作信息当安排次数在2次以上时必须要有定时周期！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (circleOrTiming == "4" && planexedate == DateTime.MinValue)
            {
                MessageBoxEx.Show("当安排的工作信息是非周期性质时必须填首次执行日期！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }
        private void cbxOrderExcelNum_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbxOrderExcelNum.SelectedValue != null && cbxOrderExcelNum.SelectedValue.ToString() != "-1")
                txtEXCEL_ORDERNUM.Text = (Convert.ToInt32(cbxOrderExcelNum.SelectedValue) + 1).ToString();
            else
                txtEXCEL_ORDERNUM.Text = workinfoHistoryOut.EXCEL_ORDERNUM.ToString();
        }
        /// <summary>
        /// 打开工作报告.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lklWorkReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lklWorkReport.Text == "没有报告") return;
            string fileId = ""; //当前工作报告模板文档对应的大对象库的Id
            fileId = dtbFirstArrangeWorkInfo.Rows[0]["file_id"].ToString();
            if (fileId != "")
            {
                openFile ofile = new openFile();
                ourFile file = new ourFile();
                file.FileId = fileId;
                ofile.FileOpen(file, right.R);
            }
        }
        private bool CheckTableInfo()
        {
            if (string.IsNullOrEmpty(txtORDERNUM_SHOW.Text.Trim()))
            {
                MessageBoxEx.Show("序号不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtEXCEL_ORDERNUM.Text))
            {
                MessageBoxEx.Show("请选择要插入其后面的表格排序号");
                return false;
            }
            return true;
        }
        /// <summary>
        /// 保存表格方法.
        /// </summary>
        /// <returns></returns>
        private bool SaveTableInfo()
        {
            string err;
            if (!CheckTableInfo())
                return false;
            int? oldnum = null;
            if (!string.IsNullOrEmpty(workinfoHistoryOut.WHID) && workinfoHistoryOut.EXCEL_ORDERNUM!=0)
                oldnum = workinfoHistoryOut.EXCEL_ORDERNUM;
            int newnum = Convert.ToInt32(txtEXCEL_ORDERNUM.Text);
            workinfoHistoryOut.SHIP_ID = workinfo.SHIP_ID;
            workinfoHistoryOut.ANNUAL = annual;
            workinfoHistoryOut.WORKID = workinfo.WORKINFOID;
            workinfoHistoryOut.ORDERNUM_SHOW = txtORDERNUM_SHOW.Text.Trim();
            workinfoHistoryOut.EXCEL_ORDERNUM = newnum;
            workinfoHistoryOut.MONTHS_CHECK = "";
            workinfoHistoryOut.ITEMTYPE = "1";
            workinfoHistoryOut.EX1 = txtEx1.Text.Trim();
            for (int i = 1; i <= 12; i++)
            {
                CheckBox cb = (CheckBox)flowLayoutPanel2.Controls.Find("checkbox" + i, false)[0];
                if (cb.Checked)
                    workinfoHistoryOut.MONTHS_CHECK += ("{" + i + "},");
            }
            if (!string.IsNullOrEmpty(workinfoHistoryOut.MONTHS_CHECK))
                workinfoHistoryOut.MONTHS_CHECK = workinfoHistoryOut.MONTHS_CHECK.Substring(0, workinfoHistoryOut.MONTHS_CHECK.Length - 1);
            if (!workinfoHistoryOut.Update(out err))
            {
                MessageBoxEx.Show(err);
                return false;
            }
            if (!T_WORKINFO_HISTORY_OUTService.Instance.ResetExcelOrdernum(workinfo.SHIP_ID, annual, workinfoHistoryOut.WHID, oldnum, newnum, out err))
            {
                MessageBoxEx.Show(err);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 仅保存表格.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOnlySaveTable_Click(object sender, EventArgs e)
        {
            if (!SaveTableInfo())
                return;
            MessageBoxEx.Show("操作成功");
            this.Close();
        }
        /// <summary>
        /// 信息保存.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutoArrange_Click(object sender, EventArgs e)
        {
            string err = "";     //错误信息参数.

            //取所有要首排的行信息.

            if (dtbFirstArrangeWorkInfo.Rows.Count == 0)
            {
                MessageBoxEx.Show("没有任何要首排的工作信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //首排保存时的数据校验.
            if (this.IsArrangeValidate(dtbFirstArrangeWorkInfo) == false)
            {
                return;
            }
            dtbFirstArrangeWorkInfo.Rows[0]["principalpost"] = cboPrincipalPostGrid.SelectedValue.ToString();
            dtbFirstArrangeWorkInfo.Rows[0]["confirmpost"] = cboConfirmPostGrid.SelectedValue.ToString();
            if (dtpPlanExeDate.Value != DateTime.MinValue)
                dtbFirstArrangeWorkInfo.Rows[0]["planexedate"] = dtpPlanExeDate.Value;
            if (!txtnextvalue.ReadOnly && !string.IsNullOrEmpty(txtnextvalue.Text))
                dtbFirstArrangeWorkInfo.Rows[0]["nextvalue"] = Convert.ToDecimal(txtnextvalue.Text);
            dtbFirstArrangeWorkInfo.Rows[0]["arrangetimes"] = nudarrangetimes.Value;

            if (this.DataValidating(dtbFirstArrangeWorkInfo) == false)
            {
                return;
            }
            if (!SaveTableInfo())
                return;
            //更新结果报告.
            if (WorkInfoService.Instance.WorkInfoArrange(dtbFirstArrangeWorkInfo, out err))
            {
                MessageBoxEx.Show("工作信息首排成功！", "首排成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBoxEx.Show(err, "首排失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        /// <summary>
        /// 手动首排.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnManualArrange_Click(object sender, EventArgs e)
        {
            string err = "";     //错误信息参数.
            //取所有要首排的行信息.
            if (dtbFirstArrangeWorkInfo.Rows.Count == 0)
            {
                MessageBoxEx.Show("没有任何要首排的工作信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            List<int> mon = new List<int>();
            for (int i = 1; i <= 12; i++)
            {
                CheckBox cb = (CheckBox)flowLayoutPanel2.Controls.Find("checkbox" + i, false)[0];
                if (cb.Checked)
                    mon.Add(i);
            }
            if (mon.Count == 0)
            {
                MessageBoxEx.Show("手动首排必须选择月份最少一个月份");
                return;
            }
            //首排保存时的数据校验.
            if (this.IsArrangeValidate(dtbFirstArrangeWorkInfo) == false)
            {
                return;
            }
            dtbFirstArrangeWorkInfo.Rows[0]["principalpost"] = cboPrincipalPostGrid.SelectedValue.ToString();
            dtbFirstArrangeWorkInfo.Rows[0]["confirmpost"] = cboConfirmPostGrid.SelectedValue.ToString();
            if (dtpPlanExeDate.Value != DateTime.MinValue)
                dtbFirstArrangeWorkInfo.Rows[0]["planexedate"] = dtpPlanExeDate.Value;
            if (!txtnextvalue.ReadOnly && !string.IsNullOrEmpty(txtnextvalue.Text))
                dtbFirstArrangeWorkInfo.Rows[0]["nextvalue"] = Convert.ToDecimal(txtnextvalue.Text);
            dtbFirstArrangeWorkInfo.Rows[0]["arrangetimes"] = nudarrangetimes.Value;

            if (this.DataValidating(dtbFirstArrangeWorkInfo) == false)
            {
                return;
            }
            if (!SaveTableInfo())
                return;
            for (int i = 0; i < mon.Count - 1; i++)
            {
                object[] ia = dtbFirstArrangeWorkInfo.Rows[0].ItemArray;
                dtbFirstArrangeWorkInfo.Rows.Add(ia);
            }
            for (int i = 0; i < mon.Count; i++)
            {
                DateTime pd = Convert.ToDateTime(workinfoHistoryOut.ANNUAL.Year.ToString() + "-" + mon[i] + "-" + "1");
                dtbFirstArrangeWorkInfo.Rows[i]["planexedate"] = pd;
            }
            //更新结果报告.
            if (WorkInfoService.Instance.WorkInfoArrange(dtbFirstArrangeWorkInfo, out err))
            {
                MessageBoxEx.Show("工作信息首排成功！", "首排成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBoxEx.Show(err, "首排失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        /// <summary>
        /// 关闭窗体.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}