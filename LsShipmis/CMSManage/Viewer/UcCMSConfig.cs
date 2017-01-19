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

namespace CMSManage.Viewer
{
    internal partial class UcCMSConfig : UserControl, IOneObjectViewer
    {
        public bool needRetrieve = false;
        CMSConfig theObject = new CMSConfig();
        private string shipId = CommonOperation.ConstParameter.ShipId;

        public CommonOperation.BaseClass.CommonClass.deleItemChanged ItemChanged;

        public string ShipId
        {
            set
            {
                shipId = value;
                ucShipSelect1.SelectedId(shipId);
            }
        }
        public CMSConfig TheObject
        {
            get
            {
                string err;
                SetObject(out err);
                return theObject;
            }
        }
        public UcCMSConfig()
        {
            InitializeComponent();
        }
        public UcCMSConfig(string shipId)
        {
            this.shipId = shipId;
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
            theObject = (CMSConfig)toChangeData;
            if (theObject != null && !theObject.IsWrong)
            {
                theObject.FillThisObject();
                ucShipSelect1.SelectedId(theObject.SHIP_ID);
                txtSortNo.Text = theObject.SortNo.ToString();
                txtCMSConfigName.Text = theObject.CHECKTITLE;
                txtCHECKENGLISHNAME.Text = theObject.CHECKENGLISHNAME;
                txtCMSCode.Text = theObject.CMSCODE;
                if (theObject.TheWorkInfo != null)
                {
                    txtWorkInfo.Text = theObject.TheWorkInfo.WORKINFONAME;
                    txtWorkInfo.Tag = theObject.WORKINFOID;
                }
                else
                {
                    txtWorkInfo.Text = "";
                    txtWorkInfo.Tag = null;
                }
                txtRemark.Text = theObject.CHECKDETAIL;
            }
            else
            {
                ClearData();
            }
        }

        public void ClearData()
        {
            theObject = new CMSConfig();
            ucShipSelect1.SelectedId("");
            txtCMSConfigName.Text = "";
            txtCHECKENGLISHNAME.Text = "";
            txtCMSCode.Text = "";
            txtSortNo.Text = "";
            txtWorkInfo.Text = "";
            txtRemark.Text = "";
            txtWorkInfo.Tag = null;
        }

        public bool SetObject(out string err)
        {
            err = "";
            if (theObject != null)
            {
                theObject.SHIP_ID = ucShipSelect1.GetId();
                theObject.CHECKTITLE = txtCMSConfigName.Text;
                theObject.CMSCODE = txtCMSCode.Text;
                int i;
                if (int.TryParse(txtSortNo.Text, out i))
                {
                    theObject.SortNo = i;
                }
                if (txtWorkInfo.Tag != null)
                    theObject.WORKINFOID = txtWorkInfo.Tag.ToString();
                else
                    theObject.WORKINFOID = "";
                theObject.CHECKDETAIL = txtRemark.Text;
                theObject.CHECKENGLISHNAME = txtCHECKENGLISHNAME.Text;
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
            txtCMSConfigName.ReadOnly = !canEdit;
            txtCHECKENGLISHNAME.ReadOnly = !canEdit;
            txtSortNo.ReadOnly = !canEdit;
            txtCMSCode.ReadOnly = !canEdit;
            txtWorkInfo.ReadOnly = !canEdit;
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
                if (CMSConfigService.Instance.deleteUnit(theObject.GetId(), out err))
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
            if (string.IsNullOrEmpty(txtCMSConfigName.Text.Trim()))
            {
                MessageBoxEx.Show("项目名称为必填字段");
                txtCMSConfigName.Select();
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

        private void btn_WorkInfoSelect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(shipId))
            {
                MessageBoxEx.Show("未确定船舶,无法选择工作信息");
                return;
            }
            FrmCMSWorkInfoSelect frm = new FrmCMSWorkInfoSelect(shipId, false);
            frm.ShowDialog();
            if (frm.WorkInfoIds != null && frm.WorkInfoIds.Count > 0)
            {
                //将第一个取出来.
                string err;
                WorkInfo workInfo = WorkInfoService.Instance.getObject(frm.WorkInfoIds[0], out err);
                txtWorkInfo.Text = workInfo.WORKINFONAME;
                if (string.IsNullOrEmpty(txtCMSConfigName.Text)) txtCMSConfigName.Text = workInfo.WORKINFONAME;
                if (string.IsNullOrEmpty(txtRemark.Text)) txtRemark.Text = workInfo.WORKINFODETAIL;
                txtWorkInfo.Tag = workInfo.GetId();
                theObject.WORKINFOID = workInfo.GetId();
                if (theObject.Update(out err))
                    if (ItemChanged != null) ItemChanged(theObject);
                    else
                        MessageBox.Show("工作信息关联失败,错误原因请参考:\r" + err, "错误提示");
            }
        }
    }
}
