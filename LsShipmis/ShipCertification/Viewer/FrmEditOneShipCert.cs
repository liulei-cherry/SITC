﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms; 
namespace ShipCertification.Viewer
{
    public partial class FrmEditOneShipCert : CommonViewer.BaseForm.FormBase
    {
        public bool NeedRetrieve = false;
        public FrmEditOneShipCert()
        {
            InitializeComponent();
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ucShipCert.UpdateObject())
            {
                NeedRetrieve = true;
                this.Close();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}