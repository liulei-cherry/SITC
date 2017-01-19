/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmSpareForEquipType.cs
 * 创 建 人：李景育
 * 创建时间：2008-07-05
 * 标    题：备件添加窗体
 * 功能描述：实现为设备型号添加备件业务的窗体，主要供船舶设备维护保养部分调用。
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
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using ItemsManage.Viewer.Forms;
using ItemsManage.Services;
using ItemsManage.DataObject;
using CommonViewer.BaseControlService;
using BaseInfo.DataAccess;
using CommonViewer.BaseControl;

namespace ItemsManage.Viewer
{
    /// <summary>
    /// 为设备型号添加备件窗体.
    /// </summary>
    public partial class FrmSpareForEquipType : CommonViewer.BaseForm.FormBase
    {
        /// <summary>
        /// 定义一个公共类CommonOpt对象.
        /// </summary>
        private IDBOperation commonOpt = InterfaceInstantiation.NewADBOperation();

        /// <summary>
        /// 定义一个设备型号对象.
        /// </summary>
        private ComponentType ComponentType = null;

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="ComponentType">设备型号对象</param>
        public FrmSpareForEquipType(ComponentType ComponentType)
        {
            InitializeComponent();
            this.ComponentType = ComponentType;
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSpareForEquipType_Load(object sender, EventArgs e)
        {
            //显示设备型号信息.
            buttonEx1.Text = "设备(" + ComponentType.COMPTYPE_CHINESE_NAME + ")的备件";

            this.setBindingSource();//设置数据源.
            this.bindingCtrols();   //绑定窗体控件.

            //加载当前网格的状态信息.
            //if (dgvSpare.Rows.Count == 0) bdNgAddNewItem_Click(sender, e);
        }

        /// <summary>
        /// 设置备件基础信息的bindingSource数据源。.
        /// </summary>
        private void setBindingSource()
        {
            string componentTypeId = ComponentType.COMPONENT_TYPE_ID;//取当前设备型号Id
            DataTable dtbSpare = SpareInfoService.Instance.GetSpareByComponentType(componentTypeId);//取得备件基础信息的DataTable对象.
            bindingSourceMain.DataSource = dtbSpare;//备件基础信息的数据源设置.
            dgvSpare.DataSource = bindingSourceMain;
            this.setDataGridView(); //设置网格控件dgvSpApply的隐藏列与标头的设置.
        }

        /// <summary>
        /// 设置备件基础信息网格控件dgvSpare的隐藏列与显示标题.
        /// </summary>
        private void setDataGridView()
        {
            dgvSpare.LoadGridView("FrmSpareForEquipType.dgvSpare");
            Dictionary<string, string> allColumnsName = new Dictionary<string, string>();
            allColumnsName.Add("spare_name", "备件名称");
            allColumnsName.Add("spare_ename", "第二语言名称");
            allColumnsName.Add("partnumber", "配件号|规格");
            allColumnsName.Add("picnumber", "备件图号");
            allColumnsName.Add("piccode", "在图编号");
            allColumnsName.Add("alertstock", "警戒库存");
            allColumnsName.Add("makeupNumber", "构成数量");
            dgvSpare.SetDgvGridColumns(allColumnsName);
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
            txtSpareEName.DataBindings.Add("Tag", bindingSourceMain, "comptypespareid", true);
            txtUnit.DataBindings.Add("Text", bindingSourceMain, "unit_name", true);
            txtPartNumber.DataBindings.Add("Text", bindingSourceMain, "partnumber", true);
            txtPartNumberHis1.DataBindings.Add("Text", bindingSourceMain, "partnumber_his1", true);
            txtPartNumberHis2.DataBindings.Add("Text", bindingSourceMain, "partnumber_his2", true);
            txtPicNumber.DataBindings.Add("Text", bindingSourceMain, "picnumber", true);
            txtPicCode.DataBindings.Add("Text", bindingSourceMain, "piccode", true);
            txtSpareStuff.DataBindings.Add("Text", bindingSourceMain, "sparestuff", true);
            txtAlertStock.DataBindings.Add("Text", bindingSourceMain, "alertstock", true);
            txtMakeupNumber.DataBindings.Add("Text", bindingSourceMain, "makeupNumber", true);
            txtRemark.DataBindings.Add("Text", bindingSourceMain, "remark", true);
            txtRemark.DataBindings.Add("Tag", bindingSourceMain, "creator", true);//注意使用了txtRemark的Tag属性绑定creator字段.
        }

        /// <summary>
        /// 备件信息添加操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            bindingSourceMain.AddNew();
            txtSpareName.Tag = Guid.NewGuid().ToString();//产生基础信息主键值.

            txtUnit.Text = "EA";
            txtRemark.Tag = CommonOperation.ConstParameter.UserName;//当前登录用户Id            
            txtSpareName.Focus();
            AddButton.Enabled = false;
        }

