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
    public partial class UcCurrency : UserControl, IOneObjectViewer
    {
        public bool needRetrieve = false;
        Currency theObject = new Currency();
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();

        public Currency TheObject
        {
            get
            {
                string err;
                SetObject(out err);
                return theObject;
            }
        }

        public UcCurrency()
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
            theObject = (Currency)toChangeData;
            if (theObject != null && !theObject.IsWrong)
            {
                SetCanEdit(true);

                txtCURRENCYCODE.Text = theObject.CURRENCYCODE;
                txtCURRENCYNAME.Text = theObject.CURRENCYNAME;
                txtFULLNAME.Text = theObject.FULLNAME;
                txtKEYNAME.Text = theObject.KEYNAME;
                chbInUse.Checked = (theObject.INUSE == 1);
                txtDetail.Text = theObject.REMARK;
            }
            else
            {
                ClearData();
                SetCanEdit(false);
            }
        }

        public void ClearData()
        {
            theObject = new Currency();
            txtCURRENCYCODE.Text = "";
            txtCURRENCYNAME.Text = "";
            txtFULLNAME.Text = "";
            txtKEYNAME.Text = "";
            chbInUse.Checked = true;
            txtDetail.Text = "";
        }

        public bool SetObject(out string err)
        {
            err = "";
            if (theObject != null)
            {
                theObject.CURRENCYCODE = txtCURRENCYCODE.Text;
                theObject.CURRENCYNAME = txtCURRENCYNAME.Text;
                theObject.FULLNAME = txtFULLNAME.Text;
                theObject.KEYNAME = txtKEYNAME.Text;
                theObject.INUSE = chbInUse.Checked ? 1 : 0;
                theObject.REMARK = txtDetail.Text;
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
            txtCURRENCYCODE.ReadOnly = !canEdit;
            txtCURRENCYNAME.ReadOnly = !canEdit;
            txtFULLNAME.ReadOnly = !canEdit;
            txtKEYNAME.ReadOnly = !canEdit;
            chbInUse.Enabled = canEdit;
            txtDetail.ReadOnly = !canEdit;
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
                if (CurrencyService.Instance.deleteUnit(theObject.GetId(), out err))
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
                if (string.IsNullOrEmpty(theObject.CURRENCYCODE))
                {
                    MessageBoxEx.Show("标准货币编码为必填项");
                    txtCURRENCYCODE.Focus();
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
    }
}
