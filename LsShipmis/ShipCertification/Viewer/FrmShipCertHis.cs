using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ShipCertification.DataObject;
using ShipCertification.Services;
using CommonViewer.MultiLanguage;
namespace ShipCertification.Viewer
{
    public partial class FrmShipCertHis : CommonViewer.BaseForm.FormBase
    {

        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmShipCertHis instance = new FrmShipCertHis();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmShipCertHis Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmShipCertHis.instance = new FrmShipCertHis();
                }
                return FrmShipCertHis.instance;
            }
        }
        #endregion
        string lastShipId = "";
        string lastShipCertId = "";
        private FrmShipCertHis()
        {
            InitializeComponent();
            ucShipSelect1.ChangeSelectedState(false, true);
            ucShipCertSelect1.ReInitControl("全部证书");
            ucDataGridView1.SelectedChanged += new CommonViewer.UcDataGridView.DeleSelectedChanged(ucDataGridView1_SelectedChanged);
            ucShipSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(ucShipSelect1_TheSelectedChanged);
            ucShipCertSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(ucShipCertSelect1_TheSelectedChanged);
        }

        void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            retrieveData();
        }

        void ucShipCertSelect1_TheSelectedChanged(string theSelectedObject)
        {
            retrieveData();
        }

        void ucDataGridView1_SelectedChanged(int rowNumber)
        {
            if (rowNumber < 0 || rowNumber >= ucDataGridView1.Rows.Count 
                || !ucDataGridView1.Columns.Contains("SHIP_ID") || !ucDataGridView1.Columns.Contains("SHIP_CERT_ID"))
            {
                retrieveCertData(null);
                return;
            }
            string shipId = ucDataGridView1.Rows[rowNumber].Cells["SHIP_ID"].Value.ToString();
            string shipCertId = ucDataGridView1.Rows[rowNumber].Cells["SHIP_CERT_ID"].Value.ToString();
            if (shipId.Equals(lastShipId) && shipCertId.EndsWith(lastShipCertId) && lastShipCertId.Length >0) return;
            lastShipId = shipId;
            lastShipCertId = shipCertId;
            ShipCertRegister theObject = ShipCertRegisterService.Instance.GetTheLastRegisterOfShipCert(lastShipId, lastShipCertId);
            retrieveCertData(theObject);
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmShipCertHis_Load(object sender, EventArgs e)
        {
            ucShipCertRegister1.SetCanEdit(false);
            retrieveData();
            setDataView();            
        }

        private void setDataView()
        {    
            //ucDataGridView1  
            ucDataGridView1.LoadGridView("FrmShipCertHis.ucDataGridView1");
            ucDataGridView1.SetDataGridViewNoSort();
            ucDataGridView1.Columns["SHIP_ID"].Visible = false;
            ucDataGridView1.Columns["SHIP_CERT_ID"].Visible = false;
            ucDataGridView1.Columns["SHIP_NAME"].HeaderText = "船舶名称";
            ucDataGridView1.Columns["SHIP_CERT_NAME"].HeaderText = "证书名称"; 
            ucDataGridView1.Columns["SIGNEDDATE"].HeaderText = "签发日期";
        }

        private void retrieveData()
        {
            string shipid;
            string certid;
            shipid = ucShipSelect1.GetId();
            certid = ucShipCertSelect1.GetId();

            retrieveCertData(null);
            DataTable dt;
            if (checkBox1.Checked)
            {
                dt = ShipCertRegisterService.Instance.GetAllShipCertificationOfShipAndCert(shipid, certid, true);
            }
            else
            {
                dt = ShipCertRegisterService.Instance.GetAllShipCertificationOfShipAndCert(shipid, certid, false);
            }
            ucDataGridView1.DataSource = dt;
        }

        private void retrieveCertData(ShipCertRegister theObject)
        {
            DataTable dt;
            if (theObject == null || theObject.IsWrong)
            {  
                FileOperation.FileBoundingOperation.Instance.FileBoundCheck("", "", 0, "");
                ucShipCertRegister1.ClearData();
                ucDataGridView2.DataSource = null;                
                lastShipCertId = "";
                lastShipId = "";
                return;
            }
            ucShipCertRegister1.ChangeData(theObject);
            dt = ShipCertRegisterService.Instance.GetAllShipCertificationHisOfShipAndCert(theObject.SHIP_ID, theObject.SHIP_CERT_ID);
            ucDataGridView2.DataSource = dt;
            FileOperation.FileBoundingOperation.Instance.FileBoundCheck(theObject.SHIP_CERT_ID, (theObject.ThisCert == null ? "" : theObject.SHIP_CERT_NAME),
              CommonOperation.Enum.FileBoundingTypes.SHIPCERTREGISTER, theObject.SHIP_ID);
            ucDataGridView2.LoadGridView("FrmShipCertHis.ucDataGridView2");
            ucDataGridView2.Columns["SHIP_CERT_REGISTERID"].Visible = false;
            ucDataGridView2.Columns["alertdate"].Visible = false;
            ucDataGridView2.Columns["enddate"].Visible = false;
            ucDataGridView2.Columns["EFFECTDATE"].Visible = false;
            ucDataGridView2.Columns["SIGNEDDATE"].Visible = false;
            ucDataGridView2.Columns["SHIP_NAME"].HeaderText = "船舶名称";
            ucDataGridView2.Columns["SHIP_CERT_NAME"].HeaderText = "证书名称";
            ucDataGridView2.Columns["MATUREDATE"].HeaderText = "检验|换证日期";
            ucDataGridView2.Columns["SHIPCERTDEPARTNAME"].HeaderText = "检验机构";
            ucDataGridView2.Columns["certType"].HeaderText = "处理"; 
            ucDataGridView2.Columns["MATUREDATE"].DisplayIndex = 8;  
            ucDataGridView2.Columns["remark"].HeaderText = "备注"; 
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            retrieveData();
        }

        private void FrmShipCertHis_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        private void ucShipCertRegister1_Load(object sender, EventArgs e)
        {
            MultiLanguageTranslate multiLanguageTranslate = MultiLanguageTranslate.Instance;
            for (int i = 0; i < ucShipCertRegister1.Controls.Count; i++)
            {
                multiLanguageTranslate.Translate((System.Windows.Forms.TableLayoutPanel)ucShipCertRegister1.Controls[i]);
            }
        }

        private void FrmShipCertHis_FormClosing(object sender, FormClosingEventArgs e)
        {
            ucDataGridView1.SaveGridView("FrmShipCertHis.ucDataGridView1");
            ucDataGridView2.SaveGridView("FrmShipCertHis.ucDataGridView2");
        }
    }
}