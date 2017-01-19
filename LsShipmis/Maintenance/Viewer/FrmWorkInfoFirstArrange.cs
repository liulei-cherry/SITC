/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmWorkInfoFirstArrange.cs
 * 创 建 人：李景育
 * 创建时间：2009-05-15
 * 标    题：工作信息首排业务窗体
 * 功能描述：实现工作信息首排业务功能
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms; 
using FileOperationBase.Services; 
using CommonViewer.BaseForm;
using Maintenance.Services;
using CommonViewer.BaseControlService;
using Maintenance.DataObject;
using ItemsManage.Services;
using ItemsManage.DataObject;
using CommonViewer.BaseControl;

namespace Maintenance.Viewer
{
    /// <summary>
    /// 工作信息首排业务窗体.
    /// </summary>
    public partial class FrmWorkInfoFirstArrange : CommonViewer.BaseForm.FormBase
    { 

        /// <summary>
        /// 存放列与列标题的集合.
        /// </summary>
        private Dictionary<string, string> dictColumns = new Dictionary<string, string>();
 
        /// <summary>
        /// 要首排的工作信息Id组成的List集合.
        /// </summary>
        private List<string> lstWorkInfoIds = null;
        private WorkInfo workinfo;
        /// <summary>
        /// 构造函数.
        /// </summar>
        /// <param name="lstWorkInfoIds">要合并的工作信息Id组成的List集合</param>
        public FrmWorkInfoFirstArrange(List<string> lstWorkInfoIds)
        {
            InitializeComponent();
            this.lstWorkInfoIds = lstWorkInfoIds;
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWorkInfoFirstArrange_Load(object sender, EventArgs e)
        {         
            this.setComboBox();                  //设置窗体所需的下拉列表框的数据源.
            this.loadData_FirstArrangeWorkInfo();//加载要首排的工作信息.

            //加载网格控件默认的列宽信息.
            dgvWorkInfo.LoadGridView("FrmWorkInfoFirstArrange.dgvWorkInfo");
        }

        /// <summary>
        ///  当窗体启动后根据工作信息类型设置网格dgvWorkInfo的一些单元格的只读或者非只读属性.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWorkInfoFirstArrange_Shown(object sender, EventArgs e)
        {
            this.dgvWorkInfo.ReadOnly = false;
        }     

        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        { 
            //1.用于网格的责任人岗位下拉列表.
            DataTable dtbPrincipalPostGrid = BaseInfo.DataAccess.PostService.Instance.GetLandOrShipPostList(false, false);
            FormControlOption.Instance.SetComboBoxValue(cboPrincipalPostGrid, dtbPrincipalPostGrid,0,3);
            DgvBindDrop dgvBindDrop1 = new DgvBindDrop();
            dgvBindDrop1.bindDropToDgv(dgvWorkInfo, cboPrincipalPostGrid, 6, false, 1);

            //2.用于网格的确认者岗位下拉列表.
            DataTable dtbConfirmPostGrid = BaseInfo.DataAccess.PostService.Instance.GetLandOrShipPostList(false, true);
            FormControlOption.Instance.SetComboBoxValue(cboConfirmPostGrid, dtbConfirmPostGrid,0,3);
            DgvBindDrop dgvBindDrop2 = new DgvBindDrop();
            dgvBindDrop2.bindDropToDgv(dgvWorkInfo, cboConfirmPostGrid, 8, false, 1);

            //8.在网格dgvWorkInfo绑定计划执行时间.
            DgvBindDrop dgvBindDrop3 = new DgvBindDrop();
            dgvBindDrop3.bindDropToDgv(dgvWorkInfo, dtpPlanExeDate, 9); 
        }

        /// <summary>
        /// 加载要首排的工作信息.
        /// </summary>
        private void loadData_FirstArrangeWorkInfo()
        {
            //取得要首排的工作信息的DataTable对象.
            DataTable dtbFirstArrangeWorkInfo = WorkInfoService.Instance.GetFirstArrangeWorkInfo(lstWorkInfoIds);
            bdsFirstArrangeWorkInfo.DataSource = dtbFirstArrangeWorkInfo;
            dgvWorkInfo.DataSource = bdsFirstArrangeWorkInfo;

            //设置列标题.
            dictColumns.Clear();
            dictColumns.Add("workinfoname", "工作信息名称");
            dictColumns.Add("circleortimingname", "定期/定时");
            dictColumns.Add("principalpostname", "责任人岗位");
            dictColumns.Add("confirmpostname", "确认者岗位");
            dictColumns.Add("planexedate", "首次执行日期");
            dictColumns.Add("nextvalue", "首次执行表值");
            dictColumns.Add("GAUGE_TIME", "设备最后一次抄表时间");
            dictColumns.Add("total_workhours", "设备最后一次抄表值");          
            dictColumns.Add("measure_report_type_name", "工作报告");
            dictColumns.Add("arrangetimes", "安排次数");
            dgvWorkInfo.SetDgvGridColumns(dictColumns);

            dgvWorkInfo.Columns["nextvalue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvWorkInfo.Columns["planexedate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvWorkInfo.Columns["total_workhours"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvWorkInfo.Columns["arrangetimes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvWorkInfo.Columns["total_workhours"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvWorkInfo.Columns["nextvalue"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvWorkInfo.Columns["measure_report_type_name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvWorkInfo.Columns["arrangetimes"].SortMode = DataGridViewColumnSortMode.NotSortable;
 
            this.setDgvReadOnly();
            if (this.dgvWorkInfo.Rows.Count > 0)
                this.dgvWorkInfo.Rows[0].Cells["workinfoname"].Selected = true;
        }

        /// <summary>
        /// 当网格行变化时显示当前行的信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvWorkInfo_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow curDgvRow = dgvWorkInfo.Rows[e.RowIndex];
            //取出当前工作信息所对应的设备的最近抄表值.
            string workInfoId = dgvWorkInfo.Rows[e.RowIndex].Cells["workinfoid"].Value.ToString();
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
            this.txtCirclePeriod.Text = curDgvRow.Cells["circleperiod"].Value.ToString();
            this.txtCircleUnit.Text = curDgvRow.Cells["circleunitname"].Value.ToString(); ;
            this.txtCircleFrontLimit.Text = curDgvRow.Cells["circlefrontlimit"].Value.ToString();
            this.txtCircleBackLimit.Text = curDgvRow.Cells["circlebacklimit"].Value.ToString();
            this.txtCircleLimitUnit.Text = curDgvRow.Cells["circlelimitunit"].Value.ToString();
            this.txtTimingPeriod.Text = curDgvRow.Cells["timingperiod"].Value.ToString();
            this.txtTimingFrontLimit.Text = curDgvRow.Cells["timingfrontlimit"].Value.ToString();
            this.txtTimingBackLimit.Text = curDgvRow.Cells["timingbacklimit"].Value.ToString(); 
            if (curDgvRow.Cells["ischeckproject"].Value.ToString() == "1")
            {
                chkIsCheckProject.Checked = true;
            }
            else
            {
                chkIsCheckProject.Checked = false;
            }
            if (curDgvRow.Cells["isrepairproject"].Value.ToString() == "1")
            {
                chkIsRepairProject.Checked = true;
            }
            else
            {
                chkIsRepairProject.Checked = false;
            }
            txtWorkInfoDetail.Text = curDgvRow.Cells["workinfodetail"].Value.ToString();
            txtWorkDescription.Text = curDgvRow.Cells["workdescription"].Value.ToString();
        }

        /// <summary>
        /// 打开工作报告.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvWorkInfo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string colName = "";//当前单元格所在的列名.
            string fileId = ""; //当前工作报告模板文档对应的大对象库的Id

            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                colName = dgvWorkInfo.Columns[e.ColumnIndex].Name;

                if (colName == "measure_report_type_name")
                {
                    fileId = dgvWorkInfo.Rows[e.RowIndex].Cells["file_id"].Value.ToString();

                    if (fileId != "")
                    {
                        openFile ofile = new openFile();
                        ourFile file = new ourFile();
                        file.FileId = fileId;
                        ofile.FileOpen(file, right.R);
                    }
                }
            }
        }

        /// <summary>
        /// 当工单补充说明文本框值变化时，把该值赋给网格dgvWorkInfo当前行的workdescription字段.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtWorkDescription_TextChanged(object sender, EventArgs e)
        {
            if (dgvWorkInfo.CurrentRow == null) return;
            dgvWorkInfo.CurrentRow.Cells["workdescription"].Value = txtWorkDescription.Text;
        }

        /// <summary>
        /// 网格校验部分.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvWorkInfo_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string colName = "";        //当前单元格所在的列名.
            string curValue = "";       //当前单元格的值.
            decimal decValidata = 0;   //数值型数值校验.

            colName = dgvWorkInfo.Columns[e.ColumnIndex].Name;
            curValue = e.FormattedValue.ToString().Trim();

            //1.前允差日期不能大于首次执行日期.
            if (colName == "circlefrontlimitdate")
            {
                //取首次执行日期.
                string sPlanexedate = dgvWorkInfo.Rows[e.RowIndex].Cells["planexedate"].Value.ToString();

                //与前允差日期做比较.
                if (sPlanexedate != "" && curValue != "")
                {
                    DateTime dtCirclefrontlimitdate = DateTime.Parse(curValue);
                    DateTime dtPlanexedate = DateTime.Parse(sPlanexedate);
                    if (dtCirclefrontlimitdate > dtPlanexedate)
                    {
                        MessageBoxEx.Show("前允差日期不能大于首次执行日期！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                        return;
                    }
                }
            }

            //2.后允差日期不能小于首次执行日期.
            if (colName == "circlebacklimitdate")
            {
                //取首次执行日期.
                string sPlanexedate = dgvWorkInfo.Rows[e.RowIndex].Cells["planexedate"].Value.ToString();

                //与前允差日期做比较.
                if (sPlanexedate != "" && curValue != "")
                {
                    DateTime dtCirclebacklimitdate = DateTime.Parse(curValue);
                    DateTime dtPlanexedate = DateTime.Parse(sPlanexedate);
                    if (dtCirclebacklimitdate < dtPlanexedate)
                    {
                        MessageBoxEx.Show("后允差日期不能小于首次执行日期！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                        return;
                    }
                }
            }

            //3.首次执行表值必须是数值型数据.
            if (colName == "nextvalue")
            {
                if (curValue != "")
                {                  
                    decimal aimHours = decimal.Parse(curValue);
                    string sTotalWorkhours = dgvWorkInfo.Rows[e.RowIndex].Cells["total_workhours"].Value.ToString();
                    decimal totalWorkhours = 0;                    
                    DateTime dt;
                    if (sTotalWorkhours != "") totalWorkhours = decimal.Parse(sTotalWorkhours);

                    decimal rate = 1;
                    if (workinfo.CompUnit != null && !workinfo.CompUnit.IsWrong)
                    {
                        rate = workinfo.CompUnit.USE_RATE;
                        if (rate == 0) rate = 1;
                        string dts = dgvWorkInfo.Rows[e.RowIndex].Cells["GAUGE_TIME"].Value.ToString();
                        if (dts != "")
                        {
                            dt = DateTime.Parse(dts); 
                        }
                        else
                        {
                            MessageBoxEx.Show("由于没有发现抄表记录,当前操作无效！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            e.Cancel = true;
                            return;
                        }
                    }
                     else
                        {
                            MessageBoxEx.Show("由于当前工作信息没有绑定设备,无法获取抄表记录,操作无效！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            e.Cancel = true;
                            return;
                        }
                    if (decimal.TryParse(curValue, out decValidata) == false)
                    {
                        MessageBoxEx.Show("首次执行表值必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                        return;
                    }
                    else
                    {
                        if (totalWorkhours > 0 && decimal.Parse(curValue) <= totalWorkhours)
                        {
                            MessageBoxEx.Show("首次执行表值必须大于设备上次抄表值！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            e.Cancel = true;
                            return;
                        }
                    }                     
                    dgvWorkInfo.Rows[e.RowIndex].Cells["planexedate"].Value =  dt.AddHours( (int)((aimHours - totalWorkhours) / rate));
                    dgvWorkInfo.Rows[e.RowIndex].Cells["timingfrontlimithours"].Value = aimHours - workinfo.TIMINGFRONTLIMIT;
                    dgvWorkInfo.Rows[e.RowIndex].Cells["timingbacklimithours"].Value = aimHours - workinfo.TIMINGBACKLIMIT;
                    dgvWorkInfo.Rows[e.RowIndex].Cells["nextvalue"].Value = aimHours;
                }
                return;
            }

            //4.前允差小时数必须是数值型数据且不能大于首次执行表值.
            if (colName == "timingfrontlimithours")
            {
                if (curValue != "")
                {
                    if (decimal.TryParse(curValue, out decValidata) == false)
                    {
                        MessageBoxEx.Show("前允差小时数必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                        return;
                    }
                }

                //取首次执行表值.
                string sNextvalue = dgvWorkInfo.Rows[e.RowIndex].Cells["nextvalue"].Value.ToString();
                if (sNextvalue != "" && curValue != "")
                {
                    decimal nextValue = decimal.Parse(sNextvalue);
                    decimal timingFrontLimitHours = decimal.Parse(curValue);
                    if (timingFrontLimitHours > nextValue)
                    {
                        MessageBoxEx.Show("前允差小时数不能大于首次执行表值！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                        return; 
                    }
                }
            }

            //5.后允差小时数必须是数值型数据且不能小于首次执行表值.
            if (colName == "timingbacklimithours")
            {
                if (curValue != "")
                {
                    if (decimal.TryParse(curValue, out decValidata) == false)
                    {
                        MessageBoxEx.Show("后允差小时数必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                        return;
                    }
                }

                //取首次执行表值.
                string sNextvalue = dgvWorkInfo.Rows[e.RowIndex].Cells["nextvalue"].Value.ToString();
                if (sNextvalue != "" && curValue != "")
                {
                    decimal nextValue = decimal.Parse(sNextvalue);
                    decimal timingBackLimitHours = decimal.Parse(curValue);
                    if (timingBackLimitHours < nextValue)
                    {
                        MessageBoxEx.Show("后允差小时数不能小于首次执行表值！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                        return;
                    }
                }
            }

            //6.安排次数必须是数值型数据.
            if (colName == "arrangetimes")
            {
                if (curValue != "")
                {
                    if (decimal.TryParse(curValue, out decValidata) == false)
                    {
                        MessageBoxEx.Show("安排次数必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                        return;
                    }

                    if (decimal.Parse(curValue) <= 0)
                    {
                        MessageBoxEx.Show("安排次数必须大于0，未填写则默认为1次！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 窗体关闭时保存网格列信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWorkInfoFirstArrange_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvWorkInfo.SaveGridView("FrmWorkInfoFirstArrange.dgvWorkInfo");
        }

        /// <summary>
        /// 当网格dgvWorkInfo行排序时设置其单元格的只读与非只读属性.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvWorkInfo_Sorted(object sender, EventArgs e)
        {
            this.setDgvReadOnly();
        }

        /// <summary>
        /// 当单击工具条上的按钮时网格dgvWorkInfo必须通过数据校验.
        /// 通过把控件cboCircleOrTiming设置为当前焦点的方式来实现，如果网格未通过数据校验那么就无法移动焦点.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgMain_Click(object sender, EventArgs e)
        {
            txtCirclePeriod.Select();
        }

        /// <summary>
        /// 信息保存.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgSaveItem_Click(object sender, EventArgs e)
        {
            string err = "";     //错误信息参数.

            dgvWorkInfo.EndEdit();

            //取所有要首排的行信息.
            BindingSource bds = (BindingSource)dgvWorkInfo.DataSource;
            DataTable dtb = (DataTable)bds.DataSource;

            if (dtb.Rows.Count == 0)
            {
                MessageBoxEx.Show("没有选择任何要首排的工作信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //首排保存时的数据校验.
            if (this.IsArrangeValidate(dtb) == false)
            {
                return;
            } 

            //更新结果报告.
            if (WorkInfoService.Instance.WorkInfoArrange(dtb, out err))
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
        /// 首排保存时的数据校验.
        /// </summary>
        /// <param name="dtb">包含要首排的行信息的DataTable对象</param>
        /// <returns>如果通过校验返回true，否则返回false</returns>
        private bool IsArrangeValidate(DataTable dtb)
        {
            string principalpost = "";  //责任人岗位Id
            string confirmpost = "";    //确认者岗位Id
            string circleOrTiming = ""; //定期/定时（1表示定期，2表示定时，3表示定期与定时）.
            string planexedate = "";    //首次执行日期.
            string nextvalue = "";      //首次执行表值.
            string sArrangetimes = "";  //安排次数（字符型）.
            int arrangetimes = 0;       //安排次数（数值型）.

            foreach (DataRow curRow in dtb.Rows)
            {
                principalpost = curRow["principalpost"].ToString();
                confirmpost = curRow["confirmpost"].ToString();
                circleOrTiming = curRow["circleortiming"].ToString();
                planexedate = curRow["planexedate"].ToString();
                nextvalue = curRow["nextvalue"].ToString();
                sArrangetimes = curRow["arrangetimes"].ToString();
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

                if (circleOrTiming == "1" && planexedate == "")
                {
                    MessageBoxEx.Show("当首排的工作信息是定期时必须填首次执行日期！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (circleOrTiming == "2" && nextvalue == "")
                {
                    MessageBoxEx.Show("当首排的工作信息是定时时必须填首次执行表值！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (circleOrTiming == "3" && planexedate == "")
                {
                    MessageBoxEx.Show("当首排的工作信息是定期和定时时必须填首次执行日期！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (circleOrTiming == "3" && nextvalue == "")
                {
                    MessageBoxEx.Show("当首排的工作信息是定期和定时时必须填首次执行表值！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (circleOrTiming == "1" && arrangetimes > 1 && txtCirclePeriod.Text.Trim() == "")
                {
                    MessageBoxEx.Show("定期的工作信息当安排次数在2次以上时必须要有定期周期！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (circleOrTiming == "2" && arrangetimes > 1 && txtTimingPeriod.Text.Trim() == "")
                {
                    MessageBoxEx.Show("定时的工作信息当安排次数在2次以上时必须要有定时周期！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (circleOrTiming == "3" && arrangetimes > 1 && txtCirclePeriod.Text.Trim() == "")
                {
                    MessageBoxEx.Show("[定期和定时]的工作信息当安排次数在2次以上时必须要有定期周期！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (circleOrTiming == "3" && arrangetimes > 1 && txtTimingPeriod.Text.Trim() == "")
                {
                    MessageBoxEx.Show("[定期和定时]的工作信息当安排次数在2次以上时必须要有定时周期！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (circleOrTiming == "4" && planexedate == "")
                {
                    MessageBoxEx.Show("当安排的工作信息是非周期性质时必须填首次执行日期！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            return true;
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

        /// <summary>
        /// 根据工作信息类型设置网格dgvWorkInfo的一些单元格的只读或者非只读属性.
        /// </summary>
        private void setDgvReadOnly()
        {
            foreach (DataGridViewRow dgvRow in dgvWorkInfo.Rows)
            {
                string circleOrTiming = dgvRow.Cells["circleortiming"].Value.ToString();

                dgvRow.Cells["workinfoname"].ReadOnly = true;
                dgvRow.Cells["workinfoname"].Style.BackColor = Color.Linen;
                dgvRow.Cells["circleortimingname"].ReadOnly = true;
                dgvRow.Cells["circleortimingname"].Style.BackColor = Color.Linen;
                dgvRow.Cells["total_workhours"].ReadOnly = true;
                dgvRow.Cells["total_workhours"].Style.BackColor = Color.Linen;
                dgvRow.Cells["GAUGE_TIME"].ReadOnly = true;
                dgvRow.Cells["GAUGE_TIME"].Style.BackColor = Color.Linen;
                
                dgvRow.Cells["measure_report_type_name"].Style.Font = new Font("宋体", 9, FontStyle.Underline);
                dgvRow.Cells["measure_report_type_name"].Style.ForeColor = Color.Blue;
                dgvRow.Cells["measure_report_type_name"].ReadOnly = true;
                dgvRow.Cells["measure_report_type_name"].Style.BackColor = Color.Linen;

                if (circleOrTiming == "1")
                {
                    //dgvRow.Cells["circlefrontlimitdate"].ReadOnly = false;
                    //dgvRow.Cells["circlebacklimitdate"].ReadOnly = false;
                    dgvRow.Cells["nextvalue"].ReadOnly = true;
                    //dgvRow.Cells["timingfrontlimithours"].ReadOnly = true;
                    //dgvRow.Cells["timingbacklimithours"].ReadOnly = true;
                    //dgvRow.Cells["circlefrontlimitdate"].Style.BackColor = Color.White;
                    //dgvRow.Cells["circlebacklimitdate"].Style.BackColor = Color.White;
                    dgvRow.Cells["nextvalue"].Style.BackColor = Color.Linen;
                    //dgvRow.Cells["timingfrontlimithours"].Style.BackColor = Color.Linen;
                    //dgvRow.Cells["timingbacklimithours"].Style.BackColor = Color.Linen;
                }
                else if (circleOrTiming == "2")
                {
                    dgvRow.Cells["planexedate"].ReadOnly = true;
                    dgvRow.Cells["planexedate"].Style.BackColor = Color.Linen;
                    //dgvRow.Cells["circlefrontlimitdate"].ReadOnly = true;
                    //dgvRow.Cells["circlebacklimitdate"].ReadOnly = true;
                    dgvRow.Cells["nextvalue"].ReadOnly = false;
                    //dgvRow.Cells["timingfrontlimithours"].ReadOnly = false;
                    //dgvRow.Cells["timingbacklimithours"].ReadOnly = false;
                    //dgvRow.Cells["circlefrontlimitdate"].Style.BackColor = Color.Linen;
                    //dgvRow.Cells["circlebacklimitdate"].Style.BackColor = Color.Linen;
                    dgvRow.Cells["nextvalue"].Style.BackColor = Color.White;
                    //dgvRow.Cells["timingfrontlimithours"].Style.BackColor = Color.White;
                    //dgvRow.Cells["timingbacklimithours"].Style.BackColor = Color.White;
                }
                else if (circleOrTiming == "3")
                {
                    //dgvRow.Cells["circlefrontlimitdate"].ReadOnly = false;
                    //dgvRow.Cells["circlebacklimitdate"].ReadOnly = false;
                    dgvRow.Cells["nextvalue"].ReadOnly = false;
                    //dgvRow.Cells["timingfrontlimithours"].ReadOnly = false;
                    //dgvRow.Cells["timingbacklimithours"].ReadOnly = false;
                    //dgvRow.Cells["circlefrontlimitdate"].Style.BackColor = Color.White;
                    //dgvRow.Cells["circlebacklimitdate"].Style.BackColor = Color.White;
                    dgvRow.Cells["nextvalue"].Style.BackColor = Color.White;
                    //dgvRow.Cells["timingfrontlimithours"].Style.BackColor = Color.White;
                    //dgvRow.Cells["timingbacklimithours"].Style.BackColor = Color.White;
                }
                else if (circleOrTiming == "4")
                {
                    //dgvRow.Cells["circlefrontlimitdate"].ReadOnly = true;
                    //dgvRow.Cells["circlebacklimitdate"].ReadOnly = true;
                    dgvRow.Cells["nextvalue"].ReadOnly = true;
                    //dgvRow.Cells["timingfrontlimithours"].ReadOnly = true;
                    //dgvRow.Cells["timingbacklimithours"].ReadOnly = true;
                    dgvRow.Cells["arrangetimes"].ReadOnly = true;
                    //dgvRow.Cells["circlefrontlimitdate"].Style.BackColor = Color.Linen;
                    //dgvRow.Cells["circlebacklimitdate"].Style.BackColor = Color.Linen;
                    dgvRow.Cells["nextvalue"].Style.BackColor = Color.Linen;
                    //dgvRow.Cells["timingfrontlimithours"].Style.BackColor = Color.Linen;
                    //dgvRow.Cells["timingbacklimithours"].Style.BackColor = Color.Linen;
                    dgvRow.Cells["arrangetimes"].Style.BackColor = Color.Linen;
                }
            }
        } 
    }
}