using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using BaseInfo.DataAccess;

namespace BaseInfo.Objects
{
    partial class ShipInfo : CommonClass
    {
        public override string GetId()
        {
            return SHIP_ID;
        }
        public override string GetTypeName()
        {
            return "ShipInfo";
        }
        public override bool Update(out string err)
        {
            return ShipInfoService.Instance.saveUnit(this, out err);
        }
        public override bool Delete(out string err)
        {
            return ShipInfoService.Instance.deleteUnit(this, out err);
        }
        public override string ToString()
        {            
            if (this.IsWrong)
            {
                return WhyWrong;
            }
            string shipDetail = SHIP_NAME;
            if (SHIP_CODE.Length > 0)
            {
                shipDetail += "(" + SHIP_CODE + ")"; 
            }
            else if (SHIP_EN_NAME.Length > 0)
            {
                shipDetail += "(" + SHIP_EN_NAME + ")"; 
            }
            return shipDetail;
        }
        public string GetShipMainContactInfo()
        {
            return SSFGS;
        }
        public override void FillThisObject() { }
    }
}
