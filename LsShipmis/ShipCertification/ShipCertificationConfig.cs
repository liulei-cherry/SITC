using System;
using System.Collections.Generic;
using System.Text; 
using System.Windows.Forms;
using ShipCertification.Report;
using ShipCertification.DataObject;
using BaseInfo.Objects;

namespace ShipCertification
{
    public class ShipCertificationConfig
    {
        //证书客户化表格的实现.
        public delegate bool CustomShipCertificationReport(ShipInfo shipInfo, List<ShipCert> allReportCert, 
            List<ShipCertRegister> lstCertsOfOneShip,WorkModelType model, string path,out string err);
        public static CustomShipCertificationReport customShipCertificationReport;

        public delegate void CustomExportAllShipCertificationReportInfo();
        public static CustomExportAllShipCertificationReportInfo customExportAllShipCertificationReportInfo;

        public static Form getCertificationReportOfOneShip()
        {
            return FrmCertificationReportOfOneShip.Instance;
        }
    }
}
