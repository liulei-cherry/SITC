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
    public partial class UcShipHold : UserControl, IOneObjectViewer
    //public partial class UcShipHold : UserControl
    {
        ShipHold theObject = new ShipHold ();
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();

        public ShipHold TheObject
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
            set {theObject.SHIP_ID = value;}
        }

        public UcShipHold()
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
            theObject = (ShipHold)toChangeData;
            if (theObject != null && !theObject.IsWrong)
            {
                txtHCBH.Text = theObject.HCBH;
                txtCKCD.Text = theObject.CKCD.ToString();
                txtCKKD.Text = theObject.CKKD.ToString();
                txtCNCD.Text = theObject.CNCD.ToString();
                txtCNKD.Text = theObject.CNKD.ToString();
                txtCNGD.Text = theObject.CNGD.ToString();
                txtSZRJ.Text = theObject.SZRJ.ToString();
                txtBZRJ.Text = theObject.BZRJ.ToString();
                txtQHSB.Text = theObject.QHSB.ToString();
                txtREMARK.Text = theObject.REMARK;
            }
            else
            {
                ClearData();
            }
        }

        public void ClearData()
        {
            theObject = new ShipHold();
            txtHCBH.Text = "";
            txtCKCD.Text = "";
            txtCKKD.Text = "";
            txtCNCD.Text = "";
            txtCNKD.Text = "";
            txtCNGD.Text = "";
            txtSZRJ.Text = "";
            txtBZRJ.Text = "";
            txtQHSB.Text = "";
            txtREMARK.Text = "";
        }

        public bool SetObject(out string err)
        {
            err = "";
            if (theObject != null)
            {
                theObject.HCBH = txtHCBH.Text;
                theObject.CKCD = Decimal.Parse(txtCKCD.Text);
                theObject.CKKD = Decimal.Parse(txtCKKD.Text);
                theObject.CNCD = Decimal.Parse(txtCNCD.Text);
                theObject.CNKD = Decimal.Parse(txtCNKD.Text);
                theObject.CNGD = Decimal.Parse(txtCNGD.Text);
                theObject.SZRJ = Decimal.Parse(txtSZRJ.Text);
                theObject.BZRJ = Decimal.Parse(txtBZRJ.Text);
                theObject.QHSB = Decimal.Parse(txtQHSB.Text);
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
            txtHCBH.ReadOnly = !canEdit;
            txtCKCD.ReadOnly = !canEdit;
            txtCKKD.ReadOnly = !canEdit;
            txtCNCD.ReadOnly = !canEdit;
            txtCNKD.ReadOnly = !canEdit;
            txtCNGD.ReadOnly = !canEdit;
            txtSZRJ.ReadOnly = !canEdit;
            txtBZRJ.ReadOnly = !canEdit;
            txtQHSB.ReadOnly = !canEdit;
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
                if (txtCKCD.Text.Trim().Length > 0 && float.TryParse(txtCKCD.Text, out fltValidate) == false)
                {
                    MessageBoxEx.Show("舱口长度必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCKCD.Focus();
                    return false;
                }
                if (txtCKCD.Text.Trim().Length == 0)
                {
                    txtCKCD.Text = "0";
                }
                if (txtCKKD.Text.Trim().Length > 0 && float.TryParse(txtCKKD.Text, out fltValidate) == false)
                {
                    MessageBoxEx.Show("舱口宽度必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCKKD.Focus();
                    return false;
                }
                if (txtCKKD.Text.Trim().Length == 0)
                {
                    txtCKKD.Text = "0";
                }

                if (txtCNCD.Text.Trim().Length > 0 && float.TryParse(txtCNCD.Text, out fltValidate) == false)
                {
                    MessageBoxEx.Show("舱内长度必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCNCD.Focus();
                    return false;
                }
                if (txtCNCD.Text.Trim().Length == 0)
                {
                    txtCNCD.Text = "0";
                }

                if (txtCNKD.Text.Trim().Length > 0 && float.TryParse(txtCNKD.Text, out fltValidate) == false)
                {
                    MessageBoxEx.Show("舱内宽度必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCNKD.Focus();
                    return false;
                }
                if (txtCNKD.Text.Trim().Length == 0)
                {
                    txtCNKD.Text = "0";
                }

                if (txtCNGD.Text.Trim().Length > 0 && float.TryParse(txtCNGD.Text, out fltValidate) == false)
                {
                    MessageBoxEx.Show("舱内高度必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCNGD.Focus();
                    return false;
                }
                if (txtCNGD.Text.Trim().Length == 0)
                {
                    txtCNGD.Text = "0";
                }

                if (txtSZRJ.Text.Trim().Length > 0 && float.TryParse(txtSZRJ.Text, out fltValidate) == false)
                {
                    MessageBoxEx.Show("散装容积必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSZRJ.Focus();
                    return false;
                }
                if (txtSZRJ.Text.Trim().Length == 0)
                {
                    txtSZRJ.Text = "0";
                }

                if (txtBZRJ.Text.Trim().Length > 0 && float.TryParse(txtBZRJ.Text, out fltValidate) == false)
                {
                    MessageBoxEx.Show("包装容积必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBZRJ.Focus();
                    return false;
                }
                if (txtBZRJ.Text.Trim().Length == 0)
                {
                    txtBZRJ.Text = "0";
                } 
                if (txtQHSB.Text.Trim().Length > 0 && float.TryParse(txtQHSB.Text, out fltValidate) == false)
                {
                    MessageBoxEx.Show("起货设备(数量)必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQHSB.Focus();
                    return false;
                }
                if (txtQHSB.Text.Trim().Length == 0)
                {
                    txtQHSB.Text = "0";
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
