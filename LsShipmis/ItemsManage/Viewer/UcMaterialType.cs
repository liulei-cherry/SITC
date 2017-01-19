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
    public partial class UcMaterialType : UserControl, IOneObjectViewer
    {
        public bool NeedRetrieve = false; 
        MaterialType theObject = new MaterialType();
        MaterialType parentObjcet;

        public MaterialType TheObject
        {
            get
            {
                return theObject;
            }
        }

        public UcMaterialType()
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
                string err;
                parentObjcet = MaterialTypeService.Instance.getObject(((MaterialType)toChangeData).SUPERIOR_ID, out err);
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
                theObject.MATERIAL_TYPE_NAME = txtName.Text;              
                theObject.REMARK = txtDetail.Text; 
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
            txtName.ReadOnly = !canEdit; 
            txtDetail.ReadOnly = !canEdit;
        }

        public void DirectlyChangeData(CommonClass toChangeData)
        {
            theObject = (MaterialType)toChangeData;
            if (theObject != null && !theObject.IsWrong)
            {
                SetCanEdit(true); 
                txtName.Text = theObject.MATERIAL_TYPE_NAME;                
                txtDetail.Text = theObject.REMARK;
                if(parentObjcet!=null && !parentObjcet.IsWrong)
                    txtSub.Text = parentObjcet.MATERIAL_TYPE_NAME;
            }
            else
            {
                ClearData();
            }
        }

        public void ClearData()
        {
            theObject = new MaterialType();
            if (parentObjcet != null) theObject.SUPERIOR_ID = parentObjcet.GetId();
            txtName.Text = "";            
            txtSub.Text = ""; 
            txtDetail.Text = "";
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
            if (string.IsNullOrEmpty(theObject.MATERIAL_TYPE_NAME))
            {
                MessageBoxEx.Show("物资分类名称不允许为空!");
                txtName.Focus();
                return false;
            }            
            return true;
        }
    }
}
