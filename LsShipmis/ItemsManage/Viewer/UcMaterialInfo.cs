/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：
 * 创 建 人：徐正本
 * 创建时间：2011-5-18
 * 标    题：
 * 功能描述：船舶设备分类控件
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
using CommonOperation.Interfaces;
using BaseInfo.DataAccess;
using BaseInfo.Objects;
using CommonOperation.BaseClass;
using System.IO;
using Microsoft.Win32;
using System.Data.SqlClient;
using CommonOperation.Functions;

using ItemsManage.DataObject;
using ItemsManage.Services;
using CommonViewer.BaseControl;

namespace ItemsManage.Viewer
{
    public partial class UcMaterialInfo : UserControl, IOneObjectViewer
    {
        public bool NeedRetrieve = false;
        MaterialInfo theObject = new MaterialInfo();
        MaterialType theMaterialType;

        public MaterialInfo TheObject
        {
            get
            {
                return theObject;
            }
        }

        public UcMaterialInfo()
        {
            InitializeComponent();
        }

        #region IOneObjectViewer 成员
        /// <summary>
        /// 设置对象和关联数据功能.
        /// </summary>
        public void ChangeData(CommonClass toChangeData)
        {
            if (toChangeData == null) ClearData();
            if (!toChangeData.EqualTo(theObject) || (string.IsNullOrEmpty(theObject.GetId()) && toChangeData != null))
            { 
                DirectlyChangeData(toChangeData);
            }
        }
        /// <summary>
        /// 把显示值设置到对象上.
        /// </summary>
        public bool SetObject(out string err)
        {
            err = "";
            if (theObject != null)
            {
                theObject.UNIT_NAME = txtUnit.Text;
                theObject.REMARK = txtRemark.Text;
                theObject.MATERIAL_SPEC = txtMaterialSpec.Text;
                theObject.MATERIAL_NAME = txtMaterialName.Text;
                if (theMaterialType != null && !theMaterialType.IsWrong) theMaterialType.MATERIAL_TYPE_NAME = theMaterialType.MATERIAL_TYPE_ID;
                theObject.MATERIAL_CODE = txtMaterialCode.Text;
                return true;
            }
            else
            {
                err = "当前对象无效!";
                MessageBoxEx.Show(err);
            }
            return false;
        }

        /// <summary>
        /// 使对象可编辑.
        /// </summary>
        public void SetCanEdit(bool canEdit)
        {
            txtUnit.ReadOnly = !canEdit;
            txtRemark.ReadOnly = !canEdit;
            txtMaterialSpec.ReadOnly = !canEdit;
            txtMaterialName.ReadOnly = !canEdit;
            txtMaterialCode.ReadOnly = !canEdit;
        }

        public void DirectlyChangeData(CommonClass toChangeData)
        {
            theObject = (MaterialInfo)toChangeData;
            string err;
            if (!string.IsNullOrEmpty(theObject.MATERIAL_TYPE_ID))
            {
                theMaterialType = MaterialTypeService.Instance.getObject(theObject.MATERIAL_TYPE_ID, out err);
            }
            if (theObject != null && !theObject.IsWrong)
            {
                txtUnit.Text = theObject.UNIT_NAME;
                txtRemark.Text = theObject.REMARK;
                txtMaterialSpec.Text = theObject.MATERIAL_SPEC;
                txtMaterialName.Text = theObject.MATERIAL_NAME;
                if (theMaterialType != null && !theMaterialType.IsWrong) txtMaterialType.Text = theMaterialType.MATERIAL_TYPE_NAME;
                txtMaterialCode.Text = theObject.MATERIAL_CODE;
            }
            else
            {
                ClearData();
            }
        }

        public void ClearData()
        {
            theObject = new MaterialInfo();
            txtUnit.Text = "EA";
            txtRemark.Text = "";
            txtMaterialSpec.Text = "";
            txtMaterialName.Text = "";
            txtMaterialType.Text = theObject.TypeName;
            txtMaterialCode.Text = "";
        }

        #endregion

        /// <summary>
        /// 删除对象功能.
        /// </summary>
        public void DeleteObject()
        {
            if (theObject != null && theObject.MATERIAL_TYPE_ID != null && theObject.MATERIAL_TYPE_ID.Length > 0)
            {
                string err;
                DialogResult response = MessageBoxEx.Show("您确定要删除该条数据吗？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (response == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                if (theObject.Delete(out err))
                {
                    MessageBoxEx.Show("删除成功!");
                    NeedRetrieve = true;
                }
                else
                {
                    MessageBoxEx.Show("当前对象删除失败,错误原因是:\n\n" + err);
                }
            }
            else
            {
                MessageBoxEx.Show("当前节点不能删除!");
            }

        }

        /// <summary>
        /// 保存对象功能.
        /// </summary>
        public bool UpdateObject()
        {
            string err;
            if (!SetObject(out err))
            {
                return false;
            }
            if (beforSaveCheck())
            {
                if (!theObject.Update(out err))
                {
                    MessageBoxEx.Show("当前对象保存失败,错误原因是:" + err);
                    return false;
                }
                else
                {
                    MessageBoxEx.Show("保存成功!");
                    return true;
                }
            }
            return false;
        }

        private bool beforSaveCheck()
        {
            if (string.IsNullOrEmpty(theObject.MATERIAL_NAME))
            {
                MessageBoxEx.Show("物资名称不允许为空!");
                txtMaterialName.Focus();
                return false;
            } 
            if (string.IsNullOrEmpty(theObject.UNIT_NAME))
            {
                MessageBoxEx.Show("物资单位名称不允许为空!");
                txtUnit.Text = "EA";
                txtUnit.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(theObject.MATERIAL_TYPE_ID))
            {
                MessageBoxEx.Show("物资的所属分类不能为空,但此值不允许编辑,无法保持当前对象,请关闭界面后重试!");
                return false;
            }
            return true;
        }
    }
}
