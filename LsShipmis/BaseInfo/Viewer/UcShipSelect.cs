using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BaseInfo.Viewer
{
    public partial class UcShipSelect : CommonViewer.BaseControl.ComboxEx
    {

        public UcShipSelect()
        {
            InitializeComponent();
            ChangeSelectedState(CommonOperation.ConstParameter.IsLandVersion);
        }

        /// <summary>
        /// 设置船舶的显示状态
        /// </summary>
        /// <param name="showAllShip">是否增加“所以船”项</param>
        /// <param name="onlyUsersShip">是否获取个人管理船舶</param>
        public void ChangeSelectedState(bool showAllShip, bool onlyUsersShip)
        {
            DataTable dt;
            string err;
            if (onlyUsersShip)
                dt = BaseInfo.DataAccess.ShipInfoService.Instance.GetOwnerShip(out err);
            else
                dt = BaseInfo.DataAccess.ShipInfoService.Instance.getInfo(out err);
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                Init(dt, "SHIP_ID", "SHIP_NAME", false, showAllShip, "所有船", null, false);
            }
            else
            {
                Init(dt, "SHIP_ID", "SHIP_NAME", false, false, "", null, false);
            }
        }
        public void ChangeSelectedState(bool showAllShip)
        {
            ChangeSelectedState(showAllShip, true);
        }
        public void ChangeSelectedState(bool showAllShip, string nullValue, bool onlyUsersShip)
        {
            DataTable dt;
            string err;
            if (onlyUsersShip)
                dt = BaseInfo.DataAccess.ShipInfoService.Instance.GetOwnerShip(out err);
            else
                dt = BaseInfo.DataAccess.ShipInfoService.Instance.getInfo(out err);
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                Init(dt, "SHIP_ID", "SHIP_NAME", false, showAllShip, nullValue, null, false);
            }
            else
            {
                Init(dt, "SHIP_ID", "SHIP_NAME", false, false, nullValue, null, false);
            }
        }
        public void ChangeSelectedState(bool canEditIn,bool canNullIn, string nullValue, bool onlyUsersShip)
        {
            DataTable dt;
            string err;
            if (onlyUsersShip)
                dt = BaseInfo.DataAccess.ShipInfoService.Instance.GetOwnerShip(out err);
            else
                dt = BaseInfo.DataAccess.ShipInfoService.Instance.getInfo(out err);
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                Init(dt, "SHIP_ID", "SHIP_NAME", canEditIn, canNullIn, nullValue, null, false);
            }
            else
            {
                Init(dt, "SHIP_ID", "SHIP_NAME", canEditIn, canNullIn, nullValue, null, false);
            }
        }
    }
}
