/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmOilApplyEdit.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-08-01
 * 标    题：编辑申请业务窗体
 * 功能描述：实现物料申请业务窗体上的相关功能,本窗体有5种功能
 *           1 新申请、
 *           2 别处选择物料(油料)，调用添加申请单、
 *           3 修改申请单
 *           4 部门长审批
 *           5 船长审批
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
using Oil.DataObject;
using Oil.Services;
using CommonViewer.BaseForm;
using System.IO;
using ShipMisZHJ_WorkFlow.Forms;
using ShipMisZHJ_WorkFlow.Services;
using BaseInfo.DataAccess;
using CommonOperation.BaseClass;
using CommonOperation.Interfaces;
using CommonViewer.BaseControl;
using CommonOperation.Functions;
using CommonViewer.BaseControlService;

namespace Oil.Viewer
{
    /// <summary>
    /// 物料申请业务窗体.
    /// </summary>
    public partial class FrmOilApplyEdit : CommonViewer.BaseForm.FormBase
    {

        #region 窗体对象

        private HOilApply currentObject;
        public HOilApply CurrentObject
        {
            get { return currentObject; }
            set
            {
                currentObject = value;
            }
        }

        #endregion

        # region 业务对象和类

        private int mainFunction = 1;
        //            1 新申请、.
        //*           2 别处选择物料（油料），调用添加申请单、.
        //*           3 修改申请单.
        //*           4 部门长审批.
        //*           5 船长审批.
        //*           6 陆地端审核.
        private IDBOperation commonOpt = CommonOperation.Functions.InterfaceInstantiation.NewADBOperation();//定义一个公共类CommonOpt对象.
        private FormControlOption other = FormControlOption.Instance;
        private DataTable dtb2;

        #endregion

        /// <summary>
        /// 构造函数，默认就是新申请.
        /// </summary>
        public FrmOilApplyEdit()
        {
            InitializeComponent();
        }

