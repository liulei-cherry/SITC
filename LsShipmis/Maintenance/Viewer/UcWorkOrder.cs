/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：UcWorkOrder.cs
 * 创 建 人：夏喜龙
 * 创建时间：2009-06-26
 * 标    题：工单显示控件
 * 功能描述：只是工单的显示
 * 修 改 人：
 * 修改时间：
 * 修改内容：  
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms; 
using CommonViewer.BaseForm;
using Maintenance.DataObject;
using Maintenance.Services;
using OfficeOperation;
using CommonViewer;
using CommonViewer.BaseControl;

namespace Maintenance.Viewer
{
    public partial class UcWorkOrder : UserControl
    {
        public UcWorkOrder()
        {
            InitializeComponent();
        }          

        private WorkOrder workOrder; //工单的扩展类.
        public WorkOrder ThisWorkOrder
        {
            get { return workOrder; }
            set 
            {
                if (null == value) {
                    clearData();
                    return;
                }
                workOrder = value;
                loadWorkOrder();
            }
        }

        private string taskId;
        public string TaskId
        {
            get { return taskId; }
            set 
            {
                if (value == null) return;
                taskId = value;
                string err;
                ThisWorkOrder = WorkOrderService.Instance.getObject(taskId, out err);
            }
        }

        /// <summary>
        /// 加载工作历史信息.
        /// </summary>
        private  void loadWorkOrder()
        {
            //控件初始值.
            if (workOrder != null && !workOrder.IsWrong )
            {
                workOrder.FillThisObject ();
                if (workOrder.WORKORDERID != null && workOrder.WORKORDERID.Length > 0)
                { 
                    taskName.Text = workOrder.WORKORDERNAME;
                    switch ((int)workOrder.WORKORDERSTATE)
                    {
                        case 1:
                            cboState.Text = "计划状态";
                            break;
                        case 2:
                            cboState.Text = "超期状态";
                            break;
                        case 3:
                            cboState.Text = "免做申请状态";
                            break;
                        case 4:
                            cboState.Text = "超期待确认状态";
                            break;
                        case 5:
                            cboState.Text = "计划状态";
                            break;
                        case 6:
                            cboState.Text = "本次免做确认";
                            break;
                        case 7:
                            cboState.Text = "已确认";
                            break;
                        case 8:
                            cboState.Text = "超期确认";
                            break;
                    }
                    if (workOrder.TheWorkInfo == null || workOrder.TheWorkInfo.IsWrong)
                    {
                        if ((int)workOrder.ISCOMBINEDORDER == 1)
                            cboType.Text = "合并工单";
                        else if ((int)workOrder.ISTEMPWORKORDER == 1)
                            cboType.Text = "临时工单";
                        else
                            cboType.Text = "未知种类的工单"; 
                    }
                    else
                    {
                        switch ((int)workOrder.TheWorkInfo.CIRCLEORTIMING)
                        {
                            case 1:
                                cboType.Text = "定期";
                                break;
                            case 2:
                                cboType.Text = "定时";
                                break;
                            case 3:
                                cboType.Text = "定期和定时";
                                break;
                            case 4:
                                cboType.Text = "非周期工单";
                                break;                               
                        }
                    }

                    PlanExeDate.Text = workOrder.PLANEXEDATE.ToShortDateString() == "0001-1-1" ? "" : workOrder.PLANEXEDATE.ToShortDateString();
                    CircleFrontLimitDate.Text = workOrder.CIRCLEFRONTLIMITDATE.ToShortDateString() == "0001-1-1" ? "" : workOrder.CIRCLEFRONTLIMITDATE.ToShortDateString();
                    CircleBackLimitDate.Text = workOrder.CIRCLEBACKLIMITDATE.ToShortDateString() == "0001-1-1" ? "" : workOrder.CIRCLEBACKLIMITDATE.ToShortDateString();

                    NextValue.Text = workOrder.NEXTVALUE.ToString();
                    TimingFrontLimitHours.Text = workOrder.TIMINGFRONTLIMITHOURS.ToString();
                    TimingBackLimitHours.Text = workOrder.TIMINGBACKLIMITHOURS.ToString();

                    ExecuteValue.Text = workOrder.EXCUTEVALUE.ToString();
                    PreExecuteValue.Text = workOrder.Estimatevalue.ToString();
                    CompletedDate.Text = workOrder.COMPLETEDDATE.ToShortDateString() == "0001-1-1" ? "" : workOrder.COMPLETEDDATE.ToShortDateString();

                    principalPost.Text = workOrder.Principalpostname;
                    WorkExecutor.Text = workOrder.WORKEXECUTOR;

                    ConfirmPost.Text = workOrder.Confirmpostname;
                    WorkConfirmor.Text = workOrder.WORKCONFIRMOR;

                    steadedWk.Text = workOrder.Insteadedwkname;
                    IsTempWorkOrder.Checked = (int)workOrder.ISTEMPWORKORDER == 1 ? true : false;
                    IsCombinedOrder.Checked = (int)workOrder.ISCOMBINEDORDER == 1 ? true : false;
                    chkRepair.Checked = (int)workOrder.ISREPAIRPROJECT == 1 ? true : false;
                    chkCheck.Checked = (int)workOrder.ISCHECKPROJECT  == 1 ? true : false;

                    if(workOrder.TheWorkInfo!= null) txtWorkInfo.Text = workOrder.TheWorkInfo.WORKINFODETAIL;
                    txtExtra.Text = workOrder.WORKDESCRIPTION;
                    txtCommon.Text = workOrder.WORKCOMPLETEDINFO;
                    
                }
            }

        }

