/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 创 建 人：徐正本
 * 创建时间：2011-5-18
 * 功能描述：船舶物资分类信息管理的相关功能
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
using System.IO;
using System.Windows.Forms;
using CommonViewer.BaseControlService;
using CommonOperation.Interfaces;
using BaseInfo.DataAccess;
using BaseInfo.Objects;
using System.Runtime.InteropServices;
using ItemsManage.DataObject;
using ItemsManage.Services;
using CommonViewer.BaseControl;

namespace ItemsManage.Viewer
{
    /// <summary>
    /// 船舶分类信息管理窗体.
    /// </summary>
    public partial class FrmMaterialTypeEdit : CommonViewer.BaseForm.FormBase
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmMaterialTypeEdit instance = new FrmMaterialTypeEdit();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmMaterialTypeEdit Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmMaterialTypeEdit.instance = new FrmMaterialTypeEdit();
                }
                return FrmMaterialTypeEdit.instance;
            }
        }
        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmMaterialTypeEdit()
        {
            InitializeComponent();
            if (!CommonOperation.ConstParameter.IsLandVersion)
            {
                AddButton.Visible = false; deleteButton.Visible = false; SaveButton.Visible = false;
            }
        }
        /// <summary>
        /// 添加操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            string superId = "";
            if (ucMaterialTypeTree1.SelectedNode == null)
            {
                MessageBoxEx.Show("请选择要添加分类的上级节点!\rSelect the parent node of which you want to add.");
                return;
            }
            if (ucMaterialTypeTree1.SelectedNode.Tag != null)
            {
                if (ucMaterialTypeTree1.SelectedNode.Tag.GetType() == typeof(MaterialType))
                {
                    MaterialType MaterialType = (MaterialType)(ucMaterialTypeTree1.SelectedNode.Tag);
                    superId = MaterialType.GetId();
                }
                else
                {
                    throw new Exception("FrmMaterialTypeEdit控件配置错误,请联系开发商!");
                }
            }

            MaterialType newMaterialType = new MaterialType("", superId, "", "");
            FrmEditOneMaterialType formNew = new FrmEditOneMaterialType(newMaterialType);

            formNew.ShowDialog();
            //当新添加数据时，刷新tree
            if (ucMaterialTypeTree1.SelectedNode != null)
            {
                ucMaterialTypeTree1.RefreshOneNode(ucMaterialTypeTree1.SelectedNode);
            }
        }

        /// <summary>
        /// 删除操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            ucMaterialType1.DeleteObject();
            if (ucMaterialTypeTree1.SelectedNode != null && ucMaterialTypeTree1.SelectedNode.Parent != null)
            {
                ucMaterialTypeTree1.RefreshOneNode(ucMaterialTypeTree1.SelectedNode.Parent);
            }
        }

        /// <summary>
        /// 保存操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ucMaterialType1.UpdateObject())
            {
                if (ucMaterialTypeTree1.SelectedNode != null && ucMaterialTypeTree1.SelectedNode.Parent != null)
                {
                    ucMaterialTypeTree1.RefreshOneNode(ucMaterialTypeTree1.SelectedNode.Parent);
                    ucMaterialTypeTree1.SelectOneMaterialType(ucMaterialType1.TheObject);
                }
            }
        }

        /// <summary>
        /// 主窗体加载.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPortInfo_Load(object sender, EventArgs e)
        {
            ucMaterialTypeTree1.ReloadingAllData();
        }

        /// <summary>
        /// 主窗体关闭.
        /// </summary>
        private void FrmPortInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
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

        private void ucMaterialTypeTree1_ItemChanged(MaterialType materialType)
        {
            //刷新右边元素.
            if (materialType == null || materialType.IsWrong)
            {
                ucMaterialType1.ClearData();
            }
            else
            {
                ucMaterialType1.ChangeData(materialType);
            }
        }

    }
}