        public FrmOilApplyEdit(string applyId, int functionIn)
        {
            InitializeComponent();
            string sChkMessage = "传入的id无效，无法展示数据";
            if (applyId.Length == 36)
            {
                CurrentObject = HOilApplyService.Instance.getObject(applyId, out sChkMessage);
            }
            if (CurrentObject == null)
            {
                MessageBoxEx.Show(sChkMessage, "警告", new MessageBoxButtons(), MessageBoxIcon.Warning);
                this.Close();
            }

            if (functionIn <= 3) mainFunction = 3;
            else if (functionIn >= 6) mainFunction = 6;
            else if (functionIn == 5) mainFunction = 5;
            else mainFunction = 4;
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMaterialApplyEdit_Load(object sender, EventArgs e)
        {
            setComboBox();

            this.bindingData();

            setBindingSourceDetail();//刷新当前明细列表.
            setButtonsAndControls();
        }

        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {
            string err = "";

            //滑油.
            dtb2 = HOilService.Instance.GetShipLubOil(CommonOperation.ConstParameter.ShipId);
            cboShipLubOil.DataSource = dtb2;
            cboShipLubOil.DisplayMember = "OIL_FULL_NAME";
            cboShipLubOil.ValueMember = "Oil_Id";

            DgvBindDrop dgvBindDrop1 = new DgvBindDrop();
            dgvBindDrop1.bindDropToDgv(dgvMatApplyDetail, cboShipLubOil, 3, false, 1);

            //港口.
            DataTable dtb1 = PortInfoService.Instance.getInfo(out err);
            other.SetComboBoxValue(cobPort, dtb1);
        }

        private void setButtonsAndControls()
        {
            //修改的按钮谁都可以看，但审核的时候不能用仅保存，只能一次完成.
            bdNgSaveItem.Visible = mainFunction < 4;
            bdNgComplete.Visible = mainFunction < 4;
        }

        /// <summary>
        /// 绑定窗体控件（申请单信息控件的绑定）.
        /// </summary>
        private void bindingData()
        {
            string err;
            //如果是包含子记录的，要把主记录和子记录都加上，否则只需要主记录.
            if (mainFunction < 3)
            {
                currentObject = new HOilApply();
                currentObject.APPLY_DATE = DateTime.Now;
                currentObject.SHIP_ID = CommonOperation.ConstParameter.ShipId;
                currentObject.SUPPLY_DATE = DateTime.Now.AddMonths(1);
                currentObject.PORT_ID = cobPort.SelectedValue.ToString();
                currentObject.Update(out err);
            }
            showDataToForm();
        }

        private void showDataToForm()
        {
            if (currentObject == null)
            {
                throw new Exception("错误，不应该出现无法识别申请单信息的情况!");
            }

            dtpApplyDate.Value = currentObject.APPLY_DATE;
            dtpArriveDate.Value = currentObject.SUPPLY_DATE;
            cobPort.SelectedValue = currentObject.PORT_ID;
            txtVoyage.Text = currentObject.VOYAGE;

            txtCheckor.Text = currentObject.APPROVER;
            txtLeader.Text = currentObject.APPROVER2;
            txtLandChecker.Text = currentObject.CHECKED.Equals(0M) ? "未审核" : "已审核";
            txtRemark.Text = currentObject.REMARK;

        }

        private void updateObjectFromForm()
        {
            if (currentObject == null)
            {
                throw new Exception("错误，不应该出现无法识别申请单信息的情况!");
            }

            currentObject.APPLY_DATE = dtpApplyDate.Value;
            currentObject.SUPPLY_DATE = dtpArriveDate.Value;
            currentObject.PORT_ID = cobPort.SelectedValue.ToString();
            currentObject.VOYAGE = txtVoyage.Text;
            currentObject.REMARK = txtRemark.Text;
        }

        private bool checkingBeforeSave()
        {
            txtLeader.Focus();//避免刚刚填写的内容没有被截取到，换一下焦点.

            updateObjectFromForm();

            return true;
        }

        /// <summary>
        /// 保存申请单和明细单.
        /// </summary>
        private bool saveInfor()
        {
            string err;
            updateObjectFromForm();
            if (currentObject.Update(out err))
            {
                return saveDetails(out err);
            }
            else
            {
                MessageBoxEx.Show("当前对象保存失败,错误原因是:" + err, "错误", new MessageBoxButtons(), MessageBoxIcon.Error);
            }
            return false;
        }

        private bool saveDetails(out string err)
        {
            err = "";

            dgvMatApplyDetail.EndEdit();

            if (dgvMatApplyDetail.Rows.Count == 0) return true;
            //***************数据校验*****************************************************************************
            if (this.validateDet() == false)
            {
                return false;
            }
            //***************数据保存*****************************************************************************
            DataTable dtb = (DataTable)bindingSourceDetail.DataSource;//从BindingSource组件中取得信息集放到DataTable中去.

            //在保存数据时要保存两套：一套保存到表T_HOIL_APPLY_DETAIL中去.
            return commonOpt.SaveFormData(dtb, "T_HOIL_APPLY_DETAIL", 0, out err);//保存数据.
        }

        /// <summary>
        /// 滑油信息保存操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgSaveItem_Click(object sender, EventArgs e)
        {
            if (!checkingBeforeSave()) return;

            if (saveInfor())
            {
                MessageBoxEx.Show("操作成功!", "提示", new MessageBoxButtons(), MessageBoxIcon.Information);
                setBindingSourceDetail();//刷新当前明细列表.
            }
        }

        /// <summary>
        /// 申请单完成操作（只有完成的申请单才允许审核）.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgComplete_Click(object sender, EventArgs e)
        {
            if (dgvMatApplyDetail.Rows.Count == 0)
            {
                MessageBoxEx.Show("申请没有任何明细，不允许提交审核！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.validateDet() == false)
            {
                return;
            }

            if (!checkingBeforeSave()) return;

            if (MessageBoxEx.Show("是否提交审核？", "提示信息", MessageBoxButtons.YesNo,
MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
== System.Windows.Forms.DialogResult.No) return;


            if (saveInfor())
            {
                string sFrmErrMessage = "";                     //错误信息参数.
                string workFlowObjectName = "海丰润滑油申请";

                //执行提交操作.
                //审核通过后，如果是轮机长，则更新报表数据.
                if ("轮机长".Equals(CommonOperation.ConstParameter.LoginUserInfo.ShipHeadShipName))
                {
                    currentObject.APPROVER = CommonOperation.ConstParameter.UserName;
                }
                T_WorkFlowService.Instance.AgreeBusiness(currentObject.SHIP_ID, currentObject.GetId(), workFlowObjectName,false, out sFrmErrMessage);
                //更新结果报告.
                if (sFrmErrMessage.Equals(""))
                {
                    MessageBox.Show("提交成功！", "提交成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(sFrmErrMessage, "提交失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                currentObject.CHECKED = 1M;
                currentObject.Update(out sFrmErrMessage);
            }
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
        /// <summary>
        /// 设置物料申请单明细信息的bindingSource数据源，每次查询的都是指定申请单的明细信息数据.
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <param name="MaterialApplyId">申请单信息Id</param>
        private void setBindingSourceDetail()
        {
            DataTable dt = HOilApplyDetailService.Instance.GetApplyDataForSave(currentObject.GetId(),
                currentObject.SHIP_ID, dtpApplyDate.Value.AddMonths(-1));
            bindingSourceDetail.DataSource = dt;
            dgvMatApplyDetail.DataSource = bindingSourceDetail;
            this.setDataGridViewDetail();
        }

        /// <summary>
        /// 设物料明细信息网格控件dgvMatApplyDetail的隐藏列与显示标题.
        /// </summary>
        private void setDataGridViewDetail()
        {
            Dictionary<string, string> allColumns = new Dictionary<string, string>();
            allColumns.Add("OIL_FULL_NAME", "润滑油名称");
            allColumns.Add("THISMONTH_STORE", "上月库存量");
            allColumns.Add("NUM", "申请数量");
            allColumns.Add("remark", "备注");
            dgvMatApplyDetail.SetDgvGridColumns(allColumns);
            dgvMatApplyDetail.setDgvColumnsReadOnly(new string[] { "OIL_FULL_NAME", "THISMONTH_STORE" });
            dgvMatApplyDetail.LoadGridView("FrmOilApplyEdit.dgvMatApplyDetail");

        }

        /// <summary>
        /// 释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMaterialApply_FormClosing(object sender, FormClosingEventArgs e)
        {
            string err;
            dgvMatApplyDetail.SaveGridView("FrmOilApplyEdit.dgvMatApplyDetail");
            //清除大文档绑定功能.
            if (dgvMatApplyDetail.Rows.Count == 0)
            {
                if (MessageBoxEx.Show("没明细，保存吗?", "提示", MessageBoxButtons.OKCancel,
                     MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                {
                    currentObject.Delete(out err);
                }
            }
        }

        #region 申请单明细网格校验部分


        /// <summary>
        /// 明细数据保存时的校验函数.
        /// </summary>
        /// <returns>如果校验通过，返回true；否则返回false</returns>
        private bool validateDet()
        {

            if (dgvMatApplyDetail.HasEmptyVal("OIL_ID"))
            {
                MessageBoxEx.Show("油品是必选内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (dgvMatApplyDetail.HasRepliVal("OIL_ID"))
            {
                MessageBoxEx.Show("一个申请单中同一种润滑油申请明细记录只能有一条！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (dgvMatApplyDetail.HasEmptyVal("NUM") == true)
            {
                MessageBoxEx.Show("申请数量是必填内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dgvMatApplyDetail.IsNumeric("NUM") == false)
            {
                MessageBoxEx.Show("申请数量必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void dgvMatApplyDetail_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            float flt = 0.0f;

            //取DataGridView控件的当前列名赋给变量sColName
            string sColName = dgvMatApplyDetail.Columns[e.ColumnIndex].Name.ToLower();
            //取当前值赋给变量scurValue
            string sCurValue = e.FormattedValue.ToString().Trim();

            if (sColName.Equals("NUM") && sCurValue.Length == 0)
            {
                MessageBoxEx.Show("申请数量为必填项！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvMatApplyDetail.CurrentRow.Cells[sColName].Value = 1;
                e.Cancel = true;
                return;
            }
            if (sColName.Equals("NUM") && float.TryParse(sCurValue, out flt) == false)
            {
                MessageBoxEx.Show("申请数量必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvMatApplyDetail.CurrentRow.Cells[sColName].Value = 1;
                e.Cancel = true;
                return;
            }
            if (sColName.Equals("NUM") && float.Parse(sCurValue) < 0)
            {
                MessageBoxEx.Show("申请数量不能为负数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvMatApplyDetail.CurrentRow.Cells[sColName].Value = 1;
                e.Cancel = true;
                return;
            }
        }

        #endregion

        /// <summary>
        /// 删除明细.
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {

            string err = ""; //错误信息参数.
            if (dgvMatApplyDetail.CurrentCell != null)
            {

                if (MessageBoxEx.Show("确定要删除吗？", "删除提示", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }

                //取当前网格dgvMatApply中的申请单信息主键赋值给变量MaterialApplyId

                DataTable dt = (DataTable)bindingSourceDetail.DataSource;
                //删除当前记录.
                if (dt.Rows.Count > 0)
                {
                    string detailID = dt.Rows[dgvMatApplyDetail.CurrentCell.RowIndex]["APPLY_DETAIL_ID"].ToString();
                    HOilApplyDetailService.Instance.deleteUnit(detailID, out err);
                }

                dt.Rows.RemoveAt(dgvMatApplyDetail.CurrentCell.RowIndex);
                dgvMatApplyDetail.EndEdit();
                if (saveDetails(out err))
                {
                    MessageBoxEx.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!string.IsNullOrEmpty(err))//如果err为空,表示没有过了第一个检验,已经报错了,不需要再次报错.
                {
                    MessageBoxEx.Show("当前对象删除失败,错误原因是:" + err, "错误", new MessageBoxButtons(), MessageBoxIcon.Exclamation);
                }

                setBindingSourceDetail();//刷新当前明细列表.
            }
        }

        /// <summary>
        /// 增加明细.
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string shipId = CommonOperation.ConstParameter.ShipId;//取当前船舶Id

            int rowIndex = 0;
            if (dgvMatApplyDetail.Rows.Count > 0)
            {
                if (dgvMatApplyDetail.CurrentRow == null)
                {
                    rowIndex = dgvMatApplyDetail.Rows.Count;
                }
                else
                {
                    rowIndex = dgvMatApplyDetail.CurrentRow.Index + 1;
                }
            }
            DataTable dt = (DataTable)bindingSourceDetail.DataSource;
            dt.Rows.InsertAt(dt.NewRow(), rowIndex);
            //为明细列添加一个新的全球码号.
            dgvMatApplyDetail.Rows[rowIndex].Cells["APPLY_DETAIL_ID"].Value = Guid.NewGuid().ToString();
            dgvMatApplyDetail.Rows[rowIndex].Cells["APPLY_ID"].Value = currentObject.GetId();
            dgvMatApplyDetail.Rows[rowIndex].Cells["OIL_ID"].Value = "";

        }

        private void dgvMatApplyDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvMatApplyDetail.Columns["OIL_ID"].Index
                && !string.IsNullOrEmpty(dgvMatApplyDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
            {
                SetLastMonthLeft();
            }
        }

        private void dtpApplyDate_ValueChanged(object sender, EventArgs e)
        {
            SetLastMonthLeft();
        }
        private void SetLastMonthLeft()
        {
            string err;
            foreach (DataGridViewRow item in dgvMatApplyDetail.Rows)
            {
                string oilID = item.Cells["OIL_ID"].Value.ToString();
                if (string.IsNullOrEmpty(oilID))
                    continue;
                DataTable dt = HOilLuboilConsumeService.Instance.GetInfoByMonthOil(
                    currentObject.SHIP_ID, dtpApplyDate.Value.AddMonths(-1), oilID, out err);
                if (dt.Rows.Count > 0)
                    item.Cells["THISMONTH_STORE"].Value = dt.Rows[0]["THISMONTH_STORE"].ToString();
                else
                    item.Cells["THISMONTH_STORE"].Value = DBNull.Value;
            }
        }
    }
}