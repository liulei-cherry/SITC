/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmData.cs
 * 创 建 人：李景育
 * 创建时间：2007-06-20
 * 标    题：资料借阅业务窗体
 * 功能描述：实现资料借阅业务窗体上的相关功能
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
using SeaChartManage.Services;
using CommonViewer.BaseControlService;
using CommonOperation.Interfaces;
using CommonViewer.BaseForm;
using CommonViewer.BaseControl;

namespace SeaChartManage.Forms
{
    /// <summary>
    /// 资料借阅业务窗体.
    /// </summary>
    public partial class FrmData : CommonViewer.BaseForm.FormBase
    {
        private IDBOperation commonOpt = CommonOperation.Functions.InterfaceInstantiation.NewADBOperation();//定义一个公共类CommonOpt对象.

        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmData instance = new FrmData();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmData Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmData.instance = new FrmData();
                }

                return FrmData.instance;
            }
        }

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmData()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体启动时的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmData_Load(object sender, EventArgs e)
        {
            this.setComboBox();     //设置窗体所需的下拉列表框的数据源.
            this.setBindingSource();//设置数据源.
            this.setDataGridView(); //设置网格控件dgvMain一些的隐藏与列标头的设置.
            this.bindingCtrols();   //绑定窗体控件.
            this.WindowState = FormWindowState.Maximized;//窗体最大化.
        }

        /// <summary>
        /// 设置bindingSource为数据源.
        /// </summary>
        private void setBindingSource()
        {
            DataTable dtbData = DataService.GetData();
            bindingSourceMain.DataSource = dtbData; 
            dgvMain.DataSource = bindingSourceMain;
           
            //如果当前没有数据，则输入框区域的控件为不可用状态；否则为可用状态。.
            if (dgvMain.Rows.Count > 0)
            {
                FormControlOption.Instance.EnableOrDisableCtrls(tableLayoutPanel2, true);
            }
            else
            {
                FormControlOption.Instance.EnableOrDisableCtrls(tableLayoutPanel2, false);
            }

            chkReturn.Enabled = false;
        }

        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {
            DataTable dtbDataName = DataService.GetDataName();
            cboDataStock.DataSource = dtbDataName;
            cboDataStock.DisplayMember = "data_name";
            cboDataStock.ValueMember = "data_stock_id";
        }

        /// <summary>
        /// 设置dgvMain的隐藏列与显示标题.
        /// </summary>
        private void setDataGridView()
        {
            dgvMain.Columns["data_id"].Visible = false;
            dgvMain.Columns["data_stock_id"].Visible = false;
            dgvMain.Columns["return_flag"].Visible = false;
            dgvMain.Columns["data_name"].HeaderText = "资料名称";
            dgvMain.Columns["apply_date"].HeaderText = "申请日期";
            dgvMain.Columns["catch_date"].HeaderText = "领取日期";
            dgvMain.Columns["end_date"].HeaderText = "返还日期";
            dgvMain.Columns["apply_persorn"].HeaderText = "申领人";
            dgvMain.Columns["return_name"].HeaderText = "已返还";
            dgvMain.Columns["data_remark"].HeaderText = "备注";
        }

        /// <summary>
        /// 绑定窗体上的控件.
        /// </summary>
        private void bindingCtrols()
        {
            cboDataStock.DataBindings.Add("Tag", bindingSourceMain, "data_id", true);
            cboDataStock.DataBindings.Add("SelectedValue", bindingSourceMain, "data_stock_id", true);
            txtApplyDate.TextBox.DataBindings.Add("Text", bindingSourceMain, "apply_date", true);
            txtCatchDate.TextBox.DataBindings.Add("Text", bindingSourceMain, "catch_date", true);
            txtEndDate.TextBox.DataBindings.Add("Text", bindingSourceMain, "end_date", true);
            txtApplyPerson.DataBindings.Add("Text", bindingSourceMain, "apply_persorn", true);
            txtRemark.DataBindings.Add("Text", bindingSourceMain, "data_remark", true);
            chkReturn.DataBindings.Add("Checked", bindingSourceMain, "return_flag", true);
        }

        /// <summary>
        /// 添加记录.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            bindingSourceMain.AddNew();
            cboDataStock.Tag = Guid.NewGuid().ToString();//产生主键值.
            if (cboDataStock.SelectedValue != null) cboDataStock.SelectedIndex = 0;

            chkReturn.Checked = false;

            //如果当前数据为空（主网格控件行数 = 1说明是刚添加的空行），则把输入区域的控件设置为可用状态。.
            if (dgvMain.Rows.Count == 1)
            {
                FormControlOption.Instance.EnableOrDisableCtrls(tableLayoutPanel2, true);
            }

            bdNgAddNewItem.Enabled = false;//把bdNgAddNewItem.Enabled设置为false是为了防止连续添加.
            bdNgReturn.Enabled = false;
            chkReturn.Enabled = false;
            cboDataStock.Enabled = true;
        }

        /// <summary>
        /// 删除操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.

            if (bindingSourceMain.Current != null)
            {               
                if (MessageBoxEx.Show("确定要删除吗？", "删除提示", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }

                bindingSourceMain.RemoveCurrent();
                bindingSourceMain.EndEdit();
                DataTable dtb = (DataTable)bindingSourceMain.DataSource;//从BindingSource组件中取得信息集放到DataTable中去.

                //更新结果报告.
                if (commonOpt.SaveFormData(dtb, "T_Data", 0, out err))
                {
                    MessageBoxEx.Show("删除成功！", "删除成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBoxEx.Show(err, "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
              
                //如果当前没有数据，则输入框区域的控件为不可用状态；否则为可用状态。.
                if (dgvMain.Rows.Count > 0)
                {
                    FormControlOption.Instance.EnableOrDisableCtrls(tableLayoutPanel2, true);
                }
                else
                {
                    FormControlOption.Instance.EnableOrDisableCtrls(tableLayoutPanel2, false);
                }
            }

            bdNgAddNewItem.Enabled = true;
            cboDataStock.Enabled = false;
            bdNgReturn.Enabled = true;
            chkReturn.Enabled = false;
        }

        /// <summary>
        /// 取消操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgCancelItem_Click(object sender, EventArgs e)
        {
            bindingSourceMain.CancelEdit();
            this.setBindingSource();
            bdNgAddNewItem.Enabled = true;
            bdNgReturn.Enabled = true;
            cboDataStock.Enabled = false;
        }

        /// <summary>
        /// 保存操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgSaveItem_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.
            string dataStockId = "";    //资料库存Id
            int dataStockNumb = 0;      //资料当前库存数量.

            //***************数据校验*****************************************************************************
            if (bindingSourceMain.Count == 0)
            {
                MessageBoxEx.Show("无可保存的记录！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboDataStock.Text == "")
            {
                MessageBoxEx.Show("申请资料是必选内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboDataStock.Focus();
                return;
            }

            if (txtApplyDate.TextBox.Text.Trim().Length == 0)
            {
                MessageBoxEx.Show("申请日期是必填内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApplyDate.Focus();
                return;
            }
            if (txtCatchDate.TextBox.Text.Trim().Length == 0)
            {
                MessageBoxEx.Show("领取日期是必填内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCatchDate.Focus();
                return;
            }
            if (DateTime.Parse(txtCatchDate.TextBox.Text) < DateTime.Parse(txtApplyDate.TextBox.Text))
            {
                MessageBoxEx.Show("领取日期不能小于申请日期！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCatchDate.Focus();
                return;
            }
            if (txtEndDate.TextBox.Text != "" && DateTime.Parse(txtEndDate.TextBox.Text) < DateTime.Parse(txtCatchDate.TextBox.Text))
            {
                MessageBoxEx.Show("返还日期不能小于领取日期！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEndDate.Focus();
                return;
            }
            if (txtApplyPerson.Text.Trim().Length == 0)
            {
                MessageBoxEx.Show("申请人是必填内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApplyPerson.Focus();
                return;
            }

            dataStockId = cboDataStock.SelectedValue.ToString();
            dataStockNumb = DataService.GetDataStockNumb(dataStockId);
            if(!bdNgAddNewItem.Enabled && dataStockNumb <= 0)
            {
                MessageBoxEx.Show("当前资料已经没有库存！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (chkReturn.Checked)
            {
                MessageBoxEx.Show("当前资料已经返还，不能再编辑信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //***************数据保存*****************************************************************************
            bindingSourceMain.EndEdit();
            DataTable dtb = (DataTable)bindingSourceMain.DataSource;//从BindingSource组件中取得信息集放到DataTable中去.

            //更新结果报告.
            if (DataService.SaveData(dtb, dataStockId, out err))
            {
                //保存数据后刷新BindingSource数据源组件.
                this.setBindingSource();
                MessageBoxEx.Show("数据保存成功！", "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBoxEx.Show(err, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            bdNgAddNewItem.Enabled = true;
            bdNgReturn.Enabled = true;
            chkReturn.Enabled = false;
            cboDataStock.Enabled = false;
        }

        /// <summary>
        /// 资料的返还.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgReturn_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.
            string dataStockId = "";    //资料库存Id
            string dataId = "";         //资料借阅信息Id
            string endDate = "";        //返还日期.

            if (bindingSourceMain.Count == 0)
            {
                MessageBoxEx.Show("无可返还的信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtEndDate.TextBox.Text.Trim().Length == 0)
            {
                MessageBoxEx.Show("返还日期是必填内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEndDate.Focus();
                return;
            }
            if (txtEndDate.TextBox.Text != "" && DateTime.Parse(txtEndDate.TextBox.Text) < DateTime.Parse(txtCatchDate.TextBox.Text))
            {
                MessageBoxEx.Show("返还日期不能小于领取日期！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEndDate.Focus();
                return;
            }

            if (chkReturn.Checked)
            {
                MessageBoxEx.Show("当前资料已经返还，不能重复操作！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dataStockId = cboDataStock.SelectedValue.ToString();
            dataId = dgvMain.CurrentRow.Cells["data_id"].Value.ToString();
            endDate = txtEndDate.TextBox.Text;

            //更新结果报告.
            if (DataService.DataReturn(dataId, endDate, dataStockId, out err))
            {
                //保存数据后刷新BindingSource数据源组件.
                this.setBindingSource();
                MessageBoxEx.Show("操作成功！", "操作成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBoxEx.Show(err, "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            bdNgAddNewItem.Enabled = true;
            bdNgReturn.Enabled = true;
            chkReturn.Enabled = false;
            cboDataStock.Enabled = false;
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
        /// 关闭窗体时释放资料.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmData_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;    //释放窗体实例变量.
        } 
    }
}