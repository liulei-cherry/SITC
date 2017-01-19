/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有 * 文 件 名：FrmSeamanInfo.cs
 * 创 建 人：李景育 * 创建时间：2007-07-15
 * 标    题：船员基本信息业务窗体
 * 功能描述：实现船员基本信息业务窗体上的相关功能 * 修 改 人：
 * 修改时间： * 修改内容： ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms; 
using LSShipMis_Ship.SysLs.Services;
using LSShipMis_Ship.BasicData;
using LSShipMis_Ship.Common;
using LSShipMis_Ship.Common.Classes;
using LSShipMis_Ship.Seaman.Services;
using CommonViewer.BaseControlService;
using CommonViewer.BaseForm;
using CommonViewer.BaseControl;

namespace LSShipMis_Ship.Seaman.Forms
{
    /// <summary>
    /// 船员基本信息业务窗体.
    /// </summary>
    public partial class FrmSeamanInfo : CommonViewer.BaseForm.FormBase
    {
        private CommonOpt commonOpt = new CommonOpt();//定义一个公共类CommonOpt对象.
        private string sChkMessage = "";//权限检查提示信息（没有配置或者没有权限的提示）.
        private CommonOperation.Functions.ProxyRight proxyRight =CommonOperation.Functions.ProxyRight.Instance;//权限代理业务类.
        #region 窗体单实例模型
               
        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmSeamanInfo instance = new FrmSeamanInfo();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmSeamanInfo Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmSeamanInfo.instance = new FrmSeamanInfo();
                }