        private void clearData()
        {
            taskName.Text = "";
            cboState.Text = "";
            cboType.Text = "";

            PlanExeDate.Text = "";
            CircleFrontLimitDate.Text = "";
            CircleBackLimitDate.Text = "";

            NextValue.Text = "";
            TimingFrontLimitHours.Text = "";
            TimingBackLimitHours.Text = "";

            ExecuteValue.Text = "";
            PreExecuteValue.Text = "";
            CompletedDate.Text = "";

            principalPost.Text = "";
            WorkExecutor.Text = "";

            ConfirmPost.Text = "";
            WorkConfirmor.Text = "";

            steadedWk.Text = "";
            IsTempWorkOrder.Checked = false;
            IsCombinedOrder.Checked = false;
            chkRepair.Checked = false;
            chkCheck.Checked = false;

            txtWorkInfo.Text = "";
            txtExtra.Text = "";
            txtCommon.Text = "";
        }

        private void SetViewMode(bool CanEdit)
        {
            if (CanEdit)
            {
                groupBox1.Text = "工单信息维护";
            }
            else
            {
                groupBox1.Text = "工单信息查看";
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            using (OperationExcel operationExcel = new OperationExcel())
            {
                if (workOrder == null || workOrder.IsWrong)
                {
                    MessageBoxEx.Show("无效工单,不能打印");
                    return;
                }
                string err;
                if (!operationExcel.AddTitle("(" + taskName.Text + ")工单信息", 1, out err)
                    || !operationExcel.InsertABodyPair(new OnePair("责任人岗位", principalPost.Text, PairType.ALLBORDER, 2, 2), out err)
                    || !operationExcel.InsertABodyPair(new OnePair("工单执行人", WorkExecutor.Text, PairType.ALLBORDER, 2, 4), out err)
                    || !operationExcel.InsertABodyPair(new OnePair("确认人岗位", ConfirmPost.Text, PairType.ALLBORDER, 2, 6), out err)
                    || !operationExcel.InsertABodyPair(new OnePair("工单确认人", WorkConfirmor.Text, PairType.ALLBORDER, 2, 8), out err)
                    || !operationExcel.InsertABodyPair(new OnePair("工单状态", cboState.Text, PairType.ALLBORDER, 3, 2), out err)
                    || !operationExcel.InsertABodyPair(new OnePair("工单类型", cboType.Text, PairType.ALLBORDER, 3, 4), out err)
                    || !operationExcel.InsertABodyPair(new OnePair("计划执行日期", PlanExeDate.Text, PairType.ALLBORDER, 3, 6), out err)
                    || !operationExcel.InsertABodyPair(new OnePair("计划执行表值", NextValue.Text, PairType.ALLBORDER, 3, 8), out err)
                    || !operationExcel.InsertABodyPair(new OnePair("前允差日期", CircleFrontLimitDate.Text, PairType.ALLBORDER, 4, 2), out err)
                    || !operationExcel.InsertABodyPair(new OnePair("后允差日期", CircleBackLimitDate.Text, PairType.ALLBORDER, 4, 4), out err)
                    || !operationExcel.InsertABodyPair(new OnePair("前允差表值", TimingFrontLimitHours.Text, PairType.ALLBORDER, 4, 6), out err)
                    || !operationExcel.InsertABodyPair(new OnePair("后允差表值", TimingBackLimitHours.Text, PairType.ALLBORDER, 4, 8), out err)
                    || !operationExcel.InsertABodyPair(new OnePair("实际完工日期", CompletedDate.Text, PairType.ALLBORDER, 5, 2), out err)
                    || !operationExcel.InsertABodyPair(new OnePair("实际执行表值", ExecuteValue.Text, PairType.ALLBORDER, 5, 4), out err)
                    || !operationExcel.InsertABodyPair(new OnePair("预计执行表值", PreExecuteValue.Text, PairType.ALLBORDER, 5, 6, 3), out err)
                    || !operationExcel.InsertABodyPair(new OnePair("工作信息描述", TimingBackLimitHours.Text, PairType.ALLBORDER, 6, 2, 7), out err)
                    || !operationExcel.InsertABodyPair(new OnePair("工单补充说明", txtExtra.Text, PairType.ALLBORDER, 7, 2, 7), out err)
                    || !operationExcel.InsertABodyPair(new OnePair("工单完工说明", txtCommon.Text, PairType.ALLBORDER, 8, 2, 7), out err))
                {
                    MessageBoxEx.Show(err);
                    return;
                }
                operationExcel.AddAllColumnSize(1, 20);
                operationExcel.AddAllLineSize(1, 50);
                operationExcel.AddAllLineSize(6, 50);
                operationExcel.AddAllLineSize(7, 50);
                operationExcel.AddAllLineSize(8, 50);
                FrmOurReport frmOurReport = new FrmOurReport("工单详情打印", operationExcel);
                frmOurReport.StartPosition = FormStartPosition.CenterParent;
                frmOurReport.ShowDialog();
            }
        }

        private void btnSpare_Click(object sender, EventArgs e)
        { 
            if (workOrder == null)
            {
                MessageBoxEx.Show("工单不能为空！");
                return;
            }
            else
            {
                FrmWorkOrderSpConsume frm = new FrmWorkOrderSpConsume(1, workOrder.GetId (), workOrder.WORKINFOID, workOrder.WORKORDERNAME);
                frm.ShowDialog();
            }
        }

        private void btnMeasureReport_Click(object sender, EventArgs e)
        {
            if (workOrder == null)
            {
                return;
            }
            FrmWorkOrderMeasureReport frm = new FrmWorkOrderMeasureReport(workOrder.WORKINFOID , workOrder.WORKORDERID );
            frm.ShowDialog();

        }

        private void btnReplaceWork_Click(object sender, EventArgs e)
        {
            if (workOrder == null)
            {
                return;
            }
            FrmReplacedWorkView frm = new FrmReplacedWorkView(workOrder);
            frm.ShowDialog();
        }
       
    }
}
