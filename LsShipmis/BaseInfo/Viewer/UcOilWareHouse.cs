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
    public partial class UcOilWareHouse : UserControl, IOneObjectViewer
    {
        ShipOilWareHouse theObject = new ShipOilWareHouse ();
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();

        public ShipOilWareHouse TheObject
        {
            get
            {
                string err;
                SetObject(out err);
                return theObject;
            }
        }

        /// <summary>
        /// 设置shipID值.
        /// </summary>
        public string ShipID
        {
            set { theObject.SHIP_ID = value; }
        }

        public UcOilWareHouse()
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
            theObject = (ShipOilWareHouse)toChangeData;
            if (theObject != null && !theObject.IsWrong)
            {
                txtCGXH.Text = theObject.CGXH;
                txtXRJ.Text = theObject.XRJ.ToString();
                txtJRJ.Text = theObject.JRJ.ToString();
                txtWZ.Text = theObject.WZ;
                txtREMARK.Text = theObject.REMARK;
            }
            else
            {
                ClearData();
            }
        }

        public void ClearData()
        {
            theObject = new ShipOilWareHouse();
            //主键值ship_id的绑定使用了txtShipName的Tag属性解决，无法使用隐藏的控件。.
            txtCGXH.Text = "";
            txtXRJ.Text = "";
            txtJRJ.Text = "";
            txtWZ.Text = "";
            txtREMARK.Text = "";
        }

        public bool SetObject(out string err)
        {
            err = "";
            if (theObject != null)
            {
                theObject.CGXH = txtCGXH.Text;
                theObject.XRJ = Decimal.Parse(txtXRJ.Text);
                theObject.JRJ = Decimal.Parse(txtJRJ.Text);
                theObject.WZ = txtWZ.Text;
                theObject.REMARK = txtREMARK.Text;
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
            txtCGXH.ReadOnly = !canEdit;
            txtXRJ.ReadOnly = !canEdit;
            txtJRJ.ReadOnly = !canEdit;
            txtWZ.ReadOnly = !canEdit;
            txtREMARK.ReadOnly = !canEdit;
        }

        #endregion

        public bool UpdateObject()
        {
            string err;

            //****数据类型校验***
            float fltValidate = 0.0f;
            if (theObject != null)
            {
               if (txtXRJ.Text.Trim().Length > 0 && float.TryParse(txtXRJ.Text, out fltValidate) == false)
                {
                    MessageBoxEx.Show("舱柜型容积必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtXRJ.Focus();
                    return false;
                }
                if (txtXRJ.Text.Trim().Length == 0)
                {
                    txtXRJ.Text = "0";
                }

                if (txtJRJ.Text.Trim().Length > 0 && float.TryParse(txtJRJ.Text, out fltValidate) == false)
                {
                    MessageBoxEx.Show("舱柜净容积必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtJRJ.Focus();
                    return false;
                }
                if (txtJRJ.Text.Trim().Length == 0)
                {
                    txtJRJ.Text = "0";
                }
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
