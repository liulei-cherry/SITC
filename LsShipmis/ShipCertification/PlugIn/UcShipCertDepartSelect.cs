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
    public partial class UcShipCertDepartSelect : CommonViewer.BaseControl.ComboxEx
    { 
       
        public UcShipCertDepartSelect()
        {
            InitializeComponent();
            ReInitControl(true);
        }
        public void ReInitControl(bool canNull)
        {
            DataTable dt; 
            string err;
            dt = ShipCertDepartService.Instance.getInfo(out err); 
            FrmShipCertDepartSelect frm = new FrmShipCertDepartSelect();
            Init(dt, "SHIP_CERT_DEPARTID", "SHIPCERTDEPARTNAME", true, canNull, "", frm, true);
        }
    }
}
