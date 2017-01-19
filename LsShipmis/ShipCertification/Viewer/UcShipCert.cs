using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CommonOperation.Interfaces;
using CommonOperation.BaseClass;
using BaseInfo.DataAccess;
using BaseInfo.Objects;
using BaseInfo.Viewer;
using ShipCertification.DataObject;
using ShipCertification.Services;
using CommonViewer.BaseControl;

namespace ShipCertification.Viewer
{
    public partial class UcShipCert : UserControl, IOneObjectViewer
    {
        #region 对象初始化
        ShipCert theObject = new ShipCert(); 
        public bool needRetrieve = false;
        #endregion

        public UcShipCert()
        {
            InitializeComponent();           
        }

        #region IOneObjectViewer成员
        /// <summary>
        /// 获取当前所选数据的对象.
        /// </summary>
        /// <param name="toChangeData"></param>
        public void ChangeData(CommonClass toChangeData)
        {
            
            if (!toChangeData.EqualTo(theObject))
            {
                DirectlyChangeData(toChangeData);
            }
        } 
        public void DirectlyChangeData(CommonClass toChangeData)
        {
            resetValue((ShipCert)toChangeData);
        }
 
        /// <summary>
        /// 清空.
        /// </summary>
        public void ClearData()
        {
            theObject = new ShipCert();            
            txtCertificationCode.Text = "";
            txtChineseName.Text = "";
            txtEnglishName.Text = "";
            txtAlertDays.Text = "90";
            cbxIfPrint.Checked = true;
            txtDefaultPeriod.Text = "";
            txtPrintFullName.Text = "";
            txtPrintShortName.Text = "";
            txtRemark.Text = "";
            txtSortNo.Text = "1";
        }
        /// <summary>
        /// 把用户所输入数据存放到theObject属性中.
        /// </summary>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool SetObject(out string err)
        {
            err = "";
            if (!theObject.IsWrong)
            { 
                theObject.SHIPCERTCODE = txtCertificationCode.Text;
                theObject.SHIPCERTCHNAME = txtChineseName.Text;
                theObject.SHIPCERTENNAME = txtEnglishName.Text;
                int alterDays;
                if (!int.TryParse(txtAlertDays.Text, out alterDays))
                {
                    theObject.ALERTDAYS = 90;
                }
                else
                {
                    theObject.ALERTDAYS = alterDays;
                }
                theObject.NEEDOUTPUTSHOW = cbxIfPrint.Checked;
                theObject.AIMTOCONFIG = txtPrintFullName.Text;
                theObject.AIMTOCONFIGSHORT = txtPrintShortName.Text;
                int sortNo;
                if (!int.TryParse(txtSortNo.Text, out sortNo))
                {
                    theObject.SORTNO = 1;
                }
                else
                {
                    theObject.SORTNO = sortNo;
                }
                decimal defaultPeriod;
                if (!decimal.TryParse(txtDefaultPeriod.Text, out defaultPeriod))
                {
                    theObject.EFFECTDATE = 0;
                }
                else
                {
                    theObject.EFFECTDATE = defaultPeriod;
                }
                theObject.REMARK = txtRemark.Text;
            }
            return true;
        }
        public void SetCanEdit(bool canEdit)
        {
            txtCertificationCode.ReadOnly = !canEdit;
            txtChineseName.ReadOnly = !canEdit;
            txtEnglishName.ReadOnly = !canEdit;
            txtDefaultPeriod.ReadOnly = !canEdit;
            txtAlertDays.ReadOnly = !canEdit;
            cbxIfPrint.Enabled  = canEdit;
            txtPrintFullName.ReadOnly = !canEdit;
            txtPrintShortName.ReadOnly = !canEdit;
            txtSortNo.ReadOnly = !canEdit;
            txtRemark.ReadOnly = !canEdit; 
        }
        #endregion

        /// <summary>
        /// 重置数据.
        /// </summary>
        private void resetValue(ShipCert toResetObject)
        {
            if (toResetObject != null && !toResetObject.IsWrong)
            {
                txtCertificationCode.Text = toResetObject.SHIPCERTCODE ;
                txtChineseName.Text = toResetObject.SHIPCERTCHNAME;
                txtEnglishName.Text = toResetObject.SHIPCERTENNAME;
                txtAlertDays.Text = toResetObject.ALERTDAYS.ToString();
                txtDefaultPeriod.Text = toResetObject.EFFECTDATE.ToString();
                cbxIfPrint.Checked = toResetObject.NEEDOUTPUTSHOW;
                txtPrintFullName.Text = toResetObject.AIMTOCONFIG;
                txtPrintShortName.Text = toResetObject.AIMTOCONFIGSHORT;
                txtSortNo.Text = toResetObject.SORTNO.ToString();
                txtRemark.Text = toResetObject.REMARK;
                theObject = toResetObject;
            }
            else ClearData();
        }
      
        public bool  UpdateObject()
        {
            string err;
            if (!beforeSaveCheck(out err))
            {
                MessageBoxEx.Show(err);
                return false;
            }
            if (theObject.IsWrong)
            {                
                MessageBoxEx.Show("当前对象无效,不能保存!");
                return false;                
            }
            else
            {
                if (SetObject(out err))
                {
                    if (!theObject.Update(out err))
                    {
                        MessageBoxEx.Show("当前对象保存失败,错误原因是:" + err);
                        return false;
                    }
                    else
                    {
                        needRetrieve = true;
                        MessageBoxEx.Show("保存成功");
                        return true;
                    }
                }
                else
                {
                    MessageBoxEx.Show("当前对象保存失败,错误原因是:" + err);
                    return false;
                }

            }
        }
        /// <summary>
        /// save之前检验.
        /// </summary>
        /// <param name="err"></param>
        /// <returns></returns>
        private bool beforeSaveCheck(out string err)
        {
            int alertdays;
            int sortNo;
            if (string.IsNullOrEmpty(txtChineseName.Text ) )
            {
                err = "证书中文名称必填。";
                txtChineseName.Focus();
                return false;
            }
            else if (!int.TryParse(txtAlertDays.Text, out alertdays) || alertdays <= 0)
            {
                err = "报警日期必须大于0,现置为默认值90天。";
                txtAlertDays.Text = "90";
                txtAlertDays.Focus();
                return false;
            }
            else if (!int.TryParse(txtSortNo.Text, out sortNo))
            {
                err = "排序号无效";
                txtSortNo.Text = "1";
                txtSortNo.Focus();
                return false;
            }
            else
            {
                err = "";
                return true;
            }
        }
        public void DeleteObject()
        {
            if (theObject.IsWrong || string.IsNullOrEmpty(theObject.GetId ()))
            {
                MessageBoxEx.Show("当前对象无效,不能删除!");
                return;
            }
            else
            {
                string err;
                DialogResult response = MessageBoxEx.Show("您确定要删除该条数据吗？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (response == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
                if (ShipCertService.Instance.deleteUnit(theObject.GetId(),out err))
                {
                    needRetrieve = true;
                    MessageBoxEx.Show("删除成功");
                }
                else
                {
                    MessageBoxEx.Show("当前对象删除失败,错误原因是:\n\n" + err);
                }
            }
        }    
    }
}
