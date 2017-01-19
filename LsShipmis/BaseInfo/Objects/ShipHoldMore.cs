using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using BaseInfo.DataAccess;

namespace BaseInfo.Objects
{
    partial class ShipHold : CommonClass
    {
        public override string GetId()
        {
            return _hOLD_ID;
        }

        public override string GetTypeName()
        {
            return "ShipHold";
        }

        public override bool Update(out string err)
        {
            return ShipHoldService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return ShipHoldService.Instance.deleteUnit(this, out err);
        }
        public override void FillThisObject()
        {
            
        }
    }
}
