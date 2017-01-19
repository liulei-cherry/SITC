using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; 
using System.Text;
using System.Windows.Forms;
using BaseInfo.Objects;
using BaseInfo.DataAccess;
namespace BaseInfo.Viewer
{
    public partial class FrmShipQuickSelect : CommonViewer.BaseForm.FormBase
    {

        private ShipInfo theShip;
        public bool SelectUsefull = false;
        public ShipInfo TheShip
        {
            get { return theShip; }            
        }
        public FrmShipQuickSelect():this(true)
        {  
        }
        public FrmShipQuickSelect(bool showAllShip)
        {             
            InitializeComponent();           
            ucShipSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(ucShipSelect1_TheSelectedChanged);
            ucShipSelect1.ChangeSelectedState(showAllShip);
        } 

        void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            theShip = (ShipInfo)ShipInfoService.Instance.GetOneObjectById(theSelectedObject);
        }

        private void button1_Click(object sender, EventArgs e)
        {       
            SelectUsefull = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectUsefull = false;
            this.Close();
        }
    }
}