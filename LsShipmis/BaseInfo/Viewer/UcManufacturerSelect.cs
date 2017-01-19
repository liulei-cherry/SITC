using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BaseInfo.Viewer
{
    public partial class UcManufacturerSelect : CommonViewer.BaseControl.ComboxEx
    {
        public UcManufacturerSelect()
        {
            InitializeComponent();
            ChangeMode(true, true, false);
        }
        public void ChangeMode(bool useId, bool canNullIn, bool errCanLeave)
        {
            DataTable dt;
            string err;
            InitializeComponent();
            dt = BaseInfo.DataAccess.ManufacturerService.Instance.getInfo(true, out err);
            Init(dt, useId ? "MANUFACTURER_ID" : "MANUFACTURER_NAME", "MANUFACTURER_NAME", true,
                canNullIn, "服务商", null, errCanLeave);

        }
        public void ChangeMode(bool useId, bool canNullIn, bool errCanLeave, string nullValue)
        {
            DataTable dt;
            string err;
            InitializeComponent();
           
            dt = BaseInfo.DataAccess.ManufacturerService.Instance.getInfo(true, out err);
            Init(dt, useId ? "MANUFACTURER_ID" : "MANUFACTURER_NAME", "MANUFACTURER_NAME",
                true, canNullIn, nullValue, null, errCanLeave);
        }
        public void ChangeMode(string code, bool useId, bool canNullIn, bool errCanLeave, string nullValue)
        {
            DataTable dt;
            string err;
            InitializeComponent();
            dt = BaseInfo.DataAccess.ManufacturerService.Instance.getInfoListByType(code, out err);
            Init(dt, useId ? "MANUFACTURER_ID" : "MANUFACTURER_NAME", "MANUFACTURER_NAME",
                true, canNullIn, nullValue, null, errCanLeave);
        }
        //public void ChangeMode(DataTable dtb, string columnId, string columnValue, bool canNullIn, bool errCanLeave, string nullValue)
        //{
        //    InitializeComponent();
        //    Init(dtb, columnId, columnValue, false, canNullIn, nullValue, null, errCanLeave);
        //}

    }
}
