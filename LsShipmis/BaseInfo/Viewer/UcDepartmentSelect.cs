using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BaseInfo.Viewer
{
    public partial class UcDepartmentSelect : CommonViewer.BaseControl.ComboxEx
    {
        public UcDepartmentSelect()
        {
            InitializeComponent();
            ChangeMode(0);
        }
        public void ChangeMode(int mode)
        {
            ChangeMode(mode, true);
        }
        public void ChangeMode(int mode, bool useId)
        {
            DataTable dt;
            string err;
            //land 1,ship 2,all 0,all加全部 3;
            if (mode == 0)
            {
                dt = BaseInfo.DataAccess.DepartmentService.Instance.getInfo(out err);
                Init(dt, useId ? "DEPARTMENTID" : "DEPARTNAME", "DEPARTNAME", false, false, "", null, false);
            }
            else if (mode == 1)
            {
                dt = BaseInfo.DataAccess.DepartmentService.Instance.GetInfo(true, out err);
                Init(dt, useId ? "DEPARTMENTID" : "DEPARTNAME", "DEPARTNAME", false, false, "", null, false);
            }
            else if (mode == 2)
            {
                dt = BaseInfo.DataAccess.DepartmentService.Instance.GetInfo(false, out err);
                Init(dt, useId ? "DEPARTMENTID" : "DEPARTNAME", "DEPARTNAME", false, false, "", null, false);
            }
            else if (mode == 3)
            {
                dt = BaseInfo.DataAccess.DepartmentService.Instance.GetInfo(false, out err);
                DataRow dr = dt.NewRow();
                dr["DEPARTMENTID"] = "0";
                dr["DEPARTNAME"] = "全部";
                dt.Rows.InsertAt(dr, 0);
                Init(dt, useId ? "DEPARTMENTID" : "DEPARTNAME", "DEPARTNAME", false, false, "", null, false);
            }
        }
    }
}
