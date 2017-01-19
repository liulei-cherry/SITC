/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmWorkInfoFirstArrange.cs
 * 创 建 人：夏喜龙
 * 创建时间：2009-06-16
 * 标    题：保养计划执行窗体
 * 功能描述：月度的保养计划执行列表
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FileOperationBase.Services;
using BaseInfo.Objects;
using BaseInfo.DataAccess;
using FileOperationBase.FileServices;
using CommonOperation.Enum;
using Maintenance;
using CommonOperation.BaseClass;
using Maintenance.Services;
using Maintenance.DataObject;
using Maintenance.Viewer;
using CommonViewer.BaseControl;
using CommonViewer.BaseForm;

namespace Maintenance.Report
{
    public partial class FrmPlanMonthFinish : CommonViewer.BaseForm.FormBase
    {
        /// <summary>
        /// 存放列与列标题的集合.
        /// </summary>
        private Dictionary<string, string> dictColumns = new Dictionary<string, string>();

        public FrmPlanMonthFinish()
        {
            InitializeComponent();
        }
        bool loadingfinish = false;
        public FrmPlanMonthFinish(string formTitle, string departmentname)
        {
            InitializeComponent();
            this.Text = formTitle;
            buttonEx5.Text = formTitle;
            depart = (Department)BaseInfo.DataAccess.DepartmentService.Instance.GetOneObjectByName(departmentname);
            if (depart.IsWrong) throw new Exception(depart.WhyWrong);

            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                ucShipSelect1.ChangeSelectedState(false, true);
                ucShipSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(ucShipSelect1_TheSelectedChanged);
            }
            else
            {
                shipid = CommonOperation.ConstParameter.ShipId;
            }
            ucPostSelect1.ChangeSelectedState(departmentname, true);
            ucPostSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(ucPostSelect1_TheSelectedChanged);
        }

        void ucPostSelect1_TheSelectedChanged(string theSelectedObject)
        {
            posID = theSelectedObject;
            BindData();
        }