                return FrmSeamanInfo.instance;
            }
        }

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmSeamanInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSeamanInfo_Load(object sender, EventArgs e)
        {
            this.setComboBox();     //设置窗体所需的下拉列表框的数据源.
            this.setBindingSource();//设置数据源.
            this.setDataGridView(); //设置网格控件dgvSpApply的隐藏列与标头的设置.
            this.bindingCtrols();   //绑定窗体控件.
            this.checkRight();      //功能权限校验.
        }

        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        { 
            //国籍选择的DataTable对象.
            DataTable dtbCountry = BaseDataService.GetCountry(""); 

            //国籍下拉列表.
            cboCountry.DataSource = dtbCountry;
            cboCountry.DisplayMember = "countryname";
            cboCountry.ValueMember = "countryId";
        }

        /// <summary>
        /// 界面功能权限的校验.
        /// </summary>
        private void checkRight()
        {
            //船员操作权限.
            bool seamanInfoOperation = CommonOperation.ConstParameter.SupperUser ||
                proxyRight.CheckRight(CommonOperation.ConstParameter.SEAMAN_INFO_OPERATION, out sChkMessage);

            //设置需要权限控制的控件的可见性.
            bdNgAddNewItem.Visible = seamanInfoOperation;
            bdNgDeleteItem.Visible = seamanInfoOperation;
            bdNgCancelItem.Visible = seamanInfoOperation;
            bdNgSaveItem.Visible = seamanInfoOperation;

            toolStripButton3.Visible = CommonOperation.ConstParameter.SupperUser;
        }

        /// <summary>
        /// 设置船员基本信息的bindingSource数据源.
        /// </summary>
        private void setBindingSource()
        {
            DataTable dtbSeamanInfo = SeamanService.GetSeamanInfo();//取得船员基本信息的DataTable对象.
            bindingSourceMain.DataSource = dtbSeamanInfo;//船员基本信息的数据源设置.
            bdNgMain.BindingSource = bindingSourceMain;
            dgvSeaman.DataSource = bindingSourceMain;

            //如果当前没有数据，则输入框区域的控件为不可用状态；否则为可用状态。.
            if (dgvSeaman.Rows.Count > 0)
            {
                FormControlOption.Instance.EnableOrDisableCtrls(tableLayoutPanel2, true);
            }
            else
            {
                FormControlOption.Instance.EnableOrDisableCtrls(tableLayoutPanel2, false);
            }
        }

        /// <summary>
        /// 设置船员基本信息网格控件dgvSeaman的隐藏列与显示标题.
        /// </summary>
        private void setDataGridView()
        {
            dgvSeaman.Columns["shipuserid"].Visible = false;            
            dgvSeaman.Columns["unit_id"].Visible = false;
            dgvSeaman.Columns["countryid"].Visible = false;
            dgvSeaman.Columns["ship_headship_id"].Visible = false;
            dgvSeaman.Columns["creator"].Visible = false;
            dgvSeaman.Columns["username"].HeaderText = "姓名";
            dgvSeaman.Columns["enname"].Visible = false;
            dgvSeaman.Columns["birthday"].HeaderText = "出生年月";
            dgvSeaman.Columns["sex"].HeaderText = "性别";
            dgvSeaman.Columns["nation"].HeaderText = "民族";
            dgvSeaman.Columns["ismarriage"].HeaderText = "婚否";
            dgvSeaman.Columns["headship_name"].Visible = false;
            dgvSeaman.Columns["unit_name"].Visible = false;
            dgvSeaman.Columns["countryname"].HeaderText = "国籍";
            dgvSeaman.Columns["schage"].HeaderText = "学历";
            dgvSeaman.Columns["ident"].HeaderText = "身份证号";
            dgvSeaman.Columns["seanumb"].HeaderText = "海员证号";
            dgvSeaman.Columns["ssnumb"].HeaderText = "适任证号";
            dgvSeaman.Columns["sernumb"].HeaderText = "服务簿号";
            dgvSeaman.Columns["address"].HeaderText = "住址";
            dgvSeaman.Columns["connection"].HeaderText = "联系方式";
            dgvSeaman.Columns["remark"].HeaderText = "备注";
        }
        
        /// <summary>
        /// 绑定窗体控件.
        /// </summary>
        private void bindingCtrols()
        {
            //主键值shipuserid的绑定使用了txtChName的Tag属性解决，无法使用隐藏的控件。.
            txtChName.DataBindings.Add("Tag", bindingSourceMain, "shipuserid", true);
            txtChName.DataBindings.Add("Text", bindingSourceMain, "username", true); 
            cboSex.DataBindings.Add("Text", bindingSourceMain, "sex", true);//使用的ComboBox的Text属性绑定，因为没有Id值.
            txtBirthday.DataBindings.Add("Text", bindingSourceMain, "birthday", true);
            txtNation.DataBindings.Add("Text", bindingSourceMain, "nation", true);
            cboMarriage.DataBindings.Add("Text", bindingSourceMain, "ismarriage", true);//使用的ComboBox的Text属性绑定，因为没有Id值.
            cboCountry.DataBindings.Add("SelectedValue", bindingSourceMain, "countryid", true);
            txtSchage.DataBindings.Add("Text", bindingSourceMain, "schage", true); 
            txtIdent.DataBindings.Add("Text", bindingSourceMain, "ident", true);
            txtSeaNumb.DataBindings.Add("Text", bindingSourceMain, "seanumb", true);
            txtSsnumb.DataBindings.Add("Text", bindingSourceMain, "ssnumb", true);
            txtSerNumb.DataBindings.Add("Text", bindingSourceMain, "sernumb", true);
            txtConnection.DataBindings.Add("Text", bindingSourceMain, "connection", true);
            txtAddress.DataBindings.Add("Text", bindingSourceMain, "address", true);
            txtRemark.DataBindings.Add("Text", bindingSourceMain, "remark", true);
            txtRemark.DataBindings.Add("Tag", bindingSourceMain, "creator", true);//注意使用了txtRemark的Tag属性绑定creator字段.

            ////照片的绑定.
            //Binding bindPhoto = new Binding("Image", bindingSourceMain, "photo", true);//绑定图片内容.
            ////bindPhoto.Format += new ConvertEventHandler(commonOpt.PictureFormat);
            //picPhoto.DataBindings.Add(bindPhoto);
        }

        /// <summary>
        /// 船员基本信息申请单信息添加操作        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            if (!CommonOperation.ConstParameter.SupperUser && proxyRight.CheckRight(CommonOperation.ConstParameter.SEAMAN_INFO_OPERATION, out sChkMessage) == false)
            {
                MessageBoxEx.Show(sChkMessage, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bindingSourceMain.AddNew();
            txtChName.Tag = Guid.NewGuid().ToString();//产生主键值.
            cboCountry.SelectedIndex = 0;
            cboSex.SelectedIndex = 1;
            cboSex.SelectedIndex = 0;
            cboMarriage.SelectedIndex = 1;
            cboMarriage.SelectedIndex = 0;
            txtRemark.Tag = CommonOperation.ConstParameter.UserName;//当前登录用户Id
            bdNgAddNewItem.Enabled = false; //设置添加按钮的Enable为不可用以避免连续添加.
            //如果当前数据为空（主网格控件行数 = 1说明是刚添加的空行），则把输入区域的控件设置为可用状态。.
            if (dgvSeaman.Rows.Count == 1)
            {                
                FormControlOption.Instance.EnableOrDisableCtrls(tableLayoutPanel2, true);
            }
        }

        /// <summary>
        /// 删除操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.

            if (!CommonOperation.ConstParameter.SupperUser && proxyRight.CheckRight(CommonOperation.ConstParameter.SEAMAN_INFO_OPERATION, out sChkMessage) == false)
            {
                MessageBoxEx.Show(sChkMessage, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
                commonOpt.SaveFormData(dtb, "T_Ship_User", 0, out err);//保存数据.

                //更新结果报告.
                if (err.Equals(""))
                {
                    MessageBoxEx.Show("删除成功！", "删除成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    bdNgCancelItem_Click(null, null);
                    if (commonOpt.IsAgainstReference(err))
                    {
                        this.setBindingSource();//撤消.
                        MessageBoxEx.Show("被引用的信息不能删除！", "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBoxEx.Show(err, "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                      
                    }
                }

                //如果当前没有数据，则输入框区域的控件为不可用状态；否则为可用状态。.
                if (dgvSeaman.Rows.Count > 0)
                {
                    FormControlOption.Instance.EnableOrDisableCtrls(tableLayoutPanel2, true);
                }
                else
                {
                    FormControlOption.Instance.EnableOrDisableCtrls(tableLayoutPanel2, false);
                }

                bdNgAddNewItem.Enabled = true;
            }
        }

        /// <summary>
        /// 船员基本信息申请单信息取消操作        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgCancelItem_Click(object sender, EventArgs e)
        {
            bindingSourceMain.CancelEdit();
            this.setBindingSource();
            bdNgAddNewItem.Enabled = true;
        }

        /// <summary>
        /// 船员基本信息信息保存操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgSaveItem_Click(object sender, EventArgs e)
        {
            string err = "";//错误信息参数.

            if (!CommonOperation.ConstParameter.SupperUser && proxyRight.CheckRight(CommonOperation.ConstParameter.SEAMAN_INFO_OPERATION, out sChkMessage) == false)
            {
                MessageBoxEx.Show(sChkMessage, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //***************数据校验*****************************************************************************
            DateTime dtValidate = new DateTime();

            if (dgvSeaman.Rows.Count > 0)
            {
                if (txtChName.Text.Trim().Length == 0)
                {
                    MessageBoxEx.Show("船员姓名是必填内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtChName.Focus();
                    return;
                }
                if (!txtBirthday.Text.Equals("") && !DateTime.TryParse(txtBirthday.Text, out dtValidate))
                {
                    MessageBoxEx.Show("出生年月日期的格式不正确，正确的格式是：yyyy-mm-dd。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBirthday.Focus();
                    return;
                }
            }

            //如果日期文本框为空字符串,重新绑定.
            if (txtBirthday.Text.Trim().Equals(""))
            {
                txtBirthday.DataBindings.Clear();
                txtBirthday.DataBindings.Add("Text", bindingSourceMain, "birthday", true);
            }

            //***************数据保存*****************************************************************************
            bindingSourceMain.EndEdit();
            DataTable dtb = (DataTable)bindingSourceMain.DataSource;//从BindingSource组件中取得信息集放到DataTable中去.
            commonOpt.SaveFormData(dtb, "T_Ship_User", 0, out err);//保存数据.

            //更新结果报告.
            if (err.Equals(""))
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
        /// 释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSeamanInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            //清除大文档绑定功能.
            FileOperation.FileBoundingOperation.Instance.FileBoundCheck("", "", 0, "");
            instance = null;    //释放窗体实例变量.
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //调用用户注册窗口.
            string personName = "";
            if (dgvSeaman.CurrentRow != null)
            {
                personName = dgvSeaman.CurrentRow.Cells["username"].Value.ToString();
            }
           
            SysLs.Forms.FrmSysUser frm = new SysLs.Forms.FrmSysUser(1, personName);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
           
        }

        private void ucDepartmentSelect1_TheSelectedChanged(string theSelectedObject)
        {
            if(dgvSeaman.CurrentRow != null)
                dgvSeaman.CurrentRow.Cells["unit_id"].Value = theSelectedObject;
        }

    }
}