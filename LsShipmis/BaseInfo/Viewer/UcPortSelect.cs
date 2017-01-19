using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BaseInfo.Viewer
{
    public partial class UcPortSelect : CommonViewer.BaseControl.ComboxEx
    {
        public UcPortSelect()
        {
            InitializeComponent();
            ChangeMode(true,true,true,false);
        }
        public void ChangeMode(bool useId,bool canEdit, bool canNull, bool errCanLeave)
        {
            DataTable dt;
            string err;            
            dt = BaseInfo.DataAccess.PortInfoService.Instance.getInfo(out err);
            FrmPortInfoSelect frm = new FrmPortInfoSelect();
            Init(dt, useId ? "PORTID" : "CNAME", "CNAME", canEdit, canNull, "", frm, errCanLeave);
        }
    }
}
