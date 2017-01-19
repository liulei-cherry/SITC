using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using CommonOperation.Interfaces;

namespace BaseInfo.BaseClass
{
    /// <summary>
    /// 所有物品的基类,可能是 设备,备件,物料,油水等等任何内容.
    /// 共同拥有的属性包含名称,计量单位,(购买厂家,价值等信息暂时不在基类中实现)
    /// </summary>
    public abstract class Item : CommonClass
    {
        protected string itemName;
        protected string itemDetail;

    }
}
