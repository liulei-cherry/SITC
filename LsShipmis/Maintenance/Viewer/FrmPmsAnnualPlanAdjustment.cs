using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ItemsManage.DataObject;
using ItemsManage.Services;
using Maintenance.Services;
using CommonViewer.BaseControl;
using Maintenance.DataObject;
using BaseInfo.DataAccess;
using BaseInfo.Objects;
using OfficeOperation;
using CommonViewer;
using System.Drawing;

namespace Maintenance.Viewer
{
    public partial class FrmPmsAnnualPlanAdjustment : CommonViewer.BaseForm.FormBase
    {
        private int currentRow = 0;

        private ComponentUnit componentUnit = null;
        private Maintenance.DataObject.WorkInfo workInfo;
        public Maintenance.DataObject.WorkInfo WorkInfo
        {
            get { return workInfo; }
            set
            {
                if (null == value)
                {
                    workInfo = null;

                    ucWorkInfo.WorkInfo = value;
                    return;
                }
                workInfo = value;
                ucWorkInfo.WorkInfo = workInfo;
            }
        }
        Maintenance.DataObject.T_WORKINFO_HISTORY_OUT workinfoHistoryOut = null;

        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmPmsAnnualPlanAdjustment instance = new FrmPmsAnnualPlanAdjustment();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmPmsAnnualPlanAdjustment Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmPmsAnnualPlanAdjustment.instance = new FrmPmsAnnualPlanAdjustment();
                }

