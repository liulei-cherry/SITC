/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：
 * 创 建 人：夏喜龙
 * 创建时间：2011-4-12
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
    public partial class UcEquipmentClass : UserControl, IOneObjectViewer
    {
        public bool needRetrieve = false;
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        EquipmentClass theObject = new EquipmentClass();
        EquipmentClass parentObjcet;

        public EquipmentClass TheObject
        {
            get
            {
                return theObject;
            }
        }

        public UcEquipmentClass()
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
                parentObjcet = EquipmentClassService.Instance.getObject(((EquipmentClass)toChangeData).PARENTCLASSID, out err);
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
                theObject.CLASSNAME = txtName.Text;
                theObject.CLASSCODE = txtCode.Text;                
                theObject.CLASSDETAIL = txtDetail.Text;
                theObject.CLASSTYPE = (rbnType1.Checked ? 1 : (rbnType2.Checked ? 2 : 3));
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
            txtCode.ReadOnly = !canEdit; 
            txtDetail.ReadOnly = !canEdit;
        }

        public void DirectlyChangeData(CommonClass toChangeData)
        {
            theObject = (EquipmentClass)toChangeData;
            if (theObject != null && !theObject.IsWrong)
            {
                SetCanEdit(true);
                txtCode.Text = theObject.CLASSCODE;
                txtName.Text = theObject.CLASSNAME;                
                txtDetail.Text = theObject.CLASSDETAIL;
                int caseSwitch = (int)theObject.CLASSTYPE;
                switch (caseSwitch)
                {
                    case 1:
                        rbnType1.Checked = true;
                        break;
                    case 2:
                        rbnType2.Checked = true;
                        break;
                    case 3:
                        rbnType3.Checked = true;
                        break;
                }
            }
            else
            {
                ClearData();
            }
        }

        public void ClearData()
        {
            theObject = new EquipmentClass();
            if (parentObjcet != null) theObject.PARENTCLASSID = parentObjcet.GetId();
            txtName.Text = "";
            txtCode.Text = "";
            txtSub.Text = "";
            rbnType1.Checked = true; 
            txtDetail.Text = "";
        }

        #endregion

        /// <summary>
        /// 删除对象功能.
        /// </summary>
        public void DeleteObject()
        {
            if (theObject != null && theObject.CLASSID != null && theObject.CLASSID.Length > 0)
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
                    needRetrieve = true;
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
            if (string.IsNullOrEmpty(theObject.CLASSNAME))
            {
                MessageBoxEx.Show("设备分类名称不允许为空!");
                txtName.Focus();
                return false;
            }
            string err;
            if (!EquipmentClassService.Instance.EquipmentClassCanBeOthersSubClassification(theObject, parentObjcet, out err))
            {
                MessageBoxEx.Show(err);
                return false;
            }
            return true;
        }
    }
}
