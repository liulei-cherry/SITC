using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using BaseInfo.DataAccess;

namespace BaseInfo.Objects
{
    partial class ShipOilWareHouse : CommonClass
    {
        public override string GetId()
        {
            return _owWareHouse_ID;
        }

        public override string GetTypeName()
        {
            return "ShipOilWareHouse";
        }

        public override bool Update(out string err)
        {
            return ShipOilWareHouseService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return ShipOilWareHouseService.Instance.deleteUnit(this, out err);
        }
        public override void FillThisObject()
        {
            
        }
    }
}
