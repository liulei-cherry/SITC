using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ShipCertification.DataObject;
using CommonViewer.BaseControl;
namespace ShipCertification.Viewer
{
    public partial class FrmEditOneShipCertRegister : CommonViewer.BaseForm.FormBase
    {
        public bool NeedRetrieve = false;
        public string ship_id;
        public FrmEditOneShipCertRegister()
        {
            InitializeComponent();
        }
        public FrmEditOneShipCertRegister(ShipCertRegister theShipCertRegister)
            : this(theShipCertRegister, false)
        { }
        public FrmEditOneShipCertRegister(ShipCertRegister theShipCertRegister, bool shipNameVisible)
        {
            InitializeComponent();
            ucShipCertRegister1.ChangeData(theShipCertRegister);
            ucShipCertRegister1.setShipNameVisible(shipNameVisible);//船舶是否可改,true为可以修改，false为不可改.
        }
        public FrmEditOneShipCertRegister(string ship_id)
        {
            InitializeComponent();
            ucShipCertRegister1.setShipSelectName(ship_id);
            this.ship_id = ship_id;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ucShipCertRegister1.UpdateObject())
            {
                NeedRetrieve = true;
                //ucShipCertRegister1.ClearData();
                //ucShipCertRegister1.setShipSelectName(this.ship_id);
                this.Close();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEx2_Click(object sender, EventArgs e)
        {
            if (ucShipCertRegister1.TheObject != null && !ucShipCertRegister1.TheObject.IsWrong
                && !string.IsNullOrEmpty(ucShipCertRegister1.TheObject.GetId()))
            {
                if (ucShipCertRegister1.TheObject.SHIPCERTTYPE != 1 && ucShipCertRegister1.TheObject.SHIPCERTTYPE != 4)
                {
                    FrmShipCertificationCheck frm = new FrmShipCertificationCheck(ucShipCertRegister1.TheObject);//修改船期时不可以修改船舶名称,false为不可以改，true可以.
                    frm.ShowDialog();
                    if (frm.needRetrieve)
                    {
                        this.NeedRetrieve = true;
                        this.Close();
                    }
                }
                else MessageBoxEx.Show("长期证书和存档的证书不需要检查,如希望记录临时记录,请直接在注释中标明即可!");
            }

        }
    }
}