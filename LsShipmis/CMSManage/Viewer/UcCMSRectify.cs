using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CommonOperation.Interfaces;
using CommonOperation.BaseClass;
using System.IO;
using Microsoft.Win32;
using System.Data.SqlClient;
using CommonOperation.Functions;
using FileOperationBase.FileServices;
using CommonViewer.BaseControl;
using CMSManage.DataObject;
using CMSManage.Services;
using Maintenance.DataObject;
using Maintenance.Services;
using Maintenance.Viewer;

namespace CMSManage.Viewer
{
    internal partial class UcCMSRectify : UserControl, IOneObjectViewer
    {
        public bool needRetrieve = false;
        CMSRectify theObject = new CMSRectify();
        private string shipId = CommonOperation.ConstParameter.ShipId;

        public CMSRectify TheObject
        {
            get
            {
                string err;
                SetObject(out err);
                return theObject;
            }
        }
        public UcCMSRectify()
        {
            InitializeComponent();
        }

        #region IOneObjectViewer 成员
        public void ChangeData(CommonClass toChangeData)
        {
            if (!toChangeData.EqualTo(theObject))
            {
                DirectlyChangeData(toChangeData);
            }
        }

        public void DirectlyChangeData(CommonClass toChangeData)
        {
            theObject = (CMSRectify)toChangeData;
            if (theObject != null && !theObject.IsWrong)
            {
                theObject.FillThisObject();
                ucShipSelect1.SelectedId(theObject.SHIP_ID);
                CMSCheck theCheck = theObject.ThisCheck;
                txt_CMSCode.Text = theCheck.CMS_CODE;
                txt_CMSTitle.Text = theCheck.CHECK_TITLE;
                dt_CheckDate.Value = theCheck.CHECK_DATE;
                txt_CMSChecker.Text = theCheck.CHECK_PERSON;
                txtRemark.Text = theCheck.CHECK_DETAIL;
                /////////////////////////////////////////////////
                dt_PlanDate.Value = theObject.RECTIFY_PLAN_DATE;
                dt_RectifyDate.Value = theObject.RECTIFY_DATE;
                if (theObject.RECTIFY_STATE == 2) rb_ok.Checked = true;
                else rb_plan.Checked = true;

                txt_RectifyApplyer.Text = theObject.RECTIFY_APPROVE;
                txt_opinion.Text = theObject.RECTIFY_OPINION;
                txt_rectify_Detail.Text = theObject.RECTIFY_DETAIL;
            }
            else
            {
                ClearData();
            }
        }

        public void ClearData()
        {
            theObject = new CMSRectify();
            ucShipSelect1.SelectedId("");
            txt_CMSCode.Text = "";
            txt_CMSTitle.Text = "";
            dt_CheckDate.Text = "";
            txt_CMSChecker.Text = "";
            txtRemark.Text = "";
            /////////////////////////////////////////////////
            dt_PlanDate.Text = "";
            dt_RectifyDate.Text = "";
            rb_plan.Checked = true;
            txt_RectifyApplyer.Text = "";
            txt_opinion.Text = "";
            txt_rectify_Detail.Text = "";
        }

        public bool SetObject(out string err)
        {
            err = "";
            if (theObject != null)
            {
                theObject.RECTIFY_PLAN_DATE = dt_PlanDate.Value;
                theObject.RECTIFY_DATE = dt_RectifyDate.Value;
                if (rb_plan.Checked) theObject.RECTIFY_STATE = 1;
                else theObject.RECTIFY_STATE = 2;
                theObject.RECTIFY_APPROVE = txt_RectifyApplyer.Text;
                theObject.RECTIFY_OPINION = txt_opinion.Text;
                theObject.RECTIFY_DETAIL = txt_rectify_Detail.Text;
                if (theObject.RECTIFY_STATE == 2 && (theObject.RECTIFY_DATE==null || 
                    theObject.RECTIFY_DATE < CommonOperation.ConstParameter.MinDateTime ||
                    theObject.RECTIFY_DATE > DateTime.Today || theObject.RECTIFY_APPROVE.Length ==0 ||
                    theObject.RECTIFY_DETAIL.Length ==0))
                {
                    err = "当设置为通过检验状态时,\r[实际整改日期]为必填项且不能超过当天;"
                        + "\r[整改比准入]和[实际整改情况]必须为有效值";
                    rb_plan.Checked = true;
                    return false;
                }
                return true;
            }
            else
            {
                err = "没有对应的数据!";
            }
            return false;
        }

        public void SetCanEdit(bool canEdit)
        {
            dt_PlanDate.ReadOnly = !canEdit;
            dt_RectifyDate.ReadOnly = !canEdit;
            txt_RectifyApplyer.ReadOnly = !canEdit; 
            txt_opinion.ReadOnly = !canEdit;
            txt_rectify_Detail.ReadOnly = !canEdit;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public void DeleteObject()
        {

            if (theObject.IsWrong || string.IsNullOrEmpty(theObject.GetId()))
            {
                MessageBoxEx.Show("当前对象无效,不能删除!");
            }
            else
            {
                string err;
                DialogResult response = MessageBoxEx.Show("您确定要删除该条数据吗？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (response == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
                if (CMSCheckService.Instance.deleteUnit(theObject.GetId(), out err))
                {
                    MessageBoxEx.Show("删除成功!");
                    needRetrieve = true;
                }
                else
                {
                    MessageBoxEx.Show("当前对象删除失败,错误原因是:\n\n" + err);
                }
            }
        }

        public bool UpdateObject()
        {
            string err;
            if (!SetObject(out err))
            {
                MessageBoxEx.Show(err);
                return false;
            }
            if (theObject == null)
            {
                MessageBoxEx.Show("当前对象无效,不能保存!");
                return false;
            }
            else
            {
                if (!theObject.Update(out err))
                {
                    MessageBoxEx.Show("当前对象保存失败,错误原因是:" + err);
                    return false;
                }
            }
            if (theObject.RECTIFY_STATE == 1)
            {
                MessageBoxEx.Show("保存成功,请尽快完成此整改内容!");
            }
            else
            {
                MessageBoxEx.Show("整改完毕!");
            }
            return true;
        }

        public bool RectifyObject()
        {            
            rb_ok.Checked = true;
            return UpdateObject();
        }

    }
}
