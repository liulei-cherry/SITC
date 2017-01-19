using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ShipCertification.DataObject;
using ShipCertification.Services;
using CommonViewer.BaseControl;

namespace ShipCertification.Viewer
{
    public partial class FrmShipCertificationCheck : CommonViewer.BaseForm.FormBase
    {
        public bool needRetrieve = false;

        ShipCertRegister theObject;
        ShipCertRegister theObject2;
        public FrmShipCertificationCheck()
        {
            InitializeComponent();
        }

        public FrmShipCertificationCheck(ShipCertRegister theObjectIn)
        {
            theObject = theObjectIn;
            InitializeComponent();
        }

        private void FrmShipCertificationCheck_Load(object sender, EventArgs e)
        {
            if (theObject == null || theObject.IsWrong)
            {
                MessageBoxEx.Show("进入当前界面但并未传入任何证书！", "错误提示");
                this.Close();
            }
            else
            {                
                theObject.FillThisObject();
                buttonEx2.Visible = true;
                buttonEx5.Visible = true;
                buttonEx6.Visible = true;
                textBox1.Text = theObject.SHIP_CERT_NAME;
                textBox2.Text = theObject.SHIPCERTNUMB;
                textBox4.Text = theObject.SIGNEDDATE.ToShortDateString();
                textBox3.Text = theObject.EFFECTDATE.ToString();
                dateTimerPickerEx2.Value = DateTime.Today;
                if(theObject.ThisDepart != null)
                ucShipCertDepartSelect1.SelectedText(theObject.ThisDepart.SHIPCERTDEPARTNAME, false);                   
                rbChange.Checked = (theObject.RECERTIFICATION == 1);
                textBox6.Text = theObject.REMARK;
                txtNewCertYear.Text = theObject.EFFECTDATE.ToString();
                changeState();
                FileOperation.FileBoundingOperation.Instance.FileBoundCheck(theObject.GetId(), theObject.ToString(), CommonOperation.Enum.FileBoundingTypes.SHIPCERTCHECK, theObject.SHIP_ID);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            needRetrieve = false;
            this.Close();
        }

        private void buttonEx2_Click(object sender, EventArgs e)
        {
            string err;
            //检验过程包含几个动作.
            #region 1判断内容是否完备，
            DateTime dt = dateTimerPickerEx2.Value;
            if (dt <= theObject.SIGNEDDATE || dt > DateTime.Today.AddDays(1))
            {
                MessageBoxEx.Show("检验日期无效！可能是小于证书签发日期或检验日期超过今天造成的");
                dateTimerPickerEx2.Focus();
                return;

            }
            theObject.MATUREDATE = dt;
            if (string.IsNullOrEmpty(ucShipCertDepartSelect1.GetText()))
            {
                MessageBoxEx.Show("为以后查询方便，检验机构必填！");
                ucShipCertDepartSelect1.Focus();
                return;
            }
            dt = dateTimerPickerEx1.Value;
            if (dt <= theObject.SIGNEDDATE || dt <=dateTimerPickerEx2.Value   ||dt > CommonOperation.ConstParameter.MaxDateTime)
            {
                MessageBoxEx.Show("下次预计检验日期无效！可能是下次预计检验日期小于当前检验日期或签发日期造成的");
                dateTimerPickerEx1.Focus();
                return;
            }

            theObject2 = (ShipCertRegister)theObject.Clone();
            theObject2.MATUREDATE = dt;            
            theObject2.RECERTIFICATION = 0;
            if (rbChange.Checked)
            {
               
                theObject.RECERTIFICATION = 1;
                int newCertEffectYear;
                if (!int.TryParse(txtNewCertYear.Text, out newCertEffectYear))
                {
                    MessageBoxEx.Show("新证书的有效期无效！");
                    txtNewCertYear.Focus();
                    return;
                }
                theObject2.EFFECTDATE = newCertEffectYear;
                theObject2.SHIPCERTNUMB = txtNewCertCode.Text;
                theObject2.SHIP_CERT_REGISTERID = "";

                dt = dtpChangeDate.Value;
                if (dt <= theObject.SIGNEDDATE || dt > DateTime.Today.AddDays(1))
                {
                    MessageBoxEx.Show("签发日期无效！可能是小于签发日期或者大于当前日期");
                    dtpChangeDate.Focus();
                    return;
                }
                theObject2.SIGNEDDATE = dt;
            }
            
            #endregion
            #region 2保存当前证书，--存档
            theObject.SHIPCERTTYPE = 4;
            theObject.REMARK = textBox6.Text;
            if (!theObject.Update(out err))
            {
                MessageBoxEx.Show("证书检验失败！");
                return;
            }
            #endregion
            #region 3保存下一个证书，成为最新
            if (!theObject2.Update(out err))
            {
                MessageBoxEx.Show("新证书形成失败！");
                return;
            }
            #endregion
            MessageBoxEx.Show("证书检验成功！");
            needRetrieve = true;
            this.Close();
        }

        private void buttonEx4_Click(object sender, EventArgs e)
        {
            rbChange.Checked = true;
            changeState();
        }

        private void buttonEx3_Click(object sender, EventArgs e)
        {
            rbCheck.Checked = true;
            changeState();
        }

        private void changeState()
        {
            label9.Visible = rbChange.Checked;
            label10.Visible = rbChange.Checked; 
            label11.Visible = rbChange.Checked;
            dtpChangeDate.Visible = rbChange.Checked;
            txtNewCertYear.Visible = rbChange.Checked;
            txtNewCertCode.Visible = rbChange.Checked;
        }

        private void dateTimerPickerEx2__ValueChanged(object sender, EventArgs e)
        {
            dtpChangeDate.Value = dateTimerPickerEx2.Value;

        }

        private void buttonEx5_Click(object sender, EventArgs e)
        {
            //把当前证书作废.
            if (MessageBoxEx.Show("证书存档或作废是当证书不再有效时发生，此动作将把当前证书存档，而不形成新证书，"+
                "\r操作完毕以后，如果还希望对当前证书进行检验，则需要重新添加此证书！"
                ,"操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                string err;
                if (ShipCertRegisterService.Instance.FinishOrAbolishAShipCert(theObject.GetId(), out err))
                {
                    MessageBoxEx.Show("证书已经成功作废，希望对当前证书进行检验，则需要重新添加此证书");
                    needRetrieve = true;
                    this.Close();
                }
                else
                    MessageBoxEx.Show(err);
            }
        }
         
        private void rbChange_CheckedChanged(object sender, EventArgs e)
        {
            changeState();
        }

        private void rbCheck_CheckedChanged(object sender, EventArgs e)
        {
            changeState();
        }

        private void buttonEx6_Click(object sender, EventArgs e)
        {
            if (theObject == null || theObject.IsWrong) return;
            if (string.IsNullOrEmpty(theObject.GetId()))
            {
                MessageBoxEx.Show("当前证书相关信息为空,无法查看绑定的电子文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                FileOperation.FileBoundingOperation.Instance.FileBoundOperation();
            }
        }

        private void FrmShipCertificationCheck_FormClosed(object sender, FormClosedEventArgs e)
        {
            FileOperation.FileBoundingOperation.Instance.FileBoundCheck("", "", 0, null);  
        }
    }
}