                return FrmPmsAnnualPlanAdjustment.instance;
            }
        }

        #endregion
        public FrmPmsAnnualPlanAdjustment()
        {
            InitializeComponent();
            this.setGridShortCutBtn();           //设置界面上的网格的一些常用的快捷菜单的事件处理.
        }
        private void FrmPmsAnnualPlanAdjustment_Load(object sender, EventArgs e)
        {
            cbxREPROT_TYPE.SelectedIndex = 0;
            dtpTarget.Value = dtpOrigin.Value.AddYears(1);
            ucShipSelect1.ChangeSelectedState(false, false);
            this.setGridShortCutBtn();          //设置界面上的网格的一些常用的快捷菜单的事件处理.
            //加载所有工作列表信息.
            if (!this.loadWorkData())
                return;
            //设置列标题.
            Dictionary<string, string> dictColumns = new Dictionary<string, string>();
            dictColumns.Clear();

            dictColumns.Add("WORKINFOCODE", "工作编号");
            dictColumns.Add("COMP_CHINESE_NAME", "保养设备");
            dictColumns.Add("WorkInfoName", "工作名称");
            dictColumns.Add("worker", "责任人");
            dictColumns.Add("CircleOrTiming", "定期/定时");
            dictColumns.Add("WORKINFOSTATE", "工作状态");
            dictColumns.Add("ORDERNUM_SHOW", "序号");
            //dictColumns.Add("MONTHS_CHECK", "月保养");

            dgvWork.SetDgvGridColumns(dictColumns);
            dgvWork.Columns["WorkInfoName"].Tag = 0;
            foreach (DataGridViewColumn col in dgvWork.Columns)
            {
                col.ReadOnly = true;
            }
            //加载网格控件默认的列宽信息.
            dgvWork.LoadGridView("FrmPmsAnnualPlanAdjustment.dgvWork");
        }
        /// <summary>
        /// 设置界面上的网格的一些常用的快捷菜单的事件处理，.
        /// </summary>
        private void setGridShortCutBtn()
        {
            dgvWork.adding = new CommonViewer.UcDataGridView.Adding(deleAdding);
            dgvWork.editing = new CommonViewer.UcDataGridView.Editing(deleEditing);
            dgvWork.deleting = new CommonViewer.UcDataGridView.Deleting(deleDeleting);
        }

        /// <summary>
        /// 加载按条件查询出的工作信息列表.
        /// </summary>
        private bool loadWorkData()
        {
            string err = "";
            this.dgvWork.RowEnter -= new DataGridViewCellEventHandler(dgvWork_CurrentCellChanged);//取消rowEnter事件.
            //加载列表数据.
            if (dtpQueryYear.Value == null)
                return true;
            string REPROT_TYPE = "";
            if (cbxREPROT_TYPE.SelectedItem != null)
            {
                if (cbxREPROT_TYPE.SelectedItem.ToString() == "甲板类型")
                    REPROT_TYPE = "1";
                else if (cbxREPROT_TYPE.SelectedItem.ToString() == "轮机类型")
                    REPROT_TYPE = "2";
            }
            DataTable dtbWork;
            if (!T_WORKINFO_HISTORY_OUTService.Instance.GetWorkinfoHistory(ucShipSelect1.GetId(), dtpQueryYear.Value,
                REPROT_TYPE, out dtbWork, out err))
            {
                MessageBoxEx.Show(err);
                return false;
            }
            bindingSourceMain.DataSource = dtbWork;
            dgvWork.DataSource = bindingSourceMain;
            //当没有工作信息时.
            if (dtbWork.Rows.Count == 0)
            {
                workInfo = null;
                ucWorkInfo.WorkInfo = workInfo;
                ucWorkInfo.addRefrshControls();
            }

            //工作信息的初始化设置。.
            ucWorkInfo.Component_unit = componentUnit;
            this.dgvWork.RowEnter += new DataGridViewCellEventHandler(dgvWork_CurrentCellChanged);//加rowEnter事件.
            if (dgvWork.Rows.Count > 0)
            {
                dgvWork.CurrentCell = dgvWork.FirstDisplayedCell;
            }
            else
            {
                ucWorkInfo.WorkInfo = null;
            }
            return true;
        }
        private void dgvWork_CurrentCellChanged(object sender, EventArgs e)
        {
            string err;
            if (dgvWork.CurrentCell == null || dgvWork.CurrentCell.RowIndex < 0 || dgvWork.Rows[dgvWork.CurrentCell.RowIndex].Cells["WorkInfoID"].Value == null)
            {
                return;
            }
            else
            {
                DataGridViewRow dr = dgvWork.Rows[dgvWork.CurrentCell.RowIndex];
                //加载选中工作的相关工单列表.
                string workInfoID = "";
                if (DBNull.Value != dr.Cells["WorkInfoID"].Value && dr.Cells["WorkInfoID"].Value != null)
                    workInfoID = dr.Cells["WorkInfoID"].Value.ToString();
                workInfo = WorkInfoService.Instance.getObject(workInfoID, out err);

                //加载选中工作的表格信息.
                string WHID = "";
                if (DBNull.Value != dr.Cells["WHID"].Value && dr.Cells["WHID"].Value != null)
                    WHID = dr.Cells["WHID"].Value.ToString();
                workinfoHistoryOut = T_WORKINFO_HISTORY_OUTService.Instance.getObject(WHID, out err);
            }
            ucWorkInfo.WorkInfo = workInfo;
            txtORDERNUM_SHOW.Text = workinfoHistoryOut.ORDERNUM_SHOW;
            txtEXCEL_ORDERNUM.Text = workinfoHistoryOut.EXCEL_ORDERNUM.ToString();
            string months_check = workinfoHistoryOut.MONTHS_CHECK == null ? "" : workinfoHistoryOut.MONTHS_CHECK;
            for (int i = 1; i <= 12; i++)
            {
                CheckBox cb = (CheckBox)flowLayoutPanel2.Controls.Find("checkbox" + i, false)[0];
                cb.Checked = (months_check.Contains("{" + i + "}"));
            }
            txtEx1.Text = workinfoHistoryOut.EX1;
        }
        private void cbxITEMTYPE_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadWorkData();
        }
        /// <summary>
        /// 年度复制.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnnualCopy_Click(object sender, EventArgs e)
        {
            string err;
            if (string.IsNullOrEmpty(ucShipSelect1.GetId()))
            {
                MessageBoxEx.Show("请先选择船舶");
                return;
            }
            if (DialogResult.No == MessageBoxEx.Show("确认要执行年度复制吗?", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;
            if (!T_WORKINFO_HISTORY_OUTService.Instance.CopyAnnualInfo(ucShipSelect1.GetId(), dtpOrigin.Value
                , ucShipSelect1.GetId(), dtpTarget.Value, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            MessageBoxEx.Show("操作成功");
            this.loadWorkData();
        }
        private void deleAdding()
        {
            string err;
            int lastRow = 0;

            //保存当前行.
            if (dgvWork.Rows.Count > 0)
            {
                currentRow = this.dgvWork.CurrentCell.RowIndex;
            }
            else
            {
                currentRow = 0;
            }

            Maintenance.DataObject.WorkInfo work = new Maintenance.DataObject.WorkInfo();
            work.SHIP_ID = ucShipSelect1.GetId();
            work.WORKINFOID = null;
            work.WORKINFOSTATE = 1;

            lastRow = dgvWork.Rows.Count;                          //记录总行数.
            FrmEquipmentWorkInfoAddEdit frm = new FrmEquipmentWorkInfoAddEdit();
            frm.ComponentUnit = componentUnit;
            frm.WorkInfo = work;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            if (!string.IsNullOrEmpty(work.WORKINFOID))
            {
                T_WORKINFO_HISTORY_OUT who = new T_WORKINFO_HISTORY_OUT();
                who.SHIP_ID = ucShipSelect1.GetId();
                who.ANNUAL = dtpQueryYear.Value;
                who.WORKID = work.WORKINFOID;
                Post p = PostService.Instance.getObject(work.PRINCIPALPOST, out err);
                if (p.DepartmentId == DepartmentService.Instance.GetInfoByDepartmentType("甲板部门", out err).DEPARTMENTID)
                    who.REPROT_TYPE = 1;
                else if (p.DepartmentId == DepartmentService.Instance.GetInfoByDepartmentType("轮机部门", out err).DEPARTMENTID)
                    who.REPROT_TYPE = 2;
                who.ITEMTYPE = "1";
                if (!who.Update(out err))
                {
                    MessageBoxEx.Show(err);
                    return;
                }
            }
            this.loadWorkData();
            if (dgvWork.Rows.Count > 0)
            {
                if (dgvWork.Rows.Count > lastRow)
                {
                    dgvWork.CurrentCell = dgvWork["WorkInfoName", dgvWork.Rows.Count - 1];//显示最后一行.
                }
                else
                {
                    dgvWork.CurrentCell = dgvWork["WorkInfoName", currentRow];//显示当前行.
                }
            }
        }
        private void deleEditing()
        {
            if (workInfo == null)
            {
                MessageBoxEx.Show("请选择要修改的工作信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //保存当前行.
            currentRow = this.dgvWork.CurrentCell.RowIndex;

            FrmEquipmentWorkInfoAddEdit frm = new FrmEquipmentWorkInfoAddEdit();
            frm.WorkInfo = workInfo;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            this.loadWorkData();
            try
            {
                dgvWork.CurrentCell = dgvWork["WorkInfoName", currentRow];//显示当前行.
            }
            catch
            { }
        }

        private void deleDeleting()
        {
            if (workInfo == null)
            {
                MessageBoxEx.Show("请选择要停止的工作信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBoxEx.Show("您确认停止选定的工作信息吗?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            string err = "";
            int deleteType = -1;//-1未选择,1,删除已经生效的工单,0,不删除已经生效的工单.
            if (workInfo.WORKINFOSTATE == 1)
            {
                if (WorkInfoService.Instance.getLeftValidWork(workInfo.WORKINFOID) > 0)
                {
                    if (deleteType == -1)
                    {
                        if (MessageBoxEx.Show("工作信息存在未完成的工单，是否删除已经列入计划的工单信息?"
                           , "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3) == DialogResult.Yes)
                        {
                            deleteType = 1;
                        }
                        else
                        {
                            deleteType = 0;
                        }
                    }
                    if (deleteType == 1)
                    {
                        //是否删除已经该工作信息已列入计划的工作，1删除，0不删除.
                        if (!WorkInfoService.Instance.cancelWorkInfo(workInfo, deleteType, out err))
                        {
                            MessageBoxEx.Show(err, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                workInfo.WORKINFOSTATE = 0;
                if (!workInfo.Update(out err))
                {
                    MessageBoxEx.Show(err, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            MessageBoxEx.Show("工作信息停止成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.loadWorkData();
        }
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            deleAdding();
        }

        private void bdNgEditItem_Click(object sender, EventArgs e)
        {
            deleEditing();
        }
        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            deleDeleting();
        }
        private void btnTableEdit_Click(object sender, EventArgs e)
        {
            if (workInfo == null)
            {
                MessageBoxEx.Show("请选择工作信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (workInfo.WORKINFOSTATE == 0)
            {
                MessageBoxEx.Show("对于已经停止的工作信息不能安排工单！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            currentRow = this.dgvWork.CurrentCell.RowIndex;
            FrmPmsAnnualPlanFirstArrange frm = new FrmPmsAnnualPlanFirstArrange(workInfo, workinfoHistoryOut, dtpQueryYear.Value);
            frm.ShowDialog();
            this.loadWorkData();
            try
            {
                dgvWork.CurrentCell = dgvWork["WorkInfoName", currentRow];//显示当前行.
            }
            catch { }
        }

        private void dgvWork_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bdNgEditItem_Click(sender, null);
        }

        private void getSubComponentIds(ComponentUnit unit)
        {
            List<ComponentUnit> units = ComponentUnitService.Instance.GetListComponentByParentId(unit.COMPONENT_UNIT_ID);
            if (units.Count > 0)
            {
                foreach (ComponentUnit ounit in units)
                {
                    getSubComponentIds(ounit);
                }
            }
        }
        private void dtpQueryYear_ValueChanged(object sender, EventArgs e)
        {
            loadWorkData();
        }
        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            loadWorkData();
        }
        private void ckbAnnual_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadWorkData();
        }

        private void FrmPmsAnnualPlanAdjustment_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvWork.SaveGridView("FrmPmsAnnualPlanAdjustment.dgvWork");
            instance = null;
        }

        private void bdNgClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 打印输出部分

        Font titleFont = new Font("宋体", 20, FontStyle.Bold);
        Font tableHeadFont = new Font("宋体", 10, FontStyle.Bold);
        Font systemFont = new Font("黑体", 12, FontStyle.Bold);
        Font bodyFont = new Font("宋体", 10);

        /// <summary>
        /// 打印.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            string err = "";
            DataTable dt = T_WORKINFO_HISTORY_OUTService.Instance.getInfoByship(ucShipSelect1.GetId(), cbxREPROT_TYPE.SelectedItem.ToString().Equals("甲板类型") ? 1 : 2, dtpQueryYear.Value, out err);
            List<string> applyList = new List<string>();
            foreach (DataRow item in dt.Rows)
            {
                applyList.Add(item["WHID"].ToString());
            }
            if(applyList.Count <=0)
            {
                MessageBoxEx.Show("无打印内容","提示");
                return;
            }
            if (!customRepairApplyPrint(applyList, cbxREPROT_TYPE.SelectedItem.ToString().Equals("甲板类型") ? 1 : 2, out err))
            {
                MessageBoxEx.Show("打印失败,错误参考\r" + err);
            }
        }

        /// <summary>
        /// path包含名称.
        /// </summary>
        /// <param name="applyId"></param>
        /// <param name="path"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool customRepairApplyPrint(List<string> applyList,int type, out string err)
        {
            using (OperationExcel operExcel = new OperationExcel())
            {
                operExcel.SetHorizontal(true);

                //设置标题.
                operExcel.AddTitle("山东省海丰船舶管理有限公司", 1, out err);
                operExcel.AddTitle(type ==1 ?"甲板部分": "轮机部分", 2, out err);
                operExcel.AddTitle("编号 100107-2", 4, out err);
                operExcel.AddTitle("船名:    _______________  " + "       年度:__________________", 6, out err);
                operExcel.AddTitle("轮机长:  _______________ " + " 船长:_________________" + " 日期:___________________", 9, out err);
                operExcel.AddTitle("机务主管:_______________" + "    船技部经理:______________" + "  日期:_______________", 13, out err);

                //bodyContents
                DataTable dt = new DataTable();

                string[,] tableData = new string[applyList.Count, 17];
                string value;
                for (int i = 0; i < applyList.Count; i++)
                {
                    DataTable apply = T_WORKINFO_HISTORY_OUTService.Instance.getInfo(applyList[i], out err);
                    if (i == 0) dt = apply;
                    DataRow drapply = apply.Rows[0];
                    tableData[i, 0] = drapply["ORDERNUM_SHOW"].ToString();
                    tableData[i, 1] = drapply["CLASS1"].ToString();
                    tableData[i, 2] = drapply["CLASS2"].ToString();
                    tableData[i, 3] = drapply["MONTHS_CHECK"].ToString().Contains("{1}") ? "√" : null;
                    tableData[i, 4] = drapply["MONTHS_CHECK"].ToString().Contains("{2}") ? "√" : null;
                    tableData[i, 5] = drapply["MONTHS_CHECK"].ToString().Contains("{3}") ? "√" : null;
                    tableData[i, 6] = drapply["MONTHS_CHECK"].ToString().Contains("{4}") ? "√" : null;
                    tableData[i, 7] = drapply["MONTHS_CHECK"].ToString().Contains("{5}") ? "√" : null;
                    tableData[i, 8] = drapply["MONTHS_CHECK"].ToString().Contains("{6}") ? "√" : null;
                    tableData[i, 9] = drapply["MONTHS_CHECK"].ToString().Contains("{7}") ? "√" : null;
                    tableData[i, 10] = drapply["MONTHS_CHECK"].ToString().Contains("{8}") ? "√" : null;
                    tableData[i, 11] = drapply["MONTHS_CHECK"].ToString().Contains("{9}") ? "√" : null;
                    tableData[i, 12] = drapply["MONTHS_CHECK"].ToString().Contains("{10}") ? "√" : null;
                    tableData[i, 13] = drapply["MONTHS_CHECK"].ToString().Contains("{11}") ? "√" : null;
                    tableData[i, 14] = drapply["MONTHS_CHECK"].ToString().Contains("{12}") ? "√" : null;

                    if (T_WORKINFO_HISTORY_OUTService.Instance.getHEADSHIP_NAME(drapply["WORKID"].ToString(), out value, out err))
                    {
                        tableData[i, 15] = value;
                    }
                    else
                    {
                        return false;
                    }
                    tableData[i, 16] = drapply["EX1"].ToString(); //备注.
                }

                operExcel.AddAllColumnSize(1, 5);
                operExcel.AddAllColumnSize(2, 60);
                operExcel.AddAllColumnSize(3, 230);
                operExcel.AddAllColumnSize(4, 240);
                operExcel.AddAllColumnSize(5, 40);
                operExcel.AddAllColumnSize(6, 40);
                operExcel.AddAllColumnSize(7, 40);
                operExcel.AddAllColumnSize(8, 40);
                operExcel.AddAllColumnSize(9, 40);
                operExcel.AddAllColumnSize(10, 40);
                operExcel.AddAllColumnSize(11, 40);
                operExcel.AddAllColumnSize(12, 40);
                operExcel.AddAllColumnSize(13, 40);
                operExcel.AddAllColumnSize(14, 40);
                operExcel.AddAllColumnSize(15, 40);
                operExcel.AddAllColumnSize(16, 40);
                operExcel.AddAllColumnSize(17, 40);
                operExcel.AddAllColumnSize(18, 40);

                if (!operExcel.InsertATable(new OneTable(tableData, false, 15, 2, applyList.Count, 17, true, XlHorizontalAlignment.xlLeft), out err))
                {
                    return false;
                }

                SetHeaderFooter(operExcel);

                FrmOurReport frm = new FrmOurReport(type == 1 ? "甲板部年度计划" : "轮机部年度计划", operExcel);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                return true;
            }
        }

        //, DataRow theApply
        private void SetHeaderFooter(OperationExcel operationExcel)
        {
            List<OneUnit> theHeader = new List<OneUnit>();

            theHeader.Add(new OneUnit("项目", false, 1, 2, 2, 1, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));
            theHeader.Add(new OneUnit("维护保养部位", false, 1, 3, 2, 1, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));
            theHeader.Add(new OneUnit("维护保养内容", false, 1, 4, 2, 1, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));
            theHeader.Add(new OneUnit("月份", false, 1, 5, 1, 12, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));
            theHeader.Add(new OneUnit("1", false, 2, 5, 1, 1, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));
            theHeader.Add(new OneUnit("2", false, 2, 6, 1, 1, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));
            theHeader.Add(new OneUnit("3", false, 2, 7, 1, 1, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));
            theHeader.Add(new OneUnit("4", false, 2, 8, 1, 1, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));
            theHeader.Add(new OneUnit("5", false, 2, 9, 1, 1, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));
            theHeader.Add(new OneUnit("6", false, 2, 10, 1, 1, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));
            theHeader.Add(new OneUnit("7", false, 2, 11, 1, 1, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));
            theHeader.Add(new OneUnit("8", false, 2, 12, 1, 1, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));
            theHeader.Add(new OneUnit("9", false, 2, 13, 1, 1, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));
            theHeader.Add(new OneUnit("10", false, 2, 14, 1, 1, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));
            theHeader.Add(new OneUnit("11", false, 2, 15, 1, 1, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));
            theHeader.Add(new OneUnit("12", false, 2, 16, 1, 1, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));
            theHeader.Add(new OneUnit("检修负责人", false, 1, 17, 2, 1, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));
            theHeader.Add(new OneUnit("备注", false, 1, 18, 2, 1, true, false, XlHorizontalAlignment.xlCenter, tableHeadFont));

            List<OneUnit> theFooter = new List<OneUnit>();
            theFooter.Add(new OneUnit("注:1.打√表示选中。", false, 1, 2, 1, 17, false, false, XlHorizontalAlignment.xlLeft, bodyFont));
            theFooter.Add(new OneUnit("2.本表一式二份，机务监督员存一份，船舶存一份。", false, 2, 2, 1, 17, false, false, XlHorizontalAlignment.xlLeft, bodyFont));

            List<int> headerHeight = new List<int>();
            headerHeight.Add(25);
            headerHeight.Add(25);

            List<int> footerHeight = new List<int>();
            footerHeight.Add(20);
            footerHeight.Add(20);
            footerHeight.Add(1);
            //HeaderAndFooter oneHeaderAndFooter1 = new HeaderAndFooter(new List<OneUnit>(), new List<OneUnit>(), 1, headerHeight, footerHeight);   
            HeaderAndFooter oneHeaderAndFooter2 = new HeaderAndFooter(theHeader, theFooter, 15, headerHeight, footerHeight);
            //operationExcel.AddHeaderAndFooter(oneHeaderAndFooter1);
            operationExcel.AddHeaderAndFooter(oneHeaderAndFooter2);
            //operationExcel.SetPageFillGrid(true, 2, 18, 20);
        }

        #endregion

    }
}