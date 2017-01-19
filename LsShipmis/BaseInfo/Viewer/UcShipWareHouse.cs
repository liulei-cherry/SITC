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
using BaseInfo.DataObject;
using CommonViewer.BaseControl; 

namespace BaseInfo.Viewer
{
    public partial class UcShipWareHouse : UserControl, IOneObjectViewer
    {
        public bool needRetrieve = false;
        ShipWareHouse theObject = new ShipWareHouse();
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();

        public ShipWareHouse TheObject
        {
            get
            {
                string err;
                SetObject(out err);
                return theObject;
            }
        }

        public UcShipWareHouse()
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
            theObject = (ShipWareHouse)toChangeData;
            if (theObject != null && !theObject.IsWrong)
            {
                txtWarehouseName.Text = theObject.WAREHOUSE_NAME;
                txtWarehouseCode.Text = theObject.WAREHOUSE_CODE;
                ucShipSelect1.SelectedId(theObject.SHIP_ID);
                txtDetail.Text = theObject.REMARK;
            }
            else
            {
                ClearData();
            }
        }

        public void ClearData()
        {
            theObject = new ShipWareHouse();
            txtWarehouseName.Text = "";
            txtWarehouseCode.Text = "";
            txtDetail.Text = "";
        }

        public bool SetObject(out string err)
        {
            err = "";
            if (theObject != null)
            {
                theObject.WAREHOUSE_NAME = txtWarehouseName.Text;
                theObject.WAREHOUSE_CODE = txtWarehouseCode.Text;
                theObject.REMARK = txtDetail.Text;
                theObject.SHIP_ID = ucShipSelect1.GetId();          
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
            txtWarehouseName.ReadOnly = !canEdit;
            txtWarehouseCode.ReadOnly = !canEdit;
            ucShipSelect1.Enabled = CommonOperation.ConstParameter.IsLandVersion;
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
                if (ShipWareHouseService.Instance.deleteUnit(theObject.GetId(), out err))
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

            //****数据类型校验*** 
            if (theObject != null)
            {
               
            }
            //*********
            SetObject(out err);
            if (theObject == null)
            {
                MessageBoxEx.Show("当前对象无效,不能保存!");
                return false;
            }
            else
            {
                if (string.IsNullOrEmpty(theObject.WAREHOUSE_NAME))
                {
                    MessageBoxEx.Show("仓库名称不允许为空!");
                    txtWarehouseName.Focus();
                    return false;
                }
                if(string.IsNullOrEmpty(theObject.SHIP_ID) )
                {
                    MessageBoxEx.Show("仓库所在船舶不允许为空!");
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
