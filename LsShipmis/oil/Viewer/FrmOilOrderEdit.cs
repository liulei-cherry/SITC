/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmOilOrderEdit.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-08-01
 * 标    题：编辑订购业务窗体
 * 功能描述：
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
    /// 订购编辑业务窗体.
    /// </summary>
    public partial class FrmOilOrderEdit : CommonViewer.BaseForm.FormBase
    {

        #region 窗体对象

        private HOilOrder currentObject;
        public HOilOrder CurrentObject
        {
            get { return currentObject; }
            set
            {
                currentObject = value;
            }
        }

        private HOilApply currentApply;
        public HOilApply CurrentApply
        {
            get { return currentApply; }
            set
            {
                currentApply = value;
            }
        }

        #endregion

        # region 业务对象和类

        private IDBOperation commonOpt = CommonOperation.Functions.InterfaceInstantiation.NewADBOperation();//定义一个公共类CommonOpt对象.
        private FormControlOption other = FormControlOption.Instance;
        bool isFirstLoadMain = true;
        bool isFirstLoadSub = true;

        private DataTable dtb2;//润滑油油品.
        private DataTable dtb5;//币种.

        Dictionary<string, string> dictColumns = new Dictionary<string, string>();



        #endregion

        /// <summary>
        /// 构造函数，默认就是新订单.
        /// </summary>
        public FrmOilOrderEdit()
        {
            InitializeComponent();
        }

        public FrmOilOrderEdit(HOilOrder tempObject)
        {
            InitializeComponent();

            //陆地端和船舶端按钮功能不同.
            if (!CommonOperation.ConstParameter.IsLandVersion)
            {
                btnAdd.Enabled = false;
                bdNgSaveItem.Enabled = false;
                cboApply.Enabled = false;
                btnDown.Visible = false;
            }
            else
            {
                bdNgComplete.Visible = !(tempObject.CHECKED == 3M);
            }

            //订单对应申请单.
            if (tempObject.APPLY_ID != null)
            {
                cboApply.SelectedValue = tempObject.APPLY_ID;
            }
            CurrentObject = tempObject;
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMaterielApplyEdit_Load(object sender, EventArgs e)
        {
            ucManufacturerSelect1.ChangeMode(true, false, false);
            setComboBox();

            mainData();     //主信息显示.

            subData(currentObject.GetId());//明细信息列表.
        }

        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {
            string err = "";

            //已批准的申请单列表.
            DataTable dtb3 = HOilApplyService.Instance.GetApply(currentObject.SHIP_ID);
            other.SetComboBoxValue(cboApply, dtb3);

            //滑油.
            dtb2 = HOilService.Instance.GetShipLubOil(currentObject.SHIP_ID);

            //港口.
            DataTable dtb1 = PortInfoService.Instance.getInfo(out err);
            other.SetComboBoxValue(cobPort, dtb1);
            //币种.
            dtb5 = CurrencyService.Instance.getInfo(out err);
        }

        /// <summary>
        /// 绑定窗体控件（订购单信息控件的绑定）.
        /// </summary>
        private void mainData()
        {
            string err;
            //如果订单不存在，则新建立一个。.
            if (currentObject.ORDER_ID == null)
            {
                currentObject.PORT_ID = cobPort.SelectedValue.ToString();
                currentObject.SUPPLIER_ID = ucManufacturerSelect1.GetId();
                currentObject.Update(out err);
            }

            showDataToForm();
        }

        private void showDataToForm()
        {
            if (currentObject == null)
            {
                throw new Exception("错误，订单不存在!");
            }

            dtpApplyDate.Value = currentObject.ORDER_DATE;
            dtpArriveDate.Value = currentObject.SUPPLY_DATE;
            cobPort.SelectedValue = currentObject.PORT_ID;
            ucManufacturerSelect1.SelectedId(currentObject.SUPPLIER_ID);
            txtLandChecker.Text = currentObject.APPROVER;
            txtRemark.Text = currentObject.REMARK;
        }

        private void updateObjectFromForm()
        {
            if (currentObject == null)
            {
                throw new Exception("错误，订单不存在!");
            }

            currentObject.ORDER_DATE = dtpApplyDate.Value;
            currentObject.SUPPLY_DATE = dtpArriveDate.Value;
            currentObject.PORT_ID = cobPort.SelectedValue == null ? "" : cobPort.SelectedValue.ToString();
            currentObject.SUPPLIER_ID = ucManufacturerSelect1.GetId();
            currentObject.APPROVER = txtLandChecker.Text;
            currentObject.REMARK = txtRemark.Text;
            currentObject.APPLY_ID = cboApply.SelectedValue == null ? "" : cboApply.SelectedValue.ToString();
        }

        private bool checkingBeforeSave()
        {
            if (cobPort.SelectedValue == null)
            {
                MessageBoxEx.Show("必须选择港口！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrEmpty(ucManufacturerSelect1.GetId()))
            {
                MessageBoxEx.Show("必须选择供应商！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            updateObjectFromForm();

            return true;
        }

        /// <summary>
        /// 保存订购单和明细单.
        /// </summary>
        private bool saveInfor()
        {
            string err;
            updateObjectFromForm();
            if (currentObject.Update(out err))
            {
                if (CurrentApply != null)
                {
                    CurrentApply.CHECKED = 9;
                    CurrentApply.Update(out err);
                    return saveDetails(out err);
                }
                return true;
            }
            else
            {
                MessageBoxEx.Show(err, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            DataTable dtb = (DataTable)dgvMatApplyDetail.DataSource;//从BindingSource组件中取得信息集放到DataTable中去.

            //在保存数据时要保存两套：一套保存到表T_HOIL_APPLY_DETAIL中去.
            return commonOpt.SaveFormData(dtb, "T_HOIL_ORDER_DETAIL", 0, out err);//保存数据.
        }

        /// <summary>
        /// 滑油信息保存操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgSaveItem_Click(object sender, EventArgs e)
        {
            if (this.validateDet() == false)
            {
                return;
            }

            if (!checkingBeforeSave()) return;

            if (saveInfor())
            {
                MessageBoxEx.Show("操作成功！", "提示", new MessageBoxButtons(), MessageBoxIcon.Information);
                this.Close();
            }
        }

        /// <summary>
        /// 订购单完成并审批通过.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgComplete_Click(object sender, EventArgs e)
        {
            if (dgvMatApplyDetail.Rows.Count == 0)
            {
                MessageBoxEx.Show("订购没有任何明细，不允许提交审核！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            string err;
            if (saveInfor())
            {
                string sFrmErrMessage = "";                     //错误信息参数.

                if ("财务经理岗位" == CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)
                    currentObject.CHECKED = 5;
                else
                    currentObject.CHECKED = 1;

                currentObject.Update(out sFrmErrMessage);
                if (sFrmErrMessage.Equals(""))
                {
                    T_WorkFlowService.Instance.AgreeBusiness(null, currentObject.GetId(), "油料订单审核流程",false, out err);
                    MessageBox.Show("提交成功！", "提交成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(sFrmErrMessage, "提交失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }


        private void btnPass_Click(object sender, EventArgs e)
        {
            if (dgvMatApplyDetail.Rows.Count == 0)
            {
                MessageBoxEx.Show("订购没有任何明细，不允许提交审核！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.validateDet() == false)
            {
                return;
            }

            if (!checkingBeforeSave()) return;

            if (MessageBoxEx.Show("本次盘点是否审核通过？", "提示信息", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.No) return;

            string err;
            if (saveInfor())
            {
                string sFrmErrMessage = "";                     //错误信息参数.
                currentObject.CHECKED = 5;
                currentObject.Update(out sFrmErrMessage);
                if (sFrmErrMessage.Equals(""))
                {
                    T_WorkFlowService.Instance.AgreeBusiness(currentObject.SHIP_ID, currentObject.GetId(), "油料订单审核流程", true, out err);
                    MessageBox.Show("审核通过！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(sFrmErrMessage, "提交失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        /// <summary>
        /// 列出明细信息.
        /// </summary>
        private void subData(string OrderId)
        {
            dgvMatApplyDetail.AllowUserToAddRows = false;
            dgvMatApplyDetail.AutoGenerateColumns = false;

            DataTable dt = HOilOrderDetailService.Instance.GetOrderDataForSave(OrderId);
            dgvMatApplyDetail.DataSource = dt;

            //加载主列项.
            if (isFirstLoadSub)
            {
                this.setDataGridViewDetail();
            }

        }

        /// <summary>
        /// 设物料明细信息网格控件dgvMatApplyDetail的隐藏列与显示标题.
        /// </summary>
        private void setDataGridViewDetail()
        {
            DataGridViewComboBoxColumn cmbox = new DataGridViewComboBoxColumn();
            cmbox.DataSource = dtb2.DefaultView;
            cmbox.DataPropertyName = "OIL_ID";
            cmbox.DisplayMember = "OIL_FULL_NAME";
            cmbox.ValueMember = "OIL_ID";
            cmbox.Width = 260;
            cmbox.HeaderText = "润滑油名称";
            dgvMatApplyDetail.Columns.Add(cmbox);

            DataGridViewColumn col5 = new DataGridViewTextBoxColumn();
            col5.DataPropertyName = "NUM";
            col5.Name = "NUM";

            col5.HeaderText = "订购数量";
            dgvMatApplyDetail.Columns.Add(col5);

            DataGridViewColumn col7 = new DataGridViewTextBoxColumn();
            col7.DataPropertyName = "CURRENCY_ID";
            col7.Name = "CURRENCY_ID";
            col7.Visible = false;
            dgvMatApplyDetail.Columns.Add(col7);

            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                //DataGridViewComboBoxColumn cmbox2 = new DataGridViewComboBoxColumn();
                //cmbox2.DataSource = dtb5.DefaultView;
                //cmbox2.DataPropertyName = "CURRENCY_ID";
                //cmbox2.DisplayMember = "CURRENCYNAME";
                //cmbox2.ValueMember = "CURRENCYID";
                //cmbox2.HeaderText = "币种";
                //dgvMatApplyDetail.Columns.Add(cmbox2);

                DataGridViewTextBoxColumn cmbox2 = new DataGridViewTextBoxColumn();
                cmbox2.DataPropertyName = "CURRENCY_ID";
                cmbox2.Name = "CURRENCY_ID";
                cmbox2.Visible = false;
                dgvMatApplyDetail.Columns.Add(cmbox2);

                DataGridViewTextBoxColumn cmbox22 = new DataGridViewTextBoxColumn();
                cmbox22.DataPropertyName = "CURRENCYNAME";
                cmbox22.Name = "CURRENCY_NAME";
                cmbox22.HeaderText = "币种";
                dgvMatApplyDetail.Columns.Add(cmbox22);

                cboCURRENCY.DataSource = dtb5;
                cboCURRENCY.DisplayMember = "CURRENCYNAME";
                cboCURRENCY.ValueMember = "CURRENCYID";
                DgvBindDrop dgvBindDrop1 = new DgvBindDrop();
                dgvBindDrop1.bindDropToDgv(dgvMatApplyDetail, cboCURRENCY, 4, false, 1);

                DataGridViewColumn col8 = new DataGridViewTextBoxColumn();
                col8.DataPropertyName = "AMOUNT";
                col8.Name = "AMOUNT";
                col8.HeaderText = "金额数量";
                dgvMatApplyDetail.Columns.Add(col8);
            }
            else
            {
                DataGridViewColumn col8 = new DataGridViewTextBoxColumn();
                col8.DataPropertyName = "AMOUNT";
                col8.Name = "AMOUNT";
                col8.Visible = false;
                dgvMatApplyDetail.Columns.Add(col8);
            }

            DataGridViewColumn col1 = new DataGridViewTextBoxColumn();
            col1.DataPropertyName = "ORDER_DETAIL_ID";
            col1.Name = "ORDER_DETAIL_ID";
            col1.Visible = false;
            dgvMatApplyDetail.Columns.Add(col1);

            DataGridViewColumn col2 = new DataGridViewTextBoxColumn();
            col2.DataPropertyName = "ORDER_ID";
            col2.Name = "ORDER_ID";
            col2.Visible = false;
            dgvMatApplyDetail.Columns.Add(col2);

            DataGridViewColumn col3 = new DataGridViewTextBoxColumn();
            col3.DataPropertyName = "OIL_ID";
            col3.Name = "OIL_ID";
            col3.Visible = false;
            dgvMatApplyDetail.Columns.Add(col3);

            isFirstLoadSub = false;

        }

        /// <summary>
        /// 释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmOilOrderEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            string err;
            //清除大文档绑定功能.
            if (dgvMatApplyDetail.Rows.Count == 0)
            {
                if (MessageBoxEx.Show("没有添加任何订购条目，请确认是否保存当前信息，\r保存请按【是】不保存请按【否】", "提示", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.No)
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

            if (dgvMatApplyDetail.HasRepliVal("OIL_ID"))
            {
                MessageBoxEx.Show("一个订购单中同一种润滑油明细记录只能有一条！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (dgvMatApplyDetail.HasEmptyVal("CURRENCY_ID") == true)
            {
                MessageBoxEx.Show("币种是必填内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dgvMatApplyDetail.HasEmptyVal("NUM") == true)
            {
                MessageBoxEx.Show("数量是必填内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dgvMatApplyDetail.IsNumeric("NUM") == false)
            {
                MessageBoxEx.Show("数量必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dgvMatApplyDetail.HasEmptyVal("AMOUNT") == true)
            {
                MessageBoxEx.Show("金额是必填内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dgvMatApplyDetail.IsNumeric("AMOUNT") == false)
            {
                MessageBoxEx.Show("金额必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBoxEx.Show("数量为必填项！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvMatApplyDetail.CurrentRow.Cells[sColName].Value = 1;
                e.Cancel = true;
                return;
            }
            if (sColName.Equals("NUM") && float.TryParse(sCurValue, out flt) == false)
            {
                MessageBoxEx.Show("数量必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvMatApplyDetail.CurrentRow.Cells[sColName].Value = 1;
                e.Cancel = true;
                return;
            }
            if (sColName.Equals("NUM") && float.Parse(sCurValue) < 0)
            {
                MessageBoxEx.Show("数量不能为负数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvMatApplyDetail.CurrentRow.Cells[sColName].Value = 1;
                e.Cancel = true;
                return;
            }

            if (sColName.Equals("AMOUNT") && float.TryParse(sCurValue, out flt) == false)
            {
                MessageBoxEx.Show("数量必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvMatApplyDetail.CurrentRow.Cells[sColName].Value = 1;
                e.Cancel = true;
                return;
            }

        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowIndex">第几行</param>
        /// <param name="state">哪种状态，0,不允许修改的，1,手写的</param>
        private void singleLineEditStatusSetting(int rowIndex, int state)
        {
            if (rowIndex < 0 || dgvMatApplyDetail.Rows.Count < rowIndex)
            {
                return;
            }
            //    cellStyleSetting(dgvMatApplyDetail.Rows[rowIndex].Cells["OIL_NAME"], state != 1);//物料名称.
        }
        private void cellStyleSetting(DataGridViewCell dgvc, bool ifReadOnly)
        {
            dgvc.ReadOnly = ifReadOnly;
            dgvc.Style.BackColor = (ifReadOnly ? Color.Linen : Color.White);
        }

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

                //取当前网格dgvMatApply中的申请单信息主键赋值给变量MaterielApplyId
                DataTable dt = (DataTable)dgvMatApplyDetail.DataSource;
                //删除当前记录.
                if (dt.Rows.Count > 0)
                {
                    string detailID = dt.Rows[dgvMatApplyDetail.CurrentCell.RowIndex]["ORDER_DETAIL_ID"].ToString();
                    HOilOrderDetailService.Instance.deleteUnit(detailID, out err);
                }

                dt.Rows.RemoveAt(dgvMatApplyDetail.CurrentCell.RowIndex);
                dgvMatApplyDetail.EndEdit();

                if (saveDetails(out err))
                {
                    MessageBoxEx.Show("删除成功！", "删除成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBoxEx.Show(err, "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                subData(currentObject.ORDER_ID);//刷新当前明细列表.
            }
        }

        /// <summary>
        /// 增加明细.
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string shipId = currentObject.SHIP_ID;//取当前船舶Id

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
            DataTable dt = (DataTable)dgvMatApplyDetail.DataSource;
            dt.Rows.InsertAt(dt.NewRow(), rowIndex);

            //       singleLineEditStatusSetting(rowIndex, 1);
            //为明细列添加一个新的全球码号.
            dgvMatApplyDetail.Rows[rowIndex].Cells["ORDER_DETAIL_ID"].Value = Guid.NewGuid().ToString();
            dgvMatApplyDetail.Rows[rowIndex].Cells["ORDER_ID"].Value = currentObject.GetId();
            dgvMatApplyDetail.Rows[rowIndex].Cells["OIL_ID"].Value = "";
        }

        /// <summary>
        /// 申请单选择事件.
        /// </summary>
        private void cboApply_SelectedValueChanged(object sender, EventArgs e)
        {
            loadMainData();//申请单明细信息.
        }

        /// <summary>
        /// 加载申请单明细信息.
        /// </summary>
        public void loadMainData()
        {
            //获得申请ID
            if (cboApply.SelectedValue == null || cboApply.SelectedValue.ToString() == "System.Data.DataRowView") return;
            string applyID = cboApply.SelectedValue.ToString();
            string err = "";
            CurrentApply = HOilApplyService.Instance.getObject(applyID, out err);

            DataTable dtb = HOilApplyDetailService.Instance.GetApplyDatas(CurrentApply.APPLY_ID, CurrentApply.SHIP_ID, CurrentApply.APPLY_DATE);
            //datatable 增加复选列.
            dgvApplyDetail.DataSource = dtb;

            //加载主列项.
            if (isFirstLoadMain)
            {
                loadDataCol();
            }

            //设置列只读.
            string[] sCols = new string[] { "TRADEMARK", "OIL_NAME", "NUM", "REMARK" };
            dgvApplyDetail.setDgvCellReadOnly("APPLY_DETAIL_ID", sCols);
        }

        /// <summary>
        /// 设置主列项.
        /// </summary>
        private void loadDataCol()
        {
            dictColumns.Clear();
            //设置列标题.
            dictColumns.Add("TRADEMARK", "牌号");
            dictColumns.Add("OIL_NAME", "滑油名称");
            dictColumns.Add("NUM", "申请数量");
            dictColumns.Add("remark", "备注");
            dgvApplyDetail.SetDgvGridColumns(dictColumns, "check");
            dgvApplyDetail.Columns["TRADEMARK"].Width = 200;
            dgvApplyDetail.Columns["OIL_NAME"].Width = 200;
            dgvApplyDetail.Columns["NUM"].Width = 70;
            dgvApplyDetail.Columns["remark"].Width = 300;
            dgvApplyDetail.Columns["check"].Width = 25;

            isFirstLoadMain = false;
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            string err = "";
            if (dgvApplyDetail.DataSource == null) return;

            List<string> lstID = new List<string>();
            foreach (DataGridViewRow item in dgvApplyDetail.Rows)
            {
                if (item.Cells["check"].Value != null)
                {
                    lstID.Add(item.Cells["APPLY_DETAIL_ID"].Value.ToString());
                }
            }

            if (lstID.Count == 0)
            {
                MessageBoxEx.Show("请先选中申请单明细!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!HOilOrderDetailService.Instance.applyToOrder(currentObject.GetId(), lstID, out err))
            {
                MessageBoxEx.Show(err, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                loadMainData();         //刷新列表.
                subData(currentObject.GetId());
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

        private void cboCURRENCY_SelectedIndexChanged(object sender, EventArgs e)
        {
            string CURRENCY_ID = "";
            string CURRENCY_NAME = "";
            if (cboCURRENCY.SelectedValue != null)
            {
                CURRENCY_ID = cboCURRENCY.SelectedValue.ToString();
                CURRENCY_NAME = cboCURRENCY.Text;
            }
            for (int i = 0; i < dgvMatApplyDetail.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dgvMatApplyDetail.Rows[i].Cells["CURRENCY_ID"].Value.ToString()))
                {
                    dgvMatApplyDetail.Rows[i].Cells["CURRENCY_ID"].Value = CURRENCY_ID;
                    dgvMatApplyDetail.Rows[i].Cells["CURRENCY_NAME"].Value = CURRENCY_NAME;
                }
            }
        }


    }
}