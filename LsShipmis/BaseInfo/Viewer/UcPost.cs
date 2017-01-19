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
using FileOperationBase.FileServices;
using CommonViewer.BaseControl;

namespace BaseInfo.Viewer
{
    public partial class UcPost : UserControl, IOneObjectViewer
    {
        public bool needRetrieve = false;
        Post theObject = new Post();
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();

        public Post TheObject
        {
            get
            {
                string err;
                SetObject(out err);
                return theObject;
            }
        }

        public UcPost()
        {
            InitializeComponent();
            ucDepartmentSelect1.ChangeMode(0);
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
            theObject = (Post)toChangeData;
            if (theObject != null && !theObject.IsWrong)
            {
                SetCanEdit(true);
                txtPostName.Text = theObject.POSTNAME;
                txtCode.Text = theObject.POSTCODE;
                cboForLand.Checked = (theObject.ISLANDPOST == 1);
                cboIsLeader.Checked = (theObject.ISHEADER == 1);
                cboIsHighLevelShipMan.Checked = (theObject.IsHighLevelShipMan == 1);
                txtLevel.Text = theObject.POSTLEVEL.ToString();
                txtDetail.Text = theObject.DETAIL;
                ucDepartmentSelect1.SelectedId(theObject.DEPARTMENTID);
                if (string.IsNullOrEmpty(theObject.POSTTYPE))
                    cmbPostType.SelectedIndex = 0;
                else
                    cmbPostType.SelectedItem = theObject.POSTTYPE;

            }
            else
            {
                ClearData();
                SetCanEdit(false);
            }
        }

        public void ClearData()
        {
            theObject = new Post();
            txtPostName.Text = "";
            txtCode.Text = "";
            cboForLand.Checked = false;
            cboIsLeader.Checked = false;
            cboIsHighLevelShipMan.Checked = false;
            txtLevel.Text = "";
            txtDetail.Text = "";
            cmbPostType.SelectedItem = "";
        }

        public bool SetObject(out string err)
        {
            err = "";
            if (theObject != null)
            {
                theObject.POSTNAME = txtPostName.Text;
                theObject.POSTCODE = txtCode.Text;
                theObject.ISLANDPOST = cboForLand.Checked ? 1 : 0;
                theObject.ISHEADER = cboIsLeader.Checked ? 1 : 0;
                theObject.IsHighLevelShipMan = cboIsHighLevelShipMan.Checked ? 1 : 0;
                int level;
                if (int.TryParse(txtLevel.Text, out level))
                {
                    theObject.POSTLEVEL = level;
                }
                else
                {
                    MessageBoxEx.Show("岗位等级必须为数字");
                    txtLevel.Focus();
                    return false;
                }
                theObject.DEPARTMENTID = ucDepartmentSelect1.GetId();
                theObject.DETAIL = txtDetail.Text;
                theObject.POSTTYPE = (cmbPostType.SelectedItem).ToString();
                return true;
            }
            else
            {
                err = "没有对应的数据！";
            }
            return false;
        }

        public void SetCanEdit(bool canEdit)
        {
            txtPostName.ReadOnly = !canEdit;
            txtCode.ReadOnly = !canEdit;
            cboForLand.Enabled = canEdit;
            cboIsLeader.Enabled = canEdit;
            cboIsHighLevelShipMan.Enabled = canEdit;
            ucDepartmentSelect1.Enabled = canEdit;
            txtLevel.ReadOnly = !canEdit;
            txtDetail.ReadOnly = !canEdit;
            cmbPostType.Enabled = canEdit;
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
                if (theObject.Delete (out err))
                {
                    MessageBoxEx.Show("删除成功");
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
            if (!SetObject(out err)) return false;
            if (theObject == null)
            {
                MessageBoxEx.Show("当前对象无效,不能保存!");
                return false;
            }
            else
            {
                if (string.IsNullOrEmpty(theObject.POSTNAME))
                {
                    MessageBoxEx.Show("岗位名称为必填项");
                    txtPostName.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtLevel.Text))
                {
                    MessageBoxEx.Show("岗位等级为必填项");
                    txtLevel.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(theObject.DEPARTMENTID))
                {
                    MessageBoxEx.Show("所属部门为必填项");

                    return false;
                }
                if (!theObject.Update(out err))
                {
                    MessageBoxEx.Show("当前对象保存失败,错误原因是:" + err);
                    return false;
                }
            }
            MessageBoxEx.Show("保存成功!");
            return true;
        }

        private void cboForLand_CheckedChanged(object sender, EventArgs e)
        {
            //ucDepartmentSelect1.ChangeMode(cboForLand.Checked ? 1 : 2);
        }
    }
}
