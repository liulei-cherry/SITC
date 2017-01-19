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
using CommonViewer.BaseControlService;

namespace BaseInfo.Viewer
{
    public partial class UcDepartment : UserControl, IOneObjectViewer
    {
        public bool needRetrieve = false;
        Department theObject = new Department ();
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private FormControlOption other = FormControlOption.Instance;

        public Department TheObject
        {
            get
            {
                string err;
                SetObject(out err);
                return theObject;
            }
        }

        public UcDepartment()
        {
            InitializeComponent();
            ucDepartmentSelect1.ChangeMode(0);
            setComboBox();                 //设置窗体所需的下拉列表框的数据源.
        }

        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {
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
            theObject = (Department)toChangeData;
            if (theObject != null && !theObject.IsWrong)
            {
                SetCanEdit(true);
                txtDepartmentName.Text = theObject.DEPARTNAME;
                txtDetail.Text = theObject.DETAIL;
                txtCode.Text = theObject.DEPARTCODE;
                txtsort.Text = theObject.SORTNO.ToString();
                cboIsLand.Checked = (theObject.ISLANDDEPART == 1);
                cboUnmodify.Checked = (theObject.UNMODIFY == 1);
                ucDepartmentSelect1.SelectedId(theObject.UPDEPARTID);
                cobType.Text = theObject.DEPARTMENTTYPE == string.Empty ? "其它部门" : theObject.DEPARTMENTTYPE;

                if (theObject.UNMODIFY == 1)
                {
                    txtDepartmentName.ReadOnly = true;
                    ucDepartmentSelect1.Enabled = false;
                }
            }
            else
            {
                ClearData();
            }
        }

        public void ClearData()
        {
            theObject = new Department();
            txtDepartmentName.Text = "";
            txtDetail.Text = "";
            txtsort.Text = "";
            txtCode.Text = "";
            cboIsLand.Checked = false;
            cboUnmodify.Checked = false;
        }

        public bool SetObject(out string err)
        {
            err = "";
            if (theObject != null)
            {
                theObject.DEPARTNAME = txtDepartmentName.Text;
                theObject.DETAIL = txtDetail.Text;
                theObject.DEPARTCODE = txtCode.Text;
                theObject.ISLANDDEPART = cboIsLand.Checked ? 1 : 2;
                theObject.UNMODIFY = cboUnmodify.Checked ? 1 : 0;
                theObject.UPDEPARTID = ucDepartmentSelect1.GetId();
                theObject.DEPARTMENTTYPE = cobType.Text;
                int level;
                if (int.TryParse(txtsort.Text, out level))
                {
                    theObject.SORTNO = level;
                }
                else if(!string.IsNullOrEmpty (txtsort.Text))
                {
                    MessageBoxEx.Show("部门排序号必须为数字!");
                    txtsort.Focus();
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
            txtDepartmentName.ReadOnly = !canEdit;
            txtDetail.ReadOnly = !canEdit;
            txtCode.ReadOnly = !canEdit;
            cboIsLand.Enabled = canEdit;
            txtsort.ReadOnly = !canEdit;
            ucDepartmentSelect1.Enabled = canEdit;
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
            SetObject(out err);
            if (theObject == null)
            {
                MessageBoxEx.Show("当前对象无效,不能保存!");
                return false;
            }
            else
            {
                if (string.IsNullOrEmpty(theObject.DEPARTNAME))
                {
                    MessageBoxEx.Show("部门名称不允许为空!");
                    txtDepartmentName.Focus();
                    return false;
                }
                bool ischildOfOther;
                if (!string.IsNullOrEmpty(theObject.GetId()) && (theObject.GetId() == ucDepartmentSelect1.GetId() ||
                    !DepartmentService.Instance.ADepartmentIsChildOfAnotherOne(theObject.GetId(), ucDepartmentSelect1.GetId(), out ischildOfOther) ||
                    ischildOfOther))
                {
                    MessageBoxEx.Show("选择的上级部门有误,\r不能选择当前部门或其下级部门作为自己的上级部门!", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ucDepartmentSelect1.Focus();
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

        private void cboIsLand_CheckedChanged(object sender, EventArgs e)
        {
            //ucDepartmentSelect1.ChangeMode(cboIsLand.Checked ? 1 : 2);
        }
    }
}
