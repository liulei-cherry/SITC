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
    public partial class UcShipInfo : UserControl, IOneObjectViewer
    {
        ShipInfo theObject = new ShipInfo ();
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();

        public ShipInfo TheObject
        {
            get
            {
                string err;
                SetObject(out err);
                return theObject;
            }
        }

        public UcShipInfo()
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
            theObject = (ShipInfo)toChangeData;
            if (theObject != null && !theObject.IsWrong)
            {
                btn_changePic.Enabled = true;
                txtShipName.Text = theObject.SHIP_NAME;
                txtShipEnName.Text = theObject.SHIP_EN_NAME;
                txtShipCode.Text = theObject.SHIP_CODE;
                txtShipHh.Text = theObject.SHIP_HH;
                txtIMO.Text = theObject.IMO;
                txtMMSI.Text = theObject.MMSI;
                txtCBDJH.Text = theObject.CBDJH;
                txtCQG.Text = theObject.CQG;
                txtCJG.Text = theObject.CJG;
                txtHQ.Text = theObject.HQ;
                txtCJFH.Text = theObject.CJFH;
                txtCBSYR.Text = theObject.CBSYR;
                txtShipType.Text = theObject.SHIP_TYPE;
                txtXK.Text = theObject.XK.ToString();
                txtXS.Text = theObject.XS.ToString();
                txtZC.Text = theObject.ZC.ToString();
                txtLZJC.Text = theObject.LZJC.ToString();
                txtQZCS.Text = theObject.QZCS.ToString();
                txtSJCS.Text = theObject.SJCS.ToString();
                txtQZPSL.Text = theObject.QZPSL.ToString();
                txtMZPSL.Text = theObject.MZPSL.ToString();
                txtZD.Text = theObject.ZD.ToString();
                txtJD.Text = theObject.JD.ToString();
                txtZZD.Text = theObject.ZZD.ToString();
                txtSYSZD.Text = theObject.SYSZD.ToString();
                txtBNMZD.Text = theObject.BNMZD.ToString();
                txtHS.Text = theObject.HS.ToString();
                txtZDPY.Text = theObject.ZDPY.ToString();
                txtZJXH.Text = theObject.ZJXH;
                txtZJTS.Text = theObject.ZJTS.ToString();
                txtZJGL.Text = theObject.ZJGL.ToString();
                txtZJZS.Text = theObject.ZJZS.ToString();
                txtZJJZC.Text = theObject.ZJJZC;
                dtpUcZJCZRQ.Text = theObject.ZJCZRQ.ToShortDateString();
                txtFDJYDJXH.Text = theObject.FDJYDJXH;
                txtFDJYDJTS.Text = theObject.FDJYDJTS.ToString();
                txtFDJYDJGL.Text = theObject.FDJYDJGL.ToString();
                txtFDJYDJZS.Text = theObject.FDJYDJZS.ToString();
                txtFDJXH.Text = theObject.FDJXH;
                txtFDJTS.Text = theObject.FDJTS.ToString();
                txtZYCL.Text = theObject.ZYCL.ToString();
                txtQYCL.Text = theObject.QYCL.ToString();
                txtDSCL.Text = theObject.DSCL.ToString();
                txtSSFGS.Text = theObject.SSFGS;
                dtpUcYYKSRQ.Text = theObject.YYKSRQ.ToShortDateString();
                dtpUcYYJSRQ.Text = theObject.YYJSRQ.ToShortDateString();
                txtRemark.Text = theObject.REMARK;
                txtZDHS.Text = theObject.ZDHS.ToString();
                txtCD.Text = theObject.CD;
                dtpZZRQ.Text = theObject.ZZRQ.ToShortDateString();
                txtCBZZC.Text = theObject.CBZZC;
                txtCW.Text = theObject.CW.ToString();
                txtZJGJ.Text = theObject.ZJGJ.ToString();
                txtZJXC.Text = theObject.ZJXC.ToString();
                txtZJYH.Text = theObject.ZJYH.ToString();
                txtSBZK.Text = theObject.ZJSBZK;
                txtFDJKYSL.Text = theObject.FJKYSL.ToString();
                txtRYXH1.Text = theObject.RYXH1;
                txtRYXH2.Text = theObject.RYXH2;
                txtHYXH.Text = theObject.HYXH;
                txtHYCR.Text = theObject.HYCR.ToString();
                txtXHHL.Text = theObject.XHHL.ToString();
                txtXHTS.Text = theObject.XHTS.ToString();
                txtXZTL.Text = theObject.XZTL.ToString();
                txtTLZJ.Text = theObject.TLZJ.ToString();
                txtTLJTS.Text = theObject.TLJTS.ToString();
                txtZDJ.Text = theObject.ZDJ.ToString();
                txtJSTSL.Text = theObject.JSTSL.ToString();
                txtJZTSL.Text = theObject.JZTSL.ToString();
                txtFDJGL.Text = theObject.FDJGL.ToString();
                setPic();
            }
            else
            {
                ClearData();
            }
        }

        private void setPic()
        {
            Stream fileStream; 
            FileOperationBase.Services.ourFile thePic;
            if (FileDbService.Instance.GetAFileById(theObject.PICTURE, out thePic))
            {
                if (FileDbService.Instance.GetABlobStreamById(thePic.Object_id, out fileStream))
                {
                    pictureBox1.Image = Image.FromStream(fileStream);
                }
            }
            else
            {
                pictureBox1.Image = null;
            }
        }
        public void DisablePictrueAdding()
        {
            btn_changePic.Enabled = false;
        }

        public void ClearData()
        {
            theObject = new ShipInfo();
            btn_changePic.Enabled = false;
            //主键值ship_id的绑定使用了txtShipName的Tag属性解决，无法使用隐藏的控件。.
            txtShipName.Text = "";
            txtShipEnName.Text = "";
            txtShipCode.Text = "";
            txtShipHh.Text = "";
            txtIMO.Text = "";
            txtMMSI.Text = "";
            txtCBDJH.Text = "";
            txtCQG.Text = "";
            txtCJG.Text = "";
            txtHQ.Text = "";
            txtCJFH.Text = "";
            txtCBSYR.Text = "";
            txtShipType.Text = "";
            txtXK.Text = "";
            txtXS.Text = "";
            txtZC.Text = "";
            txtLZJC.Text = "";
            txtQZCS.Text = "";
            txtSJCS.Text = "";
            txtQZPSL.Text = "";
            txtMZPSL.Text = "";
            txtZD.Text = "";
            txtJD.Text = "";
            txtZZD.Text = "";
            txtSYSZD.Text = "";
            txtBNMZD.Text = "";
            txtHS.Text = "";
            txtZDPY.Text = "";
            txtZJXH.Text = "";
            txtZJTS.Text = "";
            txtZJGL.Text = "";
            txtZJZS.Text = "";
            txtZJJZC.Text = "";
            dtpUcZJCZRQ.Text = "";
            txtFDJYDJXH.Text = "";
            txtFDJYDJTS.Text = "";
            txtFDJYDJGL.Text = "";
            txtFDJYDJZS.Text = "";
            txtFDJXH.Text = "";
            txtFDJTS.Text = "";
            txtZYCL.Text = "";
            txtQYCL.Text = "";
            txtDSCL.Text = "";
            txtSSFGS.Text = "";
            dtpUcYYKSRQ.Text = "";
            dtpUcYYJSRQ.Text = "";
            txtRemark.Text = "";
            txtZDHS.Text = "";
            txtCD.Text = "";
            dtpZZRQ.Text = "";
            txtCBZZC.Text = "";
            txtCW.Text = "";
            txtZJGJ.Text = "";
            txtZJXC.Text = "";
            txtZJYH.Text = "";
            txtSBZK.Text = "";
            txtFDJKYSL.Text = "";
            txtRYXH1.Text = "";
            txtRYXH2.Text = "";
            txtHYXH.Text = "";
            txtHYCR.Text = "";
            txtXHHL.Text = "";
            txtXHTS.Text = "";
            txtXZTL.Text = "";
            txtTLZJ.Text = "";
            txtTLJTS.Text = "";
            txtZDJ.Text = "";
            txtJSTSL.Text = "";
            txtJZTSL.Text = "";
            txtFDJGL.Text = "";
            pictureBox1.ImageLocation = "";
        }

        public bool SetObject(out string err)
        {
            err = "";
            if (theObject != null)
            {
                theObject.SHIP_NAME = txtShipName.Text;
                theObject.SHIP_EN_NAME = txtShipEnName.Text;
                theObject.SHIP_CODE = txtShipCode.Text;
                theObject.SHIP_HH = txtShipHh.Text;
                theObject.IMO = txtIMO.Text;
                theObject.MMSI = txtMMSI.Text;
                theObject.CBDJH = txtCBDJH.Text;
                theObject.CQG = txtCQG.Text;
                theObject.CJG = txtCJG.Text;
                theObject.HQ = txtHQ.Text;
                theObject.CJFH = txtCJFH.Text;
                theObject.CBSYR = txtCBSYR.Text;
                theObject.SHIP_TYPE = txtShipType.Text;
                theObject.XK = Decimal.Parse(txtXK.Text);
                theObject.XS = Decimal.Parse(txtXS.Text);
                theObject.ZC = Decimal.Parse(txtZC.Text);
                theObject.LZJC = Decimal.Parse(txtLZJC.Text);
                theObject.QZCS = Decimal.Parse(txtQZCS.Text);
                theObject.SJCS = Decimal.Parse(txtSJCS.Text);
                theObject.QZPSL = Decimal.Parse(txtQZPSL.Text);
                theObject.MZPSL = Decimal.Parse(txtMZPSL.Text);
                theObject.ZD = Decimal.Parse(txtZD.Text);
                theObject.JD = Decimal.Parse(txtJD.Text);
                theObject.ZZD = Decimal.Parse(txtZZD.Text);
                theObject.SYSZD = Decimal.Parse(txtSYSZD.Text);
                theObject.BNMZD = Decimal.Parse(txtBNMZD.Text);
                theObject.HS = Decimal.Parse(txtHS.Text);
                theObject.ZDPY = Decimal.Parse(txtZDPY.Text);
                theObject.ZJXH = txtZJXH.Text;
                theObject.ZJTS = Decimal.Parse(txtZJTS.Text);
                theObject.ZJGL = Decimal.Parse(txtZJGL.Text);
                theObject.ZJZS = Decimal.Parse(txtZJZS.Text);
                theObject.ZJJZC = txtZJJZC.Text;
                theObject.ZJCZRQ = DateTime.Parse(dtpUcZJCZRQ.Text);
                theObject.FDJYDJXH = txtFDJYDJXH.Text;
                theObject.FDJYDJTS = Decimal.Parse(txtFDJYDJTS.Text);
                theObject.FDJYDJGL = Decimal.Parse(txtFDJYDJGL.Text);
                theObject.FDJYDJZS = Decimal.Parse(txtFDJYDJZS.Text);
                theObject.FDJXH = txtFDJXH.Text;
                theObject.FDJTS = Decimal.Parse(txtFDJTS.Text);
                theObject.ZYCL = Decimal.Parse(txtZYCL.Text);
                theObject.QYCL = Decimal.Parse(txtQYCL.Text);
                theObject.DSCL = Decimal.Parse(txtDSCL.Text);
                theObject.SSFGS = txtSSFGS.Text;
                theObject.YYKSRQ = DateTime.Parse(dtpUcYYKSRQ.Text);
                theObject.YYJSRQ = DateTime.Parse(dtpUcYYJSRQ.Text);
                theObject.REMARK = txtRemark.Text;
                theObject.ZDHS = Decimal.Parse(txtZDHS.Text);
                theObject.CD = txtCD.Text;
                theObject.ZZRQ = DateTime.Parse(dtpZZRQ.Text);
                theObject.CBZZC = txtCBZZC.Text;
                theObject.CW = Decimal.Parse(txtCW.Text);
                theObject.ZJGJ = Decimal.Parse(txtZJGJ.Text);
                theObject.ZJXC = Decimal.Parse(txtZJXC.Text);
                theObject.ZJYH = Decimal.Parse(txtZJYH.Text);
                theObject.ZJSBZK = txtSBZK.Text;
                theObject.FJKYSL = Decimal.Parse(txtFDJKYSL.Text);
                theObject.RYXH1 = txtRYXH1.Text;
                theObject.RYXH2 = txtRYXH2.Text;
                theObject.HYXH = txtHYXH.Text;
                theObject.HYCR = Decimal.Parse(txtHYCR.Text);
                theObject.XHHL = Decimal.Parse(txtXHHL.Text);
                theObject.XHTS = Decimal.Parse(txtXHTS.Text);
                theObject.XZTL = Decimal.Parse(txtXZTL.Text);
                theObject.TLZJ = Decimal.Parse(txtTLZJ.Text);
                theObject.TLJTS = Decimal.Parse(txtTLJTS.Text);
                theObject.ZDJ = Decimal.Parse(txtZDJ.Text);
                theObject.JSTSL = Decimal.Parse(txtJSTSL.Text);
                theObject.JZTSL = Decimal.Parse(txtJZTSL.Text);
                theObject.FDJGL = Decimal.Parse(txtFDJGL.Text);               
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
            txtShipName.ReadOnly = !canEdit;
            btn_changePic.Enabled = canEdit;
            txtShipEnName.ReadOnly = !canEdit;
            txtShipCode.ReadOnly = !canEdit;
            txtShipHh.ReadOnly = !canEdit;
            txtIMO.ReadOnly = !canEdit;
            txtMMSI.ReadOnly = !canEdit;
            txtCBDJH.ReadOnly = !canEdit;
            txtCQG.ReadOnly = !canEdit;
            txtCJG.ReadOnly = !canEdit;
            txtHQ.ReadOnly = !canEdit;
            txtCJFH.ReadOnly = !canEdit;
            txtCBSYR.ReadOnly = !canEdit;
            txtShipType.ReadOnly = !canEdit;
            txtXK.ReadOnly = !canEdit;
            txtXS.ReadOnly = !canEdit;
            txtZC.ReadOnly = !canEdit;
            txtLZJC.ReadOnly = !canEdit;
            txtQZCS.ReadOnly = !canEdit;
            txtSJCS.ReadOnly = !canEdit;
            txtQZPSL.ReadOnly = !canEdit;
            txtMZPSL.ReadOnly = !canEdit;
            txtZD.ReadOnly = !canEdit;
            txtJD.ReadOnly = !canEdit;
            txtZZD.ReadOnly = !canEdit;
            txtSYSZD.ReadOnly = !canEdit;
            txtBNMZD.ReadOnly = !canEdit;
            txtHS.ReadOnly = !canEdit;
            txtZDPY.ReadOnly = !canEdit;
            txtZJXH.ReadOnly = !canEdit;
            txtZJTS.ReadOnly = !canEdit;
            txtZJGL.ReadOnly = !canEdit;
            txtZJZS.ReadOnly = !canEdit;
            txtZJJZC.ReadOnly = !canEdit;
            //dtpUcZJCZRQ.Enabled = canEdit;
            dtpUcZJCZRQ.ReadOnly = !canEdit;
            txtFDJYDJXH.ReadOnly = !canEdit;
            txtFDJYDJTS.ReadOnly = !canEdit;
            txtFDJYDJGL.ReadOnly = !canEdit;
            txtFDJYDJZS.ReadOnly = !canEdit;
            txtFDJXH.ReadOnly = !canEdit;
            txtFDJTS.ReadOnly = !canEdit;
            txtZYCL.ReadOnly = !canEdit;
            txtQYCL.ReadOnly = !canEdit;
            txtDSCL.ReadOnly = !canEdit;
            txtSSFGS.ReadOnly = !canEdit;
            dtpUcYYKSRQ.ReadOnly = !canEdit;
            dtpUcYYJSRQ.ReadOnly = !canEdit;
            //dtpUcYYKSRQ.Enabled = canEdit;
            //dtpUcYYJSRQ.Enabled = canEdit;
            txtRemark.ReadOnly = !canEdit;
            txtZDHS.ReadOnly = !canEdit;
            txtCD.ReadOnly = !canEdit;
            dtpZZRQ.ReadOnly = !canEdit;
            //dtpZZRQ.Enabled = canEdit;
            txtCBZZC.ReadOnly = !canEdit;
            txtCW.ReadOnly = !canEdit;
            txtZJGJ.ReadOnly = !canEdit;
            txtZJXC.ReadOnly = !canEdit;
            txtZJYH.ReadOnly = !canEdit;
            txtSBZK.ReadOnly = !canEdit;
            txtFDJKYSL.ReadOnly = !canEdit;
            txtRYXH1.ReadOnly = !canEdit;
            txtRYXH2.ReadOnly = !canEdit;
            txtHYXH.ReadOnly = !canEdit;
            txtHYCR.ReadOnly = !canEdit;
            txtXHHL.ReadOnly = !canEdit;
            txtXHTS.ReadOnly = !canEdit;
            txtXZTL.ReadOnly = !canEdit;
            txtTLZJ.ReadOnly = !canEdit;
            txtTLJTS.ReadOnly = !canEdit;
            txtZDJ.ReadOnly = !canEdit;
            txtJSTSL.ReadOnly = !canEdit;
            txtJZTSL.ReadOnly = !canEdit;
            txtFDJGL.ReadOnly = !canEdit;
        }

        #endregion
 
        public bool UpdateObject()
        {
            string err;            
            if (!beforeSaveCheck(out err))
            {
                MessageBoxEx.Show(err);
                return false;
            }
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

        private bool beforeSaveCheck(out string err)
        {
            float fltValidate = 0.0f;
            if (string.IsNullOrEmpty(txtShipName.Text))
            {
                err = "中文船名为必填字段";
                return false;
            }
            if (string.IsNullOrEmpty(txtShipCode.Text))
            {
                err = "船舶缩写代号必填,作为申请单等的船舶代号使用!";
                return false;
            }
            if (txtXK.Text.Trim().Length > 0 && float.TryParse(txtXK.Text, out fltValidate) == false)
            {
                err = "型宽必须是数值型数据！";
                txtXK.Focus();
                return false;
            }
            if (txtXK.Text.Trim().Length == 0)
            {
                txtXK.Text = "0";
            }
            if (txtXS.Text.Trim().Length > 0 && float.TryParse(txtXS.Text, out fltValidate) == false)
            {
                err = "型深必须是数值型数据！";
                txtXS.Focus();
                return false;
            }
            if (txtXS.Text.Trim().Length == 0)
            {
                txtXS.Text = "0";
            }
            if (txtZC.Text.Trim().Length > 0 && float.TryParse(txtZC.Text, out fltValidate) == false)
            {
                err = "总长必须是数值型数据！";
                txtZC.Focus();
                return false;
            }
            if (txtZC.Text.Trim().Length == 0)
            {
                txtZC.Text = "0";
            }
            if (txtLZJC.Text.Trim().Length > 0 && float.TryParse(txtLZJC.Text, out fltValidate) == false)
            {
                err = "垂线间长必须是数值型数据！";
                txtLZJC.Focus();
                return false;
            }
            if (txtLZJC.Text.Trim().Length == 0)
            {
                txtLZJC.Text = "0";
            }
            if (txtQZCS.Text.Trim().Length > 0 && float.TryParse(txtQZCS.Text, out fltValidate) == false)
            {
                err = "轻载吃水必须是数值型数据！";
                txtQZCS.Focus();
                return false;
            }
            if (txtQZCS.Text.Trim().Length == 0)
            {
                txtQZCS.Text = "0";
            }
            if (txtSJCS.Text.Trim().Length > 0 && float.TryParse(txtSJCS.Text, out fltValidate) == false)
            {
                err = "设计吃水必须是数值型数据！";
                txtSJCS.Focus();
                return false;
            }
            if (txtSJCS.Text.Trim().Length == 0)
            {
                txtSJCS.Text = "0";
            }
            if (txtQZPSL.Text.Trim().Length > 0 && float.TryParse(txtQZPSL.Text, out fltValidate) == false)
            {
                err = "轻载排水量必须是数值型数据！";
                txtQZPSL.Focus();
                return false;
            }
            if (txtQZPSL.Text.Trim().Length == 0)
            {
                txtQZPSL.Text = "0";
            }
            if (txtMZPSL.Text.Trim().Length > 0 && float.TryParse(txtMZPSL.Text, out fltValidate) == false)
            {
                err = "满载排水量必须是数值型数据！";
                txtMZPSL.Focus();
                return false;
            }
            if (txtMZPSL.Text.Trim().Length == 0)
            {
                txtMZPSL.Text = "0";
            }
            if (txtZD.Text.Trim().Length > 0 && float.TryParse(txtZD.Text, out fltValidate) == false)
            {
                err = "总吨必须是数值型数据！";
                txtZD.Focus();
                return false;
            }
            if (txtZD.Text.Trim().Length == 0)
            {
                txtZD.Text = "0";
            }
            if (txtJD.Text.Trim().Length > 0 && float.TryParse(txtJD.Text, out fltValidate) == false)
            {
                err = "净吨必须是数值型数据！";
                txtJD.Focus();
                return false;
            }
            if (txtJD.Text.Trim().Length == 0)
            {
                txtJD.Text = "0";
            }
            if (txtZZD.Text.Trim().Length > 0 && float.TryParse(txtZZD.Text, out fltValidate) == false)
            {
                err = "载重吨必须是数值型数据！";
                txtZZD.Focus();
                return false;
            }
            if (txtZZD.Text.Trim().Length == 0)
            {
                txtZZD.Text = "0";
            }
            if (txtSYSZD.Text.Trim().Length > 0 && float.TryParse(txtSYSZD.Text, out fltValidate) == false)
            {
                err = "苏伊士运河吨必须是数值型数据！";
                txtSYSZD.Focus();
                return false;
            }
            if (txtSYSZD.Text.Trim().Length == 0)
            {
                txtSYSZD.Text = "0";
            }
            if (txtBNMZD.Text.Trim().Length > 0 && float.TryParse(txtBNMZD.Text, out fltValidate) == false)
            {
                err = "巴拿马运河吨必须是数值型数据！";
                txtBNMZD.Focus();
                return false;
            }
            if (txtBNMZD.Text.Trim().Length == 0)
            {
                txtBNMZD.Text = "0";
            }
            if (txtHS.Text.Trim().Length > 0 && float.TryParse(txtHS.Text, out fltValidate) == false)
            {
                err = "航速必须是数值型数据！";
                txtHS.Focus();
                return false;
            }
            if (txtHS.Text.Trim().Length == 0)
            {
                txtHS.Text = "0";
            }
            if (txtZDPY.Text.Trim().Length > 0 && float.TryParse(txtZDPY.Text, out fltValidate) == false)
            {
                err = "最低配员必须是数值型数据！";
                txtZDPY.Focus();
                return false;
            }
            if (txtZDPY.Text.Trim().Length == 0)
            {
                txtZDPY.Text = "0";
            }
            if (txtZJTS.Text.Trim().Length > 0 && float.TryParse(txtZJTS.Text, out fltValidate) == false)
            {
                err = "主机台数必须是数值型数据！";
                txtZJTS.Focus();
                return false;
            }
            if (txtZJTS.Text.Trim().Length == 0)
            {
                txtZJTS.Text = "0";
            }
            if (txtZJGL.Text.Trim().Length > 0 && float.TryParse(txtZJGL.Text, out fltValidate) == false)
            {
                err = "主机功率必须是数值型数据！";
                txtZJGL.Focus();
                return false;
            }
            if (txtZJGL.Text.Trim().Length == 0)
            {
                txtZJGL.Text = "0";
            }
            if (txtZJZS.Text.Trim().Length > 0 && float.TryParse(txtZJZS.Text, out fltValidate) == false)
            {
                err = "主机转速必须是数值型数据！";
                txtZJZS.Focus();
                return false;
            }
            if (txtZJZS.Text.Trim().Length == 0)
            {
                txtZJZS.Text = "0";
            }
            if (txtFDJYDJTS.Text.Trim().Length > 0 && float.TryParse(txtFDJYDJTS.Text, out fltValidate) == false)
            {
                err = "发电机原动机台数必须是数值型数据！";
                txtFDJYDJTS.Focus();
                return false;
            }
            if (txtFDJYDJTS.Text.Trim().Length == 0)
            {
                txtFDJYDJTS.Text = "0";
            } 
            if (txtFDJYDJGL.Text.Trim().Length > 0 && float.TryParse(txtFDJYDJGL.Text, out fltValidate) == false)
            {
                err = "发电机原动机功率必须是数值型数据！";
                txtFDJYDJGL.Focus();
                return false;
            }
            if (txtFDJYDJGL.Text.Trim().Length == 0)
            {
                txtFDJYDJGL.Text = "0";
            }
            if (txtFDJYDJZS.Text.Trim().Length > 0 && float.TryParse(txtFDJYDJZS.Text, out fltValidate) == false)
            {
                err = "发动机原动机转速必须是数值型数据！";
                txtFDJYDJZS.Focus();
                return false;
            }
            if (txtFDJYDJZS.Text.Trim().Length == 0)
            {
                txtFDJYDJZS.Text = "0";
            }
            if (txtFDJTS.Text.Trim().Length > 0 && float.TryParse(txtFDJTS.Text, out fltValidate) == false)
            {
                err = "发电机台数必须是数值型数据！";
                txtFDJTS.Focus();
                return false;
            }
            if (txtFDJTS.Text.Trim().Length == 0)
            {
                txtFDJTS.Text = "0";
            }
            if (txtZYCL.Text.Trim().Length > 0 && float.TryParse(txtZYCL.Text, out fltValidate) == false)
            {
                err = "重油储量必须是数值型数据！";
                txtZYCL.Focus();
                return false;
            }
            if (txtZYCL.Text.Trim().Length == 0)
            {
                txtZYCL.Text = "0";
            }
            if (txtQYCL.Text.Trim().Length > 0 && float.TryParse(txtQYCL.Text, out fltValidate) == false)
            {
                err = "轻油储量必须是数值型数据！";
                txtQYCL.Focus();
                return false;
            }
            if (txtQYCL.Text.Trim().Length == 0)
            {
                txtQYCL.Text = "0";
            }
            if (txtDSCL.Text.Trim().Length > 0 && float.TryParse(txtDSCL.Text, out fltValidate) == false)
            {
                err = "淡水储量必须是数值型数据！";
                txtDSCL.Focus();
                return false;
            }
            if (txtDSCL.Text.Trim().Length == 0)
            {
                txtDSCL.Text = "0";
            }
            if (txtZDHS.Text.Trim().Length > 0 && float.TryParse(txtZDHS.Text, out fltValidate) == false)
            {
                err = "最大航速必须是数值型数据！";
                txtZDHS.Focus();
                return false;
            }
            if (txtZDHS.Text.Trim().Length == 0)
            {
                txtZDHS.Text = "0";
            }
            if (txtCW.Text.Trim().Length > 0 && float.TryParse(txtCW.Text, out fltValidate) == false)
            {
                err = "床位必须是数值型数据！";
                txtCW.Focus();
                return false;
            }
            if (txtCW.Text.Trim().Length == 0)
            {
                txtCW.Text = "0";
            }
            if (txtZJGJ.Text.Trim().Length > 0 && float.TryParse(txtZJGJ.Text, out fltValidate) == false)
            {
                err = "主机缸径必须是数值型数据！";
                txtZJGJ.Focus();
                return false;
            }
            if (txtZJGJ.Text.Trim().Length == 0)
            {
                txtZJGJ.Text = "0";
            }
            if (txtZJXC.Text.Trim().Length > 0 && float.TryParse(txtZJXC.Text, out fltValidate) == false)
            {
                err = "主机行程必须是数值型数据！";
                txtZJXC.Focus();
                return false;
            }
            if (txtZJXC.Text.Trim().Length == 0)
            {
                txtZJXC.Text = "0";
            }
            if (txtZJYH.Text.Trim().Length > 0 && float.TryParse(txtZJYH.Text, out fltValidate) == false)
            {
                err = "主机油耗必须是数值型数据！";
                txtZJYH.Focus();
                return false;
            }
            if (txtZJYH.Text.Trim().Length == 0)
            {
                txtZJYH.Text = "0";
            }
            if (txtFDJKYSL.Text.Trim().Length > 0 && float.TryParse(txtFDJKYSL.Text, out fltValidate) == false)
            {
                err = "副机可用数量必须是数值型数据！";
                txtFDJKYSL.Focus();
                return false;
            }
            if (txtFDJKYSL.Text.Trim().Length == 0)
            {
                txtFDJKYSL.Text = "0";
            }
            if (txtHYCR.Text.Trim().Length > 0 && float.TryParse(txtHYCR.Text, out fltValidate) == false)
            {
                err = "滑油仓容必须是数值型数据！";
                txtHYCR.Focus();
                return false;
            }
            if (txtHYCR.Text.Trim().Length == 0)
            {
                txtHYCR.Text = "0";
            }
            if (txtXHHL.Text.Trim().Length > 0 && float.TryParse(txtXHHL.Text, out fltValidate) == false)
            {
                err = "续航海里必须是数值型数据！";
                txtXHHL.Focus();
                return false;
            }
            if (txtXHHL.Text.Trim().Length == 0)
            {
                txtXHHL.Text = "0";
            }
            if (txtXHTS.Text.Trim().Length > 0 && float.TryParse(txtXHTS.Text, out fltValidate) == false)
            {
                err = "续航天数必须是数值型数据！";
                txtXHTS.Focus();
                return false;
            }
            if (txtXHTS.Text.Trim().Length == 0)
            {
                txtXHTS.Text = "0";
            }
            if (txtXZTL.Text.Trim().Length > 0 && float.TryParse(txtXZTL.Text, out fltValidate) == false)
            {
                err = "系柱拖力必须是数值型数据！";
                txtXZTL.Focus();
                return false;
            }
            if (txtXZTL.Text.Trim().Length == 0)
            {
                txtXZTL.Text = "0";
            }
            if (txtTLZJ.Text.Trim().Length > 0 && float.TryParse(txtTLZJ.Text, out fltValidate) == false)
            {
                err = "拖缆直径必须是数值型数据！";
                txtTLZJ.Focus();
                return false;
            }
            if (txtTLZJ.Text.Trim().Length == 0)
            {
                txtTLZJ.Text = "0";
            }
            if (txtTLJTS.Text.Trim().Length > 0 && float.TryParse(txtTLJTS.Text, out fltValidate) == false)
            {
                err = "拖缆机台数必须是数值型数据！";
                txtTLJTS.Focus();
                return false;
            }
            if (txtTLJTS.Text.Trim().Length == 0)
            {
                txtTLJTS.Text = "0";
            }
            if (txtZDJ.Text.Trim().Length > 0 && float.TryParse(txtZDJ.Text, out fltValidate) == false)
            {
                err = "制淡机必须是数值型数据！";
                txtZDJ.Focus();
                return false;
            }
            if (txtZDJ.Text.Trim().Length == 0)
            {
                txtZDJ.Text = "0";
            }
            if (txtJSTSL.Text.Trim().Length > 0 && float.TryParse(txtJSTSL.Text, out fltValidate) == false)
            {
                err = "救生艇数量必须是数值型数据！";
                txtJSTSL.Focus();
                return false;
            }
            if (txtJSTSL.Text.Trim().Length == 0)
            {
                txtJSTSL.Text = "0";
            }
            if (txtJZTSL.Text.Trim().Length > 0 && float.TryParse(txtJZTSL.Text, out fltValidate) == false)
            {
                err = "救助艇数量必须是数值型数据！";
                txtJZTSL.Focus();
                return false;
            }
            if (txtJZTSL.Text.Trim().Length == 0)
            {
                txtJZTSL.Text = "0";
            }
            if (txtFDJGL.Text.Trim().Length > 0 && float.TryParse(txtFDJGL.Text, out fltValidate) == false)
            {
                err = "发电机功率必须是数值型数据！";
                txtFDJGL.Focus();
                return false;
            }
            if (txtFDJGL.Text.Trim().Length == 0)
            {
                txtFDJGL.Text = "0";
            }
            if (!ShipInfoService.Instance.JustTheNameOrNoExist(txtShipName.Text, txtShipCode.Text,theObject.GetId(), out err))
            {
                return false;
            }
            err = "";
            return true;
        }

        //更改图片.
        private void btn_changePic_Click(object sender, EventArgs e)
        {
            //判断ship_id是否有效,有效则插入,否则提示用户不能插入图片.
            if (theObject == null || theObject.IsWrong)
            {
                MessageBoxEx.Show("仅能为已经保存的船舶添加或修改图片!");
                return;
            }
            if (OpenFileDialogEx.ShowDialog(openFileDialog) != DialogResult.OK)
            {
                //MessageBoxEx.Show("用户取消操作!");
                return;
            }
            string filename = openFileDialog.FileName;
            //导入数据库.
            string err;

            if (!ShipInfoService.Instance.InsertAPicToShip(theObject, filename, out err))
            {
                MessageBoxEx.Show(err, "插入图片出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                setPic();
            }
        }
    }
}
