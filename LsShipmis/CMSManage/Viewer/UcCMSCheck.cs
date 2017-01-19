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
    internal partial class UcCMSCheck : UserControl, IOneObjectViewer
    {
        public bool needRetrieve = false;
        CMSCheck theObject = new CMSCheck();
        private string shipId = CommonOperation.ConstParameter.ShipId;

        public CMSCheck TheObject
        {
            get
            {
                string err;
                SetObject(out err);
                return theObject;
            }
        }
        public UcCMSCheck()
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
            theObject = (CMSCheck)toChangeData;
            if (theObject != null && !theObject.IsWrong)
            {
                theObject.FillThisObject();
                ucShipSelect1.SelectedId(theObject.SHIP_ID);
                txtCMSCheckName.Text = theObject.CHECK_TITLE;
                txtCMSCode.Text = theObject.CMS_CODE;
                dt_PlanDate.Value = theObject.PLAN_DATE;
                dt_CheckDate.Value = theObject.CHECK_DATE;
                cbx_bandWorkOrder.Checked = (!string.IsNullOrEmpty(theObject.WORKORDER_ID));
                btn_workOrderSelect.Visible = cbx_bandWorkOrder.Checked;
                if (theObject.CHECK_STATE == 1) rb_plan.Checked = true;
                else if (theObject.CHECK_STATE == 2) rb_ok.Checked = true;
                else if (theObject.CHECK_STATE == 3) rb_haveFlaw.Checked = true;
                else if (theObject.CHECK_STATE == 4) rb_rectified.Checked = true;

                if (theObject.CHECK_DEPART == 1) rb_SelfCheck.Checked = true;
                else rb_SocietyCheck.Checked = true;

                txtChecker.Text = theObject.CHECK_PERSON;
                txtRemark.Text = theObject.CHECK_DETAIL;
            }
            else
            {
                ClearData();
            }
        }

        public void ClearData()
        {
            theObject = new CMSCheck();
            ucShipSelect1.SelectedId("");
            txtCMSCheckName.Text = "";
            txtCMSCode.Text = "";
            cbx_bandWorkOrder.Checked = false;
            btn_workOrderSelect.Visible = cbx_bandWorkOrder.Checked;
            dt_PlanDate.Text = "";
            dt_CheckDate.Text = "";
            rb_plan.Checked = true;
            rb_SelfCheck.Checked = true;
            txtChecker.Text = "";
            txtRemark.Text = "";
        }

        public bool SetObject(out string err)
        {
            err = "";
            if (theObject != null)
            {
                theObject.SHIP_ID = ucShipSelect1.GetId();
                theObject.CHECK_TITLE = txtCMSCheckName.Text;
                theObject.CMS_CODE = txtCMSCode.Text;
                theObject.PLAN_DATE = dt_PlanDate.Value;
                theObject.CHECK_DATE = dt_CheckDate.Value;
                if (rb_plan.Checked) theObject.CHECK_STATE = 1;
                else if (rb_ok.Checked || rb_rectified.Checked) theObject.CHECK_STATE = 2;
                else theObject.CHECK_STATE = 3;
                if (rb_SelfCheck.Checked) theObject.CHECK_DEPART = 1;
                else theObject.CHECK_DEPART = 2;
                theObject.CHECK_PERSON = txtChecker.Text;
                theObject.CHECK_DETAIL = txtRemark.Text;
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
            //ucShipSelect1.Enabled = canEdit;
            //txtCMSCheckName.ReadOnly = !canEdit;
            //txtCMSCode.ReadOnly = !canEdit;
            //dt_PlanDate.ReadOnly = !canEdit;
            dt_CheckDate.ReadOnly = !canEdit;
            //rb_haveFlaw.Enabled = canEdit;
            //rb_ok.Enabled = canEdit;
            //rb_plan.Enabled = canEdit;
            //rb_rectified.Enabled = canEdit;
            rb_SelfCheck.Enabled = canEdit;
            rb_SocietyCheck.Enabled = canEdit;
            txtChecker.ReadOnly = !canEdit;
            txtRemark.ReadOnly = !canEdit;
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

        public bool updateChecking()
        {
            if (string.IsNullOrEmpty(ucShipSelect1.GetId().Trim()))
            {
                MessageBoxEx.Show("船舶必须选择");
                ucShipSelect1.Select();
                return false;
            }
            if (string.IsNullOrEmpty(txtCMSCode.Text.Trim()))
            {
                MessageBoxEx.Show("检验代码为必填字段");
                txtCMSCode.Select();
                return false;
            }
            if (string.IsNullOrEmpty(txtCMSCheckName.Text.Trim()))
            {
                MessageBoxEx.Show("检验名称为必填字段");
                txtCMSCheckName.Select();
                return false;
            }
            return true;
        }

        public bool UpdateObject()
        {
            string err;
            SetObject(out err);
            if (theObject == null)
            {
                MessageBoxEx.Show("当前对象无效,不能保存!");
                return false;
            }
            else
            {
                if (!updateChecking()) return false;
                if (!theObject.Update(out err))
                {
                    MessageBoxEx.Show("当前对象保存失败,错误原因是:" + err);
                    return false;
                }
            }
            MessageBoxEx.Show("保存成功!");
            return true;
        }

        private void btn_WorkOrderSelect_Click(object sender, EventArgs e)
        {
            if (theObject != null && !string.IsNullOrEmpty(theObject.WORKORDER_ID))
            {
                FrmOneWorkOrderView frmOneWorkOrderView = new FrmOneWorkOrderView(theObject.WORKORDER_ID);
                frmOneWorkOrderView.ShowDialog();
            }
        }

        private void btn_rectify_Click(object sender, EventArgs e)
        {
            if (theObject != null)
            {
                theObject.FillThisObject();
                if (theObject.CmsRectify != null)
                {
                    FrmEditOneCMSRectify frm = new FrmEditOneCMSRectify(theObject.CmsRectify, true);
                    frm.ShowDialog();
                    if (frm.NeedRetrieve)
                    {
                        if (theObject.CmsRectify.RECTIFY_STATE == 2)
                        {
                            rb_rectified.Checked = true;
                        }
                    }
                }
            }
        }
    }
}
