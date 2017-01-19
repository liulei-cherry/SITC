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
    /// <summary>
    /// 本控件有4种显示方式,
    /// 1.普通添加的新证书:所有元素均可以维护,如果是船舶端,则船舶不能修改.
    /// 2.修改某个证书:船舶不让修改,其他属性可以修改,注意修改的时候保证有效证书不重复.
    /// 3.检查某个证书:只能改换证和签章,检验日期,备注,其他元素不让修改,
    /// 4.对某个证书形成下次检验相关信息:只能修改各种日期,备注,换证签章.
    /// </summary>
    public partial class UcShipCertRegister : UserControl, IOneObjectViewer
    {
        bool initing = false;
        ShipCertRegister theObject = new ShipCertRegister();
        public ShipCertRegister TheObject
        {
            get
            {
                string err;
                SetObject(out err);
                return theObject;
            }
        }

        public UcShipCertRegister()
        {
            InitializeComponent();
            initing = true;
            initDropDownControls();
            ucShipSelect1.ChangeSelectedState(false);
            ucShipCertSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(ucShipCertSelect1_TheSelectedChanged);
            initing = false;
            cboShipCertType_SelectedIndexChanged(null, null);
        }

        public UcShipCertRegister(ShipCertRegister theObjectIn, int checkType)
            : this()
        {
            theObject = theObjectIn;
        }

        void ucShipCertSelect1_TheSelectedChanged(string theSelectedObject)
        {
            if (!string.IsNullOrEmpty(theSelectedObject))
            {
                //获取默认的报警日期并给报警日期赋值；.
                ShipCert theSelectedShipCert = (ShipCert)ShipCertService.Instance.GetOneObjectById(theSelectedObject);
                if (theSelectedShipCert != null && !theSelectedShipCert.IsWrong)
                {
                    txtAlertDays.Text = theSelectedShipCert.ALERTDAYS.ToString();
                    txtSortNo.ReadOnly = true;
                    txtSortNo.Text = theSelectedShipCert.SORTNO.ToString();
                    cboShipCertType.Enabled = false;
                    if (theSelectedShipCert.EFFECTDATE == 0)
                    {
                        cboShipCertType.SelectedValue = 1;
                    }
                    else
                    {
                        cboShipCertType.SelectedValue = 2;
                        txtEffectDate.Text = theSelectedShipCert.EFFECTDATE.ToString();
                    }
                    //      if (txtCertName.Text.Length == 0)
                    txtCertName.Text = theSelectedShipCert.ToString();
                }
                else
                {
                    cboShipCertType.Enabled = true;
                    txtSortNo.ReadOnly = false;
                    txtSortNo.Text = "0";
                }
            }
            else
            {
                cboShipCertType.Enabled = true;
                txtCertName.Text = "";
            }
        }

        /// <summary>
        /// /// <summary>
        /// 设置船舶是否可修改.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// </summary>
        /// <param name="isVisible"></param>
        public void setShipNameVisible(bool isVisible)
        {
            if (isVisible == true)
            {
                ucShipSelect1.Enabled = true;

            }
            else
            {
                ucShipSelect1.Enabled = false;
            }

        }
        /// <summary>
        /// 给船舶设置默认值，且不可修改.
        /// </summary>
        /// <param name="ship_id"></param>
        public void setShipSelectName(string ship_id)
        {
            ucShipSelect1.SelectedId(ship_id);
            setShipNameVisible(false);
        }
        private void initDropDownControls()
        {
            //证书类型下拉列表框.
            DataTable dtbShipCertType = new DataTable();
            dtbShipCertType.Columns.Add("Id", typeof(string));
            dtbShipCertType.Columns.Add("Type", typeof(string));
            DataRow row0 = dtbShipCertType.NewRow();
            row0["Id"] = "1";
            row0["Type"] = "长期有效证书";
            DataRow row1 = dtbShipCertType.NewRow();
            row1["Id"] = "2";
            row1["Type"] = "定期检查证书";
            DataRow row2 = dtbShipCertType.NewRow();
            row2["Id"] = "3";
            row2["Type"] = "临时(条件)证书";
            DataRow row3 = dtbShipCertType.NewRow();
            row3["Id"] = "4";
            row3["Type"] = "存档或作废证书";
            dtbShipCertType.Rows.Add(row0);
            dtbShipCertType.Rows.Add(row1);
            dtbShipCertType.Rows.Add(row2);
            dtbShipCertType.Rows.Add(row3);

            cboShipCertType.DataSource = dtbShipCertType;
            cboShipCertType.DisplayMember = "Type";
            cboShipCertType.ValueMember = "Id";
        }
        #region IOneObjectViewer 成员

        public void ChangeData(CommonClass toChangeData)
        {
            if (!toChangeData.EqualTo(theObject))
            {
                DirectlyChangeData(toChangeData);
            }
            else
            {
                ClearData();
            }
        }

        public void ClearData()
        {
            this.theObject = new ShipCertRegister();
            ucShipCertSelect1.SelectedId("");
            txtCertCode.Text = "";
            cboShipCertType.Text = "长期有效证书";
            ucShipCertDepartSelect1.SelectedId("");
            ucShipSelect1.SelectedId("");
            txtCertName.Text = "";
            dtBegin.Text = "";
            txtDetail.Text = "";
            txtEffectDate.Text = "";
            rbChange.Checked = false;
            rbStamp.Checked = false;

            txtAlertDays.Visible = false;
            labelAlterDays.Visible = false;
            if (string.IsNullOrEmpty(txtAlertDays.Text)) txtAlertDays.Text = "1";
            dtEnd.Visible = false;
            labelEnd.Visible = false;
            dtEnd.Value = CommonOperation.ConstParameter.MaxDateTime;
            dtOverDue.Value = CommonOperation.ConstParameter.MaxDateTime;
            txtEffectDate.Visible = false;
            label1.Visible = false;
            label6.Visible = false;
            dtOverDue.Visible = false;
            label7.Visible = false;
        }

        public void ClearDataNoShip()
        {
            this.theObject = new ShipCertRegister();
            ucShipCertSelect1.SelectedId("");
            txtCertCode.Text = "";
            cboShipCertType.Text = "长期有效证书";
            ucShipCertDepartSelect1.SelectedId("");
            ucShipSelect1.SelectedId("");
            txtCertName.Text = "";
            dtBegin.Text = "";
            txtDetail.Text = "";
            txtEffectDate.Text = "";
            rbChange.Checked = false;
            rbStamp.Checked = false;

            txtAlertDays.Visible = false;
            labelAlterDays.Visible = false;
            if (string.IsNullOrEmpty(txtAlertDays.Text)) txtAlertDays.Text = "1";
            dtEnd.Visible = false;
            labelEnd.Visible = false;
            dtEnd.Value = CommonOperation.ConstParameter.MaxDateTime;
            dtOverDue.Value = CommonOperation.ConstParameter.MaxDateTime;
            txtEffectDate.Visible = false;
            label1.Visible = false;
            label6.Visible = false;
            dtOverDue.Visible = false;
            label7.Visible = false;
        }
        public bool SetObject(out string err)
        {
            err = "";
            if (!theObject.IsWrong)
            {
                theObject.SHIP_CERT_NAME = txtCertName.Text;
                theObject.SHIP_CERT_DEPARTID = ucShipCertDepartSelect1.GetId();
                theObject.SHIP_CERT_ID = ucShipCertSelect1.GetId();
                theObject.SHIPCERTNUMB = txtCertCode.Text;
                theObject.PLACE = txtPlace.Text;
                int certtype;
                if (!int.TryParse(cboShipCertType.SelectedValue.ToString(), out certtype))
                {
                    theObject.SHIPCERTTYPE = 1;
                }
                else theObject.SHIPCERTTYPE = certtype;
                theObject.SHIP_ID = ucShipSelect1.GetId();
                int alterDays;
                if (!int.TryParse(txtAlertDays.Text, out alterDays))
                {
                    theObject.ALERTDAYS = 90;
                }
                else
                {
                    theObject.ALERTDAYS = alterDays;
                }
                decimal effectDays;
                if (!txtEffectDate.Visible)
                {
                    theObject.EFFECTDATE = 0;
                }
                else if (decimal.TryParse(txtEffectDate.Text, out effectDays) && effectDays > 0)
                {
                    theObject.EFFECTDATE = effectDays;
                }
                else
                {
                    theObject.EFFECTDATE = 5;
                }
                
                DateTime dtTemp;
                if (dtBegin.TextBox.Text.Length > 0 && DateTime.TryParse(dtBegin.TextBox.Text, out dtTemp))
                    theObject.SIGNEDDATE = dtBegin.Value;

                if (dtOverDue.TextBox.Text.Length > 0 && DateTime.TryParse(dtOverDue.TextBox.Text, out dtTemp))
                    theObject.EXPIREDATE = dtOverDue.Value;
                else
                {
                    theObject.EXPIREDATE = CommonOperation.ConstParameter.MaxDateTime;
                }
                if (dtEnd.Visible && dtEnd.TextBox.Text.Length > 0 && DateTime.TryParse(dtEnd.TextBox.Text, out dtTemp))
                    theObject.MATUREDATE = dtEnd.Value;
                else
                    theObject.MATUREDATE = CommonOperation.ConstParameter.MaxDateTime;
                if (!rbChange.Checked)
                {
                    theObject.RECERTIFICATION = 0;
                }
                else
                {
                    theObject.RECERTIFICATION = 1;
                }
                int sortNo;
                if (!int.TryParse(txtSortNo.Text, out sortNo))
                {
                    sortNo = 0;
                }

                theObject.SORTNO = sortNo;
                theObject.REMARK = txtDetail.Text;
                return true;
            }
            else
            {
                err = "当前对象无效,不能保存!";
                return false;
            }
        }

        public void SetCanEdit(bool canEdit)
        {
            ucShipCertDepartSelect1.Enabled = canEdit;
            ucShipCertSelect1.Enabled = canEdit;
            txtCertName.ReadOnly = !canEdit;
            txtCertCode.ReadOnly = !canEdit;
            cboShipCertType.Enabled = canEdit;
            txtEffectDate.ReadOnly = !canEdit;
            ucShipSelect1.Enabled = canEdit;
            txtAlertDays.ReadOnly = !canEdit;
            dtBegin.ReadOnly = !canEdit;
            dtEnd.ReadOnly = !canEdit;
            txtDetail.ReadOnly = !canEdit;
            rbChange.Enabled = canEdit;
            rbStamp.Enabled = canEdit;
            dtOverDue.ReadOnly = !canEdit;
            //不用分船舶和岸端，船端仅有一条船.
        }

        #endregion

        private void resetValue(ShipCertRegister toResetObject)
        {
            ClearData();
            if (toResetObject == null || toResetObject.IsWrong)
            {
                ClearData();
                return;
            }
            initing = true;
            cboShipCertType.SelectedValue = (int)toResetObject.SHIPCERTTYPE;
            ucShipSelect1.SelectedId(toResetObject.SHIP_ID);
            ucShipCertDepartSelect1.SelectedId(toResetObject.SHIP_CERT_DEPARTID != null ? toResetObject.SHIP_CERT_DEPARTID : "");
            if (!string.IsNullOrEmpty(toResetObject.SHIP_CERT_ID))
            {
                ucShipCertSelect1.SelectedId(toResetObject.SHIP_CERT_ID != null ? toResetObject.SHIP_CERT_ID : "");
                txtSortNo.ReadOnly = true;
            }
            else
            {
                txtSortNo.ReadOnly = false;
            }
            txtCertName.Text = toResetObject.SHIP_CERT_NAME;
            txtCertCode.Text = toResetObject.SHIPCERTNUMB;
            txtPlace.Text = toResetObject.PLACE;
            txtAlertDays.Text = toResetObject.ALERTDAYS.ToString();
            if (toResetObject.SIGNEDDATE != null)
                dtBegin.Value = toResetObject.SIGNEDDATE;
            if (toResetObject.MATUREDATE != null && toResetObject.MATUREDATE < CommonOperation.ConstParameter.MaxDateTime)
                dtEnd.Value = toResetObject.MATUREDATE;
            if (toResetObject.EXPIREDATE != null && toResetObject.EXPIREDATE < CommonOperation.ConstParameter.MaxDateTime)
                dtOverDue.Value = toResetObject.EXPIREDATE;
            txtEffectDate.Text = toResetObject.EFFECTDATE.ToString();
            txtDetail.Text = toResetObject.REMARK;

            if (toResetObject.RECERTIFICATION == 0)
            {
                rbStamp.Checked = true;
            }
            else
            {
                rbChange.Checked = true;
            }
            theObject = toResetObject;
            initing = false;
            //最后设置这个，为了让界面刷新.
            cboShipCertType_SelectedIndexChanged(null, null);
            txtSortNo.Text = toResetObject.SORTNO.ToString();
        }

        public bool UpdateObject()
        {
            string err;
            SetObject(out err);
            if (!beforeSaveCheck(out err))
            {
                MessageBoxEx.Show(err);
                return false;
            }
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
            MessageBoxEx.Show("保存成功");
            return true;
        }

        private bool beforeSaveCheck(out string err)
        {
            int alertdays;
            if (string.IsNullOrEmpty(theObject.SHIP_ID))
            {
                err = "船舶必须选择，否则无法保存";
                return false;
            }
            else if (string.IsNullOrEmpty(theObject.SHIP_CERT_NAME))
            {
                err = "证书名称必须填写，否则无法保存";
                txtCertName.Select();
                return false;
            }
            else if (!string.IsNullOrEmpty(theObject.SHIP_CERT_ID) &&
                !ShipCertRegisterService.Instance.HaveNotTheCert(theObject.SHIP_ID, theObject.SHIP_CERT_ID, theObject.GetId()))
            {
                err = "此船舶已经添加过此标准证书，不允许同一个证书添加多次！";
                return false;
            }
            else if (txtAlertDays.Visible && (!int.TryParse(txtAlertDays.Text, out alertdays) || alertdays <= 0))
            {
                err = "报警日期必须大于0,现置为默认值90天。";
                txtAlertDays.Text = "90";
                txtAlertDays.Focus();
                return false;
            }
            err = "";
            return true;
        }

        #region IOneObjectViewer 成员

        public void DirectlyChangeData(CommonClass toChangeData)
        {
            resetValue((ShipCertRegister)toChangeData);
        }

        #endregion

        private void cboShipCertType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (initing) return;
            //row0["Id"] = "1";
            //row0["Type"] = "长期有效证书";
            //DataRow row1 = dtbShipCertType.NewRow();
            //row1["Id"] = "2";
            //row1["Type"] = "定期检查证书";
            //DataRow row2 = dtbShipCertType.NewRow();
            //row2["Id"] = "3";
            //row2["Type"] = "临时颁发证书";
            //DataRow row3 = dtbShipCertType.NewRow();
            //row3["Id"] = "4";
            //row3["Type"] = "存档证书";
            //不同的证书看到不同的内容。.
            if ((int)cboShipCertType.SelectedIndex + 1 == 1)
            {
                txtAlertDays.Visible = false;
                labelAlterDays.Visible = false;
                if (string.IsNullOrEmpty(txtAlertDays.Text)) txtAlertDays.Text = "1";
                dtEnd.Visible = false;
                labelEnd.Visible = false;
                dtEnd.Value = CommonOperation.ConstParameter.MaxDateTime;
                dtOverDue.Value = CommonOperation.ConstParameter.MaxDateTime;
                txtEffectDate.Visible = false;
                label1.Visible = false;
                label6.Visible = false;
                dtOverDue.Visible = false;
                label7.Visible = false;
                rbChange.Visible = false;
                rbStamp.Visible = false;
            }
            else if ((int)cboShipCertType.SelectedIndex + 1 == 2)
            {
                txtAlertDays.Visible = true;
                labelAlterDays.Visible = true;
                dtEnd.Visible = true;
                labelEnd.Visible = true;
                txtEffectDate.Visible = true;
                label1.Visible = true;
                label6.Visible = true;
                dtOverDue.Visible = true;
                label7.Visible = true;
                rbChange.Visible = true;
                rbStamp.Visible = true;
            }
            else if ((int)cboShipCertType.SelectedIndex + 1 == 3)
            {
                txtAlertDays.Visible = true;
                label1.Visible = true;
                dtEnd.Visible = true;
                labelEnd.Visible = true;
                txtEffectDate.Visible = false;
                labelAlterDays.Visible = false;
                label6.Visible = false;
                dtOverDue.Visible = false;
                label7.Visible = false;
                rbChange.Checked = true;
                rbChange.Visible = false;
                rbStamp.Visible = false;
            }
        }

        private void txtEffectDate_TextChanged(object sender, EventArgs e)
        {
            if (initing) return;
            decimal a;
            if (!decimal.TryParse(txtEffectDate.Text, out a))
            {
                txtEffectDate.Text = "";
            }
            else if (dtBegin.Value == null)
            {
                return;
            }
            else if ((int)cboShipCertType.SelectedIndex + 1 == 2 || (int)cboShipCertType.SelectedIndex + 1 == 3)
            {
                try
                {
                    if (dtOverDue.Text.Length == 0)
                        dtOverDue.Value = dtBegin.Value.AddYears(int.Parse(txtEffectDate.Text)).AddDays(-1);
                }
                catch { }
            }
            else
            {
                dtOverDue.Value = CommonOperation.ConstParameter.MaxDateTime;
            }
        }
    }
}
