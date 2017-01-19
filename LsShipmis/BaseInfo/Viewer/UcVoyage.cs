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
    public partial class UcVoyage : UserControl, IOneObjectViewer
    {
        public bool needRetrieve = false;
        Voyage theObject = new Voyage ();
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();

        public Voyage TheObject
        {
            get
            {
                string err;
                SetObject(out err);
                return theObject;
            }
        }

        public UcVoyage()
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
            theObject = (Voyage)toChangeData;
            if (theObject != null && !theObject.IsWrong)
            {
                txtVoyageName.Text = theObject.VOYTIMESNAME;
                ucShipSelect1.SelectedId(theObject.SHIP_ID);
                dtBegin.Value = theObject.STARTDATE;
                dtEnd .Value = theObject.ENDDATE ;
                txtDetail.Text = theObject.REMARK;
            }
            else
            {
                ClearData();
            }
        }

        public void ClearData()
        {
            theObject = new Voyage();
            txtVoyageName.Text = "";
            txtDetail.Text = "";
            dtBegin.Text = "";
            dtEnd.Text = "";
        }

        public bool SetObject(out string err)
        {
            err = "";
            if (theObject != null)
            {
                theObject.VOYTIMESNAME = txtVoyageName.Text;
                theObject.REMARK = txtDetail.Text;
                theObject.SHIP_ID = ucShipSelect1.GetId();
                theObject.STARTDATE = dtBegin.Value;
                theObject.ENDDATE = dtEnd.Value;
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
            txtVoyageName.ReadOnly = !canEdit;
            txtDetail.ReadOnly = !canEdit;
            dtBegin.ReadOnly = !canEdit;
            dtEnd.ReadOnly = !canEdit;
            ucShipSelect1.Enabled = canEdit;
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
                if (VoyageService.Instance.deleteUnit(theObject.GetId(), out err))
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
                if (string.IsNullOrEmpty(theObject.VOYTIMESNAME))
                {
                    MessageBoxEx.Show("航次名称不允许为空!");
                    txtVoyageName.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(theObject.SHIP_ID))
                {
                    MessageBoxEx.Show("船舶不允许为空!");
                    ucShipSelect1.Focus();
                    return false;
                }
                if (theObject.STARTDATE == null || theObject.STARTDATE< CommonOperation .ConstParameter.MinDateTime)
                {
                    MessageBoxEx.Show("航次开始日期不允许为空!");
                    dtBegin.Focus();
                    return false;
                }
                if (theObject.ENDDATE == null || theObject.ENDDATE < CommonOperation.ConstParameter.MinDateTime)
                {
                    MessageBoxEx.Show("航次结束日期不允许为空!");
                    dtEnd.Focus();
                    return false;
                }
                if (theObject.STARTDATE　>= theObject.ENDDATE )
                {
                    MessageBoxEx.Show("航次结束日期必须大于航次开始日期!");
                    dtEnd.Focus();
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