        void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            BindData();
        }
        private static FrmPlanMonthFinish instanceJ;
        private static FrmPlanMonthFinish instanceL;

        public static FrmPlanMonthFinish GetInstance(string formTitle, string department)
        {
            if (department.Contains("甲板部"))
            {
                if (instanceJ == null)
                {
                    instanceJ = new FrmPlanMonthFinish(formTitle, "甲板部");
                }
                return instanceJ;
            }
            else
            {
                if (instanceL == null)
                {
                    instanceL = new FrmPlanMonthFinish(formTitle, "轮机部");
                }
                return instanceL;
            }

        }

        public static void BindCbbxYear(ComboBox cbx)
        {
            int now = DateTime.Now.Year;
            for (int i = 0; i < 12; i++)
            {
                cbx.Items.Add(now - i);
            }
            cbx.SelectedItem = now;
        }

        public static void BindCbbxMonth(ComboBox cbx)
        {
            for (int i = 1; i <= 12; i++)
            {
                cbx.Items.Add(i);
            }
            cbx.SelectedItem = DateTime.Now.Month;
        }
        private void FrmPlanMonthFinish_Load(object sender, EventArgs e)
        {
            BindCbbxYear(this.cbbxyear);
            BindCbbxMonth(this.cbbmonth);
            if (CommonOperation.ConstParameter.IsLandVersion)
                shipid = ucShipSelect1.GetId();
            dgv.LoadGridView("FrmPlanMonthFinish");
            loadingfinish = true;
            BindData();
        }

        string err = "";
        Department depart;

        string shipid;
        string posID;
        int year = DateTime.Today.Year;
        int month = DateTime.Today.Month;
        string taskid;

        FrmBusyWithStep frm = null;
        private void BindData()
        {
            if (loadingfinish)
            {
                frm = new FrmBusyWithStep("正在努力加载本月工单", new FrmBusyWithStep.FinishedOpeartion(LoadingDataWithStep));
                frm.ShowDialog();
            }
        }
        private void LoadingDataWithStep()
        {
            if (CommonOperation.ConstParameter.IsLandVersion) shipid = ucShipSelect1.GetId();
            if (shipid != null)
            {
                 if(frm!=null) frm.ChangeStep("第一步，正在获取本月计划信息和完成信息", 10);

                dgv.Rows.Clear();
                taskid = null;
                DateTime startTime = new DateTime(year, month, 1);
                DateTime endTime = startTime.AddMonths(1).AddSeconds(-1);
                WorkOrderService workOrderService = new WorkOrderService();
                List<WorkOrder> lstWorkOrders;
                List<string> lstPost = new List<string>();
                if (string.IsNullOrEmpty(posID))
                {
                    //所有部门人员.
                    DataTable dtpost = PostService.Instance.getDepartPosts(depart.GetId(), out err);
                    if (dtpost == null)
                    {
                        MessageBoxEx.Show("获取所有" + depart.DEPARTNAME + "人员的信息时出错,\r错误信息为:" + err, "错误信息");
                    }
                    foreach (DataRow dr in dtpost.Rows)
                    {
                        lstPost.Add(dr["SHIP_HEADSHIP_ID"].ToString());
                    }
                }
                else
                {
                    lstPost.Add(posID);
                }

                if (WorkOrderService.Instance.GetWorkOrderOfDate(startTime, endTime, lstPost, shipid,
                    false, out lstWorkOrders, out err) && lstWorkOrders.Count > 0)
                {
                    dgv.Rows.Add(lstWorkOrders.Count);
                    for (int i = 0; i < lstWorkOrders.Count; i++)
                    {
                        if (frm != null) frm.ChangeStep("第二步，正在为每条月度完成情况加载更多信息，共" + lstWorkOrders.Count + "条，现在正在处理第" + i + "条", 10 + i * 90 / lstWorkOrders.Count);
                        Application.DoEvents();
                        
                        WorkOrder wo = lstWorkOrders[i];
                        wo.FillThisObject();
                        if (wo.TheWorkInfo != null && wo.TheWorkInfo.WORKINFOCODE != null)
                            dgv.Rows[i].Cells["workinfocode"].Value = (wo.PLANEXEDATE < wo.COMPLETEDDATE ? "Y " : "") + wo.TheWorkInfo.WORKINFOCODE;
                        dgv.Rows[i].Cells["workorderid"].Value = wo.GetId();
                        if (wo.TheWorkInfo == null || wo.TheWorkInfo.IsWrong)
                        {
                            dgv.Rows[i].Cells["workinfodetail"].Value = wo.WORKORDERNAME + ":" + wo.WORKDESCRIPTION;
                        }
                        else
                        {
                            if (wo.TheWorkInfo.WORKINFODETAIL.Contains(wo.TheWorkInfo.WORKINFONAME))
                                dgv.Rows[i].Cells["workinfodetail"].Value = wo.TheWorkInfo.WORKINFODETAIL;
                            else
                                dgv.Rows[i].Cells["workinfodetail"].Value = wo.TheWorkInfo.WORKINFONAME + ":" + wo.TheWorkInfo.WORKINFODETAIL;
                        }
                        dgv.Rows[i].Cells["plandate"].Value = wo.PLANEXEDATE.ToShortDateString();
                        dgv.Rows[i].Cells["completedate"].Value = wo.COMPLETEDDATE.ToShortDateString();
                        dgv.Rows[i].Cells["completeinfo"].Value = wo.WORKCOMPLETEDINFO;
                        dgv.Rows[i].Cells["executor"].Value = wo.WORKEXECUTOR;
                        //dgv.Rows[i].Cells["confirmor"].Value = wo.WORKCONFIRMOR;
                    }
                }
            }
        }
        private void cbbxyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                year = Int32.Parse(this.cbbxyear.SelectedItem.ToString());
            }
            catch
            {
                return;
            }
            if (month > 0)
                BindData();
        }

        private void cbbmonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                month = Int32.Parse(this.cbbmonth.SelectedItem.ToString());
            }
            catch
            {
                return;
            }
            BindData();
        }

        private void tsbtnExcel_Click(object sender, EventArgs e)
        {
            if (CommonOperation.ConstParameter.IsLandVersion) shipid = ucShipSelect1.GetId();
            if (string.IsNullOrEmpty(shipid)) return;
            Post post = PostService.Instance.getObject(posID, out err);
            WorkModelType workModelType = null;
            if (MaintenanceConfig.customMonthlyCompleteReport != null)
            {
                workModelType = WorkModelTypeService.Instance.getModelObject(shipid, CommonPrintTableName.CTNOfMonthlyCompleteReport, out err);
            }
            if (workModelType == null)
            {
                MessageBoxEx.Show("没有找到月度完成记录的模板","错误提示");
                return;
            }
            string fileid;

            string fileName = workModelType.ModelName + (post.IsWrong ? "" : post.POSTNAME) + "_" + year.ToString() + "年" + month.ToString() + "月.xls";

            ourFolder rootFolder = FolderDbService.Instance.getFolderByFolderType(FileBoundingTypes.MACHINEWORKMONTHFINISH, shipid);

            if (rootFolder != null && FolderFileDbService.Instance.IfFolderHasTheFile(rootFolder.NodeId, fileName, out fileid))
            {
                if (MessageBoxEx.Show("找到了之前形成的文件" + fileName + ",是否要直接打开此文件?" +
                    "\r选择是,将打开旧文件,选择否,系统将替换旧文件.", "系统提示", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    ourFile ofile;

                    if (!FileDbService.Instance.GetAFileById(fileid, out ofile))
                    {
                        MessageBoxEx.Show("非常抱歉,没有成功获取此文档,下面将重新形成新文件!", "系统提示");
                    }
                    else
                    {
                        openFile opf = new openFile();
                        opf.FileOpen(ofile, right.U);
                        return;
                    }
                }
                else
                {
                    if (!FolderFileDbService.Instance.DeleteAFile(rootFolder.NodeId, fileid, out err))
                    {
                        MessageBoxEx.Show("非常抱歉,系统帮您删除旧文件时出错,错误信息为:" + err
                            + "\r这不会影响您的主要业务,但有时间希望您可以到文件管理目录中删除相应文件!", "错误提示!");
                    }
                }
            }
            if (dgv.Rows.Count > 0)
            {              
                Cursor.Current = Cursors.WaitCursor;
                List<string> lstPost = new List<string>();
                if (post == null || post.IsWrong)
                {
                    //所有部门人员.
                    DataTable dtpost = PostService.Instance.getDepartPosts(depart.GetId(), out err);
                    if (dtpost == null)
                    {

                        MessageBoxEx.Show("获取所有" + depart.DEPARTNAME + "人员的信息时出错,\r错误信息为:" + err, "错误信息");
                    }
                    foreach (DataRow dr in dtpost.Rows)
                    {
                        lstPost.Add(dr["SHIP_HEADSHIP_ID"].ToString());
                    }
                }
                else
                {
                    lstPost.Add(post.GetId());
                }
                if (depart.DEPARTNAME == "甲板部" && MaintenanceConfig.customMonthlyCompleteReport != null)
                {
                    if (!MaintenanceConfig.customMonthlyCompleteReport(shipid, year, month, lstPost, 1, out err))
                    {
                        MessageBoxEx.Show(err, "信息提示");
                    }
                }
                else if (depart.DEPARTNAME == "轮机部" && MaintenanceConfig.customMonthlyCompleteReport != null)
                {

                    if (!MaintenanceConfig.customMonthlyCompleteReport(shipid, year, month, lstPost, 2, out err))
                    {
                        MessageBoxEx.Show(err, "信息提示");
                    }
                }
                else
                {
                    MessageBoxEx.Show("没有找到合适的实现模板导出方法,只能按照默认样式导出Excel文件!");
                    easyReport();
                }
                Cursor.Current = Cursors.Default;
            }
            else
            {
                MessageBoxEx.Show("没有数据!");
            }
        }
        private void easyReport()
        {
            if (dgv.Rows.Count == 0) return;
            dgv.Title = depart.DEPARTNAME + "(" + year.ToString() + "年" + month.ToString() + "月)月度完工报告";
            dgv.Header.Clear();
            dgv.Header.Add("船舶:" + ucShipSelect1.GetText() + "                                  责任人:" + ucPostSelect1.GetText());
            dgv.OutPutExcel();
        }

        //查看任务详细信息 taskid
        private void tsbtndetail_Click(object sender, EventArgs e)
        {
            //FrmTaskDetail frm = new FrmTaskDetail();
            //frm.Taskid = taskid;
            WorkOrder wo = (WorkOrder)WorkOrderService.Instance.GetOneObjectById(taskid );
            if (wo != null)
            {
                FrmWorkOrderTraceEdit frm2 = new FrmWorkOrderTraceEdit(wo);
                frm2.ShowDialog();
                if (wo.WORKCOMPLETEDINFO != null && dgv.CurrentRow!= null)
                {
                    dgv.CurrentRow.Cells["completeinfo"].Value = wo.WORKCOMPLETEDINFO;
                }
            }
        }

        private void dgv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                taskid = dgv.Rows[e.RowIndex].Cells["workorderid"].Value.ToString();
            }
            catch
            {
                //此处不捕获错误.
            }
        }

        private void tsbtnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmPlanMonthFinish_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgv.SaveGridView("FrmPlanMonthFinish");
            instanceJ = null;
            instanceL = null;
        }

        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells["completeinfo"];
                tsbtndetail_Click(null, null);
            }
        }

    }
}