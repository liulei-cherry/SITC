using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseInfo.Objects;
using ShipCertification.Services;

namespace ShipCertification.PlugIn
{   
    public partial class UcShipCertSelect : CommonViewer.BaseControl.ComboxEx
    {

        public UcShipCertSelect()
        {
            InitializeComponent();
            ReInitControl(true);
        }
        public void ReInitControl(bool canNull)
        {
            DataTable dt;
            string err;
            dt = ShipCertService.Instance.getInfo(out err);            
            FrmShipCertSelect frm = new FrmShipCertSelect();
            Init(dt, "SHIP_CERT_ID", "SHIPCERTCHNAME", true, canNull, "其他证书", frm, false);
        }
        public void ReInitControl(string allCertName)
        {
            DataTable dt;
            string err;
            dt = ShipCertService.Instance.getInfo(out err);
            FrmShipCertSelect frm = new FrmShipCertSelect();
            Init(dt, "SHIP_CERT_ID", "SHIPCERTCHNAME", true, true, allCertName, frm, false);
        }
    }
}