        /// <summary>
        /// 删除操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.
            string componentTypeId = "";//当前设备型号Id
            string spareId = "";        //当前备件Id

            if (bindingSourceMain.Current != null)
            {
                if (MessageBoxEx.Show("点击本按钮将不但删除当前设备与此备件的绑定关系，又同时删除此备件基本信息！\r如果此备件被其它设备在使用，则不会删除成功！\r请问您是否确定要删除吗？",
                    "操作失败", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }

                componentTypeId = ComponentType.COMPONENT_TYPE_ID;
                spareId = txtSpareName.Tag.ToString();

                bindingSourceMain.RemoveCurrent();
                bindingSourceMain.EndEdit();
                DataTable dtb = (DataTable)bindingSourceMain.DataSource;//从BindingSource组件中取得信息集放到DataTable中去.
                if (commonOpt.SaveFormData(dtb, "t_spare", 0, out err))
                {
                    if (CompTypeSpareService.Instance.DeleteUnit(componentTypeId, spareId, out err))
                    {
                        //保存数据后刷新BindingSource数据源组件.

                        this.setBindingSource();
                        MessageBoxEx.Show("数据保存成功！", "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AddButton.Enabled = true;
                        return;
                    }
                }
                MessageBoxEx.Show(err, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// 备件信息取消操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgCancelItem_Click(object sender, EventArgs e)
        {
            bindingSourceMain.CancelEdit();
            this.setBindingSource();
            AddButton.Enabled = true;
        }

        /// <summary>
        /// 备件基础信息保存操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgSaveItem_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.
            float fltValidate = 0.0f;   //用于校验的变量.

            string componentTypeId = "";//当前设备型号Id
            string spareId = "";        //当前备件Id

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

            componentTypeId = ComponentType.COMPONENT_TYPE_ID;
            if (txtSpareName.Text.Length == 0 || txtSpareName.Tag == null) return;
            spareId = txtSpareName.Tag.ToString();

            //***************数据保存*****************************************************************************
            bindingSourceMain.EndEdit();
            DataTable dtb = (DataTable)bindingSourceMain.DataSource;//从BindingSource组件中取得信息集放到DataTable中去.
            //执行保存备件的操作，保存备件时有两种操作（一个是保存备件基本信息，另一个是向设备型号-备件表中保存对应关系信息）.

            if (commonOpt.SaveFormData(dtb, "t_spare", 0, out err))
            {
                int makeupNumber;
                if (!int.TryParse(txtMakeupNumber.Text, out makeupNumber)) makeupNumber = 0;
                if (CompTypeSpareService.Instance.AddUnit(componentTypeId, spareId, makeupNumber, out err))
                {
                    //保存数据后刷新BindingSource数据源组件.

                    this.setBindingSource();
                    MessageBoxEx.Show("数据保存成功！", "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AddButton.Enabled = true;
                    return;
                }
            }
            MessageBoxEx.Show(err, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        /// 在界面关闭时保存网格的状态信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSpareForEquipType_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataGridViewExt.saveGridView(dgvSpare, CommonOperation.ConstParameter.UserId, "FrmSpareForEquipType.dgvSpare");
        }

        private void buttonEx2_Click(object sender, EventArgs e)
        {
            FrmSpareBasic frm = new FrmSpareBasic(true);
            frm.ShowDialog();
            if (frm.Selected && ComponentType != null)
            {
                string err;
                for (int i = 0; i < frm.SelectedSpareIds.Count; i++)
                {
                    //直接保存，然后刷新左边.

                    if (!ComponentTypeService.Instance.BandingToSpare(ComponentType.COMPONENT_TYPE_ID, frm.SelectedSpareIds[i], out err))
                    {
                        MessageBoxEx.Show("绑定备件到设备时出错，错误提示为：\r" + err, "错误提示");
                        return;
                    }
                }
                this.setBindingSource();
                AddButton.Enabled = true;
            }
        }

        private void buttonEx3_Click(object sender, EventArgs e)
        {
            if (txtSpareEName.Tag != null)
            {
                string err;
                if (!ComponentTypeService.Instance.DeleteBandingToSpare(txtSpareEName.Tag.ToString(), out err))
                    MessageBoxEx.Show("绑定备件到设备时出错，错误提示为：\r" + err, "错误提示");
                this.setBindingSource();
                AddButton.Enabled = true;
            }
        }

        private void buttonEx4_Click(object sender, EventArgs e)
        {
            if (ItemsManageConfig.quicklyInsertEquipmentByEquipmentType != null)
            {
                ItemsManageConfig.quicklyInsertEquipmentByEquipmentType(ComponentType);
                this.setBindingSource();
            } 
            else
            {
                throw new Exception("未对快速初始化功能进行设置,请速与开发商联系,\r可能是程序版本不对应");
            }
        }
    }
}