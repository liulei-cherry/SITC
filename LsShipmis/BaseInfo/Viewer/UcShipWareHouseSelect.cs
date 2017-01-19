using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BaseInfo.Viewer
{
    public partial class UcShipWareHouseSelect : CommonViewer.BaseControl.ComboxEx
    {
        public UcShipWareHouseSelect()
        {
            InitializeComponent();
            ChangeMode();
        }
        /// <summary>
        /// 切换下拉模式.
        /// </summary>
        /// <param name="onlyCommon"></param>
        public void ChangeMode()
        {
            DataTable dt;
            string err;
            dt = BaseInfo.DataAccess.ShipWareHouseService.Instance.getInfo(out err);
            Init(dt, "WAREHOUSE_ID", "WAREHOUSE_NAME", false, false, "", null, false);
        }
        /// <summary>
        /// 切换下拉模式.
        /// </summary>
        /// <param name="onlyCommon"></param>
        public void ChangeMode(string shipId)
        {
            DataTable dt;
            string err;
            dt = BaseInfo.DataAccess.ShipWareHouseService.Instance.getInfoByShipId(shipId,out err);
            Init(dt, "WAREHOUSE_ID", "WAREHOUSE_NAME", false, false, "", null, false);
        }
        /// <summary>
        /// 切换下拉模式.
        /// </summary>
        /// <param name="onlyCommon"></param>
        public void ChangeMode(string shipId,bool canNullIn)
        {
            DataTable dt;
            string err;
            dt = BaseInfo.DataAccess.ShipWareHouseService.Instance.getInfoByShipId(shipId, out err);
            Init(dt, "WAREHOUSE_ID", "WAREHOUSE_NAME", false, canNullIn, "", null, false);
        }
    }
}
