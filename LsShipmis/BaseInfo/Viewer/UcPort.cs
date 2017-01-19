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
    public partial class UcPort : UserControl, IOneObjectViewer
    {
        public bool needRetrieve = false;
        PortInfo theObject = new PortInfo ();
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();

        public PortInfo TheObject
        {
            get
            {
                string err;
                SetObject(out err);
                return theObject;
            }
        }

        public UcPort()
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
            theObject = (PortInfo)toChangeData;
            if (theObject != null && !theObject.IsWrong)
            {
                txtportName.Text = theObject.CNAME;
                txtPortCode.Text = theObject.ISOCODE;
                txtEnName.Text = theObject.ENAME;
                txtCountry.Text = theObject.COUNTRY;
                txtRemark.Text = theObject.REMARK; 
            }
            else
            {
                ClearData();
            }
        }

        public void ClearData()
        {
            theObject = new PortInfo();
            txtportName.Text = "";
            txtEnName.Text = "";
            txtPortCode.Text = ""; 
            txtCountry.Text = "";
            txtRemark.Text = ""; 
        }

        public bool SetObject(out string err)
        {
            err = "";
            if (theObject != null)
            {
                theObject.CNAME = txtportName.Text;
                theObject.ISOCODE = txtPortCode.Text;
                theObject.ENAME = txtEnName.Text;
                theObject.COUNTRY = txtCountry.Text;
                theObject.REMARK = txtRemark.Text; 
               
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
            txtportName.ReadOnly = !canEdit;
            txtEnName.ReadOnly = !canEdit;
            txtPortCode.ReadOnly = !canEdit;
            txtCountry.ReadOnly = !canEdit;
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
                if (PortInfoService.Instance.deleteUnit(theObject.GetId(), out err))
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
                if (!theObject.Update(out err))
                {
                    MessageBoxEx.Show("当前对象保存失败,错误原因是:" + err);
                    return false;
                }
            }
            MessageBoxEx.Show("保存成功!");
            return true;
        } 
    }
}
