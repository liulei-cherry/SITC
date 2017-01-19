using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BaseInfo.Viewer
{
    public partial class UcCurrencySelect : CommonViewer.BaseControl.ComboxEx
    {
        public UcCurrencySelect()
        {
            InitializeComponent();
            ChangeMode(true,false);
        }
        /// <summary>
        /// 切换下拉模式.
        /// </summary>
        /// <param name="onlyCommon"></param>
        public void ChangeMode(bool onlyCommon,bool useCode)
        {
            DataTable dt;
            string err;
            dt = BaseInfo.DataAccess.CurrencyService.Instance.getInfoByInUse(onlyCommon, out err);
            Init(dt, useCode ? "CURRENCYCODE" : "CURRENCYID", "SHOWINGNAME", false, false, "", null, false);
        }
        /// <summary>
        /// 切换下拉模式.
        /// </summary>
        /// <param name="onlyCommon"></param>
        public void ChangeMode(bool onlyCommon, bool useCode,bool canNullIn)
        {
            DataTable dt;
            string err;
            dt = BaseInfo.DataAccess.CurrencyService.Instance.getInfoByInUse(onlyCommon, out err);
            Init(dt, useCode ? "CURRENCYCODE" : "CURRENCYID", "SHOWINGNAME", false, canNullIn, "", null, false);
        }
    }
}
