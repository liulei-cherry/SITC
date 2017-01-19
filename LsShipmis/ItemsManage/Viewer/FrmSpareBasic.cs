/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmSpareBasic.cs
 * 创 建 人：徐正本
 * 创建时间：2010-8-1
 * 标    题：备件基础信息业务窗体
 * 功能描述：实现岸端备件基础信息业务窗体上的相关功能
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
using CommonViewer.BaseForm;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using ItemsManage.Services;
using FileOperation.Forms;
using BaseInfo.DataAccess;
using CommonViewer.BaseControl;

namespace ItemsManage.Viewer.Forms
{
    /// <summary>
    /// 备件基础信息业务窗体.
    /// </summary>
    public partial class FrmSpareBasic : CommonViewer.BaseForm.FormBase
    {
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        //用于快速搜索的参数.
        private string toSpareId;
        public List<string> SelectedSpareIds = new List<string>();
        public bool Selected = false;
        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmSpareBasic()
        {
            InitializeComponent();
        }
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmSpareBasic instance = new FrmSpareBasic();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmSpareBasic Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmSpareBasic.instance = new FrmSpareBasic();
                }

                return FrmSpareBasic.instance;
            }
        }

        #endregion
        /// <summary>
        /// 构造函数,快速定位模式.
        /// </summary>
        public FrmSpareBasic(string spareid)
        {
            InitializeComponent();
            toSpareId = spareid;
        }

        private void enableEdit(bool canEdit)
        {
            txtSpareName.ReadOnly = !canEdit;
            txtSpareEName.ReadOnly = !canEdit;
            txtPartNumber.ReadOnly = !canEdit;
            txtPartNumberHis1.ReadOnly = !canEdit;
            txtPartNumberHis2.ReadOnly = !canEdit;
            txtPicNumber.ReadOnly = !canEdit;
            txtPicCode.ReadOnly = !canEdit;
            txtAlertStock.ReadOnly = !canEdit;
            txtSpareStuff.ReadOnly = !canEdit;
            txtRemark.ReadOnly = !canEdit;
        }

        public FrmSpareBasic(bool toSelect)
        {
            InitializeComponent();
            if (toSelect)
                btnFastSelect.Visible = true;
            rdoUnbind.Checked = true;
        }
        private void scrollToSpareBaseInfo(string spareid)
        {
            try
            {
                for (int i = 0; i < dgvSpare.Rows.Count; i++)
                {
                    if (dgvSpare.Rows[i].Cells["spare_id"].Value.ToString().ToUpper() == spareid.ToUpper())
                    {
                        dgvSpare.CurrentCell = dgvSpare.Rows[i].Cells[dgvSpare.FirstDisplayedCell.ColumnIndex];
                        return;
                    }
                }
                dgvSpare.Rows[0].Cells[dgvSpare.FirstDisplayedCell.ColumnIndex].Selected = true;
            }
            catch { }//此处不捕获错误.
        }
        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSpareBasic_Load(object sender, EventArgs e)
        {
            this.setBindingSource();//设置数据源.
            this.setDataGridView(); //设置网格控件dgvSpApply的隐藏列与标头的设置.
            bindingCtrols();
            if (!string.IsNullOrEmpty(toSpareId))
            {
                scrollToSpareBaseInfo(toSpareId);
            }
            if (btnFastSelect.Visible)
            {
                checkBox1.Visible = true;
                //为dgv添加一个多选列，可以一下选择一堆.
                DataGridViewColumn toSelect = new DataGridViewColumn(new DataGridViewCheckBoxCell());
                toSelect.Name = "selected";
                toSelect.HeaderText = "";
                toSelect.DisplayIndex = 0;
                toSelect.ReadOnly = false;
                toSelect.Width = 30;
                dgvSpare.Columns.Add(toSelect);
            }
            else
            {
                checkBox1.Visible = false;
                label6.Location = new Point(label6.Location.X, label6.Location.Y + 15);
                textBox1.Location = new Point(textBox1.Location.X, textBox1.Location.Y + 15);
            }
            ucSpareInWhich1.SetSpareId = getSpareId;
        }

        public string getSpareId()
        {
            if (txtSpareName.Tag != null)
                return txtSpareName.Tag.ToString();
            else return "";
        }
        /// <summary>
        /// 设置备件基础信息的bindingSource数据源。.
        /// </summary>
        private void setBindingSource()
        {

            DataTable dtbSpareBasic;
            string err;
            if (!SpareInfoService.Instance.GetSpareBasic(out dtbSpareBasic, out err))
                throw new Exception("获取备件基本信息是出错。更多信息请参考：\r" + err);//取得备件基础信息的DataTable对象.
            bindingSourceMain.DataSource = dtbSpareBasic;//备件基础信息的数据源设置.
            dgvSpare.DataSource = bindingSourceMain;
            retrieveData();

        }

        private void retrieveData()
        {
            int bindmark = 0;
            if (rdoIsBind.Checked)
            {
                bindingSourceMain.CancelEdit();
                bindmark = 1;
            }
            else if (rdoUnbind.Checked)
            {
                bindmark = 0;
            }
            string filter = "bindmark=" + bindmark.ToString();

            //如果当前没有数据，则输入框区域的控件为不可用状态；否则为可用状态。.
            if (textBox1.Text.Length > 0 && bindingSourceMain != null)
            {
                bindingSourceMain.Filter = filter + " and (spare_name like '%" + textBox1.Text.Replace("'", "''")
                     + "%' or picnumber like '%" + textBox1.Text.Replace("'", "''")
                    + "%' or partnumber like '%" + textBox1.Text.Replace("'", "''")
                     + "%' or partnumber_his1 like '%" + textBox1.Text.Replace("'", "''")
                      + "%' or partnumber_his2 like '%" + textBox1.Text.Replace("'", "''")
                    + "%' or spare_ename like '%" + textBox1.Text.Replace("'", "''") + "%') ";
            }
            else
                bindingSourceMain.Filter = filter;

            //如果当前没有数据，则输入框区域的控件为不可用状态；否则为可用状态。.
            if (dgvSpare.Rows.Count > 0)
            {
                enableEdit(true);
            }
            else
            {
                enableEdit(false);
            }
        }

        /// <summary>
        /// 设置备件基础信息网格控件dgvSpare的隐藏列与显示标题.
        /// </summary>
        private void setDataGridView()
        {
            dgvSpare.Columns["spare_id"].Visible = false;
            dgvSpare.Columns["creator"].Visible = false;
            dgvSpare.Columns["spare_name"].HeaderText = "备件名称";
            dgvSpare.Columns["spare_ename"].HeaderText = "第二语言名称";
            dgvSpare.Columns["partnumber"].HeaderText = "配件号|规格";
            dgvSpare.Columns["partnumber_his1"].HeaderText = "历史配件号1";
            dgvSpare.Columns["partnumber_his2"].HeaderText = "历史配件号2";
            dgvSpare.Columns["picnumber"].HeaderText = "备件图号";
            dgvSpare.Columns["piccode"].HeaderText = "在图编号";
            dgvSpare.Columns["unit_name"].HeaderText = "计量单位";
            dgvSpare.Columns["alertstock"].HeaderText = "警戒库存";
            dgvSpare.Columns["sparestuff"].HeaderText = "构成材料";
            dgvSpare.Columns["remark"].HeaderText = "备注";
            dgvSpare.Columns["isspecialsp"].Visible = false;
            dgvSpare.Columns["isspecialsp_name"].HeaderText = "特殊备件";
            dgvSpare.LoadGridView("FrmSpareBasic.dgvSpare");
        }

        /// <summary>
        /// 绑定窗体控件（入库单信息控件的绑定）.
        /// </summary>
        private void bindingCtrols()
        {
            //主键值spare_id的绑定使用了txtSpareName的Tag属性解决，无法使用隐藏的控件。.
            txtSpareName.DataBindings.Add("Tag", bindingSourceMain, "spare_id", true);
            txtSpareName.DataBindings.Add("Text", bindingSourceMain, "spare_name", true);
            txtSpareEName.DataBindings.Add("Text", bindingSourceMain, "spare_ename", true);
            txtPartNumber.DataBindings.Add("Text", bindingSourceMain, "partnumber", true);
            txtPartNumberHis1.DataBindings.Add("Text", bindingSourceMain, "partnumber_his1", true);
            txtPartNumberHis2.DataBindings.Add("Text", bindingSourceMain, "partnumber_his2", true);
            txtPicNumber.DataBindings.Add("Text", bindingSourceMain, "picnumber", true);
            txtUnit.DataBindings.Add("Text", bindingSourceMain, "unit_name", true);
            txtPicCode.DataBindings.Add("Text", bindingSourceMain, "piccode", true);
            txtSpareStuff.DataBindings.Add("Text", bindingSourceMain, "sparestuff", true);
            txtAlertStock.DataBindings.Add("Text", bindingSourceMain, "alertstock", true);
            txtRemark.DataBindings.Add("Text", bindingSourceMain, "remark", true);
            txtRemark.DataBindings.Add("Tag", bindingSourceMain, "creator", true);//注意使用了txtRemark的Tag属性绑定creator字段.
            ckbISSPECIALSP.DataBindings.Add("Checked", bindingSourceMain, "ISSPECIALSP", true);
        }

        /// <summary>
        /// 查询已被绑定的备件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoIsBind_CheckedChanged(object sender, EventArgs e)
        {
            retrieveData();

        }

        /// <summary>
        /// 查询未被绑定的备件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoUnbind_CheckedChanged(object sender, EventArgs e)
        {
            retrieveData();
        }

        /// <summary>
        /// 备件基础信息添加操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            rdoUnbind.Checked = true;
            bindingSourceMain.AddNew();
            txtSpareName.Tag = Guid.NewGuid().ToString();//产生基础信息主键值.
            txtUnit.Text = "EA";
            txtRemark.Tag = CommonOperation.ConstParameter.UserName;//当前登录用户Id            
            txtSpareName.Focus();
            enableEdit(true);
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
                if (rdoIsBind.Checked)
                {
                    MessageBoxEx.Show("当前备件已被设备型号绑定，在删除前请先去掉与设备型号的绑定关系！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                bindingSourceMain.RemoveCurrent();
                bindingSourceMain.EndEdit();
                DataTable dtb = (DataTable)bindingSourceMain.DataSource;//从BindingSource组件中取得信息集放到DataTable中去.
                if (dbOperation.SaveFormData(dtb, "T_Spare", 0, out err))
                {
                    MessageBoxEx.Show("删除成功！", "删除成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBoxEx.Show("当前备件可能已经被使用，不能删除，更多错误信息请见：\r" + err, "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            //如果当前没有数据，则输入框区域的控件为不可用状态；否则为可用状态。.
            if (dgvSpare.Rows.Count > 0)
            {
                enableEdit(true);
            }
            else
            {
                enableEdit(false);
            }
        }

        /// <summary>
        /// 备件基础信息保存操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgSaveItem_Click(object sender, EventArgs e)
        {
            string err = "";//错误信息参数.
            float fltValidate = 0.0f;   //用于校验的变量.

            //***************数据校验*****************************************************************************
            if (dgvSpare.Rows.Count > 0)
            {
                if (txtSpareName.Text.Trim().Length == 0)
                {
                    MessageBoxEx.Show("备件名称不能为空！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSpareName.Focus();
                    return;
                }
                if (txtPartNumber.Text.Trim().Length == 0)
                {
                    MessageBoxEx.Show("[配件号|规格]不能为空！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPartNumber.Focus();
                    return;
                }
                if (txtAlertStock.Text.Trim().Length > 0 && float.TryParse(txtAlertStock.Text.Trim(), out fltValidate) == false)
                {
                    MessageBoxEx.Show("警戒库存必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAlertStock.Focus();
                    return;
                }
                if (txtUnit.Text.Trim().Length == 0)
                {
                    MessageBoxEx.Show("计量单位不能为空！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUnit.Focus();
                    return;
                }
                if (txtAlertStock.Text.Trim().Length == 0)
                {
                    txtAlertStock.Text = "0";
                }
            }

            //***************数据保存*****************************************************************************
            bindingSourceMain.EndEdit();
            DataTable dtb = (DataTable)bindingSourceMain.DataSource;//从BindingSource组件中取得信息集放到DataTable中去.
            if (dbOperation.SaveFormData(dtb, "T_Spare", 0, out err))
            {
                //保存数据后刷新BindingSource数据源组件.
                this.setBindingSource();
                MessageBoxEx.Show("数据保存成功！", "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBoxEx.Show(err, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //如果当前没有数据，则输入框区域的控件为不可用状态；否则为可用状态。.
            if (dgvSpare.Rows.Count > 0)
            {
                enableEdit(true);
            }
            else
            {
                enableEdit(false);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            retrieveData();
        }

        private void buttonEx3_Click(object sender, EventArgs e)
        {
            //只是根据图号来搜索文件，各种扩展名的都找。.
            if (txtPicNumber.Text.Length == 0)
            {
                MessageBoxEx.Show("本功能是根据备件图号在初始化的资料库中查询相应资料实现的，您选择的备件并没有初始化备件图号，无法进行查询");
                return;
            }
            FileSearch frm = new FileSearch(txtPicNumber.Text);
            frm.ShowDialog();
        }

        private void btnFastSelect_Click(object sender, EventArgs e)
        {
            if (btnFastSelect.Visible)
            {
                //判断有多少被选择项.
                SelectedSpareIds.Clear();

                for (int i = 0; i < dgvSpare.RowCount; i++)
                {
                    if (dgvSpare.Rows[i].Cells["selected"].Value != null && (bool)(dgvSpare.Rows[i].Cells["selected"].Value))
                        SelectedSpareIds.Add(dgvSpare.Rows[i].Cells["spare_id"].Value.ToString());
                }
                if (SelectedSpareIds.Count > 0)
                {
                    if (SelectedSpareIds.Count > 30)
                    {
                        if (MessageBoxEx.Show("为了避免错误操作，这里再一次的提醒您：\r您一次性选择了非常多个备件，请问是否确认您的选择！", "系统提示", MessageBoxButtons.YesNo,
                             MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.No)
                        {
                            return;
                        }
                    }
                    Selected = true;
                    this.Close();
                }
                else MessageBoxEx.Show("没有选择任何备件，如果希望选择备件，请在其点击相应行的选择框，让其变成选择状态！");
            }
        }

        private void dgvSpare_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (btnFastSelect.Visible)
            {
                SelectedSpareIds.Add(dgvSpare.Rows[e.RowIndex].Cells["spare_id"].Value.ToString());
                btnFastSelect_Click(sender, null);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool s = checkBox1.Checked;
            for (int i = 0; i < dgvSpare.RowCount; i++)
            {
                dgvSpare.Rows[i].Cells["selected"].Value = s;
            }
        }

        private void dgvSpare_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSpare.Columns.Contains("selected") && dgvSpare.Columns["selected"].Index == e.ColumnIndex)
            {
                if (dgvSpare.Rows[e.RowIndex].Cells["selected"].Value == null || !(bool)(dgvSpare.Rows[e.RowIndex].Cells["selected"].Value))
                    dgvSpare.Rows[e.RowIndex].Cells["selected"].Value = true;
                else
                    dgvSpare.Rows[e.RowIndex].Cells["selected"].Value = false;
            }
            ucSpareInWhich1.ClearView();
        }

        private void btnInShipInfo_Click(object sender, EventArgs e)
        {
            if (ItemsManage.ItemsManageConfig.openSpareInshipInfo != null)
            {
                if (txtSpareName.Tag != null && txtSpareName.Tag.ToString() != "" && txtSpareName.Tag.ToString().Length == 36)
                    ItemsManage.ItemsManageConfig.openSpareInshipInfo(
                        CommonOperation.ConstParameter.IsLandVersion ? "" : CommonOperation.ConstParameter.ShipId,
                        txtSpareName.Tag.ToString());
            }
        }

        private void FrmSpareBasic_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
            dgvSpare.SaveGridView("FrmSpareBasic.dgvSpare");
        }
    }
}